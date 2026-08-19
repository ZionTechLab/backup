using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class frm_pmsExtraHours : Form
    {

        #region Variables
        //to manage update and insert
        static bool IsUpdate = false, bNoAccess = false;
        public string sMachineName = "", sOperatorName = "", sStartDate = "", sEndDate = "",
              sWipID = "", sPrePlanID = "", sSectionID = "", sMachineID = "";
        public int iSeduleLineNo = 0, iSectionOrderNo = 0;


        //form manage
        string sFormConfigCode;
           public int iFormID;

        //for security handle       
        #endregion

        #region Form Load
        public frm_pmsExtraHours()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.OffcutEntry);
            iFormID = clsSecurity.getFormID(FormName.OffcutEntry);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_pmsOffcutEntry_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Extra Hours ", 3, iFormID);
            txtMachine.Text = sMachineName ;
            txtOperator.Text = sOperatorName ;
            txtStartDate.Text = sStartDate;
            txtEndDate.Text = sEndDate;

            ClearFields();
            LoadOldData();
            //format Form
            
        } 
        #endregion

        
        #region Btn New
        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearFields();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_pmsWorkInProgress_Machine_Shedule Shedule = tbl_pmsWorkInProgress_Machine_Shedule.Select(iSeduleLineNo, sWipID, iSectionOrderNo, sPrePlanID, sSectionID, sMachineID);
                if (Shedule != null)
                {

                    if (txtIddle.Text.Length > 0 && txtIddleMin.Text.Length > 0 && txtMaintenance.Text.Length > 0 && txtMaintenanceMin.Text.Length > 0 && txtLabours.Text.Length > 0 
                        && txtLaboursMin.Text.Length > 0 && txtCleaning.Text.Length > 0 && txtCleaningMin.Text.Length > 0 && txtApproval.Text.Length > 0
                        && txtApprovalMin.Text.Length > 0 && txtPowerAirEtc.Text.Length > 0 && txtPowerAirEtcMin.Text.Length > 0 && txtJobSetting.Text.Length > 0 
                        && txtJobSettingMin.Text.Length > 0 && txtJobRunning.Text.Length > 0 && txtJobRunningMin.Text.Length > 0)
                    {
                        Shedule.ExtraHours_iddle = decimal.Parse(txtIddle.Text + "." + txtIddleMin.Text);
                        Shedule.ExtraHours_Maintenance = decimal.Parse((txtMaintenance.Text + "." + txtMaintenanceMin.Text).ToString().Trim());
                        Shedule.ExtraHours_Labours = decimal.Parse((txtLabours.Text + "." + txtLaboursMin.Text).ToString().Trim());
                        Shedule.ExtraHours_Cleaning = decimal.Parse((txtCleaning.Text + "." + txtCleaningMin.Text).ToString().Trim());
                        Shedule.ExtraHours_Approval = decimal.Parse((txtApproval.Text + "." + txtApprovalMin.Text).ToString().Trim());
                        Shedule.ExtraHours_Powe_Air_etc = decimal.Parse((txtPowerAirEtc.Text + "." + txtPowerAirEtcMin.Text).ToString().Trim());
                        Shedule.ExtraHours_JobSetting = decimal.Parse((txtJobSetting.Text + "." + txtJobSettingMin.Text).ToString().Trim());
                        Shedule.ExtraHours_JobRunning = decimal.Parse((txtJobRunning.Text + "." + txtJobRunningMin.Text).ToString().Trim());
                        Shedule.CutbackSize = decimal.Parse(txtCutbackSize.Text);
                        Shedule.Update();
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); 
                    }
                    else
                        MessageBox.Show("", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveCancel), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        #endregion
        
        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;   
           
            txtIddle.Text = "00";
            txtMaintenance.Text = "00";
            txtLabours.Text = "00";
            txtCleaning.Text = "00";
            txtApproval.Text = "00";
            txtPowerAirEtc.Text = "00";
            txtJobSetting.Text = "00";
            txtJobRunning.Text = "00";
            txtCutbackSize.Text = "00";

            txtIddleMin.Text = "00";
            txtMaintenanceMin.Text = "00";
            txtLaboursMin.Text = "00";
            txtCleaningMin.Text = "00";
            txtApprovalMin.Text = "00";
            txtPowerAirEtcMin.Text = "00";
            txtJobSettingMin.Text = "00";
            txtJobRunningMin.Text = "00";

            txtIddleMin.ForeColor = Color.Black;
            txtMaintenanceMin.ForeColor = Color.Black;
            txtLaboursMin.ForeColor = Color.Black;
            txtCleaningMin.ForeColor = Color.Black;
            txtApprovalMin.ForeColor = Color.Black;
            txtPowerAirEtcMin.ForeColor = Color.Black;
            txtJobSettingMin.ForeColor = Color.Black;
            txtJobRunningMin.ForeColor = Color.Black;
          


        }
        #endregion

        #region Fill Datagrid
        private void LoadOldData()
        {
            tbl_pmsWorkInProgress_Machine_Shedule Shedule = tbl_pmsWorkInProgress_Machine_Shedule.Select(iSeduleLineNo, sWipID, iSectionOrderNo, sPrePlanID, sSectionID, sMachineID);
            if (Shedule != null)
            {
               
                try
                {
                    string[] oIddle = null, oMaintenance = null, oLabours = null, oCleaning = null, oApproval = null, oPowe_Air_etc = null, oJobSetting = null, oJobRunning=null;

                    if (Shedule.ExtraHours_iddle.ToString().Contains('.'))
                    {
                        oIddle = Shedule.ExtraHours_iddle.ToString().Split('.');
                    }
                    if (Shedule.ExtraHours_Maintenance.ToString().Contains('.'))
                    {
                        oMaintenance = Shedule.ExtraHours_Maintenance.ToString().Split('.'); 
                    }
                    if (Shedule.ExtraHours_Labours.ToString().Contains('.'))
                    {
                        oLabours = Shedule.ExtraHours_Labours.ToString().Split('.'); 
                    }
                    if (Shedule.ExtraHours_Cleaning.ToString().Contains('.'))
                    {
                       oCleaning = Shedule.ExtraHours_Cleaning.ToString().Split('.'); 
                    }
                    if (Shedule.ExtraHours_Approval.ToString().Contains('.'))
                    {
                       oApproval = Shedule.ExtraHours_Approval.ToString().Split('.'); 
                    }
                    if (Shedule.ExtraHours_Powe_Air_etc.ToString().Contains('.'))
                    {
                        oPowe_Air_etc = Shedule.ExtraHours_Powe_Air_etc.ToString().Split('.'); 
                    }
                    if (Shedule.ExtraHours_JobSetting.ToString().Contains('.'))
                    {
                        oJobSetting = Shedule.ExtraHours_JobSetting.ToString().Split('.'); 
                    }
                    if (Shedule.ExtraHours_JobRunning.ToString().Contains('.'))
                    {
                        oJobRunning = Shedule.ExtraHours_JobRunning.ToString().Split('.'); 
                    }

                    if (oIddle != null && oMaintenance != null && oLabours != null && oCleaning != null && oApproval != null && oPowe_Air_etc != null && oJobSetting != null && oJobRunning !=null)
                    {
                        txtIddle.Text = oIddle[0];
                        txtMaintenance.Text = oMaintenance[0];
                        txtLabours.Text = oLabours[0];
                        txtCleaning.Text = oCleaning[0];
                        txtApproval.Text = oApproval[0];
                        txtPowerAirEtc.Text = oPowe_Air_etc[0];
                        txtJobSetting.Text = oJobSetting[0];
                        txtJobRunning.Text = oJobRunning[0];

                        txtIddleMin.Text = oIddle[1];
                        txtMaintenanceMin.Text = oMaintenance[1];
                        txtLaboursMin.Text = oLabours[1];
                        txtCleaningMin.Text = oCleaning[1];
                        txtApprovalMin.Text = oApproval[1];
                        txtPowerAirEtcMin.Text = oPowe_Air_etc[1];
                        txtJobSettingMin.Text = oJobSetting[1];
                        txtJobRunningMin.Text = oJobRunning[1]; 
                    }

                    
                    txtCutbackSize.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(Shedule.CutbackSize);
                   // txtIddle.Text = decimal.Parse(TimeSpan.Parse(Shedule.ExtraHours_iddle.ToString()).TotalHours);

                 
                }
                catch (Exception ex)
                {
                      MessageBox.Show(ex.Message, clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                   
                }
            }
        } 
        #endregion

        #region Validation
        #region Validate Minutes
        private void ValidateMinutes(ref TextBox oTextBox)
        {
            if (oTextBox.Text.Length > 0)
            {
                if (decimal.Parse(oTextBox.Text.ToString().Trim()) > 59 || oTextBox.Text.ToString().Length > 2)
                {
                    oTextBox.Text = "00";
                    oTextBox.ForeColor = Color.Red;
                }              
                else
                    oTextBox.ForeColor = Color.Black;
            }
        }
        #endregion
        #region Validate Hour
        private void ValidateHour(ref TextBox oTextBox)
        {
            if (oTextBox.Text.Length > 0)
            {
                if (decimal.Parse(oTextBox.Text.ToString().Trim()) > 12)
                {
                    oTextBox.Text = "00";
                    oTextBox.ForeColor = Color.Red;
                }
                else
                    oTextBox.ForeColor = Color.Black;
            }

        }
        #endregion
        #region Validate Minutes To TwoDigites
        private void ValidateMinutesToTwoDigites(ref TextBox oTextBox)
        {
            if (oTextBox.Text.Length < 2)
            {
                oTextBox.Text = "0" + oTextBox.Text;
            }
        }
        #endregion
        #endregion



        #region Events KeyUp 
        private void txtIddleMin_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateMinutes(ref txtIddleMin);
        }

        private void txtMaintenanceMin_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateMinutes(ref txtMaintenanceMin);
        }

        private void txtLaboursMin_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateMinutes(ref txtLaboursMin);
        }

        private void txtCleaningMin_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateMinutes(ref txtCleaningMin);
        }

        private void txtApprovalMin_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateMinutes(ref txtApprovalMin);
        }

        private void txtPowerAirEtcMin_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateMinutes(ref txtPowerAirEtcMin);
        }

        private void txtJobSettingMin_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateMinutes(ref txtJobSettingMin);
        }

        private void txtJobRunningMin_KeyUp(object sender, KeyEventArgs e)
        {
            ValidateMinutes(ref txtJobRunningMin);
        }

        private void frm_pmsExtraHours_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Event Text Leave
        private void txtIddleMin_Leave(object sender, EventArgs e)
        {
            ValidateMinutesToTwoDigites(ref txtIddleMin);
        }

        private void txtMaintenanceMin_Leave(object sender, EventArgs e)
        {
            ValidateMinutesToTwoDigites(ref txtMaintenanceMin);
        }

        private void txtLaboursMin_Leave(object sender, EventArgs e)
        {
            ValidateMinutesToTwoDigites(ref txtLaboursMin);
        }

        private void txtCleaningMin_Leave(object sender, EventArgs e)
        {
            ValidateMinutesToTwoDigites(ref txtCleaningMin);
        }

        private void txtApprovalMin_Leave(object sender, EventArgs e)
        {
            ValidateMinutesToTwoDigites(ref txtApprovalMin);
        }

        private void txtPowerAirEtcMin_Leave(object sender, EventArgs e)
        {
            ValidateMinutesToTwoDigites(ref txtPowerAirEtcMin);
        }

        private void txtJobSettingMin_Leave(object sender, EventArgs e)
        {
            ValidateMinutesToTwoDigites(ref txtJobSettingMin);
        }

        private void txtJobRunningMin_Leave(object sender, EventArgs e)
        {
            ValidateMinutesToTwoDigites(ref txtJobRunningMin);
        }
        #endregion

        






    }
}
