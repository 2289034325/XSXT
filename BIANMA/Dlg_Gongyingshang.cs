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

namespace BIANMA
{
    public partial class Dlg_Gongyingshang : Form
    {
        private JCSJData.DataServiceClient _dc;
        private TUser _u;
        public Dlg_Gongyingshang(JCSJData.DataServiceClient dc,TUser u)
        {
            InitializeComponent();
            _dc = dc;
            _u = u;
        }       

        /// <summary>
        /// 重新加载供应商信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            if (_u == null)
            {
                MessageBox.Show("未登陆");
                return;
            }

            TGongyingshang[] gs = _dc.GetGongyingshangsByUserId(_u.id);

            grid_gys.Rows.Clear();
            for (int i = 0; i < gs.Length;i++ )
            {
                grid_gys.Rows.Add(new object[] 
                {
                    gs[i].id,
                    gs[i].mingcheng,
                    gs[i].lianxiren,
                    gs[i].dianhua,
                    gs[i].dizhi,
                    gs[i].beizhu,
                    gs[i].charushijian,
                    gs[i].xiugaishijian
                });
            }
        }

        /// <summary>
        /// 增加一个供应商
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                TGongyingshang g = getEditInfo();

                TGongyingshang ng = _dc.InsertGongyingshang(g);

                addGongyingshang(ng);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addGongyingshang(TGongyingshang ng)
        {
            grid_gys.Rows.Add(new object[]
            {
                ng.id,
                ng.mingcheng,
                ng.lianxiren,
                ng.dianhua,
                ng.dizhi,
                ng.beizhu,
                ng.charushijian,
                ng.xiugaishijian
            });
        }

        private TGongyingshang getEditInfo()
        {
            string mc = txb_mc.Text.Trim();
            string lxr = txb_lxr.Text.Trim();
            string dh = txb_dh.Text.Trim();
            string dz = txb_dz.Text.Trim();
            string bz = txb_bz.Text.Trim();

            TGongyingshang g = new TGongyingshang() 
            {
                mingcheng = mc,
                lianxiren = lxr,
                dianhua = dh,
                dizhi = dz,
                beizhu = bz
            };

            return g;
        }


        /// <summary>
        /// 修改供应商信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid_gys.SelectedRows.Count == 0)
                {
                    return;
                }

                TGongyingshang og = getEditInfo();
                og.id = (int)grid_gys.SelectedRows[0].Cells["col_id"].Value;

                _dc.EditGongyingshang(og);

                editGongyingshang(og);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 修改grid中的信息
        /// </summary>
        /// <param name="og"></param>
        private void editGongyingshang(TGongyingshang g)
        {
            DataGridViewRow dr = grid_gys.SelectedRows[0];
            dr.SetValues(new object[] 
                {
                    g.id,
                    g.mingcheng,
                    g.lianxiren,
                    g.dianhua,
                    g.dizhi,
                    g.beizhu                    
                });

            dr.Cells["col_xgsj"].Value = DateTime.Now;
        }

        /// <summary>
        /// 删除一个供应商
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_gys_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = int.Parse(e.Row.Cells["col_id"].Value.ToString());

            _dc.DeleteGongyingshang(id);
        }

        /// <summary>
        /// 选中一行，加载其编辑信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_gys_SelectionChanged(object sender, EventArgs e)
        {
            if (grid_gys.SelectedRows.Count == 0)
            {
                txb_bz.Text = "";
                txb_mc.Text = "";
                txb_dh.Text = "";
                txb_dz.Text = "";
                txb_lxr.Text = "";

                return;
            }

            DataGridViewRow dr = grid_gys.SelectedRows[0];

            txb_mc.Text = dr.Cells["col_mc"].Value.ToString();
            txb_lxr.Text = dr.Cells["col_lxr"].Value.ToString();
            txb_dh.Text = dr.Cells["col_dh"].Value.ToString();
            txb_dz.Text = dr.Cells["col_dz"].Value.ToString();
            txb_bz.Text = dr.Cells["col_bz"].Value.ToString();
        }       
    }
}
