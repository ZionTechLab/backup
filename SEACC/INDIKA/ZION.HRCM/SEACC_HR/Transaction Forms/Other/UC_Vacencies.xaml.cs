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
    /// Interaction logic for UC_Vacencies.xaml
    /// </summary>
    public partial class UC_Vacencies : UserControl
    {
        #region class Variable
        DataTable dt = new DataTable();
        #endregion

        #region Form Load
        public UC_Vacencies()
        {
            #region Initialize UserControl
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Vacancy;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Data Table
            dt.Columns.Add("VacentCode");
            dt.Columns.Add("vacentType");
            dt.Columns.Add("ExpDate");
            dt.Columns.Add("Country");
            dt.Columns.Add("Province");
            dt.Columns.Add("District");
            dt.Columns.Add("City");
            dt.Columns.Add("Division");
            dt.Columns.Add("Department");
            dt.Columns.Add("Section");
            dt.Columns.Add("Designation");
            dt.Columns.Add("ExprienceYears");
            dt.Columns.Add("JoinDate");
            dt.Columns.Add("Email");
            dt.Columns.Add("Address");
            #endregion

            #region Initialize Data Grid
            grd_Main.Add_DatagridColoumn("Code", "VacentCode", 100);
            grd_Main.Add_DatagridColoumn("Vacent Type", "vacentType", 150);
            grd_Main.Add_DatagridColoumn("Exp. Date", "ExpDate", 200);
            grd_Main.Add_DatagridColoumn("Country", "Country", 200);
            grd_Main.Add_DatagridColoumn("Province", "Province", 200);
            grd_Main.Add_DatagridColoumn("District", "District", 200);
            grd_Main.Add_DatagridColoumn("City", "City", 200);
            grd_Main.Add_DatagridColoumn("Division", "Division", 200);
            grd_Main.Add_DatagridColoumn("Department", "Department", 100);
            grd_Main.Add_DatagridColoumn("Section", "Section", 150);
            grd_Main.Add_DatagridColoumn("Designation", "Designation", 200);
            grd_Main.Add_DatagridColoumn("Exprience Years", "ExprienceYears", 200);
            grd_Main.Add_DatagridColoumn("Join Date", "JoinDate", 200);
            grd_Main.Add_DatagridColoumn("Email", "Email", 200);
            grd_Main.Add_DatagridColoumn("Address ", "Address", 200);
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
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtVacentCode, true, false, false);
          //  clsCommon.SetEnableDisable_LabelDateSelector(dtpExpDate, true);
          //  clsCommon.SetEnableDisable_LabelDateSelector(dtpjoinDate, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtvacentType, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCountry, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProvince, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCity, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDivision, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDistrict, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDepartment, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDesignation, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtExperianceYear, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEmail, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAddress1, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtJobDescription, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtJobRole, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtJobResposibility, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmployemantType, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtstatus, true, false, true);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtHiringMethode, true, false, true);

            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtVacentCode.setReadOnlyStatus(true);
                txtVacentCode.Text = "<Auto Generate>";
            }
            else
                txtVacentCode.setReadOnlyStatus(false);
        }
        #endregion  
    }
}
