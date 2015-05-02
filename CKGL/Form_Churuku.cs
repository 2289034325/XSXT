using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool.DB.CK;

namespace CKGL
{
    public partial class Form_Churuku : Form
    {
        //当前登陆的用户
        private TUser _user;

        public Form_Churuku(TUser user)
        {
            InitializeComponent();
            _user = user;
        }

        /// <summary>
        /// 查询出入库记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_crk_cx_Click(object sender, EventArgs e)
        {
            string sid = txb_id.Text.Trim();
            int iid;
            int? id;
            if (string.IsNullOrEmpty(sid))
            {
                id = null;
            }
            else
            {
                if (!int.TryParse(sid, out iid))
                {
                    MessageBox.Show("id必须是整数");
                    return;
                }
                else
                {
                    id = iid;
                }
            }
            DateTime dstart = dp_start.Value.Date;
            DateTime dend = dp_end.Value.Date;

            DBContext db = new DBContext();
            TChuruku[] cs = db.GetChurukus(id, dstart, dend);

            grid_crk.Rows.Clear();
            grid_crkmx.Rows.Clear();
            foreach (TChuruku c in cs)
            {
                addChuruku(c);
            }
        }

        private void addChuruku(TChuruku c)
        {
            grid_crk.Rows.Insert(0,new object[] 
                {
                    c.id,
                    ((DBCONSTS.CRK_FX)c.fangxiang).ToString(),
                    ((DBCONSTS.CRK_LYQX)c.laiyuanquxiang).ToString(),
                    c.TChurukuMX.Sum(r=>(short?)r.shuliang)??0,
                    c.beizhu,
                    c.TUser.yonghuming,
                    c.charushijian,
                    c.xiugaishijian,
                    c.shangbaoshijian
                });

            grid_crk.Rows[0].Selected = true;
        }

        /// <summary>
        /// 选中一行出入库记录，加载其详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_crk_SelectionChanged(object sender, EventArgs e)
        {
            if (grid_crk.SelectedRows.Count == 0)
            {
                return;
            }

            refreshMx();
        }

        /// <summary>
        /// 刷新出入库明细表格
        /// </summary>
        private void refreshMx()
        {
            int id = (int)grid_crk.SelectedRows[0].Cells[col_crk_id.Name].Value;

            DBContext db = new DBContext();
            TChurukuMX[] mxs = db.GetChurukuMxsByCrkId(id);

            grid_crkmx.Rows.Clear();
            foreach (TChurukuMX mx in mxs)
            {
                addChurukuMx(mx);
            }
        }

        /// <summary>
        /// 增加一个出入库明细
        /// </summary>
        /// <param name="mx"></param>
        private void addChurukuMx(TChurukuMX mx)
        {
            grid_crkmx.Rows.Add(new object[] 
                {
                    mx.id,
                    mx.TTiaoma.tiaoma,
                    mx.TTiaoma.kuanhao,
                    mx.TTiaoma.pinming,
                    mx.TTiaoma.yanse,
                    mx.TTiaoma.chima,
                    mx.shuliang,
                    mx.TTiaoma.shoujia
                });
        }

        /// <summary>
        /// 增加一个入库记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_crk_rk_Click(object sender, EventArgs e)
        {
            TChuruku c = new TChuruku 
            {
                fangxiang = (byte)DBCONSTS.CRK_FX.入,
                laiyuanquxiang = (byte)DBCONSTS.CRK_LYQX.新货,
                beizhu = "",
                caozuorenid = _user.id,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now,
                shangbaoshijian = null
            };

            DBContext db = new DBContext();
            TChuruku nc = db.InsertChuruku(c);

            addChuruku(nc);
        }

        /// <summary>
        /// 增加一个出库记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_crk_ck_Click(object sender, EventArgs e)
        {
            TChuruku c = new TChuruku
            {
                fangxiang = (byte)DBCONSTS.CRK_FX.出,
                laiyuanquxiang = (byte)DBCONSTS.CRK_LYQX.内部,
                beizhu = "",
                caozuorenid = _user.id,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now,
                shangbaoshijian = null
            };

            DBContext db = new DBContext();
            TChuruku nc = db.InsertChuruku(c);

            addChuruku(nc);
        }

