using Express.Domain.Message;
using Express.Interfaces.Operations.Manifest;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Enum;
using Express.UI.Common.Helpers;
using Express.UI.Factory.Operations;
using Express.UI.Helpers;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
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

namespace Express.UI.Operation.View
{
    public partial class Manifest_Upload_Fedex : Form,IDataManipulate
    {
        private readonly IManifestUploadFedex<ManifestUploadFedexDomainView> dataProvider;
        private List<GatewayDomainView> Location = new List<GatewayDomainView>();

        private List<ConsMasterDomainView> AllConsList = new List<ConsMasterDomainView>();
        private List<ConsMasterDomainView> ConsList = new List<ConsMasterDomainView>();

        List<OpsConsAWBDomainView> AllAwbList = new List<OpsConsAWBDomainView>();
        List<OpsConsAWBDomainView> AwbList = new List<OpsConsAWBDomainView>();
        List<OpsConsAWBDomainView> SaveAwbList = new List<OpsConsAWBDomainView>();
        List<OpsConsAWBDomainView> DuplicateAwb = new List<OpsConsAWBDomainView>();

        ConsMasterDomainView SelectedCons = null;
        DuplicateAWB DuplicateWindow = null;
        private readonly ConsMasterDomainView _model;
        public Manifest_Upload_Fedex()
        {
            InitializeComponent();
            if (dataProvider == null)
            {
                dataProvider = OperationsUIFacotry.GetService<IManifestUploadFedex<ManifestUploadFedexDomainView>>();
            }
            _model = new ConsMasterDomainView();
            dataManipulate2.NewButtonClick += new EventHandler(NewMethod);
            dataManipulate2.SaveButtonClick += new EventHandler(SaveMethod);
            dataManipulate2.EditButtonClick += new EventHandler(EditMethod);
            dataManipulate2.CancelButtonClick += new EventHandler(ClearMethod);
            dataManipulate2.CloseButtonClick += new EventHandler(CloseForm);
            dataManipulate2.DelteButtonClick += new EventHandler(DeleteMethod);
            dataManipulate2.ImportButtonClick += new EventHandler(ImportMethod);

            dataManipulate2.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate2.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate2.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate2.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate2.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);

