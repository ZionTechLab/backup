using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accFinancialYearMaster {
		#region Fields
		private string financialYear_ID;
		private string financialYearName;
		private DateTime dateStart;
		private DateTime dateEnd;
		private int statusID;
		private string closedUser_ID;
		private DateTime dateClosed;
		private string createUser_ID;
		private string createTerminal_ID;
		private string modifiedUser_ID;
		private string modifiedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accFinancialYearMaster class.
		/// </summary>
		public tbl_accFinancialYearMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accFinancialYearMaster class.
		/// </summary>
		public tbl_accFinancialYearMaster(string financialYear_ID, string financialYearName, DateTime dateStart, DateTime dateEnd, int statusID, string closedUser_ID, DateTime dateClosed, string createUser_ID, string createTerminal_ID, string modifiedUser_ID, string modifiedTerminal_ID, DateTime dateCreate, DateTime dateModified) {
			this.financialYear_ID = financialYear_ID;
			this.financialYearName = financialYearName;
			this.dateStart = dateStart;
			this.dateEnd = dateEnd;
			this.statusID = statusID;
			this.closedUser_ID = closedUser_ID;
			this.dateClosed = dateClosed;
			this.createUser_ID = createUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedUser_ID = modifiedUser_ID;
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
		/// Gets or sets the FinancialYearName value.
		/// </summary>
		public string FinancialYearName {
			get { return financialYearName; }
			set { financialYearName = value; }
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
		/// Gets or sets the StatusID value.
		/// </summary>
		public int StatusID {
			get { return statusID; }
			set { statusID = value; }
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
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUser_ID value.
		/// </summary>
		public string ModifiedUser_ID {
			get { return modifiedUser_ID; }
			set { modifiedUser_ID = value; }
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
		/// Saves a record to the tbl_accFinancialYearMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYearName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateStart", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateEnd", SqlDbType.DateTime,8);
			scom.Parameters.Add("@statusID", SqlDbType.Int,4);
			scom.Parameters.Add("@closedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateClosed", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
 
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@financialYearName"].Value = financialYearName;
			scom.Parameters["@dateStart"].Value = dateStart;
			scom.Parameters["@dateEnd"].Value = dateEnd;
			scom.Parameters["@statusID"].Value = statusID;
			scom.Parameters["@closedUser_ID"].Value = closedUser_ID;
			scom.Parameters["@dateClosed"].Value = dateClosed;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accFinancialYearMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@financialYearName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateStart", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateEnd", SqlDbType.DateTime,8);
			scom.Parameters.Add("@statusID", SqlDbType.Int,4);
			scom.Parameters.Add("@closedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@dateClosed", SqlDbType.DateTime,8);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
			scom.Parameters["@financialYearName"].Value = financialYearName;
			scom.Parameters["@dateStart"].Value = dateStart;
			scom.Parameters["@dateEnd"].Value = dateEnd;
			scom.Parameters["@statusID"].Value = statusID;
			scom.Parameters["@closedUser_ID"].Value = closedUser_ID;
			scom.Parameters["@dateClosed"].Value = dateClosed;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accFinancialYearMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accFinancialYearMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByStatusID(int statusID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMasterDeleteAllByStatusID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@statusID", SqlDbType.Int,4);
			scom.Parameters["@statusID"].Value = statusID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accFinancialYearMaster table.
		/// </summary>
		public static tbl_accFinancialYearMaster Select(string financialYear_ID_Incoming){

			tbl_accFinancialYearMaster tbl_accFinancialYearMasterins = new tbl_accFinancialYearMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@financialYear_ID", SqlDbType.VarChar,20);
			scom.Parameters["@financialYear_ID"].Value = financialYear_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accFinancialYearMasterins = Maketbl_accFinancialYearMaster(dataReader);
				} else {
					tbl_accFinancialYearMasterins = null;
				}
			}
			scon.Close();
			return tbl_accFinancialYearMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accFinancialYearMaster table.
		/// </summary>
		public static List<tbl_accFinancialYearMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accFinancialYearMaster> tbl_accFinancialYearMasterList = new List<tbl_accFinancialYearMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accFinancialYearMaster tbl_accFinancialYearMaster = Maketbl_accFinancialYearMaster(dataReader);
					tbl_accFinancialYearMasterList.Add(tbl_accFinancialYearMaster);
				}
			}
			scon.Close();
			return tbl_accFinancialYearMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accFinancialYearMaster table by a foreign key.
		/// </summary>
		public static List<tbl_accFinancialYearMaster> SelectAllByStatusID(int statusID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accFinancialYearMasterSelectAllByStatusID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@statusID", SqlDbType.Int,4);
			scom.Parameters["@statusID"].Value = statusID;
				List<tbl_accFinancialYearMaster> tbl_accFinancialYearMasterList = new List<tbl_accFinancialYearMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accFinancialYearMaster tbl_accFinancialYearMaster = Maketbl_accFinancialYearMaster(dataReader);
					tbl_accFinancialYearMasterList.Add(tbl_accFinancialYearMaster);
				}
			}
			scon.Close();
			return tbl_accFinancialYearMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accFinancialYearMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accFinancialYearMaster Maketbl_accFinancialYearMaster(SqlDataReader dataReader) {
			tbl_accFinancialYearMaster tbl_accFinancialYearMaster = new tbl_accFinancialYearMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accFinancialYearMaster.FinancialYear_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accFinancialYearMaster.FinancialYearName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accFinancialYearMaster.DateStart = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_accFinancialYearMaster.DateEnd = dataReader.GetDateTime(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_accFinancialYearMaster.StatusID = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_accFinancialYearMaster.ClosedUser_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_accFinancialYearMaster.DateClosed = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_accFinancialYearMaster.CreateUser_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_accFinancialYearMaster.CreateTerminal_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_accFinancialYearMaster.ModifiedUser_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_accFinancialYearMaster.ModifiedTerminal_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_accFinancialYearMaster.DateCreate = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_accFinancialYearMaster.DateModified = dataReader.GetDateTime(12);
			}

			return tbl_accFinancialYearMaster;
		}
		/// <summary>
		/// This makes tbl_accFinancialYearMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accFinancialYearMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accFinancialYearMaster  tbl_accFinancialYearMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_financialYear_ID = new DataColumn("financialYear_ID" , typeof(string));
			DataColumn col_financialYearName = new DataColumn("financialYearName" , typeof(string));
			DataColumn col_dateStart = new DataColumn("dateStart" , typeof(DateTime));
			DataColumn col_dateEnd = new DataColumn("dateEnd" , typeof(DateTime));
			DataColumn col_statusID = new DataColumn("statusID" , typeof(int));
			DataColumn col_closedUser_ID = new DataColumn("closedUser_ID" , typeof(string));
			DataColumn col_dateClosed = new DataColumn("dateClosed" , typeof(DateTime));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_financialYear_ID,col_financialYearName,col_dateStart,col_dateEnd,col_statusID,col_closedUser_ID,col_dateClosed,col_createUser_ID,col_createTerminal_ID,col_modifiedUser_ID,col_modifiedTerminal_ID,col_dateCreate,col_dateModified,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accFinancialYearMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accFinancialYearMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accFinancialYearMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["financialYear_ID"] = user.financialYear_ID;
			drow["financialYearName"] = user.financialYearName;
			drow["dateStart"] = user.dateStart;
			drow["dateEnd"] = user.dateEnd;
			drow["statusID"] = user.statusID;
			drow["closedUser_ID"] = user.closedUser_ID;
			drow["dateClosed"] = user.dateClosed;
			drow["createUser_ID"] = user.createUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
