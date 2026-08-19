using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prodTxMaterialRequision_JobCard {
		#region Fields
		private string mr_No;
		private string prodJob_ID;
		private string prodBatch_ID;
		private string customerOrder_ID;
		private decimal mr_FGQty;
		private string uom_ID;
		private decimal bomUnitPriceNonTax;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxMaterialRequision_JobCard class.
		/// </summary>
		public tbl_prodTxMaterialRequision_JobCard() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prodTxMaterialRequision_JobCard class.
		/// </summary>
		public tbl_prodTxMaterialRequision_JobCard(string mr_No, string prodJob_ID, string prodBatch_ID, string customerOrder_ID, decimal mr_FGQty, string uom_ID, decimal bomUnitPriceNonTax) {
			this.mr_No = mr_No;
			this.prodJob_ID = prodJob_ID;
			this.prodBatch_ID = prodBatch_ID;
			this.customerOrder_ID = customerOrder_ID;
			this.mr_FGQty = mr_FGQty;
			this.uom_ID = uom_ID;
			this.bomUnitPriceNonTax = bomUnitPriceNonTax;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Mr_No value.
		/// </summary>
		public string Mr_No {
			get { return mr_No; }
			set { mr_No = value; }
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
		/// Gets or sets the CustomerOrder_ID value.
		/// </summary>
		public string CustomerOrder_ID {
			get { return customerOrder_ID; }
			set { customerOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Mr_FGQty value.
		/// </summary>
		public decimal Mr_FGQty {
			get { return mr_FGQty; }
			set { mr_FGQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
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
		/// Saves a record to the tbl_prodTxMaterialRequision_JobCard table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_JobCardInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mr_FGQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bomUnitPriceNonTax", SqlDbType.Decimal,9);
 
			scom.Parameters["@mr_No"].Value = mr_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@mr_FGQty"].Value = mr_FGQty;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@bomUnitPriceNonTax"].Value = bomUnitPriceNonTax;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prodTxMaterialRequision_JobCard table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_JobCardUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@mr_FGQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@bomUnitPriceNonTax", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@mr_No"].Value = mr_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@mr_FGQty"].Value = mr_FGQty;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@bomUnitPriceNonTax"].Value = bomUnitPriceNonTax;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prodTxMaterialRequision_JobCard table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_JobCardDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mr_No"].Value = mr_No;
 
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_JobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_JobCardDeleteAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_JobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByMr_No(string mr_No) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_JobCardDeleteAllByMr_No", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters["@mr_No"].Value = mr_No;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_JobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_JobCardDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prodTxMaterialRequision_JobCard table.
		/// </summary>
		public static tbl_prodTxMaterialRequision_JobCard Select(string mr_No_Incoming, string prodJob_ID_Incoming, string prodBatch_ID_Incoming){

			tbl_prodTxMaterialRequision_JobCard tbl_prodTxMaterialRequision_JobCardins = new tbl_prodTxMaterialRequision_JobCard();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_JobCardSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodBatch_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mr_No"].Value = mr_No_Incoming;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID_Incoming;
			scom.Parameters["@prodBatch_ID"].Value = prodBatch_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prodTxMaterialRequision_JobCardins = Maketbl_prodTxMaterialRequision_JobCard(dataReader);
				} else {
					tbl_prodTxMaterialRequision_JobCardins = null;
				}
			}
			scon.Close();
			return tbl_prodTxMaterialRequision_JobCardins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_JobCard table.
		/// </summary>
		public static List<tbl_prodTxMaterialRequision_JobCard> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_JobCardSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prodTxMaterialRequision_JobCard> tbl_prodTxMaterialRequision_JobCardList = new List<tbl_prodTxMaterialRequision_JobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxMaterialRequision_JobCard tbl_prodTxMaterialRequision_JobCard = Maketbl_prodTxMaterialRequision_JobCard(dataReader);
					tbl_prodTxMaterialRequision_JobCardList.Add(tbl_prodTxMaterialRequision_JobCard);
				}
			}
			scon.Close();
			return tbl_prodTxMaterialRequision_JobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_JobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxMaterialRequision_JobCard> SelectAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_JobCardSelectAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
				List<tbl_prodTxMaterialRequision_JobCard> tbl_prodTxMaterialRequision_JobCardList = new List<tbl_prodTxMaterialRequision_JobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxMaterialRequision_JobCard tbl_prodTxMaterialRequision_JobCard = Maketbl_prodTxMaterialRequision_JobCard(dataReader);
					tbl_prodTxMaterialRequision_JobCardList.Add(tbl_prodTxMaterialRequision_JobCard);
				}
			}
			scon.Close();
			return tbl_prodTxMaterialRequision_JobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_JobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxMaterialRequision_JobCard> SelectAllByMr_No(string mr_No) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_JobCardSelectAllByMr_No", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters["@mr_No"].Value = mr_No;
				List<tbl_prodTxMaterialRequision_JobCard> tbl_prodTxMaterialRequision_JobCardList = new List<tbl_prodTxMaterialRequision_JobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxMaterialRequision_JobCard tbl_prodTxMaterialRequision_JobCard = Maketbl_prodTxMaterialRequision_JobCard(dataReader);
					tbl_prodTxMaterialRequision_JobCardList.Add(tbl_prodTxMaterialRequision_JobCard);
				}
			}
			scon.Close();
			return tbl_prodTxMaterialRequision_JobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prodTxMaterialRequision_JobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prodTxMaterialRequision_JobCard> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prodTxMaterialRequision_JobCardSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prodTxMaterialRequision_JobCard> tbl_prodTxMaterialRequision_JobCardList = new List<tbl_prodTxMaterialRequision_JobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prodTxMaterialRequision_JobCard tbl_prodTxMaterialRequision_JobCard = Maketbl_prodTxMaterialRequision_JobCard(dataReader);
					tbl_prodTxMaterialRequision_JobCardList.Add(tbl_prodTxMaterialRequision_JobCard);
				}
			}
			scon.Close();
			return tbl_prodTxMaterialRequision_JobCardList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prodTxMaterialRequision_JobCard class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prodTxMaterialRequision_JobCard Maketbl_prodTxMaterialRequision_JobCard(SqlDataReader dataReader) {
			tbl_prodTxMaterialRequision_JobCard tbl_prodTxMaterialRequision_JobCard = new tbl_prodTxMaterialRequision_JobCard();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prodTxMaterialRequision_JobCard.Mr_No = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prodTxMaterialRequision_JobCard.ProdJob_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prodTxMaterialRequision_JobCard.ProdBatch_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prodTxMaterialRequision_JobCard.CustomerOrder_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prodTxMaterialRequision_JobCard.Mr_FGQty = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prodTxMaterialRequision_JobCard.Uom_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prodTxMaterialRequision_JobCard.BomUnitPriceNonTax = dataReader.GetDecimal(6);
			}

			return tbl_prodTxMaterialRequision_JobCard;
		}
		/// <summary>
		/// This makes tbl_prodTxMaterialRequision_JobCard datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prodTxMaterialRequision_JobCard object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prodTxMaterialRequision_JobCard  tbl_prodTxMaterialRequision_JobCard   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_mr_No = new DataColumn("mr_No" , typeof(string));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_prodBatch_ID = new DataColumn("prodBatch_ID" , typeof(string));
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_mr_FGQty = new DataColumn("mr_FGQty" , typeof(decimal));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_bomUnitPriceNonTax = new DataColumn("bomUnitPriceNonTax" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_mr_No,col_prodJob_ID,col_prodBatch_ID,col_customerOrder_ID,col_mr_FGQty,col_uom_ID,col_bomUnitPriceNonTax,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prodTxMaterialRequision_JobCard datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prodTxMaterialRequision_JobCard object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prodTxMaterialRequision_JobCard user) {
		DataRow drow = dt.NewRow();
		
			drow["mr_No"] = user.mr_No;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["prodBatch_ID"] = user.prodBatch_ID;
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["mr_FGQty"] = user.mr_FGQty;
			drow["uom_ID"] = user.uom_ID;
			drow["bomUnitPriceNonTax"] = user.bomUnitPriceNonTax;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
