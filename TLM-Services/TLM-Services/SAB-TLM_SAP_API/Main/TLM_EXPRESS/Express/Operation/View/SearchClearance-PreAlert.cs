using Express.Interfaces.Operations.Manifest;
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
    public partial class SearchClearance_PreAlert : Form
    {
        AgencyDomainViewcs SelectedAgency = new AgencyDomainViewcs();
        List<ClearancePreAlertDomainView> ClearanceDataList = new List<ClearancePreAlertDomainView>();
        private readonly ISearchClearancePreAlert<ClearancePreAlertDomainView> dataProvider;
        public ClearancePreAlertDomainView refCons;
        public SearchClearance_PreAlert(AgencyDomainViewcs Agency,ref ClearancePreAlertDomainView _refCons)
        {
            InitializeComponent();
            this.SelectedAgency = Agency;
            if (dataProvider == null)
            {
                dataProvider = OperationsUIFacotry.GetService<ISearchClearancePreAlert<ClearancePreAlertDomainView>>();
            }
            this.refCons = _refCons;
          //  refCons.AgncyCode = 20101;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SearchClearance_PreAlert_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        public void GetSerchResult()
        {
            if(comboBox1.SelectedItem !=null)
            {
                if(textBox1.Text !="")
                {
                    //string Console = "";
                    //string MAWBNo = "";
                    //string ConsoleNo = "";

                    if(comboBox1.SelectedItem.ToString()== "Express Cons")
                    {
                        ClearanceDataList = dataProvider.GetSerchResult(SelectedAgency.GroupID, SelectedAgency.CompID, SelectedAgency.AgncyCode, textBox1.Text, "", "").ToList();
                    }

                    else if(comboBox1.SelectedItem.ToString() == "MAWB No")
                    {
                        ClearanceDataList = dataProvider.GetSerchResult(SelectedAgency.GroupID, SelectedAgency.CompID, SelectedAgency.AgncyCode, "", textBox1.Text, "").ToList();
                    }
                    else
                    {
                        ClearanceDataList = dataProvider.GetSerchResult(SelectedAgency.GroupID, SelectedAgency.CompID, SelectedAgency.AgncyCode, "", "", textBox1.Text).ToList();
                    }
                    dataGridView2.DataSource = null;
                    dataGridView2.AutoGenerateColumns = false;
                    dataGridView2.DataSource = ClearanceDataList;
                }
                else
                {
                    MessageNotification.MessageBoxOK("Please enter Search value", LoginInfoView.COMPANYNAME, MessagHeaderInfo.Information);
                }
            }

        }

        private void Find_Click(object sender, EventArgs e)
        {
            GetSerchResult();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                var temp= (ClearancePreAlertDomainView)dataGridView2.SelectedRows[0].DataBoundItem;
                refCons.AgncyCode = temp.AgncyCode;
                refCons.ConsId = temp.ConsId;
                refCons.TransDate = temp.TransDate;
                refCons.OrgHubID = temp.OrgHubID;
                refCons.DesHubID = temp.DesHubID;
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
