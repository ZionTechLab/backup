using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsOfferLetter {
		#region Fields
		private string offer_ID;
		private string tender_ID;
		private DateTime offerLetterDate;
		private string offerLetterRefNo;
		private bool isCanceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsOfferLetter class.
		/// </summary>
		public tbl_ttsOfferLetter() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsOfferLetter class.
		/// </summary>
		public tbl_ttsOfferLetter(string offer_ID, string tender_ID, DateTime offerLetterDate, string offerLetterRefNo, bool isCanceled) {
			this.offer_ID = offer_ID;
			this.tender_ID = tender_ID;
			this.offerLetterDate = offerLetterDate;
			this.offerLetterRefNo = offerLetterRefNo;
			this.isCanceled = isCanceled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Offer_ID value.
		/// </summary>
		public string Offer_ID {
			get { return offer_ID; }
			set { offer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tender_ID value.
		/// </summary>
		public string Tender_ID {
			get { return tender_ID; }
			set { tender_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the OfferLetterDate value.
		/// </summary>
		public DateTime OfferLetterDate {
			get { return offerLetterDate; }
			set { offerLetterDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the OfferLetterRefNo value.
		/// </summary>
		public string OfferLetterRefNo {
			get { return offerLetterRefNo; }
			set { offerLetterRefNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ttsOfferLetter table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsOfferLetterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@offer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@offerLetterDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@offerLetterRefNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
			scom.Parameters["@offer_ID"].Value = offer_ID;
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@offerLetterDate"].Value = offerLetterDate;
			scom.Parameters["@offerLetterRefNo"].Value = offerLetterRefNo;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ttsOfferLetter table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsOfferLetterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@offer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@offerLetterDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@offerLetterRefNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@offer_ID"].Value = offer_ID;
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@offerLetterDate"].Value = offerLetterDate;
			scom.Parameters["@offerLetterRefNo"].Value = offerLetterRefNo;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ttsOfferLetter table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsOfferLetterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@offer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@offer_ID"].Value = offer_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsOfferLetter table by a foreign key.
		/// </summary>
		public static void DeleteAllByTender_ID(string tender_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsOfferLetterDeleteAllByTender_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ttsOfferLetter table.
		/// </summary>
		public static tbl_ttsOfferLetter Select(string offer_ID_Incoming){

			tbl_ttsOfferLetter tbl_ttsOfferLetterins = new tbl_ttsOfferLetter();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsOfferLetterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@offer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@offer_ID"].Value = offer_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ttsOfferLetterins = Maketbl_ttsOfferLetter(dataReader);
				} else {
					tbl_ttsOfferLetterins = null;
				}
			}
			scon.Close();
			return tbl_ttsOfferLetterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsOfferLetter table.
		/// </summary>
		public static List<tbl_ttsOfferLetter> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsOfferLetterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsOfferLetter> tbl_ttsOfferLetterList = new List<tbl_ttsOfferLetter>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsOfferLetter tbl_ttsOfferLetter = Maketbl_ttsOfferLetter(dataReader);
					tbl_ttsOfferLetterList.Add(tbl_ttsOfferLetter);
				}
			}
			scon.Close();
			return tbl_ttsOfferLetterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsOfferLetter table by a foreign key.
		/// </summary>
		public static List<tbl_ttsOfferLetter> SelectAllByTender_ID(string tender_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsOfferLetterSelectAllByTender_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
				List<tbl_ttsOfferLetter> tbl_ttsOfferLetterList = new List<tbl_ttsOfferLetter>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsOfferLetter tbl_ttsOfferLetter = Maketbl_ttsOfferLetter(dataReader);
					tbl_ttsOfferLetterList.Add(tbl_ttsOfferLetter);
				}
			}
			scon.Close();
			return tbl_ttsOfferLetterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ttsOfferLetter class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsOfferLetter Maketbl_ttsOfferLetter(SqlDataReader dataReader) {
			tbl_ttsOfferLetter tbl_ttsOfferLetter = new tbl_ttsOfferLetter();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsOfferLetter.Offer_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsOfferLetter.Tender_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ttsOfferLetter.OfferLetterDate = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ttsOfferLetter.OfferLetterRefNo = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ttsOfferLetter.IsCanceled = dataReader.GetBoolean(4);
			}

			return tbl_ttsOfferLetter;
		}
		/// <summary>
		/// This makes tbl_ttsOfferLetter datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsOfferLetter object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsOfferLetter  tbl_ttsOfferLetter   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_offer_ID = new DataColumn("offer_ID" , typeof(string));
			DataColumn col_tender_ID = new DataColumn("tender_ID" , typeof(string));
			DataColumn col_offerLetterDate = new DataColumn("offerLetterDate" , typeof(DateTime));
			DataColumn col_offerLetterRefNo = new DataColumn("offerLetterRefNo" , typeof(string));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_offer_ID,col_tender_ID,col_offerLetterDate,col_offerLetterRefNo,col_isCanceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ttsOfferLetter datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsOfferLetter object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsOfferLetter user) {
		DataRow drow = dt.NewRow();
		
			drow["offer_ID"] = user.offer_ID;
			drow["tender_ID"] = user.tender_ID;
			drow["offerLetterDate"] = user.offerLetterDate;
			drow["offerLetterRefNo"] = user.offerLetterRefNo;
			drow["isCanceled"] = user.isCanceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
