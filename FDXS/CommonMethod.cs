using DB_FD;
using DB_FD.Models;
using FDXS.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FDXS
{
    class CommonMethod
    {
        /// <summary>
        /// 下载指定的一组条码信息
        /// </summary>
        /// <param name="tmhs"></param>
        public static void DownLoadTiaomaInfo(string[] tmhs, bool autoClose)
        {
            new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
            {
                try
                {
                    JCSJData.TTiaoma[] jtms = JCSJWCF.GetTiaomasByTiaomahaos(tmhs);
                    SaveTmsToLocal(jtms);

                    ShowMsg("下载完毕，共下载" + jtms.Count() + "个条码信息", false);
                }
                catch (Exception ex)
                {
                    Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                    ShowMsg(ex.Message, true);
                }
            }, autoClose).Start();
        }

        public static void DownLoadTiaomaInfo(DateTime start, DateTime end,bool autoClose)
        {
            new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
            {
                try
                {
                    JCSJData.TTiaoma[] jtms = JCSJWCF.GetTiaomasByUpdTime(start, end);
                    CommonMethod.SaveTmsToLocal(jtms);

                    ShowMsg("下载完毕，共下载" + jtms.Count() + "个条码信息", false);
                }
                catch (Exception ex)
                {
                    Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                    ShowMsg(ex.Message, true);
                }
            }, autoClose).Start();
        }
    

        /// <summary>
        /// 把取得的条码信息保存到本地
        /// </summary>
        /// <param name="jtms"></param>
        public static void SaveTmsToLocal(JCSJData.TTiaoma[] jtms)
        {
            List<TTiaoma> tms = new List<TTiaoma>();
            foreach (JCSJData.TTiaoma jtm in jtms)
            {
                TTiaoma tm = new TTiaoma
                {
                    id = jtm.id,
                    tiaoma = jtm.tiaoma,
                    kuanhao = jtm.TKuanhao.kuanhao,
                    gongyingshang = jtm.TGongyingshang.mingcheng,
                    gyskuanhao = jtm.gyskuanhao,
                    leixing = jtm.TKuanhao.leixing,
                    pinming = jtm.TKuanhao.pinming,
                    yanse = jtm.yanse,
                    chima = jtm.chima,
                    jinjia = jtm.jinjia,
                    shoujia = jtm.shoujia,
                    charushijian = DateTime.Now,
                    xiugaishijian = DateTime.Now
                };
                tms.Add(tm);
            }

            DBContext db = IDB.GetDB();
            //检查是否有条码号冲突的，因为用户可能在编码时修改了旧条码号，
            //或者在网站上条码信息管理页面修改了条码号，导致分店系统的条码号
            //TODO
            //TTiaoma[] otmhs = db.GetTiaomasByTmhs(tms.Select(r => r.tiaoma).ToArray());


            //找出已经在本地存在的条码
            TTiaoma[] otms = db.GetTiaomasByIds(tms.Select(r => r.id).ToArray());
            int[] oids = otms.Select(r => r.id).ToArray();
            //需要更新的条码和需要新插入的条码
            TTiaoma[] uts = tms.Where(r => oids.Contains(r.id)).ToArray();
            TTiaoma[] nts = tms.Where(r => !oids.Contains(r.id)).ToArray();
            db.UpdateTiaomas(uts);
            db.InsertTiaomas(nts);
        }
    }
}
