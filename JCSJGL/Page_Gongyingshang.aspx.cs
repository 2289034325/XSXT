﻿using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JCSJGL
{
    public partial class Page_Gongyingshang : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                //加载所有供应商信息
                loadGongyingshangs();
            }
            else
            {
                string opt = hid_opt.Value;
                if (opt == "DELETE")
                {
                    int id = int.Parse(hid_id.Value);
                    deleteGongyingshang(id);
                }

                //操作后清除操作标志
                hid_opt.Value = "";
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        private void deleteGongyingshang(int id)
        {
            DBContext db = new DBContext();
            db.DeleteGongyingshang(id);

            loadGongyingshangs();
        }

        /// <summary>
        /// 加载所有供应商信息
        /// </summary>
        private void loadGongyingshangs()
        {
            DBContext db = new DBContext();
            TGongyingshang[] cs = db.GetGongyingshangs();
            var dfs = cs.Select(r => new
            {
                id = r.id,
                jiancheng = r.jiancheng,
                mingcheng = r.mingcheng,
                lianxiren = r.lianxiren,
                dianhua = r.dianhua,
                dizhi = r.dizhi,
                beizhu = r.beizhu,
                caozuoren = r.TUser.yonghuming,
                charushijian = r.charushijian,
                xiugaishijian = r.xiugaishijian,
                editParams = r.id + ",'" + r.jiancheng + "','" + r.mingcheng + "','" + r.lianxiren + "','" + r.dianhua + "','" + r.dizhi + "','" + r.beizhu + "'"
            });

            grid_gys.DataSource = Tool.CommonFunc.LINQToDataTable(dfs);
            grid_gys.DataBind();
        }

        /// <summary>
        /// 修改供应商信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            TGongyingshang f = getEditInfo();
            f.id = int.Parse(hid_id.Value);
            f.caozuorenid = ((TUser)Session["USER"]).id;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            db.UpdateGongyingshang(f);

            loadGongyingshangs();
        }

        /// <summary>
        /// 取得编辑信息
        /// </summary>
        /// <returns></returns>
        private TGongyingshang getEditInfo()
        {
            string jc = txb_jc.Text.Trim();
            string mc = txb_mc.Text.Trim();
            string dz = txb_dz.Text.Trim();
            string lxr = txb_lxr.Text.Trim();
            string dh = txb_dh.Text.Trim();
            string bz = txb_bz.Text.Trim();

            TGongyingshang f = new TGongyingshang
            {
                jiancheng = jc,
                mingcheng = mc,
                dizhi = dz,
                lianxiren = lxr,
                dianhua = dh,
                beizhu = bz
            };

            return f;
        }

        /// <summary>
        /// 增加一个供应商
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            TGongyingshang f = getEditInfo();
            f.caozuorenid = ((TUser)Session["USER"]).id;
            f.charushijian = DateTime.Now;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            db.InsertGongyingshang(f);

            loadGongyingshangs();

        }
    }
}