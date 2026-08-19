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

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_CarderRequest.xaml
    /// </summary>
    public partial class UC_CarderRequest : UserControl
    {
        #region Form Load
        public UC_CarderRequest()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Cadre_Request;
            SEACC_Form.Initialize(); 
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

        #region Clear Fields
        private void ClearFields()
        {
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtApprovedBudget, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAvalibleBudget, true, false, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtAvalibleBudgetAmount, true, true,false);
            cls_Formater.SetEnableDisable_LableTextbox(txtCarderRequestNo, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDepartment, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDesignation, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDivision, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtJobDescription, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtMainRole, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtReporting_Admin, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtReporting_Functional, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtRequestBy, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtResponsibility, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSalaryFrom, true, false, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtSalaryFromAmount, true, true,false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtSalaryTo, true, false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(txtSalaryToAmount, true, true,false);
            cls_Formater.SetEnableDisable_SEACCNormalTextbox(ApprovedBudgetAmount, true, true,false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSection, true, false, false);
            cls_Formater.SetEnableDisable_DatePicker(dtp_Date, true);
            cls_Formater.SetEnableDisable_DatePicker(dtp_ExpectedDate, true);
           cls_Formater.SetEnableDisable_DataGrid(grd_CarderRequest, true, "#FF41B1E1", "#FFFFFF");
        } 
        #endregion

        #region Search Events
        private void txtDepartment_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            if (RowDataSearch.DialogResult == true)
            {          
            }
        }

        private void txtSection_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Sections);
            if (RowDataSearch.DialogResult == true)
            {
                txtSection.Text = lstResult[1];
                txtSection.Tag = lstResult[0];
            }
        }

        private void txtRequestBy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                txtRequestBy.Text = lstResult[1];
                txtRequestBy.Tag = lstResult[0];
            }
        }

        private void txtDesignation_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Designations);
            if (RowDataSearch.DialogResult == true)
            {
                txtDesignation.Text = lstResult[1];
                txtDesignation.Tag = lstResult[0];
            }
        }

        private void txtReporting_Functional_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                txtReporting_Functional.Text = lstResult[1];
                txtReporting_Functional.Tag = lstResult[0];
            }
        }

        private void txtSalaryFrom_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                txtSalaryFrom.Text = lstResult[0];
                txtSalaryFrom.Tag = lstResult[1];
            }
        }

        private void txtSalaryTo_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                txtSalaryTo.Text = lstResult[0];
                txtSalaryTo.Tag = lstResult[1];
            }
        }

        private void txtAvalibleBudget_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.EnD);
            if (RowDataSearch.DialogResult == true)
            {
                txtAvalibleBudget.Text = lstResult[0];
                txtAvalibleBudget.Tag = lstResult[1];
            }
        }

        private void txtApprovedBudget_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                txtApprovedBudget.Text = lstResult[0];
                txtApprovedBudget.Tag = lstResult[1];
            }
        }

        private void txtReporting_Admin_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                txtApprovedBudget.Text = lstResult[1];
                txtApprovedBudget.Tag = lstResult[2];
            }
        } 
        #endregion
    }
}
