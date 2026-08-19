using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTire;
using System.Windows.Forms;
using System.Globalization;

namespace Digiteq_Logic
{
    public class clsBackProcess
    {

        #region Auto Assign Config Values
        public static void AutoAssignConfigValue()
        {
            foreach (tbl_securityConfigValue detail in tbl_securityConfigValue.SelectAll())
            {
                if (detail.ValueID == 1) //Backup Folder Location
                    clsConfig.sServerBackupFolder = detail.ConfigValue.Trim();
                else if (detail.ValueID == 2) //Admin Category ID
                    clsConfig.sAdminCategoryID = detail.ConfigValue.Trim();
                else if (detail.ValueID == 6) //Auto Reconcilation Days
                    clsConfig.iAutoChequeReconciliationDays = int.Parse(detail.ConfigValue.Trim());
                else if (detail.ValueID == 7) //ItemSubCategory Name
                    clsConfig.sItemSubCategory = detail.ConfigValue.Trim();
                else if (detail.ValueID == 8) //Software Model
                { 
                    clsConfig.sSoftwareModel = detail.ConfigValue.Trim();
                    if (clsConfig.sSoftwareModel != "")
                    {
                        if (!Enum.IsDefined(typeof(SoftwareModel_Sales), clsConfig.sSoftwareModel))
                        { clsConfig.SoftwareModel = SoftwareModel_Sales.ceilingAndWallPanal; } //  return SoftwareModel_Sales.ceilingAndWallPanal;
                        else
                            clsConfig.SoftwareModel = (SoftwareModel_Sales)Enum.Parse(typeof(SoftwareModel_Sales), clsConfig.sSoftwareModel);
                     //   return (TEnum)Enum.Parse(typeof(TEnum), strEnumValue);


                      //  int i = int.Parse(clsConfig.sSoftwareModel);
                     //   clsConfig.SoftwareModel = (SoftwareModel_Sales)i;
                    }
                }
                else if (detail.ValueID == 9) //ItemSubCategory2 Name
                    clsConfig.sItemSubCategory2 = detail.ConfigValue.Trim();
                else if (detail.ValueID == 10)
                    clsConfig.sWeightCalculation_Type = detail.ConfigValue.Trim();
                else if (detail.ValueID == 11) //Item Search Type
                    clsConfig.sItemSearchType = detail.ConfigValue.Trim();

                //Single Item Stock
                else if (detail.ValueID == 12) //Item ID
                    clsConfig.sSingleItemStockItemID = detail.ConfigValue.Trim();
                else if (detail.ValueID == 13) //SubCategory ID
                    clsConfig.sSingleItemStockItemSubCategoryID = detail.ConfigValue.Trim();
                else if (detail.ValueID == 14) //SubCategory 2 ID
                    clsConfig.sSingleItemStockItemSubCategory2ID = detail.ConfigValue.Trim();
                else if (detail.ValueID == 15) //Serial No
                    clsConfig.sSingleItemStockItemSerialNo = detail.ConfigValue.Trim();
                else if (detail.ValueID == 16) //Serial No 2
                    clsConfig.sSingleItemStockItemSerialNo2 = detail.ConfigValue.Trim();

                //General Ledger
                else if (detail.ValueID == 17)//SubGL-reduNumber
                    clsConfig.sSubGLReduNumber = detail.ConfigValue.Trim();
                else if (detail.ValueID == 18)//SubGL-addNumber
                    clsConfig.sSubGLAddNumber = detail.ConfigValue.Trim();
                else if (detail.ValueID == 19)//AcctType-ReduNumber
                    clsConfig.sAcctTypeReduNumber = detail.ConfigValue.Trim();
                else if (detail.ValueID == 20)//AcctType-AddNumber
                    clsConfig.sAcctTypeAddNumber = detail.ConfigValue.Trim();
                else if (detail.ValueID == 21)//AcctCode-ReduNumber
                    clsConfig.sAcctCodeReduNumber = detail.ConfigValue.Trim();
                else if (detail.ValueID == 22)//AcctCode-AddNumber
                    clsConfig.sAcctCodeAddNumber = detail.ConfigValue.Trim();
                else if (detail.ValueID == 23)//GLAddNumber
                    clsConfig.sGLAddNumber = detail.ConfigValue.Trim();

                //Currency Decimal Placess
                else if (detail.ValueID == 24)//sCurrencyDecimalPlaces_UnitPrice
                    clsConfig.sCurrencyDecimalPlaces_UnitPrice = int.Parse(detail.ConfigValue.Trim());
                else if (detail.ValueID == 25)//sCurrencyDecimalPlaces_WeightPrice
                    clsConfig.sCurrencyDecimalPlaces_WeightPrice = int.Parse(detail.ConfigValue.Trim());
                else if (detail.ValueID == 26)//sCurrencyDecimalPlaces_Quantity
                    clsConfig.sDecimalPlaces_Quantity = int.Parse(detail.ConfigValue.Trim());
                else if (detail.ValueID == 27)//sCurrencyDecimalPlaces_Weight
                    clsConfig.sDecimalPlaces_Weight = int.Parse(detail.ConfigValue.Trim());


                //Recommended Prices
                else if (detail.ValueID == 28)//sRecommendedUnitPrice
                    clsConfig.sItemUnitPriceCode_Default = detail.ConfigValue.Trim();
                else if (detail.ValueID == 29)//sRecommendedWeightPrice
                    clsConfig.sItemWeightPriceCode_Default = detail.ConfigValue.Trim();
                else if (detail.ValueID == 235)//sRecommendedUnitPriceProduction
                    clsConfig.sItemUnitPrice_Production = detail.ConfigValue.Trim();

                //Currency
                else if (detail.ValueID == 30)//Currency
                    clsConfig.sLocalCurrencyCode = detail.ConfigValue.Trim();

                //Cost Center
                else if (detail.ValueID == 31)//Cost Center
                    clsConfig.sCostCenter1 = detail.ConfigValue.Trim();
                else if (detail.ValueID == 32)//Cost Center
                    clsConfig.sCostCenter2 = detail.ConfigValue.Trim();
                else if (detail.ValueID == 33)//Cost Center
                    clsConfig.sCostCenter3 = detail.ConfigValue.Trim();
                else if (detail.ValueID == 34)//Cost Center
                    clsConfig.sCostCenter4 = detail.ConfigValue.Trim();

                //Damaged Good Store
                else if (detail.ValueID == 35)//sDamagedGoodsStore
                    clsConfig.sDamagedGoodsStore = detail.ConfigValue.Trim();

                //sProductionJobPrePlan
                else if (detail.ValueID == 36)//sProductionJobPrePlan
                    clsConfig.sProductionJobPrePlanDates = detail.ConfigValue.Trim();

                //Production Job Pre Plan
                else if (detail.ValueID == (int)JobPercentage.JobMarckup)//sProductionJobPrePlan
                    clsConfig.sJobMarckup = detail.ConfigValue.Trim();
                else if (detail.ValueID == (int)JobPercentage.JobGenaralOverhead)//sProductionJobPrePlan
                    clsConfig.sJobGenaralOverhead = detail.ConfigValue.Trim();

                //Version
                else if (detail.ValueID == 39)//sProductionJobPrePlan
                    clsConfig.sVersion = detail.ConfigValue.Trim();

                //Com Port
                else if (detail.ValueID == 40)//sDonglePortNo
                    clsConfig.sDonglePortNo = detail.ConfigValue.Trim();

                //SEACC_POS
                else if (detail.ValueID == 41)//sDefaltBranchStoreID
                    clsConfig.sDefaltBranchStoreID = detail.ConfigValue.Trim();
                else if (detail.ValueID == 42)//sDefaultCustomerID
                    clsConfig.sDefaultCashCustomerID = detail.ConfigValue.Trim();
                else if (detail.ValueID == 43)//Outstaning Report Backdate By Month
                    clsConfig.OutstaningReport_BackdateByMonth = int.Parse(detail.ConfigValue.Trim());
                else if (detail.ValueID == 44)//Image Path
                    clsConfig.sImagePath = detail.ConfigValue.Trim();
                else if (detail.ValueID == 45)//Gift Voucher Code
                    clsConfig.sGiftVoucherCode = detail.ConfigValue.Trim();

                //Database Backup
                else if (detail.ValueID == 47)//Gift Voucher Code
                    clsConfig.sLastBackupedDate = detail.ConfigValue.Trim();
                else if (detail.ValueID == 100)
                    clsConfig.sSeaccBackupPath_Server = detail.ConfigValue.Trim();
                else if (detail.ValueID == 101)
                    clsConfig.sSeaccBackupPreFix = detail.ConfigValue.Trim();
                else if (detail.ValueID == 102)
                    clsConfig.sSeaccBackup_SourceFolder_1 = detail.ConfigValue.Trim();
                else if (detail.ValueID == 103)
                    clsConfig.sSeaccBackup_SourceFolder_2 = detail.ConfigValue.Trim();
                else if (detail.ValueID == 104)
                    clsConfig.sSeaccBackup_SourceFolder_3 = detail.ConfigValue.Trim();
                else if (detail.ValueID == 210)
                    clsConfig.sAutoBackupPath = detail.ConfigValue.Trim();

                //Remort Desktop Printer
                else if (detail.ValueID == 52)//sRemortDesktopExportPath
                    clsConfig.sRemortDesktopExportPath = detail.ConfigValue.Trim();
                //OPS Doc Printing Invoice
                else if (detail.ValueID == 56)
                    clsConfig.sInvoiceTop = detail.ConfigValue.Trim();
                else if (detail.ValueID == 57)
                    clsConfig.sInvoiceBottom = detail.ConfigValue.Trim();
                else if (detail.ValueID == 58)
                    clsConfig.sInvoiceAddress = detail.ConfigValue.Trim();
                else if (detail.ValueID == 59)
                    clsConfig.sPOSBillDecimalPoint = detail.ConfigValue.Trim();
                else if (detail.ValueID == 60)
                    clsConfig.sDAPL_GRN_Enable_BranchCode = detail.ConfigValue.Trim();
                else if (detail.ValueID == 61)
                    clsConfig.sGbl_Company_Code = detail.ConfigValue.Trim();
                else if (detail.ValueID == 62)//SMS prth
                    clsConfig.sGbl_SMS_Shared_Folder_Parth = detail.ConfigValue.Trim();
                else if (detail.ValueID == 63)//sMaximumQuntityExceededPercentage_localOrders
                    clsConfig.sMaximumQuntityExceededPercentage_localOrders = detail.ConfigValue.Trim();
                else if (detail.ValueID == 64)//sMaximumQuntityExceededPercentage_ExportOrders
                    clsConfig.sMaximumQuntityExceededPercentage_ExportOrders = detail.ConfigValue.Trim();
                else if (detail.ValueID == 65)//sMaximumQuntityExceededPercentage_ExportOrders
                {
                    if (detail.ConfigValue != "" && detail.ConfigValue.ToString().Length > 0)
                        clsConfig.dtmDateExpiration = DateTime.Parse(detail.ConfigValue.Trim());
                }

                else if (detail.ValueID == 207)//Item Modeles
                    clsConfig.sItemModel1 = detail.ConfigValue.Trim();
                else if (detail.ValueID == 208)//Item Modeles
                    clsConfig.sItemModel2 = detail.ConfigValue.Trim();
                else if (detail.ValueID == 209)//For Enable Other Field in Loan IN out
                    clsConfig.bEnable_OtherTextBox_LoanOutForm = detail.ConfigValue.Trim();
                else if (detail.ValueID == 211)//For GRN
                    clsConfig.sMaximumQuntityExceededPercentage_localOrders_GRN = detail.ConfigValue.Trim();
                else if (detail.ValueID == 212)//For GRN
                    clsConfig.sMaximumQuntityExceededPercentage_ExportOrders_GRN = detail.ConfigValue.Trim();

                //Multiple Discount 
                //  else if (detail.ValueID == 213)
                //     clsConfig.sDiscount1_Name = detail.ConfigValue.Trim();
                // else if (detail.ValueID == 214)
                //     clsConfig.sDiscount2_Name = detail.ConfigValue.Trim();
                // else if (detail.ValueID == 215)
                //     clsConfig.sDiscount3_Name = detail.ConfigValue.Trim();

                //Item Prices
                else if (detail.ValueID == 216)
                    clsConfig.sItemPrice1_Name = detail.ConfigValue.Trim();
                else if (detail.ValueID == 217)
                    clsConfig.sItemPrice2_Name = detail.ConfigValue.Trim();
                else if (detail.ValueID == 218)
                    clsConfig.sItemPrice3_Name = detail.ConfigValue.Trim();
                else if (detail.ValueID == 219)
                    clsConfig.sItemPrice4_Name = detail.ConfigValue.Trim();
                else if (detail.ValueID == 220)
                    clsConfig.sItemPrice5_Name = detail.ConfigValue.Trim();
                else if (detail.ValueID == 221)
                    clsConfig.sItemPrice6_Name = detail.ConfigValue.Trim();

                else if (detail.ValueID == 222)
                    clsConfig.sTotalMonths_ForLastValidDO_ForSRN = detail.ConfigValue.Trim();
                else if (detail.ValueID == 223)
                    clsConfig.sCustomChequeFormat = detail.ConfigValue.Trim();

                //For SEACC POS
                else if (detail.ValueID == 224)
                    clsConfig.sDefaultCashCustomerID = detail.ConfigValue.Trim();
                else if (detail.ValueID == 225)
                    clsConfig.sDefaultSalesNoteTypeID = detail.ConfigValue.Trim();
                else if (detail.ValueID == 226)
                    clsConfig.sDefaultSalesRep = detail.ConfigValue.Trim();
                else if (detail.ValueID == 227)
                    clsConfig.sPoS_SystemName = detail.ConfigValue;

                else if (detail.ValueID == 228)
                {
                    //Accounts code factoring Charges
                }
                else if (detail.ValueID == 229)
                {
                    //Accounts code factoring Charges VAT
                }
                else if (detail.ValueID == 230)
                {
                    //Accounts code factoring Charges NBT
                }
                else if (detail.ValueID == 231)
                {
                    //Accounts code factoring Charges NBT
                }
                else if (detail.ValueID == 232)
                {
                    //Cheque in hand
                }
                else if (detail.ValueID == 233)
                    clsConfig.sItemCostPriceName_Default = detail.ConfigValue.Trim();
                else if (detail.ValueID == 234)
                    clsConfig.sAccountNo_RetainedEarnings = detail.ConfigValue.Trim();
                else if (detail.ValueID == 236)
                    clsConfig.sSubLedger_Creditors = detail.ConfigValue.Trim();
                else if (detail.ValueID == 237)
                    clsConfig.sSubLedger_Debters = detail.ConfigValue.Trim();
                else if (detail.ValueID == 240)
                    clsConfig.sWeightedAvg_Percentage = detail.ConfigValue.Trim();
                else if (detail.ValueID == 241)
                    clsConfig.sAccountCode_Discount = detail.ConfigValue.Trim();
                else if (detail.ValueID == 242)
                    clsConfig.sAccountCode_CostOfSales = detail.ConfigValue.Trim();
                //else if (detail.ValueID == 243)
                //    clsConfig.sAccountCode_Inventry = detail.ConfigValue.Trim();
                else if (detail.ValueID == 250)
                    clsConfig.sFinancialYear_StartMonth = detail.ConfigValue.Trim();
                else if (detail.ValueID == 251)
                    clsConfig.sAttachmentPath_Server = detail.ConfigValue.Trim();
                else if (detail.ValueID == 252)
                    clsConfig.sFixedAsset_MainStore = detail.ConfigValue.Trim();
                else if (detail.ValueID == 253)
                    clsConfig.accType_InterCompany = detail.ConfigValue.Trim();
                else if (detail.ValueID == 254)
                    clsConfig.sInvoice_SalesAccount_Type = detail.ConfigValue.Trim();
                else if (detail.ValueID == 255)
                    clsConfig.iTransactionId_MaxLength = int.Parse(detail.ConfigValue.Trim());
                else if (detail.ValueID == 256)
                    clsConfig.iTransactionId_MinLength = int.Parse(detail.ConfigValue.Trim());
                else if (detail.ValueID == 257)
                    clsConfig.bStockValidation_waTollarance = decimal.Parse(detail.ConfigValue.Trim());


                //SEACC PRODUCTION (Value ID from 400 to 600)
                //--PROD APPAREL (From 401 to 450)
                else if (detail.ValueID == 401)
                    clsConfig.sProdApparel_AttachmentPath_Server = detail.ConfigValue + "\\";

                //--PROD PHARMA (From 451 to 500)
                else if (detail.ValueID == 451)
                    clsConfig.sProd_Pharma_DefaultCostType = detail.ConfigValue;
                else if (detail.ValueID == 452)
                    clsConfig.sProdPharma_AttachmentPath_Server = detail.ConfigValue + "\\";
                else if (detail.ValueID == 453)
                    clsConfig.dDataGrid_EditedQuantity_Validation_WithPecentage = decimal.Parse(detail.ConfigValue);

                //--SEACC R2 POS (FROM 601 - 700)
                else if (detail.ValueID == 604)
                    clsConfig.sPOSAttachmentPath_Server = detail.ConfigValue.Trim();

                //--INDIKA COMMISSION (FROM 801 - 850)
                else if (detail.ValueID == 801)
                    clsConfig.dReturnChq_DeductionRate_SalesRep = decimal.Parse(detail.ConfigValue.Trim());
                else if (detail.ValueID == 802)
                    clsConfig.dReturnChq_DeductionRate_AreaMgr = decimal.Parse(detail.ConfigValue.Trim());
                else if (detail.ValueID == 803)
                    clsConfig.dReturnChq_DeductionRate_SalesMgr = decimal.Parse(detail.ConfigValue.Trim());
                else if (detail.ValueID == 804)
                    clsConfig.dReturnChq_DeductionRate_Collector = decimal.Parse(detail.ConfigValue.Trim());

            }
        }
        #endregion

