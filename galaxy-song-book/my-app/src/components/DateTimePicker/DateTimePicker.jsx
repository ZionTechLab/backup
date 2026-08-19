import React, { useState, useEffect, useRef, useCallback } from 'react';
import { createPortal } from 'react-dom';
import { formatDate, formatDateTime } from '../../helpers/transformDateFields';
import './DateTimePicker.css';

const DAYS_OF_WEEK = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
const MONTHS = [
  'January', 'February', 'March', 'April', 'May', 'June',
  'July', 'August', 'September', 'October', 'November', 'December'
];

function pad(n) {
  return n < 10 ? '0' + n : n;
}

function parseDate(val) {
  if (!val) return null;
  const d = new Date(val);
  return isNaN(d.getTime()) ? null : d;
}

export default function DateTimePicker({
  value,
  onChange,
  name,
  disabled,
  readOnly,
  placeholder,
  type = 'date', // 'date' or 'datetime'
  className,
  ...rest
}) {
  const isTime = type === 'datetime' || type === 'datetime-local';
  
  const [isOpen, setIsOpen] = useState(false);
  const [selectedDate, setSelectedDate] = useState(() => parseDate(value));
  const [viewDate, setViewDate] = useState(() => parseDate(value) || new Date());
  
  const [hh, setHh] = useState(() => {
    const d = parseDate(value);
    return d ? pad(d.getHours()) : '12';
  });
  const [mm, setMm] = useState(() => {
    const d = parseDate(value);
    return d ? pad(d.getMinutes()) : '00';
  });

  const [menuRect, setMenuRect] = useState(null);
  
  const containerRef = useRef(null);
  const triggerRef = useRef(null);
  const menuRef = useRef(null);

  // Sync external value changes
  useEffect(() => {
    const d = parseDate(value);
    if (d) {
      setSelectedDate(d);
      setViewDate(new Date(d.getFullYear(), d.getMonth(), 1));
      setHh(pad(d.getHours()));
      setMm(pad(d.getMinutes()));
    } else {
      setSelectedDate(null);
    }
  }, [value]);

  const updateMenuRect = useCallback(() => {
    if (!triggerRef.current) return;
    const r = triggerRef.current.getBoundingClientRect();
    const spaceBelow = window.innerHeight - r.bottom;
    const spaceAbove = r.top;
    
    // Approximate height of the picker
    const pickerHeight = isTime ? 380 : 320;
    const openUp = spaceBelow < pickerHeight && spaceAbove > spaceBelow;
    
    setMenuRect({
      left: r.left,
      width: 300, // fixed width for picker
      top: openUp ? null : r.bottom + 4,
      bottom: openUp ? window.innerHeight - r.top + 4 : null,
    });
  }, [isTime]);

  useEffect(() => {
    if (!isOpen) return;
    updateMenuRect();
    const handleScrollOrResize = () => updateMenuRect();
    window.addEventListener('scroll', handleScrollOrResize, true);
    window.addEventListener('resize', handleScrollOrResize);
    return () => {
      window.removeEventListener('scroll', handleScrollOrResize, true);
      window.removeEventListener('resize', handleScrollOrResize);
    };
  }, [isOpen, updateMenuRect]);

  useEffect(() => {
    if (!isOpen) return;
    const handleDocClick = (e) => {
      const inTrigger = triggerRef.current && triggerRef.current.contains(e.target);
      const inMenu = menuRef.current && menuRef.current.contains(e.target);
      if (!inTrigger && !inMenu) {
        setIsOpen(false);
      }
    };
    document.addEventListener('mousedown', handleDocClick);
    return () => document.removeEventListener('mousedown', handleDocClick);
  }, [isOpen]);

  const notifyChange = (dateObj) => {
    if (!onChange || !dateObj) return;
    let formatted = '';
    const y = dateObj.getFullYear();
    const m = pad(dateObj.getMonth() + 1);
    const d = pad(dateObj.getDate());
    if (isTime) {
      const h = pad(dateObj.getHours());
      const min = pad(dateObj.getMinutes());
      formatted = `${y}-${m}-${d}T${h}:${min}`;
    } else {
      formatted = `${y}-${m}-${d}`;
    }
    onChange({ target: { name, value: formatted } });
  };

  const handleDayClick = (year, month, day) => {
    const newDate = new Date(year, month, day);
    if (isTime) {
      newDate.setHours(parseInt(hh, 10) || 0);
      newDate.setMinutes(parseInt(mm, 10) || 0);
    }
    setSelectedDate(newDate);
    notifyChange(newDate);
    if (!isTime) setIsOpen(false); // auto-close only if date-only
  };

  const handleTimeChange = (type, val) => {
    let num = parseInt(val, 10) || 0;
    if (type === 'h') {
      if (num < 0) num = 23;
      if (num > 23) num = 0;
      setHh(pad(num));
    } else {
      if (num < 0) num = 59;
      if (num > 59) num = 0;
      setMm(pad(num));
    }
    
    if (selectedDate) {
      const newDate = new Date(selectedDate);
      if (type === 'h') newDate.setHours(num);
      else newDate.setMinutes(num);
      setSelectedDate(newDate);
      notifyChange(newDate);
    }
  };

  const prevMonth = () => {
    setViewDate(new Date(viewDate.getFullYear(), viewDate.getMonth() - 1, 1));
  };
  const nextMonth = () => {
    setViewDate(new Date(viewDate.getFullYear(), viewDate.getMonth() + 1, 1));
  };

  const renderGrid = () => {
    const year = viewDate.getFullYear();
    const month = viewDate.getMonth();
    const firstDay = new Date(year, month, 1).getDay();
    const daysInMonth = new Date(year, month + 1, 0).getDate();
    const daysInPrevMonth = new Date(year, month, 0).getDate();
    
    const days = [];
    // Previous month padding
    for (let i = firstDay - 1; i >= 0; i--) {
      days.push({ year: month === 0 ? year - 1 : year, month: month === 0 ? 11 : month - 1, day: daysInPrevMonth - i, outside: true });
    }
    // Current month
    for (let i = 1; i <= daysInMonth; i++) {
      days.push({ year, month, day: i, outside: false });
    }
    // Next month padding
    const remaining = 42 - days.length; // 6 rows * 7 cols
    for (let i = 1; i <= remaining; i++) {
      days.push({ year: month === 11 ? year + 1 : year, month: month === 11 ? 0 : month + 1, day: i, outside: true });
    }

    const today = new Date();
    
    return days.map((d, i) => {
      const isSelected = selectedDate && d.year === selectedDate.getFullYear() && d.month === selectedDate.getMonth() && d.day === selectedDate.getDate();
      const isToday = d.year === today.getFullYear() && d.month === today.getMonth() && d.day === today.getDate();
      
      let cls = 'ml-datetime-day';
      if (d.outside) cls += ' outside';
      if (isSelected) cls += ' selected';
      if (isToday) cls += ' today';
      
      return (
        <div key={i} className={cls} onClick={() => handleDayClick(d.year, d.month, d.day)}>
          {d.day}
        </div>
      );
    });
  };

  const displayValue = () => {
    if (!selectedDate) return '';
    if (isTime) return formatDateTime(selectedDate);
    return formatDate(selectedDate);
  };

  return (
    <div className="position-relative w-100" ref={containerRef}>
      <input
        ref={triggerRef}
        type="text"
        className={`form-control ${className || ''}`}
        name={name}
        value={displayValue()}
        readOnly
        disabled={disabled}
        placeholder={placeholder || (isTime ? 'YYYY-MM-DD HH:MM' : 'YYYY-MM-DD')}
        onClick={() => {
          if (!disabled && !readOnly) setIsOpen(!isOpen);
        }}
        style={{ cursor: (disabled || readOnly) ? 'default' : 'pointer' }}
        {...rest}
      />
      {isOpen && menuRect && createPortal(
        <div 
          ref={menuRef} 
          className="ml-datetime-picker-portal"
          style={{
            left: menuRect.left,
            top: menuRect.top ?? 'auto',
            bottom: menuRect.bottom ?? 'auto',
          }}
        >
          <div className="ml-datetime-header">
            <button type="button" className="ml-datetime-nav-btn" onClick={prevMonth} aria-label="Previous month">
              <i className="bi bi-chevron-left" />
            </button>
            <div className="ml-datetime-title">
              {MONTHS[viewDate.getMonth()]} {viewDate.getFullYear()}
            </div>
            <button type="button" className="ml-datetime-nav-btn" onClick={nextMonth} aria-label="Next month">
              <i className="bi bi-chevron-right" />
            </button>
          </div>
          <div className="ml-datetime-body">
            <div className="ml-datetime-weekdays">
              {DAYS_OF_WEEK.map(d => <div key={d}>{d}</div>)}
            </div>
            <div className="ml-datetime-days">
              {renderGrid()}
            </div>
          </div>
          {isTime && (
            <div className="ml-datetime-time">
              <input 
                type="number" 
                value={hh} 
                onChange={e => handleTimeChange('h', e.target.value)} 
                onBlur={() => setHh(pad(parseInt(hh, 10) || 0))}
              />
              <span className="ml-datetime-time-separator">:</span>
              <input 
                type="number" 
                value={mm} 
                onChange={e => handleTimeChange('m', e.target.value)}
                onBlur={() => setMm(pad(parseInt(mm, 10) || 0))}
              />
            </div>
          )}
        </div>,
        document.body
      )}
    </div>
  );
}
