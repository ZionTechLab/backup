const yup = require('yup');
const { optionalNumber } = require('../../middleware/validation');

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  header: yup.object({
    id: optionalNumber(),
    uomName: yup.string().required('UOM name is required'),
    description: yup.string().nullable(),
    active: yup.boolean().default(true),
  }).required(),
});

const deleteSchema = yup.object({
  id: yup.number().required(),
});

module.exports = { updateSchema, deleteSchema };
