namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FinancePR.OrgGroups")]
    public partial class OrgGroup
    {
        public bool Deleted { get; set; }

        public int CMPY { get; set; }

        [Key]
        [Column("OrgGroup")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrgGroup1 { get; set; }

        public int  GroupID { get; set; }

        [StringLength(60)]
        public string OrgGroupName { get; set; }

        [StringLength(1)]
        public string Active { get; set; }
    }
}
