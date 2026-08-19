using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.RatesExchange")]
    public partial class RatesExchange
    {
        [Key]
        [Column(Order = 0)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExgRateTarif { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "smalldatetime")]
        public DateTime EffectDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ExgRate { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }
    }
}
