const yup = require('yup');
const { optionalNumber } = require('../../middleware/validation');

const saveSchema = yup.object({
  // null id = create a new item.
  id: optionalNumber(),
  parentId: yup.number().required('Parent is required'),
  route: yup.string().required('Route is required'),
  displayName: yup.string().required('Name is required'),
  icon: yup.string().required('Icon is required'),
  isGroup: yup.boolean().default(false),
  isActive: yup.boolean().default(true),
});

const arrangeSchema = yup.object({
  items: yup.array().of(yup.object({
    id: yup.number().required(),
    parentId: yup.number().required(),
    order: yup.number().required(),
  })).min(1, 'Nothing to arrange').required(),
});

const grantsSchema = yup.object({
  id: yup.number().required(),
  roleIds: yup.array().of(yup.number()).default([]),
});

module.exports = { saveSchema, arrangeSchema, grantsSchema };
