using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_polyTxMaterialRequision_JobCard {
		#region Fields
		private string mr_No;
		private string prodJob_ID;
		private string customerOrder_ID;
		private string uom_ID;
		private string uom_ID_Weight;
		private decimal finishGood_Qty;
		private decimal finishGood_Weight;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_polyTxMaterialRequision_JobCard class.
		/// </summary>
		public tbl_prod_polyTxMaterialRequision_JobCard() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_polyTxMaterialRequision_JobCard class.
		/// </summary>
		public tbl_prod_polyTxMaterialRequision_JobCard(string mr_No, string prodJob_ID, string customerOrder_ID, string uom_ID, string uom_ID_Weight, decimal finishGood_Qty, decimal finishGood_Weight) {
			this.mr_No = mr_No;
			this.prodJob_ID = prodJob_ID;
			this.customerOrder_ID = customerOrder_ID;
			this.uom_ID = uom_ID;
			this.uom_ID_Weight = uom_ID_Weight;
			this.finishGood_Qty = finishGood_Qty;
			this.finishGood_Weight = finishGood_Weight;
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
		/// Gets or sets the Uom_ID_Weight value.
		/// </summary>
		public string Uom_ID_Weight {
			get { return uom_ID_Weight; }
			set { uom_ID_Weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the FinishGood_Qty value.
		/// </summary>
		public decimal FinishGood_Qty {
			get { return finishGood_Qty; }
			set { finishGood_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the FinishGood_Weight value.
		/// </summary>
		public decimal FinishGood_Weight {
			get { return finishGood_Weight; }
			set { finishGood_Weight = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_prod_polyTxMaterialRequision_JobCard table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_JobCardInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@uom_ID_Weight", SqlDbType.VarChar,10);
			scom.Parameters.Add("@finishGood_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@finishGood_Weight", SqlDbType.Decimal,9);
 
			scom.Parameters["@mr_No"].Value = mr_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@uom_ID_Weight"].Value = uom_ID_Weight;
			scom.Parameters["@finishGood_Qty"].Value = finishGood_Qty;
			scom.Parameters["@finishGood_Weight"].Value = finishGood_Weight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_polyTxMaterialRequision_JobCard table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_JobCardUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@uom_ID_Weight", SqlDbType.VarChar,10);
			scom.Parameters.Add("@finishGood_Qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@finishGood_Weight", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@mr_No"].Value = mr_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@uom_ID_Weight"].Value = uom_ID_Weight;
			scom.Parameters["@finishGood_Qty"].Value = finishGood_Qty;
			scom.Parameters["@finishGood_Weight"].Value = finishGood_Weight;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_polyTxMaterialRequision_JobCard table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_JobCardDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mr_No"].Value = mr_No;
 
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision_JobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_JobCardDeleteAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision_JobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByMr_No(string mr_No) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_JobCardDeleteAllByMr_No", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters["@mr_No"].Value = mr_No;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision_JobCard table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_JobCardDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			//scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_polyTxMaterialRequision_JobCard table.
		/// </summary>
		public static tbl_prod_polyTxMaterialRequision_JobCard Select(string mr_No_Incoming, string prodJob_ID_Incoming){

			tbl_prod_polyTxMaterialRequision_JobCard tbl_prod_polyTxMaterialRequision_JobCardins = new tbl_prod_polyTxMaterialRequision_JobCard();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_JobCardSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@mr_No"].Value = mr_No_Incoming;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision_JobCardins = Maketbl_prod_polyTxMaterialRequision_JobCard(dataReader);
				} else {
					tbl_prod_polyTxMaterialRequision_JobCardins = null;
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequision_JobCardins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision_JobCard table.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision_JobCard> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_JobCardSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_polyTxMaterialRequision_JobCard> tbl_prod_polyTxMaterialRequision_JobCardList = new List<tbl_prod_polyTxMaterialRequision_JobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision_JobCard tbl_prod_polyTxMaterialRequision_JobCard = Maketbl_prod_polyTxMaterialRequision_JobCard(dataReader);
					tbl_prod_polyTxMaterialRequision_JobCardList.Add(tbl_prod_polyTxMaterialRequision_JobCard);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequision_JobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision_JobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision_JobCard> SelectAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_JobCardSelectAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
				List<tbl_prod_polyTxMaterialRequision_JobCard> tbl_prod_polyTxMaterialRequision_JobCardList = new List<tbl_prod_polyTxMaterialRequision_JobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision_JobCard tbl_prod_polyTxMaterialRequision_JobCard = Maketbl_prod_polyTxMaterialRequision_JobCard(dataReader);
					tbl_prod_polyTxMaterialRequision_JobCardList.Add(tbl_prod_polyTxMaterialRequision_JobCard);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequision_JobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision_JobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision_JobCard> SelectAllByMr_No(string mr_No) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_JobCardSelectAllByMr_No", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@mr_No", SqlDbType.VarChar,20);
			scom.Parameters["@mr_No"].Value = mr_No;
				List<tbl_prod_polyTxMaterialRequision_JobCard> tbl_prod_polyTxMaterialRequision_JobCardList = new List<tbl_prod_polyTxMaterialRequision_JobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision_JobCard tbl_prod_polyTxMaterialRequision_JobCard = Maketbl_prod_polyTxMaterialRequision_JobCard(dataReader);
					tbl_prod_polyTxMaterialRequision_JobCardList.Add(tbl_prod_polyTxMaterialRequision_JobCard);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequision_JobCardList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxMaterialRequision_JobCard table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxMaterialRequision_JobCard> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxMaterialRequision_JobCardSelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prod_polyTxMaterialRequision_JobCard> tbl_prod_polyTxMaterialRequision_JobCardList = new List<tbl_prod_polyTxMaterialRequision_JobCard>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxMaterialRequision_JobCard tbl_prod_polyTxMaterialRequision_JobCard = Maketbl_prod_polyTxMaterialRequision_JobCard(dataReader);
					tbl_prod_polyTxMaterialRequision_JobCardList.Add(tbl_prod_polyTxMaterialRequision_JobCard);
				}
			}
			scon.Close();
			return tbl_prod_polyTxMaterialRequision_JobCardList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_polyTxMaterialRequision_JobCard class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_polyTxMaterialRequision_JobCard Maketbl_prod_polyTxMaterialRequision_JobCard(SqlDataReader dataReader) {
			tbl_prod_polyTxMaterialRequision_JobCard tbl_prod_polyTxMaterialRequision_JobCard = new tbl_prod_polyTxMaterialRequision_JobCard();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_polyTxMaterialRequision_JobCard.Mr_No = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_polyTxMaterialRequision_JobCard.ProdJob_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_polyTxMaterialRequision_JobCard.CustomerOrder_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_polyTxMaterialRequision_JobCard.Uom_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_polyTxMaterialRequision_JobCard.Uom_ID_Weight = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_polyTxMaterialRequision_JobCard.FinishGood_Qty = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prod_polyTxMaterialRequision_JobCard.FinishGood_Weight = dataReader.GetDecimal(6);
			}

			return tbl_prod_polyTxMaterialRequision_JobCard;
		}
		/// <summary>
		/// This makes tbl_prod_polyTxMaterialRequision_JobCard datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_polyTxMaterialRequision_JobCard object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_polyTxMaterialRequision_JobCard  tbl_prod_polyTxMaterialRequision_JobCard   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_mr_No = new DataColumn("mr_No" , typeof(string));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_uom_ID_Weight = new DataColumn("uom_ID_Weight" , typeof(string));
			DataColumn col_finishGood_Qty = new DataColumn("finishGood_Qty" , typeof(decimal));
			DataColumn col_finishGood_Weight = new DataColumn("finishGood_Weight" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_mr_No,col_prodJob_ID,col_customerOrder_ID,col_uom_ID,col_uom_ID_Weight,col_finishGood_Qty,col_finishGood_Weight,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_polyTxMaterialRequision_JobCard datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_polyTxMaterialRequision_JobCard object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_polyTxMaterialRequision_JobCard user) {
		DataRow drow = dt.NewRow();
		
			drow["mr_No"] = user.mr_No;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["uom_ID_Weight"] = user.uom_ID_Weight;
			drow["finishGood_Qty"] = user.finishGood_Qty;
			drow["finishGood_Weight"] = user.finishGood_Weight;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
