import { computeMemberMetrics, utilColor, utilBg } from '../utils/metrics'
import { useState } from 'react'
import WorkItemsTable from './WorkItemsTable'

export default function MemberRow({ member, iterationStart, iterationEnd }) {
  const [showWI, setShowWI] = useState(false)
  const m = computeMemberMetrics({ ...member, iterationStart, iterationEnd })
  const pct = m.utilPct

  const origEst = (member.workItems || []).reduce((s, w) => s + (w.originalEstimate || 0), 0)

  return (
    <>
      <tr style={{ background: 'white', borderBottom: '1px solid #eef2f7' }}>
        <td style={td}>{m.member}</td>
        <td style={{ ...td, textAlign: 'center' }}>{m.capacityPerDay}h</td>
        <td style={{ ...td, textAlign: 'center' }}>{m.daysOff}</td>
        <td style={{ ...td, textAlign: 'center' }}>{m.planTime}h</td>
        <td style={{ ...td, textAlign: 'center' }}>{m.actualCapacity}h</td>
        <td style={{ ...td, textAlign: 'center', color: origEst > 0 ? '#1F3864' : '#aaa', fontWeight: origEst > 0 ? 600 : 400 }}>
          {origEst > 0 ? `${Math.round(origEst * 10) / 10}h` : '—'}
        </td>
        <td style={{ ...td, textAlign: 'center' }}>{m.actualHours}h</td>
        <td style={{ ...td, textAlign: 'center' }}>
          <span style={{ background: utilBg(pct), color: utilColor(pct), padding: '3px 10px', borderRadius: 20, fontWeight: 700, fontSize: 12 }}>
            {pct}%
          </span>
        </td>
        <td style={{ ...td, textAlign: 'center' }}>
          <button onClick={() => setShowWI(true)}
            style={{ fontSize: 11, padding: '3px 10px', borderRadius: 5, border: '1px solid #dde3ed', background: '#f5f7fa', cursor: 'pointer', color: '#1F3864', fontWeight: 600 }}>
            {member.workItems?.length || 0} items
          </button>
        </td>
      </tr>
      {showWI && <WorkItemsTable workItems={member.workItems || []} onClose={() => setShowWI(false)} />}
    </>
  )
}

const td = { padding: '8px 12px' }
