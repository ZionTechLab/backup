const yup = require('yup');

const loginSchema = yup.object({
    userName: yup.string().required(),
    password: yup.string().required(),
});

const refreshSchema = yup.object({
    refreshToken: yup.string().required(),
});

const changePasswordSchema = yup.object({
    currentPassword: yup.string().required('Current password is required'),
    newPassword: yup.string().required('New password is required').min(6, 'Password must be at least 6 characters'),
});

module.exports = { loginSchema, refreshSchema, changePasswordSchema };
