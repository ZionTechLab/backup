import { computeMemberMetrics, utilColor, utilBg } from '../utils/metrics'

export default function ConsolidatedReport({ data, filters }) {
  const byProject = {}

  data.forEach(entry => {
    if (filters.projects?.length && !filters.projects.includes(entry.project)) return
    if (filters.teams?.length && !filters.teams.includes(entry.team)) return
    if (filters.iterations?.length && !filters.iterations.includes(entry.iteration)) return

    if (!byProject[entry.project]) byProject[entry.project] = { plan: 0, cap: 0, util: 0, members: new Set(), teams: new Set() }

    entry.members.forEach(m => {
      if (filters.members?.length && !filters.members.includes(m.member)) return
      const met = computeMemberMetrics({ ...m, iterationStart: entry.iterationStart, iterationEnd: entry.iterationEnd })
      if (filters.utilMin !== undefined && met.utilPct < filters.utilMin) return
      if (filters.utilMax !== undefined && met.utilPct > filters.utilMax) return
      byProject[entry.project].plan += met.planTime
      byProject[entry.project].cap += met.actualCapacity
      byProject[entry.project].util += met.actualHours
      byProject[entry.project].members.add(m.member)
      byProject[entry.project].teams.add(entry.team)
    })
  })

  const rows = Object.entries(byProject).map(([proj, d]) => ({
    project: proj,
    teams: d.teams.size,
    members: d.members.size,
    plan: Math.round(d.plan * 10) / 10,
    cap: Math.round(d.cap * 10) / 10,
    util: Math.round(d.util * 10) / 10,
    pct: d.cap > 0 ? Math.round((d.util / d.cap) * 1000) / 10 : 0
  }))

  const grand = rows.reduce((acc, r) => ({
    plan: acc.plan + r.plan, cap: acc.cap + r.cap, util: acc.util + r.util, members: acc.members + r.members
  }), { plan: 0, cap: 0, util: 0, members: 0 })
  const grandPct = grand.cap > 0 ? Math.round((grand.util / grand.cap) * 1000) / 10 : 0

  return (
    <div style={{ background: 'white', borderRadius: 10, border: '1px solid #e5e9f0', marginBottom: 16, overflow: 'hidden' }}>
      {/* Summary Cards */}
      <div style={{ display: 'grid', gridTemplateColumns: 'repeat(4, 1fr)', gap: 0, borderBottom: '1px solid #e5e9f0' }}>
        {[
          { label: 'Plan Time', val: `${Math.round(grand.plan * 10) / 10}h`, sub: 'Total planned hours' },
          { label: 'Actual Capacity', val: `${Math.round(grand.cap * 10) / 10}h`, sub: 'After days off' },
          { label: 'Utilized Time', val: `${Math.round(grand.util * 10) / 10}h`, sub: 'Completed work logged' },
          { label: 'Utilization %', val: `${grandPct}%`, sub: 'Utilized / Actual Cap', highlight: true, pct: grandPct }
        ].map((card, i) => (
          <div key={i} style={{ padding: '18px 20px', borderRight: i < 3 ? '1px solid #e5e9f0' : 'none' }}>
            <div style={{ fontSize: 11, fontWeight: 700, color: '#888', textTransform: 'uppercase', letterSpacing: '0.5px', marginBottom: 6 }}>{card.label}</div>
            <div style={{ fontSize: 26, fontWeight: 700, color: card.highlight ? utilColor(card.pct) : '#1F3864' }}>{card.val}</div>
            <div style={{ fontSize: 11, color: '#aaa', marginTop: 4 }}>{card.sub}</div>
          </div>
        ))}
      </div>

      {/* Table */}
      <div style={{ padding: '14px 16px' }}>
        <div style={{ fontSize: 12, fontWeight: 700, color: '#888', textTransform: 'uppercase', letterSpacing: '0.5px', marginBottom: 10 }}>Project Breakdown</div>
        <table style={{ width: '100%', borderCollapse: 'collapse', fontSize: 13 }}>
          <thead>
            <tr style={{ background: '#f8fafc' }}>
              {['Project', 'Teams', 'Members', 'Plan Time', 'Actual Capacity', 'Utilized', 'Utilization %', 'Bar'].map(h => (
                <th key={h} style={{ padding: '8px 12px', textAlign: h === 'Project' ? 'left' : 'center', fontWeight: 600, fontSize: 11, color: '#666', borderBottom: '2px solid #e5e9f0' }}>{h}</th>
              ))}
            </tr>
          </thead>
          <tbody>
            {rows.map((r, i) => (
              <tr key={r.project} style={{ background: i % 2 === 0 ? 'white' : '#fafbfd', borderBottom: '1px solid #eef2f7' }}>
                <td style={{ padding: '9px 12px', fontWeight: 600, color: '#1F3864' }}>{r.project}</td>
                <td style={{ padding: '9px 12px', textAlign: 'center', color: '#666' }}>{r.teams}</td>
                <td style={{ padding: '9px 12px', textAlign: 'center', color: '#666' }}>{r.members}</td>
                <td style={{ padding: '9px 12px', textAlign: 'center' }}>{r.plan}h</td>
                <td style={{ padding: '9px 12px', textAlign: 'center' }}>{r.cap}h</td>
                <td style={{ padding: '9px 12px', textAlign: 'center', fontWeight: 600 }}>{r.util}h</td>
                <td style={{ padding: '9px 12px', textAlign: 'center' }}>
                  <span style={{ background: utilBg(r.pct), color: utilColor(r.pct), padding: '3px 12px', borderRadius: 20, fontWeight: 700, fontSize: 12 }}>{r.pct}%</span>
                </td>
                <td style={{ padding: '9px 12px', minWidth: 120 }}>
                  <div style={{ background: '#eef2f7', borderRadius: 4, height: 8, overflow: 'hidden' }}>
                    <div style={{ height: '100%', width: `${Math.min(r.pct, 100)}%`, background: utilColor(r.pct), borderRadius: 4, transition: 'width 0.4s' }} />
                  </div>
                </td>
              </tr>
            ))}
            {/* Grand Total */}
            <tr style={{ background: '#1F3864', color: 'white', fontWeight: 700 }}>
              <td style={{ padding: '10px 12px' }}>TOTAL</td>
              <td style={{ padding: '10px 12px', textAlign: 'center' }}>—</td>
              <td style={{ padding: '10px 12px', textAlign: 'center' }}>{grand.members}</td>
              <td style={{ padding: '10px 12px', textAlign: 'center' }}>{Math.round(grand.plan * 10) / 10}h</td>
              <td style={{ padding: '10px 12px', textAlign: 'center' }}>{Math.round(grand.cap * 10) / 10}h</td>
              <td style={{ padding: '10px 12px', textAlign: 'center' }}>{Math.round(grand.util * 10) / 10}h</td>
              <td style={{ padding: '10px 12px', textAlign: 'center' }}>{grandPct}%</td>
              <td style={{ padding: '10px 12px' }}></td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  )
}
