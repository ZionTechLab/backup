using Express.Interfaces.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Express.View.Domain.Permission;

namespace Express.Business.Permission
{
    public class PermissionBusiness : IPermissionRepository
    {
        private readonly IPermissionRepository _permission;
        public PermissionBusiness(IPermissionRepository _permission)
        {
            this._permission = _permission;
        }
        public PermissionDomainView GetButtonPermission(PermissionParaDomainView _para)
        {
            return _permission.GetButtonPermission(_para);
        }
    }
}
