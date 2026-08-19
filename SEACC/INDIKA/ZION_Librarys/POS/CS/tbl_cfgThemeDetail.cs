using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_cfgThemeDetail {
		#region Fields
		private int themeID;
		private int elementID;
		private string elementValue;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_cfgThemeDetail class.
		/// </summary>
		public tbl_cfgThemeDetail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_cfgThemeDetail class.
		/// </summary>
		public tbl_cfgThemeDetail(int themeID, int elementID, string elementValue) {
			this.themeID = themeID;
			this.elementID = elementID;
			this.elementValue = elementValue;
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
		/// Gets or sets the ElementID value.
		/// </summary>
		public int ElementID {
			get { return elementID; }
			set { elementID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ElementValue value.
		/// </summary>
		public string ElementValue {
			get { return elementValue; }
			set { elementValue = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_cfgThemeDetail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeDetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@themeID", SqlDbType.Int,4);
			scom.Parameters.Add("@elementID", SqlDbType.Int,4);
			scom.Parameters.Add("@elementValue", SqlDbType.VarChar,20);
 
			scom.Parameters["@themeID"].Value = themeID;
			scom.Parameters["@elementID"].Value = elementID;
			scom.Parameters["@elementValue"].Value = elementValue;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_cfgThemeDetail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeDetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@themeID", SqlDbType.Int,4);
			scom.Parameters.Add("@elementID", SqlDbType.Int,4);
			scom.Parameters.Add("@elementValue", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@themeID"].Value = themeID;
			scom.Parameters["@elementID"].Value = elementID;
			scom.Parameters["@elementValue"].Value = elementValue;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_cfgThemeDetail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeDetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@themeID", SqlDbType.Int,4);
			scom.Parameters.Add("@elementID", SqlDbType.Int,4);
			scom.Parameters["@themeID"].Value = themeID;
 
			scom.Parameters["@elementID"].Value = elementID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_cfgThemeDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByElementID(int elementID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeDetailDeleteAllByElementID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@elementID", SqlDbType.Int,4);
			scom.Parameters["@elementID"].Value = elementID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_cfgThemeDetail table by a foreign key.
		/// </summary>
		public static void DeleteAllByThemeID(int themeID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeDetailDeleteAllByThemeID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@themeID", SqlDbType.Int,4);
			scom.Parameters["@themeID"].Value = themeID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_cfgThemeDetail table.
		/// </summary>
		public static tbl_cfgThemeDetail Select(int themeID_Incoming, int elementID_Incoming){

			tbl_cfgThemeDetail tbl_cfgThemeDetailins = new tbl_cfgThemeDetail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeDetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@themeID", SqlDbType.Int,4);
			scom.Parameters.Add("@elementID", SqlDbType.Int,4);
			scom.Parameters["@themeID"].Value = themeID_Incoming;
			scom.Parameters["@elementID"].Value = elementID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_cfgThemeDetailins = Maketbl_cfgThemeDetail(dataReader);
				} else {
					tbl_cfgThemeDetailins = null;
				}
			}
			scon.Close();
			return tbl_cfgThemeDetailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_cfgThemeDetail table.
		/// </summary>
		public static List<tbl_cfgThemeDetail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeDetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_cfgThemeDetail> tbl_cfgThemeDetailList = new List<tbl_cfgThemeDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_cfgThemeDetail tbl_cfgThemeDetail = Maketbl_cfgThemeDetail(dataReader);
					tbl_cfgThemeDetailList.Add(tbl_cfgThemeDetail);
				}
			}
			scon.Close();
			return tbl_cfgThemeDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_cfgThemeDetail table by a foreign key.
		/// </summary>
		public static List<tbl_cfgThemeDetail> SelectAllByElementID(int elementID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeDetailSelectAllByElementID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@elementID", SqlDbType.Int,4);
			scom.Parameters["@elementID"].Value = elementID;
				List<tbl_cfgThemeDetail> tbl_cfgThemeDetailList = new List<tbl_cfgThemeDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_cfgThemeDetail tbl_cfgThemeDetail = Maketbl_cfgThemeDetail(dataReader);
					tbl_cfgThemeDetailList.Add(tbl_cfgThemeDetail);
				}
			}
			scon.Close();
			return tbl_cfgThemeDetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_cfgThemeDetail table by a foreign key.
		/// </summary>
		public static List<tbl_cfgThemeDetail> SelectAllByThemeID(int themeID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeDetailSelectAllByThemeID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@themeID", SqlDbType.Int,4);
			scom.Parameters["@themeID"].Value = themeID;
				List<tbl_cfgThemeDetail> tbl_cfgThemeDetailList = new List<tbl_cfgThemeDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_cfgThemeDetail tbl_cfgThemeDetail = Maketbl_cfgThemeDetail(dataReader);
					tbl_cfgThemeDetailList.Add(tbl_cfgThemeDetail);
				}
			}
			scon.Close();
			return tbl_cfgThemeDetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_cfgThemeDetail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_cfgThemeDetail Maketbl_cfgThemeDetail(SqlDataReader dataReader) {
			tbl_cfgThemeDetail tbl_cfgThemeDetail = new tbl_cfgThemeDetail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_cfgThemeDetail.ThemeID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_cfgThemeDetail.ElementID = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_cfgThemeDetail.ElementValue = dataReader.GetString(2);
			}

			return tbl_cfgThemeDetail;
		}
		/// <summary>
		/// This makes tbl_cfgThemeDetail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_cfgThemeDetail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_cfgThemeDetail  tbl_cfgThemeDetail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_themeID = new DataColumn("themeID" , typeof(int));
			DataColumn col_elementID = new DataColumn("elementID" , typeof(int));
			DataColumn col_elementValue = new DataColumn("elementValue" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_themeID,col_elementID,col_elementValue,});		return dt;
		}
		/// <summary>
		/// This fills tbl_cfgThemeDetail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_cfgThemeDetail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_cfgThemeDetail user) {
		DataRow drow = dt.NewRow();
		
			drow["themeID"] = user.themeID;
			drow["elementID"] = user.elementID;
			drow["elementValue"] = user.elementValue;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
