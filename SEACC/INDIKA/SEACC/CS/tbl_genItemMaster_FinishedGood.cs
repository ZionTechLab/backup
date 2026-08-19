using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genItemMaster_FinishedGood {
		#region Fields
		private decimal width;
		private decimal height;
		private decimal thickness;
		private decimal gusset;
		private string customer_ID;
		private string brand_ID;
		private string polytheneType_ID;
		private string sealingType_ID;
		private bool isPrinted;
		private string item_ID;
		private string itemName;
		private bool isCustomerWise;
		private bool isBrandWise;
		private bool isCommercial;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_FinishedGood class.
		/// </summary>
		public tbl_genItemMaster_FinishedGood() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_FinishedGood class.
		/// </summary>
		public tbl_genItemMaster_FinishedGood(decimal width, decimal height, decimal thickness, decimal gusset, string customer_ID, string brand_ID, string polytheneType_ID, string sealingType_ID, bool isPrinted, string item_ID, string itemName, bool isCustomerWise, bool isBrandWise, bool isCommercial) {
			this.width = width;
			this.height = height;
			this.thickness = thickness;
			this.gusset = gusset;
			this.customer_ID = customer_ID;
			this.brand_ID = brand_ID;
			this.polytheneType_ID = polytheneType_ID;
			this.sealingType_ID = sealingType_ID;
			this.isPrinted = isPrinted;
			this.item_ID = item_ID;
			this.itemName = itemName;
			this.isCustomerWise = isCustomerWise;
			this.isBrandWise = isBrandWise;
			this.isCommercial = isCommercial;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the Width value.
		/// </summary>
		public decimal Width {
			get { return width; }
			set { width = value; }
		}
		
		/// <summary>
		/// Gets or sets the Height value.
		/// </summary>
		public decimal Height {
			get { return height; }
			set { height = value; }
		}
		
		/// <summary>
		/// Gets or sets the Thickness value.
		/// </summary>
		public decimal Thickness {
			get { return thickness; }
			set { thickness = value; }
		}
		
		/// <summary>
		/// Gets or sets the Gusset value.
		/// </summary>
		public decimal Gusset {
			get { return gusset; }
			set { gusset = value; }
		}
		
		/// <summary>
		/// Gets or sets the Customer_ID value.
		/// </summary>
		public string Customer_ID {
			get { return customer_ID; }
			set { customer_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Brand_ID value.
		/// </summary>
		public string Brand_ID {
			get { return brand_ID; }
			set { brand_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the PolytheneType_ID value.
		/// </summary>
		public string PolytheneType_ID {
			get { return polytheneType_ID; }
			set { polytheneType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SealingType_ID value.
		/// </summary>
		public string SealingType_ID {
			get { return sealingType_ID; }
			set { sealingType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPrinted value.
		/// </summary>
		public bool IsPrinted {
			get { return isPrinted; }
			set { isPrinted = value; }
		}
		
		/// <summary>
		/// Gets or sets the Item_ID value.
		/// </summary>
		public string Item_ID {
			get { return item_ID; }
			set { item_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemName value.
		/// </summary>
		public string ItemName {
			get { return itemName; }
			set { itemName = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCustomerWise value.
		/// </summary>
		public bool IsCustomerWise {
			get { return isCustomerWise; }
			set { isCustomerWise = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsBrandWise value.
		/// </summary>
		public bool IsBrandWise {
			get { return isBrandWise; }
			set { isBrandWise = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCommercial value.
		/// </summary>
		public bool IsCommercial {
			get { return isCommercial; }
			set { isCommercial = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genItemMaster_FinishedGood table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGoodInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gusset", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sealingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isCustomerWise", SqlDbType.Bit,1);
			scom.Parameters.Add("@isBrandWise", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCommercial", SqlDbType.Bit,1);
 
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@height"].Value = height;
			scom.Parameters["@thickness"].Value = thickness;
			scom.Parameters["@gusset"].Value = gusset;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@brand_ID"].Value = brand_ID;
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
			scom.Parameters["@sealingType_ID"].Value = sealingType_ID;
			scom.Parameters["@isPrinted"].Value = isPrinted;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@isCustomerWise"].Value = isCustomerWise;
			scom.Parameters["@isBrandWise"].Value = isBrandWise;
			scom.Parameters["@isCommercial"].Value = isCommercial;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genItemMaster_FinishedGood table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGoodUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gusset", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sealingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isCustomerWise", SqlDbType.Bit,1);
			scom.Parameters.Add("@isBrandWise", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCommercial", SqlDbType.Bit,1);
 
 
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@height"].Value = height;
			scom.Parameters["@thickness"].Value = thickness;
			scom.Parameters["@gusset"].Value = gusset;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@brand_ID"].Value = brand_ID;
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
			scom.Parameters["@sealingType_ID"].Value = sealingType_ID;
			scom.Parameters["@isPrinted"].Value = isPrinted;
			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@isCustomerWise"].Value = isCustomerWise;
			scom.Parameters["@isBrandWise"].Value = isBrandWise;
			scom.Parameters["@isCommercial"].Value = isCommercial;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_genItemMaster_FinishedGood table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGoodDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood table by a foreign key.
		/// </summary>
		public static void DeleteAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGoodDeleteAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood table by a foreign key.
		/// </summary>
		public static void DeleteAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGoodDeleteAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood table by a foreign key.
		/// </summary>
		public static void DeleteAllBySealingType_ID(string sealingType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGoodDeleteAllBySealingType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sealingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@sealingType_ID"].Value = sealingType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood table by a foreign key.
		/// </summary>
		public static void DeleteAllByBrand_ID(string brand_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGoodDeleteAllByBrand_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters["@brand_ID"].Value = brand_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood table by a foreign key.
		/// </summary>
		public static void DeleteAllByPolytheneType_ID(string polytheneType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGoodDeleteAllByPolytheneType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genItemMaster_FinishedGood table.
		/// </summary>
		public static tbl_genItemMaster_FinishedGood Select(string item_ID_Incoming){

			tbl_genItemMaster_FinishedGood tbl_genItemMaster_FinishedGoodins = new tbl_genItemMaster_FinishedGood();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGoodSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItemMaster_FinishedGoodins = Maketbl_genItemMaster_FinishedGood(dataReader);
				} else {
					tbl_genItemMaster_FinishedGoodins = null;
				}
			}
			scon.Close();
			return tbl_genItemMaster_FinishedGoodins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood table.
		/// </summary>
		public static List<tbl_genItemMaster_FinishedGood> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGoodSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItemMaster_FinishedGood> tbl_genItemMaster_FinishedGoodList = new List<tbl_genItemMaster_FinishedGood>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_FinishedGood tbl_genItemMaster_FinishedGood = Maketbl_genItemMaster_FinishedGood(dataReader);
					tbl_genItemMaster_FinishedGoodList.Add(tbl_genItemMaster_FinishedGood);
				}
			}
			scon.Close();
			return tbl_genItemMaster_FinishedGoodList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_FinishedGood> SelectAllByCustomer_ID(string customer_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGoodSelectAllByCustomer_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters["@customer_ID"].Value = customer_ID;
				List<tbl_genItemMaster_FinishedGood> tbl_genItemMaster_FinishedGoodList = new List<tbl_genItemMaster_FinishedGood>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_FinishedGood tbl_genItemMaster_FinishedGood = Maketbl_genItemMaster_FinishedGood(dataReader);
					tbl_genItemMaster_FinishedGoodList.Add(tbl_genItemMaster_FinishedGood);
				}
			}
			scon.Close();
			return tbl_genItemMaster_FinishedGoodList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_FinishedGood> SelectAllByItem_ID(string item_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGoodSelectAllByItem_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID;
				List<tbl_genItemMaster_FinishedGood> tbl_genItemMaster_FinishedGoodList = new List<tbl_genItemMaster_FinishedGood>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_FinishedGood tbl_genItemMaster_FinishedGood = Maketbl_genItemMaster_FinishedGood(dataReader);
					tbl_genItemMaster_FinishedGoodList.Add(tbl_genItemMaster_FinishedGood);
				}
			}
			scon.Close();
			return tbl_genItemMaster_FinishedGoodList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_FinishedGood> SelectAllBySealingType_ID(string sealingType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGoodSelectAllBySealingType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@sealingType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@sealingType_ID"].Value = sealingType_ID;
				List<tbl_genItemMaster_FinishedGood> tbl_genItemMaster_FinishedGoodList = new List<tbl_genItemMaster_FinishedGood>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_FinishedGood tbl_genItemMaster_FinishedGood = Maketbl_genItemMaster_FinishedGood(dataReader);
					tbl_genItemMaster_FinishedGoodList.Add(tbl_genItemMaster_FinishedGood);
				}
			}
			scon.Close();
			return tbl_genItemMaster_FinishedGoodList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_FinishedGood> SelectAllByBrand_ID(string brand_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGoodSelectAllByBrand_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters["@brand_ID"].Value = brand_ID;
				List<tbl_genItemMaster_FinishedGood> tbl_genItemMaster_FinishedGoodList = new List<tbl_genItemMaster_FinishedGood>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_FinishedGood tbl_genItemMaster_FinishedGood = Maketbl_genItemMaster_FinishedGood(dataReader);
					tbl_genItemMaster_FinishedGoodList.Add(tbl_genItemMaster_FinishedGood);
				}
			}
			scon.Close();
			return tbl_genItemMaster_FinishedGoodList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_FinishedGood table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_FinishedGood> SelectAllByPolytheneType_ID(string polytheneType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_FinishedGoodSelectAllByPolytheneType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
				List<tbl_genItemMaster_FinishedGood> tbl_genItemMaster_FinishedGoodList = new List<tbl_genItemMaster_FinishedGood>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_FinishedGood tbl_genItemMaster_FinishedGood = Maketbl_genItemMaster_FinishedGood(dataReader);
					tbl_genItemMaster_FinishedGoodList.Add(tbl_genItemMaster_FinishedGood);
				}
			}
			scon.Close();
			return tbl_genItemMaster_FinishedGoodList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genItemMaster_FinishedGood class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItemMaster_FinishedGood Maketbl_genItemMaster_FinishedGood(SqlDataReader dataReader) {
			tbl_genItemMaster_FinishedGood tbl_genItemMaster_FinishedGood = new tbl_genItemMaster_FinishedGood();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItemMaster_FinishedGood.Width = dataReader.GetDecimal(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItemMaster_FinishedGood.Height = dataReader.GetDecimal(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genItemMaster_FinishedGood.Thickness = dataReader.GetDecimal(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genItemMaster_FinishedGood.Gusset = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genItemMaster_FinishedGood.Customer_ID = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genItemMaster_FinishedGood.Brand_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genItemMaster_FinishedGood.PolytheneType_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genItemMaster_FinishedGood.SealingType_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genItemMaster_FinishedGood.IsPrinted = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genItemMaster_FinishedGood.Item_ID = dataReader.GetString(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genItemMaster_FinishedGood.ItemName = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genItemMaster_FinishedGood.IsCustomerWise = dataReader.GetBoolean(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genItemMaster_FinishedGood.IsBrandWise = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genItemMaster_FinishedGood.IsCommercial = dataReader.GetBoolean(13);
			}

			return tbl_genItemMaster_FinishedGood;
		}
		/// <summary>
		/// This makes tbl_genItemMaster_FinishedGood datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_FinishedGood object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItemMaster_FinishedGood  tbl_genItemMaster_FinishedGood   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_width = new DataColumn("width" , typeof(decimal));
			DataColumn col_height = new DataColumn("height" , typeof(decimal));
			DataColumn col_thickness = new DataColumn("thickness" , typeof(decimal));
			DataColumn col_gusset = new DataColumn("gusset" , typeof(decimal));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_brand_ID = new DataColumn("brand_ID" , typeof(string));
			DataColumn col_polytheneType_ID = new DataColumn("polytheneType_ID" , typeof(string));
			DataColumn col_sealingType_ID = new DataColumn("sealingType_ID" , typeof(string));
			DataColumn col_isPrinted = new DataColumn("isPrinted" , typeof(bool));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemName = new DataColumn("itemName" , typeof(string));
			DataColumn col_isCustomerWise = new DataColumn("isCustomerWise" , typeof(bool));
			DataColumn col_isBrandWise = new DataColumn("isBrandWise" , typeof(bool));
			DataColumn col_isCommercial = new DataColumn("isCommercial" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_width,col_height,col_thickness,col_gusset,col_customer_ID,col_brand_ID,col_polytheneType_ID,col_sealingType_ID,col_isPrinted,col_item_ID,col_itemName,col_isCustomerWise,col_isBrandWise,col_isCommercial,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItemMaster_FinishedGood datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_FinishedGood object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItemMaster_FinishedGood user) {
		DataRow drow = dt.NewRow();
		
			drow["width"] = user.width;
			drow["height"] = user.height;
			drow["thickness"] = user.thickness;
			drow["gusset"] = user.gusset;
			drow["customer_ID"] = user.customer_ID;
			drow["brand_ID"] = user.brand_ID;
			drow["polytheneType_ID"] = user.polytheneType_ID;
			drow["sealingType_ID"] = user.sealingType_ID;
			drow["isPrinted"] = user.isPrinted;
			drow["item_ID"] = user.item_ID;
			drow["itemName"] = user.itemName;
			drow["isCustomerWise"] = user.isCustomerWise;
			drow["isBrandWise"] = user.isBrandWise;
			drow["isCommercial"] = user.isCommercial;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