        /// <summary>
        /// 从文件导入出入库明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_crk_daoru_Click(object sender, EventArgs e)
        {
            int crkid = (int)grid_crk.SelectedRows[0].Cells[col_crk_id.Name].Value;

            //检查该出入库记录是否已经上报
            if (!checkAllow())
            {
                MessageBox.Show("该记录已经上报到服务器，不能再导入明细数据");
                return;
            }

            DBContext db = new DBContext();
            Dlg_Tiaomahao dt = new Dlg_Tiaomahao();
            if (dt.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] tmhs = dt.txb_tmhs.Text.Trim().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string,short> tmsls = tmhs.ToDictionary(k=>k.Split(new char[]{','})[0],v=>short.Parse(v.Split(new char[]{','})[1]));
                
                TTiaoma[] tms = db.GetTiaomasByTmhs(tmsls.Select(r=>r.Key).ToArray());
                Dictionary<int,short> tss = tms.ToDictionary(k=>k.id,v=>tmsls[v.tiaoma]);
                if (tms.Length != tmhs.Length)
                {
                    MessageBox.Show("有条码信息不存在，请先下载条码信息");
                }
                else
                {
                    List<TChurukuMX> mxs= new List<TChurukuMX>();
                    foreach (KeyValuePair<int, short> p in tss)
                    {
                        TChurukuMX mx = new TChurukuMX 
                        {
                            churukuid = crkid,
                            tiaomaid = p.Key,
                            shuliang = p.Value
                        };

                        mxs.Add(mx);
                    }

                    db.InsertChurukuMxs(mxs.ToArray());
                }

                refreshMx();
            }
        }

