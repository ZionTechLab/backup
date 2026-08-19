using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ZEmpSalesManager {
		#region Fields
		private string salesManager_ID;
		private string salesManagerName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ZEmpSalesManager class.
		/// </summary>
		public tbl_ZEmpSalesManager() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ZEmpSalesManager class.
		/// </summary>
		public tbl_ZEmpSalesManager(string salesManager_ID, string salesManagerName) {
			this.salesManager_ID = salesManager_ID;
			this.salesManagerName = salesManagerName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SalesManager_ID value.
		/// </summary>
		public string SalesManager_ID {
			get { return salesManager_ID; }
			set { salesManager_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesManagerName value.
		/// </summary>
		public string SalesManagerName {
			get { return salesManagerName; }
			set { salesManagerName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ZEmpSalesManager table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesManagerInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesManagerName", SqlDbType.VarChar,50);
 
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
			scom.Parameters["@salesManagerName"].Value = salesManagerName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ZEmpSalesManager table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesManagerUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesManagerName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
			scom.Parameters["@salesManagerName"].Value = salesManagerName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ZEmpSalesManager table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesManagerDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ZEmpSalesManager table by a foreign key.
		/// </summary>
		public static void DeleteAllBySalesManager_ID(string salesManager_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesManagerDeleteAllBySalesManager_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ZEmpSalesManager table.
		/// </summary>
		public static tbl_ZEmpSalesManager Select(string salesManager_ID_Incoming){

			tbl_ZEmpSalesManager tbl_ZEmpSalesManagerins = new tbl_ZEmpSalesManager();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesManagerSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ZEmpSalesManagerins = Maketbl_ZEmpSalesManager(dataReader);
				} else {
					tbl_ZEmpSalesManagerins = null;
				}
			}
			scon.Close();
			return tbl_ZEmpSalesManagerins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ZEmpSalesManager table.
		/// </summary>
		public static List<tbl_ZEmpSalesManager> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesManagerSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ZEmpSalesManager> tbl_ZEmpSalesManagerList = new List<tbl_ZEmpSalesManager>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ZEmpSalesManager tbl_ZEmpSalesManager = Maketbl_ZEmpSalesManager(dataReader);
					tbl_ZEmpSalesManagerList.Add(tbl_ZEmpSalesManager);
				}
			}
			scon.Close();
			return tbl_ZEmpSalesManagerList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ZEmpSalesManager table by a foreign key.
		/// </summary>
		public static List<tbl_ZEmpSalesManager> SelectAllBySalesManager_ID(string salesManager_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesManagerSelectAllBySalesManager_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesManager_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesManager_ID"].Value = salesManager_ID;
				List<tbl_ZEmpSalesManager> tbl_ZEmpSalesManagerList = new List<tbl_ZEmpSalesManager>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ZEmpSalesManager tbl_ZEmpSalesManager = Maketbl_ZEmpSalesManager(dataReader);
					tbl_ZEmpSalesManagerList.Add(tbl_ZEmpSalesManager);
				}
			}
			scon.Close();
			return tbl_ZEmpSalesManagerList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ZEmpSalesManager class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ZEmpSalesManager Maketbl_ZEmpSalesManager(SqlDataReader dataReader) {
			tbl_ZEmpSalesManager tbl_ZEmpSalesManager = new tbl_ZEmpSalesManager();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ZEmpSalesManager.SalesManager_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ZEmpSalesManager.SalesManagerName = dataReader.GetString(1);
			}

			return tbl_ZEmpSalesManager;
		}
		/// <summary>
		/// This makes tbl_ZEmpSalesManager datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ZEmpSalesManager object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ZEmpSalesManager  tbl_ZEmpSalesManager   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_salesManager_ID = new DataColumn("salesManager_ID" , typeof(string));
			DataColumn col_salesManagerName = new DataColumn("salesManagerName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_salesManager_ID,col_salesManagerName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ZEmpSalesManager datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ZEmpSalesManager object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ZEmpSalesManager user) {
		DataRow drow = dt.NewRow();
		
			drow["salesManager_ID"] = user.salesManager_ID;
			drow["salesManagerName"] = user.salesManagerName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
