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
    public partial class frm_toolSetFormMaster : Form
    {
        #region Public variables
       public int iFormID; 
        #endregion

        #region Form Load
        private void frm_toolCheckToDepositeMode1_Load(object sender, EventArgs e)
        {
            ClearFields();
        }

        public frm_toolSetFormMaster()
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
                MessageBox.Show("All Forms Are Updated Succesfull.", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Byte[] img = new byte[0];
            List<tbl_securityFormMaster> details = tbl_securityFormMaster.SelectAll();
            foreach (tbl_securityFormMaster detail in details)
            {               
                switch(detail.Form_ID)
                {
                    case 1 :
                        detail.DisplayName = "M-Item";
                        detail.FormName = "Item Master";
                        img = detail.Image;
                        ////detail.Update();
                        break;
                    case 2 :
                        detail.DisplayName = "M-Cust";
                        detail.FormName = "Customer Master";
                        //detail.Update();
                        break;
                    case 3 :
                        detail.DisplayName = "M-Supp";
                        detail.FormName = "Supplier Master";
                        //detail.Update();
                        break;
                    case 4 :
                        detail.FormName = "Supp. Purchase Order [PO]";
                        detail.DisplayName = "P.O";
                        //detail.Update();
                        break;
                    case 5 :
                        detail.FormName = "Goods Received Note [GRN]";
                        detail.DisplayName = "G.R.N";
                        //detail.Update();
                        break;
                    case 6 :
                        detail.FormName = "Supplier Return Note [SRN]";
                        detail.DisplayName = "S.R.N";
                        //detail.Update();
                        break;
                    case 7 :
                        detail.FormName = "Goods Issue Note [GIN]";
                        detail.DisplayName = "G.I.N";
                        //detail.Update();
                        break;
                    case 8 :
                        detail.FormName = "Issue Return Note [IRN]";
                        detail.DisplayName = "I.R.N]";
                        //detail.Update();
                        break;
                    case 9 :
                        detail.FormName = "Customer Order";
                        detail.DisplayName = "C.O";
                        //detail.Update();
                        break;
                    case 10 :
                        detail.FormName = "Customer Invoice";
                        detail.DisplayName = "Invoice";
                        //detail.Update();
                        break;
                    case 11 :
                        detail.FormName = "Customer Delivery Order [DO]";
                        detail.DisplayName = "D.O";
                        //detail.Update();
                        break;
                    case 12 :
                        detail.FormName = "Job Order";
                        detail.DisplayName = "J.O";
                        //detail.Update();
                        break;
                     case 13 :
                        detail.FormName = "Store Requisition Note [SR]";
                        detail.DisplayName = "S.R";
                        detail.IsVisible = false;
                        break;
                    case 14 :
                        detail.FormName = "Goods Transfer Note [GTN]";
                        detail.DisplayName = "G.T.N";
                        //detail.Update();
                        break;
                    case 15 :
                        detail.FormName = "Loan In/Out Note";
                        detail.DisplayName = "Loan";
                        //detail.Update();
                        break;
                    case 16 :
                        detail.FormName = "Loan-Out Note";
                        detail.DisplayName = "Loan";
                        ////detail.Update();
                        break;
                    case 17 :
                        detail.FormName = "Damaged Good Note [DGN]";
                        detail.DisplayName = "D.G.N";
                        //detail.Update();
                        break;
                    case 18 :
                        detail.FormName = "Discarded Item Note [DIN]";
                        detail.DisplayName = "D.I.N";
                        //detail.Update();
                        break;
                    case 19 :
                        detail.FormName = "Cheque Register [CR]";
                        detail.DisplayName = "Cheq-R";
                        //detail.Update();
                        break;
                    case 20 :
                        detail.FormName = "Cheque Management [CM]";
                        detail.DisplayName = "Chq.Mg";
                        //detail.Update();
                        break;
                    case 21 :
                        detail.FormName = "Sales Receipt";
                        detail.DisplayName = "Sls-Rpt";
                        //detail.Update();
                        break;
                    case 22 :
                        detail.FormName = "Cust. Sales Inquiry [CSI]";
                        detail.DisplayName = "Inqry";
                        //detail.Update();
                        break;
                     case 23 :
                        detail.FormName = "Customer Quotation";
                        detail.DisplayName = "C-Quot";
                        //detail.Update();
                        break;
                    case 24 :
                        detail.FormName = "Customer Pro-forma Invoice";
                        detail.DisplayName = "Pro.INV";
                        //detail.Update();
                        break;
                    case 25 :
                        detail.FormName = "Company Information";
                        detail.DisplayName = "COM-I";
                        //detail.Update();
                        break;
                    case 26 :
                        detail.FormName = "User Master";
                        detail.DisplayName = "M-User";
                        //detail.Update();
                        break;
                    case 27 :
                        detail.FormName = "User Permission";
                        detail.DisplayName = "U-Per";
                        //detail.Update();
                        break;
                    case 28 :
                        detail.FormName = "Cheque Deposite";
                        detail.DisplayName = "Cheq-D";
                        //detail.Update();
                        break;
                    case 29 :
                        detail.FormName = "Master Reports";
                        detail.DisplayName = "RPT1";
                        //detail.Update();
                        break;
                    case 30 :
                        detail.FormName = "Cheque Re-Issue";
                        detail.DisplayName = "Chq-RI";
                        //detail.Update();
                        break;
                    case 31 :
                        detail.FormName = "Cheque Reconsilation";
                        detail.DisplayName = "Chq-Rec";
                        //detail.Update();
                        break;
                    case 33 :
                        detail.FormName = "Reference";
                        detail.DisplayName = "REF";
                        //detail.Update();
                        break;
                     case 34 :
                        detail.FormName = "Country Master";
                        detail.DisplayName = "M-Cntry";
                        //detail.Update();
                        break;
                    case 35 :
                        detail.FormName = "Bank Master";
                        detail.DisplayName = "M-Bank";
                        //detail.Update();
                        break;
                    case 36 :
                        detail.FormName = "Customer Category Master";
                        detail.DisplayName = "Cus-Cat";
                        //detail.Update();
                        break;
                    case 37 :
                        detail.FormName = "Customer Type Master";
                        detail.DisplayName = "Cus-Typ";
                        //detail.Update();
                        break;
                    case 38 :
                        detail.FormName = "Customer Class Master";
                        detail.DisplayName = "Cus-Cls";
                        //detail.Update();
                        break;
                    case 39 :
                        detail.FormName = "Supplier Class Master";
                        detail.DisplayName = "Supp-Cls";
                        //detail.Update();
                        break;
                    case 40 :
                        detail.FormName = "Supplier Type Master";
                        detail.DisplayName = "Supp-Typ";
                        //detail.Update();
                        break;
                    case 41 :
                        detail.FormName = "Supplier Category Master";
                        detail.DisplayName = "Supp-Cat";
                        //detail.Update();
                        break;
                    case 42 :
                        detail.FormName = "Item Class Master";
                        detail.DisplayName = "Itm-Cls";
                        //detail.Update();
                        break;
                    case 43 :
                        detail.FormName = "Item Type Master";
                        detail.DisplayName = "Itm-Typ";
                        //detail.Update();
                        break;
                     case 44 :
                        detail.FormName = "Item Category Master";
                        detail.DisplayName = "Itm-Cat";
                        //detail.Update();
                        break;
                    case 45 :
                        detail.FormName = "Database Backup";
                        detail.DisplayName = "Backup";
                        //detail.Update();
                        break;
                    case 46 :
                        detail.FormName = "Area Master";
                        detail.DisplayName = "M-Area";
                        //detail.Update();
                        break;
                    case 47 :
                        detail.FormName = "Route Master";
                        detail.DisplayName = "M-Route";
                        //detail.Update();
                        break;
                    case 48 :
                        detail.FormName = "Branch Master";
                        detail.DisplayName = "M.Brnch";
                        //detail.Update();
                        break;
                    case 49 :
                        detail.FormName = "District Master";
                        detail.DisplayName = "M-Dist";
                        //detail.Update();
                        break;
                    case 50 :
                        detail.FormName = "Province Master";
                        detail.DisplayName = "M-Prov";
                        //detail.Update();
                        break;
                    case 51 :
                        detail.FormName = "City Master";
                        detail.DisplayName = "M-City";
                        //detail.Update();
                        break;
                    case 52 :
                        detail.FormName = "Town Master";
                        detail.DisplayName = "M-Town";
                        //detail.Update();
                        break;
                    case 53 :
                        detail.FormName = "Employee Master";
                        detail.DisplayName = "M-EMP";
                        //detail.Update();
                        break;
                     case 54 :
                        detail.FormName = "UOM Category Master";
                        detail.DisplayName = "UOM-Cat";
                        //detail.Update();
                        break;
                    case 55 :
                        detail.FormName = "UOM Master";
                        detail.DisplayName = "M-UOM";
                        //detail.Update();
                        break;
                    case 56 :
                        detail.FormName = "Sales Manager";
                        detail.DisplayName = "SalesMgr";
                        //detail.Update();
                        break;
                    case 57 :
                        detail.FormName = "Area Sales Manager";
                        detail.DisplayName = "AreaMgr";
                        //detail.Update();
                        break;
                    case 58 :
                        detail.FormName = "Sales Executive";
                        detail.DisplayName = "SalesEx";
                        //detail.Update();
                        break;
                    case 59 :
                        detail.FormName = "Sales Rep";
                        detail.DisplayName = "SalesRep";
                        //detail.Update();
                        break;
                    case 60 :
                        detail.FormName = "Cheque Tracer";
                        detail.DisplayName = "Cheq-T";
                        //detail.Update();
                        break;
                    case 61 :
                        detail.FormName = "Report Sales Register - Deleted";
                       detail.DisplayName = "Del";
                        detail.IsEnable = false;
                        detail.IsVisible = false;
                        break;
                    case 62 :
                        detail.FormName = "GRN Trading Stock";
                        detail.DisplayName = "i-GRN";
                        detail.IsVisible = false;
                        break;
                    case 63 :
                        detail.FormName = "GIN Trading Stock";
                        detail.DisplayName = "i-GIN";
                        detail.IsVisible = false;
                        break;
                     case 64 :
                        detail.FormName = "SRN Trading Stock";
                        detail.DisplayName = "i-SR";
                        detail.IsVisible = false;
                        break;
                    case 65 :
                        detail.FormName = "Report Cheque Register";
                        detail.DisplayName = "Rpt.Reg";
                        //detail.Update();
                        break;
                    case 66 :
                        detail.FormName = "Report Cheque Standard";
                        detail.DisplayName = "Rpt.Std";
                        //detail.Update();
                        break;
                    case 67 :
                        detail.FormName = "Report Sales Standard - Deleted";
                        detail.DisplayName = "Del";
                        detail.IsEnable = false;
                        detail.IsVisible = false;
                        //detail.Update();
                        break;
                    case 68 :
                        detail.FormName = "Pre-Costing";
                        detail.DisplayName = "Pr-Cost";
                        //detail.Update();
                        break;
                    case 69 :
                        detail.FormName = "Machine Master";
                        detail.DisplayName = "M-Mac";
                        //detail.Update();
                        break;
                    case 70 :
                        detail.FormName = "Sales Job Order";
                        detail.DisplayName = "S.J.O";
                        //detail.Update();
                        break;
                    case 71 :
                        detail.FormName = "Driver";
                        detail.DisplayName = "Driver";
                        //detail.Update();
                        break;
                    case 72 :
                        detail.FormName = "Assistant";
                        detail.DisplayName = "Assist";
                        //detail.Update();
                        break;
                    case 73 :
                        detail.FormName = "Vehicle";
                        detail.DisplayName = "Vehicle";
                        //detail.Update();
                        break;
                     case 74 :
                        detail.FormName = "Machine Class";
                        detail.DisplayName = "Mac-Cls";
                        //detail.Update();
                        break;
                    case 75 :
                        detail.FormName = "Machine Type";
                        detail.DisplayName = "Mac-Typ";
                        //detail.Update();
                        break;
                    case 76 :
                        detail.FormName = "Machine Category";
                        detail.DisplayName = "Mac-Cat";
                        //detail.Update();
                        break;
                    case 77 :
                        detail.FormName = "Machine Specification";
                        detail.DisplayName = "Mac-Sp";
                        //detail.Update();
                        break;
                    case 82 :
                        detail.FormName = "Job Viewer";
                        detail.DisplayName = "Job-V";
                        //detail.Update();
                        break;
                    case 83 :
                        detail.FormName = "Machine Sub Category";
                        detail.DisplayName = "M.S.C";
                        //detail.Update();
                        break;
                    case 84 :
                        detail.FormName = "Machine Sub Specification";
                        detail.DisplayName = "M.S.S";
                        //detail.Update();
                        break;
                    case 85 :
                        detail.FormName = "Item Specification";
                        detail.DisplayName = "I.Spec";
                        //detail.Update();
                        break;
                    case 86 :
                        detail.FormName = "Item Sub Category";
                        detail.DisplayName = "S.Catg";
                        //detail.Update();
                        break;
                    case 87 :
                        detail.FormName = "Item Sub Specification";
                        detail.DisplayName = "S.Spec";
                        //detail.Update();
                        break;
                     case 88 :
                        detail.FormName = "Item Finished Good";
                        detail.DisplayName = "F.G";
                        //detail.Update();
                        break;
                    case 89 :
                        detail.FormName = "Company Country Master";
                        detail.DisplayName = "C-Cntry";
                        //detail.Update();
                        break;
                    case 90 :
                        detail.FormName = "Company Branch Master";
                        detail.DisplayName = "M-Brnch";
                        //detail.Update();
                        break;
                    case 91 :
                        detail.FormName = "Company Division Master";
                        detail.DisplayName = "M-Div";
                        //detail.Update();
                        break;
                    case 92 :
                        detail.FormName = "Company Department Master";
                        detail.DisplayName = "M-Dept";
                        //detail.Update();
                        break;
                    case 93 :
                        detail.FormName = "Company Section Master";
                        detail.DisplayName = "M-Sect";
                        //detail.Update();
                        break;
                    case 94 :
                        detail.FormName = "Company Master";
                        detail.DisplayName = "M-Com";
                        //detail.Update();
                        break;
                    case 95 :
                        detail.FormName = "Pre Plan Section";
                        detail.DisplayName = "PPS";
                        //detail.Update();
                        break;
                    case 97 :
                        detail.FormName = "Company Store Master";
                        detail.DisplayName = "M-Store";
                        //detail.Update();
                        break;
                    case 98 :
                        detail.FormName = "Account Receipt";
                        detail.DisplayName = "AccRcpt";
                        detail.IsVisible = false;
                        detail.IsEnable = false;
                        break;
                     case 99 :
                        detail.FormName = "Item Combination Material";
                        detail.DisplayName = "C.M";
                        //detail.Update();
                        break;
                    case 100 :
                        detail.FormName = "Production Job Order";
                        detail.DisplayName = "P.J.B";
                        //detail.Update();
                        break;
                    case 101 :
                        detail.FormName = "Work In Progress";
                        detail.DisplayName = "W.I.P";
                        //detail.Update();
                        break;
                    case 102 :
                        detail.FormName = "Create Petty Cash Account";
                        detail.DisplayName = "Acc-Pet";
                        //detail.Update();
                        break;
                    case 103 :
                        detail.FormName = "Update Petty Cash Accounts";
                        detail.DisplayName = "Upd-Pet";
                        //detail.Update();
                        break;
                    case 104 :
                        detail.FormName = "Petty Cash IncomeType";
                        detail.DisplayName = "Income";
                        //detail.Update();
                        break;
                    case 105 :
                        detail.FormName = "Petty Cash Expenditure Type";
                        detail.DisplayName = "Expend";
                        //detail.Update();
                        break;
                    case 106 :
                        detail.FormName = "Viewer Combination Material";
                        detail.DisplayName = "C.M.View";
                        //detail.Update();
                        break;
                    case 107 :
                        detail.FormName = "Viewer Finished Good";
                        detail.DisplayName = "F.G.View";
                        //detail.Update();
                        break;
                    case 108 :
                        detail.FormName = "Viewer Raw Material";
                        detail.DisplayName = "R.M.View";
                        //detail.Update();
                        break;
                     case 109 :
                        detail.FormName = "Viewer Laminated Material ";
                        detail.DisplayName = "L.M.View";
                        //detail.Update();
                        break;
                    case 110 :
                        detail.FormName = "Viewer Semi Finished ";
                        detail.DisplayName = "S.F.View";
                        //detail.Update();
                        break;
                    case 111 :
                        detail.FormName = "Viewer Section ";
                        detail.DisplayName = "Sec.View";
                        //detail.Update();
                        break;
                    case 112 :
                        detail.FormName = "Viewer Machine Line ";
                        detail.DisplayName = "Mac.View";
                        //detail.Update();
                        break;
                    case 113 :
                        detail.FormName = "Section Goods Receive Note";
                        detail.DisplayName = "i-GRN";
                        detail.IsVisible = false;
                        break;
                    case 114 :
                        detail.FormName = "Section Goods Issue Note";
                        detail.DisplayName = "i-GIN";
                        detail.IsVisible = false;
                        break;
                    case 115 :
                        detail.FormName = "Section Requisition Note";
                        detail.DisplayName = "i-SR";
                        detail.IsVisible = false;
                        break;
                    case 116 :
                        detail.FormName = "Item Master Home";
                        detail.DisplayName = "M-Itm-hm";
                        //detail.Update();
                        break;
                    case 117 :
                        detail.FormName = "Report Petty Cash Account";
                        detail.DisplayName = "R-Pet";
                        //detail.Update();
                        break;
                    case 118 :
                        detail.FormName = "Report Item Summary";
                        detail.DisplayName = "R-I.Sum";
                        //detail.Update();
                        break;
                     case 119 :
                        detail.FormName = "Flow Stock Balance";
                        detail.DisplayName = "Fl-Stk";
                        //detail.Update();
                        break;
                    case 120 :
                        detail.FormName = "Offcut Entry";
                        detail.DisplayName = "Off-En";
                        //detail.Update();
                        break;
                    case 121 :
                        detail.FormName = "Viewer Semi Finished Goods";
                        detail.DisplayName = "S.F-View";
                        //detail.Update();
                        break;
                    case 122 :
                        detail.FormName = "Daily Planning Report";
                        detail.DisplayName = "RptPrd1";
                        //detail.Update();
                        break;
                    case 123 :
                        detail.FormName = "Daily Production Report";
                        detail.DisplayName = "RptPrd2";
                        //detail.Update();
                        break;
                    case 124 :
                        detail.FormName = "Section Stock Transfer Report";
                        detail.DisplayName = "RptStk1";
                        //detail.Update();
                        break;
                    case 125 :
                        detail.FormName = "Store Stock Transfer Report";
                        detail.DisplayName = "RptStk2";
                        //detail.Update();
                        break;
                    case 127 :
                        detail.FormName = "Quotation Request";
                        detail.DisplayName = "Q.Req";
                        //detail.Update();
                        break;
                    case 128 :
                        detail.FormName = "Supplier Purchase Order";
                        detail.DisplayName = "P.O";
                        //detail.Update();
                        break;
                    case 129 :
                        detail.FormName = "Supplier Goods Received Note";
                        detail.DisplayName = "G.R.N";
                        //detail.Update();
                        break;
                     case 130 :
                        detail.FormName = "Supplier Purchase Return Note";
                        detail.DisplayName = "P.R.N";
                        //detail.Update();
                        break;
                    case 131 :
                        detail.FormName = "External Goods Issue Note";
                        detail.DisplayName = "G.I.N";
                        //detail.Update();
                        break;
                    case 132 :
                        detail.FormName = "Damaged Goods Note";
                        detail.DisplayName = "D.G.N";
                        //detail.Update();
                        break;
                    case 133 :
                        detail.FormName = "Discarded Goods Note";
                        detail.DisplayName = "Dis.G.N";
                        //detail.Update();
                        break;
                    case 134 :
                        detail.FormName = "Sales Return Note";
                        detail.DisplayName = "S.R.N";
                        //detail.Update();
                        break;
                    case 135 :
                        detail.FormName = "Credit Note";
                        detail.DisplayName = "Crdt.N";
                        //detail.Update();
                        break;
                    case 136 :
                        detail.FormName = "Invoice Settlement";
                        detail.DisplayName = "Inv.Set";
                        //detail.Update();
                        break;
                    case 137 :
                        detail.FormName = "Cash Payment";
                        detail.DisplayName = "Cash";
                        //detail.Update();
                        break;
                    case 138 :
                        detail.FormName = "Cheque Payment";
                        detail.DisplayName = "Cheq";
                        //detail.Update();
                        break;
                    case 139 :
                        detail.FormName = "Cheque Returned";
                        detail.DisplayName = "RC";
                        //detail.Update();
                        break;
                     case 140 :
                        detail.FormName = "Debit Note";
                        detail.DisplayName = "Dbt.N";
                        //detail.Update();
                        break;
                    case 141 :
                        detail.FormName = "GRN Settlement";
                        detail.DisplayName = "GRN-Set";
                        //detail.Update();
                        break;
                    case 142 :
                        detail.FormName = "Daily Production Progress Report";
                        detail.DisplayName = "Rpt-Prd3";
                        //detail.Update();
                        break;
                    case 143 :
                        detail.FormName = "Job Cost Analysis Report";
                        detail.DisplayName = "Cst-Rpt";
                        //detail.Update();
                        break;
                    case 144 :
                        detail.FormName = "Account Cash Book Receipt";
                        detail.DisplayName = "CB-Rcpt";
                        //detail.Update();
                        break;
                    case 145 :
                        detail.FormName = "Account Master Category";
                        detail.DisplayName = "AM-Cat";
                        //detail.Update();
                        break;
                    case 146 :
                        detail.FormName = "Accoun Sub Category";
                        detail.DisplayName = "AS-Cat";
                        //detail.Update();
                        break;
                    case 147 :
                        detail.FormName = "Account Fiscal Year";
                        detail.DisplayName = "Fin-Yr";
                        //detail.Update();
                        break;
                    case 148 :
                        detail.FormName = "Account Head";
                        detail.DisplayName = "Acc-H";
                        //detail.Update();
                        break;
                    case 149 :
                        detail.FormName = "Account Types";
                        detail.DisplayName = "Acc-Typ";
                        //detail.Update();
                        break;
                     case 150 :
                        detail.FormName = "Account Master";
                        detail.DisplayName = "M-Acc";
                        //detail.Update();
                        break;
                    case 151 :
                        detail.FormName = "Account Cash Book Payments";
                        detail.DisplayName = "Paymnt";
                        //detail.Update();
                        break;
                    case 152 :
                        detail.FormName = "Payment Advice";
                        detail.DisplayName = "Pay.Adv";
                        //detail.Update();
                        break;
                    case 153 :
                        detail.FormName = "Item Laminated Material";
                        detail.DisplayName = "L.M";
                        //detail.Update();
                        break;
                    case 154 :
                        detail.FormName = "Employee Master";
                        detail.DisplayName = "M-Emp";
                        //detail.Update();
                        break;
                    case 155 :
                        detail.FormName = "Inquiry";
                        detail.DisplayName = "INQ";
                        //detail.Update();
                        break;
                    case 156 :
                        detail.FormName = "Stock Adjustment";
                        detail.DisplayName = "Stk.Adj";
                        //detail.Update();
                        break;
                    case 157 :
                        detail.FormName = "Tax Master";
                        detail.DisplayName = "M-Tax";
                        //detail.Update();
                        break;
                    case 158 :
                        detail.FormName = "Invoice Viewer";
                        detail.DisplayName = "Inv-View";
                        //detail.Update();
                        break;
                    case 159 :
                        detail.FormName = "Stock Add";
                        detail.DisplayName = "StkAdd";
                        detail.IsVisible = false;
                        detail.IsEnable = false;
                        break;
                     case 160 :
                        detail.FormName = "Finished Goods Transfer Note";
                        detail.DisplayName = "F.G.T.N";
                        //detail.Update();
                        break;
                    case 162 :
                        detail.FormName = "Lamination Type";
                        detail.DisplayName = "LamTyp";
                        //detail.Update();
                        break;
                    case 163 :
                        detail.FormName = "Lamination Material Type";
                        detail.DisplayName = "Lm-Typ";
                        //detail.Update();
                        break;
                    case 164 :
                        detail.FormName = "Brand ";
                        detail.DisplayName = "Brnd";
                        //detail.Update();
                        break;
                    case 165 :
                        detail.FormName = "Supervisor";
                        detail.DisplayName = "Sprv";
                        //detail.Update();
                        break;
                    case 166 :
                        detail.FormName = "Operator ";
                        detail.DisplayName = "Oprt";
                        //detail.Update();
                        break;
                    case 167 :
                        detail.FormName = "Assistant ";
                        detail.DisplayName = "Assist2";
                        //detail.Update();
                        break;
                    case 169 :
                        detail.FormName = "Sales Pending Order Report";
                        detail.DisplayName = "Rpt.Pen";
                        detail.SortOrder = 5;
                        //detail.Update();
                        break;
                    case 170 :
                        detail.FormName = "Sales Register Report";
                        detail.DisplayName = "Rpt.Reg";
                        detail.SortOrder = 3;
                        //detail.Update();
                        break;
                    case 171 :
                        detail.FormName = "Viewer Customer";
                        detail.DisplayName = "CusView";
                        //detail.Update();
                        break;
                     case 173 :
                        detail.FormName = "Schedule";
                        detail.DisplayName = "Schdl";
                        //detail.Update();
                        break;
                    case 174 :
                        detail.FormName = "Manage Route";
                        detail.DisplayName = "Rout.Mg";
                        //detail.Update();
                        break;
                    case 175 :
                        detail.FormName = "Sales Standard Report";
                        detail.DisplayName = "Rpt.Std";
                        detail.SortOrder = 2;
                        //detail.Update();
                        break;
                    case 176 :
                        detail.FormName = "Sales Return Note";
                        detail.DisplayName = "S.R.N2";
                        //detail.Update();
                        break;
                    case 177 :
                        detail.FormName = "Production Job Close";
                        detail.DisplayName = "P.J.C";
                        //detail.Update();
                        break;
                    case 178 :
                        detail.FormName = "Batch Approval";
                        detail.DisplayName = "B.App";
                        //detail.Update();
                        break;
                    case 179 :
                        detail.FormName = "Issued Ref No";
                        detail.DisplayName = "IssRef";
                        //detail.Update();
                        break;
                    case 180 :
                        detail.FormName = "Report Prodution Job Wise Input Output";
                        detail.DisplayName = "RptPrd3";
                        //detail.Update();
                        break;
                    case 183 :
                        detail.FormName = "Report Production Delivery";
                        detail.DisplayName = "RptPrd4";
                        //detail.Update();
                        break;
                    case 184 :
                        detail.FormName = "SecurityConfigType_Status";
                        detail.DisplayName = "[RPD]";
                        //detail.Update();
                        break;
                     case 185 :
                        detail.FormName = "SecurityConfigTypeValue";
                        detail.DisplayName = "[RPD]";
                        //detail.Update();
                        break;
                    case 186 :
                        detail.FormName = "SecurityConfigValue";
                        detail.DisplayName = "[RPD]";
                        //detail.Update();
                        break;
                    case 187 :
                        detail.FormName = "SecurityConfigStatus";
                        detail.DisplayName = "[RPD]";
                        //detail.Update();
                        break;
                    case 188 :
                        detail.FormName = "SecuritySoftwareModel";
                        detail.DisplayName = "[RPD]";
                        //detail.Update();
                        break;
                    case 189 :
                        detail.FormName = "SecurityProjects";
                        detail.DisplayName = "[RPD]";
                        //detail.Update();
                        break;
                    case 190 :
                        detail.FormName = "SecurityTerminal";
                        detail.DisplayName = "[RPD]";
                        //detail.Update();
                        break;
                    case 191 :
                        detail.FormName = "SecurityItemExceedLock";
                        detail.DisplayName = "[RPD]";
                        //detail.Update();
                        break;
                    case 192 :
                        detail.FormName = "Store Production";
                        detail.DisplayName = "FGTN";
                        //detail.Update();
                        break;
                    case 193 :
                        detail.FormName = "Currency";
                        detail.DisplayName = "Curr";
                        //detail.Update();
                        break;
                    case 194 :
                        detail.FormName = "Printer Master";
                        detail.DisplayName = "Printer";
                        //detail.Update();
                        break;
                     case 195 :
                        detail.FormName = "Report Permission";
                        detail.DisplayName = "Rpt.Per";
                        //detail.Update();
                        break;
                    case 196 :
                        detail.FormName = "Item Split Note";
                        detail.DisplayName = "Itm.Spl";
                        //detail.Update();
                        break;
                    case 197 :
                        detail.FormName = "Stock Standard Report";
                        detail.DisplayName = "Rpt.Std";
                        //detail.Update();
                        break;
                    case 198 :
                        detail.FormName = "Customer Order Viewer";
                        detail.DisplayName = "COView";
                        //detail.Update();
                        break;
                    case 199 :
                        detail.FormName = "Delivery Order Viewer";
                        detail.DisplayName = "DOView";
                        //detail.Update();
                        break;
                    case 200 :
                        detail.FormName = "Inquiry Viewer";
                        detail.DisplayName = "InqView";
                        //detail.Update();
                        break;
                    case 201 :
                        detail.FormName = "Invoice Viewer";
                        detail.DisplayName = "InvView";
                        //detail.Update();
                        break;
                    case 202 :
                        detail.FormName = "Receipt Tracer";
                        detail.DisplayName = "RcptTrc";
                        //detail.Update();
                        break;
                    case 203 :
                        detail.FormName = "Chat";
                        detail.DisplayName = "Chat";
                        //detail.Update();
                        break;
                    case 205 :
                        detail.FormName = "User Control";
                        detail.DisplayName = "Usr-Con";
                        //detail.Update();
                        break;
                     case 206 :
                        detail.FormName = "Report Job Wise";
                        detail.DisplayName = "RptPrd5";
                        //detail.Update();
                        break;
                    case 207 :
                        detail.FormName = "Document Audit";
                        detail.DisplayName = "Audit";
                        //detail.Update();
                        break;
                    case 208 :
                        detail.FormName = "Sales Finance Report";
                        detail.DisplayName = "Rpt.Fin";
                        detail.SortOrder = 4;
                        //detail.Update();
                        break;
                    case 209 :
                        detail.FormName = "Report Section Wise Status";
                        detail.DisplayName = "RptPrd6";
                        //detail.Update();
                        break;
                    case 210 :
                        detail.FormName = "Stock Register Report";
                        detail.DisplayName = "Rpt.Reg";
                        //detail.Update();
                        break;
                    case 211 :
                        detail.FormName = "Customer Order Edit";
                        detail.DisplayName = "CO-Edit";
                        //detail.Update();
                        break;
                    case 212 :
                        detail.FormName = "Pending Approval";
                        detail.DisplayName = "P-App";
                        //detail.Update();
                        break;
                    case 213 :
                        detail.FormName = "Pending Checking";
                        detail.DisplayName = "P-Chk";
                        //detail.Update();
                        break;
                    case 214 :
                        detail.FormName = "User Permission Pending Approval";
                        detail.DisplayName = "[P-AP]";
                        //detail.Update();
                        break;
                    case 215 :
                        detail.FormName = "User Permission Pending Checking";
                        detail.DisplayName = "[P-CK]";
                        //detail.Update();
                        break;
                     case 216 :
                        detail.FormName = "Cheque ReDeposit";
                        detail.DisplayName = "[RDP]";
                        //detail.Update();
                        break;
                    case 219 :
                        detail.FormName = "User Permission Audit";
                        detail.DisplayName = "[P-AU]";
                        //detail.Update();
                        break;
                    case 220 :
                        detail.FormName = "Planed Section Closer";
                        detail.DisplayName = "[PSC]";
                        //detail.Update();
                        break;
                    case 226 :
                        detail.FormName = "ProgressReport";
                        detail.DisplayName = "[PR]";
                        //detail.Update();
                        break;
                    case 227 :
                        detail.FormName = "Delivery Plan";
                        detail.DisplayName = "[DOP]";
                        //detail.Update();
                        break;
                    case 228 :
                        detail.FormName = "Cost Center 2";
                        detail.DisplayName = "[CC2]";
                        //detail.Update();
                        break;
                    case 229 :
                        detail.FormName = "Cost Center 3";
                        detail.DisplayName = "[CC3]";
                        //detail.Update();
                        break;
                    case 230 :
                        detail.FormName = "Cost Center 4";
                        detail.DisplayName = "[CC4]";
                        //detail.Update();
                        break;
                    case 231 :
                        detail.FormName = "Profit And Lost Report";
                        detail.DisplayName = "[PNL]";
                        //detail.Update();
                        break;
                    case 232 :
                        detail.FormName = "Petty Cach Master Report Null";
                        detail.DisplayName = "[PMR]";
                        //detail.Update();
                        break;
                     case 233 :
                        detail.FormName = "Report Setting";
                        detail.DisplayName = "[RS]";
                        //detail.Update();
                        break;
                    case 234 :
                        detail.FormName = "Auto Genarete Number Settings";
                        detail.DisplayName = "[GEN]";
                        //detail.Update();
                        break;
                    case 235 :
                        detail.FormName = "Petty Cash Account Basic";
                        detail.DisplayName = "[RPT]";
                        //detail.Update();
                        break;
                    case 238 :
                        detail.FormName = "Color Master";
                        detail.DisplayName = "[RPT]";
                        //detail.Update();
                        break;
                    case 239 :
                        detail.FormName = "Date Settings";
                        detail.DisplayName = "[RPT]";
                        //detail.Update();
                        break;
                    case 240 :
                        detail.FormName = "Delivery Order Manual Settle";
                        detail.DisplayName = "[DMS]";
                        //detail.Update();
                        break;
                    case 241 :
                        detail.FormName = "Email Configaration";
                        detail.DisplayName = "[Mail]";
                        //detail.Update();
                        break;
                    case 243 :
                        detail.FormName = "Cash Deposite";
                        detail.DisplayName = "[CaD]";
                        //detail.Update();
                        break;
                    case 245 :
                        detail.FormName = "Account Standard Report";
                        detail.DisplayName = "Rpt.Std";
                        //detail.Update();
                        break;
                    case 246 :
                        detail.FormName = "Sales Tools";
                        detail.DisplayName = "Tools";
                        //detail.Update();
                        break;
                     case 247 :
                        detail.FormName = "Finance Master";
                        detail.DisplayName = "M-Fin";
                        //detail.Update();
                        break;
                    case 248 :
                        detail.FormName = "Job Cost Analysis Summary";
                        detail.DisplayName = "[COS]";
                        //detail.Update();
                        break;
                    case 249 :
                        detail.FormName = "Sales Custom Report";
                        detail.DisplayName = "Rpt.Cus";
                        detail.SortOrder = 1;
                        //detail.Update();
                        break;
                        case 251 :
                        detail.FormName = "Sub Agent Payment Advice";
                        detail.DisplayName = "Sb.PayA";
                        //detail.Update();
                        break;
                        case 252 :
                        detail.FormName = "Stock Transfter Note";
                        detail.DisplayName = "StkTrf";
                        //detail.Update();
                        break;
                        case 253:
                        detail.FormName = "Purchase Requisition Note";
                        detail.DisplayName = "P.R.";
                        //detail.Update();
                        break;
                    case 254 :
                        detail.FormName = "Item Finance";
                        detail.DisplayName = "Itm.Fin";
                        //detail.Update();
                        break;
                    case 255:
                        detail.FormName = "Interim Receipt";
                        detail.DisplayName = "iRecpt";
                        //detail.Update();
                        break;
                    case 257:
                        detail.FormName = "Customer Master Report";
                        detail.DisplayName = "Mas-Cus";
                        //detail.Update();
                        break;
                    case 263:
                        detail.FormName = "Stock Statement";
                        detail.DisplayName = "Stk.St";
                        //detail.Update();
                        break;
                    case 265:
                        detail.FormName = "Material Requirement Planning";
                        detail.DisplayName = "M.R.P";
                        //detail.Update();
                        break;


                    case 400 :
                        detail.FormName = "Financial Year";
                        detail.DisplayName = "Mas-FY";
                        //detail.Update();
                        break;
                    case 401 :
                        detail.FormName = "Chart Of Accounts";
                        detail.DisplayName = "Mas-COF";
                        //detail.Update();
                        break;
                    case 402 :
                        detail.FormName = "Sub GL";
                        detail.DisplayName = "[RV]";
                        //detail.Update();
                        break;
                    case 403 :
                        detail.FormName = "Account Type";
                        detail.DisplayName = "[RV]";
                        //detail.Update();
                        break;
                    case 404 :
                        detail.FormName = "Account Head";
                        detail.DisplayName = "[RV]";
                        //detail.Update();
                        break;
                    case 405 :
                        detail.FormName = "Chart Of Accounts Report";
                        detail.DisplayName = "Rpt.COF";
                        //detail.Update();
                        break;
                     case 406 :
                        detail.FormName = "Receipt Voucher";
                        detail.DisplayName = "R.V";
                        //detail.Update();
                        break;
                    case 407 :
                        detail.FormName = "Double Entry Slot";
                        detail.DisplayName = "Slot";
                        //detail.Update();
                        break;
                    case 408 :
                        detail.FormName = "PendingSlotPosting";
                        detail.DisplayName = "Post";
                        //detail.Update();
                        break;
                    case 409 :
                        detail.FormName = "Journal Voucher";
                        detail.DisplayName = "J.V";
                        //detail.Update();
                        break;
                    case 410 :
                        detail.FormName = "paymet Voucher";
                        detail.DisplayName = "P.V";
                        //detail.Update();
                        break;
                    case 411 :
                        detail.FormName = "Account GL Master Note";
                        detail.DisplayName = "[ACC]";
                        //detail.Update();
                        break;
                    case 416:
                        detail.FormName = "Account Register Report";
                        detail.DisplayName = "Rpt.Reg";
                        //detail.Update();
                        break;  
          
                        
                }

                //set default img
                if (detail.Image == null)
                    detail.Image = img;
              
                //update record
                detail.Update();
            }
        }
        #endregion       
    }
}
