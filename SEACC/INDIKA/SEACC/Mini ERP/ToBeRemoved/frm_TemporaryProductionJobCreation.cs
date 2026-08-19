using DataTire;
using Digiteq_Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Digiteq
{
    public partial class frm_TemporaryProductionJobCreation : Form
    {
        #region Variables
        public int iFormID = 0;
        public bool bNoAccess = false;
        bool IsUpdate = false;
        #endregion

        #region Form Load
        public frm_TemporaryProductionJobCreation()
        {
            iFormID = clsSecurity.getFormID(FormName.TemporaryProductionJobCreation);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent();
        }
        private void frm_TemporaryProductionJobCreation_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "Temporary Production Job Creation  ", 2, iFormID);
            ClearFields();
        }
        #endregion

        #region button Click Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckValidity_EmptyField())
            {
                if (JobNoValidation(txtTpJobNo.Text.Trim()))
                {
                    if (clsSecurity.PermissionToSave(clsSecurity.UserIDLoged, iFormID, IsUpdate))
                    {
                        if (IsUpdate)
                        {
                        }
                        else
                        {
                            try
                            {
                                if (txtFinishedGoodItem.Tag == null)
                                    txtFinishedGoodItem.Tag = "default";

                                //tbl_pmsProductionJobRegister oProduction = new tbl_pmsProductionJobRegister(txtTpJobNo.Text, dtmTeporyP_JobDate.Value, txtFinishedGoodItemDescription.Text, "default", txtFinishedGoodItem.Tag.ToString(), "default", "default", "default", "default", "default", "default", "default", 0, 0, dtmTeporyP_JobDate.Value.Date.AddDays(-3), DateTime.MaxValue, DateTime.MaxValue, DateTime.MaxValue, "default", "default", "default", "default", DateTime.MaxValue, DateTime.MaxValue, DateTime.MaxValue, DateTime.MaxValue, true, true, true, false, false, true, true, true, false, false, "default", 0, 1, 1);
                                //oProduction.Insert();
                                //MessageBox.Show("Record added Successfully....!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //ClearFields();
                            }
                            catch (Exception )
                            {
                                
                                throw;
                            }
                        }
                    }
                }
            }
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Event Double Click
        private void txtFinishedGoodItem_DoubleClick(object sender, EventArgs e)
        {
            //clsSearch.Search_ItemMaster(ref txtFinishedGoodItem);//clsAutocode.getItemTypeID(ItemTypes.FinishGood)
            //if (txtFinishedGoodItem.Tag != null)
            //    FillDetails(txtFinishedGoodItem.Tag.ToString(), true);
        }
        #endregion

        #region Fill Detail
        private void FillDetails(string FinishedGoodItem, bool bFinishedGoods)
        {
            if (bFinishedGoods)
            {
                if (txtFinishedGoodItem.Tag != null && txtFinishedGoodItem.Tag.ToString().Length > 0)
                {
                    tbl_genItemMaster oItem = tbl_genItemMaster.Select(txtFinishedGoodItem.Tag.ToString());
                    if (oItem != null && oItem.Item_ID != "defult")
                        txtFinishedGoodItemDescription.Text = oItem.Description;
                }
            }

        }
        #endregion

        #region Clear
        private void ClearFields()
        {
            IsUpdate = false;
            txtFinishedGoodItem.Clear();
            txtFinishedGoodItem.Tag = null;
            txtTpJobNo.Clear();
            txtFinishedGoodItemDescription.Clear();
        }
        #endregion

        #region Validation
        private bool CheckValidity_EmptyField()
        {
            bool bStatus = false;
            if (clsValidate.ValidateTextBox_EmptyValue(txtTpJobNo, "Temporary Production Job No"))
            {
                //if (clsValidate.ValidateTextBox_Tag_CannotBeEmptyOrDefault(txtFinishedGoodItem, "Finished Goods Item"))
                //{
                    bStatus = true;
                //}
            }
            return bStatus;
        }

        private bool JobNoValidation(string sjobNo)
        {
            bool bStatus = true;
            tbl_pmsProductionJobRegister oProduction = tbl_pmsProductionJobRegister.Select(txtTpJobNo.Text.Trim());
            if (oProduction != null && oProduction.ProductionJob_ID != "default")
            {
                bStatus = false;
                MessageBox.Show("Sorry Already this Job No Exist Please enter new Job No", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
              
            return bStatus;
        } 
        #endregion

    }
}
