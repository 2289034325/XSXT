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
    public partial class Dlg_Bangding : Form
    {
        public Dlg_Bangding()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 用户绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string dlm = txb_dlm.Text.Trim();
            string mm = txb_mm.Text;
            string zcm = txb_zcm.Text.Trim();
            string tzm = Tool.CommonFunc.GetJQM();

            try
            {
                JCSJWCF.BMZHBangding(dlm, mm, zcm);
                
                MessageBox.Show("绑定成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }       
    }
}
