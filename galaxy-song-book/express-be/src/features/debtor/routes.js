const express = require('express');
const router = express.Router();
const Controller = require('./controller');

router.get('/get-ui', (req, res, next) => {
	/*
		#swagger.tags = ['Debtor']
		#swagger.summary = 'Get UI data required for debtor invoice screen'
		#swagger.responses[200] = { description: 'UI metadata and default values' }
		#swagger.responses[500] = { description: 'Server error' }
	*/
	return Controller.getUi(req, res, next);
});

router.get('/get-all', (req, res, next) => {
	/*
		#swagger.tags = ['Debtor']
		#swagger.summary = 'Get a list of debtor invoices (supports filters/pagination)'
		#swagger.parameters['page'] = { in: 'query', type: 'integer' }
		#swagger.parameters['limit'] = { in: 'query', type: 'integer' }
		#swagger.responses[200] = { description: 'Array of invoice objects' }
	*/
	return Controller.getAll(req, res, next);
});

router.get('/get', (req, res, next) => {
	/*
		#swagger.tags = ['Debtor']
		#swagger.summary = 'Get a single debtor invoice by query params (e.g., id)'
		#swagger.parameters['id'] = { in: 'query', type: 'integer', required: true, description: 'Invoice id' }
		#swagger.responses[200] = { description: 'Invoice object' }
		#swagger.responses[404] = { description: 'Invoice not found' }
	*/
	return Controller.get(req, res, next);
});

router.post('/update', (req, res, next) => {
	/*
		#swagger.tags = ['Debtor']
		#swagger.summary = 'Create or update a debtor invoice'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						properties: {
							id: { type: 'integer' },
							customerId: { type: 'integer' },
							items: { type: 'array', items: { type: 'object' } }
						},
						example: { customerId: 1, items: [{ description: 'Service', amount: 100.0 }] }
					}
				}
			}
		}
		#swagger.responses[200] = { description: 'Invoice created/updated successfully' }
		#swagger.responses[400] = { description: 'Validation error' }
	*/
	return Controller.update(req, res, next);
});

router.post('/update-advance', (req, res, next) => {
	/*
		#swagger.tags = ['Debtor']
		#swagger.summary = 'Update an advance payment for an invoice'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						properties: { invoiceId: { type: 'integer' }, amount: { type: 'number' } },
						required: ['invoiceId','amount'],
						example: { invoiceId: 123, amount: 50.0 }
					}
				}
			}
		}
		#swagger.responses[200] = { description: 'Advance updated' }
		#swagger.responses[400] = { description: 'Validation error' }
	*/
	return Controller.updateAdvance(req, res, next);
});

router.post('/delete', (req, res, next) => {
	/*
		#swagger.tags = ['Debtor']
		#swagger.summary = 'Delete a debtor invoice (soft/hard depends on implementation)'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						properties: { id: { type: 'integer' } },
						required: ['id'],
						example: { id: 123 }
					}
				}
			}
		}
		#swagger.responses[200] = { description: 'Invoice deleted' }
		#swagger.responses[404] = { description: 'Invoice not found' }
	*/
	return Controller.delete(req, res, next);
});

router.post('/delete-advance', (req, res, next) => {
	/*
		#swagger.tags = ['Debtor']
		#swagger.summary = 'Delete an advance payment from an invoice'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						properties: { advanceId: { type: 'integer' } },
						required: ['advanceId'],
						example: { advanceId: 456 }
					}
				}
			}
		}
		#swagger.responses[200] = { description: 'Advance deleted' }
		#swagger.responses[404] = { description: 'Advance not found' }
	*/
	return Controller.deleteAdvance(req, res, next);
});

router.get('/get-print', (req, res, next) => {
	/*
		#swagger.tags = ['Debtor']
		#swagger.summary = 'Get printable representation of an invoice'
		#swagger.parameters['id'] = { in: 'query', type: 'integer', required: true }
		#swagger.responses[200] = { description: 'Printable invoice (html/pdf binary or html string)' }
		#swagger.responses[404] = { description: 'Invoice not found' }
	*/
	return Controller.getPrint(req, res, next);
});

module.exports = router;