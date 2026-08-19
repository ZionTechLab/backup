using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;


namespace Digiteq
{
    public partial class frm_Alert_Home : Form
    {
        #region Variables

        //for security handle
        public bool bNoAccess;

        //form manage
        string sFormConfigCode;
           public int iFormID;

        #endregion

        public frm_Alert_Home()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.AlertHome);
            iFormID = clsSecurity.getFormID(FormName.AlertHome);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_masFinanceMaster_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Alert Home", 2, iFormID);
        }

        #region Email Config
        private void btnEmailConfig_Click(object sender, EventArgs e)
        {
            frm_Alert_EmailConfig oFrm = new frm_Alert_EmailConfig();
            oFrm.ShowDialog();
        }
        #endregion

        #region Alert config
        private void btnUsrSetup_Click(object sender, EventArgs e)
        {
            frm_Alert_Configuration oFrm = new frm_Alert_Configuration();
            oFrm.ShowDialog();
        }
        #endregion

        #region Alert shedule
        private void btnAlertScheduling_Click(object sender, EventArgs e)
        {
            frm_AlertShedules oFrm = new frm_AlertShedules();
            oFrm.ShowDialog();
        }
        #endregion

        #region Alert master
        private void btnAlertMaster_Click(object sender, EventArgs e)
        {
            frm_AlertMaster oFrm = new frm_AlertMaster();
            oFrm.ShowDialog();
        }
        #endregion
    }
}
