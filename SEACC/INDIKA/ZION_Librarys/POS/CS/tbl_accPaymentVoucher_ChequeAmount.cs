using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accPaymentVoucher_ChequeAmount {
		#region Fields
		private string paymentVoucher_ID;
		private string chequeAmount_glCode;
		private decimal chequeAmount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accPaymentVoucher_ChequeAmount class.
		/// </summary>
		public tbl_accPaymentVoucher_ChequeAmount() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accPaymentVoucher_ChequeAmount class.
		/// </summary>
		public tbl_accPaymentVoucher_ChequeAmount(string paymentVoucher_ID, string chequeAmount_glCode, decimal chequeAmount) {
			this.paymentVoucher_ID = paymentVoucher_ID;
			this.chequeAmount_glCode = chequeAmount_glCode;
			this.chequeAmount = chequeAmount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PaymentVoucher_ID value.
		/// </summary>
		public string PaymentVoucher_ID {
			get { return paymentVoucher_ID; }
			set { paymentVoucher_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeAmount_glCode value.
		/// </summary>
		public string ChequeAmount_glCode {
			get { return chequeAmount_glCode; }
			set { chequeAmount_glCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the ChequeAmount value.
		/// </summary>
		public decimal ChequeAmount {
			get { return chequeAmount; }
			set { chequeAmount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accPaymentVoucher_ChequeAmount table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_ChequeAmountInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeAmount_glCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
 
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
			scom.Parameters["@chequeAmount_glCode"].Value = chequeAmount_glCode;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accPaymentVoucher_ChequeAmount table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_ChequeAmountUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeAmount_glCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
			scom.Parameters["@chequeAmount_glCode"].Value = chequeAmount_glCode;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accPaymentVoucher_ChequeAmount table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_ChequeAmountDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeAmount_glCode", SqlDbType.VarChar,20);
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
 
			scom.Parameters["@chequeAmount_glCode"].Value = chequeAmount_glCode;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accPaymentVoucher_ChequeAmount table by a foreign key.
		/// </summary>
		public static void DeleteAllByPaymentVoucher_ID(string paymentVoucher_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_ChequeAmountDeleteAllByPaymentVoucher_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accPaymentVoucher_ChequeAmount table.
		/// </summary>
		public static tbl_accPaymentVoucher_ChequeAmount Select(string paymentVoucher_ID_Incoming, string chequeAmount_glCode_Incoming){

			tbl_accPaymentVoucher_ChequeAmount tbl_accPaymentVoucher_ChequeAmountins = new tbl_accPaymentVoucher_ChequeAmount();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_ChequeAmountSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeAmount_glCode", SqlDbType.VarChar,20);
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID_Incoming;
			scom.Parameters["@chequeAmount_glCode"].Value = chequeAmount_glCode_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accPaymentVoucher_ChequeAmountins = Maketbl_accPaymentVoucher_ChequeAmount(dataReader);
				} else {
					tbl_accPaymentVoucher_ChequeAmountins = null;
				}
			}
			scon.Close();
			return tbl_accPaymentVoucher_ChequeAmountins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accPaymentVoucher_ChequeAmount table.
		/// </summary>
		public static List<tbl_accPaymentVoucher_ChequeAmount> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_ChequeAmountSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accPaymentVoucher_ChequeAmount> tbl_accPaymentVoucher_ChequeAmountList = new List<tbl_accPaymentVoucher_ChequeAmount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accPaymentVoucher_ChequeAmount tbl_accPaymentVoucher_ChequeAmount = Maketbl_accPaymentVoucher_ChequeAmount(dataReader);
					tbl_accPaymentVoucher_ChequeAmountList.Add(tbl_accPaymentVoucher_ChequeAmount);
				}
			}
			scon.Close();
			return tbl_accPaymentVoucher_ChequeAmountList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accPaymentVoucher_ChequeAmount table by a foreign key.
		/// </summary>
		public static List<tbl_accPaymentVoucher_ChequeAmount> SelectAllByPaymentVoucher_ID(string paymentVoucher_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accPaymentVoucher_ChequeAmountSelectAllByPaymentVoucher_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@paymentVoucher_ID", SqlDbType.VarChar,20);
			scom.Parameters["@paymentVoucher_ID"].Value = paymentVoucher_ID;
				List<tbl_accPaymentVoucher_ChequeAmount> tbl_accPaymentVoucher_ChequeAmountList = new List<tbl_accPaymentVoucher_ChequeAmount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accPaymentVoucher_ChequeAmount tbl_accPaymentVoucher_ChequeAmount = Maketbl_accPaymentVoucher_ChequeAmount(dataReader);
					tbl_accPaymentVoucher_ChequeAmountList.Add(tbl_accPaymentVoucher_ChequeAmount);
				}
			}
			scon.Close();
			return tbl_accPaymentVoucher_ChequeAmountList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accPaymentVoucher_ChequeAmount class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accPaymentVoucher_ChequeAmount Maketbl_accPaymentVoucher_ChequeAmount(SqlDataReader dataReader) {
			tbl_accPaymentVoucher_ChequeAmount tbl_accPaymentVoucher_ChequeAmount = new tbl_accPaymentVoucher_ChequeAmount();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accPaymentVoucher_ChequeAmount.PaymentVoucher_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accPaymentVoucher_ChequeAmount.ChequeAmount_glCode = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accPaymentVoucher_ChequeAmount.ChequeAmount = dataReader.GetDecimal(2);
			}

			return tbl_accPaymentVoucher_ChequeAmount;
		}
		/// <summary>
		/// This makes tbl_accPaymentVoucher_ChequeAmount datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accPaymentVoucher_ChequeAmount object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accPaymentVoucher_ChequeAmount  tbl_accPaymentVoucher_ChequeAmount   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_paymentVoucher_ID = new DataColumn("paymentVoucher_ID" , typeof(string));
			DataColumn col_chequeAmount_glCode = new DataColumn("chequeAmount_glCode" , typeof(string));
			DataColumn col_chequeAmount = new DataColumn("chequeAmount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_paymentVoucher_ID,col_chequeAmount_glCode,col_chequeAmount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accPaymentVoucher_ChequeAmount datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accPaymentVoucher_ChequeAmount object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accPaymentVoucher_ChequeAmount user) {
		DataRow drow = dt.NewRow();
		
			drow["paymentVoucher_ID"] = user.paymentVoucher_ID;
			drow["chequeAmount_glCode"] = user.chequeAmount_glCode;
			drow["chequeAmount"] = user.chequeAmount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
