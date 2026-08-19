using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zAccPostingStatus {
		#region Fields
		private string postingStatus_ID;
		private string postingStatusName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zAccPostingStatus class.
		/// </summary>
		public tbl_zAccPostingStatus() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zAccPostingStatus class.
		/// </summary>
		public tbl_zAccPostingStatus(string postingStatus_ID, string postingStatusName) {
			this.postingStatus_ID = postingStatus_ID;
			this.postingStatusName = postingStatusName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PostingStatus_ID value.
		/// </summary>
		public string PostingStatus_ID {
			get { return postingStatus_ID; }
			set { postingStatus_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PostingStatusName value.
		/// </summary>
		public string PostingStatusName {
			get { return postingStatusName; }
			set { postingStatusName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zAccPostingStatus table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccPostingStatusInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@postingStatusName", SqlDbType.VarChar,50);
 
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@postingStatusName"].Value = postingStatusName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zAccPostingStatus table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccPostingStatusUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@postingStatusName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
			scom.Parameters["@postingStatusName"].Value = postingStatusName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zAccPostingStatus table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccPostingStatusDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zAccPostingStatus table.
		/// </summary>
		public static tbl_zAccPostingStatus Select(string postingStatus_ID_Incoming){

			tbl_zAccPostingStatus tbl_zAccPostingStatusins = new tbl_zAccPostingStatus();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccPostingStatusSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@postingStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@postingStatus_ID"].Value = postingStatus_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zAccPostingStatusins = Maketbl_zAccPostingStatus(dataReader);
				} else {
					tbl_zAccPostingStatusins = null;
				}
			}
			scon.Close();
			return tbl_zAccPostingStatusins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zAccPostingStatus table.
		/// </summary>
		public static List<tbl_zAccPostingStatus> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccPostingStatusSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zAccPostingStatus> tbl_zAccPostingStatusList = new List<tbl_zAccPostingStatus>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zAccPostingStatus tbl_zAccPostingStatus = Maketbl_zAccPostingStatus(dataReader);
					tbl_zAccPostingStatusList.Add(tbl_zAccPostingStatus);
				}
			}
			scon.Close();
			return tbl_zAccPostingStatusList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zAccPostingStatus class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zAccPostingStatus Maketbl_zAccPostingStatus(SqlDataReader dataReader) {
			tbl_zAccPostingStatus tbl_zAccPostingStatus = new tbl_zAccPostingStatus();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zAccPostingStatus.PostingStatus_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zAccPostingStatus.PostingStatusName = dataReader.GetString(1);
			}

			return tbl_zAccPostingStatus;
		}
		/// <summary>
		/// This makes tbl_zAccPostingStatus datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zAccPostingStatus object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zAccPostingStatus  tbl_zAccPostingStatus   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_postingStatus_ID = new DataColumn("postingStatus_ID" , typeof(string));
			DataColumn col_postingStatusName = new DataColumn("postingStatusName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_postingStatus_ID,col_postingStatusName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zAccPostingStatus datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zAccPostingStatus object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zAccPostingStatus user) {
		DataRow drow = dt.NewRow();
		
			drow["postingStatus_ID"] = user.postingStatus_ID;
			drow["postingStatusName"] = user.postingStatusName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
