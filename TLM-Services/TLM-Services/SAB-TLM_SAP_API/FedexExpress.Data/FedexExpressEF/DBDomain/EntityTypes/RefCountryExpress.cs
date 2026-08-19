using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.RefCountry")]
    public class RefCountryExpress
    {

        [Key]
        [StringLength(2)]
        public string Country { get; set; }

        [StringLength(30)]
        public string CountryN { get; set; }

        [StringLength(20)]
        public string Region { get; set; }

        [StringLength(1)]
        public string Active { get; set; }

        [StringLength(20)]
        public string FDXReg { get; set; }

        [StringLength(20)]
        public string MHEReg { get; set; }
    }
}
