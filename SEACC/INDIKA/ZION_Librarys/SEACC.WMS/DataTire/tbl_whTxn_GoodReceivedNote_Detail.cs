using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_whTxn_GoodReceivedNote_Detail {
		#region Fields
		private string line_No;
		private string goodReceivedNote_ID;
		private string store_ID;
		private string item_ID;
		private string discription;
		private string remarks1;
		private string remarks2;
		private decimal qty;
		private decimal qtySettle;
		private decimal unitWeight;
		private decimal grossWeight;
		private decimal noOfPaletes;
		private decimal damageGoods;
		private DateTime dateExpire;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_whTxn_GoodReceivedNote_Detail class.
		/// </summary>
		public tbl_whTxn_GoodReceivedNote_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_whTxn_GoodReceivedNote_Detail class.
		/// </summary>
		public tbl_whTxn_GoodReceivedNote_Detail(string line_No, string goodReceivedNote_ID, string store_ID, string item_ID, string discription, string remarks1, string remarks2, decimal qty, decimal qtySettle, decimal unitWeight, decimal grossWeight, decimal noOfPaletes, decimal damageGoods, DateTime dateExpire) {
			this.line_No = line_No;
			this.goodReceivedNote_ID = goodReceivedNote_ID;
			this.store_ID = store_ID;
			this.item_ID = item_ID;
			this.discription = discription;
			this.remarks1 = remarks1;
			this.remarks2 = remarks2;
			this.qty = qty;
			this.qtySettle = qtySettle;
			this.unitWeight = unitWeight;
			this.grossWeight = grossWeight;
			this.noOfPaletes = noOfPaletes;
			this.damageGoods = damageGoods;
			this.dateExpire = dateExpire;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Line_No value.
		/// </summary>
		public string Line_No {
			get { return line_No; }
			set { line_No = value; }
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
		/// Gets or sets the Discription value.
		/// </summary>
		public string Discription {
			get { return discription; }
			set { discription = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks1 value.
		/// </summary>
		public string Remarks1 {
			get { return remarks1; }
			set { remarks1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks2 value.
		/// </summary>
		public string Remarks2 {
			get { return remarks2; }
			set { remarks2 = value; }
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
		
		/// <summary>
		/// Gets or sets the NoOfPaletes value.
		/// </summary>
		public decimal NoOfPaletes {
			get { return noOfPaletes; }
			set { noOfPaletes = value; }
		}
		
		/// <summary>
		/// Gets or sets the DamageGoods value.
		/// </summary>
		public decimal DamageGoods {
			get { return damageGoods; }
			set { damageGoods = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateExpire value.
		/// </summary>
		public DateTime DateExpire {
			get { return dateExpire; }
			set { dateExpire = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_whTxn_GoodReceivedNote_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNote_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@GoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@discription", SqlDbType.VarChar,100);
			scom.Parameters.Add("@remarks1", SqlDbType.VarChar,100);
			scom.Parameters.Add("@remarks2", SqlDbType.VarChar,100);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grossWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@noOfPaletes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@damageGoods", SqlDbType.Decimal,9);
			scom.Parameters.Add("@DateExpire", SqlDbType.DateTime,8);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@GoodReceivedNote_ID"].Value = goodReceivedNote_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@discription"].Value = discription;
			scom.Parameters["@remarks1"].Value = remarks1;
			scom.Parameters["@remarks2"].Value = remarks2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@unitWeight"].Value = unitWeight;
			scom.Parameters["@grossWeight"].Value = grossWeight;
			scom.Parameters["@noOfPaletes"].Value = noOfPaletes;
			scom.Parameters["@damageGoods"].Value = damageGoods;
			scom.Parameters["@DateExpire"].Value = dateExpire;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_whTxn_GoodReceivedNote_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNote_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@GoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@discription", SqlDbType.VarChar,100);
			scom.Parameters.Add("@remarks1", SqlDbType.VarChar,100);
			scom.Parameters.Add("@remarks2", SqlDbType.VarChar,100);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qtySettle", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@grossWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@noOfPaletes", SqlDbType.Decimal,9);
			scom.Parameters.Add("@damageGoods", SqlDbType.Decimal,9);
			scom.Parameters.Add("@DateExpire", SqlDbType.DateTime,8);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@GoodReceivedNote_ID"].Value = goodReceivedNote_ID;
			scom.Parameters["@store_ID"].Value = store_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@discription"].Value = discription;
			scom.Parameters["@remarks1"].Value = remarks1;
			scom.Parameters["@remarks2"].Value = remarks2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@qtySettle"].Value = qtySettle;
			scom.Parameters["@unitWeight"].Value = unitWeight;
			scom.Parameters["@grossWeight"].Value = grossWeight;
			scom.Parameters["@noOfPaletes"].Value = noOfPaletes;
			scom.Parameters["@damageGoods"].Value = damageGoods;
			scom.Parameters["@DateExpire"].Value = dateExpire;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_whTxn_GoodReceivedNote_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNote_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@GoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@GoodReceivedNote_ID"].Value = goodReceivedNote_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodReceivedNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByGoodReceivedNote_ID(string goodReceivedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNote_DetailDeleteAllByGoodReceivedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@GoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@GoodReceivedNote_ID"].Value = goodReceivedNote_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodReceivedNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNote_DetailDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodReceivedNote_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNote_DetailDeleteAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_whTxn_GoodReceivedNote_Detail table.
		/// </summary>
		public static tbl_whTxn_GoodReceivedNote_Detail Select(string line_No_Incoming, string goodReceivedNote_ID_Incoming){

			tbl_whTxn_GoodReceivedNote_Detail tbl_whTxn_GoodReceivedNote_Detailins = new tbl_whTxn_GoodReceivedNote_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNote_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@GoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@GoodReceivedNote_ID"].Value = goodReceivedNote_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_whTxn_GoodReceivedNote_Detailins = Maketbl_whTxn_GoodReceivedNote_Detail(dataReader);
				} else {
					tbl_whTxn_GoodReceivedNote_Detailins = null;
				}
			}
			scon.Close();
			return tbl_whTxn_GoodReceivedNote_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodReceivedNote_Detail table.
		/// </summary>
		public static List<tbl_whTxn_GoodReceivedNote_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNote_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_whTxn_GoodReceivedNote_Detail> tbl_whTxn_GoodReceivedNote_DetailList = new List<tbl_whTxn_GoodReceivedNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_GoodReceivedNote_Detail tbl_whTxn_GoodReceivedNote_Detail = Maketbl_whTxn_GoodReceivedNote_Detail(dataReader);
					tbl_whTxn_GoodReceivedNote_DetailList.Add(tbl_whTxn_GoodReceivedNote_Detail);
				}
			}
			scon.Close();
			return tbl_whTxn_GoodReceivedNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodReceivedNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_whTxn_GoodReceivedNote_Detail> SelectAllByGoodReceivedNote_ID(string goodReceivedNote_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNote_DetailSelectAllByGoodReceivedNote_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@GoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters["@GoodReceivedNote_ID"].Value = goodReceivedNote_ID;
				List<tbl_whTxn_GoodReceivedNote_Detail> tbl_whTxn_GoodReceivedNote_DetailList = new List<tbl_whTxn_GoodReceivedNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_GoodReceivedNote_Detail tbl_whTxn_GoodReceivedNote_Detail = Maketbl_whTxn_GoodReceivedNote_Detail(dataReader);
					tbl_whTxn_GoodReceivedNote_DetailList.Add(tbl_whTxn_GoodReceivedNote_Detail);
				}
			}
			scon.Close();
			return tbl_whTxn_GoodReceivedNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodReceivedNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_whTxn_GoodReceivedNote_Detail> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNote_DetailSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_whTxn_GoodReceivedNote_Detail> tbl_whTxn_GoodReceivedNote_DetailList = new List<tbl_whTxn_GoodReceivedNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_GoodReceivedNote_Detail tbl_whTxn_GoodReceivedNote_Detail = Maketbl_whTxn_GoodReceivedNote_Detail(dataReader);
					tbl_whTxn_GoodReceivedNote_DetailList.Add(tbl_whTxn_GoodReceivedNote_Detail);
				}
			}
			scon.Close();
			return tbl_whTxn_GoodReceivedNote_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_whTxn_GoodReceivedNote_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_whTxn_GoodReceivedNote_Detail> SelectAllByStore_ID(string store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_whTxn_GoodReceivedNote_DetailSelectAllByStore_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@store_ID"].Value = store_ID;
				List<tbl_whTxn_GoodReceivedNote_Detail> tbl_whTxn_GoodReceivedNote_DetailList = new List<tbl_whTxn_GoodReceivedNote_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_whTxn_GoodReceivedNote_Detail tbl_whTxn_GoodReceivedNote_Detail = Maketbl_whTxn_GoodReceivedNote_Detail(dataReader);
					tbl_whTxn_GoodReceivedNote_DetailList.Add(tbl_whTxn_GoodReceivedNote_Detail);
				}
			}
			scon.Close();
			return tbl_whTxn_GoodReceivedNote_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_whTxn_GoodReceivedNote_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_whTxn_GoodReceivedNote_Detail Maketbl_whTxn_GoodReceivedNote_Detail(SqlDataReader dataReader) {
			tbl_whTxn_GoodReceivedNote_Detail tbl_whTxn_GoodReceivedNote_Detail = new tbl_whTxn_GoodReceivedNote_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_whTxn_GoodReceivedNote_Detail.Line_No = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_whTxn_GoodReceivedNote_Detail.GoodReceivedNote_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_whTxn_GoodReceivedNote_Detail.Store_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_whTxn_GoodReceivedNote_Detail.Item_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_whTxn_GoodReceivedNote_Detail.Discription = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_whTxn_GoodReceivedNote_Detail.Remarks1 = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_whTxn_GoodReceivedNote_Detail.Remarks2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_whTxn_GoodReceivedNote_Detail.Qty = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_whTxn_GoodReceivedNote_Detail.QtySettle = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_whTxn_GoodReceivedNote_Detail.UnitWeight = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_whTxn_GoodReceivedNote_Detail.GrossWeight = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_whTxn_GoodReceivedNote_Detail.NoOfPaletes = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_whTxn_GoodReceivedNote_Detail.DamageGoods = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_whTxn_GoodReceivedNote_Detail.DateExpire = dataReader.GetDateTime(13);
			}

			return tbl_whTxn_GoodReceivedNote_Detail;
		}
		/// <summary>
		/// This makes tbl_whTxn_GoodReceivedNote_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_whTxn_GoodReceivedNote_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_whTxn_GoodReceivedNote_Detail  tbl_whTxn_GoodReceivedNote_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(string));
			DataColumn col_GoodReceivedNote_ID = new DataColumn("GoodReceivedNote_ID" , typeof(string));
			DataColumn col_store_ID = new DataColumn("store_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_discription = new DataColumn("discription" , typeof(string));
			DataColumn col_remarks1 = new DataColumn("remarks1" , typeof(string));
			DataColumn col_remarks2 = new DataColumn("remarks2" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_qtySettle = new DataColumn("qtySettle" , typeof(decimal));
			DataColumn col_unitWeight = new DataColumn("unitWeight" , typeof(decimal));
			DataColumn col_grossWeight = new DataColumn("grossWeight" , typeof(decimal));
			DataColumn col_noOfPaletes = new DataColumn("noOfPaletes" , typeof(decimal));
			DataColumn col_damageGoods = new DataColumn("damageGoods" , typeof(decimal));
			DataColumn col_DateExpire = new DataColumn("DateExpire" , typeof(DateTime));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_GoodReceivedNote_ID,col_store_ID,col_item_ID,col_discription,col_remarks1,col_remarks2,col_qty,col_qtySettle,col_unitWeight,col_grossWeight,col_noOfPaletes,col_damageGoods,col_DateExpire,});		return dt;
		}
		/// <summary>
		/// This fills tbl_whTxn_GoodReceivedNote_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_whTxn_GoodReceivedNote_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_whTxn_GoodReceivedNote_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["GoodReceivedNote_ID"] = user.GoodReceivedNote_ID;
			drow["store_ID"] = user.store_ID;
			drow["item_ID"] = user.item_ID;
			drow["discription"] = user.discription;
			drow["remarks1"] = user.remarks1;
			drow["remarks2"] = user.remarks2;
			drow["qty"] = user.qty;
			drow["qtySettle"] = user.qtySettle;
			drow["unitWeight"] = user.unitWeight;
			drow["grossWeight"] = user.grossWeight;
			drow["noOfPaletes"] = user.noOfPaletes;
			drow["damageGoods"] = user.damageGoods;
			drow["DateExpire"] = user.DateExpire;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
