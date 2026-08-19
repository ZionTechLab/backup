const yup = require('yup');
const { optionalNumber } = require('../../../middleware/validation');

const lineSchema = yup.object({
  categoryId: yup.string().required(),
  description: yup.string().nullable(),
  netAmount: optionalNumber(),
  vatAmount: optionalNumber(),
  lineTotal: optionalNumber(),
  costCenterCode: yup.string().nullable(),
});

const allocationSchema = yup.object({
  iouId: yup.string().required(),
  amount: yup.number().required().moreThan(0, 'Allocation must be greater than zero'),
});

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  settlementId: yup.string().nullable(),
  // Cash book is the entry point: it decides currency and scopes which
  // IOUs/requests can be settled. Currency is derived from it server-side.
  cashBookId: yup.string().required('Cash book is required'),
  partyType: yup.string().required('Party type is required'),
  partyId: yup.string().required('Party is required'),
  settlementDate: yup.string().required('Date is required'),
  receiptsPath: yup.string().nullable(),
  remarks: yup.string().nullable(),
  cashReturned: optionalNumber(),
  // Optional link to a draft petty cash request. When set, lines are taken
  // from the voucher server-side and any client lines are ignored.
  voucherId: yup.string().nullable(),
  currencyCode: yup.string().nullable(),
  exchangeRate: optionalNumber(),
  lines: yup.array().of(lineSchema).default([]),
  allocations: yup.array().of(allocationSchema).default([]),
}).test('has-substance', 'Add bills, a petty cash request, an IOU allocation, or a cash return', (v) =>
  !!(v.voucherId || (v.lines && v.lines.length) || (v.allocations && v.allocations.length) || Number(v.cashReturned || 0) > 0)
);

const idSchema = yup.object({ id: yup.string().required() });

const actSchema = yup.object({
  id: yup.string().required(),
  action: yup.string().oneOf(['Approve', 'Reject', 'OnHold']).required(),
  comment: yup.string().nullable(),
  onHoldUntil: yup.string().nullable(),
});

module.exports = { lineSchema, updateSchema, idSchema, actSchema };
