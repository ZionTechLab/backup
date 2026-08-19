using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_whTxn_Estimation_Detail {
		#region Fields
		private int line_No;
		private string estimation_ID;
		private string item_ID;
		private string remarks;
		private string uom_ID;
		private decimal qty;
		private decimal qtySettle;
		private decimal weight;
		private decimal weightSettle;
		private decimal unitPrice;
		private decimal discountPresentage;
		private decimal discountTotal;
		private decimal amount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_whTxn_Estimation_Detail class.
		/// </summary>
		public tbl_whTxn_Estimation_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_whTxn_Estimation_Detail class.
		/// </summary>
		public tbl_whTxn_Estimation_Detail(int line_No, string estimation_ID, string item_ID, string remarks, string uom_ID, decimal qty, decimal qtySettle, decimal weight, decimal weightSettle, decimal unitPrice, decimal discountPresentage, decimal discountTotal, decimal amount) {
			this.line_No = line_No;
			this.estimation_ID = estimation_ID;
			this.item_ID = item_ID;
			this.remarks = remarks;
			this.uom_ID = uom_ID;
			this.qty = qty;
			this.qtySettle = qtySettle;
			this.weight = weight;
			this.weightSettle = weightSettle;
			this.unitPrice = unitPrice;
			this.discountPresentage = discountPresentage;
			this.discountTotal = discountTotal;
			this.amount = amount;
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
		/// Gets or sets the Estimation_ID value.
		/// </summary>
		public string Estimation_ID {
			get { return estimation_ID; }
			set { estimation_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the QtySettle value.
		/// </summary>
		public decimal QtySettle {
			get { return qtySettle; }
			set { qtySettle = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightSettle value.
		/// </summary>
		public decimal WeightSettle {
			get { return weightSettle; }
			set { weightSettle = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitPrice value.
		/// </summary>
		public decimal UnitPrice {
			get { return unitPrice; }
			set { unitPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountPresentage value.
		/// </summary>
		public decimal DiscountPresentage {
			get { return discountPresentage; }
			set { discountPresentage = value; }
		}
		
		/// <summary>
		/// Gets or sets the DiscountTotal value.
		/// </summary>
		public decimal DiscountTotal {
			get { return discountTotal; }
			set { discountTotal = value; }
		}
		
		/// <summary>
		/// Gets or sets the Amount value.
		/// </summary>
		public decimal Amount {
			get { return amount; }
			set { amount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_whTxn_Estimation_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_Estimation_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@estimation_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,50);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountPresentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@estimation_ID"].Value = estimation_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@discountPresentage"].Value = discountPresentage;
			scom.Parameters["@discountTotal"].Value = discountTotal;
			scom.Parameters["@amount"].Value = amount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_whTxn_Estimation_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_Estimation_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@estimation_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,50);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightSettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountPresentage", SqlDbType.Decimal,9);
			scom.Parameters.Add("@discountTotal", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@estimation_ID"].Value = estimation_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@weightSettle"].Value = weightSettle;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@discountPresentage"].Value = discountPresentage;
			scom.Parameters["@discountTotal"].Value = discountTotal;
			scom.Parameters["@amount"].Value = amount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_whTxn_Estimation_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_Estimation_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@estimation_ID", SqlDbType.VarChar,10);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@estimation_ID"].Value = estimation_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_Estimation_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByEstimation_ID(string estimation_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_Estimation_DetailDeleteAllByEstimation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@estimation_ID", SqlDbType.VarChar,10);
			scom.Parameters["@estimation_ID"].Value = estimation_ID;
 

			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_Estimation_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_Estimation_DetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_whTxn_Estimation_Detail table.
		/// </summary>
		public static tbl_whTxn_Estimation_Detail Select(int line_No_Incoming, string estimation_ID_Incoming){

			tbl_whTxn_Estimation_Detail tbl_whTxn_Estimation_Detailins = new tbl_whTxn_Estimation_Detail();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_Estimation_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@estimation_ID", SqlDbType.VarChar,10);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@estimation_ID"].Value = estimation_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_whTxn_Estimation_Detailins = Maketbl_whTxn_Estimation_Detail(dataReader);
				} else {
					tbl_whTxn_Estimation_Detailins = null;
				}
			}
			scon.Close();
			return tbl_whTxn_Estimation_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_Estimation_Detail table.
		/// </summary>
		public static List<tbl_whTxn_Estimation_Detail> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_Estimation_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_whTxn_Estimation_Detail> tbl_whTxn_Estimation_DetailList = new List<tbl_whTxn_Estimation_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_Estimation_Detail tbl_whTxn_Estimation_Detail = Maketbl_whTxn_Estimation_Detail(dataReader);
					tbl_whTxn_Estimation_DetailList.Add(tbl_whTxn_Estimation_Detail);
				}
			}
			scon.Close();
			return tbl_whTxn_Estimation_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_Estimation_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_whTxn_Estimation_Detail> SelectAllByEstimation_ID(string estimation_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_Estimation_DetailSelectAllByEstimation_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@estimation_ID", SqlDbType.VarChar,10);
			scom.Parameters["@estimation_ID"].Value = estimation_ID;
				List<tbl_whTxn_Estimation_Detail> tbl_whTxn_Estimation_DetailList = new List<tbl_whTxn_Estimation_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_Estimation_Detail tbl_whTxn_Estimation_Detail = Maketbl_whTxn_Estimation_Detail(dataReader);
					tbl_whTxn_Estimation_DetailList.Add(tbl_whTxn_Estimation_Detail);
				}
			}
			scon.Close();
			return tbl_whTxn_Estimation_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_Estimation_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_whTxn_Estimation_Detail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_Estimation_DetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_whTxn_Estimation_Detail> tbl_whTxn_Estimation_DetailList = new List<tbl_whTxn_Estimation_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_Estimation_Detail tbl_whTxn_Estimation_Detail = Maketbl_whTxn_Estimation_Detail(dataReader);
					tbl_whTxn_Estimation_DetailList.Add(tbl_whTxn_Estimation_Detail);
				}
			}
			scon.Close();
			return tbl_whTxn_Estimation_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_whTxn_Estimation_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_whTxn_Estimation_Detail Maketbl_whTxn_Estimation_Detail(SqlDataReader dataReader) {
			tbl_whTxn_Estimation_Detail tbl_whTxn_Estimation_Detail = new tbl_whTxn_Estimation_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_whTxn_Estimation_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_whTxn_Estimation_Detail.Estimation_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_whTxn_Estimation_Detail.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_whTxn_Estimation_Detail.Remarks = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_whTxn_Estimation_Detail.Uom_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_whTxn_Estimation_Detail.Qty = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_whTxn_Estimation_Detail.QtySettle = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_whTxn_Estimation_Detail.Weight = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_whTxn_Estimation_Detail.WeightSettle = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_whTxn_Estimation_Detail.UnitPrice = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_whTxn_Estimation_Detail.DiscountPresentage = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_whTxn_Estimation_Detail.DiscountTotal = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_whTxn_Estimation_Detail.Amount = dataReader.GetDecimal(12);
			}

			return tbl_whTxn_Estimation_Detail;
		}
		/// <summary>
		/// This makes tbl_whTxn_Estimation_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_whTxn_Estimation_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_whTxn_Estimation_Detail  tbl_whTxn_Estimation_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_estimation_ID = new DataColumn("estimation_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_qtySettle = new DataColumn("qtySettle" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_weightSettle = new DataColumn("weightSettle" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_discountPresentage = new DataColumn("discountPresentage" , typeof(decimal));
			DataColumn col_discountTotal = new DataColumn("discountTotal" , typeof(decimal));
			DataColumn col_amount = new DataColumn("amount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_estimation_ID,col_item_ID,col_remarks,col_uom_ID,col_qty,col_qtySettle,col_weight,col_weightSettle,col_unitPrice,col_discountPresentage,col_discountTotal,col_amount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_whTxn_Estimation_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_whTxn_Estimation_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_whTxn_Estimation_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["estimation_ID"] = user.estimation_ID;
			drow["item_ID"] = user.item_ID;
			drow["remarks"] = user.remarks;
			drow["uom_ID"] = user.uom_ID;
			drow["qty"] = user.qty;
			drow["qtySettle"] = user.qtySettle;
			drow["weight"] = user.weight;
			drow["weightSettle"] = user.weightSettle;
			drow["unitPrice"] = user.unitPrice;
			drow["discountPresentage"] = user.discountPresentage;
			drow["discountTotal"] = user.discountTotal;
			drow["amount"] = user.amount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}