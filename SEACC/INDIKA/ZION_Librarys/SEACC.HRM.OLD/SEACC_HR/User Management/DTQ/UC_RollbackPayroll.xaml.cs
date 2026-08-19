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

namespace Digiteq.User_Management.DTQ
{
    /// <summary>
    /// Interaction logic for UC_RollbackPayroll.xaml
    /// </summary>
    public partial class UC_RollbackPayroll : UserControl
    {
        #region Form Load
        public UC_RollbackPayroll()
        {
            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.RollbackPayroll;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, false, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            #endregion

            ClearFields();
        }
        #endregion

        #region Action Buttons
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region button Click
        private void btn_Rollback_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sGroupID = txtProcessGroup.Tag.ToString();
                int iMain = int.Parse(txtMainPeriod.Tag.ToString());
                int iSub = int.Parse(txtSubPeriod.Tag.ToString());
                DateTime dtmStartDate = dtpStartDate.GetDateTime().Date;
                DateTime dtmEndDate = dtpEndDate.GetDateTime().Date;

                bool bMessegeBoxResult = SEACCMessageBox.Show("Confirmation", "Are you sure to rollback paryoll data?", MessageBoxButton.YesNo, "#FF5B6B76");
                if (bMessegeBoxResult)
                {
                    clsHelpMethods.RollBack_Payroll(sGroupID, dtmStartDate, dtmEndDate);

                    SEACCMessageBox.Show("Successfully Rollbacked", "", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtMainPeriod, false, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSubPeriod, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProcessGroup, false, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpStartDate, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpEndDate, false, false);

            txtMainPeriod.Text = "";
            txtSubPeriod.Text = "";        
            txtProcessGroup.Text = "";
           
            txtMainPeriod.Tag = null;
            txtSubPeriod.Tag = null;
            txtProcessGroup.Tag = null;

            dtpStartDate.SetTime(DateTime.Now);
            dtpEndDate.SetTime(DateTime.Now);

        }
        #endregion

        #region Search Event
        private void txtMainPeriod_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void txtSubPeriod_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            bool bStatus = true;
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PayrollProcessPeriodSub);
            if (RowDataSearch.DialogResult == true)
            {
                tbl_payMas_ProcessPeriod_Sub sub = tbl_payMas_ProcessPeriod_Sub.Select(clsSecurity.CompanyID, clsSecurity.BranchID, lstResult[0], int.Parse(lstResult[2]), int.Parse(lstResult[4]));
                DateTime dtEndDate = DateTime.Now.AddMonths(-1);
                if (sub.EndDate < dtEndDate)
                {
                    if (SEACCMessageBox.Show("Do You Want to Select Previous Payroll Period?", "You selected from " + sub.StartDate.ToString("yyyy-MMM-dd") + " to " + sub.EndDate.ToString("yyyy-MMM-dd") + " period of " + txtProcessGroup.Text.Trim(), MessageBoxButton.YesNo))
                        bStatus = true;
                    else
                        bStatus = false;
                }

                if (bStatus)
                {
                    txtProcessGroup.Tag = lstResult[0];
                    txtProcessGroup.Text = lstResult[1];

                    txtMainPeriod.Tag = lstResult[2];
                    txtMainPeriod.Text = lstResult[3];

                    txtSubPeriod.Tag = lstResult[4];
                    txtSubPeriod.Text = lstResult[5];

                    dtpStartDate.SetTime(sub.StartDate);
                    dtpEndDate.SetTime(sub.EndDate);
                }
            }
        }

        private void txtProcessGroup_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }
        #endregion
    }
}
