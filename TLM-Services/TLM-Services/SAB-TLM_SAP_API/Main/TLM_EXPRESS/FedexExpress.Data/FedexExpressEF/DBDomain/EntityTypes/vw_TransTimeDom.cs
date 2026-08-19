using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    
    public partial class vw_TransTimeDom
    {
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TransTimeCode { get; set; }

        [StringLength(50)]
        public string OriginLocation { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OriginLoc { get; set; }

        [StringLength(50)]
        public string DestinationLocation { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DestinLoc { get; set; }

        [StringLength(5)]
        public string TimeLastPick { get; set; }

        [StringLength(50)]
        public string TimeComit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? TransTimeDays { get; set; }

        [StringLength(20)]
        public string USM_LOGIN { get; set; }

        public DateTime? USM_DATE { get; set; }
    }
}
