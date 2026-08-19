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

namespace SEACC.WinFormControls.Forms
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class ucExpander : UserControl
    {
        public delegate void Click(object sender, EventArgs e);
        public event Click Update_Click;
        public event Click Refresh_Click;
       
        int iDispayHeight ;

        public string DisplayName
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }
        public ucExpander()
        {
            InitializeComponent();
        }

        private void pnlHeader_Click(object sender, EventArgs e)
        {
            if (this.Height != pnlHeader.Height)
            {
                this.Height = pnlHeader.Height;
                btn_Refresh.Visible = false;
                    btn_Update.Visible = false;
            }
            else
            {
                this.Height = pnlHeader.Height + iDispayHeight;
                btn_Refresh.Visible = true;
                btn_Update.Visible = true;
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Refresh_Click( sender,  e);
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            Update_Click(sender, e);
        }
        public void InitializeSize()
        {
            pnlHeader_Click(null, null);
        }

        private void ucExpander_Load(object sender, EventArgs e)
        {
            iDispayHeight = this.Height - pnlHeader.Height;
        }
                
    }
}