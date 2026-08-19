using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zTown {
		#region Fields
		private string town_ID;
		private string townName;
		private string city_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zTown class.
		/// </summary>
		public tbl_zTown() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zTown class.
		/// </summary>
		public tbl_zTown(string town_ID, string townName, string city_ID) {
			this.town_ID = town_ID;
			this.townName = townName;
			this.city_ID = city_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Town_ID value.
		/// </summary>
		public string Town_ID {
			get { return town_ID; }
			set { town_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TownName value.
		/// </summary>
		public string TownName {
			get { return townName; }
			set { townName = value; }
		}
		
		/// <summary>
		/// Gets or sets the City_ID value.
		/// </summary>
		public string City_ID {
			get { return city_ID; }
			set { city_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zTown table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zTownInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@townName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,10);
 
			scom.Parameters["@town_ID"].Value = town_ID;
			scom.Parameters["@townName"].Value = townName;
			scom.Parameters["@city_ID"].Value = city_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zTown table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zTownUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@townName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@town_ID"].Value = town_ID;
			scom.Parameters["@townName"].Value = townName;
			scom.Parameters["@city_ID"].Value = city_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zTown table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zTownDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@town_ID"].Value = town_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zTown table by a foreign key.
		/// </summary>
		public static void DeleteAllByCity_ID(string city_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zTownDeleteAllByCity_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,10);
			scom.Parameters["@city_ID"].Value = city_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zTown table.
		/// </summary>
		public static tbl_zTown Select(string town_ID_Incoming){

			tbl_zTown tbl_zTownins = new tbl_zTown();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zTownSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@town_ID", SqlDbType.VarChar,10);
			scom.Parameters["@town_ID"].Value = town_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zTownins = Maketbl_zTown(dataReader);
				} else {
					tbl_zTownins = null;
				}
			}
			scon.Close();
			return tbl_zTownins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zTown table.
		/// </summary>
		public static List<tbl_zTown> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zTownSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zTown> tbl_zTownList = new List<tbl_zTown>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zTown tbl_zTown = Maketbl_zTown(dataReader);
					tbl_zTownList.Add(tbl_zTown);
				}
			}
			scon.Close();
			return tbl_zTownList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zTown table by a foreign key.
		/// </summary>
		public static List<tbl_zTown> SelectAllByCity_ID(string city_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zTownSelectAllByCity_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@city_ID", SqlDbType.VarChar,10);
			scom.Parameters["@city_ID"].Value = city_ID;
				List<tbl_zTown> tbl_zTownList = new List<tbl_zTown>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zTown tbl_zTown = Maketbl_zTown(dataReader);
					tbl_zTownList.Add(tbl_zTown);
				}
			}
			scon.Close();
			return tbl_zTownList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zTown class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zTown Maketbl_zTown(SqlDataReader dataReader) {
			tbl_zTown tbl_zTown = new tbl_zTown();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zTown.Town_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zTown.TownName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zTown.City_ID = dataReader.GetString(2);
			}

			return tbl_zTown;
		}
		/// <summary>
		/// This fills tbl_zTown datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zTown object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zTown user) {
		DataRow drow = dt.NewRow();
		
			drow["town_ID"] = user.town_ID;
			drow["townName"] = user.townName;
			drow["city_ID"] = user.city_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
