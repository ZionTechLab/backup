using Express.Interfaces.Operations.Manifest;
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

namespace Express.UI.Operation.View
{

  
    public partial class AWBManual : Form
    {

        bool isNew = false;
        bool isCancel = false;
        bool isEdit = false;
        bool isFormLoad = false;
        bool isAWBKeyPress = false;


        private readonly IAWBManual _extProvider;
        private AgencyDomainViewcs oAgencyDomainViewcs = null;
        private List<AgencyDomainViewcs> agencyList = null;
        private List<CountryDomainView> CountryList = null;
        private List<CountryDomainView> ReceipientCountryList = null;
        private List<CityDomainView> CityList = null;
        private List<CityDomainView> ReceipientCityList = null;
        private List<PackageDomainView> PackageList = null;
        private List<ServiceDominView> ServiceList = null;
        private AWBDomainView AWBDomainView = null;
        private AgencyDomainViewcs agencyView = null;
        private ConsDomainView consView = null;
        private List<ConsDomainView> ConsList = null;
        private List<AWBDomainView> AWBList = null;
        private AWBDomainView AWBView = null;
        private AWBDomainView AWBViewMps = null;
        private AWBDomainView AWBViewDeleteMps = null;

        private CountryDomainView SenderCountryView = null;
        private CountryDomainView ReceiverCountryView = null;
        private CityDomainView SenderCityView = null;
        private CityDomainView ReceipientCityView = null;

        private PackageDomainView PackageView = null;
        private ServiceDominView ServiceView = null;

        private List<AWBDomainView> AWBMPSList = null;

        private string Event = null;

        private List<MpsNoDel> AWBMpsDelList = new List<MpsNoDel>();

        private string CurrentMspNo = null;
        private int CurrentMspNoRowNo;

        private bool CellValidated = false;

        public AWBManual()
        {
            InitializeComponent();

            CellValidated = false;

            if (_extProvider == null)
            {
                _extProvider = OperationsUIFacotry.GetService<IAWBManual>();
            }
        }
        


        private void Clear()
        {
            txtConsNo.Text = "";
            dtpTrasactionDate.Value = DateTime.Now;
            txtOriginHub.Text = "";
            txtDestination.Text = "";
            txtMAWBNo.Text = "";
            cmbAgency.SelectedIndex = -1;
            txtAgencyCode.Text = "";
            txtCompany.Text = "";
            txtAWBNo.Text = "";
            txtExpressID.Text = "";
            txtSenderAccount.Text = "";
            txtSenderPhene.Text = "";
            txtSenderCountryCode.Text = "";
            //cmbSenderCountryName.set =null;

            try
            {
                cmbSenderCountryName.SelectedIndex = -1;
                chkSenderOneTime.Checked = true;
                chkRecepientOneTime.Checked = true;
                cmbRecepientCity.SelectedIndex = -1;
            }
            catch (Exception ex)
            {

              
            }

        
            //cmbSenderCountryName.Items.Clear();

            txtSenderCode.Text = "";
         
           // txtSenderOneTime.Text = "";
            txtSenderCompany.Text = "";
            txtSenderName.Text = "";
            txtSenderAdrress1.Text = "";
            txtSenderAdrress2.Text = "";
            txtSenderCityCode.Text = "";
            cmbSenderCity.Text = "";
            txtSenderSTPV.Text = "";
            txtSenderPostalZip.Text = "";
            txtRecepientAccount.Text = "";
            txtRecepientPhene.Text = "";
            txtRecepientCountryCode.Text = "";
            cmbRecepientCountry.Text = "";
            txtRecepientCode.Text = "";
        
           // txtRecepientOneTime.Text = "";
            txtRecepientCompany.Text = "";
            txtRecepientName.Text = "";
            txtRecepientAdrress1.Text = "";
            txtRecepientAdrress2.Text = "";
            txtRecepientCityCode.Text = "";
         
            txtRecepientSTPV.Text = "";
            txtRecepientPostalZip.Text = "";
            txtOrigCountry.Text = "";
            txtOrigCountry.Text = "";
            txtOriginLoc.Text = "";
            txtOrigin.Text = "";
            txtDestimation.Text = "";
            txtDestinLoc.Text = "";
            txtPackage.Text = "";
            dteShipDate.Value = DateTime.Now;
            txtServiceCode.Text = "";
            cmbService.Text = "";
            txtPackingCode.Text = "";
            cmbPacking.Text = "";
            txtTotWeight.Text = "";
            cmbTotWeight.Text = "";
            txtDimVol.Text = "";
            cmbDimVol.Text = "";
            txtCarriageVal.Text = "";
            txtCarriageValText.Text = "";
            txtCustomVal.Text = "";
            txtCustomValText.Text = "";
            txtDescription.Text = "";
            txtShipmentRef.Text = "";
            txtDepartment.Text = "";
            radDocs.Checked = false;
            radNdocs.Checked = false;
            chkHoldLocation.Checked = false;
            cmbBillTransport.SelectedText = "";
            cmbBillDuties.SelectedText = "";
            cmbBillTransport.SelectedText = "";
            txtTransportAccount.Text = "";
            cmbDimVol.SelectedText = "";
            txtBillDutiesAccount.Text = "";
            dteCommitmentDate.Value = DateTime.Now;
            dteComTime.Text = "";
            dgvMpsNo.DataSource = null;
            txtDestCountry.Text = "";


            txtAWBNo.Enabled = true;
            txtConsNo.Enabled = false;
            dtpTrasactionDate.Enabled = false;
            txtOriginHub.Enabled = false;
            txtDestination.Enabled = false;            
            cmbAgency.Enabled = false;
            txtAgencyCode.Enabled = false;
            txtCompany.Enabled = false;
            txtMAWBNo.Enabled = false;
            //txtExpressID.Enabled = false;
            txtSenderAccount.Enabled = false;
            txtSenderPhene.Enabled = false;
           // txtSenderCountryCode.Enabled = false;
            cmbSenderCountryName.Enabled = false;
            //txtSenderCode.Enabled = false;
            chkSenderOneTime.Enabled = false;
           // txtSenderOneTime.Enabled = false;
            txtSenderCompany.Enabled = false;
            txtSenderName.Enabled = false;
            txtSenderAdrress1.Enabled = false;
            txtSenderAdrress2.Enabled = false;
          //  txtSenderCityCode.Enabled = false;
            cmbSenderCity.Enabled = false;
            txtSenderSTPV.Enabled = false;
            txtSenderPostalZip.Enabled = false;
            txtRecepientAccount.Enabled = false;
            txtRecepientPhene.Enabled = false;
          //  txtRecepientCountryCode.Enabled = false;
            cmbRecepientCountry.Enabled = false;
           // txtRecepientCode.Enabled = false;
            chkRecepientOneTime.Enabled = false;
          //  txtRecepientOneTime.Enabled = false;
            txtRecepientCompany.Enabled = false;
            txtRecepientName.Enabled = false;
            txtRecepientAdrress1.Enabled = false;
            txtRecepientAdrress2.Enabled = false;
          //  txtRecepientCityCode.Enabled = false;
            cmbRecepientCity.Enabled = false;
            txtRecepientSTPV.Enabled = false;
            txtRecepientPostalZip.Enabled = false;
            txtOrigCountry.Enabled = false;
            txtOrigCountry.Enabled = false;
            txtOriginLoc.Enabled = false;
            txtOrigin.Enabled = false;
            txtDestimation.Enabled = false;
            txtDestinLoc.Enabled = false;
            txtPackage.Enabled = false;
            dteShipDate.Enabled = false;
          //  txtServiceCode.Enabled = false;
            cmbService.Enabled = false;
           // txtPackingCode.Enabled = false;
            cmbPacking.Enabled = false;
            txtTotWeight.Enabled = false;
            cmbTotWeight.Enabled = false;
            txtDimVol.Enabled = false;
            cmbDimVol.Enabled = false;
            txtCarriageVal.Enabled = false;
            txtCarriageValText.Enabled = false;
            txtCustomVal.Enabled = false;
            txtCustomValText.Enabled = false;
            txtDescription.Enabled = false;
            txtShipmentRef.Enabled = false;
            txtDepartment.Enabled = false;
            radDocs.Enabled = false;
            radNdocs.Enabled = false;
            chkHoldLocation.Enabled = false;
            cmbBillDuties.Enabled = false;
            txtTransportAccount.Enabled = false;
            cmbBillTransport.Enabled = false;
            cmbBillDuties.Enabled = false;
            txtBillDutiesAccount.Enabled = false;
            dteCommitmentDate.Enabled = false;
            dteComTime.Enabled = false;
            dgvMpsNo.Enabled = false;
            txtDestCountry.Enabled = false;

            try
            {
                if (dgvMpsNo.Rows.Count > 1)
                {
                    dgvMpsNo.Rows.Clear();
                }
            }
            catch (Exception ex)
            {

               
            }
          
         


            isNew = false;
            isCancel = true;
            isEdit = false;



        }




