using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zAccCostCenter {

		#region Fields
		private string costCenter_ID;
		private string costCenterName;
		private string costCenterCode;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zAccCostCenter class.
		/// </summary>
		public tbl_zAccCostCenter() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zAccCostCenter class.
		/// </summary>
		public tbl_zAccCostCenter(string costCenter_ID, string costCenterName, string costCenterCode) {
			this.costCenter_ID = costCenter_ID;
			this.costCenterName = costCenterName;
			this.costCenterCode = costCenterCode;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CostCenter_ID value.
		/// </summary>
		public string CostCenter_ID {
			get { return costCenter_ID; }
			set { costCenter_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostCenterName value.
		/// </summary>
		public string CostCenterName {
			get { return costCenterName; }
			set { costCenterName = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostCenterCode value.
		/// </summary>
		public string CostCenterCode {
			get { return costCenterCode; }
			set { costCenterCode = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zAccCostCenter table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccCostCenterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@costCenter_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costCenterName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@costCenterCode", SqlDbType.VarChar,50);
 
			scom.Parameters["@costCenter_ID"].Value = costCenter_ID;
			scom.Parameters["@costCenterName"].Value = costCenterName;
			scom.Parameters["@costCenterCode"].Value = costCenterCode;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zAccCostCenter table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccCostCenterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@costCenter_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@costCenterName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@costCenterCode", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@costCenter_ID"].Value = costCenter_ID;
			scom.Parameters["@costCenterName"].Value = costCenterName;
			scom.Parameters["@costCenterCode"].Value = costCenterCode;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zAccCostCenter table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccCostCenterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@costCenter_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter_ID"].Value = costCenter_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zAccCostCenter table.
		/// </summary>
		public static tbl_zAccCostCenter Select(string costCenter_ID_Incoming){

			tbl_zAccCostCenter tbl_zAccCostCenterins = new tbl_zAccCostCenter();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccCostCenterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costCenter_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter_ID"].Value = costCenter_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zAccCostCenterins = Maketbl_zAccCostCenter(dataReader);
				} else {
					tbl_zAccCostCenterins = null;
				}
			}
			scon.Close();
			return tbl_zAccCostCenterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zAccCostCenter table.
		/// </summary>
		public static List<tbl_zAccCostCenter> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccCostCenterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zAccCostCenter> tbl_zAccCostCenterList = new List<tbl_zAccCostCenter>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zAccCostCenter tbl_zAccCostCenter = Maketbl_zAccCostCenter(dataReader);
					tbl_zAccCostCenterList.Add(tbl_zAccCostCenter);
				}
			}
			scon.Close();
			return tbl_zAccCostCenterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zAccCostCenter class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zAccCostCenter Maketbl_zAccCostCenter(SqlDataReader dataReader) {
			tbl_zAccCostCenter tbl_zAccCostCenter = new tbl_zAccCostCenter();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zAccCostCenter.CostCenter_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zAccCostCenter.CostCenterName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zAccCostCenter.CostCenterCode = dataReader.GetString(2);
			}

			return tbl_zAccCostCenter;
		}
		/// <summary>
		/// This makes tbl_zAccCostCenter datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zAccCostCenter object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zAccCostCenter  tbl_zAccCostCenter   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_costCenter_ID = new DataColumn("costCenter_ID" , typeof(string));
			DataColumn col_costCenterName = new DataColumn("costCenterName" , typeof(string));
			DataColumn col_costCenterCode = new DataColumn("costCenterCode" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_costCenter_ID,col_costCenterName,col_costCenterCode,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zAccCostCenter datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zAccCostCenter object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zAccCostCenter user) {
		DataRow drow = dt.NewRow();
		
			drow["costCenter_ID"] = user.costCenter_ID;
			drow["costCenterName"] = user.costCenterName;
			drow["costCenterCode"] = user.costCenterCode;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
