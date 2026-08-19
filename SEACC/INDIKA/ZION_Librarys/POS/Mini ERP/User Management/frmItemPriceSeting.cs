using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; using Digiteq_Logic;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.IO;

namespace Digiteq
{
    public partial class frmItemPriceSeting : Form
    {
        #region Variables    
           public int iFormID;
        public bool bNoAccess;
        public string glbItemID = "", glbItemSubCategoryID1 = "", glbItemSubCategoryID2 = "", glbItemSerialNo1 = "", glbItemSerialNo2 = "";
        public decimal glbdPrice = 0; 

        int iRow;
        #endregion

        #region Form Load
        public frmItemPriceSeting()
        {
            iFormID = clsSecurity.getFormID(FormName.ViewerRawMaterial);
            if (!clsSecurity.PermissionToRead(clsSecurity.UserIDLoged, iFormID))
            {
                bNoAccess = true;
            }
            InitializeComponent(); 
        }

        private void frm_bpsChequeViewer_Load(object sender, EventArgs e)
        {
            clsFormatter.setFormatForm(this, "", 2, iFormID);
            ClearFields();
            if (glbItemID.Length > 0 && glbItemSubCategoryID1.Length > 0 && glbItemSubCategoryID2.Length > 0 && glbItemSerialNo1.Length > 0 && glbItemSerialNo2.Length > 0)
            {
                FillDetails(glbItemID, glbItemSubCategoryID1, glbItemSubCategoryID2, glbItemSerialNo1, glbItemSerialNo2);
            }
        } 
        #endregion


        #region Btn Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            frm_scsStockAdjustment.glbnewPrice = decimal.Parse(txtNewPrice.Text.ToString());
            this.Close();
        }
        #endregion

        #region Btn Refresh
        private void Refresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            if (glbItemID.Length > 0 && glbItemSubCategoryID1.Length > 0 && glbItemSubCategoryID2.Length > 0 && glbItemSerialNo1.Length > 0 && glbItemSerialNo2.Length > 0)
            {
                FillDetails(glbItemID, glbItemSubCategoryID1, glbItemSubCategoryID2, glbItemSerialNo1, glbItemSerialNo2);

            }
        }
        #endregion


        #region Clear Fields
        private void ClearFields()
        {
            lblMaterialCategory.Text = "";
            lblMaterialClass.Text = "";
            lblMaterialID.Text = "";
            lblMaterialName.Text = "";
            lblMaterialType.Text = "";
            lblMaterialType.Text = "";           
            lblSubCategory.Text = "";
            txtSerialNo1.Text = "";
            txtSerialNo2.Text = "";
            txtSubCategory1.Text = "";
            txtSubCategory2.Text = "";           
        }
        #endregion

        #region  Fill Details
        private void FillDetails(string sItemCode, string sSubCategoryID1, string sSubCategoryID2, string sSerial1, string sSerial2)
        {
            tbl_genItemMaster Details = tbl_genItemMaster.Select(sItemCode);
            if (Details != null)
            {
                if (sSerial1 == "0")
                    sSerial1 = "N/A";
                if (sSerial2 == "0")
                    sSerial2 = "N/A";
                if (sSubCategoryID1 == "default")
                    sSubCategoryID1 = "N/A";
                else
                    sSubCategoryID1 = clsGenaralName.getName_ItemSubCategory(sSubCategoryID1);
                if (sSubCategoryID2 == "default")
                    sSubCategoryID2 = "N/A";
                else
                    sSubCategoryID2 = clsGenaralName.getName_ItemSubCategory(sSubCategoryID2);

                lblMaterialCategory.Text = clsGenaralName.getName_ItemCategory(Details.ItemCategory_ID);
                lblMaterialClass.Text = clsGenaralName.getName_ItemClass(Details.ItemClass_ID);
                lblMaterialID.Text = Details.Item_ID;
                lblMaterialName.Text = clsGenaralName.getName_Item(Details.Item_ID);
                lblMaterialType.Text = clsGenaralName.getName_ItemType(Details.ItemType_ID);               
                lblSubCategory.Text = Details.ItemCategorySub_ID;
                
                txtSerialNo1.Text =  clsCommon.GetForeignKeyValue(sSerial1);
                txtSerialNo2.Text = clsCommon.GetForeignKeyValue(sSerial2);
                txtSubCategory1.Text = sSubCategoryID1;
                txtSubCategory2.Text = sSubCategoryID2;
            }
            tbl_genItemMaster_Pricing Itemdetail = tbl_genItemMaster_Pricing.Select(glbItemID);
            if (Itemdetail != null)
            {
                lblFIFO.Text =  clsFormatter.FormatToCurrecyWithThousendSep( Itemdetail.FifoCostPrice);
                lblHighestPurchase.Text =  clsFormatter.FormatToCurrecyWithThousendSep(Itemdetail.HighestPurchaseCostPrice);
                lblLIFOCostPrice.Text =  clsFormatter.FormatToCurrecyWithThousendSep( Itemdetail.LifoCostPrice);
                lblLovesetPurchase.Text =  clsFormatter.FormatToCurrecyWithThousendSep(Itemdetail.LowestPurchaseCostPrice);
                lblWeightedAverage.Text =  clsFormatter.FormatToCurrecyWithThousendSep(Itemdetail.WeightedAverageCostPrice);
                txtNewPrice.Text =  clsFormatter.FormatToCurrecyWithThousendSep(Itemdetail.LifoCostPrice);
            }
            else
            {
                lblFIFO.Text = clsFormatter.FormatToCurrecyWithThousendSep(0);
                lblHighestPurchase.Text = clsFormatter.FormatToCurrecyWithThousendSep(0);
                lblLIFOCostPrice.Text = clsFormatter.FormatToCurrecyWithThousendSep(0);
                lblLovesetPurchase.Text = clsFormatter.FormatToCurrecyWithThousendSep(0);
                lblWeightedAverage.Text = clsFormatter.FormatToCurrecyWithThousendSep(0);
                txtNewPrice.Text = clsFormatter.FormatToCurrecyWithThousendSep(0);
            }
        }
        #endregion

        private void x2_Paint(object sender, PaintEventArgs e)
        {

        }

        #region btn Set Price
        private void btnSetPrice_Click(object sender, EventArgs e)
        {
            frm_scsStockAdjustment.glbnewPrice = decimal.Parse(txtNewPrice.Text.ToString());
            this.Close();
        } 
        #endregion


    }
}
