namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Express.RefVisaRoots")]
    public partial class RefVisaRoot
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string VisaRootID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AgncyCode { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string AgncyID { get; set; }

        [Required]
        [StringLength(50)]
        public string VisaRootName { get; set; }

        [StringLength(3)]
        public string OrgHub { get; set; }

        [StringLength(3)]
        public string DesHub { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [StringLength(1)]
        public string Active { get; set; }
    }
}
