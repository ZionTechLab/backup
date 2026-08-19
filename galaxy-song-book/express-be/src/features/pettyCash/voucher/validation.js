const yup = require('yup');
const { optionalNumber } = require('../../../middleware/validation');

const lineSchema = yup.object({
  categoryId: yup.string().required(),
  description: yup.string().nullable(),
  qty: optionalNumber(),
  unitPrice: optionalNumber(),
  netAmount: optionalNumber(),
  vatAmount: optionalNumber(),
  lineTotal: optionalNumber(),
  costCenterCode: yup.string().nullable(),
});

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  voucherId: yup.string().nullable(),
  cashBookId: yup.string().required('Cash book is required'),
  voucherDate: yup.string().required('Date is required'),
  payeePartyType: yup.string().nullable(),
  payeePartyId: yup.string().nullable(),
  payeeName: yup.string().nullable(),
  payeeNic: yup.string().nullable(),
  costCenterCode: yup.string().nullable(),
  jobNo: yup.string().nullable(),
  description: yup.string().nullable(),
  currencyCode: yup.string().required('Currency is required'),
  exchangeRate: optionalNumber(),
  receiptPath: yup.string().nullable(),
  remarks: yup.string().nullable(),
  lines: yup.array().of(lineSchema).min(1, 'At least one line is required').default([]),
});

const idSchema = yup.object({ id: yup.string().required() });

module.exports = { lineSchema, updateSchema, idSchema };
