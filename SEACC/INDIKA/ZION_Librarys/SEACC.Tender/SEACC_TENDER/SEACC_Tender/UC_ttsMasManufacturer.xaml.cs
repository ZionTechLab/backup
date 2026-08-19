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
    /// Interaction logic for UC_ttsMasManufacturer.xaml
    /// </summary>
    public partial class UC_ttsMasManufacturer : UserControl
    {
        DataTable dt_Item = new DataTable();
        bool bIsItemChanged = false;
        public UC_ttsMasManufacturer()
        {
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.TenManufacturer;
            SEACC_Form.Initialize();

            dt_Item.Columns.Add("LineNo");
            dt_Item.Columns.Add("ItemID");
            dt_Item.Columns.Add("ItemDescription");
            dt_Item.Columns.Add("ItemSpecification");
            dt_Item.Columns.Add("ItemCategoryID");
            dt_Item.Columns.Add("ItemCategory");
            dt_Item.Columns.Add("UoMCode");
            dt_Item.Columns.Add("UoM");
            dt_Item.Columns.Add("Remarks");
            dgr_Items.ItemsSource = dt_Item.DefaultView;

            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_New.Click += Btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += Btn_Cancel_Click;
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

            cls_Formater.SetEnableDisable_LableTextbox(txtManufacturerID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtManufacturerName, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtManufacturer_cls, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtManufacturer_Type, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtManufacturer_Category, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCurrency, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDel_Address, true, false, false);

            chkIsBlackListed.IsChecked = false;
            chkIsSuspended.IsChecked = false;
            chkIsDeactivated.IsChecked = false;

            //cls_Formater.SetEnableDisable_LableTextbox(txtAccountCode, true, false, false);
            //cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAccountType, true, false, false);
            
            //Accounts Details
            //cls_Formater.SetEnableDisable_LableTextbox(txtBalance, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtBussRegNo, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtCodeLink, true, false, false);
            
            //cls_Formater.SetEnableDisable_LableTextbox(txtCredit_limit, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtCredit_period, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtDep_amnt, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtNBTRegNo, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtSVATRegNo, true, false, false);
            //cls_Formater.SetEnableDisable_LableTextbox(txtVATRegNo, true, false, false);

            //chkNBT.IsChecked = false;
            //rdoVAT.IsChecked = false;
            //rdoSVAT.IsChecked = false;

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

        #region Search
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
                txtProvince.Tag = lstResult[0];
                txtProvince.Text = lstResult[1];
            }
        }

        private void txtDistrict_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.District);
            if (RowDataSearch.DialogResult == true)
            {
                txtDistrict.Tag = lstResult[0];
                txtDistrict.Text = lstResult[1];
                txtProvince.Tag = lstResult[2];
                txtProvince.Text = lstResult[3];
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
                txtDistrict.Tag = lstResult[2];
                txtDistrict.Text = lstResult[3];
                txtProvince.Tag = lstResult[4];
                txtProvince.Text = lstResult[5];
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
                txtCity.Tag = lstResult[2];
                txtCity.Text = lstResult[3];
            }
        } 
        #endregion

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

        private void btnGridItemAdd_Click(object sender, RoutedEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResultIt = RowDataSearch.Show(Search.ItemMaster);
            if (RowDataSearch.DialogResult == true)
            {
                string sDescription = "";
                int iRow = dt_Item.Rows.Count + 1;
                tbl_genItemMaster oDetail = tbl_genItemMaster.Select(lstResultIt[0]);
                if (oDetail != null)
                {
                    sDescription = oDetail.Description;
                }

                dt_Item.Rows.Add(iRow, lstResultIt[0], lstResultIt[1], sDescription, "", "","","","");
            }
        }

        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_Items.SelectedItem;
            if (selectedItem != null)
                ((DataRowView)(dgr_Items.SelectedItem)).Row.Delete();
        }

        private void dgr_Items_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var vDgv_Cell = dgr_Items.CurrentCell;
                object item = dgr_Items.SelectedItem;

                if (vDgv_Cell.Column.Header.ToString() == "Item Category")
                {
                    frmSearch RowDataSearch = new frmSearch();
                    List<string> lstResult = RowDataSearch.Show(Search.ItemCategory);
                    if (RowDataSearch.DialogResult == true)
                    {
                        int irowID = dgr_Items.SelectedIndex;
                        dt_Item.Rows[irowID]["ItemCategoryID"] = lstResult[0];
                        dt_Item.Rows[irowID]["ItemCategory"] = lstResult[1];
                    }
                }
                else if (vDgv_Cell.Column.Header.ToString() == "UoM")
                {
                    frmSearch RowDataSearch = new frmSearch();
                    List<string> lstResult = RowDataSearch.Show(Search.UOM);
                    if (RowDataSearch.DialogResult == true)
                    {
                        int irowID = dgr_Items.SelectedIndex;
                        dt_Item.Rows[irowID]["UoM"] = lstResult[1];
                        dt_Item.Rows[irowID]["UoMCode"] = lstResult[0];
                    }
                }
            }
            catch(Exception){

            }
        }
    }
}
