using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_hrm_MealPlanRates {
		#region Fields
		private string mealPlan_ID;
		private string mealType_ID;
		private string menuType_ID;
		private string emp_Catagory1_ID;
		private decimal amount_byCompany;
		private decimal amount_byEmployee;
		private bool status;
		private bool isCanceled;
		private string userID_Created;
		private string userID_Modified;
		private string userID_Canceled;
		private string terminalID_Created;
		private string terminalID_Modified;
		private string terminalID_Canceled;
		private DateTime date_Created;
		private DateTime date_Modified;
		private DateTime date_Canceled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_hrm_MealPlanRates class.
		/// </summary>
		public tbl_hrm_MealPlanRates() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_hrm_MealPlanRates class.
		/// </summary>
		public tbl_hrm_MealPlanRates(string mealPlan_ID, string mealType_ID, string menuType_ID, string emp_Catagory1_ID, decimal amount_byCompany, decimal amount_byEmployee, bool status, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.mealPlan_ID = mealPlan_ID;
			this.mealType_ID = mealType_ID;
			this.menuType_ID = menuType_ID;
			this.emp_Catagory1_ID = emp_Catagory1_ID;
			this.amount_byCompany = amount_byCompany;
			this.amount_byEmployee = amount_byEmployee;
			this.status = status;
			this.isCanceled = isCanceled;
			this.userID_Created = userID_Created;
			this.userID_Modified = userID_Modified;
			this.userID_Canceled = userID_Canceled;
			this.terminalID_Created = terminalID_Created;
			this.terminalID_Modified = terminalID_Modified;
			this.terminalID_Canceled = terminalID_Canceled;
			this.date_Created = date_Created;
			this.date_Modified = date_Modified;
			this.date_Canceled = date_Canceled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the MealPlan_ID value.
		/// </summary>
		public string MealPlan_ID {
			get { return mealPlan_ID; }
			set { mealPlan_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MealType_ID value.
		/// </summary>
		public string MealType_ID {
			get { return mealType_ID; }
			set { mealType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MenuType_ID value.
		/// </summary>
		public string MenuType_ID {
			get { return menuType_ID; }
			set { menuType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Emp_Catagory1_ID value.
		/// </summary>
		public string Emp_Catagory1_ID {
			get { return emp_Catagory1_ID; }
			set { emp_Catagory1_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount_byCompany value.
		/// </summary>
		public decimal Amount_byCompany {
			get { return amount_byCompany; }
			set { amount_byCompany = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount_byEmployee value.
		/// </summary>
		public decimal Amount_byEmployee {
			get { return amount_byEmployee; }
			set { amount_byEmployee = value; }
		}
		
		/// <summary>
		/// Gets or sets the Status value.
		/// </summary>
		public bool Status {
			get { return status; }
			set { status = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCanceled value.
		/// </summary>
		public bool IsCanceled {
			get { return isCanceled; }
			set { isCanceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Created value.
		/// </summary>
		public string UserID_Created {
			get { return userID_Created; }
			set { userID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Modified value.
		/// </summary>
		public string UserID_Modified {
			get { return userID_Modified; }
			set { userID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the UserID_Canceled value.
		/// </summary>
		public string UserID_Canceled {
			get { return userID_Canceled; }
			set { userID_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Created value.
		/// </summary>
		public string TerminalID_Created {
			get { return terminalID_Created; }
			set { terminalID_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Modified value.
		/// </summary>
		public string TerminalID_Modified {
			get { return terminalID_Modified; }
			set { terminalID_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the TerminalID_Canceled value.
		/// </summary>
		public string TerminalID_Canceled {
			get { return terminalID_Canceled; }
			set { terminalID_Canceled = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Created value.
		/// </summary>
		public DateTime Date_Created {
			get { return date_Created; }
			set { date_Created = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Modified value.
		/// </summary>
		public DateTime Date_Modified {
			get { return date_Modified; }
			set { date_Modified = value; }
		}
		
		/// <summary>
		/// Gets or sets the Date_Canceled value.
		/// </summary>
		public DateTime Date_Canceled {
			get { return date_Canceled; }
			set { date_Canceled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_hrm_MealPlanRates table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrm_MealPlanRatesInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@mealPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mealType_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@menuType_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@emp_Catagory1_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@amount_byCompany", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amount_byEmployee", SqlDbType.Decimal,9);
			scom.Parameters.Add("@status", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
			scom.Parameters["@mealPlan_ID"].Value = mealPlan_ID;
			scom.Parameters["@mealType_ID"].Value = mealType_ID;
			scom.Parameters["@menuType_ID"].Value = menuType_ID;
			scom.Parameters["@emp_Catagory1_ID"].Value = emp_Catagory1_ID;
			scom.Parameters["@amount_byCompany"].Value = amount_byCompany;
			scom.Parameters["@amount_byEmployee"].Value = amount_byEmployee;
			scom.Parameters["@status"].Value = status;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_hrm_MealPlanRates table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrm_MealPlanRatesUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@mealPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mealType_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@menuType_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@emp_Catagory1_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@amount_byCompany", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amount_byEmployee", SqlDbType.Decimal,9);
			scom.Parameters.Add("@status", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCanceled", SqlDbType.Bit,1);
			scom.Parameters.Add("@userID_Created", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Modified", SqlDbType.VarChar,20);
			scom.Parameters.Add("@userID_Canceled", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terminalID_Created", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Modified", SqlDbType.VarChar,30);
			scom.Parameters.Add("@terminalID_Canceled", SqlDbType.VarChar,30);
			scom.Parameters.Add("@date_Created", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Modified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@date_Canceled", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@mealPlan_ID"].Value = mealPlan_ID;
			scom.Parameters["@mealType_ID"].Value = mealType_ID;
			scom.Parameters["@menuType_ID"].Value = menuType_ID;
			scom.Parameters["@emp_Catagory1_ID"].Value = emp_Catagory1_ID;
			scom.Parameters["@amount_byCompany"].Value = amount_byCompany;
			scom.Parameters["@amount_byEmployee"].Value = amount_byEmployee;
			scom.Parameters["@status"].Value = status;
			scom.Parameters["@isCanceled"].Value = isCanceled;
			scom.Parameters["@userID_Created"].Value = userID_Created;
			scom.Parameters["@userID_Modified"].Value = userID_Modified;
			scom.Parameters["@userID_Canceled"].Value = userID_Canceled;
			scom.Parameters["@terminalID_Created"].Value = terminalID_Created;
			scom.Parameters["@terminalID_Modified"].Value = terminalID_Modified;
			scom.Parameters["@terminalID_Canceled"].Value = terminalID_Canceled;
			scom.Parameters["@date_Created"].Value = date_Created;
			scom.Parameters["@date_Modified"].Value = date_Modified;
			scom.Parameters["@date_Canceled"].Value = date_Canceled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_hrm_MealPlanRates table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrm_MealPlanRatesDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@mealPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mealPlan_ID"].Value = mealPlan_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_hrm_MealPlanRates table.
		/// </summary>
		public static tbl_hrm_MealPlanRates Select(string mealPlan_ID_Incoming){

			tbl_hrm_MealPlanRates tbl_hrm_MealPlanRatesins = new tbl_hrm_MealPlanRates();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrm_MealPlanRatesSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mealPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mealPlan_ID"].Value = mealPlan_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_hrm_MealPlanRatesins = Maketbl_hrm_MealPlanRates(dataReader);
				} else {
					tbl_hrm_MealPlanRatesins = null;
				}
			}
			scon.Close();
			return tbl_hrm_MealPlanRatesins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_hrm_MealPlanRates table.
		/// </summary>
		public static List<tbl_hrm_MealPlanRates> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrm_MealPlanRatesSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_hrm_MealPlanRates> tbl_hrm_MealPlanRatesList = new List<tbl_hrm_MealPlanRates>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_hrm_MealPlanRates tbl_hrm_MealPlanRates = Maketbl_hrm_MealPlanRates(dataReader);
					tbl_hrm_MealPlanRatesList.Add(tbl_hrm_MealPlanRates);
				}
			}
			scon.Close();
			return tbl_hrm_MealPlanRatesList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_hrm_MealPlanRates class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_hrm_MealPlanRates Maketbl_hrm_MealPlanRates(SqlDataReader dataReader) {
			tbl_hrm_MealPlanRates tbl_hrm_MealPlanRates = new tbl_hrm_MealPlanRates();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_hrm_MealPlanRates.MealPlan_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_hrm_MealPlanRates.MealType_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_hrm_MealPlanRates.MenuType_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_hrm_MealPlanRates.Emp_Catagory1_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_hrm_MealPlanRates.Amount_byCompany = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_hrm_MealPlanRates.Amount_byEmployee = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_hrm_MealPlanRates.Status = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_hrm_MealPlanRates.IsCanceled = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_hrm_MealPlanRates.UserID_Created = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_hrm_MealPlanRates.UserID_Modified = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_hrm_MealPlanRates.UserID_Canceled = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_hrm_MealPlanRates.TerminalID_Created = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_hrm_MealPlanRates.TerminalID_Modified = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_hrm_MealPlanRates.TerminalID_Canceled = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_hrm_MealPlanRates.Date_Created = dataReader.GetDateTime(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_hrm_MealPlanRates.Date_Modified = dataReader.GetDateTime(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_hrm_MealPlanRates.Date_Canceled = dataReader.GetDateTime(16);
			}

			return tbl_hrm_MealPlanRates;
		}
		/// <summary>
		/// This makes tbl_hrm_MealPlanRates datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_hrm_MealPlanRates object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_hrm_MealPlanRates  tbl_hrm_MealPlanRates   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_mealPlan_ID = new DataColumn("mealPlan_ID" , typeof(string));
			DataColumn col_mealType_ID = new DataColumn("mealType_ID" , typeof(string));
			DataColumn col_menuType_ID = new DataColumn("menuType_ID" , typeof(string));
			DataColumn col_emp_Catagory1_ID = new DataColumn("emp_Catagory1_ID" , typeof(string));
			DataColumn col_amount_byCompany = new DataColumn("amount_byCompany" , typeof(decimal));
			DataColumn col_amount_byEmployee = new DataColumn("amount_byEmployee" , typeof(decimal));
			DataColumn col_status = new DataColumn("status" , typeof(bool));
			DataColumn col_isCanceled = new DataColumn("isCanceled" , typeof(bool));
			DataColumn col_userID_Created = new DataColumn("userID_Created" , typeof(string));
			DataColumn col_userID_Modified = new DataColumn("userID_Modified" , typeof(string));
			DataColumn col_userID_Canceled = new DataColumn("userID_Canceled" , typeof(string));
			DataColumn col_terminalID_Created = new DataColumn("terminalID_Created" , typeof(string));
			DataColumn col_terminalID_Modified = new DataColumn("terminalID_Modified" , typeof(string));
			DataColumn col_terminalID_Canceled = new DataColumn("terminalID_Canceled" , typeof(string));
			DataColumn col_date_Created = new DataColumn("date_Created" , typeof(DateTime));
			DataColumn col_date_Modified = new DataColumn("date_Modified" , typeof(DateTime));
			DataColumn col_date_Canceled = new DataColumn("date_Canceled" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_mealPlan_ID,col_mealType_ID,col_menuType_ID,col_emp_Catagory1_ID,col_amount_byCompany,col_amount_byEmployee,col_status,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_hrm_MealPlanRates datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_hrm_MealPlanRates object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_hrm_MealPlanRates user) {
		DataRow drow = dt.NewRow();
		
			drow["mealPlan_ID"] = user.mealPlan_ID;
			drow["mealType_ID"] = user.mealType_ID;
			drow["menuType_ID"] = user.menuType_ID;
			drow["emp_Catagory1_ID"] = user.emp_Catagory1_ID;
			drow["amount_byCompany"] = user.amount_byCompany;
			drow["amount_byEmployee"] = user.amount_byEmployee;
			drow["status"] = user.status;
			drow["isCanceled"] = user.isCanceled;
			drow["userID_Created"] = user.userID_Created;
			drow["userID_Modified"] = user.userID_Modified;
			drow["userID_Canceled"] = user.userID_Canceled;
			drow["terminalID_Created"] = user.terminalID_Created;
			drow["terminalID_Modified"] = user.terminalID_Modified;
			drow["terminalID_Canceled"] = user.terminalID_Canceled;
			drow["date_Created"] = user.date_Created;
			drow["date_Modified"] = user.date_Modified;
			drow["date_Canceled"] = user.date_Canceled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
