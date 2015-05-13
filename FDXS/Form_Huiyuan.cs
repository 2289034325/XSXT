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
    public partial class Form_Huiyuan : MyForm
    {
        /// <summary>
        /// 基础数据WCF服务
        /// </summary>
        private JCSJData.DataServiceClient _jdc;
        private TUser _user;

        public Form_Huiyuan(TUser user)
        {
            InitializeComponent();
            _jdc = null;
            _user = user;
        }

        /// <summary>
        /// 查询库存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sch_Click(object sender, EventArgs e)
        {
            //查询条件
            //string tmh = txb_tiaoma.Text.Trim();
            //string kh = txb_kuanhao.Text.Trim();
            //string lx = cmb_leixing.SelectedValue.ToString();

            ////入-出+库存修正
            //DBContext db= new DBContext();
            //Dictionary<TTiaoma, short> ks = db.GetKucunView(tmh,kh,lx);

            //grid_kc.Rows.Clear();
            //foreach (KeyValuePair<TTiaoma, short> p in ks)
            //{
            //    grid_kc.Rows.Add(new object[] 
            //    {
            //        p.Key.tiaoma,
            //        p.Key.kuanhao,
            //        p.Key.gyskuanhao,
            //        ((JCSJData.DBCONSTS.KUANHAO_LX)p.Key.leixing).ToString(),
            //        p.Key.pinming,
            //        p.Key.yanse,
            //        p.Key.chima,
            //        p.Key.shoujia,
            //        p.Value
            //    });
            //}
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KucunYilan_Load(object sender, EventArgs e)
        {
            //类型下拉框
            //Tool.CommonFunc.InitCombbox(cmb_leixing, typeof(JCSJData.DBCONSTS.KUANHAO_LX));
            //DataTable dt = (DataTable)cmb_leixing.DataSource;
            //dt.Rows.InsertAt(dt.NewRow(), 0);
            //cmb_leixing.SelectedIndex = 0;
        }

        /// <summary>
        /// 更新会员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_hy_gxxx_Click(object sender, EventArgs e)
        {
            //取得被选中的会员ID
            int id = (int)grid_hy.SelectedRows[0].Cells[col_id.Name].Value;

            //调用接口
            JCSJData.THuiyuan jh = _jdc.GetHuiyuanById(id);

            //更新到本地
            DBContext db = new DBContext();
            THuiyuan fh = db.GetHuiyuanById(id);

            fh.shoujihao = jh.shoujihao;
            fh.xingming = jh.xingming;
            fh.xingbie = jh.xingbie;
            fh.shengri = jh.shengri;
            fh.xxgxshijian = DateTime.Now;

            fh.jifen = jh.jifen;
            fh.jfgxshijian = jh.jfjsshijian;

            db.UpdateHuiyuanAll(fh);
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
        /// 修改会员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmn_hy_edit_Click(object sender, EventArgs e)
        {
            loginJCSJ();

            //取得被选中的会员ID
            int id = (int)grid_hy.SelectedRows[0].Cells[col_id.Name].Value;
            Dlg_HuiyuanEdit dh = new Dlg_HuiyuanEdit( id,_jdc);
            dh.ShowDialog();
        }
    }
}