        #region Auto Assign Config Status
        public static void AutoAssignConfigStatus()
        {
            #region Stock Validation
            foreach (tbl_securityStockValidate oStock in tbl_securityStockValidate.SelectAllByCompanyBranch_ID(clsSecurity.BranchID))
            {
                switch (oStock.Form_ID)
                {
                    case 10://Invoice
                        clsConfig.bStockValidateQty_Invoice = oStock.StockValidate_Qty;
                        clsConfig.bStockValidateWeight_Invoice = oStock.StockValidate_Weight;
                        break;
                    case 155://Inquiry
                        clsConfig.bStockValidateQty_Inquiry = oStock.StockValidate_Qty;
                        clsConfig.bStockValidateWeight_Inquiry = oStock.StockValidate_Weight;
                        break;
                    case 70://SalesJob
                        clsConfig.bStockValidateQty_SalesJob = oStock.StockValidate_Qty;
                        clsConfig.bStockValidateWeight_SalesJob = oStock.StockValidate_Weight;
                        break;
                    case 23://Quotation
                        clsConfig.bStockValidateQty_Quotation = oStock.StockValidate_Qty;
                        clsConfig.bStockValidateWeight_Quotation = oStock.StockValidate_Weight;
                        break;
                    case 9:// CustomerOrder
                        clsConfig.bStockValidateQty_CustomerOrder = oStock.StockValidate_Qty;
                        clsConfig.bStockValidateWeight_CustomerOrder = oStock.StockValidate_Weight;
                        break;

                    case 24://ProforemaInvoice
                        clsConfig.bStockValidateQty_ProforemaInvoice = oStock.StockValidate_Qty;
                        clsConfig.bStockValidateWeight_ProforemaInvoice = oStock.StockValidate_Weight;
                        break;

                    case 11:// DeliveryOrder
                        clsConfig.bStockValidateQty_DeliveryOrder = oStock.StockValidate_Qty;
                        clsConfig.bStockValidateWeight_DeliveryOrder = oStock.StockValidate_Weight;
                        break;

                    case 114:// iGIN
                        clsConfig.bStockValidateQty_iGIN = oStock.StockValidate_Qty;
                        clsConfig.bStockValidateWeight_iGIN = oStock.StockValidate_Weight;
                        break;

                    case 113://iGRN
                        clsConfig.bStockValidateQty_iGRN = oStock.StockValidate_Qty;
                        clsConfig.bStockValidateWeight_iGRN = oStock.StockValidate_Weight;
                        break;

                    case 115:// iSR
                        clsConfig.bStockValidateQty_iSR = oStock.StockValidate_Qty;
                        clsConfig.bStockValidateWeight_iSR = oStock.StockValidate_Weight;
                        break;

                    case 7://   eGIN
                        clsConfig.bStockValidateQty_eGIN = oStock.StockValidate_Qty;
                        clsConfig.bStockValidateWeight_eGIN = oStock.StockValidate_Weight;
                        break;

                    case 17:// DIN
                        clsConfig.bStockValidateQty_DIN = oStock.StockValidate_Qty;
                        clsConfig.bStockValidateWeight_DIN = oStock.StockValidate_Weight;
                        break;

                    case 130:// PRN
                        clsConfig.bStockValidateQty_PRN = oStock.StockValidate_Qty;
                        clsConfig.bStockValidateWeight_PRN = oStock.StockValidate_Weight;
                        break;

                    case 14://GTN
                        clsConfig.bStockValidateQty_GTN = oStock.StockValidate_Qty;
                        clsConfig.bStockValidateWeight_GTN = oStock.StockValidate_Weight;
                        break;

                    case 15:// Damage Good
                        clsConfig.bStockValidateQty_DamageGood = oStock.StockValidate_Qty;
                        clsConfig.bStockValidateWeight_DamageGood = oStock.StockValidate_Weight;
                        break;

                    case 16:// Split Note
                        clsConfig.bStockValidateQty_SplitNote = oStock.StockValidate_Qty;
                        clsConfig.bStockValidateWeight_SplitNote = oStock.StockValidate_Weight;
                        break;
                }
            }
            #endregion

            foreach (tbl_securityConfigStatus detail in tbl_securityConfigStatus.SelectAll())
            {
                switch (detail.ValueID)
                {
                    case 5://IsItemSubCategory Enable
                        clsConfig.bItemSubCategoryEnable = detail.ConfigValue;
                        break;
                    case 6://IsSerialNumber Enabled
                        clsConfig.bSerialNumberEnabled = detail.ConfigValue;
                        break;

                    case 7://Inquiry
                        clsConfig.bApprovalEnabledInquiry = detail.ConfigValue;
                        break;
                    case 8://SalesJob
                        clsConfig.bApprovalEnabledSalesJob = detail.ConfigValue;
                        break;
                    case 9://Quotation
                        clsConfig.bApprovalEnabledQuotation = detail.ConfigValue;
                        break;
                    case 10://Customer Order
                        clsConfig.bApprovalEnabledCustomerOrder = detail.ConfigValue;
                        break;
                    case 11://Proforema Invoice
                        clsConfig.bApprovalEnabledProforemaInvoice = detail.ConfigValue;
                        break;
                    case 12://Delivery Order
                        clsConfig.bApprovalEnabledDeliveryOrder = detail.ConfigValue;
                        break;
                    case 13:// Invoice
                        clsConfig.bApprovalEnabledInvoice = detail.ConfigValue;
                        break;


                    case 14://Inquiry
                        clsConfig.bSettleEnabledInquiry = detail.ConfigValue;
                        break;
                    case 15://SalesJob
                        clsConfig.bSettleEnabledSalesJob = detail.ConfigValue;
                        break;
                    case 16://Quotation
                        clsConfig.bSettleEnabledQuotation = detail.ConfigValue;
                        break;
                    case 17://Customer Order
                        clsConfig.bSettleEnabledCustomerOrder = detail.ConfigValue;
                        break;
                    case 18://Proforema Invoice
                        clsConfig.bSettleEnabledProforemaInvoice = detail.ConfigValue;
                        break;
                    case 19://Delivery Order
                        clsConfig.bSettleEnabledDeliveryOrder = detail.ConfigValue;
                        break;
                    case 20:// Invoice
                        clsConfig.bSettleEnabledInvoice = detail.ConfigValue;
                        break;
                    case 21:// GIN/SR
                        clsConfig.bJobIdRequiredGIN = detail.ConfigValue;
                        break;
                    //Credit balance message
                    case 22://Inquiry
                        clsConfig.bCreditBalanceInquiry_Message = detail.ConfigValue;
                        break;
                    case 23://SalesJob
                        clsConfig.bCreditBalanceSalesJob_Message = detail.ConfigValue;
                        break;
                    case 24://Quotation
                        clsConfig.bCreditBalanceQuotation_Message = detail.ConfigValue;
                        break;
                    case 25://Customer Order
                        clsConfig.bValidate_CreditBalance_Message = detail.ConfigValue;
                        break;
                    case 46://Customer Order
                        clsConfig.bValidate_CreditBalance_Block = detail.ConfigValue;
                        break;
                    case 413:
                        clsConfig.bValidate_InvoiceCreditPeriod_Block = detail.ConfigValue;
                        break;
                    case 503:
                        clsConfig.bValidate_InvoiceCreditPeriod_Messege = detail.ConfigValue;
                        break;
                    case 26://Proforema Invoice
                        clsConfig.bCreditBalanceProforemaInvoice_Message = detail.ConfigValue;
                        break;
                    case 27://Delivery Order
                        clsConfig.bCreditBalanceDeliveryOrder_Message = detail.ConfigValue;
                        break;
                    case 28:// Invoice
                        clsConfig.bCreditBalanceInvoice_Message = detail.ConfigValue;
                        break;


                    case 30:// Sales Return
                        clsConfig.bEnableGridLock_Price_SRN = detail.ConfigValue;
                        break;
                    case 31:// Quotation
                        clsConfig.bEnableGridLock_Price_Quotation = detail.ConfigValue;
                        break;
                    case 32:// Customer Order
                        clsConfig.bEnableGridLock_Price_CO = detail.ConfigValue;
                        break;
                    case 33:// Pro. Inv
                        clsConfig.bEnableGridLock_Price_ProformaInvoice = detail.ConfigValue;
                        break;
                    case 34:// DO
                        clsConfig.bEnableGridLock_Price_DO = detail.ConfigValue;
                        break;
                    case 35:// Invoice
                        clsConfig.bEnableGridLock_Price_Invoice = detail.ConfigValue;
                        break;
                    case 40:// Pro. Inv
                        clsConfig.bEnableGridLock_Quantity_ProformaInvoice = detail.ConfigValue;
                        break;
                    case 41:// DO
                        clsConfig.bEnableGridLock_Quantity_DO = detail.ConfigValue;
                        break;
                    case 42:// Invoice
                        clsConfig.bEnableGridLock_Quantity_Invoice = detail.ConfigValue;
                        break;
                    case 37:// Sales Return
                        clsConfig.bEnableGridLock_Quantity_SRN = detail.ConfigValue;
                        break;
                    case 39:// CO
                        clsConfig.bEnableGridLock_Quantity_CO = detail.ConfigValue;
                        break;


                    //Credit balance message
                    case 43://Inquiry
                        clsConfig.bCreditBalanceInquiry_Lock = detail.ConfigValue;
                        break;
                    case 44://SalesJob
                        clsConfig.bCreditBalanceSalesJob_Lock = detail.ConfigValue;
                        break;
                    case 45://Quotation
                        clsConfig.bCreditBalanceQuotation_Lock = detail.ConfigValue;
                        break;

                    case 47://Proforema Invoice
                        clsConfig.bCreditBalanceProforemaInvoice_Lock = detail.ConfigValue;
                        break;
                    case 48://Delivery Order
                        clsConfig.bCreditBalanceDeliveryOrder_Lock = detail.ConfigValue;
                        break;
                    case 49:// Invoice
                        clsConfig.bCreditBalanceInvoice_Lock = detail.ConfigValue;
                        break;
                    case 265:// Invoice
                        clsConfig.bOutstandingBalance_InvoiceLock_Aging = detail.ConfigValue;
                        break;

                    //Credit balance message
                    case 51://Inquiry
                        clsConfig.bAutoSettleHideInquiry = detail.ConfigValue;
                        break;
                    case 52://SalesJob
                        clsConfig.bAutoSettleHideSalesJob = detail.ConfigValue;
                        break;
                    case 53://Quotation
                        clsConfig.bAutoSettleHideQuotation = detail.ConfigValue;
                        break;
                    case 54://Customer Order
                        clsConfig.bAutoSettleHideCustomerOrder = detail.ConfigValue;
                        break;
                    case 55://Proforema Invoice
                        clsConfig.bAutoSettleHideProforemaInvoice = detail.ConfigValue;
                        break;
                    case 56://Delivery Order
                        clsConfig.bAutoSettleHideDeliveryOrder = detail.ConfigValue;
                        break;
                    case 57:// Invoice
                        clsConfig.bAutoSettleHideInvoice = detail.ConfigValue;
                        break;

                    //Need To Be Approved Before Print
                    case 58://Inquiry
                        clsConfig.bApprovalNeedToPrintInquiry = detail.ConfigValue;
                        break;
                    case 59://SalesJob
                        clsConfig.bApprovalNeedToPrintSalesJob = detail.ConfigValue;
                        break;
                    case 60://Quotation
                        clsConfig.bApprovalNeedToPrintQuotation = detail.ConfigValue;
                        break;
                    case 61://Customer Order
                        clsConfig.bApprovalNeedToPrintCustomerOrder = detail.ConfigValue;
                        break;
                    case 62://Proforema Invoice
                        clsConfig.bApprovalNeedToPrintProforemaInvoice = detail.ConfigValue;
                        break;
                    case 63://Delivery Order
                        clsConfig.bApprovalNeedToPrintDeliveryOrder = detail.ConfigValue;
                        break;
                    case 64:// Invoice
                        clsConfig.bApprovalNeedToPrintInvoice = detail.ConfigValue;
                        break;
                    case 119:// Receipt
                        clsConfig.bApprovalNeedToPrintReceipt = detail.ConfigValue;
                        break;
                    case 120:// SalesReutnred
                        clsConfig.bApprovalNeedToPrintSalesReturned = detail.ConfigValue;
                        break;
                    case 121:// Credit Note
                        clsConfig.bApprovalNeedToPrintCreditNote = detail.ConfigValue;
                        break;
                    case 122:// DebitNote
                        clsConfig.bApprovalNeedToPrintDebitNote = detail.ConfigValue;
                        break;
                    case 408:// PRN
                        clsConfig.bApprovalNeedToPrintPRN = detail.ConfigValue;
                        break;



                    //Need To Be Checked Before Print
                    case 65://Inquiry
                        clsConfig.bCheckingNeedToPrintInquiry = detail.ConfigValue;
                        break;
                    case 66://SalesJob
                        clsConfig.bCheckingNeedToPrintSalesJob = detail.ConfigValue;
                        break;
                    case 67://Quotation
                        clsConfig.bCheckingNeedToPrintQuotation = detail.ConfigValue;
                        break;
                    case 68://Customer Order
                        clsConfig.bCheckingNeedToPrintCustomerOrder = detail.ConfigValue;
                        break;
                    case 69://Proforema Invoice
                        clsConfig.bCheckingNeedToPrintProforemaInvoice = detail.ConfigValue;
                        break;
                    case 70://Delivery Order
                        clsConfig.bCheckingNeedToPrintDeliveryOrder = detail.ConfigValue;
                        break;
                    case 71:// Invoice
                        clsConfig.bCheckingNeedToPrintInvoice = detail.ConfigValue;
                        break;
                    case 123:// Receipt
                        clsConfig.bCheckingNeedToPrintReceipt = detail.ConfigValue;
                        break;
                    case 124:// Sales Returned
                        clsConfig.bCheckingNeedToPrintSalesReturned = detail.ConfigValue;
                        break;
                    case 125:// Credit Note
                        clsConfig.bCheckingNeedToPrintCreditNote = detail.ConfigValue;
                        break;
                    case 126:// Debit Note
                        clsConfig.bCheckingNeedToPrintDebitNote = detail.ConfigValue;
                        break;
                    case 407:// PRN
                        clsConfig.bCheckingNeedToPrintPRN = detail.ConfigValue;
                        break;


                    case 72:// Section Stock With JobID - IGIN,IGRN
                        clsConfig.bSectionStockWithJobID = detail.ConfigValue;
                        break;
                    case 73:// Store Stock With JobID - IGIN,IGRN
                        clsConfig.bStoreStockWithJobID = detail.ConfigValue;
                        break;


                    //Display Pricing Column in Sales Note
                    case 74://  Unit Price Visible-Invoice
                        clsConfig.bUnitPriceVisible_Invoice = detail.ConfigValue;
                        break;
                    case 75://  Weight Price Visible-Invoice
                        clsConfig.bWeightPriceVisible_Invoice = detail.ConfigValue;
                        break;
                    case 76:// Unit Price Visible-Inquiry
                        clsConfig.bUnitPriceVisible_Inquiry = detail.ConfigValue;
                        break;
                    case 77://  Weight Price Visible-Inquiry
                        clsConfig.bWeightPriceVisible_Inquiry = detail.ConfigValue;
                        break;
                    case 78:// Unit Price Visible-SalesJob
                        clsConfig.bUnitPriceVisible_SalesJob = detail.ConfigValue;
                        break;
                    case 79:// Weight Price Visible-SalesJob
                        clsConfig.bWeightPriceVisible_SalesJob = detail.ConfigValue;
                        break;
                    case 80://  Unit Price Visible-Quotation
                        clsConfig.bUnitPriceVisible_Quotation = detail.ConfigValue;
                        break;
                    case 81://  Weight Price Visible-Quotation
                        clsConfig.bWeightPriceVisible_Quotation = detail.ConfigValue;
                        break;
                    case 82://  Unit Price Visible-CustomerOrder
                        clsConfig.bUnitPriceVisible_CustomerOrder = detail.ConfigValue;
                        break;
                    case 83://  Weight Price Visible-CustomerOrder
                        clsConfig.bWeightPriceVisible_CustomerOrder = detail.ConfigValue;
                        break;
                    case 84://  Unit Price Visible-ProforemaInvoice
                        clsConfig.bUnitPriceVisible_ProforemaInvoice = detail.ConfigValue;
                        break;
                    case 85://  Weight Price Visible-ProforemaInvoice
                        clsConfig.bWeightPriceVisible_ProforemaInvoice = detail.ConfigValue;
                        break;
                    case 86://  Unit Price Visible-DeliveryOrder
                        clsConfig.bUnitPriceVisible_DeliveryOrder = detail.ConfigValue;
                        break;
                    case 87://  Weight Price Visible-DeliveryOrder
                        clsConfig.bWeightPriceVisible_DeliveryOrder = detail.ConfigValue;
                        break;

                    //Default Pricing Unit use in Customer
                    case 88://  Unit Qty Pricing_Invoice
                        clsConfig.bUnitQtyPricing_Invoice = detail.ConfigValue;
                        break;
                    case 89://  Unit Qty Pricing_Inquiry
                        clsConfig.bUnitQtyPricing_Inquiry = detail.ConfigValue;
                        break;
                    case 90://  Unit Qty Pricing_SalesJob
                        clsConfig.bUnitQtyPricing_SalesJob = detail.ConfigValue;
                        break;
                    case 91://  Unit Qty Pricing_Quotation
                        clsConfig.bUnitQtyPricing_Quotation = detail.ConfigValue;
                        break;
                    case 92://  Unit Qty Pricing_CustomerOrder
                        clsConfig.bUnitQtyPricing_CustomerOrder = detail.ConfigValue;
                        break;
                    case 93://  Unit Qty Pricing_ProforemaInvoice
                        clsConfig.bUnitQtyPricing_ProforemaInvoice = detail.ConfigValue;
                        break;
                    case 94://  Unit Qty Pricing_DeliveryOrder
                        clsConfig.bUnitQtyPricing_DeliveryOrder = detail.ConfigValue;
                        break;

                    //Which Unit need to Validate in stock weight or qty



                    //Single Item Stock - to keep Production stock in a single Item 
                    case 115://   Stock Validate Weight_iSR
                        clsConfig.bSingleItemStockEnabled = detail.ConfigValue;
                        break;
                    case 116://  Pre Plan Lock When Woking Progress Done
                        clsConfig.bPrePlanItemLockWhenWorkInProgressDone = detail.ConfigValue;
                        break;
                    case 117://  Pre Plan Lock When Woking Progress Done
                        clsConfig.bPrePlanSectionPathLockWhenWorkInProgressDone = detail.ConfigValue;
                        break;


                    //Stock GRN and SRN same Serial
                    case 118://   Sales Returned Note GRN Having Same Item Serial
                        clsConfig.bSRNandGRNHavingSameSerial = detail.ConfigValue;
                        break;

                    //Auto Settle
                    case 127://Auto Settled Enable - Receipt
                        clsConfig.bAutoSettleEnableReceipt = detail.ConfigValue;
                        break;

                    //Auto CreditNote Creation
                    case 128://SRN - Auto CreditNote Create Enable
                        clsConfig.bSRN_AutoCreditNoteCreateEnable = detail.ConfigValue;
                        break;
                    case 129://SRN - Auto CreditNote Create Enable - Need Approval
                        clsConfig.bSRN_AutoCreditNoteCreateEnable_NeedApproval = detail.ConfigValue;
                        break;


                    //Stock Update    
                    case 130://SRN - Stock Update - Need Checking
                        clsConfig.bSRN_StockUpdate_NeedChecking = detail.ConfigValue;
                        break;

                    //Conver From Square Feet To Qty
                    case 131: //Auto Qty Convert From Square Feet
                        clsConfig.bAutoQtyConvertFromSquareFeet = detail.ConfigValue;
                        break;



                    //Direct Print 
                    case 134: //Direct Print - NP_Inquiry
                        clsConfig.bDirectPrint_NP_Inquiry = detail.ConfigValue;
                        break;
                    case 135: //Direct Print - NP_Quotation
                        clsConfig.bDirectPrint_NP_Quotation = detail.ConfigValue;
                        break;
                    case 136: //Direct Print - NP_ProforemaInvoice
                        clsConfig.bDirectPrint_NP_ProforemaInvoice = detail.ConfigValue;
                        break;
                    case 137: //Direct Print - NP_CustomerOrder
                        clsConfig.bDirectPrint_NP_CustomerOrder = detail.ConfigValue;
                        break;
                    case 138: //Direct Print - NP_DeliveryOrder
                        clsConfig.bDirectPrint_NP_DeliveryOrder = detail.ConfigValue;
                        break;
                    case 139: //Direct Print - NP_Invoice
                        clsConfig.bDirectPrint_NP_Invoice = detail.ConfigValue;
                        break;

                    case 144://   Direct Print - NP_Invoice
                        clsConfig.bDirectPrint_NP_ProductionJob = detail.ConfigValue;
                        break;


                    //case 145://   Auto Posting Enable - AccountPayableNote
                    //    clsConfig.bAutoPostingEnable_AccountPayableNote = detail.ConfigValue;
                    //    break;
                    //case 146://   Auto Posting Enable - PaymentVoucher
                    //    clsConfig.bAutoPostingEnable_PaymentVoucher = detail.ConfigValue;
                    //    break;
                    //case 147://   Auto Posting Enable - ReceiptVoucher
                    //    clsConfig.bAutoPostingEnable_ReceiptVoucher = detail.ConfigValue;
                    //    break;
                    //case 148://   Auto Posting Enable - Invoice
                    //    clsConfig.bAutoPostingEnable_Invoice = detail.ConfigValue;
                    //    break;
                    case 149://   Auto Posting Enable - Receipt
                        clsConfig.bAutoPostingEnable = detail.ConfigValue;
                        break;
                    case 150://   Auto Posting Enable - CreditNote
                        clsConfig.bAutoPostingEnable_Stock = detail.ConfigValue;
                        break;
                    //case 151://   Auto Posting Enable - DebitNote
                    //    clsConfig.bAutoPostingEnable_DebitNote = detail.ConfigValue;
                    //    break;

                    case 152://   bValidate_FIFO_QTY-INV
                        clsConfig.bValidate_InvoiceFIFO_QTY = detail.ConfigValue;
                        break;
                    case 153://   bValidate_FIFO_QTY-INV
                        clsConfig.bValidate_InvoiceFIFOCostPrice = detail.ConfigValue;
                        break;
                    case 154://   bValidate_CostCalculatedByInvoiceNotDO
                        clsConfig.bValidate_CostCalculatedByInvoiceNotDO = detail.ConfigValue;
                        break;
                    case 155://   bValidate_CostCalculatedByInvoiceNotDO
                        clsConfig.bValidate_ReceiptPostByChequeDate = detail.ConfigValue;
                        break;

                    //Stock Update    
                    case 156://FGTN - Stock Update - Need Checking
                        clsConfig.bFGTN_StockUpdate_NeedChecking = detail.ConfigValue;
                        break;

                    //Dataset Active
                    //case 157://FGTN - Dataset Active - Invoice NotePrint
                    //    clsConfig.bDatasetActive_InvoiceNotePrint = detail.ConfigValue;
                    //    break;

                    case 158:// Minus Qty Enable - DO
                        clsConfig.bMinusQtyEnable_DO = detail.ConfigValue;
                        break;

                    case 159:// Auto Realized On/Off - DO
                        clsConfig.bChequeAutoRealizedOn = detail.ConfigValue;
                        break;


                    case 160:// Auto Serial Create By SalesNoteType - DO
                        clsConfig.bSalesNoteType_SerialNoActiveFor_CustomerOrder = detail.ConfigValue;
                        break;
                    case 161:// Auto Serial Create By SalesNoteType - DO
                        clsConfig.bSalesNoteType_SerialNoActiveFor_DeliveryOrder = detail.ConfigValue;
                        break;
                    case 162:// Auto Serial Create By SalesNoteType - DO
                        clsConfig.bSalesNoteType_SerialNoActiveFor_Invoice = detail.ConfigValue;
                        break;
                    case 163:// Auto Serial Create By SalesNoteType - DO
                        clsConfig.bSalesNoteType_SerialNoActiveFor_SalesReturnedNote = detail.ConfigValue;
                        break;
                    case 164:/// Auto Serial Create By SalesNoteType - DO
                        clsConfig.bSalesNoteType_SerialNoActiveFor_CreditNote = detail.ConfigValue;
                        break;
                    case 165:// Auto Serial Create By SalesNoteType - DO
                        clsConfig.bSalesNoteType_SerialNoActiveFor_DebitNote = detail.ConfigValue;
                        break;
                    case 166:// Auto Serial Create By SalesNoteType - DO
                        clsConfig.bSalesNoteType_SerialNoActiveFor_ReciptSales = detail.ConfigValue;
                        break;


                    case 167://Auto Create Delivery Order - POS 
                        clsConfig.bPOSReceipt_AutoCreate_DO = detail.ConfigValue;
                        break;

                    case 168://Cheque Landscape
                        clsConfig.bChequeLandscape = detail.ConfigValue;
                        break;
                    case 169://Checking Need To Print PO
                        clsConfig.bCheckingNeedToPrintPO = detail.ConfigValue;
                        break;
                    case 170://Approval Need To Print PO 
                        clsConfig.bApprovalNeedToPrintPO = detail.ConfigValue;
                        break;
                    case 171://Checking Need To Print GRN
                        clsConfig.bCheckingNeedToPrintGRN = detail.ConfigValue;
                        break;
                    case 172://Approval Need To Print GRN 
                        clsConfig.bApprovalNeedToPrintGRN = detail.ConfigValue;
                        break;

                    case 173:// Serial Number Active
                        clsConfig.bSerialNumberActive = detail.ConfigValue;
                        break;

                    //Company Branch master Serial No
                    case 174:// BranchMaster_SerialNoActiveFor_CustomerOrder
                        clsConfig.bBranchMaster_SerialNoActiveFor_CustomerOrder = detail.ConfigValue;
                        break;
                    case 175:// BranchMaster_SerialNoActiveFor_DeliveryOrder
                        clsConfig.bBranchMaster_SerialNoActiveFor_DeliveryOrder = detail.ConfigValue;
                        break;
                    case 176:// BranchMaster_SerialNoActiveFor_Invoice
                        clsConfig.bBranchMaster_SerialNoActiveFor_Invoice = detail.ConfigValue;
                        break;
                    case 177:// BranchMaster_SerialNoActiveFor_CreditNote
                        clsConfig.bBranchMaster_SerialNoActiveFor_CreditNote = detail.ConfigValue;
                        break;
                    case 178:// BranchMaster_SerialNoActiveFor_DebitNote
                        clsConfig.bBranchMaster_SerialNoActiveFor_DebitNote = detail.ConfigValue;
                        break;
                    case 179:// BranchMaster_SerialNoActiveFor_SalesReturn
                        clsConfig.bBranchMaster_SerialNoActiveFor_SalesReturn = detail.ConfigValue;
                        break;
                    case 180:// BranchMaster_SerialNoActiveFor_DebitNote
                        clsConfig.bBranchMaster_SerialNoActiveFor_CustomerMaster = detail.ConfigValue;
                        break;
                    case 181:// BranchMaster_SerialNoActiveFor_SupplierMaster
                        clsConfig.bBranchMaster_SerialNoActiveFor_SupplierMaster = detail.ConfigValue;
                        break;
                    case 182:// Display ItemName In POS Item Button
                        clsConfig.bDisplayItemNameInPOSItemButton = detail.ConfigValue;
                        break;
                    case 183:// BranchMaster_SerialNoActiveFor_SalesReceipt
                        clsConfig.bBranchMaster_SerialNoActiveFor_SalesReceipt = detail.ConfigValue;
                        break;

                    case 184:// MettleDetail GridViewColumn
                        clsConfig.bMettleDetail_GridViewColumn = detail.ConfigValue;
                        break;
                    case 185:// GemDetail_GridViewColumn
                        clsConfig.bGemDetail_GridViewColumn = detail.ConfigValue;
                        break;
                    case 186:// SellingPrice_GridViewColumn
                        clsConfig.bSellingPrice_GridViewColumn = detail.ConfigValue;
                        break;
                    case 187:// SellingPrice_GridViewColumn
                        clsConfig.bItemSubCategoryID_GridViewColumn = detail.ConfigValue;
                        break;
                    case 188:// SellingPrice_GridViewColumn
                        clsConfig.bSerialNo_GridViewColumn = detail.ConfigValue;
                        break;
                    case 189:// SellingPrice_GridViewColumn
                        clsConfig.bCostPrice_GridViewColumn = detail.ConfigValue;
                        break;
                    case 190:// SellingPrice_GridViewColumn
                        clsConfig.bRefNo_GridViewColumn = detail.ConfigValue;
                        break;
                    case 191:// SellingPrice_GridViewColumn
                        clsConfig.bPOS_DisplaySerialNo_SalesGridViewColumn = detail.ConfigValue;
                        break;
                    case 192:// SellingPrice_GridViewColumn
                        clsConfig.bEnableReceiptSort_ByReceiptID = detail.ConfigValue;
                        break;
                    //case 193:// AutoPostingEnable_CashDeposit
                    //    clsConfig.bAutoPostingEnable_CashDeposit = detail.ConfigValue;
                    //    break;
                    //case 194:// AutoPostingEnable_ChequeDeposit
                    //    clsConfig.bAutoPostingEnable_ChequeDeposit = detail.ConfigValue;
                    //    break;
                    //case 195:// AutoPostingEnable_ChequeReturned
                    //    clsConfig.bAutoPostingEnable_ChequeReturned = detail.ConfigValue;
                    //    break;
                    case 196:// AutoPostingEnable_ChequeReturned
                        clsConfig.bActivate_paymentVoucherNotePrintingwithAccountCode = detail.ConfigValue;
                        break;
                    case 197:// bUsePosPrinter
                        clsConfig.bUsePosPrinter = detail.ConfigValue;
                        break;
                    case 198:// bDirect_Print_Pos_Invoice
                        clsConfig.bDirect_Print_Pos_Invoice = detail.ConfigValue;
                        break;
                    case 199:
                        clsConfig.bPOSItemSearch_StoreWiseEnable = detail.ConfigValue;
                        break;
                    case 200:
                        clsConfig.bIsAllPaymentMethodsAreActive = detail.ConfigValue;
                        break;
                    case 201:
                        clsConfig.bPOSItemSearch_CheckForPhysicalQty = detail.ConfigValue;
                        break;
                    case 202:
                        clsConfig.bPOSItemSearch_CheckForAvailableQty = detail.ConfigValue;
                        break;
                    case 203:
                        clsConfig.bPOSItemSearch_StockValidationEnable = detail.ConfigValue;
                        break;
                    case 204:
                        clsConfig.bPOSSaveActualPayedAmount = detail.ConfigValue;
                        break;
                    case 205:
                        clsConfig.bOpenImageInImageTempFolder = detail.ConfigValue;
                        break;
                    case 206:
                        clsConfig.bDAPL_GRN_Block_BranchCode = detail.ConfigValue;
                        break;
                    case 207:
                        clsConfig.bStockAdjustment_StockUpdate_NeedApproval = detail.ConfigValue;
                        break;
                    case 208:
                        clsConfig.bDisplayBankManagemnet_CashDeposit_Account = detail.ConfigValue;
                        break;
                    case 209:
                        clsConfig.bDisplayBankManagemnet_ChequeDeposit_Account = detail.ConfigValue;
                        break;
                    case 210:
                        clsConfig.bDebitnoteType_SerialNoActiveFor_DebitNote = detail.ConfigValue;
                        break;

                    case 211:
                        clsConfig.bEnableAdvancedItemViewer = detail.ConfigValue;
                        break;
                    case 212:// Auto Serial Create By SalesNoteType - DO
                        clsConfig.bBranchMaster_SerialNoActiveFor_Receipt = detail.ConfigValue;
                        break;
                    case 213:// Genaral Ledger report Group Cash Deposit
                        clsConfig.bGenaralLedgerreport_GroupCashDeposit = detail.ConfigValue;
                        break;
                    case 214://bUse_Seperate_Serial_Number_Advanced_And_Partpayment_Resipt 
                        clsConfig.bUseSeperateSerialNo_AdvancedAndPartpaymentReceipt = detail.ConfigValue;
                        break;
                    case 215://bUse_Seperate_Serial_Number_Advanced_And_Partpayment_Resipt 
                        clsConfig.bisDataSetActive_DONotePrinting = detail.ConfigValue;
                        break;
                    case 216://isEnable_QuantityExceedPercentageLock 
                        clsConfig.isEnable_QuantityExceedPercentageLock = detail.ConfigValue;
                        break;
                    case 217://bUse_Seperate_Serial_Number_Advanced_And_Partpayment_Resipt 
                        clsConfig.bUseSeperateSerialNoInterimReceipt = detail.ConfigValue;
                        break;
                    case 218://SRN - Auto CreditNote Create Enable - Need Approval
                        clsConfig.bSRN_AutoCreditNoteCreateEnable_Returnable = detail.ConfigValue;
                        break;
                    case 219://Enable DataGrid Setting
                        clsConfig.bEnableDataGridSetting = detail.ConfigValue;
                        break;
                    case 220:
                        clsConfig.bShowJobNo_StockControllPanel_forDocNo = detail.ConfigValue;
                        break;
                    case 221:
                        clsConfig.bisDataSet_AccountPaybleNote = detail.ConfigValue;
                        break;

                    case 222:
                        clsConfig.bSalesNoteType_SerialNoActiveFor_ReciptSales_AndDifferntNoForAdvances = detail.ConfigValue;
                        break;
                    case 223:
                        clsConfig.bAllowInvoiceLessThanDO_Qty = detail.ConfigValue;
                        break;
                    case 224:
                        clsConfig.bAllowCashAndCheque_InOneReceipt = detail.ConfigValue;
                        break;
                    case 225:
                        clsConfig.bStockNoteType_SerialNoActiveFor_PurchaseOrder = detail.ConfigValue;
                        break;
                    case 226:
                        clsConfig.bStockNoteType_SerialNoActiveFor_PurchaseRequisitionNote = detail.ConfigValue;
                        break;
                    case 227:
                        clsConfig.bStockNoteType_SerialNoActiveFor_GoodsReceivedNote = detail.ConfigValue;
                        break;
                    case 228:
                        clsConfig.bStockNoteType_SerialNoActiveFor_PurchaseReturnNote = detail.ConfigValue;
                        break;
                    case 229:
                        clsConfig.bBackDateEnable_CustomerOutstandingReports = detail.ConfigValue;
                        break;
                    case 230:
                        clsConfig.bEnableReceiptDateAndChequeDateValidater = detail.ConfigValue;
                        break;
                    case 231:
                        clsConfig.bPV_UseChequeDate_As_PVPostingDate = detail.ConfigValue;
                        break;
                    case 232:
                        clsConfig.bisDataSetActive_PaymentVoucherNotePrinting = detail.ConfigValue;
                        break;
                    case 233:
                        clsConfig.bDataSetActive_LoanInLoanOut = detail.ConfigValue;
                        break;
                    case 234:
                        clsConfig.isEnable_QuantityExceedPercentageLock_GRN = detail.ConfigValue;
                        break;
                    case 235:
                        clsConfig.bIsUserWise_EnableDisableReport = detail.ConfigValue;
                        break;
                    case 236:
                        clsConfig.bItemSerialNo_Active = detail.ConfigValue;
                        break;
                    case 237:
                        clsConfig.bItemSerialNo_EnableDuplication_GRN = detail.ConfigValue;
                        break;
                    case 238:
                        clsConfig.bItemSerialNo_EnableQtyValidation_GRNDetailvsSerial = detail.ConfigValue;
                        break;
                    case 239:
                        clsConfig.bMandatoryFieldEnable_iSR_JobNo = detail.ConfigValue;
                        break;
                    case 240:
                        clsConfig.bMandatoryFieldEnable_iGIN_JobNo = detail.ConfigValue;
                        break;
                    case 241:
                        clsConfig.bMandatoryFieldEnable_iGRN_JobNo = detail.ConfigValue;
                        break;
                    case 242:
                        clsConfig.bMandatoryFieldEnable_iSR_RefNo = detail.ConfigValue;
                        break;
                    case 243:
                        clsConfig.bMandatoryFieldEnable_iGIN_RefNo = detail.ConfigValue;
                        break;
                    case 244:
                        clsConfig.bMandatoryFieldEnable_iGRN_RefNo = detail.ConfigValue;
                        break;
                    case 245:
                        clsConfig.bItemSerialNoActive_iSR = detail.ConfigValue;
                        break;
                    case 246:
                        clsConfig.bItemSerialNoActive_iGIN = detail.ConfigValue;
                        break;
                    case 247:
                        clsConfig.bItemSerialNoActive_iGRN = detail.ConfigValue;
                        break;
                    case 248:
                        clsConfig.bCommission_ActivateNetValue = detail.ConfigValue;
                        break;
                    case 249:
                        clsConfig.bIsEnabledMultiple_Discount = detail.ConfigValue;
                        break;
                    case 250:
                        clsConfig.bDisplay_ItemUnitPrice_StoreTransferNotes = detail.ConfigValue;
                        break;
                    case 251:
                        clsConfig.bValidateStock_WhenAddingMultipleItems = detail.ConfigValue;
                        break;
                    case 252:
                        clsConfig.bIsEnableZeroItemQuentityValidate_DO = detail.ConfigValue;
                        break;
                    case 253:
                        clsConfig.bIsEnableZeroItemQuentityValidate_GIN = detail.ConfigValue;
                        break;
                    case 254:
                        clsConfig.bIsEnableStartupStocReconcilation = detail.ConfigValue;
                        break;
                    case 255:
                        clsConfig.bApprovalNeed_ToUpdateStock_ItemSplitNote = detail.ConfigValue;
                        break;
                    case 256:
                        clsConfig.bHide_GridViewColumn_Stock_Weight = detail.ConfigValue;
                        break;
                    case 257:
                        clsConfig.bHide_GridViewColumn_Stock_GoodsFrom = detail.ConfigValue;
                        break;
                    case 258:
                        clsConfig.bHide_GridViewColumn_Stock_NoteID = detail.ConfigValue;
                        break;
                    case 259:
                        clsConfig.bDateSetActive_PurchaseOrderPrint = detail.ConfigValue;
                        break;
                    case 260:
                        clsConfig.bIsCustomerMandatory_ItemFinanceScreen = detail.ConfigValue;
                        break;
                    case 262:
                        clsConfig.bIsRateLocked_Multiple_Discount = detail.ConfigValue;
                        break;
                    case 261:
                        clsConfig.bItemSearch_ValidateAddingDuplicateItem = detail.ConfigValue;
                        break;
                    case 263:
                        clsConfig.bBranchMaster_SerialNoActiveFor_Pos_Transaction = detail.ConfigValue;
                        break;
                    case 264:
                        clsConfig.bBranchMaster_SerialNoActiveFor_Pos_Receipt = detail.ConfigValue;
                        break;
                    case 266:
                        clsConfig.bDisplayPoSBackgroundImage = detail.ConfigValue;
                        break;
                    case 267:
                        clsConfig.bisDatasetActive_SalesReturnNotePrinting = detail.ConfigValue;
                        break;
                    case 268:
                        clsConfig.bisDatasetActive_DebitNotePrinting = detail.ConfigValue;
                        break;
                    case 269:
                        clsConfig.bShowQty_InvoiceReristerDetails = detail.ConfigValue;
                        break;
                    case 270:
                        clsConfig.bCartonNo_GridViewColumn = detail.ConfigValue;
                        break;
                    case 271:
                        clsConfig.bSRn_Item_Validation_With_DO = detail.ConfigValue;
                        break;
                    case 272:
                        clsConfig.bDataSetActive_DepositedChequeSummary = detail.ConfigValue;
                        break;
                    case 273:
                        clsConfig.bEnable_TAX_ManualMode = detail.ConfigValue;
                        break;
                    case 274:
                        clsConfig.bAllow_user_to_Dupplicate_items_SAS_Transactions = detail.ConfigValue;
                        break;
                    case 275:
                        clsConfig.bDataSetActive_CustomerOrder = detail.ConfigValue;
                        break;
                    case 276:
                        clsConfig.bPriceDetailsHide_DeliveryOrder = detail.ConfigValue;
                        break;
                    case 277:
                        clsConfig.bAllow_user_to_Dupplicate_items_SCS_Transactions = detail.ConfigValue;
                        break;
                    case 278:
                        clsConfig.bValidateCostPriceVsSellPrice = detail.ConfigValue;
                        break;
                    case 279:
                        clsConfig.bLock_TransactionDate_SAS = detail.ConfigValue;
                        break;
                    case 280:
                        clsConfig.bLock_TransactionDate_SCS = detail.ConfigValue;
                        break;
                    case 281:
                        clsConfig.bProductActivated = true;//detail.ConfigValue;
                        break;
                    case 282:
                        clsConfig.bDataSetActive_PurchseRequision = detail.ConfigValue;
                        break;
                    case 283:
                        clsConfig.bShowDONotInvoiced = detail.ConfigValue;
                        break;
                    case 284:
                        clsConfig.bAllow_Multiple_DO_For_Invoice = detail.ConfigValue;
                        break;
                    case 285:
                        clsConfig.bDataSetActive_DamageGood = detail.ConfigValue;
                        break;
                    case 286:
                        clsConfig.bEnableF5_StockAdjustment = detail.ConfigValue;
                        break;
                    case 287:
                        clsConfig.bEnableProformaInvoice_AccountNo = detail.ConfigValue;
                        break;
                    case 288:
                        clsConfig.bEnableMandatory_PONo_for_GRN = detail.ConfigValue;
                        break;
                    case 289:
                        clsConfig.bVisible_digiteq_User = detail.ConfigValue;
                        break;
                    case 290:
                        clsConfig.bHide_GridViewColumn_Stock_CostPrice = detail.ConfigValue;
                        break;
                    case 291:
                        clsConfig.bHide_GridViewColumn_Stock_TotalCostPrice = detail.ConfigValue;
                        break;
                    case 292:
                        clsConfig.bHide_GridViewColumn_Stock_SellingPrice = detail.ConfigValue;
                        break;
                    //create for PO ui by janith
                    case 293:
                        clsConfig.bRemove_alreadyGRNitems_from_PO = detail.ConfigValue;
                        break;
                    //create for ISR note print by janith
                    case 294:
                        clsConfig.bPrintPreviewSetActive_StoreRequisition = detail.ConfigValue;
                        break;
                    case 296:
                        clsConfig.bDataSetActive_iGRN = detail.ConfigValue;
                        break;
                    case 297:
                        clsConfig.bDataSetActive_iGIN = detail.ConfigValue;
                        break;
                    case 298:
                        clsConfig.bDataSetActive_SplitNote = detail.ConfigValue;
                        break;
                    //create for password reminder change
                    //change due to reason
                    //case 295:
                    //    clsConfig.bIsEnablePasswordChange_Reminder = detail.ConfigValue;
                    //    break;
                    case 299:
                        clsConfig.bCreditBalanceInvoice_Check = detail.ConfigValue;
                        break;
                    case 300:
                        clsConfig.bCheckingNeedToPrintAPNDetail = detail.ConfigValue;
                        break;
                    case 302:
                        clsConfig.isEnable_CreateStorefor_SalesRep = detail.ConfigValue;
                        break;
                    case 303:
                        clsConfig.bHide_GridViewColumn_Store_PendingQty = detail.ConfigValue; //hide pending qty customer wise
                        break;
                    case 304:
                        clsConfig.bDO_HideSettingsPanel = detail.ConfigValue; //hide DO Settings Panel
                        break;
                    case 305:
                        clsConfig.bShow_ManuallyEnter_DeliveryAddress = detail.ConfigValue; //Show, DO Manually Enter Delivery Address
                        break;
                    case 306:
                        clsConfig.bChange_Name_lblTerms = detail.ConfigValue; //Change label name to Payment Terms
                        break;
                    case 307:
                        clsConfig.bHide_PriceCategory_DO = detail.ConfigValue; //Change label name to Payment Terms
                        break;
                    case 308:
                        clsConfig.bHide_Fields_DO = detail.ConfigValue; //Change label name to Payment Terms
                        break;
                    case 309:
                        clsConfig.bHide_SpecialSettings_Invoice = detail.ConfigValue; //Change label name to Payment Terms
                        break;
                    case 310:
                        clsConfig.bDisplay_ChequePrint_AmountEndWith_StarMark = detail.ConfigValue; //Change Cheque Print Amount End With Stars
                        break;
                    case 311:
                        clsConfig.bShow_CustomerOrderTracking_Report = detail.ConfigValue; //Show Customer order tracking report for RHP
                        break;
                    case 312:
                        clsConfig.bDisplay_DeliveredQuantity_DeliveryOrderItems = detail.ConfigValue; //Display Delivered Quantity in Delivery Order Items
                        break;
                    case 313:
                        clsConfig.bShowGrid_FreeColumn_DO = detail.ConfigValue; //Show Delivery Order Free Column - Celcius
                        break;
                    case 314:
                        clsConfig.bShowFreeItems = detail.ConfigValue;
                        break;

                    case 315:
                        clsConfig.bShowItemComponents = detail.ConfigValue;
                        break;
                    case 316:
                        clsConfig.bIsEnableStartupStocReconciliation_SQL_SP = detail.ConfigValue;
                        break;
                        
                    //PRoduction System R2 ( 400 Onwards )
                    case 400:
                        clsConfig.b_Prod_InactiveWIP_QuantityCalculationAutomate = detail.ConfigValue;
                        break;
                    case 401:
                        clsConfig.b_Prod_View_Competitive_ProductComparison = detail.ConfigValue;
                        break;
                    case 402:// GRN Price
                        clsConfig.bEnableGridLock_Price_GRN = detail.ConfigValue;
                        break;
                    case 403:// Stk Adj.
                        clsConfig.bShowSystemQty = detail.ConfigValue;
                        break;
                    case 404:
                        clsConfig.bPostReversalEntry_WhenCancellation = detail.ConfigValue;
                        break;
                    case 405:
                        clsConfig.bHide_NoteType_Invoice = detail.ConfigValue;
                        break;
                    case 406:
                        clsConfig.bCheckValidation_BudgetExceed = detail.ConfigValue;
                        break;
                    case 409:
                        clsConfig.bShow_GridViewColumn_Remarks = detail.ConfigValue;
                        break;
                    case 410:
                        clsConfig.bAdvanceCashDepositeEnable = detail.ConfigValue;
                        break;
                    case 411:
                        clsConfig.bDisplay_TaxCreditNote = detail.ConfigValue;
                        break;
                    case 412:
                        clsConfig.bDisplay_RefundableButton = detail.ConfigValue;
                        break;

                    case 414:
                        clsConfig.benable_multipleDO_Invoice = detail.ConfigValue;
                        break;
                    case 415:
                        clsConfig.benable_TaxSelection_Quotation = detail.ConfigValue;
                        break;
                    case 416:
                        clsConfig.enableBranchWiseFilterOnSearch = detail.ConfigValue;
                        break;
                    case 417:
                        clsConfig.bLoadZeroQtyItems_DOGrid = detail.ConfigValue;
                        break;
                    case 418:
                        clsConfig.bWrap_ItemGrid_ItemName = detail.ConfigValue;
                        break;
                    case 419:
                        clsConfig.bShowAll_branches_storeSearch = detail.ConfigValue;
                        break;
                    case 420:
                        clsConfig.enableBranchWiseItemSearch = detail.ConfigValue;
                        break;
                    case 421:
                        clsConfig.isVisibleCompanyInfoInDraftPrint = detail.ConfigValue;
                        break;
                    case 422:
                        clsConfig.bReceipt_isCollectorMandatory = detail.ConfigValue;
                        break;
                    case 423:
                        clsConfig.bRecipt_Validate_AccountNo = detail.ConfigValue;
                        break;
                    case 424:
                        clsConfig.bDataSetActive_GIN = detail.ConfigValue;
                        break;
                    case 425:
                        clsConfig.bApprovalEnabledPurchaseOrder = detail.ConfigValue;
                        break;
                    case 426:
                        clsConfig.bitemSplitNote_ToStoreActive = detail.ConfigValue;
                        break;
                    case 427:
                        clsConfig.bEnableSalesReturn_DirectPosting = detail.ConfigValue;
                        break;
                    case 428:
                        clsConfig.bEnable_CreditNoteWithSalesReturnItem = detail.ConfigValue;
                        break;
                    case 429:
                        clsConfig.bLoadItemSearch_ByStore = detail.ConfigValue;
                        break;

                    case 430:// APN Approve
                        clsConfig.bApprovalNeedToPrintAPN = detail.ConfigValue;
                        break;
                    case 431:// APN Check
                        clsConfig.bCheckingNeedToPrintAPN = detail.ConfigValue;
                        break;
                    case 432:// Approval check for Internal Transfer searches
                        clsConfig.bApprovalNeedForInternalTransferNoteSearch = detail.ConfigValue;
                        break;
                    case 433:
                        clsConfig.bEnable_AutomatedChequePrint = detail.ConfigValue;
                        break;
                    case 434:
                        clsConfig.bHideGRNNo_APN = detail.ConfigValue;
                        break;
                    case 435://Checking Need To Print GTN
                        clsConfig.bCheckingNeedToPrintGTN = detail.ConfigValue;
                        break;
                    case 436://Approval Need To Print GTN 
                        clsConfig.bApprovalNeedToPrintGTN = detail.ConfigValue;
                        break;
                    case 437://Old CRN posting
                        clsConfig.bEnableOldCRNposting = detail.ConfigValue;
                        break;
                    case 438:
                        clsConfig.bEnableSalesman_DO = detail.ConfigValue;
                        break;
                    case 439:
                        clsConfig.bHideBreakDownDetail_DO = detail.ConfigValue;
                        break;
                    case 440:
                        clsConfig.bShowQtyANDWeightColumns_DO = detail.ConfigValue;
                        break;
                    case 441:
                        clsConfig.bEnableFinishedGood_Validation = detail.ConfigValue;
                        break;
                    case 442:
                        clsConfig.bDisableMultipleCustomerBranch = detail.ConfigValue;
                        break;

                    //SEACC PRODUCTION (Value ID from 500 to 600)
                    //--PROD APPAREL (From 501 to 550)
                    case 501:
                        clsConfig.bBoM_CustomerOrderIDUpdate_NeedChecking = detail.ConfigValue;
                        break;
                    case 502:
                        clsConfig.bBoM_CustomerOrderIDUpdate_NeedApproval = detail.ConfigValue;
                        break;

                    //--PROD PHARMA (From 551 to 600)
                    //--Not Yet

                    //--SEACC R2 POS (FROM 601 - 700)
                    //--See POS Project => clsBackProcess.cs File

                    //--PROD POLY (From 701 - 800)
                    case 701:
                        clsConfig.bCreditBalanceCustomerOrder_Message = detail.ConfigValue;
                        break;
                    case 702:
                        clsConfig.bCreditBalanceCustomerOrder_Lock = detail.ConfigValue;
                        break;
                    case 703:
                        clsConfig.bAllowToAddZeroQty_PrePlan_Inputs = detail.ConfigValue;
                        break;
                    case 704:
                        clsConfig.bEnableDirectProdcutionJobSave = detail.ConfigValue;
                        break;
                    case 710:
                        clsConfig.bEnableRouteWisePermissionCheck = detail.ConfigValue;
                        break;
                }
            }
        }
        #endregion

