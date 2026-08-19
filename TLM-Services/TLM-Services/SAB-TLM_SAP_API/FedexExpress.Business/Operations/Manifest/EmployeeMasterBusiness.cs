using Express.Interfaces.Operations.Manifest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
using Express.View.Domain.Operations.Manifest;

namespace Express.Business.Operations.Manifest
{
    public class EmployeeMasterBusiness : IEmployeeMaster<EmployeeMasterView>
    {
        private IEmployeeMaster<EmployeeMasterView> employeeMasterDataProvider;

        public EmployeeMasterBusiness(IEmployeeMaster<EmployeeMasterView> employeeMaster)
        {
            this.employeeMasterDataProvider = employeeMaster;
        }

        public ResponseMessage DeleteDetail(EmployeeMasterView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(EmployeeMasterView typePara)
        {
            return employeeMasterDataProvider.EditDetails(typePara);
        }

        public List<EmployeeMasterView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<EmployeeMasterView> GetDetails(EmployeeMasterView typePara)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeMasterView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public IList<EmployeeMasterView> GetEmployeeMasterGrid()
        {
            return employeeMasterDataProvider.GetEmployeeMasterGrid();
        }

        public ResponseMessage SaveDetails(EmployeeMasterView typePara)
        {
            return employeeMasterDataProvider.SaveDetails(typePara);
        }
    }
}
