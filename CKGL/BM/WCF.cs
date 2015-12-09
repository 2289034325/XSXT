using CKGL.JCSJData;
using CKGL.JCSJValid;
using CKGL.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKGL.BM
{
    public static class JCSJWCF
    {
        private static DataServiceClient _jdc = null;

        private static string _dlm = null;
        private static string _mm = null;

        /// <summary>
        /// 检查到数据中心的连接状态
        /// </summary>
        /// <param name="jdc"></param>
        /// <returns></returns>
        public static TUser Login(string dlm,string mm)
        {
            if (_jdc == null)
            {
                _jdc = new DataServiceClient("WsHttpBinding_IDataService",Settings.Default.WCFDataADD);
            }
            else
            {
                if (_jdc.State != System.ServiceModel.CommunicationState.Opened)
                {
                    _jdc = new DataServiceClient("WsHttpBinding_IDataService",Settings.Default.WCFValidADD);
                }
            }

            TUser User = _jdc.BMZHLogin(dlm, Tool.CommonFunc.MD5_16(mm), Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()), RuntimeInfo.ClientVersion.ToString());

            _dlm = dlm;
            _mm = mm;

            return User;
        }
        public static void AutoLogin()
        {
            if (_jdc == null)
            {
                _jdc = new DataServiceClient("WsHttpBinding_IDataService",Settings.Default.WCFDataADD);
                _jdc.BMZHLogin(_dlm, Tool.CommonFunc.MD5_16(_mm), Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()), RuntimeInfo.ClientVersion.ToString());
            }
            else
            {
                if (_jdc.State != System.ServiceModel.CommunicationState.Opened)
                {
                    _jdc = new DataServiceClient("WsHttpBinding_IDataService", Settings.Default.WCFDataADD);
                    _jdc.BMZHLogin(_dlm, Tool.CommonFunc.MD5_16(_mm), Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()), RuntimeInfo.ClientVersion.ToString());
                }
            }
        }

        internal static void BMZHBangding(string dlm, string mm, string zcm)
        {
            ValidServiceClient vdc = new ValidServiceClient("BasicHttpBinding_IValidService",Settings.Default.WCFValidADD);
            vdc.BMZHBangding(dlm, Tool.CommonFunc.MD5_16(mm), Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()), zcm, RuntimeInfo.ClientVersion.ToString());
        }

        internal static TGongyingshang[] GetGongyingshangs()
        {
            AutoLogin();
            return _jdc.GetGongyingshangs();
        }

        internal static TKuanhao[] GetKuanhaosByCond(int pageSize, int pageIndex, out int recordCount)
        {
            AutoLogin();
            return _jdc.GetKuanhaosByCond(pageSize, pageIndex, out recordCount);
        }

        internal static TKuanhao InsertKuanhao(TKuanhao k)
        {
            AutoLogin();
            return _jdc.InsertKuanhao(k);
        }

        internal static void EditKuanhao(TKuanhao ok)
        {
            AutoLogin();
            _jdc.EditKuanhao(ok);
        }

        internal static void DeleteKuanhao(int id)
        {
            AutoLogin();
            _jdc.DeleteKuanhao(id);
        }

        internal static TTiaoma[] GetTiaomas(string kuanhao, string tiaoma, DateTime? start, DateTime? end)
        {
            AutoLogin();
            return _jdc.GetTiaomasByCond(kuanhao, tiaoma, start, end);
        }

        internal static TKuanhao[] GetKuanhaosByMcs(string[] khs)
        {
            AutoLogin();
            return _jdc.GetKuanhaosByMcs(khs);
        }

        //internal static TKuanhao[] CheckKuanhaosChongfu(string[] khs)
        //{
        //    AutoLogin();
        //    return _jdc.GetKuanhaosByMcs(khs);
        //}

        internal static TTiaoma[] GetTiaomasByTiaomahaos(string[] tms)
        {
            AutoLogin();
            return _jdc.GetTiaomasByTiaomahaos(tms);
        }

        internal static TKuanhao[] SaveKuanhaos(TKuanhao[] tKuanhao)
        {
            AutoLogin();
            return _jdc.SaveKuanhaos(tKuanhao);
        }

        internal static TTiaoma[] SaveTiaomas(TTiaoma[] tTiaoma)
        {
            AutoLogin();
            return _jdc.SaveTiaomas(tTiaoma);
        }

        internal static void EditTiaoma(TTiaoma t)
        {
            AutoLogin();
            _jdc.EditTiaoma(t);
        }

        internal static TPinpaishang[] GetJMPinpais()
        {
            AutoLogin();
            return _jdc.GetJMPinpais();
        }

        internal static void XiugaiKuanhao(int id, string kh)
        {
            AutoLogin();
            _jdc.XiugaiKuanhao(id, kh);
        }

        internal static void FugaiTiaoma(TTiaoma t)
        {
            AutoLogin();
            _jdc.UpdateTiaoma(t);
        }
    }
}
