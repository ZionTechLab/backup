using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_rpt_FloorStock_DAPL {
		#region Fields		
		private string storeName;
		private string item_ID;
		private string refNo;
		private string itemName;
		private string className;
		private string typeName;
		private string categoryName;
		private string metalDetail;
		private string gemDetail;
		private string uomName;
		private decimal weight;
		private decimal qty;
		private decimal unitCost;
		private decimal costPrice;
		private string itemSerialNo;
		private string categorySubName;
		private string store_ID;
		private string itemType_ID;
		private string itemCategory_ID;
		private string itemClass_ID;
		private string gemID;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_rpt_FloorStock_DAPL class.
		/// </summary>
		public tbl_rpt_FloorStock_DAPL() {
		}
		
        ///// <summary>
        ///// Initializes a new instance of the tbl_rpt_FloorStock_DAPL class.
        ///// </summary>
        //public tbl_rpt_FloorStock_DAPL(string storeName, string item_ID, string refNo, string itemName, string className, string typeName, string categoryName, string metalDetail, string gemDetail, string uomName, decimal weight, decimal qty, decimal unitCost, decimal costPrice, string itemSerialNo, string categorySubName, string store_ID, string itemType_ID, string itemCategory_ID, string itemClass_ID, string gemID) {
        //    this.storeName = storeName;
        //    this.item_ID = item_ID;
        //    this.refNo = refNo;
        //    this.itemName = itemName;
        //    this.className = className;
        //    this.typeName = typeName;
        //    this.categoryName = categoryName;
        //    this.metalDetail = metalDetail;
        //    this.gemDetail = gemDetail;
        //    this.uomName = uomName;
        //    this.weight = weight;
        //    this.qty = qty;
        //    this.unitCost = unitCost;
        //    this.costPrice = costPrice;
        //    this.itemSerialNo = itemSerialNo;
        //    this.categorySubName = categorySubName;
        //    this.store_ID = store_ID;
        //    this.itemType_ID = itemType_ID;
        //    this.itemCategory_ID = itemCategory_ID;
        //    this.itemClass_ID = itemClass_ID;
        //    this.gemID = gemID;
        //}
		
		/// <summary>
		/// Initializes a new instance of the tbl_rpt_FloorStock_DAPL class.
		/// </summary>
		public tbl_rpt_FloorStock_DAPL(string storeName, string item_ID, string refNo, string itemName, string className, string typeName, string categoryName, string metalDetail, string gemDetail, string uomName, decimal weight, decimal qty, decimal unitCost, decimal costPrice, string itemSerialNo, string categorySubName, string store_ID, string itemType_ID, string itemCategory_ID, string itemClass_ID, string gemID) {
			
			this.storeName = storeName;
			this.item_ID = item_ID;
			this.refNo = refNo;
			this.itemName = itemName;
			this.className = className;
			this.typeName = typeName;
			this.categoryName = categoryName;
			this.metalDetail = metalDetail;
			this.gemDetail = gemDetail;
			this.uomName = uomName;
			this.weight = weight;
			this.qty = qty;
			this.unitCost = unitCost;
			this.costPrice = costPrice;
			this.itemSerialNo = itemSerialNo;
			this.categorySubName = categorySubName;
			this.store_ID = store_ID;
			this.itemType_ID = itemType_ID;
			this.itemCategory_ID = itemCategory_ID;
			this.itemClass_ID = itemClass_ID;
			this.gemID = gemID;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_no value.
		/// </summary>		
		
		/// <summary>
		/// Gets or sets the StoreName value.
		/// </summary>
		public string StoreName {
			get { return storeName; }
			set { storeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the RefNo value.
		/// </summary>
		public string RefNo {
			get { return refNo; }
			set { refNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemName value.
		/// </summary>
		public string ItemName {
			get { return itemName; }
			set { itemName = value; }
		}
		
		/// <summary>
		/// Gets or sets the ClassName value.
		/// </summary>
		public string ClassName {
			get { return className; }
			set { className = value; }
		}
		
		/// <summary>
		/// Gets or sets the TypeName value.
		/// </summary>
		public string TypeName {
			get { return typeName; }
			set { typeName = value; }
		}
		
		/// <summary>
		/// Gets or sets the CategoryName value.
		/// </summary>
		public string CategoryName {
			get { return categoryName; }
			set { categoryName = value; }
		}
		
		/// <summary>
		/// Gets or sets the MetalDetail value.
		/// </summary>
		public string MetalDetail {
			get { return metalDetail; }
			set { metalDetail = value; }
		}
		
		/// <summary>
		/// Gets or sets the GemDetail value.
		/// </summary>
		public string GemDetail {
			get { return gemDetail; }
			set { gemDetail = value; }
		}
		
		/// <summary>
		/// Gets or sets the UomName value.
		/// </summary>
		public string UomName {
			get { return uomName; }
			set { uomName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitCost value.
		/// </summary>
		public decimal UnitCost {
			get { return unitCost; }
			set { unitCost = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostPrice value.
		/// </summary>
		public decimal CostPrice {
			get { return costPrice; }
			set { costPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo value.
		/// </summary>
		public string ItemSerialNo {
			get { return itemSerialNo; }
			set { itemSerialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the CategorySubName value.
		/// </summary>
		public string CategorySubName {
			get { return categorySubName; }
			set { categorySubName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemType_ID value.
		/// </summary>
		public string ItemType_ID {
			get { return itemType_ID; }
			set { itemType_ID = value; }
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
		/// Gets or sets the GemID value.
		/// </summary>
		public string GemID {
			get { return gemID; }
			set { gemID = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_rpt_FloorStock_DAPL table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rpt_FloorStock_DAPLInsert", scon);
			scom.CommandType = CommandType.StoredProcedure; 
 
			scom.Parameters.Add("@storeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@refNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@className", SqlDbType.VarChar,50);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@categoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@metalDetail", SqlDbType.VarChar,50);
			scom.Parameters.Add("@gemDetail", SqlDbType.VarChar,50);
			scom.Parameters.Add("@uomName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@UnitCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@CostPrice", SqlDbType.Decimal,17);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@categorySubName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gemID", SqlDbType.VarChar,10);
 
			scom.Parameters["@storeName"].Value = storeName;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@refNo"].Value = refNo;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@className"].Value = className;
			scom.Parameters["@typeName"].Value = typeName;
			scom.Parameters["@categoryName"].Value = categoryName;
			scom.Parameters["@metalDetail"].Value = metalDetail;
			scom.Parameters["@gemDetail"].Value = gemDetail;
			scom.Parameters["@uomName"].Value = uomName;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@UnitCost"].Value = unitCost;
			scom.Parameters["@CostPrice"].Value = costPrice;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@categorySubName"].Value = categorySubName;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@itemType_ID"].Value = itemType_ID;
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
			scom.Parameters["@itemClass_ID"].Value = itemClass_ID;
			scom.Parameters["@gemID"].Value = gemID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_rpt_FloorStock_DAPL table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rpt_FloorStock_DAPLUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure; 
 
			scom.Parameters.Add("@storeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@refNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@className", SqlDbType.VarChar,50);
			scom.Parameters.Add("@typeName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@categoryName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@metalDetail", SqlDbType.VarChar,50);
			scom.Parameters.Add("@gemDetail", SqlDbType.VarChar,50);
			scom.Parameters.Add("@uomName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@UnitCost", SqlDbType.Decimal,9);
			scom.Parameters.Add("@CostPrice", SqlDbType.Decimal,17);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@categorySubName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@gemID", SqlDbType.VarChar,10);
 
 
			scom.Parameters["@storeName"].Value = storeName;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@refNo"].Value = refNo;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@className"].Value = className;
			scom.Parameters["@typeName"].Value = typeName;
			scom.Parameters["@categoryName"].Value = categoryName;
			scom.Parameters["@metalDetail"].Value = metalDetail;
			scom.Parameters["@gemDetail"].Value = gemDetail;
			scom.Parameters["@uomName"].Value = uomName;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@UnitCost"].Value = unitCost;
			scom.Parameters["@CostPrice"].Value = costPrice;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@categorySubName"].Value = categorySubName;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@itemType_ID"].Value = itemType_ID;
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
			scom.Parameters["@itemClass_ID"].Value = itemClass_ID;
			scom.Parameters["@gemID"].Value = gemID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		
		
		/// <summary>
		/// Selects a single record from the tbl_rpt_FloorStock_DAPL table.
		/// </summary>
		public static tbl_rpt_FloorStock_DAPL Select(int line_no_Incoming){

			tbl_rpt_FloorStock_DAPL tbl_rpt_FloorStock_DAPLins = new tbl_rpt_FloorStock_DAPL();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_rpt_FloorStock_DAPLSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_no", SqlDbType.Int,4);
			scom.Parameters["@line_no"].Value = line_no_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_rpt_FloorStock_DAPLins = Maketbl_rpt_FloorStock_DAPL(dataReader);
				} else {
					tbl_rpt_FloorStock_DAPLins = null;
				}
			}
			scon.Close();
			return tbl_rpt_FloorStock_DAPLins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_rpt_FloorStock_DAPL table.
		/// </summary>
        public static List<tbl_rpt_FloorStock_DAPL> SelectAll_without_GemID(string sStoreID, string sItemTypeID, string sItemCategoryID, string sItemName,
            string sItemClass, string sReference, string sGemID)
        {
 
			SqlConnection scon = DBHandling.GetConnection();
            SqlCommand command = new SqlCommand("sp_FloorStock_WithOut_GemFilter", scon);
            command.CommandType = CommandType.StoredProcedure;

            command.CommandTimeout = 600;

            if (sStoreID == null)
                command.Parameters.Add("@store", SqlDbType.VarChar).Value = DBNull.Value;
            else
                command.Parameters.Add("@store", SqlDbType.VarChar).Value = sStoreID;

            if (sItemTypeID == null)
                command.Parameters.Add("@itemType", SqlDbType.VarChar).Value = DBNull.Value;
            else
                command.Parameters.Add("@itemType", SqlDbType.VarChar).Value = sItemTypeID;

            if (sItemCategoryID == null)
                command.Parameters.Add("@ItemCategory", SqlDbType.VarChar).Value = DBNull.Value;
            else
                command.Parameters.Add("@ItemCategory", SqlDbType.VarChar).Value = sItemCategoryID;

            if (sItemName == null)
                command.Parameters.Add("@itemName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                command.Parameters.Add("@itemName", SqlDbType.VarChar).Value = sItemName;

            if (sItemClass == null)
                command.Parameters.Add("@itemClass", SqlDbType.VarChar).Value = DBNull.Value;
            else
                command.Parameters.Add("@itemClass", SqlDbType.VarChar).Value = sItemClass;

            if (sReference == null)
                command.Parameters.Add("@reference", SqlDbType.VarChar).Value = DBNull.Value;
            else
                command.Parameters.Add("@reference", SqlDbType.VarChar).Value = sReference;

            if (sGemID == null)
                command.Parameters.Add("@gem", SqlDbType.VarChar).Value = DBNull.Value;
            else
                command.Parameters.Add("@gem", SqlDbType.VarChar).Value = sGemID;
            
            scon.Open();
            command.ExecuteNonQuery();

				List<tbl_rpt_FloorStock_DAPL> tbl_rpt_FloorStock_DAPLList = new List<tbl_rpt_FloorStock_DAPL>();
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        tbl_rpt_FloorStock_DAPL tbl_rpt_FloorStock_DAPL = Maketbl_rpt_FloorStock_DAPL(dataReader);
                        tbl_rpt_FloorStock_DAPLList.Add(tbl_rpt_FloorStock_DAPL);
                    }
                }

			scon.Close();
			return tbl_rpt_FloorStock_DAPLList;
		}


        /// <summary>
        /// Selects all records from the tbl_rpt_FloorStock_DAPL table.
        /// </summary>
        public static List<tbl_rpt_FloorStock_DAPL> SelectAll_with_GemID(string sStoreID, string sItemTypeID, string sItemCategoryID, string sItemName,
            string sItemClass, string sReference, string sGemID)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand command = new SqlCommand("sp_FloorStock", scon);
            command.CommandType = CommandType.StoredProcedure;

            command.CommandTimeout = 600;

            if (sStoreID == null)
                command.Parameters.Add("@store", SqlDbType.VarChar).Value = DBNull.Value;
            else
                command.Parameters.Add("@store", SqlDbType.VarChar).Value = sStoreID;

            if (sItemTypeID == null)
                command.Parameters.Add("@itemType", SqlDbType.VarChar).Value = DBNull.Value;
            else
                command.Parameters.Add("@itemType", SqlDbType.VarChar).Value = sItemTypeID;

            if (sItemCategoryID == null)
                command.Parameters.Add("@ItemCategory", SqlDbType.VarChar).Value = DBNull.Value;
            else
                command.Parameters.Add("@ItemCategory", SqlDbType.VarChar).Value = sItemCategoryID;

            if (sItemName == null)
                command.Parameters.Add("@itemName", SqlDbType.VarChar).Value = DBNull.Value;
            else
                command.Parameters.Add("@itemName", SqlDbType.VarChar).Value = sItemName;

            if (sItemClass == null)
                command.Parameters.Add("@itemClass", SqlDbType.VarChar).Value = DBNull.Value;
            else
                command.Parameters.Add("@itemClass", SqlDbType.VarChar).Value = sItemClass;

            if (sReference == null)
                command.Parameters.Add("@reference", SqlDbType.VarChar).Value = DBNull.Value;
            else
                command.Parameters.Add("@reference", SqlDbType.VarChar).Value = sReference;

            if (sGemID == null)
                command.Parameters.Add("@gem", SqlDbType.VarChar).Value = DBNull.Value;
            else
                command.Parameters.Add("@gem", SqlDbType.VarChar).Value = sGemID;

            scon.Open();
            command.ExecuteNonQuery();

            List<tbl_rpt_FloorStock_DAPL> tbl_rpt_FloorStock_DAPLList = new List<tbl_rpt_FloorStock_DAPL>();
            using (SqlDataReader dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_rpt_FloorStock_DAPL tbl_rpt_FloorStock_DAPL = Maketbl_rpt_FloorStock_DAPL(dataReader);
                    tbl_rpt_FloorStock_DAPLList.Add(tbl_rpt_FloorStock_DAPL);
                }
            }

            scon.Close();
            return tbl_rpt_FloorStock_DAPLList;
        }
		
		/// <summary>
		/// Creates a new instance of the tbl_rpt_FloorStock_DAPL class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_rpt_FloorStock_DAPL Maketbl_rpt_FloorStock_DAPL(SqlDataReader dataReader) {
			tbl_rpt_FloorStock_DAPL tbl_rpt_FloorStock_DAPL = new tbl_rpt_FloorStock_DAPL();
			
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_rpt_FloorStock_DAPL.StoreName = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_rpt_FloorStock_DAPL.Item_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_rpt_FloorStock_DAPL.RefNo = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_rpt_FloorStock_DAPL.ItemName = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_rpt_FloorStock_DAPL.ClassName = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_rpt_FloorStock_DAPL.TypeName = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_rpt_FloorStock_DAPL.CategoryName = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_rpt_FloorStock_DAPL.MetalDetail = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_rpt_FloorStock_DAPL.GemDetail = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_rpt_FloorStock_DAPL.UomName = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_rpt_FloorStock_DAPL.Weight = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_rpt_FloorStock_DAPL.Qty = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_rpt_FloorStock_DAPL.UnitCost = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_rpt_FloorStock_DAPL.CostPrice = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_rpt_FloorStock_DAPL.ItemSerialNo = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_rpt_FloorStock_DAPL.CategorySubName = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_rpt_FloorStock_DAPL.Store_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_rpt_FloorStock_DAPL.ItemType_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_rpt_FloorStock_DAPL.ItemCategory_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_rpt_FloorStock_DAPL.ItemClass_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_rpt_FloorStock_DAPL.GemID = dataReader.GetString(20);
			}

			return tbl_rpt_FloorStock_DAPL;
		}
		/// <summary>
		/// This makes tbl_rpt_FloorStock_DAPL datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_rpt_FloorStock_DAPL object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_rpt_FloorStock_DAPL  tbl_rpt_FloorStock_DAPL   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_storeName = new DataColumn("storeName" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_refNo = new DataColumn("refNo" , typeof(string));
			DataColumn col_itemName = new DataColumn("itemName" , typeof(string));
			DataColumn col_className = new DataColumn("className" , typeof(string));
			DataColumn col_typeName = new DataColumn("typeName" , typeof(string));
			DataColumn col_categoryName = new DataColumn("categoryName" , typeof(string));
			DataColumn col_metalDetail = new DataColumn("metalDetail" , typeof(string));
			DataColumn col_gemDetail = new DataColumn("gemDetail" , typeof(string));
			DataColumn col_uomName = new DataColumn("uomName" , typeof(string));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_UnitCost = new DataColumn("UnitCost" , typeof(decimal));
			DataColumn col_CostPrice = new DataColumn("CostPrice" , typeof(decimal));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_categorySubName = new DataColumn("categorySubName" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_itemType_ID = new DataColumn("itemType_ID" , typeof(string));
			DataColumn col_itemCategory_ID = new DataColumn("itemCategory_ID" , typeof(string));
			DataColumn col_itemClass_ID = new DataColumn("itemClass_ID" , typeof(string));
			DataColumn col_gemID = new DataColumn("gemID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_storeName,col_item_ID,col_refNo,col_itemName,col_className,col_typeName,col_categoryName,col_metalDetail,col_gemDetail,col_uomName,col_weight,col_qty,col_UnitCost,col_CostPrice,col_itemSerialNo,col_categorySubName,col_store_ID,col_itemType_ID,col_itemCategory_ID,col_itemClass_ID,col_gemID,});		return dt;
		}
		/// <summary>
		/// This fills tbl_rpt_FloorStock_DAPL datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_rpt_FloorStock_DAPL object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_rpt_FloorStock_DAPL user) {
		DataRow drow = dt.NewRow();
		
			drow["storeName"] = user.storeName;
			drow["item_ID"] = user.item_ID;
			drow["refNo"] = user.refNo;
			drow["itemName"] = user.itemName;
			drow["className"] = user.className;
			drow["typeName"] = user.typeName;
			drow["categoryName"] = user.categoryName;
			drow["metalDetail"] = user.metalDetail;
			drow["gemDetail"] = user.gemDetail;
			drow["uomName"] = user.uomName;
			drow["weight"] = user.weight;
			drow["qty"] = user.qty;
			drow["UnitCost"] = user.UnitCost;
			drow["CostPrice"] = user.CostPrice;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["categorySubName"] = user.categorySubName;
			drow["store_ID"] = user.store_ID;
			drow["itemType_ID"] = user.itemType_ID;
			drow["itemCategory_ID"] = user.itemCategory_ID;
			drow["itemClass_ID"] = user.itemClass_ID;
			drow["gemID"] = user.gemID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
