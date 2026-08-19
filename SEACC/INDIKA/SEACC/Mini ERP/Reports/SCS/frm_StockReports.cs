using Digiteq_Logic;
using Newtonsoft.Json;
using SEACC.DATA.Data.SCS;
using SEACC.DATA.Domain.SCS;
using SEACC.WinFormControls.Domain;
using SEACC.WinFormControls.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEACC.DATA.Domain;
using SelectionList2 = SEACC.DATA.Domain.SelectionList;
using SelectionList = SEACC.WinFormControls.Domain.SelectionList;

namespace Digiteq.Reports.SCS
{
    public partial class frm_StockReports : MettroForm
    {
        public int iFormID;
        public bool bNoAccess;

        StockReportsData oData = new StockReportsData();
        StockReportUiDomain UIdata;
        List<StockReport> GridList= new List<StockReport>();
        public frm_StockReports()
        {
            iFormID = clsSecurity.getFormID(FormName.StockReports);
       
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
                bNoAccess = true;

            InitializeComponent();
            try
            {
                LoadUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadUI()
        {
            try
            {
                UIdata = oData.GetUI();

                //---------------------------------------------------
                cmbStore.DisplayMember = "storeName";
                cmbStore.ValueMember = "store_ID";

                cmbItemClass.DisplayMember = "className";
                cmbItemClass.ValueMember = "itemClass_ID";

                cmbItemType.DisplayMember = "typeName";
                cmbItemType.ValueMember = "itemType_ID";

                cmbItemCat.DisplayMember = "categoryName";
                cmbItemCat.ValueMember = "itemCategory_ID";

                dtpFrom.Value = DateTime.Now;
                dtpTo.Value = DateTime.Now;

                chkHideZeroQty.Checked = true;
                chkShowDeactivate.Checked = true;

                cmbStore.Checked = true;
                cmbItemClass.Checked = true;
                cmbItemType.Checked = true;
                cmbItemCat.Checked = true;

                cmbStore.DataSource = UIdata.Store;
                cmbItemClass.DataSource = UIdata.ItemClass;
                cmbItemType.DataSource = UIdata.ItemType;
                cmbItemCat.DataSource = UIdata.ItemCategory;

                Selected_Store.Clear();
                Selected_Class.Clear();
                Selected_Type.Clear();
                Selected_Catagory.Clear();

                txtItem.Clear();

                GridList.Clear();

                GridList.Clear();
                gridMain.DataSource = GridList;
                panel2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LoadUI();
        }

        private void btnRetrive_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cmbStore.ValidateValue())
                    return;
                if (!cmbItemClass.ValidateValue())
                    return;
                if (!cmbItemType.ValidateValue())
                    return;
                if (!cmbItemCat.ValidateValue())
                    return;

             var SL = new List<SelectionList2>();

                Selected_Store.ForEach(c =>
                {
                    SL.Add(new SelectionList2 { Type = "Store", ValueMember = c.ValueMember });
                });
                Selected_Class.ForEach(c =>
                {
                    SL.Add(new SelectionList2 { Type = "Class", ValueMember = c.ValueMember });
                });
                Selected_Type.ForEach(c =>
                {
                    SL.Add(new SelectionList2 { Type = "Type", ValueMember = c.ValueMember });
                });
                Selected_Catagory.ForEach(c =>
                {
                    SL.Add(new SelectionList2 { Type = "Catagory", ValueMember = c.ValueMember });
                });

                int ReportID = 0;
                if (rdoStoreWise.Checked)
                    ReportID = 1;
                else if(rdoItemWise.Checked)
                    ReportID = 2;

                #region MyRegion
                var C1 = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Item_ID",
                    Name = "Item_ID",
                    DataPropertyName = "Item_ID",
                    Width = 80,
                };
                var C2 = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Item_Name",
                    Name = "Item_Name",
                    DataPropertyName = "Item_Name",
                    Width = 80,
                };
                var C3 = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Store_ID",
                    Name = "Store_ID",
                    DataPropertyName = "Store_ID",
                    Width = 80,
                    Visible = rdoStoreWise.Checked,
                };
                var C4 = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Store_Name",
                    Name = "Store_Name",
                    DataPropertyName = "Store_Name",
                    Width = 80,
                    Visible = rdoStoreWise.Checked,
                };
                var C5 = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Item_Class_ID",
                    Name = "Item_Class_ID",
                    DataPropertyName = "Item_Class_ID",
                    Width = 80,
                };
                var C6 = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Item_Class_Name",
                    Name = "Item_Class_Name",
                    DataPropertyName = "Item_Class_Name",
                    Width = 80,
                };
                var C7 = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Item_Type_ID",
                    Name = "Item_Type_ID",
                    DataPropertyName = "Item_Type_ID",
                    Width = 80,
                };
                var C8 = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Item_Type_Name",
                    Name = "Item_Type_Name",
                    DataPropertyName = "Item_Type_Name",
                    Width = 80,
                };
                var C9 = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Item_Category_ID",
                    Name = "Item_Category_ID",
                    DataPropertyName = "Item_Category_ID",
                    Width = 80,
                };
                var C10 = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Item_Category_Name",
                    Name = "Item_Category_Name",
                    DataPropertyName = "Item_Category_Name",
                    Width = 80,
                };
                var C11 = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Uom_ID",
                    Name = "Uom_ID",
                    DataPropertyName = "Uom_ID",
                    Width = 80,
                };
                var C12 = new DataGridViewTextBoxColumn
                {
                    HeaderText = "Uom_Name",
                    Name = "Uom_Name",
                    DataPropertyName = "Uom_Name",
                    Width = 80,
                };
                var C13 = new DataGridViewTextBoxColumn
                {
                    HeaderText = "QTY",
                    Name = "QTY",
                    DataPropertyName = "QTY",
                    Width = 80,
                };
                gridMain.Columns.Clear();
                gridMain.DataSource = null;
                gridMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {  C1, C2,
                C3, C4, C5, C6, C7, C8,  C9, C10, C11,C12,C13}); 
                #endregion


                GridList = oData.getReport(ReportID, SL, txtItem.Text,chkHideZeroQty.Checked,chkShowLessThan.Checked,txtQty.getValue(0));
              //  SetDataSet();
                panel2.Enabled = false;

                var json = JsonConvert.SerializeObject(GridList);
                DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

                gridMain.DataSource = dt;




            }
            catch (Exception ex)
            {
              //  SEACCException.Show(ex);
            }
        }

     

        private void SetDataSet()
        {
            var tempList= new List<StockReport>();
            tempList.AddRange(GridList);

            if (Selected_Store.Count > 0)
                 tempList = tempList.Where(p => (Selected_Store.Any(x => p.Store_ID == x.ValueMember))).ToList();

            if (Selected_Class.Count > 0)
                tempList = tempList.Where(p => (Selected_Class.Any(x => p.Item_Class_ID == x.ValueMember))).ToList();

            if (Selected_Type.Count > 0)
                tempList = tempList.Where(p => (Selected_Type.Any(x => p.Item_Type_ID == x.ValueMember))).ToList();

            if (Selected_Catagory.Count > 0)
                tempList = tempList.Where(p => (Selected_Catagory.Any(x => p.Item_Category_ID == x.ValueMember))).ToList();

            if(txtItem.Text!="")
                tempList = tempList.Where(p =>p.Item_Name.ToUpper().Contains(txtItem.Text.ToUpper())).ToList();

            var json = JsonConvert.SerializeObject(tempList);
            DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

            gridMain.DataSource = dt;
        }


        List<SEACC.WinFormControls.Domain.SelectionList> Selected_Store = new List<SelectionList>();
        List<SelectionList> Selected_Class= new List<SelectionList>();
        List<SelectionList> Selected_Type = new List<SelectionList>();
        List<SelectionList> Selected_Catagory = new List<SelectionList>();
        private void cmbStore_SelectionChanged(DataView value, List<SelectionList> Data)
        {
            Selected_Store = Data;
          //  SetDataSet();
        }

        private void cmbItemClass_SelectionChanged(DataView value, List<SelectionList> Data)
        {
            Selected_Class = Data;// SetDataSet();
        }

        private void cmbItemType_SelectionChanged(DataView value, List<SelectionList> Data)
        {
            Selected_Type = Data; //SetDataSet();
        }

        private void cmbItemCat_SelectionChanged(DataView value, List<SelectionList> Data)
        {
            Selected_Catagory = Data; //SetDataSet();
        }

        private void btnrint_Click(object sender, EventArgs e)
        {
            xSearchQuary Filter = new xSearchQuary();
            Filter.Append(cmbStore.SelctionQuary());
            Filter.Append(cmbItemClass.SelctionQuary());
            Filter.Append(cmbItemType.SelctionQuary());
            Filter.Append(cmbItemCat.SelctionQuary());
            if(txtItem.Text!="")
            Filter.Append("Item Name : "+txtItem.Text);
            gridMain.PrintReport(Filter.GetQuary());
        }

        private void txtItem_KeyUp(object sender, KeyEventArgs e)
        {
          //  SetDataSet();
        }

        private void chkShowLessThan_CheckedChanged(object sender, EventArgs e)
        {
            txtQty.Enabled = chkShowLessThan.Checked;
            txtQty.SetValue("");
        }
    }
}

