using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DB.JCSJ
{
    public partial class OPT
    {
        private JCSJDataContext _db;
        public OPT()
        {
            _db = new JCSJDataContext();
        }

        /// <summary>
        /// 登陆验证
        /// </summary>
        /// <param name="dlm">用户名</param>
        /// <param name="mmd5">md5加密后的密码</param>
        /// <returns></returns>
        public TUser ValidateLogin(string dlm, string mmd5)
        {
            return _db.TUser.SingleOrDefault(r => r.dengluming == dlm && r.mima == mmd5);
        }

        /// <summary>
        /// 取得所有系统用户
        /// </summary>
        /// <param name="ExeptAdmin">是否包含系统管理员</param>
        /// <returns></returns>
        public object GetAllUsers(bool ExeptAdmin)
        {
            throw new NotImplementedException();
        }
    }
}
