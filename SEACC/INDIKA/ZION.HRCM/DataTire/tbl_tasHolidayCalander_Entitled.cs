using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_tasHolidayCalander_Entitled {
		#region Fields
		private string company_ID;
		private string companyBranch_ID;
		private string holiday_ID;
		private string sectionID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_tasHolidayCalander_Entitled class.
		/// </summary>
		public tbl_tasHolidayCalander_Entitled() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_tasHolidayCalander_Entitled class.
		/// </summary>
		public tbl_tasHolidayCalander_Entitled(string company_ID, string companyBranch_ID, string holiday_ID, string sectionID) {
			this.company_ID = company_ID;
			this.companyBranch_ID = companyBranch_ID;
			this.holiday_ID = holiday_ID;
			this.sectionID = sectionID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Company_ID value.
		/// </summary>
		public string Company_ID {
			get { return company_ID; }
			set { company_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Holiday_ID value.
		/// </summary>
		public string Holiday_ID {
			get { return holiday_ID; }
			set { holiday_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SectionID value.
		/// </summary>
		public string SectionID {
			get { return sectionID; }
			set { sectionID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_tasHolidayCalander_Entitled table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasHolidayCalander_EntitledInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@holiday_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@sectionID", SqlDbType.VarChar,20);
 
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@holiday_ID"].Value = holiday_ID;
			scom.Parameters["@sectionID"].Value = sectionID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_tasHolidayCalander_Entitled table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasHolidayCalander_EntitledDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@holiday_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@sectionID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID;
 
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scom.Parameters["@holiday_ID"].Value = holiday_ID;
 
			scom.Parameters["@sectionID"].Value = sectionID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasHolidayCalander_Entitled table by a foreign key.
		/// </summary>
		public static void DeleteAllBySectionID_Company_ID_CompanyBranch_ID(string sectionID, string company_ID, string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasHolidayCalander_EntitledDeleteAllBySectionID_Company_ID_CompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@sectionID"].Value = sectionID;
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasHolidayCalander_Entitled table by a foreign key.
		/// </summary>
		public static void DeleteAllByHoliday_ID(string holiday_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasHolidayCalander_EntitledDeleteAllByHoliday_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@holiday_ID", SqlDbType.VarChar,8);
			scom.Parameters["@holiday_ID"].Value = holiday_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_tasHolidayCalander_Entitled table.
		/// </summary>
		public static tbl_tasHolidayCalander_Entitled Select(string company_ID_Incoming, string companyBranch_ID_Incoming, string holiday_ID_Incoming, string sectionID_Incoming){

			tbl_tasHolidayCalander_Entitled tbl_tasHolidayCalander_Entitledins = new tbl_tasHolidayCalander_Entitled();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasHolidayCalander_EntitledSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@holiday_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@sectionID", SqlDbType.VarChar,20);
			scom.Parameters["@company_ID"].Value = company_ID_Incoming;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID_Incoming;
			scom.Parameters["@holiday_ID"].Value = holiday_ID_Incoming;
			scom.Parameters["@sectionID"].Value = sectionID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_tasHolidayCalander_Entitledins = Maketbl_tasHolidayCalander_Entitled(dataReader);
				} else {
					tbl_tasHolidayCalander_Entitledins = null;
				}
			}
			scon.Close();
			return tbl_tasHolidayCalander_Entitledins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasHolidayCalander_Entitled table by a foreign key.
		/// </summary>
		public static List<tbl_tasHolidayCalander_Entitled> SelectAllBySectionID_Company_ID_CompanyBranch_ID(string sectionID, string company_ID, string companyBranch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasHolidayCalander_EntitledSelectAllBySectionID_Company_ID_CompanyBranch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sectionID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@company_ID", SqlDbType.VarChar,8);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,8);
			scom.Parameters["@sectionID"].Value = sectionID;
			scom.Parameters["@company_ID"].Value = company_ID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
				List<tbl_tasHolidayCalander_Entitled> tbl_tasHolidayCalander_EntitledList = new List<tbl_tasHolidayCalander_Entitled>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasHolidayCalander_Entitled tbl_tasHolidayCalander_Entitled = Maketbl_tasHolidayCalander_Entitled(dataReader);
					tbl_tasHolidayCalander_EntitledList.Add(tbl_tasHolidayCalander_Entitled);
				}
			}
			scon.Close();
			return tbl_tasHolidayCalander_EntitledList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_tasHolidayCalander_Entitled table by a foreign key.
		/// </summary>
		public static List<tbl_tasHolidayCalander_Entitled> SelectAllByHoliday_ID(string holiday_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_tasHolidayCalander_EntitledSelectAllByHoliday_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@holiday_ID", SqlDbType.VarChar,8);
			scom.Parameters["@holiday_ID"].Value = holiday_ID;
				List<tbl_tasHolidayCalander_Entitled> tbl_tasHolidayCalander_EntitledList = new List<tbl_tasHolidayCalander_Entitled>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_tasHolidayCalander_Entitled tbl_tasHolidayCalander_Entitled = Maketbl_tasHolidayCalander_Entitled(dataReader);
					tbl_tasHolidayCalander_EntitledList.Add(tbl_tasHolidayCalander_Entitled);
				}
			}
			scon.Close();
			return tbl_tasHolidayCalander_EntitledList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_tasHolidayCalander_Entitled class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_tasHolidayCalander_Entitled Maketbl_tasHolidayCalander_Entitled(SqlDataReader dataReader) {
			tbl_tasHolidayCalander_Entitled tbl_tasHolidayCalander_Entitled = new tbl_tasHolidayCalander_Entitled();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_tasHolidayCalander_Entitled.Company_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_tasHolidayCalander_Entitled.CompanyBranch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_tasHolidayCalander_Entitled.Holiday_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_tasHolidayCalander_Entitled.SectionID = dataReader.GetString(3);
			}

			return tbl_tasHolidayCalander_Entitled;
		}
		/// <summary>
		/// This makes tbl_tasHolidayCalander_Entitled datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_tasHolidayCalander_Entitled object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_tasHolidayCalander_Entitled  tbl_tasHolidayCalander_Entitled   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_company_ID = new DataColumn("company_ID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_holiday_ID = new DataColumn("holiday_ID" , typeof(string));
			DataColumn col_sectionID = new DataColumn("sectionID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_company_ID,col_companyBranch_ID,col_holiday_ID,col_sectionID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_tasHolidayCalander_Entitled datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_tasHolidayCalander_Entitled object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_tasHolidayCalander_Entitled user) {
		DataRow drow = dt.NewRow();
		
			drow["company_ID"] = user.company_ID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["holiday_ID"] = user.holiday_ID;
			drow["sectionID"] = user.sectionID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