        #region Auto Assign Company Values
        //public static void AutoAssignCompanyValue()
        //{
        //    //foreach (tbl_securityCompanyValues detail in tbl_securityCompanyValues.SelectAll())
        //    //{
        //    //    if (detail.CompanyValues_ID == 1) //Quotation Subject
        //    //        clsConfig.sCmp_qQuotationSubject = detail.CompanyValuesDetail.Trim();
        //    //    else if (detail.CompanyValues_ID == 2) //Payment Terms
        //    //        clsConfig.sCmp_qPaymentTerms = detail.CompanyValuesDetail.Trim();
        //    //    else if (detail.CompanyValues_ID == 3) //Validity Period
        //    //        clsConfig.sCmp_qValidityPeriod = detail.CompanyValuesDetail.Trim();
        //    //    else if (detail.CompanyValues_ID == 4) //Delivery Period
        //    //        clsConfig.sCmp_qDeliveryPeriod = detail.CompanyValuesDetail.Trim();
        //    //    else if (detail.CompanyValues_ID == 5) //Contact Telephone
        //    //        clsConfig.sCmp_qContactTelephone = detail.CompanyValuesDetail.Trim();
        //    //    else if (detail.CompanyValues_ID == 6) //Contact Email
        //    //        clsConfig.sCmp_qContactEmail = detail.CompanyValuesDetail.Trim();
        //    //    else if (detail.CompanyValues_ID == 7) //Company Type
        //    //        clsConfig.sCmp_companyCode = detail.CompanyValuesDetail.Trim();
        //    //}

