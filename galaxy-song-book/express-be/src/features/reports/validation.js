const yup = require('yup');

const reportSchema = yup.object({
  txnType: yup.string().required(),
  fromDate: yup.string().required(),
  toDate: yup.string().required(),
  partner: yup.string().nullable(),
  ref1: yup.string().nullable(),
});

module.exports = { reportSchema };
