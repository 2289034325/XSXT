﻿using DB_FD;
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

namespace FDXS
{
    public partial class Form_KucunGuanli : MyForm
    {
        public Form_KucunGuanli()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 处理扫描枪事件
        /// </summary>
        /// <param name="tm"></param>
        public override void OnScan(string tm)
        {
            //如果是盘点页
            if (tb_gl.SelectedTab.Equals(tbp_pd))
            {
                //检查条码
                DBContext db = IDB.GetDB();
                TTiaoma t = db.GetTiaomaByTmh(tm);
                if (t == null)
                {
                    MessageBox.Show("该条码不存在，请先更新条码信息");
                }
                else
                {
                    //检查是否已经在盘点表中存在
                    TPandian pd = db.GetPandianByTmId(t.id);
                    if (pd == null)
                    {
                        //插入盘点表
                        pd = new TPandian
                        {
                            TTiaoma = t,
                            pdshuliang = 1,
                            kcshuliang = 0,
                            charushijian = DateTime.Now
                        };

                        db.InsertPandian(pd);
                        addPandian(pd);
                    }
                    else
                    {
                        //已有的盘点记录数量加1
                        db.UpdatePandian(pd.id,true);
                        pandianShuliang(pd.id,true);
                    }
                }
            }
        }
        
        /// <summary>
        /// 在grid中增加一行盘点记录
        /// </summary>
        /// <param name="pd"></param>
        private void addPandian(TPandian pd)
        {
            grid_pd.Rows.Insert(0,new object[] 
            {
                pd.id,
                pd.TTiaoma.id,
                pd.TTiaoma.tiaoma,
                pd.TTiaoma.kuanhao,
                pd.TTiaoma.pinming,
                pd.TTiaoma.yanse,
                pd.TTiaoma.chima,
                pd.pdshuliang,
                pd.kcshuliang,
                pd.charushijian
            });

            grid_pd.ClearSelection();
            grid_pd.Rows[0].Selected = true;
            grid_pd.FirstDisplayedScrollingRowIndex = 0;
        }

        /// <summary>
        /// 将表格中的盘点数量加减1
        /// </summary>
        /// <param name="pdid"></param>
        /// <param name="jiajian"></param>
        private void pandianShuliang(int pdid, bool jiajian)
        {
            //找到对应行
            foreach (DataGridViewRow dr in grid_pd.Rows)
            {
                if (pdid.Equals(dr.Cells[col_pd_id.Name].Value))
                {
                    if (jiajian)
                    {
                        dr.Cells[col_pd_pdsl.Name].Value = (short)((short)dr.Cells[col_pd_pdsl.Name].Value + 1);
                    }
                    else
                    {
                        if ((short)dr.Cells[col_pd_pdsl.Name].Value > 0)
                        {
                            dr.Cells[col_pd_pdsl.Name].Value = (short)((short)dr.Cells[col_pd_pdsl.Name].Value - 1);
                        }
                    }
                    grid_pd.ClearSelection();
                    dr.Selected = true;
                    grid_pd.FirstDisplayedScrollingRowIndex = dr.Index;
                }
            }
        }

