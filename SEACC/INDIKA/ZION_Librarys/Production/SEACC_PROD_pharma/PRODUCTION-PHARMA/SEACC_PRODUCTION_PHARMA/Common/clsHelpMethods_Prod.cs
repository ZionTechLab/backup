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

namespace SEACC_PRODUCTION_PHARMA.Common
{
    public class clsHelpMethods_Prod
    {
        #region Format Date and Time
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

        #region Order by Data Grid
        public static void OrderBy_DataGrid(DataTable dt)
        {
            int i = 0;
            foreach (DataRow row in dt.Rows)
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

        private static string GenarateQuery(string table, string field, string Key, string value)
        {
            if (!string.IsNullOrEmpty(value) && value.Length > 0)
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
            return DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_prod_pharmaTxFinishedGoodTransferNote", "fgtn_ID", "prodJob_ID", ID));
        }

        public static string get_FinishedGoodTransferNoteDate(string ID)
        {
            return DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_prod_pharmaTxFinishedGoodTransferNote", "fgtn_Date", "prodJob_ID", ID));
        }

        public static string get_FinishedGoodTransferNoteUoM(string ID)
        {
            return DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_prod_pharmaTxFinishedGoodTransferNote", "uom_ID", "prodJob_ID", ID));
        }

        public static string get_FinishedGoodTransferNoteQty(string ID)
        {
            return DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_prod_pharmaTxFinishedGoodTransferNote", "fGoodQty", "prodJob_ID", ID));
        }

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
            tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemID);
            tbl_genStore_Stock oStock = tbl_genStore_Stock.Select(sStoreID, sItemID, "default", oItem != null ? oItem.ItemCategorySub_ID : "default", "default", "0", "0");
            if (oStock != null)
            {
                oStock.Qty += dQty;
                oStock.Update();
            }
            else
            {
                tbl_genStore_Stock oNewStoreStock = new tbl_genStore_Stock(sStoreID, sItemID, "default", oItem != null ? oItem.ItemCategorySub_ID : "default", "default", "0", "0", dQty, 0, 0, 0, 0, 0, 0, 0);
                oNewStoreStock.Insert();
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
            tbl_prod_pharmaTxBatch oBatch = tbl_prod_pharmaTxBatch.Select(sProdBatct_ID);
            if (oBatch != null)
            {
                tbl_prod_pharmaTxJobCard oBoM = tbl_prod_pharmaTxJobCard.Select(oBatch.ProdJob_ID);
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

        public static decimal DataGrid_EditedQuantity_Validation(decimal dEnteredQty, decimal dPreviousQty, decimal dBase_Qty, decimal dValidity_Pecentage)
        {
            if (dEnteredQty == 0)
            {
                return 0;
            }
            else if (dValidity_Pecentage < 0)
            {
                return dEnteredQty;
            }
            else
            {
                decimal dMargin_Qty = Math.Round(dBase_Qty * dValidity_Pecentage / 100, clsConfig.sDecimalPlaces_Quantity);
                if ((dEnteredQty + dPreviousQty) <= (dBase_Qty + dMargin_Qty) && (dEnteredQty + dPreviousQty) >= ((dBase_Qty - dMargin_Qty)))
                {
                    return dEnteredQty;
                }
                else
                {
                    decimal dLowerMargin = (dBase_Qty - dMargin_Qty) - dPreviousQty;
                    decimal dUpperMargin = (dBase_Qty + dMargin_Qty) - dPreviousQty;

                    SEACCMessageBox.Show("Not Valid Qty...!", "Please Enter a valid quantity between "
                        + cls_Formater.FormatDecimal(dLowerMargin < 0 ? 0 : dLowerMargin, clsConfig.sDecimalPlaces_Quantity)
                        + " and "
                        + cls_Formater.FormatDecimal(dUpperMargin < 0 ? 0 : dUpperMargin, clsConfig.sDecimalPlaces_Quantity)
                        , MessageBoxButton.OK, "Red");

                    if ((dEnteredQty + dPreviousQty) > (dBase_Qty + dMargin_Qty))
                        return dUpperMargin < 0 ? 0 : dUpperMargin;
                    else if ((dEnteredQty + dPreviousQty) < (dBase_Qty - dMargin_Qty))
                        return dLowerMargin < 0 ? 0 : dLowerMargin;
                    else
                        return 0;
                }
            }
        }

        public static decimal AlreadyRequestedQty_formMRs(string sBoM_No, string sBatch_No, string sItem_ID, string sSection_ID)
        {
            decimal dQty = 0;
            foreach (tbl_prod_pharmaTxMaterialRequision_Material oMeterial in tbl_prod_pharmaTxMaterialRequision_Material.SelectAllByProdBatch_ID(sBatch_No).Where(r => r.ProdJob_ID == sBoM_No && r.Item_ID == sItem_ID))
            {
                tbl_prod_pharmaTxMaterialRequision oMR = tbl_prod_pharmaTxMaterialRequision.Select(oMeterial.Mr_No);
                if (oMR != null && !oMR.IsCanceled && oMR.Section_ID == sSection_ID)
                {
                    dQty += oMeterial.Mr_Qty;
                }
            }
            return dQty;
        }

        public static decimal AlreadyRequestedQty_formMRs(string sBoM_No, string sBatch_No, string sCurrent_MR_ID, string sItem_ID, string sSection_ID)
        {
            decimal dQty = 0;
            foreach (tbl_prod_pharmaTxMaterialRequision_Material oMeterial in tbl_prod_pharmaTxMaterialRequision_Material.SelectAllByProdBatch_ID(sBatch_No).Where(r => r.Mr_No != sCurrent_MR_ID && r.ProdJob_ID == sBoM_No && r.Item_ID == sItem_ID))
            {
                tbl_prod_pharmaTxMaterialRequision oMR = tbl_prod_pharmaTxMaterialRequision.Select(oMeterial.Mr_No);
                if (oMR != null && oMR.IsCanceled && oMR.Section_ID == sSection_ID)
                {
                    dQty += oMeterial.Mr_Qty;
                }
            }
            return dQty;
        }

        public static decimal AlreadyIssuedQty_formPGINs(string sBoM_No, string sBatch_No, string sItem_ID)
        {
            decimal dQty = 0;
            foreach (tbl_prod_pharmaTxGoodIssueNote_Material oMeterial in tbl_prod_pharmaTxGoodIssueNote_Material.SelectAllByProdJob_ID(sBoM_No).Where(r => r.ProdBatch_ID == sBatch_No && r.Item_ID == sItem_ID))
            {
                tbl_prod_pharmaTxGoodIssueNote oPGIN = tbl_prod_pharmaTxGoodIssueNote.Select(oMeterial.PGIN_No);
                if (oPGIN != null && oPGIN.IsCanceled)
                    continue;

                dQty += oMeterial.PGIN_Qty;
            }
            return dQty;
        }

        public static decimal AlreadyIssuedQty_formPGINs(string sBoM_No, string sBatch_No, string sItem_ID, DateTime dtmAsAtTime)
        {
            decimal dQty = 0;
            foreach (tbl_prod_pharmaTxGoodIssueNote_Material oMeterial in tbl_prod_pharmaTxGoodIssueNote_Material.SelectAllByProdJob_ID(sBoM_No).Where(r => r.ProdBatch_ID == sBatch_No && r.Item_ID == sItem_ID))
            {
                tbl_prod_pharmaTxGoodIssueNote oPGIN = tbl_prod_pharmaTxGoodIssueNote.Select(oMeterial.PGIN_No);
                if (oPGIN != null && oPGIN.IsCanceled)
                    continue;
                if (oPGIN != null && oPGIN.DateCreate > dtmAsAtTime)
                    continue;

                dQty += oMeterial.PGIN_Qty;
            }
            return dQty;
        }

        public static decimal AlreadyReturnedQty_formPGRNs(string sBoM_No, string sBatch_No, string sItem_ID)
        {
            decimal dQty = 0;
            foreach (tbl_prod_pharmaTxGoodReturnNote oPGRN in tbl_prod_pharmaTxGoodReturnNote.SelectAllByProdJob_ID(sBoM_No).Where(r => r.ProdBatch_ID == sBatch_No && !r.IsCanceled))
            {
                foreach (tbl_prod_pharmaTxGoodReturnNote_Material oMeterial in tbl_prod_pharmaTxGoodReturnNote_Material.SelectAllByPGRN_No(oPGRN.PGRN_No).Where(r => r.Item_ID == sItem_ID))
                    dQty += oMeterial.PGRN_Qty;
            }
            return dQty;
        }

        public static decimal AlreadyConsumedQty_formWIPs(string sBoM_No, string sBatch_No, string sItem_ID)
        {
            decimal dQty = 0;
            foreach (tbl_prod_pharmaTxWorkInProgress oWIP in tbl_prod_pharmaTxWorkInProgress.SelectAllByProdJob_ID(sBoM_No).Where(r => r.ProdBatch_ID == sBatch_No && !r.IsCanceled))
            {
                foreach (tbl_prod_pharmaTxWorkInProgress_Material oMeterial in tbl_prod_pharmaTxWorkInProgress_Material.SelectAllByWip_ID(oWIP.Wip_ID).Where(r => r.Item_ID == sItem_ID && !r.Is_Output))
                    dQty += oMeterial.InputOutput_Qty;
            }
            return dQty;
        }

        public static decimal AlreadyMadeFG_formWIPs(string sBoM_No, string sBatch_No)
        {
            decimal dQty = 0;
            foreach (tbl_prod_pharmaTxWorkInProgress oWIP in tbl_prod_pharmaTxWorkInProgress.SelectAllByProdJob_ID(sBoM_No).Where(r => r.ProdBatch_ID == sBatch_No && !r.IsCanceled))
            {
                foreach (tbl_prod_pharmaTxWorkInProgress_Material oMeterial in tbl_prod_pharmaTxWorkInProgress_Material.SelectAllByWip_ID(oWIP.Wip_ID).Where(r => r.Is_Output && r.Item_ID == oWIP.Item_ID_FG))
                    dQty += oMeterial.InputOutput_Qty;
            }
            return dQty;
        }

        public static decimal AlreadyIssuedQty_formFGTNs(string sBoM_No, string sBatch_No)
        {
            decimal dQty = 0;
            foreach (tbl_prod_pharmaTxFinishedGoodTransferNote oFGTN in tbl_prod_pharmaTxFinishedGoodTransferNote.SelectAllByProdJob_ID(sBoM_No).Where(r => r.ProdBatch_ID == sBatch_No && !r.IsCanceled))
            {
                dQty += oFGTN.FgtnQty;
            }
            return dQty;
        }

        public static decimal AlreadyMadeFG_formWIPs(string sCurrentWIP_ID, string sBoM_No, string sBatch_No)
        {
            decimal dQty = 0;
            foreach (tbl_prod_pharmaTxWorkInProgress oWIP in tbl_prod_pharmaTxWorkInProgress.SelectAllByProdJob_ID(sBoM_No).Where(r => r.Wip_ID != sCurrentWIP_ID && r.ProdBatch_ID == sBatch_No && !r.IsCanceled))
            {
                foreach (tbl_prod_pharmaTxWorkInProgress_Material oMeterial in tbl_prod_pharmaTxWorkInProgress_Material.SelectAllByWip_ID(oWIP.Wip_ID).Where(r => r.Is_Output && r.Item_ID == oWIP.Item_ID_FG))
                    dQty += oMeterial.InputOutput_Qty;
            }
            return dQty;
        }

        public static decimal AlreadyMadeSemiFG_fromWIPs(string sCurrentWIP_ID, string sBoM_No, string sBatch_No, string sActivity_No, string sItem_ID)
        {
            decimal dQty = 0;
            foreach (tbl_prod_pharmaTxWorkInProgress oWIP in tbl_prod_pharmaTxWorkInProgress.SelectAllByProdJob_ID(sBoM_No).Where(r => r.Wip_ID != sCurrentWIP_ID && r.ProdBatch_ID == sBatch_No && r.Activity_ID == sActivity_No && !r.IsCanceled))
            {
                foreach (tbl_prod_pharmaTxWorkInProgress_Material oWIP_Detail in tbl_prod_pharmaTxWorkInProgress_Material.SelectAllByWip_ID(oWIP.Wip_ID).Where(r => r.Item_ID == sItem_ID && r.Is_Output))
                {
                    dQty += oWIP_Detail.InputOutput_Qty;
                }
            }

            return dQty;
        }

        public static bool IsJobType_MakeToSupply(string sJobTypeID)
        {
            bool isMTS = false;
            if (sJobTypeID == "PJT/002")
                isMTS = true;

            return isMTS;
        }

        public static bool IsProdJobBoM_MakeToSupply(string sBoM_No)
        {
            bool isMTS = false;
            tbl_prod_pharmaTxJobCard oProdJobBoM = tbl_prod_pharmaTxJobCard.Select(sBoM_No);
            if (oProdJobBoM != null)
                isMTS = IsJobType_MakeToSupply(oProdJobBoM.JobType_ID);

            return isMTS;
        }

        public static decimal Get_SectionStockBalance_Qty(string sSection_ID, string sItemID)
        {
            decimal dQty = 0;
            tbl_genSectionMaster oSection = tbl_genSectionMaster.Select(sSection_ID);
            if (oSection != null)
            {
                dQty = clsProcessMethods.Get_StoreStockBalance_Qty(oSection.Store_ID, sItemID, "default", "default", "default", "0", "0");
            }
            return dQty;
        }

        public static decimal Get_StoreStockBalance_Qty(string sStore_ID, string sItemID)
        {
            return clsProcessMethods.Get_StoreStockBalance_Qty(sStore_ID, sItemID, "default", "default", "default", "0", "0");
        }

        public static DataTable GetItemGroupedItemFloorstockTable(DataTable dt_In, string sQtyColumnName, string sStore_ID)
        {
            return GetItemGroupedItemFloorstockTable(dt_In, "Item_ID", sQtyColumnName, sStore_ID);
        }

        public static DataTable GetItemGroupedItemFloorstockTable(DataTable dt_In, string sItemColumnName, string sQtyColumnName, string sStore_ID)
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
                                 FloorQuantity = clsHelpMethods_Prod.Get_StoreStockBalance_Qty(sStore_ID, grp.Key.ItemID)
                             };

            foreach (var record in newResults)
                dtGroupedItem.Rows.Add(record.Item_ID, record.Quantity, 0, record.FloorQuantity);

            return dtGroupedItem;
        }

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