        private void New()
        {
            txtConsNo.Text = "";
            dtpTrasactionDate.Value = DateTime.Now;
            txtOriginHub.Text = "";
            txtDestination.Text = "";
            txtMAWBNo.Text = "";
            cmbAgency.Text = "";
            txtAgencyCode.Text = "";
            txtCompany.Text = "";
            txtAWBNo.Text = "";
            txtExpressID.Text = "";
            txtSenderAccount.Text = "";
            txtSenderPhene.Text = "";
            txtSenderCountryCode.Text = "";
            cmbSenderCountryName.Text = "";
            txtSenderCode.Text = "";
            chkSenderOneTime.Checked = true;
           // txtSenderOneTime.Text = "";
            txtSenderCompany.Text = "";
            txtSenderName.Text = "";
            txtSenderAdrress1.Text = "";
            txtSenderAdrress2.Text = "";
            txtSenderCityCode.Text = "";
            cmbSenderCity.Text = "";
            txtSenderSTPV.Text = "";
            txtSenderPostalZip.Text = "";
            txtRecepientAccount.Text = "";
            txtRecepientPhene.Text = "";
            txtRecepientCountryCode.Text = "";
            cmbRecepientCountry.Text = "";
            txtRecepientCode.Text = "";
            chkRecepientOneTime.Checked = true;
          //  txtRecepientOneTime.Text = "";
            txtRecepientCompany.Text = "";
            txtRecepientName.Text = "";
            txtRecepientAdrress1.Text = "";
            txtRecepientAdrress2.Text = "";
            txtRecepientCityCode.Text = "";
            cmbRecepientCity.Text = "";
            txtRecepientSTPV.Text = "";
            txtRecepientPostalZip.Text = "";
            txtOrigCountry.Text = "";
            txtOrigCountry.Text = "";
            txtOriginLoc.Text = "";
            txtOrigin.Text = "";
            txtDestimation.Text = "";
            txtDestinLoc.Text = "";
            txtPackage.Text = "";
            dteShipDate.Value = DateTime.Now;
            txtServiceCode.Text = "";
            cmbService.Text = "";
            txtPackingCode.Text = "";
            cmbPacking.Text = "";
            txtTotWeight.Text = "";
            cmbTotWeight.Text = "";
            txtDimVol.Text = "";
            cmbDimVol.Text = "";
            txtCarriageVal.Text = "";
            txtCarriageValText.Text = "";
            txtCustomVal.Text = "";
            txtCustomValText.Text = "";
            txtDescription.Text = "";
            txtShipmentRef.Text = "";
            txtDepartment.Text = "";         
            chkHoldLocation.Checked = false;
            cmbBillTransport.Text = "";
            cmbBillDuties.Text = "";
            txtTransportAccount.Text = "";
            cmbDimVol.SelectedText = "";
            txtBillDutiesAccount.Text = "";
            dteCommitmentDate.Value = DateTime.Now;
            dteComTime.Text = "";
            dgvMpsNo.DataSource = null;
            txtDestCountry.Text = "";



            txtConsNo.Enabled = true;
            dteCommitmentDate.Enabled = false;
            dtpTrasactionDate.Enabled = true;
            txtAWBNo.Enabled = false;
            cmbAgency.Enabled = true;
            txtOriginHub.Enabled = false;
            txtDestination.Enabled = false;                 
            txtCompany.Enabled = false;
            txtMAWBNo.Enabled = false;
          //  txtExpressID.Enabled = false;
            txtSenderAccount.Enabled = false;
            txtSenderPhene.Enabled = false;
           // txtSenderCountryCode.Enabled = false;
            cmbSenderCountryName.Enabled = false;
          //  txtSenderCode.Enabled = false;
            chkSenderOneTime.Enabled = false;
          //  txtSenderOneTime.Enabled = false;
            txtSenderCompany.Enabled = false;
            txtSenderName.Enabled = false;
            txtSenderAdrress1.Enabled = false;
            txtSenderAdrress2.Enabled = false;
           // txtSenderCityCode.Enabled = false;
            cmbSenderCity.Enabled = false;
            txtSenderSTPV.Enabled = false;
            txtSenderPostalZip.Enabled = false;
            txtRecepientAccount.Enabled = false;
            txtRecepientPhene.Enabled = false;
           // txtRecepientCountryCode.Enabled = false;
            cmbRecepientCountry.Enabled = false;
           // txtRecepientCode.Enabled = false;
            chkRecepientOneTime.Enabled = false;
           // txtRecepientOneTime.Enabled = false;
            txtRecepientCompany.Enabled = false;
            txtRecepientName.Enabled = false;
            txtRecepientAdrress1.Enabled = false;
            txtRecepientAdrress2.Enabled = false;
          //  txtRecepientCityCode.Enabled = false;
            cmbRecepientCity.Enabled = false;
            txtRecepientSTPV.Enabled = false;
            txtRecepientPostalZip.Enabled = false;
            txtOrigCountry.Enabled = false;
            txtOrigCountry.Enabled = false;
            txtOriginLoc.Enabled = false;
            txtOrigin.Enabled = false;
            txtDestimation.Enabled = false;
            txtDestinLoc.Enabled = false;
            txtPackage.Enabled = false;
            dteShipDate.Enabled = false;
          //  txtServiceCode.Enabled = false;
            cmbService.Enabled = false;
          //  txtPackingCode.Enabled = false;
            cmbPacking.Enabled = false;
            txtTotWeight.Enabled = false;
            cmbTotWeight.Enabled = false;
            txtDimVol.Enabled = false;
            cmbDimVol.Enabled = false;
            txtCarriageVal.Enabled = false;
            txtCarriageValText.Enabled = false;
            txtCustomVal.Enabled = false;
            txtCustomValText.Enabled = false;
            txtDescription.Enabled = false;
            txtShipmentRef.Enabled = false;
            txtDepartment.Enabled = false;
            radDocs.Enabled = false;
            radNdocs.Enabled = false;
            chkHoldLocation.Enabled = false;
            cmbBillTransport.Enabled = false;
            cmbBillDuties.Enabled = false;
            txtTransportAccount.Enabled = false;
            cmbDimVol.Enabled = false;
            txtBillDutiesAccount.Enabled = false;
            dteCommitmentDate.Enabled = false;
            dteComTime.Enabled = false;
            dgvMpsNo.Enabled = false;
            txtDestCountry.Enabled = false;
            radDocs.Checked = false;
            radNdocs.Checked = false;

            try
            {
                if (dgvMpsNo.Rows.Count > 1)
                {
                    dgvMpsNo.Rows.Clear();
                }
            }
            catch (Exception ex)
            {


            }



            isNew = true;
            isCancel = false;
            isEdit = false;

        }




        private void EnterNew()
        {
           
           
            txtExpressID.Text = "";
            txtSenderAccount.Text = "";
            txtSenderPhene.Text = "";
            txtSenderCountryCode.Text = "";
            cmbSenderCountryName.Text = "";
            txtSenderCode.Text = "";
            chkSenderOneTime.Checked = true;
         //   txtSenderOneTime.Text = "";
            txtSenderCompany.Text = "";
            txtSenderName.Text = "";
            txtSenderAdrress1.Text = "";
            txtSenderAdrress2.Text = "";
            txtSenderCityCode.Text = "";
            cmbSenderCity.Text = "";
            txtSenderSTPV.Text = "";
            txtSenderPostalZip.Text = "";
            txtRecepientAccount.Text = "";
            txtRecepientPhene.Text = "";
            txtRecepientCountryCode.Text = "";
            cmbRecepientCountry.Text = "";
            txtRecepientCode.Text = "";
            chkRecepientOneTime.Checked = true;
        //    txtRecepientOneTime.Text = "";
            txtRecepientCompany.Text = "";
            txtRecepientName.Text = "";
            txtRecepientAdrress1.Text = "";
            txtRecepientAdrress2.Text = "";
            txtRecepientCityCode.Text = "";
            cmbRecepientCity.SelectedIndex = -1;
            txtRecepientSTPV.Text = "";
            txtRecepientPostalZip.Text = "";
            txtOrigCountry.Text = "";
            txtOrigCountry.Text = "";
            txtOriginLoc.Text = "";
            txtOrigin.Text = "";
            txtDestimation.Text = "";
            txtDestinLoc.Text = "";
            txtPackage.Text = "";
            dteShipDate.Value = DateTime.Now;
            txtServiceCode.Text = "";
            cmbService.Text = "";
            txtPackingCode.Text = "";
            cmbPacking.Text = "";
            //txtTotWeight.Text = "";
            //cmbTotWeight.Text = "";
            //txtDimVol.Text = "";
            //cmbDimVol.Text = "";
            //txtCarriageVal.Text = "";
            //txtCarriageValText.Text = "";
            //txtCustomVal.Text = "";
            //txtCustomValText.Text = "";
            txtDescription.Text = "";
            txtShipmentRef.Text = "";
            txtDepartment.Text = "";
          
            chkHoldLocation.Checked = false;
            cmbBillTransport.SelectedText = "";
            cmbBillDuties.SelectedText = "";
            txtTransportAccount.Text = "";
            cmbBillDuties.SelectedText = "";
            txtBillDutiesAccount.Text = "";
            dteCommitmentDate.Value = DateTime.Now;
            dteComTime.Text = "";
            dgvMpsNo.DataSource = null;
            txtDestCountry.Text = "";
            
          //  txtExpressID.Enabled = true;
            txtSenderAccount.Enabled = true;
            txtSenderPhene.Enabled = true;
           // txtSenderCountryCode.Enabled = true;
            cmbSenderCountryName.Enabled = true;
           // txtSenderCode.Enabled = true;
            chkSenderOneTime.Enabled = true;
          //  txtSenderOneTime.Enabled = true;
            txtSenderCompany.Enabled = true;
            txtSenderName.Enabled = true;
            txtSenderAdrress1.Enabled = true;
            txtSenderAdrress2.Enabled = true;
          //  txtSenderCityCode.Enabled = true;
            cmbSenderCity.Enabled = true;
            txtSenderSTPV.Enabled = true;
            txtSenderPostalZip.Enabled = true;
            txtRecepientAccount.Enabled = true;
            txtRecepientPhene.Enabled = true;
           // txtRecepientCountryCode.Enabled = true;
            cmbRecepientCountry.Enabled = true;
           // txtRecepientCode.Enabled = true;
            chkRecepientOneTime.Enabled = true;
          //  txtRecepientOneTime.Enabled = true;
            txtRecepientCompany.Enabled = true;
            txtRecepientName.Enabled = true;
            txtRecepientAdrress1.Enabled = true;
            txtRecepientAdrress2.Enabled = true;
           // txtRecepientCityCode.Enabled = true;
            cmbRecepientCity.Enabled = true;
            txtRecepientSTPV.Enabled = true;
            txtRecepientPostalZip.Enabled = true;
            txtOrigCountry.Enabled = true;
            txtOrigCountry.Enabled = true;
            txtOriginLoc.Enabled = true;
            txtOrigin.Enabled = true;
            txtDestimation.Enabled = true;
            txtDestinLoc.Enabled = true;
            txtPackage.Enabled = true;
            dteShipDate.Enabled = true;
          //  txtServiceCode.Enabled = true;
            cmbService.Enabled = true;
           // txtPackingCode.Enabled = true;
            cmbPacking.Enabled = true;
            txtTotWeight.Enabled = true;
            cmbTotWeight.Enabled = true;
            txtDimVol.Enabled = true;
            cmbDimVol.Enabled = true;
            txtCarriageVal.Enabled = true;
            txtCarriageValText.Enabled = true;
            txtCustomVal.Enabled = true;
            txtCustomValText.Enabled = true;
            txtDescription.Enabled = true;
            txtShipmentRef.Enabled = true;
            txtDepartment.Enabled = true;
            radDocs.Enabled = true;
            radNdocs.Enabled = true;
            chkHoldLocation.Enabled = true;
            cmbBillTransport.Enabled = true;
            cmbBillDuties.Enabled = true;
            txtTransportAccount.Enabled = true;
            cmbDimVol.Enabled = true;
            txtBillDutiesAccount.Enabled = true;
            dteCommitmentDate.Enabled = true;
            dteComTime.Enabled = true;
            dgvMpsNo.Enabled = true;
            txtDestCountry.Enabled = true;


            isNew = true;
            isCancel = false;
            isEdit = false;

        }





