using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BIANMA
{
    public partial class Dlg_JiazaiFahuoJilu : Form
    {
        public Dlg_JiazaiFahuoJilu()
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
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Dlg_JiazaiFahuoJilu_Load(object sender, EventArgs e)
        {
            Tool.CommonFunc.InitCombbox(cmb_pp, RuntimeInfo.JmPps, "mingcheng", "id");            
        }
    }
}