        //    tbl_genCompanyInfo com = tbl_genCompanyInfo.Select(clsSecurity.getRegDBComapanyName());
        //    if (com != null)
        //    {
        //        clsSecurity.CompanyName = clsCript.Decrypt(com.CompanyName);
        //        clsSecurity.CompanyAddress1 = clsCript.Decrypt(com.Address);
        //        clsSecurity.CompanyAddress2 = "";
        //        if (com.Telephone1.Length > 0)
        //            clsSecurity.CompanyAddress2 = "Tel : " + com.Telephone1;
        //        if (com.Telephone2.Length > 0)
        //            clsSecurity.CompanyAddress2 += " | " + com.Telephone2;
        //        if (com.Fax.Length > 0)
        //            clsSecurity.CompanyAddress2 += " FAX : " + com.Fax;
        //    }

        //    if (clsSecurity.BranchID != null)
        //    {
        //        clsSecurity.BranchName = clsGenaralName.getName_CompanyBranchMaster(clsSecurity.BranchID);
        //    }

        //}
        #endregion

        #region Auto Assign Commission Values
        public static void AutoAssignCommissionValues()
        {
            foreach (tbl_zCommissionSlabSetting oSlab in tbl_zCommissionSlabSetting.SelectAll())
            {
                if (oSlab.SlabID == "1")
                {
                    clsConfig.dRange1_Days = oSlab.DateRange;
                    clsConfig.dRange1_Pasantage = oSlab.CommissionPercentage;
                }
                else if (oSlab.SlabID == "2")
                {
                    clsConfig.dRange2_Days = oSlab.DateRange;
                    clsConfig.dRange2_Pasantage = oSlab.CommissionPercentage;
                }
                else if (oSlab.SlabID == "3")
                {
                    clsConfig.dRange3_Days = oSlab.DateRange;
                    clsConfig.dRange3_Pasantage = oSlab.CommissionPercentage;
                }
                else if (oSlab.SlabID == "4")
                {
                    clsConfig.dRange4_Days = oSlab.DateRange;
                    clsConfig.dRange4_Pasantage = oSlab.CommissionPercentage;
                }
            }
        }
        #endregion

