using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zBatchApprovalStatus {
		#region Fields
		private string batchApprovalStatus_ID;
		private string batchApprovalStatus;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zBatchApprovalStatus class.
		/// </summary>
		public tbl_zBatchApprovalStatus() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zBatchApprovalStatus class.
		/// </summary>
		public tbl_zBatchApprovalStatus(string batchApprovalStatus_ID, string batchApprovalStatus) {
			this.batchApprovalStatus_ID = batchApprovalStatus_ID;
			this.batchApprovalStatus = batchApprovalStatus;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the BatchApprovalStatus_ID value.
		/// </summary>
		public string BatchApprovalStatus_ID {
			get { return batchApprovalStatus_ID; }
			set { batchApprovalStatus_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BatchApprovalStatus value.
		/// </summary>
		public string BatchApprovalStatus {
			get { return batchApprovalStatus; }
			set { batchApprovalStatus = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zBatchApprovalStatus table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBatchApprovalStatusInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@batchApprovalStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@batchApprovalStatus", SqlDbType.VarChar,50);
 
			scom.Parameters["@batchApprovalStatus_ID"].Value = batchApprovalStatus_ID;
			scom.Parameters["@batchApprovalStatus"].Value = batchApprovalStatus;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zBatchApprovalStatus table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBatchApprovalStatusUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@batchApprovalStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@batchApprovalStatus", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@batchApprovalStatus_ID"].Value = batchApprovalStatus_ID;
			scom.Parameters["@batchApprovalStatus"].Value = batchApprovalStatus;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zBatchApprovalStatus table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBatchApprovalStatusDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@batchApprovalStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@batchApprovalStatus_ID"].Value = batchApprovalStatus_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zBatchApprovalStatus table.
		/// </summary>
		public static tbl_zBatchApprovalStatus Select(string batchApprovalStatus_ID_Incoming){

			tbl_zBatchApprovalStatus tbl_zBatchApprovalStatusins = new tbl_zBatchApprovalStatus();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBatchApprovalStatusSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@batchApprovalStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@batchApprovalStatus_ID"].Value = batchApprovalStatus_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zBatchApprovalStatusins = Maketbl_zBatchApprovalStatus(dataReader);
				} else {
					tbl_zBatchApprovalStatusins = null;
				}
			}
			scon.Close();
			return tbl_zBatchApprovalStatusins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zBatchApprovalStatus table.
		/// </summary>
		public static List<tbl_zBatchApprovalStatus> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBatchApprovalStatusSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zBatchApprovalStatus> tbl_zBatchApprovalStatusList = new List<tbl_zBatchApprovalStatus>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zBatchApprovalStatus tbl_zBatchApprovalStatus = Maketbl_zBatchApprovalStatus(dataReader);
					tbl_zBatchApprovalStatusList.Add(tbl_zBatchApprovalStatus);
				}
			}
			scon.Close();
			return tbl_zBatchApprovalStatusList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zBatchApprovalStatus class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zBatchApprovalStatus Maketbl_zBatchApprovalStatus(SqlDataReader dataReader) {
			tbl_zBatchApprovalStatus tbl_zBatchApprovalStatus = new tbl_zBatchApprovalStatus();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zBatchApprovalStatus.BatchApprovalStatus_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zBatchApprovalStatus.BatchApprovalStatus = dataReader.GetString(1);
			}

			return tbl_zBatchApprovalStatus;
		}
		/// <summary>
		/// This makes tbl_zBatchApprovalStatus datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zBatchApprovalStatus object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zBatchApprovalStatus  tbl_zBatchApprovalStatus   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_batchApprovalStatus_ID = new DataColumn("batchApprovalStatus_ID" , typeof(string));
			DataColumn col_batchApprovalStatus = new DataColumn("batchApprovalStatus" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_batchApprovalStatus_ID,col_batchApprovalStatus,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zBatchApprovalStatus datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zBatchApprovalStatus object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zBatchApprovalStatus user) {
		DataRow drow = dt.NewRow();
		
			drow["batchApprovalStatus_ID"] = user.batchApprovalStatus_ID;
			drow["batchApprovalStatus"] = user.batchApprovalStatus;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
