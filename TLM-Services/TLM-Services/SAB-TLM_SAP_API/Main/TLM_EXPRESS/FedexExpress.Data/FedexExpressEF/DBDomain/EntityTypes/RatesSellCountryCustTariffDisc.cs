namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Express.RatesSellCountryCustTariffDisc")]
    public partial class RatesSellCountryCustTariffDisc
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SellCustRateTariffNo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string Country { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal Weight { get; set; }

        public decimal? DiscPer { get; set; }

        [StringLength(1)]
        public string Perkg { get; set; }
    }
}
