using DataTire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiteq_Logic
{
    public class clsBackProcess
    {
        public static void AutoAssignConfigValue()
        {
            foreach (tbl_securityConfigValue detail in tbl_securityConfigValue.SelectAll())
            {
                switch (detail.ValueID)
                {
                    case 1://System Expire Date
                        clsConfig.SystemExpireDate = DateTime.Parse(detail.ConfigValue);
                        break;

                    #region Backup Configs
                    case 200:
                        clsConfig.sSERVII_BackupPath_Server = detail.ConfigValue;
                        break;
                    case 201:
                        clsConfig.sSERVII_Backup_SourceFolder_1 = detail.ConfigValue;
                        break;
                    case 202:
                        clsConfig.sSERVII_Backup_SourceFolder_2 = detail.ConfigValue;
                        break;
                    case 203:
                        clsConfig.sSERVII_Backup_SourceFolder_3 = detail.ConfigValue;
                        break;
                    case 204:
                        clsConfig.sSERVII_BackupPreFix = detail.ConfigValue;
                        break;
                   #endregion
                }

            }
        }
    }
}
