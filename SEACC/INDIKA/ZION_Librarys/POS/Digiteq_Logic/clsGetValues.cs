using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTire;

namespace Digiteq_Logic
{
    public class clsGetValues
    {
        #region Get Commission Value
        public static void get_CommissionValue_FromCommissionSlabs(decimal dDays, decimal dCustomerCreditPeriod, decimal dAmount, ref decimal dRange1Value, ref decimal dRange2Value, ref decimal dRange3Value, ref decimal dRange4Value,ref decimal dRange5Value)
        {
            if (dDays > 0)
            {
               // bool bValidForDiductionComission = false;
                if (dCustomerCreditPeriod >= 90)
                {
                   // if (dDays <= clsConfig.dRange1_Days)
                   //     bValidForDiductionComission = true;
                }
                else if (dCustomerCreditPeriod >= 75)
                {
                    //if (dDays <= clsConfig.dRange2_Days)
                     //   bValidForDiductionComission = true;
                }
                else if (dCustomerCreditPeriod >= 60)
                {
                   // if (dDays <= clsConfig.dRange3_Days)
                     //   bValidForDiductionComission = true;
                }
                else if (dCustomerCreditPeriod >= 45)
                {
                   // if (dDays <= clsConfig.dRange4_Days)
                     //   bValidForDiductionComission = true;
                }
                else
                  //  bValidForDiductionComission = true;


                if (dDays <= clsConfig.dRange1_Days)
                    dRange1Value = dAmount;
                else if (dDays <= clsConfig.dRange2_Days)
                    dRange2Value = dAmount;
                else if (dDays <= clsConfig.dRange3_Days)
                    dRange3Value = dAmount;
                else if (dDays <= clsConfig.dRange4_Days)
                    dRange4Value = dAmount;
                else if (dDays > clsConfig.dRange5_Days)
                    dRange5Value = dAmount;

            }
        }
        public static void get_CommissionValueAll_FromCommissionSlabs(decimal dDays, decimal dCustomerCreditPeriod, decimal dAmount, decimal dCommissionPasantage,           
            ref decimal dRange1Value, ref decimal dRange2Value, ref decimal dRange3Value, ref decimal dRange4Value,
           ref decimal dRange5Value, ref decimal dRange1Pasantage, ref decimal dRange2Pasantage, ref decimal dRange3Pasantage, ref decimal dRange4Pasantage, ref decimal dRange5Pasantage,
            ref decimal dRange1Commission, ref decimal dRange2Commission, ref decimal dRange3Commission, ref decimal dRange4Commission, ref decimal dRange5Commission)
        {
            
            if (dDays > 0)
            {
                bool bValidForDiductionComission = false;
                if (dCustomerCreditPeriod >= 90)
                {
                    if (dDays <= clsConfig.dRange1_Days)
                        bValidForDiductionComission = true;
                }
                else if (dCustomerCreditPeriod >= 75)
                {
                    if (dDays <= clsConfig.dRange2_Days)
                        bValidForDiductionComission = true;
                }
                else if (dCustomerCreditPeriod >= 60)
                {
                    if (dDays <= clsConfig.dRange3_Days)
                        bValidForDiductionComission = true;
                }
                else if (dCustomerCreditPeriod >= 45)
                {
                    if (dDays <= clsConfig.dRange4_Days)
                        bValidForDiductionComission = true;
                }else
                    bValidForDiductionComission = true;


                if (dDays <= clsConfig.dRange1_Days)
                {
                    dRange1Value = dAmount;
                    decimal dPasantage = dCommissionPasantage * clsConfig.dRange1_Pasantage / 100;
                    dRange1Commission = bValidForDiductionComission ? dAmount * dPasantage / 100 : 0;
                }
                else if (dDays <= clsConfig.dRange2_Days)
                {
                    dRange2Value = dAmount;
                    decimal dPasantage = dCommissionPasantage * clsConfig.dRange2_Pasantage / 100;
                    dRange2Commission = bValidForDiductionComission ? dAmount * dPasantage / 100 : 0;
                }
                else if (dDays <= clsConfig.dRange3_Days)
                {
                    dRange3Value = dAmount;
                    decimal dPasantage = dCommissionPasantage * clsConfig.dRange3_Pasantage / 100;
                    dRange3Commission = bValidForDiductionComission ? dAmount * dPasantage / 100 : 0;
                }
                else if (dDays <= clsConfig.dRange4_Days)
                {
                    dRange4Value = dAmount;
                    decimal dPasantage = dCommissionPasantage * clsConfig.dRange4_Pasantage / 100;
                    dRange4Commission = bValidForDiductionComission ? dAmount * dPasantage / 100 : 0;
                }
                else if (dDays > clsConfig.dRange5_Days)
                {
                    dRange5Value = dAmount;
                    decimal dPasantage = dCommissionPasantage * clsConfig.dRange5_Pasantage / 100;
                    dRange5Commission = bValidForDiductionComission ? dAmount * dPasantage / 100 : 0;
                }

            }
        } 
        #endregion

    }
}
