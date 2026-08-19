using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_cfgSearchDetail {
		#region Fields
		private int searchId;
		private int fieldOrder;
		private string fieldName;
		private string displayName;
		private string datatype;
		private int size;
		private bool isFilter;
		private int filterOrder;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_cfgSearchDetail class.
		/// </summary>
		public tbl_cfgSearchDetail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_cfgSearchDetail class.
		/// </summary>
		public tbl_cfgSearchDetail(int searchId, int fieldOrder, string fieldName, string displayName, string datatype, int size, bool isFilter, int filterOrder) {
			this.searchId = searchId;
			this.fieldOrder = fieldOrder;
			this.fieldName = fieldName;
			this.displayName = displayName;
			this.datatype = datatype;
			this.size = size;
			this.isFilter = isFilter;
			this.filterOrder = filterOrder;
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
		/// Gets or sets the FieldOrder value.
		/// </summary>
		public int FieldOrder {
			get { return fieldOrder; }
			set { fieldOrder = value; }
		}
		
		/// <summary>
		/// Gets or sets the FieldName value.
		/// </summary>
		public string FieldName {
			get { return fieldName; }
			set { fieldName = value; }
		}
		
		/// <summary>
		/// Gets or sets the DisplayName value.
		/// </summary>
		public string DisplayName {
			get { return displayName; }
			set { displayName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Datatype value.
		/// </summary>
		public string Datatype {
			get { return datatype; }
			set { datatype = value; }
		}
		
		/// <summary>
		/// Gets or sets the Size value.
		/// </summary>
		public int Size {
			get { return size; }
			set { size = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsFilter value.
		/// </summary>
		public bool IsFilter {
			get { return isFilter; }
			set { isFilter = value; }
		}
		
		/// <summary>
		/// Gets or sets the FilterOrder value.
		/// </summary>
		public int FilterOrder {
			get { return filterOrder; }
			set { filterOrder = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_cfgSearchDetail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgSearchDetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@searchId", SqlDbType.Int,4);
			scom.Parameters.Add("@fieldOrder", SqlDbType.Int,4);
			scom.Parameters.Add("@fieldName", SqlDbType.VarChar,400);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@datatype", SqlDbType.VarChar,1);
			scom.Parameters.Add("@size", SqlDbType.Int,4);
			scom.Parameters.Add("@isFilter", SqlDbType.Bit,1);
			scom.Parameters.Add("@FilterOrder", SqlDbType.Int,4);
 
			scom.Parameters["@searchId"].Value = searchId;
			scom.Parameters["@fieldOrder"].Value = fieldOrder;
			scom.Parameters["@fieldName"].Value = fieldName;
			scom.Parameters["@displayName"].Value = displayName;
			scom.Parameters["@datatype"].Value = datatype;
			scom.Parameters["@size"].Value = size;
			scom.Parameters["@isFilter"].Value = isFilter;
			scom.Parameters["@FilterOrder"].Value = filterOrder;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_cfgSearchDetail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgSearchDetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@searchId", SqlDbType.Int,4);
			scom.Parameters.Add("@fieldOrder", SqlDbType.Int,4);
			scom.Parameters.Add("@fieldName", SqlDbType.VarChar,400);
			scom.Parameters.Add("@displayName", SqlDbType.VarChar,20);
			scom.Parameters.Add("@datatype", SqlDbType.VarChar,1);
			scom.Parameters.Add("@size", SqlDbType.Int,4);
			scom.Parameters.Add("@isFilter", SqlDbType.Bit,1);
			scom.Parameters.Add("@FilterOrder", SqlDbType.Int,4);
 
 
			scom.Parameters["@searchId"].Value = searchId;
			scom.Parameters["@fieldOrder"].Value = fieldOrder;
			scom.Parameters["@fieldName"].Value = fieldName;
			scom.Parameters["@displayName"].Value = displayName;
			scom.Parameters["@datatype"].Value = datatype;
			scom.Parameters["@size"].Value = size;
			scom.Parameters["@isFilter"].Value = isFilter;
			scom.Parameters["@FilterOrder"].Value = filterOrder;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_cfgSearchDetail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgSearchDetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@searchId", SqlDbType.Int,4);
			scom.Parameters.Add("@fieldOrder", SqlDbType.Int,4);
			scom.Parameters["@searchId"].Value = searchId;
 
			scom.Parameters["@fieldOrder"].Value = fieldOrder;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_cfgSearchDetail table.
		/// </summary>
		public static tbl_cfgSearchDetail Select(int searchId_Incoming, int fieldOrder_Incoming){

			tbl_cfgSearchDetail tbl_cfgSearchDetailins = new tbl_cfgSearchDetail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgSearchDetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@searchId", SqlDbType.Int,4);
			scom.Parameters.Add("@fieldOrder", SqlDbType.Int,4);
			scom.Parameters["@searchId"].Value = searchId_Incoming;
			scom.Parameters["@fieldOrder"].Value = fieldOrder_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_cfgSearchDetailins = Maketbl_cfgSearchDetail(dataReader);
				} else {
					tbl_cfgSearchDetailins = null;
				}
			}
			scon.Close();
			return tbl_cfgSearchDetailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_cfgSearchDetail table.
		/// </summary>
		public static List<tbl_cfgSearchDetail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgSearchDetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_cfgSearchDetail> tbl_cfgSearchDetailList = new List<tbl_cfgSearchDetail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_cfgSearchDetail tbl_cfgSearchDetail = Maketbl_cfgSearchDetail(dataReader);
					tbl_cfgSearchDetailList.Add(tbl_cfgSearchDetail);
				}
			}
			scon.Close();
			return tbl_cfgSearchDetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_cfgSearchDetail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_cfgSearchDetail Maketbl_cfgSearchDetail(SqlDataReader dataReader) {
			tbl_cfgSearchDetail tbl_cfgSearchDetail = new tbl_cfgSearchDetail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_cfgSearchDetail.SearchId = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_cfgSearchDetail.FieldOrder = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_cfgSearchDetail.FieldName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_cfgSearchDetail.DisplayName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_cfgSearchDetail.Datatype = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_cfgSearchDetail.Size = dataReader.GetInt32(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_cfgSearchDetail.IsFilter = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_cfgSearchDetail.FilterOrder = dataReader.GetInt32(7);
			}

			return tbl_cfgSearchDetail;
		}
		/// <summary>
		/// This makes tbl_cfgSearchDetail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_cfgSearchDetail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_cfgSearchDetail  tbl_cfgSearchDetail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_searchId = new DataColumn("searchId" , typeof(int));
			DataColumn col_fieldOrder = new DataColumn("fieldOrder" , typeof(int));
			DataColumn col_fieldName = new DataColumn("fieldName" , typeof(string));
			DataColumn col_displayName = new DataColumn("displayName" , typeof(string));
			DataColumn col_datatype = new DataColumn("datatype" , typeof(string));
			DataColumn col_size = new DataColumn("size" , typeof(int));
			DataColumn col_isFilter = new DataColumn("isFilter" , typeof(bool));
			DataColumn col_FilterOrder = new DataColumn("FilterOrder" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_searchId,col_fieldOrder,col_fieldName,col_displayName,col_datatype,col_size,col_isFilter,col_FilterOrder,});		return dt;
		}
		/// <summary>
		/// This fills tbl_cfgSearchDetail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_cfgSearchDetail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_cfgSearchDetail user) {
		DataRow drow = dt.NewRow();
		
			drow["searchId"] = user.searchId;
			drow["fieldOrder"] = user.fieldOrder;
			drow["fieldName"] = user.fieldName;
			drow["displayName"] = user.displayName;
			drow["datatype"] = user.datatype;
			drow["size"] = user.size;
			drow["isFilter"] = user.isFilter;
			drow["FilterOrder"] = user.FilterOrder;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
