using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_tasTxMonthlyAttendance_DayTypeBreakdown {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private int monthlyIndex_ID;
		private int index_ID;
		private int dayType_ID;
		private decimal workingMinutes_Mand;
		private decimal workingMinutes_Act;
		private decimal noPayMinutes;
		private decimal lateMinutes;
		private decimal workingMinutesAct_OT;
		private decimal workingMinutesAct_OT_Dub;
		private decimal workingMinutesAct_OT_Trpl;
		private decimal leaveMinutes;
		private decimal gatePassMinutes;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_tasTxMonthlyAttendance_DayTypeBreakdown class.
		/// </summary>
		public tbl_tasTxMonthlyAttendance_DayTypeBreakdown() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasTxMonthlyAttendance_DayTypeBreakdown class.
		/// </summary>
		public tbl_tasTxMonthlyAttendance_DayTypeBreakdown(string company_ID, string companyBranch_ID, int monthlyIndex_ID, int index_ID, int dayType_ID, decimal workingMinutes_Mand, decimal workingMinutes_Act, decimal noPayMinutes, decimal lateMinutes, decimal workingMinutesAct_OT, decimal workingMinutesAct_OT_Dub, decimal workingMinutesAct_OT_Trpl, decimal leaveMinutes, decimal gatePassMinutes) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.monthlyIndex_ID = monthlyIndex_ID;
			this.index_ID = index_ID;
			this.dayType_ID = dayType_ID;
			this.workingMinutes_Mand = workingMinutes_Mand;
			this.workingMinutes_Act = workingMinutes_Act;
			this.noPayMinutes = noPayMinutes;
			this.lateMinutes = lateMinutes;
			this.workingMinutesAct_OT = workingMinutesAct_OT;
			this.workingMinutesAct_OT_Dub = workingMinutesAct_OT_Dub;
			this.workingMinutesAct_OT_Trpl = workingMinutesAct_OT_Trpl;
			this.leaveMinutes = leaveMinutes;
			this.gatePassMinutes = gatePassMinutes;
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
		/// Gets or sets the MonthlyIndex_ID value.
		/// </summary>
		public int MonthlyIndex_ID {
			get { return monthlyIndex_ID; }
			set { monthlyIndex_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Index_ID value.
		/// </summary>
		public int Index_ID {
			get { return index_ID; }
			set { index_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DayType_ID value.
		/// </summary>
		public int DayType_ID {
			get { return dayType_ID; }
			set { dayType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutes_Mand value.
		/// </summary>
		public decimal WorkingMinutes_Mand {
			get { return workingMinutes_Mand; }
			set { workingMinutes_Mand = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutes_Act value.
		/// </summary>
		public decimal WorkingMinutes_Act {
			get { return workingMinutes_Act; }
			set { workingMinutes_Act = value; }
		}
		
		/// <summary>
		/// Gets or sets the NoPayMinutes value.
		/// </summary>
		public decimal NoPayMinutes {
			get { return noPayMinutes; }
			set { noPayMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the LateMinutes value.
		/// </summary>
		public decimal LateMinutes {
			get { return lateMinutes; }
			set { lateMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutesAct_OT value.
		/// </summary>
		public decimal WorkingMinutesAct_OT {
			get { return workingMinutesAct_OT; }
			set { workingMinutesAct_OT = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutesAct_OT_Dub value.
		/// </summary>
		public decimal WorkingMinutesAct_OT_Dub {
			get { return workingMinutesAct_OT_Dub; }
			set { workingMinutesAct_OT_Dub = value; }
		}
		
		/// <summary>
		/// Gets or sets the WorkingMinutesAct_OT_Trpl value.
		/// </summary>
		public decimal WorkingMinutesAct_OT_Trpl {
			get { return workingMinutesAct_OT_Trpl; }
			set { workingMinutesAct_OT_Trpl = value; }
		}
		
		/// <summary>
		/// Gets or sets the LeaveMinutes value.
		/// </summary>
		public decimal LeaveMinutes {
			get { return leaveMinutes; }
			set { leaveMinutes = value; }
		}
		
		/// <summary>
		/// Gets or sets the GatePassMinutes value.
		/// </summary>
		public decimal GatePassMinutes {
			get { return gatePassMinutes; }
			set { gatePassMinutes = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_tasTxMonthlyAttendance_DayTypeBreakdown table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendance_DayTypeBreakdownInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@monthlyIndex_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@index_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@dayType_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@workingMinutes_Mand", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@noPayMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lateMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_OT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_OT_Dub", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_OT_Trpl", SqlDbType.Decimal,9);
			scom.Parameters.Add("@leaveMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gatePassMinutes", SqlDbType.Decimal,9);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@monthlyIndex_ID"].Value = monthlyIndex_ID;
			scom.Parameters["@index_ID"].Value = index_ID;
			scom.Parameters["@dayType_ID"].Value = dayType_ID;
			scom.Parameters["@workingMinutes_Mand"].Value = workingMinutes_Mand;
			scom.Parameters["@workingMinutes_Act"].Value = workingMinutes_Act;
			scom.Parameters["@noPayMinutes"].Value = noPayMinutes;
			scom.Parameters["@lateMinutes"].Value = lateMinutes;
			scom.Parameters["@workingMinutesAct_OT"].Value = workingMinutesAct_OT;
			scom.Parameters["@workingMinutesAct_OT_Dub"].Value = workingMinutesAct_OT_Dub;
			scom.Parameters["@workingMinutesAct_OT_Trpl"].Value = workingMinutesAct_OT_Trpl;
			scom.Parameters["@leaveMinutes"].Value = leaveMinutes;
			scom.Parameters["@gatePassMinutes"].Value = gatePassMinutes;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_tasTxMonthlyAttendance_DayTypeBreakdown table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendance_DayTypeBreakdownUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@monthlyIndex_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@index_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@dayType_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@workingMinutes_Mand", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutes_Act", SqlDbType.Decimal,9);
			scom.Parameters.Add("@noPayMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lateMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_OT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_OT_Dub", SqlDbType.Decimal,9);
			scom.Parameters.Add("@workingMinutesAct_OT_Trpl", SqlDbType.Decimal,9);
			scom.Parameters.Add("@leaveMinutes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gatePassMinutes", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@monthlyIndex_ID"].Value = monthlyIndex_ID;
			scom.Parameters["@index_ID"].Value = index_ID;
			scom.Parameters["@dayType_ID"].Value = dayType_ID;
			scom.Parameters["@workingMinutes_Mand"].Value = workingMinutes_Mand;
			scom.Parameters["@workingMinutes_Act"].Value = workingMinutes_Act;
			scom.Parameters["@noPayMinutes"].Value = noPayMinutes;
			scom.Parameters["@lateMinutes"].Value = lateMinutes;
			scom.Parameters["@workingMinutesAct_OT"].Value = workingMinutesAct_OT;
			scom.Parameters["@workingMinutesAct_OT_Dub"].Value = workingMinutesAct_OT_Dub;
			scom.Parameters["@workingMinutesAct_OT_Trpl"].Value = workingMinutesAct_OT_Trpl;
			scom.Parameters["@leaveMinutes"].Value = leaveMinutes;
			scom.Parameters["@gatePassMinutes"].Value = gatePassMinutes;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_tasTxMonthlyAttendance_DayTypeBreakdown table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendance_DayTypeBreakdownDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@monthlyIndex_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@index_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@monthlyIndex_ID"].Value = monthlyIndex_ID;
 
			scom.Parameters["@index_ID"].Value = index_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxMonthlyAttendance_DayTypeBreakdown table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_MonthlyIndex_ID(string company_ID, string companyBranch_ID, int monthlyIndex_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendance_DayTypeBreakdownDeleteAllByCompany_ID_CompanyBranch_ID_MonthlyIndex_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@monthlyIndex_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@monthlyIndex_ID"].Value = monthlyIndex_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_tasTxMonthlyAttendance_DayTypeBreakdown table.
		/// </summary>
		public static tbl_tasTxMonthlyAttendance_DayTypeBreakdown Select(string company_ID_Incoming, string companyBranch_ID_Incoming, int monthlyIndex_ID_Incoming, int index_ID_Incoming){

			tbl_tasTxMonthlyAttendance_DayTypeBreakdown tbl_tasTxMonthlyAttendance_DayTypeBreakdownins = new tbl_tasTxMonthlyAttendance_DayTypeBreakdown();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendance_DayTypeBreakdownSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@monthlyIndex_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@index_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@monthlyIndex_ID"].Value = monthlyIndex_ID_Incoming;
			scom.Parameters["@index_ID"].Value = index_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_tasTxMonthlyAttendance_DayTypeBreakdownins = Maketbl_tasTxMonthlyAttendance_DayTypeBreakdown(dataReader);
				} else {
					tbl_tasTxMonthlyAttendance_DayTypeBreakdownins = null;
				}
			}
			scon.Close();
			return tbl_tasTxMonthlyAttendance_DayTypeBreakdownins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxMonthlyAttendance_DayTypeBreakdown table.
		/// </summary>
		public static List<tbl_tasTxMonthlyAttendance_DayTypeBreakdown> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendance_DayTypeBreakdownSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_tasTxMonthlyAttendance_DayTypeBreakdown> tbl_tasTxMonthlyAttendance_DayTypeBreakdownList = new List<tbl_tasTxMonthlyAttendance_DayTypeBreakdown>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxMonthlyAttendance_DayTypeBreakdown tbl_tasTxMonthlyAttendance_DayTypeBreakdown = Maketbl_tasTxMonthlyAttendance_DayTypeBreakdown(dataReader);
					tbl_tasTxMonthlyAttendance_DayTypeBreakdownList.Add(tbl_tasTxMonthlyAttendance_DayTypeBreakdown);
				}
			}
			scon.Close();
			return tbl_tasTxMonthlyAttendance_DayTypeBreakdownList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasTxMonthlyAttendance_DayTypeBreakdown table by a foreign key.
		/// </summary>
		public static List<tbl_tasTxMonthlyAttendance_DayTypeBreakdown> SelectAllByCompany_ID_CompanyBranch_ID_MonthlyIndex_ID(string company_ID, string companyBranch_ID, int monthlyIndex_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasTxMonthlyAttendance_DayTypeBreakdownSelectAllByCompany_ID_CompanyBranch_ID_MonthlyIndex_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@monthlyIndex_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@monthlyIndex_ID"].Value = monthlyIndex_ID;
				List<tbl_tasTxMonthlyAttendance_DayTypeBreakdown> tbl_tasTxMonthlyAttendance_DayTypeBreakdownList = new List<tbl_tasTxMonthlyAttendance_DayTypeBreakdown>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasTxMonthlyAttendance_DayTypeBreakdown tbl_tasTxMonthlyAttendance_DayTypeBreakdown = Maketbl_tasTxMonthlyAttendance_DayTypeBreakdown(dataReader);
					tbl_tasTxMonthlyAttendance_DayTypeBreakdownList.Add(tbl_tasTxMonthlyAttendance_DayTypeBreakdown);
				}
			}
			scon.Close();
			return tbl_tasTxMonthlyAttendance_DayTypeBreakdownList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_tasTxMonthlyAttendance_DayTypeBreakdown class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_tasTxMonthlyAttendance_DayTypeBreakdown Maketbl_tasTxMonthlyAttendance_DayTypeBreakdown(SqlDataReader dataReader) {
			tbl_tasTxMonthlyAttendance_DayTypeBreakdown tbl_tasTxMonthlyAttendance_DayTypeBreakdown = new tbl_tasTxMonthlyAttendance_DayTypeBreakdown();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_tasTxMonthlyAttendance_DayTypeBreakdown.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasTxMonthlyAttendance_DayTypeBreakdown.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasTxMonthlyAttendance_DayTypeBreakdown.MonthlyIndex_ID = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_tasTxMonthlyAttendance_DayTypeBreakdown.Index_ID = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_tasTxMonthlyAttendance_DayTypeBreakdown.DayType_ID = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_tasTxMonthlyAttendance_DayTypeBreakdown.WorkingMinutes_Mand = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_tasTxMonthlyAttendance_DayTypeBreakdown.WorkingMinutes_Act = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_tasTxMonthlyAttendance_DayTypeBreakdown.NoPayMinutes = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_tasTxMonthlyAttendance_DayTypeBreakdown.LateMinutes = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_tasTxMonthlyAttendance_DayTypeBreakdown.WorkingMinutesAct_OT = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_tasTxMonthlyAttendance_DayTypeBreakdown.WorkingMinutesAct_OT_Dub = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_tasTxMonthlyAttendance_DayTypeBreakdown.WorkingMinutesAct_OT_Trpl = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_tasTxMonthlyAttendance_DayTypeBreakdown.LeaveMinutes = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_tasTxMonthlyAttendance_DayTypeBreakdown.GatePassMinutes = dataReader.GetDecimal(13);
			}

			return tbl_tasTxMonthlyAttendance_DayTypeBreakdown;
		}
		/// <summary>
		/// This makes tbl_tasTxMonthlyAttendance_DayTypeBreakdown datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasTxMonthlyAttendance_DayTypeBreakdown object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasTxMonthlyAttendance_DayTypeBreakdown  tbl_tasTxMonthlyAttendance_DayTypeBreakdown   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_monthlyIndex_ID = new DataColumn("monthlyIndex_ID" , typeof(int));
			DataColumn col_index_ID = new DataColumn("index_ID" , typeof(int));
			DataColumn col_dayType_ID = new DataColumn("dayType_ID" , typeof(int));
			DataColumn col_workingMinutes_Mand = new DataColumn("workingMinutes_Mand" , typeof(decimal));
			DataColumn col_workingMinutes_Act = new DataColumn("workingMinutes_Act" , typeof(decimal));
			DataColumn col_noPayMinutes = new DataColumn("noPayMinutes" , typeof(decimal));
			DataColumn col_lateMinutes = new DataColumn("lateMinutes" , typeof(decimal));
			DataColumn col_workingMinutesAct_OT = new DataColumn("workingMinutesAct_OT" , typeof(decimal));
			DataColumn col_workingMinutesAct_OT_Dub = new DataColumn("workingMinutesAct_OT_Dub" , typeof(decimal));
			DataColumn col_workingMinutesAct_OT_Trpl = new DataColumn("workingMinutesAct_OT_Trpl" , typeof(decimal));
			DataColumn col_leaveMinutes = new DataColumn("leaveMinutes" , typeof(decimal));
			DataColumn col_gatePassMinutes = new DataColumn("gatePassMinutes" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_monthlyIndex_ID,col_index_ID,col_dayType_ID,col_workingMinutes_Mand,col_workingMinutes_Act,col_noPayMinutes,col_lateMinutes,col_workingMinutesAct_OT,col_workingMinutesAct_OT_Dub,col_workingMinutesAct_OT_Trpl,col_leaveMinutes,col_gatePassMinutes,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasTxMonthlyAttendance_DayTypeBreakdown datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasTxMonthlyAttendance_DayTypeBreakdown object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasTxMonthlyAttendance_DayTypeBreakdown user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["monthlyIndex_ID"] = user.monthlyIndex_ID;
			drow["index_ID"] = user.index_ID;
			drow["dayType_ID"] = user.dayType_ID;
			drow["workingMinutes_Mand"] = user.workingMinutes_Mand;
			drow["workingMinutes_Act"] = user.workingMinutes_Act;
			drow["noPayMinutes"] = user.noPayMinutes;
			drow["lateMinutes"] = user.lateMinutes;
			drow["workingMinutesAct_OT"] = user.workingMinutesAct_OT;
			drow["workingMinutesAct_OT_Dub"] = user.workingMinutesAct_OT_Dub;
			drow["workingMinutesAct_OT_Trpl"] = user.workingMinutesAct_OT_Trpl;
			drow["leaveMinutes"] = user.leaveMinutes;
			drow["gatePassMinutes"] = user.gatePassMinutes;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
