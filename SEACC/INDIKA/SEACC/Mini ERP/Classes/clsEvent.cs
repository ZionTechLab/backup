using System;
using Digiteq_Logic;
using SEACC.WinFormControls.Forms;
using System.Windows.Forms;
using DataTire;
using System.Data;

namespace Digiteq
{
    public class clsEvent

    {
        public static void SalesGrid_CellEndEdit_crn(object sender, DataGridViewCellEventArgs e, DataGridView dgvDetail, bool bWeightCalculation)
        {
            try
            {
                string sColName = "";
                decimal dWeightPrice = 0, dUnitPrice = 0, dQuantity = 0, dWeight = 0, dDiscountPresentage = 0, dDiscountedPrice = 0, dAmount = 0;
                bool bIsFreeItem = false;
                decimal UnitOrWaitedPrice = 0, dQtyOrWeight = 0;

                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                bIsFreeItem = (clsValidate.ValidateGridValue(dgvDetail, "Free", e.RowIndex, "") == "True") ? true : false;
                dDiscountPresentage = clsFormatter.RoundDecimalPlaces(clsValidate.ValidateGridValue(dgvDetail, "DiscuntPresentage", e.RowIndex, decimal.Parse("0.00")));
                dDiscountedPrice = clsFormatter.RoundDecimalPlaces(clsValidate.ValidateGridValue(dgvDetail, "DiscountValue", e.RowIndex, decimal.Parse("0.00")));

                if (!bWeightCalculation)
                {
                    dQtyOrWeight = dQuantity = clsFormatter.RoundDecimalPlaces_Quantity(clsValidate.ValidateGridValue(dgvDetail, "Quantity", e.RowIndex, decimal.Parse("0.00")));
                    UnitOrWaitedPrice = dUnitPrice = clsFormatter.RoundDecimalPlaces_UnitPrice(clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", e.RowIndex, decimal.Parse("0.00")));
                }
                else if (bWeightCalculation)
                {
                    dQtyOrWeight = dWeight = clsFormatter.RoundDecimalPlaces_Weight(clsValidate.ValidateGridValue(dgvDetail, "Weight", e.RowIndex, decimal.Parse("0.00")));
                    UnitOrWaitedPrice = dWeightPrice = clsFormatter.RoundDecimalPlaces_WeightPrice(clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", e.RowIndex, decimal.Parse("0.00")));
                }

                #region Discounts
                if (sColName == "DiscountValue")
                    dDiscountPresentage = clsFormatter.RoundDecimalPlaces(dDiscountedPrice * 100 / UnitOrWaitedPrice);
                else if (sColName == "DiscuntPresentage")
                    dDiscountedPrice = clsFormatter.RoundDecimalPlaces(UnitOrWaitedPrice * dDiscountPresentage / 100);
                else
                    dDiscountedPrice = clsFormatter.RoundDecimalPlaces(UnitOrWaitedPrice * dDiscountPresentage / 100);
                #endregion

                #region Free Item
                if (bIsFreeItem)
                {
                    dDiscountPresentage = 100;
                    dDiscountedPrice = dUnitPrice;

                    dgvDetail["DiscuntPresentage", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                    dgvDetail["DiscountValue", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                }
                else
                {
                    //   dgvDetail["DiscuntPresentage", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountPresentage);
                    //   dgvDetail["DiscountValue", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountedPrice);
                }
                #endregion

                dAmount = clsFormatter.RoundDecimalPlaces((UnitOrWaitedPrice - dDiscountedPrice) * dQtyOrWeight);

                dgvDetail["Quantity", e.RowIndex].Tag = dQuantity;
                dgvDetail["Quantity", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_Quantity(dQuantity);
                dgvDetail["UnitPrice", e.RowIndex].Tag = dUnitPrice;
                dgvDetail["UnitPrice", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(dUnitPrice);
                dgvDetail["Weight", e.RowIndex].Tag = dWeight;
                dgvDetail["Weight", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(dWeight);
                dgvDetail["WeightPrice", e.RowIndex].Tag = dWeightPrice;
                dgvDetail["WeightPrice", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(dWeightPrice);


                //   dgvDetail["DiscuntPresentage", e.RowIndex].Tag = dDiscountPresentage;
                //   dgvDetail["DiscountValue", e.RowIndex].Tag = dDiscountedPrice;

                dgvDetail["Amount", e.RowIndex].Tag = dAmount;
                dgvDetail["Amount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Sales Grid CellDoubleClick
        public static void SalesGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e, DataGridView dgvDetail)
        {
            string sColName = "";
            if (e.ColumnIndex >= 0)
                sColName = dgvDetail.Columns[e.ColumnIndex].Name;

            //if (sColName == "ItemCode" || sColName == "ItemName")
            //{
            //    int iRow = e.RowIndex;
            //    Form frmhelpsearch = new frmSearchMaster();
            //    clsSearch.passValue_ItemMaster();
            //    frmhelpsearch.ShowDialog();

            //    if (frmSearchMaster.s_SearchID.Length > 0)
            //    {
            //        dgvDetail["ItemCode", e.RowIndex].Value = frmSearchMaster.s_SearchID;
            //        dgvDetail["ItemName", e.RowIndex].Value = clsGenaralName.getName_Item(frmSearchMaster.s_SearchID);
            //        dgvDetail["UOM", e.RowIndex].Value = clsGenaralName.getName_ItemUOM(frmSearchMaster.s_SearchID);
            //        dgvDetail["UOM", e.RowIndex].Tag = clsGenaralName.getName_ItemUOMID(frmSearchMaster.s_SearchID);
            //        dgvDetail["JobCode", e.RowIndex].Value = "default";//add by thilina
            //        dgvDetail["Quantity", e.RowIndex].Value = "1";
            //        dgvDetail["Width", e.RowIndex].Value = "1.00";
            //        dgvDetail["Height", e.RowIndex].Value = "1.00";
            //        dgvDetail["Gauge", e.RowIndex].Value = "1.00";
            //        dgvDetail["Gusset", e.RowIndex].Value = "1.00";//add by thilina

            //        dgvDetail["KiloPrice", e.RowIndex].Value = "0.000";
            //        dgvDetail["Weight", e.RowIndex].Value = "0.0000";

            //        decimal dWidth = 0, dHeight = 0, dGauge = 0, dGusset = 0, dKiloPrice = 0, dUnitPrice = 0, dQuantity = 0, dWeight = 0;
            //        string sUomID = "default";

            //            dWidth = clsValidate.ValidateGridValue(dgvDetail, "Width", iRow, decimal.Parse("0.00"));
            //            dHeight = clsValidate.ValidateGridValue(dgvDetail, "Height", iRow, decimal.Parse("0.00"));
            //            dGauge = clsValidate.ValidateGridValue(dgvDetail, "Gauge", iRow, decimal.Parse("0.00"));
            //            dGusset = clsValidate.ValidateGridValue(dgvDetail, "Gusset", iRow, decimal.Parse("0.00"));
            //            dKiloPrice = clsValidate.ValidateGridValue(dgvDetail, "KiloPrice", iRow, decimal.Parse("0.00"));
            //            sUomID = clsValidate.ValidateGridTag(dgvDetail, "UOM", iRow, "");

            //            dUnitPrice = clsHelpMethods.GetUnitPrice(dWidth, dHeight, dGauge, dGusset, dKiloPrice, sUomID);
            //        dgvDetail["UnitPrice", e.RowIndex].Value = clsCommon.FormatToCurrecyWithFourDecimalPlaces(dUnitPrice);

            //        dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", iRow, decimal.Parse("0.00"));
            //        dWeight = clsHelpMethods.GetWeight(dWidth, dHeight, dGauge, dGusset, dQuantity, sUomID);
            //        dgvDetail["Weight", e.RowIndex].Value = clsFormatter.FormatToNumberWithFourDecimalPlaces(dWeight);
            //        dgvDetail["Amount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(GetTotalPrice(dUnitPrice, dQuantity));

            //        if (!clsCommon.IsLastRawEmpty(dgvDetail, dgvDetail.Rows.GetLastRow(DataGridViewElementStates.Displayed)))
            //            dgvDetail.Rows.Add();
            //    }
            //}

            if (sColName == "UOM")
            {
                string sItemCode = "";
                try
                {
                    sItemCode = dgvDetail["ItemCode", e.RowIndex].Value.ToString();
                }
                catch (Exception) { }
                if (sItemCode.Length <= 0)
                    MessageBox.Show("Please Select the Item Code or Name First", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    Form frmhelpsearch = new frmSearchMaster();
                    clsSearch.passValue_UomForSales();
                    frmhelpsearch.ShowDialog();

                    if (frmSearchMaster.s_SearchID.Length > 0)
                    {
                        dgvDetail["UOM", e.RowIndex].Tag = frmSearchMaster.s_SearchID;
                        dgvDetail["UOM", e.RowIndex].Value = clsGenaralName.getName_Uom(frmSearchMaster.s_SearchID);
                    }
                }
            }

            //if (sColName == "Width" || sColName == "Height" || sColName == "Gauge" || sColName == "Gusset" || sColName == "Quantity" || sColName == "KiloPrice" || sColName == "UnitPrice" || sColName == "Weight")
            //{
            //    if (dgvDetail["ItemCode", e.RowIndex].Value == null || dgvDetail["ItemCode", e.RowIndex].Value.ToString().Length <= 0)
            //        MessageBox.Show("Please Select the Item Code or Name First", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }
        private static decimal GetTotalPrice(decimal dPrice, decimal dQuantity)
        {
            decimal dTotalPrice = 0;
            dTotalPrice = dPrice * dQuantity;
            return dTotalPrice;
        }
        #endregion

        #region Stock Grid CellDoubleClick

        public static void StockGrid_GTN_CellDoubleClick(object sender, DataGridViewCellEventArgs e, DataGridView dgvDetail)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (sColName == "ItemCode" || sColName == "ItemName" || sColName == "ItemSubCategoryID" || sColName == "GoodsFrom" || sColName == "Note_ID" || sColName == "UOM")
                {
                    clsAlerts.DisplayItemViewer(dgvDetail["ItemCode", e.RowIndex].Value.ToString(),
                             dgvDetail["ItemSubCategoryID", e.RowIndex].Tag.ToString(), dgvDetail["ItemSubCategoryID2", e.RowIndex].Tag.ToString(),
                             dgvDetail["ItemSerialNo", e.RowIndex].Value.ToString(), dgvDetail["ItemSerialNo2", e.RowIndex].Value.ToString());
                }
                else if (sColName == "ItemSerialNo")
                {
                    string sItemCode = dgvDetail["ItemCode", e.RowIndex].Value.ToString();
                    if (sItemCode.Length > 0 && sItemCode != "default")
                    {
                        string sImagePath = clsGenaralName.getName_ItemImagePath_ByItemID(sItemCode);
                        if (sImagePath != "" && sImagePath != "Default")
                        {
                            frmImageViewer f = new frmImageViewer(sImagePath);
                            f.ShowDialog();
                        }

                    }
                }
            }
        }

        public static void StockGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e, DataGridView dgvDetail)
        {
            if (e.RowIndex >= 0)
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (sColName == "ItemCode" || sColName == "ItemName" || sColName == "ItemSubCategoryID1" || sColName == "GoodsFrom" || sColName == "Note_ID" || sColName == "UOM")
                {
                    clsAlerts.DisplayItemViewer(dgvDetail["ItemCode", e.RowIndex].Value.ToString(),
                             dgvDetail["ItemSubCategoryID1", e.RowIndex].Tag.ToString(), dgvDetail["ItemSubCategoryID2", e.RowIndex].Tag.ToString(),
                             dgvDetail["ItemSerialNo1", e.RowIndex].Value.ToString(), dgvDetail["ItemSerialNo2", e.RowIndex].Value.ToString());
                }
                else if (sColName == "ItemSerialNo1")
                {
                    string sItemCode = dgvDetail["ItemCode", e.RowIndex].Value.ToString();
                    if (sItemCode.Length > 0 && sItemCode != "default")
                    {
                        string sImagePath = clsGenaralName.getName_ItemImagePath_ByItemID(sItemCode);
                        if (sImagePath != "" && sImagePath != "Default")
                        {
                            frmImageViewer f = new frmImageViewer(sImagePath);
                            f.ShowDialog();
                        }

                    }
                }
            }
        }
        public static void StockGridBinding_CellDoubleClick(object sender, DataGridViewCellEventArgs e, DataGridView dgvDetail)
        {
            string sColName = "";
            if (e.ColumnIndex >= 0)
                sColName = dgvDetail.Columns[e.ColumnIndex].Name;

            if (sColName == "item_ID" || sColName == "ItemName" || sColName == "itemSubCategory_ID" || sColName == "GoodsFrom" || sColName == "Note_ID" || sColName == "UOM")
            {
                string s = dgvDetail["item_ID", e.RowIndex].Value.ToString();

                clsAlerts.DisplayItemViewer(dgvDetail["item_ID", e.RowIndex].Value.ToString(),
                         dgvDetail["itemSubCategory_ID", e.RowIndex].Value.ToString(), dgvDetail["itemSubCategory2_ID", e.RowIndex].Value.ToString(),
                         dgvDetail["itemSerialNo", e.RowIndex].Value.ToString(), dgvDetail["itemSerialNo2", e.RowIndex].Value.ToString());
            }
        }

        #endregion

        #region Sales Grid CellEndEdit
        public static void SalesGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e, DataGridView dgvDetail, bool bWeightCalculation)
        {
            try
            {
                string sColName = "";
                decimal dWeightPrice = 0, dUnitPrice = 0, dQuantity = 0, dWeight = 0, dDiscountPresentage = 0, dDiscountedPrice = 0, dAmount = 0;
                bool bIsFreeItem = false;
                decimal UnitOrWaitedPrice = 0, dQtyOrWeight = 0;

                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                bIsFreeItem = (clsValidate.ValidateGridValue(dgvDetail, "Free", e.RowIndex, "") == "True") ? true : false;
                dDiscountPresentage = clsFormatter.RoundDecimalPlaces(clsValidate.ValidateGridValue(dgvDetail, "DiscuntPresentage", e.RowIndex, decimal.Parse("0.00")));
                dDiscountedPrice = clsFormatter.RoundDecimalPlaces(clsValidate.ValidateGridValue(dgvDetail, "DiscountValue", e.RowIndex, decimal.Parse("0.00")));

                if (!bWeightCalculation)
                {
                    dQtyOrWeight = dQuantity = clsFormatter.RoundDecimalPlaces_Quantity(clsValidate.ValidateGridValue(dgvDetail, "Quantity", e.RowIndex, decimal.Parse("0.00")));
                    UnitOrWaitedPrice = dUnitPrice = clsFormatter.RoundDecimalPlaces_UnitPrice(clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", e.RowIndex, decimal.Parse("0.00")));
                }
                else if (bWeightCalculation)
                {
                    dQtyOrWeight = dWeight = clsFormatter.RoundDecimalPlaces_Weight(clsValidate.ValidateGridValue(dgvDetail, "Weight", e.RowIndex, decimal.Parse("0.00")));
                    UnitOrWaitedPrice = dWeightPrice = clsFormatter.RoundDecimalPlaces_WeightPrice(clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", e.RowIndex, decimal.Parse("0.00")));
                }

                #region Discounts
                if (sColName == "DiscountValue")
                    dDiscountPresentage = clsFormatter.RoundDecimalPlaces(dDiscountedPrice * 100 / UnitOrWaitedPrice);
                else if (sColName == "DiscuntPresentage")
                    dDiscountedPrice = clsFormatter.RoundDecimalPlaces(UnitOrWaitedPrice * dDiscountPresentage / 100);
                else
                    dDiscountedPrice = clsFormatter.RoundDecimalPlaces(UnitOrWaitedPrice * dDiscountPresentage / 100);
                #endregion

                #region Free Item
                if (bIsFreeItem)
                {
                    dDiscountPresentage = 100;
                    dDiscountedPrice = dUnitPrice;

                    dgvDetail["DiscuntPresentage", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                    dgvDetail["DiscountValue", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                }
                else
                {
                    dgvDetail["DiscuntPresentage", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountPresentage);
                    dgvDetail["DiscountValue", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountedPrice);
                }
                #endregion

                dAmount = clsFormatter.RoundDecimalPlaces((UnitOrWaitedPrice - dDiscountedPrice) * dQtyOrWeight);

                dgvDetail["Quantity", e.RowIndex].Tag = dQuantity;
                dgvDetail["Quantity", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_Quantity(dQuantity);
                dgvDetail["UnitPrice", e.RowIndex].Tag = dUnitPrice;
                dgvDetail["UnitPrice", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(dUnitPrice);
                dgvDetail["Weight", e.RowIndex].Tag = dWeight;
                dgvDetail["Weight", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(dWeight);
                dgvDetail["WeightPrice", e.RowIndex].Tag = dWeightPrice;
                dgvDetail["WeightPrice", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(dWeightPrice);


                dgvDetail["DiscuntPresentage", e.RowIndex].Tag = dDiscountPresentage;
                dgvDetail["DiscountValue", e.RowIndex].Tag = dDiscountedPrice;

                dgvDetail["Amount", e.RowIndex].Tag = dAmount;
                dgvDetail["Amount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void SalesGrid_CellEndEdit_Invoice_Old(object sender, DataGridViewCellEventArgs e, DataGridView dgvDetail, bool bWeightCalculation)
        {
            //warning
            //rounding amounts may be effect to tax reverce calculation
            try
            {
                string sColName = "";
                decimal dWeightPrice = 0, dUnitPrice = 0, dQuantity = 0, dWeight = 0, dDiscountPresentage = 0, dDiscountedPrice = 0, dAmount = 0;
                bool bIsFreeItem = false;

                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                bIsFreeItem = (clsValidate.ValidateGridValue(dgvDetail, "Free", e.RowIndex, "") == "True") ? true : false;
                dDiscountPresentage = clsValidate.ValidateGridValue(dgvDetail, "DiscuntPresentage", e.RowIndex, decimal.Parse("0.00"));
                dDiscountedPrice = clsValidate.ValidateGridValue(dgvDetail, "DiscountValue", e.RowIndex, decimal.Parse("0.00"));

                if (!bWeightCalculation) //qty
                {
                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", e.RowIndex, decimal.Parse("0.00"));
                    dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", e.RowIndex, decimal.Parse("0.00"));

                    dgvDetail["UnitPrice", e.RowIndex].Tag = dUnitPrice;
                    dgvDetail["UnitPrice", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(dUnitPrice);

                    #region Discounts
                    if (sColName == "DiscountValue")
                        dDiscountPresentage = dDiscountedPrice * 100 / dUnitPrice;
                    else if (sColName == "DiscuntPresentage")
                        dDiscountedPrice = dUnitPrice * dDiscountPresentage / 100;
                    #endregion

                    #region Free Item
                    if (bIsFreeItem)
                    {
                        dDiscountPresentage = 100;
                        dDiscountedPrice = dUnitPrice;

                        dgvDetail["DiscuntPresentage", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                        dgvDetail["DiscountValue", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                    }
                    else
                    {
                        dgvDetail["DiscuntPresentage", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountPresentage);
                        dgvDetail["DiscountValue", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountedPrice);
                    }
                    #endregion

                    dAmount = GetTotalPrice(dUnitPrice - dDiscountedPrice, dQuantity);
                }
                else //weight
                {
                    dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", e.RowIndex, decimal.Parse("0.00"));
                    dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", e.RowIndex, decimal.Parse("0.00"));

                    dgvDetail["WeightPrice", e.RowIndex].Tag = dWeightPrice;
                    dgvDetail["WeightPrice", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(dWeightPrice);

                    if (clsConfig.bAutoQtyConvertFromSquareFeet && (sColName == "Weight" || sColName == "WeightPrice"))
                    {
                        string sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", e.RowIndex, "default");
                        decimal dQty = clsHelpMethods_Local.GetQuantityBySquarFt(sItemID, dWeight);
                        decimal dUPrice = (dWeight * dWeightPrice) / dQty;

                        dgvDetail["Quantity", e.RowIndex].Value = dQty;
                        dgvDetail["UnitPrice", e.RowIndex].Tag = dUPrice;
                        dgvDetail["UnitPrice", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(dUPrice);
                    }

                    #region Discounts
                    if (sColName == "DiscountValue")
                        dDiscountPresentage = dDiscountedPrice * 100 / dWeightPrice;
                    else if (sColName == "DiscuntPresentage")
                        dDiscountedPrice = dWeightPrice * dDiscountPresentage / 100;
                    #endregion

                    #region Free Item
                    if (bIsFreeItem)
                    {
                        dDiscountPresentage = 100;
                        dDiscountedPrice = dWeightPrice;

                        dgvDetail["DiscuntPresentage", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                        dgvDetail["DiscountValue", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                    }
                    else
                    {
                        dgvDetail["DiscuntPresentage", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountPresentage);
                        dgvDetail["DiscountValue", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountedPrice);
                    }
                    #endregion

                    dAmount = GetTotalPrice(dWeightPrice - dDiscountedPrice, dWeight);
                }
                dgvDetail["DiscuntPresentage", e.RowIndex].Tag = dDiscountPresentage;
                dgvDetail["DiscountValue", e.RowIndex].Tag = dDiscountedPrice;
                dgvDetail["Amount", e.RowIndex].Tag = dAmount;
                dgvDetail["Amount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void SalesGrid_CellEndEdit_Invoice(object sender, DataGridViewCellEventArgs e, DataGridView dgvDetail, bool bWeightCalculation)
        {
            try
            {
                string sColName = "";
                decimal dWeightPrice = 0, dUnitPrice = 0, dQuantity = 0, dWeight = 0, dDiscountPresentage = 0, dDiscountedPrice = 0, dAmount = 0;
                bool bIsFreeItem = false;

                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                bIsFreeItem = (clsValidate.ValidateGridValue(dgvDetail, "Free", e.RowIndex, "") == "True") ? true : false;
                dDiscountPresentage = clsValidate.ValidateGridValue(dgvDetail, "DiscuntPresentage", e.RowIndex, decimal.Parse("0.00"));
                dDiscountedPrice = clsValidate.ValidateGridValue(dgvDetail, "DiscountValue", e.RowIndex, decimal.Parse("0.00"));

                if (!bWeightCalculation) //qty
                {
                    dQuantity = clsValidate.ValidateGridValue(dgvDetail, "Quantity", e.RowIndex, decimal.Parse("0.00"));
                    dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", e.RowIndex, decimal.Parse("0.00"));
                    dUnitPrice = clsFormatter.RoundDecimalPlaces(dUnitPrice);

                    dgvDetail["UnitPrice", e.RowIndex].Tag = dUnitPrice;
                    dgvDetail["UnitPrice", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(dUnitPrice);

                    #region Discounts
                    if (sColName == "DiscountValue")
                        dDiscountPresentage = dDiscountedPrice * 100 / dUnitPrice;
                    else if (sColName == "DiscuntPresentage")
                    {
                        dDiscountedPrice = dUnitPrice * dDiscountPresentage / 100;
                        dDiscountedPrice = clsFormatter.RoundDecimalPlaces(dDiscountedPrice);
                    }
                    else
                        dDiscountedPrice = clsFormatter.RoundDecimalPlaces(dUnitPrice * dDiscountPresentage / 100);
                    #endregion

                    #region Free Item
                    if (bIsFreeItem)
                    {
                        dDiscountPresentage = 100;
                        dDiscountedPrice = dUnitPrice;

                        dgvDetail["DiscuntPresentage", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                        dgvDetail["DiscountValue", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                    }
                    else
                    {
                        dgvDetail["DiscuntPresentage", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountPresentage);
                        dgvDetail["DiscountValue", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountedPrice);
                    }
                    #endregion

                    dAmount = clsFormatter.RoundDecimalPlaces((dUnitPrice - dDiscountedPrice) * dQuantity);
                    //GetTotalPrice(dUnitPrice-dDiscountedPrice, dQuantity);
                }
                else //weight
                {
                    //dWeight = clsValidate.ValidateGridValue(dgvDetail, "Weight", e.RowIndex, decimal.Parse("0.00"));
                    //dWeightPrice = clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", e.RowIndex, decimal.Parse("0.00"));

                    //dgvDetail["WeightPrice", e.RowIndex].Tag = dWeightPrice;
                    //dgvDetail["WeightPrice", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(dWeightPrice);

                    //if (clsConfig.bAutoQtyConvertFromSquareFeet && (sColName == "Weight" || sColName == "WeightPrice"))
                    //{
                    //    string sItemID = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", e.RowIndex, "default");
                    //    decimal dQty = clsHelpMethods_Local.GetQuantityBySquarFt(sItemID, dWeight);
                    //    decimal dUPrice = (dWeight * dWeightPrice) / dQty;

                    //    dgvDetail["Quantity", e.RowIndex].Value = dQty;
                    //    dgvDetail["UnitPrice", e.RowIndex].Tag = dUPrice;
                    //    dgvDetail["UnitPrice", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(dUPrice);
                    //}

                    //#region Discounts
                    //if (sColName == "DiscountValue")
                    //    dDiscountPresentage = dDiscountedPrice * 100 / dWeightPrice;
                    //else if (sColName == "DiscuntPresentage")
                    //    dDiscountedPrice = dWeightPrice * dDiscountPresentage / 100;
                    //#endregion

                    //#region Free Item
                    //if (bIsFreeItem)
                    //{
                    //    dDiscountPresentage = 100;
                    //    dDiscountedPrice = dWeightPrice;

                    //    dgvDetail["DiscuntPresentage", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                    //    dgvDetail["DiscountValue", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(0);
                    //}
                    //else
                    //{
                    //    dgvDetail["DiscuntPresentage", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountPresentage);
                    //    dgvDetail["DiscountValue", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dDiscountedPrice);
                    //} 
                    //#endregion

                    //dAmount = GetTotalPrice(dWeightPrice-dDiscountedPrice, dWeight);
                }
                dgvDetail["DiscuntPresentage", e.RowIndex].Tag = dDiscountPresentage;
                dgvDetail["DiscountValue", e.RowIndex].Tag = dDiscountedPrice;
                dgvDetail["Amount", e.RowIndex].Tag = dAmount;
                dgvDetail["Amount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Stock Grid CellEndEdit
        public static void StockGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e, DataGridView dgvDetail)
        {
            try
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;
                //Change Actual Weight         
                if (sColName == "WeightActual")
                {
                    string sjobCode = "", sFrom = "", sItemCode = "";
                    decimal dQty = 0, dweightAct = 0;

                    sjobCode = clsValidate.ValidateGridValue(dgvDetail, "JobCode", e.RowIndex, "");
                    sFrom = clsValidate.ValidateGridValue(dgvDetail, "GoodsFrom", e.RowIndex, "");
                    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", e.RowIndex, "");
                    dweightAct = clsValidate.ValidateGridValue(dgvDetail, "WeightActual", e.RowIndex, decimal.Parse("0.00"));
                    dQty = clsHelpMethods_Local.GetQuantityByItemID(sItemCode, dweightAct);

                }
                else if (sColName == "Quantity" || sColName == "ItemUnitPrice")
                {
                    string sItemCode = "";
                    decimal dQty = 0, dweightAct = 0, dCostPrice = 0, dUnitPrice = 0;

                    sItemCode = clsValidate.ValidateGridValue(dgvDetail, "ItemCode", e.RowIndex, "");
                    dQty = clsValidate.ValidateGridValue(dgvDetail, "Quantity", e.RowIndex, decimal.Parse("0.00"));
                    dweightAct = clsHelpMethods_Local.GetWeightByItemID(sItemCode, dQty);
                    dCostPrice = clsValidate.ValidateGridValue(dgvDetail, "CostPrice", e.RowIndex, decimal.Parse("0.00"));
                    dUnitPrice = clsValidate.ValidateGridValue(dgvDetail, "ItemUnitPrice", e.RowIndex, decimal.Parse("0.00"));
                    dgvDetail["TotalCostPrice", e.RowIndex].Value = clsFormatter.FormatToNumberWithTwoDecimalPlaces(dCostPrice * dQty);
                    dgvDetail["ItemTotalValue", e.RowIndex].Value = clsFormatter.FormatToNumberWithFourDecimalPlaces(dQty * dUnitPrice);
                    // dgvDetail["WeightActual", e.RowIndex].Value = clsFormatter.FormatToNumberWithFourDecimalPlaces(dweightAct);
                }
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Stock Grid - External CellEndEdit
        public static void StockGrid_External_CellEndEdit(object sender, DataGridViewCellEventArgs e, DataGridView dgvDetail, bool bWeightCalculation)
        {
            try
            {
                string sColName = "";
                decimal dWeightPrice = 0, dUnitPrice = 0, dQuantity = 0, dWeight, dAmount = 0;
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (!bWeightCalculation)
                {
                    dQuantity = clsFormatter.RoundDecimalPlaces_Quantity(clsValidate.ValidateGridValue(dgvDetail, "Quantity", e.RowIndex, decimal.Parse("0.00")));
                    dUnitPrice = clsFormatter.RoundDecimalPlaces_UnitPrice(clsValidate.ValidateGridValue(dgvDetail, "UnitPrice", e.RowIndex, decimal.Parse("0.00")));
                    dAmount = clsFormatter.RoundDecimalPlaces(GetTotalPrice(dUnitPrice, dQuantity));

                    dgvDetail["Quantity", e.RowIndex].Value = dQuantity;
                    dgvDetail["Amount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                    dgvDetail["Amount", e.RowIndex].Tag = dAmount;
                    dgvDetail["UnitPrice", e.RowIndex].Tag = dUnitPrice;
                    dgvDetail["UnitPrice", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_UnitPrice(dUnitPrice);
                }
                else if (bWeightCalculation)
                {
                    dWeight = clsFormatter.RoundDecimalPlaces_UnitPrice(clsValidate.ValidateGridValue(dgvDetail, "Weight", e.RowIndex, decimal.Parse("0.00")));
                    dWeightPrice = clsFormatter.RoundDecimalPlaces_UnitPrice(clsValidate.ValidateGridValue(dgvDetail, "WeightPrice", e.RowIndex, decimal.Parse("0.00")));
                    dAmount = clsFormatter.RoundDecimalPlaces(GetTotalPrice(dWeight, dWeightPrice));

                    dgvDetail["Weight", e.RowIndex].Value = dWeight;
                    dgvDetail["Amount", e.RowIndex].Value = clsFormatter.FormatToCurrecyWithThousendSep(dAmount);
                    dgvDetail["Amount", e.RowIndex].Tag = dAmount;
                    dgvDetail["WeightPrice", e.RowIndex].Tag = dWeightPrice;
                    dgvDetail["WeightPrice", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_WeightPrice(dWeightPrice);
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", 0, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Grid CellEndEdit - SalesBreakdown
        public static bool Grid_CellEndEditBreakdown(object sender, DataGridViewCellEventArgs e, DataGridView dgvDetail, DataGridView dgvGenaral, bool bWeightCalculation)
        {
            bool value = false;
            try
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                decimal dQuantity = 0, dWeight = 0;
                string sItemID = "";
                int iLineNo = 0, iRow = -1;
                if (sColName == "BrkSerialNo" || sColName == "BrkQuantity" || sColName == "BrkWeight" || sColName == "BrkItemName") //Serial No  
                {
                    if (dgvGenaral.SelectedRows.Count > 0)
                        iRow = dgvGenaral.SelectedRows[0].Index;
                    if (iRow != -1)
                    {
                        iLineNo = clsValidate.ValidateGridValue(dgvGenaral, "GenLineNo", iRow, int.Parse("0"));
                        sItemID = clsValidate.ValidateGridValue(dgvGenaral, "GenItemCode", iRow, "default");
                        dWeight = clsValidate.ValidateGridValue(dgvGenaral, "GenWeight", iRow, decimal.Parse("0.00"));
                        dQuantity = clsValidate.ValidateGridValue(dgvGenaral, "GenQuantity", iRow, decimal.Parse("0.00"));

                        //calculate required qtry
                        decimal dExQty = 0, dExWeight = 0;
                        if (sColName == "BrkSerialNo") //Serial No  
                        {
                            //Clear 
                            dgvDetail["BrkLineNo", e.RowIndex].Value = iLineNo;
                            dgvDetail["BrkQuantity", e.RowIndex].Value = 0;
                            dgvDetail["BrkWeight", e.RowIndex].Value = 0;

                            foreach (DataGridViewRow row in dgvDetail.Rows)
                            {
                                if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())//For AKT
                                {
                                    dExWeight += clsValidate.ValidateGridValue(dgvDetail, "BrkItemName", row.Index, decimal.Parse("0.00"));

                                    decimal dTmpExPack = clsValidate.ValidateGridValue(dgvDetail, "BrkSerialNo", row.Index, decimal.Parse("0.00"));
                                    decimal dTmpExQty = clsValidate.ValidateGridValue(dgvDetail, "BrkQuantity", row.Index, decimal.Parse("0.00"));
                                    if (dTmpExQty > 0 && dTmpExPack > 0)
                                        dExQty += (dTmpExQty * dTmpExPack);
                                }
                                else
                                {
                                    dExQty += clsValidate.ValidateGridValue(dgvDetail, "BrkQuantity", row.Index, decimal.Parse("0.00"));
                                    dExWeight += clsValidate.ValidateGridValue(dgvDetail, "BrkWeight", row.Index, decimal.Parse("0.00"));
                                }
                            }
                            dQuantity -= dExQty;
                            dWeight -= dExWeight;

                            dgvDetail["BrkLineNo", e.RowIndex].Value = iLineNo;
                            dgvDetail["BrkItemCode", e.RowIndex].Value = sItemID;
                            dgvDetail["BrkItemName", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_Weight(dExWeight);
                            dgvDetail["BrkQuantity", e.RowIndex].Value = dQuantity;
                            dgvDetail["BrkWeight", e.RowIndex].Value = dWeight;
                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())//For AKT
                            {
                                dgvDetail["BrkItemName", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_Weight(dWeight); //update TotalWeight
                                decimal dTmpExPack = clsValidate.ValidateGridValue(dgvDetail, "BrkSerialNo", e.RowIndex, decimal.Parse("1.00"));
                                decimal dTmpExQty = clsValidate.ValidateGridValue(dgvDetail, "BrkQuantity", e.RowIndex, decimal.Parse("1.00"));
                                dgvDetail["BrkQuantity", e.RowIndex].Value = (dQuantity / dTmpExPack); //update Qty                                

                                if (!bWeightCalculation)
                                    dgvDetail["BrkWeight", e.RowIndex].Value = "N/A";
                            }
                        }
                        else if (sColName == "BrkQuantity" || sColName == "BrkWeight" || sColName == "BrkItemName")
                        {
                            if (clsConfig.sSoftwareModel.Trim() == SoftwareModel_Sales.akt.ToString())
                            {
                                if (!bWeightCalculation)
                                {
                                    dgvDetail["BrkWeight", e.RowIndex].Value = "N/A";
                                }
                                else
                                {
                                    decimal dTmpQty = clsValidate.ValidateGridValue(dgvDetail, "BrkQuantity", e.RowIndex, decimal.Parse("0.00"));
                                    decimal dTmpWeight = clsValidate.ValidateGridValue(dgvDetail, "BrkWeight", e.RowIndex, decimal.Parse("0.00"));
                                    decimal dTmpPack = clsValidate.ValidateGridValue(dgvDetail, "BrkSerialNo", e.RowIndex, decimal.Parse("0.00"));
                                    decimal dTotalWeight = (dTmpWeight * dTmpQty * dTmpPack);
                                    dgvDetail["BrkItemName", e.RowIndex].Value = clsFormatter.FormatDecimalPlaces_Weight(dTotalWeight);
                                }
                            }
                            value = true;
                        }
                    }
                }

                if (!clsCommon.IsLastRawEmpty(dgvDetail, dgvDetail.Rows.GetLastRow(DataGridViewElementStates.Displayed)))
                    dgvDetail.Rows.Add();
            }
            catch (Exception) { }
            return value;
        }
        #endregion

        #region Grid CellEndEdit - StokeBreakdown
        public static bool Grid_CellEndEditBreakdownForStoke(object sender, DataGridViewCellEventArgs e, DataGridView dgvDetail, DataGridView dgvGenaral)
        {
            bool value = false;
            try
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                string sItemCode = "", sUom = "default", sJobCode = "";
                decimal dWeight = 0, dWeightActual = 0, dQuantitiy = 0, dLength = 0, dGauge = 0;
                int iLineNo = 0, iRow = -1;

                if (sColName == "BrkSerialNo") //Serial No
                {
                    if (dgvGenaral.SelectedRows.Count > 0)
                        iRow = dgvGenaral.SelectedRows[0].Index;
                    if (iRow != -1)
                    {
                        iLineNo = clsValidate.ValidateGridValue(dgvGenaral, "LineNo", iRow, 0);
                        sItemCode = clsValidate.ValidateGridValue(dgvGenaral, "BItemCode", iRow, "");
                        sJobCode = clsValidate.ValidateGridValue(dgvGenaral, "BJobCode", iRow, "default");
                        sUom = clsValidate.ValidateGridTag(dgvGenaral, "BUOM", iRow, "default");
                        dQuantitiy = clsValidate.ValidateGridValue(dgvGenaral, "BQuantity", iRow, decimal.Parse("0.00"));
                        dWeight = clsValidate.ValidateGridValue(dgvGenaral, "BWeight", iRow, decimal.Parse("0.00"));
                        dWeightActual = clsValidate.ValidateGridValue(dgvGenaral, "BWeightActual", iRow, decimal.Parse("0.00"));
                        dLength = clsValidate.ValidateGridValue(dgvGenaral, "BLength", iRow, decimal.Parse("0.00"));
                        dGauge = clsValidate.ValidateGridValue(dgvGenaral, "BGauge", iRow, decimal.Parse("0.00"));

                        //calculate required qtry
                        decimal dExQty = 0;
                        foreach (DataGridViewRow row in dgvDetail.Rows)
                        {
                            dExQty += clsValidate.ValidateGridValue(dgvDetail, "BrkQuantity", row.Index, decimal.Parse("0.00"));
                        }
                        //dQuantitiy -= dExQty;


                        dgvDetail["BrkLineNo", e.RowIndex].Value = iLineNo;
                        dgvDetail["BrkItemCode", e.RowIndex].Value = sItemCode;
                        dgvDetail["BrkJobCode", e.RowIndex].Value = sJobCode;
                        dgvDetail["BrkUOM", e.RowIndex].Value = clsGenaralName.getName_Uom(sUom);
                        dgvDetail["BrkUOM", e.RowIndex].Tag = sUom;
                        dgvDetail["BrkQuantity", e.RowIndex].Value = dQuantitiy;
                        dgvDetail["BrkWeight", e.RowIndex].Value = dWeight;
                        dgvDetail["BrkWeightActual", e.RowIndex].Value = dWeightActual;
                        dgvDetail["BrkHeight", e.RowIndex].Value = dLength;
                        dgvDetail["BrkGauge", e.RowIndex].Value = dGauge;
                        value = true;
                        if (!clsCommon.IsLastRawEmpty(dgvDetail, dgvDetail.Rows.GetLastRow(DataGridViewElementStates.Displayed)))
                            dgvDetail.Rows.Add();
                    }
                }
                else if (sColName == "BrkQuantity") //Quantity
                {
                    if (dgvDetail["BrkItemCode", e.RowIndex].Value == null || dgvDetail["BrkItemCode", e.RowIndex].Value.ToString().Length <= 0)
                        MessageBox.Show("Please Select the Serial Number First", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        if (!clsCommon.IsLastRawEmpty(dgvDetail, dgvDetail.Rows.GetLastRow(DataGridViewElementStates.Displayed)))
                            dgvDetail.Rows.Add();
                        value = true;
                    }
                }
                else if (sColName == "BrkRemarks") //Remarks
                {
                    if (!clsCommon.IsLastRawEmpty(dgvDetail, dgvDetail.Rows.GetLastRow(DataGridViewElementStates.Displayed)))
                        dgvDetail.Rows.Add();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return value;
        }
        #endregion

        #region Sales Grid CellParsing
        public static void SalesGrid_CellParsing(object sender, DataGridViewCellParsingEventArgs e, DataGridView dgvDetail)
        {
            try
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (sColName == "Width" || sColName == "Height" || sColName == "Gauge" || sColName == "Gusset" || sColName == "Quantity" || sColName == "KiloPrice" || sColName == "UnitPrice" || sColName == "Weight" || sColName == "DepositedAmount")
                {
                    if (!clsCommon.isCurrency(e.Value.ToString()))
                        MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, e.Value.ToString()), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region Stock Grid CellParsing
        public static void StockGrid_CellParsing(object sender, DataGridViewCellParsingEventArgs e, DataGridView dgvDetail)
        {
            try
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvDetail.Columns[e.ColumnIndex].Name;

                if (sColName == "Weight" || sColName == "WeightActual")
                {
                    if (!clsCommon.isCurrency(e.Value.ToString()))
                        MessageBox.Show(clsFormatter.getCommonStatusStripMessage(StatusStripMessageTypes.WhenInserNumber, e.Value.ToString()), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region grid Cell Edit - Stock GRN BrackDown
        public static bool Grid_CellEndEditBreakdownStoke(object sender, DataGridViewCellEventArgs e, DataGridView dgvBrakedown, DataGridView dgvGenaral)
        {
            bool value = false;
            try
            {
                string sColName = "";
                if (e.ColumnIndex >= 0)
                    sColName = dgvBrakedown.Columns[e.ColumnIndex].Name;

                int iRow = -1;
                if (sColName.Trim().ToLower() == "brkserialno")
                {
                    if (dgvGenaral.SelectedRows.Count > 0)
                        iRow = dgvGenaral.SelectedRows[0].Index;
                    if (iRow >= 0)
                    {
                        if (dgvBrakedown["BrkSerialNo", e.RowIndex].Value != null && dgvBrakedown["BrkSerialNo", e.RowIndex].Value.ToString().Trim().Length > 0)
                        {
                            //calculate required qtry
                            decimal dExQty = 0;
                            foreach (DataGridViewRow row in dgvBrakedown.Rows)
                            {
                                dExQty += clsValidate.ValidateGridValue(dgvBrakedown, "BrkQuantity", row.Index, decimal.Parse("0.00"));
                            }
                            decimal dWeight = 0, Qty = 0;
                            string sItmID = "";
                            sItmID = clsValidate.ValidateGridValue(dgvGenaral, "GenItemCode", iRow, "default");
                            Qty = clsValidate.ValidateGridValue(dgvGenaral, "GenQuantity", iRow, decimal.Parse("0.00"));
                            dWeight = clsHelpMethods_Local.GetWeightByItemID(sItmID, Qty);

                            //sItmID = clsValidate.ValidateGridValue(dgvBrakedown, "BrkItemCode", e.RowIndex, "default");
                            //Qty = clsValidate.ValidateGridValue(dgvBrakedown, "BrkQuantity", e.RowIndex, decimal.Parse("0.00"));
                            //dWeight = clsHelpMethods.GetWeightByItemID(sItmID, Qty);

                            dgvBrakedown["BrkLineNo", e.RowIndex].Value = clsValidate.ValidateGridValue(dgvGenaral, "GenLineNo", iRow, 0);
                            dgvBrakedown["BrkItemCode", e.RowIndex].Value = clsValidate.ValidateGridValue(dgvGenaral, "GenItemCode", iRow, "default");
                            dgvBrakedown["BrkItemName", e.RowIndex].Value = clsValidate.ValidateGridValue(dgvGenaral, "GenItemName", iRow, "");
                            dgvBrakedown["BrkJobCode", e.RowIndex].Value = clsValidate.ValidateGridValue(dgvGenaral, "GenJobCode", iRow, "default");
                            dgvBrakedown["BrkGoodsFrom", e.RowIndex].Value = clsValidate.ValidateGridValue(dgvGenaral, "GenGoodsFrom", iRow, "default");
                            dgvBrakedown["BrkNote_ID", e.RowIndex].Value = clsValidate.ValidateGridValue(dgvGenaral, "GenNote_ID", iRow, "default");
                            //dgvBrakedown["BrkSerialNo", e.RowIndex].Value =
                            dgvBrakedown["BrkQuantity", e.RowIndex].Value = clsValidate.ValidateGridValue(dgvGenaral, "GenQuantity", iRow, decimal.Parse("0.00")) - dExQty;
                            dgvBrakedown["BrkUOM", e.RowIndex].Tag = clsValidate.ValidateGridTag(dgvGenaral, "GenUOM", iRow, "default");
                            dgvBrakedown["BrkUOM", e.RowIndex].Value = clsGenaralName.getName_Uom(clsValidate.ValidateGridTag(dgvGenaral, "GenUOM", iRow, "default"));
                            dgvBrakedown["BrkWeight", e.RowIndex].Value = dWeight;      // clsValidate.ValidateGridValue(dgvGenaral, "GenWeight", iRow, decimal.Parse("0.00"));
                            dgvBrakedown["BrkWeightActual", e.RowIndex].Value = dWeight;   // clsValidate.ValidateGridValue(dgvGenaral, "GenWeightActual", iRow, decimal.Parse("0.00"));
                            dgvBrakedown["BrkSelectArea_ID", e.RowIndex].Value = clsValidate.ValidateGridValue(dgvGenaral, "GenSelectArea_ID", iRow, "default");
                            dgvBrakedown["BrkDepartment_ID", e.RowIndex].Value = clsValidate.ValidateGridValue(dgvGenaral, "GenDepartment_ID", iRow, "default");
                            dgvBrakedown["BrkSection_ID", e.RowIndex].Value = clsValidate.ValidateGridValue(dgvGenaral, "GenSection_ID", iRow, "default");
                            dgvBrakedown["BrkStore_ID", e.RowIndex].Value = clsValidate.ValidateGridValue(dgvGenaral, "GenStore_ID", iRow, "default");
                            dgvBrakedown["BrkDepartmentNote_ID", e.RowIndex].Value = clsValidate.ValidateGridValue(dgvGenaral, "GenDepartmentNote_ID", iRow, "default");
                            dgvBrakedown["BrkSectionNote_ID", e.RowIndex].Value = clsValidate.ValidateGridValue(dgvGenaral, "GenSectionNote_ID", iRow, "default");
                            dgvBrakedown["BrkStoreNote_ID", e.RowIndex].Value = clsValidate.ValidateGridValue(dgvGenaral, "GenStoreNote_ID", iRow, "default");
                            //dgvBrakedown["BrkRemaks", e.RowIndex].Value =
                            value = true;
                            if (!clsCommon.IsLastRawEmpty(dgvBrakedown, dgvBrakedown.Rows.GetLastRow(DataGridViewElementStates.Displayed)))
                                dgvBrakedown.Rows.Add();
                        }
                        else
                        {
                            MessageBox.Show("Please Select the Serial Number First", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
                else if (sColName.Trim().ToLower() == "brkquantity") //Quantity
                {
                    if (dgvBrakedown["BrkItemCode", e.RowIndex].Value == null || dgvBrakedown["BrkItemCode", e.RowIndex].Value.ToString().Trim().Length <= 0)
                    {
                        MessageBox.Show("Please Select the Serial Number First", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvBrakedown["BrkQuantity", e.RowIndex].Value = "";
                    }
                    else
                    {
                        decimal dWeight = 0, Qty = 0;
                        string sItmID = "";
                        sItmID = clsValidate.ValidateGridValue(dgvBrakedown, "BrkItemCode", e.RowIndex, "default");
                        Qty = clsValidate.ValidateGridValue(dgvBrakedown, "BrkQuantity", e.RowIndex, decimal.Parse("0.00"));
                        dWeight = clsHelpMethods_Local.GetWeightByItemID(sItmID, Qty);
                        dgvBrakedown["BrkWeight", e.RowIndex].Value = clsFormatter.FormatToNumberWithFourDecimalPlaces(dWeight);
                        dgvBrakedown["BrkWeightActual", e.RowIndex].Value = clsFormatter.FormatToNumberWithFourDecimalPlaces(dWeight);
                        if (!clsCommon.IsLastRawEmpty(dgvBrakedown, dgvBrakedown.Rows.GetLastRow(DataGridViewElementStates.Displayed)))
                            dgvBrakedown.Rows.Add();
                        value = true;
                    }
                }
                else if (sColName.Trim().ToLower() == "brkremaks") //Remarks
                {
                    if (dgvBrakedown["BrkItemCode", e.RowIndex].Value == null || dgvBrakedown["BrkItemCode", e.RowIndex].Value.ToString().Trim().Length <= 0)
                    {
                        MessageBox.Show("Please Select the Serial Number First", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvBrakedown["BrkRemaks", e.RowIndex].Value = "";
                    }
                    else
                    {
                        if (!clsCommon.IsLastRawEmpty(dgvBrakedown, dgvBrakedown.Rows.GetLastRow(DataGridViewElementStates.Displayed)))
                            dgvBrakedown.Rows.Add();
                    }
                }
            }
            catch (Exception ex)
            {
                clsValidate.WriteErrorLog("", -1, ex);
                MessageBox.Show(ex.Message.ToString(), clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return value;
        }
        #endregion

        //Picture Box
        #region Picture Box Click
        public static void PictureBox_Click(TextBox txtGLCode, TextBox txtAmount)
        {
            frmSetGLCode frm = new frmSetGLCode();
            frmSetGLCode.glbGLCode = txtGLCode.Text.Trim();
            frm.glbAmount = (txtAmount.TextLength > 0 && clsCommon.isCurrency(txtAmount.Text)) ? decimal.Parse(txtAmount.Text.Trim()) : 0;
            frm.ShowDialog();
            txtGLCode.Text = frmSetGLCode.glbGLCode;
        }


        public static void PictureBox_Click(ref DataTable dtGLAccountDetails, decimal dAmount, TransactionCategory eTCategory, int iSendFormId, string sCurrencyID, decimal dCurrencyRate)
        {
            frmSetGLCode frm = new frmSetGLCode();
            if (sCurrencyID == null || sCurrencyID == "")
                sCurrencyID = clsConfig.sLocalCurrencyCode;

            frm.txtCurrencyID.Tag = sCurrencyID;
            frm.txtCurrencyID.Text = clsGenaralName.getName_Currency(sCurrencyID);
            frm.txtCurCode.Text = clsGenaralName.getName_CurrencyCode(sCurrencyID);
            frm.txtCurrencyRate.Text = dCurrencyRate.ToString();

            if (TransactionCategory.SubTotal == eTCategory)
            {
                frmSetGLCode.glb_SubTotal = dtGLAccountDetails;
                frmSetGLCode.iTCatID = clsAutocode.getTransactionCategoryID(TransactionCategory.SubTotal);
            }
            else if (TransactionCategory.NBT == eTCategory)
            {
                frmSetGLCode.glb_NBT = dtGLAccountDetails;
                frmSetGLCode.iTCatID = clsAutocode.getTransactionCategoryID(TransactionCategory.NBT);
            }
            else if (TransactionCategory.VAT == eTCategory)
            {
                frmSetGLCode.glb_VAT = dtGLAccountDetails;
                frmSetGLCode.iTCatID = clsAutocode.getTransactionCategoryID(TransactionCategory.VAT);
            }
            else if (TransactionCategory.SVAT == eTCategory)
            {
                frmSetGLCode.glb_SVAT = dtGLAccountDetails;
                frmSetGLCode.iTCatID = clsAutocode.getTransactionCategoryID(TransactionCategory.SVAT);
            }
            else if (TransactionCategory.GrandTotal == eTCategory)
            {
                frmSetGLCode.glb_GrandTotal = dtGLAccountDetails;
                frmSetGLCode.iTCatID = clsAutocode.getTransactionCategoryID(TransactionCategory.GrandTotal);
            }
            else if (TransactionCategory.Cash == eTCategory)
            {
                frmSetGLCode.glb_Cash = dtGLAccountDetails;
                frmSetGLCode.iTCatID = clsAutocode.getTransactionCategoryID(TransactionCategory.Cash);
            }
            else if (TransactionCategory.Cheque == eTCategory)
            {
                frmSetGLCode.glb_Cheque = dtGLAccountDetails;
                frmSetGLCode.iTCatID = clsAutocode.getTransactionCategoryID(TransactionCategory.Cheque);
            }
            else if (TransactionCategory.Other_Cr == eTCategory)
            {
                frmSetGLCode.glb_Other_Cr = dtGLAccountDetails;
                frmSetGLCode.iTCatID = clsAutocode.getTransactionCategoryID(TransactionCategory.Other_Cr);
            }
            else if (TransactionCategory.Supplier == eTCategory)
            {
                frmSetGLCode.glb_Suppler = dtGLAccountDetails;
                frmSetGLCode.iTCatID = clsAutocode.getTransactionCategoryID(TransactionCategory.Supplier);
            }
            else if (TransactionCategory.Customer == eTCategory)
            {
                frmSetGLCode.glb_Customer = dtGLAccountDetails;
                frmSetGLCode.iTCatID = clsAutocode.getTransactionCategoryID(TransactionCategory.Customer);
            }
            else if (TransactionCategory.CreditEntry == eTCategory)
            {
                frmSetGLCode.glb_CreditEntry = dtGLAccountDetails;
                frmSetGLCode.iTCatID = clsAutocode.getTransactionCategoryID(TransactionCategory.CreditEntry);
            }
            else if (TransactionCategory.DebitEntry == eTCategory)
            {
                frmSetGLCode.glb_DebitEntry = dtGLAccountDetails;
                frmSetGLCode.iTCatID = clsAutocode.getTransactionCategoryID(TransactionCategory.DebitEntry);
            }

            frm.iSendFormId = iSendFormId;
            frm.glbAmount = dAmount;
            frm.ShowDialog();

            if (TransactionCategory.SubTotal == eTCategory)
                dtGLAccountDetails = frmSetGLCode.glb_SubTotal;
            else if (TransactionCategory.NBT == eTCategory)
                dtGLAccountDetails = frmSetGLCode.glb_NBT;
            else if (TransactionCategory.VAT == eTCategory)
                dtGLAccountDetails = frmSetGLCode.glb_VAT;
            else if (TransactionCategory.SVAT == eTCategory)
                frmSetGLCode.glb_SVAT = dtGLAccountDetails;
            else if (TransactionCategory.GrandTotal == eTCategory)
                dtGLAccountDetails = frmSetGLCode.glb_GrandTotal;
            else if (TransactionCategory.Cash == eTCategory)
                dtGLAccountDetails = frmSetGLCode.glb_Cash;
            else if (TransactionCategory.Cheque == eTCategory)
                dtGLAccountDetails = frmSetGLCode.glb_Cheque;
            else if (TransactionCategory.Other_Cr == eTCategory)
                dtGLAccountDetails = frmSetGLCode.glb_Other_Cr;
            else if (TransactionCategory.Supplier == eTCategory)
                dtGLAccountDetails = frmSetGLCode.glb_Suppler;
            else if (TransactionCategory.CreditEntry == eTCategory)
                dtGLAccountDetails = frmSetGLCode.glb_CreditEntry;
            else if (TransactionCategory.DebitEntry == eTCategory)
                dtGLAccountDetails = frmSetGLCode.glb_DebitEntry;
        }
        #endregion

        #region GLCode Text Change
        public static void GLCode_TextChanged(PictureBox pbxIcon, string txt)
        {
            if (txt == "")
                pbxIcon.Image = Digiteq.Properties.Resources.Free;
            else if (txt == "default")
                pbxIcon.Image = Digiteq.Properties.Resources.delete;
            else if (txt.Length > 0)
                pbxIcon.Image = Digiteq.Properties.Resources.accept;
        }
        public static void GLCode_TextChanged(PictureBox pbxIcon, DataTable dt, TextBox txtSubTotal, TextBox txtExRate)
        {
            decimal dTotAmount = 0;
            decimal dExRate = 0;
            if (txtExRate == null)
                dExRate = 1;
            else
                dExRate = decimal.Parse(txtExRate.Text.Trim());

            //Validate 1
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["GLCode"].ToString() == "default")
                        pbxIcon.Image = Digiteq.Properties.Resources.delete;
                    else if (row["GLCode"].ToString().Length > 0)
                        pbxIcon.Image = Digiteq.Properties.Resources.accept;

                    dTotAmount += decimal.Parse(row["GLAmount"].ToString());
                }
            }
            else
                pbxIcon.Image = Digiteq.Properties.Resources.Free;

            //Validate 2

            decimal dSubTotal = clsCommon.isCurrency(txtSubTotal.Text.Trim()) && txtSubTotal.Text.Trim().Length > 0 ? decimal.Parse(txtSubTotal.Text.Trim()) : decimal.Parse("0.00");
            if (dTotAmount != dSubTotal * dExRate)
                pbxIcon.Image = Digiteq.Properties.Resources.delete;
        }
        #endregion
    }
}