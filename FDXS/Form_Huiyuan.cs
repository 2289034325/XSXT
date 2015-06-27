using DB_FD;
using FDXS.Properties;
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
using Tool.FD;

namespace FDXS
{
    public partial class Form_Huiyuan : MyForm
    {
        public Form_Huiyuan()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询会员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sch_Click(object sender, EventArgs e)
        {
            //查询条件
            string sjh = txb_sjh.Text.Trim();
            DBContext db = IDB.GetDB();
            THuiyuan[] hys = db.GetHuiyuanByCond(sjh);

            grid_hy.Rows.Clear();
            foreach (THuiyuan h in hys)
            {
                grid_hy.Rows.Add(new object[] 
                {
                    h.id,
                    h.shoujihao,
                    h.xingming,
                    (Tool.JCSJ.DBCONSTS.HUIYUAN_XB)h.xingbie,
                    DateTime.Now.Year - h.shengri.Year,
                    h.jifen,
                    h.jfgxshijian
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
            //Tool.CommonFunc.InitCombbox(cmb_leixing, typeof(JCSJData.DBCONSTS.KUANHAO_LX));
            //DataTable dt = (DataTable)cmb_leixing.DataSource;
            //dt.Rows.InsertAt(dt.NewRow(), 0);
            //cmb_leixing.SelectedIndex = 0;
        }

        /// <summary>
        /// 下载会员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_hy_gxxx_Click(object sender, EventArgs e)
        {
            if (grid_hy.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选中一行");
                return;
            }


            Dlg_Progress dp = new Dlg_Progress();
            cmn_hy_gxxx_Click_sync(dp);
            dp.ShowDialog();
        }
        private async void cmn_hy_gxxx_Click_sync(Dlg_Progress dp)
        {
            await Task.Run(() => 
            {
                //取得被选中的会员ID
                int id = (int)grid_hy.SelectedRows[0].Cells[col_id.Name].Value;

                //调用接口
                JCSJData.THuiyuan jh = null;
                try
                {
                    jh = JCSJWCF.GetHuiyuanById(id);
                }
                catch (Exception ex)
                {
                    dp.lbl_msg.Text =  ex.Message;
                    return;
                }

                //更新到本地
                DBContext db = IDB.GetDB();
                THuiyuan fh = db.GetHuiyuanById(id);

                fh.shoujihao = jh.shoujihao;
                fh.xingming = jh.xingming;
                fh.xingbie = jh.xingbie;
                fh.shengri = jh.shengri;
                fh.xxgxshijian = DateTime.Now;

                fh.jifen = jh.jifen;
                fh.jfgxshijian = jh.jfjsshijian;

                db.UpdateHuiyuanAll(fh);

                dp.lbl_msg.Text = "下载成功";
            });

            dp.ControlBox = true;
        }

        /// <summary>
        /// 上传会员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_hy_shangchuan_Click(object sender, EventArgs e)
        {
            if (grid_hy.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选中一行");
                return;
            }

            Dlg_Progress dp = new Dlg_Progress();
            cmn_hy_shangchuan_Click_sync(dp);
            dp.ShowDialog();          
        }
        private async void cmn_hy_shangchuan_Click_sync(Dlg_Progress dp)
        {
            await Task.Run(() => 
            {
                int id = (int)grid_hy.SelectedRows[0].Cells[col_id.Name].Value;
                DBContext db = IDB.GetDB();
                THuiyuan h = db.GetHuiyuanById(id);

                JCSJData.THuiyuan jh = new JCSJData.THuiyuan
                {
                    id = h.id,
                    shengri = h.shengri,
                    shoujihao = h.shoujihao,
                    xingbie = h.xingbie,
                    xingming = h.xingming
                };

                try
                {
                    JCSJWCF.UpdateHuiyuan(jh);
                }
                catch (Exception ex)
                {
                    dp.lbl_msg.Text = ex.Message;
                    return;
                }
                dp.lbl_msg.Text = "上传成功";
            });
            dp.ControlBox = true;
        }

        /// <summary>
        /// 修改会员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_hy_edit_Click(object sender, EventArgs e)
        {
            if (grid_hy.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选中一行");
                return;
            }

            //取得被选中的会员ID
            int id = (int)grid_hy.SelectedRows[0].Cells[col_id.Name].Value;
            Dlg_HuiyuanEdit dh = new Dlg_HuiyuanEdit( id);
            dh.ShowDialog();
        }
    }
}
