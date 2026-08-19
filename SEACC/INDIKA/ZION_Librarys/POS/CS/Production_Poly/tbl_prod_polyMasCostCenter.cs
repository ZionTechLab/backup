using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_polyMasCostCenter {
		#region Fields
		private string cost_Center_ID;
		private string description;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_polyMasCostCenter class.
		/// </summary>
		public tbl_prod_polyMasCostCenter() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_polyMasCostCenter class.
		/// </summary>
		public tbl_prod_polyMasCostCenter(string cost_Center_ID, string description) {
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
		/// Saves a record to the tbl_prod_polyMasCostCenter table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyMasCostCenterInsert", scon);
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
		/// Updates a record in the tbl_prod_polyMasCostCenter table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyMasCostCenterUpdate", scon);
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
		/// Deletes a record from the tbl_prod_polyMasCostCenter table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyMasCostCenterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,20);
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_polyMasCostCenter table.
		/// </summary>
		public static tbl_prod_polyMasCostCenter Select(string cost_Center_ID_Incoming){

			tbl_prod_polyMasCostCenter tbl_prod_polyMasCostCenterins = new tbl_prod_polyMasCostCenter();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyMasCostCenterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,20);
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_polyMasCostCenterins = Maketbl_prod_polyMasCostCenter(dataReader);
				} else {
					tbl_prod_polyMasCostCenterins = null;
				}
			}
			scon.Close();
			return tbl_prod_polyMasCostCenterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyMasCostCenter table.
		/// </summary>
		public static List<tbl_prod_polyMasCostCenter> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyMasCostCenterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_polyMasCostCenter> tbl_prod_polyMasCostCenterList = new List<tbl_prod_polyMasCostCenter>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyMasCostCenter tbl_prod_polyMasCostCenter = Maketbl_prod_polyMasCostCenter(dataReader);
					tbl_prod_polyMasCostCenterList.Add(tbl_prod_polyMasCostCenter);
				}
			}
			scon.Close();
			return tbl_prod_polyMasCostCenterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_polyMasCostCenter class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_polyMasCostCenter Maketbl_prod_polyMasCostCenter(SqlDataReader dataReader) {
			tbl_prod_polyMasCostCenter tbl_prod_polyMasCostCenter = new tbl_prod_polyMasCostCenter();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_polyMasCostCenter.Cost_Center_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_polyMasCostCenter.Description = dataReader.GetString(1);
			}

			return tbl_prod_polyMasCostCenter;
		}
		/// <summary>
		/// This makes tbl_prod_polyMasCostCenter datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_polyMasCostCenter object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_polyMasCostCenter  tbl_prod_polyMasCostCenter   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_cost_Center_ID = new DataColumn("cost_Center_ID" , typeof(string));
			DataColumn col_description = new DataColumn("description" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_cost_Center_ID,col_description,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_polyMasCostCenter datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_polyMasCostCenter object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_polyMasCostCenter user) {
		DataRow drow = dt.NewRow();
		
			drow["cost_Center_ID"] = user.cost_Center_ID;
			drow["description"] = user.description;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
