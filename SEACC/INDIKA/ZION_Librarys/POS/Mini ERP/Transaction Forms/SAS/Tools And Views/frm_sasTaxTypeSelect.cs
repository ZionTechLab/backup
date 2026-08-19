using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frm_sasTaxTypeSelect : Form
    {
        public bool bCheckNBT = false, bCheckVat = false;
        public frm_sasTaxTypeSelect()
        {
            InitializeComponent();
        }
        public frm_sasTaxTypeSelect(bool bEnableNBT, bool bEnableVat )
        {            
            chkNBT.Enabled = bEnableNBT;
            chkVat.Enabled = bEnableVat;           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bCheckNBT = chkNBT.Checked;
            bCheckVat = chkVat.Checked;
            this.Close();
        }
    }
}
