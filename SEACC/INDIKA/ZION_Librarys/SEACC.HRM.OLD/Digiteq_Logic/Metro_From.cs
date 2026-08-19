using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Digiteq_Logic
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class Metro_From : Form
    {
        #region Variables and Properties
        bool bIsmaximized = false;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public Color TheamColor
        {
            get
            {
                return lblTitleBar.BackColor;
            }
            set
            {
                lblTitleBar.BackColor = value;
                panel1.BackColor = value;
                panel2.BackColor = value;
                panel3.BackColor = value;
                panel4.BackColor = value;
                panel5.BackColor = value;
                btnRestore.BackColor = value;
                btn_Close.BackColor = value;
                btn_minimize.BackColor = value;
            }
        }
        #endregion

        #region Form Load
        public Metro_From()
        {
            InitializeComponent();
        }

        private void Metro_From_Load(object sender, EventArgs e)
        {
            lblTitleBar.Text = Text;

            if (WindowState == FormWindowState.Maximized)
            {
                btnRestore.Text = "\uE923";
                bIsmaximized = true;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                btnRestore.Text = "\uE003";
                bIsmaximized = false;
            }

        }
        #endregion

        #region Button Events
        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Other Events
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region Override Methods

        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }

        #endregion

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (bIsmaximized)
            {
                WindowState = FormWindowState.Normal;
                btnRestore.Text = "\uE003";
                bIsmaximized = false;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                btnRestore.Text = "\uE923";
                bIsmaximized = true;
            }
        }

        private void lblTitleBar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnRestore_Click(null, null);
        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            btnRestore_Click(null, null);
        }

        private void Metro_From_ResizeEnd(object sender, EventArgs e)
        {
            btnRestore_Click(null, null);
        }
    }
}
