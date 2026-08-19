namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Express.RatesSellZoneCustSpecHed")]
    public partial class RatesSellZoneCustSpecHed
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
        public int SellCustRateTariffNo { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrgCode { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(3)]
        public string ProductM { get; set; }

        [Required]
        [StringLength(5)]
        public string ProductS { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        [StringLength(1)]
        public string Active { get; set; }

        [StringLength(3)]
        public string Currency { get; set; }

       public int ZoneChartNo { get; set; }

        [StringLength(1)]
        public string FuelChartFixed { get; set; }

        public int? FuelChart { get; set; }

        public decimal? FuelFixedPer { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        public short? Usm_Id { get; set; }

        public DateTime? Usm_Date { get; set; }
    }
}
