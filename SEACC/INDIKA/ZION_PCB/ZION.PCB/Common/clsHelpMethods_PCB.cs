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

namespace ZION.PCB.Common
{

    public class clsHelpMethods_PCB
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

        public enum pcb_IOUStatus
        {
            [Description("")]
            IOUAll = 0,
            [Description("Settled")]
            IOUSet = 1,
            [Description("UnSettled")]
            IOUUnSet = 2,
        }

        public static string WrapNegatives(decimal value)
        {
            string fmt = "{0:#,###.00;(#,###.00);0}";
            decimal negAmount = value;
            return negAmount.ToString(fmt);
        }
    }
}
