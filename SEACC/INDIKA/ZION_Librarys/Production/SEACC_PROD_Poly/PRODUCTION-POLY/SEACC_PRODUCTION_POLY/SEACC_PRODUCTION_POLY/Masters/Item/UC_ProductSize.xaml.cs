using DataTire;
using Digiteq_Logic;
using SEACC_PRODUCTION_POLY.Search;
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
using System.Windows.Shapes;
using System.Globalization;

namespace SEACC_PRODUCTION_POLY.Masters
{
    /// <summary>
    /// Interaction logic for UC_ProductSize.xaml
    /// </summary>
    public partial class UC_ProductSize : UserControl
    {
        #region Form Load
        public UC_ProductSize()
        {
            #region Initialize Usercontrol
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_ProductSizes;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("SizeID");
            dgr_Main.dt.Columns.Add("SizeName");
            dgr_Main.dt.Columns.Add("Prefix");
            dgr_Main.dt.Columns.Add("Remark");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false, false, false);
            SEACC_Form.btn_New.Click += btn_New_Click;
            SEACC_Form.btn_Save.Click += btn_Save_Click;
            //this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Size ID", "SizeID", 75, false);
            dgr_Main.Add_DatagridColoumn("Prefix", "Prefix", 200);
            dgr_Main.Add_DatagridColoumn("Description", "SizeName", 200);
            dgr_Main.Add_DatagridColoumn("Remark", "Remark", 300);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Action Buttons

        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
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
                            tbl_zItemTag3 oOldSize = tbl_zItemTag3.Select(txtSizeID.Tag.ToString());
                            if (oOldSize != null)
                            {
                                tbl_zItemTag3 oSize = new tbl_zItemTag3(txtSizeID.Tag.ToString(), txtSizeName.Text, txtRemark.Text, txtPrefix.Text, txtShortPrefix.Text,
                                    decimal.Parse(txtValueLength.Text), txtUoMLength.Tag != null ? txtUoMLength.Tag.ToString() : "default",
                                    decimal.Parse(txtValueWidth.Text), txtUoMWidth.Tag != null ? txtUoMWidth.Tag.ToString() : "default",
                                    decimal.Parse(txtValueHeight.Text), txtUoMHeight.Tag != null ? txtUoMHeight.Tag.ToString() : "default",
                                    decimal.Parse(txtValueDiameter.Text), txtUoMDiameter.Tag != null ? txtUoMDiameter.Tag.ToString() : "default",
                                    decimal.Parse(txtValueRadious.Text), txtUoMRadious.Tag != null ? txtUoMRadious.Tag.ToString() : "default",
                                    decimal.Parse(txtValueThickness.Text), txtUoMThickness.Tag != null ? txtUoMThickness.Tag.ToString() : "default",
                                    decimal.Parse(txtValueWeight.Text), txtUoMWeight.Tag != null ? txtUoMWeight.Tag.ToString() : "default",
                                    oOldSize.IsDeleted);
                                oSize.Update();
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
                            tbl_zItemTag3 oNewSize = new tbl_zItemTag3(txtSizeID.Tag.ToString(), txtSizeName.Text, txtRemark.Text, txtPrefix.Text, txtShortPrefix.Text,
                                    decimal.Parse(txtValueLength.Text), txtUoMLength.Tag != null ? txtUoMLength.Tag.ToString() : "default",
                                    decimal.Parse(txtValueWidth.Text), txtUoMWidth.Tag != null ? txtUoMWidth.Tag.ToString() : "default",
                                    decimal.Parse(txtValueHeight.Text), txtUoMHeight.Tag != null ? txtUoMHeight.Tag.ToString() : "default",
                                    decimal.Parse(txtValueDiameter.Text), txtUoMDiameter.Tag != null ? txtUoMDiameter.Tag.ToString() : "default",
                                    decimal.Parse(txtValueRadious.Text), txtUoMRadious.Tag != null ? txtUoMRadious.Tag.ToString() : "default",
                                    decimal.Parse(txtValueThickness.Text), txtUoMThickness.Tag != null ? txtUoMThickness.Tag.ToString() : "default",
                                    decimal.Parse(txtValueWeight.Text), txtUoMWeight.Tag != null ? txtUoMWeight.Tag.ToString() : "default",
                                    false);
                            oNewSize.Insert();
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

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtSizeID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPrefix, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtShortPrefix, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtSizeName, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtUoMWidth, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtUoMLength, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtUoMHeight, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtUoMDiameter, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtUoMRadious, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtUoMThickness, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtUoMWeight, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtUoMGusset, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtUoMArea, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtValueWidth, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtValueLength, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtValueHeight, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtValueDiameter, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtValueRadious, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtValueThickness, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtValueWeight, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtValueGusset, true, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtValueArea, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemark, true, false, true);

