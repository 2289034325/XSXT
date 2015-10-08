using DB_FD;
using DB_FD.Models;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDXS
{
    public static class RuntimeInfo
    {
        //客户端版本
        public static Version ClientVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion;

        //当前需要的数据库版本
        public const int DbVersion = 0;
        
        //当前登陆的用户
        public static TUser LoginUser = null;
    }
}
