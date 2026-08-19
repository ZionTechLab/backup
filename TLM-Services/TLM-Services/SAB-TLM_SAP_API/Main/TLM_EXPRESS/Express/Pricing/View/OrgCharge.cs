using Express.Domain.Message;
using Express.Interfaces.Pricing;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Enum;
using Express.UI.Common.Helpers;
using Express.UI.Factory;
using Express.UI.Filters.View;
using Express.View.Domain.AdminConfiguration;
using Express.View.Domain.Filters;
using Express.View.Domain.Pricing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Express.UI.Pricing.View
{
    public partial class OrgCharges : Form, IDataManipulate
    {
        private readonly IOrgCharges<OrgChargesView> _orgCharges;
        private List<OrgChargesCurrencyView> _currency;
        private readonly OrgChargesView _orgChargesSave;
      
        private string checkBox = "";
        private int CMPY;

        public FormStateEnum FormState { get; private set; }

            public OrgCharges()
            {
            InitializeComponent();

            if (_orgCharges == null)
            {
                _orgCharges = PricingUIFactory.GetService<IOrgCharges<OrgChargesView>>();

            }

            _currency = new List<OrgChargesCurrencyView>();
            _orgChargesSave = new OrgChargesView();
                        
            _currency = _orgCharges.GetLocalCurrency("").ToList();
            txtLocalCurrency.Text = _currency.FirstOrDefault().Currency;

            _currency = _orgCharges.GetLocalCurrency("").ToList();
            CMPY = _currency.FirstOrDefault().CompID;



            dataManipulate1.NewButtonClick += new EventHandler(NewMethod);
            dataManipulate1.SaveButtonClick += new EventHandler(SaveMethod);
            dataManipulate1.EditButtonClick += new EventHandler(EditMethod);
            dataManipulate1.CancelButtonClick += new EventHandler(ClearMethod);
            dataManipulate1.CloseButtonClick += new EventHandler(CloseForm);
            dataManipulate1.DelteButtonClick += new EventHandler(DeleteMethod);


            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CLOSE, true, ButtonCustomState.HIDEVISIBLE);


            // not Necessary (buttons status when program run) 
            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);


            dataManipulate1.CustomButtonState(ButtonTypes.PRINT, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PREVIEW, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.PROCESS, false, ButtonCustomState.HIDEVISIBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.IMPORT, false, ButtonCustomState.HIDEVISIBLE);

            txtOrgCode.ReadOnly = true;
            txtOrgName.ReadOnly = true;
            txtAddress1.ReadOnly = true;
            txtAddress2.ReadOnly = true;
            txtAddress3.ReadOnly = true;
            txtSalseAreaCode.ReadOnly = true;
            txtSalesAreaName.ReadOnly = true;
            txtAmount.ReadOnly = true;
            txtLocalCurrency.ReadOnly = true;
            chkExcempt.Enabled = false;
            grdAdminCharges.AutoGenerateColumns = false;
            ShowDataGrid();

        }

        public void ShowDataGrid()
        {
            var showGride = _orgCharges.GetAdminChargesGrid(1);
            grdAdminCharges.DataSource = showGride.ToList();
            grdAdminCharges.AutoGenerateColumns = false;
        }


        public void ShowSalesInfo(int OrgCode)
        {
            OrgChargeSalseAreaNameView GetSalsesDetails = _orgCharges.GetSalesAreaName(OrgCode).FirstOrDefault();
            if (GetSalsesDetails != null)
            {
                txtSalseAreaCode.Text = GetSalsesDetails.SalesAreaID;
                txtSalesAreaName.Text = GetSalsesDetails.SalesAreaName;
            }
        }
      
            public void ClearMethod(object param, EventArgs e)
            {

            FormState = FormStateEnum.Clear;

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CLOSE, true, ButtonCustomState.HIDEVISIBLE);

            txtOrgCode.Text = "";
            txtOrgName.Text = "";
            txtAddress1.Text = "";
            txtAddress2.Text = "";
            txtAddress3.Text = "";
            txtSalseAreaCode.Text = "";
            txtSalesAreaName.Text = "";
            txtAmount.Text = "";
            chkExcempt.Text = "";
            chkExcempt.Checked = false;

            txtOrgCode.ReadOnly = true;
            txtOrgName.ReadOnly = true;
            txtAddress1.ReadOnly = true;
            txtAddress2.ReadOnly = true;
            txtAddress3.ReadOnly = true;
            txtSalesAreaName.ReadOnly = true;
            txtAmount.ReadOnly = true;
            chkExcempt.Enabled = false;

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

            FormState = FormStateEnum.Update;

            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);

            txtOrgName.ReadOnly = true;
            txtAddress1.ReadOnly = true;
            txtAddress2.ReadOnly = true;
            txtAddress3.ReadOnly = true;
            txtSalesAreaName.ReadOnly = true;
            txtAmount.ReadOnly = false;
            chkExcempt.Enabled = true;           

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

            dataManipulate1.CustomButtonState(ButtonTypes.NEW, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.SAVE, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.DELETE, false, ButtonCustomState.DISABLEENABBLE);
            dataManipulate1.CustomButtonState(ButtonTypes.CLOSE, true, ButtonCustomState.HIDEVISIBLE);

            txtOrgCode.ReadOnly = true;
            txtOrgName.ReadOnly = true;
            txtAddress1.ReadOnly = true;
            txtAddress2.ReadOnly = true;
            txtAddress3.ReadOnly = true;
            txtSalesAreaName.ReadOnly = true;
            txtAmount.ReadOnly = false;
            chkExcempt.Enabled = true;

            ShowDataGrid();
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

            FormState = (FormState != FormStateEnum.Update) ? FormStateEnum.Save : FormStateEnum.Update;
            ResponseMessage responce = null;

            _orgChargesSave.Deleted = 0;
            _orgChargesSave.CMPY = CMPY;
            _orgChargesSave.OrgCode = Convert.ToInt32(txtOrgCode.Text);
            _orgChargesSave.Amount = Convert.ToDecimal(txtAmount.Text);
            _orgChargesSave.excemptY = checkBox;     

            grdAdminCharges.AutoGenerateColumns = false;


            var vResult = CustomValidate.Instance.ValidateModel(_orgChargesSave);


            if (vResult == "")
            {

                if (FormState == FormStateEnum.Save)
                {
                    responce = _orgCharges.SaveDetails(_orgChargesSave);
                }
                if (FormState == FormStateEnum.Update)
                {
                    responce = _orgCharges.EditDetails(_orgChargesSave);
                }


                if (responce.IsSuccess)
                {
                    ShowDataGrid();

                    txtAmount.ReadOnly = true;
                    chkExcempt.Enabled = false;
                    chkExcempt.Checked = false;

                    dataManipulate1.CustomButtonState(ButtonTypes.NEW, true, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.CANCEL, true, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.DELETE, true, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.CLOSE, true, ButtonCustomState.HIDEVISIBLE);

                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            var search = new OrgSearchValueDomainView
            {

            };
            new CustomerSearch(ref search).ShowDialog();

            if (search.OrgCode == 0)
            {
                txtOrgCode.Text = "";
            }
            else
            {
                txtOrgCode.Text = search.OrgCode.ToString();
            }
            txtOrgName.Text = search.OrgName;
            txtAddress1.Text = search.OrgAdd1;
            txtAddress2.Text = search.OrgAdd2;
            txtAddress3.Text = search.OrgCity;
          
            ShowSalesInfo(search.OrgCode);
            txtAmount.Text = "";
            dataManipulate1.CustomButtonState(ButtonTypes.EDIT, false, ButtonCustomState.DISABLEENABBLE);
            //txtSalseAreaCode.Text = "";
            //txtSalesAreaName.Text = "";
        }

        private void chkExcempt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcempt.Checked == true)
            {
                checkBox = "Y";
            }
            else
            {
                checkBox = "";
            }
        }

        private void grdAdminCharges_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    dataManipulate1.CustomButtonState(ButtonTypes.EDIT, true, ButtonCustomState.DISABLEENABBLE);
                    dataManipulate1.CustomButtonState(ButtonTypes.SAVE, false, ButtonCustomState.DISABLEENABBLE);
                    txtAmount.ReadOnly = true;

                    DataGridViewRow row = this.grdAdminCharges.Rows[e.RowIndex];

                    txtOrgCode.Text = row.Cells["OrgCode"].Value.ToString();
                    txtOrgName.Text = row.Cells["OrgName"].Value.ToString();
                    txtAmount.Text = row.Cells["Amount"].Value.ToString();
                    txtSalseAreaCode.Text = row.Cells["SalesAreaID"].Value.ToString();
                    txtSalesAreaName.Text = row.Cells["SalesAreaName"].Value.ToString();
                    txtAddress1.Text = row.Cells["OrgAddr1"].Value.ToString();
                    txtAddress2.Text = row.Cells["OrgAddr2"].Value.ToString();
                    txtAddress3.Text = row.Cells["OrgCity"].Value.ToString();             
                    
                }
            }

            catch (Exception)

            {
            }

        }

        private void OrgCharges_Load(object sender, EventArgs e)
        {

        }
    }
}

