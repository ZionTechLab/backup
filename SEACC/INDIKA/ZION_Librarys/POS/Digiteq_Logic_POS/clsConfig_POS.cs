using Digiteq_Logic;

namespace Digiteq_Logic_POS
{
    public class clsConfig_POS : clsConfig
    {
        public static string sERP_Location = "";
        public static string sPoS_SystemLogout_IdleSeconds = "18000";
        public static string sPOSAttachmentPath_Server = "";
        public static string sItemUnitPriceCode_Default_POS = "";
        public static string sPos_Customer_Default_GLAccount = "default";

        public static int iCurrencyDecimalPalces_PoS_Discount = 0;

        public static bool bPOSBillPrint_UsingReportWriter = false;
        public static bool bDirect_Print_R2_Pos_Invoice = false;
        public static bool bItemSearch_ImageLoadEnabled = false;
        public static bool bCapslockLtterst_R2_Pos_Textbox = false;
        public static bool bRemoteDesktopMode = false;
        public static bool bSalesReturn_Hide_POSTx_Window = false;
        public static bool bHide_AdvancePartPayment_Option = false;
        public static bool bDisableChequePaymentsFor_POS_Customers = false;

        //Hide 0 Qty Item - Celcius
        public static bool bHide_ZeroQty_Items = false;

        public static string sFinishedGoodStores = "";
        public static bool bEnableFilterSpecificStoresInStoreStock = false;
    }
}
