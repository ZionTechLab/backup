using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_accGLMaster_CostCenter1 {
		#region Fields
		private string gl_ID;
		private string costCenter1_ID;
		private bool isActive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_CostCenter1 class.
		/// </summary>
		public tbl_accGLMaster_CostCenter1() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_accGLMaster_CostCenter1 class.
		/// </summary>
		public tbl_accGLMaster_CostCenter1(string gl_ID, string costCenter1_ID, bool isActive) {
			this.gl_ID = gl_ID;
			this.costCenter1_ID = costCenter1_ID;
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
		/// Gets or sets the CostCenter1_ID value.
		/// </summary>
		public string CostCenter1_ID {
			get { return costCenter1_ID; }
			set { costCenter1_ID = value; }
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
		/// Saves a record to the tbl_accGLMaster_CostCenter1 table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CostCenter1Insert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_accGLMaster_CostCenter1 table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CostCenter1Update", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isActive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@gl_ID"].Value = gl_ID;
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
			scom.Parameters["@isActive"].Value = isActive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_accGLMaster_CostCenter1 table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CostCenter1Delete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_CostCenter1 table by a foreign key.
		/// </summary>
		public static void DeleteAllByCostCenter1_ID(string costCenter1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CostCenter1DeleteAllByCostCenter1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_CostCenter1 table by a foreign key.
		/// </summary>
		public static void DeleteAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CostCenter1DeleteAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;			
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_accGLMaster_CostCenter1 table.
		/// </summary>
		public static tbl_accGLMaster_CostCenter1 Select(string gl_ID_Incoming, string costCenter1_ID_Incoming){

			tbl_accGLMaster_CostCenter1 tbl_accGLMaster_CostCenter1ins = new tbl_accGLMaster_CostCenter1();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CostCenter1Select", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@gl_ID"].Value = gl_ID_Incoming;
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_accGLMaster_CostCenter1ins = Maketbl_accGLMaster_CostCenter1(dataReader);
				} else {
					tbl_accGLMaster_CostCenter1ins = null;
				}
			}
			scon.Close();
			return tbl_accGLMaster_CostCenter1ins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_CostCenter1 table.
		/// </summary>
		public static List<tbl_accGLMaster_CostCenter1> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CostCenter1SelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_accGLMaster_CostCenter1> tbl_accGLMaster_CostCenter1List = new List<tbl_accGLMaster_CostCenter1>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_CostCenter1 tbl_accGLMaster_CostCenter1 = Maketbl_accGLMaster_CostCenter1(dataReader);
					tbl_accGLMaster_CostCenter1List.Add(tbl_accGLMaster_CostCenter1);
				}
			}
			scon.Close();
			return tbl_accGLMaster_CostCenter1List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_CostCenter1 table by a foreign key.
		/// </summary>
		public static List<tbl_accGLMaster_CostCenter1> SelectAllByCostCenter1_ID(string costCenter1_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CostCenter1SelectAllByCostCenter1_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@costCenter1_ID", SqlDbType.VarChar,10);
			scom.Parameters["@costCenter1_ID"].Value = costCenter1_ID;
				List<tbl_accGLMaster_CostCenter1> tbl_accGLMaster_CostCenter1List = new List<tbl_accGLMaster_CostCenter1>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_CostCenter1 tbl_accGLMaster_CostCenter1 = Maketbl_accGLMaster_CostCenter1(dataReader);
					tbl_accGLMaster_CostCenter1List.Add(tbl_accGLMaster_CostCenter1);
				}
			}
			scon.Close();
			return tbl_accGLMaster_CostCenter1List;
		}
		
		/// <summary>
		/// Selects all records from the tbl_accGLMaster_CostCenter1 table by a foreign key.
		/// </summary>
		public static List<tbl_accGLMaster_CostCenter1> SelectAllByGl_ID(string gl_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_accGLMaster_CostCenter1SelectAllByGl_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@gl_ID", SqlDbType.VarChar,20);
			scom.Parameters["@gl_ID"].Value = gl_ID;
				List<tbl_accGLMaster_CostCenter1> tbl_accGLMaster_CostCenter1List = new List<tbl_accGLMaster_CostCenter1>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_accGLMaster_CostCenter1 tbl_accGLMaster_CostCenter1 = Maketbl_accGLMaster_CostCenter1(dataReader);
					tbl_accGLMaster_CostCenter1List.Add(tbl_accGLMaster_CostCenter1);
				}
			}
			scon.Close();
			return tbl_accGLMaster_CostCenter1List;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_accGLMaster_CostCenter1 class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_accGLMaster_CostCenter1 Maketbl_accGLMaster_CostCenter1(SqlDataReader dataReader) {
			tbl_accGLMaster_CostCenter1 tbl_accGLMaster_CostCenter1 = new tbl_accGLMaster_CostCenter1();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_accGLMaster_CostCenter1.Gl_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_accGLMaster_CostCenter1.CostCenter1_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_accGLMaster_CostCenter1.IsActive = dataReader.GetBoolean(2);
			}

			return tbl_accGLMaster_CostCenter1;
		}
		/// <summary>
		/// This makes tbl_accGLMaster_CostCenter1 datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_CostCenter1 object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_accGLMaster_CostCenter1  tbl_accGLMaster_CostCenter1   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_gl_ID = new DataColumn("gl_ID" , typeof(string));
			DataColumn col_costCenter1_ID = new DataColumn("costCenter1_ID" , typeof(string));
			DataColumn col_isActive = new DataColumn("isActive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_gl_ID,col_costCenter1_ID,col_isActive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_accGLMaster_CostCenter1 datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_accGLMaster_CostCenter1 object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_accGLMaster_CostCenter1 user) {
		DataRow drow = dt.NewRow();
		
			drow["gl_ID"] = user.gl_ID;
			drow["costCenter1_ID"] = user.costCenter1_ID;
			drow["isActive"] = user.isActive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
