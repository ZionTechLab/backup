using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.CfgExgRatTarifTypes")]
    public partial class CfgExgRatTarifType
    {
        [Key]
        [Column(Order = 0)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExgRatTarif { get; set; }

        [StringLength(50)]
        public string ExgRatTarifN { get; set; }

        [StringLength(50)]
        public string CurrencyFrom { get; set; }
        [StringLength(50)]
        public string CurrencyTo { get; set; }

        [StringLength(1)]
        public string Active { get; set; }
    }
}
