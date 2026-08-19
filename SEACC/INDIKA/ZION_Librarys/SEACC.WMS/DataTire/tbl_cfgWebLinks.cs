using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_cfgWebLinks {
		#region Fields
		private string wb_ID;
		private string wb_Name;
		private string wb_description;
		private string wb_link;
		private bool isCancled;
		private string userID_Created;
		private string userID_Modified;
		private string userID_Canceled;
		private string terminalID_Created;
		private string terminalID_Modified;
		private string terminalID_Canceled;
		private DateTime date_Created;
		private DateTime date_Modified;
		private DateTime date_Canceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_cfgWebLinks class.
		/// </summary>
		public tbl_cfgWebLinks() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_cfgWebLinks class.
		/// </summary>
		public tbl_cfgWebLinks(string wb_ID, string wb_Name, string wb_description, string wb_link, bool isCancled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.wb_ID = wb_ID;
			this.wb_Name = wb_Name;
			this.wb_description = wb_description;
			this.wb_link = wb_link;
			this.isCancled = isCancled;
			this.userID_Created = userID_Created;
			this.userID_Modified = userID_Modified;
			this.userID_Canceled = userID_Canceled;
			this.terminalID_Created = terminalID_Created;
			this.terminalID_Modified = terminalID_Modified;
			this.terminalID_Canceled = terminalID_Canceled;
			this.date_Created = date_Created;
			this.date_Modified = date_Modified;
			this.date_Canceled = date_Canceled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Wb_ID value.
		/// </summary>
		public string Wb_ID {
			get { return wb_ID; }
			set { wb_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Wb_Name value.
		/// </summary>
		public string Wb_Name {
			get { return wb_Name; }
			set { wb_Name = value; }
		}
		
		/// <summary>
		/// Gets or sets the Wb_description value.
		/// </summary>
		public string Wb_description {
			get { return wb_description; }
			set { wb_description = value; }
		}
		
		/// <summary>
		/// Gets or sets the Wb_link value.
		/// </summary>
		public string Wb_link {
			get { return wb_link; }
			set { wb_link = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCancled value.
		/// </summary>
		public bool IsCancled {
			get { return isCancled; }
			set { isCancled = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Created value.
		/// </summary>
		public string UserID_Created {
			get { return userID_Created; }
			set { userID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Modified value.
		/// </summary>
		public string UserID_Modified {
			get { return userID_Modified; }
			set { userID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Canceled value.
		/// </summary>
		public string UserID_Canceled {
			get { return userID_Canceled; }
			set { userID_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Created value.
		/// </summary>
		public string TerminalID_Created {
			get { return terminalID_Created; }
			set { terminalID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Modified value.
		/// </summary>
		public string TerminalID_Modified {
			get { return terminalID_Modified; }
			set { terminalID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Canceled value.
		/// </summary>
		public string TerminalID_Canceled {
			get { return terminalID_Canceled; }
			set { terminalID_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Created value.
		/// </summary>
		public DateTime Date_Created {
			get { return date_Created; }
			set { date_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Modified value.
		/// </summary>
		public DateTime Date_Modified {
			get { return date_Modified; }
			set { date_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Canceled value.
		/// </summary>
		public DateTime Date_Canceled {
			get { return date_Canceled; }
			set { date_Canceled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_cfgWebLinks table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgWebLinksInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@wb_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@wb_Name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@wb_description", SqlDbType.VarChar,8000);
			scom.Parameters.Add("@wb_link", SqlDbType.VarChar,8000);
			scom.Parameters.Add("@isCancled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
			scom.Parameters["@wb_ID"].Value = wb_ID;
			scom.Parameters["@wb_Name"].Value = wb_Name;
			scom.Parameters["@wb_description"].Value = wb_description;
			scom.Parameters["@wb_link"].Value = wb_link;
			scom.Parameters["@isCancled"].Value = isCancled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_cfgWebLinks table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgWebLinksUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@wb_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@wb_Name", SqlDbType.VarChar,100);
			scom.Parameters.Add("@wb_description", SqlDbType.VarChar,8000);
			scom.Parameters.Add("@wb_link", SqlDbType.VarChar,8000);
			scom.Parameters.Add("@isCancled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@wb_ID"].Value = wb_ID;
			scom.Parameters["@wb_Name"].Value = wb_Name;
			scom.Parameters["@wb_description"].Value = wb_description;
			scom.Parameters["@wb_link"].Value = wb_link;
			scom.Parameters["@isCancled"].Value = isCancled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_cfgWebLinks table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgWebLinksDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@wb_ID", SqlDbType.VarChar,8);
			scom.Parameters["@wb_ID"].Value = wb_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_cfgWebLinks table.
		/// </summary>
		public static tbl_cfgWebLinks Select(string wb_ID_Incoming){

			tbl_cfgWebLinks tbl_cfgWebLinksins = new tbl_cfgWebLinks();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgWebLinksSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@wb_ID", SqlDbType.VarChar,8);
			scom.Parameters["@wb_ID"].Value = wb_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_cfgWebLinksins = Maketbl_cfgWebLinks(dataReader);
				} else {
					tbl_cfgWebLinksins = null;
				}
			}
			scon.Close();
			return tbl_cfgWebLinksins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_cfgWebLinks table.
		/// </summary>
		public static List<tbl_cfgWebLinks> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgWebLinksSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_cfgWebLinks> tbl_cfgWebLinksList = new List<tbl_cfgWebLinks>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_cfgWebLinks tbl_cfgWebLinks = Maketbl_cfgWebLinks(dataReader);
					tbl_cfgWebLinksList.Add(tbl_cfgWebLinks);
				}
			}
			scon.Close();
			return tbl_cfgWebLinksList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_cfgWebLinks class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_cfgWebLinks Maketbl_cfgWebLinks(SqlDataReader dataReader) {
			tbl_cfgWebLinks tbl_cfgWebLinks = new tbl_cfgWebLinks();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_cfgWebLinks.Wb_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_cfgWebLinks.Wb_Name = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_cfgWebLinks.Wb_description = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_cfgWebLinks.Wb_link = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_cfgWebLinks.IsCancled = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_cfgWebLinks.UserID_Created = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_cfgWebLinks.UserID_Modified = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_cfgWebLinks.UserID_Canceled = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_cfgWebLinks.TerminalID_Created = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_cfgWebLinks.TerminalID_Modified = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_cfgWebLinks.TerminalID_Canceled = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_cfgWebLinks.Date_Created = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_cfgWebLinks.Date_Modified = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_cfgWebLinks.Date_Canceled = dataReader.GetDateTime(13);
			}

			return tbl_cfgWebLinks;
		}
		/// <summary>
		/// This makes tbl_cfgWebLinks datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_cfgWebLinks object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_cfgWebLinks  tbl_cfgWebLinks   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_wb_ID = new DataColumn("wb_ID" , typeof(string));
			DataColumn col_wb_Name = new DataColumn("wb_Name" , typeof(string));
			DataColumn col_wb_description = new DataColumn("wb_description" , typeof(string));
			DataColumn col_wb_link = new DataColumn("wb_link" , typeof(string));
			DataColumn col_isCancled = new DataColumn("isCancled" , typeof(bool));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Modified = new DataColumn("terminalID_Modified" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Modified = new DataColumn("date_Modified" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_wb_ID,col_wb_Name,col_wb_description,col_wb_link,col_isCancled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_cfgWebLinks datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_cfgWebLinks object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_cfgWebLinks user) {
		DataRow drow = dt.NewRow();
		
			drow["wb_ID"] = user.wb_ID;
			drow["wb_Name"] = user.wb_Name;
			drow["wb_description"] = user.wb_description;
			drow["wb_link"] = user.wb_link;
			drow["isCancled"] = user.isCancled;
			drow["userID_Created"] = user.userID_Created;
			drow["userID_Modified"] = user.userID_Modified;
			drow["userID_Canceled"] = user.userID_Canceled;
			drow["terminalID_Created"] = user.terminalID_Created;
			drow["terminalID_Modified"] = user.terminalID_Modified;
			drow["terminalID_Canceled"] = user.terminalID_Canceled;
			drow["date_Created"] = user.date_Created;
			drow["date_Modified"] = user.date_Modified;
			drow["date_Canceled"] = user.date_Canceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
