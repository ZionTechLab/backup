using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_payMas_PaySlipItems_Statutary {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string payItem_ID;
		private string statutaryPayItem_ID;
		private bool isApplicable;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_payMas_PaySlipItems_Statutary class.
		/// </summary>
		public tbl_payMas_PaySlipItems_Statutary() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_payMas_PaySlipItems_Statutary class.
		/// </summary>
		public tbl_payMas_PaySlipItems_Statutary(string company_ID, string companyBranch_ID, string payItem_ID, string statutaryPayItem_ID, bool isApplicable) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.payItem_ID = payItem_ID;
			this.statutaryPayItem_ID = statutaryPayItem_ID;
			this.isApplicable = isApplicable;
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
		/// Gets or sets the PayItem_ID value.
		/// </summary>
		public string PayItem_ID {
			get { return payItem_ID; }
			set { payItem_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StatutaryPayItem_ID value.
		/// </summary>
		public string StatutaryPayItem_ID {
			get { return statutaryPayItem_ID; }
			set { statutaryPayItem_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsApplicable value.
		/// </summary>
		public bool IsApplicable {
			get { return isApplicable; }
			set { isApplicable = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_payMas_PaySlipItems_Statutary table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItems_StatutaryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@statutaryPayItem_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isApplicable", SqlDbType.Bit,1);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@payItem_ID"].Value = payItem_ID;
			scom.Parameters["@statutaryPayItem_ID"].Value = statutaryPayItem_ID;
			scom.Parameters["@isApplicable"].Value = isApplicable;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_payMas_PaySlipItems_Statutary table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItems_StatutaryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@statutaryPayItem_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isApplicable", SqlDbType.Bit,1);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@payItem_ID"].Value = payItem_ID;
			scom.Parameters["@statutaryPayItem_ID"].Value = statutaryPayItem_ID;
			scom.Parameters["@isApplicable"].Value = isApplicable;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_payMas_PaySlipItems_Statutary table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItems_StatutaryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@statutaryPayItem_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@payItem_ID"].Value = payItem_ID;
 
			scom.Parameters["@statutaryPayItem_ID"].Value = statutaryPayItem_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PaySlipItems_Statutary table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_PayItem_ID(string company_ID, string companyBranch_ID, string payItem_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItems_StatutaryDeleteAllByCompany_ID_CompanyBranch_ID_PayItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@payItem_ID"].Value = payItem_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PaySlipItems_Statutary table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_StatutaryPayItem_ID(string company_ID, string companyBranch_ID, string statutaryPayItem_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItems_StatutaryDeleteAllByCompany_ID_CompanyBranch_ID_StatutaryPayItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@statutaryPayItem_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@statutaryPayItem_ID"].Value = statutaryPayItem_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_payMas_PaySlipItems_Statutary table.
		/// </summary>
		public static tbl_payMas_PaySlipItems_Statutary Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string payItem_ID_Incoming, string statutaryPayItem_ID_Incoming){

			tbl_payMas_PaySlipItems_Statutary tbl_payMas_PaySlipItems_Statutaryins = new tbl_payMas_PaySlipItems_Statutary();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItems_StatutarySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@statutaryPayItem_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@payItem_ID"].Value = payItem_ID_Incoming;
			scom.Parameters["@statutaryPayItem_ID"].Value = statutaryPayItem_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_payMas_PaySlipItems_Statutaryins = Maketbl_payMas_PaySlipItems_Statutary(dataReader);
				} else {
					tbl_payMas_PaySlipItems_Statutaryins = null;
				}
			}
			scon.Close();
			return tbl_payMas_PaySlipItems_Statutaryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PaySlipItems_Statutary table.
		/// </summary>
		public static List<tbl_payMas_PaySlipItems_Statutary> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItems_StatutarySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_payMas_PaySlipItems_Statutary> tbl_payMas_PaySlipItems_StatutaryList = new List<tbl_payMas_PaySlipItems_Statutary>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_PaySlipItems_Statutary tbl_payMas_PaySlipItems_Statutary = Maketbl_payMas_PaySlipItems_Statutary(dataReader);
					tbl_payMas_PaySlipItems_StatutaryList.Add(tbl_payMas_PaySlipItems_Statutary);
				}
			}
			scon.Close();
			return tbl_payMas_PaySlipItems_StatutaryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PaySlipItems_Statutary table by a foreign key.
		/// </summary>
		public static List<tbl_payMas_PaySlipItems_Statutary> SelectAllByCompany_ID_CompanyBranch_ID_PayItem_ID(string company_ID, string companyBranch_ID, string payItem_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItems_StatutarySelectAllByCompany_ID_CompanyBranch_ID_PayItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@payItem_ID"].Value = payItem_ID;
				List<tbl_payMas_PaySlipItems_Statutary> tbl_payMas_PaySlipItems_StatutaryList = new List<tbl_payMas_PaySlipItems_Statutary>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_PaySlipItems_Statutary tbl_payMas_PaySlipItems_Statutary = Maketbl_payMas_PaySlipItems_Statutary(dataReader);
					tbl_payMas_PaySlipItems_StatutaryList.Add(tbl_payMas_PaySlipItems_Statutary);
				}
			}
			scon.Close();
			return tbl_payMas_PaySlipItems_StatutaryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PaySlipItems_Statutary table by a foreign key.
		/// </summary>
		public static List<tbl_payMas_PaySlipItems_Statutary> SelectAllByCompany_ID_CompanyBranch_ID_StatutaryPayItem_ID(string company_ID, string companyBranch_ID, string statutaryPayItem_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItems_StatutarySelectAllByCompany_ID_CompanyBranch_ID_StatutaryPayItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@statutaryPayItem_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@statutaryPayItem_ID"].Value = statutaryPayItem_ID;
				List<tbl_payMas_PaySlipItems_Statutary> tbl_payMas_PaySlipItems_StatutaryList = new List<tbl_payMas_PaySlipItems_Statutary>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_PaySlipItems_Statutary tbl_payMas_PaySlipItems_Statutary = Maketbl_payMas_PaySlipItems_Statutary(dataReader);
					tbl_payMas_PaySlipItems_StatutaryList.Add(tbl_payMas_PaySlipItems_Statutary);
				}
			}
			scon.Close();
			return tbl_payMas_PaySlipItems_StatutaryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_payMas_PaySlipItems_Statutary class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_payMas_PaySlipItems_Statutary Maketbl_payMas_PaySlipItems_Statutary(SqlDataReader dataReader) {
			tbl_payMas_PaySlipItems_Statutary tbl_payMas_PaySlipItems_Statutary = new tbl_payMas_PaySlipItems_Statutary();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_payMas_PaySlipItems_Statutary.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_payMas_PaySlipItems_Statutary.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_payMas_PaySlipItems_Statutary.PayItem_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_payMas_PaySlipItems_Statutary.StatutaryPayItem_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_payMas_PaySlipItems_Statutary.IsApplicable = dataReader.GetBoolean(4);
			}

			return tbl_payMas_PaySlipItems_Statutary;
		}
		/// <summary>
		/// This makes tbl_payMas_PaySlipItems_Statutary datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_payMas_PaySlipItems_Statutary object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_payMas_PaySlipItems_Statutary  tbl_payMas_PaySlipItems_Statutary   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_payItem_ID = new DataColumn("payItem_ID" , typeof(string));
			DataColumn col_statutaryPayItem_ID = new DataColumn("statutaryPayItem_ID" , typeof(string));
			DataColumn col_isApplicable = new DataColumn("isApplicable" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_payItem_ID,col_statutaryPayItem_ID,col_isApplicable,});		return dt;
		}
		/// <summary>
		/// This fills tbl_payMas_PaySlipItems_Statutary datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_payMas_PaySlipItems_Statutary object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_payMas_PaySlipItems_Statutary user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["payItem_ID"] = user.payItem_ID;
			drow["statutaryPayItem_ID"] = user.statutaryPayItem_ID;
			drow["isApplicable"] = user.isApplicable;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
