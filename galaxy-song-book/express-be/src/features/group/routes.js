const express = require('express');
const router = express.Router();
const Controller = require('./controller');

router.get('/get-all', (req, res, next) => {
	/*
		#swagger.tags = ['Group']
		#swagger.summary = 'Get all active groups'
		#swagger.responses[200] = { description: 'Array of group objects' }
	*/
	return Controller.getAll(req, res, next);
});

router.get('/get', (req, res, next) => {
	/*
		#swagger.tags = ['Group']
		#swagger.summary = 'Get a single group'
		#swagger.parameters['groupId'] = { in: 'query', type: 'string', required: true }
		#swagger.responses[200] = { description: 'Group object' }
		#swagger.responses[404] = { description: 'Group not found' }
	*/
	return Controller.get(req, res, next);
});

router.post('/update', (req, res, next) => {
	/*
		#swagger.tags = ['Group']
		#swagger.summary = 'Create or update a group'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						properties: {
							isUpdate:         { type: 'boolean' },
							groupId:          { type: 'string' },
							tenantId:         { type: 'string' },
							groupName:        { type: 'string' },
							baseCurrencyCode: { type: 'string' }
						},
						required: ['tenantId', 'groupName'],
						example: { isUpdate: false, tenantId: 'uuid-here', groupName: 'Asia Pacific', baseCurrencyCode: 'LKR' }
					}
				}
			}
		}
		#swagger.responses[201] = { description: 'Group created/updated' }
	*/
	return Controller.update(req, res, next);
});

router.post('/delete', (req, res, next) => {
	/*
		#swagger.tags = ['Group']
		#swagger.summary = 'Delete a group'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						properties: {
							groupId: { type: 'string' }
						},
						required: ['groupId'],
						example: { groupId: 'uuid-here' }
					}
				}
			}
		}
		#swagger.responses[200] = { description: 'Group deleted' }
		#swagger.responses[404] = { description: 'Group not found' }
	*/
	return Controller.delete(req, res, next);
});

module.exports = router;
