using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_audTransactioin_ChequeRegister {
		#region Fields
		private string chequeRegister_ID;
		private string user_ID;
		private bool bIsCanceled;
		private string terminal_ID;
		private DateTime auditDate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_audTransactioin_ChequeRegister class.
		/// </summary>
		public tbl_audTransactioin_ChequeRegister() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_audTransactioin_ChequeRegister class.
		/// </summary>
		public tbl_audTransactioin_ChequeRegister(string chequeRegister_ID, string user_ID, bool bIsCanceled, string terminal_ID, DateTime auditDate) {
			this.chequeRegister_ID = chequeRegister_ID;
			this.user_ID = user_ID;
			this.bIsCanceled = bIsCanceled;
			this.terminal_ID = terminal_ID;
			this.auditDate = auditDate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ChequeRegister_ID value.
		/// </summary>
		public string ChequeRegister_ID {
			get { return chequeRegister_ID; }
			set { chequeRegister_ID = value; }
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
		/// Saves a record to the tbl_audTransactioin_ChequeRegister table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_ChequeRegisterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@auditDate", SqlDbType.DateTime,8);
 
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@auditDate"].Value = auditDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_audTransactioin_ChequeRegister table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_ChequeRegisterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@auditDate", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@auditDate"].Value = auditDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_audTransactioin_ChequeRegister table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_ChequeRegisterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_ChequeRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByTerminal_ID(string terminal_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_ChequeRegisterDeleteAllByTerminal_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_ChequeRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_ChequeRegisterDeleteAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_ChequeRegister table by a foreign key.
		/// </summary>
		public static void DeleteAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_ChequeRegisterDeleteAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_audTransactioin_ChequeRegister table.
		/// </summary>
		public static tbl_audTransactioin_ChequeRegister Select(string chequeRegister_ID_Incoming, string user_ID_Incoming, bool bIsCanceled_Incoming){

			tbl_audTransactioin_ChequeRegister tbl_audTransactioin_ChequeRegisterins = new tbl_audTransactioin_ChequeRegister();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_ChequeRegisterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bIsCanceled", SqlDbType.Bit,1);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID_Incoming;
			scom.Parameters["@user_ID"].Value = user_ID_Incoming;
			scom.Parameters["@bIsCanceled"].Value = bIsCanceled_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_audTransactioin_ChequeRegisterins = Maketbl_audTransactioin_ChequeRegister(dataReader);
				} else {
					tbl_audTransactioin_ChequeRegisterins = null;
				}
			}
			scon.Close();
			return tbl_audTransactioin_ChequeRegisterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_ChequeRegister table.
		/// </summary>
		public static List<tbl_audTransactioin_ChequeRegister> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_ChequeRegisterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_audTransactioin_ChequeRegister> tbl_audTransactioin_ChequeRegisterList = new List<tbl_audTransactioin_ChequeRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransactioin_ChequeRegister tbl_audTransactioin_ChequeRegister = Maketbl_audTransactioin_ChequeRegister(dataReader);
					tbl_audTransactioin_ChequeRegisterList.Add(tbl_audTransactioin_ChequeRegister);
				}
			}
			scon.Close();
			return tbl_audTransactioin_ChequeRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_ChequeRegister table by a foreign key.
		/// </summary>
		public static List<tbl_audTransactioin_ChequeRegister> SelectAllByTerminal_ID(string terminal_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_ChequeRegisterSelectAllByTerminal_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
				List<tbl_audTransactioin_ChequeRegister> tbl_audTransactioin_ChequeRegisterList = new List<tbl_audTransactioin_ChequeRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransactioin_ChequeRegister tbl_audTransactioin_ChequeRegister = Maketbl_audTransactioin_ChequeRegister(dataReader);
					tbl_audTransactioin_ChequeRegisterList.Add(tbl_audTransactioin_ChequeRegister);
				}
			}
			scon.Close();
			return tbl_audTransactioin_ChequeRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_ChequeRegister table by a foreign key.
		/// </summary>
		public static List<tbl_audTransactioin_ChequeRegister> SelectAllByUser_ID(string user_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_ChequeRegisterSelectAllByUser_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters["@user_ID"].Value = user_ID;
				List<tbl_audTransactioin_ChequeRegister> tbl_audTransactioin_ChequeRegisterList = new List<tbl_audTransactioin_ChequeRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransactioin_ChequeRegister tbl_audTransactioin_ChequeRegister = Maketbl_audTransactioin_ChequeRegister(dataReader);
					tbl_audTransactioin_ChequeRegisterList.Add(tbl_audTransactioin_ChequeRegister);
				}
			}
			scon.Close();
			return tbl_audTransactioin_ChequeRegisterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_audTransactioin_ChequeRegister table by a foreign key.
		/// </summary>
		public static List<tbl_audTransactioin_ChequeRegister> SelectAllByChequeRegister_ID(string chequeRegister_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_audTransactioin_ChequeRegisterSelectAllByChequeRegister_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@chequeRegister_ID", SqlDbType.VarChar,20);
			scom.Parameters["@chequeRegister_ID"].Value = chequeRegister_ID;
				List<tbl_audTransactioin_ChequeRegister> tbl_audTransactioin_ChequeRegisterList = new List<tbl_audTransactioin_ChequeRegister>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_audTransactioin_ChequeRegister tbl_audTransactioin_ChequeRegister = Maketbl_audTransactioin_ChequeRegister(dataReader);
					tbl_audTransactioin_ChequeRegisterList.Add(tbl_audTransactioin_ChequeRegister);
				}
			}
			scon.Close();
			return tbl_audTransactioin_ChequeRegisterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_audTransactioin_ChequeRegister class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_audTransactioin_ChequeRegister Maketbl_audTransactioin_ChequeRegister(SqlDataReader dataReader) {
			tbl_audTransactioin_ChequeRegister tbl_audTransactioin_ChequeRegister = new tbl_audTransactioin_ChequeRegister();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_audTransactioin_ChequeRegister.ChequeRegister_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_audTransactioin_ChequeRegister.User_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_audTransactioin_ChequeRegister.BIsCanceled = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_audTransactioin_ChequeRegister.Terminal_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_audTransactioin_ChequeRegister.AuditDate = dataReader.GetDateTime(4);
			}

			return tbl_audTransactioin_ChequeRegister;
		}
		/// <summary>
		/// This makes tbl_audTransactioin_ChequeRegister datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_audTransactioin_ChequeRegister object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_audTransactioin_ChequeRegister  tbl_audTransactioin_ChequeRegister   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_chequeRegister_ID = new DataColumn("chequeRegister_ID" , typeof(string));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_bIsCanceled = new DataColumn("bIsCanceled" , typeof(bool));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
			DataColumn col_auditDate = new DataColumn("auditDate" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_chequeRegister_ID,col_user_ID,col_bIsCanceled,col_terminal_ID,col_auditDate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_audTransactioin_ChequeRegister datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_audTransactioin_ChequeRegister object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_audTransactioin_ChequeRegister user) {
		DataRow drow = dt.NewRow();
		
			drow["chequeRegister_ID"] = user.chequeRegister_ID;
			drow["user_ID"] = user.user_ID;
			drow["bIsCanceled"] = user.bIsCanceled;
			drow["terminal_ID"] = user.terminal_ID;
			drow["auditDate"] = user.auditDate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
