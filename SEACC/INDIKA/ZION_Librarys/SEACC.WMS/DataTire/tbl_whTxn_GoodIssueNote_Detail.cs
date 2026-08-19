using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_whTxn_GoodIssueNote_Detail {
		#region Fields
		private int line_No;
		private string goodIssueNote_ID;
		private string goodReceivedNote_ID;
		private string store_ID;
		private string item_ID;
		private string remarks;
		private decimal qty;
		private decimal qtySettle;
		private decimal unitWeight;
		private decimal grossWeight;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_whTxn_GoodIssueNote_Detail class.
		/// </summary>
		public tbl_whTxn_GoodIssueNote_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_whTxn_GoodIssueNote_Detail class.
		/// </summary>
		public tbl_whTxn_GoodIssueNote_Detail(int line_No, string goodIssueNote_ID, string goodReceivedNote_ID, string store_ID, string item_ID, string remarks, decimal qty, decimal qtySettle, decimal unitWeight, decimal grossWeight) {
			this.line_No = line_No;
			this.goodIssueNote_ID = goodIssueNote_ID;
			this.goodReceivedNote_ID = goodReceivedNote_ID;
			this.store_ID = store_ID;
			this.item_ID = item_ID;
			this.remarks = remarks;
			this.qty = qty;
			this.qtySettle = qtySettle;
			this.unitWeight = unitWeight;
			this.grossWeight = grossWeight;
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
		/// Gets or sets the GoodIssueNote_ID value.
		/// </summary>
		public string GoodIssueNote_ID {
			get { return goodIssueNote_ID; }
			set { goodIssueNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the GoodReceivedNote_ID value.
		/// </summary>
		public string GoodReceivedNote_ID {
			get { return goodReceivedNote_ID; }
			set { goodReceivedNote_ID = value; }
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
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
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
		/// Gets or sets the UnitWeight value.
		/// </summary>
		public decimal UnitWeight {
			get { return unitWeight; }
			set { unitWeight = value; }
		}
		
		/// <summary>
		/// Gets or sets the GrossWeight value.
		/// </summary>
		public decimal GrossWeight {
			get { return grossWeight; }
			set { grossWeight = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_whTxn_GoodIssueNote_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodIssueNote_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@GoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@goodReceivedNote_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grossWeight", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@GoodIssueNote_ID"].Value = goodIssueNote_ID;
			scom.Parameters["@goodReceivedNote_ID"].Value = goodReceivedNote_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@unitWeight"].Value = unitWeight;
			scom.Parameters["@grossWeight"].Value = grossWeight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_whTxn_GoodIssueNote_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodIssueNote_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@GoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@goodReceivedNote_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grossWeight", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@GoodIssueNote_ID"].Value = goodIssueNote_ID;
			scom.Parameters["@goodReceivedNote_ID"].Value = goodReceivedNote_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@unitWeight"].Value = unitWeight;
			scom.Parameters["@grossWeight"].Value = grossWeight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_whTxn_GoodIssueNote_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodIssueNote_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@GoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@GoodIssueNote_ID"].Value = goodIssueNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodIssueNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByGoodReceivedNote_ID(string goodReceivedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodIssueNote_DetailDeleteAllByGoodReceivedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@goodReceivedNote_ID", SqlDbType.VarChar,10);
			scom.Parameters["@goodReceivedNote_ID"].Value = goodReceivedNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodIssueNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodIssueNote_DetailDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodIssueNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodIssueNote_DetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodIssueNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByGoodIssueNote_ID(string goodIssueNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodIssueNote_DetailDeleteAllByGoodIssueNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@GoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@GoodIssueNote_ID"].Value = goodIssueNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_whTxn_GoodIssueNote_Detail table.
		/// </summary>
		public static tbl_whTxn_GoodIssueNote_Detail Select(int line_No_Incoming, string goodIssueNote_ID_Incoming){

			tbl_whTxn_GoodIssueNote_Detail tbl_whTxn_GoodIssueNote_Detailins = new tbl_whTxn_GoodIssueNote_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodIssueNote_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@GoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@GoodIssueNote_ID"].Value = goodIssueNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_whTxn_GoodIssueNote_Detailins = Maketbl_whTxn_GoodIssueNote_Detail(dataReader);
				} else {
					tbl_whTxn_GoodIssueNote_Detailins = null;
				}
			}
			scon.Close();
			return tbl_whTxn_GoodIssueNote_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodIssueNote_Detail table.
		/// </summary>
		public static List<tbl_whTxn_GoodIssueNote_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodIssueNote_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_whTxn_GoodIssueNote_Detail> tbl_whTxn_GoodIssueNote_DetailList = new List<tbl_whTxn_GoodIssueNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_GoodIssueNote_Detail tbl_whTxn_GoodIssueNote_Detail = Maketbl_whTxn_GoodIssueNote_Detail(dataReader);
					tbl_whTxn_GoodIssueNote_DetailList.Add(tbl_whTxn_GoodIssueNote_Detail);
				}
			}
			scon.Close();
			return tbl_whTxn_GoodIssueNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodIssueNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_whTxn_GoodIssueNote_Detail> SelectAllByGoodReceivedNote_ID(string goodReceivedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodIssueNote_DetailSelectAllByGoodReceivedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@goodReceivedNote_ID", SqlDbType.VarChar,10);
			scom.Parameters["@goodReceivedNote_ID"].Value = goodReceivedNote_ID;
				List<tbl_whTxn_GoodIssueNote_Detail> tbl_whTxn_GoodIssueNote_DetailList = new List<tbl_whTxn_GoodIssueNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_GoodIssueNote_Detail tbl_whTxn_GoodIssueNote_Detail = Maketbl_whTxn_GoodIssueNote_Detail(dataReader);
					tbl_whTxn_GoodIssueNote_DetailList.Add(tbl_whTxn_GoodIssueNote_Detail);
				}
			}
			scon.Close();
			return tbl_whTxn_GoodIssueNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodIssueNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_whTxn_GoodIssueNote_Detail> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodIssueNote_DetailSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_whTxn_GoodIssueNote_Detail> tbl_whTxn_GoodIssueNote_DetailList = new List<tbl_whTxn_GoodIssueNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_GoodIssueNote_Detail tbl_whTxn_GoodIssueNote_Detail = Maketbl_whTxn_GoodIssueNote_Detail(dataReader);
					tbl_whTxn_GoodIssueNote_DetailList.Add(tbl_whTxn_GoodIssueNote_Detail);
				}
			}
			scon.Close();
			return tbl_whTxn_GoodIssueNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodIssueNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_whTxn_GoodIssueNote_Detail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodIssueNote_DetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_whTxn_GoodIssueNote_Detail> tbl_whTxn_GoodIssueNote_DetailList = new List<tbl_whTxn_GoodIssueNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_GoodIssueNote_Detail tbl_whTxn_GoodIssueNote_Detail = Maketbl_whTxn_GoodIssueNote_Detail(dataReader);
					tbl_whTxn_GoodIssueNote_DetailList.Add(tbl_whTxn_GoodIssueNote_Detail);
				}
			}
			scon.Close();
			return tbl_whTxn_GoodIssueNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodIssueNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_whTxn_GoodIssueNote_Detail> SelectAllByGoodIssueNote_ID(string goodIssueNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodIssueNote_DetailSelectAllByGoodIssueNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@GoodIssueNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@GoodIssueNote_ID"].Value = goodIssueNote_ID;
				List<tbl_whTxn_GoodIssueNote_Detail> tbl_whTxn_GoodIssueNote_DetailList = new List<tbl_whTxn_GoodIssueNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_GoodIssueNote_Detail tbl_whTxn_GoodIssueNote_Detail = Maketbl_whTxn_GoodIssueNote_Detail(dataReader);
					tbl_whTxn_GoodIssueNote_DetailList.Add(tbl_whTxn_GoodIssueNote_Detail);
				}
			}
			scon.Close();
			return tbl_whTxn_GoodIssueNote_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_whTxn_GoodIssueNote_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_whTxn_GoodIssueNote_Detail Maketbl_whTxn_GoodIssueNote_Detail(SqlDataReader dataReader) {
			tbl_whTxn_GoodIssueNote_Detail tbl_whTxn_GoodIssueNote_Detail = new tbl_whTxn_GoodIssueNote_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_whTxn_GoodIssueNote_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_whTxn_GoodIssueNote_Detail.GoodIssueNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_whTxn_GoodIssueNote_Detail.GoodReceivedNote_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_whTxn_GoodIssueNote_Detail.Store_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_whTxn_GoodIssueNote_Detail.Item_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_whTxn_GoodIssueNote_Detail.Remarks = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_whTxn_GoodIssueNote_Detail.Qty = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_whTxn_GoodIssueNote_Detail.QtySettle = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_whTxn_GoodIssueNote_Detail.UnitWeight = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_whTxn_GoodIssueNote_Detail.GrossWeight = dataReader.GetDecimal(9);
			}

			return tbl_whTxn_GoodIssueNote_Detail;
		}
		/// <summary>
		/// This makes tbl_whTxn_GoodIssueNote_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_whTxn_GoodIssueNote_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_whTxn_GoodIssueNote_Detail  tbl_whTxn_GoodIssueNote_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_GoodIssueNote_ID = new DataColumn("GoodIssueNote_ID" , typeof(string));
			DataColumn col_goodReceivedNote_ID = new DataColumn("goodReceivedNote_ID" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_qtySettle = new DataColumn("qtySettle" , typeof(decimal));
			DataColumn col_unitWeight = new DataColumn("unitWeight" , typeof(decimal));
			DataColumn col_grossWeight = new DataColumn("grossWeight" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_GoodIssueNote_ID,col_goodReceivedNote_ID,col_store_ID,col_item_ID,col_remarks,col_qty,col_qtySettle,col_unitWeight,col_grossWeight,});		return dt;
		}
		/// <summary>
		/// This fills tbl_whTxn_GoodIssueNote_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_whTxn_GoodIssueNote_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_whTxn_GoodIssueNote_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["GoodIssueNote_ID"] = user.GoodIssueNote_ID;
			drow["goodReceivedNote_ID"] = user.goodReceivedNote_ID;
			drow["store_ID"] = user.store_ID;
			drow["item_ID"] = user.item_ID;
			drow["remarks"] = user.remarks;
			drow["qty"] = user.qty;
			drow["qtySettle"] = user.qtySettle;
			drow["unitWeight"] = user.unitWeight;
			drow["grossWeight"] = user.grossWeight;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
