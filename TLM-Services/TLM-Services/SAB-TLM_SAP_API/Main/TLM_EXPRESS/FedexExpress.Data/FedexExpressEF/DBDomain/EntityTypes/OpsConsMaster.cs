using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.OpsConsMaster")]
    public partial class OpsConsMaster
    {
        public bool? Deleted { get; set; }

        public int GroupID { get; set; }

        public int CMPY { get; set; }

        public int AgncyCode { get; set; }

        [Required]
        [StringLength(10)]
        public string AgncyID { get; set; }

        [StringLength(1)]
        public string ShipType { get; set; }

        [StringLength(1)]
        public string TransMode { get; set; }

        [Key]
        [StringLength(15)]
        public string ExpressCons { get; set; }

        [Required]
        [StringLength(12)]
        public string ConsId { get; set; }

        public DateTime TransDate { get; set; }

        [Required]
        [StringLength(10)]
        public string VisaRootID { get; set; }

        [Required]
        [StringLength(5)]
        public string OrgHubID { get; set; }

        [Required]
        [StringLength(5)]
        public string DesHubID { get; set; }

        [Required]
        [StringLength(3)]
        public string AlNumCode { get; set; }

        [StringLength(10)]
        public string FlightNo { get; set; }

        public DateTime? AriDate { get; set; }

        public DateTime? DepDate { get; set; }

        public TimeSpan? AriTime { get; set; }

        public TimeSpan? DepTime { get; set; }

        [StringLength(15)]
        public string MAWBNo { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ALActWgt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ALChgWgt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AlFreightChg { get; set; }

        [StringLength(5)]
        public string Currency { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [StringLength(1)]
        public string HighValueY { get; set; }
    }
}