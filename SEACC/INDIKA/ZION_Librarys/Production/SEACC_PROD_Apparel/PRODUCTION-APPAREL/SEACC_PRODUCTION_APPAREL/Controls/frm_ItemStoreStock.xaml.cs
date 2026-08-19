using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System.Data;
using System.Linq;
using System.Windows;

namespace SEACC_PRODUCTION_APPAREL.Controls
{
    /// <summary>
    /// Interaction logic for frm_ItemStoreStock.xaml
    /// </summary>
    public partial class frm_ItemStoreStock : Window
    {
        private DataTable dtItemStoreStock = new DataTable();

        public frm_ItemStoreStock(string sItem_ID)
        {
            InitializeComponent();

            dtItemStoreStock.Columns.Add("LineNo");
            dtItemStoreStock.Columns.Add("StoreName");
            dtItemStoreStock.Columns.Add("UoM");
            dtItemStoreStock.Columns.Add("Qty");

            dgr_ItemStoreStock.ItemsSource = dtItemStoreStock.DefaultView;

            RefreshGrid(sItem_ID);
        }

        private void RefreshGrid(string sItem_ID)
        {
            int iLineNo = 0;
            dtItemStoreStock.Rows.Clear();

            foreach (tbl_genStore_Stock oStoreStock in tbl_genStore_Stock.SelectAllByItem_ID(sItem_ID))
            {
                tbl_genStoreMaster oStore = tbl_genStoreMaster.Select(oStoreStock.Store_ID);

                if (oStore.IsDeleted || oStore.IsDamagedStore)
                    continue;

                if (oStore.IsDepartment)
                    continue;

                tbl_genSectionMaster oSectionMater = tbl_genSectionMaster.SelectAllByStore_ID(oStore.Store_ID).FirstOrDefault();
                if (oSectionMater != null)
                    continue;

                dtItemStoreStock.Rows.Add(++iLineNo, clsGenaralName.getName_Store(oStore.Store_ID), clsGenaralName.getName_ItemUOMName(oStoreStock.Item_ID), cls_Formater.FormatDecimal(oStoreStock.Qty, clsConfig.sDecimalPlaces_Quantity));
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
