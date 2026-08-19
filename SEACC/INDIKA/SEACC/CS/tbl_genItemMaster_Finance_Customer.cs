using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genItemMaster_Finance_Customer {
		#region Fields
		private string customer_ID;
		private string branch_ID;
		private string item_ID;
		private string itemSubCategory_ID;
		private string itemSubCategory2_ID;
		private string itemSerialNo;
		private string itemSerialNo2;
		private decimal sellingPrice1;
		private decimal sellingPrice2;
		private bool isVATinclusive;
		private bool isNBTinclusive;
		private int sortOrder;
		private string pluCode;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_Finance_Customer class.
		/// </summary>
		public tbl_genItemMaster_Finance_Customer() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_Finance_Customer class.
		/// </summary>
		public tbl_genItemMaster_Finance_Customer(string customer_ID, string branch_ID, string item_ID, string itemSubCategory_ID, string itemSubCategory2_ID, string itemSerialNo, string itemSerialNo2, decimal sellingPrice1, decimal sellingPrice2, bool isVATinclusive, bool isNBTinclusive, int sortOrder, string pluCode) {
			this.customer_ID = customer_ID;
			this.branch_ID = branch_ID;
			this.item_ID = item_ID;
			this.itemSubCategory_ID = itemSubCategory_ID;
			this.itemSubCategory2_ID = itemSubCategory2_ID;
			this.itemSerialNo = itemSerialNo;
			this.itemSerialNo2 = itemSerialNo2;
			this.sellingPrice1 = sellingPrice1;
			this.sellingPrice2 = sellingPrice2;
			this.isVATinclusive = isVATinclusive;
			this.isNBTinclusive = isNBTinclusive;
			this.sortOrder = sortOrder;
			this.pluCode = pluCode;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Branch_ID value.
		/// </summary>
		public string Branch_ID {
			get { return branch_ID; }
			set { branch_ID = value; }
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
		
		/// <summary>
		/// Gets or sets the SortOrder value.
		/// </summary>
		public int SortOrder {
			get { return sortOrder; }
			set { sortOrder = value; }
		}
		
		/// <summary>
		/// Gets or sets the PluCode value.
		/// </summary>
		public string PluCode {
			get { return pluCode; }
			set { pluCode = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genItemMaster_Finance_Customer table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Finance_CustomerInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@sellingPrice1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isVATinclusive", SqlDbType.Bit,1);
			scom.Parameters.Add("@isNBTinclusive", SqlDbType.Bit,1);
			scom.Parameters.Add("@sortOrder", SqlDbType.Int,4);
			scom.Parameters.Add("@pluCode", SqlDbType.VarChar,50);
 
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@sellingPrice1"].Value = sellingPrice1;
			scom.Parameters["@sellingPrice2"].Value = sellingPrice2;
			scom.Parameters["@isVATinclusive"].Value = isVATinclusive;
			scom.Parameters["@isNBTinclusive"].Value = isNBTinclusive;
			scom.Parameters["@sortOrder"].Value = sortOrder;
			scom.Parameters["@pluCode"].Value = pluCode;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genItemMaster_Finance_Customer table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Finance_CustomerUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters.Add("@sellingPrice1", SqlDbType.Decimal,9);
			scom.Parameters.Add("@sellingPrice2", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isVATinclusive", SqlDbType.Bit,1);
			scom.Parameters.Add("@isNBTinclusive", SqlDbType.Bit,1);
			scom.Parameters.Add("@sortOrder", SqlDbType.Int,4);
			scom.Parameters.Add("@pluCode", SqlDbType.VarChar,50);
 
 
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@branch_ID"].Value = branch_ID;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2;
			scom.Parameters["@sellingPrice1"].Value = sellingPrice1;
			scom.Parameters["@sellingPrice2"].Value = sellingPrice2;
			scom.Parameters["@isVATinclusive"].Value = isVATinclusive;
			scom.Parameters["@isNBTinclusive"].Value = isNBTinclusive;
			scom.Parameters["@sortOrder"].Value = sortOrder;
			scom.Parameters["@pluCode"].Value = pluCode;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genItemMaster_Finance_Customer table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Finance_CustomerDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scom.Parameters["@branch_ID"].Value = branch_ID;
 
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
		/// Selects all records from the tbl_genItemMaster_Finance_Customer table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Finance_CustomerDeleteAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Finance_Customer table by a foreign key.
		/// </summary>
		public static void DeleteAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Finance_CustomerDeleteAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Finance_Customer table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Finance_CustomerDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genItemMaster_Finance_Customer table.
		/// </summary>
		public static tbl_genItemMaster_Finance_Customer Select(string customer_ID_Incoming, string branch_ID_Incoming, string item_ID_Incoming, string itemSubCategory_ID_Incoming, string itemSubCategory2_ID_Incoming, string itemSerialNo_Incoming, string itemSerialNo2_Incoming){

			tbl_genItemMaster_Finance_Customer tbl_genItemMaster_Finance_Customerins = new tbl_genItemMaster_Finance_Customer();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Finance_CustomerSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@branch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemSerialNo", SqlDbType.VarChar,50);
			scom.Parameters.Add("@itemSerialNo2", SqlDbType.VarChar,50);
			scom.Parameters["@customer_ID"].Value = customer_ID_Incoming;
			scom.Parameters["@branch_ID"].Value = branch_ID_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID_Incoming;
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID_Incoming;
			scom.Parameters["@itemSerialNo"].Value = itemSerialNo_Incoming;
			scom.Parameters["@itemSerialNo2"].Value = itemSerialNo2_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItemMaster_Finance_Customerins = Maketbl_genItemMaster_Finance_Customer(dataReader);
				} else {
					tbl_genItemMaster_Finance_Customerins = null;
				}
			}
			scon.Close();
			return tbl_genItemMaster_Finance_Customerins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Finance_Customer table.
		/// </summary>
		public static List<tbl_genItemMaster_Finance_Customer> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Finance_CustomerSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItemMaster_Finance_Customer> tbl_genItemMaster_Finance_CustomerList = new List<tbl_genItemMaster_Finance_Customer>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Finance_Customer tbl_genItemMaster_Finance_Customer = Maketbl_genItemMaster_Finance_Customer(dataReader);
					tbl_genItemMaster_Finance_CustomerList.Add(tbl_genItemMaster_Finance_Customer);
				}
			}
			scon.Close();
			return tbl_genItemMaster_Finance_CustomerList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Finance_Customer table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_Finance_Customer> SelectAllByItemSubCategory2_ID(string itemSubCategory2_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Finance_CustomerSelectAllByItemSubCategory2_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory2_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory2_ID"].Value = itemSubCategory2_ID;
				List<tbl_genItemMaster_Finance_Customer> tbl_genItemMaster_Finance_CustomerList = new List<tbl_genItemMaster_Finance_Customer>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Finance_Customer tbl_genItemMaster_Finance_Customer = Maketbl_genItemMaster_Finance_Customer(dataReader);
					tbl_genItemMaster_Finance_CustomerList.Add(tbl_genItemMaster_Finance_Customer);
				}
			}
			scon.Close();
			return tbl_genItemMaster_Finance_CustomerList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Finance_Customer table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_Finance_Customer> SelectAllByItemSubCategory_ID(string itemSubCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Finance_CustomerSelectAllByItemSubCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemSubCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemSubCategory_ID"].Value = itemSubCategory_ID;
				List<tbl_genItemMaster_Finance_Customer> tbl_genItemMaster_Finance_CustomerList = new List<tbl_genItemMaster_Finance_Customer>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Finance_Customer tbl_genItemMaster_Finance_Customer = Maketbl_genItemMaster_Finance_Customer(dataReader);
					tbl_genItemMaster_Finance_CustomerList.Add(tbl_genItemMaster_Finance_Customer);
				}
			}
			scon.Close();
			return tbl_genItemMaster_Finance_CustomerList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_Finance_Customer table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_Finance_Customer> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_Finance_CustomerSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_genItemMaster_Finance_Customer> tbl_genItemMaster_Finance_CustomerList = new List<tbl_genItemMaster_Finance_Customer>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_Finance_Customer tbl_genItemMaster_Finance_Customer = Maketbl_genItemMaster_Finance_Customer(dataReader);
					tbl_genItemMaster_Finance_CustomerList.Add(tbl_genItemMaster_Finance_Customer);
				}
			}
			scon.Close();
			return tbl_genItemMaster_Finance_CustomerList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genItemMaster_Finance_Customer class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItemMaster_Finance_Customer Maketbl_genItemMaster_Finance_Customer(SqlDataReader dataReader) {
			tbl_genItemMaster_Finance_Customer tbl_genItemMaster_Finance_Customer = new tbl_genItemMaster_Finance_Customer();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItemMaster_Finance_Customer.Customer_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItemMaster_Finance_Customer.Branch_ID = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genItemMaster_Finance_Customer.Item_ID = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genItemMaster_Finance_Customer.ItemSubCategory_ID = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genItemMaster_Finance_Customer.ItemSubCategory2_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genItemMaster_Finance_Customer.ItemSerialNo = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genItemMaster_Finance_Customer.ItemSerialNo2 = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genItemMaster_Finance_Customer.SellingPrice1 = dataReader.GetDecimal(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genItemMaster_Finance_Customer.SellingPrice2 = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genItemMaster_Finance_Customer.IsVATinclusive = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genItemMaster_Finance_Customer.IsNBTinclusive = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genItemMaster_Finance_Customer.SortOrder = dataReader.GetInt32(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genItemMaster_Finance_Customer.PluCode = dataReader.GetString(12);
			}

			return tbl_genItemMaster_Finance_Customer;
		}
		/// <summary>
		/// This makes tbl_genItemMaster_Finance_Customer datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_Finance_Customer object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItemMaster_Finance_Customer  tbl_genItemMaster_Finance_Customer   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_branch_ID = new DataColumn("branch_ID" , typeof(string));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemSubCategory_ID = new DataColumn("itemSubCategory_ID" , typeof(string));
			DataColumn col_itemSubCategory2_ID = new DataColumn("itemSubCategory2_ID" , typeof(string));
			DataColumn col_itemSerialNo = new DataColumn("itemSerialNo" , typeof(string));
			DataColumn col_itemSerialNo2 = new DataColumn("itemSerialNo2" , typeof(string));
			DataColumn col_sellingPrice1 = new DataColumn("sellingPrice1" , typeof(decimal));
			DataColumn col_sellingPrice2 = new DataColumn("sellingPrice2" , typeof(decimal));
			DataColumn col_isVATinclusive = new DataColumn("isVATinclusive" , typeof(bool));
			DataColumn col_isNBTinclusive = new DataColumn("isNBTinclusive" , typeof(bool));
			DataColumn col_sortOrder = new DataColumn("sortOrder" , typeof(int));
			DataColumn col_pluCode = new DataColumn("pluCode" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_customer_ID,col_branch_ID,col_item_ID,col_itemSubCategory_ID,col_itemSubCategory2_ID,col_itemSerialNo,col_itemSerialNo2,col_sellingPrice1,col_sellingPrice2,col_isVATinclusive,col_isNBTinclusive,col_sortOrder,col_pluCode,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItemMaster_Finance_Customer datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_Finance_Customer object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItemMaster_Finance_Customer user) {
		DataRow drow = dt.NewRow();
		
			drow["customer_ID"] = user.customer_ID;
			drow["branch_ID"] = user.branch_ID;
			drow["item_ID"] = user.item_ID;
			drow["itemSubCategory_ID"] = user.itemSubCategory_ID;
			drow["itemSubCategory2_ID"] = user.itemSubCategory2_ID;
			drow["itemSerialNo"] = user.itemSerialNo;
			drow["itemSerialNo2"] = user.itemSerialNo2;
			drow["sellingPrice1"] = user.sellingPrice1;
			drow["sellingPrice2"] = user.sellingPrice2;
			drow["isVATinclusive"] = user.isVATinclusive;
			drow["isNBTinclusive"] = user.isNBTinclusive;
			drow["sortOrder"] = user.sortOrder;
			drow["pluCode"] = user.pluCode;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
