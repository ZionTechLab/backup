using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_payMas_ProcessPeriod_Main {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string processGroup_ID;
		private int processPeriod_ID;
		private string processPeriod_Title;
		private DateTime startDate;
		private DateTime endDate;
		private bool isClosedPeriod;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_payMas_ProcessPeriod_Main class.
		/// </summary>
		public tbl_payMas_ProcessPeriod_Main() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_payMas_ProcessPeriod_Main class.
		/// </summary>
		public tbl_payMas_ProcessPeriod_Main(string company_ID, string companyBranch_ID, string processGroup_ID, int processPeriod_ID, string processPeriod_Title, DateTime startDate, DateTime endDate, bool isClosedPeriod) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.processGroup_ID = processGroup_ID;
			this.processPeriod_ID = processPeriod_ID;
			this.processPeriod_Title = processPeriod_Title;
			this.startDate = startDate;
			this.endDate = endDate;
			this.isClosedPeriod = isClosedPeriod;
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
		/// Gets or sets the ProcessGroup_ID value.
		/// </summary>
		public string ProcessGroup_ID {
			get { return processGroup_ID; }
			set { processGroup_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProcessPeriod_ID value.
		/// </summary>
		public int ProcessPeriod_ID {
			get { return processPeriod_ID; }
			set { processPeriod_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProcessPeriod_Title value.
		/// </summary>
		public string ProcessPeriod_Title {
			get { return processPeriod_Title; }
			set { processPeriod_Title = value; }
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
		/// Gets or sets the IsClosedPeriod value.
		/// </summary>
		public bool IsClosedPeriod {
			get { return isClosedPeriod; }
			set { isClosedPeriod = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_payMas_ProcessPeriod_Main table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessPeriod_MainInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@processPeriod_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processPeriod_Title", SqlDbType.VarChar,50);
			scom.Parameters.Add("@startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isClosedPeriod", SqlDbType.Bit,1);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
			scom.Parameters["@processPeriod_ID"].Value = processPeriod_ID;
			scom.Parameters["@processPeriod_Title"].Value = processPeriod_Title;
			scom.Parameters["@startDate"].Value = startDate;
			scom.Parameters["@endDate"].Value = endDate;
			scom.Parameters["@isClosedPeriod"].Value = isClosedPeriod;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_payMas_ProcessPeriod_Main table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessPeriod_MainUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@processPeriod_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processPeriod_Title", SqlDbType.VarChar,50);
			scom.Parameters.Add("@startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isClosedPeriod", SqlDbType.Bit,1);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
			scom.Parameters["@processPeriod_ID"].Value = processPeriod_ID;
			scom.Parameters["@processPeriod_Title"].Value = processPeriod_Title;
			scom.Parameters["@startDate"].Value = startDate;
			scom.Parameters["@endDate"].Value = endDate;
			scom.Parameters["@isClosedPeriod"].Value = isClosedPeriod;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_payMas_ProcessPeriod_Main table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessPeriod_MainDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@processPeriod_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
 
			scom.Parameters["@processPeriod_ID"].Value = processPeriod_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_ProcessPeriod_Main table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID(string company_ID, string companyBranch_ID, string processGroup_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessPeriod_MainDeleteAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_payMas_ProcessPeriod_Main table.
		/// </summary>
		public static tbl_payMas_ProcessPeriod_Main Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string processGroup_ID_Incoming, int processPeriod_ID_Incoming){

			tbl_payMas_ProcessPeriod_Main tbl_payMas_ProcessPeriod_Mainins = new tbl_payMas_ProcessPeriod_Main();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessPeriod_MainSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@processPeriod_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID_Incoming;
			scom.Parameters["@processPeriod_ID"].Value = processPeriod_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_payMas_ProcessPeriod_Mainins = Maketbl_payMas_ProcessPeriod_Main(dataReader);
				} else {
					tbl_payMas_ProcessPeriod_Mainins = null;
				}
			}
			scon.Close();
			return tbl_payMas_ProcessPeriod_Mainins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_ProcessPeriod_Main table.
		/// </summary>
		public static List<tbl_payMas_ProcessPeriod_Main> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessPeriod_MainSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_payMas_ProcessPeriod_Main> tbl_payMas_ProcessPeriod_MainList = new List<tbl_payMas_ProcessPeriod_Main>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_ProcessPeriod_Main tbl_payMas_ProcessPeriod_Main = Maketbl_payMas_ProcessPeriod_Main(dataReader);
					tbl_payMas_ProcessPeriod_MainList.Add(tbl_payMas_ProcessPeriod_Main);
				}
			}
			scon.Close();
			return tbl_payMas_ProcessPeriod_MainList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_ProcessPeriod_Main table by a foreign key.
		/// </summary>
		public static List<tbl_payMas_ProcessPeriod_Main> SelectAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID(string company_ID, string companyBranch_ID, string processGroup_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessPeriod_MainSelectAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
				List<tbl_payMas_ProcessPeriod_Main> tbl_payMas_ProcessPeriod_MainList = new List<tbl_payMas_ProcessPeriod_Main>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_ProcessPeriod_Main tbl_payMas_ProcessPeriod_Main = Maketbl_payMas_ProcessPeriod_Main(dataReader);
					tbl_payMas_ProcessPeriod_MainList.Add(tbl_payMas_ProcessPeriod_Main);
				}
			}
			scon.Close();
			return tbl_payMas_ProcessPeriod_MainList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_payMas_ProcessPeriod_Main class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_payMas_ProcessPeriod_Main Maketbl_payMas_ProcessPeriod_Main(SqlDataReader dataReader) {
			tbl_payMas_ProcessPeriod_Main tbl_payMas_ProcessPeriod_Main = new tbl_payMas_ProcessPeriod_Main();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_payMas_ProcessPeriod_Main.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_payMas_ProcessPeriod_Main.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_payMas_ProcessPeriod_Main.ProcessGroup_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_payMas_ProcessPeriod_Main.ProcessPeriod_ID = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_payMas_ProcessPeriod_Main.ProcessPeriod_Title = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_payMas_ProcessPeriod_Main.StartDate = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_payMas_ProcessPeriod_Main.EndDate = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_payMas_ProcessPeriod_Main.IsClosedPeriod = dataReader.GetBoolean(7);
			}

			return tbl_payMas_ProcessPeriod_Main;
		}
		/// <summary>
		/// This makes tbl_payMas_ProcessPeriod_Main datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_payMas_ProcessPeriod_Main object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_payMas_ProcessPeriod_Main  tbl_payMas_ProcessPeriod_Main   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_processGroup_ID = new DataColumn("processGroup_ID" , typeof(string));
			DataColumn col_processPeriod_ID = new DataColumn("processPeriod_ID" , typeof(int));
			DataColumn col_processPeriod_Title = new DataColumn("processPeriod_Title" , typeof(string));
			DataColumn col_startDate = new DataColumn("startDate" , typeof(DateTime));
			DataColumn col_endDate = new DataColumn("endDate" , typeof(DateTime));
			DataColumn col_isClosedPeriod = new DataColumn("isClosedPeriod" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_processGroup_ID,col_processPeriod_ID,col_processPeriod_Title,col_startDate,col_endDate,col_isClosedPeriod,});		return dt;
		}
		/// <summary>
		/// This fills tbl_payMas_ProcessPeriod_Main datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_payMas_ProcessPeriod_Main object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_payMas_ProcessPeriod_Main user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["processGroup_ID"] = user.processGroup_ID;
			drow["processPeriod_ID"] = user.processPeriod_ID;
			drow["processPeriod_Title"] = user.processPeriod_Title;
			drow["startDate"] = user.startDate;
			drow["endDate"] = user.endDate;
			drow["isClosedPeriod"] = user.isClosedPeriod;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
