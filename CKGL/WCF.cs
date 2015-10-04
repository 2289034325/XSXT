using CKGL.JCSJData;
using CKGL.JCSJValid;
using CKGL.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKGL
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
            //_jdc = new DataServiceClient("NetTcpBinding_IDataService");
            _jdc.CKZHLogin(Settings.Default.CKID, Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));
        }

        public static void Login()
        {
            if (_jdc == null)
            {
                _jdc = new DataServiceClient("WsHttpBinding_IDataService", Settings.Default.WCFDataADD);
                //_jdc = new DataServiceClient("NetTcpBinding_IDataService");
                _jdc.CKZHLogin(Settings.Default.CKID, Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));
            }
            else
            {
                if (_jdc.State != System.ServiceModel.CommunicationState.Opened)
                {
                    _jdc = new DataServiceClient("WsHttpBinding_IDataService", Settings.Default.WCFDataADD);
                    //_jdc = new DataServiceClient("NetTcpBinding_IDataService");
                    _jdc.CKZHLogin(Settings.Default.CKID, Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));
                }
            }
        }

        /// <summary>
        /// 仓库账号注册
        /// </summary>
        /// <param name="ckid"></param>
        /// <param name="ckm"></param>
        /// <param name="zcm"></param>
        internal static void CKZHZhuce(int ckid, string ckm,string jqm, string zcm)
        {
            ValidServiceClient vdc = new ValidServiceClient("BasicHttpBinding_IValidService", Settings.Default.WCFValidADD);
            vdc.CKZHZhuce(ckid, ckm,jqm, zcm);
        }

        /// <summary>
        /// 上报仓库的进出货
        /// </summary>
        /// <param name="jcjcs"></param>
        internal static void ShangbaoJinchuhuo_CK(TCangkuJinchuhuo[] jcjcs)
        {
            Login();
            _jdc.ShangbaoJinchuhuo_CK(jcjcs);
        }

        /// <summary>
        /// 上报仓库库存
        /// </summary>
        /// <param name="fks"></param>
        internal static void ShangbaoKucun_CK(TCangkuKucunMX[] fks)
        {
            Login();
            _jdc.ShangbaoKucun_CK(fks);
        }

        /// <summary>
        /// 取得条码
        /// </summary>
        /// <returns></returns>
        internal static TTiaoma[] GetTiaomasByUpdTime(DateTime upt_start, DateTime upt_end)
        {
            Login();
            return _jdc.GetTiaomasByCond("","",upt_start, upt_end);
        }

        /// <summary>
        /// 取得指定条码号的信息
        /// </summary>
        /// <param name="tmhs"></param>
        /// <returns></returns>
        internal static TTiaoma[] GetTiaomasByTiaomahaos(string[] tmhs)
        {
            Login();
            return _jdc.GetTiaomasByTiaomahaos(tmhs);
        }

        /// <summary>
        /// 取得所有的分店信息
        /// </summary>
        /// <returns></returns>
        internal static TFendian[] GetFendians()
        {
            Login();
            return _jdc.GetFendians();
        }

        /// <summary>
        /// 将发货数据上传到中央系统，让分店下载
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fdid"></param>
        internal static void CangkuFahuoFendian(int id, int fdid)
        {
            Login();
            _jdc.CangkufahuoFendian(id, fdid);
        }
    }
}
