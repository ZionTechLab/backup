using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaTxJobCard_WIPFlow_Detail {
		#region Fields
		private Int64 sf_Index;
		private Int64 wipout_sf_Index;
		private string item_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxJobCard_WIPFlow_Detail class.
		/// </summary>
		public tbl_prod_pharmaTxJobCard_WIPFlow_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxJobCard_WIPFlow_Detail class.
		/// </summary>
		public tbl_prod_pharmaTxJobCard_WIPFlow_Detail(Int64 sf_Index, Int64 wipout_sf_Index, string item_ID) {
			this.sf_Index = sf_Index;
			this.wipout_sf_Index = wipout_sf_Index;
			this.item_ID = item_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Sf_Index value.
		/// </summary>
		public Int64 Sf_Index {
			get { return sf_Index; }
			set { sf_Index = value; }
		}
		
		/// <summary>
		/// Gets or sets the Wipout_sf_Index value.
		/// </summary>
		public Int64 Wipout_sf_Index {
			get { return wipout_sf_Index; }
			set { wipout_sf_Index = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prod_pharmaTxJobCard_WIPFlow_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_WIPFlow_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@sf_Index", SqlDbType.BigInt);
			scom.Parameters.Add("@wipout_sf_Index", SqlDbType.BigInt);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
 
			scom.Parameters["@sf_Index"].Value = sf_Index;
			scom.Parameters["@wipout_sf_Index"].Value = wipout_sf_Index;
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_pharmaTxJobCard_WIPFlow_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_WIPFlow_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@sf_Index", SqlDbType.BigInt);
			scom.Parameters.Add("@wipout_sf_Index", SqlDbType.BigInt);
			scom.Parameters["@sf_Index"].Value = sf_Index;
 
			scom.Parameters["@wipout_sf_Index"].Value = wipout_sf_Index;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_WIPFlow_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_WIPFlow_DetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_WIPFlow_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllBySf_Index(Int64 sf_Index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_WIPFlow_DetailDeleteAllBySf_Index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@sf_Index", SqlDbType.BigInt);
			scom.Parameters["@sf_Index"].Value = sf_Index;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_WIPFlow_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByWipout_sf_Index(Int64 wipout_sf_Index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_WIPFlow_DetailDeleteAllByWipout_sf_Index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@wipout_sf_Index", SqlDbType.BigInt);
			scom.Parameters["@wipout_sf_Index"].Value = wipout_sf_Index;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_WIPFlow_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard_WIPFlow_Detail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_WIPFlow_DetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_prod_pharmaTxJobCard_WIPFlow_Detail> tbl_prod_pharmaTxJobCard_WIPFlow_DetailList = new List<tbl_prod_pharmaTxJobCard_WIPFlow_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_WIPFlow_Detail tbl_prod_pharmaTxJobCard_WIPFlow_Detail = Maketbl_prod_pharmaTxJobCard_WIPFlow_Detail(dataReader);
					tbl_prod_pharmaTxJobCard_WIPFlow_DetailList.Add(tbl_prod_pharmaTxJobCard_WIPFlow_Detail);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_WIPFlow_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_WIPFlow_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard_WIPFlow_Detail> SelectAllBySf_Index(Int64 sf_Index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_WIPFlow_DetailSelectAllBySf_Index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sf_Index", SqlDbType.BigInt);
			scom.Parameters["@sf_Index"].Value = sf_Index;
				List<tbl_prod_pharmaTxJobCard_WIPFlow_Detail> tbl_prod_pharmaTxJobCard_WIPFlow_DetailList = new List<tbl_prod_pharmaTxJobCard_WIPFlow_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_WIPFlow_Detail tbl_prod_pharmaTxJobCard_WIPFlow_Detail = Maketbl_prod_pharmaTxJobCard_WIPFlow_Detail(dataReader);
					tbl_prod_pharmaTxJobCard_WIPFlow_DetailList.Add(tbl_prod_pharmaTxJobCard_WIPFlow_Detail);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_WIPFlow_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxJobCard_WIPFlow_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxJobCard_WIPFlow_Detail> SelectAllByWipout_sf_Index(Int64 wipout_sf_Index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxJobCard_WIPFlow_DetailSelectAllByWipout_sf_Index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@wipout_sf_Index", SqlDbType.BigInt);
			scom.Parameters["@wipout_sf_Index"].Value = wipout_sf_Index;
				List<tbl_prod_pharmaTxJobCard_WIPFlow_Detail> tbl_prod_pharmaTxJobCard_WIPFlow_DetailList = new List<tbl_prod_pharmaTxJobCard_WIPFlow_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxJobCard_WIPFlow_Detail tbl_prod_pharmaTxJobCard_WIPFlow_Detail = Maketbl_prod_pharmaTxJobCard_WIPFlow_Detail(dataReader);
					tbl_prod_pharmaTxJobCard_WIPFlow_DetailList.Add(tbl_prod_pharmaTxJobCard_WIPFlow_Detail);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxJobCard_WIPFlow_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaTxJobCard_WIPFlow_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaTxJobCard_WIPFlow_Detail Maketbl_prod_pharmaTxJobCard_WIPFlow_Detail(SqlDataReader dataReader) {
			tbl_prod_pharmaTxJobCard_WIPFlow_Detail tbl_prod_pharmaTxJobCard_WIPFlow_Detail = new tbl_prod_pharmaTxJobCard_WIPFlow_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaTxJobCard_WIPFlow_Detail.Sf_Index = dataReader.GetInt64(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaTxJobCard_WIPFlow_Detail.Wipout_sf_Index = dataReader.GetInt64(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_pharmaTxJobCard_WIPFlow_Detail.Item_ID = dataReader.GetString(2);
			}

			return tbl_prod_pharmaTxJobCard_WIPFlow_Detail;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaTxJobCard_WIPFlow_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxJobCard_WIPFlow_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaTxJobCard_WIPFlow_Detail  tbl_prod_pharmaTxJobCard_WIPFlow_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_sf_Index = new DataColumn("sf_Index" , typeof(Int64));
			DataColumn col_wipout_sf_Index = new DataColumn("wipout_sf_Index" , typeof(Int64));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_sf_Index,col_wipout_sf_Index,col_item_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaTxJobCard_WIPFlow_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxJobCard_WIPFlow_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaTxJobCard_WIPFlow_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["sf_Index"] = user.sf_Index;
			drow["wipout_sf_Index"] = user.wipout_sf_Index;
			drow["item_ID"] = user.item_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
