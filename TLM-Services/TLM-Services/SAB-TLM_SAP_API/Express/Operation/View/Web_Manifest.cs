using Express.Domain.Message;
using Express.Interfaces.Operations.Manifest;
using Express.Interfaces.Report.Operation;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Enum;
using Express.UI.Common.Helpers;
using Express.UI.Factory.Operations;
using Express.UI.Factory.Report.Operation;
using Express.UI.Helpers;
using Express.UI.SoapUI;
using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using Express.View.Domain.Report.Operation;
using Express.View.Domain.SoapUI;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Express.UI.Operation.View
{
    public partial class Web_Manifest : Form, IDataManipulate
    {
        private readonly IWebManifest<WebManifestDomainView> _dataProvider;
        List<WebManifestDomainView> AWBList = new List<WebManifestDomainView>();
        List<WebManifestDomainView> AWBDisplyList = new List<WebManifestDomainView>();
        private List<TNTAwbXmlDataDomainView> TNTAwbXmlData = new List<TNTAwbXmlDataDomainView>();
        private IList<AgencyDomainViewcs> agencyList;
        private IList<ClearenceStatusDomainView> _clearenceStatus;
        private IList<WebManiClearenceType> _clarenceType;
        private List<RefExgRatesDomainView> _exchangeRates ;
        private ManifestClearenceDomainView _manifestConfig;
        private ManifestProcessParamDomainView _clearParam;
        private readonly IOperationReportProvider _operationRpt;
        private string ShipValType = "";
        public Web_Manifest()
        {
            InitializeComponent();
            if (_dataProvider == null)
            {
                _dataProvider = OperationsUIFacotry.GetService<IWebManifest<WebManifestDomainView>>();
            }
            if(_operationRpt ==null )
            {
                _operationRpt = RptOperationUIFactory.GetService<IOperationReportProvider>();
            }
            date_fdate.Value = System.DateTime.Now.Date;
            date_todate.Value= System.DateTime.Now.Date;

           

            dataManipulate1.NewButtonClick += new EventHandler(NewMethod);
            dataManipulate1.SaveButtonClick += new EventHandler(SaveMethod);
            dataManipulate1.EditButtonClick += new EventHandler(EditMethod);
            dataManipulate1.CancelButtonClick += new EventHandler(ClearMethod);
            dataManipulate1.CloseButtonClick += new EventHandler(CloseForm);
            dataManipulate1.DelteButtonClick += new EventHandler(DeleteMethod);
            dataManipulate1.PreviewButtonClick += new EventHandler(previewMethod);

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.HIDEVISIBLE);

            dataManipulate1.CustomButtonState(ButtonTypes.PRINT, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PROCESS, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.HIDEVISIBLE);

            FormState = FormStateEnum.Initial;
            btn_import.Enabled = false;
            button2.Enabled = false;
            btn_refreshclearencevalues.Enabled = false;
           // btn_printmanifest.Enabled = false;
            radio_FS.Checked = true;
           // radio_shipall.Checked = true;
            radio_ds.Checked = true;
            checkBox2.Checked = true;
            checkBox1.Checked = true;
            checkBox3.Checked = true;
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox5.Checked = true;
            checkBox6.Checked = true;
            checkBox7.Checked = true;
            checkBox8.Checked = true;
            checkBox9.Checked = true;
            checkBox4.Checked = true;
            _exchangeRates = new List<RefExgRatesDomainView>();
            grvClearenceType.AutoGenerateColumns = false;
            grvExgRate.AutoGenerateColumns = false;
            grvClearenceStatus.AutoGenerateColumns = false;
            dataGridView1.AutoGenerateColumns = false;
     
            _manifestConfig = new ManifestClearenceDomainView();
            _clearParam = new ManifestProcessParamDomainView();
           /// webManifestBack.RunWorkerAsync();
        }

        private void lbl_frightbill_Click(object sender, EventArgs e)
        {

        }

        private void lbl_cargo_Click(object sender, EventArgs e)
        {

        }

        private void lbl_FromDate_Click(object sender, EventArgs e)
        {

        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            FormState = FormStateEnum.Import;
           OpenFileDialog fileDialog = new OpenFileDialog();
            var SelectedAgencyItem = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            if (cmb_agency.SelectedItem != null)
            {
                //if (SelectedAgencyItem.AgncyID == "FedEx")
                //{
                    fileDialog.DefaultExt = ".xlsx";
                    fileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    fileDialog.ShowDialog();
                    string FilePath = fileDialog.FileName;
                    if (FilePath != null && FilePath != "")
                    {
                        AWBList.Clear();
                        LoadFedexExcel(FilePath, SelectedAgencyItem);
                        if (AWBList.Count != 0)
                        {
                            dataGridView1.AutoGenerateColumns = false;
                            dataGridView1.DataSource = AWBList;
                            txtTotAwb.Text = AWBList.Count().ToString();
                            txtRoutePendind.Text ="0";
                        }
                    }
                //}
                //else
                //{
                    //fileDialog.Filter = "XML files (*.xml)|*.xml";
                    //fileDialog.ShowDialog();
                    //string FilePath = fileDialog.FileName;
                    //if (FilePath != null && FilePath != "")
                    //{
                    //    AWBList.Clear();
                    //    TNTAwbXmlData.Clear();
                    //    ReadXamlFile(FilePath);
                    //    SaveTntAwbDetails(SelectedAgencyItem);
                    //    if (TNTAwbXmlData.Count != 0)
                    //    {
                    //        if (AWBList.Count != 0)
                    //        {
                    //            dataGridView1.AutoGenerateColumns = false;
                    //            dataGridView1.DataSource = AWBList;
                    //            txtTotAwb.Text = AWBList.Count().ToString();

                    //        }
                    //        else
                    //        {
                    //            txtTotAwb.Text = "";
                    //        }
                    //    }
                    //}
                //}
            }
            else
            {
                MessageNotification.MessageBoxError("Please Select the Agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
        }

        private void Web_Manifest_Load(object sender, EventArgs e)
        {
            try
            {
                agencyList = _dataProvider.GetAgencyDetail(1, 200, 1002);
                cmb_agency.DataSource = agencyList;
                ////cmb_agency.DisplayMember = "AgncyName";
                ////cmb_agency.ValueMember = "AgncyID";


               

            }
            catch (Exception ex)
            {
                MessageNotification.MessageBoxError("Application Loading Failure", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
        }

        private void cmb_agency_SelectedIndexChanged(object sender, EventArgs e)
        {
            var extTypeItem = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            

            IList<CfgCountryDomainView> countryList = _dataProvider.GetCountryList();
            cmb_origin.DataSource = countryList;
            ////cmb_origin.DisplayMember = "CountryN";
            ////cmb_origin.ValueMember = "Country";
            cmb_origin.SelectedIndex = -1;
           

            try
            {
                ///AgencyDomainViewcs SelectedAgencyItem = null;
                if (extTypeItem != null)
                {
                    date_fdate.Value = DateTime.Now;
                    date_todate.Value = DateTime.Now;
                    txt_Cmp.Text = extTypeItem.CompName;
                   /// SelectedAgencyItem = (AgencyDomainViewcs)cmb_agency.SelectedItem;
                    _manifestConfig = _dataProvider.GetManifestClearenceConf(extTypeItem.CompID);


                    IList<GatewayDomainView> gatewayList = _dataProvider.GetGateways(extTypeItem.CountryCode);
                    cmb_destinationloc.DataSource = gatewayList;                   
                    cmb_destinationloc.DisplayMember = "LocationName";
                    cmb_destinationloc.ValueMember = "LocationID";
                    cmb_destinationloc.SelectedIndex = -1;
                    // FilterAWB();
                    webManifestBack.RunWorkerAsync();
                }
                else
                {
                    MessageNotification.MessageBoxError("Please Select the Agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                }
            }
            catch (Exception ex)
            {
                MessageNotification.MessageBoxError("Application Loading Failure", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }

            try
            {
               //// AgencyDomainViewcs SelectedAgencyItem = null;
                if (extTypeItem != null)
                {
                  
                    IList<ServiceTypeDomainView> serviceTypeList = _dataProvider.GetServiceType(extTypeItem.CompID, extTypeItem.AgncyCode);
                    combo_servicetype.DataSource = serviceTypeList;                   
                    combo_servicetype.DisplayMember = "SvcTypeN";
                    combo_servicetype.ValueMember = "SvcType";
                    combo_servicetype.SelectedIndex = -1;

                }
                else
                {
                    MessageNotification.MessageBoxError("Please Select the Agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                }
            }
            catch (Exception ex)
            {
                MessageNotification.MessageBoxError("Application Loading Failure", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }

        }

       
        private void combo_servicetype_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void cmb_origin_MouseClick(object sender, MouseEventArgs e)
        {
           
        }
     
        private DataTable ReadExcelFile(string path)
        {
            using (ExcelPackage excelPkg = new ExcelPackage())
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                excelPkg.Load(stream);
                ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets[1];
                return WorksheetToDataTable(oSheet);
            }

        }

        private DataTable WorksheetToDataTable(ExcelWorksheet oSheet)
        {
            int totalRows = oSheet.Dimension.End.Row;
            int totalCols = oSheet.Dimension.End.Column;
            DataTable dt = new DataTable(oSheet.Name);
            DataRow dr = null;
            for (int i = 1; i <= totalRows; i++)
            {
                if (i > 1) dr = dt.Rows.Add();
                for (int j = 1; j <= totalCols; j++)
                {
                    if (i == 1)
                        dt.Columns.Add(oSheet.Cells[i, j].Value.ToString());
                    else
                    {

                        try
                        {
                            dr[j - 1] = oSheet.Cells[i, j].Value.ToString();
                        }
                        catch (Exception)
                        {

                            dr[j - 1] = "";
                        }
                    }
                }
            }
            return dt;
        }

        public void LoadFedexExcel(string Path, AgencyDomainViewcs agency)
        {
            try
            {
                DataTable dt = ReadExcelFile(Path);

                foreach (DataRow dr in dt.Rows)
                {
                    //var AgnMpsNo = dr["FdxMasterNo"] == null ? "" : dr["FdxMasterNo"].ToString();
                    //var AgnTrackNo = "";
                    //var AgnAWBNo = dr["FdxTrackNo"] == null ? "" : dr["FdxTrackNo"].ToString();

                    //if (AgnMpsNo == "")
                    //{
                    //    AgnTrackNo = AgnAWBNo;
                    //    AgnMpsNo = "";

                    //}
                    //else if (AgnMpsNo == AgnAWBNo)
                    //{
                    //    AgnMpsNo = "";
                    //    AgnTrackNo = AgnAWBNo;
                    //}
                    //else
                    //{
                    //    string oldAwbNo = AgnAWBNo;
                    //    AgnAWBNo = AgnMpsNo;
                    //    AgnMpsNo = oldAwbNo;
                    //    AgnTrackNo = AgnMpsNo;
                    //}

                    WebManifestDomainView model = new WebManifestDomainView();
                    string AWb_String = dr["AWB #"] == null ? "" : dr["AWB #"].ToString();
                    model.AgnAWBNo = AWb_String;
                    model.CMPY = 201;
                    if (AWb_String.Length<12)
                    {
                        model.AgncyCode =20102;
                        model.AgncyID = "TNT";
                    }
                    else
                    {
                        model.AgncyCode = 20101;
                        model.AgncyID = "FedEx";
                    }
                    
                    model.ConsId = "";
                    model.ShipType = "I";

                    model.AgnMpsNo = "";
                    model.AgnTrackNo = dr["AWB #"] == null ? "" : dr["AWB #"].ToString();
                    model.ORIGIN = dr["ORIGIN"] == null ? "" : dr["ORIGIN"].ToString();
                    model.DESTIN = dr["DEST"] == null ? "" : dr["DEST"].ToString();
                    model.ORIGINGate = dr["ORIGIN"] == null ? "" : dr["ORIGIN"].ToString();
                    model.DESTINGate = dr["DEST"] == null ? "" : dr["DEST"].ToString();
                    model.ORGCOUNTRY = dr["ORIGIN CNTY"] == null ? "" : dr["ORIGIN CNTY"].ToString();
                    model.DESCOUNTRY = dr["EXPORT CNTY"] == null ? "" : dr["EXPORT CNTY"].ToString();

                    string ShipDateString = dr["SHIP DATE"] == null ? "" : dr["SHIP DATE"].ToString();
                    if (ShipDateString != "")
                    {

                        //string Ship_year = ShipDateString.Substring(0, 4);
                        //string Ship_month = ShipDateString.Substring(4, 2);
                        //string Ship_day = ShipDateString.Substring(6, 2);


                        //string Ship_year = ShipDateString.Substring(5, 2);
                        //string Ship_month = ShipDateString.Substring(2, 3);
                        //string Ship_day = ShipDateString.Substring(0, 2);
                        model.ShipDate = DateTimeValidator.GetAppDateformat(DateTime.Parse(ShipDateString));
                    }
                    else
                    {
                        model.ShipDate = DateTimeValidator.GetAppDateformat(DateTime.Parse("01-01-1900"));
                    }

                    model.ShipLocationType = "";
                    model.SenAccount = dr["SHIPPER ACCOUNT"] == null ? "" : dr["SHIPPER ACCOUNT"].ToString();
                    model.SenPhone = dr["SHIPPER PHONE"] == null ? "" : dr["SHIPPER PHONE"].ToString();
                    model.SenCountry = dr["SHIPPER COUNTRY"] == null ? "" : dr["SHIPPER COUNTRY"].ToString();
                    model.SenCode = "";
                    model.SenCompany = dr["SHIPPER COMPANY"] == null ? "" : dr["SHIPPER COMPANY"].ToString();
                    model.SenID = "";
                    model.SenName = dr["SHIPPER NAME"] == null ? "" : dr["SHIPPER NAME"].ToString();
                    model.SenAddr1 = dr["SHIPPER ADDRESS1"] == null ? "" : dr["SHIPPER ADDRESS1"].ToString();
                    model.SenAddr2 = (dr["SHIPPER ADDRESS2"] == null ? "" : dr["SHIPPER ADDRESS2"].ToString());
                    string SenCity = dr["SHIPPER CITY"] == null ? "" : dr["SHIPPER CITY"].ToString();
                    if (SenCity != null)
                    {
                        try { model.SenCity = int.Parse(SenCity); }
                        catch (Exception) { model.SenCity = 0; }
                    }
                    else { model.SenCity = 0; }
                    model.SenCityN = SenCity;
                    model.SenState = dr["SHIPPER STATE"] == null ? "" : dr["SHIPPER STATE"].ToString();
                    model.SenZip = dr["SHIPPER POSTAL"] == null ? "" : dr["SHIPPER POSTAL"].ToString();
                    model.RecAccount = dr["CONSIGNEE ACCOUNT"] == null ? "" : dr["CONSIGNEE ACCOUNT"].ToString();
                    model.RecPhone = dr["CONSIGNEE PHONE"] == null ? "" : dr["CONSIGNEE PHONE"].ToString();
                    model.RecCompany = dr["CONSIGNEE COMPANY"] == null ? "" : dr["CONSIGNEE COMPANY"].ToString();
                    model.RecCode = "";
                    model.RecName = dr["CONSIGNEE NAME"] == null ? "" : dr["CONSIGNEE NAME"].ToString();
                    model.RecAddr1 = dr["CONSIGNEE ADDRESS1"] == null ? "" : dr["CONSIGNEE ADDRESS1"].ToString();
                    model.RecAddr2 = (dr["CONSIGNEE ADDRESS2"] == null ? "" : dr["CONSIGNEE ADDRESS2"].ToString());
                    string RecCity = dr["CONSIGNEE CITY"] == null ? "" : dr["CONSIGNEE CITY"].ToString();
                    if (RecCity != null)
                    {
                        try { model.RecCity = int.Parse(RecCity); }
                        catch (Exception) { model.RecCity = 0; }
                    }
                    else { model.RecCity = 0; }
                    model.RecCityN = RecCity;
                    model.RecState = dr["CONSIGNEE STATE"] == null ? "" : dr["CONSIGNEE STATE"].ToString();
                    model.RecCountry = dr["CONSIGNEE COUNTRY"] == null ? "" : dr["CONSIGNEE COUNTRY"].ToString();
                    model.RecZip = dr["CONSIGNEE POSTAL"] == null ? "" : dr["CONSIGNEE POSTAL"].ToString();

                    string Str_TotPkgs = dr["TOTAL"].ToString();
                    if (Str_TotPkgs != "") model.TotPkgs = int.Parse(Str_TotPkgs); else model.TotPkgs = 0;

                    string str_SvcType = dr["SERVICE NEW"].ToString();
                    string str_PackType = dr["PACKAGE TYPE"].ToString();
                    model.SvcType = str_SvcType == null ? "" : str_SvcType;
                    model.PackType = str_PackType == null ? "" : str_PackType.ToString();
                          
                   

                    string Str_TotWgt = dr["TOTAL WGT"].ToString();
                    string Str_WgtU = Str_TotWgt.Substring(Str_TotWgt.Length - 1, 1).ToLower();

                    string Str_Wgt = Str_TotWgt.Substring(0 , Str_TotWgt.Length-1).ToLower();

                    if (Str_Wgt != "") model.TotWgt = decimal.Parse(Str_Wgt); else model.TotWgt = 0;
                    model.WgtU = Str_WgtU.ToString();

                    string str_dimVolU = "";
                    string Str_DimVol = "";
                    if (Str_DimVol != "")
                    {
                        if (str_dimVolU.Trim().ToLower() == "c")
                        {
                            model.DimVol = Math.Round(((decimal.Parse(Str_DimVol)) / 5000), 2);
                            model.DimVolU = "K";
                        }
                        else if (str_dimVolU.Trim().ToLower() == "i")
                        {
                            model.DimVol = Math.Round((((decimal.Parse(Str_DimVol)) * 16.3871m) / 5000), 2);
                            model.DimVolU = "K";
                        }

                    }
                    else
                    {
                        model.DimVol = 0m;
                        model.DimVolU = "";
                    }
                    string Str_CarriageVal = dr["CUSTOMS VAL"].ToString();
                    if (Str_CarriageVal != "") model.CarriageVal = decimal.Parse(Str_CarriageVal); else model.CarriageVal = 0;
                    model.CarriageValCur = dr["CURR"] == null ? "" : dr["CURR"].ToString();

                    model.Descrip = dr["SHIPMENT DESCRIPTION"] == null ? "" : dr["SHIPMENT DESCRIPTION"].ToString();
                    model.SenRefNotes = "";
                    model.DocNdoc = "";
                    //model.SenRefNotes = dr["SenRefNotes"] == null ? "" : dr["SenRefNotes"].ToString();
                    //model.DocNdoc = dr["DocNdoc"] == null ? "" : dr["DocNdoc"].ToString();
                    model.HoldAtLoc = "";
                    model.BillTransChg = dr["BILL TO"] == null ? "" : dr["BILL TO"].ToString();
                    model.BillTransAcNo = "";
                    model.BillDtaxChg = dr["BILL DUTY"] == null ? "" : dr["BILL DUTY"].ToString();
                    model.BillDtaxAcNo = "";
                    string IntComDateString ="";
                    if (IntComDateString != "")
                    {
                        string IntCom_year = IntComDateString.Substring(0, 4);
                        string IntCom_month = IntComDateString.Substring(4, 2);
                        string IntCom_day = IntComDateString.Substring(6, 2);
                        DateTime d = new DateTime(int.Parse(IntCom_year), int.Parse(IntCom_month), int.Parse(IntCom_day));
                        model.IntComDate = DateTimeValidator.GetAppDateformat(d);
                    }
                    else
                    {
                        model.IntComDate = DateTimeValidator.GetAppDateformat(DateTime.Parse("01-01-1900"));
                    }
                    string IntComTimeString = "";
                    if (IntComTimeString != "")
                    {
                        string Hour = IntComTimeString.Substring(0, 2);
                        string Minit = IntComTimeString.Substring(2, 2);
                        string Second = IntComTimeString.Substring(4, 2);
                        model.IntComTime = new TimeSpan(int.Parse(Hour), int.Parse(Minit), int.Parse(Second));
                    }
                    else
                    {
                        model.IntComTime = new TimeSpan();
                    }
                    model.Form = "";
                    model.Base = "";
                    string Str_CustomVal = dr["CUSTOMS VAL"].ToString();
                    if (Str_CustomVal != "") model.CustomVal = decimal.Parse(Str_CustomVal); else model.CustomVal = 0m;
                    model.CustomValCur = dr["CURR"] == null ? "" : dr["CURR"].ToString();
                    model.USM_LOGIN = LoginInfoView.USERID.ToString();
                    model.USM_DATE = DateTimeValidator.GetAppDateformat(System.DateTime.Now.Date);
                    WebManifestDomainView New_Awb_Item = new WebManifestDomainView();
                    New_Awb_Item = DataArangement(model);
                    AWBList.Add(New_Awb_Item);
                }
            }
            catch (OperationCanceledException ex)
            {
                MessageNotification.MessageBoxOK(ex.InnerException.ToString(), "Express");
            }
        }

        public WebManifestDomainView DataArangement(WebManifestDomainView Awb)
        {

            if (Awb.AgnMpsNo == "")
            {
                Awb.AgnTrackNo = Awb.AgnAWBNo;
                Awb.AgnMpsNo = "";

            }
            else if (Awb.AgnMpsNo == Awb.AgnAWBNo)
            {
                Awb.AgnMpsNo = "";
                Awb.AgnTrackNo = Awb.AgnAWBNo;
            }
            else
            {
                string oldAwbNo = Awb.AgnAWBNo;
                Awb.AgnAWBNo = Awb.AgnMpsNo;
                Awb.AgnMpsNo = oldAwbNo;
                Awb.AgnTrackNo = Awb.AgnMpsNo;
            }
            if (Awb.WgtU.ToLower() == "l")
            {
                Awb.WgtU = "K";
                Awb.TotWgt = Math.Round((Awb.TotWgt / 2.20462m), 2);
            }
            if (Awb.SvcType.Length == 2)
            {
                Awb.SvcType = Awb.SvcType;
            }
            else
            {
                Awb.SvcType = int.Parse(Awb.SvcType == null || Awb.SvcType == "" ? "0" : Awb.SvcType).ToString("00");
            }

            if (Awb.PackType.Trim().Length > 2)
            {
                Awb.PackType = Awb.PackType == null || Awb.PackType == "" ? "0" : Awb.PackType;
            }
            else
            {
                Awb.PackType = int.Parse(Awb.PackType == null || Awb.PackType == "" ? "0" : Awb.PackType).ToString("00");
            }

            //if (Awb.ShipType == "T")
            //{
            //    Awb.BillTransChg = "O";
            //}
            //else
            //{
            //    if (Awb.BillTransChg == "1")
            //    {
            //        Awb.BillTransChg = "S";
            //    }
            //    else if (Awb.BillTransChg == "2")
            //    {
            //        Awb.BillTransChg = "C";
            //    }
            //    else
            //    {
            //        Awb.BillTransChg = "O";
            //    }
            //}

            //if (Awb.BillDtaxChg == "1")
            //{
            //    Awb.BillDtaxChg = "S";
            //}
            //else if (Awb.BillDtaxChg == "2")
            //{
            //    Awb.BillDtaxChg = "C";
            //}
            //else
            //{
            //    Awb.BillDtaxChg = "O";
            //}
            return Awb;
        }

        public void NewMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.New;
            btn_import.Enabled = true;
            button2.Enabled = true;
            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);

            AWBList.Clear();
            AWBDisplyList.Clear();
            FormState = FormStateEnum.New;
            dataGridView1.DataSource = null;
            date_fdate.Value = DateTimeValidator.GetAppDateformat(System.DateTime.Now.Date);
            date_todate.Value = DateTimeValidator.GetAppDateformat(System.DateTime.Now.Date);
            cmb_origin.SelectedIndex = -1;
            cmb_destinationloc.SelectedIndex = -1;
            combo_servicetype.SelectedIndex = -1;
            txt_cargo.Text = "";
            txt_consignee.Text = "";
            checkBox2.Checked = true;
            checkBox1.Checked = true;
            checkBox3.Checked = true;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
        
            txtRoutePendind.Text = "";
            ShipValType = "";
            btn_printmanifest.Enabled = false;
            SetCleareClearenceTypeCal();
            SetClearExgRates();
            SetClearClearanceStatus();
        }

        public void SaveMethod(object param, EventArgs e)
        {
            FormState = (FormState != FormStateEnum.Update) ? FormStateEnum.Save : FormStateEnum.Update;
            ResponseMessage responce = null;
            WebManufestUploadWrappingDoaminView _manifestWrapping = new WebManufestUploadWrappingDoaminView();
            _manifestWrapping.ManifestList = AWBList;
            var vResult = CustomValidate.Instance.ValidateModel(_manifestWrapping);
            if (AWBList.Count != 0)
            {
                if (vResult == "")
                {
                    if (FormState == FormStateEnum.Save)
                    {
                        responce = _dataProvider.SaveWebAWBList(_manifestWrapping);
                    }
                    if (responce.IsSuccess)
                    {
                       
                        MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
                        dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                        dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                        dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                        dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                        dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
                        dataGridView1.DataSource = null;
                        btn_import.Enabled = false;
                        button2.Enabled = false;
                        txtTotAwb.Text = "";
                        txtRoutePendind.Text = "";
                        btn_printmanifest.Enabled = true ;
                        FormState = FormStateEnum.Print;
                    }
                    else
                    {
                        MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                    }
                }
                else
                {
                    MessageNotification.MessageBoxError(vResult, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                }
            }
            else
            {
                MessageNotification.MessageBoxError("No New AWB Found", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }

        }

        public void EditMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.Update;

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
        }

        public void ClearMethod(object param, EventArgs e)
        {
            Clear();
        }
        private void Clear()
        {
            FormState = FormStateEnum.Clear;
            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            AWBList.Clear();
            AWBDisplyList.Clear();
            FormState = FormStateEnum.Initial;
            dataGridView1.DataSource = null;
            date_fdate.Value = DateTimeValidator.GetAppDateformat(System.DateTime.Now.Date);
            date_todate.Value = DateTimeValidator.GetAppDateformat(System.DateTime.Now.Date);
            cmb_origin.SelectedIndex = -1;
            cmb_destinationloc.SelectedIndex = -1;
            combo_servicetype.SelectedIndex = -1;
            txt_cargo.Text = "";
            txt_consignee.Text = "";
            checkBox2.Checked = true;
            checkBox1.Checked = true;
            checkBox3.Checked = true;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
            txtRoutePendind.Text = "";
            btn_import.Enabled = false;
            button2.Enabled = false;
        }
        public void DeleteMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.Delete;
        }

        public void CloseForm(object param, EventArgs e)
        {
            this.Dispose();
        }

        public void FilterMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void PrintMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void previewMethod(object param, EventArgs e)
        {
            FilterAWB();
        }

        public void ImportMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ProccessMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private FormStateEnum _FormState;
        public FormStateEnum FormState
        {
            get { return _FormState; }
            set { _FormState = value; }
        }

        public void ReadXamlFile(string path)
        {
            string Sec_Name = "";
            string Sec_Origin = "";
            string Sec_Desti = "";
            string Sec_Mode = "";
            string Sec_ShippingDocType = "";
            string Sec_ShippingDocNo = "";
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList manifestList = doc.GetElementsByTagName("sector");
            foreach (XmlNode xml_item in manifestList)
            {
                XmlNodeList SectorDetailsNodesList = xml_item.SelectNodes("sectorDetails");
                XmlNodeList pieceDataNodesList = xml_item.SelectNodes("pieceData");

                foreach (XmlNode SectorDetail_item in SectorDetailsNodesList)
                {

                    Sec_Name = SectorDetail_item["name"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    Sec_Origin = SectorDetail_item["origin"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    Sec_Desti = SectorDetail_item["destination"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    Sec_Mode = SectorDetail_item["mode"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    Sec_ShippingDocType = SectorDetail_item["shippingDocType"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    Sec_ShippingDocNo = "";
                }

                foreach (XmlNode piece_item in pieceDataNodesList)
                {
                    string Sen_Name = "";
                    string Sen_Address1 = "";
                    string Sen_Address2 = "";
                    string Sen_Address3 = "";
                    string Sen_City = "";
                    string Sen_Country = "";
                    string Sen_Postal = "";
                    string Sen_AccountNo = "";

                    string Rec_Name = "";
                    string Rec_Address1 = "";
                    string Rec_Adderss2 = "";
                    string Rec_Address3 = "";
                    string Rec_City = "";
                    string Rec_Country = "";
                    string Rec_Postal = "";
                    string Rec_Account = "";
                    XmlNodeList PartyDataNodesList = piece_item.SelectNodes("partyData");
                    foreach (XmlNode Party_item in PartyDataNodesList)
                    {
                        string attrVal = Party_item.Attributes["partyType"].Value;
                        if (attrVal == "SENDER")
                        {
                            Sen_Name = Party_item["name"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                            Sen_Address1 = Party_item["address1"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                            Sen_Address2 = Party_item["address2"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                            Sen_Address3 = Party_item["address3"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                            Sen_City = Party_item["city"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                            Sen_Country = Party_item["country"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                            Sen_Postal = Party_item["postcode"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                            Sen_AccountNo = Party_item["accountNumber"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }

                        else if (attrVal == "RECEIVER")
                        {
                            Rec_Name = Party_item["name"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                            Rec_Address1 = Party_item["address1"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                            Rec_Adderss2 = Party_item["address2"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                            Rec_Address3 = Party_item["address3"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                            Rec_City = Party_item["city"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                            Rec_Country = Party_item["country"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                            Rec_Postal = Party_item["postcode"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                            Rec_Account = Party_item["accountNumber"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        }
                    }
                    TNTAwbXmlDataDomainView newData = new TNTAwbXmlDataDomainView();
                    newData.Piec_UnitID = piece_item["unitId"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    newData.Piec_UnitSeal = piece_item["unitSeal"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    newData.Piec_No = piece_item["pieceNumber"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    newData.Piec_ConsignmentNo = piece_item["consignmentNumber"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    newData.Piec_Origin = piece_item["origin"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    newData.Piec_Desti = piece_item["destination"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    newData.Piec_Product = piece_item["product"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    newData.Piec_Option1 = piece_item["option1"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    newData.Piec_Option2 = piece_item["option2"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    newData.Piec_Option3 = piece_item["option3"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    newData.Piec_Option4 = piece_item["option4"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    newData.Piec_Terms = piece_item["terms"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    newData.Piec_CollectionZone = piece_item["collectionZone"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    newData.Piec_DeliveryZone = piece_item["deliveryZone"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    newData.GoodDescription = piece_item["goodsDescription"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    string str_calect_Date = piece_item["collectionDate"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");

                    DateTime calect_Date = DateTime.Parse(str_calect_Date, new CultureInfo("de-DE", true));
                    newData.Collection_Date = DateTimeValidator.GetAppDisplayFormat(calect_Date);

                    newData.Collection_Time = new TimeSpan();
                    newData.NumberOf_Item = piece_item["numberOfPieces"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    string Contractual_Weight = piece_item["actualWeight"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "").Trim();
                    string Contractual_Weight_StringFormat = (Contractual_Weight.Substring(0, Contractual_Weight.Length - 3)).Trim();
                    newData.Contractual_Weight = decimal.Parse(Contractual_Weight_StringFormat.Trim());
                    string Actual_Weight = piece_item["contractualWeight"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "").Trim();
                    string Actual_Weight_StringFormat = (Actual_Weight.Substring(0, Actual_Weight.Length - 3)).Trim();
                    newData.Actual_Weight = decimal.Parse(Actual_Weight_StringFormat.Trim());
                    newData.Value = decimal.Parse(piece_item["value"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "").Trim());
                    newData.Currency = piece_item["currency"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    string Contractual_Vol = piece_item["contractualVolume"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "").Trim();
                    if ((Contractual_Vol.Substring(Contractual_Vol.Length - 3, 3)).ToLower() == "cm3")
                    {
                        string Contractual_Vol_StringFormat = (Contractual_Vol.Substring(0, Contractual_Vol.Length - 3)).Trim();
                        newData.Contractual_Vol = decimal.Parse(Contractual_Vol_StringFormat) / 500;
                    }
                    else if ((Contractual_Vol.Substring(Contractual_Vol.Length - 2, 2)).ToLower() == "m3")
                    {
                        string Contractual_Vol_StringFormat = (Contractual_Vol.Substring(0, Contractual_Vol.Length - 2)).Trim();
                        newData.Contractual_Vol = decimal.Parse(Contractual_Vol_StringFormat) * 200;
                    }
                    string Actual_Vol = piece_item["actualVolume"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "").Trim();
                    if ((Actual_Vol.Substring(Actual_Vol.Length - 3, 3)).ToLower() == "cm3")
                    {
                        string Actual_Vol_StringFormat = (Actual_Vol.Substring(0, Actual_Vol.Length - 3)).Trim();
                        newData.Actual_Vol = decimal.Parse(Actual_Vol_StringFormat) / 5000;
                    }
                    else if ((Actual_Vol.Substring(Actual_Vol.Length - 2, 2)).ToLower() == "m3")
                    {
                        string Actual_Vol_StringFormat = (Actual_Vol.Substring(0, Actual_Vol.Length - 2)).Trim();
                        newData.Actual_Vol = decimal.Parse(Actual_Vol_StringFormat) * 200;
                    }
                    newData.TariffCode = piece_item["tariffCode"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    newData.Item_Quntity = piece_item["itemQuantity"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    newData.Value_Ind = piece_item["valueInd"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                    newData.Sen_Name = Sen_Name;
                    newData.Sen_Address1 = Sen_Address1;
                    newData.Sen_Address2 = Sen_Address2 + " " + Sen_Address3;
                    newData.Sen_City = Sen_City;
                    newData.Sen_Country = Sen_Country;
                    newData.Sen_Postal = Sen_Postal;
                    newData.Sen_Account = Sen_AccountNo;

                    newData.Rec_Name = Rec_Name;
                    newData.Rec_Address1 = Rec_Address1;
                    newData.Rec_Address2 = Rec_Adderss2 + " " + Rec_Address3;
                    newData.Rec_City = Rec_City;
                    newData.Rec_Country = Rec_Country;
                    newData.Rec_Postal = Rec_Postal;
                    newData.Rec_Account = Rec_Account;
                    
                    newData.Sec_Name = Sec_Name;
                    newData.Sec_Origin = Sec_Origin;
                    newData.Sec_Desti = Sec_Desti;
                    newData.Sec_Mode = Sec_Mode;
                    newData.Sec_ShippingDocType = Sec_ShippingDocType;
                    newData.Sec_ShippingDocNo = Sec_ShippingDocNo;
                    TNTAwbXmlData.Add(newData);
                }
            }
           
        }

        public void SaveTntAwbDetails(AgencyDomainViewcs agency)
        {
           // List<OpsConsAWBDomainView> TntAwbSaveList = new List<OpsConsAWBDomainView>();
            foreach (var awb_item in TNTAwbXmlData)
            {
                string[] words = awb_item.Piec_No.ToLower().Split(new string[] { "of" }, StringSplitOptions.None);
                if (int.Parse(words[0].Trim()) == 1)
                {
                    WebManifestDomainView newDomain = new WebManifestDomainView();
                    newDomain.Deleted = false;
                    newDomain.CMPY = agency.CompID;
                    newDomain.AgncyCode = agency.AgncyCode;
                    newDomain.AgncyID = agency.AgncyID;
                    newDomain.ConsId = awb_item.Sec_ShippingDocNo;
                    newDomain.ShipType = "I";
                    newDomain.AgnAWBNo = awb_item.Piec_ConsignmentNo;
                    newDomain.AgnMpsNo = "";
                    newDomain.AgnTrackNo = awb_item.Piec_ConsignmentNo;
                    newDomain.ORIGINGate = awb_item.Sec_Origin;
                    newDomain.DESTINGate = awb_item.Sec_Desti;
                    newDomain.ORIGIN = awb_item.Piec_Origin;
                    newDomain.DESTIN = awb_item.Piec_Desti;
                    newDomain.ShipDate = DateTimeValidator.GetAppDateformat(awb_item.Sec_Date);
                    newDomain.ShipLocationType = "";
                    newDomain.SenAccount = awb_item.Sen_Account == "NK" ? "" : awb_item.Sen_Account;
                    newDomain.SenPhone = "";
                    newDomain.SenCountry = awb_item.Sen_Country;
                    newDomain.SenCode = "";
                    newDomain.SenCompany = awb_item.Sen_Name;
                    newDomain.SenID = "";
                    newDomain.SenName = "";
                    newDomain.SenAddr1 = awb_item.Sen_Address1;
                    newDomain.SenAddr2 = awb_item.Sen_Address2;
                    newDomain.SenCity = 0;
                    newDomain.SenCityN = awb_item.Sen_City;
                    newDomain.SenState = "";
                    newDomain.SenZip = awb_item.Sen_Postal;
                    newDomain.RecAccount = awb_item.Rec_Account == "NK" ? "" : awb_item.Rec_Account;
                    newDomain.RecPhone = "";
                    newDomain.RecCountry = awb_item.Rec_Country;
                    newDomain.RecCode = "";
                    newDomain.RecCompany = awb_item.Rec_Name;
                    newDomain.RecName = "";
                    newDomain.RecAddr1 = awb_item.Rec_Address1;
                    newDomain.RecAddr2 = awb_item.Rec_Address2;
                    newDomain.RecCity = 0;
                    newDomain.RecCityN = awb_item.Rec_City;
                    newDomain.RecState = "";
                    newDomain.RecZip = awb_item.Rec_Postal;
                    newDomain.TotPkgs = int.Parse(awb_item.NumberOf_Item);
                    if (awb_item.Piec_Product.Trim() == "15D")
                    {
                        newDomain.SvcType = "15";
                        newDomain.PackType = "D";
                        newDomain.DocNdoc = "D";
                    }
                    else if (awb_item.Piec_Product.Trim() == "15N")
                    {
                        newDomain.SvcType = "15";
                        newDomain.PackType = "N";
                        newDomain.DocNdoc = "N";
                    }

                    else if (awb_item.Piec_Product.Trim() == "09D")
                    {
                        newDomain.SvcType = "09";
                        newDomain.PackType = "D";
                        newDomain.DocNdoc = "D";
                    }
                    else if (awb_item.Piec_Product.Trim() == "09N")
                    {
                        newDomain.SvcType = "09";
                        newDomain.PackType = "N";
                        newDomain.DocNdoc = "N";
                    }
                    else if (awb_item.Piec_Product.Trim() == "10N")
                    {
                        newDomain.SvcType = "10";
                        newDomain.PackType = "N";
                        newDomain.DocNdoc = "N";
                    }
                    else if (awb_item.Piec_Product.Trim() == "10D")
                    {
                        newDomain.SvcType = "10";
                        newDomain.PackType = "D";
                        newDomain.DocNdoc = "D";
                    }
                    else if (awb_item.Piec_Product.Trim() == "12D")
                    {
                        newDomain.SvcType = "12";
                        newDomain.PackType = "D";
                        newDomain.DocNdoc = "D";
                    }
                    else if (awb_item.Piec_Product.Trim() == "12N")
                    {
                        newDomain.SvcType = "12";
                        newDomain.PackType = "N";
                        newDomain.DocNdoc = "N";
                    }
                    else
                    {
                        newDomain.SvcType = "48";
                        newDomain.PackType = "N";
                        newDomain.DocNdoc = "N";
                    }

                    //newDomain.SvcType = awb_item.Piec_Product;
                    //newDomain.PackType = "";
                    newDomain.TotWgt = awb_item.Actual_Weight;
                    newDomain.WgtU = "K";
                    newDomain.RexWgt = awb_item.Contractual_Weight;
                    newDomain.RexWgtU = "K";
                    newDomain.RexVol = awb_item.Actual_Vol;
                    newDomain.RexVolU = "K";
                    newDomain.DimVol = (awb_item.Contractual_Vol);
                    newDomain.DimVolU = "K";
                    newDomain.CarriageVal = awb_item.Value;
                    newDomain.CustomVal = awb_item.Value;
                    newDomain.CarriageValCur = awb_item.Currency;
                    newDomain.CustomValCur = awb_item.Currency;
                    newDomain.Descrip = awb_item.GoodDescription;
                    newDomain.Form ="";
                    newDomain.Base = "";
                    newDomain.SenRefNotes = "";
                    //newDomain.DocNdoc = "";
                    newDomain.HoldAtLoc = "";

                    if (awb_item.Piec_Terms == "SENDER")
                    {
                        newDomain.BillTransChg = "S";
                        newDomain.BillDtaxChg = "C";
                        newDomain.BillDtaxAcNo = awb_item.Sen_Account == "NK" ? "" : awb_item.Sen_Account;
                        newDomain.BillTransAcNo = awb_item.Sen_Account == "NK" ? "" : awb_item.Sen_Account;
                        newDomain.ORGCOUNTRY = awb_item.Sen_Country;
                        newDomain.DESCOUNTRY = awb_item.Rec_Country;
                    }
                    if (awb_item.Piec_Terms == "RECEIVER")
                    {
                        newDomain.BillTransChg = "C";
                        newDomain.BillDtaxChg = "C";
                        newDomain.BillDtaxAcNo = awb_item.Rec_Account == "NK" ? "" : awb_item.Rec_Account;
                        newDomain.BillTransAcNo = awb_item.Rec_Account == "NK" ? "" : awb_item.Rec_Account;
                        newDomain.DESCOUNTRY = awb_item.Rec_Country;
                        newDomain.ORGCOUNTRY = awb_item.Sen_Country;
                    }

                    //newDomain.AlertEmail1 = "";
                    //newDomain.AlertEmail2 = "";
                    //newDomain.AlertSms1 = "";
                    //newDomain.AlertSms2 = "";
                    newDomain.IntComDate = DateTimeValidator.GetAppDateformat(DateTime.Parse("01-01-1900"));
                    newDomain.IntComTime = new TimeSpan();
                    //newDomain.FinComDate = DateTime.Parse("01-01-1900");
                    //newDomain.FinComTime = new TimeSpan();
                    //newDomain.TrackClosedY = "";
                    //newDomain.PickupY = "";
                    //newDomain.DeliverY = "";
                    //newDomain.PickScanTypeS = "";
                    //newDomain.PodScanTypeS = "";
                    //newDomain.LastScanTypeS = "";
                    //newDomain.LastScanDate = DateTime.Parse("01-01-1900");
                    //newDomain.LatePkg = "";
                    //newDomain.RWDL = "";
                    //newDomain.BusDay14 = DateTime.Parse("01-01-1900");
                    //newDomain.ScanGap = "";
                    //newDomain.MisScan = "";
                    //newDomain.PodYN = "";
                    //newDomain.slockcode = "";
                    //newDomain.SpCode = "";
                    //newDomain.Remarks = "";
                    newDomain.USM_LOGIN = LoginInfoView.USERID.ToString();
                    newDomain.USM_DATE = DateTimeValidator.GetAppDateformat(System.DateTime.Now);
                    //newDomain.BillTransChgY = "";
                    //newDomain.InvNoTransChg = 0m;
                    //newDomain.ScansAll = "";
                    newDomain.ShipDate = DateTimeValidator.GetAppDateformat(awb_item.Collection_Date);
                    //newDomain.LocalCountyCode = SelectedAgency.CountryCode;
                    AWBList.Add(newDomain);
                }
                else
                {

                }
            }
           // SaveTntAwbDetail(TntAwbSaveList);
        }

        private void cmb_origin_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
            if (cmb_origin.SelectedItem != null)
            {
                var extTypeItem = (CfgCountryDomainView)cmb_origin.SelectedItem;
                txt_Orign.Text = extTypeItem.Country;
                //FilterAWB();
            }
            else
            {
                txt_Orign.Text = "";
            }
        }

        private void cmb_destinationloc_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
            if (cmb_destinationloc.SelectedItem != null)
            {
                var extTypeItem = (GatewayDomainView)cmb_destinationloc.SelectedItem;
                txt_destination.Text = extTypeItem.LocationID;
               // FilterAWB();
            }
            else
            {
                txt_destination.Text = "";
            }
        }

        private void combo_servicetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
        }

        private void FilterAWB()
        {
            AgencyDomainViewcs SelectedAgency = null;
            CfgCountryDomainView SelectedCountry = null;
            GatewayDomainView selectedLocation = null;
            ServiceTypeDomainView selectedServiceType = null;
            string ManifestType = "";
            string FBillTo = "";
            string DBillTo = "";
            if (checkBox6.Checked == true)
            {
                FBillTo = "A";
            }
            else
            {
                if (radio_FS.Checked == true)
                {
                    FBillTo = "S";
                }
                else if (radio_fc.Checked == true)
                {
                    FBillTo = "C";
                }
                else
                {
                    FBillTo = "O";
                }
            }

            if (checkBox7.Checked == true)
            {
                DBillTo = "A";
            }
            else
            {
                if (radio_ds.Checked == true)
                {
                    DBillTo = "S";
                }
                else if (radio_dc.Checked == true)
                {
                    DBillTo = "C";
                }
                else
                {
                    DBillTo = "O";
                }
            }
            if (checkBox5.Checked == true)
            {
                ManifestType = "A";
            }
            else
            {
                if (radio_lv.Checked)
                {
                    ManifestType = "L";
                }
                else if (radio_hv.Checked)
                {
                    ManifestType = "H";
                }
            }

            if (cmb_agency.SelectedItem != null)
            {
                SelectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            }
            if(cmb_origin.SelectedItem !=null)
            {
                SelectedCountry = (CfgCountryDomainView)cmb_origin.SelectedItem;
            }
            if(cmb_destinationloc.SelectedItem !=null)
            {
                selectedLocation = (GatewayDomainView)cmb_destinationloc.SelectedItem;
            }
            if(combo_servicetype.SelectedItem !=null)
            {
                selectedServiceType= (ServiceTypeDomainView)combo_servicetype.SelectedItem;
            }
            if (SelectedAgency != null)
            {
                AWBDisplyList = _dataProvider.GetFilterResult(SelectedAgency.CompID,SelectedAgency.AgncyCode, checkBox4.Checked==true?"All":"Filterd",date_fdate.Value.ToString("MM-dd-yyyy"), date_todate.Value.ToString("MM-dd-yyyy"),
                    SelectedCountry==null?"": SelectedCountry.Country, selectedLocation==null?"": selectedLocation.LocationID, selectedServiceType==null?"": selectedServiceType.SvcType, ManifestType, FBillTo, DBillTo, txt_cargo.Text==""?"": txt_cargo.Text, txt_consignee.Text==""?"": txt_consignee.Text).ToList();
               /// dataGridView1.AutoGenerateColumns = false;
               /// dataGridView1.DataSource = AWBDisplyList;

                //if (AWBDisplyList.Count != 0)
                //{
                //    txtTotAwb.Text = AWBDisplyList.Count().ToString();

                //}
                //else
                //{
                //    txtTotAwb.Text = "";
                //}
                FilterByClearanceTypes(AWBDisplyList);
            }
            else
            {
                MessageNotification.MessageBoxError("Please Select the Agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }

        }


        private void FilterClearance()
        {
            AgencyDomainViewcs SelectedAgency = null;
            CfgCountryDomainView SelectedCountry = null;
            GatewayDomainView selectedLocation = null;
            ServiceTypeDomainView selectedServiceType = null;
            string ManifestType = "";
            string FBillTo = "";
            string DBillTo = "";
            if (checkBox6.Checked == true)
            {
                FBillTo = "A";
            }
            else
            {
                if (radio_FS.Checked == true)
                {
                    FBillTo = "S";
                }
                else if (radio_fc.Checked == true)
                {
                    FBillTo = "C";
                }
                else
                {
                    FBillTo = "O";
                }
            }

            if (checkBox7.Checked == true)
            {
                DBillTo = "A";
            }
            else
            {
                if (radio_ds.Checked == true)
                {
                    DBillTo = "S";
                }
                else if (radio_dc.Checked == true)
                {
                    DBillTo = "C";
                }
                else
                {
                    DBillTo = "O";
                }
            }
            if (checkBox5.Checked == true)
            {
                ManifestType = "A";
            }
            else
            {
                if (radio_lv.Checked)
                {
                    ManifestType = "L";
                }
                else if (radio_hv.Checked)
                {
                    ManifestType = "H";
                }
            }

            if (cmb_agency.SelectedItem != null)
            {
                SelectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            }
            if (cmb_origin.SelectedItem != null)
            {
                SelectedCountry = (CfgCountryDomainView)cmb_origin.SelectedItem;
            }
            if (cmb_destinationloc.SelectedItem != null)
            {
                selectedLocation = (GatewayDomainView)cmb_destinationloc.SelectedItem;
            }
            if (combo_servicetype.SelectedItem != null)
            {
                selectedServiceType = (ServiceTypeDomainView)combo_servicetype.SelectedItem;
            }
            if (SelectedAgency != null)
            {
                AWBDisplyList = _dataProvider.GetFilterResult(SelectedAgency.CompID, SelectedAgency.AgncyCode, checkBox4.Checked == true ? "All" : "Filterd", date_fdate.Value.ToString("MM-dd-yyyy"), date_todate.Value.ToString("MM-dd-yyyy"),
                    SelectedCountry == null ? "" : SelectedCountry.Country, selectedLocation == null ? "" : selectedLocation.LocationID, selectedServiceType == null ? "" : selectedServiceType.SvcType, ManifestType, FBillTo, DBillTo, txt_cargo.Text == "" ? "" : txt_cargo.Text, txt_consignee.Text == "" ? "" : txt_consignee.Text).ToList();

                ///dataGridView1.DataSource = AWBDisplyList;
                ///
                FilterByClearanceTypes(AWBDisplyList);
                //if (AWBDisplyList.Count != 0)
                //{
                //    txtTotAwb.Text = AWBDisplyList.Count().ToString();

                //}
                //else
                //{
                //    txtTotAwb.Text = "";
                //}
            }
            else
            {
                MessageNotification.MessageBoxError("Please Select the Agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }

        }

        private void FilterByClearanceTypes(List<WebManifestDomainView> tempList)
        {
            List<WebManifestDomainView> tempAwbList = new List<WebManifestDomainView>();
            ShipValType = "";
            tempAwbList.Clear();
            if (_clarenceType.Where(cal => cal.IsSelect == true).FirstOrDefault() != null)
            {
                foreach (var item in _clarenceType.Where(cal => cal.IsSelect == true))
                {
                    ShipValType = ShipValType + item.ShipValType.Trim() + ",";
                    tempAwbList.AddRange(tempList.FindAll(find => find.ShipValueType.Trim() == item.ShipValType.Trim()));
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = tempAwbList;
                CalTotAWB(tempAwbList);
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = tempList;
                 CalTotAWB(tempList);
            }

        }

        private void txt_Orign_TextChanged(object sender, EventArgs e)
        {
           // cmb_destinationloc.SelectedItem= cmb_destinationloc.DataSource;
        }

        private void radio_lv_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
        }

        private void radio_hv_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
        }

        private void radio_shipall_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
        }

        private void radio_FS_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
            // FilterAWB();
        }

        private void radio_fc_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
        }

        private void radio_fo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radio_fo_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
        }

        private void radio_ds_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
        }

        private void radio_dc_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
        }

        private void radio_do_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
        }

        private void txt_cargo_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
            // FilterAWB();
        }

        private void txt_consignee_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
            // FilterAWB();
        }

        private void date_todate_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
        }

        private void date_fdate_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            //if (cmb_agency.SelectedItem != null)
            //{
            //    FilterAWB();
            //}
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                txt_Orign.Enabled = false;
                cmb_origin.Enabled = false;
                cmb_origin.SelectedIndex = -1;
                txt_Orign.Text = "";
            }
            else
            {
                txt_Orign.Enabled = true;
                cmb_origin.Enabled = true;
            }
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked==true)
            {
                cmb_destinationloc.Enabled = false;
                txt_destination.Enabled = false;
                cmb_destinationloc.SelectedIndex = -1;
                txt_destination.Text = "";
            }
            else
            {
                cmb_destinationloc.Enabled = true;
                txt_destination.Enabled = true;
            }
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                combo_servicetype.Enabled = false;
                combo_servicetype.SelectedIndex = -1;
            }
            else
            {
                combo_servicetype.Enabled = true;
            }
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilterAWB();
            SetExchangeRates();
            SetClearenceTypeCal();
            SetClearenceStatusCal();
            btn_import.Enabled = false;
            button2.Enabled = false;
            btn_printmanifest.Enabled = true;
            FormState = FormStateEnum.Print;
            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
        }

        private void RetrievData()
        {
            FilterAWB();        
            
            btn_import.Enabled = false;
            button2.Enabled = false;
            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
        }

        private void RetrievClearanceData()
        {
            FilterClearance();
            btn_import.Enabled = false;
            button2.Enabled = false;
            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox5.Checked==true)
            {
                panel5.Enabled = false;
                radio_hv.Checked = false;
                radio_lv.Checked = false;
            }
            else
            {
                panel5.Enabled = true;
                radio_hv.Checked = true;
            }
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
            if (checkBox6.Checked == true)
            {
                panel3.Enabled = false;
                radio_FS.Checked = false;
                radio_fc.Checked = false;
                radio_fo.Checked = false;
            }
            else
            {
                panel3.Enabled = true;
                radio_FS.Checked = true;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
            if (checkBox7.Checked == true)
            {
                panel4.Enabled = false;
                radio_ds.Checked = false;
                radio_dc.Checked = false;
                radio_do.Checked = false;
            }
            else
            {
                panel4.Enabled = true;
                radio_ds.Checked = true;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
            if (checkBox8.Checked == true)
            {
                txt_cargo.Enabled = false;
                txt_cargo.Text = "";
            }
            else
            {
                txt_cargo.Enabled = true;
               

            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
            if (checkBox9.Checked == true)
            {
                txt_consignee.Enabled = false;
                txt_consignee.Text = "";
            }
            else
            {
                txt_consignee.Enabled = true;
               

            }
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            txtTotAwb.Text = "";
            txtRoutePendind.Text = "";
            if (checkBox4.Checked == true)
            {
                date_fdate.Enabled = false;
                date_todate.Enabled = false;
                date_fdate.Value = System.DateTime.Now.Date;
                date_todate.Value = System.DateTime.Now.Date;
            }
            else
            {
                date_fdate.Enabled = true;
                date_todate.Enabled = true;


            }
        }


        #region ################################################
        private void btn_exgrate_Click(object sender, EventArgs e)
        {
            ExchangeRates fexhRate = new Express.ExchangeRates(ExchangeRateStatus.CLEARENCE);
            fexhRate.StartPosition = FormStartPosition.CenterParent;
            fexhRate.ShowDialog();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           // WebManifestPopUp manifestPop=new WebManifestPopUp()
            try
            {
                if(FormState != FormStateEnum.Print)
                {
                    MessageNotification.MessageBoxError("Please save data before update", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                var _values = (WebManifestDomainView)dataGridView1.SelectedRows[0].DataBoundItem;
                new WebManifestPopUp(_values , ref AWBDisplyList, (AgencyDomainViewcs)cmb_agency.SelectedItem).ShowDialog();
                dataGridView1.DataSource = null;
                // dataGridView1.DataSource = AWBDisplyList;
                FilterByClearanceTypes(AWBDisplyList);
                SetExchangeRates();
                SetClearenceStatusCal();
                SetClearenceTypeCal();               
            }
            catch (Exception )
            {
            }
        }


        #endregion

        private void webManifestBack_DoWork(object sender, DoWorkEventArgs e)
        {
            _clearenceStatus = _dataProvider.GetClearenceStatus();
            _clarenceType = _dataProvider.GetClearenceTypes();
        }

        private void webManifestBack_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            grvClearenceStatus.DataSource = _clearenceStatus;
            grvClearenceType.DataSource = _clarenceType;
        }

        private void SetExchangeRates()
        {
            _exchangeRates.Clear();

            var shipCurren = AWBDisplyList.Select(c => new {c.ShipDate ,c.CustomValCur, c.CMPY   } ).Distinct().ToList();
            foreach(var item in  shipCurren )
            {  

                //if(item.CustomValCur.Trim()!="")  // req from ksa
                //{
                    var val = _dataProvider.GetRefExgRates(item.CMPY, item.CustomValCur.Trim(), item.ShipDate.Date).FirstOrDefault();
                    if (val == null)
                    {
                        _exchangeRates.Add(new RefExgRatesDomainView { Currency = item.CustomValCur, EffectDate = item.ShipDate.Date, ExgRate = 0 });
                    }
                    else
                    {
                        _exchangeRates.Add(_dataProvider.GetRefExgRates(item.CMPY, item.CustomValCur.Trim(), item.ShipDate.Date).FirstOrDefault());
                    }
                //}             
               
            }


            var varExt = (from ext in _exchangeRates
                          select new RefExgRatesDomainView
                          {

                              Currency = ext.Currency,
                              EffectDate = ext.EffectDate,
                              ExgRate = ext.ExgRate,

                          }
                          ).GroupBy(gb => new { gb.Currency, gb.EffectDate, gb.ExgRate })
                           .Select(grp => grp.ToList())
                            .ToList();


            var tempList = (from ext in varExt
                        select new RefExgRatesDomainView
                        {

                            Currency = ext.FirstOrDefault().Currency ,
                            EffectDate = ext.FirstOrDefault().EffectDate,
                            ExgRate = ext.FirstOrDefault().ExgRate,

                        }).ToList();

            grvExgRate.DataSource = null;
            grvExgRate.DataSource = tempList;
            this.grvExgRate.CommitEdit(DataGridViewDataErrorContexts.Commit);
            SetClearenceEnable();
        }

        private void SetClearExgRates()
        {
            grvExgRate.DataSource = null;            
            this.grvExgRate.CommitEdit(DataGridViewDataErrorContexts.Commit);
            SetClearenceEnable();
        }

        private void SetClearenceTypeCal()
        {
            var _clTypes = AWBDisplyList.FindAll(ct => ct.ShipValueType.Trim() != null && ct.ShipValueType.Trim() != "");
           if(_clTypes != null )
            {
                if(_clTypes.Count >0)
                {
                   foreach(WebManiClearenceType item in  _clarenceType)
                    {
                        _clarenceType.Where(ct => ct.ShipValType.Trim() == item.ShipValType.Trim()).FirstOrDefault().ShipTypeCount = _clTypes.Where(cal=>cal.ShipValueType.Trim() == item.ShipValType.Trim() ).Count();
                        _clarenceType.Where(ct => ct.ShipValType.Trim() == item.ShipValType.Trim()).FirstOrDefault().ShipTypeValue = _clTypes.Where(cal => cal.ShipValueType.Trim() == item.ShipValType.Trim()).Sum(cal => cal.CustomsPkgVal);
                        _clarenceType.Where(ct => ct.ShipValType.Trim() == item.ShipValType.Trim()).FirstOrDefault().ShipTypeDuty = _clTypes.Where(cal => cal.ShipValueType.Trim() == item.ShipValType.Trim()).Sum(cal => cal.TotalDutyVal);

                    }
                }
            }

            //_clarenceType
            grvClearenceType.DataSource = null;
            grvClearenceType.DataSource = _clarenceType;
            this.grvClearenceType.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void SetCleareClearenceTypeCal()
        {
            if(_clarenceType==null)
            {
                return;
            }

            foreach (WebManiClearenceType item in _clarenceType)
            {
                _clarenceType.Where(ct => ct.ShipValType.Trim() == item.ShipValType.Trim()).FirstOrDefault().ShipTypeCount = 0;
                _clarenceType.Where(ct => ct.ShipValType.Trim() == item.ShipValType.Trim()).FirstOrDefault().ShipTypeValue =0;
                _clarenceType.Where(ct => ct.ShipValType.Trim() == item.ShipValType.Trim()).FirstOrDefault().ShipTypeDuty = 0;

            }

            grvClearenceType.DataSource = null;
            grvClearenceType.DataSource = _clarenceType;
            this.grvClearenceType.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void SetClearenceStatusCal()
        {
            // _clearenceStatus
            //ClearenceStatusDomainView
            var _clTypes = AWBDisplyList;
            if (_clTypes != null)
            {
                if (_clTypes.Count > 0)
                {
                    foreach (ClearenceStatusDomainView item in _clearenceStatus)
                    {
                        _clearenceStatus.Where(ct => ct.ClearStatusID == item.ClearStatusID).FirstOrDefault().ClCounts = _clTypes.Where(cal => cal.ClearStatuesCode == item.ClearStatusID).Count();
                       
                    }
                }
            }

            //_clarenceType
            grvClearenceStatus.DataSource = null;
            grvClearenceStatus.DataSource = _clearenceStatus;
            this.grvClearenceStatus.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void SetClearClearanceStatus()
        {
            foreach (ClearenceStatusDomainView item in _clearenceStatus)
            {
                _clearenceStatus.Where(ct => ct.ClearStatusID == item.ClearStatusID).FirstOrDefault().ClCounts = 0;

            }
           
            if(_clearenceStatus ==null)
            {
                grvClearenceStatus.DataSource = null;
            }
            else
            {
                grvClearenceStatus.DataSource = null;
                grvClearenceStatus.DataSource = _clearenceStatus;
            }
            //_clarenceType
           
            this.grvClearenceStatus.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private bool CheckExgRates()
        {
            bool _isValid = true;
            foreach (RefExgRatesDomainView item in _exchangeRates)
            {
                if (item.ExgRate == 0)
                {
                    _isValid = false;
                }
            }
            if(_exchangeRates.Count ==0)
            {
                _isValid = false;
            }
            
            return _isValid;
        }

        private void SetClearenceEnable()
        {
            var curr = CheckExgRates();
            if (curr)
            {
                btn_refreshclearencevalues.Enabled = true;
            }
            else
            {
                btn_refreshclearencevalues.Enabled = false;
            }
        }

        private void btn_refreshclearencevalues_Click(object sender, EventArgs e)
        {
            try
            {
                if (!MessageNotification.MessageBoxConfirm("Are sure want to process this ?", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Confirmation))
                {
                    return;
                }

                var _sAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
                if (_sAgency == null )
                {
                    MessageNotification.MessageBoxError("Please select Agenecy", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                if (dataGridView1.DataSource == null)
                {
                    MessageNotification.MessageBoxError("Please retriev data", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }
                _clearParam.CompanyID = _sAgency.CompID;
                _clearParam.AgencyID = _sAgency.AgncyCode;
                _clearParam.AgnTrackNo = GetManifestAWB();
                _clearParam.ClearenceTarif = _manifestConfig.ClearanceExgRatTarif;
                _clearParam.ClearenceValue = _manifestConfig.ClearanceValue;
                _clearParam.ClearanceCurr = _manifestConfig.ClearanceCurrency;



                if (_clearParam.AgnTrackNo =="")
                {
                    MessageNotification.MessageBoxError("Please select track numbers", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                if(_clearParam.ClearenceTarif ==0)
                {
                    MessageNotification.MessageBoxError("Clearence Exchange tarrif number can't be zero", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                if(_clearParam.ClearanceCurr =="")
                {
                    MessageNotification.MessageBoxError("Clearence currency can't be empty", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }
               
                ResponseMessage responce = new ResponseMessage();                
                responce = _dataProvider.ProcessManifestClearence(_clearParam);
                if (responce.IsSuccess)
                {
                    MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
                    //RetrievData();
                    RetrievClearanceData();
                    SetClearenceStatusCal();
                    SetClearenceTypeCal();

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

        private string GetManifestAWB()
        {
            string _trackno = "";
            foreach (WebManifestDomainView item in AWBDisplyList)
            {
                _trackno = _trackno + item.AgnTrackNo.Trim() + ",";
            }
            return _trackno;
        }

        private void grvExgRate_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
               //// var _values = grvExgRate.SelectedRows[0].DataBoundItem;
                
                var _values = (RefExgRatesDomainView)grvExgRate.SelectedRows[0].DataBoundItem;
                if(_values.Currency==null || _values.Currency.Trim() =="")
                {
                    MessageNotification.MessageBoxError("Please update manifested currency", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                new ExchangeRates( ref _values ,  _manifestConfig , ExchangeRateStatus.CLEARENCE).ShowDialog();

                _exchangeRates.Where(curr => curr.Currency.Trim() == _values.Currency.Trim() && curr.EffectDate == _values.EffectDate).FirstOrDefault().ExgRate = _values.ExgRate;
                /// _exchangeRates.Where(curr => curr.Currency.Trim() == _values.Currency.Trim() && curr.EffectDate == _values.EffectDate).FirstOrDefault().Remarks = _values.Remarks;
                var varExt = (from ext in _exchangeRates
                              select new RefExgRatesDomainView
                              {

                                  Currency = ext.Currency,
                                  EffectDate = ext.EffectDate,
                                  ExgRate = ext.ExgRate,

                              }
                        ).GroupBy(gb => new { gb.Currency, gb.EffectDate, gb.ExgRate })
                         .Select(grp => grp.ToList())
                          .ToList();


                var tempList = (from ext in varExt
                                select new RefExgRatesDomainView
                                {

                                    Currency = ext.FirstOrDefault().Currency,
                                    EffectDate = ext.FirstOrDefault().EffectDate,
                                    ExgRate = ext.FirstOrDefault().ExgRate,

                                }).ToList();

                grvExgRate.DataSource = null;
                grvExgRate.DataSource = tempList;
                grvExgRate.CommitEdit(DataGridViewDataErrorContexts.Commit);
                SetClearenceEnable();
            }
            catch (Exception ex)
            {

            }
        }

        private void btn_printmanifest_Click(object sender, EventArgs e)
        {
            if(FormState != FormStateEnum.Print)
            {
                MessageNotification.MessageBoxError("Please correct values", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }
            FormState = FormStateEnum.Print;
            var _sAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            if (_sAgency == null)
            {
                MessageNotification.MessageBoxError("Please select Agenecy", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }
            
            var AgnTrackNo = GetManifestAWB();

            if (_clearParam.AgnTrackNo == "")
            {
                MessageNotification.MessageBoxError("Please select track numbers", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }

            if(dataGridView1.DataSource ==null )
            {
                MessageNotification.MessageBoxError("Please retriev data", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                return;
            }


            var repPara = new RptManifestParaDomainView
            {
                AgencyId = _sAgency.AgncyCode,
                CompanyID = _sAgency.CompID,
                TrakNumbers = AgnTrackNo,
                FromDate = DateTimeValidator.GetAppDateformat(Convert.ToDateTime(date_fdate.Value.Date)),
                ToDate = DateTimeValidator.GetAppDateformat(Convert.ToDateTime(date_todate.Value.Date)),
                ShipValType = ShipValType,
               
            };
            var manifestRpt = _dataProvider.GetPreManifestReport(repPara);
            _operationRpt.GetPreManifestReport(manifestRpt , SetManifestSearchText());
        }

        private string  SetManifestSearchText()
        {
            string _searchText = "";
            _searchText = _searchText + ((checkBox4.Checked == true) ? "Date Range : ALL" : "From Date : "+ date_fdate.Value.Date.ToString("MMMM dd yyyy") +"    To Date : "+date_todate.Value.Date.ToString("MMMM dd yyyy"));
            _searchText = _searchText + ((checkBox2.Checked == true ) ? "" : "Station : "+ cmb_destinationloc.Text  +" , ");
            _searchText = _searchText + ((checkBox1.Checked == true) ? "" : "Origin Country : "+ cmb_origin.Text + " , ");
            _searchText = _searchText + ((checkBox5.Checked == true) ? "" : "Clearence Type : "+ GetLvHv() + " , ");
            _searchText = _searchText + ((checkBox3.Checked == true) ? "" : "Service Type : "+ combo_servicetype.Text + " , ");
            _searchText = _searchText + ((checkBox6.Checked == true) ? "" : "Fright Bill By : " + FrtBillBy() + " , ");
            _searchText = _searchText + ((checkBox7.Checked == true) ? "" : "Duty Bill By : "+ DutyBillBy() + " , ");
            _searchText = _searchText + ((checkBox8.Checked == true) ? "" : "Cargo Like : "+ txt_cargo.Text  + " , ");
            _searchText = _searchText + ((checkBox9.Checked == true) ? "" : "Consingnee Like : "+ txt_consignee.Text + " , ");

            return _searchText;

        }

        private string GetLvHv()
        {
            string _val = "";
            if(radio_hv.Checked )
            {
                _val = "HV";
            }

            if(radio_lv.Checked )
            {
                _val = "LV";
            }
            return _val;
        }

        private string FrtBillBy()
        {

            string _val = "";
            if (radio_FS.Checked)
            {
                _val = "Shipper";
            }

            if (radio_fc.Checked)
            {
                _val = "Consingnee";
            }

            if (radio_fo.Checked)
            {
                _val = "3rd Party";
            }
            return _val;
        }

        private string DutyBillBy()
        {

            string _val = "";
            if (radio_ds.Checked)
            {
                _val = "Shipper";
            }

            if (radio_dc.Checked)
            {
                _val = "Consingnee";
            }

            if (radio_do.Checked)
            {
                _val = "3rd Party";
            }
            return _val;
        }

        private void grvClearenceType_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.grvClearenceType.CommitEdit(DataGridViewDataErrorContexts.Commit);
            List<WebManifestDomainView> tempAwbList = new List<WebManifestDomainView>();
            ShipValType = "";
            tempAwbList.Clear();
            if(_clarenceType.Where(cal => cal.IsSelect == true).FirstOrDefault()!=null)
            {
                foreach (var item in _clarenceType.Where(cal => cal.IsSelect == true))
                {
                    ShipValType = ShipValType + item.ShipValType.Trim() + ",";
                    tempAwbList.AddRange(AWBDisplyList.FindAll(find => find.ShipValueType.Trim() == item.ShipValType.Trim()));
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = tempAwbList;
                CalTotAWB(tempAwbList);
            }
            else
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = AWBDisplyList;
                CalTotAWB(AWBDisplyList);
            }
           
           

        }

        private void CalTotAWB(List<WebManifestDomainView> _values)
        {
            try
            {
                if (_values != null)
                {
                    txtTotAwb.Text = Convert.ToString(_values.Count);
                    txtRoutePendind.Text = _values.Where(val => val.RouteID.Trim() == "").Count().ToString();
                }
                else
                {
                    txtTotAwb.Text = "0";
                    txtRoutePendind.Text = "0";
                }
            }
            catch
            {

            }
           
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            var extTypeItem = (AgencyDomainViewcs)cmb_agency.SelectedItem;

            CreateSoapWebManifestRequest SoapRequest = new CreateSoapWebManifestRequest();
            XmlDocument SoupXmlDocument= SoapRequest.CreateRequstFomDestinationCountry(System.DateTime.Now.Date.AddDays(-6).ToString("yyyy-MM-dd"), System.DateTime.Now.Date.ToString("yyyy-MM-dd"), extTypeItem.CountryCode);
            GetXmlResult SoupResult = new GetXmlResult();
            XmlDocument ResultXmlDoc = SoupResult.GetXmlFormSoap(SoupXmlDocument);
            SoapUiResult AWBListRequest = new SoapUiResult();
            var result= AWBListRequest.ReadXmlLits(ResultXmlDoc);
            ArrangeWebManifestSyncData(result, extTypeItem);
            //AWBDisplyList = AWBList;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = AWBList;
            if (AWBList.Count > 0)
            {
                txtTotAwb.Text = AWBList.Count().ToString();
            }
            else
            {
                txtTotAwb.Text = "";
            }
            button2.Enabled = true;
        }

        public void ArrangeWebManifestSyncData(List<XmlReadWebManifestDomain> SyncDataList, AgencyDomainViewcs agency)
        {
            foreach (var awb_item in SyncDataList)
            {
                //string[] words = awb_item.Piec_No.ToLower().Split(new string[] { "of" }, StringSplitOptions.None);
                //if (int.Parse(words[0].Trim()) == 1)
                //{
                try
                {
                    WebManifestDomainView model = new WebManifestDomainView();
                    model.CMPY = agency.CompID;
                    if (int.Parse(awb_item.Form)>1000)
                    {
                   
                        model.AgncyCode = 20102;
                        model.AgncyID = "TNT";
                    }
                    else
                    {
                        model.AgncyCode = 20101;
                        model.AgncyID = "FedEx";
                    }
                   

                    model.ConsId = "";
                    model.ShipType = "I";

                    model.AgnMpsNo = awb_item.MAWBNo;
                    if(awb_item.MAWBNo !="")
                    {
                        model.AgnAWBNo = awb_item.Child;
                    }
                    else
                    {
                        model.AgnAWBNo = awb_item.TrackNo;
                    }
                    model.AgnTrackNo = "";
                    model.ORIGIN = awb_item.Orig;
                    model.DESTIN = awb_item.Dest;
                    model.ORIGINGate = awb_item.Orig;
                    model.DESTINGate = awb_item.Dest;
                    model.ORGCOUNTRY = awb_item.OrigCntry;
                    model.DESCOUNTRY = awb_item.ExportCntry;

                    string ShipDateString = awb_item.ShipDt;
                    if (ShipDateString != "")
                    {
                        string Ship_year = ShipDateString.Substring(0, 4);
                        string Ship_month = ShipDateString.Substring(4, 2);
                        string Ship_day = ShipDateString.Substring(6, 2);
                        DateTime d = new DateTime(int.Parse(Ship_year), int.Parse(Ship_month), int.Parse(Ship_day));
                        model.IntComDate = DateTimeValidator.GetAppDateformat(d);
                        //model.ShipDate = DateTimeValidator.GetAppDateformat(DateTime.Parse(Ship_month + "-" + Ship_day + "-" + Ship_year));
                    }
                    else
                    {
                        model.ShipDate = DateTimeValidator.GetAppDateformat(DateTime.Parse("01-01-1900"));
                    }

                    model.ShipLocationType = "";
                    model.SenAccount = awb_item.SenAccount;
                    model.SenPhone = awb_item.SenPhone;
                    model.SenCountry = awb_item.SenCountry;
                    model.SenCode = awb_item.SenCode;
                    model.SenCompany = awb_item.SenCompany;
                    model.SenID = awb_item.SenID;
                    model.SenName = awb_item.SenName;
                    model.SenAddr1 = awb_item.SenAddr1;
                    model.SenAddr2 = awb_item.SenAddr2;
                    //string SenCity = awb_item.SenCity.ToString();
                    //if (SenCity != null)
                    //{
                    //    try { model.SenCity = int.Parse(SenCity); }
                    //    catch (Exception) { model.SenCity = 0; }
                    //}
                    //else { model.SenCity = 0; }
                    model.SenCityN = awb_item.SenCityN;
                    model.SenState = awb_item.SenState;
                    model.SenZip = awb_item.SenZip;
                    model.RecAccount = awb_item.RecAccount;
                    model.RecPhone = awb_item.RecPhone;
                    model.RecCompany = awb_item.RecCompany;
                    model.RecCode = awb_item.RecCode;
                    model.RecName = awb_item.RecName;
                    model.RecAddr1 = awb_item.SenAddr1;
                    model.RecAddr2 = awb_item.SenAddr2;
                    //string RecCity = awb_item.RecCity;
                    //if (RecCity != null)
                    //{
                    //    try { model.RecCity = int.Parse(RecCity); }
                    //    catch (Exception) { model.RecCity = 0; }
                    //}
                    //else { model.RecCity = 0; }
                    model.RecCityN = awb_item.RecCityN;
                    model.RecState = awb_item.RecState;
                    model.RecCountry = awb_item.RecCountry;
                    model.RecZip = awb_item.RecZip;
                    model.Base = awb_item.Base;
                    model.Form = awb_item.Form;
                    string Str_TotPkgs = awb_item.Pieces;

                    if (Str_TotPkgs != "")
                        model.TotPkgs = int.Parse(Str_TotPkgs); else model.TotPkgs = 0;
                    string str_SvcType = awb_item.Service;
                    string str_PackType = awb_item.PackTyp;
                    model.SvcType = str_SvcType == null ? "" : str_SvcType;
                    model.PackType = str_PackType == null ? "" : str_PackType.ToString();
                    string Str_TotWgt = awb_item.Weight;
                    if (Str_TotWgt != "") model.TotWgt = decimal.Parse(Str_TotWgt); else model.TotWgt = 0;
                    model.WgtU = "Kg";
                    string str_dimVolU ="";
                    string Str_DimVol = "";
                    if (Str_DimVol != "")
                    {
                        if (str_dimVolU.Trim().ToLower() == "c")
                        {
                            model.DimVol = Math.Round(((decimal.Parse(Str_DimVol)) / 5000), 2);
                            model.DimVolU = "K";
                        }
                        else if (str_dimVolU.Trim().ToLower() == "i")
                        {
                            model.DimVol = Math.Round((((decimal.Parse(Str_DimVol)) * 16.3871m) / 5000), 2);
                            model.DimVolU = "K";
                        }

                    }
                    else
                    {
                        model.DimVol = 0m;
                        model.DimVolU = "";
                    }
                    string Str_CarriageVal = awb_item.Value;
                    if (Str_CarriageVal != "") model.CarriageVal = decimal.Parse(Str_CarriageVal); else model.CarriageVal = 0;
                    model.CarriageValCur = awb_item.Currrency;
                    model.Descrip = awb_item.Desc;
                    model.SenRefNotes = "";
                    model.DocNdoc = awb_item.Dutiable;
                    model.HoldAtLoc = "";

                    model.BillTransChg = awb_item.BillTo;
                    model.BillTransAcNo = awb_item.BillToAcct;
                    model.BillDtaxChg = awb_item.BillDty;
                    model.BillDtaxAcNo = awb_item.BillToAcct;

                    ////if(awb_item.BillToAcct.Trim()== awb_item.SenAccount.Trim())
                    ////{
                    ////    model.BillTransChg = "1";
                    ////    model.BillTransAcNo = awb_item.SenAccount;
                    ////    model.BillDtaxChg = "1";
                    ////    model.BillDtaxAcNo = awb_item.SenAccount;
                    ////}
                    ////else if(awb_item.BillToAcct.Trim() == awb_item.RecAccount.Trim())
                    ////{
                    ////    model.BillTransChg = "2";
                    ////    model.BillTransAcNo = awb_item.RecAccount;
                    ////    model.BillDtaxChg = "2";
                    ////    model.BillDtaxAcNo = awb_item.RecAccount;
                    ////}
                    ////else
                    ////{
                    ////    model.BillTransChg = "3";
                    ////    model.BillTransAcNo = awb_item.BillToAcct;

                    ////    model.BillDtaxChg = "3";
                    ////    model.BillDtaxAcNo = awb_item.BillToAcct;
                    ////}

                    string IntComDateString = awb_item.ShipDt;
                    if (IntComDateString != "")
                    {
                        string IntCom_year = IntComDateString.Substring(0, 4);
                        string IntCom_month = IntComDateString.Substring(4, 2);
                        string IntCom_day = IntComDateString.Substring(6, 2);
                        DateTime d = new DateTime(int.Parse(IntCom_year), int.Parse(IntCom_month), int.Parse(IntCom_day));
                        model.IntComDate = DateTimeValidator.GetAppDateformat(d);

                    }
                    else
                    {
                        model.IntComDate = DateTimeValidator.GetAppDateformat(DateTime.Parse("01-01-1900"));
                    }
                    string IntComTimeString = awb_item.ShipDt;
                    if (IntComTimeString != "")
                    {
                        string Hour = IntComTimeString.Substring(0, 2);
                        string Minit = IntComTimeString.Substring(2, 2);
                        string Second = IntComTimeString.Substring(4, 2);
                        model.IntComTime = new TimeSpan(int.Parse(Hour), int.Parse(Minit), int.Parse(Second));
                    }
                    else
                    {
                        model.IntComTime = new TimeSpan();
                    }

                    string Str_CustomVal = awb_item.Value;
                    if (Str_CustomVal != "") model.CustomVal = decimal.Parse(Str_CustomVal); else model.CustomVal = 0m;
                    model.CustomValCur = awb_item.Currrency;
                    model.USM_LOGIN = LoginInfoView.USERID.ToString();
                    model.USM_DATE = DateTimeValidator.GetAppDateformat(System.DateTime.Now.Date);
                    WebManifestDomainView New_Awb_Item = new WebManifestDomainView();
                    New_Awb_Item = DataArangement(model);
                    AWBList.Add(New_Awb_Item);

                    ////////////newDomain.Deleted = false;
                    ////////////newDomain.CMPY = agency.CompID;
                    ////////////newDomain.AgncyCode = agency.AgncyCode;
                    ////////////newDomain.AgncyID = agency.AgncyID;
                    ////////////newDomain.ConsId = awb_item.ConsNbr;
                    ////////////newDomain.ShipType = "I";
                    ////////////newDomain.AgnAWBNo = awb_item.TrackNo;
                    ////////////newDomain.AgnMpsNo = "";
                    ////////////newDomain.AgnTrackNo = awb_item.TrackNo;
                    ////////////newDomain.ORIGINGate = awb_item.Orig;
                    ////////////newDomain.DESTINGate = awb_item.Dest;
                    ////////////newDomain.ORIGIN = awb_item.Orig;
                    ////////////newDomain.DESTIN = awb_item.Orig;
                    ////////////if (awb_item.ShipDt != null)
                    ////////////{
                    ////////////    string Ship_year = awb_item.ShipDt.Substring(0, 4);
                    ////////////    string Ship_month = awb_item.ShipDt.Substring(4, 2);
                    ////////////    string Ship_day = awb_item.ShipDt.Substring(6, 2);
                    ////////////    newDomain.ShipDate = DateTime.Parse(Ship_month + "-" + Ship_day + "-" + Ship_year);
                    ////////////}
                    ////////////else
                    ////////////{
                    ////////////    newDomain.ShipDate = DateTime.Parse("01-01-1900");
                    ////////////}
                    ////////////newDomain.ShipLocationType = "";
                    ////////////newDomain.SenAccount = awb_item.SenAccount;
                    ////////////newDomain.SenPhone = awb_item.SenPhone;
                    ////////////newDomain.SenCountry = awb_item.SenCountry;
                    ////////////newDomain.SenCode = awb_item.SenCode;
                    ////////////newDomain.SenCompany = awb_item.SenCompany;
                    ////////////newDomain.SenID = "";
                    ////////////newDomain.SenName = awb_item.SenName;
                    ////////////newDomain.SenAddr1 = awb_item.SenAddr1;
                    ////////////newDomain.SenAddr2 = awb_item.SenAddr2;
                    ////////////newDomain.SenCity = 0;
                    ////////////newDomain.SenCityN = awb_item.SenCityN;
                    ////////////newDomain.SenState = awb_item.SenState;
                    ////////////newDomain.SenZip = awb_item.SenZip;
                    ////////////newDomain.RecAccount = awb_item.RecAccount;
                    ////////////newDomain.RecPhone = awb_item.RecPhone;
                    ////////////newDomain.RecCountry = awb_item.SenCountry;
                    ////////////newDomain.RecCode = awb_item.RecCode;
                    ////////////newDomain.RecCompany = awb_item.RecCompany;
                    ////////////newDomain.RecName = awb_item.RecName;
                    ////////////newDomain.RecAddr1 = awb_item.RecAddr1;
                    ////////////newDomain.RecAddr2 = awb_item.RecAddr2;
                    ////////////newDomain.RecCity = 0;
                    ////////////newDomain.RecCityN = awb_item.RecCityN;
                    ////////////newDomain.RecState = awb_item.RecState;
                    ////////////newDomain.RecZip = awb_item.RecZip;
                    ////////////newDomain.TotPkgs = int.Parse(awb_item.Pieces==""?"0": awb_item.Pieces);
                    ////////////if (awb_item.Service.Trim() == "15D")
                    ////////////{
                    ////////////    newDomain.SvcType = "15";
                    ////////////    newDomain.PackType = "D";
                    ////////////    newDomain.DocNdoc = "D";
                    ////////////}
                    ////////////else if (awb_item.Service.Trim() == "15N")
                    ////////////{
                    ////////////    newDomain.SvcType = "15";
                    ////////////    newDomain.PackType = "N";
                    ////////////    newDomain.DocNdoc = "N";
                    ////////////}

                    ////////////else if (awb_item.Service.Trim() == "09D")
                    ////////////{
                    ////////////    newDomain.SvcType = "09";
                    ////////////    newDomain.PackType = "D";
                    ////////////    newDomain.DocNdoc = "D";
                    ////////////}
                    ////////////else if (awb_item.Service.Trim() == "09N")
                    ////////////{
                    ////////////    newDomain.SvcType = "09";
                    ////////////    newDomain.PackType = "N";
                    ////////////    newDomain.DocNdoc = "N";
                    ////////////}
                    ////////////else if (awb_item.Service.Trim() == "10N")
                    ////////////{
                    ////////////    newDomain.SvcType = "10";
                    ////////////    newDomain.PackType = "N";
                    ////////////    newDomain.DocNdoc = "N";
                    ////////////}
                    ////////////else if (awb_item.Service.Trim() == "10D")
                    ////////////{
                    ////////////    newDomain.SvcType = "10";
                    ////////////    newDomain.PackType = "D";
                    ////////////    newDomain.DocNdoc = "D";
                    ////////////}
                    ////////////else if (awb_item.Service.Trim() == "12D")
                    ////////////{
                    ////////////    newDomain.SvcType = "12";
                    ////////////    newDomain.PackType = "D";
                    ////////////    newDomain.DocNdoc = "D";
                    ////////////}
                    ////////////else if (awb_item.Service.Trim() == "12N")
                    ////////////{
                    ////////////    newDomain.SvcType = "12";
                    ////////////    newDomain.PackType = "N";
                    ////////////    newDomain.DocNdoc = "N";
                    ////////////}
                    ////////////else
                    ////////////{
                    ////////////    newDomain.SvcType = "48";
                    ////////////    newDomain.PackType = "N";
                    ////////////    newDomain.DocNdoc = "N";
                    ////////////}

                    //////////////newDomain.SvcType = awb_item.Piec_Product;
                    //////////////newDomain.PackType = "";
                    ////////////newDomain.TotWgt = decimal.Parse(awb_item.Weight==""?"0": awb_item.Weight);
                    ////////////newDomain.WgtU = "K";
                    ////////////newDomain.RexWgt = 0;
                    ////////////newDomain.RexWgtU = "K";
                    ////////////newDomain.RexVol = 0;
                    ////////////newDomain.RexVolU = "K";
                    ////////////newDomain.DimVol = 0;
                    ////////////newDomain.DimVolU = "K";
                    ////////////newDomain.CarriageVal = decimal.Parse(awb_item.Value==""?"0": awb_item.Value);
                    ////////////newDomain.CustomVal = decimal.Parse(awb_item.Value==""?"0": awb_item.Value);
                    ////////////newDomain.CarriageValCur = awb_item.Currrency;
                    ////////////newDomain.CustomValCur = awb_item.Currrency;
                    ////////////newDomain.Descrip = awb_item.Desc;
                    ////////////newDomain.SenRefNotes = "";
                    //////////////newDomain.DocNdoc = "";
                    ////////////newDomain.HoldAtLoc = "";

                    //////////////if (awb_item.Piec_Terms == "SENDER")
                    //////////////{
                    //////////////newDomain.BillTransChg = "S";
                    //////////////newDomain.BillDtaxChg = "C";

                    //////////////newDomain.BillDtaxAcNo = awb_item. ;
                    //////////////newDomain.BillTransAcNo = awb_item.Sen_Account == "NK" ? "" : awb_item.Sen_Account;
                    //////////////newDomain.ORGCOUNTRY = awb_item.Sen_Country;
                    //////////////newDomain.DESCOUNTRY = awb_item.Rec_Country;
                    //////////////}
                    //////////////if (awb_item.Piec_Terms == "RECEIVER")
                    //////////////{
                    //////////////newDomain.BillTransChg = "C";
                    //////////////newDomain.BillDtaxChg = "C";
                    //////////////newDomain.BillDtaxAcNo = awb_item.Rec_Account == "NK" ? "" : awb_item.Rec_Account;
                    //////////////newDomain.BillTransAcNo = awb_item.Rec_Account == "NK" ? "" : awb_item.Rec_Account;
                    //////////////newDomain.DESCOUNTRY = awb_item.Rec_Country;
                    //////////////newDomain.ORGCOUNTRY = awb_item.Sen_Country;
                    //////////////}

                    //////////////newDomain.AlertEmail1 = "";
                    //////////////newDomain.AlertEmail2 = "";
                    //////////////newDomain.AlertSms1 = "";
                    //////////////newDomain.AlertSms2 = "";
                    ////////////newDomain.IntComDate = DateTime.Parse("01-01-1900");
                    ////////////newDomain.IntComTime = new TimeSpan();
                    //////////////newDomain.FinComDate = DateTime.Parse("01-01-1900");
                    //////////////newDomain.FinComTime = new TimeSpan();
                    //////////////newDomain.TrackClosedY = "";
                    //////////////newDomain.PickupY = "";
                    //////////////newDomain.DeliverY = "";
                    //////////////newDomain.PickScanTypeS = "";
                    //////////////newDomain.PodScanTypeS = "";
                    //////////////newDomain.LastScanTypeS = "";
                    //////////////newDomain.LastScanDate = DateTime.Parse("01-01-1900");
                    //////////////newDomain.LatePkg = "";
                    //////////////newDomain.RWDL = "";
                    //////////////newDomain.BusDay14 = DateTime.Parse("01-01-1900");
                    //////////////newDomain.ScanGap = "";
                    //////////////newDomain.MisScan = "";
                    //////////////newDomain.PodYN = "";
                    //////////////newDomain.slockcode = "";
                    //////////////newDomain.SpCode = "";
                    //////////////newDomain.Remarks = "";
                    ////////////newDomain.USM_LOGIN = LoginInfoView.USERID.ToString();
                    ////////////newDomain.USM_DATE = System.DateTime.Now;
                    //////////////newDomain.BillTransChgY = "";
                    //////////////newDomain.InvNoTransChg = 0m;
                    //////////////newDomain.ScansAll = "";
                    //////////////////////////if (awb_item.CommitDt != null)
                    //////////////////////////{
                    //////////////////////////    string Ship_year = awb_item.CommitDt.Substring(0, 4);
                    //////////////////////////    string Ship_month = awb_item.CommitDt.Substring(4, 2);
                    //////////////////////////    string Ship_day = awb_item.CommitDt.Substring(6, 2);
                    //////////////////////////    newDomain.ShipDate = DateTime.Parse(Ship_month + "-" + Ship_day + "-" + Ship_year);
                    //////////////////////////}
                    //////////////////////////else
                    //////////////////////////{
                    //////////////////////////    newDomain.ShipDate = DateTime.Parse("01-01-1900");
                    //////////////////////////}

                    ////////////newDomain.ShipDate = newDomain.ShipDate;
                    //////////////newDomain.LocalCountyCode = SelectedAgency.CountryCode;
                    ////////////AWBList.Add(newDomain);
                    //////////////}
                    //////////////else
                    //////////////{

                    //}
                }
                catch (Exception exx)
                {

                    throw;
                }
            }
        }

        private void dataManipulate1_Load(object sender, EventArgs e)
        {

        }
    }
}
