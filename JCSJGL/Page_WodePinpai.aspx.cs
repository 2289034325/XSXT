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
    public partial class Page_WodePinpai : MyPage
    {
        public Page_WodePinpai()
        {
            _PageName = PageName.加盟品牌;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                DBContext db = new DBContext();
               
                //加载我的加盟申请记录
                loadWdsq();

                //加载我的品牌
                loadJmpps();
                
                //加盟品牌选择下拉框
                TPinpaishang[] ppses = db.GetPinpaishangs(null);
                Tool.CommonFunc.InitDropDownList(cmb_ppxz, ppses, "mingcheng", "id");
                cmb_ppxz.Items.Insert(0, new ListItem("", ""));
            }
        }

        
        private void loadJmpps()
        {
            DBContext db = new DBContext();
            TJiamengGX[] dlses = db.GetFuJiamengGXes(_LoginUser.jmsid.Value);
            var dlsesdata = dlses.Select(r => new
            {
                r.id,
                pinpai = r.TPinpaishang.mingcheng,
                r.TPinpaishang.lianxiren,
                r.TPinpaishang.dianhua,
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
                throw new MyException("请选择一个要加盟的品牌", null);
            }
            int ppsid = int.Parse(cmb_ppxz.SelectedValue.Split(new char[] { ',' })[0]);

            DBContext db = new DBContext();
            TPinpaishang[] yjms = db.GetPinpaishangs(_LoginUser.jmsid.Value);
            int[] dlsids = yjms.Select(r => r.id).ToArray();
            if (dlsids.Contains(ppsid))
            {
                throw new MyException("已加盟该品牌，请不要重复申请", null);
            }
            //检查已经加盟的代理商数量是否已超限制
            int cc = db.GetFuPinpaishangCount(_LoginUser.jmsid.Value);
            if (cc >= _LoginUser.TJiamengshang.pinpaishu)
            {
                throw new MyException("加盟的品牌已到上限，如果想要加盟更多的品牌请联系系统管理员", null);
            }

            //检查是否已经存在
            TJiamengSQ osq = db.GetJiamengSQByPpsIdJmsId(ppsid, _LoginUser.jmsid.Value);
            if (osq != null)
            {
                throw new MyException("请不要重复申请，或者删除旧的申请记录然后再申请加盟", null);
            }


            TJiamengSQ sq = new TJiamengSQ
            {
                ppsid = ppsid,
                jmsid = _LoginUser.jmsid.Value,
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
            TJiamengSQ[] sjsqs = db.GetMySjSQ(_LoginUser.jmsid.Value);
            var sjsqdata = sjsqs.Select(r => new
            {
                r.id,
                pinpai = r.TPinpaishang.mingcheng,
                r.TPinpaishang.lianxiren,
                r.TPinpaishang.dianhua,
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
        /// 删除申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_sjsq_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Page")
            {
                return;
            }

            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            int index = Convert.ToInt32(e.CommandArgument);
            int id = int.Parse(grid_sjsq.DataKeys[index].Values[0].ToString());
            if (e.CommandName == "SC")
            {
                DBContext db = new DBContext();
                db.DeleteJiamengSQ(id);
            }
            else
            {
                throw new MyException("非法操作", null);
            }

            //重新加载数据
            loadWdsq();
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