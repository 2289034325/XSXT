using BIANMA.Properties;
using DB_JCSJ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Tool.JCSJ;
using Tool;

namespace BIANMA
{
    public partial class Form_Bianma : Form
    {
        //客户端发号的ID
        private int _cid;

        //剪切或者复制的条码idex
        private int _tmidex;

        //输入的款号，条码，供应商是否都正确
        private bool _kuanhaoOK;
        private bool _tiaomaOK;

        private List<TKuanhaoExtend> _khs;
        //设置当前行的颜色
        private Color _rowColor;

        public Form_Bianma()
        {
            InitializeComponent();
            _kuanhaoOK = false;
            _tiaomaOK = false;
            //从1开始发号
            _cid = 1;
            _tmidex = 0;

            _khs = new List<TKuanhaoExtend>();
            _rowColor = Color.Black;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Bianma_Load(object sender, EventArgs e)
        {
        }       

        /// <summary>
        /// 加载所有该用户编辑的款号条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_jiazai_Click(object sender, EventArgs e)
        {
                Dlg_Jiazai dj = new Dlg_Jiazai();
                if (dj.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string kuanhao = dj.txb_kh.Text.Trim();
                    string tiaoma = dj.txb_tm.Text.Trim();
                    DateTime? start = dj.dp_start.Checked ? (DateTime?)dj.dp_start.Value.Date : null;
                    DateTime? end = dj.dp_end.Checked ? (DateTime?)dj.dp_end.Value.Date : null;
                    TTiaoma[] ts = null;
                    TKuanhao[] ks = null;
                    try
                    {
                        ts = JCSJWCF.GetTiaomas(LoginInfo.User.id, kuanhao, tiaoma, start, end);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }

                    ks = ts.Select(r => r.TKuanhao).ToArray();

                    //显示款号
                    List<TKuanhaoExtend> khexs = new List<TKuanhaoExtend>();
                    foreach(TKuanhao k in ks)
                    {
                        List<TTiaomaExtend> tsex = ts.Where(r => r.kuanhaoid == k.id).Select(r => new TTiaomaExtend
                         {
                             idex = getClientId(),
                             tiaoma = r,
                             shuliang = 0,
                             xj = XTCONSTS.TIAOMA_XINJIU.旧条码
                         }).ToList();
                        TKuanhaoExtend khex = new TKuanhaoExtend
                        {
                            idex = getClientId(),
                            xj = XTCONSTS.KUANHAO_XINJIU.旧款,
                            kuanhao = k,
                            tms = tsex
                        };

                        //addKuanhao(khex);
                        _khs.Add(khex);
                    }

                    //刷新表格显示
                    //refreshKuanhao();
                    foreach (TKuanhaoExtend tk in _khs)
                    {
                        foreach (TTiaomaExtend tt in tk.tms)
                        {
                            addTiaomaAllMsg(tk, tt);
                        }
                    }
            }
        }

        /// <summary>
        /// 显示合并信息
        /// </summary>
        /// <param name="t"></param>
        private void addTiaomaAllMsg(TKuanhaoExtend k, TTiaomaExtend t)
        {
            object[] item = new object[] 
                        {
                            t.idex,
                            k.idex,
                            k.kuanhao.kuanhao,        
                            k.xj.ToString(),
                            ((DBCONSTS.KUANHAO_XB)k.kuanhao.xingbie).ToString(),
                            ((DBCONSTS.KUANHAO_LX)k.kuanhao.leixing).ToString(),
                            k.kuanhao.pinming,
                            t.tiaoma.tiaoma,
                            t.xj.ToString(),
                            t.tiaoma.gyskuanhao,
                            t.tiaoma.yanse,
                            t.tiaoma.chima,
                            t.shuliang,
                            t.tiaoma.jinjia,
                            t.tiaoma.shoujia,
                            t.tiaoma.charushijian,
                            t.tiaoma.xiugaishijian
                        };

            //如果款号已经存在，在其下方插入
            int? index = null;
            foreach (DataGridViewRow dr in grid_all.Rows)
            {
                int khidex = (int)dr.Cells[col_all_khidex.Name].Value;
                if (khidex == k.idex)
                {
                    index = dr.Index;
                }
            }            

            if (index == null)
            {
                grid_all.Rows.Add(item);
            }
            else
            {
                grid_all.Rows.Insert(index.Value,item);
            }

        }

        /// <summary>
        /// 在grid的中增加一个款号
        /// </summary>
        /// <param name="tKuanhao"></param>
        private void addKuanhao(TKuanhaoExtend k)
        {
            ////合并标志
            //bool hb = false;
            ////如果已存在，就合并
            //TKuanhaoExtend exk = null;
            //List<TTiaomaExtend> otms = null;
            ////如果是空白，说明是点击菜单【新款】【旧款】添加的，否则是点击【加载】添加的旧款号
            //if (k.kuanhao.kuanhao == "")
            //{
            //    hb = false;
            //}
            ////如果款号不是空白，说明是加载的旧款号
            //else
            //{
            //    //遍历检查是否已经存在相同的旧款号
            //    foreach (DataGridViewRow dr in grid_kuanhao.Rows)
            //    {
            //        exk = (TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value;
            //        otms = exk.tms;
            //        //如果款号相同
            //        if (exk.kuanhao.kuanhao == k.kuanhao.kuanhao)
            //        {
            //            hb = true;

            //            //被标为新款，报错
            //            if (exk.xj == XTCONSTS.KUANHAO_XINJIU.新款)
            //            {
            //                MessageBox.Show("款号" + exk.kuanhao.kuanhao + "被标为新款号，无法加载");
            //                return;
            //            }
            //            //标为旧款，则合并条码信息
            //            else
            //            {
            //                //更新row显示
            //                dr.Cells[col_kh_khex.Name].Value = k;

            //                //合并条码列表
            //                //检查是否已经存在list里了
            //                foreach (TTiaomaExtend t in k.tms)
            //                {
            //                    if (!otms.Exists(r => r.tiaoma.tiaoma == t.tiaoma.tiaoma))
            //                    {
            //                        otms.Add(t);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            ////没有进行合并，就直接增加一行
            //if (!hb)
            //{
            //    grid_kuanhao.Rows.Add(new object[] 
            //            {
            //                k.idex,
            //                k.xj.ToString(),
            //                k.kuanhao.kuanhao,
            //                ((DBCONSTS.KUANHAO_XB)k.kuanhao.xingbie).ToString(),
            //                ((DBCONSTS.KUANHAO_LX)k.kuanhao.leixing).ToString(),
            //                k.kuanhao.pinming,
            //                k.kuanhao.caozuorenid,
            //                k
            //            });
            //}
        }

        /// <summary>
        /// 根据每行绑定的款号对象刷新款号grid显示
        /// </summary>
        private void refreshKuanhao()
        {
            //foreach (DataGridViewRow dr in grid_kuanhao.Rows)
            //{
            //    TKuanhaoExtend k = (TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value;
            //    dr.Cells[col_kh_xj.Name].Value = k.xj.ToString();
            //    dr.Cells[col_kh_kh.Name].Value = k.kuanhao.kuanhao.ToString();
            //    dr.Cells[col_kh_xb.Name].Value = ((DBCONSTS.KUANHAO_XB)k.kuanhao.xingbie).ToString();
            //    dr.Cells[col_kh_lx.Name].Value = ((DBCONSTS.KUANHAO_LX)k.kuanhao.leixing).ToString();
            //    dr.Cells[col_kh_pm.Name].Value = k.kuanhao.pinming;
            //}

            foreach (DataGridViewRow dr in grid_all.Rows)
            {
                int khidex = (int)dr.Cells[col_all_khidex.Name].Value;

                TKuanhaoExtend tk = _khs.Single(r => r.idex == khidex);

                dr.Cells[col_all_kh.Name].Value = tk.kuanhao.kuanhao;
            }
        }

        /// <summary>
        /// 管理供应商信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_gysxx_Click(object sender, EventArgs e)
        {
            Dlg_Gongyingshang dg = new Dlg_Gongyingshang();
            dg.ShowDialog();
        }

        /// <summary>
        /// 增加一个新款号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_addkh_Click(object sender, EventArgs e)
        {
            addKuanhao(true);            
        }

        /// <summary>
        /// 增加一个旧款号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_addjkh_Click(object sender, EventArgs e)
        {
            //addKuanhao(new TKuanhaoExtend
            //{
            //    idex = getClientId(),
            //    xj = XTCONSTS.KUANHAO_XINJIU.旧款,
            //    kuanhao = new TKuanhao
            //    {
            //        kuanhao = "",
            //        xingbie = (byte)DBCONSTS.KUANHAO_XB.女,
            //        leixing = (byte)DBCONSTS.KUANHAO_LX.衣服,
            //        pinming = "",
            //        beizhu = "",
            //        caozuorenid = LoginInfo.User.id
            //    },
            //    tms = new List<TTiaomaExtend>()
            //});
            addKuanhao(false);
        }

        private void addKuanhao(bool isNew)
        {
            TKuanhaoExtend tk = new TKuanhaoExtend
            {
                idex = getClientId(),
                xj = isNew ? XTCONSTS.KUANHAO_XINJIU.新款 : XTCONSTS.KUANHAO_XINJIU.旧款,
                kuanhao = new TKuanhao
                {
                    kuanhao = "",
                    xingbie = (byte)DBCONSTS.KUANHAO_XB.女,
                    leixing = (byte)DBCONSTS.KUANHAO_LX.衣服,
                    pinming = "",
                    beizhu = "",
                    caozuorenid = LoginInfo.User.id
                },
                tms = new List<TTiaomaExtend>()
            };
            TTiaomaExtend tt = new TTiaomaExtend
            {
                idex = getClientId(),
                shuliang = 1,
                xj = XTCONSTS.TIAOMA_XINJIU.新条码,
                tiaoma = new TTiaoma
                {
                    caozuorenid = LoginInfo.User.id,
                    charushijian = DateTime.Now,
                    chima = "",
                    gyskuanhao = "",
                    jinjia = 0,
                    shoujia = 0,
                    tiaoma = "",
                    xiugaishijian = DateTime.Now,
                    yanse = ""
                }
            };
            tk.tms.Add(tt);
            _khs.Add(tk);

            //addKuanhao(tk);
            addTiaomaAllMsg(tk, tt);
        }

        /// <summary>
        /// 编辑款号前，判断该款号是否允许被编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kuanhao_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //款号，都允许编辑
            //其他列只有新款允许编辑
            if (e.ColumnIndex != grid_kuanhao.Columns[col_kh_kh.Name].Index)
            {
                string xj = grid_kuanhao[col_kh_xj.Name, e.RowIndex].Value.ToString();
                if (xj.Equals(XTCONSTS.KUANHAO_XINJIU.旧款.ToString()))
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 显示款号一览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_khxx_Click(object sender, EventArgs e)
        {
            Dlg_Kuanhao dk = new Dlg_Kuanhao();
            dk.ShowDialog();
        }
        
        /// <summary>
        /// 确定编辑，如果是修改了旧款的款号，则加载款号信息和已有的条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kuanhao_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }

        /// <summary>
        /// 验证款号信息输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kuanhao_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //编辑值后，才需要验证，获得焦点，不用验证
            if (!grid_kuanhao.IsCurrentCellInEditMode)
            {
                return;
            }

            //验证是否重复
            if (grid_kuanhao.Columns[e.ColumnIndex].Name == col_kh_kh.Name)
            {
                if (e.FormattedValue != null)
                {
                    //输入的不是null，也不是空白，才需要验证
                    if (!string.IsNullOrEmpty(e.FormattedValue.ToString()))
                    {
                        foreach (DataGridViewRow dr in grid_kuanhao.Rows)
                        {
                            if (e.FormattedValue.Equals(dr.Cells[col_kh_kh.Name].Value) && e.RowIndex != dr.Index)
                            {
                                MessageBox.Show("款号重复");
                                e.Cancel = true;
                                return;
                            }
                        }
                    }
                }
            }

            //新款
            if (grid_kuanhao[col_kh_xj.Name, e.RowIndex].Value.Equals(XTCONSTS.KUANHAO_XINJIU.新款.ToString()))
            {
                //性别列只能输入男女或混合
                if (e.ColumnIndex == grid_kuanhao.Columns[col_kh_xb.Name].Index)
                {
                    if (!Enum.GetNames(typeof(DBCONSTS.KUANHAO_XB)).Contains(e.FormattedValue.ToString()))
                    {
                        MessageBox.Show("性别只可填写[" + Enum.GetNames(typeof(DBCONSTS.KUANHAO_XB)).Aggregate((a, b) => { return a + "," + b; }) + "]");
                        e.Cancel = true;
                    }
                }
                //类型列
                else if (e.ColumnIndex == grid_kuanhao.Columns[col_kh_lx.Name].Index)
                {
                    if (!Enum.GetNames(typeof(DBCONSTS.KUANHAO_LX)).Contains(e.FormattedValue.ToString()))
                    {
                        MessageBox.Show("类型只可填写[" + Enum.GetNames(typeof(DBCONSTS.KUANHAO_LX)).Aggregate((a, b) => { return a + "," + b; }) + "]");
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                
            }
        }

        /// <summary>
        /// 选中不同的款号行，加载其对应的条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kuanhao_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            grid_tiaoma.Rows.Clear();

            //if (grid_kuanhao[col_kh_tms.Name, e.RowIndex].Value == null)
            //{
 
            //}

            //加载条码信息
            TKuanhaoExtend kx = (TKuanhaoExtend)grid_kuanhao[col_kh_khex.Name, e.RowIndex].Value;
            List<TTiaomaExtend> ts = kx.tms;
            
            foreach(TTiaomaExtend t in ts)
            {
                addTiaoma(t);
            }
        }

        /// <summary>
        /// 在grid中增加一个条码
        /// </summary>
        /// <param name="t">条码信息</param>
        private void addTiaoma(TTiaomaExtend t)
        {
            grid_tiaoma.Rows.Add(new object[] 
            {
                t.idex,
                //t.khidex,
                t.xj.ToString(),
                t.tiaoma.tiaoma,
                t.tiaoma.gyskuanhao,
                t.tiaoma.yanse,
                t.tiaoma.chima,
                t.shuliang,
                t.tiaoma.jinjia,
                t.tiaoma.shoujia,
                t.tiaoma.caozuorenid,
                t.tiaoma.charushijian,
                t.tiaoma.xiugaishijian
            });
        }

        /// <summary>
        /// 选中整个行的时候才允许删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kuanhao_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!e.Row.Selected)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 行失去焦点时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kuanhao_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            //grid_kuanhao.Rows[e.RowIndex].ContextMenuStrip = null;
        }

        /// <summary>
        /// 加载某款号的已有条码模板信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_kh_loadTms_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = grid_kuanhao.SelectedRows[0];
            if (dr.Cells[col_kh_kh.Name].Value == null)
            {
                return;
            }

            string kh = dr.Cells[col_kh_kh.Name].Value.ToString();
            TTiaoma[] ts;
            try
            {
                ts = JCSJWCF.GetTiaomasByKuanhaoMc(kh);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            TKuanhaoExtend kx = (TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value;
            List<TTiaomaExtend> txs = kx.tms;
            foreach (TTiaoma t in ts)
            {
                t.tiaoma = "";
                t.id = 0;
                TTiaomaExtend tx = new TTiaomaExtend()
                {
                    idex = getClientId(),
                    //khidex = kx.idex,
                    xj = XTCONSTS.TIAOMA_XINJIU.新条码,
                    tiaoma = t,
                    shuliang = 0
                };

                kx.tms.Add(tx);
            }

            refreshTiaoma();
        }

        /// <summary>
        /// 行选中就给菜单，取消选中就不给菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kuanhao_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Selected)
            {
                e.Row.ContextMenuStrip = cmn_kh;
            }
            else
            {
                e.Row.ContextMenuStrip = null;
            }
        }

        /// <summary>
        /// 增加一个颜色尺码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_addsm_Click(object sender, EventArgs e)
        {
            //DataGridViewRow kdr = null;
            //if (grid_kuanhao.SelectedRows.Count != 0 )
            //{
            //    kdr = grid_kuanhao.SelectedRows[0];
            //}
            //else if(grid_kuanhao.SelectedCells.Count != 0)
            //{
            //    kdr = grid_kuanhao.SelectedCells[0].OwningRow;
            //}

            //if (kdr == null)
            //{
            //    MessageBox.Show("请先选中一行款号");
            //    return;
            //}

            //TTiaomaExtend tx;
            //TKuanhaoExtend kx = (TKuanhaoExtend)kdr.Cells[col_kh_khex.Name].Value;
            //List<TTiaomaExtend> ts = kx.tms;

            //if (ts.Count != 0)
            //{
            //    tx = (TTiaomaExtend)ts[ts.Count() - 1].Clone();
            //    tx.xj = XTCONSTS.TIAOMA_XINJIU.新条码;
            //    tx.idex = getClientId();
            //    tx.tiaoma.tiaoma = "";
            //    tx.tiaoma.caozuorenid = LoginInfo.User.id;
            //    tx.tiaoma.charushijian = DateTime.Now;
            //    tx.tiaoma.xiugaishijian = DateTime.Now;
            //}
            //else
            //{
            //    tx = new TTiaomaExtend()
            //    {
            //        idex = getClientId(),
            //        //khidex = kx.idex,
            //        xj = XTCONSTS.TIAOMA_XINJIU.新条码,
            //        tiaoma = new TTiaoma
            //        {
            //            kuanhaoid = kx.kuanhao.id,
            //            tiaoma = "",
            //            gyskuanhao = "",
            //            yanse = "",
            //            chima = "",
            //            jinjia = 0,
            //            shoujia = 0,
            //            caozuorenid = LoginInfo.User.id,
            //            charushijian = DateTime.Now,
            //            xiugaishijian = DateTime.Now
            //        },
            //        shuliang = 1
            //    };
            //}

            //ts.Add(tx);
            //addTiaoma(tx);

            if (_khs.Count() == 0)
            {
                MessageBox.Show("请先增加一个款号");
                return;
            }

            TKuanhaoExtend tk = _khs.Last();
            TTiaomaExtend tt = (TTiaomaExtend)tk.tms.Last().Clone();
            tt.xj = XTCONSTS.TIAOMA_XINJIU.新条码;
            tt.idex = getClientId();
            tt.tiaoma.tiaoma = "";
            tt.tiaoma.yanse = "";
            tt.tiaoma.chima = "";
            tt.tiaoma.caozuorenid = LoginInfo.User.id;
            tt.tiaoma.charushijian = DateTime.Now;
            tt.tiaoma.xiugaishijian = DateTime.Now;

            tk.tms.Add(tt);

            addTiaomaAllMsg(tk, tt);
        }

        /// <summary>
        /// 客户端ID自动发号
        /// </summary>
        /// <returns></returns>
        private int getClientId()
        {
            int id = _cid;
            //发号后自增
            _cid++;

            return id;
        }

        /// <summary>
        /// 不是整行选中不让删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_tiaoma_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!e.Row.Selected)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 把款号grid关联的条码信息也删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_tiaoma_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            int idex = (int)e.Row.Cells[col_tm_idex.Index].Value;
            //int khidex = (int)e.Row.Cells[col_tm_khidex.Index].Value;
            //从款号grid找到本条码所属的款号
            DataGridViewRow kdr = null;
            if (grid_kuanhao.SelectedRows.Count != 0)
            {
                kdr = grid_kuanhao.SelectedRows[0];
            }
            else if (grid_kuanhao.SelectedCells.Count != 0)
            {
                kdr = grid_kuanhao.SelectedCells[0].OwningRow;
            }
            TKuanhaoExtend drk = (TKuanhaoExtend)kdr.Cells[col_kh_khex.Name].Value;

            List<TTiaomaExtend> ts = drk.tms;
            TTiaomaExtend tdel = null;
            foreach (TTiaomaExtend tex in ts)
            {
                //找到条码
                if (tex.idex == idex)
                {
                    tdel = tex;
                    break;
                }
            }

            ts.Remove(tdel);
        }

