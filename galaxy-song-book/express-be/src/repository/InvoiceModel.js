
const yup = require('yup');
const validate = require('./validate');

const invoiceLineItemSchema = yup.object().shape({
  description: yup.string().required(),
  amount: yup.number().required(),
});

const invoiceSchema = yup.object().shape({
  invoiceNo: yup.string().default('<Auto>'),
  date: yup.string().required(),
  partner: yup.string().required(),
  typeOfVehicle: yup.string().required(),
  preparedBy: yup.string().required(),
  receivedBy: yup.string().required(),
  amount: yup.number().required(),
  advance: yup.number().required(),
  totalAmount: yup.number().required(),
  id: yup.number().integer().default(0),
  lineItems: yup.array().of(invoiceLineItemSchema).required(),
});

class InvoiceModel {
  constructor(data) {
    const validated = validate(invoiceSchema, data);
    Object.assign(this, validated);
  }
}

module.exports = InvoiceModel;
