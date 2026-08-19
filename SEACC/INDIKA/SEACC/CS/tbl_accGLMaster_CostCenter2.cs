using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accGLMaster_CostCenter2 {
		#region Fields
		private string gl_ID;
		private string costCenter2_ID;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_CostCenter2 class.
		/// </summary>
		public tbl_accGLMaster_CostCenter2() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_CostCenter2 class.
		/// </summary>
		public tbl_accGLMaster_CostCenter2(string gl_ID, string costCenter2_ID, bool isActive) {
			this.gl_ID = gl_ID;
			this.costCenter2_ID = costCenter2_ID;
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
		/// Gets or sets the CostCenter2_ID value.
		/// </summary>
		public string CostCenter2_ID {
			get { return costCenter2_ID; }
			set { costCenter2_ID = value; }
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
		/// Saves a record to the tbl_accGLMaster_CostCenter2 table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CostCenter2Insert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accGLMaster_CostCenter2 table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CostCenter2Update", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accGLMaster_CostCenter2 table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CostCenter2Delete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_CostCenter2 table by a foreign key.
		/// </summary>
		public static void DeleteAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CostCenter2DeleteAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;			
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_CostCenter2 table by a foreign key.
		/// </summary>
		public static void DeleteAllByCostCenter2_ID(string costCenter2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CostCenter2DeleteAllByCostCenter2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accGLMaster_CostCenter2 table.
		/// </summary>
		public static tbl_accGLMaster_CostCenter2 Select(string gl_ID_Incoming, string costCenter2_ID_Incoming){

			tbl_accGLMaster_CostCenter2 tbl_accGLMaster_CostCenter2ins = new tbl_accGLMaster_CostCenter2();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CostCenter2Select", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@gl_ID"].Value = gl_ID_Incoming;
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accGLMaster_CostCenter2ins = Maketbl_accGLMaster_CostCenter2(dataReader);
				} else {
					tbl_accGLMaster_CostCenter2ins = null;
				}
			}
			scon.Close();
			return tbl_accGLMaster_CostCenter2ins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_CostCenter2 table.
		/// </summary>
		public static List<tbl_accGLMaster_CostCenter2> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CostCenter2SelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accGLMaster_CostCenter2> tbl_accGLMaster_CostCenter2List = new List<tbl_accGLMaster_CostCenter2>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_CostCenter2 tbl_accGLMaster_CostCenter2 = Maketbl_accGLMaster_CostCenter2(dataReader);
					tbl_accGLMaster_CostCenter2List.Add(tbl_accGLMaster_CostCenter2);
				}
			}
			scon.Close();
			return tbl_accGLMaster_CostCenter2List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_CostCenter2 table by a foreign key.
		/// </summary>
		public static List<tbl_accGLMaster_CostCenter2> SelectAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CostCenter2SelectAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
				List<tbl_accGLMaster_CostCenter2> tbl_accGLMaster_CostCenter2List = new List<tbl_accGLMaster_CostCenter2>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_CostCenter2 tbl_accGLMaster_CostCenter2 = Maketbl_accGLMaster_CostCenter2(dataReader);
					tbl_accGLMaster_CostCenter2List.Add(tbl_accGLMaster_CostCenter2);
				}
			}
			scon.Close();
			return tbl_accGLMaster_CostCenter2List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_CostCenter2 table by a foreign key.
		/// </summary>
		public static List<tbl_accGLMaster_CostCenter2> SelectAllByCostCenter2_ID(string costCenter2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CostCenter2SelectAllByCostCenter2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costCenter2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter2_ID"].Value = costCenter2_ID;
				List<tbl_accGLMaster_CostCenter2> tbl_accGLMaster_CostCenter2List = new List<tbl_accGLMaster_CostCenter2>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_CostCenter2 tbl_accGLMaster_CostCenter2 = Maketbl_accGLMaster_CostCenter2(dataReader);
					tbl_accGLMaster_CostCenter2List.Add(tbl_accGLMaster_CostCenter2);
				}
			}
			scon.Close();
			return tbl_accGLMaster_CostCenter2List;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accGLMaster_CostCenter2 class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accGLMaster_CostCenter2 Maketbl_accGLMaster_CostCenter2(SqlDataReader dataReader) {
			tbl_accGLMaster_CostCenter2 tbl_accGLMaster_CostCenter2 = new tbl_accGLMaster_CostCenter2();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accGLMaster_CostCenter2.Gl_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accGLMaster_CostCenter2.CostCenter2_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accGLMaster_CostCenter2.IsActive = dataReader.GetBoolean(2);
			}

			return tbl_accGLMaster_CostCenter2;
		}
		/// <summary>
		/// This makes tbl_accGLMaster_CostCenter2 datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_CostCenter2 object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accGLMaster_CostCenter2  tbl_accGLMaster_CostCenter2   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_costCenter2_ID = new DataColumn("costCenter2_ID" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_gl_ID,col_costCenter2_ID,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accGLMaster_CostCenter2 datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_CostCenter2 object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accGLMaster_CostCenter2 user) {
		DataRow drow = dt.NewRow();
		
			drow["gl_ID"] = user.gl_ID;
			drow["costCenter2_ID"] = user.costCenter2_ID;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
