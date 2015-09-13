using CKGL.Properties;
using DB_CK;
using DB_CK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CKGL
{
    public partial class Form_KucunYilan : Form
    {
        public Form_KucunYilan()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sch_Click(object sender, EventArgs e)
        {
            //查询条件
            string tmh = txb_tiaoma.Text.Trim();
            string kh = txb_kuanhao.Text.Trim();
            string lx = cmb_leixing.SelectedValue.ToString();

            //入-出+库存修正
            DBContext db = IDB.GetDB();
            Dictionary<TTiaoma, short> ks = db.GetKucunView(tmh, kh, lx);

            grid_kc.Rows.Clear();
            foreach (KeyValuePair<TTiaoma, short> p in ks)
            {
                grid_kc.Rows.Add(new object[] 
                    {
                        p.Key.tiaoma,
                        p.Key.kuanhao,
                        p.Key.gyskuanhao,
                        ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)p.Key.leixing).ToString(),
                        p.Key.pinming,
                        p.Key.yanse,
                        p.Key.chima,
                        p.Key.shoujia,
                        p.Value
                    });
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KucunYilan_Load(object sender, EventArgs e)
        {
            //类型下拉框
            Tool.CommonFunc.InitCombbox(cmb_leixing, typeof(Tool.JCSJ.DBCONSTS.KUANHAO_LX));
            DataTable dt = (DataTable)cmb_leixing.DataSource;
            dt.Rows.InsertAt(dt.NewRow(), 0);
            cmb_leixing.SelectedIndex = 0;
        }

        /// <summary>
        /// 想数据中心上报库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_shangbao_Click(object sender, EventArgs e)
        {
            DBContext db = IDB.GetDB();
            VKucun[] ks = db.GetKucunsByCond(1, null);

            JCSJData.TCangkuKucunMX[] fks = ks.Select(r => new JCSJData.TCangkuKucunMX
            {
                tiaomaid = r.id,
                shuliang = r.shuliang,
                jinhuoriqi = r.jinhuoriqi.Value
                
            }).ToArray();

            new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
            {
                try
                {
                    JCSJWCF.ShangbaoKucun_CK(fks);

                    ShowMsg("完成", false);
                }
                catch (Exception ex)
                {
                    Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                    ShowMsg(ex.Message, true);
                }
            }, false).Start();
        }
    }
}
