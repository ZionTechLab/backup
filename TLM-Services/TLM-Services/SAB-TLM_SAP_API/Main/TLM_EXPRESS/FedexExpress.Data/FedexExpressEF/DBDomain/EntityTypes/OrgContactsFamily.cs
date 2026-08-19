using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Crm.OrgContactsFamily")]
    public partial class OrgContactsFamily
    {
        [Key]
        public int FamilyDetailId { get; set; }
        public int OrgCode { get; set; }
        public int ContactCode { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(100)]
        public string Hobbies { get; set; }

        [StringLength(200)]
        public string Education { get; set; }

        [StringLength(1)]
        public string IsSpouse { get; set; }
    }
}
