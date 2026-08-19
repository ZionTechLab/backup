using Express.Interfaces.Inquiry;
using Express.Interfaces.Report.Inquiry;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Helpers;
using Express.UI.Factory.Inquiry;
using Express.UI.Factory.Report.Inquiry;
using Express.UI.Helpers;
using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Inquiry;
using Express.View.Domain.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express.UI.Inquiry
{
    public partial class ShipmentHeld : Form
    {
        private readonly IShipmentHeld _inqData;
        private IList<GatewaysDomainView> _gatewayDetails;
        private IList<StationDomainView> _stationDetails;
        private readonly InqShipmentHeldPara _para;
        private readonly IInquiryReportProvider _report;
       private  IList<InqShipmetHeldDomainView> _InqSummery;
       
        //  private 
        public ShipmentHeld()
        {
            InitializeComponent();
            if(_inqData ==null )
            {
                _inqData = InquryUIFacotry.GetService<IShipmentHeld>();
            }

            if(_report==null )
            {
                _report = RptInquiryUIFactory.GetService<IInquiryReportProvider>();
            }

            _InqSummery = new List<InqShipmetHeldDomainView>();
            _gatewayDetails = new List<GatewaysDomainView>();
            _stationDetails = new List<StationDomainView>();
            _para = new InqShipmentHeldPara();
            chkGateway.Checked = true;
            chkStation.Checked = true;
            grvInqShipment.AutoGenerateColumns = false;
            rdSummery.Checked = true;           
            GetUserAgency();


        }



        #region shimpment_held_events
        private void bgInqShipWork_DoWork(object sender, DoWorkEventArgs e)
        {
            _stationDetails = _inqData.GetStations(_para.CompanyID ).ToList();
            _gatewayDetails = _inqData.GetGateways(_para.CompanyID).ToList();
        }

        private void bgInqShipWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmbStation.DataSource = _stationDetails;
            cmdGateway.DataSource = _gatewayDetails;
        }

        private void cmb_agency_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cmb_agency.SelectedItem !=null)
            {
                ClearInqGrid();
                if (!bgInqShipWork.IsBusy )
                {
                    var _agnDet = (AgencyDomainViewcs)cmb_agency.SelectedItem;
                    _para.CompanyID = _agnDet.CompID;
                    _para.AgencyId = _agnDet.AgncyCode;
                    _para.CompanyN = _agnDet.CompName;
                    _para.AgencyN = _agnDet.AgncyName;
                    txtCompany.Text = _agnDet.CompName;
                    bgInqShipWork.RunWorkerAsync();
                }
                else
                {
                    MessageNotification.MessageBoxError("Please wait, data is loading", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Information);
                }
               
            }
        }

        private void chkGateway_CheckedChanged(object sender, EventArgs e)
        {
            if(chkGateway.Checked )
            {
                cmdGateway.Enabled = false;
            }
            else
            {
                cmdGateway.Enabled = true;
            }
            ClearInqGrid();
        }

        private void chkStation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStation.Checked)
            {
                cmbStation.Enabled = false;
            }
            else
            {
                cmbStation.Enabled = true;
            }
            ClearInqGrid();
        }

        private void btnRetrive_Click(object sender, EventArgs e)
        {
            if(!IsValidStation())
            {
                MessageNotification.MessageBoxError("Please select station", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Information);
                return;
            }
            if(!IsValidGateway())
            {
                MessageNotification.MessageBoxError("Please select station", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Information);
                return;
            }

            _para.GatewayID = (chkGateway.Checked == true) ? "" : ((GatewaysDomainView)cmdGateway.SelectedItem).GatewayID;
            _para.StationID = (chkStation.Checked == true) ? "" : ((StationDomainView)cmbStation.SelectedItem).StationID;
            _para.Uptodate = DateTimeValidator.GetAppDateformat( dteUpto.Value);

            ClearInqGrid();
            _InqSummery.Clear();
            _InqSummery = _inqData.GetShipmetHeld(_para);
            grvInqShipment.DataSource = _InqSummery;
            SetTotals(_InqSummery.ToList());
        }
        #endregion

        #region shipment_held_method
        private void GetUserAgency()
        {
            cmb_agency.DataSource = _inqData.GetAgencyDetail(LoginInfoView.USERID, LoginInfoView.MODULEID, LoginInfoView.MENUCODE);
        }

        private bool IsValidStation()
        {
            bool isValid = true;
            if(!chkStation.Checked )
            {
                if(cmbStation.SelectedItem ==null)
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        private bool IsValidGateway()
        {
            bool isValid = true;
            if (!chkGateway.Checked)
            {
                if (cmdGateway.SelectedItem == null)
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        private void ClearInqGrid()
        {
            grvInqShipment.DataSource = null;
            _InqSummery.Clear();
            txtDay1.Text = "0";
            txtDay2.Text = "0";
            txtDay3.Text = "0";
            txtDay4.Text = "0";
            txtDay5.Text = "0";
            txtDay6.Text = "0";
            txtDay7.Text = "0";
            txtMthan10.Text = "0";
            txtGrandTotal.Text = "0";
        }

        private void SetTotals(List<InqShipmetHeldDomainView> tempList)
        {
           try
            {
                InqShipmetHeldDomainView totals = (from p in tempList
                                                   group p by 1 into g
                                                   select new InqShipmetHeldDomainView
                                                   {
                                                       LineTotal = g.Sum(x => x.LineTotal),
                                                       Day1 = g.Sum(x => x.Day1),
                                                       Day2 = g.Sum(x => x.Day2),
                                                       Day3 = g.Sum(x => x.Day3),
                                                       Day4 = g.Sum(x => x.Day4),
                                                       Day5 = g.Sum(x => x.Day5),
                                                       Day6 = g.Sum(x => x.Day6),
                                                       Day7 = g.Sum(x => x.Day7),
                                                       MoreThanDay10 = g.Sum(x => x.MoreThanDay10)
                                                   }).FirstOrDefault();

                if (totals != null)
                {
                    txtDay1.Text = totals.Day1.ToString();
                    txtDay2.Text = totals.Day2.ToString();
                    txtDay3.Text = totals.Day3.ToString();
                    txtDay4.Text = totals.Day4.ToString();
                    txtDay5.Text = totals.Day5.ToString();
                    txtDay6.Text = totals.Day6.ToString();
                    txtDay7.Text = totals.Day7.ToString();
                    txtMthan10.Text = totals.MoreThanDay10.ToString();
                    txtGrandTotal.Text = totals.LineTotal.ToString();
                }
            }
            catch(Exception )
            {

            }
           
        }

        #endregion

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!IsValidStation())
            {
                MessageNotification.MessageBoxError("Please select station", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Information);
                return;
            }
            if (!IsValidGateway())
            {
                MessageNotification.MessageBoxError("Please select station", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Information);
                return;
            }

            

            _para.GatewayID = (chkGateway.Checked == true) ? "" : ((GatewaysDomainView)cmdGateway.SelectedItem).GatewayID;
            _para.StationID = (chkStation.Checked == true) ? "" : ((StationDomainView)cmbStation.SelectedItem).StationID;
            _para.GatewayN = (chkGateway.Checked == true) ? "" : ((GatewaysDomainView)cmdGateway.SelectedItem).GatewayN;
            _para.StationN = (chkStation.Checked == true) ? "" : ((StationDomainView)cmbStation.SelectedItem).StationN;
            _para.Uptodate = DateTimeValidator.GetAppDateformat(dteUpto.Value);

            PrintReport();
        }

        private void PrintReport()
        {
            if(rdSummery.Checked)
            {               
                _report.PrintShipmentHeldSammery(_InqSummery, _para);
            }

            if(rdDetail.Checked )
            {

            }
           
        }

        private void dteUpto_ValueChanged(object sender, EventArgs e)
        {
            ClearInqGrid();
        }
    }
}
