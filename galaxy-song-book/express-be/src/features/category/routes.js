const express = require('express');
const router = express.Router();
const Controller = require('./controller');


router.get('/get-all', (req, res, next) => {
    /*
        #swagger.tags = ['category']
        #swagger.summary = 'Get a list of categories (supports filters/pagination)'
        #swagger.parameters['page'] = { in: 'query', type: 'integer' }
        #swagger.parameters['limit'] = { in: 'query', type: 'integer' }
        #swagger.responses[200] = { description: 'Array of category objects' }
    */
    return Controller.getAll(req, res, next);
});

router.get('/get-ui', (req, res, next) => {
	/*
		#swagger.tags = ['category']
		#swagger.summary = 'Get UI data required for category screen'
		#swagger.responses[200] = { description: 'UI metadata and default values' }
		#swagger.responses[500] = { description: 'Server error' }
	*/
	return Controller.getUi(req, res, next);
});

router.get('/get', (req, res, next) => {
    /*
        #swagger.tags = ['category']
        #swagger.summary = 'Get a single category by query params (e.g., id)'
        #swagger.parameters['id'] = { in: 'query', type: 'integer', required: true, description: 'Category id' }
        #swagger.responses[200] = { description: 'Category object' }
        #swagger.responses[404] = { description: 'Category not found' }
    */
    return Controller.get(req, res, next);
});




router.post('/update', (req, res, next) => {
    /*
        #swagger.tags = ['category']
        #swagger.summary = 'Create or update a category'
        #swagger.requestBody = {
            required: true,
            content: {
                'application/json': {
                    schema: {
                        type: 'object',
                        properties: {
                            id: { type: 'integer' },
                           
                        },
                        example: { customerId: 1, items: [{ description: 'Service', amount: 100.0 }] }
                    }
                }
            }
        }
        #swagger.responses[200] = { description: 'category created/updated successfully' }
        #swagger.responses[400] = { description: 'Validation error' }
    */
    return Controller.update(req, res, next);
});



router.post('/delete', (req, res, next) => {
	/*
		#swagger.tags = ['category']
		#swagger.summary = 'Delete a Category (soft delete)'
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
	return Controller.delete(req, res, next);
});

module.exports = router;
