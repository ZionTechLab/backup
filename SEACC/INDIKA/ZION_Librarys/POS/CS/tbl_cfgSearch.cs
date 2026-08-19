using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_cfgSearch {
		#region Fields
		private int searchId;
		private string searchName;
		private string displayName;
		private string searchTable;
		private string selection1;
		private string selection2;
		private int width;
		private string orderBy;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_cfgSearch class.
		/// </summary>
		public tbl_cfgSearch() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_cfgSearch class.
		/// </summary>
		public tbl_cfgSearch(int searchId, string searchName, string displayName, string searchTable, string selection1, string selection2, int width, string orderBy) {
			this.searchId = searchId;
			this.searchName = searchName;
			this.displayName = displayName;
			this.searchTable = searchTable;
			this.selection1 = selection1;
			this.selection2 = selection2;
			this.width = width;
			this.orderBy = orderBy;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SearchId value.
		/// </summary>
		public int SearchId {
			get { return searchId; }
			set { searchId = value; }
		}
		
		/// <summary>
		/// Gets or sets the SearchName value.
		/// </summary>
		public string SearchName {
			get { return searchName; }
			set { searchName = value; }
		}
		
		/// <summary>
		/// Gets or sets the DisplayName value.
		/// </summary>
		public string DisplayName {
			get { return displayName; }
			set { displayName = value; }
		}
		
		/// <summary>
		/// Gets or sets the SearchTable value.
		/// </summary>
		public string SearchTable {
			get { return searchTable; }
			set { searchTable = value; }
		}
		
		/// <summary>
		/// Gets or sets the Selection1 value.
		/// </summary>
		public string Selection1 {
			get { return selection1; }
			set { selection1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Selection2 value.
		/// </summary>
		public string Selection2 {
			get { return selection2; }
			set { selection2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Width value.
		/// </summary>
		public int Width {
			get { return width; }
			set { width = value; }
		}
		
		/// <summary>
		/// Gets or sets the OrderBy value.
		/// </summary>
		public string OrderBy {
			get { return orderBy; }
			set { orderBy = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_cfgSearch table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgSearchInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@searchId", SqlDbType.Int,4);
			scom.Parameters.Add("@searchName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@searchTable", SqlDbType.VarChar,500);
			scom.Parameters.Add("@selection1", SqlDbType.VarChar,500);
			scom.Parameters.Add("@selection2", SqlDbType.VarChar,500);
			scom.Parameters.Add("@width", SqlDbType.Int,4);
			scom.Parameters.Add("@orderBy", SqlDbType.VarChar,200);
 
			scom.Parameters["@searchId"].Value = searchId;
			scom.Parameters["@searchName"].Value = searchName;
			scom.Parameters["@displayName"].Value = displayName;
			scom.Parameters["@searchTable"].Value = searchTable;
			scom.Parameters["@selection1"].Value = selection1;
			scom.Parameters["@selection2"].Value = selection2;
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@orderBy"].Value = orderBy;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_cfgSearch table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgSearchUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@searchId", SqlDbType.Int,4);
			scom.Parameters.Add("@searchName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@searchTable", SqlDbType.VarChar,500);
			scom.Parameters.Add("@selection1", SqlDbType.VarChar,500);
			scom.Parameters.Add("@selection2", SqlDbType.VarChar,500);
			scom.Parameters.Add("@width", SqlDbType.Int,4);
			scom.Parameters.Add("@orderBy", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@searchId"].Value = searchId;
			scom.Parameters["@searchName"].Value = searchName;
			scom.Parameters["@displayName"].Value = displayName;
			scom.Parameters["@searchTable"].Value = searchTable;
			scom.Parameters["@selection1"].Value = selection1;
			scom.Parameters["@selection2"].Value = selection2;
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@orderBy"].Value = orderBy;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_cfgSearch table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgSearchDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@searchId", SqlDbType.Int,4);
			scom.Parameters["@searchId"].Value = searchId;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_cfgSearch table.
		/// </summary>
		public static tbl_cfgSearch Select(int searchId_Incoming){

			tbl_cfgSearch tbl_cfgSearchins = new tbl_cfgSearch();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgSearchSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@searchId", SqlDbType.Int,4);
			scom.Parameters["@searchId"].Value = searchId_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_cfgSearchins = Maketbl_cfgSearch(dataReader);
				} else {
					tbl_cfgSearchins = null;
				}
			}
			scon.Close();
			return tbl_cfgSearchins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_cfgSearch table.
		/// </summary>
		public static List<tbl_cfgSearch> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgSearchSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_cfgSearch> tbl_cfgSearchList = new List<tbl_cfgSearch>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_cfgSearch tbl_cfgSearch = Maketbl_cfgSearch(dataReader);
					tbl_cfgSearchList.Add(tbl_cfgSearch);
				}
			}
			scon.Close();
			return tbl_cfgSearchList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_cfgSearch class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_cfgSearch Maketbl_cfgSearch(SqlDataReader dataReader) {
			tbl_cfgSearch tbl_cfgSearch = new tbl_cfgSearch();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_cfgSearch.SearchId = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_cfgSearch.SearchName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_cfgSearch.DisplayName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_cfgSearch.SearchTable = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_cfgSearch.Selection1 = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_cfgSearch.Selection2 = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_cfgSearch.Width = dataReader.GetInt32(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_cfgSearch.OrderBy = dataReader.GetString(7);
			}

			return tbl_cfgSearch;
		}
		/// <summary>
		/// This makes tbl_cfgSearch datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_cfgSearch object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_cfgSearch  tbl_cfgSearch   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_searchId = new DataColumn("searchId" , typeof(int));
			DataColumn col_searchName = new DataColumn("searchName" , typeof(string));
			DataColumn col_displayName = new DataColumn("displayName" , typeof(string));
			DataColumn col_searchTable = new DataColumn("searchTable" , typeof(string));
			DataColumn col_selection1 = new DataColumn("selection1" , typeof(string));
			DataColumn col_selection2 = new DataColumn("selection2" , typeof(string));
			DataColumn col_width = new DataColumn("width" , typeof(int));
			DataColumn col_orderBy = new DataColumn("orderBy" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_searchId,col_searchName,col_displayName,col_searchTable,col_selection1,col_selection2,col_width,col_orderBy,});		return dt;
		}
		/// <summary>
		/// This fills tbl_cfgSearch datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_cfgSearch object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_cfgSearch user) {
		DataRow drow = dt.NewRow();
		
			drow["searchId"] = user.searchId;
			drow["searchName"] = user.searchName;
			drow["displayName"] = user.displayName;
			drow["searchTable"] = user.searchTable;
			drow["selection1"] = user.selection1;
			drow["selection2"] = user.selection2;
			drow["width"] = user.width;
			drow["orderBy"] = user.orderBy;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
