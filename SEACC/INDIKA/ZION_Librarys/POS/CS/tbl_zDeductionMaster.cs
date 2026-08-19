using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zDeductionMaster {
		#region Fields
		private Int64 deduction_ID;
		private string employee_ID;
		private DateTime deductionDate;
		private string remark;
		private decimal deductionAmount;
		private decimal settledAmount;
		private bool isSettled;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zDeductionMaster class.
		/// </summary>
		public tbl_zDeductionMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zDeductionMaster class.
		/// </summary>
		public tbl_zDeductionMaster(string employee_ID, DateTime deductionDate, string remark, decimal deductionAmount, decimal settledAmount, bool isSettled) {
			this.employee_ID = employee_ID;
			this.deductionDate = deductionDate;
			this.remark = remark;
			this.deductionAmount = deductionAmount;
			this.settledAmount = settledAmount;
			this.isSettled = isSettled;
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zDeductionMaster class.
		/// </summary>
		public tbl_zDeductionMaster(Int64 deduction_ID, string employee_ID, DateTime deductionDate, string remark, decimal deductionAmount, decimal settledAmount, bool isSettled) {
			this.deduction_ID = deduction_ID;
			this.employee_ID = employee_ID;
			this.deductionDate = deductionDate;
			this.remark = remark;
			this.deductionAmount = deductionAmount;
			this.settledAmount = settledAmount;
			this.isSettled = isSettled;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Deduction_ID value.
		/// </summary>
		public Int64 Deduction_ID {
			get { return deduction_ID; }
			set { deduction_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeductionDate value.
		/// </summary>
		public DateTime DeductionDate {
			get { return deductionDate; }
			set { deductionDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeductionAmount value.
		/// </summary>
		public decimal DeductionAmount {
			get { return deductionAmount; }
			set { deductionAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the SettledAmount value.
		/// </summary>
		public decimal SettledAmount {
			get { return settledAmount; }
			set { settledAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSettled value.
		/// </summary>
		public bool IsSettled {
			get { return isSettled; }
			set { isSettled = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zDeductionMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDeductionMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deductionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@deductionAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@settledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSettled", SqlDbType.Bit,1);
 
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@deductionDate"].Value = deductionDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@deductionAmount"].Value = deductionAmount;
			scom.Parameters["@settledAmount"].Value = settledAmount;
			scom.Parameters["@isSettled"].Value = isSettled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zDeductionMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDeductionMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deductionDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@deductionAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@settledAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isSettled", SqlDbType.Bit,1);
 
 
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@deductionDate"].Value = deductionDate;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@deductionAmount"].Value = deductionAmount;
			scom.Parameters["@settledAmount"].Value = settledAmount;
			scom.Parameters["@isSettled"].Value = isSettled;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zDeductionMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDeductionMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@deduction_ID", SqlDbType.BigInt);
			scom.Parameters["@deduction_ID"].Value = deduction_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zDeductionMaster table by a foreign key.
		/// </summary>
		public static void DeleteAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDeductionMasterDeleteAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zDeductionMaster table.
		/// </summary>
		public static tbl_zDeductionMaster Select(Int64 deduction_ID_Incoming){

			tbl_zDeductionMaster tbl_zDeductionMasterins = new tbl_zDeductionMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDeductionMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deduction_ID", SqlDbType.BigInt);
			scom.Parameters["@deduction_ID"].Value = deduction_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zDeductionMasterins = Maketbl_zDeductionMaster(dataReader);
				} else {
					tbl_zDeductionMasterins = null;
				}
			}
			scon.Close();
			return tbl_zDeductionMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zDeductionMaster table.
		/// </summary>
		public static List<tbl_zDeductionMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDeductionMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zDeductionMaster> tbl_zDeductionMasterList = new List<tbl_zDeductionMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zDeductionMaster tbl_zDeductionMaster = Maketbl_zDeductionMaster(dataReader);
					tbl_zDeductionMasterList.Add(tbl_zDeductionMaster);
				}
			}
			scon.Close();
			return tbl_zDeductionMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zDeductionMaster table by a foreign key.
		/// </summary>
		public static List<tbl_zDeductionMaster> SelectAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDeductionMasterSelectAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_zDeductionMaster> tbl_zDeductionMasterList = new List<tbl_zDeductionMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zDeductionMaster tbl_zDeductionMaster = Maketbl_zDeductionMaster(dataReader);
					tbl_zDeductionMasterList.Add(tbl_zDeductionMaster);
				}
			}
			scon.Close();
			return tbl_zDeductionMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zDeductionMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zDeductionMaster Maketbl_zDeductionMaster(SqlDataReader dataReader) {
			tbl_zDeductionMaster tbl_zDeductionMaster = new tbl_zDeductionMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zDeductionMaster.Deduction_ID = dataReader.GetInt64(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zDeductionMaster.Employee_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zDeductionMaster.DeductionDate = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zDeductionMaster.Remark = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zDeductionMaster.DeductionAmount = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zDeductionMaster.SettledAmount = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zDeductionMaster.IsSettled = dataReader.GetBoolean(6);
			}

			return tbl_zDeductionMaster;
		}
		/// <summary>
		/// This makes tbl_zDeductionMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zDeductionMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zDeductionMaster  tbl_zDeductionMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_deduction_ID = new DataColumn("deduction_ID" , typeof(long));
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_deductionDate = new DataColumn("deductionDate" , typeof(DateTime));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_deductionAmount = new DataColumn("deductionAmount" , typeof(decimal));
			DataColumn col_settledAmount = new DataColumn("settledAmount" , typeof(decimal));
			DataColumn col_isSettled = new DataColumn("isSettled" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_deduction_ID,col_employee_ID,col_deductionDate,col_remark,col_deductionAmount,col_settledAmount,col_isSettled,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zDeductionMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zDeductionMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zDeductionMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["deduction_ID"] = user.deduction_ID;
			drow["employee_ID"] = user.employee_ID;
			drow["deductionDate"] = user.deductionDate;
			drow["remark"] = user.remark;
			drow["deductionAmount"] = user.deductionAmount;
			drow["settledAmount"] = user.settledAmount;
			drow["isSettled"] = user.isSettled;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
