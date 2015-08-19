using DB_FD;
using DB_FD.Models;
using FDXS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace FDXS
{
    public partial class Form_Kaidan : MyForm
    {
        //private string _startTM;
        private List<TXiaoshou> _XSS;
        private THuiyuan _Huiyuan;
        //private decimal _huiyuanZK;
        //private bool _mlAuto;

        public Form_Kaidan()
        {
            InitializeComponent();
            //_startTM = tm;
            _XSS = new List<TXiaoshou>();
            _Huiyuan = null;
            //_huiyuanZK = 10;
            //_mlAuto = true;

            this.Text = "开单[当前登陆:" + RuntimeInfo.LoginUser.yonghuming + "]";
            if (RuntimeInfo.LoginUser.juese == (byte)Tool.FD.DBCONSTS.USER_XTJS.店员)
            {
                //店员不允许关闭窗口
                //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                //this.ShowInTaskbar = false;
            }
        }

        /// <summary>
        /// 扫描枪事件
        /// </summary>
        /// <param name="tm">条码号</param>
        public override void OnScan(string tm)
        {
            DBContext db = IDB.GetDB();
            TTiaoma t = db.GetTiaomaByTmh(tm);
            if (t == null)
            {
                MessageBox.Show("该条码不存在");
                return;
            }

            //检查是否已经在开单表格中
            int index = 0;
            if (existsTM(tm, out index))
            {
                //在原有的行上数量加1
                short sl = short.Parse(grid_kaidan.Rows[index].Cells[col_sl.Name].Value.ToString());
                grid_kaidan.Rows[index].Cells[col_sl.Name].Value = (short)(sl + 1);
            }
            else
            {
                TXiaoshou xs = new TXiaoshou
                {
                    TTiaoma = new TTiaoma
                    {
                        id = t.id,
                        tiaoma = t.tiaoma,
                        kuanhao = t.kuanhao,
                        pinming = t.pinming,
                        yanse = t.yanse,
                        chima = t.chima
                    },
                    tiaomaid = t.id,
                    jinjia = t.jinjia,
                    shoujia = t.shoujia,
                    shuliang = 1,
                    zhekou = Settings.Default.GDZK,
                    moling = 0,
                    beizhu = ""
                };

                addKaidan(xs);
            }
        }

        /// <summary>
        /// 增加一行开单
        /// </summary>
        /// <param name="xs"></param>
        private void addKaidan(TXiaoshou xs)
        {
            grid_kaidan.Rows.Add(new object[] 
            {
                xs.TTiaoma == null?null:xs.tiaomaid,
                xs.TTiaoma == null?"":xs.TTiaoma.tiaoma,
                xs.TTiaoma == null?"":xs.TTiaoma.kuanhao,
                xs.TTiaoma == null?"":xs.TTiaoma.pinming,
                xs.TTiaoma == null?"":xs.TTiaoma.yanse,
                xs.TTiaoma == null?"":xs.TTiaoma.chima,
                xs.shuliang,
                xs.jinjia,
                xs.shoujia,
                xs.zhekou,
                xs.moling,
                xs.jine,
                xs.beizhu
            });
        }

        /// <summary>
        /// 检查条码是否已经在开单表格中
        /// </summary>
        /// <param name="tm"></param>
        /// <returns></returns>
        private bool existsTM(string tm,out int index)
        {
            index = 0;
            foreach (DataGridViewRow dr in grid_kaidan.Rows)
            {
                if (tm.Equals(dr.Cells[col_tm.Name].Value))
                {
                    index = dr.Index;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_xiaoshou_Load(object sender, EventArgs e)
        {
            //折扣按钮
            btn_7z.Visible = false;
            btn_75z.Visible = false;
            btn_8z.Visible = false;
            btn_85z.Visible = false;
            btn_9z.Visible = false;

            //销售下拉框
            DBContext db = IDB.GetDB();

            TUser[] xss = db.GetUsersByJss(new byte[] { (byte)Tool.FD.DBCONSTS.USER_XTJS.店员, (byte)Tool.FD.DBCONSTS.USER_XTJS.店长 });
            Tool.CommonFunc.InitCombbox(cmb_xsy, xss, "yonghuming", "id");

            //默认为当前登陆的用户
            cmb_xsy.SelectedValue = RuntimeInfo.LoginUser.id;

            //今日销售
            refreshJinriXS();

            //如果是传入了条码的构造
            //if (!string.IsNullOrEmpty(_startTM))
            //{
            //    //加入一行
            //    TTiaoma t = db.GetTiaomaByTmh(_startTM);
            //    if (t == null)
            //    {
            //        MessageBox.Show("该条码不存在");
            //        return;
            //    }

            //    TXiaoshou xs = new TXiaoshou
            //    {
            //        TTiaoma = new TTiaoma
            //        {
            //            id = t.id,
            //            tiaoma = t.tiaoma,
            //            kuanhao = t.kuanhao,
            //            pinming = t.pinming,
            //            yanse = t.yanse,
            //            chima = t.chima
            //        },
            //        tiaomaid = t.id,
            //        danjia = t.shoujia,
            //        shuliang = 1,
            //        zhekou = Settings.Default.GDZK,
            //        moling = 0,
            //        beizhu = ""
            //    };

            //    addKaidan(xs);
            //}
        }

        /// <summary>
        /// 今日销售
        /// </summary>
        private void refreshJinriXS()
        {
            DBContext db = IDB.GetDB();
            TXiaoshou[] jrxss = db.GetXiaoshousByCond("", "", DateTime.Now.Date, DateTime.Now.Date.AddDays(1));
            int xsl = jrxss.Sum(r => r.shuliang);
            decimal xse = jrxss.Sum(r => r.jine);
            lbl_jrxl.Text = xsl.ToString();
            lbl_jrxse.Text = xse.ToString();
        }

        /// <summary>
        /// 删除一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kaidan_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //重新计算活动折扣

            //刷新总价
            refreshZongjia();
        }

        /// <summary>
        /// 添加一行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kaidan_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //重新计算活动折扣

            //刷新总价
            refreshZongjia();
        }

        /// <summary>
        /// 计算总价
        /// </summary>
        private void refreshZongjia()
        {
            decimal zj = 0;
            foreach (DataGridViewRow dr in grid_kaidan.Rows)
            {
                decimal danjia = decimal.Parse(dr.Cells[col_sj.Name].Value.ToString());
                short shuliang = short.Parse(dr.Cells[col_sl.Name].Value.ToString());
                decimal zhekou = decimal.Parse(dr.Cells[col_zk.Name].Value.ToString());
                decimal moling = decimal.Parse(dr.Cells[col_ml.Name].Value.ToString());

                zj += decimal.Round(danjia * shuliang * zhekou / 10 - moling, 2);
            }

            //抹零
            //decimal ml = 0;
            //if (grid_kaidan.Rows.Count > 0)
            //{
            //    //将小数零头在第一行抹去
            //    ml = decimal.Parse(grid_kaidan.Rows[0].Cells[col_ml.Name].Value.ToString());
            //    ml = decimal.Truncate(ml) + (zj - decimal.Truncate(zj));
            //    //_mlAuto = true;
            //    grid_kaidan.Rows[0].Cells[col_ml.Name].Value = ml;
            //}

            lbl_zongjia.Text = zj.ToString();
        }

        /// <summary>
        /// 编辑开单信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kaidan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || e.ColumnIndex == col_yingshou.Index)
            {
                return;
            }

            //刷新应收列
            short sl = short.Parse(grid_kaidan.Rows[e.RowIndex].Cells[col_sl.Name].Value.ToString());
            decimal dj = decimal.Parse(grid_kaidan.Rows[e.RowIndex].Cells[col_sj.Name].Value.ToString());
            decimal zk = decimal.Parse(grid_kaidan.Rows[e.RowIndex].Cells[col_zk.Name].Value.ToString());
            decimal ml = decimal.Parse(grid_kaidan.Rows[e.RowIndex].Cells[col_ml.Name].Value.ToString());
            decimal jiage = decimal.Round(sl * dj * zk / 10 - ml, 2);

            grid_kaidan.Rows[e.RowIndex].Cells[col_yingshou.Name].Value = jiage;

            //自动抹零不需要刷新总价
            //if (e.ColumnIndex == col_ml.Index)
            //{
            //    return;
            //}

            refreshZongjia();
        }

        /// <summary>
        /// 使用活动折扣
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_hdzk_Click(object sender, EventArgs e)
        {
            //刷新总价
            refreshZongjia();
        }

        /// <summary>
        /// 确定开单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (grid_kaidan.Rows.Count == 0)
            {
                return;
            }

            //销售员不能空白
            if (string.IsNullOrEmpty(cmb_xsy.Text))
            {
                MessageBox.Show("请选择销售员");
                return;
            }

            //将表格数据组装成实例
            DBContext db = IDB.GetDB();
            foreach (DataGridViewRow dr in grid_kaidan.Rows)
            {
                int? tmid = null;
                if (dr.Cells[col_tmid.Name].Value != null)
                {
                    if (!string.IsNullOrEmpty(dr.Cells[col_tmid.Name].Value.ToString().Trim()))
                    {
                        tmid = (int)dr.Cells[col_tmid.Name].Value;
                    }
                }
                decimal jj = decimal.Parse(dr.Cells[col_jj.Name].Value.ToString());
                decimal sj = decimal.Parse(dr.Cells[col_sj.Name].Value.ToString());
                short sl = short.Parse(dr.Cells[col_sl.Name].Value.ToString());
                decimal zk = decimal.Parse(dr.Cells[col_zk.Name].Value.ToString());
                decimal ml = decimal.Parse(dr.Cells[col_ml.Name].Value.ToString());
                string bz = dr.Cells[col_bz.Name].Value.ToString();
                string pm = dr.Cells[col_pm.Name].Value.ToString();
                decimal yingshou = decimal.Parse(dr.Cells[col_yingshou.Name].Value.ToString());

                if (sl == 0)
                {
                    MessageBox.Show(pm + "销售数量不可以为零");
                    return;
                }

                //if (ml != 0 && dr.Index != 0)
                //{
                //    MessageBox.Show("只允许在第一行抹零");
                //    return;
                //}

                //if (yingshou < 0)
                //{
                //    MessageBox.Show(pm + "应收金额不应当小于0");
                //    return;
                //}

                //未知条码不检测库存
                if (tmid != null)
                {
                    //检查库存数量是否足够
                    VKucun vx = db.GetKucunByTiaomaId(tmid.Value);
                    if (vx.shuliang < sl)
                    {
                        MessageBox.Show(pm + "库存不足");
                        return;
                    }
                }


                TXiaoshou x = new TXiaoshou
                {
                    xiaoshoushijian = dp_xssj.Checked ? dp_xssj.Value : DateTime.Now,
                    xiaoshouyuan = cmb_xsy.Text,
                    huiyuanid = _Huiyuan == null ? null : (int?)_Huiyuan.id,
                    tiaomaid = tmid,
                    jinjia = jj,
                    shoujia = sj,
                    shuliang = sl,
                    zhekou = zk,
                    moling = ml,
                    beizhu = bz,
                    caozuorenid = RuntimeInfo.LoginUser.id,
                    charushijian = DateTime.Now,
                    xiugaishijian = DateTime.Now,
                    shangbaoshijian = null
                };

                _XSS.Add(x);
            }

            //保存到数据库
            TXiaoshou[] nxss = db.InsertXiaoshous(_XSS.ToArray());
            //将积分加给会员
            if (_Huiyuan != null)
            {
                decimal zj = _XSS.Sum(r => r.jine);
                db.UpdateAddHuiyuanJF(_Huiyuan.id, zj);
            }

            //打印小票
            xiaopiao();
            MessageBox.Show("开单成功");

            //清理变量，为下次开单做准备
            grid_kaidan.Rows.Clear();
            _XSS = new List<TXiaoshou>();
            txb_tiaoma.Text = "";
            lbl_zongjia.Text = "总价";
            lbl_zhaoling.Text = "找零";
            dp_xssj.Checked = false;
            _Huiyuan = null;
            //_mlAuto = true;
            chk_gwml.Checked = false;
            txb_sjh.Text = "";
            lbl_hyjf.Text = "";
            lbl_hyxm.Text = "";
            lbl_hyzk.Text = "";
            txb_shishou.Text = "";


            refreshJinriXS();
        }

        /// <summary>
        /// 打印小票
        /// </summary>
        private void xiaopiao()
        {
            PrintController printController = new StandardPrintController();
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintController = printController;
            printDocument.PrintPage += new PrintPageEventHandler(this.printDocument_PrintPage);

            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            try
            {
                printDocument.Print();
            }
            catch (Exception ex)
            {
                printDocument.PrintController.OnEndPrint(printDocument, new PrintEventArgs());
                throw ex;
            }
        }
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics printG = e.Graphics; //获得绘图对象 
            Font printFont = new System.Drawing.Font("宋体", 9);
            float yPosition = 0;
            float leftMargin = 0;
            float cH = printFont.GetHeight(printG);
            SolidBrush myBrush = new SolidBrush(Color.Black);//刷子

            printG.DrawString("      ", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            yPosition += cH;
            printG.DrawString(Settings.Default.FDMC, printFont, myBrush, leftMargin, yPosition, new StringFormat());
            yPosition += cH;
            yPosition += cH;
            printG.DrawString("**********欢迎光临**********", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            yPosition += cH;
            printG.DrawString("品名", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            printG.DrawString("数量", printFont, myBrush, leftMargin + 80, yPosition, new StringFormat());
            printG.DrawString("单价", printFont, myBrush, leftMargin + 110, yPosition, new StringFormat());
            printG.DrawString("金额", printFont, myBrush, leftMargin + 145, yPosition, new StringFormat());
            yPosition += cH;
            foreach (TXiaoshou x in _XSS)
            {
                string tiaoma = x.TTiaoma == null ? "" : x.TTiaoma.tiaoma;
                string pinming = x.TTiaoma == null ? "" : x.TTiaoma.pinming;
                short shuliang = x.shuliang;
                decimal danjia = x.shoujia;
                decimal jine = x.jine;
                printG.DrawString(tiaoma, printFont, myBrush, leftMargin, yPosition, new StringFormat());
                printG.DrawString(shuliang.ToString(), printFont, myBrush, leftMargin + 90, yPosition, new StringFormat());
                printG.DrawString(danjia.ToString("#"), printFont, myBrush, leftMargin + 110, yPosition, new StringFormat());
                printG.DrawString(jine.ToString("#"), printFont, myBrush, leftMargin + 145, yPosition, new StringFormat());
                yPosition += cH;
                printG.DrawString(pinming, printFont, myBrush, leftMargin, yPosition, new StringFormat());
                yPosition += cH;
            }
            printG.DrawString("_______________________________", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            yPosition += cH;
            printG.DrawString("小计", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            printG.DrawString(_XSS.Sum(x => x.shoujia * x.shuliang).ToString("0.00"), printFont, myBrush, leftMargin + 135, yPosition, new StringFormat());
            yPosition += cH;
            printG.DrawString("优惠", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            printG.DrawString(_XSS.Sum(x => x.shoujia * x.shuliang * (10 - x.zhekou) / 10 + x.moling).ToString("0.00"), printFont, myBrush, leftMargin + 135, yPosition, new StringFormat());
            yPosition += cH;
            printG.DrawString("应付", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            printG.DrawString((_XSS.Sum(x => x.jine)).ToString("0.00"), printFont, myBrush, leftMargin + 135, yPosition, new StringFormat());
            yPosition += cH;
            printG.DrawString("交易时间", printFont, myBrush, leftMargin, yPosition, new StringFormat());
            printG.DrawString(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), printFont, myBrush, leftMargin + 65, yPosition, new StringFormat());

            e.HasMorePages = false;
        }

        /// <summary>
        /// 按下回车，匹配会员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_sjh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            new Tool.ActionMessageTool(txb_sjh_KeyDown_sync, true).Start();
        }

        private void txb_sjh_KeyDown_sync(Tool.ActionMessageTool.ShowMsg ShowMsg)
        {
            try
            {
                string sjh = txb_sjh.Text.Trim();
                //如果是空，取消清空会员变量
                if (string.IsNullOrEmpty(sjh))
                {
                    _Huiyuan = null;
                    lbl_hyxm.Text = "";
                    lbl_hyjf.Text = "";
                    return;
                }

                //检查是否是规则的手机号
                if (!Tool.CommonFunc.IsTelNum(sjh))
                {
                    ShowMsg("输入的不是正常的手机号，请检查", true);
                    return;
                }

                //在本地查找该会员信息，如果存在，更新其积分，如果不存在就添加该会员信息到本地
                DBContext db = IDB.GetDB();
                THuiyuan h = db.GetHuiyuanByShoujihao(sjh);
                if (h == null)
                {
                    //从数据中心查找会员信息
                    JCSJData.THuiyuan jh = JCSJWCF.GetHuiyuanByShoujihao(sjh);

                    if (jh == null)
                    {
                        ShowMsg("会员不存在，请先注册", true);
                        return;
                    }

                    h = new THuiyuan
                    {
                        id = jh.id,
                        fendianid = jh.fendianid,
                        shoujihao = jh.shoujihao,
                        xingming = jh.xingming,
                        xingbie = jh.xingbie,
                        shengri = jh.shengri,
                        jifen = jh.jifen,
                        jfgxshijian = jh.jfjsshijian,
                        xxgxshijian = DateTime.Now
                    };

                    //保存到本地
                    db.InsertHuiyuan(h);
                }

                _Huiyuan = h;
                //按照积分折扣表给该会员应有的折扣
                //THuiyuanZK[] zks = db.GetHuiyuanZKs();
                //decimal hyzk = zks.Where(r => r.jifen <= h.jifen).Max(r => (decimal?)r.zhekou) ?? 10;

                //设置页面显示
                lbl_hyxm.Text = h.xingming;
                lbl_hyjf.Text = h.jifen.ToString();
                //lbl_hyzk.Text = hyzk.ToString();
            }
            catch (Exception ex)
            {
                Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                ShowMsg(ex.Message, true);
            }
        }

        /// <summary>
        /// 注册会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_zchy_Click(object sender, EventArgs e)
        {
            new Tool.ActionMessageTool(btn_zchy_Click_sync, false).Start();
        }

        private void btn_zchy_Click_sync(Tool.ActionMessageTool.ShowMsg ShowMsg)
        {
            try
            {
                //检查手机号是否正常
                string sjh = txb_sjh.Text.Trim();
                //检查是否是规则的手机号
                if (!Tool.CommonFunc.IsTelNum(sjh))
                {
                    ShowMsg("输入的不是正常的手机号，请检查", true);
                    return;
                }

                JCSJData.THuiyuan jh = new JCSJData.THuiyuan
                {
                    shoujihao = sjh,
                    xingming = "",
                    xingbie = (byte)Tool.JCSJ.DBCONSTS.HUIYUAN_XB.女,
                    shengri = DateTime.Now,
                    beizhu = ""
                };

                //注册会员
                jh = JCSJWCF.HuiyuanZhuce(jh);

                THuiyuan lh = new THuiyuan
                {
                    id = jh.id,
                    fendianid = jh.fendianid,
                    shoujihao = jh.shoujihao,
                    xingming = jh.xingming,
                    xingbie = jh.xingbie,
                    shengri = jh.shengri,
                    jifen = jh.jifen,
                    jfgxshijian = jh.jfjsshijian,
                    xxgxshijian = DateTime.Now
                };

                //保存到本地
                DBContext db = IDB.GetDB();
                db.InsertHuiyuan(lh);

                ShowMsg("注册成功", false);
            }
            catch (Exception ex)
            {
                Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                ShowMsg(ex.Message, true);

                return;
            }

            //刷新出新会员信息
            txb_sjh_KeyDown_sync(ShowMsg);
        }

        /// <summary>
        /// 手动输入条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_tiaoma_KeyDown(object sender, KeyEventArgs e)
        {
            //回车事件
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            string tmh = txb_tiaoma.Text.Trim();
            //如果输入不够6位，不做处理
            if (tmh.Length < 6)
            {
                return;
            }

            DBContext db = IDB.GetDB();
            TTiaoma[] tms = db.GetTiaomaByTmhEndsWith(tmh);
            if (tms.Length > 1)
            {
                MessageBox.Show("检测到相似的条码不止一个，请输入完整的条码");
                return;
            }
            if (tms.Length < 1)
            {
                MessageBox.Show("该条码不存在");
                return;
            }

            TTiaoma t = tms[0];
            //检查是否已经在开单表格中
            int index = 0;
            if (existsTM(tmh, out index))
            {
                //在原有的行上数量加1
                short sl = (short)grid_kaidan.Rows[index].Cells[col_sl.Name].Value;
                grid_kaidan.Rows[index].Cells[col_sl.Name].Value = (short)(sl + 1);
            }
            else
            {
                TXiaoshou xs = new TXiaoshou
                {
                    TTiaoma = new TTiaoma
                    {
                        id = t.id,
                        tiaoma = t.tiaoma,
                        kuanhao = t.kuanhao,
                        pinming = t.pinming,
                        yanse = t.yanse,
                        chima = t.chima
                    },
                    tiaomaid = t.id,
                    jinjia = t.jinjia,
                    shoujia = t.shoujia,
                    shuliang = 1,
                    zhekou = Settings.Default.GDZK,
                    moling = 0,
                    beizhu = ""
                };

                addKaidan(xs);
            }
        }

        /// <summary>
        /// 显示积分折扣规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_jfzk_Click(object sender, EventArgs e)
        {
            Form_JifenZhekou jf = new Form_JifenZhekou();
            jf.ShowDialog();
        }

        /// <summary>
        /// 个位抹零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chk_gwml_CheckedChanged(object sender, EventArgs e)
        {
            //手动抹零
            //_mlAuto = false;

            if (grid_kaidan.Rows.Count == 0)
            {
                return;
            }
            //计算总价的个位数
            //decimal zj = 0;
            //foreach (DataGridViewRow dr in grid_kaidan.Rows)
            //{
            //    decimal danjia = decimal.Parse(dr.Cells[col_dj.Name].Value.ToString());
            //    short shuliang = short.Parse(dr.Cells[col_sl.Name].Value.ToString());
            //    decimal zhekou = decimal.Parse(dr.Cells[col_zk.Name].Value.ToString());

            //    zj += decimal.Round(danjia * shuliang * zhekou / 10, 2);
            //}
            //decimal gw = decimal.Truncate(zj % 10);
            //decimal ml = decimal.Parse(grid_kaidan.Rows[0].Cells[col_ml.Name].Value.ToString());
            //抹零
            //if (chk_gwml.Checked)
            //{
            //    ml = gw + ml - decimal.Truncate(ml);
            //}
            ////取消抹零
            //else
            //{
            //    ml = ml - decimal.Truncate(ml);
            //}
            //grid_kaidan.Rows[0].Cells[col_ml.Name].Value = ml;

            foreach (DataGridViewRow dr in grid_kaidan.Rows)
            {
                decimal danjia = decimal.Parse(dr.Cells[col_sj.Name].Value.ToString());
                short shuliang = short.Parse(dr.Cells[col_sl.Name].Value.ToString());
                decimal zhekou = decimal.Parse(dr.Cells[col_zk.Name].Value.ToString());

                decimal jg = decimal.Round(danjia * shuliang * zhekou / 10, 2);
                decimal gw = decimal.Truncate(jg % 10);
                decimal ml = 0;
                if (chk_gwml.Checked)
                {
                    ml = gw + jg - decimal.Truncate(jg);
                }
                //取消抹零
                else
                {
                    ml = 0;
                }

                dr.Cells[col_ml.Name].Value = ml;
            }

            //刷新总价
            refreshZongjia();
        }

        /// <summary>
        /// 手动修改抹零时，留下标记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kaidan_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //如果要手动抹零，就先要取消自动个位抹零按钮的按下状态
            //if (chk_gwml.Checked)
            //{
            //    //除了备注，修改值的时候，先要取消抹零状态
            //    if (e.ColumnIndex != col_bz.Index)
            //    {
            //        MessageBox.Show("如果要手动输入数值，请先点击一下【自动抹零】按钮，取消自动抹零状态。");
            //        e.Cancel = true;
            //        return;
            //    }
            //}

            //if (e.ColumnIndex == col_ml.Index)
            //{
            //    //只允许修改第一行的抹零值
            //    if (e.RowIndex == 0)
            //    {
            //        _mlAuto = false;
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //    }
            //}
        }

        private void btn_7z_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dr in grid_kaidan.Rows)
            {
                dr.Cells[col_zk.Name].Value = 7;
            }
        }

        private void btn_75z_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dr in grid_kaidan.Rows)
            {
                dr.Cells[col_zk.Name].Value = 7.5;
            }
        }

        private void btn_8z_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dr in grid_kaidan.Rows)
            {
                dr.Cells[col_zk.Name].Value = 8;
            }
        }

        private void btn_85z_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dr in grid_kaidan.Rows)
            {
                dr.Cells[col_zk.Name].Value = 8.5;
            }
        }

        private void btn_9z_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dr in grid_kaidan.Rows)
            {
                dr.Cells[col_zk.Name].Value = 9;
            }
        }

        /// <summary>
        /// 填写实收金额，计算找零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_shishou_TextChanged(object sender, EventArgs e)
        {
            decimal ys, ss;
            if (decimal.TryParse(lbl_zongjia.Text, out ys))
            {
                if (decimal.TryParse(txb_shishou.Text.Trim(), out ss))
                {
                    lbl_zhaoling.Text = (ss - ys).ToString();
                    return;
                }
            }

            lbl_zhaoling.Text = "找零";
        }

        /// <summary>
        /// 关闭的时候检查权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_xiaoshou_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// 更改登陆用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_userchange_Click(object sender, EventArgs e)
        {
            //清除配置记录，并关闭当前进程
            Settings.Default.AutoLoginDlm = "";
            Settings.Default.AutoLoginMm = "";
            Settings.Default.Save();

            Application.Restart();
        }

        /// <summary>
        /// 显示折扣按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_zkview_Click(object sender, EventArgs e)
        {
            if (btn_7z.Visible)
            {
                btn_7z.Visible = false;
                btn_75z.Visible = false;
                btn_8z.Visible = false;
                btn_85z.Visible = false;
                btn_9z.Visible = false;
            }
            else
            {
                btn_7z.Visible = true;
                btn_75z.Visible = true;
                btn_8z.Visible = true;
                btn_85z.Visible = true;
                btn_9z.Visible = true;
            }
        }

        /// <summary>
        /// 无条码商品开单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_wutiaoma_Click(object sender, EventArgs e)
        {

            Dlg_Wutiaoma dw = new Dlg_Wutiaoma();
            if (dw.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string pm = dw.pm;
                string ys = dw.ys;
                string cm = dw.cm;
                decimal jj = dw.jj;
                decimal sj = dw.sj;

                TXiaoshou xs = new TXiaoshou
                {
                    tiaomaid = null,
                    jinjia = jj,
                    shoujia = sj,
                    shuliang = 1,
                    zhekou = Settings.Default.GDZK,
                    moling = 0,
                    beizhu = string.Format("{0}-{1}-{2}", pm, ys, cm)
                };

                addKaidan(xs);
            }
        }
    }
}