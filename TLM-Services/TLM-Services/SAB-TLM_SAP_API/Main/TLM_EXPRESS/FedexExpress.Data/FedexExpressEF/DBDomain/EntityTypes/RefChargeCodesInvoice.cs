namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FinancePR.RefChargeCodesInvoice")]
    public partial class RefChargeCodesInvoice
    {
        [Key]
        [Column(Order = 0)]
        public byte CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(7)]
        public string DocType { get; set; }

        public short? Seqno { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string ChargeCode { get; set; }

        [StringLength(10)]
        public string GlRevAc { get; set; }

        [StringLength(10)]
        public string GlWipAc { get; set; }

        [StringLength(10)]
        public string GlCosAc { get; set; }

        [StringLength(10)]
        public string GlAccAc { get; set; }

        [StringLength(5)]
        public string TaxCode1 { get; set; }

        [StringLength(5)]
        public string TaxCode2 { get; set; }

        [StringLength(5)]
        public string TaxCode3 { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        [StringLength(1)]
        public string Active { get; set; }

        public virtual RefChargeCode RefChargeCode { get; set; }
    }
}
