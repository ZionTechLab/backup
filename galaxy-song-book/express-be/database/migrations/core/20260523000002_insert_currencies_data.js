exports.up = async function(knex) {
  await knex('sec_currencies').insert([
    { currencyCode: 'USD', currencyName: 'US Dollar',          symbol: '$',  isActive: true },
    { currencyCode: 'EUR', currencyName: 'Euro',               symbol: '€',  isActive: true },
    { currencyCode: 'GBP', currencyName: 'British Pound',      symbol: '£',  isActive: true },
    { currencyCode: 'LKR', currencyName: 'Sri Lankan Rupee',   symbol: 'Rs', isActive: true },
    { currencyCode: 'INR', currencyName: 'Indian Rupee',       symbol: '₹',  isActive: true },
    { currencyCode: 'AUD', currencyName: 'Australian Dollar',  symbol: 'A$', isActive: true },
    { currencyCode: 'SGD', currencyName: 'Singapore Dollar',   symbol: 'S$', isActive: true },
    { currencyCode: 'JPY', currencyName: 'Japanese Yen',       symbol: '¥',  isActive: false },
    { currencyCode: 'AED', currencyName: 'UAE Dirham',         symbol: 'د.إ',isActive: false },
    { currencyCode: 'CNY', currencyName: 'Chinese Yuan',       symbol: '¥',  isActive: false },
  ]);
};

exports.down = async function(knex) {
  await knex('sec_currencies').whereIn('currencyCode', [
    'USD','EUR','GBP','LKR','INR','AUD','SGD','JPY','AED','CNY',
  ]).del();
};
