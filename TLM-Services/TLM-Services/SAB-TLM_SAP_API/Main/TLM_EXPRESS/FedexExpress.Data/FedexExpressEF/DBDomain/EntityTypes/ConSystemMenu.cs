namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project.ConSystemMenu")]
    public partial class ConSystemMenu
    {
        [Key]
        public int MenuIdx { get; set; }

        public int MenuCode { get; set; }

        [Required]
        [StringLength(50)]
        public string MenuName { get; set; }

        [Required]
        [StringLength(70)]
        public string MenuText { get; set; }

        [StringLength(100)]
        public string MenuLink { get; set; }

        public int MenuLevelID { get; set; }

        public int MenuParentID { get; set; }

        [Required]
        
        public int ModuleID { get; set; }

        [StringLength(1)]
        public string OView { get; set; }

        [StringLength(1)]
        public string ONew { get; set; }

        [StringLength(1)]
        public string OEdit { get; set; }

        [StringLength(1)]
        public string ODelete { get; set; }

        [StringLength(1)]
        public string OPrint { get; set; }

        [StringLength(1)]
        public string OPrivew { get; set; }

        [StringLength(1)]
        public string OProcess { get; set; }

        [StringLength(1)]
        public string OImport { get; set; }

        [StringLength(1)]
        public string OExport { get; set; }

        public int CMPY { get; set; }

        public int AGCY { get; set; }
    }
}
