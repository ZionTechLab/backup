using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_posTransaction_Detail {
		#region Fields
		private int line_No;
		private int posTransaction_Index;
		private string item_ID;
		private int giftVoucherID;
		private string remark;
		private decimal qty;
		private decimal weight;
		private decimal unitPrice;
		private decimal weightPrice;
		private bool bIsFreeItem;
		private decimal netAmount;
		private decimal lineDiscountPresentage;
		private decimal lineDiscountTotal;
		private decimal grossAmount;
		private int prevPosTx_Index;
		private int prevPosTx_LineNo;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_posTransaction_Detail class.
		/// </summary>
		public tbl_posTransaction_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_posTransaction_Detail class.
		/// </summary>
		public tbl_posTransaction_Detail(int line_No, int posTransaction_Index, string item_ID, int giftVoucherID, string remark, decimal qty, decimal weight, decimal unitPrice, decimal weightPrice, bool bIsFreeItem, decimal netAmount, decimal lineDiscountPresentage, decimal lineDiscountTotal, decimal grossAmount, int prevPosTx_Index, int prevPosTx_LineNo) {
			this.line_No = line_No;
			this.posTransaction_Index = posTransaction_Index;
			this.item_ID = item_ID;
			this.giftVoucherID = giftVoucherID;
			this.remark = remark;
			this.qty = qty;
			this.weight = weight;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.bIsFreeItem = bIsFreeItem;
			this.netAmount = netAmount;
			this.lineDiscountPresentage = lineDiscountPresentage;
			this.lineDiscountTotal = lineDiscountTotal;
			this.grossAmount = grossAmount;
			this.prevPosTx_Index = prevPosTx_Index;
			this.prevPosTx_LineNo = prevPosTx_LineNo;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the PosTransaction_Index value.
		/// </summary>
		public int PosTransaction_Index {
			get { return posTransaction_Index; }
			set { posTransaction_Index = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GiftVoucherID value.
		/// </summary>
		public int GiftVoucherID {
			get { return giftVoucherID; }
			set { giftVoucherID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
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
		/// Gets or sets the UnitPrice value.
		/// </summary>
		public decimal UnitPrice {
			get { return unitPrice; }
			set { unitPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightPrice value.
		/// </summary>
		public decimal WeightPrice {
			get { return weightPrice; }
			set { weightPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the BIsFreeItem value.
		/// </summary>
		public bool BIsFreeItem {
			get { return bIsFreeItem; }
			set { bIsFreeItem = value; }
		}
		
		/// <summary>
		/// Gets or sets the NetAmount value.
		/// </summary>
		public decimal NetAmount {
			get { return netAmount; }
			set { netAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the LineDiscountPresentage value.
		/// </summary>
		public decimal LineDiscountPresentage {
			get { return lineDiscountPresentage; }
			set { lineDiscountPresentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the LineDiscountTotal value.
		/// </summary>
		public decimal LineDiscountTotal {
			get { return lineDiscountTotal; }
			set { lineDiscountTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the GrossAmount value.
		/// </summary>
		public decimal GrossAmount {
			get { return grossAmount; }
			set { grossAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrevPosTx_Index value.
		/// </summary>
		public int PrevPosTx_Index {
			get { return prevPosTx_Index; }
			set { prevPosTx_Index = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrevPosTx_LineNo value.
		/// </summary>
		public int PrevPosTx_LineNo {
			get { return prevPosTx_LineNo; }
			set { prevPosTx_LineNo = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_posTransaction_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posTransaction_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@posTransaction_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@giftVoucherID", SqlDbType.Int,4);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bIsFreeItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@netAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lineDiscountPresentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lineDiscountTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grossAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@prevPosTx_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@prevPosTx_LineNo", SqlDbType.Int,4);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@posTransaction_Index"].Value = posTransaction_Index;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@giftVoucherID"].Value = giftVoucherID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@bIsFreeItem"].Value = bIsFreeItem;
			scom.Parameters["@netAmount"].Value = netAmount;
			scom.Parameters["@lineDiscountPresentage"].Value = lineDiscountPresentage;
			scom.Parameters["@lineDiscountTotal"].Value = lineDiscountTotal;
			scom.Parameters["@grossAmount"].Value = grossAmount;
			scom.Parameters["@prevPosTx_Index"].Value = prevPosTx_Index;
			scom.Parameters["@prevPosTx_LineNo"].Value = prevPosTx_LineNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_posTransaction_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posTransaction_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@posTransaction_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@giftVoucherID", SqlDbType.Int,4);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bIsFreeItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@netAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lineDiscountPresentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lineDiscountTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grossAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@prevPosTx_Index", SqlDbType.Int,4);
			scom.Parameters.Add("@prevPosTx_LineNo", SqlDbType.Int,4);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@posTransaction_Index"].Value = posTransaction_Index;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@giftVoucherID"].Value = giftVoucherID;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@bIsFreeItem"].Value = bIsFreeItem;
			scom.Parameters["@netAmount"].Value = netAmount;
			scom.Parameters["@lineDiscountPresentage"].Value = lineDiscountPresentage;
			scom.Parameters["@lineDiscountTotal"].Value = lineDiscountTotal;
			scom.Parameters["@grossAmount"].Value = grossAmount;
			scom.Parameters["@prevPosTx_Index"].Value = prevPosTx_Index;
			scom.Parameters["@prevPosTx_LineNo"].Value = prevPosTx_LineNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_posTransaction_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posTransaction_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@posTransaction_Index", SqlDbType.Int,4);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@posTransaction_Index"].Value = posTransaction_Index;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posTransaction_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByPrevPosTx_LineNo_PrevPosTx_Index(int prevPosTx_LineNo, int prevPosTx_Index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posTransaction_DetailDeleteAllByPrevPosTx_LineNo_PrevPosTx_Index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prevPosTx_LineNo", SqlDbType.Int,4);
			scom.Parameters.Add("@prevPosTx_Index", SqlDbType.Int,4);
			scom.Parameters["@prevPosTx_LineNo"].Value = prevPosTx_LineNo;
			scom.Parameters["@prevPosTx_Index"].Value = prevPosTx_Index;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_posTransaction_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByGiftVoucherID(int giftVoucherID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posTransaction_DetailDeleteAllByGiftVoucherID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@giftVoucherID", SqlDbType.Int,4);
			scom.Parameters["@giftVoucherID"].Value = giftVoucherID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_posTransaction_Detail table.
		/// </summary>
		public static tbl_posTransaction_Detail Select(int line_No_Incoming, int posTransaction_Index_Incoming){

			tbl_posTransaction_Detail tbl_posTransaction_Detailins = new tbl_posTransaction_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posTransaction_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@posTransaction_Index", SqlDbType.Int,4);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@posTransaction_Index"].Value = posTransaction_Index_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_posTransaction_Detailins = Maketbl_posTransaction_Detail(dataReader);
				} else {
					tbl_posTransaction_Detailins = null;
				}
			}
			scon.Close();
			return tbl_posTransaction_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posTransaction_Detail table.
		/// </summary>
		public static List<tbl_posTransaction_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posTransaction_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_posTransaction_Detail> tbl_posTransaction_DetailList = new List<tbl_posTransaction_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posTransaction_Detail tbl_posTransaction_Detail = Maketbl_posTransaction_Detail(dataReader);
					tbl_posTransaction_DetailList.Add(tbl_posTransaction_Detail);
				}
			}
			scon.Close();
			return tbl_posTransaction_DetailList;
		}

        public static List<tbl_posTransaction_Detail> SelectAllByPosTransaction_Index(int posTransaction_Index)
        {

            SqlConnection scon = DBHandling.GetConnection();
            SqlCommand scom = new SqlCommand("tbl_posTransaction_DetailSelectAllByPosTransaction_Index", scon);
            scom.CommandType = CommandType.StoredProcedure;
            scon.Open();

            scom.Parameters.Add("@posTransaction_Index", SqlDbType.Int, 4);
            scom.Parameters["@posTransaction_Index"].Value = posTransaction_Index;
            List<tbl_posTransaction_Detail> tbl_posTransaction_DetailList = new List<tbl_posTransaction_Detail>();
            using (SqlDataReader dataReader = scom.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    tbl_posTransaction_Detail tbl_posTransaction_Detail = Maketbl_posTransaction_Detail(dataReader);
                    tbl_posTransaction_DetailList.Add(tbl_posTransaction_Detail);
                }
            }
            scon.Close();
            return tbl_posTransaction_DetailList;
        }

        /// <summary>
        /// Selects all records from the tbl_posTransaction_Detail table by a foreign key.
        /// </summary>
        public static List<tbl_posTransaction_Detail> SelectAllByPrevPosTx_LineNo_PrevPosTx_Index(int prevPosTx_LineNo, int prevPosTx_Index) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posTransaction_DetailSelectAllByPrevPosTx_LineNo_PrevPosTx_Index", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prevPosTx_LineNo", SqlDbType.Int,4);
			scom.Parameters.Add("@prevPosTx_Index", SqlDbType.Int,4);
			scom.Parameters["@prevPosTx_LineNo"].Value = prevPosTx_LineNo;
			scom.Parameters["@prevPosTx_Index"].Value = prevPosTx_Index;
				List<tbl_posTransaction_Detail> tbl_posTransaction_DetailList = new List<tbl_posTransaction_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posTransaction_Detail tbl_posTransaction_Detail = Maketbl_posTransaction_Detail(dataReader);
					tbl_posTransaction_DetailList.Add(tbl_posTransaction_Detail);
				}
			}
			scon.Close();
			return tbl_posTransaction_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_posTransaction_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_posTransaction_Detail> SelectAllByGiftVoucherID(int giftVoucherID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_posTransaction_DetailSelectAllByGiftVoucherID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@giftVoucherID", SqlDbType.Int,4);
			scom.Parameters["@giftVoucherID"].Value = giftVoucherID;
				List<tbl_posTransaction_Detail> tbl_posTransaction_DetailList = new List<tbl_posTransaction_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_posTransaction_Detail tbl_posTransaction_Detail = Maketbl_posTransaction_Detail(dataReader);
					tbl_posTransaction_DetailList.Add(tbl_posTransaction_Detail);
				}
			}
			scon.Close();
			return tbl_posTransaction_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_posTransaction_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_posTransaction_Detail Maketbl_posTransaction_Detail(SqlDataReader dataReader) {
			tbl_posTransaction_Detail tbl_posTransaction_Detail = new tbl_posTransaction_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_posTransaction_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_posTransaction_Detail.PosTransaction_Index = dataReader.GetInt32(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_posTransaction_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_posTransaction_Detail.GiftVoucherID = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_posTransaction_Detail.Remark = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_posTransaction_Detail.Qty = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_posTransaction_Detail.Weight = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_posTransaction_Detail.UnitPrice = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_posTransaction_Detail.WeightPrice = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_posTransaction_Detail.BIsFreeItem = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_posTransaction_Detail.NetAmount = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_posTransaction_Detail.LineDiscountPresentage = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_posTransaction_Detail.LineDiscountTotal = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_posTransaction_Detail.GrossAmount = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_posTransaction_Detail.PrevPosTx_Index = dataReader.GetInt32(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_posTransaction_Detail.PrevPosTx_LineNo = dataReader.GetInt32(15);
			}

			return tbl_posTransaction_Detail;
		}
		/// <summary>
		/// This makes tbl_posTransaction_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_posTransaction_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_posTransaction_Detail  tbl_posTransaction_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_posTransaction_Index = new DataColumn("posTransaction_Index" , typeof(int));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_giftVoucherID = new DataColumn("giftVoucherID" , typeof(int));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_bIsFreeItem = new DataColumn("bIsFreeItem" , typeof(bool));
			DataColumn col_netAmount = new DataColumn("netAmount" , typeof(decimal));
			DataColumn col_lineDiscountPresentage = new DataColumn("lineDiscountPresentage" , typeof(decimal));
			DataColumn col_lineDiscountTotal = new DataColumn("lineDiscountTotal" , typeof(decimal));
			DataColumn col_grossAmount = new DataColumn("grossAmount" , typeof(decimal));
			DataColumn col_prevPosTx_Index = new DataColumn("prevPosTx_Index" , typeof(int));
			DataColumn col_prevPosTx_LineNo = new DataColumn("prevPosTx_LineNo" , typeof(int));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_posTransaction_Index,col_item_ID,col_giftVoucherID,col_remark,col_qty,col_weight,col_unitPrice,col_weightPrice,col_bIsFreeItem,col_netAmount,col_lineDiscountPresentage,col_lineDiscountTotal,col_grossAmount,col_prevPosTx_Index,col_prevPosTx_LineNo,});		return dt;
		}
		/// <summary>
		/// This fills tbl_posTransaction_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_posTransaction_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_posTransaction_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["posTransaction_Index"] = user.posTransaction_Index;
			drow["item_ID"] = user.item_ID;
			drow["giftVoucherID"] = user.giftVoucherID;
			drow["remark"] = user.remark;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["bIsFreeItem"] = user.bIsFreeItem;
			drow["netAmount"] = user.netAmount;
			drow["lineDiscountPresentage"] = user.lineDiscountPresentage;
			drow["lineDiscountTotal"] = user.lineDiscountTotal;
			drow["grossAmount"] = user.grossAmount;
			drow["prevPosTx_Index"] = user.prevPosTx_Index;
			drow["prevPosTx_LineNo"] = user.prevPosTx_LineNo;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
