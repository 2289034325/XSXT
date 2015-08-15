using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JCSJGL
{
    public partial class Page_Huiyuan : MyPage
    {
        public Page_Huiyuan()
        {
            _PageName = PageName.会员信息;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                //初始化下拉框
                Tool.CommonFunc.InitDropDownList(cmb_xb, typeof(Tool.JCSJ.DBCONSTS.HUIYUAN_XB));

                //加载所有会员信息
                loadHuiyuans();
            }           
        }        

        /// <summary>
        /// 加载所有会员信息
        /// </summary>
        private void loadHuiyuans()
        {
            DBContext db = new DBContext();
            int? jmsid = null;
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员 ||
                _LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.总经理)
            {
                grid_huiyuan.Columns[0].Visible = true;
            }
            else
            {
                grid_huiyuan.Columns[0].Visible = false;
                jmsid = _LoginUser.jmsid;
            }
            THuiyuan[] fs = db.GetHuiyuans(jmsid);
            var dfs = fs.Select(r => new
            {
                id = r.id,
                jiamengshang = r.TFendian.TJiamengshang.mingcheng,
                fendian = r.TFendian.dianming,
                shoujihao = r.shoujihao,
                xingming = r.xingming,
                xingbie = ((Tool.JCSJ.DBCONSTS.HUIYUAN_XB)r.xingbie).ToString(),
                shengri = r.shengri.ToString("yyyy-MM-dd"),
                jifen = r.jifen,
                jfjsshijian = r.jfjsshijian,
                beizhu = r.beizhu,
                //caozuoren = r.TUser.yonghuming,
                charushijian = r.charushijian,
                xiugaishijian = r.xiugaishijian,
                editParams = r.id + ",'" + r.shoujihao + "','" + r.xingming + "','" + r.xingbie + "','" + r.shengri.ToString("yyyy-MM-dd") + "','" +
                             r.beizhu + "'"
            });

            grid_huiyuan.DataSource = Tool.CommonFunc.LINQToDataTable(dfs);
            grid_huiyuan.DataBind();
        }

        /// <summary>
        /// 加载会员积分折扣规则
        /// </summary>
        //private void loadHuiyuanZKs()
        //{
        //    DBContext db = new DBContext();

        //    THuiyuanZK[] zs = db.GetHuiyuanZKs();
        //    grid_zhekou.DataSource = zs.OrderBy(r=>r.jifen).ToArray();
        //    grid_zhekou.DataBind();
        //}

        /// <summary>
        /// 修改会员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            THuiyuan f = getEditInfo();
            f.id = int.Parse(hid_id.Value);
            //f.caozuorenid = _LoginUser.id;
            f.xiugaishijian = DateTime.Now;

            DBContext db = new DBContext();
            THuiyuan oh = db.GetHuiyuanById(f.id);
            if (oh.TFendian.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法修改该会员信息");
            }
            db.UpdateHuiyuan(f);

            loadHuiyuans();
        }

        /// <summary>
        /// 取得编辑信息
        /// </summary>
        /// <returns></returns>
        private THuiyuan getEditInfo()
        {
            string shoujihao = txb_sjh.Text.Trim();
            string xingming = txb_xm.Text.Trim();
            byte xingbie = byte.Parse(cmb_xb.SelectedValue);
            DateTime shengri = DateTime.Parse(txb_sr.Text.Trim());
            string bz = txb_bz.Text.Trim();

            string errMsg = "非法操作，请刷新页面重新执行";
            if (!Enum.IsDefined(typeof(Tool.JCSJ.DBCONSTS.HUIYUAN_XB), xingbie))
            {
                throw new MyException(errMsg);
            }

            THuiyuan f = new THuiyuan
            {
                shoujihao = shoujihao,
                xingming = xingming,
                xingbie = xingbie,
                shengri = shengri,
                beizhu = bz
            };

            return f;
        }

        /// <summary>
        /// 删除一个会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_huiyuan_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Authenticate.CheckOperation(_PageName, PageOpt.删除, _LoginUser);

            int id = int.Parse(grid_huiyuan.DataKeys[e.RowIndex].Value.ToString());

            DBContext db = new DBContext();
            THuiyuan og = db.GetHuiyuanById(id);
            if (og.TFendian.jmsid != _LoginUser.jmsid && _LoginUser.juese != (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.系统管理员)
            {
                throw new MyException("非法操作，无法删除该会员");
            }

            db.DeleteHuiyuan(id);

            loadHuiyuans();
        }

        /// <summary>
        /// 新增一个会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btn_add_Click(object sender, EventArgs e)
        //{
        //    THuiyuan f = getEditInfo();
        //    f.caozuorenid = _LoginUser.id;
        //    f.jfjsshijian = DateTime.Now;
        //    f.charushijian = DateTime.Now;
        //    f.xiugaishijian = DateTime.Now;

        //    DBContext db = new DBContext();
        //    db.InsertHuiyuan(f);

        //    loadHuiyuans();
        //}

        /// <summary>
        /// 增加一个积分折扣规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected void btn_zk_add_Click(object sender, EventArgs e)
        //{
        //    string sjf = txb_jf.Text.Trim();
        //    string szk = txb_zk.Text.Trim();

        //    decimal jf = decimal.Parse(sjf);
        //    decimal zk = decimal.Parse(szk);

        //    THuiyuanZK z = new THuiyuanZK 
        //    {
        //        jifen = jf,
        //        zhekou = zk
        //    };

        //    DBContext db = new DBContext();
        //    db.InsertHuiyuanZK(z);

        //    loadHuiyuanZKs();
        //}
    }
}