using FDXS.JCSJData;
using FDXS.JCSJValid;
using FDXS.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDXS
{
    public static class JCSJWCF
    {
        private static DataServiceClient _jdc = null;

        /// <summary>
        /// 重新建立连接
        /// </summary>
        public static void Reconnect()
        {
            _jdc = new DataServiceClient("WsHttpBinding_IDataService", Settings.Default.WCFDataADD);
            _jdc.FDZHLogin(Settings.Default.FDID, Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));
        }

        /// <summary>
        /// 检查到数据中心的连接状态
        /// </summary>
        /// <param name="jdc"></param>
        /// <returns></returns>
        public static void Login()
        {
            if (_jdc == null)
            {
                _jdc = new DataServiceClient("WsHttpBinding_IDataService",Settings.Default.WCFDataADD);
                _jdc.FDZHLogin(Settings.Default.FDID, Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));
                
            }
            else
            {
                if (_jdc.State != System.ServiceModel.CommunicationState.Opened)
                {
                    _jdc = new DataServiceClient("WsHttpBinding_IDataService", Settings.Default.WCFDataADD);
                    _jdc.FDZHLogin(Settings.Default.FDID, Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));
                }
            }
        }


        /// <summary>
        /// 编辑会员信息
        /// </summary>
        /// <param name="jh"></param>
        internal static void UpdateHuiyuan(THuiyuan jh)
        {            
            Login();
            _jdc.UpdateHuiyuan(jh);
        }

        internal static THuiyuan GetHuiyuanByShoujihao(string sjh)
        {
            Login();
            return _jdc.GetHuiyuanByShoujihao(sjh);
        }

        internal static THuiyuan HuiyuanZhuce(THuiyuan h)
        {
            Login();
            return _jdc.HuiyuanZhuce(h);
        }

        internal static void FDZHZhuce(int ckid, string ckm, string jqm, string zcm)
        {
            ValidServiceClient vdc = new ValidServiceClient("BasicHttpBinding_IValidService", Settings.Default.WCFValidADD);
            vdc.FDZHZhuce(ckid, ckm, jqm, zcm);
        }

        internal static THuiyuan GetHuiyuanById(int id)
        {
            Login();
            return _jdc.GetHuiyuanById(id);
        }

        //internal static THuiyuanZK[] GetHuiyuanZhekous()
        //{
        //    Login();
        //    return _jdc.GetHuiyuanZhekous();
        //}

        internal static void ShangbaoJinchuhuo_FD(TFendianJinchuhuo[] jcjcs)
        {
            Login();
            _jdc.ShangbaoJinchuhuo_FD(jcjcs);
        }

        internal static void ShangbaoKucun_FD(TFendianKucunMX[] fks)
        {
            Login();
            _jdc.ShangbaoKucun_FD(fks);
        }

        internal static TTiaoma[] GetTiaomasByUpdTime(DateTime upt_start, DateTime upt_end)
        {
            Login();
            return _jdc.GetTiaomasByCond(null, null, upt_start, upt_end);
        }

        internal static TTiaoma[] GetTiaomasByTiaomahaos(string[] tmhs)
        {
            Login();
            return _jdc.GetTiaomasByTiaomahaos(tmhs);
        }

        internal static void ShangbaoXiaoshou(TXiaoshou[] jxss)
        {
            Login();
            _jdc.ShangbaoXiaoshou(jxss);
        }

        internal static TCangkuJinchuhuo[] XiazaiJinhuoShuju()
        {
            Login();
            return _jdc.XiazaiJinhuoShuju();
        }

        internal static void XiazaiJinhuoShujuFinish(int[] ckjcids)
        {
            Login();
            _jdc.XiazaiJinhuoShujuFinish(ckjcids);
        }

        //internal static string GetLatestVersion()
        //{
        //    ValidServiceClient vdc = new ValidServiceClient("BasicHttpBinding_IValidService", Settings.Default.WCFValidADD);
        //    return vdc.GetLatestVersion(Tool.JCSJ.DBCONSTS.SYS_CLIENT_TYPE.分店);
        //}

        internal static void DeleteXiaoshou(int id)
        {
            Login();
            _jdc.DeleteXiaoshoujilu(id);
        }
        internal static void DeleteJinchuhuo(int id)
        {
            Login();
            _jdc.DeleteJinchujilu_FD(id);
        }
    }
}
