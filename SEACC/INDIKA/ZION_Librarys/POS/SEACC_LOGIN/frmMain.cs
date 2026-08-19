using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
 using System.Windows.Forms;
using System.Runtime.InteropServices;
using DataTire;
using System.IO;
using SEACC_LOGIN.Common;
using System.Diagnostics;
using SEACC;
using Digiteq_Logic;
using Digiteq;
namespace SEACC_LOGIN
{
    public partial class frmMain : Form
    {
        #region Variables
        int iRestartCount = 0;
        //int iNetworkLossMessageCount = 0;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("shell32.dll", EntryPoint = "#261", CharSet = CharSet.Unicode, PreserveSig = false)]
        public static extern void GetUserTilePath(string username, UInt32 whatever, StringBuilder picpath, int maxLength);

        string sDB_Con;
        string sTerminal;
        string sUserID;
        string sComID;
        string sComBranchID;
        string sSession_Index;
        string sServer;
        string sDomain;
        #endregion

        #region Form Load
        public frmMain(string sSession_index)
        {
            InitializeComponent();

            this.sSession_Index = sSession_index;

            SetInitializeConfigs();


            this.StartPosition = FormStartPosition.Manual;
            foreach (var scrn in Screen.AllScreens)
            {
                if (scrn.Bounds.Contains(this.Location))
                {
                    this.Location = new Point(scrn.Bounds.Right - this.Width - 2, scrn.Bounds.Top + 2);
                    return;
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            iRestartCount = 0;
            timerNetworkChecker.Start();

            int top = 0;
            int left = 0;
            foreach (tbl_cfgModule oModule in tbl_cfgModule.SelectAll().Where(r => r.IsVisible).OrderBy(r => r.SortOrder))
            {
                tbl_cfgModule_Permission oPermission = tbl_cfgModule_Permission.Select(clsSecurity_Login.CompanyBranchID, clsSecurity_Login.UserIDLoged, oModule.Module_Index);
                if ((oPermission != null && oPermission.AllowAccess) || clsSecurity_Login.UserIDLoged == "digiteq")
                {
                    Button button = new Button();
                    button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    button.FlatAppearance.MouseOverBackColor = ControlPaint.Light(System.Drawing.ColorTranslator.FromHtml("#FF276699"));
                    button.Location = new System.Drawing.Point(10, 104);
                    button.Name = "btn" + oModule.ModuleName;
                    button.Size = new System.Drawing.Size(160, 35);
                    button.TabIndex = oModule.SortOrder;
                    button.Text = oModule.ModuleName;
                    button.UseVisualStyleBackColor = true;
                    button.Tag = oModule.Module_Index;
                    button.Click += new EventHandler(btnModuleButton_Click);
                    button.MouseDown += btnModuleButton_MouseDown;

                    button.Left = left;
                    button.Top = top;
                    pModules.Controls.Add(button); // here
                    top += button.Height + 2;
                }
            }
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                tbl_utlUserPool uPool = tbl_utlUserPool.Select(int.Parse(clsSecurity_Login.LoginSession_Index), clsSecurity_Login.UserIDLoged, clsSecurity_Login.TerminalID);
                if (uPool != null)
                    uPool.Delete();
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region Form Responsiveness
        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                icon_seacc_login.Visible = true;
                icon_seacc_login.ShowBalloonTip(500);
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                icon_seacc_login.Visible = false;
            }
        }
        #endregion

        #region Button Events
        private void btnModuleButton_Click(object sender, EventArgs e)
        {
            try
            {
                MouseEventArgs mouseEvent = (MouseEventArgs)e;
                int iModule_index = int.Parse((sender as Button).Tag.ToString());
                string sExeLocation = clsGenaralName.getLocation_ModuleExe(iModule_index);

                switch (iModule_index)
                {
                    case 10:
                        if (mouseEvent.Button == MouseButtons.Left)
                        {
                            DisplayContext_Menu();
                        }
                        break;
                    default:
                        if (mouseEvent.Button == MouseButtons.Left)
                        {
                            try
                            {
                                Process.Start(
                                    sExeLocation,
                                    sDB_Con + " " +
                                    sTerminal + " " +
                                    sUserID + " " +
                                    sSession_Index + " " +
                                    sComID + " " +
                                    sComBranchID + " " +
                                    sServer + " " +
                                    sDomain
                                );
                            }
                            catch (Exception ex)
                            {
                                SEACCException.Show(ex);
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }

        private void icon_seacc_login_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void btnModuleButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && clsSecurity_Login.UserIDLoged == "digiteq")
            {
                Clipboard.SetText(sDB_Con + " " +
                    sTerminal + " " +
                    sUserID + " " +
                    sSession_Index + " " +
                    sComID + " " +
                    sComBranchID + " " +
                    sServer + " " +
                    sDomain
                    );
            }
        }

        #region Contral Box Buttons
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_utlUserPool uPool = tbl_utlUserPool.Select(int.Parse(clsSecurity_Login.LoginSession_Index), clsSecurity_Login.UserIDLoged, clsSecurity_Login.TerminalID);
                if (uPool != null)
                    uPool.Delete();

                Program.IsLogOff = true;
                //MessageBox.Show("Logout");

                //MessageBox.Show(System.Reflection.Assembly.GetEntryAssembly().Location);
                //Process.Start(System.Reflection.Assembly.GetEntryAssembly().Location);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
        }

        #endregion

        #endregion

        #region Context Menu Strip Initialize and Events
        private void DisplayContext_Menu()
        {
            ContextMenuStrip contextMenuStrip1 = new ContextMenuStrip();
            contextMenuStrip1.AutoSize = false;
            contextMenuStrip1.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            contextMenuStrip1.BackColor = Color.Gray; //Color.FromArgb();
            contextMenuStrip1.ForeColor = Color.White;//Color.FromArgb();

            ToolStripMenuItem permissionTSM = new ToolStripMenuItem();
            permissionTSM.Name = "myportalToolStripMenuItem";
            permissionTSM.Size = new Size(178, 25);
            permissionTSM.Text = "Module Permission";
            permissionTSM.Click += PermissionTSM_Click;

            ToolStripMenuItem workstationregisterTSM = new ToolStripMenuItem();
            workstationregisterTSM.Name = "myportalToolStripMenuItem";
            workstationregisterTSM.Size = new Size(178, 25);
            workstationregisterTSM.Text = "Workstation Register";
            workstationregisterTSM.Click += WorkstationRegisterTSM_Click;

            contextMenuStrip1.Items.AddRange(new ToolStripItem[] {
                permissionTSM,
                workstationregisterTSM
            });


            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.ShowImageMargin = false;
            contextMenuStrip1.Size = new Size(180, 60);
            contextMenuStrip1.Renderer = new MyRenderer();

            this.Cursor = new Cursor(Cursor.Current.Handle);
            Point point = new Point(Cursor.Position.X - 200, Cursor.Position.Y);
            contextMenuStrip1.Show(point);
        }

        private void PermissionTSM_Click(object sender, EventArgs e)
        {
            frmModulePermission frm = new frmModulePermission();
            frm.Show();
        }

        private void WorkstationRegisterTSM_Click(object sender, EventArgs e)
        {
            frmWorkstationRegister frm = new frmWorkstationRegister();
            frm.Show();
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.DarkGray; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.DarkGray; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.DarkGray; }
            }
            public override Color MenuItemBorder
            {
                get { return Color.DarkGray; }
            }
        }
        #endregion

