// Mock configuration for Job Registration Logs
// Each log belongs to a job (jobId foreign key -> JobRegistration.id)
// Fields: id, jobId, logDateTime, userName, note, utilizedTime (minutes), cost, remarks

const jobLogSeed = [
  {
    id: 1,
    jobId: 1,
    logDateTime: new Date().toISOString(),
    userName: 'admin',
    note: 'Initial inspection completed.',
    utilizedTime: 30,
    cost: 0,
    remarks: ''
  },
  {
    id: 2,
    jobId: 1,
    logDateTime: new Date().toISOString(),
    userName: 'admin',
    note: 'Disassembled unit for diagnostics.',
    utilizedTime: 45,
    cost: 0,
    remarks: ''
  }
];

const jobLogMockConfig = {
  storage: 'mock.jobRegistrationLogs',
  seed: jobLogSeed,
  idField: 'id',
  createFields: ['jobId','logDateTime','userName','note','utilizedTime','cost','remarks'],
  updateFields: ['logDateTime','userName','note','utilizedTime','cost','remarks'],
};

export default jobLogMockConfig;
