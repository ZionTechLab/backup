using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.View.Domain.Operations.Manifest
{
    public class WebManifestDomainView
    {
        public bool Deleted { get; set; }
        public int CMPY { get; set; }
        public int AgncyCode { get; set; }
        public string AgncyID { get; set; }
        public string ORIGINGate { get; set; }
        public string DESTINGate { get; set; }
        public string StationID { get; set; }
        public string RouteID { get; set; }
        public string ConsId { get; set; }
        public string ShipType { get; set; }
        public string TransMode { get; set; }
        public string AgnAWBNo { get; set; }
        public string AgnMpsNo { get; set; }
        public string AgnTrackNo { get; set; }
        public string ORIGIN { get; set; }
        public string DESTIN { get; set; }
        public string ORGCOUNTRY { get; set; }
        public string DESCOUNTRY { get; set; }
        public DateTime ShipDate { get; set; }
        public string ShipLocationType { get; set; }
        public string SenAccount { get; set; }
        public string SenPhone { get; set; }
        public string SenCountry { get; set; }
        public string SenCode { get; set; }
        public string SenCompany { get; set; }
        public string SenID { get; set; }
        public string SenName { get; set; }
        public string SenAddr1 { get; set; }
        public string SenAddr2 { get; set; }
        public int SenCity { get; set; }
        public string SenCityN { get; set; }
        public string SenState { get; set; }
        public string SenZip { get; set; }
        public string RecAccount { get; set; }
        public string RecPhone { get; set; }
        public string RecCountry { get; set; }
        public string RecCode { get; set; }
        public string RecCompany { get; set; }
        public string RecName { get; set; }
        public string RecAddr1 { get; set; }
        public string RecAddr2 { get; set; }
        public int RecCity { get; set; }
        public string RecCityN { get; set; }
        public string RecState { get; set; }
        public string RecZip { get; set; }
        public int TotPkgs { get; set; }
        public string SvcType { get; set; }
        public string PackType { get; set; }
        public decimal TotWgt { get; set; }
        public string WgtU { get; set; }
        public decimal DimVol { get; set; }
        public string DimVolU { get; set; }
        public decimal RexWgt { get; set; }
        public string RexWgtU { get; set; }
        public decimal RexVol { get; set; }
        public string RexVolU { get; set; }
        public decimal CarriageVal { get; set; }
        public string CarriageValCur { get; set; }
        public decimal CustomVal { get; set; }
        public string CustomValCur { get; set; }
        public string Descrip { get; set; }
        public string SenRefNotes { get; set; }
        public string DocNdoc { get; set; }
        public string HoldAtLoc { get; set; }
        public string BillTransChg { get; set; }
        public string BillTransAcNo { get; set; }
        public string BillDtaxChg { get; set; }
        public string BillDtaxAcNo { get; set; }
        public DateTime IntComDate { get; set; }
        public TimeSpan IntComTime { get; set; }
        public decimal CustomsPkgVal { get; set; }
        public string CustomsCurr { get; set; }
        public decimal ConvRate { get; set; }
        public decimal TotalDutyVal { get; set; }
        public string ShipValueType { get; set; }
        public int ShipValueTypeCata { get; set; }
        public string DutyExcemptY { get; set; }
        public string DetainedY { get; set; }

        public decimal DutythreshLC { get; set; }
        public int ClearStatuesCode { get; set; }
        public string ClearStatusN { get; set; }
        public int BillOrgCode { get; set; }
        public string BillOrgName { get; set; }
        public string BillDTaxCreditY { get; set; }
        public string Remarks { get; set; }
        public int ConsoleType { get; set; }
        public string ConsoleTypeN { get; set; }
        public string Base { get; set; }
        public string Form { get; set; }
        public string USM_LOGIN { get; set; }
        public DateTime USM_DATE { get; set; }


    }
}
