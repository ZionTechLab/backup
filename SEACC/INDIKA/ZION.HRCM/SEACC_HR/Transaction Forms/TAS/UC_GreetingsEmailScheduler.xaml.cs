using DataTire;
using Digiteq_Logic;
using SEACC_Alert_Engine;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using Digiteq.User_Contrals;

namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_GreetingsEmailScheduler.xaml
    /// </summary>
    public partial class UC_GreetingsEmailScheduler : System.Windows.Controls.UserControl
    {
        frm_BirthdayEmailSender oFrmBirthDayList = new frm_BirthdayEmailSender();

        public UC_GreetingsEmailScheduler()
        {
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Greetings_Email_Schedular;
            SEACC_Form.Initialize();

            #region Initialize DataTable
            dgr_Main.dt.Columns.Add("Greet_ID");
            dgr_Main.dt.Columns.Add("Greet_Party");
            dgr_Main.dt.Columns.Add("Greet_Type");
            dgr_Main.dt.Columns.Add("DateTime");
            #endregion

            #region  Button Initialize
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            #endregion

            #region Grid Initialize
            dgr_Main.Add_DatagridColoumn("Greet Id", "Greet_ID", 100);
            dgr_Main.Add_DatagridColoumn("Greet Party", "Greet_Party", 100);
            dgr_Main.Add_DatagridColoumn("Greet Type", "Greet_Type", 100);
            dgr_Main.Add_DatagridColoumn("Date Time", "DateTime", 120);
            #endregion

            ClearFields();
            RefreshGrid();
        }

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {

            if (SEACC_Form.ActualWidth < 850)
                coloumnA.Width = new GridLength(210);
            else
                coloumnA.Width = new GridLength(470);

        }
        #endregion

        #region Action Buttons

        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            //Can not Update
                            //Need to cancel and recreate
                        }
                    }
                    else
                    {
                        var vBirthdayEmps = oFrmBirthDayList.dt_EmpBirthdays.Select("IsSelect = '\uE0A2'");
                        if (vBirthdayEmps.Count() > 0)
                        {
                            DataTable dt_EmailTable = vBirthdayEmps.CopyToDataTable();
                            dt_EmailTable.Columns.Remove("IsSelect");
                            int iEmail_ID = clsAlerts_Email.CreateEmail_BirthdayListOfEmploees(enum_Alerts.EmployeeBirthdayListDaily, dtpTimeSlect.GetDateTime(), dt_EmailTable, txtEmailSubject.Text, txtAlertTo.Text);

                            tbl_tasGreeting oGreet = new tbl_tasGreeting(clsSecurity.CompanyID, clsSecurity.BranchID, txtGreetID.Text, cmbGreetParty.GetSelectedIndex(), cmbGreetType.GetSelectedIndex(), txtEmailSubject.Text, txtAlertTo.Text, txtAlertBCC.Text,
                                         cls_Formater.Convert_BitMapToByteArray(imgAlert.getImage() as BitmapImage), dtpTimeSlect.GetDateTime(), iEmail_ID, false, false, false, clsSecurity.UserIDLoged, "default", "default", "default", "default", clsSecurity.TerminalID, "default", "default", "default", "default", clsSecurity.getServerDateTime(), clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime, clsValidation.defaultDateTime);
                            oGreet.Insert();
                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                        }
                    }
                }
                catch (Exception ex)
                {
                    SEACCExeption.Show(ex);
                }
                finally
                {
                    ClearFields();
                    RefreshGrid();
                }
            }
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtGreetID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_tasGreeting oGreet = tbl_tasGreeting.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtGreetID.Tag.ToString());
                            if (oGreet != null)
                            {
                                tbl_utlAlertMailBox_Pending oAlert = tbl_utlAlertMailBox_Pending.Select(oGreet.EMail_ID);
                                if (oAlert != null && oAlert.Status != (int)EmailAlertStatus.SentMail)
                                {
                                    oGreet.IsCanceled = true;
                                    oGreet.Date_Canceled = clsSecurity.getServerDateTime();
                                    oGreet.TerminalID_Canceled = clsSecurity.TerminalID;
                                    oGreet.UserID_Canceled = clsSecurity.UserIDLoged;
                                    oGreet.Update();

                                    oAlert.Status = (int)EmailAlertStatus.CancelEmail;
                                    oAlert.Update();

                                    SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                    ClearFields();
                                    RefreshGrid();
                                }
                                else
                                {
                                    string sGreet_ID = txtGreetID.Tag.ToString();
                                    SEACCMessageBox.Show("Can not be cancelled", "The email has been already sent", MessageBoxButton.OK, "Red");
                                    ClearFields();
                                    RefreshGrid();
                                    fillDetails(sGreet_ID);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Refresh 

        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();
                foreach (tbl_tasGreeting oGreet in tbl_tasGreeting.SelectAll().Where(p => p.Greet_ID != "default" && p.IsCanceled == false))
                {
                    dgr_Main.dt.Rows.Add(oGreet.Greet_ID, clsHelpMethods.GetEnumDescription((GreetParty)oGreet.Greet_Party), clsHelpMethods.GetEnumDescription((GreetType)oGreet.Greet_Type), oGreet.Alert_Time.ToString(cls_Formater.Format_DateTime));
                }
                dgr_Main.RefreshGrid();
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
            finally
            {
                RefreshYear_Birthdays();
            }
        }

        private void RefreshYear_Birthdays()
        {
            cal_Big.SetMonth(new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1), true);
        }

        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_PrimaryKeyLabelTextBox(txtGreetID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEmailSubject, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAlertTo, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAlertBCC, true, false, false);

            txtGreetID.Tag = null;

            txtGreetID.Text = "";
            txtEmailSubject.Text = "";
            txtAlertTo.Text = "";
            txtAlertBCC.Text = "";

            cmbGreetParty.SetValues(typeof(GreetParty));
            cmbGreetParty.SetSelectedIndex(0);
            cmbGreetType.comboBox.ItemsSource = clsCommon.GetEnumDescription(typeof(Digiteq_Logic.GreetType));
            cmbGreetType.SetSelectedIndex(0);

            imgAlert.setImage(new BitmapImage(new Uri("/Resources/user.png", UriKind.Relative)));

            dtpTimeSlect.SetTime(DateTime.Now);

            #region Auto Generate Key
            if (SEACC_Form.isAutoGenaratedCode)
            {
                txtGreetID.setReadOnlyStatus(true);
                txtGreetID.Text = "<Auto Generate>";
            }
            else
                txtGreetID.setReadOnlyStatus(false);
            #endregion


            cal_Big.Visibility = Visibility.Visible;

        }
        #endregion

        private void cal_Big_Date_MouseClick(object sender, EventArgs e)
        {
            UC_CalanderDate o = sender as UC_CalanderDate;
            oFrmBirthDayList.RefreshGrid(o.Date);
            oFrmBirthDayList.ShowDialog();
        }


        #region Check validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateFiled())
                    bStatus = true;
            }
            return bStatus;
        }
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtGreetID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtEmailSubject))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                if (SEACC_Form.isAutoGenaratedCode)
                {
                    txtGreetID.Text = SEACC_Form.getAutoGeneratedCode();
                    txtGreetID.Tag = txtGreetID.Text;
                }

                tbl_tasGreeting oDetail = tbl_tasGreeting.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtGreetID.Text);
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }
        #endregion

        #region Fill Details
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_tasGreeting oGreet = tbl_tasGreeting.Select(clsSecurity.CompanyID, clsSecurity.BranchID, sID);
                    if (oGreet != null)
                    {
                        SEACC_Form.IsUpdateMode = true;

                        txtGreetID.Tag = oGreet.Greet_ID;

                        txtGreetID.Text = oGreet.Greet_ID;
                        txtEmailSubject.Text = oGreet.Email_Subj;
                        txtAlertTo.Text = oGreet.Email_To;
                        txtAlertBCC.Text = oGreet.Email_BCC;

                        cmbGreetParty.SetSelectedIndex(oGreet.Greet_Party);
                        cmbGreetType.SetSelectedIndex(oGreet.Greet_Type);

                        #region Employee Image
                        if (oGreet.Greet_Image != null)
                            if (oGreet.Greet_Image.Length > 0)
                            {
                                using (var stream = new MemoryStream(oGreet.Greet_Image))
                                {
                                    var bitmap = new BitmapImage();
                                    bitmap.BeginInit();
                                    bitmap.StreamSource = stream;
                                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                                    bitmap.EndInit();
                                    bitmap.Freeze();
                                    if (bitmap != null)
                                        imgAlert.setImage(bitmap);
                                }
                            }
                        #endregion


                        dtpTimeSlect.SetTime(oGreet.Alert_Time);

                        cal_Big.Visibility = Visibility.Collapsed;
                    }
                }

            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        private void dgr_Main_MouseLeftButtonUp1(object sender, EventArgs e)
        {
            try
            {
                object item = dgr_Main.grdMain.SelectedItem;
                if (item != null)
                {
                    string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    fillDetails(GridID);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }


        private void lblAlertPreview_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            if (SEACC_Form.IsUpdateMode)
            {
                tbl_tasGreeting oGreet = tbl_tasGreeting.Select(clsSecurity.CompanyID, clsSecurity.BranchID, txtGreetID.Tag.ToString());
                if (oGreet != null)
                {
                    tbl_utlAlertMailBox_Pending oAlert = tbl_utlAlertMailBox_Pending.Select(oGreet.EMail_ID);
                    if (oAlert != null)
                    {
                        string sBody = "<html><head></head><body>" + oAlert.Body + "</body><html>";
                        frm_AlertPreview oFrmAlert = new frm_AlertPreview();
                        oFrmAlert.wbAlertPreview.DocumentText = sBody;
                        oFrmAlert.ShowDialog();
                    }
                }
            }
            else
            {
                var vBirthdayEmps = oFrmBirthDayList.dt_EmpBirthdays.Select("IsSelect = '\uE0A2'");
                if (vBirthdayEmps.Count() > 0)
                {
                    DataTable dt_EmailTable = vBirthdayEmps.CopyToDataTable();
                    dt_EmailTable.Columns.Remove("IsSelect");

                    string sBody = "<html><head></head><body>" + clsEmailEngine.CreateEmailBody_Common(txtEmailSubject.Text, "", "", SEACC_Alert_Engine.Colors.New, dt_EmailTable) + "</body><html>";
                    frm_AlertPreview oFrmAlert = new frm_AlertPreview();
                    sBody = sBody.Replace("No. of payslips:", "");
                    sBody = sBody.Replace("<b>Important</b> !!", "");
                    oFrmAlert.wbAlertPreview.DocumentText = sBody;
                    oFrmAlert.ShowDialog();
                }
            }
        }
    }
}
