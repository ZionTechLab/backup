using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_audTransactioin_SalesReturned {
		#region Fields
		private string salesReturnedNote_ID;
		private string user_ID;
		private bool bIsCanceled;
		private string terminal_ID;
		private DateTime auditDate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_audTransactioin_SalesReturned class.
		/// </summary>
		public tbl_audTransactioin_SalesReturned() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_audTransactioin_SalesReturned class.
		/// </summary>
		public tbl_audTransactioin_SalesReturned(string salesReturnedNote_ID, string user_ID, bool bIsCanceled, string terminal_ID, DateTime auditDate) {
			this.salesReturnedNote_ID = salesReturnedNote_ID;
			this.user_ID = user_ID;
			this.bIsCanceled = bIsCanceled;
			this.terminal_ID = terminal_ID;
			this.auditDate = auditDate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SalesReturnedNote_ID value.
		/// </summary>
		public string SalesReturnedNote_ID {
			get { return salesReturnedNote_ID; }
			set { salesReturnedNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BIsCanceled value.
		/// </summary>
		public bool BIsCanceled {
			get { return bIsCanceled; }
			set { bIsCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the Terminal_ID value.
		/// </summary>
		public string Terminal_ID {
			get { return terminal_ID; }
			set { terminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AuditDate value.
		/// </summary>
		public DateTime AuditDate {
			get { return auditDate; }
			set { auditDate = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_audTransactioin_SalesReturned table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_SalesReturnedInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@auditDate", SqlDbType.DateTime,8);
 
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@auditDate"].Value = auditDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_audTransactioin_SalesReturned table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_SalesReturnedUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@auditDate", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@auditDate"].Value = auditDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_audTransactioin_SalesReturned table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_SalesReturnedDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
 
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_SalesReturned table by a foreign key.
		/// </summary>
		public static void DeleteAllByTerminal_ID(string terminal_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_SalesReturnedDeleteAllByTerminal_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_SalesReturned table by a foreign key.
		/// </summary>
		public static void DeleteAllBySalesReturnedNote_ID(string salesReturnedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_SalesReturnedDeleteAllBySalesReturnedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_SalesReturned table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_SalesReturnedDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_audTransactioin_SalesReturned table.
		/// </summary>
		public static tbl_audTransactioin_SalesReturned Select(string salesReturnedNote_ID_Incoming, string user_ID_Incoming, bool bIsCanceled_Incoming){

			tbl_audTransactioin_SalesReturned tbl_audTransactioin_SalesReturnedins = new tbl_audTransactioin_SalesReturned();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_SalesReturnedSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID_Incoming;
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_audTransactioin_SalesReturnedins = Maketbl_audTransactioin_SalesReturned(dataReader);
				} else {
					tbl_audTransactioin_SalesReturnedins = null;
				}
			}
			scon.Close();
			return tbl_audTransactioin_SalesReturnedins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_SalesReturned table.
		/// </summary>
		public static List<tbl_audTransactioin_SalesReturned> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_SalesReturnedSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_audTransactioin_SalesReturned> tbl_audTransactioin_SalesReturnedList = new List<tbl_audTransactioin_SalesReturned>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransactioin_SalesReturned tbl_audTransactioin_SalesReturned = Maketbl_audTransactioin_SalesReturned(dataReader);
					tbl_audTransactioin_SalesReturnedList.Add(tbl_audTransactioin_SalesReturned);
				}
			}
			scon.Close();
			return tbl_audTransactioin_SalesReturnedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_SalesReturned table by a foreign key.
		/// </summary>
		public static List<tbl_audTransactioin_SalesReturned> SelectAllByTerminal_ID(string terminal_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_SalesReturnedSelectAllByTerminal_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
				List<tbl_audTransactioin_SalesReturned> tbl_audTransactioin_SalesReturnedList = new List<tbl_audTransactioin_SalesReturned>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransactioin_SalesReturned tbl_audTransactioin_SalesReturned = Maketbl_audTransactioin_SalesReturned(dataReader);
					tbl_audTransactioin_SalesReturnedList.Add(tbl_audTransactioin_SalesReturned);
				}
			}
			scon.Close();
			return tbl_audTransactioin_SalesReturnedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_SalesReturned table by a foreign key.
		/// </summary>
		public static List<tbl_audTransactioin_SalesReturned> SelectAllBySalesReturnedNote_ID(string salesReturnedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_SalesReturnedSelectAllBySalesReturnedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesReturnedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesReturnedNote_ID"].Value = salesReturnedNote_ID;
				List<tbl_audTransactioin_SalesReturned> tbl_audTransactioin_SalesReturnedList = new List<tbl_audTransactioin_SalesReturned>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransactioin_SalesReturned tbl_audTransactioin_SalesReturned = Maketbl_audTransactioin_SalesReturned(dataReader);
					tbl_audTransactioin_SalesReturnedList.Add(tbl_audTransactioin_SalesReturned);
				}
			}
			scon.Close();
			return tbl_audTransactioin_SalesReturnedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_SalesReturned table by a foreign key.
		/// </summary>
		public static List<tbl_audTransactioin_SalesReturned> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_SalesReturnedSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_audTransactioin_SalesReturned> tbl_audTransactioin_SalesReturnedList = new List<tbl_audTransactioin_SalesReturned>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransactioin_SalesReturned tbl_audTransactioin_SalesReturned = Maketbl_audTransactioin_SalesReturned(dataReader);
					tbl_audTransactioin_SalesReturnedList.Add(tbl_audTransactioin_SalesReturned);
				}
			}
			scon.Close();
			return tbl_audTransactioin_SalesReturnedList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_audTransactioin_SalesReturned class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_audTransactioin_SalesReturned Maketbl_audTransactioin_SalesReturned(SqlDataReader dataReader) {
			tbl_audTransactioin_SalesReturned tbl_audTransactioin_SalesReturned = new tbl_audTransactioin_SalesReturned();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_audTransactioin_SalesReturned.SalesReturnedNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_audTransactioin_SalesReturned.User_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_audTransactioin_SalesReturned.BIsCanceled = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_audTransactioin_SalesReturned.Terminal_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_audTransactioin_SalesReturned.AuditDate = dataReader.GetDateTime(4);
			}

			return tbl_audTransactioin_SalesReturned;
		}
		/// <summary>
		/// This makes tbl_audTransactioin_SalesReturned datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_audTransactioin_SalesReturned object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_audTransactioin_SalesReturned  tbl_audTransactioin_SalesReturned   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_salesReturnedNote_ID = new DataColumn("salesReturnedNote_ID" , typeof(string));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_bIsCanceled = new DataColumn("bIsCanceled" , typeof(bool));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
			DataColumn col_auditDate = new DataColumn("auditDate" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_salesReturnedNote_ID,col_user_ID,col_bIsCanceled,col_terminal_ID,col_auditDate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_audTransactioin_SalesReturned datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_audTransactioin_SalesReturned object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_audTransactioin_SalesReturned user) {
		DataRow drow = dt.NewRow();
		
			drow["salesReturnedNote_ID"] = user.salesReturnedNote_ID;
			drow["user_ID"] = user.user_ID;
			drow["bIsCanceled"] = user.bIsCanceled;
			drow["terminal_ID"] = user.terminal_ID;
			drow["auditDate"] = user.auditDate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
