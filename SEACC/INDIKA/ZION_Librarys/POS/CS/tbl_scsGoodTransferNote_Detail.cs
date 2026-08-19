using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_scsGoodTransferNote_Detail {
		#region Fields
		private int line_No;
		private string goodTransferNote_ID;
		private string item_Code;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private string uom;
		private decimal qty;
		private decimal weight;
		private decimal unitPrice;
		private decimal tatalAmount;
		private string remark;
		private decimal weightedAvgCost;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_scsGoodTransferNote_Detail class.
		/// </summary>
		public tbl_scsGoodTransferNote_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_scsGoodTransferNote_Detail class.
		/// </summary>
		public tbl_scsGoodTransferNote_Detail(int line_No, string goodTransferNote_ID, string item_Code, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, string uom, decimal qty, decimal weight, decimal unitPrice, decimal tatalAmount, string remark, decimal weightedAvgCost) {
			this.line_No = line_No;
			this.goodTransferNote_ID = goodTransferNote_ID;
			this.item_Code = item_Code;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.uom = uom;
			this.qty = qty;
			this.weight = weight;
			this.unitPrice = unitPrice;
			this.tatalAmount = tatalAmount;
			this.remark = remark;
			this.weightedAvgCost = weightedAvgCost;
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
		/// Gets or sets the GoodTransferNote_ID value.
		/// </summary>
		public string GoodTransferNote_ID {
			get { return goodTransferNote_ID; }
			set { goodTransferNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_Code value.
		/// </summary>
		public string Item_Code {
			get { return item_Code; }
			set { item_Code = value; }
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
		/// Gets or sets the UnitPrice value.
		/// </summary>
		public decimal UnitPrice {
			get { return unitPrice; }
			set { unitPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the TatalAmount value.
		/// </summary>
		public decimal TatalAmount {
			get { return tatalAmount; }
			set { tatalAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightedAvgCost value.
		/// </summary>
		public decimal WeightedAvgCost {
			get { return weightedAvgCost; }
			set { weightedAvgCost = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_scsGoodTransferNote_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsGoodTransferNote_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@goodTransferNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_Code", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@uom", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@goodTransferNote_ID"].Value = goodTransferNote_ID;
			scom.Parameters["@item_Code"].Value = item_Code;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@uom"].Value = uom;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_scsGoodTransferNote_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsGoodTransferNote_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@goodTransferNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_Code", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@uom", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@weightedAvgCost", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@goodTransferNote_ID"].Value = goodTransferNote_ID;
			scom.Parameters["@item_Code"].Value = item_Code;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@uom"].Value = uom;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@weightedAvgCost"].Value = weightedAvgCost;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_scsGoodTransferNote_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsGoodTransferNote_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@goodTransferNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_Code", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@goodTransferNote_ID"].Value = goodTransferNote_ID;
 
			scom.Parameters["@item_Code"].Value = item_Code;
 
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
 
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsGoodTransferNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByGoodTransferNote_ID(string goodTransferNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsGoodTransferNote_DetailDeleteAllByGoodTransferNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			 
			scom.Parameters.Add("@goodTransferNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@goodTransferNote_ID"].Value = goodTransferNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_scsGoodTransferNote_Detail table.
		/// </summary>
		public static tbl_scsGoodTransferNote_Detail Select(int line_No_Incoming, string goodTransferNote_ID_Incoming, string item_Code_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_scsGoodTransferNote_Detail tbl_scsGoodTransferNote_Detailins = new tbl_scsGoodTransferNote_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsGoodTransferNote_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@goodTransferNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_Code", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@goodTransferNote_ID"].Value = goodTransferNote_ID_Incoming;
			scom.Parameters["@item_Code"].Value = item_Code_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_scsGoodTransferNote_Detailins = Maketbl_scsGoodTransferNote_Detail(dataReader);
				} else {
					tbl_scsGoodTransferNote_Detailins = null;
				}
			}
			scon.Close();
			return tbl_scsGoodTransferNote_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsGoodTransferNote_Detail table.
		/// </summary>
		public static List<tbl_scsGoodTransferNote_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsGoodTransferNote_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_scsGoodTransferNote_Detail> tbl_scsGoodTransferNote_DetailList = new List<tbl_scsGoodTransferNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsGoodTransferNote_Detail tbl_scsGoodTransferNote_Detail = Maketbl_scsGoodTransferNote_Detail(dataReader);
					tbl_scsGoodTransferNote_DetailList.Add(tbl_scsGoodTransferNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsGoodTransferNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_scsGoodTransferNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_scsGoodTransferNote_Detail> SelectAllByGoodTransferNote_ID(string goodTransferNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_scsGoodTransferNote_DetailSelectAllByGoodTransferNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@goodTransferNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@goodTransferNote_ID"].Value = goodTransferNote_ID;
				List<tbl_scsGoodTransferNote_Detail> tbl_scsGoodTransferNote_DetailList = new List<tbl_scsGoodTransferNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_scsGoodTransferNote_Detail tbl_scsGoodTransferNote_Detail = Maketbl_scsGoodTransferNote_Detail(dataReader);
					tbl_scsGoodTransferNote_DetailList.Add(tbl_scsGoodTransferNote_Detail);
				}
			}
			scon.Close();
			return tbl_scsGoodTransferNote_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_scsGoodTransferNote_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_scsGoodTransferNote_Detail Maketbl_scsGoodTransferNote_Detail(SqlDataReader dataReader) {
			tbl_scsGoodTransferNote_Detail tbl_scsGoodTransferNote_Detail = new tbl_scsGoodTransferNote_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_scsGoodTransferNote_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_scsGoodTransferNote_Detail.GoodTransferNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_scsGoodTransferNote_Detail.Item_Code = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_scsGoodTransferNote_Detail.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_scsGoodTransferNote_Detail.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_scsGoodTransferNote_Detail.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_scsGoodTransferNote_Detail.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_scsGoodTransferNote_Detail.Uom = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_scsGoodTransferNote_Detail.Qty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_scsGoodTransferNote_Detail.Weight = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_scsGoodTransferNote_Detail.UnitPrice = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_scsGoodTransferNote_Detail.TatalAmount = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_scsGoodTransferNote_Detail.Remark = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_scsGoodTransferNote_Detail.WeightedAvgCost = dataReader.GetDecimal(13);
			}

			return tbl_scsGoodTransferNote_Detail;
		}
		/// <summary>
		/// This makes tbl_scsGoodTransferNote_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_scsGoodTransferNote_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_scsGoodTransferNote_Detail  tbl_scsGoodTransferNote_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_goodTransferNote_ID = new DataColumn("goodTransferNote_ID" , typeof(string));
			DataColumn col_item_Code = new DataColumn("item_Code" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_uom = new DataColumn("uom" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_tatalAmount = new DataColumn("tatalAmount" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_weightedAvgCost = new DataColumn("weightedAvgCost" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_goodTransferNote_ID,col_item_Code,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_uom,col_qty,col_weight,col_unitPrice,col_tatalAmount,col_remark,col_weightedAvgCost,});		return dt;
		}
		/// <summary>
		/// This fills tbl_scsGoodTransferNote_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_scsGoodTransferNote_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_scsGoodTransferNote_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["goodTransferNote_ID"] = user.goodTransferNote_ID;
			drow["item_Code"] = user.item_Code;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["uom"] = user.uom;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["unitPrice"] = user.unitPrice;
			drow["tatalAmount"] = user.tatalAmount;
			drow["remark"] = user.remark;
			drow["weightedAvgCost"] = user.weightedAvgCost;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
