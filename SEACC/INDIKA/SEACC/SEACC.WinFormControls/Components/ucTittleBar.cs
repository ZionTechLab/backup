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
using System.Runtime.InteropServices;

namespace SEACC.WinFormControls.Components
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class ucTittleBar : UserControl
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public ucTittleBar()
        {
            InitializeComponent();
        }

        private void ucTittleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.ParentForm.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            l_Header.ForeColor = Color.Black;
        }

        public string DisplayName
        {
            get
            {
                return this.l_Header.Text;
            }
            set
            {
                this.l_Header.Text = value;
            }
        }
        //public Font TitleFont
        //{
        //    get
        //    {
        //        return l_Header.Font;
        //    }
        //    set
        //    {
        //        l_Header.Font = value;
        //    }
        //}

    }
}
