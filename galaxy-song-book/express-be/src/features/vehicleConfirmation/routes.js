const express = require('express');
const router = express.Router();
const Controller = require('./controller');
const { upload, withMulterErrors } = require('../../middleware/upload');

// Vehicle images upload through the shared upload config. Field name 'image'.
const uploadMultipleMiddleware = withMulterErrors(upload.array('image'));

router.get('/get-ui', (req, res, next) => {
  /*
    #swagger.tags = ['Vehicle Confirmation']
    #swagger.summary = 'Get UI data required for vehicle confirmation screen'
    #swagger.responses[200] = { description: 'UI metadata and default values' }
    #swagger.responses[500] = { description: 'Server error' }
  */
  return Controller.getUi(req, res, next);
});

router.get('/get-all', (req, res, next) => {
  /*
    #swagger.tags = ['Vehicle Confirmation']
    #swagger.summary = 'Get a list of vehicle confirmations (supports filters/pagination)'
    #swagger.parameters['page'] = { in: 'query', type: 'integer' }
    #swagger.parameters['limit'] = { in: 'query', type: 'integer' }
    #swagger.responses[200] = { description: 'Array of vehicle confirmation objects' }
  */
  return Controller.getAll(req, res, next);
});

router.get('/get', (req, res, next) => {
  /*
    #swagger.tags = ['Vehicle Confirmation']
    #swagger.summary = 'Get a single vehicle confirmation by query params (e.g., id)'
    #swagger.parameters['id'] = { in: 'query', type: 'integer', required: true, description: 'Vehicle confirmation id' }
    #swagger.responses[200] = { description: 'Vehicle confirmation object' }
    #swagger.responses[404] = { description: 'Vehicle confirmation not found' }
  */
  return Controller.get(req, res, next);
});

router.post('/update', (req, res, next) => {
  /*
    #swagger.tags = ['Vehicle Confirmation']
    #swagger.summary = 'Create or update a vehicle confirmation'
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
    #swagger.responses[200] = { description: 'Vehicle Confirmation created/updated successfully' }
    #swagger.responses[400] = { description: 'Validation error' }
  */
  return Controller.update(req, res, next);
});

router.post('/delete', (req, res, next) => {
	/*
		#swagger.tags = ['Vehicle Confirmation']
		#swagger.summary = 'Delete a vehicle confirmation (soft/hard depends on implementation)'
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
		#swagger.responses[200] = { description: 'Vehicle confirmation deleted' }
		#swagger.responses[404] = { description: 'Vehicle confirmation not found' }
	*/
	return Controller.delete(req, res, next);
});

router.post('/images',
  /*
    #swagger.tags = ['Vehicle Confirmation']
    #swagger.summary = 'Upload one or more images for a vehicle confirmation record'
    #swagger.consumes = ['multipart/form-data']
    #swagger.parameters['images'] = {
      in: 'formData',
      name: 'image',
      type: 'file',
      description: 'One or more image files. Use multipart/form-data with field name "image" and send as an array.',
      required: true
    }
    #swagger.parameters['vehicleConfirmationId'] = {
      in: 'formData',
      name: 'vehicleConfirmationId',
      type: 'integer',
      description: 'Optional id of the vehicle confirmation to attach these images to'
    }
    #swagger.responses[200] = { description: 'Files uploaded successfully', schema: { type: 'object', properties: { files: { type: 'array', items: { type: 'object', properties: { originalname: { type: 'string' }, filename: { type: 'string' }, size: { type: 'integer' }, path: { type: 'string' } } } } } } }
    #swagger.responses[400] = { description: 'Bad request or upload error' }
    #swagger.responses[413] = { description: 'File too large' }
  */
  uploadMultipleMiddleware,
  Controller.uploadImage
);

module.exports = router;
