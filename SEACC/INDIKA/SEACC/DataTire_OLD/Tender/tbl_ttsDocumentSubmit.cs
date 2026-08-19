using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsDocumentSubmit {
		#region Fields
		private string tender_ID;
		private string doc_ID;
		private bool isSubmitted;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsDocumentSubmit class.
		/// </summary>
		public tbl_ttsDocumentSubmit() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsDocumentSubmit class.
		/// </summary>
		public tbl_ttsDocumentSubmit(string tender_ID, string doc_ID, bool isSubmitted) {
			this.tender_ID = tender_ID;
			this.doc_ID = doc_ID;
			this.isSubmitted = isSubmitted;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Tender_ID value.
		/// </summary>
		public string Tender_ID {
			get { return tender_ID; }
			set { tender_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Doc_ID value.
		/// </summary>
		public string Doc_ID {
			get { return doc_ID; }
			set { doc_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSubmitted value.
		/// </summary>
		public bool IsSubmitted {
			get { return isSubmitted; }
			set { isSubmitted = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ttsDocumentSubmit table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsDocumentSubmitInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@doc_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isSubmitted", SqlDbType.Bit,1);
 
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@doc_ID"].Value = doc_ID;
			scom.Parameters["@isSubmitted"].Value = isSubmitted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ttsDocumentSubmit table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsDocumentSubmitUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@doc_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isSubmitted", SqlDbType.Bit,1);
 
 
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@doc_ID"].Value = doc_ID;
			scom.Parameters["@isSubmitted"].Value = isSubmitted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ttsDocumentSubmit table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsDocumentSubmitDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@doc_ID", SqlDbType.VarChar,20);
			scom.Parameters["@tender_ID"].Value = tender_ID;
 
			scom.Parameters["@doc_ID"].Value = doc_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsDocumentSubmit table by a foreign key.
		/// </summary>
		public static void DeleteAllByDoc_ID(string doc_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsDocumentSubmitDeleteAllByDoc_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@doc_ID", SqlDbType.VarChar,20);
			scom.Parameters["@doc_ID"].Value = doc_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsDocumentSubmit table by a foreign key.
		/// </summary>
		public static void DeleteAllByTender_ID(string tender_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsDocumentSubmitDeleteAllByTender_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ttsDocumentSubmit table.
		/// </summary>
		public static tbl_ttsDocumentSubmit Select(string tender_ID_Incoming, string doc_ID_Incoming){

			tbl_ttsDocumentSubmit tbl_ttsDocumentSubmitins = new tbl_ttsDocumentSubmit();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsDocumentSubmitSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@doc_ID", SqlDbType.VarChar,20);
			scom.Parameters["@tender_ID"].Value = tender_ID_Incoming;
			scom.Parameters["@doc_ID"].Value = doc_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ttsDocumentSubmitins = Maketbl_ttsDocumentSubmit(dataReader);
				} else {
					tbl_ttsDocumentSubmitins = null;
				}
			}
			scon.Close();
			return tbl_ttsDocumentSubmitins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsDocumentSubmit table.
		/// </summary>
		public static List<tbl_ttsDocumentSubmit> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsDocumentSubmitSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsDocumentSubmit> tbl_ttsDocumentSubmitList = new List<tbl_ttsDocumentSubmit>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsDocumentSubmit tbl_ttsDocumentSubmit = Maketbl_ttsDocumentSubmit(dataReader);
					tbl_ttsDocumentSubmitList.Add(tbl_ttsDocumentSubmit);
				}
			}
			scon.Close();
			return tbl_ttsDocumentSubmitList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsDocumentSubmit table by a foreign key.
		/// </summary>
		public static List<tbl_ttsDocumentSubmit> SelectAllByDoc_ID(string doc_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsDocumentSubmitSelectAllByDoc_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@doc_ID", SqlDbType.VarChar,20);
			scom.Parameters["@doc_ID"].Value = doc_ID;
				List<tbl_ttsDocumentSubmit> tbl_ttsDocumentSubmitList = new List<tbl_ttsDocumentSubmit>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsDocumentSubmit tbl_ttsDocumentSubmit = Maketbl_ttsDocumentSubmit(dataReader);
					tbl_ttsDocumentSubmitList.Add(tbl_ttsDocumentSubmit);
				}
			}
			scon.Close();
			return tbl_ttsDocumentSubmitList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsDocumentSubmit table by a foreign key.
		/// </summary>
		public static List<tbl_ttsDocumentSubmit> SelectAllByTender_ID(string tender_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsDocumentSubmitSelectAllByTender_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
				List<tbl_ttsDocumentSubmit> tbl_ttsDocumentSubmitList = new List<tbl_ttsDocumentSubmit>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsDocumentSubmit tbl_ttsDocumentSubmit = Maketbl_ttsDocumentSubmit(dataReader);
					tbl_ttsDocumentSubmitList.Add(tbl_ttsDocumentSubmit);
				}
			}
			scon.Close();
			return tbl_ttsDocumentSubmitList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ttsDocumentSubmit class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsDocumentSubmit Maketbl_ttsDocumentSubmit(SqlDataReader dataReader) {
			tbl_ttsDocumentSubmit tbl_ttsDocumentSubmit = new tbl_ttsDocumentSubmit();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsDocumentSubmit.Tender_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsDocumentSubmit.Doc_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ttsDocumentSubmit.IsSubmitted = dataReader.GetBoolean(2);
			}

			return tbl_ttsDocumentSubmit;
		}
		/// <summary>
		/// This makes tbl_ttsDocumentSubmit datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsDocumentSubmit object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsDocumentSubmit  tbl_ttsDocumentSubmit   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_tender_ID = new DataColumn("tender_ID" , typeof(string));
			DataColumn col_doc_ID = new DataColumn("doc_ID" , typeof(string));
			DataColumn col_isSubmitted = new DataColumn("isSubmitted" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_tender_ID,col_doc_ID,col_isSubmitted,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ttsDocumentSubmit datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsDocumentSubmit object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsDocumentSubmit user) {
		DataRow drow = dt.NewRow();
		
			drow["tender_ID"] = user.tender_ID;
			drow["doc_ID"] = user.doc_ID;
			drow["isSubmitted"] = user.isSubmitted;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
