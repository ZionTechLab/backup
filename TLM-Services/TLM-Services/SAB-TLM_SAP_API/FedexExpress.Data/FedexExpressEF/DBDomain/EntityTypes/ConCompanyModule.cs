namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project.ConCompanyModules")]
    public partial class ConCompanyModule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ConCompanyModule()
        {
            ConUserCompanyModules = new HashSet<ConUserCompanyModule>();
        }


        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModuleID { get; set; }

       // public virtual ConCompany ConCompany { get; set; }

        public virtual ConModule ConModule { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConUserCompanyModule> ConUserCompanyModules { get; set; }
    }
}