        /// <summary>
        /// 删除一个出入库记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_crk_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!checkAllow())
            {
                MessageBox.Show("该记录已经上报到服务器，不允许再删除");
                e.Cancel = true;
            }
            else
            {
                DBContext db = new DBContext();
                int crkid = (int)e.Row.Cells[col_crk_id.Name].Value;
                db.DeleteChuruku(crkid);
            }
        }

        /// <summary>
        /// 删除一个出入库明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_crkmx_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!checkAllow())
            {
                MessageBox.Show("该记录已经上报到服务器，不允许再删除");
                e.Cancel = true;
            }
            else
            {
                int mxid = (int)grid_crkmx.SelectedRows[0].Cells[col_mx_id.Name].Value;
                DBContext db = new DBContext();
                db.DeleteChurukuMx(mxid);
            }
        }

        /// <summary>
        /// 修改出入库信息时的验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_crk_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //不在编辑状态，不用验证
            if (!grid_crk.IsCurrentCellInEditMode)
            {
                return;
            }

            //如果是来源去向列
            if (e.ColumnIndex == col_crk_lyqx.Index)
            {
                string text = e.FormattedValue.ToString();
                DBCONSTS.CRK_LYQX lyfx;
                if (!Enum.TryParse<DBCONSTS.CRK_LYQX>(text, out lyfx))
                {
                    e.Cancel = true;
                    MessageBox.Show("来源去向只能输入[" + Enum.GetNames(typeof(DBCONSTS.CRK_LYQX)).Aggregate((a, b) => { return a + "," + b; }) + "]");
                }
                else
                {
                    //来源只能是新货和内部，去向只能是退货，丢弃，其他
                    string sfx = (string)grid_crk.SelectedRows[0].Cells[col_crk_fx.Name].Value;
                    DBCONSTS.CRK_FX fx = (DBCONSTS.CRK_FX)Enum.Parse(typeof(DBCONSTS.CRK_FX), sfx);
                    if (fx == DBCONSTS.CRK_FX.入)
                    {
                        if (!(lyfx == DBCONSTS.CRK_LYQX.新货 || lyfx == DBCONSTS.CRK_LYQX.内部))
                        {
                            e.Cancel = true;
                            MessageBox.Show("入库的来源只能是[" + DBCONSTS.CRK_LYQX.新货.ToString() + 
                                "]和[" + DBCONSTS.CRK_LYQX.内部.ToString() + "]");
                        }
                    }
                    else
                    {
                        if (!(lyfx == DBCONSTS.CRK_LYQX.退货 || lyfx == DBCONSTS.CRK_LYQX.内部 ||
                            lyfx == DBCONSTS.CRK_LYQX.其他 || lyfx == DBCONSTS.CRK_LYQX.丢弃))
                        {
                            e.Cancel = true;
                            MessageBox.Show("出库的去向只能是[" + DBCONSTS.CRK_LYQX.退货.ToString() +
                                "]或[" + DBCONSTS.CRK_LYQX.内部.ToString() + "]" +
                                "或[" + DBCONSTS.CRK_LYQX.丢弃.ToString() + "]");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 检查该行是否允许编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_crk_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow dr = grid_crk.Rows[e.RowIndex];
            if (dr.Cells[col_crk_sbsj.Name].Value != null)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 修改出入库的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_crk_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int crkid = (int)grid_crk.SelectedRows[0].Cells[col_crk_id.Name].Value;
            if (!checkAllow())
            {
                MessageBox.Show("该记录已经上报到服务器，不允许再修改");
                return;
            }
            else
            {
                DBContext db = new DBContext();
                byte lyqx = (byte)(DBCONSTS.CRK_LYQX)Enum.Parse(typeof(DBCONSTS.CRK_LYQX), (string)grid_crk.SelectedRows[0].Cells[col_crk_lyqx.Name].Value);
                string bz = (string)grid_crk.SelectedRows[0].Cells[col_crk_bz.Name].Value ?? "";
                TChuruku nc = new TChuruku 
                {
                    id=crkid,
                    laiyuanquxiang = lyqx,
                    beizhu = bz,
                    xiugaishijian = DateTime.Now               
                };
                db.UpdateChuruku(nc);
            }
        }

        /// <summary>
        /// 检查该行出入库明细是否允许修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_crkmx_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow dr = grid_crk.Rows[e.RowIndex];
            if (dr.Cells[col_crk_sbsj.Name].Value != null)
            {
                e.Cancel = true;
            }

        }

        /// <summary>
        /// 检查输入是否合法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_crkmx_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //不在编辑状态不用验证
            if (!grid_crkmx.IsCurrentCellInEditMode)
            {
                return;
            }

            short sl;
            if (!short.TryParse(e.FormattedValue.ToString(), out sl))
            {
                MessageBox.Show("只允许输入数字");
                e.Cancel = true;
                return;
            }
            else
            {
                if (sl <= 0)
                {
                    MessageBox.Show("只允许输入大于0的数字");
                    e.Cancel = true;
                    return;
                }
            }
        }

        /// <summary>
        /// 修改明细的数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_crkmx_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (!checkAllow())
            {
                MessageBox.Show("该记录已经上报到服务器，不允许再修改");
                return;
            }
            else
            {
                int mxid = (int)grid_crkmx.SelectedRows[0].Cells[col_mx_id.Name].Value; 
                short sl = short.Parse(grid_crkmx.SelectedRows[0].Cells[col_mx_sl.Name].Value.ToString());
                DBContext db = new DBContext();
                TChurukuMX mx = new TChurukuMX 
                {
                    id = mxid,
                    shuliang = sl                    
                };
                db.UpdateChurukuMx(mx);
            }
        }

        /// <summary>
        /// 检查是否允许修改或者删除
        /// </summary>
        /// <returns></returns>
        private bool checkAllow()
        {
            int crkid = (int)grid_crk.SelectedRows[0].Cells[col_crk_id.Name].Value;            
            DBContext db = new DBContext();
            TChuruku c = db.GetChurukuById(crkid);
            if (c.shangbaoshijian != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 设置菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_crk_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {

            if (e.Row.Selected)
            {
                e.Row.ContextMenuStrip = cmn_crk;
            }
            else
            {
                e.Row.ContextMenuStrip = null;
            }
        }
    }
}
