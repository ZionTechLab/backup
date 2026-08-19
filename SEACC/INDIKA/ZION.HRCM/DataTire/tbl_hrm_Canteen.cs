using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_hrm_Canteen {
		#region Fields
		private int id;
		private DateTime tr_Date;
		private string employee_No;
		private string meal_Type_ID;
		private decimal company_Pay;
		private decimal employee_pay;
		private string apn_No;
		private string pv_No;
		private string supplier_Code;
		private string device_ID;
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
		/// Initializes a new instance of the tbl_hrm_Canteen class.
		/// </summary>
		public tbl_hrm_Canteen() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_hrm_Canteen class.
		/// </summary>
		public tbl_hrm_Canteen(DateTime tr_Date, string employee_No, string meal_Type_ID, decimal company_Pay, decimal employee_pay, string apn_No, string pv_No, string supplier_Code, string device_ID, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.tr_Date = tr_Date;
			this.employee_No = employee_No;
			this.meal_Type_ID = meal_Type_ID;
			this.company_Pay = company_Pay;
			this.employee_pay = employee_pay;
			this.apn_No = apn_No;
			this.pv_No = pv_No;
			this.supplier_Code = supplier_Code;
			this.device_ID = device_ID;
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
		
		/// <summary>
		/// Initializes a new instance of the tbl_hrm_Canteen class.
		/// </summary>
		public tbl_hrm_Canteen(int id, DateTime tr_Date, string employee_No, string meal_Type_ID, decimal company_Pay, decimal employee_pay, string apn_No, string pv_No, string supplier_Code, string device_ID, bool isCanceled, string userID_Created, string userID_Modified, string userID_Canceled, string terminalID_Created, string terminalID_Modified, string terminalID_Canceled, DateTime date_Created, DateTime date_Modified, DateTime date_Canceled) {
			this.id = id;
			this.tr_Date = tr_Date;
			this.employee_No = employee_No;
			this.meal_Type_ID = meal_Type_ID;
			this.company_Pay = company_Pay;
			this.employee_pay = employee_pay;
			this.apn_No = apn_No;
			this.pv_No = pv_No;
			this.supplier_Code = supplier_Code;
			this.device_ID = device_ID;
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
		/// Gets or sets the Id value.
		/// </summary>
		public int Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tr_Date value.
		/// </summary>
		public DateTime Tr_Date {
			get { return tr_Date; }
			set { tr_Date = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_No value.
		/// </summary>
		public string Employee_No {
			get { return employee_No; }
			set { employee_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Meal_Type_ID value.
		/// </summary>
		public string Meal_Type_ID {
			get { return meal_Type_ID; }
			set { meal_Type_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Company_Pay value.
		/// </summary>
		public decimal Company_Pay {
			get { return company_Pay; }
			set { company_Pay = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_pay value.
		/// </summary>
		public decimal Employee_pay {
			get { return employee_pay; }
			set { employee_pay = value; }
		}
		
		/// <summary>
		/// Gets or sets the Apn_No value.
		/// </summary>
		public string Apn_No {
			get { return apn_No; }
			set { apn_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Pv_No value.
		/// </summary>
		public string Pv_No {
			get { return pv_No; }
			set { pv_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the Supplier_Code value.
		/// </summary>
		public string Supplier_Code {
			get { return supplier_Code; }
			set { supplier_Code = value; }
		}
		
		/// <summary>
		/// Gets or sets the Device_ID value.
		/// </summary>
		public string Device_ID {
			get { return device_ID; }
			set { device_ID = value; }
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
		/// Saves a record to the tbl_hrm_Canteen table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrm_CanteenInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tr_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@employee_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@meal_Type_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@company_Pay", SqlDbType.Decimal,9);
			scom.Parameters.Add("@employee_pay", SqlDbType.Decimal,9);
			scom.Parameters.Add("@apn_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pv_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_Code", SqlDbType.VarChar,20);
			scom.Parameters.Add("@device_ID", SqlDbType.VarChar,20);
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
 
			scom.Parameters["@tr_Date"].Value = tr_Date;
			scom.Parameters["@employee_No"].Value = employee_No;
			scom.Parameters["@meal_Type_ID"].Value = meal_Type_ID;
			scom.Parameters["@company_Pay"].Value = company_Pay;
			scom.Parameters["@employee_pay"].Value = employee_pay;
			scom.Parameters["@apn_No"].Value = apn_No;
			scom.Parameters["@pv_No"].Value = pv_No;
			scom.Parameters["@supplier_Code"].Value = supplier_Code;
			scom.Parameters["@device_ID"].Value = device_ID;
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
		/// Updates a record in the tbl_hrm_Canteen table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrm_CanteenUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tr_Date", SqlDbType.DateTime,8);
			scom.Parameters.Add("@employee_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@meal_Type_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@company_Pay", SqlDbType.Decimal,9);
			scom.Parameters.Add("@employee_pay", SqlDbType.Decimal,9);
			scom.Parameters.Add("@apn_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@pv_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_Code", SqlDbType.VarChar,20);
			scom.Parameters.Add("@device_ID", SqlDbType.VarChar,20);
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
 
 
			scom.Parameters["@tr_Date"].Value = tr_Date;
			scom.Parameters["@employee_No"].Value = employee_No;
			scom.Parameters["@meal_Type_ID"].Value = meal_Type_ID;
			scom.Parameters["@company_Pay"].Value = company_Pay;
			scom.Parameters["@employee_pay"].Value = employee_pay;
			scom.Parameters["@apn_No"].Value = apn_No;
			scom.Parameters["@pv_No"].Value = pv_No;
			scom.Parameters["@supplier_Code"].Value = supplier_Code;
			scom.Parameters["@device_ID"].Value = device_ID;
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
		/// Deletes a record from the tbl_hrm_Canteen table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrm_CanteenDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@id", SqlDbType.Int,4);
			scom.Parameters["@id"].Value = id;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_hrm_Canteen table.
		/// </summary>
		public static tbl_hrm_Canteen Select(int id_Incoming){

			tbl_hrm_Canteen tbl_hrm_Canteenins = new tbl_hrm_Canteen();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrm_CanteenSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@id", SqlDbType.Int,4);
			scom.Parameters["@id"].Value = id_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_hrm_Canteenins = Maketbl_hrm_Canteen(dataReader);
				} else {
					tbl_hrm_Canteenins = null;
				}
			}
			scon.Close();
			return tbl_hrm_Canteenins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_hrm_Canteen table.
		/// </summary>
		public static List<tbl_hrm_Canteen> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_hrm_CanteenSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_hrm_Canteen> tbl_hrm_CanteenList = new List<tbl_hrm_Canteen>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_hrm_Canteen tbl_hrm_Canteen = Maketbl_hrm_Canteen(dataReader);
					tbl_hrm_CanteenList.Add(tbl_hrm_Canteen);
				}
			}
			scon.Close();
			return tbl_hrm_CanteenList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_hrm_Canteen class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_hrm_Canteen Maketbl_hrm_Canteen(SqlDataReader dataReader) {
			tbl_hrm_Canteen tbl_hrm_Canteen = new tbl_hrm_Canteen();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_hrm_Canteen.Id = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_hrm_Canteen.Tr_Date = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_hrm_Canteen.Employee_No = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_hrm_Canteen.Meal_Type_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_hrm_Canteen.Company_Pay = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_hrm_Canteen.Employee_pay = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_hrm_Canteen.Apn_No = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_hrm_Canteen.Pv_No = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_hrm_Canteen.Supplier_Code = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_hrm_Canteen.Device_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_hrm_Canteen.IsCanceled = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_hrm_Canteen.UserID_Created = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_hrm_Canteen.UserID_Modified = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_hrm_Canteen.UserID_Canceled = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_hrm_Canteen.TerminalID_Created = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_hrm_Canteen.TerminalID_Modified = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_hrm_Canteen.TerminalID_Canceled = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_hrm_Canteen.Date_Created = dataReader.GetDateTime(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_hrm_Canteen.Date_Modified = dataReader.GetDateTime(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_hrm_Canteen.Date_Canceled = dataReader.GetDateTime(19);
			}

			return tbl_hrm_Canteen;
		}
		/// <summary>
		/// This makes tbl_hrm_Canteen datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_hrm_Canteen object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_hrm_Canteen  tbl_hrm_Canteen   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_id = new DataColumn("id" , typeof(int));
			DataColumn col_tr_Date = new DataColumn("tr_Date" , typeof(DateTime));
			DataColumn col_employee_No = new DataColumn("employee_No" , typeof(string));
			DataColumn col_meal_Type_ID = new DataColumn("meal_Type_ID" , typeof(string));
			DataColumn col_company_Pay = new DataColumn("company_Pay" , typeof(decimal));
			DataColumn col_employee_pay = new DataColumn("employee_pay" , typeof(decimal));
			DataColumn col_apn_No = new DataColumn("apn_No" , typeof(string));
			DataColumn col_pv_No = new DataColumn("pv_No" , typeof(string));
			DataColumn col_supplier_Code = new DataColumn("supplier_Code" , typeof(string));
			DataColumn col_device_ID = new DataColumn("device_ID" , typeof(string));
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
		dt.Columns.AddRange(new DataColumn[] { col_id,col_tr_Date,col_employee_No,col_meal_Type_ID,col_company_Pay,col_employee_pay,col_apn_No,col_pv_No,col_supplier_Code,col_device_ID,col_isCanceled,col_userID_Created,col_userID_Modified,col_userID_Canceled,col_terminalID_Created,col_terminalID_Modified,col_terminalID_Canceled,col_date_Created,col_date_Modified,col_date_Canceled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_hrm_Canteen datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_hrm_Canteen object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_hrm_Canteen user) {
		DataRow drow = dt.NewRow();
		
			drow["id"] = user.id;
			drow["tr_Date"] = user.tr_Date;
			drow["employee_No"] = user.employee_No;
			drow["meal_Type_ID"] = user.meal_Type_ID;
			drow["company_Pay"] = user.company_Pay;
			drow["employee_pay"] = user.employee_pay;
			drow["apn_No"] = user.apn_No;
			drow["pv_No"] = user.pv_No;
			drow["supplier_Code"] = user.supplier_Code;
			drow["device_ID"] = user.device_ID;
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
