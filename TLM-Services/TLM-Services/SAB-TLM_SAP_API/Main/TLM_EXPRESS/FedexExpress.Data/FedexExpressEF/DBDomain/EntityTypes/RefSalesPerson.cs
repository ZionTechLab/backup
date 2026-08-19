using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.RefSalesPerson")]
    public partial class RefSalesPerson
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GroupID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string SalesPerID { get; set; }

        [StringLength(50)]
        public string SalesPerName { get; set; }

        public int UsmId { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        [StringLength(1)]
        public string Active { get; set; }
    }
}
