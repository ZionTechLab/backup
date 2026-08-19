using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasBatchApproval_Detail {
		#region Fields
		private string batchApproval_ID;
		private string noteID;
		private string batchApprovalStatus_ID;
		private bool isApproved;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasBatchApproval_Detail class.
		/// </summary>
		public tbl_sasBatchApproval_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasBatchApproval_Detail class.
		/// </summary>
		public tbl_sasBatchApproval_Detail(string batchApproval_ID, string noteID, string batchApprovalStatus_ID, bool isApproved) {
			this.batchApproval_ID = batchApproval_ID;
			this.noteID = noteID;
			this.batchApprovalStatus_ID = batchApprovalStatus_ID;
			this.isApproved = isApproved;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the BatchApproval_ID value.
		/// </summary>
		public string BatchApproval_ID {
			get { return batchApproval_ID; }
			set { batchApproval_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoteID value.
		/// </summary>
		public string NoteID {
			get { return noteID; }
			set { noteID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BatchApprovalStatus_ID value.
		/// </summary>
		public string BatchApprovalStatus_ID {
			get { return batchApprovalStatus_ID; }
			set { batchApprovalStatus_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsApproved value.
		/// </summary>
		public bool IsApproved {
			get { return isApproved; }
			set { isApproved = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasBatchApproval_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasBatchApproval_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@batchApproval_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@noteID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batchApprovalStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
 
			scom.Parameters["@batchApproval_ID"].Value = batchApproval_ID;
			scom.Parameters["@noteID"].Value = noteID;
			scom.Parameters["@batchApprovalStatus_ID"].Value = batchApprovalStatus_ID;
			scom.Parameters["@isApproved"].Value = isApproved;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasBatchApproval_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasBatchApproval_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@batchApproval_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@noteID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batchApprovalStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isApproved", SqlDbType.Bit,1);
 
 
			scom.Parameters["@batchApproval_ID"].Value = batchApproval_ID;
			scom.Parameters["@noteID"].Value = noteID;
			scom.Parameters["@batchApprovalStatus_ID"].Value = batchApprovalStatus_ID;
			scom.Parameters["@isApproved"].Value = isApproved;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasBatchApproval_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasBatchApproval_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@batchApproval_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@noteID", SqlDbType.VarChar,20);
			scom.Parameters["@batchApproval_ID"].Value = batchApproval_ID;
 
			scom.Parameters["@noteID"].Value = noteID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasBatchApproval_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByBatchApprovalStatus_ID(string batchApprovalStatus_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasBatchApproval_DetailDeleteAllByBatchApprovalStatus_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@batchApprovalStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@batchApprovalStatus_ID"].Value = batchApprovalStatus_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasBatchApproval_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByBatchApproval_ID(string batchApproval_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasBatchApproval_DetailDeleteAllByBatchApproval_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@batchApproval_ID", SqlDbType.VarChar,20);
			scom.Parameters["@batchApproval_ID"].Value = batchApproval_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasBatchApproval_Detail table.
		/// </summary>
		public static tbl_sasBatchApproval_Detail Select(string batchApproval_ID_Incoming, string noteID_Incoming){

			tbl_sasBatchApproval_Detail tbl_sasBatchApproval_Detailins = new tbl_sasBatchApproval_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasBatchApproval_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@batchApproval_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@noteID", SqlDbType.VarChar,20);
			scom.Parameters["@batchApproval_ID"].Value = batchApproval_ID_Incoming;
			scom.Parameters["@noteID"].Value = noteID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasBatchApproval_Detailins = Maketbl_sasBatchApproval_Detail(dataReader);
				} else {
					tbl_sasBatchApproval_Detailins = null;
				}
			}
			scon.Close();
			return tbl_sasBatchApproval_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasBatchApproval_Detail table.
		/// </summary>
		public static List<tbl_sasBatchApproval_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasBatchApproval_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasBatchApproval_Detail> tbl_sasBatchApproval_DetailList = new List<tbl_sasBatchApproval_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasBatchApproval_Detail tbl_sasBatchApproval_Detail = Maketbl_sasBatchApproval_Detail(dataReader);
					tbl_sasBatchApproval_DetailList.Add(tbl_sasBatchApproval_Detail);
				}
			}
			scon.Close();
			return tbl_sasBatchApproval_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasBatchApproval_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasBatchApproval_Detail> SelectAllByBatchApprovalStatus_ID(string batchApprovalStatus_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasBatchApproval_DetailSelectAllByBatchApprovalStatus_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@batchApprovalStatus_ID", SqlDbType.VarChar,10);
			scom.Parameters["@batchApprovalStatus_ID"].Value = batchApprovalStatus_ID;
				List<tbl_sasBatchApproval_Detail> tbl_sasBatchApproval_DetailList = new List<tbl_sasBatchApproval_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasBatchApproval_Detail tbl_sasBatchApproval_Detail = Maketbl_sasBatchApproval_Detail(dataReader);
					tbl_sasBatchApproval_DetailList.Add(tbl_sasBatchApproval_Detail);
				}
			}
			scon.Close();
			return tbl_sasBatchApproval_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasBatchApproval_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_sasBatchApproval_Detail> SelectAllByBatchApproval_ID(string batchApproval_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasBatchApproval_DetailSelectAllByBatchApproval_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@batchApproval_ID", SqlDbType.VarChar,20);
			scom.Parameters["@batchApproval_ID"].Value = batchApproval_ID;
				List<tbl_sasBatchApproval_Detail> tbl_sasBatchApproval_DetailList = new List<tbl_sasBatchApproval_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasBatchApproval_Detail tbl_sasBatchApproval_Detail = Maketbl_sasBatchApproval_Detail(dataReader);
					tbl_sasBatchApproval_DetailList.Add(tbl_sasBatchApproval_Detail);
				}
			}
			scon.Close();
			return tbl_sasBatchApproval_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasBatchApproval_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasBatchApproval_Detail Maketbl_sasBatchApproval_Detail(SqlDataReader dataReader) {
			tbl_sasBatchApproval_Detail tbl_sasBatchApproval_Detail = new tbl_sasBatchApproval_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasBatchApproval_Detail.BatchApproval_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasBatchApproval_Detail.NoteID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasBatchApproval_Detail.BatchApprovalStatus_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasBatchApproval_Detail.IsApproved = dataReader.GetBoolean(3);
			}

			return tbl_sasBatchApproval_Detail;
		}
		/// <summary>
		/// This makes tbl_sasBatchApproval_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasBatchApproval_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasBatchApproval_Detail  tbl_sasBatchApproval_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_batchApproval_ID = new DataColumn("batchApproval_ID" , typeof(string));
			DataColumn col_noteID = new DataColumn("noteID" , typeof(string));
			DataColumn col_batchApprovalStatus_ID = new DataColumn("batchApprovalStatus_ID" , typeof(string));
			DataColumn col_isApproved = new DataColumn("isApproved" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_batchApproval_ID,col_noteID,col_batchApprovalStatus_ID,col_isApproved,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasBatchApproval_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasBatchApproval_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasBatchApproval_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["batchApproval_ID"] = user.batchApproval_ID;
			drow["noteID"] = user.noteID;
			drow["batchApprovalStatus_ID"] = user.batchApprovalStatus_ID;
			drow["isApproved"] = user.isApproved;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
