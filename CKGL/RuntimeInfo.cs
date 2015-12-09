using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKGL
{
    public static class RuntimeInfo
    {
        //客户端版本
        public static Version ClientVersion = new Version();

        //当前需要的数据库版本
        public const int DbVersion = 0;

        //当前登陆的用户
        public static DB_CK.Models.TUser LoginUser_CK = null;
        public static CKGL.JCSJData.TUser LoginUser_BM = null;

        //所有直营分店
        public static Dictionary<string, string> AllFds = null;


        //是否已从服务器加载过必要的基础数据
        public static bool BaseDataLoaded = false;

        //供应商
        public static CKGL.JCSJData.TGongyingshang[] Gyses = null;

        //加盟的品牌
        public static CKGL.JCSJData.TPinpaishang[] JmPps = null;
    }
}
