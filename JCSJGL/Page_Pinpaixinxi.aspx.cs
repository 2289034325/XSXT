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
    public partial class Page_PinpaiXinxi : MyPage
    {
        public Page_PinpaiXinxi()
        {
            _PageName = PageName.品牌信息;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                //加载所有加盟商信息
                loadYcPp();

                //是否可加盟下拉框
                Tool.CommonFunc.InitDropDownList(cmb_sfjsjm, typeof(Tool.JCSJ.DBCONSTS.JMS_PP_KJM));
            }
        }
        

        /// <summary>
        /// 加载原创品牌
        /// </summary>
        private void loadYcPp()
        {
            DBContext db = new DBContext();
            int? jmsid = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                grid_ycpp.Columns[0].Visible = true;
            }
            else
            {
                jmsid = _LoginUser.jmsid;
                grid_ycpp.Columns[0].Visible = false;
            }
            TPinpai[] pps = db.GetYuanchuangPinpaisByJmsId(jmsid);
            var ycpps = pps.Select(r => new
            {
                jms = r.TJiamengshang.mingcheng,
                r.id,
                r.mingcheng,
                kejiameng = ((Tool.JCSJ.DBCONSTS.JMS_PP_KJM)r.kejiameng).ToString(),
                editParams = r.id + ",'" + r.mingcheng + "'," + r.kejiameng
            });
            grid_ycpp.DataSource = Tool.CommonFunc.LINQToDataTable(ycpps);
            grid_ycpp.DataBind();
        }

        /// <summary>
        /// 编辑品牌信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_pp_edit_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.修改, _LoginUser);

            if (string.IsNullOrEmpty(hid_id.Value))
            {
                throw new MyException("请先选中需要修改的品牌", null);
            }
            int id = int.Parse(hid_id.Value);
            hid_id.Value = "";//防止重复执行
            string mc = txb_ppmc.Text.Trim();
            byte sfjsjm = byte.Parse(cmb_sfjsjm.SelectedValue);
            TPinpai p = new TPinpai
            {
                id = id,
                mingcheng = mc,
                kejiameng = sfjsjm,
                xiugaishijian = DateTime.Now
            };

            DBContext db = new DBContext();
            TPinpai op = db.GetPinpaiById(id);
            if (op.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法修改此品牌信息", null);
            }

            db.UpdateJiamengshangPinpai(p);

            //重新加载数据
            loadYcPp();
        }

        /// <summary>
        /// 删除品牌信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_ycpp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

            int id = int.Parse(grid_ycpp.DataKeys[e.RowIndex].Value.ToString());

            DBContext db = new DBContext();
            TPinpai of = db.GetPinpaiById(id);
            if (of.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法删除该品牌", null);
            }
            db.DeleteFendian(id);

            //重新加载数据
            loadYcPp();
        }

        /// <summary>
        /// 增加一个品牌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.增加, _LoginUser);

            DBContext db = new DBContext();
            int ycppsl = db.GetYCPinpaiCount(_LoginUser.jmsid);
            int jmppsl = db.GetJMPinpaiCount(_LoginUser.jmsid);
            if (ycppsl > 0)
            {
                throw new MyException("只能创建一个品牌", null);
            }
            if (ycppsl + jmppsl >= _LoginUser.TJiamengshang.ppshu)
            {
                throw new MyException("创建和加盟的品牌数量已到达上限，如要创建或者加盟更多品牌请联系系统管理员", null);
            }

            string mc = txb_ppmc.Text.Trim();
            byte sfjsjm = byte.Parse(cmb_sfjsjm.SelectedValue);
            TPinpai p = new TPinpai
            {
                jmsid = _LoginUser.jmsid,
                mingcheng = mc,
                kejiameng = sfjsjm,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now
            };

            db.InsertJiamengshangPinpai(p);

            //重新加载数据
            loadYcPp();
        }
    }
}