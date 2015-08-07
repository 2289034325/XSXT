using DB_FD;
using DB_FD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDXS
{
    public static class RuntimeInfo
    {
        //客户端版本
        public static Version ClientVersion = new Version();

        //数据库版本
        public static int DbVersion = 0;

        //版本是否是最新
        public static bool IsLatestVersion = false;

        //当前登陆的用户
        public static TUser LoginUser = null;
    }
}
