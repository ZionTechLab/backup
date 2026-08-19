using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Digiteq_Logic;
using SEACC_WPFControls;
using System.Data;
using DataTire;

namespace SEACC_FACTORING
{
    /// <summary>
    /// Interaction logic for frm_ScheduleCheques_Viewer.xaml
    /// </summary>
    public partial class frm_ScheduleCheques_Viewer : Window
    {

        #region Class Variables
        public string glbAgreementID;
        public string glbAgreementRevesion;
        public decimal glbCreditLimit;

        DataTable dt = new DataTable(); 
        #endregion

        #region Form Load
        public frm_ScheduleCheques_Viewer()
        {
            InitializeComponent();

            #region Data Table Initialize
            dt.Columns.Add("ScheduleID");
            dt.Columns.Add("ScheduleDate");
            dt.Columns.Add("Cheque_NO");
            dt.Columns.Add("Cheque_Date");
            //dt.Columns.Add("Bank_ID");
            dt.Columns.Add("Bank");
            //dt.Columns.Add("Branch_ID");
            dt.Columns.Add("Branch");
            dt.Columns.Add("ChequeAmount");
            dt.Columns.Add("FactoringRate");
            dt.Columns.Add("FactoringAmount");
            dgvDetails.ItemsSource = dt.DefaultView;
            #endregion

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayAgreementDetails();
            RefreshGrid();
        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        #endregion

        #region Refresh Grid
        private void RefreshGrid()
        {
            try
            {
                dt.Clear();
                decimal dFactoringAmount = 0, dAvailableCreditAmount = 0;
                tbl_bpsFactoringAgreement oFactoring = tbl_bpsFactoringAgreement.Select(glbAgreementID, glbAgreementRevesion);
                if (oFactoring != null)
                {
                    foreach (tbl_bpsFactoringSchedule oFSche in tbl_bpsFactoringSchedule.SelectAllByFactoringAgreement_ID_FactoringAgreement_Revision(oFactoring.FactoringAgreement_ID, oFactoring.FactoringAgreement_Revision).Where(p => p.IsDeleted == false && p.FactoringSehedule_ID != "Default"))
                    {
                        foreach (tbl_bpsFactoringSchedule_detail oDetails in tbl_bpsFactoringSchedule_detail.SelectAllByFactoringSehedule_ID(oFSche.FactoringSehedule_ID))
                        {
                            tbl_bpsChequeRegister oCheque = tbl_bpsChequeRegister.Select(oDetails.ChequeRegister_ID);
                            if (oCheque != null)
                            {
                                if (oCheque.DateCheque >= DateTime.Now.Date)
                                {
                                    dt.Rows.Add(oFSche.FactoringSehedule_ID, clsFormatter.FormatDate_SL(oFSche.FactoringSeheduleDate), clsGenaralName.getName_ChequeNo(oDetails.ChequeRegister_ID), clsFormatter.FormatDate_SL(oCheque.DateCheque), clsRef_Name.get_Bank_Name(oFactoring.Bank_ID), clsRef_Name.get_BankBranch_Name(oFactoring.Branch_ID), clsFormatter.FormatDecimalPlaces_Price(oDetails.ChequeAmount), clsFormatter.FormatDecimalPlaces_Price(oDetails.FactoringRate), clsFormatter.FormatDecimalPlaces_Price(oDetails.FactoringAmount));
                                    dFactoringAmount += oDetails.FactoringAmount;
                                }
                            }
                        }
                    }

                    dAvailableCreditAmount = glbCreditLimit - dFactoringAmount;
                    lblAvailableCredit.Text = clsFormatter.FormatDecimalPlaces_Price(dAvailableCreditAmount);
                }
            }
            catch (Exception ex)
            {
                SEACCExeption.Show(ex);
            }
        } 
        #endregion

        #region Display Agreement Details
        private void DisplayAgreementDetails()
        {
            tbl_bpsFactoringAgreement oAgreement = tbl_bpsFactoringAgreement.Select(glbAgreementID, glbAgreementRevesion);
            tbl_bpsFactoringInterest oInterest = tbl_bpsFactoringInterest.Select(oAgreement.FactoringInterest_ID);
            if (oAgreement != null && oInterest != null)
            {
                lblAgreementCode.Text = oAgreement.FactoringAgreement_ID + "/" + oAgreement.FactoringAgreement_Revision;
                lblAgreementCode.Tag = oAgreement.FactoringAgreement_ID;

                lblCreditLimit.Text = clsFormatter.FormatDecimalPlaces_Price(oAgreement.Credit_Limit);
                glbCreditLimit = oAgreement.Credit_Limit;

                lblbank.Text = clsRef_Name.get_Bank_Name(oAgreement.Bank_ID);
                lblbranch.Text = clsRef_Name.get_BankBranch_Name(oAgreement.Branch_ID);
                lblbank.Tag = oAgreement.Bank_ID;
                lblbranch.Tag = oAgreement.Branch_ID;

                lblFactoringAccNo.Text = oAgreement.AccountNumber_Factoring;
                lblInerestRate.Text = clsFormatter.FormatDecimalPlaces_Price(oInterest.Interest_Credit);
            }
        } 
        #endregion

        #region Button Close
        private void btn_Close2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        } 
        #endregion

    }
}
