using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_hrMasRecuirtmentType {
		#region Fields
		private string recuirtmentType_ID;
		private string recuirtmentType;
		private bool isCanceled;
		private string userID_Created;
		private string createTerminal_ID;
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
		/// Initializes a new instance of the tbl_hrMasRecuirtmentType class.
		/// </summary>
		public tbl_hrMasRecuirtmentType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_hrMasRecuirtmentType class.
		/// </summary>
		public tbl_hrMasRecuirtmentType(string recuirtmentType_ID, string recuirtmentType, bool isCanceled, string userID_Created, string createTerminal_ID, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.recuirtmentType_ID = recuirtmentType_ID;
			this.recuirtmentType = recuirtmentType;
			this.isCanceled = isCanceled;
			this.userID_Created = userID_Created;
			this.createTerminal_ID = createTerminal_ID;
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
		/// Gets or sets the RecuirtmentType_ID value.
		/// </summary>
		public string RecuirtmentType_ID {
			get { return recuirtmentType_ID; }
			set { recuirtmentType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the RecuirtmentType value.
		/// </summary>
		public string RecuirtmentType {
			get { return recuirtmentType; }
			set { recuirtmentType = value; }
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
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
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
		/// Saves a record to the tbl_hrMasRecuirtmentType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrMasRecuirtmentTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@recuirtmentType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@recuirtmentType", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
			scom.Parameters["@recuirtmentType_ID"].Value = recuirtmentType_ID;
			scom.Parameters["@recuirtmentType"].Value = recuirtmentType;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
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
		/// Updates a record in the tbl_hrMasRecuirtmentType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrMasRecuirtmentTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@recuirtmentType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@recuirtmentType", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@recuirtmentType_ID"].Value = recuirtmentType_ID;
			scom.Parameters["@recuirtmentType"].Value = recuirtmentType;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
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
		/// Deletes a record from the tbl_hrMasRecuirtmentType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrMasRecuirtmentTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@recuirtmentType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@recuirtmentType_ID"].Value = recuirtmentType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_hrMasRecuirtmentType table.
		/// </summary>
		public static tbl_hrMasRecuirtmentType Select(string recuirtmentType_ID_Incoming){

			tbl_hrMasRecuirtmentType tbl_hrMasRecuirtmentTypeins = new tbl_hrMasRecuirtmentType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrMasRecuirtmentTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@recuirtmentType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@recuirtmentType_ID"].Value = recuirtmentType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_hrMasRecuirtmentTypeins = Maketbl_hrMasRecuirtmentType(dataReader);
				} else {
					tbl_hrMasRecuirtmentTypeins = null;
				}
			}
			scon.Close();
			return tbl_hrMasRecuirtmentTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_hrMasRecuirtmentType table.
		/// </summary>
		public static List<tbl_hrMasRecuirtmentType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrMasRecuirtmentTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_hrMasRecuirtmentType> tbl_hrMasRecuirtmentTypeList = new List<tbl_hrMasRecuirtmentType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_hrMasRecuirtmentType tbl_hrMasRecuirtmentType = Maketbl_hrMasRecuirtmentType(dataReader);
					tbl_hrMasRecuirtmentTypeList.Add(tbl_hrMasRecuirtmentType);
				}
			}
			scon.Close();
			return tbl_hrMasRecuirtmentTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_hrMasRecuirtmentType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_hrMasRecuirtmentType Maketbl_hrMasRecuirtmentType(SqlDataReader dataReader) {
			tbl_hrMasRecuirtmentType tbl_hrMasRecuirtmentType = new tbl_hrMasRecuirtmentType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_hrMasRecuirtmentType.RecuirtmentType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_hrMasRecuirtmentType.RecuirtmentType = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_hrMasRecuirtmentType.IsCanceled = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_hrMasRecuirtmentType.UserID_Created = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_hrMasRecuirtmentType.CreateTerminal_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_hrMasRecuirtmentType.UserID_Modified = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_hrMasRecuirtmentType.UserID_Canceled = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_hrMasRecuirtmentType.TerminalID_Created = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_hrMasRecuirtmentType.TerminalID_Modified = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_hrMasRecuirtmentType.TerminalID_Canceled = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_hrMasRecuirtmentType.Date_Created = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_hrMasRecuirtmentType.Date_Modified = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_hrMasRecuirtmentType.Date_Canceled = dataReader.GetDateTime(12);
			}

			return tbl_hrMasRecuirtmentType;
		}
		/// <summary>
		/// This makes tbl_hrMasRecuirtmentType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_hrMasRecuirtmentType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_hrMasRecuirtmentType  tbl_hrMasRecuirtmentType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_recuirtmentType_ID = new DataColumn("recuirtmentType_ID" , typeof(string));
			DataColumn col_recuirtmentType = new DataColumn("recuirtmentType" , typeof(string));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Modified = new DataColumn("terminalID_Modified" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Modified = new DataColumn("date_Modified" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_recuirtmentType_ID,col_recuirtmentType,col_isCanceled,col_userID_Created,col_createTerminal_ID,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_hrMasRecuirtmentType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_hrMasRecuirtmentType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_hrMasRecuirtmentType user) {
		DataRow drow = dt.NewRow();
		
			drow["recuirtmentType_ID"] = user.recuirtmentType_ID;
			drow["recuirtmentType"] = user.recuirtmentType;
			drow["isCanceled"] = user.isCanceled;
			drow["userID_Created"] = user.userID_Created;
			drow["createTerminal_ID"] = user.createTerminal_ID;
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
