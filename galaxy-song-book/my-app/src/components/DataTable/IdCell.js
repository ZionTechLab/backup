import { useState } from "react";
import "./IdCell.css";

// Clickable id text: copies the full value on click, with a brief tick.
function CopyableId({ text, value, className = "" }) {
  const [copied, setCopied] = useState(false);
  const onCopy = (e) => {
    e.stopPropagation();
    if (!value) return;
    navigator.clipboard?.writeText(value).then(() => {
      setCopied(true);
      setTimeout(() => setCopied(false), 1200);
    });
  };
  return (
    <button type="button" className="dt-id-copy" title={copied ? "Copied!" : "Click to copy"} onClick={onCopy}>
      <span className={`dt-id-text ${className}`}>{text}</span>
      {copied && <i className="bi bi-check2 dt-id-copied" />}
    </button>
  );
}

// Reusable id cell. Compressed by default (first `short` chars + show/hide
// toggle); pass `full` to render the whole value. Click the id to copy.
export function IdCell({ id, short = 8, full = false }) {
  const [shown, setShown] = useState(false);
  if (!id) return <span className="dt-id-text">-</span>;

  if (full) {
    return (
      <span className="d-inline-flex align-items-center gap-1">
        <CopyableId text={id} value={id} className="dt-id-full" />
      </span>
    );
  }

  return (
    <span className="d-inline-flex align-items-center gap-1">
      <CopyableId text={shown ? id : String(id).slice(0, short) + "…"} value={id} />
      <button
        type="button"
        className="dt-id-btn"
        title={shown ? "Hide" : "Show full ID"}
        onClick={(e) => { e.stopPropagation(); setShown((v) => !v); }}
      >
        <i className={`bi ${shown ? "bi-eye-slash" : "bi-eye"}`} />
      </button>
    </span>
  );
}
