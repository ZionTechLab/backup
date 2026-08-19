const yup = require('yup');

const denominationSchema = yup.object({
  lineNo: yup.number().integer().positive(),
  denomination: yup.number().required('Denomination value is required').moreThan(0),
  count: yup.number().integer().required('Count is required').min(0),
});

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  cashCountId: yup.string().nullable(),
  cashBookId: yup.string().required('Cash book is required'),
  countDate: yup.string().required('Count date is required'),
  reason: yup.string().nullable(),
  photoPath: yup.string().nullable(),
  denominations: yup.array().of(denominationSchema).nullable(),
});

const idSchema = yup.object({ id: yup.string().required() });

module.exports = { denominationSchema, updateSchema, idSchema };
