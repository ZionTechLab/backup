namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SharedMain.RefZipCode")]
    public partial class RefZipCode
    {
        public int CMPY { get; set; }

        [StringLength(2)]
        public string Country { get; set; }

        public int CityCode { get; set; }

        [Key]
        [StringLength(10)]
        public string ZipCode { get; set; }

        [StringLength(10)]
        public string ZipCodeN { get; set; }

        public virtual RefCity cityDetail { get; set; }
    }
}
