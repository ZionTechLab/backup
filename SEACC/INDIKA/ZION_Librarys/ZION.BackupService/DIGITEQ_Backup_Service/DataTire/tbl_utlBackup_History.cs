using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlBackup_History {
		#region Fields
		private int backUpSet_ID;
		private int shedule_ID;
		private DateTime backup_Time;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlBackup_History class.
		/// </summary>
		public tbl_utlBackup_History() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlBackup_History class.
		/// </summary>
		public tbl_utlBackup_History(int backUpSet_ID, int shedule_ID, DateTime backup_Time) {
			this.backUpSet_ID = backUpSet_ID;
			this.shedule_ID = shedule_ID;
			this.backup_Time = backup_Time;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the BackUpSet_ID value.
		/// </summary>
		public int BackUpSet_ID {
			get { return backUpSet_ID; }
			set { backUpSet_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Shedule_ID value.
		/// </summary>
		public int Shedule_ID {
			get { return shedule_ID; }
			set { shedule_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Backup_Time value.
		/// </summary>
		public DateTime Backup_Time {
			get { return backup_Time; }
			set { backup_Time = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_utlBackup_History table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlBackup_HistoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@backUpSet_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@shedule_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@backup_Time", SqlDbType.DateTime,8);
 
			scom.Parameters["@backUpSet_ID"].Value = backUpSet_ID;
			scom.Parameters["@shedule_ID"].Value = shedule_ID;
			scom.Parameters["@backup_Time"].Value = backup_Time;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlBackup_History table.
		/// </summary>
		public static List<tbl_utlBackup_History> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlBackup_HistorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlBackup_History> tbl_utlBackup_HistoryList = new List<tbl_utlBackup_History>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlBackup_History tbl_utlBackup_History = Maketbl_utlBackup_History(dataReader);
					tbl_utlBackup_HistoryList.Add(tbl_utlBackup_History);
				}
			}
			scon.Close();
			return tbl_utlBackup_HistoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlBackup_History class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlBackup_History Maketbl_utlBackup_History(SqlDataReader dataReader) {
			tbl_utlBackup_History tbl_utlBackup_History = new tbl_utlBackup_History();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlBackup_History.BackUpSet_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlBackup_History.Shedule_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlBackup_History.Backup_Time = dataReader.GetDateTime(2);
			}

			return tbl_utlBackup_History;
		}
		/// <summary>
		/// This makes tbl_utlBackup_History datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlBackup_History object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlBackup_History  tbl_utlBackup_History   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_backUpSet_ID = new DataColumn("backUpSet_ID" , typeof(int));
			DataColumn col_shedule_ID = new DataColumn("shedule_ID" , typeof(int));
			DataColumn col_backup_Time = new DataColumn("backup_Time" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_backUpSet_ID,col_shedule_ID,col_backup_Time,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlBackup_History datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlBackup_History object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlBackup_History user) {
		DataRow drow = dt.NewRow();
		
			drow["backUpSet_ID"] = user.backUpSet_ID;
			drow["shedule_ID"] = user.shedule_ID;
			drow["backup_Time"] = user.backup_Time;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
