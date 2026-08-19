using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_payTxSIPRawData_Attendance {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private int sIP_ID;
		private string dayType;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_payTxSIPRawData_Attendance class.
		/// </summary>
		public tbl_payTxSIPRawData_Attendance() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_payTxSIPRawData_Attendance class.
		/// </summary>
		public tbl_payTxSIPRawData_Attendance(string company_ID, string companyBranch_ID, int sIP_ID, string dayType) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.sIP_ID = sIP_ID;
			this.dayType = dayType;
		}
		#endregion
		
		#region Properties
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
		/// Gets or sets the SIP_ID value.
		/// </summary>
		public int SIP_ID {
			get { return sIP_ID; }
			set { sIP_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DayType value.
		/// </summary>
		public string DayType {
			get { return dayType; }
			set { dayType = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_payTxSIPRawData_Attendance table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawData_AttendanceInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@SIP_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@dayType", SqlDbType.NChar,10);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@SIP_ID"].Value = sIP_ID;
			scom.Parameters["@dayType"].Value = dayType;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_payTxSIPRawData_Attendance table.
		/// </summary>
		public static List<tbl_payTxSIPRawData_Attendance> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payTxSIPRawData_AttendanceSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_payTxSIPRawData_Attendance> tbl_payTxSIPRawData_AttendanceList = new List<tbl_payTxSIPRawData_Attendance>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payTxSIPRawData_Attendance tbl_payTxSIPRawData_Attendance = Maketbl_payTxSIPRawData_Attendance(dataReader);
					tbl_payTxSIPRawData_AttendanceList.Add(tbl_payTxSIPRawData_Attendance);
				}
			}
			scon.Close();
			return tbl_payTxSIPRawData_AttendanceList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_payTxSIPRawData_Attendance class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_payTxSIPRawData_Attendance Maketbl_payTxSIPRawData_Attendance(SqlDataReader dataReader) {
			tbl_payTxSIPRawData_Attendance tbl_payTxSIPRawData_Attendance = new tbl_payTxSIPRawData_Attendance();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_payTxSIPRawData_Attendance.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_payTxSIPRawData_Attendance.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_payTxSIPRawData_Attendance.SIP_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_payTxSIPRawData_Attendance.DayType = dataReader.GetString(3);
			}

			return tbl_payTxSIPRawData_Attendance;
		}
		/// <summary>
		/// This makes tbl_payTxSIPRawData_Attendance datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_payTxSIPRawData_Attendance object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_payTxSIPRawData_Attendance  tbl_payTxSIPRawData_Attendance   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_SIP_ID = new DataColumn("SIP_ID" , typeof(int));
			DataColumn col_dayType = new DataColumn("dayType" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_SIP_ID,col_dayType,});		return dt;
		}
		/// <summary>
		/// This fills tbl_payTxSIPRawData_Attendance datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_payTxSIPRawData_Attendance object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_payTxSIPRawData_Attendance user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["SIP_ID"] = user.SIP_ID;
			drow["dayType"] = user.dayType;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
