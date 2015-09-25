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
    public partial class Page_JiamengshangGuanxi : MyPage
    {
        public Page_JiamengshangGuanxi()
        {
            _PageName = PageName.加盟商关系;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                DBContext db = new DBContext();
                //判断可创建的品牌数和可加盟的品牌数，决定是否显示创建品牌按钮和加盟品牌按钮
                int yjmsl = db.GetFuJiamengshangCount(_LoginUser.jmsid);
                if (yjmsl >= _LoginUser.TJiamengshang.fjmsshu)
                {
                    div_wyjmpp.Visible = false;
                }

                //加载我的加盟申请记录
                loadWdsq();

                //加载我的品牌
                loadJmpps();

                //下级加盟商的申请记录
                loadXjsq();

                //加载下属加盟商
                loadXjjms();

                //加盟品牌选择下拉框
                TJiamengshang[] yjms = db.GetFuJiamengshangs(_LoginUser.jmsid);
                int[] dlsids = yjms.Select(r => r.id).ToArray();
                //接受加盟，且不是自己的品牌，而且未加盟过的品牌
                TJiamengshang[] pps = db.GetJiamengshangsOfDingji().
                    Where(r => r.id != _LoginUser.jmsid && !dlsids.Contains(r.id)).ToArray();
                var jpps = pps.Select(r => new
                {
                    id = r.id,
                    pinpai = r.mingcheng
                }).ToArray();
                Tool.CommonFunc.InitDropDownList(cmb_ppxz, jpps, "pinpai", "id");
                cmb_ppxz.Items.Insert(0, new ListItem("", ""));
            }
        }

        /// <summary>
        /// 加载我的子加盟商信息
        /// </summary>
        private void loadXjjms()
        {
            DBContext db = new DBContext();
            TJiamengshangGX[] jmses = db.GetZiJiamengshangGXes(_LoginUser.jmsid);
            VDiqu[] dqs = db.GetAllDiqus();
            var jmsesdata = jmses.Select(r => new
            {
                jmsid = r.id,
                jiamengshang = r.Jms.mingcheng,
                r.bzmingcheng,
                r.Jms.lianxiren,
                r.Jms.dianhua,
                diqu = dqs.Single(rr => rr.id == r.Jms.diquid).lujing,
                r.Jms.dizhi,
                r.beizhu,
                jmsj = r.charushijian,
                editParams = r.id + ",'" + r.bzmingcheng + "','" + r.beizhu + "'"
            });
            grid_jms.DataSource = Tool.CommonFunc.LINQToDataTable(jmsesdata);
            grid_jms.DataBind();
        }

        /// <summary>
        /// 加载下级加盟商申请加盟我的记录
        /// </summary>
        private void loadXjsq()
        {
            DBContext db = new DBContext();
            TJiamengshangGXSQ[] xjsqs = db.GetMyXjSQ(_LoginUser.jmsid).Where(r => r.jieguo == (byte)Tool.JCSJ.DBCONSTS.JMSQ_JIEGUO.待审核).ToArray();
            VDiqu[] dqs = db.GetAllDiqus();
            var xjsqsdata = xjsqs.Select(r => new
            {
                r.id,
                jiamengshang = r.Jms.mingcheng,
                r.Jms.lianxiren,
                r.Jms.dianhua,
                diqu = dqs.Single(rr => rr.id == r.Jms.diquid).lujing,
                r.Jms.dizhi,
                sqsj = r.charushijian
            });
            grid_xjsq.DataSource = Tool.CommonFunc.LINQToDataTable(xjsqsdata);
            grid_xjsq.DataBind();
        }
        private void loadJmpps()
        {
            DBContext db = new DBContext();
            TJiamengshangGX[] dlses = db.GetFuJiamengshangGXes(_LoginUser.jmsid);
            var dlsesdata = dlses.Select(r => new
            {
                r.id,
                pinpai = r.Dls.mingcheng,
                r.Dls.lianxiren,
                r.Dls.dianhua,
                jmsj = r.charushijian
            });
            grid_jmpp.DataSource = Tool.CommonFunc.LINQToDataTable(dlsesdata);
            grid_jmpp.DataBind();
        }

        /// <summary>
        /// 加盟一个品牌，生成一个加盟申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_wyjm_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            //取得选中的品牌ID
            if (string.IsNullOrEmpty(cmb_ppxz.SelectedValue))
            {
                throw new MyException("请选择一个要加盟的代理商", null);
            }
            int dlsid = int.Parse(cmb_ppxz.SelectedValue.Split(new char[] { ',' })[0]);

            DBContext db = new DBContext();
            TJiamengshang[] yjms = db.GetFuJiamengshangs(_LoginUser.jmsid);
            int[] dlsids = yjms.Select(r => r.id).ToArray();
            if (dlsids.Contains(dlsid))
            {
                throw new MyException("已加盟该品牌，请不要重复申请", null);
            }
            //检查已经加盟的代理商数量是否已超限制
            int cc = db.GetFuJiamengshangCount(_LoginUser.jmsid);
            if (cc >= _LoginUser.TJiamengshang.fjmsshu)
            {
                throw new MyException("加盟的品牌已到上限，如果想要加盟更多的品牌请联系系统管理员", null);
            }
            //自己是品牌商，不允许再加盟别的品牌
            int zc = db.GetZiJiamengshangCount(_LoginUser.jmsid);
            if (zc != 0)
            {
                throw new MyException("您已经是代理商，不允许再加盟别的品牌", null);
            }
            //检查是否已经存在
            TJiamengshangGXSQ osq = db.GetJiamengGXSQByDlsIdJmsId(dlsid, _LoginUser.jmsid);
            if (osq != null)
            {
                throw new MyException("请不要重复申请，或者删除旧的申请记录然后再申请加盟", null);
            }


            TJiamengshangGXSQ sq = new TJiamengshangGXSQ
            {
                dlsid = dlsid,
                jmsid = _LoginUser.jmsid,
                jieguo = (byte)Tool.JCSJ.DBCONSTS.JMSQ_JIEGUO.待审核,
                charushijian = DateTime.Now
            };

            db.InsertJiamengGXSQ(sq);
            loadWdsq();
        }

        /// <summary>
        /// 加载我的申请加盟记录
        /// </summary>
        private void loadWdsq()
        {
            DBContext db = new DBContext();
            //我的申请记录*********************************************
            TJiamengshangGXSQ[] sjsqs = db.GetMySjSQ(_LoginUser.jmsid);
            var sjsqdata = sjsqs.Select(r => new
            {
                r.id,
                pinpai = r.Dls.mingcheng,
                r.Dls.lianxiren,
                r.Dls.dianhua,
                sqsj = r.charushijian,
                jieguo = ((Tool.JCSJ.DBCONSTS.JMSQ_JIEGUO)r.jieguo).ToString()
            });
            grid_sjsq.DataSource = Tool.CommonFunc.LINQToDataTable(sjsqdata);
            grid_sjsq.DataBind();
            if (sjsqs.Count() == 0)
            {
                lbl_wdsq.Visible = false;
            }
            else
            {
                lbl_wdsq.Visible = true;
            }
        }

        /// <summary>
        /// 处理加盟申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_xjsq_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            int index = Convert.ToInt32(e.CommandArgument);
            int id = int.Parse(grid_xjsq.DataKeys[index].Values[0].ToString());
            if (e.CommandName == "YES")
            {
                DBContext db = new DBContext();
                TJiamengshangGXSQ sq = db.GetJiamengGXSQById(id);
                TJiamengshangGX gx = new TJiamengshangGX
                {
                    dlsid = sq.dlsid,
                    jmsid = sq.jmsid,
                    bzmingcheng = sq.Jms.mingcheng,
                    beizhu = "",
                    charushijian = DateTime.Now
                };
                //自己是加盟商，不能再接受子加盟商
                int zc = db.GetFuJiamengshangCount(_LoginUser.jmsid);
                if (zc != 0)
                {
                    throw new MyException("您是加盟商，不允许再接受下级代理或加盟", null);
                }
                //检查子加盟商数是否超出
                int cc = db.GetZiJiamengshangCount(_LoginUser.jmsid);
                if (cc >= _LoginUser.TJiamengshang.zjmsshu)
                {
                    throw new MyException("子加盟商数量已到上限，如有需要让更多加盟商加盟您的品牌请联系系统管理员", null);
                }

                db.InsertJiamengGX(gx);
                //删除申请记录
                db.DeleteJiamengGXSQ(id);
            }
            else if (e.CommandName == "NO")
            {
                DBContext db = new DBContext();
                db.UpdateJiamengGXSQShenhe(id, (byte)Tool.JCSJ.DBCONSTS.JMSQ_JIEGUO.拒绝);
            }
            else
            {
                throw new MyException("非法操作", null);
            }

            //重新加载表格
            loadXjsq();
            loadXjjms();
        }

        /// <summary>
        /// 被拒绝后再次提出申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_sjsq_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            int index = Convert.ToInt32(e.CommandArgument);
            int id = int.Parse(grid_sjsq.DataKeys[index].Values[0].ToString());
            if (e.CommandName == "SC")
            {
                DBContext db = new DBContext();
                db.DeleteJiamengGXSQ(id);
            }
            else
            {
                throw new MyException("非法操作", null);
            }

            //重新加载数据
            loadWdsq();
        }

        /// <summary>
        /// 修改子加盟商备注
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.修改, _LoginUser);

            int id = int.Parse(hid_id.Value);
            string bzmc = txb_bzmc.Text.Trim();
            string bz = txb_bz.Text.Trim();
            TJiamengshangGX g = new TJiamengshangGX
            {
                id = id,
                bzmingcheng = bzmc,
                beizhu = bz
            };

            DBContext db = new DBContext();
            TJiamengshangGX og = db.GetJiamengGXById(id);
            if (og.dlsid != _LoginUser.jmsid)
            {
                throw new MyException("非法操作，无法修改", null);
            }
            db.UpdateJiamengGXBeizhu(g);

            //重新加载数据
            loadXjjms();
        }

        /// <summary>
        /// 退出加盟
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_jmpp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

            int id = int.Parse(grid_jmpp.DataKeys[e.RowIndex].Value.ToString());

            DBContext db = new DBContext();
            db.DeleteJiamengGX(id);

            //重新加载数据
            loadJmpps();
        }
    }
}