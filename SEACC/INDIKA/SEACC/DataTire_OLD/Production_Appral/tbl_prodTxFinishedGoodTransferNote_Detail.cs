using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxFinishedGoodTransferNote_Detail {
		#region Fields
		private int line_No;
		private string fgtn_ID;
		private string item_ID;
		private string uom_ID;
		private decimal fgtnQty;
		private decimal fgtnWeight;
		private decimal unitPrice;
		private decimal weightPrice;
		private decimal totalAmount;
		private string remark;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxFinishedGoodTransferNote_Detail class.
		/// </summary>
		public tbl_prodTxFinishedGoodTransferNote_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxFinishedGoodTransferNote_Detail class.
		/// </summary>
		public tbl_prodTxFinishedGoodTransferNote_Detail(int line_No, string fgtn_ID, string item_ID, string uom_ID, decimal fgtnQty, decimal fgtnWeight, decimal unitPrice, decimal weightPrice, decimal totalAmount, string remark) {
			this.line_No = line_No;
			this.fgtn_ID = fgtn_ID;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.fgtnQty = fgtnQty;
			this.fgtnWeight = fgtnWeight;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.totalAmount = totalAmount;
			this.remark = remark;
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
		/// Gets or sets the Fgtn_ID value.
		/// </summary>
		public string Fgtn_ID {
			get { return fgtn_ID; }
			set { fgtn_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the FgtnQty value.
		/// </summary>
		public decimal FgtnQty {
			get { return fgtnQty; }
			set { fgtnQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the FgtnWeight value.
		/// </summary>
		public decimal FgtnWeight {
			get { return fgtnWeight; }
			set { fgtnWeight = value; }
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
		/// Gets or sets the TotalAmount value.
		/// </summary>
		public decimal TotalAmount {
			get { return totalAmount; }
			set { totalAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prodTxFinishedGoodTransferNote_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferNote_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@fgtnQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@fgtnWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@fgtnQty"].Value = fgtnQty;
			scom.Parameters["@fgtnWeight"].Value = fgtnWeight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxFinishedGoodTransferNote_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferNote_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@fgtnQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@fgtnWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@fgtnQty"].Value = fgtnQty;
			scom.Parameters["@fgtnWeight"].Value = fgtnWeight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxFinishedGoodTransferNote_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferNote_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferNote_DetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferNote_DetailDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByFgtn_ID(string fgtn_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferNote_DetailDeleteAllByFgtn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxFinishedGoodTransferNote_Detail table.
		/// </summary>
		public static tbl_prodTxFinishedGoodTransferNote_Detail Select(int line_No_Incoming, string fgtn_ID_Incoming){

			tbl_prodTxFinishedGoodTransferNote_Detail tbl_prodTxFinishedGoodTransferNote_Detailins = new tbl_prodTxFinishedGoodTransferNote_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferNote_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferNote_Detailins = Maketbl_prodTxFinishedGoodTransferNote_Detail(dataReader);
				} else {
					tbl_prodTxFinishedGoodTransferNote_Detailins = null;
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferNote_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferNote_Detail table.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferNote_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferNote_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxFinishedGoodTransferNote_Detail> tbl_prodTxFinishedGoodTransferNote_DetailList = new List<tbl_prodTxFinishedGoodTransferNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferNote_Detail tbl_prodTxFinishedGoodTransferNote_Detail = Maketbl_prodTxFinishedGoodTransferNote_Detail(dataReader);
					tbl_prodTxFinishedGoodTransferNote_DetailList.Add(tbl_prodTxFinishedGoodTransferNote_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferNote_Detail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferNote_DetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_prodTxFinishedGoodTransferNote_Detail> tbl_prodTxFinishedGoodTransferNote_DetailList = new List<tbl_prodTxFinishedGoodTransferNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferNote_Detail tbl_prodTxFinishedGoodTransferNote_Detail = Maketbl_prodTxFinishedGoodTransferNote_Detail(dataReader);
					tbl_prodTxFinishedGoodTransferNote_DetailList.Add(tbl_prodTxFinishedGoodTransferNote_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferNote_Detail> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferNote_DetailSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prodTxFinishedGoodTransferNote_Detail> tbl_prodTxFinishedGoodTransferNote_DetailList = new List<tbl_prodTxFinishedGoodTransferNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferNote_Detail tbl_prodTxFinishedGoodTransferNote_Detail = Maketbl_prodTxFinishedGoodTransferNote_Detail(dataReader);
					tbl_prodTxFinishedGoodTransferNote_DetailList.Add(tbl_prodTxFinishedGoodTransferNote_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferNote_Detail> SelectAllByFgtn_ID(string fgtn_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferNote_DetailSelectAllByFgtn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
				List<tbl_prodTxFinishedGoodTransferNote_Detail> tbl_prodTxFinishedGoodTransferNote_DetailList = new List<tbl_prodTxFinishedGoodTransferNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferNote_Detail tbl_prodTxFinishedGoodTransferNote_Detail = Maketbl_prodTxFinishedGoodTransferNote_Detail(dataReader);
					tbl_prodTxFinishedGoodTransferNote_DetailList.Add(tbl_prodTxFinishedGoodTransferNote_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferNote_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxFinishedGoodTransferNote_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxFinishedGoodTransferNote_Detail Maketbl_prodTxFinishedGoodTransferNote_Detail(SqlDataReader dataReader) {
			tbl_prodTxFinishedGoodTransferNote_Detail tbl_prodTxFinishedGoodTransferNote_Detail = new tbl_prodTxFinishedGoodTransferNote_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxFinishedGoodTransferNote_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxFinishedGoodTransferNote_Detail.Fgtn_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxFinishedGoodTransferNote_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxFinishedGoodTransferNote_Detail.Uom_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxFinishedGoodTransferNote_Detail.FgtnQty = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxFinishedGoodTransferNote_Detail.FgtnWeight = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxFinishedGoodTransferNote_Detail.UnitPrice = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodTxFinishedGoodTransferNote_Detail.WeightPrice = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodTxFinishedGoodTransferNote_Detail.TotalAmount = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prodTxFinishedGoodTransferNote_Detail.Remark = dataReader.GetString(9);
			}

			return tbl_prodTxFinishedGoodTransferNote_Detail;
		}
		/// <summary>
		/// This makes tbl_prodTxFinishedGoodTransferNote_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxFinishedGoodTransferNote_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxFinishedGoodTransferNote_Detail  tbl_prodTxFinishedGoodTransferNote_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_fgtn_ID = new DataColumn("fgtn_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_fgtnQty = new DataColumn("fgtnQty" , typeof(decimal));
			DataColumn col_fgtnWeight = new DataColumn("fgtnWeight" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_fgtn_ID,col_item_ID,col_uom_ID,col_fgtnQty,col_fgtnWeight,col_unitPrice,col_weightPrice,col_totalAmount,col_remark,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxFinishedGoodTransferNote_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxFinishedGoodTransferNote_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxFinishedGoodTransferNote_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["fgtn_ID"] = user.fgtn_ID;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["fgtnQty"] = user.fgtnQty;
			drow["fgtnWeight"] = user.fgtnWeight;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["totalAmount"] = user.totalAmount;
			drow["remark"] = user.remark;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
