import { useCallback } from 'react';
import { todayISO } from '../helpers/transformDateFields';

/**
 * Standalone CSV export function (can be used without React hooks)
 * @param {Array} data - Array of data rows
 * @param {Array} columns - Array of column definitions
 * @param {string} filename - Base filename for the CSV (default: 'export')
 */
export const exportToCSV = (data, columns, filename = 'export') => {
  // Filter exportable columns (exclude action columns)
  const exportColumns = columns.filter(col => col.field && !col.isAction);
  
  if (!data || data.length === 0) {
    alert('No data to export');
    return;
  }
  
  // Create CSV headers
  const headers = exportColumns.map(col => col.header).join(',');
  
  // Create CSV rows
  const rows = data.map(row => 
    exportColumns.map(col => {
      const value = row[col.field] || '';
      // Escape commas, quotes, and newlines
      const escapedValue = String(value)
        .replace(/"/g, '""')
        .replace(/\r?\n/g, ' ');
      
      // Wrap in quotes if contains comma, quote, or newline
      return /[",\r\n]/.test(escapedValue) ? `"${escapedValue}"` : escapedValue;
    }).join(',')
  );
  
  // Combine headers and rows
  const csvContent = [headers, ...rows].join('\n');
  
  // Create and download file
  const blob = new Blob([csvContent], { type: 'text/csv;charset=utf-8;' });
  const link = document.createElement('a');
  const url = URL.createObjectURL(blob);
  
  link.href = url;
  link.download = `${filename}_${todayISO()}.csv`;
  link.style.display = 'none';
  
  document.body.appendChild(link);
  link.click();
  document.body.removeChild(link);
  
  // Clean up
  URL.revokeObjectURL(url);
};

/**
 * React hook for CSV export (wraps the standalone function)
 */
export const useCSVExport = () => {
  const exportToCSVCallback = useCallback(exportToCSV, []);

  return { exportToCSV: exportToCSVCallback };
};
