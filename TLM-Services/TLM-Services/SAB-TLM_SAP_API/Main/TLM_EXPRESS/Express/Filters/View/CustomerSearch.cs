using Express.Interfaces.Filters;
using Express.Interfaces.Operations.Manifest;
using Express.UI.Common.CustomValidators;
using Express.UI.Common.Helpers;
using Express.UI.Factory.Filter;
using Express.UI.Factory.Operations;
using Express.UI.Helpers;
using Express.View.Domain.Filters;
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

namespace Express.UI.Filters.View
{
    public partial class CustomerSearch : Form
    {
        private readonly ICustomerSearch<RefOrganizationDomainView> _extProvider;
       // private OpsConsAWBDomainView oOpsConsAWBDomainView = null;
        private readonly  OrgSearchValueDomainView _searcheValue;
        private List<RefOrganizationDomainView> RegularOrganizations = null;
        private List<RefOrganizationDomainView> OneTimeOrganizations = null;

        private List<RefOrganizationDomainView> tempRegularOrganizations = null;
        private List<RefOrganizationDomainView> tempOneTimeOrganizations = null;

        private List<string> searchBy = new List<string>();
        private RefOrganizationDomainView selectedCustomer = null;
        private readonly OrgSearchParamDomainView _param;



        public CustomerSearch(ref OrgSearchValueDomainView obj)
        {
            InitializeComponent();
            if (_extProvider == null)
            {
                _extProvider = SearchFilterUIFactory.GetService<ICustomerSearch<RefOrganizationDomainView>>();
            }
            _param = new OrgSearchParamDomainView();
            tempRegularOrganizations = new List<RefOrganizationDomainView>();
            tempOneTimeOrganizations = new List<RefOrganizationDomainView>();
            //oOpsConsAWBDomainView = obj;
            this._searcheValue = obj;
            this.loadSearchByCombo();

            txtSearch.Text = obj.OrgName;
            SearchInitials(txtSearch.Text);
        }

        private void CustomerSearch_Load(object sender, EventArgs e)
        {
            ////try
            ////{
            ////    //RegularOrganizations = _extProvider.GetRefOrganizationRegular().ToList<RefOrganizationDomainView>();
            ////    //OneTimeOrganizations = _extProvider.GetRefOrganizationOneTime().ToList<RefOrganizationDomainView>();

            ////    //this.loadOraganizations("");
            ////    //this.loadSearchByCombo();    
               
            ////}
            ////catch
            ////{
            ////    MessageNotification.MessageBoxError("Loading Error", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            ////}

        }
               
