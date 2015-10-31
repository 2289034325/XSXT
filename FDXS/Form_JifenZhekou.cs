using DB_FD;
using DB_FD.Models;
using FDXS.Properties;
using MyFormControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace FDXS
{
    public partial class Form_JifenZhekou : MyForm
    {
        public Form_JifenZhekou()
        {
            InitializeComponent();
            base.InitializeComponent();
        }

        /// <summary>
        /// 更新积分规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sch_Click(object sender, EventArgs e)
        {
            //new Tool.ActionMessageTool(btn_sch_Click_sync, false).Start();      
        }
        private void btn_sch_Click_sync(Tool.ActionMessageTool.ShowMsg ShowMsg)
        {
            //try
            //{
            //    JCSJData.THuiyuanZK[] zks = JCSJWCF.GetHuiyuanZhekous();

            //    DBContext db = IDB.GetDB();
            //    THuiyuanZK[] fzks = zks.Select(r => new THuiyuanZK
            //    {
            //        jifen = r.jifen,
            //        zhekou = r.zhekou,
            //        gengxinshijian = DateTime.Now
            //    }).ToArray();
            //    db.DeleteHuiyuanZK();
            //    db.InsertHuiyuanZKs(fzks);

            //    grid_zk.Rows.Clear();
            //    foreach (THuiyuanZK zk in fzks)
            //    {
            //        grid_zk.Rows.Add(new object[] 
            //        {
            //            zk.jifen,
            //            zk.zhekou
            //        });
            //    }

            //    ShowMsg("更新成功", false);
            //}
            //catch (Exception ex)
            //{
            //    Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
            //    ShowMsg(ex.Message, true);
            //}
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KucunYilan_Load(object sender, EventArgs e)
        {
            //加载积分折扣规则
            DBContext db = IDB.GetDB();
            THuiyuanZK[] zks = db.GetHuiyuanZKs();
            zks = zks.OrderBy(z => z.jifen).ToArray();

            foreach (THuiyuanZK zk in zks)
            {
                grid_zk.Rows.Add(new object[] 
                {
                    zk.jifen,
                    zk.zhekou
                });
            }
        }
    }
}
