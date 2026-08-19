const yup = require('yup');

const updateSchema = yup.object({
  isUpdate:        yup.boolean().required(),
  accountId:       yup.string().uuid().nullable().when('isUpdate', { is: true, then: s => s.required() }),
  tenantId:        yup.string().uuid().nullable().when('isUpdate', { is: false, then: s => s.required() }),
  groupId:         yup.string().uuid().nullable().when('isUpdate', { is: false, then: s => s.required() }),
  accountType:     yup.string().max(1).required(),
  accountCode:     yup.string().max(20).required(),
  accountName:     yup.string().max(150).required(),
  parentAccountId: yup.string().uuid().nullable(),
  level:           yup.number().integer().required(),
  sortOrder:       yup.number().integer().required(),
  isActive:        yup.boolean().required(),
});

const deleteSchema = yup.object({
  accountId: yup.string().uuid().required(),
});

module.exports = { updateSchema, deleteSchema };
