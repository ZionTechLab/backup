using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SEACC_Tender.Search_Forms;
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
using SEACC_Tender.UserControls;

namespace SEACC_Tender.Transactions
{
    /// <summary>
    /// Create by Janith Srimal
    /// 2017-05-16
    /// </summary>
    public partial class UC_TenderReadings : UserControl
    {
        #region Class Variables
        private DataTable dt = new DataTable();
        private DataTable dt_Item = new DataTable();
        #endregion

        #region Form Load
        public UC_TenderReadings()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.TenderReading;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dt.Columns.Add("SRNo");
            dt.Columns.Add("ItemID");
            dt.Columns.Add("ItemName");
            dt.Columns.Add("CompetitorID");
            dt.Columns.Add("Competitor");
            dt.Columns.Add("Terms");
            dt.Columns.Add("CurrencyID");
            dt.Columns.Add("Currency");
            dt.Columns.Add("UnitPrice");
            dt.Columns.Add("BidBond");
            dt.Columns.Add("PaymentReceipt");
            dt.Columns.Add("LocalAgent");
            dt.Columns.Add("Delivery");
            dgr_Tender.ItemsSource = dt.DefaultView;

            dt_Item.Columns.Add("SRNo");
            dt_Item.Columns.Add("ItemID");
            dt_Item.Columns.Add("ItemName");
            dt_Item.Columns.Add("GenericName");
            dt_Item.Columns.Add("Specification");
            dt_Item.Columns.Add("UoMCode");
            dt_Item.Columns.Add("UoM");
            dt_Item.Columns.Add("Quantity");
            dt_Item.Columns.Add("Strength");
            dt_Item.Columns.Add("ShelfLife");
            dt_Item.Columns.Add("Packing");
            dgr_Items.ItemsSource = dt_Item.DefaultView;

            dgr_Main.dt.Columns.Add("TenderID");
            dgr_Main.dt.Columns.Add("BidNo");
            dgr_Main.dt.Columns.Add("NoticeDate");
            dgr_Main.dt.Columns.Add("ReadingDate");
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Tender ID", "TenderID", 100,false);
            dgr_Main.Add_DatagridColoumn("Tender No", "BidNo", 100);
            dgr_Main.Add_DatagridColoumn("Notice Date", "NoticeDate", 100);
            dgr_Main.Add_DatagridColoumn("Reading Date", "ReadingDate", 150);
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_New.Click += Btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += Btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += Btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += Btn_Save_Click;
            #endregion

