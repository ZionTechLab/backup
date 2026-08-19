const yup = require('yup');

const dateOnly = yup.string()
  .matches(/^\d{4}-\d{2}-\d{2}$/, 'date must be YYYY-MM-DD');

const dateRangeSchema = yup.object({
  fromDate: dateOnly.nullable().optional(),
  toDate: dateOnly.nullable().optional()
    .test('after-from', 'toDate must be greater than fromDate', function (value) {
      const { fromDate } = this.parent;
      if (!fromDate || !value) return true;
      return value > fromDate;
    }),
});

const iouRegisterSchema = dateRangeSchema.shape({
  cashBookId: yup.string().uuid().nullable().optional()
    .transform((value) => (value === '' ? null : value)),
});

const agingSchema = yup.object({
  asOf: dateOnly.nullable().optional(),
});

module.exports = { dateOnly, dateRangeSchema, iouRegisterSchema, agingSchema };
