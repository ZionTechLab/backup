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
    /// Interaction logic for UC_CompanyEvents.xaml
    /// </summary>
    public partial class UC_CompanyEvents : UserControl
    {
        #region Globle Variable
        DataTable dt = new DataTable();
        #endregion

        #region Form Load
        public UC_CompanyEvents()
        {
            #region Initialize UserControl
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Company_Event;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dt.Columns.Add("EventCode");
            dt.Columns.Add("EventCategory");
            dt.Columns.Add("Title");
            dt.Columns.Add("DateTime1");
            dt.Columns.Add("DateTime2");
            dt.Columns.Add("Country");
            dt.Columns.Add("Province");
            dt.Columns.Add("City");
            dt.Columns.Add("Town");
            dt.Columns.Add("vanue");
            #endregion

            #region Initialize Data Grid
            grd_Main.Add_DatagridColoumn("Code", "AwardCode", 100);
            grd_Main.Add_DatagridColoumn("Category", "AwardDate", 150);
            grd_Main.Add_DatagridColoumn("Title", "AwardExpDate", 200);
            grd_Main.Add_DatagridColoumn("Date Time 1", "AwardBy", 200);
            grd_Main.Add_DatagridColoumn("Date Time 2", "AwardPlace", 200);
            grd_Main.Add_DatagridColoumn("Country", "Description1", 200);
            grd_Main.Add_DatagridColoumn("Province", "Description2", 200);
            grd_Main.Add_DatagridColoumn("City", "Description3", 200);
            grd_Main.Add_DatagridColoumn("Town", "Description3", 200);
            grd_Main.Add_DatagridColoumn("Venue", "Description3", 200);
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
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEventCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEventCatg, true, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtp_DateTime1, true, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtp_DateTime2, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEventTitle, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCountry, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCity, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProvince, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTown, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtVanue, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtDocumentType, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtEventCommittee, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtEventBudject_Exp, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtEventBudget_Rev, true, false, true);
                        

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtEventCode.setReadOnlyStatus(true);
                txtEventCode.Text = "<Auto Generate>";
            }
            else
                txtEventCode.setReadOnlyStatus(false);
        }
        #endregion  
    }
}
