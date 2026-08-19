using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasAttachments {
		#region Fields
		private string transaction_ID;
		private int attachment_Index;
		private int form_ID;
		private string attachment;
		private string dipsplayName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasAttachments class.
		/// </summary>
		public tbl_sasAttachments() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasAttachments class.
		/// </summary>
		public tbl_sasAttachments(string transaction_ID, int attachment_Index, int form_ID, string attachment, string dipsplayName) {
			this.transaction_ID = transaction_ID;
			this.attachment_Index = attachment_Index;
			this.form_ID = form_ID;
			this.attachment = attachment;
			this.dipsplayName = dipsplayName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Transaction_ID value.
		/// </summary>
		public string Transaction_ID {
			get { return transaction_ID; }
			set { transaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Attachment_Index value.
		/// </summary>
		public int Attachment_Index {
			get { return attachment_Index; }
			set { attachment_Index = value; }
		}
		
		/// <summary>
		/// Gets or sets the Form_ID value.
		/// </summary>
		public int Form_ID {
			get { return form_ID; }
			set { form_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Attachment value.
		/// </summary>
		public string Attachment {
			get { return attachment; }
			set { attachment = value; }
		}
		
		/// <summary>
		/// Gets or sets the DipsplayName value.
		/// </summary>
		public string DipsplayName {
			get { return dipsplayName; }
			set { dipsplayName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasAttachments table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAttachmentsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@attachment_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@attachment", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dipsplayName", SqlDbType.VarChar,100);
 
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@attachment_Index"].Value = attachment_Index;
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@attachment"].Value = attachment;
			scom.Parameters["@dipsplayName"].Value = dipsplayName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasAttachments table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAttachmentsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@attachment_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@attachment", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dipsplayName", SqlDbType.VarChar,100);
 
 
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@attachment_Index"].Value = attachment_Index;
			scom.Parameters["@form_ID"].Value = form_ID;
			scom.Parameters["@attachment"].Value = attachment;
			scom.Parameters["@dipsplayName"].Value = dipsplayName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasAttachments table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAttachmentsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@attachment_Index", SqlDbType.Int,4);
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
 
			scom.Parameters["@attachment_Index"].Value = attachment_Index;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasAttachments table by a foreign key.
		/// </summary>
		public static void DeleteAllByForm_ID(int form_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAttachmentsDeleteAllByForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasAttachments table.
		/// </summary>
		public static tbl_sasAttachments Select(string transaction_ID_Incoming, int attachment_Index_Incoming){

			tbl_sasAttachments tbl_sasAttachmentsins = new tbl_sasAttachments();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAttachmentsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@attachment_Index", SqlDbType.Int,4);
			scom.Parameters["@transaction_ID"].Value = transaction_ID_Incoming;
			scom.Parameters["@attachment_Index"].Value = attachment_Index_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasAttachmentsins = Maketbl_sasAttachments(dataReader);
				} else {
					tbl_sasAttachmentsins = null;
				}
			}
			scon.Close();
			return tbl_sasAttachmentsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasAttachments table.
		/// </summary>
		public static List<tbl_sasAttachments> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAttachmentsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasAttachments> tbl_sasAttachmentsList = new List<tbl_sasAttachments>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasAttachments tbl_sasAttachments = Maketbl_sasAttachments(dataReader);
					tbl_sasAttachmentsList.Add(tbl_sasAttachments);
				}
			}
			scon.Close();
			return tbl_sasAttachmentsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasAttachments table by a foreign key.
		/// </summary>
		public static List<tbl_sasAttachments> SelectAllByForm_ID(int form_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasAttachmentsSelectAllByForm_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@form_ID", SqlDbType.Int,4);
			scom.Parameters["@form_ID"].Value = form_ID;
				List<tbl_sasAttachments> tbl_sasAttachmentsList = new List<tbl_sasAttachments>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasAttachments tbl_sasAttachments = Maketbl_sasAttachments(dataReader);
					tbl_sasAttachmentsList.Add(tbl_sasAttachments);
				}
			}
			scon.Close();
			return tbl_sasAttachmentsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasAttachments class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasAttachments Maketbl_sasAttachments(SqlDataReader dataReader) {
			tbl_sasAttachments tbl_sasAttachments = new tbl_sasAttachments();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasAttachments.Transaction_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasAttachments.Attachment_Index = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasAttachments.Form_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasAttachments.Attachment = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasAttachments.DipsplayName = dataReader.GetString(4);
			}

			return tbl_sasAttachments;
		}
		/// <summary>
		/// This makes tbl_sasAttachments datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasAttachments object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasAttachments  tbl_sasAttachments   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_transaction_ID = new DataColumn("transaction_ID" , typeof(string));
			DataColumn col_attachment_Index = new DataColumn("attachment_Index" , typeof(int));
			DataColumn col_form_ID = new DataColumn("form_ID" , typeof(int));
			DataColumn col_attachment = new DataColumn("attachment" , typeof(string));
			DataColumn col_dipsplayName = new DataColumn("dipsplayName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_transaction_ID,col_attachment_Index,col_form_ID,col_attachment,col_dipsplayName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasAttachments datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasAttachments object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasAttachments user) {
		DataRow drow = dt.NewRow();
		
			drow["transaction_ID"] = user.transaction_ID;
			drow["attachment_Index"] = user.attachment_Index;
			drow["form_ID"] = user.form_ID;
			drow["attachment"] = user.attachment;
			drow["dipsplayName"] = user.dipsplayName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
