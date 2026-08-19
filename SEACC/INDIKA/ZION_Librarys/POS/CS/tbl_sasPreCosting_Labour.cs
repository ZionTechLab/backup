using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasPreCosting_Labour {
		#region Fields
		private int line_NoLabour;
		private int line_No;
		private string preCosting_ID;
		private string machine_ID;
		private string employee_ID;
		private string costingType_ID;
		private decimal employeeHours;
		private decimal employeeCostPerHour;
		private decimal employeeCostTotal;
		private decimal employeeHoursPercentage;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasPreCosting_Labour class.
		/// </summary>
		public tbl_sasPreCosting_Labour() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasPreCosting_Labour class.
		/// </summary>
		public tbl_sasPreCosting_Labour(int line_NoLabour, int line_No, string preCosting_ID, string machine_ID, string employee_ID, string costingType_ID, decimal employeeHours, decimal employeeCostPerHour, decimal employeeCostTotal, decimal employeeHoursPercentage) {
			this.line_NoLabour = line_NoLabour;
			this.line_No = line_No;
			this.preCosting_ID = preCosting_ID;
			this.machine_ID = machine_ID;
			this.employee_ID = employee_ID;
			this.costingType_ID = costingType_ID;
			this.employeeHours = employeeHours;
			this.employeeCostPerHour = employeeCostPerHour;
			this.employeeCostTotal = employeeCostTotal;
			this.employeeHoursPercentage = employeeHoursPercentage;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_NoLabour value.
		/// </summary>
		public int Line_NoLabour {
			get { return line_NoLabour; }
			set { line_NoLabour = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the PreCosting_ID value.
		/// </summary>
		public string PreCosting_ID {
			get { return preCosting_ID; }
			set { preCosting_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Machine_ID value.
		/// </summary>
		public string Machine_ID {
			get { return machine_ID; }
			set { machine_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostingType_ID value.
		/// </summary>
		public string CostingType_ID {
			get { return costingType_ID; }
			set { costingType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmployeeHours value.
		/// </summary>
		public decimal EmployeeHours {
			get { return employeeHours; }
			set { employeeHours = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmployeeCostPerHour value.
		/// </summary>
		public decimal EmployeeCostPerHour {
			get { return employeeCostPerHour; }
			set { employeeCostPerHour = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmployeeCostTotal value.
		/// </summary>
		public decimal EmployeeCostTotal {
			get { return employeeCostTotal; }
			set { employeeCostTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the EmployeeHoursPercentage value.
		/// </summary>
		public decimal EmployeeHoursPercentage {
			get { return employeeHoursPercentage; }
			set { employeeHoursPercentage = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasPreCosting_Labour table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_LabourInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_NoLabour", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employeeHours", SqlDbType.Decimal,9);
			scom.Parameters.Add("@employeeCostPerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@employeeCostTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@employeeHoursPercentage", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_NoLabour"].Value = line_NoLabour;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@costingType_ID"].Value = costingType_ID;
			scom.Parameters["@employeeHours"].Value = employeeHours;
			scom.Parameters["@employeeCostPerHour"].Value = employeeCostPerHour;
			scom.Parameters["@employeeCostTotal"].Value = employeeCostTotal;
			scom.Parameters["@employeeHoursPercentage"].Value = employeeHoursPercentage;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasPreCosting_Labour table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_LabourUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_NoLabour", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@employeeHours", SqlDbType.Decimal,9);
			scom.Parameters.Add("@employeeCostPerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@employeeCostTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@employeeHoursPercentage", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_NoLabour"].Value = line_NoLabour;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@costingType_ID"].Value = costingType_ID;
			scom.Parameters["@employeeHours"].Value = employeeHours;
			scom.Parameters["@employeeCostPerHour"].Value = employeeCostPerHour;
			scom.Parameters["@employeeCostTotal"].Value = employeeCostTotal;
			scom.Parameters["@employeeHoursPercentage"].Value = employeeHoursPercentage;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasPreCosting_Labour table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_LabourDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_NoLabour", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_NoLabour"].Value = line_NoLabour;
 
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
 
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Labour table by a foreign key.
		/// </summary>
		public static void DeleteAllByLine_No_PreCosting_ID_Machine_ID(int line_No, string preCosting_ID, string machine_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_LabourDeleteAllByLine_No_PreCosting_ID_Machine_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Labour table by a foreign key.
		/// </summary>
		public static void DeleteAllByCostingType_ID(string costingType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_LabourDeleteAllByCostingType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costingType_ID"].Value = costingType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Labour table by a foreign key.
		/// </summary>
		public static void DeleteAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_LabourDeleteAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasPreCosting_Labour table.
		/// </summary>
		public static tbl_sasPreCosting_Labour Select(int line_NoLabour_Incoming, int line_No_Incoming, string preCosting_ID_Incoming, string machine_ID_Incoming, string employee_ID_Incoming){

			tbl_sasPreCosting_Labour tbl_sasPreCosting_Labourins = new tbl_sasPreCosting_Labour();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_LabourSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_NoLabour", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_NoLabour"].Value = line_NoLabour_Incoming;
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID_Incoming;
			scom.Parameters["@machine_ID"].Value = machine_ID_Incoming;
			scom.Parameters["@employee_ID"].Value = employee_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasPreCosting_Labourins = Maketbl_sasPreCosting_Labour(dataReader);
				} else {
					tbl_sasPreCosting_Labourins = null;
				}
			}
			scon.Close();
			return tbl_sasPreCosting_Labourins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Labour table.
		/// </summary>
		public static List<tbl_sasPreCosting_Labour> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_LabourSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasPreCosting_Labour> tbl_sasPreCosting_LabourList = new List<tbl_sasPreCosting_Labour>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPreCosting_Labour tbl_sasPreCosting_Labour = Maketbl_sasPreCosting_Labour(dataReader);
					tbl_sasPreCosting_LabourList.Add(tbl_sasPreCosting_Labour);
				}
			}
			scon.Close();
			return tbl_sasPreCosting_LabourList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Labour table by a foreign key.
		/// </summary>
		public static List<tbl_sasPreCosting_Labour> SelectAllByLine_No_PreCosting_ID_Machine_ID(int line_No, string preCosting_ID, string machine_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_LabourSelectAllByLine_No_PreCosting_ID_Machine_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
				List<tbl_sasPreCosting_Labour> tbl_sasPreCosting_LabourList = new List<tbl_sasPreCosting_Labour>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPreCosting_Labour tbl_sasPreCosting_Labour = Maketbl_sasPreCosting_Labour(dataReader);
					tbl_sasPreCosting_LabourList.Add(tbl_sasPreCosting_Labour);
				}
			}
			scon.Close();
			return tbl_sasPreCosting_LabourList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Labour table by a foreign key.
		/// </summary>
		public static List<tbl_sasPreCosting_Labour> SelectAllByCostingType_ID(string costingType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_LabourSelectAllByCostingType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costingType_ID"].Value = costingType_ID;
				List<tbl_sasPreCosting_Labour> tbl_sasPreCosting_LabourList = new List<tbl_sasPreCosting_Labour>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPreCosting_Labour tbl_sasPreCosting_Labour = Maketbl_sasPreCosting_Labour(dataReader);
					tbl_sasPreCosting_LabourList.Add(tbl_sasPreCosting_Labour);
				}
			}
			scon.Close();
			return tbl_sasPreCosting_LabourList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Labour table by a foreign key.
		/// </summary>
		public static List<tbl_sasPreCosting_Labour> SelectAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_LabourSelectAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_sasPreCosting_Labour> tbl_sasPreCosting_LabourList = new List<tbl_sasPreCosting_Labour>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPreCosting_Labour tbl_sasPreCosting_Labour = Maketbl_sasPreCosting_Labour(dataReader);
					tbl_sasPreCosting_LabourList.Add(tbl_sasPreCosting_Labour);
				}
			}
			scon.Close();
			return tbl_sasPreCosting_LabourList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasPreCosting_Labour class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasPreCosting_Labour Maketbl_sasPreCosting_Labour(SqlDataReader dataReader) {
			tbl_sasPreCosting_Labour tbl_sasPreCosting_Labour = new tbl_sasPreCosting_Labour();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasPreCosting_Labour.Line_NoLabour = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasPreCosting_Labour.Line_No = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasPreCosting_Labour.PreCosting_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasPreCosting_Labour.Machine_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasPreCosting_Labour.Employee_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasPreCosting_Labour.CostingType_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasPreCosting_Labour.EmployeeHours = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasPreCosting_Labour.EmployeeCostPerHour = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasPreCosting_Labour.EmployeeCostTotal = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasPreCosting_Labour.EmployeeHoursPercentage = dataReader.GetDecimal(9);
			}

			return tbl_sasPreCosting_Labour;
		}
		/// <summary>
		/// This makes tbl_sasPreCosting_Labour datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasPreCosting_Labour object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasPreCosting_Labour  tbl_sasPreCosting_Labour   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_NoLabour = new DataColumn("line_NoLabour" , typeof(int));
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_preCosting_ID = new DataColumn("preCosting_ID" , typeof(string));
			DataColumn col_machine_ID = new DataColumn("machine_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_costingType_ID = new DataColumn("costingType_ID" , typeof(string));
			DataColumn col_employeeHours = new DataColumn("employeeHours" , typeof(decimal));
			DataColumn col_employeeCostPerHour = new DataColumn("employeeCostPerHour" , typeof(decimal));
			DataColumn col_employeeCostTotal = new DataColumn("employeeCostTotal" , typeof(decimal));
			DataColumn col_employeeHoursPercentage = new DataColumn("employeeHoursPercentage" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_NoLabour,col_line_No,col_preCosting_ID,col_machine_ID,col_employee_ID,col_costingType_ID,col_employeeHours,col_employeeCostPerHour,col_employeeCostTotal,col_employeeHoursPercentage,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasPreCosting_Labour datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasPreCosting_Labour object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasPreCosting_Labour user) {
		DataRow drow = dt.NewRow();
		
			drow["line_NoLabour"] = user.line_NoLabour;
			drow["line_No"] = user.line_No;
			drow["preCosting_ID"] = user.preCosting_ID;
			drow["machine_ID"] = user.machine_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["costingType_ID"] = user.costingType_ID;
			drow["employeeHours"] = user.employeeHours;
			drow["employeeCostPerHour"] = user.employeeCostPerHour;
			drow["employeeCostTotal"] = user.employeeCostTotal;
			drow["employeeHoursPercentage"] = user.employeeHoursPercentage;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
