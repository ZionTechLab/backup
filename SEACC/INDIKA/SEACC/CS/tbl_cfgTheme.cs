using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_cfgTheme {
		#region Fields
		private int themeID;
		private string themeName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_cfgTheme class.
		/// </summary>
		public tbl_cfgTheme() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_cfgTheme class.
		/// </summary>
		public tbl_cfgTheme(int themeID, string themeName) {
			this.themeID = themeID;
			this.themeName = themeName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ThemeID value.
		/// </summary>
		public int ThemeID {
			get { return themeID; }
			set { themeID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ThemeName value.
		/// </summary>
		public string ThemeName {
			get { return themeName; }
			set { themeName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_cfgTheme table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@themeID", SqlDbType.Int,4);
			scom.Parameters.Add("@themeName", SqlDbType.VarChar,50);
 
			scom.Parameters["@themeID"].Value = themeID;
			scom.Parameters["@themeName"].Value = themeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_cfgTheme table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@themeID", SqlDbType.Int,4);
			scom.Parameters.Add("@themeName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@themeID"].Value = themeID;
			scom.Parameters["@themeName"].Value = themeName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_cfgTheme table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@themeID", SqlDbType.Int,4);
			scom.Parameters["@themeID"].Value = themeID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_cfgTheme table.
		/// </summary>
		public static tbl_cfgTheme Select(int themeID_Incoming){

			tbl_cfgTheme tbl_cfgThemeins = new tbl_cfgTheme();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@themeID", SqlDbType.Int,4);
			scom.Parameters["@themeID"].Value = themeID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_cfgThemeins = Maketbl_cfgTheme(dataReader);
				} else {
					tbl_cfgThemeins = null;
				}
			}
			scon.Close();
			return tbl_cfgThemeins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_cfgTheme table.
		/// </summary>
		public static List<tbl_cfgTheme> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_cfgTheme> tbl_cfgThemeList = new List<tbl_cfgTheme>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_cfgTheme tbl_cfgTheme = Maketbl_cfgTheme(dataReader);
					tbl_cfgThemeList.Add(tbl_cfgTheme);
				}
			}
			scon.Close();
			return tbl_cfgThemeList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_cfgTheme class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_cfgTheme Maketbl_cfgTheme(SqlDataReader dataReader) {
			tbl_cfgTheme tbl_cfgTheme = new tbl_cfgTheme();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_cfgTheme.ThemeID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_cfgTheme.ThemeName = dataReader.GetString(1);
			}

			return tbl_cfgTheme;
		}
		/// <summary>
		/// This makes tbl_cfgTheme datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_cfgTheme object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_cfgTheme  tbl_cfgTheme   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_themeID = new DataColumn("themeID" , typeof(int));
			DataColumn col_themeName = new DataColumn("themeName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_themeID,col_themeName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_cfgTheme datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_cfgTheme object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_cfgTheme user) {
		DataRow drow = dt.NewRow();
		
			drow["themeID"] = user.themeID;
			drow["themeName"] = user.themeName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
