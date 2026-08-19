using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.RatesFuelShg")]
    public partial class RatesFuelShg
    {
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FuelChart { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "smalldatetime")]
        public DateTime EffectDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FuelShg { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }
    }
}
