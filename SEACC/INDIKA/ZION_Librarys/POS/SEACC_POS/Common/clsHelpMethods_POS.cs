using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataTire;
using System.Net.NetworkInformation;
using System.Net;
using Digiteq_Logic;
using System.Windows.Controls;
using Microsoft.Windows.Controls.Primitives;
using System.Windows;
using System.Windows.Media;
using SEACC_WPFControls;
using System.ComponentModel;
using System.Reflection;
using SEACC_POS.Search_Forms;
using System.Windows.Media.Imaging;
using System.IO;
using Ext_Digiteq_Logic;

namespace SEACC_POS
{
    public class clsHelpMethods_POS
    {
        //Common

        #region Get Host Name
        public static string GetHostName()
        {
            string macAddresses = Dns.GetHostName();
            return macAddresses;
        }
        #endregion

        #region Get Mac Address
        public static string GetMacAddress()
        {
            string macAddresses = "";

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddresses;
        }
        #endregion

        #region Get IP Address
        public static string GetIPAddress()
        {
            string sIPAddress = "";
            try
            {
                System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();

                // Get server related information.
                IPHostEntry heserver = Dns.GetHostEntry(GetHostName());

                // Loop on the AddressList
                foreach (IPAddress curAdd in heserver.AddressList)
                {
                    if (clsValidate.CheckValidityIPAddress(curAdd.ToString()))
                    {
                        sIPAddress = curAdd.ToString();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[DoResolve] Exception: " + e.ToString());
            }
            return sIPAddress;
        }
        #endregion

        #region Get Form Name
        public static string getFormName(FormName iFormID)
        {
            string sFormName = "";
            tbl_securityFormMaster formMaster = tbl_securityFormMaster.Select((int)iFormID);
            if (formMaster != null)
                sFormName = formMaster.FormName;
            return sFormName;
        }
        public static void FormatUCHeader(Label lblUC_Header, Label lblUC_ID, FormName iFormID)
        {
            tbl_securityFormMaster formMaster = tbl_securityFormMaster.Select((int)iFormID);
            if (formMaster != null)
            {
                lblUC_Header.Content = formMaster.FormName;
                lblUC_ID.Content = formMaster.FormCategory_ID + "/" + formMaster.Form_ID;
            }
        }
        #endregion

        #region Assign Company Values
        public static bool AutoAssignCompanyValue()
        {
            bool status = false;
            try
            {
                tbl_genCompanyInfo com = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
                if (com != null)
                {
                    clsSecurity.CompanyName = clsCript.Decrypt(com.CompanyName);
                    clsSecurity.CompanyAddress1 = clsCript.Decrypt(com.Address);
                    clsSecurity.CompanyAddress2 = "";
                    if (com.Telephone1.Length > 0)
                        clsSecurity.CompanyAddress2 = "Tel:" + com.Telephone1;
                    if (com.Telephone2.Length > 0)
                        clsSecurity.CompanyAddress2 += "," + com.Telephone2;
                    if (com.Fax.Length > 0)
                        clsSecurity.CompanyAddress2 += "," + " FAX:" + com.Fax;
                    status = true;
                }
                else
                    SEACCMessageBox.Show("Company Not exist....!", "", MessageBoxButton.OK, "Red");

            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Something Went Wrong....!", ex.Message, MessageBoxButton.OK, "Red");
            }
            return status;
        }
        #endregion


        // Cash , Default Customer 
        public static bool Is_CashCustomer(string sCustomer_ID)
        {
            bool bIsCashDefault_Customer = false;
            tbl_genCustomerMaster oCustomer = tbl_genCustomerMaster.Select(sCustomer_ID);
            if (oCustomer != null)
            {
                bIsCashDefault_Customer = oCustomer.IsCashCustomer;
            }

            return bIsCashDefault_Customer;
        }

        public static string Get_BranchCashCustomer_ID(string sBranch_ID)
        {
            string sBranch_CashCustomer = "default";
            tbl_genCustomerMaster oCashCustomer = tbl_genCustomerMaster.SelectAll().Where(p => p.CompanyBranch_ID == sBranch_ID && p.IsCashCustomer).ToList().FirstOrDefault();
            if (oCashCustomer != null)
            {
                sBranch_CashCustomer = oCashCustomer.Customer_ID;
            }
            return sBranch_CashCustomer;
        }

        #region Get Credit Limit
        public static decimal GetCustomerCreditLimit(string sCustomerID)
        {
            decimal dCreditBalance = 0;
            tbl_genCustomerMaster detail = tbl_genCustomerMaster.Select(sCustomerID);
            tbl_genCustomerFinance finance = tbl_genCustomerFinance.Select(sCustomerID);
            if (detail != null && finance != null)
            {
                dCreditBalance = finance.CreditLimit + finance.DepositAmount;
            }
            return dCreditBalance;
        }
        #endregion

        #region Get Total Credit Balance
        public static decimal GetCustomerCreditBalance(string sCustomerID)
        {
            decimal dCreditBalance = 0, dTotalIncome = 0, dTotalDues = 0;
            tbl_genCustomerMaster detail = tbl_genCustomerMaster.Select(sCustomerID);
            tbl_genCustomerFinance finance = tbl_genCustomerFinance.Select(sCustomerID);
            if (detail != null && finance != null)
            {
                dTotalIncome = finance.CreditLimit + finance.DepositAmount;
                dTotalDues = GetCustomerTotalDues_All(sCustomerID);
                dCreditBalance = dTotalIncome - dTotalDues;
            }
            return dCreditBalance;
        }
        #endregion

        #region Get Total Dues - Invoice
        public static decimal GetCustomerTotalDues_Invoice(string sCustomerID)
        {
            decimal dTotalDues = 0;
            List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAllByCustomer_ID(sCustomerID);
            foreach (tbl_sasInvoice detail in details)
            {
                if (!detail.IsSeattled && !detail.IsDeleted && !detail.IsOpeningBalance && !detail.IsReturnedCheque)
                    dTotalDues += (detail.GrandTotal - detail.SeattleAmount);
            }
            return dTotalDues;
        }
        public static decimal GetCustomerTotalDues_Invoice30till(string sCustomerID)
        {
            decimal dTotalDues = 0;
            List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAllByCustomer_ID(sCustomerID);
            foreach (tbl_sasInvoice detail in details)
            {

                if (!detail.IsSeattled && !detail.IsDeleted && !detail.IsOpeningBalance && !detail.IsReturnedCheque)
                {
                    if (clsCommon.getDaysUptoDate(detail.InvoiceDate) >= 30 && clsCommon.getDaysUptoDate(detail.InvoiceDate) < 60)
                        dTotalDues += (detail.GrandTotal - detail.SeattleAmount);
                }
            }
            return dTotalDues;
        }
        public static decimal GetCustomerTotalDues_Invoice30to60(string sCustomerID)
        {
            decimal dTotalDues = 0;
            List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAllByCustomer_ID(sCustomerID);
            foreach (tbl_sasInvoice detail in details)
            {

                if (!detail.IsSeattled && !detail.IsDeleted && !detail.IsOpeningBalance && !detail.IsReturnedCheque)
                {
                    if (clsCommon.getDaysUptoDate(detail.InvoiceDate) >= 30 && clsCommon.getDaysUptoDate(detail.InvoiceDate) < 60)
                        dTotalDues += (detail.GrandTotal - detail.SeattleAmount);
                }
            }
            return dTotalDues;
        }
        public static decimal GetCustomerTotalDues_Invoice60to90(string sCustomerID)
        {
            decimal dTotalDues = 0;
            List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAllByCustomer_ID(sCustomerID);
            foreach (tbl_sasInvoice detail in details)
            {

                if (!detail.IsSeattled && !detail.IsDeleted && !detail.IsOpeningBalance && !detail.IsReturnedCheque)
                {
                    if (clsCommon.getDaysUptoDate(detail.InvoiceDate) >= 60 && clsCommon.getDaysUptoDate(detail.InvoiceDate) < 90)
                        dTotalDues += (detail.GrandTotal - detail.SeattleAmount);
                }
            }
            return dTotalDues;
        }
        public static decimal GetCustomerTotalDues_Invoice90plus(string sCustomerID)
        {
            decimal dTotalDues = 0;
            List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAllByCustomer_ID(sCustomerID);
            foreach (tbl_sasInvoice detail in details)
            {

                if (!detail.IsSeattled && !detail.IsDeleted && !detail.IsOpeningBalance && !detail.IsReturnedCheque)
                {
                    if (clsCommon.getDaysUptoDate(detail.InvoiceDate) >= 90)
                        dTotalDues += (detail.GrandTotal - detail.SeattleAmount);
                }
            }
            return dTotalDues;
        }
        #endregion

        #region Get Total Dues - Openiing Balnace
        public static decimal GetCustomerTotalDues_OpeningBalance(string sCustomerID)
        {
            decimal dTotalDues = 0;
            List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAllByCustomer_ID(sCustomerID);
            foreach (tbl_sasInvoice detail in details)
            {
                if (!detail.IsSeattled && !detail.IsDeleted && detail.IsOpeningBalance)
                    dTotalDues += (detail.GrandTotal - detail.SeattleAmount);
            }
            return dTotalDues;
        }
        #endregion

        #region Get Total Dues - Returned Cheques
        public static decimal GetCustomerTotalDues_ReturnedCheque(string sCustomerID)
        {
            decimal dTotalDues = 0;
            List<tbl_sasInvoice> details = tbl_sasInvoice.SelectAllByCustomer_ID(sCustomerID);
            foreach (tbl_sasInvoice detail in details)
            {
                if (!detail.IsSeattled && !detail.IsDeleted && detail.IsReturnedCheque)
                    dTotalDues += (detail.GrandTotal - detail.SeattleAmount);
            }
            return dTotalDues;
        }
        #endregion

        #region Get Total - Over Payments
        public static decimal GetCustomerTotal_UnsettledPayements(string sCustomerID)
        {
            decimal dTotalPayments = 0;

            //Cash         
            foreach (tbl_bpsReceipt cash in tbl_bpsReceipt.SelectAllByCustomer_ID(sCustomerID).Where(p => !p.IsDeleted && p.Receipt_ID != "default" && !p.IsSeattled && p.CashAmount > p.SeattleAmount))
            {
                dTotalPayments += (cash.CashAmount - cash.SeattleAmount);
            }

            //Cheques
            foreach (tbl_bpsChequeRegister cheque in tbl_bpsChequeRegister.SelectAllByCustomer_ID(sCustomerID).Where(p => !p.IsDeleted && p.Receipt_ID != "default" && !p.IsSetteled && p.Amount > p.SetteledAmount))
            {
                dTotalPayments += (cheque.Amount - cheque.SetteledAmount);
            }

            //Credit Notes
            foreach (tbl_bpsCreditNote credit in tbl_bpsCreditNote.SelectAllByCustomer_ID(sCustomerID).Where(p => !p.IsDeleted && p.CreditNote_ID != "default" && !p.IsSeattled && p.TotalAmount > p.SeattleAmount))
            {
                dTotalPayments += (credit.TotalAmount - credit.SeattleAmount);
            }
            return dTotalPayments;
        }
        #endregion

        #region Get Total Dues - All
        public static decimal GetCustomerTotalDues_All(string sCustomerID)
        {
            decimal dTotalDues = 0;
            foreach (tbl_sasInvoice detail in tbl_sasInvoice.SelectAllByCustomer_ID(sCustomerID).Where(p => !p.IsDeleted && p.Invoice_ID != "default" && !p.IsSeattled))
            {
                dTotalDues += detail.GrandTotal - detail.SeattleAmount;
            }

            //overpayments
            dTotalDues -= GetCustomerTotal_UnsettledPayements(sCustomerID);

            return dTotalDues;
        }
        #endregion

        #region Get Customer Cheques In Hand
        public static decimal GetCustomerChequesInHand(string sCustomerID)
        {
            decimal dAmount = 0;
            foreach (tbl_bpsChequeRegister detail in tbl_bpsChequeRegister.SelectAllByCustomer_ID(sCustomerID).Where(p => !p.IsDeleted && p.ChequeRegister_ID != "default" && !p.IsReconcilied && !p.IsReIssued))
            {
                dAmount += detail.Amount; //detail.ChequeAmount - detail.SetteledAmount;   
            }
            return dAmount;
        }
        #endregion

        #region Get Enum Description
        public static List<string> GetEnumDescription_List(Type enumType)
        {
            List<string> lPeriod = new List<string>();

            foreach (var record in Enum.GetValues(enumType).Cast<Enum>().Select(value => new
            {
                (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                value
            })
        .OrderBy(item => item.value)
        .ToList())
            {
                lPeriod.Add(record.Description);
            }
            return lPeriod;
        }

        public static string GetEnumDescription(Enum value)
        {
            // Get the Description attribute value for the enum value
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }


        #endregion


        //Data Grid

        #region Get Data Grid Extensions
        public static DataGridCell GetCell(DataGrid dataGrid, DataGridRow row, int column)
        {
            if (dataGrid == null) throw new ArgumentNullException("dataGrid");
            if (row == null) throw new ArgumentNullException("row");
            if (column < 0) throw new ArgumentOutOfRangeException("column");

            DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(row);
            if (presenter == null)
            {
                row.ApplyTemplate();
                presenter = FindVisualChild<DataGridCellsPresenter>(row);
            }
            if (presenter != null)
            {
                var cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
                if (cell == null)
                {
                    dataGrid.ScrollIntoView(row, dataGrid.Columns[column]);
                    cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
                }
                return cell;
            }
            return null;
        }

        public static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                var visualChild = child as T;
                if (visualChild != null)
                    return visualChild;
                var childOfChild = FindVisualChild<T>(child);
                if (childOfChild != null)
                    return childOfChild;
            }
            return null;
        }
        #endregion

        #region Order by Data Grid
        public static void OrderBy_DataGrid(DataTable dt)
        {
            int i = 0;
            foreach (DataRow row in dt.Rows)
                row["LineNo"] = ++i;
        }
        #endregion


        //Price Related

        #region Price Convertion
        public static decimal getSavePrice(decimal dPrice, TextBox txtCurrencyRate)
        {
            decimal dUnitPrice = 0, dExRate = 0;
            if (txtCurrencyRate.Text.Trim().Length > 0)
                dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

            dUnitPrice = dPrice * dExRate;
            return dUnitPrice;
        }
        public static decimal getSavePrice(decimal dPrice, decimal dCurrencyRate)
        {
            decimal dUnitPrice = 0;

            dUnitPrice = dPrice * dCurrencyRate;
            return dUnitPrice;
        }
        public static decimal getDisplayPrice(decimal dPrice, decimal dExRate)
        {
            decimal dUnitPrice = 0;
            if (dExRate > 0)
                dUnitPrice = dPrice / dExRate;
            return dUnitPrice;
        }
        public static decimal getDisplayPrice(decimal dPrice, TextBox txtCurrencyRate)
        {
            decimal dUnitPrice = 0, dExRate = 0;
            if (txtCurrencyRate.Text.Trim().Length > 0)
                dExRate = decimal.Parse(txtCurrencyRate.Text.Trim());

            if (dExRate > 0)
                dUnitPrice = dPrice / dExRate;
            return dUnitPrice;
        }
        #endregion


        public static decimal Get_StoreStockBalance_Qty(string sStore_ID, string sItem_ID)
        {
            //tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);//For purpose of getting Correct Item ID (Sometimes this may be simple or capita letters)
            return clsProcessMethods.Get_StoreStockBalance_Qty(sStore_ID, sItem_ID, "default", "default", "default", "0", "0");
        }

        //Stock Validation
        public static DataTable GetItemGroupedItemFloorstockTable(DataTable dt_In, string sItemColumnName, string sQtyColumnName, string sStore_ID)
        {
            DataTable dtGroupedItem = new DataTable();
            dtGroupedItem.Columns.Add("Item_ID");
            dtGroupedItem.Columns.Add("Qty");
            dtGroupedItem.Columns.Add("IssuedQty");
            dtGroupedItem.Columns.Add("FloorQty");

            var newResults = from row in dt_In.AsEnumerable()
                             group row by new { ItemID = (row.Field<string>(sItemColumnName)) } into grp
                             select new
                             {
                                 Item_ID = grp.Key.ItemID.ToUpper(),
                                 Quantity = grp.Sum((r) => decimal.Parse(r[sQtyColumnName].ToString())),
                                 FloorQuantity = Get_StoreStockBalance_Qty(sStore_ID, (grp.Key.ItemID))
                             };

            foreach (var record in newResults)
                dtGroupedItem.Rows.Add(record.Item_ID, record.Quantity, 0, record.FloorQuantity);

            return dtGroupedItem;
        }

        public static bool CheckItemFloorStockTable(DataTable dtItemFloorStock)
        {
            bool bValidate = true;
            foreach (DataRow dr in dtItemFloorStock.Rows)
            {
                string sItem_ID = clsValidate.ValidateRowValue(dr, "Item_ID", "default");
                decimal dQty = clsValidate.ValidateRowValue(dr, "Qty", 0m);
                decimal dIssuedQty = clsValidate.ValidateRowValue(dr, "IssuedQty", 0m);
                decimal dFloorQty = clsValidate.ValidateRowValue(dr, "FloorQty", 0m);

                tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItem_ID);
                if ((dFloorQty + dIssuedQty) < dQty && !oItem.IsGiftVoucher)
                {
                    bValidate = false;
                    SEACCMessageBox.Show("Not Enough Floor Qty..!", "Item ID : " + sItem_ID + "\nItem Name : " + clsGenaralName.getName_Item(sItem_ID) + "", MessageBoxButton.OK, "Red");
                    break;
                }
            }

            return bValidate;
        }

