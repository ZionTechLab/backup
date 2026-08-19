using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genMasEmpAttendanceProcessGroup2 {
		#region Fields
		private string attendanceGroup2_ID;
		private string attendanceGroup2_Name;
		private string remarks;
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
		/// Initializes a new instance of the tbl_genMasEmpAttendanceProcessGroup2 class.
		/// </summary>
		public tbl_genMasEmpAttendanceProcessGroup2() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genMasEmpAttendanceProcessGroup2 class.
		/// </summary>
		public tbl_genMasEmpAttendanceProcessGroup2(string attendanceGroup2_ID, string attendanceGroup2_Name, string remarks, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.attendanceGroup2_ID = attendanceGroup2_ID;
			this.attendanceGroup2_Name = attendanceGroup2_Name;
			this.remarks = remarks;
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
		/// Gets or sets the AttendanceGroup2_ID value.
		/// </summary>
		public string AttendanceGroup2_ID {
			get { return attendanceGroup2_ID; }
			set { attendanceGroup2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AttendanceGroup2_Name value.
		/// </summary>
		public string AttendanceGroup2_Name {
			get { return attendanceGroup2_Name; }
			set { attendanceGroup2_Name = value; }
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
		/// Saves a record to the tbl_genMasEmpAttendanceProcessGroup2 table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmpAttendanceProcessGroup2Insert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@attendanceGroup2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@attendanceGroup2_Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
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
 
			scom.Parameters["@attendanceGroup2_ID"].Value = attendanceGroup2_ID;
			scom.Parameters["@attendanceGroup2_Name"].Value = attendanceGroup2_Name;
			scom.Parameters["@remarks"].Value = remarks;
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
		/// Updates a record in the tbl_genMasEmpAttendanceProcessGroup2 table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmpAttendanceProcessGroup2Update", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@attendanceGroup2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@attendanceGroup2_Name", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
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
 
 
			scom.Parameters["@attendanceGroup2_ID"].Value = attendanceGroup2_ID;
			scom.Parameters["@attendanceGroup2_Name"].Value = attendanceGroup2_Name;
			scom.Parameters["@remarks"].Value = remarks;
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
		/// Deletes a record from the tbl_genMasEmpAttendanceProcessGroup2 table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmpAttendanceProcessGroup2Delete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@attendanceGroup2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@attendanceGroup2_ID"].Value = attendanceGroup2_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genMasEmpAttendanceProcessGroup2 table.
		/// </summary>
		public static tbl_genMasEmpAttendanceProcessGroup2 Select(string attendanceGroup2_ID_Incoming){

			tbl_genMasEmpAttendanceProcessGroup2 tbl_genMasEmpAttendanceProcessGroup2ins = new tbl_genMasEmpAttendanceProcessGroup2();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmpAttendanceProcessGroup2Select", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@attendanceGroup2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@attendanceGroup2_ID"].Value = attendanceGroup2_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genMasEmpAttendanceProcessGroup2ins = Maketbl_genMasEmpAttendanceProcessGroup2(dataReader);
				} else {
					tbl_genMasEmpAttendanceProcessGroup2ins = null;
				}
			}
			scon.Close();
			return tbl_genMasEmpAttendanceProcessGroup2ins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmpAttendanceProcessGroup2 table.
		/// </summary>
		public static List<tbl_genMasEmpAttendanceProcessGroup2> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmpAttendanceProcessGroup2SelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genMasEmpAttendanceProcessGroup2> tbl_genMasEmpAttendanceProcessGroup2List = new List<tbl_genMasEmpAttendanceProcessGroup2>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmpAttendanceProcessGroup2 tbl_genMasEmpAttendanceProcessGroup2 = Maketbl_genMasEmpAttendanceProcessGroup2(dataReader);
					tbl_genMasEmpAttendanceProcessGroup2List.Add(tbl_genMasEmpAttendanceProcessGroup2);
				}
			}
			scon.Close();
			return tbl_genMasEmpAttendanceProcessGroup2List;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genMasEmpAttendanceProcessGroup2 class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genMasEmpAttendanceProcessGroup2 Maketbl_genMasEmpAttendanceProcessGroup2(SqlDataReader dataReader) {
			tbl_genMasEmpAttendanceProcessGroup2 tbl_genMasEmpAttendanceProcessGroup2 = new tbl_genMasEmpAttendanceProcessGroup2();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genMasEmpAttendanceProcessGroup2.AttendanceGroup2_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genMasEmpAttendanceProcessGroup2.AttendanceGroup2_Name = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genMasEmpAttendanceProcessGroup2.Remarks = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genMasEmpAttendanceProcessGroup2.IsCanceled = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genMasEmpAttendanceProcessGroup2.UserID_Created = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genMasEmpAttendanceProcessGroup2.UserID_Modified = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genMasEmpAttendanceProcessGroup2.UserID_Canceled = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genMasEmpAttendanceProcessGroup2.TerminalID_Created = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genMasEmpAttendanceProcessGroup2.TerminalID_Modified = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genMasEmpAttendanceProcessGroup2.TerminalID_Canceled = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genMasEmpAttendanceProcessGroup2.Date_Created = dataReader.GetDateTime(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genMasEmpAttendanceProcessGroup2.Date_Modified = dataReader.GetDateTime(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genMasEmpAttendanceProcessGroup2.Date_Canceled = dataReader.GetDateTime(12);
			}

			return tbl_genMasEmpAttendanceProcessGroup2;
		}
		/// <summary>
		/// This makes tbl_genMasEmpAttendanceProcessGroup2 datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genMasEmpAttendanceProcessGroup2 object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genMasEmpAttendanceProcessGroup2  tbl_genMasEmpAttendanceProcessGroup2   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_attendanceGroup2_ID = new DataColumn("attendanceGroup2_ID" , typeof(string));
			DataColumn col_attendanceGroup2_Name = new DataColumn("attendanceGroup2_Name" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
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
		dt.Columns.AddRange(new DataColumn[] { col_attendanceGroup2_ID,col_attendanceGroup2_Name,col_remarks,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genMasEmpAttendanceProcessGroup2 datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genMasEmpAttendanceProcessGroup2 object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genMasEmpAttendanceProcessGroup2 user) {
		DataRow drow = dt.NewRow();
		
			drow["attendanceGroup2_ID"] = user.attendanceGroup2_ID;
			drow["attendanceGroup2_Name"] = user.attendanceGroup2_Name;
			drow["remarks"] = user.remarks;
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
