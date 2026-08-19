using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_tasEmployeeLeaveCard_detail {

		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string leave_ID;
		private string leaveType_ID;
		private decimal leaves_Utilized;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_tasEmployeeLeaveCard_detail class.
		/// </summary>
		public tbl_tasEmployeeLeaveCard_detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasEmployeeLeaveCard_detail class.
		/// </summary>
		public tbl_tasEmployeeLeaveCard_detail(string company_ID, string companyBranch_ID, string leave_ID, string leaveType_ID, decimal leaves_Utilized) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.leave_ID = leave_ID;
			this.leaveType_ID = leaveType_ID;
			this.leaves_Utilized = leaves_Utilized;
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
		/// Gets or sets the Leave_ID value.
		/// </summary>
		public string Leave_ID {
			get { return leave_ID; }
			set { leave_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the LeaveType_ID value.
		/// </summary>
		public string LeaveType_ID {
			get { return leaveType_ID; }
			set { leaveType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Leaves_Utilized value.
		/// </summary>
		public decimal Leaves_Utilized {
			get { return leaves_Utilized; }
			set { leaves_Utilized = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_tasEmployeeLeaveCard_detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCard_detailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leave_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@leaveType_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leaves_Utilized", SqlDbType.Decimal,9);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@leave_ID"].Value = leave_ID;
			scom.Parameters["@leaveType_ID"].Value = leaveType_ID;
			scom.Parameters["@leaves_Utilized"].Value = leaves_Utilized;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_tasEmployeeLeaveCard_detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCard_detailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leave_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@leaveType_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leaves_Utilized", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@leave_ID"].Value = leave_ID;
			scom.Parameters["@leaveType_ID"].Value = leaveType_ID;
			scom.Parameters["@leaves_Utilized"].Value = leaves_Utilized;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_tasEmployeeLeaveCard_detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCard_detailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leave_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@leaveType_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@leave_ID"].Value = leave_ID;
 
			scom.Parameters["@leaveType_ID"].Value = leaveType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeaveCard_detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID(string company_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCard_detailDeleteAllByCompany_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeaveCard_detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID(string company_ID, string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCard_detailDeleteAllByCompany_ID_CompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_tasEmployeeLeaveCard_detail table.
		/// </summary>
		public static tbl_tasEmployeeLeaveCard_detail Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string leave_ID_Incoming, string leaveType_ID_Incoming){

			tbl_tasEmployeeLeaveCard_detail tbl_tasEmployeeLeaveCard_detailins = new tbl_tasEmployeeLeaveCard_detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCard_detailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@leave_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@leaveType_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@leave_ID"].Value = leave_ID_Incoming;
			scom.Parameters["@leaveType_ID"].Value = leaveType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_tasEmployeeLeaveCard_detailins = Maketbl_tasEmployeeLeaveCard_detail(dataReader);
				} else {
					tbl_tasEmployeeLeaveCard_detailins = null;
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeaveCard_detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeaveCard_detail table.
		/// </summary>
		public static List<tbl_tasEmployeeLeaveCard_detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCard_detailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_tasEmployeeLeaveCard_detail> tbl_tasEmployeeLeaveCard_detailList = new List<tbl_tasEmployeeLeaveCard_detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasEmployeeLeaveCard_detail tbl_tasEmployeeLeaveCard_detail = Maketbl_tasEmployeeLeaveCard_detail(dataReader);
					tbl_tasEmployeeLeaveCard_detailList.Add(tbl_tasEmployeeLeaveCard_detail);
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeaveCard_detailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeaveCard_detail table by a foreign key.
		/// </summary>
		public static List<tbl_tasEmployeeLeaveCard_detail> SelectAllByCompany_ID(string company_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCard_detailSelectAllByCompany_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
				List<tbl_tasEmployeeLeaveCard_detail> tbl_tasEmployeeLeaveCard_detailList = new List<tbl_tasEmployeeLeaveCard_detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasEmployeeLeaveCard_detail tbl_tasEmployeeLeaveCard_detail = Maketbl_tasEmployeeLeaveCard_detail(dataReader);
					tbl_tasEmployeeLeaveCard_detailList.Add(tbl_tasEmployeeLeaveCard_detail);
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeaveCard_detailList;
		}
        public static List<tbl_tasEmployeeLeaveCard_detail> SelectAllByLeave_ID(string leave_ID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCard_detailSelectAllByLeave_ID", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@leave_ID", SqlDbType.VarChar, 10);
            scom.Parameters["@leave_ID"].Value = leave_ID;
            List<tbl_tasEmployeeLeaveCard_detail> tbl_tasEmployeeLeaveCard_detailList = new List<tbl_tasEmployeeLeaveCard_detail>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_tasEmployeeLeaveCard_detail tbl_tasEmployeeLeaveCard_detail = Maketbl_tasEmployeeLeaveCard_detail(dataReader);
                    tbl_tasEmployeeLeaveCard_detailList.Add(tbl_tasEmployeeLeaveCard_detail);
                }
            }
            scon.Close();
            return tbl_tasEmployeeLeaveCard_detailList;
        }
		/// <summary>
		/// Selects all records from the tbl_tasEmployeeLeaveCard_detail table by a foreign key.
		/// </summary>
		public static List<tbl_tasEmployeeLeaveCard_detail> SelectAllByCompany_ID_CompanyBranch_ID(string company_ID, string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasEmployeeLeaveCard_detailSelectAllByCompany_ID_CompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_tasEmployeeLeaveCard_detail> tbl_tasEmployeeLeaveCard_detailList = new List<tbl_tasEmployeeLeaveCard_detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasEmployeeLeaveCard_detail tbl_tasEmployeeLeaveCard_detail = Maketbl_tasEmployeeLeaveCard_detail(dataReader);
					tbl_tasEmployeeLeaveCard_detailList.Add(tbl_tasEmployeeLeaveCard_detail);
				}
			}
			scon.Close();
			return tbl_tasEmployeeLeaveCard_detailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_tasEmployeeLeaveCard_detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_tasEmployeeLeaveCard_detail Maketbl_tasEmployeeLeaveCard_detail(SqlDataReader dataReader) {
			tbl_tasEmployeeLeaveCard_detail tbl_tasEmployeeLeaveCard_detail = new tbl_tasEmployeeLeaveCard_detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_tasEmployeeLeaveCard_detail.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasEmployeeLeaveCard_detail.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasEmployeeLeaveCard_detail.Leave_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_tasEmployeeLeaveCard_detail.LeaveType_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_tasEmployeeLeaveCard_detail.Leaves_Utilized = dataReader.GetDecimal(4);
			}

			return tbl_tasEmployeeLeaveCard_detail;
		}
		/// <summary>
		/// This makes tbl_tasEmployeeLeaveCard_detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasEmployeeLeaveCard_detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasEmployeeLeaveCard_detail  tbl_tasEmployeeLeaveCard_detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_leave_ID = new DataColumn("leave_ID" , typeof(string));
			DataColumn col_leaveType_ID = new DataColumn("leaveType_ID" , typeof(string));
			DataColumn col_leaves_Utilized = new DataColumn("leaves_Utilized" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_leave_ID,col_leaveType_ID,col_leaves_Utilized,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasEmployeeLeaveCard_detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasEmployeeLeaveCard_detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasEmployeeLeaveCard_detail user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["leave_ID"] = user.leave_ID;
			drow["leaveType_ID"] = user.leaveType_ID;
			drow["leaves_Utilized"] = user.leaves_Utilized;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
