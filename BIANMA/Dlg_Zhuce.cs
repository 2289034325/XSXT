using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace BIANMA
{
    public partial class Dlg_Zhuce : Form
    {
        public Dlg_Zhuce()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 系统注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string dlm = txb_dlm.Text.Trim();
            string mm = txb_mm.Text;
            string xm = txb_xm.Text;
            string zcm = txb_zcm.Text.Trim();
            string tzm = Tool.CommonFunc.GetJQM();

            try
            {
                JCSJValid.ValidServiceClient vc = new JCSJValid.ValidServiceClient();               
                vc.BMZHZhuce(dlm, Tool.CommonFunc.MD5_16(mm), xm, Tool.CommonFunc.MD5_16(tzm), zcm);
                
                MessageBox.Show("注册成功");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        
    }
}
