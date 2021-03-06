﻿using BIANMA.Properties;
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
using DB_JCSJ.Models;

namespace BIANMA
{
    public partial class Form_Bianma : Form
    {
        //客户端发号的ID
        private int _cid;

        //复制的条码idex
        private int? _copy_otmidex;
        private int _copy_ocells;

        //输入的款号，条码，供应商是否都正确
        //private bool _kuanhaoOK;
        //private bool _tiaomaOK;

        private List<TKuanhaoExtend> _khs;
        //设置当前行的颜色
        private Color _rowColor;
        private Color _color1;
        private Color _color2;

        public Form_Bianma()
        {
            InitializeComponent();
            //_kuanhaoOK = false;
            //_tiaomaOK = false;
            //从1开始发号
            _cid = 1;
            _copy_otmidex = 0;
            _copy_ocells = 0;

            _khs = new List<TKuanhaoExtend>();
            _color1 = Color.White;
            _color2 = Color.Azure;
            _rowColor = _color2;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Bianma_Load(object sender, EventArgs e)
        {
            //性别下拉框
            col_all_xb.DataSource = Enum.GetNames(typeof(DBCONSTS.KUANHAO_XB));
            //类型下拉框
            col_all_lx.DataSource = Enum.GetNames(typeof(DBCONSTS.KUANHAO_LX));
            //供应商下拉框
            TGongyingshang[] gyss = JCSJWCF.GetGongyingshangsByUserId(LoginInfo.User.id);
            if (gyss.Count() == 0)
            {
                throw new MyException("请先登陆管理系统增加至少一个供应商信息", null);
            }


            Tool.CommonFunc.InitCombbox(cmb_gys, gyss, "jiancheng", "id");

            col_all_gys.DataSource = gyss;
            col_all_gys.ValueMember = "id";
            col_all_gys.DisplayMember = "jiancheng";
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

                TTiaoma[] ts = JCSJWCF.GetTiaomas(LoginInfo.User.id, kuanhao, tiaoma, start, end); 
                TKuanhao[] ks =  ts.Select(r => r.TKuanhao).DistinctBy(r=>r.id).ToArray();

                //加入集合，显示款号条码
                foreach (TKuanhao k in ks)
                {
                    List<TTiaomaExtend> tsex = ts.Where(r => r.kuanhaoid == k.id).Select(r => new TTiaomaExtend
                    {
                        idex = getClientId(),
                        tiaoma = r,
                        shuliang = 0,
                        xj = XTCONSTS.TIAOMA_XINJIU.旧条码
                    }).ToList();

                    //检查是否已经有同名的款号被加载到了本地
                    TKuanhaoExtend ekt = _khs.SingleOrDefault(r => r.kuanhao.kuanhao == k.kuanhao && r.xj == XTCONSTS.KUANHAO_XINJIU.旧款);
                    if (ekt == null)
                    {
                        //将该款号加入集合
                        TKuanhaoExtend khex = new TKuanhaoExtend
                        {
                            idex = getClientId(),
                            xj = XTCONSTS.KUANHAO_XINJIU.旧款,
                            kuanhao = k,
                            tms = tsex
                        };

                        _khs.Add(khex);

                        //刷新表格显示
                        foreach (TTiaomaExtend tt in khex.tms)
                        {
                            addTiaomaAllMsg(khex, tt);
                        }
                    }
                    else
                    {
                        //将条码加入该款号的条码集合
                        foreach (var t in tsex)
                        {
                            if (!ekt.tms.Any(r => r.tiaoma.tiaoma == t.tiaoma.tiaoma))
                            {
                                ekt.tms.Add(t);
                                addTiaomaAllMsg(ekt, t);
                            }
                        }
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
                            t.tiaoma.gysid,
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
            //如果有某一整行被选中
            if (grid_all.SelectedRows.Count == 1)
            {
                DataGridViewRow dr = grid_all.SelectedRows[0];
                //如果是同款则在该行的下方插入
                int khidex = (int)dr.Cells[col_all_khidex.Name].Value;
                if (khidex == k.idex)
                {
                    index = dr.Index;
                }
            }

            //如果当前行的款号不相同，则遍历，看看是否其他有相同的款号
            if(index == null)
            {
                foreach (DataGridViewRow dr in grid_all.Rows)
                {
                    int khidex = (int)dr.Cells[col_all_khidex.Name].Value;
                    if (khidex == k.idex)
                    {
                        index = dr.Index;
                    }
                }
            }

            //新款，隔款改变行背景色
            if (index == null)
            {
                //删除最后一行的操作会导致_rowColor不准确。在这里将其纠正为最后一行的颜色
                if (grid_all.Rows.Count > 0)
                {
                    _rowColor = grid_all.Rows[grid_all.Rows.Count - 1].DefaultCellStyle.BackColor;
                }

                int ni = grid_all.Rows.Add(item);
                if (_rowColor == _color1)
                {
                    grid_all.Rows[ni].DefaultCellStyle.BackColor = _color2;
                    _rowColor = _color2;
                }
                else
                {
                    grid_all.Rows[ni].DefaultCellStyle.BackColor = _color1;
                    _rowColor = _color1;
                }
                grid_all.Rows[ni].Selected = true;
            }
            //新条码，不用变背景色
            else
            {
                grid_all.Rows.Insert(index.Value+1, item);
                grid_all.Rows[index.Value + 1].DefaultCellStyle.BackColor = grid_all.Rows[index.Value].DefaultCellStyle.BackColor;
                grid_all.Rows[index.Value + 1].Selected = true;
            }

            //刷新合计行
            refreshTotalRow();
        }
        

        /// <summary>
        /// 根据每行绑定的款号对象刷新款号grid显示
        /// </summary>
        private void refreshKuanhao()
        {
            foreach (DataGridViewRow dr in grid_all.Rows)
            {
                int khidex = (int)dr.Cells[col_all_khidex.Name].Value;
                TKuanhaoExtend tk = _khs.Single(r => r.idex == khidex);

                dr.Cells[col_all_kh.Name].Value = tk.kuanhao.kuanhao;
                dr.Cells[col_all_xb.Name].Value = ((DBCONSTS.KUANHAO_XB)tk.kuanhao.xingbie).ToString();
                dr.Cells[col_all_lx.Name].Value = ((DBCONSTS.KUANHAO_LX)tk.kuanhao.leixing).ToString();
                dr.Cells[col_all_pm.Name].Value = tk.kuanhao.pinming;
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
            addKuanhao(false);
        }

        private void addKuanhao(bool isNew)
        {
            grid_all.ClearSelection();

            TKuanhaoExtend tk = new TKuanhaoExtend
            {
                idex = getClientId(),
                xj = isNew ? XTCONSTS.KUANHAO_XINJIU.新款 : XTCONSTS.KUANHAO_XINJIU.旧款,
                kuanhao = new TKuanhao
                {
                    kuanhao = "",
                    xingbie = (byte)DBCONSTS.KUANHAO_XB.女,
                    leixing = (byte)DBCONSTS.KUANHAO_LX.上装,
                    pinming = "",
                    beizhu = "",
                    caozuorenid = LoginInfo.User.id,
                    charushijian = DateTime.Now,
                    xiugaishijian = DateTime.Now
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
                    gysid = int.Parse(cmb_gys.SelectedValue.ToString()),
                    jinjia = 0,
                    shoujia = 0,
                    tiaoma = "",
                    xiugaishijian = DateTime.Now,
                    yanse = ""
                }
            };
            tk.tms.Add(tt);
            _khs.Add(tk);

            addTiaomaAllMsg(tk, tt);
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
        /// 增加一个颜色尺码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_addsm_Click(object sender, EventArgs e)
        {
            addSema();
        }

        private void addSema()
        {
            if (_khs.Count() == 0)
            {
                MessageBox.Show("请先增加一个款号");
                return;
            }

            //如果选中了某一整行，则在该行西方添加一个条码
            TKuanhaoExtend tk = null;
            if (grid_all.SelectedRows.Count != 0)
            {
                int khidex = (int)grid_all.SelectedRows[0].Cells[col_all_khidex.Name].Value;
                tk = _khs.Single(r => r.idex == khidex);
            }
            else
            {
                tk = _khs.Last();
            }
            TTiaomaExtend tt = (TTiaomaExtend)tk.tms.Last().Clone();
            tt.xj = XTCONSTS.TIAOMA_XINJIU.新条码;
            tt.idex = getClientId();
            tt.tiaoma.tiaoma = "";
            tt.tiaoma.yanse = "";
            tt.tiaoma.chima = "";
            tt.tiaoma.gysid = int.Parse(cmb_gys.SelectedValue.ToString());
            tt.tiaoma.caozuorenid = LoginInfo.User.id;
            tt.tiaoma.charushijian = DateTime.Now;
            tt.tiaoma.xiugaishijian = DateTime.Now;

            tk.tms.Add(tt);

            grid_all.ClearSelection();
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
        /// 刷新总计信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_all_shuaxin_Click(object sender, EventArgs e)
        {
            grid_all.Rows.Clear();
            foreach (TKuanhaoExtend tk in _khs)
            {
                foreach (TTiaomaExtend tt in tk.tms)
                {
                    addTiaomaAllMsg(tk, tt);
                }
            }
        }

        /// <summary>
        /// 自动生成款号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_sckh_Click(object sender, EventArgs e)
        {
            string AB = Tool.CommonFunc.Year_month_to_AB(Settings.Default.STARTYEAR);

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
        /// 自动生成条码
        /// 当前的年月日+自动发号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_sctm_Click(object sender, EventArgs e)
        {
            string AB = Tool.CommonFunc.Year_month_to_AB(Settings.Default.STARTYEAR);
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
        /// 检查款号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool checkKuanhao()
        {
            List<string> nkhs = new List<string>();
            foreach (TKuanhaoExtend tk in _khs)
            {
                if (string.IsNullOrEmpty(tk.kuanhao.kuanhao) || string.IsNullOrWhiteSpace(tk.kuanhao.kuanhao))
                {
                    MessageBox.Show("款号不能为空白");
                    setCellColorByKhidex(tk.idex,col_all_kh.Index,Color.Red);
                    return false;
                }

                //检查新款号
                if (tk.xj == XTCONSTS.KUANHAO_XINJIU.新款)
                {
                    //款号符合固定格式
                    if (!Tool.CommonFunc.CheckFormat_KH(tk.kuanhao.kuanhao))
                    {
                        MessageBox.Show("款号格式非法");
                        setCellColorByKhidex(tk.idex,col_all_kh.Index, Color.Red);
                        return false;
                    }

                    //品名是否是空白
                    if (string.IsNullOrEmpty(tk.kuanhao.pinming) || string.IsNullOrWhiteSpace(tk.kuanhao.pinming))
                    {
                        MessageBox.Show("品名不能为空白");
                        setCellColorByKhidex(tk.idex,col_all_pm.Index, Color.Red);
                        return false;
                    }

                    nkhs.Add(tk.kuanhao.kuanhao);
                }
                //如果是旧款号，必须加载款号信息
                else
                {
                    if (tk.kuanhao.id == 0)
                    {
                        MessageBox.Show("请先加载款号信息");
                        setCellColorByKhidex(tk.idex,col_all_kh.Index, Color.Red);
                        return false;
                    }
                }
            }

            //款号不能重复
            setCellColorByKh(null, col_all_kh.Index, null);
            var dkhs = _khs.GroupBy(r => r.kuanhao.kuanhao).Select(r => new { kh = r.Key, c = r.Count() }).Where(r => r.c > 1);
            if (dkhs.Count() > 0)
            {
                foreach (var dkh in dkhs)
                {
                    setCellColorByKh(dkh.kh,col_all_kh.Index, Color.Red);
                }
                MessageBox.Show("款号有重复");
                return false;
            }

            //去服务器验证新款号
            if (nkhs.Count() > 0)
            {
                string[] eKhs = JCSJWCF.CheckKuanhaosChongfu(nkhs.ToArray());
               
                //先恢复为原色，再接受检查
                setCellColorByKh(null,col_all_kh.Index, null);
                if (eKhs.Length != 0)
                {
                    foreach (string k in eKhs)
                    {
                        setCellColorByKh(k, col_all_kh.Index, Color.Red);
                    }
                    MessageBox.Show("款号有重复");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 设置单元格背景色
        /// </summary>
        /// <param name="idex"></param>
        /// <param name="color"></param>
        private void setCellColorByKhidex(int idex, int columnIndex, Color? color)
        {
            foreach (DataGridViewRow dr in grid_all.Rows)
            {
                int khidex = (int)dr.Cells[col_all_khidex.Name].Value;
                if (khidex == idex)
                {
                    if (color == null)
                    {
                        dr.Cells[columnIndex].Style.BackColor = dr.DefaultCellStyle.BackColor;
                    }
                    else
                    {

                        dr.Cells[columnIndex].Style.BackColor = color.Value;
                    }
                }
            }
        }
        private void setCellColorByKh(string kh, int columnIndex, Color? color)
        {
            foreach (DataGridViewRow dr in grid_all.Rows)
            {
                string kuanhao = (string)dr.Cells[col_all_kh.Name].Value;
                if (kh == null)
                {
                    if(color == null)
                    {
                        dr.Cells[columnIndex].Style.BackColor = dr.DefaultCellStyle.BackColor;
                    }
                    else
                    {
                        dr.Cells[columnIndex].Style.BackColor = color.Value;
                    }
                }
                else
                {
                    if (kuanhao == kh)
                    {
                        if (color == null)
                        {
                            dr.Cells[columnIndex].Style.BackColor = dr.DefaultCellStyle.BackColor;
                        }
                        else
                        {
                            dr.Cells[columnIndex].Style.BackColor = color.Value;
                        }
                    }
                }
            }
        }
        private void setCellColorByTmidex(int idex, int columnIndex, Color? color)
        {
            foreach (DataGridViewRow dr in grid_all.Rows)
            {
                int tmidex = (int)dr.Cells[col_all_tmidex.Name].Value;
                if (tmidex == idex)
                {
                    if (color == null)
                    {
                        dr.Cells[columnIndex].Style.BackColor = dr.DefaultCellStyle.BackColor;
                    }
                    else
                    {
                        dr.Cells[columnIndex].Style.BackColor = color.Value;
                    }
                }
            }
        }
        private void setCellColorByTm(string tm, int columnIndex, Color? color)
        {
            foreach (DataGridViewRow dr in grid_all.Rows)
            {
                string tiaoma = (string)dr.Cells[col_all_tm.Name].Value;
                if (tiaoma == null)
                {
                    if (color == null)
                    {
                        dr.Cells[columnIndex].Style.BackColor = dr.DefaultCellStyle.BackColor;
                    }
                    else
                    {
                        dr.Cells[columnIndex].Style.BackColor = color.Value;
                    }
                }
                else
                {
                    if (tiaoma == tm)
                    {
                        if (color == null)
                        {
                            dr.Cells[columnIndex].Style.BackColor = dr.DefaultCellStyle.BackColor;
                        }
                        else
                        {
                            dr.Cells[columnIndex].Style.BackColor = color.Value;
                        }
                    }
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
        /// 检查条码信息，和条码是否重复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool checkTiaoma()
        {
            List<string> tms = new List<string>();
            foreach (TKuanhaoExtend tk in _khs)
            {
                List<TTiaomaExtend> ts = tk.tms;

                foreach (TTiaomaExtend t in ts)
                {
                    if (string.IsNullOrEmpty(t.tiaoma.tiaoma) || string.IsNullOrWhiteSpace(t.tiaoma.tiaoma))
                    {
                        MessageBox.Show("条码不能空白");
                        setCellColorByTmidex(t.idex, col_all_tm.Index, Color.Red);
                        return false;
                    }

                    //条码符合固定格式
                    if (!Tool.CommonFunc.CheckFormat_TM(t.tiaoma.tiaoma))
                    {
                        MessageBox.Show("条码格式非法");
                        setCellColorByTmidex(t.idex, col_all_tm.Index, Color.Red);
                        return false;
                    }

                    if (string.IsNullOrEmpty(t.tiaoma.yanse) || string.IsNullOrWhiteSpace(t.tiaoma.yanse))
                    {
                        MessageBox.Show("颜色不能空白");
                        setCellColorByTmidex(t.idex, col_all_ys.Index, Color.Red);
                        return false;
                    }

                    if (string.IsNullOrEmpty(t.tiaoma.chima) || string.IsNullOrWhiteSpace(t.tiaoma.chima))
                    {
                        MessageBox.Show("尺码不能空白");
                        setCellColorByTmidex(t.idex, col_all_cm.Index, Color.Red);
                        return false;
                    }

                    if (t.tiaoma.jinjia == 0)
                    {
                        MessageBox.Show("进价不能为0");
                        setCellColorByTmidex(t.idex, col_all_jj.Index, Color.Red);
                        return false;
                    }

                    if (t.tiaoma.shoujia == 0)
                    {
                        MessageBox.Show("售价不能为0");
                        setCellColorByTmidex(t.idex, col_all_sj.Index, Color.Red);
                        return false;
                    }

                    if (t.xj == XTCONSTS.TIAOMA_XINJIU.新条码)
                    {
                        tms.Add(t.tiaoma.tiaoma);
                    }
                }

                //同一个款号内，不能有同色同码的
                //setCellColorByKh(tk.kuanhao.kuanhao, col_all_kh.Index, null);
                //if (tk.tms.DistinctBy(r => new { r.tiaoma.yanse, r.tiaoma.chima }).Count() != tk.tms.Count())
                //{
                //    MessageBox.Show("同一个款号内，不能有同色同码的");
                //    setCellColorByKh(tk.kuanhao.kuanhao, col_all_kh.Index, Color.Red);
                //    return false;
                //}
            }

            //不能有相同的条码
            setCellColorByTm(null, col_all_tm.Index, null);
            var dtms = _khs.SelectMany(r => r.tms).GroupBy(r => r.tiaoma.tiaoma).Select(r => new { tm = r.Key, c = r.Count() }).Where(r => r.c > 1);
            if (dtms.Count() > 0)
            {
                MessageBox.Show("存在相同的条码");
                foreach (var dtm in dtms)
                {
                    setCellColorByTm(dtm.tm, col_all_tm.Index, Color.Red);
                }
                return false;
            }

            if (tms.Count > 0)
            {
                string[] eTms = JCSJWCF.CheckTiaomaChongfu(tms.ToArray());
               

                if (eTms.Length > 0)
                {
                    foreach (string t in eTms)
                    {
                        setCellColorByTm(t, col_all_tm.Index, Color.Red);
                    }
                    MessageBox.Show("条码有重复");
                    return false;
                }
            }

            return true;
        }
                        
        /// <summary>
        /// 将款号和条码信息保存到本地xml文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Bianma_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否保存数据到本地？", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                localSave();
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
            if (checkKuanhao())
            {
                List<TKuanhao> ks = new List<TKuanhao>();
                //取得所有新款号
                foreach (TKuanhaoExtend tk in _khs)
                {
                    if (tk.xj == XTCONSTS.KUANHAO_XINJIU.新款)
                    {
                        ks.Add(tk.kuanhao);
                    }
                }

                if (ks.Count != 0)
                {
                    TKuanhao[] nks = JCSJWCF.SaveKuanhaos(ks.ToArray());
                    
                    //用返回结果更新本地数据
                    foreach (TKuanhaoExtend tk in _khs)
                    {
                        //因为_khs中可能有旧款号，但是nks中全是新款号，所以用SingleOrDefault
                        TKuanhao k = nks.SingleOrDefault(r => r.kuanhao == tk.kuanhao.kuanhao);
                        if (k != null)
                        {
                            tk.xj = XTCONSTS.KUANHAO_XINJIU.旧款;
                            tk.kuanhao = k;
                            tk.tms.ForEach(r => r.tiaoma.kuanhaoid = k.id);
                        }
                    }
                }
            }
            else
            {
                return;
            }

            //保存条码信息
            if (checkTiaoma())
            {
                List<TTiaoma> ts = new List<TTiaoma>();
                //取得所有新条码
                foreach (TKuanhaoExtend tk in _khs)
                {
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
                    TTiaoma[] nts = JCSJWCF.SaveTiaomas(ts.ToArray());
                    
                    //用返回结果更新本地数据
                    foreach (TKuanhaoExtend tk in _khs)
                    {
                        foreach (TTiaomaExtend tex in tk.tms)
                        {
                            //因为tk.tms中可能有旧条码，但是nts中全是新条码，所以用SingleOrDefault
                            TTiaoma t = nts.SingleOrDefault(r => r.tiaoma == tex.tiaoma.tiaoma);
                            if (t != null)
                            {
                                tex.xj = XTCONSTS.TIAOMA_XINJIU.旧条码;
                                tex.tiaoma = t;
                            }
                        }
                    }
                }
            }
            else
            {
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
            //如果已经添加了款号，则不允许再从本地加载，因为发番的客户端id有可能重复
            if (_khs.Count() > 0)
            {
                MessageBox.Show("已经有数据，无法再从本地加载");
                return;
            }

            TKuanhaoExtend[] kexs = TKuanhaoExtend.FromXml(Settings.Default.DUMPFILENAME);
            _khs.AddRange(kexs);
            foreach (TKuanhaoExtend kex in _khs)
            {
                //addKuanhao(kex);
                foreach (TTiaomaExtend tt in kex.tms)
                {
                    addTiaomaAllMsg(kex, tt);
                }
            }

            //加载完后，出示一下本地的发番ID
            int kmax = _khs.Max(r => (int?)r.idex) ?? 0;
            int tmax = _khs.SelectMany(r => r.tms).Max(r => (int?)r.idex) ?? 0;
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
            //增加一个款号
            else if (e.Control && !e.Alt && e.KeyCode == Keys.Add)
            {
                addKuanhao(true);   
            }
            //增加一个色码
            else if (e.Control && e.Alt && e.KeyCode == Keys.Add)
            {
                addSema();
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
            foreach (TKuanhaoExtend tk in _khs)
            {
                foreach (TTiaomaExtend tex in tk.tms)
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
                        bq += tk.kuanhao.kuanhao + ",";
                        bq += tk.kuanhao.pinming + ",";
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

            //修改值后，恢复正常背景色，等在再次检查
            grid_all[e.ColumnIndex, e.RowIndex].Style.BackColor = grid_all.Rows[e.RowIndex].DefaultCellStyle.BackColor;

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
            short sl = short.Parse(grid_all[col_all_sl.Name, e.RowIndex].Value.ToString());

            //修改的是款号
            if (e.ColumnIndex == col_all_kh.Index)
            {
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
            else if (e.ColumnIndex == col_all_sl.Index)
            {
                tt.shuliang = sl;
                //刷新合计
                refreshTotalRow();
            }

            //修改了款号信息，需要将不同行的同一款号信息都修改
            if (e.ColumnIndex == col_all_kh.Index || e.ColumnIndex == col_all_xb.Index ||
               e.ColumnIndex == col_all_lx.Index || e.ColumnIndex == col_all_pm.Index)
            {
                refreshKuanhao();
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
            XTCONSTS.KUANHAO_XINJIU khxj = (XTCONSTS.KUANHAO_XINJIU)Enum.Parse(typeof(XTCONSTS.KUANHAO_XINJIU), grid_all[col_all_khxj.Name, e.RowIndex].Value.ToString());
            XTCONSTS.TIAOMA_XINJIU tmxj = (XTCONSTS.TIAOMA_XINJIU)Enum.Parse(typeof(XTCONSTS.TIAOMA_XINJIU), grid_all[col_all_tmxj.Name, e.RowIndex].Value.ToString());
            
            //款号信息
            if (e.ColumnIndex == col_all_xb.Index || e.ColumnIndex == col_all_lx.Index || e.ColumnIndex == col_all_pm.Index)
            {
                if(khxj == XTCONSTS.KUANHAO_XINJIU.旧款)
                {
                    e.Cancel = true;
                }
            }
            //条码
            else if (e.ColumnIndex == col_all_tm.Index)
            {
                if (tmxj == XTCONSTS.TIAOMA_XINJIU.旧条码)
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

        /// <summary>
        /// 保存修改的旧条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_all_saveTm_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr;
            if (grid_all.SelectedRows.Count == 1)
            {
                dr = grid_all.SelectedRows[0];
            }
            else if (grid_all.SelectedRows.Count == 0)
            {
                if (grid_all.SelectedCells.Count == 1)
                {
                    dr = grid_all.SelectedCells[0].OwningRow;
                }
                else if (grid_all.SelectedCells.Count == 0)
                {
                    MessageBox.Show("请选择要保存的行");
                    return;
                }
                else
                {
                    MessageBox.Show("一次只能保存一个条码信息");
                    return;
                }
            }
            else
            {
                MessageBox.Show("一次只能保存一个条码信息");
                return;
            }

            int khidex = (int)dr.Cells[col_all_khidex.Name].Value;
            int tmidex = (int)dr.Cells[col_all_tmidex.Name].Value;
            TKuanhaoExtend tk = _khs.Single(r => r.idex == khidex);
            TTiaomaExtend tt = tk.tms.Single(r => r.idex == tmidex);

            if (tt.xj == XTCONSTS.TIAOMA_XINJIU.新条码)
            {
                MessageBox.Show("对新条码无效，只能保存旧条码修改的信息");
                return;
            }

            JCSJWCF.EditTiaoma(tt.tiaoma);

            MessageBox.Show("修改成功");
        }

        /// <summary>
        /// 加载旧款号信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_all_jzkh_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = grid_all.SelectedCells[0].OwningRow;

            int khidex = (int)dr.Cells[col_all_khidex.Name].Value;
            int tmidex = (int)dr.Cells[col_all_tmidex.Name].Value;
            TKuanhaoExtend tk = _khs.Single(r => r.idex == khidex);
            TTiaomaExtend tt = tk.tms.Single(r => r.idex == tmidex);
            XTCONSTS.KUANHAO_XINJIU khxj = (XTCONSTS.KUANHAO_XINJIU)Enum.Parse(typeof(XTCONSTS.KUANHAO_XINJIU), dr.Cells[col_all_khxj.Name].Value.ToString());

            if (khxj == XTCONSTS.KUANHAO_XINJIU.新款)
            {
                MessageBox.Show("只有旧款才能加载");
                return;
            }

            TKuanhao k = JCSJWCF.GetKuanhaoByMc(tk.kuanhao.kuanhao);

            if (k == null)
            {
                MessageBox.Show("不存在该款号");
            }
            else
            {
                tk.kuanhao = k;
                tk.tms.ForEach(r => r.tiaoma.kuanhaoid = k.id);
                refreshKuanhao();
            }
        }

        /// <summary>
        /// 删除一个条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_all_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            int khidex = (int)e.Row.Cells[col_all_khidex.Index].Value;
            int tmidex = (int)e.Row.Cells[col_all_tmidex.Index].Value;

            TKuanhaoExtend tk = _khs.Single(r => r.idex == khidex);
            TTiaomaExtend tt = tk.tms.Single(r => r.idex == tmidex);
            tk.tms.Remove(tt);
            if (tk.tms.Count() == 0)
            {
                _khs.Remove(tk);
            }

            //刷新合计行
            refreshTotalRow();
        }

        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_all_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                                                e.RowBounds.Location.Y,
                                                grid_all.RowHeadersWidth - 4,
                                                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                grid_all.RowHeadersDefaultCellStyle.Font,
                rectangle,
                grid_all.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        /// <summary>
        /// 刷新合计行
        /// </summary>
        private void refreshTotalRow()
        {           
            //更新合计行
            col_all_sl.HeaderText = "数量(" + (_khs.SelectMany(r => r.tms).Sum(r => (short?)r.shuliang) ?? 0) + ")";
        }

        /// <summary>
        /// 键盘快捷键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_all_KeyDown(object sender, KeyEventArgs e)
        {       
            //复制
            if (e.Control && e.KeyCode == Keys.C)
            {
                //选中一整行，复制供应商款号，颜色，尺码，进价，售价，数量
                if (grid_all.SelectedRows.Count == 1)
                {
                    _copy_otmidex = (int)grid_all.SelectedRows[0].Cells[col_all_tmidex.Name].Value;
                }
                else
                {
                    _copy_otmidex = null;
                    _copy_ocells = grid_all.SelectedCells.Count;
                }
            }
            //粘贴
            else if (e.Control && e.KeyCode == Keys.V)
            {
                //行选中模式，复制供应商款号，颜色，尺码，进价，售价，数量
                if (grid_all.SelectedRows.Count == 1)
                {
                    if (_copy_otmidex != null)
                    {
                        DataGridViewRow dr = grid_all.SelectedRows[0];
                        TTiaomaExtend tt = _khs.SelectMany(r => r.tms).Single(r => r.idex == _copy_otmidex.Value);
                        dr.Cells[col_all_gyskh.Name].Value = tt.tiaoma.gyskuanhao;
                        dr.Cells[col_all_ys.Name].Value = tt.tiaoma.yanse;
                        dr.Cells[col_all_cm.Name].Value = tt.tiaoma.chima;
                        dr.Cells[col_all_jj.Name].Value = tt.tiaoma.jinjia;
                        dr.Cells[col_all_sj.Name].Value = tt.tiaoma.shoujia;
                        dr.Cells[col_all_sl.Name].Value = tt.shuliang;
                    }

                    e.Handled = true;
                }
                //单元格选择模式
                else if (grid_all.SelectedRows.Count == 0)
                {
                    if (grid_all.SelectedCells.Count == 0)
                    {
                        MessageBox.Show("未选择目标单元格");
                        return;
                    }

                    //如果源数据有多个单元格，不允许复制
                    if (_copy_ocells > 1)
                    {
                        e.Handled = true;
                        MessageBox.Show("禁止复制多个单元格的数据");
                        return;
                    }

                    //如果选中了不同的列，不允许粘贴
                    List<int> indexs = new List<int>();
                    foreach (DataGridViewCell dc in grid_all.SelectedCells)
                    {
                        indexs.Add(dc.ColumnIndex);
                    }
                    if (indexs.Distinct().Count() != 1)
                    {
                        e.Handled = true;
                        MessageBox.Show("禁止把数据粘贴到不同的列");
                        return;
                    }

                    foreach (DataGridViewCell dc in grid_all.SelectedCells)
                    {
                        //只读和条码列不允许粘贴
                        if (!dc.ReadOnly)
                        {
                            //供应商款号，颜色，尺码，进价，售价，数量
                            if (dc.ColumnIndex == col_all_gyskh.Index || dc.ColumnIndex == col_all_ys.Index ||
                                dc.ColumnIndex == col_all_cm.Index || dc.ColumnIndex == col_all_jj.Index ||
                                dc.ColumnIndex == col_all_sj.Index || dc.ColumnIndex == col_all_sl.Index)
                            {
                                dc.Value = Clipboard.GetData(DataFormats.Text);
                            }
                        }
                    }
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("禁止粘贴到多个行");
                    return;
                }
                
            }
        }

        /// <summary>
        /// 仓库导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_fddr_Click(object sender, EventArgs e)
        {
            string bq = "";            
            foreach (TKuanhaoExtend tk in _khs)
            {
                foreach (TTiaomaExtend tex in tk.tms)
                {
                    bq += tex.tiaoma.tiaoma + ",";
                    bq += tex.shuliang + "\r\n";
                }
            }

            SaveFileDialog sdlg = new SaveFileDialog();
            if (sdlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(sdlg.FileName, bq, Encoding.Default);
            }
        }

        /// <summary>
        /// 按照系数计算售价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_jssj_Click(object sender, EventArgs e)
        {
            decimal x;
            if (!decimal.TryParse(txb_sjxs.Text.Trim(), out x))
            {
                MessageBox.Show("系数必须是数字");
                return;
            }

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

            refreshShoujia();
        }

        /// <summary>
        /// 设置供应商
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_szgys_Click(object sender, EventArgs e)
        {
            if (grid_all.SelectedRows.Count == 0)
            {
                return;
            }

            foreach (DataGridViewRow dr in grid_all.SelectedRows)
            {
                int gysid = int.Parse(cmb_gys.SelectedValue.ToString());
                dr.Cells[col_all_gys.Name].Value = gysid;

                int khidex = (int)dr.Cells[col_all_khidex.Name].Value;
                int tmidex = (int)dr.Cells[col_all_tmidex.Name].Value;

                TKuanhaoExtend ke = _khs.Single(r => r.idex == khidex);
                TTiaomaExtend te = ke.tms.Single(r => r.idex == tmidex);
                te.tiaoma.gysid = gysid;
            }
        }

        /// <summary>
        /// 从文件加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_jiazai_wenjian_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = fd.FileName;
                StreamReader fs = null;
                string content = "";
                try
                {
                    fs = new StreamReader(file, Encoding.Default);
                    content = fs.ReadToEnd();
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }

                string[] lines = content.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                //检查格式
                if (lines.Count() < 2)
                {
                    throw new MyException("连同表头，一共不得少于两行", null);
                }

                string head = lines[0];
                string standHead = Enum.GetNames(typeof(XTCONSTS.FILE_COLUMN)).Aggregate((a, b) => { return a + "," + b; });
                if (head != standHead)
                {
                    throw new MyException("正确的表头应当是："+standHead, null);
                }

                var tsEE = lines.Skip(1).Select(r => new
                {
                    lx = r.Split(new char[] { ',' })[(byte)XTCONSTS.FILE_COLUMN.类型],
                    pm = r.Split(new char[] { ',' })[(byte)XTCONSTS.FILE_COLUMN.品名],
                    te = createTTiaomaExtendFromString(r)
                }).ToArray();

                _khs = tsEE.GroupBy(r => new { r.te.tiaoma.gyskuanhao, r.pm, r.lx }).Select(r => new TKuanhaoExtend
                {
                    idex = getClientId(),
                    kuanhao = new TKuanhao
                    {
                        beizhu = "",
                        kuanhao = "",
                        leixing = (byte)(DBCONSTS.KUANHAO_LX)Enum.Parse(typeof(DBCONSTS.KUANHAO_LX), r.Key.lx),
                        pinming = r.Key.pm,
                        xingbie = (byte)DBCONSTS.KUANHAO_XB.女,
                        charushijian = DateTime.Now,
                        xiugaishijian = DateTime.Now
                    },
                    tms = r.Select(gr=>gr.te).ToList(),
                    xj = XTCONSTS.KUANHAO_XINJIU.新款
                }).ToList();

                cmn_all_shuaxin_Click(null, null);
            }
        }

        private TTiaomaExtend createTTiaomaExtendFromString(string line)
        {
            string[] ss = line.Split(new char[] { ',' });
            string tm = ss[(byte)XTCONSTS.FILE_COLUMN.条码];
            string gyskh = ss[(byte)XTCONSTS.FILE_COLUMN.款号];
            string pm = ss[(byte)XTCONSTS.FILE_COLUMN.品名];
            string ys = ss[(byte)XTCONSTS.FILE_COLUMN.颜色];
            string cm = ss[(byte)XTCONSTS.FILE_COLUMN.尺码];
            string sl = ss[(byte)XTCONSTS.FILE_COLUMN.数量];
            string jj = ss[(byte)XTCONSTS.FILE_COLUMN.进价];
            string sj = ss[(byte)XTCONSTS.FILE_COLUMN.售价];
            TTiaomaExtend te = new TTiaomaExtend
            {
                idex = getClientId(),
                xj = XTCONSTS.TIAOMA_XINJIU.新条码,
                shuliang = short.Parse(sl),
                tiaoma = new TTiaoma
                {
                    tiaoma = tm,
                    gysid = int.Parse(cmb_gys.SelectedValue.ToString()),
                    gyskuanhao = gyskh,
                    yanse = ys,
                    chima = cm,
                    jinjia = decimal.Parse(jj),
                    shoujia = decimal.Parse(sj),
                    charushijian = DateTime.Now,
                    xiugaishijian = DateTime.Now
                }
            };

            return te;
        }
    }
}
