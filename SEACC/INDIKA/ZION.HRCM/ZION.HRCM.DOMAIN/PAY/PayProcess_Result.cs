using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZION.HRCM.DOMAIN.Comon;

namespace ZION.HRCM.DOMAIN.PAY
{
  public   class PayProcess_Result
    {
        public List<string> ShiftErrors { get; set; }
        public List<string> AttendanceErrors { get; set; }

        public ResponseMessage result { get; set; }
    }
}
