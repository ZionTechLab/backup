using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genItemMaster_SemiFinishedGood_Material {
		#region Fields
		private decimal width;
		private decimal height;
		private int line_No;
		private decimal thickness;
		private decimal gusset;
		private string customer_ID;
		private string brand_ID;
		private string polytheneType_ID;
		private string sealingType_ID;
		private bool isPrinted;
		private string section_ID;
		private int sectionCount;
		private string item_ID;
		private string itemName;
		private bool isCustomerWise;
		private bool isBrandWise;
		private bool isCommercial;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_SemiFinishedGood_Material class.
		/// </summary>
		public tbl_genItemMaster_SemiFinishedGood_Material() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster_SemiFinishedGood_Material class.
		/// </summary>
		public tbl_genItemMaster_SemiFinishedGood_Material(decimal width, decimal height, int line_No, decimal thickness, decimal gusset, string customer_ID, string brand_ID, string polytheneType_ID, string sealingType_ID, bool isPrinted, string section_ID, int sectionCount, string item_ID, string itemName, bool isCustomerWise, bool isBrandWise, bool isCommercial) {
			this.width = width;
			this.height = height;
			this.line_No = line_No;
			this.thickness = thickness;
			this.gusset = gusset;
			this.customer_ID = customer_ID;
			this.brand_ID = brand_ID;
			this.polytheneType_ID = polytheneType_ID;
			this.sealingType_ID = sealingType_ID;
			this.isPrinted = isPrinted;
			this.section_ID = section_ID;
			this.sectionCount = sectionCount;
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
		/// Gets or sets the Line_No value.
		/// </summary>
		public int Line_No {
			get { return line_No; }
			set { line_No = value; }
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
		/// Gets or sets the Section_ID value.
		/// </summary>
		public string Section_ID {
			get { return section_ID; }
			set { section_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SectionCount value.
		/// </summary>
		public int SectionCount {
			get { return sectionCount; }
			set { sectionCount = value; }
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
		/// Saves a record to the tbl_genItemMaster_SemiFinishedGood_Material table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_SemiFinishedGood_MaterialInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gusset", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sealingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionCount", SqlDbType.Int,4);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isCustomerWise", SqlDbType.Bit,1);
			scom.Parameters.Add("@isBrandWise", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCommercial", SqlDbType.Bit,1);
 
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@height"].Value = height;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@thickness"].Value = thickness;
			scom.Parameters["@gusset"].Value = gusset;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@brand_ID"].Value = brand_ID;
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
			scom.Parameters["@sealingType_ID"].Value = sealingType_ID;
			scom.Parameters["@isPrinted"].Value = isPrinted;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@sectionCount"].Value = sectionCount;
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
		/// Updates a record in the tbl_genItemMaster_SemiFinishedGood_Material table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_SemiFinishedGood_MaterialUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gusset", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sealingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionCount", SqlDbType.Int,4);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,50);
			scom.Parameters.Add("@isCustomerWise", SqlDbType.Bit,1);
			scom.Parameters.Add("@isBrandWise", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCommercial", SqlDbType.Bit,1);
 
 
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@height"].Value = height;
			scom.Parameters["@line_No"].Value = line_No;
			scom.Parameters["@thickness"].Value = thickness;
			scom.Parameters["@gusset"].Value = gusset;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@brand_ID"].Value = brand_ID;
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
			scom.Parameters["@sealingType_ID"].Value = sealingType_ID;
			scom.Parameters["@isPrinted"].Value = isPrinted;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@sectionCount"].Value = sectionCount;
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
		/// Deletes a record from the tbl_genItemMaster_SemiFinishedGood_Material table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_SemiFinishedGood_MaterialDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gusset", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sealingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionCount", SqlDbType.Int,4);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@width"].Value = width;
 
			scom.Parameters["@height"].Value = height;
 
			scom.Parameters["@line_No"].Value = line_No;
 
			scom.Parameters["@thickness"].Value = thickness;
 
			scom.Parameters["@gusset"].Value = gusset;
 
			scom.Parameters["@customer_ID"].Value = customer_ID;
 
			scom.Parameters["@brand_ID"].Value = brand_ID;
 
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
 
			scom.Parameters["@sealingType_ID"].Value = sealingType_ID;
 
			scom.Parameters["@isPrinted"].Value = isPrinted;
 
			scom.Parameters["@section_ID"].Value = section_ID;
 
			scom.Parameters["@sectionCount"].Value = sectionCount;
 
			scom.Parameters["@item_ID"].Value = item_ID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_SemiFinishedGood_Material table by a foreign key.
		/// </summary>
		public static void DeleteAllByWidth_Height_Thickness_Gusset_Customer_ID_Brand_ID_PolytheneType_ID_SealingType_ID_IsPrinted_Section_ID_SectionCount(decimal width, decimal height, decimal thickness, decimal gusset, string customer_ID, string brand_ID, string polytheneType_ID, string sealingType_ID, bool isPrinted, string section_ID, int sectionCount) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_SemiFinishedGood_MaterialDeleteAllByWidth_Height_Thickness_Gusset_Customer_ID_Brand_ID_PolytheneType_ID_SealingType_ID_IsPrinted_Section_ID_SectionCount", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gusset", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sealingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionCount", SqlDbType.Int,4);
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@height"].Value = height;
			scom.Parameters["@thickness"].Value = thickness;
			scom.Parameters["@gusset"].Value = gusset;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@brand_ID"].Value = brand_ID;
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
			scom.Parameters["@sealingType_ID"].Value = sealingType_ID;
			scom.Parameters["@isPrinted"].Value = isPrinted;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@sectionCount"].Value = sectionCount;
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_genItemMaster_SemiFinishedGood_Material table.
		/// </summary>
		public static tbl_genItemMaster_SemiFinishedGood_Material Select(decimal width_Incoming, decimal height_Incoming, int line_No_Incoming, decimal thickness_Incoming, decimal gusset_Incoming, string customer_ID_Incoming, string brand_ID_Incoming, string polytheneType_ID_Incoming, string sealingType_ID_Incoming, bool isPrinted_Incoming, string section_ID_Incoming, int sectionCount_Incoming, string item_ID_Incoming){

			tbl_genItemMaster_SemiFinishedGood_Material tbl_genItemMaster_SemiFinishedGood_Materialins = new tbl_genItemMaster_SemiFinishedGood_Material();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_SemiFinishedGood_MaterialSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@line_No", SqlDbType.Int,4);
			scom.Parameters.Add("@thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gusset", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sealingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionCount", SqlDbType.Int,4);
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@width"].Value = width_Incoming;
			scom.Parameters["@height"].Value = height_Incoming;
			scom.Parameters["@line_No"].Value = line_No_Incoming;
			scom.Parameters["@thickness"].Value = thickness_Incoming;
			scom.Parameters["@gusset"].Value = gusset_Incoming;
			scom.Parameters["@customer_ID"].Value = customer_ID_Incoming;
			scom.Parameters["@brand_ID"].Value = brand_ID_Incoming;
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID_Incoming;
			scom.Parameters["@sealingType_ID"].Value = sealingType_ID_Incoming;
			scom.Parameters["@isPrinted"].Value = isPrinted_Incoming;
			scom.Parameters["@section_ID"].Value = section_ID_Incoming;
			scom.Parameters["@sectionCount"].Value = sectionCount_Incoming;
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItemMaster_SemiFinishedGood_Materialins = Maketbl_genItemMaster_SemiFinishedGood_Material(dataReader);
				} else {
					tbl_genItemMaster_SemiFinishedGood_Materialins = null;
				}
			}
			scon.Close();
			return tbl_genItemMaster_SemiFinishedGood_Materialins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_SemiFinishedGood_Material table.
		/// </summary>
		public static List<tbl_genItemMaster_SemiFinishedGood_Material> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_SemiFinishedGood_MaterialSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItemMaster_SemiFinishedGood_Material> tbl_genItemMaster_SemiFinishedGood_MaterialList = new List<tbl_genItemMaster_SemiFinishedGood_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_SemiFinishedGood_Material tbl_genItemMaster_SemiFinishedGood_Material = Maketbl_genItemMaster_SemiFinishedGood_Material(dataReader);
					tbl_genItemMaster_SemiFinishedGood_MaterialList.Add(tbl_genItemMaster_SemiFinishedGood_Material);
				}
			}
			scon.Close();
			return tbl_genItemMaster_SemiFinishedGood_MaterialList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster_SemiFinishedGood_Material table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster_SemiFinishedGood_Material> SelectAllByWidth_Height_Thickness_Gusset_Customer_ID_Brand_ID_PolytheneType_ID_SealingType_ID_IsPrinted_Section_ID_SectionCount(decimal width, decimal height, decimal thickness, decimal gusset, string customer_ID, string brand_ID, string polytheneType_ID, string sealingType_ID, bool isPrinted, string section_ID, int sectionCount) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMaster_SemiFinishedGood_MaterialSelectAllByWidth_Height_Thickness_Gusset_Customer_ID_Brand_ID_PolytheneType_ID_SealingType_ID_IsPrinted_Section_ID_SectionCount", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gusset", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customer_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@polytheneType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@sealingType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isPrinted", SqlDbType.Bit,1);
			scom.Parameters.Add("@section_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@sectionCount", SqlDbType.Int,4);
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@height"].Value = height;
			scom.Parameters["@thickness"].Value = thickness;
			scom.Parameters["@gusset"].Value = gusset;
			scom.Parameters["@customer_ID"].Value = customer_ID;
			scom.Parameters["@brand_ID"].Value = brand_ID;
			scom.Parameters["@polytheneType_ID"].Value = polytheneType_ID;
			scom.Parameters["@sealingType_ID"].Value = sealingType_ID;
			scom.Parameters["@isPrinted"].Value = isPrinted;
			scom.Parameters["@section_ID"].Value = section_ID;
			scom.Parameters["@sectionCount"].Value = sectionCount;
				List<tbl_genItemMaster_SemiFinishedGood_Material> tbl_genItemMaster_SemiFinishedGood_MaterialList = new List<tbl_genItemMaster_SemiFinishedGood_Material>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster_SemiFinishedGood_Material tbl_genItemMaster_SemiFinishedGood_Material = Maketbl_genItemMaster_SemiFinishedGood_Material(dataReader);
					tbl_genItemMaster_SemiFinishedGood_MaterialList.Add(tbl_genItemMaster_SemiFinishedGood_Material);
				}
			}
			scon.Close();
			return tbl_genItemMaster_SemiFinishedGood_MaterialList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_genItemMaster_SemiFinishedGood_Material class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItemMaster_SemiFinishedGood_Material Maketbl_genItemMaster_SemiFinishedGood_Material(SqlDataReader dataReader) {
			tbl_genItemMaster_SemiFinishedGood_Material tbl_genItemMaster_SemiFinishedGood_Material = new tbl_genItemMaster_SemiFinishedGood_Material();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItemMaster_SemiFinishedGood_Material.Width = dataReader.GetDecimal(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItemMaster_SemiFinishedGood_Material.Height = dataReader.GetDecimal(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genItemMaster_SemiFinishedGood_Material.Line_No = dataReader.GetInt32(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genItemMaster_SemiFinishedGood_Material.Thickness = dataReader.GetDecimal(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genItemMaster_SemiFinishedGood_Material.Gusset = dataReader.GetDecimal(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genItemMaster_SemiFinishedGood_Material.Customer_ID = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genItemMaster_SemiFinishedGood_Material.Brand_ID = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genItemMaster_SemiFinishedGood_Material.PolytheneType_ID = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genItemMaster_SemiFinishedGood_Material.SealingType_ID = dataReader.GetString(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genItemMaster_SemiFinishedGood_Material.IsPrinted = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genItemMaster_SemiFinishedGood_Material.Section_ID = dataReader.GetString(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genItemMaster_SemiFinishedGood_Material.SectionCount = dataReader.GetInt32(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genItemMaster_SemiFinishedGood_Material.Item_ID = dataReader.GetString(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genItemMaster_SemiFinishedGood_Material.ItemName = dataReader.GetString(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genItemMaster_SemiFinishedGood_Material.IsCustomerWise = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genItemMaster_SemiFinishedGood_Material.IsBrandWise = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genItemMaster_SemiFinishedGood_Material.IsCommercial = dataReader.GetBoolean(16);
			}

			return tbl_genItemMaster_SemiFinishedGood_Material;
		}
		/// <summary>
		/// This makes tbl_genItemMaster_SemiFinishedGood_Material datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_SemiFinishedGood_Material object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItemMaster_SemiFinishedGood_Material  tbl_genItemMaster_SemiFinishedGood_Material   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_width = new DataColumn("width" , typeof(decimal));
			DataColumn col_height = new DataColumn("height" , typeof(decimal));
			DataColumn col_line_No = new DataColumn("line_No" , typeof(int));
			DataColumn col_thickness = new DataColumn("thickness" , typeof(decimal));
			DataColumn col_gusset = new DataColumn("gusset" , typeof(decimal));
			DataColumn col_customer_ID = new DataColumn("customer_ID" , typeof(string));
			DataColumn col_brand_ID = new DataColumn("brand_ID" , typeof(string));
			DataColumn col_polytheneType_ID = new DataColumn("polytheneType_ID" , typeof(string));
			DataColumn col_sealingType_ID = new DataColumn("sealingType_ID" , typeof(string));
			DataColumn col_isPrinted = new DataColumn("isPrinted" , typeof(bool));
			DataColumn col_section_ID = new DataColumn("section_ID" , typeof(string));
			DataColumn col_sectionCount = new DataColumn("sectionCount" , typeof(int));
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_itemName = new DataColumn("itemName" , typeof(string));
			DataColumn col_isCustomerWise = new DataColumn("isCustomerWise" , typeof(bool));
			DataColumn col_isBrandWise = new DataColumn("isBrandWise" , typeof(bool));
			DataColumn col_isCommercial = new DataColumn("isCommercial" , typeof(bool));
		dt.Columns.AddRange(new DataColumn[] { col_width,col_height,col_line_No,col_thickness,col_gusset,col_customer_ID,col_brand_ID,col_polytheneType_ID,col_sealingType_ID,col_isPrinted,col_section_ID,col_sectionCount,col_item_ID,col_itemName,col_isCustomerWise,col_isBrandWise,col_isCommercial,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItemMaster_SemiFinishedGood_Material datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItemMaster_SemiFinishedGood_Material object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItemMaster_SemiFinishedGood_Material user) {
		DataRow drow = dt.NewRow();
		
			drow["width"] = user.width;
			drow["height"] = user.height;
			drow["line_No"] = user.line_No;
			drow["thickness"] = user.thickness;
			drow["gusset"] = user.gusset;
			drow["customer_ID"] = user.customer_ID;
			drow["brand_ID"] = user.brand_ID;
			drow["polytheneType_ID"] = user.polytheneType_ID;
			drow["sealingType_ID"] = user.sealingType_ID;
			drow["isPrinted"] = user.isPrinted;
			drow["section_ID"] = user.section_ID;
			drow["sectionCount"] = user.sectionCount;
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
