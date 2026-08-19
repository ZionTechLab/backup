using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("FinancePR.CfgCreditRating")]
    public partial class CfgCreditRating
    {
        [Key]
        [StringLength(5)]
        public string CreditRate { get; set; }

        [StringLength(50)]
        public string CreditRateN { get; set; }

        [StringLength(1)]
        public string Active { get; set; }
    }
}
