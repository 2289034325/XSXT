using DB_FD;
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
    public partial class Dlg_HuiyuanEdit : Form
    {
        private int _id;

        public Dlg_HuiyuanEdit( int id)
        {
            InitializeComponent();
            _id = id;
        }


        /// <summary>
        /// 修改会员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string sjh = txb_sjh.Text.Trim();
            string xm = txb_xm.Text.Trim();
            byte xb = byte.Parse(cmb_xb.SelectedValue.ToString());
            DateTime sr = dp_sr.Value.Date;           

            THuiyuan fh = new THuiyuan 
            {
                id=_id,
                shoujihao = sjh,
                xingming = xm,
                xingbie = xb,
                shengri = sr
            };
            DBContext db = new DBContext();
            db.UpdateHuiyuanInfo(fh);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_HuiyuanEdit_Load(object sender, EventArgs e)
        {
            Tool.CommonFunc.InitCombbox(cmb_xb, typeof(Tool.JCSJ.DBCONSTS.HUIYUAN_XB));
            DBContext db = new DBContext();
            THuiyuan h = db.GetHuiyuanById(_id);

            txb_sjh.Text = h.shoujihao;
            txb_xm.Text = h.xingming;
            cmb_xb.SelectedValue = h.xingbie;
            dp_sr.Value = h.shengri;
        }
    }
}
