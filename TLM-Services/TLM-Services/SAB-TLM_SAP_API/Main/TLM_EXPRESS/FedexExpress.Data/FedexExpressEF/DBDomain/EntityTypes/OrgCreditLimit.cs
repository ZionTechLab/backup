using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("FinancePR.OrgCreditLimits")]
    public partial class OrgCreditLimit
    {
        public bool? Deleted { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrgCode { get; set; }

        public decimal? MonthInvAmt { get; set; }

        [StringLength(5)]
        public string CreditRate { get; set; }

        [StringLength(1)]
        public string CredActive { get; set; }

        public DateTime? CredActiveDate { get; set; }

        public decimal? CreditLimit { get; set; }

        public int? CreditDays { get; set; }

        public int? SupCreditDays { get; set; }

        [StringLength(1)]
        public string CashOnly { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        public string DCPerson { get; set; }

        public string DCDesignation { get; set; }

        public string DCContact { get; set; }

        public short? USM_ID { get; set; }

        public DateTime? USM_DATE { get; set; }
    }

}