        #region Update Stock
        public static void UpdateStock(string sStoreID, string sItemID, decimal dQty)
        {
            tbl_genStore_Stock oStock = tbl_genStore_Stock.Select(sStoreID, sItemID, "default", "default", "default", "0", "0");
            if (oStock != null)
            {
                oStock.Qty += dQty;
                oStock.Update();
            }
            else
            {
                if (dQty > 0)
                {
                    tbl_genStore_Stock oNewStoreStock = new tbl_genStore_Stock(sStoreID, sItemID, "default", "default", "default", "0", "0", dQty, 0, 0, 0, 0, 0, 0, 0);
                    oNewStoreStock.Insert();
                }
            }
        }
        #endregion

        public static bool GetReportPath(int iReportID, bool bPrint_Default, ref string ReportName, ref string ReportName2, ref string s_Path)
        {
            ReportName = "";
            ReportName2 = "";
            try
            {
                tbl_securityFunctionMaster_Report detail = tbl_securityFunctionMaster_Report.Select(iReportID);
                if (detail != null)
                {
                    s_Path = detail.ReportPath.Trim();
                    ReportName = detail.DisplayName.Trim();
                    if (detail.DisplayName2 != null)
                        ReportName2 = detail.DisplayName2.Trim();
                }


                var oReportConfigs = tbl_securityFunctionMaster_Report_Advanced.SelectAllByFunction_ID(iReportID).Where(r => r.CompanyBranch_ID == clsSecurity.BranchID);
                if (oReportConfigs.Count() == 1)
                {
                    tbl_securityFunctionMaster_Report_Advanced oReportConfig = oReportConfigs.First();
                    s_Path = oReportConfig.ReportPath.Trim();

                }
                else if (oReportConfigs.Count() > 1)
                {
                    s_Path = "";

                    tbl_securityFunctionMaster_Report_Advanced oReportConfig = oReportConfigs.Where(r => r.IsDefault).FirstOrDefault();
                    if (bPrint_Default && oReportConfig != null)
                    {
                        s_Path = oReportConfig.ReportPath.Trim();
                    }
                    else
                    {
                        List<string> lstParameeters = new List<string>();
                        lstParameeters.Add(iReportID.ToString());
                        lstParameeters.Add(clsSecurity.BranchID);

                        frmSearchForm rowDataSearch = new frmSearchForm(lstParameeters);
                        List<string> lstResult = rowDataSearch.Show(Search.Pos_ReportSearch);
                        if (rowDataSearch.DialogResult == true)
                        {
                            s_Path = lstResult[1];
                        }
                        else
                            return false;
                    }
                }

            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }

            if (s_Path == null || s_Path.Length <= 0)
            {
                SEACCMessageBox.Show("Report is not linked...!", "", MessageBoxButton.OK, "Red");
                return false;
            }
            else
                return true;
        }

