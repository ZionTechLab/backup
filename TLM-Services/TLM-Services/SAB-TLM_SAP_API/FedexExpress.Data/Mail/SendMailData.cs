using Express.Data.Common;
using Express.Data.FedexExpressEF;
using Express.Data.FedexExpressEF.DBDomain.EntityTypes;
using Express.Domain.Message;
using Express.Interfaces.Mail;
using Express.View.Domain.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Data.Mail
{
    public class SendMailData : IMail<SendMailDomainView>
    {
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
            ResponseMessage mMessage = new ResponseMessage();
            SendMail newMail = new SendMail();
            string Excep = "";
            bool status = false;

            try
            {
                if (newMail.SendEMail(typePara.ToEmail, typePara.EmailSubject, typePara.EmailBody, typePara.Attachment, typePara.ReferenceNo.ToString(), typePara.EmailCoppyTo, typePara.FromEmail, typePara.FromEmailPassword))
                {
                    status = true;
                }
            }
            catch (Exception exx)
            {
                Excep = exx.Message.ToString();
                status = false;
            }

            using (IExpressUnitOfWork<AudEmail> uof = new ExpressUnitOfWork<AudEmail>())
            {
                var mailDetail = new AudEmail
                {


                    Reference_No = typePara.ReferenceNo,
                    Exception = Excep,
                    Mail_Status = status,
                    Reciver_ID = typePara.ToEmail,
                    Sender_ID = typePara.FromEmail,
                    Email_Area = typePara.Email_Area,
                    USM_DATE = typePara.USM_DATE,
                    USM_ID = typePara.USM_ID,

                };
                uof.Reposotery.SaveDetails(mailDetail);
                uof.Commit();
                mMessage.IsSuccess = true;
                mMessage.StrMessage = AppMessage.SaveSuccess;
            }


            return mMessage;
        }
    }
}
