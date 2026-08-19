const yup = require('yup');
const { optionalNumber } = require('../../middleware/validation');

const updateSchema = yup.object({
  isUpdate: yup.boolean().default(false),
  header: yup.object({
    id: optionalNumber(),
    txnDate: yup.string().nullable(),
    partner: yup.string().nullable(),
    status: yup.number().required(),
    ref1: yup.string().nullable(),
    ref2: yup.string().nullable(),
    ref3: yup.string().nullable(),
    description: yup.string().nullable(),
    remarks: yup.string().nullable(),
    jobTags: yup.array().of(yup.object({
      id: optionalNumber(),
      value: yup.boolean().default(false),
    })).default([]),
  }).required(),
});

const deleteSchema = yup.object({
  id: optionalNumber(),
  JobId: optionalNumber(),
}).test('id-or-jobid', 'id or JobId is required', (v) => v.id != null || v.JobId != null);

module.exports = { updateSchema, deleteSchema };
