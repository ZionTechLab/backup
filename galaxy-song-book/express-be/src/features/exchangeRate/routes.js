const express = require('express');
const router = express.Router();
const Controller = require('./controller');

router.get('/get-all', (req, res, next) => {
  /*
    #swagger.tags = ['ExchangeRate']
    #swagger.summary = 'Get all exchange rates'
    #swagger.responses[200] = { description: 'Array of exchange rate objects' }
  */
  return Controller.getAll(req, res, next);
});

router.get('/get', (req, res, next) => {
  /*
    #swagger.tags = ['ExchangeRate']
    #swagger.summary = 'Get a single exchange rate'
    #swagger.parameters['rateId'] = { in: 'query', type: 'string', required: true }
    #swagger.responses[200] = { description: 'Exchange rate object' }
    #swagger.responses[404] = { description: 'Not found' }
  */
  return Controller.get(req, res, next);
});

router.get('/get-ui', (req, res, next) => {
  /*
    #swagger.tags = ['ExchangeRate']
    #swagger.summary = 'Get UI dropdown data (currencies, rate types)'
    #swagger.responses[200] = { description: 'UI data object' }
  */
  return Controller.getUi(req, res, next);
});

router.post('/update', (req, res, next) => {
  /*
    #swagger.tags = ['ExchangeRate']
    #swagger.summary = 'Create or update an exchange rate'
    #swagger.requestBody = {
      required: true,
      content: {
        'application/json': {
          schema: {
            type: 'object',
            properties: {
              isUpdate:        { type: 'boolean' },
              rateId:          { type: 'string' },
              fromCurrencyCode: { type: 'string' },
              toCurrencyCode:   { type: 'string' },
              rateTypeId:      { type: 'integer' },
              rate:            { type: 'number' },
              effectiveDate:   { type: 'string', format: 'date' }
            },
            required: ['isUpdate', 'fromCurrencyCode', 'toCurrencyCode', 'rateTypeId', 'rate', 'effectiveDate']
          }
        }
      }
    }
    #swagger.responses[201] = { description: 'Exchange rate created/updated' }
  */
  return Controller.update(req, res, next);
});

module.exports = router;
