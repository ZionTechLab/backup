using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Invoice.InvoiceHelper.PickupInvioceProcess
{
    public sealed class PickInvoiceLocator
    {
        private static Dictionary<Type, Type> servicecontainer;
        private static ConstructorInfo constructor;
        private  PickInvoiceLocator()
        {

        }

        public static T GetService<T>()
        {
            #region inject services

            if (servicecontainer == null)
            {
                servicecontainer = new Dictionary<Type, Type>();
                servicecontainer.Add(typeof(IPickInvoicePreview), typeof(PickInoicePreview));
                servicecontainer.Add(typeof(IPickInvoiceProcess), typeof(PickInvoiceProcess));
            }
            #endregion
            try
            {
                constructor = servicecontainer[typeof(T)].GetConstructor(new Type[0]);
                return (T)constructor.Invoke(null);
            }
            catch (Exception)
            {
                throw new NotImplementedException("Service not available.");
            }
        }
    }
}
