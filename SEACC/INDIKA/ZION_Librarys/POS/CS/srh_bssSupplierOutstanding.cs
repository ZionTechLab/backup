using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class srh_bssSupplierOutstanding {
		#region Fields
		private string supplier_ID;
        private string supplierName;
        private int transactionType;
		private string transaction_ID;
		private DateTime transactionDate;
        private string remark;
        private decimal transactionAmount;
        private decimal outstandingAmount;
        private decimal chequeInHand;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the srh_bssSupplierOutstanding class.
		/// </summary>
		public srh_bssSupplierOutstanding() {
		}
		
		/// <summary>
		/// Initializes a new instance of the srh_bssSupplierOutstanding class.
		/// </summary>
        public srh_bssSupplierOutstanding(string supplier_ID, string supplierName, int transactionType, string transaction_ID, DateTime transactionDate, string remark, decimal transactionAmount, decimal OutstandingAmount, decimal chequeInHand)
        {
			this.supplier_ID = supplier_ID;
            this.supplierName = supplierName;
			this.transactionType = transactionType;
			this.transaction_ID = transaction_ID;
			this.transactionDate = transactionDate;
            this.remark = remark;
            this.transactionAmount = transactionAmount;
          //  this.outstandingAmount = outstandingAmount;
            this.chequeInHand = chequeInHand;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Supplier_ID value.
		/// </summary>
		public string Supplier_ID {
			get { return supplier_ID; }
			set { supplier_ID = value; }
		}
        /// <summary>
        /// Gets or sets the Supplier_ID value.
        /// </summary>
        public string SuppliernName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }
        /// <summary>
        /// Gets or sets the TransactionType value.
        /// </summary>
        public int TransactionType {
			get { return transactionType; }
			set { transactionType = value; }
		}
		
		/// <summary>
		/// Gets or sets the Transaction_ID value.
		/// </summary>
		public string Transaction_ID {
			get { return transaction_ID; }
			set { transaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TransactionDate value.
		/// </summary>
		public DateTime TransactionDate {
			get { return transactionDate; }
			set { transactionDate = value; }
		}

        /// <summary>
        /// Gets or sets the remark value.
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

		/// <summary>
        /// Gets or sets the transactionAmount value.
		/// </summary>
        public decimal TransactionAmount
        {
            get { return transactionAmount; }
            set { transactionAmount = value; }
		}
		
		/// <summary>
        /// Gets or sets the outstandingAmount value.
		/// </summary>
        public decimal OutstandingAmount
        {
            get { return outstandingAmount; }
            set { outstandingAmount = value; }
		}
		#endregion

        /// <summary>
        /// Gets or sets the chequeInHand value.
        /// </summary>
        public decimal ChequeInHand
        {
            get { return chequeInHand; }
            set { chequeInHand = value; }
        }

		#region Methods

        public static List<srh_bssSupplierOutstanding> SelectAllBySupplierId(string supplierr_ID, DateTime toDate, bool settleDebitNotesAsAtAPNDate, bool UseBilldateAsApnDate, string sCompanyBranchID)
        {
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom;
            if (UseBilldateAsApnDate)
                scom = new SqlCommand("srh_bssSupplierOutstandingSelectAllBySupplierID_BillDate", scon);
            else
                scom = new SqlCommand("srh_bssSupplierOutstandingSelectAllBySupplierID", scon);

            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@supplerId", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@dtmToDate", SqlDbType.DateTime);
            scom.Parameters.Add("@settleDebitNotesAsAtAPNDate", SqlDbType.Int);
            scom.Parameters.Add("@companyBranchID", SqlDbType.VarChar, 20);
            scom.Parameters["@supplerId"].Value = supplierr_ID;
            scom.Parameters["@dtmToDate"].Value = toDate;
            scom.Parameters["@settleDebitNotesAsAtAPNDate"].Value = settleDebitNotesAsAtAPNDate ? 1 : 0;
            scom.Parameters["@companyBranchID"].Value = sCompanyBranchID;

            List<srh_bssSupplierOutstanding> srh_bssSupplierOutstandingList = new List<srh_bssSupplierOutstanding>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    srh_bssSupplierOutstanding srh_bssSupplierOutstanding = Makesrh_bssSupplierOutstanding(dataReader);
                    srh_bssSupplierOutstandingList.Add(srh_bssSupplierOutstanding);
                }
            }
            scon.Close();
            return srh_bssSupplierOutstandingList;
        }
	
		/// <summary>
		/// Creates a new instance of the srh_bssSupplierOutstanding class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static srh_bssSupplierOutstanding Makesrh_bssSupplierOutstanding(SqlDataReader dataReader) {
			srh_bssSupplierOutstanding srh_bssSupplierOutstanding = new srh_bssSupplierOutstanding();
			
			if (dataReader.IsDBNull(0) == false) {
				srh_bssSupplierOutstanding.Supplier_ID = dataReader.GetString(0);
			}
            if (dataReader.IsDBNull(1) == false)
            {
                srh_bssSupplierOutstanding.supplierName = dataReader.GetString(1);
            }
            if (dataReader.IsDBNull(2) == false) {
				srh_bssSupplierOutstanding.TransactionType = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				srh_bssSupplierOutstanding.Transaction_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				srh_bssSupplierOutstanding.TransactionDate = dataReader.GetDateTime(4);
			}
            if (dataReader.IsDBNull(5) == false)
            {
                srh_bssSupplierOutstanding.Remark = dataReader.GetString(5);
            }
			if (dataReader.IsDBNull(6) == false) {
                srh_bssSupplierOutstanding.TransactionAmount = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
                srh_bssSupplierOutstanding.OutstandingAmount = dataReader.GetDecimal(7);
			}
            if (dataReader.IsDBNull(8) == false)
            {
                srh_bssSupplierOutstanding.ChequeInHand = dataReader.GetDecimal(8);
            }
			return srh_bssSupplierOutstanding;
		}
		/// <summary>
		/// This makes srh_bssSupplierOutstanding datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new srh_bssSupplierOutstanding object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( srh_bssSupplierOutstanding  srh_bssSupplierOutstanding   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
            DataColumn col_supplierName = new DataColumn("supplierName", typeof(string));
            DataColumn col_transactionType = new DataColumn("transactionType" , typeof(int));
			DataColumn col_transaction_ID = new DataColumn("transaction_ID" , typeof(string));
			DataColumn col_transactionDate = new DataColumn("transactionDate" , typeof(DateTime));
            DataColumn col_remark = new DataColumn("remark", typeof(string));
            DataColumn col_transactionAmount = new DataColumn("transactionAmount", typeof(decimal));
            DataColumn col_outstandingAmount = new DataColumn("outstandingAmount", typeof(decimal));
            DataColumn col_chequeInHand = new DataColumn("chequeInHand", typeof(decimal));
            dt.Columns.AddRange(new DataColumn[] { col_supplier_ID, col_supplierName, col_transactionType, col_transaction_ID, col_transactionDate, col_remark, col_transactionAmount, col_outstandingAmount, col_chequeInHand, }); return dt;
		}
		/// <summary>
		/// This fills srh_bssSupplierOutstanding datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new srh_bssSupplierOutstanding object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, srh_bssSupplierOutstanding user) {
		DataRow drow = dt.NewRow();
		
			drow["supplier_ID"] = user.supplier_ID;
            drow["supplierName"] = user.supplierName;
            drow["transactionType"] = user.transactionType;
			drow["transaction_ID"] = user.transaction_ID;
			drow["transactionDate"] = user.transactionDate;
            drow["remark"] = user.remark;
            drow["transactionAmount"] = user.transactionAmount;
            drow["outstandingAmount"] = user.outstandingAmount;
            drow["chequeInHand"] = user.chequeInHand;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
