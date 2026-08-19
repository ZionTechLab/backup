const express = require('express');
const router = express.Router();
const ctrl = require('./controller');

/**
 * @swagger
 * tags:
 *   name: Petty Cash - Reports
 */

/**
 * @swagger
 * /api/petty-cash/reports/iou-register:
 *   post:
 *     summary: IOU register with date range and optional cash book filter
 *     tags: [Petty Cash - Reports]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             properties:
 *               fromDate: { type: string, format: date }
 *               toDate:   { type: string, format: date }
 *               cashBookId: { type: string, format: uuid }
 *     responses:
 *       200:
 *         description: Array of IOU rows with outstanding, party, and cash book
 */
router.post('/iou-register', ctrl.iouRegister);

/**
 * @swagger
 * /api/petty-cash/reports/iou-aging:
 *   post:
 *     summary: IOU aging by party, bucketed 0-7/8-15/16-30/30+ days
 *     tags: [Petty Cash - Reports]
 *     requestBody:
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             properties:
 *               asOf: { type: string, format: date }
 *     responses:
 *       200:
 *         description: { parties: [...], totals: {...}, asOf }
 */
router.post('/iou-aging', ctrl.iouAging);

/**
 * @swagger
 * /api/petty-cash/reports/party-outstanding:
 *   post:
 *     summary: Per-party outstanding IOU summary
 *     tags: [Petty Cash - Reports]
 *     responses:
 *       200:
 *         description: Array of { partyName, partyId, iouCount, totalAdvance, totalSettled, outstanding }
 */
router.post('/party-outstanding', ctrl.partyOutstanding);

/**
 * @swagger
 * /api/petty-cash/reports/cashbook-balances:
 *   post:
 *     summary: Per-cash-book GL balance vs float limit
 *     tags: [Petty Cash - Reports]
 *     responses:
 *       200:
 *         description: Array of { cashBookId, code, name, cashierName, floatLimit, balance, headroom }
 */
router.post('/cashbook-balances', ctrl.cashBookBalances);

/**
 * @swagger
 * /api/petty-cash/reports/manager-dashboard:
 *   post:
 *     summary: Manager dashboard with cashier rows and KPI cards
 *     tags: [Petty Cash - Reports]
 *     requestBody:
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             properties:
 *               fromDate: { type: string, format: date }
 *               toDate:   { type: string, format: date }
 *     responses:
 *       200:
 *         description: { rows: [...], kpi: { totalFloat, totalOutstandingIou, overdueIouCount, settlementPeriodDays } }
 */
router.post('/manager-dashboard', ctrl.managerDashboard);

module.exports = router;
