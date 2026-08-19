const yup = require('yup');

const updateSchema = yup.object({
  companyId: yup.string().uuid().required(),
  tenantId:  yup.string().uuid().required(),
  fnYear:    yup.number().integer().required(),
  fnMonth:   yup.number().integer().min(1).max(12).required(),
  isClosed:  yup.boolean().required(),
});

module.exports = { updateSchema };
