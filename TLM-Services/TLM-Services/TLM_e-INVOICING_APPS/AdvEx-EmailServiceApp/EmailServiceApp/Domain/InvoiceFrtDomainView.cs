using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FedexExpress.View.Domain.Pricing
{
    public class InvoiceFrtDomainView
    {
        [Required(ErrorMessage = "Company group ID can't be empty")]
        public int GroupID { get; set; }

        [Required(ErrorMessage = "User ID can't be empty")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Company ID can't be empty")]
        public int CompanyID { get; set; }

        [Required(ErrorMessage = "Agency code can't be empty")]
        public int AgncyCode { get; set; }

        [Required(ErrorMessage = "Agency report code can't be empty")]
        public string AgncyRptID { get; set; }
        public string InvoiceNo { get; set; }

        [Required(ErrorMessage = "Please enter Airwaybill number")]
        public string AirWayBillNo { get; set; }

        [Required(ErrorMessage = "Express ID can't be empty")]
        public string ExpressID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime TransDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string ShipCountryCode { get; set; }
        public string ConsCountryCode { get; set; }
        public decimal AckWgt { get; set; }
        public decimal DimWgt { get; set; }
        public int Pkgs { get; set; }
        public decimal BillWgt { get; set; }
        public decimal RexWgt { get; set; }
        public string RexWgtU { get; set; }

        public decimal RexVol { get; set; }
        public string RexVolU { get; set; }
        public string Shipper { get; set; }
        public string Consingnee { get; set; }

        [Required(ErrorMessage = "Service type can't be empty")]
        public string SvsTypeCode { get; set; }

        [Required(ErrorMessage = "Product main can't be empty")]
        public string ProductMainCode { get; set; }
        [Required(ErrorMessage = "Product main sub can't be empty")]
        public string ProductSubCode { get; set; }

        [Required(ErrorMessage = "Package can't be empty")]
        public string PackTypeCode { get; set; }
        public string Remarks { get; set; }
        public string LcCurrency { get; set; }
        public string FcCurrency { get; set; }


        [Required(ErrorMessage = "Please select billing party")]
        public string OrgnizCode { get; set; }
        public string OrgnizName { get; set; }

        public string ContactPerson { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [Required(ErrorMessage = "Please select sales area")]
        public string SalesAreaID { get; set; }

        [Required(ErrorMessage ="Branch code can't be empty")]
        public string BranchCode { get; set; }

        ////  [Required(ErrorMessage = "Please select sales person")]
        ///public string SalesPerID { get; set; }
        public int DepCode { get; set; }
        public string CityCode { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }

        [Required(ErrorMessage = "Invoice mode can't be empty")]
        public string InvMode { get; set; }
        public string IsCashOnly { get; set; }

        ////public string DocId { get; set; }
        ////public string DocType { get; set; }

        [Required(ErrorMessage = "Shipment can't be empty")]
        public string ShipType { get; set; }
        public string IsMissRoute { get; set; }
        public string JobNo { get; set; }
        public decimal CurrencyRate { get; set; }


        // public string MissRoute { get; set; }
        public string WgtU { get; set; }
        public string DimVolU { get; set; }

        [Required(ErrorMessage = "Invoice type can't be empty")]
        public string InvoiceType { get; set; }

        public string DestCountry { get; set; }
        public string OrginCountry { get; set; }

        public string ConsId { get; set; }
        public string FlightNo { get; set; }
        public string MAWBNo { get; set; }

        public decimal SellRate { get; set; }
        public decimal SellDiscount { get; set; }
        public decimal SellDisPer { get; set; }
        public decimal SellBaseAmount { get; set; }
        public decimal SellFuelChg { get; set; }
        public decimal SellFuelChgPer { get; set; }
        public decimal SellOrginTax { get; set; }
        public decimal SellFCAmount { get; set; }
        public decimal SellLCAmount { get; set; }


        public decimal CostRate { get; set; }
        public decimal CostDiscount { get; set; }
        public decimal CostDisPer { get; set; }
        public decimal CostBaseAmount { get; set; }
        public decimal CostFuelChg { get; set; }
        public decimal CostFuelChgPer { get; set; }
        public decimal CostOrginTax { get; set; }
        public decimal CostFCAmount { get; set; }
        public decimal CostLCAmount { get; set; }

        public decimal SellRepChg { get; set; }
        public decimal SellPackChg { get; set; }
        public decimal SellOtherChg { get; set; }
        public decimal SellTotalInvoice { get; set; }

        public decimal CostRepChg { get; set; }
        public decimal CostPackChg { get; set; }
        public decimal CostOtherChag { get; set; }
        public decimal CostTotalInvoice { get; set; }

        public string BillTransChg { get; set; }
        public string AccountNo { get; set; }
        public string DocNdoc { get; set; }

        public int SellTariffNo { get; set; }
        public int CostTarrifNo { get; set; }

        public Boolean IsResetTax2 { get; set; }



    }
}
