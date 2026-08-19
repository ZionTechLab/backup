namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Express.CfgProductsMain")]
    public partial class CfgProductsMain
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CfgProductsMain()
        {
            //RatesSellZoneCustTariffs = new HashSet<RatesSellZoneCustTariff>();
            RatesSellZoneMasterHeds = new HashSet<RatesSellZoneMasterHed>();
            RatesSellCountryMasterHeds = new HashSet<RatesSellCountryMasterHed>();
            //RatesSellCountryCustTariff = new HashSet<RatesSellCountryCustTariff>();
            //RatesSellCountryCustSpecHeds = new HashSet<RatesSellCountryCustSpecHed>();
            RatesCostAgnZoneMasterHeds = new HashSet<RatesCostAgnZoneMasterHed>();
            RatesCostAgnCountryMasterHeds = new HashSet<RatesCostAgnCountryMasterHed>();
            RatesCostAgnZoneCustTariffs = new HashSet<RatesCostAgnZoneCustTariff>();
            RatesCostAgnCountryCustTariffs = new HashSet<RatesCostAgnCountryCustTariff>();

        }


        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AgncyCode { get; set; }

        [Required]
        [StringLength(1)]
        public string ShipType { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(3)]
        public string ProductM { get; set; }

        [StringLength(50)]
        public string ProductMN { get; set; }

        [StringLength(1)]
        public string PaidByLF { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RatesSellZoneMasterHed> RatesSellZoneMasterHeds { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<RatesSellZoneCustTariff> RatesSellZoneCustTariffs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RatesSellCountryMasterHed> RatesSellCountryMasterHeds { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<RatesSellCountryCustTariff> RatesSellCountryCustTariff { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<RatesSellCountryCustSpecHed> RatesSellCountryCustSpecHeds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RatesCostAgnZoneMasterHed> RatesCostAgnZoneMasterHeds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RatesCostAgnCountryMasterHed> RatesCostAgnCountryMasterHeds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RatesCostAgnZoneCustTariff> RatesCostAgnZoneCustTariffs { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RatesCostAgnCountryCustTariff> RatesCostAgnCountryCustTariffs { get; set; }
        

    }
}
