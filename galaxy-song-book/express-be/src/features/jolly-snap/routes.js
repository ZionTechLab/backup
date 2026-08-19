const express = require('express');
const router = express.Router();
const Controller = require('./controller');

router.get('/get-all', (req, res, next) => {
  /*
      #swagger.tags = ['Jolly Snap']
      #swagger.summary = 'List all registrations'
  */
  return Controller.getAll(req, res, next);
});
router.get('/get-ui', (req, res, next) => {
  /*
    #swagger.tags = ['Jolly Snap']
    #swagger.summary = 'Get UI metadata for Jolly Snap screen'
    #swagger.description = 'Returns lookup lists (service types, statuses, assignees, etc.) currently placeholders.'
    #swagger.responses[200] = { description: 'Metadata object' }
  */
  return Controller.getUi(req, res, next);
});
router.get('/get', (req, res, next) => {
  /*
      #swagger.tags = ['Jolly Snap']
      #swagger.summary = 'Get a registration by ID'
      #swagger.parameters['id'] = { in: 'query', required: false, schema: { type: 'integer' } }
  */
  return Controller.get(req, res, next);
});

router.post('/update', (req, res, next) => {
  /*
      #swagger.tags = ['Jolly Snap']
      #swagger.summary = 'Create or update a registration'
      #swagger.requestBody = {
        required: true,
        content: {
          'application/json': {
            schema: {
              type: 'object',
              required: ['header'],
              properties: {
                header: {
                    type: 'object',
                    properties: {
                        name: { type: 'string' },
                        email: { type: 'string' },
                        whatsAppNo: { type: 'string' }
                    }
                }
              }
            }
          }
        }
      }
    */
  return Controller.update(req, res, next);
});

router.post('/delete', (req, res, next) => {
  /*
      #swagger.tags = ['Jolly Snap']
      #swagger.summary = 'Soft-delete a registration'
      #swagger.requestBody = { required: true, content: { 'application/json': { schema: { type: 'object', properties: { id: { type: 'integer' } } } } } }
  */
  return Controller.delete(req, res, next);
});

module.exports = router;
