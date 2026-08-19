using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;

namespace Digiteq
{
    public partial class frmChatUserView : Form
    {
        

        public string glbUserID;
        public static bool bChat = false;


        #region Form Load
        public frmChatUserView()
        {
            InitializeComponent();
        }
        private void frmChatUserView_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, "", 2,0);
            ClearFields();
            FillDetails(glbUserID);
            bChat = false;
        } 
        #endregion

        #region Form Deactivate
        private void frmChatUserView_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //asign values
            lbluserID.Text = "";
            lblUser.Text = "";
            lblGroupName.Text = "";
            lblEmail.Text = "";
            
            pbxImage.Image = Digiteq.Properties.Resources.no_image;
            
        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            if (sID.Length > 0)
            {
                tbl_securityUserMaster detail = tbl_securityUserMaster.Select(sID);
                if (detail != null)
                {
                    
                    //asign values
                    lbluserID.Text = detail.User_ID;
                    lblUser.Text = detail.UserName;
                    lblGroupName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Group(detail.Group_ID));
                    lblEmail.Text = detail.Email;

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
        }
        #endregion

       
    }
}
