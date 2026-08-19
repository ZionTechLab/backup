const yup = require('yup');

const updateSchema = yup.object({
  isUpdate:          yup.boolean().required(),
  rateId:            yup.string().nullable().when('isUpdate', { is: true, then: s => s.required() }),
  fromCurrencyCode: yup.string().max(3).required(),
  toCurrencyCode:   yup.string().max(3).required(),
  rateTypeId:        yup.number().integer().required(),
  rate:              yup.number().positive().required(),
  effectiveDate:     yup.date().required(),
});

module.exports = { updateSchema };
