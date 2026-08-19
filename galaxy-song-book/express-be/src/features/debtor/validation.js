const yup = require('yup');
const { optionalNumber } = require('../../middleware/validation');

const headerShape = yup.object({
  id: optionalNumber(),
  txnDate: yup.string().nullable(),
  partner: yup.string().nullable(),
  remarks: yup.string().nullable(),
  ref1: yup.string().nullable(),
  ref2: yup.string().nullable(),
  ref3: yup.string().nullable(),
  amount: optionalNumber(),
  taxAmount: optionalNumber(),
  taxRate: optionalNumber(),
  advance: optionalNumber(),
  totalAmount: optionalNumber(),
});

const lineShape = yup.object({
  description: yup.string().nullable(),
  amount: optionalNumber(),
});

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  isTaxInvoice: yup.boolean().default(false),
  header: headerShape.required(),
  lineItems: yup.array().of(lineShape).default([]),
});

const updateAdvanceSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  isAdvance: yup.boolean().default(false),
  header: headerShape.required(),
});

const deleteSchema = yup.object({
  id: yup.number().required(),
  txnType: yup.string().nullable(),
});

module.exports = { headerShape, lineShape, updateSchema, updateAdvanceSchema, deleteSchema };
