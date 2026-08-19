import { IdCell } from './IdCell';
import { formatDate } from '../../helpers/transformDateFields';

// Renders a column's value for a row. Honors col.render, then col.isId, then
// col.type (boolean / date / currency), then action columns. Otherwise raw value.
export function formatColumnValue(col, row) {
  if (col.render) return col.render(row);
  if (col.isId) return <IdCell id={row[col.field]} short={col.idShort} />;
  if (col.type === 'boolean') {
    return <input className="text-center" type="checkbox" checked={row[col.field]} readOnly />;
  }
  if (col.type === 'date') {
    return formatDate(row[col.field]);
  }
  if (col.type === 'currency') {
    const value = Number(row[col.field]);
    return isNaN(value) ? '' : value.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
  }
  if (col.isAction) {
    return col.actionTemplate ? col.actionTemplate(row) : null;
  }
  return row[col.field];
}
