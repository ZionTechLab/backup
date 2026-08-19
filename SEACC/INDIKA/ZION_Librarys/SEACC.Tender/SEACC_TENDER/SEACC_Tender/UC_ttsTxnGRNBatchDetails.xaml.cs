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
using System.ComponentModel;

namespace SEACC_Tender
{
    /// <summary>
    /// Create by Janith Srimal
    /// 2017-05-08
    /// </summary>
    public partial class UC_ttsTxnGRNBatchDetails : UserControl
    {
        #region Class Variables
        DataTable dt = new DataTable();
        bool glbTender = false, glbItem = false, glbManufacturer = false, glbOther = false;
        #endregion

        #region Form Load
        public UC_ttsTxnGRNBatchDetails()
        {
            InitializeComponent();

            #region Form Initialize
            SEACC_Form.enmFormName = FormName.GRNBatchDetails;
            SEACC_Form.Initialize();
            #endregion

            #region Data Table Initialize
            dgr_Main.dt.Columns.Add("DocID");
            dgr_Main.dt.Columns.Add("DocCode");
            dgr_Main.dt.Columns.Add("DocType");
            dgr_Main.dt.Columns.Add("DocDescription");
            #endregion

            #region DataGrid Initialize
            dgr_Main.Add_DatagridColoumn("Doc. ID", "DocID", 80, false);
            dgr_Main.Add_DatagridColoumn("Doc. Code", "DocCode", 100);
            dgr_Main.Add_DatagridColoumn("Doc. Type", "DocType", 100);
            dgr_Main.Add_DatagridColoumn("Description", "DocDescription", 200);
            #endregion

            #region Action Button Initialize
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += Btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += Btn_Cancel_Click;
            //this.SEACC_Form.btn_Print.Click += Btn_Print_Click;
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
                ColumnA.Width = new GridLength(410);
        } 
        #endregion

        #region Action Buttons
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (SEACC_Form.CheckPermisshion_ToSave(SEACC_Form.IsUpdateMode))
            {
                if (CheckValidity())
                {
                    try
                    {
                        //#region Update
                        //if (SEACC_Form.IsUpdateMode)
                        //{
                        //    tbl_ttsTenderDocumentMaster oldDetail = tbl_ttsTenderDocumentMaster.Select(sDocID);
                        //    if (oldDetail != null)
                        //    {
                        //        if (chkTenderWise.IsChecked == true)
                        //        {
                        //            glbTender = true;
                        //        }
                        //        if (chkItemWise.IsChecked == true)
                        //        {
                        //            glbItem = true;
                        //        }
                        //        if (chkManufacturerWise.IsChecked == true)
                        //        {
                        //            glbManufacturer = true;
                        //        }
                        //        if (chkOther.IsChecked == true)
                        //        {
                        //            glbOther = true;
                        //        }
                        //        tbl_ttsTenderDocumentMaster odetail = new tbl_ttsTenderDocumentMaster(sDocID, txtDocCode.Text, cmbDocType.GetSelectedIndex(), txtDocDescription.Text, glbTender, glbItem, glbManufacturer, glbOther, false);
                        //        odetail.Update();

                        //        SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                        //    }
                        //}
                        //#endregion

                        //#region Insert
                        //else
                        //{
                        //    if (chkTenderWise.IsChecked == true)
                        //    {
                        //        glbTender = true;
                        //    }
                        //    if (chkItemWise.IsChecked == true)
                        //    {
                        //        glbItem = true;
                        //    }
                        //    if (chkManufacturerWise.IsChecked == true)
                        //    {
                        //        glbManufacturer = true;
                        //    }
                        //    if (chkOther.IsChecked == true)
                        //    {
                        //        glbOther = true;
                        //    }

                        //    if (SEACC_Form.isAutoGenaratedCode)
                        //        sDocID = txtDocID.Text = SEACC_Form.getAutoGeneratedCode();

                        //    tbl_ttsTenderDocumentMaster detail = new tbl_ttsTenderDocumentMaster(txtDocID.Text, txtDocCode.Text, cmbDocType.GetSelectedIndex(), txtDocDescription.Text, glbTender, glbItem, glbManufacturer, glbOther, false);
                        //    detail.Insert();

                        //    SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                        //}
                        //#endregion

                    }
                    catch (Exception Ex)
                    {
                        SEACCExeption.Show(Ex);
                    }

                    finally
                    {
                        ClearFields();
                        RefreshGrid();
                        //FillDetails(sDocID);
                    }
                }
            }
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            //if (SEACC_Form.IsUpdateMode)
            //{
            //    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
            //    if (bMessegeBoxResult)
            //    //{
            //    //    tbl_ttsTenderDocumentMaster Detail = tbl_ttsTenderDocumentMaster.Select(txtDocID.Tag.ToString());
            //    //    if (Detail != null)
            //    //    {
            //    //        Detail.IsCanceled = true;
            //    //        Detail.Update();

