using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("FinancePR.RefBranches")]
    public partial class RefBranch
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string BranchCode { get; set; }

        [StringLength(3)]
        public string GlCostCenter { get; set; }

        [StringLength(1)]
        public string Active { get; set; }

        [StringLength(1)]
        public string AfterDelete { get; set; }

        [StringLength(30)]
        public string BranchName { get; set; }

        public int DefBranch { get; set; }
    }
}
