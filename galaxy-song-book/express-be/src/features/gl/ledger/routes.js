const express = require('express');
const router = express.Router();
const Controller = require('./controller');
const { requirePermission } = require('../../../middleware/requirePermission');

router.get('/get-all', (req, res, next) => {
	/*
		#swagger.tags = ['Ledger']
		#swagger.summary = 'Get all ledger transaction headers'
		#swagger.responses[200] = { description: 'Array of transaction headers' }
	*/
	return Controller.getAll(req, res, next);
});

router.get('/get', (req, res, next) => {
	/*
		#swagger.tags = ['Ledger']
		#swagger.summary = 'Get a single ledger transaction with detail lines'
		#swagger.parameters['transactionId'] = { in: 'query', type: 'string', required: true }
		#swagger.responses[200] = { description: 'Transaction header with details array' }
		#swagger.responses[404] = { description: 'Not found' }
	*/
	return Controller.get(req, res, next);
});

router.post('/update', requirePermission('journal-save'), (req, res, next) => {
	/*
		#swagger.tags = ['Ledger']
		#swagger.summary = 'Create or update a ledger transaction (header + details)'
		#swagger.description = 'Validates that sum of debits equals sum of credits in base currency before saving.'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						properties: {
							isUpdate:      { type: 'boolean' },
							transactionId: { type: 'string', format: 'uuid' },
							tenantId:      { type: 'string', format: 'uuid' },
							companyId:     { type: 'string', format: 'uuid' },
							txnYear:       { type: 'integer' },
							txnMonth:      { type: 'integer' },
							docType:       { type: 'string' },
							txnType:       { type: 'string' },
							txnDate:       { type: 'string', format: 'date' },
							reference:     { type: 'string' },
							description:   { type: 'string' },
							status:        { type: 'string', enum: ['Draft', 'Posted', 'Void'] },
							details: {
								type: 'array',
								items: {
									type: 'object',
									properties: {
										accountId:    { type: 'string', format: 'uuid' },
										debitAmount:  { type: 'number' },
										creditAmount: { type: 'number' },
										currencyCode: { type: 'string' },
										exchangeRate: { type: 'number' },
										rateTypeId:   { type: 'integer' },
										description:  { type: 'string' }
									}
								}
							}
						},
						example: {
							isUpdate: false,
							txnYear: 2026,
							txnMonth: 5,
							docType: 'BP',
							txnType: 'BP',
							txnDate: '2026-05-20',
							reference: 'JV-001',
							description: 'Cash sale',
							status: 'Draft',
							details: [
								{ accountId: 'uuid-1', debitAmount: 1000, creditAmount: 0, currencyCode: 'LKR', exchangeRate: 1, description: 'Cash in' },
								{ accountId: 'uuid-2', debitAmount: 0, creditAmount: 1000, currencyCode: 'LKR', exchangeRate: 1, description: 'Sales' }
							]
						}
					}
				}
			}
		}
		#swagger.responses[201] = { description: 'Transaction created/updated' }
		#swagger.responses[400] = { description: 'Debit/credit out of balance or validation error' }
		#swagger.responses[404] = { description: 'Transaction not found (update only)' }
	*/
	return Controller.update(req, res, next);
});

router.get('/accounts', (req, res, next) => {
	/*
		#swagger.tags = ['Ledger']
		#swagger.summary = 'Get chart of accounts list for report dropdown'
		#swagger.responses[200] = { description: 'Array of active accounts' }
	*/
	return Controller.getAccounts(req, res, next);
});

router.post('/get-report', (req, res, next) => {
	/*
		#swagger.tags = ['Ledger']
		#swagger.summary = 'Get General Ledger report for a single account'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						required: ['accountId', 'fromDate', 'toDate'],
						properties: {
							accountId: { type: 'string', format: 'uuid' },
							fromDate:  { type: 'string', format: 'date', example: '2026-01-01' },
							toDate:    { type: 'string', format: 'date', example: '2026-05-31' }
						}
					}
				}
			}
		}
		#swagger.responses[200] = { description: 'GL report with opening balance, lines, and summary totals' }
	*/
	return Controller.getReport(req, res, next);
});

router.post('/delete', requirePermission('journal-delete'), (req, res, next) => {
	/*
		#swagger.tags = ['Ledger']
		#swagger.summary = 'Void a ledger transaction (sets status to Void)'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						properties: { transactionId: { type: 'string', format: 'uuid' } },
						required: ['transactionId'],
						example: { transactionId: 'uuid-here' }
					}
				}
			}
		}
		#swagger.responses[200] = { description: 'Voided' }
		#swagger.responses[404] = { description: 'Not found' }
	*/
	return Controller.delete(req, res, next);
});

module.exports = router;
