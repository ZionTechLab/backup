using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTire;
using System.Drawing;

namespace Digiteq_Logic
{
    public class clsConfig
    {
        #region Config Values
        public static string sItemSubCategory = "";
        public static string sItemSubCategory2 = "";
        public static string sServerBackupFolder = "";
        public static string sAdminCategoryID = "";
        public static string sSoftwareModel = "";
        public static SoftwareModel_Sales SoftwareModel;
        public static string sWeightCalculation_Type = "";
        public static string sItemSearchType = "";
        public static string sSingleItemStockItemID = "";
        public static string sSingleItemStockItemSubCategoryID = "";
        public static string sSingleItemStockItemSubCategory2ID = "";
        public static string sSingleItemStockItemSerialNo = "";
        public static string sSingleItemStockItemSerialNo2 = "";

        public static int iTransactionId_MaxLength = 15;
        public static int iTransactionId_MinLength = 04;
        public static int iAutoChequeReconciliationDays = 100000;
        public static int sCurrencyDecimalPlaces_UnitPrice = 4;
        public static int sCurrencyDecimalPlaces_WeightPrice = 4;
        public static int sDecimalPlaces_Quantity = 2;
        public static int sDecimalPlaces_Weight = 2;

        //Maximum Quntity Exceeded
        public static string sMaximumQuntityExceededPercentage_localOrders = "";
        public static string sMaximumQuntityExceededPercentage_ExportOrders = "";

        public static string sMaximumQuntityExceededPercentage_localOrders_GRN = "";
        public static string sMaximumQuntityExceededPercentage_ExportOrders_GRN = "";

        //Currency
        public static string sLocalCurrencyCode = "";

        //petty cash cost centers
        public static string sCostCenter1 = "";
        public static string sCostCenter2 = "";
        public static string sCostCenter3 = "";
        public static string sCostCenter4 = "";

        //Damaged Goods Store
        public static string sDamagedGoodsStore = "";

        public static string sDefaultInvoiceSearch = "";

        public static int OutstaningReport_BackdateByMonth = 6;

        //Version
        public static string sVersion = "";

        public static string sDonglePortNo = "";

        //Backup
        public static string sSeaccBackupPath_Server = "";
        public static string sSeaccBackupPreFix = "";
        public static string sSeaccBackup_SourceFolder_1 = "";
        public static string sSeaccBackup_SourceFolder_2 = "";
        public static string sSeaccBackup_SourceFolder_3 = "";
        public static string sLastBackupedDate = "";
        public static string sAutoBackupPath = "";

        //Remort Desktop Printer
        public static string sRemortDesktopExportPath = "";

        //Accounts
        public static string sSubGLReduNumber = "";
        public static string sSubGLAddNumber = "";
        public static string sAcctTypeReduNumber = "";
        public static string sAcctTypeAddNumber = "";
        public static string sAcctCodeReduNumber = "";
        public static string sAcctCodeAddNumber = "";
        public static string sGLAddNumber = "";

        //ApN
        public static string sDefaultAPNTypeID = "";

        public static string sDAPL_GRN_Enable_BranchCode = "";
        public static string sGbl_Company_Code = "";
        public static string sGbl_SMS_Shared_Folder_Parth = "";

        public static DateTime dtmDateExpiration = DateTime.MaxValue;

        //Item Model
        public static string sItemModel1 = "";
        public static string sItemModel2 = "";

        //For Other Field 
        public static string bEnable_OtherTextBox_LoanOutForm = "";

        //For Multiple Discount 
        // public static string sDiscount1_Name = "";
        // public static string sDiscount2_Name = "";
        // public static string sDiscount3_Name = "";

        //For Item Selling Prices
        public static string sItemPrice1_Name = "";
        public static string sItemPrice2_Name = "";
        public static string sItemPrice3_Name = "";
        public static string sItemPrice4_Name = "";
        public static string sItemPrice5_Name = "";
        public static string sItemPrice6_Name = "";
        public static string sItemUnitPriceCode_Default = "";
        public static string sItemUnitPriceName_Default = "";
        public static string sItemWeightPriceCode_Default = "";
        public static string sItemWeightPriceName_Default = "";
        public static string sItemUnitPrice_Production = "";

        //For Item Cost Prices
        public static string sItemCostPriceName_Default = "";

        public static string sWeightedAvg_Percentage = "";

        //Last DO for SRN - total months
        public static string sTotalMonths_ForLastValidDO_ForSRN = "";

        public static string sCustomChequeFormat = "";

        public static string sAccountNo_RetainedEarnings = "";