        public static decimal GetTotalQtyofBatches_FromBoM(string sBoMID, DateTime dtmCurrentBatch_CreateTime)
        {
            decimal dValue = 0;

            foreach (tbl_prod_pharmaTxBatch oBatch in tbl_prod_pharmaTxBatch.SelectAllByProdJob_ID(sBoMID).Where(r => r.DateCreate < dtmCurrentBatch_CreateTime && !r.IsCanceled))
                dValue += oBatch.BatchQty;

            return dValue;
        }

        public static decimal GetProdBatchQty(string sBatchID)
        {
            decimal dValue = 0;

            tbl_prod_pharmaTxBatch oBatch = tbl_prod_pharmaTxBatch.Select(sBatchID);
            if (oBatch != null)
                dValue = oBatch.BatchQty;

            return dValue;
        }

        public static decimal GetProdBoMQty(string sBoMID)
        {
            decimal dValue = 0;

            tbl_prod_pharmaTxJobCard oBoM = tbl_prod_pharmaTxJobCard.Select(sBoMID);
            if (oBoM != null)
                dValue = oBoM.FGoodQty;

            return dValue;
        }

        public static decimal GetUnitCostWithoutTax_BoM(string sBoMID)
        {
            decimal dValue = 0;

            tbl_prod_pharmaTxJobCard_CostFooter oCost = tbl_prod_pharmaTxJobCard_CostFooter.SelectAllByProdJob_ID(sBoMID).Where(p => p.Footer_ID == clsConfig.sItemUnitPrice_Production).FirstOrDefault();
            if (oCost != null)
                dValue = oCost.Amount;

            return dValue;
        }

