namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project.ConSystemMenuOptions")]
    public partial class ConSystemMenuOption
    {
        [Key]
        [StringLength(1)]
        public string OptionID { get; set; }

        [StringLength(20)]
        public string OptionName { get; set; }
    }
}
