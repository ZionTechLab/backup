const db = require("../../database");
const { getNextSerialNo } = require("../../repository/getNextSerialNo");
const { snapshotBefore, snapshotInsert } = require('../../repository/auditHistory');

const repo = {
  async getAllBooks(filters = {}) {
    const result = await db("sb_txn_Book")
      .select("id", "title", "language")
      .where("deleted", false);
    return result;
  },


  async getPopularSongs(limit = 10) {
    const result = await db("sb_txn_song as s")
      .select("s.id", "s.title")
      .count("bp.Song_id as occurrence_count")
      .leftOuterJoin("sb_txn_BookPages as bp", function() {
        this.on("bp.Song_id", "=", "s.id")
          .andOn("bp.deleted", "=", db.raw("false"));
      })
      .where("s.deleted", false)
      .groupBy("s.id", "s.title")
      .orderBy("occurrence_count", "desc")
      .limit(limit);

    // Ensure occurrence_count is a number
    return result.map(row => ({
      ...row,
      occurrence_count: parseInt(row.occurrence_count, 10) || 0
    }));
  },

  async getAllSongs(filters = {}) {
    const result = await db("sb_txn_song")
      .select("id", "title")
      .where("deleted", false);
    return result;
  },

  async getSong(filters = {}) {
    const result = await db("sb_txn_song")
      .select("id", "title", "lyrics")
      .where({ id: filters.id, deleted: false })
      .first();
    return result || null;
  },

  async getBook(filters = {}) {
    const rows = await db("sb_txn_Book b")
      .select(
        "b.id",
        "b.title",
        "b.language",
        "bp.Song_id",
        "bp.Song_No",
        "s.title as songTitle"
      )
      .leftOuterJoin("sb_txn_BookPages bp", function() {
        this.on("bp.Book_id", "=", "b.id")
          .andOn("bp.deleted", "=", db.raw("false"));
      })
      .leftOuterJoin("sb_txn_song s", function() {
        this.on("s.id", "=", "bp.Song_id")
          .andOn("s.deleted", "=", db.raw("false"));
      })
      .where({ "b.id": filters.id, "b.deleted": false })
      .orderBy("bp.Song_No");

    if (!rows.length) return null;
    const { id, title, language } = rows[0];
    const pages = rows
      .filter(r => r.Song_id != null)
      .map(r => ({ songId: r.Song_id, songNo: r.Song_No, songTitle: r.songTitle }));
    return { id, title, language, pages };
  },

  async updateSong(data) {
    const docType = "SNG", txnType = "SNG";

    return db.transaction(async (trx) => {
      if (data.isUpdate) {
        // Snapshot the current row to history, then update it in place
        await snapshotBefore(trx, 'sb_txn_song', { id: data.id, deleted: false }, data.userId || 0, 'UPDATE');

        await trx("sb_txn_song")
          .where({ id: data.id, deleted: false })
          .update({
            title:    data.title,
            lyrics:   data.lyrics,
            language: data.language || '',
            updatedBy: data.userId || null,
            updatedAt: new Date(),
          });

        return trx("sb_txn_song").where({ id: data.id, deleted: false }).first();
      }

      // New song — allocate an ID and insert
      const id = await getNextSerialNo(trx, docType, txnType);

      await trx("sb_txn_song").insert({
        tenantId:  data.tenantId  || 1,
        companyId: data.companyId || 1,
        id,
        title:     data.title,
        lyrics:    data.lyrics,
        language:  data.language || '',
        active:    true,
        deleted:   false,
        updatedBy: data.userId || null,
        updatedAt: new Date(),
      });
      await snapshotInsert(trx, "sb_txn_song", { id }, data.userId);

      return trx("sb_txn_song").where({ id, deleted: false }).first();
    });
  },

  async deleteSong(data) {
    return db.transaction(async (trx) => {
      await snapshotBefore(trx, 'sb_txn_song', { id: data.id, deleted: false }, data.userId || 0, 'DELETE');

      await trx("sb_txn_song")
        .where({ id: data.id, deleted: false })
        .update({ deleted: true, updatedBy: data.userId || null, updatedAt: new Date() });

      return 'success';
    });
  },
};

module.exports = repo;