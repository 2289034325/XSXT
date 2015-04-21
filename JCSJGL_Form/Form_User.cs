using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool.DB.JCSJ;

namespace JCSJGL
{
    public partial class Form_User : Form
    {
        public Form_User()
        {
            InitializeComponent();

            grid_user.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_User_Load(object sender, EventArgs e)
        {
            //加载所有用户         
            refreshGrid();
        }


        /// <summary>
        /// 刷新表格数据
        /// </summary>
        private void refreshGrid()
        {
            Form_Main fm = (Form_Main)this.MdiParent;
            TUser[] us = fm.WCF.GetAllUsers(true);

            foreach (TUser u in us)
            {
                grid_user.Rows.Add(new object[] 
                {
                    u.id,
                    u.dengluming,
                    u.yonghuming,
                    (CONSTS.USER_XTJS)u.juese,
                    (CONSTS.USER_ZT)u.zhuangtai,
                    u.beizhu,
                    u.charushijian,
                    u.xiugaishijian
                });
            }
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_User_KeyDown(object sender, KeyEventArgs e)
        {
            //F5刷新，F2编辑，F6增加
            if (e.KeyCode == Keys.F5)
            {
                //刷新
                refreshGrid();
            }
            else if (e.KeyCode == Keys.F2)
            {
                //编辑
            }
            else if (e.KeyCode == Keys.F10)
            {
                //增加
            }            
        }
    }
}
