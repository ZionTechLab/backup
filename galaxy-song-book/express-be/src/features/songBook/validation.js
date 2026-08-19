const yup = require('yup');
const { optionalNumber } = require('../../middleware/validation');

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  id: optionalNumber(),
  title: yup.string().required(),
  lyrics: yup.string().nullable(),
  language: yup.string().nullable(),
});

const deleteSchema = yup.object({
  id: yup.number().required(),
});

module.exports = { updateSchema, deleteSchema };
