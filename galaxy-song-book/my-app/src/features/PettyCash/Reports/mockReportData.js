// Shared, deterministic mock data for the demo-only reports (Summary,
// Detailed, Tracking, Analytical). Fixed, not randomized, so numbers stay
// consistent across pages and across reloads — Summary's cashier subtotals
// must match Detailed's for the same period.

export const CASHIERS = ['Nimal Perera', 'Kasun Silva', 'Dilani Fernando'];
export const CATEGORIES = ['Fuel', 'Stationery', 'Courier', 'Refreshments', 'Repairs'];
export const DEPARTMENTS = ['Production', 'Admin', 'Sales', 'Finance'];
export const VENDORS = ['ABC Traders', 'Quick Mart', 'City Hardware', 'Speedy Couriers'];
export const ITEM_CATEGORIES = ['Office Supplies', 'Vehicle', 'Utilities', 'Food & Beverage'];

// One flat list of petty cash payment transactions. Every Summary/Detailed
// report page filters and groups this same list, so they can never disagree.
export const TRANSACTIONS = [
  { date: '2026-07-01', cashier: 'Nimal Perera', category: 'Fuel', department: 'Production', vendor: 'City Hardware', itemCategory: 'Vehicle', description: 'Diesel top-up - delivery van', amount: 4500 },
  { date: '2026-07-01', cashier: 'Nimal Perera', category: 'Stationery', department: 'Admin', vendor: 'Quick Mart', itemCategory: 'Office Supplies', description: 'Printer paper & pens', amount: 1250 },
  { date: '2026-07-02', cashier: 'Kasun Silva', category: 'Courier', department: 'Sales', vendor: 'Speedy Couriers', itemCategory: 'Office Supplies', description: 'Sample dispatch to client', amount: 850 },
  { date: '2026-07-02', cashier: 'Kasun Silva', category: 'Refreshments', department: 'Admin', vendor: 'Quick Mart', itemCategory: 'Food & Beverage', description: 'Client meeting refreshments', amount: 2200 },
  { date: '2026-07-03', cashier: 'Dilani Fernando', category: 'Repairs', department: 'Production', vendor: 'City Hardware', itemCategory: 'Vehicle', description: 'Forklift tyre repair', amount: 6800 },
  { date: '2026-07-03', cashier: 'Nimal Perera', category: 'Fuel', department: 'Sales', vendor: 'City Hardware', itemCategory: 'Vehicle', description: 'Fuel - rep vehicle', amount: 3900 },
  { date: '2026-07-04', cashier: 'Kasun Silva', category: 'Stationery', department: 'Finance', vendor: 'Quick Mart', itemCategory: 'Office Supplies', description: 'Ledger books', amount: 950 },
  { date: '2026-07-04', cashier: 'Dilani Fernando', category: 'Courier', department: 'Admin', vendor: 'Speedy Couriers', itemCategory: 'Office Supplies', description: 'Document courier - HO', amount: 650 },
  { date: '2026-07-05', cashier: 'Nimal Perera', category: 'Refreshments', department: 'Production', vendor: 'Quick Mart', itemCategory: 'Food & Beverage', description: 'Staff refreshments - late shift', amount: 1800 },
  { date: '2026-07-05', cashier: 'Kasun Silva', category: 'Fuel', department: 'Sales', vendor: 'City Hardware', itemCategory: 'Vehicle', description: 'Fuel - site visit', amount: 4100 },
  { date: '2026-07-08', cashier: 'Dilani Fernando', category: 'Repairs', department: 'Admin', vendor: 'City Hardware', itemCategory: 'Utilities', description: 'AC unit service', amount: 5200 },
  { date: '2026-07-08', cashier: 'Nimal Perera', category: 'Stationery', department: 'Production', vendor: 'Quick Mart', itemCategory: 'Office Supplies', description: 'Labels & tape', amount: 720 },
  { date: '2026-07-09', cashier: 'Kasun Silva', category: 'Courier', department: 'Finance', vendor: 'Speedy Couriers', itemCategory: 'Office Supplies', description: 'Bank documents dispatch', amount: 480 },
  { date: '2026-07-09', cashier: 'Dilani Fernando', category: 'Refreshments', department: 'Sales', vendor: 'Quick Mart', itemCategory: 'Food & Beverage', description: 'Client visit refreshments', amount: 1600 },
  { date: '2026-07-10', cashier: 'Nimal Perera', category: 'Fuel', department: 'Admin', vendor: 'City Hardware', itemCategory: 'Vehicle', description: 'Fuel - admin vehicle', amount: 3600 },
  { date: '2026-07-10', cashier: 'Kasun Silva', category: 'Repairs', department: 'Production', vendor: 'City Hardware', itemCategory: 'Vehicle', description: 'Generator maintenance', amount: 7400 },
  { date: '2026-07-11', cashier: 'Dilani Fernando', category: 'Stationery', department: 'Finance', vendor: 'Quick Mart', itemCategory: 'Office Supplies', description: 'Files & folders', amount: 610 },
  { date: '2026-07-11', cashier: 'Nimal Perera', category: 'Courier', department: 'Sales', vendor: 'Speedy Couriers', itemCategory: 'Office Supplies', description: 'Contract dispatch', amount: 720 },
  { date: '2026-07-12', cashier: 'Kasun Silva', category: 'Refreshments', department: 'Production', vendor: 'Quick Mart', itemCategory: 'Food & Beverage', description: 'Weekly staff meeting', amount: 2100 },
  { date: '2026-07-12', cashier: 'Dilani Fernando', category: 'Fuel', department: 'Admin', vendor: 'City Hardware', itemCategory: 'Vehicle', description: 'Fuel - director vehicle', amount: 4800 },
];

