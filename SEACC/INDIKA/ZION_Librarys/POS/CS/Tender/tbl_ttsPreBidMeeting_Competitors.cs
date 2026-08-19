using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsPreBidMeeting_Competitors {
		#region Fields
		private string preBidMeeting_ID;
		private string lineNo;
		private string competitor_Id;
		private string representer_Name;
		private string representer_Designation;
		private string remarks;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsPreBidMeeting_Competitors class.
		/// </summary>
		public tbl_ttsPreBidMeeting_Competitors() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsPreBidMeeting_Competitors class.
		/// </summary>
		public tbl_ttsPreBidMeeting_Competitors(string preBidMeeting_ID, string lineNo, string competitor_Id, string representer_Name, string representer_Designation, string remarks) {
			this.preBidMeeting_ID = preBidMeeting_ID;
			this.lineNo = lineNo;
			this.competitor_Id = competitor_Id;
			this.representer_Name = representer_Name;
			this.representer_Designation = representer_Designation;
			this.remarks = remarks;
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
		/// Gets or sets the LineNo value.
		/// </summary>
		public string LineNo {
			get { return lineNo; }
			set { lineNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Competitor_Id value.
		/// </summary>
		public string Competitor_Id {
			get { return competitor_Id; }
			set { competitor_Id = value; }
		}
		
		/// <summary>
		/// Gets or sets the Representer_Name value.
		/// </summary>
		public string Representer_Name {
			get { return representer_Name; }
			set { representer_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the Representer_Designation value.
		/// </summary>
		public string Representer_Designation {
			get { return representer_Designation; }
			set { representer_Designation = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ttsPreBidMeeting_Competitors table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsPreBidMeeting_CompetitorsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@preBidMeeting_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@lineNo", SqlDbType.VarChar,10);
			scom.Parameters.Add("@competitor_Id", SqlDbType.VarChar,20);
			scom.Parameters.Add("@representer_Name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@representer_Designation", SqlDbType.VarChar,100);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,500);
 
			scom.Parameters["@preBidMeeting_ID"].Value = preBidMeeting_ID;
			scom.Parameters["@lineNo"].Value = lineNo;
			scom.Parameters["@competitor_Id"].Value = competitor_Id;
			scom.Parameters["@representer_Name"].Value = representer_Name;
			scom.Parameters["@representer_Designation"].Value = representer_Designation;
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ttsPreBidMeeting_Competitors table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsPreBidMeeting_CompetitorsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@preBidMeeting_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@lineNo", SqlDbType.VarChar,10);
			scom.Parameters.Add("@competitor_Id", SqlDbType.VarChar,20);
			scom.Parameters.Add("@representer_Name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@representer_Designation", SqlDbType.VarChar,100);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,500);
 
 
			scom.Parameters["@preBidMeeting_ID"].Value = preBidMeeting_ID;
			scom.Parameters["@lineNo"].Value = lineNo;
			scom.Parameters["@competitor_Id"].Value = competitor_Id;
			scom.Parameters["@representer_Name"].Value = representer_Name;
			scom.Parameters["@representer_Designation"].Value = representer_Designation;
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ttsPreBidMeeting_Competitors table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsPreBidMeeting_CompetitorsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@preBidMeeting_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@lineNo", SqlDbType.VarChar,10);
			scom.Parameters["@preBidMeeting_ID"].Value = preBidMeeting_ID;
 
			scom.Parameters["@lineNo"].Value = lineNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsPreBidMeeting_Competitors table by a foreign key.
		/// </summary>
		public static void DeleteAllByPreBidMeeting_ID(string preBidMeeting_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsPreBidMeeting_CompetitorsDeleteAllByPreBidMeeting_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@preBidMeeting_ID", SqlDbType.VarChar,10);
			scom.Parameters["@preBidMeeting_ID"].Value = preBidMeeting_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsPreBidMeeting_Competitors table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompetitor_Id(string competitor_Id) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsPreBidMeeting_CompetitorsDeleteAllByCompetitor_Id", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@competitor_Id", SqlDbType.VarChar,20);
			scom.Parameters["@competitor_Id"].Value = competitor_Id;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ttsPreBidMeeting_Competitors table.
		/// </summary>
		public static tbl_ttsPreBidMeeting_Competitors Select(string preBidMeeting_ID_Incoming, string lineNo_Incoming){

			tbl_ttsPreBidMeeting_Competitors tbl_ttsPreBidMeeting_Competitorsins = new tbl_ttsPreBidMeeting_Competitors();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsPreBidMeeting_CompetitorsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@preBidMeeting_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@lineNo", SqlDbType.VarChar,10);
			scom.Parameters["@preBidMeeting_ID"].Value = preBidMeeting_ID_Incoming;
			scom.Parameters["@lineNo"].Value = lineNo_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ttsPreBidMeeting_Competitorsins = Maketbl_ttsPreBidMeeting_Competitors(dataReader);
				} else {
					tbl_ttsPreBidMeeting_Competitorsins = null;
				}
			}
			scon.Close();
			return tbl_ttsPreBidMeeting_Competitorsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsPreBidMeeting_Competitors table.
		/// </summary>
		public static List<tbl_ttsPreBidMeeting_Competitors> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsPreBidMeeting_CompetitorsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsPreBidMeeting_Competitors> tbl_ttsPreBidMeeting_CompetitorsList = new List<tbl_ttsPreBidMeeting_Competitors>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsPreBidMeeting_Competitors tbl_ttsPreBidMeeting_Competitors = Maketbl_ttsPreBidMeeting_Competitors(dataReader);
					tbl_ttsPreBidMeeting_CompetitorsList.Add(tbl_ttsPreBidMeeting_Competitors);
				}
			}
			scon.Close();
			return tbl_ttsPreBidMeeting_CompetitorsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsPreBidMeeting_Competitors table by a foreign key.
		/// </summary>
		public static List<tbl_ttsPreBidMeeting_Competitors> SelectAllByPreBidMeeting_ID(string preBidMeeting_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsPreBidMeeting_CompetitorsSelectAllByPreBidMeeting_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@preBidMeeting_ID", SqlDbType.VarChar,10);
			scom.Parameters["@preBidMeeting_ID"].Value = preBidMeeting_ID;
				List<tbl_ttsPreBidMeeting_Competitors> tbl_ttsPreBidMeeting_CompetitorsList = new List<tbl_ttsPreBidMeeting_Competitors>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsPreBidMeeting_Competitors tbl_ttsPreBidMeeting_Competitors = Maketbl_ttsPreBidMeeting_Competitors(dataReader);
					tbl_ttsPreBidMeeting_CompetitorsList.Add(tbl_ttsPreBidMeeting_Competitors);
				}
			}
			scon.Close();
			return tbl_ttsPreBidMeeting_CompetitorsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsPreBidMeeting_Competitors table by a foreign key.
		/// </summary>
		public static List<tbl_ttsPreBidMeeting_Competitors> SelectAllByCompetitor_Id(string competitor_Id) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsPreBidMeeting_CompetitorsSelectAllByCompetitor_Id", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@competitor_Id", SqlDbType.VarChar,20);
			scom.Parameters["@competitor_Id"].Value = competitor_Id;
				List<tbl_ttsPreBidMeeting_Competitors> tbl_ttsPreBidMeeting_CompetitorsList = new List<tbl_ttsPreBidMeeting_Competitors>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsPreBidMeeting_Competitors tbl_ttsPreBidMeeting_Competitors = Maketbl_ttsPreBidMeeting_Competitors(dataReader);
					tbl_ttsPreBidMeeting_CompetitorsList.Add(tbl_ttsPreBidMeeting_Competitors);
				}
			}
			scon.Close();
			return tbl_ttsPreBidMeeting_CompetitorsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ttsPreBidMeeting_Competitors class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsPreBidMeeting_Competitors Maketbl_ttsPreBidMeeting_Competitors(SqlDataReader dataReader) {
			tbl_ttsPreBidMeeting_Competitors tbl_ttsPreBidMeeting_Competitors = new tbl_ttsPreBidMeeting_Competitors();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsPreBidMeeting_Competitors.PreBidMeeting_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsPreBidMeeting_Competitors.LineNo = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ttsPreBidMeeting_Competitors.Competitor_Id = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ttsPreBidMeeting_Competitors.Representer_Name = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ttsPreBidMeeting_Competitors.Representer_Designation = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ttsPreBidMeeting_Competitors.Remarks = dataReader.GetString(5);
			}

			return tbl_ttsPreBidMeeting_Competitors;
		}
		/// <summary>
		/// This makes tbl_ttsPreBidMeeting_Competitors datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsPreBidMeeting_Competitors object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsPreBidMeeting_Competitors  tbl_ttsPreBidMeeting_Competitors   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_preBidMeeting_ID = new DataColumn("preBidMeeting_ID" , typeof(string));
			DataColumn col_lineNo = new DataColumn("lineNo" , typeof(string));
			DataColumn col_competitor_Id = new DataColumn("competitor_Id" , typeof(string));
			DataColumn col_representer_Name = new DataColumn("representer_Name" , typeof(string));
			DataColumn col_representer_Designation = new DataColumn("representer_Designation" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_preBidMeeting_ID,col_lineNo,col_competitor_Id,col_representer_Name,col_representer_Designation,col_remarks,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ttsPreBidMeeting_Competitors datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsPreBidMeeting_Competitors object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsPreBidMeeting_Competitors user) {
		DataRow drow = dt.NewRow();
		
			drow["preBidMeeting_ID"] = user.preBidMeeting_ID;
			drow["lineNo"] = user.lineNo;
			drow["competitor_Id"] = user.competitor_Id;
			drow["representer_Name"] = user.representer_Name;
			drow["representer_Designation"] = user.representer_Designation;
			drow["remarks"] = user.remarks;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
