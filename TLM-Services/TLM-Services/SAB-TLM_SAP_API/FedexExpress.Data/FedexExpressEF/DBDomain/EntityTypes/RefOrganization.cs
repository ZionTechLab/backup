using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.RefOrganization")]
    public partial class RefOrganization
    {

        
        public bool Deleted { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrgCode { get; set; }

        public int indType { get; set; }

        [StringLength(10)]
        public string SalesAreaID { get; set; }

        [StringLength(10)]
        public string SalesPerID { get; set; }

        [StringLength(10)]
        public string SvcRootID { get; set; }

        [StringLength(1)]
        public string Automated { get; set; }

        public DateTime AutomateDate { get; set; }

        [StringLength(1)]
        public string Active { get; set; }

        public int InactiveCode { get; set; }

        public DateTime AcOpen { get; set; }

        public int ConFormNo { get; set; }

        [StringLength(10)]
        public string FedExAcNo { get; set; }

        [StringLength(10)]
        public string TNTAcNo { get; set; }

        [StringLength(1)]
        public string DeptInvoice { get; set; }

        [StringLength(1)]
        public string InvFreIB { get; set; }

        [StringLength(1)]
        public string InvFreOB { get; set; }

        [StringLength(1)]
        public string InvFre3P { get; set; }

        [StringLength(1)]
        public string InvDutax { get; set; }

        [StringLength(1)]
        public string CredFrIB { get; set; }

        [StringLength(1)]
        public string CredFrOB { get; set; }

        [StringLength(1)]
        public string CredFr3P { get; set; }

        [StringLength(1)]
        public string CredDtax { get; set; }

        [StringLength(1)]
        public string FreInvPkgType { get; set; }

        [StringLength(1)]
        public string OneDtaxInvoice { get; set; }

        [StringLength(1)]
        public string OneFreInvoice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DTaxClearValue { get; set; }


    }
}
