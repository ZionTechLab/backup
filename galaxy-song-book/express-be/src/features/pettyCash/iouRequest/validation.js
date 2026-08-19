const yup = require('yup');
const { optionalNumber } = require('../../../middleware/validation');

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  iouRequestId: yup.string().nullable(),
  partyType: yup.string().required('Party type is required'),
  partyId: yup.string().required('Party is required'),
  purpose: yup.string().nullable(),
  requestAmount: yup.number().required('Amount is required').moreThan(0, 'Amount must be greater than zero'),
  expectedSettlementDate: yup.string().nullable(),
  iouDate: yup.string().nullable(),
  jobPoRef: yup.string().nullable(),
  supportingDocPath: yup.string().nullable(),
  remarks: yup.string().nullable(),
  branchOrgUnitId: yup.string().nullable(),
  departmentOrgUnitId: yup.string().nullable(),
  sectionOrgUnitId: yup.string().nullable(),
  currencyCode: yup.string().nullable(),
  docs: yup.array().of(yup.object({
    filePath: yup.string().required(),
    comment: yup.string().nullable(),
  })).default([]),
});

const idSchema = yup.object({ id: yup.string().required() });

const actSchema = yup.object({
  id: yup.string().required(),
  action: yup.string().oneOf(['Approve', 'Reject']).required(),
  amount: optionalNumber(),
  comment: yup.string().nullable(),
});

module.exports = { updateSchema, idSchema, actSchema };
