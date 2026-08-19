using Express.Domain.Message;
using Express.Interfaces.Mail;
using Express.View.Domain.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Business.Mail
{
    public class SendMailBusiness : IMail<SendMailDomainView>
    {
        IMail<SendMailDomainView> sendMail;
        public SendMailBusiness(IMail<SendMailDomainView> _sendMail)
        {
            this.sendMail = _sendMail;
        }
        public ResponseMessage DeleteDetail(SendMailDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage EditDetails(SendMailDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<SendMailDomainView> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<SendMailDomainView> GetDetails(SendMailDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public List<SendMailDomainView> GetDetails(string code)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage SaveDetails(SendMailDomainView typePara)
        {
            throw new NotImplementedException();
        }

        public ResponseMessage SendMail(SendMailDomainView typePara)
        {
            return sendMail.SendMail(typePara);
        }
    }
}
