export interface ReportEntry {
  id: string;
  workItemId: number;
  workItemTitle: string;
  workItemType: string;
  project: string;
  costCenter: string;   // Looked up from project settings at report load time
  date: string;          // YYYY-MM-DD
  hours: number;
  taskType: string;      // empty string = unspecified
  category: string;      // 'AMC' | 'Other' — set at report load via AMC config
  notes: string;
  createdBy: string;
  createdById: string;
}

export interface ReportFilters {
  dateFrom: string;
  dateTo: string;
  projects: string[];    // empty = all
  users: string[];       // empty = all
  taskTypes: string[];   // empty = all
  costCenters: string[]; // empty = all
}

export type GroupBy = 'user' | 'project' | 'costCenter' | 'date' | 'category';

export interface GroupedRow {
  label: string;                       // user name, project name, or cost centre
  key: string;                         // unique key for this group
  hoursByType: Record<string, number>; // taskType → sum
  total: number;
  entries: ReportEntry[];
  expanded?: boolean;
}

export interface ReportResult {
  rows: GroupedRow[];
  taskTypeColumns: string[];  // distinct task types in filtered data
  grandTotal: number;
  totalAmcHours: number;
  totalUsers: number;
  totalProjects: number;
  totalCostCenters: number;
  totalEntries: number;
}
