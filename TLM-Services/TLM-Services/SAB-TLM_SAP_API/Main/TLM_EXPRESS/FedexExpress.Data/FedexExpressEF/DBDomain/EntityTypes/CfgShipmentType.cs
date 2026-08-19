namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Express.CfgShipmentTypes")]
    public partial class CfgShipmentType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CfgShipmentType()
        {
          
           
        }

        public int CMPY { get; set; }

        [Key]
        [StringLength(1)]
        public string ShipType { get; set; }

        [StringLength(25)]
        public string ShipTypeN { get; set; }

     
       
    }
}
