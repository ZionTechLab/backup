const yup = require('yup');

const exportSchema = yup.object({
  scope: yup.string().oneOf(['tenant', 'module', 'full']).required(),
  moduleCodes: yup.array().of(yup.string()).default([]),
});

// Preview: the zip is the multipart upload itself; scope/moduleCodes arrive
// as form fields alongside it (moduleCodes as a JSON-stringified array).
const restorePreviewSchema = yup.object({
  scope: yup.string().oneOf(['tenant', 'module', 'full']).required(),
  moduleCodes: yup.array().of(yup.string()).default([]),
});

// Apply: references the file already uploaded during preview by its token.
const restoreApplySchema = yup.object({
  token: yup.string().required(),
  scope: yup.string().oneOf(['tenant', 'module', 'full']).required(),
  moduleCodes: yup.array().of(yup.string()).default([]),
});

module.exports = { exportSchema, restorePreviewSchema, restoreApplySchema };
