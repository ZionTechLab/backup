using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_cfgThemeElement {
		#region Fields
		private int elementID;
		private string elementName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_cfgThemeElement class.
		/// </summary>
		public tbl_cfgThemeElement() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_cfgThemeElement class.
		/// </summary>
		public tbl_cfgThemeElement(int elementID, string elementName) {
			this.elementID = elementID;
			this.elementName = elementName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ElementID value.
		/// </summary>
		public int ElementID {
			get { return elementID; }
			set { elementID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ElementName value.
		/// </summary>
		public string ElementName {
			get { return elementName; }
			set { elementName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_cfgThemeElement table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeElementInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@elementID", SqlDbType.Int,4);
			scom.Parameters.Add("@elementName", SqlDbType.VarChar,50);
 
			scom.Parameters["@elementID"].Value = elementID;
			scom.Parameters["@elementName"].Value = elementName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_cfgThemeElement table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeElementUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@elementID", SqlDbType.Int,4);
			scom.Parameters.Add("@elementName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@elementID"].Value = elementID;
			scom.Parameters["@elementName"].Value = elementName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_cfgThemeElement table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeElementDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@elementID", SqlDbType.Int,4);
			scom.Parameters["@elementID"].Value = elementID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_cfgThemeElement table.
		/// </summary>
		public static tbl_cfgThemeElement Select(int elementID_Incoming){

			tbl_cfgThemeElement tbl_cfgThemeElementins = new tbl_cfgThemeElement();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeElementSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@elementID", SqlDbType.Int,4);
			scom.Parameters["@elementID"].Value = elementID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_cfgThemeElementins = Maketbl_cfgThemeElement(dataReader);
				} else {
					tbl_cfgThemeElementins = null;
				}
			}
			scon.Close();
			return tbl_cfgThemeElementins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_cfgThemeElement table.
		/// </summary>
		public static List<tbl_cfgThemeElement> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_cfgThemeElementSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_cfgThemeElement> tbl_cfgThemeElementList = new List<tbl_cfgThemeElement>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_cfgThemeElement tbl_cfgThemeElement = Maketbl_cfgThemeElement(dataReader);
					tbl_cfgThemeElementList.Add(tbl_cfgThemeElement);
				}
			}
			scon.Close();
			return tbl_cfgThemeElementList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_cfgThemeElement class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_cfgThemeElement Maketbl_cfgThemeElement(SqlDataReader dataReader) {
			tbl_cfgThemeElement tbl_cfgThemeElement = new tbl_cfgThemeElement();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_cfgThemeElement.ElementID = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_cfgThemeElement.ElementName = dataReader.GetString(1);
			}

			return tbl_cfgThemeElement;
		}
		/// <summary>
		/// This makes tbl_cfgThemeElement datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_cfgThemeElement object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_cfgThemeElement  tbl_cfgThemeElement   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_elementID = new DataColumn("elementID" , typeof(int));
			DataColumn col_elementName = new DataColumn("elementName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_elementID,col_elementName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_cfgThemeElement datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_cfgThemeElement object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_cfgThemeElement user) {
		DataRow drow = dt.NewRow();
		
			drow["elementID"] = user.elementID;
			drow["elementName"] = user.elementName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
