const express = require('express');
const router = express.Router();
const Controller = require('./controller');

router.get('/get-all', (req, res, next) => {
  /*
    #swagger.tags = ['Currency']
    #swagger.summary = 'Get all currencies'
    #swagger.responses[200] = { description: 'Array of currency objects' }
  */
  return Controller.getAll(req, res, next);
});

router.get('/get', (req, res, next) => {
  /*
    #swagger.tags = ['Currency']
    #swagger.summary = 'Get a single currency'
    #swagger.parameters['currencyCode'] = { in: 'query', type: 'string', required: true }
    #swagger.responses[200] = { description: 'Currency object' }
    #swagger.responses[404] = { description: 'Not found' }
  */
  return Controller.get(req, res, next);
});

router.post('/update', (req, res, next) => {
  /*
    #swagger.tags = ['Currency']
    #swagger.summary = 'Create or update a currency'
    #swagger.requestBody = {
      required: true,
      content: {
        'application/json': {
          schema: {
            type: 'object',
            properties: {
              isUpdate:     { type: 'boolean' },
              currencyCode: { type: 'string' },
              currencyName: { type: 'string' },
              symbol:       { type: 'string' },
              isActive:     { type: 'boolean' }
            },
            required: ['isUpdate', 'currencyCode', 'currencyName']
          }
        }
      }
    }
    #swagger.responses[201] = { description: 'Currency created/updated' }
  */
  return Controller.update(req, res, next);
});

router.post('/delete', (req, res, next) => {
  /*
    #swagger.tags = ['Currency']
    #swagger.summary = 'Deactivate a currency'
    #swagger.requestBody = {
      required: true,
      content: {
        'application/json': {
          schema: {
            type: 'object',
            properties: {
              currencyCode: { type: 'string' }
            },
            required: ['currencyCode']
          }
        }
      }
    }
    #swagger.responses[200] = { description: 'Currency deactivated' }
  */
  return Controller.delete(req, res, next);
});

module.exports = router;
