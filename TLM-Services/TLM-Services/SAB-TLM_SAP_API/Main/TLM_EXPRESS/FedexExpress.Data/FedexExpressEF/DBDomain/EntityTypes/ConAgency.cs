using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Project.ConAgency")]
    public partial class ConAgency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AgncyCode { get; set; }

        [StringLength(50)]
        public string AgncyName { get; set; }

        [StringLength(10)]
        public string AgncyID { get; set; }

        public int CMPY { get; set; }

        [StringLength(1)]
        public string AgncyType { get; set; }

        public int ModuleID { get; set; }

        [StringLength(1)]
        public string Active { get; set; }
    }
}