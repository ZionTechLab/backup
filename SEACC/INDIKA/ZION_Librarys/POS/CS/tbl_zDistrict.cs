using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zDistrict {
		#region Fields
		private string district_ID;
		private string districtName;
		private string province_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zDistrict class.
		/// </summary>
		public tbl_zDistrict() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zDistrict class.
		/// </summary>
		public tbl_zDistrict(string district_ID, string districtName, string province_ID) {
			this.district_ID = district_ID;
			this.districtName = districtName;
			this.province_ID = province_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the District_ID value.
		/// </summary>
		public string District_ID {
			get { return district_ID; }
			set { district_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DistrictName value.
		/// </summary>
		public string DistrictName {
			get { return districtName; }
			set { districtName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Province_ID value.
		/// </summary>
		public string Province_ID {
			get { return province_ID; }
			set { province_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zDistrict table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDistrictInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@district_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@districtName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@province_ID", SqlDbType.VarChar,10);
 
			scom.Parameters["@district_ID"].Value = district_ID;
			scom.Parameters["@districtName"].Value = districtName;
			scom.Parameters["@province_ID"].Value = province_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zDistrict table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDistrictUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@district_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@districtName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@province_ID", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@district_ID"].Value = district_ID;
			scom.Parameters["@districtName"].Value = districtName;
			scom.Parameters["@province_ID"].Value = province_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zDistrict table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDistrictDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@district_ID", SqlDbType.VarChar,10);
			scom.Parameters["@district_ID"].Value = district_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zDistrict table by a foreign key.
		/// </summary>
		public static void DeleteAllByProvince_ID(string province_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDistrictDeleteAllByProvince_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@province_ID", SqlDbType.VarChar,10);
			scom.Parameters["@province_ID"].Value = province_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zDistrict table.
		/// </summary>
		public static tbl_zDistrict Select(string district_ID_Incoming){

			tbl_zDistrict tbl_zDistrictins = new tbl_zDistrict();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDistrictSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@district_ID", SqlDbType.VarChar,10);
			scom.Parameters["@district_ID"].Value = district_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zDistrictins = Maketbl_zDistrict(dataReader);
				} else {
					tbl_zDistrictins = null;
				}
			}
			scon.Close();
			return tbl_zDistrictins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zDistrict table.
		/// </summary>
		public static List<tbl_zDistrict> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDistrictSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zDistrict> tbl_zDistrictList = new List<tbl_zDistrict>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zDistrict tbl_zDistrict = Maketbl_zDistrict(dataReader);
					tbl_zDistrictList.Add(tbl_zDistrict);
				}
			}
			scon.Close();
			return tbl_zDistrictList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zDistrict table by a foreign key.
		/// </summary>
		public static List<tbl_zDistrict> SelectAllByProvince_ID(string province_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zDistrictSelectAllByProvince_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@province_ID", SqlDbType.VarChar,10);
			scom.Parameters["@province_ID"].Value = province_ID;
				List<tbl_zDistrict> tbl_zDistrictList = new List<tbl_zDistrict>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zDistrict tbl_zDistrict = Maketbl_zDistrict(dataReader);
					tbl_zDistrictList.Add(tbl_zDistrict);
				}
			}
			scon.Close();
			return tbl_zDistrictList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zDistrict class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zDistrict Maketbl_zDistrict(SqlDataReader dataReader) {
			tbl_zDistrict tbl_zDistrict = new tbl_zDistrict();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zDistrict.District_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zDistrict.DistrictName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zDistrict.Province_ID = dataReader.GetString(2);
			}

			return tbl_zDistrict;
		}
		/// <summary>
		/// This fills tbl_zDistrict datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zDistrict object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zDistrict user) {
		DataRow drow = dt.NewRow();
		
			drow["district_ID"] = user.district_ID;
			drow["districtName"] = user.districtName;
			drow["province_ID"] = user.province_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
