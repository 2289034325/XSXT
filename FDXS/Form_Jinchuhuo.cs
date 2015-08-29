using DB_FD;
using DB_FD.Models;
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
    public partial class Form_Jinchuhuo : MyForm
    {
        //批量输入条码对话框
        private Dlg_Tiaomahao _dlgtm;

        public Form_Jinchuhuo()
        {
            InitializeComponent();
            _dlgtm = new Dlg_Tiaomahao();
        }

        /// <summary>
        /// 扫描枪事件
        /// </summary>
        /// <param name="tm"></param>
        public override void OnScan(string tmh)
        {
            //判断是不是正在批量输入
            if (_dlgtm.Visible)
            {
                _dlgtm.OnScan(tmh);
                return;
            }

            int jcid = (int)grid_jch.SelectedRows[0].Cells[col_jc_id.Name].Value;


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
            if (Tool.JCSJ.DBCONSTS.JCH_FX.出.ToString().Equals(grid_jch.SelectedRows[0].Cells[col_jc_fx.Name].Value))
            {
                VKucun kc = db.GetKucunByTiaomaId(tm.id);
                if (kc.shuliang == 0)
                {
                    MessageBox.Show("该条码库存为0，无法再出货，请核实数据");
                    return;
                }
            }

            TJinchuMX mx = getMx(jcid, tm.id);
            if (mx != null)
            {
                db.UpdateChurukuMx(mx.id, (short)(mx.shuliang + 1));
            }
            else
            {
                TJinchuMX nmx = new TJinchuMX
                {
                    jinchuid = jcid,
                    tiaomaid = tm.id,
                    shuliang = 1
                };
                TJinchuMX[] mxs = new TJinchuMX[] { nmx };
                db.InsertJinchuMxs(mxs);
            }

            refreshMx();
        }

        /// <summary>
        /// 检查某个出入库明细是否已经存在
        /// </summary>
        /// <param name="jcid"></param>
        /// <param name="tmid"></param>
        /// <returns></returns>
        private TJinchuMX getMx(int jcid, int tmid)
        {
            DBContext db = IDB.GetDB();
            return db.GetJinchuhuoMX(jcid, tmid);
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

            DBContext db = IDB.GetDB();
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
                    ((Tool.JCSJ.DBCONSTS.JCH_FX)c.fangxiang).ToString(),
                    c.laiyuanquxiang.ToString(),
                    c.TJinchuMXes.Sum(r=>(short?)r.shuliang)??0,
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

            DBContext db = IDB.GetDB();
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
                fangxiang = (byte)Tool.JCSJ.DBCONSTS.JCH_FX.进,
                laiyuanquxiang = (byte)Tool.JCSJ.DBCONSTS.JCH_LYQX.仓库,
                beizhu = "",
                caozuorenid = RuntimeInfo.LoginUser.id,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now,
                shangbaoshijian = null
            };

            DBContext db = IDB.GetDB();
            TJinchuhuo nc = db.InsertJinchuhuo(c);
            nc.TUser = RuntimeInfo.LoginUser;
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
                fangxiang = (byte)Tool.JCSJ.DBCONSTS.JCH_FX.出,
                laiyuanquxiang = (byte)Tool.JCSJ.DBCONSTS.JCH_LYQX.退货,
                beizhu = "",
                caozuorenid = RuntimeInfo.LoginUser.id,
                charushijian = DateTime.Now,
                xiugaishijian = DateTime.Now,
                shangbaoshijian = null
            };

            DBContext db = IDB.GetDB();
            TJinchuhuo nc = db.InsertJinchuhuo(c);
            nc.TUser = RuntimeInfo.LoginUser;

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
            Tool.JCSJ.DBCONSTS.JCH_FX fx = (Tool.JCSJ.DBCONSTS.JCH_FX)Enum.Parse(typeof(Tool.JCSJ.DBCONSTS.JCH_FX), (string)grid_jch.SelectedRows[0].Cells[col_jc_fx.Name].Value);

            //if (fx == Tool.JCSJ.DBCONSTS.JCH_FX.出)
            //{
            //    MessageBox.Show("出货无法批量导入");
            //    return;
            //}            

            //检查该出入库记录是否已经上报
            if (!checkAllow())
            {
                MessageBox.Show("该记录已经上报到服务器，不能再导入明细数据");
                return;
            }

            DBContext db = IDB.GetDB();
            //Dlg_Tiaomahao dt = new Dlg_Tiaomahao();
            if (_dlgtm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //string[] tmhs = _dlgtm.txb_tmhs.Text.Trim().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                //Dictionary<string, short> tmsls = tmhs.ToDictionary(k => k.Split(new char[] { ',' })[0], v => short.Parse(v.Split(new char[] { ',' })[1]));

                string[] tmhs = _dlgtm.TMHs;
                Dictionary<string, short> tmsls = tmhs.GroupBy(r => r).
                    Select(r => new { tmh = r.Key, sl = r.Count() }).ToDictionary(r => r.tmh, v => (short)v.sl);
                string[] tmhs_all = tmsls.Keys.ToArray();

                TTiaoma[] tms = db.GetTiaomasByTmhs(tmhs);
                string[] tmhs_exist = tms.Select(r => r.tiaoma).ToArray();

                string[] tmhs_no = tmhs_all.Except(tmhs_exist).ToArray();
                //下载不存在的条码信息
                if (tmhs_no.Length != 0)
                {
                    CommonMethod.DownLoadTiaomaInfo(tmhs_no, true);
                }

                //下载后再检查是否有遗漏
                tms = db.GetTiaomasByTmhs(tmhs);
                tmhs_exist = tms.Select(r => r.tiaoma).ToArray();
                tmhs_no = tmhs_all.Except(tmhs_exist).ToArray();
                if (tmhs_no.Length != 0)
                {
                    string errtms = tmhs_no.Aggregate((a, b) => { return a + "," + b; });
                    MessageBox.Show("无法下载下列条码，请检查网络是否联通，或者确认这些条码来源\r\n" + errtms);
                    return;
                }
                Dictionary<int, short> tss = tms.ToDictionary(k => k.id, v => tmsls[v.tiaoma]);


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
                TJinchuMX[] all = mxs.ToArray();
                //已经存在的，数量加1
                TJinchuMX[] mx_exist = db.GetJinchuhuoMxsByJchId(crkid);
                int[] tmids_exist = mx_exist.Select(r=>r.tiaomaid).ToArray();
                TJinchuMX[] mx_insert = all.Where(r => !tmids_exist.Contains(r.tiaomaid)).ToArray();
                TJinchuMX[] mx_update = all.Where(r => tmids_exist.Contains(r.tiaomaid)).ToArray();

                db.InsertUpdateJinchuMxs(mx_insert,mx_update);

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
                e.Cancel = true;
                MessageBox.Show("该记录已经上报到服务器，不允许再删除");
                return;
            }
            else
            {
                DBContext db = IDB.GetDB();
                int crkid = (int)e.Row.Cells[col_jc_id.Name].Value;
                TJinchuhuo jc = db.GetJinchuhuoById(crkid);
                if (jc.TJinchuMXes.Count != 0)
                {
                    e.Cancel = true;
                    MessageBox.Show("请先删除下方的明细数据，在删除该记录");
                    return;
                }
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
                //删除后是否会导致库存数量为负
                DBContext db = IDB.GetDB();
                int mxid = (int)grid_jcmx.SelectedRows[0].Cells[col_mx_id.Name].Value;
                TJinchuMX mx = db.GetJinchuhuoMXById(mxid);
                if (mx.TJinchuhuo.fangxiang == (byte)Tool.JCSJ.DBCONSTS.JCH_FX.进)
                {
                    VKucun k = db.GetKucunByTiaomaId(mx.tiaomaid);
                    if (k.shuliang - mx.shuliang < 0)
                    {
                        e.Cancel = true;
                        MessageBox.Show("删除该记录会导致库存数量为负数");
                        return;
                    }
                }

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
                Tool.JCSJ.DBCONSTS.JCH_LYQX lyfx = (Tool.JCSJ.DBCONSTS.JCH_LYQX)Enum.Parse(typeof(Tool.JCSJ.DBCONSTS.JCH_LYQX), e.FormattedValue.ToString());

                //来源只能是新货和内部，去向只能是退货，丢弃，其他
                string sfx = (string)grid_jch.SelectedRows[0].Cells[col_jc_fx.Name].Value;
                Tool.JCSJ.DBCONSTS.JCH_FX fx = (Tool.JCSJ.DBCONSTS.JCH_FX)Enum.Parse(typeof(Tool.JCSJ.DBCONSTS.JCH_FX), sfx);
                if (fx == Tool.JCSJ.DBCONSTS.JCH_FX.进)
                {
                    if (lyfx != Tool.JCSJ.DBCONSTS.JCH_LYQX.仓库 && lyfx != Tool.JCSJ.DBCONSTS.JCH_LYQX.分店 && lyfx != Tool.JCSJ.DBCONSTS.JCH_LYQX.新货)
                    {
                        e.Cancel = true;
                        MessageBox.Show("进货的来源只能是[" + Tool.JCSJ.DBCONSTS.JCH_LYQX.新货.ToString() + "]或者[" + Tool.JCSJ.DBCONSTS.JCH_LYQX.仓库.ToString() + "]或者[" +
                            Tool.JCSJ.DBCONSTS.JCH_LYQX.分店.ToString() + "]");
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

        /// <summary>
        /// 检查该行是否允许编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_crk_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //DataGridViewRow dr = grid_jch.Rows[e.RowIndex];
            //if (dr.Cells[col_jc_sbsj.Name].Value != null)
            //{
            //    e.Cancel = true;
            //}
            if (!checkAllow())
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
            DBContext db = IDB.GetDB();
            byte lyqx = byte.Parse(grid_jch.SelectedRows[0].Cells[col_jc_lyqx.Name].Value.ToString());
            string bz = (string)grid_jch.SelectedRows[0].Cells[col_jc_bz.Name].Value ?? "";
            TJinchuhuo nc = new TJinchuhuo
            {
                id = crkid,
                laiyuanquxiang = lyqx,
                beizhu = bz,
                xiugaishijian = DateTime.Now
            };
            db.UpdateChuruku(nc);
        }

        /// <summary>
        /// 检查该行出入库明细是否允许修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_crkmx_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //DataGridViewRow dr = grid_jch.Rows[e.RowIndex];
            //if (dr.Cells[col_jc_sbsj.Name].Value != null)
            //{
            //    e.Cancel = true;
            //}
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
            if (!grid_jcmx.IsCurrentCellInEditMode)
            {
                return;
            }

            if (e.ColumnIndex == col_mx_sl.Index)
            {
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

                //检查变动是否会引起库存为负数
                DBContext db = IDB.GetDB();
                int id = (int)grid_jcmx.Rows[e.RowIndex].Cells[col_mx_id.Name].Value;
                TJinchuMX mx = db.GetJinchuhuoMXById(id);
                VKucun kc = db.GetKucunByTiaomaId(mx.tiaomaid);
                //进货
                if (Tool.JCSJ.DBCONSTS.JCH_FX.进.ToString().Equals(grid_jch.SelectedRows[0].Cells[col_jc_fx.Name].Value))
                {
                    if (kc.shuliang - mx.shuliang + sl < 0)
                    {
                        MessageBox.Show("修改后会导致库存数量为负数，请核实数据");
                        e.Cancel = true;
                        return;
                    }
                }

                //出货
                else
                {
                    if (kc.shuliang + mx.shuliang - sl < 0)
                    {
                        MessageBox.Show("修改后会导致库存数量为负数，请核实数据");
                        e.Cancel = true;
                        return;
                    }
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

            if (e.ColumnIndex == col_mx_sl.Index)
            {
                int mxid = (int)grid_jcmx.Rows[e.RowIndex].Cells[col_mx_id.Name].Value;
                short sl = short.Parse(grid_jcmx.Rows[e.RowIndex].Cells[col_mx_sl.Name].Value.ToString());
                DBContext db = IDB.GetDB();
                //TJinchuMX mx = new TJinchuMX 
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
            int crkid = (int)grid_jch.SelectedRows[0].Cells[col_jc_id.Name].Value;
            DBContext db = IDB.GetDB();
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
            new Tool.ActionMessageTool(btn_shangbao_Click_sync, false).Start();    
        }

        private void btn_shangbao_Click_sync(Tool.ActionMessageTool.ShowMsg ShowMsg)
        {
            try
            {
                MyTask.SBJinchuhuo();
                ShowMsg("完成", false);
            }
            catch (Exception ex)
            {
                Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                ShowMsg(ex.Message, true);
            }               
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Jinchuhuo_Load(object sender, EventArgs e)
        {
            //来源去向列的下拉框值
            col_jc_lyqx.DataSource = Tool.CommonFunc.GetTableFromEnum(typeof(Tool.JCSJ.DBCONSTS.JCH_LYQX));
            col_jc_lyqx.DisplayMember = "Text";
            col_jc_lyqx.ValueMember = "Value";
        }

        /// <summary>
        /// 下载进货数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xzjinhuo_Click(object sender, EventArgs e)
        {
            new Tool.ActionMessageTool(btn_xzjinhuo_Click_sync, false).Start();  
        }

        private void btn_xzjinhuo_Click_sync(Tool.ActionMessageTool.ShowMsg ShowMsg)
        {
            try
            {
                JCSJData.TCangkuJinchuhuo[] jhs = JCSJWCF.XiazaiJinhuoShuju();

                if (jhs.Length == 0)
                {
                    ShowMsg("没有数据可下载", true);
                    return;
                }

                DBContext db = IDB.GetDB();
                //检查是否有本地不存在的条码
                string[] tmhs = jhs.SelectMany(r => r.TCangkuJinchuhuoMXes).Select(r=>r.TTiaoma.tiaoma).ToArray();
                TTiaoma[] tms = db.GetTiaomasByTmhs(tmhs);
                string[] tmh_exist = tms.Select(r=>r.tiaoma).ToArray();

                string[] tmh_not_exist = tmhs.Except(tmh_exist).ToArray();
                //从服务器下载不存在的条码信息
                CommonMethod.DownLoadTiaomaInfo(tmh_not_exist, true);

                //string untmhs = tmh_not_exist.Aggregate((a, b) => { return a + "," + b; });
                //if (tmh_not_exist.Length != 0)
                //{
                //    ShowMsg("本地缺少条码信息，请先下载条码信息\r\n" + untmhs, true);
                //    return;
                //}

                TJinchuhuo[] jchs = jhs.Select(r => new TJinchuhuo
                {
                    fangxiang = (byte)Tool.JCSJ.DBCONSTS.JCH_FX.进,
                    laiyuanquxiang = (byte)Tool.JCSJ.DBCONSTS.JCH_LYQX.仓库,
                    beizhu = "从服务器下载",
                    caozuorenid = RuntimeInfo.LoginUser.id,
                    charushijian = DateTime.Now,
                    xiugaishijian = DateTime.Now,
                    TJinchuMXes = r.TCangkuJinchuhuoMXes.Select(xr => new TJinchuMX
                    {
                        tiaomaid = xr.tiaomaid,
                        shuliang = xr.shuliang
                    }).ToArray(),

                }).ToArray();

                TJinchuhuo[] njs = db.InsertJinchuhuos(jchs);
                foreach (TJinchuhuo jc in jchs)
                {
                    jc.TUser = RuntimeInfo.LoginUser;
                    addJinchuhuo(jc);
                }

                //像服务器返回信息表示已经收到数据
                JCSJWCF.XiazaiJinhuoShujuFinish(jhs.Select(r => r.id).ToArray());

                int total = jhs.SelectMany(r => r.TCangkuJinchuhuoMXes).Sum(r => r.shuliang);
                ShowMsg("进货" + total + "件", false);
            }
            catch (Exception ex)
            {
                Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                ShowMsg(ex.Message, true);
            }
        }

        /// <summary>
        /// 撤销上报记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_crk_cxsb_Click(object sender, EventArgs e)
        {
            if (grid_jch.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一行进出货记录");
                return;
            }

            DataGridViewRow dr = grid_jch.SelectedRows[0];

            DBContext db = IDB.GetDB();
            int crkid = (int)dr.Cells[col_jc_id.Name].Value;
            TJinchuhuo jc = db.GetJinchuhuoById(crkid);

            if (jc.shangbaoshijian == null)
            {
                MessageBox.Show("尚未上报，不需要撤销");
                return;
            }
            else
            {
                if ((DateTime.Now - jc.shangbaoshijian.Value).TotalDays > 1)
                {
                    MessageBox.Show("上报已经超过1天的数据，不允许撤销");
                    return;
                }
                else
                {
                    if (MessageBox.Show("是否确定撤销", "确认", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        //先去服务器删除
                        new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
                        {
                            JCSJWCF.DeleteJinchuhuo(jc.id);
                            db.UpdateJinchuhuoShangbaoshijian(new int[] { jc.id }, null);

                            ShowMsg("撤销成功", false);
                        }, false).Start();
                    }
                }
            }
        }
    }
}