        public static decimal GetRequiredMaterialQty(string sBoMID, string sMaterialID, decimal dFG_Qty)
        {
            decimal dQty = 0;

            foreach (tbl_prod_pharmaTxJobCard_Material oMat in tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(sBoMID).Where(r => r.Item_ID == sMaterialID))
                dQty += (oMat.TotalInputQty * dFG_Qty);

            return dQty;
        }

        public static string GetBoM_formFinishedGood(string sItem_FG)
        {
            string sProdJob_ID = "";
            tbl_prod_pharmaTxJobCard oBoM = tbl_prod_pharmaTxJobCard.SelectAllByItem_ID_FG(sItem_FG).LastOrDefault();
            if (oBoM != null)
                sProdJob_ID = oBoM.ProdJob_ID;

            return sProdJob_ID;
        }

        public static decimal AlreadyAcceptedQty_fromFGTN_Accepatance(string sBatch_No)
        {
            decimal dValue = 0;

            foreach (tbl_prod_pharmaTxFinishedGoodTransferAcceptance oAcceptance in tbl_prod_pharmaTxFinishedGoodTransferAcceptance.SelectAllByProdBatch_ID(sBatch_No).Where(r => !r.IsCanceled))
            {
                dValue += oAcceptance.AcceptanceQty;
            }

            return dValue;
        }

