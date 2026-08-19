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
using Digiteq_Logic; using SEACC.WinFormControls.Forms;

namespace Digiteq
{
    public partial class frmChat : MettroForm
    {
        



        int i_locX = 0, i_locY = 0, i_cnt = 0, i_columns = 2;
        public string glbChatID;
        public static string glbUserID = "";
        int UserCount = 0;



        #region Form Load
        public frmChat()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.Chat);
            iFormID = clsSecurity.getFormID(FormName.Chat);
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
            ThemeColor = clsFormatter.colorAccounts;
            //format Form
            clsFormatter.setFormatForm(this, "", 2, iFormID);

            //fill user names
            LoadUsers();

            //if (glbChatID != null || glbChatID != "")
            //    LoadMessages(glbChatID);            

            glbChatID = "";
        }
        #endregion

        #region Form Deactivate
        private void frmChat_Deactivate(object sender, EventArgs e)
        {
            //this.Hide();
        }
        #endregion

        #region Form VisibleChanged
        private void frmChat_VisibleChanged(object sender, EventArgs e)
        {
            SelectChatRoom(glbChatID);
            timer1.Start();
        }
        #endregion

        #region Load Users
        private void LoadUsers()
        {
            //set the values
            this.i_locX = 5;
            this.i_locY = 5;
            this.i_cnt = 0;
            this.i_columns = 2;

            //clear the pannel
            xpnlUsers.Controls.Clear();

            //Check whether show digiteq user or not 2017-08-09
            List<tbl_utlUserPool> details = null;
            if (clsConfig.bVisible_digiteq_User)
                details = tbl_utlUserPool.SelectAll();
            else
                details = tbl_utlUserPool.SelectAll().Where(p => p.User_ID != "digiteq").ToList();

            //List<tbl_utlUserPool> details = tbl_utlUserPool.SelectAll();
            UserCount = details.Count;
            foreach (tbl_utlUserPool detail in details)
            {
                if (detail.LoginStatus_ID == clsAutocode.getLoginStatusID(LoginStatus.Online) || detail.LoginStatus_ID == clsAutocode.getLoginStatusID(LoginStatus.Idle))
                {
                    int width = 90;
                    Button btnUser = new Button();
                    PictureBox pbxImage = new PictureBox();
                    FillUser(detail, btnUser, pbxImage, width);
                    btnUser.Click += new EventHandler(UserClick);
                    btnUser.MouseHover += new EventHandler(User_MouseHover);
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
                pbxImage.Size = new Size(25, 25);
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
                btnUser.Size = new Size(width, 25);
                btnUser.Font = new Font("calibri", 9, FontStyle.Bold); //clsCommon.defaultFont;
                btnUser.Name = Category.User_ID;
                btnUser.Text = clsGenaralName.getName_User(Category.User_ID);
                btnUser.TextAlign = ContentAlignment.BottomCenter;
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
                string s = ((Control)sender).Tag.ToString().Trim();
                CreateChatRoom(s);
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
        #endregion

        #region MouseHover on User
        private void User_MouseHover(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                Point p = GetPositionInForm(((Control)sender));
                string s = ((Control)sender).Tag.ToString().Trim();
                frmChatUserView view = new frmChatUserView();
                view.glbUserID = s;
                view.MdiParent = this.MdiParent;
                view.StartPosition = FormStartPosition.Manual;
                view.Location = new Point(p.X + 1 + ((Control)sender).Width, p.Y + 2);
                view.Show();
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

        #region Create A ChatRoom
        public void CreateChatRoom(string sUserID)
        {
            try
            {
                string sChatID = "";
                bool bChatAvailable = false;

                #region Open New Chat Room
                List<tbl_utlChatUser> OpenedChats = tbl_utlChatUser.SelectAllByUser_ID(sUserID);
                foreach (tbl_utlChatUser OpenedChat in OpenedChats)
                {
                    List<tbl_utlChatUser> OpenedChatsForMe = tbl_utlChatUser.SelectAllByChat_ID(OpenedChat.Chat_ID);
                    foreach (tbl_utlChatUser OpenedChatForMe in OpenedChatsForMe)
                    {
                        if (OpenedChatForMe.User_ID == clsSecurity.UserIDLoged)
                        {
                            sChatID = OpenedChatForMe.Chat_ID;
                            bChatAvailable = true;
                            break;
                        }
                    }
                    if (bChatAvailable)
                        break;
                }
                #endregion

                #region New Chat Create
                if (sChatID.Length == 0)
                {
                    if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                        sChatID = clsAutocode.getAutoGeneratedCode(sFormConfigCode);
                    if (sChatID.Length > 0)
                    {
                        //Create Chat Room
                        tbl_utlChat cRoom = new tbl_utlChat(sChatID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.UserIDLoged);
                        cRoom.Insert();

                        //Add Users Created
                        tbl_utlChatUser cUser1 = new tbl_utlChatUser(sChatID, clsSecurity.UserIDLoged, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false, true);
                        cUser1.Insert();

                        //Add Other User
                        if (sUserID != clsSecurity.UserIDLoged)
                        {
                            tbl_utlChatUser cUser2 = new tbl_utlChatUser(sChatID, sUserID, clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), false, false);
                            cUser2.Insert();
                        }
                    }
                }
                #endregion

                //set the values
                this.i_cnt = 0;

                LoadRooms(sChatID);
                LoadMessages(sChatID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Create A ChatRoom
        public void SelectChatRoom(string sChatID)
        {
            try
            {
                LoadRooms(sChatID);
                LoadMessages(sChatID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Load Room
        private void LoadRooms(string sChatID)
        {
            //set the values
            this.i_locX = 5;
            this.i_locY = 5;
            this.i_cnt = 0;
            this.i_columns = 4;

            //clear the pannel
            xpnlChatRooms.Controls.Clear();

            List<tbl_utlChatUser> details = tbl_utlChatUser.SelectAllByUser_ID(clsSecurity.UserIDLoged);
            foreach (tbl_utlChatUser detail in details)
            {
                if (true) //(sChatID != detail.Chat_ID)
                {
                    int width = 70;
                    Button btnRoom = new Button();

                    FillRooms(detail.Chat_ID, btnRoom, width);
                    btnRoom.Click += new EventHandler(btnRoom_Click);
                    //btnUser.MouseHover += new EventHandler(Category_MouseHover);
                }
            }
        }
        #endregion

        #region Fill Rooms
        private void FillRooms(string Chat_ID, Button btnRoom, int width)
        {
            try
            {
                #region fill User
                tbl_utlChat cChat = tbl_utlChat.Select(Chat_ID);
                if (cChat != null)
                {
                    btnRoom.Size = new Size(width, 36);
                    btnRoom.Font = new Font("calibri", 7, FontStyle.Bold); //clsCommon.defaultFont;
                    btnRoom.Name = Chat_ID;
                    btnRoom.Text = cChat.StartTime.ToShortTimeString() + "\n" + getChatUserNameExceptMe(cChat.Chat_ID);
                    btnRoom.TextAlign = ContentAlignment.BottomCenter;
                    btnRoom.Tag = Chat_ID;
                    btnRoom.AutoSize = false;
                    btnRoom.BackColor = Color.Transparent;
                    btnRoom.ForeColor = Color.Green;
                    btnRoom.FlatAppearance.BorderSize = 1;
                    btnRoom.FlatAppearance.BorderColor = Color.DarkGreen;
                    btnRoom.FlatStyle = FlatStyle.Flat;
                    btnRoom.Location = new Point(this.i_locX, this.i_locY);
                    btnRoom.TextImageRelation = TextImageRelation.ImageAboveText;
                    xpnlChatRooms.Controls.Add(btnRoom);
                    this.i_cnt += 1;
                    if (((this.i_cnt) % this.i_columns) == 0)
                    {
                        this.i_locX = 5;
                        this.i_locY += btnRoom.Size.Height + 5;
                        this.i_cnt = 0;
                    }
                    else
                    {
                        this.i_locX += btnRoom.Size.Width + 5;
                    }
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
        private void btnRoom_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string sChatID = ((Control)sender).Tag.ToString().Trim();
                LoadMessages(sChatID);

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
        #endregion

        #region Load Messages
        private void LoadMessages(string sChatID)
        {
            //set the values
            this.i_locX = 0;
            this.i_locY = 0;
            this.i_cnt = 0;
            this.i_columns = 2;
            //clear the pannel
            xpnlMessages.Controls.Clear();
            xpnlMessageHeader.Controls.Clear();
            glbChatID = sChatID;

            try
            {
                if (sChatID != null && sChatID != "")
                {
                    tbl_utlChat cChat = tbl_utlChat.Select(sChatID);
                    if (cChat != null)
                    {
                        #region Button, Label and Location Initialization
                        //User
                        Label lblHeader = new Label();
                        Button btnLeave = new Button();

                        #region label Header
                        string sHeader = "";
                        sHeader += cChat.StartTime.ToShortTimeString();
                        sHeader += " ---- " + clsGenaralName.getName_User(cChat.CreateUser_ID);

                        List<tbl_utlChatUser> cUsers = tbl_utlChatUser.SelectAllByChat_ID(sChatID);
                        foreach (tbl_utlChatUser cUser in cUsers)
                        {
                            if (cUser.User_ID != clsSecurity.UserIDLoged)
                                sHeader += " / " + clsGenaralName.getName_User(cUser.User_ID);
                        }

                        lblHeader.Text = sHeader;
                        lblHeader.Font = new Font("calibri", 9, FontStyle.Bold); //clsCommon.defaultFont;                             
                        lblHeader.AutoSize = false;
                        lblHeader.BackColor = Color.Transparent;
                        lblHeader.ForeColor = Color.FromArgb(99, 50, 50);
                        lblHeader.Size = new Size(243, 25);
                        lblHeader.TextAlign = ContentAlignment.MiddleLeft;
                        lblHeader.Location = new Point(this.i_locX, this.i_locY);
                        xpnlMessageHeader.Controls.Add(lblHeader);
                        this.i_cnt += 1;
                        if (((this.i_cnt) % this.i_columns) == 0)
                        {
                            this.i_locX = 5;
                            this.i_locY += lblHeader.Size.Height + 5;
                            this.i_cnt = 0;
                        }
                        else
                        {
                            this.i_locX += lblHeader.Size.Width + 2;
                        }
                        #endregion

                        #region Button Leave
                        btnLeave.Text = "Exit";
                        btnLeave.Font = new Font("calibri", 9, FontStyle.Bold); //clsCommon.defaultFont;                             
                        btnLeave.AutoSize = false;
                        btnLeave.Name = cChat.Chat_ID;
                        btnLeave.ForeColor = Color.FromArgb(99, 50, 50);
                        btnLeave.Size = new Size(60, 22);
                        btnLeave.TextAlign = ContentAlignment.MiddleCenter;
                        btnLeave.FlatAppearance.BorderSize = 1;
                        btnLeave.FlatAppearance.BorderColor = Color.DarkGreen;
                        btnLeave.FlatStyle = FlatStyle.Flat;
                        btnLeave.Location = new Point(this.i_locX, this.i_locY);
                        btnLeave.Visible = false;
                        xpnlMessageHeader.Controls.Add(btnLeave);
                        this.i_cnt += 1;
                        if (((this.i_cnt) % this.i_columns) == 0)
                        {
                            this.i_locX = 5;
                            this.i_locY += lblHeader.Size.Height + 5;
                            this.i_cnt = 0;
                        }
                        else
                        {
                            this.i_locX += lblHeader.Size.Width + 2;
                        }
                        #endregion

                        this.i_locX = 5;
                        this.i_locY = 5;
                        this.i_cnt = 0;
                        this.i_columns = 2;

                        #endregion

                        #region Chat Load in room
                        List<tbl_utlChat_Message> cMessages = tbl_utlChat_Message.SelectAllByChat_ID(sChatID);
                        foreach (tbl_utlChat_Message cMessage in cMessages)
                        {

                            int width = 110;
                            Label lblMessage = new Label();
                            Label lblUser = new Label();
                            FillMessage(cMessage, lblMessage, lblUser, width);
                        }
                        btnLeave.Click += new EventHandler(btnLeave_Click);
                        #endregion

                        //update read status
                        tbl_utlChatUser chatUser = tbl_utlChatUser.Select(sChatID, clsSecurity.UserIDLoged);
                        if (chatUser != null)
                        {
                            chatUser.HasUnReadMessages = false;
                            chatUser.Update();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Message
        private void FillMessage(tbl_utlChat_Message cMessage, Label lblMessage, Label lblHeader, int width)
        {
            try
            {
                //User
                #region Fill Users
                lblHeader.Text = clsGenaralName.getName_User(cMessage.User_ID) + "  :";
                lblHeader.Font = new Font("calibri", 9, FontStyle.Bold); //clsCommon.defaultFont;
                lblHeader.TextAlign = ContentAlignment.BottomCenter;
                lblHeader.Tag = cMessage.Chat_ID;
                lblHeader.AutoSize = true;
                lblHeader.BackColor = Color.Transparent;
                lblHeader.ForeColor = Color.Green;
                lblHeader.MaximumSize = new Size(221, 0);
                lblHeader.TextAlign = ContentAlignment.MiddleLeft;
                lblHeader.Location = new Point(this.i_locX, this.i_locY);
                xpnlMessages.Controls.Add(lblHeader);

                this.i_cnt += 1;
                if (((this.i_cnt) % this.i_columns) == 0)
                {
                    this.i_locX = 5;
                    this.i_locY += lblHeader.Size.Height + 5;
                    this.i_cnt = 0;
                }
                else
                {
                    this.i_locX += lblHeader.Size.Width + 2;
                }
                #endregion

                //Message
                #region Fill Message
                lblMessage.Text = cMessage.ChatMessage.Trim();
                lblMessage.Font = new Font("calibri", 9, FontStyle.Bold); //clsCommon.defaultFont;
                lblMessage.TextAlign = ContentAlignment.BottomCenter;
                lblMessage.Tag = cMessage.Chat_ID;
                lblMessage.AutoSize = true;
                lblMessage.BackColor = Color.Transparent;
                lblMessage.ForeColor = Color.Green;
                lblMessage.MaximumSize = new Size(200, 0);
                lblMessage.TextAlign = ContentAlignment.MiddleLeft;
                lblMessage.Location = new Point(this.i_locX, this.i_locY);
                xpnlMessages.Controls.Add(lblMessage);

                this.i_cnt += 1;
                if (((this.i_cnt) % this.i_columns) == 0)
                {
                    this.i_locX = 5;
                    this.i_locY += lblMessage.Size.Height + 5;
                    this.i_cnt = 0;
                }
                else
                {
                    this.i_locX += lblMessage.Size.Width + 2;
                }
                #endregion
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Btn Leave
        private void btnLeave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string sChatID = ((Control)sender).Name.Trim();
                List<tbl_utlChatUser> cUsers = tbl_utlChatUser.SelectAllByChat_ID(sChatID);
                foreach (tbl_utlChatUser cUser in cUsers)
                {
                    if (cUser.User_ID == clsSecurity.UserIDLoged)
                    {
                        cUser.Delete();
                        clsProcessMethods.ArchiveChat(sChatID);
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
        #endregion

        #region Btn Send
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (glbChatID.Length > 0)
            {
                tbl_utlChat_Message cMessage = new tbl_utlChat_Message(glbChatID, clsSecurity.UserIDLoged, txtMessage.Text.Trim(), clsSecurity.getServerDateTime());
                cMessage.Insert();
                txtMessage.Clear();

                //update unread message status
                List<tbl_utlChatUser> chatUsers = tbl_utlChatUser.SelectAllByChat_ID(glbChatID);
                foreach (tbl_utlChatUser chatUser in chatUsers)
                {
                    if (chatUser.User_ID != clsSecurity.UserIDLoged)
                    {
                        chatUser.HasUnReadMessages = true;
                        chatUser.Update();
                    }
                }

                //Load Messages
                LoadMessages(glbChatID);
            }
        }
        #endregion

        #region Get Chat Name Except ME
        private string getChatUserNameExceptMe(string sChatID)
        {
            string sUserName = clsGenaralName.getName_User(clsSecurity.UserIDLoged);
            List<tbl_utlChatUser> users = tbl_utlChatUser.SelectAllByChat_ID(sChatID);
            foreach (tbl_utlChatUser user in users)
            {
                if (user.User_ID != clsSecurity.UserIDLoged)
                {
                    sUserName = clsGenaralName.getName_User(user.User_ID);
                    break;
                }
            }
            return sUserName;
        }
        #endregion

        #region Events KeyDown
        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(sender, e);
            }
        }
        #endregion

        #region Position Reporter Edge
        private void PositionReporterEdge()
        {
            frmChatUserView view = new frmChatUserView();

            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;

            Point parentPoint = this.Location;

            int parentHeight = this.Height;
            int parentWidth = this.Width;

            int childHeight = view.Height;
            int childWidth = view.Width;

            int resultX;
            int resultY;

            if ((parentPoint.Y + parentHeight + childHeight) > screenHeight)
            {
                // If we would move off the screen, position near the top.
                resultY = parentPoint.Y + 50; // move down 50
                resultX = parentPoint.X;
            }
            else
            {
                // Position on the edge.
                resultY = parentPoint.Y + parentHeight;
                resultX = parentPoint.X;
            }

            // set our child form to the new position
            view.Location = new Point(resultX, resultY);
            view.Show();
        }
        #endregion

        #region Timer Tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (glbChatID != "" && glbChatID != null)
            {
                tbl_utlChatUser user = tbl_utlChatUser.Select(glbChatID, clsSecurity.UserIDLoged);
                if (user != null && user.HasUnReadMessages)
                {
                    LoadMessages(glbChatID);
                }
            }

            List<tbl_utlUserPool> details = null;
            if (clsConfig.bVisible_digiteq_User)
                details = tbl_utlUserPool.SelectAll();
            else
                details = tbl_utlUserPool.SelectAll().Where(p => p.User_ID != "digiteq").ToList();

            foreach (tbl_utlUserPool oPool in details)
            {
                if (UserCount != details.Count || oPool.IsNewLogin == true || oPool.IsForceLogout == true || oPool.IsForceShoutdown == true)
                {
                    UserCount = details.Count;
                    LoadUsers();
                }
            }
        }
        #endregion

        #region Chat box Title Bar - Developped by Gayan 2016-08-05
        private void btnChatClose_Click(object sender, EventArgs e)
        {
            frmMainNew master = (frmMainNew)Application.OpenForms["frmMainNew"];
            master.ChatMethod();
        }

        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMainNew master = new frmMainNew();
            master.ChatMethod();
        }

        //public const int WM_NCLBUTTONDOWN = 0xA1;
        //public const int HT_CAPTION = 0x2;

        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //public static extern int SendMessage(IntPtr hWnd,
        //                 int Msg, int wParam, int lParam);
        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //public static extern bool ReleaseCapture();
        //private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        //{
        //    // this.Location = new Point(Cursor.Position.X + e.X, Cursor.Position.Y + e.Y);
        //    ReleaseCapture();
        //    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        //} 
        #endregion
    }
}
