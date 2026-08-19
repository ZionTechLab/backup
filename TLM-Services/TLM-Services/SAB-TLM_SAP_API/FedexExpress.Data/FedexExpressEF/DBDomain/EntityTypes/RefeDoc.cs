using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("[eDoc].RefeDoc")]
    public partial class RefeDoc
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string eDocCode { get; set; }

        [StringLength(50)]
        public string eFileName { get; set; }

        [StringLength(5)]
        public string eDocType { get; set; }

        public byte[] eDocImage { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        public int? USM_LOGIN { get; set; }

        public DateTime? USM_DATE { get; set; }

    }
}
