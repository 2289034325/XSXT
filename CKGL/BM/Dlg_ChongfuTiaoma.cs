using CKGL.JCSJData;
using CKGL.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;
using Tool.JCSJ;

namespace CKGL.BM
{
    public partial class Dlg_ChongfuTiaoma : Form
    {
        private TKuanhao _xkh;
        private TTiaomaExtend _xtm;
        private TTiaomaExtend _jtm;

        public Dlg_ChongfuTiaoma(TTiaomaExtend jtm, TTiaomaExtend xtm,TKuanhao xkh)
        {
            InitializeComponent();

            _jtm = jtm;
            _xtm = xtm;
            _xkh = xkh;
        }
        private void Dlg_ChongfuTiaoma_Load(object sender, EventArgs e)
        {
            col_gys.DataSource = RuntimeInfo.Gyses;
            col_gys.ValueMember = "id";
            col_gys.DisplayMember = "mingcheng";

            //旧款
            addRow(_jtm);
            addRow(_xtm);
        }

        private void addRow(TTiaomaExtend t)
        {
            string kuanhao  = t.tiaoma.TKuanhao == null?_xkh.kuanhao:t.tiaoma.TKuanhao.kuanhao;
            string lx = t.tiaoma.TKuanhao == null ? ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)_xkh.leixing).ToString() :
                ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)t.tiaoma.TKuanhao.leixing).ToString();
            string pm = t.tiaoma.TKuanhao == null ? _xkh.pinming : t.tiaoma.TKuanhao.pinming;
            grid_kh.Rows.Add(
                t.xj.ToString(),
                t.tiaoma.tiaoma,
                kuanhao,
                lx,
                pm,
                t.tiaoma.gysid,
                t.tiaoma.gyskuanhao,
                t.tiaoma.yanse,
                t.tiaoma.chima,
                t.tiaoma.jinjia,
                t.tiaoma.shoujia,
                t.tiaoma.charushijian,
                t.tiaoma.xiugaishijian);
        }


        /// <summary>
        /// 覆盖旧条码信息（单价，吊牌价等信息）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_jtmcmm_Click(object sender, EventArgs e)
        {
            //string tm = txb_jtm.Text.Trim();
            //if (string.IsNullOrEmpty(tm))
            //{
            //    MessageBox.Show("请输入要修改的条码号");
            //    return;
            //}

            new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
            {
                try
                {
                    TTiaoma t = new TTiaoma
                    {
                        id = _jtm.tiaoma.id,
                        yanse = _xtm.tiaoma.yanse,
                        chima = _xtm.tiaoma.chima,
                        jinjia = _xtm.tiaoma.jinjia,
                        shoujia = _xtm.tiaoma.shoujia,
                        gysid = _xtm.tiaoma.gysid,
                        gyskuanhao = _xtm.tiaoma.gyskuanhao,
                        xiugaishijian = DateTime.Now
                    };
                    JCSJWCF.FugaiTiaoma(t);
                    ShowMsg("覆盖成功", false);
                    this.DialogResult = System.Windows.Forms.DialogResult.Retry;
                }
                catch (Exception ex)
                {
                    Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                    ShowMsg(ex.Message, true);
                }

            }, false).Start();

        }
        private void btn_xtmcmm_Click(object sender, EventArgs e)
        {
            string tm = txb_xtm.Text.Trim();
            if (string.IsNullOrEmpty(tm))
            {
                MessageBox.Show("请输入要修改的条码号");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void btn_syjtm_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }
    }
}