        private void Edit()
        {
            

           // txtExpressID.Enabled = true;
            txtSenderAccount.Enabled = true;
            txtSenderPhene.Enabled = true;
          //  txtSenderCountryCode.Enabled = true;
            cmbSenderCountryName.Enabled = true;
           // txtSenderCode.Enabled = true;
            chkSenderOneTime.Enabled = true;
          //  txtSenderOneTime.Enabled = true;
            txtSenderCompany.Enabled = true;
            txtSenderName.Enabled = true;
            txtSenderAdrress1.Enabled = true;
            txtSenderAdrress2.Enabled = true;
          // txtSenderCityCode.Enabled = true;
            cmbSenderCity.Enabled = true;
            txtSenderSTPV.Enabled = true;
            txtSenderPostalZip.Enabled = true;
            txtRecepientAccount.Enabled = true;
            txtRecepientPhene.Enabled = true;
          //  txtRecepientCountryCode.Enabled = true;
            cmbRecepientCountry.Enabled = true;
          //  txtRecepientCode.Enabled = true;
            chkRecepientOneTime.Enabled = true;
           // txtRecepientOneTime.Enabled = true;
            txtRecepientCompany.Enabled = true;
            txtRecepientName.Enabled = true;
            txtRecepientAdrress1.Enabled = true;
            txtRecepientAdrress2.Enabled = true;
          //  txtRecepientCityCode.Enabled = true;
            cmbRecepientCity.Enabled = true;
            txtRecepientSTPV.Enabled = true;
            txtRecepientPostalZip.Enabled = true;
            txtOrigCountry.Enabled = true;
            txtOrigCountry.Enabled = true;
            txtOriginLoc.Enabled = true;
            txtOrigin.Enabled = true;
            txtDestimation.Enabled = true;
            txtDestinLoc.Enabled = true;
            txtPackage.Enabled = true;
            dteShipDate.Enabled = true;
          //  txtServiceCode.Enabled = true;
            cmbService.Enabled = true;
          //  txtPackingCode.Enabled = true;
            cmbPacking.Enabled = true;
            txtTotWeight.Enabled = true;
            cmbTotWeight.Enabled = true;
            txtDimVol.Enabled = true;
            cmbDimVol.Enabled = true;
            txtCarriageVal.Enabled = true;
            txtCarriageValText.Enabled = true;
            txtCustomVal.Enabled = true;
            txtCustomValText.Enabled = true;
            txtDescription.Enabled = true;
            txtShipmentRef.Enabled = true;
            txtDepartment.Enabled = true;
            radDocs.Enabled = true;
            radNdocs.Enabled = true;
            chkHoldLocation.Enabled = true;
            cmbBillDuties.Enabled = true;
            cmbBillTransport.Enabled = true;
            txtTransportAccount.Enabled = true;
            cmbBillDuties.Enabled = true;
            txtBillDutiesAccount.Enabled = true;
            dteCommitmentDate.Enabled = true;
            dteComTime.Enabled = true;
            dgvMpsNo.Enabled = true;
            txtDestCountry.Enabled = true;


            isNew = false;
            isCancel = false;
            isEdit = true;

        }

        

        private void AWBManual_Load(object sender, EventArgs e)
        {
            try
            {
                agencyList = _extProvider.GetAgencyDetail(1, 200, 1002).ToList<AgencyDomainViewcs>();
                cmbAgency.DataSource = agencyList;


                btnCancel.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
                btnNew.Enabled = true;
                btnClose.Enabled = true;

                isFormLoad = true;


                cmbAgency.SelectedIndex = -1;

                CountryList = _extProvider.GetCountryList("").ToList();
                cmbSenderCountryName.DataSource = CountryList;

                ReceipientCountryList = _extProvider.GetCountryList("").ToList();
                cmbRecepientCountry.DataSource = ReceipientCountryList; 

                //cmbTotWeight.Items.Add("Kg");
                //cmbDimVol.Items.Add("Kg");

                cmbTotWeight.DataSource = _extProvider.GetUOMist("");

                cmbTotWeight.ValueMember = "Code";
                cmbTotWeight.DisplayMember = "Name";

                cmbDimVol.DataSource = _extProvider.GetDimVolUOMist("");

                cmbDimVol.ValueMember = "Code";
                cmbDimVol.DisplayMember = "Name";

                cmbBillTransport.DataSource = _extProvider.BillChgTo("");

                cmbBillTransport.ValueMember = "Code";
                cmbBillTransport.DisplayMember = "Name";

                cmbBillTransport.SelectedValue = "S";


                cmbBillDuties.DataSource = _extProvider.BillChgTo("");

                cmbBillDuties.ValueMember = "Code";
                cmbBillDuties.DisplayMember = "Name";

                cmbBillDuties.SelectedValue = "S";

                cmbBillDuties.SelectedIndex = -1;
                cmbBillTransport.SelectedIndex = -1;

             

                //cmbBillTransport.Items.Add("Shipper");
                //cmbBillTransport.Items.Add("Consignee");
                //cmbBillTransport.Items.Add("Other");

                //cmbBillDuties.Items.Add("Shipper");
                //cmbBillDuties.Items.Add("Consignee");
                //cmbBillDuties.Items.Add("Other");



                //cmbSenderCountryName.SelectedIndex = -1;
                //dteComTime



                Clear();
            }
            catch (Exception ex)
            {

              
            }
         
          
          
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Event = "I";
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            New();
            btnNew.Enabled = false;
            txtConsNo.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            var dt = _extProvider.GetAWBBilledList(txtAWBNo.Text);


            if (dt.ToList().Count > 0)
            {
                MessageBox.Show("You cannot delete this AWB. This is already billed.");
                return;
            }


            DialogResult dr = MessageBox.Show("You are going to cancel the AWB. Do you wish to continue?", "Cancel", MessageBoxButtons.YesNo,
            MessageBoxIcon.Information);

            if (dr == DialogResult.No)
            {
                return;
            }






            Clear();
            txtAWBNo.Focus();

            btnCancel.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnNew.Enabled = true;
            btnClose.Enabled = true;

            


        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("You are going to close the AWB. Do you wish to continue?", "Delete", MessageBoxButtons.YesNo,
           MessageBoxIcon.Information);

            if (dr == DialogResult.No)
            {
                return;
            }


            this.Close();
        }
        
        private void txtAWBNo_Leave(object sender, EventArgs e)
        {

            isFormLoad = false;
            CellValidated = false;
            AWBMpsDelList.Clear();
            try
            {
                string actCntrName = ActiveControl.Name;

              
                if (isAWBKeyPress)
                {
                    AWBLeave();
                    isAWBKeyPress = false;
                }
                else if (actCntrName == "btnNew")
                {

                    btnNew_Click(e, e);
                    return;
                }
                else if (actCntrName == "btnClose")
                {

                    btnClose_Click(e, e);
                    return;
                }
                else if (actCntrName == "btnCancel")
                {
                    btnCancel_Click(e, e);
                    return;
                }
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);

               
            }

           

           


        }

        private void txtConsNo_Leave(object sender, EventArgs e)
        {
            string actCntrName = ActiveControl.Name;

            isFormLoad = false;

            if (actCntrName == "btnCancel" || actCntrName == "btnClose")
            {
                return;
            }
            ConsLeave();           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Event = "E";

            Edit();

            btnSave.Enabled = true;
            txtAWBNo.Enabled = false;
        }



        private void SenderOneTime()
        {
            if (chkSenderOneTime.Checked)
            {
              //  txtSenderOneTime.Enabled = true;
                txtSenderCompany.Enabled = true;
                txtSenderName.Enabled = true;
                txtSenderAdrress1.Enabled = true;
                txtSenderAdrress2.Enabled = true;
              //  txtSenderCityCode.Enabled = true;
                cmbSenderCity.Enabled = true;
                txtSenderSTPV.Enabled = true;
                txtSenderPostalZip.Enabled = true;
            }else
            {
               // txtSenderOneTime.Enabled = false;
                txtSenderCompany.Enabled = false;
                txtSenderName.Enabled = false;
                txtSenderAdrress1.Enabled = false;
                txtSenderAdrress2.Enabled = false;
              //  txtSenderCityCode.Enabled = false;
                cmbSenderCity.Enabled = false;
                txtSenderSTPV.Enabled = false;
                txtSenderPostalZip.Enabled = false;
            }
           
          
        }