            ClearFields();
            RefreshGrid();
        }

        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 880)
                ColumnA.Width = new GridLength(200);
            else
                ColumnA.Width = new GridLength(310);
        }
        #endregion

        #region Action Buttons
        #region New
        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        } 
        #endregion

        #region Cancel
        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                    if (bMessegeBoxResult)
                    {
                        tbl_ttsTenderReadings oDetail = tbl_ttsTenderReadings.Select(txtTenderNo.Tag.ToString());
                        if (oDetail != null)
                        {
                            oDetail.IsCanceled = true;
                            oDetail.Update();

                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                            ClearFields();
                            RefreshGrid();
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

        private void Btn_Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {

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

        #region Save
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (SEACC_Form.CheckPermisshion_ToSave(SEACC_Form.IsUpdateMode))
            {
                if (CheckValidity())
                {
                    string sTenderID = "";
                    try
                    {
                        #region Update
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_ttsTenderReadings oldRecord = tbl_ttsTenderReadings.Select(txtTenderNo.Tag.ToString());
                            if (oldRecord != null)
                            {
                                tbl_ttsTenderReadings oReadings = new tbl_ttsTenderReadings(txtTenderNo.Tag.ToString(), dtpReadingDate.GetDateTime().Date, false);
                                oReadings.Update();

                                #region Reading Details
                                tbl_ttsTenderReadingsDetails.DeleteAllByTender_ID(txtTenderNo.Tag.ToString());

                                foreach (DataRow row in dt.Rows)
                                {
                                    string sSRNo = row["SRNo"].ToString();
                                    string sItem = row["ItemID"].ToString();
                                    string sBidder = row["CompetitorID"].ToString();
                                    string sTerms = row["Terms"].ToString();
                                    string sCurrencyID = row["CurrencyID"].ToString();
                                    decimal dUnitpIrce = decimal.Parse(row["UnitPrice"].ToString());
                                    string sBidBond = row["BidBond"].ToString();
                                    string sPaymentReceipt = row["PaymentReceipt"].ToString();
                                    string sLocalAgent = row["LocalAgent"].ToString();
                                    string sDelivery = row["Delivery"].ToString();

                                    string sCurrency = "";
                                    if (sCurrencyID != "")
                                    {
                                        sCurrency = sCurrencyID;
                                    }
                                    else
                                    {
                                        sCurrency = "default";
                                    }

                                    tbl_ttsTenderReadingsDetails oReadingDetails = new tbl_ttsTenderReadingsDetails(txtTenderNo.Tag.ToString(), sSRNo, sItem, sBidder, sTerms, sCurrency, dUnitpIrce, sBidBond, sPaymentReceipt, sLocalAgent, sDelivery);
                                    oReadingDetails.Insert();
                                }
                                #endregion

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                        #endregion

                        #region Insert
                        else
                        {
                            tbl_ttsTenderReadings oReadings = new tbl_ttsTenderReadings(txtTenderNo.Tag.ToString(), dtpReadingDate.GetDateTime().Date, false);
                            oReadings.Insert();

                            #region Reading Details
                            foreach (DataRow row in dt.Rows)
                            {
                                string sSRNo = row["SRNo"].ToString(); 
                                string sItem = row["ItemID"].ToString();
                                string sBidder = row["CompetitorID"].ToString();
                                string sTerms = row["Terms"].ToString();
                                string sCurrencyID = row["CurrencyID"].ToString();
                                decimal dUnitpIrce = decimal.Parse(row["UnitPrice"].ToString());
                                string sBidBond = row["BidBond"].ToString();
                                string sPaymentReceipt = row["PaymentReceipt"].ToString();
                                string sLocalAgent = row["LocalAgent"].ToString();
                                string sDelivery = row["Delivery"].ToString();

                                string sCurrency = "";
                                if (sCurrencyID != "")
                                {
                                    sCurrency = sCurrencyID;
                                }
                                else
                                {
                                    sCurrency = "default";
                                }


                                tbl_ttsTenderReadingsDetails oReadingDetails = new tbl_ttsTenderReadingsDetails(txtTenderNo.Tag.ToString(), sSRNo,sItem, sBidder, sTerms, sCurrency, dUnitpIrce, sBidBond, sPaymentReceipt, sLocalAgent, sDelivery);
                                oReadingDetails.Insert();
                            }
                            #endregion

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

                        sTenderID = txtTenderNo.Tag.ToString();
                        Cursor = Cursors.Arrow;
                        ClearFields();
                        RefreshGrid();
                        FillDetails(sTenderID);
                    }
                }
            }
        } 
        #endregion

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            dt.Clear();
            dt_Item.Clear();

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtTenderNo, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtSRNo, true, false, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtTerms, true, false, true);

            txtTenderNo.Tag = null;
            //txtSRNo.Tag = null;

            txtTerms.Text = "";
            txtTenderNo.Text = "";
            //txtSRNo.Text = "";

            dtpReadingDate.SetTime(DateTime.Now);
            
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_ttsTenderReadings oDetail in tbl_ttsTenderReadings.SelectAll().Where(p => !p.IsCanceled).OrderBy(p => p.TenderReading_Date))
                {
                    dgr_Main.dt.Rows.Add(oDetail.Tender_ID, clsRef_Name.get_Bid_No(oDetail.Tender_ID), clsRef_Name.get_Notice_Date(oDetail.Tender_ID), oDetail.TenderReading_Date.ToString(cls_Formater.Format_Date2));
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        } 
        #endregion

        #region Fill Details
        private void FillDetails(string sTenID)
        {
            if (sTenID != null)
            {
                try
                {
                    SEACC_Form.IsUpdateMode = true;

                    tbl_ttsTenderReadings oReadings = tbl_ttsTenderReadings.Select(sTenID);
                    if (oReadings != null)
                    {
                        txtTenderNo.Tag = oReadings.Tender_ID;
                        txtTenderNo.Text = clsRef_Name.get_Bid_No(oReadings.Tender_ID);
                        //txtSRNo.Text = oReadings.SerialNo;
                        dtpReadingDate.SetTime(oReadings.TenderReading_Date);

                        dt.Clear();
                        foreach (tbl_ttsTenderReadingsDetails oReadingDetails in tbl_ttsTenderReadingsDetails.SelectAll().Where(p => p.Tender_ID == sTenID))
                        {
                            tbl_ttsMasCompetitor oCom = tbl_ttsMasCompetitor.Select(oReadingDetails.Bidder_ID);
                            tbl_zCurrency oCur = tbl_zCurrency.Select(oReadingDetails.Currency);
                            if (oCom != null && oCur != null)
                            {
                                int iRow = dt.Rows.Count + 1;
                                dt.Rows.Add(oReadingDetails.SerialNo, oReadingDetails.Item_ID, clsRef_Name.get_Item_Name(oReadingDetails.Item_ID), oReadingDetails.Bidder_ID, oCom.Competitor_name, oReadingDetails.Terms, oReadingDetails.Currency, oCur.CurrencyCode, cls_Formater.FormatDecimal(oReadingDetails.UnitPrice, 2), oReadingDetails.BidBond, oReadingDetails.PaymentReceipt, oReadingDetails.LocalAgent, oReadingDetails.DeliveryDetails);
                            }
                        }
                        FillItemsGrid(sTenID);
                    }
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
            }

        }

        private void FillItemsGrid(string sTenID)
        {
            if (sTenID != null)
            {
                try
                {
                    dt_Item.Clear();
                    foreach (tbl_ttsTenderNotice_Detail oNoticeDetails in tbl_ttsTenderNotice_Detail.SelectAllByTender_ID(sTenID))
                    {
                        dt_Item.Rows.Add(oNoticeDetails.SerialNo, oNoticeDetails.Item_ID, clsRef_Name.get_Item_Name(oNoticeDetails.Item_ID), oNoticeDetails.TdrItem_Name, oNoticeDetails.TdrItem_Specification, oNoticeDetails.TdrUoM, clsRef_Name.get_UoM_Code(oNoticeDetails.TdrUoM), cls_Formater.FormatDecimal(oNoticeDetails.Qty, 2), oNoticeDetails.TdrItemStrength, oNoticeDetails.Tdrshelf_Life, oNoticeDetails.TdrPackSize);
                    }
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyFields())
            {
                if (CheckGridvalidity())
                {
                    bStatus = true;
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyFields()
        {
            string strMessage = "";
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtTenderNo, ref strMessage))
                bStatus = false;

            if (bStatus == false)
                SEACCMessageBox.Show("Fields cannot be Empty", strMessage, MessageBoxButton.OK);

            return bStatus;
        }
        private bool CheckGridvalidity()
        {
            bool bStatus = true;
            if (dt.Rows.Count <= 0)
            {
                SEACCMessageBox.Show("Information", "Please select Items..", MessageBoxButton.OK);
                bStatus = false;
            }
            return bStatus;
        }
        //private bool CheckGridEmptyFields()
        //{
        //    bool bStatus = true;
        //    string sSRRefNo = "";
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        sSRRefNo = row["SRNo"].ToString();
        //    }

        //    if (sSRRefNo == "")
        //    {
        //        SEACCMessageBox.Show("Information", "Please fill out this required field SR No", MessageBoxButton.OK);
        //        bStatus = false;
        //    }
        //    return bStatus;
        //}
        #endregion

        #region Grid Item Add
        private void btnGridItemAdd_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)dgr_Items.SelectedItem;
            if (dataRow != null)
            {
                frm_MasCompetitor RowDataSearch = new frm_MasCompetitor();
                List<string> lstResult = RowDataSearch.Show();

                string sSRNo = dataRow["SRNo"].ToString();
                string sItemID = dataRow["ItemID"].ToString();
                string sItemName = dataRow["ItemName"].ToString();
                if (RowDataSearch.DialogResult == true)
                {
                    bool bItemOk = true;
                    foreach (DataRow row in dt.Rows)
                    {
                        string sDocID = row["CompetitorID"].ToString();
                        if (sDocID == lstResult[0])
                        {
                            SEACCMessageBox.Show("Sorry", "This Competitor already selected...!", MessageBoxButton.OK);
                            bItemOk = false;
                            break;
                        }
                    }
                    if (bItemOk)
                    {
                        dt.Rows.Add(sSRNo, sItemID, sItemName, lstResult[0], lstResult[1], "", "", "", 0, "", "", "", "");
                    }
                }
            }
            else
                SEACCMessageBox.Show("Warning", "Please Select Tender Item...", MessageBoxButton.OK);
        }

        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_Tender.SelectedItem;
            if (selectedItem != null)
                ((DataRowView)(dgr_Tender.SelectedItem)).Row.Delete();
        } 
        #endregion

        #region Search Events
        private void txtTenderNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtTenderNo.Text = "";
            txtTenderNo.Tag = null;

            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Tender);
            if (RowDataSearch.DialogResult == true)
            {
                bool bItemOk = true;
                foreach (tbl_ttsTenderReadings detail in tbl_ttsTenderReadings.SelectAllByTender_ID(lstResult[0]))
                {
                    if (detail != null)
                    {
                        //pop_Error.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
                        //pop_Error.IsOpen = true;

                        //txtError.Text = "This Record Already Added";
                        
                        bItemOk = false;
                        FillDetails(lstResult[0]);
                    }
                }
                
                if (bItemOk)
                {
                    ClearFields();

                    txtTenderNo.Tag = lstResult[0];
                    txtTenderNo.Text = lstResult[1];

                    FillItemsGrid(lstResult[0]);
                }
            }
        } 
        #endregion

        #region Data Grid Event
        private void dgr_Main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object oItem = dgr_Main.grdMain.SelectedItem;
                if (oItem != null)
                {
                    string sTenID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(oItem) as TextBlock).Text;
                    //string sSRNo = (dgr_Main.grdMain.SelectedCells[2].Column.GetCellContent(oItem) as TextBlock).Text;
                    FillDetails(sTenID);
                }
            }
            catch (Exception ex)
            {

                SEACCExeption.Show(ex);
            }
        } 
        #endregion

        #region Grid Event Popup
        private void dgr_Tender_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var vDgv_Cell = dgr_Tender.CurrentCell;
                object item = dgr_Tender.SelectedItem;

                if (vDgv_Cell.Column.Header.ToString() == "Terms")
                {
                    txtTerms.Text = "";
                    pop_Event.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
                    pop_Event.IsOpen = true;

                    string GridID = (dgr_Tender.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                    txtTerms.Text = GridID;
                    txtTerms.Focus();
                }
                if (vDgv_Cell.Column.Header.ToString() == "Currency")
                {
                    frmSearch RowDataSearch = new frmSearch();
                    List<string> lstResult = RowDataSearch.Show(Search.Currency);
                    if (RowDataSearch.DialogResult == true)
                    {
                        int irowID = dgr_Tender.SelectedIndex;
                        dt.Rows[irowID]["CurrencyID"] = lstResult[0];
                        dt.Rows[irowID]["Currency"] = lstResult[2];
                    }
                }
            }
            catch (Exception ex)
            { }
        } 
        #endregion

        #region Grid cell editing event
        private void dgr_Tender_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                int irowID = dgr_Tender.SelectedIndex;
                string sColoumn = e.Column.Header.ToString();
                TextBox t = e.EditingElement as TextBox;
                decimal dUnitPrice = 0;

                //dQty = decimal.Parse(dt_Item.Rows[irowID]["Quantity"].ToString());

                switch (sColoumn)
                {
                    case "Unit Price":
                        if (t != null)
                            dUnitPrice = clsValidation.Validate_DecimalNumber(t.Text);
                        dt.Rows[irowID]["UnitPrice"] = cls_Formater.FormatDecimal(dUnitPrice, 2);
                        break;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        } 
        #endregion

        #region Popup Event
        private void btn_PoPSave_Click(object sender, RoutedEventArgs e)
        {
            int irowID = dgr_Tender.SelectedIndex;
            dt.Rows[irowID]["Terms"] = txtTerms.Text;

            pop_Event.IsOpen = false;
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            pop_Event.IsOpen = false;
        }
        private void pop_Event_LostFocus(object sender, RoutedEventArgs e)
        {
            int irowID = dgr_Tender.SelectedIndex;
            dt.Rows[irowID]["Terms"] = txtTerms.Text;
        }
        #endregion

    }
}
