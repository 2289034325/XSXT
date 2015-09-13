using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIANMA
{
    public static class RuntimeInfo
    {
        //客户端版本
        public static Version ClientVersion = new Version();

        //当前登陆的用户
        public static TUser LoginUser = null;

        //是否已从服务器加载过必要的基础数据
        public static bool BaseDataLoaded = false;

        //供应商
        public static TGongyingshang[] Gyses = null;

        //自己的品牌
        public static TPinpai[] MyPps = null;

        //加盟的品牌
        public static TPinpai[] JmPps = null;
    }
}
