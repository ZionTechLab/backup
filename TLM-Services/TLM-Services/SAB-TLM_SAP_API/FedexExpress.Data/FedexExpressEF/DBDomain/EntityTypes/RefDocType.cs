using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("FinancePR.RefDocTypes")]
    public partial class RefDocType
    {
        public int CMPY { get; set; }

        [Required]
        [StringLength(10)]
        public string DocId { get; set; }

        [Key]
        [StringLength(7)]
        public string DocType { get; set; }

        [StringLength(10)]
        public string DocTypeSub { get; set; }

        [StringLength(50)]
        public string DocTypeN { get; set; }

        [StringLength(50)]
        public string DocTypeSubN { get; set; }

        [StringLength(5)]
        public string Group1 { get; set; }

        [StringLength(5)]
        public string Group2 { get; set; }

        [StringLength(5)]
        public string Group3 { get; set; }

        [StringLength(5)]
        public string Group4 { get; set; }

        [StringLength(5)]
        public string Group5 { get; set; }

        [StringLength(5)]
        public string Mode { get; set; }

        [StringLength(10)]
        public string GlDebtorsLoc { get; set; }

        [StringLength(10)]
        public string GlDebtorsFor { get; set; }

        [StringLength(10)]
        public string GlCreditorsLoc { get; set; }

        [StringLength(10)]
        public string GlCreditorsFor { get; set; }

        [StringLength(1)]
        public string Active { get; set; }
    }
}
