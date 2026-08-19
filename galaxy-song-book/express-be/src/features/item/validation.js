const yup = require('yup');
const { optionalNumber } = require('../../middleware/validation');

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  header: yup.object({
    id: optionalNumber(),
    itemName: yup.string().required(),
    description: yup.string().nullable(),
    uom: yup.string().required(),
    brand: yup.string().required(),
    reorderLevel: optionalNumber(),
    costPrice: optionalNumber(),
    sellingPrice: optionalNumber(),
    active: yup.boolean().default(true),
  }).required(),
});

const deleteSchema = yup.object({
  id: yup.number().required(),
});

module.exports = { updateSchema, deleteSchema };
