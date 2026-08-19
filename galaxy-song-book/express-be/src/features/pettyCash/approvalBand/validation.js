const yup = require('yup');
const { optionalNumber } = require('../../../middleware/validation');

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  bandId: yup.string().nullable(),
  docType: yup.string().oneOf(['PCV', 'PIOU']).required('Doc type is required'),
  minAmount: yup.number().required('Min amount is required').min(0),
  maxAmount: optionalNumber(),
  approverFunction: yup.string().required('Approver function is required'),
  sortOrder: yup.number().required('Sort order is required').integer().min(0),
});

const deleteSchema = yup.object({ id: yup.string().required() });

module.exports = { updateSchema, deleteSchema };
