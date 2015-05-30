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
        private static ValidServiceClient _vdc = null;

        /// <summary>
        /// 检查到数据中心的连接状态
        /// </summary>
        /// <param name="jdc"></param>
        /// <returns></returns>
        public static void Login()
        {
            if (_jdc == null)
            {
                _jdc = new DataServiceClient();
            }
            else
            {
                if (_jdc.State != System.ServiceModel.CommunicationState.Opened)
                {
                    _jdc = new DataServiceClient();
                }
            }
            _jdc.FDZHLogin(Settings.Default.FDID, Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));
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

        internal static void HuiyuanZhuce(THuiyuan h)
        {
            Login();
            _jdc.HuiyuanZhuce(h);
        }

        internal static void FDZHZhuce(int ckid, string ckm, string jqm, string zcm)
        {
            Login();
            _vdc.FDZHZhuce(ckid,ckm,jqm,zcm);
        }

        internal static THuiyuan GetHuiyuanById(int id)
        {
            Login();
            return _jdc.GetHuiyuanById(id);
        }

        internal static THuiyuanZK[] GetHuiyuanZhekous()
        {
            Login();
            return _jdc.GetHuiyuanZhekous();
        }

        internal static void ShangbaoJinchuhuo_FD(TFendianJinchuhuo[] jcjcs)
        {
            Login();
            _jdc.ShangbaoJinchuhuo_FD(jcjcs);
        }

        internal static void ShangbaoKucun_FD(TFendianKucun[] fks)
        {
            Login();
            _jdc.ShangbaoKucun_FD(fks);
        }

        internal static TTiaoma[] GetTiaomasByUpdTime()
        {
            Login();
            return _jdc.GetTiaomasByUpdTime();
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
    }
}
