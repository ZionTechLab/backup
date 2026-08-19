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
using SEACC_WPFControls;
using Digiteq_Logic;
using SEACC_Tender.UserControls;
using System.Data;
using SEACC_Tender.Search_Forms;
using System.Threading;

namespace SEACC_Tender
{
    /// <summary>
    /// Create by Janith Srimal
    /// 2017-05-13
    /// </summary>
    public partial class UC_ttsPreBidMeeting : UserControl
    {
        #region Class Variables
        bool bIsItemChanged = false;
        public static DataTable dt_Competitors = new DataTable();
        private string sTenderID;
        private string sPreBidMeeting;
        public int iFormID;
        #endregion

        #region Form Load
        public UC_ttsPreBidMeeting()
        {
            InitializeComponent();

            #region Form Initialize
            SEACC_Form.enmFormName = FormName.PreBidMeeting;
            iFormID = clsSecurity.getFormID(FormName.PreBidMeeting);
            SEACC_Form.Initialize();
            #endregion

            #region Data table initialize
            dt_Competitors.Columns.Add("LineNo");
            dt_Competitors.Columns.Add("CompetitorID");
            dt_Competitors.Columns.Add("Competitor");
            dt_Competitors.Columns.Add("Representer");
            dt_Competitors.Columns.Add("Designation");
            dt_Competitors.Columns.Add("Remarks");
            dgr_Tender.ItemsSource = dt_Competitors.DefaultView;

            dgr_Main.dt.Columns.Add("PreBidMeetingNo");
            dgr_Main.dt.Columns.Add("TenderID");
            dgr_Main.dt.Columns.Add("TenderNo");
            dgr_Main.dt.Columns.Add("NoticeDate");
            dgr_Main.dt.Columns.Add("PreBidMeetingDate");
            dgr_Main.dt.Columns.Add("Status");
            //dgr_Main.dt.Columns.Add("Venue"); 
            #endregion

            #region Datagrid intialize
            dgr_Main.Add_DatagridColoumn("Pre Bid Meeting No", "PreBidMeetingNo", 120, false);
            dgr_Main.Add_DatagridColoumn("Tender ID", "TenderID", 100, false);
            dgr_Main.Add_DatagridColoumn("Tender No", "TenderNo", 100);
            dgr_Main.Add_DatagridColoumn("Notice Date", "NoticeDate", 100);
            dgr_Main.Add_DatagridColoumn("Meeting Date", "PreBidMeetingDate", 100);
            dgr_Main.Add_DatagridColoumn("Status", "Status", 100);
            //dgr_Main.Add_DatagridColoumn("Venue", "Venue", 200); 
            #endregion

            #region Action Button Intialize
            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_New.Click += Btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += Btn_Cancel_Click;
            //this.SEACC_Form.btn_Print.Click += Btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += Btn_Save_Click;
            #endregion

            ClearFields();
            RefreshGrid();
        } 
        #endregion

        public UC_ttsPreBidMeeting(string _sTenderID)
        {
            this.sTenderID = _sTenderID;
        }

