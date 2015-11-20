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
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace FDXS
{
    public partial class Form_KucunPandian : MyForm
    {
        SpeechSynthesizer _synth;
        public Form_KucunPandian()
        {
            InitializeComponent();
            base.InitializeComponent();

            _synth = new SpeechSynthesizer();
        }

        /// <summary>
        /// 处理扫描枪事件
        /// </summary>
        /// <param name="tm"></param>
        public override void OnScan(string tm)
        {
            addTiaoma(tm);
        }

        private void addTiaoma(string tm)
        {
            //检查条码
            DBContext db = IDB.GetDB();
            TTiaoma t = db.GetTiaomaByTmh(tm);
            if (t == null)
            {
                _synth.Speak("该条码不存在");
                //MessageBox.Show("该条码不存在，请先更新条码信息");
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
                    db.UpdatePandian(pd.id, true);
                    pandianShuliang(pd.id, true);
                }
                PromptBuilder pb = new PromptBuilder();
                //只读后4位
                string vc = "";
                if (tm.Length <= 4)
                {
                    vc = tm;
                }
                else
                {
                    vc = tm.Substring(tm.Length - 4);
                }
                pb.AppendTextWithHint(vc, SayAs.SpellOut);
                _synth.Speak(pb);
            }
        }
        
        /// <summary>
        /// 在grid中增加一行盘点记录
        /// </summary>
        /// <param name="pd"></param>
        private void addPandian(TPandian pd)
        {

            //检查是否已经存在
            foreach (DataGridViewRow dr in grid_pd.Rows)
            {
                int pdid = (int)dr.Cells[col_pd_id.Name].Value;
                int tmid = (int)dr.Cells[col_pd_tmid.Name].Value;
                short pdsl = short.Parse(dr.Cells[col_pd_pdsl.Name].Value.ToString());
                if (pdid == pd.id && pdid != 0)
                {
                    dr.Cells[col_pd_pdsl.Name].Value = (short)(pdsl + 1);
                    return;
                }
                else if (tmid == pd.tiaomaid)
                {
                    dr.Cells[col_pd_id.Name].Value = pd.id;
                    dr.Cells[col_pd_pdsl.Name].Value = (short)(pdsl + 1);
                    return;
                }
            }

            grid_pd.Rows.Insert(0, new object[] 
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
            int recordCount = 0;
            int i1;
            decimal d1, d2;
            DBContext db = IDB.GetDB();
            Dictionary<TTiaoma, short> kc = db.GetKucunView("", "", null, 1, null, null, null, null, null, out recordCount, out i1, out d1, out d2);

            //如果第一次核对时，盘点数量为0，库存数量不为0，进行修正后使得库存数量为0,
            //那么再次核对时，该条码将不会出现在上述列表中，导致不会对当前的grid进行刷新，库存数量依旧停留在上次修正前的数量
            //故再次核对时，应当将上述列表中不存在的条码在grid中库存数量更正为0
            foreach (DataGridViewRow dr in grid_pd.Rows)
            {
                int tmid = (int)dr.Cells[col_pd_tmid.Name].Value;
                if (!kc.Any(k => k.Key.id == tmid))
                {
                    dr.Cells[col_pd_kcsl.Name].Value = (short)0;
                }
            }

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
            List<DataGridViewRow> rRows = new List<DataGridViewRow>();
            List<DataGridViewRow> yRows = new List<DataGridViewRow>();
            grid_pd.ClearSelection();
            foreach (DataGridViewRow dr in grid_pd.Rows)
            {
                short pdsl = (short)dr.Cells[col_pd_pdsl.Name].Value;
                short kcsl = (short)dr.Cells[col_pd_kcsl.Name].Value;
                if (pdsl == kcsl)
                {
                    dr.DefaultCellStyle.BackColor = Color.DarkBlue;
                }
                else if (pdsl < kcsl)
                {
                    dr.DefaultCellStyle.BackColor = Color.Red;
                    rRows.Add(dr);
                }
                else
                {
                    dr.DefaultCellStyle.BackColor = Color.DarkGreen;
                    yRows.Add(dr);
                }
            }

            //将数量不对的往上移动
            rRows = rRows.OrderBy(r => (string)r.Cells[col_pd_tm.Name].Value).ToList();
            yRows = yRows.OrderBy(r => (string)r.Cells[col_pd_tm.Name].Value).ToList();
            foreach (var r in rRows)
            {
                grid_pd.Rows.Remove(r);
                grid_pd.Rows.Insert(0, r);
            }
            foreach (var r in yRows)
            {
                grid_pd.Rows.Remove(r);
                grid_pd.Rows.Insert(0, r);
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
            DataGridViewRow dr;
            if (grid_pd.SelectedRows.Count != 0)
            {
                dr = grid_pd.SelectedRows[0];
            }
            else if (grid_pd.SelectedCells.Count != 0)
            {
                dr = grid_pd.SelectedCells[0].OwningRow;
            }
            else
            {
                return;
            }

            DBContext db = IDB.GetDB();
            int pdid = (int)dr.Cells[col_pd_id.Name].Value;
            string tm = (string)dr.Cells[col_pd_tm.Name].Value;
            if (pdid == 0)
            {
                //核对后，可能该条码没有盘点到，grid中显示的是库存，因而盘点ID为0
                //此时，应当用条码号向盘点表中插入一行，并且得到发番的盘点ID，放入该行
                if (e.KeyCode == Keys.Add)
                {
                    addTiaoma(tm);
                }
                return;
            }

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

        /// <summary>
        /// 输入无法扫描的条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_wfsm_Click(object sender, EventArgs e)
        {
            string tm = txb_tm.Text.Trim();
            if (string.IsNullOrEmpty(tm))
            {
                MessageBox.Show("请输入条码");
                return;
            }

            addTiaoma(tm);
        }

        /// <summary>
        /// 按照核对差额修正库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_xzkc_Click(object sender, EventArgs e)
        {
            if(grid_pd.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选中需要修正的条码");
                return;
            }

            DataGridViewRow dr = grid_pd.SelectedRows[0];
            int tmid = (int)dr.Cells[col_pd_tmid.Name].Value;

            DBContext db = IDB.GetDB();
            VKucun kc = db.GetKucunByTiaomaId(tmid);
            TPandian pd = db.GetPandianByTmId(tmid);
            short pdsl = pd == null ? (short)0 : pd.pdshuliang;

            short xzsl = (short)(pdsl - kc.shuliang);
            if (xzsl != 0)
            {
                TKucunXZ xz = new TKucunXZ
                {
                    tiaomaid = tmid,
                    shuliang = xzsl,
                    caozuorenid = RuntimeInfo.LoginUser.id,
                    charushijian = DateTime.Now,
                    xiugaishijian = DateTime.Now
                };
                db.InsertKucunXZ(xz);
            }
        }

        /// <summary>
        /// 设置右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_pd_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected)
            {
                if (e.Row.Selected)
                {
                    e.Row.ContextMenuStrip = cmn;
                }
                else
                {
                    e.Row.ContextMenuStrip = null;
                }
            }
        }

        /// <summary>
        /// 计算总数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_pd_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || (e.ColumnIndex != col_pd_pdsl.Index && e.ColumnIndex != col_pd_kcsl.Index))
            {
                return;
            }

            int tpdsl = 0;
            int tkcsl = 0;
            foreach (DataGridViewRow dr in grid_pd.Rows)
            {
                short pdsl = (short)dr.Cells[col_pd_pdsl.Name].Value;
                short kcsl = (short)dr.Cells[col_pd_kcsl.Name].Value;

                tpdsl += pdsl;
                tkcsl += kcsl;
            }

            col_pd_pdsl.HeaderText = "盘点数量(" + tpdsl + ")";
            col_pd_kcsl.HeaderText = "库存数量(" + tkcsl + ")";
        }       
    }
}
