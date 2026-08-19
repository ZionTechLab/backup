const express = require('express');
const router = express.Router();
const Controller = require('./controller');

router.get('/get-ui', (req, res, next) => {
  /*
    #swagger.tags = ['Vehicle Confirmation']
    #swagger.summary = 'Get UI data required for vehicle confirmation screen'
    #swagger.responses[200] = { description: 'UI metadata and default values' }
    #swagger.responses[500] = { description: 'Server error' }
  */
  return Controller.getUi(req, res, next);
});



router.get('/get-all', Controller.getAll);
router.get('/get', Controller.get);
router.post('/update', Controller.update);
router.post('/delete', Controller.delete);
// router.put('/activitylogs/:id', activityLogController.updateActivityLog);
// router.delete('/activitylogs/:id', activityLogController.deleteActivityLog);

module.exports = router;
