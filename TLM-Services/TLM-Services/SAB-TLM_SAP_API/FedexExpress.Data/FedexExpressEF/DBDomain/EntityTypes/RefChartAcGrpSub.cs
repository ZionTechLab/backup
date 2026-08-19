using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("FinanceGL.RefChartAcGrpSub")]
    public  class RefChartAcGrpSub
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(5)]
        public string MGroupCode { get; set; }

        [StringLength(3)]
        public string SGroupCode { get; set; }

        public string SGroupName { get; set; }
        public string Rcancel { get; set; }
    }
}
