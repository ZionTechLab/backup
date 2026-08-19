using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Crm.CfgMaritalStatus")]
    public partial class CfgMaritalStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StatusCode { get; set; }

        [StringLength(50)]
        public string StatusName { get; set; }

        [StringLength(1)]
        public string active { get; set; }
    }
}
