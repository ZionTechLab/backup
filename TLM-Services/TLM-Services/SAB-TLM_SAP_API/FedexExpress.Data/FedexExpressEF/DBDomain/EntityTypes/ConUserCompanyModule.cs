namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project.ConUserCompanyModules")]
    public partial class ConUserCompanyModule
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UsmId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModuleID { get; set; }


        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupId { get; set; }

        public int UserRollId { get; set; }

        public string DefaultY { get; set; }

        public virtual ConCompanyModule ConCompanyModule { get; set; }

        public virtual ConUserCompany ConUserCompany { get; set; }
        //[Key]
        //[Column(Order = 0)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int UsmId { get; set; }

        //[Key]
        //[Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int ModuleID { get; set; }

        //[Key]
        //[Column(Order = 2)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int CompID { get; set; }

        //[Key]
        //[Column(Order = 3)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //public int AgncyCode { get; set; }

        //public int UserRollId { get; set; }

        //[Required]
        //[StringLength(1)]
        //public string DefaultY { get; set; }

        //public int GroupId { get; set; }

        ////public int UserRollId { get; set; }

        ////public string DefaultY { get; set; }

        //public virtual ConCompanyModule ConCompanyModule { get; set; }

        //public virtual ConUserCompany ConUserCompany { get; set; }
    }
}
