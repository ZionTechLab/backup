namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Express.RatesCostAgnZoneMasterHed")]
    public partial class RatesCostAgnZoneMasterHed
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
        [StringLength(3)]
        public string ProductM { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(5)]
        public string ProductS { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CostMastRateNo { get; set; }

        [StringLength(50)]
        public string CostMastRateName { get; set; }

        [StringLength(1)]
        public string StandRate { get; set; }

        [StringLength(1)]
        public string Active { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        public int? ZoneChartNo { get; set; }

        [StringLength(1)]
        public string FuelChartFixed { get; set; }

        public int? FuelChart { get; set; }

        public decimal? FuelFixedPer { get; set; }

        [StringLength(3)]
        public string Currency { get; set; }

        public short? Usm_Id { get; set; }

        public DateTime? Usm_Date { get; set; }

        public virtual CfgProductsMain CfgProductsMain { get; set; }

        public virtual CfgProductsSub CfgProductsSub { get; set; }
        public virtual RefZonesHed RefZonesHed { get; set; }


    }
}
