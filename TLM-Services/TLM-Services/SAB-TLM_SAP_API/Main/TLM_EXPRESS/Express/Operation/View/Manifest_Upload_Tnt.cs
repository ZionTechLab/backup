using Express.Domain.Message;
using Express.Interfaces.Operations.Manifest;
using Express.UI.Common.Enum;
using Express.UI.Common.Helpers;
using Express.UI.Factory.Operations;
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
using System.Xml;

namespace Express.UI.Operation.View
{
    public partial class Manifest_Upload_Tnt : Form, IDataManipulate
    {
        private readonly IManifestUploadTNT<ManifestUploadTNTDomainView> dataProvider;
        private readonly ConsMasterDomainView _model;
        private List<GatewayDomainView> Location = new List<GatewayDomainView>();
        List<ConsMasterDomainView> SaveConsList = new List<ConsMasterDomainView>();
        List<TNTAwbXmlDataDomainView> TNTAwbXmlData = new List<TNTAwbXmlDataDomainView>();
        private List<ConsMasterDomainView> AllConsList = new List<ConsMasterDomainView>();
        private List<ConsMasterDomainView> ConsList = new List<ConsMasterDomainView>();

        List<OpsConsAWBDomainView> AllAwbList = new List<OpsConsAWBDomainView>();
        List<OpsConsAWBDomainView> AwbList = new List<OpsConsAWBDomainView>();
        List<OpsConsAWBDomainView> SaveAwbList = new List<OpsConsAWBDomainView>();
        List<OpsConsAWBDomainView> DuplicateAwb = new List<OpsConsAWBDomainView>();
        DuplicateAWB DuplicateWindow = null;
        AgencyDomainViewcs selectedAgencyItem = null;
        ConsMasterDomainView SelectedCons = null;

        public Manifest_Upload_Tnt()
        {
            InitializeComponent();

            if (dataProvider == null)
            {
                dataProvider = OperationsUIFacotry.GetService<IManifestUploadTNT<ManifestUploadTNTDomainView>>();
            }
            _model = new ConsMasterDomainView();
            dataManipulate1.NewButtonClick += new EventHandler(NewMethod);
            dataManipulate1.SaveButtonClick += new EventHandler(SaveMethod);
            dataManipulate1.EditButtonClick += new EventHandler(EditMethod);
            dataManipulate1.CancelButtonClick += new EventHandler(ClearMethod);
            dataManipulate1.CloseButtonClick += new EventHandler(CloseForm);
            dataManipulate1.DelteButtonClick += new EventHandler(DeleteMethod);
            dataManipulate1.ImportButtonClick += new EventHandler(ImportMethod);

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.DISABLEENABBLE);

            dataManipulate1.CustomButtonState(ButtonTypes.PRINT, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PROCESS, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, true, ButtonCustomState.HIDEVISIBLE);

            date_transaction.Value = System.DateTime.Now.Date;
            date_arrival.Value = System.DateTime.Now.Date;
            date_dep.Value = System.DateTime.Now.Date;
            radio_ib.Checked = true;
            radio_mawb.Checked = true;
            cmb_agency.Enabled = false;
            groupBox2.Enabled = false;
        }

        private void Manifest_Upload_Tnt_Load(object sender, EventArgs e)
        {
            IList<AgencyDomainViewcs> agencyList = dataProvider.GetAgencyDetail(1, 200, 1002).Where(z => z.AgncyID == "TNT").ToList();
            cmb_agency.DataSource = agencyList;
            cmb_agency.DisplayMember = "AgncyName";
            cmb_agency.ValueMember = "AgncyID";
        }