        private void ReceipientOneTime()
        {
            if (chkRecepientOneTime.Checked)
            {
              //  txtRecepientOneTime.Enabled = true;
                txtRecepientCompany.Enabled = true;
                txtRecepientName.Enabled = true;
                txtRecepientAdrress1.Enabled = true;
                txtRecepientAdrress2.Enabled = true;
              //  txtRecepientCityCode.Enabled = true;
                cmbRecepientCity.Enabled = true;
                txtRecepientSTPV.Enabled = true;
                txtRecepientPostalZip.Enabled = true;
            }else
            {
               // txtRecepientOneTime.Enabled = false; 
                txtRecepientCompany.Enabled = false;
                txtRecepientName.Enabled = false;
                txtRecepientAdrress1.Enabled = false;
                txtRecepientAdrress2.Enabled = false;
               // txtRecepientCityCode.Enabled = false;
                cmbRecepientCity.Enabled = false;
                txtRecepientSTPV.Enabled = false;
                txtRecepientPostalZip.Enabled = false;
            }
        }

        private void chkSenderOneTime_CheckedChanged(object sender, EventArgs e)
        {
            SenderOneTime();
        }

        private void chkRecepientOneTime_CheckedChanged(object sender, EventArgs e)
        {
            ReceipientOneTime();
        }

        private void cmbAgency_SelectedValueChanged(object sender, EventArgs e)
        {
            AgencyDomainViewcs DV = (AgencyDomainViewcs)cmbAgency.SelectedItem;

            if(DV != null)
            {
                txtAgencyCode.Text = DV.AgncyName;
                txtCompany.Text = DV.CompName;            
            }
        }

        private void cmbSenderCountryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            CityList = _extProvider.GetCityList(cmbSenderCountryName.SelectedValue.ToString(),"").ToList();
            cmbSenderCity.DataSource = CityList;
            cmbSenderCity.SelectedIndex = -1;

            SenderCountryView = _extProvider.GetCountryList(cmbSenderCountryName.SelectedValue.ToString()).FirstOrDefault();

            txtSenderCountryCode.Text = SenderCountryView.CountryCode;

            txtSenderCityCode.Text = "";

