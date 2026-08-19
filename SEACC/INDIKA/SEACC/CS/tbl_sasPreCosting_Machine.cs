using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasPreCosting_Machine {
		#region Fields
		private int line_No;
		private string preCosting_ID;
		private string machine_ID;
		private decimal machineCostPerHour;
		private decimal machineHours;
		private decimal machineCostTotal;
		private bool hasEmployees;
		private bool isLocked;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasPreCosting_Machine class.
		/// </summary>
		public tbl_sasPreCosting_Machine() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasPreCosting_Machine class.
		/// </summary>
		public tbl_sasPreCosting_Machine(int line_No, string preCosting_ID, string machine_ID, decimal machineCostPerHour, decimal machineHours, decimal machineCostTotal, bool hasEmployees, bool isLocked) {
			this.line_No = line_No;
			this.preCosting_ID = preCosting_ID;
			this.machine_ID = machine_ID;
			this.machineCostPerHour = machineCostPerHour;
			this.machineHours = machineHours;
			this.machineCostTotal = machineCostTotal;
			this.hasEmployees = hasEmployees;
			this.isLocked = isLocked;
		}
		#endregion
		
		#region Properties
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
		/// Gets or sets the MachineCostPerHour value.
		/// </summary>
		public decimal MachineCostPerHour {
			get { return machineCostPerHour; }
			set { machineCostPerHour = value; }
		}
		
		/// <summary>
		/// Gets or sets the MachineHours value.
		/// </summary>
		public decimal MachineHours {
			get { return machineHours; }
			set { machineHours = value; }
		}
		
		/// <summary>
		/// Gets or sets the MachineCostTotal value.
		/// </summary>
		public decimal MachineCostTotal {
			get { return machineCostTotal; }
			set { machineCostTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the HasEmployees value.
		/// </summary>
		public bool HasEmployees {
			get { return hasEmployees; }
			set { hasEmployees = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsLocked value.
		/// </summary>
		public bool IsLocked {
			get { return isLocked; }
			set { isLocked = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasPreCosting_Machine table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_MachineInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machineCostPerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@machineHours", SqlDbType.Decimal,9);
			scom.Parameters.Add("@machineCostTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@hasEmployees", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@machineCostPerHour"].Value = machineCostPerHour;
			scom.Parameters["@machineHours"].Value = machineHours;
			scom.Parameters["@machineCostTotal"].Value = machineCostTotal;
			scom.Parameters["@hasEmployees"].Value = hasEmployees;
			scom.Parameters["@isLocked"].Value = isLocked;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasPreCosting_Machine table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_MachineUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machineCostPerHour", SqlDbType.Decimal,9);
			scom.Parameters.Add("@machineHours", SqlDbType.Decimal,9);
			scom.Parameters.Add("@machineCostTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@hasEmployees", SqlDbType.Bit,1);
			scom.Parameters.Add("@isLocked", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@machineCostPerHour"].Value = machineCostPerHour;
			scom.Parameters["@machineHours"].Value = machineHours;
			scom.Parameters["@machineCostTotal"].Value = machineCostTotal;
			scom.Parameters["@hasEmployees"].Value = hasEmployees;
			scom.Parameters["@isLocked"].Value = isLocked;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasPreCosting_Machine table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_MachineDelete", scon);
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
		/// Selects all records from the tbl_sasPreCosting_Machine table by a foreign key.
		/// </summary>
		public static void DeleteAllByPreCosting_ID(string preCosting_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_MachineDeleteAllByPreCosting_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Machine table by a foreign key.
		/// </summary>
		public static void DeleteAllByMachine_ID(string machine_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_MachineDeleteAllByMachine_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasPreCosting_Machine table.
		/// </summary>
		public static tbl_sasPreCosting_Machine Select(int line_No_Incoming, string preCosting_ID_Incoming, string machine_ID_Incoming){

			tbl_sasPreCosting_Machine tbl_sasPreCosting_Machineins = new tbl_sasPreCosting_Machine();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_MachineSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID_Incoming;
			scom.Parameters["@machine_ID"].Value = machine_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasPreCosting_Machineins = Maketbl_sasPreCosting_Machine(dataReader);
				} else {
					tbl_sasPreCosting_Machineins = null;
				}
			}
			scon.Close();
			return tbl_sasPreCosting_Machineins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Machine table.
		/// </summary>
		public static List<tbl_sasPreCosting_Machine> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_MachineSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasPreCosting_Machine> tbl_sasPreCosting_MachineList = new List<tbl_sasPreCosting_Machine>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPreCosting_Machine tbl_sasPreCosting_Machine = Maketbl_sasPreCosting_Machine(dataReader);
					tbl_sasPreCosting_MachineList.Add(tbl_sasPreCosting_Machine);
				}
			}
			scon.Close();
			return tbl_sasPreCosting_MachineList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Machine table by a foreign key.
		/// </summary>
		public static List<tbl_sasPreCosting_Machine> SelectAllByPreCosting_ID(string preCosting_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_MachineSelectAllByPreCosting_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@preCosting_ID", SqlDbType.VarChar,20);
			scom.Parameters["@preCosting_ID"].Value = preCosting_ID;
				List<tbl_sasPreCosting_Machine> tbl_sasPreCosting_MachineList = new List<tbl_sasPreCosting_Machine>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPreCosting_Machine tbl_sasPreCosting_Machine = Maketbl_sasPreCosting_Machine(dataReader);
					tbl_sasPreCosting_MachineList.Add(tbl_sasPreCosting_Machine);
				}
			}
			scon.Close();
			return tbl_sasPreCosting_MachineList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasPreCosting_Machine table by a foreign key.
		/// </summary>
		public static List<tbl_sasPreCosting_Machine> SelectAllByMachine_ID(string machine_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasPreCosting_MachineSelectAllByMachine_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@machine_ID"].Value = machine_ID;
				List<tbl_sasPreCosting_Machine> tbl_sasPreCosting_MachineList = new List<tbl_sasPreCosting_Machine>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasPreCosting_Machine tbl_sasPreCosting_Machine = Maketbl_sasPreCosting_Machine(dataReader);
					tbl_sasPreCosting_MachineList.Add(tbl_sasPreCosting_Machine);
				}
			}
			scon.Close();
			return tbl_sasPreCosting_MachineList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasPreCosting_Machine class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasPreCosting_Machine Maketbl_sasPreCosting_Machine(SqlDataReader dataReader) {
			tbl_sasPreCosting_Machine tbl_sasPreCosting_Machine = new tbl_sasPreCosting_Machine();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasPreCosting_Machine.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasPreCosting_Machine.PreCosting_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasPreCosting_Machine.Machine_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasPreCosting_Machine.MachineCostPerHour = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasPreCosting_Machine.MachineHours = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasPreCosting_Machine.MachineCostTotal = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasPreCosting_Machine.HasEmployees = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasPreCosting_Machine.IsLocked = dataReader.GetBoolean(7);
			}

			return tbl_sasPreCosting_Machine;
		}
		/// <summary>
		/// This makes tbl_sasPreCosting_Machine datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasPreCosting_Machine object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasPreCosting_Machine  tbl_sasPreCosting_Machine   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_preCosting_ID = new DataColumn("preCosting_ID" , typeof(string));
			DataColumn col_machine_ID = new DataColumn("machine_ID" , typeof(string));
			DataColumn col_machineCostPerHour = new DataColumn("machineCostPerHour" , typeof(decimal));
			DataColumn col_machineHours = new DataColumn("machineHours" , typeof(decimal));
			DataColumn col_machineCostTotal = new DataColumn("machineCostTotal" , typeof(decimal));
			DataColumn col_hasEmployees = new DataColumn("hasEmployees" , typeof(bool));
			DataColumn col_isLocked = new DataColumn("isLocked" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_preCosting_ID,col_machine_ID,col_machineCostPerHour,col_machineHours,col_machineCostTotal,col_hasEmployees,col_isLocked,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasPreCosting_Machine datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasPreCosting_Machine object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasPreCosting_Machine user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["preCosting_ID"] = user.preCosting_ID;
			drow["machine_ID"] = user.machine_ID;
			drow["machineCostPerHour"] = user.machineCostPerHour;
			drow["machineHours"] = user.machineHours;
			drow["machineCostTotal"] = user.machineCostTotal;
			drow["hasEmployees"] = user.hasEmployees;
			drow["isLocked"] = user.isLocked;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
