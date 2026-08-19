

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("Express.RefHolidays")]
    public partial class RefHolidays
    {
        [Key]
        public int AutoNo { get; set; }

        public bool? Deleted { get; set; }

        public int CMPY { get; set; }

        public DateTime? HolidayDate { get; set; }

        [StringLength(50)]
        public string HolidayReason { get; set; }

        [StringLength(20)]
        public string USM_LOGIN { get; set; }

        public DateTime? USM_DATE { get; set; }
    }
}
