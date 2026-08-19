const db = require('../../../database');
const { AppError } = require('../../../middleware/errorHandler');

function naturalAmount(accountType, net) {
  return accountType === 'A' || accountType === 'X' ? net : -net;
}

function buildHierarchy(accounts, types, amountById) {
  const typeSet = new Set(types);
  const nodes = new Map();

  for (const a of accounts) {
    if (!typeSet.has(a.accountType)) continue;
    nodes.set(a.accountId, {
      accountId:   a.accountId,
      accountCode: a.accountCode,
      accountName: a.accountName,
      accountType: a.accountType,
      level:       a.level,
      amount:      Number(amountById.get(a.accountId) || 0),
      children:    [],
    });
  }

  const roots = [];
  for (const a of accounts) {
    const node = nodes.get(a.accountId);
    if (!node) continue;
    const parent = a.parentAccountId ? nodes.get(a.parentAccountId) : null;
    if (parent) parent.children.push(node);
    else roots.push(node);
  }

  const rollUp = (n) => {
    for (const c of n.children) n.amount += rollUp(c);
    return n.amount;
  };
  const sortRec = (n) => {
    n.children.sort((x, y) => String(x.accountCode).localeCompare(String(y.accountCode)));
    n.children.forEach(sortRec);
  };
  roots.sort((x, y) => String(x.accountCode).localeCompare(String(y.accountCode)));
  roots.forEach((n) => { rollUp(n); sortRec(n); });

  return roots;
}

function fyPeriodOf(date, startMonth = 1) {
  const d = new Date(date);
  const y = d.getFullYear();
  const m = d.getMonth() + 1;
  const fyYear  = m >= startMonth ? y : y - 1;
  const fyMonth = ((m - startMonth + 12) % 12) + 1;
  return { fyYear, fyMonth };
}

function nextFyPeriod(date, startMonth = 1) {
  const { fyYear, fyMonth } = fyPeriodOf(date, startMonth);
  return fyMonth === 12 ? { fyYear: fyYear + 1, fyMonth: 1 } : { fyYear, fyMonth: fyMonth + 1 };
}

function prevFyPeriod(date, startMonth = 1) {
  const { fyYear, fyMonth } = fyPeriodOf(date, startMonth);
  return fyMonth === 1 ? { fyYear: fyYear - 1, fyMonth: 12 } : { fyYear, fyMonth: fyMonth - 1 };
}

function addDays(date, days = 1) {
  const newDate = new Date(date);
  newDate.setDate(newDate.getDate() + days);
  return newDate;
}

function getFirstDayOfMonth(date) {
  return new Date(date.getFullYear(), date.getMonth(), 1);
}

function formatDate(date) {
  const year = date.getFullYear();
  const month = String(date.getMonth() + 1).padStart(2, '0');
  const day = String(date.getDate()).padStart(2, '0');
  return `${year}-${month}-${day}`;
}

