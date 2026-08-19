using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic; using SEACC.WinFormControls.Forms;
using System.Text;
using System.Windows.Forms;
using DataTire;

namespace Digiteq
{
    public partial class frm_sasOrderReferanceUpdate : Form
    {

        
        //to manage update and insert
        static bool IsUpdate = false;

        //to keep form detail       
        string sFormConfigCode;
           public int iFormID;
        public bool bNoAccess;



        #region Form Load
        public frm_sasOrderReferanceUpdate()
        {
            iFormID = clsSecurity.getFormID(FormName.OrderReferanceUpdate);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_sasOrderReferanceUpdate_Load(object sender, EventArgs e)
        {
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
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            ValidateEmptyForeignKey();
                                
                            string sORefCode = txtOrderRefID.Text;
                            tbl_zOrderRefNo detail = tbl_zOrderRefNo.Select(sORefCode);
                            if (detail != null)
                            {
                                detail.OrderRefNo = txtOrderRefNo.Text.Trim();
                                detail.Customer_ID = txtCustomerName.Tag.ToString();
                                detail.Employee_ID = txtSaelsRep.Tag.ToString();
                                detail.Town_ID = txtTown.Tag.ToString();
                                detail.Route_ID = txtRotue.Tag.ToString(); 
                                detail.Update();
                            }                                
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            clsValidate.WriteErrorLog("", iFormID,ex);
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                            ClearFields();
                        }
                    }
                }
            }

        }
        #endregion

        #region btn JobClose
        private void btnJobClose_Click(object sender, EventArgs e)
        {

            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;
                            ValidateEmptyForeignKey();

                            string sORefCode = txtOrderRefID.Text;
                            tbl_zOrderRefNo detail = tbl_zOrderRefNo.Select(sORefCode);
                            if (detail != null)
                            {
                                detail.IsActive = false;
                                detail.Update();
                            }
                            MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            clsValidate.WriteErrorLog("", iFormID,ex);
                            SEACCException.Show(ex);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                            ClearFields();
                        }
                    }
                }
            }

        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtOrderRefID, true);
            clsCommon.SetEnableDisable_NormalLabel(lblOrderRefID, true); 

            txtOrderRefID.Tag = null;
            txtOrderRefNo.Tag = null;
            txtRotue.Tag = null;
            txtTown.Tag = null;
            txtSaelsRep.Tag = null;
            txtCustomerName.Tag = null;

            txtOrderRefID.Clear();
            txtOrderRefNo.Clear();
            txtRotue.Clear();
            txtTown.Clear();
            txtSaelsRep.Clear();
            txtCustomerName.Clear();
            
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
          //  string strMessage = "";
            bool bStatus = false;

            if (txtOrderRefID.Text != null && txtOrderRefNo.Text != null)
            {
                bStatus = true;
            }

            if (bStatus == false)
            {
                MessageBox.Show("User Needs To Select Atleast One Order Referance No To Settle", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }

        private bool CheckNumberValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            try
            {


            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion


        #region Fill Details
        private void FillDetails(string sID)
        {
            try
            {
                if (sID.Length > 0)
                {
                    tbl_zOrderRefNo detail = tbl_zOrderRefNo.Select(sID);
                    if (detail != null)
                    {
                        //set the update flag and Locked
                        IsUpdate = true;
                        clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtOrderRefID, false);
                        clsCommon.SetEnableDisable_NormalLabel(lblOrderRefID, false);

                        //asign values
                        txtOrderRefID.Text = detail.OrderRefNo_ID;
                        txtOrderRefNo.Text = detail.OrderRefNo;

                        txtRotue.Tag = detail.Route_ID;
                        txtTown.Tag = detail.Town_ID;
                        txtSaelsRep.Tag = detail.Employee_ID;
                        txtCustomerName.Tag = detail.Customer_ID;

                      //  txtRotue.Text      = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Route(detail.Route_ID));
                        txtTown.Text       = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Town(detail.Town_ID));
                        txtSaelsRep.Text   = clsCommon.GetForeignKeyValue(clsGenaralName.getName_SalesRep(detail.Employee_ID));
                        txtCustomerName.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Customer(detail.Customer_ID));
                        
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion


        #region Events KeyDown
        private void txtOrderRefNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_OrderReferanceID();
            }
        }
        private void frm_sasOrderReferanceUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void txtCusOrderNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_OrderReferanceID();
            }
        }
        private void txtSaelsRep_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1)
            {
                Search_SalesExecutiveID();
            }

        }
        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1)
            {
                Search_CustomerID();
            }
        }
        private void txtRotue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_RouteID();
            }

        }
        private void txtTown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_TownID();
            }

        }
        #endregion

        #region Events DoubleClick
        private void txtOrderRefNo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_OrderReferanceID();           
        }
        private void txtCusOrderNo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_OrderReferanceID();
        }
        private void txtCustomerName_DoubleClick(object sender, EventArgs e)
        {
            Search_CustomerID();
        }
        private void txtRotue_DoubleClick(object sender, EventArgs e)
        {
            Search_RouteID();
        }
        private void txtSaelsRep_DoubleClick(object sender, EventArgs e)
        {
            Search_SalesExecutiveID();
        }
        private void txtTown_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Search_TownID();
        }
        #endregion

        #region Search Methods
        private void Search_OrderReferanceID()
        {
            clsSearch.Search_MasterOrderReferance(ref txtOrderRefID,false);
            if (txtOrderRefID.Tag != null && txtOrderRefID.Tag.ToString().Trim().Length > 0)
            {
                txtOrderRefID.Text = txtOrderRefID.Tag.ToString();
                FillDetails(txtOrderRefID.Tag.ToString().Trim());
            }
        }
        private void Search_SalesExecutiveID()
        {
            try
            {
                clsSearch.Search_MasterSalesRep(ref txtSaelsRep);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_RouteID()
        {
            try
            {
                clsSearch.Search_MasterRoute(ref txtRotue);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_TownID()
        {
            try
            {
                clsSearch.Search_MasterTown(ref txtTown);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        private void Search_CustomerID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_CustomerMaster();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    if (frmSearchMaster.s_SearchText.Length > 0)
                        txtCustomerName.Text = frmSearchMaster.s_SearchText;
                    if (frmSearchMaster.s_SearchID.Length > 0)
                    {
                        txtCustomerName.Tag = frmSearchMaster.s_SearchID;
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            try
            {
                clsCommon.ValidateForeignKey(ref txtRotue);
                clsCommon.ValidateForeignKey(ref txtTown);
                clsCommon.ValidateForeignKey(ref txtSaelsRep);
                clsCommon.ValidateForeignKey(ref txtCustomerName);              
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion               
        
    }
}
