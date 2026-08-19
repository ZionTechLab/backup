const yup = require('yup');

const updateSchema = yup.object({
  isUpdate: yup.boolean().required(),
  header: yup.object({
    companyId:        yup.mixed().when('$isUpdate', { is: true, then: s => s.required() }),
    companyCode:      yup.string().required(),
    companyName:      yup.string().required(),
    tenantId:         yup.string().required(),
    groupId:          yup.string().required(),
    country:          yup.number().nullable(),
    baseCurrencyCode: yup.string().required(),
  }).required(),
});

const deleteSchema = yup.object({
  companyId: yup.string().required(),
});

const addUserSchema = yup.object({
  companyId: yup.string().required(),
  userId: yup.string().required(),
});

const removeUserSchema = yup.object({
  id: yup.number().required(),
});

const setDefaultSchema = yup.object({
  id: yup.number().required(),
});

const listUsersSchema = yup.object({
  companyId: yup.string().required(),
});

module.exports = { updateSchema, deleteSchema, addUserSchema, removeUserSchema, setDefaultSchema, listUsersSchema };