        public static string sAccountCode_Discount = "";
        public static string sAccountCode_CostOfSales = "";
      //  public static string sAccountCode_RM_Inventry = "";

        public static string sInvoice_SalesAccount_Type = "";
        //get Financial year Start Month
        public static string sFinancialYear_StartMonth = "";

        public static string sAttachmentPath_Server = "";

        public static string sFixedAsset_MainStore = "";
        public static string sGl_id_ClosingStock = "";
        //intercompany transaction
        public static string accType_InterCompany;

        public static decimal bStockValidation_waTollarance;

        #region SEACC POS Configs
        //SEACC_POS
        public static string sFontName = "calibri";
        public static int FontSize = 14;
        public static string sDefaltBranchStoreID = "";
        public static string sImagePath = "";
        public static string sGiftVoucherCode = "";
        /* Added by Gayan  FOR SEACC POS */
        public static string sDefaultCashCustomerID = "";
        public static string sDefaultSalesNoteTypeID = "";
        public static string sDefaultSalesRep = "";
        public static string sPoS_SystemName = "";
        public static string sPOSAttachmentPath_Server = "";

        #endregion

        #region SEACC PRODUCTION
        #region PROD APPAREL
        public static string sProdApparel_AttachmentPath_Server = "";
        #endregion

        #region PROD PHARMA
        public static string sProd_Pharma_DefaultCostType = "2";
        public static string sProdPharma_AttachmentPath_Server = "";
        public static decimal dDataGrid_EditedQuantity_Validation_WithPecentage = -1;
        #endregion
        #endregion

        public static decimal dReturnChq_DeductionRate_SalesRep = 0.015m;
        public static decimal dReturnChq_DeductionRate_AreaMgr = 0.015m;
        public static decimal dReturnChq_DeductionRate_SalesMgr = 0.015m;
        public static decimal dReturnChq_DeductionRate_Collector = 0.015m;

        //PMS 
        public static string sProductionJobPrePlanDates = "";
        public static string sJobMarckup = "";
        public static string sJobGenaralOverhead = "";
        public static string sCompanyID = "";
        #endregion

        #region Config Status
        public static bool bItemSubCategoryEnable = false;
        public static bool bSerialNumberEnabled = false;

        //Check Dataset or not
        public static bool bisDataSetActive_DONotePrinting = false;
        public static bool bisDataSet_AccountPaybleNote = false;
        public static bool bisDataSetActive_PaymentVoucherNotePrinting = false;
        public static bool bisDatasetActive_SalesReturnNotePrinting = false;
        public static bool bisDatasetActive_DebitNotePrinting = false;

        //for approval
        public static bool bApprovalEnabledInquiry = false;
        public static bool bApprovalEnabledSalesJob = false;
        public static bool bApprovalEnabledQuotation = false;
        public static bool bApprovalEnabledCustomerOrder = false;
        public static bool bApprovalEnabledProforemaInvoice = false;
        public static bool bApprovalEnabledDeliveryOrder = false;
        public static bool bApprovalEnabledInvoice = false;

        public static bool bApprovalEnabledPurchaseOrder = false;

        public static bool bApprovalNeedForInternalTransferNoteSearch = false;

        //for settle
        public static bool bSettleEnabledInquiry = false;
        public static bool bSettleEnabledSalesJob = false;
        public static bool bSettleEnabledQuotation = false;
        public static bool bSettleEnabledCustomerOrder = false;
        public static bool bSettleEnabledProforemaInvoice = false;
        public static bool bSettleEnabledDeliveryOrder = false;
        public static bool bSettleEnabledInvoice = false;

        //for settle and hide from system
        public static bool bAutoSettleHideInquiry = false;
        public static bool bAutoSettleHideSalesJob = false;
        public static bool bAutoSettleHideQuotation = false;
        public static bool bAutoSettleHideCustomerOrder = false;
        public static bool bAutoSettleHideProforemaInvoice = false;
        public static bool bAutoSettleHideDeliveryOrder = false;
        public static bool bAutoSettleHideInvoice = false;

        //Need Note To Be Approved Before Print
        public static bool bApprovalNeedToPrintInquiry = false;
        public static bool bApprovalNeedToPrintSalesJob = false;
        public static bool bApprovalNeedToPrintQuotation = false;
        public static bool bApprovalNeedToPrintCustomerOrder = false;
        public static bool bApprovalNeedToPrintProforemaInvoice = false;
        public static bool bApprovalNeedToPrintDeliveryOrder = false;
        public static bool bApprovalNeedToPrintInvoice = false;
        public static bool bApprovalNeedToPrintReceipt = false;
        public static bool bApprovalNeedToPrintSalesReturned = false;
        public static bool bApprovalNeedToPrintCreditNote = false;
        public static bool bApprovalNeedToPrintDebitNote = false;
        public static bool bApprovalNeedToPrintPO = false;
        public static bool bApprovalNeedToPrintGRN = false;
        public static bool bApprovalNeedToPrintPRN = false;
        public static bool bApprovalNeedToPrintGTN = false;
        public static bool bApprovalNeedToPrintAPN = false;

