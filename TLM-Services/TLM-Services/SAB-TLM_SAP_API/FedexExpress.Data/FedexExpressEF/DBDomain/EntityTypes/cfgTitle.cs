namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project.cfgTitle")]
    public partial class cfgTitle
    {
        public int ID { get; set; }

        [StringLength(5)]
        public string Title { get; set; }
    }
}
