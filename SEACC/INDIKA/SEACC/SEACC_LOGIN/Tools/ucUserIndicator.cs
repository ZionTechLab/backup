using System;
using System.Drawing;
using System.Windows.Forms;

namespace SEACC_LOGIN
{
    public partial class ucUserIndicator : UserControl
    {
        public delegate void ResultString(string sResult);
        public event ResultString Selection;
        public ucUserIndicator()
        {
            InitializeComponent();
        }

        public Image Picture
        {
            get
            {
                return this.pbxProPic.BackgroundImage;
            }
            set
            {
                this.pbxProPic.BackgroundImage = value;
            }
        }

        public string DisplayName
        {
            get
            {
                return this.lblFullName.Text; 
            }
            set
            {
                this.lblFullName.Text = value;
            }
        }
        public string UserName
        {
            get
            {
                return this.lblFullName.Text;
            }
            set
            {
                this.lblFullName.Text = value;
            }
        }

        public string UserID
        {
            get
            {
                return this.lblUser.Text;
            }
            set
            {
                this.lblUser.Text = value;
            }
        }

        private void ucUserIndicator_MouseEnter(object sender, EventArgs e)
        {
           // this.BackColor = Color.DimGray;
        }

        private void ucUserIndicator_MouseLeave(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
        }

        private void ucUserIndicator_MouseDown(object sender, MouseEventArgs e)
        {
            //Control control = (Control)sender;
            //Point startPoint = this.PointToScreen(new Point());
            //contextMenuStrip1.Show(startPoint.X, startPoint.Y + this.Height);
        }
        void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
         
        }

        private void personalizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Selection("personalize");
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //Selection("Close");
        }

        private void lblFullName_Click(object sender, EventArgs e)
        {

        }
    }
}
