using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace Digiteq
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class ucExpander2 : UserControl
    {
        int iDispayHeight ;

        public string DisplayName
        {
            get
            {
                return this.lblDisplayName.Text;
            }
            set
            {
                this.lblDisplayName.Text = value;
            }
        }

        public string DisplayAmount
        {
            get
            {
                return this.lblAmount.Text;
            }
            set
            {
                this.lblAmount.Text = value;
            }
        }

        public Color ThemeColor
        {
            get
            {
                return this.pnlHeader.BackColor;
            }
            set
            {
                this.pnlHeader.BackColor = value;
            }
        }

        public Color FontColor
        {
            get
            {
                return this.lblDisplayName.ForeColor;
            }
            set
            {
                this.lblDisplayName.ForeColor = value;
            }
        }

        public ucExpander2()
        {
            InitializeComponent();
        }

        private void ucExpander_Load(object sender, EventArgs e)
        {
            iDispayHeight = this.Height - pnlHeader.Height;
        }

        private void pnlHeader_Click(object sender, EventArgs e)
        {
            if (this.Height != pnlHeader.Height)
            {
                this.Height = pnlHeader.Height;
                lblIcon.Text = "";
            }
            else
            {
                this.Height = pnlHeader.Height + iDispayHeight;
                lblIcon.Text = "";
            }
        }
        public void InitializeSize()
        {
            pnlHeader_Click(null, null);
        }    
    }
}