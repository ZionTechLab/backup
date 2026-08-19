using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Crm.RefDesignation")]
    public partial class RefDesignation
    {
        [Key]
        public int DesignationID { get; set; }

        [Required]
        [StringLength(5)]
        public string DesignationCode { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(1)]
        public string Active { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
    }
}
