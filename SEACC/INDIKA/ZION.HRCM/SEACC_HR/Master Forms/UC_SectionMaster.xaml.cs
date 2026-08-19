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
using SEACC_WPFControls;
using System.Data;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_SectionMaster.xaml
    /// </summary>
    public partial class UC_SectionMaster : UserControl
    {
        #region Form Load
        public UC_SectionMaster()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Section_Creation;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("SectionCode");
            dgr_Main.dt.Columns.Add("SectioNname");
            dgr_Main.dt.Columns.Add("Head");
            dgr_Main.dt.Columns.Add("Remarks"); 
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click; 
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Sect. Code", "SectionCode", 75);
            dgr_Main.Add_DatagridColoumn("Name", "SectioNname", 150);
            dgr_Main.Add_DatagridColoumn("HOS", "Head", 120);
            dgr_Main.Add_DatagridColoumn("Remarks", "Remarks", 200); 
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(470);
        }
        #endregion

        #region Action Button
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            RefreshGrid();
            ClearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtSectionCode.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_genMasSection oShiftMaster = tbl_genMasSection.Select(txtSectionCode.Text.Trim(),clsSecurity.CompanyID,clsSecurity.BranchID);
                            if (oShiftMaster != null)
                            {
                                oShiftMaster.IsCanceled = true;
                                oShiftMaster.Date_Canceled = clsSecurity.getServerDateTime();
                                oShiftMaster.UserID_Canceled = clsSecurity.UserIDLoged;
                                oShiftMaster.TerminalID_Canceled = clsSecurity.TerminalID;
                                oShiftMaster.Update();
                                SEACCMessageBox.Show("Delete Successful", "", MessageBoxButton.OK);
                                ClearFields();
                                RefreshGrid();
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_genMasSection Oldrecord = tbl_genMasSection.Select(txtSectionCode.Text.Trim(), clsSecurity.CompanyID, clsSecurity.BranchID);
                            if (Oldrecord != null)
                            {
                                tbl_genMasSection oSectionMaster = new tbl_genMasSection(clsSecurity.CompanyID, clsSecurity.BranchID, txtSectionCode.Text, txtDescription.Text, txtHeadOfSection.Tag.ToString(), txtRemarks.Text, Oldrecord.IsCanceled, Oldrecord.UserID_Created, clsSecurity.UserIDLoged, Oldrecord.UserID_Canceled, Oldrecord.TerminalID_Created, clsSecurity.TerminalID, Oldrecord.TerminalID_Canceled, Oldrecord.Date_Created, clsSecurity.getServerDateTime(), Oldrecord.Date_Canceled);
                                oSectionMaster.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    } 
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtSectionCode.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_genMasSection oSection = new tbl_genMasSection(clsSecurity.CompanyID, clsSecurity.BranchID, txtSectionCode.Text, txtDescription.Text, txtHeadOfSection.Tag.ToString(), txtRemarks.Text, false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                        oSection.Insert();
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
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSectionCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDescription, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtHeadOfSection, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, false);

            txtDescription.Text = "";
            txtSectionCode.Tag = null;
            txtSectionCode.Text = "";
            txtHeadOfSection.Text = "";
            txtHeadOfSection.Tag = "default";
            txtRemarks.Text = "";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtSectionCode.setReadOnlyStatus(true);
                txtSectionCode.Text = "<Auto Generate>";
            }
            else
                txtSectionCode.setReadOnlyStatus(false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_genMasSection oSection in tbl_genMasSection.SelectAll().Where(p => p.IsCanceled == false && p.SectionID != "default"))
                {
                    dgr_Main.dt.Rows.Add(oSection.SectionID, oSection.Section_Name, clsRef_Name.get_EmployeeName(oSection.Employee_ID_HOS) == "default" ? "" : clsRef_Name.get_EmployeeName(oSection.Employee_ID_HOS), oSection.Remarks);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateFiled())
                    bStatus = true;
            }

            if (!ChekValidity_DuplicateNames())
                bStatus = false;
            return bStatus;
        }
        
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtSectionCode))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtDescription))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_genMasSection oDetail = tbl_genMasSection.Select(txtSectionCode.Text.Trim(), clsSecurity.CompanyID, clsSecurity.BranchID);
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        public bool ChekValidity_DuplicateNames()
        {
            bool bStatus = true;
            foreach (tbl_genMasSection detail1 in tbl_genMasSection.SelectAll().Where(p => p.Section_Name == txtDescription.Text && p.IsCanceled == false && p.SectionID != txtSectionCode.Text))
            {
                if (detail1 != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
                    break;
                }
            }
            return bStatus;
        }
        #endregion

        #region FillDetails
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_genMasSection oSection = tbl_genMasSection.Select(sID, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oSection != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtSectionCode.IsEnabled = false;
                        txtSectionCode.Text = oSection.SectionID;
                        txtSectionCode.Tag = oSection.SectionID;
                        txtDescription.Text = oSection.Section_Name;
                        if (oSection.Employee_ID_HOS != "default")
                        {
                            txtHeadOfSection.Text = oSection.Employee_ID_HOS + "-" + clsRef_Name.get_EmployeeName(oSection.Employee_ID_HOS);
                            txtHeadOfSection.Tag = oSection.Employee_ID_HOS;
                        }
                        txtRemarks.Text = oSection.Remarks;
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Grid Event
        private void ddd_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
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

        #region Search Event
        private void txtHeadOfSection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                string a = lstResult[0];
                txtHeadOfSection.Tag = lstResult[0];
                txtHeadOfSection.Text = lstResult[0] + "-" + lstResult[2];
            }
        }

        private void txtSectionCode_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Sections);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtSectionCode.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }
        #endregion
    }
}
