import { useState } from 'react'
import DrillDownPanel from './DrillDownPanel'
import { computeMemberMetrics, utilColor, utilBg } from '../utils/metrics'

export default function ProjectReport({ projectName, entries, filters, groupBy = { project: true, team: true } }) {
  const forceOpen = !groupBy.project
  const [open, setOpen] = useState(true)
  const isOpen = forceOpen || open

  const filtered = entries.filter(e => {
    if (filters.teams?.length && !filters.teams.includes(e.team)) return false
    if (filters.iterations?.length && !filters.iterations.includes(e.iteration)) return false
    return true
  }).map(e => ({
    ...e,
    members: e.members.filter(m => {
      if (filters.members?.length && !filters.members.includes(m.member)) return false
      const metrics = computeMemberMetrics({ ...m, iterationStart: e.iterationStart, iterationEnd: e.iterationEnd })
      if (filters.utilMin !== undefined && metrics.utilPct < filters.utilMin) return false
      if (filters.utilMax !== undefined && metrics.utilPct > filters.utilMax) return false
      return true
    })
  })).filter(e => e.members.length > 0)

  // Project-level totals
  const totals = filtered.reduce((acc, e) => {
    e.members.forEach(m => {
      const met = computeMemberMetrics({ ...m, iterationStart: e.iterationStart, iterationEnd: e.iterationEnd })
      acc.plan += met.planTime
      acc.cap += met.actualCapacity
      acc.util += met.actualHours
    })
    return acc
  }, { plan: 0, cap: 0, util: 0 })

  const overallPct = totals.cap > 0 ? Math.round((totals.util / totals.cap) * 1000) / 10 : 0

  return (
    <div style={{ background: 'white', borderRadius: 10, border: '1px solid #e5e9f0', marginBottom: 16, overflow: 'hidden' }}>
      {/* Project header — hide collapse when project grouping is off */}
      {groupBy.project && (
        <div onClick={() => setOpen(o => !o)} style={{ display: 'flex', alignItems: 'center', gap: 14, padding: '14px 18px', cursor: 'pointer', background: '#1F3864', color: 'white' }}>
          <span style={{ fontSize: 13 }}>{isOpen ? '▾' : '▸'}</span>
          <span style={{ fontWeight: 700, fontSize: 15, flex: 1 }}>📁 {projectName}</span>
          <div style={{ display: 'flex', gap: 20, fontSize: 12 }}>
            <div><span style={{ opacity: 0.7 }}>Plan </span><strong>{Math.round(totals.plan * 10) / 10}h</strong></div>
            <div><span style={{ opacity: 0.7 }}>Capacity </span><strong>{Math.round(totals.cap * 10) / 10}h</strong></div>
            <div><span style={{ opacity: 0.7 }}>Utilized </span><strong>{Math.round(totals.util * 10) / 10}h</strong></div>
            <div style={{ background: utilBg(overallPct), color: utilColor(overallPct), padding: '2px 12px', borderRadius: 20, fontWeight: 700 }}>{overallPct}%</div>
          </div>
        </div>
      )}

      {/* Drill-down entries */}
      {isOpen && (
        <div style={{ padding: '12px 14px' }}>
          {filtered.length === 0
            ? <div style={{ padding: 20, textAlign: 'center', color: '#aaa', fontSize: 13 }}>No data for current filters</div>
            : filtered.map((entry, i) => <DrillDownPanel key={i} entry={entry} groupBy={groupBy} />)
          }
        </div>
      )}
    </div>
  )
}
