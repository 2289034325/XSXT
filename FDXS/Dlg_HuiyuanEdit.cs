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
        private JCSJData.DataServiceClient _jdc;

        public Dlg_HuiyuanEdit( int id,JCSJData.DataServiceClient jdc)
        {
            InitializeComponent();
            _id = id;
            _jdc = jdc;
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
           
            JCSJData.THuiyuan jh = new JCSJData.THuiyuan
            {
                id = _id,
                shoujihao = sjh,
                xingming = xm,
                xingbie = xb,
                shengri = sr,
                xiugaishijian = DateTime.Now
            };

            _jdc.UpdateHuiyuan(jh);

            //更新本地信息
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
    }
}
