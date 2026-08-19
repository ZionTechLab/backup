import { useEditor } from '../store/useEditorStore';

export default function ParseDiagnosticsModal() {
  const { state, actions } = useEditor();
  const diag = state.loadDiagnostics;
  if (!diag) return null;

  const hasErrors   = diag.errors.length > 0;
  const hasWarnings = diag.warnings.length > 0;
  const fatal       = diag.fatal || (hasErrors && diag.sectionCount === 0);
  const title       = fatal ? 'File Could Not Be Loaded' : 'File Loaded with Warnings';
  const accent      = fatal ? '#e94560' : '#f59e0b';

  function dismiss() {
    actions.clearLoadDiagnostics();
    if (fatal) actions.clearFile?.();
  }

  return (
    <div
      className="fixed inset-0 z-50 flex items-center justify-center"
      style={{ background: 'rgba(0,0,0,0.7)' }}
      onClick={e => { if (e.target === e.currentTarget) dismiss(); }}
    >
      <div
        className="flex flex-col rounded-lg overflow-hidden"
        style={{
          width: 480,
          maxHeight: '80vh',
          background: '#16213e',
          border: `1px solid ${accent}`,
          boxShadow: `0 0 32px rgba(0,0,0,0.6)`,
        }}
      >
        {/* Header */}
        <div
          className="flex items-center gap-3 px-5 py-4 shrink-0"
          style={{ background: '#0f1c35', borderBottom: `1px solid ${accent}40` }}
        >
          <span style={{ fontSize: 20 }}>{fatal ? '✕' : '⚠'}</span>
          <div className="flex-1 min-w-0">
            <div className="font-semibold text-sm" style={{ color: accent }}>{title}</div>
            <div className="text-xs truncate" style={{ color: '#9ca3af' }}>{diag.filename}</div>
          </div>
          {!fatal && (
            <span className="text-xs px-2 py-0.5 rounded" style={{ background: '#10b98130', color: '#10b981' }}>
              {diag.sectionCount} section{diag.sectionCount !== 1 ? 's' : ''} loaded
            </span>
          )}
        </div>

        {/* Body */}
        <div className="flex-1 overflow-y-auto px-5 py-4 flex flex-col gap-4">

          {/* Errors */}
          {hasErrors && (
            <section>
              <div className="text-xs font-semibold uppercase tracking-wider mb-2" style={{ color: '#e94560' }}>
                Errors
              </div>
              <ul className="flex flex-col gap-2">
                {diag.errors.map((msg, i) => (
                  <li key={i} className="flex gap-2 text-xs rounded p-2"
                    style={{ background: '#e9456015', border: '1px solid #e9456030' }}>
                    <span style={{ color: '#e94560', flexShrink: 0 }}>✕</span>
                    <span style={{ color: '#fca5a5' }}>{msg}</span>
                  </li>
                ))}
              </ul>
            </section>
          )}

          {/* Warnings */}
          {hasWarnings && (
            <section>
              <div className="text-xs font-semibold uppercase tracking-wider mb-2" style={{ color: '#f59e0b' }}>
                Warnings
              </div>
              <ul className="flex flex-col gap-2">
                {diag.warnings.map((msg, i) => (
                  <li key={i} className="flex gap-2 text-xs rounded p-2"
                    style={{ background: '#f59e0b12', border: '1px solid #f59e0b25' }}>
                    <span style={{ color: '#f59e0b', flexShrink: 0 }}>⚠</span>
                    <span style={{ color: '#fde68a' }}>{msg}</span>
                  </li>
                ))}
              </ul>
            </section>
          )}

          {/* Suggestion for fatal errors */}
          {fatal && (
            <p className="text-xs" style={{ color: '#6b7280' }}>
              Try opening a different file, or check that this is a valid Yamaha style file
              (.sty, .prs, .sst, .bcs, .pst, .pcs, .fps).
            </p>
          )}
        </div>

        {/* Footer */}
        <div
          className="flex justify-end gap-2 px-5 py-3 shrink-0"
          style={{ borderTop: '1px solid #0f3460' }}
        >
          {!fatal && (
            <button
              onClick={dismiss}
              className="px-4 py-1.5 rounded text-xs font-semibold"
              style={{ background: '#e94560', color: '#fff' }}
            >
              Continue
            </button>
          )}
          {fatal && (
            <button
              onClick={dismiss}
              className="px-4 py-1.5 rounded text-xs font-semibold"
              style={{ background: '#0f3460', color: '#eaeaea' }}
            >
              Dismiss
            </button>
          )}
        </div>
      </div>
    </div>
  );
}
