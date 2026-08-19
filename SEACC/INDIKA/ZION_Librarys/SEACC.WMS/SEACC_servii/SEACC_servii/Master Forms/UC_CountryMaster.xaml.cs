using DataTire;
using Digiteq_Logic;
using SEACC_servii.Search_Forms;
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

namespace SEACC_servii.Master_Forms
{
    /// <summary>
    /// Interaction logic for UC_CountryMaster.xaml
    /// </summary>
    public partial class UC_CountryMaster : UserControl
    {
        #region Form Load
        public UC_CountryMaster()
        {
            InitializeComponent();


            SEACC_Form.enmFormName = FormName.CountryMaster;
            SEACC_Form.Initialize();


            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("CountryId");
            dgr_Main.dt.Columns.Add("CountryName");
            dgr_Main.dt.Columns.Add("CountryCode");
            #endregion

            #region Initialized Action Button
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid
            dgr_Main.Add_DatagridColoumn("ID", "CountryId", 70);
            dgr_Main.Add_DatagridColoumn("Name", "CountryName", 150);
            dgr_Main.Add_DatagridColoumn("Code", "CountryCode", 150);
            #endregion

            ClearFileds();
            RefreshGrid();

        } 
        #endregion

        #region Clear Fields
        private void ClearFileds()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtCountryID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCountryName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCountryCode, true, false, false);

            txtCountryID.Text = "";
            txtCountryName.Text = "";
            txtCountryCode.Text = "";

            txtCountryID.Tag = null;

            #region Set Auto Genarate Key fields
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtCountryID.setReadOnlyStatus(true);
                txtCountryID.Text = "<Auto Generate>";
            }
            else
                txtCountryID.setReadOnlyStatus(false);
            #endregion
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_genMasCountry detail in tbl_genMasCountry.SelectAll().Where(p => p.IsCanceled == false && p.Country_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(detail.Country_ID, detail.CountryName, detail.Country_Code_ISO);
                }

                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Action Button
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFileds();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtCountryID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_genMasCountry detail = tbl_genMasCountry.Select(txtCountryID.Text.Trim());
                            if (detail != null)
                            {
                                detail.IsCanceled = true;
                                detail.UserID_Canceled = clsSecurity.UserIDLoged;
                                detail.Date_Canceled = clsSecurity.getServerDateTime();
                                detail.TerminalID_Canceled = clsSecurity.TerminalID;
                                detail.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                ClearFileds();
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
                            tbl_genMasCountry oldRecord = tbl_genMasCountry.Select(txtCountryID.Text.Trim());
                            if (oldRecord != null)
                            {
                                tbl_genMasCountry detail = new tbl_genMasCountry(txtCountryID.Text.Trim(),txtCountryName.Text, txtCountryCode.Text, oldRecord.Country_Code_UN, oldRecord.DialingCode,oldRecord.Status,oldRecord.IsDefaultcountry,oldRecord.PfReg_1,oldRecord.PfReg_2,oldRecord.PfReg_3,oldRecord.PfReg_4,oldRecord.PfReg_5,oldRecord.TaxReg_1,oldRecord.TaxReg_2,oldRecord.TaxReg_3,oldRecord.IsCanceled,oldRecord.UserID_Created,clsSecurity.UserIDLoged,oldRecord.UserID_Canceled,oldRecord.TerminalID_Created,clsSecurity.TerminalID,oldRecord.TerminalID_Canceled,oldRecord.Date_Created,clsSecurity.getServerDateTime(),oldRecord.Date_Canceled);
                                detail.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtCountryID.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_genMasCountry detail = new tbl_genMasCountry(txtCountryID.Text.Trim(), txtCountryName.Text, txtCountryCode.Text,"","",true,false,"","","","","","","","",false,clsSecurity.UserIDLoged,"default","default",clsSecurity.TerminalID,"default","default",clsSecurity.getServerDateTime(), clsConfig.defaultDateTime,clsConfig.defaultDateTime);
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
                    ClearFileds();
                    RefreshGrid();
                }
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
                    bStatus = true;
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!SEACC_Form.IsUpdateMode)
            {
                if (!clsValidation.Validate_EmptyValue(txtCountryID))
                    bStatus = false;
                if (!clsValidation.Validate_EmptyValue(txtCountryName))
                    bStatus = false;
                if (!clsValidation.Validate_EmptyValue(txtCountryCode))
                    bStatus = false;
            }

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_genMasCountry detail = tbl_genMasCountry.Select(txtCountryID.Text);
                if (detail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            tbl_genMasCountry detail = tbl_genMasCountry.Select(sID);
            if (detail != null)
            {
                SEACC_Form.IsUpdateMode = true;
                txtCountryID.IsEnabled = false;
                
                txtCountryID.Text = detail.Country_ID;
                txtCountryName.Text = detail.CountryName;
                txtCountryCode.Text = detail.Country_Code_ISO;

                txtCountryID.Tag = detail.Country_ID;
            }
        }
        #endregion

        #region Grid Event
        private void grd_Country_MouseLeftButtonUp1(object sender, EventArgs e)
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
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Search Event
        private void txtCountryID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CountryMaster);
            if (RowDataSearch.DialogResult == true)
            {
                txtCountryID.Text = lstResult[0];
                txtCountryID.Tag = lstResult[0];
                ClearFileds();
                FillDetails(lstResult[0]);
            }
        }
        #endregion

    }
}
