using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accGLMaster_Customer {
		#region Fields
		private string customer_ID;
		private string gl_ID;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_Customer class.
		/// </summary>
		public tbl_accGLMaster_Customer() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_Customer class.
		/// </summary>
		public tbl_accGLMaster_Customer(string customer_ID, string gl_ID, bool isActive) {
			this.customer_ID = customer_ID;
			this.gl_ID = gl_ID;
			this.isActive = isActive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsActive value.
		/// </summary>
		public bool IsActive {
			get { return isActive; }
			set { isActive = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_accGLMaster_Customer table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CustomerInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accGLMaster_Customer table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CustomerUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accGLMaster_Customer table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CustomerDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Customer table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CustomerDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Customer table by a foreign key.
		/// </summary>
		public static void DeleteAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CustomerDeleteAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accGLMaster_Customer table.
		/// </summary>
		public static tbl_accGLMaster_Customer Select(string customer_ID_Incoming){

			tbl_accGLMaster_Customer tbl_accGLMaster_Customerins = new tbl_accGLMaster_Customer();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CustomerSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accGLMaster_Customerins = Maketbl_accGLMaster_Customer(dataReader);
				} else {
					tbl_accGLMaster_Customerins = null;
				}
			}
			scon.Close();
			return tbl_accGLMaster_Customerins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Customer table.
		/// </summary>
		public static List<tbl_accGLMaster_Customer> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CustomerSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accGLMaster_Customer> tbl_accGLMaster_CustomerList = new List<tbl_accGLMaster_Customer>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_Customer tbl_accGLMaster_Customer = Maketbl_accGLMaster_Customer(dataReader);
					tbl_accGLMaster_CustomerList.Add(tbl_accGLMaster_Customer);
				}
			}
			scon.Close();
			return tbl_accGLMaster_CustomerList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Customer table by a foreign key.
		/// </summary>
		public static List<tbl_accGLMaster_Customer> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CustomerSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_accGLMaster_Customer> tbl_accGLMaster_CustomerList = new List<tbl_accGLMaster_Customer>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_Customer tbl_accGLMaster_Customer = Maketbl_accGLMaster_Customer(dataReader);
					tbl_accGLMaster_CustomerList.Add(tbl_accGLMaster_Customer);
				}
			}
			scon.Close();
			return tbl_accGLMaster_CustomerList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Customer table by a foreign key.
		/// </summary>
		public static List<tbl_accGLMaster_Customer> SelectAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CustomerSelectAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
				List<tbl_accGLMaster_Customer> tbl_accGLMaster_CustomerList = new List<tbl_accGLMaster_Customer>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_Customer tbl_accGLMaster_Customer = Maketbl_accGLMaster_Customer(dataReader);
					tbl_accGLMaster_CustomerList.Add(tbl_accGLMaster_Customer);
				}
			}
			scon.Close();
			return tbl_accGLMaster_CustomerList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accGLMaster_Customer class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accGLMaster_Customer Maketbl_accGLMaster_Customer(SqlDataReader dataReader) {
			tbl_accGLMaster_Customer tbl_accGLMaster_Customer = new tbl_accGLMaster_Customer();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accGLMaster_Customer.Customer_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accGLMaster_Customer.Gl_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accGLMaster_Customer.IsActive = dataReader.GetBoolean(2);
			}

			return tbl_accGLMaster_Customer;
		}
		/// <summary>
		/// This makes tbl_accGLMaster_Customer datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_Customer object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accGLMaster_Customer  tbl_accGLMaster_Customer   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_customer_ID,col_gl_ID,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accGLMaster_Customer datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_Customer object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accGLMaster_Customer user) {
		DataRow drow = dt.NewRow();
		
			drow["customer_ID"] = user.customer_ID;
			drow["gl_ID"] = user.gl_ID;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
