using DB_FD;
using DB_FD.Models;
using FDXS.Properties;
using MyFormControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace FDXS
{
    public partial class Form_Xiaoshou : MyForm
    {
        //开单对话框
        //private Dlg_xiaoshou _dlgKaidan;
        //开单数据
        //private List<TXiaoshou> _XSS;

        public Form_Xiaoshou()
        {
            InitializeComponent();
            //_dlgKaidan = null;
            //_XSS = null;
        }

        /// <summary>
        /// 扫描枪事件
        /// </summary>
        /// <param name="tm"></param>
        public override void OnScan(string tm)
        {
            //if (_dlgKaidan != null)
            //{
            //    _dlgKaidan.OnScan(tm);
            //}
            //else
            //{
            //    //打开开单对话框
            //    Dlg_xiaoshou dx = new Dlg_xiaoshou(tm);
            //    _dlgKaidan = dx; 
            //    if (dx.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //    {
            //        //xiaoshouDlgOK(dx.XSS,dx.Huiyuan);
            //        btn_sch_Click(null, null);
            //    }
            //    _dlgKaidan = null;
            //}
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
            DateTime? dend = dp_end.Checked ? (DateTime?)dp_end.Value.Date.AddDays(1) : null;

            //查询数据
            DBContext db = IDB.GetDB();
            grid_xs.Rows.Clear();
            TXiaoshou[] xss = db.GetXiaoshousByCond(tmh, kh, dstart, dend);
            int tsl = 0;
            foreach (TXiaoshou x in xss)
            {
                tsl += x.shuliang;
                addXiaoshou(x);
            }

            //合計行
            //int index = grid_xs.Rows.Add();
            //grid_xs.Rows[index].Cells[col_tm.Name].Value = "合計";
            //grid_xs.Rows[index].Cells[col_sl.Name].Value = tsl;
            //grid_xs.Rows[index].DefaultCellStyle.ForeColor = Color.Red;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KucunYilan_Load(object sender, EventArgs e)
        {
            //隐藏折扣列
            if (RuntimeInfo.LoginUser.juese == (byte)Tool.FD.DBCONSTS.USER_XTJS.店员)
            {
                col_zk.Visible = false;
                col_ml.Visible = false;
                col_jg.Visible = false;
            }

            //显示开单
            //btn_kd_Click(null, null);
        }

        /// <summary>
        /// 销售开单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_kd_Click(object sender, EventArgs e)
        {
                //Dlg_xiaoshou dx = new Dlg_xiaoshou(null);
                //_dlgKaidan = dx;
                //if (dx.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //{
                //    //xiaoshouDlgOK(dx.XSS, dx.Huiyuan);
                //    btn_sch_Click(null, null);
                //}
                //_dlgKaidan = null;
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
                x.TTiaoma== null?"":x.TTiaoma.tiaoma,
                x.TTiaoma== null?"":x.TTiaoma.kuanhao,
                x.TTiaoma== null?"":x.TTiaoma.gyskuanhao,
                x.TTiaoma== null?"":x.TTiaoma.pinming,
                x.TTiaoma== null?"":x.TTiaoma.yanse,
                x.TTiaoma== null?"":x.TTiaoma.chima,
                x.shoujia,
                x.shuliang,
                x.zhekou,
                x.moling,
                //金额
                x.jine.ToString("00.00"),
                //销售员
                x.xiaoshouyuan,
                x.xiaoshoushijian,
                x.shangbaoshijian,
                x.beizhu
            });

            refreshTotal();
        }

        /// <summary>
        /// 刷新总数
        /// </summary>
        private void refreshTotal()
        {
            decimal tjg = 0;
            decimal tsl = 0;
            decimal tml = 0;
            foreach (DataGridViewRow dr in grid_xs.Rows)
            {
                decimal jg = decimal.Parse(dr.Cells[col_jg.Name].Value.ToString());
                decimal sl = decimal.Parse(dr.Cells[col_sl.Name].Value.ToString());
                decimal ml = decimal.Parse(dr.Cells[col_ml.Name].Value.ToString());
                tjg += jg;
                tsl += sl;
                tml += ml;
            }

            col_jg.HeaderText = "价格(" + tjg + ")";
            col_sl.HeaderText = "数量(" + tsl + ")";
            col_ml.HeaderText = "抹零(" + tml + ")";
        }

        /// <summary>
        /// 检查销售记录是否允许被删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_xs_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            int id = (int)e.Row.Cells[col_id.Name].Value;

            DBContext db = IDB.GetDB();
            TXiaoshou x = db.GetXiaoshouById(id);

            if (x.tiaomaid != null)
            {
                //检查是否会导致库存数量为负，因为有可能删除的是退货记录，销售数量为负数
                VKucun kc = db.GetKucunByTiaomaId(x.tiaomaid.Value);
                if (kc.shuliang + x.shuliang < 0)
                {
                    e.Cancel = true;
                    MessageBox.Show("删除后会导致库存数量为负数");
                    return;
                }
            }

            if (x.shangbaoshijian != null)
            {
                if ((DateTime.Now - x.shangbaoshijian.Value).TotalDays > 1)
                {
                    e.Cancel = true;
                    MessageBox.Show("上报已经超过1天的数据，不允许删除");
                    return;
                }
                else
                {
                    if (MessageBox.Show("是否确定删除", "确认", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        //先去服务器删除
                        new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
                            {
                                JCSJWCF.DeleteXiaoshou(x.id);
                                db.DeleteXiaoshou(id);

                                ShowMsg("删除成功", false);

                            }, false).Start();
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            else
            {
                db.DeleteXiaoshou(id);
            }
        }

        /// <summary>
        /// 删除一个销售记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grid_xs_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //int id = (int)e.Row.Cells[col_id.Index].Value;
            //DBContext db = IDB.GetDB();

            ////把会员积分减掉
            //TXiaoshou x = db.GetXiaoshouById(id);
            //if (x.huiyuanid != null)
            //{
            //    decimal jf = 0 - x.jine;
            //    db.UpdateAddHuiyuanJF(x.huiyuanid.Value, jf);
            //}

            //db.DeleteXiaoshou(id);

        }

        /// <summary>
        /// 上报销售数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_shangbao_Click(object sender, EventArgs e)
        {
            new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
            {
                try
                {
                    MyTask.SBXiaoshou();
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
