namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Express.cfgCityType")]
    public partial class cfgCityType
    {

        [Key]
        [StringLength(5)]
        public string CityType { get; set; }

        [StringLength(15)]
        public string CityTypeN { get; set; }
    }
}
