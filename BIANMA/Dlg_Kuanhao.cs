using DB_JCSJ;
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

namespace BIANMA
{
    public partial class Dlg_Kuanhao : Form
    {
        public Dlg_Kuanhao()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_Kuanhao_Load(object sender, EventArgs e)
        {
            //初始化下拉框
            Tool.CommonFunc.InitCombbox(cmb_lx, typeof(DBCONSTS.KUANHAO_LX));
            Tool.CommonFunc.InitCombbox(cmb_xb, typeof(DBCONSTS.KUANHAO_XB));
        }  

        /// <summary>
        /// 重新加载供应商信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            TKuanhao[] ks;
            try
            {
                ks = JCSJWCF.GetKuanhaosByUserId(LoginInfo.User.id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            grid_kh.Rows.Clear();
            foreach (TKuanhao k in ks)
            {
                addKuanhao(k);
            }
        }

        /// <summary>
        /// 增加一个款号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            TKuanhao k = getEditInfo();
            TKuanhao nk;

            try
            {
                nk = JCSJWCF.InsertKuanhao(k);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            addKuanhao(nk);
        }

        /// <summary>
        /// 取得用户编辑的信息
        /// </summary>
        /// <returns></returns>
        private TKuanhao getEditInfo()
        {

            string kuanhao = txb_kh.Text.Trim();
            string pinming = txb_pm.Text.Trim();
            string beizhu = txb_bz.Text.Trim();
            byte xingbie = byte.Parse(cmb_xb.SelectedValue.ToString());
            byte leixing = byte.Parse(cmb_lx.SelectedValue.ToString());

            TKuanhao k = new TKuanhao()
            {
                kuanhao = kuanhao,
                pinming = pinming,
                beizhu = beizhu,
                xingbie = xingbie,
                leixing = leixing,
            };

            return k;
        }

        /// <summary>
        /// 增加一个款号后在grid中显示
        /// </summary>
        /// <param name="nk"></param>
        private void addKuanhao(TKuanhao k)
        {
            grid_kh.Rows.Add(new object[] 
                {
                    k.id,
                    k.kuanhao,
                    ((DBCONSTS.KUANHAO_XB)k.xingbie).ToString(),
                    ((DBCONSTS.KUANHAO_LX)k.leixing).ToString(),
                    k.pinming,
                    k.beizhu,
                    k.charushijian,
                    k.xiugaishijian
                });
        }

        /// <summary>
        /// 将grid中某个款号信息更新
        /// </summary>
        /// <param name="k"></param>
        private void editKuanhao(TKuanhao k)
        {
            DataGridViewRow dr = grid_kh.SelectedRows[0];
            dr.SetValues(new object[] 
                {
                    k.id,
                    k.kuanhao,
                    ((DBCONSTS.KUANHAO_XB)k.xingbie).ToString(),
                    ((DBCONSTS.KUANHAO_LX)k.leixing).ToString(),
                    k.pinming,
                    k.beizhu
                });

            dr.Cells[col_xgsj.Name].Value = DateTime.Now;
        }

        /// <summary>
        /// 选中一行，加载编辑信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kh_SelectionChanged(object sender, EventArgs e)
        {
            if (grid_kh.SelectedRows.Count == 0)
            {
                txb_bz.Text = "";
                txb_kh.Text = "";
                txb_pm.Text = "";
                
                return;
            }

            DataGridViewRow dr = grid_kh.SelectedRows[0];

            txb_kh.Text = dr.Cells[col_kh.Name].Value.ToString();
            txb_pm.Text = dr.Cells[col_pm.Name].Value.ToString();
            txb_bz.Text = dr.Cells[col_bz.Name].Value.ToString();

            cmb_xb.SelectedText = dr.Cells[col_xb.Name].Value.ToString();
            cmb_lx.SelectedText = dr.Cells[col_lx.Name].Value.ToString();
        }


        /// <summary>
        /// 修改款号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (grid_kh.SelectedRows.Count == 0)
            {
                return;
            }

            TKuanhao ok = getEditInfo();
            ok.id = (int)grid_kh.SelectedRows[0].Cells[col_id.Name].Value;

            try
            {
                JCSJWCF.EditKuanhao(ok);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            editKuanhao(ok);
        }

        /// <summary>
        /// 删除一个款号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kh_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = int.Parse(e.Row.Cells["col_id"].Value.ToString());

            try
            {
                JCSJWCF.DeleteKuanhao(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }     
    }
}
