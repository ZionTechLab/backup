using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsAttachments {
		#region Fields
		private string attachment_ID;
		private string transaction_ID;
		private int function_ID;
		private string attachment;
		private string dipsplayName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsAttachments class.
		/// </summary>
		public tbl_ttsAttachments() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsAttachments class.
		/// </summary>
		public tbl_ttsAttachments(string attachment_ID, string transaction_ID, int function_ID, string attachment, string dipsplayName) {
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
		/// Saves a record to the tbl_ttsAttachments table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsAttachmentsInsert", scon);
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
		/// Updates a record in the tbl_ttsAttachments table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsAttachmentsUpdate", scon);
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
		/// Deletes a record from the tbl_ttsAttachments table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsAttachmentsDelete", scon);
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
		/// Selects a single record from the tbl_ttsAttachments table.
		/// </summary>
		public static tbl_ttsAttachments Select(string attachment_ID_Incoming, string transaction_ID_Incoming, int function_ID_Incoming){

			tbl_ttsAttachments tbl_ttsAttachmentsins = new tbl_ttsAttachments();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsAttachmentsSelect", scon);
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
					tbl_ttsAttachmentsins = Maketbl_ttsAttachments(dataReader);
				} else {
					tbl_ttsAttachmentsins = null;
				}
			}
			scon.Close();
			return tbl_ttsAttachmentsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsAttachments table.
		/// </summary>
		public static List<tbl_ttsAttachments> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsAttachmentsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsAttachments> tbl_ttsAttachmentsList = new List<tbl_ttsAttachments>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsAttachments tbl_ttsAttachments = Maketbl_ttsAttachments(dataReader);
					tbl_ttsAttachmentsList.Add(tbl_ttsAttachments);
				}
			}
			scon.Close();
			return tbl_ttsAttachmentsList;
		}
        public static List<tbl_ttsAttachments> SelectAllby_function_ID_transaction_ID(string transaction_ID_Incoming, int function_ID_Incoming)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_ttsAttachmentsSelectAllby_function_ID_transaction_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

          
            scom.Parameters.Add("@transaction_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@function_ID", SqlDbType.Int, 4);
          
            scom.Parameters["@transaction_ID"].Value = transaction_ID_Incoming;
            scom.Parameters["@function_ID"].Value = function_ID_Incoming;

            List<tbl_ttsAttachments> tbl_ttsAttachmentsList = new List<tbl_ttsAttachments>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_ttsAttachments tbl_ttsAttachments = Maketbl_ttsAttachments(dataReader);
                    tbl_ttsAttachmentsList.Add(tbl_ttsAttachments);
                }
            }
            scon.Close();
            return tbl_ttsAttachmentsList;
        }
		/// <summary>
		/// Creates a new instance of the tbl_ttsAttachments class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsAttachments Maketbl_ttsAttachments(SqlDataReader dataReader) {
			tbl_ttsAttachments tbl_ttsAttachments = new tbl_ttsAttachments();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsAttachments.Attachment_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsAttachments.Transaction_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ttsAttachments.Function_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ttsAttachments.Attachment = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ttsAttachments.DipsplayName = dataReader.GetString(4);
			}

			return tbl_ttsAttachments;
		}
		/// <summary>
		/// This makes tbl_ttsAttachments datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsAttachments object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsAttachments  tbl_ttsAttachments   )
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
		/// This fills tbl_ttsAttachments datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsAttachments object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsAttachments user) {
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