        public static decimal GetAdavanceTotal(int sPosTransaction_Index)
        {
            decimal dAmount = 0;

            foreach (tbl_posReceipt oPosTx in tbl_posReceipt.SelectAllByPosTransaction_Index(sPosTransaction_Index))
            {
                tbl_posReceipt oReceipt = tbl_posReceipt.Select(oPosTx.PosReceipt_ID);
                if (oReceipt != null && !oReceipt.IsDeleted)//&& oReceipt.IsAdvance
                    dAmount += oReceipt.TotalAmount;
            }

            return dAmount;
        }

        public static BitmapImage ImageFromBytearray(byte[] imageData)
        {

            if (imageData == null)
                return null;
            MemoryStream strm = new MemoryStream();
            strm.Write(imageData, 0, imageData.Length);
            strm.Position = 0;
            System.Drawing.Image img = System.Drawing.Image.FromStream(strm);

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            MemoryStream memoryStream = new MemoryStream();
            img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            memoryStream.Seek(0, SeekOrigin.Begin);
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.EndInit();

            return bitmapImage;
        }

        #region Day End Check
        public static bool Check_DayEndComplted_PosTransactionUpdate(int iPosTransaction_Index)
        {
            bool bReturn = false;
            tbl_posTransaction oPosTx = tbl_posTransaction.Select(iPosTransaction_Index);
            if (oPosTx != null)
            {
                tbl_posDayStartAndEnd oDayEnd = tbl_posDayStartAndEnd.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).FirstOrDefault(r => r.DateCreated.Date == oPosTx.PosTransactiondate.Date);
                if (oDayEnd != null)
                {
                    bReturn = oDayEnd.IsApproved;
                }
            }
            return bReturn;
        }

