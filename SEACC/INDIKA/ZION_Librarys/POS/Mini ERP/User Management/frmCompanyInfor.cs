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
using System.IO;
using Digiteq.User_Management;

namespace Digiteq
{
    public partial class frmCompanyInfor : SEACC_Form
    {
        #region Variables
        //to manage update and insert
        //static bool IsUpdate = false;

        //form manage
      //  string sFormConfigCode;
           //public int iFormID;

        //for security handle
        //public bool bNoAccess;
        public bool bHasChecked;
        public bool bHasApproved;
        DateTime glbApprovedDate = clsSecurity.getServerDateTime();
        DateTime glbCheckedDate = clsSecurity.getServerDateTime();

        Byte[] imgM = new byte[0];
        Byte[] imgL = new byte[0];
        Byte[] imgT = new byte[0];
        string s_FileNameMain;
        string s_FileNameLogo;
        string s_FileNameText;
        #endregion

        #region Form Load
        public frmCompanyInfor(FormName _enmForm)
        {          
            //iFormID = clsSecurity.getFormID(FormName.CompanyInfor);
            //if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            //{
            //    bNoAccess = true;
            //}
            enmForm = _enmForm;
            InitializeComponent();
            Initialize();
        }

        private void frmCompanyInfor_Load(object sender, EventArgs e)
        {
            //format Form
            SetVisibility_ActionButons(false, false, false, true, false, false, false, false, false);
            cusFormat();

            string compnayID = clsSecurity.CompanyID;
            FillDetails(compnayID);
        }
        #endregion