        public void NewMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.New;
            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, true, ButtonCustomState.DISABLEENABBLE);
            dataGridView2.ClearSelection();
            SelectedCons = null;
            txt_cons.Text = "";
            txt_mawb.Text = "";
            txt_transmode.Text = "";
            combo_origin.SelectedIndex = -1;
            combo_destination.SelectedIndex = -1;
            txt_remarks.Text = "";
            txt_origin.Text = "";
            txt_destination.Text = "";
            date_arrival.Value = System.DateTime.Now.Date;
            date_dep.Value = System.DateTime.Now.Date;
            txt_flightno.Text = "";
            AllAwbList.Clear();
            AwbList.Clear();
            dataGridView1.DataSource = null;
        }

        public void SaveMethod(object param, EventArgs e)
        {
            {
                FormState = (FormState != FormStateEnum.Update) ? FormStateEnum.Save : FormStateEnum.Update;
                ManifestUploadWrappingDomain model = new ManifestUploadWrappingDomain();
                model.ConsList = SaveConsList;
                ResponseMessage objMsg = null;

                if (FormState == FormStateEnum.Update)
                {
                    ConsMasterDomainView _model = SelectedCons;
                    _model.FlightNo = txt_flightno.Text;
                    _model.Remarks = txt_remarks.Text;
                    _model.MAWBNo = txt_mawb.Text;
                    _model.AriDate = date_arrival.Value;
                    _model.DepDate = date_dep.Value;

                    objMsg = dataProvider.EditDetails(_model);
                    if (objMsg.IsSuccess)
                    {
                        MessageNotification.MessageBoxOK(objMsg.StrMessage, "TNT Manifest Upload");
                        TNTAwbXmlData.Clear();
                        SaveAwbList.Clear();
                        DuplicateAwb.Clear();
                        GetConsDataFomCons();
                        dataGridView2.Enabled = true;
                        dataGridView2.ClearSelection();
                        dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                        dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                        dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                        dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                        dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
                    }
                    else
                    {
                        MessageNotification.MessageBoxOK(objMsg.StrMessage, "TNT Manifest Upload");
                    }
                }
                if (SaveConsList.Count > 0)
                {
                    if (FormState == FormStateEnum.Save)
                    {
                        objMsg = dataProvider.SaveConsList(model);
                        SaveConsList.Clear();


                        if (objMsg.IsSuccess)
                        {

                            if (objMsg.IsSuccess == true)
                            {
                                ManifestUploadWrappingDomain model_Awb = new ManifestUploadWrappingDomain();
                                model_Awb.AwbList = SaveAwbList;


                                if (FormState == FormStateEnum.Save)
                                {
                                    objMsg = dataProvider.SaveAwbList(model_Awb);

                                }
                                if (objMsg.IsSuccess)
                                {
                                    MessageNotification.MessageBoxOK(objMsg.StrMessage, "TNT Manifest Upload");
                                    TNTAwbXmlData.Clear();
                                    SaveAwbList.Clear();
                                    DuplicateAwb.Clear();
                                    GetConsDataFomCons();
                                    dataGridView2.Enabled = true;
                                    dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                                    dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                                    dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                                    dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                                    dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
                                    dataGridView2.ClearSelection();
                                }
                                else
                                {
                                    MessageNotification.MessageBoxOK(objMsg.StrMessage, "TNT Manifest Upload");
                                    TNTAwbXmlData.Clear();
                                }
                            }

                        }
                        else
                        {
                            MessageNotification.MessageBoxOK(objMsg.StrMessage, "TNT Manifest Upload");
                        }
                    }
                }
                else
                {


                }
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
            dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.DISABLEENABBLE);

            groupBox2.Enabled = true;
            dataGridView2.Enabled = false;
            txt_cons.Enabled = false;
            combo_origin.Enabled = false;
            combo_destination.Enabled = false;
            txt_origin.Enabled = false;
            txt_destination.Enabled = false;
            txt_transmode.Enabled = false;

        }

        public void ClearMethod(object param, EventArgs e)
        {
            ClearDataAfterChange();
            date_transaction.Value = System.DateTime.Now.Date;
            date_arrival.Value = System.DateTime.Now.Date;
            date_dep.Value = System.DateTime.Now.Date;
            radio_ib.Checked = true;
            radio_mawb.Checked = true;
            cmb_agency.Enabled = false;
            groupBox2.Enabled = false;
            txt_origin.Enabled = true;
            txt_destination.Enabled = true;
            dataGridView2.Enabled = true;
            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.DISABLEENABBLE);
        }

        public void DeleteMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void CloseForm(object param, EventArgs e)
        {
            throw new NotImplementedException();
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

        private FormStateEnum _FormState;
        public FormStateEnum FormState
        {
            get { return _FormState; }
            set { _FormState = value; }
        }
        public void ImportMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.Import;
            OpenFileDialog fileDialog = new OpenFileDialog();
            //var SelectedAgencyItem = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            //if (cmb_agency.SelectedItem != null)
            //{
            if (selectedAgencyItem.AgncyID == "FedEx")
            {
                fileDialog.DefaultExt = ".xlsx";
                fileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                fileDialog.ShowDialog();
                string FilePath = fileDialog.FileName;
                if (FilePath != null && FilePath != "")
                {

                }
            }
            else
            {

                fileDialog.Filter = "XML files (*.xml)|*.xml";
                fileDialog.ShowDialog();
                string FilePath = fileDialog.FileName;
                if (FilePath != null && FilePath != "")
                {
                    AwbList.Clear();
                    TNTAwbXmlData.Clear();
                    ReadXamlFile(FilePath);
                    CreateConsForXMLUpload();
                    if (TNTAwbXmlData.Count != 0)
                    {
                        if (AwbList.Count != 0)
                        {

                            dataGridView2.DataSource = null;
                            dataGridView2.AutoGenerateColumns = false;
                            dataGridView2.DataSource = ConsList;
                           
                            //dataGridView2.Refresh();
                            //textBox2.Text = AwbList.Count().ToString();

                        }
                        else
                        {
                            // textBox2.Text = "";
                        }
                    }
                }
            }
            //}
            //else
            //{
            //    MessageNotification.MessageBoxError("Please Select the Agency ", LoginInfoView.COMPANYNAME);
            //}
        }

        public void ProccessMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public void RefreshOriginDestination(AgencyDomainViewcs extTypeItem)
        {
            if (radio_ib.Checked == true)
            {
                combo_origin.DataSource = null;
                combo_destination.DataSource = null;
                combo_origin.DataSource = Location.Where(z => z.Country != extTypeItem.CountryCode && z.GateWay == "Y").ToList();
                combo_destination.DataSource = Location.Where(z => z.Country == extTypeItem.CountryCode && z.GateWay == "Y").ToList();
                combo_origin.DataSource = Location.Where(z => z.GateWay == "Y" && z.Country != extTypeItem.CountryCode).ToList();
                combo_origin.DisplayMember = "LocationName";
                combo_origin.ValueMember = "LocationID";
                combo_destination.DisplayMember = "LocationName";
                combo_destination.ValueMember = "LocationID";

            }
            if (radio_ob.Checked == true)
            {
                combo_origin.DataSource = null;
                combo_destination.DataSource = null;
                combo_origin.DataSource = Location.Where(z => z.Country == extTypeItem.CountryCode && z.GateWay == "Y").ToList();
                combo_destination.DataSource = Location.Where(z => z.Country != extTypeItem.CountryCode && z.GateWay == "Y").ToList();
                combo_origin.DisplayMember = "LocationName";
                combo_origin.ValueMember = "LocationID";
                combo_destination.DisplayMember = "LocationName";
                combo_destination.ValueMember = "LocationID";
            }
            if (radio_3p.Checked == true)
            {
                combo_origin.DataSource = null;
                combo_destination.DataSource = null;
                combo_origin.DataSource = Location.Where(z => z.GateWay == "Y").ToList();
                combo_destination.DataSource = Location.Where(z => z.GateWay == "Y").ToList();
                combo_origin.DisplayMember = "LocationName";
                combo_origin.ValueMember = "LocationID";
                combo_destination.DisplayMember = "LocationName";
                combo_destination.ValueMember = "LocationID";
            }

        }
        public void GetConsDataFomCons()
        {

            try
            {
                AllConsList.Clear();
                AllAwbList.Clear();
                AwbList.Clear();
                ConsList.Clear();
                dataGridView2.DataSource = null;
                dataGridView1.DataSource = null;

                if (selectedAgencyItem != null)
                {
                    if (radio_ib.Checked == true)
                    {
                         ConsList = dataProvider.GetConsDetail(selectedAgencyItem.CompID, selectedAgencyItem.GroupID, selectedAgencyItem.AgncyCode, date_transaction.Value.ToString("MM-dd-yyyy"), "I").ToList();

                    }
                    else if (radio_ob.Checked == true)
                    {
                         ConsList = dataProvider.GetConsDetail(selectedAgencyItem.CompID, selectedAgencyItem.GroupID, selectedAgencyItem.AgncyCode, date_transaction.Value.ToString("MM-dd-yyyy"), "O").ToList();
                    }
                    else if (radio_3p.Checked == true)
                    {
                         ConsList = dataProvider.GetConsDetail(selectedAgencyItem.CompID, selectedAgencyItem.GroupID, selectedAgencyItem.AgncyCode, date_transaction.Value.ToString("MM-dd-yyyy"), "T").ToList();
                    }
                    dataGridView2.AutoGenerateColumns = false;
                    dataGridView2.DataSource = ConsList;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #region Xml Upload Methord
        public void ReadXamlFile(string path)
        {
            try
            {
                string Sec_Name = "";
                DateTime Sec_Date = DateTime.Parse("01-01-1900");
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
                            Sec_Date = DateTime.Parse(Str_Sec_Date);
                        }
                        else
                        {
                            Sec_Date = DateTime.Parse("01-01-1900");
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
                        newData.Collection_Date = DateTime.Parse(piece_item["collectionDate"].InnerXml.Replace("![CDATA[", "").Replace("]]", "").Replace("<", "").Replace(">", ""));
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

        public void CreateConsForXMLUpload()
        {
            if (SelectedCons != null)
            {

                if (SelectedCons.ConsId.Trim() != TNTAwbXmlData.FirstOrDefault().Sec_ShippingDocNo.Trim())
                {
                    string DialogResult = MessageNotification.MessageBoxConfirmYesNoCancel("Cons No Mismatch, Press 'Yes' to Proceed With " + SelectedCons.ConsId + "\n or  Press 'No' to Create New Cons " + TNTAwbXmlData.FirstOrDefault().Sec_ShippingDocNo.Trim() + " "
                      , LoginInfoView.COMPANYNAME);
                    if (DialogResult == "Y")
                    {
                        AddingTNTXMLAwbData(SelectedCons);
                    }
                    else if (DialogResult == "N")
                    {
                        SelectedCons = null;
                        CreateNewConsDataForXmlUpload();
                    }

                }
                else
                {
                    AddingTNTXMLAwbData(SelectedCons);
                }
            }
            else
            {
                CreateNewConsDataForXmlUpload();
            }
        }

        public void CreateNewConsDataForXmlUpload()
        {
            var selectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            List<string> ConsNoList = TNTAwbXmlData.AsEnumerable().Select(r => r.Sec_ShippingDocNo).Distinct().ToList();
            foreach (var item_ConsNumbers in ConsNoList)
            {
                ConsMasterDomainView OldCons = dataProvider.CheckConsExist(selectedAgency.CompID, selectedAgency.GroupID, selectedAgency.AgncyCode, item_ConsNumbers);
                if (OldCons == null)
                {
                    TNTAwbXmlDataDomainView SelectedTntXMLAwbDetail = TNTAwbXmlData.FirstOrDefault(z => z.Sec_ShippingDocNo == item_ConsNumbers);
                    ConsMasterDomainView newTNTCons = new ConsMasterDomainView();
                    newTNTCons.ConsId = item_ConsNumbers;
                    newTNTCons.AgncyCode = selectedAgency.AgncyCode;
                    newTNTCons.AgncyID = selectedAgency.AgncyID;
                    newTNTCons.OrgHubID = SelectedTntXMLAwbDetail.Sec_Origin;
                    newTNTCons.DesHubID = SelectedTntXMLAwbDetail.Sec_Desti;

                    newTNTCons.AriDate = SelectedTntXMLAwbDetail.Sec_Date;
                    newTNTCons.DepDate = SelectedTntXMLAwbDetail.Sec_Date;
                    newTNTCons.DepTime = new TimeSpan();
                    newTNTCons.AriTime = new TimeSpan();

                    newTNTCons.CMPY = selectedAgency.CompID;
                    newTNTCons.Currency = "USD";

                    if (radio_ib.Checked == true)
                    {
                        newTNTCons.ShipType = "I";
                    }
                    else if (radio_ob.Checked == true)
                    {
                        newTNTCons.ShipType = "O";
                    }
                    else if (radio_3p.Checked == true)
                    {
                        newTNTCons.ShipType = "T";
                    }

                    //newTNTCons.ShipType = IsInbound == true ? "I" : "O";
                    newTNTCons.Deleted = false;

                    newTNTCons.FlightNo = SelectedTntXMLAwbDetail.Sec_Name;
                    newTNTCons.GroupID = selectedAgency.GroupID;
                    newTNTCons.MAWBNo = item_ConsNumbers;
                    newTNTCons.TransDate = date_transaction.Value;
                    newTNTCons.Remarks = "Automaticaly Created For TNT Upload";
                    newTNTCons.HighValueY = false;
                    newTNTCons.TransMode = SelectedTntXMLAwbDetail.Sec_Mode;
                    newTNTCons.VisaRootID = "";
                    newTNTCons.IsNew = true;
                    SaveConsList.Add(newTNTCons);
                    ConsList.Add(newTNTCons);
                    //BindingSource bs = (BindingSource)this.dataGridView2.DataSource;
                    //bs.Add(newTNTCons);
                    AddingTNTXMLAwbData(newTNTCons);


                }

                else
                {
                    if (MessageNotification.MessageBoxConfirm(OldCons.ConsId + " Allredy Exist " + " Do you want to Import AWB For Same Manifest ? ", LoginInfoView.COMPANYNAME))
                    {

                        date_transaction.Value = OldCons.TransDate;
                        SelectedCons = OldCons;
                        AddingTNTXMLAwbData(OldCons);

                    }
                    else
                    {
                        //  GetConsDataFomCons();
                    }
                }
            }

        }

        public void AddingTNTXMLAwbData(ConsMasterDomainView SelectedItemConsItem)
        {
            var selectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            List<OpsConsAWBDomainView> OldAwbData = dataProvider.GetOpsConsAWBDetail(selectedAgency.CompID, selectedAgency.GroupID, selectedAgency.AgncyCode, SelectedItemConsItem.ConsId).ToList();
            List<string> AwbNoList = TNTAwbXmlData.Where(c => c.Sec_ShippingDocNo == SelectedItemConsItem.ConsId).AsEnumerable().Select(r => r.Piec_ConsignmentNo).Distinct().ToList();

            if (ValidateShipmentType(TNTAwbXmlData.FirstOrDefault().Sec_Origin, TNTAwbXmlData.FirstOrDefault().Sec_Desti) != "")
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
                        else if (radio_3p.Checked == true)
                        {
                            newDomain.ShipType = "T";
                        }
                        newDomain.ExpressMpsNo = 0;
                        newDomain.AgnAWBNo = awb_item.Piec_ConsignmentNo;
                        newDomain.AgnMpsNo = "";
                        newDomain.AgnTrackNo = awb_item.Piec_ConsignmentNo;

                        newDomain.ORIGIN = awb_item.Piec_Origin;
                        newDomain.DESTIN = awb_item.Piec_Desti;

                        //newDomain.ORIGIN = awb_item.Piec_Origin;
                        //newDomain.DestinLoc = awb_item.Piec_Desti;

                        newDomain.ORIGINGate = awb_item.Sec_Origin;
                        newDomain.DESTINGate = awb_item.Sec_Desti;

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
                        newDomain.IntComDate = DateTime.Parse("01-01-1900");
                        newDomain.IntComTime = new TimeSpan();
                        newDomain.FinComDate = DateTime.Parse("01-01-1900");
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
                        newDomain.BusDay14 = DateTime.Parse("01-01-1900");
                        //newDomain.ScanGap = "";
                        //newDomain.MisScan = "";
                        //newDomain.PodYN = "";
                        //newDomain.slockcode = "";
                        //newDomain.SpCode = "";
                        newDomain.Remarks = "";
                        newDomain.USM_LOGIN = LoginInfoView.USERID.ToString();
                        newDomain.USM_DATE = System.DateTime.Now;
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
                MessageNotification.MessageBoxOK("Invalid shipment types or some gateways has not been defined in master files, Please Check First Recode in Manifest File", "Manifest Upload TNT");
                SaveConsList.Clear();
                ConsList.Clear();
                //GetConsDataFomCons();
            }

            if (SaveAwbList.Count > 0)
            {
                dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.DISABLEENABBLE);
            }

        }

        #endregion

        #region Shipment Type Validation
        public string ValidateShipmentType(string val_Origin, string val_Desti)
        {
            var selectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            string OriginCountry = null;
            string DestinationCountry = null;
            string ShipmetTypeValidationResult = "";
            if (val_Origin != null && val_Desti != null)
            {

                if (selectedAgency.AgncyID == "FedEx")
                {
                    OriginCountry = val_Origin;
                    DestinationCountry = val_Desti;
                }
                else
                {
                    OriginCountry = dataProvider.GetCountryCodeFromLocation(val_Origin);
                    DestinationCountry = dataProvider.GetCountryCodeFromLocation(val_Desti);
                }

                if (OriginCountry == null && DestinationCountry == null)
                {
                    ShipmetTypeValidationResult = "";
                }
                if (radio_ib.Checked == true)
                {
                    if (selectedAgency.CountryCode == DestinationCountry)
                    {
                        ShipmetTypeValidationResult = "I";
                    }
                    else
                    {
                        ShipmetTypeValidationResult = "";
                    }

                }
                else if (radio_ob.Checked == true)
                {
                    if (selectedAgency.CountryCode == OriginCountry)
                    {
                        ShipmetTypeValidationResult = "O";
                    }
                    else
                    {
                        ShipmetTypeValidationResult = "";
                    }
                }
                else if (radio_3p.Checked == true)
                {
                    if (selectedAgency.CountryCode != OriginCountry && selectedAgency.CountryCode != DestinationCountry)
                    {
                        ShipmetTypeValidationResult = "T";
                    }
                    else
                    {
                        ShipmetTypeValidationResult = "";
                    }
                }

            }
            return ShipmetTypeValidationResult;
        }

        #endregion

        private void cmb_agency_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedAgencyItem = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            txt_company.Text = selectedAgencyItem.CompName;
            if (cmb_agency.SelectedItem != null)
            {
                Location = dataProvider.GetGateways(selectedAgencyItem.CountryCode).ToList();
                RefreshOriginDestination(selectedAgencyItem);
                GetConsDataFomCons();
            }
        }

        private void ClearDataAfterChange()
        {
            dataGridView2.ClearSelection();
            textBox2.Text = "";
            textBox3.Text = "";
            //AllAwbList.Clear();
            //AwbList.Clear();
            //ConsList.Clear();
            //dataGridView1.DataSource = null;
            SelectedCons = null;
            txt_cons.Text = "";
            txt_mawb.Text = "";
            txt_transmode.Text = "";
            combo_origin.SelectedIndex = -1;
            combo_destination.SelectedIndex = -1;
            txt_remarks.Text = "";
            txt_origin.Text = "";
            txt_destination.Text = "";
            date_arrival.Value = System.DateTime.Now.Date;
            date_dep.Value = System.DateTime.Now.Date;
            txt_flightno.Text = "";
        }

        private void dataGridView2_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                var selectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
                var consRow = (ConsMasterDomainView)e.Row.DataBoundItem;
                if (consRow != null)
                {
                    SelectedCons = (ConsMasterDomainView)e.Row.DataBoundItem;
                    if (SelectedCons != null)
                    {
                        txt_cons.Text = SelectedCons.ConsId.ToString();
                        txt_mawb.Text = SelectedCons.MAWBNo.ToString();
                        txt_transmode.Text = SelectedCons.TransMode.ToString();
                        txt_flightno.Text = SelectedCons.FlightNo.ToString();
                        txt_remarks.Text = SelectedCons.Remarks.ToString();
                        date_arrival.Value = SelectedCons.AriDate;
                        date_dep.Value = SelectedCons.DepDate;
                        combo_origin.SelectedValue = SelectedCons.OrgHubID.Trim();
                        combo_destination.SelectedValue = SelectedCons.DesHubID.Trim();

                        if (SelectedCons.IsNew == true)
                        {
                            dataGridView1.DataSource = null;
                            dataGridView1.AutoGenerateColumns = false;
                            dataGridView1.DataSource = SaveAwbList.Where(a => a.ConsId.Trim() == SelectedCons.ConsId.Trim()).ToList();
                            textBox2.Text = SaveAwbList.Where(a => a.ConsId.Trim() == SelectedCons.ConsId.Trim()).ToList().Count().ToString();
                            textBox3.Text = SaveAwbList.Where(a => a.ConsId.Trim() == SelectedCons.ConsId.Trim()).ToList().Sum(z => z.TotPkgs).ToString();
                        }
                        else
                        {
                            AllAwbList = AwbList = dataProvider.GetOpsConsAWBDetail(selectedAgency.CompID, selectedAgency.GroupID, selectedAgency.AgncyCode, SelectedCons.ConsId.Trim()).ToList();
                            dataGridView1.DataSource = null;
                            dataGridView1.AutoGenerateColumns = false;
                            dataGridView1.DataSource = AwbList;
                            textBox2.Text = AwbList.Count().ToString();
                            textBox3.Text = AwbList.Sum(a => a.TotPkgs).ToString();
                        }

                    }
                }
            }
            catch (Exception)
            {


            }

        }

        private void radio_ib_CheckedChanged(object sender, EventArgs e)
        {
            GetConsDataFomCons();
        }

        private void radio_ob_CheckedChanged(object sender, EventArgs e)
        {
            GetConsDataFomCons();
        }

        private void radio_3p_CheckedChanged(object sender, EventArgs e)
        {
            GetConsDataFomCons();

        }

        private void combo_origin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_origin.SelectedItem != null)
            {
                var selectedOrigin = (GatewayDomainView)combo_origin.SelectedItem;
                txt_origin.Text = selectedOrigin.LocationID.ToString();
            }
        }

        private void combo_destination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_destination.SelectedItem != null)
            {
                var selectedOrigin = (GatewayDomainView)combo_destination.SelectedItem;
                txt_destination.Text = selectedOrigin.LocationID.ToString();
            }
        }

        private void date_transaction_ValueChanged(object sender, EventArgs e)
        {
            GetConsDataFomCons();
        }
    }
}
