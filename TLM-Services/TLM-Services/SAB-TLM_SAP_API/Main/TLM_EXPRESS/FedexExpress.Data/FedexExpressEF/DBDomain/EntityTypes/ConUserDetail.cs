namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
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
            ConUserAccesses = new HashSet<ConUserAccess>();
            ConUserCompanies = new HashSet<ConUserCompany>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UsmId { get; set; }

        [StringLength(300)]
        public string UsmLogin { get; set; }

        [StringLength(300)]
        public string UsmPass { get; set; }

        public int? Title { get; set; }

        [StringLength(50)]
        public string PreferredName { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        public int? UserRollId { get; set; }

        [StringLength(200)]
        public string Address1 { get; set; }

        [StringLength(200)]
        public string Address2 { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Designation { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [Column(TypeName = "date")]
        public DateTime? JoinDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DepartDate { get; set; }

        [StringLength(1)]
        public string Depart { get; set; }

        [Column(TypeName = "image")]
        public byte[] UserPic { get; set; }

        [StringLength(20)]
        public string WorkPhone { get; set; }

        [StringLength(20)]
        public string WorkExtension { get; set; }

        [StringLength(20)]
        public string Fax { get; set; }

        [StringLength(20)]
        public string HomePhone { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Branch { get; set; }

        [StringLength(50)]
        public string Department { get; set; }

        [StringLength(5)]
        public string DCLCODE { get; set; }

        [StringLength(15)]
        public string DEPT { get; set; }

        [StringLength(10)]
        public string DESIG { get; set; }

        [StringLength(1)]
        public string USM_AE { get; set; }

        [StringLength(1)]
        public string Active { get; set; }

        public DateTime? Last_Date { get; set; }

        public int? Login_Times { get; set; }

        public DateTime LastPassChgDate { get; set; }

        public int PassExpDays { get; set; }

        [StringLength(1)]
        public string ChanePassNext { get; set; }

        public virtual cfgTitle cfgTitle { get; set; }

        public virtual ConUserRoll ConUserRoll { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConUserAccess> ConUserAccesses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConUserCompany> ConUserCompanies { get; set; }
    }
}
