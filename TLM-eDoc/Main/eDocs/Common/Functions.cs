using eDocs_DAL.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using static eDocs.Common.Enums;

namespace eDocs.Common
{
    public class Functions
    {
        //readonly UnitOfWork _unitOfWork = new UnitOfWork();
        eDocs_DAL.Repository.UnitOfWork _unitOfWork = new eDocs_DAL.Repository.UnitOfWork();
        public static string GetUserId()
        {
            return HttpContext.Current.Request.Cookies.Get(SessionsEnum.UserId.ToString()).Value;
        }

        public static int checkpagesvalidility(string mathod, string controller)
        {
            eDocs_DAL.Repository.UnitOfWork _unitOfWork = new eDocs_DAL.Repository.UnitOfWork();
            var status = 0;
            int getUserId = Convert.ToInt32(Functions.GetUserId());
            var getuseraccess = _unitOfWork.ERPModuleMenuRepository.GetAll(x => x.MenuLink == mathod && x.MenuLocation == controller);
            var checkUserAccessPages = _unitOfWork.UserRole_Permission.GetAll(x => x.UserID == getUserId).ToList();

            var GetList = getuseraccess.Where(a => checkUserAccessPages.Any(b => b.MenuCode == a.MenuCode)).Count();

            if (GetList > 0)
            {
                status = 1;
            }
            else
            {
                status = 0;
            }
            return status;
        }

        public static string GetCompanyId()
        {
            return HttpContext.Current.Request.Cookies.Get(SessionsEnum.GetCompanyId.ToString()).Value;
        }
        //public static int GetProfileId()
        //{
        //    return Convert.ToInt32(HttpContext.Current.Request.Cookies.Get(SessionsEnum.CompanyId.ToString()).Value);
        //}
        public static int GetBranchId()
        {
            return Convert.ToInt32(HttpContext.Current.Request.Cookies.Get(SessionsEnum.BranchId.ToString()).Value);
        }
        public static int GetEmployeeId()
        {
            return Convert.ToInt32(HttpContext.Current.Request.Cookies.Get(SessionsEnum.EmployeeId.ToString()).Value);
        }
        public static int GetUserRoleId()
        {
            return Convert.ToInt32(HttpContext.Current.Request.Cookies.Get(SessionsEnum.UserRoleId.ToString()).Value);
        }

        public static int GetUserRoleName()
        {
            return Convert.ToInt32(HttpContext.Current.Request.Cookies.Get(SessionsEnum.UserRoleName.ToString()).Value);
        }


        public string GenMainCode(IndexSectionsEnum Section)
        {

            var CurrentData = _unitOfWork.IndexReferenceRepository.GetAll(a => a.Section == Section + "").FirstOrDefault();

            string ReffNo;

            if (CurrentData != null)
            {
                ReffNo = CurrentData.Prefix + (CurrentData.CurrentIndex + 1).ToString("D4");
            }
            else
            {
                ReffNo = "0000";
            }

            return ReffNo;
        }

        public static void SetCookies(AdminUserDetail user)
        {
            // profile id
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(SessionsEnum.UserId.ToString())
            {
                Expires = DateTime.Now.AddDays(1),
                Value = user.UserID.ToString(),

            });

           
            // User Name
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(SessionsEnum.UserName.ToString())
            {
                Expires = DateTime.Now.AddDays(1),
                Value = user.UserLoginN,

            });
            // userrole
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(SessionsEnum.UserRoleId.ToString())
            {
                Expires = DateTime.Now.AddDays(1),
                Value = Convert.ToString(user.UserRoleId),

            });
            //   profile id
            //HttpContext.Current.Response.Cookies.Add(new HttpCookie(SessionsEnum.CompanyId.ToString())
            //{
            //    Expires = DateTime.Now.AddDays(1),
            //    Value = user.ProfileId.ToString(),
            //});
            // branch id
            //HttpContext.Current.Response.Cookies.Add(new HttpCookie(SessionsEnum.BranchId.ToString())
            //{
            //    Expires = DateTime.Now.AddDays(1),
            //    Value = user.BranchId.ToString(),
            //});

        }
        public static void UpdateCookies()
        {
            //// user id
            HttpCookie cookieUserId = HttpContext.Current.Request.Cookies[SessionsEnum.UserId.ToString()];
            cookieUserId.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Request.Cookies.Set(cookieUserId);
            HttpContext.Current.Response.Cookies.Set(cookieUserId);

        }
        public static void RemoveCookies()
        {
            // user id
            HttpContext.Current.Request.Cookies.Remove(SessionsEnum.UserId.ToString());
            HttpContext.Current.Response.Cookies.Remove(SessionsEnum.UserId.ToString());

            HttpContext.Current.Request.Cookies.Remove(SessionsEnum.GetCompanyId.ToString());
            HttpContext.Current.Response.Cookies.Remove(SessionsEnum.GetCompanyId.ToString());

        }

     

        public List<KeyValuePair<string, int>> GetEnumList<T>()
        {
            var list = new List<KeyValuePair<string, int>>();
            foreach (var e in Enum.GetValues(typeof(T)))
            {
                list.Add(new KeyValuePair<string, int>(e.ToString(), (int)e));
            }
            return list;
        }

        //public static ErrorLogViewModel GetErrorLogObject(Exception ex)
        //{
        //    var obj = new ErrorLogViewModel()
        //    {
        //        Message = ex.Message,
        //        FullException = ex.ToString(),
        //        InnerMessage = ex.InnerException != null ? ex.InnerException.Message : null,
        //        InnerFull = ex.InnerException != null ? ex.InnerException.ToString() : null,
        //    };
        //    return obj;
        //}






        //public static string UploadFilePath = @"C:\Uploads\";
        //public static string TempFilePath = @"C:\Uploads\TempUpload\";

        public static string UploadFilePath = ConfigurationManager.AppSettings["UploadFilePath"];
        public static string TempFilePath = ConfigurationManager.AppSettings["TempFilePath"];

        public static bool IsFirstLogin = true;
        public static DateTime LastRefreshedTime = DateTime.Now.AddDays(-1);

        public static string GetFilePath(bool IsTempPath, IndexSectionsEnum module, string UserId=null)
        {

            UserId = IsTempPath ? UserId ?? GetUserId() : "";
            string MainFile = IsTempPath ? TempFilePath : UploadFilePath;
            if (IsTempPath)
                return string.Format($"{MainFile}\\{module}\\{UserId}\\");
            else
                return string.Format($"{MainFile}\\{module}\\");
        }
    }
}