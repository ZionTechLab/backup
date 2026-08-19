const yup = require('yup');

const updateSchema = yup.object({
  isUpdate:         yup.boolean(),
  groupId:          yup.string().nullable().when('isUpdate', { is: true, then: s => s.required() }),
  tenantId:         yup.string().required(),
  groupName:        yup.string().required(),
  baseCurrencyCode: yup.string().nullable(),
});

const deleteSchema = yup.object({
  groupId: yup.string().required(),
});

module.exports = { updateSchema, deleteSchema };
