using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_tasHolidayCalander {
		#region Fields
		private string holiday_ID;
		private DateTime holiday_Date;
		private string holydayType_ID;
		private string holiday_Description;
		private int holidayDurationType;
		private int holiday_Hours;
		private bool holiday_Status;
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
		/// Initializes a new instance of the tbl_tasHolidayCalander class.
		/// </summary>
		public tbl_tasHolidayCalander() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasHolidayCalander class.
		/// </summary>
		public tbl_tasHolidayCalander(string holiday_ID, DateTime holiday_Date, string holydayType_ID, string holiday_Description, int holidayDurationType, int holiday_Hours, bool holiday_Status, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.holiday_ID = holiday_ID;
			this.holiday_Date = holiday_Date;
			this.holydayType_ID = holydayType_ID;
			this.holiday_Description = holiday_Description;
			this.holidayDurationType = holidayDurationType;
			this.holiday_Hours = holiday_Hours;
			this.holiday_Status = holiday_Status;
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
		/// Gets or sets the Holiday_ID value.
		/// </summary>
		public string Holiday_ID {
			get { return holiday_ID; }
			set { holiday_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Holiday_Date value.
		/// </summary>
		public DateTime Holiday_Date {
			get { return holiday_Date; }
			set { holiday_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the HolydayType_ID value.
		/// </summary>
		public string HolydayType_ID {
			get { return holydayType_ID; }
			set { holydayType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Holiday_Description value.
		/// </summary>
		public string Holiday_Description {
			get { return holiday_Description; }
			set { holiday_Description = value; }
		}
		
		/// <summary>
		/// Gets or sets the HolidayDurationType value.
		/// </summary>
		public int HolidayDurationType {
			get { return holidayDurationType; }
			set { holidayDurationType = value; }
		}
		
		/// <summary>
		/// Gets or sets the Holiday_Hours value.
		/// </summary>
		public int Holiday_Hours {
			get { return holiday_Hours; }
			set { holiday_Hours = value; }
		}
		
		/// <summary>
		/// Gets or sets the Holiday_Status value.
		/// </summary>
		public bool Holiday_Status {
			get { return holiday_Status; }
			set { holiday_Status = value; }
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
		/// Saves a record to the tbl_tasHolidayCalander table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasHolidayCalanderInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@holiday_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@holiday_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@holydayType_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@holiday_Description", SqlDbType.VarChar,100);
			scom.Parameters.Add("@holidayDurationType", SqlDbType.Int,4);
			scom.Parameters.Add("@holiday_Hours", SqlDbType.Int,4);
			scom.Parameters.Add("@holiday_Status", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
			scom.Parameters["@holiday_ID"].Value = holiday_ID;
			scom.Parameters["@holiday_Date"].Value = holiday_Date;
			scom.Parameters["@holydayType_ID"].Value = holydayType_ID;
			scom.Parameters["@holiday_Description"].Value = holiday_Description;
			scom.Parameters["@holidayDurationType"].Value = holidayDurationType;
			scom.Parameters["@holiday_Hours"].Value = holiday_Hours;
			scom.Parameters["@holiday_Status"].Value = holiday_Status;
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
		/// Updates a record in the tbl_tasHolidayCalander table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasHolidayCalanderUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@holiday_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@holiday_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@holydayType_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@holiday_Description", SqlDbType.VarChar,100);
			scom.Parameters.Add("@holidayDurationType", SqlDbType.Int,4);
			scom.Parameters.Add("@holiday_Hours", SqlDbType.Int,4);
			scom.Parameters.Add("@holiday_Status", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@holiday_ID"].Value = holiday_ID;
			scom.Parameters["@holiday_Date"].Value = holiday_Date;
			scom.Parameters["@holydayType_ID"].Value = holydayType_ID;
			scom.Parameters["@holiday_Description"].Value = holiday_Description;
			scom.Parameters["@holidayDurationType"].Value = holidayDurationType;
			scom.Parameters["@holiday_Hours"].Value = holiday_Hours;
			scom.Parameters["@holiday_Status"].Value = holiday_Status;
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
		/// Deletes a record from the tbl_tasHolidayCalander table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasHolidayCalanderDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@holiday_ID", SqlDbType.VarChar,8);
			scom.Parameters["@holiday_ID"].Value = holiday_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasHolidayCalander table by a foreign key.
		/// </summary>
		public static void DeleteAllByHolydayType_ID(string holydayType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasHolidayCalanderDeleteAllByHolydayType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@holydayType_ID", SqlDbType.VarChar,8);
			scom.Parameters["@holydayType_ID"].Value = holydayType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_tasHolidayCalander table.
		/// </summary>
		public static tbl_tasHolidayCalander Select(string holiday_ID_Incoming){

			tbl_tasHolidayCalander tbl_tasHolidayCalanderins = new tbl_tasHolidayCalander();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasHolidayCalanderSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@holiday_ID", SqlDbType.VarChar,8);
			scom.Parameters["@holiday_ID"].Value = holiday_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_tasHolidayCalanderins = Maketbl_tasHolidayCalander(dataReader);
				} else {
					tbl_tasHolidayCalanderins = null;
				}
			}
			scon.Close();
			return tbl_tasHolidayCalanderins;
		}

        public static tbl_tasHolidayCalander SelectByHolidayDate(DateTime holiday_Date_Incoming)
        {

            tbl_tasHolidayCalander tbl_tasHolidayCalanderins = new tbl_tasHolidayCalander();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("sp_GetAllHolidaysBy_HolidayDate", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@HolidayDate", SqlDbType.DateTime, 8);
            scom.Parameters["@HolidayDate"].Value = holiday_Date_Incoming;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    tbl_tasHolidayCalanderins = Maketbl_tasHolidayCalander(dataReader);
                }
                else
                {
                    tbl_tasHolidayCalanderins = null;
                }
            }
            scon.Close();
            return tbl_tasHolidayCalanderins;
        }



		/// <summary>
		/// Selects all records from the tbl_tasHolidayCalander table.
		/// </summary>
		public static List<tbl_tasHolidayCalander> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasHolidayCalanderSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_tasHolidayCalander> tbl_tasHolidayCalanderList = new List<tbl_tasHolidayCalander>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasHolidayCalander tbl_tasHolidayCalander = Maketbl_tasHolidayCalander(dataReader);
					tbl_tasHolidayCalanderList.Add(tbl_tasHolidayCalander);
				}
			}
			scon.Close();
			return tbl_tasHolidayCalanderList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasHolidayCalander table by a foreign key.
		/// </summary>
		public static List<tbl_tasHolidayCalander> SelectAllByHolydayType_ID(string holydayType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasHolidayCalanderSelectAllByHolydayType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@holydayType_ID", SqlDbType.VarChar,8);
			scom.Parameters["@holydayType_ID"].Value = holydayType_ID;
				List<tbl_tasHolidayCalander> tbl_tasHolidayCalanderList = new List<tbl_tasHolidayCalander>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasHolidayCalander tbl_tasHolidayCalander = Maketbl_tasHolidayCalander(dataReader);
					tbl_tasHolidayCalanderList.Add(tbl_tasHolidayCalander);
				}
			}
			scon.Close();
			return tbl_tasHolidayCalanderList;
		}
        public static List<tbl_tasHolidayCalander> SelectAllByHolyday_Date(DateTime holiday_DateFrom, DateTime holiday_DateTo)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_tasHolidayCalanderSelectAllByHolydayDate", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@holiday_DateFrom", SqlDbType.DateTime, 1);
            scom.Parameters["@holiday_DateFrom"].Value = holiday_DateFrom;
            scom.Parameters.Add("@holiday_DateTo", SqlDbType.DateTime, 1);
            scom.Parameters["@holiday_DateTo"].Value = holiday_DateTo;

            List<tbl_tasHolidayCalander> tbl_tasHolidayCalanderList = new List<tbl_tasHolidayCalander>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_tasHolidayCalander tbl_tasHolidayCalander = Maketbl_tasHolidayCalander(dataReader);
                    tbl_tasHolidayCalanderList.Add(tbl_tasHolidayCalander);
                }
            }
            scon.Close();
            return tbl_tasHolidayCalanderList;
        }
		
	
		/// <summary>
		/// Creates a new instance of the tbl_tasHolidayCalander class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_tasHolidayCalander Maketbl_tasHolidayCalander(SqlDataReader dataReader) {
			tbl_tasHolidayCalander tbl_tasHolidayCalander = new tbl_tasHolidayCalander();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_tasHolidayCalander.Holiday_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasHolidayCalander.Holiday_Date = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasHolidayCalander.HolydayType_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_tasHolidayCalander.Holiday_Description = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_tasHolidayCalander.HolidayDurationType = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_tasHolidayCalander.Holiday_Hours = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_tasHolidayCalander.Holiday_Status = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_tasHolidayCalander.IsCanceled = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_tasHolidayCalander.UserID_Created = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_tasHolidayCalander.UserID_Modified = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_tasHolidayCalander.UserID_Canceled = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_tasHolidayCalander.TerminalID_Created = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_tasHolidayCalander.TerminalID_Modified = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_tasHolidayCalander.TerminalID_Canceled = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_tasHolidayCalander.Date_Created = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_tasHolidayCalander.Date_Modified = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_tasHolidayCalander.Date_Canceled = dataReader.GetDateTime(16);
			}

			return tbl_tasHolidayCalander;
		}
		/// <summary>
		/// This makes tbl_tasHolidayCalander datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasHolidayCalander object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasHolidayCalander  tbl_tasHolidayCalander   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_holiday_ID = new DataColumn("holiday_ID" , typeof(string));
			DataColumn col_holiday_Date = new DataColumn("holiday_Date" , typeof(DateTime));
			DataColumn col_holydayType_ID = new DataColumn("holydayType_ID" , typeof(string));
			DataColumn col_holiday_Description = new DataColumn("holiday_Description" , typeof(string));
			DataColumn col_holidayDurationType = new DataColumn("holidayDurationType" , typeof(int));
			DataColumn col_holiday_Hours = new DataColumn("holiday_Hours" , typeof(int));
			DataColumn col_holiday_Status = new DataColumn("holiday_Status" , typeof(bool));
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
		dt.Columns.AddRange(new DataColumn[] { col_holiday_ID,col_holiday_Date,col_holydayType_ID,col_holiday_Description,col_holidayDurationType,col_holiday_Hours,col_holiday_Status,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasHolidayCalander datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasHolidayCalander object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasHolidayCalander user) {
		DataRow drow = dt.NewRow();
		
			drow["holiday_ID"] = user.holiday_ID;
			drow["holiday_Date"] = user.holiday_Date;
			drow["holydayType_ID"] = user.holydayType_ID;
			drow["holiday_Description"] = user.holiday_Description;
			drow["holidayDurationType"] = user.holidayDurationType;
			drow["holiday_Hours"] = user.holiday_Hours;
			drow["holiday_Status"] = user.holiday_Status;
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
