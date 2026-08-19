using eDocs_DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static eDocs.Common.Enums;

namespace eDocs.Common
{
 
    public class Email
    {
       

      
       
        public static string GetUserId()
        {
            return HttpContext.Current.Request.Cookies.Get(SessionsEnum.UserId.ToString()).Value;

          
        }

         
      //  public static string UploadFilePath = @"";
        public static string TempFilePath = @"InboxEmail\TempUpload\";
        public static bool IsFirstLogin = true;
        public static DateTime LastRefreshedTime = DateTime.Now.AddDays(-1);

        public static string GetFilePath(bool IsTempPath, IndexSectionsEnum module, string UserId = null)
        {
            UnitOfWork _uow = new UnitOfWork();
            var GetInboxPath = _uow.InboxLocationPathRepository.GetById(1);

            System.Web.HttpContext.Current.Session["InboxPath"] = GetInboxPath.Path;

            string UploadFilePath = System.Web.HttpContext.Current.Session["InboxPath"] as string;
            // UserId = IsTempPath ? UserId ?? GetUserId() : "";

            string MainFile = IsTempPath ? UploadFilePath+TempFilePath : UploadFilePath;
            if (IsTempPath)
                return string.Format($"{MainFile}\\{module}\\");
            else
                return string.Format($"{MainFile}\\{module}\\");
        }
    }
}