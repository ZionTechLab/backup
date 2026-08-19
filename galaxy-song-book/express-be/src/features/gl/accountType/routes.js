const express = require('express');
const router = express.Router();
const Controller = require('./controller');

router.get('/get-all', (req, res, next) => {
	/*
		#swagger.tags = ['AccountType']
		#swagger.summary = 'Get all account types'
		#swagger.responses[200] = { description: 'Array of account type objects' }
	*/
	return Controller.getAll(req, res, next);
});

router.get('/get', (req, res, next) => {
	/*
		#swagger.tags = ['AccountType']
		#swagger.summary = 'Get a single account type'
		#swagger.parameters['accountType'] = { in: 'query', type: 'string', required: true }
		#swagger.responses[200] = { description: 'Account type object' }
		#swagger.responses[404] = { description: 'Not found' }
	*/
	return Controller.get(req, res, next);
});

router.post('/update', (req, res, next) => {
	/*
		#swagger.tags = ['AccountType']
		#swagger.summary = 'Create or update an account type'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						properties: {
							isUpdate:    { type: 'boolean' },
							accountType: { type: 'string', maxLength: 1 },
							type_name:   { type: 'string' },
							sort_order:  { type: 'integer' }
						},
						example: { isUpdate: false, accountType: 'A', type_name: 'Asset', sort_order: 1 }
					}
				}
			}
		}
		#swagger.responses[201] = { description: 'Account type created/updated' }
	*/
	return Controller.update(req, res, next);
});

router.post('/delete', (req, res, next) => {
	/*
		#swagger.tags = ['AccountType']
		#swagger.summary = 'Delete an account type'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						properties: {
							accountType: { type: 'string', maxLength: 1 }
						},
						required: ['accountType'],
						example: { accountType: 'A' }
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
