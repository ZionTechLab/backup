using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsAcceptanceLetter {
		#region Fields
		private string acceptance_ID;
		private string tender_ID;
		private DateTime acceptanceLetterDate;
		private string acceptanceLetterRefNo;
		private bool isCanceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsAcceptanceLetter class.
		/// </summary>
		public tbl_ttsAcceptanceLetter() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsAcceptanceLetter class.
		/// </summary>
		public tbl_ttsAcceptanceLetter(string acceptance_ID, string tender_ID, DateTime acceptanceLetterDate, string acceptanceLetterRefNo, bool isCanceled) {
			this.acceptance_ID = acceptance_ID;
			this.tender_ID = tender_ID;
			this.acceptanceLetterDate = acceptanceLetterDate;
			this.acceptanceLetterRefNo = acceptanceLetterRefNo;
			this.isCanceled = isCanceled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Acceptance_ID value.
		/// </summary>
		public string Acceptance_ID {
			get { return acceptance_ID; }
			set { acceptance_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tender_ID value.
		/// </summary>
		public string Tender_ID {
			get { return tender_ID; }
			set { tender_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AcceptanceLetterDate value.
		/// </summary>
		public DateTime AcceptanceLetterDate {
			get { return acceptanceLetterDate; }
			set { acceptanceLetterDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the AcceptanceLetterRefNo value.
		/// </summary>
		public string AcceptanceLetterRefNo {
			get { return acceptanceLetterRefNo; }
			set { acceptanceLetterRefNo = value; }
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
		/// Saves a record to the tbl_ttsAcceptanceLetter table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsAcceptanceLetterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@acceptance_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@acceptanceLetterDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@acceptanceLetterRefNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
			scom.Parameters["@acceptance_ID"].Value = acceptance_ID;
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@acceptanceLetterDate"].Value = acceptanceLetterDate;
			scom.Parameters["@acceptanceLetterRefNo"].Value = acceptanceLetterRefNo;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ttsAcceptanceLetter table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsAcceptanceLetterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@acceptance_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@acceptanceLetterDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@acceptanceLetterRefNo", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@acceptance_ID"].Value = acceptance_ID;
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@acceptanceLetterDate"].Value = acceptanceLetterDate;
			scom.Parameters["@acceptanceLetterRefNo"].Value = acceptanceLetterRefNo;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ttsAcceptanceLetter table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsAcceptanceLetterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@acceptance_ID", SqlDbType.VarChar,20);
			scom.Parameters["@acceptance_ID"].Value = acceptance_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsAcceptanceLetter table by a foreign key.
		/// </summary>
		public static void DeleteAllByTender_ID(string tender_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsAcceptanceLetterDeleteAllByTender_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ttsAcceptanceLetter table.
		/// </summary>
		public static tbl_ttsAcceptanceLetter Select(string acceptance_ID_Incoming){

			tbl_ttsAcceptanceLetter tbl_ttsAcceptanceLetterins = new tbl_ttsAcceptanceLetter();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsAcceptanceLetterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@acceptance_ID", SqlDbType.VarChar,20);
			scom.Parameters["@acceptance_ID"].Value = acceptance_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ttsAcceptanceLetterins = Maketbl_ttsAcceptanceLetter(dataReader);
				} else {
					tbl_ttsAcceptanceLetterins = null;
				}
			}
			scon.Close();
			return tbl_ttsAcceptanceLetterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsAcceptanceLetter table.
		/// </summary>
		public static List<tbl_ttsAcceptanceLetter> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsAcceptanceLetterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsAcceptanceLetter> tbl_ttsAcceptanceLetterList = new List<tbl_ttsAcceptanceLetter>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsAcceptanceLetter tbl_ttsAcceptanceLetter = Maketbl_ttsAcceptanceLetter(dataReader);
					tbl_ttsAcceptanceLetterList.Add(tbl_ttsAcceptanceLetter);
				}
			}
			scon.Close();
			return tbl_ttsAcceptanceLetterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsAcceptanceLetter table by a foreign key.
		/// </summary>
		public static List<tbl_ttsAcceptanceLetter> SelectAllByTender_ID(string tender_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsAcceptanceLetterSelectAllByTender_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
				List<tbl_ttsAcceptanceLetter> tbl_ttsAcceptanceLetterList = new List<tbl_ttsAcceptanceLetter>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsAcceptanceLetter tbl_ttsAcceptanceLetter = Maketbl_ttsAcceptanceLetter(dataReader);
					tbl_ttsAcceptanceLetterList.Add(tbl_ttsAcceptanceLetter);
				}
			}
			scon.Close();
			return tbl_ttsAcceptanceLetterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ttsAcceptanceLetter class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsAcceptanceLetter Maketbl_ttsAcceptanceLetter(SqlDataReader dataReader) {
			tbl_ttsAcceptanceLetter tbl_ttsAcceptanceLetter = new tbl_ttsAcceptanceLetter();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsAcceptanceLetter.Acceptance_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsAcceptanceLetter.Tender_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ttsAcceptanceLetter.AcceptanceLetterDate = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ttsAcceptanceLetter.AcceptanceLetterRefNo = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ttsAcceptanceLetter.IsCanceled = dataReader.GetBoolean(4);
			}

			return tbl_ttsAcceptanceLetter;
		}
		/// <summary>
		/// This makes tbl_ttsAcceptanceLetter datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsAcceptanceLetter object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsAcceptanceLetter  tbl_ttsAcceptanceLetter   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_acceptance_ID = new DataColumn("acceptance_ID" , typeof(string));
			DataColumn col_tender_ID = new DataColumn("tender_ID" , typeof(string));
			DataColumn col_acceptanceLetterDate = new DataColumn("acceptanceLetterDate" , typeof(DateTime));
			DataColumn col_acceptanceLetterRefNo = new DataColumn("acceptanceLetterRefNo" , typeof(string));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_acceptance_ID,col_tender_ID,col_acceptanceLetterDate,col_acceptanceLetterRefNo,col_isCanceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ttsAcceptanceLetter datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsAcceptanceLetter object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsAcceptanceLetter user) {
		DataRow drow = dt.NewRow();
		
			drow["acceptance_ID"] = user.acceptance_ID;
			drow["tender_ID"] = user.tender_ID;
			drow["acceptanceLetterDate"] = user.acceptanceLetterDate;
			drow["acceptanceLetterRefNo"] = user.acceptanceLetterRefNo;
			drow["isCanceled"] = user.isCanceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
