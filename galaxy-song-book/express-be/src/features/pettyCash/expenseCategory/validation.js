const yup = require('yup');
const { optionalNumber } = require('../../../middleware/validation');

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  categoryId: yup.string().nullable(),
  name: yup.string().required('Name is required'),
  glAccountId: yup.string().required('Expense account is required'),
  taxMode: yup.string().oneOf(['exempt', 'inclusive', 'exclusive']).default('exempt'),
  taxRate: optionalNumber(),
  inputVatGlAccountId: yup.string().nullable(),
  isActive: yup.boolean().default(true),
});

const deleteSchema = yup.object({ id: yup.string().required() });

module.exports = { updateSchema, deleteSchema };