        #region Initialize Configs
        private void SetInitializeConfigs()
        {
            try
            {
                sDB_Con = crypt.encryptPassword(DBHandling.DBConnection);
                sTerminal = crypt.encryptPassword(clsSecurity_Login.TerminalID);
                sUserID = crypt.encryptPassword(clsSecurity_Login.UserIDLoged);
                sSession_Index = crypt.encryptPassword(sSession_Index);
                sComID = crypt.encryptPassword(clsSecurity_Login.CompanyID);
                sComBranchID = crypt.encryptPassword(clsSecurity_Login.CompanyBranchID);
                sServer = crypt.encryptPassword(clsSecurity_Login.Server);
                //    sDomain = crypt.encryptPassword(clsSecurity_Login.Domain);
            }
            catch (Exception ex)
            {
                log.WriteErrorLog(ex.Message, "SetInitializeConfigs");
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Panel Event
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region User Indicator Fill Detail
        private void ucUserIndicator_Load(object sender, EventArgs e)
        {
            SetUser_Details(clsSecurity_Login.UserIDLoged);
        }
        private void SetUser_Details(string sUserID)
        {
            Image bm = null;
            tbl_securityUserMaster oMasUser = tbl_securityUserMaster.Select(sUserID);
            if (oMasUser != null)
            {
                ucUserIndicator.Picture = ByteArrayToImage(oMasUser.Image);
                ucUserIndicator.UserName = oMasUser.UserName;
                ucUserIndicator.UserID = clsGenaralName.getName_Group(oMasUser.Group_ID);
                ucUserIndicator.Tag = oMasUser.User_ID;
            }
        }
        private static Image ByteArrayToImage(byte[] bArray)
        {
            if (bArray == null)
                return null;

            Image newImage = null;

            try
            {
                using (MemoryStream ms = new MemoryStream(bArray, 0, bArray.Length))
                {
                    ms.Write(bArray, 0, bArray.Length);
                    newImage = Image.FromStream(ms, true);
                }
            }
            catch
            {
                newImage = null;
            }

            return newImage;
        }
        #endregion

        private void timerNetworkChecker_Tick(object sender, EventArgs e)
        {
            try
            {
                tbl_utlUserPool oUpool = tbl_utlUserPool.Select(int.Parse(clsSecurity_Login.LoginSession_Index), clsSecurity_Login.UserIDLoged, clsSecurity_Login.TerminalID);
                lblNetworkAvailability.Visible = false;
                if (oUpool == null)
                {
                    if (!Program.IsLogOff)
                    {
                        Application.Exit();
                    }
                    else
                    {

                        if (iRestartCount == 0)
                        {
                            ++iRestartCount;
                            Program.IsLogOff = false;
                            timerNetworkChecker.Stop();
                            //Application.Restart();
                            Process.Start(System.Reflection.Assembly.GetEntryAssembly().Location);
                            timerNetworkChecker.Start();
                        }
                    }
                }
                //iNetworkLossMessageCount = 0;
            }
            catch (Exception ex)
            {
                lblNetworkAvailability.Visible = true;
                //if (iNetworkLossMessageCount == 0)
                //{
                //    ++iNetworkLossMessageCount;
                //    SEACCException.Show(ex);
                //}
            }
        }
    }
}
