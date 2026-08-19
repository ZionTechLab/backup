const db = require('../database');

async function getRefCategory(categoryType) {
const category = await db('ref_category')
    .select('id', 'parentId', 'value')
    .where({
        categoryType: categoryType,
        isActive: true
    });

  return category;
}

module.exports = { getRefCategory };
