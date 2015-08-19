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
    public partial class Page_FDKucun : MyPage
    {
        public Page_FDKucun()
        {
            _PageName = PageName.分店库存;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //初始化分店下拉框
                DBContext db = new DBContext();
                TFendian[] fs = null;

                //隐藏搜索条件
                div_sch_jms.Visible = false;

                //初始化分店下拉框
                int? jmsid = null;
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                    _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
                {
                    //显示搜索
                    div_sch_jms.Visible = true;

                    TJiamengshang[] jmss = db.GetJiamengshangs();
                    Tool.CommonFunc.InitDropDownList(cmb_jms, jmss, "mingcheng", "id");
                    cmb_jms.Items.Insert(0, new ListItem("所有加盟商", ""));

                    fs = new TFendian[] { };
                }
                else
                {
                    jmsid = _LoginUser.jmsid;

                    fs = db.GetFendiansAsItems(jmsid);
                }

                Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
                cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));

                string fdid_s = Request["fdid"];
                if (!string.IsNullOrEmpty(fdid_s))
                {
                    int fdid = int.Parse(fdid_s);
                    cmb_fd.SelectedValue = fdid.ToString();

                    //加载某分店的历史库存
                    loadHistroy(fdid);
                }
                else
                {
                    //加载总库存和加盟商旗下的每个分店的最新库存数据
                    loadKCOfFendians(null);
                }
            }
        }

        /// <summary>
        /// 加载所有分店的最新库存数据
        /// </summary>
        private void loadKCOfFendians(int? fdid)
        {
            grid_kc_total.Visible = true;
            grid_kc_fd.Visible = true;
            grid_kc.Visible = false;

            DBContext db = new DBContext();
            int? jmsid = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    jmsid = int.Parse(cmb_jms.SelectedValue);
                }
                grid_kc_total.Columns[0].Visible = true;
                grid_kc_fd.Columns[0].Visible = true;
            }
            else
            {
                grid_kc_total.Columns[0].Visible = false;
                grid_kc_fd.Columns[0].Visible = false;
                jmsid = _LoginUser.jmsid;
            }
            TFendianKucun[] jcs = db.GetFDKucunByCond(jmsid, fdid, true);
            var xs = jcs.Select(r => new
            {
                jiamengshang = r.TFendian.TJiamengshang.mingcheng,
                fdid = r.fendianid,
                fendian = r.TFendian.dianming,
                kucunshuliang = r.TFendianKucunMXes.Sum(mr => mr.shuliang),
                chengbenjine = r.TFendianKucunMXes.Sum(mr => mr.TTiaoma.jinjia * mr.shuliang),
                shoujiajine = r.TFendianKucunMXes.Sum(mr => mr.TTiaoma.shoujia * mr.shuliang),
                r.shangbaoshijian
            });

            grid_kc_fd.DataSource = Tool.CommonFunc.LINQToDataTable(xs);
            grid_kc_fd.DataBind();

            //总库存
            var data = xs.GroupBy(r=>r.jiamengshang).Select(r => new
            {
                jiamengshang = r.Key,
                kucunshuliang = r.Sum(xr => xr.kucunshuliang),
                chengbenjine = decimal.Round(r.Sum(xr => xr.chengbenjine), 2),
                shoujiajine = decimal.Round(r.Sum(xr => xr.shoujiajine), 2),
                shangbaoshijian = r.Min(xr=>(DateTime?)xr.shangbaoshijian)
            });

            grid_kc_total.DataSource = Tool.CommonFunc.LINQToDataTable(data);
            grid_kc_total.DataBind();
        }

        /// <summary>
        /// 加载某个分店的历史库存数据
        /// </summary>
        /// <param name="fdid"></param>
        private void loadHistroy(int fdid)
        {
            grid_kc_total.Visible = false;
            grid_kc_fd.Visible = false;
            grid_kc.Visible = true;

            DBContext db = new DBContext();
            int? jmsid = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    jmsid = int.Parse(cmb_jms.SelectedValue);
                }
                grid_kc.Columns[0].Visible = true;
            }
            else
            {
                jmsid = _LoginUser.jmsid;
                grid_kc.Columns[0].Visible = false;
            }
            TFendianKucun[] jcs = db.GetFDKucunByCond(jmsid, fdid, false);
            var xs = jcs.Select(r => new
            {
                jiamengshang = r.TFendian.TJiamengshang.mingcheng,
                id = r.id,
                fendian = r.TFendian.dianming,
                kucunshuliang = r.TFendianKucunMXes.Sum(mr => mr.shuliang),
                chengbenjine = r.TFendianKucunMXes.Sum(mr => mr.TTiaoma.jinjia * mr.shuliang),
                shoujiajine = r.TFendianKucunMXes.Sum(mr => mr.TTiaoma.shoujia * mr.shuliang),
                r.shangbaoshijian
            });

            grid_kc.DataSource = Tool.CommonFunc.LINQToDataTable(xs);
            grid_kc.DataBind();
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_sch_Click(object sender, EventArgs e)
        {
            //取查询条件
            int? fdid = null;
            if (!string.IsNullOrEmpty(cmb_fd.SelectedValue))
            {
                fdid = int.Parse(cmb_fd.SelectedValue);
            }

            loadKCOfFendians(fdid);
        }

        /// <summary>
        /// 删除一个库存历史记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_kc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //检查权限
            Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

            int id = int.Parse(grid_kc.DataKeys[e.RowIndex].Value.ToString());

            DBContext db = new DBContext();
            TFendianKucun ok = db.GetFDKucunById(id);
            if (ok.TFendian.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法删除该数据");
            }

            db.DeleteFDKucun(id); 

            loadHistroy(ok.fendianid);
        }

        protected void cmb_jms_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid_kc_total.DataSource = null;
            grid_kc_total.DataBind();
            grid_kc_fd.DataSource = null;
            grid_kc_fd.DataBind();
            grid_kc.DataSource = null;
            grid_kc.DataBind();

            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                cmb_fd.Items.Clear();
                DBContext db = new DBContext();
                if (!string.IsNullOrEmpty(cmb_jms.SelectedValue))
                {
                    int jmsid = int.Parse(cmb_jms.SelectedValue);
                    TFendian[] fs = db.GetFendiansAsItems(jmsid);

                    Tool.CommonFunc.InitDropDownList(cmb_fd, fs, "dianming", "id");
                    cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
                }
                else
                {
                    cmb_fd.Items.Insert(0, new ListItem("所有分店", ""));
                }
            }
            else
            {
                //其他角色不可能触发该事件，如果有，判定为浏览器操作漏洞
                throw new MyException("非法操作，请刷新页面重新执行");
            }
        }
    }
}