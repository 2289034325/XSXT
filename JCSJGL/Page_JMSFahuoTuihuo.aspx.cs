using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

namespace JCSJGL
{
    public partial class Page_JMSFahuoTuihuo : MyPage
    {
        public Page_JMSFahuoTuihuo()
        {
            _PageName = PageName.加盟商发货退货;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //如果不是顶级加盟商，不显示该页面
            DBContext db = new DBContext();
            if (!(_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理))
            {
                TJiamengshang j = db.GetJiamengshangById(_LoginUser.jmsid);
                if (j.zjmsshu <= 0)
                {
                    throw new MyException("没有权限", null);
                }
            }

            if (!IsPostBack)
            {
                //隐藏搜索条件
                div_sch_dls.Visible = false;

                //初始化分店下拉框
                int? dlsid = null;
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    //显示搜索
                    div_sch_dls.Visible = true;

                    //代理商下拉框
                    TJiamengshang[] dlses = db.GetJiamengshangs();
                    Tool.CommonFunc.InitDropDownList(cmb_dls, dlses, "mingcheng", "id");
                    cmb_dls.Items.Insert(0, new ListItem("所有代理商", ""));

                    //加盟商下拉框
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));
                }
                else
                {
                    dlsid = _LoginUser.jmsid;
                    TJiamengshangGX[] jmses = db.GetZiJiamengshangGXes(dlsid.Value);
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmses, "bzmingcheng", "jmsid");
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));
                }
                
                //默认日期
                txb_fsrq_start.Text = DateTime.Now.ToString("yyyy-MM-dd");
                txb_fsrq_end.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sch_Click(object sender, EventArgs e)
        {

            loadFahuotuihuo();            
        }

        private void loadFahuotuihuo()
        {
            grid_jc.DataSource = null;
            grid_jc.DataBind();
            grid_mx.DataSource = null;
            grid_mx.DataBind();

            DBContext db = new DBContext();
            int? dlsid = null;
            Dictionary<int, string> bzmcs = new Dictionary<int, string>();
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (!string.IsNullOrEmpty(cmb_dls.SelectedValue))
                {
                    dlsid = int.Parse(cmb_dls.SelectedValue);
                }
                grid_jc.Columns[0].Visible = true;

                bzmcs = db.GetJiamengshangs().ToDictionary(k => k.id, v => v.mingcheng);
            }
            else
            {
                grid_jc.Columns[0].Visible = false;
                dlsid = _LoginUser.jmsid;

                bzmcs = db.GetZiJiamengshangGXes(_LoginUser.jmsid).ToDictionary(k => k.jmsid, v => v.bzmingcheng);
                bzmcs.Add(_LoginUser.jmsid, _LoginUser.TJiamengshang.mingcheng);  
            }

            int? jmsid = null;
            if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
            {
                jmsid = int.Parse(cmb_jms.SelectedValue);
            }
            DateTime? fsrq_start = null;
            DateTime? fsrq_end = null;
            if (!string.IsNullOrEmpty(txb_fsrq_start.Text.Trim()))
            {
                fsrq_start = DateTime.Parse(txb_fsrq_start.Text.Trim()).Date;
            }
            if (!string.IsNullOrEmpty(txb_fsrq_end.Text.Trim()))
            {
                fsrq_end = DateTime.Parse(txb_fsrq_end.Text.Trim()).Date.AddDays(1);
            }

            int recordCount = 0;
            TJiamengshangJintuihuo[] jths = db.GetJiamengshangJintuihuosByCond(dlsid, jmsid, fsrq_start, fsrq_end,grid_jc.PageSize,grid_jc.PageIndex,out recordCount);
            var data = jths.Select(r => new
            {
                r.id,
                dailishang = r.Dls.mingcheng,
                fashengriqi = r.fashengriqi.ToString("yyyy-MM-dd"),
                jiamengshang = bzmcs[r.jmsid],
                fangxiang = ((Tool.JCSJ.DBCONSTS.JMS_FHTH)r.fangxiang).ToString(),
                zhekou = r.zhekou,
                shuliang = r.TJiamengshangJintuihuoMXes.Count,
                jine = r.TJiamengshangJintuihuoMXes.Sum(xr => xr.jinhuojia * xr.shuliang),
                r.beizhu,
                r.charushijian,
                r.xiugaishijian,
                editParams = r.id + "," + r.zhekou + ",'" + r.beizhu + "'"
            });

            grid_jc.VirtualItemCount = recordCount;
            grid_jc.DataSource = Tool.CommonFunc.LINQToDataTable(data);
            grid_jc.DataBind();
        }

        /// <summary>
        /// 切换代理商，加载其子加盟商信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmb_dls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                cmb_jms.Items.Clear();
                DBContext db = new DBContext();
                if (!string.IsNullOrEmpty(cmb_dls.SelectedValue))
                {
                    int dlsid = int.Parse(cmb_dls.SelectedValue);
                    TJiamengshang[] jmses = db.GetZiJiamengshangs(dlsid);

                    Tool.CommonFunc.InitDropDownList(cmb_jms,jmses, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));
                }
                else
                {
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));
                }
            }
            else
            {
                //其他角色不可能触发该事件，如果有，判定为浏览器操作漏洞
                throw new MyException("非法操作，请刷新页面重新执行", null);
            }
        }

        /// <summary>
        /// 查看明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_jc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                return;
            }

            if (e.CommandName == "MX")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int id = int.Parse(grid_jc.DataKeys[index].Value.ToString());
                //此处设置是为了在修改明细记录后重新加载明细的时候用
                hid_jcid.Value = id.ToString();
                loadMX(id);
            }
            else if (e.CommandName == "DEL")
            {
                Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

                int index = Convert.ToInt32(e.CommandArgument);
                int id = int.Parse(grid_jc.DataKeys[index].Value.ToString());
                DBContext db = new DBContext();
                TJiamengshangJintuihuo oj = db.GetJiamengshangJintuihuosById(id);
                if (oj.dlsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
                {
                    throw new MyException("非法操作，无法删除", null);
                }
                db.DeleteJiamengshangJintuihuo(id);

                btn_sch_Click(null, null);
            }
        }

        /// <summary>
        /// 加载进退货的明细数据
        /// </summary>
        /// <param name="jtid"></param>
        private void loadMX(int jtid)
        {
            DBContext db = new DBContext();
            TJiamengshangJintuihuoMX[] mxes = db.GetJiamengshangJintuihuoMXes(jtid);

            var data = mxes.Select(r => new
            {
                r.id,
                r.TTiaoma.tiaoma,
                r.TTiaoma.TKuanhao.kuanhao,
                r.TTiaoma.TKuanhao.pinming,
                r.TTiaoma.yanse,
                r.TTiaoma.chima,
                diaopaijia = r.TTiaoma.shoujia,
                r.jinhuojia,
                zhekou = decimal.Round(r.jinhuojia / r.TTiaoma.shoujia * 10M, 2),
                editParams = r.id + ",'" + r.TTiaoma.tiaoma + "'," + r.jinhuojia
            });

            grid_mx.DataSource = Tool.CommonFunc.LINQToDataTable(data);
            grid_mx.DataBind();
        }

        /// <summary>
        /// 删除一个明细记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_mx_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                return;
            }

            Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

            int index = Convert.ToInt32(e.CommandArgument);
            int id = int.Parse(grid_mx.DataKeys[index].Value.ToString());
            if (e.CommandName == "DEL")
            {
                DBContext db = new DBContext();
                TJiamengshangJintuihuoMX om = db.GetJiamengshangJintuihuoMXById(id);
                if (om.TJiamengshangJintuihuo.dlsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
                {
                    throw new MyException("非法操作，无法删除", null);
                }
                db.DeleteJiamengshangJintuihuoMX(id);

                //重新加载数据
                loadMX(om.jintuiid);
            }
        }

        /// <summary>
        /// 增加一个发货记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_fahuo_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            if (string.IsNullOrEmpty(cmb_jms.SelectedValue))
            {
                throw new MyException("请先选择一个加盟商",null);
            }

            int jmsid = int.Parse(cmb_jms.SelectedValue);

            TJiamengshangJintuihuo jc = new TJiamengshangJintuihuo
            {
                dlsid = _LoginUser.jmsid,
                fashengriqi = DateTime.Now,
                jmsid = jmsid,
                fangxiang = (byte)Tool.JCSJ.DBCONSTS.JMS_FHTH.发货,
                zhekou = 3,
                beizhu = "",
                caozuorenid = _LoginUser.id,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now            
            };

            DBContext db = new DBContext();
            db.InsertJiamengshangJinchuhuo(jc);

            //重新加载表格
            loadFahuotuihuo();
        }

        /// <summary>
        /// 增加一个退货记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_tuihuo_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            if (string.IsNullOrEmpty(cmb_jms.SelectedValue))
            {
                throw new MyException("请先选择一个加盟商", null);
            }

            int jmsid = int.Parse(cmb_jms.SelectedValue);

            TJiamengshangJintuihuo jc = new TJiamengshangJintuihuo
            {
                dlsid = _LoginUser.jmsid,
                fashengriqi = DateTime.Now,
                jmsid = jmsid,
                fangxiang = (byte)Tool.JCSJ.DBCONSTS.JMS_FHTH.退货,
                zhekou = 3,
                beizhu = "",
                caozuorenid = _LoginUser.id,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now            
            };

            DBContext db = new DBContext();
            db.InsertJiamengshangJinchuhuo(jc);

            //重新加载表格
            loadFahuotuihuo();
        }

        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_jc_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.修改, _LoginUser);

            int id = int.Parse(hid_jcid.Value);
            decimal zk = decimal.Parse(txb_zk.Text.Trim());
            string bz = txb_bz.Text.Trim();
            TJiamengshangJintuihuo j = new TJiamengshangJintuihuo 
            {
                id =id,
                zhekou = zk,
                beizhu = bz,
                xiugaishijian = DateTime.Now
            };

            DBContext db = new DBContext();
            TJiamengshangJintuihuo oj = db.GetJiamengshangJintuihuosById(id);
            if (oj.dlsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法修改", null);
            }
            db.UpdateJiamengshangJintuihuo(j);

            //重新加载数据
            loadFahuotuihuo();
        }

        protected void btn_save_mx_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.修改, _LoginUser);

            DBContext db = new DBContext();

            int jcid = int.Parse(hid_jcid.Value);
            int mxid = int.Parse(hid_mxid.Value);
            string tmh = txb_tm_edit.Text.Trim();
            TTiaoma tm = db.GetTiaomaByTiaomahaoWithJmsId(tmh, _LoginUser.jmsid);
            if (tm == null)
            {
                throw new MyException("条码[" + tmh + "]不存在", null);
            }
            decimal jhj = decimal.Parse(txb_jhj.Text.Trim());
            TJiamengshangJintuihuoMX m = new TJiamengshangJintuihuoMX
            {
                id = mxid,
                tiaomaid = tm.id,
                jinhuojia = jhj
            };

            TJiamengshangJintuihuoMX om = db.GetJiamengshangJintuihuoMXById(mxid);
            if (om.TJiamengshangJintuihuo.dlsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法修改", null);
            }
            db.UpdateJiamengshangJintuihuoMX(m);
            
            //重新加载数据
            loadMX(jcid);
        }

        protected void btn_add_mx_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            DBContext db = new DBContext();

            int jcid = int.Parse(hid_jcid.Value);
            TJiamengshangJintuihuo oj = db.GetJiamengshangJintuihuosById(jcid);
            if (oj.dlsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法增加", null);
            }
            string tmh = txb_tm_edit.Text.Trim();
            TTiaoma tm = db.GetTiaomaByTiaomahaoWithJmsId(tmh, _LoginUser.jmsid);
            if (tm == null)
            {
                throw new MyException("条码[" + tmh + "]不存在", null);
            }
            decimal jhj = decimal.Parse(txb_jhj.Text.Trim());
            TJiamengshangJintuihuoMX j = new TJiamengshangJintuihuoMX
            {
                jintuiid = jcid,
                tiaomaid = tm.id,
                jinhuojia = jhj
            };

            db.InsertJiamengshangJinchuhuoMX(j);

            //重新加载数据
            loadMX(jcid);
        }

        protected void grid_jc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           
            grid_jc.PageIndex =  e.NewPageIndex;
            loadFahuotuihuo();
        }  
    }
}