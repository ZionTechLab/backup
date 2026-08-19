const express = require('express');
const router = express.Router();
const controller = require('./controller');
const { requirePermission } = require('../../middleware/requirePermission');

const canView = requirePermission('audit-log-view');

router.get('/summary', canView, (req, res, next) => {
  /*
    #swagger.tags = ['AuditHistory']
    #swagger.summary = 'Aggregated audit activity for the current tenant (requires audit-log-view)'
  */
  return controller.getSummary(req, res, next);
});

router.get('/get-all', canView, (req, res, next) => {
  /*
    #swagger.tags = ['AuditHistory']
    #swagger.summary = 'Paginated, filtered audit feed for the current tenant (requires audit-log-view)'
  */
  return controller.getAll(req, res, next);
});

router.get('/get-record', canView, (req, res, next) => {
  /*
    #swagger.tags = ['AuditHistory']
    #swagger.summary = 'Full change history for one record (requires audit-log-view)'
    #swagger.parameters['tableName'] = { in: 'query', type: 'string', required: true }
    #swagger.parameters['recordId'] = { in: 'query', type: 'string', required: true }
  */
  return controller.getRecord(req, res, next);
});

module.exports = router;
