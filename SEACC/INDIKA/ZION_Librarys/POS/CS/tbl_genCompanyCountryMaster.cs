using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genCompanyCountryMaster {
		#region Fields
		private string companyCountry_ID;
		private string countryName;
		private string companyID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genCompanyCountryMaster class.
		/// </summary>
		public tbl_genCompanyCountryMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genCompanyCountryMaster class.
		/// </summary>
		public tbl_genCompanyCountryMaster(string companyCountry_ID, string countryName, string companyID) {
			this.companyCountry_ID = companyCountry_ID;
			this.countryName = countryName;
			this.companyID = companyID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the CompanyCountry_ID value.
		/// </summary>
		public string CompanyCountry_ID {
			get { return companyCountry_ID; }
			set { companyCountry_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CountryName value.
		/// </summary>
		public string CountryName {
			get { return countryName; }
			set { countryName = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genCompanyCountryMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyCountryMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyCountry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@countryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
 
			scom.Parameters["@companyCountry_ID"].Value = companyCountry_ID;
			scom.Parameters["@countryName"].Value = countryName;
			scom.Parameters["@companyID"].Value = companyID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genCompanyCountryMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyCountryMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@companyCountry_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@countryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@companyCountry_ID"].Value = companyCountry_ID;
			scom.Parameters["@countryName"].Value = countryName;
			scom.Parameters["@companyID"].Value = companyID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genCompanyCountryMaster table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyCountryMasterDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@companyCountry_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyCountry_ID"].Value = companyCountry_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genCompanyCountryMaster table.
		/// </summary>
		public static tbl_genCompanyCountryMaster Select(string companyCountry_ID_Incoming){

			tbl_genCompanyCountryMaster tbl_genCompanyCountryMasterins = new tbl_genCompanyCountryMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyCountryMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@companyCountry_ID", SqlDbType.VarChar,20);
			scom.Parameters["@companyCountry_ID"].Value = companyCountry_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genCompanyCountryMasterins = Maketbl_genCompanyCountryMaster(dataReader);
				} else {
					tbl_genCompanyCountryMasterins = null;
				}
			}
			scon.Close();
			return tbl_genCompanyCountryMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genCompanyCountryMaster table.
		/// </summary>
		public static List<tbl_genCompanyCountryMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genCompanyCountryMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genCompanyCountryMaster> tbl_genCompanyCountryMasterList = new List<tbl_genCompanyCountryMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genCompanyCountryMaster tbl_genCompanyCountryMaster = Maketbl_genCompanyCountryMaster(dataReader);
					tbl_genCompanyCountryMasterList.Add(tbl_genCompanyCountryMaster);
				}
			}
			scon.Close();
			return tbl_genCompanyCountryMasterList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genCompanyCountryMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genCompanyCountryMaster Maketbl_genCompanyCountryMaster(SqlDataReader dataReader) {
			tbl_genCompanyCountryMaster tbl_genCompanyCountryMaster = new tbl_genCompanyCountryMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genCompanyCountryMaster.CompanyCountry_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genCompanyCountryMaster.CountryName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genCompanyCountryMaster.CompanyID = dataReader.GetString(2);
			}

			return tbl_genCompanyCountryMaster;
		}
		/// <summary>
		/// This makes tbl_genCompanyCountryMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genCompanyCountryMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genCompanyCountryMaster  tbl_genCompanyCountryMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_companyCountry_ID = new DataColumn("companyCountry_ID" , typeof(string));
			DataColumn col_countryName = new DataColumn("countryName" , typeof(string));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_companyCountry_ID,col_countryName,col_companyID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genCompanyCountryMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genCompanyCountryMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genCompanyCountryMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["companyCountry_ID"] = user.companyCountry_ID;
			drow["countryName"] = user.countryName;
			drow["companyID"] = user.companyID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
