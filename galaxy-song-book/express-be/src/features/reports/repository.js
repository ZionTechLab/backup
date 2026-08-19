const db = require('../../database');
const { getNextSerialNo } = require('../../repository/getNextSerialNo');

const DebtorTXN = {
  async getUi() { 
     const reports = await db({ct: 'conf_txnType'})
       .select('ct.docType', 'ct.txnType', 'st.txnTypename')
       .leftJoin({st: 'sec_txnType'}, function() {
         this.on('st.docType', '=', 'ct.docType')
           .andOn('st.txnType', '=', 'ct.txnType');
       })
       .where({'ct.isActive': true, 'ct.isReport': true});

     const vehicleType = await db('ref_category')
       .select('id', 'value')
       .where({ categoryType: 70, isActive: true });

     return { reports, vehicleType };
  },

  async getReport(data) {
    let result = [];
    let columns = [];

    const baseQuery = (txnType) => {
      return db('ar_txn_debtorTXN AS DB')
        .select(
          'DB.id',
          db.raw("CONCAT(DB.txnType, '/', DB.id) AS txnNoDisplay"),
          'DB.txnDate',
          'BP.partnerCode',
          'BP.partnerName',
          'DB.remarks',
          db.raw('V.value AS vehicleType'),
          'DB.amount',
          ...(txnType === 'TAX' || txnType === 'ADV' || txnType === 'PAY' ? ['DB.taxAmount'] : []),
          'DB.totalAmount'
        )
        .leftOuterJoin('mas_businessPartner AS BP', 'DB.partner', 'BP.businessPartnerId')
        .leftOuterJoin('ref_category AS V', function() {
          this.on('V.categoryType', '=', db.raw('70'))
            .andOn('V.isActive', '=', db.raw('true'))
            .andOn('DB.ref1', '=', 'V.id');
        })
        .where('DB.deleted', false)
        .where('DB.txnType', data.txnType)
        .whereBetween('DB.txnDate', [data.fromDate, data.toDate])
        .where(function() {
          if (data.partner) {
            this.where('DB.partner', data.partner);
          }
        })
        .where(function() {
          if (data.ref1) {
            this.where('DB.ref1', data.ref1);
          }
        });
    };

    switch (data.txnType) {
      case 'NT':
          result = await baseQuery('NT');

          columns = [
            { header: 'Invoice No', field: 'txnNoDisplay',class:'text-nowrap' },
            { header: 'Date', field: 'txnDate',class:'text-nowrap' ,type: 'date'},
            { header: 'Customer Code', field: 'partnerCode',class:'text-nowrap' },
            { header: 'Customer', field: 'partnerName',class:'text-nowrap' },
            { header: 'Vehicle Type', field: 'vehicleType',class:'text-nowrap' },
            { header: 'Amount', type: 'currency', field: 'amount',class:'text-nowrap text-end' },
            { header: 'Advance', type: 'currency', field: 'advance',class:'text-nowrap text-end' },
            { header: 'Total Amount', type: 'currency', field: 'totalAmount',class:'text-nowrap text-end' },
          ];

          return {result, columns};
        break;
      case 'TAX':
          result = await baseQuery('TAX');

          columns = [
            { header: 'Invoice No', field: 'txnNoDisplay',class:'text-nowrap' },
            { header: 'Date', field: 'txnDate',class:'text-nowrap' ,type: 'date'},
            { header: 'Customer Code', field: 'partnerCode',class:'text-nowrap' },
            { header: 'Customer', field: 'partnerName',class:'text-nowrap' },
            { header: 'Amount', type: 'currency', field: 'amount',class:'text-nowrap text-end' },
            { header: 'Tax Amount', type: 'currency', field: 'taxAmount',class:'text-nowrap text-end' },
            { header: 'Total Amount', type: 'currency', field: 'totalAmount',class:'text-nowrap text-end' },
          ];

          return {result, columns};
        break;
         case 'ADV':
          result = await baseQuery('ADV');

          columns = [
            { header: 'Advance No', field: 'txnNoDisplay',class:'text-nowrap' },
            { header: 'Date', field: 'txnDate',class:'text-nowrap' ,type: 'date'},
            { header: 'Employee Code', field: 'partnerCode',class:'text-nowrap' },
            { header: 'Employee', field: 'partnerName',class:'text-nowrap' },
            { header: 'Remarks', field: 'remarks',class:'text-nowrap' },
            { header: 'Total Amount', type: 'currency', field: 'totalAmount',class:'text-nowrap text-end' },
          ];

          return {result, columns};
        break;
         case 'PAY':
          result = await baseQuery('PAY');

          columns = [
            { header: 'Payment No', field: 'txnNoDisplay',class:'text-nowrap' },
            { header: 'Date', field: 'txnDate',class:'text-nowrap' ,type: 'date'},
            { header: 'Employee Code', field: 'partnerCode',class:'text-nowrap' },
            { header: 'Employee', field: 'partnerName',class:'text-nowrap' },
            { header: 'Vehicle Type', field: 'vehicleType',class:'text-nowrap' },
            { header: 'Remarks', field: 'remarks',class:'text-nowrap' },
            { header: 'Total Amount', type: 'currency', field: 'totalAmount',class:'text-nowrap text-end' },
          ];

          return {result, columns};
        break;
      default:
        // handle default case
    }
    

  },
  
};

module.exports = DebtorTXN;