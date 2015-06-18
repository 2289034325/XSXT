using DB_FD;
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
    public partial class Dlg_xiaoshou : MyForm
    {
        private string _startTM;
        public List<TXiaoshou> XSS;
        public THuiyuan Huiyuan;
        private decimal _huiyuanZK;
        private bool _mlAuto;

        public Dlg_xiaoshou(string tm)
        {
            InitializeComponent();
            _startTM = tm;
            XSS = new List<TXiaoshou>();
            Huiyuan = null;
            _huiyuanZK = 10;
            _mlAuto = true;
        }

        /// <summary>
        /// 扫描枪事件
        /// </summary>
        /// <param name="tm">条码号</param>
        public override void OnScan(string tm)
        {            
                DBContext db = new DBContext();
                TTiaoma t = db.GetTiaomaByTmh(tm);
                if (t == null)
                {
                    MessageBox.Show("该条码不存在");
                    return;
                }

            //检查是否已经在开单表格中
            int index = 0;
            if (existsTM(tm,out index))
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
                        id=t.id,
                        tiaoma = t.tiaoma,
                        kuanhao = t.kuanhao,
                        pinming = t.pinming,
                        yanse = t.yanse,
                        chima = t.chima
                    },
                    tiaomaid = t.id,
                    danjia = t.shoujia,
                    shuliang = 1,
                    zhekou = Settings.Default.GDZK,
                    moliing = 0,
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
                xs.TTiaoma.id,
                xs.TTiaoma.tiaoma,
                xs.TTiaoma.kuanhao,
                xs.TTiaoma.pinming,
                xs.TTiaoma.yanse,
                xs.TTiaoma.chima,
                xs.shuliang,
                xs.danjia,
                xs.zhekou,
                xs.moliing,
                decimal.Round(xs.danjia*xs.shuliang*xs.zhekou/10-xs.moliing,2),
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
            //销售下拉框
            DBContext db = new DBContext();
           
                TUser[] xss = db.GetUsersByJss(new byte[] { (byte)Tool.FD.DBCONSTS.USER_XTJS.店员, (byte)Tool.FD.DBCONSTS.USER_XTJS.店长 });
                Tool.CommonFunc.InitCombbox(cmb_xsy, xss, "yonghuming", "id");
            
            //默认为当前登陆的用户
                cmb_xsy.SelectedValue = LoginInfo.User.id;

            //如果是传入了条码的构造
            if (!string.IsNullOrEmpty(_startTM))
            {
                //加入一行
                TTiaoma t = db.GetTiaomaByTmh(_startTM);
                if (t == null)
                {
                    MessageBox.Show("该条码不存在");
                    return;
                }

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
                    danjia = t.shoujia,
                    shuliang = 1,
                    zhekou = Settings.Default.GDZK,
                    moliing = 0,
                    beizhu = ""
                };

                addKaidan(xs);
            }
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
                decimal danjia = decimal.Parse(dr.Cells[col_dj.Name].Value.ToString());
                short shuliang = short.Parse(dr.Cells[col_sl.Name].Value.ToString());
                decimal zhekou = decimal.Parse(dr.Cells[col_zk.Name].Value.ToString());

                zj += decimal.Round(danjia * shuliang * zhekou / 10, 2);
            }

            //小数抹零
            decimal ml = 0;
            if (grid_kaidan.Rows.Count > 0)
            {
                //将小数零头在第一行抹去
                ml = decimal.Parse(grid_kaidan.Rows[0].Cells[col_ml.Name].Value.ToString());
                ml = decimal.Truncate(ml) + (zj - decimal.Truncate(zj));
                _mlAuto = true;
                grid_kaidan.Rows[0].Cells[col_ml.Name].Value = ml;
            }

            lbl_zongjia.Text = (zj - ml).ToString();
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
            decimal dj = decimal.Parse(grid_kaidan.Rows[e.RowIndex].Cells[col_dj.Name].Value.ToString());
            decimal zk = decimal.Parse(grid_kaidan.Rows[e.RowIndex].Cells[col_zk.Name].Value.ToString());
            decimal ml = decimal.Parse(grid_kaidan.Rows[e.RowIndex].Cells[col_ml.Name].Value.ToString());
            decimal jiage = decimal.Round(sl * dj * zk / 10 - ml, 2);

            grid_kaidan.Rows[e.RowIndex].Cells[col_yingshou.Name].Value = jiage;

            //自动抹零不需要刷新总价
            if (e.ColumnIndex == col_ml.Index && _mlAuto == true)
            {
                return;
            }

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
            DBContext db = new DBContext();
            //int[] kids = XSS.Select(r => r.tiaomaid).ToArray();
            //VKucun[] vs = db.GetKucunsByTiaomaIds(kids);

            foreach (DataGridViewRow dr in grid_kaidan.Rows)
            {
                int tmid = (int)dr.Cells[col_tmid.Name].Value;
                decimal danjia = decimal.Parse(dr.Cells[col_dj.Name].Value.ToString());
                short sl = short.Parse(dr.Cells[col_sl.Name].Value.ToString());
                decimal zk = decimal.Parse(dr.Cells[col_zk.Name].Value.ToString());
                decimal ml = decimal.Parse(dr.Cells[col_ml.Name].Value.ToString());
                string bz = dr.Cells[col_zk.Name].Value.ToString();
                string pm = dr.Cells[col_pm.Name].Value.ToString();
                decimal yingshou = decimal.Parse(dr.Cells[col_yingshou.Name].Value.ToString());

                if (sl == 0)
                {
                    MessageBox.Show(pm + "销售数量不可以为零");
                    return;
                }

                if (ml != 0 && dr.Index != 0)
                {
                    MessageBox.Show("只允许在第一行抹零");
                    return;
                }

                //if (yingshou < 0)
                //{
                //    MessageBox.Show(pm + "应收金额不应当小于0");
                //    return;
                //}

                //检查库存数量是否足够
                VKucun vx = db.GetKucunByTiaomaId(tmid);
                if (vx.shuliang < sl)
                {
                    MessageBox.Show(pm + "库存不足");
                    return;
                }

                TXiaoshou x = new TXiaoshou
                {
                    xiaoshoushijian = dp_xssj.Value,
                    xiaoshouyuan = cmb_xsy.Text,
                    huiyuanid = Huiyuan == null ? null : (int?)Huiyuan.id,
                    tiaomaid = tmid,
                    danjia = danjia,
                    shuliang = sl,
                    zhekou = zk,
                    moliing = ml,
                    beizhu = bz,
                    caozuorenid = LoginInfo.User.id,
                    charushijian = DateTime.Now,
                    xiugaishijian = DateTime.Now,
                    shangbaoshijian = null
                };

                XSS.Add(x);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
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

            string sjh = txb_sjh.Text.Trim();
            //检查是否是规则的手机号
            if (!Tool.CommonFunc.IsTelNum(sjh))
            {
                MessageBox.Show("输入的不是正常的手机号，请检查");
                return;
            }
            
            //在本地查找该会员信息，如果存在，更新其积分，如果不存在就添加该会员信息到本地
            DBContext db = new DBContext();
            THuiyuan h = db.GetHuiyuanByShoujihao(sjh);
            if (h == null)
            {
                //从数据中心查找会员信息
                JCSJData.THuiyuan jh = null;
                try
                {
                    jh = JCSJWCF.GetHuiyuanByShoujihao(sjh);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                if (jh == null)
                {
                    MessageBox.Show("会员不存在，请先注册");
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
           
            Huiyuan = h;
            //按照积分折扣表给该会员应有的折扣
            THuiyuanZK[] zks = db.GetHuiyuanZKs();
            decimal hyzk = zks.Where(r => r.jifen <= h.jifen).Max(r => (decimal?)r.zhekou) ?? 10;

            //设置页面显示
            lbl_hyxm.Text = h.xingming;
            lbl_hyjf.Text = h.jifen.ToString();
            lbl_hyzk.Text = hyzk.ToString();

            //在现有折扣基础上，乘以会员折扣
            //foreach (DataGridViewRow dr in grid_kaidan.Rows)
            //{
            //    decimal zk = decimal.Parse(dr.Cells[col_zk.Name].Value.ToString());
            //    dr.Cells[col_zk.Name].Value = decimal.Round(zk * hyzk / 10, 2);
            //}

            //刷新总价
            //refreshZongjia();
        }

        /// <summary>
        /// 注册会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_zchy_Click(object sender, EventArgs e)
        {
            //检查手机号是否正常
            string sjh = txb_sjh.Text.Trim();
            //检查是否是规则的手机号
            if (!Tool.CommonFunc.IsTelNum(sjh))
            {
                MessageBox.Show("输入的不是正常的手机号，请检查");
                return;
            }

            JCSJData.THuiyuan h = new JCSJData.THuiyuan 
            {
                shoujihao = sjh,
                xingming = "",
                xingbie = (byte)Tool.JCSJ.DBCONSTS.HUIYUAN_XB.女,
                shengri = DateTime.Now,
                beizhu = ""
            };

            //注册会员
            try
            {
                JCSJWCF.HuiyuanZhuce(h);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            txb_sjh_KeyDown(null, new KeyEventArgs(Keys.Enter));
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
            DBContext db = new DBContext();

            TTiaoma t = db.GetTiaomaByTmh(tmh);
            if (t == null)
            {
                MessageBox.Show("该条码不存在");
                return;
            }

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
                    danjia = t.shoujia,
                    shuliang = 1,
                    zhekou = Settings.Default.GDZK,
                    moliing = 0,
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
            _mlAuto = false;

            if (grid_kaidan.Rows.Count == 0)
            {
                return;
            }
            //计算总价的个位数
            decimal zj = 0;
            foreach (DataGridViewRow dr in grid_kaidan.Rows)
            {
                decimal danjia = decimal.Parse(dr.Cells[col_dj.Name].Value.ToString());
                short shuliang = short.Parse(dr.Cells[col_sl.Name].Value.ToString());
                decimal zhekou = decimal.Parse(dr.Cells[col_zk.Name].Value.ToString());

                zj += decimal.Round(danjia * shuliang * zhekou / 10, 2);
            }
            decimal gw = decimal.Truncate(zj % 10);
            decimal ml = decimal.Parse(grid_kaidan.Rows[0].Cells[col_ml.Name].Value.ToString());
            //抹零
            if (chk_gwml.Checked)
            {

                ml = gw + ml - decimal.Truncate(ml);
            }
            //取消抹零
            else
            {
                ml = ml - decimal.Truncate(ml);
            }
            grid_kaidan.Rows[0].Cells[col_ml.Name].Value = ml;

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
            if (chk_gwml.Checked)
            {
                //除了备注，修改值的时候，先要取消抹零状态
                if (e.ColumnIndex != col_bz.Index)
                {
                    MessageBox.Show("如果要手动输入数值，请先点击一下【个位抹零】按钮，取消自动抹零状态。");
                    e.Cancel = true;
                    return;
                }
            }

            if (e.ColumnIndex == col_ml.Index)
            {
                //只允许修改第一行的抹零值
                if (e.RowIndex == 0)
                {
                    _mlAuto = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
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
    }
}