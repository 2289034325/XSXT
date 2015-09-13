using CKGL.Properties;
using DB_CK;
using DB_CK.Models;
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

namespace CKGL
{
    public partial class Form_Churuku : MyForm
    {
        public Form_Churuku()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 扫描条码
        /// </summary>
        /// <param name="tmh"></param>
        public override void OnScan(string tmh)
        {
            int jcid = (int)grid_crk.SelectedRows[0].Cells[col_crk_id.Name].Value;


            //检查该出入库记录是否已经上报
            if (!checkAllow())
            {
                MessageBox.Show("该记录已经上报到服务器，不能再修改");
                return;
            }

            DBContext db = IDB.GetDB();
            TTiaoma tm = db.GetTiaomaByTmh(tmh);
            if (tm == null)
            {
                MessageBox.Show("该条码不存在，或者打开条码信息页面，从服务器下载该条码信息");
                return;
            }

            //如果是出货，检查是否会引起库存负数
            if (Tool.JCSJ.DBCONSTS.JCH_FX.出.ToString().Equals(grid_crk.SelectedRows[0].Cells[col_crk_fx.Name].Value))
            {
                VKucun kc = db.GetKucunByTmid(tm.id);
                if (kc.shuliang == 0)
                {
                    MessageBox.Show("该条码库存为0，无法再出货，请核实数据");
                    return;
                }
            }

            TChurukuMX mx = getMx(jcid, tm.id);
            if (mx != null)
            {
                db.UpdateChurukuMx(mx.id, (short)(mx.shuliang + 1));
            }
            else
            {
                TChurukuMX nmx = new TChurukuMX
                {
                    churukuid = jcid,
                    tiaomaid = tm.id,
                    shuliang = 1
                };
                TChurukuMX[] mxs = new TChurukuMX[] { nmx };
                db.InsertChurukuMxs(mxs);
            }

            refreshMx();
        }

        private TChurukuMX getMx(int jcid, int tmid)
        {
            DBContext db = IDB.GetDB();
            return db.GetChurukuMxByCrkIdTmid(jcid, tmid);
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

            DBContext db = IDB.GetDB();
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
                    ((Tool.JCSJ.DBCONSTS.JCH_FX)c.fangxiang).ToString(),
                    c.laiyuanquxiang.ToString(),
                    c.TChurukuMXes.Sum(r=>(short?)r.shuliang)??0,
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

            DBContext db = IDB.GetDB();
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
                fangxiang = (byte)Tool.JCSJ.DBCONSTS.JCH_FX.进,
                laiyuanquxiang = (byte)Tool.JCSJ.DBCONSTS.JCH_LYQX.新货,
                beizhu = "",
                caozuorenid = RuntimeInfo.LoginUser.id,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now,
                shangbaoshijian = null
            };

            DBContext db = IDB.GetDB();
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
                fangxiang = (byte)Tool.JCSJ.DBCONSTS.JCH_FX.出,
                laiyuanquxiang = (byte)Tool.JCSJ.DBCONSTS.JCH_LYQX.分店,
                beizhu = "",
                caozuorenid = RuntimeInfo.LoginUser.id,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now,
                shangbaoshijian = null
            };

            DBContext db = IDB.GetDB();
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

            DBContext db = IDB.GetDB();
            Dlg_Tiaomahao dt = new Dlg_Tiaomahao();
            if (dt.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] tmhs = dt.txb_tmhs.Text.Trim().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, short> tmsls = tmhs.ToDictionary(k => k.Split(new char[] { ',' })[0], v => short.Parse(v.Split(new char[] { ',' })[1]));

