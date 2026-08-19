using Express.Interfaces.Common;
using Express.View.Domain.Login;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Operations.Manifest
{
    public interface IRouteMaster<T> : IDataAccess<T> where T : class
    {
        IList<RouteMasterView> GetRoutMasterGrid();
        
    }
    
}
