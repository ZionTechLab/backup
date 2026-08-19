const yup = require('yup');
const { optionalNumber } = require('../../../middleware/validation');

const PAYMENT_MODES = ['PettyCash', 'BankTransfer', 'Cheque', 'Cash'];

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  iouId: yup.string().nullable(),
  cashBookId: yup.string().required('Cash book is required'),
  partyType: yup.string().required('Party type is required'),
  partyId: yup.string().required('Party is required'),
  purpose: yup.string().nullable(),
  requestAmount: yup.number().required('Amount is required').moreThan(0, 'Amount must be greater than zero'),
  expectedSettlementDate: yup.string().nullable(),
  jobPoRef: yup.string().nullable(),
  supportingDocPath: yup.string().nullable(),
  paymentMode: yup.string().nullable().oneOf([null, '', ...PAYMENT_MODES], 'Invalid payment mode'),
  voucherRef: yup.string().nullable(),
  paidDate: yup.string().nullable(),
  paidByCashierId: yup.string().nullable(),
  currencyCode: yup.string().required('Currency is required'),
  exchangeRate: optionalNumber(),
  remarks: yup.string().nullable(),
  branchOrgUnitId: yup.string().nullable(),
  iouRequestId: yup.string().nullable(),
  iouDate: yup.string().nullable(),
  docs: yup.array().of(yup.object({
    filePath: yup.string().required(),
    comment: yup.string().nullable(),
  })).default([]),
});

const idSchema = yup.object({ id: yup.string().required() });

const actSchema = yup.object({
  id: yup.string().required(),
  action: yup.string().oneOf(['Approve', 'Reject', 'OnHold']).required(),
});

const auditSchema = yup.object({
  iouId: yup.string().required(),
  auditorRole: yup.string().nullable(),
  comment: yup.string().nullable(),
});

module.exports = { updateSchema, idSchema, actSchema, auditSchema };
