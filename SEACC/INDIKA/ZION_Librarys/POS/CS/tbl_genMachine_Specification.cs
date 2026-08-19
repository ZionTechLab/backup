using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genMachine_Specification {
		#region Fields
		private string machine_ID;
		private string machineCategory_ID;
		private string machineSepcification_ID;
		private string specificationValue;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genMachine_Specification class.
		/// </summary>
		public tbl_genMachine_Specification() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genMachine_Specification class.
		/// </summary>
		public tbl_genMachine_Specification(string machine_ID, string machineCategory_ID, string machineSepcification_ID, string specificationValue) {
			this.machine_ID = machine_ID;
			this.machineCategory_ID = machineCategory_ID;
			this.machineSepcification_ID = machineSepcification_ID;
			this.specificationValue = specificationValue;
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
		/// Gets or sets the MachineCategory_ID value.
		/// </summary>
		public string MachineCategory_ID {
			get { return machineCategory_ID; }
			set { machineCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MachineSepcification_ID value.
		/// </summary>
		public string MachineSepcification_ID {
			get { return machineSepcification_ID; }
			set { machineSepcification_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SpecificationValue value.
		/// </summary>
		public string SpecificationValue {
			get { return specificationValue; }
			set { specificationValue = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genMachine_Specification table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachine_SpecificationInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@specificationValue", SqlDbType.VarChar,50);
 
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID;
			scom.Parameters["@machineSepcification_ID"].Value = machineSepcification_ID;
			scom.Parameters["@specificationValue"].Value = specificationValue;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genMachine_Specification table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachine_SpecificationUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@specificationValue", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID;
			scom.Parameters["@machineSepcification_ID"].Value = machineSepcification_ID;
			scom.Parameters["@specificationValue"].Value = specificationValue;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genMachine_Specification table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachine_SpecificationDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID;
 
			scom.Parameters["@machineSepcification_ID"].Value = machineSepcification_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMachine_Specification table by a foreign key.
		/// </summary>
		public static void DeleteAllByMachine_ID(string machine_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachine_SpecificationDeleteAllByMachine_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;

 
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMachine_Specification table by a foreign key.
		/// </summary>
		public static void DeleteAllByMachineCategory_ID_MachineSepcification_ID(string machineCategory_ID, string machineSepcification_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachine_SpecificationDeleteAllByMachineCategory_ID_MachineSepcification_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID;
			scom.Parameters["@machineSepcification_ID"].Value = machineSepcification_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genMachine_Specification table.
		/// </summary>
		public static tbl_genMachine_Specification Select(string machine_ID_Incoming, string machineCategory_ID_Incoming, string machineSepcification_ID_Incoming){

			tbl_genMachine_Specification tbl_genMachine_Specificationins = new tbl_genMachine_Specification();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachine_SpecificationSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machine_ID"].Value = machine_ID_Incoming;
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID_Incoming;
			scom.Parameters["@machineSepcification_ID"].Value = machineSepcification_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genMachine_Specificationins = Maketbl_genMachine_Specification(dataReader);
				} else {
					tbl_genMachine_Specificationins = null;
				}
			}
			scon.Close();
			return tbl_genMachine_Specificationins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMachine_Specification table.
		/// </summary>
		public static List<tbl_genMachine_Specification> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachine_SpecificationSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genMachine_Specification> tbl_genMachine_SpecificationList = new List<tbl_genMachine_Specification>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMachine_Specification tbl_genMachine_Specification = Maketbl_genMachine_Specification(dataReader);
					tbl_genMachine_SpecificationList.Add(tbl_genMachine_Specification);
				}
			}
			scon.Close();
			return tbl_genMachine_SpecificationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMachine_Specification table by a foreign key.
		/// </summary>
		public static List<tbl_genMachine_Specification> SelectAllByMachine_ID(string machine_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachine_SpecificationSelectAllByMachine_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@machine_ID"].Value = machine_ID;
				List<tbl_genMachine_Specification> tbl_genMachine_SpecificationList = new List<tbl_genMachine_Specification>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMachine_Specification tbl_genMachine_Specification = Maketbl_genMachine_Specification(dataReader);
					tbl_genMachine_SpecificationList.Add(tbl_genMachine_Specification);
				}
			}
			scon.Close();
			return tbl_genMachine_SpecificationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genMachine_Specification table by a foreign key.
		/// </summary>
		public static List<tbl_genMachine_Specification> SelectAllByMachineCategory_ID_MachineSepcification_ID(string machineCategory_ID, string machineSepcification_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genMachine_SpecificationSelectAllByMachineCategory_ID_MachineSepcification_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID;
			scom.Parameters["@machineSepcification_ID"].Value = machineSepcification_ID;
				List<tbl_genMachine_Specification> tbl_genMachine_SpecificationList = new List<tbl_genMachine_Specification>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genMachine_Specification tbl_genMachine_Specification = Maketbl_genMachine_Specification(dataReader);
					tbl_genMachine_SpecificationList.Add(tbl_genMachine_Specification);
				}
			}
			scon.Close();
			return tbl_genMachine_SpecificationList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genMachine_Specification class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genMachine_Specification Maketbl_genMachine_Specification(SqlDataReader dataReader) {
			tbl_genMachine_Specification tbl_genMachine_Specification = new tbl_genMachine_Specification();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genMachine_Specification.Machine_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genMachine_Specification.MachineCategory_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genMachine_Specification.MachineSepcification_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genMachine_Specification.SpecificationValue = dataReader.GetString(3);
			}

			return tbl_genMachine_Specification;
		}
		/// <summary>
		/// This makes tbl_genMachine_Specification datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genMachine_Specification object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genMachine_Specification  tbl_genMachine_Specification   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_machine_ID = new DataColumn("machine_ID" , typeof(string));
			DataColumn col_machineCategory_ID = new DataColumn("machineCategory_ID" , typeof(string));
			DataColumn col_machineSepcification_ID = new DataColumn("machineSepcification_ID" , typeof(string));
			DataColumn col_specificationValue = new DataColumn("specificationValue" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_machine_ID,col_machineCategory_ID,col_machineSepcification_ID,col_specificationValue,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genMachine_Specification datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genMachine_Specification object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genMachine_Specification user) {
		DataRow drow = dt.NewRow();
		
			drow["machine_ID"] = user.machine_ID;
			drow["machineCategory_ID"] = user.machineCategory_ID;
			drow["machineSepcification_ID"] = user.machineSepcification_ID;
			drow["specificationValue"] = user.specificationValue;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
