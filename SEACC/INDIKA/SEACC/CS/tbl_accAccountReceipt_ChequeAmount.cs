using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accAccountReceipt_ChequeAmount {
		#region Fields
		private string accountReceipt_ID;
		private string chequeAmount_glCode;
		private decimal chequeAmount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accAccountReceipt_ChequeAmount class.
		/// </summary>
		public tbl_accAccountReceipt_ChequeAmount() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accAccountReceipt_ChequeAmount class.
		/// </summary>
		public tbl_accAccountReceipt_ChequeAmount(string accountReceipt_ID, string chequeAmount_glCode, decimal chequeAmount) {
			this.accountReceipt_ID = accountReceipt_ID;
			this.chequeAmount_glCode = chequeAmount_glCode;
			this.chequeAmount = chequeAmount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the AccountReceipt_ID value.
		/// </summary>
		public string AccountReceipt_ID {
			get { return accountReceipt_ID; }
			set { accountReceipt_ID = value; }
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
		/// Saves a record to the tbl_accAccountReceipt_ChequeAmount table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountReceipt_ChequeAmountInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@accountReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeAmount_glCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
 
			scom.Parameters["@accountReceipt_ID"].Value = accountReceipt_ID;
			scom.Parameters["@chequeAmount_glCode"].Value = chequeAmount_glCode;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accAccountReceipt_ChequeAmount table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountReceipt_ChequeAmountUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@accountReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeAmount_glCode", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeAmount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@accountReceipt_ID"].Value = accountReceipt_ID;
			scom.Parameters["@chequeAmount_glCode"].Value = chequeAmount_glCode;
			scom.Parameters["@chequeAmount"].Value = chequeAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accAccountReceipt_ChequeAmount table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountReceipt_ChequeAmountDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@accountReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeAmount_glCode", SqlDbType.VarChar,20);
			scom.Parameters["@accountReceipt_ID"].Value = accountReceipt_ID;
 
			scom.Parameters["@chequeAmount_glCode"].Value = chequeAmount_glCode;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountReceipt_ChequeAmount table by a foreign key.
		/// </summary>
		public static void DeleteAllByAccountReceipt_ID(string accountReceipt_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountReceipt_ChequeAmountDeleteAllByAccountReceipt_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@accountReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@accountReceipt_ID"].Value = accountReceipt_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accAccountReceipt_ChequeAmount table.
		/// </summary>
		public static tbl_accAccountReceipt_ChequeAmount Select(string accountReceipt_ID_Incoming, string chequeAmount_glCode_Incoming){

			tbl_accAccountReceipt_ChequeAmount tbl_accAccountReceipt_ChequeAmountins = new tbl_accAccountReceipt_ChequeAmount();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountReceipt_ChequeAmountSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@accountReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@chequeAmount_glCode", SqlDbType.VarChar,20);
			scom.Parameters["@accountReceipt_ID"].Value = accountReceipt_ID_Incoming;
			scom.Parameters["@chequeAmount_glCode"].Value = chequeAmount_glCode_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accAccountReceipt_ChequeAmountins = Maketbl_accAccountReceipt_ChequeAmount(dataReader);
				} else {
					tbl_accAccountReceipt_ChequeAmountins = null;
				}
			}
			scon.Close();
			return tbl_accAccountReceipt_ChequeAmountins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountReceipt_ChequeAmount table.
		/// </summary>
		public static List<tbl_accAccountReceipt_ChequeAmount> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountReceipt_ChequeAmountSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accAccountReceipt_ChequeAmount> tbl_accAccountReceipt_ChequeAmountList = new List<tbl_accAccountReceipt_ChequeAmount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accAccountReceipt_ChequeAmount tbl_accAccountReceipt_ChequeAmount = Maketbl_accAccountReceipt_ChequeAmount(dataReader);
					tbl_accAccountReceipt_ChequeAmountList.Add(tbl_accAccountReceipt_ChequeAmount);
				}
			}
			scon.Close();
			return tbl_accAccountReceipt_ChequeAmountList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accAccountReceipt_ChequeAmount table by a foreign key.
		/// </summary>
		public static List<tbl_accAccountReceipt_ChequeAmount> SelectAllByAccountReceipt_ID(string accountReceipt_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accAccountReceipt_ChequeAmountSelectAllByAccountReceipt_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@accountReceipt_ID", SqlDbType.VarChar,20);
			scom.Parameters["@accountReceipt_ID"].Value = accountReceipt_ID;
				List<tbl_accAccountReceipt_ChequeAmount> tbl_accAccountReceipt_ChequeAmountList = new List<tbl_accAccountReceipt_ChequeAmount>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accAccountReceipt_ChequeAmount tbl_accAccountReceipt_ChequeAmount = Maketbl_accAccountReceipt_ChequeAmount(dataReader);
					tbl_accAccountReceipt_ChequeAmountList.Add(tbl_accAccountReceipt_ChequeAmount);
				}
			}
			scon.Close();
			return tbl_accAccountReceipt_ChequeAmountList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accAccountReceipt_ChequeAmount class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accAccountReceipt_ChequeAmount Maketbl_accAccountReceipt_ChequeAmount(SqlDataReader dataReader) {
			tbl_accAccountReceipt_ChequeAmount tbl_accAccountReceipt_ChequeAmount = new tbl_accAccountReceipt_ChequeAmount();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accAccountReceipt_ChequeAmount.AccountReceipt_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accAccountReceipt_ChequeAmount.ChequeAmount_glCode = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accAccountReceipt_ChequeAmount.ChequeAmount = dataReader.GetDecimal(2);
			}

			return tbl_accAccountReceipt_ChequeAmount;
		}
		/// <summary>
		/// This makes tbl_accAccountReceipt_ChequeAmount datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accAccountReceipt_ChequeAmount object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accAccountReceipt_ChequeAmount  tbl_accAccountReceipt_ChequeAmount   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_accountReceipt_ID = new DataColumn("accountReceipt_ID" , typeof(string));
			DataColumn col_chequeAmount_glCode = new DataColumn("chequeAmount_glCode" , typeof(string));
			DataColumn col_chequeAmount = new DataColumn("chequeAmount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_accountReceipt_ID,col_chequeAmount_glCode,col_chequeAmount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accAccountReceipt_ChequeAmount datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accAccountReceipt_ChequeAmount object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accAccountReceipt_ChequeAmount user) {
		DataRow drow = dt.NewRow();
		
			drow["accountReceipt_ID"] = user.accountReceipt_ID;
			drow["chequeAmount_glCode"] = user.chequeAmount_glCode;
			drow["chequeAmount"] = user.chequeAmount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
