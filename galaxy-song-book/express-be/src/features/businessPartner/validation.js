const yup = require('yup');
const { phoneNumber } = require('../../middleware/validation');

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  header: yup.object({
    businessPartnerId: yup.string().nullable(),
    partnerCode: yup.string().required(),
    partnerName: yup.string().required(),
    contactPerson: yup.string().nullable(),
    email: yup.string().nullable(),
    address: yup.string().nullable(),
    phone1: phoneNumber(),
    phone2: phoneNumber(),
    whatsappId: yup.string().nullable(),
    nic: yup.string().nullable(),
    preferredName: yup.string().nullable(),
    fullName: yup.string().nullable(),
    empNo: yup.string().nullable(),
    photoPath: yup.string().nullable(),
    digitalSignPath: yup.string().nullable(),
    isActive: yup.boolean().default(true),
    tenantId: yup.string().nullable(),
    companyId: yup.string().nullable(),
  }).required(),
  detail: yup.array().of(yup.object({
    type: yup.string().required(),
  })).default([]),
});

const deleteSchema = yup.object({
  businessPartnerId: yup.string().nullable(),
  id: yup.string().nullable(),
}).test('bp-id', 'businessPartnerId or id is required', (v) => !!(v.businessPartnerId || v.id));

module.exports = { updateSchema, deleteSchema };