        #region Auto Assign GL Codes
        public static void AutoAssignGLCodes()
        {
            foreach (tbl_zTax oSlab in tbl_zTax.SelectAll())
            {
                if (oSlab.Tax_ID == "TAX/002") //NBT
                {
                    clsConfig.sNBTGLCode_Payable = oSlab.PayableGl_ID;
                    clsConfig.sNBTGLCode_Receivable = oSlab.ReceivableGl_ID;
                }
                else if (oSlab.Tax_ID == "TAX/001") //VAT
                {
                    clsConfig.sVATGLCode_Payable = oSlab.PayableGl_ID;
                    clsConfig.sVATGLCode_Receivable = oSlab.ReceivableGl_ID;
                }
            }
        }
        #endregion

        #region Update Supplier
        //public static void UpdateSupplierMaster_OutstandingAmount(string supplierCode, decimal dTransactionAmount, decimal dChequeInHandAmount, Boolean bIsCredit)
        //{
        //    tbl_genSupplierMaster oSupMaster = tbl_genSupplierMaster.Select(supplierCode);
        //    if (oSupMaster != null && supplierCode != "default")
        //    {
        //        decimal dCRMultiplier = 1;
        //        if (!bIsCredit == true)
        //            dCRMultiplier = -1;

        //        oSupMaster.OutstandingAmount += dCRMultiplier * dTransactionAmount;
        //        oSupMaster.ChequeInHandAmount += dCRMultiplier * dChequeInHandAmount;
        //        oSupMaster.Update(); ;
        //    }
        //}
        #endregion