        private void grdRegularOrg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                grdOneTimeOrg.ClearSelection();
                this.grdRegularOrg.CommitEdit(DataGridViewDataErrorContexts.Commit);
                this.grdOneTimeOrg.CommitEdit(DataGridViewDataErrorContexts.Commit);
                selectedCustomer = (RefOrganizationDomainView)grdRegularOrg.SelectedRows[0].DataBoundItem;                
            }
            catch (Exception ex)
            {
                MessageNotification.MessageBoxError("Error Selection", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
        }

        private void grdOneTimeOrg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                grdRegularOrg.ClearSelection();
                this.grdRegularOrg.CommitEdit(DataGridViewDataErrorContexts.Commit);
                this.grdOneTimeOrg.CommitEdit(DataGridViewDataErrorContexts.Commit);
                selectedCustomer = (RefOrganizationDomainView)grdOneTimeOrg.SelectedRows[0].DataBoundItem;
            }
            catch (Exception ex)
            {
                MessageNotification.MessageBoxError("Error Selection", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(selectedCustomer!=null)
                {
                    //oOpsConsAWBDomainView.BillOrgCode = selectedCustomer.OrgCode;
                    //oOpsConsAWBDomainView.RecCompany = selectedCustomer.OrgName;

                    _searcheValue.OrgCode = selectedCustomer.OrgCode;
                    _searcheValue.OrgName = selectedCustomer.OrgName;
                    _searcheValue.OrgAdd1 = selectedCustomer.OrgAddr1;
                    _searcheValue.OrgAdd2 = selectedCustomer.OrgAddr2;
                    _searcheValue.OrgCity = selectedCustomer.OrgCity;
                    _searcheValue.OrgCountry = selectedCustomer.OrgCountry;
                    _searcheValue.OrgCountryN  = selectedCustomer.OrgCountryN ;
                    _searcheValue.PhoneN = selectedCustomer.OrgPhone;



                    this.Close();
                }
                else
                {
                    MessageNotification.MessageBoxError("Select a Customer", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
                }
            }
            catch
            {
                MessageNotification.MessageBoxError("Error Selection", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtSearch.Text=="")
                {
                    MessageNotification.MessageBoxError("Please enter value to search", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                if(cmbSearchBy.SelectedItem.ToString().Trim() == "Organization Name")
                {
                    _param.OrgName = txtSearch.Text;
                    _param.OrgCode = 0;
                    _param.OrgAdd1 = "";
                    _param.OrgAdd2 = "";
                    this.loadOraganizations("Organization Name");
                }
                else if (cmbSearchBy.SelectedItem.ToString().Trim() == "Organization Code")
                {
                   if(!NumberValidator.TryPassInteger(txtSearch.Text ))
                    {
                        MessageNotification.MessageBoxError("Please enter valid number", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                        return;
                    }

                    _param.OrgCode = Convert.ToInt32(txtSearch.Text);
                    _param.OrgAdd1 = "";
                    _param.OrgAdd2 = "";
                    _param.OrgName = "";
                    this.loadOraganizations("Organization Code");
                }
                else if (cmbSearchBy.SelectedItem.ToString().Trim() == "Address 1")
                {
                    _param.OrgAdd1 = txtSearch.Text;
                    _param.OrgAdd2 = "";
                    _param.OrgName = "";
                    _param.OrgCode = 0;
                    this.loadOraganizations("Address 1");
                }
                else if (cmbSearchBy.SelectedItem.ToString().Trim() == "Address 2")
                {
                    _param.OrgAdd2 = txtSearch.Text;
                    _param.OrgAdd1 = "";
                    _param.OrgName = "";
                    _param.OrgCode = 0;
                    this.loadOraganizations("Address 2");
                }
                else 
                {
                    this.loadOraganizations("");
                }                
            }
            catch
            {
                MessageNotification.MessageBoxError("Error Search", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
            }
        }

        private void SearchInitials(string orgName)
        {
            try
            {
                if (txtSearch.Text == "")
                {
                    //MessageNotification.MessageBoxError("Please enter value to search", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
                    return;
                }

                if (cmbSearchBy.SelectedItem.ToString().Trim() == "Organization Name")
                {
                    _param.OrgName = txtSearch.Text;
                    _param.OrgCode = 0;
                    _param.OrgAdd1 = "";
                    _param.OrgAdd2 = "";
                    this.loadOraganizations("Organization Name");
                }                
                else
                {
                    this.loadOraganizations("");
                }
            }
            catch
            {
                MessageNotification.MessageBoxError("Error Search", LoginInfoView.COMPANYNAME, MessagHeaderInfo.ValidationError);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (cmbSearchBy.SelectedItem.ToString() == "Organization Code")
                {
                    int.Parse(txtSearch.Text);
                }
            }
            catch
            {
                txtSearch.Text = "";
            }
        }

        private void cmbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            txtSearch.Text = "";
            txtSearch.Focus();
        }

        private void grdRegularOrg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.grdRegularOrg_CellClick(sender, e);
                this.button2_Click(null, null);
            }
            catch
            {
                MessageNotification.MessageBoxError("Error Selection", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
        }

        private void grdOneTimeOrg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.grdOneTimeOrg_CellClick(sender, e);
                this.button2_Click(null, null);
            }
            catch
            {
                MessageNotification.MessageBoxError("Error Selection", LoginInfoView.COMPANYNAME, MessagHeaderInfo.SavingError);
            }
        }

        #region methods

        private void loadOraganizations(string selection)
        {
            ////if (selection == "Organization Name")
            ////{
            ////    grdRegularOrg.DataSource = RegularOrganizations.Where(c => c.OrgName.Trim().ToUpper().Contains(txtSearch.Text.ToUpper())).ToList<RefOrganizationDomainView>();
            ////    grdOneTimeOrg.DataSource = OneTimeOrganizations.Where(c => c.OrgName.Trim().ToUpper().Contains(txtSearch.Text.ToUpper())).ToList<RefOrganizationDomainView>();
            ////}
            ////else if (selection == "Organization Code")
            ////{
            ////    if (txtSearch.Text != "")
            ////    {
            ////        grdRegularOrg.DataSource = RegularOrganizations.Where(c => c.OrgCode.ToString().Trim().Contains(txtSearch.Text)).ToList<RefOrganizationDomainView>();
            ////        grdOneTimeOrg.DataSource = OneTimeOrganizations.Where(c => c.OrgCode.ToString().Trim().Contains(txtSearch.Text)).ToList<RefOrganizationDomainView>();
            ////    }
            ////}
            ////else if (selection == "Address 1")
            ////{
            ////    grdRegularOrg.DataSource = RegularOrganizations.Where(c => c.OrgAddr1.Trim().ToUpper().Contains(txtSearch.Text.ToUpper())).ToList<RefOrganizationDomainView>();
            ////    grdOneTimeOrg.DataSource = OneTimeOrganizations.Where(c => c.OrgAddr1.Trim().ToUpper().Contains(txtSearch.Text.ToUpper())).ToList<RefOrganizationDomainView>();
            ////}
            ////else if (selection == "Address 2")
            ////{
            ////    grdRegularOrg.DataSource = RegularOrganizations.Where(c => c.OrgAddr2.Trim().ToUpper().Contains(txtSearch.Text.ToUpper())).ToList<RefOrganizationDomainView>();
            ////    grdOneTimeOrg.DataSource = OneTimeOrganizations.Where(c => c.OrgAddr2.Trim().ToUpper().Contains(txtSearch.Text.ToUpper())).ToList<RefOrganizationDomainView>();
            ////}
            ////else
            ////{
            ////    grdRegularOrg.DataSource = RegularOrganizations;
            ////    grdOneTimeOrg.DataSource = OneTimeOrganizations;
            ////}

            if (bgOrgWork != null)
            {
                if (!bgOrgWork.IsBusy)
                {
                    bgOrgWork.RunWorkerAsync();
                }
                else
                {
                    MessageNotification.MessageBoxOK("Please wait.. Datas are loading", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Information);
                }
            }
        }

        private void loadSearchByCombo()
        {
            searchBy.Clear();
            searchBy.Add("Organization Name");
            searchBy.Add("Organization Code");
            searchBy.Add("Address 1");
            searchBy.Add("Address 2");
            cmbSearchBy.DataSource = searchBy;
            //cmbSearchBy.SelectedItem = null;
        }

        #endregion


        #region org background work
        private void bgOrgWork_DoWork(object sender, DoWorkEventArgs e)
        {
            RegularOrganizations = _extProvider.GetRefOrganizationRegular(_param).ToList<RefOrganizationDomainView>();
            OneTimeOrganizations = _extProvider.GetRefOrganizationOneTime(_param).ToList<RefOrganizationDomainView>();
            tempOneTimeOrganizations.AddRange(OneTimeOrganizations);
            tempRegularOrganizations.AddRange(RegularOrganizations);
        }

        private void bgOrgWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void bgOrgWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RefreshGrids();

        }

        #endregion

        private void RefreshGrids()
        {
            grdRegularOrg.ClearSelection();
            grdOneTimeOrg.ClearSelection();
            grdRegularOrg.DataSource = RegularOrganizations;
            grdOneTimeOrg.DataSource = OneTimeOrganizations;
            this.grdRegularOrg.CommitEdit(DataGridViewDataErrorContexts.Commit);
            this.grdOneTimeOrg.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (tempRegularOrganizations != null && tempRegularOrganizations.Count > 0)
                {
                  
                    RegularOrganizations = FilterRegularList();
                }
                if (tempOneTimeOrganizations != null && tempOneTimeOrganizations.Count > 0)
                {                   
                    OneTimeOrganizations = FilterOnetimeList();
                }

                RefreshGrids();
            }
            catch(Exception )
            {

            }
        }

