using DataTire;
using Digiteq_Logic;

namespace Digiteq_Logic_POS
{
    public class clsBackProcess_POS : clsBackProcess
    {
        public static void AutoAssignConfigStatus_POS()
        {
            foreach (tbl_securityConfigStatus oStatus in tbl_securityConfigStatus.SelectAll())
            {
                switch (oStatus.ValueID)
                {
                    //--SEACC R2 POS (FROM 601 - 700)
                    case 601:
                        clsConfig_POS.bPOSBillPrint_UsingReportWriter = oStatus.ConfigValue;
                        break;
                    case 602:
                        clsConfig_POS.bDirect_Print_R2_Pos_Invoice = oStatus.ConfigValue;
                        break;
                    case 603:
                        clsConfig_POS.bItemSearch_ImageLoadEnabled = oStatus.ConfigValue;
                        break;
                    case 604:
                        clsConfig_POS.bCapslockLtterst_R2_Pos_Textbox = oStatus.ConfigValue;
                        break;
                    case 605:
                        clsConfig_POS.bRemoteDesktopMode = oStatus.ConfigValue;
                        break;
                    case 606:
                        clsConfig_POS.bHide_ZeroQty_Items = oStatus.ConfigValue;
                        break;
                    case 607:
                        clsConfig_POS.bEnableFilterSpecificStoresInStoreStock = oStatus.ConfigValue;
                        break;
                    case 608:
                        clsConfig_POS.bSalesReturn_Hide_POSTx_Window = oStatus.ConfigValue;
                        break;
                    case 609:
                        clsConfig_POS.bHide_AdvancePartPayment_Option = oStatus.ConfigValue;
                        break;
                    case 610:
                        clsConfig_POS.bDisableChequePaymentsFor_POS_Customers = oStatus.ConfigValue;
                        break;
                }
            }
        }

        public static void AutoAssignConfigValue_POS()
        {
            foreach (tbl_securityConfigValue oValue in tbl_securityConfigValue.SelectAll())
            {
                switch (oValue.ValueID)
                {
                    case 601:
                        clsConfig_POS.sERP_Location = oValue.ConfigValue.Trim();
                        break;
                    case 602:
                        clsConfig_POS.sPoS_SystemLogout_IdleSeconds = oValue.ConfigValue.Trim();
                        break;
                    case 603:
                        clsConfig_POS.iCurrencyDecimalPalces_PoS_Discount = int.Parse(oValue.ConfigValue.Trim());
                        break;
                    case 604:
                        clsConfig_POS.sPOSAttachmentPath_Server = oValue.ConfigValue.Trim();
                        break;
                    case 605:
                        clsConfig_POS.sItemUnitPriceCode_Default_POS = oValue.ConfigValue.Trim();
                        break;
                    case 606:
                        clsConfig_POS.sFinishedGoodStores = oValue.ConfigValue.Trim();
                        break;
                    case 607:
                        clsConfig_POS.sPos_Customer_Default_GLAccount = oValue.ConfigValue.Trim();
                        break;
                }
            }
        }

    }
}
