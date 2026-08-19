import { useRef, useState } from 'react';
import { uploadFile, fileUrl } from '../../services/fileService';
import MessageBoxService from '../../services/MessageBoxService';
import './DocumentUploader.css';

// Icon per file extension.
function iconFor(name = '') {
  const ext = String(name).split('.').pop().toLowerCase();
  if (['pdf'].includes(ext)) return 'bi-file-earmark-pdf';
  if (['png', 'jpg', 'jpeg', 'gif', 'webp', 'bmp', 'svg'].includes(ext)) return 'bi-file-earmark-image';
  if (['doc', 'docx'].includes(ext)) return 'bi-file-earmark-word';
  if (['xls', 'xlsx', 'csv'].includes(ext)) return 'bi-file-earmark-spreadsheet';
  if (['zip', 'rar', '7z'].includes(ext)) return 'bi-file-earmark-zip';
  return 'bi-file-earmark';
}

// Controlled attachment uploader. value is [{ filePath, comment }]. Owns the
// upload to the shared files endpoint. Enforces the max, supports drag-drop and
// a read-only mode. Backend contract is just the value array.
export default function DocumentUploader({
  value = [],
  onChange,
  readOnly = false,
  max = 5,
  label = 'Documents',
  accept,
}) {
  const inputRef = useRef(null);
  const [dragOver, setDragOver] = useState(false);
  const [uploading, setUploading] = useState(0);

  const docs = Array.isArray(value) ? value : [];
  const canAdd = !readOnly && docs.length < max;

  const addFiles = async (fileList) => {
    const files = Array.from(fileList || []);
    if (!files.length) return;
    const room = max - docs.length;
    if (files.length > room) {
      MessageBoxService.show({ message: `Only ${max} files allowed. Extra files were skipped.`, type: 'warning' });
    }
    const toAdd = files.slice(0, room);
    setUploading((n) => n + toAdd.length);
    const added = [];
    for (const f of toAdd) {
      const { success, data } = await uploadFile(f);
      if (success && data?.filename) added.push({ filePath: data.filename, comment: '' });
      setUploading((n) => n - 1);
    }
    if (added.length) onChange([...docs, ...added]);
  };

  const handleDrop = (e) => {
    e.preventDefault();
    setDragOver(false);
    if (!canAdd) return;
    addFiles(e.dataTransfer.files);
  };

  const setComment = (i, comment) => {
    const next = [...docs];
    next[i] = { ...next[i], comment };
    onChange(next);
  };

  const remove = (i) => onChange(docs.filter((_, x) => x !== i));

  return (
    <div className="ml-doc-uploader">
      <div className="ml-doc-head">
        <h6 className="ml-doc-title">{label}</h6>
        <span className="ml-doc-count">{docs.length} / {max}</span>
      </div>

      {canAdd && (
        <div
          className={`ml-doc-dropzone${dragOver ? ' is-drag' : ''}`}
          role="button"
          tabIndex={0}
          onClick={() => inputRef.current?.click()}
          onKeyDown={(e) => { if (e.key === 'Enter' || e.key === ' ') inputRef.current?.click(); }}
          onDragOver={(e) => { e.preventDefault(); setDragOver(true); }}
          onDragLeave={() => setDragOver(false)}
          onDrop={handleDrop}
        >
          <i className="bi bi-cloud-arrow-up ml-doc-dz-icon" aria-hidden="true" />
          <div className="ml-doc-dz-text">Drag files here or <span className="ml-doc-dz-link">browse</span></div>
          <div className="ml-doc-dz-hint">PDF, image, doc &middot; max {max}</div>
          <input
            ref={inputRef}
            type="file"
            multiple
            accept={accept}
            className="d-none"
            onChange={(e) => { addFiles(e.target.files); e.target.value = ''; }}
          />
        </div>
      )}

      {uploading > 0 && (
        <div className="ml-doc-uploading">
          <span className="spinner-border spinner-border-sm" aria-hidden="true" /> Uploading {uploading}...
        </div>
      )}

      {docs.length === 0 && !canAdd && (
        <p className="ml-doc-empty">No documents attached.</p>
      )}

      {docs.length > 0 && (
        <div className="ml-doc-list">
          {docs.map((doc, i) => (
            <div key={i} className="ml-doc-card">
              <i className={`bi ${iconFor(doc.filePath)} ml-doc-card-icon`} aria-hidden="true" />
              <div className="ml-doc-card-body">
                {doc.filePath ? (
                  <a href={fileUrl(doc.filePath)} target="_blank" rel="noreferrer" className="ml-doc-card-name" title={doc.filePath}>
                    {doc.filePath}
                  </a>
                ) : (
                  <span className="ml-doc-card-name ml-doc-muted">Uploading...</span>
                )}
                <input
                  type="text"
                  className="ml-doc-card-comment"
                  placeholder={readOnly ? '' : 'Add a comment'}
                  value={doc.comment || ''}
                  disabled={readOnly}
                  onChange={(e) => setComment(i, e.target.value)}
                />
              </div>
              {!readOnly && (
                <button type="button" className="ml-doc-card-remove" aria-label="Remove" onClick={() => remove(i)}>
                  <i className="bi bi-x-lg" aria-hidden="true" />
                </button>
              )}
            </div>
          ))}
        </div>
      )}
    </div>
  );
}
