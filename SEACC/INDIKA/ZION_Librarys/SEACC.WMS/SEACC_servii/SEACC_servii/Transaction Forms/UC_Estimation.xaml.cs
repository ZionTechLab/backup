using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataTire;
using Digiteq_Logic;
using SEACC_servii.Search_Forms;
using SEACC_WPFControls;
using System.Data;
using SEACC_servii.Reports;
using digiteq;

namespace SEACC_servii.Master_Forms
{
    public partial class UC_Estimation : UserControl
    {
        DataTable dt_detail = new DataTable();
     
        #region User Control Initialize
        public UC_Estimation()
        {
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Estimation;
            SEACC_Form.Initialize();

            #region Initialize Data table
            dgr_Main.dt.Columns.Add("estimation_ID");
            dgr_Main.dt.Columns.Add("estimation_Date");
            dgr_Main.dt.Columns.Add("customer_ID");
            dgr_Main.dt.Columns.Add("customerName");
            dgr_Main.dt.Columns.Add("storage_Period");
            dgr_Main.dt.Columns.Add("grandTotal");
            #endregion
          
            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Estimation ID", "estimation_ID", 80);
            dgr_Main.Add_DatagridColoumn("Estimation Date", "estimation_Date", 100);
            dgr_Main.Add_DatagridColoumn("Customer ID", "customer_ID", 40, false);
            dgr_Main.Add_DatagridColoumn("Customer Name", "customerName", 100);
            dgr_Main.Add_DatagridColoumn("Storage Period", "storage_Period", 90);
            dgr_Main.Add_DatagridColoumn("Grand Total", "grandTotal", 150);
            #endregion

            #region Initialize Data Table - Items
            dt_detail.Columns.Add("itemID");
            dt_detail.Columns.Add("itemName");
            dt_detail.Columns.Add("remark");
            dt_detail.Columns.Add("weight");
            dt_detail.Columns.Add("uomID");
            dt_detail.Columns.Add("uomCode");
            dt_detail.Columns.Add("qty");
            dt_detail.Columns.Add("qtySettle");            
            dt_detail.Columns.Add("weightSettle");
            dt_detail.Columns.Add("unitPrice");
            dt_detail.Columns.Add("unitDiscount");
            dt_detail.Columns.Add("totalDiscount");
            dt_detail.Columns.Add("totalAmount");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            this.SEACC_Form.btn_Print.Click += Btn_Print_Click;
            #endregion

            dgr_details.ItemsSource = dt_detail.DefaultView;

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 880)
                coloumnA.Width = new GridLength(200);
            else
                coloumnA.Width = new GridLength(310);
        }
        #endregion

