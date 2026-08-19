const express = require('express');
const router = express.Router();
const controller = require('./controller');

router.get('/get-ui', (req, res, next) => {
	/*
		#swagger.tags = ['Item']
		#swagger.summary = 'Get UI metadata required for Item master screen'
		#swagger.responses[200] = { description: 'UI metadata' }
	*/
	return controller.getUi(req, res, next);
});

router.get('/get-all', (req, res, next) => {
	/*
		#swagger.tags = ['Item']
		#swagger.summary = 'Get all items (master list)'
		#swagger.responses[200] = { description: 'Array of items' }
	*/
	return controller.getAll(req, res, next);
});

router.get('/get', (req, res, next) => {
	/*
		#swagger.tags = ['Item']
		#swagger.summary = 'Get a single item by id'
		#swagger.parameters['id'] = { in: 'query', type: 'integer', required: true }
		#swagger.responses[200] = { description: 'Item object' }
		#swagger.responses[404] = { description: 'Not found' }
	*/
	return controller.get(req, res, next);
});

router.get('/get-print', (req, res, next) => {
	/*
		#swagger.tags = ['Item']
		#swagger.summary = 'Get printable representation of an item'
		#swagger.parameters['id'] = { in: 'query', type: 'integer', required: true }
		#swagger.responses[200] = { description: 'Printable item (html or details)' }
		#swagger.responses[404] = { description: 'Not found' }
	*/
	return controller.getPrint(req, res, next);
});

router.post('/update', (req, res, next) => {
	/*
		#swagger.tags = ['Item']
		#swagger.summary = 'Create or update an item'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						properties: {
							isUpdate: { type: 'boolean' },
							header: {
								type: 'object',
								properties: {
									tenantId: { type: 'integer' },
									companyId: { type: 'integer' },
									id: { type: 'integer' },
									itemCode: { type: 'integer' },
									itemName: { type: 'string' },
									description: { type: 'string' },
									uom: { type: 'string' },
									brand: { type: 'string' },
									reorderLevel: { type: 'integer' },
									costPrice: { type: 'number' },
									sellingPrice: { type: 'number' },
									active: { type: 'boolean' }
								}
							}
						}
					}
				}
			}
		}
		#swagger.responses[200] = { description: 'Item created/updated' }
		#swagger.responses[400] = { description: 'Validation error' }
	*/
	return controller.update(req, res, next);
});

router.post('/delete', (req, res, next) => {
	/*
		#swagger.tags = ['Item']
		#swagger.summary = 'Delete an item (soft delete)'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: { type: 'object', properties: { id: { type: 'integer' } }, required: ['id'] }
				}
			}
		}
		#swagger.responses[200] = { description: 'Deleted' }
		#swagger.responses[404] = { description: 'Not found' }
	*/
	return controller.delete(req, res, next);
});

module.exports = router;
