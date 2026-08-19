using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.Domain.Message;
namespace Express.Interfaces.Common
{
   public interface IDataAccess<T>   where T :class 
    {
        List<T> GetDetails();
        List<T> GetDetails(string code);
        List<T> GetDetails(T typePara);
        ResponseMessage SaveDetails(T typePara);
        ResponseMessage EditDetails(T typePara);
        ResponseMessage DeleteDetail(T typePara);
    }
}
