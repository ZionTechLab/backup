using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_payMas_ProcessPeriod_Sub {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string processGroup_ID;
		private int processPeriod_ID;
		private int processPeriod_Sub_ID;
		private string processPeriod_Sub_Title;
		private DateTime startDate;
		private DateTime endDate;
		private bool isClosedPeriod;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_payMas_ProcessPeriod_Sub class.
		/// </summary>
		public tbl_payMas_ProcessPeriod_Sub() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_payMas_ProcessPeriod_Sub class.
		/// </summary>
		public tbl_payMas_ProcessPeriod_Sub(string company_ID, string companyBranch_ID, string processGroup_ID, int processPeriod_ID, int processPeriod_Sub_ID, string processPeriod_Sub_Title, DateTime startDate, DateTime endDate, bool isClosedPeriod) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.processGroup_ID = processGroup_ID;
			this.processPeriod_ID = processPeriod_ID;
			this.processPeriod_Sub_ID = processPeriod_Sub_ID;
			this.processPeriod_Sub_Title = processPeriod_Sub_Title;
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
		/// Gets or sets the ProcessPeriod_Sub_ID value.
		/// </summary>
		public int ProcessPeriod_Sub_ID {
			get { return processPeriod_Sub_ID; }
			set { processPeriod_Sub_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProcessPeriod_Sub_Title value.
		/// </summary>
		public string ProcessPeriod_Sub_Title {
			get { return processPeriod_Sub_Title; }
			set { processPeriod_Sub_Title = value; }
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
		/// Saves a record to the tbl_payMas_ProcessPeriod_Sub table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessPeriod_SubInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@processPeriod_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processPeriod_Sub_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processPeriod_Sub_Title", SqlDbType.VarChar,50);
			scom.Parameters.Add("@startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isClosedPeriod", SqlDbType.Bit,1);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
			scom.Parameters["@processPeriod_ID"].Value = processPeriod_ID;
			scom.Parameters["@processPeriod_Sub_ID"].Value = processPeriod_Sub_ID;
			scom.Parameters["@processPeriod_Sub_Title"].Value = processPeriod_Sub_Title;
			scom.Parameters["@startDate"].Value = startDate;
			scom.Parameters["@endDate"].Value = endDate;
			scom.Parameters["@isClosedPeriod"].Value = isClosedPeriod;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_payMas_ProcessPeriod_Sub table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessPeriod_SubUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@processPeriod_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processPeriod_Sub_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processPeriod_Sub_Title", SqlDbType.VarChar,50);
			scom.Parameters.Add("@startDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@endDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isClosedPeriod", SqlDbType.Bit,1);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
			scom.Parameters["@processPeriod_ID"].Value = processPeriod_ID;
			scom.Parameters["@processPeriod_Sub_ID"].Value = processPeriod_Sub_ID;
			scom.Parameters["@processPeriod_Sub_Title"].Value = processPeriod_Sub_Title;
			scom.Parameters["@startDate"].Value = startDate;
			scom.Parameters["@endDate"].Value = endDate;
			scom.Parameters["@isClosedPeriod"].Value = isClosedPeriod;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_payMas_ProcessPeriod_Sub table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessPeriod_SubDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@processPeriod_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processPeriod_Sub_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
 
			scom.Parameters["@processPeriod_ID"].Value = processPeriod_ID;
 
			scom.Parameters["@processPeriod_Sub_ID"].Value = processPeriod_Sub_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_ProcessPeriod_Sub table by a foreign key.
		/// </summary>
		public static void DeleteAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID_ProcessPeriod_ID(string company_ID, string companyBranch_ID, string processGroup_ID, int processPeriod_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessPeriod_SubDeleteAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID_ProcessPeriod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
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
		/// Selects a single record from the tbl_payMas_ProcessPeriod_Sub table.
		/// </summary>
		public static tbl_payMas_ProcessPeriod_Sub Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string processGroup_ID_Incoming, int processPeriod_ID_Incoming, int processPeriod_Sub_ID_Incoming){

			tbl_payMas_ProcessPeriod_Sub tbl_payMas_ProcessPeriod_Subins = new tbl_payMas_ProcessPeriod_Sub();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessPeriod_SubSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@processPeriod_ID", SqlDbType.Int,4);
			scom.Parameters.Add("@processPeriod_Sub_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID_Incoming;
			scom.Parameters["@processPeriod_ID"].Value = processPeriod_ID_Incoming;
			scom.Parameters["@processPeriod_Sub_ID"].Value = processPeriod_Sub_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_payMas_ProcessPeriod_Subins = Maketbl_payMas_ProcessPeriod_Sub(dataReader);
				} else {
					tbl_payMas_ProcessPeriod_Subins = null;
				}
			}
			scon.Close();
			return tbl_payMas_ProcessPeriod_Subins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_ProcessPeriod_Sub table.
		/// </summary>
		public static List<tbl_payMas_ProcessPeriod_Sub> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessPeriod_SubSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_payMas_ProcessPeriod_Sub> tbl_payMas_ProcessPeriod_SubList = new List<tbl_payMas_ProcessPeriod_Sub>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_ProcessPeriod_Sub tbl_payMas_ProcessPeriod_Sub = Maketbl_payMas_ProcessPeriod_Sub(dataReader);
					tbl_payMas_ProcessPeriod_SubList.Add(tbl_payMas_ProcessPeriod_Sub);
				}
			}
			scon.Close();
			return tbl_payMas_ProcessPeriod_SubList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_ProcessPeriod_Sub table by a foreign key.
		/// </summary>
		public static List<tbl_payMas_ProcessPeriod_Sub> SelectAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID_ProcessPeriod_ID(string company_ID, string companyBranch_ID, string processGroup_ID, int processPeriod_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessPeriod_SubSelectAllByCompany_ID_CompanyBranch_ID_ProcessGroup_ID_ProcessPeriod_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@processPeriod_ID", SqlDbType.Int,4);
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
			scom.Parameters["@processPeriod_ID"].Value = processPeriod_ID;
				List<tbl_payMas_ProcessPeriod_Sub> tbl_payMas_ProcessPeriod_SubList = new List<tbl_payMas_ProcessPeriod_Sub>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_ProcessPeriod_Sub tbl_payMas_ProcessPeriod_Sub = Maketbl_payMas_ProcessPeriod_Sub(dataReader);
					tbl_payMas_ProcessPeriod_SubList.Add(tbl_payMas_ProcessPeriod_Sub);
				}
			}
			scon.Close();
			return tbl_payMas_ProcessPeriod_SubList;
		}

        public static List<tbl_payMas_ProcessPeriod_Sub> SelectAllByDateRange(DateTime dtmFromDate, DateTime dtmToDate)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_payMas_ProcessPeriod_SubSelectAllByDateRange", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@FromDate", SqlDbType.DateTime);
            scom.Parameters.Add("@ToDate", SqlDbType.DateTime);

            scom.Parameters["@FromDate"].Value = dtmFromDate.Date;
            scom.Parameters["@ToDate"].Value = dtmToDate.Date;

            List<tbl_payMas_ProcessPeriod_Sub> tbl_payMas_ProcessPeriod_SubList = new List<tbl_payMas_ProcessPeriod_Sub>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_payMas_ProcessPeriod_Sub tbl_payMas_ProcessPeriod_Sub = Maketbl_payMas_ProcessPeriod_Sub(dataReader);
                    tbl_payMas_ProcessPeriod_SubList.Add(tbl_payMas_ProcessPeriod_Sub);
                }
            }
            scon.Close();
            return tbl_payMas_ProcessPeriod_SubList;
        }


        /// <summary>
        /// Creates a new instance of the tbl_payMas_ProcessPeriod_Sub class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static tbl_payMas_ProcessPeriod_Sub Maketbl_payMas_ProcessPeriod_Sub(SqlDataReader dataReader) {
			tbl_payMas_ProcessPeriod_Sub tbl_payMas_ProcessPeriod_Sub = new tbl_payMas_ProcessPeriod_Sub();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_payMas_ProcessPeriod_Sub.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_payMas_ProcessPeriod_Sub.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_payMas_ProcessPeriod_Sub.ProcessGroup_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_payMas_ProcessPeriod_Sub.ProcessPeriod_ID = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_payMas_ProcessPeriod_Sub.ProcessPeriod_Sub_ID = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_payMas_ProcessPeriod_Sub.ProcessPeriod_Sub_Title = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_payMas_ProcessPeriod_Sub.StartDate = dataReader.GetDateTime(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_payMas_ProcessPeriod_Sub.EndDate = dataReader.GetDateTime(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_payMas_ProcessPeriod_Sub.IsClosedPeriod = dataReader.GetBoolean(8);
			}

			return tbl_payMas_ProcessPeriod_Sub;
		}
		/// <summary>
		/// This makes tbl_payMas_ProcessPeriod_Sub datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_payMas_ProcessPeriod_Sub object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_payMas_ProcessPeriod_Sub  tbl_payMas_ProcessPeriod_Sub   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_processGroup_ID = new DataColumn("processGroup_ID" , typeof(string));
			DataColumn col_processPeriod_ID = new DataColumn("processPeriod_ID" , typeof(int));
			DataColumn col_processPeriod_Sub_ID = new DataColumn("processPeriod_Sub_ID" , typeof(int));
			DataColumn col_processPeriod_Sub_Title = new DataColumn("processPeriod_Sub_Title" , typeof(string));
			DataColumn col_startDate = new DataColumn("startDate" , typeof(DateTime));
			DataColumn col_endDate = new DataColumn("endDate" , typeof(DateTime));
			DataColumn col_isClosedPeriod = new DataColumn("isClosedPeriod" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_processGroup_ID,col_processPeriod_ID,col_processPeriod_Sub_ID,col_processPeriod_Sub_Title,col_startDate,col_endDate,col_isClosedPeriod,});		return dt;
		}
		/// <summary>
		/// This fills tbl_payMas_ProcessPeriod_Sub datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_payMas_ProcessPeriod_Sub object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_payMas_ProcessPeriod_Sub user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["processGroup_ID"] = user.processGroup_ID;
			drow["processPeriod_ID"] = user.processPeriod_ID;
			drow["processPeriod_Sub_ID"] = user.processPeriod_Sub_ID;
			drow["processPeriod_Sub_Title"] = user.processPeriod_Sub_Title;
			drow["startDate"] = user.startDate;
			drow["endDate"] = user.endDate;
			drow["isClosedPeriod"] = user.isClosedPeriod;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
