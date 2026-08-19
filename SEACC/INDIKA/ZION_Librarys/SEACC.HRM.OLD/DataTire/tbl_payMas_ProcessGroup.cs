using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_payMas_ProcessGroup {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string processGroup_ID;
		private string processGroup_Title;
		private int pay_Period;
		private decimal divRate_Nopay;
		private decimal divRate_Late;
		private decimal maxMins_Late;
		private decimal maxDays_Late;
		private decimal graceMins_Late;
		private decimal divRate_OT;
		private decimal divRate_DOT;
		private bool isCanceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_payMas_ProcessGroup class.
		/// </summary>
		public tbl_payMas_ProcessGroup() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_payMas_ProcessGroup class.
		/// </summary>
		public tbl_payMas_ProcessGroup(string company_ID, string companyBranch_ID, string processGroup_ID, string processGroup_Title, int pay_Period, decimal divRate_Nopay, decimal divRate_Late, decimal maxMins_Late, decimal maxDays_Late, decimal graceMins_Late, decimal divRate_OT, decimal divRate_DOT, bool isCanceled) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.processGroup_ID = processGroup_ID;
			this.processGroup_Title = processGroup_Title;
			this.pay_Period = pay_Period;
			this.divRate_Nopay = divRate_Nopay;
			this.divRate_Late = divRate_Late;
			this.maxMins_Late = maxMins_Late;
			this.maxDays_Late = maxDays_Late;
			this.graceMins_Late = graceMins_Late;
			this.divRate_OT = divRate_OT;
			this.divRate_DOT = divRate_DOT;
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
		/// Gets or sets the ProcessGroup_ID value.
		/// </summary>
		public string ProcessGroup_ID {
			get { return processGroup_ID; }
			set { processGroup_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProcessGroup_Title value.
		/// </summary>
		public string ProcessGroup_Title {
			get { return processGroup_Title; }
			set { processGroup_Title = value; }
		}
		
		/// <summary>
		/// Gets or sets the Pay_Period value.
		/// </summary>
		public int Pay_Period {
			get { return pay_Period; }
			set { pay_Period = value; }
		}
		
		/// <summary>
		/// Gets or sets the DivRate_Nopay value.
		/// </summary>
		public decimal DivRate_Nopay {
			get { return divRate_Nopay; }
			set { divRate_Nopay = value; }
		}
		
		/// <summary>
		/// Gets or sets the DivRate_Late value.
		/// </summary>
		public decimal DivRate_Late {
			get { return divRate_Late; }
			set { divRate_Late = value; }
		}
		
		/// <summary>
		/// Gets or sets the MaxMins_Late value.
		/// </summary>
		public decimal MaxMins_Late {
			get { return maxMins_Late; }
			set { maxMins_Late = value; }
		}
		
		/// <summary>
		/// Gets or sets the MaxDays_Late value.
		/// </summary>
		public decimal MaxDays_Late {
			get { return maxDays_Late; }
			set { maxDays_Late = value; }
		}
		
		/// <summary>
		/// Gets or sets the GraceMins_Late value.
		/// </summary>
		public decimal GraceMins_Late {
			get { return graceMins_Late; }
			set { graceMins_Late = value; }
		}
		
		/// <summary>
		/// Gets or sets the DivRate_OT value.
		/// </summary>
		public decimal DivRate_OT {
			get { return divRate_OT; }
			set { divRate_OT = value; }
		}
		
		/// <summary>
		/// Gets or sets the DivRate_DOT value.
		/// </summary>
		public decimal DivRate_DOT {
			get { return divRate_DOT; }
			set { divRate_DOT = value; }
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
		/// Saves a record to the tbl_payMas_ProcessGroup table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessGroupInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@processGroup_Title", SqlDbType.VarChar,50);
			scom.Parameters.Add("@pay_Period", SqlDbType.Int,4);
			scom.Parameters.Add("@divRate_Nopay", SqlDbType.Decimal,9);
			scom.Parameters.Add("@divRate_Late", SqlDbType.Decimal,9);
			scom.Parameters.Add("@maxMins_Late", SqlDbType.Decimal,9);
			scom.Parameters.Add("@maxDays_Late", SqlDbType.Decimal,9);
			scom.Parameters.Add("@graceMins_Late", SqlDbType.Decimal,9);
			scom.Parameters.Add("@divRate_OT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@divRate_DOT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
			scom.Parameters["@processGroup_Title"].Value = processGroup_Title;
			scom.Parameters["@pay_Period"].Value = pay_Period;
			scom.Parameters["@divRate_Nopay"].Value = divRate_Nopay;
			scom.Parameters["@divRate_Late"].Value = divRate_Late;
			scom.Parameters["@maxMins_Late"].Value = maxMins_Late;
			scom.Parameters["@maxDays_Late"].Value = maxDays_Late;
			scom.Parameters["@graceMins_Late"].Value = graceMins_Late;
			scom.Parameters["@divRate_OT"].Value = divRate_OT;
			scom.Parameters["@divRate_DOT"].Value = divRate_DOT;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_payMas_ProcessGroup table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessGroupUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@processGroup_Title", SqlDbType.VarChar,50);
			scom.Parameters.Add("@pay_Period", SqlDbType.Int,4);
			scom.Parameters.Add("@divRate_Nopay", SqlDbType.Decimal,9);
			scom.Parameters.Add("@divRate_Late", SqlDbType.Decimal,9);
			scom.Parameters.Add("@maxMins_Late", SqlDbType.Decimal,9);
			scom.Parameters.Add("@maxDays_Late", SqlDbType.Decimal,9);
			scom.Parameters.Add("@graceMins_Late", SqlDbType.Decimal,9);
			scom.Parameters.Add("@divRate_OT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@divRate_DOT", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID;
			scom.Parameters["@processGroup_Title"].Value = processGroup_Title;
			scom.Parameters["@pay_Period"].Value = pay_Period;
			scom.Parameters["@divRate_Nopay"].Value = divRate_Nopay;
			scom.Parameters["@divRate_Late"].Value = divRate_Late;
			scom.Parameters["@maxMins_Late"].Value = maxMins_Late;
			scom.Parameters["@maxDays_Late"].Value = maxDays_Late;
			scom.Parameters["@graceMins_Late"].Value = graceMins_Late;
			scom.Parameters["@divRate_OT"].Value = divRate_OT;
			scom.Parameters["@divRate_DOT"].Value = divRate_DOT;
			scom.Parameters["@isCanceled"].Value = isCanceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_payMas_ProcessGroup table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessGroupDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
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
		/// Selects a single record from the tbl_payMas_ProcessGroup table.
		/// </summary>
		public static tbl_payMas_ProcessGroup Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string processGroup_ID_Incoming){

			tbl_payMas_ProcessGroup tbl_payMas_ProcessGroupins = new tbl_payMas_ProcessGroup();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessGroupSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@processGroup_ID", SqlDbType.VarChar,10);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@processGroup_ID"].Value = processGroup_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_payMas_ProcessGroupins = Maketbl_payMas_ProcessGroup(dataReader);
				} else {
					tbl_payMas_ProcessGroupins = null;
				}
			}
			scon.Close();
			return tbl_payMas_ProcessGroupins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_payMas_ProcessGroup table.
		/// </summary>
		public static List<tbl_payMas_ProcessGroup> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_payMas_ProcessGroupSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_payMas_ProcessGroup> tbl_payMas_ProcessGroupList = new List<tbl_payMas_ProcessGroup>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_payMas_ProcessGroup tbl_payMas_ProcessGroup = Maketbl_payMas_ProcessGroup(dataReader);
					tbl_payMas_ProcessGroupList.Add(tbl_payMas_ProcessGroup);
				}
			}
			scon.Close();
			return tbl_payMas_ProcessGroupList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_payMas_ProcessGroup class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_payMas_ProcessGroup Maketbl_payMas_ProcessGroup(SqlDataReader dataReader) {
			tbl_payMas_ProcessGroup tbl_payMas_ProcessGroup = new tbl_payMas_ProcessGroup();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_payMas_ProcessGroup.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_payMas_ProcessGroup.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_payMas_ProcessGroup.ProcessGroup_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_payMas_ProcessGroup.ProcessGroup_Title = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_payMas_ProcessGroup.Pay_Period = dataReader.GetInt32(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_payMas_ProcessGroup.DivRate_Nopay = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_payMas_ProcessGroup.DivRate_Late = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_payMas_ProcessGroup.MaxMins_Late = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_payMas_ProcessGroup.MaxDays_Late = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_payMas_ProcessGroup.GraceMins_Late = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_payMas_ProcessGroup.DivRate_OT = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_payMas_ProcessGroup.DivRate_DOT = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_payMas_ProcessGroup.IsCanceled = dataReader.GetBoolean(12);
			}

			return tbl_payMas_ProcessGroup;
		}
		/// <summary>
		/// This makes tbl_payMas_ProcessGroup datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_payMas_ProcessGroup object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_payMas_ProcessGroup  tbl_payMas_ProcessGroup   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_processGroup_ID = new DataColumn("processGroup_ID" , typeof(string));
			DataColumn col_processGroup_Title = new DataColumn("processGroup_Title" , typeof(string));
			DataColumn col_pay_Period = new DataColumn("pay_Period" , typeof(int));
			DataColumn col_divRate_Nopay = new DataColumn("divRate_Nopay" , typeof(decimal));
			DataColumn col_divRate_Late = new DataColumn("divRate_Late" , typeof(decimal));
			DataColumn col_maxMins_Late = new DataColumn("maxMins_Late" , typeof(decimal));
			DataColumn col_maxDays_Late = new DataColumn("maxDays_Late" , typeof(decimal));
			DataColumn col_graceMins_Late = new DataColumn("graceMins_Late" , typeof(decimal));
			DataColumn col_divRate_OT = new DataColumn("divRate_OT" , typeof(decimal));
			DataColumn col_divRate_DOT = new DataColumn("divRate_DOT" , typeof(decimal));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_processGroup_ID,col_processGroup_Title,col_pay_Period,col_divRate_Nopay,col_divRate_Late,col_maxMins_Late,col_maxDays_Late,col_graceMins_Late,col_divRate_OT,col_divRate_DOT,col_isCanceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_payMas_ProcessGroup datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_payMas_ProcessGroup object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_payMas_ProcessGroup user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["processGroup_ID"] = user.processGroup_ID;
			drow["processGroup_Title"] = user.processGroup_Title;
			drow["pay_Period"] = user.pay_Period;
			drow["divRate_Nopay"] = user.divRate_Nopay;
			drow["divRate_Late"] = user.divRate_Late;
			drow["maxMins_Late"] = user.maxMins_Late;
			drow["maxDays_Late"] = user.maxDays_Late;
			drow["graceMins_Late"] = user.graceMins_Late;
			drow["divRate_OT"] = user.divRate_OT;
			drow["divRate_DOT"] = user.divRate_DOT;
			drow["isCanceled"] = user.isCanceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
