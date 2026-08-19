using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlAlert_Master {
		#region Fields
		private int alert_ID;
		private string alertName;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_Master class.
		/// </summary>
		public tbl_utlAlert_Master() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlert_Master class.
		/// </summary>
		public tbl_utlAlert_Master(int alert_ID, string alertName, bool isActive) {
			this.alert_ID = alert_ID;
			this.alertName = alertName;
			this.isActive = isActive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Alert_ID value.
		/// </summary>
		public int Alert_ID {
			get { return alert_ID; }
			set { alert_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AlertName value.
		/// </summary>
		public string AlertName {
			get { return alertName; }
			set { alertName = value; }
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
		/// Saves a record to the tbl_utlAlert_Master table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_MasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@alert_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@alertName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@alert_ID"].Value = alert_ID;
			scom.Parameters["@alertName"].Value = alertName;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlAlert_Master table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_MasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@alert_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@alertName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@alert_ID"].Value = alert_ID;
			scom.Parameters["@alertName"].Value = alertName;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlAlert_Master table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_MasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@alert_ID", SqlDbType.Int,4);
			scom.Parameters["@alert_ID"].Value = alert_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlAlert_Master table.
		/// </summary>
		public static tbl_utlAlert_Master Select(int alert_ID_Incoming){

			tbl_utlAlert_Master tbl_utlAlert_Masterins = new tbl_utlAlert_Master();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_MasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@alert_ID", SqlDbType.Int,4);
			scom.Parameters["@alert_ID"].Value = alert_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlAlert_Masterins = Maketbl_utlAlert_Master(dataReader);
				} else {
					tbl_utlAlert_Masterins = null;
				}
			}
			scon.Close();
			return tbl_utlAlert_Masterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlert_Master table.
		/// </summary>
		public static List<tbl_utlAlert_Master> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlert_MasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlAlert_Master> tbl_utlAlert_MasterList = new List<tbl_utlAlert_Master>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlert_Master tbl_utlAlert_Master = Maketbl_utlAlert_Master(dataReader);
					tbl_utlAlert_MasterList.Add(tbl_utlAlert_Master);
				}
			}
			scon.Close();
			return tbl_utlAlert_MasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlAlert_Master class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlAlert_Master Maketbl_utlAlert_Master(SqlDataReader dataReader) {
			tbl_utlAlert_Master tbl_utlAlert_Master = new tbl_utlAlert_Master();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlAlert_Master.Alert_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlAlert_Master.AlertName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlAlert_Master.IsActive = dataReader.GetBoolean(2);
			}

			return tbl_utlAlert_Master;
		}
		/// <summary>
		/// This makes tbl_utlAlert_Master datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlAlert_Master object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlAlert_Master  tbl_utlAlert_Master   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_alert_ID = new DataColumn("alert_ID" , typeof(int));
			DataColumn col_alertName = new DataColumn("alertName" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_alert_ID,col_alertName,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlAlert_Master datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlAlert_Master object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlAlert_Master user) {
		DataRow drow = dt.NewRow();
		
			drow["alert_ID"] = user.alert_ID;
			drow["alertName"] = user.alertName;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
