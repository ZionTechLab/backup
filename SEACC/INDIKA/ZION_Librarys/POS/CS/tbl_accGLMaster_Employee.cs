using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accGLMaster_Employee {
		#region Fields
		private string gl_ID;
		private string employee_ID;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_Employee class.
		/// </summary>
		public tbl_accGLMaster_Employee() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_Employee class.
		/// </summary>
		public tbl_accGLMaster_Employee(string gl_ID, string employee_ID, bool isActive) {
			this.gl_ID = gl_ID;
			this.employee_ID = employee_ID;
			this.isActive = isActive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accGLMaster_Employee table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_EmployeeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accGLMaster_Employee table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_EmployeeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accGLMaster_Employee table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_EmployeeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Employee table by a foreign key.
		/// </summary>
		public static void DeleteAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_EmployeeDeleteAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;			
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Employee table by a foreign key.
		/// </summary>
		public static void DeleteAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_EmployeeDeleteAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accGLMaster_Employee table.
		/// </summary>
		public static tbl_accGLMaster_Employee Select(string gl_ID_Incoming, string employee_ID_Incoming){

			tbl_accGLMaster_Employee tbl_accGLMaster_Employeeins = new tbl_accGLMaster_Employee();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_EmployeeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID_Incoming;
			scom.Parameters["@employee_ID"].Value = employee_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accGLMaster_Employeeins = Maketbl_accGLMaster_Employee(dataReader);
				} else {
					tbl_accGLMaster_Employeeins = null;
				}
			}
			scon.Close();
			return tbl_accGLMaster_Employeeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Employee table.
		/// </summary>
		public static List<tbl_accGLMaster_Employee> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_EmployeeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accGLMaster_Employee> tbl_accGLMaster_EmployeeList = new List<tbl_accGLMaster_Employee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_Employee tbl_accGLMaster_Employee = Maketbl_accGLMaster_Employee(dataReader);
					tbl_accGLMaster_EmployeeList.Add(tbl_accGLMaster_Employee);
				}
			}
			scon.Close();
			return tbl_accGLMaster_EmployeeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Employee table by a foreign key.
		/// </summary>
		public static List<tbl_accGLMaster_Employee> SelectAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_EmployeeSelectAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
				List<tbl_accGLMaster_Employee> tbl_accGLMaster_EmployeeList = new List<tbl_accGLMaster_Employee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_Employee tbl_accGLMaster_Employee = Maketbl_accGLMaster_Employee(dataReader);
					tbl_accGLMaster_EmployeeList.Add(tbl_accGLMaster_Employee);
				}
			}
			scon.Close();
			return tbl_accGLMaster_EmployeeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Employee table by a foreign key.
		/// </summary>
		public static List<tbl_accGLMaster_Employee> SelectAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_EmployeeSelectAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_accGLMaster_Employee> tbl_accGLMaster_EmployeeList = new List<tbl_accGLMaster_Employee>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_Employee tbl_accGLMaster_Employee = Maketbl_accGLMaster_Employee(dataReader);
					tbl_accGLMaster_EmployeeList.Add(tbl_accGLMaster_Employee);
				}
			}
			scon.Close();
			return tbl_accGLMaster_EmployeeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accGLMaster_Employee class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accGLMaster_Employee Maketbl_accGLMaster_Employee(SqlDataReader dataReader) {
			tbl_accGLMaster_Employee tbl_accGLMaster_Employee = new tbl_accGLMaster_Employee();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accGLMaster_Employee.Gl_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accGLMaster_Employee.Employee_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accGLMaster_Employee.IsActive = dataReader.GetBoolean(2);
			}

			return tbl_accGLMaster_Employee;
		}
		/// <summary>
		/// This makes tbl_accGLMaster_Employee datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_Employee object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accGLMaster_Employee  tbl_accGLMaster_Employee   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_gl_ID,col_employee_ID,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accGLMaster_Employee datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_Employee object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accGLMaster_Employee user) {
		DataRow drow = dt.NewRow();
		
			drow["gl_ID"] = user.gl_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