        public static decimal GetWeightedAvgCostPrice(string sItemId)
        {
            decimal dUnitPrice = 0;

            tbl_genItemMaster oItem = tbl_genItemMaster.Select(sItemId);
            if (oItem != null)
            {
                tbl_genItemMaster_Pricing oItemFinance = tbl_genItemMaster_Pricing.Select(oItem.Item_ID);
                if (oItemFinance != null)
                    dUnitPrice = oItemFinance.WeightedAverageCostPrice;
            }

            return dUnitPrice;
        }

        public static decimal GetWeightedAvgCostPrice(tbl_genItemMaster oItem)
        {
            decimal dUnitPrice = 0;
            if (oItem != null)
            {
                tbl_genItemMaster_Pricing oItemFinance = tbl_genItemMaster_Pricing.Select(oItem.Item_ID);
                if (oItemFinance != null)
                    dUnitPrice = oItemFinance.WeightedAverageCostPrice;
            }

            return dUnitPrice;
        }

        public static decimal Get_WIP_SF_UnitCost(tbl_prod_pharmaTxJobCard_WIPFlow oWipFlow, string sBatch_ID)
        {
            decimal dUnitPrice = 0;

            if (oWipFlow.OutQty == 0) return dUnitPrice;

            foreach (tbl_prod_pharmaTxJobCard_Material oBoM_Material in tbl_prod_pharmaTxJobCard_Material.SelectAllByWipout_sf_Index(oWipFlow.Sf_Index))
            {
                if (oBoM_Material.IsSemiFinishItem)
                {
                    decimal dCost = Get_FG_UnitCost_BoM(GetBoM_formFinishedGood(oBoM_Material.Item_ID));
                    if (dCost == 0)
                        dCost = Get_SOutItem_UnitCost(oBoM_Material.ProdJob_ID, oBoM_Material.Item_ID);

                    dUnitPrice += Math.Round(((dCost * oBoM_Material.TotalInputQty) / oWipFlow.OutQty), 2);
                }
                else
                {
                    var oBatchMatOption = GetBatchSelected_Material(oBoM_Material.Line_No, oBoM_Material.Line_No_Sub1, oBoM_Material.ProdJob_ID, sBatch_ID);
                    dUnitPrice += Math.Round(((GetWeightedAvgCostPrice(oBatchMatOption.Item_ID) * oBatchMatOption.TotalInputQty) / oWipFlow.OutQty), 2);
                }
            }

            foreach (tbl_prod_pharmaTxJobCard_WIPFlow_Detail oWipFlowDetail in tbl_prod_pharmaTxJobCard_WIPFlow_Detail.SelectAllBySf_Index(oWipFlow.Sf_Index))
            {
                tbl_prod_pharmaTxJobCard_WIPFlow oSubWipFlow =
                    tbl_prod_pharmaTxJobCard_WIPFlow.Select(oWipFlowDetail.Wipout_sf_Index);
                if (oSubWipFlow != null)
                {
                    dUnitPrice += Math.Round((Get_WIP_SF_UnitCost(oSubWipFlow, sBatch_ID) * oSubWipFlow.OutQty) / oWipFlow.OutQty, 2);
                }
            }

            return dUnitPrice;
        }

