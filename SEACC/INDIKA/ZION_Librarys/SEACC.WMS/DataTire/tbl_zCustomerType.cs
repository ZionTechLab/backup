using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zCustomerType {
		#region Fields
		private string customerType_ID;
		private string typeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zCustomerType class.
		/// </summary>
		public tbl_zCustomerType() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zCustomerType class.
		/// </summary>
		public tbl_zCustomerType(string customerType_ID, string typeName) {
			this.customerType_ID = customerType_ID;
			this.typeName = typeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CustomerType_ID value.
		/// </summary>
		public string CustomerType_ID {
			get { return customerType_ID; }
			set { customerType_ID = value; }
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
		/// Saves a record to the tbl_zCustomerType table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCustomerTypeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customerType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@customerType_ID"].Value = customerType_ID;
			scom.Parameters["@typeName"].Value = typeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zCustomerType table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCustomerTypeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customerType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@customerType_ID"].Value = customerType_ID;
			scom.Parameters["@typeName"].Value = typeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zCustomerType table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCustomerTypeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@customerType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@customerType_ID"].Value = customerType_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zCustomerType table.
		/// </summary>
		public static tbl_zCustomerType Select(string customerType_ID_Incoming){

			tbl_zCustomerType tbl_zCustomerTypeins = new tbl_zCustomerType();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCustomerTypeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@customerType_ID"].Value = customerType_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zCustomerTypeins = Maketbl_zCustomerType(dataReader);
				} else {
					tbl_zCustomerTypeins = null;
				}
			}
			scon.Close();
			return tbl_zCustomerTypeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zCustomerType table.
		/// </summary>
		public static List<tbl_zCustomerType> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCustomerTypeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zCustomerType> tbl_zCustomerTypeList = new List<tbl_zCustomerType>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zCustomerType tbl_zCustomerType = Maketbl_zCustomerType(dataReader);
					tbl_zCustomerTypeList.Add(tbl_zCustomerType);
				}
			}
			scon.Close();
			return tbl_zCustomerTypeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zCustomerType class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zCustomerType Maketbl_zCustomerType(SqlDataReader dataReader) {
			tbl_zCustomerType tbl_zCustomerType = new tbl_zCustomerType();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zCustomerType.CustomerType_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zCustomerType.TypeName = dataReader.GetString(1);
			}

			return tbl_zCustomerType;
		}
		/// <summary>
		/// This makes tbl_zCustomerType datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zCustomerType object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zCustomerType  tbl_zCustomerType   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_customerType_ID = new DataColumn("customerType_ID" , typeof(string));
			DataColumn col_typeName = new DataColumn("typeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_customerType_ID,col_typeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zCustomerType datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zCustomerType object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zCustomerType user) {
		DataRow drow = dt.NewRow();
		
			drow["customerType_ID"] = user.customerType_ID;
			drow["typeName"] = user.typeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
