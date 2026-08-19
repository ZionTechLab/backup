const yup = require('yup');

const businessPartnerSchema = yup.object().shape({
  businessPartnerId: yup.string(),
  partnerCode: yup.string().required(),
  partnerName: yup.string().required(),
  contactPerson: yup.string(),
  email: yup.string().email().required(),
  address: yup.string(),
  phone1: yup.string(),
  phone2: yup.string(),
  isCustomer: yup.boolean(),
  isSupplier: yup.boolean(),
  isEmployee: yup.boolean(),
  isActive: yup.boolean(),
  updatedAt: yup.string(),
});

class BusinessPartnerModel {
  constructor(data) {
    const validated = businessPartnerSchema.validateSync(data, { abortEarly: false });
    Object.assign(this, validated);
  }
}

module.exports = BusinessPartnerModel;
