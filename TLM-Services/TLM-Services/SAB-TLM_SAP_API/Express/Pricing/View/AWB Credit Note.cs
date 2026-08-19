using Express.Domain.Message;
using Express.Interfaces.Pricing;
using Express.Interfaces.Report.Pricing;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Enum;
using Express.UI.Common.Helpers;
using Express.UI.Factory;
using Express.UI.Factory.Report;
using Express.UI.Helpers;
using Express.View.Domain.Login;
using Express.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express.UI.Pricing.View
{
    public partial class AWB_Credit_Note : Form, IDataManipulate
    {
        private readonly IAWBCreditNote<AWBCreditView> _awbCreditNote;
        private readonly AWBCreditView _invoiceNo = new AWBCreditView();
        private List<AWBCreditNoteDetailDomainViewcs> CrdList = new List<AWBCreditNoteDetailDomainViewcs>();
        private List<AWBCreditNoteDetailDomainViewcs> tmpCrdList = new List<AWBCreditNoteDetailDomainViewcs>();
        private List<AWBCreditView> previewList = new List<AWBCreditView>();

        private ResponseMessage _response = new ResponseMessage();
            
        private string creditNoteNo = "<NEW>";
        private decimal totalInvAmt = 0m;
        private decimal balanceInvAmt = 0m;
        //private decimal getAWBLCAmount = 0m;
      //  private decimal getCRDLCAmount = 0m;
        private decimal totalCreditAmt = 0m;
       // private int checkBoxMthd = 0; 
        private int chechBoxChecker = 0;
        private decimal tmpCRDLC = 0m;
        //private string expressID = "";
        private string expressIDString = "";
        private int invClick = 0;
       // private string responseMSG = "Already exists";


        List<string> expressIDList = new List<string>();
       // List<string> tempList = new List<string>();

        public AWB_Credit_Note()
        {
            InitializeComponent();

            if (_awbCreditNote == null)
            {
                _awbCreditNote = PricingUIFactory.GetService<IAWBCreditNote<AWBCreditView>>();                
            }
                        
            dataManipulate1.NewButtonClick += new EventHandler(NewMethod);
            dataManipulate1.SaveButtonClick += new EventHandler(SaveMethod);
            dataManipulate1.EditButtonClick += new EventHandler(EditMethod);
            dataManipulate1.CancelButtonClick += new EventHandler(ClearMethod);
            dataManipulate1.CloseButtonClick += new EventHandler(CloseForm);
            dataManipulate1.DelteButtonClick += new EventHandler(DeleteMethod);
            dataManipulate1.PreviewButtonClick += new EventHandler(previewMethod);
            
            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CLOSE, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.DISABLEENABBLE);
            
            // not Necessary (buttons status when program run) 
            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.HIDEVISIBLE);
            
            dataManipulate1.CustomButtonState(ButtonTypes.PRINT, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PROCESS, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.HIDEVISIBLE);

            txtCreditNoteNo.MaxLength = 12;
            txtInvoiceNo.MaxLength = 12;
            txtAWBNoSearch.MaxLength = 15;
            txtAWBNo.MaxLength = 20;

            txtCreditNoteNo.ReadOnly = false;
            txtInvoiceNo.ReadOnly = true;
            dtpCRNDate.Enabled = false;
           // dtpCRNDate.Value = System.DateTime.Now.Date;
            dtpCRNDate.MaxDate = DateTime.Today;
            txtBusinessCode.ReadOnly = true;
            txtBusiness.ReadOnly = true;
            txtAgencyCode.ReadOnly = true;
            txtAgency.ReadOnly = true;
            txtCompanyCode.ReadOnly = true;
            txtCompany.ReadOnly = true;
            txtBranchCode.ReadOnly = true;
            txtBranch.ReadOnly = true;
            txtSalesRefCode.ReadOnly = true;
            txtSalesRef.ReadOnly = true;
            txtRemarks.ReadOnly = true;
            txtAWBNoSearch.ReadOnly = true;

            dtpINVDate.Enabled = false;
            dtpINVDate.Value = DateTime.Today;
            txtJobRef.ReadOnly = true;
            txtInvRef.ReadOnly = true;
            txtRefID1.ReadOnly = true;
            txtRefID2.ReadOnly = true;
            txtRefID3.ReadOnly = true;
            txtTotalInvAmt.ReadOnly = true;
            txtBalanceInvAmt.ReadOnly = true;

            txtOrgCode.ReadOnly = true;
            txtOrg.ReadOnly = true;
            txtPerson.ReadOnly = true;
            txtAddress1.ReadOnly = true;
            txtAddress2.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtCountry.ReadOnly = true;
            chkAllInv.Enabled = false;
            txtTotalCrdNteAmt.ReadOnly = true;
            txtAWBNo.ReadOnly = true;

            chechBoxChecker = 0;

            btnSearchAWBNo.Enabled = false;

            grdAWBCreditNote.ReadOnly = false;
            grdAWBCreditNote.Enabled = true;

          //  tmpGridCheckedList.Clear();



        }

        public FormStateEnum FormState { get; private set; }
        public object RptPricingUIFactory { get; private set; }

        public void GridFieldsDisable()
        {
            grdAWBCreditNote.Columns["AutoId"].ReadOnly = true;
            grdAWBCreditNote.Columns["ExpressID"].ReadOnly = true;
            grdAWBCreditNote.Columns["AWBNo"].ReadOnly = true;
            grdAWBCreditNote.Columns["AWBLCAmount"].ReadOnly = true;
            grdAWBCreditNote.Columns["CRDLCAmount"].ReadOnly = true;
            grdAWBCreditNote.Columns["IsCreditabil"].ReadOnly = true;

        }

        public void GetInvoiceGrid()
        {
            try {
                CrdList.Clear();
                tmpCrdList.Clear();
                CrdList = _awbCreditNote.GetCreditNoteData(Convert.ToInt32(txtCompanyCode.Text), Convert.ToInt32(txtAgencyCode.Text), Convert.ToInt64(txtInvoiceNo.Text), txtAWBNo.Text.Trim()).ToList();

                if (CrdList.Count == 0)
                {
                    grdAWBCreditNote.DataSource = null;
                    MessageNotification.MessageBoxError("Relevant data not found", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
                }
                else {

                    grdAWBCreditNote.AutoGenerateColumns = false;
                    //grdAWBCreditNote.DataSource = CrdList.ToList();

                    // to stop load creditable data
                    tmpCrdList = CrdList.Where(z => z.IsCreditabil == false).ToList();
                    grdAWBCreditNote.DataSource = tmpCrdList;

                    //tmpGridCheckedList.Clear();
                    //tmpGridCheckedList.AddRange(tmpCrdList);

                    txtAWBNoSearch.Text = "";
                    txtAWBNoSearch.ReadOnly = false;
                    btnSearchAWBNo.Enabled = true;


                    foreach (DataGridViewRow row in grdAWBCreditNote.Rows)
                    {
                        row.Cells["AutoId"].Value = (row.Index + 1).ToString();
                    }
                    GridFieldsDisable();
                }
            }
            catch(Exception ex) {

               // MessageNotification.MessageBoxError("Relevant data not found", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
            }
        }

        public void GetCreditNoteGrid()
        {
            CrdList.Clear();            
            //CrdList = _awbCreditNote.GetCreditNoteData(Convert.ToInt32(txtCompanyCode.Text), Convert.ToInt32(txtAgencyCode.Text), Convert.ToInt64(txtCreditNoteNo.Text)).ToList();
            CrdList = _awbCreditNote.GetCreditNoteDataFromJobTrance(Convert.ToInt32(txtCompanyCode.Text), Convert.ToInt32(txtAgencyCode.Text), Convert.ToInt64(txtCreditNoteNo.Text)).ToList();

            //// only shows creditable data
            //tmpCrdList = CrdList.Where(z => z.IsCreditabil == true).ToList();

            grdAWBCreditNote.AutoGenerateColumns = false;

            tmpCrdList = CrdList.Where(z => z.IsCreditabil == true).ToList();
            grdAWBCreditNote.DataSource = tmpCrdList;
            
            foreach (DataGridViewRow row in grdAWBCreditNote.Rows)
            {
                row.Cells["AutoId"].Value = (row.Index + 1).ToString();
            }

            //grdAWBCreditNote.DataSource = CrdList.ToList();
            GridFieldsDisable();

            if (tmpCrdList.Count > 0)
            {
                dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, true, ButtonCustomState.DISABLEENABBLE);
            }
        }


        public void ClearMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.Clear;
                     
        
                dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.CLOSE, true, ButtonCustomState.HIDEVISIBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.DISABLEENABBLE);

                txtCreditNoteNo.Text = "";
                txtInvoiceNo.Text = "";
                // dtpCRNDate.Enabled = false;
                txtBusinessCode.Text = "";
                txtBusiness.Text = "";
                txtAgencyCode.Text = "";
                txtAgency.Text = "";
                txtCompanyCode.Text = "";
                txtCompany.Text = "";
                txtBranchCode.Text = "";
                txtBranch.Text = "";
                txtSalesRefCode.Text = "";
                txtSalesRef.Text = "";
                txtRemarks.Text = "";


                txtAWBNo.Text = "";

                // dtpINVDate.Enabled = false;
                txtJobRef.Text = "";
                txtInvRef.Text = "";
                txtRefID1.Text = "";
                txtRefID2.Text = "";
                txtRefID3.Text = "";
                txtTotalInvAmt.Text = "";
                txtBalanceInvAmt.Text = "";

                txtOrgCode.Text = "";
                txtOrg.Text = "";
                txtPerson.Text = "";
                txtAddress1.Text = "";
                txtAddress2.Text = "";
                txtCity.Text = "";
                txtCountry.Text = "";
                //  chkAllInv.Enabled = false;
                txtTotalCrdNteAmt.Text = "";
                txtAWBNoSearch.Text = "";
                txtAWBNoSearch.ReadOnly = true;
                // txtCreditNoteNo.ReadOnly = true;
                chkAllInv.Checked = false;
                totalInvAmt = 0m;
                totalCreditAmt = 0m;

                btnSearchAWBNo.Enabled = false;

                grdAWBCreditNote.DataSource = null;


                //----------------

                txtCreditNoteNo.ReadOnly = false;
                txtInvoiceNo.ReadOnly = true;
                dtpCRNDate.Enabled = false;
                txtBusinessCode.ReadOnly = true;
                txtBusiness.ReadOnly = true;
                txtAgencyCode.ReadOnly = true;
                txtAgency.ReadOnly = true;
                txtCompanyCode.ReadOnly = true;
                txtCompany.ReadOnly = true;
                txtBranchCode.ReadOnly = true;
                txtBranch.ReadOnly = true;
                txtSalesRefCode.ReadOnly = true;
                txtSalesRef.ReadOnly = true;
                txtRemarks.ReadOnly = true;
                txtAWBNo.ReadOnly = true;

                dtpINVDate.Enabled = false;
                txtJobRef.ReadOnly = true;
                txtInvRef.ReadOnly = true;
                txtRefID1.ReadOnly = true;
                txtRefID2.ReadOnly = true;
                txtRefID3.ReadOnly = true;
                txtTotalInvAmt.ReadOnly = true;
                txtBalanceInvAmt.ReadOnly = true;

                txtOrgCode.ReadOnly = true;
                txtOrg.ReadOnly = true;
                txtPerson.ReadOnly = true;
                txtAddress1.ReadOnly = true;
                //txtAddress2.ReadOnly = true;
                txtCity.ReadOnly = true;
                txtCountry.ReadOnly = true;
                chkAllInv.Enabled = false;
                txtTotalCrdNteAmt.ReadOnly = true;

                grdAWBCreditNote.ReadOnly = false;
                grdAWBCreditNote.Enabled = true;

            if (txtInvoiceNo.Text.Equals("") || txtCreditNoteNo.Text.Equals(""))
            {
                dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, false, ButtonCustomState.DISABLEENABBLE);
            }

        }

        public void CloseForm(object param, EventArgs e)
        {
            this.Dispose();
        }

        public void DeleteMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void EditMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
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

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CLOSE, true, ButtonCustomState.HIDEVISIBLE);

            txtCreditNoteNo.ReadOnly = true;
            txtCreditNoteNo.Text = creditNoteNo;
            
            txtInvoiceNo.ReadOnly = false;
            dtpCRNDate.Enabled = false;

            chkAllInv.Checked = false;
            //*************************

            txtCreditNoteNo.Text = "";
            txtInvoiceNo.Text = "";
            // dtpCRNDate.Enabled = false;
            txtBusinessCode.Text = "";
            txtBusiness.Text = "";
            txtAgencyCode.Text = "";
            txtAgency.Text = "";
            txtCompanyCode.Text = "";
            txtCompany.Text = "";
            txtBranchCode.Text = "";
            txtBranch.Text = "";
            txtSalesRefCode.Text = "";
            txtSalesRef.Text = "";
            txtRemarks.Text = "";

            txtAWBNo.ReadOnly = false;

            // dtpINVDate.Enabled = false;
            txtJobRef.Text = "";
            txtInvRef.Text = "";
            txtRefID1.Text = "";
            txtRefID2.Text = "";
            txtRefID3.Text = "";
            txtTotalInvAmt.Text = "";
            txtBalanceInvAmt.Text = "";

            txtOrgCode.Text = "";
            txtOrg.Text = "";
            txtPerson.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            txtCountry.Text = "";
            //  chkAllInv.Enabled = false;
            txtTotalCrdNteAmt.Text = "";
            txtAWBNoSearch.Text = "";
            txtAWBNoSearch.ReadOnly = true;
            // txtCreditNoteNo.ReadOnly = true;

            totalInvAmt = 0m;
            totalCreditAmt = 0m;

            grdAWBCreditNote.DataSource = null;

            //-----

            txtCreditNoteNo.ReadOnly = true;
            txtCreditNoteNo.Text = creditNoteNo;
            ///txtInvoiceNo.ReadOnly = true;
            dtpCRNDate.Enabled = false;
            txtBusinessCode.ReadOnly = true;
            txtBusiness.ReadOnly = true;
            txtAgencyCode.ReadOnly = true;
            txtAgency.ReadOnly = true;
            txtCompanyCode.ReadOnly = true;
            txtCompany.ReadOnly = true;
            txtBranchCode.ReadOnly = true;
            txtBranch.ReadOnly = true;
            txtSalesRefCode.ReadOnly = true;
            txtSalesRef.ReadOnly = true;
            txtRemarks.ReadOnly = true;

            dtpINVDate.Enabled = false;
            txtJobRef.ReadOnly = true;
            txtInvRef.ReadOnly = true;
            txtRefID1.ReadOnly = true;
            txtRefID2.ReadOnly = true;
            txtRefID3.ReadOnly = true;
            txtTotalInvAmt.ReadOnly = true;
            txtBalanceInvAmt.ReadOnly = true;

            txtOrgCode.ReadOnly = true;
            txtOrg.ReadOnly = true;
            txtPerson.ReadOnly = true;
            txtAddress1.ReadOnly = true;
            txtAddress2.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtCountry.ReadOnly = true;
            chkAllInv.Enabled = false;
            txtTotalCrdNteAmt.ReadOnly = true;

            grdAWBCreditNote.ReadOnly = false;
            grdAWBCreditNote.Enabled = true;
            //grdAWBCreditNote.DataSource = null;
            


        }


        public void previewMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.PrintPreview;

           previewList =  _awbCreditNote.PreviewData(Convert.ToDecimal(txtCreditNoteNo.Text)).ToList();

            if (previewList.Count > 0)
            {
                AWBCreditView awbCreditDomain = new AWBCreditView();

                // var select = (AWBCreditView)txtCreditNoteNo.Text.SelectedItem;
                var select = awbCreditDomain;
                IPricingReport _report = PricingUIFactory.GetService<IPricingReport>();
             

                previewList.ForEach(cc => cc.CMPY = select == null ? 1 : select.CMPY);
                _report.PreviewAWBCreditNote(previewList);
            }
            else
           {
                MessageNotification.MessageBoxOK("No data", "ERROR");
            }
        }

        public void PrintMethod(object param, EventArgs e)
        {
           
        }

        public void ProccessMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }
       
        public void AfterSave()
        {
            txtCreditNoteNo.ReadOnly = false;
            txtInvoiceNo.ReadOnly = true;
            dtpCRNDate.Enabled = false;
            dtpINVDate.Enabled = false;
            chkAllInv.Enabled = false;
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            grdAWBCreditNote.Enabled = false;
            txtAWBNoSearch.Text = "";
            btnSearchAWBNo.Enabled = false;
        }

        public void SaveMethod(object param, EventArgs e)
        {
            //grdAWBCreditNote.Rows.Count
            if (grdAWBCreditNote.Rows.Count > 0)
            {
                List<AWBCreditNoteDetailDomainViewcs> sss = (List<AWBCreditNoteDetailDomainViewcs>)grdAWBCreditNote.DataSource;
                
                if ((sss).Where(z => z.IsCreditabil == true).Count() > 0)
                {
                   
                    //foreach (var item in tmpCrdList.Where(c => c.IsCreditabil == true))
                    //{
                        AWBCreditNoteWrappingDomainView xmlList = new AWBCreditNoteWrappingDomainView();

                        ResponseMessage objResponse = null;

                        xmlList.CMPY = Convert.ToInt32(txtCompanyCode.Text);
                        xmlList.InvoiceNo = Convert.ToDecimal(txtInvoiceNo.Text);
                        xmlList.DocDate = dtpCRNDate.Value.Date;
                        xmlList.CreditNoteList = sss.ToList();
                        xmlList.Naration = txtRemarks.Text;
                        xmlList.UserID = LoginInfoView.USERID;

                      objResponse = _awbCreditNote.SaveCreditNoteDetails(xmlList);

                    if (objResponse.IsSuccess)
                    {
                        txtCreditNoteNo.Text = objResponse.ReturnValue;

                        MessageBox.Show("Save Successful", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        AfterSave();
                    }
                    else
                    {
                        MessageNotification.MessageBoxError("Data not saved", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
                    }                 
                        
                }
                else
                {
                    MessageBox.Show("You have to select at least one creditable to proceed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                      
                }
            }

            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
        }


        private void txtInvoiceNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (NumberValidator.TryPassInteger(txtInvoiceNo.Text))
                {

                
                if (string.IsNullOrWhiteSpace(txtInvoiceNo.Text))
                {
                    MessageBox.Show("The field is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                 _invoiceNo.InvNo = Convert.ToDecimal(txtInvoiceNo.Text);

                if (_invoiceNo.InvNo == 0)
                {
                    txtInvoiceNo.Text = "";
                }
                else
                {                       
                        if (Convert.ToDecimal(txtInvoiceNo.Text) > 200000000 || Convert.ToDecimal(txtInvoiceNo.Text) < 099999999)
                        {
                            MessageBox.Show("Invalid Invoice Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtInvoiceNo.Text = "";
                        }
                        else
                        {
                            var _getInvoNo = _awbCreditNote.GetInvoiceDetailFromDebt(_invoiceNo.InvNo = Convert.ToDecimal(txtInvoiceNo.Text));

                            SetDataToFields(_getInvoNo.FirstOrDefault());
                        }

                        // TotalInvo_Balace_Credit();
                        //dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);

                    }
                }

                }
                else
                {
                    txtInvoiceNo.Text = "";
                    MessageBox.Show("Invoice No contains invalid characters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        public void SetDataToFields(AWBCreditView _getInvoNo)
        {
           
            try {
                // Convert.ToInt32(txtBusinessCode.Text) = x.; no data
                // txtBusiness.Text = x.  no data
                txtAgencyCode.Text = _getInvoNo.AgncyCode.ToString();
                txtAgency.Text = _getInvoNo.AgncyName;
                txtCompanyCode.Text = _getInvoNo.CMPY.ToString();
                txtCompany.Text = _getInvoNo.CompName;
                txtBranchCode.Text = _getInvoNo.BranchCode;
                txtBranch.Text = _getInvoNo.BranchName;
                txtSalesRefCode.Text = _getInvoNo.BranchCode;//branchcode;
                txtSalesRef.Text = _getInvoNo.SalesAreaName;   //salse Area name
                txtRemarks.Text = _getInvoNo.Remarks1;// ?? remarks
                txtJobRef.Text = _getInvoNo.JobNo.ToString();
                txtInvRef.Text = _getInvoNo.DocReference; //doc reference
                txtRefID1.Text = _getInvoNo.RefNo1;
                txtRefID2.Text = _getInvoNo.RefNo2;
                txtRefID3.Text = _getInvoNo.RefNo3;
                txtOrgCode.Text = _getInvoNo.OrgCode.ToString();
                txtOrg.Text = _getInvoNo.OrgName;
                txtPerson.Text = _getInvoNo.OrgPerson;
                txtAddress1.Text = _getInvoNo.OrgAddr1;
                txtAddress2.Text = _getInvoNo.OrgAddr2;
                txtCity.Text = _getInvoNo.OrgCity;
                txtCountry.Text = _getInvoNo.OrgCountry;

                txtTotalInvAmt.Text = _getInvoNo.VALRS.ToString();
                txtBalanceInvAmt.Text = _getInvoNo.BALANCE.ToString();
                txtTotalCrdNteAmt.Text = "0.00";
                balanceInvAmt = _getInvoNo.BALANCE;

                // balanceInvAmt = _invoiceNo.BALANCE;

                dtpCRNDate.Enabled = true;
                dtpINVDate.Enabled = false;
                chkAllInv.Enabled = true;

                //txtCreditNoteNo.Text = getInvoNo.DocNo.ToString();

                CheckBalance();
                GetInvoiceGrid();
                //  Testing();
            }
            catch (Exception EX)
            {
                MessageNotification.MessageBoxError("Relevant data not found", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
            }


        }

        public void CheckBalance() // check balance is 0 or not
        {
            if(balanceInvAmt == 0m || balanceInvAmt < 0m)
            {
               // grdAWBCreditNote.Enabled = false;
                grdAWBCreditNote.ReadOnly = true;
                chkAllInv.Enabled = false;
                dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);

            }
            else
            {
                grdAWBCreditNote.ReadOnly = false;
                grdAWBCreditNote.Enabled = true;
            }
            
        }


        public void SetFiels_CreditNote(AWBCreditView getCreditNote)
        {
            try { 
           
            txtInvoiceNo.Text = getCreditNote.InvNo.ToString();
            txtAgencyCode.Text = getCreditNote.AgncyCode.ToString();
            txtAgency.Text = getCreditNote.AgncyName;
            txtCompanyCode.Text = getCreditNote.CMPY.ToString();
            txtCompany.Text = getCreditNote.CompName;
            txtBranchCode.Text = getCreditNote.BranchCode;
            txtBranch.Text = getCreditNote.BranchName;
            txtSalesRefCode.Text = getCreditNote.BranchCode;//branchcode;
            txtSalesRef.Text = getCreditNote.SalesAreaName;   //salse Area name
            txtRemarks.Text = getCreditNote.Remarks1;// ??
            txtJobRef.Text = getCreditNote.JobNo.ToString();
            txtInvRef.Text = getCreditNote.DocReference;
            txtRefID1.Text = getCreditNote.RefNo1;
            txtRefID2.Text = getCreditNote.RefNo2;
            txtRefID3.Text = getCreditNote.RefNo3;
            txtOrgCode.Text = getCreditNote.OrgCode.ToString();
            txtOrg.Text = getCreditNote.OrgName;
            txtPerson.Text = getCreditNote.OrgPerson;
            txtAddress1.Text = getCreditNote.OrgAddr1;
            txtAddress2.Text = getCreditNote.OrgAddr2;
            txtCity.Text = getCreditNote.OrgCity;
            txtCountry.Text = getCreditNote.OrgCountry;

            txtTotalInvAmt.Text = getCreditNote.VALRS.ToString();
            txtBalanceInvAmt.Text = getCreditNote.BALANCE.ToString();
            txtTotalCrdNteAmt.Text = "0.00";

            dtpCRNDate.Enabled = true;
            dtpINVDate.Enabled = false;
            chkAllInv.Enabled = true;

            //grdAWBCreditNote.ReadOnly = true;
            //grdAWBCreditNote.Columns["IsCreditabil"].ReadOnly = true;
            grdAWBCreditNote.Enabled = false;
            //GetInvoiceGrid();
            GetCreditNoteGrid();
                
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);

            }
            catch (Exception EX)
            {
                MessageNotification.MessageBoxError("Relevant data not found", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
            }
        }

       

        private void grdAWBCreditNote_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            grdAWBCreditNote.CommitEdit(DataGridViewDataErrorContexts.Commit);
           
            //try
            //{                
                //if (e.RowIndex >= 0)
                //{                    
                //    foreach (DataGridViewRow viewRow in grdAWBCreditNote.Rows)
                //    {
                        var senderGrid = (DataGridView)sender;

                        if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn &&
                            e.RowIndex >= 0)
                        {

                            // check box when checked
                            // gonna unchecked

                            if (("" + grdAWBCreditNote.SelectedRows[0].Cells[5].Value) == "True" )
                            {

                               
                                /* string tmpExpressID*/
                                expressIDString = Convert.ToString(grdAWBCreditNote.SelectedRows[0].Cells["ExpressID"].Value).Trim();
                                expressIDList.RemoveAll(x => ((string)x) == expressIDString);
                                // expressID                                                      
                                decimal tmp = Convert.ToDecimal(grdAWBCreditNote.SelectedRows[0].Cells["CRDLCAmount"].Value);
                                tmpCRDLC = tmp;


                                string tempCredit = "0.00";
                                grdAWBCreditNote.SelectedRows[0].Cells["CRDLCAmount"].Value = tempCredit;

                                if ((expressIDList != null) && (!expressIDList.Any()))
                                {
                                    dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                                }

                                TotalInvo_Balace_Credit();
                                grdAWBCreditNote.SelectedRows[0].Cells[5].Value = false;


                               // gridCheckedList.Add();

                            }
                            else
                            {

                    // check box when UNchecked
                    // gonna checked



                    grdAWBCreditNote.SelectedRows[0].Cells[5].Value = true;
                    //--------------------------------------------------------------------------------------------------

                    List<AWBCreditNoteDetailDomainViewcs> tmpGridList1 = (List<AWBCreditNoteDetailDomainViewcs>)grdAWBCreditNote.DataSource;
                    List<AWBCreditNoteDetailDomainViewcs> tmpGridList2 = new List<AWBCreditNoteDetailDomainViewcs>();

                    //  grdAWBCreditNote.DataSource = null;
                    // if (tmpGridList1.Any(a => a.AWBNo.Trim().Equals(txtAWBNoSearch.Text.Trim())))
                    if (tmpGridList1.Any(a => a.IsCreditabil == true))
                    {
                        //int index = tmpGridList1.FindIndex(a => a.IsCreditabil == true);
                        tmpGridList2.Add(tmpGridList1[e.RowIndex]);
                        tmpGridList1.Remove(tmpGridList1[e.RowIndex]);

                    }
                    else
                    {
                        //MessageBox.Show("Invalid AWB Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //txtAWBNoSearch.Text = "";
                    }

                    foreach (AWBCreditNoteDetailDomainViewcs x in tmpGridList1)
                    {
                        tmpGridList2.Add(x);
                    }

                    grdAWBCreditNote.DataSource = tmpGridList2;

                    foreach (DataGridViewRow row in grdAWBCreditNote.Rows)
                    {
                        row.Cells["AutoId"].Value = (row.Index + 1).ToString();
                    }

                    //--------------------------------------------------------------------------------------------------

                    dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);

                                grdAWBCreditNote.SelectedRows[0].Cells["CRDLCAmount"].Value = grdAWBCreditNote.SelectedRows[0].Cells["AWBLCAmount"].Value;

                                /*string tmpExpressID*/
                                expressIDString = Convert.ToString(grdAWBCreditNote.SelectedRows[0].Cells["ExpressID"].Value).Trim();
                                // expressID = tmpExpressID;
                                //expressID
                                CreditOverrideValidation(expressIDList, expressIDString);
                                //expressID
                                if (CreditOverrideValidation(expressIDList, expressIDString))
                                {
                                    decimal tmp = Convert.ToDecimal(grdAWBCreditNote.SelectedRows[0].Cells["CRDLCAmount"].Value);
                                    tmpCRDLC = tmp;
                                    chechBoxChecker = 1;
                                    TotalInvo_Balace_Credit();
                                    expressIDList.Add(grdAWBCreditNote.SelectedRows[0].Cells["ExpressID"].Value.ToString().Trim());                                       

                    }
                                //grdAWBCreditNote.SelectedRows[0].Cells[5].Value = true;
                                
                }
            }        else
                        {
                           
                        }
                //    }
                    
                //}   

            //}

            //catch (Exception ex)
            //{
            //}

        }
       
        private bool CreditOverrideValidation(List<string> expList, string expID)
        {
            bool check_Inv = true;
            
            foreach (var item in expList)
            {
                if (item.Equals(expID))
                {
                    check_Inv = false;
                }             
            }
            return check_Inv;
        }


        private void chkAllInv_CheckedChanged(object sender, EventArgs e)
        {
            grdAWBCreditNote.CommitEdit(DataGridViewDataErrorContexts.Commit);
           // checkBoxMthd = 1; // use to find the calculation method
                       
            if (chkAllInv.Checked == true)
            {
                dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);

                foreach (DataGridViewRow row in grdAWBCreditNote.Rows)
                {
                    ((DataGridViewCheckBoxCell)row.Cells["IsCreditabil"]).Value = chkAllInv.Checked;

                    /*string tmpExpressID*/ expressIDString = Convert.ToString(row.Cells["ExpressID"].Value).Trim();
                    //  expressID = tmpExpressID;
                    // expressID
                    if (CreditOverrideValidation(expressIDList, expressIDString))
                    {                        
                            row.Cells["CRDLCAmount"].Value = row.Cells["AWBLCAmount"].Value;

                            decimal tmp = Convert.ToDecimal(row.Cells["CRDLCAmount"].Value);
                            tmpCRDLC = tmp;
                            chechBoxChecker = 1;
                            TotalInvo_Balace_Credit();
                            expressIDList.Add(row.Cells["ExpressID"].Value.ToString().Trim());                            
                    }
                    //}                    
                }            

            }
            else
            {
               // dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);

                foreach (DataGridViewRow row in grdAWBCreditNote.Rows)
                {
                    ((DataGridViewCheckBoxCell)row.Cells["IsCreditabil"]).Value = chkAllInv.Checked = false;

                    /* string tmpExpressID*/  expressIDString = Convert.ToString(row.Cells["ExpressID"].Value).Trim();
                    expressIDList.RemoveAll(x => ((string)x) == expressIDString);
                  
                    decimal tmp = Convert.ToDecimal(row.Cells["CRDLCAmount"].Value);
                    tmpCRDLC = tmp;

                    string tempCredit = "0.00";
                    row.Cells["CRDLCAmount"].Value = tempCredit;

                    if ((expressIDList != null) && (!expressIDList.Any()))
                    {
                        dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                    }

                    TotalInvo_Balace_Credit();

                    //}
                }                

                
            }
        }

        public void TotalInvo_Balace_Credit()
        {
            decimal tempBalance = balanceInvAmt;
                        
                if (chechBoxChecker == 1)
                {
                    //check

                    totalCreditAmt = totalCreditAmt + tmpCRDLC;
                    txtTotalCrdNteAmt.Text = totalCreditAmt.ToString();

                    balanceInvAmt = tempBalance - tmpCRDLC;
                    txtBalanceInvAmt.Text = balanceInvAmt.ToString();

                }
                else
                {
                    balanceInvAmt = tempBalance + tmpCRDLC;
                    txtBalanceInvAmt.Text = balanceInvAmt.ToString();

                    totalCreditAmt = totalCreditAmt - tmpCRDLC;
                    txtTotalCrdNteAmt.Text = totalCreditAmt.ToString();

                }           

            tmpCRDLC = 0;
            chechBoxChecker = 0;
        }
             
        private void txtCreditNoteNo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                if (NumberValidator.TryPassInteger(txtCreditNoteNo.Text))
                {

                    if (string.IsNullOrWhiteSpace(txtCreditNoteNo.Text))
                    {
                        MessageBox.Show("The field is empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        _invoiceNo.DocNo = Convert.ToDecimal(txtCreditNoteNo.Text);

                        if (_invoiceNo.DocNo == 0)
                        {
                            txtCreditNoteNo.Text = "";


                        }
                        else
                        {

                            if (Convert.ToDecimal(txtCreditNoteNo.Text) < 300000000 || Convert.ToDecimal(txtCreditNoteNo.Text) > 400000000)
                            {

                                MessageBox.Show("Invalid Credit Note Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtCreditNoteNo.Text = "";

                            }
                            else
                            {
                                var getCreditNote = _awbCreditNote.GetCreditNoteDetailFromDebt(_invoiceNo.DocNo = Convert.ToDecimal(txtCreditNoteNo.Text));
                                // var xx = _awbCreditNote.GetCreditNoteDataFromJobTrance(_invoiceNo.InvNo = Convert.ToDecimal(txtCreditNoteNo.Text),_invoiceNo.CMPY = 201,_invoiceNo.AgncyCode);
                                //var getCreditNote = _awbCreditNote.GetCreditNoteDataFromJobTrance(Convert.ToInt32(txtCompanyCode.Text), Convert.ToInt32(txtAgencyCode.Text), Convert.ToInt64(txtInvoiceNo.Text));



                                SetFiels_CreditNote(getCreditNote.FirstOrDefault());
                                //  TotalInvo_Balace_Credit();

                                dtpCRNDate.Enabled = false;
                                dtpINVDate.Enabled = false;
                                grdAWBCreditNote.ReadOnly = true;
                                chkAllInv.Enabled = false;
                            }
                        }
                    }
                }
                else
                {
                    txtCreditNoteNo.Text = "";
                    MessageBox.Show("Credit Note No contains invalid characters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSearchAWBNo_Click(object sender, EventArgs e)
        {
           
            List<AWBCreditNoteDetailDomainViewcs> tmpGridList1 = (List< AWBCreditNoteDetailDomainViewcs>)grdAWBCreditNote.DataSource;
            List<AWBCreditNoteDetailDomainViewcs> tmpGridList2 = new List<AWBCreditNoteDetailDomainViewcs>();

            grdAWBCreditNote.DataSource = null;
            if (tmpGridList1.Any(a => a.AWBNo.Trim().Equals(txtAWBNoSearch.Text.Trim())))
            {
                int index = tmpGridList1.FindIndex(a => a.AWBNo.Trim().Equals(txtAWBNoSearch.Text.Trim()));
                tmpGridList2.Add(tmpGridList1[index]);
                tmpGridList1.Remove(tmpGridList1[index]);
            }
            else {

                if (txtAWBNoSearch.Text.Equals(""))
                {
                    MessageBox.Show("Please enter AWB No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    MessageBox.Show("Invalid AWB Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAWBNoSearch.Text = "";
                }
            }

            foreach(AWBCreditNoteDetailDomainViewcs x in tmpGridList1)
            {
                tmpGridList2.Add(x);
            }
            
            grdAWBCreditNote.DataSource = tmpGridList2;

            foreach (DataGridViewRow row in grdAWBCreditNote.Rows)
            {
                row.Cells["AutoId"].Value = (row.Index + 1).ToString();
            }
        }


        private void txtAWBno_KeyPress(object sender, KeyPressEventArgs e)
         {
            if ((!char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
            {
                //MessageBox.Show("", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }

            if (e.KeyChar == 13)
            {
                //if (NumberValidator.TryPassInteger(txtAWBNo.Text.Trim()))
                //if((char.IsDigit(e.KeyChar)) && !char.IsControl(e.KeyChar))
                //{
                                if (txtInvoiceNo.Text.Trim() != "")
                                {
                                    invClick = 1;
                                }

                                if (invClick == 1)
                                {
                                    txtInvoiceNo_KeyPress(sender, e);
                                }
                                else
                                {
                                     MessageBox.Show("Please enter Invoice Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                 }                            
                //}
                //else
                //{
                //    if (txtAWBNo.Text.Equals(""))
                //    {
                //        txtInvoiceNo_KeyPress(sender, e);                       
                //    }
                //    else
                //    {
                //        txtAWBNo.Text = "";
                //        MessageBox.Show("AWB No contains invalid characters", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    }                   
                //}
            }
            invClick = 0;
        }

        private void txtAWBNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
