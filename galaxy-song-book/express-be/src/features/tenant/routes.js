const express = require('express');
const router = express.Router();
const Controller = require('./controller');
const { requirePermission } = require('../../middleware/requirePermission');

router.get('/get-all', (req, res, next) => {
	/*
		#swagger.tags = ['Tenant']
		#swagger.summary = 'Get all tenants'
		#swagger.responses[200] = { description: 'Array of tenant objects' }
	*/
	return Controller.getAll(req, res, next);
});

router.get('/get', (req, res, next) => {
	/*
		#swagger.tags = ['Tenant']
		#swagger.summary = 'Get a single tenant'
		#swagger.parameters['tenantId'] = { in: 'query', type: 'string', required: true }
		#swagger.responses[200] = { description: 'Tenant object' }
		#swagger.responses[404] = { description: 'Tenant not found' }
	*/
	return Controller.get(req, res, next);
});

router.post('/update', (req, res, next) => {
	/*
		#swagger.tags = ['Tenant']
		#swagger.summary = 'Create or update a tenant'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						properties: {
							isUpdate:       { type: 'boolean' },
							tenantId:       { type: 'string' },
							tenantName:     { type: 'string' },
							legalName:      { type: 'string' },
							status:         { type: 'string' },
							email:          { type: 'string' },
							phone:          { type: 'string' },
							address_line1:  { type: 'string' },
							address_line2:  { type: 'string' },
							city:           { type: 'string' },
							state_province: { type: 'string' },
							postal_code:    { type: 'string' },
							country:        { type: 'string' }
						},
						required: ['tenantName'],
						example: { isUpdate: false, tenantName: 'Acme Corp', legalName: 'Acme Corporation Ltd', status: 'active', email: 'admin@acme.com' }
					}
				}
			}
		}
		#swagger.responses[201] = { description: 'Tenant created/updated' }
	*/
	return Controller.update(req, res, next);
});

router.post('/delete', (req, res, next) => {
	/*
		#swagger.tags = ['Tenant']
		#swagger.summary = 'Delete a tenant'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						properties: {
							tenantId: { type: 'string' }
						},
						required: ['tenantId'],
						example: { tenantId: 'uuid-here' }
					}
				}
			}
		}
		#swagger.responses[200] = { description: 'Tenant deleted' }
		#swagger.responses[404] = { description: 'Tenant not found' }
	*/
	return Controller.delete(req, res, next);
});

router.get('/settings', requirePermission('tenant-settings-view'), (req, res, next) => {
	/*
		#swagger.tags = ['Tenant']
		#swagger.summary = 'Get tenant-level settings (theme defaults, table/behavior flags)'
		#swagger.parameters['tenantId'] = { in: 'query', type: 'string', required: true }
		#swagger.responses[200] = { description: 'Tenant settings, merged with defaults' }
	*/
	return Controller.getSettings(req, res, next);
});

router.post('/settings/update', requirePermission('tenant-settings-update'), (req, res, next) => {
	/*
		#swagger.tags = ['Tenant']
		#swagger.summary = 'Update tenant-level settings'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						properties: {
							tenantId: { type: 'string' },
							settings: {
								type: 'object',
								properties: {
									DISPLAY_DATE_FORMAT:       { type: 'string' },
									returnToListAfterSave:     { type: 'boolean' },
									showThemeControls:         { type: 'boolean' },
									dataTableColumnVisibility: { type: 'boolean' },
									actionColumnsRightEnd:     { type: 'boolean' },
									dataTableCSVExport:        { type: 'boolean' },
									selectSearch:               { type: 'boolean' },
									theme:                       { type: 'string' },
									colorTheme:                  { type: 'string' },
									uiTheme:                     { type: 'string' }
								}
							}
						},
						required: ['tenantId', 'settings'],
						example: { tenantId: 'uuid-here', settings: { theme: 'dark', dataTableCSVExport: true } }
					}
				}
			}
		}
		#swagger.responses[201] = { description: 'Updated tenant settings' }
	*/
	return Controller.updateSettings(req, res, next);
});

// --- Tenant user membership ---

router.get('/users', requirePermission('tenant-save'), (req, res, next) => {
	/*
		#swagger.tags = ['Tenant']
		#swagger.summary = 'List users with access to a tenant'
		#swagger.parameters['tenantId'] = { in: 'query', type: 'string', required: true }
		#swagger.responses[200] = { description: 'Array of user membership objects' }
	*/
	return Controller.listUsers(req, res, next);
});

router.post('/users/add', requirePermission('tenant-save'), (req, res, next) => {
	/*
		#swagger.tags = ['Tenant']
		#swagger.summary = 'Grant a user access to a tenant'
		#swagger.requestBody = { required: true, content: { 'application/json': { schema: { type: 'object', properties: { tenantId: { type: 'string' }, userId: { type: 'string' } }, required: ['tenantId', 'userId'] } } } }
		#swagger.responses[201] = { description: 'Membership row created' }
	*/
	return Controller.addUser(req, res, next);
});

router.post('/users/remove', requirePermission('tenant-save'), (req, res, next) => {
	/*
		#swagger.tags = ['Tenant']
		#swagger.summary = 'Remove a user from a tenant (soft-delete)'
		#swagger.requestBody = { required: true, content: { 'application/json': { schema: { type: 'object', properties: { id: { type: 'integer' } }, required: ['id'] } } } }
		#swagger.responses[200] = { description: 'Membership removed' }
	*/
	return Controller.removeUser(req, res, next);
});

router.post('/users/set-default', requirePermission('tenant-save'), (req, res, next) => {
	/*
		#swagger.tags = ['Tenant']
		#swagger.summary = 'Set a tenant as default for a user'
		#swagger.requestBody = { required: true, content: { 'application/json': { schema: { type: 'object', properties: { id: { type: 'integer' } }, required: ['id'] } } } }
		#swagger.responses[201] = { description: 'Default tenant updated' }
	*/
	return Controller.setDefault(req, res, next);
});

router.get('/users/count-other', requirePermission('tenant-save'), (req, res, next) => {
	/*
		#swagger.tags = ['Tenant']
		#swagger.summary = 'Count other active tenants for the user linked to a membership'
		#swagger.parameters['id'] = { in: 'query', type: 'integer', required: true }
		#swagger.responses[200] = { description: '{ count: number }' }
	*/
	return Controller.countOtherTenants(req, res, next);
});

// Self-service: current user sets their own default tenant (no admin gate)
router.post('/users/set-my-default', (req, res, next) => {
	/*
		#swagger.tags = ['Tenant']
		#swagger.summary = 'Set own default tenant'
		#swagger.requestBody = { required: true, content: { 'application/json': { schema: { type: 'object', properties: { tenantId: { type: 'string' } }, required: ['tenantId'] } } } }
		#swagger.responses[201] = { description: 'Default tenant updated' }
	*/
	return Controller.setMyDefault(req, res, next);
});

module.exports = router;
