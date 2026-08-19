namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FinancePR.RefChargeCodes")]
    public partial class RefChargeCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RefChargeCode()
        {
            RefChargeCodesInvoices = new HashSet<RefChargeCodesInvoice>();
        }

        [Key]
        [Column(Order = 0)]
        public byte CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string ChargeCode { get; set; }

        [StringLength(50)]
        public string ChargeDesc { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        [StringLength(1)]
        public string Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefChargeCodesInvoice> RefChargeCodesInvoices { get; set; }
    }
}
