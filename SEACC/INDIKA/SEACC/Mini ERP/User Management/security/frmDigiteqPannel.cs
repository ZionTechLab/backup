using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using Digiteq.Master_Forms;
using System.IO;
using Digiteq.User_Management;
using Digiteq.Transaction_Forms.ACC;
using Digiteq.Transaction_Forms.ACC.Tools_And_Views;

namespace Digiteq
{
    public partial class frmDigiteqPannel : Form
    {
        clsAlerts_Email email = new clsAlerts_Email();
        public frmDigiteqPannel()
        {
            InitializeComponent();
        }

        private void btnAutoNumber_Click(object sender, EventArgs e)
        {
            frmAutoFormNumber frm = new frmAutoFormNumber();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        #region Form Category
        private void btnCategory_Click(object sender, EventArgs e)
        {
            frmFormCategory frm = new frmFormCategory();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
        #endregion

        #region Form Master
        private void btnFormMaster_Click(object sender, EventArgs e)
        {
            frmForm frm = new frmForm();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
        #endregion
        
        private void btnUserPermission_Click(object sender, EventArgs e)
        {
            frmUserPermission frm = new frmUserPermission();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
        
        private void btnReportMaster_Click(object sender, EventArgs e)
        {
            frmReportMaster frm = new frmReportMaster();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        } 

        private void btnConfigStatus_Click(object sender, EventArgs e)
        {
            frm_securityConfigStatus frm = new frm_securityConfigStatus();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnConfigValues_Click(object sender, EventArgs e)
        {
            frm_securityConfigValue frm = new frm_securityConfigValue();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnTypes_Status_Click(object sender, EventArgs e)
        {
            frm_securityConfigStatusType frm = new frm_securityConfigStatusType();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnTypes_Value_Click(object sender, EventArgs e)
        {
            frm_securityConfigTypeValue frm = new frm_securityConfigTypeValue();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnTool1_Click(object sender, EventArgs e)
        {
            frm_ToolUpdateOldestInvoiceDate frm = new frm_ToolUpdateOldestInvoiceDate();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnRecordUnlock_Click(object sender, EventArgs e)
        {
            frm_toolUnlockRecode frm = new frm_toolUnlockRecode();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnUnsettle_Click(object sender, EventArgs e)
        {
            frm_toolUnsetteldRecode frm = new frm_toolUnsetteldRecode();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnPrintUnlock_Click(object sender, EventArgs e)
        {
            frm_toolUnlockRecode frm = new frm_toolUnlockRecode();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnChequeToDepositeMode_Click(object sender, EventArgs e)
        {
            frm_toolCheckToDepositeMode frm = new frm_toolCheckToDepositeMode();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnConfigValuesQuick_Click(object sender, EventArgs e)
        {
            //   frmSetConfigValues frm = new frmSetConfigValues();
            //  frm.MdiParent = this.MdiParent;
            //  frm.Show();
        }

        private void btnDateSetting_Click(object sender, EventArgs e)
        {
            frmDateSettings frm = new frmDateSettings();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            frm_toolDemo frm = new frm_toolDemo();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnUpdateReportMaster_Click(object sender, EventArgs e)
        {
            frm_toolSetReportMaster frm = new frm_toolSetReportMaster();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnReplaceDefaultValue_Click(object sender, EventArgs e)
        {
            frm_toolReplaceDefaultValuesAllMaster frm = new frm_toolReplaceDefaultValuesAllMaster();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnUpdateFormMaster_Click(object sender, EventArgs e)
        {
            frm_toolSetFormMaster frm = new frm_toolSetFormMaster();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnRemoveSettledRecords_Click(object sender, EventArgs e)
        {
            frm_toolRecordPurge frm = new frm_toolRecordPurge();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnChequeToNewMode_Click(object sender, EventArgs e)
        {
            frm_toolChequeToNewMode frm = new frm_toolChequeToNewMode();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnUpdateOPBal_Click(object sender, EventArgs e)
        {
          
        }

        private void btnAlert_Click(object sender, EventArgs e)
        {
            DialogResult msgResult = MessageBox.Show("Do You Want To Send daily email alerts? ", clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (msgResult == DialogResult.Yes)
            {
          
                email.createEmail_DONotInvoiced(enum_Alerts.SheduleAlert_DONoteInvoiced, "default");
            }
        }

        //private void btnExcelImportAndExport_Click(object sender, EventArgs e)
        //{
        //    frm_toolExcelFile_ImportExport frm = new frm_toolExcelFile_ImportExport();
        //    frm.MdiParent = this.MdiParent;
        //    frm.Show();
        //}



        private void btnImageResize_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists("Images"))
                {
                    if (Directory.Exists("ImagesTemp") == false)
                        Directory.CreateDirectory("ImagesTemp");
                    string s_Path = Application.StartupPath;
                    s_Path += "\\Images";
                    DirectoryInfo mydir = new DirectoryInfo(s_Path);
                    FileInfo[] sourceFiles = mydir.GetFiles();
                    foreach (FileInfo file in sourceFiles)
                    {
                        try
                        {
                            if (!File.Exists("ImagesTemp\\" + file.Name))
                            {
                                using (FileStream fs = new FileStream(s_Path + "\\" + file.Name, FileMode.Open, FileAccess.Read))
                                {
                                    Image imggg = new Bitmap(Image.FromStream(fs), new Size(300, 300));
                                    imggg.Save("ImagesTemp\\" + file, System.Drawing.Imaging.ImageFormat.Jpeg);
                                }
                            }
                        }
                        catch { continue; }
                    }
                    MessageBox.Show("Export & Resize Is Done", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
            }
        }
        private void btnMaintainGridColumns_Click(object sender, EventArgs e)
        {
            //   frm_MaintainGridColumn frmGridMaintance = new frm_MaintainGridColumn();
            //   frmGridMaintance.Show();
        }

        private void btnUnpostedTra_Click(object sender, EventArgs e)
        {
            frm_accNotPostedTransactions frm = new frm_accNotPostedTransactions();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnUpdateAccType_Click(object sender, EventArgs e)
        {
            frm_accUpdateAccountType frm = new frm_accUpdateAccountType();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_accChequeToNewMode_PV frm = new frm_accChequeToNewMode_PV();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnCreateFinYear_Click(object sender, EventArgs e)
        {
            frm_masAccCreateFinancialYear_New frm = new frm_masAccCreateFinancialYear_New();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }

        private void btnCheckPosting_Click(object sender, EventArgs e)
        {
            frm_accCheckPosting frm = new frm_accCheckPosting();
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
    }
}