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
                cmb_zhlx.Items.Insert(0, new ListItem("品牌商", "pps"));
                cmb_zhlx.Items.Insert(0, new ListItem("加盟商", "jms"));

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
            DBContext db = new DBContext();
            
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
            if (db.GetPinpaishangBySjh(sjh) != null || db.GetJiamengshangBySjh(sjh) != null)
            {
                throw new MyException("该手机号已经被注册，请换一个手机号注册", null);
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

            ////生成一个4位代码
            //short[] dms = db.GetPinpaishangDaimas();
            //short ndm = 0;
            //if (dms.Count() >= 9000)
            //{
            //    throw new MyException("用户数已到上限，无法再注册", null);
            //}
            //if (dms.Count() == 0)
            //{
            //    //最小代码从1000开始，0开头的条码不好看
            //    ndm = 1000;
            //}
            //else
            //{
            //    for (int i = 0; i < dms.Length - 1; i++)
            //    {
            //        if (dms[i + 1] - dms[i] > 1)
            //        {
            //            ndm = (short)(dms[i] + 1);
            //            break;
            //        }
            //    }
            //    if (ndm == 0)
            //    {
            //        ndm = (short)(dms.Max() + 1);
            //    }
            //}
           
            ////控制新产生的代码，避免超过9999
            //if (ndm > 9999 || ndm < 1000)
            //{
            //    throw new MyException("系统错误，请重新提交注册", null);
            //}



            string zhlx = cmb_zhlx.SelectedValue;
            if (zhlx == "jms")
            {
                short? dmax = db.GetJiamengshangDaimaMax();
                short ndm = dmax == null ? ((short)1000) : ((short)(dmax.Value + 1));
                if (ndm > 9999)
                {
                    throw new MyException("系统错误，无法注册", null);
                }

                TJiamengshang j = new TJiamengshang
                {
                    //基本信息
                    daima = ndm,
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
                    pinpaishu = 1,
                    zhanghaoshu = 3,
                    huiyuanshu = 10000,
                    fendianshu = 1,
                    xsjilushu = 10000,
                    jchjilushu = 10000,
                    kcjilushu = 10000
                };

                //以手机号做一个管理员账号
                j.TUsers.Add(new TUser
                {
                    dengluming = sjh,
                    mima = Tool.CommonFunc.MD5_16(mm),
                    yonghuming = mc,
                    jiqima = Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetRandomNum(6)),
                    juese = (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.加盟商管理员,
                    zhuangtai = (byte)Tool.JCSJ.DBCONSTS.USER_ZT.可用,
                    beizhu = "",
                    charushijian = DateTime.Now,
                    xiugaishijian = DateTime.Now
                });

                db.InsertJiamengshang(j);
            }
            else
            {
                short? dmax = db.GetPinpaishangDaimaMax();
                short ndm = dmax == null ? ((short)1000) : ((short)(dmax.Value + 1));
                if (ndm > 9999)
                {
                    throw new MyException("系统错误，无法注册", null);
                }

                TPinpaishang p = new TPinpaishang
                {
                    mingcheng = mc,
                    daima = ndm,
                    shoujihao = sjh,
                    youxiang = yx,
                    diquid = dqid,
                    dizhi = dz,
                    lianxiren = lxr,
                    dianhua = dh,
                    beizhu = "",
                    zhanghaoshu = 5,
                    jchjilushu = 10000,
                    kcjilushu = 10000,
                    kuanhaoshu = 10000,
                    tiaomashu = 10000,
                    cangkushu = 1,
                    jmsshu = 50,
                    gysshu = 100,
                    dtyzm = Tool.CommonFunc.GetRandomNum(6),
                    charushijian = DateTime.Now,
                    xiugaishijian = DateTime.Now
                };
                
                p.TUsers.Add(new TUser
                {
                    dengluming = sjh,
                    mima = Tool.CommonFunc.MD5_16(mm),
                    yonghuming = mc,
                    jiqima = Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetRandomNum(6)),
                    juese = (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员,
                    zhuangtai = (byte)Tool.JCSJ.DBCONSTS.USER_ZT.可用,
                    beizhu = "",
                    charushijian = DateTime.Now,
                    xiugaishijian = DateTime.Now
                });

                db.InsertPinpaishang(p);
            }

            //将用过的注册码删去
            SysTool.delZcm(zcm);

            //转向登陆页面
            Response.Write("<script>alert('注册成功，点击确定转到登录页面');window.location='Login.aspx';</script>");
        }       
    }
}