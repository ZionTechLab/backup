using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zSupplierClass {
		#region Fields
		private string supplierClass_ID;
		private string className;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zSupplierClass class.
		/// </summary>
		public tbl_zSupplierClass() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zSupplierClass class.
		/// </summary>
		public tbl_zSupplierClass(string supplierClass_ID, string className) {
			this.supplierClass_ID = supplierClass_ID;
			this.className = className;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SupplierClass_ID value.
		/// </summary>
		public string SupplierClass_ID {
			get { return supplierClass_ID; }
			set { supplierClass_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ClassName value.
		/// </summary>
		public string ClassName {
			get { return className; }
			set { className = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zSupplierClass table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSupplierClassInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@supplierClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@ClassName", SqlDbType.VarChar,50);
 
			scom.Parameters["@supplierClass_ID"].Value = supplierClass_ID;
			scom.Parameters["@ClassName"].Value = className;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zSupplierClass table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSupplierClassUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@supplierClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@ClassName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@supplierClass_ID"].Value = supplierClass_ID;
			scom.Parameters["@ClassName"].Value = className;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zSupplierClass table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSupplierClassDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@supplierClass_ID", SqlDbType.VarChar,10);
			scom.Parameters["@supplierClass_ID"].Value = supplierClass_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zSupplierClass table.
		/// </summary>
		public static tbl_zSupplierClass Select(string supplierClass_ID_Incoming){

			tbl_zSupplierClass tbl_zSupplierClassins = new tbl_zSupplierClass();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSupplierClassSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplierClass_ID", SqlDbType.VarChar,10);
			scom.Parameters["@supplierClass_ID"].Value = supplierClass_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zSupplierClassins = Maketbl_zSupplierClass(dataReader);
				} else {
					tbl_zSupplierClassins = null;
				}
			}
			scon.Close();
			return tbl_zSupplierClassins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zSupplierClass table.
		/// </summary>
		public static List<tbl_zSupplierClass> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zSupplierClassSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zSupplierClass> tbl_zSupplierClassList = new List<tbl_zSupplierClass>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zSupplierClass tbl_zSupplierClass = Maketbl_zSupplierClass(dataReader);
					tbl_zSupplierClassList.Add(tbl_zSupplierClass);
				}
			}
			scon.Close();
			return tbl_zSupplierClassList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zSupplierClass class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zSupplierClass Maketbl_zSupplierClass(SqlDataReader dataReader) {
			tbl_zSupplierClass tbl_zSupplierClass = new tbl_zSupplierClass();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zSupplierClass.SupplierClass_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zSupplierClass.ClassName = dataReader.GetString(1);
			}

			return tbl_zSupplierClass;
		}
		/// <summary>
		/// This fills tbl_zSupplierClass datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zSupplierClass object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zSupplierClass user) {
		DataRow drow = dt.NewRow();
		
			drow["supplierClass_ID"] = user.supplierClass_ID;
			drow["ClassName"] = user.ClassName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
