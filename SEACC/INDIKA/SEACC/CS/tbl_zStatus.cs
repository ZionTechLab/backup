using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zStatus {
		#region Fields
		private int statusID;
		private string statusName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zStatus class.
		/// </summary>
		public tbl_zStatus() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zStatus class.
		/// </summary>
		public tbl_zStatus(int statusID, string statusName) {
			this.statusID = statusID;
			this.statusName = statusName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the StatusID value.
		/// </summary>
		public int StatusID {
			get { return statusID; }
			set { statusID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StatusName value.
		/// </summary>
		public string StatusName {
			get { return statusName; }
			set { statusName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zStatus table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zStatusInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@statusID", SqlDbType.Int,4);
			scom.Parameters.Add("@statusName", SqlDbType.VarChar,10);
 
			scom.Parameters["@statusID"].Value = statusID;
			scom.Parameters["@statusName"].Value = statusName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zStatus table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zStatusUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@statusID", SqlDbType.Int,4);
			scom.Parameters.Add("@statusName", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@statusID"].Value = statusID;
			scom.Parameters["@statusName"].Value = statusName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zStatus table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zStatusDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@statusID", SqlDbType.Int,4);
			scom.Parameters["@statusID"].Value = statusID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zStatus table.
		/// </summary>
		public static tbl_zStatus Select(int statusID_Incoming){

			tbl_zStatus tbl_zStatusins = new tbl_zStatus();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zStatusSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@statusID", SqlDbType.Int,4);
			scom.Parameters["@statusID"].Value = statusID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zStatusins = Maketbl_zStatus(dataReader);
				} else {
					tbl_zStatusins = null;
				}
			}
			scon.Close();
			return tbl_zStatusins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zStatus table.
		/// </summary>
		public static List<tbl_zStatus> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zStatusSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zStatus> tbl_zStatusList = new List<tbl_zStatus>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zStatus tbl_zStatus = Maketbl_zStatus(dataReader);
					tbl_zStatusList.Add(tbl_zStatus);
				}
			}
			scon.Close();
			return tbl_zStatusList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zStatus class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zStatus Maketbl_zStatus(SqlDataReader dataReader) {
			tbl_zStatus tbl_zStatus = new tbl_zStatus();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zStatus.StatusID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zStatus.StatusName = dataReader.GetString(1);
			}

			return tbl_zStatus;
		}
		/// <summary>
		/// This makes tbl_zStatus datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zStatus object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zStatus  tbl_zStatus   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_statusID = new DataColumn("statusID" , typeof(int));
			DataColumn col_statusName = new DataColumn("statusName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_statusID,col_statusName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zStatus datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zStatus object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zStatus user) {
		DataRow drow = dt.NewRow();
		
			drow["statusID"] = user.statusID;
			drow["statusName"] = user.statusName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
