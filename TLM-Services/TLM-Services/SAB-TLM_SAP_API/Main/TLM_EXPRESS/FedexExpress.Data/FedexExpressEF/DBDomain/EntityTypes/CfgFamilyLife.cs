using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Crm.CfgFamilyLife")]
    public partial class CfgFamilyLife
    {
        [Key]
        public int FamilyLifeId { get; set; }

        [Required]
        [StringLength(5)]
        public string FamilyLifeCode { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        [StringLength(1)]
        public string Active { get; set; }

    }
}
