using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_payMas_PaySlipItems_Type {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string payItem_Class_ID;
		private string payItem_Type_ID;
		private string payItem_Type_Code;
		private string payItem_Type_Title;
		private bool isCanceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_payMas_PaySlipItems_Type class.
		/// </summary>
		public tbl_payMas_PaySlipItems_Type() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_payMas_PaySlipItems_Type class.
		/// </summary>
		public tbl_payMas_PaySlipItems_Type(string company_ID, string companyBranch_ID, string payItem_Class_ID, string payItem_Type_ID, string payItem_Type_Code, string payItem_Type_Title, bool isCanceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.payItem_Class_ID = payItem_Class_ID;
			this.payItem_Type_ID = payItem_Type_ID;
			this.payItem_Type_Code = payItem_Type_Code;
			this.payItem_Type_Title = payItem_Type_Title;
			this.isCanceled = isCanceled;
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
		/// Gets or sets the PayItem_Class_ID value.
		/// </summary>
		public string PayItem_Class_ID {
			get { return payItem_Class_ID; }
			set { payItem_Class_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PayItem_Type_ID value.
		/// </summary>
		public string PayItem_Type_ID {
			get { return payItem_Type_ID; }
			set { payItem_Type_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PayItem_Type_Code value.
		/// </summary>
		public string PayItem_Type_Code {
			get { return payItem_Type_Code; }
			set { payItem_Type_Code = value; }
		}
		
		/// <summary>
		/// Gets or sets the PayItem_Type_Title value.
		/// </summary>
		public string PayItem_Type_Title {
			get { return payItem_Type_Title; }
			set { payItem_Type_Title = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_payMas_PaySlipItems_Type table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItems_TypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_Class_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Type_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Type_Code", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Type_Title", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@payItem_Class_ID"].Value = payItem_Class_ID;
			scom.Parameters["@payItem_Type_ID"].Value = payItem_Type_ID;
			scom.Parameters["@payItem_Type_Code"].Value = payItem_Type_Code;
			scom.Parameters["@payItem_Type_Title"].Value = payItem_Type_Title;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_payMas_PaySlipItems_Type table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItems_TypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_Class_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Type_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Type_Code", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Type_Title", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@payItem_Class_ID"].Value = payItem_Class_ID;
			scom.Parameters["@payItem_Type_ID"].Value = payItem_Type_ID;
			scom.Parameters["@payItem_Type_Code"].Value = payItem_Type_Code;
			scom.Parameters["@payItem_Type_Title"].Value = payItem_Type_Title;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_payMas_PaySlipItems_Type table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItems_TypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_Class_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Type_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@payItem_Class_ID"].Value = payItem_Class_ID;
 
			scom.Parameters["@payItem_Type_ID"].Value = payItem_Type_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PaySlipItems_Type table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_PayItem_Class_ID(string company_ID, string companyBranch_ID, string payItem_Class_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItems_TypeDeleteAllByCompany_ID_CompanyBranch_ID_PayItem_Class_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_Class_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@payItem_Class_ID"].Value = payItem_Class_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_payMas_PaySlipItems_Type table.
		/// </summary>
		public static tbl_payMas_PaySlipItems_Type Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string payItem_Class_ID_Incoming, string payItem_Type_ID_Incoming){

			tbl_payMas_PaySlipItems_Type tbl_payMas_PaySlipItems_Typeins = new tbl_payMas_PaySlipItems_Type();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItems_TypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_Class_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@payItem_Type_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@payItem_Class_ID"].Value = payItem_Class_ID_Incoming;
			scom.Parameters["@payItem_Type_ID"].Value = payItem_Type_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_payMas_PaySlipItems_Typeins = Maketbl_payMas_PaySlipItems_Type(dataReader);
				} else {
					tbl_payMas_PaySlipItems_Typeins = null;
				}
			}
			scon.Close();
			return tbl_payMas_PaySlipItems_Typeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PaySlipItems_Type table.
		/// </summary>
		public static List<tbl_payMas_PaySlipItems_Type> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItems_TypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_payMas_PaySlipItems_Type> tbl_payMas_PaySlipItems_TypeList = new List<tbl_payMas_PaySlipItems_Type>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_PaySlipItems_Type tbl_payMas_PaySlipItems_Type = Maketbl_payMas_PaySlipItems_Type(dataReader);
					tbl_payMas_PaySlipItems_TypeList.Add(tbl_payMas_PaySlipItems_Type);
				}
			}
			scon.Close();
			return tbl_payMas_PaySlipItems_TypeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_PaySlipItems_Type table by a foreign key.
		/// </summary>
		public static List<tbl_payMas_PaySlipItems_Type> SelectAllByCompany_ID_CompanyBranch_ID_PayItem_Class_ID(string company_ID, string companyBranch_ID, string payItem_Class_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_PaySlipItems_TypeSelectAllByCompany_ID_CompanyBranch_ID_PayItem_Class_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@payItem_Class_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@payItem_Class_ID"].Value = payItem_Class_ID;
				List<tbl_payMas_PaySlipItems_Type> tbl_payMas_PaySlipItems_TypeList = new List<tbl_payMas_PaySlipItems_Type>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_PaySlipItems_Type tbl_payMas_PaySlipItems_Type = Maketbl_payMas_PaySlipItems_Type(dataReader);
					tbl_payMas_PaySlipItems_TypeList.Add(tbl_payMas_PaySlipItems_Type);
				}
			}
			scon.Close();
			return tbl_payMas_PaySlipItems_TypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_payMas_PaySlipItems_Type class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_payMas_PaySlipItems_Type Maketbl_payMas_PaySlipItems_Type(SqlDataReader dataReader) {
			tbl_payMas_PaySlipItems_Type tbl_payMas_PaySlipItems_Type = new tbl_payMas_PaySlipItems_Type();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_payMas_PaySlipItems_Type.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_payMas_PaySlipItems_Type.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_payMas_PaySlipItems_Type.PayItem_Class_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_payMas_PaySlipItems_Type.PayItem_Type_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_payMas_PaySlipItems_Type.PayItem_Type_Code = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_payMas_PaySlipItems_Type.PayItem_Type_Title = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_payMas_PaySlipItems_Type.IsCanceled = dataReader.GetBoolean(6);
			}

			return tbl_payMas_PaySlipItems_Type;
		}
		/// <summary>
		/// This makes tbl_payMas_PaySlipItems_Type datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_payMas_PaySlipItems_Type object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_payMas_PaySlipItems_Type  tbl_payMas_PaySlipItems_Type   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_payItem_Class_ID = new DataColumn("payItem_Class_ID" , typeof(string));
			DataColumn col_payItem_Type_ID = new DataColumn("payItem_Type_ID" , typeof(string));
			DataColumn col_payItem_Type_Code = new DataColumn("payItem_Type_Code" , typeof(string));
			DataColumn col_payItem_Type_Title = new DataColumn("payItem_Type_Title" , typeof(string));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_payItem_Class_ID,col_payItem_Type_ID,col_payItem_Type_Code,col_payItem_Type_Title,col_isCanceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_payMas_PaySlipItems_Type datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_payMas_PaySlipItems_Type object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_payMas_PaySlipItems_Type user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["payItem_Class_ID"] = user.payItem_Class_ID;
			drow["payItem_Type_ID"] = user.payItem_Type_ID;
			drow["payItem_Type_Code"] = user.payItem_Type_Code;
			drow["payItem_Type_Title"] = user.payItem_Type_Title;
			drow["isCanceled"] = user.isCanceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
