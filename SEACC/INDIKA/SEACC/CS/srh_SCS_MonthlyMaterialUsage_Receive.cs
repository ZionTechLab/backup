using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class srh_SCS_MonthlyMaterialUsage_Receive {
		#region Fields
		private string storeGoodReceiveNote_ID;
		private DateTime storeGoodReceiveNoteDate;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string itemName;
		private string itemClass_ID;
		private string className;
		private string itemType_ID;
		private string typeName;
		private string itemCategory_ID;
		private string categoryName;
		private string productionJob_ID;
		private string productionJobType_ID;
		private string productionJobTypeName;
		private string toStore_ID;
		private decimal qty;
		private decimal weight;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the srh_SCS_MonthlyMaterialUsage_Receive class.
		/// </summary>
		public srh_SCS_MonthlyMaterialUsage_Receive() {
		}
		
		/// <summary>
		/// Initializes a new instance of the srh_SCS_MonthlyMaterialUsage_Receive class.
		/// </summary>
		public srh_SCS_MonthlyMaterialUsage_Receive(string storeGoodReceiveNote_ID, DateTime storeGoodReceiveNoteDate, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string itemName, string itemClass_ID, string className, string itemType_ID, string typeName, string itemCategory_ID, string categoryName, string productionJob_ID, string productionJobType_ID, string productionJobTypeName, string toStore_ID, decimal qty, decimal weight) {
			this.storeGoodReceiveNote_ID = storeGoodReceiveNote_ID;
			this.storeGoodReceiveNoteDate = storeGoodReceiveNoteDate;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.itemName = itemName;
			this.itemClass_ID = itemClass_ID;
			this.className = className;
			this.itemType_ID = itemType_ID;
			this.typeName = typeName;
			this.itemCategory_ID = itemCategory_ID;
			this.categoryName = categoryName;
			this.productionJob_ID = productionJob_ID;
			this.productionJobType_ID = productionJobType_ID;
			this.productionJobTypeName = productionJobTypeName;
			this.toStore_ID = toStore_ID;
			this.qty = qty;
			this.weight = weight;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the StoreGoodReceiveNote_ID value.
		/// </summary>
		public string StoreGoodReceiveNote_ID {
			get { return storeGoodReceiveNote_ID; }
			set { storeGoodReceiveNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StoreGoodReceiveNoteDate value.
		/// </summary>
		public DateTime StoreGoodReceiveNoteDate {
			get { return storeGoodReceiveNoteDate; }
			set { storeGoodReceiveNoteDate = value; }
		}
		
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
		/// Gets or sets the ItemClass_ID value.
		/// </summary>
		public string ItemClass_ID {
			get { return itemClass_ID; }
			set { itemClass_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ClassName value.
		/// </summary>
		public string ClassName {
			get { return className; }
			set { className = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemType_ID value.
		/// </summary>
		public string ItemType_ID {
			get { return itemType_ID; }
			set { itemType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the TypeName value.
		/// </summary>
		public string TypeName {
			get { return typeName; }
			set { typeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemCategory_ID value.
		/// </summary>
		public string ItemCategory_ID {
			get { return itemCategory_ID; }
			set { itemCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CategoryName value.
		/// </summary>
		public string CategoryName {
			get { return categoryName; }
			set { categoryName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionJob_ID value.
		/// </summary>
		public string ProductionJob_ID {
			get { return productionJob_ID; }
			set { productionJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionJobType_ID value.
		/// </summary>
		public string ProductionJobType_ID {
			get { return productionJobType_ID; }
			set { productionJobType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProductionJobTypeName value.
		/// </summary>
		public string ProductionJobTypeName {
			get { return productionJobTypeName; }
			set { productionJobTypeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ToStore_ID value.
		/// </summary>
		public string ToStore_ID {
			get { return toStore_ID; }
			set { toStore_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Selects all records from the srh_SCS_MonthlyMaterialUsage_Receive table.
		/// </summary>
        public static List<srh_SCS_MonthlyMaterialUsage_Receive> SelectAll(DateTime dateFrom, DateTime dateTo)
        {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_SCS_MonthlyMaterialUsage_ReceiveSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dateTo.AddDays(1).AddMinutes(-1);
				List<srh_SCS_MonthlyMaterialUsage_Receive> srh_SCS_MonthlyMaterialUsage_ReceiveList = new List<srh_SCS_MonthlyMaterialUsage_Receive>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					srh_SCS_MonthlyMaterialUsage_Receive srh_SCS_MonthlyMaterialUsage_Receive = Makesrh_SCS_MonthlyMaterialUsage_Receive(dataReader);
					srh_SCS_MonthlyMaterialUsage_ReceiveList.Add(srh_SCS_MonthlyMaterialUsage_Receive);
				}
			}
			scon.Close();
			return srh_SCS_MonthlyMaterialUsage_ReceiveList;
		}
		
		/// <summary>
		/// Selects all records from the srh_SCS_MonthlyMaterialUsage_Receive table by a foreign key.
		/// </summary>
        public static List<srh_SCS_MonthlyMaterialUsage_Receive> SelectAllByProductionJobType_ID(string productionJobType_ID, DateTime dateFrom, DateTime dateTo)
        {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_SCS_MonthlyMaterialUsage_ReceiveSelectAllByProductionJobType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dateTo.AddDays(1).AddMinutes(-1);
			scom.Parameters.Add("@productionJobType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@productionJobType_ID"].Value = productionJobType_ID;
				List<srh_SCS_MonthlyMaterialUsage_Receive> srh_SCS_MonthlyMaterialUsage_ReceiveList = new List<srh_SCS_MonthlyMaterialUsage_Receive>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					srh_SCS_MonthlyMaterialUsage_Receive srh_SCS_MonthlyMaterialUsage_Receive = Makesrh_SCS_MonthlyMaterialUsage_Receive(dataReader);
					srh_SCS_MonthlyMaterialUsage_ReceiveList.Add(srh_SCS_MonthlyMaterialUsage_Receive);
				}
			}
			scon.Close();
			return srh_SCS_MonthlyMaterialUsage_ReceiveList;
		}
		
		/// <summary>
		/// Selects all records from the srh_SCS_MonthlyMaterialUsage_Receive table by a foreign key.
		/// </summary>
        public static List<srh_SCS_MonthlyMaterialUsage_Receive> SelectAllByItemCategory_ID(string itemCategory_ID, DateTime dateFrom, DateTime dateTo)
        {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_SCS_MonthlyMaterialUsage_ReceiveSelectAllByItemType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dateTo.AddDays(1).AddMinutes(-1);
            scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar, 10);
            scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
				List<srh_SCS_MonthlyMaterialUsage_Receive> srh_SCS_MonthlyMaterialUsage_ReceiveList = new List<srh_SCS_MonthlyMaterialUsage_Receive>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					srh_SCS_MonthlyMaterialUsage_Receive srh_SCS_MonthlyMaterialUsage_Receive = Makesrh_SCS_MonthlyMaterialUsage_Receive(dataReader);
					srh_SCS_MonthlyMaterialUsage_ReceiveList.Add(srh_SCS_MonthlyMaterialUsage_Receive);
				}
			}
			scon.Close();
			return srh_SCS_MonthlyMaterialUsage_ReceiveList;
		}
		
		/// <summary>
		/// Creates a new instance of the srh_SCS_MonthlyMaterialUsage_Receive class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static srh_SCS_MonthlyMaterialUsage_Receive Makesrh_SCS_MonthlyMaterialUsage_Receive(SqlDataReader dataReader) {
			srh_SCS_MonthlyMaterialUsage_Receive srh_SCS_MonthlyMaterialUsage_Receive = new srh_SCS_MonthlyMaterialUsage_Receive();
			
			if (dataReader.IsDBNull(0) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.StoreGoodReceiveNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.StoreGoodReceiveNoteDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.ItemName = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.ItemClass_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.ClassName = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.ItemType_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.TypeName = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.ItemCategory_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.CategoryName = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.ProductionJob_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.ProductionJobType_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.ProductionJobTypeName = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.ToStore_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.Qty = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				srh_SCS_MonthlyMaterialUsage_Receive.Weight = dataReader.GetDecimal(19);
			}

			return srh_SCS_MonthlyMaterialUsage_Receive;
		}		
		#endregion
	}
}
