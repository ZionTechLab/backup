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
using System.Data;
using Digiteq_Logic;
using SEACC_WPFControls;
using DataTire;

namespace Digiteq.User_Contrals
{
    /// <summary>
    /// Interaction logic for UC_Customization.xaml
    /// </summary>
    public partial class UC_Customization : UserControl
    {
        #region Form Load
        public UC_Customization()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Canteen;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("ValueId");
            dgr_Main.dt.Columns.Add("ValueName");
            dgr_Main.dt.Columns.Add("ConfigValue");
            dgr_Main.dt.Columns.Add("ConfigTypeValue_Id");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("#", "ValueId", 40);
            dgr_Main.Add_DatagridColoumn("Value Name", "ValueName", 340);
            dgr_Main.Add_DatagridColoumn("Config Value", "ConfigValue", 140);
            dgr_Main.Add_DatagridColoumn("Config Type Value Id", "ConfigTypeValue_Id", 130); 
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(410);
            else
                coloumnA.Width = new GridLength(690);
        }
        #endregion

        #region Action Buttons
        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
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
                            tbl_securityConfigValue oldRecord = tbl_securityConfigValue.Select(int.Parse(txtValueID.Text.Trim()));
                            if (oldRecord != null)
                            {
                                tbl_securityConfigValue detail = new tbl_securityConfigValue(int.Parse(txtValueID.Text.Trim()), txtValueName.Text, txtConfigValue.Text, "default" );
                                detail.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert Data
                    else
                    {
                        tbl_securityConfigValue detail = new tbl_securityConfigValue(int.Parse(txtValueID.Text.Trim()), txtValueName.Text, txtConfigValue.Text, txtConfigTypeValueId.Text);
                        detail.Insert();
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

            cls_Formater.SetEnableDisable_LableTextbox(txtValueID, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtValueName, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtConfigValue, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtConfigTypeValueId, true, false, false);

            txtValueID.Tag = null;

            txtValueID.Text = "";
            txtValueName.Text = "";
            txtConfigValue.Text = "";
            txtConfigTypeValueId.Text = "";
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                foreach (tbl_securityConfigValue detail in tbl_securityConfigValue.SelectAll())
                {
                    dgr_Main.dt.Rows.Add(detail.ValueID, detail.ValueName, detail.ConfigValue, detail.ConfigTypeValue_ID);
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
                    bStatus = true;
                if (!ChekValidity_DuplicateNames())
                    bStatus = false;
            }
            return bStatus;
        }
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!SEACC_Form.IsUpdateMode)
            {
                if (!clsValidation.Validate_EmptyValue(txtValueID))
                    bStatus = false;
                if (!clsValidation.Validate_EmptyValue(txtValueName))
                    bStatus = false;
                if (!clsValidation.Validate_EmptyValue(txtConfigValue))
                    bStatus = false;
                if (!clsValidation.Validate_EmptyValue(txtConfigTypeValueId))
                    bStatus = false;
            }

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_securityConfigValue detail = tbl_securityConfigValue.Select(Int32.Parse(txtValueID.Text));
                if (detail != null)
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
            foreach (tbl_securityConfigValue detail1 in tbl_securityConfigValue.SelectAll().Where(p => p.ValueName == txtValueName.Text && p.ValueID != int.Parse(txtValueID.Text)))
            {
                if (detail1 != null)
                {
                    SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist);
                    bStatus = false;
                    break;
                }
            }
            return bStatus;
        }

        #endregion

        #region Fill Details
        private void fillDetails(int sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_securityConfigValue detail = tbl_securityConfigValue.Select(sID);
                    if (detail != null)
                    {
                        txtValueID.IsEnabled = false;
                        SEACC_Form.IsUpdateMode = true;
                        txtValueID.Text = detail.ValueID.ToString();
                        txtValueName.Text = detail.ValueName;
                        txtConfigValue.Text = detail.ConfigValue;
                        txtConfigTypeValueId.IsEnabled = false;
                        txtConfigTypeValueId.Text = detail.ConfigTypeValue_ID;
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
        private void dgr_Main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails(int.Parse(GridID));
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Search Event
        private void txtValueID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Configuration);
            if (RowDataSearch.DialogResult == true)
            {
                txtValueID.Text = lstResult[0];
                fillDetails(int.Parse(lstResult[0]));
            }
        }
        #endregion
    }
}
