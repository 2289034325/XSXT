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
    public partial class Zhuce : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DBContext db = new DBContext();
                VDiqu[] dqs = db.GetAllDiqus();
                VDiqu[] shengs = dqs.Where(r => r.jibie == 0).ToArray();
                Tool.CommonFunc.InitDropDownList(cmb_sheng, shengs, "lujing", "id");
                cmb_sheng.Items.Insert(0, new ListItem("", ""));
            }
        }

        /// <summary>
        /// 省市下拉框联动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cmb_sheng_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sid = 0;
            cmb_shi.Items.Clear();
            if (int.TryParse(cmb_sheng.SelectedValue, out sid))
            {
                DBContext db = new DBContext();
                VDiqu[] dqs = db.GetAllDiqus();
                VDiqu[] shis = dqs.Where(r => r.fid == sid).ToArray();

                Tool.CommonFunc.InitDropDownList(cmb_shi, shis, "mingcheng", "id");
                cmb_shi.Items.Insert(0, new ListItem("", ""));
            }
        }

        /// <summary>
        /// 提交注册信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_zhuce_Click(object sender, EventArgs e)
        {
            string mc = txb_mc.Value.Trim();
            if (string.IsNullOrEmpty(mc))
            {
                throw new MyException("请输入一个名称", null);
            }
            string sjh = txb_sjh.Value.Trim();
            if (!Tool.CommonFunc.IsTelNum(sjh))
            {
                throw new MyException("手机号格式错误", null);
            }
            string mm = txb_mm.Value;

            string mmqr = txb_mmqr.Value;
            if (string.IsNullOrEmpty(mm) || string.IsNullOrEmpty(mmqr))
            {
                throw new MyException("密码不能为空白", null);
            }
            if (mm != mmqr)
            {
                throw new MyException("两次输入的密码不一致，请重新输入", null);
            }
            string yx = txb_yx.Value.Trim();
            if (string.IsNullOrEmpty(yx))
            {
                throw new MyException("请输入一个邮箱", null);
            }

            string lxr = txb_lxr.Value.Trim();
            string dh = txb_dh.Value.Trim();
            int dqid = 0;
            if (!int.TryParse(cmb_shi.SelectedValue, out dqid))
            {
                throw new MyException("请选择一个省市地区", null);
            }
            string dz = txb_dz.Value.Trim();

            TJiamengshang j = new TJiamengshang
            {
                //基本信息
                mingcheng = mc,
                zhuceshouji = sjh,
                zhuceyouxiang = yx,
                diquid = dqid,
                dizhi = dz,
                lianxiren = lxr,
                dianhua = dh,
                beizhu = "",
                dtyzm = Tool.CommonFunc.GetRandomNum(6),
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now,

                //用量
                zjmsshu = 0,
                zhanghaoshu = 3,
                kuanhaoshu = 10000,
                tiaomashu = 100000,
                huiyuanshu = 10000,
                fendianshu = 1,
                cangkushu = 0,
                gongyingshangshu = 1,
                xsjilushu = 10000,
                jchjilushu = 10000,
                kcjilushu = 10000,
                shoucifufei = 0,
                xufeidanjia = 0,
                jiezhiriqi = DateTime.Now
            };

            //以手机号做一个管理员账号
            j.TUsers.Add(new TUser
            {
                dengluming = sjh,
                mima = Tool.CommonFunc.MD5_16(mm),
                yonghuming = mc,
                jiqima = Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetRandomNum(6)),
                juese = (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.管理员,
                zhuangtai = (byte)Tool.JCSJ.DBCONSTS.USER_ZT.可用,
                beizhu = "",
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now
            });

            DBContext db = new DBContext();
            db.InsertJiamengshang(j);

            //转向登陆页面
            Response.Redirect("Login.aspx");
        }       
    }
}