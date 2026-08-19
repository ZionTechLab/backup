using Express.Domain.Message;
using Express.Interfaces.Operations.Manifest;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Enum;
using Express.UI.Common.Helpers;
using Express.UI.Factory.Operations;
using Express.UI.Helpers;
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
    public partial class Clearance_PreAlert : Form, IDataManipulate
    {
        private readonly IClearancePreAlert<ClearancePreAlertDomainView> dataProvider;
        private List<GatewayDomainView> Location = new List<GatewayDomainView>();
        private readonly ClearancePreAlertDomainView _model;
       // private AgencyDomainViewcs SelectedAgency = null;
        public Clearance_PreAlert()
        {
            InitializeComponent();
            date_transaction.Value = System.DateTime.Now.Date;
            _model = new ClearancePreAlertDomainView();
            if (dataProvider == null)
            {
                dataProvider = OperationsUIFacotry.GetService<IClearancePreAlert<ClearancePreAlertDomainView>>();
            }

            dataManipulate1.NewButtonClick += new EventHandler(NewMethod);
            dataManipulate1.SaveButtonClick += new EventHandler(SaveMethod);
            dataManipulate1.EditButtonClick += new EventHandler(EditMethod);
            dataManipulate1.CancelButtonClick += new EventHandler(ClearMethod);
            dataManipulate1.CloseButtonClick += new EventHandler(CloseForm);
            dataManipulate1.DelteButtonClick += new EventHandler(DeleteMethod);


            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);

            dataManipulate1.CustomButtonState(ButtonTypes.PRINT, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PROCESS, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.HIDEVISIBLE);
            groupBox2.Enabled = false;
            radio_ib.Checked = true;
            radio_flight.Checked = true;
            date_transaction.Value = System.DateTime.Now.Date;
            date_arrival.Value= System.DateTime.Now.Date;
            date_dep.Value = System.DateTime.Now.Date;
        }

        private void Clearance_PreAlert_Load(object sender, EventArgs e)
        {
            IList<AgencyDomainViewcs> agencyList = dataProvider.GetAgencyDetail(1, 200, 1002);
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
                _model.GroupID = SelectedAgency.GroupID;
                _model.CMPY = SelectedAgency.CompID;
                _model.AgncyCode = SelectedAgency.AgncyCode;

                Location = dataProvider.GetGateways(SelectedAgency.CountryCode).ToList();
                RefreshOriginDestination(SelectedAgency);
               // GetConsDetail();
            }
        }

        public void RefreshOriginDestination(AgencyDomainViewcs extTypeItem)
        {
            combo_gateway.DataSource = null;
            combo_gateway.DataSource = Location.Where(z => z.Country == extTypeItem.CountryCode && z.GateWay == "Y").ToList();
            combo_gateway.DisplayMember = "LocationName";
            combo_gateway.ValueMember = "LocationID";

            combo_Destin_Gate.DataSource = null;
            combo_Destin_Gate.DataSource = Location.Where(z => z.Country != extTypeItem.CountryCode && z.GateWay == "Y").ToList();
            combo_Destin_Gate.DisplayMember = "LocationName";
            combo_Destin_Gate.ValueMember = "LocationID";


        }

        private void combo_LocalGateway_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combo_gateway.SelectedItem != null)
            {
                var selectedOrigin = (GatewayDomainView)combo_gateway.SelectedItem;
                txt_Gate_way.Text = selectedOrigin.LocationID.ToString();
                GetConsDetail();
            }
        }


        private FormStateEnum _FormState;
        public FormStateEnum FormState
        {
            get { return _FormState; }
            set { _FormState = value; }
        }


        #region Data Maniflulate

        public void NewMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.New;

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            groupBox2.Enabled = true;
            radio_ib.Checked = true;
            radio_flight.Checked = true;
            dataGridView2.Enabled = false;
            ClearField();
        }

        public void SaveMethod(object param, EventArgs e)
        {
            var selectedorigin = (GatewayDomainView)combo_gateway.SelectedItem;
            var SelectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            var selecteddestination = (GatewayDomainView)combo_Destin_Gate.SelectedItem;
            FormState = (FormState != FormStateEnum.Update) ? FormStateEnum.Save : FormStateEnum.Update;
            ResponseMessage responce = null;
            _model.AgncyCode = SelectedAgency.AgncyCode;
            _model.AgncyID = SelectedAgency.AgncyID;
            _model.CMPY = SelectedAgency.CompID;
            _model.GroupID = SelectedAgency.GroupID;
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
            
            if(radio_flight.Checked==true)
            {
                _model.TransMode = "A";
            }
            else
            {
                _model.TransMode = "T";
            }
            _model.TransDate = date_transaction.Value;
            if (radio_ib.Checked == true)
            {
                _model.ShipType = "I";
                if (selectedorigin == null)
                {
                    _model.OrgHubID = "";
                }
                else
                {
                    _model.OrgHubID = selecteddestination.LocationID;
                }
                if (selecteddestination == null)
                {
                    _model.DesHubID = "";
                }
                else
                {
                    _model.DesHubID = selectedorigin.LocationID;
                }
            }
            else if(radio_ob.Checked == true)
            {
                _model.ShipType = "O";
                if (selectedorigin == null)
                {
                    _model.DesHubID = "";
                }
                else
                {
                    _model.DesHubID = selecteddestination.LocationID;
                }
                if (selecteddestination == null)
                {
                    _model.OrgHubID = "";
                }
                else
                {
                    _model.OrgHubID = selectedorigin.LocationID;
                }
            }
            _model.HighValueY = false;
            _model.AlNumCode = "0";
            _model.FlightNo = txt_flightno.Text;
            _model.ExpressCons = textBox2.Text.ToString();
            var vResult = CustomValidate.Instance.ValidateModel(_model);

            if (vResult == "")
            {
                if (FormState == FormStateEnum.Save)
                {
                    responce = dataProvider.SaveDetails(_model);
                }
                if (FormState == FormStateEnum.Update)
                {
                    responce = dataProvider.EditDetails(_model);
                }

                if (responce.IsSuccess)
                {
                    MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);

                    dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
                    textBox2.Text = responce.ReturnValue==null?"": responce.ReturnValue.ToString();
                    ClearField();
                    groupBox2.Enabled = false;
                    GetConsDetail();
                    dataGridView2.Enabled = true;
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

        public void EditMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.Update;

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            groupBox2.Enabled = true;
            dataGridView2.Enabled = false;
        }

        public void ClearMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.Clear;
            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            groupBox2.Enabled = false;
            radio_ib.Checked = true;
            radio_flight.Checked = true;
            date_transaction.Value = System.DateTime.Now.Date;
            ClearField();
            dataGridView2.Enabled = true;
        }

        public void DeleteMethod(object param, EventArgs e)
        {
            ResponseMessage responce = null;
            FormState = FormStateEnum.Delete;
            var selectedorigin = (GatewayDomainView)combo_gateway.SelectedItem;
            var SelectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            var selecteddestination = (GatewayDomainView)combo_Destin_Gate.SelectedItem;

            _model.AgncyCode = SelectedAgency.AgncyCode;
            _model.AgncyID = SelectedAgency.AgncyID;
            _model.CMPY = SelectedAgency.CompID;
            _model.ExpressCons = textBox2.Text;
            _model.GroupID = SelectedAgency.GroupID;
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
            if (selecteddestination == null)
            {
                _model.DesHubID = "";
            }
            else
            {
                _model.DesHubID = selecteddestination.LocationID;
            }
            if (radio_flight.Checked == true)
            {
                _model.TransMode = "A";
            }
            if(radio_road.Checked==true) 
            {
                _model.TransMode = "T";
            }
            _model.TransDate = date_transaction.Value;
            if (radio_ib.Checked == true)
            {
                _model.ShipType = "I";
            }
            else if (radio_ob.Checked == true)
            {
                _model.ShipType = "O";
            }
            _model.HighValueY = false;
            _model.AlNumCode = "0";
            _model.FlightNo = txt_flightno.Text;

            if (FormState == FormStateEnum.Delete)
            {
                responce = dataProvider.DeleteDetail(_model);
            }
            if (responce.IsSuccess)
            {
                MessageNotification.MessageBoxOK(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.Successfull);

                dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
                textBox2.Text = responce.ReturnValue == null ? "" : responce.ReturnValue.ToString();
                ClearField();
                groupBox2.Enabled = false;
                GetConsDetail();
                dataGridView2.Enabled = true;
            }
            else
            {
                MessageNotification.MessageBoxError(responce.StrMessage, LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }


        }

        public void CloseForm(object param, EventArgs e)
        {
            this.Dispose();
        }

        public void FilterMethod(object param, EventArgs e)
        {

        }

        public void PrintMethod(object param, EventArgs e)
        {

        }

        public void previewMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ImportMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ProccessMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion

        public void GetConsDetail()
        {
            ClearancePreAlertDomainView SerchCons = new ClearancePreAlertDomainView();
            var selectedorigin = (GatewayDomainView)combo_gateway.SelectedItem;
            var SelectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            if (SelectedAgency != null)
            {
                SerchCons.GroupID = SelectedAgency.GroupID;
                SerchCons.CMPY = SelectedAgency.CompID;
                SerchCons.AgncyCode = SelectedAgency.AgncyCode;
                SerchCons.TransDate = date_transaction.Value;

                SerchCons.OrgHubID = selectedorigin.LocationID;
                dataGridView2.DataSource = null;
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = dataProvider.GetDetails(SerchCons);
            }

        }
        public void ClearField()
        {
            textBox2.Text = "";
            txt_mawb.Text = "";
            txt_cons.Text = "";
            txt_remarks.Text = "";
            txt_flightno.Text = "";
            date_dep.Value = System.DateTime.Now.Date;
            date_arrival.Value= System.DateTime.Now.Date;
            radio_flight.Checked = true;
            radio_ib.Checked = true;
            combo_Destin_Gate.SelectedIndex = 0;
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            ClearancePreAlertDomainView refCons =  new ClearancePreAlertDomainView();
            var selectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
            SearchClearance_PreAlert serch = new SearchClearance_PreAlert(selectedAgency,ref refCons);
            serch.ShowDialog();
            var res = refCons;
            if (refCons.OrgHubID != null)
            {
                date_transaction.Value = refCons.TransDate;
                combo_gateway.SelectedItem = refCons.OrgHubID;
            }
            GetConsDetail();

        }

        public void AdvanceFindMethord()
        {

        }

        private void date_transaction_ValueChanged(object sender, EventArgs e)
        {
            GetConsDetail();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var selectedAgency = (AgencyDomainViewcs)cmb_agency.SelectedItem;
                var consRow = (ClearancePreAlertDomainView)dataGridView2.SelectedRows[0].DataBoundItem;
                txt_cons.Text = consRow.ConsId.ToString();
                txt_mawb.Text = consRow.MAWBNo.ToString();
                textBox2.Text = consRow.ExpressCons.ToString();
                if (consRow.TransMode.ToString() == "A")
                {
                    radio_flight.Checked = true;
                }
                else if(consRow.TransMode.ToString() == "T")
                {
                    radio_road.Checked = true;
                }
                if (consRow.ShipType.ToString() == "I")
                {
                    radio_ib.Checked = true;
                    //combo_gateway.SelectedValue = consRow.OrgHubID.Trim();
                    //combo_Destin_Gate.SelectedValue = consRow.DesHubID.Trim();
                    combo_Destin_Gate.SelectedValue = consRow.OrgHubID.Trim();
                }
                else if (consRow.ShipType.ToString() == "O")
                {
                    radio_ob.Checked = true;
                    combo_Destin_Gate.SelectedValue = consRow.DesHubID.Trim();
                    //combo_gateway.SelectedValue = consRow.DesHubID.Trim();
                    //combo_Destin_Gate.SelectedValue = consRow.OrgHubID.Trim() ;
                }
                txt_flightno.Text = consRow.FlightNo.ToString();
                txt_remarks.Text = consRow.Remarks.ToString();
                date_arrival.Value = consRow.AriDate;
                date_dep.Value = consRow.DepDate;

                if (textBox2.Text != "")
                {
                    dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                }
               
            }
            catch (Exception)
            {


            }
        }

       
    }
}
