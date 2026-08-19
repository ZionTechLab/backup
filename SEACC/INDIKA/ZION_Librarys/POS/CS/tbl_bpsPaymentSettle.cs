using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_bpsPaymentSettle {
		#region Fields
		private string accountPayableNote_ID;
		private string paymentVoucher_ID;
		private string chequeRegister_ID;
		private string debitNote_ID;
		private DateTime alocatedDate;
		private decimal alocatedAmount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_bpsPaymentSettle class.
		/// </summary>
		public tbl_bpsPaymentSettle() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_bpsPaymentSettle class.
		/// </summary>
		public tbl_bpsPaymentSettle(string accountPayableNote_ID, string paymentVoucher_ID, string chequeRegister_ID, string debitNote_ID, DateTime alocatedDate, decimal alocatedAmount) {
			this.accountPayableNote_ID = accountPayableNote_ID;
			this.paymentVoucher_ID = paymentVoucher_ID;
			this.chequeRegister_ID = chequeRegister_ID;
			this.debitNote_ID = debitNote_ID;
			this.alocatedDate = alocatedDate;
			this.alocatedAmount = alocatedAmount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the AccountPayableNote_ID value.
		/// </summary>
		public string AccountPayableNote_ID {
			get { return accountPayableNote_ID; }
			set { accountPayableNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentVoucher_ID value.
		/// </summary>
		public string PaymentVoucher_ID {
			get { return paymentVoucher_ID; }
			set { paymentVoucher_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeRegister_ID value.
		/// </summary>
		public string ChequeRegister_ID {
			get { return chequeRegister_ID; }
			set { chequeRegister_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DebitNote_ID value.
		/// </summary>
		public string DebitNote_ID {
			get { return debitNote_ID; }
			set { debitNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AlocatedDate value.
		/// </summary>
		public DateTime AlocatedDate {
			get { return alocatedDate; }
			set { alocatedDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the AlocatedAmount value.
		/// </summary>
		public decimal AlocatedAmount {
			get { return alocatedAmount; }
			set { alocatedAmount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_bpsPaymentSettle table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPaymentSettleInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alocatedDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@alocatedAmount", SqlDbType.Decimal,9);
 
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
			scom.Parameters["@alocatedDate"].Value = alocatedDate;
			scom.Parameters["@alocatedAmount"].Value = alocatedAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_bpsPaymentSettle table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPaymentSettleUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@alocatedDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@alocatedAmount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
			scom.Parameters["@alocatedDate"].Value = alocatedDate;
			scom.Parameters["@alocatedAmount"].Value = alocatedAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_bpsPaymentSettle table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPaymentSettleDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
 
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
 
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_bpsPaymentSettle table.
		/// </summary>
		public static tbl_bpsPaymentSettle Select(string accountPayableNote_ID_Incoming, string paymentVoucher_ID_Incoming, string chequeRegister_ID_Incoming, string debitNote_ID_Incoming){

			tbl_bpsPaymentSettle tbl_bpsPaymentSettleins = new tbl_bpsPaymentSettle();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPaymentSettleSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID_Incoming;
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID_Incoming;
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID_Incoming;
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_bpsPaymentSettleins = Maketbl_bpsPaymentSettle(dataReader);
				} else {
					tbl_bpsPaymentSettleins = null;
				}
			}
			scon.Close();
			return tbl_bpsPaymentSettleins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_bpsPaymentSettle table.
		/// </summary>
		public static List<tbl_bpsPaymentSettle> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_bpsPaymentSettleSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_bpsPaymentSettle> tbl_bpsPaymentSettleList = new List<tbl_bpsPaymentSettle>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_bpsPaymentSettle tbl_bpsPaymentSettle = Maketbl_bpsPaymentSettle(dataReader);
					tbl_bpsPaymentSettleList.Add(tbl_bpsPaymentSettle);
				}
			}
			scon.Close();
			return tbl_bpsPaymentSettleList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_bpsPaymentSettle class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_bpsPaymentSettle Maketbl_bpsPaymentSettle(SqlDataReader dataReader) {
			tbl_bpsPaymentSettle tbl_bpsPaymentSettle = new tbl_bpsPaymentSettle();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_bpsPaymentSettle.AccountPayableNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_bpsPaymentSettle.PaymentVoucher_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_bpsPaymentSettle.ChequeRegister_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_bpsPaymentSettle.DebitNote_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_bpsPaymentSettle.AlocatedDate = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_bpsPaymentSettle.AlocatedAmount = dataReader.GetDecimal(5);
			}

			return tbl_bpsPaymentSettle;
		}
		/// <summary>
		/// This makes tbl_bpsPaymentSettle datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_bpsPaymentSettle object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_bpsPaymentSettle  tbl_bpsPaymentSettle   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_accountPayableNote_ID = new DataColumn("accountPayableNote_ID" , typeof(string));
			DataColumn col_paymentVoucher_ID = new DataColumn("paymentVoucher_ID" , typeof(string));
			DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID" , typeof(string));
			DataColumn col_debitNote_ID = new DataColumn("debitNote_ID" , typeof(string));
			DataColumn col_alocatedDate = new DataColumn("alocatedDate" , typeof(DateTime));
			DataColumn col_alocatedAmount = new DataColumn("alocatedAmount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_accountPayableNote_ID,col_paymentVoucher_ID,col_chequeRegister_ID,col_debitNote_ID,col_alocatedDate,col_alocatedAmount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_bpsPaymentSettle datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_bpsPaymentSettle object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_bpsPaymentSettle user) {
		DataRow drow = dt.NewRow();
		
			drow["accountPayableNote_ID"] = user.accountPayableNote_ID;
			drow["paymentVoucher_ID"] = user.paymentVoucher_ID;
			drow["chequeRegister_ID"] = user.chequeRegister_ID;
			drow["debitNote_ID"] = user.debitNote_ID;
			drow["alocatedDate"] = user.alocatedDate;
			drow["alocatedAmount"] = user.alocatedAmount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
