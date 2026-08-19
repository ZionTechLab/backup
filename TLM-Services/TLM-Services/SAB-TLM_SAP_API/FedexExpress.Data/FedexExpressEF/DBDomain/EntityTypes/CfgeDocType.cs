using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("eDoc.RefeDocType")]
    public partial class CfgeDocType
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModuleId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(3)]
        public string AreaCode { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(3)]
        public string eDoctype { get; set; }

        [StringLength(30)]
        public string eDoctypeN { get; set; }

        [StringLength(100)]
        public string Remarks { get; set; }

        [StringLength(1)]
        public string Active { get; set; }
    }
}
