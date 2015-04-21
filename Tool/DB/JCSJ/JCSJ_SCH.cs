using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DB.JCSJ
{
    public partial class OPT
    {
        private JCSJ.Entities _db;
        public OPT()
        {
            _db = new Entities();
            //此项会引起entity无法序列化的错误
            _db.Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// 登陆验证
        /// </summary>
        /// <param name="dlm">用户名</param>
        /// <param name="mmd5">md5加密后的密码</param>
        /// <returns></returns>
        public TUser GetUser(string dlm, string mmd5)
        {
            return _db.TUser.SingleOrDefault(r => r.dengluming == dlm && r.mima == mmd5);
        }

        /// <summary>
        /// 取得所有系统用户
        /// </summary>
        /// <param name="ExeptAdmin">是否包含系统管理员</param>
        /// <returns></returns>
        public TUser[] GetAllUsers(bool ExeptAdmin)
        {
            var Users = _db.TUser.Where(r => r.juese != (byte)CONSTS.USER_XTJS.系统管理员);

            return Users.ToArray();
        }

        /// <summary>
        /// 取得所有分店信息
        /// </summary>
        /// <returns></returns>
        public TFendian[] GetAllFendians()
        {
            var Fendians = _db.TFendian.Include("TUser");

            return Fendians.ToArray();
        }

        /// <summary>
        /// 取得所有仓库信息
        /// </summary>
        /// <returns></returns>
        public TCangku[] GetAllCangkus()
        {
            var Cangkus = _db.TCangku.Include("TUser");

            return Cangkus.ToArray();
        }

        /// <summary>
        /// 取得所有会员信息
        /// </summary>
        /// <returns></returns>
        public THuiyuan[] GetAllHuiyuans()
        {
            var Huiyuans = _db.THuiyuan.Include("Tuser").Include("TFendian");

            return Huiyuans.ToArray();
        }

        /// <summary>
        /// 取得所有供应商信息
        /// </summary>
        /// <returns></returns>
        public TGongyingshang[] GetAllGongyingshangs()
        {
            var Gongys = _db.TGongyingshang.Include("TUser");

            return Gongys.ToArray();
        }

        /// <summary>
        /// 取得所有款号信息
        /// </summary>
        /// <returns></returns>
        public TKuanhao[] GetAllKuanhaos()
        {
            var Kuanhaos = _db.TKuanhao.Include("TUser");

            return Kuanhaos.ToArray();
        }

        /// <summary>
        /// 取得所有条码信息
        /// </summary>
        /// <returns></returns>
        public TTiaoma[] GetAllTiaomas()
        {
            var Tiaomas = _db.TTiaoma.Include("TUser").Include("TKuanhao").Include("TGongyingshang");

            return Tiaomas.ToArray();
        }

        /// <summary>
        /// 根据款号名称取得款号信息
        /// </summary>
        /// <param name="kh"></param>
        /// <returns></returns>
        public TKuanhao GetKuanhaoByMc(string kh)
        {
            return _db.TKuanhao.SingleOrDefault(r => r.kuanhao == kh);
        }
    }
}
