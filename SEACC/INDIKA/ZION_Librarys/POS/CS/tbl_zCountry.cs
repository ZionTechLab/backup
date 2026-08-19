using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zCountry {
		#region Fields
		private string country_ID;
		private string countryName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zCountry class.
		/// </summary>
		public tbl_zCountry() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zCountry class.
		/// </summary>
		public tbl_zCountry(string country_ID, string countryName) {
			this.country_ID = country_ID;
			this.countryName = countryName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Country_ID value.
		/// </summary>
		public string Country_ID {
			get { return country_ID; }
			set { country_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CountryName value.
		/// </summary>
		public string CountryName {
			get { return countryName; }
			set { countryName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zCountry table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCountryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@countryName", SqlDbType.VarChar,50);
 
			scom.Parameters["@country_ID"].Value = country_ID;
			scom.Parameters["@countryName"].Value = countryName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zCountry table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCountryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@countryName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@country_ID"].Value = country_ID;
			scom.Parameters["@countryName"].Value = countryName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zCountry table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCountryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters["@country_ID"].Value = country_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zCountry table.
		/// </summary>
		public static tbl_zCountry Select(string country_ID_Incoming){

			tbl_zCountry tbl_zCountryins = new tbl_zCountry();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCountrySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters["@country_ID"].Value = country_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zCountryins = Maketbl_zCountry(dataReader);
				} else {
					tbl_zCountryins = null;
				}
			}
			scon.Close();
			return tbl_zCountryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zCountry table.
		/// </summary>
		public static List<tbl_zCountry> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCountrySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zCountry> tbl_zCountryList = new List<tbl_zCountry>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zCountry tbl_zCountry = Maketbl_zCountry(dataReader);
					tbl_zCountryList.Add(tbl_zCountry);
				}
			}
			scon.Close();
			return tbl_zCountryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zCountry class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zCountry Maketbl_zCountry(SqlDataReader dataReader) {
			tbl_zCountry tbl_zCountry = new tbl_zCountry();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zCountry.Country_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zCountry.CountryName = dataReader.GetString(1);
			}

			return tbl_zCountry;
		}
		/// <summary>
		/// This fills tbl_zCountry datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zCountry object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zCountry user) {
		DataRow drow = dt.NewRow();
		
			drow["country_ID"] = user.country_ID;
			drow["countryName"] = user.countryName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
