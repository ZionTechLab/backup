namespace AuthorizationServer.Model.DBEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project.ConUserBranches")]
    public partial class ConUserBranch
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UsmId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string BranchCode { get; set; }

        public int? DefBranch { get; set; }

        public virtual ConBranch ConBranch { get; set; }

        public virtual ConCompany ConCompany { get; set; }

        public virtual ConUserDetail ConUserDetail { get; set; }
    }
}
