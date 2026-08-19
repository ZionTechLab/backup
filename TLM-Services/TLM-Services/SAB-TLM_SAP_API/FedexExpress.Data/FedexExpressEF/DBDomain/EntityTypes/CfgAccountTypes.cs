using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("FinanceGL.CfgAccountTypes")]
    public class CfgAccountTypes
    {
       
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupID { get; set; }

        [StringLength(1)]
        public string PBType { get; set; }

        [Key]
        [StringLength(2)]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ACTYPE { get; set; }

        [StringLength(50)]
        public string ACTYPEN { get; set; }
        public int AcMainCode { get; set; }
        public int AcGroupCode { get; set; }
    }
}
