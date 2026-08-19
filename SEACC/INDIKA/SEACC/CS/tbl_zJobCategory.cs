using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zJobCategory {
		#region Fields
		private string jobCategory_ID;
		private string jobCategoryName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zJobCategory class.
		/// </summary>
		public tbl_zJobCategory() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zJobCategory class.
		/// </summary>
		public tbl_zJobCategory(string jobCategory_ID, string jobCategoryName) {
			this.jobCategory_ID = jobCategory_ID;
			this.jobCategoryName = jobCategoryName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the JobCategory_ID value.
		/// </summary>
		public string JobCategory_ID {
			get { return jobCategory_ID; }
			set { jobCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the JobCategoryName value.
		/// </summary>
		public string JobCategoryName {
			get { return jobCategoryName; }
			set { jobCategoryName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zJobCategory table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobCategoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@jobCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@jobCategoryName", SqlDbType.VarChar,50);
 
			scom.Parameters["@jobCategory_ID"].Value = jobCategory_ID;
			scom.Parameters["@jobCategoryName"].Value = jobCategoryName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zJobCategory table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobCategoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@jobCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@jobCategoryName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@jobCategory_ID"].Value = jobCategory_ID;
			scom.Parameters["@jobCategoryName"].Value = jobCategoryName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zJobCategory table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobCategoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@jobCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@jobCategory_ID"].Value = jobCategory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zJobCategory table.
		/// </summary>
		public static tbl_zJobCategory Select(string jobCategory_ID_Incoming){

			tbl_zJobCategory tbl_zJobCategoryins = new tbl_zJobCategory();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobCategorySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@jobCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@jobCategory_ID"].Value = jobCategory_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zJobCategoryins = Maketbl_zJobCategory(dataReader);
				} else {
					tbl_zJobCategoryins = null;
				}
			}
			scon.Close();
			return tbl_zJobCategoryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zJobCategory table.
		/// </summary>
		public static List<tbl_zJobCategory> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zJobCategorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zJobCategory> tbl_zJobCategoryList = new List<tbl_zJobCategory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zJobCategory tbl_zJobCategory = Maketbl_zJobCategory(dataReader);
					tbl_zJobCategoryList.Add(tbl_zJobCategory);
				}
			}
			scon.Close();
			return tbl_zJobCategoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zJobCategory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zJobCategory Maketbl_zJobCategory(SqlDataReader dataReader) {
			tbl_zJobCategory tbl_zJobCategory = new tbl_zJobCategory();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zJobCategory.JobCategory_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zJobCategory.JobCategoryName = dataReader.GetString(1);
			}

			return tbl_zJobCategory;
		}
		/// <summary>
		/// This makes tbl_zJobCategory datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zJobCategory object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zJobCategory  tbl_zJobCategory   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_jobCategory_ID = new DataColumn("jobCategory_ID" , typeof(string));
			DataColumn col_jobCategoryName = new DataColumn("jobCategoryName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_jobCategory_ID,col_jobCategoryName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zJobCategory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zJobCategory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zJobCategory user) {
		DataRow drow = dt.NewRow();
		
			drow["jobCategory_ID"] = user.jobCategory_ID;
			drow["jobCategoryName"] = user.jobCategoryName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
