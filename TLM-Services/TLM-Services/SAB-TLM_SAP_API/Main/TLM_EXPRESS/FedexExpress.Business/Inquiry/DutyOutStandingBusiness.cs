using Express.Interfaces.Inquiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Business.Inquiry
{
    public class DutyOutStandingBusiness: IDutyOutstanding
    {
        private readonly IDutyOutstanding _iDutyOutstanding;
        public DutyOutStandingBusiness(IDutyOutstanding _iDutyOutstanding)
        {
            this._iDutyOutstanding = _iDutyOutstanding;
        }
    }
}
