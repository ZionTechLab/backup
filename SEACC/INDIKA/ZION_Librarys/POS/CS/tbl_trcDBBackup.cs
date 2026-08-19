using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_trcDBBackup {
		#region Fields
		private Int64 transaction_ID;
		private DateTime backupDate;
		private string backupLocation;
		private string user_ID;
		private string terminal_ID;
		private bool isAutoBackup;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_trcDBBackup class.
		/// </summary>
		public tbl_trcDBBackup() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_trcDBBackup class.
		/// </summary>
		public tbl_trcDBBackup(Int64 transaction_ID, DateTime backupDate, string backupLocation, string user_ID, string terminal_ID, bool isAutoBackup) {
			this.transaction_ID = transaction_ID;
			this.backupDate = backupDate;
			this.backupLocation = backupLocation;
			this.user_ID = user_ID;
			this.terminal_ID = terminal_ID;
			this.isAutoBackup = isAutoBackup;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Transaction_ID value.
		/// </summary>
		public Int64 Transaction_ID {
			get { return transaction_ID; }
			set { transaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BackupDate value.
		/// </summary>
		public DateTime BackupDate {
			get { return backupDate; }
			set { backupDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the BackupLocation value.
		/// </summary>
		public string BackupLocation {
			get { return backupLocation; }
			set { backupLocation = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Terminal_ID value.
		/// </summary>
		public string Terminal_ID {
			get { return terminal_ID; }
			set { terminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsAutoBackup value.
		/// </summary>
		public bool IsAutoBackup {
			get { return isAutoBackup; }
			set { isAutoBackup = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_trcDBBackup table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcDBBackupInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.BigInt,8);
			scom.Parameters.Add("@backupDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@backupLocation", SqlDbType.VarChar,100);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isAutoBackup", SqlDbType.Bit,1);
 
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@backupDate"].Value = backupDate;
			scom.Parameters["@backupLocation"].Value = backupLocation;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@isAutoBackup"].Value = isAutoBackup;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_trcDBBackup table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcDBBackupUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.BigInt,8);
			scom.Parameters.Add("@backupDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@backupLocation", SqlDbType.VarChar,100);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isAutoBackup", SqlDbType.Bit,1);
 
 
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@backupDate"].Value = backupDate;
			scom.Parameters["@backupLocation"].Value = backupLocation;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@terminal_ID"].Value = terminal_ID;
			scom.Parameters["@isAutoBackup"].Value = isAutoBackup;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_trcDBBackup table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcDBBackupDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.BigInt,8);
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_trcDBBackup table.
		/// </summary>
		public static tbl_trcDBBackup Select(Int64 transaction_ID_Incoming){

			tbl_trcDBBackup tbl_trcDBBackupins = new tbl_trcDBBackup();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcDBBackupSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.BigInt,8);
			scom.Parameters["@transaction_ID"].Value = transaction_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_trcDBBackupins = Maketbl_trcDBBackup(dataReader);
				} else {
					tbl_trcDBBackupins = null;
				}
			}
			scon.Close();
			return tbl_trcDBBackupins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_trcDBBackup table.
		/// </summary>
		public static List<tbl_trcDBBackup> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_trcDBBackupSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_trcDBBackup> tbl_trcDBBackupList = new List<tbl_trcDBBackup>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_trcDBBackup tbl_trcDBBackup = Maketbl_trcDBBackup(dataReader);
					tbl_trcDBBackupList.Add(tbl_trcDBBackup);
				}
			}
			scon.Close();
			return tbl_trcDBBackupList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_trcDBBackup class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_trcDBBackup Maketbl_trcDBBackup(SqlDataReader dataReader) {
			tbl_trcDBBackup tbl_trcDBBackup = new tbl_trcDBBackup();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_trcDBBackup.Transaction_ID = dataReader.GetInt64(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_trcDBBackup.BackupDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_trcDBBackup.BackupLocation = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_trcDBBackup.User_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_trcDBBackup.Terminal_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_trcDBBackup.IsAutoBackup = dataReader.GetBoolean(5);
			}

			return tbl_trcDBBackup;
		}
		/// <summary>
		/// This makes tbl_trcDBBackup datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_trcDBBackup object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_trcDBBackup  tbl_trcDBBackup   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_transaction_ID = new DataColumn("transaction_ID" , typeof(int));
			DataColumn col_backupDate = new DataColumn("backupDate" , typeof(DateTime));
			DataColumn col_backupLocation = new DataColumn("backupLocation" , typeof(string));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_terminal_ID = new DataColumn("terminal_ID" , typeof(string));
			DataColumn col_isAutoBackup = new DataColumn("isAutoBackup" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_transaction_ID,col_backupDate,col_backupLocation,col_user_ID,col_terminal_ID,col_isAutoBackup,});		return dt;
		}
		/// <summary>
		/// This fills tbl_trcDBBackup datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_trcDBBackup object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_trcDBBackup user) {
		DataRow drow = dt.NewRow();
		
			drow["transaction_ID"] = user.transaction_ID;
			drow["backupDate"] = user.backupDate;
			drow["backupLocation"] = user.backupLocation;
			drow["user_ID"] = user.user_ID;
			drow["terminal_ID"] = user.terminal_ID;
			drow["isAutoBackup"] = user.isAutoBackup;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
