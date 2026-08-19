using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire
{
	public sealed class tbl_genItemMaster_Pricing {
		#region Fields
		private string item_ID;
		private decimal costPrice1;
		private decimal costPrice2;
		private decimal lifoCostPrice;
		private decimal fifoCostPrice;
		private decimal weightedAverageCostPrice;
		private decimal highestPurchaseCostPrice;
		private decimal lowestPurchaseCostPrice;
		private decimal sellingPrice1;
		private decimal sellingPrice2;
		private decimal sellingPrice3;
		private decimal sellingPrice4;
		private decimal sellingPrice5;
		private decimal sellingPrice6;
		private bool isVATinclusive;
		private bool isNBTinclusive;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_Pricing class.
		/// </summary>
		public tbl_genItemMaster_Pricing() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_Pricing class.
		/// </summary>
		public tbl_genItemMaster_Pricing(string item_ID, decimal costPrice1, decimal costPrice2, decimal lifoCostPrice, decimal fifoCostPrice, decimal weightedAverageCostPrice, decimal highestPurchaseCostPrice, decimal lowestPurchaseCostPrice, decimal sellingPrice1, decimal sellingPrice2, decimal sellingPrice3, decimal sellingPrice4, decimal sellingPrice5, decimal sellingPrice6, bool isVATinclusive, bool isNBTinclusive) {
			this.item_ID = item_ID;
			this.costPrice1 = costPrice1;
			this.costPrice2 = costPrice2;
			this.lifoCostPrice = lifoCostPrice;
			this.fifoCostPrice = fifoCostPrice;
			this.weightedAverageCostPrice = weightedAverageCostPrice;
			this.highestPurchaseCostPrice = highestPurchaseCostPrice;
			this.lowestPurchaseCostPrice = lowestPurchaseCostPrice;
			this.sellingPrice1 = sellingPrice1;
			this.sellingPrice2 = sellingPrice2;
			this.sellingPrice3 = sellingPrice3;
			this.sellingPrice4 = sellingPrice4;
			this.sellingPrice5 = sellingPrice5;
			this.sellingPrice6 = sellingPrice6;
			this.isVATinclusive = isVATinclusive;
			this.isNBTinclusive = isNBTinclusive;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostPrice1 value.
		/// </summary>
		public decimal CostPrice1 {
			get { return costPrice1; }
			set { costPrice1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostPrice2 value.
		/// </summary>
		public decimal CostPrice2 {
			get { return costPrice2; }
			set { costPrice2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the LifoCostPrice value.
		/// </summary>
		public decimal LifoCostPrice {
			get { return lifoCostPrice; }
			set { lifoCostPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the FifoCostPrice value.
		/// </summary>
		public decimal FifoCostPrice {
			get { return fifoCostPrice; }
			set { fifoCostPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightedAverageCostPrice value.
		/// </summary>
		public decimal WeightedAverageCostPrice {
			get { return weightedAverageCostPrice; }
			set { weightedAverageCostPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the HighestPurchaseCostPrice value.
		/// </summary>
		public decimal HighestPurchaseCostPrice {
			get { return highestPurchaseCostPrice; }
			set { highestPurchaseCostPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the LowestPurchaseCostPrice value.
		/// </summary>
		public decimal LowestPurchaseCostPrice {
			get { return lowestPurchaseCostPrice; }
			set { lowestPurchaseCostPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the SellingPrice1 value.
		/// </summary>
		public decimal SellingPrice1 {
			get { return sellingPrice1; }
			set { sellingPrice1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the SellingPrice2 value.
		/// </summary>
		public decimal SellingPrice2 {
			get { return sellingPrice2; }
			set { sellingPrice2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the SellingPrice3 value.
		/// </summary>
		public decimal SellingPrice3 {
			get { return sellingPrice3; }
			set { sellingPrice3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the SellingPrice4 value.
		/// </summary>
		public decimal SellingPrice4 {
			get { return sellingPrice4; }
			set { sellingPrice4 = value; }
		}
		
		/// <summary>
		/// Gets or sets the SellingPrice5 value.
		/// </summary>
		public decimal SellingPrice5 {
			get { return sellingPrice5; }
			set { sellingPrice5 = value; }
		}
		
		/// <summary>
		/// Gets or sets the SellingPrice6 value.
		/// </summary>
		public decimal SellingPrice6 {
			get { return sellingPrice6; }
			set { sellingPrice6 = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsVATinclusive value.
		/// </summary>
		public bool IsVATinclusive {
			get { return isVATinclusive; }
			set { isVATinclusive = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsNBTinclusive value.
		/// </summary>
		public bool IsNBTinclusive {
			get { return isNBTinclusive; }
			set { isNBTinclusive = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genItemMaster_Pricing table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricingInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costPrice1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costPrice2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lifoCostPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@fifoCostPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightedAverageCostPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@highestPurchaseCostPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lowestPurchaseCostPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice3", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice4", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice5", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice6", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isVATinclusive", SqlDbType.Bit,1);
			scom.Parameters.Add("@isNBTinclusive", SqlDbType.Bit,1);
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@costPrice1"].Value = costPrice1;
			scom.Parameters["@costPrice2"].Value = costPrice2;
			scom.Parameters["@lifoCostPrice"].Value = lifoCostPrice;
			scom.Parameters["@fifoCostPrice"].Value = fifoCostPrice;
			scom.Parameters["@weightedAverageCostPrice"].Value = weightedAverageCostPrice;
			scom.Parameters["@highestPurchaseCostPrice"].Value = highestPurchaseCostPrice;
			scom.Parameters["@lowestPurchaseCostPrice"].Value = lowestPurchaseCostPrice;
			scom.Parameters["@sellingPrice1"].Value = sellingPrice1;
			scom.Parameters["@sellingPrice2"].Value = sellingPrice2;
			scom.Parameters["@sellingPrice3"].Value = sellingPrice3;
			scom.Parameters["@sellingPrice4"].Value = sellingPrice4;
			scom.Parameters["@sellingPrice5"].Value = sellingPrice5;
			scom.Parameters["@sellingPrice6"].Value = sellingPrice6;
			scom.Parameters["@isVATinclusive"].Value = isVATinclusive;
			scom.Parameters["@isNBTinclusive"].Value = isNBTinclusive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genItemMaster_Pricing table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricingUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@costPrice1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costPrice2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lifoCostPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@fifoCostPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightedAverageCostPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@highestPurchaseCostPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lowestPurchaseCostPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice3", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice4", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice5", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice6", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isVATinclusive", SqlDbType.Bit,1);
			scom.Parameters.Add("@isNBTinclusive", SqlDbType.Bit,1);
 
 
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@costPrice1"].Value = costPrice1;
			scom.Parameters["@costPrice2"].Value = costPrice2;
			scom.Parameters["@lifoCostPrice"].Value = lifoCostPrice;
			scom.Parameters["@fifoCostPrice"].Value = fifoCostPrice;
			scom.Parameters["@weightedAverageCostPrice"].Value = weightedAverageCostPrice;
			scom.Parameters["@highestPurchaseCostPrice"].Value = highestPurchaseCostPrice;
			scom.Parameters["@lowestPurchaseCostPrice"].Value = lowestPurchaseCostPrice;
			scom.Parameters["@sellingPrice1"].Value = sellingPrice1;
			scom.Parameters["@sellingPrice2"].Value = sellingPrice2;
			scom.Parameters["@sellingPrice3"].Value = sellingPrice3;
			scom.Parameters["@sellingPrice4"].Value = sellingPrice4;
			scom.Parameters["@sellingPrice5"].Value = sellingPrice5;
			scom.Parameters["@sellingPrice6"].Value = sellingPrice6;
			scom.Parameters["@isVATinclusive"].Value = isVATinclusive;
			scom.Parameters["@isNBTinclusive"].Value = isNBTinclusive;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genItemMaster_Pricing table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricingDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Pricing table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricingDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genItemMaster_Pricing table.
		/// </summary>
		public static tbl_genItemMaster_Pricing Select(string item_ID_Incoming){

			tbl_genItemMaster_Pricing tbl_genItemMaster_Pricingins = new tbl_genItemMaster_Pricing();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricingSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItemMaster_Pricingins = Maketbl_genItemMaster_Pricing(dataReader);
				} else {
					tbl_genItemMaster_Pricingins = null;
				}
			}
			scon.Close();
			return tbl_genItemMaster_Pricingins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Pricing table.
		/// </summary>
		public static List<tbl_genItemMaster_Pricing> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricingSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItemMaster_Pricing> tbl_genItemMaster_PricingList = new List<tbl_genItemMaster_Pricing>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Pricing tbl_genItemMaster_Pricing = Maketbl_genItemMaster_Pricing(dataReader);
					tbl_genItemMaster_PricingList.Add(tbl_genItemMaster_Pricing);
				}
			}
			scon.Close();
			return tbl_genItemMaster_PricingList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Pricing table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_Pricing> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_PricingSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_genItemMaster_Pricing> tbl_genItemMaster_PricingList = new List<tbl_genItemMaster_Pricing>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Pricing tbl_genItemMaster_Pricing = Maketbl_genItemMaster_Pricing(dataReader);
					tbl_genItemMaster_PricingList.Add(tbl_genItemMaster_Pricing);
				}
			}
			scon.Close();
			return tbl_genItemMaster_PricingList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genItemMaster_Pricing class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItemMaster_Pricing Maketbl_genItemMaster_Pricing(SqlDataReader dataReader) {
			tbl_genItemMaster_Pricing tbl_genItemMaster_Pricing = new tbl_genItemMaster_Pricing();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItemMaster_Pricing.Item_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItemMaster_Pricing.CostPrice1 = dataReader.GetDecimal(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genItemMaster_Pricing.CostPrice2 = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genItemMaster_Pricing.LifoCostPrice = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genItemMaster_Pricing.FifoCostPrice = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genItemMaster_Pricing.WeightedAverageCostPrice = dataReader.GetDecimal(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genItemMaster_Pricing.HighestPurchaseCostPrice = dataReader.GetDecimal(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genItemMaster_Pricing.LowestPurchaseCostPrice = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genItemMaster_Pricing.SellingPrice1 = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genItemMaster_Pricing.SellingPrice2 = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genItemMaster_Pricing.SellingPrice3 = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genItemMaster_Pricing.SellingPrice4 = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genItemMaster_Pricing.SellingPrice5 = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genItemMaster_Pricing.SellingPrice6 = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genItemMaster_Pricing.IsVATinclusive = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genItemMaster_Pricing.IsNBTinclusive = dataReader.GetBoolean(15);
			}

			return tbl_genItemMaster_Pricing;
		}
		/// <summary>
		/// This makes tbl_genItemMaster_Pricing datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_Pricing object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItemMaster_Pricing  tbl_genItemMaster_Pricing   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_costPrice1 = new DataColumn("costPrice1" , typeof(decimal));
			DataColumn col_costPrice2 = new DataColumn("costPrice2" , typeof(decimal));
			DataColumn col_lifoCostPrice = new DataColumn("lifoCostPrice" , typeof(decimal));
			DataColumn col_fifoCostPrice = new DataColumn("fifoCostPrice" , typeof(decimal));
			DataColumn col_weightedAverageCostPrice = new DataColumn("weightedAverageCostPrice" , typeof(decimal));
			DataColumn col_highestPurchaseCostPrice = new DataColumn("highestPurchaseCostPrice" , typeof(decimal));
			DataColumn col_lowestPurchaseCostPrice = new DataColumn("lowestPurchaseCostPrice" , typeof(decimal));
			DataColumn col_sellingPrice1 = new DataColumn("sellingPrice1" , typeof(decimal));
			DataColumn col_sellingPrice2 = new DataColumn("sellingPrice2" , typeof(decimal));
			DataColumn col_sellingPrice3 = new DataColumn("sellingPrice3" , typeof(decimal));
			DataColumn col_sellingPrice4 = new DataColumn("sellingPrice4" , typeof(decimal));
			DataColumn col_sellingPrice5 = new DataColumn("sellingPrice5" , typeof(decimal));
			DataColumn col_sellingPrice6 = new DataColumn("sellingPrice6" , typeof(decimal));
			DataColumn col_isVATinclusive = new DataColumn("isVATinclusive" , typeof(bool));
			DataColumn col_isNBTinclusive = new DataColumn("isNBTinclusive" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_item_ID,col_costPrice1,col_costPrice2,col_lifoCostPrice,col_fifoCostPrice,col_weightedAverageCostPrice,col_highestPurchaseCostPrice,col_lowestPurchaseCostPrice,col_sellingPrice1,col_sellingPrice2,col_sellingPrice3,col_sellingPrice4,col_sellingPrice5,col_sellingPrice6,col_isVATinclusive,col_isNBTinclusive,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItemMaster_Pricing datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_Pricing object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItemMaster_Pricing user) {
		DataRow drow = dt.NewRow();
		
			drow["item_ID"] = user.item_ID;
			drow["costPrice1"] = user.costPrice1;
			drow["costPrice2"] = user.costPrice2;
			drow["lifoCostPrice"] = user.lifoCostPrice;
			drow["fifoCostPrice"] = user.fifoCostPrice;
			drow["weightedAverageCostPrice"] = user.weightedAverageCostPrice;
			drow["highestPurchaseCostPrice"] = user.highestPurchaseCostPrice;
			drow["lowestPurchaseCostPrice"] = user.lowestPurchaseCostPrice;
			drow["sellingPrice1"] = user.sellingPrice1;
			drow["sellingPrice2"] = user.sellingPrice2;
			drow["sellingPrice3"] = user.sellingPrice3;
			drow["sellingPrice4"] = user.sellingPrice4;
			drow["sellingPrice5"] = user.sellingPrice5;
			drow["sellingPrice6"] = user.sellingPrice6;
			drow["isVATinclusive"] = user.isVATinclusive;
			drow["isNBTinclusive"] = user.isNBTinclusive;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
