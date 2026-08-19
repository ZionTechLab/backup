namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Express.RatesSellCountryMaster")]
    public partial class RatesSellCountryMaster
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AgncyCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SellMastRateNo { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(2)]
        public string Country { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal Weight { get; set; }

        public decimal? Rate { get; set; }

        [StringLength(1)]
        public string Perkg { get; set; }

        public virtual RefCountryExpress RefCountry { get; set; }
    }
}
