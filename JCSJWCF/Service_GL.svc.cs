using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tool.DB.JCSJ;

namespace JCSJWCF
{
    public class Service_GL : IService_GL
    {
        /// <summary>
        /// 验证登录
        /// </summary>
        /// <param name="dlm">登录名</param>
        /// <param name="mm">MD5加密后的密码</param>
        /// <returns></returns>
        public TUser Login(string dlm, string mm)
        {
            OPT dbo = new OPT();
            TUser tu = dbo.GetUser(dlm, mm);
            return tu;
        }

        /// <summary>
        /// 取得所有系统用户
        /// </summary>
        /// <param name="ExceptAdmin">是否排除系统管理员</param>
        /// <returns></returns>
        public TUser[] GetAllUsers(bool ExceptAdmin)
        {
            OPT dbo = new OPT();
            return dbo.GetAllUsers(true);            
        }
    }
}
