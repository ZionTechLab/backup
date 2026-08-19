using System;
using System.Collections.Generic;
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
using Digiteq_Logic;
using SEACC_WPFControls;
using DataTire;
using System.IO;
using Microsoft.Win32;
using System.Data;
using System.Threading;
using SEACC_servii.Search_Forms;
using System.Text.RegularExpressions;

namespace SEACC_servii.User_Management
{
    /// <summary>
    /// Interaction logic for UC_UserMaster.xaml
    /// </summary>
    public partial class UC_UserMaster : UserControl
    {
        #region Class variable
        DataTable dt = new DataTable();
        #endregion

        #region Form Load
        public UC_UserMaster()
        {
            InitializeComponent();
            SEACC_Form.enmFormName = FormName.UserCreation;
            SEACC_Form.Initialize();

            dgr_Main.dt.Columns.Add("UserID");
            dgr_Main.dt.Columns.Add("UserName");
            dgr_Main.dt.Columns.Add("UserGroup");

            #region Action Button Inilized
            SEACC_Form.SetVisibility_ActionButons(true, false, true, true);
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion


            dgr_Main.Add_DatagridColoumn("User ID", "UserID", 120);
            dgr_Main.Add_DatagridColoumn("User Name", "UserName", 150);
            dgr_Main.Add_DatagridColoumn("User Group", "UserGroup", 150);
                        
            CleaerFields();
            RefreshGrid();
        }

        #endregion

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
        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    #region Variables

                    bool bLogged = false;
                    bool bBlocked = false;
                    bool bLocked = false;

