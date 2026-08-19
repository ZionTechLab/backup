const yup = require('yup');
const { optionalNumber } = require('../../../middleware/validation');

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  replenishmentId: yup.string().nullable(),
  cashBookId: yup.string().required('Cash book is required'),
  requestDate: yup.string().required('Request date is required'),
  amountRequested: yup.number().required('Amount is required').moreThan(0, 'Amount must be greater than zero'),
  periodFrom: yup.string().nullable(),
  periodTo: yup.string().nullable(),
  bankTransferRef: yup.string().nullable(),
  bankGlAccountId: yup.string().nullable(),
});

const idSchema = yup.object({ id: yup.string().required() });

module.exports = { updateSchema, idSchema };
