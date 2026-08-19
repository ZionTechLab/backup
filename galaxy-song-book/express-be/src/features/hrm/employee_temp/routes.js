const express = require('express');
const router = express.Router();
const userController = require('./controller');
const { authorizeRoles } = require('../../../middleware/auth');

router.get('/get-all', (req, res, next) => {

	/*
		#swagger.tags = ['Users']
		#swagger.summary = 'List users'
		#swagger.security = [{ "bearerAuth": [] }]
	*/
	return userController.getAll(req, res, next);
});
router.get('/get-ui', (req, res, next) => {
	/*
		#swagger.tags = ['Users']
		#swagger.summary = 'Get UI metadata for users'
	*/
	return userController.getUi(req, res, next);
});
router.get('/get', (req, res, next) => {
	/*
		#swagger.tags = ['Users']
		#swagger.summary = 'Get a user by filters'
		#swagger.parameters['id'] = { in: 'query', required: false, schema: { type: 'integer' } }
		#swagger.parameters['userName'] = { in: 'query', required: false, schema: { type: 'string' } }
	*/
	return userController.get(req, res, next);
});
router.post('/update', authorizeRoles(1, 'Admin'), (req, res, next) => {
	/*
		#swagger.tags = ['Users']
		#swagger.summary = 'Create/update user (soft-update)'
		#swagger.security = [{ "bearerAuth": [] }]
		#swagger.requestBody = {
			required: true,
			content: { 'application/json': { schema: { type: 'object' } } }
		}
	*/

	return userController.update(req, res, next);
});
router.post('/delete', authorizeRoles(1, 'Admin'), (req, res, next) => {
	/*
		#swagger.tags = ['Users']
		#swagger.summary = 'Soft-delete user'
		#swagger.security = [{ "bearerAuth": [] }]
		#swagger.requestBody = { required: true, content: { 'application/json': { schema: { type: 'object', properties: { id: { type: 'integer' } } } } } }
	*/
	return userController.delete(req, res, next);
});

module.exports = router;