        #region Auto Assign Stock Exceed Lock
        //public static void AutoAssignStockExceedLock()
        //{
        //    foreach (tbl_securityItemExceedLock detail in tbl_securityItemExceedLock.SelectAll())
        //    {
        //        switch (detail.ValueID)
        //        {
        //            case 7://Stock Exceed Lock - Delivery Order
        //              //  clsConfig.bStockExceedLock_DeliveryOrder = detail.ConfigValue;
        //                break;
        //            case 8://Stock Exceed Lock - iSR
        //             //   clsConfig.bStockExceedLock_iSR = detail.ConfigValue;
        //                break;
        //            case 9://Stock Exceed Lock - Delivery Order
        //             //   clsConfig.bStockExceedLock_iGIN = detail.ConfigValue;
        //                break;
        //            case 10://Stock Exceed Lock - Delivery Order
        //              //  clsConfig.bStockExceedLock_iGRN = detail.ConfigValue;
        //                break;
        //        }
        //    }
        //}
        #endregion

        #region Auto Assign Payment Methods
        //public static void AutoAssignPaymentMethods()
        //{
        //    //clsConfig.sPaymentMethod_Cash = clsAutocode.getPaymentMethodCode(PaymentMethods.Cash);
        //    //clsConfig.sPaymentMethod_Cheque = clsAutocode.getPaymentMethodCode(PaymentMethods.Cheque);
        //    //clsConfig.sPaymentMethod_Visa = clsAutocode.getPaymentMethodCode(PaymentMethods.Visa);
        //    //clsConfig.sPaymentMethod_Master = clsAutocode.getPaymentMethodCode(PaymentMethods.Master);
        //    //clsConfig.sPaymentMethod_LoyalityCard = clsAutocode.getPaymentMethodCode(PaymentMethods.LoyalityCard);
        //    //clsConfig.sPaymentMethod_Voucher = clsAutocode.getPaymentMethodCode(PaymentMethods.Voucher);
        //    //clsConfig.sPaymentMethod_Bank_Slip = clsAutocode.getPaymentMethodCode(PaymentMethods.Bank_Slip);
        //    //clsConfig.sPaymentMethod_Bank_Swift = clsAutocode.getPaymentMethodCode(PaymentMethods.Bank_Swift);
        //    //clsConfig.sPaymentMethod_Amex = clsAutocode.getPaymentMethodCode(PaymentMethods.Amex);
        //    //clsConfig.sPaymentMethod_DinersClub = clsAutocode.getPaymentMethodCode(PaymentMethods.DinersClub);
        //    //clsConfig.sPaymentMethod_GiftVouther = clsAutocode.getPaymentMethodCode(PaymentMethods.GiftVoucher);
        //    //clsConfig.sPaymentMethod_StarPoint = clsAutocode.getPaymentMethodCode(PaymentMethods.StarPoints);
        //}
        #endregion

