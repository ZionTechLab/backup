using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;
using SEACC.DATA.Data;
using SEACC.DATA.Domain;

namespace Digiteq
{
    public partial class frm_sasDeliveryOrder_DoDate : MettroForm
    {
        
        //to manage update and insert

        sasDeliveryOrder_DoDateData data = new sasDeliveryOrder_DoDateData();
    

        #region Form Load
        public frm_sasDeliveryOrder_DoDate()
        {
            iFormID = clsSecurity.getFormID(FormName.DoDateEdit);
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
                if (txtDriver.Tag == null)
                {
                    MessageBox.Show("Please select a driver");
                    return;
                }
                if (txtDeliveryOfficer.Tag == null)
                {
                    MessageBox.Show("Please select a Delivery Officer");
                    return;
                }
                sasDeliveryOrderDomain oOrder = new sasDeliveryOrderDomain()
                {
                    deliveryOrder_ID = txtDoCode.Text.Trim(),
                    customerDeliveryDate = dtpReceivedDate.Value.Date,
                    driver_ID = txtDriver.Tag.ToString(),
                    deliveryRemarks = rhRemark.Text,
                    VehicleNo = txtVehicleNo.Text,
                    DeliveryOfficer_ID = txtDeliveryOfficer.Tag.ToString()
                };

                if (oOrder != null && oOrder.deliveryOrder_ID != "default")
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;

                        var result = data.SaveDetails(oOrder);
                        if (result.IsSuccess)
                        {
                            ClearFields();
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption() + " [" + iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show(result.OutMsg, clsFormatter.GetMessageCaption() + " [" + iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
        }
        #endregion

        #region Fill Data
        private void FillDoData()
        {
            if (txtDoCode.Tag != null && txtDoCode.Tag.ToString().Length > 0)
            {
             
                var oOrder = data.GetDetails(txtDoCode.Tag.ToString().Trim());

                if (oOrder != null && oOrder.deliveryOrder_ID != "default")
                {
                    rhRemark.Text = oOrder.deliveryRemarks;
                    dtpReceivedDate.Value = oOrder.customerDeliveryDate;
                    txtDriver.Tag = oOrder.driver_ID;
                    txtDriver.Text = oOrder.driverName;
                    txtVehicleNo.Text = oOrder.VehicleNo;
                    txtDeliveryOfficer.Tag = oOrder.DeliveryOfficer_ID;
                    txtDeliveryOfficer.Text = oOrder.DeliveryOfficerName;
                }
            }
        }
        #endregion



        #region Clear Fields
        private void ClearFields()
        {
            txtDoCode.Clear();
            txtDoCode.Tag = null;
            rhRemark.Clear();
            txtDriver.Clear();
            txtDriver.Tag = null;
            txtDeliveryOfficer.Tag = null;
            txtDeliveryOfficer.Clear();
            txtVehicleNo.Clear();
            dtpReceivedDate.Value = DateTime.Now;
        }
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
            clsSearch.Search_TransactionDeliveryOrder_Use(ref txtDoCode, "",true);
        }
        #endregion

        private void txtDriver_DoubleClick(object sender, EventArgs e)
        {
            Search_DriverID();
        }
        private void Search_DriverID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_DriverID();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    tbl_zDriver detail = tbl_zDriver.Select(frmSearchMaster.s_SearchID);
                    if (detail != null)
                    {
                        txtDriver.Tag = frmSearchMaster.s_SearchID;
                        txtDriver.Text = detail.DriverName;
                        //  FillDetails(frmSearchMaster.s_SearchID);}}
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_DeleveryOfficeID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_DriverID();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    tbl_zDriver detail = tbl_zDriver.Select(frmSearchMaster.s_SearchID);
                    if (detail != null)
                    {
                        txtDriver.Tag = frmSearchMaster.s_SearchID;
                        txtDriver.Text = detail.DriverName;
                        //  FillDetails(frmSearchMaster.s_SearchID);}}
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID, ex);
                SEACCException.Show(ex);
            }
        }

        private void txtDeliveryOfficer_DoubleClick(object sender, EventArgs e)
        {
            clsSearch.Search_DeleveryOfficer(ref txtDeliveryOfficer);
        }
    }
}