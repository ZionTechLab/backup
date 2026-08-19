using Express.Interfaces.Common;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Operations.Manifest
{
    public interface ISearchClearancePreAlert<T> : IDataAccess<ClearancePreAlertDomainView> where T : class
    {
        IList<ClearancePreAlertDomainView> GetSerchResult(int GroupId, int CMPY, int AgencyId, string Console, string MAWB, string ConsoleNo);
    }
}
