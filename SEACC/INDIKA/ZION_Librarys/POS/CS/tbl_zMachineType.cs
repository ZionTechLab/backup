using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zMachineType {
		#region Fields
		private string machineType_ID;
		private string typeName;
		private string machineClass_ID;
		private string prefrix;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zMachineType class.
		/// </summary>
		public tbl_zMachineType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zMachineType class.
		/// </summary>
		public tbl_zMachineType(string machineType_ID, string typeName, string machineClass_ID, string prefrix) {
			this.machineType_ID = machineType_ID;
			this.typeName = typeName;
			this.machineClass_ID = machineClass_ID;
			this.prefrix = prefrix;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the MachineType_ID value.
		/// </summary>
		public string MachineType_ID {
			get { return machineType_ID; }
			set { machineType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TypeName value.
		/// </summary>
		public string TypeName {
			get { return typeName; }
			set { typeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the MachineClass_ID value.
		/// </summary>
		public string MachineClass_ID {
			get { return machineClass_ID; }
			set { machineClass_ID = value; }
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
		/// Saves a record to the tbl_zMachineType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@machineType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@machineClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@prefrix", SqlDbType.VarChar,10);
 
			scom.Parameters["@machineType_ID"].Value = machineType_ID;
			scom.Parameters["@typeName"].Value = typeName;
			scom.Parameters["@machineClass_ID"].Value = machineClass_ID;
			scom.Parameters["@prefrix"].Value = prefrix;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zMachineType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@machineType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@machineClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@prefrix", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@machineType_ID"].Value = machineType_ID;
			scom.Parameters["@typeName"].Value = typeName;
			scom.Parameters["@machineClass_ID"].Value = machineClass_ID;
			scom.Parameters["@prefrix"].Value = prefrix;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zMachineType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@machineType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineType_ID"].Value = machineType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMachineType table by a foreign key.
		/// </summary>
		public static void DeleteAllByMachineClass_ID(string machineClass_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineTypeDeleteAllByMachineClass_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineClass_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineClass_ID"].Value = machineClass_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zMachineType table.
		/// </summary>
		public static tbl_zMachineType Select(string machineType_ID_Incoming){

			tbl_zMachineType tbl_zMachineTypeins = new tbl_zMachineType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineType_ID"].Value = machineType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zMachineTypeins = Maketbl_zMachineType(dataReader);
				} else {
					tbl_zMachineTypeins = null;
				}
			}
			scon.Close();
			return tbl_zMachineTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMachineType table.
		/// </summary>
		public static List<tbl_zMachineType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zMachineType> tbl_zMachineTypeList = new List<tbl_zMachineType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zMachineType tbl_zMachineType = Maketbl_zMachineType(dataReader);
					tbl_zMachineTypeList.Add(tbl_zMachineType);
				}
			}
			scon.Close();
			return tbl_zMachineTypeList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zMachineType table by a foreign key.
		/// </summary>
		public static List<tbl_zMachineType> SelectAllByMachineClass_ID(string machineClass_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zMachineTypeSelectAllByMachineClass_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@machineClass_ID", SqlDbType.VarChar,10);
			scom.Parameters["@machineClass_ID"].Value = machineClass_ID;
				List<tbl_zMachineType> tbl_zMachineTypeList = new List<tbl_zMachineType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zMachineType tbl_zMachineType = Maketbl_zMachineType(dataReader);
					tbl_zMachineTypeList.Add(tbl_zMachineType);
				}
			}
			scon.Close();
			return tbl_zMachineTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zMachineType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zMachineType Maketbl_zMachineType(SqlDataReader dataReader) {
			tbl_zMachineType tbl_zMachineType = new tbl_zMachineType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zMachineType.MachineType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zMachineType.TypeName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zMachineType.MachineClass_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zMachineType.Prefrix = dataReader.GetString(3);
			}

			return tbl_zMachineType;
		}
		/// <summary>
		/// This makes tbl_zMachineType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zMachineType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zMachineType  tbl_zMachineType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_machineType_ID = new DataColumn("machineType_ID" , typeof(string));
			DataColumn col_typeName = new DataColumn("typeName" , typeof(string));
			DataColumn col_machineClass_ID = new DataColumn("machineClass_ID" , typeof(string));
			DataColumn col_prefrix = new DataColumn("prefrix" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_machineType_ID,col_typeName,col_machineClass_ID,col_prefrix,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zMachineType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zMachineType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zMachineType user) {
		DataRow drow = dt.NewRow();
		
			drow["machineType_ID"] = user.machineType_ID;
			drow["typeName"] = user.typeName;
			drow["machineClass_ID"] = user.machineClass_ID;
			drow["prefrix"] = user.prefrix;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
