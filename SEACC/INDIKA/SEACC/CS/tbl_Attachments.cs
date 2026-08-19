using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_Attachments {
		#region Fields
		private int attachment_ID;
		private string attachment_Path;
		private string dipsplayName;
		private bool isDeleted;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_Attachments class.
		/// </summary>
		public tbl_Attachments() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_Attachments class.
		/// </summary>
		public tbl_Attachments(int attachment_ID, string attachment_Path, string dipsplayName, bool isDeleted) {
			this.attachment_ID = attachment_ID;
			this.attachment_Path = attachment_Path;
			this.dipsplayName = dipsplayName;
			this.isDeleted = isDeleted;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Attachment_ID value.
		/// </summary>
		public int Attachment_ID {
			get { return attachment_ID; }
			set { attachment_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Attachment_Path value.
		/// </summary>
		public string Attachment_Path {
			get { return attachment_Path; }
			set { attachment_Path = value; }
		}
		
		/// <summary>
		/// Gets or sets the DipsplayName value.
		/// </summary>
		public string DipsplayName {
			get { return dipsplayName; }
			set { dipsplayName = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_Attachments table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_AttachmentsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@attachment_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@attachment_Path", SqlDbType.VarChar,200);
			scom.Parameters.Add("@dipsplayName", SqlDbType.VarChar,200);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
			scom.Parameters["@attachment_ID"].Value = attachment_ID;
			scom.Parameters["@attachment_Path"].Value = attachment_Path;
			scom.Parameters["@dipsplayName"].Value = dipsplayName;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_Attachments table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_AttachmentsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@attachment_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@attachment_Path", SqlDbType.VarChar,200);
			scom.Parameters.Add("@dipsplayName", SqlDbType.VarChar,200);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
 
			scom.Parameters["@attachment_ID"].Value = attachment_ID;
			scom.Parameters["@attachment_Path"].Value = attachment_Path;
			scom.Parameters["@dipsplayName"].Value = dipsplayName;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_Attachments table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_AttachmentsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@attachment_ID", SqlDbType.Int,4);
			scom.Parameters["@attachment_ID"].Value = attachment_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_Attachments table.
		/// </summary>
		public static tbl_Attachments Select(int attachment_ID_Incoming){

			tbl_Attachments tbl_Attachmentsins = new tbl_Attachments();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_AttachmentsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@attachment_ID", SqlDbType.Int,4);
			scom.Parameters["@attachment_ID"].Value = attachment_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_Attachmentsins = Maketbl_Attachments(dataReader);
				} else {
					tbl_Attachmentsins = null;
				}
			}
			scon.Close();
			return tbl_Attachmentsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_Attachments table.
		/// </summary>
		public static List<tbl_Attachments> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_AttachmentsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_Attachments> tbl_AttachmentsList = new List<tbl_Attachments>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_Attachments tbl_Attachments = Maketbl_Attachments(dataReader);
					tbl_AttachmentsList.Add(tbl_Attachments);
				}
			}
			scon.Close();
			return tbl_AttachmentsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_Attachments class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_Attachments Maketbl_Attachments(SqlDataReader dataReader) {
			tbl_Attachments tbl_Attachments = new tbl_Attachments();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_Attachments.Attachment_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_Attachments.Attachment_Path = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_Attachments.DipsplayName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_Attachments.IsDeleted = dataReader.GetBoolean(3);
			}

			return tbl_Attachments;
		}
		/// <summary>
		/// This makes tbl_Attachments datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_Attachments object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_Attachments  tbl_Attachments   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_attachment_ID = new DataColumn("attachment_ID" , typeof(int));
			DataColumn col_attachment_Path = new DataColumn("attachment_Path" , typeof(string));
			DataColumn col_dipsplayName = new DataColumn("dipsplayName" , typeof(string));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_attachment_ID,col_attachment_Path,col_dipsplayName,col_isDeleted,});		return dt;
		}
		/// <summary>
		/// This fills tbl_Attachments datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_Attachments object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_Attachments user) {
		DataRow drow = dt.NewRow();
		
			drow["attachment_ID"] = user.attachment_ID;
			drow["attachment_Path"] = user.attachment_Path;
			drow["dipsplayName"] = user.dipsplayName;
			drow["isDeleted"] = user.isDeleted;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
