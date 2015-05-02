﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;
using Tool.DB.JCSJ;

namespace JCSJG
{
    public partial class Page_Tiaoma : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                //加载所有条码信息
                loadTiaomas();

                //初始化下拉框
                DBContext db = new DBContext();
                TGongyingshang[] gs = db.GetGongyingshangs();
            }
            else
            {
                string opt = hid_opt.Value;
                if (opt == "DELETE")
                {
                    int id = int.Parse(hid_id.Value);
                    deleteTiaoma(id);
                }

                //操作后清除操作标志
                hid_opt.Value = "";
            }
        }

        /// <summary>
        /// 删除一个条码
        /// </summary>
        /// <param name="id"></param>
        private void deleteTiaoma(int id)
        {
            DBContext db = new DBContext();
            db.DeleteTiaoma(id);

            loadTiaomas();
        }

        /// <summary>
        /// 加载所有条码信息
        /// </summary>
        private void loadTiaomas()
        {
            DBContext db = new DBContext();
            TTiaoma[] fs = db.GetTiaomas();
            var dfs = fs.Select(r => new
            {
                id = r.id,
                tiaoma = r.tiaoma,
                yanse = r.yanse,
                chima = r.chima,
                jinjia = r.jinjia,
                shoujia = r.shoujia,
                kuanhao = r.TKuanhao.kuanhao,
                leixing = ((DBCONSTS.KUANHAO_LX)r.TKuanhao.leixing).ToString(),
                pinming = r.TKuanhao.pinming,
                gyskuanhao = r.gyskuanhao,
                caozuoren = r.TUser.yonghuming,
                charushijian = r.charushijian,
                xiugaishijian = r.xiugaishijian,
                editParams = r.id + ",'" + r.tiaoma + "','" + r.yanse + "','" + r.chima + "','" + r.jinjia + "','" + r.shoujia + "','" +
                             r.TKuanhao.kuanhao + "','" + r.gyskuanhao + "'"
            });

            grid_tiaoma.DataSource = Tool.CommonFunc.LINQToDataTable(dfs);
            grid_tiaoma.DataBind();
        }

        /// <summary>
        /// 修改条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            TTiaoma f = getEditInfo();
            f.id = int.Parse(hid_id.Value);
            f.caozuorenid = ((TUser)Session["USER"]).id;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            db.UpdateTiaoma(f);

            loadTiaomas();
        }

        /// <summary>
        /// 取得编辑信息
        /// </summary>
        /// <returns></returns>
        private TTiaoma getEditInfo()
        {
            string tiaoma = txb_tm.Text.Trim();
            string yanse = txb_ys.Text.Trim();
            string chima = txb_cm.Text.Trim();
            decimal jinjia = decimal.Parse(txb_jj.Text.Trim());
            decimal shoujia = decimal.Parse(txb_sj.Text.Trim());
            string kuanhao = txb_kh.Text.Trim();
            DBContext db = new DBContext();
            TKuanhao k = db.GetKuanhaoByMc(kuanhao);
            if (k == null)
            {
                throw new MyException("该款号不存在");
            }

            string gyskuanhao = txb_gyskh.Text.Trim();

            TTiaoma f = new TTiaoma
            {
                tiaoma = tiaoma,
                yanse = yanse,
                chima = chima,
                jinjia = jinjia,
                shoujia = shoujia,
                kuanhaoid = k.id,
                gyskuanhao = gyskuanhao,
            };

            return f;
        }

        /// <summary>
        /// 增加一个条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            TTiaoma f = getEditInfo();
            f.caozuorenid = ((TUser)Session["USER"]).id;
            f.charushijian = DateTime.Now;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            db.InsertTiaoma(f);

            loadTiaomas();
        }
    }
}