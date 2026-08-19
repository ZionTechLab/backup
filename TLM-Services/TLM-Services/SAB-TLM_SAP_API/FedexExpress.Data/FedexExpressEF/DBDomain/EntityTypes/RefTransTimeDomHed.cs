using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.RefTransTimeDomHed")]
    public partial class RefTransTimeDomHed
    {
        public int CMPY { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TransTimeCode { get; set; }

        [StringLength(50)]
        public string TransTimeCodeN { get; set; }
    }
}
