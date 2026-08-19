using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.RefSvcRoots")]
    public partial class RefSvcRoot
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string SvcRootID { get; set; }

        [Required]
        [StringLength(50)]
        public string SvcRootName { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [StringLength(1)]
        public string Active { get; set; }

       // public virtual ConCompany ConCompany { get; set; }
    }
}
