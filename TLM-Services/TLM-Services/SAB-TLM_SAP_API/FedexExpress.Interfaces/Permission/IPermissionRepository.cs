using Express.View.Domain.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Express.Interfaces.Permission
{
   public interface IPermissionRepository
    {
        PermissionDomainView GetButtonPermission(PermissionParaDomainView _para);
    }
}
