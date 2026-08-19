const express = require('express');
const router = express.Router();
const Controller = require('./controller');

// Base tag: Job
router.get('/get-ui', (req, res, next) => {
	/*
		#swagger.tags = ['Job']
		#swagger.summary = 'Get UI metadata for Job screen'
		#swagger.description = 'Returns lookup lists (service types, statuses, assignees, etc.) currently placeholders.'
		#swagger.responses[200] = { description: 'Metadata object' }
	*/
	return Controller.getUi(req, res, next);
});

router.get('/get-all', (req, res, next) => {
	/*
		#swagger.tags = ['Job']
		#swagger.summary = 'List jobs'
		#swagger.parameters['status'] = { in: 'query', type: 'integer', required: false }
		#swagger.parameters['assigned_to'] = { in: 'query', type: 'integer', required: false }
		#swagger.parameters['partner'] = { in: 'query', type: 'integer', required: false }
		#swagger.responses[200] = { description: 'Array of job headers' }
	*/
	return Controller.getAll(req, res, next);
});

router.get('/get', (req, res, next) => {
	/*
		#swagger.tags = ['Job']
		#swagger.summary = 'Get a single job'
		#swagger.parameters['JobId'] = { in: 'query', type: 'integer', required: true, description: 'Job identifier' }
		#swagger.responses[200] = { description: 'Job with activities & tags' }
		#swagger.responses[404] = { description: 'Job not found' }
	*/
	return Controller.get(req, res, next);
});

router.get('/getPrint', (req, res, next) => {
	/*
		#swagger.tags = ['Job']
		#swagger.summary = 'Get printable representation of a job'
		#swagger.parameters['JobId'] = { in: 'query', type: 'integer', required: true }
		#swagger.responses[200] = { description: 'Printable job object' }
		#swagger.responses[404] = { description: 'Job not found' }
	*/
	return Controller.getPrint(req, res, next);
});

router.post('/update', (req, res, next) => {
	/*
		#swagger.tags = ['Job']
		#swagger.summary = 'Create or update a job'
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
									JobId: { type: 'integer' },
									txnDate: { type: 'string', format: 'date' },
									partner: { type: 'integer' },
									client_project: { type: 'string' },
									service_type: { type: 'integer' },
									assigned_to: { type: 'integer' },
									status: { type: 'integer' },
									due_date: { type: 'string', format: 'date' },
									ref1: { type: 'string' },
									ref2: { type: 'string' },
									ref3: { type: 'string' },
									description: { type: 'string' },
									remarks: { type: 'string' },
									active: { type: 'boolean' }
								},
								required: ['txnDate','active']
							},
							activities: {
								type: 'array',
								items: {
									type: 'object',
									properties: {
										activityDate: { type: 'string', format: 'date' },
										description: { type: 'string' },
										remarks: { type: 'string' }
									}
								}
							},
							tags: { type: 'array', items: { type: 'integer' } }
						},
						example: {
							isUpdate: false,
							header: { txnDate: '2025-09-16', partner: 10, client_project: 'Alpha', service_type: 2, assigned_to: 5, status: 1, due_date: '2025-09-30', active: true },
							activities: [ { activityDate: '2025-09-16', description: 'Kickoff' } ],
							tags: [10,11]
						}
					}
				}
			}
		}
		#swagger.responses[201] = { description: 'Job saved' }
		#swagger.responses[400] = { description: 'Validation error (if added later)' }
	*/
	return Controller.update(req, res, next);
});

router.post('/delete', (req, res, next) => {
	/*
		#swagger.tags = ['Job']
		#swagger.summary = 'Delete (soft) a job'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: { type: 'object', properties: { JobId: { type: 'integer' } }, required: ['JobId'], example: { JobId: 123 } }
				}
			}
		}
		#swagger.responses[200] = { description: 'Deletion success status' }
		#swagger.responses[404] = { description: 'Job not found (if validation added later)' }
	*/
	return Controller.delete(req, res, next);
});

module.exports = router;
