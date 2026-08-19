namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Express.CfgParam1")]
    public partial class CfgParam1
    {
        [Key]
        public int keyFeild { get; set; }

        public int? CMPY { get; set; }

        [StringLength(1)]
        public string ExpressIDa { get; set; }

        public int? ExpressIDb { get; set; }

        public int? SellMastRateNo { get; set; }

        public int? CostMastRateNo { get; set; }

        public int? SellCustRateTariffNo { get; set; }

        public int? CostCustRateTariffNo { get; set; }

      
        

        [Column(TypeName = "numeric")]
        public decimal? InvNoTransChg { get; set; }
    }
}
