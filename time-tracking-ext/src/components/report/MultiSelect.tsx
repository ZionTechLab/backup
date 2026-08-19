import React, { useEffect, useRef, useState } from 'react';

export interface SelectOption {
  value: string;
  label: string;
}

interface Props {
  label: string;
  options: SelectOption[];
  selected: string[];
  onChange: (selected: string[]) => void;
  disabled?: boolean;
}

export function MultiSelect({ label, options, selected, onChange, disabled }: Props) {
  const [open, setOpen] = useState(false);
  const [query, setQuery] = useState('');
  const ref = useRef<HTMLDivElement>(null);
  const searchRef = useRef<HTMLInputElement>(null);

  useEffect(() => {
    function handleClick(e: MouseEvent) {
      if (ref.current && !ref.current.contains(e.target as Node)) {
        setOpen(false);
      }
    }
    document.addEventListener('mousedown', handleClick);
    return () => document.removeEventListener('mousedown', handleClick);
  }, []);

  useEffect(() => {
    if (open) {
      searchRef.current?.focus();
    } else {
      setQuery('');
    }
  }, [open]);

  const allSelected = selected.length === 0;
  const filtered = query
    ? options.filter(o => o.label.toLowerCase().includes(query.toLowerCase()))
    : options;

  function toggle(value: string) {
    onChange(selected.includes(value) ? selected.filter(v => v !== value) : [...selected, value]);
  }

  const buttonLabel = allSelected
    ? `All ${label}`
    : selected.length === 1
      ? (options.find(o => o.value === selected[0])?.label ?? selected[0])
      : `${selected.length} selected`;

  return (
    <div className="ms-root" ref={ref}>
      <button
        type="button"
        className={`ms-trigger ${open ? 'ms-trigger--open' : ''}`}
        onClick={() => !disabled && setOpen(o => !o)}
        disabled={disabled}
        aria-haspopup="listbox"
        aria-expanded={open}
      >
        <span className="ms-trigger-label">{buttonLabel}</span>
        <span className="ms-chevron">{open ? '▲' : '▼'}</span>
      </button>

      {open && (
        <div className="ms-dropdown" role="listbox" aria-multiselectable="true">
          <div className="ms-search">
            <input
              ref={searchRef}
              type="text"
              className="ms-search-input"
              placeholder={`Search ${label}...`}
              value={query}
              onChange={e => setQuery(e.target.value)}
              onKeyDown={e => e.stopPropagation()}
              aria-label={`Search ${label}`}
            />
          </div>
          <label className="ms-option ms-option--all">
            <input type="checkbox" checked={allSelected} onChange={() => onChange([])} />
            <span>All {label}</span>
          </label>
          <div className="ms-divider" />
          {filtered.length === 0 ? (
            <div className="ms-option ms-option--empty">No options found</div>
          ) : (
            filtered.map(opt => (
              <label key={opt.value} className="ms-option">
                <input
                  type="checkbox"
                  checked={selected.includes(opt.value)}
                  onChange={() => toggle(opt.value)}
                />
                <span>{opt.label}</span>
              </label>
            ))
          )}
        </div>
      )}
    </div>
  );
}
