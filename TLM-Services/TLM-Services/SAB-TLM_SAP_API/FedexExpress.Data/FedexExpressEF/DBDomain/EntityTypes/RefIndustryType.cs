using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{

    [Table("SharedMain.RefIndustryTypes")]
    public partial class RefIndustryType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int indType { get; set; }

        [StringLength(100)]
        public string indTypeN { get; set; }

        [StringLength(1)]
        public string Active { get; set; }
    }
}
