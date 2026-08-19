using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frm_sasDeliveryOrderEditRemark : MettroForm
    {

        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;
        public int iFormID;
        public bool bNoAccess;
        #endregion

        #region Form Load
        public frm_sasDeliveryOrderEditRemark()
        {
            iFormID = clsSecurity.getFormID(FormName.DeliveryOrderRemarkEdit);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_sasDeliveryOrderManuslSettle_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "D/O Edit", 2, iFormID);
            ClearFields();

        }
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();

        }
        #endregion

        #region Btn Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDoCode.Tag != null && txtDoCode.Tag.ToString().Length > 0)
            {
                tbl_sasDeliveryOrder oOrder = tbl_sasDeliveryOrder.Select(txtDoCode.Tag.ToString().Trim());
                if (oOrder != null && oOrder.DeliveryOrder_ID != "default")
                {
                    if (!oOrder.IsDeleted)
                    {

                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            oOrder.Remark = rhRemark.Text;
                            oOrder.ModifiedTerminal_ID = clsSecurity.TerminalID;
                            oOrder.ModifiedUser_ID = clsSecurity.UserIDLoged;
                            oOrder.Update();
                            ClearFields();
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption() + " [" + iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, clsFormatter.GetMessageCaption() + " [" + iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                        }
                    }
                    else
                        MessageBox.Show("This Do Deleted.....!", clsFormatter.GetMessageCaption() + " [" + iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        #endregion

        #region Fill Data
        private void FillDoData()
        {
            if (txtDoCode.Tag != null && txtDoCode.Tag.ToString().Length > 0)
            {
                tbl_sasDeliveryOrder oOrder = tbl_sasDeliveryOrder.Select(txtDoCode.Tag.ToString().Trim());
                if (oOrder != null && oOrder.DeliveryOrder_ID != "default")
                    rhRemark.Text = oOrder.Remark;
            }
        }
        #endregion



        #region Clear Fields
        private void ClearFields()
        {

            txtDoCode.Clear();
            txtDoCode.Tag = null;
            rhRemark.Clear();

        }
        #endregion



        #region Check Validity


        #endregion



        #region Events KeyDown


        private void txtDoCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                ClearFields();
                Search_DeliveryOrderID();
                FillDoData();
            }
        }

        private void frm_sasDeliveryOrderManuslSettle_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region Events DoubleClick

        private void txtDoCode_DoubleClick(object sender, EventArgs e)
        {
            ClearFields();
            Search_DeliveryOrderID();
            FillDoData();
        }
        #endregion

        #region Search Methods
        private void Search_DeliveryOrderID()
        {
            clsSearch.Search_TransactionDeliveryOrder_Use(ref txtDoCode, "",false);
        }
        #endregion
    }
}
