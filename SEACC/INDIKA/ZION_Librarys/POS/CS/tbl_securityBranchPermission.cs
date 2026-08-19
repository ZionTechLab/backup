using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_securityBranchPermission {
		#region Fields
		private string companyBranch_ID;
		private string user_ID;
		private bool allowLogin;
		private bool allowTransactions;
		private bool allowReports;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_securityBranchPermission class.
		/// </summary>
		public tbl_securityBranchPermission() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_securityBranchPermission class.
		/// </summary>
		public tbl_securityBranchPermission(string companyBranch_ID, string user_ID, bool allowLogin, bool allowTransactions, bool allowReports) {
			this.companyBranch_ID = companyBranch_ID;
			this.user_ID = user_ID;
			this.allowLogin = allowLogin;
			this.allowTransactions = allowTransactions;
			this.allowReports = allowReports;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the User_ID value.
		/// </summary>
		public string User_ID {
			get { return user_ID; }
			set { user_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowLogin value.
		/// </summary>
		public bool AllowLogin {
			get { return allowLogin; }
			set { allowLogin = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowTransactions value.
		/// </summary>
		public bool AllowTransactions {
			get { return allowTransactions; }
			set { allowTransactions = value; }
		}
		
		/// <summary>
		/// Gets or sets the AllowReports value.
		/// </summary>
		public bool AllowReports {
			get { return allowReports; }
			set { allowReports = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_securityBranchPermission table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityBranchPermissionInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@allowLogin", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowTransactions", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowReports", SqlDbType.Bit,1);
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@allowLogin"].Value = allowLogin;
			scom.Parameters["@allowTransactions"].Value = allowTransactions;
			scom.Parameters["@allowReports"].Value = allowReports;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_securityBranchPermission table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityBranchPermissionUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@user_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@allowLogin", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowTransactions", SqlDbType.Bit,1);
			scom.Parameters.Add("@allowReports", SqlDbType.Bit,1);
 
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@user_ID"].Value = user_ID;
			scom.Parameters["@allowLogin"].Value = allowLogin;
			scom.Parameters["@allowTransactions"].Value = allowTransactions;
			scom.Parameters["@allowReports"].Value = allowReports;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_securityBranchPermission table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityBranchPermissionDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_securityBranchPermission table.
		/// </summary>
		public static tbl_securityBranchPermission Select(string companyBranch_ID_Incoming){

			tbl_securityBranchPermission tbl_securityBranchPermissionins = new tbl_securityBranchPermission();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityBranchPermissionSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_securityBranchPermissionins = Maketbl_securityBranchPermission(dataReader);
				} else {
					tbl_securityBranchPermissionins = null;
				}
			}
			scon.Close();
			return tbl_securityBranchPermissionins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_securityBranchPermission table.
		/// </summary>
		public static List<tbl_securityBranchPermission> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_securityBranchPermissionSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_securityBranchPermission> tbl_securityBranchPermissionList = new List<tbl_securityBranchPermission>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_securityBranchPermission tbl_securityBranchPermission = Maketbl_securityBranchPermission(dataReader);
					tbl_securityBranchPermissionList.Add(tbl_securityBranchPermission);
				}
			}
			scon.Close();
			return tbl_securityBranchPermissionList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_securityBranchPermission class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_securityBranchPermission Maketbl_securityBranchPermission(SqlDataReader dataReader) {
			tbl_securityBranchPermission tbl_securityBranchPermission = new tbl_securityBranchPermission();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_securityBranchPermission.CompanyBranch_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_securityBranchPermission.User_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_securityBranchPermission.AllowLogin = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_securityBranchPermission.AllowTransactions = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_securityBranchPermission.AllowReports = dataReader.GetBoolean(4);
			}

			return tbl_securityBranchPermission;
		}
		/// <summary>
		/// This makes tbl_securityBranchPermission datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_securityBranchPermission object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_securityBranchPermission  tbl_securityBranchPermission   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_user_ID = new DataColumn("user_ID" , typeof(string));
			DataColumn col_allowLogin = new DataColumn("allowLogin" , typeof(bool));
			DataColumn col_allowTransactions = new DataColumn("allowTransactions" , typeof(bool));
			DataColumn col_allowReports = new DataColumn("allowReports" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_companyBranch_ID,col_user_ID,col_allowLogin,col_allowTransactions,col_allowReports,});		return dt;
		}
		/// <summary>
		/// This fills tbl_securityBranchPermission datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_securityBranchPermission object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_securityBranchPermission user) {
		DataRow drow = dt.NewRow();
		
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["user_ID"] = user.user_ID;
			drow["allowLogin"] = user.allowLogin;
			drow["allowTransactions"] = user.allowTransactions;
			drow["allowReports"] = user.allowReports;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
