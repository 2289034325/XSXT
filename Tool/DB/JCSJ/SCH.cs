using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tool.DB.JCSJ;

namespace Tool.DB.JCSJ
{
        public partial class DBContext
        {
            private Entities _db;
            public DBContext()
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
            /// 根据登陆名取得用户
            /// </summary>
            /// <param name="dlm"></param>
            /// <returns></returns>
            public TUser GetUserByDlm(string dlm)
            {
                return _db.TUser.SingleOrDefault(r => r.dengluming == dlm);
            }

            /// <summary>
            /// 取得所有系统用户
            /// </summary>
            /// <param name="ExeptAdmin">是否包含系统管理员</param>
            /// <returns></returns>
            public TUser[] GetUsers(bool ExeptAdmin)
            {
                var Users = _db.TUser.Where(r => r.juese != (byte)JCSJ.DBCONSTS.USER_XTJS.系统管理员);

                return Users.ToArray();
            }

            /// <summary>
            /// 取得所有分店信息
            /// </summary>
            /// <returns></returns>
            public TFendian[] GetFendians()
            {
                var Fendians = _db.TFendian.Include("TUser");

                return Fendians.ToArray();
            }

            /// <summary>
            /// 取得所有仓库信息
            /// </summary>
            /// <returns></returns>
            public TCangku[] GetCangkus()
            {
                var Cangkus = _db.TCangku.Include("TUser");

                return Cangkus.ToArray();
            }
            /// <summary>
            /// 根据id和名称取得仓库信息
            /// </summary>
            /// <param name="id"></param>
            /// <param name="mc"></param>
            /// <returns></returns>
            public TCangku GetCangkuByIdMc(int id, string mc)
            {
                return _db.TCangku.SingleOrDefault(r => r.id == id && r.mingcheng == mc);
            }
            public TCangku GetCangkuById(int id)
            {
                return _db.TCangku.SingleOrDefault(r => r.id == id);
            }

            /// <summary>
            /// 取得所有会员信息
            /// </summary>
            /// <returns></returns>
            public THuiyuan[] GetHuiyuans()
            {
                var Huiyuans = _db.THuiyuan.Include("Tuser").Include("TFendian");

                return Huiyuans.ToArray();
            }

            /// <summary>
            /// 取得所有供应商信息
            /// </summary>
            /// <returns></returns>
            public TGongyingshang[] GetGongyingshangs()
            {
                var Gongys = _db.TGongyingshang.Include("TUser");

                return Gongys.ToArray();
            }
            /// <summary>
            /// 取得某个用户编辑的所有供应商信息
            /// </summary>
            /// <returns></returns>
            public TGongyingshang[] GetGongyingshangsByUserId(int UserId)
            {
                var Gongys = _db.TGongyingshang.Where(r => r.caozuorenid == UserId);

                return Gongys.ToArray();
            }
            public TGongyingshang GetGongyingshangById(int id)
            {
                return _db.TGongyingshang.SingleOrDefault(r => r.id == id);
            }

            /// <summary>
            /// 取得所有款号信息
            /// </summary>
            /// <returns></returns>
            public TKuanhao[] GetKuanhaos()
            {
                var Kuanhaos = _db.TKuanhao.Include("TUser");

                return Kuanhaos.ToArray();
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
            public TKuanhao GetKuanhaoById(int id)
            {
                return _db.TKuanhao.SingleOrDefault(r => r.id == id);
            }

            /// <summary>
            /// 取得某个用户编辑的所有款号信息
            /// </summary>
            /// <param name="UserId"></param>
            /// <returns></returns>
            public TKuanhao[] GetKuanhaosByUserId(int UserId)
            {
                var ks = _db.TKuanhao.Where(r => r.caozuorenid == UserId);

                return ks.ToArray();
            }

            /// <summary>
            /// 取得所有条码信息
            /// </summary>
            /// <returns></returns>
            public TTiaoma[] GetTiaomas()
            {
                var Tiaomas = _db.TTiaoma.Include("TUser").Include("TKuanhao");

                return Tiaomas.ToArray();
            }
            public TTiaoma[] GetTiaomasByUpdTime(DateTime dt)
            {
                return _db.TTiaoma.Include("TUser").Include("TKuanhao").Where(r => r.xiugaishijian >= dt).ToArray();
            }

            /// <summary>
            /// 按条件取得条码信息
            /// </summary>
            /// <param name="Userid">操作人ID</param>
            /// <param name="Kuanhao"></param>
            /// <param name="Tiaoma"></param>
            /// <param name="Start">条码插入时间</param>
            /// <param name="End">条码插入时间</param>
            /// <returns></returns>
            public TTiaoma[] GetTiaomas(int Userid, string Kuanhao, string Tiaoma, DateTime Start, DateTime End)
            {
                var Tiaomas = _db.TTiaoma.Include("TKuanhao").Where(r => r.caozuorenid == Userid && r.charushijian >= Start && r.charushijian <= End);
                if (!string.IsNullOrEmpty(Kuanhao))
                {
                    Tiaomas = Tiaomas.Where(r => r.TKuanhao.kuanhao == Kuanhao);
                }
                if (!string.IsNullOrEmpty(Tiaoma))
                {
                    Tiaomas = Tiaomas.Where(r => r.tiaoma == Tiaoma);
                }

                return Tiaomas.ToArray();
            }

            /// <summary>
            /// 根据款号取得所有的条码信息
            /// </summary>
            /// <param name="kh">款号名称</param>
            /// <returns></returns>
            public TTiaoma[] GetTiaomasByKuanhaoMc(string kh)
            {
                var Tiaomas = _db.TTiaoma.Where(r=>r.TKuanhao.kuanhao == kh);

                return Tiaomas.ToArray();
            }

            /// <summary>
            /// 根据条码号取得条码信息
            /// </summary>
            /// <param name="t"></param>
            /// <returns></returns>
            public TTiaoma GetTiaomaByTiaomahao(string t)
            {
                return _db.TTiaoma.SingleOrDefault(r => r.tiaoma == t);
            }
            public TTiaoma[] GetTiaomasByTiaomahaos(string[] tmhs)
            {
                return _db.TTiaoma.Include("TKuanhao").Where(r => tmhs.Contains(r.tiaoma)).ToArray();
            }

            /// <summary>
            /// 取得某用户的下载记录
            /// </summary>
            /// <param name="userid">用户ID</param>
            /// <param name="neirong">下载内容</param>
            /// <returns></returns>
            public TXiazaijilu GetXiazaijilu(int userid, string neirong)
            {
                return _db.TXiazaijilu.SingleOrDefault(r => r.yonghuid == userid && r.neirong == neirong);
            }
        }
 
}