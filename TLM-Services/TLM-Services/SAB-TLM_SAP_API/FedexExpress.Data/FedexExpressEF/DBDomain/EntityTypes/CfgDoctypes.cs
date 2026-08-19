using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.CfgDoctypes")]
    public class CfgDoctypes
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Doctype { get; set; }

        [StringLength(50)]
        public string DoctypeN { get; set; }

        [StringLength(5)]
        public string DocCata { get; set; }

        [StringLength(1)]
        public string PaidLF { get; set; }
        public int BillOrgCode { get; set; }

       
        public int ExgRateTarif { get; set; }
        public int FuelCostChart { get; set; }
        public int FuelChart { get; set; }

        [StringLength(1)]
        public string Active { get; set; }

    }
}
