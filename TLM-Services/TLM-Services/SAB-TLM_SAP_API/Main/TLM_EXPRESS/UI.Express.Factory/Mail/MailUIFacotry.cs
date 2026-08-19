using Express.Business.Mail;
using Express.Data.Mail;
using Express.Interfaces.Mail;
using Express.View.Domain.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Factory.Mail
{
   
    public sealed class MailUIFacotry
    {
        private static Dictionary<object, object> servicecontainer = null;
        public MailUIFacotry()
        {

        }
        public static T GetService<T>()
        {
            #region inject services
            if (servicecontainer == null)
            {
                servicecontainer = new Dictionary<object, object>();
                servicecontainer.Add(typeof(IMail<SendMailDomainView>), new SendMailBusiness(new SendMailData()));
             
            }

            #endregion
            try
            {
                return (T)servicecontainer[typeof(T)];
            }
            catch (Exception)
            {
                throw new NotImplementedException("Service not available.");
            }
        }


    }
}
