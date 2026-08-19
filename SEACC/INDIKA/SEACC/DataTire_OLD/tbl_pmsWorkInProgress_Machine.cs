using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_pmsWorkInProgress_Machine {
		#region Fields
		private string workInProgress_ID;
		private int line_No;
		private string prePlan_ID;
		private string section_ID;
		private string machine_ID;
		private bool isNewJob;
		private bool isJobWorkInProgress;
		private bool isJobClosed;
		private DateTime dateJobClosed;
		private bool isJobSuspended;
		private DateTime dateJobSuspended;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_pmsWorkInProgress_Machine class.
		/// </summary>
		public tbl_pmsWorkInProgress_Machine() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_pmsWorkInProgress_Machine class.
		/// </summary>
		public tbl_pmsWorkInProgress_Machine(string workInProgress_ID, int line_No, string prePlan_ID, string section_ID, string machine_ID, bool isNewJob, bool isJobWorkInProgress, bool isJobClosed, DateTime dateJobClosed, bool isJobSuspended, DateTime dateJobSuspended) {
			this.workInProgress_ID = workInProgress_ID;
			this.line_No = line_No;
			this.prePlan_ID = prePlan_ID;
			this.section_ID = section_ID;
			this.machine_ID = machine_ID;
			this.isNewJob = isNewJob;
			this.isJobWorkInProgress = isJobWorkInProgress;
			this.isJobClosed = isJobClosed;
			this.dateJobClosed = dateJobClosed;
			this.isJobSuspended = isJobSuspended;
			this.dateJobSuspended = dateJobSuspended;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the WorkInProgress_ID value.
		/// </summary>
		public string WorkInProgress_ID {
			get { return workInProgress_ID; }
			set { workInProgress_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrePlan_ID value.
		/// </summary>
		public string PrePlan_ID {
			get { return prePlan_ID; }
			set { prePlan_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Machine_ID value.
		/// </summary>
		public string Machine_ID {
			get { return machine_ID; }
			set { machine_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsNewJob value.
		/// </summary>
		public bool IsNewJob {
			get { return isNewJob; }
			set { isNewJob = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsJobWorkInProgress value.
		/// </summary>
		public bool IsJobWorkInProgress {
			get { return isJobWorkInProgress; }
			set { isJobWorkInProgress = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsJobClosed value.
		/// </summary>
		public bool IsJobClosed {
			get { return isJobClosed; }
			set { isJobClosed = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateJobClosed value.
		/// </summary>
		public DateTime DateJobClosed {
			get { return dateJobClosed; }
			set { dateJobClosed = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsJobSuspended value.
		/// </summary>
		public bool IsJobSuspended {
			get { return isJobSuspended; }
			set { isJobSuspended = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateJobSuspended value.
		/// </summary>
		public DateTime DateJobSuspended {
			get { return dateJobSuspended; }
			set { dateJobSuspended = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_pmsWorkInProgress_Machine table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_MachineInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isNewJob", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobWorkInProgress", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobClosed", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateJobClosed", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isJobSuspended", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateJobSuspended", SqlDbType.DateTime,8);
 
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@isNewJob"].Value = isNewJob;
			scom.Parameters["@isJobWorkInProgress"].Value = isJobWorkInProgress;
			scom.Parameters["@isJobClosed"].Value = isJobClosed;
			scom.Parameters["@dateJobClosed"].Value = dateJobClosed;
			scom.Parameters["@isJobSuspended"].Value = isJobSuspended;
			scom.Parameters["@dateJobSuspended"].Value = dateJobSuspended;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_pmsWorkInProgress_Machine table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_MachineUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isNewJob", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobWorkInProgress", SqlDbType.Bit,1);
			scom.Parameters.Add("@isJobClosed", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateJobClosed", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isJobSuspended", SqlDbType.Bit,1);
			scom.Parameters.Add("@dateJobSuspended", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@machine_ID"].Value = machine_ID;
			scom.Parameters["@isNewJob"].Value = isNewJob;
			scom.Parameters["@isJobWorkInProgress"].Value = isJobWorkInProgress;
			scom.Parameters["@isJobClosed"].Value = isJobClosed;
			scom.Parameters["@dateJobClosed"].Value = dateJobClosed;
			scom.Parameters["@isJobSuspended"].Value = isJobSuspended;
			scom.Parameters["@dateJobSuspended"].Value = dateJobSuspended;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_pmsWorkInProgress_Machine table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_MachineDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
 
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
 
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine table by a foreign key.
		/// </summary>
		public static void DeleteAllByLine_No_PrePlan_ID_Section_ID(int line_No, string prePlan_ID, string section_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_MachineDeleteAllByLine_No_PrePlan_ID_Section_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine table by a foreign key.
		/// </summary>
		public static void DeleteAllByMachine_ID(string machine_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_MachineDeleteAllByMachine_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@machine_ID"].Value = machine_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine table by a foreign key.
		/// </summary>
		public static void DeleteAllByWorkInProgress_ID(string workInProgress_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_MachineDeleteAllByWorkInProgress_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_pmsWorkInProgress_Machine table.
		/// </summary>
		public static tbl_pmsWorkInProgress_Machine Select(string workInProgress_ID_Incoming, int line_No_Incoming, string prePlan_ID_Incoming, string section_ID_Incoming, string machine_ID_Incoming){

			tbl_pmsWorkInProgress_Machine tbl_pmsWorkInProgress_Machineins = new tbl_pmsWorkInProgress_Machine();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_MachineSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID_Incoming;
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID_Incoming;
			scom.Parameters["@section_ID"].Value = section_ID_Incoming;
			scom.Parameters["@machine_ID"].Value = machine_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_pmsWorkInProgress_Machineins = Maketbl_pmsWorkInProgress_Machine(dataReader);
				} else {
					tbl_pmsWorkInProgress_Machineins = null;
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_Machineins;
		}
        
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine table.
		/// </summary>
		public static List<tbl_pmsWorkInProgress_Machine> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_MachineSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_pmsWorkInProgress_Machine> tbl_pmsWorkInProgress_MachineList = new List<tbl_pmsWorkInProgress_Machine>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsWorkInProgress_Machine tbl_pmsWorkInProgress_Machine = Maketbl_pmsWorkInProgress_Machine(dataReader);
					tbl_pmsWorkInProgress_MachineList.Add(tbl_pmsWorkInProgress_Machine);
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_MachineList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine table by a foreign key.
		/// </summary>
		public static List<tbl_pmsWorkInProgress_Machine> SelectAllByLine_No_PrePlan_ID_Section_ID(int line_No, string prePlan_ID, string section_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_MachineSelectAllByLine_No_PrePlan_ID_Section_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prePlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prePlan_ID"].Value = prePlan_ID;
			scom.Parameters["@section_ID"].Value = section_ID;
				List<tbl_pmsWorkInProgress_Machine> tbl_pmsWorkInProgress_MachineList = new List<tbl_pmsWorkInProgress_Machine>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsWorkInProgress_Machine tbl_pmsWorkInProgress_Machine = Maketbl_pmsWorkInProgress_Machine(dataReader);
					tbl_pmsWorkInProgress_MachineList.Add(tbl_pmsWorkInProgress_Machine);
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_MachineList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine table by a foreign key.
		/// </summary>
		public static List<tbl_pmsWorkInProgress_Machine> SelectAllByMachine_ID(string machine_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_MachineSelectAllByMachine_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machine_ID", SqlDbType.VarChar,20);
			scom.Parameters["@machine_ID"].Value = machine_ID;
				List<tbl_pmsWorkInProgress_Machine> tbl_pmsWorkInProgress_MachineList = new List<tbl_pmsWorkInProgress_Machine>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsWorkInProgress_Machine tbl_pmsWorkInProgress_Machine = Maketbl_pmsWorkInProgress_Machine(dataReader);
					tbl_pmsWorkInProgress_MachineList.Add(tbl_pmsWorkInProgress_Machine);
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_MachineList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_pmsWorkInProgress_Machine table by a foreign key.
		/// </summary>
		public static List<tbl_pmsWorkInProgress_Machine> SelectAllByWorkInProgress_ID(string workInProgress_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_pmsWorkInProgress_MachineSelectAllByWorkInProgress_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@workInProgress_ID", SqlDbType.VarChar,20);
			scom.Parameters["@workInProgress_ID"].Value = workInProgress_ID;
				List<tbl_pmsWorkInProgress_Machine> tbl_pmsWorkInProgress_MachineList = new List<tbl_pmsWorkInProgress_Machine>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_pmsWorkInProgress_Machine tbl_pmsWorkInProgress_Machine = Maketbl_pmsWorkInProgress_Machine(dataReader);
					tbl_pmsWorkInProgress_MachineList.Add(tbl_pmsWorkInProgress_Machine);
				}
			}
			scon.Close();
			return tbl_pmsWorkInProgress_MachineList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_pmsWorkInProgress_Machine class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_pmsWorkInProgress_Machine Maketbl_pmsWorkInProgress_Machine(SqlDataReader dataReader) {
			tbl_pmsWorkInProgress_Machine tbl_pmsWorkInProgress_Machine = new tbl_pmsWorkInProgress_Machine();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_pmsWorkInProgress_Machine.WorkInProgress_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_pmsWorkInProgress_Machine.Line_No = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_pmsWorkInProgress_Machine.PrePlan_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_pmsWorkInProgress_Machine.Section_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_pmsWorkInProgress_Machine.Machine_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_pmsWorkInProgress_Machine.IsNewJob = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_pmsWorkInProgress_Machine.IsJobWorkInProgress = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_pmsWorkInProgress_Machine.IsJobClosed = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_pmsWorkInProgress_Machine.DateJobClosed = dataReader.GetDateTime(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_pmsWorkInProgress_Machine.IsJobSuspended = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_pmsWorkInProgress_Machine.DateJobSuspended = dataReader.GetDateTime(10);
			}

			return tbl_pmsWorkInProgress_Machine;
		}
		/// <summary>
		/// This makes tbl_pmsWorkInProgress_Machine datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_pmsWorkInProgress_Machine object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_pmsWorkInProgress_Machine  tbl_pmsWorkInProgress_Machine   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_workInProgress_ID = new DataColumn("workInProgress_ID" , typeof(string));
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_prePlan_ID = new DataColumn("prePlan_ID" , typeof(string));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_machine_ID = new DataColumn("machine_ID" , typeof(string));
			DataColumn col_isNewJob = new DataColumn("isNewJob" , typeof(bool));
			DataColumn col_isJobWorkInProgress = new DataColumn("isJobWorkInProgress" , typeof(bool));
			DataColumn col_isJobClosed = new DataColumn("isJobClosed" , typeof(bool));
			DataColumn col_dateJobClosed = new DataColumn("dateJobClosed" , typeof(DateTime));
			DataColumn col_isJobSuspended = new DataColumn("isJobSuspended" , typeof(bool));
			DataColumn col_dateJobSuspended = new DataColumn("dateJobSuspended" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_workInProgress_ID,col_line_No,col_prePlan_ID,col_section_ID,col_machine_ID,col_isNewJob,col_isJobWorkInProgress,col_isJobClosed,col_dateJobClosed,col_isJobSuspended,col_dateJobSuspended,});		return dt;
		}
		/// <summary>
		/// This fills tbl_pmsWorkInProgress_Machine datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_pmsWorkInProgress_Machine object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_pmsWorkInProgress_Machine user) {
		DataRow drow = dt.NewRow();
		
			drow["workInProgress_ID"] = user.workInProgress_ID;
			drow["line_No"] = user.line_No;
			drow["prePlan_ID"] = user.prePlan_ID;
			drow["section_ID"] = user.section_ID;
			drow["machine_ID"] = user.machine_ID;
			drow["isNewJob"] = user.isNewJob;
			drow["isJobWorkInProgress"] = user.isJobWorkInProgress;
			drow["isJobClosed"] = user.isJobClosed;
			drow["dateJobClosed"] = user.dateJobClosed;
			drow["isJobSuspended"] = user.isJobSuspended;
			drow["dateJobSuspended"] = user.dateJobSuspended;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
