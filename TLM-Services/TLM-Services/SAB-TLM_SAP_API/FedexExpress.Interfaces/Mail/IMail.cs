using Express.Domain.Message;
using Express.Interfaces.Common;
using Express.View.Domain.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Mail
{
    public interface IMail<T> : IDataAccess<SendMailDomainView> where T : class
    {
        ResponseMessage SendMail(SendMailDomainView typePara);
    }
}
