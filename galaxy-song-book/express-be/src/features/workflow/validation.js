const yup = require('yup');
const { optionalNumber } = require('../../middleware/validation');

const saveSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  levelId: yup.string().nullable(),
  docType: yup.string().required('Transaction type is required'),
  levelNo: yup.number().integer().min(1).required('Level number is required'),
  levelName: yup.string().required('Level name is required'),
  approverFunction: yup.string().required('Approver permission is required'),
  minAmount: optionalNumber(),
  maxAmount: optionalNumber(),
  isActive: yup.boolean().default(true),
});

module.exports = { saveSchema };
