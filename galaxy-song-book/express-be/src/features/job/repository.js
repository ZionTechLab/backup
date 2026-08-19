const db = require('../../database');
const { getNextSerialNo } = require('../../repository/getNextSerialNo');
const { getRefCategory } = require('../../repository/refCategory');
const { pickFields } = require('../../repository/pickFields');
const { snapshotBefore, snapshotInsert } = require('../../repository/auditHistory');

const docType = 'JOB';
const txnType = 'SVC';

// Client-settable columns on svc_txn_jobs. id, docType, txnType, tenantId,
// companyId, deleted, updatedBy, updatedAt set explicitly.
const JOB_FIELDS = ['txnDate', 'partner', 'status', 'ref1', 'ref2', 'ref3', 'description', 'remarks'];

const repo = {

  async getUi() {
    const jobTypes =await getRefCategory(1);
    const JobPriorities = await getRefCategory(2);
    const JobTags = await getRefCategory(3);
    const JobStatus = await getRefCategory(4);

    return {jobTypes,JobPriorities,JobTags,JobStatus};
  },

  async getAll(filters = {}) {
    const result = await db('svc_txn_jobs AS DB')
      .select(
        db.raw("CONCAT(DB.txnType, '/', DB.id) AS txnNoDisplay"),
        'DB.id',
        'DB.txnDate',
        'BP.partnerName',
        db.raw('RC.value AS status'),
        'DB.ref1',
        'DB.ref2',
        'DB.ref3',
        'DB.description',
        'DB.remarks'
      )
      .leftOuterJoin('mas_businessPartner AS BP', 'DB.partner', 'BP.businessPartnerId')
      .leftOuterJoin('ref_category AS RC', function() {
        this.on('DB.status', '=', 'RC.id')
          .andOn('RC.categoryType', '=', db.raw('4'));
      })
      .where({ 'DB.deleted': false, 'DB.docType': docType, 'DB.txnType': txnType });
    return result;
  },


  async get(filters = {}) {
    const header = await db('svc_txn_jobs')
      .select(
       'id','txnDate','partner','status','ref1','ref2','ref3','description','remarks'
      )
      .where({ id: filters.id , docType, txnType, deleted: false })
      .first();
    if (!header) return null;

    const tags = await db('svc_txn_job_tags')
      .select('tag_id')
      .where({ id: header.id, deleted: false });

    return { ...header, jobTags: tags.map(t => t.tag_id) };
  },

  async getPrint(filters = {}) {

    const header = await db('svc_txn_jobs AS DB')
      .select(
        db.raw("CONCAT(DB.txnType, '/', DB.id) AS txnNoDisplay"),
        'DB.id',
        'DB.txnDate',
        'BP.partnerName',
        db.raw('RC.value AS status'),
        'DB.ref1',
        'DB.ref2',
        'DB.ref3',
        'DB.description',
        'DB.remarks'
      )
      .leftOuterJoin('mas_businessPartner AS BP', 'DB.partner', 'BP.businessPartnerId')
      .leftOuterJoin('ref_category AS RC', function() {
        this.on('DB.status', '=', 'RC.id')
          .andOn('RC.categoryType', '=', db.raw('4'));
      })
      .where({ 'DB.deleted': false, 'DB.id': filters.id, 'DB.docType': docType, 'DB.txnType': txnType })
      .first();

    if (!header) return null;

    const tags = await db('svc_txn_job_tags AS DB')
      .select(db.raw('RC.value'))
      .leftOuterJoin('ref_category AS RC', function() {
        this.on('DB.tag_id', '=', 'RC.id')
          .andOn('RC.categoryType', '=', db.raw('3'));
      })
      .where({ 'DB.deleted': false, 'DB.id': filters.id });

    return { ...header, jobTags: tags.map(t => t.value) || [] };
  },

  async update(data) {

    return db.transaction(async (trx) => {

      let id = data.isUpdate ? data.header.id : await getNextSerialNo(trx, docType, txnType);
      const headerInput = data.header || {};
      const jobTags = headerInput.jobTags;

      if (data.isUpdate) {
        await trx('svc_txn_jobs').where({ id, docType, txnType, deleted:false }).update({ deleted:true });
        await trx('svc_txn_job_tags').where({ id, deleted:false }).update({ deleted:true });
        await trx('svc_txn_job_activities').where({ JobId: id, deleted:false }).update({ deleted:true });

      }

      const [txnIndex] = await trx('svc_txn_jobs').insert({
        ...pickFields(headerInput, JOB_FIELDS),
        id,
        docType,
        txnType,
        tenantId: data.tenantId ?? null,
        companyId: data.companyId ?? null,
        updatedBy: data.userId ?? null,
        updatedAt: new Date(),
        deleted: false,
      });
      await snapshotInsert(trx, 'svc_txn_jobs', { txnIndex }, data.userId);

      if (Array.isArray(jobTags) && jobTags.length) {
        for (const tag of jobTags.filter((jobTag) => jobTag.value === true)) {
          await trx('svc_txn_job_tags').insert({
            tenantId: data.tenantId ?? 1,
            companyId: data.companyId ?? 1,
            id,
            tag_id: tag.id,
            deleted: false,
          });
        }
      }

      return trx('svc_txn_jobs').where({ txnIndex }).first();
    });

  },
  async delete(data) {
    return db.transaction(async (trx) => {
      const id = data.id ?? data.JobId;
      await snapshotBefore(trx, 'svc_txn_jobs', { id, docType, txnType, deleted: false }, data.userId, 'DELETE');
      await trx('svc_txn_jobs').where({ id, docType, txnType, deleted: false }).update({ deleted: true });
      await trx('svc_txn_job_activities').where({ JobId: id, deleted: false }).update({ deleted: true });
      await trx('svc_txn_job_tags').where({ id, deleted: false }).update({ deleted: true });
      return 'success';
    });
  }
};

module.exports = repo;