            //    //        SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
            //    //        ClearFields();
            //    //        RefreshGrid();
            //    //    }
            //    //}
            //}
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

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtGRNNo, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBrand, true, false, true);
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtSupplier, true, false, false);
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtItem, true, false, false);

            //txtDocCode.Text = "";
            //txtDocDescription.Text = "";
            //txtDocID.Tag = null;
            //txtDocID.Text = "";

            //chkItemWise.IsChecked = false;
            //chkManufacturerWise.IsChecked = false;
            //chkOther.IsChecked = false;
            //chkTenderWise.IsChecked = false;

            //cmbDocType.comboBox.ItemsSource = Common.clsHelpMethods.GetEnumDescription(typeof(DocumentType));
            //cmbDocType.SetSelectedIndex(0);
        } 
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                //foreach (tbl_ttsTenderDocumentMaster oDetails in tbl_ttsTenderDocumentMaster.SelectAll().Where(p => p.IsCanceled != true))
                //{
                //    string sDocumentType = (Common.clsHelpMethods.GetEnumDescription(typeof(DocumentType)))[oDetails.Doc_Type];
                //    dgr_Main.dt.Rows.Add(oDetails.Doc_ID, oDetails.Doc_Code, sDocumentType, oDetails.Doc_Description);
                //}
                //dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }  
        #endregion     

        #region Fill Details
        private void FillDetails(string sid)
        {
            try
            {
                if (sid != null)
                {
                    ClearFields();
                    SEACC_Form.IsUpdateMode = true;

                    tbl_ttsTenderDocumentMaster oTDMaster = tbl_ttsTenderDocumentMaster.Select(sid);
                    if (oTDMaster != null)
                    {
                        
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        } 
        #endregion

        #region Grid Event
        private void dgr_Main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object oItem = dgr_Main.grdMain.SelectedItem;
                if (oItem != null)
                {
                    string id = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(oItem) as TextBlock).Text;
                    FillDetails(id);
                }
            }
            catch (Exception ex)
            {

                SEACCExeption.Show(ex);
            }
        } 
        #endregion

        #region Search
        private void txtSupplier_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch DataRowSearch = new Search_Forms.frmSearch();
            List<string> lstResult = DataRowSearch.Show(Search.CustomerList);
            if (DataRowSearch.DialogResult == true)
            {
                txtSupplier.Tag = lstResult[0];
                txtSupplier.Text = lstResult[1];
            }
        }

        private void txtGRNNo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Search_Forms.frmSearch DataRowSearch = new Search_Forms.frmSearch();
            //List<string> lstResult = DataRowSearch.Show(Search.G);
            //if (DataRowSearch.DialogResult == true)
            //{
            //    txtSupplier.Tag = lstResult[0];
            //    txtSupplier.Text = lstResult[1];
            //}
        }

        private void txtItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch DataRowSearch = new Search_Forms.frmSearch();
            List<string> lstResult = DataRowSearch.Show(Search.ItemMaster);
            if (DataRowSearch.DialogResult == true)
            {
                txtItem.Tag = lstResult[0];
                txtItem.Text = lstResult[1];
            }
        }

        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyFields())
            {
                bStatus = true;
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyFields()
        {
            string strMessage = "";
            bool bStatus = true;

            //if (!clsValidation.Validate_EmptyValue(cmbDocType))
            //    bStatus = false;
            //else if (!clsValidation.Validate_EmptyValue(txtDocCode, ref strMessage))
            //    bStatus = false;

            //if (bStatus == false)
            //    SEACCMessageBox.Show("Fields cannot be Empty", strMessage, MessageBoxButton.OK);

            return bStatus;
        } 
        #endregion

    }
}