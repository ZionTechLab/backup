const express = require('express');
const router  = express.Router();
const ctrl    = require('./controller');
const { requirePermission } = require('../../../middleware/requirePermission');

/**
 * @swagger
 * /api/gl/financial-month/get-all:
 *   get:
 *     summary: Get all financial months for the current FY
 *     tags: [GL - Financial Month]
 *     parameters:
 *       - in: query
 *         name: companyId
 *         required: true
 *         schema: { type: string, format: uuid }
 *     responses:
 *       200:
 *         description: List of financial months
 */
router.get('/get-all', ctrl.getAll);

/**
 * @swagger
 * /api/gl/financial-month/update:
 *   post:
 *     summary: Close or reopen a financial month
 *     tags: [GL - Financial Month]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             required: [companyId, tenantId, fnYear, fnMonth, isClosed]
 *             properties:
 *               companyId: { type: string, format: uuid }
 *               tenantId:  { type: string, format: uuid }
 *               fnYear:    { type: integer }
 *               fnMonth:   { type: integer, minimum: 1, maximum: 12 }
 *               isClosed:  { type: boolean }
 *     responses:
 *       200:
 *         description: Updated financial month record
 */
router.post('/update', requirePermission('financial-month-close'), ctrl.update);

module.exports = router;