        private List<RefOrganizationDomainView>  FilterRegularList()
        {
            if (cmbSearchBy.SelectedItem.ToString().Trim() == "Organization Name")
            {
                if (txtSearch.Text == "")
                {
                    return tempRegularOrganizations;
                }
                return tempRegularOrganizations.FindAll(val => val.OrgName.ToUpper().Contains(txtSearch.Text.ToUpper()));
            }
            else if (cmbSearchBy.SelectedItem.ToString().Trim() == "Organization Code")
            {
                if (txtSearch.Text == "")
                {
                    return tempRegularOrganizations;
                }
                return tempRegularOrganizations.FindAll(val => val.OrgCode.ToString().Contains(txtSearch.Text)).ToList();
            }
            else if (cmbSearchBy.SelectedItem.ToString().Trim() == "Address 1")
            {
                if (txtSearch.Text == "")
                {
                    return tempRegularOrganizations;
                }
                return tempRegularOrganizations.FindAll(val => val.OrgAddr1.ToUpper().Contains(txtSearch.Text.ToUpper())).ToList();
            }
            else if (cmbSearchBy.SelectedItem.ToString().Trim() == "Address 2")
            {
                if (txtSearch.Text == "")
                {
                    return tempRegularOrganizations;
                }
                return tempRegularOrganizations.FindAll(val => val.OrgAddr2.ToUpper().Contains(txtSearch.Text.ToUpper())).ToList();
            }
            return null;
        }


        private List<RefOrganizationDomainView> FilterOnetimeList()
        {
            if (cmbSearchBy.SelectedItem.ToString().Trim() == "Organization Name")
            {
                if (txtSearch.Text == "")
                {
                    return tempOneTimeOrganizations;
                }
                return tempOneTimeOrganizations.Where(val => val.OrgName.ToUpper().Contains(txtSearch.Text.ToUpper())).ToList();
            }
            else if (cmbSearchBy.SelectedItem.ToString().Trim() == "Organization Code")
            {
                if (txtSearch.Text == "")
                {
                    return tempOneTimeOrganizations;
                }
                return tempOneTimeOrganizations.Where(val => val.OrgCode.ToString().Contains(txtSearch.Text)).ToList();
            }
            else if (cmbSearchBy.SelectedItem.ToString().Trim() == "Address 1")
            {
                if (txtSearch.Text == "")
                {
                    return tempOneTimeOrganizations;
                }
                return tempOneTimeOrganizations.Where(val => val.OrgAddr1.ToUpper().Contains(txtSearch.Text.ToUpper())).ToList();
            }
            else if (cmbSearchBy.SelectedItem.ToString().Trim() == "Address 2")
            {
                if (txtSearch.Text == "")
                {
                    return tempOneTimeOrganizations;
                }
                return tempOneTimeOrganizations.Where(val => val.OrgAddr2.ToUpper().Contains(txtSearch.Text.ToUpper())).ToList();
            }
            return null;
        }
    }
}
