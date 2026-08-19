using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{

    [Table("Project.SystemUserAccess")]
    public class SystemUserAccess
    {
        [Key]
        [Column(Order = 0)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string RoleID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int MenuCode { get; set; }

        [StringLength(15)]
        public string UserRole { get; set; }

        [StringLength(5)]
        public string ActivityList { get; set; }
    }
}