        /// <summary>
        /// 核对库存和盘点数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_pd_hd_Click(object sender, EventArgs e)
        {
            //查询出当前库存
            DBContext db = IDB.GetDB();
            Dictionary<TTiaoma, short> kc = db.GetKucunView("", "", "");

            //并入grid
            bool exist = false;
            foreach (KeyValuePair<TTiaoma, short> p in kc)
            {
                exist = false;
                foreach (DataGridViewRow dr in grid_pd.Rows)
                {
                    if (p.Key.id.Equals(dr.Cells[col_pd_tmid.Name].Value))
                    {
                        exist = true;
                        dr.Cells[col_pd_kcsl.Name].Value = p.Value;
                        break;
                    }
                }
                //没有盘点到的，就直接插入一行
                if (!exist)
                {
                    addPandian(new TPandian 
                    {
                        TTiaoma = p.Key,
                        pdshuliang = 0,
                        kcshuliang = p.Value,
                        charushijian = DateTime.Now
                    });
                } 
            }

            //盘点数少的，打红色，多的打黄色，正好一样的绿色
            grid_pd.ClearSelection();
            foreach (DataGridViewRow dr in grid_pd.Rows)
            {
                short pdsl = (short)dr.Cells[col_pd_pdsl.Name].Value;
                short kcsl = (short)dr.Cells[col_pd_kcsl.Name].Value;
                if (pdsl == kcsl)
                {
                    dr.DefaultCellStyle.BackColor = Color.SpringGreen;
                }
                else if (pdsl < kcsl)
                {
                    dr.DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    dr.DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KucunGuanli_Load(object sender, EventArgs e)
        {
            //加载盘点记录
            DBContext db = IDB.GetDB();
            TPandian[] ps = db.GetPandians();

            foreach (TPandian p in ps)
            {
                addPandian(p);
            }
        }

        /// <summary>
        /// 加减盘点数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_pd_KeyDown(object sender, KeyEventArgs e)
        {
            if (grid_pd.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow dr = grid_pd.SelectedRows[0];
            int pdid = (int)dr.Cells[col_pd_id.Name].Value;
            if (pdid == 0)
            {
                //核对后，可能该条码没有盘点到，grid中显示的是库存，因而盘点ID为0
                return;
            }

            DBContext db = IDB.GetDB();
            if (e.KeyCode == Keys.Add)
            {
                //已有的盘点记录数量加1
                db.UpdatePandian(pdid, true);
                pandianShuliang(pdid, true);
 
            }
            else if (e.KeyCode == Keys.Subtract)
            {
                if ((short)dr.Cells[col_pd_pdsl.Name].Value > 0)
                {
                    //已有的盘点记录数量减1
                    db.UpdatePandian(pdid, false);
                    pandianShuliang(pdid, false);
                }
            }
        }

        /// <summary>
        /// 清空盘点表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_pd_qk_Click(object sender, EventArgs e)
        {
            DBContext db = IDB.GetDB();
            db.DeletePandianAll();

            grid_pd.Rows.Clear();
        }

        /// <summary>
        /// 增加一个库存修正记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xz_zj_Click(object sender, EventArgs e)
        {
            Dlg_KucunXZ dx = new Dlg_KucunXZ();
            if (dx.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                addXiuzheng(dx.XZ);
            }
        }

        /// <summary>
        /// 在修正grid中增加一行
        /// </summary>
        /// <param name="tKucunXZ"></param>
        private void addXiuzheng(TKucunXZ x)
        {
            grid_xz.Rows.Insert(0,new object[] 
            {
                x.id,
                x.tiaomaid,
                x.TTiaoma.tiaoma,
                x.TTiaoma.kuanhao,
                x.TTiaoma.pinming,
                x.TTiaoma.yanse,
                x.TTiaoma.chima,
                x.shuliang,
                x.TUser.yonghuming,
                x.charushijian,
                x.xiugaishijian
            });
        }

        /// <summary>
        /// 查询出修正信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xz_cx_Click(object sender, EventArgs e)
        {
            DBContext db = IDB.GetDB();
            TKucunXZ[] xzs = db.GetKucunXZs();

            grid_xz.Rows.Clear();
            foreach (TKucunXZ xz in xzs)
            {
                addXiuzheng(xz);
            }
        }

        /// <summary>
        /// 检查修正数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_xz_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //不在编辑状态不用检查
            if (!grid_xz.IsCurrentCellInEditMode)
            {
                return;
            }

            DataGridViewRow dr = grid_xz.Rows[0];
            int id = (int)dr.Cells[col_xz_id.Name].Value;
            int tmid = (int)dr.Cells[col_xz_tmid.Name].Value;

            //数量必须是数字
            short sl;
            if (!short.TryParse(e.FormattedValue.ToString(), out sl))
            {
                e.Cancel = true;
                MessageBox.Show("数量必须是数字");
                return;
            }

            //检查该记录是否允许被修改
            DBContext db = IDB.GetDB();
            TKucunXZ xz = db.GetKucunXZById(id);
            //1天前的记录不允许修改
            if ((DateTime.Now - xz.charushijian).TotalDays > 1)
            {
                e.Cancel = true;
                MessageBox.Show("1天前的记录不允许修改");
                return;
            }            

            //检查是否会导致库存数为负
            VKucun kc = db.GetKucunByTiaomaId(tmid);
            //库存数量-该修正记录的原来的数量，得到除该修正记录外的库存数量X
            //用X加上此次修改的修正数量得到修改之后的库存数量
            if (kc.shuliang - xz.shuliang + sl < 0)
            {
                e.Cancel = true;
                MessageBox.Show("修改后会导致库存数量为负数");
                return;
            }
        }

        /// <summary>
        /// 数据修改后保存到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_xz_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex != col_xz_sl.Index)
            {
                return;
            }

            if (grid_xz.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow dr = grid_xz.Rows[0];
            int id = (int)dr.Cells[col_xz_id.Name].Value;
            short sl = short.Parse(dr.Cells[col_xz_sl.Name].Value.ToString());

            DBContext db = IDB.GetDB();
            db.UpdateKucunXZ(new TKucunXZ 
            {
                id = id,
                shuliang = sl,
                xiugaishijian = DateTime.Now
            });
            
        }

        /// <summary>
        /// 删除时，检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_xz_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = (int)e.Row.Cells[col_xz_id.Name].Value;
            int tmid = (int)e.Row.Cells[col_xz_tmid.Name].Value;
            DBContext db = IDB.GetDB();
            TKucunXZ x = db.GetKucunXZById(id);
            //1天前的记录不允许删除
            if ((DateTime.Now - x.charushijian).TotalDays > 1)
            {
                e.Cancel = true;
                MessageBox.Show("1天前的记录不允许删除");
                return;
            }       

            //删除后是否会导致库存数量为负
            VKucun k = db.GetKucunByTiaomaId(tmid);
            if (k.shuliang - x.shuliang < 0)
            {
                e.Cancel = true;
                MessageBox.Show("删除该记录会导致库存数量为负数");
                return;
            }
        }

        /// <summary>
        /// 删除后，去数据库删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_xz_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            int id = (int)e.Row.Cells[col_xz_id.Index].Value;
            DBContext db = IDB.GetDB();
            db.DeleteKucunXZ(id);
        }

        /// <summary>
        /// 删除一个盘点记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_pd_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = (int)e.Row.Cells[col_pd_id.Name].Value;
            if(id == 0)
            {
                e.Cancel = true;
                return;
            }
        }

        private void grid_pd_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            int id = (int)e.Row.Cells[col_pd_id.Index].Value;
            DBContext db = IDB.GetDB();
            db.DeletePandianById(id);
        }
    }
}
