using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
     public partial class GetAWBDuplicateResult
    {
        [StringLength(10)]
        public string AgncyID { get; set; }

        [StringLength(15)]
        public string AgnAWBNo { get; set; }

        public int AgncyCode { get; set; }

        [StringLength(15)]
        public string AgnMpsNo { get; set; }

        [StringLength(15)]
        public string AgnTrackNo { get; set; }

        [StringLength(200)]
        public string AlertEmail1 { get; set; }

        [StringLength(200)]
        public string AlertEmail2 { get; set; }

        [StringLength(15)]
        public string AlertSms1 { get; set; }

        [StringLength(15)]
        public string AlertSms2 { get; set; }

        [StringLength(10)]
        public string BillDtaxAcNo { get; set; }

        [StringLength(1)]
        public string BillDtaxChg { get; set; }

        [StringLength(10)]
        public string BillTransAcNo { get; set; }

        [StringLength(1)]
        public string BillTransChg { get; set; }

        [StringLength(1)]
        public string BillTransChgY { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime BusDay14 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CarriageVal { get; set; }

        [StringLength(5)]
        public string CarriageValCur { get; set; }

        public int CMPY { get; set; }

        [StringLength(12)]
        public string ConsId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CustomVal { get; set; }

        [StringLength(5)]
        public string CustomValCur { get; set; }

        public bool Deleted { get; set; }

        [StringLength(1)]
        public string DeliverY { get; set; }

        [StringLength(2000)]
        public string DepNotes { get; set; }

        [StringLength(5)]
        public string DESCOUNTRY { get; set; }

        [StringLength(4000)]
        public string Descrip { get; set; }

        [StringLength(5)]
        public string DESTIN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DimVol { get; set; }

        [StringLength(1)]
        public string DimVolU { get; set; }

        [StringLength(1)]
        public string DocNdoc { get; set; }

        [StringLength(15)]
        public string ExpressID { get; set; }

        public int ExpressMpsNo { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime FinComDate { get; set; }

        public TimeSpan FinComTime { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime IntComDate { get; set; }

        public TimeSpan IntComTime { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupID { get; set; }

        [StringLength(1)]
        public string HoldAtLoc { get; set; }

        [Column(TypeName = "numeric")]
        public decimal InvNoTransChg { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime LastScanDate { get; set; }

        [StringLength(10)]
        public string LastScanTypeS { get; set; }

        [StringLength(20)]
        public string LatePkg { get; set; }

        [StringLength(30)]
        public string MisScan { get; set; }

        [StringLength(1)]
        public string MissRoute { get; set; }

        [StringLength(5)]
        public string ORGCOUNTRY { get; set; }

        [StringLength(5)]
        public string ORIGIN { get; set; }

        [StringLength(5)]
        public string PackType { get; set; }

        [StringLength(10)]
        public string PickScanTypeS { get; set; }

        [StringLength(1)]
        public string PickupY { get; set; }

        [StringLength(10)]
        public string PodScanTypeS { get; set; }

        [StringLength(3)]
        public string PodYN { get; set; }

        [StringLength(10)]
        public string RecAccount { get; set; }

        [StringLength(200)]
        public string RecAddr1 { get; set; }

        [StringLength(200)]
        public string RecAddr2 { get; set; }

        [StringLength(60)]
        public string RecCityN { get; set; }

        [StringLength(12)]
        public string RecCode { get; set; }

        [StringLength(100)]
        public string RecCompany { get; set; }

        [StringLength(2)]
        public string RecCountry { get; set; }

        [StringLength(100)]
        public string RecName { get; set; }

        [StringLength(15)]
        public string RecPhone { get; set; }

        [StringLength(5)]
        public string RecState { get; set; }

        [StringLength(10)]
        public string RecZip { get; set; }

        [StringLength(200)]
        public string Remarks { get; set; }

        [StringLength(3)]
        public string RWDL { get; set; }

        [StringLength(1)]
        public string ScanGap { get; set; }

        [StringLength(100)]
        public string ScansAll { get; set; }

        [StringLength(10)]
        public string SenAccount { get; set; }

        [StringLength(200)]
        public string SenAddr1 { get; set; }

        [StringLength(200)]
        public string SenAddr2 { get; set; }

        public int? SenCity { get; set; }

        [StringLength(60)]
        public string SenCityN { get; set; }

        [StringLength(12)]
        public string SenCode { get; set; }

        [StringLength(100)]
        public string SenCompany { get; set; }

        [StringLength(2)]
        public string SenCountry { get; set; }

        [StringLength(20)]
        public string SenID { get; set; }

        [StringLength(100)]
        public string SenName { get; set; }

        [StringLength(15)]
        public string SenPhone { get; set; }

        [StringLength(2000)]
        public string SenRefNotes { get; set; }

        [StringLength(5)]
        public string SenState { get; set; }

        [StringLength(10)]
        public string SenZip { get; set; }

        public DateTime ShipDate { get; set; }

        [StringLength(5)]
        public string ShipLocationType { get; set; }

        [StringLength(1)]
        public string ShipType { get; set; }

        [StringLength(5)]
        public string slockcode { get; set; }

        [StringLength(5)]
        public string SpCode { get; set; }

        [StringLength(5)]
        public string SvcType { get; set; }

        public int TotPkgs { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TotWgt { get; set; }

        [StringLength(1)]
        public string TrackClosedY { get; set; }

        public DateTime TransDate { get; set; }

        public DateTime USM_DATE { get; set; }

        [StringLength(20)]
        public string USM_LOGIN { get; set; }

        [StringLength(1)]
        public string WgtU { get; set; }

        [StringLength(5)]
        public string MHEPackType { get; set; }
    }
}
