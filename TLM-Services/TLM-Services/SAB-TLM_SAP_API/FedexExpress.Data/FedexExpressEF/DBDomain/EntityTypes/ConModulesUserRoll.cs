namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project.ConModulesUserRolls")]
    public partial class ConModulesUserRoll
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModuleID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserRollId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MenuCode { get; set; }

     

        [StringLength(5)]
        public string ActivityList { get; set; }

        public virtual ConModulesUserRollsHed ConModulesUserRollsHed { get; set; }
    }
}
