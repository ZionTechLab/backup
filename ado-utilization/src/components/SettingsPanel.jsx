import { useState } from 'react'

export default function SettingsPanel({ config, onSave }) {
  const [org, setOrg] = useState(config.org || 'HAYADVANTIS')
  const [pat, setPat] = useState(config.pat || '')

  return (
    <div style={{ maxWidth: 480, margin: '60px auto', background: 'white', borderRadius: 12, padding: 32, boxShadow: '0 4px 24px rgba(0,0,0,0.08)', border: '1px solid #e5e9f0' }}>
      <div style={{ display: 'flex', alignItems: 'center', gap: 12, marginBottom: 28 }}>
        <div style={{ width: 40, height: 40, background: '#1F3864', borderRadius: 10, display: 'flex', alignItems: 'center', justifyContent: 'center', fontSize: 20 }}>📊</div>
        <div>
          <div style={{ fontWeight: 700, fontSize: 18, color: '#1F3864' }}>ADO Utilization</div>
          <div style={{ fontSize: 12, color: '#888' }}>Azure DevOps Connection</div>
        </div>
      </div>

      <div style={{ marginBottom: 16 }}>
        <label style={{ display: 'block', fontSize: 12, fontWeight: 600, color: '#444', marginBottom: 6 }}>Organization Name</label>
        <input
          value={org}
          onChange={e => setOrg(e.target.value)}
          placeholder="e.g. HAYADVANTIS"
          style={inputStyle}
        />
        <div style={{ fontSize: 11, color: '#999', marginTop: 4 }}>From dev.azure.com/<strong>{org || 'your-org'}</strong></div>
      </div>

      <div style={{ marginBottom: 24 }}>
        <label style={{ display: 'block', fontSize: 12, fontWeight: 600, color: '#444', marginBottom: 6 }}>Personal Access Token (PAT)</label>
        <input
          type="password"
          value={pat}
          onChange={e => setPat(e.target.value)}
          placeholder="Paste your PAT here"
          style={inputStyle}
        />
        <div style={{ fontSize: 11, color: '#999', marginTop: 4 }}>
          Needs <strong>Read</strong> access on: Work Items, Project &amp; Team
        </div>
      </div>

      <button
        onClick={() => onSave({ org: org.trim(), pat: pat.trim() })}
        disabled={!org.trim() || !pat.trim()}
        style={{
          width: '100%', padding: '12px', background: org.trim() && pat.trim() ? '#1F3864' : '#ccc',
          color: 'white', border: 'none', borderRadius: 8, fontWeight: 600,
          fontSize: 14, cursor: org.trim() && pat.trim() ? 'pointer' : 'not-allowed'
        }}
      >
        Connect to Azure DevOps →
      </button>

      <div style={{ marginTop: 16, padding: 12, background: '#f8fafc', borderRadius: 8, fontSize: 11, color: '#666', lineHeight: 1.5 }}>
        🔒 Your PAT is stored only in memory for this session. It is never saved to disk.
      </div>
    </div>
  )
}

const inputStyle = {
  width: '100%', padding: '10px 12px', border: '1.5px solid #e5e9f0',
  borderRadius: 8, fontSize: 13, outline: 'none', boxSizing: 'border-box',
  fontFamily: 'inherit'
}
