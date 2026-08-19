using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_zItemSerialNo {
		#region Fields
		private string itemSerialNo;
		private string item_ID;
		private string batchNo;
		private string customerOrder_ID;
		private string externalGoodReceivedNote_ID;
		private DateTime externalGoodReceivedNoteDate;
		private string description;
		private string refNo;
		private string itemLength;
		private string itemSize;
		private string gemDetail;
		private string metalDetail;
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
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_zItemSerialNo class.
		/// </summary>
		public tbl_zItemSerialNo() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_zItemSerialNo class.
		/// </summary>
		public tbl_zItemSerialNo(string itemSerialNo, string item_ID, string batchNo, string customerOrder_ID, string externalGoodReceivedNote_ID, DateTime externalGoodReceivedNoteDate, string description, string refNo, string itemLength, string itemSize, string gemDetail, string metalDetail, decimal weight, decimal sellingPrice, decimal costPrice, decimal averageWeightFrom, decimal averageWeightTo, bool isManufacture, bool isBuyingAndSelling, bool isOrdered, string createUser_ID, string modifiedUser_ID, string deletedUser_ID, string createTerminal_ID, string modifiedTerminal_ID, string deletedTerminal_ID, DateTime dateCreate, DateTime dateModified, DateTime dateDeleted, bool isDeleted) {
			this.itemSerialNo = itemSerialNo;
			this.item_ID = item_ID;
			this.batchNo = batchNo;
			this.customerOrder_ID = customerOrder_ID;
			this.externalGoodReceivedNote_ID = externalGoodReceivedNote_ID;
			this.externalGoodReceivedNoteDate = externalGoodReceivedNoteDate;
			this.description = description;
			this.refNo = refNo;
			this.itemLength = itemLength;
			this.itemSize = itemSize;
			this.gemDetail = gemDetail;
			this.metalDetail = metalDetail;
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
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the ItemSerialNo value.
		/// </summary>
		public string ItemSerialNo {
			get { return itemSerialNo; }
			set { itemSerialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the BatchNo value.
		/// </summary>
		public string BatchNo {
			get { return batchNo; }
			set { batchNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerOrder_ID value.
		/// </summary>
		public string CustomerOrder_ID {
			get { return customerOrder_ID; }
			set { customerOrder_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExternalGoodReceivedNote_ID value.
		/// </summary>
		public string ExternalGoodReceivedNote_ID {
			get { return externalGoodReceivedNote_ID; }
			set { externalGoodReceivedNote_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ExternalGoodReceivedNoteDate value.
		/// </summary>
		public DateTime ExternalGoodReceivedNoteDate {
			get { return externalGoodReceivedNoteDate; }
			set { externalGoodReceivedNoteDate = value; }
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
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_zItemSerialNo table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSerialNoInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batchNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@externalGoodReceivedNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@description", SqlDbType.VarChar,100);
			scom.Parameters.Add("@refNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemLength", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSize", SqlDbType.VarChar,50);
			scom.Parameters.Add("@gemDetail", SqlDbType.VarChar,50);
			scom.Parameters.Add("@metalDetail", SqlDbType.VarChar,50);
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
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@batchNo"].Value = batchNo;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@externalGoodReceivedNoteDate"].Value = externalGoodReceivedNoteDate;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@refNo"].Value = refNo;
			scom.Parameters["@itemLength"].Value = itemLength;
			scom.Parameters["@itemSize"].Value = itemSize;
			scom.Parameters["@gemDetail"].Value = gemDetail;
			scom.Parameters["@metalDetail"].Value = metalDetail;
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
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_zItemSerialNo table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSerialNoUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@batchNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@externalGoodReceivedNote_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@externalGoodReceivedNoteDate", SqlDbType.DateTime,8);
			scom.Parameters.Add("@description", SqlDbType.VarChar,100);
			scom.Parameters.Add("@refNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemLength", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSize", SqlDbType.VarChar,50);
			scom.Parameters.Add("@gemDetail", SqlDbType.VarChar,50);
			scom.Parameters.Add("@metalDetail", SqlDbType.VarChar,50);
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
 
 
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@batchNo"].Value = batchNo;
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
			scom.Parameters["@externalGoodReceivedNote_ID"].Value = externalGoodReceivedNote_ID;
			scom.Parameters["@externalGoodReceivedNoteDate"].Value = externalGoodReceivedNoteDate;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@refNo"].Value = refNo;
			scom.Parameters["@itemLength"].Value = itemLength;
			scom.Parameters["@itemSize"].Value = itemSize;
			scom.Parameters["@gemDetail"].Value = gemDetail;
			scom.Parameters["@metalDetail"].Value = metalDetail;
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
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_zItemSerialNo table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSerialNoDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemSerialNo table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSerialNoDeleteAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemSerialNo table by a foreign key.
		/// </summary>
		public static void DeleteAllByBatchNo(string batchNo) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSerialNoDeleteAllByBatchNo", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@batchNo", SqlDbType.VarChar,50);
			scom.Parameters["@batchNo"].Value = batchNo;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemSerialNo table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSerialNoDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_zItemSerialNo table.
		/// </summary>
		public static tbl_zItemSerialNo Select(string itemSerialNo_Incoming){

			tbl_zItemSerialNo tbl_zItemSerialNoins = new tbl_zItemSerialNo();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSerialNoSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_zItemSerialNoins = Maketbl_zItemSerialNo(dataReader);
				} else {
					tbl_zItemSerialNoins = null;
				}
			}
			scon.Close();
			return tbl_zItemSerialNoins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemSerialNo table.
		/// </summary>
		public static List<tbl_zItemSerialNo> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSerialNoSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_zItemSerialNo> tbl_zItemSerialNoList = new List<tbl_zItemSerialNo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemSerialNo tbl_zItemSerialNo = Maketbl_zItemSerialNo(dataReader);
					tbl_zItemSerialNoList.Add(tbl_zItemSerialNo);
				}
			}
			scon.Close();
			return tbl_zItemSerialNoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemSerialNo table by a foreign key.
		/// </summary>
		public static List<tbl_zItemSerialNo> SelectAllByCustomerOrder_ID(string customerOrder_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSerialNoSelectAllByCustomerOrder_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customerOrder_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customerOrder_ID"].Value = customerOrder_ID;
				List<tbl_zItemSerialNo> tbl_zItemSerialNoList = new List<tbl_zItemSerialNo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemSerialNo tbl_zItemSerialNo = Maketbl_zItemSerialNo(dataReader);
					tbl_zItemSerialNoList.Add(tbl_zItemSerialNo);
				}
			}
			scon.Close();
			return tbl_zItemSerialNoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemSerialNo table by a foreign key.
		/// </summary>
		public static List<tbl_zItemSerialNo> SelectAllByBatchNo(string batchNo) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSerialNoSelectAllByBatchNo", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@batchNo", SqlDbType.VarChar,50);
			scom.Parameters["@batchNo"].Value = batchNo;
				List<tbl_zItemSerialNo> tbl_zItemSerialNoList = new List<tbl_zItemSerialNo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemSerialNo tbl_zItemSerialNo = Maketbl_zItemSerialNo(dataReader);
					tbl_zItemSerialNoList.Add(tbl_zItemSerialNo);
				}
			}
			scon.Close();
			return tbl_zItemSerialNoList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_zItemSerialNo table by a foreign key.
		/// </summary>
		public static List<tbl_zItemSerialNo> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_zItemSerialNoSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_zItemSerialNo> tbl_zItemSerialNoList = new List<tbl_zItemSerialNo>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_zItemSerialNo tbl_zItemSerialNo = Maketbl_zItemSerialNo(dataReader);
					tbl_zItemSerialNoList.Add(tbl_zItemSerialNo);
				}
			}
			scon.Close();
			return tbl_zItemSerialNoList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_zItemSerialNo class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_zItemSerialNo Maketbl_zItemSerialNo(SqlDataReader dataReader) {
			tbl_zItemSerialNo tbl_zItemSerialNo = new tbl_zItemSerialNo();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_zItemSerialNo.ItemSerialNo = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_zItemSerialNo.Item_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_zItemSerialNo.BatchNo = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_zItemSerialNo.CustomerOrder_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_zItemSerialNo.ExternalGoodReceivedNote_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_zItemSerialNo.ExternalGoodReceivedNoteDate = dataReader.GetDateTime(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_zItemSerialNo.Description = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_zItemSerialNo.RefNo = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_zItemSerialNo.ItemLength = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_zItemSerialNo.ItemSize = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_zItemSerialNo.GemDetail = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_zItemSerialNo.MetalDetail = dataReader.GetString(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_zItemSerialNo.Weight = dataReader.GetDecimal(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_zItemSerialNo.SellingPrice = dataReader.GetDecimal(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_zItemSerialNo.CostPrice = dataReader.GetDecimal(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_zItemSerialNo.AverageWeightFrom = dataReader.GetDecimal(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_zItemSerialNo.AverageWeightTo = dataReader.GetDecimal(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_zItemSerialNo.IsManufacture = dataReader.GetBoolean(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_zItemSerialNo.IsBuyingAndSelling = dataReader.GetBoolean(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_zItemSerialNo.IsOrdered = dataReader.GetBoolean(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_zItemSerialNo.CreateUser_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_zItemSerialNo.ModifiedUser_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_zItemSerialNo.DeletedUser_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_zItemSerialNo.CreateTerminal_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_zItemSerialNo.ModifiedTerminal_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_zItemSerialNo.DeletedTerminal_ID = dataReader.GetString(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_zItemSerialNo.DateCreate = dataReader.GetDateTime(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_zItemSerialNo.DateModified = dataReader.GetDateTime(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_zItemSerialNo.DateDeleted = dataReader.GetDateTime(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_zItemSerialNo.IsDeleted = dataReader.GetBoolean(29);
			}

			return tbl_zItemSerialNo;
		}
		/// <summary>
		/// This makes tbl_zItemSerialNo datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_zItemSerialNo object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_zItemSerialNo  tbl_zItemSerialNo   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_batchNo = new DataColumn("batchNo" , typeof(string));
			DataColumn col_customerOrder_ID = new DataColumn("customerOrder_ID" , typeof(string));
			DataColumn col_externalGoodReceivedNote_ID = new DataColumn("externalGoodReceivedNote_ID" , typeof(string));
			DataColumn col_externalGoodReceivedNoteDate = new DataColumn("externalGoodReceivedNoteDate" , typeof(DateTime));
			DataColumn col_description = new DataColumn("description" , typeof(string));
			DataColumn col_refNo = new DataColumn("refNo" , typeof(string));
			DataColumn col_itemLength = new DataColumn("itemLength" , typeof(string));
			DataColumn col_itemSize = new DataColumn("itemSize" , typeof(string));
			DataColumn col_gemDetail = new DataColumn("gemDetail" , typeof(string));
			DataColumn col_metalDetail = new DataColumn("metalDetail" , typeof(string));
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
		dt.Columns.AddRange(new DataColumn[] { col_itemSerialNo,col_item_ID,col_batchNo,col_customerOrder_ID,col_externalGoodReceivedNote_ID,col_externalGoodReceivedNoteDate,col_description,col_refNo,col_itemLength,col_itemSize,col_gemDetail,col_metalDetail,col_weight,col_sellingPrice,col_costPrice,col_averageWeightFrom,col_averageWeightTo,col_isManufacture,col_isBuyingAndSelling,col_isOrdered,col_createUser_ID,col_modifiedUser_ID,col_deletedUser_ID,col_createTerminal_ID,col_modifiedTerminal_ID,col_deletedTerminal_ID,col_dateCreate,col_dateModified,col_dateDeleted,col_isDeleted,});		return dt;
		}
		/// <summary>
		/// This fills tbl_zItemSerialNo datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_zItemSerialNo object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_zItemSerialNo user) {
		DataRow drow = dt.NewRow();
		
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["item_ID"] = user.item_ID;
			drow["batchNo"] = user.batchNo;
			drow["customerOrder_ID"] = user.customerOrder_ID;
			drow["externalGoodReceivedNote_ID"] = user.externalGoodReceivedNote_ID;
			drow["externalGoodReceivedNoteDate"] = user.externalGoodReceivedNoteDate;
			drow["description"] = user.description;
			drow["refNo"] = user.refNo;
			drow["itemLength"] = user.itemLength;
			drow["itemSize"] = user.itemSize;
			drow["gemDetail"] = user.gemDetail;
			drow["metalDetail"] = user.metalDetail;
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
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
