using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq; 
using System.Text;
using DataTire;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Net;
using System.Net.Sockets;
//using CrystalDecisions.CrystalReports.Engine;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;
using Digiteq_Logic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SEACC_servii
{
    class clsHelpMethods
    {
     public static   void Update_StoreStock(string Store_ID, string Item_ID, string Cusstomer_ID, decimal Qty, decimal weight)
        {
            tbl_genStore_Stock oStock = tbl_genStore_Stock.Select(Store_ID, Item_ID, Cusstomer_ID);
            if (oStock != null)
            {
                oStock.Qty += Qty;
                oStock.Weight += weight;
                oStock.Update();
            }
            else
            {
                tbl_genStore_Stock Stock = new tbl_genStore_Stock(Store_ID, Item_ID, Cusstomer_ID, Qty, weight);
                Stock.Insert();
            }
        }

        public static bool CheckValidityIPAddress(string sIPAddress)
        {
            //create our match pattern
            string pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
            //create our Regular Expression object
            Regex check = new Regex(pattern);
            //boolean variable to hold the status
            bool valid = false;
            //check to make sure an ip address was provided
            if (sIPAddress == "")
            {
                //no address provided so return false
                valid = false;
            }
            else
            {
                //address provided so use the IsMatch Method
                //of the Regular Expression object
                valid = check.IsMatch(sIPAddress, 0);
            }
            //return the results
            return valid;
        }

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
                    if (CheckValidityIPAddress(curAdd.ToString()))
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
        //public static string GetIPAddress()
        //{
        //    string sIPAddress = "";
        //    try
        //    {
        //        System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();

        //        // Get server related information.
        //        IPHostEntry heserver = Dns.GetHostEntry(GetHostName());

        //        // Loop on the AddressList
        //        foreach (IPAddress curAdd in heserver.AddressList)
        //        {
        //            if (clsValidation.CheckValidityIPAddress(curAdd.ToString()))
        //            {
        //                sIPAddress = curAdd.ToString();
        //                break;
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("[DoResolve] Exception: " + e.ToString());
        //    }
        //    return sIPAddress;
        //}
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

        //public static decimal CalculateGrandTotalAdvance(TextBox txtSubTotal, TextBox txtDiscount, TextBox txtDiscountRate, CheckBox chkDiscount, TextBox txtNbt, TextBox txtNbtRate, CheckBox chkNbt, TextBox txtVat, TextBox txtVatRate, CheckBox chkVat, TextBox txtOtherTax, TextBox txtOtherTaxRate, CheckBox chkOtherTax)
        //{
        //    decimal dGrandTotal = 0, dSubTotalRunning = 0, dSubTotal = 0, dDiscount = 0, dDicountRate = 0, dNbt = 0, dNbtRate = 0, dVat = 0, dVatRate = 0, dOtherTax = 0, dOtherTaxRate = 0;

        //    ////Assign SubTotal
        //    if (txtSubTotal.Tag != null && txtSubTotal.Tag.ToString().Trim().Length > 0 && cls_Formater.isCurrency(txtSubTotal.Tag.ToString().Trim()))
        //        dSubTotal = (dSubTotalRunning = decimal.Parse(txtSubTotal.Tag.ToString().Trim()));

        //    ////Discount Calculation
        //    //#region Discount
        //    //if (chkDiscount.Checked)
        //    //{
        //    //    if (txtDiscountRate.TextLength > 0 && cls_Formater.isCurrency(txtDiscountRate.Text.Trim()))
        //    //        dDicountRate = decimal.Parse(txtDiscountRate.Text.Trim());
        //    //    if (txtDiscount.Tag != null && txtDiscount.Tag.ToString().Trim().Length > 0 && cls_Formater.isCurrency(txtDiscount.Tag.ToString().Trim()))
        //    //        dDiscount = decimal.Parse(txtDiscount.Tag.ToString().Trim());

        //    //    if (dDicountRate > 0)
        //    //        dDiscount = ((dSubTotalRunning * dDicountRate) / 100);

        //    //    if (dSubTotalRunning > 0 && dDiscount > 0)
        //    //    {
        //    //        dSubTotalRunning = (dSubTotalRunning - dDiscount);
        //    //    }

        //    //    //Assign Values
        //    //    txtDiscount.Tag = dDiscount;
        //    //    txtDiscount.Text = cls_Formater.FormatToCurrecyWithThousendSep(dDiscount);
        //    //}
        //    //else
        //    //{
        //    //    //Assign Values
        //    //    txtDiscount.Tag = dDiscount;
        //    //    txtDiscount.Text = cls_Formater.FormatToCurrecyWithThousendSep(dDiscount);
        //    //}
        //    //#endregion

        //    ////NBT Calculation
        //    //#region NBT
        //    //if (chkNbt.Checked)
        //    //{
        //    //    if (txtNbtRate.TextLength > 0 && cls_Formater.isCurrency(txtNbtRate.Text.Trim()))
        //    //        dNbtRate = decimal.Parse(txtNbtRate.Text.Trim());


        //    //    if (dNbtRate > 0)
        //    //        dNbt = ((dSubTotalRunning * dNbtRate) / 100);

        //    //    if (dSubTotalRunning > 0 && dNbt > 0)
        //    //    {
        //    //        dSubTotalRunning = (dSubTotalRunning + dNbt);
        //    //    }

        //    //    //Assign Values
        //    //    txtNbt.Tag = dNbt;
        //    //    txtNbt.Text = cls_Formater.FormatToCurrecyWithThousendSep(dNbt);
        //    //}
        //    //else
        //    //{
        //    //    //Assign Values
        //    //    txtNbt.Tag = dNbt;
        //    //    txtNbt.Text = cls_Formater.FormatToCurrecyWithThousendSep(dNbt);
        //    //}
        //    //#endregion

        //    ////VAT Calculation
        //    //#region VAT
        //    //if (chkVat.Checked)
        //    //{
        //    //    if (txtVatRate.TextLength > 0 && cls_Formater.isCurrency(txtVatRate.Text.Trim()))
        //    //        dVatRate = decimal.Parse(txtVatRate.Text.Trim());

        //    //    if (dVatRate > 0)
        //    //        dVat = ((dSubTotalRunning * dVatRate) / 100);

        //    //    if (dSubTotalRunning > 0 && dVat > 0)
        //    //    {
        //    //        dSubTotalRunning = (dSubTotalRunning + dVat);
        //    //    }

        //    //    //Assign Values
        //    //    txtVat.Tag = dVat;
        //    //    txtVat.Text = cls_Formater.FormatToCurrecyWithThousendSep(dVat);
        //    //}
        //    //else
        //    //{
        //    //    //Assign Values
        //    //    txtVat.Tag = dVat;
        //    //    txtVat.Text = cls_Formater.FormatToCurrecyWithThousendSep(dVat);
        //    //}
        //    //#endregion

        //    ////Other Tax Calculation
        //    //#region Other Tax
        //    //if (chkOtherTax.Checked)
        //    //{
        //    //    if (txtOtherTaxRate.TextLength > 0 && cls_Formater.isCurrency(txtOtherTaxRate.Text.Trim()))
        //    //        dOtherTaxRate = decimal.Parse(txtOtherTaxRate.Text.Trim());


        //    //    if (dOtherTaxRate > 0)
        //    //        dOtherTax = ((dSubTotalRunning * dOtherTaxRate) / 100);

        //    //    //if (dSubTotalRunning > 0 && dOtherTax > 0)
        //    //    //{
        //    //    //    dSubTotalRunning = (dSubTotalRunning + dOtherTax);
        //    //    //}

        //    //    //Assign Values
        //    //    txtOtherTax.Tag = dOtherTax;
        //    //    txtOtherTax.Text = cls_Formater.FormatToCurrecyWithThousendSep(dOtherTax);
        //    //}
        //    //else
        //    //{
        //    //    //Assign Values
        //    //    txtOtherTax.Tag = dOtherTax;
        //    //    txtOtherTax.Text = cls_Formater.FormatToCurrecyWithThousendSep(dOtherTax);
        //    //}
        //    //#endregion

        //    ////Calculate Grand Total
        //    //#region Grand Total
        //    //dGrandTotal = (dSubTotal - dDiscount + dNbt + dVat);
        //    //#endregion


        //    return dGrandTotal;

        //}

    }
}
