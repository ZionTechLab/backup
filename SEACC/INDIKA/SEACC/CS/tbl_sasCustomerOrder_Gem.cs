using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_sasCustomerOrder_Gem {
		#region Fields
		private string customerOrder_ID;
		private string item_ID;
		private DateTime itemDate;
		private string description;
		private string refNo;
		private string itemLength;
		private string itemSize;
		private string imagePath1;
		private string imagePath2;
		private string imagePath3;
		private string gemDetail;
		private string metalDetail;
		private string itemCategory_ID;
		private string itemClass_ID;
		private string itemType_ID;
		private decimal weight;
		private decimal sellingPrice;
		private decimal costPrice;
		private decimal averageWeightFrom;
		private decimal averageWeightTo;
		private bool isManufacture;
		private bool isBuyingAndSelling;
		private bool isOrdered;
		private string createUser_ID;
		private string modifiedUser_ID;
		private string deletedUser_ID;
		private string createTerminal_ID;
		private string modifiedTerminal_ID;
		private string deletedTerminal_ID;
		private DateTime dateCreate;
		private DateTime dateModified;
		private DateTime dateDeleted;
		private bool isDeleted;
		private string remarks;
		private bool isRepaire;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_sasCustomerOrder_Gem class.
		/// </summary>
		public tbl_sasCustomerOrder_Gem() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_sasCustomerOrder_Gem class.
		/// </summary>
		public tbl_sasCustomerOrder_Gem(string customerOrder_ID, string item_ID, DateTime itemDate, string description, string refNo, string itemLength, string itemSize, string imagePath1, string imagePath2, string imagePath3, string gemDetail, string metalDetail, string itemCategory_ID, string itemClass_ID, string itemType_ID, decimal weight, decimal sellingPrice, decimal costPrice, decimal averageWeightFrom, decimal averageWeightTo, bool isManufacture, bool isBuyingAndSelling, bool isOrdered, string createUser_ID, string modifiedUser_ID, string deletedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateDeleted, bool isDeleted, string remarks, bool isRepaire) {
			this.customerOrder_ID = customerOrder_ID;
			this.item_ID = item_ID;
			this.itemDate = itemDate;
			this.description = description;
			this.refNo = refNo;
			this.itemLength = itemLength;
			this.itemSize = itemSize;
			this.imagePath1 = imagePath1;
			this.imagePath2 = imagePath2;
			this.imagePath3 = imagePath3;
			this.gemDetail = gemDetail;
			this.metalDetail = metalDetail;
			this.itemCategory_ID = itemCategory_ID;
			this.itemClass_ID = itemClass_ID;
			this.itemType_ID = itemType_ID;
			this.weight = weight;
			this.sellingPrice = sellingPrice;
			this.costPrice = costPrice;
			this.averageWeightFrom = averageWeightFrom;
			this.averageWeightTo = averageWeightTo;
			this.isManufacture = isManufacture;
			this.isBuyingAndSelling = isBuyingAndSelling;
			this.isOrdered = isOrdered;
			this.createUser_ID = createUser_ID;
			this.modifiedUser_ID = modifiedUser_ID;
			this.deletedUser_ID = deletedUser_ID;
			this.createTerminal_ID = createTerminal_ID;
			this.modifiedTerminal_ID = modifiedTerminal_ID;
			this.deletedTerminal_ID = deletedTerminal_ID;
			this.dateCreate = dateCreate;
			this.dateModified = dateModified;
			this.dateDeleted = dateDeleted;
			this.isDeleted = isDeleted;
			this.remarks = remarks;
			this.isRepaire = isRepaire;
		}
		#endregion
		
		#region Properties
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
		/// Gets or sets the ItemDate value.
		/// </summary>
		public DateTime ItemDate {
			get { return itemDate; }
			set { itemDate = value; }
		}
		
		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description {
			get { return description; }
			set { description = value; }
		}
		
		/// <summary>
		/// Gets or sets the RefNo value.
		/// </summary>
		public string RefNo {
			get { return refNo; }
			set { refNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemLength value.
		/// </summary>
		public string ItemLength {
			get { return itemLength; }
			set { itemLength = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSize value.
		/// </summary>
		public string ItemSize {
			get { return itemSize; }
			set { itemSize = value; }
		}
		
		/// <summary>
		/// Gets or sets the ImagePath1 value.
		/// </summary>
		public string ImagePath1 {
			get { return imagePath1; }
			set { imagePath1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the ImagePath2 value.
		/// </summary>
		public string ImagePath2 {
			get { return imagePath2; }
			set { imagePath2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the ImagePath3 value.
		/// </summary>
		public string ImagePath3 {
			get { return imagePath3; }
			set { imagePath3 = value; }
		}
		
		/// <summary>
		/// Gets or sets the GemDetail value.
		/// </summary>
		public string GemDetail {
			get { return gemDetail; }
			set { gemDetail = value; }
		}
		
		/// <summary>
		/// Gets or sets the MetalDetail value.
		/// </summary>
		public string MetalDetail {
			get { return metalDetail; }
			set { metalDetail = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemCategory_ID value.
		/// </summary>
		public string ItemCategory_ID {
			get { return itemCategory_ID; }
			set { itemCategory_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemClass_ID value.
		/// </summary>
		public string ItemClass_ID {
			get { return itemClass_ID; }
			set { itemClass_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemType_ID value.
		/// </summary>
		public string ItemType_ID {
			get { return itemType_ID; }
			set { itemType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Weight value.
		/// </summary>
		public decimal Weight {
			get { return weight; }
			set { weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the SellingPrice value.
		/// </summary>
		public decimal SellingPrice {
			get { return sellingPrice; }
			set { sellingPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the CostPrice value.
		/// </summary>
		public decimal CostPrice {
			get { return costPrice; }
			set { costPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the AverageWeightFrom value.
		/// </summary>
		public decimal AverageWeightFrom {
			get { return averageWeightFrom; }
			set { averageWeightFrom = value; }
		}
		
		/// <summary>
		/// Gets or sets the AverageWeightTo value.
		/// </summary>
		public decimal AverageWeightTo {
			get { return averageWeightTo; }
			set { averageWeightTo = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsManufacture value.
		/// </summary>
		public bool IsManufacture {
			get { return isManufacture; }
			set { isManufacture = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsBuyingAndSelling value.
		/// </summary>
		public bool IsBuyingAndSelling {
			get { return isBuyingAndSelling; }
			set { isBuyingAndSelling = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsOrdered value.
		/// </summary>
		public bool IsOrdered {
			get { return isOrdered; }
			set { isOrdered = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateUser_ID value.
		/// </summary>
		public string CreateUser_ID {
			get { return createUser_ID; }
			set { createUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedUser_ID value.
		/// </summary>
		public string ModifiedUser_ID {
			get { return modifiedUser_ID; }
			set { modifiedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeletedUser_ID value.
		/// </summary>
		public string DeletedUser_ID {
			get { return deletedUser_ID; }
			set { deletedUser_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CreateTerminal_ID value.
		/// </summary>
		public string CreateTerminal_ID {
			get { return createTerminal_ID; }
			set { createTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ModifiedTerminal_ID value.
		/// </summary>
		public string ModifiedTerminal_ID {
			get { return modifiedTerminal_ID; }
			set { modifiedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeletedTerminal_ID value.
		/// </summary>
		public string DeletedTerminal_ID {
			get { return deletedTerminal_ID; }
			set { deletedTerminal_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateCreate value.
		/// </summary>
		public DateTime DateCreate {
			get { return dateCreate; }
			set { dateCreate = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateModified value.
		/// </summary>
		public DateTime DateModified {
			get { return dateModified; }
			set { dateModified = value; }
		}
		
		/// <summary>
		/// Gets or sets the DateDeleted value.
		/// </summary>
		public DateTime DateDeleted {
			get { return dateDeleted; }
			set { dateDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remarks value.
		/// </summary>
		public string Remarks {
			get { return remarks; }
			set { remarks = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsRepaire value.
		/// </summary>
		public bool IsRepaire {
			get { return isRepaire; }
			set { isRepaire = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_sasCustomerOrder_Gem table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_GemInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@description", SqlDbType.VarChar,100);
			scom.Parameters.Add("@refNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemLength", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSize", SqlDbType.VarChar,50);
			scom.Parameters.Add("@imagePath1", SqlDbType.VarChar,200);
			scom.Parameters.Add("@imagePath2", SqlDbType.VarChar,200);
			scom.Parameters.Add("@imagePath3", SqlDbType.VarChar,200);
			scom.Parameters.Add("@gemDetail", SqlDbType.VarChar,50);
			scom.Parameters.Add("@metalDetail", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@averageWeightFrom", SqlDbType.Decimal,9);
			scom.Parameters.Add("@averageWeightTo", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isManufacture", SqlDbType.Bit,1);
			scom.Parameters.Add("@isBuyingAndSelling", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOrdered", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,500);
			scom.Parameters.Add("@isRepaire", SqlDbType.Bit,1);
 
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemDate"].Value = itemDate;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@refNo"].Value = refNo;
			scom.Parameters["@itemLength"].Value = itemLength;
			scom.Parameters["@itemSize"].Value = itemSize;
			scom.Parameters["@imagePath1"].Value = imagePath1;
			scom.Parameters["@imagePath2"].Value = imagePath2;
			scom.Parameters["@imagePath3"].Value = imagePath3;
			scom.Parameters["@gemDetail"].Value = gemDetail;
			scom.Parameters["@metalDetail"].Value = metalDetail;
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
			scom.Parameters["@itemClass_ID"].Value = itemClass_ID;
			scom.Parameters["@itemType_ID"].Value = itemType_ID;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@sellingPrice"].Value = sellingPrice;
			scom.Parameters["@costPrice"].Value = costPrice;
			scom.Parameters["@averageWeightFrom"].Value = averageWeightFrom;
			scom.Parameters["@averageWeightTo"].Value = averageWeightTo;
			scom.Parameters["@isManufacture"].Value = isManufacture;
			scom.Parameters["@isBuyingAndSelling"].Value = isBuyingAndSelling;
			scom.Parameters["@isOrdered"].Value = isOrdered;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@isRepaire"].Value = isRepaire;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_sasCustomerOrder_Gem table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_GemUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@description", SqlDbType.VarChar,100);
			scom.Parameters.Add("@refNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemLength", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSize", SqlDbType.VarChar,50);
			scom.Parameters.Add("@imagePath1", SqlDbType.VarChar,200);
			scom.Parameters.Add("@imagePath2", SqlDbType.VarChar,200);
			scom.Parameters.Add("@imagePath3", SqlDbType.VarChar,200);
			scom.Parameters.Add("@gemDetail", SqlDbType.VarChar,50);
			scom.Parameters.Add("@metalDetail", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@costPrice", SqlDbType.Decimal,9);
			scom.Parameters.Add("@averageWeightFrom", SqlDbType.Decimal,9);
			scom.Parameters.Add("@averageWeightTo", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isManufacture", SqlDbType.Bit,1);
			scom.Parameters.Add("@isBuyingAndSelling", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOrdered", SqlDbType.Bit,1);
			scom.Parameters.Add("@createUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@modifiedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@deletedUser_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@createTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@modifiedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@deletedTerminal_ID", SqlDbType.VarChar,50);
			scom.Parameters.Add("@dateCreate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateModified", SqlDbType.DateTime,8);
			scom.Parameters.Add("@dateDeleted", SqlDbType.DateTime,8);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@remarks", SqlDbType.VarChar,500);
			scom.Parameters.Add("@isRepaire", SqlDbType.Bit,1);
 
 
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemDate"].Value = itemDate;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@refNo"].Value = refNo;
			scom.Parameters["@itemLength"].Value = itemLength;
			scom.Parameters["@itemSize"].Value = itemSize;
			scom.Parameters["@imagePath1"].Value = imagePath1;
			scom.Parameters["@imagePath2"].Value = imagePath2;
			scom.Parameters["@imagePath3"].Value = imagePath3;
			scom.Parameters["@gemDetail"].Value = gemDetail;
			scom.Parameters["@metalDetail"].Value = metalDetail;
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
			scom.Parameters["@itemClass_ID"].Value = itemClass_ID;
			scom.Parameters["@itemType_ID"].Value = itemType_ID;
			scom.Parameters["@weight"].Value = weight;
			scom.Parameters["@sellingPrice"].Value = sellingPrice;
			scom.Parameters["@costPrice"].Value = costPrice;
			scom.Parameters["@averageWeightFrom"].Value = averageWeightFrom;
			scom.Parameters["@averageWeightTo"].Value = averageWeightTo;
			scom.Parameters["@isManufacture"].Value = isManufacture;
			scom.Parameters["@isBuyingAndSelling"].Value = isBuyingAndSelling;
			scom.Parameters["@isOrdered"].Value = isOrdered;
			scom.Parameters["@createUser_ID"].Value = createUser_ID;
			scom.Parameters["@modifiedUser_ID"].Value = modifiedUser_ID;
			scom.Parameters["@deletedUser_ID"].Value = deletedUser_ID;
			scom.Parameters["@createTerminal_ID"].Value = createTerminal_ID;
			scom.Parameters["@modifiedTerminal_ID"].Value = modifiedTerminal_ID;
			scom.Parameters["@deletedTerminal_ID"].Value = deletedTerminal_ID;
			scom.Parameters["@dateCreate"].Value = dateCreate;
			scom.Parameters["@dateModified"].Value = dateModified;
			scom.Parameters["@dateDeleted"].Value = dateDeleted;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@remarks"].Value = remarks;
			scom.Parameters["@isRepaire"].Value = isRepaire;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_sasCustomerOrder_Gem table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_GemDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Gem table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_GemDeleteAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_sasCustomerOrder_Gem table.
		/// </summary>
		public static tbl_sasCustomerOrder_Gem Select(string customerOrder_ID_Incoming, string item_ID_Incoming){

			tbl_sasCustomerOrder_Gem tbl_sasCustomerOrder_Gemins = new tbl_sasCustomerOrder_Gem();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_GemSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_sasCustomerOrder_Gemins = Maketbl_sasCustomerOrder_Gem(dataReader);
				} else {
					tbl_sasCustomerOrder_Gemins = null;
				}
			}
			scon.Close();
			return tbl_sasCustomerOrder_Gemins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Gem table.
		/// </summary>
		public static List<tbl_sasCustomerOrder_Gem> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_GemSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_sasCustomerOrder_Gem> tbl_sasCustomerOrder_GemList = new List<tbl_sasCustomerOrder_Gem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasCustomerOrder_Gem tbl_sasCustomerOrder_Gem = Maketbl_sasCustomerOrder_Gem(dataReader);
					tbl_sasCustomerOrder_GemList.Add(tbl_sasCustomerOrder_Gem);
				}
			}
			scon.Close();
			return tbl_sasCustomerOrder_GemList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_sasCustomerOrder_Gem table by a foreign key.
		/// </summary>
		public static List<tbl_sasCustomerOrder_Gem> SelectAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_sasCustomerOrder_GemSelectAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
				List<tbl_sasCustomerOrder_Gem> tbl_sasCustomerOrder_GemList = new List<tbl_sasCustomerOrder_Gem>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_sasCustomerOrder_Gem tbl_sasCustomerOrder_Gem = Maketbl_sasCustomerOrder_Gem(dataReader);
					tbl_sasCustomerOrder_GemList.Add(tbl_sasCustomerOrder_Gem);
				}
			}
			scon.Close();
			return tbl_sasCustomerOrder_GemList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_sasCustomerOrder_Gem class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_sasCustomerOrder_Gem Maketbl_sasCustomerOrder_Gem(SqlDataReader dataReader) {
			tbl_sasCustomerOrder_Gem tbl_sasCustomerOrder_Gem = new tbl_sasCustomerOrder_Gem();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_sasCustomerOrder_Gem.CustomerOrder_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_sasCustomerOrder_Gem.Item_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_sasCustomerOrder_Gem.ItemDate = dataReader.GetDateTime(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_sasCustomerOrder_Gem.Description = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_sasCustomerOrder_Gem.RefNo = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_sasCustomerOrder_Gem.ItemLength = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_sasCustomerOrder_Gem.ItemSize = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_sasCustomerOrder_Gem.ImagePath1 = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_sasCustomerOrder_Gem.ImagePath2 = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_sasCustomerOrder_Gem.ImagePath3 = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_sasCustomerOrder_Gem.GemDetail = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_sasCustomerOrder_Gem.MetalDetail = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_sasCustomerOrder_Gem.ItemCategory_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_sasCustomerOrder_Gem.ItemClass_ID = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_sasCustomerOrder_Gem.ItemType_ID = dataReader.GetString(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_sasCustomerOrder_Gem.Weight = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_sasCustomerOrder_Gem.SellingPrice = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_sasCustomerOrder_Gem.CostPrice = dataReader.GetDecimal(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_sasCustomerOrder_Gem.AverageWeightFrom = dataReader.GetDecimal(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_sasCustomerOrder_Gem.AverageWeightTo = dataReader.GetDecimal(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_sasCustomerOrder_Gem.IsManufacture = dataReader.GetBoolean(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_sasCustomerOrder_Gem.IsBuyingAndSelling = dataReader.GetBoolean(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_sasCustomerOrder_Gem.IsOrdered = dataReader.GetBoolean(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_sasCustomerOrder_Gem.CreateUser_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_sasCustomerOrder_Gem.ModifiedUser_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_sasCustomerOrder_Gem.DeletedUser_ID = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_sasCustomerOrder_Gem.CreateTerminal_ID = dataReader.GetString(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_sasCustomerOrder_Gem.ModifiedTerminal_ID = dataReader.GetString(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_sasCustomerOrder_Gem.DeletedTerminal_ID = dataReader.GetString(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_sasCustomerOrder_Gem.DateCreate = dataReader.GetDateTime(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_sasCustomerOrder_Gem.DateModified = dataReader.GetDateTime(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_sasCustomerOrder_Gem.DateDeleted = dataReader.GetDateTime(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_sasCustomerOrder_Gem.IsDeleted = dataReader.GetBoolean(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_sasCustomerOrder_Gem.Remarks = dataReader.GetString(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_sasCustomerOrder_Gem.IsRepaire = dataReader.GetBoolean(34);
			}

			return tbl_sasCustomerOrder_Gem;
		}
		/// <summary>
		/// This makes tbl_sasCustomerOrder_Gem datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_sasCustomerOrder_Gem object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_sasCustomerOrder_Gem  tbl_sasCustomerOrder_Gem   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemDate = new DataColumn("itemDate" , typeof(DateTime));
			DataColumn col_description = new DataColumn("description" , typeof(string));
			DataColumn col_refNo = new DataColumn("refNo" , typeof(string));
			DataColumn col_itemLength = new DataColumn("itemLength" , typeof(string));
			DataColumn col_itemSize = new DataColumn("itemSize" , typeof(string));
			DataColumn col_imagePath1 = new DataColumn("imagePath1" , typeof(string));
			DataColumn col_imagePath2 = new DataColumn("imagePath2" , typeof(string));
			DataColumn col_imagePath3 = new DataColumn("imagePath3" , typeof(string));
			DataColumn col_gemDetail = new DataColumn("gemDetail" , typeof(string));
			DataColumn col_metalDetail = new DataColumn("metalDetail" , typeof(string));
			DataColumn col_itemCategory_ID = new DataColumn("itemCategory_ID" , typeof(string));
			DataColumn col_itemClass_ID = new DataColumn("itemClass_ID" , typeof(string));
			DataColumn col_itemType_ID = new DataColumn("itemType_ID" , typeof(string));
			DataColumn col_weight = new DataColumn("weight" , typeof(decimal));
			DataColumn col_sellingPrice = new DataColumn("sellingPrice" , typeof(decimal));
			DataColumn col_costPrice = new DataColumn("costPrice" , typeof(decimal));
			DataColumn col_averageWeightFrom = new DataColumn("averageWeightFrom" , typeof(decimal));
			DataColumn col_averageWeightTo = new DataColumn("averageWeightTo" , typeof(decimal));
			DataColumn col_isManufacture = new DataColumn("isManufacture" , typeof(bool));
			DataColumn col_isBuyingAndSelling = new DataColumn("isBuyingAndSelling" , typeof(bool));
			DataColumn col_isOrdered = new DataColumn("isOrdered" , typeof(bool));
			DataColumn col_createUser_ID = new DataColumn("createUser_ID" , typeof(string));
			DataColumn col_modifiedUser_ID = new DataColumn("modifiedUser_ID" , typeof(string));
			DataColumn col_deletedUser_ID = new DataColumn("deletedUser_ID" , typeof(string));
			DataColumn col_createTerminal_ID = new DataColumn("createTerminal_ID" , typeof(string));
			DataColumn col_modifiedTerminal_ID = new DataColumn("modifiedTerminal_ID" , typeof(string));
			DataColumn col_deletedTerminal_ID = new DataColumn("deletedTerminal_ID" , typeof(string));
			DataColumn col_dateCreate = new DataColumn("dateCreate" , typeof(DateTime));
			DataColumn col_dateModified = new DataColumn("dateModified" , typeof(DateTime));
			DataColumn col_dateDeleted = new DataColumn("dateDeleted" , typeof(DateTime));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_remarks = new DataColumn("remarks" , typeof(string));
			DataColumn col_isRepaire = new DataColumn("isRepaire" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_customerOrder_ID,col_item_ID,col_itemDate,col_description,col_refNo,col_itemLength,col_itemSize,col_imagePath1,col_imagePath2,col_imagePath3,col_gemDetail,col_metalDetail,col_itemCategory_ID,col_itemClass_ID,col_itemType_ID,col_weight,col_sellingPrice,col_costPrice,col_averageWeightFrom,col_averageWeightTo,col_isManufacture,col_isBuyingAndSelling,col_isOrdered,col_createUser_ID,col_modifiedUser_ID,col_deletedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_dateCreate,col_dateModified,col_dateDeleted,col_isDeleted,col_remarks,col_isRepaire,});		return dt;
		}
		/// <summary>
		/// This fills tbl_sasCustomerOrder_Gem datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_sasCustomerOrder_Gem object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_sasCustomerOrder_Gem user) {
		DataRow drow = dt.NewRow();
		
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemDate"] = user.itemDate;
			drow["description"] = user.description;
			drow["refNo"] = user.refNo;
			drow["itemLength"] = user.itemLength;
			drow["itemSize"] = user.itemSize;
			drow["imagePath1"] = user.imagePath1;
			drow["imagePath2"] = user.imagePath2;
			drow["imagePath3"] = user.imagePath3;
			drow["gemDetail"] = user.gemDetail;
			drow["metalDetail"] = user.metalDetail;
			drow["itemCategory_ID"] = user.itemCategory_ID;
			drow["itemClass_ID"] = user.itemClass_ID;
			drow["itemType_ID"] = user.itemType_ID;
			drow["weight"] = user.weight;
			drow["sellingPrice"] = user.sellingPrice;
			drow["costPrice"] = user.costPrice;
			drow["averageWeightFrom"] = user.averageWeightFrom;
			drow["averageWeightTo"] = user.averageWeightTo;
			drow["isManufacture"] = user.isManufacture;
			drow["isBuyingAndSelling"] = user.isBuyingAndSelling;
			drow["isOrdered"] = user.isOrdered;
			drow["createUser_ID"] = user.createUser_ID;
			drow["modifiedUser_ID"] = user.modifiedUser_ID;
			drow["deletedUser_ID"] = user.deletedUser_ID;
			drow["createTerminal_ID"] = user.createTerminal_ID;
			drow["modifiedTerminal_ID"] = user.modifiedTerminal_ID;
			drow["deletedTerminal_ID"] = user.deletedTerminal_ID;
			drow["dateCreate"] = user.dateCreate;
			drow["dateModified"] = user.dateModified;
			drow["dateDeleted"] = user.dateDeleted;
			drow["isDeleted"] = user.isDeleted;
			drow["remarks"] = user.remarks;
			drow["isRepaire"] = user.isRepaire;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
