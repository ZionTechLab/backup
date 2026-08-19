using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_ttsTenderReadingsDetails {
		#region Fields
		private string tender_ID;
		private string serialNo;
		private string item_ID;
		private string bidder_ID;
		private string terms;
		private string currency;
		private decimal unitPrice;
		private string bidBond;
		private string paymentReceipt;
		private string localAgent;
		private string deliveryDetails;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderReadingsDetails class.
		/// </summary>
		public tbl_ttsTenderReadingsDetails() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_ttsTenderReadingsDetails class.
		/// </summary>
		public tbl_ttsTenderReadingsDetails(string tender_ID, string serialNo, string item_ID, string bidder_ID, string terms, string currency, decimal unitPrice, string bidBond, string paymentReceipt, string localAgent, string deliveryDetails) {
			this.tender_ID = tender_ID;
			this.serialNo = serialNo;
			this.item_ID = item_ID;
			this.bidder_ID = bidder_ID;
			this.terms = terms;
			this.currency = currency;
			this.unitPrice = unitPrice;
			this.bidBond = bidBond;
			this.paymentReceipt = paymentReceipt;
			this.localAgent = localAgent;
			this.deliveryDetails = deliveryDetails;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Tender_ID value.
		/// </summary>
		public string Tender_ID {
			get { return tender_ID; }
			set { tender_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SerialNo value.
		/// </summary>
		public string SerialNo {
			get { return serialNo; }
			set { serialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Bidder_ID value.
		/// </summary>
		public string Bidder_ID {
			get { return bidder_ID; }
			set { bidder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Terms value.
		/// </summary>
		public string Terms {
			get { return terms; }
			set { terms = value; }
		}
		
		/// <summary>
		/// Gets or sets the Currency value.
		/// </summary>
		public string Currency {
			get { return currency; }
			set { currency = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitPrice value.
		/// </summary>
		public decimal UnitPrice {
			get { return unitPrice; }
			set { unitPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the BidBond value.
		/// </summary>
		public string BidBond {
			get { return bidBond; }
			set { bidBond = value; }
		}
		
		/// <summary>
		/// Gets or sets the PaymentReceipt value.
		/// </summary>
		public string PaymentReceipt {
			get { return paymentReceipt; }
			set { paymentReceipt = value; }
		}
		
		/// <summary>
		/// Gets or sets the LocalAgent value.
		/// </summary>
		public string LocalAgent {
			get { return localAgent; }
			set { localAgent = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryDetails value.
		/// </summary>
		public string DeliveryDetails {
			get { return deliveryDetails; }
			set { deliveryDetails = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_ttsTenderReadingsDetails table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderReadingsDetailsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@serialNo", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bidder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terms", SqlDbType.VarChar,1000);
			scom.Parameters.Add("@currency", SqlDbType.VarChar,10);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bidBond", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paymentReceipt", SqlDbType.VarChar,50);
			scom.Parameters.Add("@localAgent", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deliveryDetails", SqlDbType.VarChar,100);
 
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@serialNo"].Value = serialNo;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@bidder_ID"].Value = bidder_ID;
			scom.Parameters["@terms"].Value = terms;
			scom.Parameters["@currency"].Value = currency;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@bidBond"].Value = bidBond;
			scom.Parameters["@paymentReceipt"].Value = paymentReceipt;
			scom.Parameters["@localAgent"].Value = localAgent;
			scom.Parameters["@deliveryDetails"].Value = deliveryDetails;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_ttsTenderReadingsDetails table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderReadingsDetailsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@serialNo", SqlDbType.VarChar,10);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@bidder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@terms", SqlDbType.VarChar,1000);
			scom.Parameters.Add("@currency", SqlDbType.VarChar,10);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@bidBond", SqlDbType.VarChar,10);
			scom.Parameters.Add("@paymentReceipt", SqlDbType.VarChar,50);
			scom.Parameters.Add("@localAgent", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deliveryDetails", SqlDbType.VarChar,100);
 
 
			scom.Parameters["@tender_ID"].Value = tender_ID;
			scom.Parameters["@serialNo"].Value = serialNo;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@bidder_ID"].Value = bidder_ID;
			scom.Parameters["@terms"].Value = terms;
			scom.Parameters["@currency"].Value = currency;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@bidBond"].Value = bidBond;
			scom.Parameters["@paymentReceipt"].Value = paymentReceipt;
			scom.Parameters["@localAgent"].Value = localAgent;
			scom.Parameters["@deliveryDetails"].Value = deliveryDetails;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_ttsTenderReadingsDetails table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderReadingsDetailsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@serialNo", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
 
			scom.Parameters["@serialNo"].Value = serialNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderReadingsDetails table by a foreign key.
		/// </summary>
		public static void DeleteAllByTender_ID(string tender_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderReadingsDetailsDeleteAllByTender_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;

			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderReadingsDetails table by a foreign key.
		/// </summary>
		public static void DeleteAllByCurrency(string currency) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderReadingsDetailsDeleteAllByCurrency", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@currency", SqlDbType.VarChar,10);
			scom.Parameters["@currency"].Value = currency;
 
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderReadingsDetails table by a foreign key.
		/// </summary>
		public static void DeleteAllByBidder_ID(string bidder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderReadingsDetailsDeleteAllByBidder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bidder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@bidder_ID"].Value = bidder_ID;
 
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_ttsTenderReadingsDetails table.
		/// </summary>
		public static tbl_ttsTenderReadingsDetails Select(string tender_ID_Incoming, string serialNo_Incoming){

			tbl_ttsTenderReadingsDetails tbl_ttsTenderReadingsDetailsins = new tbl_ttsTenderReadingsDetails();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderReadingsDetailsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@serialNo", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID_Incoming;
			scom.Parameters["@serialNo"].Value = serialNo_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_ttsTenderReadingsDetailsins = Maketbl_ttsTenderReadingsDetails(dataReader);
				} else {
					tbl_ttsTenderReadingsDetailsins = null;
				}
			}
			scon.Close();
			return tbl_ttsTenderReadingsDetailsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderReadingsDetails table.
		/// </summary>
		public static List<tbl_ttsTenderReadingsDetails> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderReadingsDetailsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_ttsTenderReadingsDetails> tbl_ttsTenderReadingsDetailsList = new List<tbl_ttsTenderReadingsDetails>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderReadingsDetails tbl_ttsTenderReadingsDetails = Maketbl_ttsTenderReadingsDetails(dataReader);
					tbl_ttsTenderReadingsDetailsList.Add(tbl_ttsTenderReadingsDetails);
				}
			}
			scon.Close();
			return tbl_ttsTenderReadingsDetailsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderReadingsDetails table by a foreign key.
		/// </summary>
		public static List<tbl_ttsTenderReadingsDetails> SelectAllByTender_ID(string tender_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderReadingsDetailsSelectAllByTender_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@tender_ID", SqlDbType.VarChar,10);
			scom.Parameters["@tender_ID"].Value = tender_ID;
				List<tbl_ttsTenderReadingsDetails> tbl_ttsTenderReadingsDetailsList = new List<tbl_ttsTenderReadingsDetails>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderReadingsDetails tbl_ttsTenderReadingsDetails = Maketbl_ttsTenderReadingsDetails(dataReader);
					tbl_ttsTenderReadingsDetailsList.Add(tbl_ttsTenderReadingsDetails);
				}
			}
			scon.Close();
			return tbl_ttsTenderReadingsDetailsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderReadingsDetails table by a foreign key.
		/// </summary>
		public static List<tbl_ttsTenderReadingsDetails> SelectAllByCurrency(string currency) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderReadingsDetailsSelectAllByCurrency", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@currency", SqlDbType.VarChar,10);
			scom.Parameters["@currency"].Value = currency;
				List<tbl_ttsTenderReadingsDetails> tbl_ttsTenderReadingsDetailsList = new List<tbl_ttsTenderReadingsDetails>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderReadingsDetails tbl_ttsTenderReadingsDetails = Maketbl_ttsTenderReadingsDetails(dataReader);
					tbl_ttsTenderReadingsDetailsList.Add(tbl_ttsTenderReadingsDetails);
				}
			}
			scon.Close();
			return tbl_ttsTenderReadingsDetailsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_ttsTenderReadingsDetails table by a foreign key.
		/// </summary>
		public static List<tbl_ttsTenderReadingsDetails> SelectAllByBidder_ID(string bidder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_ttsTenderReadingsDetailsSelectAllByBidder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@bidder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@bidder_ID"].Value = bidder_ID;
				List<tbl_ttsTenderReadingsDetails> tbl_ttsTenderReadingsDetailsList = new List<tbl_ttsTenderReadingsDetails>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_ttsTenderReadingsDetails tbl_ttsTenderReadingsDetails = Maketbl_ttsTenderReadingsDetails(dataReader);
					tbl_ttsTenderReadingsDetailsList.Add(tbl_ttsTenderReadingsDetails);
				}
			}
			scon.Close();
			return tbl_ttsTenderReadingsDetailsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_ttsTenderReadingsDetails class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_ttsTenderReadingsDetails Maketbl_ttsTenderReadingsDetails(SqlDataReader dataReader) {
			tbl_ttsTenderReadingsDetails tbl_ttsTenderReadingsDetails = new tbl_ttsTenderReadingsDetails();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_ttsTenderReadingsDetails.Tender_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_ttsTenderReadingsDetails.SerialNo = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_ttsTenderReadingsDetails.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_ttsTenderReadingsDetails.Bidder_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_ttsTenderReadingsDetails.Terms = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_ttsTenderReadingsDetails.Currency = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_ttsTenderReadingsDetails.UnitPrice = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_ttsTenderReadingsDetails.BidBond = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_ttsTenderReadingsDetails.PaymentReceipt = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_ttsTenderReadingsDetails.LocalAgent = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_ttsTenderReadingsDetails.DeliveryDetails = dataReader.GetString(10);
			}

			return tbl_ttsTenderReadingsDetails;
		}
		/// <summary>
		/// This makes tbl_ttsTenderReadingsDetails datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_ttsTenderReadingsDetails object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_ttsTenderReadingsDetails  tbl_ttsTenderReadingsDetails   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_tender_ID = new DataColumn("tender_ID" , typeof(string));
			DataColumn col_serialNo = new DataColumn("serialNo" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_bidder_ID = new DataColumn("bidder_ID" , typeof(string));
			DataColumn col_terms = new DataColumn("terms" , typeof(string));
			DataColumn col_currency = new DataColumn("currency" , typeof(string));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_bidBond = new DataColumn("bidBond" , typeof(string));
			DataColumn col_paymentReceipt = new DataColumn("paymentReceipt" , typeof(string));
			DataColumn col_localAgent = new DataColumn("localAgent" , typeof(string));
			DataColumn col_deliveryDetails = new DataColumn("deliveryDetails" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_tender_ID,col_serialNo,col_item_ID,col_bidder_ID,col_terms,col_currency,col_unitPrice,col_bidBond,col_paymentReceipt,col_localAgent,col_deliveryDetails,});		return dt;
		}
		/// <summary>
		/// This fills tbl_ttsTenderReadingsDetails datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_ttsTenderReadingsDetails object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_ttsTenderReadingsDetails user) {
		DataRow drow = dt.NewRow();
		
			drow["tender_ID"] = user.tender_ID;
			drow["serialNo"] = user.serialNo;
			drow["item_ID"] = user.item_ID;
			drow["bidder_ID"] = user.bidder_ID;
			drow["terms"] = user.terms;
			drow["currency"] = user.currency;
			drow["unitPrice"] = user.unitPrice;
			drow["bidBond"] = user.bidBond;
			drow["paymentReceipt"] = user.paymentReceipt;
			drow["localAgent"] = user.localAgent;
			drow["deliveryDetails"] = user.deliveryDetails;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
