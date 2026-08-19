using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;


namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{

    [Table("Express.CfgCurrencyLF")]
    public class CfgCurrencyLF
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
        public string LocCurrency { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(3)]
        public string ForCurrency { get; set; }
    }
}
