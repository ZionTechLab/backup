using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.MapScanType")]
    public partial class MapScanType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Seqno { get; set; }

        public int CMPY { get; set; }

        public int AgncyCode { get; set; }

        [StringLength(10)]
        public string ScanTypeS { get; set; }

        [StringLength(10)]
        public string ScanTypeP { get; set; }

        [StringLength(50)]
        public string RemarkS { get; set; }

        [StringLength(50)]
        public string RemarkP { get; set; }

        [StringLength(1)]
        public string Active { get; set; }
    }
}
