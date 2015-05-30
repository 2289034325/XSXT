using BIANMA.JCSJData;
using BIANMA.JCSJValid;
using DB_JCSJ;
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
        private static ValidServiceClient _vdc = null;

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
                _jdc = new DataServiceClient();
            }
            else
            {
                if (_jdc.State != System.ServiceModel.CommunicationState.Opened)
                {
                    _jdc = new DataServiceClient();
                }
            }
            TUser User = _jdc.BMZHLogin(dlm, Tool.CommonFunc.MD5_16(mm), Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));

            _dlm = dlm;
            _mm = mm;

            return User;
        }
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

            _jdc.BMZHLogin(_dlm, Tool.CommonFunc.MD5_16(_mm), Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));
        }

        internal static void BMZHBangding(string dlm, string mm, string zcm)
        {
            _vdc.BMZHBangding(dlm, Tool.CommonFunc.MD5_16(mm), Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()), zcm);
        }

        internal static TGongyingshang[] GetGongyingshangsByUserId(int id)
        {
            Login();
            return _jdc.GetGongyingshangsByUserId(id);
        }

        internal static TGongyingshang InsertGongyingshang(TGongyingshang g)
        {
            Login();
            return _jdc.InsertGongyingshang(g);
        }

        internal static void EditGongyingshang(TGongyingshang og)
        {
            Login();
            _jdc.EditGongyingshang(og);
        }

        internal static void DeleteGongyingshang(int id)
        {
            Login();
            _jdc.DeleteGongyingshang(id);
        }

        internal static TKuanhao[] GetKuanhaosByUserId(int id)
        {
            Login();
            return _jdc.GetKuanhaosByUserId(id);
        }

        internal static TKuanhao InsertKuanhao(TKuanhao k)
        {
            Login();
            return _jdc.InsertKuanhao(k);
        }

        internal static void EditKuanhao(TKuanhao ok)
        {
            Login();
            _jdc.EditKuanhao(ok);
        }

        internal static void DeleteKuanhao(int id)
        {
            Login();
            _jdc.DeleteKuanhao(id);
        }

        internal static void BMZHEditPsw(string om, string nm)
        {
            Login();
            _jdc.BMZHEditPsw(Tool.CommonFunc.MD5_16(om), Tool.CommonFunc.MD5_16(nm));
        }

        internal static void BMZHZhuce(string dlm, string mm, string xm, string zcm)
        {
            _vdc.BMZHZhuce(dlm, Tool.CommonFunc.MD5_16(mm), xm, Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()), zcm);
        }

        internal static TTiaoma[] GetTiaomas(int userid, string kuanhao, string tiaoma, DateTime start, DateTime end)
        {
            Login();
            return _jdc.GetTiaomas(userid, kuanhao, tiaoma, start, end);
        }

        internal static TTiaoma[] GetTiaomasByKuanhaoMc(string kh)
        {
            Login();
            return _jdc.GetTiaomasByKuanhaoMc(kh);
        }

        internal static TKuanhao GetKuanhaoByMc(string kh)
        {
            Login();
            return _jdc.GetKuanhaoByMc(kh);
        }

        internal static string[] CheckKuanhaosChongfu(string[] khs)
        {
            Login();
            return _jdc.CheckKuanhaosChongfu(khs);
        }

        internal static string[] CheckTiaomaChongfu(string[] tms)
        {
            Login();
            return _jdc.CheckTiaomaChongfu(tms);
        }

        internal static TKuanhao[] SaveKuanhaos(TKuanhao[] tKuanhao)
        {
            Login();
            return _jdc.SaveKuanhaos(tKuanhao);
        }

        internal static TTiaoma[] SaveTiaomas(TTiaoma[] tTiaoma)
        {
            Login();
            return _jdc.SaveTiaomas(tTiaoma);
        }

        internal static void EditTiaoma(TTiaoma t)
        {
            Login();
            _jdc.EditTiaoma(t);
        }
    }
}
