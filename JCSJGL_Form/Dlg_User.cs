using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JCSJGL
{
    public partial class Dlg_User : Form
    {
        public Dlg_User()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dlg_User_Load(object sender, EventArgs e)
        {
            Tool.CommonFunc.InitCombbox(cmb_js, typeof(Tool.DB.JCSJ.CONSTS.USER_XTJS));
        }
    }
}
