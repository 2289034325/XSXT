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
    public partial class Form_KucunXiuzheng : MyForm
    {
        public Form_KucunXiuzheng()
        {
            InitializeComponent();
            base.InitializeComponent();
        }

        /// <summary>
        /// 处理扫描枪事件
        /// </summary>
        /// <param name="tm"></param>
        public override void OnScan(string tm)
        {

        }

       
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KucunGuanli_Load(object sender, EventArgs e)
        {

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
    }
}
