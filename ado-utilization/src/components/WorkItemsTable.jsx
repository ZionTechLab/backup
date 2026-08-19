export default function WorkItemsTable({ workItems, onClose }) {
  const total = workItems.length
  const totalCompleted = workItems.reduce((s, w) => s + w.completedWork, 0)

  const typeColor = { Task: '#1F3864', Bug: '#c0392b', 'User Story': '#1a7340', Feature: '#6b21a8' }
  const stateColor = { Done: '#1a7340', Closed: '#1a7340', Active: '#b45309', 'In Progress': '#b45309', New: '#6b7280', Resolved: '#1F3864' }

  return (
    <div style={{ position: 'fixed', inset: 0, background: 'rgba(0,0,0,0.45)', zIndex: 1000, display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
      <div style={{ background: 'white', borderRadius: 12, width: '90vw', maxWidth: 1100, maxHeight: '85vh', display: 'flex', flexDirection: 'column', boxShadow: '0 20px 60px rgba(0,0,0,0.2)' }}>
        {/* Header */}
        <div style={{ padding: '16px 20px', borderBottom: '1px solid #e5e9f0', display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
          <div>
            <div style={{ fontWeight: 700, fontSize: 16, color: '#1F3864' }}>Work Items</div>
            <div style={{ fontSize: 12, color: '#888', marginTop: 2 }}>
              {total} items · {Math.round(totalCompleted * 10) / 10}h completed
            </div>
          </div>
          <button onClick={onClose} style={{ background: 'none', border: 'none', fontSize: 20, cursor: 'pointer', color: '#888', padding: '0 4px' }}>✕</button>
        </div>

        {/* Table */}
        <div style={{ overflowY: 'auto', flex: 1 }}>
          <table style={{ width: '100%', borderCollapse: 'collapse', fontSize: 12 }}>
            <thead style={{ position: 'sticky', top: 0 }}>
              <tr>
                {['ID', 'Title', 'Type', 'State', 'Assigned To', 'Orig. Est (h)', 'Remaining (h)', 'Completed (h)', 'Story Pts'].map(col => (
                  <th key={col} style={{ background: '#1F3864', color: 'white', padding: '8px 10px', textAlign: 'left', fontWeight: 600, whiteSpace: 'nowrap' }}>{col}</th>
                ))}
              </tr>
            </thead>
            <tbody>
              {workItems.map((wi, i) => (
                <tr key={wi.id} style={{ background: i % 2 === 0 ? 'white' : '#f8fafc' }}>
                  <td style={td}><span style={{ color: '#1F3864', fontWeight: 600 }}>#{wi.id}</span></td>
                  <td style={{ ...td, maxWidth: 280 }}><span title={wi.title} style={{ display: 'block', overflow: 'hidden', textOverflow: 'ellipsis', whiteSpace: 'nowrap' }}>{wi.title}</span></td>
                  <td style={td}>
                    <span style={{ background: typeColor[wi.type] || '#666', color: 'white', padding: '2px 8px', borderRadius: 4, fontSize: 10, fontWeight: 600 }}>{wi.type}</span>
                  </td>
                  <td style={td}>
                    <span style={{ color: stateColor[wi.state] || '#444', fontWeight: 600 }}>{wi.state}</span>
                  </td>
                  <td style={td}>{wi.assignedTo}</td>
                  <td style={{ ...td, textAlign: 'center' }}>{wi.originalEstimate || '—'}</td>
                  <td style={{ ...td, textAlign: 'center' }}>{wi.remainingWork || '—'}</td>
                  <td style={{ ...td, textAlign: 'center', fontWeight: 600, color: wi.completedWork > 0 ? '#1a7340' : '#999' }}>{wi.completedWork || '—'}</td>
                  <td style={{ ...td, textAlign: 'center' }}>{wi.storyPoints || '—'}</td>
                </tr>
              ))}
              {!workItems.length && (
                <tr><td colSpan={9} style={{ padding: 24, textAlign: 'center', color: '#aaa' }}>No work items found</td></tr>
              )}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  )
}

const td = { padding: '7px 10px', borderBottom: '1px solid #eef2f7' }
