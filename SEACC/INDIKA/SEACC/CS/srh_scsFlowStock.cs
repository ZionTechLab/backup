using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
    public sealed class srh_scsFlowStock
    {
        #region Fields
        private int noteType;
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
        private bool isWeightCalculation;
        private decimal qty;
        private decimal weight;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the srh_scsFlowStock class.
        /// </summary>
        public srh_scsFlowStock()
        {
        }

        /// <summary>
        /// Initializes a new instance of the srh_scsFlowStock class.
        /// </summary>
        public srh_scsFlowStock(int noteType,string itemCategory_ID, string itemCategorySub_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string itemClass_ID, string itemType_ID, string salesNoteType_ID, string store_ID, string item_ID,string itemName,string brand_ID, string uom,bool isWeightCalculation, decimal qty, decimal weight)
        {
            this.noteType = noteType;
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
            this.isWeightCalculation = isWeightCalculation;
            this.qty = qty;
            this.weight = weight;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the noteType value.
        /// </summary>
        public int NoteType
        {
            get { return noteType; }
            set { noteType = value; }
        }

        /// <summary>
        /// Gets or sets the ItemCategory_ID value.
        /// </summary>
        public string ItemCategory_ID
        {
            get { return itemCategory_ID; }
            set { itemCategory_ID = value; }
        }

        /// <summary>
        /// Gets or sets the ItemCategorySub_ID value.
        /// </summary>
        public string ItemCategorySub_ID
        {
            get { return itemCategorySub_ID; }
            set { itemCategorySub_ID = value; }
        }

        /// <summary>
        /// Gets or sets the itemSubCategory2_ID value.
        /// </summary>
        public string ItemSubCategory2_ID
        {
            get { return itemSubCategory2_ID; }
            set { itemSubCategory2_ID = value; }
        }

        /// <summary>
        /// Gets or sets the itemSerialNo value.
        /// </summary>
        public string ItemSerialNo
        {
            get { return itemSerialNo; }
            set { itemSerialNo = value; }
        }

        /// <summary>
        /// Gets or sets the itemSerialNo2 value.
        /// </summary>
        public string ItemSerialNo2
        {
            get { return itemSerialNo2; }
            set { itemSerialNo2 = value; }
        }

        /// <summary>
        /// Gets or sets the ItemClass_ID value.
        /// </summary>
        public string ItemClass_ID
        {
            get { return itemClass_ID; }
            set { itemClass_ID = value; }
        }

        /// <summary>
        /// Gets or sets the ItemType_ID value.
        /// </summary>
        public string ItemType_ID
        {
            get { return itemType_ID; }
            set { itemType_ID = value; }
        }

        /// <summary>
        /// Gets or sets the SalesNoteType_ID value.
        /// </summary>
        public string SalesNoteType_ID
        {
            get { return salesNoteType_ID; }
            set { salesNoteType_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Store_ID value.
        /// </summary>
        public string Store_ID
        {
            get { return store_ID; }
            set { store_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Item_ID value.
        /// </summary>
        public string Item_ID
        {
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
        /// Gets or sets the itemName value.
        /// </summary>
        public string Brand_ID
        {
            get { return brand_ID; }
            set { brand_ID = value; }
        }

        /// <summary>
        /// Gets or sets the Uom value.
        /// </summary>
        public string Uom
        {
            get { return uom; }
            set { uom = value; }
        }

        /// <summary>
        /// Gets or sets the Uom value.
        /// </summary>
        public bool IsWeightCalculation
        {
            get { return isWeightCalculation; }
            set { isWeightCalculation = value; }
        }

        /// <summary>
        /// Gets or sets the Qty value.
        /// </summary>
        public decimal Qty
        {
            get { return qty; }
            set { qty = value; }
        }

        /// <summary>
        /// Gets or sets the Weight value.
        /// </summary>
        public decimal Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Selects all records from the srh_scsFlowStock table.
        /// </summary>
        public static List<srh_scsFlowStock> Select(DateTime toDate, string item_ID,string isDeleted, string companyBranch_ID)
        {
            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("dbo.srh_scsFlowStock", scon);
            scom.CommandTimeout = 18000;
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@ToDate", SqlDbType.DateTime);
            scom.Parameters["@ToDate"].Value = toDate;
            scom.Parameters.Add("@item_ID", SqlDbType.VarChar);
            scom.Parameters["@item_ID"].Value = item_ID;
            scom.Parameters.Add("@isDeleted", SqlDbType.VarChar);
            scom.Parameters["@isDeleted"].Value = isDeleted;
            scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar);
            scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;

            List<srh_scsFlowStock> srh_scsFlowStockList = new List<srh_scsFlowStock>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    srh_scsFlowStock srh_scsFlowStock = Makesrh_scsFlowStock(dataReader);
                    srh_scsFlowStockList.Add(srh_scsFlowStock);
                }
            }
            scon.Close();
            return srh_scsFlowStockList;
        }

        /// <summary>
        /// Creates a new instance of the srh_scsFlowStock class and populates it with data from the specified SqlDataReader.
        /// </summary>
        private static srh_scsFlowStock Makesrh_scsFlowStock(SqlDataReader dataReader)
        {
            srh_scsFlowStock srh_scsFlowStock = new srh_scsFlowStock();

            if (dataReader.IsDBNull(0) == false)
                srh_scsFlowStock.NoteType =dataReader.GetInt32(0);

            if (dataReader.IsDBNull(1) == false)
                srh_scsFlowStock.ItemCategory_ID = dataReader.GetString(1);
          
            if (dataReader.IsDBNull(2) == false)
                srh_scsFlowStock.ItemCategorySub_ID = dataReader.GetString(2);

            if (dataReader.IsDBNull(3) == false)
                srh_scsFlowStock.ItemSubCategory2_ID = dataReader.GetString(3);

            if (dataReader.IsDBNull(4) == false)
                srh_scsFlowStock.ItemSerialNo = dataReader.GetString(4);

            if (dataReader.IsDBNull(5) == false)
                srh_scsFlowStock.ItemSerialNo2 = dataReader.GetString(5);

            if (dataReader.IsDBNull(6) == false)
                srh_scsFlowStock.ItemClass_ID = dataReader.GetString(6);

            if (dataReader.IsDBNull(7) == false)
                srh_scsFlowStock.ItemType_ID = dataReader.GetString(7);

            if (dataReader.IsDBNull(8) == false)
                srh_scsFlowStock.SalesNoteType_ID = dataReader.GetString(8);

            if (dataReader.IsDBNull(9) == false)
                srh_scsFlowStock.Store_ID = dataReader.GetString(9);

            if (dataReader.IsDBNull(10) == false)
                srh_scsFlowStock.Item_ID = dataReader.GetString(10);

            if (dataReader.IsDBNull(11) == false)
                srh_scsFlowStock.ItemName = dataReader.GetString(11);

            if (dataReader.IsDBNull(12) == false)
                srh_scsFlowStock.Brand_ID = dataReader.GetString(12);

            if (dataReader.IsDBNull(13) == false)
                srh_scsFlowStock.Uom = dataReader.GetString(13);

            if (dataReader.IsDBNull(14) == false)
                srh_scsFlowStock.IsWeightCalculation = dataReader.GetBoolean(14);

            if (dataReader.IsDBNull(15) == false)
                srh_scsFlowStock.Qty = dataReader.GetDecimal(15);

            if (dataReader.IsDBNull(16) == false)
                srh_scsFlowStock.Weight = dataReader.GetDecimal(16);

            return srh_scsFlowStock;
        }
        /// <summary>
        /// This makes srh_scsFlowStock datatable according to the datatable.
        /// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
        ///            We are still humans
        /// </summary>
        /// <param name="user">new srh_scsFlowStock object</param>
        /// <returns></returns>
        public static DataTable CreateDataTable(srh_scsFlowStock srh_scsFlowStock)
        {
            DataTable dt = new DataTable();

            DataColumn col_itemCategory_ID = new DataColumn("itemCategory_ID", typeof(string));
            DataColumn col_itemCategorySub_ID = new DataColumn("itemCategorySub_ID", typeof(string));
            DataColumn col_itemClass_ID = new DataColumn("itemClass_ID", typeof(string));
            DataColumn col_itemType_ID = new DataColumn("itemType_ID", typeof(string));
            DataColumn col_salesNoteType_ID = new DataColumn("salesNoteType_ID", typeof(string));
            DataColumn col_store_ID = new DataColumn("store_ID", typeof(string));
            DataColumn col_item_ID = new DataColumn("item_ID", typeof(string));
            DataColumn col_uom = new DataColumn("uom", typeof(string));
            DataColumn col_qty = new DataColumn("qty", typeof(decimal));
            DataColumn col_weight = new DataColumn("weight", typeof(decimal));
            dt.Columns.AddRange(new DataColumn[] { col_itemCategory_ID, col_itemCategorySub_ID, col_itemClass_ID, col_itemType_ID, col_salesNoteType_ID, col_store_ID, col_item_ID, col_uom, col_qty, col_weight, }); return dt;
        }
        /// <summary>
        /// This fills srh_scsFlowStock datatable according to the Given user list.
        /// </summary>
        /// <param name="user">new srh_scsFlowStock object</param>
        /// <returns></returns>
        public static void FillData(DataTable dt, srh_scsFlowStock user)
        {
            DataRow drow = dt.NewRow();

            drow["itemCategory_ID"] = user.itemCategory_ID;
            drow["itemCategorySub_ID"] = user.itemCategorySub_ID;
            drow["itemClass_ID"] = user.itemClass_ID;
            drow["itemType_ID"] = user.itemType_ID;
            drow["salesNoteType_ID"] = user.salesNoteType_ID;
            drow["store_ID"] = user.store_ID;
            drow["item_ID"] = user.item_ID;
            drow["uom"] = user.uom;
            drow["qty"] = user.qty;
            drow["weight"] = user.weight;
            dt.Rows.Add(drow);
        }
        #endregion
    }
}