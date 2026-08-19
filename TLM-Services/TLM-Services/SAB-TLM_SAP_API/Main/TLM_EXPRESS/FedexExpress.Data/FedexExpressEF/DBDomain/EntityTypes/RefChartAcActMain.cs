using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
 

    [Table("FinanceGL.RefChartAcActMain")]
    public partial class RefChartAcActMain
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string AcType { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string MGroupCode { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(5)]
        public string SGroupCode { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(4)]
        public string AcmainCode { get; set; }

        [StringLength(100)]
        public string AcmainName { get; set; }

        [StringLength(5)]
        public string RCODE { get; set; }

        [StringLength(1)]
        public string RCANCEL { get; set; }
    }
}
