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
using SEACC_WPFControls;
using DataTire;
using SEACC_Tender.UserControls;
using System.Data;
using Digiteq_Logic;
using SEACC_Tender.Search_Forms;

namespace SEACC_Tender
{
    /// <summary>
    /// Interaction logic for UC_SupplierMaster.xaml
    /// </summary>
    public partial class UC_ttsMasSupplier : UserControl
    {
        DataTable dt = new DataTable();
        bool bIsItemChanged = false;
        public UC_ttsMasSupplier()
        {
            InitializeComponent();
            
            SEACC_Form.enmFormName = FormName.TenSupplierMaster;
            SEACC_Form.Initialize();

            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_New.Click += Btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += Btn_Cancel_Click;
            //this.SEACC_Form.btn_Print.Click += Btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += Btn_Save_Click;

            ClearFields();
        }

        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 880)
                ColumnA.Width = new GridLength(200);
            else
                ColumnA.Width = new GridLength(310);
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_LableTextbox(txtSupplierID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSupplierName, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSup_cls, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSup_Type, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCategory, true, false, false);

            //cls_Formater.SetEnableDisable_CheckBox(chkIsBlackListed, true);
            //cls_Formater.SetEnableDisable_CheckBox(chkIsDeactivated, true);
            //cls_Formater.SetEnableDisable_CheckBox(chkIsSuspended, true);
            chkIsBlackListed.IsChecked = false;
            chkIsSuspended.IsChecked = false;
            chkIsDeactivated.IsChecked = false;

            cls_Formater.SetEnableDisable_LableTextbox(txtAccountCode, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAccountType, true, false, false);
            
            //Accounts Details
            cls_Formater.SetEnableDisable_LableTextbox(txtBalance, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtBussRegNo, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtCodeLink, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCurrency, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCredit_limit, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCredit_period, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDel_Address, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDep_amnt, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtNBTRegNo, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSVATRegNo, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtVATRegNo, true, false, false);

            //cls_Formater.SetEnableDisable_CheckBox(chkNBT, true);
            //cls_Formater.SetEnableDisable_RadioButttons(rdoVAT, true);
            //cls_Formater.SetEnableDisable_RadioButttons(rdoSVAT, true);
            chkNBT.IsChecked = false;
            rdoVAT.IsChecked = false;
            rdoSVAT.IsChecked = false;

            //General Detaiils
            cls_Formater.SetEnableDisable_LableTextbox(txtArea, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCity, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCountry, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDistrict, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEmail, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtMobi, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFax, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRoute, true, false, false);            
            cls_Formater.SetEnableDisable_LableTextbox(txtTel, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTown, true, false, false);           
            cls_Formater.SetEnableDisable_LableTextbox(txtWeb_URL, true, false, false);

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProvince, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtReg_Address, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, false);

            
            

        }

        private void txtCountry_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Country);
            if (RowDataSearch.DialogResult == true)
            {
                txtCountry.Tag = lstResult[0];
                txtCountry.Text = lstResult[1];

            }
        }

        private void txtProvince_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Province);
            if (RowDataSearch.DialogResult == true)
            {
                txtCity.Tag = lstResult[0];
                txtCity.Text = lstResult[1];
                txtCountry.Tag = lstResult[6];
                txtCountry.Text = lstResult[7];
            }
        }

        private void txtDistrict_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.District);
            if (RowDataSearch.DialogResult == true)
            {
                txtCity.Tag = lstResult[0];
                txtCity.Text = lstResult[1];
                txtCountry.Tag = lstResult[6];
                txtCountry.Text = lstResult[7];
            }
        }

        private void txtCity_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.City);
            if (RowDataSearch.DialogResult == true)
            {
                txtCity.Tag = lstResult[0];
                txtCity.Text = lstResult[1];
                txtCountry.Tag = lstResult[6];
                txtCountry.Text = lstResult[7];
            }
        }

        private void txtTown_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Town);
            if (RowDataSearch.DialogResult == true)
            {
                txtTown.Tag = lstResult[0];
                txtTown.Text = lstResult[1];
            }
        }

        private void btnUploadImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            dlg.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphic (*.png)|*.png";
            if (result == true)
            {
                bIsItemChanged = true;
                string filename = dlg.FileName;
                //txtUpload.Text = filename;
            }
        }

        
    }
}
