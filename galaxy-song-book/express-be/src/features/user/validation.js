const yup = require('yup');
const { phoneNumber } = require('../../middleware/validation');

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  header: yup.object({
    userId: yup.string().nullable(),
    userName: yup.string().required(),
    password: yup.string().nullable(),
    fullName: yup.string().required(),
    email: yup.string().required(),
    phone: phoneNumber({ required: true }),
    phone2: phoneNumber(),
    isActive: yup.boolean().default(true),
    roleIds: yup.array().of(yup.number().positive()).default([]),
    permissionIds: yup.array().of(yup.number().positive()).default([]),
  }).required(),
});

const deleteSchema = yup.object({
  userId: yup.string().nullable(),
  id: yup.string().nullable(),
}).test('user-id', 'userId or id is required', (v) => !!(v.userId || v.id));

module.exports = { updateSchema, deleteSchema };
