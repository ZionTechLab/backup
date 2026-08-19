using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    public class OpsConsAWBResults
    {
        public bool? Deleted { get; set; }
        public int GroupID { get; set; }
        public int CMPY { get; set; }
        public int AgncyCode { get; set; }
        public string AgncyID { get; set; }
        public string ORIGINGate { get; set; }
        public string DESTINGate { get; set; }
        public string StationID { get; set; }
        public string ConsId { get; set; }
        public DateTime TransDate { get; set; }
        public string ShipType { get; set; }
        public string TransMode { get; set; }
        public string MissRoute { get; set; }
        public string ExpressID { get; set; }
        public int ExpressMpsNo { get; set; }
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
        public decimal? TotWgt { get; set; }
        public string WgtU { get; set; }
        public decimal? DimVol { get; set; }
        public string DimVolU { get; set; }
        public decimal? RexWgt { get; set; }
        public string RexWgtU { get; set; }
        public decimal? RexVol { get; set; }
        public string RexVolU { get; set; }
        public decimal? CarriageVal { get; set; }
        public string CarriageValCur { get; set; }
        public decimal? CustomVal { get; set; }
        public string CustomValCur { get; set; }
        public string Descrip { get; set; }
        public string SenRefNotes { get; set; }
        public string DepNotes { get; set; }
        public string DocNdoc { get; set; }
        public string HoldAtLoc { get; set; }
        public string BillTransChg { get; set; }
        public string BillTransAcNo { get; set; }
        public string BillDtaxChg { get; set; }
        public string BillDtaxAcNo { get; set; }
        public string AlertEmail1 { get; set; }
        public string AlertEmail2 { get; set; }
        public string AlertSms1 { get; set; }
        public string AlertSms2 { get; set; }
        public DateTime IntComDate { get; set; }
        public TimeSpan IntComTime { get; set; }
        public DateTime FinComDate { get; set; }
        public TimeSpan FinComTime { get; set; }
        public string TrackClosedY { get; set; }
        public string PickupY { get; set; }
        public string DeliverY { get; set; }
        public string PickScanTypeS { get; set; }
        public string PodScanTypeS { get; set; }
        public string LastScanTypeS { get; set; }
        public DateTime LastScanDate { get; set; }
        public string LatePkg { get; set; }
        public string RWDL { get; set; }
        public DateTime BusDay14 { get; set; }
        public string ScanGap { get; set; }
        public string MisScan { get; set; }
        public string PodYN { get; set; }
        public string slockcode { get; set; }
        public string SpCode { get; set; }
        public string Remarks { get; set; }
        public decimal? AlFreightChg { get; set; }
        public string USM_LOGIN { get; set; }
        public DateTime USM_DATE { get; set; }
        public string DutyExcemptY { get; set; }
        public string DetainedY { get; set; }
        public string BillDTaxChgY { get; set; }
        public string BillTransChgY { get; set; }
        public decimal? InvNoDTaxChg { get; set; }
        public decimal? InvNoTransChg { get; set; }
        public string ScansAll { get; set; }
        public string MHEPackType { get; set; }
        public string ShipValueType { get; set; }
        public decimal? ConvRate { get; set; }
        public decimal? CustomsPkgVal { get; set; }
        public string CustomsCurr { get; set; }
        public decimal? TotalDutyVal { get; set; }

        public string BillDTaxCreditY { get; set; }
        public string RouteID { get; set; }
        public string ShoOvr { get; set; }
        public int? BillOrgCode { get; set; }
        public string  BillOrgName { get; set; }
        public string PayNoDTaxChg { get; set; }
        public string BillOrgAddr1 { get; set; }
        public string BillOrgAddr2 { get; set; }
        public string BillOrgCity { get; set; }
        public string SenCityCode { get; set; }
        public string RecCityCode { get; set; }

    }
}
