const express = require('express');
const router = express.Router();
const Controller = require('./controller');
const { requirePermission } = require('../../../middleware/requirePermission');

router.get('/get-all', (req, res, next) => {
	/*
		#swagger.tags = ['ChartOfAccounts']
		#swagger.summary = 'Get all chart of accounts'
		#swagger.responses[200] = { description: 'Array of account objects' }
	*/
	return Controller.getAll(req, res, next);
});

router.get('/get', (req, res, next) => {
	/*
		#swagger.tags = ['ChartOfAccounts']
		#swagger.summary = 'Get a single account'
		#swagger.parameters['accountId'] = { in: 'query', type: 'string', required: true }
		#swagger.responses[200] = { description: 'Account object' }
		#swagger.responses[404] = { description: 'Not found' }
	*/
	return Controller.get(req, res, next);
});

router.post('/update', requirePermission('coa-save'), (req, res, next) => {
	/*
		#swagger.tags = ['ChartOfAccounts']
		#swagger.summary = 'Create or update an account'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						properties: {
							isUpdate:        { type: 'boolean' },
							accountId:       { type: 'string', format: 'uuid' },
							tenantId:        { type: 'string', format: 'uuid' },
							groupId:         { type: 'string', format: 'uuid' },
							accountType:     { type: 'string', maxLength: 1 },
							accountCode:     { type: 'string' },
							accountName:     { type: 'string' },
							parentAccountId: { type: 'string', format: 'uuid' },
							level:           { type: 'integer' },
							sortOrder:       { type: 'integer' },
							isActive:        { type: 'boolean' }
						},
						example: { isUpdate: false, accountType: 'A', accountCode: '1000', accountName: 'Cash', level: 1, sortOrder: 1, isActive: true }
					}
				}
			}
		}
		#swagger.responses[201] = { description: 'Account created/updated' }
	*/
	return Controller.update(req, res, next);
});

router.post('/delete', requirePermission('coa-delete'), (req, res, next) => {
	/*
		#swagger.tags = ['ChartOfAccounts']
		#swagger.summary = 'Delete an account'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						properties: {
							accountId: { type: 'string', format: 'uuid' }
						},
						required: ['accountId'],
						example: { accountId: 'uuid-here' }
					}
				}
			}
		}
		#swagger.responses[200] = { description: 'Deleted' }
		#swagger.responses[404] = { description: 'Not found' }
	*/
	return Controller.delete(req, res, next);
});

module.exports = router;
