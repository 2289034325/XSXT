using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tool;

namespace JCSJWCF
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IDataService 
    {
        [OperationContract(IsInitiating = true)]
        TUser BMZHLogin(string dlm, string mm, string tzm);

        [OperationContract(IsInitiating = true)]
        void CKZHLogin(int ckid, string tzm);

        [OperationContract(IsInitiating = true)]
        void FDZHLogin(int fdid, string tzm);

        //[OperationContract(IsInitiating=false)]
        //void BMZHEditPsw(string om,string nm);

        [OperationContract(IsInitiating = false)]
        TTiaoma[] GetTiaomasByCond(string Kuanhao, string Tiaoma, DateTime? Start, DateTime? End);


        [OperationContract(IsInitiating = false)]
        TGongyingshang[] GetGongyingshangs();


        [OperationContract(IsInitiating = false)]
        TKuanhao[] GetKuanhaosByCond(int pageSize, int pageIndex, out int recordCount);


        [OperationContract(IsInitiating = false)]
        TKuanhao InsertKuanhao(TKuanhao k);


        [OperationContract(IsInitiating = false)]
        void EditKuanhao(TKuanhao k);


        [OperationContract(IsInitiating = false)]
        void DeleteKuanhao(int id);

        //[OperationContract(IsInitiating = false)]
        //TGongyingshang InsertGongyingshang(TGongyingshang g);

        //[OperationContract(IsInitiating = false)]
        //void EditGongyingshang(TGongyingshang g);

        //[OperationContract(IsInitiating = false)]
        //void DeleteGongyingshang(int id);

        [OperationContract(IsInitiating = false)]
        TKuanhao[] GetKuanhaosByMcs(string[] khs);
        //TKuanhao GetKuanhaoByMc(string kh);

        //[OperationContract(IsInitiating = false)]
        //TTiaoma[] GetTiaomasByKuanhaoMc(string kh);

        //[OperationContract(IsInitiating = false)]
        //string[] CheckKuanhaosChongfu(string[] khs);

        //[OperationContract(IsInitiating = false)]
        //string[] CheckTiaomaChongfu(string[] tms);

        [OperationContract(IsInitiating = false)]
        TKuanhao[] SaveKuanhaos(TKuanhao[] ks);

        [OperationContract(IsInitiating = false)]
        TTiaoma[] SaveTiaomas(TTiaoma[] ts);

        [OperationContract(IsInitiating = false)]
        void EditTiaoma(TTiaoma t);


        //[OperationContract(IsInitiating = false)]
        //TTiaoma[] GetTiaomasByUpdTime(DateTime upt_start, DateTime upt_end);

        [OperationContract(IsInitiating = false)]
        TTiaoma[] GetTiaomasByTiaomahaos(string[] tmhs);


        [OperationContract(IsInitiating = false)]
        THuiyuan HuiyuanZhuce(THuiyuan h);

        [OperationContract(IsInitiating = false)]
        THuiyuan GetHuiyuanByShoujihao(string sjh);

        [OperationContract(IsInitiating = false)]
        THuiyuan GetHuiyuanById(int id);

        [OperationContract(IsInitiating = false)]
        void UpdateHuiyuan(THuiyuan h);


        //[OperationContract(IsInitiating = false)]
        //THuiyuanZK[] GetHuiyuanZhekous();


        [OperationContract(IsInitiating = false)]
        void ShangbaoXiaoshou(TXiaoshou[] xss);


        [OperationContract(IsInitiating = false)]
        void ShangbaoKucun_FD(TFendianKucunMX[] fks);

        [OperationContract(IsInitiating = false)]
        void ShangbaoJinchuhuo_FD(TFendianJinchuhuo[] fjcs);


        [OperationContract(IsInitiating = false)]
        void ShangbaoKucun_CK(TCangkuKucunMX[] cks);

        [OperationContract(IsInitiating = false)]
        void ShangbaoJinchuhuo_CK(TCangkuJinchuhuo[] cjcs);

        /// <summary>
        /// 将仓库发货到分店的出货数据上传到服务器，让分店不用扫描入库，就能直接下载
        /// </summary>
        /// <param name="cjcs"></param>
        [OperationContract(IsInitiating = false)]
        void CangkufahuoFendian(int oid,int fdid);


        /// <summary>
        /// 取得所有分店信息
        /// </summary>
        /// <returns></returns>
        [OperationContract(IsInitiating = false)]
        TFendian[] GetFendians();
        [OperationContract(IsInitiating = false)]
        TCangku[] GetCangkus();

        /// <summary>
        /// 取下级加盟商
        /// </summary>
        /// <returns></returns>
        [OperationContract(IsInitiating = false)]
        TJiamengshang[] GetZiJiamengshangs();

        /// <summary>
        /// 分店看到进货后，直接从中央系统下载这批货的详细数据
        /// </summary>
        /// <returns></returns>
        [OperationContract(IsInitiating = false)]
        TCangkuJinchuhuo[] XiazaiJinhuoShuju();

        [OperationContract(IsInitiating = false)]
        void XiazaiJinhuoShujuFinish(int[] ckjcids);

        //分店系统删除已上报的销售记录和进出货记录
        [OperationContract(IsInitiating = false)]
        void DeleteXiaoshoujilu(int oid);
        [OperationContract(IsInitiating = false)]
        void DeleteJinchujilu_FD(int oid);

       
        /// <summary>
        /// 取得某加盟商加盟的品牌
        /// </summary>
        /// <returns></returns>
        [OperationContract(IsInitiating = false)]
        TJiamengshang[] GetJMPinpais();

        [OperationContract(IsInitiating = false)]
        void XiugaiKuanhao(int id, string kh);

        [OperationContract(IsInitiating = false)]
        void XiugaiTiaoma(int id, string tm);
    }
}
