using Express.Domain.Message;
using Express.Interfaces.Operations;
using Express.Interfaces.Report.Operation;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Enum;
using Express.UI.Common.Helpers;
using Express.UI.Factory.Operations;
using Express.UI.Factory.Report.Operation;
using Express.UI.Filters.View;
using Express.UI.Helpers;
using Express.View.Domain.Filters;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express.UI.Operation.View
{
    public partial class Principal_Accounts : Form, IDataManipulate
    {
        private readonly IPrincipleAccounts<PrincipleAccountsView> _principleAccounts;
        private readonly PrincipleAccountsView _principleAcNoSave = new PrincipleAccountsView();

        private bool initialLoad = true;
        private AgencyDomainViewcs oAgencyDomainViewcs = null;
        private List<AgencyDomainViewcs> agencyList = null;

        List<PrincipleAccountsView> AccountSummaryList = new List<PrincipleAccountsView>();
        List<PrincipleAccountsView> tmpAccountSummaryList = new List<PrincipleAccountsView>();

        private int agencyValue = 0;
        private int agencyValueTmp = 0;
        private int orgCodeText = 0;
        private string responseMSG = "Already exists";
        private string currentActNo = "";

        private string checkBox_active = "";
        private int tmpAgencyUP = 0;
        private string tmpAgenyNameUP = "";
        private int tmpOrgCodeUp = 0;
        private string tmpAccountNoUp = "";
        private int tmp2AgencyUP = 0;


        public FormStateEnum FormState { get; private set; }
        public Principal_Accounts()
        {
            InitializeComponent();

            if (_principleAccounts == null)
            {
                _principleAccounts = OperationsUIFacotry.GetService<IPrincipleAccounts<PrincipleAccountsView>>();
            }

            dataManipulate1.NewButtonClick += new EventHandler(NewMethod);
            dataManipulate1.SaveButtonClick += new EventHandler(SaveMethod);
           // dataManipulate1.EditButtonClick += new EventHandler(EditMethod);
            dataManipulate1.CancelButtonClick += new EventHandler(ClearMethod);
            dataManipulate1.CloseButtonClick += new EventHandler(CloseForm);
            dataManipulate1.DelteButtonClick += new EventHandler(DeleteMethod);
            dataManipulate1.PreviewButtonClick += new EventHandler(previewMethod);

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.DISABLEENABBLE);

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CLOSE, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PRINT, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PROCESS, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.HIDEVISIBLE);

            cmbAgency_Up.DisplayMember = "AgncyName";
            cmbAgency_Up.ValueMember = "AgncyCode";

            cmbAgency_Down.DisplayMember = "AgncyName";
            cmbAgency_Down.ValueMember = "AgncyCode";

            grdPrincipleAccounts.AllowUserToResizeColumns = false;

            txtAccountNo_Up.MaxLength = 10;
            txtRemarks.MaxLength = 10;

            chkAll_Agency.Checked = true;
            chkAll_Org.Checked = true;
            chkAll_AccountNo.Checked = true;

            txtAccountNo_Up.MaxLength = 10;
            txtAccountNo_Down.MaxLength = 10;
            txtRemarks.MaxLength = 10;

            chkActive.Checked = true;
            chkActive.Enabled = false;

            DisableFields_Down();
            GridFieldsDisable();

            txtOrgCode_Up.ReadOnly = true;
            txtOrgName_Up.ReadOnly = true;

            txtOrgCode_Down.ReadOnly = true;
            txtOrgName_Down.ReadOnly = true;

        }

        public void OrgCodeTextUp()
        {
            if (txtOrgCode_Up.Text != "")
            {
                orgCodeText = Convert.ToInt32(txtOrgCode_Up.Text);
            }
            else
            {
                txtOrgCode_Up.Text = "";
                orgCodeText = 0;
            }
        }
        public void ClearField_Up()
        {
            cmbAgency_Up.Text = "";
            txtOrgCode_Up.Text = "";
            txtOrgName_Up.Text = "";
            txtAccountNo_Up.Text = "";
            orgCodeText = 0;

        }
        public void ClearFields_Down()
        {
            cmbAgency_Down.Text = "";
            txtAccountNo_Down.Text = "";
            txtOrgCode_Down.Text = "";
            txtOrgName_Down.Text = "";
            txtRemarks.Text = "";
            orgCodeText = 0;
        }

        public void DisableFields_Up()
        {
            cmbAgency_Up.Enabled = false;
            //txtOrgCode_Up.ReadOnly = true;
            //txtOrgName_Up.ReadOnly = true;
            txtAccountNo_Up.ReadOnly = true;
            btnSearch.Enabled = false;
            btnCustomerSearch_Up.Enabled = false;

            chkAll_Agency.Enabled = false;
            chkAll_Org.Enabled = false;
            chkAll_AccountNo.Enabled = false;
        }

        public void EnableFields_Up()
        {
            cmbAgency_Up.Enabled = true;
            //txtOrgCode_Up.ReadOnly = true;
            //txtOrgName_Up.ReadOnly = true;
            txtAccountNo_Up.ReadOnly = false;
            btnCustomerSearch_Up.Enabled = true;
        }

        public void DisableFields_Down()
        {
            cmbAgency_Down.Enabled = false;
            //txtOrgCode_Down.ReadOnly = true;
            //txtOrgName_Down.ReadOnly = true;
            txtAccountNo_Down.ReadOnly = true;
            txtRemarks.ReadOnly = true;
            btnCustomerSearch_Down.Enabled = false;
            chkActive.Enabled = false;
        }

        public void EnableFields_Down()
        {
            cmbAgency_Down.Enabled = true;
            //txtOrgCode_Down.ReadOnly = true;
            //txtOrgName_Down.ReadOnly = true;
            txtAccountNo_Down.ReadOnly = false;
            txtRemarks.ReadOnly = false;
            btnCustomerSearch_Down.Enabled = true;
            chkActive.Enabled = true;
        }

        public void GridFieldsDisable()
        {
            grdPrincipleAccounts.Columns["AgncyName"].ReadOnly = true;
            grdPrincipleAccounts.Columns["OrgCode"].ReadOnly = true;
            grdPrincipleAccounts.Columns["OrgName"].ReadOnly = true;
            grdPrincipleAccounts.Columns["Remarks"].ReadOnly = true;
            grdPrincipleAccounts.Columns["AcNo"].ReadOnly = true;
            grdPrincipleAccounts.Columns["Remarks"].ReadOnly = true;
            grdPrincipleAccounts.Columns["Active"].ReadOnly = true;
            grdPrincipleAccounts.Columns["DeleteDate"].ReadOnly = true;
            grdPrincipleAccounts.Columns["UserID"].ReadOnly = true;
        }

        public void ShowGridView()
        {
            if (TextValidator.IsSpecialChar(txtAccountNo_Up.Text))
            {
                var showGrid = _principleAccounts.GetPrincipleAccountGrid(agencyValue, orgCodeText, txtAccountNo_Up.Text);
                grdPrincipleAccounts.AutoGenerateColumns = false;
                grdPrincipleAccounts.DataSource = showGrid.ToList();

                AccountSummaryList = showGrid.ToList();
            }
            else
            {
                txtAccountNo_Up.Text = "";
                MessageBox.Show("Account No contains invalid characters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void EditButtonDisable()
        {
            if (grdPrincipleAccounts.DataSource == null)
            {
                dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            }
        }

        public void ShowGridView_NewAdd()
        {
            var showGrid = _principleAccounts.GetPrincipleAccountGrid(agencyValue, orgCodeText, txtAccountNo_Down.Text);
            grdPrincipleAccounts.AutoGenerateColumns = false;
            grdPrincipleAccounts.DataSource = showGrid.ToList();
        }

        public void ClearMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.Clear;

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.DISABLEENABBLE);

            grdPrincipleAccounts.DataSource = null;
            grdPrincipleAccounts.Enabled = true;
            ClearFields_Down();
            DisableFields_Down();
            ClearField_Up();

            btnSearch.Enabled = true;
            chkAll_Agency.Enabled = true;
            chkAll_Org.Enabled = true;
            chkAll_AccountNo.Enabled = true;

            chkAll_Agency.Checked = true;
            chkAll_Org.Checked = true;
            chkAll_AccountNo.Checked = true;
            agencyValue = 0;
            tmpAgencyUP = 0;

        }

        public void CloseForm(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void DeleteMethod(object param, EventArgs e)
        {
            if (txtAccountNo_Down.Text !="") {

                DialogResult result = MessageBox.Show("Do you want to delete Account No: " + txtAccountNo_Down.Text, "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    _principleAccounts.DeleteData(txtAccountNo_Down.Text);
                    ClearField_Up();
                    ClearFields_Down();
                  //  cmbAgency_Up.Text = tmpAgenyNameUP;

                    //grdPrincipleAccounts.Update();
                    //grdPrincipleAccounts.Refresh();

                    var showGrid = _principleAccounts.GetPrincipleAccountGrid(tmpAgencyUP, tmpOrgCodeUp, tmpAccountNoUp);
                    grdPrincipleAccounts.AutoGenerateColumns = false;
                    grdPrincipleAccounts.DataSource = showGrid.ToList();

                    // ShowGridView();
                }
                else { }

                
            }
            else
            {
                MessageBox.Show("Select data to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        public void EditMethod(object param, EventArgs e)
        {
            //FormState = FormStateEnum.Update;
            //agencyValue = agencyValueTmp;

            //if (txtOrgCode_Down.Text != "")
            //{
            //    grdPrincipleAccounts.Enabled = false;
            //    chkActive.Enabled = true;

            //    dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            //    dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            //    dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
            //    dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            //    dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.DISABLEENABBLE);

            //    DisableFields_Up();
            //    DisableFields_Down();
            //    txtAccountNo_Down.ReadOnly = false;
            //    txtRemarks.ReadOnly = false;
            //    chkActive.Enabled = true;
            //}
            //else
            //{
            //    MessageBox.Show("Select data to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}

        }

        public void FilterMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ImportMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void NewMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.New;

            // grdPrincipleAccounts.Enabled = false;
            chkActive.Enabled = true;
            grdPrincipleAccounts.DataSource = null;
            agencyValue = 0;
            tmpAgencyUP = 0;


            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);

            ClearField_Up();
            ClearFields_Down();
            DisableFields_Up();
            EnableFields_Down();


        }

        public void previewMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.PrintPreview;
           // tmpAccountSummaryList.Clear();

            tmpAccountSummaryList = AccountSummaryList.Where(z => z.Active.Equals("Y")).ToList();

            if (tmpAccountSummaryList.Count > 0)
            {
                PrincipleAccountsView accountDomain = new PrincipleAccountsView();

                 var select = accountDomain;

                //var select = (PrincipleAccountsView).SelectedItem;
                IOperationReportProvider _report = RptOperationUIFactory.GetService<IOperationReportProvider>();
                tmpAccountSummaryList.ForEach(cc => cc.CMPY = select == null ? 1 : select.CMPY);
              
                _report.GetPrincipleAccountsReport(tmpAccountSummaryList);

                //var showGrid = _principleAccounts.GetPrincipleAccountGrid(tmpAgencyUP, tmpOrgCodeUp, tmpAccountNoUp);
                //grdPrincipleAccounts.AutoGenerateColumns = false;
                //grdPrincipleAccounts.DataSource = showGrid.ToList();

            }
            else
            {
                MessageNotification.MessageBoxOK("No data", "ERROR");
            }
        }

        public void PrintMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ProccessMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void SaveMethod(object param, EventArgs e)
        {
            //GridFieldsDisable();
            if (TextValidator.IsSpecialChar(txtAccountNo_Down.Text))
            {
                if (agencyValue > 0 && txtOrgCode_Down.Text != "" && txtAccountNo_Down.Text != "")
                {
                    //agencyValueTmp

                    FormState = (FormState != FormStateEnum.Update) ? FormStateEnum.Save : FormStateEnum.Update;
                    ResponseMessage responce = null;

                    string x = "";

                    //DateTime xz = ;

                    _principleAcNoSave.USM_ID = 1;
                    //_principleAcNoSave.USM_Date = DateTime.Now;
                    //_principleAcNoSave.DelUSM_ID = 1;
                    //_principleAcNoSave.DelUSM_Date = DateTime.Now;
                    _principleAcNoSave.Deleted = 0;

                    _principleAcNoSave.AgncyCode = agencyValue;
                    _principleAcNoSave.OrgCode = Convert.ToInt32(txtOrgCode_Down.Text);
                    _principleAcNoSave.AcNo = txtAccountNo_Down.Text;
                    _principleAcNoSave.CurrentActNo = currentActNo.ToString();
                    _principleAcNoSave.Remarks = txtRemarks.Text;
                    _principleAcNoSave.Active = checkBox_active;



                    //grdRouteMaster.AutoGenerateColumns = false;

                    var vResult = CustomValidate.Instance.ValidateModel(_principleAcNoSave);


                    if (vResult == "")
                    {

                        if (FormState == FormStateEnum.Save)
                        {
                            responce = _principleAccounts.SaveDetails(_principleAcNoSave);
                        }
                        if (FormState == FormStateEnum.Update)
                        {
                            responce = _principleAccounts.EditDetails(_principleAcNoSave);
                        }


                        if (responce.IsSuccess) // after save result
                        {

                            MessageBox.Show("Save Successful", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);

                            // ShowGridView();
                            ShowGridView_NewAdd();
                            ClearFields_Down();
                            ClearField_Up();
                            DisableFields_Up();
                            DisableFields_Down();
                            FormState = FormStateEnum.Clear;

                            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.DISABLEENABBLE);
                            dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.DISABLEENABBLE);

                            //txtRouteCode.ReadOnly = true;
                            //txtRouteName.ReadOnly = true;
                            txtRemarks.ReadOnly = true;
                            chkActive.Enabled = false;
                            chkActive.Checked = true;
                            grdPrincipleAccounts.Enabled = true;

                            //grdRouteMaster.Enabled = true;

                        }

                        string response = responce.StrMessage;


                        if (String.Equals(response, responseMSG))
                        {
                            if (FormState == FormStateEnum.Save)
                            {
                                MessageBox.Show("Account No already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                ClearFields_Down();
                            }
                            if (FormState == FormStateEnum.Update)
                            {
                                MessageBox.Show("Account No already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtAccountNo_Down.Text = "";
                            }
                        }
                    }
                }
                else if (agencyValue == 0 && txtOrgCode_Down.Text.Equals("") && txtAccountNo_Down.Text.Equals(""))
                {
                    MessageBox.Show("Please select an Agency code, Organization & Account No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (agencyValue == 0 && txtOrgCode_Down.Text.Equals(""))
                {
                    MessageBox.Show("Please select an Agency Code & Organization", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (agencyValue == 0 && txtAccountNo_Down.Text.Equals(""))
                {
                    MessageBox.Show("Please select an Agency Code & Account No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (txtOrgCode_Down.Text.Equals("") && txtAccountNo_Down.Text.Equals(""))
                {
                    MessageBox.Show("Please select an Organization Code & Account No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (agencyValue == 0)
                {
                    MessageBox.Show("Please select an Agency Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbAgency_Down.Text = "";
                }

                else if (txtOrgCode_Down.Text.Equals(""))
                {
                    MessageBox.Show("Please select an Organization", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (txtAccountNo_Down.Text.Equals(""))
                {
                    MessageBox.Show("Please select an Account No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                txtAccountNo_Down.Text = "";
                MessageBox.Show("Account No contains invalid characters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Principal_Accounts_Load(object sender, EventArgs e)
        {
            try
            {
                agencyList = _principleAccounts.GetAgencyDetail(1, 200, 1002).ToList<AgencyDomainViewcs>();
                cmbAgency_Up.DataSource = agencyList;
                cmbAgency_Up.SelectedItem = null;

                //cmbAgency_Down.BindingContext = new BindingContext();
                                
                cmbAgency_Down.DataSource = agencyList;
                cmbAgency_Down.SelectedItem = null;
                initialLoad = false;

            }
            catch
            {
                MessageNotification.MessageBoxError("Application Loading Failure", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
        }

        private void cmbAgency_Up_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!initialLoad)
                {
                    oAgencyDomainViewcs = (AgencyDomainViewcs)cmbAgency_Up.SelectedItem;
                    // int index = cmbAgency_Up.Items.IndexOf(oAgencyDomainViewcs);
                    agencyValue = oAgencyDomainViewcs.AgncyCode;
                    tmpAgencyUP = agencyValue;

                    if (cmbAgency_Down.Text != "" && chkAll_Agency.Checked == true)
                    {

                        cmbAgency_Up.Text = "";
                        tmpAgenyNameUP = "";
                        tmpAgencyUP = 0;
                    }

                }
            }
            catch (Exception EX)
            {
                MessageNotification.MessageBoxError("Application Loading Failure", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (chkAll_Agency.Checked == false && chkAll_Org.Checked == false && chkAll_AccountNo.Checked == false && agencyValue == 0 && txtOrgCode_Up.Text.Equals("")
                && txtAccountNo_Up.Text.Equals(""))
            {
                MessageBox.Show("Please enter a value to find", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (chkAll_Agency.Checked == false && agencyValue == 0 && chkAll_Org.Checked == false && txtOrgCode_Up.Text.Equals(""))
            {
                MessageBox.Show("Please select an Agency & Organization", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (chkAll_Agency.Checked == false && agencyValue == 0 && chkAll_AccountNo.Checked == false && txtAccountNo_Up.Text.Equals(""))
            {
                MessageBox.Show("Please select an Agency & Account No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (chkAll_Org.Checked == false && txtOrgCode_Up.Text.Equals("") && chkAll_AccountNo.Checked == false && txtAccountNo_Up.Text.Equals(""))
            {
                MessageBox.Show("Please select an Organization & Account No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            else if (chkAll_Agency.Checked == false && agencyValue == 0)
            {
                MessageBox.Show("Please select an Agency", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (chkAll_Org.Checked == false && txtOrgCode_Up.Text.Equals(""))
            {
                MessageBox.Show("Please select an Organization", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            else if (chkAll_AccountNo.Checked == false && txtAccountNo_Up.Text.Equals(""))
            {
                MessageBox.Show("Please select an Account No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
            else if (agencyValue > 0 || txtOrgCode_Up.Text != "" || txtAccountNo_Up.Text != "")
            {
                OrgCodeTextUp();
                ShowGridView();
                grdPrincipleAccounts.Enabled = true;
                ClearFields_Down();
               // agencyValue = 0;
                dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            }
            else
            {
                grdPrincipleAccounts.DataSource = null;
                ClearField_Up();
                ShowGridView();
                //agencyValue = 0;
                dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);

            }

        }

        private void cmbAgency_Down_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!initialLoad)
                {
                    oAgencyDomainViewcs = (AgencyDomainViewcs)cmbAgency_Down.SelectedItem;
                    // int index = cmbAgency_Up.Items.IndexOf(oAgencyDomainViewcs);
                    agencyValue = oAgencyDomainViewcs.AgncyCode;

                }
            }
            catch (Exception EX)
            {
                MessageNotification.MessageBoxError("Application Loading Failure", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
            }
        }

        private void chkAll_Agency_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll_Agency.Checked == true)
            {
                cmbAgency_Up.Enabled = false;
                agencyValue = 0;
                cmbAgency_Up.Text = "";
                grdPrincipleAccounts.DataSource = null;
                ClearFields_Down();
                EditButtonDisable();
                               
            }
            else
            {
                cmbAgency_Up.Enabled = true;
                grdPrincipleAccounts.DataSource = null;
                ClearFields_Down();
                EditButtonDisable();

                dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.DISABLEENABBLE);
            }
        }

        private void chkAll_Org_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll_Org.Checked == true)
            {
                btnCustomerSearch_Up.Enabled = false;
                grdPrincipleAccounts.DataSource = null;
                ClearFields_Down();
                EditButtonDisable();

                txtOrgCode_Up.Text = "";
                txtOrgName_Up.Text = "";

            }
            else
            {
                btnCustomerSearch_Up.Enabled = true;
                grdPrincipleAccounts.DataSource = null;
                ClearFields_Down();
                EditButtonDisable();

                dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.DISABLEENABBLE);
            }
        }

        private void chkAll_AccountNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll_AccountNo.Checked == true)
            {
                txtAccountNo_Up.ReadOnly = true;
                txtAccountNo_Up.Text = "";
                grdPrincipleAccounts.DataSource = null;
                ClearFields_Down();
                EditButtonDisable();
            }
            else
            {
                txtAccountNo_Up.ReadOnly = false;
                grdPrincipleAccounts.DataSource = null;
                ClearFields_Down();
                EditButtonDisable();

                dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.DISABLEENABBLE);
            }
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActive.Checked == true)
            {
                checkBox_active = "Y";
            }
            else
            {
                checkBox_active = "";
            }
        }

        private void grdPrincipleAccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {

                    DataGridViewRow row = this.grdPrincipleAccounts.Rows[e.RowIndex];

                    //int x = Convert.ToInt32(row.Cells["AgncyCode"].Value.ToString());
                    cmbAgency_Down.Text = row.Cells["AgncyName"].Value.ToString();
                    txtOrgCode_Down.Text = row.Cells["OrgCode"].Value.ToString();
                    txtOrgName_Down.Text = row.Cells["OrgName"].Value.ToString();
                    txtAccountNo_Down.Text = row.Cells["AcNo"].Value.ToString();
                    txtRemarks.Text = row.Cells["Remarks"].Value.ToString();
                    checkBox_active = row.Cells["Active"].Value.ToString();
                    currentActNo = row.Cells["AcNo"].Value.ToString();
                    agencyValue = Convert.ToInt32(row.Cells["AgncyCode"].Value.ToString());

                    //cmbAgency_Up.Text = "";

                   // agencyValueTmp = agencyValue;
                    agencyValue = 0;
                                

                    if (cmbAgency_Down.Text != "" && chkAll_Agency.Checked == true)
                    {
                      
                        cmbAgency_Up.Text = "";
                        tmpAgenyNameUP = "";
                        tmpAgencyUP = 0;
                    }

                    if(chkAll_Org.Checked == true)
                    {
                        tmpOrgCodeUp = 0;
                    }
                    else
                    {
                        tmpOrgCodeUp = Convert.ToInt32(txtOrgCode_Up.Text.ToString());
                    }

                    if (chkAll_AccountNo.Checked == true)
                    {
                        tmpAccountNoUp = "";
                    }
                    else
                    {
                        tmpAccountNoUp = txtAccountNo_Up.Text;
                    }
                   


                    if (checkBox_active.Equals("Y"))
                    {
                        chkActive.Checked = true;
                        chkActive_CheckedChanged(sender, e);
                    }
                    else
                    {
                        chkActive.Checked = false;
                        chkActive_CheckedChanged(sender, e);
                    }


                    dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);

                }
            }

            catch (Exception)

            {
            }
        }

        private void btnCustomerSearch_Up_Click_1(object sender, EventArgs e)
        {
            var search = new OrgSearchValueDomainView
            {

            };

            new CustomerSearch(ref search).ShowDialog();

            if (search.OrgCode == 0)
            {
                txtOrgCode_Up.Text = "";
            }
            else
            {
                txtOrgCode_Up.Text = search.OrgCode.ToString();
            }

            txtOrgName_Up.Text = search.OrgName;


            // dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
        }

        private void btnCustomerSearch_Down_Click(object sender, EventArgs e)
        {
            var search = new OrgSearchValueDomainView
            {

            };

            new CustomerSearch(ref search).ShowDialog();

            if (search.OrgCode == 0)
            {
                txtOrgCode_Down.Text = "";
            }
            else
            {
                txtOrgCode_Down.Text = search.OrgCode.ToString();
            }

            txtOrgName_Down.Text = search.OrgName;


            // dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
        }

        private void cmbAgency_Down_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
