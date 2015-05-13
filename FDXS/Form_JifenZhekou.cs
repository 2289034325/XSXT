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
    public partial class Form_JifenZhekou : MyForm
    {
        private JCSJData.DataServiceClient _jdc;
        private TUser _user;
        public Form_JifenZhekou(TUser user)
        {
            InitializeComponent();
            _user = user;
            _jdc = null;
        }

        /// <summary>
        /// 登陆数据中心
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
        /// 更新积分规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sch_Click(object sender, EventArgs e)
        {
            loginJCSJ();

            JCSJData.THuiyuanZK[] zks = _jdc.GetHuiyuanZhekous();

            DBContext db = new DBContext();
            THuiyuanZK[] fzks = zks.Select(r => new THuiyuanZK 
            {
                jifen = r.jifen,
                zhekou = r.zhekou
            }).ToArray();
            db.DeleteHuiyuanZK();
            db.InsertHuiyuanZKs(fzks);

            grid_zk.Rows.Clear();
            foreach (THuiyuanZK zk in fzks)
            {
                grid_zk.Rows.Add(new object[] 
                {
                    zk.jifen,
                    zk.zhekou
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
            //加载积分折扣规则
            DBContext db = new DBContext();
            THuiyuanZK[] zks = db.GetHuiyuanZKs();

            foreach (THuiyuanZK zk in zks)
            {
                grid_zk.Rows.Add(new object[] 
                {
                    zk.jifen,
                    zk.zhekou
                });
            }
        }
    }
}
