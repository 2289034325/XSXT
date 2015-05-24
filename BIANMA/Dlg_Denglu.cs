using DB_JCSJ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIANMA
{
    public partial class Dlg_Denglu : Form
    {
        private JCSJData.DataServiceClient _dc;

        public TUser User;

        public Dlg_Denglu(JCSJData.DataServiceClient dc)
        {
            InitializeComponent();
            _dc = dc;
        }


        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string dlm = txb_dlm.Text.Trim();
            string mm = txb_mm.Text;

            try
            {
                User = _dc.BMZHLogin(dlm, Tool.CommonFunc.MD5_16(mm), Tool.CommonFunc.MD5_16(Tool.CommonFunc.GetJQM()));
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
