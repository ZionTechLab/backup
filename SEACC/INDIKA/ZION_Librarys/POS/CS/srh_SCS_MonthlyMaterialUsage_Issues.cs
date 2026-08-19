using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class srh_SCS_MonthlyMaterialUsage_Issues {
		#region Fields
		private string storeGoodIssueNote_ID;
		private DateTime storeGoodIssueNoteDate;
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
		private string fromStore_ID;
		private decimal qty;
		private decimal weight;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the srh_SCS_MonthlyMaterialUsage_Issues class.
		/// </summary>
		public srh_SCS_MonthlyMaterialUsage_Issues() {
		}
		
		/// <summary>
		/// Initializes a new instance of the srh_SCS_MonthlyMaterialUsage_Issues class.
		/// </summary>
		public srh_SCS_MonthlyMaterialUsage_Issues(string storeGoodIssueNote_ID, DateTime storeGoodIssueNoteDate, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string itemName, string itemClass_ID, string className, string itemType_ID, string typeName, string itemCategory_ID, string categoryName, string productionJob_ID, string productionJobType_ID, string productionJobTypeName, string fromStore_ID, decimal qty, decimal weight) {
			this.storeGoodIssueNote_ID = storeGoodIssueNote_ID;
			this.storeGoodIssueNoteDate = storeGoodIssueNoteDate;
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
			this.fromStore_ID = fromStore_ID;
			this.qty = qty;
			this.weight = weight;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the StoreGoodIssueNote_ID value.
		/// </summary>
		public string StoreGoodIssueNote_ID {
			get { return storeGoodIssueNote_ID; }
			set { storeGoodIssueNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the StoreGoodIssueNoteDate value.
		/// </summary>
		public DateTime StoreGoodIssueNoteDate {
			get { return storeGoodIssueNoteDate; }
			set { storeGoodIssueNoteDate = value; }
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
		/// Gets or sets the FromStore_ID value.
		/// </summary>
		public string FromStore_ID {
			get { return fromStore_ID; }
			set { fromStore_ID = value; }
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
		/// Selects all records from the srh_SCS_MonthlyMaterialUsage_Issues table.
		/// </summary>
        public static List<srh_SCS_MonthlyMaterialUsage_Issues> SelectAll(DateTime dateFrom, DateTime dateTo)
        {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_SCS_MonthlyMaterialUsage_IssuesSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dateTo.AddDays(1).AddMinutes(-1);
				List<srh_SCS_MonthlyMaterialUsage_Issues> srh_SCS_MonthlyMaterialUsage_IssuesList = new List<srh_SCS_MonthlyMaterialUsage_Issues>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					srh_SCS_MonthlyMaterialUsage_Issues srh_SCS_MonthlyMaterialUsage_Issues = Makesrh_SCS_MonthlyMaterialUsage_Issues(dataReader);
					srh_SCS_MonthlyMaterialUsage_IssuesList.Add(srh_SCS_MonthlyMaterialUsage_Issues);
				}
			}
			scon.Close();
			return srh_SCS_MonthlyMaterialUsage_IssuesList;
		}
		
		/// <summary>
		/// Selects all records from the srh_SCS_MonthlyMaterialUsage_Issues table by a foreign key.
		/// </summary>
        public static List<srh_SCS_MonthlyMaterialUsage_Issues> SelectAllByProductionJobType_ID(string productionJobType_ID, DateTime dateFrom, DateTime dateTo)
        {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_SCS_MonthlyMaterialUsage_IssuesSelectAllByProductionJobType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dateTo.AddDays(1).AddMinutes(-1);
			scom.Parameters.Add("@productionJobType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@productionJobType_ID"].Value = productionJobType_ID;
				List<srh_SCS_MonthlyMaterialUsage_Issues> srh_SCS_MonthlyMaterialUsage_IssuesList = new List<srh_SCS_MonthlyMaterialUsage_Issues>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					srh_SCS_MonthlyMaterialUsage_Issues srh_SCS_MonthlyMaterialUsage_Issues = Makesrh_SCS_MonthlyMaterialUsage_Issues(dataReader);
					srh_SCS_MonthlyMaterialUsage_IssuesList.Add(srh_SCS_MonthlyMaterialUsage_Issues);
				}
			}
			scon.Close();
			return srh_SCS_MonthlyMaterialUsage_IssuesList;
		}
		
		/// <summary>
		/// Selects all records from the srh_SCS_MonthlyMaterialUsage_Issues table by a foreign key.
		/// </summary>
        public static List<srh_SCS_MonthlyMaterialUsage_Issues> SelectAllByItemCategory_ID(string itemCategory_ID, DateTime dateFrom, DateTime dateTo)
        {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("srh_SCS_MonthlyMaterialUsage_IssuesSelectAllByItemCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();

            scom.Parameters.Add("@dateFrom", SqlDbType.DateTime, 8);
            scom.Parameters["@dateFrom"].Value = dateFrom;
            scom.Parameters.Add("@dateTo", SqlDbType.DateTime, 8);
            scom.Parameters["@dateTo"].Value = dateTo.AddDays(1).AddMinutes(-1);
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
				List<srh_SCS_MonthlyMaterialUsage_Issues> srh_SCS_MonthlyMaterialUsage_IssuesList = new List<srh_SCS_MonthlyMaterialUsage_Issues>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					srh_SCS_MonthlyMaterialUsage_Issues srh_SCS_MonthlyMaterialUsage_Issues = Makesrh_SCS_MonthlyMaterialUsage_Issues(dataReader);
					srh_SCS_MonthlyMaterialUsage_IssuesList.Add(srh_SCS_MonthlyMaterialUsage_Issues);
				}
			}
			scon.Close();
			return srh_SCS_MonthlyMaterialUsage_IssuesList;
		}
		
		/// <summary>
		/// Creates a new instance of the srh_SCS_MonthlyMaterialUsage_Issues class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static srh_SCS_MonthlyMaterialUsage_Issues Makesrh_SCS_MonthlyMaterialUsage_Issues(SqlDataReader dataReader) {
			srh_SCS_MonthlyMaterialUsage_Issues srh_SCS_MonthlyMaterialUsage_Issues = new srh_SCS_MonthlyMaterialUsage_Issues();
			
			if (dataReader.IsDBNull(0) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.StoreGoodIssueNote_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.StoreGoodIssueNoteDate = dataReader.GetDateTime(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.ItemName = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.ItemClass_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.ClassName = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.ItemType_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.TypeName = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.ItemCategory_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.CategoryName = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.ProductionJob_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.ProductionJobType_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.ProductionJobTypeName = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.FromStore_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.Qty = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				srh_SCS_MonthlyMaterialUsage_Issues.Weight = dataReader.GetDecimal(19);
			}

			return srh_SCS_MonthlyMaterialUsage_Issues;
		}		
		#endregion
	}
}
