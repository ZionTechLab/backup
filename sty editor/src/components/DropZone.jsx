import { useState, useCallback } from 'react';
import { useEditor } from '../store/useEditorStore';
import { parseStyleFile, STYLE_EXTENSIONS } from '../parser/StyleFileParser';

export default function DropZone({ children }) {
  const { actions } = useEditor();
  const [isDragging, setIsDragging] = useState(false);

  const handleDragOver = useCallback((e) => {
    e.preventDefault();
    setIsDragging(true);
  }, []);

  const handleDragLeave = useCallback((e) => {
    // Only clear if leaving the root element
    if (!e.currentTarget.contains(e.relatedTarget)) {
      setIsDragging(false);
    }
  }, []);

  const handleDrop = useCallback(async (e) => {
    e.preventDefault();
    setIsDragging(false);

    const file = e.dataTransfer.files?.[0];
    if (!file) return;

    const ext = '.' + file.name.split('.').pop().toLowerCase();
    if (!STYLE_EXTENSIONS.includes(ext)) {
      actions.setStatus(`Unsupported file type: ${ext}. Expected: ${STYLE_EXTENSIONS.join(', ')}`);
      actions.addError(`Unsupported file type: ${ext}`);
      return;
    }

    try {
      actions.setStatus(`Loading ${file.name}...`);
      const buffer = await file.arrayBuffer();
      const parsed = parseStyleFile(buffer, file.name);

      console.group(`[STY Editor] Drag-dropped: ${file.name}`);
      console.log('Format:', parsed.format);
      console.log('Summary:', parsed.summary);
      console.log('Sections:', Object.keys(parsed.sections));
      if (parsed.errors.length)   console.error('Parse errors:',   parsed.errors);
      if (parsed.warnings.length) console.warn ('Parse warnings:', parsed.warnings);
      console.groupEnd();

      actions.loadFile(parsed, file.name, null);
      actions.addRecentFile({ name: file.name, size: file.size, date: Date.now() });

      // Surface any parser errors or warnings as a modal
      if (parsed.errors.length > 0 || parsed.warnings.length > 0) {
        actions.setLoadDiagnostics({
          filename:     file.name,
          errors:       parsed.errors,
          warnings:     parsed.warnings,
          sectionCount: Object.keys(parsed.sections).length,
        });
      }
    } catch (err) {
      // Fatal — file could not be parsed at all
      actions.setStatus(`Failed to load: ${file.name}`);
      actions.setLoadDiagnostics({
        filename:     file.name,
        errors:       [err.message],
        warnings:     [],
        sectionCount: 0,
        fatal:        true,
      });
    }
  }, [actions]);

  return (
    <div
      className="relative w-full h-full"
      onDragOver={handleDragOver}
      onDragLeave={handleDragLeave}
      onDrop={handleDrop}
    >
      {children}
      {isDragging && (
        <div
          className="absolute inset-0 flex items-center justify-center z-50 pointer-events-none"
          style={{
            background: 'rgba(15,52,96,0.85)',
            border: '3px dashed #e94560',
          }}
        >
          <div className="text-center">
            <div className="text-4xl mb-2">♪</div>
            <div className="text-lg font-semibold" style={{ color: '#eaeaea' }}>
              Drop style file here
            </div>
            <div className="text-sm" style={{ color: '#9ca3af' }}>
              {STYLE_EXTENSIONS.join(' ')}
            </div>
          </div>
        </div>
      )}
    </div>
  );
}
