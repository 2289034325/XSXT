using BIANMA.JCSJData;
using BIANMA.JCSJValid;
using BIANMA.Properties;
using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIANMA
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
                _jdc = new DataServiceClient("WsHttpBinding_IDataService",Settings.Default.WCF_DATAADD);
            }
            else
            {
                if (_jdc.State != System.ServiceModel.CommunicationState.Opened)
                {
                    _jdc = new DataServiceClient("WsHttpBinding_IDataService",Settings.Default.WCF_DATAADD);
                }
            }

            TUser User = _jdc.BMZHLogin(dlm, Tool.CommonFunc.MD5_16(mm), Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));

            _dlm = dlm;
            _mm = mm;

            return User;
        }
        public static void AutoLogin()
        {
            if (_jdc == null)
            {
                _jdc = new DataServiceClient("WsHttpBinding_IDataService",Settings.Default.WCF_DATAADD);
                _jdc.BMZHLogin(_dlm, Tool.CommonFunc.MD5_16(_mm), Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));
            }
            else
            {
                if (_jdc.State != System.ServiceModel.CommunicationState.Opened)
                {
                    _jdc = new DataServiceClient("WsHttpBinding_IDataService", Settings.Default.WCF_DATAADD);
                    _jdc.BMZHLogin(_dlm, Tool.CommonFunc.MD5_16(_mm), Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));
                }
            }
        }

        internal static void BMZHBangding(string dlm, string mm, string zcm)
        {
            ValidServiceClient vdc = new ValidServiceClient("BasicHttpBinding_IValidService",Settings.Default.WCF_VALIDADD);
            vdc.BMZHBangding(dlm, Tool.CommonFunc.MD5_16(mm), Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()), zcm);
        }

        internal static TGongyingshang[] GetGongyingshangs()
        {
            AutoLogin();
            return _jdc.GetGongyingshangs();
        }

        //internal static TGongyingshang InsertGongyingshang(TGongyingshang g)
        //{
        //    AutoLogin();
        //    return _jdc.InsertGongyingshang(g);
        //}

        //internal static void EditGongyingshang(TGongyingshang og)
        //{
        //    AutoLogin();
        //    _jdc.EditGongyingshang(og);
        //}

        //internal static void DeleteGongyingshang(int id)
        //{
        //    AutoLogin();
        //    _jdc.DeleteGongyingshang(id);
        //}

        internal static TKuanhao[] GetKuanhaos()
        {
            AutoLogin();
            return _jdc.GetKuanhaos();
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

        //internal static void BMZHEditPsw(string om, string nm)
        //{
        //    AutoLogin();
        //    _jdc.BMZHEditPsw(Tool.CommonFunc.MD5_16(om), Tool.CommonFunc.MD5_16(nm));
        //}

        //internal static void BMZHZhuce(string dlm, string mm, string xm, string zcm)
        //{
        //    ValidServiceClient vdc = new ValidServiceClient("BasicHttpBinding_IValidService", Settings.Default.WCF_VALIDADD);
        //    vdc.BMZHZhuce(dlm, Tool.CommonFunc.MD5_16(mm), xm, Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()), zcm);
        //}

        internal static TTiaoma[] GetTiaomas(string kuanhao, string tiaoma, DateTime? start, DateTime? end)
        {
            AutoLogin();
            return _jdc.GetTiaomasByCond(kuanhao, tiaoma, start, end);
        }

        internal static TKuanhao GetKuanhaoByMc(string kh)
        {
            AutoLogin();
            return _jdc.GetKuanhaoByMc(kh);
        }

        internal static string[] CheckKuanhaosChongfu(string[] khs)
        {
            AutoLogin();
            return _jdc.CheckKuanhaosChongfu(khs);
        }

        internal static string[] CheckTiaomaChongfu(string[] tms)
        {
            AutoLogin();
            return _jdc.CheckTiaomaChongfu(tms);
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
    }
}
