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
using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System.Data;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.IO;
using System.Net;
using System.Threading;


namespace Digiteq
{
    /// <summary>
    /// Interaction logic for UC_EmployeeMaster.xaml
    /// </summary>
    public partial class UC_EmployeeMaster : UserControl
    {
        #region Class Variable
        DataTable dt_Doc;
        int iDocumentNo;
        Uri oDocImage;
        //List<string> gender;
        //List<string> civilStatus;
        #endregion

        #region Form Load
        public UC_EmployeeMaster()
        {

            #region Initialize Variable
            dt_Doc = new DataTable();
            iDocumentNo = 0;
            //File Upload
            this.DataContext = this;
            //File Upload 

            //gender = new List<string>();
            //gender.Add("Male");
            //gender.Add("Female");

            //civilStatus = new List<string>();
            //civilStatus.Add("Single");
            //civilStatus.Add("Married");
            //civilStatus.Add("Widower");
            //civilStatus.Add("Widow");
            //civilStatus.Add("Divorced");
            #endregion

            #region Initialize Usercontrol
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Employee_Demography;
            SEACC_Form.Initialize();
            #endregion

            #region Initialize DataTable Main
            //dgr_Main.dt.Columns.Add("EmpNo");
            //dgr_Main.dt.Columns.Add("EPFNo");
            //dgr_Main.dt.Columns.Add("DeviceEmpNo");
            //dgr_Main.dt.Columns.Add("NICNo");
            //dgr_Main.dt.Columns.Add("EmpName");
            //dgr_Main.dt.Columns.Add("EmpDept");
            //dgr_Main.dt.Columns.Add("Ext");
            #endregion

            #region Initialize DataTable for Document Grid
            dt_Doc.Columns.Add("No");
            dt_Doc.Columns.Add("Icon");
            dt_Doc.Columns.Add("FileDetail");
            dt_Doc.Columns.Add("DocumentType");
            dt_Doc.Columns.Add("DocumentTypeTag");
            dt_Doc.Columns.Add("UploadDate");
            dt_Doc.Columns.Add("UploadBy");
            dt_Doc.Columns.Add("Download");
            dt_Doc.Clear();
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Save.Click += btn_Save_Click;
            #endregion

            #region Initialize DataGrid Main
            //dgr_Main.Add_DatagridColoumn("Employee No.", "EmpNo", 90);
            //dgr_Main.Add_DatagridColoumn("EPF No.", "EPFNo", 90);
            //dgr_Main.Add_DatagridColoumn("Dev. Emp No.", "DeviceEmpNo", 90);
            //dgr_Main.Add_DatagridColoumn("NIC No.", "NICNo", 100);
            //dgr_Main.Add_DatagridColoumn("Name.", "EmpName", 150);
            //dgr_Main.Add_DatagridColoumn("Department", "EmpDept", 100);
            //dgr_Main.Add_DatagridColoumn("Phone Ext", "Ext", 70);
            #endregion

            ClearFields();
            RefreshGrid();
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //if (SEACC_Form.ActualWidth < 850)
            //    coloumnA.Width = new GridLength(230);
            //else
            //    coloumnA.Width = new GridLength(580);
        }
        #endregion

