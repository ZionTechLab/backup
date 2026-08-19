
using Digiteq_Logic;
using SEACC.DATA.Data.MAS;
using SEACC.DATA.Domain.MAS;
using SEACC.DATA.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frm_BookNoAllocate_Receipt : MettroForm
    {
      //  public int iFormID;
      //  public bool bNoAccess;

        BookNoData oData = new BookNoData();
        List<tbl_ZEmpSalesRep> UIdata;
        List<tbl_RefBooks_Receipt_Pages> GridData = new List<tbl_RefBooks_Receipt_Pages>();
        public frm_BookNoAllocate_Receipt()
        {
            iFormID = clsSecurity.getFormID(FormName.BookNoAllocation_Receipt);

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
                UIdata = oData.GetUI();

                //---------------------------------------------------
                cmbSalesRep.DisplayMember = "selesRepName";
                cmbSalesRep.ValueMember = "selesRep_ID";

                cmbSalesRep.DataSource = UIdata;
                cmbSalesRep.SelectedIndex = -1;
                txtBookNo.SetValue("");
                txtRemarks.SetValue("");
                txtPreFix.SetValue("");
                txtLength.SetValue("4");
                txtStart.SetValue("0");
                txtEnd.SetValue("0");

                GridData = new List<tbl_RefBooks_Receipt_Pages>();
                gridMain.DataSource = cast.ToDataTables(GridData);
    
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {


            try
            {
                if (!txtBookNo.ValidateValue())
                    return;
                if (!txtPreFix.ValidateValue())
                    return;
                if(!cmbSalesRep.ValidateValue())
                    return;

                int iStartSerial = txtStart.getValue(0);
                int iEndSerial = txtEnd.getValue(0);
                int iLength = txtLength.getValue(0);

                if (iStartSerial >= iEndSerial)
                {
                    MessageBox.Show("Please Check the serial range");
                    return;
                }

                var x = oData.CheckValidity_BookNo(txtBookNo.getValue(""));
                if (!x.IsSuccess)
                {
                    MessageBox.Show(x.OutMsg);
                    return;
                }



                for (int i = iStartSerial; i <= iEndSerial; i++)
                {
                    GridData.Add(new tbl_RefBooks_Receipt_Pages() { PageNo = txtPreFix.getValue("") + i.ToString(clsAutocode.getWidthFormat(iLength)) });
                }
                gridMain.DataSource = cast.ToDataTables(GridData);
            }
            catch (Exception)
            {
                // throw;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadUI();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (GridData.Count == 0)
            {
                MessageBox.Show("Please process serial numbers");
                return;
            }
            if (!txtBookNo.ValidateValue())
                return;
            if (!txtPreFix.ValidateValue())
                return;
            if (!cmbSalesRep.ValidateValue())
                return;


         var x=   oData.SaveBookNo(GridData, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.getServerDateTime(), txtBookNo.getValue(""), cmbSalesRep.getSelectedValue(""), txtRemarks.getValue(""));
            if (!x.IsSuccess)
            {
                MessageBox.Show(x.OutMsg);
                return;
            }
            else
            { 
                MessageBox.Show("Save Successfully");
                LoadUI();
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            var frm = new frm_BookNoShowAll_Receipt();
            frm.ShowDialog();
        }
    }
}
