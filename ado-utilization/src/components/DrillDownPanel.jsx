import { useState } from 'react'
import MemberRow from './MemberRow'
import { computeMemberMetrics, utilColor, utilBg } from '../utils/metrics'

export default function DrillDownPanel({ entry, groupBy }) {
  const forceOpen = groupBy && !groupBy.team
  const [open, setOpen] = useState(false)
  const isOpen = forceOpen || open
  const showMembers = groupBy?.member !== false

  const totalActual = entry.members.reduce((s, m) => s + m.actualHours, 0)
  const totalOrigEst = entry.members.reduce((s, m) =>
    s + (m.workItems || []).reduce((a, w) => a + (w.originalEstimate || 0), 0), 0)
  const totalPlan = entry.members.reduce((s, m) => {
    const met = computeMemberMetrics({ ...m, iterationStart: entry.iterationStart, iterationEnd: entry.iterationEnd })
    return s + met.planTime
  }, 0)
  const totalCap = entry.members.reduce((s, m) => {
    const met = computeMemberMetrics({ ...m, iterationStart: entry.iterationStart, iterationEnd: entry.iterationEnd })
    return s + met.actualCapacity
  }, 0)
  const totalPct = totalCap > 0 ? Math.round((totalActual / totalCap) * 1000) / 10 : 0

  return (
    <div style={{ border: '1px solid #e5e9f0', borderRadius: 8, marginBottom: 8, overflow: 'hidden' }}>
      {/* Row header — hide collapse toggle when team grouping is off */}
      {groupBy?.team !== false && (
        <div
          onClick={() => setOpen(o => !o)}
          style={{ display: 'flex', alignItems: 'center', gap: 12, padding: '10px 14px', cursor: 'pointer', background: isOpen ? '#f0f4ff' : 'white', transition: 'background 0.15s' }}
        >
          <span style={{ fontSize: 11, color: '#888', width: 14 }}>{isOpen ? '▾' : '▸'}</span>
          <span style={{ flex: 2, fontWeight: 600, fontSize: 13, color: '#1F3864' }}>{entry.team}</span>
          <span style={{ flex: 2, fontSize: 12, color: '#666' }}>{entry.iteration}</span>
          <span style={{ fontSize: 11, color: '#999' }}>{entry.iterationStart} → {entry.iterationEnd}</span>
          <span style={{ marginLeft: 'auto', fontSize: 12, color: '#444' }}>
            {entry.members.length} members · <strong>{Math.round(totalActual * 10) / 10}h</strong> utilized
          </span>
        </div>
      )}

      {/* Members table */}
      {isOpen && (
        <div style={{ borderTop: groupBy?.team !== false ? '1px solid #eef2f7' : 'none' }}>
          <table style={{ width: '100%', borderCollapse: 'collapse', fontSize: 12 }}>
            <thead>
              <tr style={{ background: '#f8fafc' }}>
                {['Member', 'Cap/Day', 'Days Off', 'Plan Time', 'Actual Cap.', 'Orig. Est.', 'Utilized', 'Util %', 'Work Items'].map(h => (
                  <th key={h} style={{ padding: '7px 12px', textAlign: h === 'Member' ? 'left' : 'center', fontWeight: 600, fontSize: 11, color: '#666', borderBottom: '1px solid #eef2f7' }}>{h}</th>
                ))}
              </tr>
            </thead>
            <tbody>
              {showMembers ? (
                <>
                  {entry.members.map((m, i) => (
                    <MemberRow key={i} member={m} iterationStart={entry.iterationStart} iterationEnd={entry.iterationEnd} />
                  ))}
                  {!entry.members.length && (
                    <tr><td colSpan={9} style={{ padding: 16, textAlign: 'center', color: '#aaa', fontSize: 12 }}>No capacity data</td></tr>
                  )}
                </>
              ) : (
                /* Summary row when member grouping is off */
                <tr style={{ background: '#f0f4ff', fontWeight: 600 }}>
                  <td style={{ padding: '8px 12px', color: '#1F3864' }}>{entry.members.length} members</td>
                  <td style={{ padding: '8px 12px', textAlign: 'center', color: '#666' }}>—</td>
                  <td style={{ padding: '8px 12px', textAlign: 'center', color: '#666' }}>—</td>
                  <td style={{ padding: '8px 12px', textAlign: 'center' }}>{Math.round(totalPlan * 10) / 10}h</td>
                  <td style={{ padding: '8px 12px', textAlign: 'center' }}>{Math.round(totalCap * 10) / 10}h</td>
                  <td style={{ padding: '8px 12px', textAlign: 'center', color: totalOrigEst > 0 ? '#1F3864' : '#aaa' }}>
                    {totalOrigEst > 0 ? `${Math.round(totalOrigEst * 10) / 10}h` : '—'}
                  </td>
                  <td style={{ padding: '8px 12px', textAlign: 'center' }}>{Math.round(totalActual * 10) / 10}h</td>
                  <td style={{ padding: '8px 12px', textAlign: 'center' }}>
                    <span style={{ background: utilBg(totalPct), color: utilColor(totalPct), padding: '3px 10px', borderRadius: 20, fontWeight: 700, fontSize: 12 }}>
                      {totalPct}%
                    </span>
                  </td>
                  <td style={{ padding: '8px 12px', textAlign: 'center', color: '#aaa' }}>—</td>
                </tr>
              )}
            </tbody>
          </table>
        </div>
      )}
    </div>
  )
}
