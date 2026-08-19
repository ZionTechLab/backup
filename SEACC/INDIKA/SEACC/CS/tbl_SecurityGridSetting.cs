using DataTire;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataTire {
	public sealed class tbl_SecurityGridSetting {
		#region Fields
		private string formID;
		private bool isShowItemCode;
		private bool isShowItemSerialNo;
		private bool isShowDeliveryOrderCode;
		private bool isShowCustomerOrderCode;
		private bool isShowQuotation;
		private bool isShowJobCode;
		private bool isShowItemDescriotion;
		private bool isShowCategoryName;
		private bool isShowItemSubCategory;
		private bool isShowItemSerialNo2;
		private bool isShowRemark;
		private bool isShowWidth;
		private bool isShowLength;
		private bool isShowGauge;
		private bool isShowGusset;
		private bool isShowUom;
		private bool isShowQuantity;
		private bool isShowUnitPrice;
		private bool isShowWeigtht;
		private bool isShowWeightPrice;
		private bool isShowAmount;
		private decimal itemCodeWidth;
		private decimal serialCodeWidth;
		private decimal deliveryOrderCodeWidth;
		private decimal customerOrderNoWidth;
		private decimal quotationWidth;
		private decimal jobCodeWidth;
		private decimal itemDescriptionWidth;
		private decimal categoryNameWidth;
		private decimal itemSubCategoryID2Width;
		private decimal itemSerialNo2Width;
		private decimal remarksWidth;
		private decimal widthWidth;
		private decimal lengthWidth;
		private decimal gaugeWidth;
		private decimal gussetWidth;
		private decimal uomWidth;
		private decimal quantityWidth;
		private decimal unitPriceWidth;
		private decimal weightWidth;
		private decimal weightPriceWidth;
		private decimal amountWidth;
		#endregion
		
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the tbl_SecurityGridSetting class.
		/// </summary>
		public tbl_SecurityGridSetting() {
		}
		
		/// <summary>
		/// Initializes a new instance of the tbl_SecurityGridSetting class.
		/// </summary>
		public tbl_SecurityGridSetting(string formID, bool isShowItemCode, bool isShowItemSerialNo, bool isShowDeliveryOrderCode, bool isShowCustomerOrderCode, bool isShowQuotation, bool isShowJobCode, bool isShowItemDescriotion, bool isShowCategoryName, bool isShowItemSubCategory, bool isShowItemSerialNo2, bool isShowRemark, bool isShowWidth, bool isShowLength, bool isShowGauge, bool isShowGusset, bool isShowUom, bool isShowQuantity, bool isShowUnitPrice, bool isShowWeigtht, bool isShowWeightPrice, bool isShowAmount, decimal itemCodeWidth, decimal serialCodeWidth, decimal deliveryOrderCodeWidth, decimal customerOrderNoWidth, decimal quotationWidth, decimal jobCodeWidth, decimal itemDescriptionWidth, decimal categoryNameWidth, decimal itemSubCategoryID2Width, decimal itemSerialNo2Width, decimal remarksWidth, decimal widthWidth, decimal lengthWidth, decimal gaugeWidth, decimal gussetWidth, decimal uomWidth, decimal quantityWidth, decimal unitPriceWidth, decimal weightWidth, decimal weightPriceWidth, decimal amountWidth) {
			this.formID = formID;
			this.isShowItemCode = isShowItemCode;
			this.isShowItemSerialNo = isShowItemSerialNo;
			this.isShowDeliveryOrderCode = isShowDeliveryOrderCode;
			this.isShowCustomerOrderCode = isShowCustomerOrderCode;
			this.isShowQuotation = isShowQuotation;
			this.isShowJobCode = isShowJobCode;
			this.isShowItemDescriotion = isShowItemDescriotion;
			this.isShowCategoryName = isShowCategoryName;
			this.isShowItemSubCategory = isShowItemSubCategory;
			this.isShowItemSerialNo2 = isShowItemSerialNo2;
			this.isShowRemark = isShowRemark;
			this.isShowWidth = isShowWidth;
			this.isShowLength = isShowLength;
			this.isShowGauge = isShowGauge;
			this.isShowGusset = isShowGusset;
			this.isShowUom = isShowUom;
			this.isShowQuantity = isShowQuantity;
			this.isShowUnitPrice = isShowUnitPrice;
			this.isShowWeigtht = isShowWeigtht;
			this.isShowWeightPrice = isShowWeightPrice;
			this.isShowAmount = isShowAmount;
			this.itemCodeWidth = itemCodeWidth;
			this.serialCodeWidth = serialCodeWidth;
			this.deliveryOrderCodeWidth = deliveryOrderCodeWidth;
			this.customerOrderNoWidth = customerOrderNoWidth;
			this.quotationWidth = quotationWidth;
			this.jobCodeWidth = jobCodeWidth;
			this.itemDescriptionWidth = itemDescriptionWidth;
			this.categoryNameWidth = categoryNameWidth;
			this.itemSubCategoryID2Width = itemSubCategoryID2Width;
			this.itemSerialNo2Width = itemSerialNo2Width;
			this.remarksWidth = remarksWidth;
			this.widthWidth = widthWidth;
			this.lengthWidth = lengthWidth;
			this.gaugeWidth = gaugeWidth;
			this.gussetWidth = gussetWidth;
			this.uomWidth = uomWidth;
			this.quantityWidth = quantityWidth;
			this.unitPriceWidth = unitPriceWidth;
			this.weightWidth = weightWidth;
			this.weightPriceWidth = weightPriceWidth;
			this.amountWidth = amountWidth;
		}
		#endregion
		
		#region Properties
		/// <summary>
		/// Gets or sets the FormID value.
		/// </summary>
		public string FormID {
			get { return formID; }
			set { formID = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowItemCode value.
		/// </summary>
		public bool IsShowItemCode {
			get { return isShowItemCode; }
			set { isShowItemCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowItemSerialNo value.
		/// </summary>
		public bool IsShowItemSerialNo {
			get { return isShowItemSerialNo; }
			set { isShowItemSerialNo = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowDeliveryOrderCode value.
		/// </summary>
		public bool IsShowDeliveryOrderCode {
			get { return isShowDeliveryOrderCode; }
			set { isShowDeliveryOrderCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowCustomerOrderCode value.
		/// </summary>
		public bool IsShowCustomerOrderCode {
			get { return isShowCustomerOrderCode; }
			set { isShowCustomerOrderCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowQuotation value.
		/// </summary>
		public bool IsShowQuotation {
			get { return isShowQuotation; }
			set { isShowQuotation = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowJobCode value.
		/// </summary>
		public bool IsShowJobCode {
			get { return isShowJobCode; }
			set { isShowJobCode = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowItemDescriotion value.
		/// </summary>
		public bool IsShowItemDescriotion {
			get { return isShowItemDescriotion; }
			set { isShowItemDescriotion = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowCategoryName value.
		/// </summary>
		public bool IsShowCategoryName {
			get { return isShowCategoryName; }
			set { isShowCategoryName = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowItemSubCategory value.
		/// </summary>
		public bool IsShowItemSubCategory {
			get { return isShowItemSubCategory; }
			set { isShowItemSubCategory = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowItemSerialNo2 value.
		/// </summary>
		public bool IsShowItemSerialNo2 {
			get { return isShowItemSerialNo2; }
			set { isShowItemSerialNo2 = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowRemark value.
		/// </summary>
		public bool IsShowRemark {
			get { return isShowRemark; }
			set { isShowRemark = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowWidth value.
		/// </summary>
		public bool IsShowWidth {
			get { return isShowWidth; }
			set { isShowWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowLength value.
		/// </summary>
		public bool IsShowLength {
			get { return isShowLength; }
			set { isShowLength = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowGauge value.
		/// </summary>
		public bool IsShowGauge {
			get { return isShowGauge; }
			set { isShowGauge = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowGusset value.
		/// </summary>
		public bool IsShowGusset {
			get { return isShowGusset; }
			set { isShowGusset = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowUom value.
		/// </summary>
		public bool IsShowUom {
			get { return isShowUom; }
			set { isShowUom = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowQuantity value.
		/// </summary>
		public bool IsShowQuantity {
			get { return isShowQuantity; }
			set { isShowQuantity = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowUnitPrice value.
		/// </summary>
		public bool IsShowUnitPrice {
			get { return isShowUnitPrice; }
			set { isShowUnitPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowWeigtht value.
		/// </summary>
		public bool IsShowWeigtht {
			get { return isShowWeigtht; }
			set { isShowWeigtht = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowWeightPrice value.
		/// </summary>
		public bool IsShowWeightPrice {
			get { return isShowWeightPrice; }
			set { isShowWeightPrice = value; }
		}
		
		/// <summary>
		/// Gets or sets the IsShowAmount value.
		/// </summary>
		public bool IsShowAmount {
			get { return isShowAmount; }
			set { isShowAmount = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemCodeWidth value.
		/// </summary>
		public decimal ItemCodeWidth {
			get { return itemCodeWidth; }
			set { itemCodeWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the SerialCodeWidth value.
		/// </summary>
		public decimal SerialCodeWidth {
			get { return serialCodeWidth; }
			set { serialCodeWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the DeliveryOrderCodeWidth value.
		/// </summary>
		public decimal DeliveryOrderCodeWidth {
			get { return deliveryOrderCodeWidth; }
			set { deliveryOrderCodeWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the CustomerOrderNoWidth value.
		/// </summary>
		public decimal CustomerOrderNoWidth {
			get { return customerOrderNoWidth; }
			set { customerOrderNoWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the QuotationWidth value.
		/// </summary>
		public decimal QuotationWidth {
			get { return quotationWidth; }
			set { quotationWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the JobCodeWidth value.
		/// </summary>
		public decimal JobCodeWidth {
			get { return jobCodeWidth; }
			set { jobCodeWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemDescriptionWidth value.
		/// </summary>
		public decimal ItemDescriptionWidth {
			get { return itemDescriptionWidth; }
			set { itemDescriptionWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the CategoryNameWidth value.
		/// </summary>
		public decimal CategoryNameWidth {
			get { return categoryNameWidth; }
			set { categoryNameWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSubCategoryID2Width value.
		/// </summary>
		public decimal ItemSubCategoryID2Width {
			get { return itemSubCategoryID2Width; }
			set { itemSubCategoryID2Width = value; }
		}
		
		/// <summary>
		/// Gets or sets the ItemSerialNo2Width value.
		/// </summary>
		public decimal ItemSerialNo2Width {
			get { return itemSerialNo2Width; }
			set { itemSerialNo2Width = value; }
		}
		
		/// <summary>
		/// Gets or sets the RemarksWidth value.
		/// </summary>
		public decimal RemarksWidth {
			get { return remarksWidth; }
			set { remarksWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the WidthWidth value.
		/// </summary>
		public decimal WidthWidth {
			get { return widthWidth; }
			set { widthWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the LengthWidth value.
		/// </summary>
		public decimal LengthWidth {
			get { return lengthWidth; }
			set { lengthWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the GaugeWidth value.
		/// </summary>
		public decimal GaugeWidth {
			get { return gaugeWidth; }
			set { gaugeWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the GussetWidth value.
		/// </summary>
		public decimal GussetWidth {
			get { return gussetWidth; }
			set { gussetWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the UomWidth value.
		/// </summary>
		public decimal UomWidth {
			get { return uomWidth; }
			set { uomWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the QuantityWidth value.
		/// </summary>
		public decimal QuantityWidth {
			get { return quantityWidth; }
			set { quantityWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the UnitPriceWidth value.
		/// </summary>
		public decimal UnitPriceWidth {
			get { return unitPriceWidth; }
			set { unitPriceWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightWidth value.
		/// </summary>
		public decimal WeightWidth {
			get { return weightWidth; }
			set { weightWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the WeightPriceWidth value.
		/// </summary>
		public decimal WeightPriceWidth {
			get { return weightPriceWidth; }
			set { weightPriceWidth = value; }
		}
		
		/// <summary>
		/// Gets or sets the AmountWidth value.
		/// </summary>
		public decimal AmountWidth {
			get { return amountWidth; }
			set { amountWidth = value; }
		}
		#endregion
		
		#region Methods
		/// <summary>
		/// Saves a record to the tbl_SecurityGridSetting table.
		/// </summary>
		public void Insert() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_SecurityGridSettingInsert", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@FormID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isShowItemCode", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowItemSerialNo", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowDeliveryOrderCode", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowCustomerOrderCode", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowQuotation", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowJobCode", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowItemDescriotion", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowCategoryName", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowItemSubCategory", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowItemSerialNo2", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowRemark", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowWidth", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowLength", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowGauge", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowGusset", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowUom", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowQuantity", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowUnitPrice", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowWeigtht", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowWeightPrice", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowAmount", SqlDbType.Bit,1);
			scom.Parameters.Add("@itemCodeWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@serialCodeWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deliveryOrderCodeWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customerOrderNoWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@quotationWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@jobCodeWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ItemDescriptionWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@categoryNameWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@itemSubCategoryID2Width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@itemSerialNo2Width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remarksWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@widthWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lengthWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gaugeWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gussetWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uomWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@quantityWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPriceWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPriceWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amountWidth", SqlDbType.Decimal,9);
 
			scom.Parameters["@FormID"].Value = formID;
			scom.Parameters["@isShowItemCode"].Value = isShowItemCode;
			scom.Parameters["@isShowItemSerialNo"].Value = isShowItemSerialNo;
			scom.Parameters["@isShowDeliveryOrderCode"].Value = isShowDeliveryOrderCode;
			scom.Parameters["@isShowCustomerOrderCode"].Value = isShowCustomerOrderCode;
			scom.Parameters["@isShowQuotation"].Value = isShowQuotation;
			scom.Parameters["@isShowJobCode"].Value = isShowJobCode;
			scom.Parameters["@isShowItemDescriotion"].Value = isShowItemDescriotion;
			scom.Parameters["@isShowCategoryName"].Value = isShowCategoryName;
			scom.Parameters["@isShowItemSubCategory"].Value = isShowItemSubCategory;
			scom.Parameters["@isShowItemSerialNo2"].Value = isShowItemSerialNo2;
			scom.Parameters["@isShowRemark"].Value = isShowRemark;
			scom.Parameters["@isShowWidth"].Value = isShowWidth;
			scom.Parameters["@isShowLength"].Value = isShowLength;
			scom.Parameters["@isShowGauge"].Value = isShowGauge;
			scom.Parameters["@isShowGusset"].Value = isShowGusset;
			scom.Parameters["@isShowUom"].Value = isShowUom;
			scom.Parameters["@isShowQuantity"].Value = isShowQuantity;
			scom.Parameters["@isShowUnitPrice"].Value = isShowUnitPrice;
			scom.Parameters["@isShowWeigtht"].Value = isShowWeigtht;
			scom.Parameters["@isShowWeightPrice"].Value = isShowWeightPrice;
			scom.Parameters["@isShowAmount"].Value = isShowAmount;
			scom.Parameters["@itemCodeWidth"].Value = itemCodeWidth;
			scom.Parameters["@serialCodeWidth"].Value = serialCodeWidth;
			scom.Parameters["@deliveryOrderCodeWidth"].Value = deliveryOrderCodeWidth;
			scom.Parameters["@customerOrderNoWidth"].Value = customerOrderNoWidth;
			scom.Parameters["@quotationWidth"].Value = quotationWidth;
			scom.Parameters["@jobCodeWidth"].Value = jobCodeWidth;
			scom.Parameters["@ItemDescriptionWidth"].Value = itemDescriptionWidth;
			scom.Parameters["@categoryNameWidth"].Value = categoryNameWidth;
			scom.Parameters["@itemSubCategoryID2Width"].Value = itemSubCategoryID2Width;
			scom.Parameters["@itemSerialNo2Width"].Value = itemSerialNo2Width;
			scom.Parameters["@remarksWidth"].Value = remarksWidth;
			scom.Parameters["@widthWidth"].Value = widthWidth;
			scom.Parameters["@lengthWidth"].Value = lengthWidth;
			scom.Parameters["@gaugeWidth"].Value = gaugeWidth;
			scom.Parameters["@gussetWidth"].Value = gussetWidth;
			scom.Parameters["@uomWidth"].Value = uomWidth;
			scom.Parameters["@quantityWidth"].Value = quantityWidth;
			scom.Parameters["@unitPriceWidth"].Value = unitPriceWidth;
			scom.Parameters["@weightWidth"].Value = weightWidth;
			scom.Parameters["@weightPriceWidth"].Value = weightPriceWidth;
			scom.Parameters["@amountWidth"].Value = amountWidth;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Updates a record in the tbl_SecurityGridSetting table.
		/// </summary>
		public void Update() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_SecurityGridSettingUpdate", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
 
			scom.Parameters.Add("@FormID", SqlDbType.VarChar,10);
			scom.Parameters.Add("@isShowItemCode", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowItemSerialNo", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowDeliveryOrderCode", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowCustomerOrderCode", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowQuotation", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowJobCode", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowItemDescriotion", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowCategoryName", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowItemSubCategory", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowItemSerialNo2", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowRemark", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowWidth", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowLength", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowGauge", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowGusset", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowUom", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowQuantity", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowUnitPrice", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowWeigtht", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowWeightPrice", SqlDbType.Bit,1);
			scom.Parameters.Add("@isShowAmount", SqlDbType.Bit,1);
			scom.Parameters.Add("@itemCodeWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@serialCodeWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@deliveryOrderCodeWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@customerOrderNoWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@quotationWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@jobCodeWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@ItemDescriptionWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@categoryNameWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@itemSubCategoryID2Width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@itemSerialNo2Width", SqlDbType.Decimal,9);
			scom.Parameters.Add("@remarksWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@widthWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@lengthWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gaugeWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@gussetWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@uomWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@quantityWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@unitPriceWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@weightPriceWidth", SqlDbType.Decimal,9);
			scom.Parameters.Add("@amountWidth", SqlDbType.Decimal,9);
 
 
			scom.Parameters["@FormID"].Value = formID;
			scom.Parameters["@isShowItemCode"].Value = isShowItemCode;
			scom.Parameters["@isShowItemSerialNo"].Value = isShowItemSerialNo;
			scom.Parameters["@isShowDeliveryOrderCode"].Value = isShowDeliveryOrderCode;
			scom.Parameters["@isShowCustomerOrderCode"].Value = isShowCustomerOrderCode;
			scom.Parameters["@isShowQuotation"].Value = isShowQuotation;
			scom.Parameters["@isShowJobCode"].Value = isShowJobCode;
			scom.Parameters["@isShowItemDescriotion"].Value = isShowItemDescriotion;
			scom.Parameters["@isShowCategoryName"].Value = isShowCategoryName;
			scom.Parameters["@isShowItemSubCategory"].Value = isShowItemSubCategory;
			scom.Parameters["@isShowItemSerialNo2"].Value = isShowItemSerialNo2;
			scom.Parameters["@isShowRemark"].Value = isShowRemark;
			scom.Parameters["@isShowWidth"].Value = isShowWidth;
			scom.Parameters["@isShowLength"].Value = isShowLength;
			scom.Parameters["@isShowGauge"].Value = isShowGauge;
			scom.Parameters["@isShowGusset"].Value = isShowGusset;
			scom.Parameters["@isShowUom"].Value = isShowUom;
			scom.Parameters["@isShowQuantity"].Value = isShowQuantity;
			scom.Parameters["@isShowUnitPrice"].Value = isShowUnitPrice;
			scom.Parameters["@isShowWeigtht"].Value = isShowWeigtht;
			scom.Parameters["@isShowWeightPrice"].Value = isShowWeightPrice;
			scom.Parameters["@isShowAmount"].Value = isShowAmount;
			scom.Parameters["@itemCodeWidth"].Value = itemCodeWidth;
			scom.Parameters["@serialCodeWidth"].Value = serialCodeWidth;
			scom.Parameters["@deliveryOrderCodeWidth"].Value = deliveryOrderCodeWidth;
			scom.Parameters["@customerOrderNoWidth"].Value = customerOrderNoWidth;
			scom.Parameters["@quotationWidth"].Value = quotationWidth;
			scom.Parameters["@jobCodeWidth"].Value = jobCodeWidth;
			scom.Parameters["@ItemDescriptionWidth"].Value = itemDescriptionWidth;
			scom.Parameters["@categoryNameWidth"].Value = categoryNameWidth;
			scom.Parameters["@itemSubCategoryID2Width"].Value = itemSubCategoryID2Width;
			scom.Parameters["@itemSerialNo2Width"].Value = itemSerialNo2Width;
			scom.Parameters["@remarksWidth"].Value = remarksWidth;
			scom.Parameters["@widthWidth"].Value = widthWidth;
			scom.Parameters["@lengthWidth"].Value = lengthWidth;
			scom.Parameters["@gaugeWidth"].Value = gaugeWidth;
			scom.Parameters["@gussetWidth"].Value = gussetWidth;
			scom.Parameters["@uomWidth"].Value = uomWidth;
			scom.Parameters["@quantityWidth"].Value = quantityWidth;
			scom.Parameters["@unitPriceWidth"].Value = unitPriceWidth;
			scom.Parameters["@weightWidth"].Value = weightWidth;
			scom.Parameters["@weightPriceWidth"].Value = weightPriceWidth;
			scom.Parameters["@amountWidth"].Value = amountWidth;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Deletes a record from the tbl_SecurityGridSetting table by its primary key.
		/// </summary>
		public void Delete() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_SecurityGridSettingDelete", scon);
			scom.CommandType = CommandType.StoredProcedure;
 
			scom.Parameters.Add("@FormID", SqlDbType.VarChar,10);
			scom.Parameters["@FormID"].Value = formID;
 
 
			scon.Open();
			scom.ExecuteNonQuery();
			scon.Close();
		}
		
		/// <summary>
		/// Selects a single record from the tbl_SecurityGridSetting table.
		/// </summary>
		public static tbl_SecurityGridSetting Select(string formID_Incoming){

			tbl_SecurityGridSetting tbl_SecurityGridSettingins = new tbl_SecurityGridSetting();
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_SecurityGridSettingSelect", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
			scom.Parameters.Add("@FormID", SqlDbType.VarChar,10);
			scom.Parameters["@FormID"].Value = formID_Incoming;
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				if (dataReader.Read()) {
					tbl_SecurityGridSettingins = Maketbl_SecurityGridSetting(dataReader);
				} else {
					tbl_SecurityGridSettingins = null;
				}
			}
			scon.Close();
			return tbl_SecurityGridSettingins;
		}
		
		/// <summary>
		/// Selects all records from the tbl_SecurityGridSetting table.
		/// </summary>
		public static List<tbl_SecurityGridSetting> SelectAll() {
 
			SqlConnection scon = DBHandling.GetConnection();
			SqlCommand scom = new SqlCommand("tbl_SecurityGridSettingSelectAll", scon);
			scom.CommandType = CommandType.StoredProcedure;
			scon.Open();
 
				List<tbl_SecurityGridSetting> tbl_SecurityGridSettingList = new List<tbl_SecurityGridSetting>();
			using (SqlDataReader dataReader = scom.ExecuteReader()){
				while (dataReader.Read()) {
					tbl_SecurityGridSetting tbl_SecurityGridSetting = Maketbl_SecurityGridSetting(dataReader);
					tbl_SecurityGridSettingList.Add(tbl_SecurityGridSetting);
				}
			}
			scon.Close();
			return tbl_SecurityGridSettingList;
		}
		
		/// <summary>
		/// Creates a new instance of the tbl_SecurityGridSetting class and populates it with data from the specified SqlDataReader.
		/// </summary>
		private static tbl_SecurityGridSetting Maketbl_SecurityGridSetting(SqlDataReader dataReader) {
			tbl_SecurityGridSetting tbl_SecurityGridSetting = new tbl_SecurityGridSetting();
			
			if (dataReader.IsDBNull(0) == false) {
				tbl_SecurityGridSetting.FormID = dataReader.GetString(0);
			}
			if (dataReader.IsDBNull(1) == false) {
				tbl_SecurityGridSetting.IsShowItemCode = dataReader.GetBoolean(1);
			}
			if (dataReader.IsDBNull(2) == false) {
				tbl_SecurityGridSetting.IsShowItemSerialNo = dataReader.GetBoolean(2);
			}
			if (dataReader.IsDBNull(3) == false) {
				tbl_SecurityGridSetting.IsShowDeliveryOrderCode = dataReader.GetBoolean(3);
			}
			if (dataReader.IsDBNull(4) == false) {
				tbl_SecurityGridSetting.IsShowCustomerOrderCode = dataReader.GetBoolean(4);
			}
			if (dataReader.IsDBNull(5) == false) {
				tbl_SecurityGridSetting.IsShowQuotation = dataReader.GetBoolean(5);
			}
			if (dataReader.IsDBNull(6) == false) {
				tbl_SecurityGridSetting.IsShowJobCode = dataReader.GetBoolean(6);
			}
			if (dataReader.IsDBNull(7) == false) {
				tbl_SecurityGridSetting.IsShowItemDescriotion = dataReader.GetBoolean(7);
			}
			if (dataReader.IsDBNull(8) == false) {
				tbl_SecurityGridSetting.IsShowCategoryName = dataReader.GetBoolean(8);
			}
			if (dataReader.IsDBNull(9) == false) {
				tbl_SecurityGridSetting.IsShowItemSubCategory = dataReader.GetBoolean(9);
			}
			if (dataReader.IsDBNull(10) == false) {
				tbl_SecurityGridSetting.IsShowItemSerialNo2 = dataReader.GetBoolean(10);
			}
			if (dataReader.IsDBNull(11) == false) {
				tbl_SecurityGridSetting.IsShowRemark = dataReader.GetBoolean(11);
			}
			if (dataReader.IsDBNull(12) == false) {
				tbl_SecurityGridSetting.IsShowWidth = dataReader.GetBoolean(12);
			}
			if (dataReader.IsDBNull(13) == false) {
				tbl_SecurityGridSetting.IsShowLength = dataReader.GetBoolean(13);
			}
			if (dataReader.IsDBNull(14) == false) {
				tbl_SecurityGridSetting.IsShowGauge = dataReader.GetBoolean(14);
			}
			if (dataReader.IsDBNull(15) == false) {
				tbl_SecurityGridSetting.IsShowGusset = dataReader.GetBoolean(15);
			}
			if (dataReader.IsDBNull(16) == false) {
				tbl_SecurityGridSetting.IsShowUom = dataReader.GetBoolean(16);
			}
			if (dataReader.IsDBNull(17) == false) {
				tbl_SecurityGridSetting.IsShowQuantity = dataReader.GetBoolean(17);
			}
			if (dataReader.IsDBNull(18) == false) {
				tbl_SecurityGridSetting.IsShowUnitPrice = dataReader.GetBoolean(18);
			}
			if (dataReader.IsDBNull(19) == false) {
				tbl_SecurityGridSetting.IsShowWeigtht = dataReader.GetBoolean(19);
			}
			if (dataReader.IsDBNull(20) == false) {
				tbl_SecurityGridSetting.IsShowWeightPrice = dataReader.GetBoolean(20);
			}
			if (dataReader.IsDBNull(21) == false) {
				tbl_SecurityGridSetting.IsShowAmount = dataReader.GetBoolean(21);
			}
			if (dataReader.IsDBNull(22) == false) {
				tbl_SecurityGridSetting.ItemCodeWidth = dataReader.GetDecimal(22);
			}
			if (dataReader.IsDBNull(23) == false) {
				tbl_SecurityGridSetting.SerialCodeWidth = dataReader.GetDecimal(23);
			}
			if (dataReader.IsDBNull(24) == false) {
				tbl_SecurityGridSetting.DeliveryOrderCodeWidth = dataReader.GetDecimal(24);
			}
			if (dataReader.IsDBNull(25) == false) {
				tbl_SecurityGridSetting.CustomerOrderNoWidth = dataReader.GetDecimal(25);
			}
			if (dataReader.IsDBNull(26) == false) {
				tbl_SecurityGridSetting.QuotationWidth = dataReader.GetDecimal(26);
			}
			if (dataReader.IsDBNull(27) == false) {
				tbl_SecurityGridSetting.JobCodeWidth = dataReader.GetDecimal(27);
			}
			if (dataReader.IsDBNull(28) == false) {
				tbl_SecurityGridSetting.ItemDescriptionWidth = dataReader.GetDecimal(28);
			}
			if (dataReader.IsDBNull(29) == false) {
				tbl_SecurityGridSetting.CategoryNameWidth = dataReader.GetDecimal(29);
			}
			if (dataReader.IsDBNull(30) == false) {
				tbl_SecurityGridSetting.ItemSubCategoryID2Width = dataReader.GetDecimal(30);
			}
			if (dataReader.IsDBNull(31) == false) {
				tbl_SecurityGridSetting.ItemSerialNo2Width = dataReader.GetDecimal(31);
			}
			if (dataReader.IsDBNull(32) == false) {
				tbl_SecurityGridSetting.RemarksWidth = dataReader.GetDecimal(32);
			}
			if (dataReader.IsDBNull(33) == false) {
				tbl_SecurityGridSetting.WidthWidth = dataReader.GetDecimal(33);
			}
			if (dataReader.IsDBNull(34) == false) {
				tbl_SecurityGridSetting.LengthWidth = dataReader.GetDecimal(34);
			}
			if (dataReader.IsDBNull(35) == false) {
				tbl_SecurityGridSetting.GaugeWidth = dataReader.GetDecimal(35);
			}
			if (dataReader.IsDBNull(36) == false) {
				tbl_SecurityGridSetting.GussetWidth = dataReader.GetDecimal(36);
			}
			if (dataReader.IsDBNull(37) == false) {
				tbl_SecurityGridSetting.UomWidth = dataReader.GetDecimal(37);
			}
			if (dataReader.IsDBNull(38) == false) {
				tbl_SecurityGridSetting.QuantityWidth = dataReader.GetDecimal(38);
			}
			if (dataReader.IsDBNull(39) == false) {
				tbl_SecurityGridSetting.UnitPriceWidth = dataReader.GetDecimal(39);
			}
			if (dataReader.IsDBNull(40) == false) {
				tbl_SecurityGridSetting.WeightWidth = dataReader.GetDecimal(40);
			}
			if (dataReader.IsDBNull(41) == false) {
				tbl_SecurityGridSetting.WeightPriceWidth = dataReader.GetDecimal(41);
			}
			if (dataReader.IsDBNull(42) == false) {
				tbl_SecurityGridSetting.AmountWidth = dataReader.GetDecimal(42);
			}

			return tbl_SecurityGridSetting;
		}
		/// <summary>
		/// This makes tbl_SecurityGridSetting datatable according to the datatable.
		/// IMPORTANT: you have to change the Column names according to your disire. becouse we cannot change it to your fit
		///            We are still humans
		/// </summary>
		/// <param name="user">new tbl_SecurityGridSetting object</param>
		/// <returns></returns>
		public static DataTable CreateDataTable( tbl_SecurityGridSetting  tbl_SecurityGridSetting   )
		{
		DataTable dt = new DataTable();
		
			DataColumn col_FormID = new DataColumn("FormID" , typeof(string));
			DataColumn col_isShowItemCode = new DataColumn("isShowItemCode" , typeof(bool));
			DataColumn col_isShowItemSerialNo = new DataColumn("isShowItemSerialNo" , typeof(bool));
			DataColumn col_isShowDeliveryOrderCode = new DataColumn("isShowDeliveryOrderCode" , typeof(bool));
			DataColumn col_isShowCustomerOrderCode = new DataColumn("isShowCustomerOrderCode" , typeof(bool));
			DataColumn col_isShowQuotation = new DataColumn("isShowQuotation" , typeof(bool));
			DataColumn col_isShowJobCode = new DataColumn("isShowJobCode" , typeof(bool));
			DataColumn col_isShowItemDescriotion = new DataColumn("isShowItemDescriotion" , typeof(bool));
			DataColumn col_isShowCategoryName = new DataColumn("isShowCategoryName" , typeof(bool));
			DataColumn col_isShowItemSubCategory = new DataColumn("isShowItemSubCategory" , typeof(bool));
			DataColumn col_isShowItemSerialNo2 = new DataColumn("isShowItemSerialNo2" , typeof(bool));
			DataColumn col_isShowRemark = new DataColumn("isShowRemark" , typeof(bool));
			DataColumn col_isShowWidth = new DataColumn("isShowWidth" , typeof(bool));
			DataColumn col_isShowLength = new DataColumn("isShowLength" , typeof(bool));
			DataColumn col_isShowGauge = new DataColumn("isShowGauge" , typeof(bool));
			DataColumn col_isShowGusset = new DataColumn("isShowGusset" , typeof(bool));
			DataColumn col_isShowUom = new DataColumn("isShowUom" , typeof(bool));
			DataColumn col_isShowQuantity = new DataColumn("isShowQuantity" , typeof(bool));
			DataColumn col_isShowUnitPrice = new DataColumn("isShowUnitPrice" , typeof(bool));
			DataColumn col_isShowWeigtht = new DataColumn("isShowWeigtht" , typeof(bool));
			DataColumn col_isShowWeightPrice = new DataColumn("isShowWeightPrice" , typeof(bool));
			DataColumn col_isShowAmount = new DataColumn("isShowAmount" , typeof(bool));
			DataColumn col_itemCodeWidth = new DataColumn("itemCodeWidth" , typeof(decimal));
			DataColumn col_serialCodeWidth = new DataColumn("serialCodeWidth" , typeof(decimal));
			DataColumn col_deliveryOrderCodeWidth = new DataColumn("deliveryOrderCodeWidth" , typeof(decimal));
			DataColumn col_customerOrderNoWidth = new DataColumn("customerOrderNoWidth" , typeof(decimal));
			DataColumn col_quotationWidth = new DataColumn("quotationWidth" , typeof(decimal));
			DataColumn col_jobCodeWidth = new DataColumn("jobCodeWidth" , typeof(decimal));
			DataColumn col_ItemDescriptionWidth = new DataColumn("ItemDescriptionWidth" , typeof(decimal));
			DataColumn col_categoryNameWidth = new DataColumn("categoryNameWidth" , typeof(decimal));
			DataColumn col_itemSubCategoryID2Width = new DataColumn("itemSubCategoryID2Width" , typeof(decimal));
			DataColumn col_itemSerialNo2Width = new DataColumn("itemSerialNo2Width" , typeof(decimal));
			DataColumn col_remarksWidth = new DataColumn("remarksWidth" , typeof(decimal));
			DataColumn col_widthWidth = new DataColumn("widthWidth" , typeof(decimal));
			DataColumn col_lengthWidth = new DataColumn("lengthWidth" , typeof(decimal));
			DataColumn col_gaugeWidth = new DataColumn("gaugeWidth" , typeof(decimal));
			DataColumn col_gussetWidth = new DataColumn("gussetWidth" , typeof(decimal));
			DataColumn col_uomWidth = new DataColumn("uomWidth" , typeof(decimal));
			DataColumn col_quantityWidth = new DataColumn("quantityWidth" , typeof(decimal));
			DataColumn col_unitPriceWidth = new DataColumn("unitPriceWidth" , typeof(decimal));
			DataColumn col_weightWidth = new DataColumn("weightWidth" , typeof(decimal));
			DataColumn col_weightPriceWidth = new DataColumn("weightPriceWidth" , typeof(decimal));
			DataColumn col_amountWidth = new DataColumn("amountWidth" , typeof(decimal));
		dt.Columns.AddRange(new DataColumn[] { col_FormID,col_isShowItemCode,col_isShowItemSerialNo,col_isShowDeliveryOrderCode,col_isShowCustomerOrderCode,col_isShowQuotation,col_isShowJobCode,col_isShowItemDescriotion,col_isShowCategoryName,col_isShowItemSubCategory,col_isShowItemSerialNo2,col_isShowRemark,col_isShowWidth,col_isShowLength,col_isShowGauge,col_isShowGusset,col_isShowUom,col_isShowQuantity,col_isShowUnitPrice,col_isShowWeigtht,col_isShowWeightPrice,col_isShowAmount,col_itemCodeWidth,col_serialCodeWidth,col_deliveryOrderCodeWidth,col_customerOrderNoWidth,col_quotationWidth,col_jobCodeWidth,col_ItemDescriptionWidth,col_categoryNameWidth,col_itemSubCategoryID2Width,col_itemSerialNo2Width,col_remarksWidth,col_widthWidth,col_lengthWidth,col_gaugeWidth,col_gussetWidth,col_uomWidth,col_quantityWidth,col_unitPriceWidth,col_weightWidth,col_weightPriceWidth,col_amountWidth,});		return dt;
		}
		/// <summary>
		/// This fills tbl_SecurityGridSetting datatable according to the Given user list.
		/// </summary>
		/// <param name="user">new tbl_SecurityGridSetting object</param>
		/// <returns></returns>
		public static void FillData(DataTable dt, tbl_SecurityGridSetting user) {
		DataRow drow = dt.NewRow();
		
			drow["FormID"] = user.FormID;
			drow["isShowItemCode"] = user.isShowItemCode;
			drow["isShowItemSerialNo"] = user.isShowItemSerialNo;
			drow["isShowDeliveryOrderCode"] = user.isShowDeliveryOrderCode;
			drow["isShowCustomerOrderCode"] = user.isShowCustomerOrderCode;
			drow["isShowQuotation"] = user.isShowQuotation;
			drow["isShowJobCode"] = user.isShowJobCode;
			drow["isShowItemDescriotion"] = user.isShowItemDescriotion;
			drow["isShowCategoryName"] = user.isShowCategoryName;
			drow["isShowItemSubCategory"] = user.isShowItemSubCategory;
			drow["isShowItemSerialNo2"] = user.isShowItemSerialNo2;
			drow["isShowRemark"] = user.isShowRemark;
			drow["isShowWidth"] = user.isShowWidth;
			drow["isShowLength"] = user.isShowLength;
			drow["isShowGauge"] = user.isShowGauge;
			drow["isShowGusset"] = user.isShowGusset;
			drow["isShowUom"] = user.isShowUom;
			drow["isShowQuantity"] = user.isShowQuantity;
			drow["isShowUnitPrice"] = user.isShowUnitPrice;
			drow["isShowWeigtht"] = user.isShowWeigtht;
			drow["isShowWeightPrice"] = user.isShowWeightPrice;
			drow["isShowAmount"] = user.isShowAmount;
			drow["itemCodeWidth"] = user.itemCodeWidth;
			drow["serialCodeWidth"] = user.serialCodeWidth;
			drow["deliveryOrderCodeWidth"] = user.deliveryOrderCodeWidth;
			drow["customerOrderNoWidth"] = user.customerOrderNoWidth;
			drow["quotationWidth"] = user.quotationWidth;
			drow["jobCodeWidth"] = user.jobCodeWidth;
			drow["ItemDescriptionWidth"] = user.ItemDescriptionWidth;
			drow["categoryNameWidth"] = user.categoryNameWidth;
			drow["itemSubCategoryID2Width"] = user.itemSubCategoryID2Width;
			drow["itemSerialNo2Width"] = user.itemSerialNo2Width;
			drow["remarksWidth"] = user.remarksWidth;
			drow["widthWidth"] = user.widthWidth;
			drow["lengthWidth"] = user.lengthWidth;
			drow["gaugeWidth"] = user.gaugeWidth;
			drow["gussetWidth"] = user.gussetWidth;
			drow["uomWidth"] = user.uomWidth;
			drow["quantityWidth"] = user.quantityWidth;
			drow["unitPriceWidth"] = user.unitPriceWidth;
			drow["weightWidth"] = user.weightWidth;
			drow["weightPriceWidth"] = user.weightPriceWidth;
			drow["amountWidth"] = user.amountWidth;
		dt.Rows.Add(drow);
		}
		#endregion
	}
}
