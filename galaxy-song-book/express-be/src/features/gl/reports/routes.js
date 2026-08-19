const express = require('express');
const router  = express.Router();
const ctrl    = require('./controller');

/**
 * @swagger
 * /api/gl/reports/get-ui:
 *   get:
 *     summary: Get report UI metadata
 *     tags: [GL - Reports]
 *     responses:
 *       200:
 *         description: Report UI metadata
 */
router.get('/get-ui', ctrl.getUi);

/**
 * @swagger
 * /api/gl/reports/get-report:
 *   post:
 *     summary: Get general ledger report over a date range
 *     description: Omit accountId to report on all accounts. Returns an array of per-account ledgers.
 *     tags: [GL - Reports]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             required: [fromDate, toDate]
 *             properties:
 *               accountId: { type: string, format: uuid, description: Optional. Omit to report on all accounts. }
 *               fromDate:  { type: string, format: date }
 *               toDate:    { type: string, format: date }
 *     responses:
 *       200:
 *         description: Array of per-account ledgers, each with account, opbl, debit, credit, clbl, lines
 *       400:
 *         description: Validation error (toDate not greater, or dates span financial years)
 */
router.post('/get-report', ctrl.getReport);

/**
 * @swagger
 * /api/gl/reports/trial-balance:
 *   post:
 *     summary: Get trial balance for all accounts over a date range
 *     description: Dates must fall within a single financial year. Returns one row per account.
 *     tags: [GL - Reports]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             required: [fromDate, toDate]
 *             properties:
 *               fromDate: { type: string, format: date }
 *               toDate:   { type: string, format: date }
 *     responses:
 *       200:
 *         description: Array of per-account balances, each with account, opbl, debit, credit, clbl
 *       400:
 *         description: Validation error (toDate not greater, or dates span financial years)
 */
router.post('/trial-balance', ctrl.getTrialBalance);

/**
 * @swagger
 * /api/gl/reports/pnl:
 *   post:
 *     summary: Get profit and loss statement over a date range
 *     description: Dates must fall within a single financial year. Income and expense accounts nested by parent, with totals and net profit.
 *     tags: [GL - Reports]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             required: [fromDate, toDate]
 *             properties:
 *               fromDate: { type: string, format: date }
 *               toDate:   { type: string, format: date }
 *     responses:
 *       200:
 *         description: P&L with nested income/expense trees, totalIncome, totalExpense, netProfit
 *       400:
 *         description: Validation error (toDate not greater, or dates span financial years)
 */
router.post('/pnl', ctrl.getPnl);

/**
 * @swagger
 * /api/gl/reports/balance-sheet:
 *   post:
 *     summary: Get balance sheet as of a date
 *     description: Assets, liabilities and equity nested by parent, as of asOf. Equity includes a current-year-earnings line so the statement balances.
 *     tags: [GL - Reports]
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             type: object
 *             required: [asOf]
 *             properties:
 *               asOf: { type: string, format: date }
 *     responses:
 *       200:
 *         description: Balance sheet with nested asset/liability/equity trees, totals, netProfit, and balanced flag
 *       404:
 *         description: GL company config not found
 */
router.post('/balance-sheet', ctrl.getBalanceSheet);

/**
 * @swagger
 * /api/gl/reports/get-accounts:
 *   get:
 *     summary: Get all active accounts
 *     tags: [GL - Reports]
 *     responses:
 *       200:
 *         description: List of accounts (accountId, accountType, accountName)
 */
router.get('/get-accounts', ctrl.getAccounts);

module.exports = router;
