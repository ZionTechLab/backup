namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SharedMain.RefWorldRegion")]
    public partial class RefWorldRegion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RefWorldRegion()
        {
            RefCountries = new HashSet<RefCountry>();
        }

        public int CMPY { get; set; }

        [Key]
        [StringLength(5)]
        public string WoRegion { get; set; }

        [StringLength(50)]
        public string WoRegionN { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefCountry> RefCountries { get; set; }
    }
}
