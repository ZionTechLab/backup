using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasDeliveryOrder_DetailBreakdown {
		#region Fields
		private int line_NoBreakdown;
		private int line_No;
		private string deliveryOrder_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string serialNo;
		private decimal qty;
		private decimal weight;
		private string remark;
		private string itemSerialNo_Roll;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasDeliveryOrder_DetailBreakdown class.
		/// </summary>
		public tbl_sasDeliveryOrder_DetailBreakdown() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasDeliveryOrder_DetailBreakdown class.
		/// </summary>
		public tbl_sasDeliveryOrder_DetailBreakdown(int line_NoBreakdown, int line_No, string deliveryOrder_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string serialNo, decimal qty, decimal weight, string remark, string itemSerialNo_Roll) {
			this.line_NoBreakdown = line_NoBreakdown;
			this.line_No = line_No;
			this.deliveryOrder_ID = deliveryOrder_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.serialNo = serialNo;
			this.qty = qty;
			this.weight = weight;
			this.remark = remark;
			this.itemSerialNo_Roll = itemSerialNo_Roll;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_NoBreakdown value.
		/// </summary>
		public int Line_NoBreakdown {
			get { return line_NoBreakdown; }
			set { line_NoBreakdown = value; }
		}
		
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryOrder_ID value.
		/// </summary>
		public string DeliveryOrder_ID {
			get { return deliveryOrder_ID; }
			set { deliveryOrder_ID = value; }
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
		/// Gets or sets the SerialNo value.
		/// </summary>
		public string SerialNo {
			get { return serialNo; }
			set { serialNo = value; }
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
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo_Roll value.
		/// </summary>
		public string ItemSerialNo_Roll {
			get { return itemSerialNo_Roll; }
			set { itemSerialNo_Roll = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasDeliveryOrder_DetailBreakdown table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrder_DetailBreakdownInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_NoBreakdown", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@serialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@itemSerialNo_Roll", SqlDbType.VarChar,50);
 
			scom.Parameters["@line_NoBreakdown"].Value = line_NoBreakdown;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@serialNo"].Value = serialNo;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@itemSerialNo_Roll"].Value = itemSerialNo_Roll;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasDeliveryOrder_DetailBreakdown table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrder_DetailBreakdownUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_NoBreakdown", SqlDbType.Int,4);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@serialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@itemSerialNo_Roll", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@line_NoBreakdown"].Value = line_NoBreakdown;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@serialNo"].Value = serialNo;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@itemSerialNo_Roll"].Value = itemSerialNo_Roll;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasDeliveryOrder_DetailBreakdown table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrder_DetailBreakdownDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_NoBreakdown", SqlDbType.Int,4);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@line_NoBreakdown"].Value = line_NoBreakdown;
 
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
 
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

        public static void DeleteAllByDeliveryOrder_ID_Item_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2(string deliveryOrder_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("sp_DO_DetailBreakdownDeleteAllByDeliveryOrder_ID_Item_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2", scon);
            scom.CommandType = CommandType.StoredProcedure;

            scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@item_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar, 50);
            scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
            scom.Parameters["@item_ID"].Value = item_ID;
            scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
            scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
            scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
            scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;

            scon.Open();
            scom.ExecuteNonQuery();
            scon.Close();
        }
        /// <summary>
        /// Selects all records from the tbl_sasDeliveryOrder_DetailBreakdown table by a foreign key.
        /// </summary>
        public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrder_DetailBreakdownDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasDeliveryOrder_DetailBreakdown table.
		/// </summary>
		public static tbl_sasDeliveryOrder_DetailBreakdown Select(int line_NoBreakdown_Incoming, string deliveryOrder_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_sasDeliveryOrder_DetailBreakdown tbl_sasDeliveryOrder_DetailBreakdownins = new tbl_sasDeliveryOrder_DetailBreakdown();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrder_DetailBreakdownSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_NoBreakdown", SqlDbType.Int,4);
			scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@line_NoBreakdown"].Value = line_NoBreakdown_Incoming;
			scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasDeliveryOrder_DetailBreakdownins = Maketbl_sasDeliveryOrder_DetailBreakdown(dataReader);
				} else {
					tbl_sasDeliveryOrder_DetailBreakdownins = null;
				}
			}
			scon.Close();
			return tbl_sasDeliveryOrder_DetailBreakdownins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryOrder_DetailBreakdown table.
		/// </summary>
		public static List<tbl_sasDeliveryOrder_DetailBreakdown> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrder_DetailBreakdownSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasDeliveryOrder_DetailBreakdown> tbl_sasDeliveryOrder_DetailBreakdownList = new List<tbl_sasDeliveryOrder_DetailBreakdown>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryOrder_DetailBreakdown tbl_sasDeliveryOrder_DetailBreakdown = Maketbl_sasDeliveryOrder_DetailBreakdown(dataReader);
					tbl_sasDeliveryOrder_DetailBreakdownList.Add(tbl_sasDeliveryOrder_DetailBreakdown);
				}
			}
			scon.Close();
			return tbl_sasDeliveryOrder_DetailBreakdownList;
		}

        public static List<tbl_sasDeliveryOrder_DetailBreakdown> SelectAllByDeliveryOrder_ID_Item_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2(string deliveryOrder_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("sp_DO_DetailBreakdownSelectAllByDeliveryOrder_ID_Item_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@deliveryOrder_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@item_ID", SqlDbType.VarChar, 20);
            scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar, 10);
            scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar, 50);
            scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar, 50);
            scom.Parameters["@deliveryOrder_ID"].Value = deliveryOrder_ID;
            scom.Parameters["@item_ID"].Value = item_ID;
            scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
            scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
            scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
            scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
            List<tbl_sasDeliveryOrder_DetailBreakdown> tbl_sasDeliveryOrder_DetailBreakdownList = new List<tbl_sasDeliveryOrder_DetailBreakdown>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_sasDeliveryOrder_DetailBreakdown tbl_sasDeliveryOrder_DetailBreakdown = Maketbl_sasDeliveryOrder_DetailBreakdown(dataReader);
                    tbl_sasDeliveryOrder_DetailBreakdownList.Add(tbl_sasDeliveryOrder_DetailBreakdown);
                }
            }
            scon.Close();
            return tbl_sasDeliveryOrder_DetailBreakdownList;
        }
        /// <summary>
        /// Selects all records from the tbl_sasDeliveryOrder_DetailBreakdown table by a foreign key.
        /// </summary>
        public static List<tbl_sasDeliveryOrder_DetailBreakdown> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryOrder_DetailBreakdownSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_sasDeliveryOrder_DetailBreakdown> tbl_sasDeliveryOrder_DetailBreakdownList = new List<tbl_sasDeliveryOrder_DetailBreakdown>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryOrder_DetailBreakdown tbl_sasDeliveryOrder_DetailBreakdown = Maketbl_sasDeliveryOrder_DetailBreakdown(dataReader);
					tbl_sasDeliveryOrder_DetailBreakdownList.Add(tbl_sasDeliveryOrder_DetailBreakdown);
				}
			}
			scon.Close();
			return tbl_sasDeliveryOrder_DetailBreakdownList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasDeliveryOrder_DetailBreakdown class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasDeliveryOrder_DetailBreakdown Maketbl_sasDeliveryOrder_DetailBreakdown(SqlDataReader dataReader) {
			tbl_sasDeliveryOrder_DetailBreakdown tbl_sasDeliveryOrder_DetailBreakdown = new tbl_sasDeliveryOrder_DetailBreakdown();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasDeliveryOrder_DetailBreakdown.Line_NoBreakdown = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasDeliveryOrder_DetailBreakdown.Line_No = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasDeliveryOrder_DetailBreakdown.DeliveryOrder_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasDeliveryOrder_DetailBreakdown.Item_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasDeliveryOrder_DetailBreakdown.ItemSubCategory_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasDeliveryOrder_DetailBreakdown.ItemSubCategory2_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasDeliveryOrder_DetailBreakdown.ItemSerialNo = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasDeliveryOrder_DetailBreakdown.ItemSerialNo2 = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasDeliveryOrder_DetailBreakdown.SerialNo = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasDeliveryOrder_DetailBreakdown.Qty = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasDeliveryOrder_DetailBreakdown.Weight = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasDeliveryOrder_DetailBreakdown.Remark = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasDeliveryOrder_DetailBreakdown.ItemSerialNo_Roll = dataReader.GetString(12);
			}

			return tbl_sasDeliveryOrder_DetailBreakdown;
		}
		/// <summary>
		/// This makes tbl_sasDeliveryOrder_DetailBreakdown datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasDeliveryOrder_DetailBreakdown object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasDeliveryOrder_DetailBreakdown  tbl_sasDeliveryOrder_DetailBreakdown   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_NoBreakdown = new DataColumn("line_NoBreakdown" , typeof(int));
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_deliveryOrder_ID = new DataColumn("deliveryOrder_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_serialNo = new DataColumn("serialNo" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_itemSerialNo_Roll = new DataColumn("itemSerialNo_Roll" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_NoBreakdown,col_line_No,col_deliveryOrder_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_serialNo,col_qty,col_weight,col_remark,col_itemSerialNo_Roll,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasDeliveryOrder_DetailBreakdown datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasDeliveryOrder_DetailBreakdown object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasDeliveryOrder_DetailBreakdown user) {
		DataRow drow = dt.NewRow();
		
			drow["line_NoBreakdown"] = user.line_NoBreakdown;
			drow["line_No"] = user.line_No;
			drow["deliveryOrder_ID"] = user.deliveryOrder_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["serialNo"] = user.serialNo;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["remark"] = user.remark;
			drow["itemSerialNo_Roll"] = user.itemSerialNo_Roll;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
