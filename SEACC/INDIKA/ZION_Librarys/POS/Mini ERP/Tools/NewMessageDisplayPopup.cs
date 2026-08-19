using DataTire;
using Digiteq_Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class NewMessageDisplayPopup : Form
    {
        public string _sChatID { get; set; }
        private string _sUserID { get; set; }
    //    frmChat obj_frmChat = new frmChat();
        
        public NewMessageDisplayPopup()
        {
            InitializeComponent();

        }
        public NewMessageDisplayPopup(string sChatID)
        {
            InitializeComponent();
            this._sChatID = sChatID;

            Rectangle r = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }
        private void NewMessageDisplayPopup_Load(object sender, EventArgs e)
        {
            FillDetails(_sChatID, _sUserID);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
        //    obj_frmChat.glbChatID = _sChatID;
       //     obj_frmChat.MdiParent = this;
        //    obj_frmChat.Show();
        }

        #region Fill Details
        private void FillDetails(string sChatID, string sUserID)
        {
            if (sUserID.Length > 0)
            {
                tbl_securityUserMaster detail = tbl_securityUserMaster.Select(sUserID);
                if (detail != null)
                {

                    //asign values
                    lbluserID.Text = detail.User_ID;
                    lblUser.Text = detail.UserName;
                    lblGroupName.Text = "Message";

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
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