                TTiaoma[] tms = db.GetTiaomasByTmhs(tmsls.Select(r => r.Key).ToArray());
                Dictionary<int, short> tss = tms.ToDictionary(k => k.id, v => tmsls[v.tiaoma]);
                if (tms.Length != tmhs.Length)
                {
                    MessageBox.Show("有条码信息不存在，请先下载条码信息");
                }
                else
                {
                    List<TChurukuMX> mxs = new List<TChurukuMX>();
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
                DBContext db = IDB.GetDB();
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
                DBContext db = IDB.GetDB();
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
                //如果是来源去向列
                if (e.ColumnIndex == col_crk_lyqx.Index)
                {
                    Tool.JCSJ.DBCONSTS.JCH_LYQX lyfx = (Tool.JCSJ.DBCONSTS.JCH_LYQX)Enum.Parse(typeof(Tool.JCSJ.DBCONSTS.JCH_LYQX), e.FormattedValue.ToString());

                    //来源只能是新货和内部，去向只能是退货，丢弃，其他
                    string sfx = (string)grid_crk.SelectedRows[0].Cells[col_crk_fx.Name].Value;
                    Tool.JCSJ.DBCONSTS.JCH_FX fx = (Tool.JCSJ.DBCONSTS.JCH_FX)Enum.Parse(typeof(Tool.JCSJ.DBCONSTS.JCH_FX), sfx);
                    if (fx == Tool.JCSJ.DBCONSTS.JCH_FX.进)
                    {
                        if (lyfx != Tool.JCSJ.DBCONSTS.JCH_LYQX.分店 && lyfx != Tool.JCSJ.DBCONSTS.JCH_LYQX.新货 &&
                            lyfx != Tool.JCSJ.DBCONSTS.JCH_LYQX.仓库)
                        {
                            e.Cancel = true;
                            MessageBox.Show("进货的来源只能是[" + Tool.JCSJ.DBCONSTS.JCH_LYQX.新货.ToString() + "]或者["
                                + Tool.JCSJ.DBCONSTS.JCH_LYQX.分店.ToString() + "]或者[" + Tool.JCSJ.DBCONSTS.JCH_LYQX.仓库.ToString() + "]");
                        }
                    }
                    else
                    {
                        if (lyfx == Tool.JCSJ.DBCONSTS.JCH_LYQX.新货)
                        {
                            e.Cancel = true;
                            MessageBox.Show("出货的去向不能是[" + Tool.JCSJ.DBCONSTS.JCH_LYQX.新货.ToString() + "]");
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
                DBContext db = IDB.GetDB();
                byte lyqx = (byte)(Tool.JCSJ.DBCONSTS.JCH_LYQX)Enum.Parse(typeof(Tool.JCSJ.DBCONSTS.JCH_LYQX), (string)grid_crk.SelectedRows[0].Cells[col_crk_lyqx.Name].Value);
                string bz = (string)grid_crk.SelectedRows[0].Cells[col_crk_bz.Name].Value ?? "";
                TChuruku nc = new TChuruku
                {
                    id = crkid,
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
            if (!checkAllow())
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
                DBContext db = IDB.GetDB();
                //TChurukuMX mx = new TChurukuMX 
                //{
                //    id = mxid,
                //    shuliang = sl                    
                //};
                db.UpdateChurukuMx(mxid, sl);
            }
        }

        /// <summary>
        /// 检查是否允许修改或者删除
        /// </summary>
        /// <returns></returns>
        private bool checkAllow()
        {
            int crkid = (int)grid_crk.SelectedRows[0].Cells[col_crk_id.Name].Value;
            DBContext db = IDB.GetDB();
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

        /// <summary>
        /// 上报进出货数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_shangbao_Click(object sender, EventArgs e)
        {
            //取得所有未上报的数据
            DBContext db = IDB.GetDB();
            TChuruku[] jcs = db.GetChurukuWeishangbao();
            if (jcs.Count() == 0)
            {
                MessageBox.Show("没有需要上报的数据");
                return;
            }

            JCSJData.TCangkuJinchuhuo[] jcjcs = jcs.Select(r => new JCSJData.TCangkuJinchuhuo
            {
                oid = r.id,
                fangxiang = r.fangxiang,
                laiyuanquxiang = r.laiyuanquxiang,
                gxckid = r.cangkuid,
                fdid = r.fendianid,
                jmsid = r.jmsid,
                zhekou = r.zhekou,                
                beizhu = r.beizhu,
                fashengshijian = r.charushijian,
                TCangkuJinchuhuoMXes = r.TChurukuMXes.Select(mr => new JCSJData.TCangkuJinchuhuoMX
                {
                    tiaomaid = mr.tiaomaid,
                    shuliang = mr.shuliang,                    
                }).ToArray()
            }).ToArray();


            new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
            {
                try
                {
                    //数据中心处理                
                    JCSJWCF.ShangbaoJinchuhuo_CK(jcjcs);

                    //更新本地上报时间
                    int[] ids = jcs.Select(r => r.id).ToArray();
                    db.UpdateChurukuShangbaoshijian(ids, DateTime.Now);

                    ShowMsg("完成",false);
                }
                catch (Exception ex)
                {
                    Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                    ShowMsg(ex.Message, true);
                }
            }, false).Start();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Churuku_Load(object sender, EventArgs e)
        {
            //来源去向列的下拉框值
            col_crk_lyqx.DataSource = Tool.CommonFunc.GetTableFromEnum(typeof(Tool.JCSJ.DBCONSTS.JCH_LYQX));
            col_crk_lyqx.DisplayMember = "Text";
            col_crk_lyqx.ValueMember = "Value";
        }

        /// <summary>
        /// 上传到中央服务器给分店下载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_crk_uplazy_Click(object sender, EventArgs e)
        {
            if (grid_crk.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择一行数据");
                return;
            }

            int id = (int)grid_crk.SelectedRows[0].Cells[col_crk_id.Name].Value;
            DBContext db = IDB.GetDB();
            //取得数据
            TChuruku crk = db.GetChurukuById(id);
            if (crk.fangxiang != (byte)Tool.JCSJ.DBCONSTS.JCH_FX.出)
            {
                MessageBox.Show("只有出货清单可以直接给分店下载");
                return;
            }
            if (crk.shangbaoshijian == null)
            {
                MessageBox.Show("请先上报进出货数据");
                return;
            }
            else if (crk.fangxiang != (byte)Tool.JCSJ.DBCONSTS.JCH_FX.进 && crk.laiyuanquxiang != (byte)Tool.JCSJ.DBCONSTS.JCH_LYQX.分店)
            {
                MessageBox.Show("只能上传出货到分店的数据");
                return;
            }

            Dlg_Fendian dl = new Dlg_Fendian();
            if (dl.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int fdid = int.Parse(dl.cmb_fd.SelectedValue.ToString());
                new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
                {
                    try
                    {
                        JCSJWCF.CangkuFahuoFendian(id, fdid);
                        ShowMsg("上传成功", false);
                    }
                    catch (Exception ex)
                    {
                        Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                        ShowMsg(ex.Message, true);
                    }
                }, true).Start();
            }
        }

        /// <summary>
        /// 增加一个进出库记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            Dlg_Jinchu dj = new Dlg_Jinchu();
            if (dj.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TChuruku cr = dj.Churuku;
                addChuruku(cr);
            }
        }
    }
}
