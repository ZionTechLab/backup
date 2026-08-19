using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Express.Data.FedexExpressEF.DBDomain.ComplexTypes
{
    [NotMapped]
    public partial class CountryResult
    {
            public string WoRegion { get; set; } 
            public string  WoRegionN { get; set; }
            public string  Country { get; set; }
            public string CountryN { get; set; }
            public bool Active { get; set; }
    }
}