            dataManipulate2.CustomButtonState(ButtonTypes.PRINT, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate2.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate2.CustomButtonState(ButtonTypes.PROCESS, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate2.CustomButtonState(ButtonTypes.IMPORT, true, ButtonCustomState.HIDEVISIBLE);

            date_transaction.Value = System.DateTime.Now.Date;
            date_arrival.Value = System.DateTime.Now.Date;
            date_dep.Value = System.DateTime.Now.Date;
            radio_ib.Checked = true;
            radio_mawb.Checked = true;
            cmb_agency.Enabled = false;
            groupBox2.Enabled = false;
        }

        #region Data Manipilation

        public void ClearMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.Clear;
            dataManipulate2.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate2.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate2.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate2.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate2.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            dataGridView2.ClearSelection();
            txt_cons.Enabled = true;
            combo_origin.Enabled = true;
            combo_destination.Enabled = true;
            AllAwbList.Clear();
            AwbList.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView2.Enabled = true;
            txt_origin.Enabled = true;
            txt_destination.Enabled = true;
            groupBox2.Enabled = false;
            txt_transmode.Enabled = true;
            ClearFeild();
        }
        public void ClearFeild()
        {
            dataGridView2.ClearSelection();
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
            textBox2.Text = "";
            textBox3.Text = "";


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
            if (txt_cons.Text != "")
            {
                FormState = FormStateEnum.Update;
                dataManipulate2.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
                dataManipulate2.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
                dataManipulate2.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate2.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate2.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
                dataManipulate2.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.DISABLEENABBLE);
                dataGridView2.Enabled = false;
                txt_cons.Enabled = false;
                combo_origin.Enabled = false;
                combo_destination.Enabled = false;
                txt_transmode.Enabled = false;
                txt_origin.Enabled = false;
                txt_destination.Enabled = false;
                groupBox2.Enabled = true;
                dataGridView2.ClearSelection();
            }
            else
            {
                MessageNotification.MessageBoxError("Please Select the Cons First ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }

        }

        public void FilterMethod(object param, EventArgs e)
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
                if (SelectedAgencyItem.AgncyID == "FedEx")
                {
                    fileDialog.DefaultExt = ".xlsx";
                    fileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                    fileDialog.ShowDialog();
                    string FilePath = fileDialog.FileName;
                    if (FilePath != null && FilePath != "")
                    {
                        AwbList.Clear();
                        AllAwbList.Clear();
                        SaveAwbList.Clear();
                        LoadFedexExcel(FilePath);
                        
                        //LoadFedexExcel(FilePath, SelectedAgencyItem);
                        //if (AWBList.Count != 0)
                        //{
                        //    dataGridView1.AutoGenerateColumns = false;
                        //    dataGridView1.DataSource = AWBList;
                        //    textBox2.Text = AWBList.Count().ToString();
                        //}
                    }
                }
                else
                {

                //    fileDialog.Filter = "XML files (*.xml)|*.xml";
                //    fileDialog.ShowDialog();
                //    string FilePath = fileDialog.FileName;
                //    if (FilePath != null && FilePath != "")
                //    {
                //        AWBList.Clear();
                //        TNTAwbXmlData.Clear();
                //        ReadXamlFile(FilePath);
                //        SaveTntAwbDetails(SelectedAgencyItem);
                //        if (TNTAwbXmlData.Count != 0)
                //        {
                //            if (AWBList.Count != 0)
                //            {
                //                dataGridView1.AutoGenerateColumns = false;
                //                dataGridView1.DataSource = AWBList;
                //                textBox2.Text = AWBList.Count().ToString();

                //            }
                //            else
                //            {
                //                textBox2.Text = "";
                //            }
                //        }
                //    }
               }
            }
            else
            {
                MessageNotification.MessageBoxError("Please Select the Agency ", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
        }

        public void NewMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.New;
            AllAwbList.Clear();
            AwbList.Clear();
            dataGridView2.Enabled = false;
            txt_origin.Enabled = true;
            txt_destination.Enabled = true;
            groupBox2.Enabled = true;
            txt_transmode.Enabled = true;
            combo_origin.Enabled = true;
            combo_destination.Enabled = true;
            txt_cons.Enabled = true;
            dataGridView2.ClearSelection();
            dataManipulate2.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate2.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate2.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate2.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate2.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate2.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.DISABLEENABBLE);
            ClearFeild();
            dataGridView1.DataSource = null;
        }

        private FormStateEnum _FormState;
        public FormStateEnum FormState
        {
            get { return _FormState; }
            set { _FormState = value; }
        }

        public void previewMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
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
            var selectedagency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            var selectedorigin = (GatewayDomainView)combo_origin.SelectedItem;
            var selecteddestination = (GatewayDomainView)combo_destination.SelectedItem;

            string ShipType = "";

            if (radio_ib.Checked == true)
            {
                ShipType = "I";
            }
            if (radio_ob.Checked == true)
            {
                ShipType = "O";
            }
            if (radio_3p.Checked == true)
            {
                ShipType = "T";
            }

            ResponseMessage responce = null;
            _model.AgncyCode = selectedagency.AgncyCode;
            _model.AgncyID = selectedagency.AgncyID;
            _model.CMPY = selectedagency.CompID;
            _model.GroupID = selectedagency.GroupID;
            _model.ALActWgt = 0m;
            _model.Remarks = txt_remarks.Text;
            _model.ALChgWgt = 0m;
            _model.AlFreightChg = 0m;
            _model.AriDate = date_arrival.Value;
            _model.DepDate = date_dep.Value;
            _model.AriTime = new TimeSpan();
            _model.DepTime = new TimeSpan();
            _model.ConsId = txt_cons.Text;
            _model.MAWBNo = txt_mawb.Text;
            if (selectedorigin == null)
            {
                _model.OrgHubID = "";
            }
            else
            {
                _model.OrgHubID = selectedorigin.LocationID;
            }
            if( selecteddestination==null)
            {
                _model.DesHubID = "";
            }
            else
            {
                _model.DesHubID = selecteddestination.LocationID;
            }
            _model.TransMode = txt_transmode.Text;
            _model.TransDate = date_transaction.Value;
            _model.ShipType = ShipType;
            _model.HighValueY = false;
            _model.AlNumCode = "0";
            _model.FlightNo = txt_flightno.Text;
            
