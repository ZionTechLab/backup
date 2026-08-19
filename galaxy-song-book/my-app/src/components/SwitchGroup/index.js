import React, { useState, useEffect } from 'react';


/**
 * SwitchGroup Component
 * Renders a group of switch inputs from an array of items
 * Manages its own state internally
 * 
 * @param {Array} data - Array of objects with {id, value} from API
 * @param {Function} onChange - Callback function (allItems) => void - returns all items with current state
 * @param {string} className - Optional wrapper class name
 * @param {boolean} defaultValue - Default checked state for all switches (default: false)
 * @param {string} title - Header title for the card (default: 'Job Tags')
 */
function SwitchGroup( {data = [], onChange, className = '', defaultValue = false, title = 'Job Tags',checkedIds = [] } ) {
  const [items, setItems] = useState([]);

  useEffect(() => {
    if (data && data.length > 0 && items.length === 0) {
      const initialItems = data.map(item => ({
        id: item.id,
        name: item.value,
        value: checkedIds.includes(item.id) ? true : defaultValue
      }));
      setItems(initialItems);
    }
  // checkedIds captured once at init; its array ref changes every parent render
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [data, defaultValue]);


  // Initialize items state from data prop only once when component mounts and data is available
  // useEffect(() => {
  //   if (data && data.length > 0 && items.length === 0) {
  //     const initialItems = data.map(item => ({
  //       id: item.id,
  //       name: item.value,
  //       value: defaultValue
  //     }));
  //     setItems(initialItems);
  //   }
  // }, [data, defaultValue, items.length]);

  const handleSwitchChange = (itemId, event) => {
    const newValue = event.target.checked;
    const updatedItems = items.map(item => 
      item.id === itemId ? { ...item, value: newValue } : item
    );
    setItems(updatedItems);
    
    // Notify parent component of all items state
    if (onChange) {
      onChange(updatedItems);
    }
  };

  if (!items || items.length === 0) {
    return null;
  }

  return (
    <div className={className}>
      <div className="mb-3">
        <h6 className="mb-2">{title}</h6>
        <div className="row g-2">  
          {items.map((item) => (
            <div key={item.id} className="col-md-2 col-4">
              <input
                className="form-check-input"
                type="checkbox"
                id={`switch_${item.id}`}
                name={`switch_${item.id}`}
                checked={item.value}
                onChange={(e) => handleSwitchChange(item.id, e)}
              />
              <label className="form-label mb-0 ms-2" htmlFor={`switch_${item.id}`}>
                {item.name}
              </label>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}

export default SwitchGroup;