        //Need Note To Be Checked Before Print
        public static bool bCheckingNeedToPrintInquiry = false;
        public static bool bCheckingNeedToPrintSalesJob = false;
        public static bool bCheckingNeedToPrintQuotation = false;
        public static bool bCheckingNeedToPrintCustomerOrder = false;
        public static bool bCheckingNeedToPrintProforemaInvoice = false;
        public static bool bCheckingNeedToPrintDeliveryOrder = false;
        public static bool bCheckingNeedToPrintInvoice = false;
        public static bool bCheckingNeedToPrintReceipt = false;
        public static bool bCheckingNeedToPrintSalesReturned = false;
        public static bool bCheckingNeedToPrintCreditNote = false;
        public static bool bCheckingNeedToPrintDebitNote = false;
        public static bool bCheckingNeedToPrintPO = false;
        public static bool bCheckingNeedToPrintGRN = false;
        public static bool bCheckingNeedToPrintGTN = false;
        public static bool bCheckingNeedToPrintPRN = false;
        public static bool bCheckingNeedToPrintAPN = false;
        public static bool bCheckingNeedToPrintAPNDetail = false;

        //Data Grid Fild Lock
        public static bool bEnableGridLock_Price_DO = false;
        public static bool bEnableGridLock_Price_Invoice = false;
        public static bool bEnableGridLock_Price_CO = false;
        public static bool bEnableGridLock_Price_Quotation = false;
        public static bool bEnableGridLock_Price_ProformaInvoice = false;
        public static bool bEnableGridLock_Price_SRN = false;

        public static bool bEnableGridLock_Quantity_ProformaInvoice = false;
        public static bool bEnableGridLock_Quantity_DO = false;
        public static bool bEnableGridLock_Quantity_Invoice = false;
        public static bool bEnableGridLock_Quantity_CO = false;
        public static bool bEnableGridLock_Quantity_SRN = false;

        public static bool bEnableGridLock_Price_GRN = false;
        //Data Grid Setting
        public static bool bEnableDataGridSetting = false;

        //stock exceed lock
        // public static bool bStockExceedLock_DeliveryOrder = false;
        //  public static bool bStockExceedLock_iSR = false;
        //  public static bool bStockExceedLock_iGIN = false;
        //  public static bool bStockExceedLock_iGRN = false;

        //sub stock exceed lock
        public static bool bSubStockExceedLock_DeliveryOrder = false;

        public static bool bEnableOldCRNposting = false;

        //Quantity Exceed Percentage Lock
        public static bool isEnable_QuantityExceedPercentageLock = false;
        public static bool isEnable_QuantityExceedPercentageLock_GRN = false;

        public static bool isEnable_CreateStorefor_SalesRep = false;

        //Stock Note Job id required
        public static bool bJobIdRequiredGIN = false;
        public static bool bSectionStockWithJobID = false;
        public static bool bStoreStockWithJobID = false;

        //Credit balance message and lock
        public static bool bCreditBalanceInquiry_Message = false;
        public static bool bCreditBalanceSalesJob_Message = false;
        public static bool bCreditBalanceQuotation_Message = false;

        public static bool bCreditBalanceProforemaInvoice_Message = false;
        public static bool bCreditBalanceDeliveryOrder_Message = false;
        public static bool bCreditBalanceInvoice_Message = false;
        public static bool bCreditBalanceInquiry_Lock = false;
        public static bool bCreditBalanceSalesJob_Lock = false;
        public static bool bCreditBalanceQuotation_Lock = false;

        public static bool bCreditBalanceProforemaInvoice_Lock = false;
        public static bool bCreditBalanceDeliveryOrder_Lock = false;
        public static bool bCreditBalanceInvoice_Lock = false;
        public static bool bOutstandingBalance_InvoiceLock_Aging = false;
        public static bool bCreditBalanceInvoice_Check = false;