        public static tbl_prod_pharmaTxBatch_Material GetBatchSelected_Material(int iLineNo, int iLineNo_sub1, string BoM_ID, string sBatch_ID)
        {
            tbl_prod_pharmaTxBatch_Material oBatch_Mat = tbl_prod_pharmaTxBatch_Material.SelectAllByProdBatch_ID(sBatch_ID)
                .Where(r => r.Line_No == iLineNo && r.Line_No_Sub1 == iLineNo_sub1 && r.ProdJob_ID == BoM_ID && r.IsSelected).FirstOrDefault();
            return oBatch_Mat;
        }

        public static decimal Get_FG_UnitCost(string sBatch_ID, ref decimal dFG_Qty, ref decimal dTotal_Cost)
        {
            decimal dUnitPrice = 0;

            decimal dTotal_Amt = 0;
            decimal dTotal_Qty = 0;

            tbl_prod_pharmaTxBatch oBatch = tbl_prod_pharmaTxBatch.Select(sBatch_ID);
            if (oBatch != null && (oBatch.BatchStatus == (int)prod_Batch_Status.Close || oBatch.BatchStatus == (int)prod_Batch_Status.Open))
            {
                foreach (tbl_prod_pharmaTxWorkInProgress oWIP in tbl_prod_pharmaTxWorkInProgress.SelectAllByProdBatch_ID(sBatch_ID).Where(r => !r.IsCanceled))
                {
                    foreach (tbl_prod_pharmaTxWorkInProgress_Material oWIP_Detail in tbl_prod_pharmaTxWorkInProgress_Material.SelectAllByItem_ID(oWIP.Item_ID_FG).Where(r => r.Wip_ID == oWIP.Wip_ID))
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
            tbl_prod_pharmaTxJobCard_Material oSout_Item = tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(sBoM_ID).Where(r => r.IsSemiFinishItem && r.Item_ID == sSubOutItem_ID).FirstOrDefault();
            if (oSout_Item != null)
            {
                foreach (tbl_prod_pharmaTxJobCard_Material oItm in tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(sBoM_ID).Where(r => r.Line_No == oSout_Item.Line_No && r.Line_No_Sub1 != 0 && r.Line_No_Sub2 == 0))
                {
                    dUnitCost += oItm.TotalInputQty * GetWeightedAvgCostPrice(oItm.Item_ID);
                }
            }

            foreach (tbl_prod_pharmaTxSubContractInNote oSubIn in tbl_prod_pharmaTxSubContractInNote.SelectAllByProdJob_ID(sBoM_ID).Where(r => r.SemiFG_item_ID == sSubOutItem_ID && !r.IsCanceled))
            {
                dUnitCost += oSubIn.Supplier_Rate;
                break;
            }

            return dUnitCost;
        }

        public static int BatchCount_ForBoM(string sBoMID)
        {
            var vBatches = tbl_prod_pharmaTxBatch.SelectAllByProdJob_ID(sBoMID).Where(r => !r.IsCanceled);
            return vBatches.Count();
        }

        #region Update Weighted Avarage Cost From At FGTN Acceptance Point 
        public static void Update_ItemFinanceCosts(string sFG_Item_ID, decimal dCurrent_UnitCost, decimal dCurrent_qty, decimal dPrevious_UnitCost, decimal dPrevious_Updating_qty)
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
                    if ((dQty - dPrevious_Updating_qty + dCurrent_qty) != 0)
                    {
                        dTotalCost = dQty * vItmFin.WeightedAverageCostPrice;
                        dTotalCost -= dPrevious_Updating_qty * dPrevious_UnitCost;
                        dTotalCost = dTotalCost < 0 ? 0 : dTotalCost;
                        dTotalCost += dCurrent_qty * dCurrent_UnitCost;
                        vItmFin.WeightedAverageCostPrice = decimal.Round(dTotalCost / (dQty - dPrevious_Updating_qty + dCurrent_qty), 2);
                        vItmFin.Update();
                    }
                    else
                    {
                        vItmFin.WeightedAverageCostPrice = 0;
                        vItmFin.Update();
                    }
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

                if (vItmFin.LowestPurchaseCostPrice == 0 && vItmFin.WeightedAverageCostPrice == 0)
                {
                    vItmFin.HighestPurchaseCostPrice = 0m;
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

        #region Get unit price of Finished Good from BoM
        public static decimal Get_FG_UnitCost_BoM(string sBoMId_ForSemiFG)
        {
            decimal dUnitPrice = 0;

            tbl_prod_pharmaTxJobCard_CostFooter oFirstObj = null;
            foreach (var footer in tbl_prod_pharmaTxJobCard_CostFooter.SelectAllByProdJob_ID(sBoMId_ForSemiFG).Where(p => p.Footer_ID == clsConfig.sItemUnitPrice_Production))
            {
                oFirstObj = footer;
                break;
            }

            if (oFirstObj != null)
                dUnitPrice = oFirstObj.Amount;

            return dUnitPrice;
        }


        #endregion

        public static List<tbl_prod_pharmaTxJobCard_Material> GetSubstituteMaterials(int iMainLine, int iSubLine_1, string sBoMID)
        {
            List<tbl_prod_pharmaTxJobCard_Material> lstMats = new List<tbl_prod_pharmaTxJobCard_Material>();
            foreach (tbl_prod_pharmaTxJobCard_Material oSubstitue_Mat in tbl_prod_pharmaTxJobCard_Material.SelectAllByProdJob_ID(sBoMID).
                Where(r1 => r1.Line_No == iMainLine && r1.Line_No_Sub1 == iSubLine_1))
            {
                lstMats.Add(oSubstitue_Mat);
            }
            return lstMats;
        }

        public static decimal Get_FloorQty_WIP_SemiFGs(string sBoMID, string sBatch_ID, string sItemID, string sActivityID)
        {
            decimal dInFloorQty = 0;
            decimal dOutFloorQty = 0;

            foreach (tbl_prod_pharmaTxWorkInProgress_Material oWIP_SF in tbl_prod_pharmaTxWorkInProgress_Material.SelectAllByItem_ID(sItemID).Where(r => r.Is_Output && r.Output_Activity_ID == sActivityID))
            {
                tbl_prod_pharmaTxWorkInProgress oWIP = tbl_prod_pharmaTxWorkInProgress.Select(oWIP_SF.Wip_ID);
                if (oWIP != null && oWIP.ProdJob_ID == sBoMID && oWIP.ProdBatch_ID == sBatch_ID && !oWIP.IsCanceled)
                    dInFloorQty += oWIP_SF.InputOutput_Qty;
            }

            foreach (tbl_prod_pharmaTxWorkInProgress_Material oWIP_SF in tbl_prod_pharmaTxWorkInProgress_Material.SelectAllByItem_ID(sItemID).Where(r => !r.Is_Output))
            {
                tbl_prod_pharmaTxWorkInProgress oWIP = tbl_prod_pharmaTxWorkInProgress.Select(oWIP_SF.Wip_ID);
                if (oWIP != null && oWIP.ProdJob_ID == sBoMID && oWIP.ProdBatch_ID == sBatch_ID && oWIP.Activity_ID == sActivityID && !oWIP.IsCanceled)
                    dOutFloorQty += oWIP_SF.InputOutput_Qty;
            }

            return (dInFloorQty - dOutFloorQty);
        }

        public static DataTable GetItemGroupedItemFloorstockTable_FloorStockGetFromUI_Grid(DataTable dt_In, string sQtyColumnName, string sStore_ID)
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

        public static decimal GetScrewNail_100PcksCountFromBatch(string sBatchID)
        {
            decimal dCount = 0;
            List<tbl_prod_pharmaTxWorkInProgress> lstWIP = tbl_prod_pharmaTxWorkInProgress.SelectAllByProdBatch_ID(sBatchID).Where(r=>!r.IsCanceled).ToList();
            List <tbl_prod_pharmaTxWorkInProgress> lstWIP_threading = lstWIP.Where(r=>r.Section_ID == "SECT/00003").ToList();//Check the Threading Section
            if (lstWIP_threading != null && lstWIP_threading.Count > 0)
            {
                //Packing Section
                foreach (tbl_prod_pharmaTxWorkInProgress oWIP_pck in lstWIP.Where(r=>r.Section_ID == "SECT/00004"))
                {
                    foreach (tbl_prod_pharmaTxWorkInProgress_Material oDetail in tbl_prod_pharmaTxWorkInProgress_Material.SelectAllByWip_ID(oWIP_pck.Wip_ID).Where(r=>r.Is_Output))
                    {
                        //Packing Section Output Qty
                        dCount += oDetail.InputOutput_Qty;
                    }
                }
            }
            return dCount;
        }
    }
}
