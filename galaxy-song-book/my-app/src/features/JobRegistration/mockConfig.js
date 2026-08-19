// Mock configuration for Job Registration entity
// Fields: jobId (auto/code), intakeDate, partner, deliveredBy, item, serialNumber, natureOfFault, status, remarks

const jobStatuses = [
  { id: 1, value: 'Pending' },
  { id: 2, value: 'In Progress' },
  { id: 3, value: 'Completed' },
  { id: 4, value: 'Cancelled' },
];

const jobRegistrationSeed = [
  {
    id: 1,
    jobId: 'JOB-001',
    intakeDate: new Date().toISOString().split('T')[0],
    partner: 1,
    deliveredBy: 'John Doe',
    item: 'Generator Unit',
    serialNumber: 'SN-1001',
    natureOfFault: 'Will not start under load',
    status: 'Pending',
    remarks: 'Customer waiting for quick turnaround'
  },
  {
    id: 2,
    jobId: 'JOB-002',
    intakeDate: new Date().toISOString().split('T')[0],
    partner: 2,
    deliveredBy: 'Jane Smith',
    item: 'Control Board',
    serialNumber: 'CTRL-9988',
    natureOfFault: 'Intermittent power failure',
    status: 'In Progress',
    remarks: ''
  }
];

const jobRegistrationMockConfig = {
  storage: 'mock.jobRegistration',
  seed: jobRegistrationSeed,
  idField: 'id',
  code: { field: 'jobId', from: 'item', length: 3 }, // derives code prefix from item name (e.g., GEN, CON) + id fallback handled by fakeApi
  createFields: ['intakeDate','partner','deliveredBy','item','serialNumber','natureOfFault','status','remarks'],
  updateFields: ['intakeDate','partner','deliveredBy','item','serialNumber','natureOfFault','status','remarks'],
  uiData: { Statuses: jobStatuses },
};

export default jobRegistrationMockConfig;