export function totalForCashier(rows, cashier) {
  return rows.filter((r) => r.cashier === cashier).reduce((s, r) => s + r.amount, 0);
}

export function filterByPeriod(rows, from, to) {
  return rows.filter((r) => (!from || r.date >= from) && (!to || r.date <= to));
}

// One row per IOU Request tracked end to end: what was requested, what was
// actually issued, and what's been settled so far. settled <= paidOut <=
// requested always holds, by construction.
export const TRACKING_ROWS = [
  { requestNo: 'PREQ/0041', party: 'Nimal Perera', department: 'Production', requestDate: '2026-07-01', requested: 15000, paidOut: 15000, settled: 15000, status: 'Fully Settled' },
  { requestNo: 'PREQ/0042', party: 'Kasun Silva', department: 'Sales', requestDate: '2026-07-03', requested: 20000, paidOut: 20000, settled: 12500, status: 'Partially Settled' },
  { requestNo: 'PREQ/0043', party: 'Dilani Fernando', department: 'Admin', requestDate: '2026-07-05', requested: 10000, paidOut: 8000, settled: 0, status: 'Pending Settlement' },
  { requestNo: 'PREQ/0044', party: 'Nimal Perera', department: 'Production', requestDate: '2026-07-08', requested: 25000, paidOut: 25000, settled: 25000, status: 'Fully Settled' },
  { requestNo: 'PREQ/0045', party: 'Kasun Silva', department: 'Finance', requestDate: '2026-07-09', requested: 12000, paidOut: 12000, settled: 9000, status: 'Partially Settled' },
  { requestNo: 'PREQ/0046', party: 'Dilani Fernando', department: 'Sales', requestDate: '2026-07-11', requested: 18000, paidOut: 0, settled: 0, status: 'Awaiting Payment' },
];

// Yesterday's petty cash payments — pre-sorted highest to lowest, matching
// what the SOD alert email would contain.
export const YESTERDAYS_PAYMENTS = [...TRANSACTIONS]
  .slice(-8)
  .sort((a, b) => b.amount - a.amount);
