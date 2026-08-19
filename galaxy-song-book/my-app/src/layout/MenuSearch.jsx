import { useEffect, useMemo, useRef, useState } from "react";
import { useNavigate } from "react-router-dom";
import "./menu-search.css";

// Searchable command palette over the menu. The topbar pill opens it; Cmd/Ctrl+K
// also opens it. Type to filter menu leaves by name, Enter or click to navigate.
export default function MenuSearch({ items = [] }) {
  const navigate = useNavigate();
  const [open, setOpen] = useState(false);
  const [query, setQuery] = useState("");
  const [active, setActive] = useState(0);
  const inputRef = useRef(null);

  // Leaf items only (those with a real route), with their parent group name.
  const leaves = useMemo(() => {
    const nameById = Object.fromEntries(items.map((m) => [m.id, m.displayName]));
    return items
      .filter((m) => m.route && m.route !== "#")
      .map((m) => ({
        route: m.route,
        name: m.displayName,
        icon: m.icon,
        group: m.parentId ? nameById[m.parentId] : "",
      }));
  }, [items]);

  const results = useMemo(() => {
    const q = query.trim().toLowerCase();
    const list = q
      ? leaves.filter((l) => l.name.toLowerCase().includes(q) || (l.group || "").toLowerCase().includes(q))
      : leaves;
    return list.slice(0, 25);
  }, [leaves, query]);

  useEffect(() => { setActive(0); }, [query, open]);

  // Cmd/Ctrl+K opens. Esc closes.
  useEffect(() => {
    const onKey = (e) => {
      if ((e.metaKey || e.ctrlKey) && e.key.toLowerCase() === "k") {
        e.preventDefault();
        setOpen(true);
      } else if (e.key === "Escape") {
        setOpen(false);
      }
    };
    window.addEventListener("keydown", onKey);
    return () => window.removeEventListener("keydown", onKey);
  }, []);

  useEffect(() => {
    if (open) {
      setQuery("");
      setTimeout(() => inputRef.current?.focus(), 0);
    }
  }, [open]);

  const go = (route) => {
    setOpen(false);
    if (route) navigate(route);
  };

  const onInputKey = (e) => {
    if (e.key === "ArrowDown") { e.preventDefault(); setActive((i) => Math.min(i + 1, results.length - 1)); }
    else if (e.key === "ArrowUp") { e.preventDefault(); setActive((i) => Math.max(i - 1, 0)); }
    else if (e.key === "Enter") { e.preventDefault(); const r = results[active]; if (r) go(r.route); }
  };

  return (
    <>
      <button className="ml-search-pill d-none d-xl-flex" type="button" aria-label="Search or jump to" onClick={() => setOpen(true)}>
        <i className="bi bi-search" aria-hidden="true" />
        <span>Search or jump to...</span>
        <kbd className="ml-search-kbd">⌘K</kbd>
      </button>
      <button className="ml-nav-icon-btn d-xl-none" type="button" aria-label="Search" onClick={() => setOpen(true)}>
        <i className="bi bi-search nav-icon-lg" />
      </button>

      {open && (
        <div className="ml-search-overlay" onMouseDown={() => setOpen(false)}>
          <div className="ml-search-panel" onMouseDown={(e) => e.stopPropagation()}>
            <div className="ml-search-input-row">
              <i className="bi bi-search" aria-hidden="true" />
              <input
                ref={inputRef}
                className="ml-search-input"
                placeholder="Search menu..."
                value={query}
                onChange={(e) => setQuery(e.target.value)}
                onKeyDown={onInputKey}
                aria-label="Search menu"
              />
              <kbd className="ml-search-kbd">esc</kbd>
            </div>
            <div className="ml-search-results">
              {results.length === 0 ? (
                <div className="ml-search-empty">No matches</div>
              ) : (
                results.map((r, i) => (
                  <button
                    key={r.route + i}
                    className={`ml-search-item ${i === active ? "active" : ""}`}
                    onMouseEnter={() => setActive(i)}
                    onClick={() => go(r.route)}
                  >
                    <i className={`${r.icon || "bi bi-dot"} ml-search-item-icon`} aria-hidden="true" />
                    <span className="ml-search-item-name">{r.name}</span>
                    {r.group && <span className="ml-search-item-group">{r.group}</span>}
                  </button>
                ))
              )}
            </div>
          </div>
        </div>
      )}
    </>
  );
}