        //Display Pricing Column in Sales Note
        public static bool bUnitPriceVisible_Invoice = false;
        public static bool bWeightPriceVisible_Invoice = false;
        public static bool bUnitPriceVisible_Inquiry = false;
        public static bool bWeightPriceVisible_Inquiry = false;
        public static bool bUnitPriceVisible_SalesJob = false;
        public static bool bWeightPriceVisible_SalesJob = false;
        public static bool bUnitPriceVisible_Quotation = false;
        public static bool bWeightPriceVisible_Quotation = false;
        public static bool bUnitPriceVisible_CustomerOrder = false;
        public static bool bWeightPriceVisible_CustomerOrder = false;
        public static bool bUnitPriceVisible_ProforemaInvoice = false;
        public static bool bWeightPriceVisible_ProforemaInvoice = false;
        public static bool bUnitPriceVisible_DeliveryOrder = false;
        public static bool bWeightPriceVisible_DeliveryOrder = false;
        public static bool bValidateCostPriceVsSellPrice = false;

        //Price Details Completely Hide
        public static bool bPriceDetailsHide_DeliveryOrder = false;

        //Default Pricing Unit use in Customer
        public static bool bUnitQtyPricing_Invoice = false;
        public static bool bUnitQtyPricing_Inquiry = false;
        public static bool bUnitQtyPricing_SalesJob = false;
        public static bool bUnitQtyPricing_Quotation = false;
        public static bool bUnitQtyPricing_CustomerOrder = false;
        public static bool bUnitQtyPricing_ProforemaInvoice = false;
        public static bool bUnitQtyPricing_DeliveryOrder = false;

        //Which Unit need to Validate in stock weight or qty
        public static bool bStockValidateQty_Invoice = false;
        public static bool bStockValidateWeight_Invoice = false;
        public static bool bStockValidateQty_Inquiry = false;
        public static bool bStockValidateWeight_Inquiry = false;
        public static bool bStockValidateQty_SalesJob = false;
        public static bool bStockValidateWeight_SalesJob = false;
        public static bool bStockValidateQty_Quotation = false;
        public static bool bStockValidateWeight_Quotation = false;
        public static bool bStockValidateQty_CustomerOrder = false;
        public static bool bStockValidateWeight_CustomerOrder = false;
        public static bool bStockValidateQty_ProforemaInvoice = false;
        public static bool bStockValidateWeight_ProforemaInvoice = false;
        public static bool bStockValidateQty_DeliveryOrder = false;
        public static bool bStockValidateWeight_DeliveryOrder = false;


        //Stock Validate
        public static bool bStockValidateQty_iSR = false;
        public static bool bStockValidateWeight_iSR = false;
        public static bool bStockValidateQty_iGIN = false;
        public static bool bStockValidateWeight_iGIN = false;
        public static bool bStockValidateQty_GTN = false;
        public static bool bStockValidateWeight_GTN = false;
        public static bool bStockValidateQty_iGRN = false;
        public static bool bStockValidateWeight_iGRN = false;
        public static bool bStockValidateQty_eGIN = false;
        public static bool bStockValidateWeight_eGIN = false;
        public static bool bStockValidateQty_DIN = false;
        public static bool bStockValidateWeight_DIN = false;
        public static bool bStockValidateQty_PRN = false;
        public static bool bStockValidateWeight_PRN = false;
        public static bool bShowJobNo_StockControllPanel_forDocNo = false;
        public static bool bItemSearch_ValidateAddingDuplicateItem = false;
        public static bool bStockValidateQty_DamageGood = false;
        public static bool bStockValidateWeight_DamageGood = false;
        public static bool bStockValidateQty_SplitNote = false;
        public static bool bStockValidateWeight_SplitNote = false;

        //Single Item Stock Enabled
        public static bool bSingleItemStockEnabled = false;

        //PMS
        public static bool bPrePlanItemLockWhenWorkInProgressDone = false;
        public static bool bPrePlanSectionPathLockWhenWorkInProgressDone = false;

        //Stock SRN and GRN
        public static bool bSRNandGRNHavingSameSerial = false;



        //Auto Settle 
        public static bool bAutoSettleEnableReceipt = false;

        public static bool bDisplay_RefundableButton = false;

        //Auto CreditNote Creation
        public static bool bSRN_AutoCreditNoteCreateEnable = false;
        public static bool bSRN_AutoCreditNoteCreateEnable_NeedApproval = false;
        public static bool bSRN_AutoCreditNoteCreateEnable_Returnable = false;
        public static bool bDisplay_TaxCreditNote = false;

        //Stock Update Need Checking
        public static bool bSRN_StockUpdate_NeedChecking = false;
        public static bool bFGTN_StockUpdate_NeedChecking = false;
        public static bool bStockAdjustment_StockUpdate_NeedApproval = false;


        //Auto Qty Convert From Square Feet
        public static bool bAutoQtyConvertFromSquareFeet = false;

        public static bool bShowSystemQty = false;

