using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Project.CfgCurrency")]
    public class CfgCurrencies
    {
        //'dbo.CfgCurrencies'.
        public bool? Deleted { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Currency { get; set; }
        public string CurrencyN { get; set; }
        public string Country { get; set; }
        public string Active { get; set; }
    }
}
