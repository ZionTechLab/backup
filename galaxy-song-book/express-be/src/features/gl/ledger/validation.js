const yup = require('yup');

const detailSchema = yup.object({
  lineId:       yup.string().uuid().nullable(),
  accountId:    yup.string().uuid().required(),
  debitAmount:  yup.number().min(0).required(),
  creditAmount: yup.number().min(0).required(),
  currencyCode: yup.string().length(3).required(),
  exchangeRate: yup.number().positive().required(),
  rateTypeId:   yup.number().integer().nullable(),
  description:  yup.string().max(500).nullable(),
});

const updateSchema = yup.object({
  isUpdate:      yup.boolean().required(),
  transactionId: yup.string().uuid().nullable().when('isUpdate', { is: true, then: s => s.required() }),
  tenantId:      yup.string().uuid(),
  companyId:     yup.string().uuid(),
  fnYear:       yup.number().integer().required(),
  fnMonth:      yup.number().integer().min(1).max(12).required(),
  docType:       yup.string().required(),
  txnType:       yup.string().required(),
  txnDate:       yup.date().required(),
  reference:     yup.string().max(100).nullable(),
  description:   yup.string().max(500).nullable(),
  status:        yup.string().oneOf(['Draft', 'Posted', 'Void']).required(),
  details:       yup.array().of(detailSchema).min(2).required(),
});

const deleteSchema = yup.object({
  transactionId: yup.string().uuid().required(),
});

const reportSchema = yup.object({
  accountId: yup.string().uuid().required(),
  fromDate:  yup.date().required(),
  toDate:    yup.date().required(),
});

module.exports = { detailSchema, updateSchema, deleteSchema, reportSchema };
