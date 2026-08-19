using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.CfgPackTypes")]
    public partial class CfgPackType
    {
        [Key]
        [Column(Order = 0)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string PackType { get; set; }

        [StringLength(50)]
        public string PackTypeN { get; set; }
    }
}