        //Direct Print Enable
        public static bool bDirectPrint_NP_Inquiry = false;
        public static bool bDirectPrint_NP_Quotation = false;
        public static bool bDirectPrint_NP_ProforemaInvoice = false;
        public static bool bDirectPrint_NP_CustomerOrder = false;
        public static bool bDirectPrint_NP_DeliveryOrder = false;
        public static bool bDirectPrint_NP_Invoice = false;
        public static bool bDirectPrint_NP_ProductionJob = false;

        //Auto Posting Enable
        // public static bool bAutoPostingEnable_AccountPayableNote = false;
        //  public static bool bAutoPostingEnable_PaymentVoucher = false;
        //   public static bool bAutoPostingEnable_ReceiptVoucher = false;
        //  public static bool bAutoPostingEnable_Invoice = false;
        public static bool bAutoPostingEnable = false;
        public static bool bAutoPostingEnable_Stock = false;
        //   public static bool bAutoPostingEnable_DebitNote = false;

        //FIFO Lock
        public static bool bValidate_InvoiceFIFO_QTY = false;
        public static bool bValidate_InvoiceFIFOCostPrice = false;
        public static bool bValidate_CostCalculatedByInvoiceNotDO = false;


        //Dataset Active
        //  public static bool bDatasetActive_InvoiceNotePrint = false;
        public static bool bDataSetActive_LoanInLoanOut = false;
        public static bool bDateSetActive_PurchaseOrderPrint = false;
        public static bool bDataSetActive_DepositedChequeSummary = false;
        public static bool bDataSetActive_CustomerOrder = false;
        public static bool bDataSetActive_DamageGood = false;
        public static bool bDataSetActive_SplitNote = false;
        public static bool bDataSetActive_iGRN = false;
        public static bool bDataSetActive_iGIN = false;
        public static bool bDataSetActive_GIN = false;
        public static bool bDataSetActive_PurchseRequision = false;

        //CrystalReport Formularfiled 
        public static bool bShowQty_InvoiceReristerDetails = false;

        //Enable Minus Qty
        public static bool bMinusQtyEnable_DO = false;

        //Cheque Auto Realized On
        public static bool bChequeAutoRealizedOn = false;

        //R1 POS System
        public static bool bDefaultStoreID = false;
        public static bool bPOSReceipt_AutoCreate_DO = false;
        public static bool bDisplayItemNameInPOSItemButton = false;
        public static bool bDisplayPoSBackgroundImage = false;

        //Seiral Number Genaration Enable For Sales Note Type 
        public static bool bSalesNoteType_SerialNoActiveFor_CustomerOrder = false;
        public static bool bSalesNoteType_SerialNoActiveFor_DeliveryOrder = false;
        public static bool bSalesNoteType_SerialNoActiveFor_Invoice = false;
        public static bool bSalesNoteType_SerialNoActiveFor_SalesReturnedNote = false;
        public static bool bSalesNoteType_SerialNoActiveFor_CreditNote = false;
        public static bool bSalesNoteType_SerialNoActiveFor_DebitNote = false;
        public static bool bSalesNoteType_SerialNoActiveFor_ReciptSales = false;
        public static bool bSalesNoteType_SerialNoActiveFor_ReciptSales_AndDifferntNoForAdvances = false;
        public static bool bStockNoteType_SerialNoActiveFor_PurchaseOrder = false;
        public static bool bStockNoteType_SerialNoActiveFor_PurchaseRequisitionNote = false;
        public static bool bStockNoteType_SerialNoActiveFor_GoodsReceivedNote = false;
        public static bool bStockNoteType_SerialNoActiveFor_PurchaseReturnNote = false;
        public static bool bBackDateEnable_CustomerOutstandingReports = false;
        public static bool bEnableReceiptDateAndChequeDateValidater = false;
        public static bool bPV_UseChequeDate_As_PVPostingDate = false;
        //Cheque
        public static bool bChequeLandscape = false;
        public static bool bDisplayBankManagemnet_CashDeposit_Account = false;
        public static bool bDisplayBankManagemnet_ChequeDeposit_Account = false;
        public static bool bDisplay_ChequePrint_AmountEndWith_StarMark = false;
        public static bool bAdvanceCashDepositeEnable = false;

        //
        public static bool bSerialNumberActive = false;

