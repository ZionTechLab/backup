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
    public partial class frm_toolReplaceDefaultValuesAllMaster : Form
    {
        #region Public variables
       public int iFormID; 
        #endregion

        #region Form Load
        private void frm_toolCheckToDepositeMode1_Load(object sender, EventArgs e)
        {
            ClearFields();
        }

        public frm_toolReplaceDefaultValuesAllMaster()
        {
            InitializeComponent();
        } 
        #endregion

        #region  Btn Login
        private void btnLogon_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor = Cursors.WaitCursor;
                if (UpdateRecords())
                {
                    ClearFields();
                    MessageBox.Show("All Tables Updated Succesfull.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ClearFields();
                    MessageBox.Show("Table Update is Faild Pls Fix the Problem and Try Again.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
               SEACCException.Show(ex);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        } 
        #endregion

        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region btn Reset
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        } 
        #endregion


        
        #region Clear Fields
        private void ClearFields()
        {
           
        }
        #endregion

        #region Update All Records
        private bool UpdateRecords()
        {
            bool bValue = true;
            try
            {
                #region tbl_zAccCostCenter1
                {
                    tbl_zAccCostCenter1 detail = tbl_zAccCostCenter1.Select("default");
                    if (detail != null)
                    {
                        detail.CostCenter1Name = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zAccCostCenter2
                {
                    tbl_zAccCostCenter2 detail = tbl_zAccCostCenter2.Select("default");
                    if (detail != null)
                    {
                        detail.CostCenter2Name = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zAccGLMaster_AccountType
                {
                    tbl_zAccGLMaster_AccountType detail = tbl_zAccGLMaster_AccountType.Select("default");
                    if (detail != null)
                    {
                        detail.GlAccountTypeName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zAccGLMaster_MainCatagory
                {
                    tbl_zAccGLMaster_MainCatagory detail = tbl_zAccGLMaster_MainCatagory.Select("default");
                    if (detail != null)
                    {
                        detail.GlMainCatagoryName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zAccGLMaster_SubCatagory
                {
                    tbl_zAccGLMaster_SubCatagory detail = tbl_zAccGLMaster_SubCatagory.Select("default");
                    if (detail != null)
                    {
                        detail.GlSubCatagoryName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zAccJournalVoucherType
                {
                    tbl_zAccJournalVoucherType detail = tbl_zAccJournalVoucherType.Select("default");
                    if (detail != null)
                    {
                        detail.JournalEntryName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zAccPostingStatus
                {
                    tbl_zAccPostingStatus detail = tbl_zAccPostingStatus.Select("default");
                    if (detail != null)
                    {
                        detail.PostingStatusName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zAccSlotCategory
                {
                    tbl_zAccSlotCategory detail = tbl_zAccSlotCategory.Select("default");
                    if (detail != null)
                    {
                        detail.SlotCategoryName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zArea
                {
                    tbl_zArea detail = tbl_zArea.Select("default");
                    if (detail != null)
                    {
                        detail.AreaName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zAssistant
                {
                    tbl_zAssistant detail = tbl_zAssistant.Select("default");
                    if (detail != null)
                    {
                        detail.AssistantName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zAuditCategory
                {
                    tbl_zAuditCategory detail = tbl_zAuditCategory.Select("default");
                    if (detail != null)
                    {
                        detail.AuditCategoryName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zBank
                {
                    tbl_zBank detail = tbl_zBank.Select("default");
                    if (detail != null)
                    {
                        detail.BankName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zBankBranches
                {
                    tbl_zBankBranches detail = tbl_zBankBranches.Select("default");
                    if (detail != null)
                    {
                        detail.BranchName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zBatchApprovalStatus
                {
                    tbl_zBatchApprovalStatus detail = tbl_zBatchApprovalStatus.Select("default");
                    if (detail != null)
                    {
                        detail.BatchApprovalStatus = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zBrand
                {
                    tbl_zBrand detail = tbl_zBrand.Select("default");
                    if (detail != null)
                    {
                        detail.BrandName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zChequeStatus
                {
                    tbl_zChequeStatus detail = tbl_zChequeStatus.Select("default");
                    if (detail != null)
                    {
                        detail.StatusName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zChequeType
                {
                    tbl_zChequeType detail = tbl_zChequeType.Select("default");
                    if (detail != null)
                    {
                        detail.TypeName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zCity
                {
                    tbl_zCity detail = tbl_zCity.Select("default");
                    if (detail != null)
                    {
                        detail.CityName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zColour
                {
                    tbl_zColour detail = tbl_zColour.Select("default");
                    if (detail != null)
                    {
                        detail.ColourName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zCost_Center1
                {
                    tbl_zCost_Center1 detail = tbl_zCost_Center1.Select("default");
                    if (detail != null)
                    {
                        detail.Cost_Center1_Name = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zCost_Center2
                {
                    tbl_zCost_Center2 detail = tbl_zCost_Center2.Select("default");
                    if (detail != null)
                    {
                        detail.Cost_Center2_Name = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zCost_Center3
                {
                    tbl_zCost_Center3 detail = tbl_zCost_Center3.Select("default");
                    if (detail != null)
                    {
                        detail.Cost_Center3_Name = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zCost_Center4
                {
                    tbl_zCost_Center4 detail = tbl_zCost_Center4.Select("default");
                    if (detail != null)
                    {
                        detail.Cost_Center4_Name = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zCostingType
                {
                    tbl_zCostingType detail = tbl_zCostingType.Select("default");
                    if (detail != null)
                    {
                        detail.CostingTypeName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zCountry
                {
                    tbl_zCountry detail = tbl_zCountry.Select("default");
                    if (detail != null)
                    {
                        detail.CountryName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zCreditNoteType
                {
                    tbl_zCreditNoteType detail = tbl_zCreditNoteType.Select("default");
                    if (detail != null)
                    {
                        detail.CreditNoteTypeName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zCurrency
                {
                    tbl_zCurrency detail = tbl_zCurrency.Select("default");
                    if (detail != null)
                    {
                        detail.CurrencyName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zCustomerCategory
                {
                    tbl_zCustomerCategory detail = tbl_zCustomerCategory.Select("default");
                    if (detail != null)
                    {
                        detail.CategoryName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zCustomerClass
                {
                    tbl_zCustomerClass detail = tbl_zCustomerClass.Select("default");
                    if (detail != null)
                    {
                        detail.ClassName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zCustomerType
                {
                    tbl_zCustomerType detail = tbl_zCustomerType.Select("default");
                    if (detail != null)
                    {
                        detail.TypeName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zDebitNoteType
                {
                    tbl_zDebitNoteType detail = tbl_zDebitNoteType.Select("default");
                    if (detail != null)
                    {
                        detail.DebitNoteTypeName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zDistrict
                {
                    tbl_zDistrict detail = tbl_zDistrict.Select("default");
                    if (detail != null)
                    {
                        detail.DistrictName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zDriver
                {
                    tbl_zDriver detail = tbl_zDriver.Select("default");
                    if (detail != null)
                    {
                        detail.DriverName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_ZEmpAreaManager
                {
                    tbl_ZEmpAreaManager detail = tbl_ZEmpAreaManager.Select("default");
                    if (detail != null)
                    {
                        detail.AreaManagerName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zEmpAssistant
                {
                    tbl_zEmpAssistant detail = tbl_zEmpAssistant.Select("default");
                    if (detail != null)
                    {
                        detail.AssistantName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zEmpOperator
                {
                    tbl_zEmpOperator detail = tbl_zEmpOperator.Select("default");
                    if (detail != null)
                    {
                        detail.OperatorName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_ZEmpSalesExecutive
                {
                    tbl_ZEmpSalesExecutive detail = tbl_ZEmpSalesExecutive.Select("default");
                    if (detail != null)
                    {
                        detail.SalesExecutiveName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_ZEmpSalesManager
                {
                    tbl_ZEmpSalesManager detail = tbl_ZEmpSalesManager.Select("default");
                    if (detail != null)
                    {
                        detail.SalesManagerName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_ZEmpSalesRep
                {
                    tbl_ZEmpSalesRep detail = tbl_ZEmpSalesRep.Select("default");
                    if (detail != null)
                    {
                        detail.SelesRepName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zEmpSupervisor
                {
                    tbl_zEmpSupervisor detail = tbl_zEmpSupervisor.Select("default");
                    if (detail != null)
                    {
                        detail.SupervisorName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zIssuedRefNo
                {
                    tbl_zIssuedRefNo detail = tbl_zIssuedRefNo.Select("default");
                    if (detail != null)
                    {
                        detail.IssuedRefNo = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zItemCategory
                {
                    tbl_zItemCategory detail = tbl_zItemCategory.Select("default");
                    if (detail != null)
                    {
                        detail.CategoryName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zItemCategory_Sub
                {
                    tbl_zItemCategory_Sub detail = tbl_zItemCategory_Sub.Select("default");
                    if (detail != null)
                    {
                        detail.CategorySubName = "";
                        detail.Update();
                    }
                }
                #endregion

                #region tbl_zItemClass
                {
                    tbl_zItemClass detail = tbl_zItemClass.Select("default");
                    if (detail != null)
                    {
                        detail.ClassName = "";
                        detail.Update();
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                bValue = false;
                clsValidate.WriteErrorLog("", iFormID,ex);
               SEACCException.Show(ex);
            }
            return bValue;
        }
        #endregion       
    }
}
