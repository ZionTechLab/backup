using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.FedexExpressEF.DBDomain.EntityTypes
{
    [Table("Express.AudEmails")]
    public partial class AudEmail
    {
        [Key]
        public int Send_ID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Reference_No { get; set; }

        public bool? Mail_Status { get; set; }

        [StringLength(200)]
        public string Exception { get; set; }

        [StringLength(100)]
        public string Sender_ID { get; set; }

        [StringLength(200)]
        public string Reciver_ID { get; set; }

        [StringLength(50)]
        public string Email_Area { get; set; }

        public int USM_ID { get; set; }

        public DateTime USM_DATE { get; set; }
    }
}
