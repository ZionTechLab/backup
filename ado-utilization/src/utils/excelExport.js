import * as XLSX from 'xlsx'
import { computeMemberMetrics, calcUtilizationPct } from './metrics'

function styleHeader(ws, range) {
  for (let C = range.s.c; C <= range.e.c; C++) {
    const addr = XLSX.utils.encode_cell({ r: 0, c: C })
    if (!ws[addr]) continue
    ws[addr].s = {
      fill: { fgColor: { rgb: '1F3864' } },
      font: { color: { rgb: 'FFFFFF' }, bold: true },
      alignment: { horizontal: 'center' }
    }
  }
}

// Flatten all data into flat rows with metrics
function buildFlatRows(data, filters) {
  const rows = []
  data.forEach(entry => {
    if (filters.projects?.length && !filters.projects.includes(entry.project)) return
    if (filters.teams?.length && !filters.teams.includes(entry.team)) return

    entry.members.forEach(m => {
      if (filters.members?.length && !filters.members.includes(m.member)) return

      const metrics = computeMemberMetrics({
        ...m,
        iterationStart: entry.iterationStart,
        iterationEnd: entry.iterationEnd
      })

      const utilPct = calcUtilizationPct(metrics.actualHours, metrics.actualCapacity)
      if (filters.utilMin !== undefined && utilPct < filters.utilMin) return
      if (filters.utilMax !== undefined && utilPct > filters.utilMax) return

      rows.push({
        Project: entry.project,
        Team: entry.team,
        Iteration: entry.iteration,
        'Iteration Start': entry.iterationStart,
        'Iteration End': entry.iterationEnd,
        Member: m.member,
        'Capacity/Day (h)': metrics.capacityPerDay,
        'Days Off': metrics.daysOff,
        'Plan Time (h)': metrics.planTime,
        'Actual Capacity (h)': metrics.actualCapacity,
        'Utilized Time (h)': metrics.actualHours,
        'Utilization %': `${utilPct}%`
      })
    })
  })
  return rows
}

function buildWorkItemRows(data, filters) {
  const rows = []
  data.forEach(entry => {
    if (filters.projects?.length && !filters.projects.includes(entry.project)) return
    entry.allWorkItems?.forEach(wi => {
      rows.push({
        Project: entry.project,
        Team: entry.team,
        Iteration: entry.iteration,
        'Work Item ID': wi.id,
        Title: wi.title,
        Type: wi.type,
        State: wi.state,
        'Assigned To': wi.assignedTo,
        'Original Estimate (h)': wi.originalEstimate,
        'Remaining Work (h)': wi.remainingWork,
        'Completed Work (h)': wi.completedWork,
        'Story Points': wi.storyPoints
      })
    })
  })
  return rows
}

function buildProjectSummary(data, filters) {
  const byProject = {}
  data.forEach(entry => {
    if (filters.projects?.length && !filters.projects.includes(entry.project)) return
    if (!byProject[entry.project]) byProject[entry.project] = { planTime: 0, actualCapacity: 0, actualHours: 0, members: new Set() }
    entry.members.forEach(m => {
      const metrics = computeMemberMetrics({ ...m, iterationStart: entry.iterationStart, iterationEnd: entry.iterationEnd })
      byProject[entry.project].planTime += metrics.planTime
      byProject[entry.project].actualCapacity += metrics.actualCapacity
      byProject[entry.project].actualHours += metrics.actualHours
      byProject[entry.project].members.add(m.member)
    })
  })
  return Object.entries(byProject).map(([proj, d]) => ({
    Project: proj,
    'Total Members': d.members.size,
    'Plan Time (h)': Math.round(d.planTime * 10) / 10,
    'Actual Capacity (h)': Math.round(d.actualCapacity * 10) / 10,
    'Utilized Time (h)': Math.round(d.actualHours * 10) / 10,
    'Utilization %': `${Math.round((d.actualHours / (d.actualCapacity || 1)) * 1000) / 10}%`
  }))
}

export function exportToExcel(data, filters = {}, dateRange = {}) {
  const wb = XLSX.utils.book_new()

  // Sheet 1: Consolidated Summary
  const summaryRows = buildProjectSummary(data, filters)
  const wsSummary = XLSX.utils.json_to_sheet(summaryRows)
  styleHeader(wsSummary, XLSX.utils.decode_range(wsSummary['!ref']))
  wsSummary['!cols'] = [{ wch: 25 }, { wch: 16 }, { wch: 18 }, { wch: 20 }, { wch: 18 }, { wch: 14 }]
  XLSX.utils.book_append_sheet(wb, wsSummary, 'Consolidated Summary')

  // Sheet 2: Detailed (all members)
  const flatRows = buildFlatRows(data, filters)
  const wsDetail = XLSX.utils.json_to_sheet(flatRows)
  styleHeader(wsDetail, XLSX.utils.decode_range(wsDetail['!ref']))
  wsDetail['!cols'] = [
    { wch: 22 }, { wch: 22 }, { wch: 20 }, { wch: 14 }, { wch: 12 },
    { wch: 25 }, { wch: 16 }, { wch: 10 }, { wch: 14 }, { wch: 18 }, { wch: 16 }, { wch: 14 }
  ]
  XLSX.utils.book_append_sheet(wb, wsDetail, 'Member Detail')

  // Sheet 3+: Per-project sheets
  const projects = [...new Set(data.map(d => d.project))]
  projects.forEach(proj => {
    const projRows = buildFlatRows(data, { ...filters, projects: [proj] })
    if (!projRows.length) return
    const ws = XLSX.utils.json_to_sheet(projRows)
    styleHeader(ws, XLSX.utils.decode_range(ws['!ref']))
    ws['!cols'] = wsDetail['!cols']
    const sheetName = proj.slice(0, 31).replace(/[\\/:*?[\]]/g, '')
    XLSX.utils.book_append_sheet(wb, ws, sheetName)
  })

  // Sheet: Work Items
  const wiRows = buildWorkItemRows(data, filters)
  if (wiRows.length) {
    const wsWI = XLSX.utils.json_to_sheet(wiRows)
    styleHeader(wsWI, XLSX.utils.decode_range(wsWI['!ref']))
    wsWI['!cols'] = [
      { wch: 20 }, { wch: 18 }, { wch: 18 }, { wch: 12 }, { wch: 40 },
      { wch: 14 }, { wch: 16 }, { wch: 25 }, { wch: 20 }, { wch: 20 }, { wch: 20 }, { wch: 12 }
    ]
    XLSX.utils.book_append_sheet(wb, wsWI, 'Work Items')
  }

  const from = dateRange.start || ''
  const to = dateRange.end || ''
  const filename = `ADO_Utilization_${from}_to_${to}.xlsx`
  XLSX.writeFile(wb, filename)
}
