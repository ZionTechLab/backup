using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zMachineCategory {
		#region Fields
		private string machineCategory_ID;
		private string categoryName;
		private string machineType_ID;
		private string prefrix;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zMachineCategory class.
		/// </summary>
		public tbl_zMachineCategory() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zMachineCategory class.
		/// </summary>
		public tbl_zMachineCategory(string machineCategory_ID, string categoryName, string machineType_ID, string prefrix) {
			this.machineCategory_ID = machineCategory_ID;
			this.categoryName = categoryName;
			this.machineType_ID = machineType_ID;
			this.prefrix = prefrix;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the MachineCategory_ID value.
		/// </summary>
		public string MachineCategory_ID {
			get { return machineCategory_ID; }
			set { machineCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CategoryName value.
		/// </summary>
		public string CategoryName {
			get { return categoryName; }
			set { categoryName = value; }
		}
		
		/// <summary>
		/// Gets or sets the MachineType_ID value.
		/// </summary>
		public string MachineType_ID {
			get { return machineType_ID; }
			set { machineType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefrix value.
		/// </summary>
		public string Prefrix {
			get { return prefrix; }
			set { prefrix = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zMachineCategory table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@categoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@machineType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@prefrix", SqlDbType.VarChar,10);
 
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID;
			scom.Parameters["@categoryName"].Value = categoryName;
			scom.Parameters["@machineType_ID"].Value = machineType_ID;
			scom.Parameters["@prefrix"].Value = prefrix;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zMachineCategory table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@categoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@machineType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@prefrix", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID;
			scom.Parameters["@categoryName"].Value = categoryName;
			scom.Parameters["@machineType_ID"].Value = machineType_ID;
			scom.Parameters["@prefrix"].Value = prefrix;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zMachineCategory table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMachineCategory table by a foreign key.
		/// </summary>
		public static void DeleteAllByMachineType_ID(string machineType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategoryDeleteAllByMachineType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineType_ID"].Value = machineType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zMachineCategory table.
		/// </summary>
		public static tbl_zMachineCategory Select(string machineCategory_ID_Incoming){

			tbl_zMachineCategory tbl_zMachineCategoryins = new tbl_zMachineCategory();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategorySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zMachineCategoryins = Maketbl_zMachineCategory(dataReader);
				} else {
					tbl_zMachineCategoryins = null;
				}
			}
			scon.Close();
			return tbl_zMachineCategoryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMachineCategory table.
		/// </summary>
		public static List<tbl_zMachineCategory> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zMachineCategory> tbl_zMachineCategoryList = new List<tbl_zMachineCategory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zMachineCategory tbl_zMachineCategory = Maketbl_zMachineCategory(dataReader);
					tbl_zMachineCategoryList.Add(tbl_zMachineCategory);
				}
			}
			scon.Close();
			return tbl_zMachineCategoryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMachineCategory table by a foreign key.
		/// </summary>
		public static List<tbl_zMachineCategory> SelectAllByMachineType_ID(string machineType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategorySelectAllByMachineType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineType_ID"].Value = machineType_ID;
				List<tbl_zMachineCategory> tbl_zMachineCategoryList = new List<tbl_zMachineCategory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zMachineCategory tbl_zMachineCategory = Maketbl_zMachineCategory(dataReader);
					tbl_zMachineCategoryList.Add(tbl_zMachineCategory);
				}
			}
			scon.Close();
			return tbl_zMachineCategoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zMachineCategory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zMachineCategory Maketbl_zMachineCategory(SqlDataReader dataReader) {
			tbl_zMachineCategory tbl_zMachineCategory = new tbl_zMachineCategory();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zMachineCategory.MachineCategory_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zMachineCategory.CategoryName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zMachineCategory.MachineType_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zMachineCategory.Prefrix = dataReader.GetString(3);
			}

			return tbl_zMachineCategory;
		}
		/// <summary>
		/// This makes tbl_zMachineCategory datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zMachineCategory object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zMachineCategory  tbl_zMachineCategory   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_machineCategory_ID = new DataColumn("machineCategory_ID" , typeof(string));
			DataColumn col_categoryName = new DataColumn("categoryName" , typeof(string));
			DataColumn col_machineType_ID = new DataColumn("machineType_ID" , typeof(string));
			DataColumn col_prefrix = new DataColumn("prefrix" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_machineCategory_ID,col_categoryName,col_machineType_ID,col_prefrix,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zMachineCategory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zMachineCategory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zMachineCategory user) {
		DataRow drow = dt.NewRow();
		
			drow["machineCategory_ID"] = user.machineCategory_ID;
			drow["categoryName"] = user.categoryName;
			drow["machineType_ID"] = user.machineType_ID;
			drow["prefrix"] = user.prefrix;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