        public void getCompetitorID(string sPreBidMeeting)
        {
            this.sPreBidMeeting = sPreBidMeeting;
        }

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth > 960)
                ColumnA.Width = new GridLength(400);
            else if (SEACC_Form.ActualWidth > 640)
                ColumnA.Width = new GridLength(310);
            else
                ColumnA.Width = new GridLength(200);
        }
        #endregion

        #region Action Buttons
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (SEACC_Form.CheckPermisshion_ToSave(SEACC_Form.IsUpdateMode))
            {
                if (CheckValidity())
                {
                    Cursor = Cursors.Wait;
                    string sTenderID = "";
                    try
                    {
                        sTenderID = txtTenderNo.Tag.ToString();
                        #region Update
                        if (SEACC_Form.IsUpdateMode)
                        {
                            tbl_ttsPreBidMeeting oldRecords = tbl_ttsPreBidMeeting.Select(txtPreBidMeetigNo.Tag.ToString());
                            if (oldRecords != null)
                            {
                                tbl_ttsPreBidMeeting oPreBidDetail = new tbl_ttsPreBidMeeting(txtPreBidMeetigNo.Tag.ToString(), txtTenderNo.Tag.ToString(), dtpPreBidMeetingDate.GetDateTime(),
                                    txtAddress1.Text, txtAddress2.Text, txtCountry.Tag.ToString(), txtCity.Tag.ToString(), txtTown.Tag.ToString(), txtRemarks.Text, false);
                                oPreBidDetail.Update();

                                #region Competitor
                                #region Pre Bid Meeting competitors
                                string sCompetitors = "", sLineNo = "", sComID = "", sRepesenter = "", sDesignation = "", sRemarks = "";
                                foreach (tbl_ttsPreBidMeeting_Competitors oDetail in tbl_ttsPreBidMeeting_Competitors.SelectAll().Where(p => p.PreBidMeeting_ID == txtPreBidMeetigNo.Tag.ToString()))
                                {
                                    oDetail.Delete();
                                }
                                foreach (DataRow row in dt_Competitors.Rows)
                                {
                                    sLineNo = row["LineNo"].ToString();
                                    sCompetitors = row["CompetitorID"].ToString();
                                    sRepesenter = row["Representer"].ToString();
                                    sDesignation = row["Designation"].ToString();
                                    sRemarks = row["Remarks"].ToString();

                                    //tbl_ttsPreBidMeeting_Competitors oldDetails = tbl_ttsPreBidMeeting_Competitors.Select(txtTenderNo.Tag.ToString(), sCompetitors);
                                    //if (oldDetails.Competitor_Id != sCompetitors)
                                    //{

                                    //    oldDetails.Delete();

                                    //}
                                    //else
                                    //{
                                    //    tbl_ttsPreBidMeeting_Competitors oldDetail = tbl_ttsPreBidMeeting_Competitors.Select(txtTenderNo.Tag.ToString(), sCompetitors);
                                    //    if (oldDetail.Competitor_Id != sCompetitors)
                                    //    {
                                    //        if (SEACC_Form.isAutoGenaratedCode)
                                    //            sComID = SEACC_Form.getAutoGeneratedCode();
                                    //    }
                                    //    else
                                    //    {
                                    //        sComID = sCompetitors;
                                    //    }
                                    //}
                                    tbl_ttsPreBidMeeting_Competitors oDetails = new tbl_ttsPreBidMeeting_Competitors(txtPreBidMeetigNo.Tag.ToString(), sLineNo, sCompetitors, sRepesenter, sDesignation, sRemarks);
                                    oDetails.Insert();
                                }

                                #endregion

                                #endregion

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                        #endregion

                        #region Insert
                        else
                        {
                            if (SEACC_Form.isAutoGenaratedCode)
                                txtPreBidMeetigNo.Tag = SEACC_Form.getAutoGeneratedCode();

                            tbl_ttsPreBidMeeting oPreBidDetail = new tbl_ttsPreBidMeeting(txtPreBidMeetigNo.Tag.ToString(), txtTenderNo.Tag.ToString(), dtpPreBidMeetingDate.GetDateTime(),
                                    txtAddress1.Text, txtAddress2.Text, txtCountry.Tag.ToString(), txtCity.Tag.ToString(), txtTown.Tag.ToString(), txtRemarks.Text, false);
                            oPreBidDetail.Insert();

                            #region Pre Bid Meeting competitors
                            string sCompetitorID = "", sLineNo = "", sComID = "", sRepesenters = "", sDesignations = "", sRemark = "";
                            foreach (DataRow row in dt_Competitors.Rows)
                            {
                                sLineNo = row["LineNo"].ToString();
                                sCompetitorID = row["CompetitorID"].ToString();
                                sRepesenters = row["Representer"].ToString();
                                sDesignations = row["Designation"].ToString();
                                sRemark = row["Remarks"].ToString();
                                //tbl_ttsPreBidMeeting_Competitors oldDetail = tbl_ttsPreBidMeeting_Competitors.Select(txtTenderNo.Tag.ToString(), sCompetitorID);
                                //if (oldDetail.Competitor_Id != sCompetitorID)
                                //{
                                //    if (SEACC_Form.isAutoGenaratedCode)
                                //        sComID = SEACC_Form.getAutoGeneratedCode();
                                //}
                                //else
                                //{
                                sComID = sCompetitorID;
                                //}
                                tbl_ttsPreBidMeeting_Competitors oDetails = new tbl_ttsPreBidMeeting_Competitors(txtPreBidMeetigNo.Tag.ToString(), sLineNo, sCompetitorID, sRepesenters, sDesignations, sRemark);
                                oDetails.Insert();

                            }
                            #endregion

                            Attachments.Insert(txtPreBidMeetigNo.Tag.ToString());

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
                        Cursor = Cursors.Arrow;
                        string sPreBidMeetingNo = txtPreBidMeetigNo.Tag.ToString();
                        ClearFields();
                        RefreshGrid();
                        RefreshCompetitorGrid(sPreBidMeetingNo);
                        FillDetails(sPreBidMeetingNo);
                    }
                }
            }
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                    if (bMessegeBoxResult)
                    {
                        tbl_ttsPreBidMeeting oDetail = tbl_ttsPreBidMeeting.Select(txtPreBidMeetigNo.Tag.ToString());
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

        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        } 
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            dt_Competitors.Clear();

            Attachments.Clear(SEACC_Form.Function_ID);

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtPreBidMeetigNo, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAddress1, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAddress2, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCity, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCountry, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTenderNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTown, true, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpPreBidMeetingDate, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, true);

            txtPreBidMeetigNo.Text = "<Auto Generated>";
            txtPreBidMeetigNo.Tag = null;
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "Srilanka";
            txtTenderNo.Text = "";
            txtTown.Text = "";
            dtpPreBidMeetingDate.SetTime(DateTime.Now);
            txtRemarks.Text = "";

            txtTenderNo.Tag = null;
            txtCity.Tag = null;
            txtCountry.Tag = 94;
            txtTown.Tag = null;

        } 
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_ttsPreBidMeeting oDetail in tbl_ttsPreBidMeeting.SelectAll().Where(p => p.IsCanceled != true).OrderBy(p => p.PreBidMeeting_ID))
                {
                    DateTime dDate = DateTime.Parse(clsRef_Name.get_Notice_Date(oDetail.Tender_ID));
                    dgr_Main.dt.Rows.Add(oDetail.PreBidMeeting_ID, oDetail.Tender_ID, clsRef_Name.get_Bid_No(oDetail.Tender_ID), dDate.ToString(cls_Formater.Format_Date2), oDetail.PreBidMeeting_Date.ToString(cls_Formater.Format_Date2), "");
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Refresh Competitor Grid
        private void RefreshCompetitorGrid(string sPreBidMeetingID)
        {
            dt_Competitors.Clear();
            foreach (tbl_ttsPreBidMeeting_Competitors oPreBidCompetitor in tbl_ttsPreBidMeeting_Competitors.SelectAll().Where(p => p.PreBidMeeting_ID == sPreBidMeetingID))
            {
                tbl_ttsMasCompetitor oCompetitor = tbl_ttsMasCompetitor.Select(oPreBidCompetitor.Competitor_Id);
                if (oCompetitor != null)
                {
                    dt_Competitors.Rows.Add(oPreBidCompetitor.LineNo, oPreBidCompetitor.Competitor_Id, oCompetitor.Competitor_name, oPreBidCompetitor.Representer_Name, oPreBidCompetitor.Representer_Designation, oPreBidCompetitor.Remarks);
                }
            }
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sPreBidMeetingNo)
        {
            if (sPreBidMeetingNo != null)
            {
                SEACC_Form.IsUpdateMode = true;

                tbl_ttsPreBidMeeting oMeeting = tbl_ttsPreBidMeeting.Select(sPreBidMeetingNo);
                if (oMeeting != null)
                {
                    txtPreBidMeetigNo.Tag = sPreBidMeetingNo;
                    txtPreBidMeetigNo.Text = sPreBidMeetingNo;
                    txtTenderNo.Tag = oMeeting.Tender_ID;
                    txtTenderNo.Text = clsRef_Name.get_Bid_No(oMeeting.Tender_ID);
                    dtpPreBidMeetingDate.SetTime(oMeeting.PreBidMeeting_Date);
                    txtRemarks.Text = oMeeting.Remarks;

                    txtAddress1.Text = oMeeting.PreBidMeeting_Address1;
                    txtAddress2.Text = oMeeting.PreBidMeeting_Address2;
                    txtCity.Tag = oMeeting.PreBidMeeting_City_ID;
                    txtCity.Text = clsRef_Name.get_City_Name(oMeeting.PreBidMeeting_City_ID);
                    txtCountry.Tag = oMeeting.PreBidMeeting_Country_ID;
                    txtCountry.Text = clsRef_Name.get_Country_Name(oMeeting.PreBidMeeting_Country_ID);
                    txtTown.Tag = oMeeting.PreBidMeeting_Town_ID;
                    txtTown.Text = clsRef_Name.get_Town_Name(oMeeting.PreBidMeeting_Town_ID);

                    RefreshCompetitorGrid(sPreBidMeetingNo);

                    Attachments.FillDetails(sPreBidMeetingNo);
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
                if (CheckValidity_DuplicateKey())
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
            else if (!clsValidation.Validate_EmptyValue(txtCountry, ref strMessage))
                bStatus = false;
            else if (!clsValidation.Validate_EmptyValue(txtCity, ref strMessage))
                bStatus = false;
            else if (!clsValidation.Validate_EmptyValue(txtTown, ref strMessage))
                bStatus = false;

            if (bStatus == false)
                SEACCMessageBox.Show("Fields cannot be Empty", strMessage, MessageBoxButton.OK);

            return bStatus;
        }

        public bool CheckValidity_DuplicateKey()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtPreBidMeetigNo.Text = SEACC_Form.getAutoGeneratedCode();

                txtPreBidMeetigNo.Tag = txtPreBidMeetigNo.Text;

                tbl_ttsPreBidMeeting detail = tbl_ttsPreBidMeeting.Select(txtPreBidMeetigNo.Tag.ToString());
                if (detail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }


        #endregion            

        #region Search
        private void txtTenderNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtTenderNo.Text = "";
            txtTenderNo.Tag = "";

            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Tender);
            if (RowDataSearch.DialogResult == true)
            {
                bool bItemOk = true;
                foreach (tbl_ttsPreBidMeeting detail in tbl_ttsPreBidMeeting.SelectAllByTender_ID(lstResult[0]))
                {
                    if (detail != null)
                    {
                        //pop_Error.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Slide;
                        //pop_Error.IsOpen = true;

                        //txtError.Text = "This Record Already Added";
                        bItemOk = false;
                        FillDetails(detail.PreBidMeeting_ID);
                    }
                }
                if (bItemOk)
                {
                    ClearFields();
                    txtTenderNo.Tag = lstResult[0];
                    txtTenderNo.Text = lstResult[1];
                }
            }
        }

        private void txtPreBidMeetigNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Ten_PreBidMeeting);
            if (RowDataSearch.DialogResult == true)
            {
                FillDetails(lstResult[0]);
            }
        }

        private void txtCountry_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Country);
            if (RowDataSearch.DialogResult == true)
            {
                txtCountry.Tag = lstResult[0];
                txtCountry.Text = lstResult[1];
            }
        }

        private void txtCity_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.City);
            if (RowDataSearch.DialogResult == true)
            {
                txtCity.Tag = lstResult[0];
                txtCity.Text = lstResult[1];
                txtCountry.Tag = lstResult[6];
                txtCountry.Text = lstResult[7];
            }
        }

        private void txtTown_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtCity.Tag != null && txtCity.Text != "")
            {
                lstParameeters.Add(txtCity.Tag.ToString());
            }

            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.Towns);
            if (RowDataSearch.DialogResult == true)
            {
                txtTown.Tag = lstResult[0];
                txtTown.Text = lstResult[1];
                txtCity.Tag = lstResult[2];
                txtCity.Text = lstResult[3];
                txtCountry.Tag = lstResult[8];
                txtCountry.Text = lstResult[9];
            }
        } 
        #endregion

        #region Popup Lost Focus
        private void pop_Error_LostFocus(object sender, RoutedEventArgs e)
        {
            FillDetails(txtTenderNo.Tag.ToString());
        } 
        #endregion

        #region Datagrid Events
        private void dgr_Main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object oItem = dgr_Main.grdMain.SelectedItem;
                if (oItem != null)
                {
                    string sId = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(oItem) as TextBlock).Text;
                    FillDetails(sId);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        private void dgr_Tender_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var vDgv_Cell = dgr_Tender.CurrentCell;
                //int irowID = dgr_Cheque.SelectedIndex;
                object item = dgr_Tender.SelectedItem;

                if (vDgv_Cell.Column.Header.ToString() == "Country")
                {
                    frmSearch RowDataSearch = new frmSearch();
                    List<string> lstResult = RowDataSearch.Show(Search.Country);
                    if (RowDataSearch.DialogResult == true)
                    {
                        int irowID = dgr_Tender.SelectedIndex;
                        dt_Competitors.Rows[irowID]["Country"] = lstResult[1];
                        dt_Competitors.Rows[irowID]["CountryID"] = lstResult[0];
                    }
                }
                else if (vDgv_Cell.Column.Header.ToString() == "City")
                {
                    frmSearch RowDataSearch = new frmSearch();
                    List<string> lstResult = RowDataSearch.Show(Search.City);
                    if (RowDataSearch.DialogResult == true)
                    {
                        int irowID = dgr_Tender.SelectedIndex;
                        dt_Competitors.Rows[irowID]["City"] = lstResult[1];
                        dt_Competitors.Rows[irowID]["CityID"] = lstResult[0];
                        dt_Competitors.Rows[irowID]["CountryID"] = lstResult[6];
                        dt_Competitors.Rows[irowID]["Country"] = lstResult[7];
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        #endregion

        #region Data Grid Item Add
        private void btnGridItemAdd_Click(object sender, RoutedEventArgs e)
        {
            frm_MasCompetitor RowDataSearch = new frm_MasCompetitor();
            List<string> lstResult = RowDataSearch.Show();


            if (RowDataSearch.DialogResult == true)
            {
                bool bItemOk = true;
                foreach (DataRow row in dt_Competitors.Rows)
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
                    int iRow = dt_Competitors.Rows.Count + 1;
                    dt_Competitors.Rows.Add(iRow, lstResult[0], lstResult[1], "", "", "");
                }
            }
        }

        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_Tender.SelectedItem;
            if (selectedItem != null)
            {
                ((DataRowView)(dgr_Tender.SelectedItem)).Row.Delete();
            }
        } 
        #endregion

    }
}
