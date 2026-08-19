using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; 
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;
using Digiteq_Logic;

namespace Digiteq
{
    public partial class frmUserRemove :MettroForm
    {
        #region Variables
        //form manage      
           public int iFormID;

        //for security handle
        public bool bNoAccess;

        int i_locX = 0, i_locY = 0, i_cnt = 0, i_columns = 2;


        #endregion

        #region Form Load
        public frmUserRemove()
        { 
            iFormID = clsSecurity.getFormID(FormName.UserControl);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
            //Rectangle r = Screen.PrimaryScreen.WorkingArea;
            //this.StartPosition = FormStartPosition.Manual;
            //this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }

        private void frm_Chat_Load(object sender, EventArgs e)
        {
            //format Form
            clsFormatter.setFormatForm(this, clsHelpMethods.getFormName(iFormID), 2, iFormID);

            //fill user names
            LoadUsers();

        } 
        #endregion

        #region Form Deactivate
        private void frmChat_Deactivate(object sender, EventArgs e)
        {
            //this.Hide();
        } 
        #endregion

        #region Load Users
        private void LoadUsers()
        {
            //set the values
            this.i_locX = 5;
            this.i_locY = 5;
            this.i_cnt = 0;
            this.i_columns = 4;
          
            //clear the pannel
            xpnlUsers.Controls.Clear();

            //Check whether show digiteq user or not 2017-08-09
            List<tbl_utlUserPool> details = null;
            if (clsConfig.bVisible_digiteq_User)
                details = tbl_utlUserPool.SelectAll();
            else
                details = tbl_utlUserPool.SelectAll().Where(p => p.User_ID != "digiteq").ToList();

            //List<tbl_utlUserPool> details = tbl_utlUserPool.SelectAll();
            foreach (tbl_utlUserPool detail in details)
            {
                bool bOk = true;
                if (detail.LoginStatus_ID == clsAutocode.getLoginStatusID(LoginStatus.Online) || detail.LoginStatus_ID == clsAutocode.getLoginStatusID(LoginStatus.Idle))
                {
                    if (chkLockedUsers.Checked)
                    {
                        if (detail.IsForceShoutdown || detail.IsForceLogout)
                            bOk = true;
                        else
                            bOk = false;
                        
                    }
                    if (bOk)
                    {
                        int width = 125;
                        Button btnUser = new Button();
                        PictureBox pbxImage = new PictureBox();
                        FillUser(detail, btnUser, pbxImage, width);
                        btnUser.Click += new EventHandler(UserClick);
                        //btnUser.MouseHover += new EventHandler(Category_MouseHover);
                    }
                }
            }
        }
        #endregion

        #region Fill User
        private void FillUser(tbl_utlUserPool Category, Button btnUser, PictureBox pbxImage, int width)
        {
            try
            {
                #region Fill Image
                pbxImage.Size = new Size(40, 40);
                tbl_securityUserMaster sUser = tbl_securityUserMaster.Select(Category.User_ID);
                if (sUser != null && sUser.Image != null)
                {
                    if (sUser.Image.Length > 0)
                    {
                        MemoryStream ms = new MemoryStream(sUser.Image);
                        pbxImage.Image = Image.FromStream(ms);
                    }
                    else
                        pbxImage.Image = pbxImage.InitialImage;
                }
                else
                    pbxImage.Image = pbxImage.InitialImage;
                pbxImage.SizeMode = PictureBoxSizeMode.StretchImage;
                pbxImage.BorderStyle = BorderStyle.FixedSingle;
                pbxImage.Location = new Point(this.i_locX, this.i_locY);
                xpnlUsers.Controls.Add(pbxImage);
                this.i_cnt += 1;
                if (((this.i_cnt) % this.i_columns) == 0)
                {
                    this.i_locX = 5;
                    this.i_locY += pbxImage.Size.Height + 5;
                    this.i_cnt = 0;
                }
                else
                {
                    this.i_locX += pbxImage.Size.Width;
                } 
                #endregion

                #region fill User
                btnUser.Size = new Size(width, 40);
                btnUser.Font = new Font("calibri", 9, FontStyle.Bold); //clsCommon.defaultFont;
                btnUser.Name = Category.Terminal_ID;
                btnUser.Text = "Usr : " + clsGenaralName.getName_User(Category.User_ID) + "\nTer : "+ clsGenaralName.getName_Terminal(Category.Terminal_ID);
                btnUser.TextAlign = ContentAlignment.MiddleLeft;
                btnUser.Tag = Category.User_ID;
                btnUser.AutoSize = false;
                btnUser.BackColor = Color.Transparent;
                btnUser.ForeColor = Color.Green;
                btnUser.FlatAppearance.BorderSize = 1;
                btnUser.FlatAppearance.BorderColor = Color.DarkGreen;
                btnUser.FlatStyle = FlatStyle.Flat;
                btnUser.Location = new Point(this.i_locX, this.i_locY);
                btnUser.TextImageRelation = TextImageRelation.ImageAboveText;
                xpnlUsers.Controls.Add(btnUser);
                this.i_cnt += 1;
                if (((this.i_cnt) % this.i_columns) == 0)
                {
                    this.i_locX = 5;
                    this.i_locY += btnUser.Size.Height + 5;
                    this.i_cnt = 0;
                }
                else
                {
                    this.i_locX += btnUser.Size.Width + 5;
                } 
                #endregion
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Click on User
        private void UserClick(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Point p = GetPositionInForm(((Control)sender));
                string userID = ((Control)sender).Tag.ToString().Trim();
                string terminalID = ((Control)sender).Name.Trim();

                DialogResult msgResult = MessageBox.Show("Are you sure you want to force logout " + clsGenaralName.getName_User(userID), clsFormatter.GetMessageCaption(), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (msgResult == DialogResult.Yes)
                {
                    tbl_utlUserPool pool = tbl_utlUserPool.SelectAllByUser_ID(userID).Where(r=>r.Terminal_ID == terminalID).FirstOrDefault();
                    if (pool != null)
                    {
                        if (chkLockedUsers.Checked)
                        {
                            pool.Delete();
                        }
                        else
                        {
                            pool.IsForceShoutdown = true;
                            pool.Update();
                        }

                        //Refresh
                        LoadUsers();
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        public Point GetPositionInForm(Control ctrl)
        {
            Point p = ctrl.Location;
            Control parent = ctrl.Parent;
            while (!(parent is Form))
            {
                p.Offset(parent.Location.X, parent.Location.Y);
                parent = parent.Parent;
            }
            return p;
        }

        #endregion

        private void chkLockedUsers_CheckedChanged(object sender, EventArgs e)
        {
            LoadUsers();
        }

    }
}
