using Express.Interfaces.Permission;
using Express.UI.Factory.Permission;
using Express.View.Domain.Login;
using Express.View.Domain.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.UI.Common.Permission
{
    public sealed class Permission
    {
        private static volatile Permission instance;
        private static object syncRoot = new Object();
        private Permission()
        {

        }

        public static Permission Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Permission();
                    }
                }

                return instance;
            }
        }

        public bool CheckPermission( int userid , int menucode , string option)
        {
            var _para = new PermissionParaDomainView
            {
                CompanyID = LoginInfoView.COMPANYID,
                MenuCode = LoginInfoView.MENUCODE,//  menucode,
                ModuleCode = LoginInfoView.MODULEID,
                Option = option,
                UserID = LoginInfoView.USERID // need to change
                //CompanyID = LoginInfoView.COMPANYID,
                //MenuCode = 1018,//  menucode,
                //ModuleCode = LoginInfoView.MODULEID,
                //Option = option,
                //UserID = 1197 // need to change


            };

            var _permission =  PermissionUIFactory.GetService<IPermissionRepository>();
            var optionsList = _permission.GetButtonPermission(_para);
            return  IsPermissionGrant(optionsList , option );
        }


        private bool IsPermissionGrant(PermissionDomainView optionsList ,string option)
        {
            
            if (optionsList == null) {               
            return false ;
            }

            if(optionsList.OptionList ==null)            {
               
                return false ;
            }

            if(optionsList.OptionList.Contains(option ))
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

    }
}
