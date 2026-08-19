using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.RefSalesAreaGroup")]
    public partial class RefSalesAreaGroup
    {
        public int CMPY { get; set; }

        [Key]
        [StringLength(10)]
        public string SalesAreaGroup { get; set; }

        [StringLength(50)]
        public string SalesAreaGroupName { get; set; }
    }
}
