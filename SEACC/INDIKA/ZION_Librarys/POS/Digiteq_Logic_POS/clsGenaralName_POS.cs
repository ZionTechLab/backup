using DataTire;
using Digiteq_Logic;

namespace Ext_Digiteq_Logic
{
    public class clsGenaralName_POS : clsGenaralName
    {
        public static string getDescription2_Item(string Item_ID)
        {
            string valueName = DBHandling.ExecQuery_ReturnString(GenarateQuery("tbl_genItemMaster", "description1", "item_ID", Item_ID));
            return valueName == "default" ? "-" : valueName;
        }

        public static string getPoS_ID_From_PoS_Index(int iPosTransaction_Index)
        {
            string sReturn = "";
            tbl_posTransaction oPosTx = tbl_posTransaction.Select(iPosTransaction_Index);
            if (oPosTx != null && oPosTx.PosTransaction_ID != "default")
                sReturn = oPosTx.PosTransaction_ID;
            return sReturn;
        }

        public static string getGiftVoucherSerial_From_ID(int iGV_ID)
        {
            string sReturn = "";
            tbl_bpsGiftVoucher oGV = tbl_bpsGiftVoucher.Select(iGV_ID);
            if (oGV != null)
                sReturn = oGV.SerialNo;

            return sReturn;
        }

        //public static string getPosTransaction_ID_FromIndex(int iPosTransaction_Index)
        //{
        //    string sTx_ID = "default";
        //    tbl_posTransaction oPosTx = tbl_posTransaction.Select(iPosTransaction_Index);
        //    if (oPosTx != null)
        //        sTx_ID = oPosTx.PosTransaction_ID;

        //    return sTx_ID;
        //}
    }
}