        #region Action Button
        void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (SEACC_Form.IsUpdateMode)
            {
                if (txtEmployeeNo.Tag != null)
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show(MessegeBoxType.Cancel_Confirmation);
                    if (bMessegeBoxResult)
                    {
                        tbl_genMasEmployee detail = tbl_genMasEmployee.Select(txtEmployeeNo.Text.Trim(), clsSecurity.CompanyID, clsSecurity.BranchID);
                        if (detail != null)
                        {
                            detail.IsCanceled = true;
                            detail.Date_Canceled = clsSecurity.getServerDateTime();
                            detail.TerminalID_Canceled = clsSecurity.TerminalID;
                            detail.UserID_Canceled = clsSecurity.UserIDLoged;
                            detail.Update();

                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Canceled);
                            ClearFields();
                            RefreshGrid();
                        }
                    }
                }
            }
        }

        void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            if (CheckValidity())
            {
                try
                {
                    #region Variables
                    int nGender = 0; //0-not selected 1-Male 2-Female
                    int CivilStatus = 0; //0-Not Selected 1-Unmarried 2-Married 3-Widower 4-Widow 5-Devorced
                    bool Attendance = false;
                    bool pay = false;
                    bool SlipPrint = false;
                    bool EPF_ETF = false;
                    bool PayeeProcess = false;

                    if (cmb_Gender.GetSelectedIndex() == ((int)Gender.Male - 1))
                        nGender = (int)Gender.Male;
                    else if (cmb_Gender.GetSelectedIndex() == ((int)Gender.Female - 1))
                        nGender = (int)Gender.Female;

                    if (cmb_CivilStatus.GetSelectedIndex() == ((int)CivilState.Unmarried - 1))
                        CivilStatus = (int)CivilState.Unmarried;
                    else if (cmb_CivilStatus.GetSelectedIndex() == ((int)CivilState.Married - 1))
                        CivilStatus = (int)CivilState.Married;
                    else if (cmb_CivilStatus.GetSelectedIndex() == ((int)CivilState.Widower - 1))
                        CivilStatus = (int)CivilState.Widower;
                    else if (cmb_CivilStatus.GetSelectedIndex() == ((int)CivilState.Widow - 1))
                        CivilStatus = (int)CivilState.Widow;
                    else if (cmb_CivilStatus.GetSelectedIndex() == ((int)CivilState.Divorced - 1))
                        CivilStatus = (int)CivilState.Divorced;

                    if (chk_Attendance.IsChecked == true)
                    {
                        Attendance = true;
                    }
                    else
                    {
                        Attendance = false;
                    }
                    if (chk_Payroll.IsChecked == true)
                    {
                        pay = true;
                    }
                    else
                    {
                        pay = false;
                    }
                    if (chk_PaySlip.IsChecked == true)
                    {
                        SlipPrint = true;
                    }
                    else
                    {
                        SlipPrint = false;
                    }
                    if (chk_EPF_ETFProcess.IsChecked == true)
                    {
                        EPF_ETF = true;
                    }
                    else
                    {
                        EPF_ETF = false;
                    }
                    if (chk_PayeeProcess.IsChecked == true)
                    {
                        PayeeProcess = true;
                    }
                    else
                    {
                        PayeeProcess = false;
                    }
                    

                    string sEmployeeNo = txtEmployeeNo.Text;
                    string EmployeeTitle = txttitle.Tag.ToString();
                    string FullName = txtFullName.Text;
                    string initials = txtInitial.Text;
                    string sureName = txtSureName.Text;
                    string AliasName = txtAliasName.Text;
                    string NIC = txtNIC.Text;
                    string PassPort = txtPassport.Text;
                    string Nationality = txtNationality.Tag.ToString();
                    string Religion = txtReligion.Tag.ToString();
                    DateTime DOB = dtp_DOB.GetDateTime();
                    string Add1 = txtAdd1.Text;
                    string Add2 = txtAdd2.Text;
                    string Add3 = txtAdd3.Text;
                    string HomeTown = txtHomeTown.Tag.ToString();
                    string city = txtCity.Tag.ToString();
                    string dist = txtDistrict.Tag.ToString();
                    string Country = txtCountry.Tag.ToString();
                    string Postalcode = txtPostalCode.Tag.ToString();
                    string Telephone = txtHomeTelephone.Text;
                    string M1 = txtMobile.Text;
                    string M3 = txtMobile2.Text;
                    string OfficeMobile = txtOfficeMobile.Text;
                    string ImrgContNumber1 = txtImrgContact1.Text;
                    string ImrgContPerson1 = txtEmrgContPer1.Text;
                    string ImrgContNumber2 = txtImrgcontact2.Text;
                    string ImrgContPerson2 = txtimrgcontPer2.Text;
                    string PersonalEmail = txtEmail.Text;
                    string OfficeEmail = txtOfficeEmail.Text;
                    string EPF = txtEPF.Text;
                    string Designation = txtDesignation.Tag.ToString();
                    string EmployeeCategory1 = txtCategory.Tag.ToString();
                    string EmployeeCategory2 = txtCategory1.Tag.ToString();
                    string EmployeeCategory3 = txtCategory2.Tag.ToString();
                    string Department = txtDepartment.Tag.ToString();
                    string Section = txtSection.Tag.ToString();
                    string SubSection = txtSubSection.Tag.ToString();
                    string RecuirtmentType = txtRecuirtmentType.Tag.ToString();
                    DateTime DOJ = dtp_JoinDate.GetDateTime();
                    DateTime DOConf = dtp_DateOfConfirm.GetDateTime();
                    DateTime DOTermi = dtp_Terminate.GetDateTime();
                    DateTime DOLastWorking = dtpLastWorkingDate.GetDateTime();
                    DateTime DOPayrollEnd = dtp_PayrollEendDate.GetDateTime();
                    DateTime VisaEndDate = dtpVisaEndDate.GetDateTime();
                    string ManagerID = txtManagerID.Tag.ToString();
                    string SupevisorID = txtSupevisorId.Tag.ToString();
                    string AccountHoldername = txtAccountName.Text;
                    string AccountNo = txtAccountNo.Text;
                    string BankCode = txtBank.Tag.ToString();
                    string BankBranch = txtBranch.Tag.ToString();
                    string PayrillLavel = txtpayrollLavel.Tag.ToString();
                    string ProcessGroup = txtpayrollGroup.Tag.ToString();
                    string PayemntType = txtPayementBy.Tag.ToString();
                    string WorkingShift = txtEmployeeShiftCode.Tag.ToString();
                    string Division = txtDivision.Tag.ToString();
                    string GS_Division = txtGsDivision.Text;
                    string Status = cmb_EmpStatus.GetSelectedIndex().ToString();
                    string Province = txtProvince.Tag.ToString();
                    string acctShiftCode = string.Empty;
                    string AttendanceGroup1 = txtAttendanceGroup1.Tag.ToString();
                    string AttendanceGroup2 = txtAttendanceGroup2.Tag.ToString();
                    
                    if (txtEmployeeShiftCode.Text == "")
                    {
                        acctShiftCode = "default";
                    }
                    else
                    {
                        acctShiftCode = txtEmployeeShiftCode.Text;
                    }
                    Byte[] img = new byte[0];
                    #endregion

                    #region Update
                    if (SEACC_Form.IsUpdateMode)
                    {
                        if (SEACC_Form.CheckPermisshion_ToUpdate())
                        {
                            tbl_genMasEmployee oldRecord = tbl_genMasEmployee.Select(txtEmployeeNo.Text.Trim(), clsSecurity.CompanyID, clsSecurity.BranchID);
                            if (oldRecord != null)
                            {

                                tbl_genMasEmployee detail = new tbl_genMasEmployee(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployeeNo, txtEmployeeNo2.Text, EmployeeTitle, FullName, initials, sureName, AliasName, NIC, txtDriving_LicNO.Text, PassPort, Nationality, Religion, DOB, dtp_DateOfMerrage.GetDateTime(),
                                  nGender, CivilStatus, Add1, txtAdd2.Text, txtAdd3.Text, HomeTown, city, dist, Country, Postalcode, GS_Division, Province, Telephone, txtOfficeTelephone.Text, txtOfficeExt.Text, M1, M3, OfficeMobile, ImrgContNumber1, ImrgContPerson1, ImrgContNumber2,
                                  ImrgContPerson2, PersonalEmail, OfficeEmail, EPF, Designation, EmployeeCategory1, EmployeeCategory2, EmployeeCategory3, Department, Division, Section, SubSection, RecuirtmentType, DOJ, DOConf,
                                  DOTermi, DOLastWorking, DOPayrollEnd, VisaEndDate, ManagerID, SupevisorID, WorkingShift, Attendance, AttendanceGroup1, AttendanceGroup2, pay, SlipPrint, EPF_ETF, PayeeProcess, PayemntType,// acctShiftCode,
                                  AccountHoldername, AccountNo, BankCode, BankBranch, PayrillLavel, ProcessGroup, Status, cls_Formater.Convert_BitMapToByteArray(imgEmployee.getImage() as BitmapImage), false, false, false, false, false, false, false, false, chk_RosterEmployee.IsChecked, 0.00M, 0.00M, 0.00M, 0.00M, oldRecord.IsCanceled, oldRecord.UserID_Created, clsSecurity.UserIDLoged,
                                  oldRecord.UserID_Canceled, oldRecord.TerminalID_Created, clsSecurity.TerminalID, oldRecord.TerminalID_Canceled, oldRecord.Date_Created, clsSecurity.getServerDateTime(), oldRecord.Date_Canceled);
                                detail.Update();
                                SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                            }
                        }
                    }
                    #endregion

                    #region Insert
                    else
                    {
                        tbl_genMasEmployee Insert = new tbl_genMasEmployee(clsSecurity.CompanyID, clsSecurity.BranchID, sEmployeeNo, txtEmployeeNo2.Text, EmployeeTitle, FullName, initials, sureName, AliasName, NIC, txtDriving_LicNO.Text, PassPort, Nationality, Religion, DOB, dtp_DateOfMerrage.GetDateTime(),
                                     nGender, CivilStatus, Add1, txtAdd2.Text, txtAdd3.Text, HomeTown, city, dist, Country, Postalcode, GS_Division, Province, Telephone, txtOfficeTelephone.Text, txtOfficeExt.Text, M1, M3, OfficeMobile, ImrgContNumber1, ImrgContPerson1, ImrgContNumber2,
                                     ImrgContPerson2, PersonalEmail, OfficeEmail, EPF, Designation, EmployeeCategory1, EmployeeCategory2, EmployeeCategory3, Department, Division, Section, SubSection, RecuirtmentType, DOJ, DOConf,
                                     DOTermi, DOLastWorking, DOPayrollEnd, VisaEndDate, ManagerID, SupevisorID, WorkingShift, Attendance, AttendanceGroup1, AttendanceGroup2, pay, SlipPrint, EPF_ETF, PayeeProcess, PayemntType,// acctShiftCode,
                                     AccountHoldername, AccountNo, BankCode, BankBranch, PayrillLavel, ProcessGroup, Status, cls_Formater.Convert_BitMapToByteArray(imgEmployee.getImage() as BitmapImage), false, false, false, false, false, false, false, false, chk_RosterEmployee.IsChecked, 0.00M, 0.00M, 0.00M, 0.00M, false, clsSecurity.UserIDLoged, "Default",
                                     "Default", clsSecurity.TerminalID, "Default", "Default", clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime(), clsSecurity.getServerDateTime());
                        Insert.Insert();

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
                    ClearFields();
                    RefreshGrid();
                }
            }
        }

        //private void btn_SelectImage_Click(object sender, RoutedEventArgs e)
        //{
        //    imgEmployee.setImage(null);
        //    OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //    openFileDialog1.ShowDialog();
        //    imgEmployee.Source = null;
        //    Thread.Sleep(2000);
        //    ImageSource imageSource = new BitmapImage(new Uri(openFileDialog1.FileName));
        //    imgEmployee.Source = imageSource;
        //}

        private void btn_DocumentUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fldial = new OpenFileDialog();
            fldial.Multiselect = true;

            string result = fldial.ShowDialog().ToString();

            if (result == "True")
            {

                string sDocumentFolderName = AppDomain.CurrentDomain.BaseDirectory + "Employe Documents";

                #region Check Document Directory
                if (!System.IO.Directory.Exists(sDocumentFolderName))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(sDocumentFolderName);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                #endregion

                #region Save  File in to Document Folder
                foreach (string oFilePath in fldial.FileNames)
                {
                    foreach (string oFileName in fldial.SafeFileNames)
                    {
                        if (oFilePath.IndexOf(oFileName) != -1)
                        {
                            try
                            {
                                this.DocumentIconSetter(System.IO.Path.GetExtension(oFileName), ref oDocImage);

                                string sDestinationFolder = sDocumentFolderName + "\\" + oFileName;
                                if (System.IO.File.Exists(sDestinationFolder))
                                    sDestinationFolder = sDocumentFolderName + "\\_" + oFileName;

                                System.IO.File.Copy(oFilePath, sDestinationFolder, false);

                                dt_Doc.Rows.Add(iDocumentNo++, oDocImage, oFileName, txtDocumentType.Text, txtDocumentType.Tag != null ? txtDocumentType.Tag.ToString() : "", DateTime.Now.Date.ToString(clsConfig.Format_Date), clsSecurity.UserNameLoged, oFileName);


                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                        }
                    }
                }
                grd_DocumentManagement.ItemsSource = dt_Doc.DefaultView;
                #endregion
            }
        }
        #endregion

        #region Clear fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;
            cls_Formater.SetEnableDisable_LableTextbox(txtEmployeeNo, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEmployeeNo2, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtFullName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtInitial, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtSureName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAliasName, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtNIC, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDriving_LicNO, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPassport, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtNationality, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAdd1, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAdd2, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAdd3, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtHomeTown, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCity, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPostalCode, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtHomeTelephone, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtMobile, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtImrgContact1, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEmrgContPer1, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtimrgcontPer2, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtOfficeMobile, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEmail, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtProvince, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDivision, true, false, false);

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtpayrollLavel, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtpayrollGroup, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtEmployeeShiftCode, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtPayementBy, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBank, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtBranch, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEPF, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtOfficeExt, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtOfficeTelephone, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtDriving_LicNO, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDistrict, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCountry, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtOfficeMobile, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtImrgContact1, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEmrgContPer1, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtImrgcontact2, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtimrgcontPer2, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtOfficeEmail, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtOfficeMobile, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtReligion, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtOfficeMobile, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtMobile2, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txttitle, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCategory, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCategory1, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCategory2, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDepartment, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDesignation, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtManagerID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSupevisorId, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtSubSection, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCategory, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtRecuirtmentType, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAccountNo, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtAccountName, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtGsDivision, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtDocumentType, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtEmployeeShiftCode, true, false, false);

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAttendanceGroup1, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtAttendanceGroup2, true, false, false);

            //cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtStatus, true, false, false);
            //cls_Formater.SetEnableDisable_CheckBox(chk_Attendance, true);
            //cls_Formater.SetEnableDisable_CheckBox(chk_EPF_ETFProcess, true);
            //cls_Formater.SetEnableDisable_CheckBox(chk_PayeeProcess, true);
            //cls_Formater.SetEnableDisable_CheckBox(chk_Payroll, true);
            //cls_Formater.SetEnableDisable_CheckBox(chk_PaySlip, true);

            txtCategory.Text = "";
            txtEmployeeNo2.Text = "";
            txtRecuirtmentType.Text = "";
            txtpayrollLavel.Text = "";
            txtpayrollGroup.Text = "";
            txtPayementBy.Text = "";
            txtEmployeeShiftCode.Text = "";
            txtBank.Text = "";

            txtBranch.Text = "";
            txtAccountName.Text = "";
            txtAccountNo.Text = "";
            txtDepartment.Text = "";
            txtSection.Text = "";
            txtSubSection.Text = "";
            txtSupevisorId.Text = "";
            txtManagerID.Text = "";
            txtDesignation.Text = "";
            txttitle.Text = "";
            txtFullName.Text = "";
            txtMobile2.Text = "";
            txtInitial.Text = "";
            txtSureName.Text = "";
            txtAliasName.Text = "";
            txtOfficeEmail.Text = "";
            txtReligion.Text = "";
            txtDistrict.Text = "";
            txtNationality.Text = "";
            txtCountry.Text = "";
            txtOfficeMobile.Text = "";
            txtimrgcontPer2.Text = "";
            txtOfficeMobile.Text = "";
            txtNIC.Text = "";
            txtImrgcontact2.Text = "";
            txtPassport.Text = "";

            txtImrgContact1.Text = "";
            txtEmrgContPer1.Text = "";
            txtAdd1.Text = "";
            txtAdd2.Text = "";
            txtAdd3.Text = "";
            txtHomeTown.Text = "";
            txtCity.Text = "";
            txtPostalCode.Text = "";
            txtHomeTelephone.Text = "";
            txtMobile.Text = "";
            txtImrgContact1.Text = "";
            txtEmrgContPer1.Text = "";
            txtimrgcontPer2.Text = "";
            txtOfficeMobile.Text = "";
            txtEmail.Text = "";
            txtEmployeeNo.Text = "";
            txtEmployeeNo.Tag = null;
            txtEPF.Text = "";
            txtDocumentType.Text = "";
            //txtStatus.Text = "";
            txtDivision.Text = "";
            txtGsDivision.Text = "";
            txtCategory1.Text = "";
            txtCategory2.Text = "";
            txtProvince.Text = "";
            txtOfficeTelephone.Text = "";
            txtOfficeExt.Text = "";
            txtDriving_LicNO.Text = "";

            txtAttendanceGroup1.Text = "";
            txtAttendanceGroup2.Text = "";

            imgEmployee.setImage(new BitmapImage(new Uri("/Resources/user.png", UriKind.Relative)));

            chk_Attendance.IsChecked = false;
            chk_EPF_ETFProcess.IsChecked = false;
            chk_PayeeProcess.IsChecked = false;
            chk_Payroll.IsChecked = false;
            chk_PaySlip.IsChecked = false;
            chk_RosterEmployee.IsChecked = false;

            txtEmployeeShiftCode.Visibility = Visibility.Collapsed;
            lblDeaprtemnt_manager.Visibility = Visibility.Hidden;
            lblDesignation_manager.Visibility = Visibility.Hidden;
            lblDepat_Supevisor.Visibility = Visibility.Hidden;
            lblDesignation_Supevisior.Visibility = Visibility.Hidden;

            dtp_Terminate.SetTime(clsConfig.defaultDateTime);
            dtp_PayrollEendDate.SetTime(clsConfig.defaultDateTime);
            dtpLastWorkingDate.SetTime(clsConfig.defaultDateTime);
            dtp_DateOfConfirm.SetTime(clsConfig.defaultDateTime);
            dtp_DOB.SetTime(clsConfig.defaultDateTime);
            dtpVisaEndDate.SetTime(clsConfig.defaultDateTime);
            dtp_DateOfMerrage.SetTime(clsConfig.defaultDateTime);
            dtp_DateOfMerrage.SetTime(clsConfig.defaultDateTime);
            dtp_JoinDate.SetTime(clsConfig.defaultDateTime);

            txttitle.Tag = "Default";
            txtNationality.Tag = "Default";
            txtReligion.Tag = "Default";
            txtCountry.Tag = "Default";
            txtHomeTown.Tag = "Default";
            txtCity.Tag = "Default";
            txtDistrict.Tag = "Default";
            txtPostalCode.Tag = "Default";
            txtEmployeeShiftCode.Tag = "Default";
            txtPayementBy.Tag = "Default";
            txtBank.Tag = "Default";
            txtBranch.Tag = "Default";
            txtpayrollLavel.Tag = "Default";
            txtpayrollGroup.Tag = "Default";
            txtDesignation.Tag = "Default";
            txtCategory1.Tag = "Default";
            txtCategory2.Tag = "Default";
            txtCategory.Tag = "Default";
            txtDepartment.Tag = "Default";
            txtSection.Tag = "Default";
            txtSubSection.Tag = "Default";
            txtRecuirtmentType.Tag = "Default";
            txtManagerID.Tag = "Default";
            txtSupevisorId.Tag = "Default";
            //txtStatus.Tag = "Default";
            txtDivision.Tag = "Default";
            txtGsDivision.Tag = "Default";
            txtProvince.Tag = "Default";
            txtDocumentType.Tag = null;

            txtAttendanceGroup1.Tag = "Default";
            txtAttendanceGroup2.Tag = "Default";

            grd_ManagerDetail.Height = 0;
            grd_SupevisorDetails.Height = 0;


            if (!clsConfig.bEnableAttendanceGroup1)
            {
                txtAttendanceGroup1.Visibility = Visibility.Collapsed;
                txtAttendanceGroup2.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtAttendanceGroup1.Visibility = Visibility.Visible;
                txtAttendanceGroup2.Visibility = Visibility.Collapsed;
            }

            txtNationality.Tag = clsConfig.DefaultNationality;
            txtNationality.Text = clsRef_Name.get_Nationality_Name(clsConfig.DefaultNationality);
            txtCountry.Tag = clsConfig.DefaultCountry;
            txtCountry.Text = clsRef_Name.get_Country_Name(clsConfig.DefaultCountry);
            txtEmployeeShiftCode.Tag = clsConfig.DefaultShift;
            txtEmployeeShiftCode.Text = clsRef_Name.get_Shift_Name(clsConfig.DefaultShift);
            //txtStatus.Tag = clsConfig.DefaultEmployeeStatus;
            //txtStatus.Text = clsRef_Name.get_EmployeeStatus_Name(clsConfig.DefaultEmployeeStatus);

            cmb_Gender.SetValues(typeof(Gender));
            cmb_Gender.SetSelectedIndex(-1);

            cmb_CivilStatus.SetValues(typeof(CivilState));
            cmb_CivilStatus.SetSelectedIndex(-1);

            cmb_EmpStatus.SetValues(typeof(EmployeeStatus));
            cmb_EmpStatus.SetSelectedIndex(-1);

            dt_Doc.Clear();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            //try
            //{
            //    dgr_Main.dt.Clear();
            //    foreach (sp_genMasEmployee detail in sp_genMasEmployee.SelectAll().Where(p => p.Employee_ID != null && p.Employee_ID != "Default" && p.SurName != null && p.Department_ID != null && p.IsCanceled == false && p.Emp_statusID != ((int)EmployeeStatus.Resigned).ToString()).OrderBy(p => p.Employee_ID))
            //    {
            //        dgr_Main.dt.Rows.Add(detail.Employee_ID, detail.EpfNo, detail.Employee_ID2, detail.NicNo, detail.SurName + " " + detail.Initails, detail.DepartmentName, detail.Telephone_Ext);
            //    }
            //    dgr_Main.RefreshGrid();
            //}
            //catch (Exception ex)
            //{
            //    SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            //}
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            bool bStatus = false;
            if (CheckValidity_EmptyField())
            {
                if (CheckValidity_DuplicateFiled())
                    bStatus = true;
                if (!CheckValidity_NIC_Lengtgth())
                    bStatus = false;
                if (!CheckValidityMobileNo_Duplicates())
                    bStatus = false;
            }
            return bStatus;
        }

        private bool CheckValidity_EmptyField()
        {
            bool bStatus = true;
            if (!clsValidation.Validate_EmptyValue(txtEmployeeNo))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtFullName))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtNIC))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtAdd1))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtAdd2))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtAdd3))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtDesignation))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCategory))
                bStatus = false;
            if (!clsValidation.Validate_EmptyValue(txtCategory1))
                bStatus = false;

            return bStatus;
        }

        public bool CheckValidity_DuplicateFiled()
        {
            bool bStatus = true;
            string sEmployeesNIC_duplicates = "";


            if (!SEACC_Form.IsUpdateMode)
            {
                tbl_genMasEmployee detail = tbl_genMasEmployee.Select(txtEmployeeNo.Text.Trim(), clsSecurity.CompanyID, clsSecurity.BranchID);
                if (detail != null && detail.IsCanceled == false)
                {
                    bStatus = false;
                    SEACCMessageBox.Show(MessegeBoxType.RecordAlreadyExist);
                }
            }

            foreach (tbl_genMasEmployee detail in tbl_genMasEmployee.SelectAll().Where(p => p.NicNo == txtNIC.Text.Trim() && p.Employee_ID != txtEmployeeNo.Text))
            {
                    sEmployeesNIC_duplicates += "\n" + detail.Employee_ID + " - " + detail.FullName;
            }
            if (sEmployeesNIC_duplicates.Length > 3)
            {
                bool bMessageBoxStatus = SEACCMessageBox.Show("Are you sure ?", "The NIC you entered " + txtNIC.Text + " has already been belonged to : " + sEmployeesNIC_duplicates, MessageBoxButton.YesNo);
                if (!bMessageBoxStatus)
                    bStatus = false;
            }
           

            foreach (tbl_genMasEmployee detail in tbl_genMasEmployee.SelectAll().Where(p => p.Email == txtEmail.Text.Trim() && p.Employee_ID != txtEmployeeNo.Text && p.IsCanceled == false && p.Email != ""))
            {
                if (detail != null)
                {
                    SEACCMessageBox.Show("Oops...", "The personal email you entered is belongs to :'" + detail.FullName + "'", MessageBoxButton.OK);
                    bStatus = false;
                    break;
                }
            }

            foreach (tbl_genMasEmployee detail in tbl_genMasEmployee.SelectAll().Where(p => p.PassportNo == txtPassport.Text.Trim() && p.Employee_ID != txtEmployeeNo.Text && p.IsCanceled == false && p.PassportNo != ""))
            {
                if (detail != null)
                {
                    SEACCMessageBox.Show("Oops...", "The  Passport No. you entered is belongs to :'" + detail.FullName + "'", MessageBoxButton.OK);
                    bStatus = false;
                    break;
                }

            }

            foreach (tbl_genMasEmployee detail in tbl_genMasEmployee.SelectAll().Where(p => p.EpfNo == txtEPF.Text.Trim() && p.Division_ID == txtDivision.Tag.ToString() && p.Employee_ID != txtEmployeeNo.Text && p.IsCanceled == false && p.EpfNo != ""))
            {
                if (detail != null)
                {
                    SEACCMessageBox.Show("Oops...", "The  EPF No. you entered is belongs to :'" + detail.FullName + "'", MessageBoxButton.OK);
                    bStatus = false;
                    break;
                }
            }

            return bStatus;
        }

        public bool CheckValidity_NIC_Lengtgth()
        {
            bool bStatus = true;
            if (!(txtNIC.Text.Trim().Length == 10 || txtNIC.Text.Trim().Length == 12))
            {
                SEACCMessageBox.Show("Warning....", " Invalid NIC no", MessageBoxButton.OK);

                //  SEACCMessageBox.Show(MessegeBoxType.NICLangthValidation);
                bStatus = false;
            }
            return bStatus;
        }

        public bool CheckValidityMobileNo_Duplicates()
        {
            bool bStatus = true;
            if (txtMobile.Text != "" || txtMobile2.Text != "")
            {
                if (txtMobile.Text == txtMobile2.Text)
                {
                    SEACCMessageBox.Show("Warning....", "Mobile Numbers cannot be duplicate", MessageBoxButton.OK);
                    //  SEACCMessageBox.Show(MessegeBoxType.MobileNumberDuplicate);
                    bStatus = false;
                }
            }

            return bStatus;
        }
        #endregion

        #region Fill Data
        private void fillDetails(string sID)
        {
            try
            {
                tbl_genMasEmployee detail = tbl_genMasEmployee.Select(sID, clsSecurity.CompanyID, clsSecurity.BranchID);
                if (detail != null)
                {
                    SEACC_Form.IsUpdateMode = true;
                    txtEmployeeNo.IsEnabled = false;
                    txtEmployeeNo.Text = detail.Employee_ID;
                    txtEmployeeNo.Tag = detail.Employee_ID;
                    txtEmployeeNo2.Text = detail.Employee_ID2;
                    txtDriving_LicNO.Text = detail.DrivingLic_No;
                    dtp_DateOfMerrage.SetTime(detail.DateOfMerrage);
                    txtOfficeTelephone.Text = detail.Telephone_Office;
                    txtOfficeExt.Text = detail.Telephone_Ext;
                    if (detail.Employee_ID2 != null)
                    {
                        txtEmployeeNo2.IsEnabled = true;
                        txtEmployeeNo2.Text = detail.Employee_ID2;
                    }
                    if (detail.TitleID != "Default")
                    {
                        txttitle.Text = clsRef_Name.get_EmployeeTitle_Name(detail.TitleID);
                        txttitle.Tag = detail.TitleID;
                    }
                    txtFullName.Text = detail.FullName;
                    txtInitial.Text = detail.Initails;
                    txtSureName.Text = detail.SurName;
                    txtAliasName.Text = detail.AliasName;
                    txtNIC.Text = detail.NicNo;
                    txtPassport.Text = detail.PassportNo;
                    if (detail.Nationality_ID != "Default")
                    {
                        txtNationality.Text = clsRef_Name.get_Nationality_Name(detail.Nationality_ID);
                        txtNationality.Tag = detail.Nationality_ID;
                    }
                    if (detail.Religion_ID != "Default")
                    {
                        txtReligion.Text = clsRef_Name.get_Religion_Name(detail.Religion_ID);
                        txtReligion.Tag = detail.Religion_ID;
                    }

                    txtAdd2.Text = detail.AddressLine2;

                    #region Gender
                    if (detail.Gender == (int)Gender.Male)
                        cmb_Gender.SetSelectedIndex((int)Gender.Male - 1);
                    else if (detail.Gender == (int)Gender.Female)
                        cmb_Gender.SetSelectedIndex((int)Gender.Female - 1);
                    else
                        cmb_Gender.SetSelectedIndex(-1);
                    #endregion

                    #region Civil Status
                    if (detail.CivilState == (int)CivilState.Unmarried)
                        cmb_CivilStatus.SetSelectedIndex((int)CivilState.Unmarried - 1);
                    else if (detail.CivilState == (int)CivilState.Married)
                        cmb_CivilStatus.SetSelectedIndex((int)CivilState.Married - 1);
                    else if (detail.CivilState == (int)CivilState.Widower)
                        cmb_CivilStatus.SetSelectedIndex((int)CivilState.Widower - 1);
                    else if (detail.CivilState == (int)CivilState.Widow)
                        cmb_CivilStatus.SetSelectedIndex((int)CivilState.Widow - 1);
                    else if (detail.CivilState == (int)CivilState.Divorced)
                        cmb_CivilStatus.SetSelectedIndex((int)CivilState.Divorced - 1);
                    else
                        cmb_CivilStatus.SetSelectedIndex(-1);
                    #endregion

                    txtAdd1.Text = detail.AddressLine1;
                    txtAdd2.Text = txtAdd2.Text;
                    txtAdd3.Text = detail.AddressLine3;
                    if (detail.Town_ID != "Default")
                    {
                        txtHomeTown.Text = clsRef_Name.get_HomeTown_Name(detail.Town_ID);
                        txtHomeTown.Tag = detail.Town_ID;
                    }

                    if (detail.City_ID != "Default")
                    {
                        txtCity.Text = clsRef_Name.get_City_Name(detail.City_ID);
                        txtCity.Tag = detail.City_ID;
                    }

                    if (detail.District_ID != "Default")
                    {
                        txtDistrict.Text = clsRef_Name.get_District_Name(detail.District_ID);
                        txtDistrict.Tag = detail.District_ID;
                    }

                    if (detail.Country_ID != "Default")
                    {
                        txtCountry.Text = clsRef_Name.get_Country_Name(detail.Country_ID);
                        txtCountry.Tag = detail.Country_ID;
                    }

                    if (detail.PostalCode_ID != "Default")
                    {
                        tbl_genMasPostalCode postaCodeDetail = tbl_genMasPostalCode.Select(detail.PostalCode_ID);
                        txtPostalCode.Text = (postaCodeDetail.PostalCode) + "-" + clsRef_Name.get_PostalCode_Name(detail.PostalCode_ID);
                        txtPostalCode.Tag = detail.PostalCode_ID;
                    }
                    txtHomeTelephone.Text = detail.Telephone_Home;
                    txtMobile.Text = detail.Mobile1;
                    txtMobile2.Text = detail.Mobile2;
                    txtOfficeMobile.Text = detail.Mobile_Office;

                    txtEmrgContPer1.Text = detail.Emrg_ContactPerson1;
                    txtImrgContact1.Text = detail.Emrg_Contact1;

                    txtimrgcontPer2.Text = detail.Emrg_ContactPerson2;
                    txtImrgcontact2.Text = detail.Emrg_Contact2;

                    txtEmail.Text = detail.Email;
                    txtOfficeEmail.Text = detail.Email_office;
                    txtEPF.IsEnabled = true;
                    txtEPF.Text = detail.EpfNo;
                    if (detail.Designation_ID != "Default")
                    {
                        txtDesignation.Text = clsRef_Name.get_Designation_Name(detail.Designation_ID);
                        txtDesignation.Tag = detail.Designation_ID;
                    }
                    if (detail.EmpCatagory1_ID != "Default")
                    {
                        txtCategory.Text = clsRef_Name.get_EmployeeCategory1_Name(detail.EmpCatagory1_ID);
                        txtCategory.Tag = detail.EmpCatagory1_ID;
                    }
                    if (detail.EmpCatagory2_ID != "Default")
                    {
                        txtCategory1.Text = clsRef_Name.get_EmployeeCategory2_Name(detail.EmpCatagory2_ID);
                        txtCategory1.Tag = detail.EmpCatagory2_ID;
                    }
                    if (detail.EmpCatagory3_ID != "Default")
                    {
                        txtCategory2.Text = clsRef_Name.get_EmployeeCategory3_Name(detail.EmpCatagory3_ID);
                        txtCategory2.Tag = detail.EmpCatagory3_ID;
                    }
                    if (detail.Department_ID != "Default")
                    {
                        txtDepartment.Text = clsRef_Name.get_Department_Name(detail.Department_ID);
                        txtDepartment.Tag = detail.Department_ID;
                    }
                    if (detail.SectionID != "Default")
                    {
                        txtSection.Text = clsRef_Name.get_Section_Name(detail.SectionID);
                        txtSection.Tag = detail.SectionID;
                    }
                    if (detail.SubSectionID != "Default")
                    {
                        txtSubSection.Text = clsRef_Name.get_SubSection_Name(detail.SubSectionID);
                        txtSubSection.Tag = detail.SubSectionID;
                    }
                    if (detail.Employee_RecuirtmentType != "Default")
                    {
                        txtRecuirtmentType.Text = clsRef_Name.get_RecuirtmentType_Name(detail.Employee_RecuirtmentType);
                        txtRecuirtmentType.Tag = detail.Employee_RecuirtmentType;
                    }

                    dtp_JoinDate.SetTime(detail.DateJoin);
                    dtp_DateOfConfirm.SetTime(detail.DateConfirm);
                    dtp_Terminate.SetTime(detail.DateTerminate);
                    dtpLastWorkingDate.SetTime(detail.LastWorkingDate);

                    if (detail.ManagerID != "Default")
                    {
                        txtManagerID.Text = detail.ManagerID + "-" + clsRef_Name.get_EmployeeName(detail.ManagerID);
                        txtManagerID.Tag = detail.ManagerID;

                        grd_ManagerDetail.Height = 30;
                        foreach (tbl_genMasEmployee odetail in tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID == detail.ManagerID))
                        {
                            lblDeaprtemnt_manager.Visibility = Visibility.Visible;
                            lblDesignation_manager.Visibility = Visibility.Visible;

                            lblDeaprtemnt_manager.Content = "Depat : " + clsRef_Name.get_Department_Name(odetail.Department_ID);
                            lblDesignation_manager.Content = "Desig. : " + clsRef_Name.get_Designation_Name(odetail.Designation_ID);
                        }
                    }
                    if (detail.SupevisorID != "Defalut")
                    {
                        txtSupevisorId.Text = detail.SupevisorID + "-" + clsRef_Name.get_EmployeeName(detail.SupevisorID);
                        txtSupevisorId.Tag = detail.SupevisorID;

                        grd_SupevisorDetails.Height = 30;
                        foreach (tbl_genMasEmployee odetail in tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID == detail.SupevisorID))
                        {
                            lblDepat_Supevisor.Visibility = Visibility.Visible;
                            lblDesignation_Supevisior.Visibility = Visibility.Visible;
                            lblDepat_Supevisor.Content = "Department : " + clsRef_Name.get_Department_Name(odetail.Department_ID);
                            lblDesignation_Supevisior.Content = "Desig. : " + clsRef_Name.get_Designation_Name(odetail.Designation_ID);
                        }
                    }
                    if (detail.Shift_ID != "Default")
                    {
                        txtEmployeeShiftCode.Text = clsRef_Name.get_Shift_Name(detail.Shift_ID);
                        txtEmployeeShiftCode.Tag = detail.Shift_ID;
                    }

                    if (detail.IsTime_Attendance == true)
                    {
                        chk_Attendance.IsChecked = true;
                    }
                    else
                    {
                        chk_Attendance.IsChecked = false;
                    }

                    if (detail.IsPayrall_Process == true)
                    {
                        chk_Payroll.IsChecked = true;
                    }
                    else
                    {
                        chk_Payroll.IsChecked = false;
                    }

                    if (detail.IsPayslip_Print == true)
                    {
                        chk_PaySlip.IsChecked = true;
                    }
                    else
                    {
                        chk_PaySlip.IsChecked = false;
                    }

                    if (detail.IsEPF_ETF_Process == true)
                    {
                        chk_EPF_ETFProcess.IsChecked = true;
                    }
                    else
                    {
                        chk_EPF_ETFProcess.IsChecked = false;
                    }

                    if (detail.Is_PayeeProcess == true)
                    {
                        chk_PayeeProcess.IsChecked = true;
                    }
                    else
                    {
                        chk_PayeeProcess.IsChecked = false;
                    }

                    chk_RosterEmployee.IsChecked = detail.IsRosterBasedEmployee;

                    if (detail.PaymentMethod_ID != "Default")
                    {
                        txtPayementBy.Text = clsRef_Name.get_PayemntMethode_Name(detail.PaymentMethod_ID);
                        txtPayementBy.Tag = detail.PaymentMethod_ID;
                    }

                    txtAccountName.Text = detail.Employee_AccountName;
                    txtAccountNo.Text = detail.Employee_AccountNo;

                    if (detail.Bank_ID != "Default")
                    {
                        txtBank.Text = detail.Bank_ID + "-" + clsRef_Name.get_Bank_Name(detail.Bank_ID);
                        txtBank.Tag = detail.Bank_ID;
                    }


                    if (detail.BankBranch_ID != "Default")
                    {
                        tbl_genMasBankBranch bankDetail = tbl_genMasBankBranch.Select(detail.BankBranch_ID);
                        txtBranch.Text = bankDetail.BankBranch_code + "-" + bankDetail.BranchName;
                        txtBranch.Tag = detail.BankBranch_ID;
                    }
                    if (detail.Division_ID != "Default")
                    {
                        txtDivision.Tag = detail.Division_ID;
                        txtDivision.Text = clsRef_Name.get_Division_Name(detail.Division_ID);
                    }
                    if (detail.Emp_statusID != "Default")
                    {
                        cmb_EmpStatus.SetSelectedIndex(int.Parse(detail.Emp_statusID));
                    }

                    txtGsDivision.Text = detail.Gs_DivisionCode;

                    if (detail.Payroll_Level != "Default")
                    {
                        txtpayrollLavel.Text = clsRef_Name.get_ProllLevel_Name(detail.Payroll_Level);
                        txtpayrollLavel.Tag = detail.Payroll_Level;
                    }
                    if (detail.Payroll_ProcessGroupID != "Default")
                    {
                        txtpayrollGroup.Text = clsRef_Name.get_PayrollProcessGroup_Title(detail.Payroll_ProcessGroupID);
                        txtpayrollGroup.Tag = detail.Payroll_ProcessGroupID;
                    }

                    if (detail.Province_ID != "Default")
                    {
                        txtProvince.Text = clsRef_Name.get_Province_Name(detail.Province_ID);
                        txtProvince.Tag = detail.Province_ID;
                    }

                    if (detail.AttendanceGroup1_ID != "Default")
                    {
                        txtAttendanceGroup1.Text = clsRef_Name.get_Attendance_ProcessGroup1(detail.AttendanceGroup1_ID);
                        txtAttendanceGroup1.Tag = detail.AttendanceGroup1_ID;
                    }

                    if (detail.AttendanceGroup2_ID != "Default")
                    {
                        txtAttendanceGroup2.Text = clsRef_Name.get_Attendance_ProcessGroup2(detail.AttendanceGroup2_ID);
                        txtAttendanceGroup2.Tag = detail.AttendanceGroup2_ID;
                    }
                    
                    dtp_DOB.SetTime(detail.DateOfBirth);
                    dtpVisaEndDate.SetTime(detail.VisaEndDate);

                    #region Employee Image
                    if (detail.Employee_Image != null)
                        if (detail.Employee_Image.Length > 0)
                        {
                            using (var stream = new MemoryStream(detail.Employee_Image))
                            {
                                var bitmap = new BitmapImage();
                                bitmap.BeginInit();
                                bitmap.StreamSource = stream;
                                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                                bitmap.EndInit();
                                bitmap.Freeze();
                                if (bitmap != null)
                                    imgEmployee.setImage(bitmap);
                            }
                        }
                    #endregion

                }
            }
            catch (Exception ex)
            {
                SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            }
        }
        #endregion

        #region Grid Event
        private void grd_Employee_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //try
            //{
            //    object item = dgr_Main.grdMain.SelectedItem;
            //    if (item != null)
            //    {
            //        string GridID = (dgr_Main.grdMain.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            //        ClearFields();
            //        fillDetails(GridID);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    SEACCMessageBox.Show("Error", ex.Message, MessageBoxButton.OK);
            //}
        }
        #endregion

        #region Search Event

        #region Employee No
        private void txtEmployeeNo_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                ClearFields();
                txtEmployeeNo.Text = lstResult[0];
                string sEmpNI = lstResult[0].ToString();
                fillDetails(sEmpNI);
            }
        }
        #endregion

        #region Title
        private void txttitle_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Title);
            if (RowDataSearch.DialogResult == true)
            {
                txttitle.Text = lstResult[1];
                txttitle.Tag = lstResult[0];
            }
        }
        #endregion

        #region Nationality
        private void txtNationality_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Naltonality);
            if (RowDataSearch.DialogResult == true)
            {

                txtNationality.Tag = lstResult[0];
                txtNationality.Text = lstResult[1];
            }
        }
        #endregion

        #region Religion
        private void txtReligion_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Religions);
            if (RowDataSearch.DialogResult == true)
            {
                txtReligion.Tag = lstResult[0];
                txtReligion.Text = lstResult[1];
            }
        }
        #endregion

        #region Country
        private void txtCountry_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CountryMaster);
            if (RowDataSearch.DialogResult == true)
            {

                txtCountry.Text = lstResult[1];
                txtCountry.Tag = lstResult[0];
            }
        }
        #endregion

        #region City
        private void txtCity_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CityMaster);
            if (RowDataSearch.DialogResult == true)
            {
                txtCity.Text = lstResult[3];
                txtCity.Tag = lstResult[0];

                //txtDistrict.Text = lstResult[2];

                //txtProvince.Text = lstResult[1];
            }
        }
        #endregion

        #region District
        private void txtDistrict_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Districts);
            if (RowDataSearch.DialogResult == true)
            {

                txtDistrict.Text = lstResult[1];
                txtDistrict.Tag = lstResult[0];
            }
        }
        #endregion

        #region Postal Code
        private void txtPostalCode_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PostalCode);
            if (RowDataSearch.DialogResult == true)
            {

                txtPostalCode.Text = lstResult[1] + "-" + lstResult[2];
                txtPostalCode.Tag = lstResult[0];
            }
        }
        #endregion

        #region Shift
        private void txtEmployeeShiftCode_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Shift);
            if (RowDataSearch.DialogResult == true)
            {
                txtEmployeeShiftCode.Text = lstResult[1];
                txtEmployeeShiftCode.Tag = lstResult[0];
            }
        }
        #endregion

        #region Payment Type
        private void txtPayementBy_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PayemntTypes);
            if (RowDataSearch.DialogResult == true)
            {

                txtPayementBy.Text = lstResult[1];
                txtPayementBy.Tag = lstResult[0];
            }
        }
        #endregion

        #region Bank
        private void txtBank_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Banks);
            if (RowDataSearch.DialogResult == true)
            {
                txtBank.Text = lstResult[0] + " - " + lstResult[1];
                txtBank.Tag = lstResult[0];
            }
        }
        #endregion

        #region Bank Branch
        private void txtBranch_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            List<string> lstParameeters = new List<string>();
            if (txtBank.Tag != null && txtBank.Text != "")
            {
                lstParameeters.Add(txtBank.Tag.ToString());
            }
            frmSearch RowDataSearch = new frmSearch(lstParameeters);
            List<string> lstResult = RowDataSearch.Show(Search.BankBranch);
            if (RowDataSearch.DialogResult == true)
            {
                txtBranch.Tag = lstResult[0];
                txtBranch.Text = lstResult[3] + "-" + lstResult[2];
            }
        }
        #endregion

        #region Payroll Level
        private void txtpayrollLavel_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PayrollLevel);
            if (RowDataSearch.DialogResult == true)
            {
                txtpayrollLavel.Tag = lstResult[0];
                txtpayrollLavel.Text = lstResult[1];
            }
        }
        #endregion

        #region Payroll Process Group
        private void txtpayrollGroup_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.PayrollProcessGroup);
            if (RowDataSearch.DialogResult == true)
            {
                txtpayrollGroup.Tag = lstResult[0];
                txtpayrollGroup.Text = lstResult[1];
            }
        }
        #endregion

        #region Attendance Process Group
        private void txtAttendanceGroup1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.AttendanceProcessGroup1);
            if (RowDataSearch.DialogResult == true)
            {
                txtAttendanceGroup1.Tag = lstResult[0];
                txtAttendanceGroup1.Text = lstResult[1];
            }
        }

        private void txtAttendanceGroup2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.AttendanceProcessGroup2);
            if (RowDataSearch.DialogResult == true)
            {
                txtAttendanceGroup2.Tag = lstResult[0];
                txtAttendanceGroup2.Text = lstResult[1];
            }
        } 
        #endregion

        #region Designation
        private void txtDesignation_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Designations);
            if (RowDataSearch.DialogResult == true)
            {
                txtDesignation.Tag = lstResult[0];
                txtDesignation.Text = lstResult[1];
            }
        }
        #endregion

        #region Employee Category
        private void txtCategory_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.EmployeeCategory);
            if (RowDataSearch.DialogResult == true)
            {
                txtCategory.Text = lstResult[1];
                txtCategory.Tag = lstResult[0];
            }
        }
        #endregion

        #region Department
        private void txtDepartment_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Departments);
            if (RowDataSearch.DialogResult == true)
            {
                txtDepartment.Tag = lstResult[0];
                txtDepartment.Text = lstResult[1];
            }
        }
        #endregion

        #region Section
        private void txtSection_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Sections);
            if (RowDataSearch.DialogResult == true)
            {
                txtSection.Tag = lstResult[0];
                txtSection.Text = lstResult[1];
            }
        }
        #endregion

        #region Sub Section
        private void txtSubSection_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.SubSections);
            if (RowDataSearch.DialogResult == true)
            {
                txtSubSection.Tag = lstResult[0];
                txtSubSection.Text = lstResult[1];
            }
        }
        #endregion

        #region Recuirtment Type
        private void txtRecuirtmentType_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.RecruitmentTypes);
            if (RowDataSearch.DialogResult == true)
            {
                txtRecuirtmentType.Text = lstResult[1];
                txtRecuirtmentType.Tag = lstResult[0];
            }
        }
        #endregion

        #region Manager ID
        private void txtManagerID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                if (lstResult[0] == txtEmployeeNo.Text)
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show("Warning !", "you going to select  same employee as Manager.Are you sure do you want to continue", MessageBoxButton.YesNo);
                    if (bMessegeBoxResult)
                    {
                        txtManagerID.Text = lstResult[0] + " - " + lstResult[2];
                        txtManagerID.Tag = lstResult[0];

                        grd_ManagerDetail.Height = 30;
                        foreach (tbl_genMasEmployee odetail in tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID == lstResult[0]))
                        {
                            lblDeaprtemnt_manager.Visibility = Visibility.Visible;
                            lblDesignation_manager.Visibility = Visibility.Visible;

                            lblDeaprtemnt_manager.Content = "Dept. :" + clsRef_Name.get_Department_Name(odetail.Department_ID);
                            lblDesignation_manager.Content = "Desig. :" + clsRef_Name.get_Designation_Name(odetail.Designation_ID);
                        }
                    }
                }

                if (lstResult[0] != txtEmployeeNo.Text)
                {


                    txtManagerID.Text = lstResult[0] + " - " + lstResult[2];
                    txtManagerID.Tag = lstResult[0];

                    grd_ManagerDetail.Height = 30;
                    foreach (tbl_genMasEmployee odetail in tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID == lstResult[0]))
                    {
                        lblDeaprtemnt_manager.Visibility = Visibility.Visible;
                        lblDesignation_manager.Visibility = Visibility.Visible;

                        lblDeaprtemnt_manager.Content = "Dept. :" + clsRef_Name.get_Department_Name(odetail.Department_ID);
                        lblDesignation_manager.Content = "Desig. :" + clsRef_Name.get_Designation_Name(odetail.Designation_ID);
                    }
                }
            }
        }
        #endregion

        #region Supevisor ID
        private void txtSupevisorId_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Employee_Master);
            if (RowDataSearch.DialogResult == true)
            {
                if (lstResult[0] == txtEmployeeNo.Text)
                {
                    bool bMessegeBoxResult = SEACCMessageBox.Show("Warning !", "you going to select  same employee as Supervisor.Are you sure do you want to continue", MessageBoxButton.YesNo);
                    if (bMessegeBoxResult)
                    {
                        txtSupevisorId.Text = lstResult[0] + " - " + lstResult[2];
                        txtSupevisorId.Tag = lstResult[0];

                        grd_SupevisorDetails.Height = 30;
                        foreach (tbl_genMasEmployee odetail in tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID == lstResult[0]))
                        {
                            lblDepat_Supevisor.Visibility = Visibility.Visible;
                            lblDesignation_Supevisior.Visibility = Visibility.Visible;
                            lblDepat_Supevisor.Content = "Dept. :" + clsRef_Name.get_Department_Name(odetail.Department_ID);
                            lblDesignation_Supevisior.Content = "Desig. :" + clsRef_Name.get_Designation_Name(odetail.Designation_ID);
                        }
                    }
                }

                if (lstResult[0] != txtEmployeeNo.Text)
                {
                    txtSupevisorId.Text = lstResult[0] + " - " + lstResult[2];
                    txtSupevisorId.Tag = lstResult[0];

                    grd_SupevisorDetails.Height = 30;
                    foreach (tbl_genMasEmployee odetail in tbl_genMasEmployee.SelectAll().Where(p => p.Employee_ID == lstResult[0]))
                    {
                        lblDepat_Supevisor.Visibility = Visibility.Visible;
                        lblDesignation_Supevisior.Visibility = Visibility.Visible;
                        lblDepat_Supevisor.Content = "Dept. :" + clsRef_Name.get_Department_Name(odetail.Department_ID);
                        lblDesignation_Supevisior.Content = "Desig. :" + clsRef_Name.get_Designation_Name(odetail.Designation_ID);
                    }
                }
            }
        }
        #endregion

        #region Emp Category 2
        private void txtCategory1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.EmployeeCategory2);
            if (RowDataSearch.DialogResult == true)
            {
                txtCategory1.Text = lstResult[1];
                txtCategory1.Tag = lstResult[0];
            }
        }
        #endregion

        #region Employee Category 3
        private void txtCategory2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.EmployeeCategory3);
            if (RowDataSearch.DialogResult == true)
            {
                txtCategory2.Text = lstResult[1];
                txtCategory2.Tag = lstResult[0];
            }
        }
        #endregion

        #region Home Town
        private void txtHomeTown_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.HomeTown);
            if (RowDataSearch.DialogResult == true)
            {
                txtHomeTown.Text = lstResult[1];
                txtHomeTown.Tag = lstResult[0];
            }
        }
        #endregion

        #region Division
        private void txtDivision_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Division);
            if (RowDataSearch.DialogResult == true)
            {
                txtDivision.Text = lstResult[1];
                txtDivision.Tag = lstResult[0];
            }
        }
        #endregion

        #region Status
        //private void txtStatus_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    frmSearch RowDataSearch = new frmSearch();
        //    List<string> lstResult = RowDataSearch.Show(Search.Status);
        //    if (RowDataSearch.DialogResult == true)
        //    {
        //        txtStatus.Text = lstResult[1];
        //        txtStatus.Tag = lstResult[0];
        //    }
        //}

        private void txtDocumentType_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.DocumentType);
            if (RowDataSearch.DialogResult == true)
            {
                txtDocumentType.Text = lstResult[1];
                txtDocumentType.Tag = lstResult[0];
            }
        }
        #endregion

        #region Province
        private void txtProvince_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.ProvinceCode);
            if (RowDataSearch.DialogResult == true)
            {
                txtProvince.Text = lstResult[1];
                txtProvince.Tag = lstResult[0];
            }
        }
        #endregion

        #region GS Division
        private void txtGsDivision_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            frmSearch RowDataSearch = new frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.GN_Division);
            if (RowDataSearch.DialogResult == true)
            {
                txtGsDivision.Text = lstResult[1];
                txtGsDivision.Tag = lstResult[0];
            }
        }
        #endregion

        #endregion

        #region Others

        #region File Upload Event
        private static void Uploader(string filename, Stream Data)
        {
            BinaryReader reader = new BinaryReader(Data);

            string path = System.IO.Directory.GetCurrentDirectory();

            FileStream fstream = new FileStream(path, FileMode.CreateNew);
            BinaryWriter wr = new BinaryWriter(fstream);
            wr.Write(reader.ReadBytes((int)Data.Length));

            wr.Close();

            fstream.Close();
        }

        private void DocumentIconSetter(string extension, ref Uri oDocImage)
        {
            switch (extension.Trim())
            {
                case ".text":
                    oDocImage = new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\File Images\\Text-icon.png");
                    break;
                case ".txt":
                    oDocImage = new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\File Images\\txt-icon.png");
                    break;
                case ".xlsx":
                    oDocImage = new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\File Images\\Excel-icon.png");
                    break;
                case ".docx":
                    oDocImage = new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\File Images\\MS-Word.png");
                    break;
                case ".pdf":
                    oDocImage = new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\File Images\\PDF.png");
                    break;
                default:
                    oDocImage = new Uri(AppDomain.CurrentDomain.BaseDirectory + "\\File Images\\defualt.png");
                    break;
            }

        }
        #endregion

        private void Calculate_DOR(string gender, DateTime DOB)
        {
            if (gender == Gender.Male.ToString())
            {
                dtp_Terminate.SetTime(DOB.AddYears(55));
            }
            else if (gender == Gender.Female.ToString())
            {
                dtp_Terminate.SetTime(DOB.AddYears(50));
            }
        }

        private void redFemale_Checked(object sender, RoutedEventArgs e)
        {
            if (dtp_DOB.GetDateTime().Date != clsConfig.defaultDateTime)
            {
                Calculate_DOR(Gender.Female.ToString(), dtp_DOB.GetDateTime().Date);
            }
        }

        private void dtpDOB_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtp_DOB.GetDateTime().Date != clsConfig.defaultDateTime)
            {
                if (cmb_Gender.GetSelectedIndex() == 0)
                {
                    Calculate_DOR(Gender.Male.ToString(), dtp_DOB.GetDateTime().Date);
                }
                else
                {
                    Calculate_DOR(Gender.Female.ToString(), dtp_DOB.GetDateTime().Date);
                }
            }
        }
        #endregion

        #region Payroll Information - Checkbox Events
        private void chk_PayeeProcess_checkBox_Checked_1(object sender, EventArgs e)
        {
            try
            {
                txtTaxDirectiveRefNo.IsEnabled = true;
                txtAmountPAYEprocess.IsEnabled = true;
                cls_Formater.SetEnableDisable_LableTextbox(txtTaxDirectiveRefNo, true, false, false);
                cls_Formater.SetEnableDisable_LableTextbox(txtAmountPAYEprocess, true, false, false);
                dtp_StartDate.IsEnabled = true;
                dtp_EndDate.IsEnabled = true;
            }
            catch (Exception)
            {
                
            }
        }

        private void chk_PayeeProcess_checkBox_Unchecked(object sender, EventArgs e)
        {
            try
            {
                txtTaxDirectiveRefNo.IsEnabled = false;
                txtAmountPAYEprocess.IsEnabled = false;
                cls_Formater.SetEnableDisable_LableTextbox(txtTaxDirectiveRefNo, false, false, false);
                cls_Formater.SetEnableDisable_LableTextbox(txtAmountPAYEprocess, false, false, false);
                dtp_EndDate.IsEnabled = false;
                dtp_StartDate.IsEnabled = false;
            }
            catch (Exception)
            {
                
            }
        }
        #endregion

        #region Payroll - Employee
        private void lblEmpSalary_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (txtEmployeeNo.Tag != null)
            {
                Master_Forms.frm_Employee_PaySlipItems emp_PaySlipItems = new Master_Forms.frm_Employee_PaySlipItems(txtEmployeeNo.Tag.ToString(), true, true, clsConfig.defaultDateTime, clsConfig.defaultDateTime,true);
                if (emp_PaySlipItems.SEACC_Form.PermissionTO_Read)
                    emp_PaySlipItems.ShowDialog();
            }
            else
            {
                SEACCMessageBox.Show("Oops....", " Please Select an Employee ", MessageBoxButton.OK);
            }
        }
        #endregion

    }
}