using DataTire;
using Digiteq_Logic;
using SEACC_LOGIN.Common;
using SEACC_LOGIN.Search;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
  using System.Windows.Forms;
using Digiteq_Logic;
using Digiteq;

namespace SEACC_LOGIN
{
    public partial class frmWorkstationRegister : Form
    {
        #region Variable
        DataTable dtMain = new DataTable();
        static bool IsUpdate = false;

        private const int CS_DROPSHADOW = 0x20000;
        #endregion

        #region Form Load
        public frmWorkstationRegister()
        {
            InitializeComponent();

            #region Initialize Data Table
            dtMain.Columns.Add("LineNo");
            dtMain.Columns.Add("WorkStationID");
            dtMain.Columns.Add("TerminalID");
            dtMain.Columns.Add("BranchID");
            #endregion

            dgvMain.DataSource = dtMain.DefaultView;

            ClearFields();
            RefreshGrid();
        }
        private void frmWorkstationRegister2_Load(object sender, EventArgs e)
        {
            ucTittleBar1.Refresh();
        }
        #endregion

        #region Action Buttons
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckValidity_EmptyFields())
                {
                    if (IsUpdate)
                    {
                        tbl_securityWorkstationRegister oOldRecord = tbl_securityWorkstationRegister.Select(int.Parse(txtWorkstationID.Text.Trim()));
                        if (oOldRecord != null)
                        {
                            tbl_securityWorkstationRegister oDetail = new tbl_securityWorkstationRegister(int.Parse(txtWorkstationID.Text.Trim()), txtTerminal_ID.Text, clsSecurity_Login.CompanyID, txtCompanyBranch.Tag.ToString(), chkIsApproved.Checked);
                            oDetail.Update();

                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
                        }                        
                    }
                    else
                    {
                        if (CheckValidity_DuplicateRecord())
                        {
                            tbl_securityWorkstationRegister oDetail = new tbl_securityWorkstationRegister(txtTerminal_ID.Text, clsSecurity_Login.CompanyID, txtCompanyBranch.Tag.ToString(), chkIsApproved.Checked);
                            oDetail.Insert();

                            SEACCMessageBox.Show(MessegeBoxType.Successfully_Created);
                            Program.IsWS_Reg = true;
                            Program.sCompanyBranchID = txtCompanyBranch.Tag.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
            finally
            {
                ClearFields();
                RefreshGrid();
            }
        }
        #endregion

        #region Clear Field
        private void ClearFields()
        {
            IsUpdate = false;

            Digiteq_Logic.clsCommon.SetEnableDisable_ForeignKeyTextboxMust(txtCompanyBranch, true);
            Digiteq_Logic.clsCommon.SetEnableDisable_NormalTextbox(txtTerminal_ID, true);

            txtWorkstationID.Text = "0";
            txtCompanyBranch.Tag = clsSecurity_Login.CompanyBranchID;
            txtCompanyBranch.Text =clsGenaralName .getName_CompanyBranchMaster(clsSecurity_Login.CompanyBranchID);
            txtTerminal_ID.Text = clsSecurity_Login.TerminalID;

            chkIsApproved.Checked = false;
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dtMain.Clear();
                int iLine = 0;
                foreach (tbl_securityWorkstationRegister oWorkstation in tbl_securityWorkstationRegister.SelectAll())
                {
                    dtMain.Rows.Add(++iLine, oWorkstation.Workstation_ID, oWorkstation.Terminal_ID, clsGenaralName.getName_CompanyBranchMaster(oWorkstation.CompanyBranch_ID));
                }
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }
        }
        #endregion

        #region Fill Detail
        private void fillDetails(int sID)
        {
            try
            {
                tbl_securityWorkstationRegister oDetail = tbl_securityWorkstationRegister.Select(sID);
                if (oDetail != null)
                {
                    IsUpdate = true;

                    txtCompanyBranch.Tag = oDetail.CompanyBranch_ID;

                    txtWorkstationID.Text = oDetail.Workstation_ID.ToString();
                    txtTerminal_ID.Text = oDetail.Terminal_ID;
                    txtCompanyBranch.Text = clsGenaralName.getName_CompanyBranchMaster(oDetail.CompanyBranch_ID);

                    chkIsApproved.Checked = oDetail.IsApproved;
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Grid Event
        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    int GridID = int.Parse(Digiteq_Logic.clsValidate.ValidateGridValue(dgvMain, "WorkstationID", e.RowIndex, ""));
                    if (GridID > 0)
                    {
                        fillDetails(GridID);
                    }
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        }
        #endregion

        #region Double Click Event

        private void txtCompanyBranch_DoubleClick(object sender, EventArgs e)
        {
            frm_search RowDataSearch = new frm_search();
            List<string> lstResult = RowDataSearch.Show(5007);
            if (RowDataSearch.DialogResult == true)
            {
                txtCompanyBranch.Tag = lstResult[0];
                txtCompanyBranch.Text = lstResult[1];
            }
        }
        #endregion

        #region Check Validity
        private bool CheckValidity_DuplicateRecord()
        {
            bool bStatus = true;
            try
            {
                tbl_securityWorkstationRegister oSection = tbl_securityWorkstationRegister.SelectAll().Where(p => p.Terminal_ID == txtTerminal_ID.Text).FirstOrDefault();
                if (oSection != null)
                    bStatus = false;


                if(!bStatus)
                    SEACCMessageBox.Show("This workstation already registerd","", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                SEACCException.Show(ex);
            }

            return bStatus;
        }

        private bool CheckValidity_EmptyFields()
        {
            bool bStatus = true;
            if (!Digiteq_Logic.clsValidate.ValidateTextBox_EmptyValue(txtCompanyBranch, "Company Brach ID"))
                bStatus = false;
            if (!Digiteq_Logic.clsValidate.ValidateTextBox_EmptyValue(txtTerminal_ID, "Motherboard ID"))
                bStatus = false;

            return bStatus;
        }
        #endregion

        #region Dropshadow
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        #endregion

        #region Title Bar Gradient Paint
        private void ucTittleBar1_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(ucTittleBar1.ClientRectangle, Color.FromArgb(39, 102, 153), Color.FromArgb(21, 56, 84), 90);

            ColorBlend cblend = new ColorBlend(2);
            cblend.Colors = new Color[2] { Color.FromArgb(39, 102, 153), Color.FromArgb(21, 56, 84) };
            cblend.Positions = new float[2] { 0f, 1f };
            linearGradientBrush.InterpolationColors = cblend;

            e.Graphics.FillRectangle(linearGradientBrush, ucTittleBar1.ClientRectangle);
        }
        #endregion
    }
}