            var vResult = CustomValidate.Instance.ValidateModel(_model);
            if (FormState == FormStateEnum.Import)
            {
                if (FormState == FormStateEnum.Import)
                {
                    if (SaveAwbList.Count != 0)
                    {
                        ManifestUploadWrappingDomain AwbWrapper = new ManifestUploadWrappingDomain();
                        AwbWrapper.AwbList = SaveAwbList;
                        responce = dataProvider.SaveAwbList(AwbWrapper);
                        if (responce.IsSuccess)
                        {
                            MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);
                          
                            dataManipulate2.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                            dataManipulate2.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                            dataManipulate2.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                            dataManipulate2.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                            dataManipulate2.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
                           
                            dataGridView2.Enabled = true;
                            dataGridView1.DataSource = null;
                            dataGridView2.ClearSelection();
                            GetConsDataFomCons();
                            dataGridView2.ClearSelection();
                            groupBox2.Enabled = false;
                        }
                        else
                        {
                            MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                        }
                    }
                    else
                    {
                        MessageNotification.MessageBoxError("No New AWB Found", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                    }
                }
            }
            else
            {
                if (txt_cons.Text != "" && txt_mawb.Text != "" && txt_flightno.Text != "" && txt_transmode.Text != "")
                {
                    FormState = (FormState != FormStateEnum.Update) ? FormStateEnum.Save : FormStateEnum.Update;
                    if (vResult == "")
                    {

                        if (FormState == FormStateEnum.Save)
                        {
                            responce = dataProvider.SaveCons(_model);
                        }
                        if (FormState == FormStateEnum.Update)
                        {
                            responce = dataProvider.EditDetails(_model);
                        }


                        if (responce.IsSuccess)
                        {
                            MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);

                            dataManipulate2.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                            dataManipulate2.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                            dataManipulate2.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                            dataManipulate2.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                            dataManipulate2.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);

                            dataGridView2.Enabled = true;
                            dataGridView1.DataSource = null;
                            //ClearDataAfterChange();
                            dataGridView2.ClearSelection();
                            GetConsDataFomCons();
                            groupBox2.Enabled = false;

                        }
                        else
                        {
                            MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                        }
                    }
                    else
                    {
                        MessageNotification.MessageBoxError("Invalid Details", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                    }
                }
                else
                {
                    MessageNotification.MessageBoxError(vResult, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                }
            }

        }
        #endregion

        private void Manifest_Upload_Fedex_Load(object sender, EventArgs e)
        {

                IList<AgencyDomainViewcs> agencyList = dataProvider.GetAgencyDetail(1, 200, 1002);
                cmb_agency.DataSource = agencyList;
                cmb_agency.DisplayMember = "AgncyName";
                cmb_agency.ValueMember = "AgncyID";
        }

        private void cmb_agency_SelectedIndexChanged(object sender, EventArgs e)
        {
            var extTypeItem = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            txt_company.Text = extTypeItem.CompName;
            if (cmb_agency.SelectedItem != null)
            {
                Location = dataProvider.GetGateways(extTypeItem.CountryCode).ToList();
                ClearDataAfterChange();
                RefreshOriginDestination(extTypeItem);
                GetConsDataFomCons();
            }
           
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
                combo_origin.DataSource = Location.Where(z=>z.GateWay == "Y").ToList();
                combo_destination.DataSource = Location.Where(z=>z.GateWay == "Y").ToList();
                combo_origin.DisplayMember = "LocationName";
                combo_origin.ValueMember = "LocationID";
                combo_destination.DisplayMember = "LocationName";
                combo_destination.ValueMember = "LocationID";
            }

        }

        private void radio_ib_CheckedChanged(object sender, EventArgs e)
        {
            var extTypeItem = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            if (cmb_agency.SelectedItem != null)
            {
                RefreshOriginDestination(extTypeItem);
                ClearDataAfterChange();
                GetConsDataFomCons();
                
            }
        }

        private void radio_ob_CheckedChanged(object sender, EventArgs e)
        {
            var extTypeItem = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            if (cmb_agency.SelectedItem != null)
            {
                RefreshOriginDestination(extTypeItem);
                GetConsDataFomCons();
                ClearDataAfterChange();
            }
        }

        private void txt_cons_TextChanged(object sender, EventArgs e)
        {

        }

        public void GetConsDataFomCons()
        {
            var selectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            AllConsList.Clear();
            AllAwbList.Clear();
            AwbList.Clear();
            ConsList.Clear();
            dataGridView2.DataSource = null;
            dataGridView1.DataSource = null;
            dataManipulate2.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.DISABLEENABBLE);

            if (selectedAgency != null)
            {
                if (radio_ib.Checked == true)
                {
                    AllConsList = ConsList = dataProvider.GetConsDetail(selectedAgency.CompID, selectedAgency.GroupID, selectedAgency.AgncyCode, date_transaction.Value.ToString("MM-dd-yyyy"), "I").ToList();

                }
                else if (radio_ob.Checked == true)
                {
                    AllConsList = ConsList = dataProvider.GetConsDetail(selectedAgency.CompID, selectedAgency.GroupID, selectedAgency.AgncyCode, date_transaction.Value.ToString("MM-dd-yyyy"), "O").ToList();
                }
                else if (radio_3p.Checked == true)
                {
                    AllConsList = ConsList = dataProvider.GetConsDetail(selectedAgency.CompID, selectedAgency.GroupID, selectedAgency.AgncyCode, date_transaction.Value.ToString("MM-dd-yyyy"), "T").ToList();
                }
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = ConsList;
              
            }
            dataGridView2.ClearSelection();
        }

        private void radio_3p_CheckedChanged(object sender, EventArgs e)
        {
            GetConsDataFomCons();
            ClearDataAfterChange();
        }

        private void date_transaction_ValueChanged(object sender, EventArgs e)
        {
            ClearDataAfterChange();
            GetConsDataFomCons();
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
                }
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
                    AllAwbList = AwbList = dataProvider.GetOpsConsAWBDetail(selectedAgency.CompID, selectedAgency.GroupID, selectedAgency.AgncyCode, SelectedCons.ConsId.Trim()).ToList();
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = AwbList;
                    dataManipulate2.CustomButtonState(ButtonTypes.IMPORT, true, ButtonCustomState.DISABLEENABBLE);
                    textBox2.Text = AwbList.Where(a => a.ConsId.Trim() == SelectedCons.ConsId.Trim()).ToList().Count().ToString();
                    textBox3.Text = AwbList.Where(a => a.ConsId.Trim() == SelectedCons.ConsId.Trim()).ToList().Sum(z => z.TotPkgs).ToString();

                }
            }
            catch (Exception)
            {

              
            }
        }
        
        private void ClearDataAfterChange()
        {
            AllAwbList.Clear();
            AwbList.Clear();
            ConsList.Clear();
            dataGridView2.DataSource = null;
            dataGridView1.DataSource = null;
        }

        public void LoadFedexExcel(string Path)
        {
            try
            {   
                var selectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
                DataTable dt = ReadExcelFile(Path);
                List<OpsConsAWBDomainView> OldAwbData = dataProvider.GetOpsConsAWBDetail(selectedAgency.CompID, selectedAgency.GroupID, selectedAgency.AgncyCode, SelectedCons.ConsId).ToList();

                if (ValidateShipmentType(dt.Rows[0]["ORGCOUNTRY"].ToString(), dt.Rows[0]["DESCOUNTRY"].ToString()) != "")
                {
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
                            model.GroupID = SelectedCons.GroupID;
                            model.CMPY = SelectedCons.CMPY;
                            model.AgncyCode = SelectedCons.AgncyCode;
                            model.AgncyID = SelectedCons.AgncyID;
                            model.ConsId = SelectedCons.ConsId;
                            if (radio_ib.Checked == true)
                            {
                                model.ShipType = "I";
                            }
                            else if (radio_ob.Checked == true)
                            {
                                model.ShipType = "O";
                            }
                            else if (radio_3p.Checked == true)
                            {
                                model.ShipType = "T";
                            }
                            model.TransMode = SelectedCons.TransMode;
                            model.AgnMpsNo = dr["FdxMasterNo"] == null ? "" : dr["FdxMasterNo"].ToString();
                            model.AgnAWBNo = dr["FdxTrackNo"] == null ? "" : dr["FdxTrackNo"].ToString();
                            model.ExpressMpsNo = 0;
                            //model.AgnTrackNo = dr["Trac"] == null ? "" : dr["Trac"].ToString();
                            model.AgnTrackNo = "";
                            model.ORIGIN = dr["ORIGIN"] == null ? "" : dr["ORIGIN"].ToString();
                            model.DESTIN = dr["DESTIN"] == null ? "" : dr["DESTIN"].ToString();
                            model.ORIGINGate = SelectedCons.OrgHubID;
                            model.DESTINGate = SelectedCons.DesHubID;

                            model.ORGCOUNTRY = dr["ORGCOUNTRY"] == null ? "" : dr["ORGCOUNTRY"].ToString();
                            model.DESCOUNTRY = dr["DESCOUNTRY"] == null ? "" : dr["DESCOUNTRY"].ToString();

                            //model.OrignLoc = dr["origin2"] == null ? "" : dr["origin2"].ToString();
                            //model.DestinLoc = dr["destination2"] == null ? "" : dr["destination2"].ToString();

                            model.TransDate = date_transaction.Value;
                            string ShipDateString = dr["ShipDate"] == null ? "" : dr["ShipDate"].ToString();
                            if (ShipDateString != "")
                            {
                                string Ship_year = ShipDateString.Substring(0, 4);
                                string Ship_month = ShipDateString.Substring(4, 2);
                                string Ship_day = ShipDateString.Substring(6, 2);
                                model.ShipDate = DateTime.Parse(Ship_month + "-" + Ship_day + "-" + Ship_year);
                            }
                            else
                            {
                                model.ShipDate = DateTime.Parse("01-01-1900");
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

                            if (SelectedCons.HighValueY == true)
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
                                model.IntComDate = DateTime.Parse(IntCom_month + "-" + IntCom_day + "-" + IntCom_year);
                            }
                            else
                            {
                                model.IntComDate = DateTime.Parse("01-01-1900");
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
                            model.BusDay14 = DateTime.Parse("01-01-1900");
                            model.ScanGap = "";
                            model.MisScan = "";
                            model.PodYN = "";
                            model.slockcode = "";
                            model.SpCode = "";
                            model.Remarks = "";
                            model.USM_LOGIN = LoginInfoView.USERID.ToString();
                            model.USM_DATE = System.DateTime.Now.Date;
                            model.BillTransChgY = "";
                            model.InvNoTransChg = 0m;
                            model.LastScanDate = DateTime.Parse("01-01-1900");
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
                       
                        DuplicateWindow=new DuplicateAWB(DuplicateAwb);
                        DuplicateWindow.ShowDialog();
                    }
                }
                else
                {
                    DuplicateWindow.Close();
                    MessageNotification.MessageBoxOK("Invalid shipment types or some gateways has not been defined in master files, Please Check First Recode in Manifest File", "Express");
                    AwbList.Clear();
                    ConsList.Clear();
                }
            }
            catch (OperationCanceledException ex)
            {
                MessageNotification.MessageBoxOK(ex.InnerException.ToString(), "Express");
            }
            if (AwbList.Count > 0)
            {
                dataManipulate2.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
                dataManipulate2.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate2.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.DISABLEENABBLE);

            }
            
            dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = AwbList;
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

            Awb.LastScanDate = DateTime.Parse("01-01-1900");

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

            if (SelectedCons.HighValueY == true)
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

        #region Excel Reading Methord
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
                var selecteddestination = (GatewayDomainView)combo_destination.SelectedItem;
                txt_destination.Text = selecteddestination.LocationID.ToString();
            }
        }

        
    }
}
