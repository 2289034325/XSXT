using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

namespace JCSJGL
{
    public partial class Page_WodeXinxi : MyPage
    {
        public Page_WodeXinxi()
        {
            _PageName = PageName.我的信息;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //初始化
            if (!IsPostBack)
            {
                DBContext db = new DBContext();
                TJiamengshang j = db.GetJiamengshangById(_LoginUser.jmsid);
                //设置下拉框内容
                VDiqu[] dqs = db.GetAllDiqus();
                VDiqu[] shengs = dqs.Where(r => r.jibie == 0).ToArray();
                Tool.CommonFunc.InitDropDownList(cmb_sheng, shengs, "lujing", "id");
                cmb_sheng.Items.Insert(0, new ListItem("", ""));
                TDiqu dq = db.GetDiquById(j.diquid);
                VDiqu[] shis = dqs.Where(r => r.fid == dq.fid).ToArray();
                Tool.CommonFunc.InitDropDownList(cmb_shi, shis, "mingcheng", "id");


                txb_mc.Value = j.mingcheng;
                txb_sjh.Value = j.zhuceshouji;
                txb_yx.Value = j.zhuceyouxiang;
                cmb_sheng.SelectedValue = dq.fid.Value.ToString();
                cmb_shi.SelectedValue = dq.id.ToString();
                txb_lxr.Value = j.lianxiren;
                txb_dh.Value = j.dianhua;
                txb_dz.Value = j.dizhi;                
            }      
        }

        /// <summary>
        /// 保存我的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_save_Click(object sender, EventArgs e)
        {
            Authenticate.CheckOperation(this._PageName, PageOpt.修改, _LoginUser);

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
                id=  _LoginUser.jmsid,
                zhuceshouji = sjh,
                zhuceyouxiang = yx,
                diquid = dqid,
                dizhi = dz,
                lianxiren = lxr,
                dianhua = dh,
                xiugaishijian = DateTime.Now                
            };

            DBContext db = new DBContext();
            db.UpdateJiamengshangWodexinxi(j);
        }
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
    }
}