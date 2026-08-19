using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("FinancePR.CfgInvoiceMode")]
    public partial class CfgInvoiceMode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string InvMode { get; set; }

        [StringLength(50)]
        public string InvModeN { get; set; }
    }
}
