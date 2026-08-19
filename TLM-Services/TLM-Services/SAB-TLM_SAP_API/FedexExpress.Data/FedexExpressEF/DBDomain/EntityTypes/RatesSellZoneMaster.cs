namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Express.RatesSellZoneMaster")]
    public partial class RatesSellZoneMaster
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


        //[Key]
        //[Required]
        //[Column(Order = 3)]
        //[StringLength(2)]

        [Key]
        [Column(Order = 3)]
        [StringLength(5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Zone { get; set; }


        //[Key]
        //[Column(Order = 4)]
        //[Required]
        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public decimal Weight { get; set; }

        public decimal? Rate { get; set; }

        [StringLength(1)]
        public string Perkg { get; set; }
    }
}
