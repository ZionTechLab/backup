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
    /// Interaction logic for UC_Religion.xaml
    /// </summary>
    public partial class UC_Religion : UserControl
    {
        #region Form Load
        public UC_Religion()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Religion_Creation;
            SEACC_Form.Initialize(); 
            #endregion

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("ReligionCode");
            dgr_Main.dt.Columns.Add("ReligionName"); 
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click; 
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("Code", "ReligionCode", 60,false);
            dgr_Main.Add_DatagridColoumn("Religion", "ReligionName", 450); 
            #endregion

            ClearFiled();
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
            ClearFiled();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtReligionCode.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);

                        if (bMessegeBoxResult)
                        {
                            tbl_genMasReligion oShiftMaster = tbl_genMasReligion.Select(txtReligionCode.Text.Trim());
                            if (oShiftMaster != null)
                            {
                                oShiftMaster.IsCanceled = true;
                                oShiftMaster.UserID_Canceled = clsSecurity.UserIDLoged;
                                oShiftMaster.Date_Canceled = clsSecurity.getServerDateTime();
                                oShiftMaster.TerminalID_Canceled = clsSecurity.TerminalID;
                                oShiftMaster.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                ClearFiled();
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
            finally
            {
                ClearFiled();
                RefreshGrid();
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
                            tbl_genMasReligion OldRecord = tbl_genMasReligion.Select(txtReligionCode.Text);
                            if (OldRecord != null)
                            {
                                tbl_genMasReligion oReligion = new tbl_genMasReligion(txtReligionCode.Text, txtReligionName.Text, false, OldRecord.UserID_Created, clsSecurity.UserIDLoged, OldRecord.UserID_Canceled, OldRecord.TerminalID_Created, clsSecurity.TerminalID, OldRecord.TerminalID_Canceled, OldRecord.Date_Created, clsSecurity.getServerDateTime(), OldRecord.Date_Canceled);
                                oReligion.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtReligionCode.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_genMasReligion InsertData = new tbl_genMasReligion(txtReligionCode.Text, txtReligionName.Text, false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                        InsertData.Insert();
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
                    ClearFiled();
                    RefreshGrid();
                }
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFiled()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtReligionCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtReligionName, true, false, false);

            txtReligionCode.Text = "";
            txtReligionCode.Tag = null;
            txtReligionName.Text = "";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtReligionCode.setReadOnlyStatus(true);
                txtReligionCode.Text = "<Auto Generate>";
            }
            else
                txtReligionCode.setReadOnlyStatus(false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_genMasReligion oReligions in tbl_genMasReligion.SelectAll().Where(p => p.Religion_ID != "default" && p.IsCanceled == false))
                {
                    dgr_Main.dt.Rows.Add(oReligions.Religion_ID, oReligions.Religion);
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

            if (!clsValidation.Validate_EmptyValue(txtReligionCode))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtReligionName))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_genMasReligion oDetail = tbl_genMasReligion.Select(txtReligionCode.Text);
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
            foreach (tbl_genMasReligion detail1 in tbl_genMasReligion.SelectAll().Where(p => p.Religion == txtReligionName.Text && p.IsCanceled == false && p.Religion_ID != txtReligionCode.Text))
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

        #region Fill Details
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_genMasReligion oReligion = tbl_genMasReligion.Select(sID);
                    if (oReligion != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtReligionCode.IsEnabled = false;
                        txtReligionCode.Text = oReligion.Religion_ID;
                        txtReligionCode.Tag = oReligion.Religion_ID;
                        txtReligionName.Text = oReligion.Religion;
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
        private void txtReligionCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void txtReligionName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Religions);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFiled();
                txtReligionCode.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }
        #endregion


    }
}
