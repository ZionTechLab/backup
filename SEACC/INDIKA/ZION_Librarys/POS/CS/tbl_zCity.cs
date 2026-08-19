using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zCity {
		#region Fields
		private string city_ID;
		private string cityName;
		private string district_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zCity class.
		/// </summary>
		public tbl_zCity() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zCity class.
		/// </summary>
		public tbl_zCity(string city_ID, string cityName, string district_ID) {
			this.city_ID = city_ID;
			this.cityName = cityName;
			this.district_ID = district_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the City_ID value.
		/// </summary>
		public string City_ID {
			get { return city_ID; }
			set { city_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CityName value.
		/// </summary>
		public string CityName {
			get { return cityName; }
			set { cityName = value; }
		}
		
		/// <summary>
		/// Gets or sets the District_ID value.
		/// </summary>
		public string District_ID {
			get { return district_ID; }
			set { district_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zCity table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCityInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cityName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@district_ID", SqlDbType.VarChar,10);
 
			scom.Parameters["@city_ID"].Value = city_ID;
			scom.Parameters["@cityName"].Value = cityName;
			scom.Parameters["@district_ID"].Value = district_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zCity table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCityUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@cityName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@district_ID", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@city_ID"].Value = city_ID;
			scom.Parameters["@cityName"].Value = cityName;
			scom.Parameters["@district_ID"].Value = district_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zCity table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCityDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,10);
			scom.Parameters["@city_ID"].Value = city_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zCity table by a foreign key.
		/// </summary>
		public static void DeleteAllByDistrict_ID(string district_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCityDeleteAllByDistrict_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@district_ID", SqlDbType.VarChar,10);
			scom.Parameters["@district_ID"].Value = district_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zCity table.
		/// </summary>
		public static tbl_zCity Select(string city_ID_Incoming){

			tbl_zCity tbl_zCityins = new tbl_zCity();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCitySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,10);
			scom.Parameters["@city_ID"].Value = city_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zCityins = Maketbl_zCity(dataReader);
				} else {
					tbl_zCityins = null;
				}
			}
			scon.Close();
			return tbl_zCityins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zCity table.
		/// </summary>
		public static List<tbl_zCity> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCitySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zCity> tbl_zCityList = new List<tbl_zCity>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zCity tbl_zCity = Maketbl_zCity(dataReader);
					tbl_zCityList.Add(tbl_zCity);
				}
			}
			scon.Close();
			return tbl_zCityList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zCity table by a foreign key.
		/// </summary>
		public static List<tbl_zCity> SelectAllByDistrict_ID(string district_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zCitySelectAllByDistrict_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@district_ID", SqlDbType.VarChar,10);
			scom.Parameters["@district_ID"].Value = district_ID;
				List<tbl_zCity> tbl_zCityList = new List<tbl_zCity>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zCity tbl_zCity = Maketbl_zCity(dataReader);
					tbl_zCityList.Add(tbl_zCity);
				}
			}
			scon.Close();
			return tbl_zCityList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zCity class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zCity Maketbl_zCity(SqlDataReader dataReader) {
			tbl_zCity tbl_zCity = new tbl_zCity();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zCity.City_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zCity.CityName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zCity.District_ID = dataReader.GetString(2);
			}

			return tbl_zCity;
		}
		/// <summary>
		/// This fills tbl_zCity datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zCity object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zCity user) {
		DataRow drow = dt.NewRow();
		
			drow["city_ID"] = user.city_ID;
			drow["cityName"] = user.cityName;
			drow["district_ID"] = user.district_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
