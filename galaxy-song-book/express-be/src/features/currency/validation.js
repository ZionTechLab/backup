const yup = require('yup');

const updateSchema = yup.object({
  isUpdate:     yup.boolean().required(),
  currencyCode: yup.string().max(3).required(),
  currencyName: yup.string().required(),
  symbol:       yup.string().max(5).nullable(),
  isActive:     yup.boolean().default(true),
});

const deleteSchema = yup.object({
  currencyCode: yup.string().required(),
});

module.exports = { updateSchema, deleteSchema };
