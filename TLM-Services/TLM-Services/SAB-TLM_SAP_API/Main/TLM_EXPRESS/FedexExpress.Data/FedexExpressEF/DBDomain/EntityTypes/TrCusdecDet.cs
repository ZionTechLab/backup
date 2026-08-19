using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.TrCusdecDet")]
    public partial class TrCusdecDet
    {
        public bool? Deleted { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CusdecNo { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string AgnAWBNo { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string HSCode { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ItemNo { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string ChargeCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueLC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Rate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ValueBase { get; set; }

        [StringLength(1)]
        public string ChargeCodeNF { get; set; }
    }
}