        //Cheque
        #region Cheque Realizing
        //public static void AutoChequeRealized()
        //{
        //    try
        //    {
        //        List<tbl_bpsChequeRegister> details = tbl_bpsChequeRegister.SelectAll();
        //        foreach (tbl_bpsChequeRegister detail in details)
        //        {
        //            if (detail.PaymentMethod_ID == (int)PaymentRegisterTransfers.Cheque)
        //            {
        //                if (detail.IsDepositted && !detail.IsReconcilied)
        //                {
        //                    int iDays = 0;
        //                    if (clsSecurity.getServerDateTime().Year > detail.DateCheque.Year)
        //                    {
        //                        int iDaysLastYear = 365 - detail.DateCheque.DayOfYear;
        //                        iDays = clsSecurity.getServerDateTime().DayOfYear + iDaysLastYear;
        //                    }
        //                    else
        //                        iDays = clsSecurity.getServerDateTime().DayOfYear - detail.DateCheque.DayOfYear;

        //                    if (iDays > 10)
        //                    {
        //                        detail.IsReconcilied = true;
        //                        //detail.ChequeStatus_ID = clsAutocode.getChequeStatusID(ChequeStatus.Realized);
        //                        detail.DateReconcilied = clsSecurity.getServerDateTime();
        //                        detail.Update();
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsValidate.WriteErrorLog("", 0,ex);
        //        MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        #endregion

