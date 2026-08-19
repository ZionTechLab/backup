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
    /// Interaction logic for UC_CompanyAwardsAndCeritificates.xaml
    /// </summary>
    public partial class UC_CompanyAwardsAndCeritificates : UserControl
    {
        #region Class Variable
        DataTable dt = new DataTable();
        #endregion

        #region Form Load
        public UC_CompanyAwardsAndCeritificates()
        {
            #region Initialize UserControl
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Company_Awards_And_Certification;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dt.Columns.Add("AwardCode");
            dt.Columns.Add("AwardDate");
            dt.Columns.Add("AwardExpDate");
            dt.Columns.Add("AwardBy");
            dt.Columns.Add("AwardPlace");
            dt.Columns.Add("Description1");
            dt.Columns.Add("Description2");
            dt.Columns.Add("Description3");
            #endregion

            #region Initialize Data Grid
            grd_Main.Add_DatagridColoumn("Code", "AwardCode", 100);
            grd_Main.Add_DatagridColoumn("Award Date", "AwardDate", 150);
            grd_Main.Add_DatagridColoumn("Expiry Date", "AwardExpDate", 200);
            grd_Main.Add_DatagridColoumn("Award By", "AwardBy", 200);
            grd_Main.Add_DatagridColoumn("Place", "AwardPlace", 200);
            grd_Main.Add_DatagridColoumn("Description 1", "Description1", 200);
            grd_Main.Add_DatagridColoumn("Description 2", "Description2", 200);
            grd_Main.Add_DatagridColoumn("Description 3", "Description3", 200);
            #endregion

            ClearFields();
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
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAwardCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAwardBy, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAwardPlace, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtDescription1, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDescription2, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDescription3, true, false, true);
            // clsCommon.SetEnableDisable_LabelDateSelector(dtpAwardDate, true);
            //  clsCommon.SetEnableDisable_LabelDateSelector(dtpAwardExpDate, true);


            txtAwardCode.Text = "";
            txtAwardCode.Tag = null;
            txtAwardPlace.Text = "";
            txtAwardBy.Text = "";
            txtDescription1.Text = "";
            txtDescription2.Text = "";
            txtDescription3.Text = "";

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtAwardCode.setReadOnlyStatus(true);
                txtAwardCode.Text = "<Auto Generate>";
            }
            else
                txtAwardCode.setReadOnlyStatus(false);
        }
        #endregion
    }
}