        //Company Baranch Master
        public static bool bBranchMaster_SerialNoActiveFor_CustomerOrder = false;
        public static bool bBranchMaster_SerialNoActiveFor_DeliveryOrder = false;
        public static bool bBranchMaster_SerialNoActiveFor_Invoice = false;
        public static bool bBranchMaster_SerialNoActiveFor_CreditNote = false;
        public static bool bBranchMaster_SerialNoActiveFor_DebitNote = false;
        public static bool bBranchMaster_SerialNoActiveFor_SalesReturn = false;
        public static bool bBranchMaster_SerialNoActiveFor_CustomerMaster = false;
        public static bool bBranchMaster_SerialNoActiveFor_SupplierMaster = false;
        public static bool bBranchMaster_SerialNoActiveFor_SalesReceipt = false;
        public static bool bBranchMaster_SerialNoActiveFor_Receipt = false;
        public static bool bBranchMaster_SerialNoActiveFor_Pos_Transaction = false;
        public static bool bBranchMaster_SerialNoActiveFor_Pos_Receipt = false;

        //GridView Column 
        public static bool bMettleDetail_GridViewColumn = false;
        public static bool bGemDetail_GridViewColumn = false;
        public static bool bSellingPrice_GridViewColumn = false;
        public static bool bItemSubCategoryID_GridViewColumn = false;
        public static bool bSerialNo_GridViewColumn = false;
        public static bool bCostPrice_GridViewColumn = false;
        public static bool bRefNo_GridViewColumn = false;
        public static bool bPOS_DisplaySerialNo_SalesGridViewColumn = false;
        public static bool bCartonNo_GridViewColumn = false;


        //Auto Posting Switch
        //  public static bool bAutoPostingEnable_CashDeposit = false;
        //  public static bool bAutoPostingEnable_ChequeDeposit = false;
        //   public static bool bAutoPostingEnable_ChequeReturned = false;

        public static bool bActivate_paymentVoucherNotePrintingwithAccountCode = false;

        public static bool bUsePosPrinter = false;
        public static bool bDirect_Print_Pos_Invoice = false;

        public static bool bPOSItemSearch_StoreWiseEnable = false;
        public static bool bIsAllPaymentMethodsAreActive = false;
        public static bool bPOSItemSearch_CheckForPhysicalQty = false;
        public static bool bPOSItemSearch_CheckForAvailableQty = false;
        public static bool bPOSItemSearch_StockValidationEnable = false;
        public static bool bPOSSaveActualPayedAmount = false;
        public static bool bOpenImageInImageTempFolder = false;
        public static bool bDAPL_GRN_Block_BranchCode = false;
        public static bool bDebitnoteType_SerialNoActiveFor_DebitNote = false;

        public static bool bEnableAdvancedItemViewer = false;
        public static bool bGenaralLedgerreport_GroupCashDeposit = false;

        public static bool bHideGRNNo_APN = false;


        //Use Seperate Serial Number Advanced And Partpayment Resipt
        public static bool bUseSeperateSerialNo_AdvancedAndPartpaymentReceipt = false;
        public static bool bUseSeperateSerialNoInterimReceipt = false;

        //Use to Check Do Qty not Less than  Invoice Qty 
        public static bool bAllowInvoiceLessThanDO_Qty = false;

        //To Ensure Only cash or Checque 
        public static bool bAllowCashAndCheque_InOneReceipt = false;

        public static bool bDateExpiration = false;

        //To Report Enable Disable
        public static bool bIsUserWise_EnableDisableReport = false;

        //for item serial system
        public static bool bItemSerialNo_Active = false;
        public static bool bItemSerialNo_EnableDuplication_GRN = false;
        public static bool bItemSerialNo_EnableQtyValidation_GRNDetailvsSerial = true;

        //for internal iSR, iGIN, iGRN
        public static bool bMandatoryFieldEnable_iSR_JobNo = false;
        public static bool bMandatoryFieldEnable_iGIN_JobNo = false;
        public static bool bMandatoryFieldEnable_iGRN_JobNo = false;
        public static bool bMandatoryFieldEnable_iSR_RefNo = false;
        public static bool bMandatoryFieldEnable_iGIN_RefNo = false;
        public static bool bMandatoryFieldEnable_iGRN_RefNo = false;
        public static bool bItemSerialNoActive_iSR = false;
        public static bool bItemSerialNoActive_iGIN = false;
        public static bool bItemSerialNoActive_iGRN = false;
        public static bool bPrintPreviewSetActive_StoreRequisition = false;
        public static bool bHide_GridViewColumn_Store_PendingQty = false;

        //for commission activate netvalue instead of granttotal
        public static bool bCommission_ActivateNetValue = false;

        //For Multiple Discount 
        public static bool bIsEnabledMultiple_Discount = false;
        public static bool bIsRateLocked_Multiple_Discount = false;
        //Display ItemPrices in Store Transfer Notes
        public static bool bDisplay_ItemUnitPrice_StoreTransferNotes = false;

