
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{

    [Table("FinanceGL.RefChartAcActSub2")]
    public partial class RefChartAcActSub2
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string AcmainCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(3)]
        public string Acsub2Code { get; set; }

        [StringLength(100)]
        public string Acsub2Name { get; set; }

        [StringLength(1)]
        public string Active { get; set; }
    }
}
