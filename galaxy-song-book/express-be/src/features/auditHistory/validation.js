const yup = require('yup');

const listSchema = yup.object({
  tableName:  yup.string().trim().optional(),
  changeType: yup.string().trim().max(1).optional(),
  changedBy:  yup.string().trim().optional(),
  dateFrom:   yup.string().trim().optional(),
  dateTo:     yup.string().trim().optional(),
  recordId:   yup.string().trim().optional(),
  page:       yup.number().integer().min(1).optional(),
  pageSize:   yup.number().integer().min(1).max(200).optional(),
});

const recordSchema = yup.object({
  tableName: yup.string().trim().required(),
  recordId:  yup.string().trim().required(),
});

module.exports = { listSchema, recordSchema };
