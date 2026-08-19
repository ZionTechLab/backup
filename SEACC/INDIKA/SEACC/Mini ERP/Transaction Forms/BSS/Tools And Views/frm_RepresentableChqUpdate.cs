using Digiteq_Logic;
using SEACC.DATA.Data.BSS;
using SEACC.WinFormControls.Forms;
using SEACC.WinFormControls.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq.Transaction_Forms.BSS.Tools_And_Views
{
    public partial class frm_RepresentableChqUpdate : MettroForm
    {
        public int iFormID;
        public bool bNoAccess;

        ChequeData oData = new ChequeData();
        List<dynamic> GridList;

        public frm_RepresentableChqUpdate()
        {
            iFormID = clsSecurity.getFormID(FormName.RepresentableChqUpdate);

            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();

            gridMain.AutoGenerateColumns = false;
            try
            {
                LoadUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadUI()
        {
            try
            {
                GridList = oData.Get_ReturnedCheques();

                txtRemarks.Clear();
                dtmRedepositDate.Value = DateTime.Now;
                lblAmount.Text = "0.00";
                lblChqNo.Text = "";
                lblCustomer.Text = "";

              //  gridMain.DataSource = GridList;
                gridMain.DataSource =Cast.ToDataTables( GridList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadUI();
        }

        private void gridMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var row = gridMain.Rows[e.RowIndex];

                    txtRemarks.Text = DataGridValidate.GetStringValue(row.Cells["Remarks_Representable"]);
                    dtmRedepositDate.Value = DataGridValidate.GetDateTimeValue(row.Cells["date_Representable"]);
                    lblCustomer.Text = DataGridValidate.GetStringValue(row.Cells["customerName"]);
                    lblChqNo.Text = DataGridValidate.GetStringValue(row.Cells["chequeNumber"]);
                    lblAmount.Text = DataGridValidate.GetStringValue(row.Cells["ChequeAmount"]);
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (gridMain.SelectedRows.Count != 0)
            {
                var row = gridMain.SelectedRows[0];
                var ChequeRegisterId = DataGridValidate.GetStringValue(row.Cells["chequeRegister_ID"]);
                if (ChequeRegisterId != "")
                {
                    var result = oData.Save_RepresentableDate(ChequeRegisterId, dtmRedepositDate.Value.Date, txtRemarks.Text);
                    if (!result.IsSuccess)
                        MessageBox.Show(result.OutMsg);
                    else
                    {
                        MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.Afterupdate, ""), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUI();
                    }
                }
            }
        }
    }
}
