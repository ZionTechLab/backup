using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Project.SystemUserRolesAccess")]
    public class SystemUserRolesAccess
    {
        [Key]
        [Column(Order = 0)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        public int UsmId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string RoleID { get; set; }

        [Key]
        [Column(Order = 3)]
        public int MenuCode { get; set; }

        public bool? OView { get; set; }

        public bool? ONew { get; set; }

        public bool? OEdit { get; set; }

        public bool? ODelete { get; set; }

        public bool? OPrint { get; set; }

        public bool? OPrivew { get; set; }

        public bool? OProcess { get; set; }

        public bool? OImport { get; set; }

        public bool? OExport { get; set; }

        [StringLength(5)]
        public string ActivityList { get; set; }

        //public virtual ConUserRoles ConUserRole { get; set; }
    }
}
