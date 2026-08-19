using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Project.CfgCountry")]
    public partial class CfgCountry
    {
        [Key]
        [StringLength(2)]
        public string Country { get; set; }

        [StringLength(40)]
        public string CountryN { get; set; }

        [StringLength(1)]
        public string Active { get; set; }
    }
}
