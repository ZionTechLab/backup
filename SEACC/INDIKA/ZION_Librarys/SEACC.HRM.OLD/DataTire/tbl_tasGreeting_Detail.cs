using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_tasGreeting_Detail {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private int line_No;
		private string greet_ID;
		private int eMail_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_tasGreeting_Detail class.
		/// </summary>
		public tbl_tasGreeting_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasGreeting_Detail class.
		/// </summary>
		public tbl_tasGreeting_Detail(string company_ID, string companyBranch_ID, int line_No, string greet_ID, int eMail_ID) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.line_No = line_No;
			this.greet_ID = greet_ID;
			this.eMail_ID = eMail_ID;
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
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Greet_ID value.
		/// </summary>
		public string Greet_ID {
			get { return greet_ID; }
			set { greet_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the EMail_ID value.
		/// </summary>
		public int EMail_ID {
			get { return eMail_ID; }
			set { eMail_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_tasGreeting_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreeting_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@greet_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@greet_ID"].Value = greet_ID;
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_tasGreeting_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreeting_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@greet_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@greet_ID"].Value = greet_ID;
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_tasGreeting_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreeting_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@greet_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@greet_ID"].Value = greet_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_Greet_ID(string company_ID, string companyBranch_ID, string greet_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreeting_DetailDeleteAllByCompany_ID_CompanyBranch_ID_Greet_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@greet_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@greet_ID"].Value = greet_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByEMail_ID(int eMail_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreeting_DetailDeleteAllByEMail_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_tasGreeting_Detail table.
		/// </summary>
		public static tbl_tasGreeting_Detail Select(string company_ID_Incoming, string companyBranch_ID_Incoming, int line_No_Incoming, string greet_ID_Incoming){

			tbl_tasGreeting_Detail tbl_tasGreeting_Detailins = new tbl_tasGreeting_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreeting_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@greet_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@greet_ID"].Value = greet_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_tasGreeting_Detailins = Maketbl_tasGreeting_Detail(dataReader);
				} else {
					tbl_tasGreeting_Detailins = null;
				}
			}
			scon.Close();
			return tbl_tasGreeting_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting_Detail table.
		/// </summary>
		public static List<tbl_tasGreeting_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreeting_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_tasGreeting_Detail> tbl_tasGreeting_DetailList = new List<tbl_tasGreeting_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasGreeting_Detail tbl_tasGreeting_Detail = Maketbl_tasGreeting_Detail(dataReader);
					tbl_tasGreeting_DetailList.Add(tbl_tasGreeting_Detail);
				}
			}
			scon.Close();
			return tbl_tasGreeting_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_tasGreeting_Detail> SelectAllByCompany_ID_CompanyBranch_ID_Greet_ID(string company_ID, string companyBranch_ID, string greet_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreeting_DetailSelectAllByCompany_ID_CompanyBranch_ID_Greet_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@greet_ID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@greet_ID"].Value = greet_ID;
				List<tbl_tasGreeting_Detail> tbl_tasGreeting_DetailList = new List<tbl_tasGreeting_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasGreeting_Detail tbl_tasGreeting_Detail = Maketbl_tasGreeting_Detail(dataReader);
					tbl_tasGreeting_DetailList.Add(tbl_tasGreeting_Detail);
				}
			}
			scon.Close();
			return tbl_tasGreeting_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasGreeting_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_tasGreeting_Detail> SelectAllByEMail_ID(int eMail_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasGreeting_DetailSelectAllByEMail_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@eMail_ID", SqlDbType.Int,4);
			scom.Parameters["@eMail_ID"].Value = eMail_ID;
				List<tbl_tasGreeting_Detail> tbl_tasGreeting_DetailList = new List<tbl_tasGreeting_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasGreeting_Detail tbl_tasGreeting_Detail = Maketbl_tasGreeting_Detail(dataReader);
					tbl_tasGreeting_DetailList.Add(tbl_tasGreeting_Detail);
				}
			}
			scon.Close();
			return tbl_tasGreeting_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_tasGreeting_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_tasGreeting_Detail Maketbl_tasGreeting_Detail(SqlDataReader dataReader) {
			tbl_tasGreeting_Detail tbl_tasGreeting_Detail = new tbl_tasGreeting_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_tasGreeting_Detail.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasGreeting_Detail.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasGreeting_Detail.Line_No = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_tasGreeting_Detail.Greet_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_tasGreeting_Detail.EMail_ID = dataReader.GetInt32(4);
			}

			return tbl_tasGreeting_Detail;
		}
		/// <summary>
		/// This makes tbl_tasGreeting_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasGreeting_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasGreeting_Detail  tbl_tasGreeting_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_greet_ID = new DataColumn("greet_ID" , typeof(string));
			DataColumn col_eMail_ID = new DataColumn("eMail_ID" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_line_No,col_greet_ID,col_eMail_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasGreeting_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasGreeting_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasGreeting_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["line_No"] = user.line_No;
			drow["greet_ID"] = user.greet_ID;
			drow["eMail_ID"] = user.eMail_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
