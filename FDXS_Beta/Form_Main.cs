using FDXS_Beta.Properties;
using RawInput_dll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FDXS_Beta
{
    
    public partial class Form_Main : Form
    {
        private RawInputAddIn _rad;
        private Dlg_xiaoshou _dlgxs;
        public Form_Main()
        {
            InitializeComponent();
            gdv_jinhuomingxi.AutoGenerateColumns = false;
            gdv_xiaoshou.AutoGenerateColumns = false;
            tabControl1.SelectedTab = tabPage2;

            _dlgxs = new Dlg_xiaoshou(null);

            cht_meiri.Series.Clear();
            cht_xiaoshi.Series.Clear();
            cht_xingqi.Series.Clear();


            //校准扫描枪
            if (string.IsNullOrEmpty(Settings.Default.ScanName))
            {
                Dlg_ScanSet ds = new Dlg_ScanSet();
                ds.ShowDialog();
            }

            _rad = new RawInputAddIn(Settings.Default.ScanName, Handle, HandleScan);

            //
            //if (DateTime.Now > DateTime.ParseExact("20150410", "yyyyMMdd", null))
            //{
            //    MessageBox.Show("程序发生错误");
            //    this.Close();
            //}
        } 

        /// <summary>
        /// 进货记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button21_Click(object sender, EventArgs e)
        {
            //增加
            FDB_BetaEntities en = new FDB_BetaEntities();
            TJintuihuo tj = new TJintuihuo() { jintui = true, charushijian = DateTime.Now };
            en.TJintuihuo.Add(tj);
            en.SaveChanges();

            txb_jt_ids.Text = tj.id.ToString();
            //刷新
            shuaxinJintuihuo();
        }


        /// <summary>
        /// 查询进货记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        { 
            shuaxinJintuihuo();            
        }

        /// <summary>
        /// 删除一个进货记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_jinhuo_shanchu_Click(object sender, EventArgs e)
        {
            //删除详细信息
            DataGridViewRow dr = gdv_jinhuo.SelectedRows[0];
            int id = (int)dr.Cells[0].Value;
            FDB_BetaEntities en = new FDB_BetaEntities();
            TJintuihuo tr = en.TJintuihuo.Single(r => r.id == id);
            en.TJintuimingxi.RemoveRange(tr.TJintuimingxi);
            //删除记录
            en.TJintuihuo.Remove(tr);
            en.SaveChanges();

            //刷新
            shuaxinJintuihuo();
           
        }

        private void shuaxinJintuihuo()
        {
            FDB_BetaEntities en = new FDB_BetaEntities();

            IQueryable<TJintuihuo> data = en.TJintuihuo;
            string[] sids = txb_jt_ids.Text.Trim().Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries);
            if (sids.Length > 0)
            {
                int[] ids = sids.Select(r => int.Parse(r)).ToArray();
                data = data.Where(r=>ids.Contains(r.id));
            }
            string tm = txb_jt_tiaoma.Text.Trim();
            long tiaoma;
            if (long.TryParse(tm, out tiaoma))
            {
                data = data.Where(r => r.TJintuimingxi.Any(tr => tr.tiaoma == tiaoma));
            }

            gdv_jinhuo.DataSource = data.OrderBy(r => r.charushijian)
               .Select(r => new { id = r.id, jintui = r.jintui ? "进" : "退", jianshu = r.TJintuimingxi.Sum(mr => (Int16?)mr.shuliang), charushijian = r.charushijian }).ToList();

            if (long.TryParse(tm, out tiaoma))
            {
                foreach (DataGridViewRow dr in gdv_jinhuomingxi.Rows)
                {
                    if (dr.Cells[1].Value.Equals(tiaoma))
                    {
                        gdv_jinhuomingxi.FirstDisplayedScrollingRowIndex = dr.Index;
                        dr.Selected = true;
                    }
                }
            }
        }

        /// <summary>
        /// 显示右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdv_jinhuo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.ColumnIndex > -1 && e.RowIndex > -1)  //点击的是鼠标右键，并且不是表头
            {
                //右键选中单元格
                this.gdv_jinhuo.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                this.mn_jinhuo.Show(MousePosition.X, MousePosition.Y); //MousePosition.X, MousePosition.Y 是为了让菜单在所选行的位置显示

            }
        }

        /// <summary>
        /// 显示右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdv_jinhuomingxi_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.ColumnIndex > -1 && e.RowIndex > -1)  //点击的是鼠标右键，并且不是表头
            {
                //右键选中单元格
                this.gdv_jinhuomingxi.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                this.mn_jinhuomingxi.Show(MousePosition.X, MousePosition.Y); //MousePosition.X, MousePosition.Y 是为了让菜单在所选行的位置显示

            }
        }
        

        /// <summary>
        /// 从Excel文件导入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mni_jinhuo_excel_Click(object sender, EventArgs e)
        {
            if (dlg_excel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //取得进货id
                int jinhuoid = (int)gdv_jinhuo.SelectedRows[0].Cells[0].Value;
                bool jintui = gdv_jinhuo.SelectedRows[0].Cells[1].Value.Equals("进");
                //退货不用导入
                if (!jintui)
                {
                    MessageBox.Show("退货不用导入");
                    return;
                }

                //读取文件内容
                string file = dlg_excel.FileName;
                string[] rs = new string[]{};
                StreamReader sr = null;
                try
                {
                    sr = new StreamReader(file,Encoding.Default);
                    string datas = sr.ReadToEnd();
                    rs = datas.Split(new char[] { '\n' },StringSplitOptions.RemoveEmptyEntries);
                }
                catch
                {
                    MessageBox.Show("文件无法读取");
                    return;
                }
                finally
                {
                    if (sr != null)
                    { sr.Close(); }
                }
                int i = 0;
                List<TJintuimingxi> tjs = new List<TJintuimingxi>();
                try
                {
                    for (i = 1; i < rs.Length; i++)
                    {
                        string[] cols = rs[i].Split(new char[] { ',' });
                        if (cols.Length != 15)
                        {
                            throw new Exception("列数目不对");
                        }
                        TJintuimingxi tj = new TJintuimingxi
                        {
                            jinhuoid = jinhuoid,
                            tiaoma = Convert.ToInt64(cols[1]),
                            kuanhao = cols[2],
                            pinming = cols[4],
                            yanse = cols[7],
                            chima = cols[8],
                            shuliang = Convert.ToInt16(cols[9]),
                            jinjia = Convert.ToDecimal(cols[10]),
                            shoujia = Convert.ToDecimal(cols[11]),
                            jinhuoriqi = DateTime.ParseExact(cols[13],"yyyyMMdd",null)
                        };

                        if (tjs.Exists(r => r.tiaoma == tj.tiaoma))
                        {
                            tjs.Single(r => r.tiaoma == tj.tiaoma).shuliang++;
                        }
                        else
                        {
                            tjs.Add(tj);
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("第" + i + "行数据有问题"+"\r\n"+ex.Message);
                    return;
                }

                FDB_BetaEntities en = new FDB_BetaEntities();
                //检查条码是否已经存在
                foreach (var tj in tjs)
                {
                    if (en.TJintuihuo.Where(r => r.jintui == jintui).
                    Any(r => r.TJintuimingxi.Any(tr => tr.tiaoma == tj.tiaoma)))
                    {
                        MessageBox.Show("条码" + tj.tiaoma + "重复");
                        return;
                    }
                }
                

                //需插入的
                var exmx = en.TJintuihuo.Single(tr => tr.id == jinhuoid).TJintuimingxi.Select(r => r.tiaoma).ToList();
                var tjsi = tjs.Where(r => !exmx.Contains(r.tiaoma));
                en.TJintuimingxi.AddRange(tjsi);
                //需修改数量的
                var tjsu = tjs.Except(tjsi);
                foreach (var tp in tjsu)
                {
                    TJintuimingxi mx = en.TJintuihuo.Single(r=>r.id==jinhuoid).TJintuimingxi.Single(r => r.tiaoma == tp.tiaoma);
                    mx.shuliang += tp.shuliang;
                }
                en.SaveChanges();

                //刷新
                shuaxinJintuihuo();
                gdv_jinhuomingxi.DataSource = en.TJintuimingxi.Where(r => r.jinhuoid == jinhuoid).OrderBy(r => r.tiaoma).ToList();

            }
        }

        private void gdv_jinhuo_SelectionChanged(object sender, EventArgs e)
        {
            if (gdv_jinhuo.SelectedRows.Count == 0)
            {
                gdv_jinhuomingxi.DataSource = null;
                return;
            }

            shuaxinMingxi();
        }

        private void shuaxinMingxi()
        {
            //取得进货id
            int jinhuoid = (int)gdv_jinhuo.SelectedRows[0].Cells[0].Value;

            //刷新
            FDB_BetaEntities en = new FDB_BetaEntities();
            gdv_jinhuomingxi.DataSource = en.TJintuimingxi.Where(r => r.jinhuoid == jinhuoid).OrderBy(r => r.tiaoma).ToList();
        }



        /// <summary>
        /// 修改详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdv_jinhuomingxi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //取得被修改的信息
            DataGridViewRow dr = gdv_jinhuomingxi.Rows[e.RowIndex];
            int id = (int)dr.Cells[0].Value;
            FDB_BetaEntities en = new FDB_BetaEntities();
            TJintuimingxi tj = en.TJintuimingxi.Single(r => r.id == id);
            tj.kuanhao = (string)dr.Cells[2].Value;
            tj.pinming = (string)dr.Cells[3].Value;
            tj.yanse = (string)dr.Cells[4].Value;
            tj.chima = (string)dr.Cells[5].Value;
            tj.shuliang = (Int16)dr.Cells[6].Value;
            tj.jinjia = (decimal)dr.Cells[7].Value;
            tj.shoujia = (decimal)dr.Cells[8].Value;
            tj.jinhuoriqi = (DateTime)dr.Cells[9].Value;

            en.SaveChanges();
        }


        /// <summary>
        /// 删除一行明细记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //删除
            DataGridViewRow dr = gdv_jinhuomingxi.SelectedRows[0];
            int id = (int)dr.Cells[0].Value;
            FDB_BetaEntities en = new FDB_BetaEntities();
            TJintuimingxi tr = en.TJintuimingxi.Single(r => r.id == id);
            en.TJintuimingxi.Remove(tr);
            en.SaveChanges();

            //刷新
            int jinhuoid = (int)gdv_jinhuo.SelectedRows[0].Cells[0].Value;
            //刷新
            gdv_jinhuomingxi.DataSource = en.TJintuimingxi.Where(r => r.jinhuoid == jinhuoid).OrderBy(r => r.tiaoma).ToList();
        }

        /// <summary>
        /// 销售开单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            xiaoshoukaidan(null);            
        }

        private void xiaoshoukaidan(Int64? tm)
        {
            if (tm != null)
            {
                _dlgxs.addShangpin(tm.Value);
            }
            if (_dlgxs.Visible)
            {

            }
            else if(_dlgxs.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //刷新
                shuaxinXiaoshou();                
            }
        }

        /// <summary>
        /// 扫描枪事件
        /// </summary>
        /// <param name="tm"></param>
        private void HandleScan(string tm)
        {
            Int64 n;
            //如果是销售页面
            if (tabControl1.SelectedTab.Equals(tabPage2))
            {
                //如果是纯数字才当作条码处理
                if (Int64.TryParse(tm, out n))
                {
                    xiaoshoukaidan(n);
                }
            }
            //进退货页面
            else if (tabControl1.SelectedTab.Equals(tabPage1))
            {
                //如果焦点在查询框上
                if (txb_jt_tiaoma.Focused)
                {
                    txb_jt_tiaoma.Text = tm;
                }
                //如果选中的是一行退货信息
                else if (gdv_jinhuo.SelectedRows.Count > 0)
                {
                    if (gdv_jinhuo.SelectedRows[0].Cells[1].Value.Equals("退"))
                    {
                        //如果是纯数字
                        if (Int64.TryParse(tm, out n))
                        {
                            int jtid = (int)gdv_jinhuo.SelectedRows[0].Cells[0].Value;
                            Addtuihuo(jtid, n);
                        }
                    }
                }
            }
            //库存页面
            else if (tabControl1.SelectedTab.Equals(tabPage11))
            {
                //如果焦点在查询框上
                if (txb_kc_tiaoma.Focused)
                {
                    txb_kc_tiaoma.Text = tm;
                }
            }
        }


        /// <summary>
        /// 查询销售信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            shuaxinXiaoshou();

            gdv_xiaoshou.Focus();
        }

        private void shuaxinXiaoshou()
        {

            FDB_BetaEntities en = new FDB_BetaEntities();
            IQueryable<TXiaoshou> data = en.TXiaoshou;
            string tm = txb_xs_tiaoma.Text.Trim();
            long tiaoma;
            if (long.TryParse(tm, out tiaoma))
            {
                data = data.Where(r => r.TJintuimingxi.tiaoma == tiaoma);
            }
            
            DateTime dte = dtp_xs_rqe.Value.Date.AddDays(1);
            data = data.Where(r => r.charushijian >= dtp_xs_rqs.Value.Date && r.charushijian < dte);


            var ds = data.Select(x => new
            {
                id = x.id,
                tiaoma = x.TJintuimingxi.tiaoma,
                kuanhao = x.TJintuimingxi.kuanhao,
                pinming = x.TJintuimingxi.pinming,
                yanse = x.TJintuimingxi.yanse,
                chima = x.TJintuimingxi.chima,
                danjia = x.danjia,
                shuliang = x.shuliang,
                zhekou = x.zhekou,
                moling = x.moling,
                shijian = x.charushijian
            }).ToList().Select(r => new 
            {
                id = r.id,
                tiaoma = r.tiaoma,
                kuanhao = r.kuanhao,
                pinming = r.pinming,
                yanse = r.yanse,
                chima = r.chima,
                danjia = r.danjia,
                shuliang = r.shuliang,
                zhekou = r.zhekou,
                moling = r.moling,
                jiage = decimal.Round(r.danjia * r.shuliang * r.zhekou / 10 - r.moling, 2),
                shijian = r.shijian
            }).OrderByDescending(r => r.shijian).ToList();

            gdv_xiaoshou.DataSource = ds;

            //计算总件数和总金额
            lbl_xs_xsl.Text = (ds.Sum(r => (short?)r.shuliang)??0).ToString();
            lbl_xs_xse.Text = (ds.Sum(r => r.danjia * (short?)r.shuliang * r.zhekou / 10 - r.moling) ?? 0).ToString("0.00");
        }


        /// <summary>
        /// 删除一个销售信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //删除
            DataGridViewRow dr = gdv_xiaoshou.SelectedRows[0];
            int id = (int)dr.Cells[0].Value;
            FDB_BetaEntities en = new FDB_BetaEntities();
            TXiaoshou tr = en.TXiaoshou.Single(r => r.id == id);
            en.TXiaoshou.Remove(tr);
            en.SaveChanges();

            //刷新
            shuaxinXiaoshou();
        }

        private void gdv_xiaoshou_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && e.ColumnIndex > -1 && e.RowIndex > -1)  //点击的是鼠标右键，并且不是表头
            {
                //右键选中单元格
                this.gdv_xiaoshou.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                this.mn_xiaoshou.Show(MousePosition.X, MousePosition.Y); //MousePosition.X, MousePosition.Y 是为了让菜单在所选行的位置显示

            }
        }


        /// <summary>
        /// 增加一批退货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //增加
            FDB_BetaEntities en = new FDB_BetaEntities();
            TJintuihuo tj = new TJintuihuo() { jintui = false, charushijian = DateTime.Now };
            en.TJintuihuo.Add(tj);
            en.SaveChanges();

            txb_jt_ids.Text = tj.id.ToString();
            //刷新
            shuaxinJintuihuo();
        }

        /// <summary>
        /// 增加一个退货
        /// </summary>
        /// <param name="tiaoma"></param>
        private void Addtuihuo(int jintuihuiid,long tiaoma)
        {
            //检索得改条码的商品信息
            FDB_BetaEntities en = new FDB_BetaEntities();
            TJintuihuo jth = en.TJintuihuo.Single(r=>r.id==jintuihuiid);
            TJintuimingxi jh = en.TJintuimingxi.FirstOrDefault(r => r.tiaoma == tiaoma);
            if (jh != null)
            {
                TJintuimingxi th = jth.TJintuimingxi.SingleOrDefault(r=>r.tiaoma == tiaoma);
                if (th == null)
                {
                    TJintuimingxi nth = new TJintuimingxi
                    {
                        jinhuoid = jintuihuiid,
                        tiaoma = jh.tiaoma,
                        kuanhao = jh.kuanhao,
                        pinming = jh.pinming,
                        yanse = jh.yanse,
                        chima = jh.chima,
                        jinjia = jh.jinjia,
                        shoujia = jh.shoujia,
                        shuliang = 1,
                        jinhuoriqi = jh.jinhuoriqi
                    };

                    en.TJintuimingxi.Add(nth);
                }
                else
                {
                    th.shuliang++;
                }

                en.SaveChanges();

                shuaxinMingxi();
            }
        }


        /// <summary>
        /// 查询库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button20_Click(object sender, EventArgs e)
        {
            FDB_BetaEntities en = new FDB_BetaEntities();
            IQueryable<TJintuimingxi> data = en.TJintuimingxi;            
            string tm = txb_kc_tiaoma.Text.Trim();
            long tiaoma;
            if (long.TryParse(tm, out tiaoma))
            {
                data = data.Where(r=>r.tiaoma == tiaoma);
            }

            //进货
            var jinhuo = data.Where(r => r.TJintuihuo.jintui == true).GroupBy(r => r.tiaoma).Select(r => new
            {
                tiaoma = r.Key,        
                kuanhao = r.Max(mr => mr.kuanhao),
                pinming = r.Max(mr => mr.pinming),
                yanse = r.Max(mr => mr.yanse),
                chima = r.Max(mr => mr.chima),
                jinjia = r.Max(mr => mr.jinjia),
                shoujia = r.Max(mr => mr.shoujia),
                jinhuoriqi = r.Max(mr => mr.jinhuoriqi),
                shuliang = r.Sum(tr => tr.shuliang)
            }).ToList();

            //退货
            var tuihuo = data.Where(r => r.TJintuihuo.jintui == false).GroupBy(r => r.tiaoma).Select(r => new
            {
                tiaoma = r.Key,
                shuliang = r.Sum(tr => tr.shuliang)
            }).ToList();

            //销售
            var xiaoshou = en.TXiaoshou.Select(r=>new{r.TJintuimingxi.tiaoma,r.shuliang})
                .GroupBy(r => r.tiaoma).Select(r => new
            {
                tiaoma = r.Key,
                shuliang = r.Sum(kr => kr.shuliang)
            }).ToList();

            //库存 = 进货-退货-销售
            var kucun = jinhuo.Select(r => new
                        {
                            tiaoma = r.tiaoma,
                            kuanhao = r.kuanhao,
                            pinming = r.pinming,
                            yanse = r.yanse,
                            chima = r.chima,
                            jinjia = r.jinjia,
                            shoujia = r.shoujia,
                            jinhuoriqi = r.jinhuoriqi,
                            shuliang = r.shuliang - (tuihuo.Where(t => t.tiaoma == r.tiaoma).Sum(t => (int?)t.shuliang) ?? 0)
                                                  - (xiaoshou.Where(t => t.tiaoma == r.tiaoma).Sum(t => (int?)t.shuliang) ?? 0)
                        });
                

            gdv_kucun.DataSource = kucun.ToList();
        }


        /// <summary>
        /// 刷新报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //取数据
            FDB_BetaEntities en = new FDB_BetaEntities();
            var ddata_s = en.TXiaoshou.GroupBy(r => DbFunctions.TruncateTime(r.charushijian)).
                Select(r => new { X = r.Key.Value, Y = r.Sum(rx => rx.shuliang) }).OrderBy(r => r.X).ToList();
            var ddata_j = en.TXiaoshou.GroupBy(r => DbFunctions.TruncateTime(r.charushijian)).
                Select(r => new
                {
                    X = r.Key.Value,
                    Y = r.Sum(rx => DbFunctions.Truncate(rx.danjia * rx.shuliang * rx.zhekou / 10 - rx.moling, 2))
                }).OrderBy(r => r.X).ToList();

            var xdata_s = en.TXiaoshou.GroupBy(r => SqlFunctions.DateName("hh", r.charushijian)).
                Select(r => new { X = r.Key, Y = r.Average(rx => rx.shuliang) }).OrderBy(r => r.X).ToList();
            var xdata_j = en.TXiaoshou.GroupBy(r => SqlFunctions.DateName("hh", r.charushijian)).
                 Select(r => new
                 {
                     X = r.Key,
                     Y = r.Average(rx => DbFunctions.Truncate(rx.danjia * rx.shuliang * rx.zhekou / 10 - rx.moling, 2))
                 }).OrderBy(r => r.X).ToList();

            var wdata_s = en.TXiaoshou.GroupBy(r => SqlFunctions.DateName("dw", r.charushijian)).
                Select(r => new { X = r.Key, Y = r.Average(rx => rx.shuliang) }).OrderBy(r => r.X).ToList();
            var wdata_j = en.TXiaoshou.GroupBy(r => SqlFunctions.DateName("dw", r.charushijian)).
                 Select(r => new
                 {
                     X = r.Key,
                     Y = r.Average(rx => DbFunctions.Truncate(rx.danjia * rx.shuliang * rx.zhekou / 10 - rx.moling, 2))
                 }).OrderBy(r => r.X).ToList();

            DataTable ddt,xdt,wdt;
            if (cmb_leixing.Text== "件数")
            {
                ddt = Tool.LINQToDataTable(ddata_s);
                xdt = Tool.LINQToDataTable(xdata_s);
                wdt = changeWeek(Tool.LINQToDataTable(wdata_s));
            }
            else
            {
                ddt = Tool.LINQToDataTable(ddata_j);
                xdt = Tool.LINQToDataTable(xdata_j);
                wdt = changeWeek(Tool.LINQToDataTable(wdata_j));
            }

            //做报表
            cht_meiri.Series.Clear();
            cht_meiri.ChartAreas[0].AxisX.LabelStyle.IntervalType = DateTimeIntervalType.Days;
            cht_meiri.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            cht_meiri.ChartAreas[0].AxisX.LabelStyle.Format = "MM-dd";
            Series js = cht_meiri.Series.Add("S1");
            js.IsVisibleInLegend = false;
            js.ChartType = SeriesChartType.Column;
            js.Points.DataBind(ddt.AsEnumerable(), "X", "Y", "");

            //小时报表
            cht_xiaoshi.Series.Clear();
            Series xs = cht_xiaoshi.Series.Add("S1");
            xs.IsVisibleInLegend = false;
            xs.ChartType = SeriesChartType.Column;
            xs.Points.DataBind(xdt.AsEnumerable(), "X", "Y", "");


            //星期报表
            cht_xingqi.Series.Clear();
            Series ws = cht_xingqi.Series.Add("S1");
            ws.IsVisibleInLegend = false;
            ws.ChartType = SeriesChartType.Column;
            ws.Points.DataBind(wdt.AsEnumerable(), "X", "Y", "");
        }

        /// <summary>
        /// 将星期几转换成数字
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        DataTable changeWeek(DataTable dt)
        {
            dt.Columns.Add("week");
            foreach (DataRow dr in dt.Rows)
            {
                string w = dr["X"].ToString();
                if (w == "星期日")
                {
                    dr["week"] = 7;
                }
                else if (w == "星期一")
                {
                    dr["week"] = 1;
                }
                else if (w == "星期二")
                {
                    dr["week"] = 2;
                }
                else if (w == "星期三")
                {
                    dr["week"] = 3;
                }
                else if (w == "星期四")
                {
                    dr["week"] = 4;
                }
                else if (w == "星期五")
                {
                    dr["week"] = 5;
                }
                else if (w == "星期六")
                {
                    dr["week"] = 6;
                }
            }

            DataView dv = dt.DefaultView;
            dv.Sort = "week";
            DataTable ndt = dv.ToTable();

            return ndt;

        }


        /// <summary>
        /// 将扫描枪信息置空，以便重新设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.ScanName = "";
            Settings.Default.Save();
            MessageBox.Show("重置完毕，请关闭程序然后再次打开，校准新的扫描枪");
        }       
    }
}
