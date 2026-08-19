using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zCustomerClass {
		#region Fields
		private string customerClass_ID;
		private string className;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zCustomerClass class.
		/// </summary>
		public tbl_zCustomerClass() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zCustomerClass class.
		/// </summary>
		public tbl_zCustomerClass(string customerClass_ID, string className) {
			this.customerClass_ID = customerClass_ID;
			this.className = className;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CustomerClass_ID value.
		/// </summary>
		public string CustomerClass_ID {
			get { return customerClass_ID; }
			set { customerClass_ID = value; }
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
		/// Saves a record to the tbl_zCustomerClass table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCustomerClassInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customerClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@className", SqlDbType.VarChar,50);
 
			scom.Parameters["@customerClass_ID"].Value = customerClass_ID;
			scom.Parameters["@className"].Value = className;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zCustomerClass table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCustomerClassUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customerClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@className", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@customerClass_ID"].Value = customerClass_ID;
			scom.Parameters["@className"].Value = className;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zCustomerClass table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCustomerClassDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@customerClass_ID", SqlDbType.VarChar,10);
			scom.Parameters["@customerClass_ID"].Value = customerClass_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zCustomerClass table.
		/// </summary>
		public static tbl_zCustomerClass Select(string customerClass_ID_Incoming){

			tbl_zCustomerClass tbl_zCustomerClassins = new tbl_zCustomerClass();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCustomerClassSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerClass_ID", SqlDbType.VarChar,10);
			scom.Parameters["@customerClass_ID"].Value = customerClass_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zCustomerClassins = Maketbl_zCustomerClass(dataReader);
				} else {
					tbl_zCustomerClassins = null;
				}
			}
			scon.Close();
			return tbl_zCustomerClassins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zCustomerClass table.
		/// </summary>
		public static List<tbl_zCustomerClass> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCustomerClassSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zCustomerClass> tbl_zCustomerClassList = new List<tbl_zCustomerClass>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zCustomerClass tbl_zCustomerClass = Maketbl_zCustomerClass(dataReader);
					tbl_zCustomerClassList.Add(tbl_zCustomerClass);
				}
			}
			scon.Close();
			return tbl_zCustomerClassList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zCustomerClass class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zCustomerClass Maketbl_zCustomerClass(SqlDataReader dataReader) {
			tbl_zCustomerClass tbl_zCustomerClass = new tbl_zCustomerClass();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zCustomerClass.CustomerClass_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zCustomerClass.ClassName = dataReader.GetString(1);
			}

			return tbl_zCustomerClass;
		}
		/// <summary>
		/// This fills tbl_zCustomerClass datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zCustomerClass object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zCustomerClass user) {
		DataRow drow = dt.NewRow();
		
			drow["customerClass_ID"] = user.customerClass_ID;
			drow["className"] = user.className;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
