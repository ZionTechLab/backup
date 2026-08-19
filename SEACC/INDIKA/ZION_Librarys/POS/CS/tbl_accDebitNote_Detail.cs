using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accDebitNote_Detail {
		#region Fields
		private string debitNote_ID;
		private string accountPayableNote_ID;
		private string purchaseReturnedNote_ID;
		private decimal settledAmount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accDebitNote_Detail class.
		/// </summary>
		public tbl_accDebitNote_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accDebitNote_Detail class.
		/// </summary>
		public tbl_accDebitNote_Detail(string debitNote_ID, string accountPayableNote_ID, string purchaseReturnedNote_ID, decimal settledAmount) {
			this.debitNote_ID = debitNote_ID;
			this.accountPayableNote_ID = accountPayableNote_ID;
			this.purchaseReturnedNote_ID = purchaseReturnedNote_ID;
			this.settledAmount = settledAmount;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the DebitNote_ID value.
		/// </summary>
		public string DebitNote_ID {
			get { return debitNote_ID; }
			set { debitNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AccountPayableNote_ID value.
		/// </summary>
		public string AccountPayableNote_ID {
			get { return accountPayableNote_ID; }
			set { accountPayableNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PurchaseReturnedNote_ID value.
		/// </summary>
		public string PurchaseReturnedNote_ID {
			get { return purchaseReturnedNote_ID; }
			set { purchaseReturnedNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SettledAmount value.
		/// </summary>
		public decimal SettledAmount {
			get { return settledAmount; }
			set { settledAmount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accDebitNote_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDebitNote_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@purchaseReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@settledAmount", SqlDbType.Decimal,9);
 
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
			scom.Parameters["@purchaseReturnedNote_ID"].Value = purchaseReturnedNote_ID;
			scom.Parameters["@settledAmount"].Value = settledAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accDebitNote_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDebitNote_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@purchaseReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@settledAmount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
			scom.Parameters["@purchaseReturnedNote_ID"].Value = purchaseReturnedNote_ID;
			scom.Parameters["@settledAmount"].Value = settledAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accDebitNote_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDebitNote_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@purchaseReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
 
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
 
			scom.Parameters["@purchaseReturnedNote_ID"].Value = purchaseReturnedNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accDebitNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByAccountPayableNote_ID(string accountPayableNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDebitNote_DetailDeleteAllByAccountPayableNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accDebitNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByPurchaseReturnedNote_ID(string purchaseReturnedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDebitNote_DetailDeleteAllByPurchaseReturnedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@purchaseReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@purchaseReturnedNote_ID"].Value = purchaseReturnedNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accDebitNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByDebitNote_ID(string debitNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDebitNote_DetailDeleteAllByDebitNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accDebitNote_Detail table.
		/// </summary>
		public static tbl_accDebitNote_Detail Select(string debitNote_ID_Incoming, string accountPayableNote_ID_Incoming, string purchaseReturnedNote_ID_Incoming){

			tbl_accDebitNote_Detail tbl_accDebitNote_Detailins = new tbl_accDebitNote_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDebitNote_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@purchaseReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID_Incoming;
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID_Incoming;
			scom.Parameters["@purchaseReturnedNote_ID"].Value = purchaseReturnedNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accDebitNote_Detailins = Maketbl_accDebitNote_Detail(dataReader);
				} else {
					tbl_accDebitNote_Detailins = null;
				}
			}
			scon.Close();
			return tbl_accDebitNote_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accDebitNote_Detail table.
		/// </summary>
		public static List<tbl_accDebitNote_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDebitNote_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accDebitNote_Detail> tbl_accDebitNote_DetailList = new List<tbl_accDebitNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accDebitNote_Detail tbl_accDebitNote_Detail = Maketbl_accDebitNote_Detail(dataReader);
					tbl_accDebitNote_DetailList.Add(tbl_accDebitNote_Detail);
				}
			}
			scon.Close();
			return tbl_accDebitNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accDebitNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accDebitNote_Detail> SelectAllByAccountPayableNote_ID(string accountPayableNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDebitNote_DetailSelectAllByAccountPayableNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@accountPayableNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@accountPayableNote_ID"].Value = accountPayableNote_ID;
				List<tbl_accDebitNote_Detail> tbl_accDebitNote_DetailList = new List<tbl_accDebitNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accDebitNote_Detail tbl_accDebitNote_Detail = Maketbl_accDebitNote_Detail(dataReader);
					tbl_accDebitNote_DetailList.Add(tbl_accDebitNote_Detail);
				}
			}
			scon.Close();
			return tbl_accDebitNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accDebitNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accDebitNote_Detail> SelectAllByPurchaseReturnedNote_ID(string purchaseReturnedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDebitNote_DetailSelectAllByPurchaseReturnedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@purchaseReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@purchaseReturnedNote_ID"].Value = purchaseReturnedNote_ID;
				List<tbl_accDebitNote_Detail> tbl_accDebitNote_DetailList = new List<tbl_accDebitNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accDebitNote_Detail tbl_accDebitNote_Detail = Maketbl_accDebitNote_Detail(dataReader);
					tbl_accDebitNote_DetailList.Add(tbl_accDebitNote_Detail);
				}
			}
			scon.Close();
			return tbl_accDebitNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accDebitNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_accDebitNote_Detail> SelectAllByDebitNote_ID(string debitNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accDebitNote_DetailSelectAllByDebitNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@debitNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@debitNote_ID"].Value = debitNote_ID;
				List<tbl_accDebitNote_Detail> tbl_accDebitNote_DetailList = new List<tbl_accDebitNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accDebitNote_Detail tbl_accDebitNote_Detail = Maketbl_accDebitNote_Detail(dataReader);
					tbl_accDebitNote_DetailList.Add(tbl_accDebitNote_Detail);
				}
			}
			scon.Close();
			return tbl_accDebitNote_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accDebitNote_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accDebitNote_Detail Maketbl_accDebitNote_Detail(SqlDataReader dataReader) {
			tbl_accDebitNote_Detail tbl_accDebitNote_Detail = new tbl_accDebitNote_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accDebitNote_Detail.DebitNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accDebitNote_Detail.AccountPayableNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accDebitNote_Detail.PurchaseReturnedNote_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accDebitNote_Detail.SettledAmount = dataReader.GetDecimal(3);
			}

			return tbl_accDebitNote_Detail;
		}
		/// <summary>
		/// This makes tbl_accDebitNote_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accDebitNote_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accDebitNote_Detail  tbl_accDebitNote_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_debitNote_ID = new DataColumn("debitNote_ID" , typeof(string));
			DataColumn col_accountPayableNote_ID = new DataColumn("accountPayableNote_ID" , typeof(string));
			DataColumn col_purchaseReturnedNote_ID = new DataColumn("purchaseReturnedNote_ID" , typeof(string));
			DataColumn col_settledAmount = new DataColumn("settledAmount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_debitNote_ID,col_accountPayableNote_ID,col_purchaseReturnedNote_ID,col_settledAmount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accDebitNote_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accDebitNote_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accDebitNote_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["debitNote_ID"] = user.debitNote_ID;
			drow["accountPayableNote_ID"] = user.accountPayableNote_ID;
			drow["purchaseReturnedNote_ID"] = user.purchaseReturnedNote_ID;
			drow["settledAmount"] = user.settledAmount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
