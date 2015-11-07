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
    public partial class Dlg_ChongfuKuanhao : Form
    {
        private TKuanhaoExtend _jk;
        private TKuanhaoExtend _xk;

        public Dlg_ChongfuKuanhao(TKuanhaoExtend jk, TKuanhaoExtend xk)
        {
            InitializeComponent();

            _jk = jk;
            _xk = xk;
        }

        private void Dlg_ChongfuKuanhao_Load(object sender, EventArgs e)
        {
            //旧款
            addRow(_jk);
            addRow(_xk);
        }

        private void addRow(TKuanhaoExtend k)
        {
            grid_kh.Rows.Add(
                k.xj.ToString(),
                k.kuanhao.kuanhao,
                ((Tool.JCSJ.DBCONSTS.KUANHAO_XB)k.kuanhao.xingbie).ToString(),
                ((Tool.JCSJ.DBCONSTS.KUANHAO_LX)k.kuanhao.leixing).ToString(),
                k.kuanhao.pinming,
                k.kuanhao.beizhu,
                k.kuanhao.charushijian,
                k.kuanhao.xiugaishijian);
        }

        /// <summary>
        /// 重命名就款号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_jkhcmm_Click(object sender, EventArgs e)
        {
            string kh = txb_jkh.Text.Trim();
            if (string.IsNullOrEmpty(kh))
            {
                MessageBox.Show("请输入要修改的款号名称");
                return;
            }

            new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg) 
                {
                    try
                    {
                        JCSJWCF.XiugaiKuanhao(_jk.kuanhao.id, kh);
                        ShowMsg("修改成功", false);
                        this.DialogResult = System.Windows.Forms.DialogResult.Retry;
                    }
                    catch (Exception ex)
                    {
                        Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                        ShowMsg(ex.Message, true);
                    }

                }, false).Start();

        }

        /// <summary>
        /// 重命名新款号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xkhcmm_Click(object sender, EventArgs e)
        {
            string kh = txb_xkh.Text.Trim();
            if (string.IsNullOrEmpty(kh))
            {
                MessageBox.Show("请输入要修改的款号名称");
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// 使用旧款号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_syjkh_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

    }
}
