using Express.Interfaces.Operations.Manifest;
using Express.View.Domain.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;

namespace Express.Business.Operations.Manifest
{
    public class RouteMasterBusiness : IRouteMaster<RouteMasterView>
    {
        private IRouteMaster<RouteMasterView> routeMasterDataProvider;

        public RouteMasterBusiness(IRouteMaster<RouteMasterView> routeMaster)
        {
            this.routeMasterDataProvider = routeMaster;
        }

        public ResponseMessage DeleteDetail(RouteMasterView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(RouteMasterView typePara)
        {
             return routeMasterDataProvider.EditDetails(typePara);
        }

        public List<RouteMasterView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<RouteMasterView> GetDetails(RouteMasterView typePara)
        {
            throw new NotImplementedException();
        }

        public List<RouteMasterView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<RouteMasterView> GetRoutMasterGrid()
        {
            return routeMasterDataProvider.GetRoutMasterGrid();
        }

        public ResponseMessage SaveDetails(RouteMasterView typePara)
        {
            return routeMasterDataProvider.SaveDetails(typePara);
        }
    }
}
