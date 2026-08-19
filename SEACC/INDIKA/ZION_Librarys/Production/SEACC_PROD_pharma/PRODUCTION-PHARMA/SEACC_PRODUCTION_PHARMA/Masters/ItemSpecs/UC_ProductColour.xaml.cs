using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SEACC_PRODUCTION_PHARMA
{
    /// <summary>
    /// Developed by Gayan
    /// 2017-05-22
    /// </summary>
    public partial class UC_ProductColour : UserControl
    {
        #region Form Load
        public UC_ProductColour()
        {
            #region Usercontrol Initialize
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.ProdPharma_ProductColours;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("ColourID");
            dgr_Main.dt.Columns.Add("ColourName");
            dgr_Main.dt.Columns.Add("Prefix");
            dgr_Main.dt.Columns.Add("Remark");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false, false, false);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Colour ID", "ColourID", 75, false);
            dgr_Main.Add_DatagridColoumn("Prefix", "Prefix", 75);
            dgr_Main.Add_DatagridColoumn("Colour Description", "ColourName", 150);
            dgr_Main.Add_DatagridColoumn("Remark", "Remark", 350);
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

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (SEACC_Form.CheckPermission_ToCancel())
                    {
                        if (txtColourID.Tag != null)
                        {
                            bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                            if (bMessegeBoxResult)
                            {
                                tbl_zColour oOldType = tbl_zColour.Select(txtColourID.Tag.ToString());
                                if (oOldType != null)
                                {
                                    //oOldType.IsDeleted = true;
                                    //oOldType.Update();

                                    //SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                    //ClearFields();
                                    //RefreshGrid();
                                }
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

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermission_ToSave(true))
                        {
                            tbl_zColour oOldColour = tbl_zColour.Select(txtColourID.Tag.ToString());
                            if (oOldColour != null)
                            {
                                tbl_zColour oColour = new tbl_zColour(txtColourID.Tag.ToString(), txtColourName.Text, txtPrefix.Text, txtShortPrefix.Text, txtRGB_Code.Text, txtCMYK_Code.Text, txtPMS_Code.Text, txtRemark.Text);
                                oColour.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.CheckPermission_ToSave(false))
                        {
                            tbl_zColour oNewColour = new tbl_zColour(txtColourID.Tag.ToString(), txtColourName.Text, txtPrefix.Text, txtShortPrefix.Text, txtRGB_Code.Text, txtCMYK_Code.Text, txtPMS_Code.Text, txtRemark.Text);
                            oNewColour.Insert();
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
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
                }
            }
        }
        #endregion

        #region Clearfield
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtColourID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtColourName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPrefix, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtShortPrefix, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRGB_Code, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCMYK_Code, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPMS_Code, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark, true, false, true);

            txtColourID.Tag = null;

            txtColourID.Text = "";
            txtColourName.Text = "";
            txtPrefix.Text = "";
            txtShortPrefix.Text = "";
            txtRGB_Code.Text = "";
            txtCMYK_Code.Text = "";
            txtPMS_Code.Text = "";
            txtRemark.Text = "";

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtColourID.setReadOnlyStatus(true);
                txtColourID.Text = "<Auto Generate>";
            }
            else
                txtColourID.setReadOnlyStatus(false);
            #endregion
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_zColour oType in tbl_zColour.SelectAll().Where(p => p.Colour_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(oType.Colour_ID, oType.ColourName, oType.Prefrix, oType.Remark);
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

            if (!clsValidation.Validate_EmptyValue(txtColourID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtColourName))
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
                    txtColourID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtColourID.Text = txtColourID.Tag.ToString();
                }

                tbl_zColour oColour = tbl_zColour.Select(txtColourID.Text);
                if (oColour != null)
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
            foreach (tbl_zColour detail1 in tbl_zColour.SelectAll().Where(p => p.ColourName == txtColourName.Text && p.Colour_ID != txtColourID.Text))
            {
                bStatus = false;
                SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
                break;
            }
            return bStatus;
        }

        #endregion

        #region Fill Details
        private void fillDetails(string sID)
        {
            try
            {
                tbl_zColour oColour = tbl_zColour.Select(sID);
                if (oColour != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtColourID.Tag = oColour.Colour_ID;

                    txtColourID.Text = oColour.Colour_ID;
                    txtColourName.Text = oColour.ColourName;
                    txtPrefix.Text = oColour.Prefrix;
                    txtShortPrefix.Text = oColour.Prefrix2;
                    txtRGB_Code.Text = oColour.RgbCode;
                    txtCMYK_Code.Text = oColour.CmykCode;
                    txtPMS_Code.Text = oColour.PmsCode;
                    txtRemark.Text = oColour.Remark;
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
                    fillDetails(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Events
        private void txtColourID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion

        #region Key Press Event
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