            txtSizeID.Tag = null;
            txtUoMLength.Tag = null;
            txtUoMWidth.Tag = null;
            txtUoMHeight.Tag = null;
            txtUoMDiameter.Tag = null;
            txtUoMRadious.Tag = null;
            txtUoMThickness.Tag = null;
            txtUoMWeight.Tag = null;
            txtUoMGusset.Tag = null;
            txtUoMArea.Tag = null;

            txtSizeID.Text = "";
            txtSizeName.Text = "";
            txtPrefix.Text = "";
            txtShortPrefix.Text = "";
            txtValueLength.Text = clsFormatter.FormatDecimalPlaces_Weight(0);
            txtValueWidth.Text = clsFormatter.FormatDecimalPlaces_Weight(0);
            txtValueHeight.Text = clsFormatter.FormatDecimalPlaces_Weight(0);
            txtValueDiameter.Text = clsFormatter.FormatDecimalPlaces_Weight(0);
            txtValueRadious.Text = clsFormatter.FormatDecimalPlaces_Weight(0);
            txtValueThickness.Text = clsFormatter.FormatDecimalPlaces_Weight(0);
            txtValueWeight.Text = clsFormatter.FormatDecimalPlaces_Weight(0);
            txtValueGusset.Text = clsFormatter.FormatDecimalPlaces_Weight(0);
            txtValueArea.Text = clsFormatter.FormatDecimalPlaces_Weight(0);
            txtUoMLength.Text = "";
            txtUoMWidth.Text = "";
            txtUoMHeight.Text = "";
            txtUoMDiameter.Text = "";
            txtUoMRadious.Text = "";
            txtUoMThickness.Text = "";
            txtUoMWeight.Text = "";
            txtUoMGusset.Text = "";
            txtUoMArea.Text = "";
            txtRemark.Text = "";

            rbLengthFirst.IsChecked = false;
            rbWidthFirst.IsChecked = true;

            #region Auto Generate
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtSizeID.setReadOnlyStatus(true);
                txtSizeID.Text = "<Auto Generate>";
            }
            else
                txtSizeID.setReadOnlyStatus(false);
            #endregion
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_zItemTag3 oSize in tbl_zItemTag3.SelectAll().Where(p => p.Tag3_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(oSize.Tag3_ID, oSize.Description, oSize.Prefix, oSize.Remark);
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

            if (!clsValidation.Validate_EmptyValue(txtSizeID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtSizeName))
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
                    txtSizeID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtSizeID.Text = txtSizeID.Tag.ToString();
                }

                tbl_zItemTag3 oRange = tbl_zItemTag3.Select(txtSizeID.Text);
                if (oRange != null)
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
            foreach (tbl_zItemTag3 oRange in tbl_zItemTag3.SelectAll().Where(p => p.Description == txtSizeName.Text && p.Tag3_ID != txtSizeID.Text))
            {
                bStatus = false;
                SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
                break;
            }
            return bStatus;
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

