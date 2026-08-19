using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zBatchNo {
		#region Fields
		private string batchNo;
		private string remark;
		private string externalGoodReceivedNote_ID;
		private DateTime externalGoodReceivedNoteDate;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zBatchNo class.
		/// </summary>
		public tbl_zBatchNo() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zBatchNo class.
		/// </summary>
		public tbl_zBatchNo(string batchNo, string remark, string externalGoodReceivedNote_ID, DateTime externalGoodReceivedNoteDate) {
			this.batchNo = batchNo;
			this.remark = remark;
			this.externalGoodReceivedNote_ID = externalGoodReceivedNote_ID;
			this.externalGoodReceivedNoteDate = externalGoodReceivedNoteDate;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the BatchNo value.
		/// </summary>
		public string BatchNo {
			get { return batchNo; }
			set { batchNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExternalGoodReceivedNote_ID value.
		/// </summary>
		public string ExternalGoodReceivedNote_ID {
			get { return externalGoodReceivedNote_ID; }
			set { externalGoodReceivedNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExternalGoodReceivedNoteDate value.
		/// </summary>
		public DateTime ExternalGoodReceivedNoteDate {
			get { return externalGoodReceivedNoteDate; }
			set { externalGoodReceivedNoteDate = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zBatchNo table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBatchNoInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@batchNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@externalGoodReceivedNoteDate", SqlDbType.DateTime,8);
 
			scom.Parameters["@batchNo"].Value = batchNo;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@externalGoodReceivedNoteDate"].Value = externalGoodReceivedNoteDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zBatchNo table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBatchNoUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@batchNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@externalGoodReceivedNoteDate", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@batchNo"].Value = batchNo;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@externalGoodReceivedNoteDate"].Value = externalGoodReceivedNoteDate;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zBatchNo table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBatchNoDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@batchNo", SqlDbType.VarChar,50);
			scom.Parameters["@batchNo"].Value = batchNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zBatchNo table.
		/// </summary>
		public static tbl_zBatchNo Select(string batchNo_Incoming){

			tbl_zBatchNo tbl_zBatchNoins = new tbl_zBatchNo();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBatchNoSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@batchNo", SqlDbType.VarChar,50);
			scom.Parameters["@batchNo"].Value = batchNo_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zBatchNoins = Maketbl_zBatchNo(dataReader);
				} else {
					tbl_zBatchNoins = null;
				}
			}
			scon.Close();
			return tbl_zBatchNoins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zBatchNo table.
		/// </summary>
		public static List<tbl_zBatchNo> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zBatchNoSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zBatchNo> tbl_zBatchNoList = new List<tbl_zBatchNo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zBatchNo tbl_zBatchNo = Maketbl_zBatchNo(dataReader);
					tbl_zBatchNoList.Add(tbl_zBatchNo);
				}
			}
			scon.Close();
			return tbl_zBatchNoList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zBatchNo class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zBatchNo Maketbl_zBatchNo(SqlDataReader dataReader) {
			tbl_zBatchNo tbl_zBatchNo = new tbl_zBatchNo();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zBatchNo.BatchNo = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zBatchNo.Remark = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zBatchNo.ExternalGoodReceivedNote_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zBatchNo.ExternalGoodReceivedNoteDate = dataReader.GetDateTime(3);
			}

			return tbl_zBatchNo;
		}
		/// <summary>
		/// This makes tbl_zBatchNo datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zBatchNo object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zBatchNo  tbl_zBatchNo   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_batchNo = new DataColumn("batchNo" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_externalGoodReceivedNote_ID = new DataColumn("externalGoodReceivedNote_ID" , typeof(string));
			DataColumn col_externalGoodReceivedNoteDate = new DataColumn("externalGoodReceivedNoteDate" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_batchNo,col_remark,col_externalGoodReceivedNote_ID,col_externalGoodReceivedNoteDate,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zBatchNo datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zBatchNo object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zBatchNo user) {
		DataRow drow = dt.NewRow();
		
			drow["batchNo"] = user.batchNo;
			drow["remark"] = user.remark;
			drow["externalGoodReceivedNote_ID"] = user.externalGoodReceivedNote_ID;
			drow["externalGoodReceivedNoteDate"] = user.externalGoodReceivedNoteDate;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
