using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zProvince {
		#region Fields
		private string province_ID;
		private string provinceName;
		private string country_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zProvince class.
		/// </summary>
		public tbl_zProvince() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zProvince class.
		/// </summary>
		public tbl_zProvince(string province_ID, string provinceName, string country_ID) {
			this.province_ID = province_ID;
			this.provinceName = provinceName;
			this.country_ID = country_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Province_ID value.
		/// </summary>
		public string Province_ID {
			get { return province_ID; }
			set { province_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProvinceName value.
		/// </summary>
		public string ProvinceName {
			get { return provinceName; }
			set { provinceName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Country_ID value.
		/// </summary>
		public string Country_ID {
			get { return country_ID; }
			set { country_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zProvince table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zProvinceInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@province_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@provinceName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
 
			scom.Parameters["@province_ID"].Value = province_ID;
			scom.Parameters["@provinceName"].Value = provinceName;
			scom.Parameters["@country_ID"].Value = country_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zProvince table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zProvinceUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@province_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@provinceName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@province_ID"].Value = province_ID;
			scom.Parameters["@provinceName"].Value = provinceName;
			scom.Parameters["@country_ID"].Value = country_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zProvince table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zProvinceDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@province_ID", SqlDbType.VarChar,10);
			scom.Parameters["@province_ID"].Value = province_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zProvince table by a foreign key.
		/// </summary>
		public static void DeleteAllByCountry_ID(string country_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zProvinceDeleteAllByCountry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters["@country_ID"].Value = country_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zProvince table.
		/// </summary>
		public static tbl_zProvince Select(string province_ID_Incoming){

			tbl_zProvince tbl_zProvinceins = new tbl_zProvince();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zProvinceSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@province_ID", SqlDbType.VarChar,10);
			scom.Parameters["@province_ID"].Value = province_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zProvinceins = Maketbl_zProvince(dataReader);
				} else {
					tbl_zProvinceins = null;
				}
			}
			scon.Close();
			return tbl_zProvinceins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zProvince table.
		/// </summary>
		public static List<tbl_zProvince> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zProvinceSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zProvince> tbl_zProvinceList = new List<tbl_zProvince>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zProvince tbl_zProvince = Maketbl_zProvince(dataReader);
					tbl_zProvinceList.Add(tbl_zProvince);
				}
			}
			scon.Close();
			return tbl_zProvinceList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zProvince table by a foreign key.
		/// </summary>
		public static List<tbl_zProvince> SelectAllByCountry_ID(string country_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zProvinceSelectAllByCountry_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@country_ID", SqlDbType.VarChar,10);
			scom.Parameters["@country_ID"].Value = country_ID;
				List<tbl_zProvince> tbl_zProvinceList = new List<tbl_zProvince>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zProvince tbl_zProvince = Maketbl_zProvince(dataReader);
					tbl_zProvinceList.Add(tbl_zProvince);
				}
			}
			scon.Close();
			return tbl_zProvinceList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zProvince class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zProvince Maketbl_zProvince(SqlDataReader dataReader) {
			tbl_zProvince tbl_zProvince = new tbl_zProvince();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zProvince.Province_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zProvince.ProvinceName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zProvince.Country_ID = dataReader.GetString(2);
			}

			return tbl_zProvince;
		}
		/// <summary>
		/// This fills tbl_zProvince datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zProvince object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zProvince user) {
		DataRow drow = dt.NewRow();
		
			drow["province_ID"] = user.province_ID;
			drow["provinceName"] = user.provinceName;
			drow["country_ID"] = user.country_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
