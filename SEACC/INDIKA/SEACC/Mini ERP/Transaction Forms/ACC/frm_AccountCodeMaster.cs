using Digiteq_Logic;
using SEACC.DATA.Data.ACC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq.Transaction_Forms.ACC
{
    public partial class frm_AccountCodeMaster : MettroForm
    {
        #region Variables   
        string sFormConfigCode;
        public int iFormID;
        public bool bNoAccess;

        //  private BindingSource source = new BindingSource();
        //  public DataTable dtAllRecodes = new DataTable();
        //  private string sFilteQuary = "";

        //  masCustomerWiseItemPricingData dataObject = new masCustomerWiseItemPricingData();
        #endregion
        public frm_AccountCodeMaster()
        {
            InitializeComponent();

            iFormID = clsSecurity.getFormID(FormName.accAccountCode);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;
        }

        private void frm_AccountCodeMaster_Load(object sender, EventArgs e)
        {
            //   dgvDetail.DataSource = source;
            //    CreateDataTable();

            ClearFields();
        }
        private void ClearFields()
        {
            txtAcctCode.Clear();
            txtAcctCodeName.Clear();
            txtAcctCodeGlName.Clear();
            txtAcctCodeSubGLName.Clear();
            txtAcctCodeTypeName.Clear();
            txtAcctCodeType2Name.Clear();
            txtAcctCodeGlCode.Clear();
            txtAcctCodeSubGlCode.Clear();
            txtAcctCodeTypeCode.Clear();
            txtAcctCodeType2Code.Clear();
            txtSortOrder.Clear();

            cmbAcctCodeStatus.SelectedIndex = -1;
            cmbControlAcc.SelectedIndex = -1;

            AccountsMasterData oData =new AccountsMasterData();
            dgvDetail.DataSource = oData.Get_GlAccounts();
        }
    }
}
