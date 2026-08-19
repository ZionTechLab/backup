using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_utlAlertMailBox_Attachments {
		#region Fields
		private int eMail_ID;
		private int attachment_index;
		private string filePath;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlertMailBox_Attachments class.
		/// </summary>
		public tbl_utlAlertMailBox_Attachments() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_utlAlertMailBox_Attachments class.
		/// </summary>
		public tbl_utlAlertMailBox_Attachments(int eMail_ID, int attachment_index, string filePath) {
			this.eMail_ID = eMail_ID;
			this.attachment_index = attachment_index;
			this.filePath = filePath;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the EMail_ID value.
		/// </summary>
		public int EMail_ID {
			get { return eMail_ID; }
			set { eMail_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Attachment_index value.
		/// </summary>
		public int Attachment_index {
			get { return attachment_index; }
			set { attachment_index = value; }
		}
		
		/// <summary>
		/// Gets or sets the FilePath value.
		/// </summary>
		public string FilePath {
			get { return filePath; }
			set { filePath = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_utlAlertMailBox_Attachments table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_AttachmentsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@attachment_index", SqlDbType.Int,4);
			scom.Parameters.Add("@filePath", SqlDbType.VarChar,500);
 
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
			scom.Parameters["@attachment_index"].Value = attachment_index;
			scom.Parameters["@filePath"].Value = filePath;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_utlAlertMailBox_Attachments table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_AttachmentsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@attachment_index", SqlDbType.Int,4);
			scom.Parameters.Add("@filePath", SqlDbType.VarChar,500);
 
 
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
			scom.Parameters["@attachment_index"].Value = attachment_index;
			scom.Parameters["@filePath"].Value = filePath;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_utlAlertMailBox_Attachments table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_AttachmentsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_utlAlertMailBox_Attachments table.
		/// </summary>
		public static tbl_utlAlertMailBox_Attachments Select(int eMail_ID_Incoming){

			tbl_utlAlertMailBox_Attachments tbl_utlAlertMailBox_Attachmentsins = new tbl_utlAlertMailBox_Attachments();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_AttachmentsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters["@eMail_ID"].Value = eMail_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_utlAlertMailBox_Attachmentsins = Maketbl_utlAlertMailBox_Attachments(dataReader);
				} else {
					tbl_utlAlertMailBox_Attachmentsins = null;
				}
			}
			scon.Close();
			return tbl_utlAlertMailBox_Attachmentsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_utlAlertMailBox_Attachments table.
		/// </summary>
		public static List<tbl_utlAlertMailBox_Attachments> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_utlAlertMailBox_AttachmentsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_utlAlertMailBox_Attachments> tbl_utlAlertMailBox_AttachmentsList = new List<tbl_utlAlertMailBox_Attachments>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_utlAlertMailBox_Attachments tbl_utlAlertMailBox_Attachments = Maketbl_utlAlertMailBox_Attachments(dataReader);
					tbl_utlAlertMailBox_AttachmentsList.Add(tbl_utlAlertMailBox_Attachments);
				}
			}
			scon.Close();
			return tbl_utlAlertMailBox_AttachmentsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_utlAlertMailBox_Attachments class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_utlAlertMailBox_Attachments Maketbl_utlAlertMailBox_Attachments(SqlDataReader dataReader) {
			tbl_utlAlertMailBox_Attachments tbl_utlAlertMailBox_Attachments = new tbl_utlAlertMailBox_Attachments();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_utlAlertMailBox_Attachments.EMail_ID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_utlAlertMailBox_Attachments.Attachment_index = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_utlAlertMailBox_Attachments.FilePath = dataReader.GetString(2);
			}

			return tbl_utlAlertMailBox_Attachments;
		}
		/// <summary>
		/// This makes tbl_utlAlertMailBox_Attachments datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_utlAlertMailBox_Attachments object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_utlAlertMailBox_Attachments  tbl_utlAlertMailBox_Attachments   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_eMail_ID = new DataColumn("eMail_ID" , typeof(int));
			DataColumn col_attachment_index = new DataColumn("attachment_index" , typeof(int));
			DataColumn col_filePath = new DataColumn("filePath" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_eMail_ID,col_attachment_index,col_filePath,});		return dt;
		}
		/// <summary>
		/// This fills tbl_utlAlertMailBox_Attachments datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_utlAlertMailBox_Attachments object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_utlAlertMailBox_Attachments user) {
		DataRow drow = dt.NewRow();
		
			drow["eMail_ID"] = user.eMail_ID;
			drow["attachment_index"] = user.attachment_index;
			drow["filePath"] = user.filePath;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
