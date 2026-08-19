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
    /// Interaction logic for UC_BrokerMaster.xaml
    /// </summary>
    public partial class UC_BrokerMaster : UserControl
    {
        public UC_BrokerMaster()
        {
            #region User Control Initialize
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.BrokerMaster;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("BrokerId");
            dgr_Main.dt.Columns.Add("BrokerCode");
            dgr_Main.dt.Columns.Add("BrokerName");
            dgr_Main.dt.Columns.Add("Pecentage");
            dgr_Main.dt.Columns.Add("Status");
            dgr_Main.dt.Columns.Add("Address");
            dgr_Main.dt.Columns.Add("Country");
            dgr_Main.dt.Columns.Add("Province");
            dgr_Main.dt.Columns.Add("District");
            dgr_Main.dt.Columns.Add("City");
            dgr_Main.dt.Columns.Add("Town");
            dgr_Main.dt.Columns.Add("ZIP");
            dgr_Main.dt.Columns.Add("Email");
            dgr_Main.dt.Columns.Add("Phone");
            dgr_Main.dt.Columns.Add("Mobile");
            dgr_Main.dt.Columns.Add("Fax");
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("ID", "BrokerId", 60, false);
            dgr_Main.Add_DatagridColoumn("Code", "BrokerCode", 60);
            dgr_Main.Add_DatagridColoumn("Name", "BrokerName", 120);
            dgr_Main.Add_DatagridColoumn("%", "Pecentage", 35);
            dgr_Main.Add_DatagridColoumn("Status", "Status", 50, false);
            dgr_Main.Add_DatagridColoumn("Address", "Address", 80, false);
            dgr_Main.Add_DatagridColoumn("Country", "Country", 80, false);
            dgr_Main.Add_DatagridColoumn("Province", "Province", 80, false);
            dgr_Main.Add_DatagridColoumn("District", "District", 80, false);
            dgr_Main.Add_DatagridColoumn("City", "City", 80, false);
            dgr_Main.Add_DatagridColoumn("Town", "Town", 80, false);
            dgr_Main.Add_DatagridColoumn("ZIP Code", "ZIP", 80, false);
            dgr_Main.Add_DatagridColoumn("Email", "Email", 100);
            dgr_Main.Add_DatagridColoumn("Phone", "Phone", 80);
            dgr_Main.Add_DatagridColoumn("Mobile", "Mobile", 80);
            dgr_Main.Add_DatagridColoumn("Fax", "Fax", 80, false);
            #endregion

            ClearFields();
            RefreshGrid();
        }

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtBrokerID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBrokerCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBrokerName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBrokerPct, true, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBrokerStatus, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBrokerAddress, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBrokerCountry, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBrokerProvince, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBrokerDistrict, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBrokerCity, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBrokerTown, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBrokerZipCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBrokerPhone, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBrokerEmail, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBrokerMobile, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBrokerFax, true, false, true);

            txtBrokerID.Text = "";
            txtBrokerCode.Text = "";
            txtBrokerName.Text = "";
            txtBrokerPct.Text = "";
            txtBrokerStatus.Text = "";
            txtBrokerAddress.Text = "";
            txtBrokerCountry.Text = "";
            txtBrokerProvince.Text = "";
            txtBrokerDistrict.Text = "";
            txtBrokerCity.Text = "";
            txtBrokerTown.Text = "";
            txtBrokerZipCode.Text = "";
            txtBrokerPhone.Text = "";
            txtBrokerEmail.Text = "";
            txtBrokerMobile.Text = "";
            txtBrokerFax.Text = "";

            txtBrokerID.Tag = null;
            txtBrokerCountry.Tag = "default";
            txtBrokerProvince.Tag = "default";
            txtBrokerDistrict.Tag = "default";
            txtBrokerCity.Tag = "default";
            txtBrokerTown.Tag = "default";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtBrokerID.setReadOnlyStatus(true);
                txtBrokerID.Text = "<Auto Generate>";
            }
            else
                txtBrokerID.setReadOnlyStatus(false);
        }
        #endregion

        #region Action Buttons

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_genBrokerMaster OldBroker = tbl_genBrokerMaster.Select(txtBrokerID.Text.Trim());
                            if (OldBroker != null)
                            {
                                tbl_genBrokerMaster oBroker = new tbl_genBrokerMaster(txtBrokerID.Text, txtBrokerCode.Text, txtBrokerName.Text, txtBrokerAddress.Text, txtBrokerAddress.Text, txtBrokerPhone.Text, txtBrokerMobile.Text, txtBrokerFax.Text, txtBrokerEmail.Text, OldBroker.Url, OldBroker.BusinessRegistraionNo, OldBroker.VatRegistrationNo, OldBroker.NbtRegistrationNo, OldBroker.SvatRegistrationNo, OldBroker.Remark, OldBroker.IsBlacklisted, OldBroker.IsLocked, OldBroker.IsDeleted, txtBrokerCountry.Tag.ToString(), txtBrokerProvince.Tag.ToString(), txtBrokerDistrict.Tag.ToString(), txtBrokerCity.Tag.ToString(), txtBrokerTown.Tag.ToString(), OldBroker.Area_ID, OldBroker.Route_ID, OldBroker.BrokerType_ID, OldBroker.BrokerCategory_ID, OldBroker.BrokerClass_ID, OldBroker.Currency_ID, OldBroker.SalesManager_ID, OldBroker.AreaManager_ID, OldBroker.SalesRep_ID, OldBroker.SalesExecutive_ID, OldBroker.Gl_ID, OldBroker.CompanyBranch_ID, OldBroker.IsVATenable, OldBroker.IsSVATenable, OldBroker.IsNBTenable, OldBroker.IsBrokerPricingEnable, OldBroker.Title, OldBroker.NicNo, OldBroker.DateOfBirth, OldBroker.BrokerAccountType_ID, OldBroker.IsPostingEnable_VAT, OldBroker.IsPostingEnable_NBT, OldBroker.SalesReturnedGL_ID, decimal.Parse(txtBrokerPct.Text));
                                oBroker.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    else
                    {                        
                        tbl_genBrokerMaster nBroker = new tbl_genBrokerMaster(txtBrokerID.Tag.ToString(), txtBrokerCode.Text, txtBrokerName.Text, txtBrokerAddress.Text, txtBrokerAddress.Text, txtBrokerPhone.Text, txtBrokerMobile.Text, txtBrokerFax.Text, txtBrokerEmail.Text, "", "", "", "", "", "", false, false, false, txtBrokerCountry.Tag.ToString(), txtBrokerProvince.Tag.ToString(), txtBrokerDistrict.Tag.ToString(), txtBrokerCity.Tag.ToString(), txtBrokerTown.Tag.ToString(), "default", "default", "default", "default", "default", "default", "default", "default", "default", "default", "default", "default", false, false, false, false, "", "", clsConfig.defaultDateTime, "default", false, false, "default", decimal.Parse(txtBrokerPct.Text));
                        nBroker.Insert();
                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                    }
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

        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
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
            return bStatus;
        }
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtBrokerCode))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtBrokerName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtBrokerPct))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtBrokerPhone))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtBrokerEmail))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtBrokerID.Tag = SEACC_Form.getAutoGeneratedCode();

                tbl_genBrokerMaster oDetail = tbl_genBrokerMaster.Select(txtBrokerID.Tag.ToString());
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_genBrokerMaster item in tbl_genBrokerMaster.SelectAll().Where(p => p.Broker_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(item.Broker_ID, item.BrokerCode, item.BrokerName,cls_Formater.FormatDecimal(item.BrokerPercentage,2), "", item.AddressRegister, item.Country_ID, item.Province_ID, item.District_ID, item.City_ID, item.Town_ID, "", item.Email, item.Telephone, item.Mobile, item.Fax);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Fill Details
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_genBrokerMaster FillDetails = tbl_genBrokerMaster.Select(sID);
                    if (FillDetails != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtBrokerID.IsEnabled = false;

                        txtBrokerID.Text = FillDetails.Broker_ID;
                        txtBrokerCode.Text = FillDetails.BrokerCode;
                        txtBrokerName.Text = FillDetails.BrokerName;
                        txtBrokerPct.Text =  FillDetails.BrokerPercentage.ToString();
                        txtBrokerStatus.Text = "";
                        txtBrokerAddress.Text = FillDetails.AddressRegister;
                        txtBrokerCountry.Text = (FillDetails.Country_ID != "default") ? FillDetails.Country_ID + " - " + clsRef_Name.get_Country_Name(FillDetails.Country_ID) : "";
                        txtBrokerProvince.Text = (FillDetails.Province_ID != "default") ? FillDetails.Province_ID + " - " + clsRef_Name.get_Province_Name(FillDetails.Province_ID) : "";
                        txtBrokerDistrict.Text = (FillDetails.District_ID != "default") ? FillDetails.District_ID + " - " + clsRef_Name.get_District_Name(FillDetails.District_ID) : "";
                        txtBrokerCity.Text = (FillDetails.City_ID != "default") ? FillDetails.City_ID + " - " + clsRef_Name.get_City_Name(FillDetails.City_ID) : "";
                        txtBrokerTown.Text = (FillDetails.Town_ID != "default") ? FillDetails.Town_ID + " - " + clsRef_Name.get_Town_Name(FillDetails.Town_ID) : "";
                        txtBrokerZipCode.Text = "";
                        txtBrokerEmail.Text = FillDetails.Email;
                        txtBrokerPhone.Text = FillDetails.Telephone;
                        txtBrokerMobile.Text = FillDetails.Mobile;
                        txtBrokerFax.Text = FillDetails.Fax;

                        txtBrokerID.Tag = FillDetails.Broker_ID;
                        txtBrokerCountry.Tag = FillDetails.Country_ID;
                        txtBrokerProvince.Tag = FillDetails.Province_ID;
                        txtBrokerDistrict.Tag = FillDetails.District_ID;
                        txtBrokerCity.Tag = FillDetails.City_ID;
                        txtBrokerTown.Tag = FillDetails.Town_ID;
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
        private void txtBrokerCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Brokers);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtBrokerCode.Text = lstResult[0];
                txtBrokerCode.Tag = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }

        private void txtBrokerCountry_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CountryMaster);
            if (RowDataSearch.DialogResult == true)
            {
                txtBrokerCountry.Text = lstResult[0] + " - " + lstResult[3];
                txtBrokerCountry.Tag = lstResult[0];
            }
        }

        private void txtBrokerProvince_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ProvinceCode);
            if (RowDataSearch.DialogResult == true)
            {
                txtBrokerProvince.Text = lstResult[0] + " - " + lstResult[1];
                txtBrokerProvince.Tag = lstResult[0];
            }
        }

        private void txtBrokerDistrict_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Districts);
            if (RowDataSearch.DialogResult == true)
            {
                txtBrokerDistrict.Text = lstResult[0] + " - " + lstResult[1];
                txtBrokerDistrict.Tag = lstResult[0];
            }
        }

        private void txtBrokerCity_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CityMaster);
            if (RowDataSearch.DialogResult == true)
            {
                txtBrokerCity.Text = lstResult[0] + " - " + lstResult[3];
                txtBrokerCity.Tag = lstResult[0];
            }
        }

        private void txtBrokerTown_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Town);
            if (RowDataSearch.DialogResult == true)
            {
                txtBrokerTown.Text = lstResult[0] + " - " + lstResult[1];
                txtBrokerTown.Tag = lstResult[0];
            }
        }
        #endregion
    }
}
