using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_PHARMA.Search;
using SEACC_WPFControls;
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

namespace SEACC_PRODUCTION_PHARMA
{

    public partial class UC_JobType : UserControl
    {
        #region Form Load
        public UC_JobType()
        {
            #region Form Initialize
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.ProdPharma_JobTypes;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("TypeID");
            dgr_Main.dt.Columns.Add("TypeName");
            dgr_Main.dt.Columns.Add("Prefix");
            dgr_Main.dt.Columns.Add("Remarks");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false, false, false);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Type ID", "TypeID", 75, false);
            dgr_Main.Add_DatagridColoumn("Prefix", "Prefix", 75);
            dgr_Main.Add_DatagridColoumn("Description", "TypeName", 150);
            dgr_Main.Add_DatagridColoumn("Remarks", "Remarks", 300);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(670);
        }
        #endregion

        #region Action Button
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                string sJobTypeID = "";
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_zItemTag4 oJobType = tbl_zItemTag4.Select(txtTypeID.Tag.ToString());
                            if (oJobType != null)
                            {
                                tbl_zItemTag4 oOldType = new tbl_zItemTag4(txtTypeID.Text, txtTypeName.Text, txtRemark.Text, txtPrefix.Text, txtShortPrefix.Text,  oJobType.IsDeleted);
                                oOldType.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                                sJobTypeID = oOldType.Tag4_ID;
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            tbl_zItemTag4 oNewType = new tbl_zItemTag4(txtTypeID.Text, txtTypeName.Text, txtRemark.Text, txtPrefix.Text, txtShortPrefix.Text,  false);
                            oNewType.Insert();
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                            sJobTypeID = oNewType.Tag4_ID;
                        }
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
                    FillDetails(sJobTypeID);
                }
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtTypeID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtTypeName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPrefix, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtShortPrefix, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark, true, false, true);

            txtTypeID.Tag = null;

            txtTypeID.Text = "";
            txtTypeName.Text = "";
            txtPrefix.Text = "";
            txtShortPrefix.Text = "";
            txtRemark.Text = "";

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtTypeID.setReadOnlyStatus(true);
                txtTypeID.Text = "<Auto Generate>";
            }
            else
                txtTypeID.setReadOnlyStatus(false);
            #endregion
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_zItemTag4 oType in tbl_zItemTag4.SelectAll().Where(p => p.Tag4_ID != "default" && !p.IsDeleted))
                {
                    dgr_Main.dt.Rows.Add(oType.Tag4_ID, oType.Description, oType.Prefix, oType.Remark);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        } 
        #endregion

        #region Check validity

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

            if (!clsValidation.Validate_EmptyValue(txtTypeID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtTypeName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtPrefix))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtTypeID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtTypeID.Text = txtTypeID.Tag.ToString();
                }

                tbl_zItemTag4 oType = tbl_zItemTag4.Select(txtTypeID.Text);
                if (oType != null)
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
            foreach (tbl_zItemTag4 detail1 in tbl_zItemTag4.SelectAll().Where(p => p.Description == txtTypeName.Text && p.Tag4_ID != txtTypeID.Text))
            {
                bStatus = false;
                SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
                break;
            }
            return bStatus;
        }

        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                tbl_zItemTag4 oJobType = tbl_zItemTag4.Select(sID);
                if (oJobType != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtTypeID.Tag = oJobType.Tag4_ID;

                    txtTypeID.Text = oJobType.Tag4_ID;
                    txtTypeName.Text = oJobType.Description;
                    txtPrefix.Text = oJobType.Prefix;
                    txtShortPrefix.Text = oJobType.Prefrix2;
                    txtRemark.Text = oJobType.Remark;
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        #endregion

        #region Grid Events
        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    FillDetails(GridID);
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region Search Events
        private void txtTypeID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.ProdPharma_JobTypes);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                FillDetails(lstResult[0]);
            }
        }
        #endregion

        #region Key Press Events
        private void SEACC_Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
        }
        #endregion

    }
}
