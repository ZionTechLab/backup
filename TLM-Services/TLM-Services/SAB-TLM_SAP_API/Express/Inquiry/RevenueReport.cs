using Express.Interfaces.Inquiry;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Helpers;
using Express.UI.Factory.Inquiry;
using Express.UI.Filters.View;
using Express.UI.Helpers;
using Express.View.Domain.Filters;
using Express.View.Domain.Inquiry;
using Express.View.Domain.Login;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Express.UI.Inquiry
{
    public partial class RevenueReport : Form
    {
        private readonly IRevenuRepo _revRepo;
        private List<AgencyDomainViewcs> _agencyList = null;
        private RevenuPramDomainView _param;
        private IList<RevenuDomainView> _revenReport;
        private IList<SalesAreaDomainView> _salesArea;
        public RevenueReport()
        {
            InitializeComponent();
            if (_revRepo == null)
            {
                _revRepo = InquryUIFacotry.GetService<IRevenuRepo>();
            }
            _param = new RevenuPramDomainView();
            chkInvStatusAll.Checked = true;
            chkInvoiceAll.Checked = true;
            chkRevAll.Checked = true;
            chkSalesArea.Checked = true;
            chkCustomerAll.Checked = true;
            chkPrnInvDateAll.Checked = true;
            grdInqRevenu.AutoGenerateColumns = false;
            _param.CompanyID = LoginInfoView.COMPANYID;
            txtOrgName.ReadOnly = true;
            bgIntialWork.RunWorkerAsync();
        }

        private void bgIntialWork_DoWork(object sender, DoWorkEventArgs e)
        {
            _agencyList = _revRepo.GetAgencyDetail(LoginInfoView.USERID, LoginInfoView.MODULEID, LoginInfoView.MENUCODE).ToList();


        }

        private void bgIntialWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            cmb_agency.DataSource = _agencyList;
            cmb_agency.DisplayMember = "AgncyName";
            cmb_agency.ValueMember = "AgncyID";
        }

        private void cmb_agency_SelectedValueChanged(object sender, EventArgs e)
        {

            try
            {
                var _agency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
                txt_company.Text = _agency.CompName;
                _param.AgencyID = _agency.AgncyCode;
                _salesArea = _revRepo.GetSalesArea(LoginInfoView.COMPANYID, _param.AgencyID);
                cmbSalesArea.DataSource = _salesArea;
                ClearRevenuGrid();
            }
            catch
            {

            }
        }

        private void btnOrgSearch_Click(object sender, EventArgs e)
        {
            var _search = new OrgSearchValueDomainView
            {
                OrgName = txtOrgName.Text
            };
            new CustomerSearch(ref _search).ShowDialog();

            if (_search.OrgCode != 0)
            {
                SetDutyOrgnization(_search);
            }


        }

        private void SetDutyOrgnization(OrgSearchValueDomainView _search)
        {
            txtOrgCode.Text = _search.OrgCode.ToString();
            txtOrgName.Text = _search.OrgName;
        }

        private void ClearRevenuGrid()
        {
            grdInqRevenu.DataSource = null;

        }

        #region Radio/ Check Change

        private void chkCustomerAll_CheckedChanged(object sender, EventArgs e)
        {
            ClearRevenuGrid();
            if (chkCustomerAll.Checked)
            {
                txtOrgCode.Text = "";
                txtOrgName.Text = "";
                _param.IsAllCust = 1;
                btnOrgSearch.Enabled = false;
                
            }
            else
            {
                _param.IsAllCust = 0;
                btnOrgSearch.Enabled = true;
            }
        }

        private void chkRevAll_CheckedChanged(object sender, EventArgs e)
        {
            ClearRevenuGrid();
            if (chkRevAll.Checked)
            {
                _param.IsAllRevType = 1;
                
                SetRevStatusEnability(false);
            }
            else
            {
                _param.IsAllRevType = 0;
                rdRevImport.Checked = true;
                SetRevStatusEnability(true);
            }
        }

        private void SetRevStatusEnability(bool _value)
        {
            rdRevImport.Enabled = _value;
            rdRevExport.Enabled = _value;
            rdRevPickup.Enabled = _value;
            rdRevDelivery.Enabled = _value;
            rdRev3rd.Enabled = _value;
        }

       

        private void chkInvoiceAll_CheckedChanged(object sender, EventArgs e)
        {
            ClearRevenuGrid();
            if (chkInvoiceAll.Checked )
            {
                _param.IsAllInvDate = 1;
                SetInvDateEanbility(false);
            }
            else
            {
                _param.IsAllInvDate = 0;
                SetInvDateEanbility(true);


            }
        }

        private void SetInvDateEanbility( bool _value)
        {
            dteInvFrom.Enabled = _value;
            dteInvTo.Enabled = _value;
        }
       

        private void chkPrnInvDateAll_CheckedChanged(object sender, EventArgs e)
        {
            ClearRevenuGrid();
            if (chkPrnInvDateAll.Checked)
            {
                _param.IsAllInvPrnDate = 1;
                SetPrnEnability(false);
            }
            else
            {
                _param.IsAllInvPrnDate = 0;
                SetPrnEnability(true);
            }
        }

        public void SetPrnEnability(bool _value)
        {
            dtePrnInvFrom.Enabled = _value;
            dtePrnInvTo.Enabled = _value;
        }

        private void chkSalesArea_CheckedChanged(object sender, EventArgs e)
        {
            ClearRevenuGrid();
            if (chkSalesArea.Checked)
            {
                _param.IsAllSalesArea = 1;
                SetSalesAreaEnability(false);
            }
            else
            {
                _param.IsAllSalesArea = 0;
                SetSalesAreaEnability(true);
            }
        }

        private void SetSalesAreaEnability(bool _value)
        {
            cmbSalesArea.Enabled = _value;
        }

        

        private void chkInvStatusAll_CheckedChanged(object sender, EventArgs e)
        {
            ClearRevenuGrid();
            if (chkInvStatusAll.Checked)
            {
                _param.IsAllInvType = 1;
                SetInvStatusEnability(false);
            }
            else
            {
                _param.IsAllInvType = 0;
                rdInvInvoiced.Checked = true;
                SetInvStatusEnability(true);
            }        
        }
        public void SetInvStatusEnability(bool _value)
        {
            rdInvInvoiced.Enabled = _value;
            rdInvUnbill.Enabled = _value;
            rdInvUninvoice.Enabled = _value;
        }

        private void rdRevImport_CheckedChanged(object sender, EventArgs e)
        {
            ClearRevenuGrid();
            if (chkRevAll.Checked )
            {
                _param.RevImport = 0;
            }
            else
            {
                if(rdRevImport.Checked )
                {
                    _param.RevImport = 1;
                }
                else
                {
                    _param.RevImport = 0;
                }
            }
        }

        private void rdRevPickup_CheckedChanged(object sender, EventArgs e)
        {
            ClearRevenuGrid();
            if (chkRevAll.Checked)
            {
                _param.RevPickUp = 0;
            }
            else
            {
                if (rdRevPickup.Checked)
                {
                    _param.RevPickUp = 1;
                }
                else
                {
                    _param.RevPickUp = 0;
                }
            }
        }

        private void rdRev3rd_CheckedChanged(object sender, EventArgs e)
        {
            ClearRevenuGrid();
            if (chkRevAll.Checked)
            {
                _param.Rev3rdParty = 0;
            }
            else
            {
                if (rdRev3rd.Checked)
                {
                    _param.Rev3rdParty = 1;
                }
                else
                {
                    _param.Rev3rdParty = 0;
                }
            }
        }

        private void rdRevExport_CheckedChanged(object sender, EventArgs e)
        {
            ClearRevenuGrid();
            if (chkRevAll.Checked)
            {
                _param.RevExport = 0;
            }
            else
            {
                if (rdRevExport.Checked)
                {
                    _param.RevExport = 1;
                }
                else
                {
                    _param.RevExport = 0;
                }
            }
        }

        private void rdRevDelivery_CheckedChanged(object sender, EventArgs e)
        {
            ClearRevenuGrid();
            if (chkRevAll.Checked)
            {
                _param.RevDelivery = 0;
            }
            else
            {
                if (rdRevDelivery.Checked)
                {
                    _param.RevDelivery = 1;
                }
                else
                {
                    _param.RevDelivery = 0;
                }
            }
        }

        private void rdInvInvoiced_CheckedChanged(object sender, EventArgs e)
        {
            ClearRevenuGrid();
            if (chkInvStatusAll.Checked)
            {
                _param.InvInvoiced = 0;
            }
            else
            {
                if (rdInvInvoiced.Checked)
                {
                    _param.InvInvoiced = 1;
                }
                else
                {
                    _param.InvInvoiced = 0;
                }
            }
        }

        private void rdInvUnbill_CheckedChanged(object sender, EventArgs e)
        {
            ClearRevenuGrid();
            if (chkInvStatusAll.Checked)
            {
                _param.InvUnbill = 0;
            }
            else
            {
                if (rdInvUnbill.Checked)
                {
                    _param.InvUnbill = 1;
                }
                else
                {
                    _param.InvUnbill = 0;
                }
            }
        }

        private void rdInvUninvoice_CheckedChanged(object sender, EventArgs e)
        {
            ClearRevenuGrid();
            if (chkInvStatusAll.Checked)
            {
                _param.InvUninvoiced = 0;
            }
            else
            {
                if (rdInvUninvoice.Checked)
                {
                    _param.InvUninvoiced = 1;
                }
                else
                {
                    _param.InvUninvoiced = 0;
                }
            }
        }


        #endregion

        private void btnRetrive_Click(object sender, EventArgs e)
        {
            if(_param.CompanyID ==0)
            {
                MessageNotification.MessageBoxError("Please assing company code", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if(_param.AgencyID == 0)
            {
                MessageNotification.MessageBoxError("Please assing agency code", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if(chkCustomerAll.Checked==false )
            {
                if(txtOrgCode.Text ==null || txtOrgCode.Text =="")
                {
                    MessageNotification.MessageBoxError("Please select customer", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }
            }

            if(chkSalesArea.Checked==false )
            {
                var item = (SalesAreaDomainView)cmbSalesArea.SelectedItem;
                if (item == null || item.SalesAreaID ==null || item.SalesAreaID =="")
                {
                    MessageNotification.MessageBoxError("Please select sales area", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }
                else
                {
                    _param.SalesArea = item.SalesAreaID.Trim();
                }
               
            }

            _param.TrDateFrom = DateTimeValidator.GetAppDateformat( dteTransFrom.Value);
            _param.TrDateTo = DateTimeValidator.GetAppDateformat(dteTransTo.Value );
            _param.CustomerCode = (chkCustomerAll.Checked == true) ? 0 : Convert.ToInt32(txtOrgCode.Text);
            _param.InvDateFrom = DateTimeValidator.GetAppDateformat( dteInvFrom.Value);
            _param.InvDateTo = DateTimeValidator.GetAppDateformat( dteInvTo.Value);
            _param.PrnInvDateFrom = DateTimeValidator.GetAppDateformat( dtePrnInvFrom.Value);
            _param.PrnInvDateTo = DateTimeValidator.GetAppDateformat( dtePrnInvTo.Value);
           /// _param.SalesArea = (chkSalesArea.Checked == true) ? "" : "";


            if ( !bgRecRetrive.IsBusy )
            {
                bgRecRetrive.RunWorkerAsync();
            }
           else
            {
                MessageNotification.MessageBoxError("Please wait revenue report is running", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Information);
            }
           
        }

        private void bgRecRetrive_DoWork(object sender, DoWorkEventArgs e)
        {
            _revenReport = _revRepo.GetRevenu(_param);
        }

        private void bgRecRetrive_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            grdInqRevenu.DataSource = _revenReport;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(_revenReport==null)
            {
                MessageNotification.MessageBoxError("Please retreive data before export", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if(_revenReport.Count == 0)
            {
                MessageNotification.MessageBoxError("Please retreive data before export", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            saveExcelDg.InitialDirectory = @"C:\";
            saveExcelDg.Title = "Save text Files";
            saveExcelDg.CheckFileExists = false;
            saveExcelDg.CheckPathExists = false ;
           
            saveExcelDg.DefaultExt = ".xlsx";
            saveExcelDg.Filter = "Excel files (*.xlsx) | *.xlsx";
            saveExcelDg.Title = "Save an Excel File";  
        
            var targetFile = AppDomain.CurrentDomain.BaseDirectory;
            string filename = DateTime.Now.ToString("yyyy-MM-dd HHmmssfff") + ".xlsx";
            saveExcelDg.FileName = filename;
            var  fileFull = Path.Combine(targetFile, filename);

            try
            {
                if (saveExcelDg.ShowDialog() == DialogResult.OK)
                {
                    using (Stream stream = saveExcelDg.OpenFile())
                    {
                        using (ExcelPackage pck = new ExcelPackage(stream))
                        {
                            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Responses");
                            ws.Cells["A1"].Value = "Trans Date"; ;
                            ws.Cells["B1"].Value = "AWB No";
                            ws.Cells["C1"].Value = "Route";
                            ws.Cells["D1"].Value = "Gateway";
                            ws.Cells["E1"].Value = "Station";
                            ws.Cells["F1"].Value = "Origin country";
                            ws.Cells["G1"].Value = "Destination country";
                            ws.Cells["H1"].Value = "Service";
                            ws.Cells["I1"].Value = "Package";
                            ws.Cells["J1"].Value = "Weight";
                            ws.Cells["K1"].Value = "Rev.Type";
                            ws.Cells["L1"].Value = "Inv.Statues";
                            ws.Cells["M1"].Value = "Prn.Ac.No";
                            ws.Cells["N1"].Value = "Customer Code";
                            ws.Cells["O1"].Value = "Customer Name";
                            ws.Cells["P1"].Value = "Invoice.Date";
                            ws.Cells["Q1"].Value = "Invoice No";
                            ws.Cells["R1"].Value = "Currency";
                            ws.Cells["S1"].Value = "Sales Area";
                            ws.Cells["T1"].Value = "Invoice Amount";
                            ws.Cells["U1"].Value = "GDR Cost";
                            ws.Cells["V1"].Value = "SAB FSI ";
                            ws.Cells["W1"].Value = "SAB OT CHG";
                            ws.Cells["X1"].Value = "Gross Profit";
                            ws.Cells["Y1"].Value = "FDX Invoice Date";
                            ws.Cells["Z1"].Value = "FDX Invoice #";
                            ws.Cells["AA1"].Value = "Curr";
                            ws.Cells["AB1"].Value = "FDX FRT AMT";
                            ws.Cells["AC1"].Value = "FDX Fuel AMT";
                            ws.Cells["AD1"].Value = "FDX OT CHG";
                            ws.Cells["AE1"].Value = "FDX total AMT";
                            ws.Cells["AF1"].Value = "Cost Differnce";

                            ws.Cells["A2"].LoadFromCollection(Collection: _revenReport, PrintHeaders: false);
                            pck.Save();
                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
           
           
           



           


            //using (var stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None, 0x2000, false))
            //{

            //    using (ExcelPackage pck = new ExcelPackage(stream))
            //    {
            //        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Responses");
            //        ws.Cells["A1"].Value = "Trans Date"; ;
            //        ws.Cells["B1"].Value = "AWB No";
            //        ws.Cells["C1"].Value = "Route";
            //        ws.Cells["D1"].Value = "Gateway";
            //        ws.Cells["E1"].Value = "Station";
            //        ws.Cells["F1"].Value = "Origin country";
            //        ws.Cells["G1"].Value = "Destination country";
            //        ws.Cells["H1"].Value = "Service";
            //        ws.Cells["I1"].Value = "Package";
            //        ws.Cells["J1"].Value = "Weight";
            //        ws.Cells["K1"].Value = "Rev.Type";
            //        ws.Cells["L1"].Value = "Inv.Statues";
            //        ws.Cells["M1"].Value = "Prn.Ac.No";
            //        ws.Cells["N1"].Value = "Customer Code";
            //        ws.Cells["O1"].Value = "Customer Name";
            //        ws.Cells["P1"].Value = "Invoice.Date";
            //        ws.Cells["Q1"].Value = "Invoice No";
            //        ws.Cells["R1"].Value = "Currency";
            //        ws.Cells["S1"].Value = "Sales Area";
            //        ws.Cells["T1"].Value = "Invoice Amount";
            //        ws.Cells["U1"].Value = "GDR Cost";
            //        ws.Cells["V1"].Value = "SAB FSI ";
            //        ws.Cells["W1"].Value = "SAB OT CHG";
            //        ws.Cells["X1"].Value = "Gross Profit";
            //        ws.Cells["Y1"].Value = "FDX Invoice Date";
            //        ws.Cells["Z1"].Value = "FDX Invoice #";
            //        ws.Cells["AA1"].Value = "Curr";
            //        ws.Cells["AB1"].Value = "FDX FRT AMT";
            //        ws.Cells["AC1"].Value = "FDX Fuel AMT";
            //        ws.Cells["AD1"].Value = "FDX OT CHG";
            //        ws.Cells["AE1"].Value = "FDX total AMT";
            //        ws.Cells["AF1"].Value = "Cost Differnce";


            //        ws.Cells["A2"].LoadFromCollection(Collection: _revenReport, PrintHeaders: false);
            //        pck.Save();

            //    }

            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
