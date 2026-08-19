using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("FinancePR.RefCompany")]
    public partial class RefCompany
    {
        [Key]
        public byte CMPY { get; set; }

        public int? FinStartMonth { get; set; }

        public int? CurFinMonth { get; set; }

        public int? CurFinYear { get; set; }

        [StringLength(10)]
        public string ProftTransAC { get; set; }

        public int? OrgCode { get; set; }

        [StringLength(50)]
        public string ChqBenName { get; set; }

        [StringLength(100)]
        public string ChqBankName { get; set; }

        [StringLength(60)]
        public string ChqBankAddr1 { get; set; }

        [StringLength(60)]
        public string ChqBankAddr2 { get; set; }

        [StringLength(20)]
        public string ChqBankAcNo { get; set; }

        [StringLength(20)]
        public string ChqSwiftCode { get; set; }

        [StringLength(3)]
        public string LocalCurrency { get; set; }
    }
}
