using DB_FD;
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
    public partial class Form_Jinchuhuo : MyForm
    {
        //当前登陆的用户
        private TUser _user;
        /// <summary>
        /// 基础数据WCF服务
        /// </summary>
        private JCSJData.DataServiceClient _jdc;

        public Form_Jinchuhuo(TUser user)
        {
            InitializeComponent();
            _user = user;
            _jdc = null;
        }

        /// <summary>
        /// 查询进出货记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cx_Click(object sender, EventArgs e)
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
            TJinchuhuo[] cs = db.GetJinchuhuos(id, dstart, dend);

            grid_jch.Rows.Clear();
            grid_jcmx.Rows.Clear();
            foreach (TJinchuhuo c in cs)
            {
                addJinchuhuo(c);
            }
        }

        private void addJinchuhuo(TJinchuhuo c)
        {
            grid_jch.Rows.Insert(0,new object[] 
                {
                    c.id,
                    ((Tool.FD.DBCONSTS.JCH_FX)c.fangxiang).ToString(),
                    ((Tool.FD.DBCONSTS.JCH_LYQX)c.laiyuanquxiang).ToString(),
                    c.TJinchuMX.Sum(r=>(short?)r.shuliang)??0,
                    c.beizhu,
                    c.TUser.yonghuming,
                    c.charushijian,
                    c.xiugaishijian,
                    c.shangbaoshijian
                });

            grid_jch.Rows[0].Selected = true;
        }

        /// <summary>
        /// 选中一行进出货记录，加载其详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_crk_SelectionChanged(object sender, EventArgs e)
        {
            if (grid_jch.SelectedRows.Count == 0)
            {
                return;
            }

            refreshMx();
        }

        /// <summary>
        /// 刷新进出明细表格
        /// </summary>
        private void refreshMx()
        {
            int id = (int)grid_jch.SelectedRows[0].Cells[col_jc_id.Name].Value;

            DBContext db = new DBContext();
            TJinchuMX[] mxs = db.GetJinchuhuoMxsByJchId(id);

            grid_jcmx.Rows.Clear();
            foreach (TJinchuMX mx in mxs)
            {
                addJinchuMx(mx);
            }
        }

        /// <summary>
        /// 增加一个进出明细
        /// </summary>
        /// <param name="mx"></param>
        private void addJinchuMx(TJinchuMX mx)
        {
            grid_jcmx.Rows.Add(new object[] 
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
        /// 增加一个进货记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_jh_Click(object sender, EventArgs e)
        {
            TJinchuhuo c = new TJinchuhuo 
            {
                fangxiang = (byte)DBCONSTS.JCH_FX.进,
                laiyuanquxiang = (byte)DBCONSTS.JCH_LYQX.内部,
                beizhu = "",
                caozuorenid = _user.id,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now,
                shangbaoshijian = null
            };

            DBContext db = new DBContext();
            TJinchuhuo nc = db.InsertJinchuhuo(c);

            addJinchuhuo(nc);
        }

        /// <summary>
        /// 增加一个出货记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ch_Click(object sender, EventArgs e)
        {
            TJinchuhuo c = new TJinchuhuo
            {
                fangxiang = (byte)DBCONSTS.JCH_FX.出,
                laiyuanquxiang = (byte)DBCONSTS.JCH_LYQX.内部,
                beizhu = "",
                caozuorenid = _user.id,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now,
                shangbaoshijian = null
            };

            DBContext db = new DBContext();
            TJinchuhuo nc = db.InsertJinchuhuo(c);

            addJinchuhuo(nc);
        }

        /// <summary>
        /// 从文件导入进出货明细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_crk_daoru_Click(object sender, EventArgs e)
        {
            int crkid = (int)grid_jch.SelectedRows[0].Cells[col_jc_id.Name].Value;

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
                    List<TJinchuMX> mxs = new List<TJinchuMX>();
                    foreach (KeyValuePair<int, short> p in tss)
                    {
                        TJinchuMX mx = new TJinchuMX 
                        {
                            jinchuid = crkid,
                            tiaomaid = p.Key,
                            shuliang = p.Value
                        };

                        mxs.Add(mx);
                    }

                    db.InsertJinchuMxs(mxs.ToArray());
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
                int crkid = (int)e.Row.Cells[col_jc_id.Name].Value;
                db.DeleteJinchuhuo(crkid);
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
                int mxid = (int)grid_jcmx.SelectedRows[0].Cells[col_mx_id.Name].Value;
                DBContext db = new DBContext();
                db.DeleteJinchuMx(mxid);
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
            if (!grid_jch.IsCurrentCellInEditMode)
            {
                return;
            }

            //如果是来源去向列
            if (e.ColumnIndex == col_jc_lyqx.Index)
            {
                string text = e.FormattedValue.ToString();
                Tool.FD.DBCONSTS.JCH_LYQX lyfx;
                if (!Enum.TryParse<Tool.FD.DBCONSTS.JCH_LYQX>(text, out lyfx))
                {
                    e.Cancel = true;
                    MessageBox.Show("来源去向只能输入[" + Enum.GetNames(typeof(Tool.FD.DBCONSTS.JCH_LYQX)).Aggregate((a, b) => { return a + "," + b; }) + "]");
                }
                else
                {
                    //来源只能是新货和内部，去向只能是退货，丢弃，其他
                    string sfx = (string)grid_jch.SelectedRows[0].Cells[col_jc_fx.Name].Value;
                    Tool.FD.DBCONSTS.JCH_FX fx = (Tool.FD.DBCONSTS.JCH_FX)Enum.Parse(typeof(Tool.FD.DBCONSTS.JCH_FX), sfx);
                    if (fx == Tool.FD.DBCONSTS.JCH_FX.进)
                    {
                        if (lyfx != Tool.FD.DBCONSTS.JCH_LYQX.内部)
                        {
                            e.Cancel = true;
                            MessageBox.Show("进货的来源只能是[" + DBCONSTS.JCH_LYQX.内部.ToString() + "]");
                        }
                    }
                    else
                    {
                        if (!(lyfx == DBCONSTS.JCH_LYQX.退货 || lyfx == DBCONSTS.JCH_LYQX.内部 ||
                            lyfx == DBCONSTS.JCH_LYQX.其他 || lyfx == DBCONSTS.JCH_LYQX.丢弃))
                        {
                            e.Cancel = true;
                            MessageBox.Show("出货的去向只能是[" + DBCONSTS.JCH_LYQX.退货.ToString() +
                                "]或[" + DBCONSTS.JCH_LYQX.内部.ToString() + "]" +
                                "或[" + DBCONSTS.JCH_LYQX.丢弃.ToString() + "]");
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
            DataGridViewRow dr = grid_jch.Rows[e.RowIndex];
            if (dr.Cells[col_jc_sbsj.Name].Value != null)
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

            int crkid = (int)grid_jch.SelectedRows[0].Cells[col_jc_id.Name].Value;
            if (!checkAllow())
            {
                MessageBox.Show("该记录已经上报到服务器，不允许再修改");
                return;
            }
            else
            {
                DBContext db = new DBContext();
                byte lyqx = (byte)(Tool.FD.DBCONSTS.JCH_LYQX)Enum.Parse(typeof(Tool.FD.DBCONSTS.JCH_LYQX), (string)grid_jch.SelectedRows[0].Cells[col_jc_lyqx.Name].Value);
                string bz = (string)grid_jch.SelectedRows[0].Cells[col_jc_bz.Name].Value ?? "";
                TJinchuhuo nc = new TJinchuhuo 
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
            DataGridViewRow dr = grid_jch.Rows[e.RowIndex];
            if (dr.Cells[col_jc_sbsj.Name].Value != null)
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
            if (!grid_jcmx.IsCurrentCellInEditMode)
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
                int mxid = (int)grid_jcmx.SelectedRows[0].Cells[col_mx_id.Name].Value; 
                short sl = short.Parse(grid_jcmx.SelectedRows[0].Cells[col_mx_sl.Name].Value.ToString());
                DBContext db = new DBContext();
                TJinchuMX mx = new TJinchuMX 
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
            int crkid = (int)grid_jch.SelectedRows[0].Cells[col_jc_id.Name].Value;            
            DBContext db = new DBContext();
            TJinchuhuo c = db.GetJinchuhuoById(crkid);
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

        /// <summary>
        /// 上报进出货数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_shangbao_Click(object sender, EventArgs e)
        {
            //取得所有未上报的数据
            DBContext db = new DBContext();
            TJinchuhuo[] jcs = db.GetJinchuhuosWeishangbao();
            if (jcs.Count() == 0)
            {
                MessageBox.Show("没有需要上报的数据");
                return;
            }

            JCSJData.TFendianJinchuhuo[] jcjcs = jcs.Select(r => new JCSJData.TFendianJinchuhuo
            {
                oid = r.id,
                fangxiang = r.fangxiang,
                laiyuanquxiang = r.laiyuanquxiang,
                beizhu = r.beizhu,
                fashengshijian = r.charushijian,
                TFendianJinchuhuoMX = r.TJinchuMX.Select(mr => new JCSJData.TFendianJinchuhuoMX 
                {
                    tiaomaid = mr.tiaomaid,
                    shuliang = mr.shuliang
                }).ToArray()
            }).ToArray();

            //登陆到数据中心
            _jdc = CommonFunc.LoginJCSJ(_jdc);
            _jdc.ShangbaoJinchuhuo(jcjcs);

            //更新本地上报时间
            int[] ids = jcs.Select(r => r.id).ToArray();
            db.UpdateJinchuhuoShangbaoshijian(ids, DateTime.Now);

            MessageBox.Show("完成");
        }
    }
}
