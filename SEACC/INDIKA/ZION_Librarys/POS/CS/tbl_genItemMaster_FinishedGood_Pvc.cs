using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genItemMaster_FinishedGood_Pvc {
		#region Fields
		private string item_ID;
		private string itemName;
		private string itemCategorySub_ID;
		private string itemCategory_ID;
		private string itemClass_ID;
		private string itemType_ID;
		private string brand_ID;
		private string itemSize_ID;
		private string colour_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_FinishedGood_Pvc class.
		/// </summary>
		public tbl_genItemMaster_FinishedGood_Pvc() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_FinishedGood_Pvc class.
		/// </summary>
		public tbl_genItemMaster_FinishedGood_Pvc(string item_ID, string itemName, string itemCategorySub_ID, string itemCategory_ID, string itemClass_ID, string itemType_ID, string brand_ID, string itemSize_ID, string colour_ID) {
			this.item_ID = item_ID;
			this.itemName = itemName;
			this.itemCategorySub_ID = itemCategorySub_ID;
			this.itemCategory_ID = itemCategory_ID;
			this.itemClass_ID = itemClass_ID;
			this.itemType_ID = itemType_ID;
			this.brand_ID = brand_ID;
			this.itemSize_ID = itemSize_ID;
			this.colour_ID = colour_ID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemName value.
		/// </summary>
		public string ItemName {
			get { return itemName; }
			set { itemName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemCategorySub_ID value.
		/// </summary>
		public string ItemCategorySub_ID {
			get { return itemCategorySub_ID; }
			set { itemCategorySub_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemCategory_ID value.
		/// </summary>
		public string ItemCategory_ID {
			get { return itemCategory_ID; }
			set { itemCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemClass_ID value.
		/// </summary>
		public string ItemClass_ID {
			get { return itemClass_ID; }
			set { itemClass_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemType_ID value.
		/// </summary>
		public string ItemType_ID {
			get { return itemType_ID; }
			set { itemType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Brand_ID value.
		/// </summary>
		public string Brand_ID {
			get { return brand_ID; }
			set { brand_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSize_ID value.
		/// </summary>
		public string ItemSize_ID {
			get { return itemSize_ID; }
			set { itemSize_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Colour_ID value.
		/// </summary>
		public string Colour_ID {
			get { return colour_ID; }
			set { colour_ID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genItemMaster_FinishedGood_Pvc table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSize_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@colour_ID", SqlDbType.VarChar,10);
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@itemCategorySub_ID"].Value = itemCategorySub_ID;
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
			scom.Parameters["@itemClass_ID"].Value = itemClass_ID;
			scom.Parameters["@itemType_ID"].Value = itemType_ID;
			scom.Parameters["@brand_ID"].Value = brand_ID;
			scom.Parameters["@itemSize_ID"].Value = itemSize_ID;
			scom.Parameters["@colour_ID"].Value = colour_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genItemMaster_FinishedGood_Pvc table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSize_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@colour_ID", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@itemCategorySub_ID"].Value = itemCategorySub_ID;
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
			scom.Parameters["@itemClass_ID"].Value = itemClass_ID;
			scom.Parameters["@itemType_ID"].Value = itemType_ID;
			scom.Parameters["@brand_ID"].Value = brand_ID;
			scom.Parameters["@itemSize_ID"].Value = itemSize_ID;
			scom.Parameters["@colour_ID"].Value = colour_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genItemMaster_FinishedGood_Pvc table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood_Pvc table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood_Pvc table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemCategory_ID(string itemCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcDeleteAllByItemCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood_Pvc table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSize_ID(string itemSize_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcDeleteAllByItemSize_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSize_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSize_ID"].Value = itemSize_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood_Pvc table by a foreign key.
		/// </summary>
		public static void DeleteAllByColour_ID(string colour_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcDeleteAllByColour_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@colour_ID", SqlDbType.VarChar,10);
			scom.Parameters["@colour_ID"].Value = colour_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood_Pvc table by a foreign key.
		/// </summary>
		public static void DeleteAllByBrand_ID(string brand_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcDeleteAllByBrand_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters["@brand_ID"].Value = brand_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood_Pvc table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemType_ID(string itemType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcDeleteAllByItemType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemType_ID"].Value = itemType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood_Pvc table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemClass_ID(string itemClass_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcDeleteAllByItemClass_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemClass_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemClass_ID"].Value = itemClass_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood_Pvc table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemCategorySub_ID(string itemCategorySub_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcDeleteAllByItemCategorySub_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategorySub_ID"].Value = itemCategorySub_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genItemMaster_FinishedGood_Pvc table.
		/// </summary>
		public static tbl_genItemMaster_FinishedGood_Pvc Select(string item_ID_Incoming){

			tbl_genItemMaster_FinishedGood_Pvc tbl_genItemMaster_FinishedGood_Pvcins = new tbl_genItemMaster_FinishedGood_Pvc();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItemMaster_FinishedGood_Pvcins = Maketbl_genItemMaster_FinishedGood_Pvc(dataReader);
				} else {
					tbl_genItemMaster_FinishedGood_Pvcins = null;
				}
			}
			scon.Close();
			return tbl_genItemMaster_FinishedGood_Pvcins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood_Pvc table.
		/// </summary>
		public static List<tbl_genItemMaster_FinishedGood_Pvc> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItemMaster_FinishedGood_Pvc> tbl_genItemMaster_FinishedGood_PvcList = new List<tbl_genItemMaster_FinishedGood_Pvc>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_FinishedGood_Pvc tbl_genItemMaster_FinishedGood_Pvc = Maketbl_genItemMaster_FinishedGood_Pvc(dataReader);
					tbl_genItemMaster_FinishedGood_PvcList.Add(tbl_genItemMaster_FinishedGood_Pvc);
				}
			}
			scon.Close();
			return tbl_genItemMaster_FinishedGood_PvcList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood_Pvc table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_FinishedGood_Pvc> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_genItemMaster_FinishedGood_Pvc> tbl_genItemMaster_FinishedGood_PvcList = new List<tbl_genItemMaster_FinishedGood_Pvc>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_FinishedGood_Pvc tbl_genItemMaster_FinishedGood_Pvc = Maketbl_genItemMaster_FinishedGood_Pvc(dataReader);
					tbl_genItemMaster_FinishedGood_PvcList.Add(tbl_genItemMaster_FinishedGood_Pvc);
				}
			}
			scon.Close();
			return tbl_genItemMaster_FinishedGood_PvcList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood_Pvc table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_FinishedGood_Pvc> SelectAllByItemCategory_ID(string itemCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcSelectAllByItemCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
				List<tbl_genItemMaster_FinishedGood_Pvc> tbl_genItemMaster_FinishedGood_PvcList = new List<tbl_genItemMaster_FinishedGood_Pvc>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_FinishedGood_Pvc tbl_genItemMaster_FinishedGood_Pvc = Maketbl_genItemMaster_FinishedGood_Pvc(dataReader);
					tbl_genItemMaster_FinishedGood_PvcList.Add(tbl_genItemMaster_FinishedGood_Pvc);
				}
			}
			scon.Close();
			return tbl_genItemMaster_FinishedGood_PvcList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood_Pvc table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_FinishedGood_Pvc> SelectAllByItemSize_ID(string itemSize_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcSelectAllByItemSize_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSize_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSize_ID"].Value = itemSize_ID;
				List<tbl_genItemMaster_FinishedGood_Pvc> tbl_genItemMaster_FinishedGood_PvcList = new List<tbl_genItemMaster_FinishedGood_Pvc>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_FinishedGood_Pvc tbl_genItemMaster_FinishedGood_Pvc = Maketbl_genItemMaster_FinishedGood_Pvc(dataReader);
					tbl_genItemMaster_FinishedGood_PvcList.Add(tbl_genItemMaster_FinishedGood_Pvc);
				}
			}
			scon.Close();
			return tbl_genItemMaster_FinishedGood_PvcList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood_Pvc table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_FinishedGood_Pvc> SelectAllByColour_ID(string colour_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcSelectAllByColour_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@colour_ID", SqlDbType.VarChar,10);
			scom.Parameters["@colour_ID"].Value = colour_ID;
				List<tbl_genItemMaster_FinishedGood_Pvc> tbl_genItemMaster_FinishedGood_PvcList = new List<tbl_genItemMaster_FinishedGood_Pvc>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_FinishedGood_Pvc tbl_genItemMaster_FinishedGood_Pvc = Maketbl_genItemMaster_FinishedGood_Pvc(dataReader);
					tbl_genItemMaster_FinishedGood_PvcList.Add(tbl_genItemMaster_FinishedGood_Pvc);
				}
			}
			scon.Close();
			return tbl_genItemMaster_FinishedGood_PvcList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood_Pvc table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_FinishedGood_Pvc> SelectAllByBrand_ID(string brand_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcSelectAllByBrand_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters["@brand_ID"].Value = brand_ID;
				List<tbl_genItemMaster_FinishedGood_Pvc> tbl_genItemMaster_FinishedGood_PvcList = new List<tbl_genItemMaster_FinishedGood_Pvc>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_FinishedGood_Pvc tbl_genItemMaster_FinishedGood_Pvc = Maketbl_genItemMaster_FinishedGood_Pvc(dataReader);
					tbl_genItemMaster_FinishedGood_PvcList.Add(tbl_genItemMaster_FinishedGood_Pvc);
				}
			}
			scon.Close();
			return tbl_genItemMaster_FinishedGood_PvcList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood_Pvc table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_FinishedGood_Pvc> SelectAllByItemType_ID(string itemType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcSelectAllByItemType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemType_ID"].Value = itemType_ID;
				List<tbl_genItemMaster_FinishedGood_Pvc> tbl_genItemMaster_FinishedGood_PvcList = new List<tbl_genItemMaster_FinishedGood_Pvc>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_FinishedGood_Pvc tbl_genItemMaster_FinishedGood_Pvc = Maketbl_genItemMaster_FinishedGood_Pvc(dataReader);
					tbl_genItemMaster_FinishedGood_PvcList.Add(tbl_genItemMaster_FinishedGood_Pvc);
				}
			}
			scon.Close();
			return tbl_genItemMaster_FinishedGood_PvcList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood_Pvc table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_FinishedGood_Pvc> SelectAllByItemClass_ID(string itemClass_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcSelectAllByItemClass_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemClass_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemClass_ID"].Value = itemClass_ID;
				List<tbl_genItemMaster_FinishedGood_Pvc> tbl_genItemMaster_FinishedGood_PvcList = new List<tbl_genItemMaster_FinishedGood_Pvc>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_FinishedGood_Pvc tbl_genItemMaster_FinishedGood_Pvc = Maketbl_genItemMaster_FinishedGood_Pvc(dataReader);
					tbl_genItemMaster_FinishedGood_PvcList.Add(tbl_genItemMaster_FinishedGood_Pvc);
				}
			}
			scon.Close();
			return tbl_genItemMaster_FinishedGood_PvcList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood_Pvc table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_FinishedGood_Pvc> SelectAllByItemCategorySub_ID(string itemCategorySub_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGood_PvcSelectAllByItemCategorySub_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategorySub_ID"].Value = itemCategorySub_ID;
				List<tbl_genItemMaster_FinishedGood_Pvc> tbl_genItemMaster_FinishedGood_PvcList = new List<tbl_genItemMaster_FinishedGood_Pvc>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_FinishedGood_Pvc tbl_genItemMaster_FinishedGood_Pvc = Maketbl_genItemMaster_FinishedGood_Pvc(dataReader);
					tbl_genItemMaster_FinishedGood_PvcList.Add(tbl_genItemMaster_FinishedGood_Pvc);
				}
			}
			scon.Close();
			return tbl_genItemMaster_FinishedGood_PvcList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genItemMaster_FinishedGood_Pvc class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItemMaster_FinishedGood_Pvc Maketbl_genItemMaster_FinishedGood_Pvc(SqlDataReader dataReader) {
			tbl_genItemMaster_FinishedGood_Pvc tbl_genItemMaster_FinishedGood_Pvc = new tbl_genItemMaster_FinishedGood_Pvc();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItemMaster_FinishedGood_Pvc.Item_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItemMaster_FinishedGood_Pvc.ItemName = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genItemMaster_FinishedGood_Pvc.ItemCategorySub_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genItemMaster_FinishedGood_Pvc.ItemCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genItemMaster_FinishedGood_Pvc.ItemClass_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genItemMaster_FinishedGood_Pvc.ItemType_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genItemMaster_FinishedGood_Pvc.Brand_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genItemMaster_FinishedGood_Pvc.ItemSize_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genItemMaster_FinishedGood_Pvc.Colour_ID = dataReader.GetString(8);
			}

			return tbl_genItemMaster_FinishedGood_Pvc;
		}
		/// <summary>
		/// This makes tbl_genItemMaster_FinishedGood_Pvc datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_FinishedGood_Pvc object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItemMaster_FinishedGood_Pvc  tbl_genItemMaster_FinishedGood_Pvc   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemName = new DataColumn("itemName" , typeof(string));
			DataColumn col_itemCategorySub_ID = new DataColumn("itemCategorySub_ID" , typeof(string));
			DataColumn col_itemCategory_ID = new DataColumn("itemCategory_ID" , typeof(string));
			DataColumn col_itemClass_ID = new DataColumn("itemClass_ID" , typeof(string));
			DataColumn col_itemType_ID = new DataColumn("itemType_ID" , typeof(string));
			DataColumn col_brand_ID = new DataColumn("brand_ID" , typeof(string));
			DataColumn col_itemSize_ID = new DataColumn("itemSize_ID" , typeof(string));
			DataColumn col_colour_ID = new DataColumn("colour_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_item_ID,col_itemName,col_itemCategorySub_ID,col_itemCategory_ID,col_itemClass_ID,col_itemType_ID,col_brand_ID,col_itemSize_ID,col_colour_ID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItemMaster_FinishedGood_Pvc datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_FinishedGood_Pvc object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItemMaster_FinishedGood_Pvc user) {
		DataRow drow = dt.NewRow();
		
			drow["item_ID"] = user.item_ID;
			drow["itemName"] = user.itemName;
			drow["itemCategorySub_ID"] = user.itemCategorySub_ID;
			drow["itemCategory_ID"] = user.itemCategory_ID;
			drow["itemClass_ID"] = user.itemClass_ID;
			drow["itemType_ID"] = user.itemType_ID;
			drow["brand_ID"] = user.brand_ID;
			drow["itemSize_ID"] = user.itemSize_ID;
			drow["colour_ID"] = user.colour_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
