using CKGL.Properties;
using DB_CK;
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
    public partial class Form_Tiaomaxinxi : Form
    {
        /// <summary>
        /// 基础数据WCF服务
        /// </summary>
        private JCSJData.DataServiceClient _jdc;

        public Form_Tiaomaxinxi()
        {
            InitializeComponent();
            _jdc = null;
        }

        /// <summary>
        /// 下载最新条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xzzxtm_Click(object sender, EventArgs e)
        {
            //先登陆基础数据中心
            try
            {
                loginJCSJ();

                JCSJData.TTiaoma[] jtms = _jdc.GetTiaomasByUpdTime();
                saveToLocal(jtms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 下载指定条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xzzdtm_Click(object sender, EventArgs e)
        {
            try
            {
                loginJCSJ();
                Dlg_Tiaomahao dt = new Dlg_Tiaomahao();
                if (dt.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string[] tmhs = dt.txb_tmhs.Text.Trim().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    JCSJData.TTiaoma[] jtms = _jdc.GetTiaomasByTiaomahaos(tmhs);
                    saveToLocal(jtms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 把取得的条码信息保存到本地
        /// </summary>
        /// <param name="jtms"></param>
        private void saveToLocal(JCSJData.TTiaoma[] jtms)
        {
            List<TTiaoma> tms = new List<TTiaoma>();
            foreach (JCSJData.TTiaoma jtm in jtms)
            {
                TTiaoma tm = new TTiaoma
                {
                    id = jtm.id,
                    tiaoma = jtm.tiaoma,
                    kuanhao = jtm.TKuanhao.kuanhao,
                    gyskuanhao = jtm.gyskuanhao,
                    leixing = jtm.TKuanhao.leixing,
                    pinming = jtm.TKuanhao.pinming,
                    yanse = jtm.yanse,
                    chima = jtm.chima,
                    jinjia = jtm.jinjia,
                    shoujia = jtm.shoujia
                };
                tms.Add(tm);
            }

            //找出已经在本地存在的条码
            DBContext db = new DBContext();
            TTiaoma[] otms = db.GetTiaomasByIds(tms.Select(r => r.id).ToArray());
            int[] oids = otms.Select(r => r.id).ToArray();
            //需要更新的条码和需要新插入的条码
            TTiaoma[] uts = tms.Where(r => oids.Contains(r.id)).ToArray();
            uts.ToList().ForEach(t => t.xiugaishijian = DateTime.Now);
            TTiaoma[] nts = tms.Where(r => !oids.Contains(r.id)).ToArray();
            nts.ToList().ForEach(t => { t.charushijian = DateTime.Now; t.xiugaishijian = DateTime.Now; });
            db.UpdateTiaomas(uts);
            db.InsertTiaomas(nts);
        }

        /// <summary>
        /// 登陆数据中心
        /// </summary>
        private void loginJCSJ()
        {
            if (_jdc == null)
            {
                _jdc = new JCSJData.DataServiceClient();
                _jdc.CKZHLogin(Settings.Default.CKID, Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));
            }
            else
            {
                if (_jdc.State != System.ServiceModel.CommunicationState.Opened)
                {
                    _jdc = new JCSJData.DataServiceClient();
                    _jdc.CKZHLogin(Settings.Default.CKID, Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));
                }
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Tiaomaxinxi_Load(object sender, EventArgs e)
        {
            //类型下拉框
            Tool.CommonFunc.InitCombbox(cmb_lx, typeof(Tool.JCSJ.DBCONSTS.KUANHAO_LX));
            DataTable dt = (DataTable)cmb_lx.DataSource;
            dt.Rows.InsertAt(dt.NewRow(), 0);
            cmb_lx.SelectedIndex = 0;

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sch_Click(object sender, EventArgs e)
        {
            string tm = txb_tm.Text.Trim();
            string kh = txb_kh.Text.Trim();
            string lx = cmb_lx.SelectedValue.ToString();

            DBContext db = new DBContext();
            TTiaoma[] tms = db.GetTiaomasByCond(tm, kh, lx);

            grid_tm.Rows.Clear();
            foreach (TTiaoma t in tms)
            {
                grid_tm.Rows.Add(new object[] 
                {
                    t.id,
                    t.tiaoma,
                    t.kuanhao,
                    t.gyskuanhao,
                    ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)t.leixing).ToString(),
                    t.pinming,
                    t.yanse,
                    t.chima,
                    t.shoujia,
                    t.xiugaishijian
                });
            }
        }
    }
}
