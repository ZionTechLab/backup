using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{


    [Table("Express.RefTransTimeDomLT")]
    public partial class RefTransTimeDomLT
    {
        public int CMPY { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Location { get; set; }

        [StringLength(5)]
        public string TimeLastPick { get; set; }

        [StringLength(50)]
        public string TimeComit { get; set; }
    }
}
