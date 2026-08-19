using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accFinancialYearMaster_Month {
		#region Fields
		private string financialYear_ID;
		private string month_ID;
		private DateTime dateStart;
		private DateTime dateEnd;
		private bool isMonthClose;
		private string closedUser_ID;
		private DateTime dateClosed;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string createTerminal_ID;
		private string modifiedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accFinancialYearMaster_Month class.
		/// </summary>
		public tbl_accFinancialYearMaster_Month() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accFinancialYearMaster_Month class.
		/// </summary>
		public tbl_accFinancialYearMaster_Month(string financialYear_ID, string month_ID, DateTime dateStart, DateTime dateEnd, bool isMonthClose, string closedUser_ID, DateTime dateClosed, string createUser_ID, string modifiedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, DateTime dateCreate, DateTime dateModified) {
			this.financialYear_ID = financialYear_ID;
			this.month_ID = month_ID;
			this.dateStart = dateStart;
			this.dateEnd = dateEnd;
			this.isMonthClose = isMonthClose;
			this.closedUser_ID = closedUser_ID;
			this.dateClosed = dateClosed;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the FinancialYear_ID value.
		/// </summary>
		public string FinancialYear_ID {
			get { return financialYear_ID; }
			set { financialYear_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Month_ID value.
		/// </summary>
		public string Month_ID {
			get { return month_ID; }
			set { month_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateStart value.
		/// </summary>
		public DateTime DateStart {
			get { return dateStart; }
			set { dateStart = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateEnd value.
		/// </summary>
		public DateTime DateEnd {
			get { return dateEnd; }
			set { dateEnd = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsMonthClose value.
		/// </summary>
		public bool IsMonthClose {
			get { return isMonthClose; }
			set { isMonthClose = value; }
		}
		
		/// <summary>
		/// Gets or sets the ClosedUser_ID value.
		/// </summary>
		public string ClosedUser_ID {
			get { return closedUser_ID; }
			set { closedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateClosed value.
		/// </summary>
		public DateTime DateClosed {
			get { return dateClosed; }
			set { dateClosed = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUser_ID value.
		/// </summary>
		public string ModifiedUser_ID {
			get { return modifiedUser_ID; }
			set { modifiedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedTerminal_ID value.
		/// </summary>
		public string ModifiedTerminal_ID {
			get { return modifiedTerminal_ID; }
			set { modifiedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCreate value.
		/// </summary>
		public DateTime DateCreate {
			get { return dateCreate; }
			set { dateCreate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateModified value.
		/// </summary>
		public DateTime DateModified {
			get { return dateModified; }
			set { dateModified = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accFinancialYearMaster_Month table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMaster_MonthInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters.Add("@dateStart", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateEnd", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isMonthClose", SqlDbType.Bit,1);
			scom.Parameters.Add("@closedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateClosed", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
 
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@dateStart"].Value = dateStart;
			scom.Parameters["@dateEnd"].Value = dateEnd;
			scom.Parameters["@isMonthClose"].Value = isMonthClose;
			scom.Parameters["@closedUser_ID"].Value = closedUser_ID;
			scom.Parameters["@dateClosed"].Value = dateClosed;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accFinancialYearMaster_Month table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMaster_MonthUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters.Add("@dateStart", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateEnd", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isMonthClose", SqlDbType.Bit,1);
			scom.Parameters.Add("@closedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateClosed", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@month_ID"].Value = month_ID;
			scom.Parameters["@dateStart"].Value = dateStart;
			scom.Parameters["@dateEnd"].Value = dateEnd;
			scom.Parameters["@isMonthClose"].Value = isMonthClose;
			scom.Parameters["@closedUser_ID"].Value = closedUser_ID;
			scom.Parameters["@dateClosed"].Value = dateClosed;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accFinancialYearMaster_Month table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMaster_MonthDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
 
			scom.Parameters["@month_ID"].Value = month_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accFinancialYearMaster_Month table by a foreign key.
		/// </summary>
		public static void DeleteAllByFinancialYear_ID(string financialYear_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMaster_MonthDeleteAllByFinancialYear_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accFinancialYearMaster_Month table.
		/// </summary>
		public static tbl_accFinancialYearMaster_Month Select(string financialYear_ID_Incoming, string month_ID_Incoming){

			tbl_accFinancialYearMaster_Month tbl_accFinancialYearMaster_Monthins = new tbl_accFinancialYearMaster_Month();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMaster_MonthSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@month_ID", SqlDbType.VarChar,100);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID_Incoming;
			scom.Parameters["@month_ID"].Value = month_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accFinancialYearMaster_Monthins = Maketbl_accFinancialYearMaster_Month(dataReader);
				} else {
					tbl_accFinancialYearMaster_Monthins = null;
				}
			}
			scon.Close();
			return tbl_accFinancialYearMaster_Monthins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accFinancialYearMaster_Month table.
		/// </summary>
		public static List<tbl_accFinancialYearMaster_Month> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMaster_MonthSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accFinancialYearMaster_Month> tbl_accFinancialYearMaster_MonthList = new List<tbl_accFinancialYearMaster_Month>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accFinancialYearMaster_Month tbl_accFinancialYearMaster_Month = Maketbl_accFinancialYearMaster_Month(dataReader);
					tbl_accFinancialYearMaster_MonthList.Add(tbl_accFinancialYearMaster_Month);
				}
			}
			scon.Close();
			return tbl_accFinancialYearMaster_MonthList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accFinancialYearMaster_Month table by a foreign key.
		/// </summary>
		public static List<tbl_accFinancialYearMaster_Month> SelectAllByFinancialYear_ID(string financialYear_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMaster_MonthSelectAllByFinancialYear_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
				List<tbl_accFinancialYearMaster_Month> tbl_accFinancialYearMaster_MonthList = new List<tbl_accFinancialYearMaster_Month>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accFinancialYearMaster_Month tbl_accFinancialYearMaster_Month = Maketbl_accFinancialYearMaster_Month(dataReader);
					tbl_accFinancialYearMaster_MonthList.Add(tbl_accFinancialYearMaster_Month);
				}
			}
			scon.Close();
			return tbl_accFinancialYearMaster_MonthList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accFinancialYearMaster_Month class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accFinancialYearMaster_Month Maketbl_accFinancialYearMaster_Month(SqlDataReader dataReader) {
			tbl_accFinancialYearMaster_Month tbl_accFinancialYearMaster_Month = new tbl_accFinancialYearMaster_Month();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accFinancialYearMaster_Month.FinancialYear_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accFinancialYearMaster_Month.Month_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accFinancialYearMaster_Month.DateStart = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accFinancialYearMaster_Month.DateEnd = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accFinancialYearMaster_Month.IsMonthClose = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accFinancialYearMaster_Month.ClosedUser_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accFinancialYearMaster_Month.DateClosed = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accFinancialYearMaster_Month.CreateUser_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accFinancialYearMaster_Month.ModifiedUser_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accFinancialYearMaster_Month.CreateTerminal_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_accFinancialYearMaster_Month.ModifiedTerminal_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_accFinancialYearMaster_Month.DateCreate = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_accFinancialYearMaster_Month.DateModified = dataReader.GetDateTime(12);
			}

			return tbl_accFinancialYearMaster_Month;
		}
		/// <summary>
		/// This makes tbl_accFinancialYearMaster_Month datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accFinancialYearMaster_Month object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accFinancialYearMaster_Month  tbl_accFinancialYearMaster_Month   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_month_ID = new DataColumn("month_ID" , typeof(string));
			DataColumn col_dateStart = new DataColumn("dateStart" , typeof(DateTime));
			DataColumn col_dateEnd = new DataColumn("dateEnd" , typeof(DateTime));
			DataColumn col_isMonthClose = new DataColumn("isMonthClose" , typeof(bool));
			DataColumn col_closedUser_ID = new DataColumn("closedUser_ID" , typeof(string));
			DataColumn col_dateClosed = new DataColumn("dateClosed" , typeof(DateTime));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_financialYear_ID,col_month_ID,col_dateStart,col_dateEnd,col_isMonthClose,col_closedUser_ID,col_dateClosed,col_createUser_ID,col_modifiedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_dateCreate,col_dateModified,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accFinancialYearMaster_Month datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accFinancialYearMaster_Month object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accFinancialYearMaster_Month user) {
		DataRow drow = dt.NewRow();
		
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["month_ID"] = user.month_ID;
			drow["dateStart"] = user.dateStart;
			drow["dateEnd"] = user.dateEnd;
			drow["isMonthClose"] = user.isMonthClose;
			drow["closedUser_ID"] = user.closedUser_ID;
			drow["dateClosed"] = user.dateClosed;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
