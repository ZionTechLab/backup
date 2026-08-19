using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_pharmaTxSubContractOutNote_JobCard {
		#region Fields
		private int line_No;
		private string subOut_ID;
		private string prodJob_ID;
		private string prodBatch_ID;
		private string item_ID_FG;
		private string customerOrder_ID;
		private string uom_ID;
		private decimal subOut_FGQty;
		private decimal bomUnitPriceNonTax;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxSubContractOutNote_JobCard class.
		/// </summary>
		public tbl_prod_pharmaTxSubContractOutNote_JobCard() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_pharmaTxSubContractOutNote_JobCard class.
		/// </summary>
		public tbl_prod_pharmaTxSubContractOutNote_JobCard(int line_No, string subOut_ID, string prodJob_ID, string prodBatch_ID, string item_ID_FG, string customerOrder_ID, string uom_ID, decimal subOut_FGQty, decimal bomUnitPriceNonTax) {
			this.line_No = line_No;
			this.subOut_ID = subOut_ID;
			this.prodJob_ID = prodJob_ID;
			this.prodBatch_ID = prodBatch_ID;
			this.item_ID_FG = item_ID_FG;
			this.customerOrder_ID = customerOrder_ID;
			this.uom_ID = uom_ID;
			this.subOut_FGQty = subOut_FGQty;
			this.bomUnitPriceNonTax = bomUnitPriceNonTax;
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
		/// Gets or sets the Item_ID_FG value.
		/// </summary>
		public string Item_ID_FG {
			get { return item_ID_FG; }
			set { item_ID_FG = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerOrder_ID value.
		/// </summary>
		public string CustomerOrder_ID {
			get { return customerOrder_ID; }
			set { customerOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SubOut_FGQty value.
		/// </summary>
		public decimal SubOut_FGQty {
			get { return subOut_FGQty; }
			set { subOut_FGQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the BomUnitPriceNonTax value.
		/// </summary>
		public decimal BomUnitPriceNonTax {
			get { return bomUnitPriceNonTax; }
			set { bomUnitPriceNonTax = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prod_pharmaTxSubContractOutNote_JobCard table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_JobCardInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@subOut_FGQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bomUnitPriceNonTax", SqlDbType.Decimal,9);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@subOut_ID"].Value = subOut_ID;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@subOut_FGQty"].Value = subOut_FGQty;
			scom.Parameters["@bomUnitPriceNonTax"].Value = bomUnitPriceNonTax;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_pharmaTxSubContractOutNote_JobCard table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_JobCardUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@subOut_FGQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bomUnitPriceNonTax", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@subOut_ID"].Value = subOut_ID;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@subOut_FGQty"].Value = subOut_FGQty;
			scom.Parameters["@bomUnitPriceNonTax"].Value = bomUnitPriceNonTax;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_pharmaTxSubContractOutNote_JobCard table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_JobCardDelete", scon);
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
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_JobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_JobCardDeleteAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
 
			//scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_JobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_JobCardDeleteAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_JobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllBySubOut_ID(string subOut_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_JobCardDeleteAllBySubOut_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters["@subOut_ID"].Value = subOut_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_JobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID_FG(string item_ID_FG) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_JobCardDeleteAllByItem_ID_FG", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_JobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_JobCardDeleteAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_JobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_JobCardDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_pharmaTxSubContractOutNote_JobCard table.
		/// </summary>
		public static tbl_prod_pharmaTxSubContractOutNote_JobCard Select(int line_No_Incoming, string subOut_ID_Incoming){

			tbl_prod_pharmaTxSubContractOutNote_JobCard tbl_prod_pharmaTxSubContractOutNote_JobCardins = new tbl_prod_pharmaTxSubContractOutNote_JobCard();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_JobCardSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@subOut_ID"].Value = subOut_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote_JobCardins = Maketbl_prod_pharmaTxSubContractOutNote_JobCard(dataReader);
				} else {
					tbl_prod_pharmaTxSubContractOutNote_JobCardins = null;
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNote_JobCardins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_JobCard table.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote_JobCard> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_JobCardSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_pharmaTxSubContractOutNote_JobCard> tbl_prod_pharmaTxSubContractOutNote_JobCardList = new List<tbl_prod_pharmaTxSubContractOutNote_JobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote_JobCard tbl_prod_pharmaTxSubContractOutNote_JobCard = Maketbl_prod_pharmaTxSubContractOutNote_JobCard(dataReader);
					tbl_prod_pharmaTxSubContractOutNote_JobCardList.Add(tbl_prod_pharmaTxSubContractOutNote_JobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNote_JobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_JobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote_JobCard> SelectAllByUom_ID(string uom_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_JobCardSelectAllByUom_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters["@uom_ID"].Value = uom_ID;
				List<tbl_prod_pharmaTxSubContractOutNote_JobCard> tbl_prod_pharmaTxSubContractOutNote_JobCardList = new List<tbl_prod_pharmaTxSubContractOutNote_JobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote_JobCard tbl_prod_pharmaTxSubContractOutNote_JobCard = Maketbl_prod_pharmaTxSubContractOutNote_JobCard(dataReader);
					tbl_prod_pharmaTxSubContractOutNote_JobCardList.Add(tbl_prod_pharmaTxSubContractOutNote_JobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNote_JobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_JobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote_JobCard> SelectAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_JobCardSelectAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
				List<tbl_prod_pharmaTxSubContractOutNote_JobCard> tbl_prod_pharmaTxSubContractOutNote_JobCardList = new List<tbl_prod_pharmaTxSubContractOutNote_JobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote_JobCard tbl_prod_pharmaTxSubContractOutNote_JobCard = Maketbl_prod_pharmaTxSubContractOutNote_JobCard(dataReader);
					tbl_prod_pharmaTxSubContractOutNote_JobCardList.Add(tbl_prod_pharmaTxSubContractOutNote_JobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNote_JobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_JobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote_JobCard> SelectAllBySubOut_ID(string subOut_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_JobCardSelectAllBySubOut_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@subOut_ID", SqlDbType.VarChar,20);
			scom.Parameters["@subOut_ID"].Value = subOut_ID;
				List<tbl_prod_pharmaTxSubContractOutNote_JobCard> tbl_prod_pharmaTxSubContractOutNote_JobCardList = new List<tbl_prod_pharmaTxSubContractOutNote_JobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote_JobCard tbl_prod_pharmaTxSubContractOutNote_JobCard = Maketbl_prod_pharmaTxSubContractOutNote_JobCard(dataReader);
					tbl_prod_pharmaTxSubContractOutNote_JobCardList.Add(tbl_prod_pharmaTxSubContractOutNote_JobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNote_JobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_JobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote_JobCard> SelectAllByItem_ID_FG(string item_ID_FG) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_JobCardSelectAllByItem_ID_FG", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID_FG", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID_FG"].Value = item_ID_FG;
				List<tbl_prod_pharmaTxSubContractOutNote_JobCard> tbl_prod_pharmaTxSubContractOutNote_JobCardList = new List<tbl_prod_pharmaTxSubContractOutNote_JobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote_JobCard tbl_prod_pharmaTxSubContractOutNote_JobCard = Maketbl_prod_pharmaTxSubContractOutNote_JobCard(dataReader);
					tbl_prod_pharmaTxSubContractOutNote_JobCardList.Add(tbl_prod_pharmaTxSubContractOutNote_JobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNote_JobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_JobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote_JobCard> SelectAllByProdBatch_ID(string prodBatch_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_JobCardSelectAllByProdBatch_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
				List<tbl_prod_pharmaTxSubContractOutNote_JobCard> tbl_prod_pharmaTxSubContractOutNote_JobCardList = new List<tbl_prod_pharmaTxSubContractOutNote_JobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote_JobCard tbl_prod_pharmaTxSubContractOutNote_JobCard = Maketbl_prod_pharmaTxSubContractOutNote_JobCard(dataReader);
					tbl_prod_pharmaTxSubContractOutNote_JobCardList.Add(tbl_prod_pharmaTxSubContractOutNote_JobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNote_JobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_pharmaTxSubContractOutNote_JobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_pharmaTxSubContractOutNote_JobCard> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_pharmaTxSubContractOutNote_JobCardSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prod_pharmaTxSubContractOutNote_JobCard> tbl_prod_pharmaTxSubContractOutNote_JobCardList = new List<tbl_prod_pharmaTxSubContractOutNote_JobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_pharmaTxSubContractOutNote_JobCard tbl_prod_pharmaTxSubContractOutNote_JobCard = Maketbl_prod_pharmaTxSubContractOutNote_JobCard(dataReader);
					tbl_prod_pharmaTxSubContractOutNote_JobCardList.Add(tbl_prod_pharmaTxSubContractOutNote_JobCard);
				}
			}
			scon.Close();
			return tbl_prod_pharmaTxSubContractOutNote_JobCardList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_pharmaTxSubContractOutNote_JobCard class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_pharmaTxSubContractOutNote_JobCard Maketbl_prod_pharmaTxSubContractOutNote_JobCard(SqlDataReader dataReader) {
			tbl_prod_pharmaTxSubContractOutNote_JobCard tbl_prod_pharmaTxSubContractOutNote_JobCard = new tbl_prod_pharmaTxSubContractOutNote_JobCard();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_pharmaTxSubContractOutNote_JobCard.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_pharmaTxSubContractOutNote_JobCard.SubOut_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_pharmaTxSubContractOutNote_JobCard.ProdJob_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_pharmaTxSubContractOutNote_JobCard.ProdBatch_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_pharmaTxSubContractOutNote_JobCard.Item_ID_FG = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_pharmaTxSubContractOutNote_JobCard.CustomerOrder_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prod_pharmaTxSubContractOutNote_JobCard.Uom_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prod_pharmaTxSubContractOutNote_JobCard.SubOut_FGQty = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prod_pharmaTxSubContractOutNote_JobCard.BomUnitPriceNonTax = dataReader.GetDecimal(8);
			}

			return tbl_prod_pharmaTxSubContractOutNote_JobCard;
		}
		/// <summary>
		/// This makes tbl_prod_pharmaTxSubContractOutNote_JobCard datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxSubContractOutNote_JobCard object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_pharmaTxSubContractOutNote_JobCard  tbl_prod_pharmaTxSubContractOutNote_JobCard   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_subOut_ID = new DataColumn("subOut_ID" , typeof(string));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_prodBatch_ID = new DataColumn("prodBatch_ID" , typeof(string));
			DataColumn col_item_ID_FG = new DataColumn("item_ID_FG" , typeof(string));
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_subOut_FGQty = new DataColumn("subOut_FGQty" , typeof(decimal));
			DataColumn col_bomUnitPriceNonTax = new DataColumn("bomUnitPriceNonTax" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_subOut_ID,col_prodJob_ID,col_prodBatch_ID,col_item_ID_FG,col_customerOrder_ID,col_uom_ID,col_subOut_FGQty,col_bomUnitPriceNonTax,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_pharmaTxSubContractOutNote_JobCard datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_pharmaTxSubContractOutNote_JobCard object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_pharmaTxSubContractOutNote_JobCard user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["subOut_ID"] = user.subOut_ID;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["prodBatch_ID"] = user.prodBatch_ID;
			drow["item_ID_FG"] = user.item_ID_FG;
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["subOut_FGQty"] = user.subOut_FGQty;
			drow["bomUnitPriceNonTax"] = user.bomUnitPriceNonTax;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
