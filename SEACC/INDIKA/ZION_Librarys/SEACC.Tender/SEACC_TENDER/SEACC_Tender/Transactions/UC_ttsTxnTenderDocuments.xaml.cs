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
using SEACC_WPFControls;
using DataTire;
using SEACC_Tender.UserControls;
using System.Data;
using Digiteq_Logic;
using SEACC_Tender.Search_Forms;

namespace SEACC_Tender
{
    /// <summary>
    /// Interaction logic for UC_ttsTxnTenderDocuments.xaml
    /// </summary>
    public partial class UC_ttsTxnTenderDocuments : UserControl
    {
        #region class variables
        DataTable dt = new DataTable();
        private string sTenderID; 
        #endregion

        #region Form Validation
        public UC_ttsTxnTenderDocuments()
        {
            InitializeComponent();

            #region Form Initialize
            SEACC_Form.enmFormName = FormName.TenderItems;
            SEACC_Form.Initialize();
            #endregion

            #region Data Table Initialize
            //dt.Columns.Add("LineNo");
            dt.Columns.Add("DocID");
            dt.Columns.Add("TenderDocument");
            dt.Columns.Add("Description");
            //dt.Columns.Add("UploadDocument");
            //dt.Columns.Add("DocValidPeriod");
            dt.Columns.Add("Submitted", typeof(bool));
            dgr_TenderDoc.ItemsSource = dt.DefaultView;

            dgr_Main.dt.Columns.Add("TenderID");
            dgr_Main.dt.Columns.Add("TenderNo");
            dgr_Main.dt.Columns.Add("NoticeDate");
            //dgr_Main.dt.Columns.Add("DocumentList");
            #endregion

            #region Data Grid Intialize
            dgr_Main.Add_DatagridColoumn("Tender ID", "TenderID", 100, false);
            dgr_Main.Add_DatagridColoumn("Tender No", "TenderNo", 100);
            dgr_Main.Add_DatagridColoumn("Notice Date", "NoticeDate", 100);
            //dgr_Main.Add_DatagridColoumn("Document List", "DocumentList", 100); 
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

        public UC_ttsTxnTenderDocuments(string _sTenderID)
        {
            this.sTenderID = _sTenderID;
        }

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
                        #region Update
                        if (SEACC_Form.IsUpdateMode)
                        {
                            //tbl_ttsDocumentSubmit oldDetail = tbl_ttsDocumentSubmit.Select(txtTenderID.Tag.ToString(),);
                            //if (oldDetail != null)
                            //{
                                foreach (tbl_ttsDocumentSubmit oDetails in tbl_ttsDocumentSubmit.SelectAllByTender_ID(txtTenderID.Tag.ToString()))
                                {
                                    oDetails.Delete();
                                }

                                bool bSubmit = false;
                                foreach (DataRow row in dt.Rows)
                                {
                                    //string sLineNo = row["LineNo"].ToString();
                                    string sDocID = row["DocID"].ToString();
                                    bSubmit = bool.Parse(row["Submitted"].ToString());

                                    tbl_ttsDocumentSubmit oDetails = new tbl_ttsDocumentSubmit(txtTenderID.Tag.ToString(), sDocID, bSubmit);
                                    oDetails.Insert();
                                }

                                //tbl_ttsTenderNotice oNotice = tbl_ttsTenderNotice.Select(txtTenderID.Tag.ToString());
                                //if (oNotice != null)
                                //{
                                //    oNotice.IsApplicationCollected = 2;
                                //    oNotice.Update();
                                //}

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            //}
                        }
                        #endregion

                        #region Insert
                        else
                        {
                            bool bSubmit = false;
                            foreach (DataRow row in dt.Rows)
                            {
                                //string sLineNo = row["LineNo"].ToString();
                                string sDocID = row["DocID"].ToString();
                                bSubmit = bool.Parse(row["Submitted"].ToString());

                                tbl_ttsDocumentSubmit oDetails = new tbl_ttsDocumentSubmit(txtTenderID.Tag.ToString(), sDocID, bSubmit);
                                oDetails.Insert();
                            }

                            //tbl_ttsTenderNotice oNotice = tbl_ttsTenderNotice.Select(txtTenderID.Tag.ToString());
                            //if (oNotice != null)
                            //{
                            //    oNotice.DocumentListStatus = 1;
                            //    oNotice.Update();
                            //}
                            
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
                        sTenderID = txtTenderID.Tag.ToString();
                        ClearFields();
                        RefreshGrid();
                        FillDetails(sTenderID);
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
                        foreach (tbl_ttsDocumentSubmit oDetails in tbl_ttsDocumentSubmit.SelectAllByTender_ID(txtTenderID.Tag.ToString()))
                        {
                            if (oDetails != null)
                            {
                                //oDetails.IsCanceled = true;
                                //oDetails.Update();
                                //oDetails.Delete();
                            }
                        }
                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                        ClearFields();
                        RefreshGrid();
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

            dt.Clear();

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTenderID, true, false, false);

            txtTenderID.Text = "";
            txtTenderID.Tag = null;

        } 
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_ttsTenderNotice oDetail in tbl_ttsTenderNotice.SelectAll().Where(p => p.DocumentListStatus == 1 && p.IsCanceled != true))
                {
                    DateTime sNoticeDate = DateTime.Parse(clsRef_Name.get_Notice_Date(oDetail.Tender_ID));
                    dgr_Main.dt.Rows.Add(oDetail.Tender_ID, clsRef_Name.get_Bid_No(oDetail.Tender_ID), sNoticeDate.ToString(cls_Formater.Format_Date2));
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
        private void FillDetails(string sTenderID)
        {
            //tbl_ttsDocumentSubmit oDocumentSubmit = tbl_ttsDocumentSubmit.Select(sTenderID);
            if (sTenderID != null)
            {
                SEACC_Form.IsUpdateMode = true;

                txtTenderID.Text = clsRef_Name.get_Bid_No(sTenderID);
                txtTenderID.Tag = sTenderID;

                dt.Clear();
                foreach (tbl_ttsDocumentSubmit oDetail in tbl_ttsDocumentSubmit.SelectAll().Where(p => p.Tender_ID == sTenderID))
                {
                    //if (oDetail.IsSubmitted == true)
                    //dt.Rows[irowID]["Specification"] = true;
                    //int iRow = dt.Rows.Count + 1;
                    dt.Rows.Add(oDetail.Doc_ID, clsRef_Name.get_Document_Code(oDetail.Doc_ID), clsRef_Name.get_Document_Description(oDetail.Doc_ID), oDetail.IsSubmitted);
                }
            }
        } 
        #endregion

        #region Data grid event
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
        #endregion

        #region Grid Items Events
        private void btnGridItemAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtTenderID.Text != "" && txtTenderID.Tag.ToString() != null)
            {
                Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
                List<string> lstResult = RowDataSearch.Show(Search.Ten_Document);
                if (RowDataSearch.DialogResult == true)
                {
                    bool bItemOk = true;
                    foreach (DataRow row in dt.Rows)
                    {
                        string sDocID = row["DocID"].ToString();
                        if (sDocID == lstResult[0])
                        {
                            SEACCMessageBox.Show("Sorry", "This document already selected...!", MessageBoxButton.OK);
                            bItemOk = false;
                            break;
                        }
                    }
                    if (bItemOk)
                    {
                        //int iRowID = dt.Rows.Count + 1;
                        dt.Rows.Add(lstResult[0], lstResult[1], lstResult[3], false);
                    }
                }
            }
            else
            {
                SEACCMessageBox.Show("Sorry", "Please select Tender/BID number first...!", MessageBoxButton.OK);
            }
        }

        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_TenderDoc.SelectedItem;
            if (selectedItem != null)
                ((DataRowView)(dgr_TenderDoc.SelectedItem)).Row.Delete();
        } 
        #endregion

        #region Search
        private void txtTenderID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            txtTenderID.Text = "";
            txtTenderID.Tag = null;
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Tender);
            if (RowDataSearch.DialogResult == true)
            {
                bool bItemOk = true;
                foreach (tbl_ttsDocumentSubmit detail in tbl_ttsDocumentSubmit.SelectAllByTender_ID(lstResult[0]))
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
                    txtTenderID.Tag = lstResult[0];
                    txtTenderID.Text = lstResult[1];
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

            if (!clsValidation.Validate_EmptyValue(txtTenderID, ref strMessage))
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
                SEACCMessageBox.Show("Please select onr or more document(s)..", "", MessageBoxButton.OK);
                bStatus = false;
            }
            return bStatus;
        }

        #endregion

        private void lblNext_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            UC_ttsPreBidMeeting UC;
            if (txtTenderID.Tag != null)
                UC = new UC_ttsPreBidMeeting(txtTenderID.Tag.ToString());
            else
                UC = new UC_ttsPreBidMeeting();
            frm_SEACC_Window SW = new frm_SEACC_Window(UC, UC.SEACC_Form.FormName);
            SW.ShowDialog();
        }

    }
}
