using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.CfgLocationTypes")]
    public partial class CfgLocationType
    {

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string LocType { get; set; }

        [StringLength(50)]
        public string LocTypeN { get; set; }

        [StringLength(1)]
        public string SalesLocY { get; set; }

        [StringLength(1)]
        public string ControlAcY { get; set; }

   

    }
}