const repo = {
  fyPeriodOf,
  nextFyPeriod,
  prevFyPeriod,

  async getUi() {
    return {};
  },

  async getReport(data) {
    const { accountId, fromDate, toDate, companyId } = data;
    if (!companyId) throw new AppError('companyId is required', 400);

    const glCo = await db('gl_companies').where({ companyId }).first();
    if (!glCo) throw new AppError('GL company config not found', 404);

    const startMonth = glCo.financialYearStartMonth || 1;
    const from = new Date(fromDate);
    const to   = new Date(toDate);

    const fyOf = (d) => {
      const m = d.getMonth() + 1;
      return m >= startMonth ? d.getFullYear() : d.getFullYear() - 1;
    };
    if (fyOf(from) !== fyOf(to)) {
      throw new AppError('fromDate and toDate must be within a single financial year', 400);
    }

    const priorPeriod    = from.getFullYear() * 12 + from.getMonth();
    const monthStart     = formatDate(getFirstDayOfMonth(from));
    const dayBeforeFrom  = formatDate(addDays(from, -1));

    // Opening balance per account = prior-month cumulative snapshot + current-month
    // postings before fromDate. net = debit - credit.
    // Using UNION ALL via db.raw since Knex does not natively support UNION ALL in a clean way.
    const obFilter = accountId ? 'AND accountId = ?' : '';
    const obParams = accountId
      ? [companyId, priorPeriod, accountId, companyId, monthStart, dayBeforeFrom, accountId]
      : [companyId, priorPeriod, companyId, monthStart, dayBeforeFrom];

    const obRows = await db.raw(
      `SELECT accountId, SUM(debit) - SUM(credit) AS opbl
       FROM (
         SELECT accountId, debitTotal AS debit, creditTotal AS credit
         FROM gl_accountBalances
         WHERE companyId = ? AND (fnYear * 12 + fnMonth) = ? ${obFilter}
         UNION ALL
         SELECT accountId, debitBase AS debit, creditBase AS credit
         FROM gl_transactionDetail
         WHERE companyId = ? AND txnDate BETWEEN ? AND ? ${obFilter}
       ) AS t
       GROUP BY accountId`,
      obParams
    );

    const openingMap = new Map();
    for (const r of obRows) openingMap.set(r.accountId, Number(r.opbl || 0));

    // Report body — detail lines within the requested window
    let rowsQuery = db('gl_transactionDetail as d')
      .join('gl_transactions as t', 'd.transactionId', 't.transactionId')
      .where('d.companyId', companyId)
      .whereBetween('t.txnDate', [fromDate, toDate])
      .select(
        'd.accountId',
        't.txnDate',
        't.txnType',
        't.fnYear',
        't.docNo',
        't.transactionId',
        't.reference',
        db.raw('COALESCE(d.description, t.description) AS description'),
        db.raw('d.debitBase AS debit'),
        db.raw('d.creditBase AS credit')
      )
      .orderBy(['d.accountId', 't.txnDate', 't.docNo', 'd.lineNo']);

    if (accountId) {
      rowsQuery = rowsQuery.where('d.accountId', accountId);
    }

    const rows = await rowsQuery;

    // Account metadata for every account that appears in the result
    const accountIds = new Set(openingMap.keys());
    for (const r of rows) accountIds.add(r.accountId);
    if (accountId) accountIds.add(accountId);

    const accountInfo = accountIds.size
      ? await db('gl_chartOfAccounts')
          .whereIn('accountId', [...accountIds])
          .select('accountId', 'accountCode', 'accountName', 'accountType')
      : [];
    const accountMap = new Map(accountInfo.map(a => [a.accountId, a]));

    const grouped = new Map();
    const ensure = (id) => {
      if (!grouped.has(id)) {
        const opening = openingMap.get(id) || 0;
        grouped.set(id, {
          account: accountMap.get(id) || { accountId: id },
          opbl: opening,
          debit: 0,
          credit: 0,
          running: opening,
          lines: [],
        });
      }
      return grouped.get(id);
    };

    if (accountId) ensure(accountId);
    for (const id of openingMap.keys()) ensure(id);

    for (const row of rows) {
      const g = ensure(row.accountId);
      const debit  = Number(row.debit  || 0);
      const credit = Number(row.credit || 0);
      g.running += debit - credit;
      g.debit   += debit;
      g.credit  += credit;
      g.lines.push({
        txnDate:       row.txnDate,
        journalRef:    `${row.txnType}-${row.fnYear}-${String(row.docNo).padStart(4, '0')}`,
        transactionId: row.transactionId,
        reference:     row.reference,
        description:   row.description,
        debit,
        credit,
        runningBalance: g.running,
      });
    }

    const result = [...grouped.values()].map(g => ({
      account: g.account,
      opbl:    g.opbl,
      debit:   g.debit,
      credit:  g.credit,
      clbl:    g.opbl + g.debit - g.credit,
      lines:   g.lines,
    }));

    result.sort((a, b) =>
      String(a.account.accountCode || '').localeCompare(String(b.account.accountCode || '')));

    return result;
  },

  async getTrialBalance(data) {
    const report = await this.getReport({ ...data, accountId: undefined });
    return report.map(({ account, opbl, debit, credit, clbl }) => ({
      account, opbl, debit, credit, clbl,
    }));
  },

  async _chartAccounts(tenantId) {
    const q = db('gl_chartOfAccounts')
      .select('accountId', 'accountCode', 'accountName', 'accountType', 'parentAccountId', 'level', 'sortOrder')
      .where({ isActive: true });
    if (tenantId) q.andWhere({ tenantId });
    return q.orderBy('sortOrder');
  },

  async getPnl(data) {
    const report = await this.getReport({ ...data, accountId: undefined });

    const amountById = new Map();
    for (const r of report) {
      const type = r.account.accountType;
      if (type !== 'I' && type !== 'X') continue;
      amountById.set(r.account.accountId, naturalAmount(type, r.debit - r.credit));
    }

    let tenantId = data.tenantId;
    if (!tenantId && data.companyId) {
      const glCo = await db('gl_companies').where({ companyId: data.companyId }).first();
      tenantId = glCo && glCo.tenantId;
    }
    const accounts = await this._chartAccounts(tenantId);
    const income   = buildHierarchy(accounts, ['I'], amountById);
    const expense  = buildHierarchy(accounts, ['X'], amountById);

    const sum = (arr) => arr.reduce((s, n) => s + n.amount, 0);
    const totalIncome  = sum(income);
    const totalExpense = sum(expense);

    return {
      fromDate: data.fromDate,
      toDate:   data.toDate,
      income,
      expense,
      totalIncome,
      totalExpense,
      netProfit: totalIncome - totalExpense,
    };
  },

  async getBalanceSheet(data) {
    const { asOf, companyId } = data;
    if (!companyId) throw new AppError('companyId is required', 400);

    const glCo = await db('gl_companies').where({ companyId }).first();
    if (!glCo) throw new AppError('GL company config not found', 404);

    const startMonth = glCo.financialYearStartMonth || 1;
    const as = new Date(asOf);
    const fyYear  = (as.getMonth() + 1) >= startMonth ? as.getFullYear() : as.getFullYear() - 1;
    const fyStart = formatDate(new Date(fyYear, startMonth - 1, 1));

    const report = await this.getReport({ ...data, accountId: undefined, fromDate: fyStart, toDate: asOf });

    const amountById = new Map();
    let netProfit = 0;
    for (const r of report) {
      const type = r.account.accountType;
      const bal  = naturalAmount(type, r.clbl);
      if (type === 'A' || type === 'L' || type === 'E') {
        amountById.set(r.account.accountId, bal);
      } else if (type === 'I') {
        netProfit += bal;
      } else if (type === 'X') {
        netProfit -= bal;
      }
    }

    const accounts    = await this._chartAccounts(data.tenantId || glCo.tenantId);
    const assets      = buildHierarchy(accounts, ['A'], amountById);
    const liabilities = buildHierarchy(accounts, ['L'], amountById);
    const equity      = buildHierarchy(accounts, ['E'], amountById);

    const sum = (arr) => arr.reduce((s, n) => s + n.amount, 0);
    const totalAssets      = sum(assets);
    const totalLiabilities = sum(liabilities);

    const equityRows = [...equity, {
      accountId:   null,
      accountCode: '3999',
      accountName: 'Current Year Earnings',
      accountType: 'E',
      level:       1,
      amount:      netProfit,
      children:    [],
    }];
    const totalEquity = sum(equity) + netProfit;

    return {
      asOf,
      assets,
      liabilities,
      equity: equityRows,
      totalAssets,
      totalLiabilities,
      totalEquity,
      netProfit,
      balanced: Math.round((totalAssets - (totalLiabilities + totalEquity)) * 100) === 0,
    };
  },

  async getAccounts() {
    return db('gl_chartOfAccounts')
      .select('accountId', 'accountType', 'accountName')
      .where({ isActive: true })
      .orderBy('accountCode');
  },
};

module.exports = repo;
module.exports.fyPeriodOf = fyPeriodOf;
module.exports.nextFyPeriod = nextFyPeriod;
module.exports.prevFyPeriod = prevFyPeriod;