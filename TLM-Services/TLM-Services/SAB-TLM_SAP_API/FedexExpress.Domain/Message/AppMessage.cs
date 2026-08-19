using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Domain.Message
{
  public  class AppMessage
    {
        private static string  _SaveSuccess="Data Successfully Saved";

        public static string SaveSuccess
        {
            get { return _SaveSuccess; }
            
        }

        private static string _DeleteSuccess = "Data Deleted Successfully";
        public static string DeleteSuccess
        {
            get
            {
                return _DeleteSuccess;
            }
        }


        private static string _DataSaveError = "Data Saving Error";

        public static string DataSaveError
        {
            get { return _DataSaveError; }

        }

        private static string _SystemException = "System Error";

        public static string SystemException
        {
            get { return _SystemException; }

        }

        public static string PrimeryKeyException
        {
            get { return "Can't dublicate code"; }
        }

    }
}
