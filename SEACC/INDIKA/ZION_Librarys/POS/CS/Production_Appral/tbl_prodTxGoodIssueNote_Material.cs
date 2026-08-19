using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxGoodIssueNote_Material {
		#region Fields
		private int line_No;
		private string pGIN_No;
		private string item_ID;
		private string uom_ID;
		private decimal issued_Qty;
		private decimal storeBalance_Qty;
		private decimal pGIN_Qty;
		private decimal pGIN_Weight;
		private decimal unitPrice;
		private decimal weightPrice;
		private decimal totalAmount;
		private bool isDamaged;
		private string remark;
		private string prodJob_ID;
		private string prodBatch_ID;
		private string mr_No;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxGoodIssueNote_Material class.
		/// </summary>
		public tbl_prodTxGoodIssueNote_Material() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxGoodIssueNote_Material class.
		/// </summary>
		public tbl_prodTxGoodIssueNote_Material(int line_No, string pGIN_No, string item_ID, string uom_ID, decimal issued_Qty, decimal storeBalance_Qty, decimal pGIN_Qty, decimal pGIN_Weight, decimal unitPrice, decimal weightPrice, decimal totalAmount, bool isDamaged, string remark, string prodJob_ID, string prodBatch_ID, string mr_No) {
			this.line_No = line_No;
			this.pGIN_No = pGIN_No;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.issued_Qty = issued_Qty;
			this.storeBalance_Qty = storeBalance_Qty;
			this.pGIN_Qty = pGIN_Qty;
			this.pGIN_Weight = pGIN_Weight;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.totalAmount = totalAmount;
			this.isDamaged = isDamaged;
			this.remark = remark;
			this.prodJob_ID = prodJob_ID;
			this.prodBatch_ID = prodBatch_ID;
			this.mr_No = mr_No;
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
		/// Gets or sets the PGIN_No value.
		/// </summary>
		public string PGIN_No {
			get { return pGIN_No; }
			set { pGIN_No = value; }
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
		/// Gets or sets the Issued_Qty value.
		/// </summary>
		public decimal Issued_Qty {
			get { return issued_Qty; }
			set { issued_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the StoreBalance_Qty value.
		/// </summary>
		public decimal StoreBalance_Qty {
			get { return storeBalance_Qty; }
			set { storeBalance_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the PGIN_Qty value.
		/// </summary>
		public decimal PGIN_Qty {
			get { return pGIN_Qty; }
			set { pGIN_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the PGIN_Weight value.
		/// </summary>
		public decimal PGIN_Weight {
			get { return pGIN_Weight; }
			set { pGIN_Weight = value; }
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
		/// Gets or sets the IsDamaged value.
		/// </summary>
		public bool IsDamaged {
			get { return isDamaged; }
			set { isDamaged = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
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
		/// Gets or sets the Mr_No value.
		/// </summary>
		public string Mr_No {
			get { return mr_No; }
			set { mr_No = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prodTxGoodIssueNote_Material table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNote_MaterialInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@pGIN_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@issued_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@storeBalance_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@pGIN_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@pGIN_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isDamaged", SqlDbType.Bit,1);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@pGIN_No"].Value = pGIN_No;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@issued_Qty"].Value = issued_Qty;
			scom.Parameters["@storeBalance_Qty"].Value = storeBalance_Qty;
			scom.Parameters["@pGIN_Qty"].Value = pGIN_Qty;
			scom.Parameters["@pGIN_Weight"].Value = pGIN_Weight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@isDamaged"].Value = isDamaged;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@mr_No"].Value = mr_No;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxGoodIssueNote_Material table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNote_MaterialUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@pGIN_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@issued_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@storeBalance_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@pGIN_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@pGIN_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isDamaged", SqlDbType.Bit,1);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,200);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@pGIN_No"].Value = pGIN_No;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@issued_Qty"].Value = issued_Qty;
			scom.Parameters["@storeBalance_Qty"].Value = storeBalance_Qty;
			scom.Parameters["@pGIN_Qty"].Value = pGIN_Qty;
			scom.Parameters["@pGIN_Weight"].Value = pGIN_Weight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@isDamaged"].Value = isDamaged;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@mr_No"].Value = mr_No;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxGoodIssueNote_Material table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNote_MaterialDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@pGIN_No", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@pGIN_No"].Value = pGIN_No;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByPGIN_No(string pGIN_No) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNote_MaterialDeleteAllByPGIN_No", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@pGIN_No", SqlDbType.VarChar,20);
			scom.Parameters["@pGIN_No"].Value = pGIN_No;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByMr_No(string mr_No) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNote_MaterialDeleteAllByMr_No", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters["@mr_No"].Value = mr_No;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNote_MaterialDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNote_MaterialDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNote_MaterialDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNote_MaterialDeleteAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxGoodIssueNote_Material table.
		/// </summary>
		public static tbl_prodTxGoodIssueNote_Material Select(int line_No_Incoming, string pGIN_No_Incoming){

			tbl_prodTxGoodIssueNote_Material tbl_prodTxGoodIssueNote_Materialins = new tbl_prodTxGoodIssueNote_Material();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNote_MaterialSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@pGIN_No", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@pGIN_No"].Value = pGIN_No_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxGoodIssueNote_Materialins = Maketbl_prodTxGoodIssueNote_Material(dataReader);
				} else {
					tbl_prodTxGoodIssueNote_Materialins = null;
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNote_Materialins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote_Material table.
		/// </summary>
		public static List<tbl_prodTxGoodIssueNote_Material> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNote_MaterialSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxGoodIssueNote_Material> tbl_prodTxGoodIssueNote_MaterialList = new List<tbl_prodTxGoodIssueNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodIssueNote_Material tbl_prodTxGoodIssueNote_Material = Maketbl_prodTxGoodIssueNote_Material(dataReader);
					tbl_prodTxGoodIssueNote_MaterialList.Add(tbl_prodTxGoodIssueNote_Material);
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodIssueNote_Material> SelectAllByPGIN_No(string pGIN_No) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNote_MaterialSelectAllByPGIN_No", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@pGIN_No", SqlDbType.VarChar,20);
			scom.Parameters["@pGIN_No"].Value = pGIN_No;
				List<tbl_prodTxGoodIssueNote_Material> tbl_prodTxGoodIssueNote_MaterialList = new List<tbl_prodTxGoodIssueNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodIssueNote_Material tbl_prodTxGoodIssueNote_Material = Maketbl_prodTxGoodIssueNote_Material(dataReader);
					tbl_prodTxGoodIssueNote_MaterialList.Add(tbl_prodTxGoodIssueNote_Material);
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodIssueNote_Material> SelectAllByMr_No(string mr_No) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNote_MaterialSelectAllByMr_No", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters["@mr_No"].Value = mr_No;
				List<tbl_prodTxGoodIssueNote_Material> tbl_prodTxGoodIssueNote_MaterialList = new List<tbl_prodTxGoodIssueNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodIssueNote_Material tbl_prodTxGoodIssueNote_Material = Maketbl_prodTxGoodIssueNote_Material(dataReader);
					tbl_prodTxGoodIssueNote_MaterialList.Add(tbl_prodTxGoodIssueNote_Material);
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodIssueNote_Material> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNote_MaterialSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prodTxGoodIssueNote_Material> tbl_prodTxGoodIssueNote_MaterialList = new List<tbl_prodTxGoodIssueNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodIssueNote_Material tbl_prodTxGoodIssueNote_Material = Maketbl_prodTxGoodIssueNote_Material(dataReader);
					tbl_prodTxGoodIssueNote_MaterialList.Add(tbl_prodTxGoodIssueNote_Material);
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodIssueNote_Material> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNote_MaterialSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prodTxGoodIssueNote_Material> tbl_prodTxGoodIssueNote_MaterialList = new List<tbl_prodTxGoodIssueNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodIssueNote_Material tbl_prodTxGoodIssueNote_Material = Maketbl_prodTxGoodIssueNote_Material(dataReader);
					tbl_prodTxGoodIssueNote_MaterialList.Add(tbl_prodTxGoodIssueNote_Material);
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodIssueNote_Material> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNote_MaterialSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_prodTxGoodIssueNote_Material> tbl_prodTxGoodIssueNote_MaterialList = new List<tbl_prodTxGoodIssueNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodIssueNote_Material tbl_prodTxGoodIssueNote_Material = Maketbl_prodTxGoodIssueNote_Material(dataReader);
					tbl_prodTxGoodIssueNote_MaterialList.Add(tbl_prodTxGoodIssueNote_Material);
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxGoodIssueNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxGoodIssueNote_Material> SelectAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxGoodIssueNote_MaterialSelectAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
				List<tbl_prodTxGoodIssueNote_Material> tbl_prodTxGoodIssueNote_MaterialList = new List<tbl_prodTxGoodIssueNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxGoodIssueNote_Material tbl_prodTxGoodIssueNote_Material = Maketbl_prodTxGoodIssueNote_Material(dataReader);
					tbl_prodTxGoodIssueNote_MaterialList.Add(tbl_prodTxGoodIssueNote_Material);
				}
			}
			scon.Close();
			return tbl_prodTxGoodIssueNote_MaterialList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxGoodIssueNote_Material class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxGoodIssueNote_Material Maketbl_prodTxGoodIssueNote_Material(SqlDataReader dataReader) {
			tbl_prodTxGoodIssueNote_Material tbl_prodTxGoodIssueNote_Material = new tbl_prodTxGoodIssueNote_Material();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxGoodIssueNote_Material.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxGoodIssueNote_Material.PGIN_No = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxGoodIssueNote_Material.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxGoodIssueNote_Material.Uom_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxGoodIssueNote_Material.Issued_Qty = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxGoodIssueNote_Material.StoreBalance_Qty = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxGoodIssueNote_Material.PGIN_Qty = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodTxGoodIssueNote_Material.PGIN_Weight = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodTxGoodIssueNote_Material.UnitPrice = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prodTxGoodIssueNote_Material.WeightPrice = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prodTxGoodIssueNote_Material.TotalAmount = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prodTxGoodIssueNote_Material.IsDamaged = dataReader.GetBoolean(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prodTxGoodIssueNote_Material.Remark = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prodTxGoodIssueNote_Material.ProdJob_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prodTxGoodIssueNote_Material.ProdBatch_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prodTxGoodIssueNote_Material.Mr_No = dataReader.GetString(15);
			}

			return tbl_prodTxGoodIssueNote_Material;
		}
		/// <summary>
		/// This makes tbl_prodTxGoodIssueNote_Material datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxGoodIssueNote_Material object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxGoodIssueNote_Material  tbl_prodTxGoodIssueNote_Material   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_pGIN_No = new DataColumn("pGIN_No" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_issued_Qty = new DataColumn("issued_Qty" , typeof(decimal));
			DataColumn col_storeBalance_Qty = new DataColumn("storeBalance_Qty" , typeof(decimal));
			DataColumn col_pGIN_Qty = new DataColumn("pGIN_Qty" , typeof(decimal));
			DataColumn col_pGIN_Weight = new DataColumn("pGIN_Weight" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_isDamaged = new DataColumn("isDamaged" , typeof(bool));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_prodBatch_ID = new DataColumn("prodBatch_ID" , typeof(string));
			DataColumn col_mr_No = new DataColumn("mr_No" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_pGIN_No,col_item_ID,col_uom_ID,col_issued_Qty,col_storeBalance_Qty,col_pGIN_Qty,col_pGIN_Weight,col_unitPrice,col_weightPrice,col_totalAmount,col_isDamaged,col_remark,col_prodJob_ID,col_prodBatch_ID,col_mr_No,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxGoodIssueNote_Material datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxGoodIssueNote_Material object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxGoodIssueNote_Material user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["pGIN_No"] = user.pGIN_No;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["issued_Qty"] = user.issued_Qty;
			drow["storeBalance_Qty"] = user.storeBalance_Qty;
			drow["pGIN_Qty"] = user.pGIN_Qty;
			drow["pGIN_Weight"] = user.pGIN_Weight;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["totalAmount"] = user.totalAmount;
			drow["isDamaged"] = user.isDamaged;
			drow["remark"] = user.remark;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["prodBatch_ID"] = user.prodBatch_ID;
			drow["mr_No"] = user.mr_No;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
