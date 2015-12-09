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
    public partial class Page_WodeJiamengshang : MyPage
    {
        public Page_WodeJiamengshang()
        {
            _PageName = PageName.子加盟商;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                DBContext db = new DBContext();                

                //下级加盟商的申请记录
                loadXjsq();

                //加载下属加盟商
                loadXjjms();
            }
        }

        /// <summary>
        /// 加载我的子加盟商信息
        /// </summary>
        private void loadXjjms()
        {
            DBContext db = new DBContext();
            TJiamengGX[] jmses = db.GetZiJiamengGXes(_LoginUser.ppsid.Value);
            VDiqu[] dqs = db.GetAllDiqus();
            var jmsesdata = jmses.Select(r => new
            {
                jmsid = r.id,
                jiamengshang = r.TJiamengshang.mingcheng,
                r.bzmingcheng,
                r.TJiamengshang.lianxiren,
                r.TJiamengshang.dianhua,
                diqu = dqs.Single(rr => rr.id == r.TJiamengshang.diquid).lujing,
                r.TJiamengshang.dizhi,
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
            TJiamengSQ[] axjsqs = db.GetMyXjSQ(_LoginUser.ppsid.Value);
            TJiamengSQ[] xjsqs = axjsqs.Where(r => r.jieguo == (byte)Tool.JCSJ.DBCONSTS.JMSQ_JIEGUO.待审核).ToArray();
            VDiqu[] dqs = db.GetAllDiqus();
            var xjsqsdata = xjsqs.Select(r => new
            {
                r.id,
                jiamengshang = r.TJiamengshang.mingcheng,
                r.TJiamengshang.lianxiren,
                r.TJiamengshang.dianhua,
                diqu = dqs.Single(rr => rr.id == r.TJiamengshang.diquid).lujing,
                r.TJiamengshang.dizhi,
                sqsj = r.charushijian
            });
            grid_xjsq.DataSource = Tool.CommonFunc.LINQToDataTable(xjsqsdata);
            grid_xjsq.DataBind();
        }
             

        /// <summary>
        /// 处理加盟申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_xjsq_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                return;
            }

            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            int index = Convert.ToInt32(e.CommandArgument);
            int id = int.Parse(grid_xjsq.DataKeys[index].Values[0].ToString());
            if (e.CommandName == "YES")
            {
                DBContext db = new DBContext();
                TJiamengSQ sq = db.GetJiamengGXSQById(id);
                TJiamengGX gx = new TJiamengGX
                {
                    ppsid = sq.ppsid,
                    jmsid = sq.jmsid,
                    bzmingcheng = sq.TJiamengshang.mingcheng,
                    beizhu = "",
                    charushijian = DateTime.Now
                };

                //检查子加盟商数是否超出
                int cc = db.GetZiJiamengshangCount(_LoginUser.ppsid.Value);
                if (cc >= _LoginUser.TPinpaishang.jmsshu)
                {
                    throw new MyException("加盟商数量已到上限，如有需要让更多加盟商加盟您的品牌请联系系统管理员", null);
                }

                db.InsertJiamengGX(gx);
                //删除申请记录
                db.DeleteJiamengSQ(id);
            }
            else if (e.CommandName == "NO")
            {
                DBContext db = new DBContext();
                db.UpdateJiamengSQShenhe(id, (byte)Tool.JCSJ.DBCONSTS.JMSQ_JIEGUO.拒绝);
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
            TJiamengGX g = new TJiamengGX
            {
                id = id,
                bzmingcheng = bzmc,
                beizhu = bz
            };

            DBContext db = new DBContext();
            TJiamengGX og = db.GetJiamengGXById(id);
            if (og.ppsid != _LoginUser.ppsid.Value)
            {
                throw new MyException("非法操作，无法修改", null);
            }
            db.UpdateJiamengGXBeizhu(g);

            //重新加载数据
            loadXjjms();
        }
    }
}