                    if (chk_Blocked.IsChecked == true)
                    {
                        bBlocked = true;
                    }
                    if (chk_Locked.IsChecked == true)
                    {
                        bLocked = true;
                    }
                    if (chk_logged.IsChecked == true)
                    {
                        bLogged = true;
                    }
                    #endregion

                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_securityUserMaster oldRecord = tbl_securityUserMaster.Select(txtUserID.Text.Trim());
                            if (oldRecord != null)
                            {
                                tbl_securityUserMaster OUserMaster = new tbl_securityUserMaster(txtUserID.Text, txtUserName.Text, clsSecurity.encryptPassword(txtPassword.Password.Trim()), "", txtEmail.Text, txtMobile.Text, "NEC", "192.168.10.10", DateTime.Now, bLogged, bBlocked, bLocked, txtGroupName.Tag.ToString(),
                                    cls_Formater.Convert_BitMapToByteArray(pbxImage.getImage() as BitmapImage), oldRecord.IsCanceled, oldRecord.UserID_Created, clsSecurity.UserIDLoged, oldRecord.UserID_Canceled, oldRecord.TerminalID_Created, clsSecurity.TerminalID, oldRecord.TerminalID_Canceled, oldRecord.Date_Created, clsSecurity.getServerDateTime(), oldRecord.Date_Canceled);

                                OUserMaster.Update();
                                //clsUtil.CreateEmail_ChangedPassword(OUserMaster.User_ID, txtPassword.Password);
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        tbl_securityUserMaster OUserMaster = new tbl_securityUserMaster(txtUserID.Text, txtUserName.Text, clsSecurity.encryptPassword(txtPassword.Password.Trim()), "", txtEmail.Text, txtMobile.Text, "NEC", "192.168.10.10", DateTime.Now, bLogged, bBlocked, bLocked, txtGroupName.Tag.ToString(),
                         cls_Formater.Convert_BitMapToByteArray(pbxImage.getImage() as BitmapImage), false, clsSecurity.UserIDLoged, "Default", "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                        OUserMaster.Insert();

                        //clsUtil.CreateEmail_ChangedPassword(OUserMaster.User_ID, txtPassword.Password);
                        SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
                }
                finally
                {
                    CleaerFields();
                    RefreshGrid();
                }
            }
        }

        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            CleaerFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SEACC_Form.IsUpdateMode)
                {
                    if (txtUserID.Tag != null)
                    {
                        bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                        if (bMessegeBoxResult)
                        {
                            tbl_securityUserMaster detail = tbl_securityUserMaster.Select(txtUserID.Text.Trim());
                            if (detail != null)
                            {
                                detail.IsCanceled = true;
                                detail.Date_Canceled = clsSecurity.getServerDateTime();
                                detail.UserID_Canceled = clsSecurity.UserIDLoged;
                                detail.TerminalID_Canceled = clsSecurity.TerminalID;
                                detail.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                                CleaerFields();
                                RefreshGrid();
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

        #region Clear Fields
        private void CleaerFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_LableTextbox(txtUserID, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtUserName, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtGroupName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtMobile, true, false, false);
            cls_Formater.SetEnableDisable_PasswordBox(txtPassword, true, false);
            cls_Formater.SetEnableDisable_PasswordBox(txtPassword2, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEmail, true, false, false);

            txtEmail.Text = "";
            txtGroupName.Text = "";
            txtMobile.Text = "";
            txtUserID.Text = "";
            txtUserName.Text = "";
            txtPassword.Password = "";
            txtPassword2.Password = "";

            txtUserID.Tag = null;
            txtGroupName.Tag = null;

            pbxImage.setImage(new BitmapImage(new Uri("/Resources/user.png", UriKind.Relative)));

            chk_Blocked.IsChecked = false;
            chk_Locked.IsChecked = false;
            chk_logged.IsChecked = false;

        }
        #endregion

        #region CheckValidity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateRecords())
                {
                    if (CheckValidity_Password())
                    {
                        if (CheckValidity_DuplicateUserName())
                        {
                            if (CheckValidity_EmailAddress())
                            {
                                if (CheckValidity_TelNo())
                                    bStatus = true;
                            }
                        }
                    }
                }
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;

            if (!clsValidation.Validate_EmptyValue(txtUserID))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtUserName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtPassword))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtPassword2))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtGroupName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtEmail))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateRecords()
        {
            bool bStatus = true;
            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_securityUserMaster oDetail = tbl_securityUserMaster.Select(txtUserID.Text);
                if (oDetail != null)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }
            return bStatus;
        }

        public bool CheckValidity_Password()
        {
            bool bStatus = false;
            if (txtPassword.Password != "" || txtPassword2.Password != "")
            {
                if (txtPassword.Password == txtPassword2.Password)
                    bStatus = true;
            }

            if (!bStatus)
                SEACCMessageBox.Show("Password Not Match", "", MessageBoxButton.OK);
            //SEACCMessageBox.Show("Password Not Match","");

            return bStatus;
        }

        public bool CheckValidity_DuplicateUserName()
        {
            bool bStatus = true;
            foreach (tbl_securityUserMaster detail in tbl_securityUserMaster.SelectAll().Where(p => p.UserName == txtUserName.Text && p.IsCanceled == false && p.User_ID != txtUserID.Text))
            {
                bStatus = false;
                SEACCMessageBox.Show(MessegeBoxType.FieldAlreadyExist, "User Name");
                break;
            }
            return bStatus;
        }

        public bool CheckValidity_EmailAddress()
        {
            bool bStatus = true;
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");

            if (!regex.IsMatch(txtEmail.Text))
            {
                bStatus = false;
                SEACCMessageBox.Show("Invalid Email Address", "", MessageBoxButton.OK);
            }

                return bStatus;
        }

        
        public bool CheckValidity_TelNo()
        {
            bool bStatus = true;

            if (txtMobile.Text.Trim().Length.ToString() != "10")
            {
                bStatus = false;
                SEACCMessageBox.Show("Invalid Telephone No.", "", MessageBoxButton.OK);
            }

                return bStatus;
        }

        #endregion

        #region RefreshGrid
        private void RefreshGrid()
        {
            try
            {
                dgr_Main.dt.Clear();

                foreach (tbl_securityUserMaster oUser in tbl_securityUserMaster.SelectAll().Where(p => p.IsCanceled == false))
                {
                    dgr_Main.dt.Rows.Add(oUser.User_ID, oUser.UserName, clsRef_Name.get_UserGroup_Name(oUser.Group_ID));
                }
                dgr_Main.RefreshGrid();
                //string Quary = "select [user_ID],[userName],[moible],[email] from tbl_securityUserMaster where IsCanceled=0 AND User_ID != 'default'";
                //dt = DBHandling.ExecQuery(Quary).Tables[0];
                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    grdUserMaster.ItemsSource = dt.DefaultView;
                //}
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region FillDetails
        private void fillDetails(string sID)
        {
            try
            {
                if (sID != null)
                {
                    tbl_securityUserMaster Ouser = tbl_securityUserMaster.Select(sID);
                    if (Ouser != null)
                    {
                        SEACC_Form.IsUpdateMode = true;
                        txtUserID.IsEnabled = false;
                        
                        txtUserID.Text = Ouser.User_ID;
                        txtEmail.Text = Ouser.Email;
                        txtMobile.Text = Ouser.Moible;
                        txtPassword.Password = clsSecurity.decryptPassword(Ouser.Password);
                        txtPassword2.Password = clsSecurity.decryptPassword(Ouser.Password);
                        txtUserName.Text = Ouser.UserName;
                        txtGroupName.Text = clsRef_Name.get_UserGroup_Name(Ouser.Group_ID);

                        txtUserID.Tag = Ouser.User_ID;
                        txtGroupName.Tag = Ouser.Group_ID;

                        if (Ouser.IsBlocked == true)
                        {
                            chk_Blocked.IsChecked = true;
                        }
                        else
                        {
                            chk_Blocked.IsChecked = false;
                        }
                        if (Ouser.IsLocked == true)
                        {
                            chk_Locked.IsChecked = true;
                        }
                        else
                        {
                            chk_Locked.IsChecked = false;
                        }
                        if (Ouser.IsLoged == true)
                        {
                            chk_logged.IsChecked = true;
                        }
                        else
                        {
                            chk_logged.IsChecked = false;
                        }

                        txtGroupName.Tag = Ouser.Group_ID;

                        if (Ouser.Image.Length > 0)
                        {
                            using (var stream = new MemoryStream(Ouser.Image))
                            {
                                var bitmap = new BitmapImage();
                                bitmap.BeginInit();
                                bitmap.StreamSource = stream;
                                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                                bitmap.EndInit();
                                bitmap.Freeze();
                                if (bitmap != null)
                                {
                                    pbxImage.setImage(bitmap);
                                }
                                else
                                {
                                    pbxImage.setImage(null);
                                }
                            }
                        }
                        else
                            pbxImage.setImage(null);
                    }
                }

            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }

        #endregion

        #region Search Events

        private void txtUserID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Users);
            if (RowDataSearch.DialogResult == true)
            {
                txtUserID.Text = lstResult[0];
                fillDetails(lstResult[0]);
            }
        }

        private void txtGroupName_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.UserGroups);
            if (RowDataSearch.DialogResult == true)
            {
                txtGroupName.Text = lstResult[1];
                txtGroupName.Tag = lstResult[0];
            }
        }
        #endregion

        #region Grid Event
        private void dgr_Main_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion
    }
}
