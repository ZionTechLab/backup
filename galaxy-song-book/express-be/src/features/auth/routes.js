const express = require('express');
const router = express.Router();
const rateLimit = require('express-rate-limit');
const Controller = require('./controller');
const { authenticate } = require('../../middleware/auth');

// Throttle credential submission to slow brute-force attacks.
// 10 attempts per IP per 15 minutes.
const loginLimiter = rateLimit({
  windowMs: 15 * 60 * 1000,
  max: 10,
  standardHeaders: true,
  legacyHeaders: false,
  message: { error: 'Too Many Requests', message: 'Too many login attempts. Try again later.' },
});


router.get('/auth/init', (req, res, next) => {
	/*
		#swagger.tags = ['Auth']
		#swagger.summary = 'Initialize auth UI/config'
	*/
	return Controller.init(req, res, next);
});




router.post('/auth/login', loginLimiter, (req, res, next) => {
	/*
		#swagger.tags = ['Auth']
		#swagger.summary = 'Login with username and password'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: {
						type: 'object',
						required: ['userName','password'],
						properties: {
							userName: { type: 'string' },
							password: { type: 'string', format: 'password' }
						}
					}
				}
			}
		}
		#swagger.responses[200] = {
			description: 'JWT and refresh token issued',
			content: { 'application/json': { schema: { type: 'object', properties: { token: { type: 'string' }, refreshToken: { type: 'string' }, user: { type: 'object' } } } } }
		}
	*/
	return Controller.login(req, res, next);
});

router.post('/auth/refresh', (req, res, next) => {
	/*
		#swagger.tags = ['Auth']
		#swagger.summary = 'Refresh JWT using refresh token'
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: { type: 'object', required: ['refreshToken'], properties: { refreshToken: { type: 'string' } } }
				}
			}
		}
	*/
	return Controller.refresh(req, res, next);
});

router.post('/auth/logout', authenticate, (req, res, next) => {
	/*
		#swagger.tags = ['Auth']
		#swagger.summary = 'Logout and revoke refresh token(s)'
		#swagger.security = [{ "bearerAuth": [] }]
		#swagger.requestBody = {
			required: false,
			content: {
				'application/json': {
					schema: { type: 'object', properties: { refreshToken: { type: 'string' } } }
				}
			}
		}
	*/
	return Controller.logout(req, res, next);
});

router.post('/auth/change-password', authenticate, (req, res, next) => {
	/*
		#swagger.tags = ['Auth']
		#swagger.summary = 'Change password for authenticated user'
		#swagger.security = [{ "bearerAuth": [] }]
		#swagger.requestBody = {
			required: true,
			content: {
				'application/json': {
					schema: { type: 'object', required: ['currentPassword','newPassword'], properties: { currentPassword: { type: 'string' }, newPassword: { type: 'string' } } }
				}
			}
		}
	*/
	return Controller.changePassword(req, res, next);
});

module.exports = router;
