using Express.Interfaces.Invoice;
using Express.Interfaces.Operations.Manifest;
using Express.Interfaces.Report;
using Express.Interfaces.Report.Invoice;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Helpers;
using Express.UI.Factory.Invoice;
using Express.UI.Factory.Operations;
using Express.UI.Factory.Report;
using Express.UI.Factory.Report.Invoice;
using Express.UI.Helpers;
using Express.View.Domain.Invoice;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using Express.View.Domain.Report.Invoice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Express.UI.Invoice.View
{
    public partial class ClrInvPrinting : Form
    {
        private readonly IClrInvPrinting _extProvider;
        private readonly IInvoiceReportProvider _report;
        private readonly IGeneralReport _generalRpt;
        private readonly InvoiceDutyClearencePara _param;
        private readonly ClrInvParamDomainView _clearencePara;
        private bool initialLoad = true;
        private AgencyDomainViewcs oAgencyDomainViewcs = null;
        private List<AgencyDomainViewcs> agencyList = null;
        private List<ClrInvDomainView> listInvoiceDTAX = null;
        private List<ClrInvDomainView> tempListInvoiceDTAX = null;
        private IList<RefSvcRootsDomainView> _routesDetail=null;
        //private List<CfgDtaxDocTypesDomainView> listCfgDtaxDocTypes = null;
        private List<ClrInvDocTypesDomainView> listCfgDoctypes = null;
        //private ClrInvDetorDomainView oDebtDomainView = null;

        public ClrInvPrinting()
        {
            InitializeComponent();
            if (_extProvider == null)
            {
                _extProvider = InvoiceUIFactory.GetService<IClrInvPrinting>();
            }

            if(_report ==null )
            {
                _report = RptInvoiceUIFactory.GetService<IInvoiceReportProvider>();
            }

            if(_generalRpt ==null)
            {
                _generalRpt = GeneralnvoiceUIFactrory.GetService<IGeneralReport>();
            }
            _clearencePara = new ClrInvParamDomainView();
            _param = new InvoiceDutyClearencePara();
            tempListInvoiceDTAX = new List<ClrInvDomainView>();
            _param.UserID = LoginInfoView.USERID;
            chkAwbAll.Checked = true;
            chkOutstanding.Checked = true;
            txtAWB.Enabled = false;
            grdInvoiceDTAX.AutoGenerateColumns = false;
            grdInvType.AutoGenerateColumns = false;
            grdConsMaster.AutoGenerateColumns = false;
            FilterSection = 0;
        }

        private int _FilterSection;
        /// <summary>
        /// 0--normal  , 1 -- from cons grid
        /// </summary>
        public int FilterSection
        {
            get { return _FilterSection; }
            set { _FilterSection = value; }
        }

        private void Clearance_InvPrinting_Load(object sender, EventArgs e)
        {
            try
            {
                agencyList = _extProvider.GetAgencyDetail(1, 200, 1002).ToList<AgencyDomainViewcs>();
                cmbAgency.DataSource = agencyList;
                cmbAgency.SelectedItem = null;
                initialLoad = false;                
                //listCfgDtaxDocTypes = _extProvider.GetCfgDtaxDocTypes().ToList<CfgDtaxDocTypesDomainView>();
            }
            catch
            {
                MessageNotification.MessageBoxError("Application Loading Failure", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
        }

        private void radInvDate_Click(object sender, EventArgs e)
        {
            this.clear();
            dtpFrom.Enabled = true;
            dtpTo.Enabled = true;            
            txtInvFrom.Enabled = false;
            txtInvTo.Enabled = false;
            FilterSection = 0;
        }

        private void radInvNo_Click(object sender, EventArgs e)
        {
            this.clear();
            dtpFrom.Enabled = false;
            dtpTo.Enabled = false;
            txtInvFrom.Enabled = true;
            txtInvTo.Enabled = true;
            FilterSection = 0;
          
        }

        private void cmbAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!initialLoad)
                {
                    oAgencyDomainViewcs = (AgencyDomainViewcs)cmbAgency.SelectedItem;
                    lblCompany.Text = oAgencyDomainViewcs.CompName;
                    listCfgDoctypes = _extProvider.GetCfgDoctypes(oAgencyDomainViewcs.CompID, oAgencyDomainViewcs.AgncyCode).ToList();
                    grpBoxFromTo.Enabled = true;
                    grpSelect.Enabled = true;
                    this.clear();
                    this.tickRetrieveAll();
                    radInvDate.Checked = true;
                    this.radInvDate_Click(null, null);
                    this.loadCombo();
                    this.loadgrdInvType();
                    this.cleargrdInvoiceDTAX();
                    _param.AgencyID = oAgencyDomainViewcs.AgncyCode;
                    _param.CompanyID = oAgencyDomainViewcs.CompID;
                    _clearencePara.AgencyCode = oAgencyDomainViewcs.AgncyCode;
                    _clearencePara.CompanyID = oAgencyDomainViewcs.CompID;

                }
            }
            catch(Exception EX)
            {
                MessageNotification.MessageBoxError("Application Loading Failure", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            dtpTo.Value = dtpFrom.Value;
            FilterSection = 0;
            ClearInvoiceDetail();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            FilterSection = 0;
            if (dtpTo.Value< dtpFrom.Value)
            {
                dtpTo.Value = dtpFrom.Value;
            }
            ClearInvoiceDetail();
        }

        private void chkGateway_CheckedChanged(object sender, EventArgs e)
        {
            ClearInvoiceDetail();
            if (chkGateway.Checked == false){
                cmdGateway.Enabled = true;
            }                   
            else {
                cmdGateway.Enabled = false;
                cmdGateway.SelectedItem = null;
            }
        }

        private void chkStation_CheckedChanged(object sender, EventArgs e)
        {
            ClearInvoiceDetail();
            if (chkStation.Checked == false)
            {
                cmbStation.Enabled = true;
            }
            else
            {
                cmbStation.Enabled = false;
                cmbStation.SelectedItem = null;
            }
        }

        private void chkRoute_CheckedChanged(object sender, EventArgs e)
        {
            ClearInvoiceDetail();
            if (chkRoute.Checked == false)
            {
                cmbRoute.Enabled = true;
            }
            else
            {
                cmbRoute.Enabled = false;
                cmbRoute.SelectedItem = null;
            }
        }


      

        private void btnRetrive_Click(object sender, EventArgs e)
        {
            RetriveInvoices();
        }

        private void RetriveInvoices()
        {
            try
            {
                _clearencePara.FromDate = DateTimeValidator.GetAppDateformat( dtpFrom.Value.Date);
                _clearencePara.ToDate = DateTimeValidator.GetAppDateformat(dtpTo.Value.Date);
                _clearencePara.Awbnumber = txtAWB.Text;
                if (radInvDate.Checked)
                {
                    _clearencePara.SearchType = "DATE";
                    _clearencePara.FromInv = 0;
                    _clearencePara.ToInv = 0;
                }
                if (chkOutstanding.Checked)
                {
                    _clearencePara.OutstandingY = "Y";
                }
                else
                {
                    _clearencePara.OutstandingY = "";
                }
                if (_clearencePara.InvDocTypes == null || _clearencePara.InvDocTypes == "")
                {
                    MessageNotification.MessageBoxError("Please Select at least one document type", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                if (radInvNo.Checked)
                {
                    if (txtInvFrom.Text == "" || txtInvTo.Text == "")
                    {
                        MessageNotification.MessageBoxError("Enter Valid Invoice Number Range", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                        return;
                    }

                    if (int.Parse(txtInvFrom.Text) > int.Parse(txtInvTo.Text))
                    {
                        MessageNotification.MessageBoxError("Invalid Number Range", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                        return;
                    }


                    _clearencePara.SearchType = "INV";
                    _clearencePara.FromInv = Convert.ToInt32(txtInvFrom.Text);
                    _clearencePara.ToInv = Convert.ToInt32(txtInvTo.Text);
                }

                if (!chkGateway.Checked)
                {
                    if (cmdGateway.SelectedItem == null)
                    {
                        MessageNotification.MessageBoxError("Please select Gateway", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                        return;
                    }
                }

                if (!chkRoute.Checked)
                {
                    if (cmbRoute.SelectedItem == null)
                    {
                        MessageNotification.MessageBoxError("Please select Routes", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                        return;
                    }
                }

                if (!chkStation.Checked)
                {
                    if (cmbStation.SelectedItem == null)
                    {
                        MessageNotification.MessageBoxError("Please select Station", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                        return;
                    }
                }

                if(!chkAwbAll.Checked )
                {
                    if(txtAWB.Text =="")
                    {
                        MessageNotification.MessageBoxError("Please select Airwaybill Number", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                        return;
                    }
                }

                if(FilterSection ==0)
                {
                    listInvoiceDTAX = _extProvider.GetClearenceInvoices(_clearencePara).ToList();
                }
            
                this.loadInvoiceDetail();
            }
            catch (Exception ex)
            {
                MessageNotification.MessageBoxError("Data Loading Failure", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
        }

        private void txtFrom_KeyUp(object sender, KeyEventArgs e)
        {
            FilterSection = 0;
            try
            {
                int.Parse(txtInvFrom.Text);
                txtInvTo.Text = txtInvFrom.Text;
            }
            catch
            {
                txtInvFrom.Text = "";
                txtInvTo.Text = txtInvFrom.Text;
            }
            
        }

        private void txtTo_KeyUp(object sender, KeyEventArgs e)
        {
            FilterSection = 0;
            try
            {
                int.Parse(txtInvTo.Text);
            }
            catch
            {
                txtInvTo.Text = "";
            }
        }

        private void chkSelectUn_CheckedChanged(object sender, EventArgs e)
        {
            if(chkSelectUn.Checked)
            {
                this.SelectUnselectAll(true);
            }
            else
            {
                this.SelectUnselectAll(false);
            }
        }

        #region methods
        private void tickRetrieveAll()
        {
            chkGateway.Checked = true;
            chkRoute.Checked = true;
            chkStation.Checked = true;
        }

        private void clear()
        {
            dtpFrom.Value = DateTime.Today.Date;
            dtpTo.Value = DateTime.Today.Date;
            txtInvFrom.Text = "";
            txtInvTo.Text = "";
            ClearInvoiceDetail();
        }

        private void loadCombo()
        {
            _routesDetail = _extProvider.GetRefSvcRoots(oAgencyDomainViewcs.CompID).ToList<RefSvcRootsDomainView>();
            cmbRoute.DataSource = _routesDetail;
            cmbStation.DataSource = _extProvider.GetRefLocationsStations().ToList<RefLocationsDomainView>();
            cmdGateway.DataSource = _extProvider.GetGateways(oAgencyDomainViewcs.CountryCode).ToList<GatewayDomainView>();
            cmbRoute.SelectedItem = null;
            cmbStation.SelectedItem = null;
            cmdGateway.SelectedItem = null;
        }

        private void loadgrdInvType()
        {
           /// grdInvType.DataSource = null;
            /// grdInvType.DataSource = listCfgDoctypes;
            grdInvType.Rows.Clear();
            _clearencePara.InvDocTypes = "";
            foreach (var type in listCfgDoctypes)
            {
                grdInvType.Rows.Add(true, type.Doctype, type.DoctypeN);
                _clearencePara.InvDocTypes = _clearencePara.InvDocTypes + type.Doctype.Trim() + ",";
            }

        }

        private void loadInvoiceDetail()
        {
            if(FilterSection ==0)
            {
                tempListInvoiceDTAX.Clear();
                tempListInvoiceDTAX.AddRange(listInvoiceDTAX);
            }          

            if (!chkGateway.Checked)
            {
                ////listInvoiceDTAX = listInvoiceDTAX.FindAll(c => c.GateWayID == cmdGateway.SelectedValue.ToString()).ToList();
                tempListInvoiceDTAX.RemoveAll(c => c.GateWayID.Trim() != cmdGateway.SelectedValue.ToString().Trim());
            }
            if (!chkRoute.Checked)
            {
               // listInvoiceDTAX = listInvoiceDTAX.FindAll(c => c.RouteID == cmbRoute.SelectedValue.ToString()).ToList();
                tempListInvoiceDTAX.RemoveAll(c => c.RouteID.Trim() != cmbRoute.SelectedValue.ToString().Trim());
            }
            if (!chkStation.Checked)
            {
                //// listInvoiceDTAX = listInvoiceDTAX.FindAll(c => c.StationID == cmbStation.SelectedValue.ToString()).ToList();
                tempListInvoiceDTAX.RemoveAll(c => c.StationID.Trim() != cmbStation.SelectedValue.ToString().Trim());
            }

            ClearInvoiceDetail();
            
            SetConsDetail();
            /// grdInvoiceDTAX.DataSource = listInvoiceDTAX;    
            SetInvoiceList();

            if (grdInvoiceDTAX.RowCount > 0) {
                chkSelectUn.Enabled = true;
                chkSelectUn.Checked = true;
                //chkSummery.Enabled = true;
                btnInvChange.Enabled = true;
                btnRteChange.Enabled = true;
            }
            else {
                chkSelectUn.Enabled = false;
                chkSelectUn.Checked = false;
                // chkSummery.Enabled = false;
                btnInvChange.Enabled = false;
                btnRteChange.Enabled = false;
            }

           /// FilterSection = 0;




        }

        private void SetInvoiceList()
        {
            ///  grdInvoiceDTAX.CommitEdit(DataGridViewDataErrorContexts.Commit);
            ///  
           // grdInvoiceDTAX.Refresh();
            grdInvoiceDTAX.VirtualMode = true;
           // grdInvoiceDTAX.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            grdInvoiceDTAX.DataSource = tempListInvoiceDTAX;
            grdInvoiceDTAX.CommitEdit(DataGridViewDataErrorContexts.Commit);
            SetSummeryCalculation(tempListInvoiceDTAX);
            ////////////lblTotInv.Text = "Total Invoices : " + tempListInvoiceDTAX.Count.ToString();
            ////////////lblAmount.Text = "Invoice Value  : " + tempListInvoiceDTAX.Sum(c => c.InvAmount).ToString();
            ////////////lblOutstand.Text = "Ouststanding Amount  :" + tempListInvoiceDTAX.Sum(c => c.InvBalance).ToString();
        }

        private void SetSummeryCalculation(List<ClrInvDomainView> invList )
        {
            if(invList ==null )
            {
                lblTotInv.Text = "Total Invoices :0";
                lblAmount.Text = "Invoice Value  :0";
                lblOutstand.Text = "Ouststanding Amount  :0";
            }
            else if (invList.Count == 0)
            {
                lblTotInv.Text = "Total Invoices :0";
                lblAmount.Text = "Invoice Value  :0";
                lblOutstand.Text = "Ouststanding Amount  :0";
            }
            else if(invList.Count >0)
            {
                lblTotInv.Text = "Total Invoices : " + invList.Count.ToString();
                lblAmount.Text = "Invoice Value  : " + invList.Sum(c => c.InvAmount).ToString();
                lblOutstand.Text = "Ouststanding Amount  :" + invList.Sum(c => c.InvBalance).ToString();
            }
        }

        private void cleargrdInvoiceDTAX()
        {
            if (listInvoiceDTAX != null) { listInvoiceDTAX.Clear(); }            
            grdInvoiceDTAX.Rows.Clear();
            lblTotInv.Text = "Total Invoices :0";
            lblAmount.Text = "Invoice Value  :0";
            lblOutstand.Text = "Ouststanding Amount  :0";
            chkSelectUn.Enabled = false; 
        }

        private void SelectUnselectAll(bool status)
        {
            for (int i = 0; i < grdInvoiceDTAX.RowCount; i++)
            {
                
                grdInvoiceDTAX.Rows[i].Cells["IsSelect"].Value = status;
            }
        }

        #endregion

     
        private void btnPrint_Click(object sender, EventArgs e)
        {

            //if(grdInvoiceDTAX.RowCount ==0)
            // {
            //     MessageNotification.MessageBoxError("Please retrieve invoice details", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
            //     return;
            // }

            // SetInvoicePrint();
            // PrintVatInvoice();


            if (grdInvoiceDTAX.RowCount == 0)
            {
                MessageNotification.MessageBoxError("Please retrieve invoice details", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if (chkInvSummery.Checked == false)
            {
                SetInvoicePrint();
                PrintVatInvoice();
            }
            else
            {
                SetInvoiceSummeryPrint();
                _param.OutstandiY = (chkOutstanding.Checked == true) ? "Y" : "";
                var _invDutySummery = _extProvider.GetClearenceSummaryDutyPrint(_param);
                _report.ClearenceSummaryDutyPrint(_invDutySummery, SetReportHeadPara());
            }


        }
        private void SetInvoiceSummeryPrint()
        {
            // grdInvoiceDTAX
            _param.InvoiceNo = "";
            grdInvoiceDTAX.CommitEdit(DataGridViewDataErrorContexts.Commit);
            foreach (DataGridViewRow _dr in grdInvoiceDTAX.Rows)
            {

                _param.InvoiceNo = _param.InvoiceNo + _dr.Cells["InvoiceNo"].Value + ",";

            }
        }



        private void grdInvoiceDTAX_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {           
            _param.InvoiceNo  = grdInvoiceDTAX.SelectedRows[0].Cells["InvoiceNo"].Value.ToString();
            PrintVatInvoice();
        }

        private void btnInvChange_Click(object sender, EventArgs e)
        {
            if (grdInvoiceDTAX.SelectedRows == null)
            {
                MessageNotification.MessageBoxError("Select a invoice to edit", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }
            var val = listInvoiceDTAX[grdInvoiceDTAX.SelectedRows[0].Index];
            if(val.InvAmount != val.InvBalance)
            {
                MessageNotification.MessageBoxError("This invoice is all ready receipted , can not edit", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            } 

            if(val.BillTo =="S")
            {
                MessageNotification.MessageBoxError("Not Allowed for Shipper Invoice", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            new ClrInvPopInvoiceChg(listInvoiceDTAX[grdInvoiceDTAX.SelectedRows[0].Index] ,ref tempListInvoiceDTAX ,  oAgencyDomainViewcs).ShowDialog();
            
           
            SetInvoiceList();
           ////////// RetriveInvoices();
        }

        private void btnRteChange_Click(object sender, EventArgs e)
        {
            if (grdInvoiceDTAX.SelectedRows == null)
            {
                MessageNotification.MessageBoxError("Select a invoice to edit", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }
            if(_routesDetail ==null )
            {
                MessageNotification.MessageBoxError("Router detail can not be empty", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }
            var val = listInvoiceDTAX[grdInvoiceDTAX.SelectedRows[0].Index];
            if (val.InvAmount != val.InvBalance)
            {
                MessageNotification.MessageBoxError("This invoice is all ready receipted , can not edit", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            new ClrInvPopRouteChg(listInvoiceDTAX[grdInvoiceDTAX.SelectedRows[0].Index] , ref tempListInvoiceDTAX, _routesDetail , oAgencyDomainViewcs).ShowDialog();
            SetInvoiceList();
        }


        #region methods
        private void PrintVatInvoice()
        {
            if (_param.InvoiceNo == null || _param.InvoiceNo == "")
            {
                MessageNotification.MessageBoxError(" Please select at least one invoice number", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

           
            
            
                if(chkInvSummery.Checked)
                {
                   _param.OutstandiY = (chkOutstanding.Checked == true) ? "Y" : "";
                   var _invDutySummery = _extProvider.GetClearenceSummaryDutyPrint(_param);
                     _report.ClearenceSummaryDutyPrint(_invDutySummery, SetReportHeadPara());
                }
                else
                {
                    var _invDuty = _extProvider.GetClearenceDutyPrint(_param);
                    var _company = _generalRpt.GetCompany(_param.CompanyID);
                    if (_invDuty != null && _company != null)
                    {
                        _report.ClearenceDutyPrint(_invDuty, _company);
                    }
                }
               
            
        }

        private string SetReportHeadPara()
        {
            string rptPara = "";
            rptPara = rptPara + ((radInvDate.Checked == true) ? "Date From : "+  dtpFrom.Value.ToString("dd-MMM-yyyy") + " Date To : " +   dtpTo.Value.ToString("dd-MMM-yyyy") + " / " :""  );
            rptPara = rptPara + ((radInvNo.Checked == true) ? "Invoice No From : " + txtInvFrom.Text + " Invoice No To : " + txtInvTo.Text + " / ": "");
            rptPara = rptPara + ((chkGateway.Checked == false ) ? "Gateway : " + cmdGateway.Text + " / " : "");

            rptPara = rptPara + ((chkStation.Checked == false ) ? "Station : " + cmbStation.Text + " / " : "");
            rptPara = rptPara + ((chkRoute.Checked == false ) ? "Route : " + cmbRoute.Text + " / " : "");
            rptPara = rptPara + ((chkAwbAll.Checked == false ) ? "AWB No : " + txtAWB.Text : "");
            rptPara = rptPara + "Invoice Type : " + _clearencePara.InvDocTypes;

            return rptPara;
        }
         

        private void SetInvoicePrint()
        {
            // grdInvoiceDTAX
            _param.InvoiceNo = "";
            grdInvoiceDTAX.CommitEdit(DataGridViewDataErrorContexts.Commit);
            foreach (DataGridViewRow _dr in grdInvoiceDTAX.Rows)
            {
                if (_dr.Cells["IsSelect"].Value.ToString().ToUpper().Equals("TRUE"))
                {
                    _param.InvoiceNo = _param.InvoiceNo + _dr.Cells["InvoiceNo"].Value + ",";
                }
            }
        }
        private void SetSelectedInvoiceType()
        {
            _clearencePara.InvDocTypes = "";           
            grdInvType.CommitEdit(DataGridViewDataErrorContexts.Commit);
            foreach (DataGridViewRow _dr in grdInvType.Rows)
            {
                if (_dr.Cells["InvTSelect"].Value.ToString().ToUpper().Equals("TRUE"))
                {
                    _clearencePara.InvDocTypes = _clearencePara.InvDocTypes + _dr.Cells["InvType"].Value.ToString().Trim() + ",";
                }
            }
        }



        private void SetConsDetail()
        {
            if(FilterSection ==0)
            {
                grdConsMaster.Rows.Clear();
                var conslist = "";
                foreach (var type in tempListInvoiceDTAX.Select(dis => dis.ConsId).Distinct())
                {
                    var item = tempListInvoiceDTAX.Where(ex => ex.ConsId == type).FirstOrDefault();
                    conslist = conslist + item.ConsId.Trim() + ",";
                }

                var manifesDet=    _extProvider.GetManifestConsDetail(oAgencyDomainViewcs.CompID, oAgencyDomainViewcs.AgncyCode, conslist);
                foreach (var type in manifesDet)
                {                    
                    grdConsMaster.Rows.Add(true, type.ConsId, type.FlightNo, type.GateWayID);
                }


            }
           
        }

        private void SetFilterByCons()
        {
            ////tempListInvoiceDTAX.Clear();
            ////tempListInvoiceDTAX.AddRange( listInvoiceDTAX);
        
            grdConsMaster.CommitEdit(DataGridViewDataErrorContexts.Commit);
            foreach (DataGridViewRow _dr in grdConsMaster.Rows)
            {
                if (_dr.Cells["ManiSelect"].Value.ToString().ToUpper().Equals("FALSE"))
                {
                    tempListInvoiceDTAX.RemoveAll(con => con.ConsId.Trim() == _dr.Cells["consID"].Value.ToString().Trim());
                    //tempListInvoiceDTAX.RemoveAll(tempListInvoiceDTAX.Where(x => x.ConsId.Trim() == _dr.Cells["consID"].Value.ToString().Trim()).ToList());
                }
                else
                {
                    if(_dr.Cells["ManiSelect"].Value.ToString().ToUpper().Equals("TRUE"))
                    {
                        var val = tempListInvoiceDTAX.Where(con => con.ConsId.Trim() == _dr.Cells["consID"].Value.ToString().Trim());
                        if (val == null || val.Count() == 0)
                        {
                            tempListInvoiceDTAX.AddRange(listInvoiceDTAX.Where(con => con.ConsId.Trim() == _dr.Cells["consID"].Value.ToString().Trim()));
                        }
                    }
                   
                }
            }

        }
        private void ClearInvoiceDetail()
        {
            grdInvoiceDTAX.DataSource = null;
            SetSummeryCalculation(null);
        }

       
        #endregion

        private void grdInvType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex ==0)
            {
                ClearInvoiceDetail();
                SetSelectedInvoiceType();
            }         
        }

       
        private void grdConsMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex ==0)
            {
                FilterSection = 1;
                ClearInvoiceDetail();
                SetFilterByCons();
            }           
        }

      

        private void txtInvFrom_Leave(object sender, EventArgs e)
        {
            ClearInvoiceDetail();
        }

        private void txtInvTo_Leave(object sender, EventArgs e)
        {
            ClearInvoiceDetail();
        }

        private void chkAwbAll_CheckedChanged(object sender, EventArgs e)
        {
            if(!chkAwbAll.Checked)
            {
                FilterSection = 0;
                txtAWB.Enabled = true;
            }
            else
            {
                txtAWB.Text = "";
                txtAWB.Enabled = false;
            }
            ClearInvoiceDetail();
        }

      
        private void chkOutstanding_CheckedChanged_1(object sender, EventArgs e)
        {
             if (chkOutstanding.Checked == false)
            {
                chkOutstanding.Enabled = true;
            }
            else
            {
                chkOutstanding.Enabled = false;
            }
        }
    }
}
