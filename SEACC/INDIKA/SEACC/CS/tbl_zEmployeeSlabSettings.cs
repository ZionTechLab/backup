using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zEmployeeSlabSettings {
		#region Fields
		private string employee_ID;
		private int slabID;
		private decimal fromAmount;
		private decimal toAmount;
		private decimal commissionPercentage;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zEmployeeSlabSettings class.
		/// </summary>
		public tbl_zEmployeeSlabSettings() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zEmployeeSlabSettings class.
		/// </summary>
		public tbl_zEmployeeSlabSettings(string employee_ID, int slabID, decimal fromAmount, decimal toAmount, decimal commissionPercentage) {
			this.employee_ID = employee_ID;
			this.slabID = slabID;
			this.fromAmount = fromAmount;
			this.toAmount = toAmount;
			this.commissionPercentage = commissionPercentage;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Employee_ID value.
		/// </summary>
		public string Employee_ID {
			get { return employee_ID; }
			set { employee_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SlabID value.
		/// </summary>
		public int SlabID {
			get { return slabID; }
			set { slabID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FromAmount value.
		/// </summary>
		public decimal FromAmount {
			get { return fromAmount; }
			set { fromAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ToAmount value.
		/// </summary>
		public decimal ToAmount {
			get { return toAmount; }
			set { toAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the CommissionPercentage value.
		/// </summary>
		public decimal CommissionPercentage {
			get { return commissionPercentage; }
			set { commissionPercentage = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zEmployeeSlabSettings table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmployeeSlabSettingsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@slabID", SqlDbType.Int,4);
			scom.Parameters.Add("@fromAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@toAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@commissionPercentage", SqlDbType.Decimal,9);
 
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@slabID"].Value = slabID;
			scom.Parameters["@fromAmount"].Value = fromAmount;
			scom.Parameters["@toAmount"].Value = toAmount;
			scom.Parameters["@commissionPercentage"].Value = commissionPercentage;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zEmployeeSlabSettings table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmployeeSlabSettingsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@slabID", SqlDbType.Int,4);
			scom.Parameters.Add("@fromAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@toAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@commissionPercentage", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@employee_ID"].Value = employee_ID;
			scom.Parameters["@slabID"].Value = slabID;
			scom.Parameters["@fromAmount"].Value = fromAmount;
			scom.Parameters["@toAmount"].Value = toAmount;
			scom.Parameters["@commissionPercentage"].Value = commissionPercentage;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zEmployeeSlabSettings table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmployeeSlabSettingsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@slabID", SqlDbType.Int,4);
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scom.Parameters["@slabID"].Value = slabID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zEmployeeSlabSettings table by a foreign key.
		/// </summary>
		public static void DeleteAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmployeeSlabSettingsDeleteAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zEmployeeSlabSettings table.
		/// </summary>
		public static tbl_zEmployeeSlabSettings Select(string employee_ID_Incoming, int slabID_Incoming){

			tbl_zEmployeeSlabSettings tbl_zEmployeeSlabSettingsins = new tbl_zEmployeeSlabSettings();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmployeeSlabSettingsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@slabID", SqlDbType.Int,4);
			scom.Parameters["@employee_ID"].Value = employee_ID_Incoming;
			scom.Parameters["@slabID"].Value = slabID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zEmployeeSlabSettingsins = Maketbl_zEmployeeSlabSettings(dataReader);
				} else {
					tbl_zEmployeeSlabSettingsins = null;
				}
			}
			scon.Close();
			return tbl_zEmployeeSlabSettingsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zEmployeeSlabSettings table.
		/// </summary>
		public static List<tbl_zEmployeeSlabSettings> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmployeeSlabSettingsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zEmployeeSlabSettings> tbl_zEmployeeSlabSettingsList = new List<tbl_zEmployeeSlabSettings>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zEmployeeSlabSettings tbl_zEmployeeSlabSettings = Maketbl_zEmployeeSlabSettings(dataReader);
					tbl_zEmployeeSlabSettingsList.Add(tbl_zEmployeeSlabSettings);
				}
			}
			scon.Close();
			return tbl_zEmployeeSlabSettingsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zEmployeeSlabSettings table by a foreign key.
		/// </summary>
		public static List<tbl_zEmployeeSlabSettings> SelectAllByEmployee_ID(string employee_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zEmployeeSlabSettingsSelectAllByEmployee_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@employee_ID", SqlDbType.VarChar,20);
			scom.Parameters["@employee_ID"].Value = employee_ID;
				List<tbl_zEmployeeSlabSettings> tbl_zEmployeeSlabSettingsList = new List<tbl_zEmployeeSlabSettings>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zEmployeeSlabSettings tbl_zEmployeeSlabSettings = Maketbl_zEmployeeSlabSettings(dataReader);
					tbl_zEmployeeSlabSettingsList.Add(tbl_zEmployeeSlabSettings);
				}
			}
			scon.Close();
			return tbl_zEmployeeSlabSettingsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zEmployeeSlabSettings class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zEmployeeSlabSettings Maketbl_zEmployeeSlabSettings(SqlDataReader dataReader) {
			tbl_zEmployeeSlabSettings tbl_zEmployeeSlabSettings = new tbl_zEmployeeSlabSettings();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zEmployeeSlabSettings.Employee_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zEmployeeSlabSettings.SlabID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zEmployeeSlabSettings.FromAmount = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zEmployeeSlabSettings.ToAmount = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zEmployeeSlabSettings.CommissionPercentage = dataReader.GetDecimal(4);
			}

			return tbl_zEmployeeSlabSettings;
		}
		/// <summary>
		/// This makes tbl_zEmployeeSlabSettings datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zEmployeeSlabSettings object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zEmployeeSlabSettings  tbl_zEmployeeSlabSettings   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_employee_ID = new DataColumn("employee_ID" , typeof(string));
			DataColumn col_slabID = new DataColumn("slabID" , typeof(int));
			DataColumn col_fromAmount = new DataColumn("fromAmount" , typeof(decimal));
			DataColumn col_toAmount = new DataColumn("toAmount" , typeof(decimal));
			DataColumn col_commissionPercentage = new DataColumn("commissionPercentage" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_employee_ID,col_slabID,col_fromAmount,col_toAmount,col_commissionPercentage,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zEmployeeSlabSettings datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zEmployeeSlabSettings object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zEmployeeSlabSettings user) {
		DataRow drow = dt.NewRow();
		
			drow["employee_ID"] = user.employee_ID;
			drow["slabID"] = user.slabID;
			drow["fromAmount"] = user.fromAmount;
			drow["toAmount"] = user.toAmount;
			drow["commissionPercentage"] = user.commissionPercentage;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
