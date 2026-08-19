using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaMasCostCenter {
		#region Fields
		private string cost_Center_ID;
		private string description;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaMasCostCenter class.
		/// </summary>
		public tbl_prod_pharmaMasCostCenter() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaMasCostCenter class.
		/// </summary>
		public tbl_prod_pharmaMasCostCenter(string cost_Center_ID, string description) {
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
		/// Saves a record to the tbl_prod_pharmaMasCostCenter table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasCostCenterInsert", scon);
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
		/// Updates a record in the tbl_prod_pharmaMasCostCenter table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasCostCenterUpdate", scon);
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
		/// Deletes a record from the tbl_prod_pharmaMasCostCenter table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasCostCenterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,20);
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_pharmaMasCostCenter table.
		/// </summary>
		public static tbl_prod_pharmaMasCostCenter Select(string cost_Center_ID_Incoming){

			tbl_prod_pharmaMasCostCenter tbl_prod_pharmaMasCostCenterins = new tbl_prod_pharmaMasCostCenter();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasCostCenterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@cost_Center_ID", SqlDbType.VarChar,20);
			scom.Parameters["@cost_Center_ID"].Value = cost_Center_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_pharmaMasCostCenterins = Maketbl_prod_pharmaMasCostCenter(dataReader);
				} else {
					tbl_prod_pharmaMasCostCenterins = null;
				}
			}
			scon.Close();
			return tbl_prod_pharmaMasCostCenterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaMasCostCenter table.
		/// </summary>
		public static List<tbl_prod_pharmaMasCostCenter> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaMasCostCenterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_pharmaMasCostCenter> tbl_prod_pharmaMasCostCenterList = new List<tbl_prod_pharmaMasCostCenter>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaMasCostCenter tbl_prod_pharmaMasCostCenter = Maketbl_prod_pharmaMasCostCenter(dataReader);
					tbl_prod_pharmaMasCostCenterList.Add(tbl_prod_pharmaMasCostCenter);
				}
			}
			scon.Close();
			return tbl_prod_pharmaMasCostCenterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaMasCostCenter class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaMasCostCenter Maketbl_prod_pharmaMasCostCenter(SqlDataReader dataReader) {
			tbl_prod_pharmaMasCostCenter tbl_prod_pharmaMasCostCenter = new tbl_prod_pharmaMasCostCenter();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaMasCostCenter.Cost_Center_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaMasCostCenter.Description = dataReader.GetString(1);
			}

			return tbl_prod_pharmaMasCostCenter;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaMasCostCenter datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaMasCostCenter object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaMasCostCenter  tbl_prod_pharmaMasCostCenter   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_cost_Center_ID = new DataColumn("cost_Center_ID" , typeof(string));
			DataColumn col_description = new DataColumn("description" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_cost_Center_ID,col_description,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaMasCostCenter datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaMasCostCenter object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaMasCostCenter user) {
		DataRow drow = dt.NewRow();
		
			drow["cost_Center_ID"] = user.cost_Center_ID;
			drow["description"] = user.description;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