        #region Btn Save
        private void frmCompanyInfor_SF_saveButton_Click(object sender, EventArgs e)
        {
            if (CheckValidity())
            {
                if (CheckNumberValidity())
                {
                    try
                    {
                        Cursor = Cursors.WaitCursor;
                        Byte[] img = new byte[0];

                        if (IsUpdate)  //update records
                        {
                            tbl_genCompanyInfo oldRecord = tbl_genCompanyInfo.Select(txtCompanyID.Text.Trim());
                            if (oldRecord != null)
                            {                                
                                //tbl_genCompanyAccount.DeleteAllByCompanyID(txtCompanyID.Text.Trim());
                                //for (int x = 0; x < dgvAccounts.Rows.Count; x++)
                                //{
                                //    try
                                //    {
                                //         string BankID = "default", BranchID = "default", AccountNo = "", GLCode = "default";
                                            
                                //            if (dgvAccounts["BankName", x].Tag != null)
                                //                BankID  = dgvAccounts["BankName", x].Tag.ToString();
                                //            if (dgvAccounts["BranchName", x].Tag != null)
                                //                BranchID = dgvAccounts["BranchName", x].Tag.ToString();
                                //            if (dgvAccounts["AccountNo", x].Value != null)
                                //                AccountNo = dgvAccounts["AccountNo", x].Value.ToString();
                                //           if (dgvAccounts["AccBalance", x].Value != null)
                                //               GLCode = dgvAccounts["AccBalance", x].Value.ToString();                                                                                
                                //        tbl_genCompanyAccount account = new tbl_genCompanyAccount(txtCompanyID.Text.Trim(), AccountNo, BankID, BranchID, 0, GLCode);
                                //        account.Insert();
                                //    }
                                //    catch (Exception) { }//error may come because last row of the grid may not have information
                                //}
                                //Company Master                                
                                tbl_genCompanyInfo detail = new tbl_genCompanyInfo(txtCompanyID.Text.Trim(), clsCript.Encrypt(txtCompanyName.Text.Trim()),
                                    clsCript.Encrypt(txtAddress.Text.Trim()), txtTelephone1.Text.Trim(), txtTelephone2.Text.Trim(), txtTelephone3.Text.Trim(),
                                    txtFax.Text.Trim(), txtEmail.Text.Trim(), txtUrl.Text.Trim(), txtRegVat.Text.Trim(), txtMDName.Text.Trim(),
                                    txtSVATRegistrationNo.Text.Trim(), "", txtRegBusiness.Text.Trim(), oldRecord.Edition, txtSerialNumber1.Text.Trim(), txtSerialNumber2.Text.Trim(),
                                    txtSerialNumber3.Text.Trim(), txtSerialNumber3.Text.Trim(), txtFinancialYear.Tag.ToString(), cmbMonth.Text.ToString(), dateTimePicker1.Value, oldRecord.Theme_ID, oldRecord.ProductKey);
                                detail.Update();

                                tbl_genCompanyImage oldRec = tbl_genCompanyImage.Select(txtCompanyID.Text.Trim());
                                if (oldRec != null)
                                {
                                    if (s_FileNameMain != null && s_FileNameMain.Length > 0)
                                    {
                                        FileStream fs = new FileStream(s_FileNameMain, FileMode.Open);
                                        imgM = new Byte[fs.Length];
                                        fs.Read(imgM, 0, (int)fs.Length);
                                        fs.Close();
                                    }
                                    else
                                    {
                                        imgM = oldRec.MainLogo;
                                    }

                                    if (s_FileNameLogo != null && s_FileNameLogo.Length > 0)
                                    {
                                        FileStream fs = new FileStream(s_FileNameLogo, FileMode.Open);
                                        imgL = new Byte[fs.Length];
                                        fs.Read(imgL, 0, (int)fs.Length);
                                        fs.Close();
                                    }
                                    else
                                    {
                                        imgL = oldRec.LogoOnly;
                                    }

                                    if (s_FileNameText != null && s_FileNameText.Length > 0)
                                    {
                                        FileStream fs = new FileStream(s_FileNameText, FileMode.Open);
                                        imgT = new Byte[fs.Length];
                                        fs.Read(imgT, 0, (int)fs.Length);
                                        fs.Close();
                                    }
                                    else
                                    {
                                        imgT = oldRec.TextOnly;
                                    }

                                    tbl_genCompanyImage imgDet = new tbl_genCompanyImage(txtCompanyID.Text.Trim(), imgM, imgL, imgT);
                                    imgDet.Update();
                                }
                                clsHelpMethods.InsertTransactionHistory(iFormID, txtCompanyID.Text, TxnActivity.Insert);
                                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.ModifyDone), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
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
                        FillDetails(txtCompanyID.Text.Trim());
                    }
                }
            }
        }
        #endregion

        #region Btn LoadImage
        private void btnMain_Click(object sender, EventArgs e)
        {
            FileDialog filedialog = new OpenFileDialog();
            filedialog.ShowDialog();
            s_FileNameMain = filedialog.FileName;
            imgMain.ImageLocation = s_FileNameMain;
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            FileDialog filedialog = new OpenFileDialog();
            filedialog.ShowDialog();
            s_FileNameLogo = filedialog.FileName;
            imgLogo.ImageLocation = s_FileNameLogo;
        }

        private void btnText_Click(object sender, EventArgs e)
        {
            FileDialog filedialog = new OpenFileDialog();
            filedialog.ShowDialog();
            s_FileNameText = filedialog.FileName;
            imgText.ImageLocation = s_FileNameText;
        }
        #endregion

        #region Datagrid Format
        private void cusFormat()
        {
         //   clsFormatter.ApplyGridFormatModify(dgvAccounts, clsFormatter.colorDigiteqTheamColorAdminHeaderColour, clsFormatter.colorDigiteqTheamColorAdminForColour, Color.Gray);

            z1.BackColor = clsFormatter.colorDigiteqTheamColorAdmin;
          //  z2.BackColor = clsFormatter.colorDigiteqTheamColorAdmin;
            z3.BackColor = clsFormatter.colorDigiteqTheamColorAdmin;

        }
        #endregion
   
        #region Fill Details
        private void FillDetails(string sID)
        {
            if (sID.Length > 0)
            {
                tbl_genCompanyInfo detail = tbl_genCompanyInfo.Select(sID);
                if (detail != null)
                {
                    //set the update flag and Locked
                    IsUpdate = true;
                    txtCompanyID.Enabled = false;
                    txtAddress.Enabled = true;

                    //asign values
                    txtCompanyID.Text = detail.CompanyID;

                    //txtAddress.Text = clsSecurity.decryptPassword(detail.Address);
                    // txtAddress.Text = clsSecurity.CompanyAddress1;


                    txtAddress.Text = clsCript.Decrypt(detail.Address);

                    //txtBalance.Text = "0.00";  

                    //txtCompanyName.Text = clsSecurity.decryptPassword(detail.CompanyName);                    
                    // txtCompanyName.Text = clsSecurity.CompanyName;
                    txtCompanyName.Text = clsCript.Decrypt(detail.CompanyName);

                    txtEmail.Text = detail.Email;
                    txtFax.Text = detail.Fax;

                    txtMDName.Text = detail.CompanyMDName;
                    txtSVATRegistrationNo.Text = detail.MdTelephone;

                    txtRegBusiness.Text = detail.BusinessRegisterNo;
                    txtRegVat.Text = detail.VatRegisterNo;
                    txtTelephone1.Text = detail.Telephone1;
                    txtTelephone2.Text = detail.Telephone2;
                    txtTelephone3.Text = detail.Telephone3;
                    txtUrl.Text = detail.Url;
                    txtFinancialYear.Text = clsGenaralName.getName_FinancialYear(detail.FinancialYear_ID);
                    txtFinancialYear.Tag = detail.FinancialYear_ID;
                    cmbMonth.Text = detail.Month_ID;

                    //Image   
                    tbl_genCompanyImage comImg = tbl_genCompanyImage.Select(sID);
                    if (comImg != null && comImg.MainLogo != null)
                    {
                        MemoryStream ms = new MemoryStream(comImg.MainLogo);
                        imgMain.Image = Image.FromStream(ms);
                    }
                    else
                        imgMain.Image = imgMain.InitialImage;

                    if (comImg != null && comImg.LogoOnly !=null)
                    {
                        MemoryStream ms = new MemoryStream(comImg.LogoOnly);
                        imgLogo.Image = Image.FromStream(ms);
                    }
                    else
                        imgLogo.Image = imgLogo.InitialImage;

                    if (comImg != null && comImg.TextOnly!=null)
                    {
                        MemoryStream ms = new MemoryStream(comImg.TextOnly);
                        imgText.Image = Image.FromStream(ms);
                    }
                    else
                        imgText.Image = imgText.InitialImage;


                    //RefreshGrid_Account();
                }
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity()
        {
            string strMessage = "";
            bool bStatus = true;

            if (txtCompanyName.TextLength == 0)
            {
                strMessage += "\n" + "Company Name ";
                bStatus = false;
            }
            if (txtFinancialYear.TextLength == 0)
            {
                strMessage += "\n" + " Financial Year ";
                bStatus = false;
            }
            if (bStatus == false)
            {
                MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInsert, strMessage), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region Event Double Click
        private void txtFinancialYear_DoubleClick(object sender, EventArgs e)
        {
            Search_FinancialID();
        } 
        #endregion

        #region Search Methods
        private void Search_FinancialID()
        {
            try
            {
                clsSearch.Search_FinancialID(ref txtFinancialYear);
                //Form frmhelpsearch = new frmSearchMaster();
                //clsSearch.Search_FinancialID(ref txtFinancialYear);
                //frmhelpsearch.ShowDialog();

                //if (frmSearchMaster.s_SearchID.Length > 0)
                //{
                //    txtFinYear.Text = frmSearchMaster.s_SearchID;
                //    FillDetails(frmSearchMaster.s_SearchID);
                //}
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", iFormID,ex);
                SEACCException.Show(ex);
            }
        }
        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            frmCompanyBankAccount frm = new frmCompanyBankAccount();
            frm.MdiParent = this.ParentForm.MdiParent;
            if (frm.bNoAccess)
                MessageBox.Show(clsFormatter.GetMessageFrom(MessageType.PermissionToRead), clsFormatter.GetMessageCaption() + " [" + frm.iFormID + "]", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                frm.Show();
        }

        
    }
}

//private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
//{

//}
//private void btnRemove_Click_1(object sender, EventArgs e)
//{

//}

//private void dgvAccounts_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
//{
//    dgvAccounts["AccBalance", e.RowIndex].Value = 0;
//}

//private void dgvAccounts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
//{
//    bool bIsCorrect = false;
//    try
//    {
//        string BankID = dgvAccounts["BankName", e.RowIndex].Tag.ToString(),
//            BranchID = dgvAccounts["BranchName", e.RowIndex].Tag.ToString(),
//            AccountNo = dgvAccounts["AccountNo", e.RowIndex].Value.ToString();
//        if (BankID.Length > 0 && BranchID.Length > 0 && AccountNo.Length > 0)
//            bIsCorrect = true;
//    }
//    catch (Exception)
//    {
//        bIsCorrect = false;
//    }
//    if (bIsCorrect)
//        dgvAccounts.Rows.Add();
//}

//private void dgvAccounts_KeyDown(object sender, KeyEventArgs e)
//{
//    //have to develop later
//}

//private void dgvAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
//{
//    SeachAccountDetail(e.ColumnIndex, e.RowIndex);
//}

  #region Events Datagrid 

      //  private void SeachAccountDetail(int ColumnIndex, int RowIndex)
     //   {
            //if (ColumnIndex == 0)
            //{
            //    Form frmhelpsearch = new frmSearchMaster();
            //    clsSearch.passValue_Bank();
            //    frmhelpsearch.ShowDialog();

            //    if (frmSearchMaster.s_SearchText.Length > 0)
            //        dgvAccounts["BankName", RowIndex].Value = frmSearchMaster.s_SearchText;
            //    if (frmSearchMaster.s_SearchID.Length > 0)
            //        dgvAccounts["BankName", RowIndex].Tag = frmSearchMaster.s_SearchID;
            //}
            //if (ColumnIndex == 1)
            //{
            //    string sBankID = "";
            //    try
            //    {
            //        sBankID = dgvAccounts["BankName", RowIndex].Tag.ToString();
            //    }
            //    catch (Exception) { }
            //    if (sBankID.Length <= 0)
            //        MessageBox.Show("Please Select the Bank Name First", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    else
            //    {
            //        Form frmhelpsearch = new frmSearchMaster();
            //        clsSearch.passValue_BankBranchesByBankID(sBankID);
            //        frmhelpsearch.ShowDialog();

            //        if (frmSearchMaster.s_SearchText.Length > 0)
            //            dgvAccounts["BranchName", RowIndex].Value = frmSearchMaster.s_SearchText;
            //        if (frmSearchMaster.s_SearchID.Length > 0)
            //            dgvAccounts["BranchName", RowIndex].Tag = frmSearchMaster.s_SearchID;
            //    }
            //}
            //if (ColumnIndex == 2)
            //{
            //    string sBranchID = "";
            //    try
            //    {
            //        sBranchID = dgvAccounts["BranchName", RowIndex].Tag.ToString();
            //    }
            //    catch (Exception) { }
            //    if (sBranchID.Length <= 0)
            //        MessageBox.Show("Please Select the Branch Name First", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
      //  }
        #endregion


#region Refresh Grid
//private void RefreshGrid_Account()
//{
//    int iRow;
//    dgvAccounts.Rows.Clear();

//    List<tbl_genCompanyAccount> details = tbl_genCompanyAccount.SelectAllByCompanyID(txtCompanyID.Text.Trim());
//    foreach (tbl_genCompanyAccount detail in details)
//    {
//        if (detail.Bank_ID != "default")
//        {
//            dgvAccounts.Rows.Add();
//            iRow = dgvAccounts.Rows.Count - 1;
//            dgvAccounts["BankName", iRow].Value = clsGenaralName.getName_Bank(detail.Bank_ID);
//            dgvAccounts["BankName", iRow].Tag = detail.Bank_ID;
//            dgvAccounts["BranchName", iRow].Value = clsGenaralName.getName_BankBranch(detail.Branch_ID);
//            dgvAccounts["BranchName", iRow].Tag = detail.Branch_ID;
//            dgvAccounts["AccountNo", iRow].Value = detail.AccountNumber;
//            dgvAccounts["AccBalance", iRow].Value = clsCommon.GetForeignKeyValue(detail.Gl_ID); 
//        }
//    }
//    dgvAccounts.Rows.Add();
//}        
#endregion

#region Btn Remove
//private void btnRemove_Click(object sender, EventArgs e)
//{
//    try
//    {
//        if (dgvAccounts.SelectedCells.Count != 0)
//        {
//            if (dgvAccounts.Rows.Count > 1)
//                dgvAccounts.Rows.RemoveAt(dgvAccounts.SelectedCells[0].RowIndex);
//        }
//    }
//    catch (Exception) { }
//}
#endregion