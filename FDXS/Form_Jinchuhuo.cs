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
    public partial class Form_Jinchuhuo : MyForm
    {
        //批量输入条码对话框
        private Dlg_Tiaomahao _dlgtm;

        public Form_Jinchuhuo()
        {
            InitializeComponent();
            base.InitializeComponent();
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
                MessageBox.Show("该记录已经确定，不能再修改");
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
                db.UpdateJinchuhuoMx_sl(mx.id, (short)(mx.shuliang + 1));

                foreach (DataGridViewRow dr in grid_jcmx.Rows)
                {
                    int id = (int)dr.Cells[col_mx_id.Name].Value;
                    if (id == mx.id)
                    {
                        dr.Cells[col_mx_sl.Name].Value = short.Parse(dr.Cells[col_mx_sl.Name].Value.ToString()) + 1;
                        //置顶显示该行
                        grid_jcmx.ClearSelection();
                        dr.Selected = true;
                        grid_jcmx.FirstDisplayedScrollingRowIndex = dr.Index;
                        break;
                    }
                }
            }
            else
            {
                TJinchuMX nmx = new TJinchuMX
                {
                    jinchuid = jcid,
                    tiaomaid = tm.id,
                    shuliang = 1
                };
                //TJinchuMX[] mxs = new TJinchuMX[] { nmx };
                nmx = db.InsertJinchuMx(nmx);

                addJinchuMx(nmx);
            }

            //refreshMx();
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
            string sid = txb_tm.Text.Trim();

            string tm = txb_tm.Text.Trim();
            DateTime? dstart = null;
            DateTime? dend = null;
            if (dp_start.Checked)
            {
                dstart = dp_start.Value.Date;
            }
            if (dp_end.Checked)
            {
                dend = dp_end.Value.Date.AddDays(1).Date;
            }

            DBContext db = IDB.GetDB();
            TJinchuhuo[] cs = db.GetJinchuhuos(tm, dstart, dend);

            grid_jch.Rows.Clear();
            grid_jcmx.Rows.Clear();
            foreach (TJinchuhuo c in cs)
            {
                addJinchuhuo(c);
            }
        }

        private void addJinchuhuo(TJinchuhuo c)
        {
            grid_jch.Rows.Insert(0, new object[] 
                {
                    c.id,
                    ((Tool.JCSJ.DBCONSTS.JCH_FX)c.fangxiang).ToString(),
                    ((Tool.JCSJ.DBCONSTS.LYQX_FD)c.laiyuanquxiang).ToString(),
                    c.picima,
                    c.TJinchuMXes.Sum(r=>(short?)r.shuliang)??0,
                    c.TJinchuMXes.Sum(r=>(decimal?)r.TTiaoma.jinjia*r.shuliang)??0,
                    c.queding?"√":"",
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
            int i = grid_jcmx.Rows.Add(new object[] 
                {
                    mx.id,
                    mx.TTiaoma.tiaoma,
                    mx.TTiaoma.kuanhao,
                    mx.TTiaoma.pinming,
                    mx.TTiaoma.yanse,
                    mx.TTiaoma.chima,
                    mx.shuliang,
                    mx.danjia,
                    mx.TTiaoma.shoujia
                });

            grid_jcmx.ClearSelection();
            grid_jcmx.Rows[i].Selected = true;
            //置顶显示该行
            grid_jcmx.FirstDisplayedScrollingRowIndex = i;
        }

        /// <summary>
        /// 增加一个进货记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_jh_Click(object sender, EventArgs e)
        {
            //TJinchuhuo c = new TJinchuhuo
            //{
            //    fangxiang = (byte)Tool.JCSJ.DBCONSTS.JCH_FX.进,
            //    laiyuanquxiang = (byte)Tool.JCSJ.DBCONSTS.LYQX_FD.新货,
            //    beizhu = "",
            //    queding = false,
            //    caozuorenid = RuntimeInfo.LoginUser.id,
            //    charushijian = DateTime.Now,
            //    xiugaishijian = DateTime.Now,
            //    shangbaoshijian = null
            //};

            //DBContext db = IDB.GetDB();
            //TJinchuhuo nc = db.InsertJinchuhuo(c);
            //nc.TUser = RuntimeInfo.LoginUser;
            //addJinchuhuo(nc);

            Dlg_Jinchu dj = new Dlg_Jinchu();
            if (dj.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                addJinchuhuo(dj.Jinchu);
            }
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

            //检查该出入库记录是否已经上报
            if (!checkAllow())
            {
                MessageBox.Show("该记录已经确定，不能再导入明细数据");
                return;
            }

            DBContext db = IDB.GetDB();
            if (_dlgtm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
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

                List<TJinchuMX> mxs = new List<TJinchuMX>();
                foreach (TTiaoma t in tms)
                {
                    TJinchuMX mx = new TJinchuMX
                    {
                        jinchuid = crkid,
                        tiaomaid = t.id,
                        danjia = t.jinjia,
                        shuliang = tmsls[t.tiaoma]
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

                //操作成功后清除输入的条码号
                _dlgtm.txb_tmhs.Text = "";
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
                MessageBox.Show("该记录已经确定，不允许再删除");
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
                MessageBox.Show("数据已经被确定，不允许再删除");
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
            db.UpdateJinchuhuo(nc);
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
            else if (e.ColumnIndex == col_mx_jj.Index)
            {
                decimal jj;
                if (!decimal.TryParse(e.FormattedValue.ToString(), out jj))
                {
                    MessageBox.Show("只允许输入数字");
                    e.Cancel = true;
                    return;
                }
                else
                {
                    if (jj <= 0)
                    {
                        MessageBox.Show("只允许输入大于0的数字");
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

            DBContext db = IDB.GetDB();
            if (e.ColumnIndex == col_mx_sl.Index)
            {
                int mxid = (int)grid_jcmx.Rows[e.RowIndex].Cells[col_mx_id.Name].Value;
                short sl = short.Parse(grid_jcmx.Rows[e.RowIndex].Cells[col_mx_sl.Name].Value.ToString());
                db.UpdateJinchuhuoMx_sl(mxid, sl);
            }
            else if (e.ColumnIndex == col_mx_jj.Index)
            {
                int mxid = (int)grid_jcmx.Rows[e.RowIndex].Cells[col_mx_id.Name].Value;
                decimal jj = decimal.Parse(grid_jcmx.Rows[e.RowIndex].Cells[col_mx_jj.Name].Value.ToString());
                db.UpdateJinchuhuoMx_jj(mxid, jj);

                //如果是进货记录的画，更新条码信息的进价                
                TJinchuMX mx = db.GetJinchuhuoMXById(mxid);
                TJinchuhuo jc = db.GetJinchuhuoById(mx.jinchuid);
                if (jc.fangxiang == (byte)Tool.JCSJ.DBCONSTS.JCH_FX.进)
                {
                    db.UpdateTiaomaJinjia(mx.tiaomaid, jj);
                }
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
            if (c.queding)
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
        //private void btn_shangbao_Click(object sender, EventArgs e)
        //{
        //    new Tool.ActionMessageTool(btn_shangbao_Click_sync, false).Start();    
        //}

        //private void btn_shangbao_Click_sync(Tool.ActionMessageTool.ShowMsg ShowMsg)
        //{
        //    try
        //    {
        //        MyTask.SBJinchuhuo();
        //        ShowMsg("完成", false);
        //    }
        //    catch (Exception ex)
        //    {
        //        Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
        //        ShowMsg(ex.Message, true);
        //    }               
        //}

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Jinchuhuo_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 下载进货数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xzjinhuo_Click(object sender, EventArgs e)
        {
            Dlg_Picima dp = new Dlg_Picima();
            if (dp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string pcm = dp.Pcm;
                new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
                {
                    try
                    {
                        DBContext db = IDB.GetDB();
                        //检测批次码是否已存在
                        if (!string.IsNullOrEmpty(pcm))
                        {
                            TJinchuhuo ojc = db.GetJinchuhuoByPcm(pcm);
                            if (ojc != null)
                            {
                                ShowMsg("该批次码数据已经存在", true);
                                return;
                            }
                        }

                        JCSJData.TCangkuJinchuhuo[] jhs = new JCSJData.TCangkuJinchuhuo[] { };
                        if (string.IsNullOrEmpty(pcm))
                        {
                            jhs = JCSJWCF.XiazaiJinhuoShuju();
                        }
                        else
                        {
                            JCSJData.TCangkuJinchuhuo jh = JCSJWCF.XiazaiJinhuoShujuByPcm(pcm);
                            if (jh != null)
                            {
                                jhs = new JCSJData.TCangkuJinchuhuo[] { jh };
                            }
                            else
                            {
                                ShowMsg("该批次码不存在", true);
                                return;
                            }
                        }

                        if (jhs.Length == 0)
                        {
                            ShowMsg("没有数据可下载", true);
                            return;
                        }


                        //保存条码
                        TTiaoma[] tms = jhs.SelectMany(r => r.TCangkuJinchuhuoMXes).Select(r => new TTiaoma
                        {
                            id = r.TTiaoma.id,
                            tiaoma = r.TTiaoma.tiaoma,
                            gongyingshang = r.TTiaoma.TGongyingshang.mingcheng,
                            kuanhao = r.TTiaoma.TKuanhao.kuanhao,
                            gyskuanhao = r.TTiaoma.gyskuanhao,
                            leixing = r.TTiaoma.TKuanhao.leixing,
                            pinming = r.TTiaoma.TKuanhao.pinming,
                            yanse = r.TTiaoma.yanse,
                            chima = r.TTiaoma.chima,
                            jinjia = r.danjia,
                            shoujia = r.TTiaoma.shoujia,
                            charushijian = DateTime.Now,
                            xiugaishijian = DateTime.Now
                        }).ToArray();
                        string[] tmhs = tms.Select(r => r.tiaoma).ToArray();
                        TTiaoma[] otms = db.GetTiaomasByTmhs(tmhs);
                        string[] otmhs = otms.Select(r => r.tiaoma).ToArray();

                        TTiaoma[] utms = tms.Where(r => otmhs.Contains(r.tiaoma)).ToArray();
                        TTiaoma[] ntms = tms.Where(r => !otmhs.Contains(r.tiaoma)).ToArray();
                        db.UpdateTiaomas(utms);
                        db.InsertTiaomas(ntms);

                        //保存进货信息
                        List<string> cpcm = new List<string>();
                        foreach (JCSJData.TCangkuJinchuhuo j in jhs)
                        {
                            //如果某批次的进货数据已经存在，则直接跳过，不保存
                            TJinchuhuo ojc = db.GetJinchuhuoByPcm(j.picima);
                            if (ojc != null)
                            {
                                cpcm.Add(j.picima);
                                continue;
                            }

                            TJinchuhuo jc = new TJinchuhuo
                            {
                                picima = j.picima,
                                fangxiang = (byte)Tool.JCSJ.DBCONSTS.JCH_FX.进,
                                laiyuanquxiang = (byte)Tool.JCSJ.DBCONSTS.LYQX_FD.新货,
                                beizhu = "从服务器下载",
                                caozuorenid = RuntimeInfo.LoginUser.id,
                                charushijian = DateTime.Now,
                                xiugaishijian = DateTime.Now,
                                TJinchuMXes = j.TCangkuJinchuhuoMXes.Select(xr => new TJinchuMX
                                {
                                    tiaomaid = xr.tiaomaid,
                                    danjia = xr.danjia,
                                    shuliang = xr.shuliang
                                }).ToArray(),

                            };
                            db.InsertJinchuhuo(jc);
                        }

                        //像服务器返回信息表示已经收到数据
                        JCSJWCF.XiazaiJinhuoShujuFinish(jhs.Select(r => r.id).ToArray());
                        int total = jhs.Where(r=>!cpcm.Contains(r.picima)).SelectMany(r => r.TCangkuJinchuhuoMXes).Sum(r => r.shuliang);
                        string cInfo = "";
                        if (cpcm.Count() != 0)
                        {
                            cInfo = "\r\n【" + cpcm.Aggregate((a, b) => { return a + "," + b; }) + "】的数据被下载过，在本次操作已中被忽略";
                        }
                        ShowMsg("进货" + total + "件" + cInfo, false);
                    }
                    catch (Exception ex)
                    {
                        Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                        ShowMsg(ex.Message, true);
                    }
                }, false).Start();
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
                            try
                            {
                                ShowMsg("正在执行，请稍等", false);

                                JCSJWCF.DeleteJinchuhuo(jc.id);
                                db.UpdateJinchuhuoShangbaoshijian(new int[] { jc.id }, null);

                                ShowMsg("撤销成功", false);
                            }
                            catch (Exception ex)
                            {
                                Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                                ShowMsg(ex.Message, true);                                
                            }
                        }, false).Start();
                    }
                }
            }
        }

        /// <summary>
        /// 将指定进出库数据发送到邮箱
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_crk_mail_Click(object sender, EventArgs e)
        {
            int id = (int)grid_jch.SelectedRows[0].Cells[col_jc_id.Name].Value;

            DBContext db = IDB.GetDB();
            TJinchuhuo jch = db.GetJinchuhuoById(id);
            TJinchuMX[] mxs = db.GetJinchuhuoMxsByJchId(id);

            if (mxs.Count() == 0)
            {
                MessageBox.Show("没有数据");
                return;
            }

            //拼接邮件内容
            string body = "<table style='border:solid 1px grey;font-color:black' rules='all' border='1'>";
            body += "<tr style='background-color:#2C6980;font-weight: bold;color:white;'>"
                +"<th>条码</th><th>款号</th><th>品名</th><th>颜色</th><th>尺码</th><th>数量</th><th>进价</th></tr>";
            foreach (TJinchuMX mx in mxs)
            {
                body += "<tr>";
                body += "<td>" + mx.TTiaoma.tiaoma + "</td>";
                body += "<td>" + mx.TTiaoma.kuanhao + "</td>";
                body += "<td>" + mx.TTiaoma.pinming + "</td>";
                body += "<td>" + mx.TTiaoma.yanse + "</td>";
                body += "<td>" + mx.TTiaoma.chima + "</td>";
                body += "<td>" + mx.shuliang + "</td>";
                body += "<td>" + mx.TTiaoma.jinjia + "</td>";
                body += "</tr>";
            }
            body += "<tr>";
            body += "<td style='color:red;font-weight: bold;font-size:15px;'>合计</td>";
            body += "<td></td>";
            body += "<td></td>";
            body += "<td></td>";
            body += "<td></td>";
            body += "<td style='color:red;font-weight: bold;font-size:15px;'>" + jch.TJinchuMXes.Sum(r => r.shuliang) + "</td>";
            body += "<td style='color:red;font-weight: bold;font-size:15px;'>" + jch.TJinchuMXes.Sum(r => r.TTiaoma.jinjia * r.shuliang) + "</td>";
            body += "</tr>";
            body += "</table>";

            Dlg_SingleCommon dl = new Dlg_SingleCommon();
            if (dl.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string to = dl.txb_input.Text.Trim();
                if (!Tool.CommonFunc.IsEmail(to))
                {
                    MessageBox.Show("输入的不是合法的邮件地址");
                    return;
                }

                string server = Settings.Default.MailServer;
                int port = Settings.Default.MailPort;
                string user = Settings.Default.MailUser;
                string psw = Settings.Default.MailPsw;
                string subject = ((Tool.JCSJ.DBCONSTS.JCH_FX)jch.fangxiang).ToString() + "货清单-" + Settings.Default.FDMC;                
                string from = "MissSystem@acxca.com";


                new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
                {
                    try
                    {
                        ShowMsg("开始身份验证", false);
                        JCSJWCF.Login();

                        ShowMsg("开始发送", false);
                        Tool.CommonFunc.SendMail(subject, body, server, port, user, psw, from, to);

                        ShowMsg("发送成功", false);
                    }
                    catch (Exception ex)
                    {
                        Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                        ShowMsg(ex.Message, true);
                    }
                }, false).Start();
            }
        }

        /// <summary>
        /// 进货数量和价格确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_crk_queren_Click(object sender, EventArgs e)
        {
            int id = (int)grid_jch.SelectedRows[0].Cells[col_jc_id.Name].Value;

            DBContext db = IDB.GetDB();
            TJinchuhuo jch = db.GetJinchuhuoById(id);

            if (jch.shangbaoshijian != null)
            {
                MessageBox.Show("数据已上报，无法修改确认状态");
                return;
            }

            if (jch.TJinchuMXes.Count() == 0)
            {
                MessageBox.Show("没有详细数据，无法确认");
                return;
            }

            db.UpdateJinchuhuoQueren(id, true);
        }

        /// <summary>
        /// 取消确认状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_crk_queren_quxiao_Click(object sender, EventArgs e)
        {
            int id = (int)grid_jch.SelectedRows[0].Cells[col_jc_id.Name].Value;

            DBContext db = IDB.GetDB();
            TJinchuhuo jch = db.GetJinchuhuoById(id);

            if (jch.shangbaoshijian != null)
            {
                MessageBox.Show("数据已上报，无法修改确认状态");
                return;
            }

            db.UpdateJinchuhuoQueren(id, false);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_crk_xg_Click(object sender, EventArgs e)
        {
            int id = (int)grid_jch.SelectedRows[0].Cells[col_jc_id.Name].Value;

            DBContext db = IDB.GetDB();
            TJinchuhuo jch = db.GetJinchuhuoById(id);

            if (jch.queding)
            {
                MessageBox.Show("数据已经确认，无法再修改");
                return;
            }

            Dlg_Jinchu dj = new Dlg_Jinchu(jch);
            dj.ShowDialog();
        }

        /// <summary>
        /// 上报指定数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_crk_sbsj_Click(object sender, EventArgs e)
        {
            int id = (int)grid_jch.SelectedRows[0].Cells[col_jc_id.Name].Value;

            DBContext db = IDB.GetDB();
            TJinchuhuo jch = db.GetJinchuhuoById(id);

            if (!jch.queding)
            {
                MessageBox.Show("数据未确认，无法上报");
                return;
            }

            if (jch.shangbaoshijian != null)
            {
                MessageBox.Show("数据已经上报");
                return;
            }

            new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
            {
                try
                {
                    ShowMsg("正在上传数据，请稍等", false);

                    //做接口参数
                    JCSJData.TFendianJinchuhuo jcjc = new JCSJData.TFendianJinchuhuo
                    {
                        picima = jch.picima,
                        oid = jch.id,
                        fangxiang = jch.fangxiang,
                        laiyuanquxiang = jch.laiyuanquxiang,
                        beizhu = jch.beizhu,
                        fashengshijian = jch.charushijian,
                        TFendianJinchuhuoMXes = jch.TJinchuMXes.Select(mr => new JCSJData.TFendianJinchuhuoMX
                        {
                            tiaomaid = mr.tiaomaid,
                            danjia = mr.danjia,
                            shuliang = mr.shuliang
                        }).ToArray()
                    };

                    //调用服务接口
                    JCSJWCF.ShangbaoJinchuhuo_FD(new JCSJData.TFendianJinchuhuo[] { jcjc });

                    //更新本地上报时间
                    db.UpdateJinchuhuoShangbaoshijian(new int[] { jch.id }, DateTime.Now);

                    ShowMsg("完成", false);
                }
                catch (Exception ex)
                {
                    Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                    ShowMsg(ex.Message, true);
                }
            }, false).Start();           
        }
    }
}