        #region Action Buttons
        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    int iPeriod = cmbStoragePeriod.GetSelectedIndex();

                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_whTxn_Estimation OldRecord = tbl_whTxn_Estimation.Select(txtEstimationID.Text.Trim());
                            if (OldRecord != null)
                            {
                                tbl_whTxn_Estimation oDetail = new tbl_whTxn_Estimation(txtEstimationID.Text, dtpEstimation.GetDateTime().Date, txtCustomer.Tag.ToString(), iPeriod, txtRemark.Text, txtCurrency.Text, decimal.Parse(txtCurrencyRate.Text), decimal.Parse(txtSubTotal.Text), decimal.Parse(txtDiscountPercentage.Text),decimal.Parse(txtDiscountTotal.Text), decimal.Parse(txtGrandTotal.Text), false, OldRecord.UserID_Created, clsSecurity.UserIDLoged, OldRecord.UserID_Cancelled, OldRecord.TerminalID_Created, clsSecurity.TerminalID, OldRecord.TerminalID_Cancelled, OldRecord.Date_Created, clsSecurity.getServerDateTime(), OldRecord.Date_Cancelled, OldRecord.PrintCount);
                               oDetail.Update();

                                tbl_whTxn_Estimation_Detail.DeleteAllByEstimation_ID(OldRecord.Estimation_ID);
                                //foreach  (tbl_whTxn_Estimation_Detail delDetails in tbl_whTxn_Estimation_Detail.SelectAll().Where(p => p.Estimation_ID == OldRecord.Estimation_ID))
                                //    delDetails.Delete();


                                int lineNo = 0;
                                foreach (DataRow row in dt_detail.Rows)
                                {
                                    string itemId = row["itemID"].ToString();
                                    string remark = row["remark"].ToString();
                                    decimal weight = decimal.Parse(row["weight"].ToString());
                                    string uomID = row["uomID"].ToString();
                                    string uomCode = row["uomCode"].ToString();
                                    decimal qty = decimal.Parse(row["qty"].ToString());
                                    decimal qtySettle = decimal.Parse(row["qtySettle"].ToString());
                                    decimal weightSettle = decimal.Parse(row["weightSettle"].ToString());
                                    decimal unitprice = decimal.Parse(row["unitPrice"].ToString());
                                    decimal unitDiscount = decimal.Parse(row["unitDiscount"].ToString());
                                    decimal totalDiscount = decimal.Parse(row["totalDiscount"].ToString());
                                    decimal totalAmount = decimal.Parse(row["totalAmount"].ToString());

                                    lineNo++;

                                    tbl_whTxn_Estimation_Detail details = new tbl_whTxn_Estimation_Detail(lineNo, txtEstimationID.Tag.ToString(),itemId,remark, uomID, qty, qtySettle, weight, weightSettle, unitprice, unitDiscount, totalDiscount, totalAmount);
                                    details.Insert();
                                }

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion
                    #region Insert
                    else
                    {
                        tbl_whTxn_Estimation oEstimation = new tbl_whTxn_Estimation(txtEstimationID.Tag.ToString(), dtpEstimation.GetDateTime(), txtCustomer.Tag.ToString(), iPeriod, txtRemark.Text, txtCurrency.Text,decimal.Parse(txtCurrencyRate.Text), decimal.Parse(txtSubTotal.Text), decimal.Parse(txtDiscountPercentage.Text), decimal.Parse(txtDiscountTotal.Text), decimal.Parse(txtGrandTotal.Text), false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsConfig.defaultDateTime, clsConfig.defaultDateTime,0);
                        oEstimation.Insert();

                        int lineNo = 0;
                        foreach (DataRow row in dt_detail.Rows)
                        {
                            string itemId = row["itemID"].ToString();
                            string remark = row["remark"].ToString();
                            decimal weight = decimal.Parse(row["weight"].ToString());
                            string uomID = row["uomID"].ToString();
                            string uomCode = row["uomCode"].ToString();
                            decimal qty = decimal.Parse(row["qty"].ToString());
                            decimal qtySettle = decimal.Parse(row["qtySettle"].ToString());
                            decimal weightSettle = decimal.Parse(row["weightSettle"].ToString());
                            decimal unitprice = decimal.Parse(row["unitPrice"].ToString());
                            decimal unitDiscount = decimal.Parse(row["unitDiscount"].ToString());
                            decimal totalDiscount = decimal.Parse(row["totalDiscount"].ToString());
                            decimal totalAmount = decimal.Parse(row["totalAmount"].ToString());

                            lineNo++;
                            tbl_whTxn_Estimation_Detail details = new tbl_whTxn_Estimation_Detail(lineNo, txtEstimationID.Tag.ToString(), itemId, remark, uomID, qty, qtySettle, weight, weightSettle, unitprice, unitDiscount, totalDiscount, totalAmount);
                            details.Insert();
                        }
                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                    } 
                    #endregion
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    ClearFields();
                    RefreshGrid();
                }
            }
        }

        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            dt_detail.Clear();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtEstimationID.Tag != null && txtEstimationID.Tag.ToString() != "")
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_whTxn_Estimation detail = tbl_whTxn_Estimation.Select(txtEstimationID.Tag.ToString());
                            if (detail != null)
                            {
                                detail.IsCancelled = true;
                                detail.Date_Cancelled = clsSecurity.getServerDateTime();
                                detail.TerminalID_Cancelled = clsSecurity.TerminalID;
                                detail.UserID_Cancelled = clsSecurity.UserIDLoged;
                                detail.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);

                                ClearFields();
                                RefreshGrid();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }

        private void Btn_Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtEstimationID.Tag != null)
                {
                    Cursor = Cursors.Wait;
                    if (SEACC_Form.CheckPermisshion_ToUpdate())
                    {
                        //tbl_securityFunctionMaster_Report oReports = tbl_securityFunctionMaster_Report.Select((int)enum_ReportName.EstimationDetail);
                        //if (oReports != null)
                        {
                            DataSets.dts_ReportExport glb_dts_ExportReport = new DataSets.dts_ReportExport();
                            DataSets.dts_Estimation dts_Estimation = new DataSets.dts_Estimation();
                            dts_Estimation.dt_Company.Adddt_CompanyRow(clsSecurity.DigiteqName, clsSecurity.DigiteqEmail, clsSecurity.decryptPassword(clsCommon.getCompanyName()), clsSecurity.decryptPassword(clsCommon.getCompanyAddress1()), clsCommon.getCompanyAddress2(), clsCommon.getCompanyImage(), "Estimation","", "", clsSecurity.UserNameLoged, "");

                            tbl_whTxn_Estimation details = tbl_whTxn_Estimation.Select(txtEstimationID.Tag.ToString());
                            if (details != null)
                            {
                                //fill data table
                                foreach (tbl_whTxn_Estimation_Detail delDetails in tbl_whTxn_Estimation_Detail.SelectAll().Where(p => p.Estimation_ID == details.Estimation_ID))
                                {
                                    if (details.Storage_Period == 0)
                                    {
                                        dts_Estimation.dt_EstomationDetail.Adddt_EstomationDetailRow(delDetails.Estimation_ID, delDetails.Item_ID, clsRef_Name.get_Item_Name(delDetails.Item_ID), delDetails.Remarks, delDetails.Weight, delDetails.Uom_ID, clsRef_Name.get_UoM_Code(delDetails.Uom_ID), decimal.Parse(clsRef_Name.get_Item_UnitPriceD15(delDetails.Item_ID)), delDetails.Qty, delDetails.Amount);
                                    }
                                    else
                                    {
                                        dts_Estimation.dt_EstomationDetail.Adddt_EstomationDetailRow(delDetails.Estimation_ID, delDetails.Item_ID, clsRef_Name.get_Item_Name(delDetails.Item_ID), delDetails.Remarks, delDetails.Weight, delDetails.Uom_ID, clsRef_Name.get_UoM_Code(delDetails.Uom_ID), decimal.Parse(clsRef_Name.get_Item_UnitPriceD30(delDetails.Item_ID)), delDetails.Qty, delDetails.Amount);
                                    }

                                }

                                dts_Estimation.dt_Estimation.Adddt_EstimationRow(txtEstimationID.Tag.ToString(), txtCustomer.Tag.ToString(), clsRef_Name.get_Customer_Name(txtCustomer.Text), details.Storage_Period, txtRemark.Text, "", 0, 0, decimal.Parse(txtSubTotal.Text), decimal.Parse(txtDiscountPercentage.Text), decimal.Parse(txtDiscountTotal.Text), 0, decimal.Parse(txtGrandTotal.Text));
                                
                                frm_ReportViwer CRViwer = new frm_ReportViwer();
                                CRViwer.Print("\\Reports\\rpt_EstimationDetail.rpt", dts_Estimation, glb_dts_ExportReport.dt_rptParameter);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Print Failed", ex.Message);
            }
            finally
            {
                Cursor = Cursors.Arrow;
            }

        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtEstimationID, true, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpEstimation, true, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark, true, false, true);
            //cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCurrency, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtCurrency, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSubTotal, false, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDiscountPercentage, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDiscountTotal, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtGrandTotal, false, true, false);

            txtEstimationID.Tag = null;

            dtpEstimation.SetTime(DateTime.Now);
            txtCustomer.Text = "";
            txtRemark.Text = "";

            txtSubTotal.Text = "0.00";
            txtDiscountPercentage.Text = "0.00";
            txtDiscountTotal.Text = "0.00";
            txtGrandTotal.Text = "0.00";

            txtSubTotal.Tag = 0;
            txtDiscountPercentage.Tag = 0;
            txtDiscountTotal.Tag = 0;
            txtGrandTotal.Tag = 0;

            cmbStoragePeriod.SetValues(typeof(StoragePeriod));
            cmbStoragePeriod.SetSelectedIndex(-1);
            cmbStoragePeriod.IsEnabled = true;

            //tbl_zCurrency details = tbl_zCurrency.Select(clsConfig.DefaultCurrency);
            //if (details != null)
            //{
            //    txtCurrency.Text = details.Currency_ID;
            //    txtCurrencyRate.Text = details.CurrencyRate.ToString();
            //}
            txtCurrency.Text = "LKR/001";
            txtCurrencyRate.Text = "1.00";

            dt_detail.Clear();

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtEstimationID.setReadOnlyStatus(true);
                txtEstimationID.Text = "<Auto Generate>";
            }
            else
                txtEstimationID.setReadOnlyStatus(false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_whTxn_Estimation item in tbl_whTxn_Estimation.SelectAll().Where(p => p.Estimation_ID != "default" && !p.IsCancelled))
                {
                    dgr_Main.dt.Rows.Add(item.Estimation_ID, clsValidation.GetDisplayValue_Date(item.Estimation_Date), item.Customer_ID, clsRef_Name.get_Customer_Name(item.Customer_ID), ((StoragePeriod)item.Storage_Period).ToString(), cls_Formater.FormatDecimal(item.GrandTotal,2));
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_Qty())
                {
                    if (CheckValidity_DuplicateFiled())
                        bStatus = true;
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtEstimationID))
                bStatus = false;

            if (!clsValidation.Validate_EmptyValue(txtCustomer))
                bStatus = false;

            if (!clsValidation.Validate_EmptyValue(cmbStoragePeriod))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_Qty()
        {
            bool bStatus = true;

            if (dt_detail.Rows.Count > 0)
            {
                foreach (DataRow row in dt_detail.Rows)
                {
                    decimal qty = decimal.Parse(row["qty"].ToString());
                    if (qty <= 0)
                    {
                        string itemId = row["itemName"].ToString();

                        SEACCMessageBox.Show("Invalid Item QTY..!", itemId, MessageBoxButton.OK);
                        bStatus = false;
                        break;
                    }

                }
            }
            else
            {
                SEACCMessageBox.Show(" - ", "Please Add one or more items..", MessageBoxButton.OK);
                bStatus = false;
            }

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtEstimationID.Tag = SEACC_Form.getAutoGeneratedCode();

                tbl_whTxn_Estimation oDetail = tbl_whTxn_Estimation.Select(txtEstimationID.Tag.ToString());
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_whTxn_Estimation details = tbl_whTxn_Estimation.Select(sID);
                    if (details != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtEstimationID.IsEnabled = false;

                        txtEstimationID.Tag = details.Estimation_ID;
                        txtCustomer.Tag = details.Customer_ID;

                        txtEstimationID.Text = details.Estimation_ID;
                        dtpEstimation.SetTime(details.Estimation_Date);
                        txtCustomer.Text = clsRef_Name.get_Customer_Name(details.Customer_ID);
                        txtRemark.Text = details.Remarks;
                        //txtCurrency.Text = "";
                        //txtCurrencyRate.Text = "";

                        txtSubTotal.Text = cls_Formater.FormatDecimal(decimal.Parse(details.SubTotal.ToString()),2);
                        txtDiscountPercentage.Text = cls_Formater.FormatDecimal(decimal.Parse(details.DiscountPercentage.ToString()),2);
                        txtDiscountTotal.Text = cls_Formater.FormatDecimal(decimal.Parse(details.DiscountTotal.ToString()),2);
                        txtGrandTotal.Text = cls_Formater.FormatDecimal(decimal.Parse(details.GrandTotal.ToString()),2);


                        txtSubTotal.Tag = details.SubTotal;
                        txtDiscountPercentage.Tag = details.DiscountPercentage;
                        txtDiscountTotal.Tag = details.DiscountTotal;
                        txtGrandTotal.Tag = details.GrandTotal;

                        //cmbStoragePeriod.setReadOnlyStatus(true);
                        cmbStoragePeriod.SetSelectedIndex((int)details.Storage_Period);
                        cmbStoragePeriod.IsEnabled = false;
                        

                        foreach (tbl_whTxn_Estimation_Detail oDetails in tbl_whTxn_Estimation_Detail.SelectAllByEstimation_ID(sID))
                        {
                           dt_detail.Rows.Add(oDetails.Item_ID, clsRef_Name.get_Item_Name(oDetails.Item_ID), oDetails.Remarks, cls_Formater.FormatDecimal(oDetails.Weight,3), oDetails.Uom_ID, clsRef_Name.get_UoM_Code(oDetails.Uom_ID), cls_Formater.FormatDecimal(oDetails.Qty,0), cls_Formater.FormatDecimal(oDetails.QtySettle,3), cls_Formater.FormatDecimal(oDetails.WeightSettle,3),  cls_Formater.FormatDecimal(oDetails.UnitPrice,2), cls_Formater.FormatDecimal(oDetails.DiscountPresentage,2), cls_Formater.FormatDecimal(oDetails.DiscountTotal,2), cls_Formater.FormatDecimal(oDetails.Amount,2));
                        }
                  }
                }

            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Grid Events
        private void dgr_Main_MouseLeftButtonUp1_1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    dt_detail.Clear();
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        private void txtCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Customers);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomer.Text = lstResult[1];
                txtCustomer.Tag = lstResult[0];
            }
        }

        //private void txtCurrencyRate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    frmSearch RowDataSearch = new frmSearch();
        //    List<string> lstResult = RowDataSearch.Show(Search.Currency);
        //    if (RowDataSearch.DialogResult == true)
        //    {
        //        txtCurrencyRate.Text = lstResult[1];
        //        txtCurrency.Text = lstResult[0].ToString();
        //    }
        //}

        private void btnGridItemAdd_Click(object sender, RoutedEventArgs e)
        {
            int index = cmbStoragePeriod.GetSelectedIndex();
            if ( index != -1)
            {
                if (index == 0)
                {
                    frmSearch RowDataSearch = new frmSearch();
                    List<string> lstResult = RowDataSearch.Show(Search.Items);
                    if (RowDataSearch.DialogResult == true)
                    {
                        tbl_genItemMaster detail = tbl_genItemMaster.Select(lstResult[0]);
                        if (detail != null)
                        {
                            dt_detail.Rows.Add(lstResult[0], lstResult[1], "", 0, detail.Uom_ID, clsRef_Name.get_UoM_Code(detail.Uom_ID), 0, 0, 0, cls_Formater.FormatDecimal(detail.SellingPrice1,2), 0, 0, 0);
                            cmbStoragePeriod.IsEnabled = false;
                        }
                    }
                }

                else
                {
                    frmSearch RowDataSearch = new frmSearch();
                    List<string> lstResult = RowDataSearch.Show(Search.Items);
                    if (RowDataSearch.DialogResult == true)
                    {
                        tbl_genItemMaster detail = tbl_genItemMaster.Select(lstResult[0]);
                        if (detail != null)
                        {
                            dt_detail.Rows.Add(lstResult[0], lstResult[1], "", 0, detail.Uom_ID, clsRef_Name.get_UoM_Code(detail.Uom_ID), 0, 0, 0, cls_Formater.FormatDecimal(detail.SellingPrice2,2), 0, 0, 0);
                            cmbStoragePeriod.IsEnabled = false;
                        }
                    }
                }
                
            }
        }

        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_details.SelectedItem;
            if (selectedItem != null)
            {
                ((DataRowView)(dgr_details.SelectedItem)).Row.Delete();
            }
        }


        #region Calculate Taxes and GrandTotal
        private void CalculateTaxesAndGrandTotal()
        {
            //txtGrandTotal.Text = cls_Formater.FormatToCurrecyWithThousendSep(clsHelpMethods.CalculateGrandTotalAdvance(txtSubTotal, txtDiscount, txtPercentageDiscount, chkDiscount,
            //    txtNBT, txtPercentageNBT, chkNBT, txtVat, txtPercentageVat, chkVat, txtOtherTax, txtPercentageOtherTax, chkOtherTax));
            //txtGrandTotal.Text = cls_Formater.FormatToCurrecyWithThousendSep(clsHelpMethods.CalculateGrandTotalAdvance(txtSubTotal, txtDiscount, txtPercentageDiscount, chkDiscount,
            //    txtNBT, txtPercentageNBT, chkNBT, txtVat, txtPercentageVat, chkVat, txtOtherTax, txtPercentageOtherTax, chkOtherTax));
        }
        #endregion

        private void txtDiscountPercentage_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTaxesAndGrandTotal();
        }

        private void txtDiscountTotal_KeyUp(object sender, KeyEventArgs e)
        {

        }
        
        private void txtEstimationID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Estimation);
            if (RowDataSearch.DialogResult == true)
            {
                txtEstimationID.Text = lstResult[0];
                txtEstimationID.Tag = lstResult[0];
                ClearFields();
                fillDetails(lstResult[0]);
            }
        }
        
        private void dgr_details_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            CalculateLineAmount(e.Column.Header.ToString(), dgr_details.SelectedIndex, e.EditingElement as TextBox);
            CalcualteSubTotal();
        }

        private decimal Validate_Decimal(string Value)
        {
            decimal returnvalue = 0;
            try
            {
                returnvalue = decimal.Parse(Value);
            }
            catch (Exception)
            {
            }
            return returnvalue;
        }

        private void CalculateLineAmount(string sColoumn, int irowID, TextBox t)
        {
            try
            {
                decimal dQty = 0, dUnitPrice = 0, dNetAmount = 0;

                dUnitPrice = decimal.Parse(dt_detail.Rows[irowID]["unitPrice"].ToString());
                dQty = Validate_Decimal(dt_detail.Rows[irowID]["QTY"].ToString());

                switch (sColoumn)
                {
                    case "Quantity":
                        if (t != null)
                            dQty = Validate_Decimal(t.Text);
                        break;
                    case "Unit Price":
                        if (t != null)
                            dUnitPrice = Validate_Decimal(t.Text);
                        break;
                }
                dNetAmount = dQty * dUnitPrice;

                dt_detail.Rows[irowID]["QTY"] = cls_Formater.FormatDecimal(dQty,0);
                dt_detail.Rows[irowID]["unitPrice"] = cls_Formater.FormatDecimal(dUnitPrice,2);
                dt_detail.Rows[irowID]["totalAmount"] = cls_Formater.FormatDecimal(dNetAmount,2);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void CalcualteSubTotal()
        {
            try
            {
                decimal dSubTotal = 0, dDiscountPresentage = 0, dDiscountAmount = 0, dGrandTotal = 0;

                foreach (DataRow row in dt_detail.Rows)
                {
                    dSubTotal += decimal.Parse(row["totalAmount"].ToString());
                }

                dDiscountPresentage = decimal.Parse(txtDiscountPercentage.Tag.ToString());
                dDiscountAmount = dSubTotal * dDiscountPresentage / 100;
                dGrandTotal = dSubTotal - dDiscountAmount;

                txtSubTotal.Tag = dSubTotal;
                txtSubTotal.Text = cls_Formater.FormatDecimal(dSubTotal,2);

                txtDiscountTotal.Tag = dDiscountAmount;
                txtDiscountTotal.Text = cls_Formater.FormatDecimal(dDiscountAmount,2);

                txtGrandTotal.Tag = dGrandTotal;
                txtGrandTotal.Text = cls_Formater.FormatDecimal(dGrandTotal,2);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void txtDiscountPercentage_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal dSubTotal = 0, dDiscountPresentage = 0, dDiscountAmount = 0, dGrandTotal = 0;

                dSubTotal = decimal.Parse(txtSubTotal.Tag.ToString());
                dDiscountPresentage = decimal.Parse(txtDiscountPercentage.Text);

                dDiscountAmount = dSubTotal * dDiscountPresentage / 100;
                dGrandTotal = dSubTotal - dDiscountAmount;

                txtSubTotal.Tag = dSubTotal;
                txtSubTotal.Text = cls_Formater.FormatDecimal(dSubTotal,2);

                txtDiscountTotal.Tag = dDiscountAmount;
                txtDiscountTotal.Text = cls_Formater.FormatDecimal(dDiscountAmount,2);

                txtDiscountTotal.Tag = dDiscountAmount;
                txtDiscountTotal.Text = cls_Formater.FormatDecimal(dDiscountAmount,2);

                txtGrandTotal.Tag = dGrandTotal;
                txtGrandTotal.Text = cls_Formater.FormatDecimal(dGrandTotal,2);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void txtDiscountTotal_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal dSubTotal = 0, dDiscountPresentage = 0, dDiscountAmount = 0, dGrandTotal = 0;

                dSubTotal = decimal.Parse(txtSubTotal.Tag.ToString());
                dDiscountAmount = decimal.Parse(txtDiscountTotal.Text);

                dDiscountPresentage = dDiscountAmount * 100 / dSubTotal;
                dGrandTotal = dSubTotal - dDiscountAmount;

                txtSubTotal.Tag = dSubTotal;
                txtSubTotal.Text = cls_Formater.FormatDecimal(dSubTotal,2);

                txtDiscountPercentage.Tag = dDiscountPresentage;
                txtDiscountPercentage.Text = cls_Formater.FormatDecimal(dDiscountPresentage,2);

                txtDiscountTotal.Tag = dDiscountAmount;
                txtDiscountTotal.Text = cls_Formater.FormatDecimal(dDiscountAmount,2);

                txtGrandTotal.Tag = dGrandTotal;
                txtGrandTotal.Text = cls_Formater.FormatDecimal(dGrandTotal,2);
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void dgr_details_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var vDG_Cell = dgr_details.CurrentCell;
                int irowID = dgr_details.SelectedIndex;

                if (vDG_Cell.Column.SortMemberPath == "uomCode")
                {
                    frmSearch RowDataSearch = new frmSearch();
                    List<string> lstResult = RowDataSearch.Show(Search.UOM);
                    if (RowDataSearch.DialogResult == true)
                    {
                        dt_detail.Rows[irowID]["UOMID"] = lstResult[0];
                        dt_detail.Rows[irowID]["uomCode"] = lstResult[1];
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
    }
}