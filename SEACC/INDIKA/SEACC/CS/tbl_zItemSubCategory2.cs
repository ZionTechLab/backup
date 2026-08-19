using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zItemSubCategory2 {
		#region Fields
		private string itemSubCategory2_ID;
		private string itemSubCategory2Name;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zItemSubCategory2 class.
		/// </summary>
		public tbl_zItemSubCategory2() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zItemSubCategory2 class.
		/// </summary>
		public tbl_zItemSubCategory2(string itemSubCategory2_ID, string itemSubCategory2Name) {
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSubCategory2Name = itemSubCategory2Name;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ItemSubCategory2_ID value.
		/// </summary>
		public string ItemSubCategory2_ID {
			get { return itemSubCategory2_ID; }
			set { itemSubCategory2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubCategory2Name value.
		/// </summary>
		public string ItemSubCategory2Name {
			get { return itemSubCategory2Name; }
			set { itemSubCategory2Name = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zItemSubCategory2 table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSubCategory2Insert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2Name", SqlDbType.VarChar,50);
 
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSubCategory2Name"].Value = itemSubCategory2Name;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zItemSubCategory2 table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSubCategory2Update", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2Name", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSubCategory2Name"].Value = itemSubCategory2Name;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zItemSubCategory2 table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSubCategory2Delete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zItemSubCategory2 table.
		/// </summary>
		public static tbl_zItemSubCategory2 Select(string itemSubCategory2_ID_Incoming){

			tbl_zItemSubCategory2 tbl_zItemSubCategory2ins = new tbl_zItemSubCategory2();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSubCategory2Select", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zItemSubCategory2ins = Maketbl_zItemSubCategory2(dataReader);
				} else {
					tbl_zItemSubCategory2ins = null;
				}
			}
			scon.Close();
			return tbl_zItemSubCategory2ins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemSubCategory2 table.
		/// </summary>
		public static List<tbl_zItemSubCategory2> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSubCategory2SelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zItemSubCategory2> tbl_zItemSubCategory2List = new List<tbl_zItemSubCategory2>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemSubCategory2 tbl_zItemSubCategory2 = Maketbl_zItemSubCategory2(dataReader);
					tbl_zItemSubCategory2List.Add(tbl_zItemSubCategory2);
				}
			}
			scon.Close();
			return tbl_zItemSubCategory2List;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zItemSubCategory2 class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zItemSubCategory2 Maketbl_zItemSubCategory2(SqlDataReader dataReader) {
			tbl_zItemSubCategory2 tbl_zItemSubCategory2 = new tbl_zItemSubCategory2();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zItemSubCategory2.ItemSubCategory2_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zItemSubCategory2.ItemSubCategory2Name = dataReader.GetString(1);
			}

			return tbl_zItemSubCategory2;
		}
		/// <summary>
		/// This makes tbl_zItemSubCategory2 datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zItemSubCategory2 object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zItemSubCategory2  tbl_zItemSubCategory2   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSubCategory2Name = new DataColumn("itemSubCategory2Name" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_itemSubCategory2_ID,col_itemSubCategory2Name,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zItemSubCategory2 datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zItemSubCategory2 object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zItemSubCategory2 user) {
		DataRow drow = dt.NewRow();
		
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSubCategory2Name"] = user.itemSubCategory2Name;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
