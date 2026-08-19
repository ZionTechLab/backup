using SEACC_PRODUCTION_APPAREL.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SEACC_PRODUCTION_APPAREL.Controls
{
    /// <summary>
    /// Developped by Gayan
    /// 2018-05-25
    /// </summary>
    public partial class frm_MaterialSelection_SubIn : Window
    {
        #region Class Variables
        public DataTable dtMeterial_Req = new DataTable();
        public DataTable dtWIP_SF_Req = new DataTable();
        #endregion

        #region Form Load
        public frm_MaterialSelection_SubIn()
        {
            InitializeComponent();

            #region Initialize Data Table - Mat
            dtMeterial_Req.Columns.Add("LineNo");

            DataColumn dcSelectColumn = new DataColumn("IsSelect", typeof(string));
            dcSelectColumn.DefaultValue = "\uE003";
            dtMeterial_Req.Columns.Add(dcSelectColumn);

            dtMeterial_Req.Columns.Add("Item_ID");
            dtMeterial_Req.Columns.Add("ItemName");

            dgr_MererialReq.ItemsSource = dtMeterial_Req.DefaultView;
            #endregion

            #region Initialize Data Table - SF
            dtWIP_SF_Req.Columns.Add("LineNo");

            DataColumn dcSelectCol = new DataColumn("IsSelect", typeof(string));
            dcSelectCol.DefaultValue = "\uE003";
            dtWIP_SF_Req.Columns.Add(dcSelectCol);

            dtWIP_SF_Req.Columns.Add("Item_ID");
            dtWIP_SF_Req.Columns.Add("ItemName");

            dgr_SFReq.ItemsSource = dtWIP_SF_Req.DefaultView;
            #endregion
        }
        #endregion

        #region Action Buttons
        private void btnCloseTop_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
        #endregion

        #region Show Method - Fill Data
        public int Show(string sSection_ID, ref DataTable dt_WIPSF)
        {
           

            DataTable dt = dtWIP_SF_Req.Copy();
            DataRow[] drPrvRecords = dt.Select("IsSelect = '\uE0A2'");

            dtWIP_SF_Req.Rows.Clear();
            var vSF = dt_WIPSF.Select("OutSection_ID <> 'default'"); //("OutSection_ID = '" + sSection_ID + "'");
            if (vSF.Any())
                dtWIP_SF_Req.Merge(vSF.AsEnumerable().CopyToDataTable());

            foreach (DataRow dr in drPrvRecords)
            {
                string sLineNo = dr.Field<string>("LineNo");
                string sItemID = dr.Field<string>("Item_ID");
                if (dtWIP_SF_Req.Rows.Count > 0)
                {
                    DataRow drAlreadyExistRecord = dtWIP_SF_Req.Select("Item_ID = '" + sItemID + "' AND LineNo = " + int.Parse(sLineNo)).FirstOrDefault();
                    if (drAlreadyExistRecord != null)
                        drAlreadyExistRecord["IsSelect"] = "\uE0A2";
                }
            }

            ShowDialog();

            //Reset  - Is Sub Out
            dt_WIPSF.Select().ToList<DataRow>().ForEach(r => {  r["isSubOut"] = false;  });

            foreach (DataRow dr in dtWIP_SF_Req.Select("IsSelect = '\uE0A2'"))
            {
                string sLineNo = dr.Field<string>("LineNo");
                string sItemID = dr.Field<string>("Item_ID");

                DataRow drWip_SF = dt_WIPSF.Select("Item_ID = '" + sItemID + "' AND LineNo = " + int.Parse(sLineNo)).FirstOrDefault();
                if (drWip_SF != null)
                    drWip_SF["isSubOut"] = true;

            }

            DataRow[] drWiP_SFs = dtWIP_SF_Req.Select("IsSelect = '\uE0A2'");
            int iWiP_SFs = 0;
            if (drWiP_SFs != null)
                iWiP_SFs = drWiP_SFs.Count();

            return (dtMeterial_Req.Rows.Count + iWiP_SFs);
        }
        #endregion

        #region Grid Events

        private void dgr_SFReq_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgr_SFReq.SelectedIndex;
            var vDG_Cell = dgr_SFReq.CurrentCell;
            try
            {
                if (vDG_Cell.Column.SortMemberPath == "IsSelect" || vDG_Cell.Column.SortMemberPath == "ItemName")
                {
                    bool bIsChecked = false;
                    bIsChecked = dtWIP_SF_Req.Rows[irowID]["IsSelect"].ToString() == "\uE0A2" ? true : false;
                    dtWIP_SF_Req.Rows[irowID]["IsSelect"] = bIsChecked ? "\uE003" : "\uE0A2";
                }
            }
            catch (Exception) { }
        }

        #endregion

        #region Other Events
        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        #endregion

        private void dgr_MererialReq_LoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtMeterial_Req);
        }

        private void dgr_SFReq_LoadingRow(object sender, System.Windows.Controls.DataGridRowEventArgs e)
        {
            clsHelpMethods_Prod.OrderBy_DataGrid(dtWIP_SF_Req);
        }
    }
}
