using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class srh_Item_Standard_Plus {
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
		private string className;
		private string categoryName;
		private string typeName;
		private string imagePath;
		private bool isDeleted;
		private bool isVATinclusive;
		private bool isNBTinclusive;
		private bool isWeightCalculation_Sales;
		private bool isWeightCalculation_Purchase;
		private string itemCategory_ID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the srh_Item_Standard_Plus class.
		/// </summary>
		public srh_Item_Standard_Plus() {
		}
		
		/// <summary>
		/// Initializes a new instance of the srh_Item_Standard_Plus class.
		/// </summary>
		public srh_Item_Standard_Plus(string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string itemName, string itemSubCategoryName, decimal sellingPrice1, decimal costPrice1, string uomCode, string className, string categoryName, string typeName, string imagePath, bool isDeleted, bool isVATinclusive, bool isNBTinclusive, bool isWeightCalculation_Sales, bool isWeightCalculation_Purchase, string itemCategory_ID) {
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
			this.className = className;
			this.categoryName = categoryName;
			this.typeName = typeName;
			this.imagePath = imagePath;
			this.isDeleted = isDeleted;
			this.isVATinclusive = isVATinclusive;
			this.isNBTinclusive = isNBTinclusive;
			this.isWeightCalculation_Sales = isWeightCalculation_Sales;
			this.isWeightCalculation_Purchase = isWeightCalculation_Purchase;
			this.itemCategory_ID = itemCategory_ID;
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
		/// Gets or sets the ClassName value.
		/// </summary>
		public string ClassName {
			get { return className; }
			set { className = value; }
		}
		
		/// <summary>
		/// Gets or sets the CategoryName value.
		/// </summary>
		public string CategoryName {
			get { return categoryName; }
			set { categoryName = value; }
		}
		
		/// <summary>
		/// Gets or sets the TypeName value.
		/// </summary>
		public string TypeName {
			get { return typeName; }
			set { typeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ImagePath value.
		/// </summary>
		public string ImagePath {
			get { return imagePath; }
			set { imagePath = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsVATinclusive value.
		/// </summary>
		public bool IsVATinclusive {
			get { return isVATinclusive; }
			set { isVATinclusive = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsNBTinclusive value.
		/// </summary>
		public bool IsNBTinclusive {
			get { return isNBTinclusive; }
			set { isNBTinclusive = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsWeightCalculation_Sales value.
		/// </summary>
		public bool IsWeightCalculation_Sales {
			get { return isWeightCalculation_Sales; }
			set { isWeightCalculation_Sales = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsWeightCalculation_Purchase value.
		/// </summary>
		public bool IsWeightCalculation_Purchase {
			get { return isWeightCalculation_Purchase; }
			set { isWeightCalculation_Purchase = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemCategory_ID value.
		/// </summary>
		public string ItemCategory_ID {
			get { return itemCategory_ID; }
			set { itemCategory_ID = value; }
		}
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Selects a single record from the srh_Item_Standard_Plus table.
		/// </summary>
		public static srh_Item_Standard_Plus Select(string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			srh_Item_Standard_Plus srh_Item_Standard_Plusins = new srh_Item_Standard_Plus();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_Item_Standard_PlusSelect", scon);
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
					srh_Item_Standard_Plusins = Makesrh_Item_Standard_Plus(dataReader);
				} else {
					srh_Item_Standard_Plusins = null;
				}
			}
			scon.Close();
			return srh_Item_Standard_Plusins;
		}
		
		/// <summary>
		/// Selects all records from the srh_Item_Standard_Plus table.
		/// </summary>
		public static List<srh_Item_Standard_Plus> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_Item_Standard_PlusSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<srh_Item_Standard_Plus> srh_Item_Standard_PlusList = new List<srh_Item_Standard_Plus>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					srh_Item_Standard_Plus srh_Item_Standard_Plus = Makesrh_Item_Standard_Plus(dataReader);
					srh_Item_Standard_PlusList.Add(srh_Item_Standard_Plus);
				}
			}
			scon.Close();
			return srh_Item_Standard_PlusList;
		}
		
		/// <summary>
		/// Selects all records from the srh_Item_Standard_Plus table by a foreign key.
		/// </summary>
		public static List<srh_Item_Standard_Plus> SelectAllByItemCategory_ID(string itemCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_Item_Standard_PlusSelectAllByItemCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
				List<srh_Item_Standard_Plus> srh_Item_Standard_PlusList = new List<srh_Item_Standard_Plus>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					srh_Item_Standard_Plus srh_Item_Standard_Plus = Makesrh_Item_Standard_Plus(dataReader);
					srh_Item_Standard_PlusList.Add(srh_Item_Standard_Plus);
				}
			}
			scon.Close();
			return srh_Item_Standard_PlusList;
		}
		
		/// <summary>
		/// Creates a new instance of the srh_Item_Standard_Plus class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static srh_Item_Standard_Plus Makesrh_Item_Standard_Plus(SqlDataReader dataReader) {
			srh_Item_Standard_Plus srh_Item_Standard_Plus = new srh_Item_Standard_Plus();
			
			if (dataReader.IsDBNull(0) == false) {
				srh_Item_Standard_Plus.Item_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				srh_Item_Standard_Plus.ItemSubCategory_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				srh_Item_Standard_Plus.ItemSubCategory2_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				srh_Item_Standard_Plus.ItemSerialNo = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				srh_Item_Standard_Plus.ItemSerialNo2 = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				srh_Item_Standard_Plus.ItemName = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				srh_Item_Standard_Plus.ItemSubCategoryName = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				srh_Item_Standard_Plus.SellingPrice1 = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				srh_Item_Standard_Plus.CostPrice1 = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				srh_Item_Standard_Plus.UomCode = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				srh_Item_Standard_Plus.ClassName = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				srh_Item_Standard_Plus.CategoryName = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				srh_Item_Standard_Plus.TypeName = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				srh_Item_Standard_Plus.ImagePath = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				srh_Item_Standard_Plus.IsDeleted = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				srh_Item_Standard_Plus.IsVATinclusive = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				srh_Item_Standard_Plus.IsNBTinclusive = dataReader.GetBoolean(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				srh_Item_Standard_Plus.IsWeightCalculation_Sales = dataReader.GetBoolean(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				srh_Item_Standard_Plus.IsWeightCalculation_Purchase = dataReader.GetBoolean(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				srh_Item_Standard_Plus.ItemCategory_ID = dataReader.GetString(19);
			}

			return srh_Item_Standard_Plus;
		}		
		#endregion
	}
}
