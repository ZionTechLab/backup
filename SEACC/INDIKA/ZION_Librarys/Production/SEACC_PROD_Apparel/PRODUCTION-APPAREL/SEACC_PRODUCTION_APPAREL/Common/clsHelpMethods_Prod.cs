using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace SEACC_PRODUCTION_APPAREL.Common
{

    public class clsHelpMethods_Prod
    {
        #region Format Date and Time
        //public static string Format_DateTime = "yyyy/MM/dd HH:mm"; 
        public static string Format_DateTime(DateTime dt)
        {
            string sValue = "";
            if (clsValidation.defaultDateTime.Date != dt.Date)
                sValue = dt.ToString("yyyy/MM/dd HH:mm");
            else
                sValue = "-";

            return sValue;
        }
        #endregion

        #region Get Host Name
        public static string GetHostName()
        {
            string macAddresses = Dns.GetHostName();
            return macAddresses;
        }
        #endregion

        #region Get Mac Address
        public static string GetMacAddress()
        {
            string macAddresses = "";

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddresses;
        }
        #endregion

        #region Get IP Address
        public static string GetIPAddress()
        {
            string sIPAddress = "";
            try
            {
                System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();

                // Get server related information.
                IPHostEntry heserver = Dns.GetHostEntry(GetHostName());

                // Loop on the AddressList
                foreach (IPAddress curAdd in heserver.AddressList)
                {
                    if (clsValidate.CheckValidityIPAddress(curAdd.ToString()))
                    {
                        sIPAddress = curAdd.ToString();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[DoResolve] Exception: " + e.ToString());
            }
            return sIPAddress;
        }
        #endregion

        #region Get Form Name
        public static string getFormName(FormName iFormID)
        {
            string sFormName = "";
            tbl_securityFormMaster formMaster = tbl_securityFormMaster.Select((int)iFormID);
            if (formMaster != null)
                sFormName = formMaster.FormName;
            return sFormName;
        }
        public static void FormatUCHeader(Label lblUC_Header, Label lblUC_ID, FormName iFormID)
        {
            tbl_securityFormMaster formMaster = tbl_securityFormMaster.Select((int)iFormID);
            if (formMaster != null)
            {
                lblUC_Header.Content = formMaster.FormName;
                lblUC_ID.Content = formMaster.FormCategory_ID + "/" + formMaster.Form_ID;
            }
        }
        #endregion


        public static bool AutoAssignCompanyValue()
        {
            bool status = false;
            try
            {
                tbl_genCompanyInfo com = tbl_genCompanyInfo.Select(clsSecurity.CompanyID);
                if (com != null)
                {
                    clsSecurity.CompanyName = clsCript.Decrypt(com.CompanyName);
                    clsSecurity.CompanyAddress1 = clsCript.Decrypt(com.Address);
                    clsSecurity.CompanyAddress2 = "";
                    if (com.Telephone1.Length > 0)
                        clsSecurity.CompanyAddress2 = "Tel:" + com.Telephone1;
                    if (com.Telephone2.Length > 0)
                        clsSecurity.CompanyAddress2 += "," + com.Telephone2;
                    if (com.Fax.Length > 0)
                        clsSecurity.CompanyAddress2 += "," + " FAX:" + com.Fax;
                    status = true;
                }
                else
                    MessageBox.Show("Company Not exist....!", "");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Network Connection Error....!");
                clsValidate.WriteErrorLog("", 0, ex);
            }
            return status;
        }

        #region Order by Data Grid
        public static void OrderBy_DataGrid(DataTable dt)
        {
            long i = 0;
            foreach (DataRow row in dt.Rows)
                row["LineNo"] = ++i;
        }

        public static void OrderBy_DataGrid(DataTable dt, string sSort1, string sSort2)
        {
            long i = 0;
            foreach (DataRow row in dt.Select().OrderBy(c => c[sSort1]).ThenBy(c => c[sSort2]))
                row["LineNo"] = ++i;
        }

        #endregion

        #region Get Enum Description
        public static List<string> GetEnumDescription_List(Type enumType)
        {
            List<string> lPeriod = new List<string>();

            foreach (var record in Enum.GetValues(enumType).Cast<Enum>().Select(value => new
            {
                (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                value
            })
        .OrderBy(item => item.value)
        .ToList())
            {
                lPeriod.Add(record.Description);
            }
            return lPeriod;
        }

        public static string GetEnumDescription(Enum value)
        {
            // Get the Description attribute value for the enum value
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }


        #endregion

        #region Get Details from DB Tables
        private static string GenarateQuery(string table, string field, string Key, string value)
        {
            if (value != null && value != "" && value.Length > 0)
                return "select [" + field + "] from [" + table + "] where " + Key + "='" + value + "'";
            else
                return "";
        }

        public static string get_MonthName(string ID)
        {
            return DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_hrPeriod_Month", "month_Name", "month_ID", ID));
        }

        public static string get_FinishedGoodTransferNoteID(string ID)
        {
            return DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_prodTxFinishedGoodTransferNote", "fgtn_ID", "prodJob_ID", ID));
        }

        public static string get_FinishedGoodTransferNoteDate(string ID)
        {
            return DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_prodTxFinishedGoodTransferNote", "fgtn_Date", "prodJob_ID", ID));
        }

        public static string get_FinishedGoodTransferNoteUoM(string ID)
        {
            return DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_prodTxFinishedGoodTransferNote", "uom_ID", "prodJob_ID", ID));
        }

        public static string get_FinishedGoodTransferNoteQty(string ID)
        {
            return DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_prodTxFinishedGoodTransferNote", "fGoodQty", "prodJob_ID", ID));
        }
        #endregion

        #region Get Store ID From Section ID
        public static string GetStoreID_FromSectionID(string sSectionID)
        {
            string sStroreID = "default";
            tbl_genSectionMaster oSection = tbl_genSectionMaster.Select(sSectionID);
            if (oSection != null)
                sStroreID = oSection.Store_ID;

            return sStroreID;
        }
        #endregion

        #region Update Stock
        public static void UpdateStock(string sStoreID, string sItemID, decimal dQty)
        {
            tbl_genStore_Stock oStock = tbl_genStore_Stock.Select(sStoreID, sItemID, "default", "default", "default", "0", "0");
            if (oStock != null)
            {
                oStock.Qty += dQty;
                oStock.Update();
            }
            else
            {
                tbl_genStore_Stock oNewStoreStock = new tbl_genStore_Stock(sStoreID, sItemID, "default", "default", "default", "0", "0", dQty, 0, 0, 0, 0, 0, 0, 0);
                oNewStoreStock.Insert();
            }
        }
        #endregion

        #region Update Weighted Avarage Cost From At FGTN Acceptance Point 
        public static void Update_ItemFinanceCosts(string sFG_Item_ID, decimal dCurrent_UnitCost, decimal dCurrent_qty, decimal dPrevious_Updating_qty)
        {
            //Assume Every Item has an item finance recored
            //var vItmFin = tbl_genItemMaster_Finance.Select(sFG_Item_ID, "default", "default", "0", "0");
            var vItmFin = tbl_genItemMaster_Pricing.Select(sFG_Item_ID);

            #region Weight Avg Cost
            var vStores = tbl_genStore_Stock.SelectAllByItem_ID_ItemSubCategory_ID_ItemSubCategory2_ID_ItemSerialNo_ItemSerialNo2(sFG_Item_ID, "default", "default", "0", "0");
            if (vStores != null)
            {
                decimal dTotalCost = 0;
                decimal dQty = vStores.Sum(r => r.Qty);
                if (vItmFin != null)
                {
                    dTotalCost = dQty * vItmFin.WeightedAverageCostPrice;
                    dTotalCost -= dPrevious_Updating_qty * vItmFin.WeightedAverageCostPrice;
                    dTotalCost = dTotalCost < 0 ? 0 : dTotalCost;
                    dTotalCost += dCurrent_qty * dCurrent_UnitCost;
                    vItmFin.WeightedAverageCostPrice = decimal.Round(dTotalCost / (dQty + dCurrent_qty), 2);
                    vItmFin.Update();
                }
            }
            else
            {
                if (vItmFin != null)
                {
                    vItmFin.WeightedAverageCostPrice = decimal.Round(dCurrent_UnitCost, 2);
                    vItmFin.Update();
                }
            }
            #endregion
               
            if (vItmFin != null)
            {
                #region Highest Cost
                if (vItmFin.HighestPurchaseCostPrice < dCurrent_UnitCost)
                {
                    vItmFin.HighestPurchaseCostPrice = dCurrent_UnitCost;
                    vItmFin.Update();
                }
                #endregion

                #region Lowest Cost
                if (vItmFin.LowestPurchaseCostPrice == 0 || vItmFin.LowestPurchaseCostPrice > dCurrent_UnitCost)
                {
                    vItmFin.LowestPurchaseCostPrice = dCurrent_UnitCost;
                    vItmFin.Update();
                }
                #endregion
            }

        }
        #endregion

        #region Update Section Floor Stock
        public static void UpdateSectionFloorStock(string sSectionID, string sItemID, decimal dQty)
        {
            tbl_genSectionMaster oSection = tbl_genSectionMaster.Select(sSectionID);
            if (oSection != null)
            {
                UpdateStock(oSection.Store_ID, sItemID, dQty);
            }
        }
        #endregion

        #region Get Item Quantity in Customer Order from job
        public static decimal GetItemQtyInCO_FromJob(string sProdJob_ID, string sProdBatct_ID)
        {
            decimal dQty = 0.000m;
            tbl_prodTxBatch oBatch = tbl_prodTxBatch.Select(sProdBatct_ID);
            if (oBatch != null)
            {
                tbl_prodTxJobCard oBoM = tbl_prodTxJobCard.Select(oBatch.ProdJob_ID);
                if (oBoM != null)
                {
                    if (IsJobType_MakeToSupply(oBoM.JobType_ID))
                    {
                        dQty = 0;
                    }
                    else if (oBatch.CustomerOrder_ID != "default")
                    {
                        dQty = oBatch.CustomerOrder_Qty;
                    }
                }
            }
            return dQty;
        }


        public static decimal GetItemQty_FromCO(string sCO_ID, string sItem_ID_FG)
        {
            decimal dQty = 0.000m;
            tbl_sasCustomerOrder_Detail oCO_Detail_BoMItem = tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(sCO_ID).FirstOrDefault(r => r.Item_ID == sItem_ID_FG);
            if (oCO_Detail_BoMItem != null)
                dQty = oCO_Detail_BoMItem.Qty;

            return dQty;
        }

        #endregion

        #region Production Transaction Data Returns
        public static decimal AlreadyRequestedQty_formMRs(string sBoM_No, string sBatch_No, string sItem_ID)
        {
            decimal dQty = 0;
            foreach (tbl_prodTxMaterialRequision_Material oMeterial in tbl_prodTxMaterialRequision_Material.SelectAllByProdBatch_ID(sBatch_No).Where(r => r.ProdJob_ID == sBoM_No && r.Item_ID == sItem_ID))
            {
                tbl_prodTxMaterialRequision oMR = tbl_prodTxMaterialRequision.Select(oMeterial.Mr_No);
                if (oMR != null && oMR.IsCanceled)
                    continue;

                dQty += oMeterial.Mr_Qty;
            }
            return dQty;
        }

        public static decimal AlreadyRequestedQty_formMRs(string sBoM_No, string sBatch_No, string sCurrent_MR_ID, string sItem_ID)
        {
            decimal dQty = 0;
            foreach (tbl_prodTxMaterialRequision_Material oMeterial in tbl_prodTxMaterialRequision_Material.SelectAllByProdBatch_ID(sBatch_No).Where(r => r.Mr_No != sCurrent_MR_ID && r.ProdJob_ID == sBoM_No && r.Item_ID == sItem_ID))
            {
                tbl_prodTxMaterialRequision oMR = tbl_prodTxMaterialRequision.Select(oMeterial.Mr_No);
                if (oMR != null && oMR.IsCanceled)
                    continue;

                dQty += oMeterial.Mr_Qty;
            }
            return dQty;
        }

        public static decimal AlreadyIssuedQty_formPGINs(string sBoM_No, string sBatch_No, string sItem_ID)
        {
            decimal dQty = 0;
            foreach (tbl_prodTxGoodIssueNote_Material oMeterial in tbl_prodTxGoodIssueNote_Material.SelectAllByProdJob_ID(sBoM_No).Where(r => r.ProdBatch_ID == sBatch_No && r.Item_ID == sItem_ID))
            {
                tbl_prodTxGoodIssueNote oPGIN = tbl_prodTxGoodIssueNote.Select(oMeterial.PGIN_No);
                if (oPGIN != null && oPGIN.IsCanceled)
                    continue;

                dQty += oMeterial.PGIN_Qty;
            }
            return dQty;
        }

        public static decimal AlreadyReturnedQty_formPGRNs(string sBoM_No, string sBatch_No, string sItem_ID)
        {
            decimal dQty = 0;
            foreach (tbl_prodTxGoodReturnNote oPGRN in tbl_prodTxGoodReturnNote.SelectAllByProdJob_ID(sBoM_No).Where(r => r.ProdBatch_ID == sBatch_No && !r.IsCanceled))
            {
                foreach (tbl_prodTxGoodReturnNote_Material oMeterial in tbl_prodTxGoodReturnNote_Material.SelectAllByPGRN_No(oPGRN.PGRN_No).Where(r => r.Item_ID == sItem_ID))
                    dQty += oMeterial.PGRN_Qty;
            }
            return dQty;
        }

        public static decimal AlreadyConsumedQty_formWIPs(string sBoM_No, string sBatch_No, string sItem_ID)
        {
            decimal dQty = 0;
            foreach (tbl_prodTxWorkInProgress oWIP in tbl_prodTxWorkInProgress.SelectAllByProdJob_ID(sBoM_No).Where(r => r.ProdBatch_ID == sBatch_No && !r.IsCanceled))
            {
                foreach (tbl_prodTxWorkInProgress_Material oMeterial in tbl_prodTxWorkInProgress_Material.SelectAllByWip_ID(oWIP.Wip_ID).Where(r => r.Item_ID == sItem_ID && !r.Is_Output))
                    dQty += oMeterial.InputOutput_Qty;
            }
            return dQty;
        }

        public static decimal AlreadyMadeFG_formWIPs(string sCurrentWIP_ID, string sBoM_No, string sBatch_No)
        {
            decimal dQty = 0;
            foreach (tbl_prodTxWorkInProgress oWIP in tbl_prodTxWorkInProgress.SelectAllByProdJob_ID(sBoM_No).Where(r => r.Wip_ID != sCurrentWIP_ID && r.ProdBatch_ID == sBatch_No && !r.IsCanceled))
            {
                foreach (tbl_prodTxWorkInProgress_Material oMeterial in tbl_prodTxWorkInProgress_Material.SelectAllByWip_ID(oWIP.Wip_ID).Where(r => r.Is_Output && r.Item_ID == oWIP.Item_ID_FG))
                    dQty += oMeterial.InputOutput_Qty;
            }
            return dQty;
        }

        public static decimal AlreadyIssuedQty_formFGTNs(string sBoM_No, string sBatch_No)
        {
            decimal dQty = 0;
            foreach (tbl_prodTxFinishedGoodTransferNote oFGTN in tbl_prodTxFinishedGoodTransferNote.SelectAllByProdJob_ID(sBoM_No).Where(r => r.ProdBatch_ID == sBatch_No && !r.IsCanceled))
            {
                dQty += oFGTN.FgtnQty;
            }
            return dQty;
        }

        public static decimal AlreadyAcceptedQty_fromFGTN_Accepatance(string sBatch_No)
        {
            decimal dValue = 0;

            foreach (tbl_prodTxFinishedGoodTransferAcceptance_Detail oDetail in tbl_prodTxFinishedGoodTransferAcceptance_Detail.SelectAllByProdBatch_ID(sBatch_No))
            {
                tbl_prodTxFinishedGoodTransferAcceptance oAcceptance = tbl_prodTxFinishedGoodTransferAcceptance.Select(oDetail.Acceptance_ID);
                if (!oAcceptance.IsCanceled)
                    dValue += oDetail.AcceptanceQty;
            }

            return dValue;
        }

        public static decimal AlreadyAcceptedQty_fromFGTN_Accepatance(string sBatch_No, string sFGTN_ID)
        {
            decimal dValue = 0;

            foreach (tbl_prodTxFinishedGoodTransferAcceptance_Detail oDetail in tbl_prodTxFinishedGoodTransferAcceptance_Detail.SelectAllByProdBatch_ID(sBatch_No).Where(r => r.Fgtn_ID == sFGTN_ID))
            {
                tbl_prodTxFinishedGoodTransferAcceptance oAcceptance = tbl_prodTxFinishedGoodTransferAcceptance.Select(oDetail.Acceptance_ID);
                if (!oAcceptance.IsCanceled)
                    dValue += oDetail.AcceptanceQty;
            }

            return dValue;
        }
        #endregion

        #region Get - Help Methods
        public static decimal Get_StoreStockBalance_Qty(string sIssuedStore_ID, string sItem_ID, string sJob_ID, string sItemCategorySub_ID, string sItemCategorySub_ID2, string sSerial1, string sSerial2)
        {
            return clsProcessMethods.Get_StoreStockBalance_Qty(sIssuedStore_ID, sItem_ID, "default", "default", "default", "0", "0");
        }

        public static decimal Get_FG_UnitCost_BoM(string sBoMId_ForSemiFG)
        {
            decimal dUnitPrice = 0;

            tbl_prodTxJobCard_CostFooter oFirstObj = null;
            foreach (var footer in tbl_prodTxJobCard_CostFooter.SelectAllByProdJob_ID(sBoMId_ForSemiFG).Where(p => p.Footer_ID == clsConfig.sItemUnitPrice_Production))
            {
                oFirstObj = footer;
                break;
            }

            if (oFirstObj != null)
                dUnitPrice = oFirstObj.Amount;

            return dUnitPrice;
        }

        public static decimal Get_SectionStockBalance_Qty(string sSection_ID, string sItemID, string sJobID, string sSubCategory1, string sSubCategory2, string sSerial1, string sSerial2)
        {
            decimal dQty = 0;
            tbl_genSectionMaster oSection = tbl_genSectionMaster.Select(sSection_ID);
            if (oSection != null)
            {
                dQty = Get_StoreStockBalance_Qty(oSection.Store_ID, sItemID, "default", sSubCategory1, "default", sSerial1, sSerial2);
            }
            return dQty;
        }

        public static DataTable Get_ItemGroupedItemFloorstockTable(DataTable dt_In, string sQtyColumnName, string sStore_ID)
        {
            return Get_ItemGroupedItemFloorstockTable(dt_In, "Item_ID", sQtyColumnName, sStore_ID);
        }

        public static DataTable Get_ItemGroupedItemFloorstockTable(DataTable dt_In, string sItemColumnName, string sQtyColumnName, string sStore_ID)
        {
            DataTable dtGroupedItem = new DataTable();
            dtGroupedItem.Columns.Add("Item_ID");
            dtGroupedItem.Columns.Add("Qty");
            dtGroupedItem.Columns.Add("IssuedQty");
            dtGroupedItem.Columns.Add("FloorQty");

            var newResults = from row in dt_In.AsEnumerable()
                             group row by new { ItemID = row.Field<string>(sItemColumnName) } into grp
                             select new
                             {
                                 Item_ID = grp.Key.ItemID,
                                 Quantity = grp.Sum((r) => decimal.Parse(r[sQtyColumnName].ToString())),
                                 FloorQuantity = clsHelpMethods_Prod.Get_StoreStockBalance_Qty(sStore_ID, grp.Key.ItemID, "default", clsGenaralName.getItemCategorySub_ID(grp.Key.ItemID), "default", "0", "0")
                             };

            foreach (var record in newResults)
                dtGroupedItem.Rows.Add(record.Item_ID, record.Quantity, 0, record.FloorQuantity);

            return dtGroupedItem;
        }

        public static DataTable Get_ItemGroupedItemFloorstockTable_FloorStockGetFromUI_Grid(DataTable dt_In, string sQtyColumnName, string sStore_ID)
        {
            DataTable dtGroupedItem = new DataTable();
            dtGroupedItem.Columns.Add("Item_ID");
            dtGroupedItem.Columns.Add("Qty");
            dtGroupedItem.Columns.Add("IssuedQty");
            dtGroupedItem.Columns.Add("FloorQty");

            var newResults = from row in dt_In.AsEnumerable()
                             group row by new { ItemID = row.Field<string>("Item_ID") } into grp
                             select new
                             {
                                 Item_ID = grp.Key.ItemID,
                                 Quantity = grp.Sum((r) => decimal.Parse(r[sQtyColumnName].ToString())),
                                 FloorQuantity = grp.Min((r) => clsValidation.Validate_DecimalNumber(r["ProdFloorQty"].ToString()))
                             };

            foreach (var record in newResults)
                dtGroupedItem.Rows.Add(record.Item_ID, record.Quantity, 0, record.FloorQuantity);

            return dtGroupedItem;
        }

        public static DataTable Get_ItemGroupedItemFloorstockTable_FloorStockGetFromUI_Grid(DataTable dt_In, string sStoreQtyColumnName, string sItemColumnName, string sQtyColumnName, string sStore_ID)
        {
            DataTable dtGroupedItem = new DataTable();
            dtGroupedItem.Columns.Add("Item_ID");
            dtGroupedItem.Columns.Add("Qty");
            dtGroupedItem.Columns.Add("IssuedQty");
            dtGroupedItem.Columns.Add("FloorQty");

            var newResults = from row in dt_In.AsEnumerable()
                             group row by new { ItemID = row.Field<string>(sItemColumnName) } into grp
                             select new
                             {
                                 Item_ID = grp.Key.ItemID,
                                 Quantity = grp.Sum((r) => decimal.Parse(r[sQtyColumnName].ToString())),
                                 FloorQuantity = Get_StoreStockBalance_Qty(sStore_ID, grp.Key.ItemID, "default", "default", "default", "0", "0") ////FloorQuantity = grp.Min((r) => clsValidation.Validate_DecimalNumber(r[sStoreQtyColumnName].ToString()))
                             };

            foreach (var record in newResults)
                dtGroupedItem.Rows.Add(record.Item_ID, record.Quantity, 0, record.FloorQuantity);

            return dtGroupedItem;
        }

        public static DataTable Get_ItemGroupedItemFloorstockTable_FloorStockGetFromUI_Grid(DataTable dt_In, string sStoreQtyColumnName, string sItemColumnName, string sQtyColumnName, string sStore_ID, bool bWPG_GridData )
        {
            DataTable dtGroupedItem = new DataTable();
            dtGroupedItem.Columns.Add("Item_ID");
            dtGroupedItem.Columns.Add("Qty");
            dtGroupedItem.Columns.Add("IssuedQty");
            dtGroupedItem.Columns.Add("FloorQty");

            var newResults = from row in dt_In.AsEnumerable()
                group row by new { ItemID = row.Field<string>(sItemColumnName) } into grp
                select new
                {
                    Item_ID = grp.Key.ItemID,
                    Quantity = grp.Sum((r) => decimal.Parse(r[sQtyColumnName].ToString())),
                    FloorQuantity = grp.Min((r) => clsValidation.Validate_DecimalNumber(r[sStoreQtyColumnName].ToString()))
                };

            foreach (var record in newResults)
                dtGroupedItem.Rows.Add(record.Item_ID, record.Quantity, 0m, record.FloorQuantity);

            return dtGroupedItem;
        }


        public static decimal Get_TotalQtyofBatches_FromBoM(string sBoMID)
        {
            decimal dValue = 0;

            foreach (tbl_prodTxBatch oBatch in tbl_prodTxBatch.SelectAllByProdJob_ID(sBoMID).Where(r => !r.IsCanceled))
                dValue += oBatch.BatchQty;

            return dValue;
        }

        public static decimal Get_ProdBatchQty(string sBatchID)
        {
            decimal dValue = 0;

            tbl_prodTxBatch oBatch = tbl_prodTxBatch.Select(sBatchID);
            if (oBatch != null)
                dValue = oBatch.BatchQty;

            return dValue;
        }

        public static decimal Get_UnitCostWithoutTax_BoM(string sBoMID)
        {
            decimal dValue = 0;

            tbl_prodTxJobCard_CostFooter oCost = tbl_prodTxJobCard_CostFooter.SelectAllByProdJob_ID(sBoMID).Where(p => p.Footer_ID == clsConfig.sItemUnitPrice_Production).FirstOrDefault();
            if (oCost != null)
                dValue = oCost.Amount;

            return dValue;
        }

        public static decimal Get_RequiredMaterialQty(string sBoMID, string sMaterialID, decimal dFG_Qty)
        {
            decimal dQty = 0;

            foreach (tbl_prodTxJobCard_Material oMat in tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(sBoMID).Where(r => r.Item_ID == sMaterialID))
                dQty += (oMat.TotalInputQty * dFG_Qty);

            return dQty;
        }

        public static string Get_BoM_formFinishedGood(string sItem_FG)
        {
            string sProdJob_ID = "";
            tbl_prodTxJobCard oBoM = tbl_prodTxJobCard.SelectAllByItem_ID_FG(sItem_FG).LastOrDefault();
            if (oBoM != null)
                sProdJob_ID = oBoM.ProdJob_ID;

            return sProdJob_ID;
        }

        public static decimal Get_WIP_SF_UnitCost(tbl_prodTxJobCard_WIPFlow oWipFlow, string sBatch_ID)
        {
            decimal dUnitPrice = 0;

            if (oWipFlow.OutQty == 0) return dUnitPrice;

            foreach (tbl_prodTxJobCard_Material oBoM_Material in tbl_prodTxJobCard_Material.SelectAllByWipout_sf_Index(oWipFlow.Sf_Index))
            {
                if (oBoM_Material.IsSemiFinishItem)
                {
                    decimal dCost = Get_FG_UnitCost_BoM(Get_BoM_formFinishedGood(oBoM_Material.Item_ID));
                    if (dCost == 0)
                        dCost = Get_SOutItem_UnitCost(oBoM_Material.ProdJob_ID, oBoM_Material.Item_ID);

                    dUnitPrice += ((dCost * oBoM_Material.TotalInputQty) / oWipFlow.OutQty);
                }
                else
                {
                    //dUnitPrice += ((GetWeightedAvg_Unitprice(oBoM_Material.Item_ID) * oBoM_Material.TotalInputQty) / oWipFlow.OutQty);
                    var oBatchMatOption = Get_BatchSelected_Material(oBoM_Material.Line_No, oBoM_Material.Line_No_Sub1, oBoM_Material.ProdJob_ID, sBatch_ID);
                    dUnitPrice += ((Get_WeightedAvgCostPrice(oBatchMatOption.Item_ID) * oBatchMatOption.TotalInputQty) / oWipFlow.OutQty);
                }
            }

            foreach (tbl_prodTxJobCard_WIPFlow_Detail oWipFlowDetail in tbl_prodTxJobCard_WIPFlow_Detail.SelectAllBySf_Index(oWipFlow.Sf_Index))
            {
                tbl_prodTxJobCard_WIPFlow oSubWipFlow =
                    tbl_prodTxJobCard_WIPFlow.Select(oWipFlowDetail.Wipout_sf_Index);
                if (oSubWipFlow != null)
                {
                    dUnitPrice += (Get_WIP_SF_UnitCost(oSubWipFlow, sBatch_ID) * oSubWipFlow.OutQty) / oWipFlow.OutQty;
                }
            }
            return dUnitPrice;
        }

        public static decimal Get_FG_UnitCost(string sBatch_ID, ref decimal dFG_Qty, ref decimal dTotal_Cost)
        {
            decimal dUnitPrice = 0;

            decimal dTotal_Amt = 0;
            decimal dTotal_Qty = 0;

            tbl_prodTxBatch oBatch = tbl_prodTxBatch.Select(sBatch_ID);
            if (oBatch != null && (oBatch.BatchStatus == (int)prod_Batch_Status.Close || oBatch.BatchStatus == (int)prod_Batch_Status.Open))
            {
                foreach (tbl_prodTxWorkInProgress oWIP in tbl_prodTxWorkInProgress.SelectAllByProdBatch_ID(sBatch_ID).Where(r => !r.IsCanceled))
                {
                    foreach (tbl_prodTxWorkInProgress_Material oWIP_Detail in tbl_prodTxWorkInProgress_Material.SelectAllByItem_ID(oWIP.Item_ID_FG).Where(r => r.Wip_ID == oWIP.Wip_ID))
                    {
                        dTotal_Amt += oWIP_Detail.TotalAmount;
                        dTotal_Qty += oWIP_Detail.InputOutput_Qty;
                    }
                }
            }
            dFG_Qty = dTotal_Qty;
            dTotal_Cost = dTotal_Amt;
            if (dTotal_Qty > 0)
                dUnitPrice = dTotal_Amt / dTotal_Qty;

            return dUnitPrice;
        }

        public static decimal Get_SOutItem_UnitCost(string sBoM_ID, string sSubOutItem_ID)
        {
            decimal dUnitCost = 0;
            tbl_prodTxJobCard_Material oSout_Item = tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(sBoM_ID).Where(r => r.IsSemiFinishItem && r.Item_ID == sSubOutItem_ID).FirstOrDefault();
            if (oSout_Item != null)
            {
                foreach (tbl_prodTxJobCard_Material oItm in tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(sBoM_ID).Where(r => r.Line_No == oSout_Item.Line_No && r.Line_No_Sub1 != 0 && r.Line_No_Sub2 == 0))
                {
                    dUnitCost += oItm.TotalInputQty * Get_WeightedAvgCostPrice(oItm.Item_ID);
                }
            }

            foreach (tbl_prodTxSubContractInNote oSubIn in tbl_prodTxSubContractInNote.SelectAllByProdJob_ID(sBoM_ID).Where(r => r.SemiFG_item_ID == sSubOutItem_ID && !r.IsCanceled))
            {
                dUnitCost += oSubIn.Supplier_Rate;
                break;
            }

            return dUnitCost;
        }

        public static decimal Get_FloorQty_WIP_SemiFGs(string sBoMID, string sBatchID, string sItemID, string sSectionID)
        {
            decimal dInQty = 0;
            decimal dOutQty = 0;

            foreach (tbl_prodTxWorkInProgress_Material oWIP_SF in tbl_prodTxWorkInProgress_Material.SelectAllByItem_ID(sItemID).Where(r => r.Is_Output && r.Output_Section_ID == sSectionID))
            {
                tbl_prodTxWorkInProgress oWIP = tbl_prodTxWorkInProgress.Select(oWIP_SF.Wip_ID);
                if (oWIP != null && oWIP.ProdJob_ID == sBoMID && !oWIP.IsCanceled && oWIP.ProdBatch_ID == sBatchID)
                    dInQty += oWIP_SF.InputOutput_Qty;
            }

            foreach (tbl_prodTxWorkInProgress_Material oWIP_SF in tbl_prodTxWorkInProgress_Material.SelectAllByItem_ID(sItemID).Where(r => !r.Is_Output))
            {
                tbl_prodTxWorkInProgress oWIP = tbl_prodTxWorkInProgress.Select(oWIP_SF.Wip_ID);
                if (oWIP != null && oWIP.ProdJob_ID == sBoMID && oWIP.Section_ID == sSectionID && !oWIP.IsCanceled && oWIP.ProdBatch_ID == sBatchID)
                    dOutQty += oWIP_SF.InputOutput_Qty;
            }

            foreach (tbl_prodTxSubContractOutNote_Material oSout_Mat in tbl_prodTxSubContractOutNote_Material.SelectAllByItem_ID(sItemID))
            {
                tbl_prodTxSubContractOutNote oSout = tbl_prodTxSubContractOutNote.Select(oSout_Mat.SubOut_ID);
                if (oSout != null && oSout_Mat.ProdJob_ID == sBoMID && oSout_Mat.ProdBatch_ID == sBatchID && oSout.Release_Section_ID == sSectionID && !oSout.IsCanceled)
                    dOutQty += oSout_Mat.Son_Qty;
            }

            return (dInQty - dOutQty) > 0 ? (dInQty - dOutQty) : 0;
        }

        public static List<tbl_prodTxJobCard_Material> Get_SubstituteMaterials(int iMainLine, int iSubLine_1, string sBoMID)
        {
            List<tbl_prodTxJobCard_Material> lstMats = new List<tbl_prodTxJobCard_Material>();
            foreach (tbl_prodTxJobCard_Material oSubstitue_Mat in tbl_prodTxJobCard_Material.SelectAllByProdJob_ID(sBoMID).
                Where(r1 => r1.Line_No == iMainLine && r1.Line_No_Sub1 == iSubLine_1))
            {
                lstMats.Add(oSubstitue_Mat);
            }
            return lstMats;
        }

        public static tbl_prodTxBatch_Material Get_BatchSelected_Material(int iLineNo, int iLineNo_sub1, string BoM_ID, string sBatch_ID)
        {
            tbl_prodTxBatch_Material oBatch_Mat = tbl_prodTxBatch_Material.SelectAllByProdBatch_ID(sBatch_ID)
                .Where(r => r.Line_No == iLineNo && r.Line_No_Sub1 == iLineNo_sub1 && r.ProdJob_ID == BoM_ID && r.IsSelected).FirstOrDefault();
            return oBatch_Mat;
        }

        public static int Get_BatchCount_ForBoM(string sBoMID)
        {
            var vBatches = tbl_prodTxBatch.SelectAllByProdJob_ID(sBoMID).Where(r => !r.IsCanceled);
            return vBatches.Count();
        }

        public static decimal Get_WeightedAvgCostPrice(tbl_genItemMaster oItem)
        {
            decimal dUnitCost = 0;
            tbl_genItemMaster_Pricing oItem_Finance = tbl_genItemMaster_Pricing.Select((oItem != null ? oItem.Item_ID : "default"));
            if (oItem_Finance != null)
            {
                dUnitCost = oItem_Finance.WeightedAverageCostPrice;
            }

            return dUnitCost;
        }

        public static decimal Get_WeightedAvgCostPrice(string sItemId)
        {
            decimal dUnitCost = 0;

            tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemId);
            if (oItem != null)
            {
                tbl_genItemMaster_Pricing oItemFinance = tbl_genItemMaster_Pricing.Select(oItem.Item_ID);
                if (oItemFinance != null)
                    dUnitCost = oItemFinance.WeightedAverageCostPrice;
            }

            return dUnitCost;
        }

        public static decimal Get_ProdCostCenterSMV_Cost(string sBoM_ID, string sCostCenter_ID)
        {
            decimal dValue = 0;
            tbl_prodTxJobCard_CostCenter oProdCostCenter = tbl_prodTxJobCard_CostCenter.SelectAllByProdJob_ID(sBoM_ID).Where(r => r.Cost_Center_ID == sCostCenter_ID).FirstOrDefault();
            if (oProdCostCenter != null)
            {
                dValue = oProdCostCenter.Cost;
            }
            return dValue;
        }

        #endregion

        #region Validation Methods

        public static bool CheckItemFloorStockTable(DataTable dtItemFloorStock)
        {
            bool bValidate = true;
            foreach (DataRow dr in dtItemFloorStock.Rows)
            {
                string sItem_ID = clsValidate.ValidateRowValue(dr, "Item_ID", "default");
                decimal dQty = clsValidate.ValidateRowValue(dr, "Qty", 0m);
                decimal dIssuedQty = clsValidate.ValidateRowValue(dr, "IssuedQty", 0m);
                decimal dFloorQty = clsValidate.ValidateRowValue(dr, "FloorQty", 0m);

                if ((dFloorQty + dIssuedQty) < dQty)
                {
                    bValidate = false;
                    SEACCMessageBox.Show("Not Enough Floor Qty..!", "Item ID : " + sItem_ID + "\nItem Name : " + clsGenaralName.getName_Item(sItem_ID) + "", MessageBoxButton.OK, "Red");
                    break;
                }
            }

            return bValidate;
        }

        public static bool IsJobType_MakeToSupply(string sJobTypeID)
        {
            bool isMTS = false;
            if (sJobTypeID == "PJT/002")
                isMTS = true;

            return isMTS;
        }

        public static bool IsJobType_MakeToOder(string sJobTypeID)
        {
            bool isMTO = false;
            if (sJobTypeID == "PJT/001")
                isMTO = true;

            return isMTO;
        }

        public static bool IsProdJobBoM_MakeToSupply(string sBoM_No)
        {
            bool isMTS = false;
            tbl_prodTxJobCard oProdJobBoM = tbl_prodTxJobCard.Select(sBoM_No);
            if (oProdJobBoM != null)
                isMTS = IsJobType_MakeToSupply(oProdJobBoM.JobType_ID);

            return isMTS;
        }
        #endregion

        #region Print Count Update
        public static void PrintCount_Update(FormName enmFormName, enum_ReportName enmReportName, string sTransactionID, ref bool bDuplicateCopy, ref int iDuplcateCopyCount)
        {
            tbl_securityFunctionMaster dForm = tbl_securityFunctionMaster.Select((int)enmFormName);
            tbl_securityFunctionMaster_Report dReport = tbl_securityFunctionMaster_Report.Select((int)enmReportName);
            if (dForm != null && dReport != null)
            {
                tbl_securityUserActivity oUserActivity = tbl_securityUserActivity.Select(dForm.Function_ID, dReport.Function_ID, sTransactionID);
                if (oUserActivity != null)
                {
                    if (oUserActivity.PrintCount > 0)
                    {
                        bDuplicateCopy = true;
                        iDuplcateCopyCount = oUserActivity.PrintCount;

                        oUserActivity.PrintCount++;
                        oUserActivity.Update();
                    }
                }
                else
                {
                    tbl_securityUserActivity oInsert = new tbl_securityUserActivity((int)enmFormName, (int)enmReportName, sTransactionID, 1, clsSecurity.UserIDLoged, clsSecurity.TerminalID, clsSecurity.getServerDateTime());
                    oInsert.Insert();
                }
            }
        } 
        #endregion
    }
}
