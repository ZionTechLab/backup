using Digiteq.Transaction_Forms.ACC.Tools_And_Views;
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
    public partial class frm_AccountsTools : MettroForm
    {
        #region Class Variables
        public int iFormID;
        public bool bNoAccess;
        #endregion

        public frm_AccountsTools()
        {
            InitializeComponent();
            iFormID = clsSecurity.getFormID(FormName.accAccountTool);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;
        }

        private void btnChangeChqDate_Click(object sender, EventArgs e)
        {
            frm_accChequeDateChangeTool frm = new frm_accChequeDateChangeTool();
            frm.ShowDialog();
        }
    }
}
