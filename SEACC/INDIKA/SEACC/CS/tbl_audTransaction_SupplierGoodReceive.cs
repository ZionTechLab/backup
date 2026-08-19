using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_audTransaction_SupplierGoodReceive {
		#region Fields
		private string externalGoodReceivedNote_ID;
		private string user_ID;
		private bool bIsCanceled;
		private string terminal_ID;
		private DateTime auditDate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_audTransaction_SupplierGoodReceive class.
		/// </summary>
		public tbl_audTransaction_SupplierGoodReceive() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_audTransaction_SupplierGoodReceive class.
		/// </summary>
		public tbl_audTransaction_SupplierGoodReceive(string externalGoodReceivedNote_ID, string user_ID, bool bIsCanceled, string terminal_ID, DateTime auditDate) {
			this.externalGoodReceivedNote_ID = externalGoodReceivedNote_ID;
			this.user_ID = user_ID;
			this.bIsCanceled = bIsCanceled;
			this.terminal_ID = terminal_ID;
			this.auditDate = auditDate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ExternalGoodReceivedNote_ID value.
		/// </summary>
		public string ExternalGoodReceivedNote_ID {
			get { return externalGoodReceivedNote_ID; }
			set { externalGoodReceivedNote_ID = value; }
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
		/// Saves a record to the tbl_audTransaction_SupplierGoodReceive table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_SupplierGoodReceiveInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@auditDate", SqlDbType.DateTime,8);
 
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@auditDate"].Value = auditDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_audTransaction_SupplierGoodReceive table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_SupplierGoodReceiveUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@auditDate", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@auditDate"].Value = auditDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_audTransaction_SupplierGoodReceive table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_SupplierGoodReceiveDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
 
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransaction_SupplierGoodReceive table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_SupplierGoodReceiveDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransaction_SupplierGoodReceive table by a foreign key.
		/// </summary>
		public static void DeleteAllByExternalGoodReceivedNote_ID(string externalGoodReceivedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_SupplierGoodReceiveDeleteAllByExternalGoodReceivedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransaction_SupplierGoodReceive table by a foreign key.
		/// </summary>
		public static void DeleteAllByTerminal_ID(string terminal_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_SupplierGoodReceiveDeleteAllByTerminal_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_audTransaction_SupplierGoodReceive table.
		/// </summary>
		public static tbl_audTransaction_SupplierGoodReceive Select(string externalGoodReceivedNote_ID_Incoming, string user_ID_Incoming, bool bIsCanceled_Incoming){

			tbl_audTransaction_SupplierGoodReceive tbl_audTransaction_SupplierGoodReceiveins = new tbl_audTransaction_SupplierGoodReceive();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_SupplierGoodReceiveSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID_Incoming;
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_audTransaction_SupplierGoodReceiveins = Maketbl_audTransaction_SupplierGoodReceive(dataReader);
				} else {
					tbl_audTransaction_SupplierGoodReceiveins = null;
				}
			}
			scon.Close();
			return tbl_audTransaction_SupplierGoodReceiveins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransaction_SupplierGoodReceive table.
		/// </summary>
		public static List<tbl_audTransaction_SupplierGoodReceive> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_SupplierGoodReceiveSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_audTransaction_SupplierGoodReceive> tbl_audTransaction_SupplierGoodReceiveList = new List<tbl_audTransaction_SupplierGoodReceive>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransaction_SupplierGoodReceive tbl_audTransaction_SupplierGoodReceive = Maketbl_audTransaction_SupplierGoodReceive(dataReader);
					tbl_audTransaction_SupplierGoodReceiveList.Add(tbl_audTransaction_SupplierGoodReceive);
				}
			}
			scon.Close();
			return tbl_audTransaction_SupplierGoodReceiveList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransaction_SupplierGoodReceive table by a foreign key.
		/// </summary>
		public static List<tbl_audTransaction_SupplierGoodReceive> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_SupplierGoodReceiveSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_audTransaction_SupplierGoodReceive> tbl_audTransaction_SupplierGoodReceiveList = new List<tbl_audTransaction_SupplierGoodReceive>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransaction_SupplierGoodReceive tbl_audTransaction_SupplierGoodReceive = Maketbl_audTransaction_SupplierGoodReceive(dataReader);
					tbl_audTransaction_SupplierGoodReceiveList.Add(tbl_audTransaction_SupplierGoodReceive);
				}
			}
			scon.Close();
			return tbl_audTransaction_SupplierGoodReceiveList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransaction_SupplierGoodReceive table by a foreign key.
		/// </summary>
		public static List<tbl_audTransaction_SupplierGoodReceive> SelectAllByExternalGoodReceivedNote_ID(string externalGoodReceivedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_SupplierGoodReceiveSelectAllByExternalGoodReceivedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
				List<tbl_audTransaction_SupplierGoodReceive> tbl_audTransaction_SupplierGoodReceiveList = new List<tbl_audTransaction_SupplierGoodReceive>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransaction_SupplierGoodReceive tbl_audTransaction_SupplierGoodReceive = Maketbl_audTransaction_SupplierGoodReceive(dataReader);
					tbl_audTransaction_SupplierGoodReceiveList.Add(tbl_audTransaction_SupplierGoodReceive);
				}
			}
			scon.Close();
			return tbl_audTransaction_SupplierGoodReceiveList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransaction_SupplierGoodReceive table by a foreign key.
		/// </summary>
		public static List<tbl_audTransaction_SupplierGoodReceive> SelectAllByTerminal_ID(string terminal_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransaction_SupplierGoodReceiveSelectAllByTerminal_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
				List<tbl_audTransaction_SupplierGoodReceive> tbl_audTransaction_SupplierGoodReceiveList = new List<tbl_audTransaction_SupplierGoodReceive>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransaction_SupplierGoodReceive tbl_audTransaction_SupplierGoodReceive = Maketbl_audTransaction_SupplierGoodReceive(dataReader);
					tbl_audTransaction_SupplierGoodReceiveList.Add(tbl_audTransaction_SupplierGoodReceive);
				}
			}
			scon.Close();
			return tbl_audTransaction_SupplierGoodReceiveList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_audTransaction_SupplierGoodReceive class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_audTransaction_SupplierGoodReceive Maketbl_audTransaction_SupplierGoodReceive(SqlDataReader dataReader) {
			tbl_audTransaction_SupplierGoodReceive tbl_audTransaction_SupplierGoodReceive = new tbl_audTransaction_SupplierGoodReceive();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_audTransaction_SupplierGoodReceive.ExternalGoodReceivedNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_audTransaction_SupplierGoodReceive.User_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_audTransaction_SupplierGoodReceive.BIsCanceled = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_audTransaction_SupplierGoodReceive.Terminal_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_audTransaction_SupplierGoodReceive.AuditDate = dataReader.GetDateTime(4);
			}

			return tbl_audTransaction_SupplierGoodReceive;
		}
		/// <summary>
		/// This makes tbl_audTransaction_SupplierGoodReceive datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_audTransaction_SupplierGoodReceive object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_audTransaction_SupplierGoodReceive  tbl_audTransaction_SupplierGoodReceive   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_externalGoodReceivedNote_ID = new DataColumn("externalGoodReceivedNote_ID" , typeof(string));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_bIsCanceled = new DataColumn("bIsCanceled" , typeof(bool));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
			DataColumn col_auditDate = new DataColumn("auditDate" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_externalGoodReceivedNote_ID,col_user_ID,col_bIsCanceled,col_terminal_ID,col_auditDate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_audTransaction_SupplierGoodReceive datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_audTransaction_SupplierGoodReceive object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_audTransaction_SupplierGoodReceive user) {
		DataRow drow = dt.NewRow();
		
			drow["externalGoodReceivedNote_ID"] = user.externalGoodReceivedNote_ID;
			drow["user_ID"] = user.user_ID;
			drow["bIsCanceled"] = user.bIsCanceled;
			drow["terminal_ID"] = user.terminal_ID;
			drow["auditDate"] = user.auditDate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
