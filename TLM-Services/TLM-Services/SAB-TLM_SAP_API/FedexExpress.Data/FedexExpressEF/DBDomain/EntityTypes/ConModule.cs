namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project.ConModules")]
    public partial class ConModule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConModule()
        {
            ConCompanyModules = new HashSet<ConCompanyModule>();
            ConModulesUserRollsHeds = new HashSet<ConModulesUserRollsHed>();
            ConUserAccesses = new HashSet<ConUserAccess>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModuleID { get; set; }

        [Required]
        [StringLength(50)]
        public string ModuleName { get; set; }

        public int SeqNo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConCompanyModule> ConCompanyModules { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConModulesUserRollsHed> ConModulesUserRollsHeds { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConUserAccess> ConUserAccesses { get; set; }
    }
}
