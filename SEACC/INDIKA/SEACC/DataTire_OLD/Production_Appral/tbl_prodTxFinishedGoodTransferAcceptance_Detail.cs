using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxFinishedGoodTransferAcceptance_Detail {
		#region Fields
		private int line_No;
		private string acceptance_ID;
		private string prodJob_ID;
		private string prodBatch_ID;
		private string fgtn_ID;
		private string item_ID_FG;
		private string uom_ID;
		private decimal fgtnQty;
		private decimal fgtn_PendigQty;
		private decimal prevAcceptanceQty;
		private decimal acceptanceQty;
		private decimal acceptanceWeight;
		private decimal unitPrice;
		private decimal weightPrice;
		private decimal totalAmount;
		private string from_Store_ID;
		private string to_Store_ID;
		private string remark;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxFinishedGoodTransferAcceptance_Detail class.
		/// </summary>
		public tbl_prodTxFinishedGoodTransferAcceptance_Detail() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxFinishedGoodTransferAcceptance_Detail class.
		/// </summary>
		public tbl_prodTxFinishedGoodTransferAcceptance_Detail(int line_No, string acceptance_ID, string prodJob_ID, string prodBatch_ID, string fgtn_ID, string item_ID_FG, string uom_ID, decimal fgtnQty, decimal fgtn_PendigQty, decimal prevAcceptanceQty, decimal acceptanceQty, decimal acceptanceWeight, decimal unitPrice, decimal weightPrice, decimal totalAmount, string from_Store_ID, string to_Store_ID, string remark) {
			this.line_No = line_No;
			this.acceptance_ID = acceptance_ID;
			this.prodJob_ID = prodJob_ID;
			this.prodBatch_ID = prodBatch_ID;
			this.fgtn_ID = fgtn_ID;
			this.item_ID_FG = item_ID_FG;
			this.uom_ID = uom_ID;
			this.fgtnQty = fgtnQty;
			this.fgtn_PendigQty = fgtn_PendigQty;
			this.prevAcceptanceQty = prevAcceptanceQty;
			this.acceptanceQty = acceptanceQty;
			this.acceptanceWeight = acceptanceWeight;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.totalAmount = totalAmount;
			this.from_Store_ID = from_Store_ID;
			this.to_Store_ID = to_Store_ID;
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
		/// Gets or sets the Acceptance_ID value.
		/// </summary>
		public string Acceptance_ID {
			get { return acceptance_ID; }
			set { acceptance_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdJob_ID value.
		/// </summary>
		public string ProdJob_ID {
			get { return prodJob_ID; }
			set { prodJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ProdBatch_ID value.
		/// </summary>
		public string ProdBatch_ID {
			get { return prodBatch_ID; }
			set { prodBatch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Fgtn_ID value.
		/// </summary>
		public string Fgtn_ID {
			get { return fgtn_ID; }
			set { fgtn_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID_FG value.
		/// </summary>
		public string Item_ID_FG {
			get { return item_ID_FG; }
			set { item_ID_FG = value; }
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
		/// Gets or sets the Fgtn_PendigQty value.
		/// </summary>
		public decimal Fgtn_PendigQty {
			get { return fgtn_PendigQty; }
			set { fgtn_PendigQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the PrevAcceptanceQty value.
		/// </summary>
		public decimal PrevAcceptanceQty {
			get { return prevAcceptanceQty; }
			set { prevAcceptanceQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the AcceptanceQty value.
		/// </summary>
		public decimal AcceptanceQty {
			get { return acceptanceQty; }
			set { acceptanceQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the AcceptanceWeight value.
		/// </summary>
		public decimal AcceptanceWeight {
			get { return acceptanceWeight; }
			set { acceptanceWeight = value; }
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
		/// Gets or sets the From_Store_ID value.
		/// </summary>
		public string From_Store_ID {
			get { return from_Store_ID; }
			set { from_Store_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the To_Store_ID value.
		/// </summary>
		public string To_Store_ID {
			get { return to_Store_ID; }
			set { to_Store_ID = value; }
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
		/// Saves a record to the tbl_prodTxFinishedGoodTransferAcceptance_Detail table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@acceptance_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@fgtnQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@fgtn_PendigQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@prevAcceptanceQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@acceptanceQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@acceptanceWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@from_Store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@to_Store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@acceptance_ID"].Value = acceptance_ID;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@fgtnQty"].Value = fgtnQty;
			scom.Parameters["@fgtn_PendigQty"].Value = fgtn_PendigQty;
			scom.Parameters["@prevAcceptanceQty"].Value = prevAcceptanceQty;
			scom.Parameters["@acceptanceQty"].Value = acceptanceQty;
			scom.Parameters["@acceptanceWeight"].Value = acceptanceWeight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@from_Store_ID"].Value = from_Store_ID;
			scom.Parameters["@to_Store_ID"].Value = to_Store_ID;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxFinishedGoodTransferAcceptance_Detail table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@acceptance_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@fgtnQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@fgtn_PendigQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@prevAcceptanceQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@acceptanceQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@acceptanceWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@from_Store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@to_Store_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@acceptance_ID"].Value = acceptance_ID;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@fgtnQty"].Value = fgtnQty;
			scom.Parameters["@fgtn_PendigQty"].Value = fgtn_PendigQty;
			scom.Parameters["@prevAcceptanceQty"].Value = prevAcceptanceQty;
			scom.Parameters["@acceptanceQty"].Value = acceptanceQty;
			scom.Parameters["@acceptanceWeight"].Value = acceptanceWeight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@from_Store_ID"].Value = from_Store_ID;
			scom.Parameters["@to_Store_ID"].Value = to_Store_ID;
			scom.Parameters["@remark"].Value = remark;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@acceptance_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@acceptance_ID"].Value = acceptance_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByFgtn_ID(string fgtn_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailDeleteAllByFgtn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByTo_Store_ID(string to_Store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailDeleteAllByTo_Store_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@to_Store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@to_Store_ID"].Value = to_Store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailDeleteAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByFrom_Store_ID(string from_Store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailDeleteAllByFrom_Store_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@from_Store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@from_Store_ID"].Value = from_Store_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByAcceptance_ID(string acceptance_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailDeleteAllByAcceptance_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@acceptance_ID", SqlDbType.VarChar,20);
			scom.Parameters["@acceptance_ID"].Value = acceptance_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID_FG(string item_ID_FG) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailDeleteAllByItem_ID_FG", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table.
		/// </summary>
		public static tbl_prodTxFinishedGoodTransferAcceptance_Detail Select(int line_No_Incoming, string acceptance_ID_Incoming){

			tbl_prodTxFinishedGoodTransferAcceptance_Detail tbl_prodTxFinishedGoodTransferAcceptance_Detailins = new tbl_prodTxFinishedGoodTransferAcceptance_Detail();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@acceptance_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@acceptance_ID"].Value = acceptance_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptance_Detailins = Maketbl_prodTxFinishedGoodTransferAcceptance_Detail(dataReader);
				} else {
					tbl_prodTxFinishedGoodTransferAcceptance_Detailins = null;
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptance_Detailins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferAcceptance_Detail> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxFinishedGoodTransferAcceptance_Detail> tbl_prodTxFinishedGoodTransferAcceptance_DetailList = new List<tbl_prodTxFinishedGoodTransferAcceptance_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptance_Detail tbl_prodTxFinishedGoodTransferAcceptance_Detail = Maketbl_prodTxFinishedGoodTransferAcceptance_Detail(dataReader);
					tbl_prodTxFinishedGoodTransferAcceptance_DetailList.Add(tbl_prodTxFinishedGoodTransferAcceptance_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptance_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferAcceptance_Detail> SelectAllByFgtn_ID(string fgtn_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailSelectAllByFgtn_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@fgtn_ID", SqlDbType.VarChar,20);
			scom.Parameters["@fgtn_ID"].Value = fgtn_ID;
				List<tbl_prodTxFinishedGoodTransferAcceptance_Detail> tbl_prodTxFinishedGoodTransferAcceptance_DetailList = new List<tbl_prodTxFinishedGoodTransferAcceptance_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptance_Detail tbl_prodTxFinishedGoodTransferAcceptance_Detail = Maketbl_prodTxFinishedGoodTransferAcceptance_Detail(dataReader);
					tbl_prodTxFinishedGoodTransferAcceptance_DetailList.Add(tbl_prodTxFinishedGoodTransferAcceptance_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptance_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferAcceptance_Detail> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prodTxFinishedGoodTransferAcceptance_Detail> tbl_prodTxFinishedGoodTransferAcceptance_DetailList = new List<tbl_prodTxFinishedGoodTransferAcceptance_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptance_Detail tbl_prodTxFinishedGoodTransferAcceptance_Detail = Maketbl_prodTxFinishedGoodTransferAcceptance_Detail(dataReader);
					tbl_prodTxFinishedGoodTransferAcceptance_DetailList.Add(tbl_prodTxFinishedGoodTransferAcceptance_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptance_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferAcceptance_Detail> SelectAllByTo_Store_ID(string to_Store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailSelectAllByTo_Store_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@to_Store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@to_Store_ID"].Value = to_Store_ID;
				List<tbl_prodTxFinishedGoodTransferAcceptance_Detail> tbl_prodTxFinishedGoodTransferAcceptance_DetailList = new List<tbl_prodTxFinishedGoodTransferAcceptance_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptance_Detail tbl_prodTxFinishedGoodTransferAcceptance_Detail = Maketbl_prodTxFinishedGoodTransferAcceptance_Detail(dataReader);
					tbl_prodTxFinishedGoodTransferAcceptance_DetailList.Add(tbl_prodTxFinishedGoodTransferAcceptance_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptance_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferAcceptance_Detail> SelectAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailSelectAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
				List<tbl_prodTxFinishedGoodTransferAcceptance_Detail> tbl_prodTxFinishedGoodTransferAcceptance_DetailList = new List<tbl_prodTxFinishedGoodTransferAcceptance_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptance_Detail tbl_prodTxFinishedGoodTransferAcceptance_Detail = Maketbl_prodTxFinishedGoodTransferAcceptance_Detail(dataReader);
					tbl_prodTxFinishedGoodTransferAcceptance_DetailList.Add(tbl_prodTxFinishedGoodTransferAcceptance_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptance_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferAcceptance_Detail> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prodTxFinishedGoodTransferAcceptance_Detail> tbl_prodTxFinishedGoodTransferAcceptance_DetailList = new List<tbl_prodTxFinishedGoodTransferAcceptance_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptance_Detail tbl_prodTxFinishedGoodTransferAcceptance_Detail = Maketbl_prodTxFinishedGoodTransferAcceptance_Detail(dataReader);
					tbl_prodTxFinishedGoodTransferAcceptance_DetailList.Add(tbl_prodTxFinishedGoodTransferAcceptance_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptance_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferAcceptance_Detail> SelectAllByFrom_Store_ID(string from_Store_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailSelectAllByFrom_Store_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@from_Store_ID", SqlDbType.VarChar,20);
			scom.Parameters["@from_Store_ID"].Value = from_Store_ID;
				List<tbl_prodTxFinishedGoodTransferAcceptance_Detail> tbl_prodTxFinishedGoodTransferAcceptance_DetailList = new List<tbl_prodTxFinishedGoodTransferAcceptance_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptance_Detail tbl_prodTxFinishedGoodTransferAcceptance_Detail = Maketbl_prodTxFinishedGoodTransferAcceptance_Detail(dataReader);
					tbl_prodTxFinishedGoodTransferAcceptance_DetailList.Add(tbl_prodTxFinishedGoodTransferAcceptance_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptance_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferAcceptance_Detail> SelectAllByAcceptance_ID(string acceptance_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailSelectAllByAcceptance_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@acceptance_ID", SqlDbType.VarChar,20);
			scom.Parameters["@acceptance_ID"].Value = acceptance_ID;
				List<tbl_prodTxFinishedGoodTransferAcceptance_Detail> tbl_prodTxFinishedGoodTransferAcceptance_DetailList = new List<tbl_prodTxFinishedGoodTransferAcceptance_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptance_Detail tbl_prodTxFinishedGoodTransferAcceptance_Detail = Maketbl_prodTxFinishedGoodTransferAcceptance_Detail(dataReader);
					tbl_prodTxFinishedGoodTransferAcceptance_DetailList.Add(tbl_prodTxFinishedGoodTransferAcceptance_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptance_DetailList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxFinishedGoodTransferAcceptance_Detail table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxFinishedGoodTransferAcceptance_Detail> SelectAllByItem_ID_FG(string item_ID_FG) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxFinishedGoodTransferAcceptance_DetailSelectAllByItem_ID_FG", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
				List<tbl_prodTxFinishedGoodTransferAcceptance_Detail> tbl_prodTxFinishedGoodTransferAcceptance_DetailList = new List<tbl_prodTxFinishedGoodTransferAcceptance_Detail>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxFinishedGoodTransferAcceptance_Detail tbl_prodTxFinishedGoodTransferAcceptance_Detail = Maketbl_prodTxFinishedGoodTransferAcceptance_Detail(dataReader);
					tbl_prodTxFinishedGoodTransferAcceptance_DetailList.Add(tbl_prodTxFinishedGoodTransferAcceptance_Detail);
				}
			}
			scon.Close();
			return tbl_prodTxFinishedGoodTransferAcceptance_DetailList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxFinishedGoodTransferAcceptance_Detail class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxFinishedGoodTransferAcceptance_Detail Maketbl_prodTxFinishedGoodTransferAcceptance_Detail(SqlDataReader dataReader) {
			tbl_prodTxFinishedGoodTransferAcceptance_Detail tbl_prodTxFinishedGoodTransferAcceptance_Detail = new tbl_prodTxFinishedGoodTransferAcceptance_Detail();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance_Detail.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance_Detail.Acceptance_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance_Detail.ProdJob_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance_Detail.ProdBatch_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance_Detail.Fgtn_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance_Detail.Item_ID_FG = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance_Detail.Uom_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance_Detail.FgtnQty = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance_Detail.Fgtn_PendigQty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance_Detail.PrevAcceptanceQty = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance_Detail.AcceptanceQty = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance_Detail.AcceptanceWeight = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance_Detail.UnitPrice = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance_Detail.WeightPrice = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance_Detail.TotalAmount = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance_Detail.From_Store_ID = dataReader.GetString(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance_Detail.To_Store_ID = dataReader.GetString(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_prodTxFinishedGoodTransferAcceptance_Detail.Remark = dataReader.GetString(17);
			}

			return tbl_prodTxFinishedGoodTransferAcceptance_Detail;
		}
		/// <summary>
		/// This makes tbl_prodTxFinishedGoodTransferAcceptance_Detail datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxFinishedGoodTransferAcceptance_Detail object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxFinishedGoodTransferAcceptance_Detail  tbl_prodTxFinishedGoodTransferAcceptance_Detail   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_acceptance_ID = new DataColumn("acceptance_ID" , typeof(string));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_prodBatch_ID = new DataColumn("prodBatch_ID" , typeof(string));
			DataColumn col_fgtn_ID = new DataColumn("fgtn_ID" , typeof(string));
			DataColumn col_item_ID_FG = new DataColumn("item_ID_FG" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_fgtnQty = new DataColumn("fgtnQty" , typeof(decimal));
			DataColumn col_fgtn_PendigQty = new DataColumn("fgtn_PendigQty" , typeof(decimal));
			DataColumn col_prevAcceptanceQty = new DataColumn("prevAcceptanceQty" , typeof(decimal));
			DataColumn col_acceptanceQty = new DataColumn("acceptanceQty" , typeof(decimal));
			DataColumn col_acceptanceWeight = new DataColumn("acceptanceWeight" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_from_Store_ID = new DataColumn("from_Store_ID" , typeof(string));
			DataColumn col_to_Store_ID = new DataColumn("to_Store_ID" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_acceptance_ID,col_prodJob_ID,col_prodBatch_ID,col_fgtn_ID,col_item_ID_FG,col_uom_ID,col_fgtnQty,col_fgtn_PendigQty,col_prevAcceptanceQty,col_acceptanceQty,col_acceptanceWeight,col_unitPrice,col_weightPrice,col_totalAmount,col_from_Store_ID,col_to_Store_ID,col_remark,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxFinishedGoodTransferAcceptance_Detail datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxFinishedGoodTransferAcceptance_Detail object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxFinishedGoodTransferAcceptance_Detail user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["acceptance_ID"] = user.acceptance_ID;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["prodBatch_ID"] = user.prodBatch_ID;
			drow["fgtn_ID"] = user.fgtn_ID;
			drow["item_ID_FG"] = user.item_ID_FG;
			drow["uom_ID"] = user.uom_ID;
			drow["fgtnQty"] = user.fgtnQty;
			drow["fgtn_PendigQty"] = user.fgtn_PendigQty;
			drow["prevAcceptanceQty"] = user.prevAcceptanceQty;
			drow["acceptanceQty"] = user.acceptanceQty;
			drow["acceptanceWeight"] = user.acceptanceWeight;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["totalAmount"] = user.totalAmount;
			drow["from_Store_ID"] = user.from_Store_ID;
			drow["to_Store_ID"] = user.to_Store_ID;
			drow["remark"] = user.remark;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
