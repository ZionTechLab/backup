using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaTxAttachments {
		#region Fields
		private string attachment_ID;
		private string transaction_ID;
		private int function_ID;
		private string attachment;
		private string dipsplayName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxAttachments class.
		/// </summary>
		public tbl_prod_pharmaTxAttachments() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxAttachments class.
		/// </summary>
		public tbl_prod_pharmaTxAttachments(string attachment_ID, string transaction_ID, int function_ID, string attachment, string dipsplayName) {
			this.attachment_ID = attachment_ID;
			this.transaction_ID = transaction_ID;
			this.function_ID = function_ID;
			this.attachment = attachment;
			this.dipsplayName = dipsplayName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Attachment_ID value.
		/// </summary>
		public string Attachment_ID {
			get { return attachment_ID; }
			set { attachment_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Transaction_ID value.
		/// </summary>
		public string Transaction_ID {
			get { return transaction_ID; }
			set { transaction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Function_ID value.
		/// </summary>
		public int Function_ID {
			get { return function_ID; }
			set { function_ID = value; }
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
		/// Saves a record to the tbl_prod_pharmaTxAttachments table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxAttachmentsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@attachment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@attachment", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dipsplayName", SqlDbType.VarChar,100);
 
			scom.Parameters["@attachment_ID"].Value = attachment_ID;
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@function_ID"].Value = function_ID;
			scom.Parameters["@attachment"].Value = attachment;
			scom.Parameters["@dipsplayName"].Value = dipsplayName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_pharmaTxAttachments table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxAttachmentsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@attachment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@attachment", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dipsplayName", SqlDbType.VarChar,100);
 
 
			scom.Parameters["@attachment_ID"].Value = attachment_ID;
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
			scom.Parameters["@function_ID"].Value = function_ID;
			scom.Parameters["@attachment"].Value = attachment;
			scom.Parameters["@dipsplayName"].Value = dipsplayName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_pharmaTxAttachments table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxAttachmentsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@attachment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@attachment_ID"].Value = attachment_ID;
 
			scom.Parameters["@transaction_ID"].Value = transaction_ID;
 
			scom.Parameters["@function_ID"].Value = function_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_pharmaTxAttachments table.
		/// </summary>
		public static tbl_prod_pharmaTxAttachments Select(string attachment_ID_Incoming, string transaction_ID_Incoming, int function_ID_Incoming){

			tbl_prod_pharmaTxAttachments tbl_prod_pharmaTxAttachmentsins = new tbl_prod_pharmaTxAttachments();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxAttachmentsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@attachment_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@function_ID", SqlDbType.Int,4);
			scom.Parameters["@attachment_ID"].Value = attachment_ID_Incoming;
			scom.Parameters["@transaction_ID"].Value = transaction_ID_Incoming;
			scom.Parameters["@function_ID"].Value = function_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_pharmaTxAttachmentsins = Maketbl_prod_pharmaTxAttachments(dataReader);
				} else {
					tbl_prod_pharmaTxAttachmentsins = null;
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxAttachmentsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxAttachments table.
		/// </summary>
		public static List<tbl_prod_pharmaTxAttachments> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxAttachmentsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_pharmaTxAttachments> tbl_prod_pharmaTxAttachmentsList = new List<tbl_prod_pharmaTxAttachments>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxAttachments tbl_prod_pharmaTxAttachments = Maketbl_prod_pharmaTxAttachments(dataReader);
					tbl_prod_pharmaTxAttachmentsList.Add(tbl_prod_pharmaTxAttachments);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxAttachmentsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaTxAttachments class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaTxAttachments Maketbl_prod_pharmaTxAttachments(SqlDataReader dataReader) {
			tbl_prod_pharmaTxAttachments tbl_prod_pharmaTxAttachments = new tbl_prod_pharmaTxAttachments();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaTxAttachments.Attachment_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaTxAttachments.Transaction_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_pharmaTxAttachments.Function_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_pharmaTxAttachments.Attachment = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_pharmaTxAttachments.DipsplayName = dataReader.GetString(4);
			}

			return tbl_prod_pharmaTxAttachments;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaTxAttachments datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxAttachments object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaTxAttachments  tbl_prod_pharmaTxAttachments   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_attachment_ID = new DataColumn("attachment_ID" , typeof(string));
			DataColumn col_transaction_ID = new DataColumn("transaction_ID" , typeof(string));
			DataColumn col_function_ID = new DataColumn("function_ID" , typeof(int));
			DataColumn col_attachment = new DataColumn("attachment" , typeof(string));
			DataColumn col_dipsplayName = new DataColumn("dipsplayName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_attachment_ID,col_transaction_ID,col_function_ID,col_attachment,col_dipsplayName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaTxAttachments datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxAttachments object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaTxAttachments user) {
		DataRow drow = dt.NewRow();
		
			drow["attachment_ID"] = user.attachment_ID;
			drow["transaction_ID"] = user.transaction_ID;
			drow["function_ID"] = user.function_ID;
			drow["attachment"] = user.attachment;
			drow["dipsplayName"] = user.dipsplayName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
