using DataTire;
using Digiteq_Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Windows.Controls;

namespace SEACC_PRODUCTION_POLY.Common
{

    public class clsHelpMethods_Prod
    {
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

        private static string GenarateQuery(string table, string field, string Key, string value)
        {
            if (value != null && value != "" && value.Length > 0)
                return "select [" + field + "] from [" + table + "] where " + Key + "='" + value + "'";
            else
                return "";
        }

        public static string get_MonthName(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_hrPeriod_Month", "month_Name", "month_ID", ID));
        }

        public static string get_FinishedGoodTransferNoteID(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_prodTxFinishedGoodTransferNote", "fgtn_ID", "prodJob_ID", ID));
        }

        public static string get_FinishedGoodTransferNoteDate(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_prodTxFinishedGoodTransferNote", "fgtn_Date", "prodJob_ID", ID));
        }

        public static string get_FinishedGoodTransferNoteUoM(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_prodTxFinishedGoodTransferNote", "uom_ID", "prodJob_ID", ID));
        }

        public static string get_FinishedGoodTransferNoteQty(string ID)
        {
            return DBHandling.ExecQuery_ReturnStringValue(GenarateQuery("tbl_prodTxFinishedGoodTransferNote", "fGoodQty", "prodJob_ID", ID));
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
        public static decimal GetItemQtyInCustomerOrder_FromJob(string sProdJob_ID)
        {
            decimal dQty = 0.000m;
            tbl_prod_polyTxJobCard oBoM = tbl_prod_polyTxJobCard.Select(sProdJob_ID);
            if (IsJobType_MakeToSupply(oBoM.JobType_ID))
            {
                dQty = oBoM.FGoodQty;
            }
            else if (oBoM != null && oBoM.CustomerOrder_ID != "default")
            {
                tbl_sasCustomerOrder_Detail oCO_Detail_BoMItem = tbl_sasCustomerOrder_Detail.SelectAllByCustomerOrder_ID(oBoM.CustomerOrder_ID).Where(r => r.Item_ID == oBoM.Item_ID_FG).FirstOrDefault();
                if (oCO_Detail_BoMItem != null)
                    dQty = oCO_Detail_BoMItem.Qty;
            }
            return dQty;
        }
        #endregion

        public static decimal AlreadyIssuedQty_formMRs(string sBoM_No, string sItem_ID)
        {
            decimal dQty = 0;
            foreach (tbl_prod_polyTxMaterialRequision_Material oMeterial in tbl_prod_polyTxMaterialRequision_Material.SelectAllByProdJob_ID(sBoM_No).Where(r => r.Item_ID == sItem_ID))
                dQty += oMeterial.Mr_Qty;
            return dQty;
        }

        public static decimal AlreadyIssuedWeight_formMRs(string sBoM_No, string sItem_ID)
        {
            decimal dWeight = 0;
            foreach (tbl_prod_polyTxMaterialRequision_Material oMeterial in tbl_prod_polyTxMaterialRequision_Material.SelectAllByProdJob_ID(sBoM_No).Where(r => r.Item_ID == sItem_ID))
                dWeight += oMeterial.Mr_Weight;
            return dWeight;
        }

        public static decimal AlreadyIssuedQty_formPGINs(string sBoM_No, string sItem_ID)
        {
            decimal dQty = 0;
            foreach (tbl_prodTxGoodIssueNote_Material oMeterial in tbl_prodTxGoodIssueNote_Material.SelectAllByProdJob_ID(sBoM_No).Where(r => r.Item_ID == sItem_ID))
                dQty += oMeterial.PGIN_Qty;
            return dQty;
        }

        public static decimal AlreadyIssuedQty_formPGRNs(string sBoM_No, string sItem_ID)
        {
            decimal dQty = 0;
            foreach (tbl_prodTxGoodReturnNote oPGRN in tbl_prodTxGoodReturnNote.SelectAllByProdJob_ID(sBoM_No))
            {
                foreach (tbl_prodTxGoodReturnNote_Material oMeterial in tbl_prodTxGoodReturnNote_Material.SelectAllByPGRN_No(oPGRN.PGRN_No).Where(r => r.Item_ID == sItem_ID))
                    dQty += oMeterial.PGRN_Qty;
            }
            return dQty;
        }

        public static decimal AlreadyIssuedQty_formWIPs(string sBoM_No, string sItem_ID)
        {
            decimal dQty = 0;
            foreach (tbl_prod_polyTxWorkInProgress oWIP in tbl_prod_polyTxWorkInProgress.SelectAllByProdJob_ID(sBoM_No))
            {
                foreach (tbl_prod_polyTxWorkInProgress_Material oMeterial in tbl_prod_polyTxWorkInProgress_Material.SelectAllByWip_ID(oWIP.Wip_ID).Where(r => r.Item_ID == sItem_ID && !r.Is_Output))
                    dQty += oMeterial.InputOutput_Qty;
            }
            return dQty;
        }

        public static decimal AlreadyIssuedQty_formFGTNs(string sBoM_No)
        {
            decimal dQty = 0;
            foreach (tbl_prodTxFinishedGoodTransferNote oFGTN in tbl_prodTxFinishedGoodTransferNote.SelectAllByProdJob_ID(sBoM_No))
            {
                dQty += oFGTN.FgtnQty;
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
            tbl_prod_polyTxJobCard oProdJobBoM = tbl_prod_polyTxJobCard.Select(sBoM_No);
            if (oProdJobBoM != null)
                isMTS = IsJobType_MakeToSupply(oProdJobBoM.JobType_ID);

            return isMTS;
        }

        public static decimal Get_SectionStockBalance_Qty(string sSection_ID, string sItemID, string sJobID, string sSubCategory1, string sSubCategory2, string sSerial1, string sSerial2)
        {
            decimal dQty = 0;
            tbl_genSectionMaster oSection = tbl_genSectionMaster.Select(sSection_ID);
            if (oSection != null)
            {
                dQty = clsProcessMethods.Get_StoreStockBalance_Qty(oSection.Store_ID, sItemID, sJobID, sSubCategory1, sSubCategory2, sSerial1, sSerial2);
            }
            return dQty;
        }

    }
}
