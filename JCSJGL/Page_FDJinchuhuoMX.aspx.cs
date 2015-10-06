﻿using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

namespace JCSJGL
{
    public partial class Page_FDJinchuhuoMX : MyPage
    {
        public Page_FDJinchuhuoMX()
        {
            _PageName = PageName.分店进出货明细;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //取得进出记录ID
                int jcid = int.Parse(Request["id"]);
                getMX(jcid);
            }
        }

        private void getMX(int jcid)
        {
            DBContext db = new DBContext();
                        
            if (_LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 &&
             _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                //除了系统管理员和总经理，其他加盟商禁止查看其他加盟商的数据
                TFendianJinchuhuo tf = db.GetFDJinchuhuoByJcId(jcid);
                if (tf.TFendian.jmsid != _LoginUser.jmsid)
                {
                    throw new MyException("非法操作，无法显示数据", null);
                }

                //店长只能看自己下属的分店数据
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.店长)
                {
                    TUserFendian[] ufs = db.GetUserFendiansByUserId(_LoginUser.id);
                    int[] ufids = ufs.Select(r => r.fendianid).ToArray();
                    if (!ufids.Contains(tf.fendianid))
                    {
                        throw new MyException("非法操作，无法显示数据", null);
                    }
                }
            }

            TFendianJinchuhuoMX[] amxs = db.GetFDJinchuhuoMXsByJcId(jcid);

            var mxs = amxs.Select(r => new 
            {
                r.TTiaoma.tiaoma,
                r.TTiaoma.TKuanhao.kuanhao,
                r.TTiaoma.gyskuanhao,
                leixing = ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)r.TTiaoma.TKuanhao.leixing).ToString(),
                r.TTiaoma.TKuanhao.pinming,
                r.TTiaoma.yanse,
                r.TTiaoma.chima,
                r.TTiaoma.jinjia,
                r.TTiaoma.shoujia,
                r.shuliang
            });

            grid_mx.DataSource = Tool.CommonFunc.LINQToDataTable(mxs);
            grid_mx.DataBind();
        }        
    }
}