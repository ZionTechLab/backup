using Express.Domain.Message;
using Express.Interfaces.Operations.Manifest;
using Express.Interfaces.Report.Operation;
using Express.UI.Common.Enum;
using Express.UI.Common.Helpers;
using Express.UI.Factory.Operations;
using Express.UI.Factory.Report.Operation;
using Express.UI.Helpers;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using Express.View.Domain.Report.Operation;
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
    public partial class Manifest_Inbound : Form
    {
        private readonly IManifestInbound<ManifestInboundDomainView> _extProvider;
        private readonly ManifestProcessParamDomainView _param;
        private readonly IOperationReportProvider _operationRpt;
       

        private bool initialLoad = true;
        private AgencyDomainViewcs oAgencyDomainViewcs = null;
        private IList<OpsConsMasterDomainView> listOpsConsMaster = null;
        private List<OpsConsAWBDomainView> listOpsConsAWB = new List<OpsConsAWBDomainView>();
        private List<OpsConsAWBDomainView> tempOpsConsAWB = new List<OpsConsAWBDomainView>();
        private IList<RefExgRatesDomainView> listExchangeRates = new List<RefExgRatesDomainView>();
        private List<RefExgRatesDomainView> currencyList = new List<RefExgRatesDomainView>();
        private List<CfgDtaxCalDomainView> listCfgDtaxCal = null;
        private ManifestClearenceDomainView _manifestConfig;
       
        private bool ClerenceTypeSelected = false;
        private string ShipValType = "";
        public Manifest_Inbound()
        {
            InitializeComponent();
            if (_extProvider == null)
            {
                _extProvider = OperationsUIFacotry.GetService<IManifestInbound<ManifestInboundDomainView>>();
            }
            if(_operationRpt ==null )
            {
                _operationRpt = RptOperationUIFactory.GetService<IOperationReportProvider>();
            }
            _param = new ManifestProcessParamDomainView();
          
            RefreshClearBtn.Enabled = false;
            _param.UserID = LoginInfoView.USERID;
            this.grdConsAWB.AutoGenerateColumns = false;


        }
        private void Manifest_Inbound_Load(object sender, EventArgs e)
        {
            try
            {
                IList<Express.View.Domain.Login.AgencyDomainViewcs> l = _extProvider.GetAgencyDetail(1, 200, 1002);
                cmbAgency.DataSource = l;
                cmbAgency.DisplayMember = "AgncyName";
                cmbAgency.ValueMember = "AgncyID";
                cmbAgency.SelectedItem = null;

                initialLoad = false;
                listCfgDtaxCal = _extProvider.GetCfgDtaxCal().ToList<CfgDtaxCalDomainView>();
                loadClearenceType();
            }
            catch (Exception ex)
            {
                MessageNotification.MessageBoxError("Application Loading Failure", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }

        }

        #region control  events


        private void cmbAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!initialLoad)
            {
                oAgencyDomainViewcs = (AgencyDomainViewcs)cmbAgency.SelectedItem;
                lblCompany.Text = oAgencyDomainViewcs.CompName;                
                
                cmbGateway.Enabled = true;
                cmbGateway.DataSource = _extProvider.GetGateways(oAgencyDomainViewcs.CountryCode);
                cmbGateway.DisplayMember = "LocationName";
                cmbGateway.ValueMember = "LocationID";
                cmbGateway.SelectedItem = null;
                lblGway.Text = "";

                _param.AgencyID = oAgencyDomainViewcs.AgncyCode;
                _param.CompanyID = oAgencyDomainViewcs.CompID;
                _manifestConfig = _extProvider.GetManifestClearenceConf(_param.CompanyID);
                grdConsMaster.Rows.Clear();
              
                //dtpTransDate.Enabled = true;
                this.clearGrigConsAWB();
               /// clearClearenceType();
            }

        }

        private void cmbGateway_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbGateway.SelectedItem!=null)
            {
                dtpTransDate.Enabled = true;
                if (cmbGateway.SelectedValue is string)
                {
                    this.loadConsMasterGrid();
                    this.clearGrigConsAWB();
                    lblGway.Text = cmbGateway.SelectedValue.ToString();
                }
            }
            else
            {
                dtpTransDate.Enabled = false;
                this.clearGrigConsAWB();
            }
        }

        private void dtpTransDate_ValueChanged(object sender, EventArgs e)
        {
            this.loadConsMasterGrid();
            this.clearGrigConsAWB();
        }

        private void grdConsMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex >1)
            {
                return;
            }

            chkNotInvoice.Checked = false;
            chkPayAll.Checked = false;
            try {
                this.grdConsMaster.CommitEdit(DataGridViewDataErrorContexts.Commit);
                IList<OpsConsAWBDomainView> list = null;

                SetSelectedCons();

                if (grdConsMaster.SelectedRows[0].Cells["ManiSelect"].Value.ToString() == "True") // if (grdConsMaster.SelectedRows[0].Cells[4].Value.ToString() == "True")
                {
                    string val = grdConsMaster.SelectedRows[0].Cells["consID"].Value.ToString(); // grdConsMaster.SelectedRows[0].Cells[0].Value.ToString()
                    string exval = grdConsMaster.SelectedRows[0].Cells["ExpressCons"].Value.ToString();
                    //New ExpressCons
                    // list = _extProvider.GetOpsConsAWB(val);
                    list = _extProvider.GetOpsConsAWBEx(val,exval);

                    foreach (OpsConsAWBDomainView itm in list)
                    {
                        if (listOpsConsAWB.Find(c => (c.ExpressID == itm.ExpressID) && (c.AgncyCode == itm.AgncyCode) && (c.CMPY == itm.CMPY) && (c.ConsId==itm.ConsId) && (c.ExpressCons==itm.ExpressCons)) == null)
                        {
                            listOpsConsAWB.Add(itm);
                        }
                    }
                }
                else if (grdConsMaster.SelectedRows[0].Cells["ManiSelect"].Value.ToString() == "False") // else if (grdConsMaster.SelectedRows[0].Cells[4].Value.ToString() == "False")
                {
                    string val = grdConsMaster.SelectedRows[0].Cells["consID"].Value.ToString(); // grdConsMaster.SelectedRows[0].Cells[0].Value.ToString()
                    string exval = grdConsMaster.SelectedRows[0].Cells["ExpressCons"].Value.ToString();
                    //New ExpressCons
                    //list = _extProvider.GetOpsConsAWB(val);
                    list = _extProvider.GetOpsConsAWBEx(val, exval);
                    OpsConsAWBDomainView temp = null;
                    foreach (OpsConsAWBDomainView itm in list)
                    {
                        temp = listOpsConsAWB.Find(c => (c.ExpressID == itm.ExpressID) && (c.AgncyCode == itm.AgncyCode) && (c.CMPY == itm.CMPY) && (c.ConsId==itm.ConsId) && (c.ExpressCons == itm.ExpressCons));
                        if (temp != null)
                        {
                            bool t = listOpsConsAWB.Remove(temp);
                        }
                    }
                }

                if (listOpsConsAWB.Count > 0)
                {
                    this.grdConsAWB.AutoGenerateColumns = false;
                    grdConsAWB.DataSource = null;
                    grdConsAWB.DataSource = listOpsConsAWB;                    
                    lblTotAwbs.Text = "Total AWBs : " + listOpsConsAWB.Count.ToString();
                    lblUnprocessed.Text = "Unprocessed : " + listOpsConsAWB.FindAll(c => c.ShipValueType == null || c.ShipValueType.Trim() == "").Count.ToString();
                }
                else
                {
                    grdConsAWB.DataSource = null;
                    lblTotAwbs.Text = "Total AWBs : 0";
                    lblUnprocessed.Text = "Unprocessed : 0";
                }
                loadClearenceType(listOpsConsAWB); 
                //loadClearenceType();

            }
            catch(Exception ex)
            {
                MessageNotification.MessageBoxError("Error Selection", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);                
            }
        }

        private void grdConsAWB_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                if (ClerenceTypeSelected) { return; }

                if (listOpsConsAWB.FindAll(c => c.CustomVal > 0 && (c.CustomsPkgVal == 0 || c.CustomsPkgVal == null)) != null)
                {
                    //lblUnprocessed.Text = "Unprocessed : " + listOpsConsAWB.FindAll(c => c.CustomVal > 0 && (c.CustomsPkgVal == 0 || c.CustomsPkgVal == null)).Count.ToString();
                    lblUnprocessed.Text = "Unprocessed : " + listOpsConsAWB.FindAll(c => c.ShipValueType ==null || c.ShipValueType.Trim() =="").Count.ToString();
                }

                if (grdConsAWB.DataSource != null)
                {
                    /////this.loadClearenceType();                
                                       
                    this.loadCurruncies();
                }
                else
                {
                    
                    //this.clearClearenceType();
                    
                    this.clearGrdCurruncies();                    
                }
            }
            catch(Exception ex)
            {

            }
        }


        
        private void grdClrType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           if(e.ColumnIndex >0)
            {
                return;
            }

            try
            {
                ////List<string> type = new List<string>();
                this.grdClrType.CommitEdit(DataGridViewDataErrorContexts.Commit);
                ClerenceTypeSelected = false;
                ShipValType = "";
                List<string> type = new List<string>();
                type.Clear();
                foreach (DataGridViewRow r in grdClrType.Rows)
                    {
                        if (r.Cells["ClrSelect"].Value.ToString() == "True")
                        {
                            ClerenceTypeSelected = true;
                            type.Add(r.Cells["Type"].Value.ToString());
                            ShipValType = ShipValType + r.Cells["Type"].Value.ToString() + ",";
                        }  
                    }

                FilterList(type);
                ClerenceTypeSelected = false;

                //////if (ClerenceTypeSelected)
                //////{

                //////    if (type.Count == 1)
                //////    {
                //////        //this.grdConsAWB.AutoGenerateColumns = false;
                //////        //grdConsAWB.DataSource = null;
                //////        //var listV = listOpsConsAWB.FindAll(c => c.ShipValueType.Trim() == type[0]);
                //////        //grdConsAWB.DataSource = listV;
                //////        //lblTotAwbs.Text = "Total AWBs : " + listV.Count.ToString();
                //////        //lblUnprocessed.Text = "Unprocessed : " + listV.FindAll(c => c.ShipValueType == null || c.ShipValueType.Trim() == "").Count.ToString();

                //////        // FilterList()

                //////    }
                //////    else if (type.Count == 2)
                //////    {
                //////        //this.grdConsAWB.AutoGenerateColumns = false;
                //////        //grdConsAWB.DataSource = null;
                //////        //var listV = listOpsConsAWB.FindAll(c => c.ShipValueType.Trim() == type[0] || c.ShipValueType.Trim() == type[1]);
                //////        //grdConsAWB.DataSource = listV;
                //////        //lblTotAwbs.Text = "Total AWBs : " + listV.Count.ToString();
                //////        //lblUnprocessed.Text = "Unprocessed : " + listV.FindAll(c => c.ShipValueType == null || c.ShipValueType.Trim() == "").Count.ToString();

                //////    }
                //////    else if (type.Count == 3)
                //////    {
                //////        //this.grdConsAWB.AutoGenerateColumns = false;
                //////        //grdConsAWB.DataSource = null;
                //////        //var listV = listOpsConsAWB.FindAll(c => c.ShipValueType.Trim() == type[0] || c.ShipValueType.Trim() == type[1] || c.ShipValueType.Trim() == type[2]);
                //////        //grdConsAWB.DataSource = listV;
                //////        //lblTotAwbs.Text = "Total AWBs : " + listV.Count.ToString();
                //////        //lblUnprocessed.Text = "Unprocessed : " + listV.FindAll(c => c.ShipValueType == null || c.ShipValueType.Trim() == "").Count.ToString();

                //////    }

                //////}
                //////else
                //////{
                //////    //this.grdConsAWB.AutoGenerateColumns = false;
                //////    //grdConsAWB.DataSource = null;
                //////    //grdConsAWB.DataSource = listOpsConsAWB;
                //////    //lblTotAwbs.Text = "Total AWBs : " + listOpsConsAWB.Count.ToString();
                //////    //lblUnprocessed.Text = "Unprocessed : " + listOpsConsAWB.FindAll(c => c.ShipValueType == null || c.ShipValueType.Trim() == "").Count.ToString();
                //////}

                //////ClerenceTypeSelected = false;
            }
            catch
            {
                ClerenceTypeSelected = false;
                MessageNotification.MessageBoxError("Error Selection", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
           
           

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            ////ResponseMessage responce = new ResponseMessage();
            //try
            //{
            //    if (!MessageNotification.MessageBoxConfirm("Are sure want to process this ?", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Confirmation))
            //    {
            //        return;
            //    }


            //    if (!ValidateExtRate())
            //    {
            //        MessageNotification.MessageBoxError("Please enter exchange rate", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
            //        return;
            //    }
            //    if (_param.AgencyID == 0)
            //    {
            //        MessageNotification.MessageBoxError("Please select agecny", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
            //        return;
            //    }
            //    if (_param.ConsID == null || _param.ConsID == "")
            //    {
            //        MessageNotification.MessageBoxError("Please select cons id", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
            //        return;
            //    }


            //    responce = _extProvider.InvoiceProcess(_param);
            //    if(responce.IsSuccess )
            //    {
            //        MessageNotification.MessageBoxOK("Duty invoice process successfully", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
            //        var list = _extProvider.GetOpsConsAWB(_param);
            //        if (list != null)
            //        {
            //            listOpsConsAWB.Clear();
            //            listOpsConsAWB = list.ToList();
            //            grdConsAWB.DataSource = list;

            //        }
            //    }
            //    else
            //    {
            //        MessageNotification.MessageBoxError(responce.StrMessage , LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            //    }
            //}
            //catch(Exception ex)
            //{
            //    MessageNotification.MessageBoxError(ex.Message, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
            //}

            /// _param
            /// 

            if(!CheckExgRates())
            {
                MessageNotification.MessageBoxError("Please update exchange rate", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            ResponseMessage responce = new ResponseMessage();
            decimal _totDutyValue = 0;
            var invVal = new ManifestInbLVProPramDomainView()
            {
                CompanyID = _param.CompanyID,
                AgencyID = _param.AgencyID,
                UserID = _param.UserID,
                ConsIds = _param.ConsID,
                ExpressCons= _param.ExpressCons,
                BillTo = GetBillType(),
                PayVouNumber = GetPaymentVoucher()
            };

            if (grdConsAWB.DataSource ==null)
            {
                MessageNotification.MessageBoxError("Please retreive data before invoice process", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if ( grdConsAWB.RowCount ==0)
            {
                MessageNotification.MessageBoxError("Please retreive data before invoice process", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }


             _totDutyValue = Convert.ToDecimal( listOpsConsAWB.Where(duty => duty.ShipValueType.Trim() == "LV" && duty.InvNoDTaxChg ==0 && duty.PayNoDTaxChg == "0").Sum(duty => duty.TotalDutyVal));

            if(rdShipper.Checked)
            {
                _totDutyValue = Convert.ToDecimal(listOpsConsAWB.Where(duty => duty.ShipValueType.Trim() == "LV" && duty.InvNoDTaxChg == 0 && duty.PayNoDTaxChg == "0" && duty.BillDtaxChg=="S").Sum(duty => duty.TotalDutyVal));
            }

            if(rdCons.Checked )
            {
                _totDutyValue = Convert.ToDecimal(listOpsConsAWB.Where(duty => duty.ShipValueType.Trim() == "LV" && duty.InvNoDTaxChg == 0 && duty.PayNoDTaxChg == "0" && duty.BillDtaxChg == "C").Sum(duty => duty.TotalDutyVal));
            }

            if(rdOther.Checked )
            {
                _totDutyValue = Convert.ToDecimal(listOpsConsAWB.Where(duty => duty.ShipValueType.Trim() == "LV" && duty.InvNoDTaxChg == 0 && duty.PayNoDTaxChg == "0" && duty.BillDtaxChg == "O").Sum(duty => duty.TotalDutyVal));
            }
            var invPop = new Manifest_InboundInvPopUp(Convert.ToDecimal( _totDutyValue), ref responce , invVal , oAgencyDomainViewcs.LocalCurrency );
            invPop.ShowDialog();

            //if (responce.IsSuccess)
            //{
            ///MessageNotification.MessageBoxOK("Duty invoice process successfully", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
            //ExpressCons
            //var list = _extProvider.GetOpsConsAWB(_param);
            var list = _extProvider.GetOpsConsAWBEx(_param.ConsID,_param.ExpressCons);
                if (list != null)
                {
                    listOpsConsAWB.Clear();
                    listOpsConsAWB = list.ToList();
                //  grdConsAWB.DataSource = list;
                    FilterList(null);


                }
            //}
            ////else
            ////{
            ////    MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            ////}



        }

       
        private string GetPaymentVoucher()
        {
            string vourcher = "";

            var vouList = listOpsConsAWB.Select(dist => dist.PayNoDTaxChg).Distinct();
            foreach( string vNum in vouList)
            {
                if(vNum!="0")
                    vourcher = vourcher + vNum + ",";
            }
            if(vourcher.Length >0)
            {
                vourcher = vourcher.Remove(vourcher.Length - 1);
            }
            return vourcher;
        }
       

       


       


        #region button click event te
        private void ExgRateBtn_Click(object sender, EventArgs e)
        {
            ExchangeRates fexhRate = new Express.ExchangeRates(ExchangeRateStatus.CLEARENCE);
            fexhRate.StartPosition = FormStartPosition.CenterParent;
            fexhRate.ShowDialog();
        }

        private void RefreshClearBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(!MessageNotification.MessageBoxConfirm("Are sure want to process this ?", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Confirmation))
                {
                    return;
                }

                if (grdConsAWB.DataSource == null)
                {
                    MessageNotification.MessageBoxError("Please retreive data before invoice process", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                if (grdConsAWB.RowCount == 0)
                {
                    MessageNotification.MessageBoxError("Please retreive data before invoice process", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                _param.Currency = GetManifestCurrencies();
                _param.TransDate = Convert.ToDateTime(dtpTransDate.Value.Date);
                _param.PayParty = GetBillType();
                ResponseMessage responce = new ResponseMessage();
                if (!ValidateExtRate())
                {
                    MessageNotification.MessageBoxError("Please enter exchange rate", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }
                if (_param.AgencyID == 0)
                {
                    MessageNotification.MessageBoxError("Please select agecny", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }
                if (_param.ConsID == null || _param.ConsID == "")
                {
                    MessageNotification.MessageBoxError("Please select cons id", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }
                if (_param.Currency == null || _param.Currency == "")
                {
                    MessageNotification.MessageBoxError("Manifest currency list can't be empty", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                responce = _extProvider.ProcessManifestClearence(_param);
                if (responce.IsSuccess)
                {
                    MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
                    //ExpressCons
                    //var list = _extProvider.GetOpsConsAWB(_param );
                    var list = _extProvider.GetOpsConsAWBEx(_param.ConsID,_param.ExpressCons);
                    if (list !=null)
                    {
                        listOpsConsAWB.Clear();
                        listOpsConsAWB = list.ToList();
                        //grdConsAWB.DataSource = list;
                        FilterList(null);

                    }

                }
                else
                {
                    MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                }
            }
            catch (Exception ex)
            {
                MessageNotification.MessageBoxError(ex.Message, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
                return;
            }
        }
        private void grdConsAWB_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var _values = (OpsConsAWBDomainView)grdConsAWB.SelectedRows[0].DataBoundItem;
                if(_values.InvNoDTaxChg ==0)
                {
                    new Manifest_Inbound_Edit((OpsConsAWBDomainView)grdConsAWB.SelectedRows[0].DataBoundItem).ShowDialog();
                    this.loadConsAWBGrid();

                   /// FilterList(null);
                }
                else
                {
                    MessageNotification.MessageBoxError("Invoice already proccess, can't change record", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                }

              
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #endregion

        #region te method
        private bool ValidateExtRate()
        {
            bool _isValid;
            _isValid = true;
            foreach (RefExgRatesDomainView item in currencyList)
            {
                if (item.ExgRate == 0)
                {
                    _isValid = false;
                }
            }

            return _isValid;
        }

        private void SetSelectedCons()
        {
            _param.ConsID = "";
            _param.ExpressCons = "";


            foreach (DataGridViewRow _dr in grdConsMaster.Rows)
            {
                if (_dr.Cells["ManiSelect"].Value.Equals("True"))
                {
                    _param.ConsID = _param.ConsID +  _dr.Cells["consID"].Value+ ",";
                    _param.ExpressCons = _param.ExpressCons + _dr.Cells["ExpressCons"].Value + ",";
                }
            }
        }         

          

        private string GetManifestCurrencies()
        {
            string _currency = "";
            foreach(RefExgRatesDomainView item in  currencyList)
            {
                _currency = _currency +item.Currency + ",";
            }
            return _currency;
        }

        private bool  CheckExgRates()
        {
            bool _isValid = true ;
            foreach (RefExgRatesDomainView item in currencyList)
            {
                if(item.ExgRate ==0)
                {
                    _isValid = false;
                }
            }
            return _isValid;
        }
        #endregion


        #region methods
        private void loadConsAWBGrid()
        {
            List<OpsConsAWBDomainView> list = null;
            string val = "";
            string valex = "";
            listOpsConsAWB.Clear();
            foreach (DataGridViewRow r in grdConsMaster.Rows)
            {
                if (r.Cells["ManiSelect"].Value.ToString() == "True")
                {
                    val = r.Cells["consID"].Value.ToString();

                    //ExpressCons
                    valex = r.Cells["ExpressCons"].Value.ToString();
                    //
                    list = _extProvider.GetOpsConsAWBEx(val,valex).ToList<OpsConsAWBDomainView>();
                    foreach (OpsConsAWBDomainView OpsConsAWB in list)
                    {
                        listOpsConsAWB.Add(OpsConsAWB);
                    }
                }
            }

            tempOpsConsAWB.Clear();
            tempOpsConsAWB.AddRange(listOpsConsAWB);
            List<string> typeValues = new List<string>();

            foreach (DataGridViewRow r in grdClrType.Rows)
            {
                if (r.Cells["ClrSelect"].Value.ToString() == "True")
                {
                    typeValues.Add(r.Cells["Type"].Value.ToString());
                }
            }

            if (typeValues.Count > 0)
            {
                tempOpsConsAWB = tempOpsConsAWB.Where(fl => typeValues.Contains(fl.ShipValueType.Trim())).ToList();
            }

            if (chkNotInvoice.Checked)
            {
                tempOpsConsAWB = tempOpsConsAWB.Where(not => not.TotalDutyVal > 0 && not.InvNoDTaxChg == 0).ToList();

            }

            if (chkPayAll.Checked)
            {

            }
            else
            {
                if (rdShipper.Checked)
                {
                    tempOpsConsAWB = tempOpsConsAWB.Where(payT => payT.BillDtaxChg == "S").ToList();
                }

                if (rdCons.Checked)
                {
                    tempOpsConsAWB = tempOpsConsAWB.Where(payT => payT.BillDtaxChg == "C").ToList();
                }

                if (rdOther.Checked)
                {
                    tempOpsConsAWB = tempOpsConsAWB.Where(payT => payT.BillDtaxChg == "O").ToList();
                }

            }


            if (listOpsConsAWB.Count > 0)
            {
                this.grdConsAWB.AutoGenerateColumns = false;
                grdConsAWB.DataSource = null;
                grdConsAWB.DataSource = tempOpsConsAWB;
                lblTotAwbs.Text = "Total AWBs : " + tempOpsConsAWB.Count.ToString();
                lblUnprocessed.Text = "Unprocessed : " + tempOpsConsAWB.FindAll(c => c.ShipValueType == null || c.ShipValueType.Trim() == "").Count.ToString();
            }
            else
            {
                grdConsAWB.DataSource = null;
                lblTotAwbs.Text = "Total AWBs : 0";
                lblUnprocessed.Text = "Unprocessed : 0" ;
            }
        }
        private void loadConsMasterGrid()
        {
            listOpsConsMaster = _extProvider.GetOpsConsMaster(oAgencyDomainViewcs.AgncyCode, oAgencyDomainViewcs.CompID, cmbGateway.SelectedValue.ToString(), dtpTransDate.Value.Date);
            //listOpsConsMaster = _extProvider.GetOpsConsMaster("TNT", 201, "DMM", new DateTime(2018,8,30));
            grdConsMaster.Rows.Clear();
            foreach (OpsConsMasterDomainView itm in listOpsConsMaster)
            {
                grdConsMaster.Rows.Add(itm.ExpressCons, false, itm.ConsId, itm.MAWBNo, itm.FlightNo, itm.OrgHubID);
            }

            listOpsConsAWB.Clear();
        }

        private void loadCurruncies()
        {
            listExchangeRates.Clear();
            currencyList.Clear();
            if (listOpsConsAWB.Count > 0)
            {
                var uniqueCurruncies = listOpsConsAWB.Select(c => c.CustomValCur).Distinct().ToList();
                foreach (var currency in uniqueCurruncies)
                {
                    listExchangeRates = _extProvider.GetRefExgRates(oAgencyDomainViewcs.CompID, currency, dtpTransDate.Value.Date);
                    if (listExchangeRates != null)
                    {
                       if (listExchangeRates.Count > 0)
                        {
                            listExchangeRates[0].Currency = currency;
                            currencyList.Add(listExchangeRates[0]);
                        }
                        else
                        {
                            ////if(currency !=null && currency.Trim() !="")
                            ////{
                            ////    currencyList.Add(new RefExgRatesDomainView { CMPY = 0, ClearanceCurrency = "", Currency = currency, EffectDate = DateTime.Today.Date, ExgRate = 0, Remarks = "" });
                            ////}


                            //////if(currency !=null && currency.Trim() !="")
                            //////{
                            //////    currencyList.Add(new RefExgRatesDomainView { CMPY = 0, ClearanceCurrency = "", Currency = currency, EffectDate = DateTime.Today.Date, ExgRate = 0, Remarks = "" });
                            //////}
                            /// request from ksa 
                            currencyList.Add(new RefExgRatesDomainView { CMPY = 0, ClearanceCurrency = "", Currency = currency, EffectDate = dtpTransDate.Value.Date, ExgRate = 0, Remarks = "" });

                        }
                    }
                }
            }

            grdCurrency.AutoGenerateColumns = false;
            grdCurrency.DataSource = null;
            grdCurrency.DataSource = currencyList;

           var curr = CheckExgRates();
            if(curr)
            {
                RefreshClearBtn.Enabled = true;
            }
            else
            {
                RefreshClearBtn.Enabled = false;
            }
            
        }

        private void clearGrdCurruncies()
        {
            grdCurrency.DataSource = null;
            currencyList.Clear();
        }

        private void loadClearenceType(List<OpsConsAWBDomainView> fiterAwbs  )
        {

            

            List<OpsConsAWBDomainView> li = new List<OpsConsAWBDomainView>();
            List<string> typeValues = new List<string>();
            this.grdClrType.CommitEdit(DataGridViewDataErrorContexts.Commit);
            foreach (DataGridViewRow r in grdClrType.Rows)
            {
                if (r.Cells["ClrSelect"].Value.ToString() == "True")
                {                   
                    typeValues.Add(r.Cells["Type"].Value.ToString());                   
                }
            }


            grdClrType.Rows.Clear();
            grdClrType.DataSource = null;

            List<string> types = listCfgDtaxCal.Select(c => c.ShipValueType).Distinct().ToList<string>();
            foreach (string type in types)
            {
                li = fiterAwbs.FindAll(c => c.ShipValueType.Trim() == type.Trim());
                if (typeValues != null)
                {
                    if (typeValues.Contains(type.Trim()))
                    {
                        grdClrType.Rows.Add(true, type.Trim(), li.Count, li.Sum(c => c.CustomsPkgVal), li.Sum(c => c.TotalDutyVal));
                    }
                    else
                    {
                        grdClrType.Rows.Add(false, type.Trim(), li.Count, li.Sum(c => c.CustomsPkgVal), li.Sum(c => c.TotalDutyVal));
                    }
                }


                /////grdClrType.Rows.Add(false, type.Trim(), li.Count, li.Sum(c => c.CustomsPkgVal), li.Sum(c => c.TotalDutyVal));

            }


        }



        private void loadClearenceType()
        {


            List<OpsConsAWBDomainView> li = new List<OpsConsAWBDomainView>();
            grdClrType.Rows.Clear();
            grdClrType.DataSource = null;

            List<string> types = listCfgDtaxCal.Select(c => c.ShipValueType).Distinct().ToList<string>();
            foreach (string type in types)
            {
                //li = listOpsConsAWB.FindAll(c => c.ShipValueType.Trim() == type.Trim());
                //grdClrType.Rows.Add(false, type.Trim(), li.Count, li.Sum(c => c.CustomsPkgVal), li.Sum(c => c.TotalDutyVal));
                grdClrType.Rows.Add(false, type.Trim(), 0, 0, 0);
            }


        }

        private void clearClearenceType()
        {
            grdClrType.Rows.Clear();
            grdClrType.DataSource = null;
            btnProcess.Enabled = true;
        }

        private void changeDutyStatus()
        {
            bool statusEdit = false;
            if (grdConsAWB.SelectedCells[0].OwningColumn.Name == "DetainedY") // if (grdConsAWB.SelectedCells[0].ColumnIndex == 16)
            {
                statusEdit = true;
                if (grdConsAWB.SelectedCells[0].Value != null)
                {
                    if (grdConsAWB.SelectedCells[0].Value.ToString().Trim() == "")
                        grdConsAWB.SelectedCells[0].Value = "N";
                    else if (grdConsAWB.SelectedCells[0].Value.ToString() == "N")
                        grdConsAWB.SelectedCells[0].Value = "Y";
                    else if (grdConsAWB.SelectedCells[0].Value.ToString() == "Y")
                        grdConsAWB.SelectedCells[0].Value = "N";

                }
                else
                {
                    grdConsAWB.SelectedCells[0].Value = "N";
                }

            }
            else if (grdConsAWB.SelectedCells[0].OwningColumn.Name == "DutyExcemptY") //else if (grdConsAWB.SelectedCells[0].ColumnIndex == 17)
            {
                statusEdit = true;
                if (grdConsAWB.SelectedCells[0].Value != null)
                {
                    if (grdConsAWB.SelectedCells[0].Value.ToString().Trim() == "")
                        grdConsAWB.SelectedCells[0].Value = "N";
                    else if (grdConsAWB.SelectedCells[0].Value.ToString() == "N")
                        grdConsAWB.SelectedCells[0].Value = "Y";
                    else if (grdConsAWB.SelectedCells[0].Value.ToString() == "Y")
                        grdConsAWB.SelectedCells[0].Value = "N";
                }
                else
                {
                    grdConsAWB.SelectedCells[0].Value = "N";
                }
            }

            if (statusEdit)
            {
                OpsConsAWBDomainView row = (OpsConsAWBDomainView)grdConsAWB.SelectedCells[0].OwningRow.DataBoundItem;

                //string detain = row.DetainedY;
                //string dEx = row.DutyExcemptY;
                ResponseMessage msg = _extProvider.UpdateManifestInboundDutyStatus(row);

                if (msg.IsSuccess)
                {
                    if (grdConsAWB.SelectedCells[0].OwningColumn.Name == "DetainedY") // if (grdConsAWB.SelectedCells[0].ColumnIndex == 16)
                    {
                        listOpsConsAWB.Find(c => (c.ExpressID == row.ExpressID) && (c.AgncyCode == row.AgncyCode) && (c.CMPY == row.CMPY) && (c.ConsId == row.ConsId)).DetainedY = grdConsAWB.SelectedCells[0].Value.ToString();
                    }
                    else if (grdConsAWB.SelectedCells[0].OwningColumn.Name == "DutyExcemptY") // else if (grdConsAWB.SelectedCells[0].ColumnIndex == 17)
                    {
                        listOpsConsAWB.Find(c => (c.ExpressID == row.ExpressID) && (c.AgncyCode == row.AgncyCode) && (c.CMPY == row.CMPY) && (c.ConsId == row.ConsId)).DutyExcemptY = grdConsAWB.SelectedCells[0].Value.ToString();
                    }

                }

            }

        }

        private void clearGrigConsAWB()
        {
            grdConsAWB.DataSource = null;
            lblTotAwbs.Text = "Total AWBs : 0";
            lblUnprocessed.Text = "Unprocessed : 0";
            listOpsConsAWB.Clear();
        }







        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            if (_param.AgencyID == 0)
            {
                MessageNotification.MessageBoxError("Please select agecny", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if (_param.ConsID == null || _param.ConsID == "")
            {
                MessageNotification.MessageBoxError("Please select cons id", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            var isnotInv = (chkNotInvoice.Checked) ? 1 : 0;
            var payM = "ALL"; 
                      
            if (rdShipper.Checked)
            {
                payM = "S";
            }
            else if(rdCons.Checked)
            {
                payM = "C";
            }
            else if(rdOther.Checked)
            {
                payM = "O";
            }
            else if(chkPayAll.Checked )
            {
                payM = "ALL";
            }

            
                var repPara = new RptManifestParaDomainView
            {
                AgencyId = _param.AgencyID ,
                CompanyID =_param.CompanyID ,
                ConsID = _param.ExpressCons,  ////_param.ConsID ,
                TrDate  = Convert.ToDateTime(dtpTransDate.Value.Date),
                ShipValType = ShipValType,
                IsNotInvoiced = isnotInv,
                PayModes = payM,
               

                };
            var manifestRpt= _extProvider.GetManiferReport(repPara);
            _operationRpt.GetManiferReport(manifestRpt , GetSearchText());
        }

        private string GetSearchText()
        {
            string _searchText = "";
            var payMode = "ALL";

            if (rdShipper.Checked)
            {
                payMode = "Shipper";
            }
            else if (rdCons.Checked)
            {
                payMode = "Consignee";
            }
            else if (rdOther.Checked)
            {
                payMode = "Other";
            }
            else if (chkPayAll.Checked)
            {
                payMode = "ALL";
            }

            _searchText = _searchText + ((_param.ConsID == "") ? "" : "Cons ID : "+ _param.ConsID);
            _searchText = _searchText + ((chkNotInvoice.Checked == true ) ? " / Not Invoiced " : "");
            _searchText = _searchText + ((ShipValType == "") ? "" : " / Shipment Type : " + ShipValType);
            _searchText = _searchText +  " / Pay party : " + payMode;

            return _searchText;
        }

        private void grdCurrency_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var _values = (RefExgRatesDomainView)grdCurrency.SelectedRows[0].DataBoundItem;

                if (_values.Currency == null || _values.Currency.Trim() == "")
                {
                    MessageNotification.MessageBoxError("Please update manifested currency", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }
                new ExchangeRates( ref _values , _manifestConfig , ExchangeRateStatus.CLEARENCE ).ShowDialog();
                
               
                    currencyList.Where(curr => curr.Currency.Trim() == _values.Currency.Trim() && curr.EffectDate == _values.EffectDate).FirstOrDefault().ExgRate =_values.ExgRate;
                    currencyList.Where(curr => curr.Currency.Trim() == _values.Currency.Trim() && curr.EffectDate == _values.EffectDate).FirstOrDefault().Remarks = _values.Remarks ;

                    grdCurrency.AutoGenerateColumns = false;
                    grdCurrency.DataSource = null;
                    grdCurrency.DataSource = currencyList;
                    grdCurrency.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    var currY = CheckExgRates();
                    if (currY)
                    {
                        RefreshClearBtn.Enabled = true;
                    }
                    else
                    {
                        RefreshClearBtn.Enabled = false;
                    }
                
            }
            catch (Exception ex)
            {

            }
        }

        private void chkNotInvoice_CheckedChanged(object sender, EventArgs e)
        {
            if(chkNotInvoice.Checked )
            {
                ////grdConsAWB.DataSource = null;
                ////var tempList = listOpsConsAWB.FindAll(not => not.TotalDutyVal > 0 && not.InvNoDTaxChg == 0);
                ////grdConsAWB.DataSource = tempList;
                ////lblTotAwbs.Text = "Total AWBs : " + tempList.Count().ToString();
                ////lblUnprocessed.Text = "Unprocessed : " + tempList.FindAll(c => c.ShipValueType == null || c.ShipValueType.Trim() == "").Count.ToString();
                FilterList(null);
              
            }
            else
            {
                FilterList(null);
                //grdConsAWB.DataSource = null;              
                //grdConsAWB.DataSource = listOpsConsAWB;
                //lblTotAwbs.Text = "Total AWBs : " + listOpsConsAWB.Count().ToString();
                //lblUnprocessed.Text = "Unprocessed : " + listOpsConsAWB.FindAll(c => c.ShipValueType == null || c.ShipValueType.Trim() == "").Count.ToString();
            }
        }

        private void chkPayAll_CheckedChanged(object sender, EventArgs e)
        {
            if(chkPayAll.Checked  )
            {
                rdCons.Checked = false; rdCons.Enabled = false;
                rdShipper.Checked = false; rdShipper.Enabled = false;
                rdOther.Checked = false; rdOther.Enabled = false;
                FilterList(null);
               
            }
            else
            {
                rdCons.Enabled = true  ;
                rdShipper.Enabled = true ;
                rdOther.Enabled = true ;
                FilterList(null);
            }
        }

        private void rdShipper_CheckedChanged(object sender, EventArgs e)
        {
           if(rdShipper.Checked )
            {
                FilterList(null);                
            }
        }

        private void rdCons_CheckedChanged(object sender, EventArgs e)
        {
            if(rdCons.Checked )
            {
                FilterList(null);
              
            }
        }

        private void rdOther_CheckedChanged(object sender, EventArgs e)
        {
            if(rdOther.Checked)
            {
                FilterList(null);              
            }
        }

        private string GetBillType()
        {
            var _billtype = "";
            if (rdCons.Checked)
            {
                _billtype = "C";
            }
            else if (rdShipper.Checked)
            {
                _billtype = "S";
            }
            else if (rdOther.Checked)
            {
                _billtype = "O";
            }

            return _billtype;
        }
        private void FilterList(  List<string> type)
        {
            tempOpsConsAWB.Clear();
            tempOpsConsAWB.AddRange( listOpsConsAWB);
            List<string> typeValues = new List<string>();

            foreach (DataGridViewRow r in grdClrType.Rows)
            {
                if (r.Cells["ClrSelect"].Value.ToString() == "True")
                {
                    typeValues.Add(r.Cells["Type"].Value.ToString());
                }
            }

            if (typeValues.Count >0)
            {                
                tempOpsConsAWB= tempOpsConsAWB.Where(fl => typeValues.Contains(fl.ShipValueType.Trim())).ToList();
            }

           if(chkNotInvoice.Checked )
            {
                tempOpsConsAWB = tempOpsConsAWB.Where(not => not.TotalDutyVal > 0 && not.InvNoDTaxChg == 0).ToList();
                
            }

           if(chkPayAll.Checked )
            {

            }
           else
            {
                if (rdShipper.Checked)
                {
                    tempOpsConsAWB= tempOpsConsAWB.Where(payT => payT.BillDtaxChg == "S").ToList();
                }

                if(rdCons.Checked)
                {
                    tempOpsConsAWB = tempOpsConsAWB.Where(payT => payT.BillDtaxChg == "C").ToList();
                }

                if(rdOther.Checked )
                {
                    tempOpsConsAWB= tempOpsConsAWB.Where(payT => payT.BillDtaxChg == "O").ToList();
                }

            }



            grdConsAWB.DataSource = null;
            grdConsAWB.DataSource = tempOpsConsAWB;
            this.grdConsAWB.CommitEdit(DataGridViewDataErrorContexts.Commit);
            lblTotAwbs.Text = "Total AWBs : " + tempOpsConsAWB.Count().ToString();
            lblUnprocessed.Text = "Unprocessed : " + tempOpsConsAWB.FindAll(c => c.ShipValueType == null || c.ShipValueType.Trim() == "").Count.ToString();
            this.loadClearenceType(listOpsConsAWB );
        }
    }
}
