using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zSupplierType {
		#region Fields
		private string supplierType_ID;
		private string typeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zSupplierType class.
		/// </summary>
		public tbl_zSupplierType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zSupplierType class.
		/// </summary>
		public tbl_zSupplierType(string supplierType_ID, string typeName) {
			this.supplierType_ID = supplierType_ID;
			this.typeName = typeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SupplierType_ID value.
		/// </summary>
		public string SupplierType_ID {
			get { return supplierType_ID; }
			set { supplierType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TypeName value.
		/// </summary>
		public string TypeName {
			get { return typeName; }
			set { typeName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zSupplierType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSupplierTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@supplierType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@supplierType_ID"].Value = supplierType_ID;
			scom.Parameters["@typeName"].Value = typeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zSupplierType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSupplierTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@supplierType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@supplierType_ID"].Value = supplierType_ID;
			scom.Parameters["@typeName"].Value = typeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zSupplierType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSupplierTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@supplierType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@supplierType_ID"].Value = supplierType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zSupplierType table.
		/// </summary>
		public static tbl_zSupplierType Select(string supplierType_ID_Incoming){

			tbl_zSupplierType tbl_zSupplierTypeins = new tbl_zSupplierType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSupplierTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplierType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@supplierType_ID"].Value = supplierType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zSupplierTypeins = Maketbl_zSupplierType(dataReader);
				} else {
					tbl_zSupplierTypeins = null;
				}
			}
			scon.Close();
			return tbl_zSupplierTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zSupplierType table.
		/// </summary>
		public static List<tbl_zSupplierType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSupplierTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zSupplierType> tbl_zSupplierTypeList = new List<tbl_zSupplierType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zSupplierType tbl_zSupplierType = Maketbl_zSupplierType(dataReader);
					tbl_zSupplierTypeList.Add(tbl_zSupplierType);
				}
			}
			scon.Close();
			return tbl_zSupplierTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zSupplierType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zSupplierType Maketbl_zSupplierType(SqlDataReader dataReader) {
			tbl_zSupplierType tbl_zSupplierType = new tbl_zSupplierType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zSupplierType.SupplierType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zSupplierType.TypeName = dataReader.GetString(1);
			}

			return tbl_zSupplierType;
		}
		/// <summary>
		/// This fills tbl_zSupplierType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zSupplierType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zSupplierType user) {
		DataRow drow = dt.NewRow();
		
			drow["supplierType_ID"] = user.supplierType_ID;
			drow["typeName"] = user.typeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
