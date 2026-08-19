export default function FilterBar({ data, filters, onChange }) {
  const projects = [...new Set(data.map(d => d.project))].sort()
  const teams = [...new Set(
    data.filter(d => !filters.projects?.length || filters.projects.includes(d.project))
        .map(d => d.team)
  )].sort()
  const members = [...new Set(
    data.filter(d =>
      (!filters.projects?.length || filters.projects.includes(d.project)) &&
      (!filters.teams?.length || filters.teams.includes(d.team))
    ).flatMap(d => d.members.map(m => m.member))
  )].sort()
  const iterations = [...new Set(data.map(d => d.iteration))].sort()

  function toggle(key, val) {
    const cur = filters[key] || []
    const next = cur.includes(val) ? cur.filter(x => x !== val) : [...cur, val]
    onChange({ ...filters, [key]: next })
  }

  return (
    <div style={{ background: 'white', borderRadius: 10, border: '1px solid #e5e9f0', padding: '14px 16px', marginBottom: 16 }}>
      <div style={{ display: 'flex', gap: 24, flexWrap: 'wrap', alignItems: 'flex-start' }}>

        <FilterGroup label="Project" items={projects} selected={filters.projects || []}
          onToggle={v => toggle('projects', v)} />

        <FilterGroup label="Team" items={teams} selected={filters.teams || []}
          onToggle={v => toggle('teams', v)} />

        <FilterGroup label="Member" items={members} selected={filters.members || []}
          onToggle={v => toggle('members', v)} />

        <FilterGroup label="Iteration" items={iterations} selected={filters.iterations || []}
          onToggle={v => toggle('iterations', v)} />

        <div>
          <div style={labelStyle}>Utilization %</div>
          <div style={{ display: 'flex', gap: 6, alignItems: 'center' }}>
            <input type="number" placeholder="Min" value={filters.utilMin ?? ''} min={0} max={200}
              onChange={e => onChange({ ...filters, utilMin: e.target.value === '' ? undefined : Number(e.target.value) })}
              style={{ width: 56, padding: '4px 6px', border: '1px solid #dde3ed', borderRadius: 6, fontSize: 12 }} />
            <span style={{ fontSize: 12, color: '#888' }}>–</span>
            <input type="number" placeholder="Max" value={filters.utilMax ?? ''} min={0} max={300}
              onChange={e => onChange({ ...filters, utilMax: e.target.value === '' ? undefined : Number(e.target.value) })}
              style={{ width: 56, padding: '4px 6px', border: '1px solid #dde3ed', borderRadius: 6, fontSize: 12 }} />
          </div>
          <div style={{ display: 'flex', gap: 4, marginTop: 6, flexWrap: 'wrap' }}>
            {[['Over 100%', 100, 999], ['80-100%', 80, 100], ['Under 80%', 0, 80]].map(([lbl, mn, mx]) => (
              <button key={lbl} onClick={() => onChange({ ...filters, utilMin: mn, utilMax: mx })}
                style={{ fontSize: 10, padding: '2px 7px', borderRadius: 4, border: '1px solid #dde3ed', background: '#f5f7fa', cursor: 'pointer' }}>
                {lbl}
              </button>
            ))}
            <button onClick={() => onChange({ ...filters, utilMin: undefined, utilMax: undefined })}
              style={{ fontSize: 10, padding: '2px 7px', borderRadius: 4, border: '1px solid #dde3ed', background: '#f5f7fa', cursor: 'pointer', color: '#c0392b' }}>
              Clear
            </button>
          </div>
        </div>

        <div style={{ marginLeft: 'auto', alignSelf: 'flex-end' }}>
          <button onClick={() => onChange({})}
            style={{ fontSize: 12, padding: '6px 14px', borderRadius: 6, border: '1px solid #dde3ed', background: 'white', cursor: 'pointer', color: '#666' }}>
            Clear All Filters
          </button>
        </div>
      </div>
    </div>
  )
}

function FilterGroup({ label, items, selected, onToggle }) {
  if (!items.length) return null
  return (
    <div style={{ minWidth: 120, maxWidth: 200 }}>
      <div style={labelStyle}>{label}</div>
      <div style={{ display: 'flex', flexDirection: 'column', gap: 3, maxHeight: 120, overflowY: 'auto' }}>
        {items.map(item => (
          <label key={item} style={{ display: 'flex', alignItems: 'center', gap: 6, fontSize: 12, cursor: 'pointer', color: selected.includes(item) ? '#1F3864' : '#444' }}>
            <input type="checkbox" checked={selected.includes(item)} onChange={() => onToggle(item)}
              style={{ accentColor: '#1F3864' }} />
            <span style={{ whiteSpace: 'nowrap', overflow: 'hidden', textOverflow: 'ellipsis', maxWidth: 160 }}>{item}</span>
          </label>
        ))}
      </div>
    </div>
  )
}

const labelStyle = { fontSize: 11, fontWeight: 700, color: '#888', textTransform: 'uppercase', letterSpacing: '0.5px', marginBottom: 6 }
