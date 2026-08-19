using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Operations.Manifest
{
    public class TNTAwbXmlDataDomainView
    {
        public int Manifest_ID { get; set; }

        public int Sector_ID { get; set; }

        public int Piece_ID { get; set; }
        public string Sec_Name { get; set; }
        public DateTime Sec_Date { get; set; }
        public string Sec_Origin { get; set; }
        public string Sec_Desti { get; set; }
        public string Sec_Mode { get; set; }
        public string Sec_ShippingDocType { get; set; }
        public string Sec_ShippingDocNo { get; set; }

        public String Piec_UnitID { get; set; }
        public String Piec_UnitSeal { get; set; }
        public String Piec_No { get; set; }
        public String Piec_ConsignmentNo { get; set; }
        public String Piec_Origin { get; set; }
        public String Piec_Desti { get; set; }
        public String Piec_Product { get; set; }
        public String Piec_Option1 { get; set; }
        public String Piec_Option2 { get; set; }
        public String Piec_Option3 { get; set; }
        public String Piec_Option4 { get; set; }
        public String Piec_Terms { get; set; }
        public String Piec_CollectionZone { get; set; }
        public String Piec_DeliveryZone { get; set; }

        public string Sen_Name { get; set; }

        public string Sen_Address1 { get; set; }

        public string Sen_Address2 { get; set; }

        public string Sen_City { get; set; }

        public string Sen_Postal { get; set; }

        public string Sen_Country { get; set; }

        public string Sen_Account { get; set; }

        public string Rec_Name { get; set; }

        public string Rec_Address1 { get; set; }

        public string Rec_Address2 { get; set; }

        public string Rec_City { get; set; }

        public string Rec_Postal { get; set; }

        public string Rec_Country { get; set; }

        public string Rec_Account { get; set; }

        public DateTime Collection_Date { get; set; }

        public TimeSpan Collection_Time { get; set; }

        public string NumberOf_Item { get; set; }

        public decimal Contractual_Weight { get; set; }

        public decimal Actual_Weight { get; set; }

        public decimal Value { get; set; }

        public string Currency { get; set; }

        public decimal Actual_Vol { get; set; }

        public decimal Contractual_Vol { get; set; }

        public string TariffCode { get; set; }

        public string GoodDescription { get; set; }

        public string Item_Quntity { get; set; }

        public string Value_Ind { get; set; }

        public int NexTNTNo { get; set; }

        public string customerReference { get; set; }

    }
}
