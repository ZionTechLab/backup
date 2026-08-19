const yup = require('yup');
const { optionalNumber } = require('../../middleware/validation');

const saveSchema = yup.object({
  isUpdateMode: yup.boolean().default(false),
  permissionGroups: yup.array().of(yup.object({
    permGroupId: optionalNumber(),
    permGroupName: yup.string().trim().min(3, 'Name must be at least 3 characters').required(),
  })).min(1).required(),
  permissions: yup.array().of(yup.object({
    permId: yup.number().required(),
    moduleId: optionalNumber(),
    isPermitted: yup.number().oneOf([0, 1]).default(0),
  })).default([]),
});

module.exports = { saveSchema };
