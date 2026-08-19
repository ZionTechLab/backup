using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zAccSlotCategory {
		#region Fields
		private string slotCategory_ID;
		private string slotCategoryName;
		private string prefix;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zAccSlotCategory class.
		/// </summary>
		public tbl_zAccSlotCategory() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zAccSlotCategory class.
		/// </summary>
		public tbl_zAccSlotCategory(string slotCategory_ID, string slotCategoryName, string prefix) {
			this.slotCategory_ID = slotCategory_ID;
			this.slotCategoryName = slotCategoryName;
			this.prefix = prefix;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the SlotCategory_ID value.
		/// </summary>
		public string SlotCategory_ID {
			get { return slotCategory_ID; }
			set { slotCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SlotCategoryName value.
		/// </summary>
		public string SlotCategoryName {
			get { return slotCategoryName; }
			set { slotCategoryName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Prefix value.
		/// </summary>
		public string Prefix {
			get { return prefix; }
			set { prefix = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zAccSlotCategory table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccSlotCategoryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@slotCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@slotCategoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,10);
 
			scom.Parameters["@slotCategory_ID"].Value = slotCategory_ID;
			scom.Parameters["@slotCategoryName"].Value = slotCategoryName;
			scom.Parameters["@prefix"].Value = prefix;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zAccSlotCategory table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccSlotCategoryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@slotCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@slotCategoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@prefix", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@slotCategory_ID"].Value = slotCategory_ID;
			scom.Parameters["@slotCategoryName"].Value = slotCategoryName;
			scom.Parameters["@prefix"].Value = prefix;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zAccSlotCategory table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccSlotCategoryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@slotCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@slotCategory_ID"].Value = slotCategory_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zAccSlotCategory table.
		/// </summary>
		public static tbl_zAccSlotCategory Select(string slotCategory_ID_Incoming){

			tbl_zAccSlotCategory tbl_zAccSlotCategoryins = new tbl_zAccSlotCategory();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccSlotCategorySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@slotCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@slotCategory_ID"].Value = slotCategory_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zAccSlotCategoryins = Maketbl_zAccSlotCategory(dataReader);
				} else {
					tbl_zAccSlotCategoryins = null;
				}
			}
			scon.Close();
			return tbl_zAccSlotCategoryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zAccSlotCategory table.
		/// </summary>
		public static List<tbl_zAccSlotCategory> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zAccSlotCategorySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zAccSlotCategory> tbl_zAccSlotCategoryList = new List<tbl_zAccSlotCategory>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zAccSlotCategory tbl_zAccSlotCategory = Maketbl_zAccSlotCategory(dataReader);
					tbl_zAccSlotCategoryList.Add(tbl_zAccSlotCategory);
				}
			}
			scon.Close();
			return tbl_zAccSlotCategoryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zAccSlotCategory class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zAccSlotCategory Maketbl_zAccSlotCategory(SqlDataReader dataReader) {
			tbl_zAccSlotCategory tbl_zAccSlotCategory = new tbl_zAccSlotCategory();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zAccSlotCategory.SlotCategory_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zAccSlotCategory.SlotCategoryName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zAccSlotCategory.Prefix = dataReader.GetString(2);
			}

			return tbl_zAccSlotCategory;
		}
		/// <summary>
		/// This makes tbl_zAccSlotCategory datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zAccSlotCategory object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zAccSlotCategory  tbl_zAccSlotCategory   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_slotCategory_ID = new DataColumn("slotCategory_ID" , typeof(string));
			DataColumn col_slotCategoryName = new DataColumn("slotCategoryName" , typeof(string));
			DataColumn col_prefix = new DataColumn("prefix" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_slotCategory_ID,col_slotCategoryName,col_prefix,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zAccSlotCategory datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zAccSlotCategory object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zAccSlotCategory user) {
		DataRow drow = dt.NewRow();
		
			drow["slotCategory_ID"] = user.slotCategory_ID;
			drow["slotCategoryName"] = user.slotCategoryName;
			drow["prefix"] = user.prefix;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
