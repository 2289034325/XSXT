using DB_JCSJ;
using DB_JCSJ.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tool;

namespace JCSJGL
{
    public partial class Page_Dtzcm : MyPage
    {
        public Page_Dtzcm()
        {
            _PageName = PageName.注册码;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showZcms();
            }
        }

        /// <summary>
        /// 显示注册码
        /// </summary>
        private void showZcms()
        {
            List<string> zcms = SysTool.loadZcms();
            if (zcms.Count > 0)
            {
                div_zcm.InnerHtml = zcms.Aggregate((a, b) => { return a + "</br>" + b; });
            }
        }

        

        /// <summary>
        /// 生成10个新的注册码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_new_Click(object sender, EventArgs e)
        {
            //从文本文件加载                
            List<string> zcms = SysTool.loadZcms();
            List<string> nzcms = new List<string>();
            //生成新注册码
            while (true)
            {
                string nzcm = Tool.CommonFunc.GetRandomNum(6);
                if (!zcms.Contains(nzcm) && !nzcms.Contains(nzcm))
                {
                    nzcms.Add(nzcm);
                    if (nzcms.Count == 10)
                    {
                        break;
                    }
                }
            }
            //保存
            SysTool.addZcms(nzcms);

            showZcms();
        }
    }
}