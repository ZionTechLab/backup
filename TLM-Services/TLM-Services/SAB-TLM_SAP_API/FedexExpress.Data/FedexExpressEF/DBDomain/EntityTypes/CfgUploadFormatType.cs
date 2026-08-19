using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.CfgUploadFormatTypes")]
    public partial class CfgUploadFormatType
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AgncyCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string FormatID { get; set; }

        
        [StringLength(50)]
        public string Name { get; set; }
        
        [StringLength(5)]
        public string AgncyID { get; set; }

        [StringLength(5)]
        public string LocalCountry { get; set; }

        [StringLength(1)]
        public string Active { get; set; }



    }
}
