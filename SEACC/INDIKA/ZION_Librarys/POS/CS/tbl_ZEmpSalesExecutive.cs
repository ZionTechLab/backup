using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ZEmpSalesExecutive {
		#region Fields
		private string salesExecutive_ID;
		private string salesExecutiveName;
		private string areaManager_ID;
		private bool isDelete;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ZEmpSalesExecutive class.
		/// </summary>
		public tbl_ZEmpSalesExecutive() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ZEmpSalesExecutive class.
		/// </summary>
		public tbl_ZEmpSalesExecutive(string salesExecutive_ID, string salesExecutiveName, string areaManager_ID, bool isDelete) {
			this.salesExecutive_ID = salesExecutive_ID;
			this.salesExecutiveName = salesExecutiveName;
			this.areaManager_ID = areaManager_ID;
			this.isDelete = isDelete;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SalesExecutive_ID value.
		/// </summary>
		public string SalesExecutive_ID {
			get { return salesExecutive_ID; }
			set { salesExecutive_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SalesExecutiveName value.
		/// </summary>
		public string SalesExecutiveName {
			get { return salesExecutiveName; }
			set { salesExecutiveName = value; }
		}
		
		/// <summary>
		/// Gets or sets the AreaManager_ID value.
		/// </summary>
		public string AreaManager_ID {
			get { return areaManager_ID; }
			set { areaManager_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDelete value.
		/// </summary>
		public bool IsDelete {
			get { return isDelete; }
			set { isDelete = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ZEmpSalesExecutive table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesExecutiveInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@salesExecutive_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesExecutiveName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isDelete", SqlDbType.Bit,1);
 
			scom.Parameters["@salesExecutive_ID"].Value = salesExecutive_ID;
			scom.Parameters["@salesExecutiveName"].Value = salesExecutiveName;
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
			scom.Parameters["@isDelete"].Value = isDelete;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ZEmpSalesExecutive table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesExecutiveUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@salesExecutive_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@salesExecutiveName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isDelete", SqlDbType.Bit,1);
 
 
			scom.Parameters["@salesExecutive_ID"].Value = salesExecutive_ID;
			scom.Parameters["@salesExecutiveName"].Value = salesExecutiveName;
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
			scom.Parameters["@isDelete"].Value = isDelete;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ZEmpSalesExecutive table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesExecutiveDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@salesExecutive_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesExecutive_ID"].Value = salesExecutive_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ZEmpSalesExecutive table by a foreign key.
		/// </summary>
		public static void DeleteAllBySalesExecutive_ID(string salesExecutive_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesExecutiveDeleteAllBySalesExecutive_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesExecutive_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesExecutive_ID"].Value = salesExecutive_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ZEmpSalesExecutive table by a foreign key.
		/// </summary>
		public static void DeleteAllByAreaManager_ID(string areaManager_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesExecutiveDeleteAllByAreaManager_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ZEmpSalesExecutive table.
		/// </summary>
		public static tbl_ZEmpSalesExecutive Select(string salesExecutive_ID_Incoming){

			tbl_ZEmpSalesExecutive tbl_ZEmpSalesExecutiveins = new tbl_ZEmpSalesExecutive();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesExecutiveSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesExecutive_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesExecutive_ID"].Value = salesExecutive_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ZEmpSalesExecutiveins = Maketbl_ZEmpSalesExecutive(dataReader);
				} else {
					tbl_ZEmpSalesExecutiveins = null;
				}
			}
			scon.Close();
			return tbl_ZEmpSalesExecutiveins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ZEmpSalesExecutive table.
		/// </summary>
		public static List<tbl_ZEmpSalesExecutive> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesExecutiveSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ZEmpSalesExecutive> tbl_ZEmpSalesExecutiveList = new List<tbl_ZEmpSalesExecutive>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ZEmpSalesExecutive tbl_ZEmpSalesExecutive = Maketbl_ZEmpSalesExecutive(dataReader);
					tbl_ZEmpSalesExecutiveList.Add(tbl_ZEmpSalesExecutive);
				}
			}
			scon.Close();
			return tbl_ZEmpSalesExecutiveList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ZEmpSalesExecutive table by a foreign key.
		/// </summary>
		public static List<tbl_ZEmpSalesExecutive> SelectAllBySalesExecutive_ID(string salesExecutive_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesExecutiveSelectAllBySalesExecutive_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@salesExecutive_ID", SqlDbType.VarChar,20);
			scom.Parameters["@salesExecutive_ID"].Value = salesExecutive_ID;
				List<tbl_ZEmpSalesExecutive> tbl_ZEmpSalesExecutiveList = new List<tbl_ZEmpSalesExecutive>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ZEmpSalesExecutive tbl_ZEmpSalesExecutive = Maketbl_ZEmpSalesExecutive(dataReader);
					tbl_ZEmpSalesExecutiveList.Add(tbl_ZEmpSalesExecutive);
				}
			}
			scon.Close();
			return tbl_ZEmpSalesExecutiveList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ZEmpSalesExecutive table by a foreign key.
		/// </summary>
		public static List<tbl_ZEmpSalesExecutive> SelectAllByAreaManager_ID(string areaManager_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ZEmpSalesExecutiveSelectAllByAreaManager_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@areaManager_ID", SqlDbType.VarChar,20);
			scom.Parameters["@areaManager_ID"].Value = areaManager_ID;
				List<tbl_ZEmpSalesExecutive> tbl_ZEmpSalesExecutiveList = new List<tbl_ZEmpSalesExecutive>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ZEmpSalesExecutive tbl_ZEmpSalesExecutive = Maketbl_ZEmpSalesExecutive(dataReader);
					tbl_ZEmpSalesExecutiveList.Add(tbl_ZEmpSalesExecutive);
				}
			}
			scon.Close();
			return tbl_ZEmpSalesExecutiveList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ZEmpSalesExecutive class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ZEmpSalesExecutive Maketbl_ZEmpSalesExecutive(SqlDataReader dataReader) {
			tbl_ZEmpSalesExecutive tbl_ZEmpSalesExecutive = new tbl_ZEmpSalesExecutive();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ZEmpSalesExecutive.SalesExecutive_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ZEmpSalesExecutive.SalesExecutiveName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ZEmpSalesExecutive.AreaManager_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ZEmpSalesExecutive.IsDelete = dataReader.GetBoolean(3);
			}

			return tbl_ZEmpSalesExecutive;
		}
		/// <summary>
		/// This makes tbl_ZEmpSalesExecutive datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ZEmpSalesExecutive object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ZEmpSalesExecutive  tbl_ZEmpSalesExecutive   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_salesExecutive_ID = new DataColumn("salesExecutive_ID" , typeof(string));
			DataColumn col_salesExecutiveName = new DataColumn("salesExecutiveName" , typeof(string));
			DataColumn col_areaManager_ID = new DataColumn("areaManager_ID" , typeof(string));
			DataColumn col_isDelete = new DataColumn("isDelete" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_salesExecutive_ID,col_salesExecutiveName,col_areaManager_ID,col_isDelete,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ZEmpSalesExecutive datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ZEmpSalesExecutive object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ZEmpSalesExecutive user) {
		DataRow drow = dt.NewRow();
		
			drow["salesExecutive_ID"] = user.salesExecutive_ID;
			drow["salesExecutiveName"] = user.salesExecutiveName;
			drow["areaManager_ID"] = user.areaManager_ID;
			drow["isDelete"] = user.isDelete;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
