using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;

namespace Digiteq
{
    public partial class frmDesktopAlert : Form
    {

        #region Variables
        public string glbUserID = "";
        #endregion

        public frmDesktopAlert()
        {
            InitializeComponent();

            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }

        private void frmDesktopAlert_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "DeskTop Alert", 2,0);

            if (glbUserID.Length > 0)
            {
                tbl_securityUserMaster detail = tbl_securityUserMaster.Select(glbUserID);
                if (detail != null)
                {
                    lblUserName.Text = detail.UserName;
                    lblMessage.Text = "User Has Just Loged In To The SEACC System ";

                    string sterminal = "";
                    List<tbl_utlUserPool> pools = tbl_utlUserPool.SelectAllByUser_ID(glbUserID);
                    foreach (tbl_utlUserPool pool in pools)
                    {
                        tbl_securityTerminalMaster terminal = tbl_securityTerminalMaster.Select(pool.Terminal_ID);
                        if (terminal != null)
                        {
                            sterminal = terminal.Terminal_Name;
                            break;
                        }
                    }
                    if (sterminal.Length > 0)
                        lblTerminal.Text = "Terminal : " + sterminal;
                    

                    //Image                    
                    if (detail.Image != null)
                    {
                        if (detail.Image.Length > 0)
                        {
                            MemoryStream ms = new MemoryStream(detail.Image);
                            pbxImage.Image = Image.FromStream(ms);
                        }
                        else
                        {
                            pbxImage.Image = pbxImage.InitialImage;
                        }
                    }
                    else
                    {
                        pbxImage.Image = pbxImage.InitialImage;
                    }
                }
            }

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();


        }
    }
}
