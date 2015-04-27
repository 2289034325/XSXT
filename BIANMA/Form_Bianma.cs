using BIANMA.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool.DB.JCSJ;

namespace BIANMA
{
    public partial class Form_Bianma : Form
    {
        private JCSJData.DataServiceClient _dc;

        private TUser _u;

        //输入的款号，条码，供应商是否都正确
        private bool _kuanhaoOK;
        private bool _tiaomaOK;
        private bool _gysOK;

        public Form_Bianma()
        {
            InitializeComponent();
            _kuanhaoOK = false;
            _tiaomaOK = false;
            _gysOK = false;
            _dc = new JCSJData.DataServiceClient();            
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Bianma_Load(object sender, EventArgs e)
        {
            try
            {
                _u = _dc.BMZHLogin("2", Tool.CommonFunc.MD5_16("2"), Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 修改账号密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_xgmm_Click(object sender, EventArgs e)
        {
            if (checkLogin())
            {             
                Dlg_XiugaiMima dx = new Dlg_XiugaiMima(_dc);
                dx.ShowDialog();
            }
        }

        /// <summary>
        /// 检查是否已登录
        /// </summary>
        /// <returns></returns>
        private bool checkLogin()
        {
            if (_u == null)
            {
                MessageBox.Show("未登录");
                return false;
            }
            else if (_dc.State != System.ServiceModel.CommunicationState.Opened)
            {
                _dc.Open();

                MessageBox.Show("未登录");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 注册账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_zhuce_Click(object sender, EventArgs e)
        {
            Dlg_Zhuce dz = new Dlg_Zhuce();
            dz.ShowDialog();
        }

        /// <summary>
        /// 账号绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_zhbd_Click(object sender, EventArgs e)
        {
            Dlg_Bangding db = new Dlg_Bangding();
            db.ShowDialog();
        }

        /// <summary>
        /// 加载所有该用户编辑的款号条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_jiazai_Click(object sender, EventArgs e)
        {
            if (checkLogin())
            {
                Dlg_Jiazai dj = new Dlg_Jiazai();
                if (dj.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string kuanhao = dj.txb_kh.Text.Trim();
                    string tiaoma = dj.txb_tm.Text.Trim();
                    DateTime start = dj.dp_start.Value.Date;
                    DateTime end = dj.dp_end.Value.Date;
                    TTiaoma[] ts = null;
                    TKuanhao[] ks = null;

                    ts = _dc.GetTiaomas(_u.id, kuanhao, tiaoma, start, end);
                    ks = ts.Select(r => r.TKuanhao).ToArray();

                    List<TTiaomaExtend> tsex = new List<TTiaomaExtend>();
                    foreach (TTiaoma t in ts)
                    {
                        tsex.Add(new TTiaomaExtend 
                        {
                            idex = tsex.Count()+1,
                            tiaoma = t,
                            shuliang = 0,
                            xj = XTCONSTS.TIAOMA_XINJIU.旧条码
                        });
                    }
                    //显示款号
                    foreach(TKuanhao k in ks)
                    {
                        addKuanhao(new TKuanhaoExtend
                        {
                            idex = grid_kuanhao.Rows.Count,
                            xj = XTCONSTS.KUANHAO_XINJIU.旧款,
                            kuanhao = k
                        },tsex);
                    }
                    //刷新表格显示
                    refreshKuanhao();
                }
            }
        }

        /// <summary>
        /// 显示合并信息
        /// </summary>
        /// <param name="t"></param>
        private void addTiaomaAllMsg(TKuanhaoExtend k, TTiaomaExtend t)
        {
            grid_all.Rows.Add(new object[] 
                        {
                            t.idex,
                            t.khidex,
                            k.kuanhao.kuanhao,                            
                            ((DBCONSTS.KUANHAO_XB)k.kuanhao.xingbie).ToString(),
                            ((DBCONSTS.KUANHAO_LX)k.kuanhao.leixing).ToString(),
                            k.kuanhao.pinming,
                            t.tiaoma.tiaoma,
                            t.tiaoma.gyskuanhao,
                            t.tiaoma.yanse,
                            t.tiaoma.chima,
                            t.shuliang,
                            t.tiaoma.jinjia,
                            t.tiaoma.shoujia,
                            t.tiaoma.charushijian,
                            t.tiaoma.xiugaishijian
                        });
        }

        /// <summary>
        /// 在grid的中增加一个款号
        /// </summary>
        /// <param name="tKuanhao"></param>
        private void addKuanhao(TKuanhaoExtend k,List<TTiaomaExtend> tms)
        {
            //合并标志
            bool hb = false;
            //如果已存在，就合并
            TKuanhaoExtend exk = null;
            List<TTiaomaExtend> otms = null;
            //如果是空白，说明是点击菜单【新款】【旧款】添加的，否则是点击【加载】添加的旧款号
            if (k.kuanhao.kuanhao == "")
            {
                hb = false;
            }
            //如果款号不是空白，说明是加载的旧款号
            else
            {
                //遍历检查是否已经存在相同的旧款号
                foreach (DataGridViewRow dr in grid_kuanhao.Rows)
                {
                    exk = (TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value;
                    otms = (List<TTiaomaExtend>)dr.Cells[col_kh_tms.Name].Value;
                    //如果款号相同
                    if (exk.kuanhao.kuanhao == k.kuanhao.kuanhao)
                    {
                        hb = true;

                        //被标为新款，报错
                        if (exk.xj == XTCONSTS.KUANHAO_XINJIU.新款)
                        {
                            MessageBox.Show("款号" + exk.kuanhao.kuanhao + "被标为新款号，无法加载");
                            return;
                        }
                        //标为旧款，则合并条码信息
                        else
                        {
                            //更新row显示
                            dr.Cells[col_kh_khex.Name].Value = k;

                            //合并条码列表
                            //检查是否已经存在list里了
                            foreach (TTiaomaExtend t in tms)
                            {
                                if (!otms.Exists(r => r.tiaoma.tiaoma == t.tiaoma.tiaoma))
                                {
                                    otms.Add(t);
                                }
                            }
                        }
                    }
                }
            }

            //没有进行合并，就直接增加一行
            if (!hb)
            {
                grid_kuanhao.Rows.Add(new object[] 
                        {
                            k.idex,
                            k.xj.ToString(),
                            k.kuanhao.kuanhao,
                            ((DBCONSTS.KUANHAO_XB)k.kuanhao.xingbie).ToString(),
                            ((DBCONSTS.KUANHAO_LX)k.kuanhao.leixing).ToString(),
                            k.kuanhao.pinming,
                            k.kuanhao.caozuorenid,
                            tms,
                            k
                        });
            }
        }

        /// <summary>
        /// 根据每行绑定的款号对象刷新款号grid显示
        /// </summary>
      private void  refreshKuanhao()
    {
        foreach (DataGridViewRow dr in grid_kuanhao.Rows)
        {
            TKuanhaoExtend k = (TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value;
            dr.Cells[col_kh_kh.Name].Value = k.kuanhao.kuanhao.ToString();
            dr.Cells[col_kh_xb.Name].Value = ((DBCONSTS.KUANHAO_XB)k.kuanhao.xingbie).ToString();
            dr.Cells[col_kh_lx.Name].Value = ((DBCONSTS.KUANHAO_LX)k.kuanhao.leixing).ToString();
            dr.Cells[col_kh_pm.Name].Value = k.kuanhao.pinming;
        }
    }

        /// <summary>
        /// 管理供应商信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_gysxx_Click(object sender, EventArgs e)
        {
            Dlg_Gongyingshang dg = new Dlg_Gongyingshang(_dc, _u);
            dg.ShowDialog();
        }

        /// <summary>
        /// 增加一个新款号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_addkh_Click(object sender, EventArgs e)
        {
            if (!checkLogin())
            { return; }

            addKuanhao(new TKuanhaoExtend
            {
                idex = grid_kuanhao.Rows.Count,
                xj = XTCONSTS.KUANHAO_XINJIU.新款,
                kuanhao = new TKuanhao
                {
                    kuanhao = "",
                    xingbie = (byte)DBCONSTS.KUANHAO_XB.女,
                    leixing = (byte)DBCONSTS.KUANHAO_LX.衣服,
                    pinming = "",
                    caozuorenid = _u.id
                },
            }, new List<TTiaomaExtend>());
        }

        /// <summary>
        /// 增加一个旧款号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_addjkh_Click(object sender, EventArgs e)
        {
            if (!checkLogin())
            { return; }

            addKuanhao(new TKuanhaoExtend
            {
                idex = grid_kuanhao.Rows.Count,
                xj = XTCONSTS.KUANHAO_XINJIU.旧款,
                kuanhao = new TKuanhao
                {
                    kuanhao = "",
                    xingbie = (byte)DBCONSTS.KUANHAO_XB.女,
                    leixing = (byte)DBCONSTS.KUANHAO_LX.衣服,
                    pinming = "",
                    caozuorenid = _u.id
                },
            }, new List<TTiaomaExtend>());
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
            Dlg_Kuanhao dk = new Dlg_Kuanhao(_dc, _u);
            dk.ShowDialog();
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_login_Click(object sender, EventArgs e)
        {
            if (_u == null)
            {
                Dlg_Denglu dl = new Dlg_Denglu(_dc);
                if (dl.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _u = dl.User;
                }
            }
            else
            {
                MessageBox.Show("已登录");
            }
        }
        
        /// <summary>
        /// 确定编辑，如果是修改了旧款的款号，则加载款号信息和已有的条码信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kuanhao_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string kh = (string)grid_kuanhao[col_kh_kh.Name, e.RowIndex].Value; 
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
                        TKuanhao k = _dc.GetKuanhaoByMc(kh);
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
                            ((TKuanhaoExtend)grid_kuanhao.Rows[e.RowIndex].Cells[col_kh_khex.Name].Value).kuanhao = k;
                        }
                    }
                    //输入了空白，验证也算不通过
                    else
                    {
                        _kuanhaoOK = false;
                    }
                }
            }

            TKuanhaoExtend kx = (TKuanhaoExtend)grid_kuanhao.Rows[e.RowIndex].Cells[col_kh_khex.Name].Value;
            kx.kuanhao.kuanhao = kh;
            kx.kuanhao.xingbie = (byte)Enum.Parse(typeof(DBCONSTS.KUANHAO_XB), (string)grid_kuanhao[col_kh_xb.Name, e.RowIndex].Value);
            kx.kuanhao.leixing = (byte)Enum.Parse(typeof(DBCONSTS.KUANHAO_LX), (string)grid_kuanhao[col_kh_lx.Name, e.RowIndex].Value);
            kx.kuanhao.pinming = (string)grid_kuanhao[col_kh_pm.Name, e.RowIndex].Value;
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
            }
            else
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
            List<TTiaomaExtend> ts = (List<TTiaomaExtend>)grid_kuanhao[col_kh_tms.Name, e.RowIndex].Value;
            
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
                t.khidex,
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
            TTiaoma[] ts = _dc.GetTiaomasByKuanhaoMc(kh);
            byte xingbie = (byte)((DBCONSTS.KUANHAO_XB)Enum.Parse(typeof(DBCONSTS.KUANHAO_XB), dr.Cells[col_kh_xb.Name].Value.ToString()));
            byte leixing = (byte)((DBCONSTS.KUANHAO_LX)Enum.Parse(typeof(DBCONSTS.KUANHAO_LX), dr.Cells[col_kh_lx.Name].Value.ToString()));
            string pinming = dr.Cells[col_kh_pm.Name].Value.ToString();

            DataGridViewRow kdr = grid_kuanhao.SelectedRows[0];
            List<TTiaomaExtend> txs = (List<TTiaomaExtend>)kdr.Cells[col_kh_tms.Name].Value;
            int maxIdex;

            foreach (TTiaoma t in ts)
            {
                t.tiaoma = "";
                t.id = 0;
                maxIdex = txs.Max(r => (int?)r.idex) ?? 0;
                TTiaomaExtend tx = new TTiaomaExtend()
                {
                    idex = maxIdex + 1,
                    khidex = kdr.Index,
                    xj = XTCONSTS.TIAOMA_XINJIU.新条码,
                    tiaoma = t,
                    shuliang = 0
                };

                ((List<TTiaomaExtend>)dr.Cells[col_kh_tms.Name].Value).Add(tx);

                addTiaoma(tx);
            }
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
            DataGridViewRow kdr = null;
            if (grid_kuanhao.SelectedRows.Count != 0 )
            {
                kdr = grid_kuanhao.SelectedRows[0];
            }
            else if(grid_kuanhao.SelectedCells.Count != 0)
            {
                kdr = grid_kuanhao.SelectedCells[0].OwningRow;
            }

            if (kdr == null)
            {
                MessageBox.Show("请先选中一行款号");
                return;
            }

            TTiaomaExtend tx;
            List<TTiaomaExtend> ts = (List<TTiaomaExtend>)kdr.Cells[col_kh_tms.Name].Value;
            int maxIdex = ts.Max(r => (int?)r.idex) ?? 0;

            if (maxIdex != 0)
            {
                tx = (TTiaomaExtend)ts[ts.Count() - 1].Clone();
                tx.xj = XTCONSTS.TIAOMA_XINJIU.新条码;
                tx.idex = maxIdex + 1;
                tx.tiaoma.tiaoma = "";
                tx.tiaoma.caozuorenid = _u.id;
                tx.tiaoma.charushijian = DateTime.Now;
                tx.tiaoma.xiugaishijian = DateTime.Now;
            }
            else
            {
                tx = new TTiaomaExtend()
                {
                    idex = maxIdex + 1,
                    khidex = kdr.Index,
                    xj = XTCONSTS.TIAOMA_XINJIU.新条码,
                    tiaoma = new TTiaoma
                    {
                        tiaoma = "",
                        gyskuanhao = "",
                        yanse = "",
                        chima = "",
                        jinjia = 0,
                        shoujia = 0,
                        caozuorenid = _u.id,
                        charushijian = DateTime.Now,
                        xiugaishijian = DateTime.Now
                    },
                    shuliang = 1
                };
            }

            ts.Add(tx);
            addTiaoma(tx);
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
            int khidex = (int)e.Row.Cells[col_tm_khidex.Index].Value;
            //从款号grid找到本条码所属的款号
            TKuanhaoExtend drk = null;
            List<TTiaomaExtend> ts = null;
            TTiaomaExtend tdel = null;
            foreach (DataGridViewRow dr in grid_kuanhao.Rows)
            {
                drk = (TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value;
                //找到款号
                if (drk.idex == khidex)
                {
                    ts = (List<TTiaomaExtend>)dr.Cells[col_kh_tms.Name].Value;
                    foreach (TTiaomaExtend tex in ts)
                    {
                        //找到条码
                        if (tex.idex == idex)
                        {
                            tdel = tex;
                            break;
                        }
                    }
                }
                if (tdel != null)
                {
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
            shuaxinGridAll();
        }

        /// <summary>
        /// 刷新合并信息
        /// </summary>
        private void shuaxinGridAll()
        {
            grid_all.Rows.Clear();
            foreach (DataGridViewRow dr in grid_kuanhao.Rows)
            {
                if (dr.Cells[col_kh_tms.Name].Value == null)
                {
                    continue;
                }

                TKuanhaoExtend kex = (TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value;
                
                List<TTiaomaExtend> ts = (List<TTiaomaExtend>)dr.Cells[col_kh_tms.Name].Value;
                foreach (TTiaomaExtend tex in ts)
                {
                    addTiaomaAllMsg(kex,tex);
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
            int dayCount = Settings.Default.KHDAYCOUNT;
            int indexL = (dayCount * 31).ToString().Length;
            int day = DateTime.Now.Day;

            string AB = calcKuanhaoAB();
            int startIndex = day * dayCount;

            foreach (DataGridViewRow dr in grid_kuanhao.Rows)
            {
                //旧款不用编号
                if (XTCONSTS.KUANHAO_XINJIU.旧款.ToString().Equals(dr.Cells[col_kh_xj.Name].Value.ToString()))
                {
                    continue;
                }

                //空白的才发番，不是空白的留给用户手动命名
                string kh = (string)dr.Cells[col_kh_kh.Name].Value;
                if (string.IsNullOrEmpty(kh) || string.IsNullOrWhiteSpace(kh))
                {
                    string nkh = AB + startIndex.ToString().PadLeft(indexL,'0');
                    while(kuanhaoExists(nkh))
                    {
                        startIndex++;
                        nkh = AB + startIndex.ToString().PadLeft(indexL, '0');
                    }

                    ((TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value).kuanhao.kuanhao = nkh;
                    startIndex++;
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
        /// 根据当前年月计算款号前缀
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        private string calcKuanhaoAB()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

            char startYear = 'A';
            char startMonth = 'A';

            char A = (char)(startYear + year - Settings.Default.STARTYEAR);
            char B = (char)(startMonth + month - 1);

            return A.ToString() + B.ToString();
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

            DataGridViewRow dr = grid_kuanhao.Rows[e.RowIndex];
            List<TTiaomaExtend> ts = (List<TTiaomaExtend>)dr.Cells[col_kh_tms.Name].Value;
            //新旧
            XTCONSTS.KUANHAO_XINJIU xj = (XTCONSTS.KUANHAO_XINJIU)Enum.Parse(typeof(XTCONSTS.KUANHAO_XINJIU),dr.Cells[col_kh_xj.Name].Value.ToString());
            //款号ID
            //int khid = (int)dr.Cells["col_kh_id"].Value;
            //款号
            string kh = (string)dr.Cells[col_kh_kh.Name].Value;
            //性别
            DBCONSTS.KUANHAO_XB xb = (DBCONSTS.KUANHAO_XB)Enum.Parse(typeof(DBCONSTS.KUANHAO_XB), dr.Cells[col_kh_xb.Name].Value.ToString());
            //类型
            DBCONSTS.KUANHAO_LX lx = (DBCONSTS.KUANHAO_LX)Enum.Parse(typeof(DBCONSTS.KUANHAO_LX), dr.Cells[col_kh_lx.Name].Value.ToString());
            //品名
            string pm = dr.Cells[col_kh_pm.Name].Value.ToString();
        }

        /// <summary>
        /// 自动生成条码
        /// 当前的年月日+自动发号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_sctm_Click(object sender, EventArgs e)
        {
            string ymd = DateTime.Now.ToString("yyMMdd");
            //号码部分的长度
            int tmL = int.Parse(Settings.Default.TMDAYL);
            int startIndex = 1;
            string qz = Settings.Default.TMQIANZHUI;

            foreach (DataGridViewRow dr in grid_kuanhao.Rows)
            {
                List<TTiaomaExtend> ts = (List<TTiaomaExtend>)dr.Cells[col_kh_tms.Name].Value;
                foreach (TTiaomaExtend t in ts)
                {
                    //空白的才发番，不是空白的留给用户手动命名
                    string tm = t.tiaoma.tiaoma;
                    if (string.IsNullOrEmpty(tm) || string.IsNullOrWhiteSpace(tm))
                    {
                        string ntm = qz + ymd + startIndex.ToString().PadLeft(tmL, '0');
                        while (tiaomaExists(ntm))
                        {
                            startIndex++;
                            ntm = qz + ymd + startIndex.ToString().PadLeft(tmL, '0');
                        }

                        t.tiaoma.tiaoma = ntm;
                        startIndex++;
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
            grid_tiaoma.Rows.Clear();
            List<TTiaomaExtend> ts=null;
            if (grid_kuanhao.SelectedRows.Count != 0)
            {
                ts = (List<TTiaomaExtend>)grid_kuanhao.SelectedRows[0].Cells[col_kh_tms.Name].Value;
            }
            else if (grid_kuanhao.SelectedCells.Count != 0)
            {
                ts = (List<TTiaomaExtend>)grid_kuanhao.SelectedCells[0].OwningRow.Cells[col_kh_tms.Name].Value;
            }

            if (ts == null)
            {
                return;
            }

            foreach (TTiaomaExtend t in ts)
            {
                addTiaoma(t);
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
                List<TTiaomaExtend> ts = (List<TTiaomaExtend>)dr.Cells[col_kh_tms.Name].Value;
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
            int khidex = (int)grid_tiaoma[col_tm_khidex.Name, e.RowIndex].Value;
            //从款号grid找到本条码所属的款号
            TTiaomaExtend t = null;
            foreach (DataGridViewRow dr in grid_kuanhao.Rows)
            {
                TKuanhaoExtend drk = (TKuanhaoExtend)dr.Cells[col_kh_khex.Name].Value;
                List<TTiaomaExtend> ts = (List<TTiaomaExtend>)dr.Cells[col_kh_tms.Name].Value;
                if (drk.idex == khidex)
                {
                    t = ts.Single(r => r.idex == idex);
                    break;
                }
            }

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
            foreach (DataGridViewRow dr in grid_kuanhao.Rows)
            {
                //检查新款号
                if (dr.Cells[col_kh_xj.Name].Value.ToString().Equals(XTCONSTS.KUANHAO_XINJIU.新款.ToString()))
                {
                    //检查款号是否没有条码信息
                    if (((List<TTiaomaExtend>)dr.Cells[col_kh_tms.Name].Value).Count == 0)
                    {
                        _kuanhaoOK = false;
                        MessageBox.Show("款号没有条码信息");
                        return;
                    }

                    //是否是空白
                    string kh = (string)dr.Cells[col_kh_kh.Name].Value;
                    if (string.IsNullOrEmpty(kh) || string.IsNullOrWhiteSpace(kh))
                    {
                        _kuanhaoOK = false;
                        MessageBox.Show("款号不能为空白");
                        return;
                    }
                    else
                    {
                        nkhs.Add(kh);
                    }
                }
            }

            //去服务器验证新款号
            if (nkhs.Count() > 0)
            {
                string[] eKhs = _dc.CheckKuanhaosChongfu(nkhs.ToArray());

                if (eKhs.Length != 0)
                {
                    _kuanhaoOK = false;
                    MessageBox.Show("款号有重复");

                    shuaxinGridAll();
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
            foreach (DataGridViewRow dr in grid_kuanhao.Rows)
            {
                List<TTiaomaExtend> ts = (List<TTiaomaExtend>)dr.Cells[col_kh_tms.Name].Value;
                //新条码号才需要验证
                foreach (TTiaomaExtend t in ts)
                {
                    if (t.xj == XTCONSTS.TIAOMA_XINJIU.新条码)
                    {
                        if (string.IsNullOrEmpty(t.tiaoma.tiaoma) || string.IsNullOrWhiteSpace(t.tiaoma.tiaoma))
                        {
                            MessageBox.Show("条码不能空白");
                            return;
                        }
                        else
                        {
                            tms.Add(t.tiaoma.tiaoma);
                        }
                    }
                }
            }

            if (tms.Count > 0)
            {
                string[] eTms = _dc.CheckTiaomaChongfu(tms.ToArray());
                shuaxinGridAll();
                if (eTms.Length > 0)
                {
                    _tiaomaOK = false;                    
                    foreach (string k in eTms)
                    {
                        foreach (DataGridViewRow dr in grid_all.Rows)
                        {
                            if (k.Equals(dr.Cells[col_all_kh.Name].Value))
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
            //编辑值后，才需要验证，获得焦点，不用验证
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
    }
}
