namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Express.CfgProductsMap")]
    public partial class CfgProductsMap
    {
        public int CMPY { get; set; }

        [StringLength(1)]
        public string ShipType { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string ProductM { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string ProductS { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string SvcType { get; set; }

        [StringLength(5)]
        public string PackType { get; set; }

        [StringLength(1)]
        public string DocNDoc { get; set; }
    }
}
