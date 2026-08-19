using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsPreBidMeeting {
		#region Fields
		private string preBidMeeting_ID;
		private string tender_ID;
		private DateTime preBidMeeting_Date;
		private string preBidMeeting_Address1;
		private string preBidMeeting_Address2;
		private string preBidMeeting_Country_ID;
		private string preBidMeeting_City_ID;
		private string preBidMeeting_Town_ID;
		private string remarks;
		private bool isCanceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsPreBidMeeting class.
		/// </summary>
		public tbl_ttsPreBidMeeting() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsPreBidMeeting class.
		/// </summary>
		public tbl_ttsPreBidMeeting(string preBidMeeting_ID, string tender_ID, DateTime preBidMeeting_Date, string preBidMeeting_Address1, string preBidMeeting_Address2, string preBidMeeting_Country_ID, string preBidMeeting_City_ID, string preBidMeeting_Town_ID, string remarks, bool isCanceled) {
			this.preBidMeeting_ID = preBidMeeting_ID;
			this.tender_ID = tender_ID;
			this.preBidMeeting_Date = preBidMeeting_Date;
			this.preBidMeeting_Address1 = preBidMeeting_Address1;
			this.preBidMeeting_Address2 = preBidMeeting_Address2;
			this.preBidMeeting_Country_ID = preBidMeeting_Country_ID;
			this.preBidMeeting_City_ID = preBidMeeting_City_ID;
			this.preBidMeeting_Town_ID = preBidMeeting_Town_ID;
			this.remarks = remarks;
			this.isCanceled = isCanceled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the PreBidMeeting_ID value.
		/// </summary>
		public string PreBidMeeting_ID {
			get { return preBidMeeting_ID; }
			set { preBidMeeting_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tender_ID value.
		/// </summary>
		public string Tender_ID {
			get { return tender_ID; }
			set { tender_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PreBidMeeting_Date value.
		/// </summary>
		public DateTime PreBidMeeting_Date {
			get { return preBidMeeting_Date; }
			set { preBidMeeting_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the PreBidMeeting_Address1 value.
		/// </summary>
		public string PreBidMeeting_Address1 {
			get { return preBidMeeting_Address1; }
			set { preBidMeeting_Address1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the PreBidMeeting_Address2 value.
		/// </summary>
		public string PreBidMeeting_Address2 {
			get { return preBidMeeting_Address2; }
			set { preBidMeeting_Address2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the PreBidMeeting_Country_ID value.
		/// </summary>
		public string PreBidMeeting_Country_ID {
			get { return preBidMeeting_Country_ID; }
			set { preBidMeeting_Country_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PreBidMeeting_City_ID value.
		/// </summary>
		public string PreBidMeeting_City_ID {
			get { return preBidMeeting_City_ID; }
			set { preBidMeeting_City_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PreBidMeeting_Town_ID value.
		/// </summary>
		public string PreBidMeeting_Town_ID {
			get { return preBidMeeting_Town_ID; }
			set { preBidMeeting_Town_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
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
		/// Saves a record to the tbl_ttsPreBidMeeting table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsPreBidMeetingInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@preBidMeeting_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@preBidMeeting_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@preBidMeeting_Address1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@preBidMeeting_Address2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@preBidMeeting_Country_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@preBidMeeting_City_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@preBidMeeting_Town_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,1000);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
			scom.Parameters["@preBidMeeting_ID"].Value = preBidMeeting_ID;
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@preBidMeeting_Date"].Value = preBidMeeting_Date;
			scom.Parameters["@preBidMeeting_Address1"].Value = preBidMeeting_Address1;
			scom.Parameters["@preBidMeeting_Address2"].Value = preBidMeeting_Address2;
			scom.Parameters["@preBidMeeting_Country_ID"].Value = preBidMeeting_Country_ID;
			scom.Parameters["@preBidMeeting_City_ID"].Value = preBidMeeting_City_ID;
			scom.Parameters["@preBidMeeting_Town_ID"].Value = preBidMeeting_Town_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ttsPreBidMeeting table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsPreBidMeetingUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@preBidMeeting_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@preBidMeeting_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@preBidMeeting_Address1", SqlDbType.VarChar,50);
			scom.Parameters.Add("@preBidMeeting_Address2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@preBidMeeting_Country_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@preBidMeeting_City_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@preBidMeeting_Town_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,1000);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@preBidMeeting_ID"].Value = preBidMeeting_ID;
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@preBidMeeting_Date"].Value = preBidMeeting_Date;
			scom.Parameters["@preBidMeeting_Address1"].Value = preBidMeeting_Address1;
			scom.Parameters["@preBidMeeting_Address2"].Value = preBidMeeting_Address2;
			scom.Parameters["@preBidMeeting_Country_ID"].Value = preBidMeeting_Country_ID;
			scom.Parameters["@preBidMeeting_City_ID"].Value = preBidMeeting_City_ID;
			scom.Parameters["@preBidMeeting_Town_ID"].Value = preBidMeeting_Town_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ttsPreBidMeeting table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsPreBidMeetingDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@preBidMeeting_ID", SqlDbType.VarChar,10);
			scom.Parameters["@preBidMeeting_ID"].Value = preBidMeeting_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsPreBidMeeting table by a foreign key.
		/// </summary>
		public static void DeleteAllByTender_ID(string tender_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsPreBidMeetingDeleteAllByTender_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ttsPreBidMeeting table.
		/// </summary>
		public static tbl_ttsPreBidMeeting Select(string preBidMeeting_ID_Incoming){

			tbl_ttsPreBidMeeting tbl_ttsPreBidMeetingins = new tbl_ttsPreBidMeeting();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsPreBidMeetingSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@preBidMeeting_ID", SqlDbType.VarChar,10);
			scom.Parameters["@preBidMeeting_ID"].Value = preBidMeeting_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ttsPreBidMeetingins = Maketbl_ttsPreBidMeeting(dataReader);
				} else {
					tbl_ttsPreBidMeetingins = null;
				}
			}
			scon.Close();
			return tbl_ttsPreBidMeetingins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsPreBidMeeting table.
		/// </summary>
		public static List<tbl_ttsPreBidMeeting> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsPreBidMeetingSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsPreBidMeeting> tbl_ttsPreBidMeetingList = new List<tbl_ttsPreBidMeeting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsPreBidMeeting tbl_ttsPreBidMeeting = Maketbl_ttsPreBidMeeting(dataReader);
					tbl_ttsPreBidMeetingList.Add(tbl_ttsPreBidMeeting);
				}
			}
			scon.Close();
			return tbl_ttsPreBidMeetingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsPreBidMeeting table by a foreign key.
		/// </summary>
		public static List<tbl_ttsPreBidMeeting> SelectAllByTender_ID(string tender_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsPreBidMeetingSelectAllByTender_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
				List<tbl_ttsPreBidMeeting> tbl_ttsPreBidMeetingList = new List<tbl_ttsPreBidMeeting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsPreBidMeeting tbl_ttsPreBidMeeting = Maketbl_ttsPreBidMeeting(dataReader);
					tbl_ttsPreBidMeetingList.Add(tbl_ttsPreBidMeeting);
				}
			}
			scon.Close();
			return tbl_ttsPreBidMeetingList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ttsPreBidMeeting class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsPreBidMeeting Maketbl_ttsPreBidMeeting(SqlDataReader dataReader) {
			tbl_ttsPreBidMeeting tbl_ttsPreBidMeeting = new tbl_ttsPreBidMeeting();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsPreBidMeeting.PreBidMeeting_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsPreBidMeeting.Tender_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ttsPreBidMeeting.PreBidMeeting_Date = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ttsPreBidMeeting.PreBidMeeting_Address1 = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ttsPreBidMeeting.PreBidMeeting_Address2 = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ttsPreBidMeeting.PreBidMeeting_Country_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_ttsPreBidMeeting.PreBidMeeting_City_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_ttsPreBidMeeting.PreBidMeeting_Town_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_ttsPreBidMeeting.Remarks = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_ttsPreBidMeeting.IsCanceled = dataReader.GetBoolean(9);
			}

			return tbl_ttsPreBidMeeting;
		}
		/// <summary>
		/// This makes tbl_ttsPreBidMeeting datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsPreBidMeeting object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsPreBidMeeting  tbl_ttsPreBidMeeting   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_preBidMeeting_ID = new DataColumn("preBidMeeting_ID" , typeof(string));
			DataColumn col_tender_ID = new DataColumn("tender_ID" , typeof(string));
			DataColumn col_preBidMeeting_Date = new DataColumn("preBidMeeting_Date" , typeof(DateTime));
			DataColumn col_preBidMeeting_Address1 = new DataColumn("preBidMeeting_Address1" , typeof(string));
			DataColumn col_preBidMeeting_Address2 = new DataColumn("preBidMeeting_Address2" , typeof(string));
			DataColumn col_preBidMeeting_Country_ID = new DataColumn("preBidMeeting_Country_ID" , typeof(string));
			DataColumn col_preBidMeeting_City_ID = new DataColumn("preBidMeeting_City_ID" , typeof(string));
			DataColumn col_preBidMeeting_Town_ID = new DataColumn("preBidMeeting_Town_ID" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_preBidMeeting_ID,col_tender_ID,col_preBidMeeting_Date,col_preBidMeeting_Address1,col_preBidMeeting_Address2,col_preBidMeeting_Country_ID,col_preBidMeeting_City_ID,col_preBidMeeting_Town_ID,col_remarks,col_isCanceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ttsPreBidMeeting datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsPreBidMeeting object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsPreBidMeeting user) {
		DataRow drow = dt.NewRow();
		
			drow["preBidMeeting_ID"] = user.preBidMeeting_ID;
			drow["tender_ID"] = user.tender_ID;
			drow["preBidMeeting_Date"] = user.preBidMeeting_Date;
			drow["preBidMeeting_Address1"] = user.preBidMeeting_Address1;
			drow["preBidMeeting_Address2"] = user.preBidMeeting_Address2;
			drow["preBidMeeting_Country_ID"] = user.preBidMeeting_Country_ID;
			drow["preBidMeeting_City_ID"] = user.preBidMeeting_City_ID;
			drow["preBidMeeting_Town_ID"] = user.preBidMeeting_Town_ID;
			drow["remarks"] = user.remarks;
			drow["isCanceled"] = user.isCanceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
