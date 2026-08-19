using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genMachine_Helper {
		#region Fields
		private string machine_ID;
		private string employee_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genMachine_Helper class.
		/// </summary>
		public tbl_genMachine_Helper() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genMachine_Helper class.
		/// </summary>
		public tbl_genMachine_Helper(string machine_ID, string employee_ID) {
			this.machine_ID = machine_ID;
			this.employee_ID = employee_ID;
		}
		#endregion
		
		#region Properties
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genMachine_Helper table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachine_HelperInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genMachine_Helper table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachine_HelperDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMachine_Helper table by a foreign key.
		/// </summary>
		public static void DeleteAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachine_HelperDeleteAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMachine_Helper table by a foreign key.
		/// </summary>
		public static void DeleteAllByMachine_ID(string machine_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachine_HelperDeleteAllByMachine_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMachine_Helper table by a foreign key.
		/// </summary>
		public static List<tbl_genMachine_Helper> SelectAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachine_HelperSelectAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_genMachine_Helper> tbl_genMachine_HelperList = new List<tbl_genMachine_Helper>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMachine_Helper tbl_genMachine_Helper = Maketbl_genMachine_Helper(dataReader);
					tbl_genMachine_HelperList.Add(tbl_genMachine_Helper);
				}
			}
			scon.Close();
			return tbl_genMachine_HelperList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMachine_Helper table by a foreign key.
		/// </summary>
		public static List<tbl_genMachine_Helper> SelectAllByMachine_ID(string machine_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachine_HelperSelectAllByMachine_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@machine_ID"].Value = machine_ID;
				List<tbl_genMachine_Helper> tbl_genMachine_HelperList = new List<tbl_genMachine_Helper>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMachine_Helper tbl_genMachine_Helper = Maketbl_genMachine_Helper(dataReader);
					tbl_genMachine_HelperList.Add(tbl_genMachine_Helper);
				}
			}
			scon.Close();
			return tbl_genMachine_HelperList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genMachine_Helper class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genMachine_Helper Maketbl_genMachine_Helper(SqlDataReader dataReader) {
			tbl_genMachine_Helper tbl_genMachine_Helper = new tbl_genMachine_Helper();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genMachine_Helper.Machine_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genMachine_Helper.Employee_ID = dataReader.GetString(1);
			}

			return tbl_genMachine_Helper;
		}
		/// <summary>
		/// This makes tbl_genMachine_Helper datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genMachine_Helper object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genMachine_Helper  tbl_genMachine_Helper   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_machine_ID = new DataColumn("machine_ID" , typeof(string));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_machine_ID,col_employee_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genMachine_Helper datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genMachine_Helper object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genMachine_Helper user) {
		DataRow drow = dt.NewRow();
		
			drow["machine_ID"] = user.machine_ID;
			drow["employee_ID"] = user.employee_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
