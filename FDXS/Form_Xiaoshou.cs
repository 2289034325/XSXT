using DB_FD;
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
    public partial class Form_Xiaoshou : MyForm
    {
        private TUser _user;
        //开单对话框
        private Dlg_xiaoshou _dlgKaidan;

        /// <summary>
        /// 基础数据WCF服务
        /// </summary>
        private JCSJData.DataServiceClient _jdc;

        public Form_Xiaoshou(TUser user)
        {
            InitializeComponent();
            _dlgKaidan = null;
            _user = user;
            _jdc = null;
        }

        /// <summary>
        /// 扫描枪事件
        /// </summary>
        /// <param name="tm"></param>
        public override void OnScan(string tm)
        {
            if (_dlgKaidan != null)
            {
                _dlgKaidan.OnScan(tm);
            }
            else
            {
                //打开开单对话框
                Dlg_xiaoshou dx = new Dlg_xiaoshou(tm,_user);
                _dlgKaidan = dx; 
                if (dx.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    List<TXiaoshou> xss = dx.XSS;
                    //保存到数据库
                    DBContext db = new DBContext();
                    TXiaoshou[] nxss = db.InsertXiaoshous(xss.ToArray());
                    foreach (TXiaoshou x in nxss)
                    {
                        addXiaoshou(x);
                    }
                }
                _dlgKaidan = null;
            }
        }

        /// <summary>
        /// 查询销售
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sch_Click(object sender, EventArgs e)
        {
            //查询条件
            string tmh = txb_tiaoma.Text.Trim();
            string kh = txb_kuanhao.Text.Trim();
            DateTime? dstart = dp_start.Checked ? (DateTime?)dp_start.Value.Date : null;
            DateTime? dend = dp_end.Checked ? (DateTime?)dp_end.Value.Date : null;

            //查询数据
            DBContext db= new DBContext();
            grid_xs.Rows.Clear();
            TXiaoshou[] xss = db.GetXiaoshousByCond(tmh, kh, dstart, dend);
            foreach (TXiaoshou x in xss)
            {
                addXiaoshou(x);
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KucunYilan_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 销售开单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_kd_Click(object sender, EventArgs e)
        {
                Dlg_xiaoshou dx = new Dlg_xiaoshou(null, _user);
                _dlgKaidan = dx;
                if (dx.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    List<TXiaoshou> xss = dx.XSS;
                    //保存到数据库
                    DBContext db = new DBContext();
                    TXiaoshou[] nxss = db.InsertXiaoshous(xss.ToArray());
                    foreach (TXiaoshou x in nxss)
                    {
                        addXiaoshou(x);
                    }
                    //将积分加给会员
                    decimal zj = decimal.Round(nxss.Sum(r => r.danjia * r.shuliang * r.zhekou / 10 - r.moliing), 0);
                    db.UpdateHuiyuanJF(dx._huiyuan.id, zj);
                }
                _dlgKaidan = null;
        }

        /// <summary>
        /// 在grid中插入新的销售记录
        /// </summary>
        /// <param name="nxss"></param>
        private void addXiaoshou(TXiaoshou x)
        {
            grid_xs.Rows.Insert(0,new object[] 
            {
                x.id,
                x.TTiaoma.tiaoma,
                x.TTiaoma.kuanhao,
                x.TTiaoma.gyskuanhao,
                x.TTiaoma.pinming,
                x.TTiaoma.yanse,
                x.TTiaoma.chima,
                x.danjia,
                x.shuliang,
                x.zhekou,
                x.moliing,
                //价格
                (x.danjia*x.shuliang*(x.zhekou/10)-x.moliing).ToString("##.##"),
                //销售员
                x.xiaoshouyuan,
                x.xiaoshoushijian,
                x.shangbaoshijian
            });
        }

        /// <summary>
        /// 检查销售记录是否允许被删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_xs_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = (int)e.Row.Cells[col_id.Name].Value;

            DBContext db = new DBContext();
            TXiaoshou x = db.GetXiaoshouById(id);
            if (x.shangbaoshijian != null)
            {
                e.Cancel = true;
                MessageBox.Show("销售记录已经上报，不允许删除");
            }
        }

        /// <summary>
        /// 上报销售数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_shangbao_Click(object sender, EventArgs e)
        {

            DBContext db = new DBContext();
            //取得未上报的销售记录
            TXiaoshou[] xs = db.GetXiaoshousWeishangbao();
            if (xs.Count() == 0)
            {
                MessageBox.Show("没有需要上报的数据");
                return;
            }

            JCSJData.TXiaoshou[] jxss = xs.Select(r=>new JCSJData.TXiaoshou
            {
                oid = r.id,
                xiaoshoushijian = r.xiaoshoushijian,
                xiaoshouyuan = r.TUser.yonghuming,
                tiaomaid = r.tiaomaid,
                huiyuanid = r.huiyuanid,
                shuliang = r.shuliang,
                danjia = r.danjia,
                zhekou = r.zhekou,
                moling = r.moliing                
            }).ToArray();

            //登陆到数据中心
            _jdc = CommonFunc.LoginJCSJ(_jdc);
            _jdc.ShangbaoXiaoshou(jxss);

            //更新本地上报时间
            int[] ids = xs.Select(r=>r.id).ToArray();
            db.UpdateXiaoshouShangbaoshijian(ids, DateTime.Now);

            MessageBox.Show("完成");
        }
    }
}
