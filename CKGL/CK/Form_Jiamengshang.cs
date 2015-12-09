using CKGL.Properties;
using DB_CK;
using DB_CK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CKGL.CK
{
    public partial class Form_Jiamengshang : Form
    {
        public Form_Jiamengshang()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sch_Click(object sender, EventArgs e)
        {            
            DBContext db = IDB.GetDB();
            TJiamengshang[] jmses = db.GetJiamengshangs(null);

            grid_jms.Rows.Clear();
            foreach (TJiamengshang j in jmses)
            {
                grid_jms.Rows.Add(new object[] 
                    {
                        j.id,
                        j.mingcheng,
                        j.daima,
                        j.dizhi,
                        j.lianxiren,
                        j.dianhua
                    });
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KucunYilan_Load(object sender, EventArgs e)
        {
            //类型下拉框
            //Tool.CommonFunc.InitCombbox(cmb_leixing, typeof(Tool.JCSJ.DBCONSTS.KUANHAO_LX));
            //DataTable dt = (DataTable)cmb_leixing.DataSource;
            //dt.Rows.InsertAt(dt.NewRow(), 0);
            //cmb_leixing.SelectedIndex = 0;
        }

        /// <summary>
        /// 从服务器更新加盟商信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_shangbao_Click(object sender, EventArgs e)
        {
            new Tool.ActionMessageTool(delegate(Tool.ActionMessageTool.ShowMsg ShowMsg)
            {
                try
                {
                    JCSJData.TJiamengshang[] jjmses = JCSJWCF.GetJiamengshangs();
                    //转换为本地加盟商信息
                    DBContext db = IDB.GetDB();
                    db.UpdateJiamengshangZhuangtai();

                    foreach (JCSJData.TJiamengshang jj in jjmses)
                    {
                        TJiamengshang nj = new TJiamengshang
                        {
                            id = jj.id,
                            mingcheng = jj.mingcheng,
                            daima = jj.daima,
                            dizhi = jj.dizhi,
                            lianxiren = jj.lianxiren,
                            dianhua = jj.dianhua,
                            zhuangtai = true
                        };
                        TJiamengshang oj = db.GetJiamengshangById(jj.id);
                        if (oj != null)
                        {
                            db.UpdateJiamengshang(nj);
                        }
                        else
                        {
                            db.InsertJiamengshang(nj);
                        }
                    }

                    ShowMsg("完成", false);
                }
                catch (Exception ex)
                {
                    Tool.CommonFunc.LogEx(Settings.Default.LogFile, ex);
                    ShowMsg(ex.Message, true);
                }
            }, false).Start();
        }

        private void grid_jms_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DBContext db = IDB.GetDB();
            int id = (int)e.Row.Cells[col_id.Name].Value;
            try
            {
                db.DeleteJiamengshang(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败");
                e.Cancel = true;
            }
        }
    }
}
