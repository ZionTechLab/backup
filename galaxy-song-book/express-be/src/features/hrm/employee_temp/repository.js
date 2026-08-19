const db = require('../../../database');
const { getNextSerialNo } = require('../../../repository/getNextSerialNo');
const { ensureUnique } = require("../../../repository/validators");

const argon2 = require('argon2');

const UserRepo = {

  async getUi() {
    const Status = await db('ref_category').select('id', 'value').where({ categoryType: 2100 });
    const Title = await db('ref_category').select('id', 'value').where({ categoryType: 2101 });
    const Gender = await db('ref_category').select('id', 'value').where({ categoryType: 2102 });
    const MaritalStatus = await db('ref_category').select('id', 'value').where({ categoryType: 2103 });
    const Nationality = await db('ref_category').select('id', 'value').where({ categoryType: 2104 });
    const Religion = await db('ref_category').select('id', 'value').where({ categoryType: 2105 });
    const BloodGroup = await db('ref_category').select('id', 'value').where({ categoryType: 2106 });
    const Country = await db('ref_category').select('id', 'value').where({ categoryType: 2107 });
    const Province = await db('ref_category').select('id', 'value').where({ categoryType: 2108 });
    const District = await db('ref_category').select('id', 'value').where({ categoryType: 2109 });
    const City = await db('ref_category').select('id', 'value').where({ categoryType: 2110 });
    const Division = await db('ref_category').select('id', 'value').where({ categoryType: 2111 });
    const Department = await db('ref_category').select('id', 'value').where({ categoryType: 2112 });
    const Section = await db('ref_category').select('id', 'value').where({ categoryType: 2113 });
    const SubSection = await db('ref_category').select('id', 'value').where({ categoryType: 2114 });
    const Designation = await db('ref_category').select('id', 'value').where({ categoryType: 2115 });
    const RecruitmentType = await db('ref_category').select('id', 'value').where({ categoryType: 2116 });
    const PaymentMethod = await db('ref_category').select('id', 'value').where({ categoryType: 2117 });
    const Bank = await db('ref_category').select('id', 'value').where({ categoryType: 2118 });
    const BankBranch = await db('ref_category').select('id', 'value').where({ categoryType: 2119 });
    return {Status,Title,Gender,MaritalStatus,Nationality,Religion,BloodGroup,Country,Province,District,City,Division,Department,Section,SubSection,Designation,RecruitmentType,PaymentMethod,Bank,BankBranch};
  },


  async getAll(filters = {}) {
    const result = await db('mas_users')
      .select('id', 'userName', 'fullName', 'email', 'phone', 'phone2')
      .where('deleted', 0)
      .where('roleId', '<>', -1);
    return result;
  },

  async get(filters = {}) {
    const result = await db('mas_users')
      .select('id', 'userName', 'fullName', 'email', 'phone', 'phone2', 'roleId', 'active')
      .where({ deleted: 0, id: filters.id })
      .first();
    return { ...result };
  },

  async update(data) {
    const docType = "USR",txnType = "USR" ;

    return db.transaction(async (trx) => {

      const id = data.isUpdate? data.header.id: await getNextSerialNo(trx, docType, txnType);

      await ensureUnique(trx,"mas_users",{ userName: data.header.userName },{ id },
        `User with username ${data.header.userName} already exists.`
      );

      await ensureUnique(trx,"mas_users",{ fullName: data.header.fullName },{ id },
        `User with full name ${data.header.fullName} already exists.`
      );
    
      await ensureUnique(trx,"mas_users",{ email: data.header.email },{ id },
        `User with email ${data.header.email} already exists.`
      );

      await ensureUnique(trx,"mas_users",{ phone: data.header.phone},{ id },
        `User with phone ${data.header.phone} already exists.`
      );

      await ensureUnique(trx,"mas_users",{ phone2: data.header.phone},{ id },
        `User with phone ${data.header.phone} already exists.`
      );

        await ensureUnique(trx,"mas_users",{ phone2: data.header.phone2},{ id },
        `User with phone ${data.header.phone2} already exists.`
      );

      await ensureUnique(trx,"mas_users",{ phone: data.header.phone2},{ id },
        `User with phone ${data.header.phone2} already exists.`
      );
      
      // Fetch current record before soft-delete to preserve existing hash if password not provided
      let current = null;
      if (data.isUpdate) {
        current = await trx("mas_users").where({ id, deleted: false }).first();
      }

      const header = { ...data.header };

      // If password not provided (empty, null, or whitespace) on update, keep existing hashed password
      const isBlankPassword =
        header.password == null ||
        (typeof header.password === 'string' && header.password.trim() === '');
      if (data.isUpdate && isBlankPassword && current?.password) {
        header.password = current.password;
      }

      // Hash password if it's provided and not already an argon2 hash
      if (header.password && typeof header.password === 'string') {
        const alreadyHashed = header.password.startsWith('$argon2');
        if (!alreadyHashed) {
          header.password = await argon2.hash(header.password, {
            type: argon2.argon2id,
            timeCost: 2,
            memoryCost: 19456, // ~19MB
            parallelism: 1,
          });
        }
      }

      if (data.isUpdate) {
        await trx("mas_users")
          .where({ id, deleted: false })
          .update({ deleted: true });
      }

      const [index] = await trx("mas_users").insert({
        ...header,
        id,
        updatedBy: data.userId || null,
        updatedAt: new Date(),
      });

      return trx("mas_users").where({ index }).first();
    });
  },

  // Verify user credentials: returns user (without password) when valid, otherwise null
  async verifyCredentials({ userName, password }) {
    const row = await db('mas_users')
      .select('id', 'userName', 'password', 'fullName', 'email', 'phone', 'phone2', 'roleId', 'active')
      .where({ deleted: 0, userName })
      .first();
    if (!row || !row.password) return null;
    const ok = await argon2.verify(row.password, password);
    if (!ok) return null;
    const { password: _pw, ...safeUser } = row;
    return safeUser;
  },

    async delete(data) {

    return db.transaction(async (trx) => {

      await trx("mas_users")
          .where({ id: data.id, deleted: false })
          .update({ deleted: true });

      return 'success';
    });
  },
};

module.exports = UserRepo;