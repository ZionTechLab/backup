using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace SEACC_Keygen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int validationStatus = 0;
        string sProductName = "";
        string ProductType = "";
        string sProductActivationConfig_ID = "281";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void grdTitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearField()
        {
            cls_Formater.SetEnableDisable_LableTextbox(txtCompanyName, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSW_Product, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtUserName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtQuary, true, false, true);

            txtCompanyName.Text = "";
            txtSW_Product.Text = "";
            txtUserName.Text = "";


            txtQuary.Text = "";

            //txtCompanyName.Text = clsSecurity.CompanyName;
            txtSW_Product.Text = sProductName;
            //dtpExpireDate.SetTime(clsSecurity.GetSystemExpireDate());
        }

        private void btnActivate_Click(object sender, RoutedEventArgs e)
        {
            if (txtCompanyName.Text.Length > 0)
            {
                if (txtUserName.Text == "digiteq" && pbUserPassword.Password == "abc@@123")
                {
                    //clsSecurity.encryptPassword(txtCompanyName.Text)
                    string sKey = txtCompanyName.Text + "|~|" + dtpExpireDate.GetDateTime().Date.ToString(clsValidation.Format_Date);
                    string sEncyKey = clsSecurity.encryptPassword(sKey);

                    if (ProductType == "epack")
                    {
                        txtQuary.Text = "UPDATE tbl_genCompanyInfo SET[productKey] = '" + sEncyKey + "' \n" +
                        "UPDATE [dbo].[tbl_securityConfigValue] SET [configValue] = '" + dtpExpireDate.GetDateTime().Date.ToString(clsValidation.Format_Date) + "' WHERE [valueID] = '65' \n"+
                        "UPDATE [dbo].[tbl_securityConfigStatus] SET [configValue] = 'true' WHERE [valueID] = '281'";

                    }
                    else if (ProductType == "hrcm")
                    {
                        txtQuary.Text = "UPDATE tbl_genCompanyInfo SET[productKey] = '" + sEncyKey + "' \n" +
                        "UPDATE [dbo].[tbl_securityConfigValue] SET [configValue] = '" + dtpExpireDate.GetDateTime().Date.ToString(clsValidation.Format_Date) + "' WHERE [valueID] = '1' \n"+
                        "UPDATE [dbo].[tbl_securityConfigStatus] SET [configValue] = 'true' WHERE [valueID] = '7'";
                    }
                }
                else
                {
                    SEACCMessageBox.Show(MessegeBoxType.PasswordsNotMatched);
                }
            }
            else
            {
                SEACCMessageBox.Show("Company Name can't be empty", "Please fill the company name", MessageBoxButton.OK);
            }
        }

        private bool CheckValidityRegistry()
        {
            bool isRegistryOK = true;
            try
            {
                ProductType = ((AssemblyProductAttribute[])Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false)).Single().Product.ToLower();
                clsSecurity.RegRegistryName = "Software\\52465123-sys\\456465465461312313111321";

                #region Select Product type
                if (ProductType == "epack")
                {
                    clsSecurity.RegRegistryName += "1212";
                    sProductName = "SEACC ERP - epack";
                }
                else if (ProductType == "epackt")
                {
                    clsSecurity.RegRegistryName += "1212t";
                    clsConfig.bIsTestLabelVisibleInMainForm = true;
                    sProductName = "SEACC ERP - epackt";
                }
                else if (ProductType == "epackn2")
                {
                    clsSecurity.RegRegistryName += "1212n";
                    sProductName = "SEACC ERP - epackn2";
                }
                else if (ProductType == "crystal")
                {
                    clsSecurity.RegRegistryName += "1213";
                    sProductName = "SEACC ERP - crystal";
                }
                else if (ProductType == "crystalt")
                {
                    clsSecurity.RegRegistryName += "1213t";
                    clsConfig.bIsTestLabelVisibleInMainForm = true;
                    sProductName = "SEACC ERP - crystalt";
                }
                else if (ProductType == "crystaln2")
                {
                    clsSecurity.RegRegistryName += "1213n";
                    sProductName = "SEACC ERP - crystaln2";
                }
                else if (ProductType == "chemical")
                {
                    clsSecurity.RegRegistryName += "1215";
                    sProductName = "SEACC ERP - chemical";
                }
                else if (ProductType == "chemicalt")
                {
                    clsSecurity.RegRegistryName += "1215t";
                    clsConfig.bIsTestLabelVisibleInMainForm = true;
                    sProductName = "SEACC ERP - chemicalt";
                }
                else if (ProductType == "hrcm")
                {
                    clsSecurity.RegRegistryName += "1216";
                    sProductName = "SEACC HRCM - hrcm";
                    sProductActivationConfig_ID = "7";
                }
                else if (ProductType == "hrcmt")
                {
                    clsSecurity.RegRegistryName += "1216t";
                    sProductName = "SEACC HRCM - hrcmt";
                    sProductActivationConfig_ID = "7";
                }
                else if (ProductType == "pvc")
                {
                    clsSecurity.RegRegistryName += "1214";
                    sProductName = "SEACC - pvc";
                }
                #endregion

                if (!clsSecurity.CheckRegName())
                {
                    SEACCMessageBox.Show(MessegeBoxType.RegistryError);
                    isRegistryOK = false;
                }
            }
            catch (Exception ex)
            {
                isRegistryOK = false;
                clsValidation.WriteErrorLog(ex.Message, 0);
                SEACCMessageBox.Show(MessegeBoxType.RegistryError);
            }

            return isRegistryOK;
        }

        private bool GetConnectionInformation()
        {
            bool status = false;
            if (clsSecurity.setRegistryValue())
            {
                DBHandling.DBConnection = "user id=" + clsSecurity.DB_UserName + ";password=" + clsSecurity.DB_Password + ";data source=" + clsSecurity.DB_Server + ";persist security info=true;initial catalog=" + clsSecurity.DB_Database;
                status = true;
            }
            return status;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (CheckValidityRegistry())
            {
                if (GetConnectionInformation())
                {
                    validationStatus = 1;
                    ClearField();
                }
            }
            if (validationStatus != 1)
                Application.Current.Shutdown();
        }
    }
}
