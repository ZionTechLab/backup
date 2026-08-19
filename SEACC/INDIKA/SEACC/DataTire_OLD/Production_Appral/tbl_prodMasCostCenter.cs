using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodMasCostCenter {
		#region Fields
		private string cost_Center_ID;
		private string description;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodMasCostCenter class.
		/// </summary>
		public tbl_prodMasCostCenter() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodMasCostCenter class.
		/// </summary>
		public tbl_prodMasCostCenter(string cost_Center_ID, string description) {
			this.cost_Center_ID = cost_Center_ID;
			this.description = description;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Cost_Center_ID value.
		/// </summary>
		public string Cost_Center_ID {
			get { return cost_Center_ID; }
			set { cost_Center_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description {
			get { return description; }
			set { description = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prodMasCostCenter table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodMasCostCenterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@description", SqlDbType.VarChar,200);
 
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID;
			scom.Parameters["@description"].Value = description;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodMasCostCenter table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodMasCostCenterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@description", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID;
			scom.Parameters["@description"].Value = description;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodMasCostCenter table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodMasCostCenterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,20);
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodMasCostCenter table.
		/// </summary>
		public static tbl_prodMasCostCenter Select(string cost_Center_ID_Incoming){

			tbl_prodMasCostCenter tbl_prodMasCostCenterins = new tbl_prodMasCostCenter();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodMasCostCenterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,20);
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodMasCostCenterins = Maketbl_prodMasCostCenter(dataReader);
				} else {
					tbl_prodMasCostCenterins = null;
				}
			}
			scon.Close();
			return tbl_prodMasCostCenterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodMasCostCenter table.
		/// </summary>
		public static List<tbl_prodMasCostCenter> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodMasCostCenterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodMasCostCenter> tbl_prodMasCostCenterList = new List<tbl_prodMasCostCenter>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodMasCostCenter tbl_prodMasCostCenter = Maketbl_prodMasCostCenter(dataReader);
					tbl_prodMasCostCenterList.Add(tbl_prodMasCostCenter);
				}
			}
			scon.Close();
			return tbl_prodMasCostCenterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodMasCostCenter class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodMasCostCenter Maketbl_prodMasCostCenter(SqlDataReader dataReader) {
			tbl_prodMasCostCenter tbl_prodMasCostCenter = new tbl_prodMasCostCenter();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodMasCostCenter.Cost_Center_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodMasCostCenter.Description = dataReader.GetString(1);
			}

			return tbl_prodMasCostCenter;
		}
		/// <summary>
		/// This makes tbl_prodMasCostCenter datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodMasCostCenter object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodMasCostCenter  tbl_prodMasCostCenter   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_cost_Center_ID = new DataColumn("cost_Center_ID" , typeof(string));
			DataColumn col_description = new DataColumn("description" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_cost_Center_ID,col_description,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodMasCostCenter datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodMasCostCenter object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodMasCostCenter user) {
		DataRow drow = dt.NewRow();
		
			drow["cost_Center_ID"] = user.cost_Center_ID;
			drow["description"] = user.description;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
