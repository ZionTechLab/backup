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

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_CompanyBranchMaster.xaml
    /// </summary>
    public partial class UC_CompanyBranchMaster : UserControl
    {
        #region Class Variables
        DataTable dt; 
        #endregion

        #region Form Load
        public UC_CompanyBranchMaster()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Bank_Branch_Creation;
            SEACC_Form.Initialize();
            #endregion

            #region Initialization Data Table
            dgr_Main.dt.Columns.Add("CompanyCode");
            dgr_Main.dt.Columns.Add("BranchCode");
            dgr_Main.dt.Columns.Add("BranchName");
            dgr_Main.dt.Columns.Add("Address");
            dgr_Main.dt.Columns.Add("Telephone");
            dgr_Main.dt.Columns.Add("Fax");
            dgr_Main.dt.Columns.Add("ContectPerson");
            #endregion

            #region Initialization Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Print.Click += btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize Data Grid
            dgr_Main.Add_DatagridColoumn("Company Code", "CompanyCode", 100);
            dgr_Main.Add_DatagridColoumn("Branch Code", "BranchCode", 100);
            dgr_Main.Add_DatagridColoumn("Company Name", "BranchName", 200);
            dgr_Main.Add_DatagridColoumn("Company Address", "Address", 200);
            dgr_Main.Add_DatagridColoumn("Telephone", "Telephone", 80);
            dgr_Main.Add_DatagridColoumn("Fax", "Fax", 50);
            dgr_Main.Add_DatagridColoumn("Contect Person", "ContectPerson", 100);
            #endregion

            ClearFields();
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

        #region Action Buttons - Still not implemented any button
        void btn_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        void btn_Print_Click(object sender, RoutedEventArgs e)
        {

        }

        void btn_New_Click(object sender, RoutedEventArgs e)
        {

        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {

        } 
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtCompanyCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBranchCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtBranchname, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAddress, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtTelephone, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFax, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtContectPerson, true, false, false);

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
    }
}
