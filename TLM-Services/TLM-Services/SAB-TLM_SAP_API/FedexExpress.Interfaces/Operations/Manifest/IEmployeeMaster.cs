using Express.Interfaces.Common;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Operations.Manifest
{
    public interface IEmployeeMaster<T> : IDataAccess<T> where T : class
    {
        IList<EmployeeMasterView> GetEmployeeMasterGrid();
    }
}
