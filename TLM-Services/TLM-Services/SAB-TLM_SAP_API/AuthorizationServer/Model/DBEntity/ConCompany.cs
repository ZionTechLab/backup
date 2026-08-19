namespace AuthorizationServer.Model.DBEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project.ConCompany")]
    public partial class ConCompany
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConCompany()
        {
            ConBranches = new HashSet<ConBranch>();
            ConUserBranches = new HashSet<ConUserBranch>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompID { get; set; }

        [StringLength(10)]
        public string CompNameSort { get; set; }

        [StringLength(50)]
        public string CompName { get; set; }

        [StringLength(150)]
        public string Address1 { get; set; }

        [StringLength(150)]
        public string Address2 { get; set; }

        [StringLength(1)]
        public string Active { get; set; }

        public int? DefCompany { get; set; }

        public int? OrgCode { get; set; }

        [Column(TypeName = "image")]
        public byte[] Logo { get; set; }

        [StringLength(50)]
        public string Telephone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(30)]
        public string TaxRegNo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConBranch> ConBranches { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConUserBranch> ConUserBranches { get; set; }
    }
}
