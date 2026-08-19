using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class srh_scsFlowStock_detail {
		#region Fields
		private int noteType;
        private string txnID;
        private DateTime txnDate;
        private string remarks;
		private string itemCategory_ID;
		private string itemCategorySub_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string itemClass_ID;
		private string itemType_ID;
		private string salesNoteType_ID;
		private string store_ID;
		private string item_ID;
        private string itemName;
        private string brand_ID;
		private string uom;
		private decimal qty;
		private decimal weight;
		private decimal qty_issued;
        private decimal qty_received;
		private decimal weight_issued;
        private decimal weight_received;
		private string createUser_ID;
        private bool isWeightCalculation;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the srh_scsFlowStock_detail class.
		/// </summary>
		public srh_scsFlowStock_detail()
        {
		}
		
		/// <summary>
		/// Initializes a new instance of the srh_scsFlowStock_detail class.
		/// </summary>
        public srh_scsFlowStock_detail(int noteType, string txnID, DateTime txnDate, string remarks, string itemCategory_ID, string itemCategorySub_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string itemClass_ID, string itemType_ID, string salesNoteType_ID, string store_ID, string item_ID, string itemName, string brand_ID, string uom, decimal qty, decimal weight, decimal qty_issued, decimal qty_received, decimal weight_issued, decimal weight_received, string createUser_ID, bool isWeightCalculation)
        {
			this.noteType = noteType;
            this.txnID = txnID;
            this.txnDate = txnDate;
            this.remarks = remarks;
			this.itemCategory_ID = itemCategory_ID;
			this.itemCategorySub_ID = itemCategorySub_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.itemClass_ID = itemClass_ID;
			this.itemType_ID = itemType_ID;
			this.salesNoteType_ID = salesNoteType_ID;
			this.store_ID = store_ID;
			this.item_ID = item_ID;
            this.itemName = itemName;
            this.brand_ID = brand_ID;
			this.uom = uom;
			this.qty = qty;
			this.weight = weight;
			this.qty_issued = qty_issued;
			this.qty_received = qty_received;
			this.weight_issued = weight_issued;
			this.weight_received = weight_received;
			this.createUser_ID = createUser_ID;
            this.isWeightCalculation = isWeightCalculation;
		}
		#endregion
		
		#region Properties
		/// <summary>
        /// Gets or sets the noteType value.
		/// </summary>
		public int NoteType {
			get { return noteType; }
			set { noteType = value; }
		}

        /// <summary>
        /// Gets or sets the txnID value.
        /// </summary>
        public string TxnID
        {
            get { return txnID; }
            set { txnID = value; }
        }

        /// <summary>
        /// Gets or sets the TxnDate value.
        /// </summary>
        public DateTime TxnDate
        {
            get { return txnDate; }
            set { txnDate = value; }
        }

        /// <summary>
        /// Gets or sets the remarks value.
        /// </summary>
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

		/// <summary>
		/// Gets or sets the ItemCategory_ID value.
		/// </summary>
		public string ItemCategory_ID {
			get { return itemCategory_ID; }
			set { itemCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemCategorySub_ID value.
		/// </summary>
		public string ItemCategorySub_ID {
			get { return itemCategorySub_ID; }
			set { itemCategorySub_ID = value; }
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
		/// Gets or sets the SalesNoteType_ID value.
		/// </summary>
		public string SalesNoteType_ID {
			get { return salesNoteType_ID; }
			set { salesNoteType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Store_ID value.
		/// </summary>
		public string Store_ID {
			get { return store_ID; }
			set { store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}

        /// <summary>
        /// Gets or sets the itemName value.
        /// </summary>
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        /// <summary>
        /// Gets or sets the brand_ID value.
        /// </summary>
        public string Brand_ID
        {
            get { return brand_ID; }
            set { brand_ID = value; }
        }

		/// <summary>
		/// Gets or sets the Uom value.
		/// </summary>
		public string Uom {
			get { return uom; }
			set { uom = value; }
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
		
		/// <summary>
		/// Gets or sets the Qty_issued value.
		/// </summary>
		public decimal Qty_issued {
			get { return qty_issued; }
			set { qty_issued = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty_received value.
		/// </summary>
        public decimal Qty_received
        {
			get { return qty_received; }
			set { qty_received = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight_issued value.
		/// </summary>
		public decimal Weight_issued {
			get { return weight_issued; }
			set { weight_issued = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight_received value.
		/// </summary>
        public decimal Weight_received
        {
			get { return weight_received; }
			set { weight_received = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}

        /// <summary>
        /// Gets or sets the isWeightCalculation value.
        /// </summary>
        public bool IsWeightCalculation
        {
            get { return isWeightCalculation; }
            set { isWeightCalculation = value; }
        }
		#endregion
		
		#region Methods
	
		/// <summary>
		/// Selects all records from the srh_scsFlowStock_detail table.
		/// </summary>
        public static List<srh_scsFlowStock_detail> Select(DateTime fromDate,DateTime toDate, string sCompanyBranchID, string sItem_ID, string sStore_ID) 
        {
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("dbo.srh_scsFlowStock_detail", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();
            scom.CommandTimeout = 18000;
            scom.Parameters.Add("@ToDate", SqlDbType.DateTime);
            scom.Parameters.Add("@FromDate", SqlDbType.DateTime);
            scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar);
            scom.Parameters.Add("@item_ID", SqlDbType.VarChar);
            scom.Parameters.Add("@sore_ID", SqlDbType.VarChar);

            scom.Parameters["@ToDate"].Value = toDate;
            scom.Parameters["@FromDate"].Value = fromDate;
            scom.Parameters["@companyBranch_ID"].Value = sCompanyBranchID;
            scom.Parameters["@item_ID"].Value = sItem_ID;
            scom.Parameters["@sore_ID"].Value = sStore_ID;

            List<srh_scsFlowStock_detail> srh_scsFlowStockDetailList = new List<srh_scsFlowStock_detail>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    srh_scsFlowStock_detail srh_scsFlowStock_Detail = Makesrh_scsFlowStock_detail(dataReader);
                    srh_scsFlowStockDetailList.Add(srh_scsFlowStock_Detail);
                }
            }
            scon.Close();
            return srh_scsFlowStockDetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the srh_scsFlowStock_detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static srh_scsFlowStock_detail Makesrh_scsFlowStock_detail(SqlDataReader dataReader) {
			srh_scsFlowStock_detail srh_scsFlowStock_detail = new srh_scsFlowStock_detail();
			
			if (dataReader.IsDBNull(0) == false) {
				srh_scsFlowStock_detail.NoteType = dataReader.GetInt32(0);
			}
            if (dataReader.IsDBNull(1) == false)
            {
                srh_scsFlowStock_detail.TxnID = dataReader.GetString(1);
            }
            if (dataReader.IsDBNull(2) == false)
            {
                srh_scsFlowStock_detail.TxnDate = dataReader.GetDateTime(2);
            }
            if (dataReader.IsDBNull(3) == false)
            {
                srh_scsFlowStock_detail.Remarks = dataReader.GetString(3);
            }
			if (dataReader.IsDBNull(4) == false) {
				srh_scsFlowStock_detail.ItemCategory_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				srh_scsFlowStock_detail.ItemCategorySub_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				srh_scsFlowStock_detail.ItemSubCategory2_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				srh_scsFlowStock_detail.ItemSerialNo = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				srh_scsFlowStock_detail.ItemSerialNo2 = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				srh_scsFlowStock_detail.ItemClass_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				srh_scsFlowStock_detail.ItemType_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				srh_scsFlowStock_detail.SalesNoteType_ID = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				srh_scsFlowStock_detail.Store_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				srh_scsFlowStock_detail.Item_ID = dataReader.GetString(13);
			}
            if (dataReader.IsDBNull(14) == false)
            {
                srh_scsFlowStock_detail.ItemName = dataReader.GetString(14);
            }
            if (dataReader.IsDBNull(15) == false)
            {
                srh_scsFlowStock_detail.Brand_ID = dataReader.GetString(15);
            }
			if (dataReader.IsDBNull(16) == false) {
				srh_scsFlowStock_detail.Uom = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				srh_scsFlowStock_detail.Qty = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				srh_scsFlowStock_detail.Weight = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				srh_scsFlowStock_detail.Qty_issued = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				srh_scsFlowStock_detail.Qty_received = dataReader.GetDecimal(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				srh_scsFlowStock_detail.Weight_issued = dataReader.GetDecimal(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				srh_scsFlowStock_detail.Weight_received = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				srh_scsFlowStock_detail.CreateUser_ID = dataReader.GetString(23);
			}
            if (dataReader.IsDBNull(24) == false)
            {
                srh_scsFlowStock_detail.IsWeightCalculation = dataReader.GetBoolean(24);
            }
			return srh_scsFlowStock_detail;
		}
		/// <summary>
		/// This makes srh_scsFlowStock_detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new srh_scsFlowStock_detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( srh_scsFlowStock_detail  srh_scsFlowStock_detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_noteType = new DataColumn("noteType" , typeof(int));
			DataColumn col_itemCategory_ID = new DataColumn("itemCategory_ID" , typeof(string));
			DataColumn col_itemCategorySub_ID = new DataColumn("itemCategorySub_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_itemClass_ID = new DataColumn("itemClass_ID" , typeof(string));
			DataColumn col_itemType_ID = new DataColumn("itemType_ID" , typeof(string));
			DataColumn col_salesNoteType_ID = new DataColumn("salesNoteType_ID" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom = new DataColumn("uom" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_qty_issued = new DataColumn("qty_issued" , typeof(decimal));
			DataColumn col_qty_received = new DataColumn("qty_received" , typeof(int));
			DataColumn col_weight_issued = new DataColumn("weight_issued" , typeof(decimal));
			DataColumn col_weight_received = new DataColumn("weight_received" , typeof(int));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_noteType,col_itemCategory_ID,col_itemCategorySub_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_itemClass_ID,col_itemType_ID,col_salesNoteType_ID,col_store_ID,col_item_ID,col_uom,col_qty,col_weight,col_qty_issued,col_qty_received,col_weight_issued,col_weight_received,col_createUser_ID,});		return dt;
		}
		/// <summary>
		/// This fills srh_scsFlowStock_detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new srh_scsFlowStock_detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, srh_scsFlowStock_detail user) {
		DataRow drow = dt.NewRow();
		
			drow["noteType"] = user.noteType;
			drow["itemCategory_ID"] = user.itemCategory_ID;
			drow["itemCategorySub_ID"] = user.itemCategorySub_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["itemClass_ID"] = user.itemClass_ID;
			drow["itemType_ID"] = user.itemType_ID;
			drow["salesNoteType_ID"] = user.salesNoteType_ID;
			drow["store_ID"] = user.store_ID;
			drow["item_ID"] = user.item_ID;
			drow["uom"] = user.uom;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["qty_issued"] = user.qty_issued;
			drow["qty_received"] = user.qty_received;
			drow["weight_issued"] = user.weight_issued;
			drow["weight_received"] = user.weight_received;
			drow["createUser_ID"] = user.createUser_ID;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