        public static bool Check_DayEndComplted_PosTransactionUpdate(tbl_posTransaction oPoS_Transaction)
        {
            bool bReturn = false;
            if (oPoS_Transaction != null)
            {
                tbl_posDayStartAndEnd oDayEnd = tbl_posDayStartAndEnd.SelectAllByCompanyBranch_ID(clsSecurity.BranchID).FirstOrDefault(r => r.DateCreated.Date == oPoS_Transaction.PosTransactiondate.Date);
                if (oDayEnd != null)
                {
                    bReturn = oDayEnd.IsApproved;
                }
            }
            return bReturn;
        }
        
        public static bool Check_ManagerSignOff_Created(int iDayDetailIndex )
        {
            bool bStatus = false;
            tbl_posDayStartAndEnd_Detail oDayDetail_Session = tbl_posDayStartAndEnd_Detail.Select(iDayDetailIndex);
            if (oDayDetail_Session != null)
            {
                bStatus = oDayDetail_Session.IsMgtSignOffCreated;
            }

            return bStatus;
        }
        #endregion

        public static decimal Get_PendingReturn_Qty(int iItemLine_No, int iPos_Tx_ID, int iCurrent_POS_Return_ID)
        {
            decimal dSelling_Qty = 0;
            decimal dReturned_Qty = 0;

            tbl_posTransaction_Detail oSold_Item = tbl_posTransaction_Detail.Select(iItemLine_No, iPos_Tx_ID);
            if (oSold_Item != null)
            {
                dSelling_Qty += oSold_Item.Qty;

                foreach (tbl_posTransaction_Detail oDetail in tbl_posTransaction_Detail.SelectAll().Where(r => r.PosTransaction_Index != iCurrent_POS_Return_ID && r.PrevPosTx_Index == oSold_Item.PosTransaction_Index && r.PrevPosTx_LineNo == oSold_Item.Line_No))
                {
                    tbl_posTransaction OCRN = tbl_posTransaction.Select(oDetail.PosTransaction_Index);
                    if (OCRN != null && !OCRN.IsDeleted)
                        dReturned_Qty += oDetail.Qty;
                }

            }
            return (dSelling_Qty + dReturned_Qty);
        }

    }
}
