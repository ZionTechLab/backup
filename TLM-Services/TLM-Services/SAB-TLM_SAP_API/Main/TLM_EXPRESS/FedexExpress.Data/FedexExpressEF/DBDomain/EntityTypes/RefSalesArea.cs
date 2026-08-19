namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Express.RefSalesArea")]
    public partial class RefSalesArea
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        public string SalesAreaGroup { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string SalesAreaID { get; set; }

        [Required]
        [StringLength(50)]
        public string SalesAreaName { get; set; }

        [Required]
        [StringLength(10)]
        public string SalesPerID { get; set; }

        [StringLength(10)]
        public string BranchCode { get; set; }


        [StringLength(100)]
        public string Remarks { get; set; }

        [StringLength(1)]
        public string Active { get; set; }

        //public virtual ConCompany ConCompany { get; set; }
    }
}
