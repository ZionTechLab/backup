using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.RefAirLine")]
    public partial class RefAirLine
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CMPY { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutoID { get; set; }

        public bool Deleted { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string AlNumCode { get; set; }

        [StringLength(3)]
        public string AlThLeCode { get; set; }

        [StringLength(2)]
        public string AlToLeCode { get; set; }

        [StringLength(1)]
        public string Cass { get; set; }

        [StringLength(1)]
        public string Iata { get; set; }

        [StringLength(1)]
        public string Ata { get; set; }

        [StringLength(50)]
        public string AlSname { get; set; }

        [StringLength(50)]
        public string AlLname1 { get; set; }

        [StringLength(50)]
        public string AlLname2 { get; set; }

        [StringLength(50)]
        public string AlAddr1 { get; set; }

        [StringLength(50)]
        public string AlAddr2 { get; set; }

        [StringLength(50)]
        public string AlCity { get; set; }

        [StringLength(40)]
        public string AlState { get; set; }

        [StringLength(10)]
        public string AlPostCode { get; set; }

        [StringLength(2)]
        public string AlCountry { get; set; }

        [StringLength(1)]
        public string Active { get; set; }
    }
}
