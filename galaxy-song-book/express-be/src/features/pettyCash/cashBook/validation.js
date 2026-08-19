const yup = require('yup');
const { optionalNumber } = require('../../../middleware/validation');

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  cashBookId: yup.string().nullable(),
  code: yup.string().required('Code is required'),
  name: yup.string().required('Name is required'),
  cashierUserId: yup.string().required('Cashier is required'),
  currencyCode: yup.string().required('Currency is required'),
  glAccountId: yup.string().required('GL account is required'),
  floatLimit: optionalNumber(),
  topUpThreshold: optionalNumber(),
  status: yup.string().oneOf(['Active', 'Inactive', 'Suspended']).default('Active'),
  branchOrgUnitId: yup.string().nullable().transform((v) => (v === '' ? null : v)),
  minFloat: optionalNumber(),
  maxFloat: optionalNumber(),
  iouClosingDays: optionalNumber(),
  remarks: yup.string().nullable(),
});

const deleteSchema = yup.object({ id: yup.string().required() });

const idSchema = yup.object({ id: yup.string().required() });

const establishSchema = yup.object({
  cashBookId: yup.string().required('Cash book is required'),
  amount: yup.number().required('Amount is required').moreThan(0, 'Amount must be greater than zero'),
  bankGlAccountId: yup.string().required('Contra account is required'),
  date: yup.string().nullable(),
});

module.exports = { updateSchema, deleteSchema, idSchema, establishSchema };
