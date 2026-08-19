using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaTxSubContractOutNote_Material {
		#region Fields
		private int line_No;
		private string subOut_ID;
		private bool isSemiFG_item;
		private string prodJob_ID;
		private string prodBatch_ID;
		private string semiFG_item_ID;
		private string item_ID;
		private string uom_ID;
		private decimal available_Qty;
		private decimal bom_Qty;
		private decimal bom_Issued_Qty;
		private decimal bom_Balance_Qty;
		private decimal son_Qty;
		private decimal son_Weight;
		private decimal unitPrice;
		private decimal weightPrice;
		private decimal totalAmount;
		private string remarks;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxSubContractOutNote_Material class.
		/// </summary>
		public tbl_prod_pharmaTxSubContractOutNote_Material() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxSubContractOutNote_Material class.
		/// </summary>
		public tbl_prod_pharmaTxSubContractOutNote_Material(int line_No, string subOut_ID, bool isSemiFG_item, string prodJob_ID, string prodBatch_ID, string semiFG_item_ID, string item_ID, string uom_ID, decimal available_Qty, decimal bom_Qty, decimal bom_Issued_Qty, decimal bom_Balance_Qty, decimal son_Qty, decimal son_Weight, decimal unitPrice, decimal weightPrice, decimal totalAmount, string remarks) {
			this.line_No = line_No;
			this.subOut_ID = subOut_ID;
			this.isSemiFG_item = isSemiFG_item;
			this.prodJob_ID = prodJob_ID;
			this.prodBatch_ID = prodBatch_ID;
			this.semiFG_item_ID = semiFG_item_ID;
			this.item_ID = item_ID;
			this.uom_ID = uom_ID;
			this.available_Qty = available_Qty;
			this.bom_Qty = bom_Qty;
			this.bom_Issued_Qty = bom_Issued_Qty;
			this.bom_Balance_Qty = bom_Balance_Qty;
			this.son_Qty = son_Qty;
			this.son_Weight = son_Weight;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.totalAmount = totalAmount;
			this.remarks = remarks;
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
		/// Gets or sets the SubOut_ID value.
		/// </summary>
		public string SubOut_ID {
			get { return subOut_ID; }
			set { subOut_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSemiFG_item value.
		/// </summary>
		public bool IsSemiFG_item {
			get { return isSemiFG_item; }
			set { isSemiFG_item = value; }
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
		/// Gets or sets the SemiFG_item_ID value.
		/// </summary>
		public string SemiFG_item_ID {
			get { return semiFG_item_ID; }
			set { semiFG_item_ID = value; }
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
		/// Gets or sets the Available_Qty value.
		/// </summary>
		public decimal Available_Qty {
			get { return available_Qty; }
			set { available_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Bom_Qty value.
		/// </summary>
		public decimal Bom_Qty {
			get { return bom_Qty; }
			set { bom_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Bom_Issued_Qty value.
		/// </summary>
		public decimal Bom_Issued_Qty {
			get { return bom_Issued_Qty; }
			set { bom_Issued_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Bom_Balance_Qty value.
		/// </summary>
		public decimal Bom_Balance_Qty {
			get { return bom_Balance_Qty; }
			set { bom_Balance_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Son_Qty value.
		/// </summary>
		public decimal Son_Qty {
			get { return son_Qty; }
			set { son_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Son_Weight value.
		/// </summary>
		public decimal Son_Weight {
			get { return son_Weight; }
			set { son_Weight = value; }
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
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prod_pharmaTxSubContractOutNote_Material table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_MaterialInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isSemiFG_item", SqlDbType.Bit,1);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@semiFG_item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@available_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bom_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bom_Issued_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bom_Balance_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@son_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@son_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@subOut_ID"].Value = subOut_ID;
			scom.Parameters["@isSemiFG_item"].Value = isSemiFG_item;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@semiFG_item_ID"].Value = semiFG_item_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@available_Qty"].Value = available_Qty;
			scom.Parameters["@bom_Qty"].Value = bom_Qty;
			scom.Parameters["@bom_Issued_Qty"].Value = bom_Issued_Qty;
			scom.Parameters["@bom_Balance_Qty"].Value = bom_Balance_Qty;
			scom.Parameters["@son_Qty"].Value = son_Qty;
			scom.Parameters["@son_Weight"].Value = son_Weight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_pharmaTxSubContractOutNote_Material table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_MaterialUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isSemiFG_item", SqlDbType.Bit,1);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@semiFG_item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@available_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bom_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bom_Issued_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bom_Balance_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@son_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@son_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@subOut_ID"].Value = subOut_ID;
			scom.Parameters["@isSemiFG_item"].Value = isSemiFG_item;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@semiFG_item_ID"].Value = semiFG_item_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@available_Qty"].Value = available_Qty;
			scom.Parameters["@bom_Qty"].Value = bom_Qty;
			scom.Parameters["@bom_Issued_Qty"].Value = bom_Issued_Qty;
			scom.Parameters["@bom_Balance_Qty"].Value = bom_Balance_Qty;
			scom.Parameters["@son_Qty"].Value = son_Qty;
			scom.Parameters["@son_Weight"].Value = son_Weight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_pharmaTxSubContractOutNote_Material table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_MaterialDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isSemiFG_item", SqlDbType.Bit,1);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@subOut_ID"].Value = subOut_ID;
 
			scom.Parameters["@isSemiFG_item"].Value = isSemiFG_item;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_MaterialDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_MaterialDeleteAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllBySubOut_ID(string subOut_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_MaterialDeleteAllBySubOut_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters["@subOut_ID"].Value = subOut_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_MaterialDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_MaterialDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllBySemiFG_item_ID(string semiFG_item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_MaterialDeleteAllBySemiFG_item_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@semiFG_item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@semiFG_item_ID"].Value = semiFG_item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_pharmaTxSubContractOutNote_Material table.
		/// </summary>
		public static tbl_prod_pharmaTxSubContractOutNote_Material Select(int line_No_Incoming, string subOut_ID_Incoming, bool isSemiFG_item_Incoming){

			tbl_prod_pharmaTxSubContractOutNote_Material tbl_prod_pharmaTxSubContractOutNote_Materialins = new tbl_prod_pharmaTxSubContractOutNote_Material();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_MaterialSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isSemiFG_item", SqlDbType.Bit,1);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@subOut_ID"].Value = subOut_ID_Incoming;
			scom.Parameters["@isSemiFG_item"].Value = isSemiFG_item_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote_Materialins = Maketbl_prod_pharmaTxSubContractOutNote_Material(dataReader);
				} else {
					tbl_prod_pharmaTxSubContractOutNote_Materialins = null;
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNote_Materialins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_Material table.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote_Material> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_MaterialSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_pharmaTxSubContractOutNote_Material> tbl_prod_pharmaTxSubContractOutNote_MaterialList = new List<tbl_prod_pharmaTxSubContractOutNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote_Material tbl_prod_pharmaTxSubContractOutNote_Material = Maketbl_prod_pharmaTxSubContractOutNote_Material(dataReader);
					tbl_prod_pharmaTxSubContractOutNote_MaterialList.Add(tbl_prod_pharmaTxSubContractOutNote_Material);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote_Material> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_MaterialSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prod_pharmaTxSubContractOutNote_Material> tbl_prod_pharmaTxSubContractOutNote_MaterialList = new List<tbl_prod_pharmaTxSubContractOutNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote_Material tbl_prod_pharmaTxSubContractOutNote_Material = Maketbl_prod_pharmaTxSubContractOutNote_Material(dataReader);
					tbl_prod_pharmaTxSubContractOutNote_MaterialList.Add(tbl_prod_pharmaTxSubContractOutNote_Material);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote_Material> SelectAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_MaterialSelectAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
				List<tbl_prod_pharmaTxSubContractOutNote_Material> tbl_prod_pharmaTxSubContractOutNote_MaterialList = new List<tbl_prod_pharmaTxSubContractOutNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote_Material tbl_prod_pharmaTxSubContractOutNote_Material = Maketbl_prod_pharmaTxSubContractOutNote_Material(dataReader);
					tbl_prod_pharmaTxSubContractOutNote_MaterialList.Add(tbl_prod_pharmaTxSubContractOutNote_Material);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote_Material> SelectAllBySubOut_ID(string subOut_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_MaterialSelectAllBySubOut_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters["@subOut_ID"].Value = subOut_ID;
				List<tbl_prod_pharmaTxSubContractOutNote_Material> tbl_prod_pharmaTxSubContractOutNote_MaterialList = new List<tbl_prod_pharmaTxSubContractOutNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote_Material tbl_prod_pharmaTxSubContractOutNote_Material = Maketbl_prod_pharmaTxSubContractOutNote_Material(dataReader);
					tbl_prod_pharmaTxSubContractOutNote_MaterialList.Add(tbl_prod_pharmaTxSubContractOutNote_Material);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote_Material> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_MaterialSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_prod_pharmaTxSubContractOutNote_Material> tbl_prod_pharmaTxSubContractOutNote_MaterialList = new List<tbl_prod_pharmaTxSubContractOutNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote_Material tbl_prod_pharmaTxSubContractOutNote_Material = Maketbl_prod_pharmaTxSubContractOutNote_Material(dataReader);
					tbl_prod_pharmaTxSubContractOutNote_MaterialList.Add(tbl_prod_pharmaTxSubContractOutNote_Material);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote_Material> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_MaterialSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prod_pharmaTxSubContractOutNote_Material> tbl_prod_pharmaTxSubContractOutNote_MaterialList = new List<tbl_prod_pharmaTxSubContractOutNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote_Material tbl_prod_pharmaTxSubContractOutNote_Material = Maketbl_prod_pharmaTxSubContractOutNote_Material(dataReader);
					tbl_prod_pharmaTxSubContractOutNote_MaterialList.Add(tbl_prod_pharmaTxSubContractOutNote_Material);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNote_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_Material table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote_Material> SelectAllBySemiFG_item_ID(string semiFG_item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_MaterialSelectAllBySemiFG_item_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@semiFG_item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@semiFG_item_ID"].Value = semiFG_item_ID;
				List<tbl_prod_pharmaTxSubContractOutNote_Material> tbl_prod_pharmaTxSubContractOutNote_MaterialList = new List<tbl_prod_pharmaTxSubContractOutNote_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote_Material tbl_prod_pharmaTxSubContractOutNote_Material = Maketbl_prod_pharmaTxSubContractOutNote_Material(dataReader);
					tbl_prod_pharmaTxSubContractOutNote_MaterialList.Add(tbl_prod_pharmaTxSubContractOutNote_Material);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNote_MaterialList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaTxSubContractOutNote_Material class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaTxSubContractOutNote_Material Maketbl_prod_pharmaTxSubContractOutNote_Material(SqlDataReader dataReader) {
			tbl_prod_pharmaTxSubContractOutNote_Material tbl_prod_pharmaTxSubContractOutNote_Material = new tbl_prod_pharmaTxSubContractOutNote_Material();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaTxSubContractOutNote_Material.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaTxSubContractOutNote_Material.SubOut_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_pharmaTxSubContractOutNote_Material.IsSemiFG_item = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_pharmaTxSubContractOutNote_Material.ProdJob_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_pharmaTxSubContractOutNote_Material.ProdBatch_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_pharmaTxSubContractOutNote_Material.SemiFG_item_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prod_pharmaTxSubContractOutNote_Material.Item_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prod_pharmaTxSubContractOutNote_Material.Uom_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prod_pharmaTxSubContractOutNote_Material.Available_Qty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prod_pharmaTxSubContractOutNote_Material.Bom_Qty = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prod_pharmaTxSubContractOutNote_Material.Bom_Issued_Qty = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_prod_pharmaTxSubContractOutNote_Material.Bom_Balance_Qty = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_prod_pharmaTxSubContractOutNote_Material.Son_Qty = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_prod_pharmaTxSubContractOutNote_Material.Son_Weight = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_prod_pharmaTxSubContractOutNote_Material.UnitPrice = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_prod_pharmaTxSubContractOutNote_Material.WeightPrice = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_prod_pharmaTxSubContractOutNote_Material.TotalAmount = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_prod_pharmaTxSubContractOutNote_Material.Remarks = dataReader.GetString(17);
			}

			return tbl_prod_pharmaTxSubContractOutNote_Material;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaTxSubContractOutNote_Material datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxSubContractOutNote_Material object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaTxSubContractOutNote_Material  tbl_prod_pharmaTxSubContractOutNote_Material   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_subOut_ID = new DataColumn("subOut_ID" , typeof(string));
			DataColumn col_isSemiFG_item = new DataColumn("isSemiFG_item" , typeof(bool));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_prodBatch_ID = new DataColumn("prodBatch_ID" , typeof(string));
			DataColumn col_semiFG_item_ID = new DataColumn("semiFG_item_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_available_Qty = new DataColumn("available_Qty" , typeof(decimal));
			DataColumn col_bom_Qty = new DataColumn("bom_Qty" , typeof(decimal));
			DataColumn col_bom_Issued_Qty = new DataColumn("bom_Issued_Qty" , typeof(decimal));
			DataColumn col_bom_Balance_Qty = new DataColumn("bom_Balance_Qty" , typeof(decimal));
			DataColumn col_son_Qty = new DataColumn("son_Qty" , typeof(decimal));
			DataColumn col_son_Weight = new DataColumn("son_Weight" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_subOut_ID,col_isSemiFG_item,col_prodJob_ID,col_prodBatch_ID,col_semiFG_item_ID,col_item_ID,col_uom_ID,col_available_Qty,col_bom_Qty,col_bom_Issued_Qty,col_bom_Balance_Qty,col_son_Qty,col_son_Weight,col_unitPrice,col_weightPrice,col_totalAmount,col_remarks,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaTxSubContractOutNote_Material datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxSubContractOutNote_Material object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaTxSubContractOutNote_Material user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["subOut_ID"] = user.subOut_ID;
			drow["isSemiFG_item"] = user.isSemiFG_item;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["prodBatch_ID"] = user.prodBatch_ID;
			drow["semiFG_item_ID"] = user.semiFG_item_ID;
			drow["item_ID"] = user.item_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["available_Qty"] = user.available_Qty;
			drow["bom_Qty"] = user.bom_Qty;
			drow["bom_Issued_Qty"] = user.bom_Issued_Qty;
			drow["bom_Balance_Qty"] = user.bom_Balance_Qty;
			drow["son_Qty"] = user.son_Qty;
			drow["son_Weight"] = user.son_Weight;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["totalAmount"] = user.totalAmount;
			drow["remarks"] = user.remarks;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
