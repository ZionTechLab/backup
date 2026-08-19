namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SharedMain.RefStateRegion")]
    public partial class RefStateRegion
    {
        public int CMPY { get; set; }

        [StringLength(2)]
        public string Country { get; set; }

        [Key]
        [StringLength(2)]
        public string State { get; set; }

        [StringLength(50)]
        public string StateN { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        public virtual RefCountry RefCountry { get; set; }
    }
}
