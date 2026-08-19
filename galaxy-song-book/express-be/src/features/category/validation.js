const yup = require('yup');
const { optionalNumber } = require('../../middleware/validation');

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  header: yup.object({
    id: optionalNumber(),
    parentId: optionalNumber(),
    categoryType: yup.number().required(),
    value: yup.string().required(),
    description: yup.string().nullable(),
    isActive: yup.boolean().default(true),
    ref1: yup.string().nullable(),
    ref2: yup.string().nullable(),
    ref3: yup.string().nullable(),
    ref4: yup.string().nullable(),
    ref5: yup.string().nullable(),
  }).required(),
});

const deleteSchema = yup.object({
  id: yup.number().required(),
  categoryType: yup.number().required(),
});

module.exports = { updateSchema, deleteSchema };
