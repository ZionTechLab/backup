using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zArea {
		#region Fields
		private string area_ID;
		private string areaName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zArea class.
		/// </summary>
		public tbl_zArea() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zArea class.
		/// </summary>
		public tbl_zArea(string area_ID, string areaName) {
			this.area_ID = area_ID;
			this.areaName = areaName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Area_ID value.
		/// </summary>
		public string Area_ID {
			get { return area_ID; }
			set { area_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AreaName value.
		/// </summary>
		public string AreaName {
			get { return areaName; }
			set { areaName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zArea table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAreaInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@area_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@areaName", SqlDbType.VarChar,50);
 
			scom.Parameters["@area_ID"].Value = area_ID;
			scom.Parameters["@areaName"].Value = areaName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zArea table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAreaUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@area_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@areaName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@area_ID"].Value = area_ID;
			scom.Parameters["@areaName"].Value = areaName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zArea table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAreaDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@area_ID", SqlDbType.VarChar,10);
			scom.Parameters["@area_ID"].Value = area_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zArea table.
		/// </summary>
		public static tbl_zArea Select(string area_ID_Incoming){

			tbl_zArea tbl_zAreains = new tbl_zArea();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAreaSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@area_ID", SqlDbType.VarChar,10);
			scom.Parameters["@area_ID"].Value = area_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zAreains = Maketbl_zArea(dataReader);
				} else {
					tbl_zAreains = null;
				}
			}
			scon.Close();
			return tbl_zAreains;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zArea table.
		/// </summary>
		public static List<tbl_zArea> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAreaSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zArea> tbl_zAreaList = new List<tbl_zArea>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zArea tbl_zArea = Maketbl_zArea(dataReader);
					tbl_zAreaList.Add(tbl_zArea);
				}
			}
			scon.Close();
			return tbl_zAreaList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zArea class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zArea Maketbl_zArea(SqlDataReader dataReader) {
			tbl_zArea tbl_zArea = new tbl_zArea();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zArea.Area_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zArea.AreaName = dataReader.GetString(1);
			}

			return tbl_zArea;
		}
		/// <summary>
		/// This fills tbl_zArea datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zArea object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zArea user) {
		DataRow drow = dt.NewRow();
		
			drow["area_ID"] = user.area_ID;
			drow["areaName"] = user.areaName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
