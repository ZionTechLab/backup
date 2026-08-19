import { useState } from 'react'
import SettingsPanel from './components/SettingsPanel'
import FilterBar from './components/FilterBar'
import ConsolidatedReport from './components/ConsolidatedReport'
import ProjectReport from './components/ProjectReport'
import { fetchAllData } from './api/ado'
import { exportToExcel } from './utils/excelExport'

const today = new Date().toISOString().slice(0, 10)
const firstOfMonth = today.slice(0, 8) + '01'

export default function App() {
  const [config, setConfig] = useState({ org: 'HAYADVANTIS', pat: '' })
  const [connected, setConnected] = useState(false)
  const [dateRange, setDateRange] = useState({ start: '2026-04-01', end: '2026-04-30' })
  const [data, setData] = useState([])
  const [filters, setFilters] = useState({})
  const [loading, setLoading] = useState(false)
  const [progress, setProgress] = useState({ msg: '', pct: 0 })
  const [error, setError] = useState('')
  const [view, setView] = useState('consolidated') // 'consolidated' | 'projects'
  const [showSettings, setShowSettings] = useState(false)
  const [groupBy, setGroupBy] = useState({ project: true, team: true, member: true })

  function handleConnect(cfg) {
    setConfig(cfg)
    setConnected(true)
    setShowSettings(false)
  }

  async function fetchData() {
    setLoading(true)
    setError('')
    setData([])
    setFilters({})
    try {
      const result = await fetchAllData(
        config.org, config.pat,
        dateRange.start, dateRange.end,
        (msg, pct) => setProgress({ msg, pct })
      )
      setData(result)
    } catch (e) {
      setError(e.message || 'Failed to fetch data')
    } finally {
      setLoading(false)
    }
  }

  function handleExport() {
    exportToExcel(data, filters, dateRange)
  }

  const projects = [...new Set(data.map(d => d.project))].sort()
  const filteredProjects = filters.projects?.length ? projects.filter(p => filters.projects.includes(p)) : projects

  if (!connected || showSettings) {
    return (
      <div style={{ minHeight: '100vh', background: '#f5f7fa' }}>
        <SettingsPanel config={config} onSave={handleConnect} />
      </div>
    )
  }

  return (
    <div style={{ minHeight: '100vh', background: '#f5f7fa', fontFamily: '-apple-system, BlinkMacSystemFont, "Segoe UI", sans-serif' }}>
      {/* Top bar */}
      <div style={{ background: '#1F3864', color: 'white', padding: '0 24px', display: 'flex', alignItems: 'center', height: 52, gap: 16, boxShadow: '0 2px 8px rgba(0,0,0,0.15)' }}>
        <span style={{ fontWeight: 700, fontSize: 16 }}>📊 ADO Utilization</span>
        <span style={{ opacity: 0.5, fontSize: 18 }}>|</span>
        <span style={{ fontSize: 12, opacity: 0.8 }}>{config.org}</span>

        {/* Date Range */}
        <div style={{ display: 'flex', alignItems: 'center', gap: 8, marginLeft: 16, background: 'rgba(255,255,255,0.1)', borderRadius: 8, padding: '4px 12px' }}>
          <span style={{ fontSize: 11, opacity: 0.7 }}>From</span>
          <input type="date" value={dateRange.start} onChange={e => setDateRange(d => ({ ...d, start: e.target.value }))}
            style={{ background: 'transparent', border: 'none', color: 'white', fontSize: 13, outline: 'none', colorScheme: 'dark' }} />
          <span style={{ fontSize: 11, opacity: 0.7 }}>To</span>
          <input type="date" value={dateRange.end} onChange={e => setDateRange(d => ({ ...d, end: e.target.value }))}
            style={{ background: 'transparent', border: 'none', color: 'white', fontSize: 13, outline: 'none', colorScheme: 'dark' }} />
        </div>

        <button onClick={fetchData} disabled={loading}
          style={{ background: loading ? '#3a5a94' : '#2ecc71', border: 'none', color: 'white', padding: '7px 18px', borderRadius: 7, fontWeight: 600, fontSize: 13, cursor: loading ? 'not-allowed' : 'pointer' }}>
          {loading ? '⏳ Loading...' : '🔄 Fetch Data'}
        </button>

        {/* View Toggle */}
        {data.length > 0 && (
          <div style={{ display: 'flex', background: 'rgba(255,255,255,0.15)', borderRadius: 7, overflow: 'hidden', marginLeft: 8 }}>
            {[['consolidated', '📊 Consolidated'], ['projects', '📁 By Project']].map(([v, label]) => (
              <button key={v} onClick={() => setView(v)}
                style={{ padding: '6px 14px', border: 'none', background: view === v ? 'rgba(255,255,255,0.25)' : 'transparent', color: 'white', fontSize: 12, fontWeight: view === v ? 700 : 400, cursor: 'pointer' }}>
                {label}
              </button>
            ))}
          </div>
        )}

        <div style={{ marginLeft: 'auto', display: 'flex', gap: 8 }}>
          {data.length > 0 && (
            <button onClick={handleExport}
              style={{ background: 'rgba(255,255,255,0.15)', border: '1px solid rgba(255,255,255,0.3)', color: 'white', padding: '6px 14px', borderRadius: 7, fontSize: 12, fontWeight: 600, cursor: 'pointer' }}>
              ⬇ Export Excel
            </button>
          )}
          <button onClick={() => setShowSettings(true)}
            style={{ background: 'rgba(255,255,255,0.1)', border: '1px solid rgba(255,255,255,0.2)', color: 'white', padding: '6px 12px', borderRadius: 7, fontSize: 12, cursor: 'pointer' }}>
            ⚙ Settings
          </button>
        </div>
      </div>

      {/* Main content */}
      <div style={{ padding: '20px 24px', maxWidth: 1400, margin: '0 auto' }}>

        {/* Loading bar */}
        {loading && (
          <div style={{ background: 'white', borderRadius: 10, padding: '20px 24px', marginBottom: 16, border: '1px solid #e5e9f0' }}>
            <div style={{ display: 'flex', justifyContent: 'space-between', marginBottom: 8, fontSize: 13 }}>
              <span style={{ color: '#444' }}>{progress.msg}</span>
              <span style={{ color: '#1F3864', fontWeight: 700 }}>{progress.pct}%</span>
            </div>
            <div style={{ background: '#eef2f7', borderRadius: 6, height: 10, overflow: 'hidden' }}>
              <div style={{ height: '100%', width: `${progress.pct}%`, background: '#1F3864', borderRadius: 6, transition: 'width 0.3s' }} />
            </div>
          </div>
        )}

        {/* Error */}
        {error && (
          <div style={{ background: '#fce8e6', border: '1px solid #f5c6c2', borderRadius: 10, padding: '14px 18px', marginBottom: 16, color: '#b91c1c', fontSize: 13 }}>
            ❌ {error}
          </div>
        )}

        {/* Empty state */}
        {!loading && !error && data.length === 0 && (
          <div style={{ background: 'white', borderRadius: 10, border: '1px solid #e5e9f0', padding: '48px 24px', textAlign: 'center' }}>
            <div style={{ fontSize: 40, marginBottom: 12 }}>📅</div>
            <div style={{ fontSize: 16, fontWeight: 600, color: '#1F3864', marginBottom: 8 }}>Select a date range and fetch data</div>
            <div style={{ fontSize: 13, color: '#aaa' }}>Connected to <strong>{config.org}</strong> · All projects and teams will be scanned</div>
          </div>
        )}

        {/* Reports */}
        {data.length > 0 && (
          <>
            <FilterBar data={data} filters={filters} onChange={setFilters} />

            {/* Group By toolbar */}
            <div style={{ display: 'flex', alignItems: 'center', gap: 8, marginBottom: 12 }}>
              <span style={{ fontSize: 11, fontWeight: 700, color: '#888', textTransform: 'uppercase', letterSpacing: '0.5px', marginRight: 4 }}>Group by:</span>
              {[['project', 'Project'], ['team', 'Team'], ['member', 'Member']].map(([key, label]) => (
                <button key={key} onClick={() => setGroupBy(g => ({ ...g, [key]: !g[key] }))}
                  style={{
                    padding: '5px 14px', borderRadius: 6, fontSize: 12, fontWeight: 600, cursor: 'pointer',
                    border: `1.5px solid ${groupBy[key] ? '#1F3864' : '#dde3ed'}`,
                    background: groupBy[key] ? '#1F3864' : 'white',
                    color: groupBy[key] ? 'white' : '#888', transition: 'all 0.15s'
                  }}>
                  {groupBy[key] ? '✓ ' : ''}{label}
                </button>
              ))}
            </div>

            {view === 'consolidated' && (
              <ConsolidatedReport data={data} filters={filters} groupBy={groupBy} />
            )}

            {view === 'projects' && (
              <div>
                {filteredProjects.map(proj => (
                  <ProjectReport
                    key={proj}
                    projectName={proj}
                    entries={data.filter(d => d.project === proj)}
                    filters={filters}
                    groupBy={groupBy}
                  />
                ))}
              </div>
            )}
          </>
        )}
      </div>
    </div>
  )
}
