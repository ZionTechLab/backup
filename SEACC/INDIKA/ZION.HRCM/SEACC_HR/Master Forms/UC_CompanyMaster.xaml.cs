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
using System.IO;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_CompanyMaster.xaml
    /// </summary>
    public partial class UC_CompanyMaster : UserControl
    {
        #region Form Load
        public UC_CompanyMaster()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Company_Creation;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dgr_Main.dt.Columns.Add("CompanyCode");
            dgr_Main.dt.Columns.Add("CompanyName");
            dgr_Main.dt.Columns.Add("Address");
            dgr_Main.dt.Columns.Add("Telephone1");
            dgr_Main.dt.Columns.Add("Telephone2");
            dgr_Main.dt.Columns.Add("Telephone3");
            dgr_Main.dt.Columns.Add("Fax");
            dgr_Main.dt.Columns.Add("Email");
            dgr_Main.dt.Columns.Add("WebUrl");
            dgr_Main.dt.Columns.Add("VatRegNo");
            //dgr_Main.dt.Columns.Add("MDName");
            //dgr_Main.dt.Columns.Add("MDTelephone");
            dgr_Main.dt.Columns.Add("BizRegNo");
            //dgr_Main.dt.Columns.Add("FinancialYear");
            //dgr_Main.dt.Columns.Add("Month");
            #endregion

            #region Initialize Action Button
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Company Code", "CompanyCode", 100);
            dgr_Main.Add_DatagridColoumn("Company Name", "CompanyName", 150);
            dgr_Main.Add_DatagridColoumn("Address", "Address", 150);
            dgr_Main.Add_DatagridColoumn("Telephone 1", "Telephone1", 80);
            dgr_Main.Add_DatagridColoumn("Telephone 2", "Telephone2", 80);
            dgr_Main.Add_DatagridColoumn("Telephone 3", "Telephone3", 80);
            dgr_Main.Add_DatagridColoumn("Fax", "Fax", 50);
            dgr_Main.Add_DatagridColoumn("Email", "Email", 100);
            dgr_Main.Add_DatagridColoumn("Web Url", "WebUrl", 100);
            dgr_Main.Add_DatagridColoumn("VAT Reg. No.", "VatRegNo", 80);
            //dgr_Main.Add_DatagridColoumn("MD's Name", "MDName", 100);
            //dgr_Main.Add_DatagridColoumn("MD's Telephone", "MDTelephone", 100);
            dgr_Main.Add_DatagridColoumn("Business Reg. NO.", "BizRegNo", 100);
            //dgr_Main.Add_DatagridColoumn("Financial Year", "FinancialYear", 100);
            //dgr_Main.Add_DatagridColoumn("Month", "Month", 50);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsivenss
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(470);
        }
        #endregion

        #region Action Button

        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Print_Click(object sender, RoutedEventArgs e)
        {
          
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtCompanyCode.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_genCompanyInfo oCompany = tbl_genCompanyInfo.Select(txtCompanyCode.Text.Trim());
                            if (oCompany != null)
                            {
                                //oCompany.IsCanceled = true;
                                //oCompany.UserID_Canceled = clsSecurity.UserIDLoged;
                                //oCompany.TerminalID_Canceled = clsSecurity.TerminalID;
                                //oCompany.Date_Canceled = clsSecurity.getServerDateTime();
                                //oCompany.Update();

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
                            tbl_genCompanyInfo oldRecord = tbl_genCompanyInfo.Select(txtCompanyCode.Text.Trim());
                            if (oldRecord != null)
                            {
                                tbl_genCompanyInfo oCity = new tbl_genCompanyInfo(txtCompanyCode.Text, clsSecurity.encryptPassword(txtCompanyName.Text), clsSecurity.encryptPassword(txtAddress.Text), txtTelephone1.Text, txtTelephone2.Text, txtTelephone3.Text, txtFax.Text, txtEmail.Text, txtUrl.Text, txtVatRegNo.Text, oldRecord.CompanyMDName, oldRecord.MdTelephone, oldRecord.DatabaseName, txtBusinessRegNo.Text, txtEPFRegNo.Text, txtETFRegNo.Text, txtPAYERegNo.Text, txtTaxIdentityNo.Text, oldRecord.Edition, oldRecord.SerialNo1, oldRecord.SerialNo2, oldRecord.SerialNo3, oldRecord.SerialNo4, oldRecord.FinancialYear_ID, oldRecord.Month_ID, oldRecord.StartDate, oldRecord.Theme_ID, oldRecord.ProductKey);
                                oCity.Update();

                                tbl_genCompanyImage oldRec = tbl_genCompanyImage.Select(txtCompanyCode.Text.Trim());
                                if (oldRec != null)
                                {
                                    tbl_genCompanyImage oComImage = new tbl_genCompanyImage(txtCompanyCode.Text, cls_Formater.Convert_BitMapToByteArray(imgMain.getImage() as BitmapImage), cls_Formater.Convert_BitMapToByteArray(imgLogo.getImage() as BitmapImage), cls_Formater.Convert_BitMapToByteArray(imgText.getImage() as BitmapImage));
                                    oComImage.Update();
                                }

                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }

                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        if (SEACC_Form.isAutoGenaratedCode)
                            txtCompanyCode.Text = SEACC_Form.getAutoGeneratedCode();

                        tbl_genCompanyInfo oCity = new tbl_genCompanyInfo(txtCompanyCode.Text, clsSecurity.encryptPassword(txtCompanyName.Text), clsSecurity.encryptPassword(txtAddress.Text), txtTelephone1.Text, txtTelephone2.Text, txtTelephone3.Text, txtFax.Text, txtEmail.Text, txtUrl.Text, txtVatRegNo.Text, "", "", "", txtBusinessRegNo.Text, txtEPFRegNo.Text, txtETFRegNo.Text, txtPAYERegNo.Text, txtTaxIdentityNo.Text, 0, "", "", "", "", "", "", clsConfig.defaultDateTime, 0, "");
                        oCity.Insert();

                        tbl_genCompanyImage oComImage = new tbl_genCompanyImage(txtCompanyCode.Text, cls_Formater.Convert_BitMapToByteArray(imgMain.getImage() as BitmapImage), cls_Formater.Convert_BitMapToByteArray(imgLogo.getImage() as BitmapImage), cls_Formater.Convert_BitMapToByteArray(imgText.getImage() as BitmapImage));
                        oComImage.Insert();

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

        #region Clear Fiels
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtCompanyCode, true, false, false);
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
            cls_Formater.SetEnableDisable_LableTextbox(txtFinancialYear, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtMonth, true, false, false);

            txtCompanyCode.Tag = null;

            txtCompanyCode.Text = "";
            txtCompanyName.Text = "";
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

            imgMain.setImage(new BitmapImage(new Uri("/Resources/logo.PNG", UriKind.Relative)));
            imgLogo.setImage(new BitmapImage(new Uri("/Resources/logo.PNG", UriKind.Relative)));
            imgText.setImage(new BitmapImage(new Uri("/Resources/logo.PNG", UriKind.Relative)));


            #region Set Auto Genarate Key fields
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtCompanyCode.setReadOnlyStatus(true);
                txtCompanyCode.Text = "<Auto Generate>";
            }
            else
                txtCompanyCode.setReadOnlyStatus(false);
            #endregion
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
              
                foreach (tbl_genCompanyInfo oDetail in tbl_genCompanyInfo.SelectAll().Where(p => p.CompanyID == txtCompanyCode.Text))
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                    break;

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
                foreach (tbl_genCompanyInfo oCompany in tbl_genCompanyInfo.SelectAll().Where(p => p.CompanyID != "default"))
                {
                    dgr_Main.dt.Rows.Add(oCompany.CompanyID, clsSecurity.decryptPassword(oCompany.CompanyName), clsSecurity.decryptPassword(oCompany.Address), oCompany.Telephone1, oCompany.Telephone2, oCompany.Telephone3, oCompany.Fax, oCompany.Email, oCompany.Url, oCompany.VatRegisterNo, oCompany.BusinessRegisterNo);
                }
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
                    tbl_genCompanyInfo FillDetails = tbl_genCompanyInfo.Select(sID);
                    if (FillDetails != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtCompanyCode.IsEnabled = false;
                        txtCompanyCode.Text = FillDetails.CompanyID;
                        txtCompanyCode.Tag = FillDetails.CompanyID;

                        txtCompanyName.Text = clsSecurity.decryptPassword(FillDetails.CompanyName);
                        txtAddress.Text = clsSecurity.decryptPassword(FillDetails.Address);
                        txtTelephone1.Text = FillDetails.Telephone1;
                        txtTelephone2.Text = FillDetails.Telephone2;
                        txtTelephone3.Text = FillDetails.Telephone3;
                        txtFax.Text = FillDetails.Fax;
                        txtEmail.Text = FillDetails.Email;
                        txtUrl.Text = FillDetails.Url;
                        txtVatRegNo.Text = FillDetails.VatRegisterNo;
                        txtMdName.Text = FillDetails.CompanyMDName;
                        txtMdTelephone.Text = FillDetails.MdTelephone;
                        txtBusinessRegNo.Text = FillDetails.BusinessRegisterNo;
                        txtEPFRegNo.Text = FillDetails.Epf_RegNo;
                        txtETFRegNo.Text = FillDetails.Etf_RegNo;
                        txtPAYERegNo.Text = FillDetails.Payee_RegNo;
                        txtTaxIdentityNo.Text = FillDetails.Tax_IdentityNo;
                        txtFinancialYear.Text = FillDetails.FinancialYear_ID;
                        txtMonth.Text = FillDetails.Month_ID;

                        tbl_genCompanyImage comImage = tbl_genCompanyImage.Select(sID);
                        if (comImage != null)
                        {
                            #region Company Image
                            if (comImage.CompanyID != null)
                            {
                                if (comImage.MainLogo.Length > 0)
                                {
                                    using (var stream = new MemoryStream(comImage.MainLogo))
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

                                if (comImage.LogoOnly.Length > 0)
                                {
                                    using (var stream = new MemoryStream(comImage.LogoOnly))
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

                                if (comImage.TextOnly.Length > 0)
                                {
                                    using (var stream = new MemoryStream(comImage.TextOnly))
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
                            }
                            #endregion
                        }

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

        #region Search Event
        private void txtCompanyName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //frmSearch RowDataSearch = new frmSearch();
            //List<string> lstResult = RowDataSearch.Show(Search.CompanyInfo);
            //if (RowDataSearch.DialogResult == true)
            //{
            //    ClearFields();
            //    //txtCompanyCode.Text = lstResult[0];
            //    txtCompanyCode.Tag = lstResult[0];
            //    fillDetails(lstResult[0]);
            //}
        }
        #endregion
    }
}
