using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class srh_Item_Standard {
		#region Fields
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string itemName;
		private string itemSubCategoryName;
		private decimal sellingPrice1;
		private decimal costPrice1;
		private string uomCode;
		private string imagePath;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the srh_Item_Standard class.
		/// </summary>
		public srh_Item_Standard() {
		}
		
		/// <summary>
		/// Initializes a new instance of the srh_Item_Standard class.
		/// </summary>
		public srh_Item_Standard(string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string itemName, string itemSubCategoryName, decimal sellingPrice1, decimal costPrice1, string uomCode, string imagePath) {
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.itemName = itemName;
			this.itemSubCategoryName = itemSubCategoryName;
			this.sellingPrice1 = sellingPrice1;
			this.costPrice1 = costPrice1;
			this.uomCode = uomCode;
			this.imagePath = imagePath;
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
		/// Gets or sets the ItemSubCategory_ID value.
		/// </summary>
		public string ItemSubCategory_ID {
			get { return itemSubCategory_ID; }
			set { itemSubCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubCategory2_ID value.
		/// </summary>
		public string ItemSubCategory2_ID {
			get { return itemSubCategory2_ID; }
			set { itemSubCategory2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo value.
		/// </summary>
		public string ItemSerialNo {
			get { return itemSerialNo; }
			set { itemSerialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo2 value.
		/// </summary>
		public string ItemSerialNo2 {
			get { return itemSerialNo2; }
			set { itemSerialNo2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemName value.
		/// </summary>
		public string ItemName {
			get { return itemName; }
			set { itemName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubCategoryName value.
		/// </summary>
		public string ItemSubCategoryName {
			get { return itemSubCategoryName; }
			set { itemSubCategoryName = value; }
		}
		
		/// <summary>
		/// Gets or sets the SellingPrice1 value.
		/// </summary>
		public decimal SellingPrice1 {
			get { return sellingPrice1; }
			set { sellingPrice1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostPrice1 value.
		/// </summary>
		public decimal CostPrice1 {
			get { return costPrice1; }
			set { costPrice1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the UomCode value.
		/// </summary>
		public string UomCode {
			get { return uomCode; }
			set { uomCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the ImagePath value.
		/// </summary>
		public string ImagePath {
			get { return imagePath; }
			set { imagePath = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Selects a single record from the srh_Item_Standard table.
		/// </summary>
		public static srh_Item_Standard Select(string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			srh_Item_Standard srh_Item_Standardins = new srh_Item_Standard();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_Item_StandardSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					srh_Item_Standardins = Makesrh_Item_Standard(dataReader);
				} else {
					srh_Item_Standardins = null;
				}
			}
			scon.Close();
			return srh_Item_Standardins;
		}
		
		/// <summary>
		/// Selects all records from the srh_Item_Standard table.
		/// </summary>
		public static List<srh_Item_Standard> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_Item_StandardSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<srh_Item_Standard> srh_Item_StandardList = new List<srh_Item_Standard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					srh_Item_Standard srh_Item_Standard = Makesrh_Item_Standard(dataReader);
					srh_Item_StandardList.Add(srh_Item_Standard);
				}
			}
			scon.Close();
			return srh_Item_StandardList;
		}
		
		/// <summary>
		/// Creates a new instance of the srh_Item_Standard class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static srh_Item_Standard Makesrh_Item_Standard(SqlDataReader dataReader) {
			srh_Item_Standard srh_Item_Standard = new srh_Item_Standard();
			
			if (dataReader.IsDBNull(0) == false) {
				srh_Item_Standard.Item_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				srh_Item_Standard.ItemSubCategory_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				srh_Item_Standard.ItemSubCategory2_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				srh_Item_Standard.ItemSerialNo = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				srh_Item_Standard.ItemSerialNo2 = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				srh_Item_Standard.ItemName = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				srh_Item_Standard.ItemSubCategoryName = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				srh_Item_Standard.SellingPrice1 = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				srh_Item_Standard.CostPrice1 = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				srh_Item_Standard.UomCode = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				srh_Item_Standard.ImagePath = dataReader.GetString(10);
			}

			return srh_Item_Standard;
		}		
		#endregion
	}
}
