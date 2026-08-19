using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasDeliveryPlan_CustomerOrder_Items {
		#region Fields
		private int line_No;
		private string deliveryPlan_ID;
		private string customerOrder_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private decimal qty;
		private decimal weight;
		private decimal unitPrice;
		private decimal weightPrice;
		private decimal tatalAmount;
		private string remark;
		private bool isWeightCalculation;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasDeliveryPlan_CustomerOrder_Items class.
		/// </summary>
		public tbl_sasDeliveryPlan_CustomerOrder_Items() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasDeliveryPlan_CustomerOrder_Items class.
		/// </summary>
		public tbl_sasDeliveryPlan_CustomerOrder_Items(int line_No, string deliveryPlan_ID, string customerOrder_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal qty, decimal weight, decimal unitPrice, decimal weightPrice, decimal tatalAmount, string remark, bool isWeightCalculation) {
			this.line_No = line_No;
			this.deliveryPlan_ID = deliveryPlan_ID;
			this.customerOrder_ID = customerOrder_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.qty = qty;
			this.weight = weight;
			this.unitPrice = unitPrice;
			this.weightPrice = weightPrice;
			this.tatalAmount = tatalAmount;
			this.remark = remark;
			this.isWeightCalculation = isWeightCalculation;
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
		/// Gets or sets the DeliveryPlan_ID value.
		/// </summary>
		public string DeliveryPlan_ID {
			get { return deliveryPlan_ID; }
			set { deliveryPlan_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerOrder_ID value.
		/// </summary>
		public string CustomerOrder_ID {
			get { return customerOrder_ID; }
			set { customerOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubCategory_ID value.
		/// </summary>
		public string ItemSubCategory_ID {
			get { return itemSubCategory_ID; }
			set { itemSubCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubCategory2_ID value.
		/// </summary>
		public string ItemSubCategory2_ID {
			get { return itemSubCategory2_ID; }
			set { itemSubCategory2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo value.
		/// </summary>
		public string ItemSerialNo {
			get { return itemSerialNo; }
			set { itemSerialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo2 value.
		/// </summary>
		public string ItemSerialNo2 {
			get { return itemSerialNo2; }
			set { itemSerialNo2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
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
		/// Gets or sets the TatalAmount value.
		/// </summary>
		public decimal TatalAmount {
			get { return tatalAmount; }
			set { tatalAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsWeightCalculation value.
		/// </summary>
		public bool IsWeightCalculation {
			get { return isWeightCalculation; }
			set { isWeightCalculation = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasDeliveryPlan_CustomerOrder_Items table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrder_ItemsInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit,1);
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasDeliveryPlan_CustomerOrder_Items table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrder_ItemsUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@tatalAmount", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@isWeightCalculation", SqlDbType.Bit,1);
 
 
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@unitPrice"].Value = unitPrice;
			scom.Parameters["@weightPrice"].Value = weightPrice;
			scom.Parameters["@tatalAmount"].Value = tatalAmount;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@isWeightCalculation"].Value = isWeightCalculation;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasDeliveryPlan_CustomerOrder_Items table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrder_ItemsDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID;
 
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
 
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder_Items table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrder_ItemsDeleteAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder_Items table by a foreign key.
		/// </summary>
		public static void DeleteAllByDeliveryPlan_ID_CustomerOrder_ID(string deliveryPlan_ID, string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrder_ItemsDeleteAllByDeliveryPlan_ID_CustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder_Items table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrder_ItemsDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder_Items table by a foreign key.
		/// </summary>
		public static void DeleteAllByDeliveryPlan_ID(string deliveryPlan_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrder_ItemsDeleteAllByDeliveryPlan_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder_Items table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrder_ItemsDeleteAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder_Items table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrder_ItemsDeleteAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasDeliveryPlan_CustomerOrder_Items table.
		/// </summary>
		public static tbl_sasDeliveryPlan_CustomerOrder_Items Select(string deliveryPlan_ID_Incoming, string customerOrder_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_sasDeliveryPlan_CustomerOrder_Items tbl_sasDeliveryPlan_CustomerOrder_Itemsins = new tbl_sasDeliveryPlan_CustomerOrder_Items();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrder_ItemsSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID_Incoming;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasDeliveryPlan_CustomerOrder_Itemsins = Maketbl_sasDeliveryPlan_CustomerOrder_Items(dataReader);
				} else {
					tbl_sasDeliveryPlan_CustomerOrder_Itemsins = null;
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_CustomerOrder_Itemsins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder_Items table.
		/// </summary>
		public static List<tbl_sasDeliveryPlan_CustomerOrder_Items> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrder_ItemsSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasDeliveryPlan_CustomerOrder_Items> tbl_sasDeliveryPlan_CustomerOrder_ItemsList = new List<tbl_sasDeliveryPlan_CustomerOrder_Items>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryPlan_CustomerOrder_Items tbl_sasDeliveryPlan_CustomerOrder_Items = Maketbl_sasDeliveryPlan_CustomerOrder_Items(dataReader);
					tbl_sasDeliveryPlan_CustomerOrder_ItemsList.Add(tbl_sasDeliveryPlan_CustomerOrder_Items);
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_CustomerOrder_ItemsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder_Items table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryPlan_CustomerOrder_Items> SelectAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrder_ItemsSelectAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
				List<tbl_sasDeliveryPlan_CustomerOrder_Items> tbl_sasDeliveryPlan_CustomerOrder_ItemsList = new List<tbl_sasDeliveryPlan_CustomerOrder_Items>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryPlan_CustomerOrder_Items tbl_sasDeliveryPlan_CustomerOrder_Items = Maketbl_sasDeliveryPlan_CustomerOrder_Items(dataReader);
					tbl_sasDeliveryPlan_CustomerOrder_ItemsList.Add(tbl_sasDeliveryPlan_CustomerOrder_Items);
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_CustomerOrder_ItemsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder_Items table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryPlan_CustomerOrder_Items> SelectAllByDeliveryPlan_ID_CustomerOrder_ID(string deliveryPlan_ID, string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrder_ItemsSelectAllByDeliveryPlan_ID_CustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
				List<tbl_sasDeliveryPlan_CustomerOrder_Items> tbl_sasDeliveryPlan_CustomerOrder_ItemsList = new List<tbl_sasDeliveryPlan_CustomerOrder_Items>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryPlan_CustomerOrder_Items tbl_sasDeliveryPlan_CustomerOrder_Items = Maketbl_sasDeliveryPlan_CustomerOrder_Items(dataReader);
					tbl_sasDeliveryPlan_CustomerOrder_ItemsList.Add(tbl_sasDeliveryPlan_CustomerOrder_Items);
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_CustomerOrder_ItemsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder_Items table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryPlan_CustomerOrder_Items> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrder_ItemsSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_sasDeliveryPlan_CustomerOrder_Items> tbl_sasDeliveryPlan_CustomerOrder_ItemsList = new List<tbl_sasDeliveryPlan_CustomerOrder_Items>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryPlan_CustomerOrder_Items tbl_sasDeliveryPlan_CustomerOrder_Items = Maketbl_sasDeliveryPlan_CustomerOrder_Items(dataReader);
					tbl_sasDeliveryPlan_CustomerOrder_ItemsList.Add(tbl_sasDeliveryPlan_CustomerOrder_Items);
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_CustomerOrder_ItemsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder_Items table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryPlan_CustomerOrder_Items> SelectAllByDeliveryPlan_ID(string deliveryPlan_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrder_ItemsSelectAllByDeliveryPlan_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@deliveryPlan_ID", SqlDbType.VarChar,20);
			scom.Parameters["@deliveryPlan_ID"].Value = deliveryPlan_ID;
				List<tbl_sasDeliveryPlan_CustomerOrder_Items> tbl_sasDeliveryPlan_CustomerOrder_ItemsList = new List<tbl_sasDeliveryPlan_CustomerOrder_Items>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryPlan_CustomerOrder_Items tbl_sasDeliveryPlan_CustomerOrder_Items = Maketbl_sasDeliveryPlan_CustomerOrder_Items(dataReader);
					tbl_sasDeliveryPlan_CustomerOrder_ItemsList.Add(tbl_sasDeliveryPlan_CustomerOrder_Items);
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_CustomerOrder_ItemsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder_Items table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryPlan_CustomerOrder_Items> SelectAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrder_ItemsSelectAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
				List<tbl_sasDeliveryPlan_CustomerOrder_Items> tbl_sasDeliveryPlan_CustomerOrder_ItemsList = new List<tbl_sasDeliveryPlan_CustomerOrder_Items>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryPlan_CustomerOrder_Items tbl_sasDeliveryPlan_CustomerOrder_Items = Maketbl_sasDeliveryPlan_CustomerOrder_Items(dataReader);
					tbl_sasDeliveryPlan_CustomerOrder_ItemsList.Add(tbl_sasDeliveryPlan_CustomerOrder_Items);
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_CustomerOrder_ItemsList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasDeliveryPlan_CustomerOrder_Items table by a foreign key.
		/// </summary>
		public static List<tbl_sasDeliveryPlan_CustomerOrder_Items> SelectAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasDeliveryPlan_CustomerOrder_ItemsSelectAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
				List<tbl_sasDeliveryPlan_CustomerOrder_Items> tbl_sasDeliveryPlan_CustomerOrder_ItemsList = new List<tbl_sasDeliveryPlan_CustomerOrder_Items>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasDeliveryPlan_CustomerOrder_Items tbl_sasDeliveryPlan_CustomerOrder_Items = Maketbl_sasDeliveryPlan_CustomerOrder_Items(dataReader);
					tbl_sasDeliveryPlan_CustomerOrder_ItemsList.Add(tbl_sasDeliveryPlan_CustomerOrder_Items);
				}
			}
			scon.Close();
			return tbl_sasDeliveryPlan_CustomerOrder_ItemsList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasDeliveryPlan_CustomerOrder_Items class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasDeliveryPlan_CustomerOrder_Items Maketbl_sasDeliveryPlan_CustomerOrder_Items(SqlDataReader dataReader) {
			tbl_sasDeliveryPlan_CustomerOrder_Items tbl_sasDeliveryPlan_CustomerOrder_Items = new tbl_sasDeliveryPlan_CustomerOrder_Items();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasDeliveryPlan_CustomerOrder_Items.Line_No = dataReader.GetInt32(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasDeliveryPlan_CustomerOrder_Items.DeliveryPlan_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasDeliveryPlan_CustomerOrder_Items.CustomerOrder_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasDeliveryPlan_CustomerOrder_Items.Item_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasDeliveryPlan_CustomerOrder_Items.ItemSubCategory_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasDeliveryPlan_CustomerOrder_Items.ItemSubCategory2_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasDeliveryPlan_CustomerOrder_Items.ItemSerialNo = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasDeliveryPlan_CustomerOrder_Items.ItemSerialNo2 = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasDeliveryPlan_CustomerOrder_Items.Qty = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasDeliveryPlan_CustomerOrder_Items.Weight = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasDeliveryPlan_CustomerOrder_Items.UnitPrice = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasDeliveryPlan_CustomerOrder_Items.WeightPrice = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasDeliveryPlan_CustomerOrder_Items.TatalAmount = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasDeliveryPlan_CustomerOrder_Items.Remark = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasDeliveryPlan_CustomerOrder_Items.IsWeightCalculation = dataReader.GetBoolean(14);
			}

			return tbl_sasDeliveryPlan_CustomerOrder_Items;
		}
		/// <summary>
		/// This makes tbl_sasDeliveryPlan_CustomerOrder_Items datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasDeliveryPlan_CustomerOrder_Items object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasDeliveryPlan_CustomerOrder_Items  tbl_sasDeliveryPlan_CustomerOrder_Items   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_deliveryPlan_ID = new DataColumn("deliveryPlan_ID" , typeof(string));
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_unitPrice = new DataColumn("unitPrice" , typeof(decimal));
			DataColumn col_weightPrice = new DataColumn("weightPrice" , typeof(decimal));
			DataColumn col_tatalAmount = new DataColumn("tatalAmount" , typeof(decimal));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_isWeightCalculation = new DataColumn("isWeightCalculation" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_line_No,col_deliveryPlan_ID,col_customerOrder_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_qty,col_weight,col_unitPrice,col_weightPrice,col_tatalAmount,col_remark,col_isWeightCalculation,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasDeliveryPlan_CustomerOrder_Items datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasDeliveryPlan_CustomerOrder_Items object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasDeliveryPlan_CustomerOrder_Items user) {
		DataRow drow = dt.NewRow();
		
			drow["line_No"] = user.line_No;
			drow["deliveryPlan_ID"] = user.deliveryPlan_ID;
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["qty"] = user.qty;
			drow["weight"] = user.weight;
			drow["unitPrice"] = user.unitPrice;
			drow["weightPrice"] = user.weightPrice;
			drow["tatalAmount"] = user.tatalAmount;
			drow["remark"] = user.remark;
			drow["isWeightCalculation"] = user.isWeightCalculation;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
