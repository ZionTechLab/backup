using System;
using System.Collections.Generic;
using System.Data;
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

namespace SEACC_PRODUCTION_PHARMA.Controls
{
    /// <summary>
    /// Developped by Gayan
    /// 2017-10-25
    /// </summary>
    public partial class frm_MaterialSelection : Window
    {
        #region Class Variables
        DataTable dtMeterial_Req = new DataTable();
        DataTable dtWIP_SF_Req = new DataTable(); 
        List<cls_BoMDetailMaterial> lstSelectedItems = new List<cls_BoMDetailMaterial>();
        bool bClearMatList = false;
        #endregion

        #region Form Load
        public frm_MaterialSelection()
        {
            InitializeComponent();

            #region Initialize Data Table - Mat
            dtMeterial_Req.Columns.Add("LineNo");

            DataColumn dcSelectColumn = new DataColumn("IsSelect", typeof(string));
            dcSelectColumn.DefaultValue = "\uE003";
            dtMeterial_Req.Columns.Add(dcSelectColumn);

            dtMeterial_Req.Columns.Add("Item_ID");
            dtMeterial_Req.Columns.Add("ItemName");
            #endregion

            #region Initialize Data Table - SF
            dtWIP_SF_Req.Columns.Add("LineNo");

            DataColumn dcSelectCol = new DataColumn("IsSelect", typeof(string));
            dcSelectCol.DefaultValue = "\uE003";
            dtWIP_SF_Req.Columns.Add(dcSelectCol);

            dtWIP_SF_Req.Columns.Add("Item_ID");
            dtWIP_SF_Req.Columns.Add("ItemName");
            #endregion
        }
        #endregion

        #region Action Buttons
        private void btnCloseTop_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            bClearMatList = true;
            Close();
        }
        #endregion

        #region Show Method - Fill Data
        public List<cls_BoMDetailMaterial> Show(DataTable dt_Material, DataTable dt_WIPSF, List<cls_BoMDetailMaterial> lstCurrentSelected)
        {
            lstSelectedItems.Clear();

            #region Exist Raw Mats
            dtMeterial_Req.Clear();
            dtMeterial_Req.Merge(dt_Material);
            dgr_MererialReq.ItemsSource = dtMeterial_Req.DefaultView;
            foreach (cls_BoMDetailMaterial oMat in lstCurrentSelected.Where(r => !r.BIsWIP_SF))
            {
                var vDr = dtMeterial_Req.Select("LineNo = '" + oMat.ILineNo + "' AND Item_ID = '" + oMat.SItem_ID + "' ").FirstOrDefault();
                if (vDr != null)
                    vDr["IsSelect"] = "\uE0A2";
            }
            #endregion

            #region Exist SFs
            dtWIP_SF_Req.Clear();
            dtWIP_SF_Req.Merge(dt_WIPSF);
            dgr_SFReq.ItemsSource = dtWIP_SF_Req.DefaultView;
            foreach (cls_BoMDetailMaterial oSF in lstCurrentSelected.Where(r => r.BIsWIP_SF))
            {
                var vDr = dtWIP_SF_Req.Select("LineNo = '" + oSF.ILineNo + "' AND Item_ID = '" + oSF.SItem_ID + "' ").FirstOrDefault();
                if (vDr != null)
                    vDr["IsSelect"] = "\uE0A2";
            } 
            #endregion

            ShowDialog();

            #region Selected Raw Mats
            var vSelectedItems = dtMeterial_Req.Select("IsSelect = '\uE0A2'");
            foreach (DataRow dr in vSelectedItems)
            {
                cls_BoMDetailMaterial oWIP_FlowMaterial = new cls_BoMDetailMaterial();
                oWIP_FlowMaterial.ILineNo = int.Parse(dr["LineNo"].ToString());
                oWIP_FlowMaterial.SItem_ID = dr["Item_ID"].ToString();
                lstSelectedItems.Add(oWIP_FlowMaterial);
            }
            #endregion

            #region Selected SFs
            var vSelectedSFs = dtWIP_SF_Req.Select("IsSelect = '\uE0A2'");
            foreach (DataRow dr in vSelectedSFs)
            {
                cls_BoMDetailMaterial oWIP_FlowMaterial = new cls_BoMDetailMaterial();
                oWIP_FlowMaterial.ILineNo = int.Parse(dr["LineNo"].ToString());
                oWIP_FlowMaterial.SItem_ID = dr["Item_ID"].ToString();
                oWIP_FlowMaterial.BIsWIP_SF = true;
                lstSelectedItems.Add(oWIP_FlowMaterial);
            }
            #endregion

            if (bClearMatList)
                lstSelectedItems.Clear();

            return lstSelectedItems;
        }
        #endregion

        #region Grid Events

        #region Raw Mat Grid
        private void dgr_MererialReq_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int irowID = dgr_MererialReq.SelectedIndex;
            var vDG_Cell = dgr_MererialReq.CurrentCell;
            try
            {
                if (vDG_Cell.Column.SortMemberPath == "IsSelect" || vDG_Cell.Column.SortMemberPath == "ItemName")
                {
                    bool bIsChecked = false;
                    bIsChecked = dtMeterial_Req.Rows[irowID]["IsSelect"].ToString() == "\uE0A2" ? true : false;
                    dtMeterial_Req.Rows[irowID]["IsSelect"] = bIsChecked ? "\uE003" : "\uE0A2";
                }

            }
            catch (Exception) { }
        }
        #endregion

        #region SF Grid
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

        #endregion

        #region Other Events
        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        } 
        #endregion
    }
}
