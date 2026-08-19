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
    public partial class FreightProductMapping : Form, IDataManipulate
    {
        private readonly IFreightProductMapping<FreightProductMappingDomainView> _freightProductMapping;
        public readonly FreightProductMappingDomainView _freightProMappSave = new FreightProductMappingDomainView();

        //private LoginInfoView mENUCODE = null;
        //private List<LoginInfoView> mList = null;

        private bool initialLoad = true;
        private bool invoiceLoadCmb = true;
        private bool productLoadCmb = true;
        private bool svcTypeLoadCmb = true;
        private bool packTypeLoadCmb = true;


        private AgencyDomainViewcs oAgencyDomainViewcs = null;
        private List<AgencyDomainViewcs> agencyList = null;

        private ExpressCfgProductsMainDomainView productsMainDomainView = null;
        private List<ExpressCfgProductsMainDomainView> productMainList = null;

        private ExpressCfgProductsSubDomainView productsSubDomainView = null;
        private List<ExpressCfgProductsSubDomainView> productsSubList = null;

        private ExpressCfgSvcTypes cfgSvcTypeDomainView = null;
        private List<ExpressCfgSvcTypes> cfgSvcTypeList = null;

        private ExpressCfgPackTypes cfgPackTypeDomainView = null;
        private List<ExpressCfgPackTypes> cfgPackTypeList = null;

        private int agencyValue = 0;
        private string productMainCode = "";
        private string productSubCode = "";
        private string string_Doctype = "";
        private string radioButtonStatus = "";
        private decimal zeroWeight = 0;
        private int grdAgencyCode = 0;
        private string grdProductM = "";
        private string grdProductS = "";

        private string currentSvcType = "";
        private string currentPackType = "";
        private string currentDocNDoc = "";
        private string svcCode = "";
        private string packCode = "";

        private int editClick = 0;        

        public FormStateEnum FormState { get; private set; }
        public FreightProductMapping()
        {
            InitializeComponent();

            if (_freightProductMapping == null)
            {
                _freightProductMapping = OperationsUIFacotry.GetService<IFreightProductMapping<FreightProductMappingDomainView>>();
            }

            dataManipulate1.NewButtonClick += new EventHandler(NewMethod);
            dataManipulate1.SaveButtonClick += new EventHandler(SaveMethod);
            dataManipulate1.EditButtonClick += new EventHandler(EditMethod);
            dataManipulate1.CancelButtonClick += new EventHandler(ClearMethod);
          //  dataManipulate1.CloseButtonClick += new EventHandler(CloseForm);
           // dataManipulate1.DelteButtonClick += new EventHandler(DeleteMethod);
           // dataManipulate1.PreviewButtonClick += new EventHandler(previewMethod);

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.DISABLEENABBLE);

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CLOSE, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PRINT, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PROCESS, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.HIDEVISIBLE);

            cmbAgency.DisplayMember = "AgncyName";
            cmbAgency.ValueMember = "AgncyCode";

            cmbInvoiceType.DisplayMember = "ProductMN";
            cmbInvoiceType.ValueMember = "ProductM";

            cmbProduct.DisplayMember = "ProductSN";
            cmbProduct.ValueMember = "ProductS";

            cmbSvcType.DisplayMember = "SvcTypeN";
            cmbSvcType.ValueMember = "SvcType";

            cmbPackType.DisplayMember = "PackTypeN";
            cmbPackType.ValueMember = "PackType";

            txtRemarks.MaxLength = 50;
            cmbSvcType.MaxLength = 50;
            cmbSvcType.MaxLength = 50;
            txtWeight_From.MaxLength = 11;
            txtWeight_To.MaxLength = 11;
            
            cmbInvoiceType.Enabled = false;
            cmbProduct.Enabled = false;

            rdDoc.Checked = true;

            FieldDisable();
            AlwaysDisable();
            GridColumnDisable();
        }

        public void UpperFieldsEnable()
        {
            cmbAgency.Enabled = true;
            cmbInvoiceType.Enabled = true;
            cmbProduct.Enabled = true;            
        }

        public void UpperFieldsDisable()
        {
            cmbAgency.Enabled = false;
            cmbInvoiceType.Enabled = false;
            cmbProduct.Enabled = false;
        }
        public void NewBtnValidations()
        {
            if (txtAgencyCode.Text != "" && txtInvoiceTypeCode.Text != "" && txtProductCode.Text != "")
            {
                dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            }
        }

        public void AlwaysDisable()
        {
            txtAgencyCode.ReadOnly = true;
            txtInvoiceTypeCode.ReadOnly = true;
            txtProductCode.ReadOnly = true;
        }

        public void FieldDisable()
        {
            cmbSvcType.Enabled = false;
            cmbPackType.Enabled = false;
            txtWeight_From.ReadOnly = true;
            txtWeight_To.ReadOnly = true;
            txtRemarks.ReadOnly = true;

            rdDoc.Enabled = false;
            rdNonDoc.Enabled = false;
        }

        public void EnableField()
        {
            cmbSvcType.Enabled = true;
            cmbPackType.Enabled = true;
            txtWeight_From.ReadOnly = false;
            txtWeight_To.ReadOnly = false;
            txtRemarks.ReadOnly = false;

            rdDoc.Enabled = true;
            rdNonDoc.Enabled = true;
        }

        public void ClearFields()
        {
            txtAgencyCode.Text = "";
            cmbAgency.Text = "";
            txtInvoiceTypeCode.Text = "";
            cmbInvoiceType.Text = "";
            txtProductCode.Text = "";
            cmbProduct.Text = "";

            cmbSvcType.Text = "";
            cmbPackType.Text = "";
            txtWeight_From.Text = "";
            txtWeight_To.Text = "";
            txtRemarks.Text = "";

            rdDoc.Checked = true;
            rdNonDoc.Checked = false;
        }

        public void ClearFieldsOnError()
        {
            cmbSvcType.Text = "";
            cmbPackType.Text = "";
            txtWeight_From.Text = "";
            txtWeight_To.Text = "";
            txtRemarks.Text = "";

            rdDoc.Checked = true;
        }

        public void ShowGridView()
        {
            if (txtAgencyCode.Text != "" && txtInvoiceTypeCode.Text != "")
            {
                IList<FreightProductMappingDomainView> showGrid = _freightProductMapping.GetGridView(agencyValue, txtInvoiceTypeCode.Text.Trim(), txtProductCode.Text.Trim());
                grdFreightProductMappings.AutoGenerateColumns = false;
                grdFreightProductMappings.DataSource = showGrid;
            }           
        }

        public void GridColumnDisable()
        {
            //grdFreightProductMappings.Columns["SvcTypeN"].ReadOnly = true;
            //grdFreightProductMappings.Columns["PackTypeN"].ReadOnly = true;
            grdFreightProductMappings.Columns["DocNDoc"].ReadOnly = true;
            grdFreightProductMappings.Columns["WgtFrom"].ReadOnly = true;
            grdFreightProductMappings.Columns["WgtTo"].ReadOnly = true;
            grdFreightProductMappings.Columns["Remarks"].ReadOnly = true;
        }

        public void ClearMethod(object param, EventArgs e)
        {
            ClearFields();
            FieldDisable();
            UpperFieldsEnable();
            grdFreightProductMappings.DataSource = null;
            grdFreightProductMappings.Enabled = true;

            invoiceLoadCmb = true;
            productLoadCmb = true;

            cmbInvoiceType.Enabled = false;
            cmbProduct.Enabled = false;

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, false, ButtonCustomState.DISABLEENABBLE);
        }

        public void CloseForm(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void DeleteMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void EditMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.Update;

            grdFreightProductMappings.Enabled = false;

            editClick = 1;
            EnableField();
            UpperFieldsDisable();

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);

        }
            
        public void FilterMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ImportMethod(object param, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void NewMethod(object param, EventArgs e)
        {
            FormState = FormStateEnum.New;

            if (txtAgencyCode.Text != "" && txtInvoiceTypeCode.Text != "" && txtProductCode.Text != "")
            {
                EnableField();
                UpperFieldsDisable();

                cmbSvcType.Text = "";
                cmbPackType.Text = "";
                rdDoc.Checked = true;
                txtWeight_From.Text = "";
                txtWeight_To.Text = "";
                txtRemarks.Text = "";

                cmbSvcType.Enabled = true;
                cmbPackType.Enabled = true;
                rdDoc.Enabled = true;
                rdNonDoc.Enabled = true;
                txtWeight_From.ReadOnly = false;
                txtWeight_To.ReadOnly = false;
                txtRemarks.ReadOnly = false;

                grdFreightProductMappings.Enabled = false;

                dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            }
            else
            {
                MessageBox.Show("Please select Agency, Invoice Type and Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
           
            if (cmbSvcType.Text.Trim() != "" && cmbPackType.Text.Trim() != "" && rdDoc.Checked == true || rdNonDoc.Checked == true)
            {
                decimal weightFrom = 0;
                decimal weightTo = 0;

                if (txtWeight_From.Text != "" && txtWeight_To.Text.Equals(""))
                {
                    MessageBox.Show("Please enter a value for Weight To", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtWeight_From.Text.Equals("") && txtWeight_To.Text != "")
                {
                    MessageBox.Show("Please enter a value for Weight From", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }               
                else if (!decimal.TryParse(txtWeight_From.Text.Trim(),out weightFrom) && txtWeight_From.Text.Trim() != "" || !decimal.TryParse(txtWeight_To.Text.Trim(),out weightTo) && txtWeight_To.Text.Trim() != "")
                {
                   
                    txtWeight_From.Text = "";
                    txtWeight_To.Text = "";
                    MessageBox.Show("Please enter numeric value to weight fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);                    
                }                                                    
                else
                {
                  if (txtWeight_From.Text.Equals("") && txtWeight_To.Text.Equals(""))
                  {
                      _freightProMappSave.WgtFrom = weightFrom;
                      _freightProMappSave.WgtTo = weightTo;
                  }
                  else
                  {
                      _freightProMappSave.WgtFrom = weightFrom;   
                      _freightProMappSave.WgtTo = weightTo;   
                  }
                    if (_freightProMappSave.WgtFrom > _freightProMappSave.WgtTo)
                    {
                        txtWeight_From.Text = "";
                        txtWeight_To.Text = "";
                        MessageBox.Show("Enter a valid weight range", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        _freightProMappSave.AgncyCode = Convert.ToInt32(txtAgencyCode.Text);
                        _freightProMappSave.Doctype = string_Doctype.Trim();
                        _freightProMappSave.ProductM = txtInvoiceTypeCode.Text.Trim();
                        _freightProMappSave.ProductS = txtProductCode.Text.Trim();
                        _freightProMappSave.SvcType = svcCode;
                        _freightProMappSave.PackType = packCode;
                        _freightProMappSave.DocNDoc = radioButtonStatus.Trim();
                        //_freightProMappSave.WgtFrom = Convert.ToDecimal(txtWeight_From.Text.Trim());
                        //_freightProMappSave.WgtTo = Convert.ToDecimal(txtWeight_To.Text.Trim());
                        _freightProMappSave.Remarks = txtRemarks.Text.Trim();

                        if (editClick == 1)  //if click Edit 
                        {
                            if (!svcCode.Trim().Equals(currentSvcType.Trim()) || !packCode.Trim().Equals(currentPackType.Trim()) || !radioButtonStatus.Trim().Equals(currentDocNDoc.Trim()))
                            {
                                if (!_freightProductMapping.CheckAlreadExist(svcCode.Trim(), packCode.Trim(), radioButtonStatus.Trim(), agencyValue, productMainCode, productSubCode))
                                {
                                    _freightProductMapping.EditData(currentSvcType, currentPackType, currentDocNDoc, svcCode.Trim(), packCode.Trim(),
                                    radioButtonStatus, Convert.ToDecimal(txtWeight_From.Text.Trim()), Convert.ToDecimal(txtWeight_To.Text.Trim()), txtRemarks.Text.Trim());

                                    MessageBox.Show("Save successfully", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    ClearFieldsOnError();
                                    FieldDisable();
                                }
                                else
                                {
                                    ClearFieldsOnError();
                                    MessageBox.Show("The record is already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
                                }
                            }
                            else if (_freightProductMapping.CheckAlreadExist(svcCode.Trim(), packCode.Trim(), radioButtonStatus.Trim(), agencyValue, productMainCode, productSubCode))
                            {
                                _freightProductMapping.EditData(currentSvcType, currentPackType, currentDocNDoc, svcCode.Trim(), packCode.Trim(),
                                radioButtonStatus, Convert.ToDecimal(txtWeight_From.Text.Trim()), Convert.ToDecimal(txtWeight_To.Text.Trim()), txtRemarks.Text.Trim());

                                MessageBox.Show("Save successfully", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearFieldsOnError();
                                FieldDisable();

                            }
                            else
                            {
                                ClearFieldsOnError();
                                FieldDisable();
                                MessageBox.Show("The record is already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
                            }
                        }
                        else
                        {       //Save method
                            if (!_freightProductMapping.CheckAlreadExist(svcCode.Trim(), packCode.Trim(), radioButtonStatus.Trim(), agencyValue, productMainCode, productSubCode))
                            {
                                _freightProductMapping.SaveData(_freightProMappSave);
                                MessageBox.Show("Save successfully", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ClearFieldsOnError();
                                FieldDisable();
                            }
                            else
                            {
                                ClearFieldsOnError();
                                FieldDisable();
                                MessageBox.Show("The record is already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
                        }

                        ShowGridView();
                        UpperFieldsEnable();
                        grdFreightProductMappings.Enabled = true;

                        dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                        dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                    }
                }
                
            }
            else if (cmbSvcType.Text.Equals("") && cmbPackType.Text.Equals("") /*&& rdDoc.Checked == false || rdNonDoc.Checked == false*/)
            {
                MessageBox.Show("Please select a Service Type, Pack Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }          
            else if (cmbSvcType.Text.Equals(""))
            {
                MessageBox.Show("Please select a Service Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cmbPackType.Text.Equals(""))
            {
                MessageBox.Show("Please select a Pack Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            editClick = 0;
        }
        private void FreightProductMapping_Load(object sender, EventArgs e)
        {
            try
            {
                agencyList = _freightProductMapping.GetAgencyDetail(1, 200, 1002).ToList<AgencyDomainViewcs>();
                //agencyList = _freightProductMapping.GetAgenciesA().ToList<AgencyDomainViewcs>();
                cmbAgency.DataSource = agencyList;
                cmbAgency.SelectedItem = null;
                
                initialLoad = false;               
            }
            catch
            {
                MessageNotification.MessageBoxError("Application Loading Failure", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
        }

        private void cmbAgency_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!initialLoad)
                {
                    oAgencyDomainViewcs = (AgencyDomainViewcs)cmbAgency.SelectedItem;
                    agencyValue = oAgencyDomainViewcs.AgncyCode;
                    txtAgencyCode.Text = agencyValue.ToString();
                   
                    if (txtAgencyCode.Text != ""){cmbInvoiceType.Enabled = true; }

                    NewBtnValidations();

                    //set data to cmbInvoice
                    productMainList = _freightProductMapping.GetInvoiceType(agencyValue).ToList<ExpressCfgProductsMainDomainView>();
                    cmbInvoiceType.DataSource = productMainList;

                    //set data to SvtType
                    cfgSvcTypeList = _freightProductMapping.GetSvcType(agencyValue).ToList<ExpressCfgSvcTypes>();
                    cmbSvcType.DataSource = cfgSvcTypeList;

                    //set data to Pack type
                    cfgPackTypeList = _freightProductMapping.GetPackType(agencyValue).ToList<ExpressCfgPackTypes>();
                    cmbPackType.DataSource = cfgPackTypeList;

                    cmbInvoiceType.SelectedIndex = -1;
                    cmbSvcType.SelectedIndex = -1;
                    cmbPackType.SelectedIndex = -1;

                    txtInvoiceTypeCode.Text = "";

                    invoiceLoadCmb = false;
                    svcTypeLoadCmb = false;
                    packTypeLoadCmb = false;
                } 
            }
            catch (Exception EX)
            {
                //MessageNotification.MessageBoxError("Application Loading Failure", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
            }
        }
      
        private void cmbInvoiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbInvoiceType.SelectedIndex != -1)
            {
                if (!invoiceLoadCmb)
                {
                    productsMainDomainView = (ExpressCfgProductsMainDomainView)cmbInvoiceType.SelectedItem;
                    productMainCode = productsMainDomainView.ProductM;
                    txtInvoiceTypeCode.Text = productMainCode.ToString();
                    string_Doctype = productsMainDomainView.Doctype;

                    if (txtInvoiceTypeCode.Text != "") { cmbProduct.Enabled = true; }

                    NewBtnValidations();
                    ShowGridView();

                    //set data to cmbProduct
                    productsSubList = _freightProductMapping.GetProduct(productMainCode.ToString(), agencyValue).ToList<ExpressCfgProductsSubDomainView>();
                    cmbProduct.DataSource = productsSubList;
                    cmbProduct.SelectedIndex = -1;
                    txtProductCode.Text = "";

                    productLoadCmb = false;
                }
            }
            else
            {
                grdFreightProductMappings.DataSource = null;
                cmbProduct.Enabled = false;
                ClearFieldsOnError();
                FieldDisable();

                dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
                dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, false, ButtonCustomState.DISABLEENABBLE);
            }            
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbProduct.SelectedIndex != -1)
                {
                    if (!productLoadCmb)
                    {
                        productsSubDomainView = (ExpressCfgProductsSubDomainView)cmbProduct.SelectedItem;
                        productSubCode = productsSubDomainView.ProductS;
                        txtProductCode.Text = productSubCode.ToString();

                        ClearFieldsOnError();
                        FieldDisable();

                        NewBtnValidations();
                        ShowGridView();
                    } 
                }
                else
                {
                    //grdFreightProductMappings.DataSource = null;
                    //cmbProduct.Enabled = false;
                    ClearFieldsOnError();
                    FieldDisable();

                    dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, false, ButtonCustomState.DISABLEENABBLE);
                }
            }
            catch (Exception EX)
            {
                //MessageNotification.MessageBoxError("Application Loading Failure", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SysError);
            }
        }

        private void rdDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDoc.Checked == true)
            {
                radioButtonStatus = "D";
            }
        }

        private void rdNonDoc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdNonDoc.Checked == true)
            {
                radioButtonStatus = "N";
            }
        }

        private void grdFreightProductMappings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.grdFreightProductMappings.Rows[e.RowIndex];
                                      
                    cmbSvcType.Text = row.Cells["SvcTypeN"].Value.ToString();
                    cmbPackType.Text = row.Cells["PackTypeN"].Value.ToString();
                    radioButtonStatus = row.Cells["DocNDoc"].Value.ToString();
                    txtWeight_From.Text = row.Cells["WgtFrom"].Value.ToString();
                    txtWeight_To.Text = row.Cells["WgtTo"].Value.ToString();
                    txtRemarks.Text = row.Cells["Remarks"].Value.ToString();
                    grdAgencyCode = Convert.ToInt32(row.Cells["AgncyCode"].Value.ToString());
                    grdProductM = row.Cells["ProductM"].Value.ToString();
                    grdProductS = row.Cells["ProductS"].Value.ToString();

                    svcCode = row.Cells["SvcType"].Value.ToString();
                    packCode = row.Cells["PackType"].Value.ToString();

                    currentSvcType = svcCode;
                    currentPackType = packCode;
                    currentDocNDoc = radioButtonStatus;

                    if (radioButtonStatus.Equals("D"))
                    {
                        rdDoc.Checked = true;
                        rdDoc_CheckedChanged(sender, e);
                    }
                    else if (radioButtonStatus.Equals("N"))
                    {
                        rdNonDoc.Checked = true;
                        rdNonDoc_CheckedChanged(sender, e);
                    }
                    dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);

                    if (txtAgencyCode.Text != "" && txtInvoiceTypeCode.Text != "" && txtProductCode.Text != "")
                    {
                        dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                    }                   
                }
            }

            catch (Exception ex)

            {
            }
        }

        private void cmbSvcType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSvcType.SelectedIndex != -1)
            {
                if (!svcTypeLoadCmb)
                {
                    cfgSvcTypeDomainView = (ExpressCfgSvcTypes)cmbSvcType.SelectedItem;
                    svcCode = cfgSvcTypeDomainView.SvcType;                    
                }
            }
        }

        private void cmbPackType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPackType.SelectedIndex != -1)
            {
                if (!packTypeLoadCmb)
                {
                    cfgPackTypeDomainView = (ExpressCfgPackTypes)cmbPackType.SelectedItem;
                    packCode = cfgPackTypeDomainView.PackType;                    
                }
            }
        }

        private void cmbSvcType_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.KeyCode == Keys.Enter)
            {               
                var currValues = cfgSvcTypeList.FindAll(curr => curr.SvcTypeN.ToUpper().Contains(cmbSvcType.Text.ToUpper()));

                if (cfgSvcTypeList != null && currValues.Count == 0)
                {
                    cmbSvcType.Text = "";
                    MessageBox.Show("Invalid Service Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            cmbSvcType.DroppedDown = false;
        }

        private void cmbPackType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var currValues = cfgPackTypeList.FindAll(curr => curr.PackTypeN.ToUpper().Contains(cmbPackType.Text.ToUpper()));

                if (cfgPackTypeList != null && currValues.Count == 0)
                {
                    cmbPackType.Text = "";
                    MessageBox.Show("Invalid Pack Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            cmbPackType.DroppedDown = false;
        }
       

        private bool WeightTextValidation(string text)
        {
            bool ss = true;
            decimal y;
            if (decimal.TryParse(text, out y))
            {
                if (text.ToCharArray().Any(x => x == '.'))
                {
                    if (text.ToCharArray().Where(x => x == '.').Count() > 1)
                    {
                        return false;
                    }
                    else
                    {
                        string subtext = text.Split('.')[0];
                        if (subtext.ToCharArray().Count() > 7)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if (text.ToCharArray().Count() > 7)
                    {
                        return false;
                    }
                }
            }
            else
            {               
                return false;
            }

            return ss;
        }

        private void txtWeight_From_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar !='.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if(!WeightTextValidation(txtWeight_From.Text+e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if(!WeightTextValidation(txtWeight_From.Text + e.KeyChar) && char.IsControl(e.KeyChar))
                {
                    txtWeight_From.Text = "";
                }
            }
        }

        private void txtWeight_To_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                if (!WeightTextValidation(txtWeight_To.Text + e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                else if (!WeightTextValidation(txtWeight_To.Text + e.KeyChar) && char.IsControl(e.KeyChar))
                {
                    txtWeight_To.Text = "";
                }
            }
        }
    }
}
