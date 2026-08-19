const API_VERSION = '7.0'

function headers(pat) {
  return {
    'Content-Type': 'application/json',
    'x-ado-pat': pat
  }
}

async function get(url, pat) {
  const res = await fetch(url, { headers: headers(pat) })
  if (!res.ok) {
    const text = await res.text()
    throw new Error(`ADO API error ${res.status}: ${text.slice(0, 200)}`)
  }
  return res.json()
}

async function post(url, pat, body) {
  const res = await fetch(url, {
    method: 'POST',
    headers: headers(pat),
    body: JSON.stringify(body)
  })
  if (!res.ok) return null
  return res.json()
}

const base = (org) => `/ado-api/${org}`

// ── Projects ────────────────────────────────────────────────────────────────
export async function getProjects(org, pat) {
  const data = await get(`${base(org)}/_apis/projects?api-version=${API_VERSION}&$top=500`, pat)
  return data.value || []
}

// ── Teams ───────────────────────────────────────────────────────────────────
export async function getTeams(org, pat, projectId) {
  const data = await get(`${base(org)}/_apis/projects/${projectId}/teams?api-version=${API_VERSION}&$top=500`, pat)
  return data.value || []
}

// ── Iterations ──────────────────────────────────────────────────────────────
export async function getIterations(org, pat, projectName, teamName) {
  const encoded = encodeURIComponent(teamName)
  const data = await get(
    `${base(org)}/${encodeURIComponent(projectName)}/${encoded}/_apis/work/teamsettings/iterations?api-version=${API_VERSION}`,
    pat
  )
  return data.value || []
}

// ── Capacities ──────────────────────────────────────────────────────────────
export async function getCapacities(org, pat, projectName, teamName, iterationId) {
  const data = await get(
    `${base(org)}/${encodeURIComponent(projectName)}/${encodeURIComponent(teamName)}/_apis/work/teamsettings/iterations/${iterationId}/capacities?api-version=${API_VERSION}`,
    pat
  )
  return data.value || []
}

// ── Team Days Off ────────────────────────────────────────────────────────────
export async function getTeamDaysOff(org, pat, projectName, teamName, iterationId) {
  try {
    const data = await get(
      `${base(org)}/${encodeURIComponent(projectName)}/${encodeURIComponent(teamName)}/_apis/work/teamsettings/iterations/${iterationId}/teamdaysoff?api-version=${API_VERSION}`,
      pat
    )
    return data.daysOff || []
  } catch {
    return []
  }
}

// ── Work Items ───────────────────────────────────────────────────────────────
export async function getWorkItemsForIteration(org, pat, projectName, iterationPath) {
  const wiqlBody = {
    query: `SELECT [System.Id] FROM WorkItems
            WHERE [System.IterationPath] UNDER '${iterationPath}'
            AND [System.WorkItemType] IN ('Task','Bug','User Story','Feature')
            AND [System.TeamProject] = '${projectName}'`
  }
  const wiql = await post(
    `${base(org)}/${encodeURIComponent(projectName)}/_apis/wit/wiql?api-version=${API_VERSION}`,
    pat,
    wiqlBody
  )
  if (!wiql || !wiql.workItems?.length) return []

  const ids = wiql.workItems.map(w => w.id)
  const fields = [
    'System.Id',
    'System.Title',
    'System.WorkItemType',
    'System.State',
    'System.AssignedTo',
    'System.IterationPath',
    'Microsoft.VSTS.Scheduling.OriginalEstimate',
    'Microsoft.VSTS.Scheduling.RemainingWork',
    'Microsoft.VSTS.Scheduling.CompletedWork',
    'Microsoft.VSTS.Scheduling.StoryPoints'
  ].join(',')

  const results = []
  for (let i = 0; i < ids.length; i += 200) {
    const batch = ids.slice(i, i + 200).join(',')
    try {
      const data = await get(
        `${base(org)}/${encodeURIComponent(projectName)}/_apis/wit/workitems?ids=${batch}&fields=${fields}&api-version=${API_VERSION}`,
        pat
      )
      results.push(...(data.value || []))
    } catch {
      // skip batch on error
    }
  }
  return results
}

