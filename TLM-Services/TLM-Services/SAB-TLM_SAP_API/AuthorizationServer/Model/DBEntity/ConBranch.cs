namespace AuthorizationServer.Model.DBEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project.ConBranches")]
    public partial class ConBranch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConBranch()
        {
            ConUserBranches = new HashSet<ConUserBranch>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string BranchCode { get; set; }

        [StringLength(30)]
        public string BranchName { get; set; }

        [StringLength(1)]
        public string Active { get; set; }

        public virtual ConCompany ConCompany { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConUserBranch> ConUserBranches { get; set; }
    }
}
