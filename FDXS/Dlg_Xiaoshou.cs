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
        private TUser _user;
        public THuiyuan _huiyuan;
        private decimal _huiyuanZK;

        /// <summary>
        /// 基础数据WCF服务
        /// </summary>
        private JCSJData.DataServiceClient _jdc;

        public Dlg_xiaoshou(string tm,TUser user)
        {
            InitializeComponent();
            _startTM = tm;
            XSS = new List<TXiaoshou>();
            _user = user;
            _huiyuan = null;
            _huiyuanZK = 10;
            _jdc = null;
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
                short sl = (short)grid_kaidan.Rows[index].Cells[col_sl.Name].Value;
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
                xs.danjia,
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
                cmb_xsy.SelectedValue = _user.id;

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
                decimal moling = decimal.Parse(dr.Cells[col_ml.Name].Value.ToString());

                zj += decimal.Round(danjia * shuliang * zhekou / 10 - moling, 2);
            }

            lbl_zongjia.Text = zj.ToString();
        }

        /// <summary>
        /// 编辑开单信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_kaidan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //刷新总价
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
        /// 总价个位数抹零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_gwml_Click(object sender, EventArgs e)
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

            //将表格数据组装成实例
            foreach (DataGridViewRow dr in grid_kaidan.Rows)
            {
                int tmid = (int)dr.Cells[col_tmid.Name].Value;
                decimal danjia = decimal.Parse(dr.Cells[col_dj.Name].Value.ToString());
                short sl = short.Parse(dr.Cells[col_sl.Name].Value.ToString());
                decimal zk = decimal.Parse(dr.Cells[col_zk.Name].Value.ToString());
                decimal ml = decimal.Parse(dr.Cells[col_ml.Name].Value.ToString());
                string bz = dr.Cells[col_zk.Name].Value.ToString();
                TXiaoshou x = new TXiaoshou
                {
                    xiaoshoushijian = dp_xssj.Value,
                    xiaoshouyuan = cmb_xsy.SelectedText,
                    huiyuanid = _huiyuan == null ? null : (int?)_huiyuan.id,
                    tiaomaid = tmid,
                    danjia = danjia,
                    shuliang = sl,
                    zhekou = zk,
                    moliing = ml,
                    beizhu = bz,
                    caozuorenid = _user.id,
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

            //先从本地查找
            DBContext db = new DBContext();
            THuiyuan h = db.GetHuiyuanByShoujihao(sjh);
            if (h == null)
            {
                //本地没有，从基础数据服务查询
                loginJCSJ();

                JCSJData.THuiyuan jh = _jdc.GetHuiyuanByShoujihao(sjh);

                if (jh == null)
                {
                    MessageBox.Show("会员不存在，请先注册");
                    return;
                }

                h = new THuiyuan 
                {
                    id=jh.id,
                    fendianid = jh.fendianid,
                    shoujihao = jh.shoujihao,
                    xingming = jh.xingming,
                    xingbie =jh.xingbie,
                    shengri = jh.shengri,
                    jifen = jh.jifen,
                    jfgxshijian = jh.jfjsshijian,
                    xxgxshijian = DateTime.Now
                };

                _huiyuan = h;

                //保存到本地
                db.InsertHuiyuan(h);
            }
            
            //按照积分折扣表给该会员应有的折扣
            THuiyuanZK[] zks = db.GetHuiyuanZKs();
            decimal hyzk = zks.Where(r => r.jifen <= h.jifen).Max(r => (decimal?)r.zhekou) ?? 10;

            //设置页面显示
            lbl_hyxm.Text = h.xingming;
            lbl_hyjf.Text = h.jifen.ToString();
            lbl_hyzk.Text = hyzk.ToString();

            //在现有折扣基础上，乘以会员折扣
            foreach (DataGridViewRow dr in grid_kaidan.Rows)
            {
                decimal zk = decimal.Parse(dr.Cells[col_zk.Name].Value.ToString());
                dr.Cells[col_zk.Name].Value = decimal.Round(zk * hyzk / 10, 2);
            }

            //刷新总价
            refreshZongjia();
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

            //登陆数据中心
            loginJCSJ();

            //注册
            _jdc.HuiyuanZhuce(h);

            txb_sjh_KeyDown(null, new KeyEventArgs(Keys.Enter));
        }

        /// <summary>
        /// 登陆到基础数据服务系统
        /// </summary>
        private void loginJCSJ()
        {
            if (_jdc == null)
            {
                _jdc = new JCSJData.DataServiceClient();
                _jdc.FDZHLogin(Settings.Default.FDID, Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));
            }
            else
            {
                if (_jdc.State != System.ServiceModel.CommunicationState.Opened)
                {
                    _jdc = new JCSJData.DataServiceClient();
                    _jdc.FDZHLogin(Settings.Default.FDID, Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));
                }
            }
        }

        /// <summary>
        /// 手动输入条码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txb_tiaoma_KeyDown(object sender, KeyEventArgs e)
        {
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
    }
}