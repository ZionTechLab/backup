using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_prod_polyTxJobCard_Delivery {
		#region Fields
		private int line_No;
		private string prodJob_ID;
		private DateTime deliverDateTime;
		private int customerBranch_Line_No;
		private string deliverAddress;
		private decimal deliverQty;
		private decimal deliverWeight;
		private string uom_Qty;
		private string uom_Weight;
		private string deliverTerms;
		private string remarks;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_prod_polyTxJobCard_Delivery class.
		/// </summary>
		public tbl_prod_polyTxJobCard_Delivery() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_prod_polyTxJobCard_Delivery class.
		/// </summary>
		public tbl_prod_polyTxJobCard_Delivery(int line_No, string prodJob_ID, DateTime deliverDateTime, int customerBranch_Line_No, string deliverAddress, decimal deliverQty, decimal deliverWeight, string uom_Qty, string uom_Weight, string deliverTerms, string remarks) {
			this.line_No = line_No;
			this.prodJob_ID = prodJob_ID;
			this.deliverDateTime = deliverDateTime;
			this.customerBranch_Line_No = customerBranch_Line_No;
			this.deliverAddress = deliverAddress;
			this.deliverQty = deliverQty;
			this.deliverWeight = deliverWeight;
			this.uom_Qty = uom_Qty;
			this.uom_Weight = uom_Weight;
			this.deliverTerms = deliverTerms;
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
		/// Gets or sets the ProdJob_ID value.
		/// </summary>
		public string ProdJob_ID {
			get { return prodJob_ID; }
			set { prodJob_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliverDateTime value.
		/// </summary>
		public DateTime DeliverDateTime {
			get { return deliverDateTime; }
			set { deliverDateTime = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerBranch_Line_No value.
		/// </summary>
		public int CustomerBranch_Line_No {
			get { return customerBranch_Line_No; }
			set { customerBranch_Line_No = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliverAddress value.
		/// </summary>
		public string DeliverAddress {
			get { return deliverAddress; }
			set { deliverAddress = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliverQty value.
		/// </summary>
		public decimal DeliverQty {
			get { return deliverQty; }
			set { deliverQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliverWeight value.
		/// </summary>
		public decimal DeliverWeight {
			get { return deliverWeight; }
			set { deliverWeight = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_Qty value.
		/// </summary>
		public string Uom_Qty {
			get { return uom_Qty; }
			set { uom_Qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_Weight value.
		/// </summary>
		public string Uom_Weight {
			get { return uom_Weight; }
			set { uom_Weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliverTerms value.
		/// </summary>
		public string DeliverTerms {
			get { return deliverTerms; }
			set { deliverTerms = value; }
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
		/// Saves a record to the tbl_prod_polyTxJobCard_Delivery table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxJobCard_DeliveryInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliverDateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customerBranch_Line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@deliverAddress", SqlDbType.VarChar,100);
			scom.Parameters.Add("@deliverQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deliverWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_Qty", SqlDbType.VarChar,10);
			scom.Parameters.Add("@uom_Weight", SqlDbType.VarChar,10);
			scom.Parameters.Add("@deliverTerms", SqlDbType.VarChar,200);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@deliverDateTime"].Value = deliverDateTime;
			scom.Parameters["@customerBranch_Line_No"].Value = customerBranch_Line_No;
			scom.Parameters["@deliverAddress"].Value = deliverAddress;
			scom.Parameters["@deliverQty"].Value = deliverQty;
			scom.Parameters["@deliverWeight"].Value = deliverWeight;
			scom.Parameters["@uom_Qty"].Value = uom_Qty;
			scom.Parameters["@uom_Weight"].Value = uom_Weight;
			scom.Parameters["@deliverTerms"].Value = deliverTerms;
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_prod_polyTxJobCard_Delivery table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxJobCard_DeliveryUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deliverDateTime", SqlDbType.DateTime,8);
			scom.Parameters.Add("@customerBranch_Line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@deliverAddress", SqlDbType.VarChar,100);
			scom.Parameters.Add("@deliverQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deliverWeight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uom_Qty", SqlDbType.VarChar,10);
			scom.Parameters.Add("@uom_Weight", SqlDbType.VarChar,10);
			scom.Parameters.Add("@deliverTerms", SqlDbType.VarChar,200);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,200);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
			scom.Parameters["@deliverDateTime"].Value = deliverDateTime;
			scom.Parameters["@customerBranch_Line_No"].Value = customerBranch_Line_No;
			scom.Parameters["@deliverAddress"].Value = deliverAddress;
			scom.Parameters["@deliverQty"].Value = deliverQty;
			scom.Parameters["@deliverWeight"].Value = deliverWeight;
			scom.Parameters["@uom_Qty"].Value = uom_Qty;
			scom.Parameters["@uom_Weight"].Value = uom_Weight;
			scom.Parameters["@deliverTerms"].Value = deliverTerms;
			scom.Parameters["@remarks"].Value = remarks;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_prod_polyTxJobCard_Delivery table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxJobCard_DeliveryDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxJobCard_Delivery table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_Weight(string uom_Weight) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxJobCard_DeliveryDeleteAllByUom_Weight", scon);
			scom.CommandType = CommandType.StoredProcedure;
            //scon.Open();

            scom.Parameters.Add("@uom_Weight", SqlDbType.VarChar,10);
			scom.Parameters["@uom_Weight"].Value = uom_Weight;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxJobCard_Delivery table by a foreign key.
		/// </summary>
		public static void DeleteAllByLine_No_ProdJob_ID(int line_No, string prodJob_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxJobCard_DeliveryDeleteAllByLine_No_ProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
            //scon.Open();

            scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxJobCard_Delivery table by a foreign key.
		/// </summary>
		public static void DeleteAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxJobCard_DeliveryDeleteAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
            //scon.Open();

            scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxJobCard_Delivery table by a foreign key.
		/// </summary>
		//public static void DeleteAllByLine_No_ProdJob_ID(int line_No, string prodJob_ID) {
 
		//	SqlConnection scon =DBHandling.GetConnection();
		//	SqlCommand scom = new SqlCommand("tbl_prod_polyTxJobCard_DeliveryDeleteAllByLine_No_ProdJob_ID", scon);
		//	scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
		//	scom.Parameters.Add("@line_No", SqlDbType.Int,4);
		//	scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
		//	scom.Parameters["@line_No"].Value = line_No;
		//	scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
		//	scon.Open();
		//	scom.ExecuteNonQuery();
		//	scon.Close();
		//}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxJobCard_Delivery table by a foreign key.
		/// </summary>
		//public static void DeleteAllByLine_No_ProdJob_ID(int line_No, string prodJob_ID) {
 
		//	SqlConnection scon =DBHandling.GetConnection();
		//	SqlCommand scom = new SqlCommand("tbl_prod_polyTxJobCard_DeliveryDeleteAllByLine_No_ProdJob_ID", scon);
		//	scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
		//	scom.Parameters.Add("@line_No", SqlDbType.Int,4);
		//	scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
		//	scom.Parameters["@line_No"].Value = line_No;
		//	scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
 
		//	scon.Open();
		//	scom.ExecuteNonQuery();
		//	scon.Close();
		//}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxJobCard_Delivery table by a foreign key.
		/// </summary>
		public static void DeleteAllByUom_Qty(string uom_Qty) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxJobCard_DeliveryDeleteAllByUom_Qty", scon);
			scom.CommandType = CommandType.StoredProcedure;
            //scon.Open();

            scom.Parameters.Add("@uom_Qty", SqlDbType.VarChar,10);
			scom.Parameters["@uom_Qty"].Value = uom_Qty;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_prod_polyTxJobCard_Delivery table.
		/// </summary>
		public static tbl_prod_polyTxJobCard_Delivery Select(int line_No_Incoming, string prodJob_ID_Incoming){

			tbl_prod_polyTxJobCard_Delivery tbl_prod_polyTxJobCard_Deliveryins = new tbl_prod_polyTxJobCard_Delivery();
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxJobCard_DeliverySelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_prod_polyTxJobCard_Deliveryins = Maketbl_prod_polyTxJobCard_Delivery(dataReader);
				} else {
					tbl_prod_polyTxJobCard_Deliveryins = null;
				}
			}
			scon.Close();
			return tbl_prod_polyTxJobCard_Deliveryins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxJobCard_Delivery table.
		/// </summary>
		public static List<tbl_prod_polyTxJobCard_Delivery> SelectAll() {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxJobCard_DeliverySelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_prod_polyTxJobCard_Delivery> tbl_prod_polyTxJobCard_DeliveryList = new List<tbl_prod_polyTxJobCard_Delivery>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxJobCard_Delivery tbl_prod_polyTxJobCard_Delivery = Maketbl_prod_polyTxJobCard_Delivery(dataReader);
					tbl_prod_polyTxJobCard_DeliveryList.Add(tbl_prod_polyTxJobCard_Delivery);
				}
			}
			scon.Close();
			return tbl_prod_polyTxJobCard_DeliveryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxJobCard_Delivery table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxJobCard_Delivery> SelectAllByUom_Weight(string uom_Weight) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxJobCard_DeliverySelectAllByUom_Weight", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_Weight", SqlDbType.VarChar,10);
			scom.Parameters["@uom_Weight"].Value = uom_Weight;
				List<tbl_prod_polyTxJobCard_Delivery> tbl_prod_polyTxJobCard_DeliveryList = new List<tbl_prod_polyTxJobCard_Delivery>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxJobCard_Delivery tbl_prod_polyTxJobCard_Delivery = Maketbl_prod_polyTxJobCard_Delivery(dataReader);
					tbl_prod_polyTxJobCard_DeliveryList.Add(tbl_prod_polyTxJobCard_Delivery);
				}
			}
			scon.Close();
			return tbl_prod_polyTxJobCard_DeliveryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxJobCard_Delivery table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxJobCard_Delivery> SelectAllByLine_No_ProdJob_ID(int line_No, string prodJob_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxJobCard_DeliverySelectAllByLine_No_ProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prod_polyTxJobCard_Delivery> tbl_prod_polyTxJobCard_DeliveryList = new List<tbl_prod_polyTxJobCard_Delivery>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxJobCard_Delivery tbl_prod_polyTxJobCard_Delivery = Maketbl_prod_polyTxJobCard_Delivery(dataReader);
					tbl_prod_polyTxJobCard_DeliveryList.Add(tbl_prod_polyTxJobCard_Delivery);
				}
			}
			scon.Close();
			return tbl_prod_polyTxJobCard_DeliveryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxJobCard_Delivery table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxJobCard_Delivery> SelectAllByProdJob_ID(string prodJob_ID) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxJobCard_DeliverySelectAllByProdJob_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
			scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
				List<tbl_prod_polyTxJobCard_Delivery> tbl_prod_polyTxJobCard_DeliveryList = new List<tbl_prod_polyTxJobCard_Delivery>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxJobCard_Delivery tbl_prod_polyTxJobCard_Delivery = Maketbl_prod_polyTxJobCard_Delivery(dataReader);
					tbl_prod_polyTxJobCard_DeliveryList.Add(tbl_prod_polyTxJobCard_Delivery);
				}
			}
			scon.Close();
			return tbl_prod_polyTxJobCard_DeliveryList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxJobCard_Delivery table by a foreign key.
		/// </summary>
		//public static List<tbl_prod_polyTxJobCard_Delivery> SelectAllByLine_No_ProdJob_ID(int line_No, string prodJob_ID) {
 
		//	SqlConnection scon =DBHandling.GetConnection();
		//	SqlCommand scom = new SqlCommand("tbl_prod_polyTxJobCard_DeliverySelectAllByLine_No_ProdJob_ID", scon);
		//	scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
		//	scom.Parameters.Add("@line_No", SqlDbType.Int,4);
		//	scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
		//	scom.Parameters["@line_No"].Value = line_No;
		//	scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
		//		List<tbl_prod_polyTxJobCard_Delivery> tbl_prod_polyTxJobCard_DeliveryList = new List<tbl_prod_polyTxJobCard_Delivery>();
		//	using (SqlDataReader dataReader = scom.ExecuteReader()){
		//		while (dataReader.Read()) {
		//			tbl_prod_polyTxJobCard_Delivery tbl_prod_polyTxJobCard_Delivery = Maketbl_prod_polyTxJobCard_Delivery(dataReader);
		//			tbl_prod_polyTxJobCard_DeliveryList.Add(tbl_prod_polyTxJobCard_Delivery);
		//		}
		//	}
		//	scon.Close();
		//	return tbl_prod_polyTxJobCard_DeliveryList;
		//}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxJobCard_Delivery table by a foreign key.
		/// </summary>
		//public static List<tbl_prod_polyTxJobCard_Delivery> SelectAllByLine_No_ProdJob_ID(int line_No, string prodJob_ID) {
 
		//	SqlConnection scon =DBHandling.GetConnection();
		//	SqlCommand scom = new SqlCommand("tbl_prod_polyTxJobCard_DeliverySelectAllByLine_No_ProdJob_ID", scon);
		//	scom.CommandType = CommandType.StoredProcedure;
		//	scon.Open();
 
		//	scom.Parameters.Add("@line_No", SqlDbType.Int,4);
		//	scom.Parameters.Add("@prodJob_ID", SqlDbType.VarChar,20);
		//	scom.Parameters["@line_No"].Value = line_No;
		//	scom.Parameters["@prodJob_ID"].Value = prodJob_ID;
		//		List<tbl_prod_polyTxJobCard_Delivery> tbl_prod_polyTxJobCard_DeliveryList = new List<tbl_prod_polyTxJobCard_Delivery>();
		//	using (SqlDataReader dataReader = scom.ExecuteReader()){
		//		while (dataReader.Read()) {
		//			tbl_prod_polyTxJobCard_Delivery tbl_prod_polyTxJobCard_Delivery = Maketbl_prod_polyTxJobCard_Delivery(dataReader);
		//			tbl_prod_polyTxJobCard_DeliveryList.Add(tbl_prod_polyTxJobCard_Delivery);
		//		}
		//	}
		//	scon.Close();
		//	return tbl_prod_polyTxJobCard_DeliveryList;
		//}
		
		/// <summary>
		/// Selects all records from the tbl_prod_polyTxJobCard_Delivery table by a foreign key.
		/// </summary>
		public static List<tbl_prod_polyTxJobCard_Delivery> SelectAllByUom_Qty(string uom_Qty) {
 
			SqlConnection scon =DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_prod_polyTxJobCard_DeliverySelectAllByUom_Qty", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@uom_Qty", SqlDbType.VarChar,10);
			scom.Parameters["@uom_Qty"].Value = uom_Qty;
				List<tbl_prod_polyTxJobCard_Delivery> tbl_prod_polyTxJobCard_DeliveryList = new List<tbl_prod_polyTxJobCard_Delivery>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_prod_polyTxJobCard_Delivery tbl_prod_polyTxJobCard_Delivery = Maketbl_prod_polyTxJobCard_Delivery(dataReader);
					tbl_prod_polyTxJobCard_DeliveryList.Add(tbl_prod_polyTxJobCard_Delivery);
				}
			}
			scon.Close();
			return tbl_prod_polyTxJobCard_DeliveryList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_prod_polyTxJobCard_Delivery class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_prod_polyTxJobCard_Delivery Maketbl_prod_polyTxJobCard_Delivery(SqlDataReader dataReader) {
			tbl_prod_polyTxJobCard_Delivery tbl_prod_polyTxJobCard_Delivery = new tbl_prod_polyTxJobCard_Delivery();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_prod_polyTxJobCard_Delivery.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_prod_polyTxJobCard_Delivery.ProdJob_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_prod_polyTxJobCard_Delivery.DeliverDateTime = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_prod_polyTxJobCard_Delivery.CustomerBranch_Line_No = dataReader.GetInt32(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_prod_polyTxJobCard_Delivery.DeliverAddress = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_prod_polyTxJobCard_Delivery.DeliverQty = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_prod_polyTxJobCard_Delivery.DeliverWeight = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_prod_polyTxJobCard_Delivery.Uom_Qty = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_prod_polyTxJobCard_Delivery.Uom_Weight = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_prod_polyTxJobCard_Delivery.DeliverTerms = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_prod_polyTxJobCard_Delivery.Remarks = dataReader.GetString(10);
			}

			return tbl_prod_polyTxJobCard_Delivery;
		}
		/// <summary>
		/// This makes tbl_prod_polyTxJobCard_Delivery datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_prod_polyTxJobCard_Delivery object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_prod_polyTxJobCard_Delivery  tbl_prod_polyTxJobCard_Delivery   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_prodJob_ID = new DataColumn("prodJob_ID" , typeof(string));
			DataColumn col_deliverDateTime = new DataColumn("deliverDateTime" , typeof(DateTime));
			DataColumn col_customerBranch_Line_No = new DataColumn("customerBranch_Line_No" , typeof(int));
			DataColumn col_deliverAddress = new DataColumn("deliverAddress" , typeof(string));
			DataColumn col_deliverQty = new DataColumn("deliverQty" , typeof(decimal));
			DataColumn col_deliverWeight = new DataColumn("deliverWeight" , typeof(decimal));
			DataColumn col_uom_Qty = new DataColumn("uom_Qty" , typeof(string));
			DataColumn col_uom_Weight = new DataColumn("uom_Weight" , typeof(string));
			DataColumn col_deliverTerms = new DataColumn("deliverTerms" , typeof(string));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_prodJob_ID,col_deliverDateTime,col_customerBranch_Line_No,col_deliverAddress,col_deliverQty,col_deliverWeight,col_uom_Qty,col_uom_Weight,col_deliverTerms,col_remarks,});		return dt;
		}
		/// <summary>
		/// This fills tbl_prod_polyTxJobCard_Delivery datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_prod_polyTxJobCard_Delivery object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_prod_polyTxJobCard_Delivery user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["prodJob_ID"] = user.prodJob_ID;
			drow["deliverDateTime"] = user.deliverDateTime;
			drow["customerBranch_Line_No"] = user.customerBranch_Line_No;
			drow["deliverAddress"] = user.deliverAddress;
			drow["deliverQty"] = user.deliverQty;
			drow["deliverWeight"] = user.deliverWeight;
			drow["uom_Qty"] = user.uom_Qty;
			drow["uom_Weight"] = user.uom_Weight;
			drow["deliverTerms"] = user.deliverTerms;
			drow["remarks"] = user.remarks;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
