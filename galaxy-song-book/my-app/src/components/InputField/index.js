import React from 'react';
import { createPortal } from 'react-dom';
import config from '../../config/config';
import ImageMultiInputField from '../ImageInputField/ImageMultiInputField.jsx';
import DateTimePicker from '../DateTimePicker/DateTimePicker';
import { formatAmountInput } from '../../helpers/formatAmount';
import { formatPhoneAsYouType } from '../../helpers/phoneValidation';
import './InputField.css';

function InputField({
  name,
  type = 'text',
  className,
  placeholder,
  formik,
  value,
  onChange,
  error,
  touched,
  dataBinding,children,disabled,visible=true,readOnly=false,
  labelOnTop=true,
  required=false,
  clearable=false,
  validation,
}) {
  required = required || !!validation;

  const hasFormik = !!formik;

  const normalizedType = (type === 'switch' || type === 'checkbox') ? 'checkbox' : type;
  const inputProps = hasFormik
    ? { ...formik.getFieldProps({ name, type: normalizedType }) }
    : { name, value, onChange };

  const showError = hasFormik
    ? formik.touched[name] && formik.errors[name]
    : touched && error;

  // Global phone formatter — international, live-formatted as the user
  // types (e.g. "+94 77 123 4567"), via libphonenumber-js's AsYouType.
  const formatPhone = formatPhoneAsYouType;

  // Custom onChange for phone
  const handlePhoneChange = (e) => {
    const raw = e.target.value;
    const formatted = formatPhone(raw);
    if (hasFormik) {
      formik.setFieldValue(name, formatted);
    } else if (onChange) {
      // Simulate a normal event for non-Formik
      onChange({ target: { name, value: formatted } });
    }
  };

  // Shared live-editing amount formatter (commas + 2-decimal cap)
  const formatAmount = formatAmountInput;

  // Custom onChange for amount
  const handleAmountChange = (e) => {
    const raw = e.target.value.replace(/,/g, "");
    // const formatted = formatAmount(raw);
    if (hasFormik) {
      formik.setFieldValue(name, raw);
    } else if (onChange) {
      onChange({ target: { name, value: raw } });
    }
  };

  const [selectSearchText, setSelectSearchText] = React.useState('');
  const [selectOpen, setSelectOpen] = React.useState(false);
  const [highlightIndex, setHighlightIndex] = React.useState(0);
  const [menuRect, setMenuRect] = React.useState(null);
  const dropdownRef = React.useRef(null);
  const triggerRef = React.useRef(null);
  const menuRef = React.useRef(null);
  const enableSelectSearch = !!config?.features?.selectSearch;

  const updateMenuRect = React.useCallback(() => {
    if (!triggerRef.current) return;
    const r = triggerRef.current.getBoundingClientRect();
    const spaceBelow = window.innerHeight - r.bottom;
    const spaceAbove = r.top;
    const maxHeight = 280;
    const gap = 4;
    const openUp = spaceBelow < 200 && spaceAbove > spaceBelow;
    setMenuRect({
      left: r.left,
      width: r.width,
      openUp,
      top: openUp ? null : r.bottom + gap,
      bottom: openUp ? window.innerHeight - r.top + gap : null,
      maxHeight: Math.min(maxHeight, (openUp ? spaceAbove : spaceBelow) - gap - 4),
    });
  }, []);

  // Filter select options by text when search is enabled
  const getFilteredOptions = React.useCallback(() => {
    const list = dataBinding?.data ?? [];
    if (!enableSelectSearch) return list;
    const q = (selectSearchText || '').toString().toLowerCase();
    if (!q) return list;
    const keyField = dataBinding?.keyField;
    const valueField = dataBinding?.valueField;
    return list.filter((opt) => {
      const keyVal = keyField ? String(opt[keyField] ?? '') : '';
      const valVal = valueField ? String(opt[valueField] ?? '') : '';
      return keyVal.toLowerCase().includes(q) || valVal.toLowerCase().includes(q);
    });
  }, [dataBinding, enableSelectSearch, selectSearchText]);

  // Close dropdown on outside click (covers both trigger and portal menu)
  React.useEffect(() => {
    if (!selectOpen) return;
    const onDocClick = (e) => {
      const inTrigger = dropdownRef.current && dropdownRef.current.contains(e.target);
      const inMenu = menuRef.current && menuRef.current.contains(e.target);
      if (!inTrigger && !inMenu) {
        setSelectOpen(false);
        if (hasFormik) formik.setFieldTouched(name, true, false);
      }
    };
    document.addEventListener('mousedown', onDocClick);
    return () => document.removeEventListener('mousedown', onDocClick);
  }, [selectOpen, hasFormik, formik, name]);

  // Reposition portal menu on open + on scroll/resize
  React.useEffect(() => {
    if (!selectOpen) return;
    updateMenuRect();
    const onChange = () => updateMenuRect();
    window.addEventListener('scroll', onChange, true);
    window.addEventListener('resize', onChange);
    return () => {
      window.removeEventListener('scroll', onChange, true);
      window.removeEventListener('resize', onChange);
    };
  }, [selectOpen, updateMenuRect]);

  const setValueAndClose = (val) => {
    if (hasFormik) {
      formik.setFieldValue(name, val);
      formik.setFieldTouched(name, true, false);
    } else if (onChange) {
      onChange({ target: { name, value: val } });
    }
    setSelectOpen(false);
  };

  const renderInput = () => {
    if (type === 'images') {
      // Delegate to multi-image picker; handles its own label and errors
      return (
        <ImageMultiInputField
          name={name}
          placeholder={placeholder}
          formik={formik}
        />
      );
    }

    if (type === 'select') {
      if (!enableSelectSearch) {
        return (
          <select className="form-select" id={name} {...inputProps} value={inputProps.value ?? ''} disabled={disabled}>
            <option value="">{placeholder || '-- Select --'}</option>
            {dataBinding?.data?.map((opt) => (
              <option key={opt[dataBinding.keyField]} value={opt[dataBinding.keyField]}>
                {opt[dataBinding.valueField]}
              </option>
            ))}
          </select>
        );
      }

      // Searchable custom dropdown
      let options = getFilteredOptions();
      const keyField = dataBinding?.keyField;
      const valueField = dataBinding?.valueField;
      const selectedVal = (inputProps?.value ?? '').toString();
      if (keyField) {
        let foundInOptions = false;
        for (let j = 0; j < options.length; j++) {
          const val = options[j][keyField];
          if (val != null && val.toString() === selectedVal) {
            foundInOptions = true;
            break;
          }
        }
        if (!foundInOptions) {
          const data = dataBinding?.data ?? [];
          for (let j = 0; j < data.length; j++) {
            const val = data[j][keyField];
            if (val != null && val.toString() === selectedVal) {
              options = [data[j], ...options];
              break;
            }
          }
        }
      }

      const placeholderLabel = placeholder ? `Select ${placeholder}` : '-- Select --';

      const items = [
        { label: placeholderLabel, value: '' },
        ...options.map((o) => ({ label: o[valueField], value: o[keyField] }))
      ];

      const selectedItem = items.find((i) => (i.value ?? '').toString() === selectedVal);
      const displayLabel = selectedItem ? selectedItem.label : placeholderLabel;

      const toggleOpen = () => {
        if (disabled) return;
        const newOpen = !selectOpen;
        setSelectOpen(newOpen);
        if (newOpen) {
          // On open, reset search and highlight selected index
          setSelectSearchText('');
          const idx = Math.max(0, items.findIndex((i) => (i.value ?? '').toString() === selectedVal));
          setHighlightIndex(idx);
        } else if (hasFormik) {
          formik.setFieldTouched(name, true, false);
        }
      };

      const handleKeyDown = (e) => {
        if (!selectOpen) return;
        const max = items.length - 1;
        if (e.key === 'ArrowDown') {
          e.preventDefault();
          setHighlightIndex((i) => (i < max ? i + 1 : max));
        } else if (e.key === 'ArrowUp') {
          e.preventDefault();
          setHighlightIndex((i) => (i > 0 ? i - 1 : 0));
        } else if (e.key === 'Enter') {
          e.preventDefault();
          const item = items[highlightIndex];
          if (item) setValueAndClose(item.value);
        } else if (e.key === 'Escape') {
          e.preventDefault();
          setSelectOpen(false);
          if (hasFormik) formik.setFieldTouched(name, true, false);
        }
      };

      const showSearch = (dataBinding?.data?.length ?? 0) >= 7;

      const menu = selectOpen && menuRect ? createPortal(
        <div
          ref={menuRef}
          className={`dropdown-menu show rv-select-portal ml-select-menu `.trim()}
          style={{
            position: 'fixed',
            left: menuRect.left,
            top: menuRect.top ?? 'auto',
            bottom: menuRect.bottom ?? 'auto',
            width: menuRect.width,
            maxHeight: menuRect.maxHeight,
            zIndex: 2050,
          }}
          role="listbox"
        >
          {showSearch && (
          <div className="rv-select-search">
            <i className="bi bi-search rv-select-search-icon" aria-hidden="true" />
            <input
              type="text"
              className="rv-select-search-input"
              placeholder={`Search ${placeholder || ''}`.trim() || 'Search...'}
              value={selectSearchText}
              onChange={(e) => { setSelectSearchText(e.target.value); setHighlightIndex(0); }}
              onKeyDown={handleKeyDown}
              autoFocus
            />
          </div>
          )}
          <div className="rv-select-options">
            <button
              type="button"
              className={`rv-select-option rv-select-placeholder${selectedVal === '' ? ' is-active' : ''}`}
              onClick={() => setValueAndClose('')}
              role="option"
              aria-selected={selectedVal === ''}
            >
              {placeholderLabel}
            </button>
            {items.slice(1).map((item, idx) => {
              const absoluteIdx = idx + 1;
              const isActive = (item.value ?? '').toString() === selectedVal;
              const isHighlighted = absoluteIdx === highlightIndex;
              return (
                <button
                  type="button"
                  key={item.value}
                  className={`rv-select-option${isActive ? ' is-active' : ''}${isHighlighted && !isActive ? ' is-highlighted' : ''}`}
                  onClick={() => setValueAndClose(item.value)}
                  onMouseEnter={() => setHighlightIndex(absoluteIdx)}
                  role="option"
                  aria-selected={isActive}
                >
                  {item.label}
                </button>
              );
            })}
            {items.length <= 1 && (
              <div className="rv-select-empty">No matches</div>
            )}
          </div>
        </div>,
        document.body
      ) : null;

      return (
        <div className="position-relative w-100" ref={dropdownRef}>
          <button
            ref={triggerRef}
            type="button"
            id={name}
            className="form-select text-start d-flex justify-content-between align-items-center"
            onClick={toggleOpen}
            onKeyDown={handleKeyDown}
            disabled={disabled}
            aria-haspopup="listbox"
            aria-expanded={selectOpen}
          >
            <span className="text-truncate">{displayLabel}</span>
            <span className="ms-2 d-flex align-items-center">
              {clearable && selectedVal !== '' && !disabled && (
                <span
                  role="button"
                  tabIndex={-1}
                  className="rv-select-clear"
                  aria-label="Clear selection"
                  onMouseDown={(e) => e.preventDefault()}
                  onClick={(e) => {
                    e.stopPropagation();
                    setValueAndClose('');
                  }}
                >
                  <i className="bi bi-x-lg" aria-hidden="true" />
                </span>
              )}
              <span aria-hidden="true">▾</span>
            </span>
          </button>
          {menu}
        </div>
      );
    }

    if (type === 'textarea') {
      return (
        <textarea
          className="form-control"
          id={name}
          placeholder={placeholder}
          {...inputProps}
          value={inputProps.value ?? ''}
          autoComplete="off"
          rows={4}
          readOnly={readOnly}
        />
      );
    }

    if (type === 'phone') {
      // Use value from Formik or prop
      const phoneValue = hasFormik ? formik.values[name] : value;
      return (
        <input
          className="form-control"
          id={name}
          type="text"
          placeholder={placeholder || '+1 415 555 2671'}
          name={name}
          value={formatPhone(phoneValue)}
          onChange={handlePhoneChange}
          autoComplete="off"
          disabled={disabled}
          maxLength={20}
        />
      );
    }

    if (type === 'amount') {
      // Use value from Formik or prop
      const amountValue = hasFormik ? formik.values[name] : value;
      return (
        <input
          className="form-control text-end"
          id={name}
          type="text"
          placeholder={placeholder || '0.00'}
          name={name}
          value={formatAmount(amountValue)}
          onChange={handleAmountChange}
          autoComplete="off"
          disabled={disabled}
          inputMode="decimal"
          maxLength={16}
        />
      );
    }

    if (type === 'number') {
      return (
        <input
          className="form-control"
          id={name}
          type="number"
          placeholder={placeholder}
          {...inputProps}
          value={inputProps.value ?? ''}
          autoComplete="off"
          disabled={disabled}
        />
      );
    }
    if (type === 'switch') {
      return (  <div className="form-check form-switch ">
         <input
          className="form-check-input"
          id={name}
          type="checkbox" role="switch"// keep spinner away
          {...inputProps}
            checked={!!inputProps.value}
        />
        </div>
      );
    }  
      if (type === 'checkbox') {
      return (  <div className="form-check  ">
          {/* <input className="form-check-input" type="checkbox" role="switch" id="switchCheckDefault"/> */}
         <input
          className="form-check-input"
          id={name}
          type="checkbox" role="switch"// keep spinner away
          // placeholder={placeholder}
          {...inputProps}
            checked={!!inputProps.value}
          // autoComplete="off"
        />
         {/* <label className="form-check-label" htmlFor="switchCheckDefault">{placeholder}</label> */}
        </div>
      );
    }
    if (type === 'date' || type === 'datetime') {
      const dateValue = hasFormik ? formik.values[name] : value;
      return (
        <DateTimePicker
          name={name}
          value={dateValue}
          type={type}
          onChange={hasFormik
            ? (e) => {
                formik.setFieldValue(name, e.target.value);
                formik.setFieldTouched(name, true, false);
              }
            : onChange
          }
          disabled={disabled}
          readOnly={readOnly}
          placeholder={placeholder}
        />
      );
    }
    // Default input
    return (
      <input
        className="form-control"
        id={name}
        type={type}
        placeholder={placeholder}
        {...inputProps}
        value={inputProps.value ?? ''}
        readOnly={readOnly}
        disabled={disabled}
        autoComplete="off"
      />
    );
  };
if(!visible){
  return null;
}

  if (type === 'checkbox' ) {
    return (
      <div className={`form-group d-flex align-items-center gap-2 checkbox-custom ${className}`}>
      <div className="input-group flex-nowrap ">
        {renderInput()}
        <label htmlFor={name} className="form-label mb-0 ms-2 ">{placeholder}</label>
      </div>
      {showError && (
        <small>
        <div className="error-message">
          {hasFormik ? formik.errors[name] : error}
        </div>
        </small>
      )}
      </div>
    );
  }

  // Default return for other types
  return (
   
    <div className={`form-group ${className}`}>
    {labelOnTop && type !== 'images' && (
      <label htmlFor={name} className="form-label text-nowrap ">
        {placeholder}
        {required && <span className="text-danger ms-1">*</span>}
      </label>
    )}  
      <div className="input-group">
            {!labelOnTop && type !== 'images' && (
              <label htmlFor={name} className="form-label ">
                {placeholder}
                {required && <span className="text-danger ms-1">*</span>}
              </label>
            )} 
        {renderInput()}
        {children}
      </div>
      {type !== 'images' && showError && (
        <small>
          <div className="error-message">
            {hasFormik ? formik.errors[name] : error}
          </div>
        </small>
      )}
    </div>
  );
}

export default InputField;
