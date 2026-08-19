using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zItemSpecification {
		#region Fields
		private string itemSepcification_ID;
		private string itemCategory_ID;
		private string sepcificationName;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zItemSpecification class.
		/// </summary>
		public tbl_zItemSpecification() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zItemSpecification class.
		/// </summary>
		public tbl_zItemSpecification(string itemSepcification_ID, string itemCategory_ID, string sepcificationName) {
			this.itemSepcification_ID = itemSepcification_ID;
			this.itemCategory_ID = itemCategory_ID;
			this.sepcificationName = sepcificationName;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ItemSepcification_ID value.
		/// </summary>
		public string ItemSepcification_ID {
			get { return itemSepcification_ID; }
			set { itemSepcification_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemCategory_ID value.
		/// </summary>
		public string ItemCategory_ID {
			get { return itemCategory_ID; }
			set { itemCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SepcificationName value.
		/// </summary>
		public string SepcificationName {
			get { return sepcificationName; }
			set { sepcificationName = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zItemSpecification table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSpecificationInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sepcificationName", SqlDbType.VarChar,50);
 
			scom.Parameters["@itemSepcification_ID"].Value = itemSepcification_ID;
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
			scom.Parameters["@sepcificationName"].Value = sepcificationName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zItemSpecification table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSpecificationUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sepcificationName", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@itemSepcification_ID"].Value = itemSepcification_ID;
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
			scom.Parameters["@sepcificationName"].Value = sepcificationName;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zItemSpecification table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSpecificationDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@itemSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSepcification_ID"].Value = itemSepcification_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemSpecification table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemCategory_ID(string itemCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSpecificationDeleteAllByItemCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zItemSpecification table.
		/// </summary>
		public static tbl_zItemSpecification Select(string itemSepcification_ID_Incoming){

			tbl_zItemSpecification tbl_zItemSpecificationins = new tbl_zItemSpecification();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSpecificationSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSepcification_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSepcification_ID"].Value = itemSepcification_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zItemSpecificationins = Maketbl_zItemSpecification(dataReader);
				} else {
					tbl_zItemSpecificationins = null;
				}
			}
			scon.Close();
			return tbl_zItemSpecificationins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemSpecification table.
		/// </summary>
		public static List<tbl_zItemSpecification> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSpecificationSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zItemSpecification> tbl_zItemSpecificationList = new List<tbl_zItemSpecification>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemSpecification tbl_zItemSpecification = Maketbl_zItemSpecification(dataReader);
					tbl_zItemSpecificationList.Add(tbl_zItemSpecification);
				}
			}
			scon.Close();
			return tbl_zItemSpecificationList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemSpecification table by a foreign key.
		/// </summary>
		public static List<tbl_zItemSpecification> SelectAllByItemCategory_ID(string itemCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSpecificationSelectAllByItemCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
				List<tbl_zItemSpecification> tbl_zItemSpecificationList = new List<tbl_zItemSpecification>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemSpecification tbl_zItemSpecification = Maketbl_zItemSpecification(dataReader);
					tbl_zItemSpecificationList.Add(tbl_zItemSpecification);
				}
			}
			scon.Close();
			return tbl_zItemSpecificationList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zItemSpecification class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zItemSpecification Maketbl_zItemSpecification(SqlDataReader dataReader) {
			tbl_zItemSpecification tbl_zItemSpecification = new tbl_zItemSpecification();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zItemSpecification.ItemSepcification_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zItemSpecification.ItemCategory_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zItemSpecification.SepcificationName = dataReader.GetString(2);
			}

			return tbl_zItemSpecification;
		}
		/// <summary>
		/// This makes tbl_zItemSpecification datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zItemSpecification object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zItemSpecification  tbl_zItemSpecification   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_itemSepcification_ID = new DataColumn("itemSepcification_ID" , typeof(string));
			DataColumn col_itemCategory_ID = new DataColumn("itemCategory_ID" , typeof(string));
			DataColumn col_sepcificationName = new DataColumn("sepcificationName" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_itemSepcification_ID,col_itemCategory_ID,col_sepcificationName,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zItemSpecification datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zItemSpecification object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zItemSpecification user) {
		DataRow drow = dt.NewRow();
		
			drow["itemSepcification_ID"] = user.itemSepcification_ID;
			drow["itemCategory_ID"] = user.itemCategory_ID;
			drow["sepcificationName"] = user.sepcificationName;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
