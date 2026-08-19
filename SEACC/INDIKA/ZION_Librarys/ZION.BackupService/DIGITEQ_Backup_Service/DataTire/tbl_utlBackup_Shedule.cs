using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlBackup_Shedule {
		#region Fields
		private int shedule_ID;
		private int backUpSet_ID;
		private int sheduleType;
		private DateTime sheduledTime;
		private DateTime lastBackup_Time;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlBackup_Shedule class.
		/// </summary>
		public tbl_utlBackup_Shedule() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlBackup_Shedule class.
		/// </summary>
		public tbl_utlBackup_Shedule(int shedule_ID, int backUpSet_ID, int sheduleType, DateTime sheduledTime, DateTime lastBackup_Time, bool isActive) {
			this.shedule_ID = shedule_ID;
			this.backUpSet_ID = backUpSet_ID;
			this.sheduleType = sheduleType;
			this.sheduledTime = sheduledTime;
			this.lastBackup_Time = lastBackup_Time;
			this.isActive = isActive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Shedule_ID value.
		/// </summary>
		public int Shedule_ID {
			get { return shedule_ID; }
			set { shedule_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BackUpSet_ID value.
		/// </summary>
		public int BackUpSet_ID {
			get { return backUpSet_ID; }
			set { backUpSet_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SheduleType value.
		/// </summary>
		public int SheduleType {
			get { return sheduleType; }
			set { sheduleType = value; }
		}
		
		/// <summary>
		/// Gets or sets the SheduledTime value.
		/// </summary>
		public DateTime SheduledTime {
			get { return sheduledTime; }
			set { sheduledTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the LastBackup_Time value.
		/// </summary>
		public DateTime LastBackup_Time {
			get { return lastBackup_Time; }
			set { lastBackup_Time = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_utlBackup_Shedule table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlBackup_SheduleInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@shedule_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@backUpSet_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@sheduleType", SqlDbType.Int,4);
			scom.Parameters.Add("@sheduledTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@lastBackup_Time", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@shedule_ID"].Value = shedule_ID;
			scom.Parameters["@backUpSet_ID"].Value = backUpSet_ID;
			scom.Parameters["@sheduleType"].Value = sheduleType;
			scom.Parameters["@sheduledTime"].Value = sheduledTime;
			scom.Parameters["@lastBackup_Time"].Value = lastBackup_Time;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlBackup_Shedule table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlBackup_SheduleUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@shedule_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@backUpSet_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@lastBackup_Time", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@shedule_ID"].Value = shedule_ID;
			scom.Parameters["@backUpSet_ID"].Value = backUpSet_ID;
			scom.Parameters["@lastBackup_Time"].Value = lastBackup_Time;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlBackup_Shedule table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlBackup_SheduleDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@shedule_ID", SqlDbType.Int,4);
			scom.Parameters["@shedule_ID"].Value = shedule_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlBackup_Shedule table.
		/// </summary>
		public static tbl_utlBackup_Shedule Select(int shedule_ID_Incoming){

			tbl_utlBackup_Shedule tbl_utlBackup_Sheduleins = new tbl_utlBackup_Shedule();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlBackup_SheduleSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@shedule_ID", SqlDbType.Int,4);
			scom.Parameters["@shedule_ID"].Value = shedule_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlBackup_Sheduleins = Maketbl_utlBackup_Shedule(dataReader);
				} else {
					tbl_utlBackup_Sheduleins = null;
				}
			}
			scon.Close();
			return tbl_utlBackup_Sheduleins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlBackup_Shedule table.
		/// </summary>
		public static List<tbl_utlBackup_Shedule> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlBackup_SheduleSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlBackup_Shedule> tbl_utlBackup_SheduleList = new List<tbl_utlBackup_Shedule>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlBackup_Shedule tbl_utlBackup_Shedule = Maketbl_utlBackup_Shedule(dataReader);
					tbl_utlBackup_SheduleList.Add(tbl_utlBackup_Shedule);
				}
			}
			scon.Close();
			return tbl_utlBackup_SheduleList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlBackup_Shedule class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlBackup_Shedule Maketbl_utlBackup_Shedule(SqlDataReader dataReader) {
			tbl_utlBackup_Shedule tbl_utlBackup_Shedule = new tbl_utlBackup_Shedule();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlBackup_Shedule.Shedule_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlBackup_Shedule.BackUpSet_ID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlBackup_Shedule.SheduleType = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_utlBackup_Shedule.SheduledTime = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_utlBackup_Shedule.LastBackup_Time = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_utlBackup_Shedule.IsActive = dataReader.GetBoolean(5);
			}

			return tbl_utlBackup_Shedule;
		}
		/// <summary>
		/// This makes tbl_utlBackup_Shedule datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlBackup_Shedule object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlBackup_Shedule  tbl_utlBackup_Shedule   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_shedule_ID = new DataColumn("shedule_ID" , typeof(int));
			DataColumn col_backUpSet_ID = new DataColumn("backUpSet_ID" , typeof(int));
			DataColumn col_sheduleType = new DataColumn("sheduleType" , typeof(int));
			DataColumn col_sheduledTime = new DataColumn("sheduledTime" , typeof(DateTime));
			DataColumn col_lastBackup_Time = new DataColumn("lastBackup_Time" , typeof(DateTime));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_shedule_ID,col_backUpSet_ID,col_sheduleType,col_sheduledTime,col_lastBackup_Time,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlBackup_Shedule datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlBackup_Shedule object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlBackup_Shedule user) {
		DataRow drow = dt.NewRow();
		
			drow["shedule_ID"] = user.shedule_ID;
			drow["backUpSet_ID"] = user.backUpSet_ID;
			drow["sheduleType"] = user.sheduleType;
			drow["sheduledTime"] = user.sheduledTime;
			drow["lastBackup_Time"] = user.lastBackup_Time;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
