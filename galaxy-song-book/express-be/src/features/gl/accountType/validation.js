const yup = require('yup');

const updateSchema = yup.object({
  isUpdate:    yup.boolean().required(),
    header: yup.object({
  accountType: yup.string().max(1).required(),
  typeName:   yup.string().required(),
  sortOrder:  yup.number().integer().required(),
  isActive:    yup.boolean().required(),
 }).required(),
});

const deleteSchema = yup.object({
  accountType: yup.string().max(1).required(),
});

module.exports = { updateSchema, deleteSchema };
