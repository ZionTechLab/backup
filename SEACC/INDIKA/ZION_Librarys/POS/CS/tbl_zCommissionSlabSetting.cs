using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zCommissionSlabSetting {
		#region Fields
		private string slabID;
		private string slabName;
		private decimal dateRange;
		private decimal commissionPercentage;
		private bool isDeleted;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zCommissionSlabSetting class.
		/// </summary>
		public tbl_zCommissionSlabSetting() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zCommissionSlabSetting class.
		/// </summary>
		public tbl_zCommissionSlabSetting(string slabID, string slabName, decimal dateRange, decimal commissionPercentage, bool isDeleted) {
			this.slabID = slabID;
			this.slabName = slabName;
			this.dateRange = dateRange;
			this.commissionPercentage = commissionPercentage;
			this.isDeleted = isDeleted;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SlabID value.
		/// </summary>
		public string SlabID {
			get { return slabID; }
			set { slabID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SlabName value.
		/// </summary>
		public string SlabName {
			get { return slabName; }
			set { slabName = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateRange value.
		/// </summary>
		public decimal DateRange {
			get { return dateRange; }
			set { dateRange = value; }
		}
		
		/// <summary>
		/// Gets or sets the CommissionPercentage value.
		/// </summary>
		public decimal CommissionPercentage {
			get { return commissionPercentage; }
			set { commissionPercentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zCommissionSlabSetting table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCommissionSlabSettingInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@slabID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@slabName", SqlDbType.VarChar,500);
			scom.Parameters.Add("@dateRange", SqlDbType.Decimal,9);
			scom.Parameters.Add("@commissionPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
			scom.Parameters["@slabID"].Value = slabID;
			scom.Parameters["@slabName"].Value = slabName;
			scom.Parameters["@dateRange"].Value = dateRange;
			scom.Parameters["@commissionPercentage"].Value = commissionPercentage;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zCommissionSlabSetting table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCommissionSlabSettingUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@slabID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@slabName", SqlDbType.VarChar,500);
			scom.Parameters.Add("@dateRange", SqlDbType.Decimal,9);
			scom.Parameters.Add("@commissionPercentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
 
 
			scom.Parameters["@slabID"].Value = slabID;
			scom.Parameters["@slabName"].Value = slabName;
			scom.Parameters["@dateRange"].Value = dateRange;
			scom.Parameters["@commissionPercentage"].Value = commissionPercentage;
			scom.Parameters["@isDeleted"].Value = isDeleted;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zCommissionSlabSetting table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCommissionSlabSettingDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@slabID", SqlDbType.VarChar,20);
			scom.Parameters["@slabID"].Value = slabID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zCommissionSlabSetting table.
		/// </summary>
		public static tbl_zCommissionSlabSetting Select(string slabID_Incoming){

			tbl_zCommissionSlabSetting tbl_zCommissionSlabSettingins = new tbl_zCommissionSlabSetting();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCommissionSlabSettingSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@slabID", SqlDbType.VarChar,20);
			scom.Parameters["@slabID"].Value = slabID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zCommissionSlabSettingins = Maketbl_zCommissionSlabSetting(dataReader);
				} else {
					tbl_zCommissionSlabSettingins = null;
				}
			}
			scon.Close();
			return tbl_zCommissionSlabSettingins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zCommissionSlabSetting table.
		/// </summary>
		public static List<tbl_zCommissionSlabSetting> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCommissionSlabSettingSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zCommissionSlabSetting> tbl_zCommissionSlabSettingList = new List<tbl_zCommissionSlabSetting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zCommissionSlabSetting tbl_zCommissionSlabSetting = Maketbl_zCommissionSlabSetting(dataReader);
					tbl_zCommissionSlabSettingList.Add(tbl_zCommissionSlabSetting);
				}
			}
			scon.Close();
			return tbl_zCommissionSlabSettingList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zCommissionSlabSetting class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zCommissionSlabSetting Maketbl_zCommissionSlabSetting(SqlDataReader dataReader) {
			tbl_zCommissionSlabSetting tbl_zCommissionSlabSetting = new tbl_zCommissionSlabSetting();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zCommissionSlabSetting.SlabID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zCommissionSlabSetting.SlabName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zCommissionSlabSetting.DateRange = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zCommissionSlabSetting.CommissionPercentage = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zCommissionSlabSetting.IsDeleted = dataReader.GetBoolean(4);
			}

			return tbl_zCommissionSlabSetting;
		}
		/// <summary>
		/// This makes tbl_zCommissionSlabSetting datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zCommissionSlabSetting object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zCommissionSlabSetting  tbl_zCommissionSlabSetting   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_slabID = new DataColumn("slabID" , typeof(string));
			DataColumn col_slabName = new DataColumn("slabName" , typeof(string));
			DataColumn col_dateRange = new DataColumn("dateRange" , typeof(decimal));
			DataColumn col_commissionPercentage = new DataColumn("commissionPercentage" , typeof(decimal));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_slabID,col_slabName,col_dateRange,col_commissionPercentage,col_isDeleted,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zCommissionSlabSetting datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zCommissionSlabSetting object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zCommissionSlabSetting user) {
		DataRow drow = dt.NewRow();
		
			drow["slabID"] = user.slabID;
			drow["slabName"] = user.slabName;
			drow["dateRange"] = user.dateRange;
			drow["commissionPercentage"] = user.commissionPercentage;
			drow["isDeleted"] = user.isDeleted;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
