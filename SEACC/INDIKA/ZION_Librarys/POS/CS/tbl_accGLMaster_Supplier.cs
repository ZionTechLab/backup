using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accGLMaster_Supplier {
		#region Fields
		private string gl_ID;
		private string supplier_ID;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_Supplier class.
		/// </summary>
		public tbl_accGLMaster_Supplier() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_Supplier class.
		/// </summary>
		public tbl_accGLMaster_Supplier(string gl_ID, string supplier_ID, bool isActive) {
			this.gl_ID = gl_ID;
			this.supplier_ID = supplier_ID;
			this.isActive = isActive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Gl_ID value.
		/// </summary>
		public string Gl_ID {
			get { return gl_ID; }
			set { gl_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Supplier_ID value.
		/// </summary>
		public string Supplier_ID {
			get { return supplier_ID; }
			set { supplier_ID = value; }
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
		/// Saves a record to the tbl_accGLMaster_Supplier table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_SupplierInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accGLMaster_Supplier table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_SupplierUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accGLMaster_Supplier table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_SupplierDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Supplier table by a foreign key.
		/// </summary>
		public static void DeleteAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_SupplierDeleteAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;		
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Supplier table by a foreign key.
		/// </summary>
		public static void DeleteAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_SupplierDeleteAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;			
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accGLMaster_Supplier table.
		/// </summary>
		public static tbl_accGLMaster_Supplier Select(string gl_ID_Incoming, string supplier_ID_Incoming){

			tbl_accGLMaster_Supplier tbl_accGLMaster_Supplierins = new tbl_accGLMaster_Supplier();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_SupplierSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID_Incoming;
			scom.Parameters["@supplier_ID"].Value = supplier_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accGLMaster_Supplierins = Maketbl_accGLMaster_Supplier(dataReader);
				} else {
					tbl_accGLMaster_Supplierins = null;
				}
			}
			scon.Close();
			return tbl_accGLMaster_Supplierins;
		}
        public static tbl_accGLMaster_Supplier Select(string supplier_ID_Incoming)
        {

            tbl_accGLMaster_Supplier tbl_accGLMaster_Supplierins = new tbl_accGLMaster_Supplier();
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_accGLMaster_SupplierSelect1", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar, 20);
            scom.Parameters["@supplier_ID"].Value = supplier_ID_Incoming;
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                if (dataReader.Read())
                {
                    tbl_accGLMaster_Supplierins = Maketbl_accGLMaster_Supplier(dataReader);
                }
                else
                {
                    tbl_accGLMaster_Supplierins = null;
                }
            }
            scon.Close();
            return tbl_accGLMaster_Supplierins;
        }

        /// <summary>
        /// Selects all records from the tbl_accGLMaster_Supplier table.
        /// </summary>
        public static List<tbl_accGLMaster_Supplier> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_SupplierSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accGLMaster_Supplier> tbl_accGLMaster_SupplierList = new List<tbl_accGLMaster_Supplier>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_Supplier tbl_accGLMaster_Supplier = Maketbl_accGLMaster_Supplier(dataReader);
					tbl_accGLMaster_SupplierList.Add(tbl_accGLMaster_Supplier);
				}
			}
			scon.Close();
			return tbl_accGLMaster_SupplierList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Supplier table by a foreign key.
		/// </summary>
		public static List<tbl_accGLMaster_Supplier> SelectAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_SupplierSelectAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
				List<tbl_accGLMaster_Supplier> tbl_accGLMaster_SupplierList = new List<tbl_accGLMaster_Supplier>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_Supplier tbl_accGLMaster_Supplier = Maketbl_accGLMaster_Supplier(dataReader);
					tbl_accGLMaster_SupplierList.Add(tbl_accGLMaster_Supplier);
				}
			}
			scon.Close();
			return tbl_accGLMaster_SupplierList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_Supplier table by a foreign key.
		/// </summary>
		public static List<tbl_accGLMaster_Supplier> SelectAllBySupplier_ID(string supplier_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_SupplierSelectAllBySupplier_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@supplier_ID", SqlDbType.VarChar,20);
			scom.Parameters["@supplier_ID"].Value = supplier_ID;
				List<tbl_accGLMaster_Supplier> tbl_accGLMaster_SupplierList = new List<tbl_accGLMaster_Supplier>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_Supplier tbl_accGLMaster_Supplier = Maketbl_accGLMaster_Supplier(dataReader);
					tbl_accGLMaster_SupplierList.Add(tbl_accGLMaster_Supplier);
				}
			}
			scon.Close();
			return tbl_accGLMaster_SupplierList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accGLMaster_Supplier class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accGLMaster_Supplier Maketbl_accGLMaster_Supplier(SqlDataReader dataReader) {
			tbl_accGLMaster_Supplier tbl_accGLMaster_Supplier = new tbl_accGLMaster_Supplier();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accGLMaster_Supplier.Gl_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accGLMaster_Supplier.Supplier_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accGLMaster_Supplier.IsActive = dataReader.GetBoolean(2);
			}

			return tbl_accGLMaster_Supplier;
		}
		/// <summary>
		/// This makes tbl_accGLMaster_Supplier datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_Supplier object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accGLMaster_Supplier  tbl_accGLMaster_Supplier   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_supplier_ID = new DataColumn("supplier_ID" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_gl_ID,col_supplier_ID,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accGLMaster_Supplier datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_Supplier object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accGLMaster_Supplier user) {
		DataRow drow = dt.NewRow();
		
			drow["gl_ID"] = user.gl_ID;
			drow["supplier_ID"] = user.supplier_ID;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
