using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZION.SFA.BE.WebApi.Domain;
//using System.Web.Http;
using ZION.SFA.Data.Admin;
using ZION.SFA.Domain.Admin;
using ZION.SFA.Domain.Message;

namespace ZION.SFA.BE.WebApi.Controllers.Admin
{
    public class UsersController : Controller
    {
        UsersData data = new UsersData();

        [Route("Admin/Get_Users")]
        [HttpGet]
        public List<object> Get_Users()
        {
         //   this._logger.LogInformation(101, "Inoke executing");

            var x = data.Get_Users();
            return x;
        }

        [Route("Admin/Get_SalesMen")]
        [HttpGet]
        public List<object> Get_SalesReps()
        {
            //   this._logger.LogInformation(101, "Inoke executing");

            var x = data.Get_SalesMen();
            return x;
        }

        [Route("Admin/Update_User")]
        [HttpPost]
        public  ResponseMessage  Update_User([FromBody] UserData para)
        {
            var status = data.Update_User(para);
            if(!status.IsSuccess)
                throw new DomainException(status.varOutMsg);
            return  status;
        }
    }
}
