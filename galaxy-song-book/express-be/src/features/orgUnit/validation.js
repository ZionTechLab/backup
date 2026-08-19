const yup = require('yup');

const saveSchema = yup.object({
  orgUnitId: yup.string().uuid().nullable().transform((v) => (v === '' ? null : v)),
  unitType: yup.string().oneOf(['Branch', 'Division', 'Department', 'Section']).required('Unit type is required'),
  companyId: yup.string().uuid().nullable().transform((v) => (v === '' ? null : v)),
  code: yup.string().required('Code is required').max(40),
  name: yup.string().required('Name is required').max(150),
  parentId: yup.string().uuid().nullable().transform((v) => (v === '' ? null : v)),
  isActive: yup.boolean().default(true),
});

module.exports = { saveSchema };
