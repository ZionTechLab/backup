using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServiceApp.Domain
{

    public class FrtInvoiceReportDomainView
    {
        public int RowID { get; set; }
        public int numRowID { get; set;}
        public int GroupID { get; set; }
        public int CompanyID { get; set; }
        public string CompanyN { get; set; }
        public int AgencyCode { get; set; }
        ///  public string  DocReference { get; set; }	
        public DateTime InvDate { get; set; }
        public DateTime TransDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string InvNo { get; set; }
        public int OrgCode { get; set; }
        public string OrgName { get; set; }
        public string OrgCountry { get; set; }
        public string OrgAddr1 { get; set; }
        public string OrgAddr2 { get; set; }
        public string OrgCity { get; set; }
        public string ChargeCode { get; set; }
        public string ChargeDesc { get; set; }
        public decimal ConvRate { get; set; }
        public string LocalCurrency { get; set; }
        public string ForiengCurrency { get; set; }
        public decimal LineLCAmount { get; set; }
        public decimal LineFCAmount { get; set; }

        public string DebtorLCCurrency { get; set; }
        public string DebtorFLCurrency { get; set; }
        public decimal DebtorFCTotAmount { get; set; }
        public decimal DebtorLCTotAmount { get; set; }

        ///   public decimal LineTaxTotal { get; set; }
        /// public decimal LineTotalAmount { get; set; }	
        public string Remarks { get; set; }
        public string AgnAWBNo { get; set; }

        public string SvcType { get; set; }
        public string SvcTypeN { get; set; }
        public string PackType { get; set; }
        // public string PackTypeN { get; set; }
        public int TotPkgs { get; set; }
        public decimal TotWgt { get; set; }
        public string WgtU { get; set; }
        public decimal BillWgt { get; set; }
        public string BillWgtU { get; set; }
        public decimal DimVol { get; set; }
        public decimal RexWgt { get; set; }
        public decimal RexVol { get; set; }
        public string DocNdoc { get; set; }
        public decimal FuelShgPer { get; set; }
        public string Shipper { get; set; }
        public string Consingnee { get; set; }
        public string OrginCounty { get; set; }
        public string DestCountry { get; set; }

        public decimal TaxCode1Val { get; set; }
        public decimal TaxCode2Val { get; set; }
        public decimal LineTaxCode2Value { get; set; }

        public string GoodDescription { get; set; }
        public string PackName { get; set; }
        public string AgncyID { get; set; }
        public string DocType { get; set; }

        public string PayMode { get; set; }
        public string InvGroup { get; set; }
        public string PreparedBy { get; set; }
        public string OrgInDetail { get; set; }
        public string TaxRegNo1 { get; set; }
        public string AWBRemarks { get; set; }
        public string BillRemarks { get; set; }
        public string ACCNo { get; set; }
        public string ProductS { get; set; }
        public string ProductSN { get; set; }

        public string IsWortermak { get; set; }

        //ksa invs change
        public string OrgEmail { get; set; }
        public string OrgIntName { get; set; }
        public string OrgIntAddr1 { get; set; }
        public string OrgIntAddr2 { get; set; }
        public string ChargeDescInt { get; set; }
    }
    public class FrtInvoiceReportDomainView2
    {
        public int RowID { get; set; }
        public int GroupID { get; set; }
        public int CompanyID { get; set; }
        /// public int AgencyCode { get; set; }
        ///  public string  DocReference { get; set; }	
        public DateTime InvDate { get; set; }
        public DateTime TransDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string InvNo { get; set; }
        public int OrgCode { get; set; }
        public string OrgName { get; set; }
        public string OrgCountry { get; set; }
        public string OrgAddr1 { get; set; }
        public string OrgAddr2 { get; set; }
        public string OrgCity { get; set; }
        public string ChargeCode { get; set; }
        public string ChargeDesc { get; set; }
        public decimal ConvRate { get; set; }
        public string LocalCurrency { get; set; }
        public string ForiengCurrency { get; set; }
        public decimal LineLCAmount { get; set; }
        public decimal LineFCAmount { get; set; }

        public string DebtorLCCurrency { get; set; }
        public string DebtorFLCurrency { get; set; }
        public decimal DebtorFCTotAmount { get; set; }
        public decimal DebtorLCTotAmount { get; set; }

        ///   public decimal LineTaxTotal { get; set; }
        /// public decimal LineTotalAmount { get; set; }	
        public string Remarks { get; set; }
        public string AgnAWBNo { get; set; }

        public string SvcType { get; set; }
        //public string SvcTypeN { get; set; }
        public string PackType { get; set; }
        // public string PackTypeN { get; set; }
        public int TotPkgs { get; set; }
        public decimal TotWgt { get; set; }
        public string WgtU { get; set; }
        public decimal BillWgt { get; set; }
        public string BillWgtU { get; set; }
        public decimal DimVol { get; set; }
        public decimal RexWgt { get; set; }
        public decimal RexVol { get; set; }
        public string DocNdoc { get; set; }
        public decimal FuelShgPer { get; set; }
        public string Shipper { get; set; }
        public string Consingnee { get; set; }
        public string OrginCounty { get; set; }
        public string DestCountry { get; set; }

        public decimal TaxCode1Val { get; set; }
        public decimal TaxCode2Val { get; set; }
        public decimal LineTaxCode2Value { get; set; }

        public string GoodDescription { get; set; }
        public string PackName { get; set; }
        public string AgncyID { get; set; }
        public string DocType { get; set; }

        public string PayMode { get; set; }
        public string InvGroup { get; set; }
    }
}
