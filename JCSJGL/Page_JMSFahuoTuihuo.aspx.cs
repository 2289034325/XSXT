using DB_JCSJ;
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
    public partial class Page_JMSFahuoTuihuo : MyPage
    {
        public Page_JMSFahuoTuihuo()
        {
            _PageName = PageName.加盟商发货退货;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DBContext db = new DBContext();

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
                    TJiamengshang[] jmses = db.GetZiJiamengshangs(dlsid.Value);
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmses, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));
                }                
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sch_Click(object sender, EventArgs e)
        { 
            int? dlsid = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    dlsid = int.Parse(cmb_jms.SelectedValue);
                }
                grid_jc.Columns[0].Visible = true;
            }
            else
            {
                grid_jc.Columns[0].Visible = false;
                dlsid = _LoginUser.jmsid;
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

            DBContext db = new DBContext();
            TJiamengshangJintuihuo[] jths = db.GetJiamengshangJintuihuosByCond(dlsid, jmsid, fsrq_start, fsrq_end);
            var data = jths.Select(r => new 
            {
                r.id,
                dailishang = r.Dls.mingcheng,
                fashengriqi = r.fashengriqi,
                jiamengshang = r.Jms.mingcheng,
                fangxiang = ((Tool.JCSJ.DBCONSTS.JMS_FHTH)r.fangxiang).ToString(),
                zhekou = r.zhekou,
                shuliang = r.TJiamengshangJintuihuoMXes.Count,
                jine = r.TJiamengshangJintuihuoMXes.Sum(xr=>xr.jinhuojia*xr.shuliang),
                r.charushijian,
                r.xiugaishijian
            });

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
            int index = Convert.ToInt32(e.CommandArgument);
            int id = int.Parse(grid_jc.DataKeys[index].Value.ToString());
            if (e.CommandName == "MX")
            {
                loadMX(id);
            }
            else if (e.CommandName == "ADDMX")
            {
                Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

                string tmh = txb_tm.Text.Trim();
                if (string.IsNullOrEmpty(tmh))
                {
                    throw new MyException("请填写要增加的条码号", null);
                }

                DBContext db = new DBContext();
                TTiaoma[] tms = db.GetTiaomasByTiaomahaosWithJmsId(new string[] { tmh },_LoginUser.jmsid);
                if (tms.Length == 0)
                {
                    throw new MyException("条码[" + tmh + "]不存在", null);
                }
                else if (tms.Length > 1)
                {
                    throw new MyException("系统错误，请重新尝试", null);
                }
                TTiaoma tm = tms[0];
                TJiamengshangJintuihuoMX[] omxes= db.GetJiamengshangJintuihuoMXes(id);
                if (omxes.Any(r => r.tiaomaid == tm.id))
                {
                    throw new MyException("条码[" + tmh + "]已经存在，请不要重复添加", null);
                }

                TJiamengshangJintuihuo jc = db.GetJiamengshangJintuihuosById(id);
                TJiamengshangJintuihuoMX mx = new TJiamengshangJintuihuoMX
                {
                    jintuiid = id,
                    tiaomaid = tm.id,
                    chengbenjia = tm.jinjia,
                    diaopaijia = tm.shoujia,
                    jinhuojia = decimal.Round(tm.shoujia * jc.zhekou / 10, 2),
                    shuliang = 1
                };

                db.InsertJiamengshangJinchuhuoMX(mx);

                //重新加载数据
                loadMX(id);
            }
            else if (e.CommandName == "DEL")
            {
                Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

                DBContext db = new DBContext();
                db.DeleteJiamengshangJintuihuo(id);

                btn_sch_Click(null, null);
            }
            else
            {
                throw new MyException("非法操作，请刷新页面后重新执行", null);
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
                zhekou = decimal.Round(r.jinhuojia / r.TTiaoma.shoujia * 10M, 2)
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
            Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

            int index = Convert.ToInt32(e.CommandArgument);
            int id = int.Parse(grid_mx.DataKeys[index].Value.ToString());
            if (e.CommandName == "DEL")
            {
                DBContext db = new DBContext();
                TJiamengshangJintuihuoMX om = db.GetJiamengshangJintuihuoMXById(id);
                db.DeleteJiamengshangJintuihuoMX(id);

                //重新加载数据
                loadMX(om.jintuiid);
            }
            else
            {
                throw new MyException("非法操作，请刷新页面后重新执行", null);
            }
        }

        /// <summary>
        /// 增加一个发货记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_fahuo_Click(object sender, EventArgs e)
        {
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
                caozuorenid = _LoginUser.id,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now
            };

            DBContext db = new DBContext();
            db.InsertJiamengshangJinchuhuo(jc);
        }

        /// <summary>
        /// 增加一个退货记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_tuihuo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmb_jms.SelectedValue))
            {
                throw new MyException("请先选择一个加盟商", null);
            }

            int jmsid = int.Parse(cmb_jms.SelectedValue);

            TJiamengshangJintuihuo jc = new TJiamengshangJintuihuo
            {
                fashengriqi = DateTime.Now,
                jmsid = jmsid,
                fangxiang = (byte)Tool.JCSJ.DBCONSTS.JMS_FHTH.退货,
                zhekou = 3,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now
            };

            DBContext db = new DBContext();
            db.InsertJiamengshangJinchuhuo(jc);
        }     
    }
}