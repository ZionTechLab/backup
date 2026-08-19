using DataTire;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using SEACC_WPFControls;

namespace Digiteq_Logic
{
    public static class clsAlerts_Email
    {
        #region Register Alerts
        #region Invoice
        public static bool createEmail_Invoice(string sInvoiceID, enum_Alerts alertType)
        {
            bool bEmailStatus = false;
            try
            {
            string sAlertID = clsAutocode.getAlertID(alertType);

            tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
            if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
            {
                tbl_sasInvoice detail = tbl_sasInvoice.Select(sInvoiceID);
                if (detail != null && detail.Invoice_ID != "default")
                {
                    List<emailLine> lstEData = new List<emailLine>();
                    EmailLineformating oEmailLineFormat = new EmailLineformating();

                    string sBodyHTML = "";
                    #region Create/Format Email Body

                    #region Data
                    string sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                    string sCreateUserName = clsGenaralName.getName_User(detail.CreateUser_ID);
                    string sUserApproved = clsGenaralName.getName_User(detail.ApprovedUser_ID);
                    string sApprovedDate = clsFormatter.FormatDate_Short(detail.DateApproved) + " , " + clsFormatter.FormatTime_Short(detail.DateApproved);
                    string sUserChecked = clsGenaralName.getName_User(detail.CheckedUser_ID);
                    string sCheckedDate = clsFormatter.FormatDate_Short(detail.DateChecked) + " , " + clsFormatter.FormatTime_Short(detail.DateChecked);
                    string sCreateTime = clsFormatter.FormatDate_Short(detail.DateCreate) + " , " + clsFormatter.FormatTime_Short(detail.DateCreate);
                    string sPrintedUserName = clsGenaralName.getName_User(detail.PrintedUser_ID);
                    string sPrintTime = clsFormatter.FormatDate_Short(detail.DatePrinted) + " , " + clsFormatter.FormatTime_Short(detail.DatePrinted);
                    string sCanselUserName = clsGenaralName.getName_User(detail.DeletedUser_ID);
                    string sCancelDateTime = clsFormatter.FormatDate_Short(detail.DateDeleted) + " , " + clsFormatter.FormatTime_Short(detail.DateDeleted);
                    string sInvoiceDate = clsFormatter.FormatDate_Short(detail.InvoiceDate);
                    string sCurrencyCode = clsGenaralName.getName_CurrencyCode(detail.Currency_ID);
                    string sInvoiceTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate)) + " " + " " + "";
                    string sVatTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.CurrencyRate)) + " " + " " + "";
                    string sNbtTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate)) + " " + " " + "";
                    string sSVATTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate)) + " " + " " + "";
                    string sDiscountTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate)) + " " + " " + "";
                    string sSubTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.CurrencyRate)) + " " + " " + "";
                    string Header2 = (alertType == enum_Alerts.InvoiceCreated) ? "Invoice Created" : "Invoice Cancelled";
                    if (alertType == enum_Alerts.InvoicePrinted)
                    { Header2 = "Invoice Printed"; }
                    string sSubject = "SEACC E-Mail Alert : " + Header2 + " : " + sInvoiceID + " : " + sCustomerName;
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());

                    #region Detail
                    DataTable tblEmailDetail = new DataTable();
                    List<emailLine> lstEmailDetail = new List<emailLine>();

                    lstEmailDetail.Add(new emailLine(LineType.TableColomn1, "Qty"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Unit Price"));

                    tblEmailDetail.Columns.Add("Item Code");
                    tblEmailDetail.Columns.Add("Item Name");
                    tblEmailDetail.Columns.Add("Qty");
                    tblEmailDetail.Columns.Add("Unit Price");

                    foreach (tbl_sasInvoice_Detail oItems in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(detail.Invoice_ID))
                    {
                        string sItemCode = oItems.Item_ID;
                        string sItemName = clsGenaralName.getName_Item(oItems.Item_ID);
                        string sQty = detail.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(oItems.Weight) : clsFormatter.FormatDecimalPlaces_Quantity(oItems.Qty);
                        string sUnitPrice = detail.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_WeightPrice(clsHelpMethods.getDisplayPrice(oItems.WeightPrice, detail.CurrencyRate)) : clsFormatter.FormatDecimalPlaces_UnitPrice(clsHelpMethods.getDisplayPrice(oItems.UnitPrice, detail.CurrencyRate));
                        tblEmailDetail.Rows.Add(sItemCode, sItemName, sQty, sUnitPrice);
                    }
                    #endregion
                    #endregion

                    lstEData.Add(new emailLine(LineType.H1, clsSecurity.CompanyName));
                    lstEData.Add(new emailLine(LineType.H2, Header2));
                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Detail2, "Customer Name", sCustomerName));
                    lstEData.Add(new emailLine(LineType.Detail2, "Invoice No", sInvoiceID));
                    lstEData.Add(new emailLine(LineType.Detail2, "Invoice Date", sInvoiceDate));
                    lstEData.Add(new emailLine(LineType.DataTable, tblEmailDetail, lstEmailDetail));
                    lstEData.Add(new emailLine(LineType.Detail2, "Currency", sCurrencyCode));
                    lstEData.Add(new emailLine(LineType.Detail2, "Sub Total", sSubTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "Discount Total", sDiscountTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "NBT Total", sNbtTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "VAT Total", sVatTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "SVAT Total", sSVATTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "Grand Total", sInvoiceTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "Remarks", detail.Remark));
                    lstEData.Add(new emailLine(LineType.Space));
                    //lstEData.Add(new emailLine(LineType.Detail2, "Create Date & Time", sCreateTime));
                    //lstEData.Add(new emailLine(LineType.Detail2, "Create By", sCreateUserName));
                    lstEData.Add(new emailLine(LineType.Detail2, "Created", sCreateTime + " | " + sCreateUserName));
                    if (alertType == enum_Alerts.InvoiceCanceled)
                    {
                        // lstEData.Add(new emailLine(LineType.Detail2, "Cancel Date & Time", sCancelDateTime));
                        //  lstEData.Add(new emailLine(LineType.Detail2, "Cancel By", sCanselUserName));
                        lstEData.Add(new emailLine(LineType.Detail2, "Canceled", (sCancelDateTime = detail.IsDeleted ? sCancelDateTime : "-") + " | " + (sCanselUserName = detail.IsDeleted ? sCanselUserName : "-")));
                    }
                    if (alertType == enum_Alerts.InvoicePrinted)
                    {
                        // lstEData.Add(new emailLine(LineType.Detail2, "Printed Date & Time", sPrintTime));
                        // lstEData.Add(new emailLine(LineType.Detail2, "Printed By", sPrintedUserName));
                        lstEData.Add(new emailLine(LineType.Detail2, "Printed", (sPrintTime = detail.PrintCount > 0 ? sPrintTime : "_") + " | " + (sPrintedUserName = detail.PrintCount > 0 ? sPrintedUserName : "_")));
                    }


                    lstEData.Add(new emailLine(LineType.Detail2, "Checked ", (sCheckedDate = detail.IsChecked ? sCheckedDate : "-") + " | " + (sUserChecked = detail.IsChecked ? sUserChecked : "-")));
                    lstEData.Add(new emailLine(LineType.Detail2, "Approved ", (sApprovedDate = detail.IsApproved ? sApprovedDate : "-") + " | " + (sUserApproved = detail.IsApproved ? sUserApproved : "-")));

                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Footer1, "Email Ref No : " + sEmail_ID));

                    sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    clsValidate.WriteErrorLog(sAlertID + " - " + alertType.ToString() + (bEmailStatus ? " Generated Succesfully " : "Generation Failed"), -1,null);
                    #endregion
                }
            }
            else
                bEmailStatus = true;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCExeption.Show(ex);
            }

            return bEmailStatus;
        }

        public static bool createEmail_Warning_Alert_Exceeded_Credit_Days(string sInvoiceID, int iCreaditPeriod, enum_Alerts alertType)
        {
            bool bEmailStatus = false;
            try
            {
            string sAlertID = clsAutocode.getAlertID(alertType);

            tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
            if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
            {
                tbl_sasInvoice detail = tbl_sasInvoice.Select(sInvoiceID);
                if (detail != null && detail.Invoice_ID != "default")
                {
                    List<emailLine> lstEData = new List<emailLine>();

                    string sBodyHTML = "";
                    #region Create/Format Email Body

                    #region Data
                    string sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                    string sCreateUserName = clsGenaralName.getName_User(detail.CreateUser_ID);
                    string sUserApproved = clsGenaralName.getName_User(detail.ApprovedUser_ID);
                    string sApprovedDate = clsFormatter.FormatDate_Short(detail.DateApproved) + " , " + clsFormatter.FormatTime_Short(detail.DateApproved);
                    string sUserChecked = clsGenaralName.getName_User(detail.CheckedUser_ID);
                    string sCheckedDate = clsFormatter.FormatDate_Short(detail.DateChecked) + " , " + clsFormatter.FormatTime_Short(detail.DateChecked);
                    string sCreateTime = clsFormatter.FormatDate_Short(detail.DateCreate) + " , " + clsFormatter.FormatTime_Short(detail.DateCreate);
                    string sPrintedUserName = clsGenaralName.getName_User(detail.PrintedUser_ID);
                    string sPrintTime = clsFormatter.FormatDate_Short(detail.DatePrinted) + " , " + clsFormatter.FormatTime_Short(detail.DatePrinted);
                    string sCanselUserName = clsGenaralName.getName_User(detail.DeletedUser_ID);
                    string sCancelDateTime = clsFormatter.FormatDate_Short(detail.DateDeleted) + " , " + clsFormatter.FormatTime_Short(detail.DateDeleted);
                    string sInvoiceDate = clsFormatter.FormatDate_Short(detail.InvoiceDate);
                    string sCurrencyCode = clsGenaralName.getName_CurrencyCode(detail.Currency_ID);
                    string sInvoiceTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate)) + " " + " " + "";
                    string sVatTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.CurrencyRate)) + " " + " " + "";
                    string sNbtTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate)) + " " + " " + "";
                    string sSVATTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate)) + " " + " " + "";
                    string sDiscountTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate)) + " " + " " + "";
                    string sSubTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.CurrencyRate)) + " " + " " + "";

                    string Header2 = iCreaditPeriod.ToString() + " days credit period exerted Invoice Created";
                    string sSubject = "SEACC E-Mail Alert : " + Header2 + " : " + sInvoiceID + " : " + sCustomerName;
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());

                    #region Detail
                    DataTable tblEmailDetail = new DataTable();
                    List<emailLine> lstEmailDetail = new List<emailLine>();

                    lstEmailDetail.Add(new emailLine(LineType.TableColomn1, "Qty"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Unit Price"));

                    tblEmailDetail.Columns.Add("Item Code");
                    tblEmailDetail.Columns.Add("Item Name");
                    tblEmailDetail.Columns.Add("Qty");
                    tblEmailDetail.Columns.Add("Unit Price");

                    foreach (tbl_sasInvoice_Detail oItems in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(detail.Invoice_ID))
                    {
                        string sItemCode = oItems.Item_ID;
                        string sItemName = clsGenaralName.getName_Item(oItems.Item_ID);
                        string sQty = detail.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(oItems.Weight) : clsFormatter.FormatDecimalPlaces_Quantity(oItems.Qty);
                        string sUnitPrice = detail.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_WeightPrice(clsHelpMethods.getDisplayPrice(oItems.WeightPrice, detail.CurrencyRate)) : clsFormatter.FormatDecimalPlaces_UnitPrice(clsHelpMethods.getDisplayPrice(oItems.UnitPrice, detail.CurrencyRate));
                        tblEmailDetail.Rows.Add(sItemCode, sItemName, sQty, sUnitPrice);
                    }
                    #endregion
                    #endregion

                    lstEData.Add(new emailLine(LineType.H1, clsSecurity.CompanyName));
                    lstEData.Add(new emailLine(LineType.H2, Header2));
                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Detail2, "Customer Name", sCustomerName));
                    lstEData.Add(new emailLine(LineType.Detail2, "Invoice No", sInvoiceID));
                    lstEData.Add(new emailLine(LineType.Detail2, "Invoice Date", sInvoiceDate));
                    lstEData.Add(new emailLine(LineType.DataTable, tblEmailDetail, lstEmailDetail));
                    lstEData.Add(new emailLine(LineType.Detail2, "Currency", sCurrencyCode));
                    lstEData.Add(new emailLine(LineType.Detail2, "Sub Total", sSubTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "Discount Total", sDiscountTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "NBT Total", sNbtTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "VAT Total", sVatTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "SVAT Total", sSVATTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "Grand Total", sInvoiceTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "Remarks", detail.Remark));
                    lstEData.Add(new emailLine(LineType.Space));

                    lstEData.Add(new emailLine(LineType.Detail2, "Created", sCreateTime + " | " + sCreateUserName));

                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Footer1, "Email Ref No : " + sEmail_ID));

                    sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    clsValidate.WriteErrorLog(sAlertID + " - " + alertType.ToString() + (bEmailStatus ? " Generated Succesfully " : "Generation Failed"), -1,null);
                    #endregion
                }
            }
            else
                bEmailStatus = true;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCExeption.Show(ex);
            }
            return bEmailStatus;
        }
        #endregion

        #region Delivery Order
        public static void Email_DO(string sDoID, enum_Alerts alertType)
        {
            try
            {
            bool bEmailStatus = false;
            string sAlertID = clsAutocode.getAlertID(alertType);

            tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
            if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
            {
                tbl_sasDeliveryOrder detail = tbl_sasDeliveryOrder.Select(sDoID);
                if (detail != null && detail.DeliveryOrder_ID != "default")
                {
                    string sBodyHTML, sSubject = "", sCurrencyCode, sCustomerName, sCreateUserName, sCreateTime, sDODate = "", sCanselUserName, sCancelDateTime, sNoOfItem, sLifoCost = "", sWAVG = "", sHPP = "", sUserChecked = "", sUserApproved = "", sPrintedby = "", sPrintedDate = "", sCheckedDate = "", sApprovedDate = "", sRemark = "";// sDOTotal = "0.00", sVatTotal = "0.00", sNbtTotal = "0.00", sSVATTotal = "0.00", sDiscountTotal = "0.00", sSubTotal = "0.00",sNoOfQty,
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();

                    string sCompanyName = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string sEmailHeading = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());

                    #region Create/Format Email Body
                    sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                    sCreateUserName = clsGenaralName.getName_User(detail.CreateUser_ID);
                    sUserChecked = clsGenaralName.getName_User(detail.CheckedUser_ID);
                    sCheckedDate = clsFormatter.FormatDate_Short(detail.DateChecked) + " , " + clsFormatter.FormatTime_Short(detail.DateChecked);
                    sPrintedby = clsGenaralName.getName_User(detail.PrintedUser_ID);
                    sPrintedDate = clsFormatter.FormatDate_Short(detail.DatePrinted) + " , " + clsFormatter.FormatTime_Short(detail.DatePrinted);
                    sUserApproved = clsGenaralName.getName_User(detail.ApprovedUser_ID);
                    sApprovedDate = clsFormatter.FormatDate_Short(detail.DateApproved) + " , " + clsFormatter.FormatTime_Short(detail.DateApproved);
                    sCreateTime = clsFormatter.FormatDate_Short(detail.DateCreate) + " , " + clsFormatter.FormatTime_Short(detail.DateCreate);
                    sCanselUserName = clsGenaralName.getName_User(detail.DeletedUser_ID);
                    sCancelDateTime = clsFormatter.FormatDate_Short(detail.DateDeleted) + " , " + clsFormatter.FormatTime_Short(detail.DateDeleted);
                    sDODate = clsFormatter.FormatDate_Short(detail.DeliveryOrderDate);
                    sCurrencyCode = clsGenaralName.getName_CurrencyCode(detail.Currency_ID);
                    sRemark = detail.Remark != "" ? detail.Remark : "-";

                    //sDOTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate)) + " " + "";
                    //sVatTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.CurrencyRate)) + " " + "";
                    //sNbtTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate)) + " " + "";
                    //sSVATTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate)) + " " + "";
                    //sDiscountTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate)) + " " + "";
                    //sSubTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.CurrencyRate)) + " " + "";

                    #region Detail
                    DataTable tblEmailDetail = new DataTable();

                    tblEmailDetail.Columns.Add("Item Code");
                    tblEmailDetail.Columns.Add("Item Name");
                    tblEmailDetail.Columns.Add("Qty");
                    tblEmailDetail.Columns.Add("Unit Price");
                    tblEmailDetail.Columns.Add("LIFO Cost");
                    tblEmailDetail.Columns.Add("Weighted Avg Cost");
                    tblEmailDetail.Columns.Add("HPP Cost");

                    string sItemCode = "", sItemName = "", sQty = "", sUnitPrice = "";
                    int iNoOfItem = 0;

                    foreach (tbl_sasDeliveryOrder_Detail oItems in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(detail.DeliveryOrder_ID))
                    {
                        sItemCode = oItems.Item_ID;
                        sItemName = clsGenaralName.getName_Item(oItems.Item_ID);
                        sQty = detail.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Price(oItems.Weight) : clsFormatter.FormatDecimalPlaces_Price(oItems.Qty);
                        sUnitPrice = detail.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(oItems.WeightPrice, detail.CurrencyRate)) : clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(oItems.UnitPrice, detail.CurrencyRate));
                        sLifoCost = clsFormatter.FormatDecimalPlaces_Price(clsProcessMethods.GetCostPrice_ByCostType(oItems.Item_ID, oItems.ItemSubCategory_ID, oItems.ItemSubCategory2_ID, oItems.ItemSerialNo, oItems.ItemSerialNo2, enum_CostPriceType.LIFO)).ToString();
                        sWAVG = clsFormatter.FormatDecimalPlaces_Price(clsProcessMethods.GetCostPrice_ByCostType(oItems.Item_ID, oItems.ItemSubCategory_ID, oItems.ItemSubCategory2_ID, oItems.ItemSerialNo, oItems.ItemSerialNo2, enum_CostPriceType.WeightedAverage)).ToString();
                        sHPP = clsFormatter.FormatDecimalPlaces_Price(clsProcessMethods.GetCostPrice_ByCostType(oItems.Item_ID, oItems.ItemSubCategory_ID, oItems.ItemSubCategory2_ID, oItems.ItemSerialNo, oItems.ItemSerialNo2, enum_CostPriceType.HighestPurchaseCost)).ToString();
                        tblEmailDetail.Rows.Add(sItemCode, sItemName, sQty, sUnitPrice, sLifoCost, sWAVG, sHPP);
                        iNoOfItem++;
                    }
                    sNoOfItem = iNoOfItem.ToString();

                    List<emailLine> lstEmailDetail = new List<emailLine>();

                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Item Code"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Item Name"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Qty"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Unit Price"));
                    #endregion

                    if (alertType == enum_Alerts.DeliveryOrderCreate)
                    {
                        sEmailHeading = "Delivery Order Created";
                        sSubject = "SEACC E-Mail Alert : Delivery Order Created : " + sDoID + " : " + sCustomerName; //todo
                    }
                    else if (alertType == enum_Alerts.DeliveryOrderCancel)
                    {
                        sEmailHeading = "Delivery Order Cancelled";
                        sSubject = "SEACC E-Mail Alert : Delivery Order Cancelled : " + sDoID + " : " + sCustomerName; //todo
                    }
                    else if (alertType == enum_Alerts.DeliveryOrderPrinted)
                    {
                        sEmailHeading = "Delivery Order Printed";
                        sSubject = "SEACC E-Mail Alert : Delivery Order  Printed : " + sDoID + " : " + sCustomerName; //todo
                    }

                    List<emailLine> lstEData = new List<emailLine>();
                    EmailLineformating oEmailLineFormat = new EmailLineformating();

                    lstEData.Add(new emailLine(LineType.H1, clsSecurity.CompanyName));
                    lstEData.Add(new emailLine(LineType.H2, sEmailHeading));
                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Detail2, "Customer Name", sCustomerName));
                    lstEData.Add(new emailLine(LineType.Detail2, "Delivery Order No", sDoID));
                    lstEData.Add(new emailLine(LineType.Detail2, "Delivery Order Date", sDODate));
                    lstEData.Add(new emailLine(LineType.Detail2, "Remark", sRemark));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.DataTable, tblEmailDetail, lstEmailDetail));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "No of Item", sNoOfItem));
                    // lstEData.Add(new emailLine(LineType.Detail2, "No of QTY", sNoOfQty));

                    //lstEData.Add(new emailLine(LineType.Detail2, "VAT Total", sCurrencyCode));
                    //lstEData.Add(new emailLine(LineType.Detail2, "SVAT Total", sSubTotal));
                    //lstEData.Add(new emailLine(LineType.Detail2, "Discount Total", sDiscountTotal));
                    //lstEData.Add(new emailLine(LineType.Detail2, "NBT VAT Total", sNbtTotal));
                    // lstEData.Add(new emailLine(LineType.Detail2, "VAT Total", sVatTotal));
                    // lstEData.Add(new emailLine(LineType.Detail2, "Grand Total", sDOTotal));

                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Created", sCreateTime + " | " + sCreateUserName));

                    if (alertType == enum_Alerts.DeliveryOrderCancel)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Canceled", (sCancelDateTime = detail.IsDeleted ? sCancelDateTime : "-") + " | " + (sCanselUserName = detail.IsDeleted ? sCanselUserName : "-")));
                    }

                    if (alertType == enum_Alerts.DeliveryOrderPrinted)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Printed", (sPrintedDate = detail.PrintCount > 0 ? sPrintedDate : "_") + " | " + (sPrintedby = detail.PrintCount > 0 ? sPrintedby : "_")));
                    }

                    lstEData.Add(new emailLine(LineType.Detail2, "Checked ", (sCheckedDate = detail.IsChecked ? sCheckedDate : "-") + " | " + (sUserChecked = detail.IsChecked ? sUserChecked : "-")));
                    lstEData.Add(new emailLine(LineType.Detail2, "Approved ", (sApprovedDate = detail.IsApproved ? sApprovedDate : "-") + " | " + (sUserApproved = detail.IsApproved ? sUserApproved : "-")));


                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Footer1, "Email Ref No : " + sEmail_ID));


                    sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    clsValidate.WriteErrorLog(sAlertID + " - " + alertType.ToString() + (bEmailStatus ? " Generated Succesfully " : "Generation Failed"), -1,null);
                    #endregion
                }
                }

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Customer Order
        public static void Email_CO(string sCoID, enum_Alerts alertType)
        {
            try
            {
            bool bEmailStatus = false;
            string sAlertID = clsAutocode.getAlertID(alertType);

            tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
            if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
            {
                tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(sCoID);
                if (detail != null && detail.CustomerOrder_ID != "default")
                {
                    string sBodyHTML, sSubject = "", sCurrencyCode, sCustomerName, sCreateUserName, sCreateTime, sCODate = "", sCanselUserName, sCancelDateTime, sNoOfItem, sFree = "", sDisPercentage = "", sDisAmount = "", sAmount = "", sUserChecked = "", sUserApproved = "", sPrintedby = "", sPrintedDate = "", sCheckedDate = "", sApprovedDate = "", sRemark = "";

                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();

                    string sCompanyName = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string sEmailHeading = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());

                    #region Create/Format Email Body
                    sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                    sCreateUserName = clsGenaralName.getName_User(detail.CreateUser_ID);
                    sUserChecked = clsGenaralName.getName_User(detail.CheckedUser_ID);
                    sCheckedDate = clsFormatter.FormatDate_Short(detail.DateChecked) + " , " + clsFormatter.FormatTime_Short(detail.DateChecked);
                    sPrintedby = clsGenaralName.getName_User(detail.PrintedUser_ID);
                    sPrintedDate = clsFormatter.FormatDate_Short(detail.DatePrinted) + " , " + clsFormatter.FormatTime_Short(detail.DatePrinted);
                    sUserApproved = clsGenaralName.getName_User(detail.ApprovedUser_ID);
                    sApprovedDate = clsFormatter.FormatDate_Short(detail.DateApproved) + " , " + clsFormatter.FormatTime_Short(detail.DateApproved);
                    sCreateTime = clsFormatter.FormatDate_Short(detail.DateCreate) + " , " + clsFormatter.FormatTime_Short(detail.DateCreate);
                    sCanselUserName = clsGenaralName.getName_User(detail.DeletedUser_ID);
                    sCancelDateTime = clsFormatter.FormatDate_Short(detail.DateDeleted) + " , " + clsFormatter.FormatTime_Short(detail.DateDeleted);
                    sCODate = clsFormatter.FormatDate_Short(detail.CustomerOrderDate);
                    sCurrencyCode = clsGenaralName.getName_CurrencyCode(detail.Currency_ID);
                    sRemark = detail.Remark != "" ? detail.Remark : "-";

                    #region Detail
                    DataTable tblEmailDetail = new DataTable();

                    tblEmailDetail.Columns.Add("Item Code");
                    tblEmailDetail.Columns.Add("Item Name");
                    tblEmailDetail.Columns.Add("Qty");
                    tblEmailDetail.Columns.Add("Unit Price", typeof(decimal));
                    tblEmailDetail.Columns.Add("Free");
                    tblEmailDetail.Columns.Add("Discounted %");
                    tblEmailDetail.Columns.Add("Discounted Amount");
                    tblEmailDetail.Columns.Add("Amount");
                    //tblEmailDetail.Columns.Add("Discounted %", typeof(decimal));
                    //tblEmailDetail.Columns.Add("Discounted Amount", typeof(decimal));
                    //tblEmailDetail.Columns.Add("Amount", typeof(decimal));

                    string sItemCode = "", sItemName = "", sQty = "", sUnitPrice = "";
                    int iNoOfItem = 0;

                    foreach (tbl_sasCustomerOrder_Detail oItems in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(detail.CustomerOrder_ID))
                    {
                        sItemCode = oItems.Item_ID;
                        sItemName = clsGenaralName.getName_Item(oItems.Item_ID);
                        sQty = detail.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Price(oItems.Weight) : clsFormatter.FormatDecimalPlaces_Price(oItems.Qty);
                        sUnitPrice = detail.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(oItems.WeightPrice, detail.CurrencyRate)) : clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(oItems.UnitPrice, detail.CurrencyRate));
                        sFree = oItems.BIsFreeItem ? "Yes" : "-";
                        sDisPercentage = oItems.BIsFreeItem ? "-" : clsFormatter.FormatDecimalPlaces_Price(oItems.DiscountPresentage).ToString();
                        sDisAmount = oItems.BIsFreeItem ? "-" : clsFormatter.FormatDecimalPlaces_Price(oItems.DiscountAmount).ToString();
                        sAmount = oItems.BIsFreeItem ? "-" : clsFormatter.FormatDecimalPlaces_Price(oItems.TatalAmount).ToString();
                        tblEmailDetail.Rows.Add(sItemCode, sItemName, sQty, sUnitPrice, sFree, sDisPercentage, sDisAmount, oItems.TatalAmount);

                        iNoOfItem++;
                    }
                    sNoOfItem = iNoOfItem.ToString();

                    List<emailLine> lstEmailDetail = new List<emailLine>();

                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Item Code"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Item Name"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Qty"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Unit Price"));
                    #endregion

                    if (alertType == enum_Alerts.CustomerOrderCreate)
                    {
                        sEmailHeading = "Customer Order Created";
                        sSubject = "SEACC E-Mail Alert : Customer Order Created : " + sCoID + " : " + sCustomerName; //todo
                    }
                    else if (alertType == enum_Alerts.CustomerOrderCancel)
                    {
                        sEmailHeading = "Customer Order Cancelled";
                        sSubject = "SEACC E-Mail Alert : Customer Order Cancelled : " + sCoID + " : " + sCustomerName; //todo
                    }
                    else if (alertType == enum_Alerts.CustomerOrderPrinted)
                    {
                        sEmailHeading = "Customer Order Printed";
                        sSubject = "SEACC E-Mail Alert : Customer Order  Printed : " + sCoID + " : " + sCustomerName; //todo
                    }

                    List<emailLine> lstEData = new List<emailLine>();
                    EmailLineformating oEmailLineFormat = new EmailLineformating();

                    lstEData.Add(new emailLine(LineType.H1, clsSecurity.CompanyName));
                    lstEData.Add(new emailLine(LineType.H2, sEmailHeading));
                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Detail2, "Customer Name", sCustomerName));
                    lstEData.Add(new emailLine(LineType.Detail2, "Customer Order No", sCoID));
                    lstEData.Add(new emailLine(LineType.Detail2, "Customer Order Date", sCODate));
                    lstEData.Add(new emailLine(LineType.Detail2, "Remark", sRemark));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.DataTable, tblEmailDetail, lstEmailDetail));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "No of Item", sNoOfItem));

                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Created", sCreateTime + " | " + sCreateUserName));

                    if (alertType == enum_Alerts.CustomerOrderCancel)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Canceled", (sCancelDateTime = detail.IsDeleted ? sCancelDateTime : "-") + " | " + (sCanselUserName = detail.IsDeleted ? sCanselUserName : "-")));
                    }

                    if (alertType == enum_Alerts.CustomerOrderPrinted)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Printed", (sPrintedDate = detail.PrintCount > 0 ? sPrintedDate : "_") + " | " + (sPrintedby = detail.PrintCount > 0 ? sPrintedby : "_")));
                    }

                    lstEData.Add(new emailLine(LineType.Detail2, "Checked ", (sCheckedDate = detail.IsChecked ? sCheckedDate : "-") + " | " + (sUserChecked = detail.IsChecked ? sUserChecked : "-")));
                    lstEData.Add(new emailLine(LineType.Detail2, "Approved ", (sApprovedDate = detail.IsApproved ? sApprovedDate : "-") + " | " + (sUserApproved = detail.IsApproved ? sUserApproved : "-")));


                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Footer1, "Email Ref No : " + sEmail_ID));


                    sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    clsValidate.WriteErrorLog(sAlertID + " - " + alertType.ToString() + (bEmailStatus ? " Generated Succesfully " : "Generation Failed"), -1,null);
                    #endregion
                }
            }
        }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Discounted Item
        public static void Email_CO_DiscountedItem(string sCoID, enum_Alerts alertType)
        {
            try
            {
            bool bEmailStatus = false;
            string sAlertID = clsAutocode.getAlertID(alertType);

            tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
            if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
            {
                tbl_sasCustomerOrder detail = tbl_sasCustomerOrder.Select(sCoID);
                if (detail != null && detail.CustomerOrder_ID != "default")
                {
                    string sBodyHTML, sSubject = "", sCurrencyCode, sCustomerName, sCreateUserName, sCreateTime, sCODate = "", sCanselUserName, sCancelDateTime, sNoOfItem, sDisPercentage = "", sDisAmount = "", sAmount = "", sUserChecked = "", sUserApproved = "", sPrintedby = "", sPrintedDate = "", sCheckedDate = "", sApprovedDate = "", sRemark = "";

                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();

                    string sCompanyName = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string sEmailHeading = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());

                    #region Create/Format Email Body
                    sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                    sCreateUserName = clsGenaralName.getName_User(detail.CreateUser_ID);
                    sUserChecked = clsGenaralName.getName_User(detail.CheckedUser_ID);
                    sCheckedDate = clsFormatter.FormatDate_Short(detail.DateChecked) + " , " + clsFormatter.FormatTime_Short(detail.DateChecked);
                    sPrintedby = clsGenaralName.getName_User(detail.PrintedUser_ID);
                    sPrintedDate = clsFormatter.FormatDate_Short(detail.DatePrinted) + " , " + clsFormatter.FormatTime_Short(detail.DatePrinted);
                    sUserApproved = clsGenaralName.getName_User(detail.ApprovedUser_ID);
                    sApprovedDate = clsFormatter.FormatDate_Short(detail.DateApproved) + " , " + clsFormatter.FormatTime_Short(detail.DateApproved);
                    sCreateTime = clsFormatter.FormatDate_Short(detail.DateCreate) + " , " + clsFormatter.FormatTime_Short(detail.DateCreate);
                    sCanselUserName = clsGenaralName.getName_User(detail.DeletedUser_ID);
                    sCancelDateTime = clsFormatter.FormatDate_Short(detail.DateDeleted) + " , " + clsFormatter.FormatTime_Short(detail.DateDeleted);
                    sCODate = clsFormatter.FormatDate_Short(detail.CustomerOrderDate);
                    sCurrencyCode = clsGenaralName.getName_CurrencyCode(detail.Currency_ID);
                    sRemark = detail.Remark != "" ? detail.Remark : "-";

                    #region Detail
                    DataTable tblEmailDetail = new DataTable();

                    tblEmailDetail.Columns.Add("Item Code");
                    tblEmailDetail.Columns.Add("Item Name");
                    tblEmailDetail.Columns.Add("Qty");
                    tblEmailDetail.Columns.Add("Unit Price", typeof(decimal));
                    tblEmailDetail.Columns.Add("Discounted %", typeof(decimal));
                    tblEmailDetail.Columns.Add("Discounted Amount", typeof(decimal));
                    tblEmailDetail.Columns.Add("Amount", typeof(decimal));

                    string sItemCode = "", sItemName = "", sQty = "", sUnitPrice = "";
                    int iNoOfItem = 0;

                    foreach (tbl_sasCustomerOrder_Detail oItems in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(detail.CustomerOrder_ID).Where(i => i.DiscountPresentage > 0 && !i.BIsFreeItem))
                    {
                        sItemCode = oItems.Item_ID;
                        sItemName = clsGenaralName.getName_Item(oItems.Item_ID);
                        sQty = detail.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Price(oItems.Weight) : clsFormatter.FormatDecimalPlaces_Price(oItems.Qty);
                        sUnitPrice = detail.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(oItems.WeightPrice, detail.CurrencyRate)) : clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(oItems.UnitPrice, detail.CurrencyRate));
                        sDisPercentage = oItems.BIsFreeItem ? "-" : clsFormatter.FormatDecimalPlaces_Price(oItems.DiscountPresentage).ToString();
                        sDisAmount = oItems.BIsFreeItem ? "-" : clsFormatter.FormatDecimalPlaces_Price(oItems.DiscountAmount).ToString();
                        sAmount = oItems.BIsFreeItem ? "-" : clsFormatter.FormatDecimalPlaces_Price(oItems.TatalAmount).ToString();
                        tblEmailDetail.Rows.Add(sItemCode, sItemName, sQty, sUnitPrice, sDisPercentage, sDisAmount, oItems.TatalAmount);
                        iNoOfItem++;
                    }
                    sNoOfItem = iNoOfItem.ToString();

                    List<emailLine> lstEmailDetail = new List<emailLine>();

                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Item Code"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Item Name"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Qty"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Unit Price"));
                    #endregion

                    if (alertType == enum_Alerts.CustomerOrderDiscountedItemCreate)
                    {
                        sEmailHeading = "Customer Order Created (with Discounted Items)";
                        sSubject = "SEACC E-Mail Alert : Customer Order Created : " + sCoID + " : " + sCustomerName; //todo
                    }
                    else if (alertType == enum_Alerts.CustomerOrderDiscountedItemCancel)
                    {
                        sEmailHeading = "Customer Order Cancelled";
                        sSubject = "SEACC E-Mail Alert : Customer Order Cancelled : " + sCoID + " : " + sCustomerName; //todo
                    }
                    else if (alertType == enum_Alerts.CustomerOrderDiscountedItemPrinted)
                    {
                        sEmailHeading = "Customer Order Printed";
                        sSubject = "SEACC E-Mail Alert : Customer Order  Printed : " + sCoID + " : " + sCustomerName; //todo
                    }

                    List<emailLine> lstEData = new List<emailLine>();
                    EmailLineformating oEmailLineFormat = new EmailLineformating();

                    lstEData.Add(new emailLine(LineType.H1, clsSecurity.CompanyName));
                    lstEData.Add(new emailLine(LineType.H2, sEmailHeading));
                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Detail2, "Customer Name", sCustomerName));
                    lstEData.Add(new emailLine(LineType.Detail2, "Customer Order No", sCoID));
                    lstEData.Add(new emailLine(LineType.Detail2, "Customer Order Date", sCODate));
                    lstEData.Add(new emailLine(LineType.Detail2, "Remark", sRemark));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.DataTable, tblEmailDetail, lstEmailDetail));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "No of Item", sNoOfItem));

                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Created", sCreateTime + " | " + sCreateUserName));

                    if (alertType == enum_Alerts.CustomerOrderCancel)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Canceled", (sCancelDateTime = detail.IsDeleted ? sCancelDateTime : "-") + " | " + (sCanselUserName = detail.IsDeleted ? sCanselUserName : "-")));
                    }

                    if (alertType == enum_Alerts.CustomerOrderPrinted)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Printed", (sPrintedDate = detail.PrintCount > 0 ? sPrintedDate : "_") + " | " + (sPrintedby = detail.PrintCount > 0 ? sPrintedby : "_")));
                    }

                    lstEData.Add(new emailLine(LineType.Detail2, "Checked ", (sCheckedDate = detail.IsChecked ? sCheckedDate : "-") + " | " + (sUserChecked = detail.IsChecked ? sUserChecked : "-")));
                    lstEData.Add(new emailLine(LineType.Detail2, "Approved ", (sApprovedDate = detail.IsApproved ? sApprovedDate : "-") + " | " + (sUserApproved = detail.IsApproved ? sUserApproved : "-")));


                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Footer1, "Email Ref No : " + sEmail_ID));


                    sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    clsValidate.WriteErrorLog(sAlertID + " - " + alertType.ToString() + (bEmailStatus ? " Generated Succesfully " : "Generation Failed"), -1,null);
                    #endregion
                }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Credit Note
        public static bool createEmail_CreditNote(string sCRNID, enum_Alerts alertType)
        {
            bool bEmailStatus = false;
            try
            {
            string sAlertID = clsAutocode.getAlertID(alertType);

            tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
            if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
            {
                string sCraditNoteNO, sCustomerName, sCreateUserName, sCreateTime, sTotalAmount = "0.00", sVatTotal = "0.00", sCRNDate = "", sNbtTotal = "0.00", sSVATTotal = "0.00", sDiscountTotal = "0.00", sSubTotal = "0.00", sCRNType, sRemarks, sCanselUserName, sCancelDateTime;
                List<string> sMaterials = new List<string>();
                ArrayList tolist = new ArrayList();
                ArrayList filelist = new ArrayList();
                string sBodyHTML, sSubject = "", sCurrencyCode;
                // Fill Data for Processing             
                tbl_bpsCreditNote detail = tbl_bpsCreditNote.Select(sCRNID);
                if (detail != null && detail.Invoice_ID != "default")
                {
                    #region Create/Format Email Body
                    sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                    sCreateUserName = clsGenaralName.getName_User(detail.CreateUser_ID);
                    sCanselUserName = clsGenaralName.getName_User(clsSecurity.UserIDLoged);
                    sCancelDateTime = clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + " , " + clsFormatter.FormatTime_Short(clsSecurity.getServerDateTime());
                    sCreateTime = clsFormatter.FormatDate_Short(detail.DateCreate) + " , " + clsFormatter.FormatTime_Short(detail.DateCreate);
                    sCRNDate = clsFormatter.FormatDate_Short(detail.CreditNoteDate);
                    sCRNType = clsGenaralName.getName_CreditNoteType(detail.CreditNoteType_ID);
                    sRemarks = detail.Remark == "" ? "-" : detail.Remark;
                    sCurrencyCode = clsGenaralName.getName_CurrencyCode(detail.Currency_ID);
                    sTotalAmount = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.TotalAmount, detail.CurrencyRate)) + " " + "";
                    sVatTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.CurrencyRate)) + " " + "";
                    sNbtTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate)) + " " + "";
                    sSVATTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate)) + " " + "";
                    sDiscountTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate)) + " " + "";
                    sSubTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.CurrencyRate)) + " " + "";
                    sCraditNoteNO = detail.CreditNote_ID;

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    if (alertType == enum_Alerts.CreditNoteCreated)
                    {
                        l1 = "Credit Note created ";
                        sSubject = "SEACC E-Mail Alert : Credit Note Created : " + sCRNID + " : " + sCustomerName; //todo
                    }
                    else if (alertType == enum_Alerts.CreditNoteCancel)
                    {
                        sSubject = "SEACC E-Mail Alert : Credit Note Cancelled : " + sCRNID + " : " + sCustomerName; //todo
                        l1 = "Credit Note Cancelled ";
                    }

                    List<emailLine> lstEData = new List<emailLine>();
                    EmailLineformating oEmailLineFormat = new EmailLineformating();

                    lstEData.Add(new emailLine(LineType.H1, clsSecurity.CompanyName));
                    lstEData.Add(new emailLine(LineType.H2, l1));
                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Detail2, "Customer Name", sCustomerName));
                    lstEData.Add(new emailLine(LineType.Detail2, "Credit Note No", sCraditNoteNO));
                    lstEData.Add(new emailLine(LineType.Detail2, "Credit Note Date", sCRNDate));
                    lstEData.Add(new emailLine(LineType.Detail2, "Credit Note Type", sCRNType));
                    lstEData.Add(new emailLine(LineType.Detail2, "Remark", sRemarks));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Currency Code ", sCurrencyCode));
                    lstEData.Add(new emailLine(LineType.Detail2, "Total Amount", sSubTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "Discount Total", sDiscountTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "NBT VAT Total", sNbtTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "VAT Total", sVatTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "VAT Total", sTotalAmount));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Create Date & Time", sCreateTime));
                    lstEData.Add(new emailLine(LineType.Detail2, "Create By", sCreateUserName));
                    if (alertType == enum_Alerts.CreditNoteCancel)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Cancel Date & Time", sCancelDateTime));
                        lstEData.Add(new emailLine(LineType.Detail2, "Cancel By", sCanselUserName));
                    }
                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Footer1, "Email Ref No : " + sEmail_ID));

                    sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);

                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    clsValidate.WriteErrorLog(sAlertID + " - " + alertType.ToString() + (bEmailStatus ? " Generated Succesfully " : "Generation Failed"), -1, null);
                    #endregion
                }
            }
            else
                bEmailStatus = true;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCExeption.Show(ex);
            }

            return bEmailStatus;
        }
        #endregion

        #region Debit Note
        public static bool createEmail_DebitNote(string sDBNID, enum_Alerts alertType)
        {
            bool bEmailStatus = false;
            try
            {
            string sAlertID = clsAutocode.getAlertID(alertType);

            tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
            if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
            {
                string sCustomerName, sCreateUserName, sCreateTime, sTotalAmount = "0.00", sVatTotal = "0.00", sDBNDate = "", sNbtTotal = "0.00", sSVATTotal = "0.00", sDiscountTotal = "0.00", sSubTotal = "0.00", sDBNType, sRemarks, sCanselUserName, sCancelDateTime;
                List<string> sMaterials = new List<string>();

                // E-mail Information
                ArrayList tolist = new ArrayList();
                ArrayList filelist = new ArrayList();
                string sBodyHTML, sSubject = "", sCurrencyCode;

                // Fill Data for Processing             
                tbl_bpsDebitNote detail = tbl_bpsDebitNote.Select(sDBNID);
                if (detail != null && detail.Invoice_ID != "default")
                {
                    sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                    sCreateUserName = clsGenaralName.getName_User(detail.CreateUser_ID);
                    sCanselUserName = clsGenaralName.getName_User(clsSecurity.UserIDLoged);
                    sCancelDateTime = clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + " , " + clsFormatter.FormatTime_Short(clsSecurity.getServerDateTime());
                    sCreateTime = clsFormatter.FormatDate_Short(detail.DateCreate) + " , " + clsFormatter.FormatTime_Short(detail.DateCreate);
                    sDBNDate = clsFormatter.FormatDate_Short(detail.DebitNoteDate);
                    //sDBNType = clsGenaralName.getName_CreditNoteType(detail.DebitNoteType_ID);
                    sDBNType = clsGenaralName.getName_DebitNoteType(detail.DebitNoteType_ID);
                    sRemarks = detail.Remark == "" ? "-" : detail.Remark;
                    sCurrencyCode = clsGenaralName.getName_CurrencyCode(detail.Currency_ID);
                    sTotalAmount = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.TotalAmount, detail.CurrencyRate)) + " " + sCurrencyCode;
                    sVatTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.CurrencyRate)) + " " + sCurrencyCode;
                    sNbtTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate)) + " " + sCurrencyCode;
                    sSVATTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate)) + " " + sCurrencyCode;
                    sDiscountTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate)) + " " + sCurrencyCode;
                    sSubTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.CurrencyRate)) + " " + sCurrencyCode;


                    #region OLD

                    /*     #region Hard Coded E-Mail Body
                    string nl = System.Environment.NewLine;

                    string l1 = "";
                    string lCby = "", lCdt = "";

                    if (altType == enum_Alerts.DebitNoteCreate)
                    {
                        l1 = "Debit Note created " + nl;
                        sSubject = "SEACC E-Mail Alert : Debit Note Created : " + sDBNID + " : " + sCustomerName; //todo
                    }
                    else if (altType == enum_Alerts.DebitNoteCancel)
                    {
                        sSubject = "SEACC E-Mail Alert : Debit Note Canceled : " + sDBNID + " : " + sCustomerName; //todo
                        l1 = "Debit Note Canceled " + nl;
                        lCdt = "Cancel Date & Time    : " + sCancelDateTime + nl;
                        lCby = "Cancel By             : " + sCanselUserName + nl + nl;
                    }

                    string l3 = "Debit Note No.    : " + sDBNID + nl;
                    string l4 = "Debit Note Date   : " + sDBNDate + nl;
                    string l2 = "Customer Name      : " + sCustomerName + nl;
                    string l21 = "Debit Note Type     : " + sDBNType + nl + nl;

                    string l22 = "Remarks                : " + sRemarks + nl + nl;
                    string l500 = "Sub Total        : " + sSubTotal + nl;

                    string l50 = "Discount Total    : " + sDiscountTotal + nl;
                    string l5 = "NBT Total          : " + sNbtTotal + nl;
                    string l6 = "VAT Total          : " + sVatTotal + nl;
                    string l61 = "SVAT Total        : " + sSVATTotal + nl;
                    string l7 = "Grand Total        : " + sTotalAmount + nl;

                    string l9 = "";
                    foreach (string material in sMaterials)
                    {
                        l9 = l9 + material + nl;
                    }

                    string l10 = "Create Date & Time : " + sCreateTime + nl;
                    string l11 = "Create By             : " + sCreateUserName + nl + nl;

                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    string l12 = "Email Ref No      : " + sEmail_ID;

                    sBody = l1 + nl + l2 + l21 + l22 + l3 + l4 + nl + l500 + l50 + l5 + l6 + l61 + l7 + nl + l9 + nl + l10 + l11 + lCdt + lCby + nl + l12;
                    #endregion

                       tbl_utlAlert_EMail oAlert_Email = new tbl_utlAlert_EMail(sEmail_ID, oAlert.Alert_ID, sSubject, sBody);
                    oAlert_Email.Insert();

                    foreach (tbl_utlAlertSettings oAlertSetting in tbl_utlAlertSettings.SelectAllByAlert_ID(oAlert.Alert_ID))
                    {
                        if (oAlertSetting.UserEmail1.Length > 0)
                            tolist.Add(oAlertSetting.UserEmail1);
                    }          
                     SendMail("admin", tolist, filelist, sSubject, sBody, false);*/

                    #endregion

                    #region new

                    string l1 = "", sCdt = "", sCby = "";
                    if (alertType == enum_Alerts.DebitNoteCreate)
                    {
                        l1 = "Debit Note created ";
                        sSubject = "SEACC E-Mail Alert : Debit Note Created : " + sDBNID + " : " + sCustomerName; //todo
                    }
                    else if (alertType == enum_Alerts.DebitNoteCancel)
                    {
                        sSubject = "SEACC E-Mail Alert : Debit Note Canceled : " + sDBNID + " : " + sCustomerName; //todo
                        l1 = "Debit Note Canceled ";
                        sCdt = "Cancel Date & Time    : " + sCancelDateTime;
                        sCby = "Cancel By             : " + sCanselUserName;
                    }

                    List<emailLine> lstEData = new List<emailLine>();
                    EmailLineformating oEmailLineFormat = new EmailLineformating();

                    lstEData.Add(new emailLine(LineType.H1, clsSecurity.CompanyName));
                    lstEData.Add(new emailLine(LineType.H2, l1));
                    lstEData.Add(new emailLine(LineType.Line1));

                    lstEData.Add(new emailLine(LineType.Detail2, "Customer Name", sCustomerName));
                    lstEData.Add(new emailLine(LineType.Detail2, "Debit Note Type", sDBNType));

                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Remark", sRemarks));

                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Debit Note No", sDBNID));
                    lstEData.Add(new emailLine(LineType.Detail2, "Debit Note Date", sDBNDate));

                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Sub Total", sSubTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "Discount Total", sDiscountTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "NBT Total", sNbtTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "VAT Total", sVatTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "SVAT Total", sSVATTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "Grand Total ", sTotalAmount));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Create Date & Time", sCreateTime));
                    lstEData.Add(new emailLine(LineType.Detail2, "Create By", sCreateUserName));
                    if (alertType == enum_Alerts.CreditNoteCancel)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Cancel Date & Time", sCancelDateTime));
                        lstEData.Add(new emailLine(LineType.Detail2, "Cancel By", sCanselUserName));
                    }
                    lstEData.Add(new emailLine(LineType.Line1));
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    lstEData.Add(new emailLine(LineType.Footer1, "Email Ref No : " + sEmail_ID));

                    sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    clsValidate.WriteErrorLog(sAlertID + " - " + alertType.ToString() + (bEmailStatus ? " Generated Succesfully " : "Generation Failed"), -1,null);

                    #endregion

                    #endregion
                }
            }
            else
                bEmailStatus = true;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCExeption.Show(ex);
            }

            return bEmailStatus;
        }
        #endregion

        #region Sales Return
        public static bool createEmail_SalesReturn(string sSRNID, enum_Alerts alertType)
        {
            bool bEmailStatus = false;
            try
            {
            string sAlertID = clsAutocode.getAlertID(alertType);

            tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
            if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
            {
                DataTable tblEmailDetail = new DataTable();
                string sCustomerName, sCreateUserName = "-", sCreateTime = "", sSRNTotal = "0.00", sVatTotal = "0.00", sSrnDate = "", sNbtTotal = "0.00", sSVATTotal = "0.00", sDiscountTotal = "0.00", sSubTotal = "0.00", sRemarks, sCancelUserName = "-", sCancelDateTime = "", sPrintedUserName = "-", sPrintedDate = "", sApprovedUserID = "-", sApprovedDate = "", sCheckedUserID = "-", sCheckedDate = "";
                List<string> sMaterials = new List<string>();
                ArrayList tolist = new ArrayList();
                ArrayList filelist = new ArrayList();
                string sBodyHTML, sSubject = "", sCurrencyCode;

                tbl_sasSalesReturnedNote detail = tbl_sasSalesReturnedNote.Select(sSRNID);
                if (detail != null && detail.SalesReturnedNote_ID != "default")
                {
                    #region Create/Format Email Body

                    #endregion
                    sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                    sCreateUserName = clsGenaralName.getName_User(detail.CreateUser_ID);
                    sCreateTime = clsFormatter.FormatDate_Short(detail.DateCreate) + " , " + clsFormatter.FormatTime_Short(detail.DateCreate);
                    sCancelUserName = clsGenaralName.getName_User(detail.DeletedUser_ID);
                    sCancelDateTime = clsFormatter.FormatDate_Short(detail.DateDeleted) + " , " + clsFormatter.FormatTime_Short(detail.DateDeleted);
                    sPrintedUserName = clsGenaralName.getName_User(detail.PrintedUser_ID);
                    sPrintedDate = clsFormatter.FormatDate_Short(detail.DatePrinted) + " , " + clsFormatter.FormatTime_Short(detail.DatePrinted);
                    sApprovedUserID = clsGenaralName.getName_User(detail.ApprovedUser_ID);
                    sApprovedDate = clsFormatter.FormatDate_Short(detail.DateApproved) + " , " + clsFormatter.FormatTime_Short(detail.DateApproved);
                    sCheckedUserID = clsGenaralName.getName_User(detail.CheckedUser_ID);
                    sCheckedDate = clsFormatter.FormatDate_Short(detail.DateChecked) + " , " + clsFormatter.FormatTime_Short(detail.DateChecked);

                    sSrnDate = clsFormatter.FormatDate_Short(detail.SalesReturnedNoteDate);
                    sRemarks = detail.Remark == "" ? "-" : detail.Remark;
                    sCurrencyCode = clsGenaralName.getName_CurrencyCode(detail.Currency_ID);
                    sSRNTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.GrandTotal, detail.CurrencyRate)) + " " + "";
                    sVatTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.VatTotal, detail.CurrencyRate)) + " " + "";
                    sNbtTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.NbtTotal, detail.CurrencyRate)) + " " + "";
                    sSVATTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.OtherTaxTotal, detail.CurrencyRate)) + " " + "";
                    sDiscountTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.DiscountTotal, detail.CurrencyRate)) + " " + "";
                    sSubTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.SubTotal, detail.CurrencyRate)) + " " + "";

                    #region Detail
                    tblEmailDetail.Columns.Add("Item Code");
                    tblEmailDetail.Columns.Add("Item Name");
                    tblEmailDetail.Columns.Add("Qty");
                    tblEmailDetail.Columns.Add("Unit Price");

                    foreach (tbl_sasSalesReturnedNote_Detail oItems in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(detail.SalesReturnedNote_ID))
                    {

                        string sItemCode = oItems.Item_ID;
                        string sItemName = clsGenaralName.getName_Item(oItems.Item_ID);
                        string sQty = detail.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Price(oItems.Weight) : clsFormatter.FormatDecimalPlaces_Price(oItems.Qty);
                        string sUnitPrice = detail.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(oItems.KiloPrice, detail.CurrencyRate)) : clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(oItems.UnitPrice, detail.CurrencyRate));
                        tblEmailDetail.Rows.Add(sItemCode, sItemName, sQty, sUnitPrice);
                    }

                    #endregion
                    List<emailLine> lstEmailDetail = new List<emailLine>();

                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Item Code"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Item Name"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Qty"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Unit Price"));

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string Header2 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    if (alertType == enum_Alerts.SalesReternCreated)
                    {
                        Header2 = "Sale Return Created";
                        sSubject = "SEACC E-Mail Alert : Sale Return Created : " + sSRNID + " : " + sCustomerName; //todo                       
                    }
                    else if (alertType == enum_Alerts.SalesReternCancel)
                    {
                        Header2 = "Sale Return Cancelled";
                        sSubject = "SEACC E-Mail Alert : Sale Return canceled : " + sSRNID + " : " + sCustomerName; //todo                       
                    }
                    else if (alertType == enum_Alerts.SalesReturnNotePrint)
                    {
                        Header2 = "Sale Return Printed";
                        sSubject = "SEACC E-Mail Alert : Sale Return Printed : " + sSRNID + " : " + sCustomerName; //todo                       
                    }


                    List<emailLine> lstEData = new List<emailLine>();
                    EmailLineformating oEmailLineFormat = new EmailLineformating();

                    lstEData.Add(new emailLine(LineType.H1, clsSecurity.CompanyName));
                    lstEData.Add(new emailLine(LineType.H2, Header2));
                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Detail2, "Customer Name", sCustomerName));
                    lstEData.Add(new emailLine(LineType.Detail2, "Sales Return No", sSRNID));
                    lstEData.Add(new emailLine(LineType.Detail2, "Sales Return ", sSrnDate));
                    lstEData.Add(new emailLine(LineType.Detail2, "Remark", sRemarks));
                    lstEData.Add(new emailLine(LineType.DataTable, tblEmailDetail, lstEmailDetail));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Currency", sCurrencyCode));
                    lstEData.Add(new emailLine(LineType.Detail2, "SRN Total", sSRNTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "Discount Total", sDiscountTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "Sub Total", sSubTotal));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Created", sCreateTime + " | " + sCreateUserName));
                    // lstEData.Add(new emailLine(LineType.Detail2, "Create By", sCreateUserName)); 

                    if (alertType == enum_Alerts.SalesReternCancel)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Canceled", (sCancelDateTime = detail.IsDeleted ? sCancelDateTime : "-") + " | " + (sCancelUserName = detail.IsDeleted ? sCancelUserName : "-")));
                    }

                    if (alertType == enum_Alerts.SalesReturnNotePrint)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Printed", (sPrintedDate = detail.PrintCount > 0 ? sPrintedDate : "_") + " | " + (sPrintedUserName = detail.PrintCount > 0 ? sPrintedUserName : "_")));
                    }

                    lstEData.Add(new emailLine(LineType.Detail2, "Checked ", (sCheckedDate = detail.IsChecked ? sCheckedDate : "-") + " | " + (sCheckedUserID = detail.IsChecked ? sCheckedUserID : "-")));
                    lstEData.Add(new emailLine(LineType.Detail2, "Approved ", (sApprovedDate = detail.IsApproved ? sApprovedDate : "-") + " | " + (sApprovedUserID = detail.IsApproved ? sApprovedUserID : "-")));

                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Footer1, "Email Ref No : " + sEmail_ID));

                    sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    clsValidate.WriteErrorLog(sAlertID + " - " + alertType.ToString() + (bEmailStatus ? " Generated Succesfully " : "Generation Failed"), -1,null);
                    #endregion
                }
            }
            else
                bEmailStatus = true;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCExeption.Show(ex);
            }

            return bEmailStatus;
        }
        #endregion

        #region Receipt
        public static bool createEmail_Receipt(string sReceiptID, enum_Alerts alertType)
        {
            bool bEmailStatus = false;

            try
            {
            string sAlertID = clsAutocode.getAlertID(alertType);

            tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
            if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
            {
                DataTable tblEmailDetail = new DataTable();
                string sCustomerName, sCreateUserName, sCreateTime, sCashTotal = "0.00", sChequeTotal = "0.00", sRemark = "", sReceiptDate = "", sCanselUserName, sCancelDateTime, sPrintedUserName, sPrintedDate, sApprovedUserID, sApprovedDate, sCheckedUserID, sCheckedDate;
                List<string> sMaterials = new List<string>();
                ArrayList tolist = new ArrayList();
                ArrayList filelist = new ArrayList();
                string sBodyHTML, sSubject = "", sCurrencyCode;

                // Fill Data for Processing             
                tbl_bpsReceipt detail = tbl_bpsReceipt.Select(sReceiptID);
                if (detail != null && detail.Receipt_ID != "default")
                {
                    #region Create/Format Email Body
                    sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                    sCreateUserName = clsGenaralName.getName_User(detail.CreateUser_ID);
                    sCanselUserName = clsGenaralName.getName_User(clsSecurity.UserIDLoged);
                    sCancelDateTime = clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + " , " + clsFormatter.FormatTime_Short(clsSecurity.getServerDateTime());
                    sCreateTime = clsFormatter.FormatDate_Short(detail.DateCreate) + " , " + clsFormatter.FormatTime_Short(detail.DateCreate);
                    sReceiptDate = clsFormatter.FormatDate_Short(detail.ReceiptDate);
                    sCurrencyCode = clsGenaralName.getName_CurrencyCode(detail.Currency_ID);
                    sCashTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.CashAmount, detail.CurrencyRate)) + " " + "";
                    sChequeTotal = clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(detail.ChequeAmount, detail.CurrencyRate)) + " " + "";

                    sPrintedUserName = clsGenaralName.getName_User(detail.PrintedUser_ID);
                    sPrintedDate = clsFormatter.FormatDate_Short(detail.DatePrinted) + " , " + clsFormatter.FormatTime_Short(detail.DatePrinted);
                    sApprovedUserID = clsGenaralName.getName_User(detail.ApprovedUser_ID);
                    sApprovedDate = clsFormatter.FormatDate_Short(detail.DateApproved) + " , " + clsFormatter.FormatTime_Short(detail.DateApproved);
                    sCheckedUserID = clsGenaralName.getName_User(detail.CheckedUser_ID);
                    sCheckedDate = clsFormatter.FormatDate_Short(detail.DateChecked) + " , " + clsFormatter.FormatTime_Short(detail.DateChecked);

                    #endregion

                    #region Detail
                    if (detail.CashAmount == 0)
                    {
                        tblEmailDetail.Columns.Add("Cheque No");
                        tblEmailDetail.Columns.Add("Cheque Date");
                        tblEmailDetail.Columns.Add("Cheque Amount", typeof(decimal));
                        tblEmailDetail.Columns.Add("Bank Name");
                        foreach (tbl_bpsChequeRegister oItems in tbl_bpsChequeRegister.SelectAllByReceipt_ID(detail.Receipt_ID))
                        {
                            if (oItems.PaymentMethod_ID != (int)PaymentMethod.Cash)
                            {
                                string sChequeNo = oItems.ChequeNumber;
                                string sChequeDate = clsFormatter.FormatDate_Short(oItems.DateCheque);
                                string sChequeAmount = clsFormatter.FormatDecimalPlaces_Price(oItems.Amount);
                                string sBankName = clsGenaralName.getName_Bank(oItems.Bank_ID);
                                tblEmailDetail.Rows.Add(sChequeNo, sChequeDate, sChequeAmount, sBankName);
                            }
                        }
                    }
                    #endregion

                    //List<emailLine> lstEmailDetail = new List<emailLine>();

                    //lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Cheque No"));
                    //lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Cheque Date"));
                    //lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Cheque Amount"));
                    //lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Bank Name"));

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    if (alertType == enum_Alerts.ReceiptCreated)
                    {
                        l1 = "Receipt Created";
                        sSubject = "SEACC E-Mail Alert : Receipt Created : " + sReceiptID + " : " + sCustomerName; //todo
                    }
                    else if (alertType == enum_Alerts.ReceiptCanceled)
                    {
                        l1 = "Receipt Cancelled";
                        sSubject = "SEACC E-Mail Alert : Receipt Cancelled : " + sReceiptID + " : " + sCustomerName; //todo
                    }
                    else if (alertType == enum_Alerts.ReceiptPrinted)
                    {
                        l1 = "Receipt Printed";
                        sSubject = "SEACC E-Mail Alert : Receipt Printed : " + sReceiptID + " : " + sCustomerName; //todo
                    }
                    List<emailLine> lstEData = new List<emailLine>();
                    EmailLineformating oEmailLineFormat = new EmailLineformating();

                    lstEData.Add(new emailLine(LineType.H1, clsSecurity.CompanyName));
                    lstEData.Add(new emailLine(LineType.H2, l1));
                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Detail2, "Customer Name", sCustomerName));
                    lstEData.Add(new emailLine(LineType.Detail2, "Receipt No", sReceiptID));
                    lstEData.Add(new emailLine(LineType.Detail2, "Receipt Date", sReceiptDate));
                    //lstEData.Add(new emailLine(LineType.DataTable, tblEmailDetail, lstEmailDetail));
                    lstEData.Add(new emailLine(LineType.DataTable, tblEmailDetail));
                    lstEData.Add(new emailLine(LineType.Detail2, "Currency", sCurrencyCode));
                    lstEData.Add(new emailLine(LineType.Detail2, "Remark", sRemark != "" ? sRemark : "-"));
                    lstEData.Add(new emailLine(LineType.Detail2, "Cash Total", sCashTotal));
                    lstEData.Add(new emailLine(LineType.Detail2, "Cheque Total", sChequeTotal));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Created By", sCreateTime + " | " + sCreateUserName));
                    if (alertType == enum_Alerts.ReceiptCanceled)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Canceled By", sCancelDateTime + " | " + sCanselUserName));
                    }
                    else if (alertType == enum_Alerts.ReceiptPrinted)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Printed By", sPrintedDate + " | " + sPrintedUserName));
                    }

                    lstEData.Add(new emailLine(LineType.Detail2, "Checked By ", (sCheckedDate = detail.IsChecked ? sCheckedDate : "-") + " | " + (sCheckedUserID = detail.IsChecked ? sCheckedUserID : "-")));
                    lstEData.Add(new emailLine(LineType.Detail2, "Approved By", (sApprovedDate = detail.IsApproved ? sApprovedDate : "-") + " | " + (sApprovedUserID = detail.IsApproved ? sApprovedUserID : "-")));


                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Footer1, "Email Ref No : " + sEmail_ID));

                    sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);
                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    clsValidate.WriteErrorLog(sAlertID + " - " + alertType.ToString() + (bEmailStatus ? " Generated Succesfully " : "Generation Failed"), -1, null);
                    #endregion
                }
            }
            else
                bEmailStatus = true;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCExeption.Show(ex);
            }
            return bEmailStatus;
        }
        #endregion

        #region StockAdjustment
        public static bool createEmail_SAN(string sSANID, enum_Alerts alertType)
        {
            bool bEmailStatus = false;
            try
            {
            string sAlertID = clsAutocode.getAlertID(alertType);

            tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
            if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
            {
                tbl_scsStockAdjustment detail = tbl_scsStockAdjustment.Select(sSANID);
                if (detail != null && detail.StockAdjustment_ID != "default")
                {
                    DataTable tblEmailDetail = new DataTable();
                    string sCreateUserName, sCreateTime, sSANDate = "", sDepartment, sSectionName, sStoreName, sLocation = "", sRemark;// sCanselUserName, sCancelDateTime;
                    List<string> sMaterials = new List<string>();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";

                    #region Create/Format Email Body
                    sCreateUserName = clsGenaralName.getName_User(detail.CreateUser_ID);
                    sCreateTime = clsFormatter.FormatDate_Short(detail.DateCreate) + " , " + clsFormatter.FormatTime_Short(detail.DateCreate);
                    sSANDate = clsFormatter.FormatDate_Short(detail.StockAdjustmentDate);
                    sRemark = detail.Remark == "" ? "-" : detail.Remark;
                    sDepartment = clsGenaralName.getName_Department(detail.Department_ID);
                    sSectionName = clsGenaralName.getName_Section(detail.Section_ID);
                    sStoreName = clsGenaralName.getName_Store(detail.Store_ID);
                    string sCompanyName = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    string sHeading = "Stock Adjustment Created";
                    sSubject = "SEACC E-Mail Alert : Stock Adjustment Created : " + sSANID + ""; //todo

                    if (sDepartment != "")
                        sLocation = sDepartment;
                    else
                    {
                        if (sSectionName != "")
                            sLocation = sSectionName;
                        else
                            sLocation = sStoreName;
                    }

                    #region Detail
                    tblEmailDetail.Columns.Add("Item Code");
                    tblEmailDetail.Columns.Add("Item Name");
                    tblEmailDetail.Columns.Add("adj.Qty");
                    tblEmailDetail.Columns.Add("UOM");
                    tblEmailDetail.Columns.Add("adj.waight");
                    tblEmailDetail.Columns.Add("Unit Price");
                    foreach (tbl_scsStockAdjustment_Detail oStockAdj in tbl_scsStockAdjustment_Detail.SelectAllByStockAdjustment_ID(detail.StockAdjustment_ID))
                    {
                        tbl_genItemMaster oItem = tbl_genItemMaster.Select(oStockAdj.Item_ID);
                        string sItemCode = oStockAdj.Item_ID;
                        string sItemName = clsGenaralName.getName_Item(oStockAdj.Item_ID);
                        string sQty = clsFormatter.FormatDecimalPlaces_Quantity(oStockAdj.Qty);
                        string sUOM = clsGenaralName.getName_Uom(oItem.Uom_ID);
                        string sWeight = clsFormatter.FormatDecimalPlaces_Weight(oStockAdj.Weight);
                        string sUnitPrice = clsFormatter.FormatDecimalPlaces_Price(oStockAdj.UnitPrice);
                        //fill details
                        tblEmailDetail.Rows.Add(sItemCode, sItemName, sQty, sUOM, sWeight, sUnitPrice);
                    }
                    List<emailLine> lstEmailDetail = new List<emailLine>();

                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Item Code"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Item Name"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Qty"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Uom"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Weight"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Unit Price"));
                    #endregion

                    List<emailLine> lstEData = new List<emailLine>();
                    EmailLineformating oEmailLineFormat = new EmailLineformating();

                    lstEData.Add(new emailLine(LineType.H1, clsSecurity.CompanyName));
                    lstEData.Add(new emailLine(LineType.H2, sHeading));
                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Detail2, "Stock Adj. No", sSANID));
                    lstEData.Add(new emailLine(LineType.Detail2, "Stock Adj. Date", sSANDate));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Location", sLocation));
                    lstEData.Add(new emailLine(LineType.Detail2, "Remark", sRemark));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.DataTable, tblEmailDetail, lstEmailDetail));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Create Date & Time", sCreateTime));
                    lstEData.Add(new emailLine(LineType.Detail2, "Create By", sCreateUserName));
                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Footer1, "Email Ref No : " + sEmail_ID));

                    sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);

                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    clsValidate.WriteErrorLog(sAlertID + " - " + alertType.ToString() + (bEmailStatus ? " Generated Succesfully " : "Generation Failed"), -1, null);
                    #endregion
                }
            }
            else
                bEmailStatus = true;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCExeption.Show(ex);
            }

            return bEmailStatus;
        }
        #endregion

        #region Item Spred
        public static bool createEmail_IS(string sISID, enum_Alerts alertType)
        {
            bool bEmailStatus = false;
            try
            {
            string sAlertID = clsAutocode.getAlertID(alertType);

            tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
            if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
            {
                DataTable tblEmailDetail = new DataTable();
                string sCreateUserName, sCreateTime, sISDate = "", sStoreName, sRemark, sCanselUserName, sCancelDateTime;
                List<string> sMaterials = new List<string>();
                ArrayList tolist = new ArrayList();
                ArrayList filelist = new ArrayList();
                string sBodyHTML, sSubject = "";

                // Fill Data for Processing   
                tbl_scsItemSpred detail = tbl_scsItemSpred.Select(sISID);
                if (detail != null && detail.ItemSpred_ID != "default")
                {
                    #region Create/Format Email Body
                    sCreateUserName = clsGenaralName.getName_User(detail.CreateUser_ID);
                    sCreateTime = clsFormatter.FormatDate_Short(detail.DateCreate) + " , " + clsFormatter.FormatTime_Short(detail.DateCreate);
                    sCanselUserName = clsGenaralName.getName_User(clsSecurity.UserIDLoged);
                    sCancelDateTime = clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + " , " + clsFormatter.FormatTime_Short(clsSecurity.getServerDateTime());
                    sISDate = clsFormatter.FormatDate_Short(detail.DateCreate) + " , " + clsFormatter.FormatTime_Short(detail.ItemSpredDate);
                    sRemark = detail.Remark == "" ? "-" : detail.Remark;

                    string sStore = "";
                    foreach (tbl_scsItemSpred_Detail_From oItemSpred in tbl_scsItemSpred_Detail_From.SelectAllByItemSpred_ID(detail.ItemSpred_ID))
                    {
                        sStore = clsGenaralName.getName_Store(oItemSpred.Store_ID);
                    }
                    sStoreName = sStore;

                    #region Detail
                    tblEmailDetail.Columns.Add("Item Code");
                    tblEmailDetail.Columns.Add("Item Name");
                    tblEmailDetail.Columns.Add("Qty");
                    tblEmailDetail.Columns.Add("UOM");
                    tblEmailDetail.Columns.Add("Weight");

                    foreach (tbl_scsItemSpred_Detail_To oItemSpred in tbl_scsItemSpred_Detail_To.SelectAllByItemSpred_ID(detail.ItemSpred_ID))
                    {
                        tbl_genItemMaster oItem = tbl_genItemMaster.Select(oItemSpred.Item_ID);
                        string sItemCode = oItemSpred.Item_ID;
                        string sItemName = clsGenaralName.getName_Item(oItemSpred.Item_ID);
                        string sQty = clsFormatter.FormatDecimalPlaces_Quantity(oItemSpred.Qty);
                        string sUOM = clsGenaralName.getName_Uom(oItem.Uom_ID);
                        string sWeight = clsFormatter.FormatDecimalPlaces_Weight(oItemSpred.Weight);

                        //fill details
                        tblEmailDetail.Rows.Add(sItemCode, sItemName, sQty, sUOM, sWeight);
                    }
                    List<emailLine> lstEmailDetail = new List<emailLine>();

                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Item Code"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Item Name"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Qty"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Uom"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Weight"));
                    #endregion

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    if (alertType == enum_Alerts.ItemSpliteCreate)
                    {
                        l1 = "Item Split Created";
                        sSubject = "SEACC E-Mail Alert : Item Split Created : " + sISID + ""; //todo
                    }
                    else if (alertType == enum_Alerts.ItemSpliteCancel)
                    {
                        l1 = "Item Split Cancelled";
                        sSubject = "SEACC E-Mail Alert : Item Split Cancelled : " + sISID + " : " + ""; //todo
                    }

                    List<emailLine> lstEData = new List<emailLine>();
                    EmailLineformating oEmailLineFormat = new EmailLineformating();

                    lstEData.Add(new emailLine(LineType.H1, clsSecurity.CompanyName));
                    lstEData.Add(new emailLine(LineType.H2, l1));
                    lstEData.Add(new emailLine(LineType.Line1));

                    lstEData.Add(new emailLine(LineType.Detail2, "Item Split No", sISID));
                    lstEData.Add(new emailLine(LineType.Detail2, "Item Split Date", sISDate));
                    lstEData.Add(new emailLine(LineType.Detail2, "Store Name", sStoreName));
                    lstEData.Add(new emailLine(LineType.Detail2, "Remark", sRemark));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.DataTable, tblEmailDetail, lstEmailDetail));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Create Date & Time", sCreateTime));
                    lstEData.Add(new emailLine(LineType.Detail2, "Create By", sCreateUserName));
                    if (alertType == enum_Alerts.ItemSpliteCancel)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Cancel Date & Time", sCancelDateTime));
                        lstEData.Add(new emailLine(LineType.Detail2, "Cancel By", sCanselUserName));
                    }
                    lstEData.Add(new emailLine(LineType.Line1));

                    lstEData.Add(new emailLine(LineType.Footer1, "Email Ref No : " + sEmail_ID));

                    sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    clsValidate.WriteErrorLog(sAlertID + " - " + alertType.ToString() + (bEmailStatus ? " Generated Succesfully " : "Generation Failed"), -1, null);
                    #endregion
                }
            }
            else
                bEmailStatus = true;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCExeption.Show(ex);
            }

            return bEmailStatus;
        }
        #endregion

        #region  GRN Aleart 
        public static bool createEmail_GRN(string GrnID, enum_Alerts alertType)
        {
            bool bEmailStatus = false;
            try
            {
            string sAlertID = clsAutocode.getAlertID(alertType);

            tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
            if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
            {
                tbl_scsExternalGoodReceivedNote detail = tbl_scsExternalGoodReceivedNote.Select(GrnID);
                if (detail != null && detail.ExternalGoodReceivedNote_ID != "default")
                {
                    List<emailLine> lstEData = new List<emailLine>();
                    EmailLineformating oEmailLineFormat = new EmailLineformating();

                    string sBodyHTML = "";
                    #region Create/Format Email Body

                    #region Initialize Data
                    string sSupplierName = clsGenaralName.getName_Supplier(detail.Supplier_ID) == "" ? "-" : clsGenaralName.getName_Supplier(detail.Supplier_ID);
                    string sCreateUserName = clsGenaralName.getName_User(detail.CreateUser_ID) == "" ? "-" : clsGenaralName.getName_User(detail.CreateUser_ID);
                    string sCreateTime = clsFormatter.FormatDate_Short(detail.DateCreate) + " , " + clsFormatter.FormatTime_Short(detail.DateCreate);
                    string sPrintedUserName = clsGenaralName.getName_User(detail.PrintedUser_ID) == "" ? "-" : clsGenaralName.getName_User(detail.PrintedUser_ID);
                    string sPrintedDate = clsFormatter.FormatDate_Short(detail.DatePrinted) + " , " + clsFormatter.FormatTime_Short(detail.DatePrinted);
                    string sModifiedUserName = clsGenaralName.getName_User(detail.ModifiedUser_ID) == "" ? "-" : clsGenaralName.getName_User(detail.ModifiedUser_ID);
                    string sModifiedDate = clsFormatter.FormatDate_Short(detail.DateModified) == "" ? "-" : clsFormatter.FormatDate_Short(detail.DateModified);
                    string sGrnCreateDate = clsFormatter.FormatDate_Short(detail.ExternalGoodReceivedNoteDate) == "" ? "-" : clsFormatter.FormatDate_Short(detail.ExternalGoodReceivedNoteDate);
                    string sApprovedUserID = clsGenaralName.getName_User(detail.ApprovedUser_ID);
                    string sApprovedDate = clsFormatter.FormatDate_Short(detail.DateApproved) + " , " + clsFormatter.FormatTime_Short(detail.DateApproved);
                    string sCheckedUserID = clsGenaralName.getName_User(detail.CheckedUser_ID);
                    string sCheckedDate = clsFormatter.FormatDate_Short(detail.DateChecked) + " , " + clsFormatter.FormatTime_Short(detail.DateChecked);

                    string sDoNo = (detail.DeliveryOrderNumber != "default" && detail.DeliveryOrderNumber != "") ? detail.DeliveryOrderNumber : "-";
                    // string sTrackNo = "-";
                    string sCostCenter = (detail.CostCenter != "default" && detail.CostCenter != "") ? detail.CostCenter : "-";
                    string sPoNo = (detail.PurchaseOrder_ID != "default" && detail.PurchaseOrder_ID != "") ? detail.PurchaseOrder_ID : "-";
                    // string sPrnNo = "";
                    string sStoreName = clsGenaralName.getName_Store(detail.Store_ID) == "" ? "-" : clsGenaralName.getName_Store(detail.Store_ID);
                    string sNoteType = (detail.StockNoteType_ID != "default" && detail.StockNoteType_ID != "") ? detail.StockNoteType_ID : "-";
                    string Header2 = (alertType == enum_Alerts.Good_RecivedNote_Created) ? "Good Received Note Created" : (alertType == enum_Alerts.Good_RecivedNote_Modified) ? "Good Received Note Modified" : "Good Received Note Cancel";
                    if (alertType == enum_Alerts.Good_RecivedNote_Print)
                    { Header2 = "Good Received Note Printed"; }
                    string sSubject = "SEACC E-Mail Alert : " + Header2 + " : " + GrnID + " : " + sSupplierName;
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    string sGrnCanceledUser = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                    string sGrnCancelDate = clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime());
                    string sVat = detail.VatTotal != 0 ? clsFormatter.FormatDecimalPlaces_Price(detail.VatTotal) : "0.00";
                    string sSvat = detail.OtherTaxTotal != 0 ? clsFormatter.FormatDecimalPlaces_Price(detail.OtherTaxTotal) : "0.00";
                    string sNbtVat = detail.NbtTotal != 0 ? clsFormatter.FormatDecimalPlaces_Price(detail.NbtTotal) : "0.00";
                    string sGrandTotal = clsFormatter.FormatDecimalPlaces_Price(detail.GrandTotal);
                    string sDiscount = detail.DiscountTotal != 0 ? clsFormatter.FormatDecimalPlaces_Price(detail.DiscountTotal) : "0.00";
                    string sRemark = detail.Remark != "" ? detail.Remark : "-";
                    #region Detail
                    DataTable tblEmailDetail = new DataTable();
                    List<emailLine> lstEmailDetail = new List<emailLine>();

                    lstEmailDetail.Add(new emailLine(LineType.TableColomn1, "Item No"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Item Name"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "QTY"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "UOM"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Unit Cost"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Amount"));

                    tblEmailDetail.Columns.Add("Item Code");
                    tblEmailDetail.Columns.Add("Item Name");
                    tblEmailDetail.Columns.Add("Qty");
                    tblEmailDetail.Columns.Add("UOM");
                    tblEmailDetail.Columns.Add("Unit Cost", typeof(decimal));
                    tblEmailDetail.Columns.Add("Amount", typeof(decimal));

                    decimal dTotAmount = 0;
                    foreach (tbl_scsExternalGoodReceivedNote_Detail oItems in tbl_scsExternalGoodReceivedNote_Detail.SelectAllByExternalGoodReceivedNote_ID(detail.ExternalGoodReceivedNote_ID))
                    {
                        string sItemCode = oItems.Item_ID;
                        string sItemName = clsGenaralName.getName_Item(oItems.Item_ID);
                        string sQty = detail.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Price(oItems.Weight) : clsFormatter.FormatDecimalPlaces_Price(oItems.Qty);
                        string sUom = clsGenaralName.getName_ItemUOM(oItems.Item_ID);
                        string sUnitPrice = detail.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(oItems.KiloPrice, detail.CurrencyRate)) : clsFormatter.FormatDecimalPlaces_Price(clsHelpMethods.getDisplayPrice(oItems.UnitPrice, detail.CurrencyRate));
                        string sAmount = clsFormatter.FormatDecimalPlaces_Price((decimal.Parse(sUnitPrice)) * (decimal.Parse(sQty)));
                        dTotAmount += decimal.Parse(sAmount);

                        tblEmailDetail.Rows.Add(sItemCode, sItemName, sQty, sUom, sUnitPrice, sAmount.ToString());
                    }
                    #endregion




                    #endregion

                    #region Assing data to Email

                    lstEData.Add(new emailLine(LineType.H1, clsSecurity.CompanyName));
                    lstEData.Add(new emailLine(LineType.H2, Header2));
                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Detail2, "GRN No", GrnID));
                    lstEData.Add(new emailLine(LineType.Detail2, "GRN Date", sGrnCreateDate));
                    lstEData.Add(new emailLine(LineType.Detail2, "Supplier Name", sSupplierName));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "DO No", sDoNo));
                    lstEData.Add(new emailLine(LineType.Detail2, "PO No", sPoNo));
                    lstEData.Add(new emailLine(LineType.Detail2, "Store Name", sStoreName));
                    lstEData.Add(new emailLine(LineType.Detail2, "Remark", sRemark));
                    lstEData.Add(new emailLine(LineType.Space));

                    lstEData.Add(new emailLine(LineType.DataTable, tblEmailDetail, lstEmailDetail));

                    lstEData.Add(new emailLine(LineType.Space));

                    lstEData.Add(new emailLine(LineType.Detail2, "Sub Total", clsFormatter.FormatDecimalPlaces_Price(dTotAmount)));
                    lstEData.Add(new emailLine(LineType.Detail2, "Discount", sDiscount));
                    lstEData.Add(new emailLine(LineType.Detail2, "NBT Total", sNbtVat));
                    lstEData.Add(new emailLine(LineType.Detail2, "VAT Total", sVat));
                    lstEData.Add(new emailLine(LineType.Detail2, "SVAT Total", sSvat));
                    lstEData.Add(new emailLine(LineType.Detail2, "Grand Total", sGrandTotal));

                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Created", sCreateTime + " | " + sCreateUserName));


                    #region Select GRN Type

                    if (alertType == enum_Alerts.Good_RecivedNote_Modified)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Modified", sModifiedDate = detail + " | " + sModifiedUserName));
                    }

                    if (alertType == enum_Alerts.Good_RecivedNote_Cancel)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Canceled", (sGrnCancelDate = detail.IsDeleted ? sGrnCancelDate : "-") + " | " + (sGrnCanceledUser = detail.IsDeleted ? sGrnCanceledUser : "-")));
                    }

                    if (alertType == enum_Alerts.Good_RecivedNote_Print)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Printed", (sPrintedDate = detail.PrintCount > 0 ? sPrintedDate : "_") + " | " + (sPrintedUserName = detail.PrintCount > 0 ? sPrintedUserName : "_")));
                    }

                    #endregion


                    lstEData.Add(new emailLine(LineType.Detail2, "Checked ", (sCheckedDate = detail.IsChecked ? sCheckedDate : "-") + " | " + (sCheckedUserID = detail.IsChecked ? sCheckedUserID : "-")));
                    lstEData.Add(new emailLine(LineType.Detail2, "Approved ", (sApprovedDate = detail.IsApproved ? sApprovedDate : "-") + " | " + (sApprovedUserID = detail.IsApproved ? sApprovedUserID : "-")));

                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Footer1, "Email Ref No : " + sEmail_ID));

                    sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);
                    #endregion
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    clsValidate.WriteErrorLog(sAlertID + " - " + alertType.ToString() + (bEmailStatus ? " Generated Succesfully " : "Generation Failed"), -1, null);
                    #endregion
                }
            }
            else
                bEmailStatus = true;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCExeption.Show(ex);
            }

            return bEmailStatus;
        }
        #endregion

        #region APN Aleart
        public static bool createEmail_APN(string apnID, enum_Alerts alertType)
        {
            bool bEmailStatus = false;
            try
            {
            string sAlertID = clsAutocode.getAlertID(alertType);

            tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
            if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
            {
                tbl_accAccountPayableNote detail = tbl_accAccountPayableNote.Select(apnID);
                if (detail != null && detail.AccountPayableNote_ID != "default")
                {
                    List<emailLine> lstEData = new List<emailLine>();
                    EmailLineformating oEmailLineFormat = new EmailLineformating();

                    string sBodyHTML = "";
                    #region Create/Format Email Body

                    #region Initialize Data
                    string sSupplierName = clsGenaralName.getName_Supplier(detail.Supplier_ID) == "" ? "-" : clsGenaralName.getName_Supplier(detail.Supplier_ID);
                    string sCreateUserName = clsGenaralName.getName_User(detail.CreateUser_ID) == "" ? "-" : clsGenaralName.getName_User(detail.CreateUser_ID);
                    string sPrintedUserName = clsGenaralName.getName_User(detail.PrintedUser_ID) == "" ? "-" : clsGenaralName.getName_User(detail.PrintedUser_ID);
                    string sPrintedDate = clsFormatter.FormatDate_Short(detail.DatePrinted) + " , " + clsFormatter.FormatTime_Short(detail.DatePrinted);
                    string sModifiedUserName = clsGenaralName.getName_User(detail.ModifiedUser_ID) == "" ? "-" : clsGenaralName.getName_User(detail.ModifiedUser_ID);
                    string sModifiedDate = clsFormatter.FormatDate_Short(detail.DateModified) + " , " + clsFormatter.FormatTime_Short(detail.DateModified);
                    string sCreateDate = clsFormatter.FormatDate_Short(detail.DateCreate) + " , " + clsFormatter.FormatTime_Short(detail.DateCreate);
                    string sApprovedUserID = clsGenaralName.getName_User(detail.ApprovedUser_ID);
                    string sApprovedDate = clsFormatter.FormatDate_Short(detail.DateApproved) + " , " + clsFormatter.FormatTime_Short(detail.DateApproved);
                    string sCheckedUserID = clsGenaralName.getName_User(detail.CheckedUser_ID);
                    string sCheckedDate = clsFormatter.FormatDate_Short(detail.DateChecked) + " , " + clsFormatter.FormatTime_Short(detail.DateChecked);
                    string sCanceledUser = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                    string sCancelDate = clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + " , " + clsFormatter.FormatTime_Short(clsSecurity.getServerDateTime());
                    string sAPNNo = detail.AccountPayableNote_ID;
                    string sAPNDate = clsFormatter.FormatDate_Short(detail.AccountPayableNoteDate);
                    string sCreditorName = clsGenaralName.getName_Supplier(detail.Supplier_ID);
                    string sNarration = detail.Narration != "" ? detail.Narration : "-";
                    string sBillNo = detail.BillNo != "default" ? sBillNo = detail.BillNo : "-";
                    string sBillDate = clsFormatter.FormatDate_Short(detail.BillDate);
                    string sPONo = detail.PurchaseOrder_ID != "default" ? detail.PurchaseOrder_ID : "-";
                    string sGRNNo = detail.ExternalGoodReceivedNote_ID != "default" ? detail.ExternalGoodReceivedNote_ID : "-";
                    // string sRefundNoteNo =detail.ref
                    string sVat = clsFormatter.FormatDecimalPlaces_Price(detail.VatTotal);
                    string sNBT = clsFormatter.FormatDecimalPlaces_Price(detail.NbtTotal);
                    string sSVAT = clsFormatter.FormatDecimalPlaces_Price(detail.OtherTaxTotal);

                    //change the Enum Types
                    string Header2 = (alertType == enum_Alerts.AccountPayableNoteCreated) ? "Account Payable  Note Created" : (alertType == enum_Alerts.AccountPayableNoteModified) ? "Account Payable  Note Modified" : "Account Payable  Note Cancel";
                    if (alertType == enum_Alerts.AccountPayableNotePrinted)
                    { Header2 = "Account Payable  Note Printed"; }

                    string sSubject = "SEACC E-Mail Alert : " + Header2 + " : " + detail.AccountPayableNote_ID + " : " + sSupplierName;
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());

                    #region Detail
                    DataTable tblEmailDetail = new DataTable();
                    List<emailLine> lstEmailDetail = new List<emailLine>();

                    lstEmailDetail.Add(new emailLine(LineType.TableColomn1, "sGLCode"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "sGLAccountName"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "CreditAmount"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "DebitAmount"));


                    tblEmailDetail.Columns.Add("Account Code");
                    tblEmailDetail.Columns.Add("Account Name");
                    tblEmailDetail.Columns.Add("Credit Amount");
                    tblEmailDetail.Columns.Add("Debit Amount");


                    //  decimal dTotAmount = 0;
                    foreach (tbl_accAccountPayableNote_SubTotal oItems in tbl_accAccountPayableNote_SubTotal.SelectAllByAccountPayableNote_ID(detail.AccountPayableNote_ID))
                    {
                        string sGLCode = oItems.Gl_ID;
                        string sGLAccountName = clsGenaralName.getName_AccountName(oItems.Gl_ID);
                        //string sCreditAmount = oItems.IsCredit ? clsFormatter.FormatDecimalPlaces_Price(oItems.Amount) : "-";
                        //string sDebitAmount = !oItems.IsCredit ? clsFormatter.FormatDecimalPlaces_Price(oItems.Amount) : "-";
                        string sCreditAmount = oItems.IsCredit ? clsFormatter.FormatDecimalPlaces_Price(oItems.Amount) : "-";
                        string sDebitAmount = !oItems.IsCredit ? clsFormatter.FormatDecimalPlaces_Price(oItems.Amount) : "-";

                        tblEmailDetail.Rows.Add(sGLCode, sGLAccountName, sCreditAmount, sDebitAmount);
                    }
                    #endregion

                    #endregion

                    #region Assing data to Email

                    lstEData.Add(new emailLine(LineType.H1, clsSecurity.CompanyName));
                    lstEData.Add(new emailLine(LineType.H2, Header2));
                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Detail2, "APN No", sAPNNo));
                    lstEData.Add(new emailLine(LineType.Detail2, "APN Date", sAPNDate));
                    lstEData.Add(new emailLine(LineType.Detail2, "Creditor  Name", sCreditorName));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Narration", sNarration));
                    lstEData.Add(new emailLine(LineType.Detail2, "Bill No", sBillNo));
                    lstEData.Add(new emailLine(LineType.Detail2, "Bill Date", sBillDate));
                    lstEData.Add(new emailLine(LineType.Detail2, "PO No", sPONo));
                    lstEData.Add(new emailLine(LineType.Detail2, "GRN No", sGRNNo));
                    // lstEData.Add(new emailLine(LineType.Detail2, "Refund Note No", "-"));
                    lstEData.Add(new emailLine(LineType.Detail2, "VAT Total", sVat));
                    lstEData.Add(new emailLine(LineType.Detail2, "NBT", sNBT));
                    lstEData.Add(new emailLine(LineType.Detail2, "SVAT Total", sSVAT));

                    lstEData.Add(new emailLine(LineType.Space));

                    lstEData.Add(new emailLine(LineType.DataTable, tblEmailDetail, lstEmailDetail));

                    lstEData.Add(new emailLine(LineType.Space));

                    // lstEData.Add(new emailLine(LineType.Detail2, "Grand Total", sGrandTotal));

                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Created", sCreateDate + " | " + sCreateUserName));


                    #region Select APN Type

                    if (alertType == enum_Alerts.AccountPayableNoteModified)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Modified", sModifiedDate + " | " + sModifiedUserName));
                    }

                    if (alertType == enum_Alerts.AccountPayableNoteDeleted)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Canceled", (sCancelDate = detail.IsDeleted ? sCancelDate : "-") + " | " + (sCanceledUser = detail.IsDeleted ? sCanceledUser : "-")));
                    }

                    if (alertType == enum_Alerts.AccountPayableNotePrinted)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Printed", (sPrintedDate = detail.PrintCount > 0 ? sPrintedDate : "_") + " | " + (sPrintedUserName = detail.PrintCount > 0 ? sPrintedUserName : "_")));
                    }

                    #endregion


                    lstEData.Add(new emailLine(LineType.Detail2, "Checked ", (sCheckedDate = detail.IsChecked ? sCheckedDate : "-") + " | " + (sCheckedUserID = detail.IsChecked ? sCheckedUserID : "-")));
                    lstEData.Add(new emailLine(LineType.Detail2, "Approved ", (sApprovedDate = detail.IsApproved ? sApprovedDate : "-") + " | " + (sApprovedUserID = detail.IsApproved ? sApprovedUserID : "-")));

                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Footer1, "Email Ref No : " + sEmail_ID));

                    sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);
                    #endregion
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    clsValidate.WriteErrorLog(sAlertID + " - " + alertType.ToString() + (bEmailStatus ? " Generated Succesfully " : "Generation Failed"), -1,null);
                    #endregion

                }
            }
            else
                bEmailStatus = true;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCExeption.Show(ex);
            }

            return bEmailStatus;
        }
        #endregion

        #region PV Alert
        public static bool createEmail_PV(string pvID, enum_Alerts alertType)
        {
            bool bEmailStatus = false;
            try
            {
            string sAlertID = clsAutocode.getAlertID(alertType);

            tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
            if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
            {
                tbl_accPaymentVoucher detail = tbl_accPaymentVoucher.Select(pvID);
                if (detail != null && detail.PaymentVoucher_ID != "default")
                {
                    List<emailLine> lstEData = new List<emailLine>();
                    EmailLineformating oEmailLineFormat = new EmailLineformating();

                    string sBodyHTML = "";
                    #region Create/Format Email Body

                    #region Initialize Data
                    string sCreateUserName = clsGenaralName.getName_User(detail.CreateUser_ID) == "" ? "-" : clsGenaralName.getName_User(detail.CreateUser_ID);
                    string sCreateDate = clsFormatter.FormatDate_Short(detail.DateCreate) + " , " + clsFormatter.FormatTime_Short(detail.DateCreate);
                    string sPrintedUserName = clsGenaralName.getName_User(detail.PrintedUser_ID) == "" ? "-" : clsGenaralName.getName_User(detail.PrintedUser_ID);
                    string sPrintedDate = clsFormatter.FormatDate_Short(detail.DatePrinted) + " , " + clsFormatter.FormatTime_Short(detail.DatePrinted);
                    string sModifiedUserName = clsGenaralName.getName_User(detail.ModifiedUser_ID) == "" ? "-" : clsGenaralName.getName_User(detail.ModifiedUser_ID);
                    string sModifiedDate = clsFormatter.FormatDate_Short(detail.DateModified) + " , " + clsFormatter.FormatTime_Short(detail.DateModified);
                    string sApprovedUserID = clsGenaralName.getName_User(detail.ApprovedUser_ID);
                    string sApprovedDate = clsFormatter.FormatDate_Short(detail.DateApproved) + " , " + clsFormatter.FormatTime_Short(detail.DateApproved);
                    string sCheckedUserID = clsGenaralName.getName_User(detail.CheckedUser_ID);
                    string sCheckedDate = clsFormatter.FormatDate_Short(detail.DateChecked) + " , " + clsFormatter.FormatTime_Short(detail.DateChecked);
                    string sCanceledUser = clsCommon.fncsetstring(clsSecurity.UserNameLoged);
                    string sCancelDate = clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + " , " + clsFormatter.FormatTime_Short(clsSecurity.getServerDateTime());

                    string sPvno = detail.PaymentVoucher_ID;
                    string sPVDate = clsFormatter.FormatDate_Short(detail.PaymentVoucherDate);
                    string sPayee = detail.Payee;
                    string sCreditor_Name = "";

                    foreach (tbl_accPaymentVoucher_SubTotal odetail in tbl_accPaymentVoucher_SubTotal.SelectAllByPaymentVoucher_ID(detail.PaymentVoucher_ID).Where(p => p.IsCredit))
                        sCreditor_Name = clsGenaralName.getName_Supplier(odetail.Supplier_ID);

                    string sBankName = "", sAccountNo = "", sChequeNo = "", sChequeDate = "", sRemark = "";
                    foreach (tbl_accChequeRegister oCheque in tbl_accChequeRegister.SelectAllByPaymentVoucher_ID(detail.PaymentVoucher_ID).Where(p => p.ChequeNumber != "default"))
                    {
                        tbl_genCompanyAccount oAcc = tbl_genCompanyAccount.Select(oCheque.CompanyAccount_ID);
                        if (oAcc != null)
                        {
                            sBankName = clsGenaralName.getName_Bank(oAcc.Bank_ID);
                            sAccountNo = oAcc.AccountNumber;
                            sChequeNo = oCheque.ChequeNumber;
                            sChequeDate = clsFormatter.FormatDate_Short(oCheque.DateCheque);
                            sRemark = oCheque.Remark;
                        }
                    }

                    string sNarration = detail.Narration != "" ? detail.Narration : "-";

                    string Header2 = (alertType == enum_Alerts.PaymentVoucherCreated) ? "Payment Voucher Created" : (alertType == enum_Alerts.PaymentVoucherModified) ? "Account Payable  Note Modified" : "Account Payable  Note Canceled";
                    if (alertType == enum_Alerts.PaymentVoucherPrinted)
                    { Header2 = "Payment Voucher Printed"; }

                    string sSubject = "SEACC E-Mail Alert : " + Header2 + " : " + detail.PaymentVoucher_ID + " : " + sPayee;
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());

                    #region Detail
                    DataTable tblEmailDetail = new DataTable();
                    List<emailLine> lstEmailDetail = new List<emailLine>();

                    lstEmailDetail.Add(new emailLine(LineType.TableColomn1, "AccNo"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "AccName"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "AmountDebit"));
                    lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "AmountCredit"));

                    tblEmailDetail.Columns.Add("Account No");
                    tblEmailDetail.Columns.Add("Account Name");
                    tblEmailDetail.Columns.Add("Amount (De)");
                    tblEmailDetail.Columns.Add("Amount (Cr)");


                    string sAmount = "";
                    foreach (tbl_accPaymentVoucher_SubTotal oGlcode in tbl_accPaymentVoucher_SubTotal.SelectAllByPaymentVoucher_ID(detail.PaymentVoucher_ID).Where(p => p.PaymentVoucher_ID != "default"))
                    {
                        if (oGlcode.Amount.ToString().IndexOf("-") != -1)
                            sAmount = "(" + clsFormatter.FormatDecimalPlaces_Price(oGlcode.Amount) + ")";
                        else
                            sAmount = clsFormatter.FormatDecimalPlaces_Price(oGlcode.Amount);

                        tblEmailDetail.Rows.Add(oGlcode.Gl_ID, clsGenaralName.getName_AccountName(oGlcode.Gl_ID), !oGlcode.IsCredit ? sAmount : "0.00", oGlcode.IsCredit ? sAmount : "0.00");
                    }

                    #endregion

                    #endregion

                    #region Assing data to Email

                    lstEData.Add(new emailLine(LineType.H1, clsSecurity.CompanyName));
                    lstEData.Add(new emailLine(LineType.H2, Header2));
                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Detail2, "PV No", sPvno));
                    lstEData.Add(new emailLine(LineType.Detail2, "PV Date", sPVDate));
                    lstEData.Add(new emailLine(LineType.Detail2, "Payee", sPayee));
                    lstEData.Add(new emailLine(LineType.Detail2, "Creditor Name", sCreditor_Name));

                    lstEData.Add(new emailLine(LineType.Detail2, "Bank Name", sBankName));
                    lstEData.Add(new emailLine(LineType.Detail2, "Bank Account", sAccountNo));
                    lstEData.Add(new emailLine(LineType.Detail2, "Cheque no", sChequeNo));
                    lstEData.Add(new emailLine(LineType.Detail2, "Cheque date", sChequeDate));
                    lstEData.Add(new emailLine(LineType.Detail2, "Narration", sNarration));
                    // lstEData.Add(new emailLine(LineType.Space));

                    lstEData.Add(new emailLine(LineType.Space));

                    lstEData.Add(new emailLine(LineType.DataTable, tblEmailDetail, lstEmailDetail));

                    lstEData.Add(new emailLine(LineType.Space));

                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Created", sCreateDate + " | " + sCreateUserName));

                    #region Select APN Type

                    if (alertType == enum_Alerts.PaymentVoucherModified)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Modified", sModifiedDate + " | " + sModifiedUserName));
                    }

                    if (alertType == enum_Alerts.PaymentVoucherCanceled)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Canceled", (sCancelDate = detail.IsDeleted ? sCancelDate : "-") + " | " + (sCanceledUser = detail.IsDeleted ? sCanceledUser : "-")));
                    }

                    if (alertType == enum_Alerts.PaymentVoucherPrinted)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, "Printed", (sPrintedDate = detail.PrintCount > 0 ? sPrintedDate : "_") + " | " + (sPrintedUserName = detail.PrintCount > 0 ? sPrintedUserName : "_")));
                    }

                    #endregion


                    lstEData.Add(new emailLine(LineType.Detail2, "Checked ", (sCheckedDate = detail.IsChecked ? sCheckedDate : "-") + " | " + (sCheckedUserID = detail.IsChecked ? sCheckedUserID : "-")));
                    lstEData.Add(new emailLine(LineType.Detail2, "Approved ", (sApprovedDate = detail.IsApproved ? sApprovedDate : "-") + " | " + (sApprovedUserID = detail.IsApproved ? sApprovedUserID : "-")));

                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Footer1, "Email Ref No : " + sEmail_ID));

                    sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);
                    #endregion
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    clsValidate.WriteErrorLog(sAlertID + " - " + alertType.ToString() + (bEmailStatus ? " Generated Succesfully " : "Generation Failed"), -1,null);
                    #endregion

                }
            }
            else
                bEmailStatus = true;

            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                SEACCExeption.Show(ex);
            }

            return bEmailStatus;
        }


        #endregion

        #endregion

        #region Production Job Confirmed
        public static bool createEmail_ProductionJobConfirmed(String sProductionJobID)
        {
            bool bEmailStatus = false;
            string sCustomerName, sProductionJobType, sConfirmedBy, sconfirmedDateTime, sItemName, sItemSize, sOrderedQty, sWeight, sCustomerOrderNo = "", sCustomerOrderDate = "", sDeliveryDate = "", sUnitPrice = "0.00", sComment = "", sRefname = "";
            List<string> sMaterials;

            // E-mail Information
            ArrayList tolist = new ArrayList();
            ArrayList filelist = new ArrayList();
            string sSubject, sBodyHTML, sCreateTime, sCreateUserName;

            List<emailLine> lstEData = new List<emailLine>();
            string sAlertID = clsAutocode.getAlertID(enum_Alerts.JITAlert_ProductionJobConfirmed);

            tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
            // tbl_utlAlert oAlert = tbl_utlAlert.Select(clsAutocode.getAlertID(enum_Alerts.JITAlert_ProductionJobConfirmed));
            if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
            {

                tbl_pmsProductionJobRegister detail = tbl_pmsProductionJobRegister.Select(sProductionJobID);
                if (detail != null && detail.ProductionJob_ID != "default")
                {
                    sCustomerName = clsGenaralName.getName_Customer(detail.Customer_ID);
                    sProductionJobType = clsGenaralName.getName_ProductionJobType(detail.ProductionJobType_ID);
                    sConfirmedBy = clsGenaralName.getName_User(detail.ApprovedUser_ID);
                    sconfirmedDateTime = clsFormatter.FormatDate_Short(detail.DateApproved) + "" + clsFormatter.FormatTime_Short(detail.DateApproved);
                    sItemName = clsGenaralName.getName_Item(detail.Item_ID);
                    sItemSize = clsHelpMethods.GetItemSizeByItemID(detail.Item_ID);//to do-default
                    sOrderedQty = clsFormatter.FormatDecimalPlaces_Quantity(detail.Qty);
                    sMaterials = clsHelpMethods.getCombinationMaterialListByProductionJobID(detail.ProductionJob_ID, true);//to do-default
                    sWeight = clsFormatter.FormatDecimalPlaces_Weight(detail.Weight);
                    sComment = detail.Remark;
                    sCreateTime = clsFormatter.FormatDate_Short(detail.DateCreate);
                    sCreateUserName = clsGenaralName.getName_User(detail.CreateUser_ID);
                    tbl_sasJobRegister oJob = tbl_sasJobRegister.Select(detail.Job_ID);
                    if (oJob != null && oJob.Job_ID != "default")
                        sComment = oJob.Remark;
                    // string sRemark=d

                    tbl_genCustomerMaster oOderReff = tbl_genCustomerMaster.Select(detail.Customer_ID);
                    if (oOderReff != null && oOderReff.Customer_ID != "default")
                        sRefname = clsGenaralName.getName_SalesRep(oOderReff.SalesRep_ID);

                    tbl_sasCustomerOrder oCustomerOrder = tbl_sasCustomerOrder.Select(detail.CustomerOrder_ID);
                    if (oCustomerOrder != null && oCustomerOrder.CustomerOrder_ID != "default")
                    {
                        sCustomerOrderNo = oCustomerOrder.PurchaseOrder_ID;
                        sDeliveryDate = clsFormatter.FormatDate_Short(oCustomerOrder.DeliveryDate);
                        sCustomerOrderDate = clsFormatter.FormatDate_Short(oCustomerOrder.CustomerOrderDate);

                        tbl_sasCustomerOrder_Detail oCusOrdrDetail = tbl_sasCustomerOrder_Detail.Select(0, oCustomerOrder.CustomerOrder_ID, detail.Item_ID, "default", "default", "0", "0");
                        if (oCusOrdrDetail != null)
                            sUnitPrice = oCustomerOrder.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_WeightPrice(oCusOrdrDetail.WeightPrice) : clsFormatter.FormatDecimalPlaces_UnitPrice(oCusOrdrDetail.UnitPrice);
                    }
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "PRODUCTION JOB APPROVED";
                    int i = 0;
                    sSubject = "SEACC E-Mail Alert : Prod.Job Approved : " + sProductionJobID + " : " + sCustomerName; //todo

                    lstEData.Add(new emailLine(LineType.H1, clsSecurity.CompanyName));
                    lstEData.Add(new emailLine(LineType.H2, l1));
                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Detail2, "Customer Name", sCustomerName));
                    lstEData.Add(new emailLine(LineType.Detail2, "Sales Man Name", sRefname));
                    lstEData.Add(new emailLine(LineType.Detail2, "Customer Order No", sCustomerOrderNo));
                    lstEData.Add(new emailLine(LineType.Detail2, "Customer Order Date", sCustomerOrderDate));
                    lstEData.Add(new emailLine(LineType.Detail2, "Delivery Date", sDeliveryDate));
                    lstEData.Add(new emailLine(LineType.Detail2, "Comment", sComment != "" ? sComment : "-"));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Production Job NO", sProductionJobID));
                    lstEData.Add(new emailLine(LineType.Detail2, "Production Job Type", sProductionJobType));
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Item Code & Desc", (detail.Item_ID + "-" + sItemName).ToString().Trim()));
                    lstEData.Add(new emailLine(LineType.Detail2, "Ordered QTY", sOrderedQty));
                    lstEData.Add(new emailLine(LineType.Detail2, "Size", sItemSize));
                    lstEData.Add(new emailLine(LineType.Detail2, "Unit Price (Rs)", sUnitPrice));
                    lstEData.Add(new emailLine(LineType.Space));
                    foreach (string material in sMaterials)
                    {
                        lstEData.Add(new emailLine(LineType.Detail2, i == 0 ? "BOQ/BOM" : "", material));
                        i++;
                    }
                    lstEData.Add(new emailLine(LineType.Space));
                    lstEData.Add(new emailLine(LineType.Detail2, "Approved Date ", sconfirmedDateTime));
                    lstEData.Add(new emailLine(LineType.Detail2, "Approved By", sConfirmedBy));
                    lstEData.Add(new emailLine(LineType.Line1));
                    lstEData.Add(new emailLine(LineType.Footer1, "Email Ref No : " + sEmail_ID));
                    //sItemSize
                    EmailLineformating oEmailLineFormat = new EmailLineformating();
                    sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);

                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    clsValidate.WriteErrorLog(sAlertID + " - " + "Production Job Confirmed" + " Generated Succesfully ", -1,null);
                }
            }
            else
                bEmailStatus = true;

            return bEmailStatus;
        }
        #endregion

        #region Email Alerts Sheduled

        #region Cheque Pending Bank Deposit
        public static bool createEmail_ChequePendingBankDeposit(enum_Alerts alertType, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    #region Create/Format Email Body
                    DataTable tblEmailHeader = new DataTable();
                    DataTable tblEmailDetail = new DataTable();
                    DataTable tblEmailUND = new DataTable();
                    string sTabKey = System.Convert.ToChar(9).ToString();
                    //string sCustomerName, sCreateUserName, sCreateTime;
                    decimal sTotalAmount = 0;
                    List<string> sPendingCheque = new List<string>();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";// sUser, sBody, sCurrencyCode;

                    // Fill Data for Processing 

                    #region Header
                    tblEmailHeader.Columns.Add("heading");
                    tblEmailHeader.Columns.Add("detail");
                    tblEmailHeader.Columns.Add("DataType");
                    tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()));
                    #endregion

                    #region Detail
                    tblEmailDetail.Columns.Add("# ");
                    tblEmailDetail.Columns.Add("Customer Name");
                    tblEmailDetail.Columns.Add("Salesman Name");
                    tblEmailDetail.Columns.Add("Cheque No");
                    tblEmailDetail.Columns.Add("Cheque Date");
                    tblEmailDetail.Columns.Add("Days");
                    tblEmailDetail.Columns.Add("Amount", typeof(decimal));
                    int i = 1;

                    foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAll().Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default" && !p.IsReIssued && !p.IsReturnedToSender && !p.IsDepositted && p.DateCheque.Date <= clsSecurity.getServerDateTime().Date).OrderBy(p => p.DateCheque))
                    {
                        if (oCheque.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                        {
                            string sCustomer = clsGenaralName.getName_Customer(oCheque.Customer_ID);
                            string sSalesman = "";
                            string sChequeNo = oCheque.ChequeNumber;
                            string sChequeDate = clsFormatter.FormatDate_Short(oCheque.DateCheque);
                            string sDays = clsCommon.getDaysUptoDate(oCheque.DateCheque).ToString();
                            string sAmount = clsFormatter.FormatDecimalPlaces_Price(oCheque.Amount);
                            tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(oCheque.OrderRefNo_ID);
                            if (order != null)
                            {
                                sSalesman = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                            }
                            sTotalAmount += oCheque.Amount;

                            tblEmailDetail.Rows.Add(i, sCustomer, sSalesman, sChequeNo, sChequeDate, sDays, sAmount);
                            i++;
                        }
                    }
                    tblEmailDetail.Rows.Add("", "", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(sTotalAmount));

                    #endregion

                    #region Footer
                    tblEmailUND.Columns.Add("heading");
                    tblEmailUND.Columns.Add("details");
                    tblEmailUND.Columns.Add("DataType");
                    //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");  
                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("", "");
                    #endregion

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    if (alertType == enum_Alerts.SheduleAlert_ChequePendingDeposit)//
                    {
                        l1 = "Cheques Pending Deposit ";
                        sSubject = "SEACC Alert : Cheques Pending Deposit As At : " + clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + "  "; //todo
                    }

                    sBodyHTML = CreateEmailBody(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail, tblEmailUND);
                    #endregion

                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , -1,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }

        public static bool createEmail_ChequePendingBankDeposit1(enum_Alerts alertType)
        {
            string sAlertID = "";
            bool bEmailStatus = false;
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    #region Variables
                    string sTabKey = System.Convert.ToChar(9).ToString();
                    decimal sTotalAmount = 0;
                    List<string> sPendingCheque = new List<string>();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";// sUser, sBody, sCurrencyCode;
                    string sAlertDate = clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime());
                    List<emailLine> lstEmailDetail = new List<emailLine>();
                    EmailLineformating oEmailLineFormat = new EmailLineformating();


                    DataTable tblEmailDetail = new DataTable();
                    tblEmailDetail.Columns.Add("#");
                    tblEmailDetail.Columns.Add("Customer");
                    tblEmailDetail.Columns.Add("SalesMan");
                    tblEmailDetail.Columns.Add("ChequeNo");
                    tblEmailDetail.Columns.Add("Cheque Date");
                    tblEmailDetail.Columns.Add("Days");
                    tblEmailDetail.Columns.Add("Amount", typeof(decimal));
                    #endregion

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    if (alertType == enum_Alerts.SheduleAlert_ChequePendingDeposit)
                    {
                        l1 = "Cheques Pending Deposit ";
                        sSubject = "SEACC Alert : Cheques Pending Deposit As At : " + clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + "  "; //todo
                    }

                    #region Header Detail
                    lstEmailDetail.Add(new emailLine(LineType.H1, Name));
                    lstEmailDetail.Add(new emailLine(LineType.H2, l1));
                    lstEmailDetail.Add(new emailLine(LineType.Line1));
                    lstEmailDetail.Add(new emailLine(LineType.H5, clsSecurity.getServerDateTime().ToString()));
                    #endregion

                    #region Detail Section

                    int i = 1;

                    foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAll().Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default" && !p.IsReIssued && !p.IsReturnedToSender && !p.IsDepositted && p.DateCheque.Date <= clsSecurity.getServerDateTime().Date).OrderBy(p => p.DateCheque))
                    {
                        if (oCheque.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                        {
                            string sCustomer = clsGenaralName.getName_Customer(oCheque.Customer_ID);
                            string sSalesman = "";
                            string sChequeNo = oCheque.ChequeNumber;
                            string sChequeDate = clsFormatter.FormatDate_Short(oCheque.DateCheque);
                            string sDays = clsCommon.getDaysUptoDate(oCheque.DateCheque).ToString();
                            string sAmount = clsFormatter.FormatDecimalPlaces_Price(oCheque.Amount);
                            tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(oCheque.OrderRefNo_ID);

                            if (order != null)
                            {
                                sSalesman = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                            }

                            sTotalAmount += oCheque.Amount;

                            tblEmailDetail.Rows.Add(i, sCustomer, sSalesman, sChequeNo, sChequeDate, sDays, sAmount);

                            i++;
                        }
                    }
                    tblEmailDetail.Rows.Add("", "", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(sTotalAmount));
                    #endregion

                    lstEmailDetail.Add(new emailLine(LineType.DataTable, tblEmailDetail, lstEmailDetail));
                    sBodyHTML = clsEmailConfig.CreateEmailBody(lstEmailDetail);

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);

                    #endregion
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            return bEmailStatus;
        }
        #endregion

        #region Cash Sales Not Deposited
        public static bool createEmail_CashSalesNotDeposited(enum_Alerts alertType, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    #region Create/Format Email Body
                    DataTable tblEmailHeader = new DataTable();
                    DataTable tblEmailDetail = new DataTable();
                    DataTable tblEmailUND = new DataTable();
                    string sTabKey = System.Convert.ToChar(9).ToString();
                    decimal sTotalAmount = 0;
                    List<string> sPendingCheque = new List<string>();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";// sUser, sBody, sCurrencyCode;

                    // Fill Data for Processing 

                    #region Header
                    tblEmailHeader.Columns.Add("heading");
                    tblEmailHeader.Columns.Add("detail");
                    tblEmailHeader.Columns.Add("DataType");
                    tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()));
                    #endregion

                    #region Detail
                    tblEmailDetail.Columns.Add("# ");
                    tblEmailDetail.Columns.Add("Customer Name");
                    tblEmailDetail.Columns.Add("Salesman Name");
                    tblEmailDetail.Columns.Add("Receipt No");
                    tblEmailDetail.Columns.Add("Receipt Date");
                    tblEmailDetail.Columns.Add("Days");
                    tblEmailDetail.Columns.Add("Amount", typeof(decimal));
                    int i = 1;

                    foreach (tbl_bpsReceipt oReceipt in tbl_bpsReceipt.SelectAll().Where(p => !p.IsDeleted && p.Receipt_ID != "default" && !p.IsCashDeposited && p.CashAmount > 0 && p.ReceiptDate.Date <= clsSecurity.getServerDateTime().Date).OrderBy(p => p.ReceiptDate))
                    {
                        string sCustomer = clsGenaralName.getName_Customer(oReceipt.Customer_ID);
                        string sSalesman = "";
                        string sReceiptNo = oReceipt.Receipt_ID;
                        string sReceiptDate = clsFormatter.FormatDate_Short(oReceipt.ReceiptDate);
                        string sDays = clsCommon.getDaysUptoDate(oReceipt.ReceiptDate).ToString();
                        string sAmount = clsFormatter.FormatDecimalPlaces_Price(oReceipt.CashAmount);
                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(oReceipt.OrderRefNo_ID);
                        if (order != null)
                        {
                            sSalesman = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                        }
                        sTotalAmount += oReceipt.CashAmount;

                        tblEmailDetail.Rows.Add(i, sCustomer, sSalesman, sReceiptNo, sReceiptDate, sDays, sAmount);
                        i++;
                    }
                    tblEmailDetail.Rows.Add("", "", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(sTotalAmount));
                    #endregion

                    #region Footer
                    tblEmailUND.Columns.Add("heading");
                    tblEmailUND.Columns.Add("details");
                    tblEmailUND.Columns.Add("DataType");
                    //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");  
                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("", "");
                    #endregion

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    if (alertType == enum_Alerts.SheduleAlert_CashSalesNotDeposited)//
                    {
                        l1 = "Cash Sales Not Deposited ";
                        sSubject = "SEACC Alert : Cash Sales Not Deposited As At: " + clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + "  "; //todo
                    }

                    sBodyHTML = CreateEmailBody(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail, tblEmailUND);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);

                    #endregion
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(alertType.ToString() + " - " + ex.ToString(), clsFormatter.GetMessageCaption());
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }

        public static bool createEmail_CashSalesNotDeposited1(enum_Alerts alertType)
        {
            #region Variables
            ArrayList tolist = new ArrayList();
            ArrayList filelist = new ArrayList();
            string sBodyHTML, sSubject = "";// string sUser, sBody, sCurrencyCode;
            string sAlertDate = clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime());
            List<emailLine> lstEmailDetail = new List<emailLine>();
            EmailLineformating oEmailLineFormat = new EmailLineformating();
            decimal sTotalAmount = 0;

            bool bEmailStatus = false;



            //tblEmailDetail.Columns.Add("# ");
            //tblEmailDetail.Columns.Add("Customer Name");
            //tblEmailDetail.Columns.Add("Salesman Name");
            //tblEmailDetail.Columns.Add("Receipt No");
            //tblEmailDetail.Columns.Add("Receipt Date");
            //tblEmailDetail.Columns.Add("Days");
            //tblEmailDetail.Columns.Add("Amount");


            DataTable tblEmailDetail = new DataTable();
            tblEmailDetail.Columns.Add("#");
            tblEmailDetail.Columns.Add("Customer");
            tblEmailDetail.Columns.Add("SalesMan");
            tblEmailDetail.Columns.Add("ChequeNo");
            tblEmailDetail.Columns.Add("Cheque Date");
            tblEmailDetail.Columns.Add("Days");
            tblEmailDetail.Columns.Add("Amount", typeof(decimal));
            #endregion

            string sAlertID = clsAutocode.getAlertID(alertType);

            tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
            if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
            {
                #region Header Detail
                string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                string l1 = "";
                string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());

                if (alertType == enum_Alerts.SheduleAlert_CashSalesNotDeposited)//
                {
                    l1 = "Cash Sales Not Deposited ";
                    sSubject = "SEACC Alert : Cash Sales Not Deposited As At: " + clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + "  "; //todo
                }

                lstEmailDetail.Add(new emailLine(LineType.H1, Name));
                lstEmailDetail.Add(new emailLine(LineType.H2, l1));
                lstEmailDetail.Add(new emailLine(LineType.Line1));
                lstEmailDetail.Add(new emailLine(LineType.H5, clsSecurity.getServerDateTime().ToString()));
                #endregion

                #region Detail Section
                int i = 1;

                foreach (tbl_bpsReceipt oReceipt in tbl_bpsReceipt.SelectAll().Where(p => !p.IsDeleted && p.Receipt_ID != "default" && !p.IsCashDeposited && p.CashAmount > 0 && p.ReceiptDate.Date <= clsSecurity.getServerDateTime().Date).OrderBy(p => p.ReceiptDate))
                {
                    string sCustomer = clsGenaralName.getName_Customer(oReceipt.Customer_ID);
                    string sSalesman = "";
                    string sReceiptNo = oReceipt.Receipt_ID;
                    string sReceiptDate = clsFormatter.FormatDate_Short(oReceipt.ReceiptDate);
                    string sDays = clsCommon.getDaysUptoDate(oReceipt.ReceiptDate).ToString();
                    string sAmount = clsFormatter.FormatDecimalPlaces_Price(oReceipt.CashAmount);
                    tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(oReceipt.OrderRefNo_ID);
                    if (order != null)
                    {
                        sSalesman = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                    }
                    sTotalAmount += oReceipt.CashAmount;

                    tblEmailDetail.Rows.Add(i, sCustomer, sSalesman, sReceiptNo, sReceiptDate, sDays, sAmount);
                    i++;
                }
                tblEmailDetail.Rows.Add("", "", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(sTotalAmount));

                lstEmailDetail.Add(new emailLine(LineType.DataTable, tblEmailDetail, lstEmailDetail));

                #region Footer
                sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                lstEmailDetail.Add(new emailLine(LineType.Line1));
                lstEmailDetail.Add(new emailLine(LineType.Footer1, "Email ID:" + sEmail_ID));
                #endregion

                sBodyHTML = clsEmailConfig.CreateEmailBody(lstEmailDetail);
                #endregion


                #region Send Email
                bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                //tbl_utlAlert_EMail oAlert_Email = new tbl_utlAlert_EMail(sEmail_ID, oAlert.Alert_ID, sSubject, sBodyHTML);
                //oAlert_Email.Insert();
                //foreach (tbl_utlAlertSettings oAlertSetting in tbl_utlAlertSettings.SelectAllByAlert_ID(oAlert.Alert_ID))
                //{
                //    if (oAlertSetting.UserEmail1.Length > 0)
                //        tolist.Add(oAlertSetting.UserEmail1);
                //}
                //bEmailStatus = SendMailHTML("admin", tolist, filelist, sSubject, sBodyHTML, false);
                #endregion
            }
            else
                bEmailStatus = true;

            return bEmailStatus;

        }
        #endregion

        #region D/O Not Invoiced
        public static bool createEmail_DONotInvoiced(enum_Alerts alertType, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    #region Create/Format Email Body
                    DataTable tblEmailHeader = new DataTable();
                    DataTable tblEmailDetail = new DataTable();
                    DataTable tblEmailUND = new DataTable();
                    string sTabKey = System.Convert.ToChar(9).ToString();
                    decimal sTotalAmount = 0;
                    List<string> sPendingCheque = new List<string>();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";// sUser, sBody, sCurrencyCode;

                    // Fill Data for Processing 

                    #region Header
                    tblEmailHeader.Columns.Add("heading");
                    tblEmailHeader.Columns.Add("detail");
                    tblEmailHeader.Columns.Add("DataType");
                    tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()));
                    #endregion

                    #region Detail
                    tblEmailDetail.Columns.Add("# ");
                    tblEmailDetail.Columns.Add("Customer Name");
                    tblEmailDetail.Columns.Add("Salesman Name");
                    tblEmailDetail.Columns.Add("D/O No");
                    tblEmailDetail.Columns.Add("D/O Date");
                    tblEmailDetail.Columns.Add("Days");
                    tblEmailDetail.Columns.Add("D/O Value");
                    tblEmailDetail.Columns.Add("D/O Remark");
                    int i = 1;
                    foreach (tbl_sasDeliveryOrder oDO in tbl_sasDeliveryOrder.SelectAll().Where(p => !p.IsDeleted && p.DeliveryOrder_ID != "default" && !p.IsSeattled && !p.IsReplacementOrder && p.GrandTotal > 0 && p.DeliveryOrderDate.Date <= clsSecurity.getServerDateTime().Date).OrderBy(p => p.DeliveryOrderDate))
                    {

                        string sCustomer = clsGenaralName.getName_Customer(oDO.Customer_ID);
                        string sSalesman = "";
                        string sDeliveryOrderNo = oDO.DeliveryOrder_ID;
                        string sDeliveryOrderDate = clsFormatter.FormatDate_Short(oDO.DeliveryOrderDate);
                        string sDays = clsCommon.getDaysUptoDate(oDO.DeliveryOrderDate).ToString();
                        string sAmount = clsFormatter.FormatDecimalPlaces_Price(oDO.GrandTotal);
                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(oDO.OrderRefNo_ID);

                        if (order != null)
                        {
                            sSalesman = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                        }
                        sTotalAmount += oDO.GrandTotal;

                        tblEmailDetail.Rows.Add(i, sCustomer, sSalesman, sDeliveryOrderNo, sDeliveryOrderDate, sDays, sAmount, oDO.Remark);
                        i++;
                    }
                    tblEmailDetail.Rows.Add("", "", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(sTotalAmount), "");
                    #endregion

                    #region Footer
                    tblEmailUND.Columns.Add("heading");
                    tblEmailUND.Columns.Add("details");
                    tblEmailUND.Columns.Add("DataType");
                    //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");  
                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("", "");
                    #endregion

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    if (alertType == enum_Alerts.SheduleAlert_DONoteInvoiced)//
                    {
                        l1 = "Delivery Order Not Invoiced (Pending Invoices)";
                        sSubject = "SEACC Alert : Delivery Order Not Invoiced As At: " + clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + "  "; //todo
                    }

                    sBodyHTML = CreateEmailBody(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail, tblEmailUND);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    #endregion
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }
        #endregion

        #region Customer Exceeded credit
        public static bool createEmail_CustomerExceededCredit(enum_Alerts alertType, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    #region Create/Format Email Body
                    DataTable tblEmailHeader = new DataTable();
                    DataTable tblEmailDetail = new DataTable();
                    DataTable tblEmailUND = new DataTable();
                    string sTabKey = System.Convert.ToChar(9).ToString();
                    decimal sTotalAmount = 0;
                    List<string> sPendingCheque = new List<string>();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";// sUser, sBody, sCurrencyCode;

                    // Fill Data for Processing 

                    #region Header
                    tblEmailHeader.Columns.Add("heading");
                    tblEmailHeader.Columns.Add("detail");
                    tblEmailHeader.Columns.Add("DataType");
                    tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()));
                    #endregion

                    #region Detail
                    tblEmailDetail.Columns.Add("# ");
                    tblEmailDetail.Columns.Add("Customer Code");
                    tblEmailDetail.Columns.Add("Customer Name");
                    tblEmailDetail.Columns.Add("Salesman Name");
                    tblEmailDetail.Columns.Add("Outstanding Amt");
                    tblEmailDetail.Columns.Add("Cheque In Hand");
                    tblEmailDetail.Columns.Add("Credit Limit");
                    tblEmailDetail.Columns.Add("Credit Risk ");
                    int i = 1;

                    List<tmpCustomerExceededCredit> oTmpExCredits = new List<tmpCustomerExceededCredit>();
                    foreach (tbl_genCustomerMaster oCustomer in tbl_genCustomerMaster.SelectAll().Where(p => !p.IsDeleted && p.Customer_ID != "default"))
                    {
                        tbl_genCustomerFinance oFin = tbl_genCustomerFinance.Select(oCustomer.Customer_ID);
                        if (oFin != null)
                        {
                            decimal dOutstandingAmount = clsMethods_Fin.GetCustomerTotalDues_All(oCustomer.Customer_ID);
                            decimal dChequeInHandAmu = clsMethods_Fin.GetCustomerChequesInHand(oCustomer.Customer_ID);
                            decimal dCreditLimit = oFin.CreditLimit;
                            if (((dOutstandingAmount + dChequeInHandAmu) - dCreditLimit) > 0)
                            {
                                tmpCustomerExceededCredit oTmpExCredit = new tmpCustomerExceededCredit();
                                oTmpExCredit.CustomerCode = oCustomer.Customer_ID;
                                oTmpExCredit.CustomerName = oCustomer.CustomerName;
                                oTmpExCredit.Salesman = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(oCustomer.SalesRep_ID));
                                oTmpExCredit.Creditlimit = dCreditLimit;
                                oTmpExCredit.OutstandingAmu = dOutstandingAmount;
                                oTmpExCredit.ChequeInHandAmu = dChequeInHandAmu;
                                oTmpExCredit.ExceedeAmu = (dOutstandingAmount + dChequeInHandAmu) - dCreditLimit;
                                sTotalAmount += oTmpExCredit.ExceedeAmu;
                                oTmpExCredits.Add(oTmpExCredit);
                            }
                        }
                    }

                    foreach (tmpCustomerExceededCredit oTmpExCredit in oTmpExCredits.OrderByDescending(p => p.ExceedeAmu))
                    {
                        string sCustomerCode = oTmpExCredit.CustomerCode;
                        string sCustomer = oTmpExCredit.CustomerName;
                        string sSalesman = oTmpExCredit.Salesman;
                        string sCreditlimit = clsFormatter.FormatDecimalPlaces_Price(oTmpExCredit.Creditlimit);
                        string sOutstandingAmu = clsFormatter.FormatDecimalPlaces_Price(oTmpExCredit.OutstandingAmu);
                        string sChequeInHandAmu = clsFormatter.FormatDecimalPlaces_Price(oTmpExCredit.ChequeInHandAmu);
                        string sExceedeAmu = clsFormatter.FormatDecimalPlaces_Price(oTmpExCredit.ExceedeAmu);

                        tblEmailDetail.Rows.Add(i, sCustomerCode, sCustomer, sSalesman, sOutstandingAmu, sChequeInHandAmu, sCreditlimit, sExceedeAmu);
                        i++;

                    }
                    tblEmailDetail.Rows.Add("", "", "", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(sTotalAmount));
                    #endregion

                    #region Footer
                    tblEmailUND.Columns.Add("heading");
                    tblEmailUND.Columns.Add("details");
                    tblEmailUND.Columns.Add("DataType");
                    //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");  
                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("", "");
                    #endregion

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    if (alertType == enum_Alerts.SheduleAlert_CustomerExceededCredit)//
                    {
                        l1 = "Customer Exceeded Credit ";
                        sSubject = "SEACC Alert : Customer Exceeded Credit As At: " + clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + "  "; //todo
                    }
                    sBodyHTML = CreateEmailBody(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail, tblEmailUND);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    #endregion
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }
        #endregion

        #region Deposited Cheques Not Realized
        public static bool createEmail_DepositedChequesNotRealized(enum_Alerts alertType, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    #region Create/Format Email Body
                    DataTable tblEmailHeader = new DataTable();
                    DataTable tblEmailDetail = new DataTable();
                    DataTable tblEmailUND = new DataTable();
                    string sTabKey = System.Convert.ToChar(9).ToString();
                    decimal sTotalAmount = 0;
                    List<string> sPendingCheque = new List<string>();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";// string sUser, sBody, sCurrencyCode;

                    // Fill Data for Processing 

                    #region Header
                    tblEmailHeader.Columns.Add("heading");
                    tblEmailHeader.Columns.Add("detail");
                    tblEmailHeader.Columns.Add("DataType");
                    tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()));
                    #endregion

                    #region Detail
                    tblEmailDetail.Columns.Add("# ");
                    tblEmailDetail.Columns.Add("Customer Name");
                    tblEmailDetail.Columns.Add("Salesman Name");
                    tblEmailDetail.Columns.Add("Cheque No");
                    tblEmailDetail.Columns.Add("Cheque Date");
                    tblEmailDetail.Columns.Add("Deposited Date");
                    tblEmailDetail.Columns.Add("Days");
                    tblEmailDetail.Columns.Add("Amount", typeof(decimal));
                    int i = 1;
                    foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAll().Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default" && p.IsDepositted && !p.IsReconcilied && (p.DateDeposited.Date.AddDays(3)) <= clsSecurity.getServerDateTime().Date).OrderBy(p => p.DateCheque))
                    {
                        if (oCheque.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                        {
                            string sCustomer = clsGenaralName.getName_Customer(oCheque.Customer_ID);
                            string sSalesman = "";
                            string sChequeNo = oCheque.ChequeNumber;
                            string sChequeDate = clsFormatter.FormatDate_Short(oCheque.DateCheque);
                            string sDepositedDate = clsFormatter.FormatDate_Short(oCheque.DateDeposited);
                            string sDays = clsCommon.getDaysUptoDate(oCheque.DateDeposited).ToString();
                            string sAmount = clsFormatter.FormatDecimalPlaces_Price(oCheque.Amount);
                            tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(oCheque.OrderRefNo_ID);
                            if (order != null)
                            {
                                sSalesman = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                            }
                            sTotalAmount += oCheque.Amount;

                            tblEmailDetail.Rows.Add(i, sCustomer, sSalesman, sChequeNo, sChequeDate, sDepositedDate, sDays, sAmount);
                            i++;
                        }
                    }
                    tblEmailDetail.Rows.Add("", "", "", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(sTotalAmount));

                    #endregion

                    #region Footer
                    tblEmailUND.Columns.Add("heading");
                    tblEmailUND.Columns.Add("details");
                    tblEmailUND.Columns.Add("DataType");
                    //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");  
                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("", "");
                    #endregion

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    if (alertType == enum_Alerts.SheduleAlert_DepositedChequesNotRealized)
                    {
                        l1 = "Deposited  Cheques Not Realized ";
                        sSubject = "SEACC Alert : Deposited Cheques Not Realized As At: " + clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + "  "; //todo
                    }

                    sBodyHTML = CreateEmailBody(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail, tblEmailUND);
                    #endregion

                    #region Send Email

                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    #endregion
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }
        #endregion

        #region  Unsettle Returned Cheques
        public static bool createEmail_UnsettleReturnedCheques(enum_Alerts alertType, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    #region Create/Format Email Body
                    DataTable tblEmailHeader = new DataTable();
                    DataTable tblEmailDetail = new DataTable();
                    DataTable tblEmailUND = new DataTable();
                    string sTabKey = System.Convert.ToChar(9).ToString();
                    decimal sTotalAmount = 0;
                    List<string> sPendingCheque = new List<string>();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";//sUser, sBody, sCurrencyCode;

                    // Fill Data for Processing 

                    #region Header
                    tblEmailHeader.Columns.Add("heading");
                    tblEmailHeader.Columns.Add("detail");
                    tblEmailHeader.Columns.Add("DataType");
                    tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()));
                    #endregion

                    #region Detail
                    tblEmailDetail.Columns.Add("# ");
                    tblEmailDetail.Columns.Add("Customer Name");
                    tblEmailDetail.Columns.Add("Salesman Name");
                    tblEmailDetail.Columns.Add("Receipt Date & Number");
                    tblEmailDetail.Columns.Add("Cheque Date & Number");
                    tblEmailDetail.Columns.Add("Returned Date");
                    tblEmailDetail.Columns.Add("Days");
                    tblEmailDetail.Columns.Add("Unsettled Amount", typeof(decimal));
                    int i = 1;
                    foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAll().Where(p => !p.IsDeleted && p.Invoice_ID != "default" && p.IsReturnedCheque && !p.IsSeattled))
                    {
                        tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(oInvoice.ChequeRegister_ID);
                        if (oCheque != null && oCheque.ChequeRegister_ID != "default")
                        {
                            if (oCheque.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                            {
                                string sCustomer = clsGenaralName.getName_Customer(oCheque.Customer_ID);
                                string sSalesman = "";
                                string sChequeNo = oCheque.ChequeNumber;
                                string sChequeDate = clsFormatter.FormatDate_Short(oCheque.DateCheque);
                                string sReturnedDate = clsFormatter.FormatDate_Short(oCheque.DateReconcilied);
                                decimal dUnAmu = oInvoice.GrandTotal - oInvoice.SeattleAmount;
                                string sAmount = clsFormatter.FormatDecimalPlaces_Price(dUnAmu);
                                tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(oCheque.OrderRefNo_ID);
                                if (order != null)
                                {
                                    sSalesman = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                                }

                                string sReceiptNo = "", sReceiptDate = "", sDays = "N/A";
                                tbl_bpsReceipt oReceipt = tbl_bpsReceipt.Select(oCheque.Receipt_ID);
                                if (oReceipt != null && oReceipt.Receipt_ID != "default")
                                {
                                    sReceiptNo = oReceipt.Receipt_ID;
                                    sReceiptDate = clsFormatter.FormatDate_Short(oReceipt.ReceiptDate);
                                    sDays = clsCommon.getDaysUptoDate(oReceipt.ReceiptDate).ToString();
                                }
                                sTotalAmount += dUnAmu;

                                tblEmailDetail.Rows.Add(i, sCustomer, sSalesman, sReceiptDate + " / " + sReceiptNo, sChequeDate + " / " + sChequeNo, sReturnedDate, sDays, sAmount);
                            }
                        }
                        i++;
                    }
                    tblEmailDetail.Rows.Add("", "", "", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(sTotalAmount));
                    #endregion

                    #region Footer
                    tblEmailUND.Columns.Add("heading");
                    tblEmailUND.Columns.Add("details");
                    tblEmailUND.Columns.Add("DataType");
                    //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");
                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("Unsettled Amount = ", "R/C Amount - Partly Settled Amount", typeof(decimal));
                    tblEmailUND.Rows.Add("Days = ", "Alert Date - Receipt Date");

                    #endregion

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    if (alertType == enum_Alerts.SheduleAlert_UnsettleReturnedCheques)
                    {
                        l1 = "Unsettle Returned Cheques ";
                        sSubject = "SEACC Alert : Unsettle Returned Cheques As At: " + clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + "  "; //todo
                    }

                    sBodyHTML = CreateEmailBody(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail, tblEmailUND);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    #endregion
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }
        #endregion

        #region InvoicesExceeded Credit Period
        public static bool createEmail_InvoicesExceededCreditPeriod(enum_Alerts alertType, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    #region Create/Format Email Body
                    DataTable tblEmailHeader = new DataTable();
                    DataTable tblEmailDetail = new DataTable();
                    DataTable tblEmailUND = new DataTable();
                    string sTabKey = System.Convert.ToChar(9).ToString();
                    decimal sTotalAmount = 0;
                    List<string> sPendingCheque = new List<string>();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";//sUser, sBody, sCurrencyCode;

                    // Fill Data for Processing 

                    #region Header
                    tblEmailHeader.Columns.Add("heading");
                    tblEmailHeader.Columns.Add("detail");
                    tblEmailHeader.Columns.Add("DataType");
                    tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()));
                    #endregion

                    #region Detail
                    tblEmailDetail.Columns.Add("# ");
                    tblEmailDetail.Columns.Add("Customer Name ");
                    tblEmailDetail.Columns.Add("Invoice No ");
                    tblEmailDetail.Columns.Add("Invoice Date ");
                    tblEmailDetail.Columns.Add("Credit Days");
                    tblEmailDetail.Columns.Add("Overdue Days");
                    tblEmailDetail.Columns.Add("Amount ");
                    int i = 1;

                    List<tmpInvoiceExceededCreditPeriod> oTmpInvoices = new List<tmpInvoiceExceededCreditPeriod>();
                    foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAll().Where(p => !p.IsDeleted && p.Invoice_ID != "default" && !p.IsSeattled))
                    {
                        tbl_genCustomerFinance oFin = tbl_genCustomerFinance.Select(oInvoice.Customer_ID);
                        if (oFin != null)
                        {
                            decimal dDdates = (decimal)clsCommon.getDaysUptoDate(oInvoice.InvoiceDate.Date);
                            if (dDdates > oFin.CreditPeriod)
                            {
                                tmpInvoiceExceededCreditPeriod oTmpInvoice = new tmpInvoiceExceededCreditPeriod();
                                oTmpInvoice.CustomerName = clsGenaralName.getName_Customer(oInvoice.Customer_ID);
                                oTmpInvoice.InvoiceNo = oInvoice.Invoice_ID;
                                oTmpInvoice.InvoiceDate = clsFormatter.FormatDate_Short(oInvoice.InvoiceDate);
                                oTmpInvoice.CreditPeriod = oFin.CreditPeriod;
                                oTmpInvoice.Days = dDdates - oFin.CreditPeriod;
                                oTmpInvoice.Amount = oInvoice.GrandTotal - oInvoice.SeattleAmount;
                                oTmpInvoices.Add(oTmpInvoice);
                            }
                        }
                    }

                    foreach (tmpInvoiceExceededCreditPeriod oTmpInvoice in oTmpInvoices.OrderByDescending(p => p.Days))
                    {
                        string sCustomer = oTmpInvoice.CustomerName;
                        string sInvoicceNo = oTmpInvoice.InvoiceNo;
                        string sinvoiceDate = oTmpInvoice.InvoiceDate;
                        string sCustCreditPeriod = clsFormatter.FormatToNumberNoDecimal(oTmpInvoice.CreditPeriod);
                        decimal dDateDiff = oTmpInvoice.Days;
                        string sAmount = clsFormatter.FormatDecimalPlaces_Price(oTmpInvoice.Amount);
                        sTotalAmount += oTmpInvoice.Amount;
                        tblEmailDetail.Rows.Add(i, sCustomer, sInvoicceNo, sinvoiceDate, sCustCreditPeriod, dDateDiff, sAmount);
                        i++;
                    }

                    tblEmailDetail.Rows.Add("", "", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(sTotalAmount));
                    #endregion

                    #region Footer
                    tblEmailUND.Columns.Add("heading");
                    tblEmailUND.Columns.Add("details");
                    tblEmailUND.Columns.Add("DataType");
                    //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");  
                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("", "");
                    #endregion

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    if (alertType == enum_Alerts.StatusAlert_InvoicesExceededCreditPeriod)//
                    {
                        l1 = "Invoices Exceeded Credit Period ";
                        sSubject = "SEACC Alert : Invoices Exceeded Credit Period As At: " + clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + "  "; //todo
                    }
                    sBodyHTML = CreateEmailBody(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail, tblEmailUND);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    #endregion
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }
        #endregion

        #region  Daily Status General
        public static bool createEmail_DailyStatusAlert_Genaral(enum_Alerts alertType, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    #region Create/Format Email Body
                    DataTable tblEmailHeader = new DataTable();
                    DataTable tblEmailDetail1 = new DataTable();
                    DataTable tblEmailDetail2 = new DataTable();
                    DataTable tblEmailDetail3 = new DataTable();
                    DataTable tblEmailDetail4 = new DataTable();
                    DataTable tblEmailDetail5 = new DataTable();
                    DataTable tblEmailUND = new DataTable();
                    string sTabKey = System.Convert.ToChar(9).ToString();

                    List<string> sPendingCheque = new List<string>();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";

                    // Fill Data for Processing 

                    #region Header
                    tblEmailHeader.Columns.Add("heading");
                    tblEmailHeader.Columns.Add("detail");
                    tblEmailHeader.Columns.Add("DataType");
                    tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()));
                    #endregion

                    #region Detail
                    tblEmailDetail1.Columns.Add("Sales Details");
                    tblEmailDetail1.Columns.Add("For The Day", typeof(decimal));
                    tblEmailDetail1.Columns.Add("For The Month", typeof(decimal));

                    // int i = 1;
                    DateTime dtNow = clsSecurity.getServerDateTime();
                    decimal dNetSales_ForTheDay = 0, dNetSales_ForTheMonth = 0, dDebitValue_ForTheDay = 0, dDebitValue_ForTheMonth = 0, dCreditNote_Value_ForTheMonth = 0, dCreditNote_Value_ForTheDay = 0;
                    clsMethods_Fin.assingValues_NetSalesAndDebitValue(ref dNetSales_ForTheDay, ref dNetSales_ForTheMonth, ref dDebitValue_ForTheDay, ref dDebitValue_ForTheMonth, dtNow, "default");
                    clsMethods_Fin.assingValues_CreditNote_WithoutTaxes(ref dCreditNote_Value_ForTheMonth, ref dCreditNote_Value_ForTheDay, dtNow, "default");
                    tblEmailDetail1.Rows.Add("Net Sales Value (Without Taxes)", clsFormatter.FormatDecimalPlaces_Price(dNetSales_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dNetSales_ForTheMonth));
                    tblEmailDetail1.Rows.Add("Debit Note Value (Without Taxes)", clsFormatter.FormatDecimalPlaces_Price(dDebitValue_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dDebitValue_ForTheMonth));
                    tblEmailDetail1.Rows.Add("Credit Note Value (Without Taxes)", clsFormatter.FormatDecimalPlaces_Price(dCreditNote_Value_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dCreditNote_Value_ForTheMonth));
                    decimal dSales_ForTheDay = (dNetSales_ForTheDay + dDebitValue_ForTheDay) - dCreditNote_Value_ForTheDay;
                    decimal dSales_ForTheMonth = (dNetSales_ForTheMonth + dDebitValue_ForTheMonth) - dCreditNote_Value_ForTheMonth;
                    tblEmailDetail1.Rows.Add("", clsFormatter.FormatDecimalPlaces_Price(dSales_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dSales_ForTheMonth));

                    tblEmailDetail2.Columns.Add("Collection Detail");
                    tblEmailDetail2.Columns.Add("For The Day", typeof(decimal));
                    tblEmailDetail2.Columns.Add("For The Month", typeof(decimal));
                    decimal dReceipt_Cash_ForTheDay = 0, dReceipt_Cash_ForTheMonth = 0, dReceipt_Cheque_ForTheDay = 0, dReceipt_Cheque_ForTheMonth = 0;
                    clsMethods_Fin.assingValues_Collection(ref dReceipt_Cash_ForTheDay, ref dReceipt_Cash_ForTheMonth, ref dReceipt_Cheque_ForTheDay, ref dReceipt_Cheque_ForTheMonth, dtNow, "default");
                    tblEmailDetail2.Rows.Add("Cash Collection", clsFormatter.FormatDecimalPlaces_Price(dReceipt_Cash_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dReceipt_Cash_ForTheMonth));
                    tblEmailDetail2.Rows.Add("Cheque Collection", clsFormatter.FormatDecimalPlaces_Price(dReceipt_Cheque_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dReceipt_Cheque_ForTheMonth));
                    decimal dCollection_ForTheDay = dReceipt_Cash_ForTheDay + dReceipt_Cheque_ForTheDay;
                    decimal dCollection_ForTheMonth = dReceipt_Cash_ForTheMonth + dReceipt_Cheque_ForTheMonth;
                    tblEmailDetail2.Rows.Add("", clsFormatter.FormatDecimalPlaces_Price(dCollection_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dCollection_ForTheMonth));

                    tblEmailDetail3.Columns.Add("Bank Reconciliation");
                    tblEmailDetail3.Columns.Add("For The Day", typeof(decimal));
                    tblEmailDetail3.Columns.Add("For The Month", typeof(decimal));
                    decimal dReturned_Cheque_ForTheDay = 0, dReturned_Cheque_ForTheMonth = 0, dRealized_Cheque_ForTheDay = 0, dRealized_Cheque_ForTheMonth = 0, dDeposit_Cheque_ForTheDay = 0, dDeposit_Cheque_ForTheMonth = 0, dDeposit_Cash_ForTheDay = 0, dDeposit_Cash_ForTheMonth = 0;
                    clsMethods_Fin.assingValues_ChequeReconcile(ref dReturned_Cheque_ForTheDay, ref dReturned_Cheque_ForTheMonth, ref dRealized_Cheque_ForTheDay, ref dRealized_Cheque_ForTheMonth, dtNow, "default");
                    clsMethods_Fin.assingValues_ChequeDeposit(ref dDeposit_Cheque_ForTheDay, ref dDeposit_Cheque_ForTheMonth, dtNow, "default");
                    clsMethods_Fin.assingValues_CashDeposit(ref dDeposit_Cash_ForTheDay, ref dDeposit_Cash_ForTheMonth, dtNow);
                    tblEmailDetail3.Rows.Add("Cheque(s) Deposited in Bank(s)", clsFormatter.FormatDecimalPlaces_Price(dDeposit_Cheque_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dDeposit_Cheque_ForTheMonth));
                    tblEmailDetail3.Rows.Add("Cheque(s) Returns", clsFormatter.FormatDecimalPlaces_Price(dReturned_Cheque_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dReturned_Cheque_ForTheMonth));
                    tblEmailDetail3.Rows.Add("Cash Deposited in Bank(s)", clsFormatter.FormatDecimalPlaces_Price(dDeposit_Cash_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dDeposit_Cash_ForTheMonth));
                    tblEmailDetail3.Rows.Add("Cheque Realized in Bank(s)", clsFormatter.FormatDecimalPlaces_Price(dRealized_Cheque_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dRealized_Cheque_ForTheMonth));

                    tblEmailDetail4.Columns.Add("Outstanding Detail");
                    tblEmailDetail4.Columns.Add("Amount", typeof(decimal));
                    decimal dChequeInHand = 0, dTotalOutstanding = 0, dTotalOutstandingOver90 = 0, dDepositedButUnrealized = 0, dHoldingCheques = 0;
                    clsMethods_Fin.assingValues_Outstanding(ref dChequeInHand, ref dTotalOutstanding, ref dTotalOutstandingOver90, ref dDepositedButUnrealized, ref dHoldingCheques, "default");
                    tblEmailDetail4.Rows.Add("Notes Receivables (Invoice + DebitNote)", clsFormatter.FormatDecimalPlaces_Price(dTotalOutstanding));
                    tblEmailDetail4.Rows.Add("Cheque In Hand (PD Cheques)", clsFormatter.FormatDecimalPlaces_Price(dChequeInHand));
                    tblEmailDetail4.Rows.Add("", clsFormatter.FormatDecimalPlaces_Price(dChequeInHand + dTotalOutstanding));

                    tblEmailDetail5.Columns.Add("Financial Detail");
                    tblEmailDetail5.Columns.Add("Amount", typeof(decimal));
                    tblEmailDetail5.Rows.Add("Debtors Outstanding (Over 30 Days)", clsFormatter.FormatDecimalPlaces_Price(dTotalOutstandingOver90));
                    tblEmailDetail5.Rows.Add("Cheque In Hand (Not-Deposited) (On-Hold)", clsFormatter.FormatDecimalPlaces_Price(dHoldingCheques));
                    tblEmailDetail5.Rows.Add("Cheque In Hand (Not-Reconciled)", clsFormatter.FormatDecimalPlaces_Price(dDepositedButUnrealized));
                    #endregion

                    #region Footer
                    tblEmailUND.Columns.Add("heading");
                    tblEmailUND.Columns.Add("details");
                    tblEmailUND.Columns.Add("DataType");
                    //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");
                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("Without Taxes = ", "Total Value - (VAT + NBT)");
                    #endregion

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    //string l1 = "Daily Status Report";
                    string l1 = "Financial Transactions";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    if (alertType == enum_Alerts.SheduleAlert_DailyStatusAlert_Gen)
                    {
                        //l1 = "Daily Status Report ";
                        //sSubject = "SEACC Alert : Daily Status Report As At: " + clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + "  "; //todo
                        l1 = "Financial Transactions ";
                        sSubject = "SEACC Alert : Financial Transactions As At: " + clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + "  "; //todo
                    }

                    sBodyHTML = CreateEmailBody_GenearlStatus(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail1, tblEmailDetail2, tblEmailDetail3, tblEmailDetail4, tblEmailDetail5, tblEmailUND);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    //tbl_utlAlert_EMail oAlert_Email = new tbl_utlAlert_EMail(sEmail_ID, oAlert.Alert_ID, sSubject, sBodyHTML);
                    //oAlert_Email.Insert();
                    //foreach (tbl_utlAlertSettings oAlertSetting in tbl_utlAlertSettings.SelectAllByAlert_ID(oAlert.Alert_ID))
                    //{
                    //    if (oAlertSetting.UserEmail1.Length > 0)
                    //        tolist.Add(oAlertSetting.UserEmail1);
                    //}
                    //bEmailStatus = SendMailHTML("admin", tolist, filelist, sSubject, sBodyHTML, false);
                    #endregion
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }

        public static bool createEmail_DailyStatusAlert_BranchWise(enum_Alerts alertType, string sBranch_ID)
        {
            bool bEmailStatus = false;

            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    #region Create/Format Email Body
                    DataTable tblEmailHeader = new DataTable();
                    DataTable tblEmailDetail1 = new DataTable();
                    DataTable tblEmailDetail2 = new DataTable();
                    DataTable tblEmailDetail3 = new DataTable();
                    DataTable tblEmailDetail4 = new DataTable();
                    DataTable tblEmailDetail5 = new DataTable();
                    DataTable tblEmailUND = new DataTable();
                    string sTabKey = System.Convert.ToChar(9).ToString();

                    List<string> sPendingCheque = new List<string>();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";

                    // Fill Data for Processing 

                    #region Header
                    tblEmailHeader.Columns.Add("heading");
                    tblEmailHeader.Columns.Add("detail");
                    tblEmailHeader.Columns.Add("DataType");
                    tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()));
                    #endregion

                    #region Detail
                    tblEmailDetail1.Columns.Add("Sales Details");
                    tblEmailDetail1.Columns.Add("For The Day");
                    tblEmailDetail1.Columns.Add("For The Month");

                    //  int i = 1;
                    DateTime dtNow = clsSecurity.getServerDateTime();
                    decimal dNetSales_ForTheDay = 0, dNetSales_ForTheMonth = 0, dDebitValue_ForTheDay = 0, dDebitValue_ForTheMonth = 0, dCreditNote_Value_ForTheMonth = 0, dCreditNote_Value_ForTheDay = 0;

                    clsMethods_Fin.assingValues_NetSalesAndDebitValue(ref dNetSales_ForTheDay, ref dNetSales_ForTheMonth, ref dDebitValue_ForTheDay, ref dDebitValue_ForTheMonth, dtNow, sBranch_ID);
                    clsMethods_Fin.assingValues_CreditNote_WithoutTaxes(ref dCreditNote_Value_ForTheMonth, ref dCreditNote_Value_ForTheDay, dtNow, sBranch_ID);
                    tblEmailDetail1.Rows.Add("Net Sales Value (Without Taxes)", clsFormatter.FormatDecimalPlaces_Price(dNetSales_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dNetSales_ForTheMonth));
                    tblEmailDetail1.Rows.Add("Debit Note Value (Without Taxes)", clsFormatter.FormatDecimalPlaces_Price(dDebitValue_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dDebitValue_ForTheMonth));
                    tblEmailDetail1.Rows.Add("Credit Note Value (Without Taxes)", clsFormatter.FormatDecimalPlaces_Price(dCreditNote_Value_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dCreditNote_Value_ForTheMonth));
                    decimal dSales_ForTheDay = (dNetSales_ForTheDay + dDebitValue_ForTheDay) - dCreditNote_Value_ForTheDay;
                    decimal dSales_ForTheMonth = (dNetSales_ForTheMonth + dDebitValue_ForTheMonth) - dCreditNote_Value_ForTheMonth;
                    tblEmailDetail1.Rows.Add("", clsFormatter.FormatDecimalPlaces_Price(dSales_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dSales_ForTheMonth));

                    tblEmailDetail2.Columns.Add("Collection Detail");
                    tblEmailDetail2.Columns.Add("For The Day");
                    tblEmailDetail2.Columns.Add("For The Month");
                    decimal dReceipt_Cash_ForTheDay = 0, dReceipt_Cash_ForTheMonth = 0, dReceipt_Cheque_ForTheDay = 0, dReceipt_Cheque_ForTheMonth = 0;

                    clsMethods_Fin.assingValues_Collection(ref dReceipt_Cash_ForTheDay, ref dReceipt_Cash_ForTheMonth, ref dReceipt_Cheque_ForTheDay, ref dReceipt_Cheque_ForTheMonth, dtNow, sBranch_ID);
                    tblEmailDetail2.Rows.Add("Cash Collection", clsFormatter.FormatDecimalPlaces_Price(dReceipt_Cash_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dReceipt_Cash_ForTheMonth));
                    tblEmailDetail2.Rows.Add("Cheque Collection", clsFormatter.FormatDecimalPlaces_Price(dReceipt_Cheque_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dReceipt_Cheque_ForTheMonth));
                    decimal dCollection_ForTheDay = dReceipt_Cash_ForTheDay + dReceipt_Cheque_ForTheDay;
                    decimal dCollection_ForTheMonth = dReceipt_Cash_ForTheMonth + dReceipt_Cheque_ForTheMonth;
                    tblEmailDetail2.Rows.Add("", clsFormatter.FormatDecimalPlaces_Price(dCollection_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dCollection_ForTheMonth));

                    tblEmailDetail3.Columns.Add("Bank Reconciliation");
                    tblEmailDetail3.Columns.Add("For The Day");
                    tblEmailDetail3.Columns.Add("For The Month");
                    decimal dReturned_Cheque_ForTheDay = 0, dReturned_Cheque_ForTheMonth = 0, dRealized_Cheque_ForTheDay = 0, dRealized_Cheque_ForTheMonth = 0, dDeposit_Cheque_ForTheDay = 0, dDeposit_Cheque_ForTheMonth = 0, dDeposit_Cash_ForTheDay = 0, dDeposit_Cash_ForTheMonth = 0;

                    clsMethods_Fin.assingValues_ChequeReconcile(ref dReturned_Cheque_ForTheDay, ref dReturned_Cheque_ForTheMonth, ref dRealized_Cheque_ForTheDay, ref dRealized_Cheque_ForTheMonth, dtNow, sBranch_ID);
                    clsMethods_Fin.assingValues_ChequeDeposit(ref dDeposit_Cheque_ForTheDay, ref dDeposit_Cheque_ForTheMonth, dtNow, sBranch_ID);
                    clsMethods_Fin.assingValues_CashDeposit(ref dDeposit_Cash_ForTheDay, ref dDeposit_Cash_ForTheMonth, dtNow, sBranch_ID);
                    tblEmailDetail3.Rows.Add("Cheque(s) Deposited in Bank(s)", clsFormatter.FormatDecimalPlaces_Price(dDeposit_Cheque_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dDeposit_Cheque_ForTheMonth));
                    tblEmailDetail3.Rows.Add("Cheque(s) Returns", clsFormatter.FormatDecimalPlaces_Price(dReturned_Cheque_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dReturned_Cheque_ForTheMonth));
                    tblEmailDetail3.Rows.Add("Cash Deposited in Bank(s)", clsFormatter.FormatDecimalPlaces_Price(dDeposit_Cash_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dDeposit_Cash_ForTheMonth));
                    tblEmailDetail3.Rows.Add("Cheque Realized in Bank(s)", clsFormatter.FormatDecimalPlaces_Price(dRealized_Cheque_ForTheDay), clsFormatter.FormatDecimalPlaces_Price(dRealized_Cheque_ForTheMonth));

                    tblEmailDetail4.Columns.Add("Outstanding Detail");
                    tblEmailDetail4.Columns.Add("Amount", typeof(decimal));
                    decimal dChequeInHand = 0, dTotalOutstanding = 0, dTotalOutstandingOver90 = 0, dDepositedButUnrealized = 0, dHoldingCheques = 0;

                    clsMethods_Fin.assingValues_Outstanding(ref dChequeInHand, ref dTotalOutstanding, ref dTotalOutstandingOver90, ref dDepositedButUnrealized, ref dHoldingCheques, sBranch_ID);
                    tblEmailDetail4.Rows.Add("Notes Receivables (Invoice + DebitNote)", clsFormatter.FormatDecimalPlaces_Price(dTotalOutstanding));
                    tblEmailDetail4.Rows.Add("Cheque In Hand (PD Cheques)", clsFormatter.FormatDecimalPlaces_Price(dChequeInHand));
                    tblEmailDetail4.Rows.Add("", clsFormatter.FormatDecimalPlaces_Price(dChequeInHand + dTotalOutstanding));

                    tblEmailDetail5.Columns.Add("Financial Detail");
                    tblEmailDetail5.Columns.Add("Amount", typeof(decimal));
                    tblEmailDetail5.Rows.Add("Debtors Outstanding (Over 30 Days)", clsFormatter.FormatDecimalPlaces_Price(dTotalOutstandingOver90));
                    tblEmailDetail5.Rows.Add("Cheque In Hand (Not-Deposited) (On-Hold)", clsFormatter.FormatDecimalPlaces_Price(dHoldingCheques));
                    tblEmailDetail5.Rows.Add("Cheque In Hand (Not-Reconciled)", clsFormatter.FormatDecimalPlaces_Price(dDepositedButUnrealized));
                    #endregion

                    #region Footer
                    tblEmailUND.Columns.Add("heading");
                    tblEmailUND.Columns.Add("details");
                    tblEmailUND.Columns.Add("DataType");
                    //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");
                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("Without Taxes = ", "Total Value - (VAT + NBT)");
                    #endregion

                    string Name = clsSecurity.CompanyName + " - " + clsGenaralName.getName_CompanyBranchMaster(sBranch_ID);
                    //string l1 = "Daily Status Report";
                    string l1 = "Financial Transactions";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    if (alertType == enum_Alerts.SheduleAlert_DailyStatusAlert_Gen)
                    {
                        //l1 = "Daily Status Report ";
                        l1 = "Financial Transactions ";
                        //sSubject = "SEACC Alert : Daily Status Report [" +clsGenaralName.getName_CompanyBranchMaster( sBranch_ID )+ "] As At: " + clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + "  "; //todo
                        sSubject = "SEACC Alert : Financial Transactions [" + clsGenaralName.getName_CompanyBranchMaster(sBranch_ID) + "] As At: " + clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + "  "; //todo
                    }

                    sBodyHTML = CreateEmailBody_GenearlStatus(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail1, tblEmailDetail2, tblEmailDetail3, tblEmailDetail4, tblEmailDetail5, tblEmailUND);
                    #endregion

                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }
        #endregion

        #region  Invoice Summary
        public static bool createEmail_InvoiceSummary(enum_Alerts alertType, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    #region Create/Format Email Body
                    DataTable tblEmailHeader = new DataTable();
                    DataTable tblEmailDetail = new DataTable();
                    DataTable tblEmailUND = new DataTable();
                    string sTabKey = System.Convert.ToChar(9).ToString();
                    decimal dTotalAmount = 0, dTotalAmountGroup = 0;
                    List<string> sPendingCheque = new List<string>();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";//sUser, sBody, sCurrencyCode;

                    // Fill Data for Processing 

                    #region Header
                    tblEmailHeader.Columns.Add("heading");
                    tblEmailHeader.Columns.Add("detail");
                    tblEmailHeader.Columns.Add("DataType");
                    tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()));
                    #endregion

                    #region Detail
                    tblEmailDetail.Columns.Add("# ");
                    tblEmailDetail.Columns.Add("Invoice No");
                    tblEmailDetail.Columns.Add("Customer Name");
                    tblEmailDetail.Columns.Add("Salesman Name");
                    tblEmailDetail.Columns.Add("Invoice Date");
                    tblEmailDetail.Columns.Add("Invoice Amount");
                    int i = 1;
                    string sOldInvoiceType = "";
                    bool bAddGroupTotal = false;
                    List<string> sBackDatedInvoiceList = new List<string>();
                    foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAll().Where(p => !p.IsDeleted && p.Invoice_ID != "default" && p.DateCreate.Date == clsSecurity.getServerDateTime().Date && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque).OrderBy(p => p.Invoice_ID))
                    {
                        tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                        if (oCustomer != null)
                        {
                            string sCustomer = oCustomer.CustomerName, sInvoiceType = "";
                            string sSalesman = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesRep(oCustomer.SalesRep_ID));
                            string sAmount = clsFormatter.FormatDecimalPlaces_Price(oInvoice.GrandTotal);
                            dTotalAmount += oInvoice.GrandTotal;

                            if (oInvoice.InvoiceDate.Date == clsSecurity.getServerDateTime().Date)
                            {
                                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                {
                                    #region AKT Customer
                                    if (oInvoice.Quotation_ID != "default")
                                    {
                                        sInvoiceType = "Block Sales";
                                    }
                                    else if (oInvoice.DeliveryOrder_ID != "default" && oInvoice.Job_ID == "default")
                                    {
                                        sInvoiceType = "Direct Sales";
                                    }
                                    else if (oInvoice.Job_ID != "default")
                                    {
                                        tbl_pmsProductionJobRegister oJob = tbl_pmsProductionJobRegister.Select(oInvoice.Job_ID);
                                        if (oJob != null)
                                        {
                                            sInvoiceType = clsGenaralName.getName_ProductionJobType(oJob.ProductionJobType_ID);
                                        }
                                    }
                                    #endregion
                                }
                                else
                                {
                                    if (clsConfig.bSalesNoteType_SerialNoActiveFor_Invoice)
                                        sInvoiceType = clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID);
                                    else
                                        sInvoiceType = (oInvoice.IsVatInvoice) ? "Vat Invoice" : (oInvoice.IsSVatInvoice) ? "SVat Invoice" : "Non Tax Invoice";
                                }

                                if (sInvoiceType != sOldInvoiceType)
                                {
                                    if (i == 1)
                                    {
                                        bAddGroupTotal = true;
                                        dTotalAmountGroup += oInvoice.GrandTotal;
                                        tblEmailDetail.Rows.Add("", "", sInvoiceType, "", "", "");
                                        tblEmailDetail.Rows.Add(i, oInvoice.Invoice_ID, sCustomer, sSalesman, clsFormatter.FormatDate_Short(oInvoice.InvoiceDate), sAmount);
                                        i++;
                                    }
                                    else
                                    {
                                        tblEmailDetail.Rows.Add("", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(dTotalAmountGroup));
                                        tblEmailDetail.Rows.Add("", "", sInvoiceType, "", "", "");
                                        tblEmailDetail.Rows.Add(i, oInvoice.Invoice_ID, sCustomer, sSalesman, clsFormatter.FormatDate_Short(oInvoice.InvoiceDate), sAmount);
                                        i++;
                                        dTotalAmountGroup = 0;
                                        dTotalAmountGroup += oInvoice.GrandTotal;
                                        bAddGroupTotal = true;
                                    }
                                }
                                else
                                {
                                    bAddGroupTotal = true;
                                    tblEmailDetail.Rows.Add(i, oInvoice.Invoice_ID, sCustomer, sSalesman, clsFormatter.FormatDate_Short(oInvoice.InvoiceDate), sAmount);
                                    i++;
                                    dTotalAmountGroup += oInvoice.GrandTotal;
                                }
                                sOldInvoiceType = sInvoiceType;
                            }
                            else
                            {
                                sBackDatedInvoiceList.Add(oInvoice.Invoice_ID);
                            }
                        }
                    }
                    if (bAddGroupTotal)
                        tblEmailDetail.Rows.Add("", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(dTotalAmountGroup));

                    if (sBackDatedInvoiceList.Count > 0)
                        tblEmailDetail.Rows.Add("", "", "*** Back Date Invoice List", "", "", "");
                    foreach (string sInvoiceID in sBackDatedInvoiceList)
                    {
                        tbl_sasInvoice oInvoiceBackDated = tbl_sasInvoice.Select(sInvoiceID);
                        if (oInvoiceBackDated != null && oInvoiceBackDated.Invoice_ID != "default")
                        {
                            tbl_genCustomerMaster oCustomerBackDated = tbl_genCustomerMaster.Select(oInvoiceBackDated.Customer_ID);
                            if (oCustomerBackDated != null)
                            {
                                tblEmailDetail.Rows.Add(i, oInvoiceBackDated.Invoice_ID, oCustomerBackDated.CustomerName, clsGenaralName.getName_SalesRep(oCustomerBackDated.SalesRep_ID), clsFormatter.FormatDate_Short(oInvoiceBackDated.InvoiceDate), clsFormatter.FormatDecimalPlaces_Price(oInvoiceBackDated.GrandTotal));
                                i++;
                            }
                        }
                    }
                    tblEmailDetail.Rows.Add("", "", "Total Amount", "", "", clsFormatter.FormatDecimalPlaces_Price(dTotalAmount));
                    #endregion

                    #region Footer
                    tblEmailUND.Columns.Add("heading");
                    tblEmailUND.Columns.Add("details");
                    tblEmailUND.Columns.Add("DataType");
                    //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");
                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("", "");
                    #endregion

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    if (alertType == enum_Alerts.SheduleAlert_InvoiceSummary)
                    {
                        l1 = "Invoice Summary ";
                        sSubject = "SEACC Alert : Invoice Summary As At: " + clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + "  "; //todo
                    }

                    sBodyHTML = CreateEmailBody(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail, tblEmailUND);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    //tbl_utlAlert_EMail oAlert_Email = new tbl_utlAlert_EMail(sEmail_ID, oAlert.Alert_ID, sSubject, sBodyHTML);
                    //oAlert_Email.Insert();
                    //foreach (tbl_utlAlertSettings oAlertSetting in tbl_utlAlertSettings.SelectAllByAlert_ID(oAlert.Alert_ID))
                    //{
                    //    if (oAlertSetting.UserEmail1.Length > 0)
                    //        tolist.Add(oAlertSetting.UserEmail1);
                    //}
                    //bEmailStatus = SendMailHTML("admin", tolist, filelist, sSubject, sBodyHTML, false);
                    #endregion
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }

        public static bool createEmail_InvoiceSummary1(enum_Alerts alertType)
        {

            bool bEmailStatus = false;
            string sAlertID = clsAutocode.getAlertID(alertType);

            tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
            if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
            {
                ArrayList tolist = new ArrayList();
                ArrayList filelist = new ArrayList();
                string sBodyHTML, sSubject = "", sAlertDate = "";//sUser, sBody,sCurrencyCode = "",
                string sTabKey = System.Convert.ToChar(9).ToString();
                decimal dTotalAmount = 0, dTotalAmountGroup = 0;
                sAlertDate = clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime());

                List<emailLine> lstEmailDetail = new List<emailLine>();
                EmailLineformating oEmailLineFormat = new EmailLineformating();

                int i = 1;
                string sOldInvoiceType = "";
                bool bAddGroupTotal = false;
                List<string> sBackDatedInvoiceList = new List<string>();


                DataTable tblEmailDetail = new DataTable();
                tblEmailDetail.Columns.Add("#");
                tblEmailDetail.Columns.Add("Invoice No");
                tblEmailDetail.Columns.Add("Customer Name");
                tblEmailDetail.Columns.Add("Salesman Name");
                tblEmailDetail.Columns.Add("Invoice Date");
                tblEmailDetail.Columns.Add("Invoice Amount", typeof(decimal));

                //   string sItemCode = "", sItemName = "", sQty = "", sUnitPrice = "";

                string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                string l1 = "";
                string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                if (alertType == enum_Alerts.SheduleAlert_InvoiceSummary)
                {
                    l1 = "Invoice Summary ";
                    sSubject = "SEACC Alert : Invoice Summary As At: " + clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + "  "; //todo
                }


                #region Header Detail
                lstEmailDetail.Add(new emailLine(LineType.H1, clsSecurity.CompanyName));
                lstEmailDetail.Add(new emailLine(LineType.H2, l1));
                lstEmailDetail.Add(new emailLine(LineType.Line1));
                #endregion


                foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAll().Where(p => !p.IsDeleted && p.DateCreate.Date == clsSecurity.getServerDateTime().Date && p.Invoice_ID != "default" && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque).OrderBy(p => p.Job_ID))
                {

                    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oInvoice.Customer_ID);
                    if (oCustomer != null)
                    {
                        string sCustomer = oCustomer.CustomerName, sInvoiceType = "";
                        string sSalesman = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesRep(oCustomer.SalesRep_ID));
                        string sAmount = clsFormatter.FormatDecimalPlaces_Price(oInvoice.GrandTotal);
                        dTotalAmount += oInvoice.GrandTotal;

                        if (oInvoice.InvoiceDate.Date == clsSecurity.getServerDateTime().Date)
                        {
                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                            {
                                #region AKT Customer
                                if (oInvoice.Quotation_ID != "default")
                                {
                                    sInvoiceType = "Block Sales";
                                }
                                else if (oInvoice.DeliveryOrder_ID != "default" && oInvoice.Job_ID == "default")
                                {
                                    sInvoiceType = "Direct Sales";
                                }
                                else if (oInvoice.Job_ID != "default")
                                {
                                    tbl_pmsProductionJobRegister oJob = tbl_pmsProductionJobRegister.Select(oInvoice.Job_ID);
                                    if (oJob != null)
                                    {
                                        sInvoiceType = clsGenaralName.getName_ProductionJobType(oJob.ProductionJobType_ID);
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                if (clsConfig.bSalesNoteType_SerialNoActiveFor_Invoice)
                                    sInvoiceType = clsGenaralName.getName_SalesNoteType(oInvoice.SalesNoteType_ID);
                                else
                                    sInvoiceType = (oInvoice.IsVatInvoice) ? "Vat Invoice" : (oInvoice.IsSVatInvoice) ? "SVat Invoice" : "Non Tax Invoice";
                            }

                            if (sInvoiceType != sOldInvoiceType)
                            {
                                if (i == 1)
                                {
                                    bAddGroupTotal = true;
                                    dTotalAmountGroup += oInvoice.GrandTotal;

                                    tblEmailDetail.Rows.Add(i, oInvoice.Invoice_ID, sCustomer, sSalesman, clsFormatter.FormatDate_Short(oInvoice.InvoiceDate), sAmount);
                                    //tblEmailDetail.Rows.Add(i, oInvoice.Invoice_ID, sCustomer, sSalesman, clsFormatter.FormatDate_Short(oInvoice.InvoiceDate), sAmount);
                                    i++;
                                }
                                else
                                {
                                    tblEmailDetail.Rows.Add("", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(dTotalAmountGroup));
                                    tblEmailDetail.Rows.Add("", "", sInvoiceType, "", "", "");
                                    tblEmailDetail.Rows.Add(i, oInvoice.Invoice_ID, sCustomer, sSalesman, clsFormatter.FormatDate_Short(oInvoice.InvoiceDate), sAmount);
                                    i++;
                                    dTotalAmountGroup = 0;
                                    dTotalAmountGroup += oInvoice.GrandTotal;
                                    bAddGroupTotal = true;
                                }
                            }
                            else
                            {
                                bAddGroupTotal = true;
                                tblEmailDetail.Rows.Add(i, oInvoice.Invoice_ID, sCustomer, sSalesman, clsFormatter.FormatDate_Short(oInvoice.InvoiceDate), sAmount);
                                i++;
                                dTotalAmountGroup += oInvoice.GrandTotal;
                            }
                            sOldInvoiceType = sInvoiceType;
                        }
                        else
                        {
                            sBackDatedInvoiceList.Add(oInvoice.Invoice_ID);
                        }
                    }
                }

                if (bAddGroupTotal)
                    tblEmailDetail.Rows.Add("", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(dTotalAmountGroup));

                if (sBackDatedInvoiceList.Count > 0)
                    tblEmailDetail.Rows.Add("", "", "*** Back Date Invoice List", "", "", "");

                foreach (string sInvoiceID in sBackDatedInvoiceList)
                {
                    tbl_sasInvoice oInvoiceBackDated = tbl_sasInvoice.Select(sInvoiceID);
                    if (oInvoiceBackDated != null && oInvoiceBackDated.Invoice_ID != "default")
                    {
                        tbl_genCustomerMaster oCustomerBackDated = tbl_genCustomerMaster.Select(oInvoiceBackDated.Customer_ID);
                        if (oCustomerBackDated != null)
                        {
                            tblEmailDetail.Rows.Add(i, oInvoiceBackDated.Invoice_ID, oCustomerBackDated.CustomerName, clsGenaralName.getName_SalesRep(oCustomerBackDated.SalesRep_ID), clsFormatter.FormatDate_Short(oInvoiceBackDated.InvoiceDate), clsFormatter.FormatDecimalPlaces_Price(oInvoiceBackDated.GrandTotal));
                            i++;
                        }
                    }
                }

                tblEmailDetail.Rows.Add("", "", "Total Amount", "", "", clsFormatter.FormatDecimalPlaces_Price(dTotalAmount));

                lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "#"));
                lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Invoice No"));
                lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Customer Name"));
                lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Salesman Name"));
                lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Invoice Date"));
                lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Invoice Amount"));

                lstEmailDetail.Add(new emailLine(LineType.DataTable, tblEmailDetail, lstEmailDetail));
                sBodyHTML = clsEmailConfig.CreateEmailBody(lstEmailDetail);

                #region Send Email
                bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                //tbl_utlAlert_EMail oAlert_Email = new tbl_utlAlert_EMail(sEmail_ID, oAlert.Alert_ID, sSubject, sBodyHTML);
                //oAlert_Email.Insert();

                //foreach (tbl_utlAlertSettings oAlertSetting in tbl_utlAlertSettings.SelectAllByAlert_ID(oAlert.Alert_ID))
                //{
                //    if (oAlertSetting.UserEmail1.Length > 0)
                //        tolist.Add(oAlertSetting.UserEmail1);
                //}

                //SendMailHTML("admin", tolist, filelist, sSubject, sBodyHTML, false);
                #endregion

            }
            else
                bEmailStatus = true;

            return bEmailStatus;

        }
        #endregion

        #region  Receipt Summary
        public static bool createEmail_ReceiptSummary(enum_Alerts alertType, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    #region Create/Format Email Body
                    DataTable tblEmailHeader = new DataTable();
                    DataTable tblEmailDetail = new DataTable();
                    DataTable tblEmailUND = new DataTable();
                    string sTabKey = System.Convert.ToChar(9).ToString();
                    decimal dTotalAmount = 0;
                    List<string> sPendingCheque = new List<string>();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";// sUser, sBody, sCurrencyCode;

                    // Fill Data for Processing 

                    #region Header
                    tblEmailHeader.Columns.Add("heading");
                    tblEmailHeader.Columns.Add("detail");
                    tblEmailHeader.Columns.Add("DataType");
                    tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()));
                    #endregion

                    #region Detail
                    tblEmailDetail.Columns.Add("# ");
                    tblEmailDetail.Columns.Add("Receipt No");
                    tblEmailDetail.Columns.Add("Customer Name");
                    tblEmailDetail.Columns.Add("Salesman Name");
                    tblEmailDetail.Columns.Add("Receipt Date");
                    tblEmailDetail.Columns.Add("Cheque No & Date");
                    tblEmailDetail.Columns.Add("Receipt Amount", typeof(decimal));
                    int i = 1;
                    string OldReceiptNo = "";
                    foreach (tbl_bpsReceipt oReceipt in tbl_bpsReceipt.SelectAll().Where(p => !p.IsDeleted && p.Receipt_ID != "default" && p.ReceiptDate.Date == clsSecurity.getServerDateTime().Date).OrderBy(p => p.IsAdvance).OrderByDescending(p => p.Receipt_ID))
                    {
                        string sCustomer = clsGenaralName.getName_Customer(oReceipt.Customer_ID);
                        string sSalesman = "";
                        tbl_zOrderRefNo order = tbl_zOrderRefNo.Select(oReceipt.OrderRefNo_ID);
                        if (order != null)
                        {
                            sSalesman = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Employee(order.Employee_ID));
                        }
                        foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID))
                        {
                            if (oCheque.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                            {
                                dTotalAmount += oCheque.Amount;
                                if (OldReceiptNo != oReceipt.Receipt_ID)
                                {
                                    tblEmailDetail.Rows.Add(i, oReceipt.Receipt_ID, sCustomer, sSalesman, clsFormatter.FormatDate_Short(oReceipt.ReceiptDate), oCheque.ChequeNumber + " - " + clsFormatter.FormatDate_Short(oCheque.DateCheque), clsFormatter.FormatDecimalPlaces_Price(oCheque.Amount));
                                    OldReceiptNo = oReceipt.Receipt_ID;
                                }
                                else
                                    tblEmailDetail.Rows.Add(i, "", "", "", "", oCheque.ChequeNumber + " - " + clsFormatter.FormatDate_Short(oCheque.DateCheque), clsFormatter.FormatDecimalPlaces_Price(oCheque.Amount));
                                i++;
                            }
                            else
                            {
                                dTotalAmount += oReceipt.CashAmount;
                                if (OldReceiptNo != oReceipt.Receipt_ID)
                                {
                                    tblEmailDetail.Rows.Add(i, oReceipt.Receipt_ID, sCustomer, sSalesman, clsFormatter.FormatDate_Short(oReceipt.ReceiptDate), "CASH", clsFormatter.FormatDecimalPlaces_Price(oReceipt.CashAmount));
                                    OldReceiptNo = oReceipt.Receipt_ID;
                                }
                                else
                                    tblEmailDetail.Rows.Add(i, "", "", "", "", "CASH", clsFormatter.FormatDecimalPlaces_Price(oReceipt.CashAmount));
                                i++;
                            }
                        }
                        //if (oReceipt.CashAmount > 0)
                        //{

                        //}

                    }
                    tblEmailDetail.Rows.Add("", "", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(dTotalAmount));
                    #endregion

                    #region Footer
                    tblEmailUND.Columns.Add("heading");
                    tblEmailUND.Columns.Add("details");
                    tblEmailUND.Columns.Add("DataType");
                    //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");
                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("", "");
                    #endregion

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    if (alertType == enum_Alerts.SheduleAlert_ReceiptSummary)
                    {
                        l1 = "Receipt Summary ";
                        sSubject = "SEACC Alert : Receipt Summary As At: " + clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + "  "; //todo
                    }

                    sBodyHTML = CreateEmailBody(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail, tblEmailUND);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    //tbl_utlAlert_EMail oAlert_Email = new tbl_utlAlert_EMail(sEmail_ID, oAlert.Alert_ID, sSubject, sBodyHTML);
                    //oAlert_Email.Insert();
                    //foreach (tbl_utlAlertSettings oAlertSetting in tbl_utlAlertSettings.SelectAllByAlert_ID(oAlert.Alert_ID))
                    //{
                    //    if (oAlertSetting.UserEmail1.Length > 0)
                    //        tolist.Add(oAlertSetting.UserEmail1);
                    //}
                    //bEmailStatus = SendMailHTML("admin", tolist, filelist, sSubject, sBodyHTML, false);
                    #endregion
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }
        #endregion

        #region Turn Over Detail - Salesman Wise
        public static bool createEmail_TurnOverDetails_SalesmanWise(enum_Alerts alertType, string sSalesmanID, string sEmailAddress, DateTime dtmToday, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    tbl_genEmployeeMaster oEmploye = tbl_genEmployeeMaster.Select(sSalesmanID);
                    if (oEmploye != null && oEmploye.Employee_ID != "default")
                    {
                        #region Create/Format Email Body
                        DataTable tblEmailHeader = new DataTable();
                        DataTable tblEmailDetail = new DataTable();
                        DataTable tblEmailUND = new DataTable();
                        string sTabKey = System.Convert.ToChar(9).ToString();
                        // decimal dTotalAmount = 0;
                        List<string> sPendingCheque = new List<string>();
                        ArrayList tolist = new ArrayList();
                        ArrayList filelist = new ArrayList();
                        string sBodyHTML, sSubject = "";// sUser, sBody, sCurrencyCode;

                        // Fill Data for Processing 

                        #region Header
                        tblEmailHeader.Columns.Add("Heading");
                        tblEmailHeader.Columns.Add("Detail");
                        tblEmailHeader.Columns.Add("DataType");

                        DateTime dtmFirstDay = clsSecurity.FirstDayOfMonthFromDateTime(dtmToday);

                        tblEmailHeader.Rows.Add("Salesman Name ", oEmploye.EmployeeName);
                        tblEmailHeader.Rows.Add("Period ", clsFormatter.FormatDate_Short(dtmFirstDay) + " - " + clsFormatter.FormatDate_Short(dtmToday));
                        tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(dtmToday));
                        #endregion

                        #region Detail
                        tblEmailDetail.Columns.Add("# ");
                        tblEmailDetail.Columns.Add("Customer Code");
                        tblEmailDetail.Columns.Add("Customer Name");
                        tblEmailDetail.Columns.Add("Total Sales");
                        tblEmailDetail.Columns.Add("Total Credit Notes");
                        tblEmailDetail.Columns.Add("Net Sales");
                        tblEmailDetail.Columns.Add("Collection - Cash");
                        tblEmailDetail.Columns.Add("Collection - Cheque");
                        tblEmailDetail.Columns.Add("Confirmed - Orders");
                        tblEmailDetail.Columns.Add("Sales Return Value");
                        int i = 0;
                        // string OldReceiptNo = "";
                        decimal dglbTotalSales = 0, dglbTotalCreditNote = 0, dglbTotalValue = 0, dglbTotalCheque = 0, dglbTotalCash = 0, dglbTotalOrders = 0, dglbSalesReturnValue = 0;
                        foreach (tbl_genCustomerMaster oCustomer in tbl_genCustomerMaster.SelectAll().Where(p => !p.IsDeleted && p.Customer_ID != "default"))
                        {
                            decimal dTotalSales = 0, dTotalCreditNote = 0, dTotalValue = 0, dTotalCash = 0, dTotalCheque = 0, dTotalOrders = 0, dSalesReturnValue = 0;
                            bool bIsForeignCustomer = oCustomer.CustomerType_ID == "2" ? true : false;
                            if (oCustomer.SalesRep_ID != sSalesmanID)
                                continue;

                            foreach (tbl_sasInvoice oInv in tbl_sasInvoice.SelectAll_ByCustomerIDandDateRange(dtmFirstDay, dtmToday, oCustomer.Customer_ID).Where(p => !p.IsDeleted && p.Invoice_ID != "default" && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque))
                            {

                                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                {
                                    if (oInv.Quotation_ID != "default" && oInv.DeliveryOrder_ID == "default") //block invoice
                                        continue;

                                    if (oInv.DeliveryOrder_ID != "default" && oInv.Job_ID == "default") //direct sales
                                        continue;

                                    bool bIsExportSvat = (bIsForeignCustomer && oInv.IsSVatInvoice) ? true : false;

                                    if (bIsExportSvat)//Export SVAT
                                        dTotalSales += oInv.GrandTotal;
                                    else if (!bIsExportSvat && bIsForeignCustomer)//Export VAT
                                        dTotalSales += clsProcessMethods.Reduce_VAT_FromGrandTotal(oInv.GrandTotal, oInv.VatPercentage);
                                    else //Local
                                        dTotalSales += clsProcessMethods.Reduce_VATnNBT_FromGrandTotal(oInv.GrandTotal, oInv.VatPercentage, oInv.NbtPercentage);

                                }
                                else
                                {

                                    if (bIsForeignCustomer)
                                        dTotalSales += oInv.GrandTotal;
                                    else
                                        dTotalSales += clsProcessMethods.Reduce_VATnNBT_FromGrandTotal(oInv.GrandTotal, oInv.VatPercentage, oInv.NbtPercentage);

                                }
                            }

                            foreach (tbl_bpsCreditNote oCrNote in tbl_bpsCreditNote.SelectAll_ByCustomerIDandDateRange(dtmFirstDay, dtmToday, oCustomer.Customer_ID).Where(p => !p.IsDeleted && p.Invoice_ID != "default"))
                            {
                                if (bIsForeignCustomer)
                                    dTotalCreditNote += oCrNote.TotalAmount;
                                else
                                    dTotalCreditNote += clsProcessMethods.Reduce_VATnNBT_FromGrandTotal(oCrNote.TotalAmount, oCrNote.VatPercentage, oCrNote.NbtPercentage);

                                #region Reduce CRs for Block Invoices
                                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                                {
                                    foreach (tbl_sasInvoice_Sattled item in tbl_sasInvoice_Sattled.SelectAllByCreditNote_ID(oCrNote.CreditNote_ID))
                                    {
                                        tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(item.Invoice_ID);
                                        if (oInvoice != null && oInvoice.Invoice_ID != "default" && !oInvoice.IsDeleted && oInvoice.Quotation_ID != "default") //if block invoice
                                        {
                                            if (bIsForeignCustomer)
                                                dTotalCreditNote -= item.SattledAmount;
                                            else
                                                dTotalCreditNote -= clsProcessMethods.Reduce_VATnNBT_FromGrandTotal(item.SattledAmount, oCrNote.VatPercentage, oCrNote.NbtPercentage);
                                        }
                                    }
                                }
                                #endregion
                            }

                            foreach (tbl_bpsReceipt oReceipt in tbl_bpsReceipt.SelectAll_ByCustomerIDandDateRange(dtmFirstDay, dtmToday, oCustomer.Customer_ID).Where(p => !p.IsDeleted && p.Receipt_ID != "default"))
                            {
                                foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default"))
                                {
                                    if (oCheque.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                                    {
                                        dTotalCheque += oCheque.Amount;
                                    }
                                    else
                                    {
                                        dTotalCash += oReceipt.CashAmount;
                                    }
                                }
                            }

                            foreach (tbl_sasSalesReturnedNote OSRN in tbl_sasSalesReturnedNote.SelectAllByCustomer_ID(oCustomer.Customer_ID).Where(p => !p.IsDeleted && p.SalesReturnedNote_ID != "default" && p.SalesReturnedNoteDate.Date >= dtmFirstDay.Date && p.SalesReturnedNoteDate.Date <= dtmToday.Date))
                            {
                                foreach (tbl_sasSalesReturnedNote_Detail oSRNDetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(OSRN.SalesReturnedNote_ID))
                                {
                                    if (OSRN.IsWeightCalculation)
                                        dSalesReturnValue += oSRNDetail.Weight * oSRNDetail.KiloPrice;
                                    else
                                        dSalesReturnValue = +oSRNDetail.Qty * oSRNDetail.UnitPrice;
                                }
                            }

                            foreach (tbl_sasCustomerOrder oCO in tbl_sasCustomerOrder.SelectAll_ByCustomerIDandDateRange(dtmFirstDay, dtmToday, oCustomer.Customer_ID).Where(p => !p.IsDeleted && p.CustomerOrder_ID != "default"))
                            {
                                bool bValid = false;
                                foreach (tbl_pmsProductionJobRegister oJob in tbl_pmsProductionJobRegister.SelectAllByCustomerOrder_ID(oCO.CustomerOrder_ID).Where(p => p.ProductionJob_ID != "default" && !p.IsDeleted && p.IsApproved))
                                {
                                    bValid = true;
                                    break;
                                }

                                if (bValid)
                                {
                                    if (bIsForeignCustomer)
                                        dTotalOrders += oCO.GrandTotal;
                                    else
                                        dTotalOrders += clsProcessMethods.Reduce_VATnNBT_FromGrandTotal(oCO.GrandTotal, oCO.VatPercentage, oCO.NbtPercentage);
                                }
                            }

                            i++;
                            dTotalValue = (dTotalSales - dTotalCreditNote);
                            tblEmailDetail.Rows.Add(i, oCustomer.CustomerCode, oCustomer.CustomerName, clsFormatter.FormatDecimalPlaces_Price(dTotalSales), clsFormatter.FormatDecimalPlaces_Price(dTotalCreditNote), clsFormatter.FormatDecimalPlaces_Price(dTotalValue), clsFormatter.FormatDecimalPlaces_Price(dTotalCash), clsFormatter.FormatDecimalPlaces_Price(dTotalCheque), clsFormatter.FormatDecimalPlaces_Price(dTotalOrders), clsFormatter.FormatDecimalPlaces_Price(dSalesReturnValue));
                            dglbTotalSales += dTotalSales;
                            dglbTotalCreditNote += dTotalCreditNote;
                            dglbTotalValue += dTotalValue;
                            dglbTotalCheque += dTotalCheque;
                            dglbTotalCash += dTotalCash;
                            dglbTotalOrders += dTotalOrders;
                            dglbSalesReturnValue += dSalesReturnValue;
                        }
                        tblEmailDetail.Rows.Add("", "", "", clsFormatter.FormatDecimalPlaces_Price(dglbTotalSales), clsFormatter.FormatDecimalPlaces_Price(dglbTotalCreditNote), clsFormatter.FormatDecimalPlaces_Price(dglbTotalValue), clsFormatter.FormatDecimalPlaces_Price(dglbTotalCash), clsFormatter.FormatDecimalPlaces_Price(dglbTotalCheque), clsFormatter.FormatDecimalPlaces_Price(dglbTotalOrders), clsFormatter.FormatDecimalPlaces_Price(dglbSalesReturnValue));

                        decimal dSales = (dglbTotalSales - dglbTotalCreditNote);
                        decimal dTarget = oEmploye.SalesTarget;
                        decimal dPasentage = (dSales > 0 && dTarget > 0) ? ((dSales * 100) / dTarget) : 0;
                        tblEmailHeader.Rows.Add("Total Sales ", clsFormatter.FormatDecimalPlaces_Price(dSales));
                        tblEmailHeader.Rows.Add("Sales Target ", clsFormatter.FormatDecimalPlaces_Price(dTarget));
                        tblEmailHeader.Rows.Add("Achieved % ", clsFormatter.FormatDecimalPlaces_Price(dPasentage));
                        #endregion

                        #region Footer
                        tblEmailUND.Columns.Add("heading");
                        tblEmailUND.Columns.Add("details");
                        tblEmailUND.Columns.Add("DataType");
                        //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");
                        tblEmailUND.Rows.Add("*Achieved % = (Total Sales - Total Credit Notes) % Sales Target", "");
                        tblEmailUND.Rows.Add("*in export sales does not reduce VAT & NBT", "");
                        tblEmailUND.Rows.Add("*Sales Return Value = Returned Qty * Unit Price ", "");
                        tblEmailUND.Rows.Add("", "");
                        #endregion

                        string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                        string l1 = "";
                        string sEmail_ID = clsFormatter.FormatDate_FullString(dtmToday);
                        if (alertType == enum_Alerts.SheduleAlert_TurnOverDetail_SalesmanWise)
                        {
                            l1 = "Monthly Cumulative Turn Over Detail ";
                            sSubject = "SEACC Alert : Turn Over Detail [" + oEmploye.EmployeeName.Trim() + "] As At: " + clsFormatter.FormatDate_Short(dtmToday) + "  "; //todo
                        }

                        sBodyHTML = CreateEmailBody(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail, tblEmailUND);
                        #endregion

                        #region Send Email
                        bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                        //tbl_utlAlert_EMail oAlert_Email = new tbl_utlAlert_EMail(sEmail_ID, oAlert.Alert_ID, sSubject, sBodyHTML);
                        //oAlert_Email.Insert();

                        //tolist.Add(sEmailAddress);
                        //bEmailStatus = SendMailHTML("admin", tolist, filelist, sSubject, sBodyHTML, false);
                        #endregion
                    }
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }
        #endregion

        #region Turn Over Detail - SalesmanWise Summary
        public static bool createEmail_TurnOverDetails_SalesmanWiseSummary(enum_Alerts alertType, DateTime dtmToday, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    #region Create/Format Email Body
                    DataTable tblEmailHeader = new DataTable();
                    DataTable tblEmailDetail = new DataTable();
                    DataTable tblEmailUND = new DataTable();
                    string sTabKey = System.Convert.ToChar(9).ToString();
                    //  decimal dTotalAmount = 0;
                    List<string> sPendingCheque = new List<string>();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";//    string sUser, sBody, sCurrencyCode;

                    // Fill Data for Processing 

                    #region Header
                    tblEmailHeader.Columns.Add("Heading");
                    tblEmailHeader.Columns.Add("Detail");
                    tblEmailHeader.Columns.Add("DataType");
                    DateTime dtmFirstDay = clsSecurity.FirstDayOfMonthFromDateTime(dtmToday);

                    tblEmailHeader.Rows.Add("Period ", clsFormatter.FormatDate_Short(dtmFirstDay) + " - " + clsFormatter.FormatDate_Short(dtmToday));
                    tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(dtmToday));
                    #endregion

                    #region Detail
                    tblEmailDetail.Columns.Add("# ");
                    tblEmailDetail.Columns.Add("Salesman Name");
                    tblEmailDetail.Columns.Add("Confirmed - Orders");
                    tblEmailDetail.Columns.Add("Total Sales");
                    tblEmailDetail.Columns.Add("Total Credit Notes");
                    tblEmailDetail.Columns.Add("Net Sales Value");
                    tblEmailDetail.Columns.Add("Sales Target");
                    tblEmailDetail.Columns.Add("Achieved %");
                    tblEmailDetail.Columns.Add("Collection - Cash");
                    tblEmailDetail.Columns.Add("Collection - Cheque");
                    tblEmailDetail.Columns.Add("Sales Return Value");
                    int i = 0;
                    //  string OldReceiptNo = "";
                    decimal dglbTotalSales = 0, dglbTotalCreditNote = 0, dglbTotalCash = 0, dglbTotalCheque = 0, dglbTotalOrders = 0, dglbTotalValue = 0, dglbSalesReturnValue = 0;
                    List<tmpTurnOverSalesRepWise> otmpTurnOverSalesRepWises = new List<tmpTurnOverSalesRepWise>();
                    foreach (tbl_genCustomerMaster oCustomer in tbl_genCustomerMaster.SelectAll().Where(p => !p.IsDeleted && p.Customer_ID != "default"))
                    {
                        bool bIsForeignCustomer = oCustomer.CustomerType_ID == "2" ? true : false;
                        decimal dTotalSales = 0, dTotalCreditNote = 0, dTotalValue = 0, dTotalCash = 0, dTotalCheque = 0, dTotalOrders = 0, dSalesReturnValue = 0;
                        foreach (tbl_sasInvoice oInv in tbl_sasInvoice.SelectAll_ByCustomerIDandDateRange(dtmFirstDay, dtmToday, oCustomer.Customer_ID).Where(p => !p.IsDeleted && p.Invoice_ID != "default" && !p.IsOpeningBalance && !p.IsDebitNote && !p.IsReturnedCheque))
                        {
                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                            {
                                if (oInv.Quotation_ID != "default") //if block invoice
                                    continue;
                                if (oInv.DeliveryOrder_ID != "default" && oInv.Job_ID == "default") //if direct sales
                                    continue;

                                bool bIsExportSvat = (bIsForeignCustomer && oInv.IsSVatInvoice) ? true : false;

                                if (bIsExportSvat)//Export SVAT
                                    dTotalSales += oInv.GrandTotal;
                                else if (!bIsExportSvat && bIsForeignCustomer)//Export VAT
                                    dTotalSales += clsProcessMethods.Reduce_VAT_FromGrandTotal(oInv.GrandTotal, oInv.VatPercentage);
                                else //Local
                                    dTotalSales += clsProcessMethods.Reduce_VATnNBT_FromGrandTotal(oInv.GrandTotal, oInv.VatPercentage, oInv.NbtPercentage);
                            }
                            else
                            {
                                if (bIsForeignCustomer)
                                    dTotalSales += oInv.GrandTotal;
                                else
                                    dTotalSales += clsProcessMethods.Reduce_VATnNBT_FromGrandTotal(oInv.GrandTotal, oInv.VatPercentage, oInv.NbtPercentage);
                            }
                        }

                        foreach (tbl_bpsCreditNote oCrNote in tbl_bpsCreditNote.SelectAll_ByCustomerIDandDateRange(dtmFirstDay, dtmToday, oCustomer.Customer_ID).Where(p => !p.IsDeleted && p.CreditNote_ID != "default"))
                        {
                            if (bIsForeignCustomer)
                                dTotalCreditNote += oCrNote.TotalAmount;
                            else
                                dTotalCreditNote += clsProcessMethods.Reduce_VATnNBT_FromGrandTotal(oCrNote.TotalAmount, oCrNote.VatPercentage, oCrNote.NbtPercentage);

                            #region Reduce CRs for Block Invoices
                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                            {
                                foreach (tbl_sasInvoice_Sattled item in tbl_sasInvoice_Sattled.SelectAllByCreditNote_ID(oCrNote.CreditNote_ID))
                                {
                                    tbl_sasInvoice oInvoice = tbl_sasInvoice.Select(item.Invoice_ID);
                                    if (oInvoice != null && oInvoice.Invoice_ID != "default" && !oInvoice.IsDeleted && oInvoice.Quotation_ID != "default") //if block invoice
                                    {
                                        if (bIsForeignCustomer)
                                            dTotalCreditNote -= item.SattledAmount;
                                        else
                                            dTotalCreditNote -= clsProcessMethods.Reduce_VATnNBT_FromGrandTotal(item.SattledAmount, oCrNote.VatPercentage, oCrNote.NbtPercentage);
                                    }
                                }
                            }
                            #endregion
                        }

                        foreach (tbl_bpsReceipt oReceipt in tbl_bpsReceipt.SelectAll_ByCustomerIDandDateRange(dtmFirstDay, dtmToday, oCustomer.Customer_ID).Where(p => !p.IsDeleted && p.Receipt_ID != "default"))
                        {


                            foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(oReceipt.Receipt_ID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default"))
                            {
                                if (oCheque.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                                {
                                    dTotalCheque += oCheque.Amount;
                                }
                                else
                                {
                                    dTotalCash += oReceipt.CashAmount;
                                }
                            }
                        }

                        List<tbl_sasSalesReturnedNote> oSRNs = tbl_sasSalesReturnedNote.SelectAllByCustomer_ID(oCustomer.Customer_ID).Where(p => !p.IsDeleted && p.SalesReturnedNote_ID != "default" && p.SalesReturnedNoteDate.Date >= dtmFirstDay.Date && p.SalesReturnedNoteDate.Date <= dtmToday.Date).ToList();
                        foreach (tbl_sasSalesReturnedNote OSRN in oSRNs)
                        {
                            foreach (tbl_sasSalesReturnedNote_Detail oSRNDetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(OSRN.SalesReturnedNote_ID))
                            {
                                if (OSRN.IsWeightCalculation)
                                    dSalesReturnValue += oSRNDetail.Weight * oSRNDetail.KiloPrice;
                                else
                                    dSalesReturnValue += oSRNDetail.Qty * oSRNDetail.UnitPrice;
                            }
                        }

                        foreach (tbl_sasCustomerOrder oCO in tbl_sasCustomerOrder.SelectAll_ByCustomerIDandDateRange(dtmFirstDay, dtmToday, oCustomer.Customer_ID).Where(p => !p.IsDeleted && p.CustomerOrder_ID != "default"))
                        {
                            bool bValid = false;
                            foreach (tbl_pmsProductionJobRegister oJob in tbl_pmsProductionJobRegister.SelectAllByCustomerOrder_ID(oCO.CustomerOrder_ID).Where(p => p.ProductionJob_ID != "default" && !p.IsDeleted && p.IsApproved))
                            {
                                bValid = true;
                                break;
                            }

                            if (bValid)
                            {
                                if (bIsForeignCustomer)
                                    dTotalOrders += oCO.GrandTotal;
                                else
                                    dTotalOrders += clsProcessMethods.Reduce_VATnNBT_FromGrandTotal(oCO.GrandTotal, oCO.VatPercentage, oCO.NbtPercentage);
                            }
                        }

                        tmpTurnOverSalesRepWise otmpTurnOverSalesRepWise = new tmpTurnOverSalesRepWise();
                        otmpTurnOverSalesRepWise.SalesmanID = oCustomer.SalesRep_ID;
                        otmpTurnOverSalesRepWise.AmtInvoices = dTotalSales;
                        otmpTurnOverSalesRepWise.AmtCreditNote = dTotalCreditNote;
                        otmpTurnOverSalesRepWise.AmtCollection_Cash = dTotalCash;
                        otmpTurnOverSalesRepWise.AmtCollection_Cheque = dTotalCheque;
                        otmpTurnOverSalesRepWise.AmtApprovedOrders = dTotalOrders;
                        otmpTurnOverSalesRepWise.dSalesReturnValue = dSalesReturnValue;
                        otmpTurnOverSalesRepWises.Add(otmpTurnOverSalesRepWise);

                        dTotalValue = (dTotalSales - dTotalCreditNote);
                        dglbTotalSales += dTotalSales;
                        dglbTotalCreditNote += dTotalCreditNote;
                        dglbTotalCash += dTotalCash;
                        dglbTotalCheque += dTotalCheque;
                        dglbTotalOrders += dTotalOrders;
                        dglbTotalValue += dTotalValue;
                        dglbSalesReturnValue += dSalesReturnValue;
                    }

                    var details = otmpTurnOverSalesRepWises.GroupBy(gb => new { gb.SalesmanID }, (Key, group) => new { Salesman_ID = Key.SalesmanID, InvoiceTotal = group.Sum(p => p.AmtInvoices), CreditNoteTotal = group.Sum(p => p.AmtCreditNote), ChequeTotal = group.Sum(p => p.AmtCollection_Cheque), CashTotal = group.Sum(p => p.AmtCollection_Cash), OrderTotal = group.Sum(p => p.AmtApprovedOrders), SRNTotal = group.Sum(p => p.dSalesReturnValue) });
                    foreach (var detail in details.OrderByDescending(p => (p.InvoiceTotal - p.CreditNoteTotal)))
                    {
                        if (detail.Salesman_ID != null && detail.Salesman_ID != "default")
                        {
                            tbl_genEmployeeMaster oEmployee = tbl_genEmployeeMaster.Select(detail.Salesman_ID);
                            if (oEmployee != null && oEmployee.Employee_ID != "default")
                            {
                                if (detail.InvoiceTotal == 0 && detail.CreditNoteTotal == 0 && oEmployee.IsDelete)
                                    continue;

                                i++;
                                decimal dSales = (detail.InvoiceTotal - detail.CreditNoteTotal);
                                decimal dTarget = oEmployee.SalesTarget;
                                decimal dPasentage = (dSales > 0 && dTarget > 0) ? ((dSales * 100) / dTarget) : 0;
                                tblEmailDetail.Rows.Add(i, clsGenaralName.getName_Employee(detail.Salesman_ID), clsFormatter.FormatDecimalPlaces_Price(detail.OrderTotal), clsFormatter.FormatDecimalPlaces_Price(detail.InvoiceTotal), clsFormatter.FormatDecimalPlaces_Price(detail.CreditNoteTotal), clsFormatter.FormatDecimalPlaces_Price(dSales), clsFormatter.FormatDecimalPlaces_Price(dTarget), clsFormatter.FormatDecimalPlaces_Price(dPasentage), clsFormatter.FormatDecimalPlaces_Price(detail.CashTotal), clsFormatter.FormatDecimalPlaces_Price(detail.ChequeTotal), clsFormatter.FormatDecimalPlaces_Price(detail.SRNTotal));
                            }
                        }
                    }
                    tblEmailDetail.Rows.Add("", "", clsFormatter.FormatDecimalPlaces_Price(dglbTotalOrders), clsFormatter.FormatDecimalPlaces_Price(dglbTotalSales), clsFormatter.FormatDecimalPlaces_Price(dglbTotalCreditNote), clsFormatter.FormatDecimalPlaces_Price(dglbTotalValue), "", "", clsFormatter.FormatDecimalPlaces_Price(dglbTotalCash), clsFormatter.FormatDecimalPlaces_Price(dglbTotalCheque), clsFormatter.FormatDecimalPlaces_Price(dglbSalesReturnValue));


                    #endregion

                    #region Footer
                    tblEmailUND.Columns.Add("heading");
                    tblEmailUND.Columns.Add("details");
                    tblEmailUND.Columns.Add("DataType");
                    //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");
                    tblEmailUND.Rows.Add("*Achieved % = (Total Sales - Total Credit Notes) % Sales Target", "");
                    tblEmailUND.Rows.Add("*in export sales does not reduce VAT & NBT", "");
                    tblEmailUND.Rows.Add("*Sales Return Value = Returned Qty * Unit Price ", "");
                    tblEmailUND.Rows.Add("", "");
                    #endregion

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(dtmToday);
                    if (alertType == enum_Alerts.SheduleAlert_TurnOverDetail_SalesmanWiseSummary)
                    {
                        l1 = "Monthly Cumulative Turn Over Detail Salesmenwise ";
                        sSubject = "SEACC Alert : Turn Over Detail As At: " + clsFormatter.FormatDate_Short(dtmToday) + "  "; //todo
                    }

                    sBodyHTML = CreateEmailBody(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail, tblEmailUND);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    //tbl_utlAlert_EMail oAlert_Email = new tbl_utlAlert_EMail(sEmail_ID, oAlert.Alert_ID, sSubject, sBodyHTML);
                    //oAlert_Email.Insert();
                    //foreach (tbl_utlAlertSettings oAlertSetting in tbl_utlAlertSettings.SelectAllByAlert_ID(oAlert.Alert_ID))
                    //{
                    //    if (oAlertSetting.UserEmail1.Length > 0)
                    //        tolist.Add(oAlertSetting.UserEmail1);
                    //}
                    //bEmailStatus = SendMailHTML("admin", tolist, filelist, sSubject, sBodyHTML, false);
                    #endregion
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }
        #endregion

        #region Un Allocated Receipt
        public static bool createEmail_UnAllocatedReceipt(enum_Alerts alertType, DateTime dtmToday, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    #region Create/Format Email Body
                    DataTable tblEmailHeader = new DataTable();
                    DataTable tblEmailDetail = new DataTable();
                    DataTable tblEmailUND = new DataTable();
                    string sTabKey = System.Convert.ToChar(9).ToString();
                    //  decimal dTotalAmount = 0;
                    List<string> sPendingCheque = new List<string>();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";//sUser, sBody, sCurrencyCode;
                    decimal dAmount, dUnsettledAmount, dTotCAmount = 0, dTotUnAmount = 0;
                    //String sAmountType;
                    int i = 1;
                    // Fill Data for Processing 

                    #region Header
                    tblEmailHeader.Columns.Add("Heading");
                    tblEmailHeader.Columns.Add("Detail");
                    tblEmailHeader.Columns.Add("DataType");
                    DateTime dtmFirstDay = clsSecurity.FirstDayOfMonthFromDateTime(dtmToday);

                    tblEmailHeader.Rows.Add("Period ", clsFormatter.FormatDate_Short(dtmFirstDay) + " - " + clsFormatter.FormatDate_Short(dtmToday));
                    tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(dtmToday));
                    #endregion

                    #region Detail
                    tblEmailDetail.Columns.Add("# ");
                    tblEmailDetail.Columns.Add("Recept No");
                    tblEmailDetail.Columns.Add("Recept Date");
                    tblEmailDetail.Columns.Add("Customer Name");
                    tblEmailDetail.Columns.Add("Recept Type");
                    tblEmailDetail.Columns.Add("Cheque No");
                    tblEmailDetail.Columns.Add("Cheque Date");
                    tblEmailDetail.Columns.Add("Amount", typeof(decimal));
                    tblEmailDetail.Columns.Add("Unsetteld Amount", typeof(decimal));


                    foreach (tbl_bpsReceipt detail in tbl_bpsReceipt.SelectAll().Where(p => p.Receipt_ID != "default" && p.IsDeleted != true))//&&p.IsSeattled!=true
                    {

                        if (detail.CashAmount > 0)
                        {
                            dAmount = detail.CashAmount;
                            dUnsettledAmount = (detail.CashAmount - detail.SeattleAmount);

                            if (dUnsettledAmount > 0)
                            {
                                tblEmailDetail.Rows.Add(i, detail.Receipt_ID, clsFormatter.FormatDate_Short(detail.ReceiptDate), clsGenaralName.getName_Customer(detail.Customer_ID), "Cash", "", "", dAmount, dUnsettledAmount);
                                i++;
                                dTotCAmount += dAmount;
                                dTotUnAmount += dUnsettledAmount;
                            }
                        }

                        foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAllByReceipt_ID(detail.Receipt_ID).Where(p => p.ChequeRegister_ID != "default" && p.IsDeleted != true))
                        {
                            dAmount = oCheque.Amount;
                            dUnsettledAmount = (oCheque.Amount - oCheque.SetteledAmount);

                            if (dUnsettledAmount > 0)
                            {
                                tblEmailDetail.Rows.Add(i, detail.Receipt_ID, clsFormatter.FormatDate_Short(detail.ReceiptDate), clsGenaralName.getName_Customer(oCheque.Customer_ID), "Cheque", oCheque.ChequeNumber, clsFormatter.FormatDate_Short(oCheque.DateCheque), dAmount, dUnsettledAmount);
                                i++;
                                dTotCAmount += dAmount;
                                dTotUnAmount += dUnsettledAmount;

                            }
                        }
                    }
                    tblEmailDetail.Rows.Add("", "", "", "", "", "", "", dTotCAmount, dTotUnAmount);


                    #endregion

                    #region Footer
                    tblEmailUND.Columns.Add("heading");
                    tblEmailUND.Columns.Add("details");
                    tblEmailUND.Columns.Add("DataType");
                    //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");
                    tblEmailUND.Rows.Add("*Achieved % = (Total Sales - Total Credit Notes) % Sales Target", "");
                    tblEmailUND.Rows.Add("*in export sales does not reduce VAT & NBT", "");
                    tblEmailUND.Rows.Add("", "");
                    #endregion

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(dtmToday);
                    if (alertType == enum_Alerts.SheduleAlert_UnallocatedResipt)
                    {
                        l1 = "UnAllocated Receipt ";
                        sSubject = "SEACC Alert : UnAllocated Receipt As At: " + clsFormatter.FormatDate_Short(dtmToday) + "  "; //todo
                    }

                    sBodyHTML = CreateEmailBody(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail, tblEmailUND);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);

                    #endregion
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }
        #endregion

        #region  OutsTanding Jobs Alert
        public static bool createEmail_OutstandingJobsAlert_SalesmanWise(enum_Alerts alertType, string sSalesmanID, string sEmailAddress, DateTime dtmToday, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    tbl_genEmployeeMaster oEmploye = tbl_genEmployeeMaster.Select(sSalesmanID);
                    if (oEmploye != null && oEmploye.Employee_ID != "default")
                    {
                        #region Create/Format Email Body
                        DataTable tblEmailHeader = new DataTable();
                        DataTable tblEmailDetail = new DataTable();
                        DataTable tblEmailUND = new DataTable();
                        string sTabKey = System.Convert.ToChar(9).ToString();
                        // decimal dTotalAmount = 0;
                        List<string> sPendingCheque = new List<string>();
                        ArrayList tolist = new ArrayList();
                        ArrayList filelist = new ArrayList();
                        string sBodyHTML, sSubject = "";//sUser, sBody, sCurrencyCode;
                        // Fill Data for Processing 

                        #region Header
                        tblEmailHeader.Columns.Add("Heading");
                        tblEmailHeader.Columns.Add("Detail");
                        tblEmailHeader.Columns.Add("DataType");

                        DateTime dtmFirstDay = clsSecurity.FirstDayOfMonthFromDateTime(dtmToday);

                        tblEmailHeader.Rows.Add("Salesman Name ", oEmploye.EmployeeName);
                        tblEmailHeader.Rows.Add("Period ", clsFormatter.FormatDate_Short(dtmFirstDay) + " - " + clsFormatter.FormatDate_Short(dtmToday));
                        tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(dtmToday));
                        #endregion

                        #region Detail
                        tblEmailDetail.Columns.Add("# ");
                        tblEmailDetail.Columns.Add("Job Number");
                        tblEmailDetail.Columns.Add("PO Number");
                        tblEmailDetail.Columns.Add("Customer Name");
                        tblEmailDetail.Columns.Add("Order Date");
                        tblEmailDetail.Columns.Add("Ageing");
                        tblEmailDetail.Columns.Add("Item Name");
                        tblEmailDetail.Columns.Add("UOM");
                        tblEmailDetail.Columns.Add("Order Qty");
                        tblEmailDetail.Columns.Add("Delivery Qty");
                        tblEmailDetail.Columns.Add("Balance Qty");
                        tblEmailDetail.Columns.Add("Balance %");

                        int i = 0;
                        //  string OldReceiptNo = "";
                        // decimal dglbTotalSales = 0, dglbTotalCreditNote = 0, dglbTotalValue = 0, dglbTotalCheque = 0, dglbTotalCash = 0, dglbTotalOrders = 0;
                        decimal dglbOrderQty = 0, dglbDeliveryQty = 0, dglbBalanceQty = 0, dglbBalanceWeight = 0;
                        List<tmpJobOutsStanding> oJobOutstandings = new List<tmpJobOutsStanding>();
                        int count = 0;
                        foreach (tbl_genCustomerMaster oCustomer in tbl_genCustomerMaster.SelectAll().Where(p => !p.IsDeleted && p.Customer_ID != "default"))
                        {
                            // decimal dTotalSales = 0, dTotalCreditNote = 0, dTotalValue = 0, dTotalCash = 0, dTotalCheque = 0, dTotalOrders = 0;
                            // bool bValidCustomer = false;
                            string sUom = "";
                            if (oCustomer.SalesRep_ID != sSalesmanID)
                                continue;


                            foreach (tbl_sasCustomerOrder oCO in tbl_sasCustomerOrder.SelectAllByCustomer_ID(oCustomer.Customer_ID).Where(p => !p.IsDeleted && p.CustomerOrder_ID != "default" && !p.IsSeattled))
                            {
                                foreach (tbl_pmsProductionJobRegister oJob in tbl_pmsProductionJobRegister.SelectAllByCustomerOrder_ID(oCO.CustomerOrder_ID).Where(p => p.ProductionJob_ID != "default" && !p.IsDeleted && p.IsApproved))
                                {

                                    string sItemCode = oJob.Item_ID, sPONo = oCO.PurchaseOrder_ID;
                                    DateTime dtmJobOrderDate = oCO.CustomerOrderDate;
                                    decimal dOrderQty = 0, dDeliveryQty = 0, dBalanceQty = 0, dBalancePasantage = 0;
                                    sUom = clsGenaralName.getName_Uom(oJob.Uom_ID);
                                    foreach (tbl_sasCustomerOrder_Detail oCODetail in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(oCO.CustomerOrder_ID))
                                    {
                                        if (oCODetail.Item_ID == sItemCode)
                                        {
                                            dOrderQty += oCO.IsWeightCalculation ? oCODetail.Weight : oCODetail.Qty;
                                            dglbOrderQty += oCO.IsWeightCalculation ? oCODetail.Weight : oCODetail.Qty;
                                            sItemCode = oCODetail.Item_ID;
                                        }
                                    }

                                    foreach (tbl_sasDeliveryOrder oDo in tbl_sasDeliveryOrder.SelectAllByJob_ID(oJob.ProductionJob_ID).Where(p => !p.IsDeleted && p.DeliveryOrder_ID != "default"))
                                    {
                                        foreach (tbl_sasDeliveryOrder_Detail oDoDetail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDo.DeliveryOrder_ID))
                                        {
                                            if (oDoDetail.Item_ID == sItemCode)
                                            {
                                                dDeliveryQty += oDo.IsWeightCalculation ? oDoDetail.Weight : oDoDetail.Qty;
                                                dglbDeliveryQty += oDo.IsWeightCalculation ? oDoDetail.Weight : oDoDetail.Qty;
                                            }

                                            foreach (tbl_sasSalesReturnedNote oSalesReturn in tbl_sasSalesReturnedNote.SelectAllByDeliveryOrder_ID(oDo.DeliveryOrder_ID).Where(p => !p.IsDeleted && p.SalesReturnedNote_ID != "default"))
                                            {
                                                foreach (tbl_sasSalesReturnedNote_Detail oSRD in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSalesReturn.SalesReturnedNote_ID))
                                                {
                                                    if (oSRD.Item_ID == sItemCode)
                                                    {
                                                        dDeliveryQty -= oSalesReturn.IsWeightCalculation ? oSRD.Weight : oSRD.Qty;
                                                        dglbDeliveryQty -= oSalesReturn.IsWeightCalculation ? oSRD.Weight : oSRD.Qty;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    dBalanceQty = (dOrderQty - dDeliveryQty);
                                    if (dBalanceQty > 0)
                                    {
                                        string sDeliveryQty = oCO.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(dDeliveryQty) : clsFormatter.FormatDecimalPlaces_Quantity(dDeliveryQty);
                                        string sOrderQty = oCO.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(dOrderQty) : clsFormatter.FormatDecimalPlaces_Quantity(dOrderQty);
                                        string sBalanceQty = oCO.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(dBalanceQty) : clsFormatter.FormatDecimalPlaces_Quantity(dBalanceQty);
                                        dglbBalanceQty += oCO.IsWeightCalculation ? 0 : dBalanceQty;
                                        dglbBalanceWeight += oCO.IsWeightCalculation ? dBalanceQty : 0;
                                        dBalancePasantage = (decimal.Parse(sBalanceQty) / decimal.Parse(sOrderQty)) * 100;//
                                        int iAgeing = clsCommon.getDaysUptoDate(oCO.CustomerOrderDate);

                                        //tblEmailDetail.Rows.Add(i, oJob.ProductionJob_ID, sPONo, oCustomer.CustomerName, clsFormatter.FormatDate_Short(oCO.CustomerOrderDate), iAgeing, clsGenaralName.getName_Item(sItemCode), sUom, sOrderQty, sDeliveryQty, sBalanceQty, clsFormatter.FormatDecimalPlaces_Price(dBalancePasantage));
                                        //lItem.Add(i,oJob.ProductionJob_ID, sPONo, oCustomer.CustomerName, clsFormatter.FormatDate_Short(oCO.CustomerOrderDate), iAgeing, clsGenaralName.getName_Item(sItemCode), sUom, sOrderQty, sDeliveryQty, sBalanceQty, clsFormatter.FormatDecimalPlaces_Price(dBalancePasantage));
                                        tmpJobOutsStanding oJobOutstanding = new tmpJobOutsStanding();
                                        oJobOutstanding.count = i;
                                        oJobOutstanding.sProductionJob_ID = oJob.ProductionJob_ID;
                                        oJobOutstanding.sPONo = sPONo;
                                        oJobOutstanding.sCustomerName = oCustomer.CustomerName;
                                        oJobOutstanding.CustomerOrderDate = oCO.CustomerOrderDate;
                                        oJobOutstanding.iAgeing = iAgeing;
                                        oJobOutstanding.sItemCode = clsGenaralName.getName_Item(sItemCode);
                                        oJobOutstanding.sUom = sUom;
                                        oJobOutstanding.sOrderQty = sOrderQty;
                                        oJobOutstanding.sDeliveryQty = sDeliveryQty;
                                        oJobOutstanding.sBalanceQty = sBalanceQty;
                                        oJobOutstanding.dBalancePasantage = dBalancePasantage;
                                        oJobOutstandings.Add(oJobOutstanding);
                                        i++;
                                    }
                                }
                            }
                        }

                        foreach (tmpJobOutsStanding oItem in oJobOutstandings.OrderByDescending(p => p.iAgeing))
                        {
                            count++;
                            tblEmailDetail.Rows.Add(count, oItem.sProductionJob_ID, oItem.sPONo, oItem.sCustomerName, clsFormatter.FormatDate_Short(oItem.CustomerOrderDate), oItem.iAgeing, oItem.sItemCode, oItem.sUom, oItem.sOrderQty, oItem.sDeliveryQty, oItem.sBalanceQty, clsFormatter.FormatDecimalPlaces_Price(oItem.dBalancePasantage));

                        }


                        tblEmailHeader.Rows.Add("Total Balance Qty ", clsFormatter.FormatDecimalPlaces_Quantity(dglbBalanceQty));
                        tblEmailHeader.Rows.Add("Total Balance Weight ", clsFormatter.FormatDecimalPlaces_Weight(dglbBalanceWeight));
                        tblEmailHeader.Rows.Add("Total Balance Orders ", i);
                        #endregion

                        #region Footer
                        tblEmailUND.Columns.Add("heading");
                        tblEmailUND.Columns.Add("details");
                        tblEmailUND.Columns.Add("DataType");
                        //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");
                        tblEmailUND.Rows.Add("*Achieved % = (Total Sales - Total Credit Notes) % Sales Target", "");
                        tblEmailUND.Rows.Add("*in export sales does not reduce VAT & NBT", "");
                        tblEmailUND.Rows.Add("", "");
                        #endregion

                        string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                        string l1 = "";
                        string sEmail_ID = clsFormatter.FormatDate_FullString(dtmToday);
                        if (alertType == enum_Alerts.SheduleAlert_TurnOverDetail_SalesmanWise)
                        {
                            l1 = "Job Outstanding";
                            sSubject = "SEACC Alert : Job Outstanding [" + oEmploye.EmployeeName.Trim() + "] As At: " + clsFormatter.FormatDate_Short(dtmToday) + "  "; //todo
                        }

                        sBodyHTML = CreateEmailBody(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail, tblEmailUND);
                        #endregion

                        #region Send Email
                        bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                        //tbl_utlAlert_EMail oAlert_Email = new tbl_utlAlert_EMail(sEmail_ID, oAlert.Alert_ID, sSubject, sBodyHTML);
                        //oAlert_Email.Insert();

                        //tolist.Add(sEmailAddress);
                        //bEmailStatus = SendMailHTML("admin", tolist, filelist, sSubject, sBodyHTML, false);
                        #endregion
                    }
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }
        #endregion

        #region  Job Close Summary
        public static bool createEmail_JobCloseSummary(enum_Alerts alertType, DateTime dtmToday, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    #region Create/Format Email Body
                    DataTable tblEmailHeader = new DataTable();
                    DataTable tblEmailDetail = new DataTable();
                    DataTable tblEmailUND = new DataTable();
                    string sTabKey = System.Convert.ToChar(9).ToString();
                    // decimal dTotalAmount = 0;
                    List<string> sPendingCheque = new List<string>();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";//sUser, sBody, sCurrencyCode;

                    // Fill Data for Processing 

                    #region Header
                    tblEmailHeader.Columns.Add("Heading");
                    tblEmailHeader.Columns.Add("Detail");
                    tblEmailHeader.Columns.Add("DataType");
                    DateTime dtmFirstDay = clsSecurity.FirstDayOfMonthFromDateTime(dtmToday);

                    tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(dtmToday));
                    #endregion

                    #region Detail
                    tblEmailDetail.Columns.Add("# ");
                    tblEmailDetail.Columns.Add("Job Closed Time");
                    tblEmailDetail.Columns.Add("Customer Name");
                    tblEmailDetail.Columns.Add("Salesman Name");
                    tblEmailDetail.Columns.Add("Job Number");
                    tblEmailDetail.Columns.Add("PO Number");
                    tblEmailDetail.Columns.Add("Job Order Date");
                    tblEmailDetail.Columns.Add("Job Delivery Date");
                    tblEmailDetail.Columns.Add("UOM");
                    tblEmailDetail.Columns.Add("Total Order Qty");
                    tblEmailDetail.Columns.Add("Total Delivery Qty");
                    tblEmailDetail.Columns.Add("Total Invoiced Qty");
                    tblEmailDetail.Columns.Add("Total Invoiced Amount", typeof(decimal));
                    tblEmailDetail.Columns.Add("Actual Unit Cost (Ex OH) Per Item", typeof(decimal));
                    tblEmailDetail.Columns.Add("Actual Unit Cost (Ix OH) Per Item", typeof(decimal));
                    tblEmailDetail.Columns.Add("Actual Profit Total (Ex OH)", typeof(decimal));

                    int i = 0;
                    //  string OldReceiptNo = "";
                    decimal dglbTotalInvoicedAmount = 0, dglbTotalBalanceAmount = 0, dglbOrderQty = 0, dglbOrderWeight = 0, dglbDeliveryQty = 0, dglbDeliveryWeight = 0, dglbInvQty = 0, dglbInvWeight = 0;

                    foreach (tbl_pmsProductionJobRegister oJob in tbl_pmsProductionJobRegister.SelectAll().Where(p => !p.IsDeleted && p.ProductionJob_ID != "default" && p.IsJobClosed && p.DateModified.Date == dtmToday.Date))
                    {
                        decimal dActualProfit_ExcludingOV = 0, dActualProfit_IncludingOV_PerUnit = 0, dActualProfit_ExcludingOV_PerUnit = 0;// dTemp5 = 0 ,dTemp1 = 0, dTemp2 = 0, dTemp3 = 0, dTemp4 = 0;
                        string sItemCode = oJob.Item_ID, sCustomerName = "", sSalesmanName = "", sPONo = "", UOM = "";
                        DateTime dtmJobOrderDate = new DateTime(), dtmDeliveryDate = new DateTime(), dtmClosedDateTime = oJob.DateModified;
                        decimal dOrderQty = 0, dDeliveryQty = 0, dInvQty = 0, dTotalInvoicedAmount = 0, dTotalBalanceAmount = 0;
                        tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oJob.Customer_ID);
                        if (oCustomer != null && oCustomer.Customer_ID != "default")
                        {
                            sCustomerName = oCustomer.CustomerName;
                            sSalesmanName = clsGenaralName.getName_SalesRep(oCustomer.SalesRep_ID);
                        }

                        tbl_sasCustomerOrder oCO = tbl_sasCustomerOrder.Select(oJob.CustomerOrder_ID);
                        if (oCO != null && oCO.CustomerOrder_ID != "default")
                        {
                            sPONo = oCO.PurchaseOrder_ID;
                            dtmJobOrderDate = oCO.CustomerOrderDate;
                            dtmDeliveryDate = oCO.DeliveryDate;
                            foreach (tbl_sasCustomerOrder_Detail oCODetail in tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(oCO.CustomerOrder_ID))
                            {
                                if (oCODetail.Item_ID == sItemCode)
                                {
                                    dOrderQty += oCO.IsWeightCalculation ? oCODetail.Weight : oCODetail.Qty;
                                    dglbOrderQty += !oCO.IsWeightCalculation ? oCODetail.Qty : 0;
                                    dglbOrderWeight += oCO.IsWeightCalculation ? oCODetail.Weight : 0;
                                }
                            }
                            srh_WIP_ProfitAndLoss detail = srh_WIP_ProfitAndLoss.Select(oJob.ProductionJob_ID);
                            if (detail != null && detail.ProductionJob_ID != "default")
                            {
                                string sConfirmedBy, sCloseDateTime, sItemName;
                                sCustomerName = detail.CustomerName;
                                sItemName = detail.ItemName;
                                sCloseDateTime = clsSecurity.getServerDateTime().ToString();
                                sConfirmedBy = clsSecurity.UserIDLoged;

                                decimal dOrder_Qty = detail.IsQty ? detail.Qty : 0;
                                decimal dOrder_Weight = detail.IsWeight ? detail.Weight : 0;
                                decimal dOrder_Meter = detail.IsLength ? detail.Weight : 0;
                                decimal dProduced_Qty = 0, dProduced_Weight = 0, dProducedMeter = 0, dActualProfit_IncludingOV = 0, dExtraProfit = 0, dOverHead = 0, dMarkup = 0;
                                if (detail.WorkInProgress_ID != null && detail.WorkInProgress_ID != "default" && detail.WorkInProgress_ID.Length > 0)
                                {
                                    decimal dSellingPrice = detail.IsQty ? detail.UnitPrice : detail.IsWeight ? detail.WeightPrice : detail.IsLength ? detail.WeightPrice : 0;
                                    clsProcessMethods.getActualProfit_FromJobID(dOverHead, dMarkup, detail.WorkInProgress_ID, detail.Item_ID, detail.IsQty, detail.IsWeight, detail.IsLength,
                                        dSellingPrice, ref dProduced_Qty, ref dProduced_Weight, ref dProducedMeter, ref dActualProfit_IncludingOV, ref dActualProfit_ExcludingOV, ref dActualProfit_IncludingOV_PerUnit, ref dActualProfit_ExcludingOV_PerUnit, ref dExtraProfit, true, true, true);

                                }
                            }

                            foreach (tbl_sasDeliveryOrder oDo in tbl_sasDeliveryOrder.SelectAllByJob_ID(oJob.ProductionJob_ID).Where(p => !p.IsDeleted && p.DeliveryOrder_ID != "default"))
                            {
                                foreach (tbl_sasDeliveryOrder_Detail oDoDetail in tbl_sasDeliveryOrder_Detail.SelectAllByDeliveryOrder_ID(oDo.DeliveryOrder_ID))
                                {
                                    if (oDoDetail.Item_ID == sItemCode)
                                    {
                                        dDeliveryQty += oDo.IsWeightCalculation ? oDoDetail.Weight : oDoDetail.Qty;
                                        dglbDeliveryWeight += oDo.IsWeightCalculation ? oDoDetail.Weight : 0;
                                        dglbDeliveryQty += !oDo.IsWeightCalculation ? oDoDetail.Qty : 0;
                                    }

                                    foreach (tbl_sasSalesReturnedNote oSalesReturn in tbl_sasSalesReturnedNote.SelectAllByDeliveryOrder_ID(oDo.DeliveryOrder_ID).Where(p => !p.IsDeleted && p.SalesReturnedNote_ID != "default"))
                                    {
                                        foreach (tbl_sasSalesReturnedNote_Detail oSRD in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(oSalesReturn.SalesReturnedNote_ID))
                                        {
                                            if (oSRD.Item_ID == sItemCode)
                                            {
                                                dDeliveryQty -= oSalesReturn.IsWeightCalculation ? oSRD.Weight : oSRD.Qty;
                                                dglbDeliveryWeight -= oSalesReturn.IsWeightCalculation ? oSRD.Weight : 0;
                                                dglbDeliveryQty -= !oSalesReturn.IsWeightCalculation ? oSRD.Qty : 0;
                                            }
                                        }
                                    }

                                    foreach (tbl_sasInvoice oInvoice in tbl_sasInvoice.SelectAllByDeliveryOrder_ID(oDo.DeliveryOrder_ID).Where(p => !p.IsDeleted && p.Invoice_ID != "default"))
                                    {
                                        foreach (tbl_sasInvoice_Detail oInvDetail in tbl_sasInvoice_Detail.SelectAllByInvoice_ID(oInvoice.Invoice_ID))
                                        {
                                            if (oInvDetail.Item_ID == sItemCode)
                                            {
                                                dInvQty += oInvoice.IsWeightCalculation ? oInvDetail.Weight : oInvDetail.Qty;
                                                dglbInvWeight += oInvoice.IsWeightCalculation ? oInvDetail.Weight : 0;
                                                dglbInvQty += !oInvoice.IsWeightCalculation ? oInvDetail.Qty : 0;
                                                UOM = clsGenaralName.getName_Uom(oInvDetail.Uom_ID);
                                            }
                                        }
                                        dTotalInvoicedAmount += oInvoice.GrandTotal;
                                        dTotalBalanceAmount += (oInvoice.GrandTotal - oInvoice.SeattleAmount);
                                        dglbTotalInvoicedAmount += oInvoice.GrandTotal;
                                        dglbTotalBalanceAmount += (oInvoice.GrandTotal - oInvoice.SeattleAmount);

                                    }
                                }
                            }

                            string sOrderQty = oCO.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(dOrderQty) : clsFormatter.FormatDecimalPlaces_Quantity(dOrderQty);
                            string sDeliveryQty = oCO.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(dDeliveryQty) : clsFormatter.FormatDecimalPlaces_Quantity(dDeliveryQty);
                            string sInvoiceQty = oCO.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(dInvQty) : clsFormatter.FormatDecimalPlaces_Quantity(dInvQty);
                            i++;
                            tblEmailDetail.Rows.Add(i, clsFormatter.FormatTime_Short(dtmClosedDateTime), sCustomerName, sSalesmanName, oJob.ProductionJob_ID, sPONo, clsFormatter.FormatDate_Short(dtmJobOrderDate), clsFormatter.FormatDate_Short(dtmDeliveryDate), UOM, sOrderQty, sDeliveryQty, sInvoiceQty, clsFormatter.FormatDecimalPlaces_Price(dTotalInvoicedAmount), clsFormatter.FormatDecimalPlaces_Price(dActualProfit_ExcludingOV_PerUnit), clsFormatter.FormatDecimalPlaces_Price(dActualProfit_ExcludingOV_PerUnit), clsFormatter.FormatDecimalPlaces_Price(dActualProfit_ExcludingOV));
                        }
                    }

                    //   tblEmailDetail.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(dglbTotalInvoicedAmount), clsFormatter.FormatDecimalPlaces_Price(dglbTotalBalanceAmount));
                    tblEmailDetail.Rows.Add("", "", "", "", "", "", "", "", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(dglbTotalInvoicedAmount), "", "", "");

                    tblEmailHeader.Rows.Add("Total Order Qty ", clsFormatter.FormatDecimalPlaces_Quantity(dglbOrderQty));
                    tblEmailHeader.Rows.Add("Total Order Weight ", clsFormatter.FormatDecimalPlaces_Weight(dglbOrderWeight));
                    tblEmailHeader.Rows.Add("Total Delivery Qty ", clsFormatter.FormatDecimalPlaces_Quantity(dglbDeliveryQty));
                    tblEmailHeader.Rows.Add("Total Delivery Weight ", clsFormatter.FormatDecimalPlaces_Weight(dglbDeliveryWeight));
                    tblEmailHeader.Rows.Add("Total Invoice Qty ", clsFormatter.FormatDecimalPlaces_Quantity(dglbInvQty));
                    tblEmailHeader.Rows.Add("Total Invoice Weight ", clsFormatter.FormatDecimalPlaces_Weight(dglbInvWeight));
                    tblEmailHeader.Rows.Add("Total Orders ", i);
                    #endregion

                    #region Footer
                    tblEmailUND.Columns.Add("heading");
                    tblEmailUND.Columns.Add("details");
                    tblEmailUND.Columns.Add("DataType");
                    //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");
                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("", "");
                    #endregion

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(dtmToday);
                    if (alertType == enum_Alerts.SheduleAlert_JobCloseSummary)
                    {
                        l1 = "Job Close Summary ";
                        sSubject = "SEACC Alert : Job Close Summary As At: " + clsFormatter.FormatDate_Short(dtmToday) + "  "; //todo
                    }

                    sBodyHTML = CreateEmailBody(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail, tblEmailUND);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    //tbl_utlAlert_EMail oAlert_Email = new tbl_utlAlert_EMail(sEmail_ID, oAlert.Alert_ID, sSubject, sBodyHTML);
                    //oAlert_Email.Insert();
                    //foreach (tbl_utlAlertSettings oAlertSetting in tbl_utlAlertSettings.SelectAllByAlert_ID(oAlert.Alert_ID))
                    //{
                    //    if (oAlertSetting.UserEmail1.Length > 0)
                    //        tolist.Add(oAlertSetting.UserEmail1);
                    //}
                    //bEmailStatus = SendMailHTML("admin", tolist, filelist, sSubject, sBodyHTML, false);
                    #endregion
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }
        #endregion

        #region Sales Return Summary
        public static bool createEmail_SalesReturnSummary(enum_Alerts alertType, DateTime dtmToday, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {

                    #region Create/Format Email Body
                    DataTable tblEmailHeader = new DataTable();
                    DataTable tblEmailDetail = new DataTable();
                    DataTable tblEmailUND = new DataTable();
                    string sTabKey = System.Convert.ToChar(9).ToString();
                    //  decimal dTotalAmount = 0;
                    List<string> sPendingCheque = new List<string>();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";//sUser, sBody, sCurrencyCode;

                    // Fill Data for Processing 

                    #region Header
                    tblEmailHeader.Columns.Add("Heading");
                    tblEmailHeader.Columns.Add("Detail");
                    tblEmailHeader.Columns.Add("DataType");

                    DateTime dtmFirstDay = clsSecurity.FirstDayOfMonthFromDateTime(dtmToday);

                    //tblEmailHeader.Rows.Add("Salesman Name ", oEmploye.EmployeeName);
                    tblEmailHeader.Rows.Add("Period ", clsFormatter.FormatDate_Short(dtmFirstDay) + " - " + clsFormatter.FormatDate_Short(dtmToday));
                    tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(dtmToday));
                    #endregion

                    #region Detail
                    tblEmailDetail.Columns.Add("# ");
                    tblEmailDetail.Columns.Add("SRN No");
                    tblEmailDetail.Columns.Add("SRN Date");
                    tblEmailDetail.Columns.Add("DO No");
                    tblEmailDetail.Columns.Add("DO Date");
                    tblEmailDetail.Columns.Add("Customer Name");
                    tblEmailDetail.Columns.Add("Salsman Name");
                    tblEmailDetail.Columns.Add("Item Name");
                    tblEmailDetail.Columns.Add("QTY");
                    tblEmailDetail.Columns.Add("UOM");
                    tblEmailDetail.Columns.Add("Unit Price");
                    tblEmailDetail.Columns.Add("Return Value");
                    tblEmailDetail.Columns.Add("Remarks");

                    int iCount = 0;
                    // string OldReceiptNo = "";
                    decimal dglbQty = 0, dglbReturendValue = 0, dglbWeight = 0;//dglUnitPrice = 0,
                    DateTime dtmSalseReturnDate = DateTime.MinValue;


                    foreach (tbl_sasSalesReturnedNote oReturn in tbl_sasSalesReturnedNote.SelectAll().Where(p => !p.IsDeleted && p.SalesReturnedNote_ID != "default" && p.SalesReturnedNoteDate.Date >= dtmFirstDay.Date && p.SalesReturnedNoteDate.Date <= dtmToday.Date))//
                    {
                        decimal dQty = 0, dUnitPrice = 0, dReturendValue = 0;
                        string sCusustomerName = "", sSalseReturnNo = "", sItemName = "", sUom = "", sQty = "", sSalesManName = "";
                        string sRemark = "", sDoNo = "";
                        string sDoDate = "";
                        sSalseReturnNo = oReturn.SalesReturnedNote_ID;
                        dtmSalseReturnDate = oReturn.SalesReturnedNoteDate;

                        if (oReturn.Customer_ID != null && oReturn.Customer_ID != "default")
                        {
                            sCusustomerName = clsGenaralName.getName_Customer(oReturn.Customer_ID);
                        }
                        else
                            sCusustomerName = "-";

                        sRemark = oReturn.Remark.Trim();


                        if (oReturn.DeliveryOrder_ID != null && oReturn.DeliveryOrder_ID != "default")
                        {
                            sDoNo = oReturn.DeliveryOrder_ID;
                        }
                        else
                            sDoNo = "-";
                        tbl_sasDeliveryOrder oItem = tbl_sasDeliveryOrder.Select(oReturn.DeliveryOrder_ID);
                        //sDoNo = oReturn.DeliveryOrder_ID;
                        //tbl_sasDeliveryOrder oItem = tbl_sasDeliveryOrder.Select(sDoNo);
                        if (oItem != null && oItem.DeliveryOrder_ID != "default")
                            sDoDate = oItem.DeliveryOrderDate.Date.ToString("dd/MM/yyyy");

                        tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oReturn.Customer_ID);
                        if (oCustomer != null && oCustomer.CustomerCode != "default")
                        {
                            tbl_genEmployeeMaster oEmployee = tbl_genEmployeeMaster.Select(oCustomer.SalesRep_ID);
                            if (oEmployee != null && oEmployee.EmployeeName != "default")
                            {
                                sSalesManName = oEmployee.EmployeeName;
                            }
                            else
                                sSalesManName = "-";
                        }


                        foreach (tbl_sasSalesReturnedNote_Detail oReturnItems in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(sSalseReturnNo).Where(p => p.SalesReturnedNote_ID != "default"))
                        {
                            sUom = clsGenaralName.getName_ItemUOM(oReturnItems.Item_ID);
                            sItemName = clsGenaralName.getName_Item(oReturnItems.Item_ID);
                            sQty = oReturn.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(oReturnItems.Weight) : clsFormatter.FormatDecimalPlaces_Quantity(oReturnItems.Qty);
                            dQty = oReturn.IsWeightCalculation ? oReturnItems.Weight : oReturnItems.Qty;
                            dglbQty += oReturn.IsWeightCalculation ? 0 : oReturnItems.Qty;
                            dglbWeight += oReturn.IsWeightCalculation ? oReturnItems.Weight : 0;
                            dReturendValue = oReturn.IsWeightCalculation ? (oReturnItems.Weight * oReturnItems.KiloPrice) : (oReturnItems.Qty * oReturnItems.UnitPrice);
                            dglbReturendValue += dReturendValue;
                            dUnitPrice = oReturnItems.UnitPrice;

                        }
                        iCount++;
                        tblEmailDetail.Rows.Add(iCount, sSalseReturnNo, clsFormatter.FormatDate_Short(dtmSalseReturnDate), sDoNo, sDoDate, sCusustomerName, sSalesManName, sItemName, sQty, sUom, clsFormatter.FormatDecimalPlaces_Price(dUnitPrice), clsFormatter.FormatDecimalPlaces_Price(dReturendValue), sRemark);
                    }
                    tblEmailDetail.Rows.Add("", "", "", "", "", "", "", clsFormatter.FormatDecimalPlaces_Quantity(dglbQty), "", "", clsFormatter.FormatDecimalPlaces_Price(dglbReturendValue), "");
                    tblEmailHeader.Rows.Add("Total Returned Qty ", clsFormatter.FormatDecimalPlaces_Quantity(dglbQty));
                    tblEmailHeader.Rows.Add("Total Returned Weight ", clsFormatter.FormatDecimalPlaces_Weight(dglbWeight));
                    tblEmailHeader.Rows.Add("Total Returned Value ", clsFormatter.FormatDecimalPlaces_Price(dglbReturendValue));
                    #endregion

                    #region Footer
                    tblEmailUND.Columns.Add("heading");
                    tblEmailUND.Columns.Add("details");
                    tblEmailUND.Columns.Add("DataType");
                    //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");
                    tblEmailUND.Rows.Add("*Achieved % = (Total Sales - Total Credit Notes) % Sales Target", "");
                    tblEmailUND.Rows.Add("*in export sales does not reduce VAT & NBT", "");
                    tblEmailUND.Rows.Add("", "");
                    #endregion

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(dtmToday);
                    if (alertType == enum_Alerts.SheduleAlert_SalseReturnSummary)
                    {
                        l1 = " Sales Return Summary ";
                        sSubject = "SEACC Alert :  Sales Return Summary As At: " + clsFormatter.FormatDate_Short(dtmToday) + "  "; //todo
                    }

                    sBodyHTML = CreateEmailBody(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail, tblEmailUND);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    //tbl_utlAlert_EMail oAlert_Email = new tbl_utlAlert_EMail(sEmail_ID, oAlert.Alert_ID, sSubject, sBodyHTML);
                    //oAlert_Email.Insert();
                    //foreach (tbl_utlAlertSettings oAlertSetting in tbl_utlAlertSettings.SelectAllByAlert_ID(oAlert.Alert_ID))
                    //{
                    //    if (oAlertSetting.UserEmail1.Length > 0)
                    //        tolist.Add(oAlertSetting.UserEmail1);
                    //}
                    //bEmailStatus = SendMailHTML("admin", tolist, filelist, sSubject, sBodyHTML, false);
                    #endregion
                }
                else
                    bEmailStatus = true;
            }

            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }
        #endregion

        #region Sales Return Salesman Wise
        public static bool createEmail_SalesReturn_SalesmanWise(enum_Alerts alertType, string sSalesmanID, string sEmailAddress, DateTime dtmToday, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    tbl_genEmployeeMaster oEmployee = tbl_genEmployeeMaster.Select(sSalesmanID);
                    if (oEmployee != null && oEmployee.Employee_ID != "default")
                    {
                        #region Create/Format Email Body
                        DataTable tblEmailHeader = new DataTable();
                        DataTable tblEmailDetail = new DataTable();
                        DataTable tblEmailUND = new DataTable();
                        string sTabKey = System.Convert.ToChar(9).ToString();
                        //  decimal dTotalAmount = 0;
                        List<string> sPendingCheque = new List<string>();
                        ArrayList tolist = new ArrayList();
                        ArrayList filelist = new ArrayList();
                        string sBodyHTML, sSubject = "";// sUser, sBody, sCurrencyCode;

                        // Fill Data for Processing 

                        #region Header
                        tblEmailHeader.Columns.Add("Heading");
                        tblEmailHeader.Columns.Add("Detail");
                        tblEmailHeader.Columns.Add("DataType");

                        DateTime dtmFirstDay = clsSecurity.FirstDayOfMonthFromDateTime(dtmToday);

                        //tblEmailHeader.Rows.Add("Salesman Name ", oEmploye.EmployeeName);
                        tblEmailHeader.Rows.Add("Salesref Name", oEmployee.EmployeeName);
                        tblEmailHeader.Rows.Add("Period ", clsFormatter.FormatDate_Short(dtmFirstDay) + " - " + clsFormatter.FormatDate_Short(dtmToday));
                        tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(dtmToday));
                        #endregion

                        #region Detail
                        tblEmailDetail.Columns.Add("# ");
                        tblEmailDetail.Columns.Add("SRN No");
                        tblEmailDetail.Columns.Add("SRN Date");
                        tblEmailDetail.Columns.Add("DO No");
                        tblEmailDetail.Columns.Add("Customer Name");
                        tblEmailDetail.Columns.Add("Item Name");
                        tblEmailDetail.Columns.Add("QTY");
                        tblEmailDetail.Columns.Add("UOM");
                        tblEmailDetail.Columns.Add("Unit Price");
                        tblEmailDetail.Columns.Add("Return Value");
                        tblEmailDetail.Columns.Add("Remarks");

                        int iCount = 0;
                        //string OldReceiptNo = "";
                        decimal dglbQty = 0, dglbWeight = 0, dglbReturendValue = 0;// dglUnitPrice = 0,
                        DateTime dtmSalseReturnDate = new DateTime();

                        foreach (tbl_sasSalesReturnedNote oReturn in tbl_sasSalesReturnedNote.SelectAll().Where(p => !p.IsDeleted && p.SalesNoteType_ID != "default" && p.SalesReturnedNoteDate.Date >= dtmFirstDay.Date && p.SalesReturnedNoteDate.Date <= dtmToday.Date))//
                        {
                            string sCusustomerName = "", sSalseReturnNo = "", sItemName = "", sDoNo = "", sRemark = "";
                            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(oReturn.Customer_ID);
                            if (oCustomer != null && oCustomer.CustomerCode != "default")
                            {
                                if (oCustomer.SalesRep_ID != oEmployee.Employee_ID)
                                    continue;

                                sRemark = oReturn.Remark.Trim();
                                sDoNo = oReturn.DeliveryOrder_ID;
                                sSalseReturnNo = oReturn.SalesReturnedNote_ID;
                                dtmSalseReturnDate = oReturn.SalesReturnedNoteDate;
                                sCusustomerName = clsGenaralName.getName_Customer(oReturn.Customer_ID);
                                foreach (tbl_sasSalesReturnedNote_Detail oReturneItems in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(sSalseReturnNo).Where(p => p.SalesReturnedNote_ID != "default"))
                                {
                                    sItemName = clsGenaralName.getName_Item(oReturneItems.Item_ID);
                                    decimal dReturnValue = oReturn.IsWeightCalculation ? (oReturneItems.Weight * oReturneItems.KiloPrice) : (oReturneItems.Qty * oReturneItems.UnitPrice);
                                    dglbReturendValue += dReturnValue;
                                    string sQty = oReturn.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_Weight(oReturneItems.Weight) : clsFormatter.FormatDecimalPlaces_Quantity(oReturneItems.Qty);
                                    string sUnitPrice = oReturn.IsWeightCalculation ? clsFormatter.FormatDecimalPlaces_WeightPrice(oReturneItems.KiloPrice) : clsFormatter.FormatDecimalPlaces_UnitPrice(oReturneItems.UnitPrice);
                                    string sUom = clsGenaralName.getName_ItemUOM(oReturneItems.Item_ID);

                                    dglbQty += oReturn.IsWeightCalculation ? 0 : oReturneItems.Qty;
                                    dglbWeight += oReturn.IsWeightCalculation ? oReturneItems.Weight : 0;
                                    iCount++;
                                    tblEmailDetail.Rows.Add(iCount, sSalseReturnNo, clsFormatter.FormatDate_Short(dtmSalseReturnDate), sDoNo, sCusustomerName, sItemName, sQty, sUom, sUnitPrice, clsFormatter.FormatDecimalPlaces_Price(dReturnValue), sRemark);
                                }
                            }
                        }
                        tblEmailDetail.Rows.Add("", "", "", "", "", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(dglbReturendValue), "");

                        tblEmailHeader.Rows.Add("Total Returned Qty ", clsFormatter.FormatDecimalPlaces_Quantity(dglbQty));
                        tblEmailHeader.Rows.Add("Total Returned Weight ", clsFormatter.FormatDecimalPlaces_Weight(dglbWeight));
                        tblEmailHeader.Rows.Add("Total Returned Value ", clsFormatter.FormatDecimalPlaces_Price(dglbReturendValue));
                        #endregion

                        #region Footer
                        tblEmailUND.Columns.Add("heading");
                        tblEmailUND.Columns.Add("details");
                        tblEmailUND.Columns.Add("DataType");
                        //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");
                        tblEmailUND.Rows.Add("*Achieved % = (Total Sales - Total Credit Notes) % Sales Target", "");
                        tblEmailUND.Rows.Add("*in export sales does not reduce VAT & NBT", "");
                        tblEmailUND.Rows.Add("", "");
                        #endregion

                        string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                        string l1 = "";
                        string sEmail_ID = clsFormatter.FormatDate_FullString(dtmToday);
                        if (alertType == enum_Alerts.SheduleAlert_SalseReturn_SalesmanWise)
                        {
                            l1 = " Sales Return Salesman Wise";
                            sSubject = "SEACC Alert : Sales Return [" + oEmployee.EmployeeName + "] As At: " + clsFormatter.FormatDate_Short(dtmToday) + "  "; //todo
                        }

                        sBodyHTML = CreateEmailBody(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail, tblEmailUND);
                        #endregion

                        #region Send Email
                        bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                        //tbl_utlAlert_EMail oAlert_Email = new tbl_utlAlert_EMail(sEmail_ID, oAlert.Alert_ID, sSubject, sBodyHTML);
                        //oAlert_Email.Insert();

                        //tolist.Add(sEmailAddress);
                        //bEmailStatus = SendMailHTML("admin", tolist, filelist, sSubject, sBodyHTML, false);
                        #endregion
                    }
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }
        #endregion

        #region Daily Section Planing
        public static bool createEmail_DailySectionPlan(enum_Alerts alertType, DateTime dtmToday, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    #region Create/Format Email Body
                    DataTable tblEmailHeader = new DataTable();
                    DataTable tblEmailDetail = new DataTable();
                    DataTable tblEmailUND = new DataTable();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";//sUser, sBody,  sCurrencyCode;

                    // Fill Data for Processing 

                    #region Header
                    tblEmailHeader.Columns.Add("Heading");
                    tblEmailHeader.Columns.Add("Detail");
                    tblEmailHeader.Columns.Add("DataType");

                    tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(dtmToday));
                    #endregion

                    #region Detail
                    tblEmailDetail.Columns.Add("# ");
                    tblEmailDetail.Columns.Add("Job No");
                    tblEmailDetail.Columns.Add("Customer Name");
                    tblEmailDetail.Columns.Add("Item Name");
                    tblEmailDetail.Columns.Add("QTY");
                    tblEmailDetail.Columns.Add("UOM");
                    tblEmailDetail.Columns.Add("Section Capacity");
                    tblEmailDetail.Columns.Add("Total QTY");
                    tblEmailDetail.Columns.Add("Balance Qty");


                    //  int iCount = 0;
                    //  string OldReceiptNo = "";
                    // decimal dglbQty = 0, dglbWeight = 0, dglUnitPrice = 0, dglbReturendValue = 0;
                    // DateTime dtmSalseReturnDate = new DateTime();                    
                    foreach (tbl_genSectionMaster oSection in tbl_genSectionMaster.SelectAll().Where(p => p.Section_ID != "default"))
                    {
                        decimal dQty = 0;
                        List<tmpSectionPlan> oTmpSectionPlans = new List<tmpSectionPlan>();
                        foreach (tbl_pmsSectionPlan_Master detail in tbl_pmsSectionPlan_Master.SelectAllBySection_ID(oSection.Section_ID).Where(p => p.SectionPlanDate.Date == dtmToday.Date))
                        {
                            tbl_pmsProductionJobRegister oJob = tbl_pmsProductionJobRegister.Select(detail.Job_ID);
                            if (oJob != null && oJob.ProductionJob_ID != "default")
                            {
                                tmpSectionPlan oTmpPlan = new tmpSectionPlan();
                                oTmpPlan.sJobNo = detail.Job_ID;
                                oTmpPlan.sItemName = clsGenaralName.getName_Item(detail.Item_ID);
                                oTmpPlan.sCustomerName = clsGenaralName.getName_Customer(oJob.Customer_ID);
                                oTmpPlan.dQty = detail.Qty;
                                oTmpPlan.sUom = clsGenaralName.getName_ItemUOM(detail.Item_ID);
                                oTmpSectionPlans.Add(oTmpPlan);
                                dQty += oTmpPlan.dQty;
                            }
                        }
                        if (oTmpSectionPlans.Count > 0)
                        {
                            int iNo = 1;
                            decimal dBalanceQty = 0;
                            dBalanceQty = (oSection.Sectioncapacity - dQty);
                            tblEmailDetail.Rows.Add("", "", "", clsGenaralName.getName_Section(oSection.Section_ID), "", "", clsFormatter.FormatDecimalPlaces_Price(oSection.Sectioncapacity), clsFormatter.FormatDecimalPlaces_Price(dQty), clsFormatter.FormatDecimalPlaces_Price(dBalanceQty));
                            foreach (tmpSectionPlan oSectionPlan in oTmpSectionPlans)
                            {
                                tblEmailDetail.Rows.Add(iNo, oSectionPlan.sJobNo, oSectionPlan.sCustomerName, oSectionPlan.sItemName, clsFormatter.FormatDecimalPlaces_Price(oSectionPlan.dQty), oSectionPlan.sUom, "", "", "");
                                iNo++;

                            }
                            tblEmailDetail.Rows.Add("", "", "", "", "", "", "", "");
                        }
                    }
                    //tblEmailHeader.Rows.Add("Total Returned Qty ", clsFormatter.FormatDecimalPlaces_Quantity(dglbQty));
                    //tblEmailHeader.Rows.Add("Total Returned Weight ", clsFormatter.FormatDecimalPlaces_Weight(dglbWeight));
                    //tblEmailHeader.Rows.Add("Total Returned Value ", clsFormatter.FormatDecimalPlaces_Price(dglbReturendValue));
                    #endregion

                    #region Footer
                    tblEmailUND.Columns.Add("heading");
                    tblEmailUND.Columns.Add("details");
                    tblEmailUND.Columns.Add("DataType");

                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("", "");
                    #endregion

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(dtmToday);
                    if (alertType == enum_Alerts.DailySectionPlan)
                    {
                        l1 = " Daily Section Plan";
                        sSubject = "SEACC Alert : Daily Section Plan For [" + clsFormatter.FormatDate_Short(dtmToday) + "]";
                    }

                    sBodyHTML = CreateEmailBody(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail, tblEmailUND);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    ////tbl_utlAlert_EMail oAlert_Email = new tbl_utlAlert_EMail(sEmail_ID, oAlert.Alert_ID, sSubject, sBodyHTML);
                    ////oAlert_Email.Insert();
                    //foreach (tbl_utlAlertSettings oAlertSetting in tbl_utlAlertSettings.SelectAllByAlert_ID(oAlert.Alert_ID))
                    //{
                    //    if (oAlertSetting.UserEmail1.Length > 0)
                    //        tolist.Add(oAlertSetting.UserEmail1);
                    //}
                    //bEmailStatus = SendMailHTML("admin", tolist, filelist, sSubject, sBodyHTML, false);
                    #endregion
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }
        #endregion

        #region Cheque In Hand
        public static bool createEmail_ChequeInHand(enum_Alerts alertType, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    #region Create/Format Email Body
                    DataTable tblEmailHeader = new DataTable();
                    DataTable tblEmailDetail = new DataTable();
                    DataTable tblEmailUND = new DataTable();
                    string sTabKey = System.Convert.ToChar(9).ToString();
                    decimal sTotalAmount = 0;
                    List<string> sPendingCheque = new List<string>();
                    ArrayList tolist = new ArrayList();
                    ArrayList filelist = new ArrayList();
                    string sBodyHTML, sSubject = "";

                    // Fill Data for Processing 

                    #region Header
                    tblEmailHeader.Columns.Add("heading");
                    tblEmailHeader.Columns.Add("detail");
                    tblEmailHeader.Columns.Add("DataType");
                    tblEmailHeader.Rows.Add("Alert Date ", clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()));
                    #endregion

                    #region Detail
                    tblEmailDetail.Columns.Add("# ");
                    tblEmailDetail.Columns.Add("ChequeDate");
                    tblEmailDetail.Columns.Add("ChequeNo");
                    tblEmailDetail.Columns.Add("CustomerName");
                    tblEmailDetail.Columns.Add("ReceiptDate");
                    tblEmailDetail.Columns.Add("RecceiptAmount", typeof(decimal));
                    tblEmailDetail.Columns.Add("CreditPeriod");
                    tblEmailDetail.Columns.Add("OverdueDays");
                    int i = 1;
                    foreach (tbl_bpsChequeRegister oCheque in tbl_bpsChequeRegister.SelectAll().Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default" && !p.IsDepositted && !p.IsReturned).OrderBy(p => p.DateCheque))
                    {
                        if (oCheque.PaymentMethod_ID == (int)PaymentMethod.Cheque)
                        {
                            DateTime dtmOldestInvDate = clsSecurity.getServerDateTime().Date;
                            bool bIsNoInvAllocatged = true;
                            foreach (tbl_sasInvoice_Sattled oInvSettel in tbl_sasInvoice_Sattled.SelectAllByChequeRegister_ID(oCheque.ChequeRegister_ID))
                            {
                                bIsNoInvAllocatged = false;
                                tbl_sasInvoice oInv = tbl_sasInvoice.Select(oInvSettel.Invoice_ID);
                                if (oInv != null && oInv.Invoice_ID != "default")
                                {
                                    if (dtmOldestInvDate.Date > oInv.InvoiceDate.Date)
                                        dtmOldestInvDate = oInv.InvoiceDate;
                                }
                            }
                            string ChequeDate = clsFormatter.FormatDate_Short(oCheque.DateCheque);
                            string ChequeNo = oCheque.ChequeNumber;
                            string CustomerName = clsGenaralName.getName_Customer(oCheque.Customer_ID);
                            string ReceiptDate = clsFormatter.FormatDate_Short(oCheque.DateRegister);
                            string RecceiptAmount = clsFormatter.FormatDecimalPlaces_Price(oCheque.Amount);
                            string CreditPeriod = clsFormatter.FormatToNumberNoDecimal(clsMethods_Fin.GetCustomerCreditPeriod(oCheque.Customer_ID));
                            string OverdueDays = !bIsNoInvAllocatged ? clsFormatter.FormatToNumberNoDecimal((decimal)(clsSecurity.getServerDateTime().Date - dtmOldestInvDate.Date).TotalDays) : "0";

                            sTotalAmount += oCheque.Amount;

                            tblEmailDetail.Rows.Add(i, ChequeDate, ChequeNo, CustomerName, ReceiptDate, RecceiptAmount, CreditPeriod, OverdueDays);
                            i++;
                        }
                    }
                    tblEmailDetail.Rows.Add("", "", "", "", "", clsFormatter.FormatDecimalPlaces_Price(sTotalAmount), "", "");
                    #endregion

                    #region Footer
                    tblEmailUND.Columns.Add("heading");
                    tblEmailUND.Columns.Add("details");
                    tblEmailUND.Columns.Add("DataType");
                    //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");  
                    tblEmailUND.Rows.Add("", "");
                    tblEmailUND.Rows.Add("", "");
                    #endregion

                    string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                    string l1 = "";
                    string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
                    if (alertType == enum_Alerts.ChequeInHand)//
                    {
                        l1 = " Cheque In Hand";
                        sSubject = "SEACC Alert :  Cheque In Hand As At: " + clsFormatter.FormatDate_Short(clsSecurity.getServerDateTime()) + "  "; //todo
                    }

                    sBodyHTML = CreateEmailBody(sEmail_ID, Name, l1, tblEmailHeader, tblEmailDetail, tblEmailUND);
                    #endregion

                    #region Send Email
                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    //tbl_utlAlert_EMail oAlert_Email = new tbl_utlAlert_EMail(sEmail_ID, oAlert.Alert_ID, sSubject, sBodyHTML);
                    //oAlert_Email.Insert();
                    //foreach (tbl_utlAlertSettings oAlertSetting in tbl_utlAlertSettings.SelectAllByAlert_ID(oAlert.Alert_ID))
                    //{
                    //    if (oAlertSetting.UserEmail1.Length > 0)
                    //        tolist.Add(oAlertSetting.UserEmail1);
                    //}
                    //bEmailStatus = SendMailHTML("admin", tolist, filelist, sSubject, sBodyHTML, false);
                    #endregion
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }
        #endregion

        #region Outsanding Statement - Customer Wise
        public static bool createEmail_CustomerOutstandingStatement(enum_Alerts alertType, string sCustomerID, string sEmailAddress, DateTime dtmToday, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(sCustomerID);
                    if (oCustomer != null && oCustomer.Customer_ID != "default")
                    {
                        #region Create/Format Email Body
                        DataTable tblEmailHeader = new DataTable();
                        DataTable tblEmailDetail = new DataTable();
                        DataTable tblEmailUND = new DataTable();
                        string sTabKey = System.Convert.ToChar(9).ToString();
                        // decimal dTotalAmount = 0;
                        List<string> sPendingCheque = new List<string>();
                        ArrayList tolist = new ArrayList();
                        ArrayList filelist = new ArrayList();
                        string sBodyHTML, sSubject = "";// sUser, sBody, sCurrencyCode;

                        List<emailLine> lstEData = new List<emailLine>();
                        EmailLineformating oEmailLineFormat = new EmailLineformating();

                        #region Detail
                        //  DataTable tblEmailDetail = new DataTable();
                        List<emailLine> lstEmailDetail = new List<emailLine>();

                        lstEmailDetail.Add(new emailLine(LineType.TableColomn1, "#"));
                        lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Narration"));
                        lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Doc/Cheq#"));
                        lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Doc/Cheq Date"));
                        lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Outstanding Amount"));
                        lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Aging Days"));

                        #endregion

                        #region Detail
                        tblEmailDetail.Columns.Add("# ");
                        tblEmailDetail.Columns.Add("Narration");
                        tblEmailDetail.Columns.Add("Doc/Cheq#");
                        tblEmailDetail.Columns.Add("Doc/Cheq Date");
                        tblEmailDetail.Columns.Add("Outstanding Amount", typeof(decimal));
                        tblEmailDetail.Columns.Add("Aging Days", typeof(int));

                        int i = 0;
                        decimal dTotalOutstanding = 0;
                        var oDetails = srh_bssCustomerOutstanding.SelectAllByCustomerId(sCustomerID, "", Convert.ToDateTime("01/01/2001"), clsSecurity.getServerDateTime(), true);
                        foreach (srh_bssCustomerOutstanding oDetail in oDetails)
                        {
                            if (oDetail.TransactionType != 5) // ignore cheque in hand
                            {
                                string sRemark = "";
                                sRemark = oDetail.TransactionType == 2 ? "Invoice For " + oDetail.DeliveryOrder_ID + " " :
                                    oDetail.TransactionType == 7 ? "Unsettle Payment " : "";

                                i++;
                                tblEmailDetail.Rows.Add(i, sRemark, oDetail.Transaction_ID, clsFormatter.FormatDate_Short(oDetail.TransactionDate), clsFormatter.FormatDecimalPlaces_Price(oDetail.TransactionAmount), oDetail.Age);
                                dTotalOutstanding += oDetail.Outstanding;
                            }
                        }
                        //tblEmailDetail.Rows.Add("", "", "", clsFormatter.FormatDecimalPlaces_Price(dglbTotalSales), clsFormatter.FormatDecimalPlaces_Price(dglbTotalCreditNote), clsFormatter.FormatDecimalPlaces_Price(dglbTotalValue), clsFormatter.FormatDecimalPlaces_Price(dglbTotalCash), clsFormatter.FormatDecimalPlaces_Price(dglbTotalCheque), clsFormatter.FormatDecimalPlaces_Price(dglbTotalOrders), clsFormatter.FormatDecimalPlaces_Price(dglbSalesReturnValue));

                        tblEmailDetail.Rows.Add("", "", "", "", dTotalOutstanding, 0);
                        #endregion

                        #region Footer
                        tblEmailUND.Columns.Add("heading");
                        tblEmailUND.Columns.Add("details");
                        tblEmailUND.Columns.Add("DataType");
                        //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");                       
                        tblEmailUND.Rows.Add("", "");
                        #endregion

                        lstEData.Add(new emailLine(LineType.H2, clsSecurity.CompanyName));
                        lstEData.Add(new emailLine(LineType.H2, clsSecurity.CompanyAddress1));
                        lstEData.Add(new emailLine(LineType.H2, clsSecurity.CompanyAddress2));
                        lstEData.Add(new emailLine(LineType.H2, "OUTSTANDING STATEMENT"));
                        lstEData.Add(new emailLine(LineType.Line1));
                        lstEData.Add(new emailLine(LineType.Detail2, "", ""));
                        lstEData.Add(new emailLine(LineType.Detail2, "Company Name", oCustomer.CustomerName));
                        lstEData.Add(new emailLine(LineType.Detail2, "Company Address", oCustomer.AddressRegister));
                        lstEData.Add(new emailLine(LineType.Detail2, "", ""));
                        lstEData.Add(new emailLine(LineType.Detail2, "", ""));
                        lstEData.Add(new emailLine(LineType.H4, "Dear Customer,"));
                        lstEData.Add(new emailLine(LineType.H4, "Please find below your Outstanding amounts. Appreaciate very much if you could make immediate arrangements to settle all dues:"));
                        lstEData.Add(new emailLine(LineType.DataTable, tblEmailDetail, lstEmailDetail));
                        lstEData.Add(new emailLine(LineType.Detail2, "", ""));
                        lstEData.Add(new emailLine(LineType.H4, "TOTAL OUTSTANDING : " + clsFormatter.FormatDecimalPlaces_Price(dTotalOutstanding)));
                        lstEData.Add(new emailLine(LineType.Line1));
                        lstEData.Add(new emailLine(LineType.H5, "Sofrware By : " + clsSecurity.DigiteqName));

                        string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                        string sEmail_ID = clsFormatter.FormatDate_FullString(dtmToday);
                        sSubject = "SEACC Alert : Outstanding Statement [" + oCustomer.CustomerName.Trim() + "] As At: " + clsFormatter.FormatDate_Short(dtmToday) + "  "; //todo
                        sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);
                        #endregion

                        #region Send Email
                        bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                        //tbl_utlAlert_EMail oAlert_Email = new tbl_utlAlert_EMail(sEmail_ID, oAlert.Alert_ID, sSubject, sBodyHTML);
                        //oAlert_Email.Insert();

                        //tolist.Add(sEmailAddress);
                        //bEmailStatus = SendMailHTML("admin", tolist, filelist, sSubject, sBodyHTML, false);
                        #endregion
                    }
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }

        public static bool createEmail_CustomerOutstandingStatement_ToCustomer(enum_Alerts alertType, string sCustomerID, string sEmailAddress, DateTime dtmToday, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(sCustomerID);
                    if (oCustomer != null && oCustomer.Customer_ID != "default")
                    {
                        #region Create/Format Email Body
                        DataTable tblEmailHeader = new DataTable();
                        DataTable tblEmailDetail = new DataTable();
                        DataTable tblEmailUND = new DataTable();
                        string sTabKey = System.Convert.ToChar(9).ToString();
                        // decimal dTotalAmount = 0;
                        List<string> sPendingCheque = new List<string>();
                        ArrayList tolist = new ArrayList();
                        ArrayList filelist = new ArrayList();
                        string sBodyHTML, sSubject = "";// sUser, sBody, sCurrencyCode;

                        List<emailLine> lstEData = new List<emailLine>();
                        EmailLineformating oEmailLineFormat = new EmailLineformating();

                        #region Detail
                        //  DataTable tblEmailDetail = new DataTable();
                        List<emailLine> lstEmailDetail = new List<emailLine>();

                        lstEmailDetail.Add(new emailLine(LineType.TableColomn1, "#"));
                        lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Narration"));
                        lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Doc #"));
                        lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Doc Date"));
                        lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Outstanding Amount"));
                        lstEmailDetail.Add(new emailLine(LineType.TableColomn2, "Aging"));

                        #endregion

                        #region Detail
                        tblEmailDetail.Columns.Add("# ");
                        tblEmailDetail.Columns.Add("Narration");
                        tblEmailDetail.Columns.Add("Doc #");
                        tblEmailDetail.Columns.Add("Doc Date");
                        tblEmailDetail.Columns.Add("Outstanding Amount", typeof(decimal));
                        tblEmailDetail.Columns.Add("Aging", typeof(int));

                        int i = 0;
                        decimal dTotalOutstanding = 0;
                        var oDetails = srh_bssCustomerOutstanding.SelectAllByCustomerId(sCustomerID, "", Convert.ToDateTime("01/01/2001"), clsSecurity.getServerDateTime(), true);
                        foreach (srh_bssCustomerOutstanding oDetail in oDetails)
                        {
                            if (oDetail.TransactionType != 5) // ignore cheque in hand
                            {
                                string sRemark = "";
                                sRemark = oDetail.TransactionType == 2 ? "Invoice For " + oDetail.DeliveryOrder_ID + " " :
                                    oDetail.TransactionType == 7 ? "Unsettle Payment " : "";

                                tbl_genCustomerFinance oCusFinance = tbl_genCustomerFinance.Select(sCustomerID);
                                if (oDetail.Age >= oCusFinance.CreditPeriod)
                                {
                                    if (oDetail.TransactionAmount == 0)
                                        continue;
                                    i++;
                                    tblEmailDetail.Rows.Add(i, sRemark, oDetail.Transaction_ID, clsFormatter.FormatDate_Short(oDetail.TransactionDate), clsFormatter.FormatDecimalPlaces_Price(oDetail.TransactionAmount), oDetail.Age);
                                    dTotalOutstanding += oDetail.Outstanding;
                                }
                            }
                        }
                        //tblEmailDetail.Rows.Add("", "", "", clsFormatter.FormatDecimalPlaces_Price(dglbTotalSales), clsFormatter.FormatDecimalPlaces_Price(dglbTotalCreditNote), clsFormatter.FormatDecimalPlaces_Price(dglbTotalValue), clsFormatter.FormatDecimalPlaces_Price(dglbTotalCash), clsFormatter.FormatDecimalPlaces_Price(dglbTotalCheque), clsFormatter.FormatDecimalPlaces_Price(dglbTotalOrders), clsFormatter.FormatDecimalPlaces_Price(dglbSalesReturnValue));

                        //tblEmailDetail.Rows.Add("", "", "", "", dTotalOutstanding, 0);
                        #endregion

                        if (dTotalOutstanding > 0)
                        {
                            #region Footer
                            tblEmailUND.Columns.Add("heading");
                            tblEmailUND.Columns.Add("details");
                            tblEmailUND.Columns.Add("DataType");
                            //tblEmailUND.Rows.Add("Total Amount", sTotalAmount, "n");                       
                            tblEmailUND.Rows.Add("", "");
                            #endregion

                            lstEData.Add(new emailLine(LineType.H2, clsSecurity.CompanyName));
                            lstEData.Add(new emailLine(LineType.H2, clsSecurity.CompanyAddress1));
                            lstEData.Add(new emailLine(LineType.H2, clsSecurity.CompanyAddress2));
                            lstEData.Add(new emailLine(LineType.H2, "OUTSTANDING STATEMENT"));
                            lstEData.Add(new emailLine(LineType.Line1));
                            lstEData.Add(new emailLine(LineType.Detail2, "", ""));
                            lstEData.Add(new emailLine(LineType.Detail2, "Customer Name", oCustomer.CustomerName));
                            lstEData.Add(new emailLine(LineType.Detail2, "Customer Address", oCustomer.AddressRegister));
                            lstEData.Add(new emailLine(LineType.Detail2, "", ""));
                            lstEData.Add(new emailLine(LineType.Detail2, "", ""));
                            lstEData.Add(new emailLine(LineType.H4, "Dear Customer,"));
                            lstEData.Add(new emailLine(LineType.H4, "Please find your Outstanding amounts below. Immediate settlements for the dues are highly appreciated."));
                            lstEData.Add(new emailLine(LineType.DataTable, tblEmailDetail, lstEmailDetail));
                            lstEData.Add(new emailLine(LineType.Detail2, "", ""));
                            lstEData.Add(new emailLine(LineType.H4, "TOTAL OUTSTANDING : " + clsFormatter.FormatDecimalPlaces_Price(dTotalOutstanding)));
                            lstEData.Add(new emailLine(LineType.Line1));
                            lstEData.Add(new emailLine(LineType.H5, "Sofrware By : " + clsSecurity.DigiteqName));

                            string Name = clsCommon.fncsetstring(clsSecurity.CompanyName);
                            string sEmail_ID = clsFormatter.FormatDate_FullString(dtmToday);
                            sSubject = "SEACC Alert : Outstanding Statement [" + oCustomer.CustomerName.Trim() + "] As At: " + clsFormatter.FormatDate_Short(dtmToday) + "  "; //todo
                            sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);
                            #endregion

                            #region Send Email
                            bEmailStatus = SaveMailHTML_ToCustomer(sAlertID, sSubject, sBodyHTML, sEmailAddress, oCustomer.CustomerName);
                            #endregion
                        }
                    }
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , 0,ex);
            }
            finally
            {
                if (bEmailStatus)
                    clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }
        #endregion

        #region POS Schedule Alerts

        //public static bool createEmail_POSDetail(int iSchedule_ID, enum_Alerts alertType, string sCompanyBranchID)
        //{
        //    bool bEmailStatus = false;
        //    string sAlertID = "";

        //    try
        //    {
        //        sAlertID = clsAutocode.getAlertID(alertType);
        //        tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);

        //        if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
        //        {
        //            DataSets_Alerts.dts_POS glb_dtsPosStd = new DataSets_Alerts.dts_POS();
        //            tbl_securityFunctionMaster_Report oReport = tbl_securityFunctionMaster_Report.Select((int)enum_ReportName.POS_TransactionDetail);
        //            if (oReport != null)
        //            {
                        
        //                #region Attachment Generate
        //                List<tbl_posTransaction> oPosTrans = oPosTrans = tbl_posTransaction.SelectAllByCompanyBranch_ID(sCompanyBranchID).Where(p => p.PosTransactiondate.Date == clsSecurity.getServerDateTime().Date && !p.IsHold && !p.IsDeleted).ToList();
        //                foreach (tbl_posTransaction oPosTran in oPosTrans)
        //                {
        //                    #region Header
        //                    glb_dtsPosStd.dt_pos_transaction.Adddt_pos_transactionRow(oPosTran.PosTransaction_ID, oPosTran.PosTransactiondate, oPosTran.Remark,
        //                                                        oPosTran.Customer_ID != "default" ? oPosTran.Customer_ID : "-", clsGenaralName.getName_Customer(oPosTran.Customer_ID), oPosTran.Store_ID, clsGenaralName.getName_Store(oPosTran.Store_ID),
        //                                                        oPosTran.OrderRefNo_ID, oPosTran.Currency_ID, clsGenaralName.getName_CurrencyCode(oPosTran.Currency_ID), oPosTran.CurrencyRate,
        //                                                        oPosTran.DiscountPercentage, oPosTran.NbtPercentage, oPosTran.VatPercentage, oPosTran.OtherTaxPercentage, oPosTran.SubTotal, oPosTran.DiscountTotal, oPosTran.NbtTotal, oPosTran.VatTotal, oPosTran.OtherTaxTotal, oPosTran.GrandTotal,
        //                                                        oPosTran.CreateUser_ID, oPosTran.CompanyBranch_ID != null ? clsGenaralName.getName_CompanyBranchMaster(oPosTran.CompanyBranch_ID) : "-",
        //                                                        oPosTran.CreateTerminal_ID, "", oPosTran.DayDetail_Index);
        //                    #endregion

        //                    #region Detail
        //                    List<tbl_posTransaction_Detail> details = tbl_posTransaction_Detail.SelectAllByPosTransaction_Index(oPosTran.PosTransaction_Index).OrderBy(p => p.Line_No).ToList();
        //                    foreach (tbl_posTransaction_Detail detail in details)
        //                    {
        //                        glb_dtsPosStd.dt_pos_transation_details.Adddt_pos_transation_detailsRow(detail.Line_No, oPosTran.PosTransaction_ID, detail.Item_ID, "", "", "", "", "0", "0",
        //                            clsGenaralName.getName_Item(detail.Item_ID), detail.Remark, clsGenaralName.getName_ItemUOM(detail.Item_ID),
        //                            detail.Qty, detail.Weight, detail.UnitPrice, detail.WeightPrice, detail.NetAmount,
        //                            detail.LineDiscountPresentage, detail.LineDiscountTotal, detail.GrossAmount);
        //                    }
        //                    #endregion
        //                }
                        
        //                #region Set company Details
        //                tbl_genCompanyBranchMaster oBranchMaster = tbl_genCompanyBranchMaster.Select(sCompanyBranchID);
        //                var vCompanyImage = getCompanyImage(clsSecurity.CompanyID);
        //                glb_dtsPosStd.dt_Company.Adddt_CompanyRow(
        //                    clsSecurity.DigiteqName,
        //                    clsSecurity.DigiteqEmail,
        //                    clsSecurity.CompanyName,
        //                    clsSecurity.CompanyAddress1,
        //                    clsSecurity.CompanyAddress2,
        //                    vCompanyImage,
        //                    vCompanyImage,
        //                    vCompanyImage,
        //                    oReport.DisplayName,
        //                    oReport.DisplayName2,
        //                    clsSecurity.getServerDateTime().ToString("yyyy-MMM-dd"),
        //                    clsSecurity.UserNameLoged,
        //                    "",
        //                    clsCommon.getCompanyBusinessRegisterNo(),
        //                    clsCommon.getCompanyVAT(),
        //                    ("BRANCH :" + oBranchMaster.BranchName.ToUpper()),
        //                    oBranchMaster.Adress.ToUpper(),
        //                    ("TEL: " + oBranchMaster.Telephone.ToUpper() + " FAX: " + oBranchMaster.Fax.ToUpper())
        //                    );
        //                #endregion

        //                string sReportGenerationPath = PDF_Export(oReport.ReportPath, glb_dtsPosStd);
        //                clsValidate.WriteErrorLog(sAlertID + " - " + alertType.ToString() + " - Report Export Successfully -"+ clsSecurity.getServerDateTime(), -1,null);
        //                #endregion

        //                List<emailLine> lstEData = new List<emailLine>();
        //                EmailLineformating oEmailLineFormat = new EmailLineformating();

        //                string sBodyHTML = "";
        //                string sSubject = "SEACC E-Mail Alert : POS Detail " + clsSecurity.getServerDateTime().Date.ToString("yyyy-MMM-dd");
        //                string sEmail_ID = clsFormatter.FormatDate_FullString(clsSecurity.getServerDateTime());
        //                sBodyHTML = clsEmailConfig.CreateEmailBody(lstEData);

        //                #region Send Email
        //                bEmailStatus = SaveMailHTML_Attachment(sAlertID, sSubject, sBodyHTML, sReportGenerationPath);
        //                clsValidate.WriteErrorLog(sAlertID + " - " + alertType.ToString() + (bEmailStatus ? " Generated Succesfully " : "Generation Failed"), -1,null);
        //                #endregion
        //            }
        //        }
        //        else
        //            bEmailStatus = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        clsValidate.WriteErrorLog("Error - " + iSchedule_ID + ", " + sAlertID + " - " + alertType.ToString() , 0,ex);
        //    }
        //    finally
        //    {
        //        if (bEmailStatus)
        //            clsSecurity.UpdateAlertSentTime(iSchedule_ID, alertType, sAlertID, bEmailStatus, sCompanyBranchID);
        //    }

        //    return bEmailStatus;
        //}

        #region Help Method for Report Generation
        private static string PDF_Export(string sRptFilePath, DataSet ReportDataSet)
        {
            string returnPath = "";
            if (!clsConfig.bProductActivated)
            {
                MessageBox.Show("Software has been expired", "Please contact 'hepldesk@digiteq.biz' Unless reports can't be generated ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                try
                {
                    string s_Path = "";
                    ReportDocument objRpt = new ReportDocument();

                    s_Path = Application.StartupPath.Replace("\\bin\\Debug", "");
                    s_Path += sRptFilePath;

                    objRpt.Load(s_Path);
                    objRpt.SetDataSource(ReportDataSet);

                    #region Set Server Detail for Report
                    ConnectionInfo connInfo = new ConnectionInfo();
                    connInfo.IntegratedSecurity = false;
                    TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
                    tableLogOnInfo.ConnectionInfo = connInfo;
                    objRpt.SetDatabaseLogon(connInfo.UserID, connInfo.Password, connInfo.ServerName, connInfo.DatabaseName, true);
                    objRpt.VerifyDatabase();
                    #endregion

                    DateTime dtmSvrDate = clsSecurity.getServerDateTime();
                    returnPath = clsConfig.sPOSAttachmentPath_Server + "POSDetails" + "-" + dtmSvrDate.Year + dtmSvrDate.Month + dtmSvrDate.Day + "-" + dtmSvrDate.Hour + dtmSvrDate.Minute + dtmSvrDate.Second + ".pdf";
                    objRpt.ExportToDisk(ExportFormatType.PortableDocFormat, returnPath);
                    clsValidate.WriteErrorLog(" Report Generation Successfully (" + returnPath + ")", -1,null);

                    objRpt.Close();
                    objRpt.Dispose();
                }
                catch (Exception ex)
                {
                    clsValidate.WriteErrorLog(" Report Generation Failed (" + sRptFilePath + ") - " , -1,ex);
                }
            }
            return returnPath;
        }

        public static byte[] getCompanyImage(string sCopmayID)
        {
            byte[] sCompanyImage = null;
            tbl_genCompanyImage comI = tbl_genCompanyImage.Select(sCopmayID);
            if (comI != null)
                sCompanyImage = comI.MainLogo;

            return sCompanyImage;
        }
        #endregion

        #endregion

        #endregion

        #region Create Email Body
        public static string CreateEmailBody(string EmailId, string Title, string sHeading, DataTable tHeader, DataTable tDetail, DataTable tFooter)
        {

            // string sBodyHTML;
            StringBuilder sb = new StringBuilder();
            sb.Append("<H3 align=\"Center\" ><font size=\"3\" color=\"#515355\">" + Title + "</font> </H3>");
            sb.Append("<H3 align=\"Center\" ><font size=\"2\" color=\"#515355\">" + sHeading + "</font> </H3>");

            sb.Append("<HR>");

            #region Header
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            foreach (DataRow dr in tHeader.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else
                    sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "n")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            #endregion

            if (tDetail != null)
            {
                sb.Append("<p></p>");
                #region Details
                sb.Append(" <table border=\"1px\" color=\"#0B0B61\" CELLPADDING=\"3\">");
                sb.Append("<tr>");
                foreach (DataColumn dc in tDetail.Columns)
                {
                    sb.Append("<th> <font size=\"1.5\" color=\"#5C0000\">  &nbsp;" + dc.ColumnName + "&nbsp;  </font> </th>");
                }
                sb.Append("</tr>");

                foreach (DataRow dr in tDetail.Rows)
                {
                    sb.Append("<tr>");
                    foreach (DataColumn column in tDetail.Columns)
                    {
                        sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  &nbsp;" + dr[column].ToString() + "&nbsp;  </font> </td>");

                    }
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                #endregion
                sb.Append("<p></p>");
            }
            else
            {

            }

            //new method
            if (tFooter != null)
            {
                //sb.Append("<p></p>");
                #region Details
                sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
                foreach (DataRow dr in tFooter.Rows)
                {
                    sb.Append("<tr>");
                    sb.Append("<td> <font size=\"1\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                    if (dr[0].ToString() == "")
                        sb.Append("<td><font size=\"1\" color=\"#515355\">  </font></td>");
                    else
                        sb.Append("<td><font size=\"1\" color=\"#515355\"> : </font></td>");
                    sb.Append("<td> <b><font size=\"1\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                #endregion
                sb.Append("<p></p>");
                //sb.Append("<tr>");
                //foreach (DataColumn dc in tFooter.Columns)
                //{
                //    sb.Append("<th> <font size=\"1.5\" color=\"#5C0000\">  &nbsp;" + dc.ColumnName + "&nbsp;  </font> </th>");
                //}
                //sb.Append("</tr>");

                //foreach (DataRow dr in tFooter.Rows)
                //{
                //    sb.Append("<tr>");
                //    foreach (DataColumn column in tFooter.Columns)
                //    {
                //        sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  &nbsp;" + dr[column].ToString() + "&nbsp;  </font> </td>");

                //    } sb.Append("</tr>");
                //}
                //sb.Append("</table>");
                //#endregion
                //sb.Append("<p></p>");
            }




            //#region User Details
            //sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            //foreach (DataRow dr in tFooter.Rows)
            //{
            //    sb.Append("<tr>");
            //    sb.Append("<td> <font size=\"1\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
            //    if (dr[0].ToString() == "")
            //        sb.Append("<td><font size=\"1\" color=\"#515355\">  </font></td>");
            //    else
            //        sb.Append("<td><font size=\"1\" color=\"#515355\"> : </font></td>");
            //    sb.Append("<td> <b><font size=\"1\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
            //    sb.Append("</tr>");
            //}
            //sb.Append("</table>");
            //#endregion

            sb.Append("<HR>");
            sb.Append("<p><b><font size=\"1\" color=\"#80878E\">Email Ref No : " + EmailId + "</font></b></p>");
            return sb.ToString();
        }
        public static string CreateEmailBody_GenearlStatus(string EmailId, string Title, string sHeading, DataTable tHeader, DataTable tDetail1, DataTable tDetail2, DataTable tDetail3, DataTable tDetail4, DataTable tDetail5, DataTable tFooter)
        {

            // string sBodyHTML;
            StringBuilder sb = new StringBuilder();
            sb.Append("<H3 align=\"Center\" ><font size=\"3\" color=\"#515355\">" + Title + "</font> </H3>");
            sb.Append("<H3 align=\"Center\" ><font size=\"2\" color=\"#515355\">" + sHeading + "</font> </H3>");

            sb.Append("<HR>");

            #region Header
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            foreach (DataRow dr in tHeader.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else
                    sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "n")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");

            #endregion

            if (tDetail1 != null)
            {
                sb.Append("<p></p>");
                #region Details
                sb.Append(" <table border=\"1px\" color=\"#0B0B61\" CELLPADDING=\"3\">");
                sb.Append("<tr>");
                foreach (DataColumn dc in tDetail1.Columns)
                {
                    sb.Append("<th> <font size=\"1.5\" color=\"#5C0000\">  &nbsp;" + dc.ColumnName + "&nbsp;  </font> </th>");
                }
                sb.Append("</tr>");

                foreach (DataRow dr in tDetail1.Rows)
                {
                    sb.Append("<tr>");
                    foreach (DataColumn column in tDetail1.Columns)
                    {
                        sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  &nbsp;" + dr[column].ToString() + "&nbsp;  </font> </td>");

                    }
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                #endregion
                sb.Append("<p></p>");
            }

            if (tDetail2 != null)
            {
                sb.Append("<p></p>");
                #region Details
                sb.Append(" <table border=\"1px\" color=\"#0B0B61\" CELLPADDING=\"3\">");
                sb.Append("<tr>");
                foreach (DataColumn dc in tDetail2.Columns)
                {
                    sb.Append("<th> <font size=\"1.5\" color=\"#5C0000\">  &nbsp;" + dc.ColumnName + "&nbsp;  </font> </th>");
                }
                sb.Append("</tr>");

                foreach (DataRow dr in tDetail2.Rows)
                {
                    sb.Append("<tr>");
                    foreach (DataColumn column in tDetail2.Columns)
                    {
                        sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  &nbsp;" + dr[column].ToString() + "&nbsp;  </font> </td>");

                    }
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                #endregion
                sb.Append("<p></p>");
            }

            if (tDetail3 != null)
            {
                sb.Append("<p></p>");
                #region Details
                sb.Append(" <table border=\"1px\" color=\"#0B0B61\" CELLPADDING=\"3\">");
                sb.Append("<tr>");
                foreach (DataColumn dc in tDetail3.Columns)
                {
                    sb.Append("<th> <font size=\"1.5\" color=\"#5C0000\">  &nbsp;" + dc.ColumnName + "&nbsp;  </font> </th>");
                }
                sb.Append("</tr>");

                foreach (DataRow dr in tDetail3.Rows)
                {
                    sb.Append("<tr>");
                    foreach (DataColumn column in tDetail3.Columns)
                    {
                        sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  &nbsp;" + dr[column].ToString() + "&nbsp;  </font> </td>");

                    }
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                #endregion
                sb.Append("<p></p>");
            }

            if (tDetail4 != null)
            {
                sb.Append("<p></p>");
                #region Details
                sb.Append(" <table border=\"1px\" color=\"#0B0B61\" CELLPADDING=\"3\">");
                sb.Append("<tr>");
                foreach (DataColumn dc in tDetail4.Columns)
                {
                    sb.Append("<th> <font size=\"1.5\" color=\"#5C0000\">  &nbsp;" + dc.ColumnName + "&nbsp;  </font> </th>");
                }
                sb.Append("</tr>");

                foreach (DataRow dr in tDetail4.Rows)
                {
                    sb.Append("<tr>");
                    foreach (DataColumn column in tDetail4.Columns)
                    {
                        sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  &nbsp;" + dr[column].ToString() + "&nbsp;  </font> </td>");

                    }
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                #endregion
                sb.Append("<p></p>");
            }

            if (tDetail5 != null)
            {
                sb.Append("<p></p>");
                #region Details
                sb.Append(" <table border=\"1px\" color=\"#0B0B61\" CELLPADDING=\"3\">");
                sb.Append("<tr>");
                foreach (DataColumn dc in tDetail5.Columns)
                {
                    sb.Append("<th> <font size=\"1.5\" color=\"#5C0000\">  &nbsp;" + dc.ColumnName + "&nbsp;  </font> </th>");
                }
                sb.Append("</tr>");

                foreach (DataRow dr in tDetail5.Rows)
                {
                    sb.Append("<tr>");
                    foreach (DataColumn column in tDetail5.Columns)
                    {
                        sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  &nbsp;" + dr[column].ToString() + "&nbsp;  </font> </td>");

                    }
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
                #endregion
                sb.Append("<p></p>");
            }


            #region User Details
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            foreach (DataRow dr in tFooter.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td> <font size=\"1\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td><font size=\"1\" color=\"#515355\">  </font></td>");
                else
                    sb.Append("<td><font size=\"1\" color=\"#515355\"> : </font></td>");
                sb.Append("<td> <b><font size=\"1\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            #endregion

            sb.Append("<HR>");
            sb.Append("<p><b><font size=\"1\" color=\"#80878E\">Email Ref No : " + EmailId + "</font></b></p>");
            return sb.ToString();
        }
        public static string CreateDailyStatusEmailBody(string EmailId, string Title, string sHeading, DataTable tTitle, DataTable tDetail1, DataTable tDetail2, DataTable tDetail3, DataTable tDetail4, DataTable tDetail5, DataTable tDetail6, DataTable tDetail7, DataTable tHeader, DataTable tDetail, DataTable tFooter)
        {
            // string sBodyHTML;
            StringBuilder sb = new StringBuilder();

            sb.Append("<H3 align=\"Center\" >" + Title + "</H3>");
            sb.Append("<H3 align=\"Center\" >" + sHeading + "</H3>");
            sb.Append("<HR>");
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            foreach (DataRow dr in tTitle.Rows)
            {
                sb.Append("<tr  COLSPAN=\"2\">");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else
                    sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "n")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");

                sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[2].ToString() + "</font> </b></td>");

                sb.Append("</tr>");

            }
            //  sb.Append("/table");
            #region Detail1
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            sb.Append(" <tr>");
            sb.Append(" <td>");
            sb.Append(" </td>");
            sb.Append(" <td>");
            sb.Append("<th align=\"center\"><u>FOR THE DAY </u></th>");
            sb.Append(" </td>");
            sb.Append(" <td>");
            sb.Append("<th align=\"center\"><u>FOR THE MONTH</u></th>");
            sb.Append(" </td>");
            sb.Append("</tr>");
            foreach (DataRow dr in tDetail1.Rows)
            {
                sb.Append("<tr  COLSPAN=\"2\">");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else
                    sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                if (dr[3].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append("</table>");

            #endregion

            #region Detail2
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            sb.Append(" <tr>");
            sb.Append(" <td>");
            sb.Append(" </td>");
            sb.Append("</tr>");
            foreach (DataRow dr in tDetail2.Rows)
            {
                sb.Append("<tr  COLSPAN=\"2\">");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else

                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                if (dr[3].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append("</table>");

            #endregion

            #region Detail3
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            sb.Append(" <tr>");
            sb.Append(" <td>");
            sb.Append(" </td>");
            sb.Append("</tr>");
            foreach (DataRow dr in tDetail3.Rows)
            {
                sb.Append("<tr  COLSPAN=\"2\">");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else

                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");


                if (dr[3].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append("</table>");

            #endregion

            #region Detail4
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            sb.Append(" <tr>");
            sb.Append(" <td>");
            sb.Append(" </td>");
            sb.Append("</tr>");
            foreach (DataRow dr in tDetail4.Rows)
            {
                sb.Append("<tr  COLSPAN=\"2\">");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");


                if (dr[3].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append("</table>");

            #endregion

            #region Detail5
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            sb.Append(" <tr>");
            sb.Append(" <td>");
            sb.Append(" </td>");
            sb.Append("</tr>");
            foreach (DataRow dr in tDetail5.Rows)
            {
                sb.Append("<tr  COLSPAN=\"2\">");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else
                    sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");

                if (dr[3].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append("</table>");

            #endregion

            #region Detail6
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            sb.Append(" <tr>");
            sb.Append(" <td>");
            //sb.Append(" <td><font size=\"1.5\" color=\"#515355\"> Main Store Stock </font> </td>");
            //sb.Append("<th align=\"Left\">Main Store Stock </th>");
            sb.Append(" </td>");
            sb.Append("</tr>");
            foreach (DataRow dr in tDetail6.Rows)
            {
                sb.Append("<tr  COLSPAN=\"2\">");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else

                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");



                if (dr[3].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append("</table>");

            #endregion

            #region Detail7
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            sb.Append(" <tr>");
            sb.Append(" <td>");
            sb.Append(" </td>");
            sb.Append("</tr>");
            foreach (DataRow dr in tDetail7.Rows)
            {
                sb.Append("<tr  COLSPAN=\"2\">");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                else
                    sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                if (dr[2].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                if (dr[3].ToString() == "")
                    sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font> </b></td>");
                else
                    sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append(" <tr>");
            sb.Append(" </tr>");
            sb.Append("</table>");

            #endregion

            #region Header
            if (tHeader != null)
            {
                sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
                sb.Append(" <tr>");
                sb.Append(" <td>");
                sb.Append(" </td>");
                sb.Append(" <td>");
                sb.Append("<th align=\"center\"><u>FOR THE DAY </u></th>");
                sb.Append(" </td>");
                sb.Append(" <td>");
                sb.Append("<th align=\"center\"><u>FOR THE MONTH</u></th>");
                sb.Append(" </td>");
                sb.Append("</tr>");
                foreach (DataRow dr in tHeader.Rows)
                {
                    sb.Append("<tr  COLSPAN=\"2\">");
                    sb.Append("<td> <font size=\"1.5\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                    if (dr[0].ToString() == "")
                        sb.Append("<td height=\"1.5\"> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                    else
                        sb.Append("<td> <font size=\"1.5\" color=\"#515355\"> : </font> </td>");
                    if (dr[2].ToString() == "")
                        sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font> </b></td>");
                    else
                        sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                    sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  </font> </td>");
                    if (dr[3].ToString() == "")
                        sb.Append("<td > <b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font> </b></td>");
                    else
                        sb.Append("<td><b><font size=\"1.5\" color=\"#5C0000\">" + dr[3].ToString() + "</font></b> </td>");
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
            }
            else
            {

            }
            #endregion

            if (tDetail != null)
            {
                sb.Append("<p></p>");
                #region Details
                sb.Append(" <table border=\"2px\" CELLPADDING=\"3\">");
                sb.Append("<tr>");
                foreach (DataColumn dc in tDetail.Columns)
                {
                    sb.Append("<th> <font size=\"1.5\" color=\"#5C0000\">  &nbsp;" + dc.ColumnName + "&nbsp;  </font> </th>");
                }
                sb.Append("</tr>");
                sb.Append("<tr>");
                foreach (DataRow dr in tDetail.Rows)
                {
                    foreach (DataColumn column in tDetail.Columns)
                    {
                        sb.Append("<td> <font size=\"1.5\" color=\"#515355\">  &nbsp;" + dr[column].ToString() + "&nbsp;  </font> </td>");
                    }
                    //sBodyHTML += "<th>" + dr.ColumnName + "</th>";
                }
                sb.Append("</tr>");
                sb.Append("</table>");
                #endregion
                sb.Append("<p></p>");
            }
            else
            {

            }


            #region User Details
            sb.Append(" <table border=\"0\" CELLPADDING=\"3\">");
            foreach (DataRow dr in tFooter.Rows)
            {
                sb.Append("<tr>");
                sb.Append("<td> <font size=\"1\" color=\"#515355\">" + dr[0].ToString() + "</font> </td>");
                if (dr[0].ToString() == "")
                    sb.Append("<td><font size=\"1\" color=\"#515355\">  </font></td>");
                else
                    sb.Append("<td><font size=\"1\" color=\"#515355\"> : </font></td>");
                sb.Append("<td> <b><font size=\"1\" color=\"#5C0000\">" + dr[1].ToString() + "</font></b> </td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            #endregion

            sb.Append("<HR>");
            sb.Append("<p><b><font size=\"1\" color=\"#80878E\">Email Ref No : " + EmailId + "</font></b></p>");
            return sb.ToString();
        }
        #endregion

        public static bool createEmail_EventLog(enum_Alerts alertType, string sBranch_ID)
        {
            bool bEmailStatus = false;
            string sAlertID = "";
            try
            {
                sAlertID = clsAutocode.getAlertID(alertType);

                tbl_utlAlert oAlert = tbl_utlAlert.Select(sAlertID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    string sSubject = "SEACC Service - Event log " + clsSecurity.getServerDateTime();
                    string sBodyHTML = "";
                    string logFileName = Path.Combine(Application.StartupPath, "ErrorLog.txt");
                    try
                    {
                        sBodyHTML = File.ReadAllText(logFileName);
                    }
                    catch { }

                    #region Send Email

                    bEmailStatus = SaveMailHTML(sAlertID, sSubject, sBodyHTML);
                    if (bEmailStatus)
                    {
                        File.Delete(logFileName);
                    }
                    #endregion
                }
                else
                    bEmailStatus = true;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("Error - " + sAlertID + " - " + alertType.ToString() , -1,ex);
            }
            finally
            {
                clsSecurity.UpdateAlertSentTime(alertType, sAlertID, bEmailStatus, sBranch_ID);
            }
            return bEmailStatus;
        }

        public static void Checking_SheduledAlerts()
        {
            foreach (tbl_utlAlert_Shedule oShedule in tbl_utlAlert_Shedule.SelectAll().Where(p => p.IsActive))
            {
                enum_Alerts enAlert = clsAutocode.getAlertEnum(oShedule.Alert_ID);

                bool value = false;
                tbl_utlAlert oAlert = tbl_utlAlert.Select(oShedule.Alert_ID);
                if (oAlert != null && oAlert.Alert_ID != "default" && oAlert.IsActive)
                {
                    DateTime dtNow = clsSecurity.getServerDateTime();

                    #region monthly
                    if (oShedule.IsMonthly)
                    {
                        if (oShedule.LastAlert_SentTime.Month != dtNow.Month)
                        {
                            DateTime dtmSheduleTime = new DateTime(dtNow.Year, dtNow.Month, oShedule.SheduledTime.Day, oShedule.SheduledTime.Hour, oShedule.SheduledTime.Minute, 0);
                            if (dtmSheduleTime <= dtNow)
                                value = true;
                        }
                    }
                    #endregion

                    #region daily
                    else if (oShedule.IsDaily)
                    {
                        int iHour = oShedule.SheduledTime.Hour;
                        if (dtNow.Date > oShedule.LastAlert_SentTime.Date && dtNow.Hour >= iHour)
                            value = true;
                    }
                    #endregion
                }

                if (value)
                {
                    if (enAlert == enum_Alerts.SheduleAlert_ChequePendingDeposit)
                        createEmail_ChequePendingBankDeposit(enum_Alerts.SheduleAlert_ChequePendingDeposit, oShedule.CompanyBranch_ID);

                    else if (enAlert == enum_Alerts.SheduleAlert_CashSalesNotDeposited)
                        createEmail_CashSalesNotDeposited(enum_Alerts.SheduleAlert_CashSalesNotDeposited, oShedule.CompanyBranch_ID);

                    else if (enAlert == enum_Alerts.SheduleAlert_DONoteInvoiced)
                        createEmail_DONotInvoiced(enum_Alerts.SheduleAlert_DONoteInvoiced, oShedule.CompanyBranch_ID);

                    else if (enAlert == enum_Alerts.SheduleAlert_CustomerExceededCredit)
                        createEmail_CustomerExceededCredit(enum_Alerts.SheduleAlert_CustomerExceededCredit, oShedule.CompanyBranch_ID);

                    else if (enAlert == enum_Alerts.SheduleAlert_DepositedChequesNotRealized)
                        createEmail_DepositedChequesNotRealized(enum_Alerts.SheduleAlert_DepositedChequesNotRealized, oShedule.CompanyBranch_ID);

                    else if (enAlert == enum_Alerts.SheduleAlert_DailyStatusAlert_Gen)
                        createEmail_DailyStatusAlert_BranchWise(enum_Alerts.SheduleAlert_DailyStatusAlert_Gen, oShedule.CompanyBranch_ID);

                    else if (enAlert == enum_Alerts.SheduleAlert_UnsettleReturnedCheques)
                        clsAlerts_Email.createEmail_UnsettleReturnedCheques(enum_Alerts.SheduleAlert_UnsettleReturnedCheques, oShedule.CompanyBranch_ID);

                    else if (enAlert == enum_Alerts.StatusAlert_InvoicesExceededCreditPeriod)
                        createEmail_InvoicesExceededCreditPeriod(enum_Alerts.StatusAlert_InvoicesExceededCreditPeriod, oShedule.CompanyBranch_ID);

                    else if (enAlert == enum_Alerts.SheduleAlert_InvoiceSummary)
                        createEmail_InvoiceSummary(enum_Alerts.SheduleAlert_InvoiceSummary, oShedule.CompanyBranch_ID);

                    else if (enAlert == enum_Alerts.SheduleAlert_ReceiptSummary)
                        createEmail_ReceiptSummary(enum_Alerts.SheduleAlert_ReceiptSummary, oShedule.CompanyBranch_ID);

                    else if (enAlert == enum_Alerts.SheduleAlert_TurnOverDetail_SalesmanWise)
                    {
                        foreach (tbl_genEmployeeMaster oEmployee in tbl_genEmployeeMaster.SelectAll().Where(p => p.Employee_ID != "default" && p.IsSelesRep && !p.IsDelete && p.Email.Trim().Length > 0))
                            createEmail_TurnOverDetails_SalesmanWise(enum_Alerts.SheduleAlert_TurnOverDetail_SalesmanWise, oEmployee.Employee_ID, oEmployee.Email, clsSecurity.getServerDateTime(), oShedule.CompanyBranch_ID);
                    }
                    else if (enAlert == enum_Alerts.SheduleAlert_TurnOverDetail_SalesmanWiseSummary)
                        createEmail_TurnOverDetails_SalesmanWiseSummary(enum_Alerts.SheduleAlert_TurnOverDetail_SalesmanWiseSummary, clsSecurity.getServerDateTime(), oShedule.CompanyBranch_ID);

                    else if (enAlert == enum_Alerts.SheduleAlert_UnallocatedResipt)
                        createEmail_UnAllocatedReceipt(enum_Alerts.SheduleAlert_UnallocatedResipt, clsSecurity.getServerDateTime(), oShedule.CompanyBranch_ID);

                    else if (enAlert == enum_Alerts.SheduleAlert_OutstandingJobs_SalesmanWise)
                    {
                        foreach (tbl_genEmployeeMaster oEmployee in tbl_genEmployeeMaster.SelectAll().Where(p => p.Employee_ID != "default" && p.IsSelesRep && !p.IsDelete && p.Email.Trim().Length > 0))
                            createEmail_OutstandingJobsAlert_SalesmanWise(enum_Alerts.SheduleAlert_OutstandingJobs_SalesmanWise, oEmployee.Employee_ID, oEmployee.Email, clsSecurity.getServerDateTime(), oShedule.CompanyBranch_ID);
                    }
                    else if (enAlert == enum_Alerts.SheduleAlert_JobCloseSummary)
                        createEmail_JobCloseSummary(enum_Alerts.SheduleAlert_JobCloseSummary, clsSecurity.getServerDateTime(), oShedule.CompanyBranch_ID);

                    else if (enAlert == enum_Alerts.SheduleAlert_SalseReturnSummary)
                        createEmail_SalesReturnSummary(enum_Alerts.SheduleAlert_SalseReturnSummary, clsSecurity.getServerDateTime(), oShedule.CompanyBranch_ID);

                    else if (enAlert == enum_Alerts.SheduleAlert_SalseReturn_SalesmanWise)
                    {
                        foreach (tbl_genEmployeeMaster oEmployee in tbl_genEmployeeMaster.SelectAll().Where(p => p.Employee_ID != "default" && p.IsSelesRep && !p.IsDelete && p.Email.Trim().Length > 0))
                            createEmail_SalesReturn_SalesmanWise(enum_Alerts.SheduleAlert_SalseReturn_SalesmanWise, oEmployee.Employee_ID, oEmployee.Email, clsSecurity.getServerDateTime(), oShedule.CompanyBranch_ID);
                    }
                    else if (enAlert == enum_Alerts.DailySectionPlan)
                        createEmail_DailySectionPlan(enum_Alerts.DailySectionPlan, clsSecurity.getServerDateTime(), oShedule.CompanyBranch_ID);

                    else if (enAlert == enum_Alerts.EventLog)
                        createEmail_EventLog(enum_Alerts.DailySectionPlan, oShedule.CompanyBranch_ID);

                    else if (enAlert == enum_Alerts.AutoBackup)
                        clsUtil.startAutoBacup(clsConfig.sAutoBackupPath);

                    else if (enAlert == enum_Alerts.CustomerOutstandingAlert_ToCustomer)
                    {
                        foreach (tbl_genCustomerMaster oCustomer in tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID != "default" && !p.IsDeleted && !p.IsBlacklisted && !p.IsLocked && p.Email.Trim().Length > 0))
                            createEmail_CustomerOutstandingStatement_ToCustomer(enum_Alerts.CustomerOutstandingAlert_ToCustomer, oCustomer.Customer_ID, oCustomer.Email, clsSecurity.getServerDateTime(), oShedule.CompanyBranch_ID);
                        //createEmail_CustomerOutstandingStatement(enum_Alerts.CustomerOutstandingAlert_ToCustomer, oCustomer.Customer_ID, oCustomer.Email, clsSecurity.getServerDateTime(), oShedule.CompanyBranch_ID);
                    }

                    //else if (enAlert == enum_Alerts.SheduleAlert_SalesAgeAnalysis)
                    //{
                    //    clsUtil.createEmail_SalesAgeAnalysis(enum_Alerts.StatusAlert_SalesAgeAnalysis);
                    //}

                    else if (enAlert == enum_Alerts.ChequeInHand)
                    {
                        createEmail_ChequeInHand(enum_Alerts.ChequeInHand, oShedule.CompanyBranch_ID);
                    }

                    //POS Alerts
                    
                    else if (enAlert == enum_Alerts.POS_TransactionDetails)
                    {
                      //  createEmail_POSDetail(oShedule.Schedule_ID, enum_Alerts.POS_TransactionDetails, oShedule.CompanyBranch_ID);
                    }
                }
            }

            #region Comented Region
            //string sBranch_ID = "default";

            //#region MyRegion
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.SheduleAlert_ChequePendingDeposit))
            //{
            //    createEmail_ChequePendingBankDeposit(enum_Alerts.SheduleAlert_ChequePendingDeposit, sBranch_ID);
            //}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.SheduleAlert_CashSalesNotDeposited))
            //{
            //    createEmail_CashSalesNotDeposited(enum_Alerts.SheduleAlert_CashSalesNotDeposited, sBranch_ID);
            //}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.SheduleAlert_DONoteInvoiced))
            //{
            //    createEmail_DONotInvoiced(enum_Alerts.SheduleAlert_DONoteInvoiced, sBranch_ID);
            //}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.SheduleAlert_CustomerExceededCredit))
            //{
            //    createEmail_CustomerExceededCredit(enum_Alerts.SheduleAlert_CustomerExceededCredit, sBranch_ID);
            //}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.SheduleAlert_DepositedChequesNotRealized))
            //{
            //    createEmail_DepositedChequesNotRealized(enum_Alerts.SheduleAlert_DepositedChequesNotRealized, sBranch_ID);
            //}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.SheduleAlert_DailyStatusAlert_Gen))
            //{
            //    createEmail_DailyStatusAlert_Genaral(enum_Alerts.SheduleAlert_DailyStatusAlert_Gen, sBranch_ID);
            //}
            ////if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.SheduleAlert_SalesAgeAnalysis))
            ////{
            //    //createEmail_SalesAgeAnalysis(enum_Alerts.StatusAlert_SalesAgeAnalysis);
            ////}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.SheduleAlert_UnsettleReturnedCheques))
            //{
            //    clsAlerts_Email.createEmail_UnsettleReturnedCheques(enum_Alerts.SheduleAlert_UnsettleReturnedCheques, sBranch_ID);
            //}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.StatusAlert_InvoicesExceededCreditPeriod))
            //{
            //    createEmail_InvoicesExceededCreditPeriod(enum_Alerts.StatusAlert_InvoicesExceededCreditPeriod, sBranch_ID);
            //}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.SheduleAlert_InvoiceSummary))
            //{
            //    createEmail_InvoiceSummary(enum_Alerts.SheduleAlert_InvoiceSummary, sBranch_ID);
            //}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.SheduleAlert_ReceiptSummary))
            //{
            //    createEmail_ReceiptSummary(enum_Alerts.SheduleAlert_ReceiptSummary, sBranch_ID);
            //}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.SheduleAlert_TurnOverDetail_SalesmanWise))
            //{
            //    foreach (tbl_genEmployeeMaster oEmployee in tbl_genEmployeeMaster.SelectAll().Where(p => p.Employee_ID != "default" && p.IsSelesRep && !p.IsDelete && p.Email.Trim().Length > 0))
            //        createEmail_TurnOverDetails_SalesmanWise(enum_Alerts.SheduleAlert_TurnOverDetail_SalesmanWise, oEmployee.Employee_ID, oEmployee.Email, clsSecurity.getServerDateTime(), sBranch_ID);
            //}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.SheduleAlert_TurnOverDetail_SalesmanWiseSummary))
            //{
            //    createEmail_TurnOverDetails_SalesmanWiseSummary(enum_Alerts.SheduleAlert_TurnOverDetail_SalesmanWiseSummary, clsSecurity.getServerDateTime(), sBranch_ID);
            //}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.SheduleAlert_UnallocatedResipt))
            //{
            //    createEmail_UnAllocatedReceipt(enum_Alerts.SheduleAlert_UnallocatedResipt, clsSecurity.getServerDateTime(), sBranch_ID);
            //}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.SheduleAlert_OutstandingJobs_SalesmanWise))
            //{
            //    foreach (tbl_genEmployeeMaster oEmployee in tbl_genEmployeeMaster.SelectAll().Where(p => p.Employee_ID != "default" && p.IsSelesRep && !p.IsDelete && p.Email.Trim().Length > 0))
            //        createEmail_OutstandingJobsAlert_SalesmanWise(enum_Alerts.SheduleAlert_OutstandingJobs_SalesmanWise, oEmployee.Employee_ID, oEmployee.Email, clsSecurity.getServerDateTime(), sBranch_ID);
            //}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.SheduleAlert_JobCloseSummary))
            //{
            //    createEmail_JobCloseSummary(enum_Alerts.SheduleAlert_JobCloseSummary, clsSecurity.getServerDateTime(), sBranch_ID);
            //}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.SheduleAlert_SalseReturnSummary))
            //{
            //    createEmail_SalesReturnSummary(enum_Alerts.SheduleAlert_SalseReturnSummary, clsSecurity.getServerDateTime(), sBranch_ID);
            //}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.SheduleAlert_SalseReturn_SalesmanWise))
            //{
            //    foreach (tbl_genEmployeeMaster oEmployee in tbl_genEmployeeMaster.SelectAll().Where(p => p.Employee_ID != "default" && p.IsSelesRep && !p.IsDelete && p.Email.Trim().Length > 0))
            //        createEmail_SalesReturn_SalesmanWise(enum_Alerts.SheduleAlert_SalseReturn_SalesmanWise, oEmployee.Employee_ID, oEmployee.Email, clsSecurity.getServerDateTime(), sBranch_ID);
            //}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.DailySectionPlan))
            //{
            //    createEmail_DailySectionPlan(enum_Alerts.DailySectionPlan, clsSecurity.getServerDateTime(), sBranch_ID);
            //}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.EventLog))
            //{
            //    createEmail_EventLog(enum_Alerts.DailySectionPlan, sBranch_ID);
            //}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.AutoBackup))
            //{
            //     clsUtil.startAutoBacup(clsConfig.sAutoBackupPath);
            //}
            ////if (clsUtil.isBacupActive(DateTime.Parse(clsConfig.sLastBackupedDate.ToString().Trim())))
            ////{

            ////}
            //if (clsSecurity.IsAlerts_SheduleEnable(enum_Alerts.CustomerOutstandingAlert_ToCustomer))
            //{
            //    foreach (tbl_genCustomerMaster oCustomer in tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID != "default" && !p.IsDeleted && !p.IsBlacklisted && !p.IsLocked && p.Email.Trim().Length > 0))
            //        createEmail_CustomerOutstandingStatement(enum_Alerts.CustomerOutstandingAlert_ToCustomer, oCustomer.Customer_ID, oCustomer.Email, clsSecurity.getServerDateTime(), sBranch_ID);
            //}
            //#endregion 
            #endregion
        }

        public static bool SaveMailHTML(string sAlertID, string sSubject, string sBodyHTML)
        {
            bool status = false;
            try
            {
                int Emailid = int.Parse(clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.EmailBox)));

                tbl_utlAlertMailBox_Pending oAlerts = new tbl_utlAlertMailBox_Pending(Emailid, sAlertID, sSubject, sBodyHTML, 0);
                oAlerts.Insert();
                int i = 0;
                foreach (tbl_utlAlertSettings oAlertSetting in tbl_utlAlertSettings.SelectAllByAlert_ID(sAlertID))
                {
                    if (oAlertSetting.UserEmail1.Length > 0)
                    {
                        tbl_utlAlertMailBox_Receiver oAlertRes = new tbl_utlAlertMailBox_Receiver(Emailid, i, oAlertSetting.ReceiverType, oAlertSetting.PersonName, oAlertSetting.UserEmail1);
                        oAlertRes.Insert();
                        i++;
                    }
                }
                status = true;
                clsValidate.WriteErrorLog(Emailid.ToString(), -1,null);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog(sAlertID + " - Alert Save failed - " , -1,ex);
            }
            return status;
        }

        public static bool SaveMailHTML_Attachment(string sAlertID, string sSubject, string sBodyHTML, string sPath)
        {
            bool status = false;
            try
            {
                int Emailid = int.Parse(clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.EmailBox)));

                tbl_utlAlertMailBox_Pending oAlerts = new tbl_utlAlertMailBox_Pending(Emailid, sAlertID, sSubject, sBodyHTML, 0);
                oAlerts.Insert();

                tbl_utlAlertMailBox_Attachments oAttachments = new tbl_utlAlertMailBox_Attachments(Emailid, 0, sPath);
                oAttachments.Insert();

                int i = 0;
                foreach (tbl_utlAlertSettings oAlertSetting in tbl_utlAlertSettings.SelectAllByAlert_ID(sAlertID))
                {
                    if (oAlertSetting.UserEmail1.Length > 0)
                    {
                        tbl_utlAlertMailBox_Receiver oAlertRes = new tbl_utlAlertMailBox_Receiver(Emailid, i, oAlertSetting.ReceiverType, oAlertSetting.PersonName, oAlertSetting.UserEmail1);
                        oAlertRes.Insert();
                        i++;
                    }
                }
                status = true;
                clsValidate.WriteErrorLog(Emailid.ToString(), -1,null);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog(sAlertID + " - Alert Save failed - " , -1,ex);
            }
            return status;
        }

        public static bool SaveMailHTML_ToCustomer(string sAlertID, string sSubject, string sBodyHTML, string sEmailAddress, string sReceiverName)
        {
            bool status = false;
            try
            {
                int Emailid = int.Parse(clsAutocode.getAutoGeneratedCode(clsAutocode.getFormConfigCode(FormName.EmailBox)));

                tbl_utlAlertMailBox_Pending oAlerts = new tbl_utlAlertMailBox_Pending(Emailid, sAlertID, sSubject, sBodyHTML, 0);
                oAlerts.Insert();
                int i = 0;
                foreach (tbl_utlAlertSettings oAlertSetting in tbl_utlAlertSettings.SelectAllByAlert_ID(sAlertID))
                {
                    //if (oAlertSetting.UserEmail1.Length > 0)
                    //{
                    tbl_utlAlertMailBox_Receiver oAlertRes = new tbl_utlAlertMailBox_Receiver(Emailid, i, oAlertSetting.ReceiverType, sReceiverName, sEmailAddress);
                    oAlertRes.Insert();
                    i++;
                    //}
                }
                status = true;
                clsValidate.WriteErrorLog(Emailid.ToString(), -1,null);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog(sAlertID + " - Alert Save failed - " , -1,ex);
            }
            return status;
        }
    }
}