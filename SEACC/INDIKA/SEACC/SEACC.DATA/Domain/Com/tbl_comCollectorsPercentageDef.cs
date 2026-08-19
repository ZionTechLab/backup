using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.Com
{
    public class tbl_comCollectorsPercentageDef
    {
        public int p_ID { get; set; }
        public string collector_ID1 { get; set; }
        public string collector_ID2 { get; set; }
        public string collector_1 { get; set; }
        public string collector_2 { get; set; }
        public decimal percentage1 { get; set; }
        public decimal percentage2 { get; set; }
        public bool isActive { get; set; }
        public string user_ID { get; set; }
        //public string createdUser_ID { get; set; }
        //public string modifiedUser_ID { get; set; }
        //public DateTime dateCreated { get; set; }
        //public DateTime dateModified { get; set; }
    }
       
}
