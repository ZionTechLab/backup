const yup = require('yup');

const dateOnly = yup.string()
  .matches(/^\d{4}-\d{2}-\d{2}$/, 'date must be YYYY-MM-DD');

const reportSchema = yup.object({
  accountId: yup.string()
    .transform(v => (v === '' ? undefined : v))
    .uuid()
    .notRequired(),
  fromDate:  dateOnly.required(),
  toDate:    dateOnly.required()
    .test('after-from', 'toDate must be greater than fromDate', function (value) {
      const { fromDate } = this.parent;
      return !fromDate || !value || value > fromDate;
    }),
});

const trialBalanceSchema = yup.object({
  fromDate:  dateOnly.required(),
  toDate:    dateOnly.required()
    .test('after-from', 'toDate must be greater than fromDate', function (value) {
      const { fromDate } = this.parent;
      return !fromDate || !value || value > fromDate;
    }),
});

const balanceSheetSchema = yup.object({
  asOf: dateOnly.required(),
});

module.exports = { dateOnly, reportSchema, trialBalanceSchema, balanceSheetSchema };
