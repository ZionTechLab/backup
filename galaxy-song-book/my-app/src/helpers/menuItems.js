const menuItems = [
  {
    route: '/',
    displayName: 'Dashboard',
    icon: 'bi bi-grid-1x2',
  },
  {
    id: 'accounting',
    displayName: 'Accounting',
    icon: 'bi bi-journal-text',
    children: [
      { route: '/journals',      displayName: 'Journal Entries',    icon: 'bi bi-journal-plus' },
      { route: '/ledger',        displayName: 'General Ledger',     icon: 'bi bi-list-columns' },
      { route: '/coa',           displayName: 'Chart of Accounts',  icon: 'bi bi-diagram-3' },
    ],
  },
  {
    id: 'reports',
    displayName: 'Reports',
    icon: 'bi bi-bar-chart',
    children: [
      { route: '/reports/trial-balance', displayName: 'Trial Balance',  icon: 'bi bi-table' },
      { route: '/reports/pnl',           displayName: 'P&L Statement',  icon: 'bi bi-graph-up' },
      { route: '/reports/balance-sheet', displayName: 'Balance Sheet',  icon: 'bi bi-layout-split' },
    ],
  },
  {
    id: 'group-reports',
    displayName: 'Group Reports',
    icon: 'bi bi-building',
    children: [
      { route: '/group/pnl',            displayName: 'Consolidated P&L',            icon: 'bi bi-graph-up-arrow' },
      { route: '/group/balance-sheet',  displayName: 'Consolidated Balance Sheet',  icon: 'bi bi-layout-split' },
      { route: '/group/eliminations',   displayName: 'Elimination Report',          icon: 'bi bi-x-circle' },
      { route: '/group/fx-variance',    displayName: 'FX Variance',                 icon: 'bi bi-currency-exchange' },
    ],
  },
  {
    id: 'references',
    displayName: 'References',
    icon: 'bi bi-bookmarks',
    children: [
      { route: '/reference/make',         displayName: 'Make',          icon: 'bi bi-car-front' },
      { route: '/reference/model',        displayName: 'Model',         icon: 'bi bi-car-front-fill' },
      { route: '/reference/grade',        displayName: 'Grade',         icon: 'bi bi-award' },
      { route: '/reference/fuel-type',    displayName: 'Fuel Type',     icon: 'bi bi-fuel-pump' },
      { route: '/reference/transmission', displayName: 'Transmission',  icon: 'bi bi-gear-wide-connected' },
      { route: '/reference/colour',       displayName: 'Colour',        icon: 'bi bi-palette' },
    ],
  },
  {
    id: 'settings',
    displayName: 'Settings',
    icon: 'bi bi-gear',
    children: [
      { route: '/settings/tenants',          displayName: 'Tenants',           icon: 'bi bi-buildings' },
      { route: '/settings/groups',           displayName: 'Groups',            icon: 'bi bi-diagram-2' },
      { route: '/settings/companies',        displayName: 'Companies',         icon: 'bi bi-building' },
      { route: '/settings/users',            displayName: 'Users & Roles',     icon: 'bi bi-people' },
      { route: '/settings/currencies',       displayName: 'Currencies',        icon: 'bi bi-currency-dollar' },
      { route: '/settings/exchange-rates',   displayName: 'Exchange Rates',    icon: 'bi bi-arrow-left-right' },
      { route: '/settings/account-types',   displayName: 'Account Types',     icon: 'bi bi-tag' },
      { route: '/settings/fiscal-year',      displayName: 'Fiscal Year',       icon: 'bi bi-calendar3' },
      { route: '/settings/report-templates', displayName: 'Report Templates',  icon: 'bi bi-file-text' },
      { route: '/audit-log',                 displayName: 'Audit Log',         icon: 'bi bi-shield-lock' },

    ],
  },
];

export default menuItems;
