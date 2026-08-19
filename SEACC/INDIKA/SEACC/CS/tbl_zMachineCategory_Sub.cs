using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zMachineCategory_Sub {
		#region Fields
		private string machineCategorySub_ID;
		private string machineCategory_ID;
		private string categorySubName;
		private string prefrix;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zMachineCategory_Sub class.
		/// </summary>
		public tbl_zMachineCategory_Sub() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zMachineCategory_Sub class.
		/// </summary>
		public tbl_zMachineCategory_Sub(string machineCategorySub_ID, string machineCategory_ID, string categorySubName, string prefrix) {
			this.machineCategorySub_ID = machineCategorySub_ID;
			this.machineCategory_ID = machineCategory_ID;
			this.categorySubName = categorySubName;
			this.prefrix = prefrix;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the MachineCategorySub_ID value.
		/// </summary>
		public string MachineCategorySub_ID {
			get { return machineCategorySub_ID; }
			set { machineCategorySub_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the MachineCategory_ID value.
		/// </summary>
		public string MachineCategory_ID {
			get { return machineCategory_ID; }
			set { machineCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CategorySubName value.
		/// </summary>
		public string CategorySubName {
			get { return categorySubName; }
			set { categorySubName = value; }
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
		/// Saves a record to the tbl_zMachineCategory_Sub table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategory_SubInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@machineCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@categorySubName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefrix", SqlDbType.VarChar,10);
 
			scom.Parameters["@machineCategorySub_ID"].Value = machineCategorySub_ID;
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID;
			scom.Parameters["@categorySubName"].Value = categorySubName;
			scom.Parameters["@prefrix"].Value = prefrix;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zMachineCategory_Sub table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategory_SubUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@machineCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@categorySubName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefrix", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@machineCategorySub_ID"].Value = machineCategorySub_ID;
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID;
			scom.Parameters["@categorySubName"].Value = categorySubName;
			scom.Parameters["@prefrix"].Value = prefrix;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zMachineCategory_Sub table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategory_SubDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@machineCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineCategorySub_ID"].Value = machineCategorySub_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMachineCategory_Sub table by a foreign key.
		/// </summary>
		public static void DeleteAllByMachineCategory_ID(string machineCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategory_SubDeleteAllByMachineCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zMachineCategory_Sub table.
		/// </summary>
		public static tbl_zMachineCategory_Sub Select(string machineCategorySub_ID_Incoming){

			tbl_zMachineCategory_Sub tbl_zMachineCategory_Subins = new tbl_zMachineCategory_Sub();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategory_SubSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineCategorySub_ID"].Value = machineCategorySub_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zMachineCategory_Subins = Maketbl_zMachineCategory_Sub(dataReader);
				} else {
					tbl_zMachineCategory_Subins = null;
				}
			}
			scon.Close();
			return tbl_zMachineCategory_Subins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMachineCategory_Sub table.
		/// </summary>
		public static List<tbl_zMachineCategory_Sub> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategory_SubSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zMachineCategory_Sub> tbl_zMachineCategory_SubList = new List<tbl_zMachineCategory_Sub>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zMachineCategory_Sub tbl_zMachineCategory_Sub = Maketbl_zMachineCategory_Sub(dataReader);
					tbl_zMachineCategory_SubList.Add(tbl_zMachineCategory_Sub);
				}
			}
			scon.Close();
			return tbl_zMachineCategory_SubList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMachineCategory_Sub table by a foreign key.
		/// </summary>
		public static List<tbl_zMachineCategory_Sub> SelectAllByMachineCategory_ID(string machineCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineCategory_SubSelectAllByMachineCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineCategory_ID"].Value = machineCategory_ID;
				List<tbl_zMachineCategory_Sub> tbl_zMachineCategory_SubList = new List<tbl_zMachineCategory_Sub>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zMachineCategory_Sub tbl_zMachineCategory_Sub = Maketbl_zMachineCategory_Sub(dataReader);
					tbl_zMachineCategory_SubList.Add(tbl_zMachineCategory_Sub);
				}
			}
			scon.Close();
			return tbl_zMachineCategory_SubList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zMachineCategory_Sub class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zMachineCategory_Sub Maketbl_zMachineCategory_Sub(SqlDataReader dataReader) {
			tbl_zMachineCategory_Sub tbl_zMachineCategory_Sub = new tbl_zMachineCategory_Sub();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zMachineCategory_Sub.MachineCategorySub_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zMachineCategory_Sub.MachineCategory_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zMachineCategory_Sub.CategorySubName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zMachineCategory_Sub.Prefrix = dataReader.GetString(3);
			}

			return tbl_zMachineCategory_Sub;
		}
		/// <summary>
		/// This makes tbl_zMachineCategory_Sub datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zMachineCategory_Sub object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zMachineCategory_Sub  tbl_zMachineCategory_Sub   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_machineCategorySub_ID = new DataColumn("machineCategorySub_ID" , typeof(string));
			DataColumn col_machineCategory_ID = new DataColumn("machineCategory_ID" , typeof(string));
			DataColumn col_categorySubName = new DataColumn("categorySubName" , typeof(string));
			DataColumn col_prefrix = new DataColumn("prefrix" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_machineCategorySub_ID,col_machineCategory_ID,col_categorySubName,col_prefrix,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zMachineCategory_Sub datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zMachineCategory_Sub object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zMachineCategory_Sub user) {
		DataRow drow = dt.NewRow();
		
			drow["machineCategorySub_ID"] = user.machineCategorySub_ID;
			drow["machineCategory_ID"] = user.machineCategory_ID;
			drow["categorySubName"] = user.categorySubName;
			drow["prefrix"] = user.prefrix;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
