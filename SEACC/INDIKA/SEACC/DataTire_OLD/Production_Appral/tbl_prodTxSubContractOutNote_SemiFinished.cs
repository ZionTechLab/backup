using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxSubContractOutNote_SemiFinished {
		#region Fields
		private int line_No;
		private string subOut_ID;
		private string prodJob_ID;
		private string prodBatch_ID;
		private string semiFinishedItem_ID;
		private string uom_ID;
		private decimal subOut_SFGQty;
		private decimal unitPrice;
		private decimal supplierRate;
		private decimal totalAmount;
		private decimal supplierTotalAmount;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxSubContractOutNote_SemiFinished class.
		/// </summary>
		public tbl_prodTxSubContractOutNote_SemiFinished() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxSubContractOutNote_SemiFinished class.
		/// </summary>
		public tbl_prodTxSubContractOutNote_SemiFinished(int line_No, string subOut_ID, string prodJob_ID, string prodBatch_ID, string semiFinishedItem_ID, string uom_ID, decimal subOut_SFGQty, decimal unitPrice, decimal supplierRate, decimal totalAmount, decimal supplierTotalAmount) {
			this.line_No = line_No;
			this.subOut_ID = subOut_ID;
			this.prodJob_ID = prodJob_ID;
			this.prodBatch_ID = prodBatch_ID;
			this.semiFinishedItem_ID = semiFinishedItem_ID;
			this.uom_ID = uom_ID;
			this.subOut_SFGQty = subOut_SFGQty;
			this.unitPrice = unitPrice;
			this.supplierRate = supplierRate;
			this.totalAmount = totalAmount;
			this.supplierTotalAmount = supplierTotalAmount;
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
		/// Gets or sets the SemiFinishedItem_ID value.
		/// </summary>
		public string SemiFinishedItem_ID {
			get { return semiFinishedItem_ID; }
			set { semiFinishedItem_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SubOut_SFGQty value.
		/// </summary>
		public decimal SubOut_SFGQty {
			get { return subOut_SFGQty; }
			set { subOut_SFGQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitPrice value.
		/// </summary>
		public decimal UnitPrice {
			get { return unitPrice; }
			set { unitPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the SupplierRate value.
		/// </summary>
		public decimal SupplierRate {
			get { return supplierRate; }
			set { supplierRate = value; }
		}
		
		/// <summary>
		/// Gets or sets the TotalAmount value.
		/// </summary>
		public decimal TotalAmount {
			get { return totalAmount; }
			set { totalAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the SupplierTotalAmount value.
		/// </summary>
		public decimal SupplierTotalAmount {
			get { return supplierTotalAmount; }
			set { supplierTotalAmount = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prodTxSubContractOutNote_SemiFinished table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractOutNote_SemiFinishedInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@semiFinishedItem_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@subOut_SFGQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@supplierRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@supplierTotalAmount", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@subOut_ID"].Value = subOut_ID;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@semiFinishedItem_ID"].Value = semiFinishedItem_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@subOut_SFGQty"].Value = subOut_SFGQty;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@supplierRate"].Value = supplierRate;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@supplierTotalAmount"].Value = supplierTotalAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxSubContractOutNote_SemiFinished table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractOutNote_SemiFinishedUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@semiFinishedItem_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@subOut_SFGQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@supplierRate", SqlDbType.Decimal,9);
			scom.Parameters.Add("@totalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@supplierTotalAmount", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@subOut_ID"].Value = subOut_ID;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@semiFinishedItem_ID"].Value = semiFinishedItem_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@subOut_SFGQty"].Value = subOut_SFGQty;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@supplierRate"].Value = supplierRate;
			scom.Parameters["@totalAmount"].Value = totalAmount;
			scom.Parameters["@supplierTotalAmount"].Value = supplierTotalAmount;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxSubContractOutNote_SemiFinished table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractOutNote_SemiFinishedDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@subOut_ID"].Value = subOut_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractOutNote_SemiFinished table by a foreign key.
		/// </summary>
		public static void DeleteAllBySemiFinishedItem_ID(string semiFinishedItem_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractOutNote_SemiFinishedDeleteAllBySemiFinishedItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@semiFinishedItem_ID", SqlDbType.VarChar,20);
			scom.Parameters["@semiFinishedItem_ID"].Value = semiFinishedItem_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractOutNote_SemiFinished table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractOutNote_SemiFinishedDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractOutNote_SemiFinished table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractOutNote_SemiFinishedDeleteAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractOutNote_SemiFinished table by a foreign key.
		/// </summary>
		public static void DeleteAllBySubOut_ID(string subOut_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractOutNote_SemiFinishedDeleteAllBySubOut_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters["@subOut_ID"].Value = subOut_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractOutNote_SemiFinished table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractOutNote_SemiFinishedDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxSubContractOutNote_SemiFinished table.
		/// </summary>
		public static tbl_prodTxSubContractOutNote_SemiFinished Select(int line_No_Incoming, string subOut_ID_Incoming){

			tbl_prodTxSubContractOutNote_SemiFinished tbl_prodTxSubContractOutNote_SemiFinishedins = new tbl_prodTxSubContractOutNote_SemiFinished();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractOutNote_SemiFinishedSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@subOut_ID"].Value = subOut_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxSubContractOutNote_SemiFinishedins = Maketbl_prodTxSubContractOutNote_SemiFinished(dataReader);
				} else {
					tbl_prodTxSubContractOutNote_SemiFinishedins = null;
				}
			}
			scon.Close();
			return tbl_prodTxSubContractOutNote_SemiFinishedins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractOutNote_SemiFinished table.
		/// </summary>
		public static List<tbl_prodTxSubContractOutNote_SemiFinished> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractOutNote_SemiFinishedSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxSubContractOutNote_SemiFinished> tbl_prodTxSubContractOutNote_SemiFinishedList = new List<tbl_prodTxSubContractOutNote_SemiFinished>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractOutNote_SemiFinished tbl_prodTxSubContractOutNote_SemiFinished = Maketbl_prodTxSubContractOutNote_SemiFinished(dataReader);
					tbl_prodTxSubContractOutNote_SemiFinishedList.Add(tbl_prodTxSubContractOutNote_SemiFinished);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractOutNote_SemiFinishedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractOutNote_SemiFinished table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractOutNote_SemiFinished> SelectAllBySemiFinishedItem_ID(string semiFinishedItem_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractOutNote_SemiFinishedSelectAllBySemiFinishedItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@semiFinishedItem_ID", SqlDbType.VarChar,20);
			scom.Parameters["@semiFinishedItem_ID"].Value = semiFinishedItem_ID;
				List<tbl_prodTxSubContractOutNote_SemiFinished> tbl_prodTxSubContractOutNote_SemiFinishedList = new List<tbl_prodTxSubContractOutNote_SemiFinished>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractOutNote_SemiFinished tbl_prodTxSubContractOutNote_SemiFinished = Maketbl_prodTxSubContractOutNote_SemiFinished(dataReader);
					tbl_prodTxSubContractOutNote_SemiFinishedList.Add(tbl_prodTxSubContractOutNote_SemiFinished);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractOutNote_SemiFinishedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractOutNote_SemiFinished table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractOutNote_SemiFinished> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractOutNote_SemiFinishedSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prodTxSubContractOutNote_SemiFinished> tbl_prodTxSubContractOutNote_SemiFinishedList = new List<tbl_prodTxSubContractOutNote_SemiFinished>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractOutNote_SemiFinished tbl_prodTxSubContractOutNote_SemiFinished = Maketbl_prodTxSubContractOutNote_SemiFinished(dataReader);
					tbl_prodTxSubContractOutNote_SemiFinishedList.Add(tbl_prodTxSubContractOutNote_SemiFinished);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractOutNote_SemiFinishedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractOutNote_SemiFinished table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractOutNote_SemiFinished> SelectAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractOutNote_SemiFinishedSelectAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
				List<tbl_prodTxSubContractOutNote_SemiFinished> tbl_prodTxSubContractOutNote_SemiFinishedList = new List<tbl_prodTxSubContractOutNote_SemiFinished>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractOutNote_SemiFinished tbl_prodTxSubContractOutNote_SemiFinished = Maketbl_prodTxSubContractOutNote_SemiFinished(dataReader);
					tbl_prodTxSubContractOutNote_SemiFinishedList.Add(tbl_prodTxSubContractOutNote_SemiFinished);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractOutNote_SemiFinishedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractOutNote_SemiFinished table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractOutNote_SemiFinished> SelectAllBySubOut_ID(string subOut_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractOutNote_SemiFinishedSelectAllBySubOut_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters["@subOut_ID"].Value = subOut_ID;
				List<tbl_prodTxSubContractOutNote_SemiFinished> tbl_prodTxSubContractOutNote_SemiFinishedList = new List<tbl_prodTxSubContractOutNote_SemiFinished>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractOutNote_SemiFinished tbl_prodTxSubContractOutNote_SemiFinished = Maketbl_prodTxSubContractOutNote_SemiFinished(dataReader);
					tbl_prodTxSubContractOutNote_SemiFinishedList.Add(tbl_prodTxSubContractOutNote_SemiFinished);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractOutNote_SemiFinishedList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxSubContractOutNote_SemiFinished table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxSubContractOutNote_SemiFinished> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxSubContractOutNote_SemiFinishedSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prodTxSubContractOutNote_SemiFinished> tbl_prodTxSubContractOutNote_SemiFinishedList = new List<tbl_prodTxSubContractOutNote_SemiFinished>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxSubContractOutNote_SemiFinished tbl_prodTxSubContractOutNote_SemiFinished = Maketbl_prodTxSubContractOutNote_SemiFinished(dataReader);
					tbl_prodTxSubContractOutNote_SemiFinishedList.Add(tbl_prodTxSubContractOutNote_SemiFinished);
				}
			}
			scon.Close();
			return tbl_prodTxSubContractOutNote_SemiFinishedList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxSubContractOutNote_SemiFinished class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxSubContractOutNote_SemiFinished Maketbl_prodTxSubContractOutNote_SemiFinished(SqlDataReader dataReader) {
			tbl_prodTxSubContractOutNote_SemiFinished tbl_prodTxSubContractOutNote_SemiFinished = new tbl_prodTxSubContractOutNote_SemiFinished();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxSubContractOutNote_SemiFinished.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxSubContractOutNote_SemiFinished.SubOut_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxSubContractOutNote_SemiFinished.ProdJob_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxSubContractOutNote_SemiFinished.ProdBatch_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxSubContractOutNote_SemiFinished.SemiFinishedItem_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxSubContractOutNote_SemiFinished.Uom_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxSubContractOutNote_SemiFinished.SubOut_SFGQty = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prodTxSubContractOutNote_SemiFinished.UnitPrice = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prodTxSubContractOutNote_SemiFinished.SupplierRate = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prodTxSubContractOutNote_SemiFinished.TotalAmount = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prodTxSubContractOutNote_SemiFinished.SupplierTotalAmount = dataReader.GetDecimal(10);
			}

			return tbl_prodTxSubContractOutNote_SemiFinished;
		}
		/// <summary>
		/// This makes tbl_prodTxSubContractOutNote_SemiFinished datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxSubContractOutNote_SemiFinished object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxSubContractOutNote_SemiFinished  tbl_prodTxSubContractOutNote_SemiFinished   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_subOut_ID = new DataColumn("subOut_ID" , typeof(string));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_prodBatch_ID = new DataColumn("prodBatch_ID" , typeof(string));
			DataColumn col_semiFinishedItem_ID = new DataColumn("semiFinishedItem_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_subOut_SFGQty = new DataColumn("subOut_SFGQty" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_supplierRate = new DataColumn("supplierRate" , typeof(decimal));
			DataColumn col_totalAmount = new DataColumn("totalAmount" , typeof(decimal));
			DataColumn col_supplierTotalAmount = new DataColumn("supplierTotalAmount" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_subOut_ID,col_prodJob_ID,col_prodBatch_ID,col_semiFinishedItem_ID,col_uom_ID,col_subOut_SFGQty,col_unitPrice,col_supplierRate,col_totalAmount,col_supplierTotalAmount,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxSubContractOutNote_SemiFinished datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxSubContractOutNote_SemiFinished object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxSubContractOutNote_SemiFinished user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["subOut_ID"] = user.subOut_ID;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["prodBatch_ID"] = user.prodBatch_ID;
			drow["semiFinishedItem_ID"] = user.semiFinishedItem_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["subOut_SFGQty"] = user.subOut_SFGQty;
			drow["unitPrice"] = user.unitPrice;
			drow["supplierRate"] = user.supplierRate;
			drow["totalAmount"] = user.totalAmount;
			drow["supplierTotalAmount"] = user.supplierTotalAmount;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