// ── Full Data Fetch (with progress callback) ─────────────────────────────────
export async function fetchAllData(org, pat, startDate, endDate, onProgress) {
  const start = new Date(startDate)
  const end = new Date(endDate)

  onProgress('Fetching projects...', 0)
  const projects = await getProjects(org, pat)
  onProgress(`Found ${projects.length} projects`, 5)

  const allData = []
  let done = 0

  for (const proj of projects) {
    const pname = proj.name
    let teams = []
    try {
      teams = await getTeams(org, pat, proj.id)
    } catch { continue }

    // Cache work items per iteration path within this project to avoid duplicate fetches
    const wiCache = {}

    for (const team of teams) {
      const tname = team.name
      let iters = []
      try {
        iters = await getIterations(org, pat, pname, tname)
      } catch { continue }

      const aprilIters = iters.filter(it => {
        const s = it.attributes?.startDate
        const f = it.attributes?.finishDate
        if (!s || !f) return false
        return new Date(s) <= end && new Date(f) >= start
      })

      for (const iter of aprilIters) {
        const iid = iter.id
        const iname = iter.name
        const ipath = iter.path || ''
        const iterStart = iter.attributes?.startDate?.slice(0, 10) || ''
        const iterEnd = iter.attributes?.finishDate?.slice(0, 10) || ''

        let caps = []
        try { caps = await getCapacities(org, pat, pname, tname, iid) } catch {}

        // Use cached work items if this iteration path was already fetched
        let workItems = []
        if (wiCache[ipath] !== undefined) {
          workItems = wiCache[ipath]
        } else {
          try { workItems = await getWorkItemsForIteration(org, pat, pname, ipath) } catch {}
          wiCache[ipath] = workItems
        }

        // Map work items
        const mappedItems = workItems.map(wi => {
          const f = wi.fields || {}
          const assigned = f['System.AssignedTo']
          const memberName = typeof assigned === 'object' ? assigned?.displayName : (assigned || 'Unassigned')
          return {
            id: f['System.Id'],
            title: f['System.Title'] || '',
            type: f['System.WorkItemType'] || '',
            state: f['System.State'] || '',
            assignedTo: memberName,
            iterationPath: f['System.IterationPath'] || '',
            originalEstimate: f['Microsoft.VSTS.Scheduling.OriginalEstimate'] || 0,
            remainingWork: f['Microsoft.VSTS.Scheduling.RemainingWork'] || 0,
            completedWork: f['Microsoft.VSTS.Scheduling.CompletedWork'] || 0,
            storyPoints: f['Microsoft.VSTS.Scheduling.StoryPoints'] || 0
          }
        })

        // Actuals by member
        const actualsByMember = {}
        mappedItems.forEach(wi => {
          if (!actualsByMember[wi.assignedTo]) actualsByMember[wi.assignedTo] = 0
          actualsByMember[wi.assignedTo] += wi.completedWork
        })

        // Build member rows
        const memberRows = []
        if (caps.length > 0) {
          caps.forEach(cap => {
            const mi = cap.teamMember || {}
            const mname = mi.displayName || 'Unknown'
            const activities = cap.activities || []
            const capPerDay = activities.reduce((s, a) => s + (a.capacityPerDay || 0), 0)
            const memberDaysOff = cap.daysOff || []
            const actual = actualsByMember[mname] || 0
            memberRows.push({
              member: mname,
              memberId: mi.id || '',
              capacityPerDay: capPerDay,
              memberDaysOff,
              actualHours: Math.round(actual * 100) / 100,
              workItems: mappedItems.filter(wi => wi.assignedTo === mname)
            })
          })
        } else {
          Object.entries(actualsByMember).forEach(([mname, actual]) => {
            memberRows.push({
              member: mname,
              memberId: '',
              capacityPerDay: 0,
              memberDaysOff: [],
              actualHours: Math.round(actual * 100) / 100,
              workItems: mappedItems.filter(wi => wi.assignedTo === mname)
            })
          })
        }

        allData.push({
          project: pname,
          team: tname,
          iteration: iname,
          iterationPath: ipath,
          iterationStart: iterStart,
          iterationEnd: iterEnd,
          members: memberRows,
          allWorkItems: mappedItems
        })
      }
    }

    done++
    const pct = 5 + Math.round((done / projects.length) * 90)
    onProgress(`Processing: ${pname}`, pct)
  }

  onProgress('Done!', 100)
  return allData
}
