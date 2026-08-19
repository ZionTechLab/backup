namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SharedMain.RefCountry")]
    public partial class RefCountry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RefCountry()
        {
            RefStateRegions = new HashSet<RefStateRegion>();
            RatesSellCountryMasters = new HashSet<RatesSellCountryMaster>();
            RatesSellCountryCustSpecs = new HashSet<RatesSellCountryCustSpec>();
            RatesCostAgnCountryMasters = new HashSet<RatesCostAgnCountryMaster>();
        }
        [Key]
        [Column(Order = 0)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string Country { get; set; }

        [StringLength(50)]
        public string CountryN { get; set; }

        [StringLength(5)]
        public string WoRegion { get; set; }

        public bool? Active { get; set; }

        public virtual RefWorldRegion RefWorldRegion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefStateRegion> RefStateRegions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RatesSellCountryMaster> RatesSellCountryMasters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RatesSellCountryCustSpec> RatesSellCountryCustSpecs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RatesCostAgnCountryMaster> RatesCostAgnCountryMasters { get; set; }
    }
}
