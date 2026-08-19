using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_tasEmployeeLeaveCard_Detail {
		#region Fields
		private int day;
		private string company_ID;
		private string companyBranch_ID;
		private string leave_ID;
		private DateTime start_DateTime;
		private DateTime end_DateTime;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_tasEmployeeLeaveCard_Detail class.
		/// </summary>
		public tbl_tasEmployeeLeaveCard_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasEmployeeLeaveCard_Detail class.
		/// </summary>
		public tbl_tasEmployeeLeaveCard_Detail(int day, string company_ID, string companyBranch_ID, string leave_ID, DateTime start_DateTime, DateTime end_DateTime) {
			this.day = day;
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.leave_ID = leave_ID;
			this.start_DateTime = start_DateTime;
			this.end_DateTime = end_DateTime;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Day value.
		/// </summary>
		public int Day {
			get { return day; }
			set { day = value; }
		}
		
		/// <summary>
		/// Gets or sets the Company_ID value.
		/// </summary>
		public string Company_ID {
			get { return company_ID; }
			set { company_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Leave_ID value.
		/// </summary>
		public string Leave_ID {
			get { return leave_ID; }
			set { leave_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Start_DateTime value.
		/// </summary>
		public DateTime Start_DateTime {
			get { return start_DateTime; }
			set { start_DateTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the End_DateTime value.
		/// </summary>
		public DateTime End_DateTime {
			get { return end_DateTime; }
			set { end_DateTime = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_tasEmployeeLeaveCard_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCard_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@day", SqlDbType.Int,4);
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leave_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@start_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@end_DateTime", SqlDbType.DateTime,8);
 
			scom.Parameters["@day"].Value = day;
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@leave_ID"].Value = leave_ID;
			scom.Parameters["@start_DateTime"].Value = start_DateTime;
			scom.Parameters["@end_DateTime"].Value = end_DateTime;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_tasEmployeeLeaveCard_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCard_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@day", SqlDbType.Int,4);
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leave_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@start_DateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@end_DateTime", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@day"].Value = day;
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@leave_ID"].Value = leave_ID;
			scom.Parameters["@start_DateTime"].Value = start_DateTime;
			scom.Parameters["@end_DateTime"].Value = end_DateTime;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_tasEmployeeLeaveCard_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCard_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@day", SqlDbType.Int,4);
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leave_ID", SqlDbType.VarChar,10);
			scom.Parameters["@day"].Value = day;
 
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@leave_ID"].Value = leave_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeaveCard_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Leave_ID(string company_ID, string companyBranch_ID, string leave_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCard_DetailDeleteAllByCompany_ID_CompanyBranch_ID_Leave_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leave_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@leave_ID"].Value = leave_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_tasEmployeeLeaveCard_Detail table.
		/// </summary>
		public static tbl_tasEmployeeLeaveCard_Detail Select(int day_Incoming, string company_ID_Incoming, string companyBranch_ID_Incoming, string leave_ID_Incoming){

			tbl_tasEmployeeLeaveCard_Detail tbl_tasEmployeeLeaveCard_Detailins = new tbl_tasEmployeeLeaveCard_Detail();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCard_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@day", SqlDbType.Int,4);
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leave_ID", SqlDbType.VarChar,10);
			scom.Parameters["@day"].Value = day_Incoming;
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@leave_ID"].Value = leave_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_tasEmployeeLeaveCard_Detailins = Maketbl_tasEmployeeLeaveCard_Detail(dataReader);
				} else {
					tbl_tasEmployeeLeaveCard_Detailins = null;
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeaveCard_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeaveCard_Detail table.
		/// </summary>
		public static List<tbl_tasEmployeeLeaveCard_Detail> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCard_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_tasEmployeeLeaveCard_Detail> tbl_tasEmployeeLeaveCard_DetailList = new List<tbl_tasEmployeeLeaveCard_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasEmployeeLeaveCard_Detail tbl_tasEmployeeLeaveCard_Detail = Maketbl_tasEmployeeLeaveCard_Detail(dataReader);
					tbl_tasEmployeeLeaveCard_DetailList.Add(tbl_tasEmployeeLeaveCard_Detail);
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeaveCard_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeaveCard_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_tasEmployeeLeaveCard_Detail> SelectAllByCompany_ID_CompanyBranch_ID_Leave_ID(string company_ID, string companyBranch_ID, string leave_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCard_DetailSelectAllByCompany_ID_CompanyBranch_ID_Leave_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leave_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@leave_ID"].Value = leave_ID;
				List<tbl_tasEmployeeLeaveCard_Detail> tbl_tasEmployeeLeaveCard_DetailList = new List<tbl_tasEmployeeLeaveCard_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasEmployeeLeaveCard_Detail tbl_tasEmployeeLeaveCard_Detail = Maketbl_tasEmployeeLeaveCard_Detail(dataReader);
					tbl_tasEmployeeLeaveCard_DetailList.Add(tbl_tasEmployeeLeaveCard_Detail);
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeaveCard_DetailList;
		}


        public static List<tbl_tasEmployeeLeaveCard_Detail> SelectAllByCompany_ID_CompanyBranch_ID_Employee_ID(string company_ID, string companyBranch_ID, string employee_ID , string nopayLeaveType_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCard_DetailSelectAllByEmployee_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@company_ID", SqlDbType.VarChar, 8);
            scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar, 8);
            scom.Parameters.Add("@employee_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@nopayLeaveTypeID", SqlDbType.VarChar, 8);

            scom.Parameters["@company_ID"].Value = company_ID;
            scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
            scom.Parameters["@employee_ID"].Value = employee_ID;
            scom.Parameters["@nopayLeaveTypeID"].Value = nopayLeaveType_ID;

            List<tbl_tasEmployeeLeaveCard_Detail> tbl_tasEmployeeLeaveCard_DetailList = new List<tbl_tasEmployeeLeaveCard_Detail>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_tasEmployeeLeaveCard_Detail tbl_tasEmployeeLeaveCard_Detail = Maketbl_tasEmployeeLeaveCard_Detail(dataReader);
                    tbl_tasEmployeeLeaveCard_DetailList.Add(tbl_tasEmployeeLeaveCard_Detail);
                }
            }
            scon.Close();
            return tbl_tasEmployeeLeaveCard_DetailList;
        }


        /// <summary>
        /// Creates a new instance of the tbl_tasEmployeeLeaveCard_Detail class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static tbl_tasEmployeeLeaveCard_Detail Maketbl_tasEmployeeLeaveCard_Detail(SqlDataReader dataReader) {
			tbl_tasEmployeeLeaveCard_Detail tbl_tasEmployeeLeaveCard_Detail = new tbl_tasEmployeeLeaveCard_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_tasEmployeeLeaveCard_Detail.Day = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasEmployeeLeaveCard_Detail.Company_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasEmployeeLeaveCard_Detail.CompanyBranch_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_tasEmployeeLeaveCard_Detail.Leave_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_tasEmployeeLeaveCard_Detail.Start_DateTime = dataReader.GetDateTime(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_tasEmployeeLeaveCard_Detail.End_DateTime = dataReader.GetDateTime(5);
			}

			return tbl_tasEmployeeLeaveCard_Detail;
		}
		/// <summary>
		/// This makes tbl_tasEmployeeLeaveCard_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasEmployeeLeaveCard_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasEmployeeLeaveCard_Detail  tbl_tasEmployeeLeaveCard_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_day = new DataColumn("day" , typeof(int));
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_leave_ID = new DataColumn("leave_ID" , typeof(string));
			DataColumn col_start_DateTime = new DataColumn("start_DateTime" , typeof(DateTime));
			DataColumn col_end_DateTime = new DataColumn("end_DateTime" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_day,col_company_ID,col_companyBranch_ID,col_leave_ID,col_start_DateTime,col_end_DateTime,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasEmployeeLeaveCard_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasEmployeeLeaveCard_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasEmployeeLeaveCard_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["day"] = user.day;
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["leave_ID"] = user.leave_ID;
			drow["start_DateTime"] = user.start_DateTime;
			drow["end_DateTime"] = user.end_DateTime;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
