using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zJobTreatnmentStatus {
		#region Fields
		private string treatnmentStatus_ID;
		private string treatnmentStatus;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zJobTreatnmentStatus class.
		/// </summary>
		public tbl_zJobTreatnmentStatus() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zJobTreatnmentStatus class.
		/// </summary>
		public tbl_zJobTreatnmentStatus(string treatnmentStatus_ID, string treatnmentStatus) {
			this.treatnmentStatus_ID = treatnmentStatus_ID;
			this.treatnmentStatus = treatnmentStatus;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the TreatnmentStatus_ID value.
		/// </summary>
		public string TreatnmentStatus_ID {
			get { return treatnmentStatus_ID; }
			set { treatnmentStatus_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TreatnmentStatus value.
		/// </summary>
		public string TreatnmentStatus {
			get { return treatnmentStatus; }
			set { treatnmentStatus = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zJobTreatnmentStatus table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobTreatnmentStatusInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@treatnmentStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@treatnmentStatus", SqlDbType.VarChar,50);
 
			scom.Parameters["@treatnmentStatus_ID"].Value = treatnmentStatus_ID;
			scom.Parameters["@treatnmentStatus"].Value = treatnmentStatus;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zJobTreatnmentStatus table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobTreatnmentStatusUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@treatnmentStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@treatnmentStatus", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@treatnmentStatus_ID"].Value = treatnmentStatus_ID;
			scom.Parameters["@treatnmentStatus"].Value = treatnmentStatus;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zJobTreatnmentStatus table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobTreatnmentStatusDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@treatnmentStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@treatnmentStatus_ID"].Value = treatnmentStatus_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zJobTreatnmentStatus table.
		/// </summary>
		public static tbl_zJobTreatnmentStatus Select(string treatnmentStatus_ID_Incoming){

			tbl_zJobTreatnmentStatus tbl_zJobTreatnmentStatusins = new tbl_zJobTreatnmentStatus();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobTreatnmentStatusSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@treatnmentStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@treatnmentStatus_ID"].Value = treatnmentStatus_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zJobTreatnmentStatusins = Maketbl_zJobTreatnmentStatus(dataReader);
				} else {
					tbl_zJobTreatnmentStatusins = null;
				}
			}
			scon.Close();
			return tbl_zJobTreatnmentStatusins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zJobTreatnmentStatus table.
		/// </summary>
		public static List<tbl_zJobTreatnmentStatus> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobTreatnmentStatusSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zJobTreatnmentStatus> tbl_zJobTreatnmentStatusList = new List<tbl_zJobTreatnmentStatus>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zJobTreatnmentStatus tbl_zJobTreatnmentStatus = Maketbl_zJobTreatnmentStatus(dataReader);
					tbl_zJobTreatnmentStatusList.Add(tbl_zJobTreatnmentStatus);
				}
			}
			scon.Close();
			return tbl_zJobTreatnmentStatusList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zJobTreatnmentStatus class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zJobTreatnmentStatus Maketbl_zJobTreatnmentStatus(SqlDataReader dataReader) {
			tbl_zJobTreatnmentStatus tbl_zJobTreatnmentStatus = new tbl_zJobTreatnmentStatus();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zJobTreatnmentStatus.TreatnmentStatus_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zJobTreatnmentStatus.TreatnmentStatus = dataReader.GetString(1);
			}

			return tbl_zJobTreatnmentStatus;
		}
		/// <summary>
		/// This makes tbl_zJobTreatnmentStatus datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zJobTreatnmentStatus object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zJobTreatnmentStatus  tbl_zJobTreatnmentStatus   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_treatnmentStatus_ID = new DataColumn("treatnmentStatus_ID" , typeof(string));
			DataColumn col_treatnmentStatus = new DataColumn("treatnmentStatus" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_treatnmentStatus_ID,col_treatnmentStatus,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zJobTreatnmentStatus datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zJobTreatnmentStatus object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zJobTreatnmentStatus user) {
		DataRow drow = dt.NewRow();
		
			drow["treatnmentStatus_ID"] = user.treatnmentStatus_ID;
			drow["treatnmentStatus"] = user.treatnmentStatus;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
