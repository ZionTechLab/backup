const db = require('../../database');
const { getNextSerialNo } = require('../../repository/getNextSerialNo');
const { getRefCategory } = require('../../repository/refCategory');
const { snapshotInsert } = require('../../repository/auditHistory');

const JollySnapRepo = {
    async getAll(filters = {}) {
        const result = await db('js_txn_job_hedder')
            .select('id', 'name', 'email', 'whatsAppNo')
            .where('deleted', 0);
        return result;
    },
  async getUi() {
    const jobTypes = await getRefCategory(1);

    return {jobTypes};
  },
    async get(filters = {}) {
        const result = await db('js_txn_job_hedder')
            .select('id', 'name', 'email', 'whatsAppNo')
            .where({ deleted: 0, id: filters.id })
            .first();
        return { ...result };
    },

    async update(data) {
        const docType = "js", txnType = "js";

        return db.transaction(async (trx) => {
            const id = data.isUpdate ? data.header.id : await getNextSerialNo(trx, docType, txnType);

            if (data.isUpdate) {
                await trx("js_txn_job_hedder")
                    .where({ id, deleted: false })
                    .update({ deleted: true });
            }
            //   [id] = 
            await trx('js_txn_job_hedder').insert({
                id,
                tenantId: 0,
                companyId: 0,
                name: data.header.name,
                email: data.header.email,
                whatsAppNo: data.header.whatsAppNo,
            });
            await snapshotInsert(trx, 'js_txn_job_hedder', { id }, data.userId);
            return { id: id };
        });
    },

    async delete(data) {
        return db.transaction(async (trx) => {
            await trx("js_txn_job_hedder")
                .where({ id: data.param.id, deleted: false })
                .update({ deleted: true });
            return 'success';
        });
    }
};

module.exports = JollySnapRepo;