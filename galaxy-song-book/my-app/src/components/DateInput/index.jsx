import React, { useState, useEffect, useRef, useCallback } from 'react';
import { toDisplayDate, parseDisplayDate } from '../../helpers/transformDateFields';

/**
 * Masked date input. Displays using DISPLAY_DATE_FORMAT (e.g. YY-MMM-DD).
 * Stores YYYY-MM-DD internally for Formik/API compatibility.
 * Uses internal state so you can type freely; flushes on blur/enter.
 */
function DateInput({ name, value, onChange, disabled, readOnly, placeholder, className, id }) {
  const ref = useRef(null);
  const [text, setText] = useState(() => (value ? toDisplayDate(value) : ''));

  // Sync internal text when external value changes (form reset, edit load)
  useEffect(() => {
    setText(value ? toDisplayDate(value) : '');
  }, [value]);

  const flush = useCallback(() => {
    const parsed = parseDisplayDate(text);
    if (parsed) {
      const canonical = toDisplayDate(parsed);
      setText(canonical);
      if (value !== parsed) {
        onChange?.({ target: { name, value: parsed } });
      }
    } else if (text === '') {
      setText('');
      if (value !== '') onChange?.({ target: { name, value: '' } });
    } else {
      // Invalid input — revert to last valid
      setText(value ? toDisplayDate(value) : '');
    }
  }, [text, value, name, onChange]);

  const handleChange = useCallback((e) => {
    setText(e.target.value);
  }, []);

  const handleKeyDown = useCallback((e) => {
    if (e.key === 'Enter') { flush(); ref.current?.blur(); }
    if (e.key === 'Escape') {
      setText(value ? toDisplayDate(value) : '');
      ref.current?.blur();
    }
  }, [flush, value]);

  return (
    <input
      ref={ref}
      className={`form-control ${className || ''}`.trim()}
      id={id || name}
      type="text"
      name={name}
      value={text}
      onChange={handleChange}
      onBlur={flush}
      onKeyDown={handleKeyDown}
      placeholder={placeholder || 'YY-MMM-DD'}
      disabled={disabled}
      readOnly={readOnly}
      autoComplete="off"
      maxLength={9}
    />
  );
}

export default DateInput;
