using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for frm_forgetPassword.xaml
    /// </summary>
    public partial class frm_forgetPassword : Window
    {
        #region From Load
        public frm_forgetPassword()
        {
            InitializeComponent();

            ClearFields();
        } 
        #endregion

        #region Action Buttons
        private void ucbtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ucbtnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Cursor = Cursors.Wait;
                //MailAddress From = new MailAddress("dtqalert@digiteq.biz", "Digiteq Time Management System");
                //MailMessage message = new MailMessage();
                //message.IsBodyHtml = true;
                //message.From = From;


                //MailAddress to = new MailAddress("pd_engineer1@digiteq.biz");
                //message.To.Add(to);


                //message.Subject = "Test Mail Service";
                //message.Body = "<p>This is Test Email.Hcm Evaluation Only</P> ";

                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com";
                //smtp.Port = 25;
                //smtp.EnableSsl = true;
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp.UseDefaultCredentials = false;
                //smtp.Credentials = new NetworkCredential(From.Address, "d1g1t3q@@@");

                ////foreach (String sFilpath in sFilePaths)
                ////{
                ////    Attachment att = new Attachment(sFilpath);
                ////    message.Attachments.Add(att);
                ////}

                //smtp.Send(message);
                ////if (bShowMessage)
                //System.Windows.Forms.MessageBox.Show("Email sent successfully!");

                ////bSuccess = true;

                //try
                //{
                //    message.Dispose();
                //}
                //catch (Exception ex)
                //{
                //    System.Windows.Forms.MessageBox.Show(ex.Message, "Memory Dispose Problome", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                //}

                //Cursor = Cursors.IBeam;

                if (CheckValidity_EmptyField())
                {
                    clsAlerts_Email.CreateEmail_ForgotPassword(txtYourName.Text, txtEmployeeID.Text, txtDepatment.Text, txtDesignation.Text, txtEmailAddress.Text, txtMobileNo.Text);
                    SEACCMessageBox.Show("", "Email sent successfully!", MessageBoxButton.OK);
                    ClearFields();

                }
                else
                    SEACCMessageBox.Show("Error", "Fill All Data", MessageBoxButton.OK);
            }


            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
                //bSuccess = false;
                //if (bShowMessage)
                //    System.Windows.Forms.MessageBox.Show("Failed to send message because " + ex.Message);
            }
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        #region Mouse Event

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
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

        #region Titlebar Click Event
        private void Window_Closed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PART_CLOSE_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PART_MAXIMIZE_RESTORE_Click(object sender, RoutedEventArgs e)
        {

        }       

        private void  PART_MINIMIZE_Click(object sender, RoutedEventArgs e)
        {

            
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Minimized;
            }
            else
            {
               // this.WindowState = System.Windows.WindowState.Normal;
            }
        }
        #endregion

        #region Search Events
        private void txtEmployeeID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtEmployeeID.Text = lstResult[0];
                string sEmpNI = lstResult[0].ToString();
                fillDetails(sEmpNI);
            }
        } 
        #endregion

        //frmSearch RowDataSearch = new frmSearch();
        //    List<string> lstResult = RowDataSearch.Show(Search.Banks);
        //    if (RowDataSearch.DialogResult == true)
        //    {
        //        txtBankCode.Text = clsRef_Name.get_Bank_Name(lstResult[0]);
        //        txtBankCode.Tag = lstResult[0];
        //    }
    }
}
