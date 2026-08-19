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
    /// Interaction logic for UC_CustomerMaster.xaml
    /// </summary>
    public partial class UC_CustomerMaster : UserControl
    {
        public UC_CustomerMaster()
        {
            #region User Control Initialize
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.CustomerMaster;
            SEACC_Form.Initialize();


            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("CustomerId");
            dgr_Main.dt.Columns.Add("CustomerCode");
            dgr_Main.dt.Columns.Add("CustomerName");
            dgr_Main.dt.Columns.Add("Class");
            dgr_Main.dt.Columns.Add("Type");
            dgr_Main.dt.Columns.Add("Category");
            dgr_Main.dt.Columns.Add("Status");
            dgr_Main.dt.Columns.Add("BusinessRegNo");
            dgr_Main.dt.Columns.Add("VatRegNo");
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
            dgr_Main.Add_DatagridColoumn("Id", "CustomerId", 60, false);
            dgr_Main.Add_DatagridColoumn("Code", "CustomerCode", 120);
            dgr_Main.Add_DatagridColoumn("Name", "CustomerName", 220);
            dgr_Main.Add_DatagridColoumn("Class", "Class", 60 , false);
            dgr_Main.Add_DatagridColoumn("Type", "Type", 60, false);
            dgr_Main.Add_DatagridColoumn("Category", "Category", 60, false);
            dgr_Main.Add_DatagridColoumn("Status", "Status", 50, false);
            dgr_Main.Add_DatagridColoumn("Business Reg.", "BusinessRegNo", 60, false);
            dgr_Main.Add_DatagridColoumn("VAT Reg.", "VatRegNo", 60, false);
            dgr_Main.Add_DatagridColoumn("Address", "Address", 60, false);
            dgr_Main.Add_DatagridColoumn("Country", "Country", 80, false);
            dgr_Main.Add_DatagridColoumn("Province", "Province", 80, false);
            dgr_Main.Add_DatagridColoumn("District", "District", 80, false);
            dgr_Main.Add_DatagridColoumn("City", "City", 80, false);
            dgr_Main.Add_DatagridColoumn("Town", "Town", 80, false);
            dgr_Main.Add_DatagridColoumn("ZIP Code", "ZIP", 80, false);
            dgr_Main.Add_DatagridColoumn("Email", "Email", 180);
            dgr_Main.Add_DatagridColoumn("Phone", "Phone", 150);
            dgr_Main.Add_DatagridColoumn("Mobile", "Mobile", 80);
            dgr_Main.Add_DatagridColoumn("Fax", "Fax", 80, false);
            #endregion

            ClearFields();
            RefreshGrid();
            #endregion
        }


        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtCustomerID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomerCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomerName, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerClass, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerType, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerCategory, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomerStatus, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBusinessRegNo, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtVatRegNo, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomerAddress, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerTown, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerCity, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerDistrict, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerProvince, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomerCountry, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomerZipCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomerPhone, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomerEmail, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomerMobile, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCustomerFax, true, false, true);

            txtCustomerID.Text = "";
            txtCustomerCode.Text = "";
            txtCustomerName.Text = "";
            txtCustomerClass.Text = "";
            txtCustomerType.Text = "";
            txtCustomerCategory.Text = "";
            txtCustomerStatus.Text = "";
            txtBusinessRegNo.Text = "";
            txtVatRegNo.Text = "";
            txtCustomerAddress.Text = "";
            txtCustomerTown.Text = "";
            txtCustomerCity.Text = "";
            txtCustomerDistrict.Text = "";
            txtCustomerProvince.Text = "";
            txtCustomerCountry.Text = "";
            txtCustomerZipCode.Text = "";
            txtCustomerPhone.Text = "";
            txtCustomerEmail.Text = "";
            txtCustomerMobile.Text = "";
            txtCustomerFax.Text = "";

            txtCustomerID.Tag = null;
            txtCustomerClass.Tag = "default";
            txtCustomerType.Tag = "default";
            txtCustomerCategory.Tag = "default";
            txtCustomerTown.Tag = "default";
            txtCustomerCity.Tag = "default";
            txtCustomerDistrict.Tag = "default";
            txtCustomerProvince.Tag = "default";
            txtCustomerCountry.Tag = "default";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtCustomerID.setReadOnlyStatus(true);
                txtCustomerID.Text = "<Auto Generate>";
            }
            else
                txtCustomerID.setReadOnlyStatus(false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_genCustomerMaster item in tbl_genCustomerMaster.SelectAll().Where(p => p.Customer_ID != "default"))
                {
                    dgr_Main.dt.Rows.Add(item.Customer_ID, item.CustomerCode, item.CustomerName, clsRef_Name.get_CustomerClass_Name(item.CustomerClass_ID), clsRef_Name.get_CustomerType_Name(item.CustomerType_ID), clsRef_Name.get_CustomerCategory_Name(item.CustomerCategory_ID), "", item.BusinessRegistraionNo, item.VatRegistrationNo, item.AddressRegister, clsRef_Name.get_Country_Name(item.Country_ID), clsRef_Name.get_Province_Name(item.Province_ID), clsRef_Name.get_District_Name(item.District_ID), item.City_ID, clsRef_Name.get_Town_Name(item.Town_ID), "", item.Email, item.Telephone, item.Mobile, item.Fax);
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
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
                            tbl_genCustomerMaster OldCustomer = tbl_genCustomerMaster.Select(txtCustomerID.Text.Trim());
                            if (OldCustomer != null)
                            {
                                tbl_genCustomerMaster oCustomer = new tbl_genCustomerMaster(txtCustomerID.Text, txtCustomerCode.Text, txtCustomerName.Text, txtCustomerAddress.Text, txtCustomerAddress.Text, txtCustomerPhone.Text, txtCustomerMobile.Text, txtCustomerFax.Text, txtCustomerEmail.Text, OldCustomer.Url, txtBusinessRegNo.Text, txtVatRegNo.Text, OldCustomer.NbtRegistrationNo, OldCustomer.SvatRegistrationNo, OldCustomer.Remark, OldCustomer.IsBlacklisted, OldCustomer.IsLocked, OldCustomer.IsDeleted, txtCustomerCountry.Tag.ToString(), txtCustomerProvince.Tag.ToString(), txtCustomerDistrict.Tag.ToString(), txtCustomerCity.Tag.ToString(), txtCustomerTown.Tag.ToString(), OldCustomer.Area_ID, OldCustomer.Route_ID, txtCustomerType.Tag.ToString(), txtCustomerCategory.Tag.ToString(), txtCustomerClass.Tag.ToString(), OldCustomer.Currency_ID, OldCustomer.SalesManager_ID, OldCustomer.AreaManager_ID, OldCustomer.SalesRep_ID, OldCustomer.SalesExecutive_ID, OldCustomer.Gl_ID, OldCustomer.CompanyBranch_ID, OldCustomer.IsVATenable, OldCustomer.IsSVATenable, OldCustomer.IsNBTenable, OldCustomer.IsCustomerPricingEnable, OldCustomer.Title, OldCustomer.NicNo, OldCustomer.DateOfBirth, OldCustomer.CustomerAccountType_ID, OldCustomer.IsPostingEnable_VAT, OldCustomer.IsPostingEnable_NBT, OldCustomer.SalesReturnedGL_ID);
                                oCustomer.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    else
                    {                        
                        tbl_genCustomerMaster nCustomer = new tbl_genCustomerMaster(txtCustomerID.Tag.ToString(), txtCustomerCode.Text, txtCustomerName.Text, txtCustomerAddress.Text, txtCustomerAddress.Text, txtCustomerPhone.Text, txtCustomerMobile.Text, txtCustomerFax.Text, txtCustomerEmail.Text, "", txtBusinessRegNo.Text, txtVatRegNo.Text, "", "", "", false, false, false, txtCustomerCountry.Tag.ToString(), txtCustomerProvince.Tag.ToString(), txtCustomerDistrict.Tag.ToString(), txtCustomerCity.Tag.ToString(), txtCustomerTown.Tag.ToString(), "default", "default", txtCustomerType.Tag.ToString(), txtCustomerCategory.Tag.ToString(), txtCustomerClass.Tag.ToString(), "default", "default", "default", "default", "default", "default", clsSecurity.BranchID, false, false, false, false, "", "", clsConfig.defaultDateTime, "default", false, false, "default");
                        nCustomer.Insert();
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

            if (!clsValidation.Validate_EmptyValue(txtCustomerCode))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCustomerName))
                bStatus = false;
            //if (!clsValidation.Validate_LableTextBox_EmptyValue(txtCustomerClass))
            //    bStatus = false;
            //if (!clsValidation.Validate_LableTextBox_EmptyValue(txtCustomerType))
            //    bStatus = false;
            //if (!clsValidation.Validate_LableTextBox_EmptyValue(txtCustomerCategory))
            //    bStatus = false;
            //if (!clsValidation.Validate_LableTextBox_EmptyValue(txtCustomerEmail))
            //    bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCustomerPhone))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                    txtCustomerID.Tag = SEACC_Form.getAutoGeneratedCode();

                tbl_genCustomerMaster oDetail = tbl_genCustomerMaster.Select(txtCustomerID.Tag.ToString());
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
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
                    tbl_genCustomerMaster FillDetails = tbl_genCustomerMaster.Select(sID);
                    if (FillDetails != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtCustomerID.IsEnabled = false;

                        txtCustomerID.Text = FillDetails.Customer_ID;
                        txtCustomerCode.Text = FillDetails.CustomerCode;
                        txtCustomerName.Text = FillDetails.CustomerName;
                        txtCustomerClass.Text = FillDetails.CustomerClass_ID + " - " + clsRef_Name.get_CustomerClass_Name(FillDetails.CustomerClass_ID);
                        txtCustomerType.Text = FillDetails.CustomerType_ID + " - " + clsRef_Name.get_CustomerType_Name(FillDetails.CustomerType_ID);
                        txtCustomerCategory.Text = FillDetails.CustomerCategory_ID + " - " + clsRef_Name.get_CustomerCategory_Name(FillDetails.CustomerCategory_ID);
                        txtCustomerStatus.Text = "";
                        txtBusinessRegNo.Text = FillDetails.BusinessRegistraionNo;
                        txtVatRegNo.Text = FillDetails.VatRegistrationNo;
                        txtCustomerAddress.Text = FillDetails.AddressRegister;
                        txtCustomerTown.Text = (FillDetails.Town_ID != "default") ? FillDetails.Town_ID + " - " + clsRef_Name.get_Town_Name(FillDetails.Town_ID) : "";
                        txtCustomerCity.Text = (FillDetails.City_ID != "default") ? FillDetails.City_ID + " - " + clsRef_Name.get_City_Name(FillDetails.City_ID) : "";
                        txtCustomerDistrict.Text = (FillDetails.District_ID != "default") ? FillDetails.District_ID + " - " + clsRef_Name.get_District_Name(FillDetails.District_ID) : "";
                        txtCustomerProvince.Text = (FillDetails.Province_ID != "default") ? FillDetails.Province_ID + " - " + clsRef_Name.get_Province_Name(FillDetails.Province_ID) : "";
                        txtCustomerCountry.Text = (FillDetails.Country_ID != "default") ? FillDetails.Country_ID + " - " + clsRef_Name.get_Country_Name(FillDetails.Country_ID) : "";
                        txtCustomerZipCode.Text = "";
                        txtCustomerPhone.Text = FillDetails.Telephone;
                        txtCustomerEmail.Text = FillDetails.Email;
                        txtCustomerMobile.Text = FillDetails.Mobile;
                        txtCustomerFax.Text = FillDetails.Fax;

                        txtCustomerCode.Tag = FillDetails.Customer_ID;
                        txtCustomerClass.Tag = FillDetails.CustomerClass_ID;
                        txtCustomerType.Tag = FillDetails.CustomerType_ID;
                        txtCustomerCategory.Tag = FillDetails.CustomerCategory_ID;
                        txtCustomerTown.Tag = FillDetails.Town_ID;
                        txtCustomerCity.Tag = FillDetails.City_ID;
                        txtCustomerDistrict.Tag = FillDetails.District_ID;
                        txtCustomerProvince.Tag = FillDetails.Province_ID;
                        txtCustomerCountry.Tag = FillDetails.Country_ID;
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
        private void txtCustomerCode_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Customers);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtCustomerCode.Text = lstResult[0];
                txtCustomerCode.Tag = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }
        private void txtCustomerClass_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CustomerClass);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomerClass.Text = lstResult[0] + " - " + lstResult[1];
                txtCustomerClass.Tag = lstResult[0];
            }
        }

        private void txtCustomerType_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CustomerType);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomerType.Text = lstResult[0] + " - " + lstResult[1];
                txtCustomerType.Tag = lstResult[0];
            }
        }

        private void txtCustomerCategory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CustomerCategory);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomerCategory.Text = lstResult[0] + " - " + lstResult[1];
                txtCustomerCategory.Tag = lstResult[0];
            }
        }

        private void txtCustomerCity_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CityMaster);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomerCity.Text = lstResult[0] + " - " + lstResult[3];
                txtCustomerCity.Tag = lstResult[0];
            }
        }

        private void txtCustomerTown_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Town);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomerTown.Text = lstResult[0] + " - " + lstResult[1];
                txtCustomerTown.Tag = lstResult[0];
            }
        }

        private void txtCustomerDistrict_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Districts);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomerDistrict.Text = lstResult[0] + " - " + lstResult[1];
                txtCustomerDistrict.Tag = lstResult[0];
            }
        }

        private void txtCustomerProvince_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ProvinceCode);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomerProvince.Text = lstResult[0] + " - " + lstResult[1];
                txtCustomerProvince.Tag = lstResult[0];
            }
        }

        private void txtCustomerCountry_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CountryMaster);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomerCountry.Text = lstResult[0] + " - " + lstResult[3];
                txtCustomerCountry.Tag = lstResult[0];
            }
        }
        #endregion
    }
}