            cmbSenderCity.Text = "";


        }

  

        private void cmbRecepientCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReceipientCityList = _extProvider.GetCityList(cmbRecepientCountry.SelectedValue.ToString(),"").ToList();
            cmbRecepientCity.DataSource = ReceipientCityList;
            cmbRecepientCity.SelectedIndex = -1;

            ReceiverCountryView = _extProvider.GetCountryList(cmbRecepientCountry.SelectedValue.ToString()).FirstOrDefault();

            txtRecepientCountryCode.Text = ReceiverCountryView.CountryCode;

            txtRecepientCityCode.Text = "";

            cmbRecepientCity.Text = "";
        }

        private void cmbAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (agencyList.Count > 0 && cmbAgency.SelectedValue != null)
            {
                cmbTotWeight.SelectedText = "";
                cmbDimVol.SelectedText = "";
                cmbBillTransport.SelectedText = "";
                cmbBillDuties.SelectedText = "";

                PackageList = _extProvider.GetPackageList(cmbAgency.SelectedValue.ToString(),"").ToList();

                ServiceList = _extProvider.GetServiceList(cmbAgency.SelectedValue.ToString(),"").ToList();
                cmbPacking.DataSource = PackageList;
                cmbPacking.SelectedIndex = -1;

                cmbService.DataSource = ServiceList;
                cmbService.SelectedIndex = -1;

                agencyView = getAgegencyByCode(cmbAgency.SelectedValue.ToString());

                //agencyView = (from Ag in agencyList
                //                  where Ag.AgncyCode == int.Parse(cmbAgency.SelectedValue.ToString())
                //                  select new AgencyDomainViewcs
                //                    {
                //                        AgncyCode = Ag.AgncyCode,
                //                        AgncyName = Ag.AgncyName,
                //                        CompID = Ag.CompID,
                //                        CompName = Ag.CompName,
                //                        GroupID = Ag.GroupID,
                //                        MenuCode = Ag.MenuCode,
                //                        ModuleID = Ag.ModuleID,
                //                        UsmId = Ag.UsmId,
                //                        CountryCode = Ag.CountryCode,
                //                        AgncyID = Ag.AgncyID,
                //                        DefaultY = Ag.DefaultY,
                //                    }).ToList().FirstOrDefault();

                txtServiceCode.Text = "";
                txtPackingCode.Text = "";

                txtTotWeight.Text = "0";
                txtCarriageVal.Text = "0";
                txtDimVol.Text = "0";
                txtCustomVal.Text = "0";
                txtCarriageValText.Text = "USD";
                txtCustomValText.Text = "USD";

               

                cmbTotWeight.SelectedValue = "K";
                cmbDimVol.SelectedValue = "M3";

            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

          

            try
            {
                string s = "";
                if (isNew)
                {
                     s = Save(0, "", false, "");

                    if (dgvMpsNo.Rows.Count > 0 && s.Length > 0)
                    {
                        for (int i = 0; i < dgvMpsNo.Rows.Count - 1; i++)
                        {

                          s=  Save(int.Parse(dgvMpsNo.Rows[i].Cells[1].Value.ToString()), dgvMpsNo.Rows[i].Cells[0].Value.ToString(), false, s);
                        }
                    }
                }
                else
                {

                    if (isEdit)
                    {
                        foreach (var item in AWBMpsDelList)
                        {
                            DeleteMps(item.MpsNo);
                        }
                    }


                    s = Save(0, "", false, txtExpressID.Text);

                    if (dgvMpsNo.Rows.Count > 0 && s.Length > 0)
                    {
                        for (int i = 0; i < dgvMpsNo.Rows.Count - 1; i++)
                        {

                          s=  Save(int.Parse(dgvMpsNo.Rows[i].Cells[1].Value.ToString()), dgvMpsNo.Rows[i].Cells[0].Value.ToString(), dgvMpsNo.Rows[i].Cells[2].Value == null ? false : bool.Parse(dgvMpsNo.Rows[i].Cells[2].Value.ToString()), txtExpressID.Text);
                        }
                    }

                    AWBMpsDelList.Clear();
                    CellValidated = false;
                }
                if(s.Length > 0)
                {
                    MessageBox.Show("Saved Successful");

                }
               

              
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
             
          
            
              
           
        }


        private AgencyDomainViewcs getAgegencyByCode(string strAgencyCode)
        {
            return (from Ag in agencyList
                          where Ag.AgncyCode == int.Parse(strAgencyCode)
                          select new AgencyDomainViewcs
                          {
                              AgncyCode = Ag.AgncyCode,
                              AgncyName = Ag.AgncyName,
                              CompID = Ag.CompID,
                              CompName = Ag.CompName,
                              GroupID = Ag.GroupID,
                              MenuCode = Ag.MenuCode,
                              ModuleID = Ag.ModuleID,
                              UsmId = Ag.UsmId,
                              CountryCode = Ag.CountryCode,
                              AgncyID = Ag.AgncyID,
                              DefaultY = Ag.DefaultY,
                          }).ToList().FirstOrDefault();
        }

        private void dgvMpsNo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvMpsNo.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

            
        private string Save(int MpsNo,string MpsAgnNo,bool deleted,string ExpressID)
        {
            string Message = "";

         

            if (txtConsNo.Text == "")
            {
                MessageBox.Show("Cons number is empty");
                txtConsNo.Focus();

            }
            else if (txtAWBNo.Text == "")
            {
                MessageBox.Show("AWB number is empty");
                txtAWBNo.Focus();

            }
            else if (cmbAgency.SelectedValue == null || cmbAgency.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Agency cannot be empty");
                cmbAgency.Focus();

            }
            else if (txtAWBNo.Text == null || txtAWBNo.Text == "")
            {
                MessageBox.Show("AWB No. cannot be empty");
                txtAWBNo.Focus();

            }

            else if (cmbSenderCountryName.SelectedValue == null || cmbSenderCountryName.SelectedValue.ToString() == "" || cmbSenderCountryName.Text == "")
            {
                MessageBox.Show("Sender country cannot be empty");
                cmbSenderCountryName.Focus();
            }

            else if (txtSenderCompany.Text == null || txtSenderCompany.Text == "")
            {
                MessageBox.Show("Sender company cannot be empty");
                txtSenderCompany.Focus();
            }

            else if (cmbSenderCity.Text == "")
            {
                MessageBox.Show("Sender city cannot be empty");
                cmbSenderCity.Focus();
            }

            else if (cmbRecepientCountry.SelectedValue == null || cmbRecepientCountry.SelectedValue.ToString() == "" || cmbRecepientCountry.Text == "")
            {
                MessageBox.Show("Receipient country cannot be empty");
                cmbRecepientCountry.Focus();
            }

            else if (txtRecepientCompany.Text == null || txtRecepientCompany.Text == "")
            {
                MessageBox.Show("Recepient company cannot be empty");
                txtRecepientCompany.Focus();
            }


            //else if (txtRecepientName.Text == null || txtRecepientName.Text == "")
            //{
            //    MessageBox.Show("Recepient Name cannot be empty");
            //    txtRecepientName.Focus();
            //}


            else if (txtRecepientAdrress1.Text == null || txtRecepientAdrress1.Text == "")
            {
                MessageBox.Show("Recepient Address 1 cannot be empty");
                txtRecepientAdrress1.Focus();
            }

            
            else if (cmbRecepientCity.Text == "")
            {
                MessageBox.Show("Recepient city cannot be empty");
                cmbRecepientCity.Focus();
            }

            else if (txtOrigCountry.Text == null || txtOrigCountry.Text == "")
            {
                MessageBox.Show("Origin country cannot be empty");
                txtOrigCountry.Focus();
            }
            else if (txtOrigCountry.Text.Length > 0 && !CheckCountryExists(txtOrigCountry.Text))
            {
                MessageBox.Show("Origin country is invalid");
                txtOrigCountry.Focus();
            }
            else if (txtDestCountry.Text == null || txtDestCountry.Text == "")
            {
                MessageBox.Show("Destination country cannot be empty");
                txtDestCountry.Focus();
            }           
            else if (txtDestCountry.Text.Length > 0 && !CheckCountryExists(txtDestCountry.Text))
            {
                MessageBox.Show("Destination country is invalid");
                txtDestCountry.Focus();
            }
            else if (txtOrigin.Text == null || txtOrigin.Text == "")
            {
                MessageBox.Show("Origin cannot be empty");
                txtOrigin.Focus();
            }
            else if (txtDestimation.Text == null || txtDestimation.Text == "")
            {
                MessageBox.Show("Destination cannot be empty");
                txtDestimation.Focus();
            }

            else if (cmbService.SelectedValue == null || cmbService.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Service code cannot be empty");
                cmbService.Focus();
            }
            else if (cmbPacking.SelectedValue == null || cmbPacking.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Package code cannot be empty");
                cmbPacking.Focus();
            }

             
            else if (txtTotWeight.Text == null || txtTotWeight.Text == "" || txtTotWeight.Text == "0" || txtTotWeight.Text == "0.000")
            {
                MessageBox.Show("Total weight cannot be empty");
                txtTotWeight.Focus();
            }

            else if (txtCustomVal.Text == null || txtCustomVal.Text == "" || txtCustomVal.Text == "0" || txtTotWeight.Text == "0.000")
            {
                MessageBox.Show("Custome Value cannot be empty");
                txtCustomVal.Focus();
            }

            else if (!radDocs.Checked && !radNdocs.Checked)
            {
                MessageBox.Show("Doc type cannot be empty");
                radDocs.Focus();
                radDocs.Checked = false;
            }
            
            else if (cmbBillTransport.SelectedValue == null || cmbBillTransport.SelectedValue.ToString() == "" || cmbBillTransport.Text == "")
            {
                MessageBox.Show("Billing transport charge cannot be empty");
                cmbBillTransport.Focus();
            }


            else if (cmbBillDuties.SelectedValue == null || cmbBillDuties.SelectedValue.ToString() == "" || cmbBillDuties.Text == "")
            {
                MessageBox.Show("Billing duties cannot be empty");
                cmbBillDuties.Focus();
            }
          



            else
            {

              

             

                AWBDomainView = new AWBDomainView();

                


                AWBDomainView.Deleted = deleted;
                AWBDomainView.GroupID = agencyView.GroupID;
                AWBDomainView.CMPY = agencyView.CompID;
                AWBDomainView.AgncyCode = agencyView.AgncyCode;
                AWBDomainView.AgncyID = agencyView.AgncyID;
                AWBDomainView.ORIGINGate = consView == null?"": consView.OrgHubID;
                AWBDomainView.DESTINGate = consView == null?"": consView.DesHubID;
                AWBDomainView.GateWayID = "";
                AWBDomainView.StationID = "";
                AWBDomainView.RouteID = "";
                AWBDomainView.ConsId = txtConsNo.Text;
                AWBDomainView.TransDate = dtpTrasactionDate.Value;
                AWBDomainView.ShipType = consView == null ? "T" : consView.ShipType;
                AWBDomainView.TransMode = consView == null ? "" : consView.TransMode;
                AWBDomainView.ExpressID = ExpressID;
                AWBDomainView.ExpressMpsNo =MpsNo;
                AWBDomainView.AgnAWBNo = txtAWBNo.Text;
                AWBDomainView.AgnMpsNo = MpsAgnNo;
                AWBDomainView.AgnTrackNo = txtAWBNo.Text;
                AWBDomainView.ORIGIN = txtOrigin.Text;
                AWBDomainView.DESTIN = txtDestimation.Text;
                AWBDomainView.ORGCOUNTRY = txtOrigCountry.Text;
                AWBDomainView.DESCOUNTRY = txtDestCountry.Text;
                AWBDomainView.ShipDate = dteShipDate.Value;
                AWBDomainView.ShipLocationType = txtShipmentRef.Text;
                AWBDomainView.SenAccount = txtSenderAccount.Text;
                AWBDomainView.SenPhone = txtSenderPhene.Text;
                AWBDomainView.SenCountry = txtSenderCountryCode.Text;
                AWBDomainView.SenCode = txtSenderCode.Text;
                AWBDomainView.SenCompany = txtSenderCompany.Text;
                AWBDomainView.SenID = "";
                AWBDomainView.SenName = txtSenderName.Text;
                AWBDomainView.SenAddr1 = txtSenderAdrress1.Text;
                AWBDomainView.SenAddr2 = txtSenderAdrress2.Text;
                AWBDomainView.SenCity = cmbSenderCity.SelectedValue == null? 0: SenderCityView == null?0: SenderCityView.CityCode; //cmbSenderCity.SelectedValue == null ? "" : int.Parse(cmbSenderCity.SelectedValue.ToString());
                AWBDomainView.SenCityN = cmbSenderCity.SelectedValue == null? cmbSenderCity.Text : SenderCityView == null ? cmbSenderCity.Text : SenderCityView.CityName;
                AWBDomainView.SenState = txtSenderSTPV.Text == null ? "" : txtSenderSTPV.Text;
                AWBDomainView.SenZip = txtSenderPostalZip.Text == null ? "" : txtSenderPostalZip.Text;
                AWBDomainView.DutyExcemptY = "";
                AWBDomainView.RecAccount = txtRecepientAccount.Text;
                AWBDomainView.RecPhone = txtRecepientPhene.Text;
                AWBDomainView.RecCountry = txtRecepientCountryCode.Text;
                AWBDomainView.RecCode = txtRecepientCode.Text;
                AWBDomainView.RecCompany = txtRecepientCompany.Text;
                AWBDomainView.RecName = txtRecepientName.Text;
                AWBDomainView.RecAddr1 = txtRecepientAdrress1.Text;
                AWBDomainView.RecAddr2 = txtRecepientAdrress2.Text;
                AWBDomainView.RecCity = cmbRecepientCity.SelectedValue == null?0: ReceipientCityView == null?0: ReceipientCityView.CityCode ; //cmbRecepientCity.SelectedValue == null ? 0 : int.Parse(cmbRecepientCity.SelectedValue.ToString());
                AWBDomainView.RecCityN = cmbRecepientCity.SelectedValue == null? cmbRecepientCity.Text : ReceipientCityView == null ? cmbRecepientCity.Text : ReceipientCityView.CityName;
                AWBDomainView.RecState = txtSenderSTPV.Text;
                AWBDomainView.RecZip = txtRecepientPostalZip.Text;
                AWBDomainView.ExpressCons = consView == null ? "" : consView.ExpressCons;

                try
                {
                    AWBDomainView.TotPkgs = int.Parse(txtPackage.Text);
                    
                }
                catch (Exception ex)
                {

                    AWBDomainView.TotPkgs =0;
                }
               
                AWBDomainView.PackType = PackageView == null ? "" : PackageView.PackageCode;
                AWBDomainView.SvcType = ServiceView == null ? "" : ServiceView.ServiceCode;


                try
                {
                    AWBDomainView.TotWgt = decimal.Parse(txtTotWeight.Text);
                }
                catch (Exception ex)
                {

                    AWBDomainView.TotWgt = 0;
                }
             



                AWBDomainView.WgtU = "K" ;
                AWBDomainView.DimVol = decimal.Parse(txtDimVol.Text);
                AWBDomainView.DimVolU = cmbDimVol.SelectedItem == null ? "" : cmbDimVol.SelectedItem.ToString();
                AWBDomainView.RexWgt = 0;
                AWBDomainView.RexWgtU = cmbTotWeight.SelectedValue.ToString();
                AWBDomainView.RexVol = 0;
                AWBDomainView.RexVolU = null;
                AWBDomainView.CarriageVal = decimal.Parse(txtCarriageVal.Text);
                AWBDomainView.CarriageValCur = txtCarriageValText.Text;
                AWBDomainView.CustomVal = decimal.Parse(txtCustomVal.Text);
                AWBDomainView.CustomValCur = txtCustomValText.Text;
                AWBDomainView.Descrip = txtDescription.Text;
                AWBDomainView.SenRefNotes = "";
                AWBDomainView.DocNdoc = radNdocs.Checked?"N":"D";
                AWBDomainView.HoldAtLoc = chkHoldLocation.Checked?"Y":"N";
                AWBDomainView.BillTransChg = cmbBillTransport.SelectedValue == null?"": cmbBillTransport.SelectedValue.ToString();
                AWBDomainView.BillTransAcNo = txtTransportAccount.Text;
                AWBDomainView.BillDtaxChg = cmbBillDuties.SelectedValue == null?"": cmbBillDuties.SelectedValue.ToString();
                AWBDomainView.BillDtaxAcNo = txtBillDutiesAccount.Text;
                AWBDomainView.IntComDate = DateTime.Now;
                AWBDomainView.IntComTime = TimeSpan.Zero;
                AWBDomainView.FinComDate = DateTime.Now;
                AWBDomainView.FinComTime = DateTime.Now;
                AWBDomainView.TrackClosedY = "";
                AWBDomainView.DeliverY = "";
                AWBDomainView.PodScanTypeS = "";
                AWBDomainView.LastScanTypeS = "";
                AWBDomainView.LastScanDate = DateTime.Now;
                AWBDomainView.PodYN = "";
                AWBDomainView.CustomsPkgVal = 0;
                AWBDomainView.CustomsCurr = "";
                AWBDomainView.ConvRate = 0;
                AWBDomainView.TotalDutyVal = 0;
                AWBDomainView.ShipValueType = "";
                AWBDomainView.ShipValueTypeCata = 0;

                AWBDomainView.DetainedY = "";
                AWBDomainView.MissRoute = "";
                AWBDomainView.ShoOvr = "";
                AWBDomainView.DutythreshLC = 0;
                AWBDomainView.ClearStatuesCode = 0;
                AWBDomainView.Remarks1 = "";
                AWBDomainView.BillOrgCode = 0;
                AWBDomainView.BillOrgName = "";
                AWBDomainView.BillOrgAddr1 = "";
                AWBDomainView.BillOrgAddr2 = "";
                AWBDomainView.BillOrgCity = "";
                AWBDomainView.BillDTaxCreditY = "";
                AWBDomainView.BillDTaxChgY = "";
                AWBDomainView.BillTransChgY = "";
                AWBDomainView.InvNoDTaxChg = 0;
                AWBDomainView.InvNoTransChg = 0;
                AWBDomainView.USM_LOGIN = "";
                AWBDomainView.USM_DATE = DateTime.Now;
                AWBDomainView.AlertEmail1 = "";
                AWBDomainView.AlertEmail2 = "";
                AWBDomainView.AlertSms1 = "";
                AWBDomainView.AlertSms2 = "";
                AWBDomainView.PickupY = "";
                AWBDomainView.PickScanTypeS = "";
                AWBDomainView.LatePkg = "";
                AWBDomainView.RWDL = "";
                AWBDomainView.BusDay14 = DateTime.Now;
                AWBDomainView.ScanGap = "";
                AWBDomainView.MisScan = "";
                AWBDomainView.slockcode = "";
                AWBDomainView.SpCode = "";
                AWBDomainView.DepNotes = "";
                AWBDomainView.Remarks = "";
                AWBDomainView.AlFreightChg = "";
                AWBDomainView.ScansAl = "";
                AWBDomainView.MHEPackType = "";
                AWBDomainView.Event = Event;

                AWBDomainView.ScansAll = "";


                var lis = _extProvider.GetLocationList(txtOrigCountry.Text, txtOrigin.Text);
                

                DialogResult dr = new DialogResult();

                if (lis.Count == 0 && AWBDomainView.ExpressMpsNo == 0)
                {
                    dr = MessageBox.Show("You have entered invalid origin. Do you wish to continue?", "Origin", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                }

                if (dr == DialogResult.No)
                {
                    txtOrigin.Focus();

                    return "";
                }



                var lisd = _extProvider.GetLocationList(txtDestCountry.Text, txtDestimation.Text);


                DialogResult drd = new DialogResult();

                if (lisd.Count == 0 && AWBDomainView.ExpressMpsNo == 0)
                {
                    drd = MessageBox.Show("You have entered invalid destination. Do you wish to continue?", "Destination", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                }

                if (drd == DialogResult.No)
                {
                    txtDestimation.Focus();
                    return "";
                }








              

                var s = _extProvider.SaveAWBD(AWBDomainView);

                

                if(s.StrMessage.Length > 0)
                {
                    txtExpressID.Text = s.StrMessage;

                    Message = s.StrMessage;

                    ClearForEdit();

                    //MessageBox.Show("Saved Successful");
                    btnSave.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = true;
                    btnNew.Enabled = true;
                    btnClose.Enabled = true;
                    btnCancel.Enabled = true;

                }else
                {
                    Message = "";
                  //  MessageBox.Show(s.StrMessage);                   
                }

               
            }

            return Message;
        }


        private void ConsLeave()
        {
            ConsList = _extProvider.GetConsoleList(1, 1, 1, txtConsNo.Text).ToList();        

        

            if (txtConsNo.Text == "0")
            {
                txtAWBNo.Enabled = true;
                return;               
            }
            else if (txtConsNo.Text == "")
            {
                MessageBox.Show("Cons Number is empty");
                txtAWBNo.Enabled = false;
                txtConsNo.Focus();
            }
            else if (ConsList.Count == 0)
            {
                MessageBox.Show("Invalid Cons Number");
                txtConsNo.Focus();
                txtAWBNo.Enabled = false;
                return;
            }
            else if (ConsList.Count > 0)
            {
                consView = ConsList.FirstOrDefault();

                dtpTrasactionDate.Value =  consView.TransDate;
                txtOriginHub.Text = consView.OrgHubID;
                txtMAWBNo.Text = consView.OrgHubID;
                cmbAgency.SelectedValue = consView.AgncyCode;
                txtDestination.Text = consView.DesHubID;

                agencyView = getAgegencyByCode(cmbAgency.SelectedValue.ToString());

                txtAgencyCode.Text = agencyView.AgncyID;
                txtCompany.Text = agencyView.CompName;
                txtAWBNo.Enabled = true;

            }


            //if (isNew)
            //{
            //    txtAWBNo.Enabled = true;
            //}
        }


        private void AWBLeave()
        {
            AWBList = _extProvider.GetAWBList(txtAWBNo.Text).ToList();

        

            string actCntrName = ActiveControl.Name;

          
             if (txtAWBNo.Text == "" || txtAWBNo.Text == null)
            {
                MessageBox.Show("AWB Number Is Blank");
                txtAWBNo.Focus();
                return;
            }
            else if (AWBList.Count == 0 && isNew == false)
            {
                MessageBox.Show("Invalid AWB Number");
                txtAWBNo.Focus();
                return;  
            }     
            else if (AWBList.Count > 0 && isNew == true)
            {
                MessageBox.Show("AWB Number Already Exists");
                txtAWBNo.Focus();
                return;           
            }
        
            else if (isNew)
            {
                EnterNew();
                return;
              
            }
           

            AWBView = AWBList.FirstOrDefault();
            ConsList = _extProvider.GetConsoleList(0, 0, 0, AWBView.ConsId).ToList();
            consView = ConsList.FirstOrDefault();

        

            if (AWBList.Count > 0)
            {
                txtConsNo.Text = AWBView.ConsId == null ? "" : AWBView.ConsId;
                dtpTrasactionDate.Value = (DateTime)AWBView.TransDate;
                txtOriginHub.Text = consView == null ? "" : consView.OrgHubID;
                txtDestination.Text = consView == null?"": consView.DesHubID;
                txtMAWBNo.Text = consView == null ? "" : consView.MAWBNo;

               

                if (consView != null)
                {
                    cmbAgency.SelectedValue = consView.AgncyCode;
                    txtAgencyCode.Text = AWBView.AgncyID;


                    txtCompany.Text = agencyView.CompName;
                }
                else
                {

                    agencyView = getAgegencyByCode(AWBView.AgncyCode.ToString());
                    cmbAgency.SelectedValue = agencyView.AgncyCode;
                    txtAgencyCode.Text = agencyView.AgncyID;


                    txtCompany.Text = agencyView.CompName;
                }


                AWBMPSList = _extProvider.GetAWBMPSList(AWBView.AgnAWBNo, AWBView.ConsId, AWBView.ExpressID).ToList();


                int i = 0;

                if(dgvMpsNo.Rows.Count == 1)
                {
                    foreach (var item in AWBMPSList)
                    {

                        if (item.AgnMpsNo.Length > 0)
                        {
                            dgvMpsNo.Rows.Add();



                            dgvMpsNo.Rows[i].Cells[0].Value = item.AgnMpsNo;
                            dgvMpsNo.Rows[i].Cells[1].Value = item.ExpressMpsNo;
                            dgvMpsNo.Rows[i].Cells[2].Value = false;
                            dgvMpsNo.Rows[i].Cells[0].ReadOnly = true;


                            i++;
                        }


                    }

                    //dgvMpsNo.BeginEdit(true);
                }
                

             

                txtAWBNo.Text = AWBView.AgnAWBNo == null ? "" : AWBView.AgnAWBNo;
                txtExpressID.Text = AWBView.ExpressID == null ? "" : AWBView.ExpressID;
                txtSenderAccount.Text = AWBView.SenAccount == null ? "" : AWBView.SenAccount;
                txtSenderPhene.Text = AWBView.SenPhone == null ? "" : AWBView.SenPhone;
                cmbSenderCountryName.SelectedValue = AWBView.SenCountry == null || AWBView.SenCountry.Trim() == "" ? "" : AWBView.SenCountry;
                txtSenderCountryCode.Text = AWBView.SenCountry == null ? "" : AWBView.SenCountry;
                txtSenderCode.Text = AWBView.SenCode == null ? "" : AWBView.SenCode;
                // txtSenderOneTime.Text = "";
                txtSenderCompany.Text = AWBView.SenCompany == null ? "" : AWBView.SenCompany;
                txtSenderName.Text = AWBView.SenName == null ? "" : AWBView.SenName;
                txtSenderAdrress1.Text = AWBView.SenAddr1 == null ? "" : AWBView.SenAddr1;
                txtSenderAdrress2.Text = AWBView.SenAddr2 == null ? "" : AWBView.SenAddr2;
                cmbSenderCity.SelectedValue = AWBView.SenCityCode == null ? "" : AWBView.SenCityCode;
                cmbSenderCity.Text = AWBView.SenCityN;

                txtSenderCityCode.Text = AWBView.SenCityCode == null ? "" : AWBView.SenCityCode; 

                txtSenderSTPV.Text = AWBView.SenState == null ? "" : AWBView.SenState;
                txtSenderPostalZip.Text = AWBView.SenZip == null ? "" : AWBView.SenZip;
                txtRecepientAccount.Text = AWBView.RecAccount == null ? "" : AWBView.RecAccount;
                txtRecepientPhene.Text = AWBView.RecPhone == null ? "" : AWBView.RecPhone;
                txtRecepientCountryCode.Text = AWBView.RecCountry == null ? "" : AWBView.RecCountry;             
                cmbRecepientCountry.Text = AWBView.RecCountry == null ? "" : AWBView.RecCountry;

                cmbRecepientCountry.SelectedValue = AWBView.RecCountry == null || AWBView.RecCountry.Trim() == "" ? "" : AWBView.RecCountry;


                txtRecepientCode.Text = AWBView.RecCode == null ? "" : AWBView.RecCode;
                //   txtRecepientOneTime.Text = "";
                txtRecepientCompany.Text = AWBView.RecCompany == null ? "" : AWBView.RecCompany;
                txtRecepientName.Text = AWBView.RecName == null ? "" : AWBView.RecName;
                txtRecepientAdrress1.Text = AWBView.RecAddr1 == null ? "" : AWBView.RecAddr1;
                txtRecepientAdrress2.Text = AWBView.RecAddr2 == null ? "" : AWBView.RecAddr2;
                txtRecepientCityCode.Text = AWBView.RecCityCode == null ? "" : AWBView.RecCityCode;
              
                cmbRecepientCity.SelectedValue = AWBView.RecCityCode == null ? "" : AWBView.RecCityCode;
                cmbRecepientCity.Text = AWBView.RecCityN;

                

                txtRecepientSTPV.Text = AWBView.RecState == null ? "" : AWBView.RecState;
                txtRecepientPostalZip.Text = AWBView.RecZip == null ? "" : AWBView.RecZip;
                txtOrigCountry.Text = AWBView.ORGCOUNTRY == null ? "" : AWBView.ORGCOUNTRY;
                txtOrigin.Text = AWBView.ORIGIN == null ? "" : AWBView.ORIGIN;
                txtDestCountry.Text = AWBView.DESCOUNTRY == null ? "" : AWBView.DESCOUNTRY;
                txtDestimation.Text = AWBView.DESTIN == null ? "" : AWBView.DESTIN;
                txtOriginLoc.Text = "";
                txtDestinLoc.Text = "";
                txtPackage.Text = AWBView.TotPkgs.ToString() == null ? "" : AWBView.TotPkgs.ToString();
                //if (AWBView.ShipDate.Year.ToString() != "1")
                //{
                    dteShipDate.Value = (DateTime)AWBView.ShipDate;
                //}
                txtServiceCode.Text = AWBView.SvcType == null ? "" : AWBView.SvcType; ;
                cmbService.SelectedValue = AWBView.SvcType == null ? "" : AWBView.SvcType;
                txtPackingCode.Text = AWBView.PackType == null ? "" : AWBView.PackType;
                cmbPacking.SelectedValue = AWBView.PackType == null ? "" : AWBView.PackType;
                txtTotWeight.Text = AWBView.TotWgt.ToString() == null ? "" : AWBView.TotWgt.ToString();
                cmbTotWeight.SelectedValue = "K";//AWBView.DimVolU == null ? "" : AWBView.DimVolU;
                txtDimVol.Text = AWBView.DimVol.ToString() == null ? "" : AWBView.DimVol.ToString();
                cmbDimVol.SelectedValue = "K";//AWBView.WgtU == null ? "" : AWBView.WgtU;
                txtCarriageVal.Text = AWBView.CarriageVal.ToString() == null ? "" : AWBView.CarriageVal.ToString();
                txtCarriageValText.Text = AWBView.CarriageValCur == null ? "" : AWBView.CarriageValCur;
                txtCustomVal.Text = AWBView.CustomVal.ToString() == null ? "" : AWBView.CustomVal.ToString();
                txtCustomValText.Text = AWBView.CustomValCur == null ? "" : AWBView.CustomValCur;
                txtDescription.Text = AWBView.Descrip == null ? "" : AWBView.Descrip;
                txtShipmentRef.Text = AWBView.SenRefNotes == null ? "" : AWBView.SenRefNotes;
                txtDepartment.Text = "";
                radDocs.Checked = AWBView.DocNdoc == "D" ? true : false;
                radNdocs.Checked = AWBView.DocNdoc == "N" ? true : false;
                chkHoldLocation.Checked = AWBView.HoldAtLoc == "N" ? false : true;
                cmbBillTransport.SelectedValue = AWBView.BillTransChg == null ? "" : AWBView.BillTransChg;
                txtTransportAccount.Text = AWBView.BillTransAcNo == null ? "" : AWBView.BillTransAcNo;
                cmbBillDuties.SelectedValue = AWBView.BillDtaxChg == null ? "" : AWBView.BillDtaxChg;
                txtBillDutiesAccount.Text = AWBView.BillDtaxAcNo == null ? "" : AWBView.BillDtaxAcNo;
                dteCommitmentDate.Value = (DateTime)AWBView.IntComDate;
                dteComTime.Text = AWBView.IntComTime.ToString();


            }

            btnEdit.Enabled = true;
            btnDelete.Enabled = true;

            btnCancel.Enabled = true;
        }

        private void txtAWBNo_TextChanged(object sender, EventArgs e)
        {
            //if(isFormLoad && txtAWBNo.Text.Length > 0)
            //{
            //    isFormLoad = false;
            //}else
            //{
            //    isFormLoad = true;
            //}

        }

        private void txtAWBNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                isAWBKeyPress = true;


            }else
            {
                isAWBKeyPress = false;

            }

        }

        private void txtAWBNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                isFormLoad = false;
                try
                {
                    string actCntrName = ActiveControl.Name;


                    if (isAWBKeyPress)
                    {
                        AWBLeave();
                        isAWBKeyPress = false;
                    }
                    else if (actCntrName == "btnNew")
                    {

                        btnNew_Click(e, e);
                        return;
                    }
                    else if (actCntrName == "btnClose")
                    {

                        btnClose_Click(e, e);
                        return;
                    }
                    else if (actCntrName == "btnCancel")
                    {
                        btnCancel_Click(e, e);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);


                }
            }
        }

        private void NewAwbFile()
        {
            Event = "I";
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            New();
            btnNew.Enabled = false;
            txtConsNo.Focus();
        }


        private void CancelAwbFile()
        {

            btnCancel.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnNew.Enabled = true;
            btnClose.Enabled = true;



            Clear();

            txtAWBNo.Focus();
        }

        private void cmbSenderCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            SenderCityView = _extProvider.GetCityList(cmbSenderCountryName.SelectedValue.ToString(), cmbSenderCity.SelectedValue == null?"": cmbSenderCity.SelectedValue.ToString()).FirstOrDefault();

            txtSenderCityCode.Text = SenderCityView.CityID;
        }

        private void cmbRecepientCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ReceipientCityView = _extProvider.GetCityList(cmbSenderCountryName.SelectedValue.ToString(), cmbSenderCity.SelectedValue == null ? "" : cmbSenderCity.SelectedValue.ToString()).FirstOrDefault();

                txtRecepientCityCode.Text = ReceipientCityView.CityID;


            }
            catch (Exception)
            {

            }

        
        }

        private void cmbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAgency.SelectedValue == null && !isFormLoad)
            {
                MessageBox.Show("Agency is not selected");
            }
            else
            {

                ServiceView = _extProvider.GetServiceList(cmbAgency.SelectedValue.ToString(), cmbService.SelectedValue == null ? "" : cmbService.SelectedValue.ToString()).FirstOrDefault();

                txtServiceCode.Text = ServiceView.ServiceCode;

            }
        }

        private void cmbPacking_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAgency.SelectedValue == null && !isFormLoad)
            {
                MessageBox.Show("Agency is not selected");
            }
            else

            {

                PackageView = _extProvider.GetPackageList(cmbAgency.SelectedValue.ToString(), cmbPacking.SelectedValue == null ? "" : cmbPacking.SelectedValue.ToString()).FirstOrDefault();

                txtPackingCode.Text = PackageView.PackageCode;

            }
        }





        private void ClearForEdit()
        {
            


            txtAWBNo.Enabled = true;
            txtConsNo.Enabled = false;
            dtpTrasactionDate.Enabled = false;
            txtOriginHub.Enabled = false;
            txtDestination.Enabled = false;
            cmbAgency.Enabled = false;
            txtAgencyCode.Enabled = false;
            txtCompany.Enabled = false;
            txtMAWBNo.Enabled = false;
            //txtExpressID.Enabled = false;
            txtSenderAccount.Enabled = false;
            txtSenderPhene.Enabled = false;
            // txtSenderCountryCode.Enabled = false;
            cmbSenderCountryName.Enabled = false;
            //txtSenderCode.Enabled = false;
            chkSenderOneTime.Enabled = false;
            // txtSenderOneTime.Enabled = false;
            txtSenderCompany.Enabled = false;
            txtSenderName.Enabled = false;
            txtSenderAdrress1.Enabled = false;
            txtSenderAdrress2.Enabled = false;
            //  txtSenderCityCode.Enabled = false;
            cmbSenderCity.Enabled = false;
            txtSenderSTPV.Enabled = false;
            txtSenderPostalZip.Enabled = false;
            txtRecepientAccount.Enabled = false;
            txtRecepientPhene.Enabled = false;
            //  txtRecepientCountryCode.Enabled = false;
            cmbRecepientCountry.Enabled = false;
            // txtRecepientCode.Enabled = false;
            chkRecepientOneTime.Enabled = false;
            //  txtRecepientOneTime.Enabled = false;
            txtRecepientCompany.Enabled = false;
            txtRecepientName.Enabled = false;
            txtRecepientAdrress1.Enabled = false;
            txtRecepientAdrress2.Enabled = false;
            //  txtRecepientCityCode.Enabled = false;
            cmbRecepientCity.Enabled = false;
            txtRecepientSTPV.Enabled = false;
            txtRecepientPostalZip.Enabled = false;
            txtOrigCountry.Enabled = false;
            txtOrigCountry.Enabled = false;
            txtOriginLoc.Enabled = false;
            txtOrigin.Enabled = false;
            txtDestimation.Enabled = false;
            txtDestinLoc.Enabled = false;
            txtPackage.Enabled = false;
            dteShipDate.Enabled = false;
            //  txtServiceCode.Enabled = false;
            cmbService.Enabled = false;
            // txtPackingCode.Enabled = false;
            cmbPacking.Enabled = false;
            txtTotWeight.Enabled = false;
            cmbTotWeight.Enabled = false;
            txtDimVol.Enabled = false;
            cmbDimVol.Enabled = false;
            txtCarriageVal.Enabled = false;
            txtCarriageValText.Enabled = false;
            txtCustomVal.Enabled = false;
            txtCustomValText.Enabled = false;
            txtDescription.Enabled = false;
            txtShipmentRef.Enabled = false;
            txtDepartment.Enabled = false;
            radDocs.Enabled = false;
            radNdocs.Enabled = false;
            chkHoldLocation.Enabled = false;
            cmbBillDuties.Enabled = false;
            txtTransportAccount.Enabled = false;
            cmbBillTransport.Enabled = false;
            cmbBillDuties.Enabled = false;
            txtBillDutiesAccount.Enabled = false;
            dteCommitmentDate.Enabled = false;
            dteComTime.Enabled = false;
            dgvMpsNo.Enabled = true;
            txtDestCountry.Enabled = false;


            isNew = true;
            isCancel = true;
            isEdit = true;



        }
        
  
        private void dgvMpsNo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
             dgvMpsNo.Rows[dgvMpsNo.Rows.Count-2].Cells[1].Value = dgvMpsNo.Rows.Count-1;
            dgvMpsNo.Rows[dgvMpsNo.Rows.Count - 2].Cells[2].Value = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult dr = MessageBox.Show("You are going to delete the AWB. Do you wish to continue?", "Delete", MessageBoxButtons.YesNo,
           MessageBoxIcon.Information);

                if (dr == DialogResult.No)
                {
                    return;
                }else if(_extProvider.GetAWBBilledList(txtAWBNo.Text).ToList().Count > 0)
                {
                    MessageBox.Show("This is already billed.");

                    return;
                }


                AWBDomainView = new AWBDomainView();




                AWBDomainView.GroupID = agencyView.GroupID;
                AWBDomainView.CMPY = agencyView.CompID;
                AWBDomainView.AgncyCode = agencyView.AgncyCode;
                AWBDomainView.AgncyID = agencyView.AgncyID;
                AWBDomainView.ORIGINGate = consView == null ? "" : consView.OrgHubID;
                AWBDomainView.DESTINGate = consView == null ? "" : consView.DesHubID;
                AWBDomainView.GateWayID = "";
                AWBDomainView.StationID = "";
                AWBDomainView.RouteID = "";
                AWBDomainView.ConsId = txtConsNo.Text;
                AWBDomainView.TransDate = dtpTrasactionDate.Value;
                AWBDomainView.ShipType = consView == null ? "" : consView.ShipType;
                AWBDomainView.TransMode = consView == null ? "" : consView.TransMode;
                AWBDomainView.ExpressID = txtExpressID.Text;
                AWBDomainView.ExpressMpsNo = 0;
                AWBDomainView.AgnAWBNo = txtAWBNo.Text;
                AWBDomainView.AgnMpsNo = "";


                var s = _extProvider.DeleteAWBD(AWBDomainView);


                //if (isEdit)
                //{



                    for (int i = 0; i < dgvMpsNo.Rows.Count - 1; i++)
                    {
                        DeleteMps(dgvMpsNo.Rows[i].Cells[0].Value.ToString());
                    }

                    //foreach (var item in dgvMpsNo.Rows)
                    //{
                    //    DeleteMps(item.c);
                    //    i++;
                    //}
                //}





                Clear();


                btnCancel.Enabled = false;
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
                btnNew.Enabled = true;
                btnClose.Enabled = true;

                txtAWBNo.Focus();
            }
            catch (Exception ex)
            {

               
            }

           

        }

        private void dgvMpsNo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
         {

            try
            {
                MpsNoDel mps;

               // AWBMpsDelList = new List<MpsNoDel>();

                dgvMpsNo.Rows[dgvMpsNo.CurrentCell.RowIndex].Selected = true;


                //CurrentMspNo = dgvMpsNo.Rows[dgvMpsNo.CurrentCell.RowIndex].Cells[0].Value.ToString();

                //CurrentMspNoRowNo = dgvMpsNo.CurrentCell.RowIndex;

                //try
                //{
                //    if (dgvMpsNo.Rows.Count > 2)
                //    {
                //        for (int imps = 0; imps < dgvMpsNo.Rows.Count - 1; imps++)
                //        {
                //            if (dgvMpsNo.Rows[imps].Cells[0].Value.ToString().Trim() == CurrentMspNo)
                //            {                            


                //            }
                //        }
                //    }
                //}
                //catch (Exception)
                //{

                //    throw;
                //}

               // dgvMpsNo.Rows[dgvMpsNo.CurrentCell.RowIndex].Cells[0].ReadOnly = true;

                if ((bool)dgvMpsNo.Rows[dgvMpsNo.CurrentCell.RowIndex].Cells[2].Value == true)
                {

                    if (!CellValidated)
                    {
                        mps = new MpsNoDel();

                        mps.MpsNoExpressID = int.Parse(dgvMpsNo.Rows[dgvMpsNo.CurrentCell.RowIndex].Cells[1].Value.ToString());
                        mps.MpsNo = dgvMpsNo.Rows[dgvMpsNo.CurrentCell.RowIndex].Cells[0].Value.ToString();

                        AWBMpsDelList.Add(mps);
                      
                    }

                    dgvMpsNo.Rows.RemoveAt(dgvMpsNo.CurrentCell.RowIndex);
                }

                int i = 0;

                if(dgvMpsNo.Rows.Count > 0)
                {
                    foreach (var item in dgvMpsNo.Rows)
                    {
                        


                        dgvMpsNo.Rows[i].Cells[1].Value = i + 1;


                        i++;

                    }
                }

                CellValidated = false;


            }
            catch (Exception ex)
            {

               
            }


              
         
        }

   

      

        private void dgvMpsNo_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvMpsNo.EndEdit();
        }

        private void txtConsNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string actCntrName = ActiveControl.Name;

                isFormLoad = false;

                if (actCntrName == "btnCancel" || actCntrName == "btnClose")
                {
                    return;
                }
                ConsLeave();

                txtAWBNo.Focus();
            }
        }

        private void cmbRecepientCity_TextChanged(object sender, EventArgs e)
        {
            if(cmbRecepientCity.SelectedValue == null)
            {
                txtRecepientCityCode.Text = "";
             
            }
        }

        private void cmbSenderCity_TextChanged(object sender, EventArgs e)
        {
            if(cmbSenderCity.SelectedValue == null)
            {
                txtSenderCityCode.Text = "";
            }
        }

        private void txtTotWeight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal.Parse(txtTotWeight.Text);
            }
            catch (Exception)
            {

                txtTotWeight.Text = "0";
            }
           
        }

        private void txtDimVol_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal.Parse(txtDimVol.Text);
            }
            catch (Exception)
            {

                txtDimVol.Text = "0";
            }
        }

        private void txtCarriageVal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal.Parse(txtCarriageVal.Text);
            }
            catch (Exception)
            {

                txtCarriageVal.Text = "0";
            }
        }

        private void txtCustomVal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal.Parse(txtCustomVal.Text);
            }
            catch (Exception)
            {

                txtCustomVal.Text = "0";
            }
        }

        private void txtPackage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal.Parse(txtPackage.Text);
            }
            catch (Exception)
            {

                txtPackage.Text = "0";
            }
        }

        private void dgvMpsNo_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

           
        }

        private void dgvMpsNo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {


        }

        private void dgvMpsNo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {



           


        }

        private void dgvMpsNo_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dgvMpsNo_CellValidated(object sender, DataGridViewCellEventArgs e)
        {

            bool valueExists = false;

            if (e.ColumnIndex == 0 && dgvMpsNo.CurrentCell.Value != null)

            {

                foreach (DataGridViewRow row in this.dgvMpsNo.Rows)

                {

                    if (row.Index == this.dgvMpsNo.CurrentCell.RowIndex)

                    { continue; }

                    if (this.dgvMpsNo.CurrentCell.Value == null)

                    { continue; }

                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Trim() == dgvMpsNo.CurrentCell.Value.ToString().Trim())

                    {
                         MessageBox.Show("Mps No. already exists.");                   

                        valueExists = true;

                        CellValidated = true;

                        dgvMpsNo.Rows[dgvMpsNo.CurrentCell.RowIndex].Cells[2].Value = true;

                       

                    }

                }

            }

            if (valueExists)
            {
               // MessageBox.Show("Mps No. already exists.");
                valueExists = false;
                BeginInvoke(new MethodInvoker(RemoveRows));
                return;
               
            }

          






         




        }

        void RemoveRows() {

            try
            {


                int j = 0;
                foreach (var item in dgvMpsNo.Rows)
                {
                    if ((bool)dgvMpsNo.Rows[j].Cells[2].Value == true)
                    {

                        dgvMpsNo.Rows.RemoveAt(j);
                    }

                    j++;
                }

                int i = 0;

                if (dgvMpsNo.Rows.Count > 0)
                {
                    foreach (var item in dgvMpsNo.Rows)
                    {



                        dgvMpsNo.Rows[i].Cells[1].Value = i + 1;


                        i++;

                    }
                }
            }
            catch (Exception ex)
            {


            }
        }


        private void DeleteMps(string MpsNo)
        {
            try
            {
             

                AWBDomainView = new AWBDomainView();




                AWBDomainView.GroupID = agencyView.GroupID;
                AWBDomainView.CMPY = agencyView.CompID;
                AWBDomainView.AgncyCode = agencyView.AgncyCode;
                AWBDomainView.AgncyID = agencyView.AgncyID;
                AWBDomainView.ORIGINGate = consView == null ? "" : consView.OrgHubID;
                AWBDomainView.DESTINGate = consView == null ? "" : consView.DesHubID;
                AWBDomainView.GateWayID = "";
                AWBDomainView.StationID = "";
                AWBDomainView.RouteID = "";
                AWBDomainView.ConsId = txtConsNo.Text;
                AWBDomainView.TransDate = dtpTrasactionDate.Value;
                AWBDomainView.ShipType = consView == null ? "" : consView.ShipType;
                AWBDomainView.TransMode = consView == null ? "" : consView.TransMode;
                AWBDomainView.ExpressID = txtExpressID.Text;
                AWBDomainView.ExpressMpsNo = 0;
                AWBDomainView.AgnAWBNo = txtAWBNo.Text;
                AWBDomainView.AgnMpsNo = MpsNo;


                var s = _extProvider.DeleteAWBD(AWBDomainView);


                
            }
            catch (Exception ex)
            {


            }
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }
    

        private bool CheckCountryExists( string CntryName)
        {
            int numCount1 =
                (from num in CountryList
                 where num.CountryCode.ToUpper().Trim() == CntryName.ToUpper().Trim() 
                 select num).Count();


            if(numCount1 > 0)
            {
                return true;
            }

            return false;
        }
    }





    class MpsNoDel
    {
       public  int MpsNoExpressID { get; set; }
       public string MpsNo { get; set; }

    }

    
   

  
}
