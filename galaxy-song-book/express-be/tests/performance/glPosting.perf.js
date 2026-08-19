const { postGl } = require('../../src/repository/glPosting');

async function benchmark() {
  const details = [];
  const numLines = 500;

  // create balanced details
  for(let i=0; i<numLines; i++) {
    details.push({
      accountId: 'test-account',
      debitAmount: 100,
      creditAmount: 0,
      currencyCode: 'USD',
      exchangeRate: 1,
    });
    details.push({
      accountId: 'test-account-2',
      debitAmount: 0,
      creditAmount: 100,
      currencyCode: 'USD',
      exchangeRate: 1,
    });
  }

  const opts = {
    tenantId: 'test-tenant',
    companyId: 'test-company',
    docType: 'test',
    txnType: 'test',
    docNo: '123',
    txnDate: new Date(),
    details
  };

  let insertCount = 0;

  // Setup mock for resolveFinPeriod and trx
  const mockTrx = (table) => {
    return {
      insert: async (data) => {
        insertCount++;
        // Simulate network/DB latency
        await new Promise(resolve => setTimeout(resolve, 1));
      },
      where: () => ({
        andWhere: () => ({
          andWhere: () => ({
            first: async () => ({ fnYear: 2024, fnMonth: 1, isClosed: false })
          })
        })
      })
    }
  };

  console.time('postGl');
  await postGl(mockTrx, opts);
  console.timeEnd('postGl');
  console.log(`Total inserts: ${insertCount}`);
}

benchmark().catch(console.error);
