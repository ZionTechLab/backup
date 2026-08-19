using Express.Domain.Message;
using Express.Interfaces.Operations.Manifest;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Enum;
using Express.UI.Common.Helpers;
using Express.UI.Factory.Operations;
using Express.UI.Helpers;
using Express.UI.SoapUI;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
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
    public partial class ManifestUpload : Form, IDataManipulate
    {
        private readonly IManifestUpload<ManifestUploadDomainView> dataProvider;
        private List<GatewayDomainView> Location = new List<GatewayDomainView>();
        private List<ConsMasterDomainView> ConsList = new List<ConsMasterDomainView>();
        List<OpsConsAWBDomainView> AllAwbList = new List<OpsConsAWBDomainView>();
        List<OpsConsAWBDomainView> AwbList = new List<OpsConsAWBDomainView>();
        List<OpsConsAWBDomainView> SaveAwbList = new List<OpsConsAWBDomainView>();
        List<OpsConsAWBDomainView> DuplicateAwb = new List<OpsConsAWBDomainView>();
        List<TNTAwbXmlDataDomainView> TNTAwbXmlData = new List<TNTAwbXmlDataDomainView>();

        ConsMasterDomainView SelectedConsRow = new ConsMasterDomainView();
        DuplicateAWB DuplicateWindow = null;

        public ManifestUpload()
        {
            InitializeComponent();
            if (dataProvider == null)
            {
                dataProvider = OperationsUIFacotry.GetService<IManifestUpload<ManifestUploadDomainView>>();
            }
            dataManipulate1.NewButtonClick += new EventHandler(NewMethod);
            dataManipulate1.SaveButtonClick += new EventHandler(SaveMethod);
            dataManipulate1.EditButtonClick += new EventHandler(EditMethod);
            dataManipulate1.CancelButtonClick += new EventHandler(ClearMethod);
            dataManipulate1.CloseButtonClick += new EventHandler(CloseForm);
            dataManipulate1.DelteButtonClick += new EventHandler(DeleteMethod);
            dataManipulate1.ImportButtonClick += new EventHandler(ImportMethod);

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.DISABLEENABBLE);

            dataManipulate1.CustomButtonState(ButtonTypes.PRINT, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PROCESS, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, true, ButtonCustomState.HIDEVISIBLE);

            groupBox2.Enabled = false;
            //button1.Enabled = false;
        }

        private void ManifestUpload_Load(object sender, EventArgs e)
        {
            IList<AgencyDomainViewcs> agencyList = dataProvider.GetAgencyDetail(1, 200, 1002).ToList();
            cmb_agency.DataSource = agencyList;
            cmb_agency.DisplayMember = "AgncyName";
            cmb_agency.ValueMember = "AgncyID";
        }

        private void cmb_agency_SelectedIndexChanged(object sender, EventArgs e)
        {
            var SelectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            txt_company.Text = SelectedAgency.CompName;
            if (SelectedAgency != null)
            {
                Location = dataProvider.GetGateways(SelectedAgency.CountryCode).ToList();
                RefreshOriginDestination(SelectedAgency);
               // GetConsDataFomCons();
            }
        }

        public void RefreshOriginDestination(AgencyDomainViewcs extTypeItem)
        {

            combo_Destin_Gate.DataSource = null;
            combo_Destin_Gate.DataSource = Location.ToList();
            //.Where(z => z.Country == extTypeItem.CountryCode && z.GateWay == "Y")
            combo_Destin_Gate.DisplayMember = "LocationName";
            combo_Destin_Gate.ValueMember = "LocationID";

           // combo_gateway.DataSource = null;
            combo_gateway.DataSource = Location.Where(z=>z.GateWay == "Y" && z.Country == extTypeItem.CountryCode).ToList();
            combo_gateway.DisplayMember = "LocationName";
            combo_gateway.ValueMember = "LocationID";
            combo_gateway.SelectedIndex = 0;

        }

        public void GetConsDataFomCons()
        {
            var SelectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            var Gatewayitem = (GatewayDomainView)combo_gateway.SelectedItem;
            

            try
            {
                textBox2.Text ="";
                textBox3.Text = "";
                dataGridView2.ClearSelection();
                dataGridView1.ClearSelection();
                dataGridView2.DataSource = null;
                dataGridView1.DataSource = null;
                if (SelectedAgency != null)
                {
                    ConsList = dataProvider.GetConsDetail(SelectedAgency.CompID, SelectedAgency.GroupID, SelectedAgency.AgncyCode, date_transaction.Value.ToString("MM-dd-yyyy"), Gatewayitem.LocationID).ToList();
                }
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = ConsList.OrderBy(z=>z.ConsId).ToList();
               
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var selectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
                var consRow = (ConsMasterDomainView)dataGridView2.SelectedRows[0].DataBoundItem;
                SelectedConsRow = consRow;
                //if (SelectedConsRow != null)
                //{
                //    button1.Enabled = true;
                //}
                //else
                //{
                //    button1.Enabled = false;
                //}
                txt_cons.Text = consRow.ConsId.ToString();
                txt_mawb.Text = consRow.MAWBNo.ToString();
                if (consRow.TransMode.ToString() == "A")
                {
                    radio_flight.Checked = true;
                }
                else if (consRow.TransMode.ToString() == "T")
                {
                    radio_road.Checked = true;
                }
                if (consRow.ShipType.ToString() == "I")
                {
                    radio_ib.Checked = true;
                    combo_Destin_Gate.SelectedValue = consRow.OrgHubID.Trim();
                }
                else if (consRow.ShipType.ToString() == "O")
                {
                    radio_ob.Checked = true;
                    combo_Destin_Gate.SelectedValue = consRow.DesHubID.Trim() ;
                }
                txt_flightno.Text = consRow.FlightNo.ToString();
                txt_remarks.Text = consRow.Remarks.ToString();
                date_arrival.Value = consRow.AriDate;
                date_dep.Value = consRow.DepDate;
                textBox1.Text = consRow.ExpressCons;
                AllAwbList = AwbList = dataProvider.GetOpsConsAWBDetail(selectedAgency.CompID, selectedAgency.GroupID, selectedAgency.AgncyCode, consRow.ExpressCons.Trim()).ToList();
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = AwbList;
                if (AwbList.Count > 0)
                {
                    textBox2.Text = AwbList.ToList().Count().ToString();
                    textBox3.Text = AwbList.ToList().Sum(z => z.TotPkgs).ToString();
                }
                else
                {
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }
            catch (Exception)
            {


            }
        }

        public void NewMethod(object param, EventArgs e)
        {
            cmb_agency.Enabled = false;
            date_transaction.Enabled = false;
            dataGridView2.Enabled = false;
            FormState = FormStateEnum.New;
            dataGridView1.ClearSelection();
            dataGridView1.DataSource = null;
            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            if (textBox1.Text != "")
            {
                dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, true, ButtonCustomState.DISABLEENABBLE);
            }
            textBox2.Text = "";
            textBox3.Text = "";
        }

        public void SaveMethod(object param, EventArgs e)
        {
            ResponseMessage responce = null;
            var SelectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            FormState = (FormState != FormStateEnum.Update) ? FormStateEnum.Save : FormStateEnum.Update;
            if (SaveAwbList.Count > 0)
            {
                ManifestUploadWrappingDomain model = new ManifestUploadWrappingDomain();
                model.AwbList = SaveAwbList;
                if (SelectedAgency.AgncyID == "TNT")
                {
                    if (FormState == FormStateEnum.Save)
                    {
                        responce = dataProvider.SaveTntAwbList(model);
                    }
                }
                else
                {
                    if (FormState == FormStateEnum.Save)
                    {
                        responce = dataProvider.SaveFedexAwbList(model);
                    }
                }

                if (responce.IsSuccess)
                {
                    MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
                    GetDuplicateDataAfterDataSave();
                    dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);

                    dataGridView2.Enabled = true;
                    dataGridView1.DataSource = null;
                    dataGridView2.ClearSelection();
                    GetConsDataFomCons();
                    groupBox2.Enabled = false;
                    cmb_agency.Enabled = true;

                }
                else
                {
                    MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                }
            }
            else
            {
                MessageNotification.MessageBoxError("Item Not Found", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
        }

        public void GetDuplicateDataAfterDataSave()
        {
            var SelectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            List<OpsConsAWBDomainView> duplicateList = dataProvider.GetOpsAWBDetailFromDupliacte(SelectedAgency.CompID, SelectedAgency.AgncyCode, "0").ToList();
            if (duplicateList.Count > 0)
            {
                DuplicateWindow = new DuplicateAWB(duplicateList);
                DuplicateWindow.ShowDialog();
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
            cmb_agency.Enabled = true;
            date_transaction.Enabled = true;
            dataGridView2.Enabled = true;

            FormState = FormStateEnum.Clear;
            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            textBox2.Text = "";
            textBox3.Text = "";
        }

        public void DeleteMethod(object param, EventArgs e)
        {
           
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
            throw new NotImplementedException();
        }

        public void ImportMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.Import;
            OpenFileDialog fileDialog = new OpenFileDialog();
            var SelectedAgencyItem = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            if (cmb_agency.SelectedItem != null)
            {
                AwbList.Clear();
                AllAwbList.Clear();
                SaveAwbList.Clear();
                TNTAwbXmlData.Clear();
                textBox2.Text = "0";
                textBox3.Text = "0";

                if (SelectedAgencyItem.AgncyID == "FedEx")
                {

                    fileDialog.DefaultExt = ".xlsx";
                    fileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    fileDialog.ShowDialog();
                    string FilePath = fileDialog.FileName;
                    if (FilePath != null && FilePath != "")
                    {
                       
                        LoadFedexExcel(FilePath);
                        textBox2.Text = SaveAwbList.ToList().Count().ToString();
                        textBox3.Text = SaveAwbList.ToList().Sum(z => z.TotPkgs).ToString();
                    }
                }
                else
                {

                    fileDialog.Filter = "XML files (*.xml)|*.xml";
                    fileDialog.ShowDialog();
                    string FilePath = fileDialog.FileName;
                    if (FilePath != null && FilePath != "")
                    {
                       
                        ReadXamlFile(FilePath);
                        AddingTNTXMLAwbData(SelectedConsRow);
                        if (TNTAwbXmlData.Count != 0)
                        {
                            if (AwbList.Count != 0)
                            {

                                dataGridView2.DataSource = null;
                                dataGridView2.AutoGenerateColumns = false;
                                dataGridView2.DataSource = ConsList.OrderBy(z=>z.ConsId).ToList();
                                textBox2.Text = SaveAwbList.ToList().Count().ToString();
                                textBox3.Text = SaveAwbList.ToList().Sum(z => z.TotPkgs).ToString();

                            }
                            else
                            {
                                // textBox2.Text = "";
                            }
                        }
                    }
                }
            
            }
            else
            {
                MessageNotification.MessageBoxError("Please Select the Agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
        }

        public void ProccessMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #region DTO
        private FormStateEnum _FormState;
        public FormStateEnum FormState
        {
            get { return _FormState; }
            set { _FormState = value; }
        }

        #endregion

        #region Fedex Excel Upload

        public void LoadFedexExcel(string Path)
        {
            try
            {
                var selectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
                DataTable dt = ReadExcelFile(Path);
                if (dt != null)
                {
                    List<OpsConsAWBDomainView> OldAwbData = dataProvider.GetOpsConsAWBDetail(selectedAgency.CompID, selectedAgency.GroupID, selectedAgency.AgncyCode, SelectedConsRow.ExpressCons).ToList();

                    foreach (DataRow dr in dt.Rows)
                    {
                        var AgnMpsNo = dr["FdxMasterNo"] == null ? "" : dr["FdxMasterNo"].ToString();
                        var AgnTrackNo = "";
                        var AgnAWBNo = dr["FdxTrackNo"] == null ? "" : dr["FdxTrackNo"].ToString();

                        if (AgnMpsNo == "")
                        {
                            AgnTrackNo = AgnAWBNo;
                            AgnMpsNo = "";

                        }
                        else if (AgnMpsNo == AgnAWBNo)
                        {
                            AgnMpsNo = "";
                            AgnTrackNo = AgnAWBNo;
                        }
                        else
                        {
                            string oldAwbNo = AgnAWBNo;
                            AgnAWBNo = AgnMpsNo;
                            AgnMpsNo = oldAwbNo;
                            AgnTrackNo = AgnMpsNo;
                        }


                        OpsConsAWBDomainView Old_SelectedAwb = OldAwbData.FirstOrDefault(z => z.AgnTrackNo.Trim().Equals(AgnTrackNo.Trim()));
                        if (Old_SelectedAwb == null)
                        {
                            OpsConsAWBDomainView model = new OpsConsAWBDomainView();
                            model.GroupID = SelectedConsRow.GroupID;
                            model.CMPY = SelectedConsRow.CMPY;
                            model.AgncyCode = SelectedConsRow.AgncyCode;
                            model.AgncyID = SelectedConsRow.AgncyID;
                            model.ConsId = SelectedConsRow.ConsId;
                            model.ExpressCons = SelectedConsRow.ExpressCons;
                            model.ShipType = SelectedConsRow.ShipType;
                            model.TransMode = SelectedConsRow.TransMode;
                            model.AgnMpsNo = dr["FdxMasterNo"] == null ? "" : dr["FdxMasterNo"].ToString();
                            model.AgnAWBNo = dr["FdxTrackNo"] == null ? "" : dr["FdxTrackNo"].ToString();
                            model.ExpressMpsNo = 0;
                            //model.AgnTrackNo = dr["Trac"] == null ? "" : dr["Trac"].ToString();
                            model.AgnTrackNo = "";
                            model.ORIGIN = dr["ORIGIN"] == null ? "" : dr["ORIGIN"].ToString();
                            model.DESTIN = dr["DESTIN"] == null ? "" : dr["DESTIN"].ToString();
                            model.ORIGINGate = SelectedConsRow.OrgHubID;
                            model.DESTINGate = SelectedConsRow.DesHubID;

                            model.ORGCOUNTRY = dr["ORGCOUNTRY"] == null ? "" : dr["ORGCOUNTRY"].ToString();
                            model.DESCOUNTRY = dr["DESCOUNTRY"] == null ? "" : dr["DESCOUNTRY"].ToString();

                            //model.OrignLoc = dr["origin2"] == null ? "" : dr["origin2"].ToString();
                            //model.DestinLoc = dr["destination2"] == null ? "" : dr["destination2"].ToString();

                            model.TransDate = DateTimeValidator.GetAppDateformat(date_transaction.Value);
                            string ShipDateString = dr["ShipDate"] == null ? "" : dr["ShipDate"].ToString();
                            if (ShipDateString != "")
                            {
                                string Ship_year = ShipDateString.Substring(0, 4);
                                string Ship_month = ShipDateString.Substring(4, 2);
                                string Ship_day = ShipDateString.Substring(6, 2);
                                DateTime d = new DateTime(int.Parse(Ship_year), int.Parse(Ship_month), int.Parse(Ship_day));
                                model.ShipDate = DateTimeValidator.GetAppDateformat(d);

                               
                            }
                            else
                            {
                                model.ShipDate = DateTimeValidator.GetAppDateformat(DateTime.Parse("01-01-1900"));
                            }

                            model.ShipLocationType = "";
                            model.SenAccount = dr["SenAccount"] == null ? "" : dr["SenAccount"].ToString();
                            model.SenPhone = dr["SenPhone"] == null ? "" : dr["SenPhone"].ToString();
                            model.SenCountry = dr["SenCountry"] == null ? "" : dr["SenCountry"].ToString();
                            model.SenCode = "";
                            model.SenCompany = dr["SenCompany"] == null ? "" : dr["SenCompany"].ToString();
                            model.SenID = "";
                            model.SenName = dr["SenName"] == null ? "" : dr["SenName"].ToString();
                            model.SenAddr1 = dr["SenAddr1"] == null ? "" : dr["SenAddr1"].ToString();
                            model.SenAddr2 = (dr["SenAddr2"] == null ? "" : dr["SenAddr2"].ToString());
                            string SenCity = dr["SenCity"] == null ? "" : dr["SenCity"].ToString();
                            if (SenCity != null)
                            {
                                try { model.SenCity = int.Parse(SenCity); }
                                catch (Exception) { model.SenCity = 0; }
                            }
                            else { model.SenCity = 0; }
                            model.SenCityN = SenCity;
                            model.SenState = dr["SenState"] == null ? "" : dr["SenState"].ToString();
                            model.SenZip = dr["SenZip"] == null ? "" : dr["SenZip"].ToString();
                            model.RecAccount = dr["RecAccount"] == null ? "" : dr["RecAccount"].ToString();
                            model.RecPhone = dr["RecPhone"] == null ? "" : dr["RecPhone"].ToString();
                            model.RecCompany = dr["RecCompany"] == null ? "" : dr["RecCompany"].ToString();
                            model.RecCode = "";
                            model.RecName = dr["RecName"] == null ? "" : dr["RecName"].ToString();
                            model.RecAddr1 = dr["RecAddr1"] == null ? "" : dr["RecAddr1"].ToString();
                            model.RecAddr2 = (dr["RecAddr2"] == null ? "" : dr["RecAddr2"].ToString());
                            string RecCity = dr["RecCity"] == null ? "" : dr["RecCity"].ToString();
                            if (RecCity != null)
                            {
                                try { model.RecCity = int.Parse(RecCity); }
                                catch (Exception) { model.RecCity = 0; }
                            }
                            else { model.RecCity = 0; }
                            model.RecCityN = RecCity;
                            model.RecState = dr["RecState"] == null ? "" : dr["RecState"].ToString();
                            model.RecCountry = dr["RecCountry"] == null ? "" : dr["RecCountry"].ToString();
                            model.RecZip = dr["RecZip"] == null ? "" : dr["RecZip"].ToString();
                            string Str_TotPkgs = dr["TotPkgs"].ToString();
                            if (Str_TotPkgs != "") model.TotPkgs = int.Parse(Str_TotPkgs); else model.TotPkgs = 0;
                            string str_SvcType = dr["SvcType"].ToString();
                            string str_PackType = dr["PackType"].ToString();

                            model.SvcType = str_SvcType == null ? "" : str_SvcType;

                            if (SelectedConsRow.HighValueY == true)
                            {
                                model.MHEPackType = str_PackType == null ? "" : str_PackType.ToString();
                                model.PackType = "99";
                            }
                            else
                            {
                                model.PackType = str_PackType == null ? "" : str_PackType.ToString();
                                model.MHEPackType = "";
                            }


                            string Str_TotWgt = dr["TotWgt"].ToString();
                            if (Str_TotWgt != "") model.TotWgt = decimal.Parse(Str_TotWgt); else model.TotWgt = 0;
                            model.WgtU = dr["WgtU"] == null ? "" : dr["WgtU"].ToString();
                            string str_dimVolU = dr["DimVolU"] == null ? "" : dr["DimVolU"].ToString();
                            string Str_DimVol = dr["DimVol"].ToString();
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

                            string Str_CarriageVal = dr["CarriageVal"].ToString();
                            if (Str_CarriageVal != "") model.CarriageVal = decimal.Parse(Str_CarriageVal); else model.CarriageVal = 0;
                            model.CarriageValCur = dr["CarriageValCur"] == null ? "" : dr["CarriageValCur"].ToString();
                            model.Descrip = dr["Descrip"] == null ? "" : dr["Descrip"].ToString();
                            model.SenRefNotes = dr["SenRefNotes"] == null ? "" : dr["SenRefNotes"].ToString();
                            model.DepNotes = "";
                            model.DocNdoc = dr["DocNdoc"] == null ? "" : dr["DocNdoc"].ToString();
                            model.HoldAtLoc = "";
                            model.BillTransChg = dr["BillTransChg"] == null ? "" : dr["BillTransChg"].ToString();
                            model.BillTransAcNo = dr["BillTransAcNo"] == null ? "" : dr["BillTransAcNo"].ToString();
                            model.BillDtaxChg = dr["BillDtaxChg"] == null ? "" : dr["BillDtaxChg"].ToString();
                            model.BillDtaxAcNo = "";
                            model.AlertEmail1 = "";
                            model.AlertEmail2 = "";
                            model.AlertSms1 = "";
                            model.AlertSms2 = "";
                            model.SenRefNotes = dr["SenRefNotes"] == null ? "" : dr["SenRefNotes"].ToString();
                            string IntComDateString = dr["IntComDate"] == null ? "" : dr["IntComDate"].ToString();
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
                            string IntComTimeString = dr["IntComTime"] == null ? "" : dr["IntComTime"].ToString();
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
                            model.FinComDate = model.IntComDate;
                            model.FinComTime = model.IntComTime;
                            string Str_CustomVal = dr["CustomVal"].ToString();
                            if (Str_CustomVal != "")
                                model.CustomVal = decimal.Parse(Str_CustomVal);
                            else model.CustomVal = 0m;
                            model.CustomValCur = dr["CustomValCur"] == null ? "" : dr["CustomValCur"].ToString();
                            model.TrackClosedY = "";
                            model.PickupY = "";
                            model.DeliverY = "";
                            model.PodScanTypeS = "";
                            model.PodScanTypeS = "";
                            model.LastScanTypeS = "";
                            model.LatePkg = "";
                            model.RWDL = "";
                            model.BusDay14 = DateTimeValidator.GetAppDateformat(DateTime.Parse("01-01-1900"));
                            model.ScanGap = "";
                            model.MisScan = "";
                            model.PodYN = "";
                            model.slockcode = "";
                            model.SpCode = "";
                            model.Remarks = "";
                            model.USM_LOGIN = LoginInfoView.USERID.ToString();
                            model.USM_DATE = DateTimeValidator.GetAppDateformat(System.DateTime.Now.Date);
                            model.BillTransChgY = "";
                            model.InvNoTransChg = 0m;
                            model.LastScanDate = DateTimeValidator.GetAppDateformat(DateTime.Parse("01-01-1900"));
                            model.ScansAll = "";
                            model.RexWgt = 0m;
                            model.RexVol = 0m;
                            model.RexVolU = "K";
                            model.RexWgtU = "K";
                            model.AgncyID = selectedAgency.AgncyID;
                            model.LocalCountyCode = selectedAgency.CountryCode;
                            OpsConsAWBDomainView New_Awb_Item = new OpsConsAWBDomainView();
                            New_Awb_Item = DataArangement(model);
                            AwbList.Add(New_Awb_Item);
                            SaveAwbList.Add(New_Awb_Item);
                        }
                        else
                        {
                            DuplicateAwb.Add(Old_SelectedAwb);
                        }


                    }

                    if (DuplicateAwb.Count > 0)
                    {

                        DuplicateWindow = new DuplicateAWB(DuplicateAwb);
                        DuplicateWindow.ShowDialog();
                    }

                    if (SaveAwbList.Count > 0)
                    {
                        if (SelectedConsRow.ShipType == "I")
                        {
                            if ((SaveAwbList.Where(z => z.DESCOUNTRY == selectedAgency.CountryCode)).Count()>=1)
                            {
                                dataGridView1.DataSource = null;
                                dataGridView1.AutoGenerateColumns = false;
                                dataGridView1.DataSource = AwbList;
                            }
                            else
                            {
                                MessageNotification.MessageBoxOK("Invalid shipment types or some gateways has not been defined in master files, Please Check First Recode in Manifest File", "Manifest Upload TNT");
                                SaveAwbList.Clear();
                                AwbList.Clear();
                                dataGridView1.DataSource = null;

                            }
                        }
                        else if (SelectedConsRow.ShipType == "O")
                        {
                            if ((SaveAwbList.Where(z => z.ORGCOUNTRY == selectedAgency.CountryCode)).Count()>=1)
                            {
                                dataGridView1.DataSource = null;
                                dataGridView1.AutoGenerateColumns = false;
                                dataGridView1.DataSource = AwbList;
                            }
                            else
                            {
                                MessageNotification.MessageBoxOK("Invalid shipment types or some gateways has not been defined in master files, Please Check First Recode in Manifest File", "Manifest Upload TNT");
                                SaveAwbList.Clear();
                                AwbList.Clear();
                                dataGridView1.DataSource = null;

                            }
                        }

                    }
                }
                else
                {

                }
            }
            catch (OperationCanceledException ex)
            {
                MessageNotification.MessageBoxOK(ex.InnerException.ToString(), "Express");
            }
            if (AwbList.Count > 0)
            {
                dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.DISABLEENABBLE);

            }
           
            //dataGridView1.DataSource = null;
            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.DataSource = AwbList;
        }

        public OpsConsAWBDomainView DataArangement(OpsConsAWBDomainView Awb)
        {
            var selectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
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
                Awb.TotWgt = Math.Round((Awb.TotWgt.Value / 2.20462m), 2);
            }


            if (Awb.ORGCOUNTRY != selectedAgency.CountryCode && Awb.DESCOUNTRY != selectedAgency.CountryCode)
            {
                Awb.MissRoute = "Y";
            }
            else
            {
                Awb.MissRoute = "";
            }

            Awb.LastScanDate = DateTimeValidator.GetAppDateformat(DateTime.Parse("01-01-1900"));

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

            if (SelectedConsRow.HighValueY == true)
            {
                Awb.MHEPackType = int.Parse(Awb.MHEPackType == null || Awb.MHEPackType == "" ? "0" : Awb.MHEPackType).ToString("00");
            }
            else
            {
                Awb.MHEPackType = Awb.MHEPackType;
            }

            if (Awb.ShipType == "T")
            {
                Awb.BillTransChg = "O";
            }
            else
            {
                if (Awb.BillTransChg == "1")
                {
                    Awb.BillTransChg = "S";
                }
                else if (Awb.BillTransChg == "2")
                {
                    Awb.BillTransChg = "C";
                }
                else
                {
                    Awb.BillTransChg = "O";
                }
            }

            if (Awb.BillDtaxChg == "1")
            {
                Awb.BillDtaxChg = "S";
            }
            else if (Awb.BillDtaxChg == "2")
            {
                Awb.BillDtaxChg = "C";
            }
            else
            {
                Awb.BillDtaxChg = "O";
            }

            return Awb;
        }



        #endregion

        #region Excel Reading Methord
        private DataTable ReadExcelFile(string path)
        {
            try
            {
                using (ExcelPackage excelPkg = new ExcelPackage())
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    excelPkg.Load(stream);
                    ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets[1];
                    return WorksheetToDataTable(oSheet);
                }
            }
            catch (IOException ex)
            {
                MessageNotification.MessageBoxOK("File is already open cannot access", "Express");
                return null;
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

        #endregion

        #region Xml Upload Methord
        public void ReadXamlFile(string path)
        {
            try
            {
                string Sec_Name = "";
                DateTime Sec_Date = DateTimeValidator.GetAppDateformat(DateTime.Parse("01-01-1900"));
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
                        Sec_Date = date_transaction.Value;
                        string Str_Sec_Date = SectorDetail_item["date"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        if (Str_Sec_Date != "")
                        {
                            //string Ship_year = Str_Sec_Date.Substring(0, 2);
                            //string Ship_month = Str_Sec_Date.Substring(4, 2);
                            //string Ship_day = Str_Sec_Date.Substring(6, 2);
                            //Sec_Date = DateTime.Parse(Ship_month + "-" + Ship_day + "+" + Ship_year);
                            Sec_Date = DateTimeValidator.GetAppDateformat(DateTime.Parse(Str_Sec_Date));
                        }
                        else
                        {
                            Sec_Date = DateTimeValidator.GetAppDateformat(DateTime.Parse("01-01-1900"));
                        }
                        Sec_Origin = SectorDetail_item["origin"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        Sec_Desti = SectorDetail_item["destination"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        Sec_Mode = SectorDetail_item["mode"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        Sec_ShippingDocType = SectorDetail_item["shippingDocType"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        Sec_ShippingDocNo = SectorDetail_item["shippingDocNumber"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "").Replace("-", "");

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

                        //if (Sec_Mode.Trim() != "A")
                        //{
                        //    newData.Piec_ConsignmentNo = Sec_Name;

                        //}
                        //else
                        //{
                        newData.Piec_ConsignmentNo = piece_item["consignmentNumber"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");
                        //}
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
                        //newData.Collection_Date = DateTimeValidator.GetAppDateformat((DateTime.Parse(piece_item["collectionDate"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", ""))));
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

                        newData.customerReference = piece_item["customerReference"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", "");

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
                        newData.Sec_Date = Sec_Date;
                        newData.Sec_Origin = Sec_Origin;
                        newData.Sec_Desti = Sec_Desti;
                        newData.Sec_Mode = Sec_Mode;
                        newData.Sec_ShippingDocType = Sec_ShippingDocType;
                        if (Sec_Mode.Trim() != "A")
                        {
                            newData.Sec_ShippingDocNo = Sec_Name;
                        }
                        else
                        {
                            newData.Sec_ShippingDocNo = Sec_ShippingDocNo;
                        }
                        TNTAwbXmlData.Add(newData);
                    }
                }
            }
            catch (Exception)
            {

                MessageNotification.MessageBoxOK("Invalid XML File", "Manifest Upload TNT");
            }

        }

      
        public void AddingTNTXMLAwbData(ConsMasterDomainView SelectedItemConsItem)
        {
            var selectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            List<OpsConsAWBDomainView> OldAwbData = dataProvider.GetOpsConsAWBDetail(selectedAgency.CompID, selectedAgency.GroupID, selectedAgency.AgncyCode, SelectedItemConsItem.ExpressCons).ToList();
            List<string> AwbNoList = TNTAwbXmlData.AsEnumerable().Select(r => r.Piec_ConsignmentNo.Trim()).Distinct().ToList();
            if (AwbNoList.Count != 0)
            {
                foreach (var awb_ConsignmnetNo in AwbNoList)
                {
                    OpsConsAWBDomainView Old_SelectedAwb = OldAwbData.FirstOrDefault(z => z.AgnTrackNo.Trim() == awb_ConsignmnetNo.Trim());
                    if (Old_SelectedAwb == null)
                    {
                        TNTAwbXmlDataDomainView awb_item = TNTAwbXmlData.FirstOrDefault(z => z.Piec_ConsignmentNo.Trim() == awb_ConsignmnetNo.Trim());
                        OpsConsAWBDomainView newDomain = new OpsConsAWBDomainView();
                        newDomain.Deleted = false;
                        newDomain.GroupID = selectedAgency.GroupID;
                        newDomain.CMPY = selectedAgency.CompID;
                        newDomain.AgncyCode = selectedAgency.AgncyCode;
                        newDomain.AgncyID = selectedAgency.AgncyID;
                        newDomain.ExpressCons = SelectedItemConsItem.ExpressCons;
                        newDomain.ConsId = SelectedItemConsItem.ConsId;
                        newDomain.TransDate = SelectedItemConsItem.TransDate;
                        newDomain.ShipType = SelectedItemConsItem.ShipType;
                        newDomain.ExpressMpsNo = 0;
                        newDomain.AgnMpsNo = "";

                        newDomain.ORIGINGate = SelectedItemConsItem.OrgHubID;
                        newDomain.DESTINGate = SelectedItemConsItem.DesHubID;
                        newDomain.TransMode = SelectedItemConsItem.TransMode;

                        if (radio_ib.Checked == true)
                        {
                            newDomain.ShipType = "I";
                        }
                        else if (radio_ob.Checked == true)
                        {
                            newDomain.ShipType = "O";
                        }
                        //else if (radio_3p.Checked == true)
                        //{
                        //    newDomain.ShipType = "T";
                        //}
                        newDomain.ExpressMpsNo = 0;
                        newDomain.AgnAWBNo = awb_item.Piec_ConsignmentNo;
                        newDomain.AgnMpsNo = "";
                        newDomain.AgnTrackNo = awb_item.Piec_ConsignmentNo;

                        newDomain.ORIGIN = awb_item.Piec_Origin;
                        newDomain.DESTIN = awb_item.Piec_Desti;

                        //newDomain.ORIGIN = awb_item.Piec_Origin;
                        //newDomain.DestinLoc = awb_item.Piec_Desti;

                        //newDomain.ORIGINGate = awb_item.Sec_Origin;
                        //newDomain.DESTINGate = awb_item.Sec_Desti;

                        newDomain.ShipDate = awb_item.Sec_Date;
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
                        newDomain.CarriageValCur = awb_item.Currency;
                        newDomain.CustomVal = awb_item.Value;
                        newDomain.CustomValCur = awb_item.Currency;
                        newDomain.Descrip = awb_item.GoodDescription;
                        //newDomain.CustomerReference = awb_item.customerReference;
                        newDomain.SenRefNotes = awb_item.customerReference;
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


                        if (newDomain.ORGCOUNTRY != selectedAgency.CountryCode && newDomain.DESCOUNTRY != selectedAgency.CountryCode)
                        {
                            newDomain.MissRoute = "Y";
                        }
                        else
                        {
                            newDomain.MissRoute = "";
                        }
                        //newDomain.AlertEmail1 = "";
                        //newDomain.AlertEmail2 = "";
                        //newDomain.AlertSms1 = "";
                        //newDomain.AlertSms2 = "";
                        newDomain.IntComDate = DateTimeValidator.GetAppDateformat(DateTime.Parse("01-01-1900"));
                        newDomain.IntComTime = new TimeSpan();
                        newDomain.FinComDate = DateTimeValidator.GetAppDateformat(DateTime.Parse("01-01-1900"));
                        newDomain.FinComTime = new TimeSpan();
                        //newDomain.TrackClosedY = "";
                        //newDomain.PickupY = "";
                        //newDomain.DeliverY = "";
                        //newDomain.PickScanTypeS = "";
                        //newDomain.PodScanTypeS = "";
                        //newDomain.LastScanTypeS = "";
                        //newDomain.LastScanDate = DateTime.Parse("01-01-1900");
                        newDomain.LatePkg = "";
                        newDomain.RWDL = "";
                        newDomain.BusDay14 = DateTimeValidator.GetAppDateformat(DateTime.Parse("01-01-1900"));
                        //newDomain.ScanGap = "";
                        //newDomain.MisScan = "";
                        //newDomain.PodYN = "";
                        //newDomain.slockcode = "";
                        //newDomain.SpCode = "";
                        newDomain.Remarks = "";
                        newDomain.USM_LOGIN = LoginInfoView.USERID.ToString();
                        newDomain.USM_DATE = DateTimeValidator.GetAppDateformat(System.DateTime.Now);
                        newDomain.BillTransChgY = "";
                        newDomain.InvNoTransChg = 0m;
                        newDomain.ScansAll = "";
                        newDomain.ShipDate = awb_item.Collection_Date;
                        newDomain.LocalCountyCode = selectedAgency.CountryCode;
                        SaveAwbList.Add(newDomain);
                        AwbList.Add(newDomain);
                    }
                    else
                    {
                        DuplicateAwb.Add(Old_SelectedAwb);
                    }
                }
                if (DuplicateAwb.Count > 0)
                {
                    DuplicateWindow = new DuplicateAWB(DuplicateAwb);
                    DuplicateWindow.ShowDialog();

                }
            }
            else
            {
                MessageNotification.MessageBoxOK("No AWB found for Console No " + SelectedConsRow.ConsId, "Manifest Upload TNT");
            }

            if (SaveAwbList.Count > 0)
            {
                dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.DISABLEENABBLE);
            }
            if(SaveAwbList.Count>0)
            {
                if(SelectedConsRow.ShipType=="I")
                {
                    //var awbnotoman = SaveAwbList.Where(z => z.DESCOUNTRY != selectedAgency.CountryCode).ToList();
                    //int countAwb = (SaveAwbList.Where(z => z.DESCOUNTRY == selectedAgency.CountryCode)).Count();

                   if ((SaveAwbList.Where(z => z.DESCOUNTRY == selectedAgency.CountryCode)).Count()>=1)
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.AutoGenerateColumns = false;
                        dataGridView1.DataSource = AwbList;
                    }
                   else
                    {
                        MessageNotification.MessageBoxOK("Invalid shipment types or some gateways has not been defined in master files, Please Check First Recode in Manifest File", "Manifest Upload TNT");
                        SaveAwbList.Clear();
                        AwbList.Clear();
                        dataGridView1.DataSource = null;
                       
                    }
                }
                else if(SelectedConsRow.ShipType == "O")
                {
                    if ((SaveAwbList.Where(z => z.ORGCOUNTRY == selectedAgency.CountryCode)).Count()>=1)
                    {
                        dataGridView1.DataSource = null;
                        dataGridView1.AutoGenerateColumns = false;
                        dataGridView1.DataSource = AwbList;
                    }
                    else
                    {
                        MessageNotification.MessageBoxOK("Invalid shipment types or some gateways has not been defined in master files, Please Check First Recode in Manifest File", "Manifest Upload TNT");
                        SaveAwbList.Clear();
                        AwbList.Clear();
                        dataGridView1.DataSource = null;
                        
                    }
                }
               
            }
           
        }



        #endregion

        private void date_transaction_ValueChanged(object sender, EventArgs e)
        {
            GetConsDataFomCons();
        }

        private void combo_gateway_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetConsDataFomCons();
        }

        private void dataGridView2_AllowUserToDeleteRowsChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_AllowUserToResizeRowsChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button1.Enabled = false;
            var extTypeItem = (AgencyDomainViewcs)cmb_agency.SelectedItem;

            CreateSoapWebManifestRequest SoapRequest = new CreateSoapWebManifestRequest();
            XmlDocument SoupXmlDocument = SoapRequest.CreateRequstFomDestinationCountry(System.DateTime.Now.Date.AddDays(-6).ToString("yyyy-MM-dd"), System.DateTime.Now.Date.ToString("yyyy-MM-dd"), extTypeItem.CountryCode);
            GetXmlResult SoupResult = new GetXmlResult();
            XmlDocument ResultXmlDoc = SoupResult.GetXmlFormSoap(SoupXmlDocument);
            SoapUiResult AWBListRequest = new SoapUiResult();
            var result = AWBListRequest.ReadXmlLits(ResultXmlDoc);
            ArrangeWebManifestSyncData(result, extTypeItem);
            //AWBDisplyList = AWBList;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = SaveAwbList;
            if (SaveAwbList.Count > 0)
            {
                textBox2.Text = SaveAwbList.Count().ToString();
            }
            else
            {
                textBox2.Text = "";
            }
            //button1.Enabled = true;
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
                    OpsConsAWBDomainView model = new OpsConsAWBDomainView();
                    model.CMPY = agency.CompID;
                    model.AgncyCode = agency.AgncyCode;
                    model.AgncyID = agency.AgncyID;
                    model.ConsId = "";
                    model.ShipType = "I";

                    model.AgnMpsNo = awb_item.MAWBNo;
                    if (awb_item.MAWBNo != "")
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
                        model.ShipDate = DateTimeValidator.GetAppDateformat(d);
                        //////string CallectDate= (Ship_month + "-" + Ship_day + "-" + Ship_year);
                        //////DateTime calect_Date = DateTime.Parse(CallectDate, new CultureInfo("de-DE", true));
                        ////////newData.Collection_Date = DateTimeValidator.GetAppDisplayFormat(calect_Date);
                        //////model.ShipDate = DateTimeValidator.GetAppDateformat(calect_Date);
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
                    string Str_TotPkgs = awb_item.Pieces;
                    if (Str_TotPkgs != "")
                        model.TotPkgs = int.Parse(Str_TotPkgs);
                    else model.TotPkgs = 0;
                    string str_SvcType = awb_item.Service;
                    string str_PackType = awb_item.PackTyp;
                    model.SvcType = str_SvcType == null ? "" : str_SvcType;
                    model.PackType = str_PackType == null ? "" : str_PackType.ToString();
                    string Str_TotWgt = awb_item.Weight;
                    if (Str_TotWgt != "") model.TotWgt = decimal.Parse(Str_TotWgt); else model.TotWgt = 0;
                    model.WgtU = "Kg";
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

                    string IntComDateString = awb_item.ShipDt;
                    if (IntComDateString != "")
                    {
                        string IntCom_year = IntComDateString.Substring(0, 4);
                        string IntCom_month = IntComDateString.Substring(4, 2);
                        string IntCom_day = IntComDateString.Substring(6, 2);

                        DateTime d = new DateTime(int.Parse(IntCom_year), int.Parse(IntCom_month), int.Parse(IntCom_day));
                        model.IntComDate = DateTimeValidator.GetAppDateformat(d);

                        //model.IntComDate = DateTimeValidator.GetAppDateformat(DateTime.Parse(IntCom_month + "-" + IntCom_day + "-" + IntCom_year));
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
                    OpsConsAWBDomainView New_Awb_Item = new OpsConsAWBDomainView();
                    New_Awb_Item = DataArangement(model);
                    AwbList.Add(New_Awb_Item);
                    SaveAwbList.Add(New_Awb_Item);

                  
                }
                catch (Exception exx)
                {

                    throw;
                }
            }
        }
    }
}
