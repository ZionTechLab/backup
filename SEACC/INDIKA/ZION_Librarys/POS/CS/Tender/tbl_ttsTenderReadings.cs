using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsTenderReadings {
		#region Fields
		private string tender_ID;
		private DateTime tenderReading_Date;
		private bool isCanceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderReadings class.
		/// </summary>
		public tbl_ttsTenderReadings() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderReadings class.
		/// </summary>
		public tbl_ttsTenderReadings(string tender_ID, DateTime tenderReading_Date, bool isCanceled) {
			this.tender_ID = tender_ID;
			this.tenderReading_Date = tenderReading_Date;
			this.isCanceled = isCanceled;
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
		/// Gets or sets the TenderReading_Date value.
		/// </summary>
		public DateTime TenderReading_Date {
			get { return tenderReading_Date; }
			set { tenderReading_Date = value; }
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
		/// Saves a record to the tbl_ttsTenderReadings table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderReadingsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@tenderReading_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@tenderReading_Date"].Value = tenderReading_Date;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ttsTenderReadings table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderReadingsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@tenderReading_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@tenderReading_Date"].Value = tenderReading_Date;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ttsTenderReadings table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderReadingsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderReadings table by a foreign key.
		/// </summary>
		public static void DeleteAllByTender_ID(string tender_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderReadingsDeleteAllByTender_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;

			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ttsTenderReadings table.
		/// </summary>
		public static tbl_ttsTenderReadings Select(string tender_ID_Incoming){

			tbl_ttsTenderReadings tbl_ttsTenderReadingsins = new tbl_ttsTenderReadings();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderReadingsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ttsTenderReadingsins = Maketbl_ttsTenderReadings(dataReader);
				} else {
					tbl_ttsTenderReadingsins = null;
				}
			}
			scon.Close();
			return tbl_ttsTenderReadingsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderReadings table.
		/// </summary>
		public static List<tbl_ttsTenderReadings> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderReadingsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsTenderReadings> tbl_ttsTenderReadingsList = new List<tbl_ttsTenderReadings>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderReadings tbl_ttsTenderReadings = Maketbl_ttsTenderReadings(dataReader);
					tbl_ttsTenderReadingsList.Add(tbl_ttsTenderReadings);
				}
			}
			scon.Close();
			return tbl_ttsTenderReadingsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderReadings table by a foreign key.
		/// </summary>
		public static List<tbl_ttsTenderReadings> SelectAllByTender_ID(string tender_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderReadingsSelectAllByTender_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
				List<tbl_ttsTenderReadings> tbl_ttsTenderReadingsList = new List<tbl_ttsTenderReadings>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderReadings tbl_ttsTenderReadings = Maketbl_ttsTenderReadings(dataReader);
					tbl_ttsTenderReadingsList.Add(tbl_ttsTenderReadings);
				}
			}
			scon.Close();
			return tbl_ttsTenderReadingsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ttsTenderReadings class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsTenderReadings Maketbl_ttsTenderReadings(SqlDataReader dataReader) {
			tbl_ttsTenderReadings tbl_ttsTenderReadings = new tbl_ttsTenderReadings();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsTenderReadings.Tender_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsTenderReadings.TenderReading_Date = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ttsTenderReadings.IsCanceled = dataReader.GetBoolean(2);
			}

			return tbl_ttsTenderReadings;
		}
		/// <summary>
		/// This makes tbl_ttsTenderReadings datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsTenderReadings object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsTenderReadings  tbl_ttsTenderReadings   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_tender_ID = new DataColumn("tender_ID" , typeof(string));
			DataColumn col_tenderReading_Date = new DataColumn("tenderReading_Date" , typeof(DateTime));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_tender_ID,col_tenderReading_Date,col_isCanceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ttsTenderReadings datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsTenderReadings object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsTenderReadings user) {
		DataRow drow = dt.NewRow();
		
			drow["tender_ID"] = user.tender_ID;
			drow["tenderReading_Date"] = user.tenderReading_Date;
			drow["isCanceled"] = user.isCanceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
