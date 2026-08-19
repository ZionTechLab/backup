using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;

namespace SEACC.WinFormControls.Components
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class ucTittleBar_Main : UserControl
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public ucTittleBar_Main()
        {
            InitializeComponent();
        }
        private void ucTittleBar_Main_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.ParentForm.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        public string CompanyName
        {
            get
            {
                return this.lblCompanyName.Text;
            }
            set
            {
                this.lblCompanyName.Text = value;
            }
        }

        public string SeaccType
        {
            get
            {
                return this.lblSeaccType.Text;
            }
            set
            {
                this.lblSeaccType.Text = value;
            }
        }

        public string SeaccName
        {
            get
            {
                return this.lblSeaccName.Text;
            }
            set
            {
                this.lblSeaccName.Text = value;
            }
        }

    }
}
