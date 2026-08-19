using DataTire;
using Digiteq_Logic;
using SEACC_WPFControls;
using System;


namespace SEACC_POS.Common
{
    public class clsCommon_POS
    {
        public static CompanyImages getCompanyImages()
        {
            CompanyImages oCI = new CompanyImages();
            tbl_genCompanyImage comI = tbl_genCompanyImage.Select(clsSecurity.CompanyID);

            if (comI != null)
            {
                oCI.CompanyImage1 = comI.MainLogo;
                oCI.CompanyImage2 = comI.LogoOnly;
                oCI.CompanyImage3 = comI.TextOnly;
            }

            return oCI;

        }


        public static string FormatToNumberWithTwoDecimalPlaces (decimal dAmount)
        {
            string sValue = "";
            sValue = cls_Formater.FormatDecimal(dAmount, 2);
            return sValue;
        }

        public static string FormatToNumberWithOneDecimalPlaces(decimal dAmount)
        {
            string sValue = "";
            sValue = cls_Formater.FormatDecimal(dAmount, 1);
            return sValue;
        }

        public static string FormatToCurrecyWithThreeDecimalPlaces(decimal dAmount)
        {
            string sValue = "";
            sValue = cls_Formater.FormatDecimal(dAmount, 3);
            return sValue;
        }


        public static string FormatToNumberWithFourDecimalPlaces(decimal dAmount)
        {
            string sValue = "";
            sValue = cls_Formater.FormatDecimal(dAmount, 4);
            return sValue;
        }

        public static string FormatToCurrecyWithThousendSep(decimal dAmount)
        {
            string sValue = "";
            sValue = cls_Formater.FormatDecimal(dAmount, 2);
            return sValue;
        }
    }

    public class CompanyImages
    {
        public byte[] CompanyImage1 { get; set; }
        public byte[] CompanyImage2 { get; set; }
        public byte[] CompanyImage3 { get; set; }
    }
}