        /// <summary>
        /// 旧条码不允许修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_tiaoma_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (grid_tiaoma[col_tm_xj.Name, e.RowIndex].Value.Equals(XTCONSTS.TIAOMA_XINJIU.旧条码.ToString()))
            {
                //旧条码的条码号不允许修改
                if (e.ColumnIndex == col_tm_tm.Index)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 刷新总计信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_all_shuaxin_Click(object sender, EventArgs e)
        {
            refreshGridAll();
        }

        /// <summary>
        /// 刷新合并信息
        /// </summary>
        private void refreshGridAll()
        {
            short count = 0;
            grid_all.Rows.Clear();
            foreach (DataGridViewRow dr in grid_kuanhao.Rows)
            {
                TKuanhaoExtend kex = (TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value;

                List<TTiaomaExtend> ts = kex.tms;
                foreach (TTiaomaExtend tex in ts)
                {
                    addTiaomaAllMsg(kex,tex);
                    count++;
                }
            }
            //加一个合计行
            int i = grid_all.Rows.Add(new object[] { });
            grid_all.Rows[i].Cells[col_all_kh.Name].Value = "合计";
            grid_all.Rows[i].Cells[col_all_sl.Name].Value = count;
            grid_all.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
            
        }

        /// <summary>
        /// 自动生成款号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_sckh_Click(object sender, EventArgs e)
        {
            string AB = Tool.CommonFunc.Year_month_to_AB(Settings.Default.STARTYEAR);

            //foreach (DataGridViewRow dr in grid_kuanhao.Rows)
            //{
            //    //旧款不用编号
            //    if (XTCONSTS.KUANHAO_XINJIU.旧款.ToString().Equals(dr.Cells[col_kh_xj.Name].Value.ToString()))
            //    {
            //        continue;
            //    }

            //    //空白的才发番，不是空白的留给用户手动命名
            //    string kh = (string)dr.Cells[col_kh_kh.Name].Value;
            //    if (string.IsNullOrEmpty(kh) || string.IsNullOrWhiteSpace(kh))
            //    {
            //        string NUM = Tool.CommonFunc.GetRandomNum(Settings.Default.KH_NUM_LEN);
            //        ((TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value).kuanhao.kuanhao = AB + NUM;
            //    }
            //}

            foreach (TKuanhaoExtend tk in _khs)
            {
                if (tk.xj == XTCONSTS.KUANHAO_XINJIU.旧款)
                {
                    continue;
                }

                //空白的才发番，不是空白的留给用户手动命名
                if (string.IsNullOrEmpty(tk.kuanhao.kuanhao) || string.IsNullOrWhiteSpace(tk.kuanhao.kuanhao))
                {
                    string NUM = Tool.CommonFunc.GetRandomNum(Settings.Default.KH_NUM_LEN);
                    tk.kuanhao.kuanhao = AB + NUM;
                }
            }        

            refreshKuanhao();
        }

        /// <summary>
        /// 检查发番的款号是否已经存在
        /// </summary>
        /// <param name="nkh"></param>
        /// <returns></returns>
        private bool kuanhaoExists(string nkh)
        {
            foreach (DataGridViewRow dr in grid_kuanhao.Rows)
            {
                if (nkh.Equals(dr.Cells[col_kh_kh.Name].Value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 更新对应的条码的款号信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kuanhao_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            string kh = (string)grid_kuanhao[col_kh_kh.Name, e.RowIndex].Value;
            TKuanhaoExtend kex = (TKuanhaoExtend)grid_kuanhao.Rows[e.RowIndex].Cells[col_kh_khex.Name].Value;
            //修改的是款号
            if (e.ColumnIndex == col_kh_kh.Index)
            {
                //如果是旧款，从服务器加载款号信息
                if (grid_kuanhao[col_kh_xj.Name, e.RowIndex].Value.Equals(XTCONSTS.KUANHAO_XINJIU.旧款.ToString()))
                {
                    //如果输入了空白，不做处理
                    if (!string.IsNullOrEmpty(kh) && !string.IsNullOrWhiteSpace(kh))
                    {
                        ;
                        TKuanhao k;
                        try
                        {
                            k = JCSJWCF.GetKuanhaoByMc(kh);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }

                        if (k == null)
                        {
                            _kuanhaoOK = false;
                            MessageBox.Show("不存在该款号");
                            grid_kuanhao.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                        }
                        else
                        {
                            //只有当前行验证通过，不能将全局都标示为OK
                            //_kuanhaoOK = true;
                            grid_kuanhao.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                            kex.kuanhao = k;
                            List<TTiaomaExtend> tms = kex.tms;
                            tms.ForEach(r => r.tiaoma.kuanhaoid = k.id);
                        }
                    }
                    //输入了空白，验证也算不通过
                    else
                    {
                        _kuanhaoOK = false;
                    }
                }
            }

            kex.kuanhao.kuanhao = kh;
            kex.kuanhao.xingbie = (byte)Enum.Parse(typeof(DBCONSTS.KUANHAO_XB), (string)grid_kuanhao[col_kh_xb.Name, e.RowIndex].Value);
            kex.kuanhao.leixing = (byte)Enum.Parse(typeof(DBCONSTS.KUANHAO_LX), (string)grid_kuanhao[col_kh_lx.Name, e.RowIndex].Value);
            kex.kuanhao.pinming = (string)grid_kuanhao[col_kh_pm.Name, e.RowIndex].Value;
        }

        /// <summary>
        /// 自动生成条码
        /// 当前的年月日+自动发号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_sctm_Click(object sender, EventArgs e)
        {
            string AB = Tool.CommonFunc.Year_month_to_AB(Settings.Default.STARTYEAR);

            //foreach (DataGridViewRow dr in grid_kuanhao.Rows)
            //{
            //    List<TTiaomaExtend> ts = ((TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value).tms;
            //    foreach (TTiaomaExtend t in ts)
            //    {
            //        //空白的才发番，不是空白的留给用户手动命名
            //        string tm = t.tiaoma.tiaoma;
            //        if (string.IsNullOrEmpty(tm) || string.IsNullOrWhiteSpace(tm))
            //        {
            //            string NUM = Tool.CommonFunc.GetRandomNum(Settings.Default.TM_NUM_LEN);
            //            t.tiaoma.tiaoma = Settings.Default.TM_START_CHAR + AB + NUM;
            //        }
            //    }
            //}

            foreach (TKuanhaoExtend tk in _khs)
            {
                foreach (TTiaomaExtend tt in tk.tms)
                {
                    if (tt.xj == XTCONSTS.TIAOMA_XINJIU.新条码)
                    {
                        //空白的才发番，不是空白的留给用户手动命名
                        string tm = tt.tiaoma.tiaoma;
                        if (string.IsNullOrEmpty(tm) || string.IsNullOrWhiteSpace(tm))
                        {
                            string NUM = Tool.CommonFunc.GetRandomNum(Settings.Default.TM_NUM_LEN);
                            tt.tiaoma.tiaoma = Settings.Default.TM_START_CHAR + AB + NUM;
                        }
                    }
                }
            }        

            refreshTiaoma();
        }

        /// <summary>
        /// 刷新条码grid显示信息
        /// </summary>
        private void refreshTiaoma()
        {
            //grid_tiaoma.Rows.Clear();
            //List<TTiaomaExtend> ts=null;
            //if (grid_kuanhao.SelectedRows.Count != 0)
            //{
            //    ts = ((TKuanhaoExtend)grid_kuanhao.SelectedRows[0].Cells[col_kh_khex.Name].Value).tms;
            //}
            //else if (grid_kuanhao.SelectedCells.Count != 0)
            //{
            //    ts = ((TKuanhaoExtend)grid_kuanhao.SelectedCells[0].OwningRow.Cells[col_kh_khex.Name].Value).tms;
            //}

            //if (ts == null)
            //{
            //    return;
            //}

            //foreach (TTiaomaExtend t in ts)
            //{
            //    addTiaoma(t);
            //}

            foreach (DataGridViewRow dr in grid_all.Rows)
            {
                int khidex = (int)dr.Cells[col_all_khidex.Name].Value;
                int tmidex = (int)dr.Cells[col_all_tmidex.Name].Value;

                TKuanhaoExtend tk = _khs.Single(r => r.idex == khidex);
                TTiaomaExtend tt = tk.tms.Single(r => r.idex == tmidex);

                dr.Cells[col_all_tm.Name].Value = tt.tiaoma.tiaoma;
            }
        }

        /// <summary>
        /// 检查条码是否在客户端重复
        /// </summary>
        /// <param name="ntm"></param>
        /// <returns></returns>
        private bool tiaomaExists(string ntm)
        {
            foreach (DataGridViewRow dr in grid_kuanhao.Rows)
            {
                List<TTiaomaExtend> ts = ((TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value).tms;
                foreach (TTiaomaExtend t in ts)
                {
                    if (ntm == t.tiaoma.tiaoma)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 修改条码信息后，更新款号grid中相关的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_tiaoma_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            int idex = (int)grid_tiaoma[col_tm_idex.Name, e.RowIndex].Value;
            DataGridViewRow kdr = null;
            if (grid_kuanhao.SelectedRows.Count != 0)
            {
                kdr = grid_kuanhao.SelectedRows[0];
            }
            else if (grid_kuanhao.SelectedCells.Count != 0)
            {
                kdr = grid_kuanhao.SelectedCells[0].OwningRow;
            }
            TKuanhaoExtend drk = (TKuanhaoExtend)kdr.Cells[col_kh_khex.Name].Value;
            List<TTiaomaExtend> ts = drk.tms;

            //从款号grid找到本条码所属的款号
            TTiaomaExtend t = ts.Single(r => r.idex == idex);

            //条码
            t.tiaoma.tiaoma = (string)grid_tiaoma[col_tm_tm.Name, e.RowIndex].Value;
            //供应商款号
            t.tiaoma.gyskuanhao = (string)grid_tiaoma[col_tm_gyskh.Name, e.RowIndex].Value;
            //颜色
            t.tiaoma.yanse = (string)grid_tiaoma[col_tm_ys.Name, e.RowIndex].Value;
            //尺码
            t.tiaoma.chima = (string)grid_tiaoma[col_tm_cm.Name, e.RowIndex].Value;
            //数量
            t.shuliang = short.Parse(grid_tiaoma[col_tm_sl.Name, e.RowIndex].Value.ToString());
            //进价
            t.tiaoma.jinjia = decimal.Parse(grid_tiaoma[col_tm_jj.Name, e.RowIndex].Value.ToString());
            //售价
            t.tiaoma.shoujia = decimal.Parse(grid_tiaoma[col_tm_sj.Name, e.RowIndex].Value.ToString());
        }

        /// <summary>
        /// 到服务器检查新款号是否已经存在
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_jckh_Click(object sender, EventArgs e)
        {
            List<string> nkhs = new List<string>();
            List<string> okhs = new List<string>();
            foreach (TKuanhaoExtend tk in _khs)
            {
                string kh = tk.kuanhao.kuanhao;
                if (string.IsNullOrEmpty(kh) || string.IsNullOrWhiteSpace(kh))
                {
                    _kuanhaoOK = false;
                    MessageBox.Show("款号不能为空白");
                    return;
                }
                //检查新款号
                if (tk.xj == XTCONSTS.KUANHAO_XINJIU.新款)
                {
                    //款号符合固定格式
                    if (!Tool.CommonFunc.CheckFormat_KH(kh))
                    {
                        _kuanhaoOK = false;
                        MessageBox.Show("款号格式非法");
                        return;
                    }

                    //检查款号是否没有条码信息
                    //if (((TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value).tms.Count == 0)
                    //{
                    //    _kuanhaoOK = false;
                    //    MessageBox.Show("款号没有条码信息");
                    //    return;
                    //}

                    //品名是否是空白
                    string pm = tk.kuanhao.pinming;
                   
                    if (string.IsNullOrEmpty(pm) || string.IsNullOrWhiteSpace(pm))
                    {
                        _kuanhaoOK = false;
                        MessageBox.Show("品名不能为空白");
                        return;
                    }

                    nkhs.Add(kh);
                }
            }

            //去服务器验证新款号
            if (nkhs.Count() > 0)
            {
                string[] eKhs;
                try
                {
                    eKhs = JCSJWCF.CheckKuanhaosChongfu(nkhs.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                if (eKhs.Length != 0)
                {
                    _kuanhaoOK = false;
                    //refreshGridAll();
                    foreach (string k in eKhs)
                    {
                        foreach (DataGridViewRow dr in grid_all.Rows)
                        {
                            if(k.Equals(dr.Cells[col_all_kh.Name].Value))
                            {
                                dr.DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                    }
                    MessageBox.Show("款号有重复");
                }
                else
                {
                    _kuanhaoOK = true;
                    MessageBox.Show("款号检查通过");
                }
            }
        }

        /// <summary>
        /// 选中最下方的grid，联动款号grid和条码grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_all_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 选中款号，加载条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kuanhao_SelectionChanged(object sender, EventArgs e)
        {
            if (grid_kuanhao.SelectedRows.Count == 0)
            {
                return;
            }

            refreshTiaoma();
        }

        /// <summary>
        /// 检查条码信息，和条码是否重复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_jctm_Click(object sender, EventArgs e)
        {
            List<string> tms = new List<string>();
            foreach (TKuanhaoExtend tk in _khs)
            {
                List<TTiaomaExtend> ts = tk.tms;
                //新条码号才需要验证
                foreach (TTiaomaExtend t in ts)
                {
                    if (string.IsNullOrEmpty(t.tiaoma.tiaoma) || string.IsNullOrWhiteSpace(t.tiaoma.tiaoma))
                    {
                        MessageBox.Show("条码不能空白");
                        return;
                    }

                    if (t.xj == XTCONSTS.TIAOMA_XINJIU.新条码)
                    {
                        //条码符合固定格式
                        if (!Tool.CommonFunc.CheckFormat_TM(t.tiaoma.tiaoma))
                        {
                            MessageBox.Show("条码格式非法");
                            return;
                        }

                        if (string.IsNullOrEmpty(t.tiaoma.yanse) || string.IsNullOrWhiteSpace(t.tiaoma.yanse))
                        {
                            MessageBox.Show("颜色不能空白");
                            return;
                        }

                        if (string.IsNullOrEmpty(t.tiaoma.chima) || string.IsNullOrWhiteSpace(t.tiaoma.chima))
                        {
                            MessageBox.Show("尺码不能空白");
                            return;
                        }

                        if (t.tiaoma.jinjia == 0 || t.tiaoma.shoujia == 0)
                        {
                            MessageBox.Show("价格不能为0");
                            return;
                        }

                        tms.Add(t.tiaoma.tiaoma);
                    }
                }               

                    //同一个款号内，不能有同色同码的
                if (tk.tms.DistinctBy(r => new { r.tiaoma.yanse, r.tiaoma.chima }).Count() != tk.tms.Count())
                {
                    MessageBox.Show("同一个款号内，不能有同色同码的");
                    return;
                }
            }

            if (tms.Count > 0)
            {
                string[] eTms;
                try
                {
                    eTms = JCSJWCF.CheckTiaomaChongfu(tms.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                refreshGridAll();
                if (eTms.Length > 0)
                {
                    _tiaomaOK = false;                    
                    foreach (string k in eTms)
                    {
                        foreach (DataGridViewRow dr in grid_all.Rows)
                        {
                            if (k.Equals(dr.Cells[col_all_tm.Name].Value))
                            {
                                dr.DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                    }
                    MessageBox.Show("条码有重复");

                }
                else
                {
                    _tiaomaOK = true;
                    MessageBox.Show("条码检查通过");
                }
            }
        }
        

        /// <summary>
        /// 检查条码信息输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_tiaoma_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //不在编辑状态，不用验证
            if (!grid_tiaoma.IsCurrentCellInEditMode)
            {
                return;
            }

            //条码
            if (grid_tiaoma.Columns[e.ColumnIndex].Equals(col_tm_tm))
            {
                if (!string.IsNullOrEmpty((string)e.FormattedValue) && !string.IsNullOrWhiteSpace((string)e.FormattedValue))
                {
                    //检查是否重复
                    if (tiaomaExists((string)e.FormattedValue))
                    {
                        MessageBox.Show("条码重复");
                        e.Cancel = true;
                    }
                }
            }

            //数量
            else if (grid_tiaoma.Columns[e.ColumnIndex].Equals(col_tm_sl))
            {
                short sl = 0;
                if (!short.TryParse((string)e.FormattedValue, out sl))
                {
                    MessageBox.Show("数量必须是数字");
                    e.Cancel = true;
                }
            }
            //进价
            else if (grid_tiaoma.Columns[e.ColumnIndex].Equals(col_tm_jj))
            {
                decimal jj = 0;
                if (!decimal.TryParse((string)e.FormattedValue, out jj))
                {
                    MessageBox.Show("进价必须是数字");
                    e.Cancel = true;
                }
            }
            //售价
            else if (grid_tiaoma.Columns[e.ColumnIndex].Equals(col_tm_sj))
            {
                decimal sj = 0;
                if (!decimal.TryParse((string)e.FormattedValue, out sj))
                {
                    MessageBox.Show("售价必须是数字");
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 将款号和条码信息保存到本地xml文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Bianma_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<TTiaomaExtend> ts = new List<TTiaomaExtend>();
            
        }

        /// <summary>
        /// 双击合并grid信息，款号grid响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_all_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid_all.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow dr = grid_all.SelectedRows[0];
            int khidex = (int)dr.Cells[col_all_khidex.Name].Value;
            grid_kuanhao.ClearSelection();
            foreach (DataGridViewRow kdr in grid_kuanhao.Rows)
            {
                if ((int)kdr.Cells[col_kh_idex.Name].Value == khidex)
                {
                    kdr.Selected = true;
                    break;
                }
            }

        }

        /// <summary>
        /// 保存到服务器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_saveServer_Click(object sender, EventArgs e)
        {
            //保存款号
            if (_kuanhaoOK)
            {
                List<TKuanhao> ks = new List<TKuanhao>();
                //取得所有新款号
                foreach (TKuanhaoExtend tk in _khs)
                {
                    //TKuanhaoExtend tex = (TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value;
                    if (tk.xj == XTCONSTS.KUANHAO_XINJIU.新款)
                    {
                        ks.Add(tk.kuanhao);
                    }
                }

                if (ks.Count != 0)
                {
                    TKuanhao[] nks = null;
                    try
                    {
                        nks = JCSJWCF.SaveKuanhaos(ks.ToArray());
                    }
                    catch (Exception ex)
                    {
                        _kuanhaoOK = false;
                        MessageBox.Show("款号保存失败\r\n" + ex.Message);
                        return;
                    }

                    //用返回结果更新本地数据
                    foreach (TKuanhaoExtend tk in _khs)
                    {
                        //因为_khs中可能有旧款号，但是nks中全是新款号，所以用SingleOrDefault
                        TKuanhao k = nks.SingleOrDefault(r => r.kuanhao == tk.kuanhao.kuanhao);
                        if (k != null)
                        {
                            tk.xj = XTCONSTS.KUANHAO_XINJIU.旧款;
                            tk.kuanhao.id = k.id;
                            tk.tms.ForEach(r => r.tiaoma.kuanhaoid = k.id);
                        }
                        //foreach (TKuanhao k in nks)
                        //{
                        //    if (kex.kuanhao.kuanhao == k.kuanhao)
                        //    {
                        //        kex.xj = XTCONSTS.KUANHAO_XINJIU.旧款;
                        //        kex.kuanhao = k;
                        //        texs.ForEach(r => r.tiaoma.kuanhaoid = k.id);
                        //    }
                        //}
                    }

                    //刷新款号显示
                    //refreshKuanhao();
                }
            }
            else
            {
                MessageBox.Show("款号检查未通过，请先修改款号信息");
                return;
            }

            //保存条码信息
            if (_tiaomaOK)
            {
                List<TTiaoma> ts = new List<TTiaoma>();
                //取得所有新条码
                foreach (TKuanhaoExtend tk in _khs)
                {
                    //TKuanhaoExtend kex = (TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value;
                    //List<TTiaomaExtend> texs = kex.tms;
                    foreach (TTiaomaExtend tex in tk.tms)
                    {
                        if (tex.xj == XTCONSTS.TIAOMA_XINJIU.新条码)
                        {
                            ts.Add(tex.tiaoma);
                        }
                    }
                }

                if (ts.Count != 0)
                {
                    TTiaoma[] nts = null;
                    try
                    {
                        nts = JCSJWCF.SaveTiaomas(ts.ToArray());
                    }
                    catch (Exception ex)
                    {
                        _tiaomaOK = false;
                        MessageBox.Show("条码保存失败\r\n" + ex.Message);
                        return;
                    }
                    //用返回结果更新本地数据
                    foreach (TKuanhaoExtend tk in _khs)
                    {
                        //List<TTiaomaExtend> texs = ((TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value).tms;
                        foreach (TTiaomaExtend tex in tk.tms)
                        {
                            //因为tk.tms中可能有旧条码，但是nts中全是新条码，所以用SingleOrDefault
                            TTiaoma t =nts.SingleOrDefault(r => r.tiaoma == tex.tiaoma.tiaoma);
                            if (t != null)
                            {
                                tex.xj = XTCONSTS.TIAOMA_XINJIU.旧条码;
                                tex.tiaoma.id = t.id;
                            }
                        }
                    }
                    //刷新款号显示
                    //refreshTiaoma();
                }
            }
            else
            {
                MessageBox.Show("条码检查未通过，请先修改款号信息");
                return; 
            }

            //刷新新旧，保存后，所有的都变成旧款号，旧条码
            foreach (DataGridViewRow dr in grid_all.Rows)
            {
                dr.Cells[col_all_khxj.Name].Value = XTCONSTS.KUANHAO_XINJIU.旧款.ToString();
                dr.Cells[col_all_tmxj.Name].Value = XTCONSTS.TIAOMA_XINJIU.旧条码.ToString();
            }
        }

        /// <summary>
        /// 保存旧条码的修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_tm_xg_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = grid_tiaoma.SelectedRows[0];
            if (dr.Cells[col_tm_xj.Name].Value.Equals(XTCONSTS.TIAOMA_XINJIU.新条码.ToString()))
            {
                MessageBox.Show("对新条码无效");
                return;
            }
            int idex = (int)dr.Cells[col_tm_idex.Name].Value;

            DataGridViewRow kdr = null;
            if (grid_kuanhao.SelectedRows.Count != 0)
            {
                kdr = grid_kuanhao.SelectedRows[0];
            }
            else if (grid_kuanhao.SelectedCells.Count != 0)
            {
                kdr = grid_kuanhao.SelectedCells[0].OwningRow;
            }

            TKuanhaoExtend kex = (TKuanhaoExtend)kdr.Cells[col_kh_khex.Name].Value;
            TTiaoma t = null;
            foreach (TTiaomaExtend tex in kex.tms)
            {
                if (tex.idex == idex)
                {
                    t = tex.tiaoma;
                    break;
                }
            }
            try
            {
                JCSJWCF.EditTiaoma(t);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            MessageBox.Show("修改成功");
        }

        /// <summary>
        /// 款号的键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kuanhao_KeyDown(object sender, KeyEventArgs e)
        {
            //在整行选中的情况下才触发
            if (grid_kuanhao.SelectedRows.Count == 1)
            {
                //粘贴剪切的条码
                if (e.Control && e.KeyCode == Keys.V)
                {
                    //找到该条码的实例
                    TTiaomaExtend ot = null;
                    foreach (DataGridViewRow dr in grid_kuanhao.Rows)
                    {
                        TKuanhaoExtend kex = (TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value;
                        List<TTiaomaExtend> tms = kex.tms;
                        foreach (TTiaomaExtend tex in tms)
                        {
                            if (tex.idex == _tmidex)
                            {
                                ot = tex;
                                break;
                            }
                        }
                        if (ot != null)
                        {
                            TKuanhaoExtend nkex = (TKuanhaoExtend)grid_kuanhao.SelectedRows[0].Cells[col_kh_khex.Name].Value;
                            ot.tiaoma.kuanhaoid = nkex.kuanhao.id;
                            nkex.tms.Add(ot);
                            tms.Remove(ot);
                            _tmidex = 0;
                            break;
                        }
                    }
                    refreshTiaoma();
                }
            }
            //方向键事件
            else
            {
                //如果到了最右边
                if (e.KeyCode == Keys.Right)
                {
                    if (grid_kuanhao.SelectedCells.Count == 1)
                    {
                        if (grid_kuanhao.SelectedCells[0].ColumnIndex == col_kh_pm.Index)
                        {
                            if (grid_tiaoma.Rows.Count > 0)
                            {
                                grid_tiaoma.Focus();
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// 条码grid键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_tiaoma_KeyDown(object sender, KeyEventArgs e)
        {
            //在整行选中的情况下才触发
            if (grid_tiaoma.SelectedRows.Count == 1)
            {
                //剪切条码
                if (e.Control && e.KeyCode == Keys.X)
                {
                    //旧条码不允许剪切，因为剪切会修改款号
                    if (XTCONSTS.TIAOMA_XINJIU.旧条码.ToString().Equals(grid_tiaoma.SelectedRows[0].Cells[col_tm_idex.Name].Value))
                    {
                        _tmidex = (int)grid_tiaoma.SelectedRows[0].Cells[col_tm_idex.Name].Value;
                    }
                    else
                    {
                        MessageBox.Show("旧条码不允许剪切");
                    }
                }
            }
            //在单元格选择模式下触发
            else
            {
                //粘贴
                if (e.Control && e.KeyCode == Keys.V)
                {
                    foreach (DataGridViewCell dc in grid_tiaoma.SelectedCells)
                    {
                        //只读和条码列不允许粘贴
                        if (!dc.ReadOnly && dc.ColumnIndex != col_tm_tm.Index)
                        {
                            dc.Value = Clipboard.GetData(DataFormats.Text);
                        }
                    }
                }
                //向左，跨到款号grid
                else if (e.KeyCode == Keys.Left)
                {
                    //如果到了最左边
                    if (grid_tiaoma.SelectedCells.Count == 1)
                    {
                        if (grid_tiaoma.SelectedCells[0].ColumnIndex == col_tm_xj.Index)
                        {
                            grid_kuanhao.Focus();
                            //将焦点行移动到最上面
                            //grid_kuanhao.FirstDisplayedScrollingRowIndex = grid_kuanhao.SelectedCells[0].RowIndex;
                        }
                    }
                }
            }
        }
    

        /// <summary>
        /// 设置右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_tiaoma_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.Row.Selected)
            {
                e.Row.ContextMenuStrip = cmn_tm;
            }
            else
            {
                e.Row.ContextMenuStrip = null;
            }
        }

        /// <summary>
        /// 根据进价乘以系数，将结果小数去掉，位数改成9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_jssj_Click(object sender, EventArgs e)
        {
            decimal x;
            if (!decimal.TryParse(txb_sjxs.Text.Trim(), out x))
            {
                MessageBox.Show("系数必须是数字");
                return;
            }

            //foreach (DataGridViewRow dr in grid_kuanhao.Rows)
            //{
            //    TKuanhaoExtend kex = (TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value;
            //    foreach (TTiaomaExtend tex in kex.tms)
            //    {
            //        if (tex.xj == XTCONSTS.TIAOMA_XINJIU.新条码)
            //        {
            //            decimal sj = tex.tiaoma.jinjia * x;
            //            tex.tiaoma.shoujia = sj;
            //        }
            //    }
            //}

            foreach (TKuanhaoExtend tk in _khs)
            {
                foreach (TTiaomaExtend tt in tk.tms)
                {
                    if (tt.xj == XTCONSTS.TIAOMA_XINJIU.新条码)
                    {
                        tt.tiaoma.shoujia = tt.tiaoma.jinjia * x;
                    }
                }
            }

            //refreshTiaoma();

            refreshShoujia();
        }

        /// <summary>
        /// 刷新售价
        /// </summary>
        private void refreshShoujia()
        {
            foreach (DataGridViewRow dr in grid_all.Rows)
            {
                int khidex = (int)dr.Cells[col_all_khidex.Name].Value;
                int tmidex = (int)dr.Cells[col_all_tmidex.Name].Value;

                TKuanhaoExtend tk = _khs.Single(r => r.idex == khidex);
                TTiaomaExtend tt = tk.tms.Single(r => r.idex == tmidex);

                dr.Cells[col_all_sj.Name].Value = tt.tiaoma.shoujia;
            }
        }

        /// <summary>
        /// 保存数据到本地
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_saveLoacal_Click(object sender, EventArgs e)
        {
            localSave();           
        }

        /// <summary>
        /// 把当前的表格保存到本地
        /// </summary>
        private void localSave()
        {
            XElement doc = new XElement("Data");
            foreach (TKuanhaoExtend tk in _khs)
            {
                //TKuanhaoExtend kex = (TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value;
                XElement Nkex = tk.ToXml();
                foreach (TTiaomaExtend tex in tk.tms)
                {
                    Nkex.Add(tex.ToXml());
                }
                doc.Add(tk.ToXml());
            }

            doc.Save(Settings.Default.DUMPFILENAME);
        }

        /// <summary>
        /// 从本地XML加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_jiazai_bendi_Click(object sender, EventArgs e)
        {
            //如果已经在grid中添加了款号，则不允许再从本地加载，因为发番的客户端id有可能重复
            if (grid_kuanhao.Rows.Count > 0)
            {
                MessageBox.Show("已经有数据，无法再从本地加载");
                return;
            }

            TKuanhaoExtend[] kexs = TKuanhaoExtend.FromXml(Settings.Default.DUMPFILENAME);
            foreach (TKuanhaoExtend kex in kexs)
            {
                //addKuanhao(kex);
                foreach (TTiaomaExtend tt in kex.tms)
                {
                    addTiaomaAllMsg(kex, tt);
                }
            }

            //加载完后，出示一下本地的发番ID
            int kmax = kexs.Max(r => r.idex);
            int tmax = kexs.SelectMany(r => r.tms).Max(r => (int?)r.idex) ?? 0;
            _cid = (kmax > tmax ? kmax : tmax) + 1;
        }

        /// <summary>
        /// 快捷键，保存到本地
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Bianma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                localSave();
            }
        }

        /// <summary>
        /// 导出成标签打印需要的格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_dyexcel_Click(object sender, EventArgs e)
        {
            string bq = "";
            //表头
            bq += "序号,条码,款号,品名,颜色,尺码,售价\r\n";
            int i = 1;
            foreach (DataGridViewRow dr in grid_kuanhao.Rows)
            {
                TKuanhaoExtend kex = (TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value;
                List<TTiaomaExtend> tms = kex.tms;
                if (tms.Count == 0)
                {
                    continue;
                }
                foreach (TTiaomaExtend tex in tms)
                {
                    int sl = tex.shuliang;
                    if (sl == 0)
                    {
                        break;
                    }
                    while ( sl != 0)
                    {
                        bq += i + ",";
                        bq += tex.tiaoma.tiaoma + ",";
                        bq += kex.kuanhao.kuanhao + ",";
                        bq += kex.kuanhao.pinming + ",";
                        bq += tex.tiaoma.yanse + ",";
                        bq += tex.tiaoma.chima + ",";
                        bq += tex.tiaoma.shoujia + "\r\n";

                        sl--;
                    }
                    i++;
                }
            }

            SaveFileDialog sdlg = new SaveFileDialog();
            if (sdlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(sdlg.FileName, bq, Encoding.Default);
            }
        }

        /// <summary>
        /// 修改款号，条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_all_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            //合计行，跳过
            if (grid_all.Rows[e.RowIndex].Cells[col_all_khidex.Name].Value == null)
            {
                return;
            }

            int khidex = int.Parse(grid_all[col_all_khidex.Index, e.RowIndex].Value.ToString());
            int tmidex = int.Parse(grid_all[col_all_tmidex.Index, e.RowIndex].Value.ToString());
            TKuanhaoExtend tk = _khs.Single(r => r.idex == khidex);
            TTiaomaExtend tt = tk.tms.Single(r => r.idex == tmidex);

            string kh = (string)grid_all[col_all_kh.Name, e.RowIndex].Value;
            XTCONSTS.KUANHAO_XINJIU khxj = (XTCONSTS.KUANHAO_XINJIU)Enum.Parse(typeof(XTCONSTS.KUANHAO_XINJIU), grid_all[col_all_khxj.Name, e.RowIndex].Value.ToString());
            DBCONSTS.KUANHAO_XB xb = (DBCONSTS.KUANHAO_XB)Enum.Parse(typeof(DBCONSTS.KUANHAO_XB), grid_all[col_all_xb.Name, e.RowIndex].Value.ToString());
            DBCONSTS.KUANHAO_LX lx = (DBCONSTS.KUANHAO_LX)Enum.Parse(typeof(DBCONSTS.KUANHAO_LX), grid_all[col_all_lx.Name, e.RowIndex].Value.ToString());
            string pm = (string)grid_all[col_all_pm.Name, e.RowIndex].Value;
            string tm = (string)grid_all[col_all_tm.Name, e.RowIndex].Value;
            XTCONSTS.TIAOMA_XINJIU tmxj = (XTCONSTS.TIAOMA_XINJIU)Enum.Parse(typeof(XTCONSTS.TIAOMA_XINJIU), grid_all[col_all_tmxj.Name, e.RowIndex].Value.ToString());
            string gyskh = (string)grid_all[col_all_gyskh.Name, e.RowIndex].Value;
            string ys = (string)grid_all[col_all_ys.Name, e.RowIndex].Value;
            string cm = (string)grid_all[col_all_cm.Name, e.RowIndex].Value;
            decimal jj = decimal.Parse(grid_all[col_all_jj.Name, e.RowIndex].Value.ToString());
            decimal sj = decimal.Parse(grid_all[col_all_sj.Name, e.RowIndex].Value.ToString());

            //修改的是款号
            if (e.ColumnIndex == col_all_kh.Index)
            {
                ////如果是旧款，从服务器加载款号信息
                //if (grid_all[col_all_khxj.Name, e.RowIndex].Value.Equals(XTCONSTS.KUANHAO_XINJIU.旧款.ToString()))
                //{
                //    if (!string.IsNullOrEmpty(kh) && !string.IsNullOrWhiteSpace(kh))
                //    {
                //        TKuanhao k;
                //        try
                //        {
                //            k = JCSJWCF.GetKuanhaoByMc(kh);
                //        }
                //        catch (Exception ex)
                //        {
                //            MessageBox.Show(ex.Message);
                //            return;
                //        }

                //        if (k == null)
                //        {
                //            _kuanhaoOK = false;
                //            MessageBox.Show("不存在该款号");
                //            //grid_all.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                //        }
                //        else
                //        {
                //            //只有当前行验证通过，不能将全局都标示为OK
                //            //_kuanhaoOK = true;
                //            //grid_kuanhao.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                //            tk.kuanhao = k;
                //            //List<TTiaomaExtend> tms = tk.tms;
                //            tk.tms.ForEach(r => r.tiaoma.kuanhaoid = k.id);
                //        }
                //    }
                //    //输入了空白，验证也算不通过
                //    else
                //    {
                //        _kuanhaoOK = false;
                //        tk.kuanhao.id = 0;
                //        tk.kuanhao.kuanhao = "";
                //        tk.kuanhao.pinming = "";
                //        tk.tms.ForEach(r => r.tiaoma.kuanhaoid = 0);
                //    }

                tk.kuanhao.kuanhao = kh;
                if (khxj == XTCONSTS.KUANHAO_XINJIU.旧款)
                {
                    tk.kuanhao.id = 0;
                    tk.kuanhao.pinming = "";
                    tk.tms.ForEach(r => r.tiaoma.kuanhaoid = 0);
                }
            }
            else if (e.ColumnIndex == col_all_xb.Index)
            {
                tk.kuanhao.xingbie = (byte)xb;
            }
            else if (e.ColumnIndex == col_all_lx.Index)
            {
                tk.kuanhao.leixing = (byte)lx;
            }
            else if (e.ColumnIndex == col_all_pm.Index)
            {
                tk.kuanhao.pinming = pm;
            }
            else if (e.ColumnIndex == col_all_tm.Index)
            {
                tt.tiaoma.tiaoma = tm;
            }
            else if (e.ColumnIndex == col_all_gyskh.Index)
            {
                tt.tiaoma.gyskuanhao = gyskh;
            }
            else if (e.ColumnIndex == col_all_ys.Index)
            {
                tt.tiaoma.yanse = ys;
            }
            else if (e.ColumnIndex == col_all_cm.Index)
            {
                tt.tiaoma.chima = cm;
            }
            else if (e.ColumnIndex == col_all_jj.Index)
            {
                tt.tiaoma.jinjia = jj;
            }
            else if (e.ColumnIndex == col_all_sj.Index)
            {
                tt.tiaoma.shoujia = sj;
            }
        }

        /// <summary>
        /// 删除一个条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_all_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!e.Row.Selected)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 开始编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_all_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //款号，都允许编辑
            //其他列只有新款允许编辑
            if (e.ColumnIndex != grid_all.Columns[col_all_kh.Name].Index)
            {
                string xj = grid_all[col_all_khxj.Name, e.RowIndex].Value.ToString();
                if (xj.Equals(XTCONSTS.KUANHAO_XINJIU.旧款.ToString()))
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 结束编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_all_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 输入合法性检查
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_all_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //不在编辑状态，不用验证
            if (!grid_all.IsCurrentCellInEditMode)
            {
                return;
            }

            //条码
            //if (e.ColumnIndex == col_all_tm.Index)
            //{
            //    if (!string.IsNullOrEmpty((string)e.FormattedValue) && !string.IsNullOrWhiteSpace((string)e.FormattedValue))
            //    {
            //        //检查是否重复
            //        if (tiaomaExists((string)e.FormattedValue))
            //        {
            //            MessageBox.Show("条码重复");
            //            e.Cancel = true;
            //        }
            //    }
            //}

            //数量
            else if (e.ColumnIndex == col_all_sl.Index)
            {
                short sl = 0;
                if (!short.TryParse((string)e.FormattedValue, out sl))
                {
                    MessageBox.Show("数量必须是数字");
                    e.Cancel = true;
                }
            }
            //进价
            else if (e.ColumnIndex == col_all_jj.Index)
            {
                decimal jj = 0;
                if (!decimal.TryParse((string)e.FormattedValue, out jj))
                {
                    MessageBox.Show("进价必须是数字");
                    e.Cancel = true;
                }
            }
            //售价
            else if (e.ColumnIndex == col_all_sj.Index)
            {
                decimal sj = 0;
                if (!decimal.TryParse((string)e.FormattedValue, out sj))
                {
                    MessageBox.Show("售价必须是数字");
                    e.Cancel = true;
                }
            }
        }
    }
}
