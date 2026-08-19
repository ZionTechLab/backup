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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Digiteq_Logic;
using SEACC_WPFControls;

namespace SEACC_FACTORING
{
    public partial class UC_AccSettings : UserControl
    {
        string sGLA_FactoringCharges = "", sGLA_FactoringCharges_Vat = "", sGLA_FactoringCharges_Nbt = "", sGLA_FactoringContralAcc = "", sGLA_ChequeInHand = "";

        #region Form Load
        public UC_AccSettings()
        {
            InitializeComponent();

            SEACC_Form.enmFormName = FormName.Fac_Settings;
            SEACC_Form.Initialize();

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, false, true, false);
            #endregion

            #region Configarations
            sGLA_FactoringCharges = clsSecurity.GetCofigValue(228);
            sGLA_FactoringCharges_Vat = clsSecurity.GetCofigValue(229);
            sGLA_FactoringCharges_Nbt = clsSecurity.GetCofigValue(230);
            sGLA_FactoringContralAcc = clsSecurity.GetCofigValue(231);
            sGLA_ChequeInHand = clsSecurity.GetCofigValue(232);
            #endregion

            #region Initialize Action Buttons
            SEACC_Form.SetVisibility_ActionButons(true, true, true, true);
            this.SEACC_Form.btn_New.Click += Btn_New_Click;
            this.SEACC_Form.btn_Save.Click += Btn_Save_Click;
            #endregion

            ClearFields();
        }
        #endregion

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //if (SEACC_Form.ActualWidth < 850)
            //    coloumnA.Width = new GridLength(410);
            //else
            //    coloumnA.Width = new GridLength(800);
        }

        #endregion


        #region Action Buttons
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            sGLA_FactoringCharges = txtFactCharges.Tag.ToString();
            sGLA_FactoringCharges_Vat = txtFactCharges_VAT.Tag.ToString();
            sGLA_FactoringCharges_Nbt = txtFactCharges_NBT.Tag.ToString();
            sGLA_FactoringContralAcc = txtCIH.Tag.ToString();
            sGLA_ChequeInHand = txtFactoringControl.Tag.ToString();

            clsSecurity.SetCofigValue(228, sGLA_FactoringCharges);
            clsSecurity.SetCofigValue(229, sGLA_FactoringCharges_Vat);
            clsSecurity.SetCofigValue(230, sGLA_FactoringCharges_Nbt);
            clsSecurity.SetCofigValue(231, sGLA_FactoringContralAcc);
            clsSecurity.SetCofigValue(232, sGLA_ChequeInHand);

            SEACCMessageBox.Show(MessegeBoxType.Successfully_Updated);
        }

        private void Btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        } 
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            SEACC_Form.IsUpdateMode = false;

            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtFactCharges, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtFactCharges_VAT, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtFactCharges_NBT, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtCIH, true, false);
            cls_Formater.SetEnableDisable_ForigenKeyTextBox(txtFactoringControl, true, false);

            txtFactCharges.Tag = sGLA_FactoringCharges;
            txtFactCharges_VAT.Tag = sGLA_FactoringCharges_Vat;
            txtFactCharges_NBT.Tag = sGLA_FactoringCharges_Nbt;
            txtCIH.Tag = sGLA_FactoringContralAcc;
            txtFactoringControl.Tag = sGLA_ChequeInHand;

            txtFactCharges.Text = clsGenaralName.getName_AccountName(sGLA_FactoringCharges);
            txtFactCharges_VAT.Text = clsGenaralName.getName_AccountName(sGLA_FactoringCharges_Vat);
            txtFactCharges_NBT.Text = clsGenaralName.getName_AccountName(sGLA_FactoringCharges_Nbt);
            txtCIH.Text = clsGenaralName.getName_AccountName(sGLA_FactoringContralAcc);
            txtFactoringControl.Text = clsGenaralName.getName_AccountName(sGLA_ChequeInHand);
        }
        #endregion

        #region Search Event
        private void txtFactCharges_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Account);
            if (RowDataSearch.DialogResult == true)
            {
                txtFactCharges.Tag = lstResult[0];
                txtFactCharges.Text = lstResult[1];
            }
        }

        private void txtFactCharges_VAT_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Account);
            if (RowDataSearch.DialogResult == true)
            {
                txtFactCharges_VAT.Tag = lstResult[0];
                txtFactCharges_VAT.Text = lstResult[1];
            }
        }

        private void txtFactCharges_NBT_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Account);
            if (RowDataSearch.DialogResult == true)
            {
                txtFactCharges_NBT.Tag = lstResult[0];
                txtFactCharges_NBT.Text = lstResult[1];
            }
        }

        private void txtCIH_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Account);
            if (RowDataSearch.DialogResult == true)
            {
                txtCIH.Tag = lstResult[0];
                txtCIH.Text = lstResult[1];
            }
        }

        private void txtFactoringControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Account);
            if (RowDataSearch.DialogResult == true)
            {
                txtFactoringControl.Tag = lstResult[0];
                txtFactoringControl.Text = lstResult[1];
            }
        } 
        #endregion
    }
}