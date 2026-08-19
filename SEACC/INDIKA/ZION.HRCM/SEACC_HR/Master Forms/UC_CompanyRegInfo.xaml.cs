using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_CompanyRegInfo.xaml
    /// </summary>
    public partial class UC_CompanyRegInfo : UserControl
    {
        #region From Initialize
        public UC_CompanyRegInfo()
        {
            #region Usercontrol Initalize
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Registration_Details;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("RegID");
            dgr_Main.dt.Columns.Add("CompanyCode");
            dgr_Main.dt.Columns.Add("CompanyName");
            dgr_Main.dt.Columns.Add("Address");
            dgr_Main.dt.Columns.Add("Telephone1");
            dgr_Main.dt.Columns.Add("Telephone2");
            dgr_Main.dt.Columns.Add("Telephone3");
            dgr_Main.dt.Columns.Add("Fax");
            dgr_Main.dt.Columns.Add("Email");
            dgr_Main.dt.Columns.Add("WebUrl");
            #endregion

            #region Initialize Action Button
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Registration ID", "RegID", 150);
            dgr_Main.Add_DatagridColoumn("Company Name", "CompanyName", 150);
            dgr_Main.Add_DatagridColoumn("Address", "Address", 150);
            dgr_Main.Add_DatagridColoumn("Telephone 1", "Telephone1", 80);
            dgr_Main.Add_DatagridColoumn("Telephone 2", "Telephone2", 80);
            dgr_Main.Add_DatagridColoumn("Telephone 3", "Telephone3", 80);
            dgr_Main.Add_DatagridColoumn("Fax", "Fax", 50);
            dgr_Main.Add_DatagridColoumn("Email", "Email", 100);
            dgr_Main.Add_DatagridColoumn("Web Url", "WebUrl", 100);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Action Buttons
        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                string sRegID = "";
                try
                {
                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_genRegistrationInfo oldRecord = tbl_genRegistrationInfo.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtRegisterID.Text);
                            if (oldRecord != null)
                            {
                                tbl_genRegistrationInfo oRegistrion = new tbl_genRegistrationInfo(
                                    clsSecurity.CompanyID, clsSecurity.BranchID,
                                    txtRegisterID.Text, txtCompanyCode.Text, clsSecurity.encryptPassword(txtCompanyName.Text), clsSecurity.encryptPassword(txtAddress.Text),
                                    txtTelephone1.Text, txtTelephone2.Text, txtTelephone3.Text, txtFax.Text, txtEmail.Text, txtUrl.Text, txtVatRegNo.Text,
                                    txtMdName.Text, txtMdTelephone.Text, txtBusinessRegNo.Text, txtEPFRegNo.Text, txtETFRegNo.Text, txtPAYERegNo.Text, txtTaxIdentityNo.Text,
                                    oldRecord.SerialNo1, oldRecord.SerialNo2, oldRecord.SerialNo3, oldRecord.SerialNo4,
                                    cls_Formater.Convert_BitMapToByteArray(imgMain.getImage() as BitmapImage),
                                    cls_Formater.Convert_BitMapToByteArray(imgLogo.getImage() as BitmapImage),
                                    cls_Formater.Convert_BitMapToByteArray(imgText.getImage() as BitmapImage));
                                oRegistrion.Update();

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                            sRegID = oldRecord.Reg_ID;
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        tbl_genRegistrationInfo oRegistration = new tbl_genRegistrationInfo(
                                    clsSecurity.CompanyID, clsSecurity.BranchID,
                                    txtRegisterID.Text, txtCompanyCode.Text, clsSecurity.encryptPassword(txtCompanyName.Text), clsSecurity.encryptPassword(txtAddress.Text),
                                    txtTelephone1.Text, txtTelephone2.Text, txtTelephone3.Text, txtFax.Text, txtEmail.Text, txtUrl.Text, txtVatRegNo.Text,
                                    txtMdName.Text, txtMdTelephone.Text,
                                    txtBusinessRegNo.Text, txtEPFRegNo.Text, txtETFRegNo.Text, txtPAYERegNo.Text, txtTaxIdentityNo.Text,
                                    "", "", "", "",
                                    cls_Formater.Convert_BitMapToByteArray(imgMain.getImage() as BitmapImage),
                                    cls_Formater.Convert_BitMapToByteArray(imgLogo.getImage() as BitmapImage),
                                    cls_Formater.Convert_BitMapToByteArray(imgText.getImage() as BitmapImage));
                        oRegistration.Insert();
                        sRegID = oRegistration.Reg_ID;
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
                    fillDetails(sRegID);
                }
            }
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                foreach (tbl_genRegistrationInfo oRegistration in tbl_genRegistrationInfo.SelectAll().Where(p => p.Reg_ID != "default"))
                    dgr_Main.dt.Rows.Add(oRegistration.Reg_ID, oRegistration.CompanyCode, clsSecurity.decryptPassword(oRegistration.CompanyName), clsSecurity.decryptPassword(oRegistration.Address), oRegistration.Telephone1, oRegistration.Telephone2, oRegistration.Telephone3, oRegistration.Fax, oRegistration.Email, oRegistration.Url);

                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
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
                    tbl_genRegistrationInfo oFillDetails = tbl_genRegistrationInfo.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sID);
                    if (oFillDetails != null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        txtRegisterID.Tag = oFillDetails.Reg_ID;

                        txtRegisterID.Text = oFillDetails.Reg_ID;
                        txtCompanyCode.Text = oFillDetails.CompanyCode;
                        txtCompanyName.Text = clsSecurity.decryptPassword(oFillDetails.CompanyName);
                        txtAddress.Text = clsSecurity.decryptPassword(oFillDetails.Address);
                        txtTelephone1.Text = oFillDetails.Telephone1;
                        txtTelephone2.Text = oFillDetails.Telephone2;
                        txtTelephone3.Text = oFillDetails.Telephone3;
                        txtFax.Text = oFillDetails.Fax;
                        txtEmail.Text = oFillDetails.Email;
                        txtUrl.Text = oFillDetails.Url;
                        txtVatRegNo.Text = oFillDetails.VatRegisterNo;
                        txtMdName.Text = oFillDetails.CompanyMDName;
                        txtMdTelephone.Text = oFillDetails.MdTelephone;
                        txtBusinessRegNo.Text = oFillDetails.BusinessRegisterNo;
                        txtEPFRegNo.Text = oFillDetails.Epf_RegNo;
                        txtETFRegNo.Text = oFillDetails.Etf_RegNo;
                        txtPAYERegNo.Text = oFillDetails.Payee_RegNo;
                        txtTaxIdentityNo.Text = oFillDetails.Tax_IdentityNo;

                        #region Company Image
                        if (oFillDetails.MainLogo.Length > 0)
                        {
                            using (var stream = new MemoryStream(oFillDetails.MainLogo))
                            {
                                var bitmap = new BitmapImage();
                                bitmap.BeginInit();
                                bitmap.StreamSource = stream;
                                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                                bitmap.EndInit();
                                bitmap.Freeze();
                                if (bitmap != null)
                                    imgMain.setImage(bitmap);
                            }
                        }

                        if (oFillDetails.LogoOnly.Length > 0)
                        {
                            using (var stream = new MemoryStream(oFillDetails.LogoOnly))
                            {
                                var bitmap = new BitmapImage();
                                bitmap.BeginInit();
                                bitmap.StreamSource = stream;
                                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                                bitmap.EndInit();
                                bitmap.Freeze();
                                if (bitmap != null)
                                    imgLogo.setImage(bitmap);
                            }
                        }

                        if (oFillDetails.TextOnly.Length > 0)
                        {
                            using (var stream = new MemoryStream(oFillDetails.TextOnly))
                            {
                                var bitmap = new BitmapImage();
                                bitmap.BeginInit();
                                bitmap.StreamSource = stream;
                                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                                bitmap.EndInit();
                                bitmap.Freeze();
                                if (bitmap != null)
                                    imgText.setImage(bitmap);
                            }
                        }
                        #endregion

                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Form Responsiveness
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(470);
        }
        #endregion

        #region Clear Fiels
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtRegisterID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCompanyCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCompanyName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAddress, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtTelephone1, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtTelephone2, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtTelephone3, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFax, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtUrl, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEmail, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtVatRegNo, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtMdName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtMdTelephone, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBusinessRegNo, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEPFRegNo, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtETFRegNo, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPAYERegNo, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtTaxIdentityNo, true, false, false);

            txtRegisterID.Tag = null;

            txtRegisterID.Text = "";
            txtCompanyName.Text = "";
            txtCompanyCode.Text = "";
            txtAddress.Text = "";
            txtTelephone1.Text = "";
            txtTelephone2.Text = "";
            txtTelephone3.Text = "";
            txtFax.Text = "";
            txtUrl.Text = "";
            txtEmail.Text = "";
            txtVatRegNo.Text = "";
            txtBusinessRegNo.Text = "";
            txtEPFRegNo.Text = "";
            txtETFRegNo.Text = "";
            txtPAYERegNo.Text = "";
            txtTaxIdentityNo.Text = "";
            txtMdName.Text = "";
            txtMdTelephone.Text = "";

            imgMain.setImage(new BitmapImage(new Uri("/Resources/logo.PNG", UriKind.Relative)));
            imgLogo.setImage(new BitmapImage(new Uri("/Resources/logo.PNG", UriKind.Relative)));
            imgText.setImage(new BitmapImage(new Uri("/Resources/logo.PNG", UriKind.Relative)));


            #region Set Auto Genarate Key fields
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtRegisterID.setReadOnlyStatus(true);
                txtRegisterID.Text = "<Auto Generate>";
            }
            else
                txtRegisterID.setReadOnlyStatus(false);
            #endregion
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

        #region Check validity
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

            if (!clsValidation.Validate_EmptyValue(txtRegisterID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCompanyCode))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCompanyName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtAddress))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtTelephone1))
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
                    txtRegisterID.Tag = SEACC_Form.getAutoGeneratedCode();
                    txtRegisterID.Text = txtRegisterID.Tag.ToString();
                }

                foreach (tbl_genRegistrationInfo oDetail in tbl_genRegistrationInfo.SelectAll().Where(p => p.Reg_ID == txtRegisterID.Text))
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                    break;
                }
            }
            return bStatus;
        }
        #endregion

    }
}
