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
    public partial class frm_TaxSelecion : Form
    {
        public bool bVatSelected = false, bNbtSelected = false, bSVatSelected=false, bIsPrePrint = false;
        public bool bDraftPrint = false;
        public frm_TaxSelecion(bool bShowchkPrePrint)
        {
            InitializeComponent();

            rdo_Tax.Checked = true;
            chkPrePrint.Visible = bShowchkPrePrint;
        }

        private void btnPrt_Click(object sender, EventArgs e)
        {
            if(chkPrePrint.Checked)
                bIsPrePrint = true;

            if (rdo_NonTax.Checked)
            {
                bVatSelected = false;
                bNbtSelected = false;
            }
            else if (rdo_Tax.Checked)
            {
                bVatSelected = true;
                bNbtSelected = true;
            }
            else
            {
                bVatSelected = true;
                bNbtSelected = false;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnDraft_Click(object sender, EventArgs e)
        {
            bDraftPrint = true;
            if (rdo_NonTax.Checked)
            {
                bVatSelected = false;
                bNbtSelected = false;
            }
            else if (rdo_Tax.Checked)
            {
                bVatSelected = true;
                bNbtSelected = true;
            }
            else
            {
                bVatSelected = false;
                bNbtSelected = true;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }
    }
}