        //Stock
        #region Weekly Stock Take
        //public static void AutoWeeklyStockTake()
        //{
        //    try
        //    {
        //        DateTime firstDate = clsSecurity.FirstDayOfMonthFromDateTime(clsSecurity.getServerDateTime());

        //        //clsSecurity.GetFirstDayOfWeek(clsSecurity.getServerDateTime(), DayOfWeek.Monday); //get the firstday of the week
        //        tbl_scsWeeklyStockTake stock = tbl_scsWeeklyStockTake.Select(clsFormatter.FormatDate_Short(firstDate));
        //        if (stock == null) //has no record for the first day of this week
        //        {
        //            //insert header
        //            tbl_scsWeeklyStockTake wStock = new tbl_scsWeeklyStockTake(clsFormatter.FormatDate_Short(firstDate), clsSecurity.getServerDateTime());
        //            wStock.Insert();

        //            //insert detail
        //            List<tbl_genStore_Stock> details = tbl_genStore_Stock.SelectAll();
        //            foreach (tbl_genStore_Stock detail in details)
        //            {
        //                if (detail.Qty > 0)
        //                {
        //                    tbl_scsWeeklyStockTake_Detail wStockDetail = new tbl_scsWeeklyStockTake_Detail(clsFormatter.FormatDate_Short(firstDate), detail.Store_ID,
        //                        detail.Item_ID, detail.Job_ID, detail.ItemSubCategory_ID, detail.ItemSubCategory2_ID, detail.ItemSerialNo, detail.ItemSerialNo2,
        //                        detail.Qty, detail.AvailableQty, detail.Weight, detail.AvailableWeight, detail.Meter, detail.AvailableMeter, detail.WasteageWeight, detail.DamageWeight);
        //                    wStockDetail.Insert();
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        clsValidate.WriteErrorLog("", 0,ex);
        //    }
        //}
        #endregion

        //Receipt
        #region Receipt Settle
        public static void AutoReceiptSettle()
        {
            try
            {
                List<tbl_bpsReceipt> details = tbl_bpsReceipt.SelectAll();
                foreach (tbl_bpsReceipt detail in details)
                {
                    if (!detail.IsDeleted && !detail.IsSeattled && detail.Receipt_ID != "default")
                    {
                        bool bChequesOK = true;
                        //if (detail.CashAmount > 0 && detail.ChequeAmount == 0)
                        //{

                        //}
                        if (detail.CashAmount == 0 && detail.ChequeAmount > 0)
                        {

                            foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(detail.Receipt_ID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default"))
                            {
                                if (oCheque.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                                {
                                    if (!oCheque.IsSetteled)
                                    {
                                        bChequesOK = false;
                                        break;
                                    }
                                }
                                else
                                {
                                    if (oCheque.Amount == oCheque.SetteledAmount)
                                    {
                                        oCheque.IsSetteled = true;
                                        oCheque.Update();
                                    }
                                }
                            }
                            if (bChequesOK)
                            {
                                detail.IsSeattled = true;
                                detail.Update();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        //Chat
        #region Get First UnRead ChatID
        public static string GetUnReadChatID()
        {
            string sChatID = "";
            List<tbl_utlChatUser> details = tbl_utlChatUser.SelectAllByUser_ID(clsSecurity.UserIDLoged);
            foreach (tbl_utlChatUser detail in details)
            {
                if (!detail.IsRemoved && detail.HasUnReadMessages)
                {
                    sChatID = detail.Chat_ID;
                    break;
                }
            }
            return sChatID;
        }
        #endregion

        #region Get New Loged UserID
        public static string GetNewLogedUserID()
        {
            string sUserID = "";
            List<tbl_utlUserPool> details = tbl_utlUserPool.SelectAll();
            foreach (tbl_utlUserPool detail in details)
            {
                if (detail.IsNewLogin && detail.User_ID != clsSecurity.UserIDLoged)
                {
                    sUserID = detail.User_ID;
                    detail.IsNewLogin = false;
                    detail.Update();
                    break;
                }
            }
            return sUserID;
        }
        #endregion

        //Force Shutdown
        #region Is Force Shutdown
        public static bool IsForceShutDown()
        {
            bool isForceToShutDown = false;
            List<tbl_utlUserPool> details = tbl_utlUserPool.SelectAllByUser_ID(clsSecurity.UserIDLoged);
            foreach (tbl_utlUserPool detail in details)
            {
                if (detail.IsForceShoutdown)
                {
                    isForceToShutDown = detail.IsForceShoutdown;
                    break;
                }
            }
            return isForceToShutDown;
        }
        #endregion

    }
}
