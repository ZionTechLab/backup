using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataTire;
using System.Net.Mail;
using System.Collections;
using System.Net;
using Digiteq.DataSets;
using System.Data;
using CrystalDecisions.Shared;
using Digiteq_Logic;

namespace Digiteq
{
    public class clsAlerts
    {
        #region Update - After Checking - SRN
        public static bool Update_AfterChecking_SRN(string sSRNID, string sUserID)
        {
            bool isUpdate = false;
            tbl_sasSalesReturnedNote objSRN = tbl_sasSalesReturnedNote.Select(sSRNID);
            if (objSRN != null && !objSRN.IsChecked)
            {
                objSRN.IsChecked = true;
                objSRN.DateChecked = clsSecurity.getServerDateTime();
                objSRN.CheckedUser_ID = sUserID;

                //Update Other Tables
                #region Update Other Tables
                bool bUpdateOk = (clsConfig.bSRN_StockUpdate_NeedChecking) ? objSRN.IsChecked : false; //validate whether the configuration is set to need checking
                if (bUpdateOk)
                {
                    foreach (tbl_sasSalesReturnedNote_Detail oldSRNDetail in tbl_sasSalesReturnedNote_Detail.SelectAllBySalesReturnedNote_ID(objSRN.SalesReturnedNote_ID))
                    {
                        //////Update Other Tables
                        #region Update DeliveryOrder / CustomerOrder
                        if (oldSRNDetail.DeliveryOrder_ID != "default")
                        {
                            tbl_sasDeliveryOrder oDO = tbl_sasDeliveryOrder.Select(oldSRNDetail.DeliveryOrder_ID);
                            if (oDO != null && oDO.DeliveryOrder_ID != "default" && !oDO.IsDeleted)
                            {
                                tbl_sasDeliveryOrder_Detail DoItem = tbl_sasDeliveryOrder_Detail.Select(oldSRNDetail.Line_No, oDO.DeliveryOrder_ID, oldSRNDetail.Item_ID, oldSRNDetail.ItemSubCategory_ID, oldSRNDetail.ItemSubCategory2_ID, oldSRNDetail.ItemSerialNo, oldSRNDetail.ItemSerialNo2);
                                if (DoItem != null && DoItem.Item_ID != "default")
                                {
                                    //Update D/O
                                    DoItem.QtyReturned = DoItem.QtyReturned + oldSRNDetail.Qty;
                                    DoItem.WeightReturned = DoItem.WeightReturned + oldSRNDetail.Weight;
                                    DoItem.Update();

                                    isUpdate = true;

                                    CheckBox oCheckBox = new CheckBox();
                                    oCheckBox.Checked = !objSRN.IsWeightCalculation;
                                    bool bInvoiceMade = objSRN.Invoice_ID != "default";
                                    clsProcessMethods.SetSettle_DeliveryOrder(oDO.DeliveryOrder_ID, oCheckBox, bInvoiceMade);

                                    //Update C/O
                                    tbl_sasCustomerOrder_Detail CoItem = tbl_sasCustomerOrder_Detail.Select(DoItem.Line_No, oDO.CustomerOrder_ID, DoItem.Item_ID, DoItem.ItemSubCategory_ID, DoItem.ItemSubCategory2_ID, DoItem.ItemSerialNo, DoItem.ItemSerialNo2);
                                    if (CoItem != null && objSRN.IsReturnable)
                                    {
                                        CoItem.QtySettle_DeliveryOrder = CoItem.QtySettle_DeliveryOrder - oldSRNDetail.Qty;
                                        CoItem.WeightSettle_DeliveryOrder = CoItem.WeightSettle_DeliveryOrder - oldSRNDetail.Weight;
                                        CoItem.Update();

                                        clsProcessMethods.SetSettle_CustomerOrderFrom_DeliveryOrder(oDO.CustomerOrder_ID, oCheckBox);
                                    }
                                }
                            }
                            else
                                MessageBox.Show("Invalid Delivery Order Please Contact System Addministrator......!", clsFormatter.GetMessageCaption(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        #endregion
                    }
                }
                #endregion
                objSRN.Update();
            }

            return isUpdate;
        }
        #endregion

        #region DisplayItemViewer
        public static void DisplayItemViewer(string sItemCode, string sSubCategoryID1, string sSubCategoryID2, string sSerial1, string sSerial2)
        {
            if (sSubCategoryID1 == "")
                sSubCategoryID1 = "default";
            if (sSubCategoryID2 == "")
                sSubCategoryID2 = "default";
            if (sSerial1 == "")
                sSerial1 = "0";
            if (sSerial2 == "")
                sSerial2 = "0";

            if (sItemCode.Length > 0 && sSubCategoryID1.Length > 0 && sSubCategoryID2.Length > 0 && sSerial1.Length > 0 && sSerial2.Length > 0)
                clsHelpMethods_Local.showItemViewer(sItemCode, sSerial1, sSerial2, sSubCategoryID1, sSubCategoryID2);
        }

        public static void DisplayItemPriceViewer(string sItemCode, string sSubCategoryID1, string sSubCategoryID2, string sSerial1, string sSerial2)
        {
            if (sSubCategoryID1 == "")
                sSubCategoryID1 = "default";
            if (sSubCategoryID2 == "")
                sSubCategoryID2 = "default";
            if (sSerial1 == "")
                sSerial1 = "0";
            if (sSerial2 == "")
                sSerial2 = "0";

            if (sItemCode.Length > 0 && sSubCategoryID1.Length > 0 && sSubCategoryID2.Length > 0 && sSerial1.Length > 0 && sSerial2.Length > 0)
            {
                frmItemPriceSeting frm = new frmItemPriceSeting();

                frm.glbItemID = sItemCode;
                frm.glbItemSerialNo1 = sSerial1;
                frm.glbItemSerialNo2 = sSerial2;
                frm.glbItemSubCategoryID1 = sSubCategoryID1;
                frm.glbItemSubCategoryID2 = sSubCategoryID2;
                frm.ShowDialog();
            }
        }
        #endregion


        #region Create SMS For Alerts
        #region Creating WIP
        public static void CreateSMS_FinishGoodProduce_FirstTime(enum_Alerts alertType, string sCustName, string sSalesManID, string sJobID, string sItemName, string dOrderQty)
        {
            ArrayList tolist = new ArrayList();
            string sMessage = "";
            bool SmsStatus = false;
            #region Meesage Body

            sMessage = "Customer Name: " + sCustName + ",Salesman Name: " + sSalesManID + ",Job Number: " + sJobID + ",Item Name: " + sItemName + ",Order Qty : " + dOrderQty + "";
            #endregion
            tbl_utlAlert oAlert = tbl_utlAlert.Select(clsAutocode.getAlertID(alertType));
            foreach (tbl_utlAlertSettings oAlertSetting in tbl_utlAlertSettings.SelectAllByAlert_ID(oAlert.Alert_ID))
            {
                if (oAlertSetting.PhoneNo1.Length > 0)
                    SmsStatus = clsHelpMethods_Local.sendMessage(oAlertSetting.PhoneNo1, sMessage);
            }
        }
        #endregion
        #endregion
    }
}