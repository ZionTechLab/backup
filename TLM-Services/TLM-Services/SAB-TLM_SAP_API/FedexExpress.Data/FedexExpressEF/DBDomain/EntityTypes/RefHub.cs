namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Express.RefHubs")]
    public partial class RefHub
    {
        [Required]
        [StringLength(2)]
        public string Country { get; set; }

        [Key]
        [StringLength(3)]
        public string HubID { get; set; }

        [StringLength(50)]
        public string HubName { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [StringLength(1)]
        public string Active { get; set; }
    }
}
