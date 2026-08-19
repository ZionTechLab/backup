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
    public partial class frm_toolSetReportMaster : Form
    {
        #region Public variables
       public int iFormID; 
        #endregion

        #region Form Load
        private void frm_toolCheckToDepositeMode1_Load(object sender, EventArgs e)
        {
            ClearFields();
        }

        public frm_toolSetReportMaster()
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

                UpdateRecords();


                ClearFields();
                MessageBox.Show("All Reports Are Updated Succesfull.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void UpdateRecords()
        {
            try
            {
                foreach (tbl_securityReportMaster detail in tbl_securityReportMaster.SelectAll().Where(p => p.Report_ID != "default" && p.Report_ID != "0"))
                {
                    switch (detail.Report_ID)
                    {
                        #region Account Note printing
                        case "ACC/NP/0001":
                            detail.DisplayName = "NP-APN";
                            detail.ReportName = "NP Account Payable Note";
                            detail.ReportCategory_ID = "4";
                            break;
                        case "ACC/NP/0002":
                            detail.DisplayName = "NP-JV";
                            detail.ReportName = "NP Journal Voucher";
                            detail.ReportCategory_ID = "4";
                            break;
                        case "ACC/NP/0003":
                            detail.DisplayName = "NP-RV";
                            detail.ReportName = "NP Receipt Voucher";
                            detail.ReportCategory_ID = "4";
                            break;
                        case "ACC/NP/0004":
                            detail.DisplayName = "NP-PV";
                            detail.ReportName = "NP Payment Voucher";
                            detail.ReportCategory_ID = "4";
                            break;
                        case "ACC/NP/0005":
                            detail.DisplayName = "NP-PI";
                            detail.ReportName = "NP Posting Interface";
                            detail.ReportCategory_ID = "4";
                            break;
                        #endregion

                        #region Account Registers
                        case "ACC/RG/0001":
                            detail.DisplayName = "RG-PVS";
                            detail.ReportName = "RG Payment Voucher Summary";
                            detail.ReportCategory_ID = "9";
                            break;
                        case "ACC/RG/0002":
                            detail.DisplayName = "RG-PVD";
                            detail.ReportName = "RG Payment Voucher Detail";
                            detail.ReportCategory_ID = "9";
                            break;
                        case "ACC/RG/0003":
                            detail.DisplayName = "RG-FY";
                            detail.ReportName = "RG Financial Year";
                            detail.ReportCategory_ID = "9";
                            break;
                        case "ACC/RG/0004":
                            detail.DisplayName = "RG-GG";
                            detail.ReportName = "RG General Gedger";
                            detail.ReportCategory_ID = "9";
                            break;
                        case "ACC/RG/0005":
                            detail.DisplayName = "RG-SGG";
                            detail.ReportName = "RG Sub General Gedger";
                            detail.ReportCategory_ID = "9";
                            break;
                        case "ACC/RG/0006":
                            detail.DisplayName = "RG-SGG";
                            detail.ReportName = "RG Account Type";
                            detail.ReportCategory_ID = "9";
                            break;
                        case "ACC/RG/0007":
                            detail.DisplayName = "RG-SGG";
                            detail.ReportName = "RG Account Code";
                            detail.ReportCategory_ID = "9";
                            break;
                        #endregion

                        #region Account Standed
                        case "ACC/ST/0001":
                            detail.DisplayName = "ST-TB";
                            detail.ReportName = "ST Trail Balance";
                            detail.ReportCategory_ID = "14";
                            break;
                        case "ACC/ST/0002":
                            detail.DisplayName = "ST-SGG";
                            detail.ReportName = "ST Balance Sheet";
                            detail.ReportCategory_ID = "14";
                            break;
                        case "ACC/ST/0003":
                            detail.DisplayName = "ST-SGG";
                            detail.ReportName = "ST ProfitAndLoss Statement";
                            detail.ReportCategory_ID = "14";
                            break;
                        case "ACC/ST/0004":
                            detail.DisplayName = "ST-SGG";
                            detail.ReportName = "ST GL posting";
                            detail.ReportCategory_ID = "14";
                            break;
                        case "ACC/ST/0005":
                            detail.DisplayName = "ST-SGG";
                            detail.ReportName = "ST Ledger Listing";
                            detail.ReportCategory_ID = "14";
                            break;
                        case "ACC/ST/0006":
                            detail.DisplayName = "ST-GLDR";
                            detail.ReportName = "ST GL DetailedReport AccCodeWise";
                            detail.ReportCategory_ID = "14";
                            break;
                        #endregion

                        #region Admin Master
                        case "ADM/MS/0001":
                            detail.DisplayName = "RG-UMR";
                            detail.ReportName = "RG User MasterReport";
                            detail.ReportCategory_ID = "31";
                            break;
                        case "ADM/MS/0002":
                            detail.DisplayName = "RG-FM";
                            detail.ReportName = "RG Form Master ";
                            detail.ReportCategory_ID = "31";
                            break;
                        case "ADM/MS/0003":
                            detail.DisplayName = "RG-RM";
                            detail.ReportName = "RG Report Master ";
                            detail.ReportCategory_ID = "31";
                            break;
                        #endregion

                        #region Admin Registers
                        case "ADM/RG/0001":
                            detail.DisplayName = "RG-UMR";
                            detail.ReportName = "RG User Master Report";
                            detail.ReportCategory_ID = "27";
                            break;
                        case "ADM/RG/0002":
                            detail.DisplayName = "RG-UMR";
                            detail.ReportName = "RG Permission Report UserWise";
                            detail.ReportCategory_ID = "27";
                            break;
                        case "ADM/RG/0003":
                            detail.DisplayName = "RG-UMR";
                            detail.ReportName = "RG Permission Report FormWise";
                            detail.ReportCategory_ID = "27";
                            break;
                        #endregion

                        #region Admin Standered
                        case "ADM/ST/0001":
                            detail.DisplayName = "ST-FPU";
                            detail.ReportName = "ST Form Permission UserWise";
                            detail.ReportCategory_ID = "32";
                            break;
                        case "ADM/ST/0002":
                            detail.DisplayName = "ST-FPF";
                            detail.ReportName = "ST Form Permission FormWise";
                            detail.ReportCategory_ID = "32";
                            break;
                        case "ADM/ST/0003":
                            detail.DisplayName = "ST-FPU";
                            detail.ReportName = "ST Report Permission UserWise";
                            detail.ReportCategory_ID = "32";
                            break;
                        case "ADM/ST/0004":
                            detail.DisplayName = "ST-RPRW";
                            detail.ReportName = "RG Report Permission ReportWise";
                            detail.ReportCategory_ID = "32";
                            break;

                        #endregion

                        #region Bills Note Printing
                        case "BSS/NP/0001":
                            detail.DisplayName = "NP-CMCD";
                            detail.ReportName = "NP Cheque Management ChequeDeposit";
                            detail.ReportCategory_ID = "3";
                            break;
                        case "BSS/NP/0002":
                            detail.DisplayName = "NP-CMCHD";
                            detail.ReportName = "NP Cheque Management CashDeposit";
                            detail.ReportCategory_ID = "3";
                            break;
                        case "BSS/NP/0003":
                            detail.DisplayName = "NP-CMRD";
                            detail.ReportName = "NP Cheque Management ReDeposit";
                            detail.ReportCategory_ID = "3";
                            break;
                        case "BSS/NP/0004":
                            detail.DisplayName = "NP-CMRI";
                            detail.ReportName = "NP Cheque Management ReIssues";
                            detail.ReportCategory_ID = "3";
                            break;
                        case "BSS/NP/0005":
                            detail.DisplayName = "NP-CMRC";
                            detail.ReportName = "NP Cheque Management Reconciliation";
                            detail.ReportCategory_ID = "3";
                            break;
                        case "BSS/NP/0006":
                            detail.DisplayName = "NP-IS";
                            detail.ReportName = "NP Invoice Settlement";
                            detail.ReportCategory_ID = "3";
                            break;
                        case "BSS/NP/0007":
                            detail.DisplayName = "NP-CN";
                            detail.ReportName = "NP Credit Note";
                            detail.ReportCategory_ID = "3";
                            break;
                        case "BSS/NP/0008":
                            detail.DisplayName = "NP-DN";
                            detail.ReportName = "NP Debit Note";
                            detail.ReportCategory_ID = "3";
                            break;
                        case "BSS/NP/0009":
                            detail.DisplayName = "NP-IR";
                            detail.ReportName = "NP Interim Receipt";
                            detail.ReportCategory_ID = "3";
                            break;
                        #endregion

                        #region Bills Registers
                        case "BSS/RG/0001":
                            detail.DisplayName = "RG-CRCW";
                            detail.ReportName = "RG Cheque Register Cheque Weekly";
                            detail.ReportCategory_ID = "8";
                            break;
                        case "BSS/RG/0002":
                            detail.DisplayName = "RG-CRCD";
                            detail.ReportName = "RG Cheque Registered Cheque Daily";
                            detail.ReportCategory_ID = "8";
                            break;
                        case "BSS/RG/0003":
                            detail.DisplayName = "RG-CRCW";
                            detail.ReportName = "RG Cheque Registered Cheque Weekly";
                            detail.ReportCategory_ID = "8";
                            break;
                        case "BSS/RG/0004":
                            detail.DisplayName = "RG-DCBW";
                            detail.ReportName = "RG Deposited Cheques BankAcct Wise";
                            detail.ReportCategory_ID = "8";
                            break;
                        case "BSS/RG/0005":
                            detail.DisplayName = "RG-DCBW";
                            detail.ReportName = "RG Deposited Cash BankAcct Wise";
                            detail.ReportCategory_ID = "8";
                            break;
                        case "BSS/RG/0006":
                            detail.DisplayName = "RG-RCBW";
                            detail.ReportName = "RG Redeposit Cheques BankAcct Wise";
                            detail.ReportCategory_ID = "8";
                            break;
                        case "BSS/RG/0007":
                            detail.DisplayName = "RG-RICS";
                            detail.ReportName = "RG ReIssued Cheques Summary";
                            detail.ReportCategory_ID = "8";
                            break;
                        case "BSS/RG/0008":
                            detail.DisplayName = "RG-RICD";
                            detail.ReportName = "RG Realized Cheque";
                            detail.ReportCategory_ID = "8";
                            break;
                        case "BSS/RG/0009":
                            detail.DisplayName = "RG-RS";
                            detail.ReportName = "RG Receipt Summary";
                            detail.ReportCategory_ID = "8";
                            break;
                        case "BSS/RG/0010":
                            detail.DisplayName = "RG-SRS";
                            detail.ReportName = "RG Sales Receipt Summary";
                            detail.ReportCategory_ID = "8";
                            break;
                        case "BSS/RG/0011":
                            detail.DisplayName = "RG-IRS";
                            detail.ReportName = "RG Interim Receipt Summary";
                            detail.ReportCategory_ID = "8";
                            break;
                        case "BSS/RG/0012":
                            detail.DisplayName = "RG-CNS";
                            detail.ReportName = "RG Credit Note Summary";
                            detail.ReportCategory_ID = "8";
                            break;
                        case "BSS/RG/0013":
                            detail.DisplayName = "RG-DNS";
                            detail.ReportName = "RG Debit Note Summary";
                            detail.ReportCategory_ID = "8";
                            break;
                        case "BSS/RG/0014":
                            detail.DisplayName = "RG-ICD";
                            detail.ReportName = "RG Issued Cheques Daily";
                            detail.ReportCategory_ID = "8"; 
                            break;
                        case "BSS/RG/0015":
                            detail.DisplayName = "RG-RCBW";
                            detail.ReportName = "RG Returned Cheque BankWise";  
                            detail.ReportCategory_ID = "8";
                            break;
                        #endregion// ST_RG_Issued_Cheques_Dail, RG_Returned_Cheque_BankWise

                        #region Bills Standed
                        case "BSS/ST/0001":
                            detail.DisplayName = "ST-PCD";
                            detail.ReportName = "ST Pending Cheque Deposite";
                            detail.ReportCategory_ID = "13";
                            break;
                        case "BSS/ST/0002":
                            detail.DisplayName = "ST-CIHA";
                            detail.ReportName = "ST Cheque In HandAll";
                            detail.ReportCategory_ID = "13";
                            break;
                        case "BSS/ST/0003":
                            detail.DisplayName = "ST-CIHAFD";
                            detail.ReportName = "ST Cheque In Hand Approved For Deposit";
                            detail.ReportCategory_ID = "13";
                            break;
                        case "BSS/ST/0004":
                            detail.DisplayName = "ST-CIHPA";
                            detail.ReportName = "ST ChequeIn Hand Pending Approval";
                            detail.ReportCategory_ID = "13";
                            break;
                        case "BSS/ST/0005":
                            detail.DisplayName = "ST-RCIH";
                            detail.ReportName = "ST_Returned Cheque inHand";
                            detail.ReportCategory_ID = "13";
                            break;
                        case "BSS/ST/0006":
                            detail.DisplayName = "ST-CRS";
                            detail.ReportName = "ST_Collection Report Summary";
                            detail.ReportCategory_ID = "13";
                            break;
                        case "BSS/ST/0007":
                            detail.DisplayName = "ST-CRD";
                            detail.ReportName = "ST_Collection Report Detail";
                            detail.ReportCategory_ID = "13";
                            break;
                        case "BSS/ST/0008":
                            detail.DisplayName = "ST-CRA";
                            detail.ReportName = "ST Collection Report Aging";
                            detail.ReportCategory_ID = "13";
                            break;

                                                 
                        #endregion


                        //case "SAS/ST/0010":
                        //    detail.DisplayName = "ST-CRA";
                        //    detail.ReportName = "ST Collection Report Aging";
                        //    detail.ReportCategory_ID = "13";
                        //    break;
                        

                        #region Master pretty cash
                        case "MAS/PT/0001":
                            detail.DisplayName = "PT-L1T";
                            detail.ReportName = "PT Level1 Titles";
                            detail.ReportCategory_ID = "30";
                            break;
                        case "MAS/PT/0002":
                            detail.DisplayName = "PT-L2T";
                            detail.ReportName = "PT Level2 Titles";
                            detail.ReportCategory_ID = "30";
                            break;
                        case "MAS/PT/0003":
                            detail.DisplayName = "PT-L3T";
                            detail.ReportName = "PT Level3 Titles";
                            detail.ReportCategory_ID = "30";
                            break;
                        case "MAS/PT/0004":
                            detail.DisplayName = "PT-ET";
                            detail.ReportName = "PT Expenditure Types";
                            detail.ReportCategory_ID = "30";
                            break;
                        case "MAS/PT/0005":
                            detail.DisplayName = "PT-CC";
                            detail.ReportName = "PT Cost Centers";
                            detail.ReportCategory_ID = "30";
                            break;
                        case "MAS/PT/0006":
                            detail.DisplayName = "PT-AI";
                            detail.ReportName = "PT Activitys Items";
                            detail.ReportCategory_ID = "30";
                            break;
                        case "MAS/PT/0007":
                            detail.DisplayName = "PT-S";
                            detail.ReportName = "PT Suppliers";
                            detail.ReportCategory_ID = "30";
                            break;
                        case "MAS/PT/0008":
                            detail.DisplayName = "PT-IT";
                            detail.ReportName = "PT Income Types";
                            detail.ReportCategory_ID = "30";
                            break;

                        #endregion

                        #region Master Register
                        case "MAS/RG/0001":
                            detail.DisplayName = "RG-IM";
                            detail.ReportName = "RG Item Master";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0002":
                            detail.DisplayName = "RG-CM";
                            detail.ReportName = "RG Customer Master";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0003":
                            detail.DisplayName = "RG-SM";
                            detail.ReportName = "RG Supplier Master";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0004":
                            detail.DisplayName = "RG-SC";
                            detail.ReportName = "RG Supplier Class";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0005":
                            detail.DisplayName = "RG-ST";
                            detail.ReportName = "RG Supplier Type";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0006":
                            detail.DisplayName = "RG-SC";
                            detail.ReportName = "RG Supplier Category";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0007":
                            detail.DisplayName = "RG-CC";
                            detail.ReportName = "RG Customer Class";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0008":
                            detail.DisplayName = "RG-CT";
                            detail.ReportName = "RG Customer Type";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0009":
                            detail.DisplayName = "RG-CC";
                            detail.ReportName = "RG Customer Category";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0010":
                            detail.DisplayName = "RG-IC";
                            detail.ReportName = "RG Item Class";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0011":
                            detail.DisplayName = "RG-IT";
                            detail.ReportName = "RG Item Type";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0012":
                            detail.DisplayName = "RG-IC";
                            detail.ReportName = "RG Item Category";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0013":
                            detail.DisplayName = "RG-Brand";
                            detail.ReportName = "RG Brand";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0014":
                            detail.DisplayName = "RG-Uom";
                            detail.ReportName = "RG Uom";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0015":
                            detail.DisplayName = "RG-UC";
                            detail.ReportName = "RG Uom Category";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0016":
                            detail.DisplayName = "RG-Bank";
                            detail.ReportName = "RG Bank";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0017":
                            detail.DisplayName = "RG-Branch";
                            detail.ReportName = "RG Branch";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0018":
                            detail.DisplayName = "RG-Currency";
                            detail.ReportName = "RG Currency";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0019":
                            detail.DisplayName = "RG-Tax";
                            detail.ReportName = "RG Tax";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0020":
                            detail.DisplayName = "RG-County";
                            detail.ReportName = "RG County";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0021":
                            detail.DisplayName = "RG-Province";
                            detail.ReportName = "RG Province";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0022":
                            detail.DisplayName = "RG-District";
                            detail.ReportName = "RG District";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0023":
                            detail.DisplayName = "RG-City";
                            detail.ReportName = "RG City";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0024":
                            detail.DisplayName = "RG-Town";
                            detail.ReportName = "RG Town";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0025":
                            detail.DisplayName = "RG-Employee";
                            detail.ReportName = "RG Employee";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0026":
                            detail.DisplayName = "RG-SM";
                            detail.ReportName = "RG Sales Manger";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0027":
                            detail.DisplayName = "RG-AM";
                            detail.ReportName = "RG Area Manager";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0028":
                            detail.DisplayName = "RG-SR";
                            detail.ReportName = "RG Sales Rep";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0029":
                            detail.DisplayName = "RG-SE";
                            detail.ReportName = "RG Sales Executive";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0030":
                            detail.DisplayName = "RG-Vehicles";
                            detail.ReportName = "RG Vehicles";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0031":
                            detail.DisplayName = "RG-Driver";
                            detail.ReportName = "RG Driver";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0032":
                            detail.DisplayName = "RG-Assistant";
                            detail.ReportName = "RG Assistant";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0033":
                            detail.DisplayName = "RG-Area";
                            detail.ReportName = "RG Area";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0034":
                            detail.DisplayName = "RG-Root";
                            detail.ReportName = "RG Root";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0035":
                            detail.DisplayName = "RG-IC";
                            detail.ReportName = "RG Item Category";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0036":
                            detail.DisplayName = "RG-CS";
                            detail.ReportName = "RG Cheque Status";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0037":
                            detail.DisplayName = "RG-CMSCW";
                            detail.ReportName = "RG Customer Master Summary CustomerWise";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0038":
                            detail.DisplayName = "RG-CMSR";
                            detail.ReportName = "RG Customer Master Summary RouterWise";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0039":
                            detail.DisplayName = "CMSSRW";
                            detail.ReportName = "RG Customer Master Summary SelesRepWise";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0040":
                            detail.DisplayName = "RG-CMSTW";
                            detail.ReportName = "RG Customer Master Summary TownWise";
                            detail.ReportCategory_ID = "28";
                            break;
                        case "MAS/RG/0041":
                            detail.DisplayName = "RG-CT";
                            detail.ReportName = "RG Cheque Type";
                            detail.ReportCategory_ID = "28";
                            break;

                        #endregion

                        #region Production Note Printing
                        case "PSM/NP/0001":
                            detail.DisplayName = "NP-PP";
                            detail.ReportName = "NP Production Profit";
                            detail.ReportCategory_ID = "5";
                            break;
                        case "PSM/NP/0002":
                            detail.DisplayName = "NP-OP";
                            detail.ReportName = "NP Office Profit";
                            detail.ReportCategory_ID = "5";
                            break;
                        case "PSM/NP/0003":
                            detail.DisplayName = "NP-DP";
                            detail.ReportName = "NP Delivery Profit";
                            detail.ReportCategory_ID = "5";
                            break;
                        case "PSM/NP/0004":
                            detail.DisplayName = "NP-PS";
                            detail.ReportName = "NP Preplan Section";
                            detail.ReportCategory_ID = "5";
                            break;
                        case "PSM/NP/0005":
                            detail.DisplayName = "NP-WP";
                            detail.ReportName = "NP WorkIn Progress";
                            detail.ReportCategory_ID = "5";
                            break;
                        #endregion

                        #region Production Standerd
                        case "PSM/ST/0001":
                            detail.DisplayName = "ST-DPJ";
                            detail.ReportName = "ST Daily Production Jobs";
                            detail.ReportCategory_ID = "29";
                            break;
                        case "PSM/ST/0002":
                            detail.DisplayName = "ST-PJA";
                            detail.ReportName = "ST Production Jobs Approved";
                            detail.ReportCategory_ID = "29";
                            break;
                        case "PSM/ST/0003":
                            detail.DisplayName = "ST-PDJ";
                            detail.ReportName = "ST Pending Delivery Job";
                            detail.ReportCategory_ID = "29";
                            break;
                        case "PSM/ST/0004":
                            detail.DisplayName = "ST-RRSJ";
                            detail.ReportName = "ST Rejection Report Summary JobWise";
                            detail.ReportCategory_ID = "29";
                            break;
                        case "PSM/ST/0005":
                            detail.DisplayName = "ST-RRDJW";
                            detail.ReportName = "ST Rejection Report Detail JobWise";
                            detail.ReportCategory_ID = "29";
                            break;
                        case "PSM/ST/0006":
                            detail.DisplayName = "ST-PWTRJW";
                            detail.ReportName = " ST Production Weight Tracking Report JobWise";
                            detail.ReportCategory_ID = "29";
                            break;
                        case "PSM/ST/0007":
                            detail.DisplayName = "ST-PWCRJW";
                            detail.ReportName = " ST Production Weight Comparison Report JobWise";
                            detail.ReportCategory_ID = "29";
                            break;
                        case "PSM/ST/0008":
                            detail.DisplayName = "ST-OJCW";
                            detail.ReportName = " ST Outstanding Jobs Customer Wise";
                            detail.ReportCategory_ID = "29";
                            break;
                        case "PSM/ST/0009":
                            detail.DisplayName = "ST-OJDW";
                            detail.ReportName = " ST Outstanding Jobs Date Wise";
                            detail.ReportCategory_ID = "29";
                            break;

                            
                        #endregion

                        #region Sales Finance RG_Customer_wise_Outstanding_Summary
                        case "SAS/FN/0001":
                            detail.DisplayName = "RG-CWOS";
                            detail.ReportName = "RG Customer wise Outstanding Summary";
                            detail.ReportCategory_ID = "16";
                            break;
                        case "SAS/FN/0002":
                            detail.DisplayName = "RG-CWOD";
                            detail.ReportName = "RG Customer wise Outstanding Detail";
                            detail.ReportCategory_ID = "16";
                            break;
                        case "SAS/FN/0003":
                            detail.DisplayName = "RG-SWOS";
                            detail.ReportName = "RG Salesman wise Outstanding Summary";
                            detail.ReportCategory_ID = "16";
                            break;
                        case "SAS/FN/0004":
                            detail.DisplayName = "RG-SWOD";
                            detail.ReportName = "RG Salesman wise Outstanding Detail";
                            detail.ReportCategory_ID = "16";
                            break;
                        case "SAS/FN/0005":
                            detail.DisplayName = "RG-SJ";
                            detail.ReportName = "RG Sales Journal";
                            detail.ReportCategory_ID = "16";
                            break;
                        case "SAS/FN/0006":
                            detail.DisplayName = "RG-IWPT";
                            detail.ReportName = "RG Invoice wise payment Tracking";
                            detail.ReportCategory_ID = "16";
                            break;
                        case "SAS/FN/0007":
                            detail.DisplayName = "RG-RWIT";
                            detail.ReportName = "RG Receipt wise Invoice Tracking";
                            detail.ReportCategory_ID = "16";
                            break;
                        case "SAS/FN/0008":
                            detail.DisplayName = "RG-AACW";
                            detail.ReportName = "RG Age Analysis Customer wise";
                            detail.ReportCategory_ID = "16";
                            break;
                        case "SAS/FN/0009":
                            detail.DisplayName = "RG-AASW";
                            detail.ReportName = "RG Age Analysis Salesman wise"; //RG Age Analysis Salesman wise
                            detail.ReportCategory_ID = "16"; 
                            break;
                        case "SAS/FN/0010":
                            detail.DisplayName = "RG-SCS";
                            detail.ReportName = "RG Sales Commission Summary";
                            detail.ReportCategory_ID = "16";
                            break;
                        case "SAS/FN/0011":
                            detail.DisplayName = "RG-SCD";
                            detail.ReportName = "RG Sales Commission Detail";
                            detail.ReportCategory_ID = "16";
                            break;
                        case "SAS/FN/0012":
                            detail.DisplayName = "RG-OSA";
                            detail.ReportName = "RG Outstanding Statement AllCustomer";
                            detail.ReportCategory_ID = "16";
                            break;
                        case "SAS/FN/0013":
                            detail.DisplayName = "RG-OSS";
                            detail.ReportName = "RG Outstanding Statement SingleCustomer";
                            detail.ReportCategory_ID = "16";
                            break;
                       
                        #endregion

                        #region Sales Note Printing
                        case "SAS/NP/0001":
                            detail.DisplayName = "NP-SI";
                            detail.ReportName = "NP Sales Inquiry";
                            detail.ReportCategory_ID = "1";
                            break;
                        case "SAS/NP/0002":
                            detail.DisplayName = "NP-SJI";
                            detail.ReportName = "NP Sales JobEntry Inquiry";
                            detail.ReportCategory_ID = "1";
                            break;
                        case "SAS/NP/0003":
                            detail.DisplayName = "NP-CQ";
                            detail.ReportName = "NP Customer Quotation";
                            detail.ReportCategory_ID = "1";
                            break;
                        case "SAS/NP/0004":
                            detail.DisplayName = "NP-CO";
                            detail.ReportName = "NP Customer Order";
                            detail.ReportCategory_ID = "1";
                            break;
                        case "SAS/NP/0005":
                            detail.DisplayName = "NP-DO";
                            detail.ReportName = "NP Delivery Order";
                            detail.ReportCategory_ID = "1";
                            break;
                        case "SAS/NP/0006":
                            detail.DisplayName = "NP-SI";
                            detail.ReportName = "NP Sales Invoice";
                            detail.ReportCategory_ID = "1";
                            break;
                        case "SAS/NP/0007":
                            detail.DisplayName = "NP-SRN";
                            detail.ReportName = "NP Sales Return Note";
                            detail.ReportCategory_ID = "1";
                            break;
                        case "SAS/NP/0008":
                            detail.DisplayName = "NP-SR";
                            detail.ReportName = "NP Sales Receipt";
                            detail.ReportCategory_ID = "1";
                            break;
                        case "SAS/NP/0009":
                            detail.DisplayName = "NP-PI";
                            detail.ReportName = "NP Proforma Invoice";
                            detail.ReportCategory_ID = "1";
                            break;
                        #endregion

                        #region Sales Pending

                        case "SAS/PD/0001":
                            detail.DisplayName = "RG-PDSTW";
                            detail.ReportName = "RG Pending DeliverySummary TownWise";
                            detail.ReportCategory_ID = "17";
                            break;
                        case "SAS/PD/0002":
                            detail.DisplayName = "RG-PDDTW";
                            detail.ReportName = "RG Pending Delivery Details TownWise";
                            detail.ReportCategory_ID = "17";
                            break;
                        case "SAS/PD/0003":
                            detail.DisplayName = "RG-PDIS";
                            detail.ReportName = "RG Pending Delivery Item Summary";
                            detail.ReportCategory_ID = "17";
                            break;
                        case "SAS/PD/0004":
                            detail.DisplayName = "RG-PDIC";
                            detail.ReportName = "RG Pending Delivery Itemfor Customers";
                            detail.ReportCategory_ID = "17";
                            break;
                        case "SAS/PD/0005":
                            detail.DisplayName = "RG-PDSTW";
                            detail.ReportName = "RG Pending Delivery Item Datewise";
                            detail.ReportCategory_ID = "17";
                            break;
                        #endregion

                        #region Sales Registers
                        case "SAS/RG/0001":
                            detail.DisplayName = "RG-IS";
                            detail.ReportName = "RG Inquiry Summary";
                            detail.ReportCategory_ID = "6";
                            break;
                        case "SAS/RG/0002":
                            detail.DisplayName = "RG-ID";
                            detail.ReportName = "RG Inquiry Detail";
                            detail.ReportCategory_ID = "6";
                            break;
                        case "SAS/RG/0003":
                            detail.DisplayName = "RG-QS";
                            detail.ReportName = "RG Quotation Summary";
                            detail.ReportCategory_ID = "6";
                            break;
                        case "SAS/RG/0004":
                            detail.DisplayName = "RG-QD";
                            detail.ReportName = "RG Quotation Details";
                            detail.ReportCategory_ID = "6";
                            break;
                        case "SAS/RG/0005":
                            detail.DisplayName = "RG-PIS";
                            detail.ReportName = "RG Performa Invoice Summary";
                            detail.ReportCategory_ID = "6";
                            break;
                        case "SAS/RG/0006":
                            detail.DisplayName = "RG-PID";
                            detail.ReportName = "RG Performa Invoice Details";
                            detail.ReportCategory_ID = "6";
                            break;
                        case "SAS/RG/0007":
                            detail.DisplayName = "RG-COS";
                            detail.ReportName = "RG Customer Order Summary";
                            detail.ReportCategory_ID = "6";
                            break;
                        case "SAS/RG/0008":
                            detail.DisplayName = "RG-COD";
                            detail.ReportName = "RG Customer Order Detail";
                            detail.ReportCategory_ID = "6";
                            break;
                        case "SAS/RG/0009":
                            detail.DisplayName = "RG-DOS";
                            detail.ReportName = "RG Delivery Order Summary";
                            detail.ReportCategory_ID = "6";
                            break;
                        case "SAS/RG/0010":
                            detail.DisplayName = "RG-DOD";
                            detail.ReportName = "RG Delivery Order Detail";
                            detail.ReportCategory_ID = "6";
                            break;
                        case "SAS/RG/0011":
                            detail.DisplayName = "RG-IS";
                            detail.ReportName = "RG Invoice Summary";
                            detail.ReportCategory_ID = "6";
                            break;
                        case "SAS/RG/0012":
                            detail.DisplayName = "RG-ID";
                            detail.ReportName = "RG Invoice Detail";
                            detail.ReportCategory_ID = "6";
                            break;
                        case "SAS/RG/0013":
                            detail.DisplayName = "RG-SRS";
                            detail.ReportName = "RG Sales Return Summary";
                            detail.ReportCategory_ID = "6";
                            break;
                        case "SAS/RG/0014":
                            detail.DisplayName = "RG-IRD";
                            detail.ReportName = "RG Sales Return Detail";
                            detail.ReportCategory_ID = "6";
                            break;
                        case "SAS/RG/0015":
                            detail.DisplayName = "RG-ASR";
                            detail.ReportName = "RG Annual Sales Report";
                            detail.ReportCategory_ID = "6";
                            break;
                        #endregion

                        #region Sales Standerd
                        case "SAS/ST/0001":
                            detail.DisplayName = "ST-MSCWR";
                            detail.ReportName = "ST Monthly Sales Customer Wise Rupees";
                            detail.ReportCategory_ID = "11";
                            break;
                        case "SAS/ST/0002":
                            detail.DisplayName = "ST-ASRCSW";
                            detail.ReportName = "ST Annual Sales Report Customer SalesmanWise"; 
                            detail.ReportCategory_ID = "11";
                            break;

                        case "SAS/ST/0003":
                            detail.DisplayName = "ST-MTOSCW";
                            detail.ReportName = "ST Monthly Turn Over Statement CustomerWise";
                            detail.ReportCategory_ID = "11";
                            break;
                             
                        case "SAS/ST/0004":
                            detail.DisplayName = "ST-MTOSSW";
                            detail.ReportName = "ST Monthly Turn Over Statement SalesmanWise";
                            detail.ReportCategory_ID = "11";
                            break;
                        case "SAS/ST/0005":
                            detail.DisplayName = "ST-SRSIW";
                            detail.ReportName = "ST Sales Report Summary ItemWise";
                            detail.ReportCategory_ID = "11";
                            break;
                        case "SAS/ST/0006":
                            detail.DisplayName = "ST-TRCN";
                            detail.ReportName = "ST Tax Report CreditNote";
                            detail.ReportCategory_ID = "11";
                            break;
                        case "SAS/ST/0007":
                            detail.DisplayName = "ST-TRP";
                            detail.ReportName = "ST Tax Report Purchase";
                            detail.ReportCategory_ID = "11";
                            break;
                        case "SAS/ST/0008":
                            detail.DisplayName = "ST-TRS";
                            detail.ReportName = "ST Tax Report Summary";
                            detail.ReportCategory_ID = "11";
                            break;
                        case "SAS/ST/0009":
                            detail.DisplayName = "ST-TRDI";
                            detail.ReportName = "ST Tax Report Detail Invoice";
                            detail.ReportCategory_ID = "11";
                            break;
                        case "SAS/ST/0010":
                            detail.DisplayName = "ST-DLR";
                            detail.ReportName = "ST Dilivery Listing Report";
                            detail.ReportCategory_ID = "11";
                            break;
                        case "SAS/ST/0011":
                            detail.DisplayName = "ST-SRIW";
                            detail.ReportName = "ST Sales Report Itemwise";
                            detail.ReportCategory_ID = "11";
                            break;
                        case "SAS/ST/0012":
                            detail.DisplayName = "ST-OOCW";
                            detail.ReportName = "ST Outstanding Orders Customer Wise";
                            detail.ReportCategory_ID = "11";
                            break;
                        case "SAS/ST/0013":
                            detail.DisplayName = "ST-ILR";
                            detail.ReportName = "ST Invoice Listing Report";
                            detail.ReportCategory_ID = "11";
                            break;  
                                              
                        case "SAS/ST/0014":
                            detail.DisplayName = "ST-SRIW";
                            detail.ReportName = "ST ST Sales Report Itemwise";
                            detail.ReportCategory_ID = "11";
                            break;
                        case "SAS/ST/0015":
                            detail.DisplayName = "ST-MSCWD";
                            detail.ReportName = "ST Monthly Sales Customer Wise Dollars";
                            detail.ReportCategory_ID = "11";
                            break; 
                        #endregion

                        #region Sales Traking
                        case "SAS/TK/0001":
                            detail.DisplayName = "RG-IPLCW";
                            detail.ReportName = "RG Item Prise List CustomerWise";
                            detail.ReportCategory_ID = "22";
                            break;
                        case "SAS/TK/0002":
                            detail.DisplayName = "RG-CWDR";
                            detail.ReportName = "RG Customer Wise DeliveryReport";
                            detail.ReportCategory_ID = "22";
                            break;
                        case "SAS/TK/0003":
                            detail.DisplayName = "RG-JWDR";
                            detail.ReportName = "RG Job wise DeliveryReport";
                            detail.ReportCategory_ID = "22";
                            break;
                        case "SAS/TK/0004":
                            detail.DisplayName = "RG-DTR";
                            detail.ReportName = "RG Delivery TrackingReport";
                            detail.ReportCategory_ID = "22";
                            break;
                        #endregion

                        #region stocks Floor
                        case "SCS/FL/0001":
                            detail.DisplayName = "RG-Store";
                            detail.ReportName = "RG Store";
                            detail.ReportCategory_ID = "29";
                            break;
                        case "SCS/FL/0002":
                            detail.DisplayName = "RG-Section";
                            detail.ReportName = "RG Section";
                            detail.ReportCategory_ID = "29";
                            break;
                        case "SCS/FL/0003":
                            detail.DisplayName = "RG-Department";
                            detail.ReportName = "RG Department";
                            detail.ReportCategory_ID = "29";
                            break;

                        #endregion

                        #region Stocks Note Printing
                        case "SCS/NP/0001":
                            detail.DisplayName = "NP-LoanIn";
                            detail.ReportName = "NP LoanIn";
                            detail.ReportCategory_ID = "2";
                            break;
                        case "SCS/NP/0002":
                            detail.DisplayName = "NP-LoanOut";
                            detail.ReportName = "NP LoanOut";
                            detail.ReportCategory_ID = "2";
                            break;
                        case "SCS/NP/0003":
                            detail.DisplayName = "NP-PRN";
                            detail.ReportName = "NP Purchase RequisitionNote";
                            detail.ReportCategory_ID = "2";
                            break;
                        case "SCS/NP/0004":
                            detail.DisplayName = "NP-PO";
                            detail.ReportName = "NP Purchase Order";
                            detail.ReportCategory_ID = "2";
                            break;
                        case "SCS/NP/0005":
                            detail.DisplayName = "NP-GRN";
                            detail.ReportName = "NP Goods ReceivedNote";
                            detail.ReportCategory_ID = "2";
                            break;
                        case "SCS/NP/0006":
                            detail.DisplayName = "NP-GIN";
                            detail.ReportName = "NP Goods IssuedNote";
                            detail.ReportCategory_ID = "2";
                            break;
                        case "SCS/NP/0007":
                            detail.DisplayName = "NP-PRN";
                            detail.ReportName = "NP Purchase ReturnNote";
                            detail.ReportCategory_ID = "2";
                            break;
                        case "SCS/NP/0008":
                            detail.DisplayName = "NP-DGN";
                            detail.ReportName = "NP Damaged GoodsNote";
                            detail.ReportCategory_ID = "2";
                            break;
                        case "SCS/NP/0009":
                            detail.DisplayName = "NP-DIN";
                            detail.ReportName = "NP Discarded ItemNote";
                            detail.ReportCategory_ID = "2";
                            break;
                        case "SCS/NP/0010":
                            detail.DisplayName = "NP-ISN";
                            detail.ReportName = "NP Item SplitNote";
                            detail.ReportCategory_ID = "2";
                            break;
                        case "SCS/NP/0011":
                            detail.DisplayName = "NP-SA";
                            detail.ReportName = "NP Stock Adjustment";
                            detail.ReportCategory_ID = "2";
                            break;
                        #endregion

                        #region Stocks Registers
                        case "SCS/RG/0001":
                            detail.DisplayName = "RG-PRS";
                            detail.ReportName = "RG Purchase Requisition Summary";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0002":
                            detail.DisplayName = "RG-PRD";
                            detail.ReportName = "RG Purchase Requisition Detail";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0003":
                            detail.DisplayName = "RG-PO Summary";
                            detail.ReportName = "RG PO Summary";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0004":
                            detail.DisplayName = "RG-PO Detail";
                            detail.ReportName = "RG PO Detail";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0005":
                            detail.DisplayName = "RG-GRNS";
                            detail.ReportName = "RG GRN Summary";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0006":
                            detail.DisplayName = "RG-GRND";
                            detail.ReportName = "RG GRN Detail";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0007":
                            detail.DisplayName = "RG-ISS";
                            detail.ReportName = "RG Item Split Summary";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0008":
                            detail.DisplayName = "RG-ISD";
                            detail.ReportName = "RG Item Split Detail";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0009":
                            detail.DisplayName = "RG-GS";
                            detail.ReportName = "RG GIN Summary";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0010":
                            detail.DisplayName = "RG-GIND";
                            detail.ReportName = "RG GIN Detail";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0011":
                            detail.DisplayName = "RG-GRNS";
                            detail.ReportName = "RG DGN Summary";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0012":
                            detail.DisplayName = "RG-GRND";
                            detail.ReportName = "RG DGN Detail";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0013":
                            detail.DisplayName = "RG-DINS";
                            detail.ReportName = "RG DIN Summary";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0014":
                            detail.DisplayName = "RG-DIND";
                            detail.ReportName = "RG DIN Detail";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0015":
                            detail.DisplayName = "RG-ISISRS";
                            detail.ReportName = "RG Internal Store ISR Summary";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0016":
                            detail.DisplayName = "RG-ISISRD";
                            detail.ReportName = "RG Internal Store ISR Detail";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0017":
                            detail.DisplayName = "RG-ISGINS";
                            detail.ReportName = "RG Internal Store GIN Summary";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0018":
                            detail.DisplayName = "RG-ISGIND";
                            detail.ReportName = "RG Internal Store GIN Detail";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0019":
                            detail.DisplayName = "RG-ISGRNS";
                            detail.ReportName = "RG Internal Store GRN Summary";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0020":
                            detail.DisplayName = "RG-ISGRND";
                            detail.ReportName = "RG Internal Store GRN Detail";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0021":
                            detail.DisplayName = "RG-ISISRS";
                            detail.ReportName = "RG Internal Section iSR Summary";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0022":
                            detail.DisplayName = "RG-ISISRD";
                            detail.ReportName = "RG Internal Section iSR Detail";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0023":
                            detail.DisplayName = "RG-ISGINS";
                            detail.ReportName = "RG Internal Section GIN Summary";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0024":
                            detail.DisplayName = "RG-ISGIND";
                            detail.ReportName = "RG Internal Section GIN Detail";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0025":
                            detail.DisplayName = "RG-ISGRNS";
                            detail.ReportName = "RG Internal Section GRN Summary";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0026":
                            detail.DisplayName = "RG-ISGRND";
                            detail.ReportName = "RG Internal Section GRN Detail";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0027":
                            detail.DisplayName = "RG-SAS";
                            detail.ReportName = "RG Stock Adjustment Summery";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0028":
                            detail.DisplayName = "RG-SAD";
                            detail.ReportName = "RG Stock Adjustment Details";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0029":
                            detail.DisplayName = "RG-FGTNS";
                            detail.ReportName = "RG Finished Goods Transfer Note Summary ";
                            detail.ReportCategory_ID = "7";
                            break;
                        case "SCS/RG/0030":
                            detail.DisplayName = "RG-FGTND";
                            detail.ReportName = "RG_Finished_Goods_Transfer_Note_Details";
                            detail.ReportCategory_ID = "7";
                            break;  

                      #endregion

                        #region Stock Standerd
                        case "SCS/ST/0001":
                            detail.DisplayName = "ST-STRQTY";
                            detail.ReportName = "ST Stocks Tracking Report Qty";
                            detail.ReportCategory_ID = "12";
                            break;
                        case "SCS/ST/0002":
                            detail.DisplayName = "ST-STRW";
                            detail.ReportName = "ST Stocks Tracking Report Weight";
                            detail.ReportCategory_ID = "12";
                            break;  

                        case "SCS/ST/0003":
                            detail.DisplayName = "ST-SBVSPO";
                            detail.ReportName = "ST Stocks Balance vs PendingOders";
                            detail.ReportCategory_ID = "12";
                            break;

                        case "SCS/ST/0004":
                            detail.DisplayName = "ST-OSR";
                            detail.ReportName = "ST Opening Stock Report";
                            detail.ReportCategory_ID = "12";
                            break;

                        case "SCS/ST/0005":
                            detail.DisplayName = "ST-ISNDR";
                            detail.ReportName = "ST Item SplitNote DeltaReport";
                            detail.ReportCategory_ID = "12";
                            break;

                        case "SCS/ST/0006":
                            detail.DisplayName = "ST-SRVSI";
                            detail.ReportName = "ST Store Requests vs Issues";
                            detail.ReportCategory_ID = "12";
                            break;

                        case "SCS/ST/0007":
                            detail.DisplayName = "ST-PLO";
                            detail.ReportName = "ST Pending LoanOut";
                            detail.ReportCategory_ID = "12";
                            break;

                        case "SCS/ST/0008":
                            detail.DisplayName = "ST-PLI";
                            detail.ReportName = "ST Pending LoanIn";
                            detail.ReportCategory_ID = "12";
                            break;

                        case "SCS/ST/0009":
                            detail.DisplayName = "ST-POTR";
                            detail.ReportName = "ST Purchase Order Tracking Report";
                            detail.ReportCategory_ID = "12";
                            break;
                        case "SCS/ST/0010":
                            detail.DisplayName = "ST-SAAR";
                            detail.ReportName = "ST Stock Age Analysis Report";
                            detail.ReportCategory_ID = "12";
                            break;
                        case "SCS/ST/0011":
                            detail.DisplayName = "ST-SVR";
                            detail.ReportName = "ST Stock Value Report";
                            detail.ReportCategory_ID = "12";
                            break;
                        case "SCS/ST/0012":
                            detail.DisplayName = "ST-POICH";
                            detail.ReportName = "ST Purchase Order Item Cost History";
                            detail.ReportCategory_ID = "12";
                            break;
                       

                            
                        #endregion

                    }

                    //update record
                    detail.Update();
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
    }
}
