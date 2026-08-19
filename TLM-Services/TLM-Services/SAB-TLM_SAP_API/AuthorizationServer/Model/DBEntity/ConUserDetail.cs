namespace AuthorizationServer.Model.DBEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project.ConUserDetails")]
    public partial class ConUserDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConUserDetail()
        {
            ConUserBranches = new HashSet<ConUserBranch>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UsmId { get; set; }

        [StringLength(15)]
        public string UsmLogin { get; set; }

        [StringLength(300)]
        public string UsmPass { get; set; }

        [StringLength(50)]
        public string PreferredName { get; set; }

        [StringLength(1)]
        public string Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConUserBranch> ConUserBranches { get; set; }
    }
}
