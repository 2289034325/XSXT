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
    public partial class Page_Dtyzm : MyPage
    {
        public Page_Dtyzm()
        {
            _PageName = PageName.动态验证码;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DBContext db = new DBContext();
                if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员)
                {
                    TPinpaishang j = db.GetPinpaishangById(_LoginUser.ppsid.Value);
                    div_yzm.InnerText = j.dtyzm;
                }
                else
                {
                    TJiamengshang j = db.GetJiamengshangById(_LoginUser.jmsid.Value);
                    div_yzm.InnerText = j.dtyzm;
 
                }
            }
        }

        /// <summary>
        /// 重新生成动态验证码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_renew_Click(object sender, EventArgs e)
        {
            DBContext db = new DBContext();
            string n = Tool.CommonFunc.GetRandomNum(6);
            if (_LoginUser.juese == (byte)Tool.JCSJ.DBCONSTS.USER_XTJS.品牌商管理员)
            {
                db.UpdatePinpaishangDtyzm(_LoginUser.ppsid.Value, n);
                div_yzm.InnerText = n;

            }
            else
            {
                db.UpdateJiamengshangDtyzm(_LoginUser.jmsid.Value, n);
                div_yzm.InnerText = n;
 
            }

        }
    }
}