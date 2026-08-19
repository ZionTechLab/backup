const express = require('express');
const router = express.Router();
const Controller = require('./controller');

router.get('/get-all', (req, res, next) => {
  /*
    #swagger.tags = ['Company']
    #swagger.summary = 'Get all companies'
    #swagger.responses[200] = { description: 'Array of company objects' }
  */
  return Controller.getAll(req, res, next);
});

router.get('/get', (req, res, next) => {
  /*
    #swagger.tags = ['Company']
    #swagger.summary = 'Get a single company'
    #swagger.parameters['companyId'] = { in: 'query', type: 'string', required: true }
    #swagger.responses[200] = { description: 'Company object' }
    #swagger.responses[404] = { description: 'Not found' }
  */
  return Controller.get(req, res, next);
});

router.get('/get-print', (req, res, next) => {
  /*
    #swagger.tags = ['Company']
    #swagger.summary = 'Get company details for invoice print headers'
    #swagger.responses[200] = { description: 'Company print info object' }
    #swagger.responses[404] = { description: 'Not found' }
  */
  return Controller.getPrint(req, res, next);
});

router.get('/get-ui', (req, res, next) => {
  /*
    #swagger.tags = ['Company']
    #swagger.summary = 'Get UI dropdown data (groups, countries, currencies)'
    #swagger.responses[200] = { description: 'UI data object' }
  */
  return Controller.getUi(req, res, next);
});

router.post('/update', (req, res, next) => {
  /*
    #swagger.tags = ['Company']
    #swagger.summary = 'Create or update a company'
    #swagger.requestBody = {
      required: true,
      content: {
        'application/json': {
          schema: {
            type: 'object',
            properties: {
              isUpdate:         { type: 'boolean' },
              companyId:        { type: 'string' },
              companyCode:      { type: 'string' },
              companyName:      { type: 'string' },
              groupId:          { type: 'string' },
              country:          { type: 'integer' },
              baseCurrencyCode: { type: 'string' },
              fiscalYear:       { type: 'integer' },
              period:           { type: 'integer' }
            },
            required: ['isUpdate', 'companyCode', 'companyName', 'groupId', 'baseCurrencyCode']
          }
        }
      }
    }
    #swagger.responses[201] = { description: 'Company created/updated' }
  */
  return Controller.update(req, res, next);
});

router.post('/delete', (req, res, next) => {
  /*
    #swagger.tags = ['Company']
    #swagger.summary = 'Delete a company'
    #swagger.requestBody = {
      required: true,
      content: {
        'application/json': {
          schema: {
            type: 'object',
            properties: { companyId: { type: 'string' } },
            required: ['companyId'],
            example: { companyId: 'uuid-here' }
          }
        }
      }
    }
    #swagger.responses[200] = { description: 'Company deleted' }
    #swagger.responses[404] = { description: 'Not found' }
  */
  return Controller.delete(req, res, next);
});

// --- Company user membership ---

router.get('/users', (req, res, next) => {
  /*
    #swagger.tags = ['Company']
    #swagger.summary = 'List users with access to a company'
    #swagger.parameters['companyId'] = { in: 'query', type: 'string', required: true }
    #swagger.responses[200] = { description: 'Array of user membership objects' }
  */
  return Controller.listUsers(req, res, next);
});

router.post('/users/add', (req, res, next) => {
  /*
    #swagger.tags = ['Company']
    #swagger.summary = 'Grant a user access to a company'
    #swagger.requestBody = { required: true, content: { 'application/json': { schema: { type: 'object', properties: { companyId: { type: 'string' }, userId: { type: 'string' } }, required: ['companyId', 'userId'] } } } }
    #swagger.responses[201] = { description: 'Membership row created' }
  */
  return Controller.addUser(req, res, next);
});

router.post('/users/remove', (req, res, next) => {
  /*
    #swagger.tags = ['Company']
    #swagger.summary = 'Remove a user from a company (soft-delete)'
    #swagger.requestBody = { required: true, content: { 'application/json': { schema: { type: 'object', properties: { id: { type: 'integer' } }, required: ['id'] } } } }
    #swagger.responses[200] = { description: 'Membership removed' }
  */
  return Controller.removeUser(req, res, next);
});

router.post('/users/set-default', (req, res, next) => {
  /*
    #swagger.tags = ['Company']
    #swagger.summary = 'Set a company as default for a user'
    #swagger.requestBody = { required: true, content: { 'application/json': { schema: { type: 'object', properties: { id: { type: 'integer' } }, required: ['id'] } } } }
    #swagger.responses[201] = { description: 'Default company updated' }
  */
  return Controller.setDefault(req, res, next);
});

router.get('/users/count-other', (req, res, next) => {
  /*
    #swagger.tags = ['Company']
    #swagger.summary = 'Count other active companies for the user linked to a membership'
    #swagger.parameters['id'] = { in: 'query', type: 'integer', required: true }
    #swagger.responses[200] = { description: '{ count: number }' }
  */
  return Controller.countOtherCompanies(req, res, next);
});

// Self-service: current user sets their own default company
router.post('/users/set-my-default', (req, res, next) => {
  /*
    #swagger.tags = ['Company']
    #swagger.summary = 'Set own default company'
    #swagger.requestBody = { required: true, content: { 'application/json': { schema: { type: 'object', properties: { companyId: { type: 'string' } }, required: ['companyId'] } } } }
    #swagger.responses[201] = { description: 'Default company updated' }
  */
  return Controller.setMyDefault(req, res, next);
});

module.exports = router;
