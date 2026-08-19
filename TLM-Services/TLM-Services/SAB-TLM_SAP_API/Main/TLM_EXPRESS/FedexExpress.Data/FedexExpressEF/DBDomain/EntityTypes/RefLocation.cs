using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.RefLocations")]
    public partial class RefLocation
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string Country { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string LocationID { get; set; }

        [StringLength(50)]
        public string LocationName { get; set; }

        [StringLength(1)]
        public string Hub { get; set; }

        [StringLength(1)]
        public string GateWay { get; set; }

        [StringLength(1)]
        public string Station { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        [StringLength(1)]
        public string Active { get; set; }
    }
}
