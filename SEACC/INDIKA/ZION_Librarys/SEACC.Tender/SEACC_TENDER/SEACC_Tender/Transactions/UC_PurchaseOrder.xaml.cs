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
    /// Interaction logic for UC_PurchaseOrder.xaml
    /// </summary>
    public partial class UC_PurchaseOrder : UserControl
    {
        #region Class Variables
        DataTable dt = new DataTable();
        bool bIsItemChanged = false;
        public int iFormID;
        #endregion

        public UC_PurchaseOrder()
        {
            InitializeComponent();

            #region Form Initialize
            SEACC_Form.enmFormName = FormName.PurchaseOrder;
            iFormID = clsSecurity.getFormID(FormName.PurchaseOrder);
            SEACC_Form.Initialize(); 
            #endregion

            #region Data Table Initialize
            dt.Columns.Add("LineNo");
            dt.Columns.Add("OrderListNo");
            dt.Columns.Add("ModeofDispatch");
            dt.Columns.Add("DeliverySchedule");
            dt.Columns.Add("PackSize");
            dt.Columns.Add("OrderQty");
            dt.Columns.Add("UnitPrice");
            dt.Columns.Add("Total");
            dgr_Tender.ItemsSource = dt.DefaultView; 
            #endregion

            #region Action Button Initialize
            SEACC_Form.SetVisibility_ActionButons(true, true,true, true);
            this.SEACC_Form.btn_New.Click += btn_New_Click;
            this.SEACC_Form.btn_Cancel.Click += btn_Cancel_Click;
            this.SEACC_Form.btn_Print.Click += Btn_Print_Click;
            this.SEACC_Form.btn_Save.Click += Btn_Save_Click; 
            #endregion

            ClearFields();
            RefreshGrid();
        }

        #region Form Responsive
        private void SEACC_Form_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (SEACC_Form.ActualWidth < 880)
                ColumnA.Width = new GridLength(200);
            else
                ColumnA.Width = new GridLength(310);
        }
        #endregion

        #region Action Buttons
        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            //Attachments.Insert(txtDocRenewalID.Text);
        }

        private void Btn_Print_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btn_New_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        } 
        #endregion

        #region Clear Fields
        private void ClearFields()
        {
            dt.Clear();

            Attachments.Clear(SEACC_Form.Function_ID);

            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtCustomer, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtLetterRef, true, false, false);
            cls_Formater.SetEnableDisable_ForigenKeyLabelTextBox(txtTenderID, true, false, false);
            cls_Formater.SetEnableDisable_LableTimePicker(dtpPODate, true, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPONo, true, false, false);
            cls_Formater.SetEnableDisable_LableTextbox(txtPaymentTerms, true, false, true);
            cls_Formater.SetEnableDisable_LableTextbox(txtIndentConditions, true, false, true);

            txtCustomer.Text = "";
            txtIndentConditions.Text = "";
            txtLetterRef.Text = "";
            txtPaymentTerms.Text = "";
            txtPONo.Text = "";
            txtTenderID.Text = "";

            txtTenderID.Tag = null;
            txtCustomer.Tag = null;
        } 
        #endregion

        private void RefreshGrid()
        {
            
        }

        private void FillDetails()
        {
            //Attachments.FillDetails(oDetails.Doc_Renewal_ID);
        }

        #region Search
        private void txtTenderID_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Search_Forms.frmSearch RowDataSearch = new Search_Forms.frmSearch();
            List<string> lstResult = RowDataSearch.Show(Search.Tender);
            if (RowDataSearch.DialogResult == true)
            {
                txtTenderID.Tag = lstResult[0];
                txtTenderID.Text = lstResult[1];
                txtCustomer.Tag = lstResult[4];
                txtCustomer.Text = lstResult[5];
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
            }
        } 
        #endregion

        private void btnGridItemAdd_Click(object sender, RoutedEventArgs e)
        {
            int iRow = dt.Rows.Count + 1;
            dt.Rows.Add(iRow, 0, "", "", "", 0, 0, 0);
        }

        private void btnGridItemDelete_Click(object sender, RoutedEventArgs e)
        {
            object selectedItem = dgr_Tender.SelectedItem;
            if (selectedItem != null)
                ((DataRowView)(dgr_Tender.SelectedItem)).Row.Delete();
        }
    }
}
