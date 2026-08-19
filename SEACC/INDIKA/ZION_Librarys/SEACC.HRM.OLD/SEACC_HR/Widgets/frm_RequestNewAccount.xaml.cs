using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
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
using System.Windows.Shapes;

namespace Digiteq.Widgets
{
    /// <summary>
    /// Interaction logic for frm_RequestNewAccount.xaml
    /// </summary>
    public partial class frm_RequestNewAccount : Window
    {
        #region Form Load
        public frm_RequestNewAccount()
        {
            InitializeComponent();
        } 
        #endregion

        #region Action Buttons
        private void ucbtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ucbtnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CheckValidity_EmptyField())
                {
                    clsAlerts_Email.CreateEmail_RequestAccount(txtYourName.Text, txtEmployeeID.Text, txtDepatment.Text, txtDesignation.Text, txtEmailAddress.Text, txtMobileNo.Text);
                    SEACCMessageBox.Show("", "Email sent successfully!", MessageBoxButton.OK);
                    ClearFields();

                }
                else
                    SEACCMessageBox.Show("Error", "Fill All Data", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            cls_Formater.SetEnableDisable_LableTextbox(txtYourName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEmployeeID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDepatment, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDesignation, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEmailAddress, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtMobileNo, true, false, false);

            txtYourName.Text = "";
            txtEmployeeID.Text = "";
            txtDepatment.Text = "";
            txtDesignation.Text = "";
            txtEmailAddress.Text = "";
            txtMobileNo.Text = "";
        }
        #endregion

        #region Check validity
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;
            if (!clsValidation.Validate_EmptyValue(txtYourName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtEmployeeID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtDepatment))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtDesignation))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtEmailAddress))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtMobileNo))
                bStatus = false;

            return bStatus;
        }
        #endregion

        #region Fill Data
        private void fillDetails(string sID)
        {
            try
            {
                tbl_genMasEmployee detail = tbl_genMasEmployee.Select(sID, clsSecurity.CompanyID, clsSecurity.BranchID);
                if (detail != null)
                {
                    txtYourName.Text = detail.FullName;
                    txtEmployeeID.Text = detail.Employee_ID;
                    txtDepatment.Text = clsRef_Name.get_Department_Name(detail.Department_ID);
                    txtDesignation.Text = clsRef_Name.get_Designation_Name(detail.Designation_ID);
                    txtEmailAddress.Text = detail.Email;
                    txtMobileNo.Text = detail.Mobile_Office;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Mouse Event
        private void Grid_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
           this.DragMove();
        } 
        #endregion  
    }
}
