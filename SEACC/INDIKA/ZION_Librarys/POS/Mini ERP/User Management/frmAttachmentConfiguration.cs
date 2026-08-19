using DataTire;
using Digiteq_Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frmAttachmentConfiguration : SEACC_Form
    {
        public frmAttachmentConfiguration(FormName _enmForm)
        {
            enmForm = _enmForm;
            InitializeComponent(); 
            Initialize();
        }

        private void frmAttachmentConfiguration_Load(object sender, EventArgs e)
        {
            SetVisibility_ActionButons(false, false, false, true, false, false, false, false, false);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowNewFolderButton = true;
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtTargetPath.Text = folderBrowserDialog1.SelectedPath;
                Environment.SpecialFolder root = folderBrowserDialog1.RootFolder;
            }
        }

        private void frmAttachmentConfiguration_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (txtTargetPath.Text != "" && txtTargetPath.TextLength > 0)
            {
                clsConfig.sAttachmentPath_Server = txtTargetPath.Text;

                clsSecurity.SetCofigValue(251, clsConfig.sAttachmentPath_Server);
                clsConfig.accType_InterCompany = clsConfig.sAttachmentPath_Server;
                  MessageBox.Show("Settings Saved Succesfully", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                //tbl_securityConfigValue oConfig = tbl_securityConfigValue.Select(251);
                //if (oConfig != null)
                //{
                //    oConfig.ConfigValue = clsConfig.sAttachmentPath_Server;
                //    oConfig.Update();

                //    MessageBox.Show("Settings Saved Succesfully", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
        }
    }
}
