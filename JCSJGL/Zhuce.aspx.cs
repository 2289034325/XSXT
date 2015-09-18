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
            string zcm = txb_zcm.Value.Trim();
            List<string> zcms = SysTool.loadZcms();
            if (!zcms.Contains(zcm))
            {
                throw new MyException("注册码错误",null);
            }

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

            //生成一个随机的4位代码
            DBContext db = new DBContext();
            short[] dms = db.GetJiamengshangDaimas();
            short ndm = 0;
            if (dms.Count() >= 9000)
            {
                throw new MyException("用户数已到上限，无法再注册", null);
            }
            if (dms.Count() == 0)
            {
                //最小代码从1000开始，0开头的条码不好看
                ndm = 1000;
            }
            else
            {
                for (int i = 0; i < dms.Length - 1; i++)
                {
                    if (dms[i + 1] - dms[i] > 1)
                    {
                        ndm = (short)(dms[i] + 1);
                        break;
                    }
                }
                if (ndm == 0)
                {
                    ndm = (short)(dms.Max() + 1);
                }
            }
           
            //控制新产生的代码，避免超过9999
            if (ndm > 9999 || ndm < 1000)
            {
                throw new MyException("系统错误，请重新提交注册", null);
            }

            TJiamengshang j = new TJiamengshang
            {
                //基本信息
                mingcheng = mc,
                daima = ndm,
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
                fjmsshu= 1,
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

            db.InsertJiamengshang(j);

            //将用过的注册码删去
            SysTool.delZcm(zcm);

            Response.Write("<script>alert('注册成功');window.location='Login.aspx';</script>");

            //转向登陆页面
            //Response.Redirect("Login.aspx");
        }       
    }
}