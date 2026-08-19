using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genMasEmpAttendanceProcessPeriod {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string attenProcessGroup_ID;
		private int attenProcessPeriod_ID;
		private string attenProcessPeriod_Title;
		private DateTime startDate;
		private DateTime endDate;
		private bool isComplepted;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genMasEmpAttendanceProcessPeriod class.
		/// </summary>
		public tbl_genMasEmpAttendanceProcessPeriod() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genMasEmpAttendanceProcessPeriod class.
		/// </summary>
		public tbl_genMasEmpAttendanceProcessPeriod(string company_ID, string companyBranch_ID, string attenProcessGroup_ID, int attenProcessPeriod_ID, string attenProcessPeriod_Title, DateTime startDate, DateTime endDate, bool isComplepted) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.attenProcessGroup_ID = attenProcessGroup_ID;
			this.attenProcessPeriod_ID = attenProcessPeriod_ID;
			this.attenProcessPeriod_Title = attenProcessPeriod_Title;
			this.startDate = startDate;
			this.endDate = endDate;
			this.isComplepted = isComplepted;
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
		/// Gets or sets the AttenProcessGroup_ID value.
		/// </summary>
		public string AttenProcessGroup_ID {
			get { return attenProcessGroup_ID; }
			set { attenProcessGroup_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AttenProcessPeriod_ID value.
		/// </summary>
		public int AttenProcessPeriod_ID {
			get { return attenProcessPeriod_ID; }
			set { attenProcessPeriod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AttenProcessPeriod_Title value.
		/// </summary>
		public string AttenProcessPeriod_Title {
			get { return attenProcessPeriod_Title; }
			set { attenProcessPeriod_Title = value; }
		}
		
		/// <summary>
		/// Gets or sets the StartDate value.
		/// </summary>
		public DateTime StartDate {
			get { return startDate; }
			set { startDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the EndDate value.
		/// </summary>
		public DateTime EndDate {
			get { return endDate; }
			set { endDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsComplepted value.
		/// </summary>
		public bool IsComplepted {
			get { return isComplepted; }
			set { isComplepted = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genMasEmpAttendanceProcessPeriod table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmpAttendanceProcessPeriodInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attenProcessGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@attenProcessPeriod_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@attenProcessPeriod_Title", SqlDbType.VarChar,50);
			scom.Parameters.Add("@startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isComplepted", SqlDbType.Bit,1);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@attenProcessGroup_ID"].Value = attenProcessGroup_ID;
			scom.Parameters["@attenProcessPeriod_ID"].Value = attenProcessPeriod_ID;
			scom.Parameters["@attenProcessPeriod_Title"].Value = attenProcessPeriod_Title;
			scom.Parameters["@startDate"].Value = startDate;
			scom.Parameters["@endDate"].Value = endDate;
			scom.Parameters["@isComplepted"].Value = isComplepted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genMasEmpAttendanceProcessPeriod table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmpAttendanceProcessPeriodUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attenProcessGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@attenProcessPeriod_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@attenProcessPeriod_Title", SqlDbType.VarChar,50);
			scom.Parameters.Add("@startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isComplepted", SqlDbType.Bit,1);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@attenProcessGroup_ID"].Value = attenProcessGroup_ID;
			scom.Parameters["@attenProcessPeriod_ID"].Value = attenProcessPeriod_ID;
			scom.Parameters["@attenProcessPeriod_Title"].Value = attenProcessPeriod_Title;
			scom.Parameters["@startDate"].Value = startDate;
			scom.Parameters["@endDate"].Value = endDate;
			scom.Parameters["@isComplepted"].Value = isComplepted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genMasEmpAttendanceProcessPeriod table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmpAttendanceProcessPeriodDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attenProcessGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@attenProcessPeriod_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@attenProcessGroup_ID"].Value = attenProcessGroup_ID;
 
			scom.Parameters["@attenProcessPeriod_ID"].Value = attenProcessPeriod_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmpAttendanceProcessPeriod table by a foreign key.
		/// </summary>
		public static void DeleteAllByAttenProcessGroup_ID(string attenProcessGroup_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmpAttendanceProcessPeriodDeleteAllByAttenProcessGroup_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@attenProcessGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters["@attenProcessGroup_ID"].Value = attenProcessGroup_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genMasEmpAttendanceProcessPeriod table.
		/// </summary>
		public static tbl_genMasEmpAttendanceProcessPeriod Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string attenProcessGroup_ID_Incoming, int attenProcessPeriod_ID_Incoming){

			tbl_genMasEmpAttendanceProcessPeriod tbl_genMasEmpAttendanceProcessPeriodins = new tbl_genMasEmpAttendanceProcessPeriod();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmpAttendanceProcessPeriodSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@attenProcessGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@attenProcessPeriod_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@attenProcessGroup_ID"].Value = attenProcessGroup_ID_Incoming;
			scom.Parameters["@attenProcessPeriod_ID"].Value = attenProcessPeriod_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genMasEmpAttendanceProcessPeriodins = Maketbl_genMasEmpAttendanceProcessPeriod(dataReader);
				} else {
					tbl_genMasEmpAttendanceProcessPeriodins = null;
				}
			}
			scon.Close();
			return tbl_genMasEmpAttendanceProcessPeriodins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmpAttendanceProcessPeriod table.
		/// </summary>
		public static List<tbl_genMasEmpAttendanceProcessPeriod> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmpAttendanceProcessPeriodSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genMasEmpAttendanceProcessPeriod> tbl_genMasEmpAttendanceProcessPeriodList = new List<tbl_genMasEmpAttendanceProcessPeriod>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmpAttendanceProcessPeriod tbl_genMasEmpAttendanceProcessPeriod = Maketbl_genMasEmpAttendanceProcessPeriod(dataReader);
					tbl_genMasEmpAttendanceProcessPeriodList.Add(tbl_genMasEmpAttendanceProcessPeriod);
				}
			}
			scon.Close();
			return tbl_genMasEmpAttendanceProcessPeriodList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMasEmpAttendanceProcessPeriod table by a foreign key.
		/// </summary>
		public static List<tbl_genMasEmpAttendanceProcessPeriod> SelectAllByAttenProcessGroup_ID(string attenProcessGroup_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMasEmpAttendanceProcessPeriodSelectAllByAttenProcessGroup_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@attenProcessGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters["@attenProcessGroup_ID"].Value = attenProcessGroup_ID;
				List<tbl_genMasEmpAttendanceProcessPeriod> tbl_genMasEmpAttendanceProcessPeriodList = new List<tbl_genMasEmpAttendanceProcessPeriod>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMasEmpAttendanceProcessPeriod tbl_genMasEmpAttendanceProcessPeriod = Maketbl_genMasEmpAttendanceProcessPeriod(dataReader);
					tbl_genMasEmpAttendanceProcessPeriodList.Add(tbl_genMasEmpAttendanceProcessPeriod);
				}
			}
			scon.Close();
			return tbl_genMasEmpAttendanceProcessPeriodList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genMasEmpAttendanceProcessPeriod class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genMasEmpAttendanceProcessPeriod Maketbl_genMasEmpAttendanceProcessPeriod(SqlDataReader dataReader) {
			tbl_genMasEmpAttendanceProcessPeriod tbl_genMasEmpAttendanceProcessPeriod = new tbl_genMasEmpAttendanceProcessPeriod();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genMasEmpAttendanceProcessPeriod.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genMasEmpAttendanceProcessPeriod.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genMasEmpAttendanceProcessPeriod.AttenProcessGroup_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genMasEmpAttendanceProcessPeriod.AttenProcessPeriod_ID = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genMasEmpAttendanceProcessPeriod.AttenProcessPeriod_Title = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genMasEmpAttendanceProcessPeriod.StartDate = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genMasEmpAttendanceProcessPeriod.EndDate = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genMasEmpAttendanceProcessPeriod.IsComplepted = dataReader.GetBoolean(7);
			}

			return tbl_genMasEmpAttendanceProcessPeriod;
		}
		/// <summary>
		/// This makes tbl_genMasEmpAttendanceProcessPeriod datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genMasEmpAttendanceProcessPeriod object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genMasEmpAttendanceProcessPeriod  tbl_genMasEmpAttendanceProcessPeriod   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_attenProcessGroup_ID = new DataColumn("attenProcessGroup_ID" , typeof(string));
			DataColumn col_attenProcessPeriod_ID = new DataColumn("attenProcessPeriod_ID" , typeof(int));
			DataColumn col_attenProcessPeriod_Title = new DataColumn("attenProcessPeriod_Title" , typeof(string));
			DataColumn col_startDate = new DataColumn("startDate" , typeof(DateTime));
			DataColumn col_endDate = new DataColumn("endDate" , typeof(DateTime));
			DataColumn col_isComplepted = new DataColumn("isComplepted" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_attenProcessGroup_ID,col_attenProcessPeriod_ID,col_attenProcessPeriod_Title,col_startDate,col_endDate,col_isComplepted,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genMasEmpAttendanceProcessPeriod datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genMasEmpAttendanceProcessPeriod object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genMasEmpAttendanceProcessPeriod user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["attenProcessGroup_ID"] = user.attenProcessGroup_ID;
			drow["attenProcessPeriod_ID"] = user.attenProcessPeriod_ID;
			drow["attenProcessPeriod_Title"] = user.attenProcessPeriod_Title;
			drow["startDate"] = user.startDate;
			drow["endDate"] = user.endDate;
			drow["isComplepted"] = user.isComplepted;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