        //Validate Stock When AddingMultipleItems
        public static bool bValidateStock_WhenAddingMultipleItems = false;

        //Validate Stock When AddingMultipleItems
        public static bool bIsEnableZeroItemQuentityValidate_DO = false;
        public static bool bIsEnableZeroItemQuentityValidate_GIN = false;

        public static bool bIsEnableStartupStocReconcilation = false;
        public static bool bIsEnableStartupStocReconciliation_SQL_SP = false;

        //Approval Need to Stock Update Item Split Note
        public static bool bApprovalNeed_ToUpdateStock_ItemSplitNote = false;

        public static bool bShowAll_branches_storeSearch = false;
        public static bool bRecipt_Validate_AccountNo = false;
        //GridView Column 
        public static bool bHide_GridViewColumn_Stock_Weight = false;
        public static bool bHide_GridViewColumn_Stock_GoodsFrom = false;
        public static bool bHide_GridViewColumn_Stock_NoteID = false;

        public static bool bHide_GridViewColumn_Stock_CostPrice = false;
        public static bool bHide_GridViewColumn_Stock_TotalCostPrice = false;
        public static bool bHide_GridViewColumn_Stock_SellingPrice = false;

        public static bool bIsCustomerMandatory_ItemFinanceScreen = false;

        public static bool bSRn_Item_Validation_With_DO = false;
        public static bool bEnable_TAX_ManualMode = false;
        public static bool bAllow_user_to_Dupplicate_items_SAS_Transactions = false;
        public static bool bAllow_user_to_Dupplicate_items_SCS_Transactions = false;

        public static bool bShow_GridViewColumn_Remarks = false;

        public static bool bWrap_ItemGrid_ItemName = false;

        //Load zero qty items in DO Grid
        public static bool bLoadZeroQtyItems_DOGrid = false;

        //Lock Transtraction Date
        public static bool bLock_TransactionDate_SAS = false;
        public static bool bLock_TransactionDate_SCS = false;

        public static bool bShowDONotInvoiced = false;
        public static bool bAllow_Multiple_DO_For_Invoice = false;
        public static bool bShowFreeItems = false;

        //Enable F5 for stock Adjustment
        public static bool bEnableF5_StockAdjustment = false;
        
        //Enable ProformaInvoice Bank Acc
        public static bool bEnableProformaInvoice_AccountNo = false;

        //Enable GRN - PO No.
        public static bool bEnableMandatory_PONo_for_GRN = false;
        public static bool bRemove_alreadyGRNitems_from_PO = false;
        public static bool bCheckValidation_BudgetExceed = false;

        //Show digiteq user
        public static bool bVisible_digiteq_User = false;

        //Visible Panel in DO - janith
        public static bool bDO_HideSettingsPanel = false;
        public static bool bShow_ManuallyEnter_DeliveryAddress = false;
        public static bool bShowGrid_FreeColumn_DO = false; // show Free Column in DO Grid 

        public static bool bChange_Name_lblTerms = false;

        public static bool bHide_PriceCategory_DO = false;
        public static bool bHide_Fields_DO = false;

        //Hide Special Settings button in Sales Invoice
        public static bool bHide_SpecialSettings_Invoice = false;

        //Visible Customer Order tracking report - Janith (RHP)
        public static bool bShow_CustomerOrderTracking_Report = false;

        //Display Delivered Quantity in Delivery Order Items
        public static bool bDisplay_DeliveredQuantity_DeliveryOrderItems = false;

        //Enable Change Password Reminder
        //public static bool bIsEnablePasswordChange_Reminder = false; //change due to reason

        //Production System R2
        public static bool b_Prod_InactiveWIP_QuantityCalculationAutomate = false;
        public static bool b_Prod_View_Competitive_ProductComparison = false;

        public static bool bPostReversalEntry_WhenCancellation = false;

        //Invoice Note type hide - celcius only - janith
        public static bool bHide_NoteType_Invoice = false;

        public static bool bValidate_InvoiceCreditPeriod_Block = false;
        public static bool bValidate_InvoiceCreditPeriod_Messege = false;
        public static bool bValidate_CreditBalance_Message = false;
        public static bool bValidate_CreditBalance_Block = false;

        public static bool benable_multipleDO_Invoice = false;

        public static bool benable_TaxSelection_Quotation = false;

        //Set Branch wise store search
        public static bool enableBranchWiseFilterOnSearch = true;

        //item master branch wise filter search
        public static bool enableBranchWiseItemSearch = false;

        public static bool isVisibleCompanyInfoInDraftPrint = false;

        public static bool bReceipt_isCollectorMandatory = false;

        public static bool bitemSplitNote_ToStoreActive = false;

