const yup = require('yup');
const { optionalNumber } = require('../../../middleware/validation');

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  paramId: yup.string().nullable(),
  paramGroup: yup.string().required('Group is required'),
  paramKey: yup.string().required('Key is required'),
  numValue: optionalNumber(),
  textValue: yup.string().nullable(),
  glAccountId: yup.string().nullable(),
  isActive: yup.boolean().default(true),
});

const deleteSchema = yup.object({ id: yup.string().required() });

module.exports = { updateSchema, deleteSchema };
