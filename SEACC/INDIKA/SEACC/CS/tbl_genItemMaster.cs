using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_genItemMaster {
		#region Fields
		private string item_ID;
		private string generateCode;
		private string itemName;
		private string description;
		private string description1;
		private string itemHS_code;
		private string remark;
		private string origin;
		private decimal minStockLevel;
		private decimal maxStockLevel;
		private decimal reReoverLevel;
		private decimal reOrderQty;
		private bool isTIEPItem;
		private bool isImportItem;
		private bool isExportSalesItem;
		private bool isCombinationMaterail;
		private bool isServiceItem;
		private string itemCategorySub_ID;
		private string itemCategory_ID;
		private string itemClass_ID;
		private string itemType_ID;
		private string roleType_ID;
		private string brand_ID;
		private string subItem_ID;
		private string uom_ID;
		private decimal width;
		private decimal height;
		private decimal thickness;
		private decimal gusset;
		private decimal qty;
		private decimal calculationRate_Weight;
		private decimal calculationRate_LFeet;
		private string measureType_ID;
		private bool isWeightCalculation_Sales;
		private bool isWeightCalculation_Purchase;
		private bool isDeleted;
		private bool isVatinclusive;
		private bool isNBTinclusive;
		private string imagePath;
		private bool itemModel1;
		private bool itemModel2;
		private string companyID;
		private string companyBranch_ID;
		private string tag1_ID;
		private string tag2_ID;
		private bool isFinishGood;
		private bool isSemiFinishGood;
		private bool isRawMeterial;
		private bool isAccessories;
		private bool isPackingMaterial;
		private bool isStationary;
		private bool isSalesItem;
		private bool isFixedAsset;
		private bool isGiftVoucher;
		private bool isOther;
		private string asset_GL_ID;
		private string assetPrefix;
		private int counter;
		private string controlAcc;
		public bool isBlackList;
		public string store_ID;
		public string ImageStatus;

		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster class.
		/// </summary>
		public tbl_genItemMaster() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_genItemMaster class.
		/// </summary>
		public tbl_genItemMaster(string item_ID, string generateCode, string itemName, string description, string description1, string itemHS_code, string remark, string origin, decimal minStockLevel, decimal maxStockLevel, decimal reReoverLevel, decimal reOrderQty, bool isTIEPItem, bool isImportItem, bool isExportSalesItem, bool isCombinationMaterail, bool isServiceItem, string itemCategorySub_ID, string itemCategory_ID, string itemClass_ID, string itemType_ID, string roleType_ID, string brand_ID, string subItem_ID, string uom_ID, decimal width, decimal height, decimal thickness, decimal gusset, decimal qty, decimal calculationRate_Weight, decimal calculationRate_LFeet, string measureType_ID, bool isWeightCalculation_Sales, bool isWeightCalculation_Purchase, bool isDeleted, bool isVatinclusive, bool isNBTinclusive, string imagePath, bool itemModel1, bool itemModel2, string companyID, string companyBranch_ID, string tag1_ID, string tag2_ID, bool isFinishGood, bool isSemiFinishGood, bool isRawMeterial, bool isAccessories, bool isPackingMaterial, bool isStationary, bool isSalesItem, bool isFixedAsset, bool isGiftVoucher, bool isOther, string asset_GL_ID, string assetPrefix, int counter, string controlAcc,bool _isBlackList,string _store_ID,string _ImageStatus) {
			this.item_ID = item_ID;
			this.generateCode = generateCode;
			this.itemName = itemName;
			this.description = description;
			this.description1 = description1;
			this.itemHS_code = itemHS_code;
			this.remark = remark;
			this.origin = origin;
			this.minStockLevel = minStockLevel;
			this.maxStockLevel = maxStockLevel;
			this.reReoverLevel = reReoverLevel;
			this.reOrderQty = reOrderQty;
			this.isTIEPItem = isTIEPItem;
			this.isImportItem = isImportItem;
			this.isExportSalesItem = isExportSalesItem;
			this.isCombinationMaterail = isCombinationMaterail;
			this.isServiceItem = isServiceItem;
			this.itemCategorySub_ID = itemCategorySub_ID;
			this.itemCategory_ID = itemCategory_ID;
			this.itemClass_ID = itemClass_ID;
			this.itemType_ID = itemType_ID;
			this.roleType_ID = roleType_ID;
			this.brand_ID = brand_ID;
			this.subItem_ID = subItem_ID;
			this.uom_ID = uom_ID;
			this.width = width;
			this.height = height;
			this.thickness = thickness;
			this.gusset = gusset;
			this.qty = qty;
			this.calculationRate_Weight = calculationRate_Weight;
			this.calculationRate_LFeet = calculationRate_LFeet;
			this.measureType_ID = measureType_ID;
			this.isWeightCalculation_Sales = isWeightCalculation_Sales;
			this.isWeightCalculation_Purchase = isWeightCalculation_Purchase;
			this.isDeleted = isDeleted;
			this.isVatinclusive = isVatinclusive;
			this.isNBTinclusive = isNBTinclusive;
			this.imagePath = imagePath;
			this.itemModel1 = itemModel1;
			this.itemModel2 = itemModel2;
			this.companyID = companyID;
			this.companyBranch_ID = companyBranch_ID;
			this.tag1_ID = tag1_ID;
			this.tag2_ID = tag2_ID;
			this.isFinishGood = isFinishGood;
			this.isSemiFinishGood = isSemiFinishGood;
			this.isRawMeterial = isRawMeterial;
			this.isAccessories = isAccessories;
			this.isPackingMaterial = isPackingMaterial;
			this.isStationary = isStationary;
			this.isSalesItem = isSalesItem;
			this.isFixedAsset = isFixedAsset;
			this.isGiftVoucher = isGiftVoucher;
			this.isOther = isOther;
			this.asset_GL_ID = asset_GL_ID;
			this.assetPrefix = assetPrefix;
			this.counter = counter;
			this.controlAcc = controlAcc;
			this.isBlackList = _isBlackList;
			this.store_ID = _store_ID;
			this.ImageStatus = _ImageStatus;

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
		/// Gets or sets the GenerateCode value.
		/// </summary>
		public string GenerateCode {
			get { return generateCode; }
			set { generateCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemName value.
		/// </summary>
		public string ItemName {
			get { return itemName; }
			set { itemName = value; }
		}
		
		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description {
			get { return description; }
			set { description = value; }
		}
		
		/// <summary>
		/// Gets or sets the Description1 value.
		/// </summary>
		public string Description1 {
			get { return description1; }
			set { description1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemHS_code value.
		/// </summary>
		public string ItemHS_code {
			get { return itemHS_code; }
			set { itemHS_code = value; }
		}
		
		/// <summary>
		/// Gets or sets the Remark value.
		/// </summary>
		public string Remark {
			get { return remark; }
			set { remark = value; }
		}
		
		/// <summary>
		/// Gets or sets the Origin value.
		/// </summary>
		public string Origin {
			get { return origin; }
			set { origin = value; }
		}
		
		/// <summary>
		/// Gets or sets the MinStockLevel value.
		/// </summary>
		public decimal MinStockLevel {
			get { return minStockLevel; }
			set { minStockLevel = value; }
		}
		
		/// <summary>
		/// Gets or sets the MaxStockLevel value.
		/// </summary>
		public decimal MaxStockLevel {
			get { return maxStockLevel; }
			set { maxStockLevel = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReReoverLevel value.
		/// </summary>
		public decimal ReReoverLevel {
			get { return reReoverLevel; }
			set { reReoverLevel = value; }
		}
		
		/// <summary>
		/// Gets or sets the ReOrderQty value.
		/// </summary>
		public decimal ReOrderQty {
			get { return reOrderQty; }
			set { reOrderQty = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsTIEPItem value.
		/// </summary>
		public bool IsTIEPItem {
			get { return isTIEPItem; }
			set { isTIEPItem = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsImportItem value.
		/// </summary>
		public bool IsImportItem {
			get { return isImportItem; }
			set { isImportItem = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsExportSalesItem value.
		/// </summary>
		public bool IsExportSalesItem {
			get { return isExportSalesItem; }
			set { isExportSalesItem = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsCombinationMaterail value.
		/// </summary>
		public bool IsCombinationMaterail {
			get { return isCombinationMaterail; }
			set { isCombinationMaterail = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsServiceItem value.
		/// </summary>
		public bool IsServiceItem {
			get { return isServiceItem; }
			set { isServiceItem = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemCategorySub_ID value.
		/// </summary>
		public string ItemCategorySub_ID {
			get { return itemCategorySub_ID; }
			set { itemCategorySub_ID = value; }
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
		/// Gets or sets the RoleType_ID value.
		/// </summary>
		public string RoleType_ID {
			get { return roleType_ID; }
			set { roleType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Brand_ID value.
		/// </summary>
		public string Brand_ID {
			get { return brand_ID; }
			set { brand_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the SubItem_ID value.
		/// </summary>
		public string SubItem_ID {
			get { return subItem_ID; }
			set { subItem_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Uom_ID value.
		/// </summary>
		public string Uom_ID {
			get { return uom_ID; }
			set { uom_ID = value; }
		}
		
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
		/// Gets or sets the Qty value.
		/// </summary>
		public decimal Qty {
			get { return qty; }
			set { qty = value; }
		}
		
		/// <summary>
		/// Gets or sets the CalculationRate_Weight value.
		/// </summary>
		public decimal CalculationRate_Weight {
			get { return calculationRate_Weight; }
			set { calculationRate_Weight = value; }
		}
		
		/// <summary>
		/// Gets or sets the CalculationRate_LFeet value.
		/// </summary>
		public decimal CalculationRate_LFeet {
			get { return calculationRate_LFeet; }
			set { calculationRate_LFeet = value; }
		}
		
		/// <summary>
		/// Gets or sets the MeasureType_ID value.
		/// </summary>
		public string MeasureType_ID {
			get { return measureType_ID; }
			set { measureType_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsWeightCalculation_Sales value.
		/// </summary>
		public bool IsWeightCalculation_Sales {
			get { return isWeightCalculation_Sales; }
			set { isWeightCalculation_Sales = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsWeightCalculation_Purchase value.
		/// </summary>
		public bool IsWeightCalculation_Purchase {
			get { return isWeightCalculation_Purchase; }
			set { isWeightCalculation_Purchase = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsDeleted value.
		/// </summary>
		public bool IsDeleted {
			get { return isDeleted; }
			set { isDeleted = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsVatinclusive value.
		/// </summary>
		public bool IsVatinclusive {
			get { return isVatinclusive; }
			set { isVatinclusive = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsNBTinclusive value.
		/// </summary>
		public bool IsNBTinclusive {
			get { return isNBTinclusive; }
			set { isNBTinclusive = value; }
		}
		
		/// <summary>
		/// Gets or sets the ImagePath value.
		/// </summary>
		public string ImagePath {
			get { return imagePath; }
			set { imagePath = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemModel1 value.
		/// </summary>
		public bool ItemModel1 {
			get { return itemModel1; }
			set { itemModel1 = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemModel2 value.
		/// </summary>
		public bool ItemModel2 {
			get { return itemModel2; }
			set { itemModel2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyID value.
		/// </summary>
		public string CompanyID {
			get { return companyID; }
			set { companyID = value; }
		}
		
		/// <summary>
		/// Gets or sets the CompanyBranch_ID value.
		/// </summary>
		public string CompanyBranch_ID {
			get { return companyBranch_ID; }
			set { companyBranch_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tag1_ID value.
		/// </summary>
		public string Tag1_ID {
			get { return tag1_ID; }
			set { tag1_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the Tag2_ID value.
		/// </summary>
		public string Tag2_ID {
			get { return tag2_ID; }
			set { tag2_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsFinishGood value.
		/// </summary>
		public bool IsFinishGood {
			get { return isFinishGood; }
			set { isFinishGood = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSemiFinishGood value.
		/// </summary>
		public bool IsSemiFinishGood {
			get { return isSemiFinishGood; }
			set { isSemiFinishGood = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsRawMeterial value.
		/// </summary>
		public bool IsRawMeterial {
			get { return isRawMeterial; }
			set { isRawMeterial = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsAccessories value.
		/// </summary>
		public bool IsAccessories {
			get { return isAccessories; }
			set { isAccessories = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsPackingMaterial value.
		/// </summary>
		public bool IsPackingMaterial {
			get { return isPackingMaterial; }
			set { isPackingMaterial = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsStationary value.
		/// </summary>
		public bool IsStationary {
			get { return isStationary; }
			set { isStationary = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsSalesItem value.
		/// </summary>
		public bool IsSalesItem {
			get { return isSalesItem; }
			set { isSalesItem = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsFixedAsset value.
		/// </summary>
		public bool IsFixedAsset {
			get { return isFixedAsset; }
			set { isFixedAsset = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsGiftVoucher value.
		/// </summary>
		public bool IsGiftVoucher {
			get { return isGiftVoucher; }
			set { isGiftVoucher = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsOther value.
		/// </summary>
		public bool IsOther {
			get { return isOther; }
			set { isOther = value; }
		}
		
		/// <summary>
		/// Gets or sets the Asset_GL_ID value.
		/// </summary>
		public string Asset_GL_ID {
			get { return asset_GL_ID; }
			set { asset_GL_ID = value; }
		}
		
		/// <summary>
		/// Gets or sets the AssetPrefix value.
		/// </summary>
		public string AssetPrefix {
			get { return assetPrefix; }
			set { assetPrefix = value; }
		}
		
		/// <summary>
		/// Gets or sets the Counter value.
		/// </summary>
		public int Counter {
			get { return counter; }
			set { counter = value; }
		}
		
		/// <summary>
		/// Gets or sets the ControlAcc value.
		/// </summary>
		public string ControlAcc {
			get { return controlAcc; }
			set { controlAcc = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_genItemMaster table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMasterInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@generateCode", SqlDbType.VarChar,500);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,200);
			scom.Parameters.Add("@description", SqlDbType.VarChar,500);
			scom.Parameters.Add("@description1", SqlDbType.VarChar,100);
			scom.Parameters.Add("@itemHS_code", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@origin", SqlDbType.VarChar,50);
			scom.Parameters.Add("@minStockLevel", SqlDbType.Decimal,9);
			scom.Parameters.Add("@maxStockLevel", SqlDbType.Decimal,9);
			scom.Parameters.Add("@reReoverLevel", SqlDbType.Decimal,9);
			scom.Parameters.Add("@reOrderQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isTIEPItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@isImportItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@isExportSalesItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCombinationMaterail", SqlDbType.Bit,1);
			scom.Parameters.Add("@isServiceItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@itemCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@roleType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@subItem_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gusset", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@calculationRate_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@calculationRate_LFeet", SqlDbType.Decimal,9);
			scom.Parameters.Add("@measureType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isWeightCalculation_Sales", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWeightCalculation_Purchase", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isVatinclusive", SqlDbType.Bit,1);
			scom.Parameters.Add("@isNBTinclusive", SqlDbType.Bit,1);
			scom.Parameters.Add("@imagePath", SqlDbType.VarChar,200);
			scom.Parameters.Add("@itemModel1", SqlDbType.Bit,1);
			scom.Parameters.Add("@itemModel2", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tag1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tag2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isFinishGood", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSemiFinishGood", SqlDbType.Bit,1);
			scom.Parameters.Add("@isRawMeterial", SqlDbType.Bit,1);
			scom.Parameters.Add("@isAccessories", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPackingMaterial", SqlDbType.Bit,1);
			scom.Parameters.Add("@isStationary", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSalesItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFixedAsset", SqlDbType.Bit,1);
			scom.Parameters.Add("@isGiftVoucher", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOther", SqlDbType.Bit,1);
			scom.Parameters.Add("@asset_GL_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@assetPrefix", SqlDbType.VarChar,20);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@controlAcc", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isBlackList", SqlDbType.Bit, 1);
scom.Parameters.Add("@store_ID", SqlDbType.VarChar, 20);
scom.Parameters.Add("@ImageStatus", SqlDbType.Char, 1);

			scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@generateCode"].Value = generateCode;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@description1"].Value = description1;
			scom.Parameters["@itemHS_code"].Value = itemHS_code;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@origin"].Value = origin;
			scom.Parameters["@minStockLevel"].Value = minStockLevel;
			scom.Parameters["@maxStockLevel"].Value = maxStockLevel;
			scom.Parameters["@reReoverLevel"].Value = reReoverLevel;
			scom.Parameters["@reOrderQty"].Value = reOrderQty;
			scom.Parameters["@isTIEPItem"].Value = isTIEPItem;
			scom.Parameters["@isImportItem"].Value = isImportItem;
			scom.Parameters["@isExportSalesItem"].Value = isExportSalesItem;
			scom.Parameters["@isCombinationMaterail"].Value = isCombinationMaterail;
			scom.Parameters["@isServiceItem"].Value = isServiceItem;
			scom.Parameters["@itemCategorySub_ID"].Value = itemCategorySub_ID;
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
			scom.Parameters["@itemClass_ID"].Value = itemClass_ID;
			scom.Parameters["@itemType_ID"].Value = itemType_ID;
			scom.Parameters["@roleType_ID"].Value = roleType_ID;
			scom.Parameters["@brand_ID"].Value = brand_ID;
			scom.Parameters["@subItem_ID"].Value = subItem_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@height"].Value = height;
			scom.Parameters["@thickness"].Value = thickness;
			scom.Parameters["@gusset"].Value = gusset;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@calculationRate_Weight"].Value = calculationRate_Weight;
			scom.Parameters["@calculationRate_LFeet"].Value = calculationRate_LFeet;
			scom.Parameters["@measureType_ID"].Value = measureType_ID;
			scom.Parameters["@isWeightCalculation_Sales"].Value = isWeightCalculation_Sales;
			scom.Parameters["@isWeightCalculation_Purchase"].Value = isWeightCalculation_Purchase;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isVatinclusive"].Value = isVatinclusive;
			scom.Parameters["@isNBTinclusive"].Value = isNBTinclusive;
			scom.Parameters["@imagePath"].Value = imagePath;
			scom.Parameters["@itemModel1"].Value = itemModel1;
			scom.Parameters["@itemModel2"].Value = itemModel2;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@tag1_ID"].Value = tag1_ID;
			scom.Parameters["@tag2_ID"].Value = tag2_ID;
			scom.Parameters["@isFinishGood"].Value = isFinishGood;
			scom.Parameters["@isSemiFinishGood"].Value = isSemiFinishGood;
			scom.Parameters["@isRawMeterial"].Value = isRawMeterial;
			scom.Parameters["@isAccessories"].Value = isAccessories;
			scom.Parameters["@isPackingMaterial"].Value = isPackingMaterial;
			scom.Parameters["@isStationary"].Value = isStationary;
			scom.Parameters["@isSalesItem"].Value = isSalesItem;
			scom.Parameters["@isFixedAsset"].Value = isFixedAsset;
			scom.Parameters["@isGiftVoucher"].Value = isGiftVoucher;
			scom.Parameters["@isOther"].Value = isOther;
			scom.Parameters["@asset_GL_ID"].Value = asset_GL_ID;
			scom.Parameters["@assetPrefix"].Value = assetPrefix;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@controlAcc"].Value = controlAcc;
			scom.Parameters["@isBlackList"].Value = isBlackList;
scom.Parameters["@store_ID"].Value = store_ID;
scom.Parameters["@ImageStatus"].Value = ImageStatus;

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_genItemMaster table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMasterUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@generateCode", SqlDbType.VarChar,500);
			scom.Parameters.Add("@itemName", SqlDbType.VarChar,200);
			scom.Parameters.Add("@description", SqlDbType.VarChar,500);
			scom.Parameters.Add("@description1", SqlDbType.VarChar,100);
			scom.Parameters.Add("@itemHS_code", SqlDbType.VarChar,50);
			scom.Parameters.Add("@remark", SqlDbType.VarChar,100);
			scom.Parameters.Add("@origin", SqlDbType.VarChar,50);
			scom.Parameters.Add("@minStockLevel", SqlDbType.Decimal,9);
			scom.Parameters.Add("@maxStockLevel", SqlDbType.Decimal,9);
			scom.Parameters.Add("@reReoverLevel", SqlDbType.Decimal,9);
			scom.Parameters.Add("@reOrderQty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@isTIEPItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@isImportItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@isExportSalesItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@isCombinationMaterail", SqlDbType.Bit,1);
			scom.Parameters.Add("@isServiceItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@itemCategorySub_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemClass_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@itemType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@roleType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@brand_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@subItem_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@uom_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@height", SqlDbType.Decimal,9);
			scom.Parameters.Add("@thickness", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gusset", SqlDbType.Decimal,9);
			scom.Parameters.Add("@qty", SqlDbType.Decimal,9);
			scom.Parameters.Add("@calculationRate_Weight", SqlDbType.Decimal,9);
			scom.Parameters.Add("@calculationRate_LFeet", SqlDbType.Decimal,9);
			scom.Parameters.Add("@measureType_ID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isWeightCalculation_Sales", SqlDbType.Bit,1);
			scom.Parameters.Add("@isWeightCalculation_Purchase", SqlDbType.Bit,1);
			scom.Parameters.Add("@isDeleted", SqlDbType.Bit,1);
			scom.Parameters.Add("@isVatinclusive", SqlDbType.Bit,1);
			scom.Parameters.Add("@isNBTinclusive", SqlDbType.Bit,1);
			scom.Parameters.Add("@imagePath", SqlDbType.VarChar,200);
			scom.Parameters.Add("@itemModel1", SqlDbType.Bit,1);
			scom.Parameters.Add("@itemModel2", SqlDbType.Bit,1);
			scom.Parameters.Add("@companyID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@companyBranch_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tag1_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@tag2_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isFinishGood", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSemiFinishGood", SqlDbType.Bit,1);
			scom.Parameters.Add("@isRawMeterial", SqlDbType.Bit,1);
			scom.Parameters.Add("@isAccessories", SqlDbType.Bit,1);
			scom.Parameters.Add("@isPackingMaterial", SqlDbType.Bit,1);
			scom.Parameters.Add("@isStationary", SqlDbType.Bit,1);
			scom.Parameters.Add("@isSalesItem", SqlDbType.Bit,1);
			scom.Parameters.Add("@isFixedAsset", SqlDbType.Bit,1);
			scom.Parameters.Add("@isGiftVoucher", SqlDbType.Bit,1);
			scom.Parameters.Add("@isOther", SqlDbType.Bit,1);
			scom.Parameters.Add("@asset_GL_ID", SqlDbType.VarChar,20);
			scom.Parameters.Add("@assetPrefix", SqlDbType.VarChar,20);
			scom.Parameters.Add("@counter", SqlDbType.Int,4);
			scom.Parameters.Add("@controlAcc", SqlDbType.VarChar,20);
			scom.Parameters.Add("@isBlackList", SqlDbType.Bit, 1);
	scom.Parameters.Add("@store_ID", SqlDbType.VarChar, 20);
          scom.Parameters.Add("@ImageStatus", SqlDbType.Char, 1); 

            scom.Parameters["@item_ID"].Value = item_ID;
			scom.Parameters["@generateCode"].Value = generateCode;
			scom.Parameters["@itemName"].Value = itemName;
			scom.Parameters["@description"].Value = description;
			scom.Parameters["@description1"].Value = description1;
			scom.Parameters["@itemHS_code"].Value = itemHS_code;
			scom.Parameters["@remark"].Value = remark;
			scom.Parameters["@origin"].Value = origin;
			scom.Parameters["@minStockLevel"].Value = minStockLevel;
			scom.Parameters["@maxStockLevel"].Value = maxStockLevel;
			scom.Parameters["@reReoverLevel"].Value = reReoverLevel;
			scom.Parameters["@reOrderQty"].Value = reOrderQty;
			scom.Parameters["@isTIEPItem"].Value = isTIEPItem;
			scom.Parameters["@isImportItem"].Value = isImportItem;
			scom.Parameters["@isExportSalesItem"].Value = isExportSalesItem;
			scom.Parameters["@isCombinationMaterail"].Value = isCombinationMaterail;
			scom.Parameters["@isServiceItem"].Value = isServiceItem;
			scom.Parameters["@itemCategorySub_ID"].Value = itemCategorySub_ID;
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
			scom.Parameters["@itemClass_ID"].Value = itemClass_ID;
			scom.Parameters["@itemType_ID"].Value = itemType_ID;
			scom.Parameters["@roleType_ID"].Value = roleType_ID;
			scom.Parameters["@brand_ID"].Value = brand_ID;
			scom.Parameters["@subItem_ID"].Value = subItem_ID;
			scom.Parameters["@uom_ID"].Value = uom_ID;
			scom.Parameters["@width"].Value = width;
			scom.Parameters["@height"].Value = height;
			scom.Parameters["@thickness"].Value = thickness;
			scom.Parameters["@gusset"].Value = gusset;
			scom.Parameters["@qty"].Value = qty;
			scom.Parameters["@calculationRate_Weight"].Value = calculationRate_Weight;
			scom.Parameters["@calculationRate_LFeet"].Value = calculationRate_LFeet;
			scom.Parameters["@measureType_ID"].Value = measureType_ID;
			scom.Parameters["@isWeightCalculation_Sales"].Value = isWeightCalculation_Sales;
			scom.Parameters["@isWeightCalculation_Purchase"].Value = isWeightCalculation_Purchase;
			scom.Parameters["@isDeleted"].Value = isDeleted;
			scom.Parameters["@isVatinclusive"].Value = isVatinclusive;
			scom.Parameters["@isNBTinclusive"].Value = isNBTinclusive;
			scom.Parameters["@imagePath"].Value = imagePath;
			scom.Parameters["@itemModel1"].Value = itemModel1;
			scom.Parameters["@itemModel2"].Value = itemModel2;
			scom.Parameters["@companyID"].Value = companyID;
			scom.Parameters["@companyBranch_ID"].Value = companyBranch_ID;
			scom.Parameters["@tag1_ID"].Value = tag1_ID;
			scom.Parameters["@tag2_ID"].Value = tag2_ID;
			scom.Parameters["@isFinishGood"].Value = isFinishGood;
			scom.Parameters["@isSemiFinishGood"].Value = isSemiFinishGood;
			scom.Parameters["@isRawMeterial"].Value = isRawMeterial;
			scom.Parameters["@isAccessories"].Value = isAccessories;
			scom.Parameters["@isPackingMaterial"].Value = isPackingMaterial;
			scom.Parameters["@isStationary"].Value = isStationary;
			scom.Parameters["@isSalesItem"].Value = isSalesItem;
			scom.Parameters["@isFixedAsset"].Value = isFixedAsset;
			scom.Parameters["@isGiftVoucher"].Value = isGiftVoucher;
			scom.Parameters["@isOther"].Value = isOther;
			scom.Parameters["@asset_GL_ID"].Value = asset_GL_ID;
			scom.Parameters["@assetPrefix"].Value = assetPrefix;
			scom.Parameters["@counter"].Value = counter;
			scom.Parameters["@controlAcc"].Value = controlAcc;
			scom.Parameters["@isBlackList"].Value = isBlackList;
scom.Parameters["@store_ID"].Value = store_ID;
scom.Parameters["@ImageStatus"].Value = ImageStatus;

			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}

		public static tbl_genItemMaster Select(string item_ID_Incoming){

			tbl_genItemMaster tbl_genItemMasterins = new tbl_genItemMaster();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMasterSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@item_ID", SqlDbType.VarChar,20);
			scom.Parameters["@item_ID"].Value = item_ID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_genItemMasterins = Maketbl_genItemMaster(dataReader);
				} else {
					tbl_genItemMasterins = null;
				}
			}
			scon.Close();
			return tbl_genItemMasterins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster table.
		/// </summary>
		public static List<tbl_genItemMaster> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMasterSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_genItemMaster> tbl_genItemMasterList = new List<tbl_genItemMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster tbl_genItemMaster = Maketbl_genItemMaster(dataReader);
					tbl_genItemMasterList.Add(tbl_genItemMaster);
				}
			}
			scon.Close();
			return tbl_genItemMasterList;
		}
		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster> SelectAllByItemType_ID(string itemType_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMasterSelectAllByItemType_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemType_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemType_ID"].Value = itemType_ID;
				List<tbl_genItemMaster> tbl_genItemMasterList = new List<tbl_genItemMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster tbl_genItemMaster = Maketbl_genItemMaster(dataReader);
					tbl_genItemMasterList.Add(tbl_genItemMaster);
				}
			}
			scon.Close();
			return tbl_genItemMasterList;
		}
		

		
		/// <summary>
		/// Selects all records from the tbl_genItemMaster table by a foreign key.
		/// </summary>
		public static List<tbl_genItemMaster> SelectAllByItemCategory_ID(string itemCategory_ID) {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_genItemMasterSelectAllByItemCategory_ID", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@itemCategory_ID", SqlDbType.VarChar,10);
			scom.Parameters["@itemCategory_ID"].Value = itemCategory_ID;
				List<tbl_genItemMaster> tbl_genItemMasterList = new List<tbl_genItemMaster>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_genItemMaster tbl_genItemMaster = Maketbl_genItemMaster(dataReader);
					tbl_genItemMasterList.Add(tbl_genItemMaster);
				}
			}
			scon.Close();
			return tbl_genItemMasterList;
		}
		

		
		/// <summary>
		/// Creates a new instance of the tbl_genItemMaster class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_genItemMaster Maketbl_genItemMaster(SqlDataReader dataReader) {
			tbl_genItemMaster tbl_genItemMaster = new tbl_genItemMaster();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_genItemMaster.Item_ID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_genItemMaster.GenerateCode = dataReader.GetString(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_genItemMaster.ItemName = dataReader.GetString(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_genItemMaster.Description = dataReader.GetString(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_genItemMaster.Description1 = dataReader.GetString(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_genItemMaster.ItemHS_code = dataReader.GetString(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_genItemMaster.Remark = dataReader.GetString(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_genItemMaster.Origin = dataReader.GetString(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_genItemMaster.MinStockLevel = dataReader.GetDecimal(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_genItemMaster.MaxStockLevel = dataReader.GetDecimal(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_genItemMaster.ReReoverLevel = dataReader.GetDecimal(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_genItemMaster.ReOrderQty = dataReader.GetDecimal(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_genItemMaster.IsTIEPItem = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_genItemMaster.IsImportItem = dataReader.GetBoolean(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_genItemMaster.IsExportSalesItem = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_genItemMaster.IsCombinationMaterail = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_genItemMaster.IsServiceItem = dataReader.GetBoolean(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_genItemMaster.ItemCategorySub_ID = dataReader.GetString(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_genItemMaster.ItemCategory_ID = dataReader.GetString(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_genItemMaster.ItemClass_ID = dataReader.GetString(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_genItemMaster.ItemType_ID = dataReader.GetString(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_genItemMaster.RoleType_ID = dataReader.GetString(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_genItemMaster.Brand_ID = dataReader.GetString(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_genItemMaster.SubItem_ID = dataReader.GetString(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_genItemMaster.Uom_ID = dataReader.GetString(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_genItemMaster.Width = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_genItemMaster.Height = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_genItemMaster.Thickness = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_genItemMaster.Gusset = dataReader.GetDecimal(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_genItemMaster.Qty = dataReader.GetDecimal(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_genItemMaster.CalculationRate_Weight = dataReader.GetDecimal(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_genItemMaster.CalculationRate_LFeet = dataReader.GetDecimal(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_genItemMaster.MeasureType_ID = dataReader.GetString(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_genItemMaster.IsWeightCalculation_Sales = dataReader.GetBoolean(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_genItemMaster.IsWeightCalculation_Purchase = dataReader.GetBoolean(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_genItemMaster.IsDeleted = dataReader.GetBoolean(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_genItemMaster.IsVatinclusive = dataReader.GetBoolean(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_genItemMaster.IsNBTinclusive = dataReader.GetBoolean(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_genItemMaster.ImagePath = dataReader.GetString(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_genItemMaster.ItemModel1 = dataReader.GetBoolean(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_genItemMaster.ItemModel2 = dataReader.GetBoolean(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_genItemMaster.CompanyID = dataReader.GetString(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_genItemMaster.CompanyBranch_ID = dataReader.GetString(42);
			}
			if (dataReader.IsDBNull(43) == false) {
				tbl_genItemMaster.Tag1_ID = dataReader.GetString(43);
			}
			if (dataReader.IsDBNull(44) == false) {
				tbl_genItemMaster.Tag2_ID = dataReader.GetString(44);
			}
			if (dataReader.IsDBNull(45) == false) {
				tbl_genItemMaster.IsFinishGood = dataReader.GetBoolean(45);
			}
			if (dataReader.IsDBNull(46) == false) {
				tbl_genItemMaster.IsSemiFinishGood = dataReader.GetBoolean(46);
			}
			if (dataReader.IsDBNull(47) == false) {
				tbl_genItemMaster.IsRawMeterial = dataReader.GetBoolean(47);
			}
			if (dataReader.IsDBNull(48) == false) {
				tbl_genItemMaster.IsAccessories = dataReader.GetBoolean(48);
			}
			if (dataReader.IsDBNull(49) == false) {
				tbl_genItemMaster.IsPackingMaterial = dataReader.GetBoolean(49);
			}
			if (dataReader.IsDBNull(50) == false) {
				tbl_genItemMaster.IsStationary = dataReader.GetBoolean(50);
			}
			if (dataReader.IsDBNull(51) == false) {
				tbl_genItemMaster.IsSalesItem = dataReader.GetBoolean(51);
			}
			if (dataReader.IsDBNull(52) == false) {
				tbl_genItemMaster.IsFixedAsset = dataReader.GetBoolean(52);
			}
			if (dataReader.IsDBNull(53) == false) {
				tbl_genItemMaster.IsGiftVoucher = dataReader.GetBoolean(53);
			}
			if (dataReader.IsDBNull(54) == false) {
				tbl_genItemMaster.IsOther = dataReader.GetBoolean(54);
			}
			if (dataReader.IsDBNull(55) == false) {
				tbl_genItemMaster.Asset_GL_ID = dataReader.GetString(55);
			}
			if (dataReader.IsDBNull(56) == false) {
				tbl_genItemMaster.AssetPrefix = dataReader.GetString(56);
			}
			if (dataReader.IsDBNull(57) == false) {
				tbl_genItemMaster.Counter = dataReader.GetInt32(57);
			}
			if (dataReader.IsDBNull(58) == false) {
				tbl_genItemMaster.ControlAcc = dataReader.GetString(58);
			}
			if (dataReader.IsDBNull(59) == false)
			{
				tbl_genItemMaster.isBlackList = dataReader.GetBoolean(59);
			}
			if (dataReader.IsDBNull(60) == false)
			{
				tbl_genItemMaster.store_ID = dataReader.GetString(60);
			}
			if (dataReader.IsDBNull(60) == false)
			{
				tbl_genItemMaster.ImageStatus = dataReader.GetString(61);
			}
			return tbl_genItemMaster;
		}
		/// <summary>
		/// This makes tbl_genItemMaster datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_genItemMaster object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_genItemMaster  tbl_genItemMaster   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_item_ID = new DataColumn("item_ID" , typeof(string));
			DataColumn col_generateCode = new DataColumn("generateCode" , typeof(string));
			DataColumn col_itemName = new DataColumn("itemName" , typeof(string));
			DataColumn col_description = new DataColumn("description" , typeof(string));
			DataColumn col_description1 = new DataColumn("description1" , typeof(string));
			DataColumn col_itemHS_code = new DataColumn("itemHS_code" , typeof(string));
			DataColumn col_remark = new DataColumn("remark" , typeof(string));
			DataColumn col_origin = new DataColumn("origin" , typeof(string));
			DataColumn col_minStockLevel = new DataColumn("minStockLevel" , typeof(decimal));
			DataColumn col_maxStockLevel = new DataColumn("maxStockLevel" , typeof(decimal));
			DataColumn col_reReoverLevel = new DataColumn("reReoverLevel" , typeof(decimal));
			DataColumn col_reOrderQty = new DataColumn("reOrderQty" , typeof(decimal));
			DataColumn col_isTIEPItem = new DataColumn("isTIEPItem" , typeof(bool));
			DataColumn col_isImportItem = new DataColumn("isImportItem" , typeof(bool));
			DataColumn col_isExportSalesItem = new DataColumn("isExportSalesItem" , typeof(bool));
			DataColumn col_isCombinationMaterail = new DataColumn("isCombinationMaterail" , typeof(bool));
			DataColumn col_isServiceItem = new DataColumn("isServiceItem" , typeof(bool));
			DataColumn col_itemCategorySub_ID = new DataColumn("itemCategorySub_ID" , typeof(string));
			DataColumn col_itemCategory_ID = new DataColumn("itemCategory_ID" , typeof(string));
			DataColumn col_itemClass_ID = new DataColumn("itemClass_ID" , typeof(string));
			DataColumn col_itemType_ID = new DataColumn("itemType_ID" , typeof(string));
			DataColumn col_roleType_ID = new DataColumn("roleType_ID" , typeof(string));
			DataColumn col_brand_ID = new DataColumn("brand_ID" , typeof(string));
			DataColumn col_subItem_ID = new DataColumn("subItem_ID" , typeof(string));
			DataColumn col_uom_ID = new DataColumn("uom_ID" , typeof(string));
			DataColumn col_width = new DataColumn("width" , typeof(decimal));
			DataColumn col_height = new DataColumn("height" , typeof(decimal));
			DataColumn col_thickness = new DataColumn("thickness" , typeof(decimal));
			DataColumn col_gusset = new DataColumn("gusset" , typeof(decimal));
			DataColumn col_qty = new DataColumn("qty" , typeof(decimal));
			DataColumn col_calculationRate_Weight = new DataColumn("calculationRate_Weight" , typeof(decimal));
			DataColumn col_calculationRate_LFeet = new DataColumn("calculationRate_LFeet" , typeof(decimal));
			DataColumn col_measureType_ID = new DataColumn("measureType_ID" , typeof(string));
			DataColumn col_isWeightCalculation_Sales = new DataColumn("isWeightCalculation_Sales" , typeof(bool));
			DataColumn col_isWeightCalculation_Purchase = new DataColumn("isWeightCalculation_Purchase" , typeof(bool));
			DataColumn col_isDeleted = new DataColumn("isDeleted" , typeof(bool));
			DataColumn col_isVatinclusive = new DataColumn("isVatinclusive" , typeof(bool));
			DataColumn col_isNBTinclusive = new DataColumn("isNBTinclusive" , typeof(bool));
			DataColumn col_imagePath = new DataColumn("imagePath" , typeof(string));
			DataColumn col_itemModel1 = new DataColumn("itemModel1" , typeof(bool));
			DataColumn col_itemModel2 = new DataColumn("itemModel2" , typeof(bool));
			DataColumn col_companyID = new DataColumn("companyID" , typeof(string));
			DataColumn col_companyBranch_ID = new DataColumn("companyBranch_ID" , typeof(string));
			DataColumn col_tag1_ID = new DataColumn("tag1_ID" , typeof(string));
			DataColumn col_tag2_ID = new DataColumn("tag2_ID" , typeof(string));
			DataColumn col_isFinishGood = new DataColumn("isFinishGood" , typeof(bool));
			DataColumn col_isSemiFinishGood = new DataColumn("isSemiFinishGood" , typeof(bool));
			DataColumn col_isRawMeterial = new DataColumn("isRawMeterial" , typeof(bool));
			DataColumn col_isAccessories = new DataColumn("isAccessories" , typeof(bool));
			DataColumn col_isPackingMaterial = new DataColumn("isPackingMaterial" , typeof(bool));
			DataColumn col_isStationary = new DataColumn("isStationary" , typeof(bool));
			DataColumn col_isSalesItem = new DataColumn("isSalesItem" , typeof(bool));
			DataColumn col_isFixedAsset = new DataColumn("isFixedAsset" , typeof(bool));
			DataColumn col_isGiftVoucher = new DataColumn("isGiftVoucher" , typeof(bool));
			DataColumn col_isOther = new DataColumn("isOther" , typeof(bool));
			DataColumn col_asset_GL_ID = new DataColumn("asset_GL_ID" , typeof(string));
			DataColumn col_assetPrefix = new DataColumn("assetPrefix" , typeof(string));
			DataColumn col_counter = new DataColumn("counter" , typeof(int));
			DataColumn col_controlAcc = new DataColumn("controlAcc" , typeof(string));
		dt.Columns.AddRange(new DataColumn[] { col_item_ID,col_generateCode,col_itemName,col_description,col_description1,col_itemHS_code,col_remark,col_origin,col_minStockLevel,col_maxStockLevel,col_reReoverLevel,col_reOrderQty,col_isTIEPItem,col_isImportItem,col_isExportSalesItem,col_isCombinationMaterail,col_isServiceItem,col_itemCategorySub_ID,col_itemCategory_ID,col_itemClass_ID,col_itemType_ID,col_roleType_ID,col_brand_ID,col_subItem_ID,col_uom_ID,col_width,col_height,col_thickness,col_gusset,col_qty,col_calculationRate_Weight,col_calculationRate_LFeet,col_measureType_ID,col_isWeightCalculation_Sales,col_isWeightCalculation_Purchase,col_isDeleted,col_isVatinclusive,col_isNBTinclusive,col_imagePath,col_itemModel1,col_itemModel2,col_companyID,col_companyBranch_ID,col_tag1_ID,col_tag2_ID,col_isFinishGood,col_isSemiFinishGood,col_isRawMeterial,col_isAccessories,col_isPackingMaterial,col_isStationary,col_isSalesItem,col_isFixedAsset,col_isGiftVoucher,col_isOther,col_asset_GL_ID,col_assetPrefix,col_counter,col_controlAcc,});		return dt;
		}
		/// <summary>
		/// This fills tbl_genItemMaster datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_genItemMaster object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_genItemMaster user) {
		DataRow drow = dt.NewRow();
		
			drow["item_ID"] = user.item_ID;
			drow["generateCode"] = user.generateCode;
			drow["itemName"] = user.itemName;
			drow["description"] = user.description;
			drow["description1"] = user.description1;
			drow["itemHS_code"] = user.itemHS_code;
			drow["remark"] = user.remark;
			drow["origin"] = user.origin;
			drow["minStockLevel"] = user.minStockLevel;
			drow["maxStockLevel"] = user.maxStockLevel;
			drow["reReoverLevel"] = user.reReoverLevel;
			drow["reOrderQty"] = user.reOrderQty;
			drow["isTIEPItem"] = user.isTIEPItem;
			drow["isImportItem"] = user.isImportItem;
			drow["isExportSalesItem"] = user.isExportSalesItem;
			drow["isCombinationMaterail"] = user.isCombinationMaterail;
			drow["isServiceItem"] = user.isServiceItem;
			drow["itemCategorySub_ID"] = user.itemCategorySub_ID;
			drow["itemCategory_ID"] = user.itemCategory_ID;
			drow["itemClass_ID"] = user.itemClass_ID;
			drow["itemType_ID"] = user.itemType_ID;
			drow["roleType_ID"] = user.roleType_ID;
			drow["brand_ID"] = user.brand_ID;
			drow["subItem_ID"] = user.subItem_ID;
			drow["uom_ID"] = user.uom_ID;
			drow["width"] = user.width;
			drow["height"] = user.height;
			drow["thickness"] = user.thickness;
			drow["gusset"] = user.gusset;
			drow["qty"] = user.qty;
			drow["calculationRate_Weight"] = user.calculationRate_Weight;
			drow["calculationRate_LFeet"] = user.calculationRate_LFeet;
			drow["measureType_ID"] = user.measureType_ID;
			drow["isWeightCalculation_Sales"] = user.isWeightCalculation_Sales;
			drow["isWeightCalculation_Purchase"] = user.isWeightCalculation_Purchase;
			drow["isDeleted"] = user.isDeleted;
			drow["isVatinclusive"] = user.isVatinclusive;
			drow["isNBTinclusive"] = user.isNBTinclusive;
			drow["imagePath"] = user.imagePath;
			drow["itemModel1"] = user.itemModel1;
			drow["itemModel2"] = user.itemModel2;
			drow["companyID"] = user.companyID;
			drow["companyBranch_ID"] = user.companyBranch_ID;
			drow["tag1_ID"] = user.tag1_ID;
			drow["tag2_ID"] = user.tag2_ID;
			drow["isFinishGood"] = user.isFinishGood;
			drow["isSemiFinishGood"] = user.isSemiFinishGood;
			drow["isRawMeterial"] = user.isRawMeterial;
			drow["isAccessories"] = user.isAccessories;
			drow["isPackingMaterial"] = user.isPackingMaterial;
			drow["isStationary"] = user.isStationary;
			drow["isSalesItem"] = user.isSalesItem;
			drow["isFixedAsset"] = user.isFixedAsset;
			drow["isGiftVoucher"] = user.isGiftVoucher;
			drow["isOther"] = user.isOther;
			drow["asset_GL_ID"] = user.asset_GL_ID;
			drow["assetPrefix"] = user.assetPrefix;
			drow["counter"] = user.counter;
			drow["controlAcc"] = user.controlAcc;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