        #region Fill Details
        private void fillDetails(string sID)
        {
            try
            {
                tbl_zItemTag3 oSize = tbl_zItemTag3.Select(sID);
                if (oSize != null)
                {
                    SEACC_Form.IsUpdateMode = true;

                    txtSizeID.Tag = oSize.Tag3_ID;
                    txtUoMLength.Tag = oSize.Uom_ID_length;
                    txtUoMWidth.Tag = oSize.Uom_ID_width;
                    txtUoMHeight.Tag = oSize.Uom_ID_height;
                    txtUoMDiameter.Tag = oSize.Uom_ID_diameter;
                    txtUoMRadious.Tag = oSize.Uom_ID_radius;
                    txtUoMThickness.Tag = oSize.Uom_ID_thickness;
                    txtUoMWeight.Tag = oSize.Uom_ID_weight;

                    txtSizeID.Text = oSize.Tag3_ID;
                    txtSizeName.Text = oSize.Description;
                    txtShortPrefix.Text = oSize.Prefrix2;
                    txtValueLength.Text = clsFormatter.FormatDecimalPlaces_Weight(oSize.Length);
                    txtUoMLength.Text = clsGenaralName.getName_Uom(oSize.Uom_ID_length);
                    txtValueWidth.Text = clsFormatter.FormatDecimalPlaces_Weight(oSize.Width);
                    txtUoMWidth.Text = clsGenaralName.getName_Uom(oSize.Uom_ID_width);
                    txtValueHeight.Text = clsFormatter.FormatDecimalPlaces_Weight(oSize.Height);
                    txtUoMHeight.Text = clsGenaralName.getName_Uom(oSize.Uom_ID_height);
                    txtValueDiameter.Text = clsFormatter.FormatDecimalPlaces_Weight(oSize.Diameter);
                    txtUoMDiameter.Text = clsGenaralName.getName_Uom(oSize.Uom_ID_diameter);
                    txtValueRadious.Text = clsFormatter.FormatDecimalPlaces_Weight(oSize.Radius);
                    txtUoMRadious.Text = clsGenaralName.getName_Uom(oSize.Uom_ID_radius);
                    txtValueThickness.Text = clsFormatter.FormatDecimalPlaces_Weight(oSize.Thickness);
                    txtUoMThickness.Text = clsGenaralName.getName_Uom(oSize.Uom_ID_thickness);
                    txtValueWeight.Text = clsFormatter.FormatDecimalPlaces_Weight(oSize.Weight);
                    txtUoMWeight.Text = clsGenaralName.getName_Uom(oSize.Uom_ID_weight);
                    txtRemark.Text = oSize.Remark;
                    txtPrefix.Text = oSize.Prefix;

                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }

        #endregion

        #region Grid Event
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

        #region Search Event
        private void txtSizeID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.Prod_ProductSize);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                fillDetails(lstResult[0]);
            }
        }

        private void txtUoMLength_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UoM_search(txtUoMLength);
        }

        private void txtUoMWidth_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UoM_search(txtUoMWidth);
        }

        private void txtUoMHeight_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UoM_search(txtUoMHeight);
        }

        private void txtUoMDiameter_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UoM_search(txtUoMDiameter);
        }

        private void txtUoMRadious_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UoM_search(txtUoMRadious);
        }

        private void txtUoMThickness_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UoM_search(txtUoMThickness);
        }

        private void txtUoMWeight_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UoM_search(txtUoMWeight);
        }

        private void UoM_search(SEACC_TextBox txtUoM)
        {
            frm_search RowDataSearch = new frm_search();
            RowDataSearch.Top = SystemParameters.PrimaryScreenHeight / 4;
            RowDataSearch.Left = SystemParameters.PrimaryScreenWidth * 2 / 3;
            List<string> lstResult = RowDataSearch.Show(Digiteq_Logic.Search.UOM);
            if (RowDataSearch.DialogResult == true)
            {
                txtUoM.Tag = lstResult[0];
                txtUoM.Text = lstResult[1];
            }
        }

        #endregion

        #region Other Events
        private void txt_TextBox_TextChanged(object sender, EventArgs e)
        {
            decimal dLength, dWidth, dHeight, dDiameter, dRadious, dThickness, dWeight = 0;
            string sPrefix = "";

            dLength = clsValidation.Validate_DecimalNumber(txtValueLength.Text);
            dWidth = clsValidation.Validate_DecimalNumber(txtValueWidth.Text);
            dHeight = clsValidation.Validate_DecimalNumber(txtValueHeight.Text);
            dDiameter = clsValidation.Validate_DecimalNumber(txtValueDiameter.Text);
            dRadious = clsValidation.Validate_DecimalNumber(txtValueRadious.Text);
            dThickness = clsValidation.Validate_DecimalNumber(txtValueThickness.Text);
            dWeight = clsValidation.Validate_DecimalNumber(txtValueWeight.Text);

            if (rbWidthFirst.IsChecked.Value)
            {
                if (dWidth != 0)
                    sPrefix = txtValueWidth.Text + txtUoMWidth.Text;

                if (dLength != 0)
                    sPrefix += (sPrefix != "" ? " X " : "") + txtValueLength.Text + txtUoMLength.Text;
            }

            if (rbLengthFirst.IsChecked.Value)
            {
                if (dLength != 0)
                    sPrefix = txtValueLength.Text + txtUoMLength.Text;

                if (dWidth != 0)
                    sPrefix += (sPrefix != "" ? " X " : "") + txtValueWidth.Text + txtUoMWidth.Text;
            }

            if (dHeight != 0)
                sPrefix += (sPrefix != "" ? " X " : "") + txtValueHeight.Text + txtUoMHeight.Text;

            if (dDiameter != 0)
                sPrefix += (sPrefix != "" ? " X " : "") + txtValueDiameter.Text + txtUoMDiameter.Text;

            if (dRadious != 0)
                sPrefix += (sPrefix != "" ? " X " : "") + txtValueRadious.Text + txtUoMRadious.Text;

            if (dThickness != 0)
                sPrefix += (sPrefix != "" ? " X " : "") + txtValueThickness.Text + txtUoMThickness.Text;

            if (dWeight != 0)
                sPrefix += (sPrefix != "" ? " X " : "") + txtValueWeight.Text + txtUoMWeight.Text;

            txtPrefix.Text = sPrefix;
        }
        #endregion

        private void txt_LostFocus(object sender, RoutedEventArgs e)
        {
            txt_TextBox_TextChanged(sender, e);
        }

        private void rbWidthFirst_Checked(object sender, RoutedEventArgs e)
        {
            txt_TextBox_TextChanged(sender, e);
        }

        private void rbLengthFirst_Checked(object sender, RoutedEventArgs e)
        {
            txt_TextBox_TextChanged(sender, e);
        }

        private void SEACC_Form_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                btn_New_Click(sender, e);
            }
        }
    }


}