        public static bool bEnableSalesReturn_DirectPosting = false;

        public static bool bLoadItemSearch_ByStore = false;


        //item component visibility
        public static bool bShowItemComponents = false;

        //credit note report with sales return detail and inovice details
        public static bool bEnable_CreditNoteWithSalesReturnItem;


        //Production Apparel
        public static bool bBoM_CustomerOrderIDUpdate_NeedChecking = false;
        public static bool bBoM_CustomerOrderIDUpdate_NeedApproval = false;

        //Production Polythene - Need to add to Back Process
        public static bool bCreditBalanceCustomerOrder_Message = false;
        public static bool bCreditBalanceCustomerOrder_Lock = false;
        public static bool bAllowToAddZeroQty_PrePlan_Inputs = false;
        public static bool bEnableDirectProdcutionJobSave = false;


        //Automated Cheque Print
        public static bool bEnable_AutomatedChequePrint;

        public static bool bEnableSalesman_DO = false;
        public static bool bHideBreakDownDetail_DO = false;
        public static bool bShowQtyANDWeightColumns_DO = false;


        //Checked Finished Good Item in Production
        public static bool bEnableFinishedGood_Validation = false;


        //Disable Multiple Customer Branches
        public static bool bDisableMultipleCustomerBranch = false;

        public static int Theme_ID = 0;


        public static bool bEnableRouteWisePermissionCheck= false;
        #endregion

        #region Company Values
        //Quotation
   //     public static string sCmp_qQuotationSubject = "";
     //   public static string sCmp_qPaymentTerms = "";
    //    public static string sCmp_qValidityPeriod = "";
      //  public static string sCmp_qDeliveryPeriod = "";
      //  public static string sCmp_qContactTelephone = "";
     //   public static string sCmp_qContactEmail = "";
      //  public static string sCmp_companyCode = "";
        #endregion

        #region Genaral Config Status
        public static bool bIsCompanyChequeBankType = false;
        public static bool bValidate_ReceiptPostByChequeDate = false;
        public static bool bEnableReceiptSort_ByReceiptID = false;

        //public static string sPaymentMethod_Cash = "";
        //public static string sPaymentMethod_Cheque = "";
        //public static string sPaymentMethod_Visa = "";
        //public static string sPaymentMethod_Master = "";
        //public static string sPaymentMethod_LoyalityCard = "";
        //public static string sPaymentMethod_Voucher = "";
        //public static string sPaymentMethod_Bank_Slip = "";
        //public static string sPaymentMethod_Bank_Swift = "";
        //public static string sPaymentMethod_Amex = "";
        //public static string sPaymentMethod_DinersClub = "";
        //public static string sPaymentMethod_GiftVouther = "";
        //public static string sPaymentMethod_StarPoint = "";

        public static string sInvoiceTop = "";
        public static string sInvoiceBottom = "";
        public static string sInvoiceAddress = "";
        public static string sPOSBillDecimalPoint = "";
        #endregion

        #region Other
        public static bool bIsTestLabelVisibleInMainForm = false;
        public static bool bProductActivated = false;
        #endregion

        #region HardCode Variable
        public static string sHC_NonVatSalesNoteTypeID = "SN002";
        #endregion

        #region Commission Values
        public static decimal dRange1_Days = 0;
        public static decimal dRange1_Pasantage = 0;
        public static decimal dRange2_Days = 0;
        public static decimal dRange2_Pasantage = 0;
        public static decimal dRange3_Days = 0;
        public static decimal dRange3_Pasantage = 0;
        public static decimal dRange4_Days = 0;
        public static decimal dRange4_Pasantage = 0;
        public static decimal dRange5_Days = 0;
        public static decimal dRange5_Pasantage = 0;
        #endregion

        #region For adhesive Report

        public static List<string> oItem_Adhesive = new List<string>()
        {
            "ICT/156"
        };

        public static List<string> oItem_Hardner = new List<string>()
        {
            "ICT/158"
        };
        #endregion

        public static string sNBTGLCode_Receivable = "";
        public static string sNBTGLCode_Payable = "";
        public static string sVATGLCode_Receivable = "";
        public static string sVATGLCode_Payable = "";

        public static string sSubLedger_Creditors = "";
        public static string sSubLedger_Debters = "";

        public static Color Font_Grid_Active = Color.Green;
        public static Color Font_Grid_Locked = Color.Red;



        //Module IDs
        public static string sMod_POS = "FCT/013";
        public static string sMod_Prod_Apparel = "PROD/016";

        public static System.Data.DataTable tblVersion = new System.Data.DataTable();        

        public static bool bIsTestSystem { get; set; }
    }
}