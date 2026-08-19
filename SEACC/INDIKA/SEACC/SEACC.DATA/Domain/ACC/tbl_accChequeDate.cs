using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEACC.DATA.Domain.ACC
{
    public class tbl_accChequeDate
    {
        //public int p_ID { get; set; }
        public string chequeRegister_ID { get; set; }
        //public DateTime dateRegister_Old { get; set; }
        public DateTime dateRegister_New { get; set; }
        public string modifiedTerminal_ID { get; set; }
        public string modifiedUser_ID { get; set; }
    }
}
