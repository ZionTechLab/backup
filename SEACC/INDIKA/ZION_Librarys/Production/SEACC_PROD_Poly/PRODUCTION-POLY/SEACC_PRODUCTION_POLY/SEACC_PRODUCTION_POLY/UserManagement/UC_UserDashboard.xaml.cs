using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SEACC_PRODUCTION_POLY.UserManagement
{
    /// <summary>
    /// Interaction logic for UC_UserDashboard.xaml
    /// </summary>
    public partial class UC_UserDashboard : UserControl
    {
        public UC_UserDashboard()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.Prod_UserDashBoard;
            SEACC_Form.Initialize();

            #region Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, false, false, false, false);
            SEACC_Form.btn_New.Click += btn_New_Click;
            #endregion

            ClearFields();
            RefreshChart();
        }

        private void ClearFields()
        {
            cp_password.ClearField();
            cp_pin.ClearField();

            cp_pin.tbTitle.Text = "Change PIN";
            cp_pin.lblCurrentPassword.Content = "Current PIN";
            cp_pin.lblNewPassword.Content = "New PIN";
            cp_pin.lblNewPassword_Confirm.Content = "Confirm PIN";

            cp_pin.txtPassword.MaxLength = 4; //PIN Length
            cp_pin.txtPassword2.MaxLength = 4; //PIN Length
        }

        public void RefreshChart()
        {
            List<KeyValuePair<string, int>> kvpList_forPiChart = new List<KeyValuePair<string, int>>();
            foreach (prod_JobStatus job_Status in Enum.GetValues(typeof(prod_JobStatus)))
            {
                kvpList_forPiChart.Insert((int)job_Status, new KeyValuePair<string, int>(
                    (Attribute.GetCustomAttribute(job_Status.GetType().GetField(job_Status.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description
                    , tbl_prod_polyTxJobCard.SelectAll().Where(r => r.ProdJobStatus == (int)job_Status).Count()));
            }
            ((PieSeries)mcChart.Series[0]).ItemsSource = kvpList_forPiChart;
        }

        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void cp_password_BtnApplyClick(object sender, EventArgs e)
        {
            string UserID = clsSecurity.UserIDLoged;
            if (UserID != null)
            {
                tbl_securityUserMaster oSecurityUser = tbl_securityUserMaster.Select(UserID);
                if (oSecurityUser != null)
                {
                    if (cp_password.txtPassword.Password.Length >= 8)
                    {
                        if ((clsSecurity.decryptPassword(oSecurityUser.Password) == cp_password.txtCurrentPassword.Password))
                        {
                            if (cp_password.txtPassword.Password == cp_password.txtPassword2.Password)
                            {
                                oSecurityUser.Password = clsSecurity.encryptPassword(cp_password.txtPassword.Password);
                                oSecurityUser.Update();
                                //clsAlerts_Email.CreateEmail_ChangedPassword(oSecurityUser.User_ID, txtPassword.Password);
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Changed);
                                ClearFields();
                            }
                            else
                            {
                                SEACCMessageBox.Show(MessegeBoxType.PasswordsNotMatched);
                            }
                        }
                        else
                        {
                            SEACCMessageBox.Show("Oops", "Current Password is Wrong !", MessageBoxButton.OK , "Red");
                        }
                    }
                    else
                    {
                        SEACCMessageBox.Show("Password must be at least 8 digits", "", MessageBoxButton.OK, "Red");
                    }
                }
            }
        }

        private void cp_pin_BtnApplyClick(object sender, EventArgs e)
        {
            string UserID = clsSecurity.UserIDLoged;
            if (UserID != null)
            {
                tbl_securityUserMaster oSecurityUser = tbl_securityUserMaster.Select(UserID);
                if (oSecurityUser != null)
                {
                    if (cp_pin.txtPassword.Password.Length == 4)
                    {
                        if ((clsSecurity.decryptPassword(oSecurityUser.Password2) == cp_pin.txtCurrentPassword.Password))
                        {
                            if (cp_pin.txtPassword.Password == cp_pin.txtPassword2.Password)
                            {
                                oSecurityUser.Password2 = clsSecurity.encryptPassword(cp_pin.txtPassword.Password);
                                oSecurityUser.Update();
                                //clsAlerts_Email.CreateEmail_ChangedPassword(oSecurityUser.User_ID, txtPassword.Password);
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Changed);
                                ClearFields();
                            }
                            else
                            {
                                SEACCMessageBox.Show(MessegeBoxType.PasswordsNotMatched);
                            }
                        }
                        else
                        {
                            SEACCMessageBox.Show("Current PIN is Wrong !", "", MessageBoxButton.OK, "Red");
                        }
                    }
                    else
                    {
                        SEACCMessageBox.Show("PIN must be included 4 digits", "", MessageBoxButton.OK, "Red");
                    }
                }
            }
        }



    }
}
