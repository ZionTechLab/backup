namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SharedMain.RefCity")]
    public partial class RefCity
    {
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string Country { get; set; }

        [StringLength(5)]
        public string CityType { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CityCode { get; set; }

        [StringLength(5)]
        public string CityID { get; set; }

        [StringLength(50)]
        public string CityN { get; set; }

        [StringLength(2)]
        public string State { get; set; }
    }
}
