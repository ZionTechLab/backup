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
    /// Interaction logic for UC_CompanyBrands.xaml
    /// </summary>
    public partial class UC_CompanyBrands : UserControl
    {
        #region Class Variables
        DataTable dt_Main = new DataTable();
        DataTable dt = new DataTable();

        #endregion

        #region Form Load
        public UC_CompanyBrands()
        {
            #region Initialize User Control
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Company_Brands;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Tables
            dt_Main.Columns.Add("BrandCode");
            dt_Main.Columns.Add("FoundDate");
            dt_Main.Columns.Add("ExpDate");
            dt_Main.Columns.Add("FounddBy");
            dt_Main.Columns.Add("FoundPlace");
            dt_Main.Columns.Add("LaunchDate");
            dt_Main.Columns.Add("LaunchPlace");
            dt_Main.Columns.Add("Remarks");

            dt.Columns.Add("EmpNo");
            dt.Columns.Add("Name");
            #endregion

            #region Initialize Data Grid
            grd_Main.Add_DatagridColoumn("Code", "BrandCode", 100);
            grd_Main.Add_DatagridColoumn("Found Date", "FoundDate", 120);
            grd_Main.Add_DatagridColoumn("Expiry Date", "ExpDate", 120);
            grd_Main.Add_DatagridColoumn("Found By", "FounddBy", 200);
            grd_Main.Add_DatagridColoumn("Launch Date", "FoundPlace", 200);
            grd_Main.Add_DatagridColoumn("Launch Place", "LaunchDate", 120);
            grd_Main.Add_DatagridColoumn("Remarks", "Remarks", 200);
            #endregion

            ClearFields();
            RefreshGrid_Founders();
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

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBrandCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFoundBy, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtLunchPlace, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtRemarks, true, false, false);
          //  clsCommon.SetEnableDisable_LabelDateSelector(dtpBrandDate, true);
           // clsCommon.SetEnableDisable_LabelDateSelector(dtpBrandExpDate, true);
           // clsCommon.SetEnableDisable_LabelDateSelector(dtpLunchDate, true);



            txtBrandCode.Text = "";
            txtBrandCode.Tag = null;
            txtFoundBy.Text = "";
            txtLunchPlace.Text = "";
            txtRemarks.Text = "";
         

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtBrandCode.setReadOnlyStatus(true);
                txtBrandCode.Text = "<Auto Generate>";
            }
            else
                txtBrandCode.setReadOnlyStatus(false);
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid_Founders()
        {
            dt.Rows.Add("", "");

            grd_Founders.ItemsSource = dt.DefaultView;
        } 
        #endregion
    }
}
