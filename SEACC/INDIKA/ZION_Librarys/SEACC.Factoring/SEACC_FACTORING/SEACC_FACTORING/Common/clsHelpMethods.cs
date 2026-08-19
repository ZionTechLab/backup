using System;
using DataTire;
using System.Net.NetworkInformation;
using System.Net;
using Digiteq_Logic;
using System.Windows.Controls;

namespace SEACC_FACTORING.Common
{
    class clsHelpMethods
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
    }
}