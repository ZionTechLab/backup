using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using SEACC_PTS.NmsEnum;
using SEACC_PTS.NmsLogic;
using SEACC_PTS.NmsSecurity;



namespace SEACC_PTS
{
    public partial class frmMain : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public frmMain()
        {
            try
            {
                InitializeComponent();
                
                dataGridView1.AutoGenerateColumns = false;
                dgvSummary.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnTaskmaster_Click(object sender, EventArgs e)
        {
            frm_Tasks task = new frm_Tasks();

            //task.ShowInTaskbar = false;
            task.Show();
            //ShowInTaskbar = false
        }
        private void btnTimeSheet_Click(object sender, EventArgs e)
        {
            frmTimeSheet pts = new frmTimeSheet();
            pts.Show();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (settings.GetConfigaration())
                {
                    settings.strLogedUserName = System.Environment.UserName;

                    this.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width - this.Width, 0);
                    dbConnection dbc = new dbConnection();
                    if (dbc.Execute_Quary("SELECT name FROM master.dbo.sysdatabases WHERE  name  = '" + settings.strDBName + "'"))
                    {
                        configNames.AutoAssignConfigValue();

                        #region Check Product expire date
                        if (clsConfig.sExpiryDate != "")
                        {
                            DateTime dtmProductExpire = Convert.ToDateTime(clsConfig.sExpiryDate.ToString());
                            if (clsSecurity.getServerDateTime().Date >= dtmProductExpire.Date)
                            {
                                tbl_cfgConfiguration oConfig = tbl_cfgConfiguration.Select(1);//Product Expired - bool
                                if (oConfig != null)
                                {
                                    oConfig.ConfigValue = "True";
                                    oConfig.Update();
                                    clsConfig.sIsExpiry = true;
                                }
                            }

                            if (clsSecurity.getServerDateTime().Date >= dtmProductExpire.Date && clsConfig.sIsExpiry == true)
                            {
                                MessageBox.Show("Please contact 'hepldesk@digiteq.biz'", "Software has been expired", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                                Application.Exit();
                                this.Dispose();

                                return;
                            }
                        }
                        #endregion

                        tbl_masUser User = tbl_masUser.Select(settings.strLogedUserName);
                        if (User != null)
                        {
                            settings.UserId_Loged = User.User_ID;
                            settings.UserGroupID = User.UserGroup_ID;
                            try
                            {
                                settings.sImagePath = User.ProfilePicture != "" ? User.ProfilePicture : settings.sImagePath;
                            }
                            catch (Exception) { }

                            ucUserIndicator1.UserName = settings.strLogedUserName;
                            //   ucUserIndicator1.Picture = Image.FromFile(settings.sImagePath);
                            ucUserIndicator1.DisplayName = User.Full_Name;
                            tbl_UserActivity oActivity = new tbl_UserActivity(settings.UserId_Loged, 1, 1, DateTime.Now);
                            oActivity.Insert();

                            tbl_ptsTasks oTask = new tbl_ptsTasks();
                            dataGridView1.DataSource = oTask.SelectAllBy_TableAssign_To(settings.UserId_Loged);


                            dbConnection DBConnection = new dbConnection();
                            string sScript = "SELECT t.Status_ID, COUNT(t.Status_ID) AS Count, s.Status FROM tbl_ptsTasks AS t INNER JOIN tbl_refStatus AS s ON t.Status_ID = s.Status_ID WHERE        (t.Assign_To = " + settings.UserId_Loged.ToString() + ") And s.isEnable_task=1 GROUP BY t.Status_ID, s.Status";
                            bool bQuaryStatus2 = DBConnection.SelectToDataTable(sScript);
                            if (bQuaryStatus2)
                                dgvSummary.DataSource = DBConnection.ResultTable;

                            timer1.Start();
                        }
                        else
                        {
                            MessageBox.Show("Invalid User");
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Query Error ####");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Config Error ####");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void btn_TimeSheetReport_Click(object sender, EventArgs e)
        {
            frmReports r = new frmReports();
            r.ShowDialog();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            dbConnection dbc = new dbConnection();
            dbc.Execute_Quary(@"BACKUP DATABASE [PTS] TO  DISK = N'D:\New folder (2)0\developer\SEACC_PTS\pts 2015-05-09.bak' WITH NOFORMAT, NOINIT,  STATS = 10 ");
        }

        private void ucUserIndicator1_Selection(string sResult)
        {
            switch (sResult)
            {
                case "Close":
                    tbl_UserActivity oActivity = new tbl_UserActivity(settings.UserId_Loged, 1, 2, DateTime.Now);
                    oActivity.Insert();
                    this.Close();
                    break;
                case "personalize":
                    frmSettings fSettings = new frmSettings();
                    fSettings.Show();
                    break;
                default:
                    break;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            #region Repeated Task summary(Funtion Wise)
            if (settings.UserId_Loged == 7)
            {
                try
                {
                    tbl_altAlert_Shedule oAlert = tbl_altAlert_Shedule.Select(clsFinder.getShaduleID(clsEnum.AutoSendEmail.RepeatedTask_Summary));

                    if (oAlert != null && oAlert.isActive)
                    {
                        if (oAlert.isDaily)
                        {
                            if (oAlert.lastAlert_SentTime.Date != DateTime.Now.Date)
                            {
                                if (oAlert.sheduledTime.TimeOfDay <= DateTime.Now.TimeOfDay)
                                {
                                    clsUtillMaill.createEmail_RepeatedTask_Summary();
                                    oAlert.lastAlert_SentTime = DateTime.Now;
                                    oAlert.Update();
                                }
                            }
                        }
                        else if (oAlert.isWeekly)
                        {
                            if (oAlert.lastAlert_SentTime.Date <= DateTime.Now.Date.AddDays(7) && DateTime.Now.Date.AddDays(-7) <= oAlert.lastAlert_SentTime.Date)
                            {
                                if (oAlert.sheduledTime.TimeOfDay <= DateTime.Now.TimeOfDay)
                                {
                                    clsUtillMaill.createEmail_WeeklyReportEngineerWise();
                                    oAlert.lastAlert_SentTime = DateTime.Now;
                                    oAlert.Update();
                                }
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

            #endregion

            if (settings.UserId_Loged == 100)
            {
                foreach (tbl_altAlert_Shedule oAlert in tbl_altAlert_Shedule.SelectAll().Where(p => p.isActive))
                {
                    #region MyRegion
                    if (oAlert.isDaily)
                    {
                        if (oAlert.lastAlert_SentTime.Date != DateTime.Now.Date)
                        {
                            if (oAlert.sheduledTime.TimeOfDay <= DateTime.Now.TimeOfDay)
                            {
                                frmReports report = new frmReports();
                                string sFilePath = report.PrintReport(true);
                                if (sFilePath != "")
                                {
                                    ArrayList LstEmailAddreses = new ArrayList();

                                    foreach (tbl_altAlert_Shedule_Users sHeduleUsers in tbl_altAlert_Shedule_Users.SelectAllByShedule_ID(oAlert.Shedule_ID))
                                    {
                                        foreach (tbl_masUser user in tbl_masUser.SelectAllByUserGroup_ID(sHeduleUsers.UserGroup_Id))
                                        {
                                            LstEmailAddreses.Add(user.EmailAddress);
                                        }
                                    }
                                    ArrayList lstAttachments = new ArrayList();
                                    lstAttachments.Add(sFilePath);
                                    Alert.SendMail(LstEmailAddreses, lstAttachments, "TimeSheet -" + DateTime.Now.ToString("dd-MM-yyyy-HH-mm"), "", false);
                                }
                                oAlert.lastAlert_SentTime = DateTime.Now;
                                oAlert.Update();
                            }
                        }
                    }
                    {
                        TimeSpan Span = (DateTime.Now - oAlert.lastAlert_SentTime);
                        int Hours = Span.Hours + Span.Days * 24;
                    }
                    #endregion

                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fr1 = new Form1();
            fr1.Show();
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSets.dts_PTS dtsPTS = new DataSets.dts_PTS();

            foreach (tbl_UserActivity oUserAct in tbl_UserActivity.SelectAll().Where(p => p.Time.Date == DateTime.Now.Date))
            {

            }

            dtsPTS.User_Login_Times.AddUser_Login_TimesRow("aa", "adad", "adad");
            dtsPTS.User_Login_Times.AddUser_Login_TimesRow("aa", "adad", "adad");
            dtsPTS.User_Login_Times.AddUser_Login_TimesRow("aa", "adad", "adad");
            dtsPTS.User_Login_Times.AddUser_Login_TimesRow("aa", "adad", "adad");


            List<emailLine> lstEData = new List<emailLine>();
            EmailLineformating oEmailLineFormat = new EmailLineformating();
            List<emailLine> lstEmailDetail = new List<emailLine>();

            lstEData.Add(new emailLine(LineType.H1, "Time Sheet"));
            lstEData.Add(new emailLine(LineType.H2, "As At 2015-01-01"));
            lstEData.Add(new emailLine(LineType.DataTable, dtsPTS.User_Login_Times));
            string sBodyHTML = Alert.CreateEmailBody(lstEData, oEmailLineFormat, null, null, null);

            ArrayList tolist = new ArrayList();
            ArrayList filelist = new ArrayList();

            tolist.Add("pd_leader@digiteq.biz");
            Alert.SendMailHTML("admin", tolist, filelist, "test", sBodyHTML, false);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //frmReports o = new frmReports();
            //o.Show();

            clsUtillMaill.createEmail_WeeklyReportEngineerWise();

        }
    }
}
