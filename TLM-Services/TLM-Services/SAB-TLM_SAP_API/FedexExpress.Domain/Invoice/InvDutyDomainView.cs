using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Invoice
{
    public class InvDutyDomainView
    {

       
        public int GroupID { get; set; }
        [Required(ErrorMessage = "User ID can't be empty")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Company ID can't be empty")]
        public int CompanyID { get; set; }
        public string CompanyN { get; set; }

        [Required(ErrorMessage = "Agency code can't be empty")]
        public int AgncyCode { get; set; }
        public string AgencyRpt { get; set; }
        public string AgencyN { get; set; }        
        public string InvoiceNo { get; set; }
        public string AirWayBill { get; set; }

        [Required(ErrorMessage = "Express ID can't be empty")]
        public string ExpressID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime TransDate { get; set; }

        [Required(ErrorMessage = "Shipment type can't be empty")]
        public string ShipType { get; set; }
        public string ShipTypeN { get; set; }
        public string JobNo { get; set; }  
        public string PayMode { get; set; }
        [Required(ErrorMessage = "Shipper can't be empty")]
        public string ShipCntr { get; set; }
        [Required(ErrorMessage = "Consingnee can't be empty")]
        public string DestiCntr { get; set; }
        [Required(ErrorMessage = "Payin party can't be empty")]
        public string PaidBy { get; set; }

        [Required(ErrorMessage = "Tax charge type can't be empty")]
        public string BillTaxChgType { get; set; }
        public string AccountNo { get; set; }
        public string MasterAwbNo { get; set; }
        public string CusdecNo { get; set; }      
        public string GoodDescp { get; set; }
        public string ConsID { get; set; }

        // shipment values
        public decimal ShipperValue { get; set; }

        [Required(ErrorMessage = "Manifested currency is not availble")]
        public string ManiCurrCode { get; set; }
        public decimal ManExtRate { get; set; }       
        public decimal ShipValueLoc { get; set; }

        [Required(ErrorMessage = "Clearence currency is not availble")]
        public string CustomValCur { get; set; }

        [Required(ErrorMessage = "shipment value type can't be empty")]
        public string ShipValType { get; set; }




        [Required(ErrorMessage = "Please select billing party code")]
        public string OrgnizCode { get; set; }

        [Required(ErrorMessage = "Please enter billing party name")]
        public string OrgnizName { get; set; }
        public string OrgPerson { get; set; }

        [Required(ErrorMessage = "Please enter billing address 1")]
        public string OrgAddr1 { get; set; }
        public string OrgAddr2 { get; set; }
        public int OrgCityCode { get; set; }
        [Required(ErrorMessage = "Please enter billing organization city")]
        public string OrgCity { get; set; }
        [Required(ErrorMessage = "Please enter billing organization country code")]
        public string OrgCntrCode { get; set; }
       ///// [Required(ErrorMessage = "Please enter billing organization country")]
        public string OrgCntrN { get; set; }
        public string TaxCodeOne { get; set; }
        public string Remarks { get; set; }
        [Required(ErrorMessage = "Please select Station")]
        public string SalesAreaID { get; set; }

        [Required(ErrorMessage = "Please select station")]
        public string BranchCode { get; set; }
        /// public string CityCode { get; set; }     
        public string IsCredit { get; set; }
        [Required(ErrorMessage = "Invoice mode can't be empty")]
        public string InvMode { get; set; }


        [Required(ErrorMessage = "Invoice type can't be empty")]
        public string InvoiceType { get; set; }

        [Required(ErrorMessage = "Payment type can't be empty")]
        public string PaymentType { get; set; }
        
        public decimal SellCurrRate { get; set; }
        public decimal LCAmount { get; set; }
        public decimal FCAmount { get; set; }

        [Required(ErrorMessage = "Foreing currency can't be empty")]
        public string FCCurrency { get; set; }

        [Required(ErrorMessage = "Base currency can't be empty")]
        public string LLCurrency { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TotalLCAmount { get; set; }
        public decimal InvTotLCAmount { get; set; }

      
       
        public string FlightNo { get; set; }       
   
        public string SenRefNotes { get; set; }
        public string GateWayID { get; set; }
        public string StationID { get; set; }
        public string RouteID { get; set; }


        public decimal PayNo { get; set; }
        public string PayRefno { get; set; }
        public DateTime  PayDate { get; set; }
        public int  PayAccount { get; set;  }
        public List<InvDutyChargeDomainView> charges { get; set; }
        public string ChargeXML { get; set; }
        public string DirectPayY { get; set; }
        public string PayDoctype { get; set; }
        public string ConsoleID { get; set; }
        public decimal RevsDocNo { get; set; }




    }
}
