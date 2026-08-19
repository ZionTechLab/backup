using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;


namespace Digiteq
{
    public partial class frm_sasPreCosting : Form
    {
        #region Variables
        //to manage update and insert
        static bool IsUpdate = false;
        static bool IsUpdateMaterial = false;
        static bool IsUpdateMachine = false;
        static bool IsUpdateEmployee = false;

        //form manage
        string sFormConfigCode;
           public int iFormID;

        //for security handle
        public bool bNoAccess;
        public bool bHasChecked;
        public bool bHasApproved;
        DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        DateTime glbCheckedDate = clsSecurity.getServerDateTime();
        #endregion

        #region Form Load
        public frm_sasPreCosting()
        {
            sFormConfigCode = clsAutocode.getFormConfigCode(FormName.PreCosting);
            iFormID = clsSecurity.getFormID(FormName.PreCosting);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }

        private void frm_sasPreCosting_Load(object sender, EventArgs e)
        {
            //add data to the datagrid and format            
            CusDataGridViewFormat();
            ClearFields();        
        } 
        #endregion

        #region Btn New
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        #endregion

        #region Btn Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPreCostingCode.TextLength > 0)
                {
                    if (clsSecurity.PermissionToDelete(clsSecurity.UserIDLoged, iFormID))
                    {
                        //delete one record
                        Cursor = Cursors.WaitCursor;
                        tbl_sasPreCosting detail = tbl_sasPreCosting.Select(txtPreCostingCode.Text.Trim());
                        if (detail != null)
                        {
                            detail.IsDeleted = true;
                            detail.DateModified = clsSecurity.getServerDateTime();
                            detail.ModifiedUser_ID = clsSecurity.UserIDLoged;
                            detail.Update();
                        }

                        Cursor = Cursors.Default;
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.DeleteDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                    }
                    else //if no permission to delete
                    {
                        MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToDelete), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
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

                            if (IsUpdate)  //update records
                            {
                                tbl_sasPreCosting oldRecord = tbl_sasPreCosting.Select(txtPreCostingCode.Text.Trim());
                                if (oldRecord != null)
                                {
                                    #region Material
                                    tbl_sasPreCosting_Material.DeleteAllByPreCosting_ID(txtPreCostingCode.Text.Trim());
                                    foreach (DataGridViewRow row in dgvDetailMaterial.Rows)
                                    {
                                        string sItemCode = "", sUom = "default";
                                        decimal dWidth = 0, dLength = 0, dGauge = 0, dGussest = 0, dKiloPrice = 0, dAmount = 0,
                                            dQuantity = 0, dWeight = 0, dWeightCalculated = 0;

                                        sItemCode = clsValidate.ValidateGridValue(dgvDetailMaterial, "ItemCode", row.Index, "");
                                        dWidth = clsValidate.ValidateGridValue(dgvDetailMaterial, "Width", row.Index, decimal.Parse("0.00"));
                                        dLength = clsValidate.ValidateGridValue(dgvDetailMaterial, "Height", row.Index, decimal.Parse("0.00"));
                                        dGussest = clsValidate.ValidateGridValue(dgvDetailMaterial, "Gusset", row.Index, decimal.Parse("0.00"));
                                        dGauge = clsValidate.ValidateGridValue(dgvDetailMaterial, "Gauge", row.Index, decimal.Parse("0.00"));
                                        dKiloPrice = clsValidate.ValidateGridValue(dgvDetailMaterial, "KiloPrice", row.Index, decimal.Parse("0.00"));
                                        dQuantity = clsValidate.ValidateGridValue(dgvDetailMaterial, "Quantity", row.Index, decimal.Parse("0.00"));
                                        dWeight = clsValidate.ValidateGridValue(dgvDetailMaterial, "Weight", row.Index, decimal.Parse("0.00"));
                                        dWeightCalculated = clsValidate.ValidateGridValue(dgvDetailMaterial, "WeightCalculated", row.Index, decimal.Parse("0.00"));
                                        sUom = clsValidate.ValidateGridTag(dgvDetailMaterial, "Uom", row.Index, "");
                                        dAmount = clsValidate.ValidateGridValue(dgvDetailMaterial, "Amount", row.Index, decimal.Parse("0.00"));

                                        if (sItemCode.Length > 0)
                                        {
                                            tbl_sasPreCosting_Material items = new tbl_sasPreCosting_Material(row.Index, txtPreCostingCode.Text.Trim(), sItemCode,
                                                sUom, dWidth, dLength, dGauge, dGussest, dQuantity, dWeight, dWeightCalculated, dKiloPrice, dAmount);
                                            items.Insert();
                                        }
                                    } 
                                    #endregion

                                    #region Employee
                                    int Mac_LineNo = -1;
                                    string Mac_MachineID = "default";
                                    bool Mac_HasEmployees = false, bLockMachine = false;
                                    if (dgvDetailMachine.SelectedRows.Count > 0)
                                    {
                                        Mac_LineNo = clsValidate.ValidateGridValue(dgvDetailMachine, "macLineNo", dgvDetailMachine.SelectedRows[0].Index, -1);
                                        Mac_MachineID = clsValidate.ValidateGridValue(dgvDetailMachine, "MachineCode", dgvDetailMachine.SelectedRows[0].Index, "");
                                    }
                                    tbl_sasPreCosting_Labour.DeleteAllByLine_No_PreCosting_ID_Machine_ID(Mac_LineNo, txtPreCostingCode.Text.Trim(), Mac_MachineID);
                                    foreach (DataGridViewRow row in dgvDetailEmployeMachine.Rows)
                                    {
                                        string sEmployeeCode = "default";
                                        decimal dHours = 0, dHoursPercentage = 0, dRate = 0, dCost = 0;
                                        sEmployeeCode = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "EmployeeCode", row.Index, "");
                                        dCost = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "EmpCost", row.Index, decimal.Parse("0.00"));
                                        dHours = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "EmpHours", row.Index, decimal.Parse("0.00"));
                                        dHoursPercentage = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "EmpPercentageHours", row.Index, decimal.Parse("0.00"));
                                        dRate = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "EmpCostPerHour", row.Index, decimal.Parse("0.00"));
                                        if (sEmployeeCode.Length > 0)
                                        {
                                            tbl_sasPreCosting_Labour items = new tbl_sasPreCosting_Labour(row.Index, Mac_LineNo, txtPreCostingCode.Text.Trim(), Mac_MachineID,
                                                sEmployeeCode, "default", dHours, dRate, dCost, dHoursPercentage);
                                            items.Insert();
                                            Mac_HasEmployees = true;
                                            bLockMachine = true;
                                        }
                                    }
                                    if (bLockMachine)
                                    {
                                        tbl_sasPreCosting_Machine detailMachine = tbl_sasPreCosting_Machine.Select(Mac_LineNo, txtPreCostingCode.Text.Trim(), Mac_MachineID);
                                        if (detailMachine != null)
                                        {
                                            detailMachine.IsLocked = true;
                                            detailMachine.HasEmployees = Mac_HasEmployees;
                                            detailMachine.Update();
                                        }
                                    } 
                                    #endregion

                                    #region Machine
                                    List<tbl_sasPreCosting_Machine> mDetails = tbl_sasPreCosting_Machine.SelectAllByPreCosting_ID(txtPreCostingCode.Text.Trim());
                                    foreach (tbl_sasPreCosting_Machine mDetail in mDetails)
                                    {
                                        if (!mDetail.IsLocked)
                                            mDetail.Delete();
                                    }
                                    foreach (DataGridViewRow row in dgvDetailMachine.Rows)
                                    {
                                        string sMachineCode = "default";
                                        decimal dHours = 0, dRate = 0, dCost = 0;
                                        sMachineCode = clsValidate.ValidateGridValue(dgvDetailMachine, "MachineCode", row.Index, "");
                                        dHours = clsValidate.ValidateGridValue(dgvDetailMachine, "MachineHours", row.Index, decimal.Parse("0.00"));
                                        dRate = clsValidate.ValidateGridValue(dgvDetailMachine, "MachineHourlyRate", row.Index, decimal.Parse("0.00"));
                                        dCost = clsValidate.ValidateGridValue(dgvDetailMachine, "MachineCost", row.Index, decimal.Parse("0.00"));

                                        if (sMachineCode.Length > 0)
                                        {
                                            tbl_sasPreCosting_Machine machinedetail = tbl_sasPreCosting_Machine.Select(row.Index, txtPreCostingCode.Text.Trim(), sMachineCode);
                                            if (machinedetail == null)
                                            {
                                                tbl_sasPreCosting_Machine items = new tbl_sasPreCosting_Machine(row.Index, txtPreCostingCode.Text.Trim(), sMachineCode,
                                                    dRate, dHours, dCost, false, false);
                                                items.Insert();
                                            }
                                        }
                                    } 
                                    #endregion

                                    #region PreCosting Header
                                    tbl_sasPreCosting detail = new tbl_sasPreCosting(txtPreCostingCode.Text.Trim(), dtpPreCostingDate.Value, txtOrderedRemark.Text.Trim(),
                                        txtOrderedJobCode.Text.Trim(), decimal.Parse(txtOrderedMaterialCost.Text.Trim()), decimal.Parse(txtOrderedMachineCost.Text.Trim()),
                                        decimal.Parse(txtOrderedLabourCost.Text.Trim()), decimal.Parse(txtOrderedOtherCost.Text.Trim()), decimal.Parse(txtOrderedTotalCost.Text.Trim()),
                                        decimal.Parse(txtOrderedRejection.Text.Trim()), decimal.Parse(txtOrderedRejectionPercentage.Text.Trim()), decimal.Parse(txtOrderedKiloPrice.Text.Trim()),
                                        oldRecord.CreateUser_ID, clsSecurity.UserIDLoged, txtCheckedBy.Tag.ToString(), txtApprovedBy.Tag.ToString(), oldRecord.DateCreate,
                                        clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, oldRecord.IsFinished, oldRecord.IsDeleted, oldRecord.IsLocked);
                                    detail.Update(); 
                                    #endregion

                                    #region Job Register
                                    tbl_sasJobRegister job = tbl_sasJobRegister.Select(txtOrderedJobCode.Text.Trim());
                                    if (job != null)
                                    {
                                        if (bHasApproved)
                                            job.IsSTSCostingConfirmed = true;
                                        job.IsLocked = true;
                                        if (clsCommon.isCurrency(txtOrderedKiloPrice.Text.Trim()))
                                            job.KiloPrice = decimal.Parse(txtOrderedKiloPrice.Text.Trim());
                                        job.Update();
                                    } 
                                    #endregion
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else  //insert records
                            {
                                if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                                    txtPreCostingCode.Text = clsAutocode.getAutoGeneratedCode(sFormConfigCode);

                                if (txtPreCostingCode.TextLength > 0)
                                {
                                    #region PreCosting Header
                                    tbl_sasPreCosting detail = new tbl_sasPreCosting(txtPreCostingCode.Text.Trim(), dtpPreCostingDate.Value, txtOrderedRemark.Text.Trim(),
                                        txtOrderedJobCode.Text.Trim(), decimal.Parse(txtOrderedMaterialCost.Text.Trim()), decimal.Parse(txtOrderedMachineCost.Text.Trim()),
                                        decimal.Parse(txtOrderedLabourCost.Text.Trim()), decimal.Parse(txtOrderedOtherCost.Text.Trim()), decimal.Parse(txtOrderedTotalCost.Text.Trim()),
                                        decimal.Parse(txtOrderedRejection.Text.Trim()), decimal.Parse(txtOrderedRejectionPercentage.Text.Trim()), decimal.Parse(txtOrderedKiloPrice.Text.Trim()),
                                        clsSecurity.UserIDLoged, clsSecurity.UserIDLoged, txtCheckedBy.Tag.ToString(), txtApprovedBy.Tag.ToString(), clsSecurity.getServerDateTime(),
                                        clsSecurity.getServerDateTime(), glbCheckedDate, glbApprovedDate, bHasChecked, bHasApproved, false, false, false);
                                    detail.Insert(); 
                                    #endregion

                                    #region Job Register
                                    tbl_sasJobRegister job = tbl_sasJobRegister.Select(txtOrderedJobCode.Text.Trim());
                                    if (job != null)
                                    {
                                        if (bHasApproved)
                                            job.IsSTSCostingConfirmed = true;
                                        job.IsLocked = true;
                                        if (clsCommon.isCurrency(txtOrderedKiloPrice.Text.Trim()))
                                            job.KiloPrice = decimal.Parse(txtOrderedKiloPrice.Text.Trim());
                                        job.Update();
                                    } 
                                    #endregion

                                    #region Material
                                    foreach (DataGridViewRow row in dgvDetailMaterial.Rows)
                                    {
                                        string sItemCode = "", sUom = "default";
                                        decimal dWidth = 0, dLength = 0, dGauge = 0, dGussest = 0, dKiloPrice = 0, dAmount = 0,
                                            dQuantity = 0, dWeight = 0, dWeightCalculated = 0;

                                        sItemCode = clsValidate.ValidateGridValue(dgvDetailMaterial, "ItemCode", row.Index, "");
                                        dWidth = clsValidate.ValidateGridValue(dgvDetailMaterial, "Width", row.Index, decimal.Parse("0.00"));
                                        dLength = clsValidate.ValidateGridValue(dgvDetailMaterial, "Height", row.Index, decimal.Parse("0.00"));
                                        dGussest = clsValidate.ValidateGridValue(dgvDetailMaterial, "Gusset", row.Index, decimal.Parse("0.00"));
                                        dGauge = clsValidate.ValidateGridValue(dgvDetailMaterial, "Gauge", row.Index, decimal.Parse("0.00"));
                                        dKiloPrice = clsValidate.ValidateGridValue(dgvDetailMaterial, "KiloPrice", row.Index, decimal.Parse("0.00"));
                                        dQuantity = clsValidate.ValidateGridValue(dgvDetailMaterial, "Quantity", row.Index, decimal.Parse("0.00"));
                                        dWeight = clsValidate.ValidateGridValue(dgvDetailMaterial, "Weight", row.Index, decimal.Parse("0.00"));
                                        dWeightCalculated = clsValidate.ValidateGridValue(dgvDetailMaterial, "WeightCalculated", row.Index, decimal.Parse("0.00"));
                                        sUom = clsValidate.ValidateGridTag(dgvDetailMaterial, "Uom", row.Index, "");
                                        dAmount = clsValidate.ValidateGridValue(dgvDetailMaterial, "Amount", row.Index, decimal.Parse("0.00"));

                                        if (sItemCode.Length > 0)
                                        {
                                            tbl_sasPreCosting_Material items = new tbl_sasPreCosting_Material(row.Index, txtPreCostingCode.Text.Trim(), sItemCode,
                                                sUom, dWidth, dLength, dGauge, dGussest, dQuantity, dWeight, dWeightCalculated, dKiloPrice, dAmount);
                                            items.Insert();
                                        }
                                    } 
                                    #endregion
                                    
                                    #region Machine
                                    foreach (DataGridViewRow row in dgvDetailMachine.Rows)
                                    {
                                        string sMachineCode = "default";
                                        decimal dHours = 0, dRate = 0, dCost = 0;
                                        sMachineCode = clsValidate.ValidateGridValue(dgvDetailMachine, "MachineCode", row.Index, "");
                                        dHours = clsValidate.ValidateGridValue(dgvDetailMachine, "MachineHours", row.Index, decimal.Parse("0.00"));
                                        dRate = clsValidate.ValidateGridValue(dgvDetailMachine, "MachineHourlyRate", row.Index, decimal.Parse("0.00"));
                                        dCost = clsValidate.ValidateGridValue(dgvDetailMachine, "MachineCost", row.Index, decimal.Parse("0.00"));

                                        if (sMachineCode.Length > 0)
                                        {
                                            tbl_sasPreCosting_Machine items = new tbl_sasPreCosting_Machine(row.Index, txtPreCostingCode.Text.Trim(), sMachineCode,
                                                dRate, dHours, dCost, false, false);
                                            items.Insert();
                                        }
                                    } 
                                    #endregion

                                    #region Employee
                                    int Mac_LineNo = -1;
                                    string Mac_MachineID = "default";
                                    bool Mac_HasEmployees = false, bLockMachine = false;
                                    if (dgvDetailMachine.SelectedRows.Count > 0)
                                    {
                                        Mac_LineNo = clsValidate.ValidateGridValue(dgvDetailMachine, "macLineNo", dgvDetailMachine.SelectedRows[0].Index, -1);
                                        Mac_MachineID = clsValidate.ValidateGridValue(dgvDetailMachine, "MachineCode", dgvDetailMachine.SelectedRows[0].Index, "");
                                    }
                                    tbl_sasPreCosting_Labour.DeleteAllByLine_No_PreCosting_ID_Machine_ID(Mac_LineNo, txtPreCostingCode.Text.Trim(), Mac_MachineID);
                                    foreach (DataGridViewRow row in dgvDetailEmployeMachine.Rows)
                                    {
                                        string sEmployeeCode = "default";
                                        decimal dHours = 0, dHoursPercentage = 0, dRate = 0, dCost = 0;
                                        sEmployeeCode = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "EmployeeCode", row.Index, "");
                                        dCost = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "EmpCost", row.Index, decimal.Parse("0.00"));
                                        dHours = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "EmpHours", row.Index, decimal.Parse("0.00"));
                                        dHoursPercentage = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "EmpPercentageHours", row.Index, decimal.Parse("0.00"));
                                        dRate = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "EmpCostPerHour", row.Index, decimal.Parse("0.00"));
                                        if (sEmployeeCode.Length > 0)
                                        {
                                            tbl_sasPreCosting_Labour items = new tbl_sasPreCosting_Labour(row.Index, Mac_LineNo, txtPreCostingCode.Text.Trim(), Mac_MachineID,
                                                sEmployeeCode, "default", dHours, dRate, dCost, dHoursPercentage);
                                            items.Insert();
                                            Mac_HasEmployees = true;
                                            bLockMachine = true;
                                        }
                                    }
                                    if (bLockMachine)
                                    {
                                        tbl_sasPreCosting_Machine detailMachine = tbl_sasPreCosting_Machine.Select(Mac_LineNo, txtPreCostingCode.Text.Trim(), Mac_MachineID);
                                        if (detailMachine != null)
                                        {
                                            detailMachine.IsLocked = true;
                                            detailMachine.HasEmployees = Mac_HasEmployees;
                                            detailMachine.Update();
                                        }
                                    }
                                    #endregion
                                    MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.SaveDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Good Receive Note " + clsFormatter.GetMessageFrom(MessageType.IDIsEmpty), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            clsValidate.WriteErrorLog("", iFormID,ex);
                        }
                        finally
                        {
                            tbl_sasPreCosting detail = tbl_sasPreCosting.Select(txtPreCostingCode.Text.Trim());
                            if (detail != null)
                                FillDetails(detail.PreCosting_ID);
                            Cursor = Cursors.Default;
                        }
                    }
                }
            }
        }
        #endregion

        #region Btn Print
        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
        #endregion


        #region Datagrid Format
        private void CusDataGridViewFormat()
        {
            clsFormatter.ApplyGridFormat(dgvDetailMaterial);
            clsFormatter.ApplyGridFormat(dgvDetailMachine);
            clsFormatter.ApplyGridFormat(dgvDetailEmployeMachine);
            clsFormatter.ApplyGridFormat(dgvDetailEmployeeOther);
            clsFormatter.ApplyGridFormat(dgvDetailEmployeTotal);            
        }
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            //set the flag and enble the id
            IsUpdate = false;
            clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPreCostingCode, true);
            clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtOrderedJobCode, true);
            clsCommon.SetEnableDisable_NormalLabel(lblPreCostingCode, true);
            clsCommon.SetEnableDisable_NormalLabel(lblOrderedJobCode, true);
            clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);           

            txtOrderedJobCode.Tag = null;
            txtOrderedJobCodeTemplate.Tag = null;

            txtOrderedCustomerID.Clear();
            txtOrderedGauge.Text = "0";
            txtOrderedGussest.Text = "0";
            txtOrderedHeight.Text = "0";
            txtOrderedJobCode.Clear();
            txtOrderedJobCodeTemplate.Clear();
            txtOrderedKiloPrice.Text = "0.00";
            txtOrderedLabourCost.Text = "0.00";
            txtOrderedMachineCost.Text = "0.00";
            txtOrderedMaterialCost.Text = "0.00";
            txtOrderedOtherCost.Text = "0.00";
            txtOrderedProductName.Clear();
            txtOrderedQty.Clear();
            txtOrderedRejection.Text = "0.00";
            txtOrderedRejectionPercentage.Text = "0";
            txtOrderedRemark.Clear();
            txtOrderedTotalCost.Text = "0.00";
            txtOrderedUOM.Clear();
            txtOrderedWeight.Text = "0";
            txtOrderedWidth.Text = "0";

            chkOrderedRejection.Checked = false;


            clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
            clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
            clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);
            txtPreparedBy.Tag = null;
            txtCheckedBy.Tag = null;
            txtApprovedBy.Tag = null;
            txtApprovedBy.Clear();
            txtCheckedBy.Clear();
            txtPreparedBy.Clear();
            bHasApproved = false;
            bHasChecked = false;

            dgvDetailEmployeeOther.Rows.Clear();
            dgvDetailEmployeMachine.Rows.Clear();
            dgvDetailEmployeTotal.Rows.Clear();
            dgvDetailMachine.Rows.Clear();
            dgvDetailMaterial.Rows.Clear();

            ClearFieldsMaterial();
            ClearFieldsMachine();

            if (clsAutocode.IsAutoGenerated(sFormConfigCode))
                txtPreCostingCode.Text = "<Auto Generate>";
            else
                txtPreCostingCode.Clear();
            if (txtPreCostingCode.Enabled)
            {
                txtPreCostingCode.SelectAll();
                txtPreCostingCode.Focus();
            }
        }
        #endregion

        #region Clear Fields Material
        private void ClearFieldsMaterial()
        {
            //set the flag and enble the id
            IsUpdateMaterial = false;

            txtmatItemCode.Tag = null;
            txtmatUOMCode.Tag = null;

            txtmatCostLast.Clear();
            txtmatCostMax.Clear();
            txtmatCostWaitedAverage.Clear();
            txtmatGauge.Clear();         
            txtmatItemCode.Clear();
            txtmatQuantity.Clear();
            txtmatStockBalance.Clear();
            txtmatUOMCode.Clear();
            txtmatWeight.Clear();
            txtmatCostPrice.Clear();
            txtmatRowNo.Clear();
            txtmatCalculatedWeight.Clear();
            txtmatTotalCostPrice.Clear();

            clsCommon.SetEnableDisable_NormalTextbox(txtmatGauge, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtmatQuantity, false);
            clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtmatUOMCode, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtmatCostPrice, false);
            clsCommon.SetEnableDisable_NormalTextbox(txtmatWeight, false);
            clsCommon.SetEnableDisable_NormalLabel(lblmatGauge, false);
            clsCommon.SetEnableDisable_NormalLabel(lblmatQuantity, false);
            clsCommon.SetEnableDisable_NormalLabel(lblmatCostPrice, false);
            clsCommon.SetEnableDisable_NormalLabel(lblmatWeight, false);
            
            if (txtmatItemCode.Enabled)
            {
                txtmatItemCode.SelectAll();
                txtmatItemCode.Focus();
            }
        }
        #endregion

        #region Clear Fields Machine
        private void ClearFieldsMachine()
        {
            //set the flag and enble the id
            IsUpdateMachine = false;

            txtmacMachineCode.Tag = null;
            txtmacMachineName.Tag = null;

            txtmacMachineCode.Clear();
            txtmacMachineName.Clear();
            txtmacCostPerHour.Text = "0.00";
            txtmacMachineCost.Text = "0.00";
            txtmacMachineHours.Text = "0";
            txtmacRowNo.Clear();

            if (txtmacMachineCode.Enabled)
            {
                txtmacMachineCode.SelectAll();
                txtmacMachineCode.Focus();
            }
        }
        #endregion

        #region Clear Fields Employee
        private void ClearFieldsEmployee()
        {
            //set the flag and enble the id
            IsUpdateEmployee = false;

            txtmacEmployeeName.Tag = null;

            txtmacEmployeeName.Clear();            
            txtempCostPerHour.Text = "0.00";
            txtempCost.Text = "0.00";
            txtmacEmployeeHours.Text = "0";
            txtmacEmployeeHoursPercentage.Text = "0";
            txtempRowNo.Clear();

            if (txtmacEmployeeName.Enabled)
            {
                txtmacEmployeeName.SelectAll();
                txtmacEmployeeName.Focus();
            }
        }
        #endregion

        #region Refresh Grid 
        private void RefreshGridMaterial(string sPreCostingID)
        {
            try
            {
                int iRow;
                dgvDetailMaterial.Rows.Clear();

                List<tbl_sasPreCosting_Material> details = tbl_sasPreCosting_Material.SelectAllByPreCosting_ID(sPreCostingID);
                foreach (tbl_sasPreCosting_Material detail in details)
                {
                    dgvDetailMaterial.Rows.Add();
                    iRow = dgvDetailMaterial.Rows.Count - 1;

                    dgvDetailMaterial["ItemCode", iRow].Value = detail.Item_ID;
                    dgvDetailMaterial["ItemName", iRow].Value = clsGenaralName.getName_Item(detail.Item_ID);
                    dgvDetailMaterial["Width", iRow].Value = detail.Width.ToString();
                    dgvDetailMaterial["Height", iRow].Value = detail.Height.ToString();
                    dgvDetailMaterial["Gusset", iRow].Value = detail.Gusset.ToString();
                    dgvDetailMaterial["Gauge", iRow].Value = detail.Gauge.ToString();
                    dgvDetailMaterial["UOM", iRow].Tag = detail.Uom_ID;
                    dgvDetailMaterial["UOM", iRow].Value = clsGenaralName.getName_Uom(detail.Uom_ID);
                    dgvDetailMaterial["Quantity", iRow].Value = detail.Qty.ToString();
                    dgvDetailMaterial["Weight", iRow].Value = detail.Weight.ToString();
                    dgvDetailMaterial["WeightCalculated", iRow].Value = detail.WeightCalculated.ToString();
                    dgvDetailMaterial["KiloPrice", iRow].Value = detail.CostPrice.ToString();
                    dgvDetailMaterial["Amount", iRow].Value = detail.Amount.ToString();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RefreshGridMachine(string sPreCostingID)
        {
            try
            {
                int iRow;
                dgvDetailMachine.Rows.Clear();

                List<tbl_sasPreCosting_Machine> details = tbl_sasPreCosting_Machine.SelectAllByPreCosting_ID(sPreCostingID);
                foreach (tbl_sasPreCosting_Machine detail in details)
                {
                    dgvDetailMachine.Rows.Add();
                    iRow = dgvDetailMachine.Rows.Count - 1;
                    dgvDetailMachine["macLineNo", iRow].Value = iRow.ToString();
                    dgvDetailMachine["MachineCode", iRow].Value = detail.Machine_ID;
                    dgvDetailMachine["MachineName", iRow].Value = clsGenaralName.getName_MachineMaster(detail.Machine_ID);
                    dgvDetailMachine["MachineHourlyRate", iRow].Value = detail.MachineCostPerHour.ToString();
                    dgvDetailMachine["MachineHours", iRow].Value = detail.MachineHours.ToString();
                    dgvDetailMachine["MachineCost", iRow].Value = detail.MachineCostTotal.ToString();
                }

                if (dgvDetailMachine.SelectedRows.Count > 0)
                {
                    FillDetailsMachine(dgvDetailMachine.SelectedRows[0].Index);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }
        private void RefreshGridEmployeeByMachineID(string sPreCostingID, string sMachineID, int iLineNo)
        {
            try
            {
                int iRow;
                dgvDetailEmployeMachine.Rows.Clear();

                List<tbl_sasPreCosting_Labour> details = tbl_sasPreCosting_Labour.SelectAllByLine_No_PreCosting_ID_Machine_ID(iLineNo, sPreCostingID, sMachineID);
                foreach (tbl_sasPreCosting_Labour detail in details)
                {
                    dgvDetailEmployeMachine.Rows.Add();
                    iRow = dgvDetailEmployeMachine.Rows.Count - 1;

                    dgvDetailEmployeMachine["empLineNo", iRow].Value = iRow.ToString();
                    dgvDetailEmployeMachine["empLineNoMachine", iRow].Value = detail.Line_No.ToString();
                    dgvDetailEmployeMachine["EmployeeCode", iRow].Value = detail.Employee_ID;
                    dgvDetailEmployeMachine["EmployeeName", iRow].Value = clsGenaralName.getName_Employee(detail.Employee_ID);
                    dgvDetailEmployeMachine["EmpCost", iRow].Value = detail.EmployeeCostTotal.ToString();
                    dgvDetailEmployeMachine["EmpHours", iRow].Value = detail.EmployeeHours.ToString();
                    dgvDetailEmployeMachine["EmpPercentageHours", iRow].Value = detail.EmployeeHoursPercentage.ToString();
                    dgvDetailEmployeMachine["EmpCostPerHour", iRow].Value = detail.EmployeeCostPerHour.ToString();
                    dgvDetailEmployeMachine["EmpMachineID", iRow].Value = detail.Machine_ID.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }

        }
        #endregion

        #region Fill Details
        private void FillDetails(string sID)
        {
            if (sID.Length > 0)
            {
                tbl_sasPreCosting detail = tbl_sasPreCosting.Select(sID);
                if (detail != null)
                {
                    //set the update flag and Locked
                    IsUpdate = true;
                    clsCommon.SetEnableDisable_PrimaryKeyTextbox(txtPreCostingCode, false);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtOrderedJobCode, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblPreCostingCode, false);
                    clsCommon.SetEnableDisable_NormalLabel(lblOrderedJobCode, false);

                    //asign values
                    txtOrderedJobCode.Tag = detail.Job_ID;
                    txtOrderedJobCodeTemplate.Tag = detail.Job_ID;

           
                    txtOrderedJobCode.Text = detail.Job_ID;
                    txtOrderedJobCodeTemplate.Text = detail.Job_ID;
                    txtOrderedKiloPrice.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.KiloPrice);
                    txtOrderedLabourCost.Text = detail.CostLabour.ToString();
                    txtOrderedMachineCost.Text = detail.CostMachine.ToString();
                    txtOrderedMaterialCost.Text = detail.CostMaterial.ToString();
                    txtOrderedOtherCost.Text = detail.CostOther.ToString();
                    txtOrderedRejection.Text = detail.RejectionCost.ToString();
                    txtOrderedRejectionPercentage.Text = detail.RejectionCostPercentage.ToString();
                    txtOrderedRemark.Text = detail.Remark;
                    txtOrderedTotalCost.Text = detail.CostTotal.ToString();

                    txtApprovedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.ApprovedUser_ID));
                    txtCheckedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CheckedUser_ID));
                    txtPreparedBy.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_User(detail.CreateUser_ID));
                    txtPreparedBy.Tag = detail.CreateUser_ID;
                    txtCheckedBy.Tag = detail.CheckedUser_ID;
                    txtApprovedBy.Tag = detail.ApprovedUser_ID;
                    if (detail.IsApproved)
                    {
                        bHasApproved = true;
                        glbApprovedDate = detail.DateApproved;
                        dtpDateApprovedBy.Value = detail.DateApproved;
                        dtpTimeApprovedBy.Value = detail.DateApproved;
                        clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, false);
                        clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, false);
                    }
                    if (detail.IsChecked)
                    {
                        bHasChecked = true;
                        glbCheckedDate = detail.DateChecked;
                        dtpDateCheckedBy.Value = detail.DateChecked;
                        dtpTimeCheckedBy.Value = detail.DateChecked;
                        clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, false);
                        clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, false);
                    }
                    dtpDatePreparedBy.Value = detail.DateCreate;
                    dtpTimePreparedBy.Value = detail.DateCreate;

                    //fill item Job
                    FillDetailsJobDetail(detail.Job_ID);

                    //Fill Grids
                    RefreshGridMaterial(detail.PreCosting_ID);
                    RefreshGridMachine(detail.PreCosting_ID);
                }
            }
        }
        #endregion

        #region Fill Job Details
        private void FillDetailsJobDetail(string sJobID)
        {
            try
            {
                if (sJobID.Length > 0)
                {
                    tbl_sasJobRegister detail = tbl_sasJobRegister.Select(sJobID);
                    if (detail != null)
                    {
                        txtOrderedCustomerID.Text = clsGenaralName.getName_Customer(detail.Customer_ID);
                        txtOrderedProductName.Text = clsGenaralName.getName_Item(detail.Item_ID);
                        txtOrderedUOM.Text = clsGenaralName.getName_Uom(detail.Uom_ID);
                        txtOrderedWeight.Text = clsFormatter.FormatToNumberWithFourDecimalPlaces(detail.Weight);
                        txtOrderedQty.Text = clsFormatter.FormatToNumberWithFourDecimalPlaces(detail.Qty);
                    }

                    tbl_genItemMaster item = tbl_genItemMaster.Select(detail.Item_ID);
                    if (item != null)
                    {
                        txtOrderedGauge.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(item.Thickness);
                        txtOrderedGussest.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(item.Gusset);
                        txtOrderedHeight.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(item.Height);
                        txtOrderedWidth.Text = clsFormatter.FormatToNumberWithOneDecimalPlaces(item.Width);
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Fill Item Details
        private void FillDetailsItem(int iRow)
        {
            try
            {
                //set the update flag and Locked
                IsUpdateMaterial = true;
                clsCommon.SetEnableDisable_NormalTextbox(txtmatGauge, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtmatQuantity, true);
                clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtmatUOMCode, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtmatCostPrice, true);
                clsCommon.SetEnableDisable_NormalTextbox(txtmatWeight, true);
                clsCommon.SetEnableDisable_NormalLabel(lblmatGauge, true);
                clsCommon.SetEnableDisable_NormalLabel(lblmatQuantity, true);
                clsCommon.SetEnableDisable_NormalLabel(lblmatCostPrice, true);
                clsCommon.SetEnableDisable_NormalLabel(lblmatWeight, true);


                txtmatItemCode.Tag = dgvDetailMaterial["ItemCode", iRow].Value.ToString();
                txtmatItemCode.Text = dgvDetailMaterial["ItemName", iRow].Value.ToString();
                txtmatGauge.Text = dgvDetailMaterial["Gauge", iRow].Value.ToString();
                txtmatUOMCode.Text = dgvDetailMaterial["UOM", iRow].Value.ToString();
                txtmatUOMCode.Tag = dgvDetailMaterial["UOM", iRow].Tag.ToString();
                txtmatQuantity.Text = dgvDetailMaterial["Quantity", iRow].Value.ToString();
                txtmatWeight.Text = dgvDetailMaterial["Weight", iRow].Value.ToString();
                txtmatCalculatedWeight.Text = dgvDetailMaterial["WeightCalculated", iRow].Value.ToString();
                txtmatCostPrice.Text = dgvDetailMaterial["KiloPrice", iRow].Value.ToString();
                txtmatTotalCostPrice.Text = clsFormatter.FormatToCurrecyWithThousendSep(decimal.Parse(dgvDetailMaterial["Amount", iRow].Value.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }
        private void FillDetailsItemDetail(string sItemID)
        {
            if (sItemID.Length > 0)
            {
                tbl_genItemMaster detail = tbl_genItemMaster.Select(sItemID);
                if (detail != null)
                {
                    clsCommon.SetEnableDisable_NormalTextbox(txtmatGauge, true);
                    clsCommon.SetEnableDisable_NormalTextbox(txtmatQuantity, true);
                    clsCommon.SetEnableDisable_ForeignKeyTextboxOptional(txtmatUOMCode, true);
                    clsCommon.SetEnableDisable_NormalTextbox(txtmatCostPrice, true);
                    clsCommon.SetEnableDisable_NormalTextbox(txtmatWeight, true);
                    clsCommon.SetEnableDisable_NormalLabel(lblmatGauge, true);
                    clsCommon.SetEnableDisable_NormalLabel(lblmatQuantity, true);                    
                    clsCommon.SetEnableDisable_NormalLabel(lblmatCostPrice, true);
                    clsCommon.SetEnableDisable_NormalLabel(lblmatWeight, true);

                  //  txtmatCostLast.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.RecentCostPrice);
                   // txtmatCostMax.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.CostPrice);
                  //  txtmatCostWaitedAverage.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.WaitedAverageCostPrice);
                  //  txtmatCostPrice.Text = clsFormatter.FormatToCurrecyWithThousendSep(detail.WaitedAverageCostPrice);
                    txtmatUOMCode.Tag = detail.Uom_ID;
                    txtmatUOMCode.Text = clsCommon.GetForeignKeyValue(clsGenaralName.getName_Uom(detail.Uom_ID));
                    txtmatGauge.Text = txtOrderedGauge.Text.Trim();

                    decimal dGauge = 1, dQuantity = 1;                   
                    if (clsCommon.isCurrency(txtOrderedGauge.Text.Trim()))
                        dGauge = decimal.Parse(txtOrderedGauge.Text.Trim());                    
                    CalculateMaterialWeight(dGauge, dQuantity, detail.Uom_ID);
                    CalculateMaterialAmount();
                }
            }
        }
        private void CalculateMaterialWeight(decimal dGauge, decimal dQuantity, string sUomID)
        {
            decimal dWidth = 1, dLength = 1, dGussest = 1;
            if (clsCommon.isCurrency(txtOrderedWidth.Text.Trim()))
                dWidth = decimal.Parse(txtOrderedWidth.Text.Trim());
            if (clsCommon.isCurrency(txtOrderedHeight.Text.Trim()))
                dLength = decimal.Parse(txtOrderedHeight.Text.Trim());
            if (clsCommon.isCurrency(txtOrderedGussest.Text.Trim()))
                dGussest = decimal.Parse(txtOrderedGussest.Text.Trim());                           
            txtmatCalculatedWeight.Text = clsFormatter.FormatToNumberWithFourDecimalPlaces(clsHelpMethods.GetWeight(dWidth, dLength, dGauge, dGussest, dQuantity, sUomID));
            txtmatWeight.Text = txtmatCalculatedWeight.Text.Trim();
        }
        private void CalculateMaterialAmount()
        {
            decimal dCostPrice = 0, dWeight = 0, dAmount = 0;            
            if (clsCommon.isCurrency(txtmatCostPrice.Text.Trim()))
                dCostPrice = decimal.Parse(txtmatCostPrice.Text.Trim());
            if (clsCommon.isCurrency(txtmatWeight.Text.Trim()))
                dWeight = decimal.Parse(txtmatWeight.Text.Trim());
            dAmount = dCostPrice * dWeight;
            txtmatTotalCostPrice.Text = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
        }
        #endregion

        #region Fill Machine Details
        private void FillDetailsMachine(int iRow)
        {
            try
            {
                //set the update flag and Locked
                IsUpdateMachine = true;
                clsCommon.SetEnableDisable_NormalTextbox(txtmacMachineHours, true);
                clsCommon.SetEnableDisable_NormalLabel(lblmacMachineHours, true);

                string slineNo = dgvDetailMachine["macLineNo", dgvDetailMachine.SelectedRows[0].Index].Value.ToString();
                int iLineNo = -1;
                if (int.TryParse(slineNo, out iLineNo))
                    iLineNo = int.Parse(slineNo);
                else
                    iLineNo = -1;

                txtmacRowNo.Text = iLineNo.ToString();
                txtmacMachineCode.Tag = dgvDetailMachine["MachineCode", iRow].Value.ToString();
                txtmacMachineCode.Text = dgvDetailMachine["MachineCode", iRow].Value.ToString();
                txtmacMachineName.Tag = dgvDetailMachine["MachineCode", iRow].Value.ToString();
                txtmacMachineName.Text = dgvDetailMachine["MachineName", iRow].Value.ToString();
                txtmacCostPerHour.Text = dgvDetailMachine["MachineHourlyRate", iRow].Value.ToString();
                txtmacMachineHours.Text = dgvDetailMachine["MachineHours", iRow].Value.ToString();
                txtmacMachineCost.Text = dgvDetailMachine["MachineCost", iRow].Value.ToString();

                RefreshGridEmployeeByMachineID(txtPreCostingCode.Text.Trim(), txtmacMachineCode.Text.Trim(), iLineNo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }
        private void FillDetailsMachineDetail(string sItemID)
        {
            if (sItemID.Length > 0)
            {
                tbl_genMachineMaster detail = tbl_genMachineMaster.Select(sItemID);
                if (detail != null)
                {
                    txtmacCostPerHour.Text = detail.MachineCostPerHour.ToString();
                    txtmacMachineCode.Text = detail.Machine_ID.ToString();
                    txtmacMachineCode.Tag = detail.Machine_ID.ToString();
                    txtmacMachineName.Text = detail.MachineName.ToString();
                    txtmacMachineName.Tag = detail.Machine_ID.ToString();

                    CalMachineCost();
                }
            }
        }
        private void CalMachineCost()
        {
            decimal dRate = 0, dHours = 0, dCost = 0;
            if (clsCommon.isCurrency(txtmacCostPerHour.Text.Trim()))
                dRate = decimal.Parse(txtmacCostPerHour.Text.Trim());
            if (clsCommon.isCurrency(txtmacMachineHours.Text.Trim()))
                dHours = decimal.Parse(txtmacMachineHours.Text.Trim());
            dCost = dRate * dHours;
            txtmacMachineCost.Text = dCost.ToString();
        }
       
        #endregion

        #region Fill Employe Detail
        private void FillDetailsEmployee(int iRow)
        {
            try
            {
                //set the update flag and Locked
                IsUpdateEmployee = true;

                txtempRowNo.Text = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "empLineNo", dgvDetailEmployeMachine.SelectedRows[0].Index, int.Parse("-1")).ToString();
                txtempMachineRowNo.Text = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "empLineNoMachine", dgvDetailEmployeMachine.SelectedRows[0].Index, int.Parse("-1")).ToString();
                txtmacEmployeeName.Tag = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "EmployeeCode", dgvDetailEmployeMachine.SelectedRows[0].Index, "");
                txtmacEmployeeName.Text = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "EmployeeName", dgvDetailEmployeMachine.SelectedRows[0].Index, "");
                txtempCost.Text = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "EmpCost", dgvDetailEmployeMachine.SelectedRows[0].Index, decimal.Parse("0.00")).ToString();
                txtmacEmployeeHours.Text = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "EmpHours", dgvDetailEmployeMachine.SelectedRows[0].Index, decimal.Parse("0.00")).ToString();
                txtmacEmployeeHoursPercentage.Text = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "EmpPercentageHours", dgvDetailEmployeMachine.SelectedRows[0].Index, decimal.Parse("0.00")).ToString();
                txtempCostPerHour.Text = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "EmpCostPerHour", dgvDetailEmployeMachine.SelectedRows[0].Index, decimal.Parse("0.00")).ToString();
                txtempMachineID.Text = clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "EmpMachineID", dgvDetailEmployeMachine.SelectedRows[0].Index, "");        
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }
        private void FillDetailsEmployeeDetail(string sEmpID)
        {
            try
            {
                if (sEmpID.Length > 0)
                {
                    tbl_genEmployeeMaster detail = tbl_genEmployeeMaster.Select(sEmpID);
                    if (detail != null)
                    {
                        txtmacEmployeeName.Tag = detail.Employee_ID;
                        txtmacEmployeeName.Text = detail.EmployeeName;
                        txtempCostPerHour.Text = detail.EmployeeCostPerHour.ToString();

                        //txtempMachineRowNo.Text = clsValidate.ValidateGridValue(dgvDetailMachine, "empLineNoMachine", dgvDetailMachine.SelectedRows[0].Index, int.Parse("-1")).ToString();
                        txtempMachineRowNo.Text = clsValidate.ValidateGridValue(dgvDetailMachine, "macLineNo", dgvDetailMachine.SelectedRows[0].Index, int.Parse("-1")).ToString();
                        txtempMachineID.Text = clsValidate.ValidateGridValue(dgvDetailMachine, "MachineCode", dgvDetailMachine.SelectedRows[0].Index, "");

                        CalemployeeCost();
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalemployeeCost()
        {
            try
            {
                decimal dRate = 0, dHours = 0, dCost = 0;
                if (clsCommon.isCurrency(txtempCostPerHour.Text.Trim()))
                    dRate = decimal.Parse(txtempCostPerHour.Text.Trim());
                if (clsCommon.isCurrency(txtmacEmployeeHours.Text.Trim()))
                    dHours = decimal.Parse(txtmacEmployeeHours.Text.Trim());
                dCost = dRate * dHours;
                txtempCost.Text = dCost.ToString();
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion


        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;
            try
            {
                if (txtOrderedJobCode.TextLength == 0)
                {
                    strMessage += "\n" + "Job Code ";
                    bStatus = false;
                }
                if (bStatus == false)
                {
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return bStatus;
        }
        #endregion

        #region Validate Empty Foreignkey
        private void ValidateEmptyForeignKey()
        {
            clsCommon.ValidateForeignKey(ref txtOrderedJobCode);
            clsCommon.ValidateForeignKey(ref txtOrderedJobCodeTemplate);
            clsCommon.ValidateForeignKey(ref txtCheckedBy);
            clsCommon.ValidateForeignKey(ref txtApprovedBy);
        }
        #endregion

        #region Events Keydown
        private void txtPreCostingCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_PreCostingID();
            }
        }

        private void txtOrderedJobCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_JobID();
            }
        }

        private void txtOrderedJobCodeTemplate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtmatItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ItemID();
            }
        }

        private void txtmatUOMCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_UomID();
            }
        }

        private void txtmacMachineCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_MachineID();
            }
        }

        private void txtmacMachineName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_MachineID();
            }
        }

        private void txtmacEmployeeName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_EmployeeID();
            }
        }

        private void txtlabEmployeeName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_EmployeeIDOther();
            }
        }

        private void txtlabCostType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CostingType();
            }
        }
        private void txtApprovedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_ApprovedBy();
            }
        }

        private void txtCheckedBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Search_CheckedBy();
            }
        }
        private void frm_sasPreCosting_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        } 
        #endregion

        #region Events DoubleClick
        private void txtPreCostingCode_DoubleClick(object sender, EventArgs e)
        {
            Search_PreCostingID();
        }

        private void txtOrderedJobCode_DoubleClick(object sender, EventArgs e)
        {
            Search_JobID();
        }

        private void txtOrderedJobCodeTemplate_DoubleClick(object sender, EventArgs e)
        {

        }

        private void txtmatItemCode_DoubleClick(object sender, EventArgs e)
        {
            Search_ItemID();
        }

        private void txtmatUOMCode_DoubleClick(object sender, EventArgs e)
        {
            Search_UomID();
        }

        private void txtmacMachineCode_DoubleClick(object sender, EventArgs e)
        {
            Search_MachineID();
        }

        private void txtmacMachineName_DoubleClick(object sender, EventArgs e)
        {
            Search_MachineID();
        }

        private void txtmacEmployeeName_DoubleClick(object sender, EventArgs e)
        {
            Search_EmployeeID();
        }

        private void txtlabEmployeeName_DoubleClick(object sender, EventArgs e)
        {
            Search_EmployeeIDOther();
        }

        private void txtlabCostType_DoubleClick(object sender, EventArgs e)
        {
            Search_CostingType();
        }
        private void txtCheckedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_CheckedBy();
        }
        private void txtApprovedBy_DoubleClick(object sender, EventArgs e)
        {
            Search_ApprovedBy();
        }   
        #endregion     

        #region Search Methods
        private void Search_PreCostingID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchTransaction();
                clsSearch.passValue_PreCosting();
                frmhelpsearch.ShowDialog();

                if (frmSearchTransaction.s_SearchID.Length > 0)
                {
                    txtPreCostingCode.Text = frmSearchTransaction.s_SearchID;
                    FillDetails(frmSearchTransaction.s_SearchID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Search_JobID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchTransaction();
                clsSearch.passValue_JobRegister_PendingCosting();
                frmhelpsearch.ShowDialog();

                if (frmSearchTransaction.s_SearchID.Length > 0)
                {
                    txtOrderedJobCode.Tag = frmSearchTransaction.s_SearchID;
                    txtOrderedJobCode.Text = frmSearchTransaction.s_SearchID;

                    FillDetailsJobDetail(frmSearchTransaction.s_SearchID);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Search_EmployeeID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_Employee();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchID.Length > 0)
                    FillDetailsEmployeeDetail(frmSearchMaster.s_SearchID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Search_EmployeeIDOther()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_Employee();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtlabEmployeeName.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtlabEmployeeName.Tag = frmSearchMaster.s_SearchID;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Search_CostingType()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_CostingType();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtlabCostType.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                    txtlabCostType.Tag = frmSearchMaster.s_SearchID;
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Search_UomID()
        {
            try
            {
                Form frmhelpsearch = new frmSearchMaster();
                clsSearch.passValue_UomForSales();
                frmhelpsearch.ShowDialog();

                if (frmSearchMaster.s_SearchText.Length > 0)
                    txtmatUOMCode.Text = frmSearchMaster.s_SearchText;
                if (frmSearchMaster.s_SearchID.Length > 0)
                {
                    txtmatUOMCode.Tag = frmSearchMaster.s_SearchID;
                    decimal dGauge = 1, dQuantity = 1;
                    if (clsCommon.isCurrency(txtmatGauge.Text.Trim()))
                        dGauge = decimal.Parse(txtmatGauge.Text.Trim());
                    if (clsCommon.isCurrency(txtmatQuantity.Text.Trim()))
                        dQuantity = decimal.Parse(txtmatQuantity.Text.Trim());
                    CalculateMaterialWeight(dGauge, dQuantity, frmSearchMaster.s_SearchID);
                    CalculateMaterialAmount();
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Search_ItemID()
        {
            try
            {
                if (txtOrderedJobCode.Text.Trim().Length > 0)
                {
                    Form frmhelpsearch = new frmSearchMaster();
                    clsSearch.passValue_ItemMasterByTypeID(clsAutocode.getItemTypeID(ItemTypes.RawMaterial));
                    frmhelpsearch.ShowDialog();

                    if (frmSearchMaster.s_SearchText.Length > 0)
                        txtmatItemCode.Text = frmSearchMaster.s_SearchText;
                    if (frmSearchMaster.s_SearchID.Length > 0)
                    {
                        txtmatItemCode.Tag = frmSearchMaster.s_SearchID;
                        FillDetailsItemDetail(frmSearchMaster.s_SearchID);
                    }
                }
                else
                    MessageBox.Show("Please Select the Job Code before add Materials ", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Search_MachineID()
        {
            try
            {
                clsSearch.Search_MasterMachine(ref txtmacMachineCode);
                if (txtmacMachineCode.Tag != null && txtmacMachineCode.Tag.ToString().Length > 0)
                {
                    txtmacMachineCode.Text = txtmacMachineCode.Tag.ToString();
                    FillDetailsMachineDetail(txtmacMachineCode.Tag.ToString());
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Search_ApprovedBy()
        {
            try
            {
                frmSetApproved login = new frmSetApproved();
                login.iFormID = iFormID;
                login.ShowDialog();
                if (frmSetApproved.bChecked)
                {
                    bHasApproved = true;
                    glbApprovedDate = clsSecurity.getServerDateTime();
                    dtpDateApprovedBy.Value = clsSecurity.getServerDateTime();
                    dtpTimeApprovedBy.Value = clsSecurity.getServerDateTime();
                    txtApprovedBy.Text = frmSetApproved.sApprovedUserName;
                    txtApprovedBy.Tag = frmSetApproved.sApprovedUserID;
                    clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, false);
                    clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, false);


                }
                else if (frmSetApproved.bReset)
                {
                    txtDateApprovedBy.Visible = true;
                    txtApprovedBy.Text = "";
                    txtApprovedBy.Tag = null;
                    bHasApproved = false;
                    clsCommon.SetVisible_PermissionTextBox(txtDateApprovedBy, true);
                    clsCommon.SetVisible_PermissionTextBox(txtTimeApprovedBy, true);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Search_CheckedBy()
        {
            try
            {
                frmSetChecked login = new frmSetChecked();
                login.iFormID = iFormID;
                login.ShowDialog();
                if (frmSetChecked.bChecked)
                {
                    bHasChecked = true;
                    glbCheckedDate = clsSecurity.getServerDateTime();
                    dtpDateCheckedBy.Value = clsSecurity.getServerDateTime();
                    dtpTimeCheckedBy.Value = clsSecurity.getServerDateTime();
                    txtCheckedBy.Text = frmSetChecked.sCheckedUserName;
                    txtCheckedBy.Tag = frmSetChecked.sCheckedUserID;
                    clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, false);
                    clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, false);
                }
                else if (frmSetChecked.bReset)
                {
                    txtCheckedBy.Text = "";
                    txtCheckedBy.Tag = null;
                    bHasChecked = false;
                    clsCommon.SetVisible_PermissionTextBox(txtDateCheckedBy, true);
                    clsCommon.SetVisible_PermissionTextBox(txtTimeCheckedBy, true);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Events KeyUp
        private void txtmatQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (clsCommon.isCurrency(txtmatQuantity.Text.Trim()))
                {
                    decimal dGauge = 1, dQuantity = 1;
                    string sUomID = "default";
                    if (clsCommon.isCurrency(txtmatGauge.Text.Trim()))
                        dGauge = decimal.Parse(txtmatGauge.Text.Trim());
                    if (clsCommon.isCurrency(txtmatQuantity.Text.Trim()))
                        dQuantity = decimal.Parse(txtmatQuantity.Text.Trim());
                    if (txtmatUOMCode.Tag != null && txtmatUOMCode.Tag.ToString().Trim().Length > 0)
                        sUomID = txtmatUOMCode.Tag.ToString().Trim();
                    CalculateMaterialWeight(dGauge, dQuantity, sUomID);
                    CalculateMaterialAmount();
                }
                else
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, "/n Quantity"), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtmatWeight_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (clsCommon.isCurrency(txtmatQuantity.Text.Trim()))
                {
                    decimal dGauge = 1, dQuantity = 1;
                    string sUomID = "default";
                    if (clsCommon.isCurrency(txtmatGauge.Text.Trim()))
                        dGauge = decimal.Parse(txtmatGauge.Text.Trim());
                    if (clsCommon.isCurrency(txtmatQuantity.Text.Trim()))
                        dQuantity = decimal.Parse(txtmatQuantity.Text.Trim());
                    if (txtmatUOMCode.Tag != null && txtmatUOMCode.Tag.ToString().Trim().Length > 0)
                        sUomID = txtmatUOMCode.Tag.ToString().Trim();
                    CalculateMaterialWeight(dGauge, dQuantity, sUomID);
                    CalculateMaterialAmount();
                }
                else
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, "/n Quantity"), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtmatCostPrice_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (clsCommon.isCurrency(txtmatQuantity.Text.Trim()))
                    CalculateMaterialAmount();
                else
                    MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, "/n Kilo Price"), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtmatGauge_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                decimal dGauge = 1, dQuantity = 1;
                string sUomID = "default";
                if (clsCommon.isCurrency(txtmatGauge.Text.Trim()))
                    dGauge = decimal.Parse(txtmatGauge.Text.Trim());
                if (clsCommon.isCurrency(txtmatQuantity.Text.Trim()))
                    dQuantity = decimal.Parse(txtmatQuantity.Text.Trim());
                if (txtmatUOMCode.Tag != null && txtmatUOMCode.Tag.ToString().Trim().Length > 0)
                    sUomID = txtmatUOMCode.Tag.ToString().Trim();
                CalculateMaterialWeight(dGauge, dQuantity, sUomID);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtmacMachineHours_KeyUp(object sender, KeyEventArgs e)
        {
            if (clsCommon.isCurrency(txtmacMachineHours.Text.Trim()))
                CalMachineCost();
            else
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, "/n Machine Hours"), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtmacEmployeeHoursPercentage_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                decimal dPercentage = 0;
                if (clsCommon.isCurrency(txtmacEmployeeHoursPercentage.Text.Trim()))
                {
                    dPercentage = decimal.Parse(txtmacEmployeeHoursPercentage.Text.Trim());
                    if (dPercentage > 0)
                    {
                        CalculateEmployeHourFromMachinePercentage(dPercentage);
                    }
                    else
                    {
                        txtmacEmployeeHoursPercentage.Text = "0";
                        txtmacEmployeeHours.Text = "0";
                    }
                }
                else
                {
                    txtmacEmployeeHoursPercentage.Text = "0";
                    txtmacEmployeeHours.Text = "0";
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtmacEmployeeHours_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                decimal dHours = 0;
                if (clsCommon.isCurrency(txtmacEmployeeHours.Text.Trim()))
                {
                    dHours = decimal.Parse(txtmacEmployeeHours.Text.Trim());
                    if (dHours > 0)
                    {
                        CalculateEmployeHourPercentageFromMachineHour(dHours);
                    }
                    else
                    {
                        txtmacEmployeeHoursPercentage.Text = "0";
                        txtmacEmployeeHours.Text = "0";
                    }
                }
                else
                {
                    txtmacEmployeeHoursPercentage.Text = "0";
                    txtmacEmployeeHours.Text = "0";
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Events Datagrid
        private void dgvDetailMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                FillDetailsItem(e.RowIndex);
                txtmatRowNo.Text = e.RowIndex.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }

        private void dgvDetailMaterial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetailMaterial_CellClick(sender, e);
        }

        private void dgvDetailMachine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                FillDetailsMachine(e.RowIndex);
                txtmacRowNo.Text = e.RowIndex.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }

        private void dgvDetailMachine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetailMachine_CellClick(sender, e);
        }

        private void dgvDetailEmployeMachine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                FillDetailsEmployee(e.RowIndex);
                txtempRowNo.Text = e.RowIndex.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        }

        private void dgvDetailEmployeMachine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDetailEmployeMachine_CellClick(sender, e);
        }
        #endregion

        #region Calculate Methods
        private void CalculateMaterialCost()
        {
            try
            {
                decimal Amount = 0;
                foreach (DataGridViewRow row in dgvDetailMaterial.Rows)
                {
                    if (dgvDetailMaterial["Amount", row.Index].Value != null && dgvDetailMaterial["Amount", row.Index].Value.ToString().Length > 0)
                    {
                        if (clsCommon.isCurrency(dgvDetailMaterial["Amount", row.Index].Value.ToString()))
                            Amount += decimal.Parse(dgvDetailMaterial["Amount", row.Index].Value.ToString());
                    }
                }
                txtOrderedMaterialCost.Text = clsFormatter.FormatToCurrecyWithThousendSep(Amount);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalculateMachineCost()
        {
            try
            {
                decimal Amount = 0;
                foreach (DataGridViewRow row in dgvDetailMachine.Rows)
                {
                    if (dgvDetailMachine["MachineCost", row.Index].Value != null && dgvDetailMachine["MachineCost", row.Index].Value.ToString().Length > 0)
                    {
                        if (clsCommon.isCurrency(dgvDetailMachine["MachineCost", row.Index].Value.ToString()))
                            Amount += decimal.Parse(dgvDetailMachine["MachineCost", row.Index].Value.ToString());
                    }
                }
                txtOrderedMachineCost.Text = clsFormatter.FormatToCurrecyWithThousendSep(Amount);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalculateEmployeeCost()
        {
            try
            {
                decimal Amount = 0;
                foreach (DataGridViewRow row in dgvDetailEmployeMachine.Rows)
                {
                    Amount += clsValidate.ValidateGridValue(dgvDetailEmployeMachine, "EmpCost", row.Index, decimal.Parse("0.00"));
                }
                txtOrderedLabourCost.Text = clsFormatter.FormatToCurrecyWithThousendSep(Amount);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalculateTotalCost()
        {
            try
            {
                decimal dMachineCost = 0;
                decimal dMaterialCost = 0;
                decimal dLabourCost = 0;
                decimal dOtherCost = 0;
                decimal dRejection = 0;
                if (clsCommon.isCurrency(txtOrderedMachineCost.Text))
                    dMachineCost = decimal.Parse(txtOrderedMachineCost.Text.Trim());
                if (clsCommon.isCurrency(txtOrderedMaterialCost.Text.Trim()))
                    dMaterialCost = decimal.Parse(txtOrderedMaterialCost.Text.Trim());
                if (clsCommon.isCurrency(txtOrderedLabourCost.Text.Trim()))
                    dLabourCost = decimal.Parse(txtOrderedLabourCost.Text.Trim());
                if (clsCommon.isCurrency(txtOrderedOtherCost.Text.Trim()))
                    dOtherCost = decimal.Parse(txtOrderedOtherCost.Text.Trim());
                if (clsCommon.isCurrency(txtOrderedRejection.Text.Trim()))
                    dRejection = decimal.Parse(txtOrderedRejection.Text.Trim());

                decimal dGrandTotal = (dMachineCost + dMaterialCost + dLabourCost + dOtherCost) - dRejection;
                txtOrderedTotalCost.Text = clsFormatter.FormatToCurrecyWithThousendSep(dGrandTotal);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalculateKiloPrice()
        {
            try
            {
                decimal dTotalCost = 0;
                decimal dWeight = 1;
                if (clsCommon.isCurrency(txtOrderedTotalCost.Text))
                    dTotalCost = decimal.Parse(txtOrderedTotalCost.Text.Trim());
                if (clsCommon.isCurrency(txtOrderedWeight.Text.Trim()) && decimal.Parse(txtOrderedWeight.Text.Trim()) > 0)
                    dWeight = decimal.Parse(txtOrderedWeight.Text.Trim());


                decimal dKiloPrice = dTotalCost / dWeight;
                txtOrderedKiloPrice.Text = clsFormatter.FormatToCurrecyWithThousendSep(dKiloPrice);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateEmployeHourFromMachinePercentage(decimal dPecentage)
        {
            try
            {
                decimal dMachineHours = 0, dEmployeHours = 0;
                if (clsCommon.isCurrency(txtmacMachineHours.Text.Trim()))
                    dMachineHours = decimal.Parse(txtmacMachineHours.Text.Trim());
                dEmployeHours = dMachineHours * dPecentage / 100;
                txtmacEmployeeHours.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(dEmployeHours);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CalculateEmployeHourPercentageFromMachineHour(decimal dHour)
        {
            try
            {
                decimal dMachineHours = 0, dEmployeHoursPercentage = 0;
                if (clsCommon.isCurrency(txtmacMachineHours.Text.Trim()))
                    dMachineHours = decimal.Parse(txtmacMachineHours.Text.Trim());
                dEmployeHoursPercentage = dHour / dMachineHours * 100;
                txtmacEmployeeHoursPercentage.Text = clsFormatter.FormatToNumberWithTwoDecimalPlaces(dEmployeHoursPercentage);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        #region Btn Clear Material
        private void btnClearMaterial_Click(object sender, EventArgs e)
        {
            ClearFieldsMaterial();
        } 
        #endregion

        #region Btn Remove Material
        private void btnRemoveMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetailMaterial.SelectedCells.Count != 0)
                {
                    if (dgvDetailMaterial.Rows.Count > 1)
                        dgvDetailMaterial.Rows.RemoveAt(dgvDetailMaterial.SelectedCells[0].RowIndex);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        } 
        #endregion

        #region Btn Add Material
        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmatItemCode.Tag != null && txtmatItemCode.Tag.ToString().Trim().Length > 0)
                {
                    int iRow;
                    if (IsUpdateMaterial)
                        iRow = int.Parse(txtmatRowNo.Text.Trim());
                    else
                    {
                        dgvDetailMaterial.Rows.Add();
                        iRow = dgvDetailMaterial.Rows.Count - 1;
                    }
                    decimal dWidth = 0, dHeight = 0, dGussest = 0, dGauge = 0, dQty = 0, dWeight = 0, dWeightPercentage = 0, dKiloPrice = 0, dAmount = 0;
                    dgvDetailMaterial["ItemCode", iRow].Value = txtmatItemCode.Tag.ToString();
                    dgvDetailMaterial["ItemName", iRow].Value = txtmatItemCode.Text.Trim();
                    if (clsCommon.isCurrency(txtOrderedWidth.Text.Trim()))
                        dWidth = decimal.Parse(txtOrderedWidth.Text.Trim());
                    if (clsCommon.isCurrency(txtOrderedHeight.Text.Trim()))
                        dHeight = decimal.Parse(txtOrderedHeight.Text.Trim());
                    if (clsCommon.isCurrency(txtOrderedGussest.Text.Trim()))
                        dGussest = decimal.Parse(txtOrderedGussest.Text.Trim());
                    if (clsCommon.isCurrency(txtmatGauge.Text.Trim()))
                        dGauge = decimal.Parse(txtmatGauge.Text.Trim());
                    if (clsCommon.isCurrency(txtmatQuantity.Text.Trim()))
                        dQty = decimal.Parse(txtmatQuantity.Text.Trim());
                    if (clsCommon.isCurrency(txtmatWeight.Text.Trim()))
                        dWeight = decimal.Parse(txtmatWeight.Text.Trim());
                    if (clsCommon.isCurrency(txtmatCalculatedWeight.Text.Trim()))
                        dWeightPercentage = decimal.Parse(txtmatCalculatedWeight.Text.Trim());
                    if (clsCommon.isCurrency(txtmatCostPrice.Text.Trim()))
                        dKiloPrice = decimal.Parse(txtmatCostPrice.Text.Trim());
                    if (clsCommon.isCurrency(txtmatTotalCostPrice.Text.Trim()))
                        dAmount = decimal.Parse(txtmatTotalCostPrice.Text.Trim());                    


                    dgvDetailMaterial["Width", iRow].Value = dWidth.ToString();
                    dgvDetailMaterial["Height", iRow].Value = dHeight.ToString();
                    dgvDetailMaterial["Gusset", iRow].Value = dGussest.ToString();
                    dgvDetailMaterial["Gauge", iRow].Value = dGauge.ToString();
                    dgvDetailMaterial["UOM", iRow].Value = txtmatUOMCode.Text.Trim();
                    dgvDetailMaterial["UOM", iRow].Tag = txtmatUOMCode.Tag.ToString();
                    dgvDetailMaterial["Quantity", iRow].Value = dQty.ToString();
                    dgvDetailMaterial["Weight", iRow].Value = dWeight.ToString();
                    dgvDetailMaterial["WeightCalculated", iRow].Value = dWeightPercentage.ToString();
                    dgvDetailMaterial["KiloPrice", iRow].Value = dKiloPrice.ToString();
                    dgvDetailMaterial["Amount", iRow].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);

                    ClearFieldsMaterial();
                    CalculateMaterialCost();
                    CalculateTotalCost();
                    CalculateKiloPrice();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        } 
        #endregion


        #region Btn Clear Machine
        private void btnClearMachine_Click(object sender, EventArgs e)
        {
            ClearFieldsMachine();
        } 
        #endregion

        #region Btn Remove Machine
        private void btnRemoveMachine_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetailMachine.SelectedCells.Count != 0)
                {
                    if (dgvDetailMachine.Rows.Count > 1)
                        dgvDetailMachine.Rows.RemoveAt(dgvDetailMachine.SelectedCells[0].RowIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        } 
        #endregion

        #region Btn Add Machine
        private void btnAddMachine_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmacMachineCode.Tag != null && txtmacMachineCode.Tag.ToString().Trim().Length > 0)
                {
                    int iRow;
                    if (IsUpdateMachine)
                        iRow = int.Parse(txtmacRowNo.Text.Trim());
                    else
                    {
                        dgvDetailMachine.Rows.Add();
                        iRow = dgvDetailMachine.Rows.Count - 1;
                    }
                    decimal dHours = 0, dRate = 0, dCost = 0;



                    dgvDetailMachine["macLineNo", iRow].Value = iRow.ToString();
                    dgvDetailMachine["MachineCode", iRow].Value = txtmacMachineCode.Tag.ToString();
                    dgvDetailMachine["MachineName", iRow].Value = txtmacMachineName.Text.Trim();
                    if (clsCommon.isCurrency(txtmacMachineHours.Text.Trim()))
                        dHours = decimal.Parse(txtmacMachineHours.Text.Trim());
                    if (clsCommon.isCurrency(txtmacCostPerHour.Text.Trim()))
                        dRate = decimal.Parse(txtmacCostPerHour.Text.Trim());
                    if (clsCommon.isCurrency(txtmacMachineCost.Text.Trim()))
                        dCost = decimal.Parse(txtmacMachineCost.Text.Trim());

                    dgvDetailMachine["MachineHours", iRow].Value = dHours.ToString();                    
                    dgvDetailMachine["MachineHourlyRate", iRow].Value = dRate.ToString();
                    dgvDetailMachine["MachineCost", iRow].Value = dCost.ToString();


                    ClearFieldsMachine();
                    CalculateMachineCost();
                    CalculateTotalCost();
                    CalculateKiloPrice();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        } 
        #endregion

        #region Btn Clear Employee
        private void btnClearEmployeMachine_Click(object sender, EventArgs e)
        {
            ClearFieldsEmployee();
        } 
        #endregion

        #region Btn Remove Employee
        private void btnRemoveEmployeMachine_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetailEmployeMachine.SelectedCells.Count != 0)
                {
                    if (dgvDetailEmployeMachine.Rows.Count > 1)
                        dgvDetailEmployeMachine.Rows.RemoveAt(dgvDetailEmployeMachine.SelectedCells[0].RowIndex);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Btn Add Employee
        private void btnAddEmployeMachine_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmacEmployeeName.Tag != null && txtmacEmployeeName.Tag.ToString().Trim().Length > 0)
                {
                    int iRow;
                    if (IsUpdateEmployee)
                        iRow = int.Parse(txtempRowNo.Text.Trim());
                    else
                    {
                        dgvDetailEmployeMachine.Rows.Add();
                        iRow = dgvDetailEmployeMachine.Rows.Count - 1;
                    }
                    decimal dHours = 0, dHoursPercentage = 0, dRate = 0, dCost = 0;
                   
                    if (clsCommon.isCurrency(txtmacEmployeeHours.Text.Trim()))
                        dHours = decimal.Parse(txtmacEmployeeHours.Text.Trim());
                    if (clsCommon.isCurrency(txtmacEmployeeHoursPercentage.Text.Trim()))
                        dHoursPercentage = decimal.Parse(txtmacEmployeeHoursPercentage.Text.Trim()); 
                    if (clsCommon.isCurrency(txtempCostPerHour.Text.Trim()))
                        dRate = decimal.Parse(txtempCostPerHour.Text.Trim());
                    if (clsCommon.isCurrency(txtempCost.Text.Trim()))
                        dCost = decimal.Parse(txtempCost.Text.Trim());

                    dgvDetailEmployeMachine["empLineNo", iRow].Value = iRow.ToString();
                    dgvDetailEmployeMachine["empLineNoMachine", iRow].Value = txtempMachineRowNo.Text.Trim();
                    dgvDetailEmployeMachine["EmployeeCode", iRow].Value = txtmacEmployeeName.Tag.ToString();
                    dgvDetailEmployeMachine["EmployeeName", iRow].Value = txtmacEmployeeName.Text.Trim();
                    dgvDetailEmployeMachine["EmpCost", iRow].Value = dCost.ToString();
                    dgvDetailEmployeMachine["EmpHours", iRow].Value = dHours.ToString();
                    dgvDetailEmployeMachine["EmpPercentageHours", iRow].Value = dHoursPercentage.ToString();
                    dgvDetailEmployeMachine["EmpCostPerHour", iRow].Value = dRate.ToString();
                    dgvDetailEmployeMachine["EmpMachineID", iRow].Value = txtempMachineID.Text.Trim();

                    ClearFieldsEmployee();
                    CalculateEmployeeCost();
                    CalculateTotalCost();
                    CalculateKiloPrice();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                clsValidate.WriteErrorLog("", iFormID,ex);
            }
        } 
        #endregion

        

      



        





       



    }
}
