const yup = require('yup');
const { optionalNumber } = require('../../middleware/validation');

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  header: yup.object({
    id: optionalNumber(),
    txnDate: yup.string().nullable(),
    partner: yup.string().required(),
    vehicle: yup.number().required(),
    typeOfMachine: yup.number().required(),
    operator: yup.string().required(),
    helper: yup.string().nullable(),
    remarks: yup.string().nullable(),
    km: optionalNumber(),
    time: yup.string().nullable(),
    diesel: yup.string().nullable(),
    certifiedHours: yup.string().nullable(),
  }).required(),
  lineItems: yup.array().of(yup.object({
    description: yup.string().nullable(),
    amount: optionalNumber(),
    hours: yup.string().nullable(),
  })).default([]),
});

const deleteSchema = yup.object({
  id: yup.number().required(),
});

module.exports = { updateSchema, deleteSchema };
