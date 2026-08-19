using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class sp_genMasTown {
		#region Fields
		private string town_ID;
		private string townName;
		private string city_ID;
		private string cityName;
		private bool isCanceled;
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
		/// Initializes a new instance of the sp_genMasTown class.
		/// </summary>
		public sp_genMasTown() {
		}
		
		/// <summary>
		/// Initializes a new instance of the sp_genMasTown class.
		/// </summary>
		public sp_genMasTown(string town_ID, string townName, string city_ID, string cityName, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.town_ID = town_ID;
			this.townName = townName;
			this.city_ID = city_ID;
			this.cityName = cityName;
			this.isCanceled = isCanceled;
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
		/// Gets or sets the Town_ID value.
		/// </summary>
		public string Town_ID {
			get { return town_ID; }
			set { town_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TownName value.
		/// </summary>
		public string TownName {
			get { return townName; }
			set { townName = value; }
		}
		
		/// <summary>
		/// Gets or sets the City_ID value.
		/// </summary>
		public string City_ID {
			get { return city_ID; }
			set { city_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CityName value.
		/// </summary>
		public string CityName {
			get { return cityName; }
			set { cityName = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
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
		/// Saves a record to the sp_genMasTown table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("sp_genMasTownInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@townName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@cityName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
			scom.Parameters["@town_ID"].Value = town_ID;
			scom.Parameters["@townName"].Value = townName;
			scom.Parameters["@city_ID"].Value = city_ID;
			scom.Parameters["@cityName"].Value = cityName;
			scom.Parameters["@isCanceled"].Value = isCanceled;
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
		/// Updates a record in the sp_genMasTown table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("sp_genMasTownUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@townName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@cityName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@town_ID"].Value = town_ID;
			scom.Parameters["@townName"].Value = townName;
			scom.Parameters["@city_ID"].Value = city_ID;
			scom.Parameters["@cityName"].Value = cityName;
			scom.Parameters["@isCanceled"].Value = isCanceled;
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
		/// Deletes a record from the sp_genMasTown table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("sp_genMasTownDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,8);
			scom.Parameters["@town_ID"].Value = town_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the sp_genMasTown table.
		/// </summary>
		public static sp_genMasTown Select(string town_ID_Incoming){

			sp_genMasTown sp_genMasTownins = new sp_genMasTown();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("sp_genMasTownSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,8);
			scom.Parameters["@town_ID"].Value = town_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					sp_genMasTownins = Makesp_genMasTown(dataReader);
				} else {
					sp_genMasTownins = null;
				}
			}
			scon.Close();
			return sp_genMasTownins;
		}
		
		/// <summary>
		/// Selects all records from the sp_genMasTown table.
		/// </summary>
		public static List<sp_genMasTown> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("sp_genMasTownSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<sp_genMasTown> sp_genMasTownList = new List<sp_genMasTown>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					sp_genMasTown sp_genMasTown = Makesp_genMasTown(dataReader);
					sp_genMasTownList.Add(sp_genMasTown);
				}
			}
			scon.Close();
			return sp_genMasTownList;
		}
		
		/// <summary>
		/// Creates a new instance of the sp_genMasTown class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static sp_genMasTown Makesp_genMasTown(SqlDataReader dataReader) {
			sp_genMasTown sp_genMasTown = new sp_genMasTown();
			
			if (dataReader.IsDBNull(0) == false) {
				sp_genMasTown.Town_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				sp_genMasTown.TownName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				sp_genMasTown.City_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				sp_genMasTown.CityName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				sp_genMasTown.IsCanceled = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				sp_genMasTown.UserID_Created = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				sp_genMasTown.UserID_Modified = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				sp_genMasTown.UserID_Canceled = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				sp_genMasTown.TerminalID_Created = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				sp_genMasTown.TerminalID_Modified = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				sp_genMasTown.TerminalID_Canceled = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				sp_genMasTown.Date_Created = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				sp_genMasTown.Date_Modified = dataReader.GetDateTime(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				sp_genMasTown.Date_Canceled = dataReader.GetDateTime(13);
			}

			return sp_genMasTown;
		}
		/// <summary>
		/// This makes sp_genMasTown datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new sp_genMasTown object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( sp_genMasTown  sp_genMasTown   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_town_ID = new DataColumn("town_ID" , typeof(string));
			DataColumn col_townName = new DataColumn("townName" , typeof(string));
			DataColumn col_city_ID = new DataColumn("city_ID" , typeof(string));
			DataColumn col_cityName = new DataColumn("cityName" , typeof(string));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Modified = new DataColumn("terminalID_Modified" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Modified = new DataColumn("date_Modified" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_town_ID,col_townName,col_city_ID,col_cityName,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills sp_genMasTown datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new sp_genMasTown object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, sp_genMasTown user) {
		DataRow drow = dt.NewRow();
		
			drow["town_ID"] = user.town_ID;
			drow["townName"] = user.townName;
			drow["city_ID"] = user.city_ID;
			drow["cityName"] = user.cityName;
			drow["isCanceled"] = user.isCanceled;
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
