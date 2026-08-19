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
using Digiteq_Logic;
using DataTire;
using SEACC_WPFControls;
using System.Data;



namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_SubSectionMaster.xaml
    /// </summary>
    public partial class UC_SubSectionMaster : UserControl
    {
        #region Form Load
        public UC_SubSectionMaster()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Sub_Section_Creation;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("SubSection");
            dgr_Main.dt.Columns.Add("Section");
            dgr_Main.dt.Columns.Add("Description");
            dgr_Main.dt.Columns.Add("HOSS");
            dgr_Main.dt.Columns.Add("Remarks");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click; 
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Sub sect. Code", "SubSection", 90);
            dgr_Main.Add_DatagridColoumn("Sect. Code", "Section", 85);
            dgr_Main.Add_DatagridColoumn("Name", "Description", 200);
            dgr_Main.Add_DatagridColoumn("HOSS", "HOSS", 150);
            dgr_Main.Add_DatagridColoumn("Remarks", "Remarks", 150); 
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
            ClearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtSubSectioncode.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_genMasSubSection oSubSection = tbl_genMasSubSection.Select(txtSectionCode.Tag.ToString(), txtSubSectioncode.Text, clsSecurity.CompanyID, clsSecurity.BranchID);
                            if (oSubSection != null)
                            {
                                oSubSection.IsCanceled = true;
                                oSubSection.UserID_Canceled = clsSecurity.UserIDLoged;
                                oSubSection.Date_Canceled = clsSecurity.getServerDateTime();
                                oSubSection.TerminalID_Canceled = clsSecurity.TerminalID;
                                oSubSection.Update();

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
                            tbl_genMasSubSection OldRecord = tbl_genMasSubSection.Select(txtSectionCode.Tag.ToString(), txtSubSectioncode.Text, clsSecurity.CompanyID, clsSecurity.BranchID);
                            if (OldRecord != null)
                            {
                                tbl_genMasSubSection OSubsectionMaster = new tbl_genMasSubSection(clsSecurity.CompanyID, clsSecurity.BranchID, txtSectionCode.Tag.ToString(), txtSubSectioncode.Text, txtDescription.Text, txtHOS.Tag.ToString(), txtRemarks.Text, OldRecord.IsCanceled, OldRecord.UserID_Created, clsSecurity.UserIDLoged, OldRecord.UserID_Canceled, OldRecord.TerminalID_Created, clsSecurity.TerminalID, OldRecord.TerminalID_Canceled, OldRecord.Date_Created, clsSecurity.getServerDateTime(), OldRecord.Date_Canceled);
                                OSubsectionMaster.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtSubSectioncode.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_genMasSubSection OSubSection = new tbl_genMasSubSection(clsSecurity.CompanyID, clsSecurity.BranchID, txtSectionCode.Tag.ToString(), txtSubSectioncode.Text, txtDescription.Text, txtHOS.Tag.ToString(), txtRemarks.Text, false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                        OSubSection.Insert();
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
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSubSectioncode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDescription, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtHOS, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, false);

            txtSectionCode.Text = "";
            txtSectionCode.Tag = null;
            txtSubSectioncode.Text = "";
            txtSectionCode.Tag = null;
            txtDescription.Text = "";
            txtHOS.Text = "";
            txtHOS.Tag = "default";
            txtRemarks.Text = "";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtSubSectioncode.setReadOnlyStatus(true);
                txtSubSectioncode.Text = "<Auto Generate>";
            }
            else
                txtSubSectioncode.setReadOnlyStatus(false);
        }
        #endregion

        #region RefreshGrid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_genMasSubSection oSubSection in tbl_genMasSubSection.SelectAll().Where(p => p.IsCanceled == false && p.SectionID != "Default" && p.SubSectionID != "Default"))
                {
                    dgr_Main.dt.Rows.Add(oSubSection.SubSectionID, oSubSection.SectionID, oSubSection.SubSectionName, clsRef_Name.get_EmployeeName(oSubSection.Employee_ID_HOSS) == "default" ? "" : clsRef_Name.get_EmployeeName(oSubSection.Employee_ID_HOSS), oSubSection.Remarks);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region CheckValidity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateFiled())
                {
                    if (ChekValidity_DuplicateNames())
                        bStatus = true;
                }
            }
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
                tbl_genMasSubSection oDetail = tbl_genMasSubSection.Select(txtSectionCode.Text, txtSubSectioncode.Text, clsSecurity.CompanyID, clsSecurity.BranchID);
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
            foreach (tbl_genMasSubSection detail1 in tbl_genMasSubSection.SelectAll().Where(p => p.SubSectionName == txtDescription.Text && p.IsCanceled == false && (p.SectionID != txtSectionCode.Text && p.SubSectionID != txtSubSectioncode.Text)))
            {
                bStatus = false;
                SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist, "Sub Section");
                break;
            }
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void fillDetails(string sID, string sID1)
        {
            try
            {
                if (sID != null && sID1 != null)
                {
                    tbl_genMasSubSection oSubSection = tbl_genMasSubSection.Select(sID, sID1, clsSecurity.CompanyID, clsSecurity.BranchID);
                    if (oSubSection != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        tbl_genMasSection detail = tbl_genMasSection.Select(oSubSection.SectionID.Trim(), clsSecurity.CompanyID, clsSecurity.BranchID);
                        if (detail != null)
                         txtSectionCode.Text = oSubSection.SectionID + "-" + detail.Section_Name;
                        txtSectionCode.Tag = oSubSection.SectionID;
                        txtSubSectioncode.IsEnabled = false;
                        txtSubSectioncode.Tag = oSubSection.SubSectionID;
                        txtSubSectioncode.Text = oSubSection.SubSectionID;
                        txtDescription.Text = oSubSection.SubSectionName;
                        if (oSubSection != null)
                            txtHOS.Text = oSubSection.Employee_ID_HOSS + "-" + clsRef_Name.get_EmployeeName(oSubSection.Employee_ID_HOSS);
                        txtHOS.Tag = oSubSection.Employee_ID_HOSS;
                        txtRemarks.Text = oSubSection.Remarks;
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
        private void grd_SubSection_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    string GridID1 = (dgr_Main.grdMain.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails(GridID1, GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Event
        private void txtSubSectioncode_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.SubSections);
            if (RowDataSearch.DialogResult == true)
            {
                txtSubSectioncode.Text = lstResult[0];
                txtSubSectioncode.Tag = lstResult[0];
                fillDetails(lstResult[2], lstResult[0]);

            }
        }

        private void txtSectionCode_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Sections);
            if (RowDataSearch.DialogResult == true)
            {
                txtSectionCode.Text = lstResult[0] + "-" + lstResult[1];
                txtSectionCode.Tag = lstResult[0];
            }
        }

        private void txtHOS_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                txtHOS.Text = lstResult[0] + "-" + lstResult[2];
                txtHOS.Tag = lstResult[0];
            }
        }
        #endregion 
    }
}
