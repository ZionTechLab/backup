namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Express.cfgHorizontalMenuItem")]
    public partial class cfgHorizontalMenuItem
    {
        [Key]
        public int MenuIdx { get; set; }

        [Required]
        [StringLength(50)]
        public string MenuName { get; set; }

        [Required]
        [StringLength(50)]
        public string MenuText { get; set; }
    }
}
