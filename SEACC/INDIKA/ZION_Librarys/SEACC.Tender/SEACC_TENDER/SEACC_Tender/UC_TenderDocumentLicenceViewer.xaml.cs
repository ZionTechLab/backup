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
using SEACC_WPFControls;
using DataTire;
using SEACC_Tender.UserControls;
using System.Data;
using Digiteq_Logic;
using SEACC_Tender.Search_Forms;

namespace SEACC_Tender
{
    /// <summary>
    /// Interaction logic for UC_ItemRegistration.xaml
    /// </summary>
    public partial class UC_TenderDocumentLicenceViewer : UserControl
    {
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();

        public UC_TenderDocumentLicenceViewer()
        {
            InitializeComponent();

            #region Form Initialize
            SEACC_Form.enmFormName = Digiteq_Logic.FormName.TenderDocumentLicenceViewer;
            SEACC_Form.Initialize(); 
            #endregion

            #region Data Table Intialize
            dt.Columns.Add("LineNo");
            dt.Columns.Add("CertificateType");
            dt.Columns.Add("LicenceType");
            dt.Columns.Add("ReceiptNo");
            dt.Columns.Add("ReceiptDate");
            dt.Columns.Add("ReceiptAmount");
            dt.Columns.Add("ExpiryDate");
            dt.Columns.Add("FilePath");
            dt.Columns.Add("FileName");
            dt.Columns.Add("Upload");
            dgv_DocViewer.ItemsSource = dt.DefaultView;

            dt2.Columns.Add("TenderID");
            dt2.Columns.Add("TenderNo");
            dt2.Columns.Add("TenderDate");
            dgv_TenDetails.ItemsSource = dt2.DefaultView;
            #endregion


            SEACC_Form.SetVisibility_ActionButons(false, false, false, false);

            ClearFields();
        }

        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void ClearFields()
        {
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTenderID, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, true, false, false);


            txtTenderID.Text = "";
            txtCustomer.Text = "";

            txtCustomer.Tag = null;
            txtTenderID.Tag = null;

        }

        public void RefreshGrid(string sCusID)
        {
            dt2.Clear();
            foreach (tbl_ttsTenderNotice oNotice in tbl_ttsTenderNotice.SelectAllByCustomer_ID(sCusID))
            {
                dt2.Rows.Add(oNotice.Tender_ID, oNotice.BidReference_No1, oNotice.NoticeDate);
            }
            
        }
        private void txtCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.CustomerList);
            if (RowDataSearch.DialogResult == true)
            {
                txtCustomer.Tag = lstResult[0];
                txtCustomer.Text = lstResult[1];

                RefreshGrid(lstResult[0]);
            }
        }

        private void txtTenderID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Tender);
            if (RowDataSearch.DialogResult == true)
            {
                txtTenderID.Tag = lstResult[0];
                txtTenderID.Text = lstResult[1];
            }
        }

        private void DisplayDetails(string sId, string sTenId)
        {
            if (sId != null && sTenId != null)
            {
                //tbl_tenderNotice oNotice = tbl_tenderNotice.Select();
                //tbl_tenderItemMasterDocument oItemMasterDoc = tbl_tenderItemMasterDocument.SelectAllByItem_ID();

            }
        }
    }
}
