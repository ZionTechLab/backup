export interface TimeEntry {
  id: string;
  workItemId: number;
  project: string;       // Captured from System.TeamProject at save time
  workItemTitle: string; // Captured from System.Title at save time
  date: string;          // YYYY-MM-DD
  hours: number;
  taskType: string;      // Free-text label from org task type list; empty string = unspecified
  notes: string;
  createdBy: string;     // Display name
  createdById: string;   // Unique identity descriptor / entity id
  createdAt: string;     // ISO 8601
  updatedAt: string;     // ISO 8601
  updatedBy: string;
  updatedById: string;
  isDeleted: boolean;
}

export interface WorkItemTimeEntries {
  id: string;          // Work item ID as string (ExtensionDataService document key)
  entries: TimeEntry[];
}

export interface UserRef {
  id: string;
  displayName: string;
}

export interface TimeEntryFormValues {
  date: string;
  hours: string;
  taskType: string;
  notes: string;
}
