const yup = require('yup');
const { optionalNumber, phoneNumber } = require('../../middleware/validation');

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  header: yup.object({
    id: optionalNumber(),
    name: yup.string().required(),
    email: yup.string().nullable(),
    whatsAppNo: phoneNumber(),
  }).required(),
});

const deleteSchema = yup.object({
  param: yup.object({ id: yup.number().required() }).required(),
});

module.exports = { updateSchema, deleteSchema };
